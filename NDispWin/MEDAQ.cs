using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CLaser
{
    using MicroEpsilon;

    public partial class MEDAQ
    {
        public static MEDAQLib Sensor = new MEDAQLib(ME_SENSOR.SENSOR_ILD1750);//SENSOR_ILD1320);

        public static ESensorType _SensorType = ESensorType.None;
        private static bool _Connected = false;
        private string _ComPort = "";

        public enum ESensorType
        {
            None,
            ILD1302,// = MEDAQLib.ME_SENSOR.SENSOR_ILD1302,
            ILD1700,// = MEDAQLib.ME_SENSOR.SENSOR_ILD1700,
            IFD2451,// = MEDAQLib.ME_SENSOR.SENSOR_IFD2451,
            OCP8010H,// = Wenglor Laser OCP8010H
            ILD1X20,
            ILD2300,
            IFD2421,// = MEDAQLib.ME_SENSOR.SENSOR_IFD2421,
            ILD1750,// = MEDAQLib.ME_SENSOR.SENSOR_IFD1750,
            IFD2422,// = MEDAQLib.ME_SENSOR.SENSOR_IFD2422,
            ILD1900,// = MEDAQLib.ME_SENSOR.SENSOR_ILD1900,
        }

        public enum EStrParam
        {
            IP_Interface,
            IP_Port,
            IP_RemoteAddr,
            SA_ErrorText,
        }
        public static class IP_INTERFACE
        {
            public const string RS232 = "RS232";
            public const string IF2004 = "IF2004";
            public const string IF2004_USB = "IF2004_USB";
            public const string IF2008 = "IF2008";
            public const string TCPIP = "TCP/IP";
            public const string DRIVERX_USB = "DriverX_USB";
            public const string USBIO = "USBIO";
            public const string WinUSB = "WinUSB";
        }
        public enum EComType
        {
            RS232,
            TCPIP
        }
        public static EComType ComType = EComType.RS232;

        public enum EIntParam
        {
            IP_Baudrate,
            IP_ScaleErrorValues,
            IP_RemotePort,
        }
        public static class IP_BAUDRATE
        {
            public const int B_9600 = 9600;
            public const int B_19200 = 19200;
            public const int B_38400 = 38400;
            public const int B_57600 = 57600;
            public const int B_115200 = 115200;
        }
        public static class IP_SCALE_ERROR_VALUE
        {
            public const int LAST_VALID_VALUE = 1;
            public const int SET_TO_FIX_VALUE = 2;
            public const int SET_TO_NEG_ERR_VALUE = 3;
        }

        public enum EDblParam
        {
            IP_FixedErrorValue,
        }

        public void SetParam(string Param, double Value)
        {
            try
            {
                ERR_CODE ErrCode = Sensor.SetParameterDouble(Param, Value);
                if (ErrCode != ERR_CODE.ERR_NOERROR)
                    throw new Exception("SetParam " + Param + " " + Value.ToString() + (char)9 + GetErrString());
            }
            catch
            {
                throw;
            }
        }
        public void SetParam(EDblParam Param, double Value)
        {
            try
            {
                SetParam(Param.ToString(), Value);
            }
            catch
            {
                throw;
            }
        }
        public void SetParam(string Param, int Value)
        {
            try
            {
                ERR_CODE ErrCode = Sensor.SetParameterInt(Param.ToString(), Value);
                if (ErrCode != ERR_CODE.ERR_NOERROR)
                    throw new Exception("SetParam " + Param + " " + Value.ToString() + (char)9 + GetErrString());
            }
            catch
            {
                throw;
            }
        }
        public void SetParam(EIntParam Param, int Value)
        {
            try
            {
                SetParam(Param.ToString(), Value);
            }
            catch
            {
                throw;
            }
        }
        public void SetParam(string Param, string Value)
        {
            try
            {
                ERR_CODE ErrCode = Sensor.SetParameterString(Param, Value);
                if (ErrCode != ERR_CODE.ERR_NOERROR)
                    throw new Exception("SetParam " + Param + " " + Value.ToString() + (char)9 + GetErrString());
            }
            catch
            {
                throw;
            }
        }
        public void SetParam(EStrParam Param, string Value)
        {
            try
            {
                SetParam(Param.ToString(), Value);
            }
            catch
            {
                throw;
            }
        }

        public void GetParam(string Param, ref string Value)
        {
            try
            {
                string value = "";
                ERR_CODE ErrCode = Sensor.GetParameterString(Param, ref value);
                if (ErrCode != ERR_CODE.ERR_NOERROR)
                    throw new Exception("GetParam " + Param + " " + (char)9 + GetErrString());
            }
            catch
            {
                throw;
            }
        }
        public void GetParam(EStrParam Param, ref string Value)
        {
            try
            {
                GetParam(Param.ToString(), ref Value);
            }
            catch
            {
                throw;
            }
        }

        public string GetErrString()
        {
            string s = "";
            Sensor.GetError(ref s);
            return s;
        }

        public void Open(ESensorType SensorType, string ComPort_Address)
        {
            try
            {
                _ComPort = ComPort_Address;
                _Connected = false;
                Sensor.CloseSensor();

                switch (SensorType)
                {
                    //case ESensorType.ILD1700: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_ILD1700); break;
                    //case ESensorType.ILD1302: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_ILD1302); break;
                    case ESensorType.IFD2451: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_IFD2451); break;
                    case ESensorType.ILD1X20: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_ILD1320); break;
                    case ESensorType.ILD2300: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_ILD2300); break;
                    case ESensorType.IFD2421: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_IFD2421); break;
                    case ESensorType.ILD1750: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_ILD1750); break;
                    case ESensorType.IFD2422: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_IFD2422); break;
                    case ESensorType.ILD1900: Sensor = new MEDAQLib(ME_SENSOR.SENSOR_ILD1900); break;
                }

                _SensorType = SensorType;

                ERR_CODE Err = new ERR_CODE();

                if (ComPort_Address.Contains("COM"))
                {
                    int baudRate = 115200;
                    if (SensorType == ESensorType.ILD1900) baudRate = 921600;

                            Err = Sensor.SetParameterInt("IP_Baudrate", baudRate);
                    if (Err != ERR_CODE.ERR_NOERROR)
                        throw new Exception("Open - Set Baud" + (char)9 + GetErrString());

                    Err = Sensor.OpenSensorRS232(ComPort_Address);
                    if (Err != ERR_CODE.ERR_NOERROR)
                        throw new Exception("Open" + (char)9 + GetErrString());
                    _Connected = true;
                }
                else
                    if (ComPort_Address.Contains("."))
                {
                    Err = Sensor.OpenSensorTCPIP(ComPort_Address);
                    if (Err != ERR_CODE.ERR_NOERROR)
                        throw new Exception("Open" + (char)9 + GetErrString());
                    _Connected = true;
                }
                else
                {
                    try
                    {
                        Sensor.CloseSensor();
                    }
                    catch { }
                    throw new Exception("Invalid Comport or IP Address");
                }
            }
            catch
            {
                throw;
            }
        }
        public void Close()
        {
            try
            {
                Sensor.CloseSensor();

                _SensorType = ESensorType.None;
                _Connected = false;
            }
            catch
            {
                throw;
            }
        }

        private static double dZero = 0;

        /// <summary>
        /// Poll data from the sensor.
        /// </summary>
        /// <param name="RawData">ADC Data</param>
        /// <param name="ScaledAbs">Scaled Data</param>
        /// <param name="ScaledAbsInv">Inverted Scaled Data</param>
        /// <param name="ScaledRel">Scaled Data Offset from Zero</param>
        /// <param name="ScaledRelInv">Inverted Scaled Data Offset from Zero</param>
        /// <returns>In Range</returns>
        public bool Poll(ref double RawData, ref double ScaledAbs, ref double ScaledAbsInv, ref double ScaledRel, ref double ScaledRelInv)
        {
            int[] iRawData = new int[2];
            double[] dScaledData = new double[2];
            try
            {
                ERR_CODE ErrCode = Sensor.Poll(iRawData, dScaledData, 1);
                if (ErrCode != ERR_CODE.ERR_NOERROR)
                    throw new Exception("Poll" + (char)9 + GetErrString());

                RawData = iRawData[0];
                ScaledAbs = Math.Max(dScaledData[0], -999.0);

                ScaledAbsInv = 0 - ScaledAbs;
                ScaledRel = dZero - ScaledAbs;
                ScaledRelInv = dZero - ScaledRel;

                if (ScaledAbs == -999) return false;
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool Poll([MarshalAs(UnmanagedType.LPArray)] ref int[] RawData,
                         ref double CH1ScaledAbs, ref double CH1ScaledAbsInv, ref double CH1ScaledRel, ref double CH1ScaledRelInv,
                         ref double CH2ScaledAbs, ref double CH2ScaledAbsInv, ref double CH2ScaledRel, ref double CH2ScaledRelInv)
        {
            int[] iRawData = new int[3];
            double[] dScaledData = new double[3];
            try
            {   
                //MEDAQLib.ERR_CODE ErrCode = MEDAQLib.Poll(pSensor, RawData, dScaledData, 3);
                ERR_CODE ErrCode = Sensor.Poll(iRawData, dScaledData, 3);
                if (ErrCode != ERR_CODE.ERR_NOERROR)
                {
                    throw new Exception("Poll" + (char)9 + GetErrString());
                }
                CH1ScaledAbs = Math.Max(dScaledData[0], -999.0);
                CH2ScaledAbs = Math.Max(dScaledData[1], -999.0);

                CH1ScaledAbsInv = 0 - CH1ScaledAbs;
                CH1ScaledRel = dZero - CH1ScaledAbs;
                CH1ScaledRelInv = dZero - CH1ScaledRel;

                CH2ScaledAbsInv = 0 - CH2ScaledAbs;
                CH2ScaledRel = dZero - CH2ScaledAbs;
                CH2ScaledRelInv = dZero - CH2ScaledRel;

                //if (CH1ScaledAbs == -999 || CH2ScaledAbs == -999) return false;
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Poll_ScaledAbs(ref double Value)
        {
            try
            {
                double d1 = 0;
                double d2 = 0;
                double d3 = 0;
                double d4 = 0;
                return Poll(ref d1, ref Value, ref d2, ref d3, ref d4);
            }
            catch
            {
                throw;
            }
        }
        public bool Poll_ScaledAbsInv(ref double Value)
        {
            try
            {
                double d1 = 0;
                double d2 = 0;
                double d3 = 0;
                double d4 = 0;
                return Poll(ref d1, ref d2, ref Value, ref d3, ref d4);
            }
            catch
            {
                throw;
            }
        }
        public bool Poll_ScaledRel(ref double Value)
        {
            try
            {
                double d1 = 0;
                double d2 = 0;
                double d3 = 0;
                double d4 = 0;
                return Poll(ref d1, ref d2, ref d3, ref Value, ref d4);
            }
            catch
            {
                throw;
            }
        }
        public bool Poll_ScaledRelInv(ref double Value)
        {
            try
            {
                double d1 = 0;
                double d2 = 0;
                double d3 = 0;
                double d4 = 0;
                return Poll(ref d1, ref d2, ref d3, ref d4, ref Value);
            }
            catch
            {
                throw;
            }
        }

        public bool Poll_ScaledRel(ref double CH1Value, ref double CH2Value)
        {
            try
            {
                int[] Raw = new int[2];
                double CH1d1 = 0;
                double CH1d2 = 0;
                double CH1d3 = 0;
                double CH2d1 = 0;
                double CH2d2 = 0;
                double CH2d3 = 0;


                return Poll(ref Raw,
                            ref CH1d1, ref CH1d2, ref CH1Value, ref CH1d3,
                            ref CH2d1, ref CH2d2, ref CH2Value, ref CH2d3);
            }
            catch
            {
                throw;
            }
        }

        public bool DataAvail(ref int DataAvail)
        {
            int DataC = 0;

            try
            {
                ERR_CODE ErrCode = Sensor.DataAvail(ref DataC);
                if (ErrCode == ERR_CODE.ERR_NO_SENSORDATA_AVAILABLE)
                {
                    DataC = 0;
                    return true;
                }

                if (ErrCode != ERR_CODE.ERR_NOERROR)
                    throw new Exception("DataAvail" + (char)9 + GetErrString());

                DataAvail = DataC;

                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool ClearBuffer()
        {
            try
            {
                SCmdSetParam("Clear_Buffers", "SP_AllDevices", 1);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool TransferData(int[] RawData, double[] ScaledAbs, double[] ScaledAbsInv, ref int DataCount)
        {
            int MaxData = RawData.Length;
            try
            {
                ERR_CODE ErrCode = Sensor.TransferData(RawData, ScaledAbs, MaxData, ref DataCount);
                if (ErrCode != ERR_CODE.ERR_NOERROR)
                {
                    throw new Exception("TransferData" + (char)9 + GetErrString());
                }

                for (int i = 0; i < ScaledAbs.Length; i++)
                {
                    ScaledAbs[i] = Math.Max(ScaledAbs[i], -999.0);
                    ScaledAbsInv[i] = 0 - ScaledAbs[i];
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool TransferData(int[] RawData,
                                 double[] ScaledAbs, double[] ScaledAbsInv, double[] ScaledRel, double[] ScaledRelInv,
                                 ref int DataCount)
        {
            int MaxData = RawData.Length;

            try
            {
                ERR_CODE ErrCode = Sensor.TransferData(RawData, ScaledAbs, MaxData, ref DataCount);
                if (ErrCode != ERR_CODE.ERR_NOERROR)
                {
                    throw new Exception("TransferData" + (char)9 + GetErrString());
                }

                for (int i = 0; i < ScaledAbs.Length; i++)
                {
                    ScaledAbs[i] = Math.Max(ScaledAbs[i], -999.0);

                    ScaledAbsInv[i] = 0 - ScaledAbs[i];
                    ScaledRel[i] = dZero - ScaledAbs[i];
                    ScaledRelInv[i] = dZero - ScaledRel[i];
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        public void SetZero()
        {
            try
            {
                double d = 0;
                Poll(ref d, ref dZero, ref d, ref d, ref d);
            }
            catch
            {
                throw;
            }
        }
        public void ResetZero()
        {
            dZero = 0;
        }
        public double Zero
        {
            get { return dZero; }
            set { dZero = value; }
        }

        public string GetSensorName()
        {
            try
            {
                switch (_SensorType)
                {
                    case ESensorType.ILD1302:
                        return ILD1302.GetSensorName();
                    case ESensorType.ILD1X20:
                        return ILD1320.GetSensorName();
                    case ESensorType.ILD1700:
                        return ILD1700.GetSensorName();
                    case ESensorType.IFD2451:
                        return IFD2451.GetSensorName();
                    case ESensorType.ILD1750:
                        return ILD1750.GetSensorName();
                    case ESensorType.IFD2421:
                    case ESensorType.IFD2422:
                        try
                        {
                            string value = "";
                            SCmdGetParam("Get_Info", "SA_Sensor", ref value);
                            return value;
                        }
                        catch
                        {
                            throw;
                        }
                }
                throw new Exception("Invalid sensor type.");
            }
            catch { throw; }
        }
        public string GetSerialNumber()
        {
            try
            {
                switch (_SensorType)
                {
                    case ESensorType.ILD1302:
                        return ILD1302.GetSerialNumber();
                    case ESensorType.ILD1X20:
                        return ILD1320.GetSerialNumber();
                    case ESensorType.ILD1700:
                        return ILD1700.GetSerialNumber();
                    case ESensorType.IFD2451:
                        return IFD2451.GetSerialNumber();
                    case ESensorType.ILD1750:
                        return ILD1750.GetSerialNumber();
                    case ESensorType.IFD2421:
                    case ESensorType.IFD2422:
                        try
                        {
                            string value = "";
                            SCmdGetParam("Get_Info", "SA_SerialNumber", ref value);
                            return value;
                        }
                        catch
                        {
                            throw;
                        }
                }
                throw new Exception("Invalid sensor type.");
            }
            catch { throw; }
        }

        public void CtrlDlg()
        {
            //switch (_SensorType)
            //{
            //    case ESensorType.ILD1302:
            //        frm_ILD1302 frmILD1302 = new frm_ILD1302();

            //        frmILD1302.SensorType = ESensorType.ILD1302;
            //        frmILD1302.Sensor = this;
            //        frmILD1302.Show();
            //        break;
            //    case ESensorType.ILD1X20:
            //        frm_ILD1302 frmILD1X20 = new frm_ILD1302();

            //        frmILD1X20.SensorType = ESensorType.ILD1X20;
            //        frmILD1X20.Sensor = this;
            //        frmILD1X20.Show();
            //        break;
            //    case ESensorType.ILD1700:
            //        frm_ILD1700 frmILD1700 = new frm_ILD1700();

            //        frmILD1700.Sensor = this;
            //        frmILD1700.Show();
            //        break;
            //    case ESensorType.ILD1750:
            //        frm_ILD1750 frmILD1750 = new frm_ILD1750();

            //        frmILD1750.Sensor = this;
            //        frmILD1750.Show();
            //        break;
            //    case ESensorType.IFD2451:
            //    case ESensorType.IFD2421:
            //    case ESensorType.IFD2422:
            //        frm_IFD2451 frmIFD2451 = new frm_IFD2451();

            //        frmIFD2451.Sensor = this;
            //        frmIFD2451.Show();
            //        break;
            //}
        }

        public bool IsConnected
        {
            get { return _Connected; }
        }
        public string ComPort
        {
            get { return _ComPort; }
        }

        #region Sensor Command
        private static void SCmd(string SensorCommand)
        {
            try
            {
                Sensor.ExecSCmd(SensorCommand);
            }
            catch
            {
                throw;
            }
        }

        private static void SCmdGetParam(string SensorCommand, string Param, ref string Value)
        {
            try
            {
                Sensor.ExecSCmdGetString(SensorCommand, Param, ref Value);
            }
            catch
            {
                throw;
            }
        }
        private static void SCmdSetParam(string SensorCommand, string Param, string Value)
        {
            try
            {
                Sensor.SetStringExecSCmd(SensorCommand, Param, Value);
            }
            catch
            {
                throw;
            }
        }

        private static void SCmdSetParam(string SensorCommand, string Param, int Value)
        {
            try
            {
                //Sensor.SetParameters
                Sensor.SetIntExecSCmd(SensorCommand, Param, Value);
            }
            catch
            {
                throw;
            }
        }
        private static void SCmdGetParam(string SensorCommand, string Param, ref int Value)
        {
            try
            {
                Sensor.ExecSCmdGetInt(SensorCommand, Param, ref Value);
            }
            catch
            {
                throw;
            }
        }

        private static void SCmdSetParam(string SensorCommand, string Param, double Value)
        {
            try
            {
                Sensor.SetDoubleExecSCmd(SensorCommand, Param, Value);
            }
            catch
            {
                throw;
            }
        }
        private static void SCmdGetParam(string SensorCommand, string Param, ref double Value)
        {
            try
            {
                Sensor.ExecSCmdGetDouble(SensorCommand, Param, ref Value);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        public _ILD1302 ILD1302 = new _ILD1302();
        public class _ILD1302
        {
            public string GetSensorName()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_Sensor", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public string GetSerialNumber()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_SerialNumber", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public double GetRange()
            {
                try
                {
                    double value = 0;
                    SCmdGetParam("Get_Info", "SA_Range", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }

            public bool LaserOn
            {
                set
                {
                    try
                    {
                        if (value)
                            SCmd("Laser_On");
                        else
                            SCmd("Laser_Off");
                    }
                    catch { throw; }
                }
            }
            public bool DataOutput
            {
                set
                {
                    try
                    {
                        if (value)
                            SCmd("Dat_Out_On");
                        else
                            SCmd("Dat_Out_Off");
                    }
                    catch { throw; }
                }
                get
                {
                    try
                    {
                        int i = 0;
                        SCmdGetParam("Get_Settings", "SA_DatOut", ref i);
                        return (i == 1);
                    }
                    catch { throw; }
                }
            }

            public _Meas Meas = new _Meas();
            public class _Meas
            {
                public double RateVal
                {
                    //Measurement rate is fix 750Hz
                    get
                    {
                        return 750;
                    }
                }
            }
        }

        public enum E_ILD1X20_Rate { Speed250Hz, Speed500Hz, Speed1kHz, Speed2kHz, Speed4kHz };
        public enum E_ILD1X20_TrigMode { None = 0, Edge = 1, Level = 2, Software = 3 };
        public enum E_ILD1X20_OutIntf { None = 0, RS422 = 1, Analog = 6};
        public _ILD1X20 ILD1320 = new _ILD1X20();
        public class _ILD1X20
        {
            public string GetSensorName()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_Sensor", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public string GetSerialNumber()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_SerialNumber", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public double GetRange()
            {
                try
                {
                    double value = 0;
                    SCmdGetParam("Get_Info", "SA_Range", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }

            public bool LaserOn
            {
                set
                {
                    try
                    {
                        if (value)
                            SCmdSetParam("Set_LaserPower", "SP_LaserPower", 0);
                        else
                            SCmdSetParam("Set_LaserPower", "SP_LaserPower", 1);
                    }
                    catch { throw; }
                }
                get
                {
                    try
                    {
                        int value = 0;
                        SCmdGetParam("Get_LaserPower", "SA_LaserPower", ref value);
                        return (value == 0);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            public E_ILD1X20_OutIntf OutIntf
            {
                set
                {
                    try
                    {
                        int d = 0;
                        switch (value)
                        {
                            case E_ILD1X20_OutIntf.None:
                                d = 0;
                                break;
                            case E_ILD1X20_OutIntf.RS422:
                                d = 1;
                                break;
                            case E_ILD1X20_OutIntf.Analog:
                                d = 6;
                                break;
                        }
                        SCmdSetParam("Set_DataOutInterface", "SP_DataOutInterface", d);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
           
            public _Meas Meas = new _Meas();
            public class _Meas
            {
                public E_ILD1X20_Rate Rate
                {
                    set
                    {
                        try
                        {
                            double d = 2.0;
                            switch (value)
                            {
                                case E_ILD1X20_Rate.Speed250Hz:
                                    d = 0.25;
                                    break;
                                case E_ILD1X20_Rate.Speed500Hz:
                                    d = 0.5;
                                    break;
                                case E_ILD1X20_Rate.Speed1kHz:
                                    d = 1.0;
                                    break;
                                case E_ILD1X20_Rate.Speed2kHz:
                                default:
                                    d = 2.0;
                                    break;
                                case E_ILD1X20_Rate.Speed4kHz:
                                    d = 24.0;
                                    break;
                            }
                            SCmdSetParam("Get_Samplerate", "SP_Measrate", d);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            double d = 0;
                            SCmdGetParam("Set_Samplerate", "SA_Measrate", ref d);

                            if (d == 4.0) return E_ILD1X20_Rate.Speed4kHz;
                            else
                                if (d == 2.0) return E_ILD1X20_Rate.Speed2kHz;
                                else
                                    if (d == 1.0) return E_ILD1X20_Rate.Speed1kHz;
                                    else
                                        if (d == 0.5) return E_ILD1X20_Rate.Speed500Hz;
                                        else 
                                            return E_ILD1X20_Rate.Speed250Hz;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public double RateVal
                {
                    set
                    {
                        List<double> list = new List<double> { 250, 500, 1000, 2000, 4000 };

                        // find closest to number
                        double Closest = list.OrderBy(item => Math.Abs(value - item)).First();

                        double d = 0.25;
                        if (Closest == 250) { d = 0.25;}
                        if (Closest == 500) { d = 0.5; }
                        if (Closest == 1000) { d = 1.0; }
                        if (Closest == 2000) { d = 2.0; }
                        if (Closest == 4000) { d = 4.0; }

                        try
                        {
                            SCmdSetParam("Set_Samplerate", "SP_Measrate", d);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            double d = 0;
                            SCmdGetParam("Get_Samplerate", "SA_Measrate", ref d);
                            return d * 1000;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }

            public _Trig Trig = new _Trig();
            public class _Trig
            {
                public E_ILD1X20_TrigMode Mode
                {
                    set
                    {
                        try
                        {
                            SCmdSetParam("Set_TriggerMode", "SP_TriggerMode", (int)value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            int i = 0;
                            SCmdGetParam("Get_TriggerMode", "SA_TriggerMode", ref i);
                            return (E_ILD1X20_TrigMode)i;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public int Count
                {
                    set
                    {
                        if (value >= 16383)
                            throw new Exception("Invalid Trigger Count.");

                        try
                        {
                            if (value == -1)
                            {
                                SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", 16383);
                            }
                            else
                                SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", (int)value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            int i = 0;
                            SCmdGetParam("Get_TriggerCount", "SA_TriggerCount", ref i);
                            return i;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public void SwTrig()
                {
                    try
                    {
                        SCmd("Software_Trigger");
                    }
                    catch
                    {
                        throw;
                    }
                }
                public void StopMeas()
                {
                    try
                    {
                        //Count = 0;
                        SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", 0);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        public enum E_ILD1700_Rate { Speed2500Hz, Speed1250Hz, Speed625Hz, Speed312P5Hz };
        public _ILD1700 ILD1700 = new _ILD1700();
        public class _ILD1700
        {
            public string GetSensorName()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_Sensor", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public string GetSerialNumber()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_SerialNumber", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public double GetRange()
            {
                try
                {
                    double value = 0;
                    SCmdGetParam("Get_Info", "SA_Range", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }

            public bool LaserOn
            {
                set
                {
                    try
                    {
                        if (value)
                            SCmd("Laser_On");
                        else
                            SCmd("Laser_Off");
                    }
                    catch { throw; }
                }
                get
                {
                    try
                    {
                        int value = 0;
                        SCmdGetParam("Get_Settings", "SA_LaserState", ref value);
                        return (value == 1);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            public bool DataOutput
            {
                set
                {
                    try
                    {
                        if (value)
                            SCmd("Dat_Out_On");
                        else
                            SCmd("Dat_Out_Off");
                    }
                    catch { throw; }
                }
                get
                {
                    try
                    {
                        int i = 0;
                        SCmdGetParam("Get_Settings", "SA_DatOut", ref i);
                        return (i == 1);
                    }
                    catch { throw; }
                }
            }

            public _Meas Meas = new _Meas();
            public class _Meas
            {
                public E_ILD1700_Rate Rate
                {
                    set
                    {
                        try
                        {
                            SCmdSetParam("Set_Speed", "SP_Speed", (int)value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            int d = 0;
                            SCmdGetParam("Get_Setings", "SA_Speed", ref d);
                            return (E_ILD1700_Rate)d;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public double RateVal
                {
                    set
                    {
                        List<double> list = new List<double> { 312.5, 625, 1250, 2500 };

                        // find closest to number
                        double Closest = list.OrderBy(item => Math.Abs(value - item)).First();

                        E_ILD1700_Rate Speed = 0;
                        if (Closest == 312.5) { Speed = E_ILD1700_Rate.Speed312P5Hz; return; }
                        if (Closest == 625) { Speed = E_ILD1700_Rate.Speed625Hz; return; }
                        if (Closest == 1250) { Speed = E_ILD1700_Rate.Speed1250Hz; return; }
                        if (Closest == 2500) { Speed = E_ILD1700_Rate.Speed2500Hz; return; }

                        try
                        {
                            SCmdSetParam("Set_Speed", "SP_Speed", (int)Speed);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        int Speed = 0;
                        try
                        {
                            SCmdGetParam("Set_Speed", "SP_Speed", ref Speed);

                            switch (Speed)
                            {
                                default:
                                case 0: return 2500;
                                case 1: return 1250;
                                case 2: return 625;
                                case 3: return 312.5;
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        public enum E_ILD1750_TrigMode { None = 0, Edge = 1, Level = 2, Software = 3 };
        public _ILD1750 ILD1750 = new _ILD1750();
        public class _ILD1750
        {
            public string GetSensorName()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_Sensor", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public string GetSerialNumber()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_SerialNumber", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public double GetRange()
            {
                try
                {
                    double value = 0;
                    SCmdGetParam("Get_Info", "SA_Range", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }

            public bool LaserOn
            {
                set
                {
                    try
                    {
                        if (value)
                            SCmdSetParam("Set_LaserPower", "SP_LaserPower", 0);
                        else
                            SCmdSetParam("Set_LaserPower", "SP_LaserPower", 1);
                    }
                    catch { throw; }
                }
                get
                {
                    try
                    {
                        int value = 0;
                        SCmdGetParam("Get_LaserPower", "SA_LaserPower", ref value);
                        return (value == 0);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            public bool DataOutputRS422
            {
                set
                {
                    try
                    {
                        SCmdSetParam("Set_DataOutInterface", "SP_OutputRS422", 1);// value? 1:0 );
                        //SCmdSetParam("Set_DataOutInterface", "SP_OutputAnalog", 0);// value? 1:0 );
                        //SCmdSetParam("Set_Output_RS422", "SP_OutputDistance1_RS422", 1);
                        //SCmdSetParam("Set_Output_RS422", "SP_OutputAdditionalShutterTime_RS422", 1);
                        
                    }
                    catch
                    {
                        throw;
                    }
                }
                get
                {
                    try
                    {
                        int value = 0;
                        //SCmdGetParam("Get_DataOutInterface", "SA_OutputRS422", ref value);
                        SCmdGetParam("Get_DataOutInterface", "SA_OutputRS422", ref value);
                        //"Get_OutputInfo_RS422", "SA_OutputDistance1_RS422", ref value);
                        return (value == 1);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            public bool DataOutputAnalog
            {
                set
                {
                    try
                    {
                        SCmdSetParam("Set_DataOutInterface", "SP_OutputAnalog", value? 1:0 );
                    }
                    catch
                    {
                        throw;
                    }
                }
                get
                {
                    try
                    {
                        int value = 0;
                        SCmdGetParam("Get_DataOutInterface", "SA_OutputAnalog", ref value);
                        return (value == 1);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            public _Meas Meas = new _Meas();
            public class _Meas
            {
                public double Rate//0.3~7.5kHz
                {
                    set
                    {
                        try
                        {
                            if (value < 0.3) value = 0.3;
                            if (value > 7.5) value = 7.5;
                            SCmdSetParam("Get_Samplerate", "SP_Measrate", value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            double d = 0;
                            SCmdGetParam("Set_Samplerate", "SA_Measrate", ref d);
                            return d;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public double RateVal
                {
                    set
                    {
                        Rate = value;
                    }
                    get
                    {
                        return Rate;
                    }
                }
            }

            public _Trig Trig = new _Trig();
            public class _Trig
            {
                static class Mode
                {
                    public static bool Edge
                    {
                        set
                        {
                            SCmdSetParam("Set_TriggerMode", "SP_TriggerMode", 0);
                        }
                        get
                        {
                            int i = 0;
                            SCmdGetParam("Get_TriggerMode", "SA_TriggerMode", ref i);
                            return (i == 0);
                        }
                    }
                    public static bool Pulse
                    {
                        set
                        {
                            SCmdSetParam("Set_TriggerMode", "SP_TriggerMode", 1);
                        }
                        get
                        {
                            int i = 0;
                            SCmdGetParam("Get_TriggerMode", "SA_TriggerMode", ref i);
                            return (i == 1);
                        }
                    }
                    public static bool Software
                    {
                        set
                        {
                            SCmdSetParam("Set_TriggerSource", "SP_TriggerSource", 3);
                        }
                        get
                        {
                            int i = 0;
                            SCmdGetParam("Get_TriggerSource", "SA_TriggerSource", ref i);
                            return (i == 3);
                        }
                    }
                }

                public int Count
                {
                    set
                    {
                        if (value >= 16383) value = 16383;

                        if (value == -1)
                        {
                            SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", 16383);
                        }
                        else
                            SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", (int)value);
                    }
                    get
                    {
                        int i = 0;
                        SCmdGetParam("Get_TriggerCount", "SA_TriggerCount", ref i);
                        return i;
                    }
                }
                public void SwTrig()
                {
                    SCmdSetParam("Set_SoftwareTrigger", "SP_SoftwareTriggerMode", 1);// value ? 1 : 0);
                                                                                     //int i = 0;
                                                                                     //SCmdGetParam("Get_SoftwareTrigger", "SP_SoftwareTriggerMode", ref i);
                                                                                     //return (i == 1);
                }
            }
            public void StopMeas()
                {
                    try
                    {
                        //Count = 0;
                        SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", 0);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

        public enum E_IFD2451_ShutterMode
        {
            Unknown = -1,
            Auto = 0,
            FixSampleAutoShutter = 1,
            FixSampleFixShutter = 2,
            FixShutterAlternate = 3,
            FixShuttetAuto = 4,
        }
        public enum E_IFD2451_SampleRate
        {
            Rate100Hz = 0,
            Rate200Hz = 1,
            Rate300Hz = 2,
            Rate1000Hz = 3,
            Rate2500Hz = 4,
            Rate5000Hz = 5,
            Rate10000Hz = 6,
            //RateUnknown = 7,
        }
        public enum E_IFD2451_TrigMode
        {
            None = 0,
            Edge = 1,
            Level = 2,
            Software = 3,
            Encoder = 4,
        }
        public enum E_IFD2451_MeasureMode
        {
            Distance = 0,
            Thickness = 1,
            Video = 2,
            MultiLayer = 3,
            VideoStream = 4,
        }

        public _IFD2451 IFD2451 = new _IFD2451();
        public class _IFD2451
        {
            public string GetSensorName()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_Sensor", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public string GetSerialNumber()
            {
                try
                {
                    string value = "";
                    SCmdGetParam("Get_Info", "SA_SerialNumber", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            public double GetRange()
            {
                try
                {
                    double value = 0;
                    SCmdGetParam("Get_SensorInfo", "SA_Range", ref value);
                    return value;
                }
                catch
                {
                    throw;
                }
            }
            //public int GetMeasureMode()
            //{
            //  try
            //  {
            //    int value = 0;
            //    SCmdGetParam("Get_MeasureMode", "SA_MeasureMode", ref value);
            //    return value;
            //  }
            //  catch
            //  {
            //    throw;
            //  }
            //}
            //public bool SetMeasureMode(int value)
            //{
            //  try
            //  {
            //    SCmdSetParam("Set_MeasureMode", "SP_MeasureMode", value);
            //  }
            //  catch
            //  {
            //    throw;
            //  }
            //  return true;
            //}

            public _Meas Meas = new _Meas();
            public class _Meas
            {
                public E_IFD2451_MeasureMode MeasureMode
                {
                    set
                    {
                        int MMode = 0;
                        switch (value)
                        {
                            case E_IFD2451_MeasureMode.Distance: MMode = 0; break;
                            case E_IFD2451_MeasureMode.Thickness: MMode = 1; break;
                            case E_IFD2451_MeasureMode.Video: MMode = 2; break;
                            case E_IFD2451_MeasureMode.MultiLayer: MMode = 3; break;
                            case E_IFD2451_MeasureMode.VideoStream: MMode = 4; break;
                        }

                        try
                        {
                            SCmdSetParam("Set_MeasureMode", "SP_MeasureMode", MMode);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            int d = 0;
                            SCmdGetParam("Get_MeasureMode", "SA_MeasureMode", ref d);

                            if (d == 0) return E_IFD2451_MeasureMode.Distance;
                            if (d == 1) return E_IFD2451_MeasureMode.Thickness;
                            if (d == 2) return E_IFD2451_MeasureMode.Video;
                            if (d == 3) return E_IFD2451_MeasureMode.MultiLayer;
                            if (d == 4) return E_IFD2451_MeasureMode.VideoStream;

                            throw new Exception("Get_MeasureMode Invalid Value.");
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public E_IFD2451_ShutterMode ShutterMode
                {
                    set
                    {
                        try
                        {
                            SCmdSetParam("Set_ShutterMode", "SP_ShutterMode", (int)value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            int i = 0;
                            SCmdGetParam("Get_ShutterMode", "SA_ShutterMode", ref i);
                            return (E_IFD2451_ShutterMode)i;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public E_IFD2451_SampleRate SampleRate
                {
                    set
                    {
                        double Rate = 0;
                        switch (value)
                        {
                            case E_IFD2451_SampleRate.Rate100Hz: Rate = 0.1; break;
                            case E_IFD2451_SampleRate.Rate200Hz: Rate = 0.2; break;
                            case E_IFD2451_SampleRate.Rate300Hz: Rate = 0.3; break;
                            default:
                            case E_IFD2451_SampleRate.Rate1000Hz: Rate = 1.0; break;
                            case E_IFD2451_SampleRate.Rate2500Hz: Rate = 2.5; break;
                            case E_IFD2451_SampleRate.Rate5000Hz: Rate = 5.0; break;
                            case E_IFD2451_SampleRate.Rate10000Hz: Rate = 10.0; break;
                        }

                        try
                        {
                            SCmdSetParam("Set_Samplerate", "SP_Measrate", Rate);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            double d = 0;
                            SCmdGetParam("Get_Samplerate", "SA_Measrate", ref d);

                            if (d == 0.1) return E_IFD2451_SampleRate.Rate100Hz;
                            if (d == 0.2) return E_IFD2451_SampleRate.Rate200Hz;
                            if (d == 0.3) return E_IFD2451_SampleRate.Rate300Hz;
                            if (d == 1.0) return E_IFD2451_SampleRate.Rate1000Hz;
                            if (d == 2.5) return E_IFD2451_SampleRate.Rate2500Hz;
                            if (d == 5.0) return E_IFD2451_SampleRate.Rate5000Hz;
                            if (d == 10.0) return E_IFD2451_SampleRate.Rate10000Hz;

                            throw new Exception("Get_SampleRate Invalid Value.");
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public int GetMaterialTableNumber
                {
                    get
                    {
                        try
                        {
                            int i = 0;
                            SCmdGetParam("Get_MaterialTable", "SA_MaterialTableCount", ref i);
                            return i;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public string ActiveMaterial
                {
                    set
                    {
                        try
                        {
                            SCmdSetParam("Set_ActiveMaterial", "SP_ActiveMaterial", value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            string s = "";
                            SCmdGetParam("Get_ActiveMaterial", "SA_ActiveMaterial", ref s);
                            return s;
                        }
                        catch
                        {
                            throw;
                        }
                    }

                }
                public List<string> GetMaterialTableName(int N)
                {
                    List<string> SD = new List<string>();
                    try
                    {
                        for (int C = 1; C <= N; C++)
                        {
                            string S = "";

                            SCmdGetParam("Get_MaterialTable", "SA_MaterialName" + C.ToString(), ref S);
                            SD.Add(S);
                        }

                    }
                    catch
                    {
                        throw;
                    }
                    return SD;
                }

                public double SampleRateVal
                {
                    set
                    {


                        List<double> list = new List<double> { 0.1, 0.2, 0.3, 1.0, 2.5, 5.0 };

                        // find closest to number
                        double Closest = list.OrderBy(item => Math.Abs(value - item)).First();

                        try
                        {
                            SCmdSetParam("Set_Samplerate", "SP_Measrate", Closest);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            double d = 0;
                            SCmdGetParam("Get_Samplerate", "SA_Measrate", ref d);
                            return d;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public double ShutterTime
                {
                    set
                    {
                        if (value < 0.075)
                            throw new Exception("ShutterTime less than minimum.");
                        if (value > 10000)
                            throw new Exception("ShutterTime more than maximun.");

                        try
                        {
                            SCmdSetParam("Set_ShutterTime", "SP_ShutterTime1", value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            double d = 0;
                            SCmdGetParam("Get_ShutterTime", "SA_ShutterTime1", ref d);
                            return d;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public double ShutterTime2
                {
                    set
                    {
                        if (value < 0.075)
                            throw new Exception("ShutterTime less than minimum.");
                        if (value > 10000)
                            throw new Exception("ShutterTime more than maximun.");

                        try
                        {
                            SCmdSetParam("Set_ShutterTime", "SP_ShutterTime2", value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            double d = 0;
                            SCmdGetParam("Get_ShutterTime", "SA_ShutterTime2", ref d);
                            return d;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }

            public _VidSignal VideoSignal = new _VidSignal();
            public class _VidSignal
            {
                public double VideoThreshold
                {
                    set
                    {
                        try
                        {
                            SCmdSetParam("Set_Threshold", "SP_Threshold", value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            double d = 0;
                            SCmdGetParam("Get_Threshold", "SA_Threshold", ref d);
                            return d;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }

            public _Trig Trig = new _Trig();
            public class _Trig
            {
                public E_IFD2451_TrigMode Mode
                {
                    set
                    {
                        try
                        {
                            SCmdSetParam("Set_TriggerMode", "SP_TriggerMode", (int)value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            int i = 0;
                            SCmdGetParam("Get_TriggerMode", "SA_TriggerMode", ref i);
                            return (E_IFD2451_TrigMode)i;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public int Count
                {
                    set
                    {
                        if (value >= 16383)
                            throw new Exception("Invalid Trigger Count.");

                        try
                        {
                            if (value == -1)
                            {
                                SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", 16383);
                            }
                            else
                                SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", (int)value);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    get
                    {
                        try
                        {
                            int i = 0;
                            SCmdGetParam("Get_TriggerCount", "SA_TriggerCount", ref i);
                            return i;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                public void SwTrig()
                {
                    try
                    {
                        SCmd("Software_Trigger");
                    }
                    catch
                    {
                        throw;
                    }
                }
                public void StopMeas()
                {
                    try
                    {
                        //Count = 0;
                        SCmdSetParam("Set_TriggerCount", "SP_TriggerCount", 0);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}
