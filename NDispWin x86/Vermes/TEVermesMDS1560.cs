using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace NDispWin
{
    public class ASCII
    {
        public static string GetGlyph(Char C)
        {
            switch (C)
            {
                #region
                default: return C.ToString();// "<" + (byte)C + ">";
                case (char)0: return "<NUL>";
                case (char)1: return "<SOH>";
                case (char)2: return "<STX>";
                case (char)3: return "<ETX>";
                case (char)4: return "<EOT>";
                case (char)5: return "<ENQ>";
                case (char)6: return "<ACK>";
                case (char)7: return "<BEK>";
                case (char)8: return "<BS>";
                case (char)9: return "<HT>";
                case (char)10: return "<LF>";
                case (char)11: return "<VT>";
                case (char)12: return "<FF>";
                case (char)13: return "<CR>";
                case (char)14: return "<SO>";
                case (char)15: return "<SI>";
                case (char)16: return "<DLE>";
                case (char)17: return "<DC1>";
                case (char)18: return "<DC2>";
                case (char)19: return "<DC3>";
                case (char)20: return "<DC4>";
                case (char)21: return "<NAK>";
                case (char)22: return "<SYN>";
                case (char)23: return "<ETB>";
                case (char)24: return "<CAN>";
                case (char)25: return "<EM>";
                case (char)26: return "<SUB>";
                case (char)27: return "<ESC>";
                case (char)28: return "<FS>";
                case (char)29: return "<GS>";
                case (char)30: return "<RS>";
                case (char)31: return "<US>";
                case (char)127: return "<DEL>";
                    #endregion
            }
        }
        public static string GetGlyph(string S)
        {
            string str = "";
            foreach (char C in S)
            {
                str = str + ASCII.GetGlyph(C);
            }

            return str;
        }
    }

    public class TEVermesMDS1560
    {
        public SerialPort sp = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);

        Mutex ComMutex = new Mutex();
        #region Serial Port Low Level
        public void TX(string tx)
        {
            if (!sp.IsOpen) throw new Exception("Port Is Not Open.");


            ComMutex.WaitOne();
            try
            {
                tx = tx + (char)13;
                sp.Write(tx);
                AddLog("<- " + ASCII.GetGlyph(tx));
            }
            catch (Exception ex)
            {
                string exMsg = this.GetType().Name + " " + ex.Message.ToString();
                AddLog(exMsg);
                throw new Exception(exMsg);
            }
            finally
            {
                ComMutex.ReleaseMutex();
            }
        }
        public void RX_Clear()
        {
            try
            {
                sp.DiscardInBuffer();
            }
            catch
            {
                throw;
            }
        }
        public int RX_Buffer
        {
            get
            {
                try
                {
                    return sp.BytesToRead;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void RX_EOR(ref string rx)
        {
            ComMutex.WaitOne();
            try
            {
                sp.ReadTimeout = 3000;
                string EOR = ((char)10).ToString();
                rx = sp.ReadTo(EOR);
                rx = rx.Remove(rx.Length - 1);
                AddLog("-> " + ASCII.GetGlyph(rx));
            }
            catch (Exception ex)
            {
                string exMsg = this.GetType().Name + " " + ex.Message.ToString();
                AddLog(exMsg);
                throw new Exception(exMsg);
            }
            finally
            {
                ComMutex.ReleaseMutex();
            }
        }
        #endregion


        internal bool LogComm = false;
        public void AddLog(string s)
        {
            if (LogComm)
            {
                string FileName = "c:\\Vermes" + "\\Vermes_MDS1560_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                NUtils.LogFileW file = new NUtils.LogFileW(FileName);
                file.Write(s);
            }
        }

        internal int CtrlID = 0;

        internal string sIDN = "";
        internal string sMDVInfo = "";
        public double[] OT = new double[] { 2, 4, 6, 8 };//OpenTime(ms)
        public double[] CT = new double[] { 5, 5, 5, 5 };//CloseTime(ms)
        public int[] NP = new int[] { 10, 10,10,10 };//NumberOfPulse
        public double Target = 0;//Target Value

        public bool Open(string ComPort)
        {
            try
            {
                sp.PortName = ComPort;
                sp.Open();

                AddLog("Open - " + ComPort);

                RX_Clear();
                TX("*IDN?");//Vermes Microdispensing, MDC-1500, 01P10015, 4013PV1-A
                string rx = "";
                RX_EOR(ref rx);
                rx = rx.Trim();
                if (!rx.StartsWith("Vermes"))
                {
                    throw new Exception("Identification Query Fail");
                }
                sIDN = rx;


                RX_Clear();
                TX("MDV:INFO?");
                RX_EOR(ref rx);
                sMDVInfo = rx;

                //Set();

                return true;
            }
            catch (Exception Ex)
            {
                sp.Close();
                AddLog("Open - " + Ex.Message.ToString());
                throw Ex;
            }
        }
        public bool IsOpen
        {
            get
            {
                return sp.IsOpen;
            }
        }
        public void Close()
        {
            try
            {
                sp.Close();
                AddLog("Close");
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
            finally
            {
                sIDN = "";
                sMDVInfo = "";
            }
        }
        public int ValveCycles
        {
            get 
            { 
                TX("MDV:CYCLES?");
                string rx = "";
                RX_EOR(ref rx);//OK 1234567

                int c = 0;
                if (rx.StartsWith("OK"))
                {
                    string s = rx.Remove(0, 3);
                    int.TryParse(s, out c);

                }
                return c;
            }
        }

        public void ValveOpen()
        {
            try
            {
                TX("MDV:OPEN");
                string rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("OK")) return;
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");
                throw new Exception("Invalid Response.");
            }
            catch
            {
                throw;
            }
        }
        public void ValveClose()
        {
            try
            {
                TX("MDV:CLOSE");
                string rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("OK")) return;
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");
                throw new Exception("Invalid Response.");
            }
            catch
            {
                throw;
            }
        }

        public void UpdateSetup()//  Update current SetupNo values
        {
            try
            {
                TX("MDC1500:SETUP1 " + OT[0].ToString() + "m," + CT[0].ToString() + "m," + NP[0].ToString() + ",1");
                string rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("OK")) return;
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");
                throw new Exception("Invalid Response.");
            }
            catch
            {
                throw;
            }
        }
        public void Run()//  Run current values
        {
            try
            {
                TX("MDC1500:RUN " + OT[0].ToString() + "m," + CT[0].ToString() + "m," + NP[0].ToString() + ",1");
                string rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("OK")) return;
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");
                throw new Exception("Invalid Response.");
            }
            catch
            {
                throw;
            }
        }

        public void SetTarget(double temp)
        {
            try
            {
                RX_Clear();
                string cmd = "MDH:MODE 1";
                TX(cmd);
                string rx = "";
                RX_EOR(ref rx);

                //if (rx.Contains("ERROR")) throw new Exception("Transmission Error.");
                //if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");

                RX_Clear();
                int data = (int)(temp);
                cmd = "MDH:TARGET " + data.ToString();
                TX(cmd);
                rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("OK")) return;
                if (rx.Contains("ERROR")) throw new Exception("Transmission Error.");
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");
                if (rx.Contains("NOT OK")) throw new Exception("MDS1560 Set Target Temp Failed.");
                throw new Exception("Invalid Response.");
            }
            catch
            {
                throw;
            }
        }
        public void SetTarget()
        {
            SetTarget(Target);
        }
        public void GetTarget(ref double temp)
        {
            try
            {
                RX_Clear();
                string cmd = "MDH:TARGET?";
                TX(cmd);
                string rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("ERROR")) throw new Exception("Transmission Error.");
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");

                string s = rx;
                s = s.Remove(0, s.IndexOf(" ") + 1);

                int value = 0;
                if (!int.TryParse(rx, out value)) throw new Exception("Get Target Error.");
                temp = (double)value;
            }
            catch
            {
                throw;
            }
        }
        public void GetValue(ref double temp)
        {
            try
            {
                RX_Clear();
                string cmd = "MDH:STAT?";
                TX(cmd);
                string rx = "";
                RX_EOR(ref rx);//  OK OFF,20048m or OK ON, STABLE, 30000m

                if (rx.Contains("ERROR")) throw new Exception("Transmission Error.");
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");

                string s = rx;
                s = s.Remove(0, s.LastIndexOf(",") + 1);
                s = s.Remove(s.IndexOf("m"));
                s = s.Trim();

                int value = 0;
                if (!int.TryParse(s, out value)) throw new Exception("Get Target Error.");
                temp = (double)value / 1000;
            }
            catch
            {
                throw;
            }
        }
    }

    public class TEVermesHeaterHC48
    {
        //default values of Vermes_HC48, in accordance to 20171009 Rev1
        public SerialPort sp = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);

        Mutex ComMutex = new Mutex();
        #region Serial Port Low Level
        public void TX(string tx)
        {
            if (!sp.IsOpen) throw new Exception("Port Is Not Open.");


            ComMutex.WaitOne();
            try
            {
                tx = tx + (char)13;
                sp.Write(tx);
                AddLog("<- " + ASCII.GetGlyph(tx));
            }
            catch (Exception ex)
            {
                string exMsg = this.GetType().Name + " " + ex.Message.ToString();
                AddLog(exMsg);
                throw new Exception(exMsg);
            }
            finally
            {
                ComMutex.ReleaseMutex();
            }
        }
        public void RX_Clear()
        {
            try
            {
                sp.DiscardInBuffer();
            }
            catch
            {
                throw;
            }
        }
        public int RX_Buffer
        {
            get
            {
                try
                {
                    return sp.BytesToRead;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void RX_EOR(ref string rx)
        {
            ComMutex.WaitOne();
            try
            {
                sp.ReadTimeout = 3000;
                string EOR = ((char)13).ToString();
                rx = sp.ReadTo(EOR);
                //rx = rx.Remove(rx.Length - 1);
                rx = rx.Trim();
                AddLog("-> " + ASCII.GetGlyph(rx));
            }
            catch (Exception ex)
            {
                string exMsg = this.GetType().Name + " " + ex.Message.ToString();
                AddLog(exMsg);
                throw new Exception(exMsg);
            }
            finally
            {
                ComMutex.ReleaseMutex();
            }
        }
        #endregion

        internal bool LogComm = false;
        public void AddLog(string s)
        {
            if (LogComm)
            {
                string FileName = "c:\\Vermes" + "\\Vermes_HC48_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                NUtils.LogFileW file = new NUtils.LogFileW(FileName);
                file.Write(s);
            }
        }

        internal string sIDN = "";
        internal string sFWV = "";//firmware version
        public double Target = 0;//Target Value
        public double Tolerance = 0;//Tolerance

        public bool Open(string ComPort)
        {
            try
            {
                sp.PortName = ComPort;
                sp.Open();

                AddLog("Open - " + ComPort);

                RX_Clear();
                TX("*IDN?");//Vermes Microdispensing, MDC-1500, 01P10015, 4013PV1-A
                string rx = "";
                RX_EOR(ref rx);
                if (!rx.StartsWith("*"))
                {
                    throw new Exception("Identification Query Fail");
                }
                sIDN = rx;


                RX_Clear();
                TX("SYS:FWV?");
                RX_EOR(ref rx);
                sFWV = rx;

                return true;
            }
            catch (Exception Ex)
            {
                sp.Close();
                AddLog("Open - " + Ex.Message.ToString());
                throw Ex;
            }
        }
        public bool IsOpen
        {
            get
            {
                return sp.IsOpen;
            }
        }
        public void Close()
        {
            try
            {
                sp.Close();
                AddLog("Close");
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
            finally
            {
                sIDN = "";
                sFWV = "";
            }
        }

        public void HeaterOn(bool status)
        {
            try
            {
                RX_Clear();
                string cmd = "OUT:CHA:STAT" + (status? "1":"0") + ",1";//Set heater on/off, save set value
                TX(cmd);
                string rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("ACK")) return;

                if (rx.Contains("ERROR")) throw new Exception("Transmission Error.");
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");
                throw new Exception("Invalid Response.");
            }
            catch
            {
                throw;
            }
        }

        public void SetTarget(double temp)
        {
            try
            {
                RX_Clear();
                int data = (int)(temp * 1000);
                string cmd = "OUT:TEMP" + data.ToString() + ",1";//  mC, save set value
                TX(cmd);
                string rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("ACK"))
                {
                    Target = temp;
                    return;
                }

                if (rx.Contains("ERROR")) throw new Exception("Transmission Error.");
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");
                throw new Exception("Invalid Response.");
            }
            catch
            {
                throw;
            }
        }
        public void GetTarget(ref double temp)
        {
            try
            {
                RX_Clear();
                string cmd = "OUT:TEMP?";
                TX(cmd);
                string rx = "";
                RX_EOR(ref rx);

                if (rx.Contains("ERROR")) throw new Exception("Transmission Error.");
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");

                int value = 0;
                if (!int.TryParse(rx, out value)) throw new Exception("Get Target Error.");
                temp = (double)value / 1000;
            }
            catch
            {
                throw;
            }
        }
        public void GetValue(ref double temp)
        {
            try
            {
                RX_Clear();
                string cmd = "IN:TEMP?";
                TX(cmd);
                string rx = "";
                RX_EOR(ref rx);//  return 28000 (Min: 23500, Max: 29200)

                if (rx.Contains("ERROR")) throw new Exception("Transmission Error.");
                if (rx.Contains("NAK")) throw new Exception("Invalid Command or Value.");

                string s = rx;//.Remove(rx.IndexOf("("), rx.Length);
                s = s.Remove(0, s.IndexOf(">")+1);
                s = s.Remove(s.IndexOf("("));

                int value = 0;
                if (!int.TryParse(s, out value)) throw new Exception("Get Target Error.");
                temp = (double)value / 1000;
            }
            catch
            {
                throw;
            }
        }
    }
}
