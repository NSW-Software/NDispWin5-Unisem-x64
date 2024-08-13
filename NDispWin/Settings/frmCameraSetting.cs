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
        public int CamNo = 0;//cam index start from 0
        public frmMVCGenTLCamera TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();

        public frmCameraSetting()
        {
            InitializeComponent();
            GControl.LogForm(this);

            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Sizable;
            ControlBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            TaskVision.SelectedCam = (ECamNo)CamNo;
            TaskVisionfrmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
            TaskVisionfrmMVCGenTLCamera.TopLevel = false;
            TaskVisionfrmMVCGenTLCamera.Parent = this;
            TaskVisionfrmMVCGenTLCamera.Dock = DockStyle.Fill;
            TaskVisionfrmMVCGenTLCamera.Show();

            pnl_Main.Left = ClientRectangle.Right - pnl_Main.Width;
            pnl_Main.Top = 0;
            pnl_Main.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }
        private void frm_DispCore_CameraSetting_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Camera Setting [Cam " + (CamNo + 1).ToString() + "]";

            TaskVisionfrmMVCGenTLCamera.CamReticles = Reticle.Reticles;
            TaskVisionfrmMVCGenTLCamera.ShowCamReticles = true;

            TaskVisionfrmMVCGenTLCamera.SelectCamera(CamNo);

            UpdateDisplay();
        }
        private void frmCameraSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskVisionfrmMVCGenTLCamera.Close();
        }
        private void frmCameraSetting_Shown(object sender, EventArgs e)
        {
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

            DialogResult = DialogResult.OK;
        }

        private void lbl_Exposure_Click(object sender, EventArgs e)
        {
            switch (GDefine.CameraType[CamNo])
            {
                case GDefine.ECameraType.MVSGenTL:
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
                case GDefine.ECameraType.MVSGenTL:
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
        private void lbl_CalMode_Click(object sender, EventArgs e)
        {
            int i = (int)TaskVision.CalMode[CamNo];
            UC.AdjustExec("Cam " + CamNo.ToString() + ", Cal Mode", ref i, 0, Enum.GetNames(typeof(TaskVision.ECalMode)).Length - 1);
            TaskVision.CalMode[CamNo] = (TaskVision.ECalMode)i;

            UpdateDisplay();
        }
    }
}
