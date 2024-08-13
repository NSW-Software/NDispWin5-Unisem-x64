using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CControl;
using MsgBox2;

namespace DispCore
{
    internal partial class frm_DispCore_JogGantry : Form
    {
        public enum EForceGantryMode { None, XYZ, X2Y2Z2 };
        public EForceGantryMode ForceGantryMode = EForceGantryMode.None;

        enum EGantryMode { XYZ, X2Y2Z2 };
        EGantryMode GantryMode = EGantryMode.XYZ;

        double XM = 0;
        double XP = 0;
        double YM = 0;
        double YP = 0;
        bool Support = false;
        double XRange = 0;
        double YRange = 0;

        bool b_EnableLaser = false;

        public frm_DispCore_JogGantry()
        {
            InitializeComponent();

            Button SpeedSlow = new Button(); SpeedSlow.AccessibleDescription = "Slow"; SpeedSlow.Visible = false; this.Controls.Add(SpeedSlow);
            Button SpeedMed = new Button(); SpeedMed.AccessibleDescription = "Med"; SpeedMed.Visible = false; this.Controls.Add(SpeedMed);
            Button SpeedFast = new Button(); SpeedFast.AccessibleDescription = "Fast"; SpeedFast.Visible = false; this.Controls.Add(SpeedFast);

            TopMost = true;
            StartPosition = FormStartPosition.CenterParent;

            Support = TaskGantry.GetWorkArea(ref XM, ref XP, ref YM, ref YP);
            if (!Support) return;

            XRange = XP - XM;
            YRange = YP - YM;

            btn_Speed.AccessibleDescription = "Slow";
            AppLanguage.Func.SetComponent(this);
        }
        private void frmJog_Load(object sender, EventArgs e)
        {
            btn_GantryMode.Visible = (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2);

            tmr_Display.Enabled = true;
            UpdateSpeed();

            b_EnableLaser = false;
        }
        private void frmJog_Shown(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
        private void frmJog_FormClosed(object sender, FormClosedEventArgs e)
        {
            MotionBusy = false;
            tmr_Display.Enabled = false;
        }
        private void frmJog_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private bool MotionBusy = false;
        private double XRefPos, YRefPos, ZRefPos, X2RefPos, Y2RefPos, Z2RefPos;
        private double XRRefPos, YRRefPos, ZRRefPos, X2RRefPos, Y2RRefPos, Z2RRefPos;
        private enum ESpeed { Slow, Med, Fast };
        ESpeed Speed = ESpeed.Slow;
        bool LockZ = true;

        double XPos = 0;
        double YPos = 0;
        private void UpdateDisplay()
        {
            if (!Visible) return;


            if (ForceGantryMode == EForceGantryMode.XYZ)
            {
                GantryMode = EGantryMode.XYZ;
                btn_GantryMode.Enabled = false;
            }
            else
            if (ForceGantryMode == EForceGantryMode.X2Y2Z2)
            {
                GantryMode = EGantryMode.X2Y2Z2;
                btn_GantryMode.Enabled = false;
            }
            else//ForceGantryMode == EForceGantryMode.None
                btn_GantryMode.Enabled = true;
            //(ForceGantryMode == EForceGantryMode.None);

            UpdateModeDisplay();

            #region update position display
            double XA = 0; double YA = 0; double ZA = 0;
            double XR = 0; double YR = 0; double ZR = 0; double DR = 0;
            try
            {
                if (GantryMode == EGantryMode.X2Y2Z2)
                {
                    if (b_RealPos)
                    {
                        XA = TaskGantry.GX2RPos();
                        YA = TaskGantry.GY2RPos();
                        ZA = TaskGantry.GZ2RPos();
                    }
                    else
                    {
                        XA = TaskGantry.GX2Pos();
                        YA = TaskGantry.GY2Pos();
                        ZA = TaskGantry.GZ2Pos();
                    }
                }
                else
                {
                    if (b_RealPos)
                    {
                        XA = TaskGantry.GXRPos();
                        YA = TaskGantry.GYRPos();
                        ZA = TaskGantry.GZRPos();
                    }
                    else
                    {
                        XA = TaskGantry.GXPos();
                        YA = TaskGantry.GYPos();
                        ZA = TaskGantry.GZPos();
                    } 
                    XPos = XA;
                    YPos = YA;
                }
            }
            catch { };
            
            if (GantryMode == EGantryMode.X2Y2Z2)
            {
                lbl_PosX.Text = "X2=" + XA.ToString("F3");
                lbl_PosY.Text = "Y2=" + YA.ToString("F3");
                lbl_PosZ.Text = "Z2=" + ZA.ToString("F3");
            }
            else
            {
                lbl_PosX.Text = "X=" + XA.ToString("F3");
                lbl_PosY.Text = "Y=" + YA.ToString("F3");
                lbl_PosZ.Text = "Z=" + ZA.ToString("F3");
            }

            if (GantryMode == EGantryMode.X2Y2Z2)
            {
                if (b_RealPos)
                {
                    XR = XA - X2RRefPos;
                    YR = YA - Y2RRefPos;
                    ZR = ZA - Z2RRefPos;
                }
                else
                {
                    XR = XA - X2RefPos;
                    YR = YA - Y2RefPos;
                    ZR = ZA - Z2RefPos;
                }
                DR = Math.Sqrt(Math.Pow(XR,2) + Math.Pow(YR,2));
            }
            else
            {
                if (b_RealPos)
                {
                    XR = XA - XRRefPos;
                    YR = YA - YRRefPos;
                    ZR = ZA - ZRRefPos;
                }
                else
                {
                    XR = XA - XRefPos;
                    YR = YA - YRefPos;
                    ZR = ZA - ZRefPos;
                }
                DR = Math.Sqrt(Math.Pow(XR,2) + Math.Pow(YR,2));
            }

            if (GantryMode == EGantryMode.X2Y2Z2)
            {
                lbl_MPosX.Text = "X2=" + XR.ToString("F3");
                lbl_MPosY.Text = "Y2=" + YR.ToString("F3");
                lbl_MPosZ.Text = "Z2=" + ZR.ToString("F3");
                lbl_MPosD.Text = "D=" + DR.ToString("F3");
            }
            else
            {
                lbl_MPosX.Text = "X=" + XR.ToString("F3");
                lbl_MPosY.Text = "Y=" + YR.ToString("F3");
                lbl_MPosZ.Text = "Z=" + ZR.ToString("F3");
                lbl_MPosD.Text = "D=" + DR.ToString("F3");
            }
            #endregion

            if (b_RealPos)
                btn_RealLogical.Text = "R";
            else
                btn_RealLogical.Text = "L";

            #region update speed display
            switch (Speed)
            {
                case ESpeed.Slow: 
                    btn_Speed.AccessibleDescription = "Slow";
                    break;
                case ESpeed.Med: 
                    btn_Speed.AccessibleDescription = "Med";
                    break;
                case ESpeed.Fast: 
                    btn_Speed.AccessibleDescription = "Fast";
                    break;
            }
            #endregion

            lbl_JogStep.Text = d_JogStep.ToString("F3");

            btn_ZP.Enabled = !LockZ;
            btn_ZN.Enabled = !LockZ;

            if (b_EnablePointJog)
                pnl_Jog.BackColor = Color.Lime;
            else
                pnl_Jog.BackColor = this.BackColor;

            if (Support) pnl_Jog.Refresh();
            pnl_Jog.Visible = Support;

            if (b_EnableLaser)
                btn_Laser.BackColor = Color.Lime;
            else
                btn_Laser.BackColor = this.BackColor;

            btn_Laser.Visible = GDefine.HSensorType > 0;// (GDefine.HSensorType == GDefine.EHeightSensorType.IDL1302 || GDefine.HSensorType == GDefine.EHeightSensorType.IDL1700);
            lbl_Laser.Visible = b_EnableLaser;
        }
        private void UpdateSpeed()
        {
            //b_JogStep = false;
            //switch (Speed)
            //{
            //    case ESpeed.Med:
            //        btn_SpeedD.Text = "MED";
            //        TaskGantry.GXAxis.Para.Jog.Sel = TaskGantry.GXAxis.Para.Jog.MedV;
            //        TaskGantry.GYAxis.Para.Jog.Sel = TaskGantry.GYAxis.Para.Jog.MedV;
            //        TaskGantry.GZAxis.Para.Jog.Sel = TaskGantry.GZAxis.Para.Jog.MedV;
            //        //if (GantryMode == EGantryMode.X2Y2Z2)
            //        //{
            //            TaskGantry.GX2Axis.Para.Jog.Sel = TaskGantry.GX2Axis.Para.Jog.MedV;
            //            TaskGantry.GY2Axis.Para.Jog.Sel = TaskGantry.GY2Axis.Para.Jog.MedV;
            //            TaskGantry.GZ2Axis.Para.Jog.Sel = TaskGantry.GZ2Axis.Para.Jog.MedV;
            //        //}
            //        break;
            //    case ESpeed.Fast:
            //        btn_SpeedD.Text = "FAST";
            //        TaskGantry.GXAxis.Para.Jog.Sel = TaskGantry.GXAxis.Para.Jog.FastV;
            //        TaskGantry.GYAxis.Para.Jog.Sel = TaskGantry.GYAxis.Para.Jog.FastV;
            //        TaskGantry.GZAxis.Para.Jog.Sel = TaskGantry.GZAxis.Para.Jog.FastV;
            //        //if (GantryMode == EGantryMode.X2Y2Z2)
            //        //{
            //            TaskGantry.GX2Axis.Para.Jog.Sel = TaskGantry.GX2Axis.Para.Jog.FastV;
            //            TaskGantry.GY2Axis.Para.Jog.Sel = TaskGantry.GY2Axis.Para.Jog.FastV;
            //            TaskGantry.GZ2Axis.Para.Jog.Sel = TaskGantry.GZ2Axis.Para.Jog.FastV;
            //        //}
            //        break;
            //    default:
            //        btn_SpeedD.Text = "SLOW";
            //        TaskGantry.GXAxis.Para.Jog.Sel = TaskGantry.GXAxis.Para.Jog.SlowV;
            //        TaskGantry.GYAxis.Para.Jog.Sel = TaskGantry.GYAxis.Para.Jog.SlowV;
            //        TaskGantry.GZAxis.Para.Jog.Sel = TaskGantry.GZAxis.Para.Jog.SlowV;
            //        //if (GantryMode == EGantryMode.X2Y2Z2)
            //        //{
            //            TaskGantry.GX2Axis.Para.Jog.Sel = TaskGantry.GX2Axis.Para.Jog.SlowV;
            //            TaskGantry.GY2Axis.Para.Jog.Sel = TaskGantry.GY2Axis.Para.Jog.SlowV;
            //            TaskGantry.GZ2Axis.Para.Jog.Sel = TaskGantry.GZ2Axis.Para.Jog.SlowV;
            //        //}
            //        break;
            //}
        }
        //private bool CheckLimit(Common.TAxisPara Para, double Pos, bool PosDir)
        //{
        //    if (PosDir)
        //    {
        //        if (Pos >= Para.SwLimit.PosP)
        //        {
        //            GDefine.Status = EStatus.ErrorInit;
        //            frm_DispCore_Msg.Page.ShowMsg("Out of Positive Software Limit", frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK);
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        if (Pos <= Para.SwLimit.PosN)
        //        {
        //            GDefine.Status = EStatus.ErrorInit;
        //            frm_DispCore_Msg.Page.ShowMsg("Out of Negative Software Limit", frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK);
        //            return false;
        //        }
        //    }

        //    return true;
        //}
        private bool CheckLimit(Common.TAxis Axis, bool PosDir)
        {
            if (PosDir)
            {
                if (TaskGantry.SLmtP(Axis))
                {
                    Msg MsgBox = new Msg();
                    //if (Axis.Device.ID == 0)
                    //{
                    //    if (Axis.Name == "GX") MsgBox.Show(ErrCode.GX_SOFTWARE_P_LIMIT);
                    //    if (Axis.Name == "GY") MsgBox.Show(ErrCode.GY_SOFTWARE_P_LIMIT);
                    //    if (Axis.Name == "GZ") MsgBox.Show(ErrCode.GZ_SOFTWARE_P_LIMIT);
                    //}
                    //if (Axis.Device.ID == 1)
                    //{
                    //    if (Axis.Name == "GX2") MsgBox.Show(ErrCode.GX2_SOFTWARE_P_LIMIT);
                    //    if (Axis.Name == "GY2") MsgBox.Show(ErrCode.GY2_SOFTWARE_P_LIMIT);
                    //    if (Axis.Name == "GZ2") MsgBox.Show(ErrCode.GZ2_SOFTWARE_P_LIMIT);
                    //}

                    MsgBox.Show(ErrCode.SOFTWARE_P_LIMIT, Axis.Name);
                    return false;
                }
            }
            else
            {
                if (TaskGantry.SLmtN(Axis))
                {
                    Msg MsgBox = new Msg();
                    //if (Axis.Device.ID == 0)
                    //{
                    //    if (Axis.Name == "GX") MsgBox.Show(ErrCode.GX_SOFTWARE_N_LIMIT);
                    //    if (Axis.Name == "GY") MsgBox.Show(ErrCode.GY_SOFTWARE_N_LIMIT);
                    //    if (Axis.Name == "GZ") MsgBox.Show(ErrCode.GZ_SOFTWARE_N_LIMIT);
                    //}
                    //if (Axis.Device.ID == 1)
                    //{
                    //    if (Axis.Name == "GX2") MsgBox.Show(ErrCode.GX2_SOFTWARE_N_LIMIT);
                    //    if (Axis.Name == "GY2") MsgBox.Show(ErrCode.GY2_SOFTWARE_N_LIMIT);
                    //    if (Axis.Name == "GZ2") MsgBox.Show(ErrCode.GZ2_SOFTWARE_N_LIMIT);
                    //}
                    MsgBox.Show(ErrCode.SOFTWARE_N_LIMIT, Axis.Name);
                    return false;
                }
            }

            return true;
        }

        private void MoveAxisStep(Common.TAxis Axis, bool PosDir)
        {
            if (!CheckLimit(Axis, PosDir)) return;

            if (MotionBusy) { return; }
            MotionBusy = true;

            CommonControl.SetMotionParam(Axis, 1, Axis.Para.Jog.SlowV, 100);
            if (PosDir)
            {
                try
                {
                    CommonControl.MovePtpRel1(Axis, d_JogStep);
                    while (true)
                    {
                        if (!TaskGantry.AxisBusy(Axis)) break;
                        Thread.Sleep(0);
                    }
                    MotionBusy = false;
                }
                catch { };
            }
            else
            {
                try
                {
                    CommonControl.MovePtpRel1(Axis, -d_JogStep);
                    while (true)
                    {
                        if (!TaskGantry.AxisBusy(Axis)) break;
                        Thread.Sleep(0);
                    }
                    MotionBusy = false;
                }
                catch { };
            }
            MotionBusy = false;
        }
        private void JogAxisStart(Common.TAxis Axis, bool PosDir, Common.TAxisJogPara JogPara)
        {
            if (!CheckLimit(Axis, PosDir)) return;

            MotionBusy = true;

            if (PosDir)
            {
                try
                {
                    CommonControl.JogP(Axis);
                }
                catch { };
            }
            else
            {
                try
                {
                    CommonControl.JogN(Axis);
                }
                catch { };
            }
        }
        private void JogAxisStop(Common.TAxis Axis)
        {
            if (Speed == ESpeed.Slow)
            {
                CommonControl.ForceStop(Axis);
            }
            else
            {
                CommonControl.DecelStop(Axis);
            }
            UpdateDisplay();
            MotionBusy = false;

            if (!CheckLimit(Axis, true)) return;
            if (!CheckLimit(Axis, false)) return;
        }
        private void MeasureReset()
        {
            if (GantryMode == EGantryMode.X2Y2Z2)
            {
                try
                {
                    X2RefPos = TaskGantry.GX2Pos();
                    Y2RefPos = TaskGantry.GY2Pos();
                    Z2RefPos = TaskGantry.GZ2Pos();
                    X2RRefPos = TaskGantry.GX2RPos();
                    Y2RRefPos = TaskGantry.GY2RPos();
                    Z2RRefPos = TaskGantry.GZ2RPos();
                }
                catch { };
            }
            else
            {
                try
                {
                    XRefPos = TaskGantry.GXPos();
                    YRefPos = TaskGantry.GYPos();
                    ZRefPos = TaskGantry.GZPos();
                    XRRefPos = TaskGantry.GXRPos();
                    YRRefPos = TaskGantry.GYRPos();
                    ZRRefPos = TaskGantry.GZRPos();
                }
                catch { };
            }
        }

        private void UpdateModeDisplay()
        {
            if (GantryMode == EGantryMode.XYZ)
            {
                btn_GantryMode.Text = "X,Y,Z";
                ArrowDrawColor = Color.Navy;
                btn_GantryMode.BackColor = this.BackColor;
            }
            //    GantryMode = EGantryMode.X2Y2Z2;
            //    ArrowDrawColor = Color.Maroon;
            //    btn_GantryMode.Text = "X2,Y2,Z2";
            //    btn_GantryMode.BackColor = Color.Maroon;
            //}
            else
            {
                //GantryMode = EGantryMode.XYZ;
                //ArrowDrawColor = Color.Blue;
                //btn_GantryMode.Text = "X,Y,Z";
                //btn_GantryMode.BackColor = this.BackColor;
                //GantryMode = EGantryMode.X2Y2Z2;
                btn_GantryMode.Text = "X2,Y2,Z2";
                ArrowDrawColor = Color.Maroon;
                btn_GantryMode.BackColor = Color.Maroon;
            }
            Refresh();
        }
        private void SwitchMode()
        {
            if (GantryMode == EGantryMode.XYZ)
            {
                GantryMode = EGantryMode.X2Y2Z2;
                //ArrowDrawColor = Color.Maroon;
                //btn_GantryMode.Text = "X2,Y2,Z2";
                //btn_GantryMode.BackColor = Color.Maroon;
            }
            else
            {
                GantryMode = EGantryMode.XYZ;
                //ArrowDrawColor = Color.Blue;
                //btn_GantryMode.Text = "X,Y,Z";
                //btn_GantryMode.BackColor = this.BackColor;
            }
            UpdateModeDisplay();
            //Refresh();
        }

        bool GX2Col = false;
        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) { return; }

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                try
                {
                    double XV = TaskGantry.GXPos() + (TaskGantry.GX2Pos() - TaskDisp.Head2_DefPos.X);
                    if (XV > TaskGantry.GXAxis.Para.SwLimit.PosP)
                    {
                        if (!GX2Col)
                        {
                            GX2Col = true;
                            JogAxisStop(TaskGantry.GXAxis);
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.GX2Y2_COLLISION_POSSIBLE);
                        }
                    }
                    else
                        GX2Col = false;
                }
                catch { };
            }
            UpdateDisplay();
        }

        enum EJogAxis
        {
            None,
            XN, XP,
            YN, YP,
            ZN, ZP,
            X2N, X2P,
            Y2N, Y2P,
            Z2N, Z2P,
        }

        int i_MoveStepWait = 100;
        bool b_MouseDn = false;
        bool b_StepMove = false;
        public void MouseDownEvent(Common.TAxis Axis1, bool Axis1Dir, Common.TAxis Axis2, bool Axis2Dir)
        {
            //if (MotionBusy) return;

            b_MouseDn = true;

            CommonControl.ClearAxisError(Axis1);
            if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
            {
                CommonControl.ClearAxisError(Axis2);
            }

            #region Medium Fast Jog
            if (Speed == ESpeed.Med || Speed == ESpeed.Fast)
            {
                if (Speed == ESpeed.Med)
                {
                    CommonControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.MedV, 1000);
                    if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                    {
                        CommonControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.MedV, 1000);
                    }
                }
                if (Speed == ESpeed.Fast)
                {
                    CommonControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.FastV, 1000);
                    if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                    {
                        CommonControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.FastV, 1000);
                    }
                }

                JogAxisStart(Axis1, Axis1Dir, Axis1.Para.Jog);
                if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                {
                    JogAxisStart(Axis2, Axis2Dir, Axis2.Para.Jog);
                }
                return;
            }
            #endregion

            b_StepMove = true;

            //if (b_StepMove)
            //{
                #region Move Step
                MoveAxisStep(Axis1, Axis1Dir);
                if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                    MoveAxisStep(Axis2, Axis2Dir);
                #endregion
                b_StepMove = false;
                //return;
            //}

            #region Move Step Wait
            int t1 = GDefine.GetTickCount() + i_MoveStepWait;
            while (GDefine.GetTickCount() < t1)
            {
                Thread.Sleep(0);
                //Application.DoEvents();
                if (!b_MouseDn)
                {
                    return;
                }
            }
            #endregion

            //b_StepMove = false;

            #region Slow Jog
            CommonControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.SlowV, 10);
            JogAxisStart(Axis1, Axis1Dir, Axis1.Para.Jog);
            if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
            {
                CommonControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.SlowV, 10);
                JogAxisStart(Axis2, Axis2Dir, Axis2.Para.Jog);
            }
            #endregion
        }
        private void MouseDownEvent(Common.TAxis Axis, bool AxisDir)
        {
            MouseDownEvent(Axis, AxisDir, Axis, AxisDir);
        }
        private void MouseUpEvent(Common.TAxis Axis1, bool Axis1Dir, Common.TAxis Axis2, bool Axis2Dir)
        {
            b_MouseDn = false;

            if (b_StepMove) return;// = true;

            JogAxisStop(Axis1);
            if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                JogAxisStop(Axis2);
        }
        private void MouseUpEvent(Common.TAxis Axis, bool AxisDir)
        {
            MouseUpEvent(Axis, AxisDir, Axis, AxisDir);
        }

        private void btn_XN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GXAxis, false);
            else
                MouseDownEvent(TaskGantry.GX2Axis, false);
        }
        private void btn_XN_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GXAxis, false);
            else
                MouseUpEvent(TaskGantry.GX2Axis, false);
        }
        private void btn_XP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GXAxis, true);
            else
                MouseDownEvent(TaskGantry.GX2Axis, true);
        }
        private void btn_XP_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GXAxis, true);
            else
                MouseUpEvent(TaskGantry.GX2Axis, true);

        }
        private void btn_YN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GYAxis, false);
            else
                MouseDownEvent(TaskGantry.GY2Axis, false);
        }
        private void btn_YN_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GYAxis, false);
            else
                MouseUpEvent(TaskGantry.GY2Axis, false);
        }
        private void btn_YP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GYAxis, true);
            else
                MouseDownEvent(TaskGantry.GY2Axis, true);
        }
        private void btn_YP_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GYAxis, true);
            else
                MouseUpEvent(TaskGantry.GY2Axis, true);
        }
        private void btn_ZN_MouseDown(object sender, MouseEventArgs e)
        {
            if (LockZ) return;

            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GZAxis, false);
            else
                MouseDownEvent(TaskGantry.GZ2Axis, false);
        }
        private void btn_ZN_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GZAxis, false);
            else
                MouseUpEvent(TaskGantry.GZ2Axis, false);
        }
        private void btn_ZP_MouseDown(object sender, MouseEventArgs e)
        {
            if (LockZ) return;

            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GZAxis, true);
            else
                MouseDownEvent(TaskGantry.GZ2Axis, true);
        }
        private void btn_ZP_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GZAxis, true);
            else
                MouseUpEvent(TaskGantry.GZ2Axis, true);
        }
        private void btn_GXNYP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GXAxis, false, TaskGantry.GYAxis, true);
            else
                MouseDownEvent(TaskGantry.GX2Axis, false, TaskGantry.GY2Axis, true);
        }
        private void btn_GXNYP_MouseUp(object sender, MouseEventArgs e)
        {
            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GXAxis, false, TaskGantry.GYAxis, true);
            else
                MouseUpEvent(TaskGantry.GX2Axis, false, TaskGantry.GY2Axis, true);
        }
        private void btn_GXPYP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GXAxis, true, TaskGantry.GYAxis, true);
            else
                MouseDownEvent(TaskGantry.GX2Axis, true, TaskGantry.GY2Axis, true);
        }
        private void btn_GXPYP_MouseUp(object sender, MouseEventArgs e)
        {
            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GXAxis, true, TaskGantry.GYAxis, true);
            else
                MouseUpEvent(TaskGantry.GX2Axis, true, TaskGantry.GY2Axis, true);
        }
        private void btn_GXNYN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GXAxis, false, TaskGantry.GYAxis, false);
            else
                MouseDownEvent(TaskGantry.GX2Axis, false, TaskGantry.GY2Axis, false);
        }
        private void btn_GXNYN_MouseUp(object sender, MouseEventArgs e)
        {
            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GXAxis, false, TaskGantry.GYAxis, false);
            else
                MouseUpEvent(TaskGantry.GX2Axis, false, TaskGantry.GY2Axis, false);
        }
        private void btn_GXPYN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GXAxis, true, TaskGantry.GYAxis, false);
            else
                MouseDownEvent(TaskGantry.GX2Axis, true, TaskGantry.GY2Axis, false);
        }
        private void btn_GXPYN_MouseUp(object sender, MouseEventArgs e)
        {
            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GXAxis, true, TaskGantry.GYAxis, false);
            else
                MouseUpEvent(TaskGantry.GX2Axis,true, TaskGantry.GY2Axis, false);
        }

        private void btn_Speed_Click(object sender, EventArgs e)
        {
            if (Speed >= ESpeed.Fast)
            {
                Speed = ESpeed.Slow;
            }
            else
            {
                Speed++;
            }
            UpdateDisplay();
            AppLanguage.Func.SetComponent(this);
        }

        bool GXBusy, GYBusy, GZBusy, GX2Busy, GY2Busy, GZ2Busy;
        bool ZPressed;
        bool KeyDownBusy;
        bool b_JogStep = false;
        double d_JogStep = 0.010;
        public void frm_Jog_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Visible) { return; }

            if (GantryMode == EGantryMode.XYZ && GXBusy) { return; }
            if (GantryMode == EGantryMode.XYZ && GYBusy) { return; }
            if (GantryMode == EGantryMode.XYZ && GZBusy) { return; }
            if (GantryMode == EGantryMode.X2Y2Z2 && GX2Busy) { return; }
            if (GantryMode == EGantryMode.X2Y2Z2 && GY2Busy) { return; }
            if (GantryMode == EGantryMode.X2Y2Z2 && GZ2Busy) { return; }

            if (KeyDownBusy) { return; }
            KeyDownBusy = true;

            switch (e.KeyCode)
            {
                #region key
                case Keys.R:
                    {
                        MeasureReset();
                        goto _End;
                    }
                case Keys.S:
                    {
                        b_JogStep = !b_JogStep;
                        goto _End;
                    }
                case Keys.X:
                    {
                        SwitchMode();
                        goto _End;
                    }
                #endregion
            }
            #region Check Jog Key
            if ((e.Shift && e.Control) && (e.KeyCode == Keys.Z))
            {
                ZPressed = true;
            }
            if ((e.Control) && (e.KeyCode == Keys.Z))
            {
                ZPressed = true;
            }
            else
                if (e.Shift && e.Control)
                {
                    Speed = ESpeed.Med;
                    UpdateSpeed();
                }
                else
                    if (e.Control)
                    {
                        Speed = ESpeed.Slow;
                        UpdateSpeed();
                    }
                    else
                    {
                        goto _End;
                    }
            #endregion

            #region Move
            if (!ZPressed)
            {
                if (e.KeyCode == Keys.Left)
                {
                    #region
                    if (GantryMode == EGantryMode.X2Y2Z2)
                    {
                        if (!CheckLimit(TaskGantry.GX2Axis, false)) { goto _End; }
                        JogAxisStart(TaskGantry.GX2Axis, false, TaskGantry.GX2Axis.Para.Jog);
                        GX2Busy = true;
                    }
                    else
                    {
                        if (!CheckLimit(TaskGantry.GXAxis, false)) { goto _End; }
                        JogAxisStart(TaskGantry.GXAxis, false, TaskGantry.GXAxis.Para.Jog);
                        GXBusy = true;
                    }
                    #endregion
                }
                else
                    if (e.KeyCode == Keys.Right)
                    {
                        #region
                        if (GantryMode == EGantryMode.X2Y2Z2)
                        {
                            if (!CheckLimit(TaskGantry.GX2Axis, true)) { goto _End; }
                            JogAxisStart(TaskGantry.GX2Axis, true, TaskGantry.GX2Axis.Para.Jog);
                            GX2Busy = true;
                        }
                        else
                        {
                            if (!CheckLimit(TaskGantry.GXAxis, true)) { goto _End; }
                            JogAxisStart(TaskGantry.GXAxis, true, TaskGantry.GXAxis.Para.Jog);
                            GXBusy = true;
                        }
                        #endregion
                    }
                    else
                        if (e.KeyCode == Keys.Down)
                        {
                            #region
                            if (GantryMode == EGantryMode.X2Y2Z2)
                            {
                                if (!CheckLimit(TaskGantry.GY2Axis, false)) { goto _End; }
                                JogAxisStart(TaskGantry.GY2Axis, false, TaskGantry.GY2Axis.Para.Jog);
                                GY2Busy = true;
                            }
                            else
                            {
                                if (!CheckLimit(TaskGantry.GYAxis, false)) { goto _End; }
                                JogAxisStart(TaskGantry.GYAxis, false, TaskGantry.GYAxis.Para.Jog);
                                GYBusy = true;
                            }
                            #endregion
                        }
                        else
                            if (e.KeyCode == Keys.Up)
                            {
                                #region
                                if (GantryMode == EGantryMode.X2Y2Z2)
                                {
                                    if (!CheckLimit(TaskGantry.GY2Axis, true)) { goto _End; }
                                    JogAxisStart(TaskGantry.GY2Axis, true, TaskGantry.GY2Axis.Para.Jog);
                                    GY2Busy = true;
                                }
                                else
                                {
                                    if (!CheckLimit(TaskGantry.GYAxis, true)) { goto _End; }
                                    JogAxisStart(TaskGantry.GYAxis, true, TaskGantry.GYAxis.Para.Jog);
                                    GYBusy = true;
                                }
                                #endregion
                            }
            }
            else
            {
                if (e.KeyCode == Keys.Down)
                {
                    #region
                    if (GantryMode == EGantryMode.X2Y2Z2)
                    {
                        if (!CheckLimit(TaskGantry.GZ2Axis, false)) { goto _End; }
                        JogAxisStart(TaskGantry.GZ2Axis, false, TaskGantry.GZ2Axis.Para.Jog);
                        GZ2Busy = true;
                    }
                    else
                    {
                        if (!CheckLimit(TaskGantry.GZAxis, false)) { goto _End; }
                        JogAxisStart(TaskGantry.GZAxis, false, TaskGantry.GZAxis.Para.Jog);
                        GZBusy = true;
                    }
                    #endregion
                }
                else
                    if (e.KeyCode == Keys.Up)
                    {
                        #region
                        if (GantryMode == EGantryMode.X2Y2Z2)
                        {
                            if (!CheckLimit(TaskGantry.GZ2Axis, true)) { goto _End; }
                            JogAxisStart(TaskGantry.GZ2Axis, true, TaskGantry.GZ2Axis.Para.Jog);
                            GZ2Busy = true;
                        }
                        else
                        {
                            if (!CheckLimit(TaskGantry.GZAxis, true)) { goto _End; }
                            JogAxisStart(TaskGantry.GZAxis, true, TaskGantry.GZAxis.Para.Jog);
                            GZBusy = true;
                        }
                        #endregion
                    }
            }
            #endregion

            KeyDownBusy = false;
            return;

        _End:
            UpdateDisplay();
            KeyDownBusy = false;
        }
        public void frm_Jog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Control)
            {
                Speed = ESpeed.Med;
                UpdateSpeed();
            }
            else
                if (e.Control)
                {
                    Speed = ESpeed.Slow;
                    UpdateSpeed();
                }
                else
                {
                    goto _End;
                }

            if (GXBusy)
            {
                JogAxisStop(TaskGantry.GXAxis);
                CheckLimit(TaskGantry.GXAxis, false);
                CheckLimit(TaskGantry.GXAxis, true);
                GXBusy = false;
            }
            if (GYBusy)
            {
                JogAxisStop(TaskGantry.GYAxis);
                CheckLimit(TaskGantry.GYAxis, false);
                CheckLimit(TaskGantry.GYAxis, true);
                GYBusy = false;
            }
            if (GZBusy)
            {
                JogAxisStop(TaskGantry.GZAxis);
                CheckLimit(TaskGantry.GZAxis, false);
                CheckLimit(TaskGantry.GZAxis, true);
                GZBusy = false;
            }

            Speed = ESpeed.Slow;
//            UpdateSpeed();
            Enabled = true;
            if (e.KeyCode == Keys.Z)
            {
                ZPressed = false;
            }

        _End:
            UpdateDisplay();
        }

        private void lbl_JogStep_Click(object sender, EventArgs e)
        {
            double d_Min = TaskGantry.GXAxis.Para.Unit.Resolution;
            double d_Max = d_Min * 50;
            double d = d_JogStep;

            GDefine.uc.UserAdjustExecute("Jog Step", ref d, d_Min, d_Max);

            d_JogStep = d;
            UpdateDisplay();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            MeasureReset();
            UpdateDisplay();
        }

        private void btn_XYZMode_Click(object sender, EventArgs e)
        {
            SwitchMode();
            UpdateDisplay();
        }

        bool b_EnablePointJog = false;
        private void pnl_Jog_MouseDown(object sender, MouseEventArgs e)
        {
            if (!b_EnablePointJog) return;
            if (!Support) return;

            if (e.Button == MouseButtons.Left)
            {
                Point ptMouse = pnl_Jog.PointToClient(Control.MousePosition);

                double d_x_ratio = (double)ptMouse.X / pnl_Jog.Width;
                double d_y_ratio = 0;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                d_y_ratio = (double)(ptMouse.Y) / pnl_Jog.Height;
                else
                d_y_ratio = (double)(pnl_Jog.Height - ptMouse.Y) / pnl_Jog.Height;

                double mX = (XRange * d_x_ratio) + XM;
                double mY = (YRange * d_y_ratio) + YM;

                try
                {
                    //if (!TaskGantry.SetMotionParamGZZ2()) return;
                    //if (!TaskGantry.MoveAbsGZZ2(0)) return;
                    if (!TaskDisp.TaskMoveGZZ2Up()) return;

                    if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                    {
                        if (!TaskGantry.SetMotionParamGX2Y2()) return;
                        if (!TaskGantry.MoveAbsGX2Y2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y)) return;
                    }

                    if (!TaskGantry.SetMotionParamGXY()) return;
                    if (!TaskGantry.MoveAbsGXY(mX, mY)) return;

                    b_EnablePointJog = false;
                }
                catch { };
            }
        }

        private void pnl_Jog_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                int X = (int)((double)(XPos - XM) / XRange * pnl_Jog.Width);
                int Y = (int)((double)(YPos - YM) / YRange * pnl_Jog.Height);
                if (GDefine.GantryConfig != GDefine.EGantryConfig.XZ_YTABLE) Y = pnl_Jog.Height - Y;

                Pen P = new Pen(Color.Black, 1);
                e.Graphics.DrawLine(P, new Point(0, Y), new Point(pnl_Jog.Width, Y));
                e.Graphics.DrawLine(P, new Point(X, 0), new Point(X, pnl_Jog.Height));

                e.Graphics.DrawRectangle(P, new Rectangle(X - 5, Y - 5, 10, 10));
            }
            catch { };
        }

        Color ArrowDrawColor = Color.Navy;
        private void btn_YP_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled) P.Color = Color.Gray;

            int S = (int)((double)btn_YP.Width * 0.25);
            int CX = btn_YP.Width / 2;
            int CY = btn_YP.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX, CY - S);
            Points[1] = new Point(CX + S, CY + S);
            Points[2] = new Point(CX - S, CY + S);
            Points[3] = new Point(CX, CY - S);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            e.Graphics.DrawLines(P, Points);
        }
        private void btn_XN_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled) P.Color = Color.Gray;

            int S = (int)((double)btn_YN.Width * 0.25);
            int CX = btn_YN.Width / 2;
            int CY = btn_YN.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX - S, CY);
            Points[1] = new Point(CX + S, CY + S);
            Points[2] = new Point(CX + S, CY - S);
            Points[3] = new Point(CX - S, CY);
            e.Graphics.DrawLines(P, Points);
        }
        private void btn_XP_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled) P.Color = Color.Gray;

            int S = (int)((double)btn_YN.Width * 0.25);
            int CX = btn_YN.Width / 2;
            int CY = btn_YN.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX + S, CY);
            Points[1] = new Point(CX - S, CY + S);
            Points[2] = new Point(CX - S, CY - S);
            Points[3] = new Point(CX + S, CY);
            e.Graphics.DrawLines(P, Points);
        }
        private void btn_YN_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled) P.Color = Color.Gray;

            int S = (int)((double)btn_YN.Width * 0.25);
            int CX = btn_YN.Width / 2;
            int CY = btn_YN.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX, CY + S);
            Points[1] = new Point(CX + S, CY - S);
            Points[2] = new Point(CX - S, CY - S);
            Points[3] = new Point(CX, CY + S);
            e.Graphics.DrawLines(P, Points);
        }
        private void btn_GXNYP_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled) P.Color = Color.Gray;

            int S = (int)((double)btn_GXNYP.Width * 0.25);
            int CX = btn_GXNYP.Width / 2;
            int CY = btn_GXNYP.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX - S, CY - S);
            Points[1] = new Point(CX + S, CY);
            Points[2] = new Point(CX, CY + S);
            Points[3] = new Point(CX - S, CY - S);
            e.Graphics.DrawLines(P, Points);
        }
        private void btn_GXPYP_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled) P.Color = Color.Gray;

            int S = (int)((double)btn_GXNYP.Width * 0.25);
            int CX = btn_GXNYP.Width / 2;
            int CY = btn_GXNYP.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX + S, CY - S);
            Points[1] = new Point(CX - S, CY);
            Points[2] = new Point(CX, CY + S);
            Points[3] = new Point(CX + S, CY - S);
            e.Graphics.DrawLines(P, Points);
        }
        private void btn_GXNYN_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled) P.Color = Color.Gray;

            int S = (int)((double)btn_GXNYP.Width * 0.25);
            int CX = btn_GXNYP.Width / 2;
            int CY = btn_GXNYP.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX - S, CY + S);
            Points[1] = new Point(CX + S, CY);
            Points[2] = new Point(CX, CY - S);
            Points[3] = new Point(CX - S, CY + S);
            e.Graphics.DrawLines(P, Points);
        }
        private void btn_GXPYN_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled) P.Color = Color.Gray;

            int S = (int)((double)btn_GXNYP.Width * 0.25);
            int CX = btn_GXNYP.Width / 2;
            int CY = btn_GXNYP.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX + S, CY + S);
            Points[1] = new Point(CX - S, CY);
            Points[2] = new Point(CX, CY - S);
            Points[3] = new Point(CX + S, CY + S);
            e.Graphics.DrawLines(P, Points);
        }

        private void btn_ZP_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled || LockZ) P.Color = Color.Gray;

            int S = (int)((double)btn_YP.Width * 0.25);
            int CX = btn_YP.Width / 2;
            int CY = btn_YP.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX, CY - S);
            Points[1] = new Point(CX + S, CY + S - 5);
            Points[2] = new Point(CX - S, CY + S - 5);
            Points[3] = new Point(CX, CY - S);
            e.Graphics.DrawLines(P, Points);
            e.Graphics.DrawLine(P, new Point(CX + S, CY + S), new Point(CX - S, CY + S)); 
        }
        private void btn_ZN_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);
            if (!this.Enabled || LockZ) P.Color = Color.Gray;

            int S = (int)((double)btn_YN.Width * 0.25);
            int CX = btn_YN.Width / 2;
            int CY = btn_YN.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX, CY + S);
            Points[1] = new Point(CX + S, CY - S + 5);
            Points[2] = new Point(CX - S, CY - S + 5);
            Points[3] = new Point(CX, CY + S);
            e.Graphics.DrawLines(P, Points);
            e.Graphics.DrawLine(P, new Point(CX + S, CY - S), new Point(CX - S, CY - S));
        }

        private void btn_PointJog_Click(object sender, EventArgs e)
        {
            b_EnablePointJog = !b_EnablePointJog;
       }

        private void btn_LockZ_Click(object sender, EventArgs e)
        {
            LockZ = !LockZ;
            Refresh();
        }

        bool b_RealPos = false;
        private void btn_RealLogical_Click(object sender, EventArgs e)
        {
            b_RealPos = !b_RealPos;
        }

        private void btn_Laser_Click(object sender, EventArgs e)
        {
            b_EnableLaser = !b_EnableLaser;
            if (b_EnableLaser) tmr_Laser.Enabled = true;
        }

        bool b_RefPos = false;
        private void tmr_Laser_Tick(object sender, EventArgs e)
        {
            if (!b_EnableLaser) return;

            double d = 0;
            if (TaskLaser.GetHeight(ref d, false))// goto _Err;
            {
                if (!b_RefPos)
                {
                    lbl_Laser.ForeColor = Color.Lime;
                    lbl_Laser.Text = d.ToString("F3");
                }
                else
                {
                    lbl_Laser.ForeColor = Color.Orange;
                    lbl_Laser.Text = (d - TaskDisp.Laser_RefPosZ).ToString("F3");
                }
            }
            else
            {
                b_EnableLaser = false;
                lbl_Laser.ForeColor = Color.Red;
                lbl_Laser.Text = "Err";
            }
        }

        private void lbl_Laser_Click(object sender, EventArgs e)
        {
            b_RefPos = !b_RefPos;
        }
    }
}



