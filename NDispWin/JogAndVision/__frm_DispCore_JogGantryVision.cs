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
    partial class frm_DispCore_JogGantryVision : Form
    {
        public frmJogControl frmJogControl = new frmJogControl();
        public EForceGantryMode ForceGantryMode = EForceGantryMode.None;
        public frmMVCGenTLCamera TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();

        public bool ShowVision = false;
        public string Inst = "";

        public frm_DispCore_JogGantryVision()
        {
            InitializeComponent();
            ShowVision = true;

            frmJogControl.FormBorderStyle = FormBorderStyle.None;
            frmJogControl.TopLevel = false;
            frmJogControl.Parent = splitContainer1.Panel2;
            frmJogControl.Dock = DockStyle.Right;
            frmJogControl.Show();

            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
            }
        }
        private void frmJogGantryVision_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Jog";
            this.Top = 0;
            this.Left = 0;

            splitContainer1.BringToFront();
            splitContainer1.SplitterDistance = this.ClientSize.Width - frmJogControl.Width;

            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                //TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();
                TaskVisionfrmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                TaskVisionfrmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                TaskVisionfrmMVCGenTLCamera.TopLevel = false;
                TaskVisionfrmMVCGenTLCamera.Parent = splitContainer1.Panel1;
                TaskVisionfrmMVCGenTLCamera.Dock = DockStyle.Fill;
                TaskVisionfrmMVCGenTLCamera.Show();

                TaskVision.genTLCamera[0].StartGrab();
                TaskVisionfrmMVCGenTLCamera.SelectCamera(0);
                TaskVisionfrmMVCGenTLCamera.ShowCamReticles = true;
                TaskVisionfrmMVCGenTLCamera.ZoomFit();
            }

            lbl_Inst.Text = Inst;
        }
        private void frm_JogGantryVision_Shown(object sender, EventArgs e)
        {

        }

        private void frm_JogGantryVision_FormClosed(object sender, FormClosedEventArgs e)
        {
            TaskVision.DrawCalStep = 0;
        }
        private void frm_DispCore_JogGantryVision_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL) TaskVisionfrmMVCGenTLCamera.Close();
        }
        private void frm_JogGantryVision_Enter(object sender, EventArgs e)
        {

        }
        private void frm_JogGantryVision_Activated(object sender, EventArgs e)
        {
        }
        private void frm_JogGantryVision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TaskDisp.TaskMoveGZZ2Up();

                if (this.Modal)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                    Visible = false;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                DialogResult = DialogResult.OK;
            }
            else
                Visible = false;
        }
        private void btn_Retry_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                DialogResult = DialogResult.Retry;
            }
            else
                Visible = false;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
                Visible = false;
        }
    }
}
