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

        public frmVisionFailMsg2()
        {
            InitializeComponent();
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker) this.AutoSize = true;
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

                frmCamera frmCamera = new frmCamera();
                frmCamera.flirCamera = TaskVision.flirCamera2;
                frmCamera.CamReticles = Reticle.Reticles;
                frmCamera.FormBorderStyle = FormBorderStyle.None;
                frmCamera.TopLevel = false;
                frmCamera.Parent = this;
                frmCamera.Dock = DockStyle.Fill;
                frmCamera.SelectCamera(0);
                frmCamera.Show();

                frmCamera.ShowCamReticles = true;
                frmCamera.Grab();
            }
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

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                //Invoke(new Action(() =>
                //{
                //    if (TaskVision.frmGenImageView.Visible)
                //    {
                //        s_Form = TaskVision.frmGenImageView.Size;
                //        p_Form = TaskVision.frmGenImageView.Location;
                //    }

                //    TaskVision.frmGenImageView.SelectIndex((int)TaskVision.SelectedCam);
                //    TaskVision.frmGenImageView.Show();
                //    TaskVision.frmGenImageView.TopMost = true;

                //    TaskVision.frmGenImageView.Left = 0;
                //    TaskVision.frmGenImageView.Top = 0;
                //    TaskVision.frmGenImageView.Width = Screen.PrimaryScreen.Bounds.Width - (this.Width / 2);
                //    TaskVision.frmGenImageView.Height = Screen.PrimaryScreen.Bounds.Height;

                //    TaskVision.frmGenImageView.EnableCamReticles = true;
                //    TaskVision.frmGenImageView.Grab();
                //    TaskVision.frmGenImageView.ZoomFit();
                //}));
                //this.BringToFront();
                //this.TopMost = true;
                //this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width; ;
                //this.Top = 0;
            }

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                //Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                //if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                //{
                //    TaskVision.flirCamera2[0].GrabCont();
                //    Image = TaskVision.flirCamera2[0].m_ImageEmgu.m_Image.Clone();
                //}

                //pbox_Image.Image = Image.ToBitmap();

            //frmCamera frmCamera = new frmCamera();
                //frmCamera.flirCamera = TaskVision.flirCamera2;
                //frmCamera.CamReticles = Reticle.Reticles; //TaskVision.reticles;
                //frmCamera.FormBorderStyle = FormBorderStyle.None;
                //frmCamera.TopLevel = false;
                //frmCamera.Parent = this;
                //frmCamera.Dock = DockStyle.Fill;
                //frmCamera.Show();

                //frmCamera.ShowCamReticles = true;
                //frmCamera.Grab();
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

                TaskVision.frmMVCGenTLCamera = new frmMVCGenTLCamera();
                TaskVision.frmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                TaskVision.frmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                TaskVision.frmMVCGenTLCamera.TopLevel = false;
                TaskVision.frmMVCGenTLCamera.Parent = this;
                TaskVision.frmMVCGenTLCamera.Dock = DockStyle.Fill;
                TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                TaskVision.frmMVCGenTLCamera.Show();

                TaskVision.frmMVCGenTLCamera.ShowCamReticles = true;
                TaskVision.genTLCamera[0].StartGrab();
            }

            IO.SetState(EMcState.Error);
        }
        private void frmVisionFailMsg2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                //Invoke(new Action(() =>
                //{
                //    if (s_Form.Width > 0)
                //    {
                //        TaskVision.frmGenImageView.Size = s_Form;
                //        TaskVision.frmGenImageView.Location = p_Form;
                //    }
                //    else
                //    {
                //        TaskVision.frmGenImageView.Hide();
                //        TaskVision.frmGenImageView.EnableCamReticles = true;
                //    }
                //}));
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL) TaskVision.frmMVCGenTLCamera.Close();
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
    }
}
