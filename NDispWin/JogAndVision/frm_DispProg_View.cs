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
        public bool ShowSetBtn = true;
        public bool ShowCamOfstBtn = false;

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

        private object _lock = new object();
        private volatile bool _unsubscribed = false;

        Size s_Form = new Size(0, 0);
        Point p_Form = new Point(0, 0);
        private void frm_DispProg_View_Load(object sender, EventArgs e)
        {
            btn_CamOfst.Visible = ShowCamOfstBtn;
            btn_Set.Visible = ShowSetBtn;
            btn_Confirm.Visible = false;
            btn_Close.Text = "Close";

            tmr_Debug.Enabled = true;
            tmr_Debug.Interval = 10000;

            BringToFront();

            UpdateDisplay();

            if (GDefine.CameraType[0] == GDefine.ECameraType.Basler)
            {
                Close();
            }

            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
            {
                try
                {
                    TaskVision.PtGrey_CamLive(0);
                }
                catch { };

                TaskVision.fe.GrabbedEvent += new TaskVision.OnGrabbedEventHandler(GrabbedEvent);
                TaskVision.CameraRun = true;
            }

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
                this.BringToFront();
                this.TopMost = true;
                this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width; ;
                this.Top = 0;
            }

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                    JogWindPos = EJogWindPos.TR;
                    UpdateDisplay();

                    frmCamera frmCamera = new frmCamera();
                    frmCamera.flirCamera = TaskVision.flirCamera2;
                    frmCamera.CamReticles = Reticle.Reticles;
                    frmCamera.FormBorderStyle = FormBorderStyle.None;
                    frmCamera.TopLevel = false;
                    frmCamera.Parent = pbox_Image;
                    frmCamera.Dock = DockStyle.Fill;
                    frmCamera.SelectCamera(0);
                    frmCamera.Show();

                    frmCamera.ShowCamReticles = true;
                    frmCamera.Grab();
            }
        }
        private void frm_DispProg_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
            {
                try
                {
                    TaskVision.PtGrey_CamStop();
                }
                catch { };

                lock (_lock)
                {
                    _unsubscribed = true;
                    TaskVision.fe.GrabbedEvent -= new TaskVision.OnGrabbedEventHandler(GrabbedEvent);
                }
            }
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
                //}
                //));
            }
        }
        private void frm_DispProg_View_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmr_Debug.Enabled = false;

            GC.Collect();
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
                    uctrl_JogGantry1.Left = this.ClientSize.Width - uctrl_JogGantry1.Width;
                    uctrl_JogGantry1.Top = pnl_Top.Top + pnl_Top.Height;
                    break;
                case EJogWindPos.BR:
                    pbox_Image.Left = 0;
                    pbox_Image.Top = pnl_Top.Top + pnl_Top.Height;
                    uctrl_JogGantry1.Left = this.ClientSize.Width - uctrl_JogGantry1.Width;
                    uctrl_JogGantry1.Top = this.ClientSize.Height - uctrl_JogGantry1.Height;
                    break;
                case EJogWindPos.BL:
                    pbox_Image.Left = this.ClientSize.Width - pbox_Image.Width;
                    pbox_Image.Top = pnl_Top.Top + pnl_Top.Height;
                    uctrl_JogGantry1.Left = 0;
                    uctrl_JogGantry1.Top = this.ClientSize.Height - uctrl_JogGantry1.Height;
                    break;
                case EJogWindPos.TL:
                    pbox_Image.Left = this.ClientSize.Width - pbox_Image.Width;
                    pbox_Image.Top = pnl_Top.Top + pnl_Top.Height;
                    uctrl_JogGantry1.Left = 0;
                    uctrl_JogGantry1.Top = pnl_Top.Top + pnl_Top.Height;
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

        private void GrabbedEvent(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (!TaskVision.CameraRun) return;

            if (!TaskVision.PGCamera[0].IsConnected) return;

            lock (_lock)
            {
                if (_unsubscribed) return;

                using (Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> ImageG = TaskVision.PGCamera[0].Image().ToImage<Gray, byte>())//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(TaskVision.PGCamera[0].Image()))
                {
                    try
                    {
                        if (ImageG == null) return;

                        using (Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> ImageC = ImageG.Convert<Emgu.CV.Structure.Bgr, byte>())
                        {
                            TaskVision.ImageDrawReticle(ImageG, ImageC);
                            pbox_Image.Image = ImageC.ToBitmap();
                            pbox_Image.Invalidate();
                        }
                    }
                    catch (Exception Ex)
                    {
                        Log.AddToLog("frm_DispProg_View.GrabbedEvent, " + Ex.Message.ToString() + ".");
                        GC.Collect();
                    }
                    finally
                    {
                    }
                }
                Thread.Sleep(5);
            }
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
