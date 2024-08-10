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
    public partial class frmVisionFailMsg2 : Form
    {
        public string Message = "";
        public bool ShowAccept = false;
        public bool ShowSkip = true;
        public bool ShowManual = true;

        frmCamera TaskVisionfrmCamera = new frmCamera();
        frmMVCGenTLCamera TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();

        public frmVisionFailMsg2()
        {
            InitializeComponent();
        } 

        Size s_Form = new Size(0,0);
        Point p_Form = new Point(0, 0);
        private void frmVisionFailMsg2_Load(object sender, EventArgs e)
        {
            btn_Accept.Visible = ShowAccept;
            btn_Skip.Visible = ShowSkip;
            btn_Manual.Visible = ShowManual;
            rtbMessage.Text = Message;
            rtbMessage.Visible = rtbMessage.Text.Length > 0;

            Left = 0;
            Top = 0;

            UpdateDisplay();

            Text = "Vision Fail Message";

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                this.WindowState = FormWindowState.Maximized;
                AutoSize = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                panel1.Top = 0;
                panel1.Left = this.Width - panel1.Width;
                panel1.AutoSize = true;
                this.TopMost = true;
                this.BringToFront();

                TaskVisionfrmCamera.flirCamera = TaskVision.flirCamera2;
                TaskVisionfrmCamera.CamReticles = Reticle.Reticles;
                TaskVisionfrmCamera.FormBorderStyle = FormBorderStyle.None;
                TaskVisionfrmCamera.TopLevel = false;
                TaskVisionfrmCamera.Parent = this;
                TaskVisionfrmCamera.Dock = DockStyle.Fill;
                TaskVisionfrmCamera.SelectCamera(0);
                TaskVisionfrmCamera.Show();

                TaskVisionfrmCamera.ShowCamReticles = true;
                TaskVision.flirCamera2[0].GrabCont();
            }

            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                this.WindowState = FormWindowState.Maximized;
                AutoSize = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                panel1.Top = 0;
                panel1.Left = this.Width - panel1.Width;
                panel1.AutoSize = true;
                this.TopMost = true;
                this.BringToFront();

                TaskVisionfrmMVCGenTLCamera.TopLevel = false;
                TaskVisionfrmMVCGenTLCamera.Parent = this;
                TaskVisionfrmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                TaskVisionfrmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                TaskVisionfrmMVCGenTLCamera.Dock = DockStyle.Fill;
                TaskVisionfrmMVCGenTLCamera.SelectCamera(0);
                TaskVisionfrmMVCGenTLCamera.Show();

                TaskVisionfrmMVCGenTLCamera.ShowCamReticles = true;
                TaskVision.genTLCamera[0].StartGrab();
            }

            IO.SetState(EMcState.Error);
        }
        private void frmVisionFailMsg2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2) TaskVisionfrmCamera.Close();
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL) TaskVisionfrmMVCGenTLCamera.Close();
        }

        enum EJogWindPos { TR, BR, BL, TL };
        EJogWindPos JogWindPos = EJogWindPos.TR;
        private void UpdateDisplay()
        {
            switch (JogWindPos)
            {
                case EJogWindPos.TR:
                    panel1.Left = this.Width - panel1.Width;
                    panel1.Top = 0;
                    break;
                case EJogWindPos.BR:
                    panel1.Left = this.Width - panel1.Width;
                    panel1.Top = this.Height - panel1.Height;
                    break;
                case EJogWindPos.BL:
                    panel1.Left = 0;
                    panel1.Top = this.Height - panel1.Height;
                    break;
                case EJogWindPos.TL:
                    panel1.Left = 0;
                    panel1.Top = 0;
                    break;
            }
        }

        private void btn_AlmClr_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Mute);
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Last);
            DialogResult = DialogResult.Yes;
        }

        private void btn_Retry_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Last);
            DialogResult = DialogResult.Retry;
        }

        private void btn_Skip_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Last);
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Idle);
            DialogResult = DialogResult.Abort;
        }

        private void btn_Manual_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Last);
            DialogResult = DialogResult.OK;
        }


        private void pbox_Image_Click(object sender, EventArgs e)
        {

        }

        private void btn_JogPos_Click(object sender, EventArgs e)
        {
            if (JogWindPos < EJogWindPos.TL)
                JogWindPos++;
            else
                JogWindPos = EJogWindPos.TR;

            UpdateDisplay();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmVisionFailMsg2_Shown(object sender, EventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                TaskVisionfrmMVCGenTLCamera.SelectCamera(0);
            }
        }
    }
}
