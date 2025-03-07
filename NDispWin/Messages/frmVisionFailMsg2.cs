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
    public partial class frmVisionFailMsg2 : Form
    {
        public string Message = "";
        public bool ShowAccept = false;
        public bool ShowSkip = true;
        public bool ShowManual = true;

        frmMVCGenTLCamera TaskVisionfrmMVCGenTLCamera = new frmMVCGenTLCamera();

        bool bClosed = false;

        public frmVisionFailMsg2()
        {
            InitializeComponent();
            GControl.LogForm(this);
        } 

        Size s_Form = new Size(0,0);
        Point p_Form = new Point(0, 0);
        private void frmVisionFailMsg2_Load(object sender, EventArgs e)
        {
            btn_Accept.Visible = ShowAccept;
            btn_Skip.Visible = ShowSkip;
            btn_Manual.Visible = ShowManual;
            rtbMessage.Text = Message;
            rtbMessage.Visible = rtbMessage.Text.Length > 0;

            Left = 0;
            Top = 0;

            UpdateDisplay();

            Text = "Vision Fail Message";

            try
            {
                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                {
                    this.WindowState = FormWindowState.Maximized;
                    AutoSize = false;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    panel1.Top = 0;
                    panel1.Left = this.Width - panel1.Width;
                    panel1.AutoSize = true;
                    this.TopMost = true;
                    this.BringToFront();

                    TaskVisionfrmMVCGenTLCamera.TopLevel = false;
                    TaskVisionfrmMVCGenTLCamera.Parent = this;
                    TaskVisionfrmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                    TaskVisionfrmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                    TaskVisionfrmMVCGenTLCamera.Dock = DockStyle.Fill;
                    TaskVisionfrmMVCGenTLCamera.SelectCamera(0);
                    TaskVisionfrmMVCGenTLCamera.Show();

                    TaskVisionfrmMVCGenTLCamera.ShowCamReticles = true;
                    TaskVision.genTLCamera[0].StartGrab();
                }
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ex.Message.ToString());
            }

            IO.SetState(EMcState.Error);

            if (DispProg.ProgramMode) return;

            Task.Run(() => {//no await
                while (!bClosed)
                {
                    if (bClosed) break;
                    if (TaskDisp.Option_EnableIdleOnError && DispProg.Idle.Idling)
                    {
                        bClosed = true;

                        if (TaskDisp.Idle_Return && TaskConv.Pro.Status >= TaskConv.EProcessStatus.Heating)
                        {
                            DispProg.UpdateIdleReturnMaps();
                            if (TaskConv.Pre.Status != TaskConv.EProcessStatus.Empty || TaskConv.In.SensPsnt) goto _AbortReturn;
                            TaskDisp.Idle_Returned = true;
                        //TaskConv.MoveProToIn();
                        _AbortReturn:;
                        }
                        Thread.Sleep(5);

                        uint t = DispProg.Idle.Timer();
                        DialogResult = DialogResult.Abort;
                        DispProg.Idle.MoveToIdle();

                        if (TaskDisp.Idle_Return && TaskConv.Pro.Status >= TaskConv.EProcessStatus.Heating)
                        {
                            if (TaskConv.Pre.Status != TaskConv.EProcessStatus.Empty || TaskConv.In.SensPsnt) goto _AbortReturn;
                            TaskDisp.Idle_Returned = true;
                            TaskConv.MoveProToIn();
                        _AbortReturn:;
                        }

                        EMsgRes MsgRes = new Msg().Show((int)ErrCode.AUTO_IDLE_ON_ERROR_EXECUTED, $"Vision error unattended for {t}s. Frame is returned to In.");
                        break;
                    }
                    Thread.Sleep(5);
                }
            });
        }
        private void frmVisionFailMsg2_FormClosing(object sender, FormClosingEventArgs e)
        {
            bClosed = true;
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL) TaskVisionfrmMVCGenTLCamera.Close();
        }

        enum EJogWindPos { TR, BR, BL, TL };
        EJogWindPos JogWindPos = EJogWindPos.TR;
        private void UpdateDisplay()
        {
            switch (JogWindPos)
            {
                case EJogWindPos.TR:
                    panel1.Left = this.Width - panel1.Width;
                    panel1.Top = 0;
                    break;
                case EJogWindPos.BR:
                    panel1.Left = this.Width - panel1.Width;
                    panel1.Top = this.Height - panel1.Height;
                    break;
                case EJogWindPos.BL:
                    panel1.Left = 0;
                    panel1.Top = this.Height - panel1.Height;
                    break;
                case EJogWindPos.TL:
                    panel1.Left = 0;
                    panel1.Top = 0;
                    break;
            }
        }

        private void btn_AlmClr_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Mute);
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
        private void btn_Retry_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }
        private void btn_Skip_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
        private void btn_Manual_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void pbox_Image_Click(object sender, EventArgs e)
        {

        }

        private void btn_JogPos_Click(object sender, EventArgs e)
        {
            if (JogWindPos < EJogWindPos.TL)
                JogWindPos++;
            else
                JogWindPos = EJogWindPos.TR;

            UpdateDisplay();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmVisionFailMsg2_Shown(object sender, EventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                TaskVisionfrmMVCGenTLCamera.SelectCamera(0);
            }
        }

        private void tmr1s_Tick(object sender, EventArgs e)
        {
        }
    }
}
