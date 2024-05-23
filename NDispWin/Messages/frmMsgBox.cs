using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace NDispWin
{
    public partial class frm_MsgBox : Form
    {
        public int ErrCode = -1;

        MsgInfo.TMsgInfo CurrentMsgInfo = new MsgInfo.TMsgInfo();

        string ExMsg = "";
        EMcState McState = EMcState.None;
        EMsgBtn MsgBtn = EMsgBtn.smbNone;
        bool Assist = false;

        public EMsgRes MsgRes = EMsgRes.smrNone;

        public frm_MsgBox()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            AutoSize = true;

            pbox_Image.SizeMode = PictureBoxSizeMode.Zoom;


            tmr_BringToFront.Enabled = true;
            tmr_BringToFront.Interval = 5000;

            if (MsgBoxGDefine.MsgImagePath.Length > 0)
                if (!Directory.Exists(MsgBoxGDefine.MsgImagePath)) Directory.CreateDirectory(MsgBoxGDefine.MsgImagePath);
        }

        public void SetErrCode(int ErrCode, string ExMsg, EMcState McState, EMsgBtn Btn, bool Assist)
        {
            this.ErrCode = ErrCode;
            MsgInfo.GetInfo(ErrCode, ref CurrentMsgInfo);

            this.ExMsg = ExMsg;
            this.McState = McState;
            this.MsgBtn = Btn;
            this.Assist = Assist;

            GDefine.sgc2.SendAlarmSet(ErrCode.ToString() + "," + CurrentMsgInfo.Desc);

            NUtils.RegistryWR Reg = new NUtils.RegistryWR("SOFTWARE");
            Reg.WriteKey("NSWAUTOMATION_MSG", "DATETIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Reg.WriteKey("NSWAUTOMATION_MSG", "ERRCODE", ErrCode.ToString("0000"));
            Reg.WriteKey("NSWAUTOMATION_MSG", "DESC", CurrentMsgInfo.Desc);
            Reg.WriteKey("NSWAUTOMATION_MSG", "CACT", CurrentMsgInfo.CAct);
            Reg.WriteKey("NSWAUTOMATION_MSG", "EXMSG", ExMsg);
            Reg.WriteKey("NSWAUTOMATION_MSG", "STATE", McState.ToString());
        }
        public void SetErrCode(string Desc, string CAct, string ExMsg, EMcState McState, EMsgBtn Btn, bool Assist)
        {
            CurrentMsgInfo = new MsgInfo.TMsgInfo(Desc, CAct);

            this.ExMsg = ExMsg;
            this.McState = McState;
            this.MsgBtn = Btn;
            this.Assist = Assist;

            GDefine.sgc2.SendAlarmSet("0" + "," + CurrentMsgInfo.Desc);

            NUtils.RegistryWR Reg = new NUtils.RegistryWR("SOFTWARE");
            Reg.WriteKey("NSWAUTOMATION_MSG", "DATETIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Reg.WriteKey("NSWAUTOMATION_MSG", "ERRCODE", "0");
            Reg.WriteKey("NSWAUTOMATION_MSG", "DESC", CurrentMsgInfo.Desc);
            Reg.WriteKey("NSWAUTOMATION_MSG", "CACT", CurrentMsgInfo.CAct);
            Reg.WriteKey("NSWAUTOMATION_MSG", "EXMSG", ExMsg);
            Reg.WriteKey("NSWAUTOMATION_MSG", "STATE", McState.ToString());
        }

        private void frm_Msg_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            UpdateMsg();
        }
        private void frm_Msg_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void frm_Msg_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr_BringToFront.Enabled = false;
        }
        private void frm_Msg_Shown(object sender, EventArgs e)
        {
        }

        private void UpdateMsg()
        {
            tsslVersion.Text = Application.ProductName + " v" + Application.ProductVersion;

            CurrentMsgInfo.Desc = CurrentMsgInfo.Desc.Replace((char)64, (char)13);
            CurrentMsgInfo.CAct = CurrentMsgInfo.CAct.Replace((char)64, (char)13);
            CurrentMsgInfo.Desc_Alt = CurrentMsgInfo.Desc_Alt.Replace((char)64, (char)13);
            CurrentMsgInfo.CAct_Alt = CurrentMsgInfo.CAct_Alt.Replace((char)64, (char)13);

            //if (CurrentMsgInfo.Desc.Length == 0) CurrentMsgInfo.Desc = "";

            lbl_ErrCode.Text = ErrCode.ToString("0000");
            lbl_Desc.Text = CurrentMsgInfo.Desc;
            lbl_Desc_Alt.Text = CurrentMsgInfo.Desc_Alt;
            lbl_CAct.Text = CurrentMsgInfo.CAct;
            lbl_CAct_Alt.Text = CurrentMsgInfo.CAct_Alt;

            lbl_ExMessage.Text = ExMsg;

            #region Load Image
            string imgFileName = MsgBoxGDefine.MsgImagePath + "\\" + ErrCode.ToString("0000");
            try
            {
                bool FileExist = false;
                if (File.Exists(imgFileName + ".jpg")) { pbox_Image.Load(imgFileName + ".jpg"); FileExist = true; }
                else
                    if (File.Exists(imgFileName + ".png")) { pbox_Image.Load(imgFileName + ".png"); FileExist = true; }
                else
                        if (File.Exists(imgFileName + ".bmp")) { pbox_Image.Load(imgFileName + ".bmp"); FileExist = true; }

                pbox_Image.Visible = FileExist;
                tsslDateTime.Text = DateTime.Now.Date.ToString("dd-MM-yyyy") + " " + DateTime.Now.ToString("HH:mm:ss tt");
            }
            catch
            {
                //lbl_Status.Text = "Load Image Error.";
            }
            #endregion

            #region Color and Icon
            IntPtr mIcon = SystemIcons.Information.Handle;
            switch (McState)//[Msg.CurrentMsgID % Msg.MAX_MSG_QUE])
            {
                //case EMsgIcon.smiQuestion:
                //    mIcon = SystemIcons.Question.Handle;
                //    break;
                //case EMsgIcon.smiWarning:
                //    mIcon = SystemIcons.Warning.Handle;
                //    break;
                //case EMsgIcon.smiError:
                //    mIcon = SystemIcons.Error.Handle;
                //    break;
                case EMcState.Notice:
                    //this.BackColor = Color.DarkOrange;
                    mIcon = SystemIcons.Question.Handle;
                    break;
                case EMcState.Warning:
                    //this.BackColor = Color.Red;
                    mIcon = SystemIcons.Warning.Handle;
                    break;
                case EMcState.Error:
                default:
                    //this.BackColor = Color.Red;
                    mIcon = SystemIcons.Error.Handle;
                    break;
            }
            //Opacity = 0.5;
            pbox_Sign.Image = Bitmap.FromHicon(mIcon);
            #endregion

            #region Button
            btn_AlmClr.Enabled = true;
            btn_OK.Visible = (MsgBtn & EMsgBtn.smbOK) == EMsgBtn.smbOK;
            btnYes.Visible = (MsgBtn & EMsgBtn.smbYes) == EMsgBtn.smbYes;
            btnNo.Visible = (MsgBtn & EMsgBtn.smbNo) == EMsgBtn.smbNo;
            btnSkip.Visible = (MsgBtn & EMsgBtn.smbSkip) == EMsgBtn.smbSkip;
            btn_Retry.Visible = (MsgBtn & EMsgBtn.smbRetry) == EMsgBtn.smbRetry;
            btn_Stop.Visible = (MsgBtn & EMsgBtn.smbStop) == EMsgBtn.smbStop;
            btn_Cancel.Visible = (MsgBtn & EMsgBtn.smbCancel) == EMsgBtn.smbCancel;
            btnContinue.Visible = (MsgBtn & EMsgBtn.smbContinue) == EMsgBtn.smbContinue;
            #endregion

            IO.SetState(McState);

            #region MsgInfo
            MsgInfo.MsgInQue++;

            if (Assist)
            {
                MsgInfo.AssistCount++;
            }
            #endregion

            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + CurrentMsgInfo.Desc + (char)9 + ExMsg);
        }

        private void AlmClr()
        {
            IO.SetState(EMcState.Mute);
        }
        private void OK()
        {
            GDefine.sgc2.SendAlarmClear(ErrCode.ToString("0000"));
            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + "OK");
            IO.SetState(EMcState.Idle);
            MsgRes = EMsgRes.smrOK;
            MsgInfo.MsgInQue--;
            Close();
        }
        private void Yes()
        {
            GDefine.sgc2.SendAlarmClear(ErrCode.ToString("0000"));
            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + "Yes");
            IO.SetState(EMcState.Idle);
            MsgRes = EMsgRes.smrYes;
            MsgInfo.MsgInQue--;
            Close();
        }
        private void No()
        {
            GDefine.sgc2.SendAlarmClear(ErrCode.ToString("0000"));
            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + "No");
            IO.SetState(EMcState.Idle);
            MsgRes = EMsgRes.smrNo;
            MsgInfo.MsgInQue--;
            Close();
        }
        private void Retry()
        {
            GDefine.sgc2.SendAlarmClear(ErrCode.ToString("0000"));
            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + "Retry");
            IO.SetState(EMcState.Last);
            MsgRes = EMsgRes.smrRetry;
            MsgInfo.MsgInQue--;
            Close();
        }
        private void Stop()
        {
            GDefine.sgc2.SendAlarmClear(ErrCode.ToString("0000"));
            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + "Stop");
            IO.SetState(EMcState.Idle);
            MsgRes = EMsgRes.smrStop;
            MsgInfo.MsgInQue--;
            Close();
        }
        private void Skip()
        {
            GDefine.sgc2.SendAlarmClear(ErrCode.ToString("0000"));
            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + "Skip");
            IO.SetState(EMcState.Idle);
            MsgRes = EMsgRes.smrSkip;
            MsgInfo.MsgInQue--;
            Close();
        }
        private void Cancel()
        {
            GDefine.sgc2.SendAlarmClear(ErrCode.ToString("0000"));
            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + "Cancel");
            IO.SetState(EMcState.Idle);
            MsgRes = EMsgRes.smrCancel;
            MsgInfo.MsgInQue--;
            Close();
        }
        private void Continue()
        {
            GDefine.sgc2.SendAlarmClear(ErrCode.ToString("0000"));
            Log.AddToLog(ErrCode.ToString("0000") + (char)9 + "Continue");
            IO.SetState(EMcState.Idle);
            MsgRes = EMsgRes.smrContinue;
            MsgInfo.MsgInQue--;
            Close();
        }

        private void btn_AlmClr_Click(object sender, EventArgs e)
        {
            AlmClr();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (MsgBoxGDefine.enableControlKeyPress && !((ModifierKeys & Keys.Control) == Keys.Control)) return;
            OK();
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            if (MsgBoxGDefine.enableControlKeyPress && !((ModifierKeys & Keys.Control) == Keys.Control)) return;
            Yes();
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            if (MsgBoxGDefine.enableControlKeyPress && !((ModifierKeys & Keys.Control) == Keys.Control)) return;
            No();
        }
        private void btnSkip_Click(object sender, EventArgs e)
        {
            if (MsgBoxGDefine.enableControlKeyPress && !((ModifierKeys & Keys.Control) == Keys.Control)) return;
            Skip();
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (MsgBoxGDefine.enableControlKeyPress && !((ModifierKeys & Keys.Control) == Keys.Control)) return;
            Stop();
        }
        private void btn_Retry_Click(object sender, EventArgs e)
        {
            if (MsgBoxGDefine.enableControlKeyPress && !((ModifierKeys & Keys.Control) == Keys.Control)) return;
            Retry();
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (MsgBoxGDefine.enableControlKeyPress && !((ModifierKeys & Keys.Control) == Keys.Control)) return;
            Continue();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MsgBoxGDefine.enableControlKeyPress && !((ModifierKeys & Keys.Control) == Keys.Control)) return;
            Cancel();
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            tsslQue.Text = "Msg Que " + MsgInfo.MsgInQue.ToString();
        }
        private void tmr_BringToFront_Tick(object sender, EventArgs e)
        {
            BringToFront();
        }
    }
}


