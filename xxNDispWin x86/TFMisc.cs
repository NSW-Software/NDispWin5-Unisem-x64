using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace NDispWin
{
    class TFMisc
    {
    }

    class TFVideoLogger
    {
        static int port = 11000;
        public static bool WritePort(string msg)
        {
            int retried = 0;
        _Retry:
            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                TcpClient client = new TcpClient(ipAddress.ToString(), port);

                // Create a TCP/IP  socket.    
                var stream = client.GetStream();

                //Check socket
                if (stream.CanRead)
                {
                    if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        if (client.Client.Receive(new byte[1], SocketFlags.Peek) is 0)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISP_RECORDER_DISCONNECTED);
                            return false;
                        }
                    }
                }

                try
                {
                    byte[] bytes;
                    bytes = Encoding.ASCII.GetBytes(msg);
                    stream.Write(bytes, 0, bytes.Length);
                }
                //catch (ArgumentNullException ane)
                //{
                //    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                //}
                //catch (SocketException se)
                //{
                //    Console.WriteLine("SocketException : {0}", se.ToString());
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                //}
                finally
                {
                    stream.Close();
                    client.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (retried < 3)
                {
                    retried++;
                    Log.AddToLog($"WritePort retried {retried}. " + ex.Message.ToString());
                    goto _Retry;
                }

                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISP_RECORDER_COMMAND_ERR, ex.Message.ToString());
                return false;
            }
        }
        public static bool TxRxPort(string txMsg, ref string rxMsg)
        {
            int retried = 0;
            _Retry:
            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                TcpClient client = new TcpClient(ipAddress.ToString(), 11000);

                // Create a TCP/IP  socket.    
                var stream = client.GetStream();

                //Check socket
                if (stream.CanRead)
                {
                    if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        if (client.Client.Receive(new byte[1], SocketFlags.Peek) is 0)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISP_RECORDER_DISCONNECTED);
                            return false;
                        }
                    }
                }

                try
                {
                    byte[] bytes;
                    bytes = Encoding.ASCII.GetBytes(txMsg);
                    stream.Write(bytes, 0, bytes.Length);

                    byte[] rx = new byte[client.ReceiveBufferSize];
                    stream.ReadTimeout = 800;
                    stream.Read(rx, 0, rx.Length);
                    rxMsg = Encoding.ASCII.GetString(rx).Trim('\0');
                    if (rx.Length == 0)
                    {
                        Log.AddToLog("NoResp");
                        return false;
                    }

                    return true;
                }
                finally
                {
                    stream.Close();
                    client.Close();
                }
                //return true;
            }
            catch (Exception ex)
            {
                if (retried < 2)
                {
                    retried++;
                    Log.AddToLog($"TxRxPort retried {retried}. " + ex.Message.ToString());
                    System.Threading.Thread.Sleep(100);
                    goto _Retry;
                }
                return false;
            }
        }
        public static bool TaskWritePort(string msg)
        {
            //Log.LmdsCT.WriteByMonthDay(msg);
            System.Threading.Thread.Sleep(1);
            if (!WritePort(msg))
            {
                //Msg MsgBox = new Msg();
                //MsgBox.Show(ErrCode.DISP_RECORDER_COMMAND_ERR);
                return false;
            }
            return true;
        }
        public static bool TaskIsReady(ref bool ready)
        {
            string rx = "";
            if (!TxRxPort("ReadyStatus", ref rx))
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISP_RECORDER_NO_RESPONSE_ERR);
                return false;
            }
            ready = rx.StartsWith("1");
            return true;
        }
    }

    class TFTempLogger
    {
        public static bool GetTemp(ref string rxMessage)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            TcpClient client = new TcpClient(Convert.ToString(ipAddress), 11001);

               var stream = client.GetStream();

                //Check socket
                if (stream.CanRead)
                {
                    if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        if (client.Client.Receive(new byte[1], SocketFlags.Peek) is 0)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISP_RECORDER_DISCONNECTED);
                            return false;
                        }
                    }
                }

            try
            {
                byte[] tx = Encoding.ASCII.GetBytes($"GETTEMP\r\n");
                stream.Write(tx, 0, tx.Length);

                byte[] rx = new byte[client.ReceiveBufferSize];
                stream.Read(rx, 0, rx.Length);

                rxMessage = Encoding.ASCII.GetString(rx).Trim('\0');
            }
            catch
            {

            }
            finally
            {
                stream.Close();
                client.Close();
            }

            return true;
        }
    }
}