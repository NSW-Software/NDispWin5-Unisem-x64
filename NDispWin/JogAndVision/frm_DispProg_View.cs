using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NDispWin
{
    public partial class frm_DispProg_View : Form
    {
        frmJogControl frmJogControl = new frmJogControl();
        frmMVCGenTLCamera TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();

        public bool ShowSetBtn = true;
        public bool ShowCamOfstBtn = false;

        public frm_DispProg_View()
        {
            InitializeComponent();
            GControl.LogForm(this);

            WindowState = FormWindowState.Maximized;

            this.Text = "Image View";

            frmJogControl.TopLevel = false;
            frmJogControl.Parent = this;
            frmJogControl.FormBorderStyle = FormBorderStyle.None;
            frmJogControl.BringToFront();
            frmJogControl.Show();

            TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();
            TaskVisionfrmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
            TaskVisionfrmMVCGenTLCamera.TopLevel = false;
            TaskVisionfrmMVCGenTLCamera.Parent = pbox_Image;
            TaskVisionfrmMVCGenTLCamera.Dock = DockStyle.Fill;
            TaskVisionfrmMVCGenTLCamera.Show();

            TaskVisionfrmMVCGenTLCamera.CamReticles = Reticle.Reticles;
            TaskVisionfrmMVCGenTLCamera.ShowCamReticles = true;
        }

        private void frm_DispProg_View_Load(object sender, EventArgs e)
        {
            btn_CamOfst.Visible = ShowCamOfstBtn;
            btn_Set.Visible = ShowSetBtn;
            btn_Confirm.Visible = false;
            btn_Close.Text = "Close";

            BringToFront();

            JogWindPos = EJogWindPos.TR;
            TaskVisionfrmMVCGenTLCamera.SelectCamera(0);

            UpdateDisplay();
        }
        private void frm_DispProg_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmJogControl.Close();
            TaskVisionfrmMVCGenTLCamera.Close();
        }
        private void frm_DispProg_View_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void frm_DispProg_View_Shown(object sender, EventArgs e)
        {
        }

        enum EJogWindPos { TR, BR, BL, TL };
        EJogWindPos JogWindPos = EJogWindPos.TR;
        private void UpdateDisplay()
        {
            switch (JogWindPos)
            {
                case EJogWindPos.TR:
                    pbox_Image.Left = 0;
                    pbox_Image.Top = pnl_Top.Top + pnl_Top.Height;
                    frmJogControl.Left = this.ClientSize.Width - frmJogControl.Width;
                    frmJogControl.Top = pnl_Top.Top + pnl_Top.Height;
                    break;
                case EJogWindPos.BR:
                    pbox_Image.Left = 0;
                    pbox_Image.Top = pnl_Top.Top + pnl_Top.Height;
                    frmJogControl.Left = this.ClientSize.Width - frmJogControl.Width;
                    frmJogControl.Top = this.ClientSize.Height - frmJogControl.Height;
                    break;
                case EJogWindPos.BL:
                    pbox_Image.Left = this.ClientSize.Width - pbox_Image.Width;
                    pbox_Image.Top = pnl_Top.Top + pnl_Top.Height;
                    frmJogControl.Left = 0;
                    frmJogControl.Top = this.ClientSize.Height - frmJogControl.Height;
                    break;
                case EJogWindPos.TL:
                    pbox_Image.Left = this.ClientSize.Width - pbox_Image.Width;
                    pbox_Image.Top = pnl_Top.Top + pnl_Top.Height;
                    frmJogControl.Left = 0;
                    frmJogControl.Top = pnl_Top.Top + pnl_Top.Height;
                    break;
            }
        }

        private void btn_JogPos_Click(object sender, EventArgs e)
        {
            if (JogWindPos < EJogWindPos.TL)
                JogWindPos++;
            else
                JogWindPos = EJogWindPos.TR;
            UpdateDisplay();
        }

        private void btn_SetOrigin_Click(object sender, EventArgs e)
        {
            btn_Confirm.Visible = true;
            btn_Close.Text = "Cancel";
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //IO.SetState(EMcState.Idle);
        }
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            btn_Confirm.Visible = false;
            DialogResult = DialogResult.OK;
            //IO.SetState(EMcState.Idle);
        }

        private void btn_CamOfst_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskToggleCamOffset();
        }
    }
}
