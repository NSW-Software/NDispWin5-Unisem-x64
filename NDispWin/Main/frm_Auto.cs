using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace NDispWin
{
    public partial class frm_Auto : Form
    {
        public frm_Auto()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;

            string FileName = "";
            string[] Ext = new string[3] { "bmp", "jpg", "png" };
            foreach (string S in Ext)
            {
                FileName = GDefine.AppPath + "\\Logo." + S;
                if (File.Exists(FileName))
                {
                    pbox_Logo.Image = Image.FromFile(FileName);
                    break;
                }
            }

            tmr_Perf.Enabled = true;

            StartUp();
            UpdateTabs();

            AppLanguage.Func2.WriteLangFile(this);

            tsslblDoorLock.Visible = GDefineN.EnableDoorLock;

            lblRunInfoMaintDispCount.Visible = Maint.Disp.CountLimit[0] > 0;
            btnRunInfoDispCountReset.Visible = Maint.Disp.CountLimit[0] > 0;
            

            lblRunInfoMaterialTimer.Visible = TaskDisp.Material_EnableTimer;
            lblRunInfoMaterialExpiry.Visible = TaskDisp.Material_EnableTimer;

            lblRunInfoMaterialDispCount.Visible = Material.EnableUnitCounter;
            btnMaterialDispCountReset.Visible = Material.EnableUnitCounter;
        }

        private void StartUp()
        {
            DoubleBuffered = true;
            KeyPreview = true;
            lbl_AppVersion.Text = "";
            this.Text = Application.ProductName + " v" + Application.ProductVersion + " - Auto";


            lbl_RunTime.Text = GDefineN.UpdateRunTime(true);
        }

        public NDispWin.frm_DispCore_Map frm_Map = new NDispWin.frm_DispCore_Map();
        public NDispWin.frm_DispCore_DispTools frm_DispTool = new NDispWin.frm_DispCore_DispTools();

        public NDispWin.frm_DispCore_Map InfoPanel_Map = new NDispWin.frm_DispCore_Map();

        NDispWin.frm_MHS2ConvCtrl frmConvCtrl = new NDispWin.frm_MHS2ConvCtrl();
        NDispWin.frm_MHS2ElevCtrl frmElevCtrl = new NDispWin.frm_MHS2ElevCtrl();

        private void EnableControl(bool Enable)
        {
            pnl_Right.Enable(Enable);
            btn_Stop.Enable(true);

            bool CEnabled = GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR;
            btn_InitConveyor.Enabled = Enable && CEnabled;

            frmConvCtrl.Enable = Enable;

            btnNewDispense.Enabled = Enable;
            btnUnload.Enabled = Enable;

            #region External UI
            frm_DispTool.SetEnable(Enable);
            #endregion
        }

        private void UpdateTabs()
        {
            frm_Map.TopLevel = false;
            frm_Map.Parent = tpage_Map;
            frm_Map.FormBorderStyle = FormBorderStyle.None;
            frm_Map.Dock = DockStyle.Fill;
            frm_Map.Visible = true;
            frm_Map.BringToFront();

            int i_Top = 40;

            InfoPanel_Map.TopLevel = false;
            InfoPanel_Map.Parent = tpage_RunInfo;
            InfoPanel_Map.ViewOnly = true;
            InfoPanel_Map.FormBorderStyle = FormBorderStyle.None;
            InfoPanel_Map.Visible = true;
            InfoPanel_Map.Top = i_Top;
            InfoPanel_Map.Left = 0;
            InfoPanel_Map.Width = 5 * 120;
            InfoPanel_Map.Height = 240;
            InfoPanel_Map.BringToFront();
          
            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                pnl_Table.Visible = false;
                pnl_LRLineSt.Visible = false;
                pnl_ConvSt.Visible = false;

                frmConvCtrl.TopLevel = false;
                frmConvCtrl.Parent = tpage_Manual;
                frmConvCtrl.FormBorderStyle = FormBorderStyle.None;
                frmConvCtrl.Dock = DockStyle.Top;

                frmElevCtrl.TopLevel = false;
                frmElevCtrl.Parent = tpage_Manual;
                frmElevCtrl.FormBorderStyle = FormBorderStyle.None;
                frmElevCtrl.Dock = DockStyle.Fill;

                frmConvCtrl.SendToBack();
                pnl_SysStatus.SendToBack();
                frmConvCtrl.Visible = true;
                frmElevCtrl.Visible = true;
            }
            else
            {
                pnl_Table.Visible = true;
                pnl_LRLineSt.Visible = false;
            }

            frm_DispTool.TopLevel = false;
            frm_DispTool.Parent = tpage_DispTools;
            frm_DispTool.FormBorderStyle = FormBorderStyle.None;
            frm_DispTool.Dock = DockStyle.Fill;
            frm_DispTool.Visible = true;

            if (!GDefineN.AutoPageShowImage)
                tabControl.TabPages.Remove(tpageImage);
            else
            {
                imgBoxEmgu.Dock = DockStyle.Fill;
                TaskVision.imgBoxEmgu = imgBoxEmgu;
                imgBoxEmgu.Image = TaskVision.Image;
            }
        }

        private void lbl_SysAutoRun_DoubleClick(object sender, EventArgs e)
        {
            if (NUtils.UserAcc.Active.GroupID == (int)ELevel.NSW)
                if (GDefineN.SystemSt == GDefineN.ESystemSt.Ready)
                    GDefineN.SystemSt = (GDefineN.ESystemSt)0;
                else
                    GDefineN.SystemSt++;
        }

        private void frm_Auto_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);

            AppLanguage.Func2.UpdateText(this);

            tmr_DateTime_100.Enabled = true;
            tmr_TR_Buttons.Enabled = true;
            tmr_1s.Enabled = true;

            if (GDefineN.AutoPageShowImage)
            {
                tpageImage.HorizontalScroll.Visible = false;
                tpageImage.VerticalScroll.Visible = false;
                imgBoxEmgu.HorizontalScrollBar.Visible = false;
                imgBoxEmgu.VerticalScrollBar.Visible = false;

                double width = 1440;
                double height = 1080;
                if (TaskVision.genTLCamera[0].IsConnected)
                {
                    width = TaskVision.genTLCamera[0].ImageWidth;
                    height = TaskVision.genTLCamera[0].ImageHeight;
                }
                double XScale = (double)tpageImage.Width / width;
                double YScale = (double)tpageImage.Height / height;
                imgBoxEmgu.SetZoomScale(Math.Min(XScale, YScale), new Point(imgBoxEmgu.Width / 2, imgBoxEmgu.Height / 2));
            }

            rtbOptions.Text = $"Settings\r" +
                (DispProg.Options_CheckBoardInputYield > 0 ? $"Check Low Input Yield {DispProg.Options_CheckBoardInputYield * 100:f2}%\r" : "") +
                (DispProg.Options_CheckBoardYield > 0 ? $"Check Low Output Yield {DispProg.Options_CheckBoardYield*100:f2}%\r":"") +
                (DispProg.BiasKernelFile.Length > 0 ? $"BiasKernelFile: {DispProg.BiasKernelFile}\r" : "");
        }
        private void frm_Auto_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr_DateTime_100.Enabled = false;
            tmr_TR_Buttons.Enabled = false;
            tmr_1s.Enabled = false;
        }
        private void frm_Auto_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frm_Map != null)
            {
                frm_Map.Close();
                frm_Map.Dispose();
            }
            if (InfoPanel_Map != null)
            {
                InfoPanel_Map.Close();
                InfoPanel_Map.Dispose();
            }

            GC.Collect();
        }

        private void frm_Auto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                case Keys.Enter:
                    e.Handled = true; break;
            }
        }
        private void frm_Auto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void frm_Auto_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void UpdateDisplay()
        {
            #region Left Panel
            btn_ContinuePreviousMap.BackColor = Define_Run.ResumeMap ? Color.Orange : btn_ContinuePreviousMap.BackColor = SystemColors.Control;
            btn_LotInfo.Visible = NDispWin.GDefine.EnableLotEntry;
            btn_LotInfo.BackColor = LotInfo2.LotActive ? Color.Lime : this.BackColor;
            #endregion

            lbl_Recipe.Text = GDefine.ProgRecipeName;

            lbl_UpTime.Text = GDefineN.UpdateUpTime();
            lbl_Assist.Text = GDefineN.UpdateAssist();
            lbl_MTBA.Text = GDefineN.UpdateMTBA();

            double d_TactTime = (double)DispProg.LastTactTime / 1000;
            lbl_TactTime.Text = d_TactTime.ToString("f3") + " s";
            lbl_LastUPH.Text = DispProg.LastUPH.ToString();

            #region Bottom Panel
            int t_ByPass = TaskElev.Left.BypassDoorCheckTimer;
            tsslbl_LULDoor.Text = t_ByPass > 0 ? "LUL Door ByPass " + t_ByPass.ToString() + " s" : "LUL Door Arm";
            tsslbl_LULDoor.BackColor = t_ByPass > 0 ? Color.Orange : this.BackColor;

            //tsslblDoorLock.BackColor = ConvIO.DoorLock.Status ? Color.Red : this.BackColor;
            tsslblDoorLock.BackColor = DefineSafety.DoorLockStatus ? Color.Red : this.BackColor;
            #endregion

            #region Manual Tab
            lbl_GantrySt.Text = GDefine.Status.ToString();
            lbl_GantrySt.BackColor = Define_Gantry.StatusColor(GDefine.Status);

            if (pnl_Table.Visible)
            {
                #region
                lbl_TableSt.Text = GDefine.Table.StationStatus.ToString();

                switch (GDefine.Table.StationStatus)
                {
                    case GDefine.Table.TStStatus.stNone:
                    case GDefine.Table.TStStatus.stLoaded:
                        lbl_TableSt.BackColor = Color.Fuchsia;
                        break;
                    case GDefine.Table.TStStatus.stInProcess:
                        lbl_TableSt.BackColor = Color.Yellow;
                        break;
                    case GDefine.Table.TStStatus.stCompleted:
                        lbl_TableSt.BackColor = Color.Lime;
                        break;
                    default:
                        lbl_TableSt.BackColor = SystemColors.ButtonFace;
                        break;
                        #endregion
                }
                #endregion}
            }
        }
        private void UpdateStatus()
        {
            if (GDefineN.SystemSt == GDefineN.ESystemSt.ErrorInit)
            {
                lbl_SysAutoRun.BackColor = Color.Red;
                lbl_SysAutoRun.Text = "System " + GDefineN.SystemSt.ToString();
                return;
            }

            if (GDefine.Status == EStatus.ErrorInit)
            {
                lbl_SysAutoRun.BackColor = Color.Red;
                lbl_SysAutoRun.Text = "Gantry " + GDefine.Status.ToString();
                return;
            }

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                if (NDispWin.TaskConv.Status == NDispWin.TaskConv.EConvStatus.ErrorInit)
                {
                    lbl_SysAutoRun.BackColor = Color.Red;
                    lbl_SysAutoRun.Text = "Conv " + NDispWin.TaskConv.Status.ToString();
                    return;
                }
            }

            lbl_SysAutoRun.BackColor = Color.Yellow;
            lbl_SysAutoRun.Text = "Ready";
        }
        private void UpdateWaitMagStatus()
        {
            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                if (NDispWin.TaskConv.LeftMode == NDispWin.TaskConv.ELeftMode.ElevatorZ)
                {
                    if (NDispWin.TaskElev.Left.WaitMagChange && !Define_Run.b_LeftMagEmptyAlarming)
                    {
                        IO.SetState(ERYG.DontCare, ERYG.Blink, ERYG.DontCare, EBuzzer.On);
                        Define_Run.b_LeftMagEmptyAlarming = true;
                    }
                    if (!NDispWin.TaskElev.Left.WaitMagChange && Define_Run.b_LeftMagEmptyAlarming)
                    {
                        IO.SetState(EMcState.Idle);
                        Define_Run.b_LeftMagEmptyAlarming = false;
                    }
                }
                if (NDispWin.TaskConv.RightMode == NDispWin.TaskConv.ERightMode.ElevatorZ)
                {
                    if (NDispWin.TaskElev.Right.WaitMagChange && !Define_Run.b_RightMagEmptyAlarming)
                    {
                        IO.SetState(ERYG.DontCare, ERYG.Blink, ERYG.DontCare, EBuzzer.On);
                        Define_Run.b_RightMagEmptyAlarming = true;
                    }
                    if (!NDispWin.TaskElev.Right.WaitMagChange && Define_Run.b_RightMagEmptyAlarming)
                    {
                        IO.SetState(EMcState.Idle);
                        Define_Run.b_RightMagEmptyAlarming = false;
                    }
                }
            }
        }

        private void tmr_DateTime_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_DateTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");
            lbl_AccessUser.Text = "Login[" + NUtils.UserAcc.Active.GroupName + "/" + NUtils.UserAcc.Active.UserName + "]";

            UpdateDisplay();
            UpdateStatus();
            UpdateWaitMagStatus();
        }
        private void tmr_TR_Buttons_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (Define_Run.PromptButtonFocus) return;

            if (MsgInfo.Showing) return;

            if (GDefineN.BtnStartValid())
            {
                bool bStart;
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    bStart = GDefineN.DI_BtnStart;
                else
                    bStart = TaskGantry.BtnStart();

                if (bStart)
                {
                    if (btn_Start.Enabled)
                    btn_Start_Click(sender, e);
                }
            }

            if (GDefineN.BtnStopValid())
            {
                bool bStop;
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                    bStop = GDefineN.DI_BtnStop;
                else
                    bStop = TaskGantry.BtnStop();

                if (!bStop)
                {
                    btn_Stop_Click(sender, e);
                }
            }
        }
        private void tmr_1s_Tick(object sender, EventArgs e)
        {
            int value = DispProg.Idle.Idling ? 1 : 0;
            if (value == 1)
            {
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                {
                    if (!DefineSafety.DoorCheck_Disp(false)) return;
                }

                Define_Run.TR_StopRun();
                DispProg.Idle.RunIdle();
            }

            #region Progam
            lbl_Weight.Text = $"Disp_Weight : {DispProg.Disp_Weight[0]:F4}";
            lbl_Flowrate.Text = $"Flowrate : {TaskWeight.CurrentCal[1]:F4}";
            lbl_HeadShotCount.Text = $"Disp Count : {Stats.DispCount[0]} ({Stats.BoardCount} frames)";
            int t = GDefine.GetTickCount() - Stats.StartTime;
            lbl_Elapsed.Text = $"Elaspsed Time : {((double)t / 60000):f1} M";

            int i_LifeTimer_s = (int)TaskDisp.Material_Life_EndTime.Subtract(DateTime.Now).TotalSeconds;
            lblRunInfoMaterialExpiry.Text = $"Material - Expiry : {TaskDisp.Material_Life_EndTime:yyyy/MM/dd HH:mm}";
            if (i_LifeTimer_s > 0)
            {
                int i_LifeTimer_m = i_LifeTimer_s / 60;
                int i_LifeTimer_h = i_LifeTimer_m / 60;

                lblRunInfoMaterialTimer.Text = "Material - Timer : " +
                i_LifeTimer_h.ToString() + " H " +
                (i_LifeTimer_m % 60).ToString() + " M " +
                (i_LifeTimer_s % 60).ToString() + " S";

                lblRunInfoMaterialExpiry.BackColor = this.BackColor;
            }
            else
            {
                lblRunInfoMaterialTimer.Text = "Material - Timer : 0";
                lblRunInfoMaterialExpiry.BackColor = Color.Red;
            }
            lblRunInfoMaintDispCount.Text = $"Maint - Disp Count : {Maint.Disp.Count[0]} / {Maint.Disp.CountLimit[0]}";
            lblRunInfoMaterialDispCount.Text = $"Material - Disp Count : {Material.Unit.Count[0]} / {Material.Unit.Limit[0]}";
            #endregion

            #region Pump Info
            double DispA_BaseVol_ul = DispProg.PP_HeadA_DispBaseVol;
            double DispB_BaseVol_ul = DispProg.PP_HeadB_DispBaseVol;
            double DispA_DispAdj_ul = DispProg.PP_HeadA_DispVol_Adj;
            double DispB_DispAdj_ul = DispProg.PP_HeadB_DispVol_Adj;
            double DispA_VolOfst = DispProg.rt_Head1VolumeOfst;
            double DispB_VolOfst = DispProg.rt_Head2VolumeOfst;
            double dispTotalA = (DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj + DispProg.rt_Head1VolumeOfst - DispProg.PP_HeadA_BackSuckVol);
            double dispTotalB = (DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj + DispProg.rt_Head2VolumeOfst - DispProg.PP_HeadB_BackSuckVol);
            if (DispProg.Pump_Type == TaskDisp.EPumpType.PP)
            {
                rtbPumpSettings.Text = $"Pump Settings\r\r" +
                    "\t\tHeadA\tHeadB\r" +
                    $"Base (ul)\t{DispA_BaseVol_ul:f3}\t{DispB_BaseVol_ul:f3}\r" +
                    $"Adjust (ul)\t{DispA_DispAdj_ul:f3}\t{DispB_DispAdj_ul:f3}\r" +
                    $"Offset (ul)\t{DispA_VolOfst:f3}\t{DispB_VolOfst:f3}\r" +
                    $"BSuck (ul)\t{DispProg.PP_HeadA_BackSuckVol:f3}\t{DispProg.PP_HeadB_BackSuckVol:f3}\r" +
                    $"Disp Total (ul)\t{dispTotalA:f3}\t{dispTotalA:f3}\r";
            }

            if (DispProg.Pump_Type == TaskDisp.EPumpType.SP)
            {
                TModelPara model = new TModelPara(DispProg.ModelList, 0);

                rtbPumpSettings.Text = $"Pump Settings\r\r" +
                    $"FPress   \t{DispProg.FPress[0]:f3}\r" +
                    $"PPress   \t{DispProg.FPress[1]:f3}\r\r" +
                    $"Model[0]\r" +
                    $"DispGap  \t{model.DispGap:f3}\r" +
                    $"LineSpeed\t{model.LineSpeed:f3}\r"
                    ;
            }
            #endregion

            if (TaskDisp.Material_ExpiryPreAlertTime > 0)
            {
                if (DateTime.Now > TaskDisp.Material_LifePreAlert_Time && TaskDisp.Material_LifePreAlert_Time != TaskDisp.Material_Life_EndTime)
                {
                    btn_Stop_Click(sender, e);

                    TaskDisp.Material_LifePreAlert_Time = TaskDisp.Material_Life_EndTime;
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes =
                    MsgBox.Show(ErrCode.MATERIAL_EXPIRY_PREALERT, $"Material Expire in {TaskDisp.Material_ExpiryPreAlertTime} minutes.");//, EMcState.Notice, EMsgBtn.smbOK, false);
                }
            }
        }
        private void tmr_Perf_Tick(object sender, EventArgs e)
        {
            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                #region DownTime Stopwatch
                #region MHS2
                if (
                    GDefineN.SystemSt == GDefineN.ESystemSt.Ready &&
                    (GDefine.Status == EStatus.ErrorInit || NDispWin.TaskConv.Status == NDispWin.TaskConv.EConvStatus.ErrorInit)
                    )
                {
                    lbl_DownTime.Text = GDefineN.UpdateDownTime();
                }
                else
                {
                    if (DLLDefine.TickCountDowntTime.IsRunning) DLLDefine.TickCountDowntTime.Stop();
                }
                #endregion
                #endregion

                #region Idle Time Stopwatch
                if (
                    GDefineN.SystemSt == GDefineN.ESystemSt.Ready &&
                    !DispProg.TR_IsBusy() &&
                    (NDispWin.TaskConv.Status == NDispWin.TaskConv.EConvStatus.Ready || NDispWin.TaskConv.Status == NDispWin.TaskConv.EConvStatus.Stop) &&
                    !Define_Run.TR_IsRunning
                    )
                {
                    lbl_DownTime.Text = GDefineN.UpdateDownTime();
                }
                else
                {
                    if (DLLDefine.TickCountDowntTime.IsRunning) DLLDefine.TickCountDowntTime.Stop();
                }
                #endregion
            }

            if (GDefine.ConveyorType == GDefine.EConveyorType.TABLE_S320A)
            {
                #region
                if (
                    GDefineN.SystemSt != GDefineN.ESystemSt.Ready &&
                    GDefine.Status == EStatus.ErrorInit
                    )
                {
                    lbl_DownTime.Text = GDefineN.UpdateDownTime();
                }
                else
                {
                    if (DLLDefine.TickCountDowntTime.IsRunning) DLLDefine.TickCountDowntTime.Stop();
                }
                if (GDefineN.SystemSt == GDefineN.ESystemSt.Ready && !DispProg.TR_IsBusy())
                {
                    lbl_IdleTime.Text = GDefineN.UpdateIdleTime();
                }
                else
                {
                    if (DLLDefine.TickCountIdleTime.IsRunning)
                    {
                        DLLDefine.TickCountIdleTime.Stop();
                    }
                }
                #endregion
            }

            if (Define_Run.TR_IsRunning)
            {
                lbl_RunTime.Text = GDefineN.UpdateRunTime(false);
                if (MsgInfo.Showing)
                {
                    lbl_MTTA.Text = GDefineN.UpdateMTTA();
                }
                else
                {
                    if (DLLDefine.TickCountMTTATime.IsRunning)
                    {
                        DLLDefine.TickCountMTTATime.Stop();
                    }
                }
            }
            else
            {
                if (DLLDefine.TickCountMTTATime.IsRunning)
                {
                    DLLDefine.TickCountMTTATime.Stop();
                }
            }
        }

        private void btn_SysInfoReset_Click(object sender, EventArgs e)
        {
            Msg MsgBox = new Msg();
            if (MsgBox.Show(ErrCode.RESET_PERF_INFO, "", EMcState.Notice, EMsgBtn.smbOK_Cancel, false) == EMsgRes.smrCancel) return;

            GDefineN.PerformanceReset();
        }

        #region Status Bar
        private void tsslbl_BuzzerMute_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Mute);
        }
        private void tsddbtn_Language_Click(object sender, EventArgs e)
        {
            if (AppLanguage.Func2.SelectedLang == GDefineN.Language1)
                AppLanguage.Func2.SelectedLang = GDefineN.Language2;
            else
                AppLanguage.Func2.SelectedLang = GDefineN.Language1;
            AppLanguage.Func2.UpdateText(this);

            AppLanguage.Func2.UpdateText(frm_Map);

            AppLanguage.Func2.UpdateText(frm_DispTool);

            AppLanguage.Func2.UpdateText(InfoPanel_Map);
        }

        private void tsslbl_LULDoor_Click(object sender, EventArgs e)
        {
            if (NDispWin.TaskElev.Left.BypassDoorCheckTimer > 0)
            {
                NDispWin.TaskElev.Left.BypassDoorCheckTimer = 0;
                NDispWin.TaskElev.Right.BypassDoorCheckTimer = 0;
            }
            else
            {
                NDispWin.TaskElev.Left.BypassDoorCheckTimer = 20;
                NDispWin.TaskElev.Right.BypassDoorCheckTimer = 20;
            }
        }
        private void tsslblDoorLock_Click(object sender, EventArgs e)
        {
            if (!DispProg.TR_IsBusy())
                DefineSafety.DoorLock = false;
        }
        #endregion

        #region Manual
        private void btnNewDispense_Click(object sender, EventArgs e)
        {
            if (DispProg.LastLine <= 0) return;

            Msg MsgBox = new Msg();
            EMsgRes MsgRes = MsgBox.Show(ErrCode.S320_NEW_DISPENSE, EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
            switch (MsgRes)
            {
                case EMsgRes.smrOK:
                    {
                        DispProg.TR_Cancel();
                    }
                    break;
            }
        }
        private void btnUnload_Click(object sender, EventArgs e)
        {
            switch (GDefine.Table.StationStatus)
            {
                case GDefine.Table.TStStatus.stLoaded:
                case GDefine.Table.TStStatus.stInProcess:
                    GDefine.Table.StationStatus = GDefine.Table.TStStatus.stCompleted;
                    Define_Run.RunDispTable();
                    break;
            }
        }
        #endregion

        #region Functions
        private void btn_ContinuePreviousMap_Click(object sender, EventArgs e)
        {
            Define_Run.ResumeMap = !Define_Run.ResumeMap;
        }
        private void btn_LotInfo_Click(object sender, EventArgs e)
        {
            switch (LotInfo2.Customer)
            {
                case LotInfo2.ECustomer.OsramEMos:
                    {
                        frm_LotEntryOsramEMos frm = new frm_LotEntryOsramEMos();
                        frm.ShowDialog();
                        break;
                    }
                case LotInfo2.ECustomer.Analog:
                    {
                        frmLotEntryAnalog frm = new frmLotEntryAnalog();
                        frm.ShowDialog();

                        if (LotInfo2.LotStatus == LotInfo2.ELotStatus.Activated)
                        {
                            btn_LotInfo.ForeColor = Color.Green;
                        }
                        else
                        {
                            btn_LotInfo.ForeColor = Color.Red;
                        }
                        break;
                    }
                default:
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show("Lot Entry mode not supported. Please contact NSW representative.");
                        break;
                    }
            }
        
            if (LotInfo2.LoadRecipe)
            {
                switch (LotInfo2.Customer)
                {
                    case LotInfo2.ECustomer.OsramEMos:
                        {
                            Enabled = false;

                            GDefineN.PerformanceReset();
                            Stats.Reset();

                            btn_LotInfo.Text = "Loading Recipe";
                            btn_LotInfo.ForeColor = Color.Lime;
                            LotInfo2.LoadRecipe = false;

                            string RecipeName = LotInfo2._SProgramRecipe;
                            if (RecipeName.Length == 0)
                            {
                                Event.OP_DISP_AUTO_LOAD_DEVICE_INVALID.Set();
                                Msg MsgBox = new Msg();
                                MsgBox.Show("Auto Load - Invalid Recipe.");
                            }
                            else
                            if (RecipeName.Length >= 0)
                            {
                                string Filename = GDefine.DevicePath + RecipeName + "." + GDefine.DeviceRecipeExt;

                                if (!File.Exists(Filename))
                                {
                                    Event.OP_DISP_AUTO_LOAD_DEVICE_NO_FOUND.Set("Name", Filename);
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show("Auto Load - Recipe not found.");
                                }
                                else
                                {
                                    GDefine.DeviceRecipe = RecipeName;
                                    GDefine.LoadDevice(GDefine.DeviceRecipe);
                                }
                            }

                            if (LotInfo2.MatLife > 0)
                            {
                                TaskDisp.Material_EnableTimer = LotInfo2.MatLife > 0;
                                if (LotInfo2.MatLife > 0)
                                {
                                    TaskDisp.Material_Life_EndTime = DateTime.Now.AddMinutes(LotInfo2.MatLife);
                                    TaskDisp.Material_LifePreAlert_Time = TaskDisp.Material_Life_EndTime.AddMinutes((double)-TaskDisp.Material_ExpiryPreAlertTime);
                                }
                            }

                            btn_LotInfo.Text = "Lot Info";
                            btn_LotInfo.ForeColor = Color.Blue;

                            Enabled = true;
                        }
                        break;
                }
            }

            switch (LotInfo2.LotEvent)
            {
                case LotInfo2.ELotEvent.None: break;
                case LotInfo2.ELotEvent.LotStart:
                    Stats.BoardCount = 0;
                    if (TaskDisp.TeachNeedle_PromptOnLotStart) TaskDisp.TeachNeedle_Completed = false;
                    if (TaskWeight.Cal_RequireOnLotStart) TaskWeight.Cal_Status = TaskWeight.EWeightCalStatus.Require;
                    if (TaskWeight.Meas_RequireOnLotStart) TaskWeight.Meas_Status = TaskWeight.EWeightMeasStatus.Require;
                    break;
                case LotInfo2.ELotEvent.LotRestart:
                    break;
                case LotInfo2.ELotEvent.LotEnd:
                    break;
            }
        }
        private void btn_InitConveyor_Click(object sender, EventArgs e)
        {
            Define_Run.TR_StopRun();

            tmr_TR_Buttons.Enabled = false;
            Enabled = false;

            Define_Run.InitConv(true);

            Enabled = true;
            tmr_TR_Buttons.Enabled = true;
        }
        #endregion

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                Define_Run.TR_StartRun();
                AutoRun();
            }
            else
            {
                AutoRun_ManualLoad();
            }
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                Define_Run.TR_StopRun();
            }
            else
            {
                Define_Run.StopDispTable();
            }
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void AutoRun()
        {
            EnableControl(false);

            var taskGeneral = Task.Run(() =>//Check StopRun conditions
            {
                while (Define_Run.TR_IsRunning)
                {
                    if (!DefineSafety.DoorCheck_All(false))
                    {
                        GDefine.Status = EStatus.Stop;
                        Define_Run.TR_StopRun();
                        DefineSafety.DoorCheck_All(true);
                    }

                    if (GDefineN.LowPressureValid() && !GDefineN.DI_InPressureInRange)
                    {
                        GDefine.Status = EStatus.Stop;
                        Define_Run.TR_StopRun();
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.LOW_AIR_PRESSURE);
                    }

                    if (TaskConv.Pro.Status == TaskConv.EProcessStatus.InProcess &&
                      TaskConv.Pro.UseVac &&
                      !TaskConv.Pro.SensVac)
                    {
                        GDefine.Status = EStatus.Stop;
                        Define_Run.TR_StopRun();
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.CONV_VACUUM_LOW);
                    }

                    if (TaskConv.LeftMode == TaskConv.ELeftMode.ElevatorZ)
                    {
                        if (TaskElev.Left.WaitMagChange)
                        {
                            if (TaskConv.Pre.Status == TaskConv.EProcessStatus.Empty &&
                                TaskConv.Pro.Status == TaskConv.EProcessStatus.Empty &&
                                TaskConv.Pre.Status == TaskConv.EProcessStatus.Empty)
                            {
                                GDefine.Status = EStatus.Stop;
                                Define_Run.TR_StopRun();
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.IN_MAGAZINE_EMPTY_WORK_COMPLETE);
                            }
                        }
                    }

                    try
                    {
                        if (DispProg.fPoolVermes)
                        {
                            DispProg.fPoolVermes = false;
                            if (!TaskDisp.Vermes3200[0].InRange)
                            {
                                GDefine.Status = EStatus.Stop;
                                Define_Run.TR_StopRun();
                                Msg MsgBox = new Msg();
                                MsgBox.Show((int)EErrCode.DISPCTRL_TEMPERATURE_OUT_OF_TOLERANCE);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        GDefine.Status = EStatus.Stop;
                        Define_Run.TR_StopRun();
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL_ERR, $" {ex.Message}");
                    }

                    Thread.Sleep(1000);
                }
            });

            var taskConv = Task.Run(() =>
            {
                while (Define_Run.TR_IsRunning)
                {
                    try
                    {
                        if (
                            (NDispWin.TaskConv.Status == NDispWin.TaskConv.EConvStatus.Stop) ||
                            (NDispWin.TaskConv.Status == NDispWin.TaskConv.EConvStatus.ErrorInit) ||
                            (NDispWin.TaskConv.LeftMode == NDispWin.TaskConv.ELeftMode.ElevatorZ && NDispWin.TaskElev.Left.Status == NDispWin.TaskElev.EElevStatus.ErrorInit) ||
                            (NDispWin.TaskConv.RightMode == NDispWin.TaskConv.ERightMode.ElevatorZ && NDispWin.TaskElev.Right.Status == NDispWin.TaskElev.EElevStatus.ErrorInit)
                            )
                        {
                            Define_Run.TR_StopRun();
                            return;
                        }

                        TaskConv.Run();
                        Thread.Sleep(500);
                    }
                    catch
                    {
                        Event.DEBUG_INFO.Set("TaskConv.Run", "Exception");
                        Define_Run.TR_StopRun();
                    }
                }
            });

            var taskDisp = Task.Run(() =>
            {
                while (Define_Run.TR_IsRunning)
                {
                    try
                    {
                        Define_Run.RunDispConv();
                        Thread.Sleep(100);
                    }
                    catch
                    {
                        Event.DEBUG_INFO.Set("TaskDisp.Run", "Exception");
                        Define_Run.TR_StopRun();
                    }
                }
            });

            await Task.Run(() => Task.WaitAll(taskConv, taskDisp));

            TaskConv.In.Smema_DO_McReady = false;
            TaskConv.In.Smema2_DO_BdReady = false;
            TaskConv.Out.Smema_DO_BdReady = false;
            TaskConv.Out.Smema2_DO_McReady = false;

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                if (!MsgInfo.Showing) IO.SetState(EMcState.Idle);
            }
            DefineSafety.DoorLock = false;

            EnableControl(true);
        }
        private async void AutoRun_ManualLoad()
        {
            if (!DefineSafety.DoorCheck_All(true)) return;

            Define_Run.TableIsRunning = true;

            EnableControl(false);

            IO.SetState(EMcState.Run);

            bool keepTLState = false;
            var taskGeneral = Task.Run(() =>//Check StopRun conditions
            {
                while (Define_Run.TableIsRunning)
                {
                    if (!DefineSafety.DoorCheck_All(false))
                    {
                        Define_Run.StopDispTable();
                        keepTLState = true;
                        DefineSafety.DoorCheck_All(true);
                    }
                    Thread.Sleep(1000);
                }
            });

            await Task.Run(() =>
            {
                while (true)// Define_Run.TableIsRunning)//Define_Run.TR_IsRunning)
                {
                    if (!Define_Run.RunDispTable()) return;
                    Thread.Sleep(10);
                }
            });

            if (!keepTLState) IO.SetState(EMcState.Idle);

            DefineSafety.DoorLock = false;

            EnableControl(true);
        }

        private void btnResetProgram_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Reset Disp Count, FrameCount and Runtime?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Stats.Reset();
            }
        }

        private void lbl_AppVersion_Click(object sender, EventArgs e)
        {

        }

        private void lbl_RunTime_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void btnRunInfoDispCountReset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Reset Maintenance Disp Count?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Log.OnSet("Reset Maintenance Disp Counter", Maint.Disp.Count[0], 0);
                Maint.Disp.Count[0] = 0;
                Maint.Disp.CountResetDateTime[0] = DateTime.Now;
                Log.OnSet("Reset Maintenance Disp Counter", Maint.Disp.Count[1], 0);
                Maint.Disp.Count[1] = 0;
                Maint.Disp.CountResetDateTime[1] = DateTime.Now;

                GDefine.SaveDefault();
            }
            UpdateDisplay();
        }

        private void btnMaterialExpiryReset_Click(object sender, EventArgs e)
        {
            if (Material.EnableUnitCounter)
            {
                if (MessageBox.Show("Reset Material Disp Counter?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Log.OnSet("Reset Material Disp Counter A", Material.Unit.Count[0], 0);
                    Material.Unit.Count[0] = 0;
                    Log.OnSet("Reset Material Disp Counter B", Material.Unit.Count[1], 0);
                    Material.Unit.Count[1] = 0;
                    GDefine.SaveDefault();
                }
                UpdateDisplay();
            }
        }
    }
}
