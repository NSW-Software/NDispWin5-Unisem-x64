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
        frmJogControl frmJogControl = new frmJogControl();
        frmMVCGenTLCamera TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();

        public EForceGantryMode ForceGantryMode = EForceGantryMode.None;

        public bool ShowVision = false;
        public string Inst = "";

        //public TReticles Reticles = new TReticles();
        //public bool ShowReticles = true;

        public frm_DispCore_JogGantryVision()
        {
            InitializeComponent();
            GControl.LogForm(this);

            ShowVision = true;

            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();

            frmJogControl.FormBorderStyle = FormBorderStyle.None;
            frmJogControl.TopLevel = false;
            frmJogControl.Parent = splitContainer1.Panel2;
            frmJogControl.Dock = DockStyle.Right;
            frmJogControl.Show();

            TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();
            TaskVisionfrmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
            TaskVisionfrmMVCGenTLCamera.TopLevel = false;
            TaskVisionfrmMVCGenTLCamera.Parent = splitContainer1.Panel1;
            TaskVisionfrmMVCGenTLCamera.Dock = DockStyle.Fill;
            TaskVisionfrmMVCGenTLCamera.Show();

            TaskVisionfrmMVCGenTLCamera.CamReticles = Reticle.Reticles;
            TaskVisionfrmMVCGenTLCamera.ShowCamReticles = true;
        }

        private void frmJogGantryVision_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Jog";
            this.Top = 0;
            this.Left = 0;

            splitContainer1.BringToFront();
            splitContainer1.SplitterDistance = this.ClientSize.Width - frmJogControl.Width;

            lbl_Inst.Text = Inst;

            SelectCamera(0);
        }
        private void frm_JogGantryVision_Shown(object sender, EventArgs e)
        {
        }
        private void frm_JogGantryVision_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void frm_DispCore_JogGantryVision_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskVisionfrmMVCGenTLCamera.Close();
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
                TaskDisp.TaskMoveGZUp();

                if (this.Modal)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                    Visible = false;
            }
        }

        public void SelectCamera(int index)
        {
            TaskVisionfrmMVCGenTLCamera.SelectCamera(index);
        }

        public void Reticles(TReticles rectiles, bool show)
        {
            TaskVisionfrmMVCGenTLCamera.Reticles = new TReticles(rectiles);
            TaskVisionfrmMVCGenTLCamera.ShowReticles = show;
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
