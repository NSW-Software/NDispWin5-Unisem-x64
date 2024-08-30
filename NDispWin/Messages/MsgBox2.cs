using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Timers;
using System.Reflection;

namespace NDispWin
{
    public class TFTowerLight
    {
        //DIOModel, "Desc: 0 = ZM324, 1 = ZIO3001, 2 = ZIO3201, 9 = PCI1285");
        static int DIOModel = 2;

        internal static bool Red
        {
            set
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    TaskConv.TowerLight.TL_Red = value;
                else
                        TaskGantry.TLRed = value;
            }
            get
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    return TaskConv.TowerLight.TL_Red;
                else
                    return TaskGantry.TLRed;
            }
        }
        internal static bool Yellow
        {
            set
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    TaskConv.TowerLight.TL_Yellow = value;
                else
                    TaskGantry.TLYellow = value;
            }
            get
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    return TaskConv.TowerLight.TL_Yellow;
                else
                    return TaskGantry.TLYellow;
            }
        }
        internal static bool Green
        {
            set
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    TaskConv.TowerLight.TL_Green = value;
                else
                    TaskGantry.TLGreen = value;
            }
            get
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    return TaskConv.TowerLight.TL_Green;
                else
                    return TaskGantry.TLGreen;
            }
        }
        internal static bool Buzzer
        {
            set
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    TaskConv.TowerLight.TL_Buzzer = value;
                else
                    TaskGantry.TLBuzzer = value;
            }
            get
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    return TaskConv.TowerLight.TL_Buzzer;

                else
                    return TaskGantry.TLBuzzer;
            }
        }
    }

    internal class MsgBoxGDefine
    {
        public static string AppPath = @"C:\Program Files\NSWAutomation";
        public static string AppName = "";

        public static string MsgBoxPath = AppPath + "\\MsgBox";
        public static string LogPath = AppPath + "\\Log";

        public static string MsgImagePath = "";
        public static string MsgListFFileName = "";
        public static string AltMsgListName = "";

        public static bool enableControlKeyPress = false;
    }

    public enum EMsgBtn
    {
        smbNone = 0,
        smbOK = 0x02,
        smbRetry = 0x04,
        smbStop = 0x08,
        smbCancel = 0x10,
        smbYes = 0x20,
        smbNo = 0x40,
        smbContinue = 0x80,
        smbSkip = 0x100,
        smbOK_Retry = smbOK | smbRetry,
        smbOK_Stop = smbOK | smbStop,
        smbOK_Cancel = smbOK | smbCancel,
        smbOK_Retry_Stop = smbOK_Retry | smbStop,
        smbOK_Retry_Cancel = smbOK_Retry | smbCancel,
        smbRetry_Stop = smbRetry | smbStop,
        smbRetry_Cancel = smbRetry | smbCancel,
        smbRetry_Stop_Cancel = smbRetry_Stop | smbCancel,
        smbAll = smbOK_Retry_Stop | smbCancel,
        smbStop_Cancel = smbStop | smbCancel,
    }
    public enum EMsgRes { 
        smrNone = 0x00, 
        smrAlmClr = 0x01, 
        smrOK = 0x02, 
        smrRetry = 0x04, 
        smrStop = 0x08, 
        smrCancel = 0x10, 
        smrYes = 0x20, 
        smrNo = 0x40, 
        smrContinue =0x80, 
        smrSkip = 0x100 }
    public enum EMsgIcon { smiInfo, smiWarning, smiQuestion, smiError }

    public class MsgInfo
    {
        public static bool Init(string AppName)
        {
            MsgBoxGDefine.AppName = AppName;

            if (AppName.Length == 0) return false;

            if (!Directory.Exists(MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName))
                try
                {
                    Directory.CreateDirectory(MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName);
                }
                catch { };

            if (!Directory.Exists(MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName + "\\Image"))
                try
                {
                    Directory.CreateDirectory(MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName + "\\Image");
                }
                catch
                { };


            MsgBoxGDefine.MsgImagePath = MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName + "\\Image";
            MsgBoxGDefine.MsgListFFileName = MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName + "\\MsgBoxList.txt";

            return true;
        }
        public static string AltMsg
        {
            set
            {
                string FileName = Path.GetFileNameWithoutExtension(value);

                if (FileName.Length == 0) return;

                string FullFName = MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName + "\\" + FileName + ".txt";

                NUtils.IniFile Inifile = new NUtils.IniFile(FullFName);
                Inifile.WriteString("AltMsgList", "Name", FileName);

                MsgBoxGDefine.AltMsgListName = FileName;

                Load_Alt();
            }
            get
            {
                return Path.GetFileNameWithoutExtension(MsgBoxGDefine.AltMsgListName);
            }
        }

        private static Stopwatch TickCountWatch = new Stopwatch();
        internal static int GetTickCount()
        {
            if (!TickCountWatch.IsRunning)
            {
                TickCountWatch.Start();
            }

            int D = (int)TickCountWatch.ElapsedMilliseconds;
            return D;
        }

        public class TMsgInfo
        {
            public string Desc;
            public string Desc_Alt;
            public string CAct;
            public string CAct_Alt;

            public TMsgInfo()
            {
                Desc = "";
                CAct = "";
                Desc_Alt = "";
                CAct_Alt = "";
            }
            public TMsgInfo(string _Desc, string _CAct)
            {
                Desc = _Desc;
                CAct = _CAct;
                Desc_Alt = "";
                CAct_Alt = "";
            }
            public void Add(string _Desc, string _CAct)
            {
                Desc = _Desc;
                CAct = _CAct;
            }
            public TMsgInfo GetInfo()
            {
                return this;
            }
        }
        public class TMsgInfoList
        {
            public const int MAX_COUNT = 10000;
            public TMsgInfo[] MsgInfo = new TMsgInfo[MAX_COUNT];
            public TMsgInfoList()
            {
                for (int i = 0; i < MAX_COUNT; i++)
                    MsgInfo[i] = new TMsgInfo();
            }
            public void Add(int ErrCode, string Desc, string CAct)
            {
                MsgInfo[ErrCode].Add(Desc, CAct);
            }
        }

        private static TMsgInfoList _MsgInfoList = new TMsgInfoList();

        /// <summary>
        /// Load only Alternate Language by the FileName. Default Language not loaded.
        /// </summary>
        /// <param name="FileName">Full FileName</param>
        internal static void Load_Alt()
        {
            string FileName = MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName + "\\" + MsgBoxGDefine.AltMsgListName + ".txt";

            if (File.Exists(FileName))
            {
                //NSW.Net.IniFile Inifile = new NSW.Net.IniFile();
                //Inifile.Create(FileName);
                NUtils.IniFile Inifile = new NUtils.IniFile(FileName);
                for (int i = 0; i < TMsgInfoList.MAX_COUNT; i++)
                {
                    _MsgInfoList.MsgInfo[i].Desc_Alt = Inifile.ReadString(i.ToString("0000"), "Desc", "");
                    _MsgInfoList.MsgInfo[i].CAct_Alt = Inifile.ReadString(i.ToString("0000"), "CAct", "");
                }
            }
        }

        /// <summary>
        /// Save Language file to assinged names
        /// </summary>
        public static bool Save()
        {
            string FileName = MsgBoxGDefine.MsgListFFileName;

            if (System.Diagnostics.Debugger.IsAttached) return true;

                if (FileName.Length == 0) return false;

            //NSW.Net.IniFile Inifile = new NSW.Net.IniFile();
            //Inifile.Create(FileName);
            //if (File.Exists(FileName))
            {
                NUtils.IniFile Inifile = new NUtils.IniFile(FileName);
                MsgBoxGDefine.AltMsgListName = Inifile.ReadString("AltMsgList", "Name", "");
                for (int i = 0; i < TMsgInfoList.MAX_COUNT; i++)
                {
                    if (_MsgInfoList.MsgInfo[i].Desc.Length == 0)
                    {
                        _MsgInfoList.MsgInfo[i].Desc = Inifile.ReadString(i.ToString("0000"), "Desc", "");
                        _MsgInfoList.MsgInfo[i].CAct = Inifile.ReadString(i.ToString("0000"), "CAct", "");
                    }
                }

                File.Delete(FileName);
            }


            string FileNameAlt = MsgBoxGDefine.AppPath + "\\MsgBox\\" + MsgBoxGDefine.AppName + "\\" + MsgBoxGDefine.AltMsgListName + ".txt";

            if (MsgBoxGDefine.AltMsgListName.Length > 0)
            {
                //Inifile2.Create(FileNameAlt);
                NUtils.IniFile Inifile2 = new NUtils.IniFile(FileNameAlt);
                if (File.Exists(FileNameAlt))
                {
                    for (int i = 0; i < TMsgInfoList.MAX_COUNT; i++)
                    {
                        _MsgInfoList.MsgInfo[i].Desc_Alt = Inifile2.ReadString(i.ToString("0000"), "Desc", "");
                        _MsgInfoList.MsgInfo[i].CAct_Alt = Inifile2.ReadString(i.ToString("0000"), "CAct", "");
                    }

                    File.Delete(FileNameAlt);
                }
            }

            for (int i = 0; i < TMsgInfoList.MAX_COUNT; i++)
            {
                if (_MsgInfoList.MsgInfo[i].Desc.Length > 0 || _MsgInfoList.MsgInfo[i].Desc_Alt.Length > 0)
                {
                    //Inifile.Create(FileName);
                    NUtils.IniFile Inifile = new NUtils.IniFile(FileName);
                    Inifile.WriteString("AltMsgList", "Name", MsgBoxGDefine.AltMsgListName);
                    Inifile.WriteString(i.ToString("0000"), "Desc", _MsgInfoList.MsgInfo[i].Desc);
                    Inifile.WriteString(i.ToString("0000"), "CAct", _MsgInfoList.MsgInfo[i].CAct);

                    if (MsgBoxGDefine.AltMsgListName.Length > 0)
                    {
                        //Inifile2.Create(FileNameAlt);
                        NUtils.IniFile Inifile2 = new NUtils.IniFile(FileNameAlt);
                        Inifile2.WriteString(i.ToString("0000"), "Desc", _MsgInfoList.MsgInfo[i].Desc_Alt);
                        Inifile2.WriteString(i.ToString("0000"), "CAct", _MsgInfoList.MsgInfo[i].CAct_Alt);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Register message by TMsgInfo
        /// </summary>
        /// <param name="ErrCode"></param>
        /// <param name="MsgInfo"></param>
        public static void Register(int ErrCode, TMsgInfo MsgInfo)
        {
            _MsgInfoList.MsgInfo[ErrCode].Add(MsgInfo.Desc, MsgInfo.CAct);
        }

        /// <summary>
        /// Register message by Msg Info
        /// </summary>
        /// <param name="ErrCode"></param>
        /// <param name="MsgInfo"></param>
        public static void Register(int ErrCode, string Desc, string CAct)
        {
            _MsgInfoList.MsgInfo[ErrCode].Add(Desc, CAct);
        }

        /// <summary>
        /// Register message by MsgInfo
        /// </summary>
        /// <param name="ErrCode"></param>
        /// <param name="MsgInfo"></param>
        public static void Register(TMsgInfoList MsgInfoList)
        {
            for (int i = 0; i < TMsgInfoList.MAX_COUNT; i++)
            {
                if (MsgInfoList.MsgInfo[i].Desc.Length > 0)
                {
                    _MsgInfoList.MsgInfo[i].Add(MsgInfoList.MsgInfo[i].Desc, MsgInfoList.MsgInfo[i].CAct);
                }
            }
        }

        /// <summary>
        /// Get MsgInfo by ErrCode
        /// </summary>
        /// <param name="ErrCode"></param>
        /// <param name="MsgInfo"></param>
        public static void GetInfo(int ErrCode, ref TMsgInfo MsgInfo)
        {
            MsgInfo = _MsgInfoList.MsgInfo[ErrCode].GetInfo();

            if (MsgInfo.Desc.Length == 0) MsgInfo.Desc = ((EErrCode)ErrCode).ToString();
        }

        public static string Desc(int ErrCode)
        {
            TMsgInfo msgInfo = _MsgInfoList.MsgInfo[ErrCode].GetInfo();
            return msgInfo.Desc;
        }

        public static int MsgInQue = 0;
        public static int AssistCount = 0;
        public static bool Showing
        {
            get
            {
                return (MsgInQue > 0);
            }
        }
    }
    public class Msg
    {
        public EMsgRes Show(int ErrCode, string ExMsg, EMcState McState, EMsgBtn MsgBtn, bool Assist)
        {
            Event.ERROR.Set($"{ErrCode:d4}", MsgInfo.Desc(ErrCode) + ","+ ExMsg);
            frm_MsgBox frm = new frm_MsgBox();
            frm.SetErrCode(ErrCode, ExMsg, McState, MsgBtn, Assist);
            frm.ShowDialog();
            return frm.MsgRes;
        }
        public EMsgRes Show(int ErrCode, EMcState McState, EMsgBtn MsgBtn, bool Assist)
        {
            Event.ERROR.Set($"{ErrCode:d4}", MsgInfo.Desc(ErrCode));
            frm_MsgBox frm = new frm_MsgBox();
            frm.SetErrCode(ErrCode, "", McState, MsgBtn, Assist);
            frm.ShowDialog();
            return frm.MsgRes;
        }
        public EMsgRes Show(int ErrCode, string ExMsg, bool Assist)
        {
            Event.ERROR.Set($"{ErrCode:d4}", MsgInfo.Desc(ErrCode) + "," + ExMsg);
            frm_MsgBox frm = new frm_MsgBox();
            frm.SetErrCode(ErrCode, ExMsg, EMcState.Error, EMsgBtn.smbOK, Assist);
            frm.ShowDialog();
            return frm.MsgRes;
        }
        public EMsgRes Show(int ErrCode, string ExMsg)
        {
            Event.ERROR.Set($"{ErrCode:d4}", MsgInfo.Desc(ErrCode) + "," + ExMsg);
            frm_MsgBox frm = new frm_MsgBox();
            frm.SetErrCode(ErrCode, ExMsg, EMcState.Error, EMsgBtn.smbOK, false);
            frm.ShowDialog();
            return frm.MsgRes;
        }
        public EMsgRes Show(int ErrCode)//Error, OK
        {
            Event.ERROR.Set($"{ErrCode:d4}", MsgInfo.Desc(ErrCode));
            frm_MsgBox frm = new frm_MsgBox();
            frm.SetErrCode(ErrCode, "", EMcState.Error, EMsgBtn.smbOK, false);
            frm.ShowDialog();
            return frm.MsgRes;
        }
        public EMsgRes Show(string Desc, string CAct, string ExMsg, EMcState McState, EMsgBtn MsgBtn, bool Assist)
        {
            Event.ERROR.Set("nil", Desc + "," + ExMsg);
            frm_MsgBox frm = new frm_MsgBox();
            frm.SetErrCode(Desc, CAct, ExMsg, McState, MsgBtn, Assist);
            frm.ShowDialog();
            return frm.MsgRes;
        }
        public EMsgRes Show(string Desc, EMcState McState, EMsgBtn MsgBtn, bool Assist)
        {
            return Show(Desc, "", "", McState, MsgBtn, Assist);
        }
        public EMsgRes Show(string Desc)
        {
            return Show(Desc, "", "", EMcState.Error, EMsgBtn.smbOK, false);
        }
    }

    public enum ERYG { Off, Blink, On, DontCare }
    public enum EBuzzer { Off, On, DontCare }
    internal struct ETLState
    {
        public ERYG Red;
        public ERYG Yel;
        public ERYG Grn;
        public EBuzzer Buz;
        public ETLState(ERYG Red_, ERYG Yel_, ERYG Grn_, EBuzzer Buz_)
        {
            Red = Red_;
            Yel = Yel_;
            Grn = Grn_;
            Buz = Buz_;
        }
    }

    /// <summary>
    /// None - All Off
    /// Mute - Silent buzzer only
    /// Idle - Machine is in Idle or Ready state
    /// Run - Machine is in Run State
    /// Wait - Machine is in Run State, waiting for part
    /// Notice - System is in Notification State, notify an event
    /// Warning - System is in Warning State, danger or undesired state
    /// Error - Machine is in Error State, error state
    /// </summary>
    public enum EMcState { None, Mute, Idle, Run, Wait, Notice, Warning, Error, Define, Last }

    public class IO
    {
        internal static ETLState[] IntStates = new ETLState[] {
        new ETLState(ERYG.Off, ERYG.Off, ERYG.Off, EBuzzer.Off),//EMcState.None
        new ETLState(ERYG.DontCare, ERYG.DontCare, ERYG.DontCare, EBuzzer.Off),//EMcState.Mute
        new ETLState(ERYG.Off, ERYG.On, ERYG.Off, EBuzzer.Off),//EMcState.Idle
        new ETLState(ERYG.Off, ERYG.Off, ERYG.On, EBuzzer.Off),//EMcState.Run
        new ETLState(ERYG.Off, ERYG.Blink, ERYG.On, EBuzzer.Off),//EMcState.Wait
        new ETLState(ERYG.Off, ERYG.Blink, ERYG.Off, EBuzzer.On),//EMcState.Notice
        new ETLState(ERYG.Blink, ERYG.Off, ERYG.Off, EBuzzer.On),//EMcState.Warning
        new ETLState(ERYG.On, ERYG.Off, ERYG.Off, EBuzzer.On),//EMcState.Error
        new ETLState(ERYG.On, ERYG.On, ERYG.On, EBuzzer.On),//EMcState.Define
        new ETLState(ERYG.Off, ERYG.Off, ERYG.Off, EBuzzer.Off),//EMcState.Last
    };

        private static int BoardID = 1;
        public static int DIOModel = 2;
        public static bool pwmControl = false;

        //private static ZEC3002.Ctrl.TDOutput TL_RED = new ZEC3002.Ctrl.TDOutput("TL_RED", ZEC3002.Ctrl.TDIOModel.ZIO3201, 1, 0, 9, false, false);
        //private static ZEC3002.Ctrl.TDOutput TL_YLW = new ZEC3002.Ctrl.TDOutput("TL_YLW", ZEC3002.Ctrl.TDIOModel.ZIO3201, 1, 0, 10, false, false);
        //private static ZEC3002.Ctrl.TDOutput TL_GRN = new ZEC3002.Ctrl.TDOutput("TL_GRN", ZEC3002.Ctrl.TDIOModel.ZIO3201, 1, 0, 11, false, false);
        //private static ZEC3002.Ctrl.TDOutput TL_BZR = new ZEC3002.Ctrl.TDOutput("TL_BZR", ZEC3002.Ctrl.TDIOModel.ZIO3201, 1, 0, 12, false, false);

        //private static ZEC3002.Ctrl.TPWMOutput TL_PWM_RED = new ZEC3002.Ctrl.TPWMOutput("TL_PWM_RED", ZEC3002.Ctrl.TDIOModel.ZIO3201, 1, 0, 3, 0);
        //private static ZEC3002.Ctrl.TPWMOutput TL_PWM_YLW = new ZEC3002.Ctrl.TPWMOutput("TL_PWM_YLW", ZEC3002.Ctrl.TDIOModel.ZIO3201, 1, 0, 4, 0);
        //private static ZEC3002.Ctrl.TPWMOutput TL_PWM_GRN = new ZEC3002.Ctrl.TPWMOutput("TL_PWM_GRN", ZEC3002.Ctrl.TDIOModel.ZIO3201, 1, 0, 1, 0);
        //private static ZEC3002.Ctrl.TPWMOutput TL_PWM_BZR = new ZEC3002.Ctrl.TPWMOutput("TL_PWM_BZR", ZEC3002.Ctrl.TDIOModel.ZIO3201, 1, 0, 5, 0);

        private static void LoadData()
        {
            string S = MsgBoxGDefine.MsgBoxPath;
            if (!Directory.Exists(S)) { Directory.CreateDirectory(S); }

            string FName = S + "\\" + "MsgBox.dta";
            NUtils.IniFile Inifile = new NUtils.IniFile(FName);

            DIOModel = Inifile.ReadInteger("Board", "DIOModel", 2);

            BoardID = Inifile.ReadInteger("Board", "ID", 1);
            //TL_RED.DIOModel = (ZEC3002.Ctrl.TDIOModel)Inifile.ReadInteger("Board", "DIOModel", DIOModel);
            //TL_YLW.DIOModel = (ZEC3002.Ctrl.TDIOModel)Inifile.ReadInteger("Board", "DIOModel", DIOModel);
            //TL_GRN.DIOModel = (ZEC3002.Ctrl.TDIOModel)Inifile.ReadInteger("Board", "DIOModel", DIOModel);
            //TL_BZR.DIOModel = (ZEC3002.Ctrl.TDIOModel)Inifile.ReadInteger("Board", "DIOModel", DIOModel);
            //TL_PWM_RED.DIOModel = (ZEC3002.Ctrl.TDIOModel)Inifile.ReadInteger("Board", "DIOModel", DIOModel);
            //TL_PWM_YLW.DIOModel = (ZEC3002.Ctrl.TDIOModel)Inifile.ReadInteger("Board", "DIOModel", DIOModel);
            //TL_PWM_GRN.DIOModel = (ZEC3002.Ctrl.TDIOModel)Inifile.ReadInteger("Board", "DIOModel", DIOModel);
            //TL_PWM_BZR.DIOModel = (ZEC3002.Ctrl.TDIOModel)Inifile.ReadInteger("Board", "DIOModel", DIOModel);
            pwmControl = Inifile.ReadBool("Control", "PWMMode", false);

            //TL_RED.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_RED", 25);
            //TL_YLW.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_YLW", 26);
            //TL_GRN.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_GRN", 27);
            //TL_BZR.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_BZR", 28);

            //TL_PWM_RED.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_PWM_Red", 3);
            //TL_PWM_YLW.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_PWM_YLW", 4);
            //TL_PWM_GRN.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_PWM_GRN", 1);
            //TL_PWM_BZR.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_PWM_BZR", 5);

            //Reverse compatibility
            bool b = Inifile.ReadBool("Control", "Pwm Mode", false);
            if (b)
            {
                pwmControl = b;
                //TL_PWM_RED.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_Red", 3);
                //TL_PWM_YLW.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_YLW", 4);
                //TL_PWM_GRN.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_GRN", 1);
                //TL_PWM_BZR.Add = (byte)Inifile.ReadInteger("IOAdd", "TL_BZR", 5);
            }
            //Delete old file; remove old settings
            int i = (byte)Inifile.ReadInteger("pwmAdd", "TL_Red", 0);
            {
                if (i > 0)
                {
                    string NewFname = Path.GetDirectoryName(FName) + "\\" + Path.GetFileNameWithoutExtension(FName) + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FName);
                    File.Copy(FName, NewFname, true);
                    File.Delete(S + "\\" + "MsgBox.dta");
                }
            }

            SaveData();
        }
        private static void SaveData()
        {
            string S = MsgBoxGDefine.AppPath + "\\MsgBox";
            if (!Directory.Exists(S)) { Directory.CreateDirectory(S); }

            NUtils.IniFile Inifile = new NUtils.IniFile(S + "\\" + "MsgBox.dta");

            Inifile.WriteInteger("Board", "ID", BoardID);
            Inifile.WriteString("Board", "//DIOModel", "Desc: 0 = ZM324, 1 = ZIO3001, 2 = ZIO3201, 9 = PCI1285");
            Inifile.WriteInteger("Board", "DIOModel", DIOModel);
            Inifile.WriteBool("Control", "PWMMode", pwmControl);

            //Inifile.WriteInteger("IOAdd", "TL_RED", TL_RED.Add);
            //Inifile.WriteInteger("IOAdd", "TL_YLW", TL_YLW.Add);
            //Inifile.WriteInteger("IOAdd", "TL_GRN", TL_GRN.Add);
            //Inifile.WriteInteger("IOAdd", "TL_BZR", TL_BZR.Add);

            //Inifile.WriteInteger("IOAdd", "TL_PWM_Red", TL_PWM_RED.Add);
            //Inifile.WriteInteger("IOAdd", "TL_PWM_YLW", TL_PWM_YLW.Add);
            //Inifile.WriteInteger("IOAdd", "TL_PWM_GRN", TL_PWM_GRN.Add);
            //Inifile.WriteInteger("IOAdd", "TL_PWM_BZR", TL_PWM_BZR.Add);
        }


        const uint pwmLo = 0;
        const uint pwmHi = 1000;

        //private static bool TL_Red
        //{
        //    set
        //    {
        //        switch (DIOModel)
        //        {
        //            case 2:
        //                if (b_ZEC_Error) { return; }

        //                if (!ZEC3002.Ctrl.BoardOpened(BoardID)) return;

        //                try
        //                {
        //                    if (!pwmControl)
        //                    {
        //                        ZEC3002.Ctrl.TDOStatus status = value ? ZEC3002.Ctrl.TDOStatus.Hi : ZEC3002.Ctrl.TDOStatus.Lo;
        //                        ZEC3002.Ctrl.SetDO(ref TL_RED, status);
        //                    }
        //                    else
        //                    {
        //                        uint pwmValue = value ? pwmHi : pwmLo;
        //                        ZEC3002.Ctrl.SetPWMDutyCycle(ref TL_PWM_RED, pwmValue);
        //                    }
        //                }
        //                catch
        //                {
        //                    b_ZEC_Error = true;
        //                }
        //                break;
        //            case 9:
        //                if (P1245.DeviceOpened(TL_CC_RED.Device))
        //                    if (value)
        //                        P1245.UpdateOutputHi(ref TL_CC_RED);
        //                    else
        //                        P1245.UpdateOutputLo(ref TL_CC_RED);
        //                break;
        //        }
        //    }
        //    get
        //    {
        //        switch (DIOModel)
        //        {
        //            case 2:
        //                if (!ZEC3002.Ctrl.BoardOpened(BoardID)) return false;

        //                if (!pwmControl)
        //                    return TL_GRN.Status;
        //                else
        //                    return TL_PWM_RED.DutyCycle == pwmHi;
        //            case 9:
        //                return TL_CC_RED.Status;
        //            default:
        //                return false;
        //        }
        //    }
        //}
        //private static bool TL_Yellow
        //{
        //    set
        //    {
        //        switch (DIOModel)
        //        {
        //            case 2:
        //                if (b_ZEC_Error) { return; }

        //                if (!ZEC3002.Ctrl.BoardOpened(BoardID)) return;

        //                try
        //                {
        //                    if (!pwmControl)
        //                    {
        //                        ZEC3002.Ctrl.TDOStatus status = value ? ZEC3002.Ctrl.TDOStatus.Hi : ZEC3002.Ctrl.TDOStatus.Lo;
        //                        ZEC3002.Ctrl.SetDO(ref TL_YLW, status);
        //                    }
        //                    else
        //                    {
        //                        uint pwmValue = value ? pwmHi : pwmLo;
        //                        ZEC3002.Ctrl.SetPWMDutyCycle(ref TL_PWM_YLW, pwmValue);
        //                    }
        //                }
        //                catch
        //                {
        //                    b_ZEC_Error = true;
        //                }
        //                break;
        //            case 9:
        //                if (P1245.DeviceOpened(TL_CC_YLW.Device))
        //                    if (value)
        //                        P1245.UpdateOutputHi(ref TL_CC_YLW);
        //                    else
        //                        P1245.UpdateOutputLo(ref TL_CC_YLW);
        //                break;
        //        }
        //    }
        //    get
        //    {
        //        switch (DIOModel)
        //        {
        //            case 2:
        //                if (!ZEC3002.Ctrl.BoardOpened(BoardID)) return false;

        //                if (!pwmControl)
        //                    return TL_YLW.Status;
        //                else
        //                    return TL_PWM_YLW.DutyCycle == pwmHi;
        //            case 9:
        //                return TL_CC_YLW.Status;
        //            default:
        //                return false;
        //        }
        //    }
        //}
        //private static bool TL_Green
        //{
        //    set
        //    {
        //        switch (DIOModel)
        //        {
        //            case 2:
        //                if (b_ZEC_Error) { return; }

        //                if (!ZEC3002.Ctrl.BoardOpened(BoardID)) return;

        //                try
        //                {
        //                    if (!pwmControl)
        //                    {
        //                        ZEC3002.Ctrl.TDOStatus status = value ? ZEC3002.Ctrl.TDOStatus.Hi : ZEC3002.Ctrl.TDOStatus.Lo;
        //                        ZEC3002.Ctrl.SetDO(ref TL_GRN, status);
        //                    }
        //                    else
        //                    {
        //                        uint pwmValue = value ? pwmHi : pwmLo;
        //                        ZEC3002.Ctrl.SetPWMDutyCycle(ref TL_PWM_GRN, pwmValue);
        //                    }
        //                }
        //                catch
        //                {
        //                    b_ZEC_Error = true;
        //                }
        //                break;
        //            case 9:
        //                if (P1245.DeviceOpened(TL_CC_GRN.Device))
        //                    if (value)
        //                        P1245.UpdateOutputHi(ref TL_CC_GRN);
        //                    else
        //                        P1245.UpdateOutputLo(ref TL_CC_GRN);
        //                break;
        //        }
        //    }
        //    get
        //    {
        //        switch (DIOModel)
        //        {
        //            case 2:
        //                if (!ZEC3002.Ctrl.BoardOpened(BoardID)) return false;

        //                if (!pwmControl)
        //                    return TL_GRN.Status;
        //                else
        //                    return TL_PWM_GRN.DutyCycle == pwmHi;
        //            case 9:
        //                return TL_CC_GRN.Status;
        //            default: return false;
        //        }
        //    }
        //}
        //private static bool TL_Buzzer
        //{
        //    set
        //    {
        //        switch (DIOModel)
        //        {
        //            case 2:
        //                if (b_ZEC_Error) { return; }

        //                if (!ZEC3002.Ctrl.BoardOpened(BoardID)) return;

        //                try
        //                {
        //                    if (!pwmControl)
        //                    {
        //                        ZEC3002.Ctrl.TDOStatus status = value ? ZEC3002.Ctrl.TDOStatus.Hi : ZEC3002.Ctrl.TDOStatus.Lo;
        //                        ZEC3002.Ctrl.SetDO(ref TL_BZR, status);
        //                    }
        //                    else
        //                    {
        //                        uint pwmValue = value ? pwmHi : pwmLo;
        //                        ZEC3002.Ctrl.SetPWMDutyCycle(ref TL_PWM_BZR, pwmValue);
        //                    }
        //                }
        //                catch
        //                {
        //                    b_ZEC_Error = true;
        //                }
        //                break;
        //            case 9:
        //                if (P1245.DeviceOpened(TL_CC_BZR.Device))
        //                    if (value)
        //                        P1245.UpdateOutputHi(ref TL_CC_BZR);
        //                    else
        //                        P1245.UpdateOutputLo(ref TL_CC_BZR);
        //                break;
        //        }
        //    }
        //    get
        //    {
        //        switch (DIOModel)
        //        {
        //            case 2:
        //                if (!ZEC3002.Ctrl.BoardOpened(BoardID)) return false;

        //                if (!pwmControl)
        //                    return TL_BZR.Status;
        //                else
        //                    return TL_PWM_BZR.DutyCycle == pwmHi;
        //            case 9:
        //                return TL_CC_BZR.Status;
        //            default: return false;
        //        }
        //    }
        //}

        static System.Windows.Forms.Timer timer500 = new System.Windows.Forms.Timer();
        internal static ETLState IntState = new ETLState();
        public static void SetState(EMcState State)
        {
            NUtils.RegistryWR Reg = new NUtils.RegistryWR("SOFTWARE");
            Reg.WriteKey("NSWAUTOMATION_STATE", "DATETIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Reg.WriteKey("NSWAUTOMATION_STATE", "STATE", State.ToString());

            //update last status if not same status
            if (!(State == EMcState.Last || State == EMcState.Mute || State == EMcState.Define))
            {
                if (IO.IntStates[(int)EMcState.Last].Red != IO.IntState.Red ||
                    IO.IntStates[(int)EMcState.Last].Yel != IO.IntState.Yel ||
                    IO.IntStates[(int)EMcState.Last].Grn != IO.IntState.Grn ||
                    IO.IntStates[(int)EMcState.Last].Buz != IO.IntState.Buz)
                    IO.IntStates[(int)EMcState.Last] = IO.IntState;
            }

            if (IntStates[(int)State].Red != ERYG.DontCare) IntState.Red = IntStates[(int)State].Red;
            if (IntStates[(int)State].Yel != ERYG.DontCare) IntState.Yel = IntStates[(int)State].Yel;
            if (IntStates[(int)State].Grn != ERYG.DontCare) IntState.Grn = IntStates[(int)State].Grn;
            if (IntStates[(int)State].Buz != EBuzzer.DontCare) IntState.Buz = IntStates[(int)State].Buz;

            if (DispProg.ProgramMode = State == EMcState.Last)
            {
                IntState.Red = ERYG.Off;
                IntState.Yel = ERYG.On;
                IntState.Grn = ERYG.Off;
                IntState.Buz = EBuzzer.Off;
            }

            if (!timer500.Enabled)
            {
                timer500.Interval = 500;
                timer500.Enabled = true;
                timer500.Tick += new EventHandler(timer500_Tick);
            }

            try
            {
                switch (IntState.Grn)
                {
                    case ERYG.On:
                        TFTowerLight.Green = true;
                        break;
                    case ERYG.Off:
                        TFTowerLight.Green = false;
                        break;
                }
                switch (IntState.Yel)
                {
                    case ERYG.On:
                        TFTowerLight.Yellow = true;
                        break;
                    case ERYG.Off:
                        TFTowerLight.Yellow = false;
                        break;
                }
                switch (IntState.Red)
                {
                    case ERYG.On:
                        TFTowerLight.Red = true;
                        break;
                    case ERYG.Off:
                        TFTowerLight.Red = false;
                        break;
                }
                switch (IntState.Buz)
                {
                    case EBuzzer.On:
                        TFTowerLight.Buzzer = true;
                        break;
                    case EBuzzer.Off:
                        TFTowerLight.Buzzer = false;
                        break;
                }
            }
            catch
            {
            }
        }
        public static void SetState(ERYG Red, ERYG Yel, ERYG Grn, EBuzzer Buz)
        {
            IntStates[(int)EMcState.Define].Red = Red;
            IntStates[(int)EMcState.Define].Yel = Yel;
            IntStates[(int)EMcState.Define].Grn = Grn;
            IntStates[(int)EMcState.Define].Buz = Buz;

            SetState(EMcState.Define);
        }
        static bool b_Toggle = false;
        static void timer500_Tick(object sender, EventArgs e)
        {
            try
            {
                b_Toggle = !b_Toggle;

                if (IntState.Grn == ERYG.Blink) TFTowerLight.Green = b_Toggle ? true : false;
                if (IntState.Yel == ERYG.Blink) TFTowerLight.Yellow = b_Toggle ? true : false;
                if (IntState.Red == ERYG.Blink) TFTowerLight.Red = b_Toggle ? true : false;
            }
            catch
            {
            }
        }
    }
}
