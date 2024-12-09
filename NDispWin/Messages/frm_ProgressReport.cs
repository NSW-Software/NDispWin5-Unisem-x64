using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDispWin
{
    public partial class frm_ProgressReport : Form
    {
        public string Message = "";
        Stopwatch sw = new Stopwatch();
        public bool ShowButtons = true;
        public bool Enable_StartButton = false;
        public bool Done = false;
        public bool Cancel = false;

        int progress = 0;

        public frm_ProgressReport()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_ProgressReport_Load(object sender, EventArgs e)
        {
            TopMost = true;

            this.Left = 100;
            this.Top = 100;

            btn_OK.Visible = this.Modal && ShowButtons;
            btn_Cancel.Visible = this.Modal && ShowButtons;
            
            lbl_Message.Text = Message;
            lbl_StartTime.Text = "Start Time: " + DateTime.Now.ToString("T");

            progress = 0;

            sw.Reset();
            sw.Start();

        }
        private void tmr_500ms_Tick(object sender, EventArgs e)
        {
            Int64 ms = sw.ElapsedMilliseconds;
            int ts = (int)ms / 1000;
            int s = ts % 60;
            int tm = ts / 60;
            int m = tm % 3600;
            int th = tm / 60;
            int h = th % 24;

            progress++;
            progressBar.Value = progress % 100;

            lbl_ElapseTime.Text = "Elapsed Time: " + h.ToString("d2") + " H : " + m.ToString("d2") + " M : " + s.ToString("d2") + " S";

            if (Cancel) Close();
            if (Done) Close();

            if (Enable_StartButton)
            {
                if (TaskGantry.BtnStart()) btn_OK_Click(sender, e);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Cancel = true;
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                Cancel = true;
                Close();
            }
        }
    }
}
