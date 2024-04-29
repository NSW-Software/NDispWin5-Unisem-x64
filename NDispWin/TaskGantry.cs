using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace NDispWin
{
    public enum EForceGantryMode { None, XYZ, X2Y2Z2 };

    public class TaskGantry
    {
        internal static CControl2.TDevice Device_0 = new CControl2.TDevice(CControl2.EDeviceType.P1245, 0, "GMC1", "P1245_0");
        internal static CControl2.TDevice Device_1 = new CControl2.TDevice(CControl2.EDeviceType.P1245, 1, "GMC2", "P1245_1");
        internal static CControl2.TDevice Device_D = new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "GMC", "");

        internal static CControl2.TInput _EMO = new CControl2.TInput(Device_0, 0x01, 0x2000, "", "EMO");

        #region TAxis
        internal static CControl2.TAxis GXAxis = new CControl2.TAxis(Device_0, 0x00, "GX", "GX");
        internal static CControl2.TAxis GYAxis = new CControl2.TAxis(Device_0, 0x01, "GY", "GY");
        internal static CControl2.TAxis GZAxis = new CControl2.TAxis(Device_0, 0x02, "GZ", "GZ");
        internal static CControl2.TAxis GUAxis = new CControl2.TAxis(Device_0, 0x03, "GU", "GU");

        internal static CControl2.TAxis GZ2Axis = new CControl2.TAxis(Device_0, 0x08, "GZ2", "GZ2");//XY_Z_Z2Y2_Z2
        //internal static CControl2.TAxis GZ3Axis = new CControl2.TAxis(Device_1, 0x01, "GZ3", "GZ3");
        //internal static CControl2.TAxis GZ4Axis = new CControl2.TAxis(Device_1, 0x02, "GZ4", "GZ4");

        internal static CControl2.TAxis GX2Axis = new CControl2.TAxis(Device_1, 0x01, "GX2", "GX2");//XY_Z_Z2Y2_Z2
        internal static CControl2.TAxis GY2Axis = new CControl2.TAxis(Device_1, 0x02, "GY2", "GY2");//XY_Z_Z2Y2_Z2 

        //internal static CControl2.TAxis RXAxis = new CControl2.TAxis(Device_1, 0x01, "RX", "RX");//XY_Z_RX, XYZ_Z_RXRY 
        //internal static CControl2.TAxis RYAxis = new CControl2.TAxis(Device_1, 0x02, "RY", "RY");//XY_Z_RXRY 

        internal static CControl2.TAxis SZAxis = new CControl2.TAxis(Device_0, 0x04, "SZ", "SZ");//ZSensor 


        #endregion
        #region GXInput
        internal static CControl2.TInput _SensGXHome = new CControl2.TInput(Device_0, 0x01, 0x0004, "", "Sens GX Home");
        internal static CControl2.TInput _GXInp = new CControl2.TInput(Device_0, 0x01, 0x0040, "", "GX Inpos");
        internal static CControl2.TInput _GXAlm = new CControl2.TInput(Device_0, 0x01, 0x0080, "", "GX Alarm");
        internal static CControl2.TInput _SensGXLmtP = new CControl2.TInput(Device_0, 0x01, 0x0400, "", "Sens GX LmtP");
        internal static CControl2.TInput _SensGXLmtN = new CControl2.TInput(Device_0, 0x01, 0x0800, "", "Sens GX LmtN");
        internal static CControl2.TInput _GXSLmtP = new CControl2.TInput(Device_0, 0x01, 0x0100, "", "GX SLmtP");
        internal static CControl2.TInput _GXSLmtN = new CControl2.TInput(Device_0, 0x01, 0x0200, "", "GX SLmtN");
        internal static CControl2.TOutput _GXMtrOn = new CControl2.TOutput(Device_0, 0x01, 0x01, "", "GX Motor On");
        internal static CControl2.TOutput _GXAlmClr = new CControl2.TOutput(Device_0, 0x01, 0x02, "", "GX AlmClr");
        #endregion
        #region GYInput
        internal static CControl2.TInput _SensGYHome = new CControl2.TInput(Device_0, 0x02, 0x0004, "", "Sens GY Home");
        internal static CControl2.TInput _GYInp = new CControl2.TInput(Device_0, 0x02, 0x0040, "", "GY Inpos");
        internal static CControl2.TInput _GYAlm = new CControl2.TInput(Device_0, 0x02, 0x0080, "", "GY Alarm");
        internal static CControl2.TInput _SensGYLmtP = new CControl2.TInput(Device_0, 0x02, 0x0400, "", "Sens GY LmtP");
        internal static CControl2.TInput _SensGYLmtN = new CControl2.TInput(Device_0, 0x02, 0x0800, "", "Sens GY LmtN");
        internal static CControl2.TInput _GYSLmtP = new CControl2.TInput(Device_0, 0x02, 0x0100, "", "GY SLmtP");
        internal static CControl2.TInput _GYSLmtN = new CControl2.TInput(Device_0, 0x02, 0x0200, "", "GY SLmtN");
        internal static CControl2.TOutput _GYMtrOn = new CControl2.TOutput(Device_0, 0x02, 0x01, "", "GY Motor On");
        internal static CControl2.TOutput _GYAlmClr = new CControl2.TOutput(Device_0, 0x02, 0x02, "", "GY AlmClr");
        #endregion
        #region GZ IO
        internal static CControl2.TInput _SensGZHome = new CControl2.TInput(Device_0, 0x03, 0x0004, "", "Sens GZ Home");
        internal static CControl2.TInput _GZInp = new CControl2.TInput(Device_0, 0x03, 0x0040, "", "GZ Inpos");
        internal static CControl2.TInput _GZAlm = new CControl2.TInput(Device_0, 0x03, 0x0080, "", "GZ Alarm");
        internal static CControl2.TInput _SensGZLmtP = new CControl2.TInput(Device_0, 0x03, 0x0400, "", "Sens GZ LmtP");
        internal static CControl2.TInput _SensGZLmtN = new CControl2.TInput(Device_0, 0x03, 0x0800, "", "Sens GZ LmtN");
        internal static CControl2.TInput _GZSLmtP = new CControl2.TInput(Device_0, 0x03, 0x0100, "", "GZ SLmtP");
        internal static CControl2.TInput _GZSLmtN = new CControl2.TInput(Device_0, 0x03, 0x0200, "", "GZ SLmtN");
        internal static CControl2.TOutput _GZMtrOn = new CControl2.TOutput(Device_0, 0x03, 0x01, "", "GZ Motor On");
        internal static CControl2.TOutput _GZAlmClr = new CControl2.TOutput(Device_0, 0x03, 0x02, "", "GZ AlmClr");
        #endregion
        #region GX2 IO
        internal static CControl2.TInput _SensGX2Home = new CControl2.TInput(Device_1, 0x01, 0x0004, "", "Sens GX2 Home");
        internal static CControl2.TInput _GX2Inp = new CControl2.TInput(Device_1, 0x01, 0x0040, "", "GX2 Inpos");
        internal static CControl2.TInput _GX2Alm = new CControl2.TInput(Device_1, 0x01, 0x0080, "", "GX2 Alarm");
        internal static CControl2.TInput _SensGX2LmtP = new CControl2.TInput(Device_1, 0x01, 0x0400, "", "Sens GX2 LmtP");
        internal static CControl2.TInput _SensGX2LmtN = new CControl2.TInput(Device_1, 0x01, 0x0800, "", "Sens GX2 LmtN");
        internal static CControl2.TInput _GX2SLmtP = new CControl2.TInput(Device_1, 0x01, 0x0100, "", "GX2 SLmtP");
        internal static CControl2.TInput _GX2SLmtN = new CControl2.TInput(Device_1, 0x01, 0x0200, "", "GX2 SLmtN");
        internal static CControl2.TOutput _GX2MtrOn = new CControl2.TOutput(Device_1, 0x01, 0x01, "", "GX2 Motor On");
        internal static CControl2.TOutput _GX2AlmClr = new CControl2.TOutput(Device_1, 0x01, 0x02, "", "GX2 AlmClr");
        #endregion
        #region GY2 IO
        internal static CControl2.TInput _SensGY2Home = new CControl2.TInput(Device_1, 0x01, 0x0004, "", "Sens GY2 Home");
        internal static CControl2.TInput _GY2Inp = new CControl2.TInput(Device_1, 0x02, 0x0040, "", "GY2 Inpos");
        internal static CControl2.TInput _GY2Alm = new CControl2.TInput(Device_1, 0x02, 0x0080, "", "GY2 Alarm");
        internal static CControl2.TInput _SensGY2LmtP = new CControl2.TInput(Device_1, 0x02, 0x0400, "", "Sens GY2 LmtP");
        internal static CControl2.TInput _SensGY2LmtN = new CControl2.TInput(Device_1, 0x02, 0x0800, "", "Sens GY2 LmtN");
        internal static CControl2.TInput _GY2SLmtP = new CControl2.TInput(Device_1, 0x01, 0x0100, "", "GY2 SLmtP");
        internal static CControl2.TInput _GY2SLmtN = new CControl2.TInput(Device_1, 0x01, 0x0200, "", "GY2 SLmtN");
        internal static CControl2.TOutput _GY2MtrOn = new CControl2.TOutput(Device_1, 0x02, 0x01, "", "GY2 Motor On");
        internal static CControl2.TOutput _GY2AlmClr = new CControl2.TOutput(Device_1, 0x02, 0x02, "", "GY2 AlmClr");
        #endregion
        #region GZ2 IO
        internal static CControl2.TInput _SensGZ2Home = new CControl2.TInput(Device_0, 0x04, 0x0004, "", "Sens GZ2 Home");
        internal static CControl2.TInput _GZ2Inp = new CControl2.TInput(Device_0, 0x04, 0x0040, "", "GZ2 Inpos");
        internal static CControl2.TInput _GZ2Alm = new CControl2.TInput(Device_0, 0x04, 0x0080, "", "GZ2 Alarm");
        internal static CControl2.TInput _SensGZ2LmtP = new CControl2.TInput(Device_0, 0x04, 0x0400, "", "Sens GZ2 LmtP");
        internal static CControl2.TInput _SensGZ2LmtN = new CControl2.TInput(Device_0, 0x04, 0x0800, "", "Sens GZ2 LmtN");
        internal static CControl2.TInput _GZ2SLmtP = new CControl2.TInput(Device_0, 0x04, 0x0100, "", "GZ2 SLmtP");
        internal static CControl2.TInput _GZ2SLmtN = new CControl2.TInput(Device_0, 0x04, 0x0200, "", "GZ2 SLmtN");
        internal static CControl2.TOutput _GZ2MtrOn = new CControl2.TOutput(Device_0, 0x04, 0x01, "", "GZ2 Motor On");
        internal static CControl2.TOutput _GZ2AlmClr = new CControl2.TOutput(Device_0, 0x04, 0x02, "", "GZ2 AlmClr");
        #endregion
        #region GZ3 IO
        internal static CControl2.TInput _SensGZ3Home = new CControl2.TInput(Device_1, 0x01, 0x0004, "", "Sens GZ3 Home");
        internal static CControl2.TInput _GZ3Inp = new CControl2.TInput(Device_1, 0x01, 0x0040, "", "GZ3 Inpos");
        internal static CControl2.TInput _GZ3Alm = new CControl2.TInput(Device_1, 0x01, 0x0080, "", "GZ3 Alarm");
        internal static CControl2.TInput _SensGZ3LmtP = new CControl2.TInput(Device_1, 0x01, 0x0400, "", "Sens GZ3 LmtP");
        internal static CControl2.TInput _SensGZ3LmtN = new CControl2.TInput(Device_1, 0x01, 0x0800, "", "Sens GZ3 LmtN");
        internal static CControl2.TInput _GZ3SLmtP = new CControl2.TInput(Device_1, 0x01, 0x0100, "", "GZ3 SLmtP");
        internal static CControl2.TInput _GZ3SLmtN = new CControl2.TInput(Device_1, 0x01, 0x0200, "", "GZ3 SLmtN");
        internal static CControl2.TOutput _GZ3MtrOn = new CControl2.TOutput(Device_1, 0x01, 0x01, "", "GZ3 Motor On");
        internal static CControl2.TOutput _GZ3AlmClr = new CControl2.TOutput(Device_1, 0x01, 0x02, "", "GZ3 AlmClr");
        #endregion
        #region GZ4 IO
        internal static CControl2.TInput _SensGZ4Home = new CControl2.TInput(Device_1, 0x02, 0x0004, "", "Sens GZ4 Home");
        internal static CControl2.TInput _GZ4Inp = new CControl2.TInput(Device_1, 0x02, 0x0040, "", "GZ4 Inpos");
        internal static CControl2.TInput _GZ4Alm = new CControl2.TInput(Device_1, 0x02, 0x0080, "", "GZ4 Alarm");
        internal static CControl2.TInput _SensGZ4LmtP = new CControl2.TInput(Device_1, 0x02, 0x0400, "", "Sens GZ4 LmtP");
        internal static CControl2.TInput _SensGZ4LmtN = new CControl2.TInput(Device_1, 0x02, 0x0800, "", "Sens GZ4 LmtN");
        internal static CControl2.TInput _GZ4SLmtP = new CControl2.TInput(Device_1, 0x02, 0x0100, "", "GZ4 SLmtP");
        internal static CControl2.TInput _GZ4SLmtN = new CControl2.TInput(Device_1, 0x02, 0x0200, "", "GZ4 SLmtN");
        internal static CControl2.TOutput _GZ4MtrOn = new CControl2.TOutput(Device_1, 0x02, 0x01, "", "GZ4 Motor On");
        internal static CControl2.TOutput _GZ4AlmClr = new CControl2.TOutput(Device_1, 0x02, 0x02, "", "GZ4 AlmClr");
        #endregion
        #region RX IO
        internal static CControl2.TInput _SensRXHome = new CControl2.TInput(Device_1, 0x01, 0x0004, "", "Sens RX Home");
        internal static CControl2.TInput _RXInp = new CControl2.TInput(Device_1, 0x01, 0x0040, "", "RX Inpos");
        internal static CControl2.TInput _RXAlm = new CControl2.TInput(Device_1, 0x01, 0x0080, "", "RX Alarm");
        internal static CControl2.TInput _SensRXLmtP = new CControl2.TInput(Device_1, 0x01, 0x0400, "", "Sens RX LmtP");
        internal static CControl2.TInput _SensRXLmtN = new CControl2.TInput(Device_1, 0x01, 0x0800, "", "Sens RX LmtN");
        internal static CControl2.TInput _RXSLmtP = new CControl2.TInput(Device_1, 0x01, 0x0100, "", "RX SLmtP");
        internal static CControl2.TInput _RXSLmtN = new CControl2.TInput(Device_1, 0x01, 0x0200, "", "RX SLmtN");
        internal static CControl2.TOutput _RXMtrOn = new CControl2.TOutput(Device_1, 0x01, 0x01, "", "RX Motor On");
        internal static CControl2.TOutput _RXAlmClr = new CControl2.TOutput(Device_1, 0x01, 0x02, "", "RX AlmClr");
        #endregion
        #region RY IO
        internal static CControl2.TInput _SensRYHome = new CControl2.TInput(Device_1, 0x02, 0x0004, "", "Sens RY Home");
        internal static CControl2.TInput _RYInp = new CControl2.TInput(Device_1, 0x02, 0x0040, "", "RY Inpos");
        internal static CControl2.TInput _RYAlm = new CControl2.TInput(Device_1, 0x02, 0x0080, "", "RY Alarm");
        internal static CControl2.TInput _SensRYLmtP = new CControl2.TInput(Device_1, 0x02, 0x0400, "", "Sens RY LmtP");
        internal static CControl2.TInput _SensRYLmtN = new CControl2.TInput(Device_1, 0x02, 0x0800, "", "Sens RY LmtN");
        internal static CControl2.TInput _RYSLmtP = new CControl2.TInput(Device_1, 0x02, 0x0100, "", "RY SLmtP");
        internal static CControl2.TInput _RYSLmtN = new CControl2.TInput(Device_1, 0x02, 0x0200, "", "RY SLmtN");
        internal static CControl2.TOutput _RYMtrOn = new CControl2.TOutput(Device_1, 0x02, 0x01, "", "RY Motor On");
        internal static CControl2.TOutput _RYAlmClr = new CControl2.TOutput(Device_1, 0x02, 0x02, "", "RY AlmClr");
        #endregion

        #region IO
        internal static CControl2.TInput _BtnStart = new CControl2.TInput(Device_0, 0x02, 0x0002, "", "Btn Start");
        internal static CControl2.TInput _BtnStop = new CControl2.TInput(Device_0, 0x02, 0x0004, "", "Btn Stop");

        internal static CControl2.TInput _DispARdy = new CControl2.TInput(Device_0, 0x08, 0x0002, "", "DispA Ready");
        internal static CControl2.TInput _DispBRdy = new CControl2.TInput(Device_0, 0x08, 0x0004, "", "DispB Ready");
        internal static CControl2.TOutput _DispATrg = new CControl2.TOutput(Device_0, 0x08, 0x04, "", "DispA Trig");
        internal static CControl2.TOutput _DispBTrg = new CControl2.TOutput(Device_0, 0x08, 0x08, "", "DispB Trig");
        internal static CControl2.TInput _DispError = new CControl2.TInput(Device_D, 0x01, 0x01, "", "Disp Error");

        internal static CControl2.TInput _SensNeedleZ = new CControl2.TInput(Device_0, 0x04, 0x0002, "", "Sens Needle Z");
        internal static CControl2.TOutput _SvCleanVac = new CControl2.TOutput(Device_0, 0x04, 0x04, "", "Sv Clean Vac");

        internal static CControl2.TOutput _SvChuckVac = new CControl2.TOutput(Device_0, 0x04, 0x08, "", "Sv Chuck Vac");
        internal static CControl2.TInput _SensChuckVac = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x08, "", "Sens Chuck Vac");

        internal static CControl2.TInput _SensMat1Low = new CControl2.TInput(Device_0, 0x00, 0x08, "", "Sense Mat1 Low");
        internal static CControl2.TInput _SensMat2Low = new CControl2.TInput(Device_0, 0x01, 0x08, "", "Sense Mat2 Low");

        internal static CControl2.TOutput _SvFPress1 = new CControl2.TOutput(Device_0, 0x05, 0x04, "", "Sv FPress1");
        internal static CControl2.TOutput _SvFPress2 = new CControl2.TOutput(Device_0, 0x05, 0x08, "", "Sv FPress2");

        internal static CControl2.TOutput _SvFVac1 = new CControl2.TOutput(Device_0, 0x05, 0x04, "", "Sv FVac1");

        internal static CControl2.TOutput _SvPortA1 = new CControl2.TOutput(Device_0, 0x03, 0x04, "", "Sv DispPortA1");
        internal static CControl2.TOutput _SvPortB1 = new CControl2.TOutput(Device_0, 0x03, 0x04, "", "Sv DispPortB1");
        internal static CControl2.TOutput _SvPortC1 = new CControl2.TOutput(Device_0, 0x03, 0x04, "", "Sv DispPortC1");

        internal static CControl2.TOutput _Buzzer = new CControl2.TOutput(Device_0, 0x02, 0x08, "", "Buzzer");

        internal static CControl2.TOutput _GPOut1 = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x08, "", "GP Out1");
        internal static CControl2.TOutput _GPOut2 = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x08, "", "GP Out2");
        internal static CControl2.TOutput _GPOut3 = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x08, "", "GP Out3");
        internal static CControl2.TOutput _GPOut4 = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x08, "", "GP Out4");
        internal static CControl2.TOutput _GPOut5 = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x08, "", "GP Out5");
        internal static CControl2.TOutput _GPOut6 = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x08, "", "GP Out6");

        internal static CControl2.TInput _SensDoor = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x03, 0x03, "", "Sens Door");
        internal static CControl2.TOutput _LockDoor = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x01, "", "Lock Door");

        internal static CControl2.TInput _TapeReady = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x00, 0x04, "", "Tape Ready");
        internal static CControl2.TInput _TapeAlarm = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x01, 0x04, "", "Tape Alarm");
        internal static CControl2.TOutput _TapeTrig = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x01, 0x02, "", "Tape Trig");
        internal static CControl2.TOutput _TapeReset = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x03, 0x02, "", "Tape Reset");

        internal static CControl2.TOutput _SvPnpPrecise = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x00, 0x02, "", "Sv Pnp Precise");
        internal static CControl2.TInput _SensPnpPrecise = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x00, 0x04, "", "Sens Pnp Precise");
        internal static CControl2.TInput _SensPnpContact = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x03, 0x02, "", "Sens Pnp Contact");
        internal static CControl2.TOutput _SvPnpVac = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x01, 0x0002, "", "Sv Pnp Vac");
        internal static CControl2.TOutput _SvPnpPurge = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x01, 0x0001, "", "Sv Pnp Purge");
        internal static CControl2.TInput _SensPnpVac = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x02, 0x0004, "", "Sens Pnp Vac");

        internal static CControl2.TOutput _TlRed = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x01, "", "Tower Light Red");
        internal static CControl2.TOutput _TlYlw = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x02, "", "Tower Light Yellow");
        internal static CControl2.TOutput _TlGrn = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x04, "", "Tower Light Green");
        internal static CControl2.TOutput _TlBzr = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x08, "", "Tower Light Buzzer");

        internal static CControl2.TOutput _NICamTrig = new CControl2.TOutput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x01, "", "NICam Trig");
        internal static CControl2.TInput _NICamSigOK = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x01, "", "NICam SigOK");
        internal static CControl2.TInput _NICamBusy = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x02, "", "NICam Busy");
        internal static CControl2.TInput _NICamRun = new CControl2.TInput(new CControl2.TDevice(CControl2.EDeviceType.NONE, 0, "", ""), 0x04, 0x04, "", "NICam Run");
        #endregion

        public enum TOutputState { On, Off, St };

        public enum EHomeSequence { ZXY, ZYX }
        public static EHomeSequence HomeSequence = EHomeSequence.ZXY;

        public static double ZHeightForSlowSpeed = -100;

        #region device config
        private static void SaveDeviceConfig(ref CControl2.TInput Input, string FileName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(FileName);

            IniFile.WriteInteger(Input.Name, "DeviceType", (int)Input.Device.Type);
            IniFile.WriteInteger(Input.Name, "DeviceID", (int)Input.Device.ID);
            IniFile.WriteInteger(Input.Name, "Axis_Port", Input.Axis_Port);
            Input.Axis_Port = Math.Min(Input.Axis_Port, (byte)7);
            IniFile.WriteInteger(Input.Name, "Mask", Input.Mask);
            IniFile.WriteString(Input.Name, "Label", Input.Label);
        }
        private static void LoadDeviceConfig(ref CControl2.TInput Input, string FileName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(FileName);

            Input.Device.Type = (CControl2.EDeviceType)IniFile.ReadInteger(Input.Name, "DeviceType", 0);

            if (Input.Device.Type > CControl2.EDeviceType.NONE)
            {
                Input.Device.ID = (byte)IniFile.ReadInteger(Input.Name, "DeviceID", 0);
                Input.Axis_Port = (byte)IniFile.ReadInteger(Input.Name, "Axis_Port", 0x00);
                Input.Mask = (ushort)IniFile.ReadInteger(Input.Name, "Mask", 0x0000);
                Input.Axis_Port = Math.Min(Input.Axis_Port, (byte)7);
                Input.Label = IniFile.ReadString(Input.Name, "Label", "undefined");
            }
        }
        private static void SaveDeviceConfig(ref CControl2.TOutput Output, string FileName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(FileName);

            IniFile.WriteInteger(Output.Name, "DeviceType", (int)Output.Device.Type);
            IniFile.WriteInteger(Output.Name, "DeviceID", (int)Output.Device.ID);
            IniFile.WriteInteger(Output.Name, "Axis_Port", Output.Axis_Port);
            Output.Axis_Port = Math.Min(Output.Axis_Port, (byte)7);
            IniFile.WriteInteger(Output.Name, "Mask", Output.Mask);
            IniFile.WriteString(Output.Name, "Label", Output.Label);
        }
        private static void LoadDeviceConfig(ref CControl2.TOutput Output, string FileName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(FileName);

            Output.Device.Type = (CControl2.EDeviceType)IniFile.ReadInteger(Output.Name, "DeviceType", 0);

            if (Output.Device.Type > CControl2.EDeviceType.NONE)
            {
                Output.Device.ID = (byte)IniFile.ReadInteger(Output.Name, "DeviceID", 0);
                Output.Axis_Port = (byte)IniFile.ReadInteger(Output.Name, "Axis_Port", 0x00);
                Output.Mask = (ushort)IniFile.ReadInteger(Output.Name, "Mask", 0x0000);
                Output.Axis_Port = Math.Min(Output.Axis_Port, (byte)7);
                Output.Label = IniFile.ReadString(Output.Name, "Label", "undefined");
            }
        }
        private static void SaveDeviceConfig(ref CControl2.TAxis Axis, string FileName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(FileName);

            IniFile.WriteInteger(Axis.Name, "DeviceType", (int)Axis.Device.Type);
            IniFile.WriteInteger(Axis.Name, "DeviceID", (int)Axis.Device.ID);
            IniFile.WriteInteger(Axis.Name, "Mask", Axis.Mask);
            IniFile.WriteString(Axis.Name, "Label", Axis.Label);
        }
        private static void LoadDeviceConfig(ref CControl2.TAxis Axis, string FileName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(FileName);

            Axis.Device.Type = (CControl2.EDeviceType)IniFile.ReadInteger(Axis.Name, "DeviceType", 0);

            if (Axis.Device.Type > CControl2.EDeviceType.NONE)
            {
                Axis.Device.ID = (byte)IniFile.ReadInteger(Axis.Name, "DeviceID", 0);
                Axis.Mask = (byte)IniFile.ReadInteger(Axis.Name, "Mask", 0x0000);
                Axis.Label = IniFile.ReadString(Axis.Name, "Label", "undefined");
            }
        }
        public static void SaveDeviceConfig(string FileName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(FileName);

            #region Device
            IniFile.WriteInteger("Device_0", "Type", (int)Device_0.Type);
            IniFile.WriteInteger("Device_0", "ID", Device_0.ID);
            IniFile.WriteString("Device_0", "IPAddress", Device_0.IPAddress);
            IniFile.WriteString("Device_0", "Label", Device_0.Label);
            //IniFile.WriteString("Device_0", "Name", Device_0.Name);

            IniFile.WriteInteger("Device_1", "Type", (int)Device_1.Type);
            IniFile.WriteInteger("Device_1", "ID", Device_1.ID);
            IniFile.WriteString("Device_1", "IPAddress", Device_1.IPAddress);
            IniFile.WriteString("Device_1", "Label", Device_1.Label);
            //IniFile.WriteString("Device_1", "Name", Device_1.Name);
            #endregion
            #region Axis
            SaveDeviceConfig(ref GXAxis, FileName);
            SaveDeviceConfig(ref GYAxis, FileName);
            SaveDeviceConfig(ref GZAxis, FileName);
            SaveDeviceConfig(ref GX2Axis, FileName);
            SaveDeviceConfig(ref GY2Axis, FileName);
            SaveDeviceConfig(ref GZ2Axis, FileName);
            SaveDeviceConfig(ref SZAxis, FileName);
            #endregion
            #region IO
            SaveDeviceConfig(ref _SensGXHome, FileName);
            SaveDeviceConfig(ref _GXInp, FileName);
            SaveDeviceConfig(ref _GXAlm, FileName);
            SaveDeviceConfig(ref _SensGXLmtP, FileName);
            SaveDeviceConfig(ref _SensGXLmtN, FileName);
            SaveDeviceConfig(ref _GXSLmtP, FileName);
            SaveDeviceConfig(ref _GXSLmtN, FileName);
            SaveDeviceConfig(ref _GXMtrOn, FileName);
            SaveDeviceConfig(ref _GXAlmClr, FileName);

            SaveDeviceConfig(ref _SensGYHome, FileName);
            SaveDeviceConfig(ref _GYInp, FileName);
            SaveDeviceConfig(ref _GYAlm, FileName);
            SaveDeviceConfig(ref _SensGYLmtP, FileName);
            SaveDeviceConfig(ref _SensGYLmtN, FileName);
            SaveDeviceConfig(ref _GYSLmtP, FileName);
            SaveDeviceConfig(ref _GYSLmtN, FileName);
            SaveDeviceConfig(ref _GYMtrOn, FileName);
            SaveDeviceConfig(ref _GYAlmClr, FileName);

            SaveDeviceConfig(ref _SensGZHome, FileName);
            SaveDeviceConfig(ref _GZInp, FileName);
            SaveDeviceConfig(ref _GZAlm, FileName);
            SaveDeviceConfig(ref _SensGZLmtP, FileName);
            SaveDeviceConfig(ref _SensGZLmtN, FileName);
            SaveDeviceConfig(ref _GZSLmtP, FileName);
            SaveDeviceConfig(ref _GZSLmtN, FileName);
            SaveDeviceConfig(ref _GZMtrOn, FileName);
            SaveDeviceConfig(ref _GZAlmClr, FileName);

            SaveDeviceConfig(ref _SensGX2Home, FileName);
            SaveDeviceConfig(ref _GX2Inp, FileName);
            SaveDeviceConfig(ref _GX2Alm, FileName);
            SaveDeviceConfig(ref _SensGX2LmtP, FileName);
            SaveDeviceConfig(ref _SensGX2LmtN, FileName);
            SaveDeviceConfig(ref _GX2SLmtP, FileName);
            SaveDeviceConfig(ref _GX2SLmtN, FileName);
            SaveDeviceConfig(ref _GX2MtrOn, FileName);
            SaveDeviceConfig(ref _GX2AlmClr, FileName);

            SaveDeviceConfig(ref _SensGY2Home, FileName);
            SaveDeviceConfig(ref _GY2Inp, FileName);
            SaveDeviceConfig(ref _GY2Alm, FileName);
            SaveDeviceConfig(ref _SensGY2LmtP, FileName);
            SaveDeviceConfig(ref _SensGY2LmtN, FileName);
            SaveDeviceConfig(ref _GY2SLmtP, FileName);
            SaveDeviceConfig(ref _GY2SLmtN, FileName);
            SaveDeviceConfig(ref _GY2MtrOn, FileName);
            SaveDeviceConfig(ref _GY2AlmClr, FileName);

            SaveDeviceConfig(ref _SensGZ2Home, FileName);
            SaveDeviceConfig(ref _GZ2Inp, FileName);
            SaveDeviceConfig(ref _GZ2Alm, FileName);
            SaveDeviceConfig(ref _SensGZ2LmtP, FileName);
            SaveDeviceConfig(ref _SensGZ2LmtN, FileName);
            SaveDeviceConfig(ref _GZ2SLmtP, FileName);
            SaveDeviceConfig(ref _GZ2SLmtN, FileName);
            SaveDeviceConfig(ref _GZ2MtrOn, FileName);
            SaveDeviceConfig(ref _GZ2AlmClr, FileName);

            SaveDeviceConfig(ref _SensGZ3Home, FileName);
            SaveDeviceConfig(ref _GZ3Inp, FileName);
            SaveDeviceConfig(ref _GZ3Alm, FileName);
            SaveDeviceConfig(ref _SensGZ3LmtP, FileName);
            SaveDeviceConfig(ref _SensGZ3LmtN, FileName);
            SaveDeviceConfig(ref _GZ3SLmtP, FileName);
            SaveDeviceConfig(ref _GZ3SLmtN, FileName);
            SaveDeviceConfig(ref _GZ3MtrOn, FileName);
            SaveDeviceConfig(ref _GZ3AlmClr, FileName);

            SaveDeviceConfig(ref _SensGZ4Home, FileName);
            SaveDeviceConfig(ref _GZ4Inp, FileName);
            SaveDeviceConfig(ref _GZ4Alm, FileName);
            SaveDeviceConfig(ref _SensGZ4LmtP, FileName);
            SaveDeviceConfig(ref _SensGZ4LmtN, FileName);
            SaveDeviceConfig(ref _GZ4SLmtP, FileName);
            SaveDeviceConfig(ref _GZ4SLmtN, FileName);
            SaveDeviceConfig(ref _GZ4MtrOn, FileName);
            SaveDeviceConfig(ref _GZ4AlmClr, FileName);

            SaveDeviceConfig(ref _SensRXHome, FileName);
            SaveDeviceConfig(ref _RXInp, FileName);
            SaveDeviceConfig(ref _RXAlm, FileName);
            SaveDeviceConfig(ref _SensRXLmtP, FileName);
            SaveDeviceConfig(ref _SensRXLmtN, FileName);
            SaveDeviceConfig(ref _RXSLmtP, FileName);
            SaveDeviceConfig(ref _RXSLmtN, FileName);
            SaveDeviceConfig(ref _RXMtrOn, FileName);
            SaveDeviceConfig(ref _RXAlmClr, FileName);

            SaveDeviceConfig(ref _SensRYHome, FileName);
            SaveDeviceConfig(ref _RYInp, FileName);
            SaveDeviceConfig(ref _RYAlm, FileName);
            SaveDeviceConfig(ref _SensRYLmtP, FileName);
            SaveDeviceConfig(ref _SensRYLmtN, FileName);
            SaveDeviceConfig(ref _RYSLmtP, FileName);
            SaveDeviceConfig(ref _RYSLmtN, FileName);
            SaveDeviceConfig(ref _RYMtrOn, FileName);
            SaveDeviceConfig(ref _RYAlmClr, FileName);

            SaveDeviceConfig(ref _BtnStart, FileName);
            SaveDeviceConfig(ref _BtnStop, FileName);
            SaveDeviceConfig(ref _DispARdy, FileName);
            SaveDeviceConfig(ref _DispBRdy, FileName);
            SaveDeviceConfig(ref _DispATrg, FileName);
            SaveDeviceConfig(ref _DispBTrg, FileName);
            SaveDeviceConfig(ref _DispError, FileName);
            SaveDeviceConfig(ref _SensNeedleZ, FileName);
            SaveDeviceConfig(ref _SvCleanVac, FileName);
            SaveDeviceConfig(ref _SvChuckVac, FileName);
            SaveDeviceConfig(ref _SensChuckVac, FileName);
            SaveDeviceConfig(ref _SensMat1Low, FileName);
            SaveDeviceConfig(ref _SensMat2Low, FileName);

            SaveDeviceConfig(ref _SvFPress1, FileName);
            SaveDeviceConfig(ref _SvFPress2, FileName);
            SaveDeviceConfig(ref _SvFVac1, FileName);
            SaveDeviceConfig(ref _SvPortA1, FileName);
            SaveDeviceConfig(ref _SvPortB1, FileName);
            SaveDeviceConfig(ref _SvPortC1, FileName);

            SaveDeviceConfig(ref _Buzzer, FileName);

            SaveDeviceConfig(ref _GPOut1, FileName);
            SaveDeviceConfig(ref _GPOut2, FileName);
            SaveDeviceConfig(ref _GPOut3, FileName);
            SaveDeviceConfig(ref _GPOut4, FileName);
            SaveDeviceConfig(ref _GPOut5, FileName);
            SaveDeviceConfig(ref _GPOut6, FileName);

            SaveDeviceConfig(ref _SensDoor, FileName);
            SaveDeviceConfig(ref _LockDoor, FileName);

            SaveDeviceConfig(ref _TapeReady, FileName);
            SaveDeviceConfig(ref _TapeTrig, FileName);
            SaveDeviceConfig(ref _TapeAlarm, FileName);
            SaveDeviceConfig(ref _TapeReset, FileName);

            SaveDeviceConfig(ref _SvPnpPrecise, FileName);
            SaveDeviceConfig(ref _SensPnpPrecise, FileName);
            SaveDeviceConfig(ref _SensPnpContact, FileName);
            SaveDeviceConfig(ref _SensPnpVac, FileName);
            SaveDeviceConfig(ref _SvPnpVac, FileName);
            SaveDeviceConfig(ref _SvPnpPurge, FileName);

            SaveDeviceConfig(ref _TlRed, FileName);
            SaveDeviceConfig(ref _TlYlw, FileName);
            SaveDeviceConfig(ref _TlGrn, FileName);
            SaveDeviceConfig(ref _TlBzr, FileName);

            SaveDeviceConfig(ref _NICamSigOK, FileName);
            SaveDeviceConfig(ref _NICamBusy, FileName);
            SaveDeviceConfig(ref _NICamRun, FileName);
            SaveDeviceConfig(ref _NICamTrig, FileName);
            #endregion
        }
        public static void LoadDeviceConfig(string FileName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(FileName);

            Device_0.Type = (CControl2.EDeviceType)IniFile.ReadInteger("Device_0", "Type", (int)CControl2.EDeviceType.P1245);
            Device_0.ID = (byte)IniFile.ReadInteger("Device_0", "ID", 0);
            Device_0.IPAddress = IniFile.ReadString("Device_0", "IPAddress", "10.0.0.0");
            Device_0.Label = IniFile.ReadString("Device_0", "Label", "");
            string Type = Enum.GetName(typeof(CControl2.EDeviceType), Device_0.Type);
            Device_0.Name = Type + "_" + Device_0.ID;

            //Device_0.CheckDependencies();

            Device_1.Type = (CControl2.EDeviceType)IniFile.ReadInteger("Device_1", "Type", (int)CControl2.EDeviceType.NONE);
            Device_1.ID = (byte)IniFile.ReadInteger("Device_1", "ID", 1);
            Device_1.IPAddress = IniFile.ReadString("Device_1", "IPAddress", "10.0.0.1");
            Device_1.Label = IniFile.ReadString("Device_1", "Label", "");
            Type = Enum.GetName(typeof(CControl2.EDeviceType), Device_1.Type);
            Device_1.Name = Type + "_" + Device_1.ID;

            //Device_1.CheckDependencies();

            #region Axis
            LoadDeviceConfig(ref GXAxis, FileName);
            LoadDeviceConfig(ref GYAxis, FileName);
            LoadDeviceConfig(ref GZAxis, FileName);
            LoadDeviceConfig(ref GX2Axis, FileName);
            LoadDeviceConfig(ref GY2Axis, FileName);
            LoadDeviceConfig(ref GZ2Axis, FileName);
            LoadDeviceConfig(ref SZAxis, FileName);
            #endregion
            #region IO
            LoadDeviceConfig(ref _SensGXHome, FileName);
            LoadDeviceConfig(ref _GXInp, FileName);
            LoadDeviceConfig(ref _GXAlm, FileName);
            LoadDeviceConfig(ref _SensGXLmtP, FileName);
            LoadDeviceConfig(ref _SensGXLmtN, FileName);
            LoadDeviceConfig(ref _GXSLmtP, FileName);
            LoadDeviceConfig(ref _GXSLmtN, FileName);
            LoadDeviceConfig(ref _GXMtrOn, FileName);
            LoadDeviceConfig(ref _GXAlmClr, FileName);

            LoadDeviceConfig(ref _SensGYHome, FileName);
            LoadDeviceConfig(ref _GYInp, FileName);
            LoadDeviceConfig(ref _GYAlm, FileName);
            LoadDeviceConfig(ref _SensGYLmtP, FileName);
            LoadDeviceConfig(ref _SensGYLmtN, FileName);
            LoadDeviceConfig(ref _GYSLmtP, FileName);
            LoadDeviceConfig(ref _GYSLmtN, FileName);
            LoadDeviceConfig(ref _GYMtrOn, FileName);
            LoadDeviceConfig(ref _GYAlmClr, FileName);

            LoadDeviceConfig(ref _SensGZHome, FileName);
            LoadDeviceConfig(ref _GZInp, FileName);
            LoadDeviceConfig(ref _GZAlm, FileName);
            LoadDeviceConfig(ref _SensGZLmtP, FileName);
            LoadDeviceConfig(ref _SensGZLmtN, FileName);
            LoadDeviceConfig(ref _GZSLmtP, FileName);
            LoadDeviceConfig(ref _GZSLmtN, FileName);
            LoadDeviceConfig(ref _GZMtrOn, FileName);
            LoadDeviceConfig(ref _GZAlmClr, FileName);

            LoadDeviceConfig(ref _SensGX2Home, FileName);
            LoadDeviceConfig(ref _GX2Inp, FileName);
            LoadDeviceConfig(ref _GX2Alm, FileName);
            LoadDeviceConfig(ref _SensGX2LmtP, FileName);
            LoadDeviceConfig(ref _SensGX2LmtN, FileName);
            LoadDeviceConfig(ref _GX2SLmtP, FileName);
            LoadDeviceConfig(ref _GX2SLmtN, FileName);
            LoadDeviceConfig(ref _GX2MtrOn, FileName);
            LoadDeviceConfig(ref _GX2AlmClr, FileName);

            LoadDeviceConfig(ref _SensGY2Home, FileName);
            LoadDeviceConfig(ref _GY2Inp, FileName);
            LoadDeviceConfig(ref _GY2Alm, FileName);
            LoadDeviceConfig(ref _SensGY2LmtP, FileName);
            LoadDeviceConfig(ref _SensGY2LmtN, FileName);
            LoadDeviceConfig(ref _GY2SLmtP, FileName);
            LoadDeviceConfig(ref _GY2SLmtN, FileName);
            LoadDeviceConfig(ref _GY2MtrOn, FileName);
            LoadDeviceConfig(ref _GY2AlmClr, FileName);

            LoadDeviceConfig(ref _SensGZ2Home, FileName);
            LoadDeviceConfig(ref _GZ2Inp, FileName);
            LoadDeviceConfig(ref _GZ2Alm, FileName);
            LoadDeviceConfig(ref _SensGZ2LmtP, FileName);
            LoadDeviceConfig(ref _SensGZ2LmtN, FileName);
            LoadDeviceConfig(ref _GZ2SLmtP, FileName);
            LoadDeviceConfig(ref _GZ2SLmtN, FileName);
            LoadDeviceConfig(ref _GZ2MtrOn, FileName);
            LoadDeviceConfig(ref _GZ2AlmClr, FileName);

            LoadDeviceConfig(ref _SensGZ3Home, FileName);
            LoadDeviceConfig(ref _GZ3Inp, FileName);
            LoadDeviceConfig(ref _GZ3Alm, FileName);
            LoadDeviceConfig(ref _SensGZ3LmtP, FileName);
            LoadDeviceConfig(ref _SensGZ3LmtN, FileName);
            LoadDeviceConfig(ref _GZ3SLmtP, FileName);
            LoadDeviceConfig(ref _GZ3SLmtN, FileName);
            LoadDeviceConfig(ref _GZ3MtrOn, FileName);
            LoadDeviceConfig(ref _GZ3AlmClr, FileName);

            LoadDeviceConfig(ref _SensGZ4Home, FileName);
            LoadDeviceConfig(ref _GZ4Inp, FileName);
            LoadDeviceConfig(ref _GZ4Alm, FileName);
            LoadDeviceConfig(ref _SensGZ4LmtP, FileName);
            LoadDeviceConfig(ref _SensGZ4LmtN, FileName);
            LoadDeviceConfig(ref _GZ4SLmtP, FileName);
            LoadDeviceConfig(ref _GZ4SLmtN, FileName);
            LoadDeviceConfig(ref _GZ4MtrOn, FileName);
            LoadDeviceConfig(ref _GZ4AlmClr, FileName);

            LoadDeviceConfig(ref _SensRXHome, FileName);
            LoadDeviceConfig(ref _RXInp, FileName);
            LoadDeviceConfig(ref _RXAlm, FileName);
            LoadDeviceConfig(ref _SensRXLmtP, FileName);
            LoadDeviceConfig(ref _SensRXLmtN, FileName);
            LoadDeviceConfig(ref _RXSLmtP, FileName);
            LoadDeviceConfig(ref _RXSLmtN, FileName);
            LoadDeviceConfig(ref _RXMtrOn, FileName);
            LoadDeviceConfig(ref _RXAlmClr, FileName);

            LoadDeviceConfig(ref _SensRYHome, FileName);
            LoadDeviceConfig(ref _RYInp, FileName);
            LoadDeviceConfig(ref _RYAlm, FileName);
            LoadDeviceConfig(ref _SensRYLmtP, FileName);
            LoadDeviceConfig(ref _SensRYLmtN, FileName);
            LoadDeviceConfig(ref _RYSLmtP, FileName);
            LoadDeviceConfig(ref _RYSLmtN, FileName);
            LoadDeviceConfig(ref _RYMtrOn, FileName);
            LoadDeviceConfig(ref _RYAlmClr, FileName);

            LoadDeviceConfig(ref _BtnStart, FileName);
            LoadDeviceConfig(ref _BtnStop, FileName);
            LoadDeviceConfig(ref _DispARdy, FileName);
            LoadDeviceConfig(ref _DispBRdy, FileName);
            LoadDeviceConfig(ref _DispATrg, FileName);
            LoadDeviceConfig(ref _DispBTrg, FileName);
            LoadDeviceConfig(ref _DispError, FileName);
            LoadDeviceConfig(ref _SensNeedleZ, FileName);
            LoadDeviceConfig(ref _SvCleanVac, FileName);
            LoadDeviceConfig(ref _SvChuckVac, FileName);
            LoadDeviceConfig(ref _SensChuckVac, FileName);
            LoadDeviceConfig(ref _SensMat1Low, FileName);
            LoadDeviceConfig(ref _SensMat2Low, FileName);

            LoadDeviceConfig(ref _SvFPress1, FileName);
            LoadDeviceConfig(ref _SvFPress2, FileName);
            LoadDeviceConfig(ref _SvFVac1, FileName);
            LoadDeviceConfig(ref _SvPortA1, FileName);
            LoadDeviceConfig(ref _SvPortB1, FileName);
            LoadDeviceConfig(ref _SvPortC1, FileName);

            LoadDeviceConfig(ref _Buzzer, FileName);

            LoadDeviceConfig(ref _GPOut1, FileName);
            LoadDeviceConfig(ref _GPOut2, FileName);
            LoadDeviceConfig(ref _GPOut3, FileName);
            LoadDeviceConfig(ref _GPOut4, FileName);
            LoadDeviceConfig(ref _GPOut5, FileName);
            LoadDeviceConfig(ref _GPOut6, FileName);

            LoadDeviceConfig(ref _SensDoor, FileName);
            LoadDeviceConfig(ref _LockDoor, FileName);

            LoadDeviceConfig(ref _TapeReady, FileName);
            LoadDeviceConfig(ref _TapeTrig, FileName);
            LoadDeviceConfig(ref _TapeAlarm, FileName);
            LoadDeviceConfig(ref _TapeReset, FileName);

            LoadDeviceConfig(ref _SvPnpPrecise, FileName);
            LoadDeviceConfig(ref _SensPnpPrecise, FileName);
            LoadDeviceConfig(ref _SensPnpContact, FileName);
            LoadDeviceConfig(ref _SensPnpVac, FileName);
            LoadDeviceConfig(ref _SvPnpVac, FileName);
            LoadDeviceConfig(ref _SvPnpPurge, FileName);

            LoadDeviceConfig(ref _TlRed, FileName);
            LoadDeviceConfig(ref _TlYlw, FileName);
            LoadDeviceConfig(ref _TlGrn, FileName);
            LoadDeviceConfig(ref _TlBzr, FileName);

            LoadDeviceConfig(ref _NICamSigOK, FileName);
            LoadDeviceConfig(ref _NICamBusy, FileName);
            LoadDeviceConfig(ref _NICamRun, FileName);
            LoadDeviceConfig(ref _NICamTrig, FileName);
            #endregion
        }

        public static void UpdateDeviceConfig(ref CControl2.TAxis Axis, CControl2.TDevice OldDev, CControl2.TDevice NewDev)
        {
            if (Axis.Device.Type == OldDev.Type && Axis.Device.ID == OldDev.ID)
                Axis.Device = NewDev;
        }
        public static void UpdateDeviceConfig(ref CControl2.TInput Input, CControl2.TDevice OldDev, CControl2.TDevice NewDev)
        {
            if (Input.Device.Type == OldDev.Type && Input.Device.ID == OldDev.ID)
                Input.Device = NewDev;
        }
        public static void UpdateDeviceConfig(ref CControl2.TOutput Output, CControl2.TDevice OldDev, CControl2.TDevice NewDev)
        {
            if (Output.Device.Type == OldDev.Type && Output.Device.ID == OldDev.ID)
                Output.Device = NewDev;
        }
        public static void UpdateDeviceConfig(CControl2.TDevice OldDev, CControl2.TDevice NewDev)
        {
            #region Axis
            UpdateDeviceConfig(ref GXAxis, OldDev, NewDev);
            UpdateDeviceConfig(ref GYAxis, OldDev, NewDev);
            UpdateDeviceConfig(ref GZAxis, OldDev, NewDev);
            UpdateDeviceConfig(ref GX2Axis, OldDev, NewDev);
            UpdateDeviceConfig(ref GY2Axis, OldDev, NewDev);
            UpdateDeviceConfig(ref GZ2Axis, OldDev, NewDev);
            #endregion
            #region IO
            UpdateDeviceConfig(ref _SensGXHome, OldDev, NewDev);
            UpdateDeviceConfig(ref _GXInp, OldDev, NewDev);
            UpdateDeviceConfig(ref _GXAlm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGXLmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGXLmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _GXMtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _GXAlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensGYHome, OldDev, NewDev);
            UpdateDeviceConfig(ref _GYInp, OldDev, NewDev);
            UpdateDeviceConfig(ref _GYAlm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGYLmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGYLmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _GYMtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _GYAlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensGZHome, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZInp, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZAlm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGZLmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGZLmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZMtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZAlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensGX2Home, OldDev, NewDev);
            UpdateDeviceConfig(ref _GX2Inp, OldDev, NewDev);
            UpdateDeviceConfig(ref _GX2Alm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGX2LmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGX2LmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _GX2MtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _GX2AlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensGY2Home, OldDev, NewDev);
            UpdateDeviceConfig(ref _GY2Inp, OldDev, NewDev);
            UpdateDeviceConfig(ref _GY2Alm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGY2LmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGY2LmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _GY2MtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _GY2AlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensGZ2Home, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ2Inp, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ2Alm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGZ2LmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGZ2LmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ2MtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ2AlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensGZ3Home, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ3Inp, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ3Alm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGZ3LmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGZ3LmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ3MtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ3AlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensGZ4Home, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ4Inp, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ4Alm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGZ4LmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensGZ4LmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ4MtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _GZ4AlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensRXHome, OldDev, NewDev);
            UpdateDeviceConfig(ref _RXInp, OldDev, NewDev);
            UpdateDeviceConfig(ref _RXAlm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensRXLmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensRXLmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _RXMtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _RXAlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensRYHome, OldDev, NewDev);
            UpdateDeviceConfig(ref _RYInp, OldDev, NewDev);
            UpdateDeviceConfig(ref _RYAlm, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensRYLmtP, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensRYLmtN, OldDev, NewDev);
            UpdateDeviceConfig(ref _RYMtrOn, OldDev, NewDev);
            UpdateDeviceConfig(ref _RYAlmClr, OldDev, NewDev);

            UpdateDeviceConfig(ref _BtnStart, OldDev, NewDev);
            UpdateDeviceConfig(ref _BtnStop, OldDev, NewDev);
            UpdateDeviceConfig(ref _DispARdy, OldDev, NewDev);
            UpdateDeviceConfig(ref _DispBRdy, OldDev, NewDev);
            UpdateDeviceConfig(ref _DispATrg, OldDev, NewDev);
            UpdateDeviceConfig(ref _DispBTrg, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensNeedleZ, OldDev, NewDev);
            UpdateDeviceConfig(ref _SvCleanVac, OldDev, NewDev);

            UpdateDeviceConfig(ref _SensMat1Low, OldDev, NewDev);
            UpdateDeviceConfig(ref _SensMat2Low, OldDev, NewDev);
            #endregion
        }

        public static void UpdateAxisConfig(ref CControl2.TInput Input, CControl2.TAxis OldAxis, CControl2.TAxis NewAxis)
        {
            if (Input.Device.Type == OldAxis.Device.Type && Input.Device.ID == OldAxis.Device.ID && Input.Axis_Port == OldAxis.Mask)
                Input.Axis_Port = NewAxis.Mask;
        }
        public static void UpdateAxisConfig(ref CControl2.TOutput Output, CControl2.TAxis OldAxis, CControl2.TAxis NewAxis)
        {
            if (Output.Device.Type == OldAxis.Device.Type && Output.Device.ID == OldAxis.Device.ID && Output.Axis_Port == OldAxis.Mask)
                Output.Axis_Port = NewAxis.Mask;
        }
        public static void UpdateAxisConfig(CControl2.TAxis OldAxis, CControl2.TAxis NewAxis)
        {
            #region IO
            UpdateAxisConfig(ref _SensGXHome, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GXInp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GXAlm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGXLmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGXLmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GXMtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GXAlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensGYHome, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GYInp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GYAlm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGYLmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGYLmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GYMtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GYAlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensGZHome, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZInp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZAlm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGZLmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGZLmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZMtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZAlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensGX2Home, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GX2Inp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GX2Alm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGX2LmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGX2LmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GX2MtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GX2AlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensGY2Home, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GY2Inp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GY2Alm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGY2LmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGY2LmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GY2MtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GY2AlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensGZ2Home, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ2Inp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ2Alm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGZ2LmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGZ2LmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ2MtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ2AlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensGZ3Home, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ3Inp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ3Alm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGZ3LmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGZ3LmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ3MtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ3AlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensGZ4Home, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ4Inp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ4Alm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGZ4LmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensGZ4LmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ4MtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _GZ4AlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensRXHome, OldAxis, NewAxis);
            UpdateAxisConfig(ref _RXInp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _RXAlm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensRXLmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensRXLmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _RXMtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _RXAlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensRYHome, OldAxis, NewAxis);
            UpdateAxisConfig(ref _RYInp, OldAxis, NewAxis);
            UpdateAxisConfig(ref _RYAlm, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensRYLmtP, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensRYLmtN, OldAxis, NewAxis);
            UpdateAxisConfig(ref _RYMtrOn, OldAxis, NewAxis);
            UpdateAxisConfig(ref _RYAlmClr, OldAxis, NewAxis);

            UpdateAxisConfig(ref _BtnStart, OldAxis, NewAxis);
            UpdateAxisConfig(ref _BtnStop, OldAxis, NewAxis);
            UpdateAxisConfig(ref _DispARdy, OldAxis, NewAxis);
            UpdateAxisConfig(ref _DispBRdy, OldAxis, NewAxis);
            UpdateAxisConfig(ref _DispATrg, OldAxis, NewAxis);
            UpdateAxisConfig(ref _DispBTrg, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensNeedleZ, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SvCleanVac, OldAxis, NewAxis);

            UpdateAxisConfig(ref _SensMat1Low, OldAxis, NewAxis);
            UpdateAxisConfig(ref _SensMat2Low, OldAxis, NewAxis);
            #endregion
        }
        #endregion
        public static void UpdateAxisConfig2(CControl2.TAxis Axis, CControl2.TAxis NewAxis)
        {
            switch (Axis.Name)
            {
                case "GX":
                    _SensGXHome.Axis_Port = NewAxis.Mask;
                    _SensGXLmtP.Axis_Port = NewAxis.Mask;
                    _SensGXLmtN.Axis_Port = NewAxis.Mask;
                    _GXSLmtP.Axis_Port = NewAxis.Mask;
                    _GXSLmtN.Axis_Port = NewAxis.Mask;
                    _GXInp.Axis_Port = NewAxis.Mask;
                    _GXAlm.Axis_Port = NewAxis.Mask;
                    _GXMtrOn.Axis_Port = NewAxis.Mask;
                    _GXAlmClr.Axis_Port = NewAxis.Mask;
                    break;
                case "GY":
                    _SensGYHome.Axis_Port = NewAxis.Mask;
                    _SensGYLmtP.Axis_Port = NewAxis.Mask;
                    _SensGYLmtN.Axis_Port = NewAxis.Mask;
                    _GYSLmtP.Axis_Port = NewAxis.Mask;
                    _GYSLmtN.Axis_Port = NewAxis.Mask;
                    _GYInp.Axis_Port = NewAxis.Mask;
                    _GYAlm.Axis_Port = NewAxis.Mask;
                    _GYMtrOn.Axis_Port = NewAxis.Mask;
                    _GYAlmClr.Axis_Port = NewAxis.Mask;
                    break;
                case "GZ":
                    _SensGZHome.Axis_Port = NewAxis.Mask;
                    _SensGZLmtP.Axis_Port = NewAxis.Mask;
                    _SensGZLmtN.Axis_Port = NewAxis.Mask;
                    _GZSLmtP.Axis_Port = NewAxis.Mask;
                    _GZSLmtN.Axis_Port = NewAxis.Mask;
                    _GZInp.Axis_Port = NewAxis.Mask;
                    _GZAlm.Axis_Port = NewAxis.Mask;
                    _GZMtrOn.Axis_Port = NewAxis.Mask;
                    _GZAlmClr.Axis_Port = NewAxis.Mask;
                    break;
                case "GX2":
                    _SensGX2Home.Axis_Port = NewAxis.Mask;
                    _SensGX2LmtP.Axis_Port = NewAxis.Mask;
                    _SensGX2LmtN.Axis_Port = NewAxis.Mask;
                    _GX2SLmtP.Axis_Port = NewAxis.Mask;
                    _GX2SLmtN.Axis_Port = NewAxis.Mask;
                    _GX2Inp.Axis_Port = NewAxis.Mask;
                    _GX2Alm.Axis_Port = NewAxis.Mask;
                    _GX2MtrOn.Axis_Port = NewAxis.Mask;
                    _GX2AlmClr.Axis_Port = NewAxis.Mask;
                    break;
                case "GY2":
                    _SensGY2Home.Axis_Port = NewAxis.Mask;
                    _SensGY2LmtP.Axis_Port = NewAxis.Mask;
                    _SensGY2LmtN.Axis_Port = NewAxis.Mask;
                    _GY2SLmtP.Axis_Port = NewAxis.Mask;
                    _GY2SLmtN.Axis_Port = NewAxis.Mask;
                    _GY2Inp.Axis_Port = NewAxis.Mask;
                    _GY2Alm.Axis_Port = NewAxis.Mask;
                    _GY2MtrOn.Axis_Port = NewAxis.Mask;
                    _GY2AlmClr.Axis_Port = NewAxis.Mask;
                    break;
                case "GZ2":
                    _SensGZ2Home.Axis_Port = NewAxis.Mask;
                    _SensGZ2LmtP.Axis_Port = NewAxis.Mask;
                    _SensGZ2LmtN.Axis_Port = NewAxis.Mask;
                    _GZ2SLmtP.Axis_Port = NewAxis.Mask;
                    _GZ2SLmtN.Axis_Port = NewAxis.Mask;
                    _GZ2Inp.Axis_Port = NewAxis.Mask;
                    _GZ2Alm.Axis_Port = NewAxis.Mask;
                    _GZ2MtrOn.Axis_Port = NewAxis.Mask;
                    _GZ2AlmClr.Axis_Port = NewAxis.Mask;
                    break;
            }
        }

        public static bool CheckReadyStop()
        {
            switch (GDefine.Status)
            {
                case EStatus.Ready: return true;
                case EStatus.Stop: return true;
                case EStatus.EndStop: return true;
                default:
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.GANTRY_NOT_READY, "", EMcState.Error, EMsgBtn.smbOK, true);
                        return false;
                    }
            }
        }

        internal static void LoadMotorPara()
        {
            string Filename = GDefine.ConfigPath + "\\Gantry.Config.ini";

            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(Filename);

            HomeSequence = (EHomeSequence)IniFile.ReadInteger("Options", "HomeSequence", (int)EHomeSequence.ZXY);
            ZHeightForSlowSpeed = IniFile.ReadDouble("Options", "ZHeightForSlowSpeed", -100);

            GXAxis.Para.ReadInifile(Filename, GXAxis.Name);
            GYAxis.Para.ReadInifile(Filename, GYAxis.Name);
            GZAxis.Para.ReadInifile(Filename, GZAxis.Name);
            GX2Axis.Para.ReadInifile(Filename, GX2Axis.Name);
            GY2Axis.Para.ReadInifile(Filename, GY2Axis.Name);
            GZ2Axis.Para.ReadInifile(Filename, GZ2Axis.Name);
            SZAxis.Para.ReadInifile(Filename, SZAxis.Name);

            if (SZAxis.Para.FastV == 1) {
                SZAxis.Device = Device_0;
                SZAxis.Para.Unit.Resolution = 0.0005;
                SZAxis.Para.FastV = 2; }

            if (!File.Exists(Filename))
            {
                CControl2.TAxis DefAxis = new CControl2.TAxis(Device_0, 0x01, "", "");

                DefAxis.Para.Multiplier = 100;
                DefAxis.Para.Unit.Resolution = 0.001;
                DefAxis.Para.SwLimit.PosP = 1000;
                DefAxis.Para.SwLimit.PosN = -1000;
                DefAxis.Para.Jog.SlowV = 1;
                DefAxis.Para.Jog.MedV = 20;
                DefAxis.Para.Jog.FastV = 50;
                DefAxis.Para.Home.SlowV = 1;
                DefAxis.Para.Home.FastV = 25;
                DefAxis.Para.Home.Timeout = 15000;
                DefAxis.Para.Accel = 500;
                DefAxis.Para.StartV = 10;
                DefAxis.Para.SlowV = 50;
                DefAxis.Para.SlowV = 100;
                DefAxis.Para.FastV = 300;

                GXAxis.Para = DefAxis.Para;
                GYAxis.Para = DefAxis.Para;
                GZAxis.Para = DefAxis.Para;
                GX2Axis.Para = DefAxis.Para;
                GY2Axis.Para = DefAxis.Para;
                GZ2Axis.Para = DefAxis.Para;
                SZAxis.Para = DefAxis.Para;
            }
        }
        internal static void SaveMotorPara()
        {
            string Filename = GDefine.ConfigPath + "\\Gantry.Config.ini";

            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(Filename);

            IniFile.WriteInteger("Options", "HomeSequence", (int)TaskGantry.HomeSequence);
            IniFile.WriteDouble("Options", "ZHeightForSlowSpeed", ZHeightForSlowSpeed);

            if (!File.Exists(Filename))
            {
                LoadMotorPara();
            }

            GXAxis.Para.WriteInifile(Filename, GXAxis.Name);
            GYAxis.Para.WriteInifile(Filename, GYAxis.Name);
            GZAxis.Para.WriteInifile(Filename, GZAxis.Name);
            GX2Axis.Para.WriteInifile(Filename, GX2Axis.Name);
            GY2Axis.Para.WriteInifile(Filename, GY2Axis.Name);
            GZ2Axis.Para.WriteInifile(Filename, GZ2Axis.Name);
            SZAxis.Para.WriteInifile(Filename, SZAxis.Name);
        }

        internal static bool UseConfigFile = false;
        internal static bool OpenBoard()
        {
            if (Device_0.Type != CControl2.EDeviceType.NONE)
            {
                #region
                try
                {
                    CommonControl.OpenBoard(Device_0);
                }
                catch (Exception Ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.GANTRY_OPEN_BOARD1_FAIL, Ex.Message);
                    return false;
                }

                try
                {
                    CommonControl.P1245.Reset(Device_0.ID);
                }
                catch (Exception Ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.GANTRY_INIT_BOARD1_FAIL, Ex.Message);
                    return false;
                }

                //string cfgFile = GDefine.AppPath + "\\Device_0.cfg";
                if (File.Exists(GDefine.ConfigFile))
                {
                    UseConfigFile = true;
                    if (!CommonControl.P1245.LoadConfigFile(0, GDefine.ConfigFile)) return false;
                }
                #endregion
            }
            if (Device_1.Type != CControl2.EDeviceType.NONE)
            {
                #region
                try
                {
                    CommonControl.OpenBoard(Device_1);
                }
                catch (Exception Ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.GANTRY_OPEN_BOARD2_FAIL, Ex.Message);
                    return false;
                }

                try
                {
                    CommonControl.P1245.Reset(Device_1.ID);
                }
                catch (Exception Ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.GANTRY_INIT_BOARD2_FAIL, Ex.Message);
                    return false;
                }

                if (UseConfigFile)
                {
                    //string cfgFile = GDefine.AppPath + "\\Device_1.cfg";
                    if (!File.Exists(GDefine.ConfigFile2))
                    {
                        MessageBox.Show("Device_2 Config File not found.");
                        return false;
                    }
                    if (!CommonControl.P1245.LoadConfigFile(1, GDefine.ConfigFile2)) return false;
                }
                #endregion
            }

            if (!UpdateAxis(GXAxis)) return false;
            if (!UpdateAxis(GYAxis)) return false;
            if (!UpdateAxis(GZAxis)) return false;

            switch (GDefine.GantryConfig)
            {
                case GDefine.EGantryConfig.XY_ZX2Y2_Z2:
                    #region
                    if (!UpdateAxis(GX2Axis)) return false;
                    if (!UpdateAxis(GY2Axis)) return false;
                    if (!UpdateAxis(GZ2Axis)) return false;
                    break;
                #endregion
                case GDefine.EGantryConfig.XY_RX_Z:
                case GDefine.EGantryConfig.XY_RXRY_Z:
                case GDefine.EGantryConfig.XYZ_X4Y4Z4:
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show("Gantry Config " + GDefine.GantryConfig.ToString() + " not supported.");
                    return false;
            }

            //  Reset IOs
            DispATrig = false;
            DispBTrig = false;
            BPress1 = false;
            BPress2 = false;
            DispPortC1 = false;

            return true;
        }
        internal static bool CloseBoard()
        {
            CommonControl.CloseBoard(Device_0);//GXAxis.Device);

            if (Device_1.Type != CControl2.EDeviceType.NONE)
                CommonControl.CloseBoard(Device_1);

            return true;
        }

        internal static bool BoardOpened(CControl2.TDevice Device)
        {
            try
            {
                CommonControl.CheckBoardOpened(Device);
            }
            catch (Exception Ex)
            {
                if (Device.ID == 0)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.GANTRY_BOARD1_NOT_OPENED, Ex.Message);
                }
                if (Device.ID == 1)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.GANTRY_BOARD2_NOT_OPENED, Ex.Message);
                }
                return false;
            }
            return true;
        }

        internal static bool UpdateAxis(CControl2.TAxis Axis)
        {
            string EMsg = Axis.Name + "UpdateAxis";
            try
            {
                CommonControl.UpdateAxis(Axis);

                //if (!UseConfigFile)
                //    CommonControl.UpdateAxis(Axis);
                //else
                //{
                //    Axis.Para.HwInvert = true;
                //    CommonControl.P1245.SetSLmtN(Axis, Axis.Para.SwLimit.PosN);
                //    CommonControl.P1245.SetSLmtP(Axis, Axis.Para.SwLimit.PosP);
                //}
                //if (UseConfigFile) Axis.Para.HwInvert = true;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }

        #region Motor IO
        internal static bool MotorAlarm(CControl2.TAxis Axis, ref CControl2.TInput Alm, bool Prompt)
        {
            if (!RefreshDI(ref Alm)) return true;

            if (Axis.Para.MotorAlarmType == CControl2.EMotorAlarmType.None)
            {
                return false;
            }
            if ((Axis.Para.MotorAlarmType == CControl2.EMotorAlarmType.NC && !Alm.Status) ||
                (Axis.Para.MotorAlarmType == CControl2.EMotorAlarmType.NO) && Alm.Status)
            {
                if (Prompt)
                {
                    GDefine.Status = EStatus.ErrorInit;
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.MOTOR_ALARM, Axis.Name);
                }
                return true;
            }
            return false;
        }
        internal static bool MotorAlarm(CControl2.TAxis Axis, bool Prompt)
        {
            if (Axis.Name == "GX") return MotorAlarm(Axis, ref _GXAlm, Prompt);
            if (Axis.Name == "GY") return MotorAlarm(Axis, ref _GYAlm, Prompt);
            if (Axis.Name == "GZ") return MotorAlarm(Axis, ref _GZAlm, Prompt);
            if (Axis.Name == "GX2") return MotorAlarm(Axis, ref _GX2Alm, Prompt);
            if (Axis.Name == "GY2") return MotorAlarm(Axis, ref _GY2Alm, Prompt);
            if (Axis.Name == "GZ2") return MotorAlarm(Axis, ref _GZ2Alm, Prompt);
            if (Axis.Name == "GZ3") return MotorAlarm(Axis, ref _GZ3Alm, Prompt);
            if (Axis.Name == "GZ4") return MotorAlarm(Axis, ref _GZ4Alm, Prompt);
            if (Axis.Name == "RX") return MotorAlarm(Axis, ref _RXAlm, Prompt);
            if (Axis.Name == "RY") return MotorAlarm(Axis, ref _RYAlm, Prompt);
            return true;
        }
        internal static bool MotorAlarmPrompt(CControl2.TAxis Axis)
        {
            return MotorAlarm(Axis, true);
        }


        internal static bool AxisErrorPrompt(CControl2.TAxis Axis)
        {
            string EMsg = Axis.Name + " AxisError";
            try
            {
                bool Error = false;
                CommonControl.AxisError(Axis, ref Error);

                if (Error)
                {
                    GDefine.Status = EStatus.ErrorInit;
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.AXIS_ERR, Axis.Name);
                    return true;
                }
                return false;
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return true;
            }
        }

        internal static bool ClearAxisError(CControl2.TAxis Axis)
        {
            string EMsg = Axis.Name + " Clear Axis Error";
            try
            {
                CommonControl.ClearAxisError(Axis);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }

        internal static bool MotorOnOff(CControl2.TAxis Axis, ref CControl2.TOutput MtrOn, bool On)
        {
            if (Axis.Para.InvertMtrOn)
            {
                return SetOutput(ref MtrOn, !On);
            }
            else
            {
                return SetOutput(ref MtrOn, On);
            }
        }
        internal static bool MotorOn(CControl2.TAxis Axis, bool On)
        {
            switch (Axis.Name)
            {
                default:
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.INVALID_AXIS, Axis.Name);
                    return false;
                case "GX": return MotorOnOff(Axis, ref _GXMtrOn, On);
                case "GY": return MotorOnOff(Axis, ref _GYMtrOn, On);
                case "GZ": return MotorOnOff(Axis, ref _GZMtrOn, On);
                case "GX2": return MotorOnOff(Axis, ref _GX2MtrOn, On);
                case "GY2": return MotorOnOff(Axis, ref _GY2MtrOn, On);
                case "GZ2": return MotorOnOff(Axis, ref _GZ2MtrOn, On);
                case "GZ3": return MotorOnOff(Axis, ref _GZ3MtrOn, On);
                case "GZ4": return MotorOnOff(Axis, ref _GZ4MtrOn, On);
                case "RX": return MotorOnOff(Axis, ref _RXMtrOn, On);
                case "RY": return MotorOnOff(Axis, ref _RYMtrOn, On);
            }
        }

        internal static bool AlmClear(ref CControl2.TOutput AlmClr, bool On)
        {
            return SetOutput(ref AlmClr, On);
        }
        internal static bool AlmClear(CControl2.TAxis Axis, bool On)
        {
            switch (Axis.Name)
            {
                default:
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.INVALID_AXIS, Axis.Name);
                    return false;
                case "GX": return AlmClear(ref _GXAlmClr, On);
                case "GY": return AlmClear(ref _GYAlmClr, On);
                case "GZ": return AlmClear(ref _GZAlmClr, On);
                case "GX2": return AlmClear(ref _GX2AlmClr, On);
                case "GY2": return AlmClear(ref _GY2AlmClr, On);
                case "GZ2": return AlmClear(ref _GZ2AlmClr, On);
                case "GZ3": return AlmClear(ref _GZ3AlmClr, On);
                case "GZ4": return AlmClear(ref _GZ4AlmClr, On);
                case "RX": return AlmClear(ref _RXAlmClr, On);
                case "RY": return AlmClear(ref _RYAlmClr, On);
            }
        }
        #endregion

        #region Motion Input
        internal static bool RefreshDI(ref CControl2.TInput DI)
        {
            try
            {
                CommonControl.RefreshDI(ref DI);
                return true;
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_IO_EX_ERR, Ex.Message);
                return false;
            }
        }
        internal static bool GetInput(ref CControl2.TInput _Sens)
        {
            try
            {
                CommonControl.RefreshDI(ref _Sens);
                return _Sens.Status;
            }
            catch
            {
                return false;
            }
        }
        internal static bool SensHome(CControl2.TAxis Axis)
        {
            switch (Axis.Name)
            {
                default:
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.INVALID_AXIS, "SenHome " + Axis.Name);
                    return false;
                case "GX": return GetInput(ref _SensGXHome);
                case "GY": return GetInput(ref _SensGYHome);
                case "GZ": return GetInput(ref _SensGZHome);
                case "GX2": return GetInput(ref _SensGX2Home);
                case "GY2": return GetInput(ref _SensGY2Home);
                case "GZ2": return GetInput(ref _SensGZ2Home);
                case "GZ3": return GetInput(ref _SensGZ3Home);
                case "GZ4": return GetInput(ref _SensGZ4Home);
                case "RX": return GetInput(ref _SensRXHome);
                case "RY": return GetInput(ref _SensRYHome);
            }
        }
    
        #region SensSLmt
        internal static bool SLmtP(CControl2.TAxis Axis)
        {
            CControl2.TInput SLmt = new CControl2.TInput();
            SLmt.Device.ID = Axis.Device.ID;
            SLmt.Device.Type = Axis.Device.Type;
            SLmt.Axis_Port = Axis.Mask;
            SLmt.Mask = 0x0100;

            //if (Axis.Para.InvertPulse)
            //{
            //    SLmt.Mask = 0x0200;
            //}
            
            return GetInput(ref SLmt);
        }
        internal static bool SLmtN(CControl2.TAxis Axis)
        {
            CControl2.TInput SLmt = new CControl2.TInput();
            SLmt.Device.ID = Axis.Device.ID;
            SLmt.Device.Type = Axis.Device.Type;
            SLmt.Axis_Port = Axis.Mask;
            SLmt.Mask = 0x0200;

            //if (Axis.Para.InvertPulse)
            //{
            //    SLmt.Mask = 0x0100;
            //}

            return GetInput(ref SLmt);
        }
        #endregion

        #endregion

        #region Motion Output
        internal static bool SetOutput(ref CControl2.TOutput Output, bool On)
        {
            try
            {
                if (On)
                    CommonControl.SetDO(ref Output, CControl2.EOutputStatus.Hi);
                else
                    CommonControl.SetDO(ref Output, CControl2.EOutputStatus.Lo);
                return true;
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_IO_EX_ERR, Ex.Message);
                return false;
            }
        }
        #endregion

        #region Get/Set Motor Position
        public static double LogicalPos(CControl2.TAxis Axis)
        {
            double Value = 0;
            try
            {
                CommonControl.GetLPos(Axis, ref Value);
            }
            catch { }
            return Value;
        }
        public static bool LogicalPos(CControl2.TAxis Axis, double Value)
        {
            string EMsg = "SetLogicalPos";
            try
            {
                CommonControl.SetLPos(Axis, Value);
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        public static double GXPos()
        {
            return LogicalPos(GXAxis);
        }
        public static double GYPos()
        {
            return LogicalPos(GYAxis);
        }
        public static double GZPos()
        {
            return LogicalPos(GZAxis);
        }
        public static double GUPos()
        {
            //return LogicalPos(GUAxis);
            return 0;
        }
        public static double GX2Pos()
        {
            return LogicalPos(GX2Axis);
        }
        public static double GY2Pos()
        {
            return LogicalPos(GY2Axis);
        }
        public static double GZ2Pos()
        {
            return LogicalPos(GZ2Axis);
        }

        public static double EncoderPos(CControl2.TAxis Axis)
        {
            double Value = 0;
            try
            {
                CommonControl.GetRPos(Axis, ref Value);
            }
            catch { }
            return Value;
        }
        public static bool EncoderPos(CControl2.TAxis Axis, double Value)
        {
            string EMsg = "SetEncoderPos";
            try
            {
                CommonControl.SetRPos(Axis, Value);
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        public static double GXRPos()
        {
            return EncoderPos(GXAxis);
        }
        public static double GYRPos()
        {
            return EncoderPos(GYAxis);
        }
        public static double GZRPos()
        {
            return EncoderPos(GZAxis);
        }
        public static double GURPos()
        {
            //return EncoderPos(GUAxis);
            return 0;
        }
        public static double GX2RPos()
        {
            return EncoderPos(GX2Axis);
        }
        public static double GY2RPos()
        {
            return EncoderPos(GY2Axis);
        }
        public static double GZ2RPos()
        {
            return EncoderPos(GZ2Axis);
        }

        public static void GXPos(double Pos)
        {
            CommonControl.SetLPos(GXAxis, Pos);
        }
        public static void GYPos(double Pos)
        {
            CommonControl.SetLPos(GYAxis, Pos);
        }
        #endregion

        private static int HomeTimeout(CControl2.TAxis Axis, int Timeout, string Msg)//0 - None, 1 - Stop, 2 - Retry
        {
            if (GDefine.GetTickCount() >= Timeout)
            {
                if (!ForceStop(Axis))
                    return 1;

                Msg MsgBox = new Msg();
                EMsgRes Res = MsgBox.Show(ErrCode.HOME_TIMEOUT, Axis.Name, EMcState.Error, EMsgBtn.smbRetry_Cancel, false);
                switch (Res)
                {
                    case EMsgRes.smrRetry: return 2;
                    default:
                    case EMsgRes.smrCancel: return 1;
                }
            }

            return 0;
        }
        private static bool HomeDelay(int msdelay)
        {
            if (msdelay <= 0) { return true; }
            int t = GDefine.GetTickCount() + msdelay;

            while (true)
            {
                if (GDefine.GetTickCount() >= t) { break; }
                Thread.Sleep(1);
            }
            return true;
        }
        public static bool Home(CControl2.TAxis Axis, ref CControl2.TInput _SensHome, ref CControl2.TInput _SensLmtP, ref CControl2.TInput _SensLmtN, ref CControl2.TInput _Alm, ref CControl2.TOutput _MtrOn, ref CControl2.TOutput _AlmClr)
        {
            try
            {
                TaskVision.PtGrey_CamStop();
            }
            catch { }

            try
            {
                //if (!TaskVision.frmGenImageView.Visible)
                //{
                //    //TaskVision.frmGenImageView.Show();
                //    //TaskVision.frmGenImageView.Hide();
                //}
            }
            catch { }

            bool PositiveDir = true;
            string EMsg = Axis.Name + " Home Positive";

            if (Axis.Para.Home.Dir == CControl2.EHomeDir.N)
            {
                PositiveDir = false;
                EMsg = Axis.Name + " Home Negative";
            }

            try
            {
                CommonControl.DisableSLimit(Axis);
            }
            catch { }

            #region AlmClr
            if (Axis.Para.MotorAlarmType != CControl2.EMotorAlarmType.None)
            {
                if (MotorAlarm(Axis, false))
                {
                    if (!MotorOnOff(Axis, ref _MtrOn, false)) goto _End;
                    HomeDelay(250);
                    AlmClear(ref _AlmClr, true);
                    HomeDelay(500);
                    AlmClear(ref _AlmClr, false);
                }
            }
            #endregion

            if (!MotorOnOff(Axis, ref _MtrOn, true)) goto _End;
            HomeDelay(50);

            if (!ClearAxisError(Axis)) goto _End;
            HomeDelay(50);

            if (MotorAlarmPrompt(Axis)) goto _End;
            if (AxisErrorPrompt(Axis)) goto _End;

            _Retry:
            int t = GDefine.GetTickCount() + (int)Axis.Para.Home.Timeout;

            if (!GetInput(ref _SensHome))
            #region Search Home
            {
                if (!SetMotionParam(Axis, 1, Axis.Para.Home.FastV, /*Axis.Para.Accel*/500)) goto _End;

                if (PositiveDir)
                    CommonControl.JogP(Axis);
                else
                    CommonControl.JogN(Axis);

                if (AxisErrorPrompt(Axis))
                {
                    if (!ForceStop(Axis)) goto _End;
                    goto _End;
                }
                while (!GetInput(ref _SensHome))
                {
                    Thread.Sleep(1);
                    //if (HomeTimeout(Axis, t, EMsg)) goto _End;
                    switch (HomeTimeout(Axis, t, EMsg))
                    {
                        case 0: break;
                        case 1: goto _End;
                        case 2: goto _Retry;
                    }
                    if (MotorAlarmPrompt(Axis)) goto _End;
                }
                if (!DecelStop(Axis)) goto _End;
                if (!AxisWait(Axis)) goto _End;
            }
            #endregion

            if (GetInput(ref _SensHome))
            #region Clear Home
            {
                if (!SetMotionParam(Axis, 1, Axis.Para.Home.FastV / 2, /*Axis.Para.Accel*/500)) goto _End;
                if (PositiveDir)
                    CommonControl.JogN(Axis);
                else
                    CommonControl.JogP(Axis);

                if (AxisErrorPrompt(Axis))
                {
                    if (!ForceStop(Axis)) goto _End;
                    goto _End;
                }
                while (GetInput(ref _SensHome))
                {
                    Thread.Sleep(1);
                    //if (HomeTimeout(Axis, t, EMsg)) goto _End;
                    switch (HomeTimeout(Axis, t, EMsg))
                    {
                        case 0: break;
                        case 1: goto _End;
                        case 2: goto _Retry;
                    }
                    if (MotorAlarmPrompt(Axis)) goto _End;
                }
                if (!DecelStop(Axis)) goto _End;
                if (!AxisWait(Axis)) goto _End;
            }
            #endregion

            if (!GetInput(ref _SensHome))
            #region Touch Home
            {
                //if (!SetMotionParam(Axis, 1, Axis.Para.Home.SlowV, Axis.Para.Accel)) goto _End;
                if (!SetMotionParam(Axis, 0.5, 0.5, 1)) goto _End;
                if (PositiveDir)
                    CommonControl.JogP(Axis);
                else
                    CommonControl.JogN(Axis);
                if (AxisErrorPrompt(Axis))
                {
                    if (!ForceStop(Axis)) goto _End;
                    goto _End;
                }

                while (true)
                {
                    if (GetInput(ref _SensHome))
                    {
                        if (!ForceStop(Axis)) goto _End;
                        break;
                    }
                    Thread.Sleep(0);
                    //if (HomeTimeout(Axis, t, EMsg)) goto _End;
                    switch (HomeTimeout(Axis, t, EMsg))
                    {
                        case 0: break;
                        case 1: goto _End;
                        case 2: goto _Retry;
                    }
                    if (MotorAlarmPrompt(Axis)) goto _End;
                }
                if (!ForceStop(Axis)) goto _End;
                if (!AxisWait(Axis)) goto _End;
            }
            if (!HomeDelay(200)) goto _End;
            #endregion

            if (MotorAlarmPrompt(Axis)) goto _End;
            if (AxisErrorPrompt(Axis)) goto _End;

            #region Set Param
            LogicalPos(Axis, 0);
            EncoderPos(Axis, 0);

            if (!UpdateAxis(Axis)) goto _End;
            SetMotionParamOp(Axis);

            try
            {
                CommonControl.EnableSLimit(Axis);
            }
            catch { }
            #endregion

            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
                TaskVision.PtGrey_CamLive(0);
            return true;

            _End:
            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
                TaskVision.PtGrey_CamLive(0);
            return false;
        }
        public static bool GXHome()
        {
            if (UseConfigFile)
            {
                if (!MotorOn(GXAxis, false)) return false;
                HomeDelay(250);
                AlmClear(GXAxis, true);
                HomeDelay(500);
                AlmClear(GXAxis, false);

                if (!MotorOn(GXAxis, true)) return false;
                HomeDelay(50);
                if (!ClearAxisError(GXAxis)) return false;
                HomeDelay(50);

                if (MotorAlarmPrompt(GXAxis)) return false;
                if (AxisErrorPrompt(GXAxis)) return false;

                SetMotionParamEx(GXAxis, GXAxis.Para.Home.SlowV, GXAxis.Para.Home.FastV, GXAxis.Para.Accel);
                try
                {
                    CommonControl.P1245.SoftwareLimitEnable(GXAxis, false);
                    //CommonControl.P1245.Home(GXAxis, CControl2.EHomeMode.MODE8_LmtSearch, GXAxis.Para.Home.Dir);
                    CommonControl.P1245.Home(GXAxis, GXAxis.Para.HomeMode, GXAxis.Para.Home.Dir);
                    AxisWait(GXAxis);
                    CommonControl.P1245.SoftwareLimitEnable(GXAxis, true);
                }
                catch (Exception ex) { throw ex; }

                if (AxisErrorPrompt(GXAxis)) return false;

                return true;
            }
            else
            {
                return Home(GXAxis, ref _SensGXHome, ref _SensGXLmtP, ref _SensGXLmtN, ref _GXAlm, ref _GXMtrOn, ref _GXAlmClr);
            }
        }
        public static bool GYHome()
        {
            if (UseConfigFile)
            {
                if (!MotorOn(GYAxis, false)) return false;
                HomeDelay(250);
                AlmClear(GYAxis, true);
                HomeDelay(500);
                AlmClear(GYAxis, false);

                if (!MotorOn(GYAxis, true)) return false;
                HomeDelay(50);
                if (!ClearAxisError(GYAxis)) return false;
                HomeDelay(50);

                if (MotorAlarmPrompt(GYAxis)) return false;
                if (AxisErrorPrompt(GYAxis)) return false;

                SetMotionParamEx(GYAxis, GYAxis.Para.Home.SlowV, GYAxis.Para.Home.FastV, GYAxis.Para.Accel);
                try
                {
                    CommonControl.P1245.SoftwareLimitEnable(GYAxis, false);
                    //CommonControl.P1245.Home(GYAxis, CControl2.EHomeMode.MODE8_LmtSearch, GYAxis.Para.Home.Dir);
                    CommonControl.P1245.Home(GYAxis, GYAxis.Para.HomeMode, GYAxis.Para.Home.Dir);
                    AxisWait(GYAxis);
                    CommonControl.P1245.SoftwareLimitEnable(GYAxis, true);
                }
                catch (Exception ex) { throw ex; }

                if (MotorAlarmPrompt(GYAxis)) return false;

                return true;
            }
            else
            {
                return Home(GYAxis, ref _SensGYHome, ref _SensGYLmtP, ref _SensGYLmtN, ref _GYAlm, ref _GYMtrOn, ref _GYAlmClr);
            }
        }
        public static bool GZHome()
        {
            if (UseConfigFile)
            {
                if (!MotorOn(GZAxis, false)) return false;
                HomeDelay(250);
                AlmClear(GZAxis, true);
                HomeDelay(500);
                AlmClear(GZAxis, false);

                if (!MotorOn(GZAxis, true)) return false;
                HomeDelay(50);
                if (!ClearAxisError(GZAxis)) return false;
                HomeDelay(50);

                if (MotorAlarmPrompt(GZAxis)) return false;
                if (AxisErrorPrompt(GZAxis)) return false;

                SetMotionParamEx(GZAxis, GZAxis.Para.Home.SlowV, GZAxis.Para.Home.FastV, GZAxis.Para.Accel);
                try
                {
                    CommonControl.P1245.SoftwareLimitEnable(GZAxis, false);
                    //CommonControl.P1245.Home(GZAxis, CControl2.EHomeMode.MODE7_AbsSearch, GZAxis.Para.Home.Dir);
                    CommonControl.P1245.Home(GZAxis, GZAxis.Para.HomeMode, GZAxis.Para.Home.Dir);
                    AxisWait(GZAxis);
                    CommonControl.P1245.SoftwareLimitEnable(GZAxis, true);
                }
                catch (Exception ex) { throw ex; }

                if (MotorAlarmPrompt(GZAxis)) return false;
            }
            else
            {
                bool Res = Home(GZAxis, ref _SensGZHome, ref _SensGZLmtP, ref _SensGZLmtN, ref _GZAlm, ref _GZMtrOn, ref _GZAlmClr);
                if (!Res) return false;
            }

            if (!TaskDisp.TaskMoveAbsGZ(TaskDisp.ZDefPos)) return false;

            return true;
        }
        public static bool GX2Home()
        {
            if (UseConfigFile)
            {
                if (!MotorOn(GX2Axis, false)) return false;
                HomeDelay(250);
                AlmClear(GX2Axis, true);
                HomeDelay(500);
                AlmClear(GX2Axis, false);

                if (!MotorOn(GX2Axis, true)) return false;
                HomeDelay(50);
                if (!ClearAxisError(GX2Axis)) return false;
                HomeDelay(50);

                if (MotorAlarmPrompt(GX2Axis)) return false;
                if (AxisErrorPrompt(GX2Axis)) return false;

                SetMotionParamEx(GX2Axis, GX2Axis.Para.Home.SlowV, GX2Axis.Para.Home.FastV, GX2Axis.Para.Accel);
                try
                {
                    CommonControl.P1245.SoftwareLimitEnable(GX2Axis, false);
                    //CommonControl.P1245.Home(GX2Axis, CControl2.EHomeMode.MODE7_AbsSearch, GX2Axis.Para.Home.Dir);
                    CommonControl.P1245.Home(GX2Axis, GX2Axis.Para.HomeMode, GX2Axis.Para.Home.Dir);
                    AxisWait(GX2Axis);
                    CommonControl.P1245.SoftwareLimitEnable(GX2Axis, true);
                }
                catch (Exception ex) { throw ex; }

                if (MotorAlarmPrompt(GX2Axis)) return false;

                return true;
            }
            else
            {
                return Home(GX2Axis, ref _SensGX2Home, ref _SensGX2LmtP, ref _SensGX2LmtN, ref _GX2Alm, ref _GX2MtrOn, ref _GX2AlmClr);
            }
        }
        public static bool GY2Home()
        {
            if (UseConfigFile)
            {
                if (!MotorOn(GY2Axis, false)) return false;
                HomeDelay(250);
                AlmClear(GY2Axis, true);
                HomeDelay(500);
                AlmClear(GY2Axis, false);

                if (!MotorOn(GY2Axis, true)) return false;
                HomeDelay(50);
                if (!ClearAxisError(GY2Axis)) return false;
                HomeDelay(50);

                if (MotorAlarmPrompt(GY2Axis)) return false;
                if (AxisErrorPrompt(GY2Axis)) return false;

                SetMotionParamEx(GY2Axis, GY2Axis.Para.Home.SlowV, GY2Axis.Para.Home.FastV, GY2Axis.Para.Accel);
                try
                {
                    CommonControl.P1245.SoftwareLimitEnable(GY2Axis, false);
                    //CommonControl.P1245.Home(GY2Axis, CControl2.EHomeMode.MODE7_AbsSearch, GY2Axis.Para.Home.Dir);
                    CommonControl.P1245.Home(GY2Axis, GY2Axis.Para.HomeMode, GY2Axis.Para.Home.Dir);
                    AxisWait(GY2Axis);
                    CommonControl.P1245.SoftwareLimitEnable(GY2Axis, true);
                }
                catch (Exception ex) { throw ex; }


                if (MotorAlarmPrompt(GY2Axis)) return false;

                return true;
            }
            else
            {
                return Home(GY2Axis, ref _SensGY2Home, ref _SensGY2LmtP, ref _SensGY2LmtN, ref _GY2Alm, ref _GY2MtrOn, ref _GY2AlmClr);
            }
        }
        public static bool GZ2Home()
        {
            if (UseConfigFile)
            {
                if (!MotorOn(GZ2Axis, false)) return false;
                HomeDelay(250);
                AlmClear(GZ2Axis, true);
                HomeDelay(500);
                AlmClear(GZ2Axis, false);

                if (!MotorOn(GZ2Axis, true)) return false;
                HomeDelay(50);
                if (!ClearAxisError(GZ2Axis)) return false;
                HomeDelay(50);

                if (MotorAlarmPrompt(GZ2Axis)) return false;
                if (AxisErrorPrompt(GZ2Axis)) return false;

                SetMotionParamEx(GZ2Axis, GZ2Axis.Para.Home.SlowV, GZ2Axis.Para.Home.FastV, GZ2Axis.Para.Accel);
                try
                {
                    CommonControl.P1245.SoftwareLimitEnable(GZ2Axis, false);
                    //CommonControl.P1245.Home(GZ2Axis, CControl2.EHomeMode.MODE7_AbsSearch, GZ2Axis.Para.Home.Dir);
                    CommonControl.P1245.Home(GZ2Axis, GZ2Axis.Para.HomeMode, GZ2Axis.Para.Home.Dir);
                    AxisWait(GZ2Axis);
                    CommonControl.P1245.SoftwareLimitEnable(GZAxis, true);
                }
                catch (Exception ex) { throw ex; }

                if (MotorAlarmPrompt(GZ2Axis)) return false;
            }
            else
            {
                bool Res = Home(GZ2Axis, ref _SensGZ2Home, ref _SensGZ2LmtP, ref _SensGZ2LmtN, ref _GZ2Alm, ref _GZ2MtrOn, ref _GZ2AlmClr);
                if (!Res) return false;
            }

            if (!TaskDisp.TaskMoveAbsGZ2(TaskDisp.ZDefPos)) return false;
            return true;
        }

        public static bool Home()
        {
            GDefine.Status = EStatus.ErrorInit;

            if (GDefine.SysOffline) goto _End;
            DispProg.Script[0].IsBusy = false;
            DispProg.ResetMaps();

            if (!UseConfigFile)
            {
                switch (GDefine.GantryConfig)
                {
                    case GDefine.EGantryConfig.XY_RX_Z:
                    case GDefine.EGantryConfig.XY_RXRY_Z:
                    case GDefine.EGantryConfig.XYZ_X4Y4Z4:
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show("Gantry Config " + GDefine.GantryConfig.ToString() + " not supported.");
                        goto _Error;
                }

                #region Update Axis
                if (!BoardOpened(GXAxis.Device)) goto _Error;

                CommonControl.P1245.MotorAlarmEnable(GUAxis, false);
                CommonControl.P1245.SoftwareLimitEnable(GUAxis, false);
                if (!ClearAxisError(GUAxis)) goto _End;

                if (!ClearAxisError(GXAxis)) goto _End;
                if (!ClearAxisError(GYAxis)) goto _End;
                if (!ClearAxisError(GZAxis)) goto _End;

                //CommonControl.P1245.MotorAlarmEnable(GUAxis, false);
                //if (!ClearAxisError(GUAxis)) goto _End;

                if (!UpdateAxis(GXAxis)) goto _Error;
                if (!UpdateAxis(GYAxis)) goto _Error;
                if (!UpdateAxis(GZAxis)) goto _Error;

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!BoardOpened(GX2Axis.Device)) goto _Error;
                    if (!UpdateAxis(GX2Axis)) goto _Error;
                    if (!UpdateAxis(GY2Axis)) goto _Error;
                    if (!UpdateAxis(GZ2Axis)) goto _Error;
                }
                #endregion

                if (TaskDisp.Option_EnableChuckVac)
                {
                    ChuckVac = false;
                    Thread.Sleep(100);
                }

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!GZ2Home()) { goto _Error; }
                }

                if (!GZHome()) { goto _Error; }

                if (HomeSequence == EHomeSequence.ZYX)
                {
                    if (!GYHome()) { goto _Error; }
                    if (!GXHome()) { goto _Error; }
                }
                else//EHomeSequence.ZXY
                {
                    if (!GXHome()) { goto _Error; }
                    if (!GYHome()) { goto _Error; }
                }

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (HomeSequence == EHomeSequence.ZYX)
                    {
                        if (!GY2Home()) { goto _Error; }
                        if (!GX2Home()) { goto _Error; }
                    }
                    else//EHomeSequence.ZXY
                    {
                        if (!GX2Home()) { goto _Error; }
                        if (!GY2Home()) { goto _Error; }
                    }
                }

                DispProg.Script[0].Init();

                if (DispProg.Pump_Type == TaskDisp.EPumpType.PP || DispProg.Pump_Type == TaskDisp.EPumpType.PP2D || DispProg.Pump_Type == TaskDisp.EPumpType.PPD)
                {
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.DISPCTRL_INIT, EMcState.Notice, EMsgBtn.smbOK_Cancel, false);

                    if (MsgRes == EMsgRes.smrOK)
                    {
                        bool b_HeadA = true;
                        bool b_HeadB = (DispProg.Head_Operation == TaskDisp.EHeadOperation.Sync);

                        if (!TaskDisp.DoInitPP(b_HeadA, b_HeadB)) goto _Error;
                        Thread.Sleep(50);
                        if (!TaskDisp.CtrlWaitReady(b_HeadA, b_HeadB)) goto _Error;
                    }
                }
            }
            else//Hardware home, Use config file
            {
                if (!BoardOpened(GXAxis.Device)) goto _Error;

                if (!File.Exists(GDefine.ConfigFile))
                {
                    MessageBox.Show(GDefine.ConfigFile + " File not found.");
                    return false;
                }
                if (!CommonControl.P1245.LoadConfigFile(0, GDefine.ConfigFile)) return false;

                #region Update Axis
                if (!BoardOpened(GXAxis.Device)) goto _Error;

                CommonControl.P1245.MotorAlarmEnable(GUAxis, false);
                CommonControl.P1245.SoftwareLimitEnable(GUAxis, false);
                if (!ClearAxisError(GUAxis)) goto _End;

                if (!UpdateAxis(GXAxis)) goto _Error;
                if (!UpdateAxis(GYAxis)) goto _Error;
                if (!UpdateAxis(GZAxis)) goto _Error;

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!BoardOpened(GX2Axis.Device)) goto _Error;
                    if (!UpdateAxis(GX2Axis)) goto _Error;
                    if (!UpdateAxis(GY2Axis)) goto _Error;
                    if (!UpdateAxis(GZ2Axis)) goto _Error;
                }
                #endregion

                if (TaskDisp.Option_EnableChuckVac)
                {
                    ChuckVac = false;
                    Thread.Sleep(100);
                }

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!GZ2Home()) { goto _Error; }
                }

                if (!GZHome()) { goto _Error; }

                if (HomeSequence == EHomeSequence.ZYX)
                {
                    if (!GYHome()) { goto _Error; }
                    if (!GXHome()) { goto _Error; }
                }
                else//EHomeSequence.ZXY
                {
                    if (!GXHome()) { goto _Error; }
                    if (!GYHome()) { goto _Error; }
                }

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (HomeSequence == EHomeSequence.ZYX)
                    {
                        if (!GY2Home()) { goto _Error; }
                        if (!GX2Home()) { goto _Error; }
                    }
                    else//EHomeSequence.ZXY
                    {
                        if (!GX2Home()) { goto _Error; }
                        if (!GY2Home()) { goto _Error; }
                    }
                }

                DispProg.Script[0].Init();

                if (DispProg.Pump_Type == TaskDisp.EPumpType.PP || DispProg.Pump_Type == TaskDisp.EPumpType.PP2D || DispProg.Pump_Type == TaskDisp.EPumpType.PPD)
                {
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.DISPCTRL_INIT, EMcState.Notice, EMsgBtn.smbOK_Cancel, false);

                    if (MsgRes == EMsgRes.smrOK)
                    {
                        bool b_HeadA = true;
                        bool b_HeadB = (DispProg.Head_Operation == TaskDisp.EHeadOperation.Sync);

                        if (!TaskDisp.DoInitPP(b_HeadA, b_HeadB)) goto _Error;
                        Thread.Sleep(50);
                        if (!TaskDisp.CtrlWaitReady(b_HeadA, b_HeadB)) goto _Error;
                    }
                }
            }
        _End:
            GDefine.Status = EStatus.Ready;
            return true;

        _Error:
            GDefine.Status = EStatus.ErrorInit;
            return false;
        }

        internal static bool GetWorkArea(ref double XM, ref double XP, ref double YM, ref double YP)
        {
            if (GXAxis.Para.SwLimit.PosN == -1000 ||
                GXAxis.Para.SwLimit.PosP == 1000 ||
                GYAxis.Para.SwLimit.PosN == -1000 ||
                GYAxis.Para.SwLimit.PosP == 1000) return false;

            XM = GXAxis.Para.SwLimit.PosN;
            XP = GXAxis.Para.SwLimit.PosP;
            YM = GYAxis.Para.SwLimit.PosN;
            YP = GYAxis.Para.SwLimit.PosP;

            return true;
        }

        internal static bool SetMotionParam(CControl2.TAxis Axis, double StartV, double DriveV, double Accel)
        {
            string EMsg = Axis.Name + " SetMotionParam";
            if (GDefine.SysOffline) { return true; }

            try
            {
                double Min = 0;
                double Max = 0;
                CommonControl.GetMotorSpeedRange(Axis, ref Min, ref Max);
                StartV = Math.Max(StartV, Min);

                CommonControl.GetMotorSpeedRange(Axis, ref Min, ref Max);
                DriveV = Math.Max(DriveV, Min);

                CommonControl.GetMotorAccelRange(Axis, ref Min, ref Max);
                Accel = Math.Max(Accel, Min);

                CommonControl.SetMotionParam(Axis, StartV, DriveV, Accel);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        internal static bool SetMotionParam(CControl2.TAxis Axis)
        {
            string EMsg = Axis.Name + " SetMotionParam";
            if (GDefine.SysOffline) { return true; }

            try
            {
                double Min = 0;
                double Max = 0;
                CommonControl.GetMotorSpeedRange(Axis, ref Min, ref Max);
                double StartV = Math.Max(TaskGantry.GZ2Axis.Para.StartV, Min);

                CommonControl.GetMotorSpeedRange(Axis, ref Min, ref Max);
                double DriveV = Math.Max(TaskGantry.GZ2Axis.Para.FastV, Min);

                CommonControl.GetMotorAccelRange(Axis, ref Min, ref Max);
                double Accel = Math.Max(TaskGantry.GZ2Axis.Para.Accel, Min);

                CommonControl.SetMotionParam(Axis, StartV, DriveV, Accel);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }

        internal static bool MovePtpAbs(CControl2.TAxis Axis, double Pos)
        {
            string EMsg = "MovePtp";
            DispProg.Idle.Reset();

            if (GDefine.SysOffline) { return true; }

            if (MotorAlarmPrompt(Axis)) return false;
            if (AxisErrorPrompt(Axis)) return false;

            try
            {
                CommonControl.MovePtpAbs1(Axis, Pos);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                if (Axis.Device.ID == 0 || Axis.Device.ID == 1)
                {
                    Msg MsgBox = new Msg();
                    if (Axis.Name == "GX") MsgBox.Show(ErrCode.MOVE_PTP_ABS_ERR, $"{ Axis.Name} {Ex.Message.ToString()}");
                }
                return false;
            }
            return true;
        }
        internal static bool MovePtpRel(CControl2.TAxis Axis, double Pos)
        {
            string EMsg = "MoveRel";
            DispProg.Idle.Reset();

            if (GDefine.SysOffline) { return true; }

            if (MotorAlarmPrompt(Axis)) return false;
            if (AxisErrorPrompt(Axis)) return false;

            try
            {
                CommonControl.MovePtpRel1(Axis, Pos);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.MOVE_PTP_REL_ERR, $"{Axis.Name} {Ex.Message}");
                return false;
            }
            return true;
        }
        internal static bool MoveLineAbs(CControl2.TAxis Axis1, CControl2.TAxis Axis2, double Pos1, double Pos2)
        {
            string EMsg = "MovePtp";
            DispProg.Idle.Reset();

            if (GDefine.SysOffline) { return true; }

            if (MotorAlarmPrompt(Axis1)) return false;
            if (MotorAlarmPrompt(Axis2)) return false;
            if (AxisErrorPrompt(Axis1)) return false;
            if (AxisErrorPrompt(Axis2)) return false;

            try
            {
                CommonControl.MoveLineAbs2(Axis1, Axis2, Pos1, Pos2);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOVE_LINE_ABS2_ERR, Ex.Message);
                return false;
            }
            return true;
        }
        internal static bool MoveArcCenterEndAbs(CControl2.TAxis Axis1, CControl2.TAxis Axis2, bool CW, double Center1, double Center2, double End1, double End2)
        {
            string EMsg = "MoveCenterEnd";
            DispProg.Idle.Reset();

            if (GDefine.SysOffline) { return true; }

            if (MotorAlarmPrompt(Axis1)) return false;
            if (MotorAlarmPrompt(Axis2)) return false;
            if (AxisErrorPrompt(Axis1)) return false;
            if (AxisErrorPrompt(Axis2)) return false;

            try
            {
                bool Dir_CW = CW;
                //if (TaskGantry.GXAxis.Para.InvertPulse) Dir_CW = !Dir_CW;
                //if (TaskGantry.GYAxis.Para.InvertPulse) Dir_CW = !Dir_CW;
                CommonControl.MoveArcCenterEndAbs(Axis1, Axis2, Dir_CW, Center1, Center2, End1, End2);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOVE_ARC_CENTER_END_ABS_ERR, Ex.Message);
                return false;
            }
            return true;
        }
        internal static bool AxisBusy(CControl2.TAxis Axis)
        {
            string EMsg = Axis.Name + " AxisBusy";
            if (GDefine.SysOffline) { return true; }

            if (MotorAlarmPrompt(Axis)) return false;
            if (AxisErrorPrompt(Axis)) return false;

            try
            {
                bool Busy = false;
                CommonControl.AxisBusy(Axis, ref Busy);
                return Busy;
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
        }
        internal static bool AxesBusy(CControl2.TAxis Axis1, CControl2.TAxis Axis2)
        {
            string EMsg = Axis1.Name + Axis2.Name + " AxesBusy";
            if (GDefine.SysOffline) { return true; }

            if (MotorAlarmPrompt(Axis1)) return false;
            if (AxisErrorPrompt(Axis1)) return false;
            if (MotorAlarmPrompt(Axis2)) return false;
            if (AxisErrorPrompt(Axis2)) return false;

            try
            {
                bool Busy = false;
                CommonControl.AxesBusy(Axis1, Axis2, ref Busy);
                return Busy;
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
        }
        internal static bool AxisWait(CControl2.TAxis Axis)
        {
            string EMsg = Axis.Name + " AxisWait";
            if (GDefine.SysOffline) { return true; }

            if (MotorAlarmPrompt(Axis)) return false;
            if (AxisErrorPrompt(Axis)) return false;

            try
            {
                bool Busy = false;
                CommonControl.AxisBusy(Axis, ref Busy);
                while (Busy)
                {
                    CommonControl.AxisBusy(Axis, ref Busy);
                    //Thread.Sleep(0);
                }
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        internal static bool AxesWait(CControl2.TAxis Axis1, CControl2.TAxis Axis2)
        {
            string EMsg = Axis1.Name + Axis2.Name + " AxesWait";
            if (GDefine.SysOffline) { return true; }

            if (MotorAlarmPrompt(Axis1)) return false;
            if (AxisErrorPrompt(Axis1)) return false;
            if (MotorAlarmPrompt(Axis2)) return false;
            if (AxisErrorPrompt(Axis2)) return false;

            try
            {
                bool Busy = false;
                CommonControl.AxesBusy(Axis1, Axis2, ref Busy);
                while (Busy)
                {
                    CommonControl.AxesBusy(Axis1, Axis2, ref Busy);
                    //Thread.Sleep(0);
                }
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        internal static bool ForceStop(CControl2.TAxis Axis)
        {
            string EMsg = Axis.Name + " ForceStop";
            if (GDefine.SysOffline) { return true; }

            try
            {
                CommonControl.ForceStop(Axis);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        internal static bool DecelStop(CControl2.TAxis Axis)
        {
            string EMsg = Axis.Name + " DecelStop";
            if (GDefine.SysOffline) { return true; }

            try
            {
                CommonControl.DecelStop(Axis);
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;

                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Set true motion parameters to Axis
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="StartV"></param>
        /// <param name="DriveV"></param>
        /// <param name="Accel"></param>
        /// <returns></returns>
        public static bool SetMotionParamEx(CControl2.TAxis Axis, double StartV, double DriveV, double Accel)
        {
            if (GDefine.SysOffline) return true;

            if (!SetMotionParam(Axis, StartV, DriveV, Accel)) return false;

            return true;
        }

        internal static void GetOperationSpeed(CControl2.TAxis Axis, ref double StartV, ref double DriveV, ref double Accel)
        {
            switch (GDefine.OperationSpeed)
            {
                case EOperationSpeed.Safe:
                    if ((Axis.Device.ID == TaskGantry.GXAxis.Device.ID && Axis.Mask == TaskGantry.GXAxis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GYAxis.Device.ID && Axis.Mask == TaskGantry.GYAxis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GZAxis.Device.ID && Axis.Mask == TaskGantry.GZAxis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GX2Axis.Device.ID && Axis.Mask == TaskGantry.GX2Axis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GY2Axis.Device.ID && Axis.Mask == TaskGantry.GY2Axis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GZ2Axis.Device.ID && Axis.Mask == TaskGantry.GZ2Axis.Mask))
                    {
                        DriveV = DriveV * GDefine.Operation_SpeedMode_SafeSpeedRatio;
                        if (DriveV < StartV) StartV = DriveV;
                        Accel = Accel * GDefine.Operation_SpeedMode_SafeSpeedRatio;
                    }
                    break;
                case EOperationSpeed.SlowMo:
                    DriveV = DriveV * GDefine.Operation_SpeedMode_SlowSpeedRatio;
                    if (DriveV < StartV) StartV = DriveV;
                    Accel = Accel * GDefine.Operation_SpeedMode_SlowSpeedRatio;
                    break;
                case EOperationSpeed.Normal:
                default:
                    break;
            }
        }
        internal static void GetOperationSpeed(ref double StartV, ref double DriveV, ref double Accel)
        {
            switch (GDefine.OperationSpeed)
            {
                case EOperationSpeed.Safe:
                    DriveV = DriveV * GDefine.Operation_SpeedMode_SafeSpeedRatio;
                    if (DriveV < StartV) StartV = DriveV;
                    Accel = Accel * GDefine.Operation_SpeedMode_SafeSpeedRatio;
                    break;
                case EOperationSpeed.SlowMo:
                    DriveV = DriveV * GDefine.Operation_SpeedMode_SlowSpeedRatio;
                    if (DriveV < StartV) StartV = DriveV;
                    Accel = Accel * GDefine.Operation_SpeedMode_SlowSpeedRatio;
                    break;
                case EOperationSpeed.Normal:
                default:
                    break;
            }
        }
        internal static void GetMotionDataEx(double StartV, double DriveV, double Accel, double Dist, ref double MoveTime)
        {
            TaskDisp.GetMotionData(StartV, DriveV, Accel, Dist, ref MoveTime);
        }
        internal static void GetMotionData(CControl2.TAxis Axis, double StartV, double DriveV, double Accel, double Dist, ref double MoveTime)
        {
            GetOperationSpeed(Axis, ref StartV, ref DriveV, ref Accel);
            TaskDisp.GetMotionData(StartV, DriveV, Accel, Dist, ref MoveTime);
        }

        //****set speed according to Operation_SpeedMode
        internal static bool SetMotionParamOp(CControl2.TAxis Axis, double StartV, double DriveV, double Accel)
        {
            if (GDefine.SysOffline) { return true; }

            //double SV = StartV;
            //double DV = DriveV;
            //double AC = Accel;

            switch (GDefine.OperationSpeed)
            {
                case EOperationSpeed.Safe:
                    if ((Axis.Device.ID == TaskGantry.GXAxis.Device.ID && Axis.Mask == TaskGantry.GXAxis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GYAxis.Device.ID && Axis.Mask == TaskGantry.GYAxis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GZAxis.Device.ID && Axis.Mask == TaskGantry.GZAxis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GX2Axis.Device.ID && Axis.Mask == TaskGantry.GX2Axis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GY2Axis.Device.ID && Axis.Mask == TaskGantry.GY2Axis.Mask) ||
                        (Axis.Device.ID == TaskGantry.GZ2Axis.Device.ID && Axis.Mask == TaskGantry.GZ2Axis.Mask))
                    {
                        //DV = DV * GDefine.Operation_SpeedMode_SafeSpeedRatio;
                        //if (DV < SV) SV = DV;
                        //AC = AC * GDefine.Operation_SpeedMode_SlowSpeedRatio;
                        GetOperationSpeed(Axis, ref StartV, ref DriveV, ref Accel);
                    }
                    break;
                case EOperationSpeed.SlowMo:
                    //DV = DV * GDefine.Operation_SpeedMode_SlowSpeedRatio;
                    //if (DV < SV) SV = DV;
                    //AC = AC * GDefine.Operation_SpeedMode_SlowSpeedRatio;
                    GetOperationSpeed(Axis, ref StartV, ref DriveV, ref Accel);
                    break;
                case EOperationSpeed.Normal:
                default:
                    break;
            }

            //try
            //{
            //    CControl2ontrol.SetMotionParam(Axis, StartV, DriveV, Accel);
            //}
            //catch (Exception Ex)
            //{
            //    //EMsg = EMsg + (char)13 + Ex.Message.ToString();
            //    //goto _Ex;
            //    GDefine.Status = EStatus.ErrorInit;
            //    ErrCode.ShowErrOKNoAssist(ErrCode.E3105_MotionExError, Ex.Message);
            //    return false;
            //}
            //return true;

            return SetMotionParam(Axis, StartV, DriveV, Accel);


            //_Error:
            //    return false;
            //_Ex:
            //    GDefine.Status = EStatus.ErrorInit;
            //    throw new Exception(EMsg);
        }
        internal static bool SetMotionParamOp(CControl2.TAxis Axis)
        {
            return SetMotionParamOp(Axis, Axis.Para.StartV, Axis.Para.FastV, Axis.Para.Accel);
        }

        //internal static bool MoveAbs(CControl2.TAxis Axis, double Pos, bool Wait)
        //{
        //    if (GDefine.SysOffline) return true;

        //    if (MotorAlarmPrompt(Axis)) return false;
        //    if (AxisErrorPrompt(Axis)) return false;

        //    if (!MovePtpAbs(Axis, Pos)) return false;
        //    if (Wait)
        //    {
        //        if (!AxisWait(Axis)) return false;
        //        if (MotorAlarmPrompt(Axis)) return false;
        //        if (AxisErrorPrompt(Axis)) return false;
        //    }

        //    return true;
        //}
        //public static bool WaitGZ()
        //{
        //    if (GDefine.SysOffline) return true;

        //    if (!AxisWait(GZAxis)) return false;

        //    return true;
        //}

        internal static bool SetMotionParamGXY(double StartV, double DriveV, double Accel)
        {
            if (!SetMotionParamOp(GXAxis, StartV, DriveV, Accel)) return false;
            if (!SetMotionParamOp(GYAxis, StartV, DriveV, Accel)) return false;
            return true;
        }

        public static bool MovePtpAbsGX(double Pos, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (MotorAlarmPrompt(GXAxis)) return false;
            if (AxisErrorPrompt(GXAxis)) return false;

            if (!MovePtpAbs(GXAxis, Pos)) return false;
            if (Wait)
            {
                if (!AxisWait(GXAxis)) return false;
                if (MotorAlarmPrompt(GXAxis)) return false;
                if (AxisErrorPrompt(GXAxis)) return false;
            }

            return true;
        }
        public static bool MovePtpRelGX(double Pos, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (MotorAlarmPrompt(GXAxis)) return false;
            if (AxisErrorPrompt(GXAxis)) return false;

            if (!MovePtpRel(GXAxis, Pos)) return false;
            if (Wait)
            {
                if (!AxisWait(GXAxis)) return false;
                if (MotorAlarmPrompt(GXAxis)) return false;
                if (AxisErrorPrompt(GXAxis)) return false;
            }

            return true;
        }

        public static bool SetMotionParamGXY()
        {
            if (GDefine.SysOffline) return true;

            if (!SetMotionParamGXY(GXAxis.Para.StartV, GXAxis.Para.FastV, GXAxis.Para.Accel)) return false;

            return true;
        }
        public static bool WaitGXY()
        {
            if (GDefine.SysOffline) return true;

            if (!AxisWait(GXAxis)) return false;
            if (!AxisWait(GYAxis)) return false;

            return true;
        }
        internal static bool IsBusyGXY()
        {
            if (GDefine.SysOffline) return true;

            //bool Busy1 = AxisBusy(GXAxis);
            //bool Busy2 = AxisBusy(GYAxis);

            //return (Busy1 || Busy2);

            bool Busy = AxesBusy(GXAxis, GYAxis);

            return (Busy);
        }
        public static bool MoveAbsGXY(double X, double Y, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            try
            {
                CommonControl.DecelOn(GXAxis);
                CommonControl.DecelOn(GYAxis);
            }
            catch { }

            double XV = X;
            double YV = Y;
            if (XV > TaskGantry.GXAxis.Para.SwLimit.PosP || XV < TaskGantry.GXAxis.Para.SwLimit.PosN)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GX_TARGET_MORE_THAN_STROKE);
                return false;
            }

            if (YV > TaskGantry.GYAxis.Para.SwLimit.PosP || YV < TaskGantry.GYAxis.Para.SwLimit.PosN)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GY_TARGET_MORE_THAN_STROKE);
                return false;
            }

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (TaskDisp.Head2_DefDistX >= 0)
                {
                    double XV2 = X + (GX2Pos() - TaskDisp.Head2_DefPos.X);
                    if (XV2 > TaskGantry.GXAxis.Para.SwLimit.PosP)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.GX2Y2_COLLISION_POSSIBLE);
                        return false;
                    }
                }
            }

            if (!MoveLineAbs(GXAxis, GYAxis, X, Y)) return false;
            if (Wait)
                if (!WaitGXY()) return false;

            if (MotorAlarmPrompt(GXAxis)) return false;
            if (MotorAlarmPrompt(GYAxis)) return false;
            if (AxisErrorPrompt(GXAxis)) return false;
            if (AxisErrorPrompt(GYAxis)) return false;

            return true;
        }
        public static bool MoveAbsGXY(double X, double Y)
        {
            return MoveAbsGXY(X, Y, true);
        }
        public static bool MoveAbsGXYNoError(double X, double Y, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            try
            {
                CommonControl.DecelOn(GXAxis);
                CommonControl.DecelOn(GYAxis);
            }
            catch { }

            double XV = X;
            double YV = Y;
            if (XV > TaskGantry.GXAxis.Para.SwLimit.PosP || XV < TaskGantry.GXAxis.Para.SwLimit.PosN)
            {
                //Msg MsgBox = new Msg();
                //MsgBox.Show(ErrCode.GX_TARGET_MORE_THAN_STROKE);
                return false;
            }

            if (YV > TaskGantry.GYAxis.Para.SwLimit.PosP || YV < TaskGantry.GYAxis.Para.SwLimit.PosN)
            {
                //Msg MsgBox = new Msg();
                //MsgBox.Show(ErrCode.GY_TARGET_MORE_THAN_STROKE);
                return false;
            }

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                double XV2 = X + (GX2Pos() - TaskDisp.Head2_DefPos.X);
                if (XV2 > TaskGantry.GXAxis.Para.SwLimit.PosP)
                {
                    //Msg MsgBox = new Msg();
                    //MsgBox.Show(ErrCode.GX2Y2_COLLISION_POSSIBLE);
                    return false;
                }
            }

            if (!MoveLineAbs(GXAxis, GYAxis, X, Y)) return false;
            if (Wait)
                if (!WaitGXY()) return false;

            //if (GXAxisAlarm()) return false;
            //if (GYAxisAlarm()) return false;
            //if (GXAxisError()) return false;
            //if (GYAxisError()) return false;

            return true;
        }

        //public static bool MoveRelGXY(double X, double Y, bool Wait)
        //{
        //    if (GDefine.SysOffline) return true;

        //    try
        //    {
        //        CommonControl.DecelOn(GXAxis);
        //        CommonControl.DecelOn(GYAxis);
        //    }
        //    catch { }

        //    if (!MoveLineRel(GXAxis, GYAxis, X, Y)) return false;
        //    if (Wait)
        //        if (!WaitGXY()) return false;

        //    if (MotorAlarmPrompt(GXAxis)) return false;
        //    if (MotorAlarmPrompt(GYAxis)) return false;
        //    if (AxisErrorPrompt(GXAxis)) return false;
        //    if (AxisErrorPrompt(GYAxis)) return false;

        //    return true;
        //}

        public static bool MoveArcCenterEndAbsGXY(bool CW, double CX, double CY, double EX, double EY, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            try
            {
                CommonControl.DecelOn(GXAxis);
                CommonControl.DecelOn(GYAxis);
            }
            catch { }

            if (!MoveArcCenterEndAbs(GXAxis, GYAxis, CW, CX, CY, EX, EY)) return false;
            if (Wait)
                if (!WaitGXY()) return false;

            if (MotorAlarmPrompt(GXAxis)) return false;
            if (MotorAlarmPrompt(GYAxis)) return false;
            if (AxisErrorPrompt(GXAxis)) return false;
            if (AxisErrorPrompt(GYAxis)) return false;

            return true;
        }

        internal static bool MoveConstAbsGXY(double X, double Y, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (MotorAlarmPrompt(GXAxis)) return false;
            if (MotorAlarmPrompt(GYAxis)) return false;
            if (AxisErrorPrompt(GXAxis)) return false;
            if (AxisErrorPrompt(GYAxis)) return false;

            try
            {
                CommonControl.DecelOff(GXAxis);
                CommonControl.DecelOff(GYAxis);
            }
            catch { }

            if (!MoveLineAbs(GXAxis, GYAxis, X, Y)) return false;
            if (Wait)
                if (!WaitGXY()) return false;

            if (MotorAlarmPrompt(GXAxis)) return false;
            if (MotorAlarmPrompt(GYAxis)) return false;
            if (AxisErrorPrompt(GXAxis)) return false;
            if (AxisErrorPrompt(GYAxis)) return false;

            return true;
        }
        internal static bool MoveConstArcCenterEndAbsGXY(double Center1, double Center2, double EndPt1, double EndPt2, bool CW, bool Wait)
        {
            if (GDefine.SysOffline) { return true; }

            if (!MoveArcCenterEndAbs(GXAxis, GYAxis, CW, Center1, Center2, EndPt1, EndPt2)) return false;
            if (Wait)
                if (!WaitGXY()) return false;

            return true;
        }
        public static bool ForceStopGXY()
        {
            if (GDefine.SysOffline) return true;

            bool E1 = ForceStop(GXAxis);
            bool E2 = ForceStop(GYAxis);

            return (E1 && E2);
        }

        //public static bool TaskGXYEcdInRange()
        //{
        //    if (TaskDisp.XYMoveEncOfst == 0) return true;

        //    double Tol = TaskDisp.XYMoveEncOfst;

        //    double logX = GXLogPos;
        //    double ecdX = GXEcdPos;
        //    double ofstX = logX - ecdX;
        //    if (Math.Abs(ofstX) >= Tol)
        //    {
        //        GDefine.Status = EStatus.ErrorInit;
        //        Msg MsgBox = new Msg();
        //        MsgBox.Show(ErrCode.GXY_ENC_OFFSET, "X Axis Logical and Encoder Offset " + ofstX.ToString("f3"));

        //        return false;
        //    }

        //    double logY = GYLogPos;
        //    double ecdY = GYEcdPos;
        //    double ofstY = logY - ecdY;
        //    if (Math.Abs(ofstY) >= Tol)
        //    {
        //        GDefine.Status = EStatus.ErrorInit;
        //        Msg MsgBox = new Msg();
        //        MsgBox.Show(ErrCode.GXY_ENC_OFFSET, "Y Axis Logical and Encoder Offset " + ofstY.ToString("f3"));

        //        return false;
        //    }

        //    return true;
        //}

        internal static bool SetMotionParamGZ(double StartV, double DriveV, double Accel)
        {
            if (GDefine.SysOffline) return true;

            return SetMotionParamOp(GZAxis, StartV, DriveV, Accel);
        }
        public static bool SetMotionParamGZ()
        {
            if (GDefine.SysOffline) return true;

            return SetMotionParamGZ(GZAxis.Para.StartV, GZAxis.Para.FastV, GZAxis.Para.Accel);
        }
        public static bool WaitGZ()
        {
            if (GDefine.SysOffline) return true;

            if (!AxisWait(GZAxis)) return false;

            return true;
        }
        internal static bool IsBusyGZ()
        {
            if (GDefine.SysOffline) return true;

            return AxisBusy(GZAxis);
        }
        public static bool MoveAbsGZ(double Pos, bool Wait)
        {
            if (GDefine.SysOffline) return true;


            if (MotorAlarmPrompt(GZAxis)) return false;
            if (AxisErrorPrompt(GZAxis)) return false;


            if (!MovePtpAbs(GZAxis, Pos)) return false;

            if (Wait)
            {

                if (!AxisWait(GZAxis)) return false;
                if (MotorAlarmPrompt(GZAxis)) return false;
                if (AxisErrorPrompt(GZAxis)) return false;
            }



            return true;
        }
        public static bool MoveAbsGZ(double Pos)
        {
            return MoveAbsGZ(Pos, true);
        }
        internal static bool MoveRelGZ(double Pos, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (MotorAlarmPrompt(GZAxis)) return false;
            if (AxisErrorPrompt(GZAxis)) return false;

            if (!MovePtpRel(GZAxis, Pos)) return false;
            if (Wait)
            {
                if (!AxisWait(GZAxis)) return false;
                if (MotorAlarmPrompt(GZAxis)) return false;
                if (AxisErrorPrompt(GZAxis)) return false;
            }

            return true;
        }
        public static bool ForceStopGZ()
        {
            if (GDefine.SysOffline) return true;

            return ForceStop(GZAxis);
        }

        internal static bool SetMotionParamExGX2Y2(double StartV, double DriveV, double Accel)
        {
            if (GDefine.SysOffline) return true;

            if (!SetMotionParamEx(GX2Axis, StartV, DriveV, Accel)) return false;
            if (!SetMotionParamEx(GY2Axis, StartV, DriveV, Accel)) return false;

            return true;
        }
        internal static bool SetMotionParamExGX2Y2()
        {
            if (GDefine.SysOffline) return true;

            if (!SetMotionParamExGX2Y2(GX2Axis.Para.StartV, GX2Axis.Para.FastV, GX2Axis.Para.Accel)) return false;
            //if (!SetMotionParamEx(GY2Axis, GX2Axis.StartV, GX2Axis.DriveV, GX2Axis.Accel)) return false;

            return true;
        }
        internal static bool SetMotionParamGX2Y2(double StartV, double DriveV, double Accel)
        {
            if (GDefine.SysOffline) return true;

            if (!SetMotionParamOp(GX2Axis, StartV, DriveV, Accel)) return false;
            if (!SetMotionParamOp(GY2Axis, StartV, DriveV, Accel)) return false;

            return true;
        }
        public static bool SetMotionParamGX2Y2()
        {
            if (GDefine.SysOffline) return true;

            return SetMotionParamGX2Y2(GX2Axis.Para.StartV, GX2Axis.Para.FastV, GX2Axis.Para.Accel);
        }
        public static bool WaitGX2Y2()
        {
            if (GDefine.SysOffline) return true;

            if (!AxisWait(GX2Axis)) return false;
            if (!AxisWait(GY2Axis)) return false;

            return true;
        }
        internal static bool IsBusyGX2Y2()
        {
            if (GDefine.SysOffline) return true;

            bool Busy1 = AxisBusy(GX2Axis);
            bool Busy2 = AxisBusy(GY2Axis);

            return (Busy1 && Busy2);
        }
        public static bool MoveAbsGX2Y2(double X2, double Y2, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            try
            {
                CommonControl.DecelOn(GX2Axis);
                CommonControl.DecelOn(GY2Axis);
            }
            catch { }

            if (!MoveLineAbs(GX2Axis, GY2Axis, X2, Y2)) return false;
            if (Wait)
                if (!WaitGX2Y2()) return false;

            if (MotorAlarmPrompt(GX2Axis)) return false;
            if (MotorAlarmPrompt(GY2Axis)) return false;
            if (AxisErrorPrompt(GX2Axis)) return false;
            if (AxisErrorPrompt(GY2Axis)) return false;

            return true;
        }
        public static bool MoveAbsGX2Y2(double X2, double Y2)
        {
            return MoveAbsGX2Y2(X2, Y2, true);
        }
        internal static bool MoveConstAbsGX2Y2(double X, double Y, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (MotorAlarmPrompt(GX2Axis)) return false;
            if (MotorAlarmPrompt(GY2Axis)) return false;
            if (AxisErrorPrompt(GX2Axis)) return false;
            if (AxisErrorPrompt(GY2Axis)) return false;

            try
            {
                CommonControl.DecelOff(GX2Axis);
                CommonControl.DecelOff(GY2Axis);
            }
            catch { }

            if (!MoveLineAbs(GX2Axis, GY2Axis, X, Y)) return false;
            if (Wait)
                if (!WaitGX2Y2()) return false;

            if (MotorAlarmPrompt(GX2Axis)) return false;
            if (MotorAlarmPrompt(GY2Axis)) return false;
            if (AxisErrorPrompt(GX2Axis)) return false;
            if (AxisErrorPrompt(GY2Axis)) return false;

            return true;
        }
        public static bool ForceStopGX2Y2()
        {
            if (GDefine.SysOffline) return true;

            bool E1 = ForceStop(GX2Axis);
            bool E2 = ForceStop(GY2Axis);

            return (E1 && E2);
        }

        internal static bool SetMotionParamGZ2(double StartV, double DriveV, double Accel)
        {
            if (GDefine.SysOffline) return true;

            return SetMotionParamOp(GZ2Axis, StartV, DriveV, Accel);
        }
        public static bool SetMotionParamGZ2()
        {
            if (GDefine.SysOffline) return true;

            return SetMotionParamGZ2(GZ2Axis.Para.StartV, GZ2Axis.Para.FastV, GZ2Axis.Para.Accel);
        }
        public static bool WaitGZ2()
        {
            if (GDefine.SysOffline) return true;

            if (!AxisWait(GZ2Axis)) return false;

            return true;
        }
        internal static bool IsBusyGZ2()
        {
            if (GDefine.SysOffline) return true;

            return AxisBusy(GZ2Axis);
        }
        public static bool MoveAbsGZ2(double Pos, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (MotorAlarmPrompt(GZ2Axis)) return false;
            if (AxisErrorPrompt(GZ2Axis)) return false;

            if (!MovePtpAbs(GZ2Axis, Pos)) return false;
            if (Wait)
            {
                if (!AxisWait(GZ2Axis)) return false;
                if (MotorAlarmPrompt(GZ2Axis)) return false;
                if (AxisErrorPrompt(GZ2Axis)) return false;
            }

            return true;
        }
        public static bool MoveAbsGZ2(double Pos)
        {
            return MoveAbsGZ2(Pos, true);
        }
        internal static bool MoveRelGZ2(double Pos, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (MotorAlarmPrompt(GZ2Axis)) return false;
            if (AxisErrorPrompt(GZ2Axis)) return false;

            if (!MovePtpRel(GZ2Axis, Pos)) return false;
            if (Wait)
            {
                if (!AxisWait(GZ2Axis)) return false;
                if (MotorAlarmPrompt(GZ2Axis)) return false;
                if (AxisErrorPrompt(GZ2Axis)) return false;
            }

            return true;
        }
        public static bool ForceStopGZ2()
        {
            if (GDefine.SysOffline) return true;

            return ForceStop(GZ2Axis);
        }

        internal static bool SetMotionParamGXYX2Y2()
        {
            if (GDefine.SysOffline) return true;

            if (!SetMotionParamGXY()) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                if (!SetMotionParamGX2Y2()) return false;

            return true;
        }

        internal static bool SetMotionParamGZZ2(double StartV, double DriveV, double Accel)
        {
            if (GDefine.SysOffline) return true;

            if (!SetMotionParamGZ(StartV, DriveV, Accel)) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!SetMotionParamGZ2(StartV, DriveV, Accel)) return false;
            }
            return true;
        }
        internal static bool SetMotionParamGZZ2()
        {
            if (GDefine.SysOffline) return true;

            if (!SetMotionParamGZ()) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!SetMotionParamGZ2()) return false;
            }
            return true;
        }
        internal static bool MoveAbsGZZ2(double Pos1, double Pos2, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (!MoveAbsGZ(Pos1, false)) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                if (!MoveAbsGZ2(Pos2, false)) return false;

            if (Wait)
            {
                if (!WaitGZ()) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                    if (!WaitGZ2()) return false;
            }
            return true;
        }
        internal static bool MoveAbsGZZ2(double Pos1, double Pos2)
        {
            if (GDefine.SysOffline) return true;

            return MoveAbsGZZ2(Pos1, Pos2, true);
        }
        internal static bool MoveAbsGZZ2(double Pos)
        {
            if (GDefine.SysOffline) return true;

            return MoveAbsGZZ2(Pos, Pos, true);
        }
        internal static bool MoveRelGZZ2(double Pos1, double Pos2, bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (!MoveRelGZ(Pos1, false)) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                if (!MoveRelGZ2(Pos2, false)) return false;

            if (Wait)
            {
                if (!WaitGZ()) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                    if (!WaitGZ2()) return false;
            }
            return true;
        }
        internal static bool MoveRelGZZ2(double Pos1, double Pos2)
        {
            if (GDefine.SysOffline) return true;

            return MoveRelGZZ2(Pos1, Pos2, true);
        }
        internal static bool MoveRelGZZ2(double Pos)
        {
            if (GDefine.SysOffline) return true;

            return MoveRelGZZ2(Pos, Pos, true);
        }
        internal static bool WaitGZZ2()
        {
            if (GDefine.SysOffline) return true;

            if (!WaitGZ()) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                if (!WaitGZ2()) return false;

            return true;
        }

        internal static bool MoveGX2Y2DefPos(bool Wait)
        {
            if (GDefine.SysOffline) return true;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);

                //GX2Y2.X = Math.Min(GX2Y2.X, 0);
                //GX2Y2.Y = Math.Min(GX2Y2.Y, 0);

                if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                if (!MoveAbsGX2Y2(GX2Y2.X, GX2Y2.Y, Wait)) return false;
                if (Wait)
                    if (!TaskGantry.WaitGXY()) return false;
            }

            return true;
        }

        #region GeneralIO
        public static bool EMO()
        {
            if (GDefine.SysOffline) return _EMO.Status;

            bool bEMO = GetInput(ref _EMO);

            if (bEMO)
            {
                DispATrig = false;
                DispBTrig = false;
                BPress1 = false;
                BPress2 = false;
                DispPortC1 = false;
            }

            return bEMO;
        }

        public static bool BtnStart()
        {
            if (GDefine.SysOffline) return _BtnStart.Status;

            return TaskGantry.GetInput(ref _BtnStart);
        }
        public static bool BtnStop()
        {
            if (GDefine.SysOffline) return _BtnStop.Status;

            return TaskGantry.GetInput(ref _BtnStop);
        }

        public static bool SensNeedleZ()
        {
            return TaskGantry.GetInput(ref _SensNeedleZ);
        }
        //public static bool SvCleanVac(TOutputState State)
        //{
        //    try
        //    {
        //        if (State == TOutputState.On)
        //            CommonControl.SetDO(ref _SvCleanVac, CControl2.EOutputStatus.Hi);
        //        if (State == TOutputState.Off)
        //            CommonControl.SetDO(ref _SvCleanVac, CControl2.EOutputStatus.Lo);
        //    }
        //    catch { }
        //    return _SvCleanVac.Status;
        //}
        public static bool SvCleanVac
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _SvCleanVac, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _SvCleanVac, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _SvCleanVac.Status;
            }
        }

        //public static bool SvChuckVac(TOutputState State)
        //{
        //    try
        //    {
        //        if (State == TOutputState.On)
        //            CommonControl.SetDO(ref _SvChuckVac, CControl2.EOutputStatus.Hi);
        //        if (State == TOutputState.Off)
        //            CommonControl.SetDO(ref _SvChuckVac, CControl2.EOutputStatus.Lo);
        //    }
        //    catch { }
        //    return _SvChuckVac.Status;
        //}
        public static bool SensChuckVac
        {
            get
            {
                return TaskGantry.GetInput(ref _SensChuckVac);
            }
        }
        public static bool ChuckVac
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _SvChuckVac, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _SvChuckVac, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _SvChuckVac.Status;
            }
        }

        public static bool CheckSensChuckVacOn()
        {
            //Thread.Sleep(100);
            if (_SensChuckVac.Device.Type == CControl2.EDeviceType.NONE) return true;
            if (SensChuckVac) return true;

            Msg MsgBox = new Msg();
            EMsgRes MsgRes = MsgBox.Show(ErrCode.CHUCK_VAC_NOT_HIGH, "", EMcState.Warning, EMsgBtn.smbOK_Stop, false);
            switch (MsgRes)
            {
                case EMsgRes.smrOK: return true;
                case EMsgRes.smrStop:
                default:
                    return false;
            }
        }

        public static bool SensMat1Low()
        {
            return TaskGantry.GetInput(ref _SensMat1Low);
        }
        public static bool SensMat2Low()
        {
            return TaskGantry.GetInput(ref _SensMat2Low);
        }

        public static bool DispAReady()
        {
            return TaskGantry.GetInput(ref _DispARdy);
        }
        public static bool DispATrigSet(TOutputState State)
        {
            try
            {
                if (State == TOutputState.On)
                    CommonControl.SetDO(ref _DispATrg, CControl2.EOutputStatus.Hi);
                if (State == TOutputState.Off)
                    CommonControl.SetDO(ref _DispATrg, CControl2.EOutputStatus.Lo);
            }
            catch { }
            return _DispATrg.Status;
        }
        public static bool DispATrig
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _DispATrg, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _DispATrg, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _DispATrg.Status;
            }
        }

        public static bool DispBReady()
        {
            return TaskGantry.GetInput(ref _DispBRdy);           
        }
        public static bool DispBTrigSet(TOutputState State)
        {
            try
            {
                if (State == TOutputState.On)
                    CommonControl.SetDO(ref _DispBTrg, CControl2.EOutputStatus.Hi);
                if (State == TOutputState.Off)
                    CommonControl.SetDO(ref _DispBTrg, CControl2.EOutputStatus.Lo);
            }
            catch { }
            return _DispBTrg.Status;
        }
        public static bool DispBTrig
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _DispBTrg, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _DispBTrg, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _DispBTrg.Status;
            }
        }
        public static bool DispCtrlError
        {
            get
            {
                return TaskGantry.GetInput(ref _DispError); 
            }
        }

        public static bool TapeReady
        {
            get
            {
                return TaskGantry.GetInput(ref _TapeReady);
            }
        }
        public static bool TapeTrig
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _TapeTrig, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _TapeTrig, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _TapeTrig.Status;
            }
        }
        public static bool TapeAlarm
        {
            get
            {
                return TaskGantry.GetInput(ref _TapeAlarm);
            }
        }
        public static bool TapeReset
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _TapeReset, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _TapeReset, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _TapeReset.Status;
            }
        }

        public static bool FPress1(TOutputState State)
        {
            try
            {
                if (State == TOutputState.On)
                    CommonControl.SetDO(ref _SvFPress1, CControl2.EOutputStatus.Hi);
                if (State == TOutputState.Off)
                    CommonControl.SetDO(ref _SvFPress1, CControl2.EOutputStatus.Lo);
            }
            catch { }
            return _SvFPress1.Status;
        }
        public static bool BPress1
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _SvFPress1, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _SvFPress1, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _SvFPress1.Status;
            }
        }
        public static bool FPress2(TOutputState State)
        {
            try
            {
                if (State == TOutputState.On)
                    CommonControl.SetDO(ref _SvFPress2, CControl2.EOutputStatus.Hi);
                if (State == TOutputState.Off)
                    CommonControl.SetDO(ref _SvFPress2, CControl2.EOutputStatus.Lo);
            }
            catch { }
            return _SvFPress2.Status;
        }
        public static bool BPress2
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _SvFPress2, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _SvFPress2, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _SvFPress2.Status;
            }
        }
        public static bool BVac1
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _SvFVac1, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _SvFVac1, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _SvFVac1.Status;
            }        
        }
        public static bool DispPortA1
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _SvPortA1, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _SvPortA1, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _SvPortA1.Status;
            }
        }
        public static bool DispPortB1
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _SvPortB1, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _SvPortB1, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _SvPortB1.Status;
            }
        }
        public static bool DispPortC1
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _SvPortC1, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _SvPortC1, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _SvPortC1.Status;
            }
        }

        public static bool Buzzer(TOutputState State)
        {
            try
            {
                if (_Buzzer.Device.Type == CControl2.EDeviceType.NONE) return false;

                if (State == TOutputState.On)
                    CommonControl.SetDO(ref _Buzzer, CControl2.EOutputStatus.Hi);
                if (State == TOutputState.Off)
                    CommonControl.SetDO(ref _Buzzer, CControl2.EOutputStatus.Lo);
            }
            catch { }
            return _Buzzer.Status;
        }

        public static bool GPOut1
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _GPOut1, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _GPOut1, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _GPOut1.Status;
            }
        }
        public static bool GPOut2
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _GPOut2, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _GPOut2, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _GPOut2.Status;
            }
        }
        public static bool GPOut3
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _GPOut3, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _GPOut3, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _GPOut3.Status;
            }
        }
        public static bool GPOut4
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _GPOut4, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _GPOut4, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _GPOut4.Status;
            }
        }
        public static bool GPOut5
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _GPOut5, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _GPOut5, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _GPOut5.Status;
            }
        }
        public static bool GPOut6
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _GPOut6, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _GPOut6, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _GPOut6.Status;
            }
        }
        public static bool SensDoor
        {
            get
            {
                return TaskGantry.GetInput(ref _SensDoor);
            }
        }
        public static bool LockDoor
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _LockDoor, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _LockDoor, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _LockDoor.Status;
            }
        }

        public static bool SvPnpPrecise
        {
            set
            {
                try
                {
                    CControl2.EOutputStatus OutputStatus = value ? CControl2.EOutputStatus.Hi : CControl2.EOutputStatus.Lo;
                    CommonControl.SetDO(ref _SvPnpPrecise, OutputStatus);
                }
                catch { }
            }
            get
            {
                return _SvPnpPrecise.Status;
            }
        }
        public static bool SensPnpPrecise
        {
            get
            {
                return TaskGantry.GetInput(ref _SensPnpPrecise);
            }
        }
        public static bool SensPnpContact
        {
            get
            {
                return TaskGantry.GetInput(ref _SensPnpContact);
            }
        }
        public static bool SvPnpVac
        {
            set
            {
                try
                {
                    CControl2.EOutputStatus OutputStatus = value ? CControl2.EOutputStatus.Hi : CControl2.EOutputStatus.Lo;
                    CommonControl.SetDO(ref _SvPnpVac, OutputStatus);
                }
                catch { }
            }
            get
            {
                return _SvPnpVac.Status;
            }
        }
        public static bool SvPnpPurge
        {
            set
            {
                try
                {
                    CControl2.EOutputStatus OutputStatus = value ? CControl2.EOutputStatus.Hi : CControl2.EOutputStatus.Lo;
                    CommonControl.SetDO(ref _SvPnpPurge, OutputStatus);
                }
                catch { }
            }
            get
            {
                return _SvPnpPurge.Status;
            }
        }
        public static bool SensPnpVac
        {
            get
            {
                return TaskGantry.GetInput(ref _SensPnpVac);
            }
        }

        public static bool TLGreen
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _TlGrn, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _TlGrn, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _TlGrn.Status;
            }
        }
        public static bool TLYellow
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _TlYlw, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _TlYlw, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _TlYlw.Status;
            }
        }
        public static bool TLRed
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _TlRed, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _TlRed, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _TlRed.Status;
            }
        }
        public static bool TLBuzzer
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _TlBzr, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _TlBzr, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _TlBzr.Status;
            }
        }


        public static bool NICamSigOK
        {
            get
            {
                return TaskGantry.GetInput(ref _NICamSigOK);
            }
        }
        public static bool NICamBusy
        {
            get
            {
                return TaskGantry.GetInput(ref _NICamBusy);
            }
        }
        public static bool NICamRun
        {
            get
            {
                return TaskGantry.GetInput(ref _NICamRun);
            }
        }
        public static bool NICamTrig
        {
            set
            {
                try
                {
                    if (value)
                        CommonControl.SetDO(ref _NICamTrig, CControl2.EOutputStatus.Hi);
                    else
                        CommonControl.SetDO(ref _NICamTrig, CControl2.EOutputStatus.Lo);
                }
                catch { }
            }
            get
            {
                return _NICamTrig.Status;
            }
        }
        #endregion

        internal static double ZSensorPos
        {
            get
            {
                if (GDefine.SysOffline) return 0;
                if (GDefine.ZSensorType == GDefine.EZSensorType.Encoder)
                {
                    double Pos = 0;
                    if (TaskGantry.SZAxis.Mask == TaskGantry.GX2Axis.Mask)
                    {
                        Pos = TaskGantry.EncoderPos(TaskGantry.GX2Axis);
                        Pos = Pos / TaskGantry.GX2Axis.Para.Unit.Resolution;
                        double Ecd_Reso = GDefine.ZSensor_DistPerPulse;// 0.0005mm
                        Pos = Pos * Ecd_Reso;
                    }
                    else
                    {
                        Pos = TaskGantry.EncoderPos(TaskGantry.SZAxis);
                    }
                    return Pos;
                }
                return 0;
            }
            set
            {
                if (GDefine.SysOffline) return;
                if (GDefine.ZSensorType == GDefine.EZSensorType.Encoder)
                {
                    TaskGantry.EncoderPos(TaskGantry.SZAxis, value);
                }
            }
        }
        internal static bool CheckDoorSw()
        {
            //if (TaskGantry._SensDoor.Device.Type != CControl2.EDeviceType.NONE)
            //{
            //    if (!TaskGantry.SensDoor)
            //    {
            //        Msg MsgBox = new Msg();
            //        EMsgRes MsgRes = MsgBox.Show(ErrCode.DOOR_IS_OPEN, EMcState.Warning, EMsgBtn.smbOK, false);
            //        return false;
            //    }

            //    if (TaskGantry._LockDoor.Device.Type != CControl2.EDeviceType.NONE)
            //    {
            //        TaskGantry.LockDoor = true;
            //        IO.SetState(EMcState.Run);
            //    }
            //}
            //return true;
            return DefineSafety.DoorCheck_Disp(true);
        }

        public class TrapezoidDrive
        {
            public static double Ac_Time(double StartSpeed, double DriveSpeed, double Accel)
            {
                //ta = (v-u)/a
                return (DriveSpeed - StartSpeed) / Accel;
            }
            public static double Ac_Dist(double StartSpeed, double DriveSpeed, double Accel)
            {
                double ac_Time = Ac_Time(StartSpeed, DriveSpeed, Accel);
                //da = ut + 1/2at2
                double d = (StartSpeed * ac_Time) + (0.5 * Accel * ac_Time * ac_Time);
                return d;
            }
            public static bool IsShortDist(double StartSpeed, double DriveSpeed, double Accel, double Dist)
            {
                return (Ac_Dist(StartSpeed, DriveSpeed, Accel) >= Dist);
            }
            public static double HalfDistSpeed(double StartSpeed, double DriveSpeed, double Accel, double Dist)
            {
                if (!IsShortDist(StartSpeed, DriveSpeed, Accel, Dist)) return DriveSpeed;
                else
                {
                    //quadratic equation
                    //ax2 + bx + c = 0
                    //x = (-b +- Sqrt(b2-4ac))/2a
                    //x = (-b +- Sqrt(d))/2a
                    //x = (-b +- e)/2a


                    //s = ut + 1/2at2
                    //0.5at2 + ut - s = 0

                    double a = 0.5 * Accel;
                    double b = StartSpeed;
                    double c = -Dist/2;
                    double b2 = StartSpeed * StartSpeed;
                    double d = b2 - (4 * a * c);
                    double e = Math.Sqrt(d);

                    double t = (-b + e) / (2 * a);

                    return StartSpeed + Accel * t;
                }
            }
        }
    }
}
