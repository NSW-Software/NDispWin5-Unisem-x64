using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    public partial class frm_MHS2ElevMotorPara : Form
    {
        public frm_MHS2ElevMotorPara()
        {
            InitializeComponent();
            AppLanguage.Func2.WriteLangFile(this);
        }

        ZEC3002.Ctrl.TAxis SelectedAxis = ElevIO.LZAxis;
        private void frm_ElevMotorPara_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
 
            btn_Save.Visible = this.Modal;
            btn_Close.Visible = this.Modal;
             
            UpdateDisplay();
            UpdateSelectedAxis();
        }

        public void UpdateSelectedAxis()
        {
                if (SelectedAxis.Name == ElevIO.LZAxis.Name) btn_LZAxis.BackColor = Color.Lime;
            else
                btn_LZAxis.BackColor = this.BackColor;

            if (SelectedAxis.Name == ElevIO.CWAxis.Name) btn_CWAxis.BackColor = Color.Lime;
            else
                btn_CWAxis.BackColor = this.BackColor;

            if (SelectedAxis.Name == ElevIO.RZAxis.Name) btn_RZAxis.BackColor = Color.Lime;
            else
                btn_RZAxis.BackColor = this.BackColor;

            if (SelectedAxis.Name == ElevIO.LPAxis.Name) btn_LPAxis.BackColor = Color.Lime;
            else
                btn_LPAxis.BackColor = this.BackColor;
        }

        private void UpdateDisplay()
        {
            #region Motor Param
            btn_Init.Text = "Init";

            lbl_DistPerPulse.Text = String.Format("{0:0.0000}", SelectedAxis.MotorPara.DistPerPulse);
            lbl_InvertDir.Text = SelectedAxis.MotorPara.InvertDir.ToString();
            switch (SelectedAxis.MotorPara.MotorAlarm)
            {
                case ZEC3002.Ctrl.TMotorAlarm.DISABLE:
                    lbl_MtrAlmLogic.Text = "None";
                    break;
                case ZEC3002.Ctrl.TMotorAlarm.NORMALLY_CLOSE:
                    lbl_MtrAlmLogic.Text = "Nc";
                    break;
                case ZEC3002.Ctrl.TMotorAlarm.NORMALLY_OPEN:
                    lbl_MtrAlmLogic.Text = "No";
                    break;
            }
            lbl_InvertMtrOn.Text = SelectedAxis.MotorPara.InvertMtrOn.ToString(); ;
            //if (SelectedAxis.MotorPara.Home.HomeDir == ZEC3002.Ctrl.THomeDir.N)
            //{
                lbl_HomeDir.Text = SelectedAxis.MotorPara.Home.HomeDir.ToString();// GDefine.NegativeStr;
            //}
            //else
            //{
            //    lbl_HomeDir.Text = GDefine.PositveStr;
            //}
            lbl_SLmtP.Text = SelectedAxis.MotorPara.SLimit.P.ToString("f3");
            lbl_SLmtN.Text = SelectedAxis.MotorPara.SLimit.N.ToString("f3");

            lbl_HomeSlowV.Text = SelectedAxis.MotorPara.Home.SlowV.ToString("f3");
            lbl_HomeFastV.Text = SelectedAxis.MotorPara.Home.FastV.ToString("f3");
            lbl_HomeTimeOut.Text = SelectedAxis.MotorPara.Home.TimeOut.ToString();

            lbl_Accel.Text = SelectedAxis.MotorPara.Accel.ToString("f3");
            lbl_StartV.Text = SelectedAxis.MotorPara.StartV.ToString("f3");
            lbl_SlowV.Text = SelectedAxis.MotorPara.SlowV.ToString("f3");
            lbl_FastV.Text = SelectedAxis.MotorPara.FastV.ToString("f3");

            lbl_JogSlowV.Text = SelectedAxis.MotorPara.Jog.SlowV.ToString("f3");
            lbl_JogMedV.Text = SelectedAxis.MotorPara.Jog.MedV.ToString("f3");
            lbl_JogFastV.Text = SelectedAxis.MotorPara.Jog.FastV.ToString("f3");

            //btn_CopyFromLZ.Visible = ((SelectedAxis.BoardID == EIOCtrl.RZAxis.BoardID) && (SelectedAxis.AxisID == EIOCtrl.RZAxis.AxisID));
            //lbl_LPAxisActivate.Visible = ((SelectedAxis.BoardID == EIOCtrl.LPAxis.BoardID) && (SelectedAxis.AxisID == EIOCtrl.LPAxis.AxisID));
            //lbl_LPAxisActive.Visible = ((SelectedAxis.BoardID == EIOCtrl.LPAxis.BoardID) && (SelectedAxis.AxisID == EIOCtrl.LPAxis.AxisID));
            //if (lbl_LPAxisActive.Visible)
            //    lbl_LPAxisActive.Text = Elev.Setup[(int)Elev.TElevator.Left].EnableLP_Axis.ToString();
            #endregion
        }

        private void UpdateAxis(ZEC3002.Ctrl.TAxis Axis)
        {
            if (SelectedAxis.AxisID == ElevIO.LZAxis.AxisID) { ElevIO.LZAxis = SelectedAxis; }
            if (SelectedAxis.AxisID == ElevIO.CWAxis.AxisID) { ElevIO.CWAxis = SelectedAxis; }
            if (SelectedAxis.AxisID == ElevIO.RZAxis.AxisID) { ElevIO.RZAxis = SelectedAxis; }
            if (SelectedAxis.AxisID == ElevIO.LPAxis.AxisID) { ElevIO.LPAxis = SelectedAxis; }
        }

        private void btn_LZAxis_Click(object sender, EventArgs e)
        {
            UpdateAxis(SelectedAxis);

            SelectedAxis = ElevIO.LZAxis;
            UpdateDisplay();
            UpdateSelectedAxis();
        }
        private void btn_CWAxis_Click(object sender, EventArgs e)
        {
            UpdateAxis(SelectedAxis);

            SelectedAxis = ElevIO.CWAxis;
            UpdateDisplay();
            UpdateSelectedAxis();
        }
        private void btn_RZAxis_Click(object sender, EventArgs e)
        {
            UpdateAxis(SelectedAxis);

            SelectedAxis = ElevIO.RZAxis;
            UpdateDisplay();
            UpdateSelectedAxis();
        }
        private void btn_LPAxis_Click(object sender, EventArgs e)
        {
            UpdateAxis(SelectedAxis);

            SelectedAxis = ElevIO.LPAxis;
            UpdateDisplay();
            UpdateSelectedAxis();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ElevIO.SaveMotorPara(GDefine.MHSMotorParaFile);
            ElevIO.SaveDIOAdd(GDefine.MHSPath + "\\DIOAdd.ini");
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbl_DistPerPulse_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", DistPePulse", ref SelectedAxis.MotorPara.DistPerPulse, 0, 50);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_InvertDir_Click(object sender, EventArgs e)
        {
            SelectedAxis.MotorPara.InvertDir = !SelectedAxis.MotorPara.InvertDir;
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_MtrAlmLogic_Click(object sender, EventArgs e)
        {
            if (SelectedAxis.MotorPara.MotorAlarm == ZEC3002.Ctrl.TMotorAlarm.NORMALLY_OPEN)
            {
                SelectedAxis.MotorPara.MotorAlarm = ZEC3002.Ctrl.TMotorAlarm.DISABLE;
            }
            else
            {
                SelectedAxis.MotorPara.MotorAlarm++;
            }
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_InvertMtrOn_Click(object sender, EventArgs e)
        {
            SelectedAxis.MotorPara.InvertMtrOn = !SelectedAxis.MotorPara.InvertMtrOn;
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_HomeDir_Click(object sender, EventArgs e)
        {
            if (SelectedAxis.MotorPara.Home.HomeDir == ZEC3002.Ctrl.THomeDir.N)
                SelectedAxis.MotorPara.Home.HomeDir = ZEC3002.Ctrl.THomeDir.P;
            else
                SelectedAxis.MotorPara.Home.HomeDir = ZEC3002.Ctrl.THomeDir.N;

            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_SLmtP_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", SLimitP", ref SelectedAxis.MotorPara.SLimit.P, 0, 1000);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_SLmtN_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", SLimitN", ref SelectedAxis.MotorPara.SLimit.P, -1000, 0);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_LPAxisActive_Click(object sender, EventArgs e)
        {
        }

        private void lbl_HomeSlowV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", HomeSlowV", ref SelectedAxis.MotorPara.Home.SlowV, SelectedAxis.MotorPara.MinSpeed, SelectedAxis.MotorPara.MaxSpeed);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_HomeFastV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", HomeFastV", ref SelectedAxis.MotorPara.Home.FastV, SelectedAxis.MotorPara.MinSpeed, SelectedAxis.MotorPara.MaxSpeed);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_HomeTimeOut_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", HomeTimeout", ref SelectedAxis.MotorPara.Home.TimeOut, 5000, 100000);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_JogSlowV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", JogSlowV", ref SelectedAxis.MotorPara.Jog.SlowV, SelectedAxis.MotorPara.MinSpeed, SelectedAxis.MotorPara.MaxSpeed);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_JogMedV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", JogMedV", ref SelectedAxis.MotorPara.Jog.MedV, SelectedAxis.MotorPara.MinSpeed, SelectedAxis.MotorPara.MaxSpeed);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_JogFastV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", JogFastV", ref SelectedAxis.MotorPara.Jog.FastV, SelectedAxis.MotorPara.MinSpeed, SelectedAxis.MotorPara.MaxSpeed);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_Accel_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", Accel", ref SelectedAxis.MotorPara.Accel, SelectedAxis.MotorPara.MinAccel, SelectedAxis.MotorPara.MaxAccel);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_StartV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", StartV", ref SelectedAxis.MotorPara.StartV, SelectedAxis.MotorPara.MinSpeed, SelectedAxis.MotorPara.MaxSpeed);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_SlowV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", SlowV", ref SelectedAxis.MotorPara.SlowV, SelectedAxis.MotorPara.MinSpeed, SelectedAxis.MotorPara.MaxSpeed);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void lbl_FastV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedAxis.Name + ", FastV", ref SelectedAxis.MotorPara.FastV, SelectedAxis.MotorPara.MinSpeed, SelectedAxis.MotorPara.MaxSpeed);
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            if (SelectedAxis.Name.Contains("LZ"))
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.ELEV_LEFT_INIT_ACCESS, "", EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                switch (MsgRes)
                {
                    case EMsgRes.smrOK: { }; break;
                    default: return;
                }
            }
            else if (SelectedAxis.Name.Contains("RZ"))
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.ELEV_RIGHT_INIT_ACCESS, "", EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                switch (MsgRes)
                {
                    case EMsgRes.smrOK: { }; break;
                    default: return;
                }
            }
            else if (SelectedAxis.Name.Contains("LP"))
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.ELEV_LEFT_PUSHER_INIT_ACCESS, "", EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                switch (MsgRes)
                {
                    case EMsgRes.smrOK: { }; break;
                    default: return;
                }

            }


            Enabled = false;

            try
            {
                if (SelectedAxis.Name.Contains("LZ"))
                {
                    TaskElev.Left.Init();
                }
                else if (SelectedAxis.Name.Contains("RZ"))
                {
                    TaskElev.Right.Init();
                }
                else if (SelectedAxis.Name.Contains("LP"))
                {
                }

            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK_Cancel, false);
            }

            Enabled = true;
            UpdateAxis(SelectedAxis);
            UpdateDisplay();
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_BoardID.Text = "Board ID" + ElevIO.BoardID.ToString();
            lbl_BoardID.BackColor = ZEC3002.Ctrl.BoardOpened(ElevIO.BoardID) ? Color.Lime : Color.Red;
        }
    }
}
