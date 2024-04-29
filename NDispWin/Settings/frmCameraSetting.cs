using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDispWin
{
    partial class frmCameraSetting : Form
    {
        public frmVisionView PageVision = new frmVisionView();
        public frm_DispCore_JogGantry2 PageJog = new frm_DispCore_JogGantry2();

        frmCamera frmCamera = new frmCamera();
        public int CamNo = 0;//cam index start from 0

        public frmCameraSetting()
        {
            InitializeComponent();
            GControl.LogForm(this);

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.ControlBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                frmCamera.Width = 800;
                frmCamera.Height = 600;

                frmCamera.flirCamera = TaskVision.flirCamera2;
                frmCamera.CamReticles = Reticle.Reticles;//TaskVision.reticles;
                frmCamera.FormBorderStyle = FormBorderStyle.None;
                frmCamera.SelectCamera(CamNo);
                frmCamera.TopLevel = false;
                frmCamera.Parent = this;
                frmCamera.Dock = DockStyle.Fill;
                frmCamera.Show();

                frmCamera.ShowCamReticles = true;
                frmCamera.Grab();

                this.Size = new Size(800, 600);
                pnl_Main.Left = this.ClientRectangle.Right - pnl_Main.Width;
                pnl_Main.Top = 0;
                pnl_Main.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            }
        }
        private void frm_DispCore_CameraSetting_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Camera Setting [Cam " + (CamNo + 1).ToString() + "]";

            StartPosition = FormStartPosition.CenterParent;
            TaskVision.SelectedCam = (ECamNo)CamNo;

            PageJog.FormBorderStyle = FormBorderStyle.None;

            switch (GDefine.CameraType[0])
            {
                case GDefine.ECameraType.Spinnaker2: break;
                case GDefine.ECameraType.MVCGenTL:
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.ControlBox = false;
                    this.StartPosition = FormStartPosition.CenterScreen;

                    TaskVision.frmMVCGenTLCamera = new frmMVCGenTLCamera();
                    TaskVision.frmMVCGenTLCamera.Width = 800;
                    TaskVision.frmMVCGenTLCamera.Height = 600;

                    TaskVision.frmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                    TaskVision.frmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                    TaskVision.frmMVCGenTLCamera.SelectCamera(CamNo);
                    TaskVision.frmMVCGenTLCamera.TopLevel = false;
                    TaskVision.frmMVCGenTLCamera.Parent = this;
                    TaskVision.frmMVCGenTLCamera.Dock = DockStyle.Fill;
                    TaskVision.frmMVCGenTLCamera.Show();

                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = true;
                    TaskVision.genTLCamera[0].StartGrab();

                    this.Size = new Size(800, 600);
                    pnl_Main.Left = this.ClientRectangle.Right - pnl_Main.Width;
                    pnl_Main.Top = 0;
                    pnl_Main.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    break;
                case GDefine.ECameraType.Spinnaker:
                    {
                        //TaskVision.frmGenImageView.SelectIndex((int)CamNo);
                        //TaskVision.frmGenImageView.Show();
                        //TaskVision.frmGenImageView.TopMost = true;

                        #region Show Jog Panel
                        PageJog.TopLevel = false;
                        PageJog.Parent = this;
                        PageJog.Dock = DockStyle.None;
                        PageJog.Top = pnl_Main.Height;
                        PageJog.Show();
                        PageJog.Visible = false;
                        #endregion

                        this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        this.AutoSize = true;
                        this.BringToFront();
                        this.TopMost = true;

                        break;
                    }
                default:
                    {
                        #region Show Vision
                        PageVision.FormBorderStyle = FormBorderStyle.None;
                        PageVision.TopLevel = false;
                        PageVision.Parent = this;
                        PageVision.Dock = DockStyle.None;
                        PageVision.Show();
                        #endregion

                        #region Show Jog Panel
                        PageJog.TopLevel = false;
                        PageJog.Parent = this;
                        PageJog.Dock = DockStyle.None;
                        PageJog.Top = PageVision.Height;
                        PageJog.Show();
                        PageJog.Visible = false;
                        #endregion

                        PageJog.BringToFront();
                        PageVision.BringToFront();

                        pnl_Main.Left = PageVision.Width;
                        pnl_Main.Top = 0;

                        this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        this.AutoSize = true;
                        this.BringToFront();
                        this.TopMost = true;

                        break;
                    }
            }

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_Exposure.Text = TaskVision.ExposureTime[CamNo].ToString("f3");
            lbl_Gain.Text = TaskVision.Gain[CamNo].ToString("f3");

            lbl_CalMode.Text = Enum.GetName(typeof (TaskVision.ECalMode), TaskVision.CalMode[CamNo]).ToString();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            TaskVision.SaveSetup();

            PageJog.Close();
            PageVision.Close();
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                //TaskVision.frmGenImageView.Hide();
                this.Close();
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL) TaskVision.frmMVCGenTLCamera.Close();

            DialogResult = DialogResult.OK;
        }

        private void lbl_Exposure_Click(object sender, EventArgs e)
        {
            switch (GDefine.CameraType[CamNo])
            {
                case GDefine.ECameraType.Basler: break;
                case GDefine.ECameraType.PtGrey:
                    {
                        bool Avail = false;
                        double Min = 0;
                        double Max = 0;
                        double Value = 0;
                        TaskVision.PGCamera[CamNo].GetProperty(PtGrey.TCamera.EProperty.Shutter, ref Avail, ref Min, ref Max, ref Value);
                        UC.AdjustExec("Cam " + CamNo.ToString() + ", Exposure Time (us)", ref TaskVision.ExposureTime[CamNo], Min, Max);
                        TaskVision.PGCamera[CamNo].SetProperty(PtGrey.TCamera.EProperty.Shutter, TaskVision.ExposureTime[CamNo]);
                        break;
                    }
                case GDefine.ECameraType.Spinnaker:
                    {
                        //double Min = 0;
                        //double Max = 20;
                        //UC.AdjustExec("Cam " + CamNo.ToString() + ", Exposure Time (us)", ref TaskVision.ExposureTime[CamNo], Min, Max);
                        //TaskVision.FlirCamera[CamNo].Exposure = TaskVision.ExposureTime[CamNo] * 1000;
                        break;
                    }
                case GDefine.ECameraType.Spinnaker2:
                    {
                        double Min = 0;
                        double Max = 20;
                        double d = TaskVision.ExposureTime[CamNo];
                        UC.AdjustExec("Cam " + CamNo.ToString() + ", Exposure Time (us)", ref d, Min, Max);
                        TaskVision.ExposureTime[CamNo] = d;
                        TaskVision.flirCamera2[CamNo].Exposure = d * 1000;
                        break;
                    }
                case GDefine.ECameraType.MVCGenTL:
                    {
                        double Min = 0;
                        double Max = 20;
                        double d = TaskVision.ExposureTime[CamNo];
                        UC.AdjustExec("Cam " + CamNo.ToString() + ", Exposure Time (us)", ref d, Min, Max);
                        TaskVision.ExposureTime[CamNo] = d;
                        TaskVision.genTLCamera[CamNo].Exposure = d * 1000;
                        break;
                    }
            }
            UpdateDisplay();
        }

        private void lbl_Gain_Click(object sender, EventArgs e)
        {
            switch (GDefine.CameraType[CamNo])
            {
                case GDefine.ECameraType.Basler: break;
                case GDefine.ECameraType.PtGrey:
                    {
                        bool Avail = false;
                        double Min = 0;
                        double Max = 0;
                        double Value = 0;
                        TaskVision.PGCamera[CamNo].GetProperty(PtGrey.TCamera.EProperty.Gain, ref Avail, ref Min, ref Max, ref Value);
                        UC.AdjustExec("Cam " + CamNo.ToString() + ", Gain", ref TaskVision.Gain[CamNo], Min, Max);
                        TaskVision.PGCamera[CamNo].SetProperty(PtGrey.TCamera.EProperty.Gain, TaskVision.Gain[CamNo]);
                        break;
                    }
                case GDefine.ECameraType.Spinnaker:
                    {
                        //double Min = 0;
                        //double Max = 24;
                        //UC.AdjustExec("Cam " + CamNo.ToString() + ", Gain", ref TaskVision.Gain[CamNo], Min, Max);
                        //TaskVision.FlirCamera[CamNo].Gain = TaskVision.Gain[CamNo];
                        break;
                    }
                case GDefine.ECameraType.Spinnaker2:
                    {
                        double Min = 0;
                        double Max = 24;
                        UC.AdjustExec("Cam " + CamNo.ToString() + ", Gain", ref TaskVision.Gain[CamNo], Min, Max);
                        TaskVision.flirCamera2[CamNo].Gain = TaskVision.Gain[CamNo];
                        break;
                    }
                case GDefine.ECameraType.MVCGenTL:
                    {
                        double Min = 0;
                        double Max = 24;
                        UC.AdjustExec("Cam " + CamNo.ToString() + ", Gain", ref TaskVision.Gain[CamNo], Min, Max);
                        TaskVision.genTLCamera[CamNo].Gain = TaskVision.Gain[CamNo];
                        break;
                    }
            }
            UpdateDisplay();
        }

        private void btn_ShowJog_Click(object sender, EventArgs e)
        {
            PageJog.Visible = !PageJog.Visible;
        }

        private void lbl_CalMode_Click(object sender, EventArgs e)
        {
            int i = (int)TaskVision.CalMode[CamNo];
            UC.AdjustExec("Cam " + CamNo.ToString() + ", Cal Mode", ref i, 0, Enum.GetNames(typeof(TaskVision.ECalMode)).Length - 1);
            TaskVision.CalMode[CamNo] = (TaskVision.ECalMode)i;

            UpdateDisplay();
        }

        private void pnl_Main_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
