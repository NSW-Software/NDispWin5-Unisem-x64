using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections;
using WGH_Series;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;

namespace NDispWin
{
    class GDefineMHS
    {
        public static void RefreshInput(object sender, bool B)
        {
            if (B)
            {
                (sender as Label).BackColor = Color.Lime;
            }
            else
            {
                (sender as Label).BackColor = SystemColors.Control;
            }
        }
        public static void RefreshInput(object sender, ZEC3002.Ctrl.TDInput DI)
        {
            (sender as Label).Text = DI.Name;

            if (!ZEC3002.Ctrl.BoardOpened(DI.BoardID)) 
            { return; }

            try
            {
                ZEC3002.Ctrl.GetDI(ref DI);
            }
            catch { };
            if (DI.Status)
            {
                (sender as Label).BackColor = Color.Lime;
            }
            else
            {
                (sender as Label).BackColor = SystemColors.Control;
            }
        }
        public static void RefreshOutput(object sender, bool B)
        {
            if (B)
            {
                if (sender is Label)
                    (sender as Label).BackColor = Color.Red;
                if (sender is Button)
                    (sender as Button).BackColor = Color.Red;
            }
            else
            {
                if (sender is Label)
                    (sender as Label).BackColor = SystemColors.Control;
                if (sender is Button)
                    (sender as Button).BackColor = SystemColors.Control;
            }
        }
        public static void RefreshOutput(object sender, ZEC3002.Ctrl.TDOutput DO)
        {
            if (sender is Label)
                //(sender as Label).Text = "DO" + DO.Add + "-" + DO.Name; ;
                (sender as Label).Text = DO.Name;
            if (sender is Button)
                //(sender as Button).Text = "DO" + DO.Add + "-" + DO.Name; ;
                (sender as Button).Text = DO.Name;

            if (!ZEC3002.Ctrl.BoardOpened(DO.BoardID)) { return; }

            if (DO.Status)
            {
                if (sender is Label)
                    (sender as Label).BackColor = Color.Red;
                if (sender is Button)
                    (sender as Button).BackColor = Color.Red;
            }
            else
            {
                if (sender is Label)
                    (sender as Label).BackColor = SystemColors.Control;
                if (sender is Button)
                    (sender as Button).BackColor = SystemColors.Control;
            }
        }
    }

    class Utils
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const byte VK_CAPSLOCK = 0x14;
        const byte VK_NUMLOCK = 0x90;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;

        public static void DisableNumCapslock()
        {
            if (Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock))
            {
                keybd_event(VK_CAPSLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(VK_CAPSLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            if (Control.IsKeyLocked(System.Windows.Forms.Keys.NumLock))
            {
                keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
        }
    }

    class GDefineN//migrated from GDefineN
    {
        #region Application
        public enum ESystemSt
        {
            ErrorInit = 0,
            Ready,
        }
        public static Color[] ModuleStColor = { Color.Red, Color.Lime, Color.Yellow };
        private static ESystemSt _SystemSt = ESystemSt.ErrorInit;
        public static ESystemSt SystemSt
        {
            get { return _SystemSt; }
            set
            {
                _SystemSt = value;
                if (value == ESystemSt.ErrorInit) GDefine.Status = EStatus.ErrorInit;
            }
        }
        #endregion

        public static bool Enabled_BtnStart;
        public static bool Enabled_BtnStop;
        public static bool Enabled_LowPressure;
        public static bool Enabled_BtnReset;
        public static bool Enable_Buzzer;
        
        public static bool EnableMapEditLock;
        public static bool AutoPageShowImage;
        public static bool EnableEventDebugLog;

        public static bool EnableDoorSens
        {
            get
            {
                //return TaskConv.EnableDoorSens;
                return true;
            }
            set
            {
                TaskConv.EnableDoorSens = value;
            }
        }
        public static bool EnableDoorLock
        {
            get
            {
                return TaskConv.EnableDoorLock;
            }
            set
            {
                TaskConv.EnableDoorLock = value;
            }
        }

        public static void Load()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(GDefine.AppPath, "\\AppData.dta");

            Enabled_BtnStart = IniFile.ReadBool("CONFIG", "Enabled_BtnStart", false);
            Enabled_BtnStop = IniFile.ReadBool("CONFIG", "Enabled_BtnStop", false);
            Enabled_LowPressure = IniFile.ReadBool("CONFIG", "Enabled_LowPressure", false);
            Enabled_BtnReset = IniFile.ReadBool("CONFIG", "Enabled_Reset", false);
            Enable_Buzzer = IniFile.ReadBool("CONFIG", "Enable_Buzzer", false);

            EnableMapEditLock = IniFile.ReadBool("ConfigUI", "EnableMapEditLock", true);
            AutoPageShowImage = IniFile.ReadBool("ConfigUI", "AutoPageShowImage", false);

            EnableDoorSens = IniFile.ReadBool("Safety", "EnableDoorSens", true);
            EnableDoorLock = IniFile.ReadBool("Safety", "EnableDoorLock", false);

            EnableEventDebugLog = IniFile.ReadBool("Advance", "EnableEventDebugLog", false);

            Save();
        }
        public static void Save()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(GDefine.AppPath, "\\AppData.dta");

            IniFile.WriteBool("CONFIG", "Enabled_BtnStart", Enabled_BtnStart);
            IniFile.WriteBool("CONFIG", "Enabled_BtnStop", Enabled_BtnStop);
            IniFile.WriteBool("CONFIG", "Enabled_Reset", Enabled_BtnReset);
            IniFile.WriteBool("CONFIG", "Enabled_LowPressure", Enabled_LowPressure);
            IniFile.WriteBool("CONFIG", "Enable_Buzzer", Enable_Buzzer);

            IniFile.WriteBool("ConfigUI", "EnableMapEditLock", EnableMapEditLock);
            IniFile.WriteBool("ConfigUI", "AutoPageShowImage", AutoPageShowImage);

            IniFile.WriteBool("Safety", "EnableDoorSens", EnableDoorSens);
            IniFile.WriteBool("Safety", "EnableDoorLock", EnableDoorLock);

            IniFile.WriteBool("Advance", "EnableEventDebugLog", EnableEventDebugLog);
        }

        public static bool BtnStartValid()
        {
            if (!Enabled_BtnStart) { return false; }
            return true;
        }
        public static bool BtnStopValid()
        {
            if (!Enabled_BtnStop) { return false; }
            return true;
        }
        public static bool BtnResetValid()
        {
            if (!Enabled_BtnReset) { return false; }
            return true;
        }
        public static bool LowPressureValid()
        {
            if (!Enabled_LowPressure) { return false; }
            return true;
        }

        public static bool DI_BtnStart
        {
            get
            {
                return TaskConv.BtnStart;
            }
        }
        public static bool DI_BtnStop
        {
            get
            {
                return TaskConv.BtnStop;
            }
        }
        public static bool DI_BtnReset
        {
            get
            {
                return TaskConv.BtnReset;
            }
        }
        public static bool DI_DoorSW
        {
            get
            {
                    return TaskConv.SensDoor;
            }
        }
        public static bool DI_InPressureInRange
        {
            get
            {
                    return TaskConv.LowPressure;
            }
        }

        public static int PreTimeOut//unit s
        {
            get
            {
                int defValue = 10000;
                //int i = 0;
                //NDispWin.TaskMHS.CmdGet("Disp12PreTimeOut", out i);
                //return Math.Max(defValue, i);
                return Math.Max(defValue, TaskConv.Setup.Pre[(int)TaskConv.EPara.TimeOut]);
            }
        }


        public static int Language1 = 0;
        public static int Language2 = 0;
        public static string AltErrMsgFile = "";

        #region Performance
        public struct TSysTime
        {
            public int Ms;
            public int Time;
            public int Day;
        }
        public static TSysTime SysUpTime;
        public static TSysTime SysRunTime;
        public static TSysTime SysIdleTime;
        public static TSysTime SysDownTime;
        public static TSysTime SysMTTATime;

        public static int SysAssist;
        public static int LastAssistCount;
        internal static int StartStopRunTime = 0;

        public static void PerformanceReset()
        {
            GDefineN.SysUpTime.Time = DLLDefine.GetTickCount();
            GDefineN.SysUpTime.Ms = 0;
            GDefineN.SysUpTime.Day = 0;

            GDefineN.SysRunTime.Time = DLLDefine.GetTickCount();
            GDefineN.SysRunTime.Ms = 0;
            GDefineN.SysRunTime.Day = 0;

            GDefineN.SysIdleTime.Time = DLLDefine.GetIdleTimeTickCount();
            GDefineN.SysIdleTime.Ms = 0;
            GDefineN.SysIdleTime.Day = 0;

            GDefineN.SysDownTime.Time = DLLDefine.GetDownTimeTickCount();
            GDefineN.SysDownTime.Ms = 0;
            GDefineN.SysDownTime.Day = 0;

            GDefineN.SysMTTATime.Time = DLLDefine.GetMTTATimeTickCount();
            DLLDefine.TickCountMTTATime.Stop();
            GDefineN.SysMTTATime.Ms = 0;

            GDefineN.SysAssist = 0;
            GDefineN.LastAssistCount = 0;
            MsgInfo.AssistCount = 0;

            GDefineN.SaveAppData();
        }
        #endregion

        public static Stopwatch sw_StartStopTime = new Stopwatch();

        public static Stopwatch sw_UpTime = new Stopwatch();
        public static Stopwatch sw_RunTime = new Stopwatch();
        public static Stopwatch sw_IdleTime = new Stopwatch();
        public static Stopwatch sw_DownTime = new Stopwatch();
        public static Stopwatch sw_ToAssistTime = new Stopwatch();

        public static int Disp12ModeWaitPreTimeOut = 10;

        public static void LoadAppData()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(GDefine.AppPath, "\\AppData.dta");

            GDefine.DeviceRecipe = IniFile.ReadString("DeviceRecipe", "RecipeName", "DEFAULT");

            Language1 = IniFile.ReadInteger("AppEnvironment", "Language1", 0);
            Language2 = IniFile.ReadInteger("AppEnvironment", "Language2", 0);
            List<string> LangList = AppLanguage.Func2.GetLangList();
            while (Language1 > LangList.Count() - 1)
                Language1--;
            while (Language2 > LangList.Count() - 1)
                Language2--;
            AltErrMsgFile = IniFile.ReadString("AppEnvironment", "AltErrMsgFile", "");

            SysUpTime.Day = IniFile.ReadInteger("SysInfo", "SysUpDay", 0);
            SysUpTime.Ms = IniFile.ReadInteger("SysInfo", "SysUpMsec", 0);
            SysRunTime.Day = IniFile.ReadInteger("SysInfo", "SysRunDay", 0);
            SysRunTime.Ms = IniFile.ReadInteger("SysInfo", "SysRunMsec", 0);
            LastAssistCount = IniFile.ReadInteger("SysInfo", "SysAssist", 0);
            SysIdleTime.Day = IniFile.ReadInteger("SysInfo", "SysIdleDay", 0);
            SysIdleTime.Ms = IniFile.ReadInteger("SysInfo", "SysIdleMsec", 0);
            SysDownTime.Day = IniFile.ReadInteger("SysInfo", "SysDownDay", 0);
            SysDownTime.Ms = IniFile.ReadInteger("SysInfo", "SysDownMsec", 0);
            SysMTTATime.Day = IniFile.ReadInteger("SysInfo", "SysMTTADay", 0);
            SysMTTATime.Ms = IniFile.ReadInteger("SysInfo", "SysMTTAMsec", 0);

            GDefine.EnableLotEntry = IniFile.ReadBool("LotInfo", "LotActivated", false);
            try
            {
                LotInfo2.Customer = (LotInfo2.ECustomer)IniFile.ReadInteger("LotInfo", "Customer", 0);
            }
            catch { }

            if (!File.Exists(GDefine.AppPath + "\\AppData.dta"))
            {
                SaveAppData();
            }

            MsgInfo.AltMsg = AltErrMsgFile;
        }
        public static void SaveAppData()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(GDefine.AppPath, "\\AppData.dta");

            IniFile.WriteString("DeviceRecipe", "RecipeName", GDefine.DeviceRecipe);
            IniFile.WriteBool("SysControl", "SysBurnRun", false);

            IniFile.WriteInteger("AppEnvironment", "Language1", Language1);
            IniFile.WriteInteger("AppEnvironment", "Language2", Language2);
            IniFile.WriteString("AppEnvironment", "AltErrMsgFile", AltErrMsgFile);

            IniFile.WriteInteger("SysInfo", "SysUpDay", SysUpTime.Day);
            IniFile.WriteInteger("SysInfo", "SysUpMsec", SysUpTime.Ms);
            IniFile.WriteInteger("SysInfo", "SysRunDay", SysRunTime.Day);
            IniFile.WriteInteger("SysInfo", "SysRunMsec", SysRunTime.Ms);
            IniFile.WriteInteger("SysInfo", "SysAssist", SysAssist);
            //Added 7Mar2014
            IniFile.WriteInteger("SysInfo", "SysIdleDay", SysIdleTime.Day);
            IniFile.WriteInteger("SysInfo", "SysIdleMsec", SysIdleTime.Ms);
            IniFile.WriteInteger("SysInfo", "SysDownDay", SysDownTime.Day);
            IniFile.WriteInteger("SysInfo", "SysDownMsec", SysDownTime.Ms);
            IniFile.WriteInteger("SysInfo", "SysMTTADay", SysMTTATime.Day);
            IniFile.WriteInteger("SysInfo", "SysMTTAMsec", SysMTTATime.Ms);
            //Added 17Jul
            IniFile.WriteBool("LotInfo", "LotActivated", GDefine.EnableLotEntry);
            IniFile.WriteInteger("LotInfo", "Customer", (int)LotInfo2.Customer);
        }

        public static void CheckDirPath(string Path)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }
        public static void CheckDir()
        {
            CheckDirPath(GDefine.AppPath);
            CheckDirPath(GDefine.AppPath + "LOG\\");
            CheckDirPath(GDefine.DevicePath);
        }

        public static string UpdateUpTime()
        {
            int UpHour, UpMin, UpSec;
            SysUpTime.Ms = DLLDefine.GetTickCount() - SysUpTime.Time;

            int UpTime = SysUpTime.Ms / 1000;
            UpSec = (UpTime) % 60;
            UpMin = (UpTime / 60) % 60;
            UpHour = (UpTime / 3600);

            if (UpHour > 23)
            {
                SysUpTime.Day++;
                SysUpTime.Time = DLLDefine.GetTickCount();
            }

            string S = $"{SysUpTime.Day} D {UpHour:D2} H {UpMin:D2} M {UpSec:D2} S";
            return S;
        }

        //Added 7Mar2014
        public static string UpdateDownTime()
        {
            int DownHour, DownMin, DownSec;
            SysDownTime.Ms = DLLDefine.GetDownTimeTickCount() - SysDownTime.Time;

            int DownTime = SysDownTime.Ms / 1000;
            DownSec = (DownTime) % 60;
            DownMin = (DownTime / 60) % 60;
            DownHour = (DownTime / 3600);

            if (DownHour > 23)
            {
                SysDownTime.Day++;
                SysDownTime.Time = DLLDefine.GetDownTimeTickCount();
            }

            string S = $"{SysDownTime.Day} D {DownHour:D2} H {DownMin:D2} M {DownSec:D2} S";
            return S;
        }
        public static string UpdateIdleTime()
        {
            int IdleHour, IdleMin, IdleSec;
            SysIdleTime.Ms = DLLDefine.GetIdleTimeTickCount() - SysIdleTime.Time;

            int IdleTime = SysIdleTime.Ms / 1000;
            IdleSec = (IdleTime) % 60;
            IdleMin = (IdleTime / 60) % 60;
            IdleHour = (IdleTime / 3600);

            if (IdleHour > 23)
            {
                SysIdleTime.Day++;
                SysIdleTime.Time = DLLDefine.GetIdleTimeTickCount();
            }

            string S = $"{SysIdleTime.Day} D {IdleHour:D2} H {IdleMin:D2} M {IdleSec:D2} S";
            return S;
        }
        public static string UpdateMTTA()
        {
            int MTTAHour, MTTAMin, MTTASec;
            int TempAssist;
            if (SysAssist == 0) { TempAssist = 1; } else { TempAssist = SysAssist; }
            SysMTTATime.Ms = DLLDefine.GetMTTATimeTickCount() - SysMTTATime.Time;

            int MTTATime = (SysMTTATime.Ms / 1000) / TempAssist;
            MTTASec = (MTTATime) % 60;
            MTTAMin = (MTTATime / 60) % 60;
            MTTAHour = (MTTATime / 3600);

            string S = $"{MTTAHour} H {MTTAMin:D2} M {MTTASec:D2} S";
            return S;
        }

        public static string UpdateRunTime(bool StartUp)
        {
            if (StartUp) { SysRunTime.Time = DLLDefine.GetTickCount() - SysRunTime.Ms; }

            int RunHour, RunMin, RunSec;
            SysRunTime.Ms = DLLDefine.GetTickCount() - SysRunTime.Time;

            int RunTime = SysRunTime.Ms / 1000;
            RunSec = (RunTime) % 60;
            RunMin = (RunTime / 60) % 60;
            RunHour = (RunTime / 3600);

            if (RunHour > 23)
            {
                SysRunTime.Day++;
                SysRunTime.Time = DLLDefine.GetTickCount();
            }

            string S = $"{SysRunTime.Day} D {RunHour:D2} H {RunMin:D2} M {RunSec:D2} S";
            return S;
        }
        public static string UpdateAssist()
        {
            //string S = (SysAssist = LastAssistCount + MsgBox.Page.ErrorAssist).ToString();
            string S = (SysAssist = LastAssistCount + MsgInfo.AssistCount).ToString();
            return S;
        }
        public static string UpdateMTBA()
        {
            int TempAssist;
            if (SysAssist == 0) { TempAssist = 1; } else { TempAssist = SysAssist; }
            int MTBA = SysRunTime.Ms / TempAssist / 60000;
            return MTBA.ToString() + " M";
        }
        public static void UpdateUPH(int StationIdx)
        {

        }
    }

    class Define_Gantry
    {
        public static Color StatusColor(NDispWin.EStatus Status)
        {
            switch (Status)
            {
                case NDispWin.EStatus.Unknown:
                default:
                    return Color.Olive;
                case NDispWin.EStatus.Disable:
                    return Color.Silver;
                case NDispWin.EStatus.ErrorInit:
                    return Color.Red;
                case NDispWin.EStatus.Busy:
                    return Color.Yellow;
                case NDispWin.EStatus.Stop:
                    return Color.Yellow;
                case NDispWin.EStatus.Ready:
                    return Color.Lime;
            }
        }

        public static bool CheckReady()
        {
            if (GDefine.Status == EStatus.Ready) return true;
            if (GDefine.Status == EStatus.Stop) return true;
            if (GDefine.Status == EStatus.EndStop) return true;

            return false;
        }
    }

    class DefineSafety
    {
        public static DateTime dtEnable = DateTime.Now;//time to enable main DoorLock and DoorSens

        public static bool DoorLock
        {
            set
            {
                try
                {
                    if (value)
                    {
                        if (GDefineN.EnableDoorLock && DateTime.Now >= DefineSafety.dtEnable)
                        {
                            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                                TaskConv.DoorLock = true;
                            else
                            {
                                if (TaskGantry._LockDoor.Device.Type != CControl2.EDeviceType.NONE)
                                    TaskGantry.LockDoor = true;
                            }
                        }
                    }
                    else
                    {
                        if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                            TaskConv.DoorLock = false;
                        else
                        {
                            if (TaskGantry._LockDoor.Device.Type != CControl2.EDeviceType.NONE)
                                TaskGantry.LockDoor = false;
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + Ex.Message.ToString());
                    return;
                }
            }
        }
        public static bool DoorLockStatus
        {
            get
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    return ConvIO.DoorLock.Status;
                else
                {
                    if (TaskGantry._LockDoor.Device.Type != CControl2.EDeviceType.NONE)
                        return TaskGantry.LockDoor;
                }
                return false;
            }
        }

        public static bool DoorCheck_Disp(bool Prompt)
        {
            //if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            //{

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                return TaskConv.DoorCheck(Prompt);
            else
            {
                if (GDefineN.EnableDoorSens && DateTime.Now >= DefineSafety.dtEnable)
                {
                    if (TaskGantry._SensDoor.Device.Type != CControl2.EDeviceType.NONE)
                    {
                        if (!TaskGantry.SensDoor)
                        {
                            if (Prompt)
                            {
                                Msg MsgBox = new Msg();
                                EMsgRes MsgRes = MsgBox.Show(ErrCode.DOOR_IS_OPEN, EMcState.Warning, EMsgBtn.smbOK, false);
                            }
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        public static bool DoorCheck_Elev(bool Prompt)
        {
            if (!TaskElev.Left.DoorCheck(Prompt)) return false;
            if (!TaskElev.Right.DoorCheck(Prompt)) return false;

            return true;
        }
        public static bool DoorCheck_All(bool Prompt)
        {
            if (!DoorCheck_Disp(Prompt)) return false;
            if (!DoorCheck_Elev(Prompt)) return false;
            return true;
        }
    }

    class Define_Run
    {
        public static bool DebugMode
        {
            get
            {
                return Application.ExecutablePath.Contains("Debug");
            }
        }

        public static bool InitSystem(bool Prompt)
        {
            if (Prompt)
            {
                Msg MsgBox = new Msg();
                if (MsgBox.Show(ErrCode.INIT_SYSTEM, EMcState.Notice, EMsgBtn.smbOK_Cancel, false) != EMsgRes.smrOK)
                {
                    return false;
                }
            }

            if (!DefineSafety.DoorCheck_Disp(true)) return false;
            DefineSafety.DoorLock = true;

            Event.OP_INIT_SYSTEM.Set("AppVersion", Application.ProductVersion);

            AccessConfig.Setup.ResetUserAccess();
            GDefineN.SystemSt = GDefineN.ESystemSt.ErrorInit;
            DispProg.TR_Cancel();

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                IO.SetState(ERYG.Blink, ERYG.Off, ERYG.Off, EBuzzer.Off);
            }
            else
                if (GDefine.ConveyorType == GDefine.EConveyorType.TABLE_S320A)
            {
                GDefine.Table.StationStatus = GDefine.Table.TStStatus.stEmpty;
            }

            if (!InitGantry(false)) { goto _Error; }

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                if (!InitConv(false)) { goto _Error; }
                if (!InitLR(false)) { goto _Error; }
            }

            GDefineN.SystemSt = GDefineN.ESystemSt.Ready;

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                IO.SetState(EMcState.Idle);
            }
            return true;

        _Error:
            GDefineN.SystemSt = GDefineN.ESystemSt.ErrorInit;
            return false;
        }
        public static bool InitGantry(bool Prompt)
        {
            if (Prompt)
            {
                Msg MsgBox = new Msg();
                if (MsgBox.Show(ErrCode.INIT_GANTRY, EMcState.Notice, EMsgBtn.smbOK_Cancel, false) != EMsgRes.smrOK)
                {
                    return false;
                }
            }

            if (!DefineSafety.DoorCheck_Disp(true)) return false;
            DefineSafety.DoorLock = true;

            Event.OP_INIT_GANTRY_START.Set();
            if (!NDispWin.TaskGantry.Home()) goto _Error;
            Event.OP_INIT_GANTRY_COMPLETE.Set();

            DefineSafety.DoorLock = false;
            return true;

        _Error:
            DefineSafety.DoorLock = false;
            return false;
        }
        public static bool InitConv(bool Prompt)
        {
            if (Prompt)
            {
                Msg MsgBox = new Msg();
                if (MsgBox.Show(ErrCode.INIT_CONVEYOR, EMcState.Notice, EMsgBtn.smbOK_Cancel, false) != EMsgRes.smrOK)
                {
                    return false;
                }
            }

            if (!DefineSafety.DoorCheck_Disp(true)) return false;
            DefineSafety.DoorLock = true;

            Event.OP_INIT_CONV_START.Set();

            DispProg.rt_RunRegion = ERunRegion.All;
            if (!NDispWin.TaskConv.Init()) goto _Error;

            Event.OP_INIT_CONV_COMPLETE.Set();

            DefineSafety.DoorLock = false;
            return true;

        _Error:
            DefineSafety.DoorLock = false;
            return false;
        }
        public static bool InitLR(bool Prompt)
        {
            if (Prompt)
            {
                Msg MsgBox = new Msg();
                if (MsgBox.Show(ErrCode.INIT_LR_LINE, EMcState.Notice, EMsgBtn.smbOK_Cancel, false) != EMsgRes.smrOK)
                {
                    return false;
                }
            }

            if (!NDispWin.TaskElev.Init()) return false;

            Event.OP_INIT_LR_LINE_COMPLETE.Set();

            return true;
        }
        public static bool InitLeft(bool Prompt)
        {
            if (Prompt)
            {
                Msg MsgBox = new Msg();
                if (MsgBox.Show((int)EErrCode.INIT_LEFT_ELEV, EMcState.Notice, EMsgBtn.smbOK_Cancel, false) != EMsgRes.smrOK)
                {
                    return false;
                }
            }

            Event.OP_INIT_LEFT_LINE_START.Set();
            if (!TaskElev.Left.Init()) return false;
            Event.OP_INIT_LEFT_LINE_COMPLETE.Set();

            return true;
        }
        public static bool InitRight(bool Prompt)
        {
            if (Prompt)
            {
                Msg MsgBox = new Msg();
                if (MsgBox.Show((int)EErrCode.INIT_RIGHT_ELEV, EMcState.Notice, EMsgBtn.smbOK_Cancel, false) != EMsgRes.smrOK)
                {
                    return false;
                }
            }

            Event.OP_INIT_RIGHT_LINE_START.Set();
            if (!TaskElev.Right.Init()) return false;
            Event.OP_INIT_RIGHT_LINE_COMPLETE.Set();

            return true;
        }

        public static bool CheckSysReady()
        {
            string EMsg = "CheckSysReady";
            if (GDefineN.SystemSt != GDefineN.ESystemSt.Ready)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.SYSTEM_NOT_READY, "", true);
                return false;
            }

            try
            {
                if (!Define_Gantry.CheckReady()) { return false; }

                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                {
                        if (!NDispWin.TaskConv.Ready) return false;
                        if (!NDispWin.TaskElev.Ready) return false;
                }

                if (!DefineSafety.DoorCheck_All(true)) { return false; }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            }
            return true;
        }
        public static bool PromptLowPressure()
        {
            if (GDefine.ConveyorType != GDefine.EConveyorType.CONVEYOR) { return true; }

            if (GDefineN.LowPressureValid())
            {
                if (!GDefineN.DI_InPressureInRange)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.LOW_AIR_PRESSURE);
                    return false;
                }
            }

            return true;
        }

        public static NDispWin.ERunMode DispRunMode = new NDispWin.ERunMode();
        internal static int t_ProStartWaitDisp = 0;

        public static void UpdateProcessStatus_BdReady()
        {
            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                if (NDispWin.Intf.Program.BdReady)
                {
                    if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.WaitNone ||
                        NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.WaitNone)
                    {
                        #region Disp1/Disp2 Mode
                        if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.WaitNone)
                        {
                            if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.InProcess)
                            {
                                NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.Psnt;
                                NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.Empty;
                            }
                        }
                        if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.WaitNone)
                        {
                            if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.InProcess)
                            {
                                NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.Psnt;
                                NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.Empty;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.InProcess)
                        {
                            NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.Psnt;
                        }
                        if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.InProcess)
                        {
                            NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.Psnt;
                        }
                    }
                }
            }
            if (GDefine.ConveyorType == GDefine.EConveyorType.TABLE_S320A)
            {
                if (NDispWin.Intf.Program.BdReady)
                {
                    GDefine.Table.StationStatus = GDefine.Table.TStStatus.stCompleted;
                }
            }
        }

        public static bool b_LeftMagEmptyAlarming = false;
        public static bool b_RightMagEmptyAlarming = false;
        public static bool ResumeMap = false;

        static bool b_TR_IsRunning = false;
        public static bool TR_IsRunning
        {
            get
            {
                return b_TR_IsRunning;
            }
        }

        public static bool TR_CheckProcess()
        {
            if (!DefineSafety.DoorCheck_All(false))
            {
                DefineSafety.DoorCheck_All(true);
                return false;
            }

            if (GDefineN.LowPressureValid() && !GDefineN.DI_InPressureInRange)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.LOW_AIR_PRESSURE);
                return false;
            }

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                if (TaskConv.Pro.Status == TaskConv.EProcessStatus.InProcess &&
              TaskConv.Pro.UseVac &&
              !TaskConv.Pro.SensVac)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.CONV_VACUUM_LOW);
                    return false;
                }
            }

            try
            {
                if (!TaskDisp.Vermes3200[0].InRange)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show((int)EErrCode.DISPCTRL_TEMPERATURE_OUT_OF_TOLERANCE);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISPCTRL_ERR, $" {ex.Message}");
                return false;
            }

            return true;
        }


        public static bool TR_StartRun()
        {
            if (TR_IsRunning) return true;

            if (!Define_Run.CheckSysReady()) return false;
            if (!Intf.Program.RunPermit) return false;

            if (!TR_CheckProcess()) return false;

            Msg MsgBox = new Msg();
            if (GDefine.EnableLotEntry && !LotInfo2.LotActive)
            {
                MsgBox.Show(ErrCode.LOT_NOT_ACTIVATED);
                return false;
            }

            if (NDispWin.TaskConv.StopInput)
            {
                EMsgRes Res = MsgBox.Show(ErrCode.INPUT_IS_STOPPED, EMcState.Notice, EMsgBtn.smbOK_Cancel | EMsgBtn.smbStop, false);
                switch (Res)
                {
                    case EMsgRes.smrStop:
                        return false;
                    case EMsgRes.smrOK:
                        NDispWin.TaskConv.StopInput = false;
                        break;
                    case EMsgRes.smrCancel:
                        break;
                }
            }

            if (TaskConv.Pro.Status == TaskConv.EProcessStatus.Empty)
            {
                if (TaskConv.Pro.SensPsnt)
                {
                    TaskDisp.TaskMoveGZZ2Up();
                    if (!TaskDisp.TaskGotoTPos2(TaskDisp.Needle_Purge_Pos)) return false;
                }
            }

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                IO.SetState(EMcState.Run);
                TaskConv.VacPump = true;
            }

            b_LeftMagEmptyAlarming = false;
            b_RightMagEmptyAlarming = false;
            if (NDispWin.TaskConv.Status == NDispWin.TaskConv.EConvStatus.Stop) NDispWin.TaskConv.Status = NDispWin.TaskConv.EConvStatus.Ready;

            if (ResumeMap)
            {
                ResumeMap = false;
                DispProg.TR_Cancel();
                DispProg.ResumeMap();
            }

            DefineSafety.DoorLock = true;

            b_TR_IsRunning = true;
            GDefineN.sw_StartStopTime.Restart();

            Event.OP_START_RUN.Set();
            return true;
        }
        public static void TR_StopRun()
        {
            if (DispProg.TR_IsBusy()) DispProg.TR_Pause();

            if (!TR_IsRunning) return;
            b_TR_IsRunning = false;

            Event.OP_STOP_RUN.Set("Runtime", GDefineN.sw_StartStopTime.Elapsed.TotalMinutes.ToString("f2") + "m");

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                IO.SetState(EMcState.Idle);
            }
        }

        public static void RunDispConv()//full auto converyor run
        {
            try
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                {
                    if (DispProg.TR_IsBusy()) return;

                    #region Set Conditions before run
                    if (GDefine.Status == EStatus.ErrorInit) TR_StopRun();

                    if (TaskConv.Pre.StType == TaskConv.EPreStType.Disp1 && TaskConv.Pro.StType == TaskConv.EProStType.Disp2)
                    {
                        if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.Heating) return;
                        if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.Heating) return;

                        if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.WaitDisp)
                        {
                            NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                        }

                        if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.WaitDisp)
                        {
                            NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                        }
                    }

                    if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.WaitNone ||
                        NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.WaitNone)
                    {
                        #region RunRegion2
                        if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.WaitNone)
                        {
                            if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.WaitDisp)
                            {
                                NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                            }
                            if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.InProcess)
                            {
                                //run34
                                DispProg.rt_RunRegion = ERunRegion.H2;//RunRegion 2 = Pump3,4
                                DispProg.RunMode = DispRunMode;
                                DispProg.rt_StationNo = 0;
                            }
                        }
                        #endregion
                        #region RunRegion1
                        if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.WaitNone)
                        {
                            if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.WaitDisp)
                            {
                                NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                            }
                            if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.InProcess)
                            {
                                //run12
                                DispProg.rt_RunRegion = ERunRegion.H1;//RunRegion 1 = Pump1,2
                                DispProg.RunMode = DispRunMode;
                                DispProg.rt_StationNo = 0;
                            }
                        }
                        #endregion
                    }
                    else
                        if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.WaitDisp2)
                    {
                        #region Disp12 - Run All Regions
                        DispProg.rt_RunRegion = ERunRegion.All;//RunRegion 0 = AllPumps
                        NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.InProcess;

                        if (NDispWin.TaskConv.Pro.Status != NDispWin.TaskConv.EProcessStatus.WaitDisp2)
                        {
                            DispProg.rt_RunRegion = ERunRegion.H2;//RunRegion 2 = Pump3,4
                        }
                        if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.WaitDisp2)
                            NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.InProcess;

                        DispProg.RunMode = DispRunMode;
                        DispProg.rt_StationNo = 0;
                        #endregion
                    }
                    else
                    {
                        #region Default
                        switch (NDispWin.TaskConv.Pro.Status)
                        {
                            case NDispWin.TaskConv.EProcessStatus.WaitDisp:
                                //20211206 5.2.40 Removed DispProg.TR_Cancel();//start new dispense
                                NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                                break;
                            case NDispWin.TaskConv.EProcessStatus.WaitDisp2:
                                if (t_ProStartWaitDisp == 0) t_ProStartWaitDisp = GDefine.GetTickCount();

                                int i_TOut = GDefineN.PreTimeOut;
                                if (GDefine.GetTickCount() >= t_ProStartWaitDisp + i_TOut)
                                {
                                    Msg MsgBox = new Msg();
                                    EMsgRes Res = MsgBox.Show(ErrCode.DISP12MODE_WAIT_PRE_TIMEOUT, EMcState.Notice, EMsgBtn.smbOK_Retry_Stop, false);

                                    switch (Res)
                                    {
                                        case EMsgRes.smrOK:
                                            NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.WaitNone;
                                            NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.WaitDisp;
                                            t_ProStartWaitDisp = 0;
                                            break;
                                        case EMsgRes.smrStop:
                                            t_ProStartWaitDisp = 0;
                                            TR_StopRun();
                                            break;
                                        case EMsgRes.smrRetry:
                                            t_ProStartWaitDisp = 0;
                                            break;
                                    }
                                    return;
                                }
                                return;
                            case NDispWin.TaskConv.EProcessStatus.InProcess:
                                break;
                            default:
                                t_ProStartWaitDisp = 0;
                                return;
                        }
                        t_ProStartWaitDisp = 0;
                        DispProg.RunMode = DispRunMode;
                        DispProg.rt_StationNo = 0;
                        #endregion
                    }
                    #endregion

                    if (!DispProg.TR_Run()) b_TR_IsRunning = false;

                    if (GDefine.Status == EStatus.Stop || Intf.Program.BdStatus == EBoardStatus.Stop) TR_StopRun();

                    if (!b_TR_IsRunning) DefineSafety.DoorLock = false;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Disp Run " + Ex.Message.ToString());
            }
            finally
            {
            }
        }
        public static bool PromptButtonFocus = false;

        public static bool TableIsRunning = false;
        public static void StopDispTable()
        {
            if (DispProg.TR_IsBusy()) DispProg.TR_Pause();
            TableIsRunning = false;
        }
        public static bool RunDispTable()
        {
            if (DispProg.TR_IsBusy()) return false;

            if (!Intf.Program.RunPermit) return false;
            if (!Define_Run.PromptLowPressure()) return false;

            switch (GDefine.Table.StationStatus)
            {
                case GDefine.Table.TStStatus.stEmpty:
                case GDefine.Table.TStStatus.stWaitLoad:
                    {
                        if (GDefine.Table.StationStatus == GDefine.Table.TStStatus.stEmpty && !DefineSafety.DoorCheck_All(true)) return false;

                        if (!GDefine.Table.TaskMoveToLoad()) return false;
                        GDefine.Table.StationStatus = GDefine.Table.TStStatus.stWaitLoad;

                        MsgInfo.TMsgInfo msgInfo = new MsgInfo.TMsgInfo();
                        MsgInfo.GetInfo(ErrCode.S320_LOAD_PRODUCT, ref msgInfo);

                        IO.SetState(EMcState.Notice);

                        frmS320Prompt frm = new frmS320Prompt();
                        frm.Desc = msgInfo.Desc;
                        frm.Desc_Alt = msgInfo.Desc_Alt;

                        DialogResult dr = frm.ShowDialog();
                        switch (dr)
                        {
                            case DialogResult.OK:
                                IO.SetState(EMcState.Run);
                                GDefine.Table.StationStatus = GDefine.Table.TStStatus.stLoaded;
                                break;
                            case DialogResult.Cancel:
                                IO.SetState(EMcState.Idle);
                                return false;
                        }
                        break;
                    }
                case GDefine.Table.TStStatus.stCompleted:
                    {
                        if (!DefineSafety.DoorCheck_All(true)) return false;

                        if (!GDefine.Table.TaskMoveToLoad()) return false;

                        DefineSafety.DoorLock = false;

                        MsgInfo.TMsgInfo msgInfo = new MsgInfo.TMsgInfo();
                        MsgInfo.GetInfo(ErrCode.S320_UNLOAD_PRODUCT, ref msgInfo);

                        IO.SetState(EMcState.Notice);

                        frmS320Prompt frm = new frmS320Prompt();
                        frm.Desc = msgInfo.Desc;
                        frm.Desc_Alt = msgInfo.Desc_Alt;

                        DialogResult dr = frm.ShowDialog();
                        switch (dr)
                        {
                            case DialogResult.OK:
                                GDefine.Table.StationStatus = GDefine.Table.TStStatus.stEmpty;
                                IO.SetState(EMcState.Idle);
                                break;
                            case DialogResult.Cancel:
                                IO.SetState(EMcState.Idle);
                                return false;
                        }
                        break;
                    }
                case GDefine.Table.TStStatus.stLoaded:
                case GDefine.Table.TStStatus.stInProcess:
                    {
                        if (!DefineSafety.DoorCheck_All(true)) return false;

                        DefineSafety.DoorLock = true;
                        GDefine.Table.StationStatus = GDefine.Table.TStStatus.stInProcess;
                        DispProg.RunMode = ERunMode.Normal;
                        if (!DispProg.TR_Run()) return false;
                        break;
                    }
            }
            return true;
        }
    }

    class DLLDefine
    {
        public static Stopwatch TickCountWatch = new Stopwatch();
        //Added 7Mar2014
        public static Stopwatch TickCountDowntTime = new Stopwatch();
        public static Stopwatch TickCountIdleTime = new Stopwatch();
        public static Stopwatch TickCountMTTATime = new Stopwatch();
        // 3.0.1.17
        public static int GetTickCount()
        {
            if (!TickCountWatch.IsRunning)
            {
                TickCountWatch.Start();
            }

            int D = (int)TickCountWatch.ElapsedMilliseconds;
            return D;
        }

        //Added 7Mar2014
        public static int GetDownTimeTickCount()
        {
            if (!TickCountDowntTime.IsRunning)
            {
                TickCountDowntTime.Start();
            }

            int D = (int)TickCountDowntTime.ElapsedMilliseconds;
            return D;
        }

        //Added 7Mar2014
        public static int GetIdleTimeTickCount()
        {
            if (!TickCountIdleTime.IsRunning)
            {
                TickCountIdleTime.Start();
            }

            int D = (int)TickCountIdleTime.ElapsedMilliseconds;
            return D;
        }

        //Added 7Mar2014
        public static int GetMTTATimeTickCount()
        {
            if (!TickCountMTTATime.IsRunning)
            {
                TickCountMTTATime.Start();
            }

            int D = (int)TickCountMTTATime.ElapsedMilliseconds;
            return D;
        }
    }

    public class Timer
    {
        public static async void DoWorkAsyncInfinite10s_CopyLog()
        {
            while (true)
            {
                try
                {
                    await Task.Run(() => 
                    {
                        // Copy files to server
                        if (TaskDisp.CopyLogToServer) Log.CopyToBuffer();
                        Log.PurgeBuffer();
                        Thread.Sleep(10000);
                    });
                }
                catch { };
            }
        }
        public static async void DoWorkAsyncInfinite10s_TempPool()
        {
            if (GDefine.TempCtrl_Type != GDefine.ETempCtrl.Autonics_TX_TK) return;
            
            while (true)
            {
                //try
                //{
                //    await Task.Run(() =>
                //    {
                //        if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
                //        {
                //            if (TempCtrl.IsOpen) TempCtrl.Pool();
                //            Thread.Sleep(1);
                //        }
                //    });
                //}
                //catch (Exception ex)
                //{
                //    Event.DEBUG_INFO.Set("DoWorkAsync Exception", ex.Message.ToString());
                //};


                Task delay = Task.Delay(5000);
                try
                {
                    if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
                    {
                        if (TempCtrl.IsOpen) TempCtrl.Pool();
                    }
                }
                catch { };
                await delay;
            }
        }
    }

    public class TPos2
    {
        public double X;
        public double Y;
        public TPos2()
        {
            X = 0;
            Y = 0;
        }
        public TPos2(TPos2 Pos)
        {
            X = Pos.X;
            Y = Pos.Y;
        }
        public TPos2(double x, double y)
        {
            X = x;
            Y = y;
        }
        public string GetString
        {
            get
            {
                return X.ToString("F3") + ", " + Y.ToString("F3");
            }
        }
    }
    public class TPos3
    {
        public double X;
        public double Y;
        public double Z;
        public TPos3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public TPos3(TPos3 Pos)
        {
            X = Pos.X;
            Y = Pos.Y;
            Z = Pos.Z;
        }
        public TPos3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public string GetString
        {
            get
            {
                return X.ToString("F3") + ", " + Y.ToString("F3") + ", " + Z.ToString("F3");
            }
        }
        public string GetStringTPos2
        {
            get
            {
                return X.ToString("F3") + ", " + Y.ToString("F3");
            }
        }
    }

    public class TCirc
    {
        public TPos2 Start;
        public TPos2 End;
        public TPos2 Thru;
        public TPos2 ThruC;//equal thru pt from Start/End
        public TPos2 Center;
        public int Dir;//>0 = CW
        public TCirc(TPos2 Start, TPos2 Thru, TPos2 End)
        {
            this.Start = Start;
            this.Thru = End;
            this.End = End;
            this.Center = CircleCenter(Start, Thru, End);

            double area = Area(Start, Thru, End);
            if (area == 0)
                throw new Exception("Circle points in straight line.");
            else
                if (area < 0) Dir = 0;
            else
                Dir = 1;
        }

        static TPos2 CircleCenter(TPos2 A, TPos2 B, TPos2 C)
        //pt circleCenter(pt A, pt B, pt C)
        {
            double yDelta_a = B.Y - A.Y;
            double xDelta_a = B.X - A.X;

            double yDelta_b = C.Y - B.Y;
            double xDelta_b = C.X - B.X;
            //pt center = P(0, 0);
            TPos2 center = new TPos2(0, 0);

            double aSlope = yDelta_a / xDelta_a;
            double bSlope = yDelta_b / xDelta_b;

            //pt AB_Mid = P((A.X + B.X) / 2, (A.Y + B.Y) / 2);
            //pt BC_Mid = P((B.X + C.X) / 2, (B.Y + C.Y) / 2);
            TPos2 AB_Mid = new TPos2((A.X + B.X) / 2, (A.Y + B.Y) / 2);
            TPos2 BC_Mid = new TPos2((B.X + C.X) / 2, (B.Y + C.Y) / 2);

            if (yDelta_a == 0)         //aSlope == 0
            {
                center.X = AB_Mid.X;
                if (xDelta_b == 0)         //bSlope == INFINITY
                {
                    center.Y = BC_Mid.Y;
                }
                else
                {
                    center.Y = BC_Mid.Y + (BC_Mid.X - center.X) / bSlope;
                }
            }
            else if (yDelta_b == 0)               //bSlope == 0
            {
                center.X = BC_Mid.X;
                if (xDelta_a == 0)             //aSlope == INFINITY
                {
                    center.Y = AB_Mid.Y;
                }
                else
                {
                    center.Y = AB_Mid.Y + (AB_Mid.X - center.X) / aSlope;
                }
            }
            else if (xDelta_a == 0)        //aSlope == INFINITY
            {
                center.Y = AB_Mid.Y;
                center.X = bSlope * (BC_Mid.Y - center.Y) + BC_Mid.X;
            }
            else if (xDelta_b == 0)        //bSlope == INFINITY
            {
                center.Y = BC_Mid.Y;
                center.X = aSlope * (AB_Mid.Y - center.Y) + AB_Mid.X;
            }
            else
            {
                center.X = (aSlope * bSlope * (AB_Mid.Y - BC_Mid.Y) - aSlope * BC_Mid.X + bSlope * AB_Mid.X) / (bSlope - aSlope);
                center.Y = AB_Mid.Y - (center.X - AB_Mid.X) / aSlope;
            }

            return center;
        }

        //static double Area(double ax, double ay, double bx, double by, double cx, double cy)
        static double Area(TPos2 A, TPos2 B, TPos2 C)
        {
            return ((A.X - C.X) * (B.Y - C.Y) - (A.Y - C.Y) * (B.X - C.X)) / 2;
        }
    }

    public enum EStatus { Unknown, Disable, ErrorInit, Busy, Stop, Ready, EndStop, IdlePurge }
    public enum EOperationSpeed { Normal, Safe, SlowMo }

    internal class GDefine
    {
        public static SECSGEMConnect2 sgc2 = new SECSGEMConnect2();

        public static bool EnableDnloadStripMapE142
        {
            get
            {
                return DispProg.EnableDnloadStripMapE142;// : sgc2.EnableDnloadStripMapE142;
            }
            set
            {
                //if (DispProg.StripMapFollowRecipe)
                    DispProg.EnableDnloadStripMapE142 = value;
                //else
                //    sgc2.EnableDnloadStripMapE142 = value;
            }
        }
        public static int StripMapDnloadFlip
        {
            get
            {
                return DispProg.StripMapDnloadFlip;//: (int)sgc2.StripMapDnloadFlip;
            }
            set
            {
                //if (DispProg.StripMapFollowRecipe)
                    DispProg.StripMapDnloadFlip = value;
                //else
                //    sgc2.StripMapDnloadFlip = (SECSGEMConnect2.EStripMapFlip)value;
            }
        }
        public static bool EnableUploadStripMapE142
        {
            get
            {
                return DispProg.EnableUploadStripMapE142;// : sgc2.EnableUploadStripMapE142;
            }
            set
            {
                //if (DispProg.StripMapFollowRecipe)
                    DispProg.EnableUploadStripMapE142 = value;
                //else
                //    sgc2.EnableUploadStripMapE142 = value;
            }
        }
        public static int StripMapUploadFlip
        {
            get
            {
                return DispProg.StripMapUploadFlip;// : (int)sgc2.StripMapUploadFlip;
            }
            set
            {
                //if (DispProg.StripMapFollowRecipe)
                    DispProg.StripMapUploadFlip = value;
                //else
                 //   sgc2.StripMapUploadFlip = (SECSGEMConnect2.EStripMapFlip)value;
            }
        }

        public static bool CheckLic = false;
        public static bool SysOffline = false;

        #region Path and files 
        public static string AppPath = "C:\\Program Files\\NSWAutomation\\NDisp3WIN";

        public static string ConfigPath = AppPath + "\\Config";
        public static string SetupPath = AppPath + "\\Setup";
        public static string ConfigFile = AppPath + "\\Device_0.cfg";
        public static string ConfigFile2 = AppPath + "\\Device_1.cfg";//"C:\\Program Files\\NSWAutomation\\NDisp3WIN\\Device_0.cfg";
        public static string LotPath = AppPath + "\\Lot";


        public static string DevicePath = AppPath + "\\Device\\";
        public static string DeviceRecipe = "DEFAULT";
        public static string DeviceRecipeExt = "device";

        public static string ProgRecipeName = "default";
        public static string ProgPath = AppPath + "\\Program";
        public const string ProgExt = "prg";
        //public static string RecipePath = AppPath + "\\Recipe";//recipe replaces program from 1.3.x version

        public static DirectoryInfo RootDir => Directory.CreateDirectory("C:\\Program Files\\NSWAutomation\\NDisp3WIN\\");
        public static DirectoryInfo RecipeDir => Directory.CreateDirectory(RootDir.FullName + "Recipe\\");
        public static DirectoryInfo RecipeDir2 => Directory.CreateDirectory(RootDir.FullName + "Recipe2\\");//Unisem recipe backup folder
        public static string RecipeExt = ".xml";

        public static string DataPath = AppPath + "\\Data";
        public static DirectoryInfo DataDir => Directory.CreateDirectory(RootDir.FullName + "Data\\");

        public static string WeightPath = AppPath + "\\Weight";
        public static string ResourcesPath = AppPath + "\\Resources";

        public static string BiasKernelPath = SetupPath + "\\BiasKernel";
        public static string ModelSettingFile = SetupPath + "\\Model.Setting.ini";
        public static string DispProgUISettingFile = SetupPath + "\\DispProg.UI.ini";

        public static string WeightMeasPath = DataPath + "\\Weight";
        public static string ImageBufferPath = DataPath + "\\ImageBuffer";

        public static DirectoryInfo StripMapDir => Directory.CreateDirectory(DataDir.FullName + "StripMap\\");
        public static DirectoryInfo StripMapDeletedDir => Directory.CreateDirectory(StripMapDir.FullName + "Deleted\\");

        public static string MHSPath = AppPath + "\\MHS2";
        public static string MHSRecipePath = MHSPath + "\\Recipe";
        public static string MHSRecipeName = "default";
        public static string MHSRecipeExt = ".hdlr";

        public static string MHSDIOAddFile = MHSPath + "\\DIOAdd.ini";
        internal static string MHSMotorParaFile = MHSPath + "\\MotorPara.ini";

        public static string BufferPath = "c:\\NSW_Buffer";
        #endregion

        public static string ProgFolder
        {
            get
            {
                string Path = ProgPath + "\\" + ProgRecipeName;
                try
                {
                    if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message.ToString()); }
                return Path;
            }
        }

        public static void CreateDirs()
        {
            if (!Directory.Exists(AppPath)) { Directory.CreateDirectory(AppPath); }

            if (!Directory.Exists(ConfigPath)) { Directory.CreateDirectory(ConfigPath); }
            if (!Directory.Exists(SetupPath)) { Directory.CreateDirectory(SetupPath); }

            //if (!Directory.Exists(RecipePath)) { Directory.CreateDirectory(RecipePath); }
            if (!Directory.Exists(MHSPath)) { Directory.CreateDirectory(MHSPath); }

            if (!Directory.Exists(DataPath)) { Directory.CreateDirectory(DataPath); }
            if (!Directory.Exists(WeightPath)) { Directory.CreateDirectory(WeightPath); }
            if (!Directory.Exists(WeightMeasPath)) { Directory.CreateDirectory(WeightMeasPath); }
            if (!Directory.Exists(ResourcesPath)) { Directory.CreateDirectory(ResourcesPath); }
            if (!Directory.Exists(BiasKernelPath)) { Directory.CreateDirectory(BiasKernelPath); }
        }



        public const string RegSubKey_DispProg = "DispCore\\UI\\DispProg";

        public static string CmdHelpFilename = "Command_Help.pdf";
        public static string CmdHelpFile = Application.StartupPath + "\\" + CmdHelpFilename;

        public static bool EnableLotEntry = false;

        public static void LoadDefault()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(AppPath + "\\" + "DispCore" + ".def");

            TaskDisp.Material_Life_EndTime = DateTime.Now;
            string s = IniFile.ReadString("Material", "Life_End_Time", "");
            try
            {
                TaskDisp.Material_Life_EndTime = DateTime.ParseExact(s, "yyyy-MM-dd HH:mm:ss", null);// Convert.ToDateTime(s);
            }
            catch
            {
                try { TaskDisp.Material_Life_EndTime = DateTime.ParseExact(s, "M/d/yyyy hh:mm:ss tt", null); } catch { };//maintain reverse compatiblity
            }
            TaskDisp.Material_LifePreAlert_Time = TaskDisp.Material_Life_EndTime.AddMinutes((double)-TaskDisp.Material_ExpiryPreAlertTime);

            for (int i = 0; i < TaskDisp.MAX_HEADCOUNT; i++)
            {
                Maint.PP.FillCount[i] = IniFile.ReadInteger("Maint", "PP_FillCount_" + i.ToString(), 0);
                Maint.PP.StartDateTime[i] = DateTime.Now;
                string PP_s = IniFile.ReadString("Maint", "PP_StartDateTime_" + i.ToString(), "");
                try
                {
                    Maint.PP.StartDateTime[i] = DateTime.ParseExact(PP_s, "yyyy-MM-dd HH:mm:ss", null);// Convert.ToDateTime(s);
                }
                catch
                {
                    try
                    {
                        Maint.PP.StartDateTime[i] = DateTime.ParseExact(PP_s, "M/d/yyyy hh:mm:ss tt", null);
                    }
                    catch { };//maintain reverse compatiblity
                }
                string VM_s = IniFile.ReadString("Maint", "Vermes_StartDateTime_" + i.ToString(), "");

                Maint.Disp.Count[i] = IniFile.ReadInteger("Maint", "Unit_Count_" + i.ToString(), 0);
                Maint.Disp.CountResetDateTime[i] = DateTime.Now;
                try
                {
                    Maint.Disp.CountResetDateTime[i] = DateTime.ParseExact(VM_s, "yyyy-MM-dd HH:mm:ss", null);
                }
                catch { };

                Material.Unit.Count[i] = IniFile.ReadInteger("Material", "Unit_Count" + i, 0);
            }

            Log.dtNextCopyToBuffer = Convert.ToDateTime(IniFile.ReadString("Log", "DTSendToPurge", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
        public static void SaveDefault()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(AppPath + "\\" + "DispCore" + ".def");
            IniFile.WriteString("Material", "Life_End_Time", TaskDisp.Material_Life_EndTime.ToString("yyyy-MM-dd HH:mm:ss"));// "MM/dd/yyyy HH:mm tt"));

            for (int i = 0; i < TaskDisp.MAX_HEADCOUNT; i++)
            {
                IniFile.WriteInteger("Maint", "PP_FillCount_" + i.ToString(), Maint.PP.FillCount[i]);
                IniFile.WriteString("Maint", "PP_StartDateTime_" + i.ToString(), Maint.PP.StartDateTime[i].ToString("yyyy-MM-dd HH:mm:ss"));// "MM/dd/yyyy HH:mm tt"));

                IniFile.WriteInteger("Maint", "Unit_Count_" + i.ToString(), Maint.Disp.Count[i]);
                IniFile.WriteString("Maint", "Unit_CountResetDateTime_" + i.ToString(), Maint.Disp.CountResetDateTime[i].ToString("yyyy-MM-dd HH:mm:ss"));

                IniFile.WriteInteger("Maint", "Unit_Count_" + i.ToString(), Maint.Disp.Count[i]);

                IniFile.WriteInteger("Material", "Unit_Count" + i, Material.Unit.Count[i]);
            }

            IniFile.WriteString("Log", "Log.dtSentToPurge", Log.dtNextCopyToBuffer.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public static string EquipmentID = "NSW";


        #region Device
        public static bool LoadDevice(string FName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(GDefine.DevicePath, FName + "." + GDefine.DeviceRecipeExt);

            string progName = IniFile.ReadString("DISPCORE", "PROGRAM NAME", "DEFAULT");
            GDefine.MHSRecipeName = IniFile.ReadString("Handler", "Recipe", "Default");

            if (!File.Exists(GDefine.DevicePath + FName + "." + GDefine.DeviceRecipeExt))
            {
                SaveDevice(FName, false);
            }

            GDefine.Table.Load();
            if (GDefine.GantryConfig != EGantryConfig.XZ_YTABLE)
            TaskMHS.LoadRecipe(GDefine.MHSRecipeName);

            try
            {
                if (!DispProg.LoadProgName(progName)) return false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return false;
            }

            return true;
        }
        public static void SaveDevice(string FName, bool SaveAll)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            IniFile.Create(GDefine.DevicePath, FName + "." + GDefine.DeviceRecipeExt);
            IniFile.WriteString("DEVICE RECIPE", "DEVICE RECIPE", FName);

            IniFile.WriteString("Handler", "Recipe", GDefine.MHSRecipeName);
            IniFile.WriteString("DISPCORE", "PROGRAM NAME", GDefine.ProgRecipeName);

            if (SaveAll)
            {
                GDefine.Table.Save();
                NDispWin.TaskMHS.SaveRecipe();

                NDispWin.Intf.Config.Save();
                NDispWin.Intf.Setup.Save();
                DispProg.Save();
                GDefineN.Save();
            }
        }
        #endregion

        #region Gantry Config
        public static int LogLevel = 0;
        public enum EGantryConfig { XZ_YTABLE, XYZ, XY_ZX2Y2_Z2, XY_RX_Z, XY_RXRY_Z, XYZ_X4Y4Z4 };
        public static EGantryConfig GantryConfig = EGantryConfig.XYZ;
        public enum EHeadConfig { Single, Dual };
        public static EHeadConfig HeadConfig = EHeadConfig.Single;

        public enum ECameraType { None, Basler, Emulator, PtGrey, Spinnaker, Spinnaker2, MVSGenTL };
        public enum ELCType { None, LCSerial, LCSerLegacy };
        public enum EHeightSensorType { None, IDL1700, IDL1302, IFD2451, DONOTUSE, IDL1X20, IFD2421, IDL1750, IFD2422, CL3000};
        //public enum EWeightStType { None, JB1603, ALD214 };
        //public enum ECleanStType { None, Type1 };
        //public enum EPurgeStType { None, Type1 };
        public enum EPreDispStType { None, Type1 };
        public enum EZSensorType { None, Sensor, Encoder };//Type1 - PinType, //Type2 - LinearEncoder
        public static EZSensorType ZSensorType = EZSensorType.None;
        public static double ZSensor_DistPerPulse = 0.0005;


        public enum EBottomCamType { None, External, ATNC }
        public static EBottomCamType BottomCamType = EBottomCamType.None;

        public enum EDispCtrlType { None, HPC_OBSOLETE, HPC15, Vermes, Vermes1560 };
        //public static ECameraType CameraType = ECameraType.None;
        //public static string CameraIPAddress = "192.168.0.100";
        public enum EDispHeaterType { None, Vermes_HC48 };

        public const int MAX_CAMERA = 3;
        public static ECameraType[] CameraType = new ECameraType[MAX_CAMERA];
        //public static ECameraType CameraTypeA = ECameraType.None;
        //public static bool[] CameraEnable = new bool[MAX_CAMERA] { false, false, false };
        public static string[] CameraIPAddress = new string[MAX_CAMERA];// "192.168.0.100";


        public static ELCType LCType = ELCType.None;
        public static int LCComport = 0;
        public static EHeightSensorType HSensorType = EHeightSensorType.None;
        public static int HSensorComport = 0;
        public static string HSensorIPAddress = "";

        public static WGH_Series.TEWeight.EWeighType WeightStType = WGH_Series.TEWeight.EWeighType.None;
        public static int WeightComport = 0;

        public static EDispCtrlType[] DispCtrlType = new EDispCtrlType[2] { EDispCtrlType.None, EDispCtrlType.None };
        public static int[] DispCtrlComport = new int[2] { 1, 2 };

        public static EDispHeaterType[] DispHeaterType = new EDispHeaterType[2] { EDispHeaterType.None, EDispHeaterType.None };
        public static string[] DispHeaterComport = new string[2] { "COM2", "COM2" };

        public static int[] FPressComport = new int[2] { 1, 2 };

        //public enum EIDReader { None, DataMan, QRCode, DataMatrix }
        //public static EIDReader IDReader_Type = EIDReader.None;
        //public static string IDReader_Addr = "COM1";

        public enum ETempCtrl { None, Autonics_TX_TK }
        public static ETempCtrl TempCtrl_Type = ETempCtrl.None;

        public static Modbus.Autonics_TX Autonics_TX = new Modbus.Autonics_TX();
        public static string TempCtrl_PortName = "COM1";
        //public static int TempCtrl_PreHeatID = 0;
        //public static int TempCtrl_DispHeatID = 0;
        public enum ETempCtrlModule { None, LifterHeat, PumpCooler, ExternalHeat_RTD };
        public static ETempCtrlModule[] TempCtrl_Module = new ETempCtrlModule[4]{ETempCtrlModule.None,ETempCtrlModule.None,ETempCtrlModule.None,ETempCtrlModule.None };
        
        public static ExtVision.EType ExtVisType = ExtVision.EType.None;
        public static string ExtVisIPAddress = "192.168.0.10";
        public static int ExtVisPort = 8500;

        public static bool SaveSystemConfig(string ConfigName)
        {
            const string SUBKEY = "NSWAUTOMATION_CONFIG";
            NUtils.RegistryWR RegWR = new NUtils.RegistryWR("Software");
            RegWR.WriteKey(SUBKEY, "EquipmentName", EquipmentID);

            string FileName = "";
            if (ConfigName.Length > 0)
                FileName = GDefine.ConfigPath + "\\Gantry.Config." + ConfigName + ".ini";
            else
                FileName = GDefine.ConfigPath + "\\Gantry.Config.ini";

            TaskGantry.SaveDeviceConfig(FileName);

            //NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            NUtils.IniFile IniFile = new NUtils.IniFile(FileName);

            //IniFile.WriteInteger("General", "LogLevel", LogLevel);

            IniFile.WriteInteger("GantryConfig", "Type", (int)GantryConfig);
            IniFile.WriteInteger("HeadConfig", "Type", (int)HeadConfig);

            for (int i = 0; i < MAX_CAMERA; i++)
            {
                string section = "Camera";
                if (i > 0) section = section + i.ToString();
                IniFile.WriteInteger(section, "Type", (int)CameraType[i]);
                IniFile.WriteString(section, "IPAddress", CameraIPAddress[i]);
            }

            IniFile.WriteInteger("LC", "Type", (int)LCType);
            IniFile.WriteInteger("LC", "ComPort", LCComport);
            IniFile.WriteInteger("HSensor", "Type", (int)HSensorType);
            IniFile.WriteInteger("HSensor", "ComPort", HSensorComport);
            IniFile.WriteString("HSensor", "IPAddress", HSensorIPAddress);

            IniFile.WriteInteger("ZSensor", "Type", (int)ZSensorType);
            IniFile.WriteDouble("ZSensor", "DistPerPulse", ZSensor_DistPerPulse);
            IniFile.WriteInteger("BottomCam", "Type", (int)BottomCamType);
            IniFile.WriteInteger("WeightSt", "Type", (int)WeightStType);
            IniFile.WriteInteger("Weight", "ComPort", WeightComport);

            IniFile.WriteInteger("DispCtrl1", "Type", (int)DispCtrlType[0]);
            IniFile.WriteInteger("DispCtrl1", "ComPort", DispCtrlComport[0]);
            IniFile.WriteInteger("DispCtrl2", "Type", (int)DispCtrlType[1]);
            IniFile.WriteInteger("DispCtrl2", "ComPort", DispCtrlComport[1]);

            IniFile.WriteString("DispHeater1", "Type", DispHeaterType[0].ToString());
            IniFile.WriteString("DispHeater1", "Comport", DispHeaterComport[0].ToString());
            IniFile.WriteString("DispHeater2", "Type", DispHeaterType[1].ToString());
            IniFile.WriteString("DispHeater2", "Comport", DispHeaterComport[1].ToString());

            IniFile.WriteInteger("FPressCtrl", "Type", (int)SysConfig.FPressAdjType);
            IniFile.WriteDouble("FPressCtrl", "Gain_A", FPressCtrl.Gain[0]);
            IniFile.WriteDouble("FPressCtrl", "Gain_B", FPressCtrl.Gain[1]);

            IniFile.WriteInteger("FPressCtrl1", "ComPort", FPressComport[0]);
            IniFile.WriteInteger("FPressCtrl2", "ComPort", FPressComport[1]);

            IniFile.WriteInteger("FPressCtrl", "PressUnit", (int)FPressCtrl.PressUnit);

            IniFile.WriteInteger("TempSensor", "Type", (int)SysConfig.TempSensorType);
            IniFile.WriteString("TempSensor", "Comport", SysConfig.TempSensorComport);

            IniFile.WriteInteger("VideoLogger", "Type", (int)SysConfig.VideoLoggerType);
            IniFile.WriteInteger("VideoLogger", "Port", SysConfig.VideoLoggerPort);

            IniFile.WriteInteger("TempCtrl", "Type", (int)TempCtrl_Type);
            IniFile.WriteString("TempCtrl", "ComPort", TempCtrl_PortName);

            for (int i = 0; i < 4; i++)
            {
                IniFile.WriteInteger("TempCtrl", "Module" + i.ToString(), (int)TempCtrl_Module[i]);
            }

            IniFile.WriteInteger("ExtVis", "Type", (int)ExtVisType);
            IniFile.WriteString("ExtVis", "IPAddress", ExtVisIPAddress);
            IniFile.WriteInteger("ExtVis", "Port", ExtVisPort);

            return true;
        }
        public static bool LoadSystemConfig(string ConfigName)
        {
            const string SUBKEY = "NSWAUTOMATION_CONFIG";
            NUtils.RegistryWR RegWR = new NUtils.RegistryWR("Software");
            EquipmentID = RegWR.ReadKey(SUBKEY, "EquipmentName", "NSW");
            if (EquipmentID == null || EquipmentID == "" || EquipmentID == "NSW")
            {
                string s = HDDFunction.HDD_SerialNo();
                s = s.Trim();
                string s4 = s.Remove(0, s.Length - 4);
                EquipmentID = "NSW-" + s4;
            }

            string FileName = "";
            if (ConfigName.Length > 0)
                FileName = GDefine.ConfigPath + "\\" + ConfigName + ".ini";
            else
            {
                FileName = GDefine.ConfigPath + "\\Gantry.Config.ini";
                if (!File.Exists(FileName)) TaskGantry.SaveDeviceConfig(FileName);
            }

            TaskGantry.LoadDeviceConfig(FileName);

            //NSW.Net.IniFile IniFile = new NSW.Net.IniFile();
            NUtils.IniFile IniFile = new NUtils.IniFile(FileName);

            //LogLevel = IniFile.ReadInteger("General", "LogLevel", 0);

            GantryConfig = (EGantryConfig)IniFile.ReadInteger("GantryConfig", "Type", (int)EGantryConfig.XYZ);
            HeadConfig = (EHeadConfig)IniFile.ReadInteger("HeadConfig", "Type", 0);

            for (int i = 0; i < MAX_CAMERA; i++)
            {
                string section = "Camera";
                if (i > 0) section = section + i.ToString();
                int camType = IniFile.ReadInteger(section, "Type", (int)ECameraType.None);
                CameraType[i] = camType < Enum.GetNames(typeof(ECameraType)).Length ? (ECameraType)camType : ECameraType.None; 
                CameraIPAddress[i] = IniFile.ReadString(section, "IPAddress", "0.0.0.0");
            }

            LCType = (ELCType)IniFile.ReadInteger("LC", "Type", (int)EHeightSensorType.None);
            LCComport = IniFile.ReadInteger("LC", "ComPort", 3);

            HSensorType = EHeightSensorType.None;
            try { HSensorType = (EHeightSensorType)IniFile.ReadInteger("HSensor", "Type", (int)EHeightSensorType.None); } catch { };
            HSensorComport = IniFile.ReadInteger("HSensor", "ComPort", 3);
            HSensorIPAddress = IniFile.ReadString("HSensor", "IPAddress", "169.254.168.150");

            //ZSensorType = EZSensorType.None;
            //try
            //{
                ZSensorType = (EZSensorType)IniFile.ReadInteger("ZSensor", "Type", (int)EZSensorType.None);
            //}
            //catch { };

            ZSensor_DistPerPulse = IniFile.ReadDouble("ZSensor", "DistPerPulse", 0.0005);

            BottomCamType = (EBottomCamType)IniFile.ReadInteger("BottomCam", "Type", (int)EBottomCamType.None);
            WeightStType = (WGH_Series.TEWeight.EWeighType)IniFile.ReadInteger("WeightSt", "Type", (int)WGH_Series.TEWeight.EWeighType.None);
            WeightComport = IniFile.ReadInteger("Weight", "ComPort", 4);

            DispCtrlType[0] = (EDispCtrlType)IniFile.ReadInteger("DispCtrl1", "Type", (int)EDispCtrlType.None);
            DispCtrlComport[0] = IniFile.ReadInteger("DispCtrl1", "ComPort", 1);
            DispCtrlType[1] = (EDispCtrlType)IniFile.ReadInteger("DispCtrl2", "Type", (int)EDispCtrlType.None);
            DispCtrlComport[1] = IniFile.ReadInteger("DispCtrl2", "ComPort", 2);

            DispHeaterType[0] = EDispHeaterType.None;
            string sType = IniFile.ReadString("DispHeater1", "Type", DispHeaterType[0].ToString());
            Enum.TryParse(sType, out DispHeaterType[0]);
            DispHeaterComport[0] = IniFile.ReadString("DispHeater1", "Comport", "COM2");

            DispHeaterType[1] = EDispHeaterType.None;
            sType = IniFile.ReadString("DispHeater2", "Type", DispHeaterType[1].ToString());
            Enum.TryParse(sType, out DispHeaterType[1]);
            DispHeaterComport[1] = IniFile.ReadString("DispHeater2", "Comport", "COM2");

            FPressComport[0] = IniFile.ReadInteger("FPressCtrl1", "ComPort", 8);
            FPressComport[1] = IniFile.ReadInteger("FPressCtrl2", "ComPort", 9);

            FPressCtrl.PressUnit = (FPressCtrl.EPressUnit)IniFile.ReadInteger("FPressCtrl", "PressUnit", 0);

            SysConfig.FPressAdjType = (SysConfig.EFPressAdjType)IniFile.ReadInteger("FPressCtrl", "Type", 0);
            FPressCtrl.Gain[0] = IniFile.ReadDouble("FPressCtrl", "Gain_A", 1);
            FPressCtrl.Gain[1] = IniFile.ReadDouble("FPressCtrl", "Gain_B", 1);

            try { SysConfig.TempSensorType = (SysConfig.ETempSensorType)IniFile.ReadInteger("TempSensor", "Type", 0); } catch { SysConfig.TempSensorType = 0; }
            SysConfig.TempSensorComport = IniFile.ReadString("TempSensor", "Comport", "COM1");

            try { SysConfig.VideoLoggerType = (SysConfig.EVideoLoggerType)IniFile.ReadInteger("VideoLogger", "Type", 0); } catch { SysConfig.VideoLoggerType = 0; }
            SysConfig.VideoLoggerPort = IniFile.ReadInteger("VideoLogger", "Port", 11000);

            TempCtrl_Type = (ETempCtrl)IniFile.ReadInteger("TempCtrl", "Type", 0);
            TempCtrl_PortName = IniFile.ReadString("TempCtrl", "ComPort", "COM0");
            int TempCtrl_PreHeatID = IniFile.ReadInteger("TempCtrl", "PreHeatID", 0);
            int TempCtrl_DispHeatID = IniFile.ReadInteger("TempCtrl", "DispHeatID", 0);
            TempCtrl_Module[0] = ETempCtrlModule.None;
            TempCtrl_Module[1] = ETempCtrlModule.None;
            TempCtrl_Module[2] = ETempCtrlModule.None;
            TempCtrl_Module[3] = ETempCtrlModule.None;
            try
            {
                TempCtrl_Module[0] = (ETempCtrlModule)IniFile.ReadInteger("TempCtrl", "Module0", TempCtrl_DispHeatID == 1 ? (int)ETempCtrlModule.LifterHeat : (int)ETempCtrlModule.None);
                TempCtrl_Module[1] = (ETempCtrlModule)IniFile.ReadInteger("TempCtrl", "Module1", TempCtrl_DispHeatID == 2 ? (int)ETempCtrlModule.LifterHeat : (int)ETempCtrlModule.None);
                TempCtrl_Module[2] = (ETempCtrlModule)IniFile.ReadInteger("TempCtrl", "Module2", (int)ETempCtrlModule.None);
                TempCtrl_Module[3] = (ETempCtrlModule)IniFile.ReadInteger("TempCtrl", "Module3", (int)ETempCtrlModule.None);
            }
            catch { }

            ExtVisType = ExtVision.EType.None;
            try { ExtVisType = (ExtVision.EType)IniFile.ReadInteger("ExtVis", "Type", 0); } catch { };
            ExtVisIPAddress = IniFile.ReadString("ExtVis", "IPAddress", ExtVisIPAddress);
            ExtVisPort = IniFile.ReadInteger("ExtVis", "Port", ExtVisPort);

            return true;
        }
        public static bool LoadSystemConfig()
        {
            return LoadSystemConfig("");
        }
        #endregion

        #region Camera
        public static string[] CameraSerialNo = new string[MAX_CAMERA];// "1234";

        public const int MAX_MCAMERA = 2;
        public static ECameraType[] MCameraType = new ECameraType[MAX_MCAMERA];
        public static string[] MCameraIPAddress = new string[MAX_MCAMERA];
        public static string[] MCameraSerialNo = new string[MAX_MCAMERA];

        public static double[] MCameraExposure = new double[MAX_MCAMERA];
        public static double[] MCameraGain = new double[MAX_MCAMERA];
        public static bool[] MCameraReverseX = new bool[MAX_MCAMERA];
        public static bool[] MCameraReverseY = new bool[MAX_MCAMERA];

        public static bool MCameraAutoShow = false;
        public static Rectangle MCameraLocation = new Rectangle(0, 0, 600, 400);
        public static bool MCameraSwapPos = false;
        #endregion

        #region Machine Setup
        public static EOperationSpeed OperationSpeed = EOperationSpeed.Safe;
        public static double Operation_SpeedMode_SafeSpeedRatio = 0.25;
        public static double Operation_SpeedMode_SlowSpeedRatio = 0.05;
        public static double Operation_SpeedMode_SlowSpeedTimeFactor = 5;
        #endregion

        public static EStatus Status = EStatus.Unknown;
        public static bool SwDoor = true;//variable updated by MHS
        public static bool InPressureInRange = true;//variable updated by MHS

        #region utitlities
        static Stopwatch sw_TickCount = new Stopwatch();
        internal static int GetTickCount()
        {
            if (!sw_TickCount.IsRunning)
            {
                sw_TickCount.Start();
            }

            int D = (int)sw_TickCount.ElapsedMilliseconds;
            return D;
        }

        public static bool GenerateXYZPlaneEquation(double X1, double Y1, double Z1, double X2, double Y2, double Z2, double X3, double Y3, double Z3, out double A, out double B, out double C)
        {
            /* Alternative
             * Ax1 + By1 + Cz1 = 0
             * Ax2 + By2 + Cz2 = 0
             * Ax3 + By3 + Cz3 = 0
             *     |1 y1 z1|        |x1 1 z1|       |x1 y1 1|        |x1 y1 z1|
             * A = |1 y2 z2|    B = |x2 1 z2|   C = |x2 y2 1|   D = -|x2 y2 z2|
             *     |1 y3 z3|        |x3 1 z3|       |x3 y3 1|        |x3 y3 z3|
             * 
             * A = y2z3-y3z2-y1(z3-z2)+z1(y3-y2)
             * B = x1(z3-z2)-(x2z3-x3z2)+z1(x2-x3)
             * C = x1(y2-y3)-y1(x2-x3)+(x2y3-x3y2)
             * D = -x1(y2z3-y3z2)-y1(x2z3-x3z2)+z1(x2y3-x3y2)
             * 
             * Ax + By + Cz + D = 0;
             * Cz = -Ax -By -D
             * z = -(A/C)x - (B/C)y - D/C  
             */

            A = 0;
            B = 0;
            C = 0;

            try
            {
                //check error

                //determine vector ab, ac
                double iab = X2 - X1;
                double jab = Y2 - Y1;
                double kab = Z2 - Z1;

                double iac = X3 - X1;
                double jac = Y3 - Y1;
                double kac = Z3 - Z1;

                //determine product
                //n = i-j+k
                double i = jab * kac - jac * kab;
                double j = (iab * kac - iac * kab) * -1;
                double k = iab * jac - iac * jab;

                //determine formula aX+bY+cZ+d=0
                double aX = i * X1;
                double bY = j * Y1;
                double cZ = k * Z1;
                double d = -aX - bY - cZ;

                //aX+bY+cZ+d = 0
                //cZ = -aX-bY-d
                //Z = -(a/c)*X -(b/c)*X -(d/c) 
                A = (double)(-i / k);
                B = (double)(-j / k);
                C = (double)(-d / k);
            }
            catch
            {
                return false;
            }

            return true;
        }
        public static bool Arc3PGetInfo(double x1, double y1, double x2, double y2, double x3, double y3, ref double xc, ref double yc, ref double rad)
        {
            #region formula
            //mr = (y2 - y1)/(x2 - x1)
            //mt = (y3 - y2)/(x3 - x2)

            //x = (mr*mt*(y3-y1) + mr(x2+x3) - mt(x1+x2))/(2(mr - mt))
            //y = -(1 / mr) * (x - (x1 + x2) / 2) + ((y1 + y2) / 2);
            #endregion

            #region calc slope, center and rad
            double mr = 0;
            double mt = 0;

            if ((x1 == x2 && x2 == x3) || (y1 == y2 && y2 == y3))
            {
                throw new Exception("Points in 1 line. Unable to generate circle or arc.");
            }

            if (x1 == x2)
            {
                mr = (y3 - y1) / (x3 - x1);
                mt = (y2 - y3) / (x2 - x3);

                xc = (mr * mt * (y3 - y1) + mr * (x3 + x3) - mt * (x1 + x3)) / (2 * (mr - mt));
                yc = -(1 / mr) * (xc - (x1 + x3) / 2) + ((y1 + y3) / 2);
                rad = (double)Math.Sqrt(Math.Pow(x3 - xc, 2) + Math.Pow(y3 - yc, 2));
            }
            else
                if (x1 == x3)
            {
                mr = (y2 - y1) / (x2 - x1);
                mt = (y3 - y2) / (x3 - x2);

                xc = (mr * mt * (y3 - y1) + mr * (x2 + x3) - mt * (x1 + x2)) / (2 * (mr - mt));
                yc = -(1 / mr) * (xc - (x1 + x2) / 2) + ((y1 + y2) / 2);
                rad = (double)Math.Sqrt(Math.Pow(x2 - xc, 2) + Math.Pow(y2 - yc, 2));
            }
            else
            //if (x2 == x3)
            {
                mr = (y1 - y2) / (x1 - x2);
                mt = (y3 - y1) / (x3 - x1);

                xc = (mr * mt * (y3 - y2) + mr * (x1 + x3) - mt * (x2 + x1)) / (2 * (mr - mt));
                yc = -(1 / mr) * (xc - (x2 + x1) / 2) + ((y2 + y1) / 2);
                rad = (double)Math.Sqrt(Math.Pow(x1 - xc, 2) + Math.Pow(y1 - yc, 2));
            }
            #endregion

            return true;
        }
        public static bool Arc3PGetInfo(double x1, double y1, double x2, double y2, double x3, double y3, ref double xc, ref double yc, ref double rad,
            ref double StartA, ref double EndA, ref double SweepA, ref double Dir)
        {
            if (!Arc3PGetInfo(x1, y1, x2, y2, x3, y3, ref xc, ref yc, ref rad)) return false;

            //CCW dir value is negative -3.142 ~ 3.142
            double f_StartA = (double)Math.Atan2((y1 - yc), (x1 - xc));
            double f_EndA = (double)Math.Atan2((y3 - yc), (x3 - xc));

            StartA = f_StartA;
            EndA = f_EndA;


            //dir <0: CCW, >0: CW
            //Dir = ((x1 - x3) * (y2 - y3) - (y1 - y3) * (x2 - x3)) / 2;
            Dir = ((x1 - x2) * (y3 - y2) - (y1 - y2) * (x3 - x2)) / 2;

            //StartA = Math.PI + StartA;
            //EndA = Math.PI + EndA;

            //SweepA = EndA - StartA;

            if (StartA > EndA)
                SweepA = EndA - StartA;
            else
                SweepA = (Math.PI * 2) - (EndA - StartA);

            SweepA = Math.Abs(SweepA);// EndA - StartA;



            //if (SweepA < 0)
            //{
            //    SweepA = (Math.PI * 2) + SweepA;
            //}

            if (Dir < 0) SweepA = (Math.PI * 2) - SweepA;

            ////if (StartA < 0) StartA = StartA + Math.PI*2;
            ////if (EndA < 0) EndA = EndA + Math.PI * 2;

            ////if (EndA > StartA) SweepA = EndA - StartA;
            ////else
            ////    SweepA = (Math.PI*2 - StartA) + EndA;

            return true;
        }
        public static bool ArcStartCenterLengthGetEndPt(double x1, double y1, double xc, double yc, bool Dir_CW, double Length, ref double xe, ref double ye)
        {
            NSW.Net.Polar Polar_Start = new NSW.Net.Polar(new NSW.Net.Point2D(xc, yc), new NSW.Net.Point2D(x1, y1));

            if (Polar_Start.R == 0) throw new Exception("Invalid Start Point");

            double Angle_Rad = Length / Polar_Start.R;
            if (Dir_CW) Angle_Rad = -Angle_Rad;

            NSW.Net.Point2D Start = new NSW.Net.Point2D(x1, y1);
            NSW.Net.Point2D Center = new NSW.Net.Point2D(xc, yc);
            NSW.Net.Point2D End = new NSW.Net.Point2D(Start);
            End = Start.Rotate(Center, Angle_Rad);

            xe = End.X;
            ye = End.Y;

            return true;
        }
        public static bool ArcStartCenterLengthGetEndPt(double x1, double y1, ref double xc, ref double yc, bool Dir_CW, double Length, double EndOfst, ref double xe, ref double ye)
        {
            NSW.Net.Polar Polar_Start = new NSW.Net.Polar(new NSW.Net.Point2D(xc, yc), new NSW.Net.Point2D(x1, y1));

            if (Polar_Start.R == 0) throw new Exception("Invalid Start Point");

            double Angle_Rad = Length / Polar_Start.R;
            if (Dir_CW) Angle_Rad = -Angle_Rad;

            NSW.Net.Point2D Start = new NSW.Net.Point2D(x1, y1);
            NSW.Net.Point2D Center = new NSW.Net.Point2D(xc, yc);
            NSW.Net.Point2D End = new NSW.Net.Point2D(Start);
            End = Start.Rotate(Center, Angle_Rad);

            //xe = End.X;
            //ye = End.Y;



            double AngleToRotate = Math.Asin((EndOfst / 2) / Polar_Start.R) * 2;

            if (!Dir_CW) AngleToRotate = -AngleToRotate;

            Center = Center.Rotate(Start, AngleToRotate);
            End = End.Rotate(Start, AngleToRotate);

            xc = Center.X;
            yc = Center.Y;

            xe = End.X;
            ye = End.Y;

            return true;
        }

        public static bool CircStartCenterGet3Points(double x1, double y1, double xc, double yc, ref double x2, ref double y2, ref double x3, ref double y3, double Dir)
        {
            NSW.Net.Point2D Pt_Start = new NSW.Net.Point2D(x1, y1);
            NSW.Net.Point2D Pt_Center = new NSW.Net.Point2D(xc, yc);

            NSW.Net.Polar Polar_Start = new NSW.Net.Polar(Pt_Center, Pt_Start);

            NSW.Net.Polar Polar_Pt2 = new NSW.Net.Polar(Polar_Start);
            double A1 = Math.PI * 120 / 180;
            if (Dir > 0) A1 = -A1;
            Polar_Pt2.A = Polar_Pt2.A + A1;
            NSW.Net.Point2D Pt_2 = new NSW.Net.Point2D(Polar_Pt2);
            x2 = Pt_2.X + Pt_Center.X;
            y2 = Pt_2.Y + Pt_Center.Y;


            NSW.Net.Polar Polar_Pt3 = new NSW.Net.Polar(Polar_Start);
            double A2 = -Math.PI * 121 / 180;
            if (Dir > 0) A2 = -A2;
            Polar_Pt3.A = Polar_Pt3.A + A2;
            NSW.Net.Point2D Pt_3 = new NSW.Net.Point2D(Polar_Pt3);
            x3 = Pt_3.X + Pt_Center.X;
            y3 = Pt_3.Y + Pt_Center.Y;

            return true;
        }
        public static bool CircStartCenterGetThruPoint(double x1, double y1, double xc, double yc, double xe, double ye, ref double xt, ref double yt, double Dir)
        {
            NSW.Net.Point2D Pt_Start = new NSW.Net.Point2D(x1, y1);
            NSW.Net.Point2D Pt_Center = new NSW.Net.Point2D(xc, yc);
            NSW.Net.Point2D Pt_End = new NSW.Net.Point2D(xe, ye);

            NSW.Net.Polar Polar_Start = new NSW.Net.Polar(Pt_Center, Pt_Start);
            NSW.Net.Polar Polar_End = new NSW.Net.Polar(Pt_Center, Pt_End);

            double SweepA = 0;

            if (Polar_Start.A > Polar_End.A)
                SweepA = Polar_End.A - Polar_Start.A;
            else
                SweepA = (Math.PI * 2) - (Polar_End.A - Polar_Start.A);

            SweepA = Math.Abs(SweepA);
            if (Dir < 0) SweepA = (Math.PI * 2) - SweepA;

            NSW.Net.Polar Polar_Thru = new NSW.Net.Polar(Polar_Start);
            if (Dir < 0)//CCW
                Polar_Thru.A = Polar_Thru.A - SweepA / 2;
            else//CW
                Polar_Thru.A = Polar_Thru.A + SweepA / 2;

            NSW.Net.Point2D Pt_Thru = new NSW.Net.Point2D(Polar_Thru);
            xt = Pt_Thru.X + Pt_Center.X;
            yt = Pt_Thru.Y + Pt_Center.Y;

            return true;
        }

        public static bool SmCircleGetInfo(double StartX, double StartY, double CenterX, double CenterY, bool Dir_CW,
            ref double StartArc_Len, ref double MainArc_Len, ref double OverlapArc_Len, ref double EndArc_Len,
            ref double StartArc_EndX, ref double StartArc_EndY, ref double MainArc_EndX, ref double MainArc_EndY,
            ref double OverlapArc_EndX, ref double OverlapArc_EndY, ref double EndArc_EndX, ref double EndArc_EndY)
        {
            bool Result = true;

            NSW.Net.Polar Polar_Start = new NSW.Net.Polar(new NSW.Net.Point2D(CenterX, CenterY), new NSW.Net.Point2D(StartX, StartY));

            double CircleLength = Polar_Start.R * 2 * Math.PI;
            double QuarterLength = CircleLength / 4;

            if (StartArc_Len > QuarterLength) StartArc_Len = QuarterLength;
            StartArc_Len = Math.Round(StartArc_Len, 3);
            try
            {
                GDefine.ArcStartCenterLengthGetEndPt(StartX, StartY, CenterX, CenterY, Dir_CW, StartArc_Len, ref StartArc_EndX, ref StartArc_EndY);
            }
            catch { Result = false; }

            MainArc_Len = CircleLength - StartArc_Len;
            MainArc_Len = Math.Round(MainArc_Len, 3);
            MainArc_EndX = StartX;
            MainArc_EndY = StartY;

            if (OverlapArc_Len > StartArc_Len) OverlapArc_Len = StartArc_Len;
            OverlapArc_Len = Math.Round(OverlapArc_Len, 3);
            try
            {
                GDefine.ArcStartCenterLengthGetEndPt(StartX, StartY, CenterX, CenterY, Dir_CW, OverlapArc_Len, ref OverlapArc_EndX, ref OverlapArc_EndY);
            }
            catch { Result = false; }

            if (EndArc_Len > CircleLength) EndArc_Len = CircleLength;
            EndArc_Len = Math.Round(EndArc_Len, 3);
            try
            {
                GDefine.ArcStartCenterLengthGetEndPt(OverlapArc_EndX, OverlapArc_EndY, CenterX, CenterY, Dir_CW, EndArc_Len, ref EndArc_EndX, ref EndArc_EndY);
            }
            catch { Result = false; }

            return Result;
        }

        public static void RefreshInput(object sender, bool B)
        {
            if (B)
            {
                (sender as Label).BackColor = Color.Lime;
            }
            else
            {
                (sender as Label).BackColor = SystemColors.Control;
            }
        }
        public static void RefreshOutput(object sender, bool B)
        {
            if (B)
            {
                (sender as Button).BackColor = Color.Red;
            }
            else
            {
                (sender as Button).BackColor = SystemColors.Control;
            }
        }
        public static void UpdateInfo(object sender, CControl2.TDevice Device)
        {
            string S = "NONE";
            if (Device.Type == CControl2.EDeviceType.NONE)
            {

            }
            else
            {
                string Type = Enum.GetName(typeof(CControl2.EDeviceType), Device.Type);

                S = Type + "-" + Device.ID + " (" + Type + ")" + (char)13 + "BID " + Device.ID.ToString("X");
                if (Device.Type == CControl2.EDeviceType.ZKAZIO3001 ||
                    Device.Type == CControl2.EDeviceType.ZKAZM302 ||
                    Device.Type == CControl2.EDeviceType.ZKAZM304)
                {
                    S = S + " IP " + Device.IPAddress;
                }
            }
            (sender as Label).Text = S;
        }
        public static void UpdateInfo(object sender, CControl2.TAxis Axis)
        {
            string DevType = Enum.GetName(typeof(CControl2.EDeviceType), Axis.Device.Type);

            string Desc = "-";
            if (Axis.Device.Type == CControl2.EDeviceType.NONE)
            { }
            else
            {
                Desc = "M" + (Axis.Mask + 1).ToString() + (char)13;
                Desc = Desc + DevType + " BID " + Axis.Device.ID.ToString() + " Motor Axis " + Axis.Mask.ToString();
            }
            (sender as Label).Text = Desc;
        }
        public static void UpdateInfo(object sender, CControl2.TInput Input)
        {
            string DevType = Enum.GetName(typeof(CControl2.EDeviceType), Input.Device.Type);

            int i = -1;
            switch (Input.Mask)
            {
                #region
                case 0x0001: i = 0; break;
                case 0x0002: i = 1; break;
                case 0x0004: i = 2; break;
                case 0x0008: i = 3; break;
                case 0x0010: i = 4; break;
                case 0x0020: i = 5; break;
                case 0x0040: i = 6; break;
                case 0x0080: i = 7; break;
                case 0x0100: i = 8; break;
                case 0x0200: i = 9; break;
                case 0x0400: i = 10; break;
                case 0x0800: i = 11; break;
                case 0x1000: i = 12; break;
                case 0x2000: i = 13; break;
                case 0x4000: i = 14; break;
                case 0x8000: i = 15; break;
                    #endregion
            }

            string Desc = "-";
            if (Input.Device.Type == CControl2.EDeviceType.NONE)
            { }
            else
            {
                string sLabel = (Input.Label.Length > 0 && !Input.Label.Contains("undefined")) ? " [" + Input.Label + "]" : "";
                Desc = "M" + (Input.Axis_Port + 1).ToString() + "-DI" + i.ToString("00") + sLabel + (char)13;
                Desc = Desc + DevType + " BID " + Input.Device.ID.ToString() + " IN " + "Axis " + Input.Axis_Port.ToString() + " Mask " + Input.Mask.ToString();
            }

            (sender as Label).Text = Desc;
        }
        public static void UpdateInfo(object sender, CControl2.TOutput Output)
        {
            string DevType = Enum.GetName(typeof(CControl2.EDeviceType), Output.Device.Type);

            int i = -1;
            switch (Output.Mask)
            {
                #region
                case 0x0001: i = 4; break;
                case 0x0002: i = 5; break;
                case 0x0004: i = 6; break;
                case 0x0008: i = 7; break;
                    #endregion
            }

            string Desc = "-";

            if (Output.Device.Type == CControl2.EDeviceType.NONE)
            { }
            else
            {
                string sLabel = (Output.Label.Length > 0 && !Output.Label.Contains("undefined")) ? " [" + Output.Label + "]" : "";
                Desc = "M" + (Output.Axis_Port + 1).ToString() + "-DO" + i.ToString("00") + sLabel + (char)13;
                Desc = Desc + DevType + " BID " + Output.Device.ID.ToString() + " OUT " + "Axis " + Output.Axis_Port.ToString() + " Mask " + Output.Mask.ToString();
            }
            (sender as Label).Text = Desc;
        }
        #endregion

        public static bool AppSleep(int Time)
        {
            Thread.Sleep(Time);
            return true;
        }

        public const string REG_KEY_STAT_UNIT_COUNT = "UNIT_COUNT";
        public const string REG_KEY_STAT_UPH = "UPH";
        public static void WriteRegStat(string Key, int Value)
        {
            NSW.Net.RegistryUtils Reg = new NSW.Net.RegistryUtils();
            Reg.WriteKey("NSWAUTOMATION_STAT", Key, Value.ToString());
        }


        public enum EConveyorType
        {
            CONVEYOR,
            TABLE_S320A,
        }
        public static EConveyorType ConveyorType;

        #region Table Added 200113
        public static class Table
        {
            public static NDispWin.TPos2 LoadPos = new NDispWin.TPos2(0, 0);
            public static int NumberOfStations = 1;

            //public const int MAX_STATIONS = 8;
            public enum TStStatus
            {
                stNone,//
                stEmpty,
                stWaitLoad,
                stLoaded,
                stInProcess,
                stCompleted,
            }
            public static TStStatus StationStatus = TStStatus.stNone;// new TStStatus;//[MAX_STATIONS];
            public static int CurrentStation = 0;
            public static bool CycleRun;

            public static void Save()
            {
                NUtils.IniFile IniFile = new NUtils.IniFile(GDefine.AppPath + "\\Table.setup.ini");

                IniFile.WriteInteger("Type", "SelectedType", (int)ConveyorType);
                IniFile.WriteDouble("Table", "LoadPosX", LoadPos.X);
                IniFile.WriteDouble("Table", "LoadPosY", LoadPos.Y);
                //IniFile.WriteInteger("Table", "NumberOfStations", NumberOfStations);
                //IniFile.WriteBool("Table", "CycleRun", CycleRun);
            }
            public static void Load()
            {
                NUtils.IniFile IniFile = new NUtils.IniFile(GDefine.AppPath + "\\Table.setup.ini");

                ConveyorType = (EConveyorType)IniFile.ReadInteger("Type", "SelectedType", 0);
                LoadPos.X = IniFile.ReadDouble("Table", "LoadPosX", 0);
                LoadPos.Y = IniFile.ReadDouble("Table", "LoadPosY", 0);
                //NumberOfStations = IniFile.ReadInteger("Table", "NumberOfStations", 1);
                //CycleRun = IniFile.ReadBool("Table", "CycleRun", false);
            }

            public static bool TaskMoveToLoad()
            {
                string EMsg = "MoveToLoad";

                GDefine.Status = EStatus.Busy;

                try
                {
                    if (!NDispWin.TaskGantry.SetMotionParamGZ()) return false;
                    if (!NDispWin.TaskGantry.MoveAbsGZ(0)) return false;

                    if (!NDispWin.TaskGantry.SetMotionParamEx(TaskGantry.GXAxis, TaskGantry.GXAxis.Para.StartV, TaskGantry.GXAxis.Para.FastV, TaskGantry.GXAxis.Para.Accel)) return false;
                    if (!NDispWin.TaskGantry.MoveAbsGXY(LoadPos.X, LoadPos.Y)) return false;
                }
                catch (Exception Ex)
                {
                    EMsg = EMsg + (char)13 + Ex.Message.ToString();
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                    return false;
                }
                GDefine.Status = EStatus.Ready;
                return true;
            }
        }
        #endregion
    }

    public class SysConfig
    {
        public enum EComPorts {COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, COM10, COM11, COM12, COM13, COM14, COM15, COM16 }


        public enum EFPressAdjType { Manual, USB4704, ITVRC2L }
        public static EFPressAdjType FPressAdjType = EFPressAdjType.Manual;

        public enum ETempSensorType { None, UE_thermoCT };
        public static ETempSensorType TempSensorType = ETempSensorType.None;
        public static string TempSensorComport = "COM8";

        public enum EVideoLoggerType { None, VideoLogger };
        public static EVideoLoggerType VideoLoggerType = EVideoLoggerType.None;
        public static int VideoLoggerPort = 11000;
    }

    public class Log
    {
        private static Mutex logMutex = new Mutex();
        public static void AddToLog(string S)
        {
            logMutex.WaitOne();

            string Date = DateTime.Now.Date.ToString("yyyyMMdd");
            string Time = DateTime.Now.ToString("HH:mm:ss tt");
            string MM = DateTime.Now.Month.ToString("00");
            string YYYY = DateTime.Now.Year.ToString("0000");
            //string LogDir = MsgBoxGDefine.LogPath + "\\" + YYYY + MM + "\\";
            string LogDir = GDefine.DataPath + "\\Log\\" + YYYY + MM + "\\";
            string LogFile = LogDir + Date + ".log";

            if (!Directory.Exists(LogDir)) { Directory.CreateDirectory(LogDir); }
            S = Date + (char)9 + Time + (char)9 + S;

            FileStream F = new FileStream(LogFile, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter W = new StreamWriter(F);
            W.WriteLine(S);
            W.Close();

            logMutex.ReleaseMutex();
        }

        private static Mutex logEventMutex = new Mutex();
        public static void AddToEventLog(string S)
        {
            logEventMutex.WaitOne();

            string Date = DateTime.Now.Date.ToString("yyyyMMdd");
            string Time = DateTime.Now.ToString("HH:mm:ss tt");
            string MM = DateTime.Now.Month.ToString("00");
            string YYYY = DateTime.Now.Year.ToString("0000");
            string LogDir = GDefine.DataPath + "\\Event\\" + YYYY + MM + "\\";
            string LogFile = LogDir + "Event_" + Date + ".log";

            if (!Directory.Exists(LogDir)) { Directory.CreateDirectory(LogDir); }
            S = Date + (char)9 + Time + (char)9 + S;

            FileStream F = new FileStream(LogFile, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter W = new StreamWriter(F);
            W.WriteLine(S);
            W.Close();

            logEventMutex.ReleaseMutex();
        }
        public static void AddToEventLog(int EventCode, string Desc, string Para = "")
        {
            AddToEventLog("Event" + (char)9 + EventCode + (char)9 + Desc + " " + Para);
        }

        public static NUtils.LogFileW Laser = new NUtils.LogFileW(GDefine.DataPath + "\\Laser");
        public static NUtils.LogFileW Vision = new NUtils.LogFileW(GDefine.DataPath + "\\Vision");
        public static NUtils.LogFileW Param = new NUtils.LogFileW(GDefine.DataPath + "\\Parameter");
        public static NUtils.LogFileW OsramSCC = new NUtils.LogFileW(GDefine.DataPath + "\\OsramSCC");
        public static NUtils.LogFileW LmdsCT = new NUtils.LogFileW(GDefine.DataPath + "\\LmdsCT");
        public static NUtils.LogFileW WeightCal = new NUtils.LogFileW(GDefine.DataPath + "\\WeightCal");
        public static NUtils.LogFileW WeightMeas = new NUtils.LogFileW(GDefine.DataPath + "\\WeightMeas");
        public static NUtils.LogFileW Board = new NUtils.LogFileW(GDefine.DataPath + "\\Board");
        public static NUtils.LogFileW TD_Log = new NUtils.LogFileW(GDefine.DataPath + "\\TD_Log");
        public static NUtils.LogFileW LotEntry = new NUtils.LogFileW(GDefine.DataPath + "\\LotEntry");
        public static NUtils.LogFileW ExtVision = new NUtils.LogFileW(GDefine.DataPath + "\\ExtVision");
        public static NUtils.LogFileW Temp = new NUtils.LogFileW(GDefine.DataPath + "\\Temp");
        public static NUtils.LogFileW LmdsWebService = new NUtils.LogFileW(GDefine.DataPath + "\\LmdsWebService");
        public static NUtils.LogFileW Vermes = new NUtils.LogFileW(GDefine.DataPath + "\\Vermes");

        public static void OnAction(string Action, string ParamName, bool Old, bool New)
        {
            Param.WriteByMonthDay(Action + (char)9 + ParamName + (char)9 + Old.ToString() + (char)9 + "->" + (char)9 + New.ToString());
        }
        public static void OnAction(string Action, string ParamName, string Old, string New)
        {
            Param.WriteByMonthDay(Action + (char)9 + ParamName + (char)9 + Old + (char)9 + "->" + (char)9 + New);
        }
        public static void OnAction(string Action, string ParamName)
        {
            OnAction(Action, ParamName, "", "");
        }
        public static void OnAction(string Action, string ParamName, double Old, double New)
        {
            OnAction(Action, ParamName, Old.ToString("f3") + ",", New.ToString("f3"));
        }
        public static void OnAction(string Action, string ParamName, NSW.Net.Point2D Old, NSW.Net.Point2D New)
        {
            OnAction(Action, ParamName, Old.X.ToString("f3") + "," + Old.Y.ToString("f3"), New.X.ToString("f3") + "," + New.Y.ToString("f3"));
        }
        public static void OnAction(string Action, string ParamName, Rectangle Old, Rectangle New)
        {
            OnAction(Action, ParamName,
                Old.X.ToString() + "," + Old.Y.ToString() + "," + Old.Width.ToString() + "," + Old.Height.ToString(),
                New.X.ToString() + "," + New.Y.ToString() + "," + New.Width.ToString() + "," + New.Height.ToString());
        }

        public static void OnSet(string ParamName, NSW.Net.Point2D Old, NSW.Net.Point2D New)
        {
            OnAction("Set", ParamName, Old.X.ToString("f3") + "," + Old.Y.ToString("f3"), New.X.ToString("f3") + "," + New.Y.ToString("f3"));
        }
        public static void OnSet(string ParamName, TPos3 Old, TPos3 New)
        {
            OnAction("Set", ParamName, Old.X.ToString("f3") + "," + Old.Y.ToString("f3"), New.X.ToString("f3") + "," + New.Y.ToString("f3"));
        }
        public static void OnSet(string ParamName, double Old, double New)
        {
            OnAction("Set", ParamName, Old.ToString("f3") + ",", New.ToString("f3"));
        }
        public static void OnSet(string ParamName, bool Old, bool New)
        {
            OnAction("Set", ParamName, Old.ToString() + ",", New.ToString());
        }
        public static void OnSet(string ParamName, bool New)
        {
            OnAction("Set", ParamName, (!New).ToString() + ",", New.ToString());
        }
        public static void OnCopy(string ParamName, double Old, double New)
        {
            OnAction("Copy", ParamName, Old, New);
        }

        public static DateTime dtNextCopyToBuffer = DateTime.Now;
        public static void CopyToBuffer()
        {
            if (DateTime.Now <= dtNextCopyToBuffer) return;
 
            if (!Directory.Exists(GDefine.BufferPath))
                try { Directory.CreateDirectory(GDefine.BufferPath); } catch { };

            DateTime dtToCopy = dtNextCopyToBuffer.AddDays(-1);

            string Folder = @"C:\Program Files\NSWAutomation\Log\" + dtToCopy.ToString("yyyyMM") + @"\";

            string LogFile = Folder + dtToCopy.ToString("yyyyMMdd") + ".log";
            string NewLogFile = GDefine.BufferPath + @"\" + GDefine.EquipmentID + "_" + dtToCopy.ToString("yyyyMMdd") + ".log";

            string EventFile = Folder + @"Event_" + dtToCopy.ToString("yyyyMMdd") + ".log";
            string NewEventFile = GDefine.BufferPath + @"\" + GDefine.EquipmentID + "_Event_" + dtToCopy.ToString("yyyyMMdd") + ".log";

            if (File.Exists(LogFile))
            try
            {
                File.Copy(LogFile, NewLogFile, true);
            } catch { };

            if (File.Exists(EventFile))
                try
                {
                File.Copy(EventFile, NewEventFile, true);
            }
            catch { };

            dtNextCopyToBuffer = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
            GDefine.SaveDefault();
        }
        public static void PurgeBuffer()
        {
            if (!Directory.Exists(GDefine.BufferPath)) return;
            if (!Directory.Exists(TaskDisp.LogServerPath)) return;

            string[] list = Directory.GetFiles(GDefine.BufferPath);
            if (list.Count() == 0) return;

            foreach (string s in list)
            {
                try
                {
                    string newFile = TaskDisp.LogServerPath + Path.GetFileName(s);
                    if (File.Exists(newFile)) File.Delete(newFile);
                    File.Move(s, newFile);
                }
                catch
                {
                    break;
                };
            }
        }

        public static DirectoryInfo ProcessLogDir => Directory.CreateDirectory(GDefine.DataDir.FullName + "Process\\" + DateTime.Now.ToString("yyyyMM") + "\\");
    }

    public class UC
    {
        static NUtils.UserCtrl uc = new NUtils.UserCtrl(GDefine.DataPath + "\\Parameter");

        public static bool AdjustExec(string ParamName, ref int Val, Enum E)
        {
            return uc.AdjustExec(ParamName, ref Val, E);
        }
        public static bool AdjustExec(string ParamName, ref int Val, int Min, int Max)
        {
            return uc.AdjustExec(ParamName, ref Val, Min, Max);
        }
        public static bool AdjustExec(string ParamName, ref double Val, double Min, double Max)
        {
            bool res = uc.AdjustExec(ParamName, ref Val, Min, Max);

            if (res)
            { 
            switch (ParamName)
                {
                    
                }
            }

            return res;
        }
        enum ETF { False, True };
        public static bool AdjustExec(string ParamName, ref bool Val)
        {
            int i = Convert.ToInt32(Val);

            if (uc.AdjustExec(ParamName, ref i, ETF.False))
            {
                Val = Convert.ToBoolean(i);
                return true;
            }
            return false;
        }
        public static bool EntryExec(string ParamName, ref string Val, bool PassChar)
        {
            return uc.EntryExec(PassChar, ParamName, ref Val);
        }
    }
}
