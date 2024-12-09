using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NDispWin
{
    public partial class frm_Message : Form
    {
        public string Message = "";
        public bool OK = false;
        public bool Cancel = false;
        public bool Enable_StartButton = false;
        Stopwatch sw = new Stopwatch();

        public frm_Message()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.Text = "Message";

            Opacity = 0.6;

            Location = new Point(50, 50);
            BringToFront();
            TopMost = true;

            pBar_Progress.Value = 0;
            lbl_ElapseTime.Text = "";
        }
        private void frm_Message_Load(object sender, EventArgs e)
        {
        }
        private void frm_Message_Shown(object sender, EventArgs e)
        {
        }
        private void frm_Message_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void frm_Message_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Cancel = false;
                sw.Reset();
                sw.Start();
                tmr_Display.Enabled = true;
                pBar_Progress.Value = 0;
                pBar_Progress.ForeColor = Color.Lime;

                lbl_Message.Text = Message;
                this.Refresh();
                lbl_Message2.Text = "";
                lbl_StartTime.Text = DateTime.Now.ToString("T");
                btn_Cancel.Visible = true;
            }
            else
            {
                Cancel = false;
                tmr_Display.Enabled = false;
                sw.Stop();
            }
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (pBar_Progress.Value >= pBar_Progress.Maximum)
            {
                pBar_Progress.Value = 0;
            }
            else
                pBar_Progress.Value++;

            Int64 ms = sw.ElapsedMilliseconds;
            int ts = (int)ms /1000;
            int s = ts % 60;
            int tm = ts / 60;
            int m = tm % 3600;
            int th = tm / 60;
            int h = th % 24;

            lbl_ElapseTime.Text = h.ToString("d2") + " H : " + m.ToString("d2") + " M : " + s.ToString("d2") + " S";

            if (Enable_StartButton)
            {
                if (TaskGantry.BtnStart()) btn_OK_Click(sender, e);
                if (!TaskGantry.BtnStop()) btn_Cancel_Click(sender, e);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                Cancel = true;
                btn_Cancel.Visible = false;
                pBar_Progress.ForeColor = Color.Red;
                lbl_Message2.Text = "Cancelling...";
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                OK = true;
            }
        }
    }
}
