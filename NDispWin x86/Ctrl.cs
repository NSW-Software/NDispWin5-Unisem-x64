using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;
using ZKA;

namespace ZEC3002
{
    public class Ctrl
    {
        public static ZM324 zm324;
        public static ZIO3001 zio3001;
        public static ZIO3201 zio3201;
        private static string CAN_IP = "192.168.1.100";
        private static bool CAN_Opened;//indicate ZEC is opened
        public static CAN_STATUS CAN_Status = CAN_STATUS.FREE;//can_status
        private static bool ZM324Device_Opened;//indicate device instance in open, open only 1x per device type
        private static bool ZIO3001Device_Opened;//indicate device instance in open, open only 1x per device type
        private static bool ZIO3201Device_Opened;//indicate device instance in open, open only 1x per device type
        private static int IOWaitTimeOut = 100;
        private static Mutex CANMutex = new Mutex();
        private static bool[] ZKAOpened = new bool[15];
        private static TDIOModel[] Device = new TDIOModel[15];


        public enum TDIOModel
        {
            None = -1,
            ZM324,
            ZIO3001,
            ZIO3201,
        }
        public static string[] TDIOModelStr = {"ZM324", "ZIO3001", "ZIO3201" };

        public struct TAxis
        {
            public string Name;
            public Ctrl.TDIOModel DIOModel;
            public byte BoardID;
            public byte AxisID;
            public TMotorPara MotorPara;
            public bool MotorStatus;

            public TAxis(string Name, Ctrl.TDIOModel DIOModel, byte BoardID, byte AxisID, TMotorPara MotorPara, bool MotorStatus)
            {
                this.Name = Name;
                this.DIOModel = DIOModel;
                this.BoardID = BoardID;
                this.AxisID = AxisID;
                this.MotorPara = MotorPara;
                this.MotorStatus = MotorStatus;
            }
        }

        public struct TDInput
        {
            public string Name;
            public Ctrl.TDIOModel DIOModel;
            public byte BoardID;
            public byte AxisID;
            public byte Add;
            public bool Status;
            public bool NA;

            public TDInput(string Name, Ctrl.TDIOModel DIOModel, byte BoardID, byte AxisID, byte Add,
                           bool Status, bool NA)
            {
                this.Name = Name;
                this.DIOModel = DIOModel;
                this.BoardID = BoardID;
                this.AxisID = AxisID;
                this.Add = Add; //P1240Mask ZM30xAdd
                this.Status = Status;
                this.NA = NA;
            }
        }
        public struct TDOutput
        {
            public string Name;
            public Ctrl.TDIOModel DIOModel;
            public byte BoardID;
            public byte AxisID;
            public byte Add;
            public bool Status;
            public bool NA;

            public TDOutput(string Name, Ctrl.TDIOModel DIOModel, byte BoardID, byte AxisID, byte Add, bool Status, bool NA)
            {
                this.Name = Name;
                this.DIOModel = DIOModel;
                this.BoardID = BoardID;
                this.AxisID = AxisID;
                this.Add = Add;
                this.Status = Status;
                this.NA = NA;
            }
        }
        public enum TDOStatus { Lo, Hi, St }

        public struct TPWMOutput
        {
            public string Name;
            public Ctrl.TDIOModel DIOModel;
            public byte BoardID;
            public byte Add;
            public uint Freq;
            public uint DutyCycle;
            public TPWMOutput(string Name, Ctrl.TDIOModel DIOModel, byte BoardID, byte Add, uint Freq, uint DutyCycle)
            {
                this.Name = Name;
                this.DIOModel = DIOModel;
                this.BoardID = BoardID;
                this.Add = Add;
                this.Freq = Freq;
                this.DutyCycle = DutyCycle;
            }
        }
        #region MotorPara
        public struct TMotorPara
        {
            public bool InvertMtrOn;
            public bool InvertDir;
            public double DistPerPulse;
            public TMotorAlarm MotorAlarm;
            //public int Range, Accel, StartV, SlowV, FastV;
            public double Range, Accel, StartV, SlowV, FastV;
            //public int PsntAccel, PsntStartV, PsntSpeed;
            public double PsntAccel, PsntStartV, PsntSpeed;
            //public int MinAccel, MaxAccel, MinStartV, MaxStartV, MinSlowV, MaxSlowV, MinFastV, MaxFastV;
            public double MinAccel, MaxAccel, MinConstSpeed, MaxConstSpeed, MinSpeed, MaxSpeed;
            public THomePara Home;
            public TJogPara Jog;
            public TSLimit SLimit;
        }
        public struct THomePara
        {
            public THomeDir HomeDir;
            //public int SlowV, FastV, TimeOut;
            public double SlowV, FastV;
            public int TimeOut;
        }
        public struct TJogPara
        {
            //public int SlowV, MedV, FastV, Sel;
            public double SlowV, MedV, FastV, Sel;
        }
        public struct TSLimit
        {
            public int N, P;
        }
        public enum TMotorAlarm
        {
            DISABLE = 0,
            NORMALLY_CLOSE = 1,
            NORMALLY_OPEN = 2,
        }
        public enum THomeDir
        {
            N = 0,
            P = 1,
        }
        #endregion

        #region  ZEC ERR CODE 
        public const int SUCCESS = 0;
        public const int CANBUSY = 1;
        public const int FAIL = 2;
        public const int ERR_CAN_CON_LOST = 50;
        public const int ERR_CAN_CON_    = 51;

        public const int ERR_INVALID_IP = 100;
        public const int ERR_BOARD_ID_NOT_INRANGE = 101;
        public const int ERR_OPEN_DEVICE_FAIL = 102;
        public const int ERR_NETWORK_DISCONNECT = 103;
        public const int ERR_OPENPORT_FAIL = 150;
        public const int ERR_INIT_MOTOR_FAIL = 160;
        public const int ERR_RESET_POS_FAIL = 161;
        public const int ERR_MOTOR_ON_FAIL = 162;
        public const int ERR_MOTOR_OFF_FAIL = 163;
        public const int ERR_GET_MIN_CONST_SPEED_TIMEOUT = 170;
        public const int ERR_GET_MAX_CONST_SPEED_TIMEOUT = 171;
        public const int ERR_GET_MIN_DRIVE_SPEED_TIMEOUT = 172;
        public const int ERR_GET_MAX_DRIVE_SPEED_TIMEOUT = 173;
        public const int ERR_GET_MIN_ACCEL_TIMEOUT = 174;
        public const int ERR_GET_MAX_ACCEL_TIMEOUT = 175;
        public const int ERR_GET_MIN_JERK_TIMEOUT = 176;
        public const int ERR_GET_MAX_JERK_TIMEOUT = 177;
        public const int ERR_CONST_SPEED_NOT_INRANGE = 180;
        public const int ERR_START_SPEED_NOT_INRANGE = 181;
        public const int ERR_DRIVE_SPEED_NOT_INRANGE = 182;
        public const int ERR_ACCEL_RATE_NOT_INRANGE = 183;
        public const int ERR_JERK_NOT_INRANGE = 184;
        public const int ERR_SET_SCURVE_PROFILE_FAIL = 190;
        public const int ERR_SET_SCURVE_PROFILE_TIMEOUT = 191;
        public const int ERR_SET_TRAPEZ_PROFILE_FAIL = 200;
        public const int ERR_SET_TRAPEZ_PROFILE_TIMEOUT = 201;
        public const int ERR_MOVE_PTP_REL1_FAIL = 210;
        public const int ERR_MOVE_PTP_REL2_AXIS1_FAIL = 211;
        public const int ERR_MOVE_PTP_REL2_AXIS2_FAIL = 212;
        public const int ERR_MOVE_PTP_REL3_AXIS1_FAIL = 213;
        public const int ERR_MOVE_PTP_REL3_AXIS2_FAIL = 214;
        public const int ERR_MOVE_PTP_REL3_AXIS3_FAIL = 215;
        public const int ERR_MOVE_PTP_REL4_AXIS1_FAIL = 216;
        public const int ERR_MOVE_PTP_REL4_AXIS2_FAIL = 217;
        public const int ERR_MOVE_PTP_REL4_AXIS3_FAIL = 218;
        public const int ERR_MOVE_PTP_REL4_AXIS4_FAIL = 219;
        public const int ERR_MOVE_PTP_ABS1_FAIL = 220;
        public const int ERR_MOVE_PTP_ABS2_AXIS1_FAIL = 221;
        public const int ERR_MOVE_PTP_ABS2_AXIS2_FAIL = 222;
        public const int ERR_MOVE_PTP_ABS3_AXIS1_FAIL = 223;
        public const int ERR_MOVE_PTP_ABS3_AXIS2_FAIL = 224;
        public const int ERR_MOVE_PTP_ABS3_AXIS3_FAIL = 225;
        public const int ERR_MOVE_PTP_ABS4_AXIS1_FAIL = 226;
        public const int ERR_MOVE_PTP_ABS4_AXIS2_FAIL = 227;
        public const int ERR_MOVE_PTP_ABS4_AXIS3_FAIL = 228;
        public const int ERR_MOVE_PTP_ABS4_AXIS4_FAIL = 229;
        public const int ERR_MOVE_LINE_REL2_AXIS1_FAIL = 230;
        public const int ERR_MOVE_LINE_REL2_AXIS2_FAIL = 231;
        public const int ERR_MOVE_LINE_REL2_AXIS1_SETPROFILE_FAIL = 232;
        public const int ERR_MOVE_LINE_REL2_AXIS2_SETPROFILE_FAIL = 233;
        public const int ERR_MOVE_LINE_ABS2_AXIS1_FAIL = 240;
        public const int ERR_MOVE_LINE_ABS2_AXIS2_FAIL = 241;
        public const int ERR_MOVE_LINE_ABS2_AXIS1_SETPROFILE_FAIL = 242;
        public const int ERR_MOVE_LINE_ABS2_AXIS2_SETPROFILE_FAIL = 243;
        #endregion

        public static Stopwatch TickCountWatch = new Stopwatch();
        public static int GetTickCount()
        {
            if (!TickCountWatch.IsRunning)
            {
                TickCountWatch.Start();
            }

            int D = (int)TickCountWatch.ElapsedMilliseconds;
            return D;
        }
      
        public static void ZEC_OpenPort(Ctrl.TDIOModel DIOModel)
        {
            IPAddress IP;

            try
            {
                if (!CAN_Opened)
                {
                    //Check IPAdd Valid
                    if (IPAddress.TryParse(CAN_IP, out IP))
                    {
                        Ping png = new Ping();
                        PingReply reply = png.Send(CAN_IP, 3000);
                        if (reply.Status == IPStatus.Success)
                        {
                        }
                        else
                        {
                            string EMsg = "[IOCTRL] ZEC300 OPEN LAN FAIL - NETWORK DISCONNECT";
                            throw new Exception(EMsg);
                        }
                    }
                    else
                    {
                        string EMsg = "[IOCTRL] ZEC300 OPEN LAN FAIL - INVALID IP";
                        throw new Exception(EMsg);
                    }
                    CAN_Opened = true;
                }
            }
            catch (Exception Ex) { throw Ex; }

                if (DIOModel == TDIOModel.ZM324)
                {
                    if (!ZM324Device_Opened)
                    {
                        try
                        {
                            Ctrl.zm324 = new ZM324();
                            if (!Ctrl.zm324.OpenDevice(CAN_IP))
                            {
                                string EMsg = "[IOCTRL] ZM324 OPEN DEVICE FAIL";
                                throw new Exception(EMsg);
                            }
                            ZM324Device_Opened = true;
                        }
                        catch (Exception Ex)
                        {
                            CAN_Opened = false;
                            ZM324Device_Opened = false;
                            throw Ex;
                        }
                    }
                }

                if (DIOModel == Ctrl.TDIOModel.ZIO3001)
                {
                    if (!ZIO3001Device_Opened)
                    {
                        try
                        {
                            Ctrl.zio3001 = new ZIO3001();
                            if (!Ctrl.zio3001.OpenDevice(CAN_IP))
                            {
                                string EMsg = "[IOCTRL] ZIO3001 OPEN DEVICE FAIL";
                                throw new Exception(EMsg);
                            }
                            ZIO3001Device_Opened = true;
                        }
                        catch (Exception Ex)
                        {
                            ZIO3001Device_Opened = false;
                            throw Ex;
                        }
                    }
                }

                if (DIOModel == Ctrl.TDIOModel.ZIO3201)
                {
                    if (!ZIO3201Device_Opened)
                    {
                        try
                        {
                            Ctrl.zio3201 = new ZIO3201();
                            if (!Ctrl.zio3201.OpenDevice(CAN_IP))
                            {
                                string EMsg = "[IOCTRL] ZIO3201 OPEN DEVICE FAIL";
                                throw new Exception(EMsg);
                            }
                            ZIO3201Device_Opened = true;
                        }
                        catch (Exception Ex)
                        {
                            ZIO3201Device_Opened = false;
                            throw Ex;
                        }
                    }
                }
        }
        public static void ZEC_ClosePort()
        {
            CAN_Opened = false;
            ZM324Device_Opened = false;
            ZIO3001Device_Opened = false;
            ZIO3201Device_Opened = false;
            try
            {
                CloseAllBoards();
            }
            catch
            {

            }
        }
        
        public static bool BoardOpened(int BoardID)
        {
            return ZKAOpened[BoardID];
        }
       
        public static bool OpenBoard(int BoardID, Ctrl.TDIOModel DIOModel)
        {
            try
            {
                if (!ZKAOpened[BoardID])
                {
                    ZEC_OpenPort(DIOModel);

                    if (DIOModel == TDIOModel.ZM324)
                    {
                        #region
                        //SetMotorParaRange(ref EIOCtrl.LYAxis);
                        //SetMotorParaRange(ref EIOCtrl.LZAxis);
                        //SetMotorParaRange(ref EIOCtrl.RYAxis);
                        //SetMotorParaRange(ref EIOCtrl.RZAxis);

                        if (!Ctrl.zm324.InitMotor((uint)BoardID, ZM324.MOTOR.MOTOR1))
                        {
                            string EMsg = "[IOCTRL] ZM324 BOARD" + BoardID.ToString() + " INIT MOTOR 1 - FAIL";
                            throw new Exception(EMsg);
                        }
                        if (!Ctrl.zm324.InitMotor((uint)BoardID, ZM324.MOTOR.MOTOR2))
                        {
                            string EMsg = "[IOCTRL] ZM324 BOARD" + BoardID.ToString() + " INIT MOTOR 2 - FAIL";
                            throw new Exception(EMsg);
                        }
                        if (!Ctrl.zm324.InitMotor((uint)BoardID, ZM324.MOTOR.MOTOR3))
                        {
                            string EMsg = "[IOCTRL] ZM324 BOARD" + BoardID.ToString() + " INIT MOTOR 3 - FAIL";
                            throw new Exception(EMsg);
                        }
                        if (!Ctrl.zm324.InitMotor((uint)BoardID, ZM324.MOTOR.MOTOR4))
                        {
                            string EMsg = "[IOCTRL] ZM324 BOARD" + BoardID.ToString() + " INIT MOTOR 4 - FAIL";
                            throw new Exception(EMsg);
                        }
                        #endregion
                    }
                    else
                    if (DIOModel == Ctrl.TDIOModel.ZIO3001)
                    {
                        #region
                        if (!Ctrl.zio3001.InitIO((uint)BoardID))
                        {
                            string EMsg = "[IOCTRL] DI DEVICE ZIO3001 INIT BOARD" + BoardID.ToString() + " FAIL";
                            throw new Exception(EMsg);
                        }
                        #endregion
                    }
                    else
                    if (DIOModel == Ctrl.TDIOModel.ZIO3201)
                    {
                        #region
                        if (!Ctrl.zio3201.InitIO((uint)BoardID))
                        {
                            string EMsg = "[IOCTRL] DI DEVICE ZIO3201 INIT BOARD" + BoardID.ToString() + " FAIL";
                            throw new Exception(EMsg);
                        }
                        #endregion
                    }
                    Device[BoardID] = DIOModel;
                    ZKAOpened[BoardID] = true;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

            return true;
        }
        public static void CloseBoard(int BoardID)
        {
            ZKAOpened[BoardID] = false;

            if (Device[BoardID] == TDIOModel.ZM324)
            {
                try
                {
                    Ctrl.zm324.CloseDevice();
                }
                catch { };
                ZM324Device_Opened = false;
                Device[BoardID] = TDIOModel.None;
            }

            if (Device[BoardID] == Ctrl.TDIOModel.ZIO3001)
            {
                try
                {
                    Ctrl.zio3001.CloseDevice();
                }
                catch { };
                ZIO3001Device_Opened = false;
                Device[BoardID] = TDIOModel.None;
            }

            if (Device[BoardID] == Ctrl.TDIOModel.ZIO3201)
            {
                try
                {
                    Ctrl.zio3201.CloseDevice();
                }
                catch { };
                ZIO3201Device_Opened = false;
                Device[BoardID] = TDIOModel.None;
            }
        }
        public static void CloseAllBoards()
        {
            for (int i = 0; i < 15; i++)
            {
                CloseBoard(i);
            }
        }

        public static int CANStatus
        {
            get
            {
                return (int)CAN_Status;
            }
        }
        private static void CheckCANStatus(uint BoardID, CAN_STATUS CanStatus)
        {
            //FREE = 1,
            //BUSY = 2,
            //CONNECTION_LOST = 3,
            //TIMEOUT = 4,
            //ID_OUT_RANGE = 5,
            if (CAN_Status >= CAN_STATUS.CONNECTION_LOST)
            {
                ZKAOpened[BoardID] = false;
                throw new Exception("CAN Status BoardID " + BoardID.ToString() + " - " + CanStatus.ToString());
            }
        }
        
        private static ZM324.INPUT GetZM324_rDIAdd(Ctrl.TDInput Input)
        {
            return (ZM324.INPUT)(Input.Add - 1);
        }
        private static ZM324.SENSOR GetZM324_rSDIAdd(Ctrl.TDInput Input)
        {
            return (ZM324.SENSOR)Math.Pow(2, Input.Add - 1);
        }
        private static ZM324.OUTPUT GetZM324_rDOAdd(Ctrl.TDOutput Output)
        {
            return (ZM324.OUTPUT)(Math.Pow(2, Output.Add - 1));
        }
        
        private static ZIO3201.INPUT GetZIO3201_rDIAdd(Ctrl.TDInput Input)
        {
            ZIO3201.INPUT DI = new ZIO3201.INPUT();
            if (Input.Add == 1) { DI = ZIO3201.INPUT.INPUT1; }
            if (Input.Add == 2) { DI = ZIO3201.INPUT.INPUT2; }
            if (Input.Add == 3) { DI = ZIO3201.INPUT.INPUT3; }
            if (Input.Add == 4) { DI = ZIO3201.INPUT.INPUT4; }
            if (Input.Add == 5) { DI = ZIO3201.INPUT.INPUT5; }
            if (Input.Add == 6) { DI = ZIO3201.INPUT.INPUT6; }
            if (Input.Add == 7) { DI = ZIO3201.INPUT.INPUT7; }
            if (Input.Add == 8) { DI = ZIO3201.INPUT.INPUT8; }
            if (Input.Add == 9) { DI = ZIO3201.INPUT.INPUT9; }
            if (Input.Add == 10) { DI = ZIO3201.INPUT.INPUT10; }

            if (Input.Add == 11) { DI = ZIO3201.INPUT.INPUT11; }
            if (Input.Add == 12) { DI = ZIO3201.INPUT.INPUT12; }
            if (Input.Add == 13) { DI = ZIO3201.INPUT.INPUT13; }
            if (Input.Add == 14) { DI = ZIO3201.INPUT.INPUT14; }
            if (Input.Add == 15) { DI = ZIO3201.INPUT.INPUT15; }
            if (Input.Add == 16) { DI = ZIO3201.INPUT.INPUT16; }
            if (Input.Add == 17) { DI = ZIO3201.INPUT.INPUT17; }
            if (Input.Add == 18) { DI = ZIO3201.INPUT.INPUT18; }
            if (Input.Add == 19) { DI = ZIO3201.INPUT.INPUT19; }
            if (Input.Add == 20) { DI = ZIO3201.INPUT.INPUT20; }

            if (Input.Add == 21) { DI = ZIO3201.INPUT.INPUT21; }
            if (Input.Add == 22) { DI = ZIO3201.INPUT.INPUT22; }
            if (Input.Add == 23) { DI = ZIO3201.INPUT.INPUT23; }
            if (Input.Add == 24) { DI = ZIO3201.INPUT.INPUT24; }
            if (Input.Add == 25) { DI = ZIO3201.INPUT.INPUT25; }
            if (Input.Add == 26) { DI = ZIO3201.INPUT.INPUT26; }
            if (Input.Add == 27) { DI = ZIO3201.INPUT.INPUT27; }
            if (Input.Add == 28) { DI = ZIO3201.INPUT.INPUT28; }
            if (Input.Add == 29) { DI = ZIO3201.INPUT.INPUT29; }
            if (Input.Add == 30) { DI = ZIO3201.INPUT.INPUT30; }

            if (Input.Add == 31) { DI = ZIO3201.INPUT.INPUT31; }
            if (Input.Add == 32) { DI = ZIO3201.INPUT.INPUT32; }
            if (Input.Add == 33) { DI = ZIO3201.INPUT.INPUT33; }
            if (Input.Add == 34) { DI = ZIO3201.INPUT.INPUT34; }
            if (Input.Add == 35) { DI = ZIO3201.INPUT.INPUT35; }
            if (Input.Add == 36) { DI = ZIO3201.INPUT.INPUT36; }
            if (Input.Add == 37) { DI = ZIO3201.INPUT.INPUT37; }
            if (Input.Add == 38) { DI = ZIO3201.INPUT.INPUT38; }
            if (Input.Add == 39) { DI = ZIO3201.INPUT.INPUT39; }

            return DI;
        }
        private static ZIO3201.OUTPUT GetZIO3201_rDOAdd(Ctrl.TDOutput Output)
        {
            return (ZIO3201.OUTPUT)(Math.Pow(2, Output.Add - 1));

            //ZIO3201.OUTPUT DO = new ZIO3201.OUTPUT();
            //if (Output.Add == 1) { DO = ZIO3201.OUTPUT.OUTPUT1; }
            //if (Output.Add == 2) { DO = ZIO3201.OUTPUT.OUTPUT2; }
            //if (Output.Add == 3) { DO = ZIO3201.OUTPUT.OUTPUT3; }
            //if (Output.Add == 4) { DO = ZIO3201.OUTPUT.OUTPUT4; }
            //if (Output.Add == 5) { DO = ZIO3201.OUTPUT.OUTPUT5; }
            //if (Output.Add == 6) { DO = ZIO3201.OUTPUT.OUTPUT6; }
            //if (Output.Add == 7) { DO = ZIO3201.OUTPUT.OUTPUT7; }
            //if (Output.Add == 8) { DO = ZIO3201.OUTPUT.OUTPUT8; }
            //if (Output.Add == 9) { DO = ZIO3201.OUTPUT.OUTPUT9; }
            //if (Output.Add == 10) { DO = ZIO3201.OUTPUT.OUTPUT10; }

            //if (Output.Add == 11) { DO = ZIO3201.OUTPUT.OUTPUT11; }
            //if (Output.Add == 12) { DO = ZIO3201.OUTPUT.OUTPUT12; }
            //if (Output.Add == 13) { DO = ZIO3201.OUTPUT.OUTPUT13; }
            //if (Output.Add == 14) { DO = ZIO3201.OUTPUT.OUTPUT14; }
            //if (Output.Add == 15) { DO = ZIO3201.OUTPUT.OUTPUT15; }
            //if (Output.Add == 16) { DO = ZIO3201.OUTPUT.OUTPUT16; }
            //if (Output.Add == 17) { DO = ZIO3201.OUTPUT.OUTPUT17; }
            //if (Output.Add == 18) { DO = ZIO3201.OUTPUT.OUTPUT18; }
            //if (Output.Add == 19) { DO = ZIO3201.OUTPUT.OUTPUT19; }
            //if (Output.Add == 20) { DO = ZIO3201.OUTPUT.OUTPUT20; }

            //if (Output.Add == 21) { DO = ZIO3201.OUTPUT.OUTPUT21; }
            //if (Output.Add == 22) { DO = ZIO3201.OUTPUT.OUTPUT22; }
            //if (Output.Add == 23) { DO = ZIO3201.OUTPUT.OUTPUT23; }
            //if (Output.Add == 24) { DO = ZIO3201.OUTPUT.OUTPUT24; }
            //if (Output.Add == 25) { DO = ZIO3201.OUTPUT.OUTPUT25; }
            //if (Output.Add == 26) { DO = ZIO3201.OUTPUT.OUTPUT26; }
            //if (Output.Add == 27) { DO = ZIO3201.OUTPUT.OUTPUT27; }
            //if (Output.Add == 28) { DO = ZIO3201.OUTPUT.OUTPUT28; }
            //if (Output.Add == 29) { DO = ZIO3201.OUTPUT.OUTPUT29; }
            //if (Output.Add == 30) { DO = ZIO3201.OUTPUT.OUTPUT30; }

            //if (Output.Add == 31) { DO = ZIO3201.OUTPUT.OUTPUT31; }
            //if (Output.Add == 32) { DO = ZIO3201.OUTPUT.OUTPUT32; }
            //if (Output.Add == 33) { DO = ZIO3201.OUTPUT.OUTPUT33; }
            //if (Output.Add == 34) { DO = ZIO3201.OUTPUT.OUTPUT34; }
            //if (Output.Add == 35) { DO = ZIO3201.OUTPUT.OUTPUT35; }
            //if (Output.Add == 36) { DO = ZIO3201.OUTPUT.OUTPUT36; }

            //return DO;
        }
        private static ulong GetZIO3201_Bit(Ctrl.TDOutput Output)
        {
            return (ulong)(Math.Pow(2, Output.Add - 1));
        }
        private static ZIO3001.INPUT GetZIO3001_rDIAdd(Ctrl.TDInput Input)
        {
            return (ZIO3001.INPUT)(Input.Add - 1);
        }
        private static ZIO3001.OUTPUT GetZIO3001_rDOAdd(Ctrl.TDOutput Output)
        {
            return (ZIO3001.OUTPUT)(Math.Pow(2, Output.Add - 1));
        }

        private static bool ZIO3x01_UpdateInput(ref Ctrl.TDInput Input)
        {
            if (!Ctrl.BoardOpened(Input.BoardID)) return false;

            if (Input.NA)
            {
                Input.Status = false;
                return false;
            }

            try
            {
                switch (Input.DIOModel)
                {
                    case TDIOModel.ZIO3001:
                        Ctrl.zio3001.UpdateDigitalInputStatus(Input.BoardID);
                        break;
                    case TDIOModel.ZIO3201:
                    default:
                        Ctrl.zio3201.UpdateDigitalInputStatus(Input.BoardID);
                        break;
                }

                #region IOCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);
                    switch (Input.DIOModel)
                    {
                        case TDIOModel.ZIO3001:
                            CheckDone = Ctrl.zio3001.IOCheckDone(Input.BoardID);
                            break;
                        case TDIOModel.ZIO3201:
                        default:
                            CheckDone = Ctrl.zio3201.IOCheckDone(Input.BoardID);
                            break;
                    }

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = EMsg = "UPDATE INPUT TIMEOUT";
                        throw new Exception(EMsg);
                    }
                }
                #endregion

                uint value = 1;
                switch (Input.DIOModel)
                {
                    case TDIOModel.ZIO3001:
                        CAN_Status = Ctrl.zio3201.GetDigitalInputStatus(Input.BoardID, Ctrl.GetZIO3201_rDIAdd(Input), out value, true);
                        break;
                    case TDIOModel.ZIO3201:
                    default:
                        CAN_Status = Ctrl.zio3201.GetDigitalInputStatus(Input.BoardID, Ctrl.GetZIO3201_rDIAdd(Input), out value, true);
                        break;
                }
                CheckCANStatus(Input.BoardID, CAN_Status);

                if (value.ToString() == "0")
                    Input.Status = true;
                else
                    Input.Status = false;
            }
            catch { };

            return true;
        }
        private static bool ZIO3x01_OutputHi(ref Ctrl.TDOutput Output)
        {
            if (!Ctrl.BoardOpened(Output.BoardID)) return false;

            if (Output.NA) { return false; }
        
            try
            {
                switch (Output.DIOModel)
                {
                    case Ctrl.TDIOModel.ZIO3001:
                        {
                            ZIO3001.OUTPUT DO = new ZIO3001.OUTPUT();
                            DO = Ctrl.GetZIO3001_rDOAdd(Output);
                            Ctrl.zio3001.DigitalOut(Output.BoardID, (uint)DO, 0);
                            break;
                        }
                    case Ctrl.TDIOModel.ZIO3201:
                    default:
                        {
                            //ZIO3201.OUTPUT uDO = new ZIO3201.OUTPUT();
                            ulong uDO = Ctrl.GetZIO3201_Bit(Output);
                            Ctrl.zio3201.DigitalOut(Output.BoardID, uDO, 0);
                            break;
                        }
                }

                #region IOCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);
                    switch (Output.DIOModel)
                    {
                        case Ctrl.TDIOModel.ZIO3001:
                            CheckDone = Ctrl.zio3001.IOCheckDone(Output.BoardID);
                            break;
                        case Ctrl.TDIOModel.ZIO3201:
                        default:
                            CheckDone = Ctrl.zio3201.IOCheckDone(Output.BoardID);
                            break;
                    }

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "OUTPUT SET HI TIMEOUT";
                        throw new Exception(EMsg);
                    }
                }
                #endregion

                uint i_value = 1;
                uint u_value = 1;
                switch (Output.DIOModel)
                {
                    case TDIOModel.ZIO3001:
                        ZIO3001.OUTPUT DO = new ZIO3001.OUTPUT();
                        DO = Ctrl.GetZIO3001_rDOAdd(Output);
                        CAN_Status = Ctrl.zio3001.GetDigitalOutputStatus((uint)Output.BoardID, DO, out i_value, true);
                        break;
                    case TDIOModel.ZIO3201:
                    default:
                        ZIO3201.OUTPUT uDO = new ZIO3201.OUTPUT();
                        uDO = (ZIO3201.OUTPUT)Ctrl.GetZIO3201_rDOAdd(Output);
                        CAN_Status = Ctrl.zio3201.GetDigitalOutputStatus((uint)Output.BoardID, uDO, out u_value, true);
                        break;
                }
                CheckCANStatus(Output.BoardID, CAN_Status);

                Output.Status = true;
            }
            catch { }

            return true;
        }
        private static bool ZIO3x01_OutputLo(ref Ctrl.TDOutput Output)
        {
            if (!Ctrl.BoardOpened(Output.BoardID)) return false;

            if (Output.NA) { return false; }

            try
            {
                switch (Output.DIOModel)
                {
                    case Ctrl.TDIOModel.ZIO3001:
                        {
                            ZIO3001.OUTPUT DO = new ZIO3001.OUTPUT();
                            DO = Ctrl.GetZIO3001_rDOAdd(Output);
                            Ctrl.zio3001.DigitalOut(Output.BoardID, 0, (uint)DO);
                            break;
                        }
                    case Ctrl.TDIOModel.ZIO3201:
                    default:
                        {
                            //ZIO3201.OUTPUT uDO = new ZIO3201.OUTPUT();
                            ulong uDO = Ctrl.GetZIO3201_Bit(Output);
                            Ctrl.zio3201.DigitalOut(Output.BoardID, 0, uDO);
                            break;
                        }
                }

                #region IOCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    switch (Output.DIOModel)
                    {
                        case Ctrl.TDIOModel.ZIO3001:
                            CheckDone = Ctrl.zio3001.IOCheckDone(Output.BoardID);
                            break;
                        case Ctrl.TDIOModel.ZIO3201:
                        default:
                            CheckDone = Ctrl.zio3201.IOCheckDone(Output.BoardID);
                            break;
                    }
                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "OUTPUT SET LO TIMEOUT";
                        throw new Exception(EMsg);
                    }
                }
                #endregion

                uint i_value = 1;
                uint u_value = 1;
                switch (Output.DIOModel)
                {
                    case TDIOModel.ZIO3001:
                        ZIO3001.OUTPUT DO = new ZIO3001.OUTPUT();
                        DO = Ctrl.GetZIO3001_rDOAdd(Output);
                        CAN_Status = Ctrl.zio3001.GetDigitalOutputStatus((uint)Output.BoardID, DO, out i_value, true);
                        break;
                    case TDIOModel.ZIO3201:
                    default:
                        ZIO3201.OUTPUT uDO = new ZIO3201.OUTPUT();
                        CAN_Status = Ctrl.zio3201.GetDigitalOutputStatus((uint)Output.BoardID, uDO, out u_value, true);
                        break;
                }
                CheckCANStatus(Output.BoardID, CAN_Status);

                Output.Status = false;
            }
            catch { };

            return true;
        }

        /// <summary>
        /// Update MotorPara Min Max values. Uses value of DistPerPulse. Exception if error.
        /// </summary>
        /// <param name="Axis"></param>
        public static void ZM3xx_UpdateMotorParaRange(ref Ctrl.TAxis Axis)
        {
            if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
            {
                double Ratio = Axis.MotorPara.DistPerPulse;

                CAN_STATUS CAN_Status;

                //Accel
                uint MinAccel = 0;
                zm324.GetMinProfileAccelRate((uint)Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, out MinAccel, false);
                //CheckCANStatus(Axis.BoardID, CAN_Status);
                Axis.MotorPara.MinAccel = MinAccel * Axis.MotorPara.DistPerPulse;

                uint MaxAccel = 0;
                zm324.GetMaxProfileAccelRate((uint)Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, out MaxAccel, false);
                Axis.MotorPara.MaxAccel = MaxAccel * Axis.MotorPara.DistPerPulse; 

                //Speed
                uint MinSpeed = 0;
                zm324.GetMinProfileSpeed((uint)Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, out MinSpeed, false);
                Axis.MotorPara.MinSpeed = MinSpeed * Axis.MotorPara.DistPerPulse; 

                uint MaxSpeed = 0;
                zm324.GetMaxProfileSpeed((uint)Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, out MaxSpeed, false);
                Axis.MotorPara.MaxSpeed = MaxSpeed * Axis.MotorPara.DistPerPulse;

                uint MinConstSpeed = 0;
                zm324.GetMinConstantSpeed((uint)Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, out MinConstSpeed, false);
                Axis.MotorPara.MinConstSpeed = MinConstSpeed * Axis.MotorPara.DistPerPulse;

                uint MaxConstSpeed = 0;
                zm324.GetMaxConstantSpeed((uint)Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, out MaxConstSpeed, false);
                Axis.MotorPara.MaxConstSpeed = MaxConstSpeed * Axis.MotorPara.DistPerPulse;
            }
        }

        public static bool ZM3xx_MotorOn(ref Ctrl.TAxis Axis)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            if (!Axis.MotorPara.InvertMtrOn)
            {
                if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    if (!Ctrl.zm324.SetEnablePinHigh(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID))
                        throw new Exception("ZM324 - MOTOR ON FAIL");
                }
            }
            else
            {
                if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    if (!Ctrl.zm324.SetEnablePinLow(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID))
                        throw new Exception("ZM324 - MOTOR ON FAIL");
                }
            }

            int t = GetTickCount() + 50;
            while (GetTickCount() > t)
            {
                Thread.Sleep(0);
            }

            Axis.MotorStatus = true;
            return true;
        }
        public static bool ZM3xx_MotorOff(ref Ctrl.TAxis Axis)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            if (!Axis.MotorPara.InvertMtrOn)
            {
                if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    if (!Ctrl.zm324.SetEnablePinLow(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID))
                        throw new Exception("ZM324 - MOTOR OFF FAIL");
                }
            }
            else
            {
                if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    if (!Ctrl.zm324.SetEnablePinHigh(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID))
                        throw new Exception("ZM324 - MOTOR OFF FAIL");
                }
            }

            int t = GetTickCount() + 50;
            while (GetTickCount() > t)
            {
                Thread.Sleep(50);
            }

            Axis.MotorStatus = false;
            return true;
        }
        public static bool ZM3xx_RLPos(Ctrl.TAxis Axis, ref double Pos)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            int rPos = 0;
            Ctrl.CANMutex.WaitOne();
            try
            {
                Ctrl.zm324.GetCurrentPosition(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, out rPos, false);
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }

            Pos = (double)(rPos * Axis.MotorPara.DistPerPulse);
            if (Axis.MotorPara.InvertDir) { Pos = -Pos; }

            return true;
        }
        public static bool ZM3xx_WLPos(Ctrl.TAxis Axis, double Pos)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            int i_Pos = (int)(Pos / Axis.MotorPara.DistPerPulse);
            if (Axis.MotorPara.InvertDir) { i_Pos = -i_Pos; }

            Ctrl.CANMutex.WaitOne();
            try
            {
                Ctrl.zm324.SetPositionCounter(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, i_Pos);

                #region MotorCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.MotorCheckDone(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID);

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                            EMsg = "ZM324 - WLPOS TIMEOUT";

                        throw new Exception(EMsg);
                    }
                }
                #endregion
                return true;
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
        }

        public static bool ZM3xx_SetMotionParam(ref Ctrl.TAxis Axis, double StartV, double DriveV, double Accel)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            Ctrl.CANMutex.WaitOne();
            try
            {
                Axis.MotorPara.PsntSpeed = DriveV;
                uint DV = (uint)(DriveV / Axis.MotorPara.DistPerPulse);

                if (DriveV < StartV) StartV = DriveV;

                Axis.MotorPara.PsntStartV = StartV;
                uint SV = (uint)(StartV / Axis.MotorPara.DistPerPulse);

                Axis.MotorPara.PsntAccel = Accel;
                uint AC = (uint)(Accel / Axis.MotorPara.DistPerPulse);

                if (StartV < Axis.MotorPara.MinSpeed || StartV > Axis.MotorPara.MaxSpeed)
                {
                    throw new Exception("ZM3x4 SET MOTION PARAM START SPEED NOT IN RANGE");
                }
                if (DriveV < Axis.MotorPara.MinSpeed || DriveV > Axis.MotorPara.MaxSpeed)
                {
                    throw new Exception("ZM3x4 SET MOTION PARAM DRIVE SPEED NOT IN RANGE");
                }
                if (Accel < Axis.MotorPara.MinAccel || Accel > Axis.MotorPara.MaxAccel)
                {
                    throw new Exception("ZM3x4 SET MOTION PARAM ACCEL NOT IN RANGE");
                }

                if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    if (!Ctrl.zm324.SetTrapezoidalProfile(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, SV, DV, AC))
                    {
                        throw new Exception("ZM3x4 SET MOTION PARAM - FAIL");
                    }
                }

                #region MotorCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.MotorCheckDone(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID);

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                            EMsg = "ZM324 - SET MOTION PARAM TIMEOUT";

                        throw new Exception(EMsg);
                    }
                }
                #endregion
                return true;
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
        }

        public static bool ZM3xx_MovePtpRel1(Ctrl.TAxis Axis, double Dist)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            Ctrl.CANMutex.WaitOne();
            try
            {
                int i_Pulse = (int)(Dist / Axis.MotorPara.DistPerPulse);
                if (Axis.MotorPara.InvertDir) i_Pulse = -i_Pulse;

                if (!Ctrl.zm324.ProfileMove(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID,
                                                  ZM324.PROFILE_TYPE.TRAPEZOIDAL,
                                                  i_Pulse, 0x00, 0x00, true))
                {
                    throw new Exception("ZM324 MOVE PTP REL 1 - FAIL");
                }
                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception("ZM324 MOVE PTP REL 1" + (char)13 + Ex.Message);
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
        }
        public static bool ZM3xx_MovePtpAbs1(Ctrl.TAxis Axis, double Pos)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;


            Ctrl.CANMutex.WaitOne();
            try
            {
                int i_Tgt = (int)(Pos / Axis.MotorPara.DistPerPulse);
                if (Axis.MotorPara.InvertDir) i_Tgt = -i_Tgt;

                int i_Pos = 0;
                CAN_Status = Ctrl.zm324.GetCurrentPosition(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, out i_Pos, true);
                try
                {
                    CheckCANStatus(Axis.BoardID, CAN_Status);
                }
                catch { throw; }

                int i_Pulse = i_Tgt - i_Pos;

                if (!Ctrl.zm324.ProfileMove(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID,
                                                  ZM324.PROFILE_TYPE.TRAPEZOIDAL,
                                                  i_Pulse, 0x00, 0x00, true))
                {
                    throw new Exception("ZM324 MOVE PTP ABS 1 - FAIL");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("ZM324 MOVE PTP ABS 1" + (char)13 + Ex.Message);
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
            return true;
        }

        public static bool ZM3xx_MoveConst(Ctrl.TAxis Axis, double Speed, double Dist)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            Ctrl.CANMutex.WaitOne();
            try
            {
                uint SP = (uint)(Speed / Axis.MotorPara.DistPerPulse);

                int i_Pulse = (int)(Dist / Axis.MotorPara.DistPerPulse);
                if (Axis.MotorPara.InvertDir) i_Pulse = -i_Pulse;

                zm324.ConstantSpeedMove((uint)Axis.BoardID, (ZM324.MOTOR)Axis.AxisID, i_Pulse, SP, 0x00, 0x00);
            }
            catch (Exception Ex)
            {
                throw new Exception("ZM3XX MOVE CONST SPEED " + (char)13 + Ex.Message);
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
            return true;
        }

        public static bool ZM3xx_ForceStop(Ctrl.TAxis Axis)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            Ctrl.CANMutex.WaitOne();
            try
            {
                if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                    Ctrl.zm324.AbortMotion(Axis.BoardID, (ZM324.MOTOR)Axis.AxisID);
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
            return true;
        }
        public static bool ZM3xx_AxisWait(Ctrl.TAxis Axis, int TimeOut)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            int TOut = GetTickCount() + TimeOut;
            
            if (Axis.AxisID == (int)ZM324.MOTOR.MOTOR1)
            {
                #region
                bool CheckDone = false;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.MotorCheckDone(Axis.BoardID, ZM324.MOTOR.MOTOR1);

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                            EMsg = "ZM324 - AXIS1 WAIT TIMEOUT";

                        throw new Exception(EMsg);
                    }
                }
                #endregion              
            }

            if (Axis.AxisID == (int)ZM324.MOTOR.MOTOR2)
            {
                #region
                bool CheckDone = false;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.MotorCheckDone(Axis.BoardID, ZM324.MOTOR.MOTOR2);

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                            EMsg = "ZM324 - AXIS2 WAIT TIMEOUT";

                        throw new Exception(EMsg);
                    }
                }
                #endregion
            }

            if (Axis.AxisID == (int)ZM324.MOTOR.MOTOR3)
            {
                #region
                bool CheckDone = false;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.MotorCheckDone(Axis.BoardID, ZM324.MOTOR.MOTOR3);

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                            EMsg = "ZM324 - AXIS3 WAIT TIMEOUT";

                        throw new Exception(EMsg);
                    }
                }
                #endregion
            }

            if (Axis.AxisID == (int)ZM324.MOTOR.MOTOR4)
            {
                #region
                bool CheckDone = false;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.MotorCheckDone(Axis.BoardID, ZM324.MOTOR.MOTOR4);

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                            EMsg = "ZM324 - AXIS4 WAIT TIMEOUT";

                        throw new Exception(EMsg);
                    }
                }
                #endregion
            }
            return true;
        }
        public static bool ZM3xx_AxisBusy(Ctrl.TAxis Axis)
        {
            if (!Ctrl.BoardOpened(Axis.BoardID)) return false;

            bool Busy = false;
            Ctrl.CANMutex.WaitOne();
            try
            {
                if (Axis.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    if (Axis.AxisID == (int)ZM324.MOTOR.MOTOR1)
                    {
                        Busy = !Ctrl.zm324.MotorCheckDone(Axis.BoardID, ZM324.MOTOR.MOTOR1);
                    }

                    if (Axis.AxisID == (int)ZM324.MOTOR.MOTOR2)
                    {
                        Busy = !Ctrl.zm324.MotorCheckDone(Axis.BoardID, ZM324.MOTOR.MOTOR2);
                    }

                    if (Axis.AxisID == (int)ZM324.MOTOR.MOTOR3)
                    {
                        Busy = !Ctrl.zm324.MotorCheckDone(Axis.BoardID, ZM324.MOTOR.MOTOR3);
                    }

                    if (Axis.AxisID == (int)ZM324.MOTOR.MOTOR4)
                    {
                        Busy = !Ctrl.zm324.MotorCheckDone(Axis.BoardID, ZM324.MOTOR.MOTOR4);
                    }
                }
            }
            catch { }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
            return Busy;
        }

        #region ZM3xx IO
        private static bool ZM3xx_UpdateInput(ref Ctrl.TDInput Input)
        {
            if (!Ctrl.BoardOpened(Input.BoardID)) return false;

            if (Input.NA)
            {
                Input.Status = false;
                return false;
            }

            try
            {
                if (Input.DIOModel == Ctrl.TDIOModel.ZM324)
                    Ctrl.zm324.UpdateDigitalInputStatus(Input.BoardID);

                #region IOCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Input.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.IOCheckDone(Input.BoardID);
                }
                #endregion

                uint value = 1;
                if (Input.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    if (Input.AxisID == 0)
                        CAN_Status = Ctrl.zm324.GetDigitalInputStatus(Input.BoardID, Ctrl.GetZM324_rDIAdd(Input), out value, true);
                    else
                        if (Input.Add == 5)
                            CAN_Status = Ctrl.zm324.GetMotorSensorStatus(Input.BoardID, (ZM324.MOTOR)Input.AxisID, ZKA.ZM324.SENSOR.IN_POSITION, out value, false);
                        else
                            CAN_Status = Ctrl.zm324.GetMotorSensorStatus(Input.BoardID, (ZM324.MOTOR)Input.AxisID, Ctrl.GetZM324_rSDIAdd(Input), out value, true);
                }
                CheckCANStatus(Input.BoardID, CAN_Status);

                if (value.ToString() == "0")
                    Input.Status = true;
                else
                    Input.Status = false;
            }
            catch { };

            //Ctrl.CANMutex.ReleaseMutex();
            return true;
        }
        private static bool ZM3xx_OutputHi(ref Ctrl.TDOutput Output)
        {
            if (!Ctrl.BoardOpened(Output.BoardID)) return false;

            if (Output.NA) { return false; }

            try
            {
                if (Output.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    ZM324.OUTPUT DO = new ZM324.OUTPUT();
                    DO = Ctrl.GetZM324_rDOAdd(Output);
                    Ctrl.zm324.DigitalOut(Output.BoardID, (byte)DO, 0);
                }

                #region IOCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Output.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.IOCheckDone(Output.BoardID);

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        if (Output.DIOModel == Ctrl.TDIOModel.ZM324)
                            EMsg = "ZM324 - OUTPUT SET HI TIMEOUT";

                        throw new Exception(EMsg);
                    }
                }
                #endregion

                uint value = 0;
                CAN_Status = Ctrl.zm324.GetDigitalOutputStatus((uint)Output.BoardID, Ctrl.GetZM324_rDOAdd(Output), out value, true);
                CheckCANStatus(Output.BoardID, CAN_Status);

                Output.Status = true;
            }
            catch { };

            //Ctrl.CANMutex.ReleaseMutex();
            return true;
        }
        private static bool ZM3xx_OutputLo(ref Ctrl.TDOutput Output)
        {
            if (!Ctrl.BoardOpened(Output.BoardID)) return false;

            if (Output.NA) { return false; }

            try
            {
                if (Output.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    ZM324.OUTPUT DO = new ZM324.OUTPUT();
                    DO = Ctrl.GetZM324_rDOAdd(Output);
                    Ctrl.zm324.DigitalOut(Output.BoardID, 0, (byte)DO);
                }

                #region IOCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    if (Output.DIOModel == Ctrl.TDIOModel.ZM324)
                        CheckDone = Ctrl.zm324.IOCheckDone(Output.BoardID);

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        if (Output.DIOModel == Ctrl.TDIOModel.ZM324)
                            EMsg = "ZM324 - OUTPUT SET LO TIMEOUT";

                        throw new Exception(EMsg);
                    }
                }
                #endregion

                Output.Status = false;
            }
            catch { };

            return true;
        }
        #endregion

        #region Common IO
        public static bool GetDI(ref Ctrl.TDInput DI)
        {
            if (!Ctrl.BoardOpened(DI.BoardID)) return false;

            Ctrl.CANMutex.WaitOne();
            try
            {
                if (DI.DIOModel == Ctrl.TDIOModel.ZIO3001 || DI.DIOModel == Ctrl.TDIOModel.ZIO3201)
                {
                    #region
                    Ctrl.ZIO3x01_UpdateInput(ref DI);
                    if (DI.Status)
                        return true;
                    else
                        return false;
                    #endregion
                }
                else
                    if (DI.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    #region
                    Ctrl.ZM3xx_UpdateInput(ref DI);
                    if (DI.Status)
                        return true;
                    else
                        return false;
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                string EMsg = DI.Name + " - " + DI.DIOModel.ToString() + " BOARD" + DI.BoardID.ToString();// +" NO OPENED";
                throw new Exception("[IOCTRL] GET DI FAIL (" + EMsg + ") - " + Ex.Message.ToString());
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
            return false;
        }
        public static bool SetDO(ref Ctrl.TDOutput DO, Ctrl.TDOStatus Status)
        {
            if (!BoardOpened(DO.BoardID)) return false;

            CANMutex.WaitOne();
            try
            {
                if ((DO.DIOModel == Ctrl.TDIOModel.ZIO3001) || (DO.DIOModel == Ctrl.TDIOModel.ZIO3201))
                {
                    #region
                    switch (Status)
                    {
                        case Ctrl.TDOStatus.Hi:
                            Ctrl.ZIO3x01_OutputHi(ref DO);
                            break;
                        case Ctrl.TDOStatus.Lo:
                            Ctrl.ZIO3x01_OutputLo(ref DO);
                            break;
                    }

                    if (DO.Status)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    #endregion
                }
                else
                if (DO.DIOModel == Ctrl.TDIOModel.ZM324)
                {
                    #region
                    switch (Status)
                    {
                        case Ctrl.TDOStatus.Hi:
                            ZM3xx_OutputHi(ref DO);
                            break;
                        case Ctrl.TDOStatus.Lo:
                            ZM3xx_OutputLo(ref DO);
                            break;
                    }

                    if (DO.Status)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                string EMsg = DO.Name + " - " + DO.DIOModel.ToString() + " BOARD" + DO.BoardID.ToString();
                throw new Exception("[IOCTRL] SET DO FAIL (" + EMsg + ") - " + Ex.Message.ToString());
            }
            finally
            {
                CANMutex.ReleaseMutex();
            }
            return false;
        }
        #endregion

        /// <summary>
        /// Set PWM Frequency
        /// </summary>
        /// <param name="BoardID"></param>
        /// <param name="DIOModel"></param>
        /// <param name="Freq">Hz(1~200000)</param>
        /// <returns></returns>
        public static bool SetPWMFreq(byte BoardID, Ctrl.TDIOModel DIOModel, uint Freq)
        {
            if (!Ctrl.BoardOpened(BoardID)) return false;

            if (Freq < 0 || Freq > 200000)
            {
                string EMsg = "SET FREQUENCY OUT OF RANGE";
                throw new Exception(EMsg);
            }

            Ctrl.CANMutex.WaitOne();
            try
            {
                switch (DIOModel)
                {
                    case Ctrl.TDIOModel.ZM324:
                        if (!Ctrl.zm324.SetPWMFrequency(BoardID, Freq))
                        {
                            string EMsg = "ZM324 - SET FREQUENCY FAIL";
                            throw new Exception(EMsg);
                        }
                        break;
                    case Ctrl.TDIOModel.ZIO3001:
                        if (!Ctrl.zio3001.SetPWMFrequency(BoardID, Freq))
                        {
                            string EMsg = "ZIO3001 - SET FREQUENCY FAIL";
                            throw new Exception(EMsg);
                        }
                        break;
                    case Ctrl.TDIOModel.ZIO3201:
                    default:
                        if (!Ctrl.zio3201.SetPWMFrequency(BoardID, Freq))
                        {
                            string EMsg = "ZIO3201 - SET FREQUENCY FAIL";
                            throw new Exception(EMsg);
                        }
                        break;
                }

                #region IOCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    switch (DIOModel)
                    {
                        case Ctrl.TDIOModel.ZM324:
                            CheckDone = Ctrl.zm324.IOCheckDone(BoardID);
                            break;
                        case Ctrl.TDIOModel.ZIO3001:
                            CheckDone = Ctrl.zio3001.IOCheckDone(BoardID);
                            break;
                        case Ctrl.TDIOModel.ZIO3201:
                        default:
                            CheckDone = Ctrl.zio3201.IOCheckDone(BoardID);
                            break;
                    }
                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "SET FREQUENCY TIMEOUT";
                        throw new Exception(EMsg);
                    }
                }
                #endregion
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
            return true;
        }
        /// <summary>
        /// Set Duty Cycle
        /// </summary>
        /// <param name="BoardID"></param>
        /// <param name="DIOModel"></param>
        /// <param name="CH"></param>
        /// <param name="DutyCycle">0.1%(1~1000)</param>
        /// <returns></returns>
        public static bool SetPWMDutyCycle(byte BoardID, Ctrl.TDIOModel DIOModel, uint CH, uint DutyCycle) //Added 151211
        {
            if (!Ctrl.BoardOpened((int)BoardID)) return false;

            if (DutyCycle < 0 || DutyCycle > 1000)
            {
                string EMsg = "SET FREQUENCY OUT OF RANGE";
                throw new Exception(EMsg);
            }

            Ctrl.CANMutex.WaitOne();
            try
            {
                switch (DIOModel)
                {
                    case TDIOModel.ZIO3001:
                        if (!Ctrl.zio3001.PWMOut(BoardID, (ZKA.ZIO3001.PWM)CH, DutyCycle))
                        {
                            string EMsg = "ZIO3001 - SET PWM OUT FAIL";
                            throw new Exception(EMsg);
                        }
                        break;
                    case TDIOModel.ZIO3201:
                    default:
                        if (!Ctrl.zio3201.PWMOut(BoardID, (ZKA.ZIO3201.PWM)CH, DutyCycle))
                        {
                            string EMsg = "ZIO3201 - SET PWM OUT FAIL";
                            throw new Exception(EMsg);
                        }

                        break;
                    case TDIOModel.ZM324:
                        if (!Ctrl.zm324.PWMOut(BoardID, (ZKA.ZM324.PWM)CH, DutyCycle))
                        {
                            string EMsg = "ZM324 - SET PWM OUT FAIL";
                            throw new Exception(EMsg);
                        }
                        break;
                }

                #region IOCheckDone
                bool CheckDone = false;
                int TOut = GetTickCount() + IOWaitTimeOut;
                while (!CheckDone)
                {
                    Thread.Sleep(0);

                    switch (DIOModel)
                    {
                        case TDIOModel.ZIO3001:
                            CheckDone = Ctrl.zio3001.IOCheckDone(BoardID);
                            break;
                        case TDIOModel.ZIO3201:
                            CheckDone = Ctrl.zio3201.IOCheckDone(BoardID);
                            break;
                        case TDIOModel.ZM324:
                            CheckDone = Ctrl.zm324.IOCheckDone(BoardID);
                            break;
                        default:
                            throw new Exception("DIOModel not supported.");
                    }

                    if (GetTickCount() >= TOut)
                    {
                        string EMsg = "";
                        EMsg = "SET PWM OUT TIMEOUT";
                        throw new Exception(EMsg);
                    }
                }
                #endregion
            }
            finally
            {
                Ctrl.CANMutex.ReleaseMutex();
            }
            return true;
        }
        /// <summary>
        /// Set PWM Frequency
        /// </summary>
        /// <param name="PWMOutput">TPWMOutput</param>
        /// <param name="Freq">Hz(1~200000)</param>
        /// <returns></returns>
        public static bool SetPWMFreq(ref TPWMOutput PWMOutput, uint Freq)
        {
            PWMOutput.Freq = Freq;
            return Ctrl.SetPWMFreq(PWMOutput.BoardID, PWMOutput.DIOModel, Freq);
        }
        /// <summary>
        /// Set Duty Cycle
        /// </summary>
        /// <param name="PWMOutput">TPWMOutput</param>
        /// <param name="DutyCycle">0.1%(1~1000)</param>
        /// <returns></returns>
        public static bool SetPWMDutyCycle(ref TPWMOutput PWMOutput, uint DutyCycle)
        {
            PWMOutput.DutyCycle = DutyCycle;
            return Ctrl.SetPWMDutyCycle(PWMOutput.BoardID, PWMOutput.DIOModel, PWMOutput.Add, DutyCycle);
        }
    }
}
