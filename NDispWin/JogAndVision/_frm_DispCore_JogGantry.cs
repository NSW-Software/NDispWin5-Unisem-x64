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

        public frm_DispCore_JogGantry()
        {
            InitializeComponent();
            TopMost = true;
            StartPosition = FormStartPosition.CenterParent;

            Support = TaskGantry.GetWorkArea(ref XM, ref XP, ref YM, ref YP);
            if (!Support) return;

            XRange = XP - XM;
            YRange = YP - YM;
        }
        private void frmJog_Load(object sender, EventArgs e)
        {
            tmr_Display.Enabled = true;
            UpdateSpeed();
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
        private enum ESpeed { Slow, Med, Fast };
        ESpeed Speed = ESpeed.Slow;
        bool LockZ = true;

        double XPos = 0;
        double YPos = 0;
        private void UpdateDisplay()
        {
            if (!Visible) return;

            btn_GantryMode.Visible = (GDefine.GantryConfig == GDefine.EGantryConfigType.XY_ZX2Y2_Z2);

            if (ForceGantryMode == EForceGantryMode.XYZ)
            {
                GantryMode = EGantryMode.XYZ;
                btn_GantryMode.Enabled = true;
            }
            if (ForceGantryMode == EForceGantryMode.X2Y2Z2)
            {
                GantryMode = EGantryMode.X2Y2Z2;
                btn_GantryMode.Enabled = true;
            }
            btn_GantryMode.Enabled = (ForceGantryMode == EForceGantryMode.None);

            #region update button text
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    //#region
            //    //btn_GantryMode.Text = "Mode  X2,Y2,Z2";
            //    //btn_XP.Text = "GX2";
            //    //btn_XN.Text = "GX2";
            //    //btn_YP.Text = "GY2";
            //    //btn_YN.Text = "GY2";
            //    //btn_ZP.Text = "GZ2";
            //    //btn_ZN.Text = "GZ2";
            //    //#endregion
            //    ArrowDrawColor = Color.Maroon;
            //    btn_GantryMode.Text = "X2,Y2,Z2";
            //    btn_GantryMode.ForeColor = Color.Maroon;
            //}
            //else
            //{
            //    //#region
            //    //btn_GantryMode.Text = "Mode X,Y,Z";
            //    //btn_XP.Text = "GX";
            //    //btn_XN.Text = "GX";
            //    //btn_YP.Text = "GY";
            //    //btn_YN.Text = "GY";
            //    //btn_ZP.Text = "GZ";
            //    //btn_ZN.Text = "GZ";
            //    //#endregion
            //    ArrowDrawColor = Color.Blue;
            //    btn_GantryMode.Text = "X,Y,Z";
            //    btn_GantryMode.ForeColor = Color.Gray;
            //}
            #endregion

            #region update position display
            double XA = 0; double YA = 0; double ZA = 0;
            double XR = 0; double YR = 0; double ZR = 0; double DR = 0;
            try
            {
                if (GantryMode == EGantryMode.X2Y2Z2)
                {
                    XA = TaskGantry.GX2Pos();
                    YA = TaskGantry.GY2Pos();
                    ZA = TaskGantry.GZ2Pos();
                }
                else
                {
                    XA = TaskGantry.GXPos();
                    YA = TaskGantry.GYPos();
                    ZA = TaskGantry.GZPos();
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
                XR = XA - X2RefPos;
                YR = YA - Y2RefPos;
                ZR = ZA - Z2RefPos;
                DR = Math.Sqrt(Math.Pow(XR,2) + Math.Pow(YR,2));
            }
            else
            {
                XR = XA - XRefPos;
                YR = YA - YRefPos;
                ZR = ZA - ZRefPos;
                DR = Math.Sqrt(Math.Pow(XR,2) + Math.Pow(YR,2));
            }

            if (GantryMode == EGantryMode.X2Y2Z2)
            {
                lbl_MPosX.Text = "X2=" + XR.ToString("F3");
                lbl_MPosY.Text = "Y2=" + YR.ToString("F3");
                lbl_MPosZ.Text = "Z2=" + ZR.ToString("F3");
                lbl_MPosD.Text = "Z2=" + DR.ToString("F3");
            }
            else
            {
                lbl_MPosX.Text = "X=" + XR.ToString("F3");
                lbl_MPosY.Text = "Y=" + YR.ToString("F3");
                lbl_MPosZ.Text = "Z=" + ZR.ToString("F3");
                lbl_MPosD.Text = "D=" + DR.ToString("F3");
            }
            #endregion

            //if (b_JogStep)
            //    btn_JogStep.BackColor = Color.Lime;
            //else
            //    btn_JogStep.BackColor = SystemColors.Control;


            //if (b_FastSpeed)
            //    btn_FastSpeed.BackColor = Color.Lime;
            //else
            //    btn_FastSpeed.BackColor = this.BackColor;//Color.Lime;

            switch (Speed)
            {
                case ESpeed.Slow: btn_Speed.Text = "SLOW"; break;
                case ESpeed.Med: btn_Speed.Text = "MED"; break;
                case ESpeed.Fast: btn_Speed.Text = "FAST"; break;
            }

            lbl_JogStep.Text = d_JogStep.ToString("F3");

            btn_ZP.Enabled = !LockZ;
            btn_ZN.Enabled = !LockZ;

            if (b_EnablePointJog)
                pnl_Jog.BackColor = Color.Lime;
            else
                pnl_Jog.BackColor = this.BackColor;

            if (Support) pnl_Jog.Refresh();
            pnl_Jog.Visible = Support;
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
        private bool CheckLimit(CMC.TAxisPara Para, double Pos, bool PosDir)
        {
            if (PosDir)
            {
                if (Pos >= Para.SwLimit.PosP)
                {
                    GDefine.Status = EStatus.ErrorInit;
                    frm_Msg.Page.ShowMsg("Out of Positive Software Limit", frm_Msg.TMsgBtn.smbAlmClr | frm_Msg.TMsgBtn.smbOK);
                    return false;
                }
            }
            else
            {
                if (Pos <= Para.SwLimit.PosN)
                {
                    GDefine.Status = EStatus.ErrorInit;
                    frm_Msg.Page.ShowMsg("Out of Negative Software Limit", frm_Msg.TMsgBtn.smbAlmClr | frm_Msg.TMsgBtn.smbOK);
                    return false;
                }
            }

            return true;
        }

        private void MoveAxisStep(CMC.TAxis Axis, bool PosDir)
        {
            if (MotionBusy) { return; }
            MotionBusy = true;

            try
            {
                CMControl.SetMotionParam(Axis, 1, Axis.Para.Jog.SlowV, 100);
                if (PosDir)
                {
                    try
                    {
                        CMControl.MovePtpRel1(Axis, d_JogStep);
                        CMControl.AxisWait(Axis);
                        MotionBusy = false;
                    }
                    catch { };
                }
                else
                {
                    try
                    {
                        CMControl.MovePtpRel1(Axis, -d_JogStep);
                        CMControl.AxisWait(Axis);
                        MotionBusy = false;
                    }
                    catch { };
                }
            }
            catch (Exception Ex)
            {
                MotionBusy = false;
                frm_Msg.Page.ShowMsg(Ex.Message.ToString(), frm_Msg.TMsgBtn.smbAlmClr | frm_Msg.TMsgBtn.smbOK);
            }
        }
        private void JogAxisStart(CMC.TAxis Axis, bool PosDir, CMC.TAxisJogPara JogPara)
        {
            //if (MotionBusy) { return; }
            MotionBusy = true;

            try
            {
                //CMControl.SetMotionParam(Axis, 1, JogPara.Sel, 100);
                if (PosDir)
                {
                    try
                    {
                        //if (b_JogStep)
                        //{
                        //    CMControl.MovePtpRel1(Axis, d_JogStep);
                        //    CMControl.AxisWait(Axis);
                        //    MotionBusy = false;
                        //}
                        //else
                            CMControl.JogP(Axis);
                    }
                    catch { };
                }
                else
                {
                    try
                    {
                        //if (b_JogStep)
                        //{
                        //    CMControl.MovePtpRel1(Axis, -d_JogStep);
                        //    CMControl.AxisWait(Axis);
                        //    MotionBusy = false;
                        //}
                        //else
                            CMControl.JogN(Axis);
                    }
                    catch { };
                }
            }
            catch (Exception Ex)
            {
                MotionBusy = false;
                frm_Msg.Page.ShowMsg(Ex.Message.ToString(), frm_Msg.TMsgBtn.smbAlmClr | frm_Msg.TMsgBtn.smbOK);
            }
        }
        private void JogAxisStop(CMC.TAxis Axis)
        {
            //            if (Speed == ESpeed.Fast)
            //                CMControl.DecelStop(Axis);
            //            else
            CMControl.ForceStop(Axis);
            UpdateDisplay();
            MotionBusy = false;
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
                }
                catch { };
            }
        }
        private void SwitchMode()
        {
            if (GantryMode == EGantryMode.XYZ)
            {
                GantryMode = EGantryMode.X2Y2Z2;
                ArrowDrawColor = Color.Maroon;
                btn_GantryMode.Text = "X2,Y2,Z2";
                btn_GantryMode.BackColor = Color.Maroon;
            }
            else
            {
                GantryMode = EGantryMode.XYZ;
                ArrowDrawColor = Color.Blue;
                btn_GantryMode.Text = "X,Y,Z";
                btn_GantryMode.BackColor = this.BackColor;// Color.Navy;
            }
            Refresh();
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) { return; }
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



        //int t_Down = 0;
        int i_MoveStepWait = 100;
        //int i_SlowJogWait = 2000;
        bool b_MouseDn = false;
        bool b_StepMove = false;
        public void MouseDownEvent(CControl.CControl.TAxis Axis1, bool Axis1Dir, CControl.CControl.TAxis Axis2, bool Axis2Dir)
        {
            b_MouseDn = true;

            //if (GDefine.GetTickCount() < t_Down + 200)
            //{
            //    CMControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.FastV, 100);
            //    if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
            //    {
            //        CMControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.FastV, 100);
            //    }

            //    //MessageBox.Show((GDefine.GetTickCount() - t_Down).ToString());
            //    JogAxisStart(Axis1, Axis1Dir, Axis1.Para.Jog);
            //    if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
            //    {
            //        CMControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.SlowV, 100);
            //        JogAxisStart(Axis2, Axis2Dir, Axis2.Para.Jog);
            //    }
            //    return;
            //}
            //t_Down = GDefine.GetTickCount();


            #region Medium Fast Jog
            if (Speed == ESpeed.Med || Speed == ESpeed.Fast)
            {
                if (Speed == ESpeed.Med)
                {
                    CMControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.MedV, 100);
                    if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                    {
                        CMControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.MedV, 100);
                    }
                }
                if (Speed == ESpeed.Fast)
                {
                    CMControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.FastV, 100);
                    if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                    {
                        CMControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.FastV, 100);
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


            #region Move Step Wait
            int t1 = GDefine.GetTickCount() + i_MoveStepWait;
            while (GDefine.GetTickCount() < t1)
            {
                Application.DoEvents();
                //Thread.Sleep(0);
                if (!b_MouseDn)
                {
                    //MessageBox.Show((GDefine.GetTickCount() - t1).ToString());
                    return;
                }
            }
            #endregion

            b_StepMove = false;

            #region Slow Jog
            CMControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.SlowV, 100);
            JogAxisStart(Axis1, Axis1Dir, Axis1.Para.Jog);
            if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
            {
                CMControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.SlowV, 100);
                JogAxisStart(Axis2, Axis2Dir, Axis2.Para.Jog);
            }
            #endregion

            //#region Slow Jog Wait
            //int t2 = GDefine.GetTickCount() + i_SlowJogWait;
            //while (GDefine.GetTickCount() < t2)
            //{
            //    if (!b_MouseDn) return;
            //    Application.DoEvents();
            //    Thread.Sleep(0);
            //}
            //#endregion

            //#region Fast Jog
            //CMControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.FastV, 500);
            //if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
            //{
            //    CMControl.SetMotionParam(Axis2, 1, Axis2.Para.Jog.FastV, 500);
            //}
            //#endregion
        }
        private void MouseDownEvent(CControl.CControl.TAxis Axis, bool AxisDir)
        {
            MouseDownEvent(Axis, AxisDir, Axis, AxisDir);
        }
        private void MouseUpEvent(CControl.CControl.TAxis Axis1, bool Axis1Dir, CControl.CControl.TAxis Axis2, bool Axis2Dir)
        {
            b_MouseDn = false;

            if (b_StepMove)
            {
                #region Move Step
                MoveAxisStep(Axis1, Axis1Dir);
                if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                    MoveAxisStep(Axis2, Axis2Dir);
                #endregion
                b_StepMove = false;
                return;
            }

            JogAxisStop(Axis1);
            if (!(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask))
                JogAxisStop(Axis2);
        }
        private void MouseUpEvent(CControl.CControl.TAxis Axis, bool AxisDir)
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
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GXAxis, false);
            else
                MouseUpEvent(TaskGantry.GX2Axis, false);
        }

        private void btn_XP_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    if (!CheckLimit(TaskGantry.GX2Axis.Para, TaskGantry.GX2Pos(), true)) { return; }
            //    JogAxisStart(TaskGantry.GX2Axis, true, TaskGantry.GX2Axis.Para.Jog);
            //}
            //else
            //{
            //    if (!CheckLimit(TaskGantry.GXAxis.Para, TaskGantry.GXPos(), true)) { return; }
            //    JogAxisStart(TaskGantry.GXAxis, true, TaskGantry.GXAxis.Para.Jog);
            //}
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GXAxis, true);
            else
                MouseDownEvent(TaskGantry.GX2Axis, true);
        }
        private void btn_XP_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    JogAxisStop(TaskGantry.GX2Axis);
            //    if (!CheckLimit(TaskGantry.GX2Axis.Para, TaskGantry.GX2Pos(), true)) { return; }
            //}
            //else
            //{
            //    JogAxisStop(TaskGantry.GXAxis);
            //    if (!CheckLimit(TaskGantry.GXAxis.Para, TaskGantry.GXPos(), true)) { return; }
            //}

            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GXAxis, true);
            else
                MouseUpEvent(TaskGantry.GX2Axis, true);

        }
        private void btn_YN_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    if (!CheckLimit(TaskGantry.GY2Axis.Para, TaskGantry.GY2Pos(), false)) { return; }
            //    JogAxisStart(TaskGantry.GY2Axis, false, TaskGantry.GY2Axis.Para.Jog);
            //}
            //else
            //{
            //    if (!CheckLimit(TaskGantry.GYAxis.Para, TaskGantry.GYPos(), false)) { return; }
            //    JogAxisStart(TaskGantry.GYAxis, false, TaskGantry.GYAxis.Para.Jog);
            //}
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GYAxis, false);
            else
                MouseDownEvent(TaskGantry.GY2Axis, false);
        }
        private void btn_YN_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    JogAxisStop(TaskGantry.GY2Axis);
            //    if (!CheckLimit(TaskGantry.GY2Axis.Para, TaskGantry.GY2Pos(), false)) { return; }
            //}
            //else
            //{
            //    JogAxisStop(TaskGantry.GYAxis);
            //    if (!CheckLimit(TaskGantry.GYAxis.Para, TaskGantry.GYPos(), false)) { return; }
            //}

            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GYAxis, false);
            else
                MouseUpEvent(TaskGantry.GY2Axis, false);
        }
        private void btn_YP_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    if (!CheckLimit(TaskGantry.GY2Axis.Para, TaskGantry.GY2Pos(), true)) { return; }
            //    JogAxisStart(TaskGantry.GY2Axis, true, TaskGantry.GY2Axis.Para.Jog);
            //}
            //else
            //{
            //    if (!CheckLimit(TaskGantry.GYAxis.Para, TaskGantry.GYPos(), true)) { return; }
            //    JogAxisStart(TaskGantry.GYAxis, true, TaskGantry.GYAxis.Para.Jog);
            //}
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GYAxis, true);
            else
                MouseDownEvent(TaskGantry.GY2Axis, true);
        }
        private void btn_YP_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    JogAxisStop(TaskGantry.GY2Axis);
            //    if (!CheckLimit(TaskGantry.GY2Axis.Para, TaskGantry.GY2Pos(), true)) { return; }
            //}
            //else
            //{
            //    JogAxisStop(TaskGantry.GYAxis);
            //    if (!CheckLimit(TaskGantry.GYAxis.Para, TaskGantry.GYPos(), true)) { return; }
            //if (e.Button != MouseButtons.Left) { return; }
            //}
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GYAxis, true);
            else
                MouseUpEvent(TaskGantry.GY2Axis, true);
        }
        private void btn_ZN_MouseDown(object sender, MouseEventArgs e)
        {
            if (LockZ) return;
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    if (!CheckLimit(TaskGantry.GZ2Axis.Para, TaskGantry.GZ2Pos(), false)) { return; }
            //    JogAxisStart(TaskGantry.GZ2Axis, false, TaskGantry.GZ2Axis.Para.Jog);
            //}
            //else
            //{
            //    if (!CheckLimit(TaskGantry.GZAxis.Para, TaskGantry.GZPos(), false)) { return; }
            //    JogAxisStart(TaskGantry.GZAxis, false, TaskGantry.GZAxis.Para.Jog);
            //}
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GZAxis, false);
            else
                MouseDownEvent(TaskGantry.GZ2Axis, false);
        }
        private void btn_ZN_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    JogAxisStop(TaskGantry.GZ2Axis);
            //    if (!CheckLimit(TaskGantry.GZ2Axis.Para, TaskGantry.GZ2Pos(), false)) { return; }
            //}
            //else
            //{
            //    JogAxisStop(TaskGantry.GZAxis);
            //    if (!CheckLimit(TaskGantry.GZAxis.Para, TaskGantry.GZPos(), false)) { return; }
            //}
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseUpEvent(TaskGantry.GZAxis, false);
            else
                MouseUpEvent(TaskGantry.GZ2Axis, false);
        }
        private void btn_ZP_MouseDown(object sender, MouseEventArgs e)
        {
            if (LockZ) return;

            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    if (!CheckLimit(TaskGantry.GZ2Axis.Para, TaskGantry.GZ2Pos(), true)) { return; }
            //    JogAxisStart(TaskGantry.GZ2Axis, true, TaskGantry.GZ2Axis.Para.Jog);
            //}
            //else
            //{
            //    if (!CheckLimit(TaskGantry.GZAxis.Para, TaskGantry.GZPos(), true)) { return; }
            //    JogAxisStart(TaskGantry.GZAxis, true, TaskGantry.GZAxis.Para.Jog);
            //}
            if (e.Button != MouseButtons.Left) { return; }

            if (GantryMode != EGantryMode.X2Y2Z2)
                MouseDownEvent(TaskGantry.GZAxis, true);
            else
                MouseDownEvent(TaskGantry.GZ2Axis, true);
        }
        private void btn_ZP_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) { return; }
            //if (GantryMode == EGantryMode.X2Y2Z2)
            //{
            //    JogAxisStop(TaskGantry.GZ2Axis);
            //    if (!CheckLimit(TaskGantry.GZ2Axis.Para, TaskGantry.GZ2Pos(), true)) { return; }
            //}
            //else
            //{
            //    JogAxisStop(TaskGantry.GZAxis);
            //    if (!CheckLimit(TaskGantry.GZAxis.Para, TaskGantry.GZPos(), true)) { return; }
            //}
            if (e.Button != MouseButtons.Left) { return; }

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
        }

        //private void btn_Speed_Click(object sender, EventArgs e)
        //{
        //    if (Speed >= ESpeed.Fast )
        //    {
        //        Speed = ESpeed.Slow;
        //    }
        //    else
        //    {
        //        Speed++;
        //    }
        //    UpdateSpeed();
        //}

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
                        if (!CheckLimit(TaskGantry.GX2Axis.Para, TaskGantry.GX2Pos(), false)) { goto _End; }
                        JogAxisStart(TaskGantry.GX2Axis, false, TaskGantry.GX2Axis.Para.Jog);
                        GX2Busy = true;
                    }
                    else
                    {
                        if (!CheckLimit(TaskGantry.GXAxis.Para, TaskGantry.GXPos(), false)) { goto _End; }
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
                            if (!CheckLimit(TaskGantry.GX2Axis.Para, TaskGantry.GX2Pos(), true)) { goto _End; }
                            JogAxisStart(TaskGantry.GX2Axis, true, TaskGantry.GX2Axis.Para.Jog);
                            GX2Busy = true;
                        }
                        else
                        {
                            if (!CheckLimit(TaskGantry.GXAxis.Para, TaskGantry.GXPos(), true)) { goto _End; }
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
                                if (!CheckLimit(TaskGantry.GY2Axis.Para, TaskGantry.GY2Pos(), false)) { goto _End; }
                                JogAxisStart(TaskGantry.GY2Axis, false, TaskGantry.GY2Axis.Para.Jog);
                                GY2Busy = true;
                            }
                            else
                            {
                                if (!CheckLimit(TaskGantry.GYAxis.Para, TaskGantry.GYPos(), false)) { goto _End; }
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
                                    if (!CheckLimit(TaskGantry.GY2Axis.Para, TaskGantry.GY2Pos(), true)) { goto _End; }
                                    JogAxisStart(TaskGantry.GY2Axis, true, TaskGantry.GY2Axis.Para.Jog);
                                    GY2Busy = true;
                                }
                                else
                                {
                                    if (!CheckLimit(TaskGantry.GYAxis.Para, TaskGantry.GYPos(), true)) { goto _End; }
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
                        if (!CheckLimit(TaskGantry.GZ2Axis.Para, TaskGantry.GZ2Pos(), false)) { goto _End; }
                        JogAxisStart(TaskGantry.GZ2Axis, false, TaskGantry.GZ2Axis.Para.Jog);
                        GZ2Busy = true;
                    }
                    else
                    {
                        if (!CheckLimit(TaskGantry.GZAxis.Para, TaskGantry.GZPos(), false)) { goto _End; }
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
                            if (!CheckLimit(TaskGantry.GZ2Axis.Para, TaskGantry.GZ2Pos(), true)) { goto _End; }
                            JogAxisStart(TaskGantry.GZ2Axis, true, TaskGantry.GZ2Axis.Para.Jog);
                            GZ2Busy = true;
                        }
                        else
                        {
                            if (!CheckLimit(TaskGantry.GZAxis.Para, TaskGantry.GZPos(), true)) { goto _End; }
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
                CheckLimit(TaskGantry.GXAxis.Para, TaskGantry.GXPos(), false);
                CheckLimit(TaskGantry.GXAxis.Para, TaskGantry.GXPos(), true);
                GXBusy = false;
            }
            if (GYBusy)
            {
                JogAxisStop(TaskGantry.GYAxis);
                CheckLimit(TaskGantry.GYAxis.Para, TaskGantry.GYPos(), false);
                CheckLimit(TaskGantry.GYAxis.Para, TaskGantry.GYPos(), true);
                GYBusy = false;
            }
            if (GZBusy)
            {
                JogAxisStop(TaskGantry.GZAxis);
                CheckLimit(TaskGantry.GZAxis.Para, TaskGantry.GZPos(), false);
                CheckLimit(TaskGantry.GZAxis.Para, TaskGantry.GZPos(), true);
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
        //private void btn_JogStep_Click(object sender, EventArgs e)
        //{
        //    b_JogStep = !b_JogStep;
        //    UpdateDisplay();
        //}

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

        //int i_x = 0;
        //int i_y = 0;
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
                if (GDefine.GantryConfig == GDefine.EGantryConfigType.XZ_YTABLE)
                d_y_ratio = (double)(ptMouse.Y) / pnl_Jog.Height;
                else
                d_y_ratio = (double)(pnl_Jog.Height - ptMouse.Y) / pnl_Jog.Height;

                double mX = (XRange * d_x_ratio) + XM;
                double mY = (YRange * d_y_ratio) + YM;

                //lbl_Pos.Text = mX.ToString("F3") + "," + mY.ToString("F3");

                try
                {
                    if (!TaskGantry.SetMotionParamGZZ2()) return;
                    if (!TaskGantry.MoveAbsGZZ2(0)) return;

                    if (GDefine.GantryConfig == GDefine.EGantryConfigType.XY_ZX2Y2_Z2)
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

        //private void btn_EnablePointJog_Click(object sender, EventArgs e)
        //{
        //    b_EnablePointJog = !b_EnablePointJog;
        //}

        private void UpdatePnlPointJog()
        {

        }

        private void pnl_Jog_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                int X = (int)((double)(XPos - XM) / XRange * pnl_Jog.Width);
                int Y = (int)((double)(YPos - YM) / YRange * pnl_Jog.Height);
                if (GDefine.GantryConfig != GDefine.EGantryConfigType.XZ_YTABLE) Y = pnl_Jog.Height - Y;

                Pen P = new Pen(Color.Black, 1);
                e.Graphics.DrawLine(P, new Point(0, Y), new Point(pnl_Jog.Width, Y));
                e.Graphics.DrawLine(P, new Point(X, 0), new Point(X, pnl_Jog.Height));

                e.Graphics.DrawRectangle(P, new Rectangle(X - 5, Y - 5, 10, 10));
            }
            catch { };
        }

        private void pnl_XYJog_Paint(object sender, PaintEventArgs e)
        {
        }

        Color ArrowDrawColor = Color.Blue;
        private void btn_YP_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);

            int S = (int)((double)btn_YP.Width * 0.25);
            int CX = btn_YP.Width / 2;
            int CY = btn_YP.Height / 2;

            Point[] Points = new Point[4];
            Points[0] = new Point(CX, CY - S);
            Points[1] = new Point(CX + S, CY + S);
            Points[2] = new Point(CX - S, CY + S);
            Points[3] = new Point(CX, CY - S);
            e.Graphics.DrawLines(P, Points);
        }
        private void btn_XN_Paint(object sender, PaintEventArgs e)
        {
            Pen P = new Pen(ArrowDrawColor, 2);

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
            if (LockZ) P.Color = Color.Gray;

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
            if (LockZ) P.Color = Color.Gray;

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
    }
}



