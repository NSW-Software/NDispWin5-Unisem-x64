using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;

namespace WGH_Series
{
    public static class TEWeight
    {
        #region Constant
        internal class AD212C
        {
            //***query commands
            public const string STOP_OUTPUT = "C";//stop output
            public const string CONT_OUTPUT = "SIR";//output reading cont
            public const string READ_IMME = "Q";//read immediately
            public const string READ_STABLE = "S";//read stable result

            public const string OFF_DISPLAY = "OFF";//standby mode
            public const string ON_DISPLAY = "ON";//weight mode, calls SIR after ON
            public const string TARE = "R";

            public const string HEADER_STABLE = "ST";
            public const string HEADER_UNSTABLE = "US";
            public const string HEADER_OVER = "OL";
        }

        internal class MT_SICS_VMS
        {
            public const string SET_UNIT = "M21";
            public const string READ_STABLE = "S";
            public const string READ_IMME = "SI";
            public const string TARE = "T";
            public const string ZERO = "T";
        }
        #endregion

        public enum EWeighType
        {
            None,
            JB1603,//Mettler Toledo Comercial Model JB1603
            ALD214,
            AD4212C,//AND Model AD4212C
            MT_SICS_VMS,//Mettler Toledo Standard Interface Command Set
            Simulator,
        }
        public static EWeighType TypeWeight;
        public static SerialPort WeighPort = new SerialPort();
        public static string PortNo = "COM1";

        private static void Delays(int ms)
        {
            if (ms <= 0) return;

            int t = Environment.TickCount + ms;
            while (true)
            {
                if (Environment.TickCount >= t) return;
            }
        }
        public static void Open(string ComPort, EWeighType typeWeight)
        {
            try
            {
                if (typeWeight == TEWeight.EWeighType.None) throw new Exception("Invalide weight type");

                PortNo = ComPort;
                TypeWeight = typeWeight;
                WeighPort.PortName = ComPort;

                switch (TypeWeight)
                {
                    case TEWeight.EWeighType.ALD214:
                    case TEWeight.EWeighType.JB1603:
                    default:
                        {
                            WeighPort.BaudRate = 9600;
                            WeighPort.DataBits = 8;
                            WeighPort.Parity = Parity.None;
                            WeighPort.StopBits = StopBits.One;
                            WeighPort.Handshake = Handshake.None;
                            break;
                        }
                    case TEWeight.EWeighType.AD4212C:
                        {
                            WeighPort.BaudRate = 19200;
                            WeighPort.DataBits = 7;
                            WeighPort.Parity = Parity.Even;
                            WeighPort.StopBits = StopBits.One;
                            WeighPort.Handshake = Handshake.None;
                            break;
                        }
                    case TEWeight.EWeighType.MT_SICS_VMS:
                        {
                            WeighPort.BaudRate = 9600;
                            WeighPort.DataBits = 8;
                            WeighPort.Parity = Parity.None;
                            WeighPort.StopBits = StopBits.One;
                            WeighPort.Handshake = Handshake.None;
                            break;
                        }
                }
                WeighPort.WriteTimeout = 1000;
                WeighPort.ReadTimeout = 1000;
                WeighPort.Open();


                switch (TypeWeight)
                {
                    case TEWeight.EWeighType.ALD214:
                    case TEWeight.EWeighType.JB1603:
                    default:
                        {
                            break;
                        }
                    case TEWeight.EWeighType.AD4212C:
                        {
                            SendMsg(AD212C.ON_DISPLAY);

                            while (true)
                            {
                                string RxMsg = "";
                                try
                                {
                                    WeighPort.ReadTimeout = 10000;
                                    ReadMsgEOC(ref RxMsg);
                                }
                                catch { }
                                if (RxMsg.StartsWith(AD212C.HEADER_STABLE)) break;
                            }
                            break;
                        }
                    case TEWeight.EWeighType.MT_SICS_VMS:
                        {
                            WeighPort.ReadTimeout = 1000;

                            SendMsg(MT_SICS_VMS.SET_UNIT + " 0 " + "0");
                            string RxMsg = "";
                            ReadMsgEOC(ref RxMsg);
                            RxMsg.StartsWith(MT_SICS_VMS.SET_UNIT);
                            break;
                        }
                }

                Delays(100);
            }
            catch (Exception ex)
            {
                Close();
                throw new Exception("Open Port " + (char)9 + ex.Message.ToString());
            }
        }
        public static void Close()
        {
            try
            {
                switch (TypeWeight)
                {
                    case TEWeight.EWeighType.ALD214:
                    case TEWeight.EWeighType.JB1603:
                    default:
                        {
                            WeighPort.Close();
                            break;
                        }
                    case TEWeight.EWeighType.AD4212C:
                        {
                            if (WeighPort.IsOpen)
                            {
                                SendMsg(AD212C.OFF_DISPLAY);
                            }
                            WeighPort.Close();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Close Port " + (char)9 + ex.Message.ToString());
            }
        }
        public static bool IsOpen
        {
            get
            {
                return WeighPort.IsOpen;
            }
        }

        private static void SendMsg(string Msg)
        {
            string S = "";
            try
            {
                if (WeighPort != null)
                {
                    if (!WeighPort.IsOpen)
                    {
                        Open(PortNo, TypeWeight);
                    }
                }
                S = Msg + (char)13 + (char)10;
                WeighPort.Write(S);
            }
            catch (Exception ex)
            {
                throw new Exception("SendMsg " + Msg + (char)9 + ex.Message.ToString());
            }
        }
        private static void ReadMsg(ref string RMsg)
        {
            try
            {
                if (WeighPort != null)
                {
                    if (!WeighPort.IsOpen)
                    {
                        Open(PortNo, TypeWeight);
                    }
                }
                RMsg = "";
                RMsg = WeighPort.ReadExisting();
            }
            catch (Exception ex)
            {
                throw new Exception("ReadMsg " + (char)9 + ex.Message.ToString());
            }
        }
        private static void ReadMsgEOC(ref string RMsg)
        {
            try
            {
                if (WeighPort != null)
                {
                    if (!WeighPort.IsOpen)
                    {
                        Open(PortNo, TypeWeight);
                    }
                }
            _Reread:
                RMsg = "";
                string EOC = ((char)13).ToString() + ((char)10).ToString();
                RMsg = WeighPort.ReadTo(EOC);

                if (WeighPort.BytesToRead > 0) goto _Reread;
            }
            catch (Exception ex)
            {
                throw new Exception("ReadMsgEOC " + (char)9 + ex.Message.ToString());
            }
        }

        public static void Tare()
        {
            string RXMsg = "";

            try
            {
                switch (TypeWeight)
                {
                    case TEWeight.EWeighType.ALD214:
                        {
                            #region ALD214
                            WeighPort.DiscardInBuffer();
                            SendMsg("T");

                            WeighPort.ReadTimeout = 3000;
                            ReadMsgEOC(ref RXMsg);
                            if (!RXMsg.Contains("OK")) throw new Exception("No Response.");

                            Delays(1000);
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.AD4212C://Tare and Zero same command
                        {
                            #region
                            SendMsg(AD212C.CONT_OUTPUT);
                            SendMsg(AD212C.TARE);

                            while (true)
                            {
                                string RxMsg = "";
                                try
                                {
                                    WeighPort.ReadTimeout = 10000;
                                    ReadMsgEOC(ref RxMsg);
                                }
                                catch { }
                                if (RxMsg.StartsWith(AD212C.HEADER_STABLE)) break;
                            }
                            SendMsg(AD212C.STOP_OUTPUT);
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.JB1603:
                    case TEWeight.EWeighType.MT_SICS_VMS:
                        {
                            #region
                            WeighPort.DiscardInBuffer();
                            SendMsg(MT_SICS_VMS.TARE);
                            WeighPort.ReadTimeout = 10000;

                                ReadMsgEOC(ref RXMsg);

                                if (RXMsg.StartsWith("T S"))
                                {
                                    break;
                                }
                                if (RXMsg.StartsWith("T I"))
                                {
                                    throw new Exception("Balance Busy or TimeOut.");
                                }
                                if (RXMsg.StartsWith("S L"))
                                {
                                    throw new Exception("Incorrect Parameter.");
                                }
                                if (RXMsg.StartsWith("T +"))
                                {
                                    throw new Exception("Balance overload.");
                                }
                                if (RXMsg.StartsWith("T -"))
                                {
                                    throw new Exception("Balance underload.");
                                }
                            break;
                            #endregion
                        }
                    default:
                        throw new Exception("Invalid weight type.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Weighting:Tare:" + ex.Message.ToString());
            }
        }
        public static void Zero()
        {
            string RXMsg = "";

            try
            {
                switch (TypeWeight)
                {
                    case TEWeight.EWeighType.ALD214:
                        {
                            #region ALD214
                            WeighPort.DiscardInBuffer();
                            SendMsg("Z");

                            WeighPort.ReadTimeout = 3000;
                            ReadMsgEOC(ref RXMsg);
                            if (!RXMsg.Contains("OK")) throw new Exception("No Response.");

                            Delays(1000);
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.AD4212C://Tare and Zero same command
                        {
                            #region
                            SendMsg(AD212C.CONT_OUTPUT);
                            SendMsg(AD212C.TARE);

                            while (true)
                            {
                                string RxMsg = "";
                                try
                                {
                                    WeighPort.ReadTimeout = 10000;
                                    ReadMsgEOC(ref RxMsg);
                                }
                                catch { }
                                if (RxMsg.StartsWith(AD212C.HEADER_STABLE)) break;
                            }
                            SendMsg(AD212C.STOP_OUTPUT);
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.JB1603:
                    case TEWeight.EWeighType.MT_SICS_VMS:
                        {
                            #region
                            WeighPort.DiscardInBuffer();
                            SendMsg(MT_SICS_VMS.ZERO);
                            WeighPort.ReadTimeout = 10000;

                            ReadMsgEOC(ref RXMsg);

                            if (RXMsg.StartsWith("Z A"))
                            {
                                break;
                            }
                            if (RXMsg.StartsWith("Z I"))
                            {
                                throw new Exception("Balance Busy or TimeOut.");
                            }
                            if (RXMsg.StartsWith("Z +"))
                            {
                                throw new Exception("Upper limit of zero setting range exceeded.");
                            }
                            if (RXMsg.StartsWith("Z -"))
                            {
                                throw new Exception("Lower limit of zero setting range exceeded.");
                            }
                            break;
                            #endregion
                        }
                    default:
                        throw new Exception("Invalid weight type.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Weight:Zero:" + ex.Message.ToString());
            }
        }
        public static void ReadStable(ref double gValue)
        {
            try
            {
                switch (TypeWeight)
                {
                    case TEWeight.EWeighType.ALD214:
                        {
                            #region ALD214
                            int i_Attempt = 0;
                        _Retry1:
                            i_Attempt++;
                            SendMsg("SP");
                            Delays(100);

                            string RxMsg = "";
                            WeighPort.ReadTimeout = 1000;
                            ReadMsgEOC(ref RxMsg);

                            if ((RxMsg.IndexOf("ES") >= 0) || (RxMsg == ""))
                            {
                                if (i_Attempt >= 3)
                                {
                                    if (RxMsg.IndexOf("ES") >= 0) throw new Exception("Invalid Command.");
                                    else
                                        throw new Exception("No Response.");
                                }
                                goto _Retry1;
                            }
                            else
                            {
                                try
                                {
                                    int y = RxMsg.IndexOf(".");
                                    RxMsg = RxMsg.Remove(y + 5);
                                    int u = RxMsg.LastIndexOf(' ');
                                    string value = RxMsg.Substring(u + 1);
                                    gValue = Convert.ToDouble(value);
                                }
                                catch
                                {
                                    throw;
                                }
                            }
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.AD4212C:
                        {
                            #region
                            SendMsg(AD212C.READ_STABLE);
                            string RxMsg = "";
                            WeighPort.ReadTimeout = 1000;
                            ReadMsgEOC(ref RxMsg);

                            //sample response, 15 ASCII
                            //  1   2   3   4   5   6   7   8   9   10  11  12  13  14  15
                            // "S" "T" "," "+" "0" "0" "1" "2" "." "3" "4" "5" " " " " "g" stable reading
                            // "U" "S" "," "+" "0" "0" "0" "5" "." "3" "4" "5" " " " " "g" unstable reading
                            // "O" "L" "," "+" "9" "9" "9" "9" "9" "9" "9" "E" "+" "1" "g" over load reading (plus side)
                            // "O" "L" "," "-" "9" "9" "9" "9" "9" "9" "9" "E" "+" "1" "g" over load reading (minus side)
                            if (RxMsg.StartsWith(AD212C.HEADER_STABLE))
                            {
                                try
                                {
                                    string value = RxMsg.Substring(4, 9);
                                    gValue = Convert.ToDouble(value);
                                }
                                catch
                                {
                                    throw;
                                }
                            }
                            if (RxMsg.StartsWith(AD212C.HEADER_OVER))
                            {
                                if (RxMsg.Contains("+"))
                                {
                                    throw new Exception("Balance overload.");
                                }
                                if (RxMsg.Contains("-"))
                                {
                                    throw new Exception("Balance underload.");
                                }
                            }
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.JB1603:
                    case TEWeight.EWeighType.MT_SICS_VMS:
                        {
                            #region
                            WeighPort.DiscardInBuffer();
                            SendMsg(MT_SICS_VMS.READ_STABLE);

                            string RxMsg = "";
                            ReadMsgEOC(ref RxMsg);

                            //sample response
                            //"S S      100.00 g"
                            //"S I" -> Cmd not execute
                            //"S L" -> Incorrect Para
                            //"S +" -> Overload
                            //"S -" -> Underload
                            //"S S <ErrorCode>" -> Error Code

                            if (RxMsg.StartsWith("S S"))
                            {
                                if (RxMsg.Contains("Error"))
                                    throw new Exception("Error " + RxMsg + ".");
                                else
                                {
                                    string S = RxMsg.ToUpper();
                                    S = S.Replace("S", "");
                                    S = S.Replace("D", "");
                                    S = S.Replace("G", "");
                                    S = S.Replace(" ", "");

                                    try
                                    {
                                        gValue = Convert.ToDouble(S);
                                    }
                                    catch
                                    {
                                        throw;
                                    }
                                }
                            }
                            if (RxMsg.StartsWith("S I"))
                            {
                                throw new Exception("Balance Busy or TimeOut.");
                            }
                            if (RxMsg.StartsWith("S L"))
                            {
                                throw new Exception("Incorrect Parameter.");
                            }
                            if (RxMsg.StartsWith("S +"))
                            {
                                throw new Exception("Balance overload.");
                            }
                            if (RxMsg.StartsWith("S -"))
                            {
                                throw new Exception("Balance underload.");
                            }
                            break;
                            #endregion
                        }
                    default:
                        throw new Exception("Invalid weight type.");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Weight:ReadStable:" + Ex.Message.ToString());
            }
        }
        public static void ReadImme(ref double gValue)
        {
            try
            {
                switch (TypeWeight)
                {
                    case TEWeight.EWeighType.ALD214:
                        {
                            #region ALD214
                            int i_Attempt = 0;
                        _Retry1:
                            i_Attempt++;
                            SendMsg("IP");
                            Delays(100);

                            string RxMsg = "";
                            WeighPort.ReadTimeout = 1000;
                            ReadMsgEOC(ref RxMsg);

                            if ((RxMsg.IndexOf("ES") >= 0) || (RxMsg == ""))
                            {
                                if (i_Attempt >= 3)
                                {
                                    if (RxMsg.IndexOf("ES") >= 0) throw new Exception("Invalid Command.");
                                    else
                                        throw new Exception("No Response.");
                                }
                                goto _Retry1;
                            }
                            else
                            {
                                try
                                {
                                    int y = RxMsg.IndexOf(".");
                                    RxMsg = RxMsg.Remove(y + 5);
                                    int u = RxMsg.LastIndexOf(' ');
                                    string value = RxMsg.Substring(u + 1);
                                    gValue = Convert.ToDouble(value);
                                }
                                catch
                                {
                                    throw;
                                }
                            }
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.AD4212C:
                        {
                            #region
                            SendMsg(AD212C.READ_IMME);
                            string RxMsg = "";
                            WeighPort.ReadTimeout = 1000;
                            ReadMsgEOC(ref RxMsg);

                            //sample response, 15 ASCII
                            //  1   2   3   4   5   6   7   8   9   10  11  12  13  14  15
                            // "S" "T" "," "+" "0" "0" "1" "2" "." "3" "4" "5" " " " " "g" stable reading
                            // "U" "S" "," "+" "0" "0" "0" "5" "." "3" "4" "5" " " " " "g" unstable reading
                            // "O" "L" "," "+" "9" "9" "9" "9" "9" "9" "9" "E" "+" "1" "g" over load reading (plus side)
                            // "O" "L" "," "-" "9" "9" "9" "9" "9" "9" "9" "E" "+" "1" "g" over load reading (minus side)

                            if (RxMsg.StartsWith(AD212C.HEADER_STABLE) || (RxMsg.StartsWith(AD212C.HEADER_UNSTABLE)))
                            {
                                try
                                {
                                    string value = RxMsg.Substring(4, 9);
                                    gValue = Convert.ToDouble(value);
                                }
                                catch
                                {
                                    throw;
                                }
                            }
                            if (RxMsg.StartsWith(AD212C.HEADER_OVER))
                            {
                                if (RxMsg.Contains("+"))
                                {
                                    throw new Exception("Balance overload.");
                                }
                                if (RxMsg.Contains("-"))
                                {
                                    throw new Exception("Balance underload.");
                                }
                            }
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.JB1603:
                    case TEWeight.EWeighType.MT_SICS_VMS:
                        {
                            #region
                            WeighPort.DiscardInBuffer();
                            SendMsg(MT_SICS_VMS.READ_IMME);

                            string RxMsg = "";
                            ReadMsgEOC(ref RxMsg);

                            //sample response
                            //"S S      100.00 g"
                            //"S I" -> Cmd not execute
                            //"S L" -> Incorrect Para
                            //"S +" -> Overload
                            //"S -" -> Underload
                            //"S S <ErrorCode>" -> Error Code

                            if (RxMsg.StartsWith("S S") || RxMsg.StartsWith("S D"))
                            {
                                if (RxMsg.Contains("Error"))
                                    throw new Exception("Error " + RxMsg + ".");
                                else
                                {
                                    string S = RxMsg.ToUpper();
                                    S = S.Replace("S", "");
                                    S = S.Replace("D", "");
                                    S = S.Replace("G", "");
                                    S = S.Replace(" ", "");

                                    try
                                    {
                                        gValue = Convert.ToDouble(S);
                                    }
                                    catch
                                    {
                                        throw;
                                    }
                                }
                            }
                            if (RxMsg.StartsWith("S I"))
                            {
                                throw new Exception("Balance Busy or TimeOut.");
                            }
                            if (RxMsg.StartsWith("S L"))
                            {
                                throw new Exception("Incorrect Parameter.");
                            }
                            if (RxMsg.StartsWith("S +"))
                            {
                                throw new Exception("Balance overload.");
                            }
                            if (RxMsg.StartsWith("S -"))
                            {
                                throw new Exception("Balance underload.");
                            }
                            break;
                            #endregion
                        }
                    case TEWeight.EWeighType.Simulator:
                        {
                            #region
                            Random rand = new Random();
                            gValue = (double)rand.Next(1000) / 100000;
                            break;
                            #endregion
                        }
                    default:
                        throw new Exception("Invalid weight type.");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Weight:ReadImme:" + Ex.Message.ToString());
            }
        }

        public static void ShowDialog()
        {
            frm_Weighing frm = new frm_Weighing();
            frm.ShowDialog();
        }
    }
}
