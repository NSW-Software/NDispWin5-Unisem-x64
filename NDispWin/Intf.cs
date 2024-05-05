using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace NDispWin
{
    public class Intf
    {
        public static FileVersionInfo GetVersionInfo
        {
            get { return FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + "DispCore.dll"); }
        }

        #region initialization and environment setting
        struct FileVer
        {
            public string FileName;
            public int Major;
            public int Minor;
            public int Build;
            public int Private;
            public FileVer(string FileName, int Major, int Minor, int Build, int Private)
            {
                this.FileName = FileName;
                this.Major = Major;
                this.Minor = Minor;
                this.Build = Build;
                this.Private = Private;
            }
            public string FileVersion
            {
                get { return Major.ToString() + "." + Minor.ToString() + "." + Build.ToString() + "." + Private.ToString(); }
            }
            public bool Validate(bool ShowMessage)
            {
                if (!File.Exists(FileName))
                {
                    if (ShowMessage)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(FileName + " not found.");
                    }
                    return false;
                }
                FileVersionInfo fvi_FoundVersion = FileVersionInfo.GetVersionInfo(FileName);
                string FoundVersion = fvi_FoundVersion.FileVersion;

                if (fvi_FoundVersion.FileMajorPart > this.Major)
                {
                    return true;
                }
                else
                    if (fvi_FoundVersion.FileMinorPart > this.Minor)
                {
                    return true;
                }
                else
                        if (fvi_FoundVersion.FileBuildPart > this.Build)
                {
                    return true;
                }
                else
                            if (fvi_FoundVersion.FilePrivatePart >= this.Private)
                {
                    return true;
                }
                if (ShowMessage)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(FileName + (char)13 + "Build ver " + FileVersion + "@Current ver " + FoundVersion, "", "", EMcState.Warning, EMsgBtn.smbOK, false);
                }
                return true;
            }
        }
        public static bool CheckDependencies()
        {
            bool OK = true;

            //FileVer file_AOT = new FileVer(Application.StartupPath + "\\" + "AOT.dll", 1, 0, 0, 4);
            //OK = !file_AOT.Validate(true);

            FileVer file_AdvMotAPI = new FileVer(Application.StartupPath + "\\" + "AdvMotAPI.dll", 1, 2, 1, 1);
            OK = !file_AdvMotAPI.Validate(true);

            //FileVer file_CControl = new FileVer(Application.StartupPath + "\\" + "CControl.dll", 1, 2, 1, 0);
            //OK = !file_CControl.Validate(true);

            FileVer file_NSWNet = new FileVer(Application.StartupPath + "\\" + "NSW.Net.dll", 1, 0, 1, 0);
            OK = !file_NSWNet.Validate(true);

            //FileVer file_GrabberNet = new FileVer(Application.StartupPath + "\\" + "GrabberNet.dll", 1, 0, 6, 4);
            //OK = !file_GrabberNet.Validate(true);

            FileVer file_LEDStudioNet = new FileVer(Application.StartupPath + "\\" + "LEDStudio.Net.dll", 1, 0, 1, 3);
            OK = !file_LEDStudioNet.Validate(true);

            FileVer file_ZedGraph = new FileVer(Application.StartupPath + "\\" + "ZedGraph.dll", 5, 1, 5, 28844);
            OK = !file_ZedGraph.Validate(true);

            //FileVer file_WGHSeries = new FileVer(Application.StartupPath + "\\" + "WGH_Series.dll", 1, 0, 2, 1);
            //OK = !file_WGHSeries.Validate(true);

            //FileVer file_LHS_IDLSeries = new FileVer(Application.StartupPath + "\\" + "LHS_ILD_Series.dll", 1, 0, 0, 5);
            //OK = !file_LHS_IDLSeries.Validate(true);

            FileVer file_MEDAQLib = new FileVer(Application.StartupPath + "\\" + "MEDAQLib.dll", 3, 3, 0, 21002);
            OK = !file_MEDAQLib.Validate(true);

            //FileVer file_CLaser = new FileVer(Application.StartupPath + "\\" + "CLaser.dll", 1, 0, 1, 3);
            //OK = !file_CLaser.Validate(true);

            FileVer file_Nspira_HPC_Series = new FileVer(Application.StartupPath + "\\" + "Nspira_HPC_Series.dll", 1, 0, 2, 0);
            OK = !file_Nspira_HPC_Series.Validate(true);

            FileVer file_HPC15 = new FileVer(Application.StartupPath + "\\" + "HPC15.dll", 1, 5, 3, 3);
            OK = !file_HPC15.Validate(true);

            FileVer file_AppLanguage = new FileVer(Application.StartupPath + "\\" + "AppLanguage.dll", 1, 0, 0, 4);
            OK = !file_AppLanguage.Validate(true);

            //FileVer file_FlyCap2CameraControl = new FileVer(Application.StartupPath + "\\" + "FlyCap2CameraControl.dll", 2, 7, 3, 18);
            //OK = !file_FlyCap2CameraControl.Validate(true);

            //FileVer file_FlyCapture2Managed = new FileVer(Application.StartupPath + "\\" + "FlyCapture2Managed.dll", 2, 7, 3, 18);
            //OK = !file_FlyCapture2Managed.Validate(true);

            //            FileVer file_NCamera = new FileVer(Application.StartupPath + "\\" + "NCamera.dll", 1, 0, 2, 1);
            //          OK = !file_NCamera.Validate(true);

            FileVer file_NVision = new FileVer(Application.StartupPath + "\\" + "NVision.dll", 1, 0, 2, 1);
            OK = !file_NVision.Validate(true);

            FileVer file_SocketV1 = new FileVer(Application.StartupPath + "\\" + "SocketV1.dll", 1, 0, 0, 6);
            OK = !file_SocketV1.Validate(true);

            //FileVer file_Vermes = new FileVer(Application.StartupPath + "\\" + "Vermes.dll", 1, 0, 0, 7);
            //OK = !file_Vermes.Validate(true);

            FileVer file_NUtils = new FileVer(Application.StartupPath + "\\" + "NUtils.dll", 1, 0, 3, 0);
            OK = !file_NUtils.Validate(true);

            return OK;
        }

        public static bool Initialize()
        {
            //if (!Directory.Exists(@"C:\Program Files\Point Grey Research\Spinnaker\bin\vs2015"))
            //{
            //    MessageBox.Show("Spinnaker Drivers is not installed.");
            //    Environment.Exit(0);
            //}
            CheckDependencies();

            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            //try
            //{
            //    //  do not removed, remove will call fail initialiazation of Open_eVision
            //    Euresys.Open_eVision_2_5.EImageBW8 m_Source = new Euresys.Open_eVision_2_5.EImageBW8();
            //}
            //catch { };


            AppLanguage.Func2.WriteLangFile(new frm_MsgBox());

            AppLanguage.Func2.WriteLangFile(new frmSystemConfig());

            #region DispProg
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_MeasL_H());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_WeightCal());
            AppLanguage.Func2.WriteLangFile(new frm_DispProg2());

            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_Arc());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_BdOrient());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_CreateMap());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_Comment());

            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_CreateMap());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_Delay());

            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_DoBdCapture());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_DoHeight());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_DoRef());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_Dot());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_DotAngArr());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_DotMulti());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_DoUnitMark());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_DoVision());


            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_Dwell());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_GoPos());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_InputMap());

            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_Layout());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_ManageProgram());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_MeasL_WH());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_ModelList());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_ModelListSetting());

            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_GoPos());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_PPFillRecycle());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_PPRecycleN());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_PPVolComp());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_PurgeClean());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_PurgeDot());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_ReadID());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispProg_ReadID_ManualEntry());

            AppLanguage.Func2.UpdateText(new frm_DispCore_DispProg_Setting());
            AppLanguage.Func2.UpdateText(new frm_DispCore_DispProg_Sub());
            AppLanguage.Func2.UpdateText(new frm_DispCore_DispProg_UISetting());
            AppLanguage.Func2.UpdateText(new frm_DispCore_DispProg_UseHeight());
            AppLanguage.Func2.UpdateText(new frm_DispCore_DispProg_UseRef());
            AppLanguage.Func2.UpdateText(new frm_DispCore_DispProg_VolumeMap());
            AppLanguage.Func2.UpdateText(new frm_DispCore_DispProg_VolumeOfst());
            #endregion

            #region DispSetup
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_CleanPurge());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_Custom());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_DispControl());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_HeadCal());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_HM());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_Maint());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_Options());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_PP());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_TeachNeedle());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispSetup_Weight());
            #endregion

            #region Motor_IO_Diag
            AppLanguage.Func2.WriteLangFile(new frmIODiag());
            AppLanguage.Func2.WriteLangFile(new frmMotorDiag());
            AppLanguage.Func2.WriteLangFile(new frmMotorPara());
            #endregion

            #region Weight
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_WeightAdjust());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_WeightCal());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_WeightMeasure());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_WeightSetting());
            #endregion

            AppLanguage.Func2.WriteLangFile(new frmCameraSetting());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispInfo());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispTools());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_IdlePurge());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_DispCtrl_FuncSetup());

            AppLanguage.Func2.WriteLangFile(new frm_DispTool_SpeedAdjust());
            AppLanguage.Func2.WriteLangFile(new frm_DispTool_VolumeAdjust());

            AppLanguage.Func2.WriteLangFile(new frm_DispCore_JogGantryVision());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_Lighting());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_ReticleSetup());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_HeightFailMsg());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_VisionFailMsg());
            AppLanguage.Func2.WriteLangFile(new frm_DispCore_VisionSelectBox());
            AppLanguage.Func2.WriteLangFile(new frmCameraSetting());

            AppLanguage.Func2.WriteLangFile(new frm_DispCore_Map());

            AppLanguage.Func2.WriteLangFile(new uctrl_JogGantry());


            #region TeachNeedle
            AppLanguage.Func2.WriteLangFile(new frm_TeachNeedle_LaserCrosshair());
            //AppLanguage.Func2.WriteLangFile(new frm_TeachNeedle_StepByStep());
            #endregion

            //ErrCode ErrCode = new ErrCode();

            DispProg.Init();

            //Timer.DoWorkAsyncInfinite10s_CopyLog();
            Timer.DoWorkAsyncInfinite10s_TempPool();

            return DispProg.Initialized;
        }
        public static bool Initialized
        {
            get { return DispProg.Initialized; }
        }
        public static bool SysOffline
        {
            get { return GDefine.SysOffline; }
            set { GDefine.SysOffline = value; }
        }
        #endregion

        public static bool Terminate = false;
        public static void OpenAllModules()
        {
            Terminate = false;

            GDefine.LoadDefault();

            try
            {
                TaskGantry.OpenBoard();
            }
            catch { };


            try
            {
                TaskVision.OpenCameras();
            }
            catch { };

            if (Terminate) goto _Terminate;

            try
            {
                TaskVision.OpenLighting();
            }
            catch { };

            try
            {
                TaskLaser.CloseLaser();
                TaskLaser.OpenLaser();
            }
            catch { };

            try
            {
                TaskDisp.OpenDispCtrl(0);
            }
            catch { };

            try
            {
                TaskDisp.OpenDispCtrl(1);
            }
            catch { };

            try
            {
                if (GDefine.DispHeaterType[0] == GDefine.EDispHeaterType.Vermes_HC48)
                    TaskDisp.Vermes_HC48[0].Open(GDefine.DispHeaterComport[0]);
            }
            catch { };

            try
            {
                FPressCtrl.Open();
            }
            catch { };

            try
            {
                TaskWeight.WeightOpen();
            }
            catch { };

            //try
            //{
            //    TaskDisp.IDReader_Open();
            //}
            //catch { };

            try
            {
                TempCtrl.Open();
                TempCtrl.Init();
            }
            catch { };

            try
            {
                ExtVision.Connect();
            }
            catch { };

            try
            {
                    TFTempSensor.Open();
            }
            catch { };

            return;
            _Terminate:
            CloseAllModules();
            Environment.Exit(0);
        }
        public static void CloseAllModules()
        {
            GDefine.SaveDefault();

            try
            {
                TaskGantry.CloseBoard();
            }
            catch { };

            try
            {
                TaskVision.CloseCameras();
            }
            catch { };

            try
            {
                TaskVision.CloseLighting();
            }
            catch { };

            try
            {
                TaskLaser.CloseLaser();
            }
            catch { };

            try
            {
                TaskDisp.CloseDispCtrl(0);
            }
            catch { };

            try
            {
                TaskDisp.CloseDispCtrl(1);
            }
            catch { };

            try
            {
                if (GDefine.DispHeaterType[0] == GDefine.EDispHeaterType.Vermes_HC48)
                    TaskDisp.Vermes_HC48[0].Close();
            }
            catch { };

            try
            {
                FPressCtrl.Close();
            }
            catch { };

            try
            {
                TaskWeight.WeightClose();
            }
            catch { };

            try
            {
                TempCtrl.Close();
            }
            catch { };

            try
            {
                ExtVision.Disconnect();
            }
            catch { };

            try
            {
                TFTempSensor.Close();
            }
            catch { };
        }

        public class frmJogGantry
        {
            static frm_DispCore_JogGantryVision frmJogGantryVision = new frm_DispCore_JogGantryVision();
            public static void Show()
            {
                if (frmJogGantryVision == null)
                {
                    frmJogGantryVision = new frm_DispCore_JogGantryVision();
                }
                frmJogGantryVision.ShowVision = false;
                frmJogGantryVision.Inst = "";
                frmJogGantryVision.Visible = true;
            }
            public static void Hide()
            {
                frmJogGantryVision.Visible = false;
            }
            public static bool Visible
            {
                get { return frmJogGantryVision.Visible; }
                set
                {
                    if (value)
                    {
                        frmJogGantryVision.ShowVision = false;
                        frmJogGantryVision.Inst = "";
                        frmJogGantryVision.TopMost = true;
                        frmJogGantryVision.Visible = true;
                    }
                    else
                    {
                        frmJogGantryVision.Visible = false;
                    }
                }
            }
        }

        public static class Config
        {
            public static void Load()
            {
                string cfgFileName = GDefine.ConfigPath + "\\Gantry.Config.ini";
                string backupFileName = Path.GetDirectoryName(cfgFileName) + "\\" + Path.GetFileNameWithoutExtension(cfgFileName) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(cfgFileName);
                    File.Copy(cfgFileName, backupFileName, true);

                GDefine.LoadSystemConfig();
                TaskGantry.LoadMotorPara();
                TaskWeight.LoadDefault();
            }
            public static void Save()
            {
                TaskGantry.SaveMotorPara();
            }
        }

        public static class Setup
        {
            public static void Load()
            {
                TaskDisp.LoadSetup();
                TaskVision.LoadSetup();
                TaskLaser.LoadSetup();
                TaskOption.LoadOption();
            }
            public static void Save()
            {
                TaskDisp.SaveSetup();
                TaskVision.SaveSetup();
                TaskLaser.SaveSetup();
                TaskOption.SaveOption();
            }
        }

        public static class Program
        {
            public static bool RunPermit
            {
                get
                {
                    if (TaskDisp.Preference == TaskDisp.EPreference.TD_4FCOB)
                    {
                        if (!RLMS.CheckHeartBeat())
                        {
                            Msg MsgBox = new Msg();
                            EMsgRes Resp = MsgBox.Show("Lot Program Not Running.@Stop - Stop Operation.", EMcState.Error, EMsgBtn.smbStop, true);
                            return false;
                        }
                        if (!RLMS.LotStarted())
                        {
                            Msg MsgBox = new Msg();
                            EMsgRes Resp = MsgBox.Show("Lot Not Started.@Stop - Stop Operation.", EMcState.Error, EMsgBtn.smbStop, true);
                            return false;
                        }
                    }
                    if (!TaskDisp.TeachNeedle_Bypass && !TaskDisp.TeachNeedle_Completed)
                    {
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show(ErrCode.TEACH_NEEDLE_REQUIRED, EMcState.Notice, EMsgBtn.smbOK, false);
                        switch (MsgRes)
                        {
                            default:
                                return false;
                        }
                    }
                    if (TaskWeight.Cal_RequireOnLotStart && TaskWeight.Cal_Status == TaskWeight.EWeightCalStatus.Require)
                    {
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show(ErrCode.WEIGHT_CAL_REQUIRED, EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                        switch (MsgRes)
                        {
                            case EMsgRes.smrOK:
                                {
                                    frm_DispCore_WeightCal frm = new frm_DispCore_WeightCal();
                                    frm.ShowDialog();
                                    return false;
                                }
                            default:
                                return false;
                        }
                    }
                    if (TaskWeight.Meas_RequireOnLotStart && TaskWeight.Meas_Status == TaskWeight.EWeightMeasStatus.Require)
                    {
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show(ErrCode.WEIGHT_MEAS_REQUIRED, EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                        switch (MsgRes)
                        {
                            case EMsgRes.smrOK:
                                {
                                    frm_DispCore_WeightMeasure frm = new frm_DispCore_WeightMeasure();
                                    frm.ShowDialog();
                                    return false;
                                }
                            default:
                                return false;
                        }
                    }
                    return true;
                }
            }

             public static bool BdReady
            {
                get { return DispProg.BdReady; }
            }
            public static EBoardStatus BdStatus
            {
                get { return DispProg.BdStatus; }
            }
        }

        public class CmdEventArgs : EventArgs
        {
            public string Cmd { get; internal set; }
            public int Param { get; internal set; }
            public CmdEventArgs(string Cmd, int Param)
            {
                this.Cmd = Cmd;
                this.Param = Param;
            }
        }
    }

    public static class frmLmdsWebServiceSetup
    {
        public static class SystemConfig
        {
            public static DialogResult ShowDialog()
            {
                frmSystemConfig frm = new frmSystemConfig();
                return frm.ShowDialog();
            }
        }
        public static class GantryMotorPara
        {
            public static DialogResult ShowDialog()
            {
                frmMotorPara frm = new frmMotorPara();
                return frm.ShowDialog();
            }
        }
        public static class VisionSetup
        {
            public static DialogResult ShowDialog()
            {
                frmCameraSetting frm = new frmCameraSetting();
                return frm.ShowDialog();
            }
        }
        public static class MotorDiag
        {
            public static DialogResult ShowDialog()
            {
                frmMotorDiag frm = new frmMotorDiag();
                return frm.ShowDialog();
            }
        }
        public static class IODiag
        {
            public static DialogResult ShowDialog()
            {
                frmIODiag frm = new frmIODiag();
                return frm.ShowDialog();
            }
        }
        public static class DispSetup
        {
            public static DialogResult ShowDialog()
            {
                frm_DispCore_DispSetup frm = new frm_DispCore_DispSetup();
                return frm.ShowDialog();
            }
        }
        public static class DispTools
        {
            public static DialogResult ShowDialog()
            {
                frm_DispCore_DispTools frm = new frm_DispCore_DispTools();
                //frm.AllowClose = true;
                return frm.ShowDialog();
            }
        }
        public static class DispInfo
        {
            public static DialogResult ShowDialog()
            {
                frm_DispCore_DispInfo frm = new frm_DispCore_DispInfo();
                return frm.ShowDialog();
            }
        }
        public static class DispProg
        {
            static frm_DispProg2 frm = new frm_DispProg2();
            public static DialogResult ShowDialog()
            {
                //bool b_NewUI = (File.Exists(GDefine.AppPath + "\\NewProg.txt"));

                //if (b_NewUI)
                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                {
                    frm_DispProg2 frm = new frm_DispProg2();
                    return frm.ShowDialog();
                }
                else
                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                {
                    frm_DispProg2 frm = new frm_DispProg2();
                    return frm.ShowDialog();
                }
                else
                {


                    if (frm == null) frm = new frm_DispProg2();

                    if (frm != null)
                    {
                        frm.Show();
                        frm.BringToFront();
                    }
                    return DialogResult.OK;
                }
                //else
                //{
                //    frm_DispCore_DispProg frm = new frm_DispCore_DispProg();

                //    DispCore.DispProg.frm_CamView.TopLevel = false;
                //    DispCore.DispProg.frm_CamView.Parent = frm;
                //    DispCore.DispProg.frm_CamView.TopMost = true;

                //    return frm.ShowDialog();
                //}
            }
        }
        public static DialogResult ShowJogGantry()
        {
            //frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
            //frm.ShowVision = false;
            //frm.Inst = "";
            //return frm.ShowDialog();
            return ShowJogGantry("");
        }
        public static DialogResult ShowJogGantry(string Instruction)
        {
            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
            frm.ShowVision = false;
            frm.Inst = Instruction;
            return frm.ShowDialog();
        }

        static frm_DispCore_JogGantryVision frmJogGantryVision = new frm_DispCore_JogGantryVision();
        public static class JogGantry
        {
            public static void Show()
            {
                if (frmJogGantryVision == null)
                {
                    frmJogGantryVision = new frm_DispCore_JogGantryVision();
                }
                frmJogGantryVision.ShowVision = false;
                frmJogGantryVision.Inst = "";
                frmJogGantryVision.Visible = true;
            }
            public static void Hide()
            {
                frmJogGantryVision.Visible = false;
            }
            public static bool Visible
            {
                get { return frmJogGantryVision.Visible; }
                set
                {
                    if (value)
                    {
                        frmJogGantryVision.ShowVision = false;
                        frmJogGantryVision.Inst = "";
                        frmJogGantryVision.TopMost = true;
                        frmJogGantryVision.Visible = true;
                    }
                    else
                    {
                        frmJogGantryVision.Visible = false;
                    }
                }
            }
        }
    }
}
