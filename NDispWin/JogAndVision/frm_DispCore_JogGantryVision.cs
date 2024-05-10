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

        public frmVisionView PageVision = new frmVisionView();
        //public frmJogGantry PageJog = new frmJogGantry();

        public EForceGantryMode ForceGantryMode = EForceGantryMode.None;

        public bool ShowVision = false;
        public string Inst = "";

        public TReticles reticles = new TReticles();
        public bool ShowReticles = false;

        public frm_DispCore_JogGantryVision()
        {
            InitializeComponent();
            ShowVision = true;

            frmJogControl.FormBorderStyle = FormBorderStyle.None;
            frmJogControl.TopLevel = false;
            frmJogControl.Parent = splitContainer1.Panel2;
            frmJogControl.Dock = DockStyle.Right;
            frmJogControl.Show();


            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
            }
            else
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
            }
            else
            {
                this.Top = 0;
                this.Left = 0;
                this.Width = 518;
            }
        }

        //bool b_frmGenImageViewVisible = TaskVision.frmGenImageView.Visible;
        private void frmJogGantryVision_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

//            TopMost = true;

            this.Text = "Jog";
            this.Top = 0;
            this.Left = 0;

            splitContainer1.BringToFront();
            splitContainer1.SplitterDistance = this.ClientSize.Width - frmJogControl.Width;

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                //TaskVision.frmCamera = new frmCamera();
                //TaskVision.frmCamera.flirCamera = TaskVision.flirCamera2;
                //TaskVision.frmCamera.CamReticles = Reticle.Reticles;
                //TaskVision.frmCamera.FormBorderStyle = FormBorderStyle.None;
                //TaskVision.frmCamera.TopLevel = false;
                //TaskVision.frmCamera.Parent = splitContainer1.Panel1;
                //TaskVision.frmCamera.Dock = DockStyle.Fill;
                //TaskVision.frmCamera.Show();

                //TaskVision.frmCamera.SelectCamera(0);
                //TaskVision.frmCamera.ShowCamReticles = true;
                //TaskVision.frmCamera.Grab();
                TaskVision.frmMVCGenTLCamera = new frmMVCGenTLCamera();
                TaskVision.frmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                TaskVision.frmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                TaskVision.frmMVCGenTLCamera.TopLevel = false;
                TaskVision.frmMVCGenTLCamera.Parent = splitContainer1.Panel1;
                TaskVision.frmMVCGenTLCamera.Dock = DockStyle.Fill;
                TaskVision.frmMVCGenTLCamera.Show();

                TaskVision.genTLCamera[0].StartGrab();
                TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                TaskVision.frmMVCGenTLCamera.ShowCamReticles = true;
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                TaskVision.frmMVCGenTLCamera = new frmMVCGenTLCamera();
                TaskVision.frmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                TaskVision.frmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                TaskVision.frmMVCGenTLCamera.TopLevel = false;
                TaskVision.frmMVCGenTLCamera.Parent = splitContainer1.Panel1;
                TaskVision.frmMVCGenTLCamera.Dock = DockStyle.Fill;
                TaskVision.frmMVCGenTLCamera.Show();

                TaskVision.genTLCamera[0].StartGrab();
                TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                TaskVision.frmMVCGenTLCamera.ShowCamReticles = true;
            }

            if (ShowVision)
                //if (GDefine.CameraType[0] != GDefine.ECameraType.Spinnaker2)
                switch (GDefine.CameraType[0])
                {
                    case GDefine.ECameraType.Spinnaker2:
                    case GDefine.ECameraType.MVSGenTL:
                        //
                        break;
                    default:
                        {
                            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                            {
                                PageVision.Visible = false;

                                try
                                {
                                    Invoke(new Action(() =>
                                    {
                                        //TaskVision.frmGenImageView.Show();
                                        //TaskVision.frmGenImageView.TopMost = true;
                                        //TaskVision.frmGenImageView.EnableCamReticles = true;
                                        //TaskVision.frmGenImageView.ZoomFit();
                                        //TaskVision.frmGenImageView.Grab();
                                    }
                                    ));
                                }
                                catch
                                {
                                    Log.AddToLog("frm_JogGantryVision.Load Invoke Exception Error.");
                                }
                            }
                            else
                            {
                                PageVision.FormBorderStyle = FormBorderStyle.None;
                                PageVision.TopLevel = false;
                                PageVision.Parent = this;
                                PageVision.Dock = DockStyle.Top;
                                PageVision.Show();
                                PageVision.BringToFront();
                            }
                        }
                        break;
                }

            //if (GDefine.CameraType[0] != GDefine.ECameraType.Spinnaker2)
            switch (GDefine.CameraType[0])
            {
                case GDefine.ECameraType.Spinnaker2:
                case GDefine.ECameraType.MVSGenTL:
                    //
                    break;
                default:
                    {
                        //PageJog.ForceGantryMode = (int)ForceGantryMode;
                        //PageJog.FormBorderStyle = FormBorderStyle.None;

                        //if (PageVision.Visible)
                        //{
                        //    PageJog.TopLevel = false;
                        //    PageJog.Parent = this;
                        //    PageJog.Dock = DockStyle.None;
                        //    PageJog.Top = 475 - 10;
                        //    PageJog.Show();
                        //    PageJog.BringToFront();
                        //}
                        //else
                        //{
                        //    PageJog.TopLevel = false;
                        //    PageJog.Parent = this;
                        //    PageJog.Dock = DockStyle.None;
                        //    PageJog.Top = 50 - 10;

                        //    PageJog.Show();
                        //    PageJog.BringToFront();
                        //}

                        //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        //this.AutoSize = true;

                        break;
                    }
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
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2) TaskVision.frmMVCGenTLCamera.Close();//TaskVision.frmCamera.Close();
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL) TaskVision.frmMVCGenTLCamera.Close();

            PageVision.Close();
            //PageJog.Close();
        }
        private void frm_JogGantryVision_Enter(object sender, EventArgs e)
        {

        }
        private void frm_JogGantryVision_Activated(object sender, EventArgs e)
        {
           // PageJog.Focus();
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
                //PageVision.Close();
                //PageJog.Close();
                //if (!PageVision.Visible) frm_LightiClientRectangle.ng.Close();
                DialogResult = DialogResult.OK;
            }
            else
                Visible = false;
        }
        private void btn_Retry_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                //PageVision.Close();
                //PageJog.Close();
                //if (!PageVision.Visible) frm_Lighting.Close();
                DialogResult = DialogResult.Retry;
            }
            else
                Visible = false;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                //PageVision.Close();
                //PageJog.Close();
                //if (!PageVision.Visible) frm_Lighting.Close();
                DialogResult = DialogResult.Cancel;
            }
            else
                Visible = false;
        }
    }
}
