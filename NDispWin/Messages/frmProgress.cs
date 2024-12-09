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
    internal partial class frm_DispCore_Progress : Form
    {
        int StartTime = 0;
        public string Message = "Please wait.";
        public bool Cancel = false;
        
        public frm_DispCore_Progress()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopMost = true;

            tmr_Display.Interval = 250;

            //AppLanguage.Func.SetComponent(this);
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            Text = "";

            StartTime = GDefine.GetTickCount();
            tmr_Display.Start();
            pBar_Progress.Value = 0;

            lbl_Message.Text = Message;// +" In Progress.";
            //Application.DoEvents();
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_Message.Text = Message;// +" In Progress.";

            if (!Cancel)
            {
                if (pBar_Progress.Value + 5 > 100) pBar_Progress.Value = 0;
                else
                    pBar_Progress.Value = pBar_Progress.Value + 5;
            }
            else
            {
                if (pBar_Progress.Value + 10 > 100) pBar_Progress.Value = 0;
                else
                    pBar_Progress.Value = pBar_Progress.Value + 10;
            }

            int t_Elapse = GDefine.GetTickCount() - StartTime;
            int h = (t_Elapse / 3600000);
            int m = (t_Elapse / 60000);
            int s = (t_Elapse / 1000);

            lbl_ElapseTime.Text = h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00");
        }

        private void frmProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr_Display.Stop();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
            pBar_Progress.Value = 0;
            pBar_Progress.ForeColor = Color.Red;
            //lbl_Message.Text = Message + " Cancelling...";
            //Close();
            Message = "Cancelling...";
        }
    }
}
