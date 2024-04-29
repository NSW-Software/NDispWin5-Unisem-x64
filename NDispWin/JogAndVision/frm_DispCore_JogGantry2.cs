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
    public partial class frm_DispCore_JogGantry2 : Form
    {
        bool ShowClose = false;
        public int ForceGantryMode = 0;

        public frm_DispCore_JogGantry2()
        {
            InitializeComponent();

        }

        private void uctrl_JogGantry1_Load(object sender, EventArgs e)
        {

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

            btn_Close.Visible = ShowClose;
            if (!ShowClose)
            {
                uctrl_JogGantry1.Location = new Point(3, 3);
                uctrl_JogGantry1.ForceGantry = ForceGantryMode;
            }
        }

        private void frm_DispCore_JogGantry2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    } 
}
