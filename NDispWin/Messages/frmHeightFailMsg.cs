using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

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

        bool bClosed = false;
        public frm_DispCore_HeightFailMsg()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopMost = true;
        }

        public EFailAction FailAction = EFailAction.Normal;
        private void frmHeightFailMsg_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            Text = "Height Fail Message";

            string msg = "";
            foreach (string s in Message) msg = s + ", ";
            Log.AddToLog(msg);

            Left = 0;
            Top = 0;

            int B = Buttons & Accept; btn_Accept.Visible = (B == Accept);
            B = Buttons & Reject; btn_Reject.Visible = (B == Reject);

            UpdateDisplay();

            IO.SetState(EMcState.Error);

            if (DispProg.ProgramMode) return;

            Task.Run(() => {//no await
                while (!bClosed)
                {
                    if (bClosed) break;
                    if (TaskDisp.Option_EnableIdleOnError && DispProg.Idle.Idling)
                    {
                        bClosed = true;

                        uint t = DispProg.Idle.Timer();
                        DialogResult = DialogResult.Abort;
                        Thread.Sleep(5);

                        DispProg.Idle.MoveToIdle();

                        if (TaskDisp.Idle_Return && TaskConv.Pro.Status >= TaskConv.EProcessStatus.Heating)
                        {
                            if (TaskConv.Pre.Status != TaskConv.EProcessStatus.Empty || TaskConv.In.SensPsnt) goto _AbortReturn;

                            TaskDisp.Idle_Returned = true;
                            DispProg.UpdateIdleReturnMaps();
                            TaskConv.MoveProToIn();
                        _AbortReturn:;
                        }
                        EMsgRes MsgRes = new Msg().Show((int)ErrCode.AUTO_IDLE_ON_ERROR_EXECUTED, $"Height error unattended for {t}s. Frame is returned to In.");
                        break;
                    }
                    Thread.Sleep(5);
                }
            });
        }

        private void frmHeightFailMsg_FormClosing(object sender, FormClosingEventArgs e)
        {
            bClosed = true;
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
    }
}
