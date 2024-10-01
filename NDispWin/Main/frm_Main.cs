using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace NDispWin
{
    public partial class frm_Main : Form
    {
        #region Click Through ToolStrip
        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        //private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        //private const int MOUSEEVENTF_LEFTUP = 0x04;
        //private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        //private const int MOUSEEVENTF_RIGHTUP = 0x10;

        //private const int WM_PARENTNOTIFY = 0x210;
        //private const int WM_LBUTTONDOWN = 0x201;

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_PARENTNOTIFY)
        //    {
        //        if (m.WParam.ToInt32() == WM_LBUTTONDOWN && ActiveForm != this)
        //        {
        //            Point p = PointToClient(Cursor.Position);
        //            if (GetChildAtPoint(p) is ToolStrip)
        //                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)p.X, (uint)p.Y, 0, 0);
        //        }
        //    }
        //    base.WndProc(ref m);
        //}
        #endregion

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);

        public frm_Main()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.WindowState = FormWindowState.Maximized;

            bool x64App = true;
            if (Environment.Is64BitOperatingSystem)
            {
                Event.APP_INFO.Set("Environment", $"OS 64bit, App {IntPtr.Size * 8}bit");
                SetDllDirectory(@"C:\Program Files (x86)\Point Grey Research\FlyCapture2\bin");
                SetDllDirectory(@"C:\Program Files (x86)\Point Grey Research\Spinnaker\bin\vs2015");

                if (x64App)
                    SetDllDirectory(@"C:\Program Files (x86)\Euresys\Open eVision 2.5\Bin64");
                else
                    SetDllDirectory(@"C:\Program Files (x86)\Euresys\Open eVision 2.5\Bin32");
            }
            else
            {
                Event.APP_INFO.Set("Environment", $" OS 32bit, App {IntPtr.Size * 8}bit");
                SetDllDirectory(@"C:\Program Files\Point Grey Research\FlyCapture2\bin");
                SetDllDirectory(@"C:\Program Files\Point Grey Research\Spinnaker\bin\vs2015");

                SetDllDirectory(@"C:\Program Files\Euresys\Open eVision 2.5\Bin32");
            }

            GDefine.CreateDirs();

            AppLanguage.Func2.WriteLangFile(this);

            NUtils.UserAcc.Users.Load();
        }

        bool MasterInit = false;
        private void frm_Main2_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);

            if (!MasterInit)
            {
                MasterInit = true;

                KeyPreview = true;

                Enabled = false;
                StartUp();
                Enabled = true;
            }
            AppLanguage.Func2.UpdateText(this);
        }
        private void frm_Main2_Activated(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);
        }
        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Shutdown())
            {
                e.Cancel = true;
                return;
            }
        }

        private void UpdateDisplay()
        {
            tsbtnMHS.Visible = GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR;
            tsbtnTable.Visible = (GDefine.ConveyorType == GDefine.EConveyorType.TABLE_S320A);
        }
        private void StartUp()
        {
            try
            {
                //  do not removed, remove will call fail initialiazation of Open_eVision
                Euresys.Open_eVision_2_5.EImageBW8 m_Source = new Euresys.Open_eVision_2_5.EImageBW8();
            }
            catch { };

            ErrCode ErrCode = new ErrCode();

            this.Text = Application.ProductName + " v" + Application.ProductVersion;
            Event.APP_START.Set("AppVersion", this.Text);
            MsgInfo.Init("NDisp3Win");

            Intf.Config.Load();
            TaskMHS.LoadDIO();
            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                try
                {
                    if (!ZEC3002.Ctrl.BoardOpened(ConvIO.BoardID)) TaskConv.OpenBoard();
                    if (!ZEC3002.Ctrl.BoardOpened(ElevIO.BoardID)) TaskElev.OpenBoard(ElevIO.BoardID);
                }
                catch { };
            }

            IO.SetState(EMcState.Idle);

            GDefineN.CheckDir();
            GDefineN.LoadAppData();

            AppLanguage.Func2.SelectedLang = GDefineN.Language1;

            NDispWin.Intf.Setup.Load();
            NDispWin.Intf.OpenAllModules();

            GDefineN.Load();

            try
            {
                if (!NDispWin.Intf.Initialize()) Close();

                string sourceDir = @"C:\DispProg\Setup";
                if (Directory.Exists(sourceDir))
                {
                    string[] files2 = Directory.GetFiles(sourceDir);
                    foreach (string f in files2)
                    {
                        string newFName = GDefine.SetupPath + @"\" + Path.GetFileName(f);
                        if (!File.Exists(newFName)) File.Copy(f, newFName);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "");
            }


            //GDefine.LoadDevice(GDefine.DeviceRecipe);
            GDefine.Table.Load();
            var recipeFullFilename = new DirectoryInfo(GDefine.RecipeDir.FullName).GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            string recipeName = Path.GetFileNameWithoutExtension(recipeFullFilename.FullName);
            DispProg.LoadProgName(recipeName);
            var mhsFullFilename = new DirectoryInfo(GDefine.MHSRecipeDir.FullName).GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            string mhsName = Path.GetFileNameWithoutExtension(mhsFullFilename.FullName);
            TaskMHS.LoadRecipe(mhsName);

            UpdateDisplay();

            GDefineN.SysUpTime.Time = DLLDefine.GetTickCount() - GDefineN.SysUpTime.Ms;
            GDefineN.SysDownTime.Time = -GDefineN.SysDownTime.Ms;//Added 7Mar2014
            GDefineN.SysIdleTime.Time = -GDefineN.SysIdleTime.Ms;//Added 7Mar2014
            GDefineN.SysMTTATime.Time = -GDefineN.SysMTTATime.Ms;//Added 7Mar2014

            Enabled = false;
            try
            {
                Define_Run.InitSystem(true);
            }
            catch { }
            finally
            {
                Enabled = true;
            }

            try
            {
                if (GDefine.sgc2.EnableSECSGEMConnect2) GDefine.sgc2.Connect();
            }
            catch { }
        }
        private bool Shutdown()
        {
            Msg MsgBox = new Msg();
            if (GDefine.EnableLotEntry)
            {
                if (LotInfo2.LotActive)
                {
                    if (MsgBox.Show(ErrCode.EXIT_WHEN_LOT_ACTIVATED, EMcState.Warning, EMsgBtn.smbOK, false) == EMsgRes.smrOK)
                    {
                        IO.SetState(EMcState.None);
                        return false;
                    }
                }
            }
            if (MsgBox.Show(ErrCode.EXIT_SAVE_RECIPE, EMcState.Warning, EMsgBtn.smbOK_Cancel, false) == EMsgRes.smrOK)
            {
                GDefineN.Save();
                GDefineN.SaveAppData();

                IO.SetState(EMcState.None);
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                {
                    //GDefineN.DO_VacPump = false;
                    TaskConv.VacPump = false;
                }
                NDispWin.Intf.CloseAllModules();
                Event.APP_CLOSE.Set("AppVersion", Application.ProductName + " v" + Application.ProductVersion);
                return true;
            }

            return false;
        }

        bool b_BlockEMO = false;
        private void tmr_EMO_Tick(object sender, EventArgs e)
        {
            if (b_BlockEMO) return;

            if (!MsgInfo.Showing)
            {
                if (NDispWin.TaskGantry.EMO())
                {
                    GDefineN.SystemSt = GDefineN.ESystemSt.ErrorInit;
                    b_BlockEMO = true;

                    Msg MsgBox = new Msg();
                    if (MsgBox.Show(ErrCode.EMO_ACTIVATED, "") == EMsgRes.smrOK)
                    {
                        if (!NDispWin.TaskGantry.EMO())
                        {
                        }
                    }
                    b_BlockEMO = false;
                }
            }
        }
        private void tmr_Status_Tick(object sender, EventArgs e)
        {
           if (!Visible) return;

            tslblUser.Text = "[ " + NUtils.UserAcc.Active.GroupName + "/" + NUtils.UserAcc.Active.UserName + " ]";
            tslblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

            if (GDefineN.SystemSt == GDefineN.ESystemSt.ErrorInit)
            {
                lbl_Status.BackColor = Color.Red;
                lbl_Status.Text = "System " + GDefineN.SystemSt.ToString();

                return;
            }

            if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
            {
                if (NDispWin.TaskConv.Status == NDispWin.TaskConv.EConvStatus.ErrorInit)
                {
                    lbl_Status.BackColor = Color.Red;
                    lbl_Status.Text = "Conv " + NDispWin.TaskConv.Status.ToString();
                    return;
                }
            }

            if (GDefine.Status == EStatus.ErrorInit)
            {
                lbl_Status.BackColor = Color.Red;
                lbl_Status.Text = "Gantry " + Color.Red;
            }
            else
            {
                lbl_Status.BackColor = Color.Yellow;
                lbl_Status.Text = "Ready";
            }
        }
        public static bool b_MonitorLowPressure = true;
        private void tmr_1s_Tick(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            
            if (b_MonitorLowPressure)
            {
                if (GDefineN.LowPressureValid())
                {
                    if (!GDefineN.DI_InPressureInRange)
                    {
                        GDefine.InPressureInRange = false;
                        b_MonitorLowPressure = false;
                    }
                }
            }

            tsslSECSGEMConnect2.Text = (int)TaskDisp.SECSGEMProtocol > 0 ? TaskDisp.SECSGEMProtocol.ToString() : "";
            if (TaskDisp.SECSGEMProtocol == TaskDisp.ESECSGEMProtocol.SECSGEMConnect2)
            {
                if (GDefine.sgc2.EnableSECSGEMConnect2)
                {
                    if (GDefine.sgc2.client.IsConnected)
                    {
                        tsslSECSGEMConnect2.Text = "SECSGEMConnnect2 [Connected]";
                        tsslSECSGEMConnect2.BackColor = Color.Lime;
                    }
                    else
                    {
                        tsslSECSGEMConnect2.Text = "SECSGEMConnnect2 [Diconnected]";
                        tsslSECSGEMConnect2.BackColor = Color.Red;
                    }
                }
                else
                {
                    tsslSECSGEMConnect2.Text = "SECSGEMConnnect2 [Disabled]";
                    tsslSECSGEMConnect2.BackColor = Color.Orange;
                }
            }
        }

        private void tsbDevice_Click(object sender, EventArgs e)
        {
            frmDevice frm = new frmDevice();
            frm.ShowDialog();
        }
        private void tsbtnAuto_Click(object sender, EventArgs e)
        {
            frm_Auto frm = new frm_Auto();
            frm.ShowDialog();
            frm.Dispose();
        }
        private void tsbtnProgram_Click(object sender, EventArgs e)
        {
            try
            {
                frm_DispProg2 frm = new frm_DispProg2();
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void tsbtnMHS_Click(object sender, EventArgs e)
        {
            frmMHS2Main frm = new frmMHS2Main();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        private void tsbtnTable_Click(object sender, EventArgs e)
        {
            frm_DesktopSetup frm = new frm_DesktopSetup();
            frm.TopMost = true;
            frm.Show();
        }
        private void tsbtnOptions_Click(object sender, EventArgs e)
        {
            frmOptions frm = new frmOptions();
            frm.ShowDialog();
        }

        private void tsmiIODiag_Click(object sender, EventArgs e)
        {
            NDispWin.frmLmdsWebServiceSetup.IODiag.ShowDialog();
        }
        private void tsmiMotorDiag_Click(object sender, EventArgs e)
        {
            NDispWin.frmLmdsWebServiceSetup.MotorDiag.ShowDialog();
        }
        private void tsmiMotorConfig_Click(object sender, EventArgs e)
        {
            NDispWin.frmLmdsWebServiceSetup.GantryMotorPara.ShowDialog();
        }
        private void tsmiVisionConfig_Click(object sender, EventArgs e)
        {
            NDispWin.frmLmdsWebServiceSetup.VisionSetup.ShowDialog();
        }
        private void tsmiConfig_Click(object sender, EventArgs e)
        {
            NDispWin.frmLmdsWebServiceSetup.SystemConfig.ShowDialog();
            UpdateDisplay();
        }

        private void tsbtnLogin_Click(object sender, EventArgs e)
        {
            NUtils.UserAcc.Users.LoginDlg();
        }
        private void tsbtnInfo_Click(object sender, EventArgs e)
        {
            NDispWin.frmAppInfo frm = new NDispWin.frmAppInfo
            {
                TopMost = true
            };
            frm.ShowDialog();
        }
        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsslSECSGEMConnect2_Click(object sender, EventArgs e)
        {
            try
            {
                if (GDefine.sgc2.EnableSECSGEMConnect2)
                {
                    if (GDefine.sgc2.client.IsConnected)
                        GDefine.sgc2.Disconnect();
                    else
                        GDefine.sgc2.Connect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbtnSetup_Click(object sender, EventArgs e)
        {
            NDispWin.frmLmdsWebServiceSetup.DispSetup.ShowDialog();
        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnInit_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                Define_Run.InitSystem(true);
                //Define_Run.InitGantry(true);
                //Define_Run.InitConv(true);
                //Define_Run.InitLR(true);
            }
            finally
            {
                Enabled = true;
            }
        }

        private void tsbtnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        private void tsbtnInitModule_Click(object sender, EventArgs e)
        {
            if (tsbtnInitGantry.Visible)
            {
                tsbtnInitGantry.Visible = false;
                tsbtnInitConveyor.Visible = false;
                //tsbtnInitElevators.Visible = false;
                tsbtnInitLeft.Visible = false;
                tsbtnInitRight.Visible = false;
                return;
            }
            else
            {
                tsbtnInitGantry.Visible = true;
                if (GDefine.ConveyorType == GDefine.EConveyorType.CONVEYOR)
                {
                    tsbtnInitConveyor.Visible = true;
                    //if (TaskConv.LeftMode == TaskConv.ELeftMode.ElevatorZ || TaskConv.RightMode == TaskConv.ERightMode.ElevatorZ) tsbtnInitElevators.Visible = true;
                    if (TaskConv.LeftMode == TaskConv.ELeftMode.ElevatorZ) tsbtnInitLeft.Visible = true;
                    if (TaskConv.RightMode == TaskConv.ERightMode.ElevatorZ) tsbtnInitRight.Visible = true;
                }
            }
        }

        private void tsbtnInitGantry_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                Define_Run.InitGantry(true);
            }
            finally
            {
                Enabled = true;
                tsbtnInitGantry.Visible = false;
                tsbtnInitConveyor.Visible = false;
                tsbtnInitElevators.Visible = false;
                tsbtnInitLeft.Visible = false;
                tsbtnInitRight.Visible = false;
            }
        }

        private void tsbtnInitConveyor_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                Define_Run.InitConv(true);
            }
            finally
            {
                Enabled = true;
                tsbtnInitGantry.Visible = false;
                tsbtnInitConveyor.Visible = false;
                tsbtnInitElevators.Visible = false;
                tsbtnInitLeft.Visible = false;
                tsbtnInitRight.Visible = false;
            }
        }

        private void tsbtnInitElevators_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                Define_Run.InitLR(true);
            }
            finally
            {
                Enabled = true;
                tsbtnInitGantry.Visible = false;
                tsbtnInitConveyor.Visible = false;
                tsbtnInitElevators.Visible = false;
                tsbtnInitLeft.Visible = false;
                tsbtnInitRight.Visible = false;
            }
        }

        private void tsbtnInitLeft_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                Define_Run.InitLeft(true);
            }
            finally
            {
                Enabled = true;
                tsbtnInitGantry.Visible = false;
                tsbtnInitConveyor.Visible = false;
                tsbtnInitElevators.Visible = false;
                tsbtnInitLeft.Visible = false;
                tsbtnInitRight.Visible = false;
            }
        }

        private void tsbtnInitRight_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                Define_Run.InitRight(true);
            }
            finally
            {
                Enabled = true;
                tsbtnInitGantry.Visible = false;
                tsbtnInitConveyor.Visible = false;
                tsbtnInitElevators.Visible = false;
                tsbtnInitLeft.Visible = false;
                tsbtnInitRight.Visible = false;
            }
        }
    }
}
