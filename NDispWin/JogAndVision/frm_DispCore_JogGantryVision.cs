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
        public frmVisionView PageVision = new frmVisionView();
        public frm_DispCore_JogGantry2 PageJog = new frm_DispCore_JogGantry2();
        frm_DispCore_Lighting frm_Lighting = new frm_DispCore_Lighting();

        public EForceGantryMode ForceGantryMode = EForceGantryMode.None;

        public bool ShowVision = false;
        public string Inst = "";

        public frmCamera frmCamera = null;// new frmCamera();
        frm_DispCore_JogGantry2 frmJog = new frm_DispCore_JogGantry2();
        public TReticles reticles = new TReticles();
        public bool ShowReticles = false;

        public frm_DispCore_JogGantryVision()
        {
            InitializeComponent();
            ShowVision = true;

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                //if (!DispProg.SetupMode)
                //{
                    this.WindowState = FormWindowState.Maximized;
                    //splitContainer1.BringToFront();
                    //splitContainer1.SplitterDistance = 400;

                    frmCamera = new frmCamera();
                    frmCamera.flirCamera = TaskVision.flirCamera2;
                    frmCamera.CamReticles = Reticle.Reticles; //TaskVision.reticles;
                    frmCamera.FormBorderStyle = FormBorderStyle.None;
                    frmCamera.TopLevel = false;
                    frmCamera.Parent = splitContainer1.Panel1;
                    frmCamera.Dock = DockStyle.Fill;
                    frmCamera.Show();

                    frmCamera.SelectCamera(0);
                    frmCamera.ShowCamReticles = true;
                    frmCamera.Grab();

                    frmJog = new frm_DispCore_JogGantry2();
                    frmJog.FormBorderStyle = FormBorderStyle.None;
                    frmJog.TopLevel = false;
                    frmJog.Parent = splitContainer1.Panel2;
                    frmJog.Dock = DockStyle.Right;
                    frmJog.Show();

                this.BringToFront();

                //}
                //else//do not show vision page
                //{
                //    this.Top = 0;
                //    this.Left = 0;
                //    this.Width = 518;
                //    this.Height = 85;
                //}
            }
            else
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
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
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                splitContainer1.BringToFront();
                splitContainer1.SplitterDistance = this.Width - frmJog.Width;

                //splitContainer1.BringToFront();
                //splitContainer1.SplitterDistance = //500;

                //this.Width - ;

                //this.WindowState = FormWindowState.Maximized;
                //splitContainer1.BringToFront();
                //splitContainer1.SplitterDistance = 500;

                //frmCamera = new frmCamera();
                //frmCamera.flirCamera = TaskVision.flirCamera2;
                //frmCamera.CamReticles = Reticle.Reticles; //TaskVision.reticles;
                //frmCamera.FormBorderStyle = FormBorderStyle.None;
                //frmCamera.TopLevel = false;
                //frmCamera.Parent = splitContainer1.Panel1;
                //frmCamera.Dock = DockStyle.Fill;
                //frmCamera.Show();

                //frmCamera.SelectCamera(0);
                //frmCamera.ShowCamReticles = true;
                //frmCamera.Grab();

                //frmJog = new frm_DispCore_JogGantry2();
                //frmJog.FormBorderStyle = FormBorderStyle.None;
                //frmJog.TopLevel = false;
                //frmJog.Parent = splitContainer1.Panel2;
                //frmJog.Dock = DockStyle.Right;
                //frmJog.Show();
            }

            if (ShowVision && GDefine.CameraType[0] != GDefine.ECameraType.Spinnaker2)
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
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
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

            if (GDefine.CameraType[0] != GDefine.ECameraType.Spinnaker2)
            {
                PageJog.ForceGantryMode = (int)ForceGantryMode;
                PageJog.FormBorderStyle = FormBorderStyle.None;

                if (PageVision.Visible)
                {
                    PageJog.TopLevel = false;
                    PageJog.Parent = this;
                    PageJog.Dock = DockStyle.None;
                    PageJog.Top = 475 - 10;
                    PageJog.Show();
                    PageJog.BringToFront();
                }
                else
                {
                    PageJog.TopLevel = false;
                    PageJog.Parent = this;
                    PageJog.Dock = DockStyle.None;
                    PageJog.Top = 50 - 10;

                    PageJog.Show();
                    PageJog.BringToFront();
                }

                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                this.AutoSize = true;
            }
            lbl_Inst.Text = Inst;
        }
        private void frm_JogGantryVision_Shown(object sender, EventArgs e)
        {

        }

        private void frm_JogGantryVision_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                //if (ShowVision && !b_frmGenImageViewVisible)
                //{
                //    try
                //    {
                //        Invoke(new Action(() =>
                //        {
                //            TaskVision.frmGenImageView.Hide();
                //        }
                //        ));
                //    }
                //    catch
                //    {
                //        Log.AddToLog("frm_JogGantryVision.FormClosed Invoke Exception Error.");
                //    }
                //}
            }

            //ShowVision = true;
            TaskVision.DrawCalStep = 0;
        }
        private void frm_DispCore_JogGantryVision_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL) TaskVision.frmMVCGenTLCamera.Close();

            PageVision.Close();
            PageJog.Close();
            frm_Lighting.Close();
        }
        private void frm_JogGantryVision_Enter(object sender, EventArgs e)
        {

        }
        private void frm_JogGantryVision_Activated(object sender, EventArgs e)
        {
            PageJog.Focus();
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

        private void btn_Lighting_Click(object sender, EventArgs e)
        {
            if (!frm_Lighting.Visible)
            {
                frm_Lighting.BringToFront();
                frm_Lighting.Show();
                //frm_Lighting.Top = this.Bottom;
                //frm_Lighting.Left = this.Left;
            }
            else
                frm_Lighting.Hide();
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                //PageVision.Close();
                //PageJog.Close();
                //if (!PageVision.Visible) frm_Lighting.Close();
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
