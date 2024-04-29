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
    internal partial class frm_DispCore_VisionFailMsg : Form
    {
        public frm_DispCore_VisionFailMsg()
        {
            InitializeComponent();
            
            TopMost = true;
        }

        public bool ShowSkipButton = true;

        EFailAction FailAction = EFailAction.Normal;

        Bitmap bmp_RefImage = null;//new Bitmap(10, 10);
        Bitmap bmp_FoundImage = null;//new Bitmap(10, 10);

        //int RefNo = 0;
        double FoundScore = 0;
        double FoundXOffset = 0;
        double FoundYOffset = 0;
        double FoundAngle = 0;
        double MinScore = 0;
        double MaxXYOffset = 0;
        double MaxAngle = 0;
        private void frmVisionFailMsg_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            Left = 0;
            Top = 0;

            UpdateDisplay();

            Text = "Vision Fail Message";

            IO.SetState(EMcState.Error);

            btn_Skip.Visible = ShowSkipButton;
        }
        private void frmVisionFailMsg_FormClosed(object sender, FormClosedEventArgs e)
        {
            bmp_RefImage.Dispose();
            bmp_FoundImage.Dispose();
        }

        public DialogResult ShowDialog(
            EFailAction _FailAction,
            Bitmap _RefImage, Bitmap _FoundImage, 
            double _FoundScore, double _FoundXOffset, double _FoundYOffset, double _FoundAngle,
            double _MinScore, double _MaxXYOffset, double _MaxAngle)
        {
            FailAction = _FailAction;

            bmp_RefImage = new Bitmap(_RefImage);
            bmp_FoundImage = new Bitmap(_FoundImage);

            FoundScore = _FoundScore * 100;
            FoundXOffset = _FoundXOffset;
            FoundYOffset = _FoundYOffset;
            FoundAngle = _FoundAngle;
            MinScore = _MinScore * 100;
            MaxXYOffset = _MaxXYOffset;
            MaxAngle = _MaxAngle;
            //this.TopMost = true;
            //return DialogResult.None;// thisShowDialog();
            UpdateDisplay();

            return this.ShowDialog();
        }

        private void UpdateDisplay()
        {
            pbox_Ref.Image = bmp_RefImage;
            pbox_Found.Image = bmp_FoundImage;

            lbl_FoundScore.Text = FoundScore.ToString("0.0");
            lbl_FoundXYOffset.Text = FoundXOffset.ToString("0.000") + "," + FoundYOffset.ToString("0.000");
            lbl_FoundAngle.Text = FoundAngle.ToString("0.000");
            lbl_MinScore.Text = "> " + MinScore.ToString("0.0");
            lbl_MaxXYOffset.Text = "-" + MaxXYOffset.ToString("0.000") + " < value < " + MaxXYOffset.ToString("0.000");
            lbl_MaxAngle.Text = "-" + MaxAngle.ToString("0.000") + " < value < " + MaxAngle.ToString("0.000");

            if (FoundScore < MinScore)
                lbl_FoundScore.ForeColor = Color.Red;
            else
                lbl_FoundScore.ForeColor = this.ForeColor;
            if (FoundXOffset > MaxXYOffset || FoundYOffset > MaxXYOffset)
                lbl_FoundXYOffset.ForeColor = Color.Red;
            else
                lbl_FoundXYOffset.ForeColor = this.ForeColor;
            if (Math.Abs(FoundAngle) > MaxAngle)
                lbl_FoundAngle.ForeColor = Color.Red;
            else
                lbl_FoundAngle.ForeColor = this.ForeColor;

            l_lbl_Angle.Visible = !(FoundAngle == 0 && MaxAngle == 0);
            lbl_FoundAngle.Visible = !(FoundAngle == 0 && MaxAngle == 0);
            lbl_MaxAngle.Visible = !(FoundAngle == 0 && MaxAngle == 0);

            //btn_Accept.Visible = FailAction != EFailAction.PromptReject;
            btn_Manual.Visible = FailAction != EFailAction.PromptReject;
            btn_Skip.Visible = FailAction != EFailAction.PromptReject;
        }

        private void btn_Retry_Click(object sender, EventArgs e)
        {
            //IO.SetState(EMcState.Idle);
            IO.SetState(EMcState.Last);

            DialogResult = DialogResult.Retry;
        }
        private void btn_Skip_Click(object sender, EventArgs e)
        {
            //IO.SetState(EMcState.Idle);
            IO.SetState(EMcState.Last);

            DialogResult = DialogResult.Ignore;
        }

        frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
        private void btn_Manual_Click(object sender, EventArgs e)
        {
            Action action = () =>
            {
                //IO.SetState(EMcState.Idle);
                frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Position Crosshair to Ref";
                frm.ShowVision = true;
                frm.Top = 0;
                frm.Left = this.Width;

                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                {
                    this.TopMost = false;
                    frm.frmCamera.ShowCamReticles = true;
                    frm.frmCamera.ShowReticles = false;
                    frm.frmCamera.SelectCamera(0);
                }
                if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
                {
                    this.TopMost = false;
                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = true;
                    TaskVision.frmMVCGenTLCamera.ShowReticles = false;
                    TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                }
                DialogResult dr = frm.ShowDialog();
                this.TopMost = true;

                if (dr == DialogResult.OK)
                {
                    IO.SetState(EMcState.Last);
                    //IO.SetState(EMcState.Idle);

                    DialogResult = DialogResult.OK;
                }
            };
                        Invoke(action);
        }
        private void btn_Accept_Click(object sender, EventArgs e)
        {
            //IO.SetState(EMcState.Idle);
            IO.SetState(EMcState.Last);

            DialogResult = DialogResult.Yes;
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Idle);
            //IO.SetState(EMcState.Last);

            DialogResult = DialogResult.Abort;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //IO.SetState(EMcState.Last);
            IO.SetState(EMcState.Idle);

            DialogResult = DialogResult.Cancel;
        }
        private void btn_AlmClr_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Mute);
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
        }
    }
}
