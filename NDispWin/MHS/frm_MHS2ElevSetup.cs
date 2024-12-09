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
    public partial class frm_MHS2ElevSetup : Form
    {
        static TaskElev.TElevator SelectedElev;
        static TaskElev.EMagazine SelectedMag = TaskElev.EMagazine.Magazine1;

        public frm_MHS2ElevSetup()
        {
            InitializeComponent();
            GControl.LogForm(this);

            AppLanguage.Func2.WriteLangFile(this);
        }

        private void frm_ElevSetup_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            btn_Save.Visible = this.Modal;
            btn_Close.Visible = this.Modal;

            //Initial values
            ElevIO.LZAxis.MotorPara.Jog.Sel = ElevIO.LZAxis.MotorPara.Jog.SlowV;
            ElevIO.RZAxis.MotorPara.Jog.Sel = ElevIO.RZAxis.MotorPara.Jog.SlowV;
        }

        int Speed = 0;
        bool MotionBusy = false;
        bool MeasureD = false;

        bool b_Step = false;
        double StepDist = 0.010;
        
        double LZRefPos = 0;
        double RZRefPos = 0;
        private void UpdateDisplay()
        {
            lbl_LZStatus.Text = TaskElev.ElevStatus[(int)TaskElev.TElevator.Left].ToString();
            lbl_LZStatus.BackColor = TaskElev.ElevStatusColor[(int)TaskElev.Left.Status];
            lbl_RZStatus.Text = TaskElev.ElevStatus[(int)TaskElev.TElevator.Right].ToString();
            lbl_RZStatus.BackColor = TaskElev.ElevStatusColor[(int)TaskElev.Right.Status];

            #region Selected Elev
            if (SelectedElev == TaskElev.TElevator.Left)
                btn_LeftElev.BackColor = Color.Lime;
            else
                btn_LeftElev.BackColor = this.BackColor;

            if (SelectedElev == TaskElev.TElevator.Right)
                btn_RightElev.BackColor = Color.Lime;
            else
                btn_RightElev.BackColor = this.BackColor;
            #endregion
            #region Magazine
            lbl_MagzCount.Text = TaskElev.Setups[(int)SelectedElev].MagCount.ToString();
            //lbl_LevelCount.Text = TaskElev.Setups[(int)SelectedElev].LevelCount.ToString();
            //lbl_LevelPitch.Text = TaskElev.Setups[(int)SelectedElev].LevelPitch.ToString("f3");
            //if (TaskElev.Setups[(int)SelectedElev].LevelPitch > 0)
            //    lbl_LevelDir.Text = "TopDown";
            //else
            //    lbl_LevelDir.Text = "BottomUp";
            lbl_LevelCount.Text = TaskElev.Setups[(int)SelectedElev].MagLevelCount[(int)SelectedMag].ToString();
            lbl_LevelPitch.Text = TaskElev.Setups[(int)SelectedElev].MagLevelPitch[(int)SelectedMag].ToString("f3");
            if (TaskElev.Setups[(int)SelectedElev].MagLevelPitch[(int)SelectedMag] > 0)
                lbl_LevelDir.Text = "TopDown";
            else
                lbl_LevelDir.Text = "BottomUp";
            lbl_LoadMagPos.Text = TaskElev.Setups[(int)SelectedElev].MagLoadPos.ToString("f3");

            #region Selected Mag
            if (SelectedMag == TaskElev.EMagazine.Magazine1)
                btn_Mag1.BackColor = Color.Lime;
            else
                btn_Mag1.BackColor = this.BackColor;

            if (SelectedMag == TaskElev.EMagazine.Magazine2)
                btn_Mag2.BackColor = Color.Lime;
            else
                btn_Mag2.BackColor = this.BackColor;

            if (SelectedMag == TaskElev.EMagazine.Magazine3)
                btn_Mag3.BackColor = Color.Lime;
            else
                btn_Mag3.BackColor = this.BackColor;

            if (SelectedMag == TaskElev.EMagazine.Magazine4)
                btn_Mag4.BackColor = Color.Lime;
            else
                btn_Mag4.BackColor = this.BackColor;
            #endregion

            btn_Mag4.Visible = TaskElev.Setups[(int)SelectedElev].MagCount >= 4;
            btn_Mag3.Visible = TaskElev.Setups[(int)SelectedElev].MagCount >= 3;

            lbl_1stLevelPos.Text = TaskElev.Setups[(int)SelectedElev].Mag1stLevelPos[(int)SelectedMag].ToString("f3");
            lbl_LastLevel1stMagzPos.Text = TaskElev.GetLastPos((int)SelectedElev, (int)SelectedMag).ToString("f3");
            //btn_SetMagLastLevelPos.Visible = SelectedMag == TaskElev.EMagazine.Magazine1;
            #endregion

            #region Pusher
            gbox_Pusher.Visible = (SelectedElev == TaskElev.TElevator.Left);
            lbl_PusherType.Text = TaskElev.Setups[(int)SelectedElev].PusherType.ToString();
            lbl_PusherExtDelay.Text = TaskElev.Setups[(int)SelectedElev].PusherExtDelay.ToString();
            lbl_PusherTimeout.Text = TaskElev.Setups[(int)SelectedElev].PusherTimeout.ToString();
            lbl_PusherRetDelay.Text = TaskElev.Setups[(int)SelectedElev].PusherRetDelay.ToString();
            lbl_PusherRetry.Text = TaskElev.Setups[(int)SelectedElev].PusherRetry.ToString();
            lbl_PusherRunConv.Text = TaskElev.Setups[(int)SelectedElev].PusherRunConv.ToString();
            #endregion

            #region Options
            lbl_EnableDoorSens.Text = TaskElev.Setups[(int)SelectedElev].EnableDoorSens.ToString();
            #endregion

            #region Jog
            //UpdateSpeed();
            //StepDis = TaskElev.Setup[(int)SelectedElev].Step;
            double dis = Convert.ToDouble(StepDist); ;// / 1000;
            lbl_Step.Text = dis.ToString("f4");
            if (SelectedElev == TaskElev.TElevator.Left)
            {
                btn_OEZN.Text = "LZ";
                btn_OEZP.Text = "LZ";

                btn_PusherRet.Enabled = true;
                btn_PusherExt.Enabled = true;

                lbl_LULPos.ForeColor = Color.Lime;
                double LZA = TaskElev.Pos(ElevIO.LZAxis);
                if (MeasureD)
                {
                    lbl_LULPos.ForeColor = Color.Yellow;
                    LZA = LZA - LZRefPos;
                }
                lbl_LULPos.Text = LZA.ToString("f3");
            }
            if (SelectedElev == TaskElev.TElevator.Right)
            {
                btn_OEZN.Text = "RZ";
                btn_OEZP.Text = "RZ";

                btn_PusherRet.Enabled = false;
                btn_PusherExt.Enabled = false;

                lbl_LULPos.ForeColor = Color.Lime;
                double RZA = TaskElev.Pos(ElevIO.RZAxis);
                if (MeasureD)
                {
                    lbl_LULPos.ForeColor = Color.Yellow;
                    RZA = RZA - RZRefPos;
                }
                lbl_LULPos.Text = RZA.ToString("f3");
            }
            #endregion
            //UpdateDG();
        }
        private void UpdateSpeed()
        {
            switch (Speed)
            {
                case 1:
                    btn_Speed.Text = "Med";// GDefine.MedSpeedStr;
                    ElevIO.LZAxis.MotorPara.Jog.Sel = ElevIO.LZAxis.MotorPara.Jog.MedV;
                    ElevIO.RZAxis.MotorPara.Jog.Sel = ElevIO.RZAxis.MotorPara.Jog.MedV;
                    break;
                case 2:
                    btn_Speed.Text = "Fast";// GDefine.FastSpeedStr;
                    ElevIO.LZAxis.MotorPara.Jog.Sel = ElevIO.LZAxis.MotorPara.Jog.FastV;
                    ElevIO.RZAxis.MotorPara.Jog.Sel = ElevIO.RZAxis.MotorPara.Jog.FastV;
                    break;

                default:
                    btn_Speed.Text = "Slow";// GDefine.SlowSpeedStr;
                    ElevIO.LZAxis.MotorPara.Jog.Sel = ElevIO.LZAxis.MotorPara.Jog.SlowV;
                    ElevIO.RZAxis.MotorPara.Jog.Sel = ElevIO.RZAxis.MotorPara.Jog.SlowV;
                    break;

            }
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_BoardID.Text = "Board ID" + ElevIO.BoardID.ToString();
            lbl_BoardID.BackColor = ZEC3002.Ctrl.BoardOpened(ElevIO.BoardID) ? Color.Lime : Color.Red;

            if (TaskElev.BoardIsOpen) UpdateDisplay();
        }
        private void tmr_Measure_Tick(object sender, EventArgs e)
        {
            if (!Visible) { return; }
            if (MeasureD)
                btn_MeasureJog.BackColor = Color.Lime;
            else
                btn_MeasureJog.BackColor = SystemColors.ButtonFace;
            if (b_Step)
                btn_Step.BackColor = Color.Red;
            else
                btn_Step.BackColor = SystemColors.ButtonFace;
        }

        private void btn_LeftElev_Click(object sender, EventArgs e)
        {
            SelectedElev = TaskElev.TElevator.Left;
            UpdateDisplay();
        }
        private void btn_RightElev_Click(object sender, EventArgs e)
        {
            SelectedElev = TaskElev.TElevator.Right;
            UpdateDisplay();
        }

        private void btn_SetLoadMagzPos_Click(object sender, EventArgs e)
        {
            Enabled = false;

            try
            {
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    TaskElev.Setups[0].MagLoadPos = (int)TaskElev.Left.Pos;
                }
                else
                {
                    TaskElev.Setups[1].MagLoadPos = (int)TaskElev.Right.Pos;
                }
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
            }

            Enabled = true;
            UpdateDisplay();
        }
        private void btn_GotoLoadMagzPos_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                double Pos = 0;

                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    if (!TaskElev.Left.Ready) { goto _Error; }
                    if (!TaskElev.Left.SafetyCheck_ElevMove()) { goto _Error; }
                    if (!TaskElev.Left.PusherHome()) { goto _Error; }
                    Pos = TaskElev.Setups[0].MagLoadPos;
                    if (!TaskElev.SetMotionParam(ref ElevIO.LZAxis, ElevIO.LZAxis.MotorPara.StartV, ElevIO.LZAxis.MotorPara.FastV, ElevIO.LZAxis.MotorPara.Accel)) { goto _Error; }
                    if (!TaskElev.LZMove(Pos))
                    {
                        TaskElev.ElevStatus[(int)TaskElev.TElevator.Left] = TaskElev.EElevStatus.ErrorInit;
                        goto _Error;
                    }
                }
                else
                {
                    if (!TaskElev.Right.Ready) { goto _Error; }
                    if (!TaskElev.Right.SafeCheck_ElevMove()) { goto _Error; }
                    //if (!TaskElev.Right.PusherReturn()) { goto _Error; }
                    Pos = TaskElev.Setups[1].MagLoadPos;
                    if (!TaskElev.SetMotionParam(ref ElevIO.RZAxis, ElevIO.RZAxis.MotorPara.StartV, ElevIO.RZAxis.MotorPara.FastV, ElevIO.RZAxis.MotorPara.Accel)) { goto _Error; }
                    if (!TaskElev.RZMove(Pos))
                    {
                        TaskElev.ElevStatus[(int)TaskElev.TElevator.Right] = TaskElev.EElevStatus.ErrorInit;
                        goto _Error;
                    }
                }
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
            }

        _Error:
            Enabled = true;
        }
        private void lbl_LoadMagzPos_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", LoadMagPos", ref TaskElev.Setups[(int)SelectedElev].MagLoadPos, -1000, 1000);
            UpdateDisplay();
        }
        private void lbl_MagzCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", MagCount", ref TaskElev.Setups[(int)SelectedElev].MagCount, 1, TaskElev.MAX_MAG_COUNT);
            UpdateDisplay();
        }
        private void lbl_LevelCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", LevelCount", ref TaskElev.Setups[(int)SelectedElev].MagLevelCount[(int)SelectedMag], 1, 50);
            UpdateDisplay();
        }
        private void lbl_LevelPitch_Click(object sender, EventArgs e)
        {
            double d = Math.Round(TaskElev.Setups[(int)SelectedElev].MagLevelPitch[(int)SelectedMag], 3);
            if (UC.AdjustExec(SelectedElev.ToString() + ", LevelPitch", ref d, -50, 50))
            TaskElev.Setups[(int)SelectedElev].MagLevelPitch[(int)SelectedMag] = d;
            UpdateDisplay();
        }
        private void lbl_LevelDir_Click(object sender, EventArgs e)
        {
            double Pitch = TaskElev.Setups[(int)SelectedElev].MagLevelPitch[(int)SelectedMag];
            int LevelCount = (int)TaskElev.Setups[(int)SelectedElev].MagLevelCount[(int)SelectedMag];

            for (int i = 0; i < TaskElev.Setups[(int)SelectedElev].MagCount; i++)
            {
                double FirstLevelPos = TaskElev.Setups[(int)SelectedElev].Mag1stLevelPos[i];
                TaskElev.Setups[(int)SelectedElev].Mag1stLevelPos[i] = FirstLevelPos + (Pitch * (LevelCount - 1));
            }

            TaskElev.Setups[(int)SelectedElev].MagLevelPitch[(int)SelectedMag] = -Pitch;
            UpdateDisplay();
        }

        private void btn_Mag1_Click(object sender, EventArgs e)
        {
            SelectedMag = TaskElev.EMagazine.Magazine1;
            TaskElev.Setups[(int)SelectedElev].PsntMagz = (int)SelectedMag;
            UpdateDisplay();
        }
        private void btn_Mag2_Click(object sender, EventArgs e)
        {
            SelectedMag = TaskElev.EMagazine.Magazine2;
            TaskElev.Setups[(int)SelectedElev].PsntMagz = (int)SelectedMag;
            UpdateDisplay();
        }
        private void btn_Mag3_Click(object sender, EventArgs e)
        {
            SelectedMag = TaskElev.EMagazine.Magazine3;
            TaskElev.Setups[(int)SelectedElev].PsntMagz = (int)SelectedMag;
            UpdateDisplay();
        }
        private void btn_Mag4_Click(object sender, EventArgs e)
        {
            SelectedMag = TaskElev.EMagazine.Magazine4;
            TaskElev.Setups[(int)SelectedElev].PsntMagz = (int)SelectedMag;
            UpdateDisplay();
        }

        private void lbl_1stLevelPos_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", LoadMagPos", ref TaskElev.Setups[(int)SelectedElev].Mag1stLevelPos[(int)SelectedMag], -1000, 1000);
            UpdateDisplay();
        }
        private void btn_SetMagFirstLevelPos_Click(object sender, EventArgs e)
        {
            Enabled = false;

            try
            {
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    TaskElev.Setups[0].Mag1stLevelPos[(int)SelectedMag] = TaskElev.Left.Pos;
                }
                else
                {
                    TaskElev.Setups[1].Mag1stLevelPos[(int)SelectedMag] = TaskElev.Right.Pos;
                }
                TaskElev.Setups[(int)SelectedElev].PsntLevel = 1;
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
            }

            Enabled = true;
            UpdateDisplay();
        }
        private void btn_GotoMagFirstLevelPos_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                double Pos = 0;

                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    if (!TaskElev.Left.Ready) { goto _Error; }
                    if (!TaskElev.Left.SafetyCheck_ElevMove()) { goto _Error; }
                    if (!TaskElev.Left.PusherHome()) { goto _Error; }
                    Pos = TaskElev.Setups[0].Mag1stLevelPos[(int)SelectedMag];
                    if (!TaskElev.SetMotionParam(ref ElevIO.LZAxis, ElevIO.LZAxis.MotorPara.StartV, ElevIO.LZAxis.MotorPara.FastV, ElevIO.LZAxis.MotorPara.Accel)) { goto _Error; }
                    if (!TaskElev.LZMove(Pos))
                    {
                        TaskElev.ElevStatus[(int)TaskElev.TElevator.Left] = TaskElev.EElevStatus.ErrorInit;
                        goto _Error;
                    }
                }
                else
                {
                    if (!TaskElev.Right.Ready) { goto _Error; }
                    if (!TaskElev.Right.SafeCheck_ElevMove()) { goto _Error; }
                    //if (!TaskElev.Right.PusherReturn()) { goto _Error; }
                    Pos = TaskElev.Setups[1].Mag1stLevelPos[(int)SelectedMag];
                    if (!TaskElev.SetMotionParam(ref ElevIO.RZAxis, ElevIO.RZAxis.MotorPara.StartV, ElevIO.RZAxis.MotorPara.FastV, ElevIO.RZAxis.MotorPara.Accel)) { goto _Error; }
                    if (!TaskElev.RZMove(Pos))
                    {
                        TaskElev.ElevStatus[(int)TaskElev.TElevator.Right] = TaskElev.EElevStatus.ErrorInit;
                        goto _Error;
                    }
                }
                TaskElev.Setups[(int)SelectedElev].PsntLevel = 1;
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
            }

        _Error:

            Enabled = true;
        }
        private void btn_SetMagLastLevelPos_Click(object sender, EventArgs e)
        {
            Enabled = false;

            try
            {
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    double Pos = TaskElev.Left.Pos;
                    try
                    {
                        //TaskElev.Setups[(int)TaskElev.TElevator.Left].LevelPitch = ((Pos -
                        //                       TaskElev.Setups[(int)TaskElev.TElevator.Left].Mag1stLevelPos[0]) /
                        //                       (TaskElev.Setups[(int)TaskElev.TElevator.Left].LevelCount - 1));
                        TaskElev.Setups[(int)TaskElev.TElevator.Left].MagLevelPitch[(int)SelectedMag] = ((Pos -
                                               TaskElev.Setups[(int)TaskElev.TElevator.Left].Mag1stLevelPos[(int)SelectedMag]) /
                                               (TaskElev.Setups[(int)TaskElev.TElevator.Left].MagLevelCount[(int)SelectedMag] - 1));
                    }
                    catch
                    {
                    }
                }
                else
                {
                    double Pos = TaskElev.Right.Pos;
                    try
                    {
                        //TaskElev.Setups[(int)TaskElev.TElevator.Right].LevelPitch = ((Pos -
                        //                       TaskElev.Setups[(int)TaskElev.TElevator.Right].Mag1stLevelPos[0]) /
                        //                       (TaskElev.Setups[(int)TaskElev.TElevator.Right].LevelCount - 1));
                        TaskElev.Setups[(int)TaskElev.TElevator.Right].MagLevelPitch[(int)SelectedMag] = ((Pos -
                                               TaskElev.Setups[(int)TaskElev.TElevator.Right].Mag1stLevelPos[(int)SelectedMag]) /
                                               (TaskElev.Setups[(int)TaskElev.TElevator.Right].MagLevelCount[(int)SelectedMag] - 1));
                    }
                    catch
                    {
                    }
                }
                TaskElev.Setups[(int)SelectedElev].PsntLevel = TaskElev.Setups[(int)SelectedElev].MagLevelCount[(int)SelectedMag];
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
            }

            Enabled = true;
            UpdateDisplay();
        }
        private void btn_GotoMagLastLevelPos_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                double Pos = 0;

                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    if (!TaskElev.Left.Ready) { goto _Error; }
                    if (!TaskElev.Left.SafetyCheck_ElevMove()) { goto _Error; }
                    if (!TaskElev.Left.PusherHome()) { goto _Error; }
                    //Pos = TaskElev.Setup[0].Param[(int)TaskElev.TParam.LastLevel_1stMagzPos];
                    Pos = TaskElev.GetLastPos((int)SelectedElev, (int)SelectedMag);
                    if (!TaskElev.SetMotionParam(ref ElevIO.LZAxis, ElevIO.LZAxis.MotorPara.StartV, ElevIO.LZAxis.MotorPara.FastV, ElevIO.LZAxis.MotorPara.Accel)) { goto _Error; }
                    if (!TaskElev.LZMove(Pos))
                    {
                        TaskElev.ElevStatus[(int)TaskElev.TElevator.Left] = TaskElev.EElevStatus.ErrorInit;
                        goto _Error;
                    }
                }
                else
                {
                    if (!TaskElev.Right.Ready) { goto _Error; }
                    if (!TaskElev.Right.SafeCheck_ElevMove()) { goto _Error; }
                    //if (!TaskElev.Right.PusherReturn()) { goto _Error; }
                    //Pos = TaskElev.Setup[1].Param[(int)TaskElev.TParam.LastLevel_1stMagzPos];
                    Pos = TaskElev.GetLastPos((int)SelectedElev, (int)SelectedMag);
                    if (!TaskElev.SetMotionParam(ref ElevIO.RZAxis, ElevIO.RZAxis.MotorPara.StartV, ElevIO.RZAxis.MotorPara.FastV, ElevIO.RZAxis.MotorPara.Accel)) { goto _Error; }
                    if (!TaskElev.RZMove(Pos))
                    {
                        TaskElev.ElevStatus[(int)TaskElev.TElevator.Right] = TaskElev.EElevStatus.ErrorInit;
                        goto _Error;
                    }
                }
                TaskElev.Setups[(int)SelectedElev].PsntLevel = TaskElev.Setups[(int)SelectedElev].MagLevelCount[(int)SelectedMag];
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
            }

        _Error:
            Enabled = true;
        }

        private void lbl_PusherType_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", PusherType", ref TaskElev.Setups[(int)SelectedElev].PusherType, TaskElev.EPusherType.Disable);
            UpdateDisplay();
        }
        private void lbl_PusherExtDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", PusherExtDelay", ref TaskElev.Setups[(int)SelectedElev].PusherExtDelay, 0, 5000);
            UpdateDisplay();
        }
        private void lbl_PusherRetDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", PusherRetDelay", ref TaskElev.Setups[(int)SelectedElev].PusherRetDelay, 0, 5000);
            UpdateDisplay();
        }
        private void lbl_PusherTimeout_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", PusherTimeout", ref TaskElev.Setups[(int)SelectedElev].PusherTimeout, 0, 5000);
            UpdateDisplay();
        }
        private void lbl_PusherRetry_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", PusherRetry", ref TaskElev.Setups[(int)SelectedElev].PusherRetry, 0, 50);
            UpdateDisplay();
        }
        private void lbl_EnableDoorSens_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", EnableDoorSens", ref TaskElev.Setups[(int)SelectedElev].EnableDoorSens, TaskElev.EDoorSens.None);

            if (TaskDisp.Preference == TaskDisp.EPreference.Lumileds)
            {
                if (TaskElev.Setups[(int)SelectedElev].EnableDoorSens == (int)TaskElev.EDoorSens.None)
                {
                    TaskElev.Setups[(int)SelectedElev].EnableDoorSens = (int)TaskElev.EDoorSens.ForceStop;
                }
            }
            UpdateDisplay();
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            if (SelectedElev == TaskElev.TElevator.Left)
            {
                #region Left
                {
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.ELEV_LEFT_INIT_ACCESS, "", EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                    switch (MsgRes)
                    {
                        case EMsgRes.smrOK: { }; break;
                        default: return;
                    }
                }
                Enabled = false;
                try
                {
                    TaskElev.Left.Init();
                }
                catch (Exception Ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK_Cancel, false);
                }
                Enabled = true;
                #endregion
            }
            else
            {
                #region Right
                {
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.ELEV_RIGHT_INIT_ACCESS, "", EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                    switch (MsgRes)
                    {
                        case EMsgRes.smrOK: { }; break;
                        default: return;
                    }
                }
                Enabled = false;
                try
                {
                    TaskElev.Right.Init();
                }
                catch (Exception Ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK_Cancel, false);
                }
                Enabled = true;
                #endregion
            }
        }
        private void btn_MeasureJog_Click(object sender, EventArgs e)
        {
            MeasureD = !MeasureD;
            if (MeasureD)
            {
                if (SelectedElev == TaskElev.TElevator.Left)
                    LZRefPos = TaskElev.Left.Pos;
                else //SelectedElev == TElevator.Right
                    RZRefPos = TaskElev.Right.Pos;
            }
            UpdateDisplay();
        }
        private void btn_Step_Click(object sender, EventArgs e)
        {
            b_Step = !b_Step;
            UpdateDisplay();
        }
        private void btn_Speed_Click(object sender, EventArgs e)
        {
            if (Speed == 2)
            {
                Speed = 0;
            }
            else
            {
                Speed++;
            }

            UpdateSpeed();
        }

        private bool CheckLimit(ZEC3002.Ctrl.TMotorPara MotorPara, double Pos, bool PosDir)
        {
            if (PosDir)
            {
                if (Pos >= MotorPara.SLimit.P)
                {
                    TaskElev.ElevStatus[(int)TaskElev.TElevator.Left] = TaskElev.EElevStatus.ErrorInit;
                    TaskElev.ElevStatus[(int)TaskElev.TElevator.Right] = TaskElev.EElevStatus.ErrorInit;

                    Msg MsgBox = new Msg();
                    MsgBox.Show("Out Of Positive Software Limit");

                    return false;
                }
            }
            else
            {
                if (Pos <= MotorPara.SLimit.N)
                {
                    TaskElev.ElevStatus[(int)TaskElev.TElevator.Left] = TaskElev.EElevStatus.ErrorInit;
                    TaskElev.ElevStatus[(int)TaskElev.TElevator.Right] = TaskElev.EElevStatus.ErrorInit;

                    Msg MsgBox = new Msg();
                    MsgBox.Show("Out Of Negative Software Limit");

                    return false;
                }
            }

            return true;
        }
        private void JogAxisStart(ZEC3002.Ctrl.TAxis Axis, bool PosDir, ZEC3002.Ctrl.TJogPara JogPara)
        {
            if (MotionBusy) { return; }
            MotionBusy = true;

            if (!TaskElev.SetMotionParam(ref Axis, 1, JogPara.Sel, 100)) return;

            if (PosDir)
            {
                TaskElev.JogP(Axis);
            }
            else
            {
                TaskElev.JogN(Axis);
            }
        }
        private void JogAxisStop(ZEC3002.Ctrl.TAxis Axis)
        {
            TaskElev.ForceStop(Axis);
            TaskElev.SetMotionParam(ref Axis, Axis.MotorPara.StartV, Axis.MotorPara.FastV, Axis.MotorPara.Accel);
            MotionBusy = false;
            UpdateDisplay();
        }
        private void StepMove(ZEC3002.Ctrl.TAxis Axis, bool PosDir, ZEC3002.Ctrl.TJogPara JogPara)
        {
            if (MotionBusy) { return; }
            MotionBusy = true;

            TaskElev.SetMotionParam(ref Axis, 1, JogPara.Sel, 100);
            if (PosDir)
            {
                TaskElev.MoveRel(Axis, StepDist);
            }
            else
            {
                TaskElev.MoveRel(Axis, (StepDist * -1));
            }
            TaskElev.SetMotionParam(ref Axis, Axis.MotorPara.StartV, Axis.MotorPara.FastV, Axis.MotorPara.Accel);
            MotionBusy = false;
            UpdateDisplay();
        }

        private void btn_OEZP_MouseDown(object sender, MouseEventArgs e)
        {
            if (!b_Step)
            {
                if (e.Button != MouseButtons.Left) { return; }
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    if (!CheckLimit(ElevIO.LZAxis.MotorPara, TaskElev.Left.Pos, false)) { return; }
                    if (!TaskElev.Left.SafetyCheck_ElevMove()) { return; }
                    JogAxisStart(ElevIO.LZAxis, true, ElevIO.LZAxis.MotorPara.Jog);
                }
                if (SelectedElev == TaskElev.TElevator.Right)
                {
                    if (!CheckLimit(ElevIO.RZAxis.MotorPara, TaskElev.Right.Pos, false)) { return; }
                    if (!TaskElev.Right.SafeCheck_ElevMove()) { return; }
                    JogAxisStart(ElevIO.RZAxis, true, ElevIO.RZAxis.MotorPara.Jog);
                }
            }
            else
            {
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    StepMove(ElevIO.LZAxis, true, ElevIO.LZAxis.MotorPara.Jog);
                }
                if (SelectedElev == TaskElev.TElevator.Right)
                {
                    StepMove(ElevIO.RZAxis, true, ElevIO.RZAxis.MotorPara.Jog);
                }
            }
        }
        private void btn_OEZP_MouseUp(object sender, MouseEventArgs e)
        {
            if (!b_Step)
            {
                if (e.Button != MouseButtons.Left) { return; }
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    JogAxisStop(ElevIO.LZAxis);
                    if (!CheckLimit(ElevIO.LZAxis.MotorPara, TaskElev.Left.Pos, false)) { return; }
                }
                if (SelectedElev == TaskElev.TElevator.Right)
                {
                    JogAxisStop(ElevIO.RZAxis);
                    if (!CheckLimit(ElevIO.RZAxis.MotorPara, TaskElev.Right.Pos, false)) { return; }
                }
            }
        }
        bool bMouseDn = false;
        private void btn_OEZN_MouseDown(object sender, MouseEventArgs e)
        {
            bMouseDn = true;

            if (!b_Step)
            {
                if (e.Button != MouseButtons.Left) { return; }
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    if (!CheckLimit(ElevIO.LZAxis.MotorPara, TaskElev.Left.Pos, false)) { return; }
                    if (!TaskElev.Left.SafetyCheck_ElevMove(false)) { return; }
                    if (!bMouseDn) return;
                    JogAxisStart(ElevIO.LZAxis, false, ElevIO.LZAxis.MotorPara.Jog);
                }
                if (SelectedElev == TaskElev.TElevator.Right)
                {
                    if (!CheckLimit(ElevIO.RZAxis.MotorPara, TaskElev.Right.Pos, false)) { return; }
                    if (!TaskElev.Right.SafeCheck_ElevMove(false)) { return; }
                    if (!bMouseDn) return;
                    JogAxisStart(ElevIO.RZAxis, false, ElevIO.RZAxis.MotorPara.Jog);
                }
            }
            else
            {
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    StepMove(ElevIO.LZAxis, false, ElevIO.LZAxis.MotorPara.Jog);
                }
                if (SelectedElev == TaskElev.TElevator.Right)
                {
                    StepMove(ElevIO.RZAxis, false, ElevIO.RZAxis.MotorPara.Jog);
                }
            }
        }
        private void btn_OEZN_MouseUp(object sender, MouseEventArgs e)
        {
            bMouseDn = false;

            if (!b_Step)
            {
                if (e.Button != MouseButtons.Left) { return; }
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    JogAxisStop(ElevIO.LZAxis);
                    if (!CheckLimit(ElevIO.LZAxis.MotorPara, TaskElev.Left.Pos, false)) { return; }
                }
                if (SelectedElev == TaskElev.TElevator.Right)
                {
                    JogAxisStop(ElevIO.RZAxis);
                    if (!CheckLimit(ElevIO.RZAxis.MotorPara, TaskElev.Right.Pos, false)) { return; }
                }
            }
        }

        private void btn_PusherRet_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    if (!TaskElev.Left.PusherRet()) { goto _Error; }
                }

                //if (SelectedAxis == TaskElev.TElevator.Right)
                //{
                //    if (!TaskElev.Right.PusherRet()) { goto _Error; }
                //}
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
            }
        _Error:
            Enabled = true;
        }
        private void btn_PusherExt_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                if (SelectedElev == TaskElev.TElevator.Left)
                {
                    //if (!TaskElev.Left.PusherExt()) { goto _Error; }
                    switch (TaskElev.Left.PusherExt())
                    {
                        default: break;
                        case TaskElev.Left.EMethodResult.Error: goto _Error;
                    }
                }                
            }
            catch (Exception Ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.ELEV_EX_ERR, Ex.Message, EMcState.Error, EMsgBtn.smbOK, false);
            }
        _Error:
            Enabled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TaskElev.SaveRecipe();
            UpdateDisplay();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                TaskElev.OpenBoard(ElevIO.BoardID);
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());
            }
        }

        private void lbl_Step_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", StepDist", ref StepDist, 0.001, 5);
            UpdateDisplay();
        }

        private void btn_Rev_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Rev_Fast();
            }
            catch
            {
                TaskConv.Conv.Stop();
            }
        }

        private void btn_Rev_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Stop();
            }
            catch
            {
            }
        }

        private void btn_RevSlow_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Rev_Slow();
            }
            catch
            {
                TaskConv.Conv.Stop();
            }
        }

        private void btn_RevSlow_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Stop();
            }
            catch
            {
            }
        }            

        private void btn_FwdSlow_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Fwd_Slow();
            }
            catch
            {
                TaskConv.Conv.Stop();
            }
        }

        private void btn_FwdSlow_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Stop();
            }
            catch
            {
            }
        }

        private void btn_Fwd_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Fwd_Fast();
            }
            catch
            {
                TaskConv.Conv.Stop();
            }
        }

        private void btn_Fwd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Stop();
            }
            catch
            {
            }
        }

        ToolTip toolTip = new ToolTip();
        private void lbl_EnableDoorSens_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(
                "0 : None." + (char)10 + 
                "1 : Enable - Allow Bypass." + (char)10 +
                "2 : ForceStop - Immediately Stop Elevator."
                , (Label)sender);
        }

        private void lbl_RunConveyor_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(SelectedElev.ToString() + ", RunConveyor", ref TaskElev.Setups[(int)SelectedElev].PusherRunConv);
            UpdateDisplay();
        }
    }
}
