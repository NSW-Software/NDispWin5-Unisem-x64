using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace NDispWin
{
    public partial class frmMHS2Main : Form
    {
        public frmMHS2Main()
        {
            InitializeComponent();
            GControl.LogForm(this);

            AppLanguage.Func2.WriteLangFile(this);
        }

        frm_MHS2ConvCtrl frmConvCtrl = new frm_MHS2ConvCtrl();
        frm_MHS2ElevCtrl frmElevCtrl = new frm_MHS2ElevCtrl();

        private void frm_Main_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            ControlBox = false;

            frmConvCtrl.TopLevel = false;
            frmConvCtrl.Parent = pnl_Control;
            frmConvCtrl.FormBorderStyle = FormBorderStyle.None;
            frmConvCtrl.Visible = true;
            frmConvCtrl.Top = 0;
            frmConvCtrl.Width = pnl_Control.Width;

            frmElevCtrl.TopLevel = false;
            frmElevCtrl.Parent = pnl_Control;
            frmElevCtrl.FormBorderStyle = FormBorderStyle.None;
            frmElevCtrl.Visible = true;
            frmElevCtrl.Top = frmConvCtrl.Height;
            frmElevCtrl.Width = pnl_Control.Width;
            frmElevCtrl.Height = pnl_Control.Height;

            frmConvCtrl.BringToFront();
            frmElevCtrl.BringToFront();

            pnlLeftSmema.Visible = TaskConv.LeftMode == TaskConv.ELeftMode.Smema || TaskConv.LeftMode == TaskConv.ELeftMode.SmemaBiDirection;
            pnlLeftSmema2.Visible = TaskConv.LeftMode == TaskConv.ELeftMode.Smema_SmemaRight || TaskConv.LeftMode == TaskConv.ELeftMode.SmemaBiDirection;

            pnlRightSmema.Visible = TaskConv.RightMode == TaskConv.ERightMode.Smema || TaskConv.RightMode == TaskConv.ERightMode.SmemaBiDirection;
            pnlRightSmema2.Visible = TaskConv.RightMode == TaskConv.ERightMode.Smema_SmemaLeft || TaskConv.RightMode == TaskConv.ERightMode.SmemaBiDirection;

            UpdateDisplay();
            UpdateSelection(btn_Control);
        }

        private void UpdateDisplay()
        {
            Text = GDefine.MHSRecipeName;
            lbl_ProcessTime.Text = i_ProcessTime.ToString();
        }

        private void UpdateSelection(object sender)
        {
            btn_Control.BackColor = sender == btn_Control ? Color.Gray : this.BackColor;
            btn_ConvParam.BackColor = sender == btn_ConvParam ? Color.Gray : this.BackColor;
            btn_ConvIO.BackColor = sender == btn_ConvIO ? Color.Gray : this.BackColor;
            btn_ElevSetup.BackColor = sender == btn_ElevSetup ? Color.Gray : this.BackColor;
            btn_ElevMotorParam.BackColor = sender == btn_ElevMotorParam ? Color.Gray : this.BackColor;
            btn_ElevIO.BackColor = sender == btn_ElevIO ? Color.Gray : this.BackColor;
            btn_Config.BackColor = sender == btn_Config ? Color.Gray : this.BackColor;

            //btnInitLeftElev.Text = "Init Elev " + (TaskConv.LeftMode == TaskConv.ELeftMode.ElevatorZ ? "L" : "") + (TaskConv.RightMode == TaskConv.ERightMode.ElevatorZ ? "R" : "");
            btnInitLeftElev.Enabled = TaskConv.LeftMode == TaskConv.ELeftMode.ElevatorZ;
            btnInitRightElev.Enabled = TaskConv.RightMode == TaskConv.ERightMode.ElevatorZ;
        }

        private void btn_Control_Click(object sender, EventArgs e)
        {
            frmConvCtrl.BringToFront();
            frmElevCtrl.BringToFront();

            UpdateSelection(sender);
        }

        frm_MHS2ConvPara frmConvPara = new frm_MHS2ConvPara();
        frm_MHS2ConvIO frmConvIO = new frm_MHS2ConvIO();

        frm_MHS2ElevSetup frmElevSetup = new frm_MHS2ElevSetup();
        frm_MHS2ElevMotorPara frmElevMotorPara = new frm_MHS2ElevMotorPara();
        frm_MHS2ElevIO frmElevIO = new frm_MHS2ElevIO();
        
        frm_MHS2Config frmConfig = new frm_MHS2Config();

        private void btn_ConvParam_Click(object sender, EventArgs e)
        {
            if (frmConvPara != null)
            {
                frmConvPara.Close();
                frmConvPara = null;
            }
            if (frmConvIO != null)
            {
                frmConvIO.Close();
                frmConvIO = null;
            }
            if (frmElevSetup != null)
            {
                frmElevSetup.Close();
                frmElevSetup = null;
            }
            if (frmElevMotorPara != null)
            {
                frmElevMotorPara.Close();
                frmElevMotorPara = null;
            }
            if (frmElevIO != null)
            {
                frmElevIO.Close();
                frmElevIO = null;
            }
            if (frmConfig != null)
            {
                frmConfig.Close();
                frmConfig = null;
            }

            if (frmConvPara == null) frmConvPara = new frm_MHS2ConvPara();
            frmConvPara.TopLevel = false;
            frmConvPara.Parent = pnl_Control;
            frmConvPara.FormBorderStyle = FormBorderStyle.None;
            frmConvPara.Visible = true;
            frmConvPara.Dock = DockStyle.Fill;
            frmConvPara.BringToFront();

            UpdateSelection(sender);
        }
        private void btn_ConvIO_Click(object sender, EventArgs e)
        {
            if (frmConvPara != null)
            {
                frmConvPara.Close();
                frmConvPara = null;
            }
            if (frmConvIO != null)
            {
                frmConvIO.Close();
                frmConvIO = null;
            }
            if (frmElevSetup != null)
            {
                frmElevSetup.Close();
                frmElevSetup = null;
            }
            if (frmElevMotorPara != null)
            {
                frmElevMotorPara.Close();
                frmElevMotorPara = null;
            }
            if (frmElevIO != null)
            {
                frmElevIO.Close();
                frmElevIO = null;
            }
            if (frmConfig != null)
            {
                frmConfig.Close();
                frmConfig = null;
            }

            if (frmConvIO == null) frmConvIO = new frm_MHS2ConvIO();
            frmConvIO.TopLevel = false;
            frmConvIO.Parent = pnl_Control;
            frmConvIO.FormBorderStyle = FormBorderStyle.None;
            frmConvIO.Visible = true;
            frmConvIO.Dock = DockStyle.Fill;
            frmConvIO.BringToFront();

            UpdateSelection(sender);
        }
        private void btn_ElevSetup_Click(object sender, EventArgs e)
        {
            if (frmConvPara != null)
            {
                frmConvPara.Close();
                frmConvPara = null;
            }
            if (frmConvIO != null)
            {
                frmConvIO.Close();
                frmConvIO = null;
            }
            if (frmElevSetup != null)
            {
                frmElevSetup.Close();
                frmElevSetup = null;
            }
            if (frmElevMotorPara != null)
            {
                frmElevMotorPara.Close();
                frmElevMotorPara = null;
            }
            if (frmElevIO != null)
            {
                frmElevIO.Close();
                frmElevIO = null;
            }
            if (frmConfig != null)
            {
                frmConfig.Close();
                frmConfig = null;
            }

            if (frmElevSetup == null) frmElevSetup = new frm_MHS2ElevSetup();
            frmElevSetup.TopLevel = false;
            frmElevSetup.Parent = pnl_Control;
            frmElevSetup.FormBorderStyle = FormBorderStyle.None;
            frmElevSetup.Visible = true;
            frmElevSetup.Dock = DockStyle.Fill;
            frmElevSetup.BringToFront();

            UpdateSelection(sender);
        }
        private void btn_ElevMotorParam_Click(object sender, EventArgs e)
        {
            if (frmConvPara != null)
            {
                frmConvPara.Close();
                frmConvPara = null;
            }
            if (frmConvIO != null)
            {
                frmConvIO.Close();
                frmConvIO = null;
            }
            if (frmElevSetup != null)
            {
                frmElevSetup.Close();
                frmElevSetup = null;
            }
            if (frmElevMotorPara != null)
            {
                frmElevMotorPara.Close();
                frmElevMotorPara = null;
            }
            if (frmElevIO != null)
            {
                frmElevIO.Close();
                frmElevIO = null;
            }
            if (frmConfig != null)
            {
                frmConfig.Close();
                frmConfig = null;
            }

            if (frmElevMotorPara == null) frmElevMotorPara = new frm_MHS2ElevMotorPara();
            frmElevMotorPara.TopLevel = false;
            frmElevMotorPara.Parent = pnl_Control;
            frmElevMotorPara.FormBorderStyle = FormBorderStyle.None;
            frmElevMotorPara.Visible = true;
            frmElevMotorPara.Dock = DockStyle.Fill;
            frmElevMotorPara.BringToFront();

            UpdateSelection(sender);
        }
        private void btn_ElevIO_Click(object sender, EventArgs e)
        {
            if (frmConvPara != null)
            {
                frmConvPara.Close();
                frmConvPara = null;
            }
            if (frmConvIO != null)
            {
                frmConvIO.Close();
                frmConvIO = null;
            }
            if (frmElevSetup != null)
            {
                frmElevSetup.Close();
                frmElevSetup = null;
            }
            if (frmElevMotorPara != null)
            {
                frmElevMotorPara.Close();
                frmElevMotorPara = null;
            }
            if (frmElevIO != null)
            {
                frmElevIO.Close();
                frmElevIO = null;
            }
            if (frmConfig != null)
            {
                frmConfig.Close();
                frmConfig = null;
            }

            if (frmElevIO == null) frmElevIO = new frm_MHS2ElevIO();
            frmElevIO.TopLevel = false;
            frmElevIO.Parent = pnl_Control;
            frmElevIO.FormBorderStyle = FormBorderStyle.None;
            frmElevIO.Visible = true;
            frmElevIO.Dock = DockStyle.Fill;
            frmElevIO.BringToFront();

            UpdateSelection(sender);
        }
        private void btn_Config_Click(object sender, EventArgs e)
        {
            if (frmConvPara != null)
            {
                frmConvPara.Close();
                frmConvPara = null;
            }
            if (frmConvIO != null)
            {
                frmConvIO.Close();
                frmConvIO = null;
            }
            if (frmElevSetup != null)
            {
                frmElevSetup.Close();
                frmElevSetup = null;
            }
            if (frmElevMotorPara != null)
            {
                frmElevMotorPara.Close();
                frmElevMotorPara = null;
            }
            if (frmElevIO != null)
            {
                frmElevIO.Close();
                frmElevIO = null;
            }
            if (frmConfig != null)
            {
                frmConfig.Close();
                frmConfig = null;
            }

            if (frmConfig == null) frmConfig = new frm_MHS2Config();
            frmConfig.TopLevel = false;
            frmConfig.Parent = pnl_Control;
            frmConfig.FormBorderStyle = FormBorderStyle.None;
            frmConfig.Visible = true;
            frmConfig.Dock = DockStyle.Fill;
            frmConfig.BringToFront();

            UpdateSelection(sender);

            UpdateDisplay();
        }

        private void btn_InitAll_Click(object sender, EventArgs e)
        {
            Msg MsgBox = new Msg();
            EMsgRes MsgRes = MsgBox.Show(ErrCode.ALL_INIT_ACCESS, "", EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
            switch (MsgRes)
            {
                case EMsgRes.smrOK: { }; break;
                default: return;
            }

            Enabled = false;
            try
            {
                TaskConv.Init();
                TaskElev.Init();
            }
            catch (Exception ex)
            {
                //Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());
            }
            finally
            {
                Enabled = true;
            }
        }
        private void btn_InitConv_Click(object sender, EventArgs e)
        {
            #region Msg
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.CONV_INIT_ACCESS, EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                switch (MsgRes)
                {
                    case EMsgRes.smrOK: { }; break;
                    default: return;
                }
            }
            #endregion

            Enabled = false;
            try
            {
                TaskConv.Init();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());
            }
            finally
            {
                Enabled = true;
            }
        }
        private void btnInitLeftElev_Click(object sender, EventArgs e)
        {
            Msg MsgBox = new Msg();
            EMsgRes MsgRes = MsgBox.Show(ErrCode.ELEV_LEFT_INIT_ACCESS, EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
            switch (MsgRes)
            {
                case EMsgRes.smrOK: { }; break;
                default: return;
            }

            Enabled = false;
            try
            {
                TaskElev.Left.Init();
            }
            catch (Exception ex)
            {
                Msg msg = new Msg();
                msg.Show(ex.Message.ToString());
            }
            finally
            {
                Enabled = true;
            }
        }
        private void btnInitRightElev_Click(object sender, EventArgs e)
        {
            Msg MsgBox = new Msg();
            EMsgRes MsgRes = MsgBox.Show(ErrCode.ELEV_RIGHT_INIT_ACCESS, EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
            switch (MsgRes)
            {
                case EMsgRes.smrOK: { }; break;
                default: return;
            }

            Enabled = false;
            try
            {
                TaskElev.Right.Init();
            }
            catch (Exception ex)
            {
                Msg msg = new Msg();
                msg.Show(ex.Message.ToString());
            }
            finally
            {
                Enabled = true;
            }
        }
        private void btn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = GDefine.MHSRecipePath;
            ofd.FileName = GDefine.MHSRecipeName;
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                GDefine.MHSRecipeName = Path.GetFileNameWithoutExtension(ofd.FileName);
                try
                {
                    TaskMHS.LoadRecipe();

                    TaskConv.OpenBoard();
                    TaskElev.OpenBoard(ElevIO.BoardID);
                }
                catch (Exception ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ex.Message.ToString());
                }
            }

            //frmConvCtrl.BringToFront();
            //frmElevCtrl.BringToFront();

            UpdateDisplay();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                TaskMHS.SaveRecipe();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());
            }
        }
        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = GDefine.MHSRecipePath;
            sfd.FileName = GDefine.MHSRecipeName;
            DialogResult dr = sfd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                GDefine.MHSRecipeName = Path.GetFileNameWithoutExtension(sfd.FileName);
                try
                {
                    TaskMHS.SaveRecipe();
                }
                catch (Exception ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ex.Message.ToString());
                }
            }
            UpdateDisplay();
        }

        private void lbl_DryRunProcessTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Dry Run, ProcessTime", ref i_ProcessTime, 0, 10000);
            UpdateDisplay();
        }

        private void EnableCtrl(bool Enable)
        {
            btn_Load.Enabled = Enable;
            btn_Save.Enabled = Enable;
            btn_Close.Enabled = Enable;

            btn_InitAll.Enabled = Enable;
            btn_InitConv.Enabled = Enable;
            btnInitLeftElev.Enabled = Enable;

            btn_Start.Enabled = Enable;
        }

        private void StopRun()
        {
            b_Run = false;
            TaskConv.Status = TaskConv.EConvStatus.Stop;
            WaitIdle();
            TaskConv.Stop();
            EnableCtrl(true);
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.CONV_DRY_RUN_ACCESS, EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                switch (MsgRes)
                {
                    case EMsgRes.smrOK: { }; break;
                    default: return;
                }
            }

            try
            {
                if (TaskConv.Status == TaskConv.EConvStatus.Stop) TaskConv.Status = TaskConv.EConvStatus.Ready;
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.CONV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
                return;
            }

            EnableCtrl(false);

            IO.SetState(EMcState.Run);
            
            b_Run = true;
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            StopRun();
        }

        private static bool WaitIdle()
        {
            Stopwatch sw = Stopwatch.StartNew();
            double t_WatchDog_s = 30;

            while (true)
            {
                if (TaskConv.Status != TaskConv.EConvStatus.Busy) break;
                //Utils.DoEvents();
                Thread.Sleep(1);
                if (sw.Elapsed.Seconds > t_WatchDog_s)
                {
                    TaskConv.Status = TaskConv.EConvStatus.ErrorInit;

                    Msg MsgBox = new Msg();
                    MsgBox.Show("Wait Conv Not Busy Timeout.");
                    break;
                }
            }

            while (true)
            {
                if (!TaskElev.Right.TransferBusy) break;
                //Utils.DoEvents();
                Thread.Sleep(1);
                if (sw.Elapsed.Seconds > t_WatchDog_s)
                {
                    TaskElev.Right.TransferBusy = false;
                    TaskElev.Right.Status = TaskElev.EElevStatus.ErrorInit;

                    Msg MsgBox = new Msg();
                    MsgBox.Show("Wait Right Elev Not Busy Timeout.");
                    break;
                }
                //break;
            }

            while (true)
            {
                if (!TaskElev.Left.TransferBusy) break;
                //Utils.DoEvents();
                Thread.Sleep(1);
                if (sw.Elapsed.Seconds > t_WatchDog_s)
                {
                    TaskElev.Left.TransferBusy = false;
                    TaskElev.Left.Status = TaskElev.EElevStatus.ErrorInit;

                    Msg MsgBox = new Msg();
                    MsgBox.Show("Wait Left Elev Not Busy Timeout.");
                    break;
                }
            }

            return true;
        }

        bool b_Run = false;
        static int i_ProcessTime = 3000;
        static bool b_DispProAsyncIsBusy = false;
        private static void DispProAsync()
        {
            b_DispProAsyncIsBusy = true;
            try
            {
                if (TaskConv.Pro.Status == TaskConv.EProcessStatus.WaitDisp)
                {
                    TaskConv.Pro.Status = TaskConv.EProcessStatus.InProcess;
                    Thread.Sleep(i_ProcessTime);
                    TaskConv.Pro.Status = TaskConv.EProcessStatus.Psnt;
                    if (TaskConv.Pre.Status == TaskConv.EProcessStatus.WaitNone)
                    {
                        TaskConv.Pre.Status = TaskConv.EProcessStatus.Empty;
                    }
                }
                if (TaskConv.Pro.Status == TaskConv.EProcessStatus.WaitDisp2)
                {

                }
            }
            finally { b_DispProAsyncIsBusy = false; }
        }

        static bool b_DispPreAsyncIsBusy = false;
        private static void DispPreAsync()
        {
            b_DispPreAsyncIsBusy = true;
            try
            {
                if (TaskConv.Pre.Status == TaskConv.EProcessStatus.WaitDisp)
                {
                    TaskConv.Pre.Status = TaskConv.EProcessStatus.InProcess;
                    Thread.Sleep(i_ProcessTime);
                    TaskConv.Pre.Status = TaskConv.EProcessStatus.Psnt;
                    if (TaskConv.Pro.Status == TaskConv.EProcessStatus.WaitNone)
                    {
                        TaskConv.Pro.Status = TaskConv.EProcessStatus.Empty;
                    }
                }
                if (TaskConv.Pre.Status == TaskConv.EProcessStatus.WaitDisp2)
                {
                    TaskConv.Pre.Status = TaskConv.EProcessStatus.InProcess;
                    if (TaskConv.Pro.Status == TaskConv.EProcessStatus.WaitDisp2)
                    {
                        TaskConv.Pro.Status = TaskConv.EProcessStatus.InProcess;
                    }
                    Thread.Sleep(i_ProcessTime);
                    TaskConv.Pre.Status = TaskConv.EProcessStatus.Psnt;
                    if (TaskConv.Pro.Status == TaskConv.EProcessStatus.InProcess)
                    {
                        TaskConv.Pro.Status = TaskConv.EProcessStatus.Psnt;
                    }
                }
            }
            finally { b_DispPreAsyncIsBusy = false; }
        }

        public static bool b_RunAsyncIsBusy = false;
        public static async void RunConvAsync()
        {
            b_RunAsyncIsBusy = true;
            try
            {
                await Task.Run(() =>
                {
                    NDispWin.TaskConv.Run();
                });

                if (AutoProcessTime)
                {
                    if (!b_DispProAsyncIsBusy) { Task.Run(() => { DispProAsync(); }); }
                    if (!b_DispPreAsyncIsBusy) { Task.Run(() => { DispPreAsync(); }); }
                }
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("MHS Run Async " + Ex.Message.ToString());
            }
            finally
            {
                b_RunAsyncIsBusy = false;
            }
        }

        private void tmr_Run_Tick(object sender, EventArgs e)
        {
            if (b_Run)
            {
                //if (!bgw_RunConv.IsBusy) bgw_RunConv.RunWorkerAsync();

                if (!b_RunAsyncIsBusy) RunConvAsync();

                if (TaskConv.Status == TaskConv.EConvStatus.Stop)
                {
                    StopRun();
                }
            }

            if (TaskConv.BoardIsOpen)
            {
                lblLeftSmema_BdReady.BackColor = TaskConv.In.Smema_DI_BdReady ? Color.Lime : Color.Gray;
                btnLeftSmema_McReady.BackColor = TaskConv.In.Smema_DO_McReady ? Color.Red : Color.Gray;
                lblRightSmema_McReady.BackColor = TaskConv.Out.Smema_DI_McReady ? Color.Lime : Color.Gray;
                btnRightSmema_BdReady.BackColor = TaskConv.Out.Smema_DO_BdReady ? Color.Red : Color.Gray;

                lblLeftSmema2_McReady.BackColor = TaskConv.In.Smema2_DI_McReady ? Color.Lime : Color.Gray;
                btnLeftSmema2_BdReady.BackColor = TaskConv.In.Smema2_DO_BdReady ? Color.Red : Color.Gray;

                if (TaskConv.RightMode == TaskConv.ERightMode.Smema_SmemaLeft)
                {
                    lblRightSmema2_BdReady.BackColor = TaskConv.In.Smema_DI_BdReady ? Color.Lime : Color.Gray;
                    btnRightSmema2_McReady.BackColor = TaskConv.In.Smema_DO_McReady ? Color.Red : Color.Gray;
                }
                else
                {
                    lblRightSmema2_BdReady.BackColor = TaskConv.Out.Smema2_DI_BdReady ? Color.Lime : Color.Gray;
                    btnRightSmema2_McReady.BackColor = TaskConv.Out.Smema2_DO_McReady ? Color.Red : Color.Gray;
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (b_Run)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Conveyor is in Dry-Run Mode. Stop Dry-Run.");
                return;
            }

            Close();
        }

        static bool AutoProcessTime = true;
        private void cbox_ProcessTime_Click(object sender, EventArgs e)
        {
            AutoProcessTime = !AutoProcessTime;
        }
        private void btn_PreSt_Click(object sender, EventArgs e)
        {
            switch (TaskConv.Pre.Status)
            {
                case TaskConv.EProcessStatus.WaitDisp:
                    TaskConv.Pre.Status = TaskConv.EProcessStatus.InProcess;
                    break;
                case TaskConv.EProcessStatus.InProcess:
                    TaskConv.Pre.Status = TaskConv.EProcessStatus.Psnt;
                    if (TaskConv.Pro.Status == TaskConv.EProcessStatus.WaitNone)
                        TaskConv.Pro.Status = TaskConv.EProcessStatus.Empty;
                    break;
            }
        }
        private void btn_ProSt_Click(object sender, EventArgs e)
        {
            switch (TaskConv.Pro.Status)
            {
                case TaskConv.EProcessStatus.WaitDisp:
                    TaskConv.Pro.Status = TaskConv.EProcessStatus.InProcess;
                    break;
                case TaskConv.EProcessStatus.InProcess:
                    TaskConv.Pro.Status = TaskConv.EProcessStatus.Psnt;
                    if (TaskConv.Pre.Status == TaskConv.EProcessStatus.WaitNone)
                        TaskConv.Pre.Status = TaskConv.EProcessStatus.Empty;
                    break;
            }
        }

        private void btn_LULBypass_Click(object sender, EventArgs e)
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
        private void tmr_1s_Tick(object sender, EventArgs e)
        {
            int t_ByPass = NDispWin.TaskElev.Left.BypassDoorCheckTimer;

            if (t_ByPass > 0)
            {
                btn_LULBypass.Text = "LUL Door ByPass [" + t_ByPass.ToString() + " s]";
                btn_LULBypass.BackColor = Color.Orange;
            }
            else
            {
                btn_LULBypass.Text = "LUL Door Arm";
                btn_LULBypass.BackColor = Color.Red;
            }
        }

        private void lbl_UL_DI_BdReady_MouseDown(object sender, MouseEventArgs e)
        {
            TaskConv.In.Smema_Emulate_DI_BdReady = true;
        }
        private void lbl_UL_DI_BdReady_MouseUp(object sender, MouseEventArgs e)
        {
            TaskConv.In.Smema_Emulate_DI_BdReady = false;
        }
        private void lblLeftSmema2_McReady_MouseDown(object sender, MouseEventArgs e)
        {
            TaskConv.In.Smema2_Emulate_DI_McReady = true;
        }
        private void lblLeftSmema2_McReady_MouseUp(object sender, MouseEventArgs e)
        {
            TaskConv.In.Smema2_Emulate_DI_McReady = false;
        }

        private void lbl_DL_McReady_MouseDown(object sender, MouseEventArgs e)
        {
            TaskConv.Out.Smema_Emulate_DI_McReady = true;
        }
        private void lbl_DL_McReady_MouseUp(object sender, MouseEventArgs e)
        {
            TaskConv.Out.Smema_Emulate_DI_McReady = false;
        }
        private void lblRightSmema2_BdReady_MouseDown(object sender, MouseEventArgs e)
        {
            TaskConv.Out.Smema2_Emulate_DI_BdReady = true;
        }
        private void lblRightSmema2_BdReady_MouseUp(object sender, MouseEventArgs e)
        {
            TaskConv.Out.Smema2_Emulate_DI_BdReady = false;
        }

        private void cbWaitReturn_Click(object sender, EventArgs e)
        {
            TaskConv.bEnableAutoWaitReturn = (sender as CheckBox).Checked;
        }

        private void cbWaitReverseSendout_Click(object sender, EventArgs e)
        {
            TaskConv.bEnableAutoReverseSendout = (sender as CheckBox).Checked;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
