using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispCore
{
    partial class frm_DispCore_JogGantryVision : Form
    {
        //public static frm_JogGantryVision Page = new frm_JogGantryVision();

        public frmVisionView PageVision = new frmVisionView();
        public frm_DispCore_JogGantry PageJog = new frm_DispCore_JogGantry();

        //public enum EForceGantryMode { None, XYZ, X2Y2Z2 };
        public frm_DispCore_JogGantry.EForceGantryMode ForceGantryMode = frm_DispCore_JogGantry.EForceGantryMode.None;

        public bool ShowVision = false;
        public string Inst = "";
        public int DrawCalStep = 0;

        public frm_DispCore_JogGantryVision()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
            this.Width = 518;
            ShowVision = true;

            AppLanguage.Func.SetComponent(this);
        }

        private void frmJogGantryVision_Load(object sender, EventArgs e)
        {
            TopMost = true;

            this.Text = "Jog";
            this.Top = 0;
            this.Left = 0;

            if (ShowVision)
            {
                PageVision.TopLevel = false;
                PageVision.Parent = this;
                PageVision.Dock = DockStyle.Top;
                //PageVision.Width = 516;
                //PageVision.Height = 410;
                //PageVision.Top = 0;
                //PageVision.Left = 0;
                PageVision.Show();
                PageVision.BringToFront();
                PageVision.DrawCalStep = DrawCalStep;
                //Height = Height + PageVision.Height;
            }
            else
            {
                PageVision.Visible = false;
                //                PageVision.Height = 0;
            }

            PageJog.ForceGantryMode = ForceGantryMode;
            if (ShowVision)
            {
                PageJog.TopLevel = false;
                PageJog.Parent = this;
                PageJog.Dock = DockStyle.None;
                //PageJog.Width = 516;
                //PageJog.Height = 300;
                PageJog.Top = 475;
                //PageJog.Left = 0;
                PageJog.Show();
                PageJog.BringToFront();
                //Height = Height + PageJog.Height;


               // this.Height = PageJog.Top + PageJog.Height + 28;
            }
            else
            {
                PageJog.TopLevel = false;
                PageJog.Parent = this;
                PageJog.Dock = DockStyle.None;
                //PageJog.Width = 516;
                //PageJog.Height = 300;
                PageJog.Top = 50;
                //PageJog.Left = 0;
                
                PageJog.Show();
                PageJog.BringToFront();

                //this.Height = PageJog.Top + PageJog.Height + 28;

            }

            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.AutoSize = true;

            lbl_Inst.Text = Inst;
        }

        private void frm_JogGantryVision_Shown(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                PageVision.Close();
                PageJog.Close();
                DialogResult = DialogResult.OK;
            }
            else
                Visible = false;
            //PageJog.Focus();
        }

        private void btn_Retry_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                PageVision.Close();
                PageJog.Close();
                DialogResult = DialogResult.Retry;
            }
            else
                Visible = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                PageVision.Close();
                PageJog.Close();
                DialogResult = DialogResult.Cancel;
            }
            else
                Visible = false;
        }

        private void frm_JogGantryVision_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowVision = true;
            DrawCalStep = 0;
        }

        private void frm_JogGantryVision_Enter(object sender, EventArgs e)
        {

        }

        private void frm_JogGantryVision_Activated(object sender, EventArgs e)
        {
            PageJog.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
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
    }
}
