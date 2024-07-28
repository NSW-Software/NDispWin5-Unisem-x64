using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;

namespace NDispWin
{
    public partial class frm_DispProg_View : Form
    {
        frmJogControl frmJogControl = new frmJogControl();
        public bool ShowSetBtn = true;
        public bool ShowCamOfstBtn = false;

        public frmMVCGenTLCamera TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();
        public frm_DispProg_View()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                JogWindPos = EJogWindPos.TL;
                pbox_Image.Visible = false;

                WindowState = FormWindowState.Normal;
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }

            this.Text = "Image View";

            UpdateDisplay();
        }

        private void frm_DispProg_View_Load(object sender, EventArgs e)
        {
            frmJogControl.TopLevel = false;
            frmJogControl.Parent = this;
            frmJogControl.FormBorderStyle = FormBorderStyle.None;
            frmJogControl.BringToFront();
            frmJogControl.Show();

            btn_CamOfst.Visible = ShowCamOfstBtn;
            btn_Set.Visible = ShowSetBtn;
            btn_Confirm.Visible = false;
            btn_Close.Text = "Close";

            BringToFront();

            UpdateDisplay();

            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                JogWindPos = EJogWindPos.TR;
                UpdateDisplay();

                TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();
                TaskVisionfrmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                TaskVisionfrmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                TaskVisionfrmMVCGenTLCamera.TopLevel = false;
                TaskVisionfrmMVCGenTLCamera.Parent = pbox_Image;
                TaskVisionfrmMVCGenTLCamera.Dock = DockStyle.Fill;
                TaskVisionfrmMVCGenTLCamera.Show();

                //TaskVisionfrmMVCGenTLCamera.SelectCamera(0);
                //TaskVisionfrmMVCGenTLCamera.ShowCamReticles = true;
                //TaskVisionfrmMVCGenTLCamera.ZoomFit();
                //TaskVision.genTLCamera[0].StartGrab();

                TaskVision.genTLCamera[0].StartGrab();
                TaskVisionfrmMVCGenTLCamera.SelectCamera(0);
                TaskVisionfrmMVCGenTLCamera.ShowCamReticles = true;
                TaskVisionfrmMVCGenTLCamera.ZoomFit();
            }
        }
        private void frm_DispProg_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmJogControl.Close();
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL) TaskVisionfrmMVCGenTLCamera.Close();
        }
        private void frm_DispProg_View_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
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
            IO.SetState(EMcState.Idle);
        }
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            btn_Confirm.Visible = false;
            DialogResult = DialogResult.OK;
            IO.SetState(EMcState.Last);
        }

        private void tmr_Debug_Tick(object sender, EventArgs e)
        {
        }

        private void btn_CamOfst_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskToggleCamOffset();
        }
    }
}
