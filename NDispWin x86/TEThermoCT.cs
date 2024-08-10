using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace NDispWin
{
    public class TEThermoCT
    {
        static Mutex mutex = new Mutex();
        static SerialPort port { get; set; } = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);

        public bool Open(string comPort, int baudRate = 9600)
        {
            if (!port.IsOpen)
            {
                try
                {
                    port.PortName = comPort;
                    port.BaudRate = baudRate;
                    port.Open();
                    port.DiscardInBuffer();

                }
                catch
                {
                    throw new Exception("Open Port Error");
                }
            }
            return true;
        }
        public bool IsOpen { get => port.IsOpen; }
        public void Close()
        {
            try
            {
                port.Close();
            }
            catch { };
        }

        class Command
        {
            public const byte READ_PROCESS = 0x01;//return 2 bytes
            public const byte READ_SERIAL_NO = 0x0E;//return 3 bytes
            public const byte READ_FW_REV = 0x0F;//retun 2 bytes
            public const byte READ_SENS_INFO = 0x45;//retun 8 bytes, byte1,2=ModelWord, byte3,4=LowerTemp, byte5,6=UpperTemp
        }

        public bool ReadProcess(ref double value)
        {
            mutex.WaitOne();
            try
            {
                port.WriteTimeout = 100;
                port.DiscardInBuffer();
                byte[] buf = new byte[] { Command.READ_PROCESS };
                port.Write(buf, 0, 1);

                var sw =  Stopwatch.StartNew();
                while (port.BytesToRead < 2)
                {
                    if (sw.ElapsedMilliseconds >= 100)
                    {
                        throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + " Timeout.");
                    }
                    Thread.Sleep(0);
                }

                byte[] rxBuf = new byte[1024];
                port.Read(rxBuf, 0, 2);
                value = (double)(((rxBuf[0] * 256) + rxBuf[1]) - 1000 )/ 10;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        public bool ReadSerialNo(ref string serialNo)
        {
            mutex.WaitOne();
            try
            {
                port.WriteTimeout = 100;
                port.DiscardInBuffer();
                byte[] buf = new byte[] { Command.READ_SERIAL_NO };
                port.Write(buf, 0, 1);

                var sw = Stopwatch.StartNew();
                while (port.BytesToRead < 3)
                {
                    if (sw.ElapsedMilliseconds >= 100)
                    {
                        throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + " Timeout.");
                    }
                    Thread.Sleep(0);
                }

                byte[] rxBuf = new byte[1024];
                port.Read(rxBuf, 0, 3);
                serialNo = ((rxBuf[0] * 65536) + (rxBuf[1] * 256) + rxBuf[2]).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        public bool ReadFWVer(ref string fwVer)
        {
            mutex.WaitOne();
            try
            {
                port.WriteTimeout = 100;
                port.DiscardInBuffer();
                byte[] buf = new byte[] { Command.READ_SERIAL_NO };
                port.Write(buf, 0, 1);

                var sw = Stopwatch.StartNew();
                while (port.BytesToRead < 2)
                {
                    if (sw.ElapsedMilliseconds >= 100)
                    {
                        throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + " Timeout.");
                    }
                    Thread.Sleep(0);
                }

                byte[] rxBuf = new byte[1024];
                port.Read(rxBuf, 0, 2);
                fwVer = ((rxBuf[0] * 256) + rxBuf[1]).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        public bool ReadSensorInfo(ref int modelWord, ref double lowerTemp, ref double upperTemp)
        {
            mutex.WaitOne();
            try
            {
                port.WriteTimeout = 100;
                port.DiscardInBuffer();
                byte[] buf = new byte[] { Command.READ_SENS_INFO };
                port.Write(buf, 0, 1);

                var sw = Stopwatch.StartNew();
                while (port.BytesToRead < 6)
                {
                    if (sw.ElapsedMilliseconds >= 100)
                    {
                        throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + " Timeout.");
                    }
                    Thread.Sleep(0);
                }

                byte[] rxBuf = new byte[1024];
                port.Read(rxBuf, 0, 6);
                modelWord = (rxBuf[0] * 256) + rxBuf[1];//no information in manual
                lowerTemp = (double)(((rxBuf[2] * 256) + rxBuf[3]) - 1000) / 10;
                upperTemp = (double)(((rxBuf[4] * 256) + rxBuf[5]) - 1000) / 10;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }

    public class TFTempSensor
    {
        public static TEThermoCT ThermoCT = new TEThermoCT();

        public static bool Open()
        {
            try
            {
                if (SysConfig.TempSensorType == SysConfig.ETempSensorType.UE_thermoCT)
                    ThermoCT.Open(SysConfig.TempSensorComport, 115200);
            }
            catch (Exception ex)
            {
                    string EMsg = MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString();
                    Msg msgBox = new Msg();
                    msgBox.Show(ErrCode.TEMPSENSOR_OPEN_ERR, EMsg);
                    return false;
            }
            return true;
        }
        public static bool IsOpen { get => ThermoCT.IsOpen; }
        public static bool Close()
        {
            try
            {
                if (SysConfig.TempSensorType == SysConfig.ETempSensorType.UE_thermoCT)
                    ThermoCT.Close();
            }
            catch (Exception ex)
            {
            }
            return true;
        }

        public static bool GetTemp(ref double value, bool PromptError = true)
        {
            try
            {
                switch (SysConfig.TempSensorType)
                {
                    case SysConfig.ETempSensorType.None: break;
                    default:
                        if (PromptError)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.LASER_NOT_CONFIG_ERR);
                        }
                        return false;
                    case SysConfig.ETempSensorType.UE_thermoCT:
                        {
                            double temp = 0;
                            TFTempSensor.ThermoCT.ReadProcess(ref temp);
                            value = temp;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (PromptError)
                {
                    string EMsg = MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString();
                    Msg msgBox = new Msg();
                    msgBox.Show(ErrCode.TEMPSENSOR_READ_FAIL, EMsg);
                    return false;
                }
            }
            return true;
        }
    }
}
