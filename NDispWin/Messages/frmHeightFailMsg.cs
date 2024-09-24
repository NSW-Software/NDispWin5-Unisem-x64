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
    internal partial class frm_DispCore_HeightFailMsg : Form
    {
        public List<string> Message = new List<string>();
        public const int None = 0x00;
        public const int Retry = 0x01;
        public const int Skip = 0x02;
        public const int Stop = 0x04;
        public const int Accept = 0x08;
        public const int Reject = 0x10;
        public int Buttons = Retry | Skip |Stop |Accept |Reject; 

        public frm_DispCore_HeightFailMsg()
        {
            InitializeComponent();
            TopMost = true;
        }

        public EFailAction FailAction = EFailAction.Normal;
        private void frmHeightFailMsg_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            Text = "Height Fail Message";

            Left = 0;
            Top = 0;

            int B = Buttons & Accept; btn_Accept.Visible = (B == Accept);
            B = Buttons & Reject; btn_Reject.Visible = (B == Reject);

            UpdateDisplay();

            IO.SetState(EMcState.Error);
        }

        private void frmHeightFailMsg_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateDisplay()
        {
            btn_Skip.Enabled = (FailAction != EFailAction.PromptReject);
            btn_Accept.Enabled = (FailAction != EFailAction.PromptReject);

            foreach (string s in Message)
            {
                lbox_Message.Items.Add(s);
            }
        }

        private void btn_AlmClr_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Mute);
        }
        private void btn_Retry_Click(object sender, EventArgs e)
        {
            //IO.SetState(EMcState.Run);
            DialogResult = DialogResult.Retry;
        }
        private void btn_Skip_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
        private void btn_Accept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
        private void btn_Reject_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
        }

        private void lbl_Message_Click(object sender, EventArgs e)
        {

        }
    }
}
