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
    public partial class frmJogGantry : Form
    {
        frmJogControl frmJogControl = new frmJogControl();

        bool ShowClose = false;
        public int ForceGantryMode = 0;

        public frmJogGantry()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void uctrl_JogGantry1_Load(object sender, EventArgs e)
        {
            //frmJogControl.TopLevel = false;
            //frmJogControl.Parent = this;
            //frmJogControl.FormBorderStyle = FormBorderStyle.None;
            //frmJogControl.BringToFront();
            //frmJogControl.Show();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (this.Modal) Close();
            else
                this.Hide();
        }

        private void frm_DispCore_JogGantry2_Load(object sender, EventArgs e)
        {
            ShowClose = FormBorderStyle != FormBorderStyle.None;

            frmJogControl.TopLevel = false;
            frmJogControl.Parent = this;
            frmJogControl.FormBorderStyle = FormBorderStyle.None;
            frmJogControl.BringToFront();
            frmJogControl.Location = new Point(6, 42);
            frmJogControl.Show();

            btn_Close.Visible = ShowClose;
            if (!ShowClose)
            {
                frmJogControl.Location = new Point(3, 3);
                frmJogControl.ForceGantry = ForceGantryMode;
            }
        }

        private void frm_DispCore_JogGantry2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    } 
}
