using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace NDispWin
{
    public partial class uctrl_JogGantry : UserControl
    {
        Color Color1 = Color.Navy;
        Color Color2 = Color.Maroon;
        Color Color3 = Color.Green;
        Color Color4 = Color.OrangeRed;
        Color SelectedColor = Color.Lime;

        public uctrl_JogGantry()
        {
            InitializeComponent();

            if (GDefine.GantryConfig != GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                tabControl1.TabPages.Remove(tpXY2);
            }

            Button SpeedStep = new Button(); SpeedStep.AccessibleDescription = "Step"; SpeedStep.Visible = false; this.Controls.Add(SpeedStep);
            Button SpeedSlow = new Button(); SpeedSlow.AccessibleDescription = "Slow"; SpeedSlow.Visible = false; this.Controls.Add(SpeedSlow);
            Button SpeedMed = new Button(); SpeedMed.AccessibleDescription = "Med"; SpeedMed.Visible = false; this.Controls.Add(SpeedMed);
            Button SpeedFast = new Button(); SpeedFast.AccessibleDescription = "Fast"; SpeedFast.Visible = false; this.Controls.Add(SpeedFast);

            b_PadSupport = TaskGantry.GetWorkArea(ref d_XMLmt, ref d_XPLmt, ref d_YMLmt, ref d_YPLmt);
            if (!b_PadSupport) return;
            d_PadXRange = d_XPLmt - d_XMLmt;
            d_PadYRange = d_YPLmt - d_YMLmt;
        }

        private void uctrl_JogGantry_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            pnl_Pad.Location = new Point(1, 1);

            Speed = ESpeed.Slow;

            UI_Utils.ButtonDrawArrow(ref btn_XM, UI_Utils.EArrow.XN);
            UI_Utils.ButtonDrawArrow(ref btn_XP, UI_Utils.EArrow.XP);
            UI_Utils.ButtonDrawArrow(ref btn_YM, UI_Utils.EArrow.YN);
            UI_Utils.ButtonDrawArrow(ref btn_YP, UI_Utils.EArrow.YP);

            UI_Utils.ButtonDrawArrow(ref btn_XMYP, UI_Utils.EArrow.XNYP);
            UI_Utils.ButtonDrawArrow(ref btn_XMYM, UI_Utils.EArrow.XNYN);
            UI_Utils.ButtonDrawArrow(ref btn_XPYP, UI_Utils.EArrow.XPYP);
            UI_Utils.ButtonDrawArrow(ref btn_XPYM, UI_Utils.EArrow.XPYN);

            UI_Utils.ButtonDrawArrow(ref btn_ZM, UI_Utils.EArrow.ZN);
            UI_Utils.ButtonDrawArrow(ref btn_ZP, UI_Utils.EArrow.ZP);

            UI_Utils.ButtonDrawArrow(ref btn_X2M, UI_Utils.EArrow.XN);
            UI_Utils.ButtonDrawArrow(ref btn_X2P, UI_Utils.EArrow.XP);
            UI_Utils.ButtonDrawArrow(ref btn_Y2M, UI_Utils.EArrow.YN);
            UI_Utils.ButtonDrawArrow(ref btn_Y2P, UI_Utils.EArrow.YP);
            UI_Utils.ButtonDrawArrow(ref btn_Z2M, UI_Utils.EArrow.ZN);
            UI_Utils.ButtonDrawArrow(ref btn_Z2P, UI_Utils.EArrow.ZP);

            //b_EnableLaser = false;

            tmr_1s.Enabled = true;

            UpdateDisplay();
        }

        public int ForceGantry
        {
            set
            {
                if (value == 2)
                    tabControl1.SelectTab(tpXY2);
                else
                    tabControl1.SelectTab(tpXY);
                UpdateDisplay();
            }
        }

        private enum ESpeed { Slow, Med, Fast };
        ESpeed Speed = ESpeed.Slow;

        private double XRefPos, YRefPos, ZRefPos, URefPos, X2RefPos, Y2RefPos, Z2RefPos;
        private double XRRefPos, YRRefPos, ZRRefPos, URRefPos, X2RRefPos, Y2RRefPos, Z2RRefPos;

        enum EPosSource { None, Logi, Real }
        EPosSource PosSource = EPosSource.Logi;
        private void UpdateDisplay()
        {
            #region Update UI

            btn_Speed.Text = Speed.ToString();
            btn_Speed.Text = stepMode > EStepMode.None? "Step": Speed.ToString();
            btn_Speed2.Text = stepMode > EStepMode.None ? "Step" : Speed.ToString();

            btn_ZP.Enabled = !b_LockZ;
            btn_ZM.Enabled = !b_LockZ;
            btn_Z2P.Enabled = !b_LockZ;
            btn_Z2M.Enabled = !b_LockZ;
            #endregion

            lblWarning.Text = bUnsafeJog ? "Unsafe Operation" : "";

            btnXY1Step1.BackColor = stepMode == EStepMode.Step1 ? Color.Lime : this.BackColor;
            btnXY1Step2.BackColor = stepMode == EStepMode.Step2 ? Color.Lime : this.BackColor;
            btnXY1Step3.BackColor = stepMode == EStepMode.Step3 ? Color.Lime : this.BackColor;
            btnXY1StepC.Text = "(" + dJogStepC.ToString("f3") + ")";
            btnXY1StepC.BackColor = stepMode == EStepMode.StepC ? Color.Lime : this.BackColor;

            btnXY2Step1.BackColor = stepMode == EStepMode.Step1 ? Color.Lime : this.BackColor;
            btnXY2Step2.BackColor = stepMode == EStepMode.Step2 ? Color.Lime : this.BackColor;
            btnXY2Step3.BackColor = stepMode == EStepMode.Step3 ? Color.Lime : this.BackColor;
            btnXY2Step3.Text = "(" + dJogStepC.ToString("f3") + ")";
            btnXY2Step3.BackColor = stepMode == EStepMode.StepC ? Color.Lime : this.BackColor;

            lbl_R.Text = TaskVision.CurrentLightRGBA.R.ToString();
            lbl_G.Text = TaskVision.CurrentLightRGBA.G.ToString();
            lbl_B.Text = TaskVision.CurrentLightRGBA.B.ToString();
            lbl_A.Text = TaskVision.CurrentLightRGBA.A.ToString();

            if (tbar_R.Value != TaskVision.CurrentLightRGBA.R) tbar_R.Value = TaskVision.CurrentLightRGBA.R;
            if (tbar_G.Value != TaskVision.CurrentLightRGBA.G) tbar_G.Value = TaskVision.CurrentLightRGBA.G;
            if (tbar_B.Value != TaskVision.CurrentLightRGBA.B) tbar_B.Value = TaskVision.CurrentLightRGBA.B;
            if (tbar_A.Value != TaskVision.CurrentLightRGBA.A) tbar_A.Value = TaskVision.CurrentLightRGBA.A;

            lbl_Focus0.Text = (TaskDisp.ZDefPos + DispProg.FocusRelPos[0]).ToString("f3");
            lbl_Focus1.Text = (TaskDisp.ZDefPos + DispProg.FocusRelPos[1]).ToString("f3");
            lbl_Focus2.Text = (TaskDisp.ZDefPos + DispProg.FocusRelPos[2]).ToString("f3");
            lbl_Focus3.Text = (TaskDisp.ZDefPos + DispProg.FocusRelPos[3]).ToString("f3");
        }

        private bool CheckLimit(CControl2.TAxis Axis, bool PosDir)
        {
            if (PosDir)
            {
                if (TaskGantry.SLmtP(Axis))
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.SOFTWARE_P_LIMIT, Axis.Name);

                    return false;
                }
            }
            else
            {
                if (TaskGantry.SLmtN(Axis))
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.SOFTWARE_N_LIMIT, Axis.Name);

                    return false;
                }
            }

            return true;
        }

        bool MotionBusy = false;
        private void MoveAxisStep(CControl2.TAxis Axis, bool PosDir)
        {
            double dStep = dJogStepC;
            if (stepMode == EStepMode.Step1) dStep = 0.001;
            if (stepMode == EStepMode.Step2) dStep = 0.005;
            if (stepMode == EStepMode.Step3) dStep = 0.010;

            if (!CheckLimit(Axis, PosDir)) return;

            if (MotionBusy) { return; }
            MotionBusy = true;

            if (PosDir)
            {
                try
                {
                    CommonControl.MovePtpRel1(Axis, dStep);
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
                    CommonControl.MovePtpRel1(Axis, -dStep);
                    while (true)
                    {
                        if (!TaskGantry.AxisBusy(Axis)) break;
                        Thread.Sleep(0);
                    }
                    MotionBusy = false;
                }
                catch { };
            }
            UpdateDisplay();
            MotionBusy = false;
        }
        private void JogAxisStart(CControl2.TAxis Axis, bool PosDir, CControl2.TAxisJogPara JogPara)
        {
            //if (!CheckLimit(Axis, PosDir)) return;


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
        private void JogAxisStop(CControl2.TAxis Axis)
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
        }

        bool bUnsafeJog = false;
        public void MouseDownEvent(object sender, CControl2.TAxis Axis1, bool Axis1Dir, CControl2.TAxis Axis2, bool Axis2Dir)
        {
            bool b_ValidAxis2 = !(Axis1.Device.ID == Axis2.Device.ID && Axis1.Mask == Axis2.Mask);

            if (Axis1.Name == TaskGantry.GXAxis.Name || Axis1.Name == TaskGantry.GYAxis.Name)
            {
                if (!bUnsafeJog && TaskGantry.DispenseWindow[0].X != 0 && TaskGantry.DispenseWindow[0].Y != 0 && TaskGantry.DispenseWindow[1].X != 0 && TaskGantry.DispenseWindow[1].Y != 0)
                {
                    double posX = TaskGantry.GXPos();
                    double posY = TaskGantry.GYPos();
                    double posZ = TaskGantry.GZPos();

                    if (posZ <= TaskGantry.DispenseWindowZ &&
                        posX >= TaskGantry.DispenseWindow[0].X + TaskDisp.Head_Ofst[0].X &&
                        posY <= TaskGantry.DispenseWindow[0].Y + TaskDisp.Head_Ofst[0].Y &&
                        posX <= TaskGantry.DispenseWindow[1].X + TaskDisp.Head_Ofst[0].X &&
                        posY >= TaskGantry.DispenseWindow[1].Y + TaskDisp.Head_Ofst[0].Y)
                    {
                        Msg MsgBox = new Msg();
                        EMsgRes res = MsgBox.Show("Warning, XY is within dispense window and Z height is not safe. Continue?", EMcState.Warning, EMsgBtn.smbYes | EMsgBtn.smbNo, false);
                        switch (res)
                        {
                            case EMsgRes.smrYes:
                                bUnsafeJog = true;
                                UpdateDisplay();
                                return;
                            case EMsgRes.smrNo: return;
                        }
                        return;
                    }
                }
            }

            CommonControl.ClearAxisError(Axis1);
            if (b_ValidAxis2) CommonControl.ClearAxisError(Axis2);

            if (TaskGantry.GZPos() <= TaskGantry.ZHeightForSlowSpeed)
            {
                if ((Axis1.Name == TaskGantry.GZAxis.Name || Axis1.Name == TaskGantry.GZ2Axis.Name) && Axis1Dir)
                { }//skip slow speed if Z move up
                else
                    Speed = ESpeed.Slow;
            }

            if (stepMode != EStepMode.None)
            {
                CommonControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.SlowV, 10);
                CommonControl.SetMotionParam(Axis2, 1, Axis1.Para.Jog.SlowV, 10);
                MoveAxisStep(Axis1, Axis1Dir);
                if (b_ValidAxis2) MoveAxisStep(Axis2, Axis2Dir);
                return;
            }

            #region Set Speed
            try
            {
                switch (Speed)
                {
                    //case ESpeed.Step:
                    //CommonControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.SlowV, 10);
                    //CommonControl.SetMotionParam(Axis2, 1, Axis1.Para.Jog.SlowV, 10);
                    //break;
                    case ESpeed.Slow:
                        CommonControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.SlowV, 100);
                        if (b_ValidAxis2) CommonControl.SetMotionParam(Axis2, 1, Axis1.Para.Jog.SlowV, 100);
                        break;
                    case ESpeed.Med:
                        CommonControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.MedV, 1000);
                        if (b_ValidAxis2) CommonControl.SetMotionParam(Axis2, 1, Axis1.Para.Jog.MedV, 1000);
                        break;
                    case ESpeed.Fast:
                        CommonControl.SetMotionParam(Axis1, 1, Axis1.Para.Jog.FastV, 1000);
                        if (b_ValidAxis2) CommonControl.SetMotionParam(Axis2, 1, Axis1.Para.Jog.FastV, 1000);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            #endregion

            //  Jog Start
            {
                JogAxisStart(Axis1, Axis1Dir, Axis1.Para.Jog);
                if (b_ValidAxis2) JogAxisStart(Axis2, Axis2Dir, Axis2.Para.Jog);
                return;
            }
        }
        private void MouseDownEvent(object sender, CControl2.TAxis Axis, bool AxisDir)
        {
            MouseDownEvent(sender, Axis, AxisDir, Axis, AxisDir);
        }
        private void MouseUpEvent(object sender, CControl2.TAxis Axis1, CControl2.TAxis Axis2)
        {
            if (stepMode != EStepMode.None) return;

            JogAxisStop(Axis1);
            JogAxisStop(Axis2);
        }
        private void MouseUpEvent(object sender, CControl2.TAxis Axis)
        {
            MouseUpEvent(sender, Axis, Axis);
        }

        #region Direction Mouse Up Dn
        private void btn_XM_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            MouseDownEvent(sender, TaskGantry.GXAxis, false);
        }
        private void btn_XM_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GXAxis);
        }
        private void btn_XM_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GXAxis);
        }
        private void btn_XP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            MouseDownEvent(sender, TaskGantry.GXAxis, true);
        }
        private void btn_XP_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GXAxis);
        }
        private void btn_XP_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GXAxis);
        }

        private void btn_YM_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            MouseDownEvent(sender, TaskGantry.GYAxis, false);
        }
        private void btn_YM_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GYAxis);
        }
        private void btn_YM_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GYAxis);
        }
        private void btn_YP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            //if (TaskGantry.SLmtP(Axis)) return;
            MouseDownEvent(sender, TaskGantry.GYAxis, true);
        }
        private void btn_YP_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GYAxis);
        }
        private void btn_YP_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GYAxis);
        }

        private void btn_XMYM_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            MouseDownEvent(sender, TaskGantry.GXAxis, false, TaskGantry.GYAxis, false);
        }
        private void btn_XMYM_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GXAxis, TaskGantry.GYAxis);
        }

        private void btn_XMYP_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvent(sender, TaskGantry.GXAxis, false, TaskGantry.GYAxis, true);
        }
        private void btn_XMYP_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GXAxis, TaskGantry.GYAxis);
        }

        private void btn_XPYM_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvent(sender, TaskGantry.GXAxis, true, TaskGantry.GYAxis, false);
        }
        private void btn_XPYM_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GXAxis, TaskGantry.GYAxis);
        }

        private void btn_XPYP_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvent(sender, TaskGantry.GXAxis, true, TaskGantry.GYAxis, true);
        }
        private void btn_XPYP_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GXAxis, TaskGantry.GYAxis);
        }

        bool bZ1Dn = false;
        private void btn_ZM_MouseDown(object sender, MouseEventArgs e)
        {
            bZ1Dn = true;
            if (e.Button != MouseButtons.Left) { return; }
            MouseDownEvent(sender, TaskGantry.GZAxis, false);

            //  Switch to slow speed if lower that set value
            Task.Run(() =>
            {
                while (bZ1Dn)
                {
                    if (Speed != ESpeed.Slow && TaskGantry.GZPos() <= TaskGantry.ZHeightForSlowSpeed)
                    {
                        //CommonControl.SetMotionParam(TaskGantry.GZAxis, 1, TaskGantry.GZAxis.Para.Jog.SlowV, 10);
                        MouseUpEvent(sender, TaskGantry.GZAxis);
                        Speed = ESpeed.Slow;
                    }
                }
            });
        }
        private void btn_ZM_MouseUp(object sender, MouseEventArgs e)
        {
            bZ1Dn = false;
            MouseUpEvent(sender, TaskGantry.GZAxis);
        }
        private void btn_ZM_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
            {
                bZ1Dn = false;
                MouseUpEvent(sender, TaskGantry.GZAxis);
            }
        }
        private void btn_ZP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            MouseDownEvent(sender, TaskGantry.GZAxis, true);
        }
        private void btn_ZP_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GZAxis);
        }
        private void btn_ZP_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GZAxis);
        }

        private void btn_X2M_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

                    MouseDownEvent(sender, TaskGantry.GX2Axis, false);
        }
        private void btn_X2M_MouseUp(object sender, MouseEventArgs e)
        {
                    MouseUpEvent(sender, TaskGantry.GX2Axis);
        }
        private void btn_X2M_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GX2Axis);
        }

        private void btn_X2P_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

                    MouseDownEvent(sender, TaskGantry.GX2Axis, true);
        }
        private void btn_X2P_MouseUp(object sender, MouseEventArgs e)
        {
                    MouseUpEvent(sender, TaskGantry.GX2Axis);
        }
        private void btn_X2P_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GX2Axis);
        }

        private void btn_Y2M_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

                    MouseDownEvent(sender, TaskGantry.GY2Axis, false);
        }
        private void btn_Y2M_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GY2Axis);
        }
        private void btn_Y2M_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GY2Axis);
        }

        private void btn_Y2P_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            MouseDownEvent(sender, TaskGantry.GY2Axis, true);
        }
        private void btn_Y2P_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GY2Axis);
        }
        private void btn_Y2P_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
                MouseUpEvent(sender, TaskGantry.GY2Axis);
        }

        bool bZ2Dn = false;
        private void btn_Z2M_MouseDown(object sender, MouseEventArgs e)
        {
            bZ2Dn = true;
            if (e.Button != MouseButtons.Left) { return; }
            MouseDownEvent(sender, TaskGantry.GZ2Axis, false);

            //  Switch to slow speed if lower that set value
            Task.Run(() =>
            {
                while (bZ1Dn)
                {
                    if (Speed != ESpeed.Slow && TaskGantry.GZ2Pos() <= TaskGantry.ZHeightForSlowSpeed)
                    {
                        MouseUpEvent(sender, TaskGantry.GZ2Axis);
                        Speed = ESpeed.Slow;
                    }
                }
            });
        }
        private void btn_Z2M_MouseUp(object sender, MouseEventArgs e)
        {
            bZ2Dn = false;
            MouseUpEvent(sender, TaskGantry.GZ2Axis);
        }
        private void btn_Z2M_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
            {
                bZ2Dn = false;
                MouseUpEvent(sender, TaskGantry.GZ2Axis);
            }
        }

        private void btn_Z2P_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            MouseDownEvent(sender, TaskGantry.GZ2Axis, true);
        }
        private void btn_Z2P_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(sender, TaskGantry.GZ2Axis);
        }

        private void btn_Z2P_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > ((Button)sender).Width || e.Y < 0 || e.Y > ((Button)sender).Height)
            {
                MouseUpEvent(sender, TaskGantry.GZ2Axis);
            }
        }
        #endregion

        private void btn_Speed_Click(object sender, EventArgs e)
        {
            if (stepMode > EStepMode.None)
            {
                stepMode = EStepMode.None;
                UpdateDisplay();
                return;
            }

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

        bool b_LockZ = true;
        private void btn_LockZ_Click(object sender, EventArgs e)
        {
            b_LockZ = !b_LockZ;

            if (!b_LockZ) Event.PROG_UNLOCK_Z.Set();

            UpdateDisplay();
        }

        //frm_DispCore_Lighting frm_Lighting = new frm_DispCore_Lighting();
        private void btn_Lightings_Click(object sender, EventArgs e)
        {
            //if (!frm_Lighting.Visible)
            //{
            //    frm_Lighting.BringToFront();
            //    frm_Lighting.Show();
            //    frm_Lighting.TopMost = true;
            //}
            //else
            //    frm_Lighting.Hide();
        }

        private void MeasureReset()
        {
            if (tabControl1.SelectedTab == tpXY)
            {
                try
                {
                    XRefPos = TaskGantry.GXPos();
                    YRefPos = TaskGantry.GYPos();
                    ZRefPos = TaskGantry.GZPos();
                    URefPos = TaskGantry.GUPos();
                    XRRefPos = TaskGantry.GXRPos();
                    YRRefPos = TaskGantry.GYRPos();
                    ZRRefPos = TaskGantry.GZRPos();
                    URRefPos = TaskGantry.GURPos();
                }
                catch { };
            }

            if (tabControl1.SelectedTab == tpXY2)
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
        }
        bool bMeasMode = false;
        private void btnMeas_Click(object sender, EventArgs e)
        {
            bMeasMode = !bMeasMode;

            if (bMeasMode)
            {
                MeasureReset();
            }
            UpdateDisplay();
        }

        bool b_EnableLaser = true;
        double d_LaserZero = 0;
        private void btn_Laser_Click(object sender, EventArgs e)
        {
            b_EnableLaser = !b_EnableLaser;
            UpdateDisplay();
        }
        private void btnLaserMeas_Click(object sender, EventArgs e)
        {
            TraceMode = false;

            if (d_LaserZero == 0)
            {
                double d = 0;
                if (TaskLaser.GetHeight(ref d, false))
                {
                    d_LaserZero = d;
                }
            }
            else
                d_LaserZero = 0;
        }
 
        double d_XMLmt = 0;
        double d_XPLmt = 0;
        double d_YMLmt = 0;
        double d_YPLmt = 0;
        bool b_PadSupport = false;//  Kind of stupid way to check limit. To improve
        double d_PadXRange = 0;
        double d_PadYRange = 0;
        private void pnl_Pad_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                d_CurrXPos = TaskGantry.GXPos();
                d_CurrYPos = TaskGantry.GYPos();

                int X = (int)((double)(d_CurrXPos - d_XMLmt) / d_PadXRange * pnl_Pad.Width);
                int Y = (int)((double)(d_CurrYPos - d_YMLmt) / d_PadYRange * pnl_Pad.Height);
                if (GDefine.GantryConfig != GDefine.EGantryConfig.XZ_YTABLE) Y = pnl_Pad.Height - Y;

                Pen P = new Pen(Color.Black, 1);
                e.Graphics.DrawLine(P, new Point(0, Y), new Point(pnl_Pad.Width, Y));
                e.Graphics.DrawLine(P, new Point(X, 0), new Point(X, pnl_Pad.Height));

                e.Graphics.DrawRectangle(P, new Rectangle(X - 5, Y - 5, 10, 10));

                //draw product
                double d_StartX = DispProg.Origin((ERunStationNo)0).X + DispProg.rt_Layouts[0].StartX;
                double d_StartY = DispProg.Origin((ERunStationNo)0).Y + DispProg.rt_Layouts[0].StartY;
                d_StartX = d_StartX / d_PadXRange * pnl_Pad.Width;
                d_StartY = -d_StartY / d_PadYRange * pnl_Pad.Height;
                double d_SizeX = DispProg.rt_Layouts[0].SizeX;
                double d_SizeY = DispProg.rt_Layouts[0].SizeY;
                d_SizeX = d_SizeX / d_PadXRange * pnl_Pad.Width;
                d_SizeY = d_SizeY / d_PadYRange * pnl_Pad.Height;

                //if (d_SizeY < 0) d_StartY = d_StartY + d_SizeY;
                d_SizeY = Math.Abs(d_SizeY);

                P.Color = Color.Maroon;
                e.Graphics.DrawRectangle(P, (float)d_StartX, (float)d_StartY, (float)d_SizeX, (float)d_SizeY);// (float)d_Size.X, (float)d_Size.Y);
            }
            catch { };
        }
        private void pnl_Pad_MouseDown(object sender, MouseEventArgs e)
        {
            if (!b_PadSupport) return;

            if (e.Button == MouseButtons.Left)
            {
                Point ptMouse = pnl_Pad.PointToClient(Control.MousePosition);

                double d_x_ratio = (double)ptMouse.X / pnl_Pad.Width;
                double d_y_ratio = 0;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                    d_y_ratio = (double)(ptMouse.Y) / pnl_Pad.Height;
                else
                    d_y_ratio = (double)(pnl_Pad.Height - ptMouse.Y) / pnl_Pad.Height;

                double mX = (d_PadXRange * d_x_ratio) + d_XMLmt;
                double mY = (d_PadYRange * d_y_ratio) + d_YMLmt;

                try
                {
                    if (!TaskDisp.TaskMoveGZZ2Up()) return;

                    if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                    {
                        if (!TaskGantry.SetMotionParamGX2Y2()) return;
                        if (!TaskGantry.MoveAbsGX2Y2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y)) return;
                    }

                    if (!TaskGantry.SetMotionParamGXY()) return;
                    if (!TaskGantry.MoveAbsGXY(mX, mY)) return;
                }
                catch { };
            }

        }

        bool b_Keyboard = false;
        bool b_SelectZ = false;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab != tpXY) return;

            if (e.KeyCode == Keys.Escape) Cursor.Position = new Point(0, 0);

            if (!b_Keyboard) return;

            CControl2.TAxis Axis = new CControl2.TAxis();
            Axis = TaskGantry.GXAxis;
            #region Axis Selection
            if (e.KeyCode == Keys.Z) b_SelectZ = true;
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) Axis = TaskGantry.GXAxis;
            if (b_SelectZ)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) Axis = TaskGantry.GZAxis;
            }
            else
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) Axis = TaskGantry.GYAxis;
            }
            #endregion

            #region Jog
            if (e.Shift)
            {
                //b_StepMode = false;
                stepMode = EStepMode.None;
            }
                if (e.Control)
            {
                //b_StepMode = false;
                stepMode = EStepMode.None;

                Speed = ESpeed.Slow;
                if (e.Shift) Speed = ESpeed.Fast;
                UpdateDisplay();

                try
                {
                    switch (Speed)
                    {
                        case ESpeed.Slow:
                            CommonControl.SetMotionParam(Axis, 1, Axis.Para.Jog.SlowV, 100);
                            break;
                        case ESpeed.Med:
                            CommonControl.SetMotionParam(Axis, 1, Axis.Para.Jog.MedV, 1000);
                            break;
                        case ESpeed.Fast:
                            CommonControl.SetMotionParam(Axis, 1, Axis.Para.Jog.FastV, 1000);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                if (b_SelectZ)
                {
                    if (e.KeyCode == Keys.Up) JogAxisStart(Axis, true, TaskGantry.GZAxis.Para.Jog);
                    if (e.KeyCode == Keys.Down) JogAxisStart(TaskGantry.GZAxis, false, TaskGantry.GZAxis.Para.Jog);
                }
                else
                {
                    if (e.KeyCode == Keys.Left) JogAxisStart(Axis, false, TaskGantry.GXAxis.Para.Jog);
                    if (e.KeyCode == Keys.Right) JogAxisStart(Axis, true, TaskGantry.GXAxis.Para.Jog);
                    if (e.KeyCode == Keys.Up) JogAxisStart(Axis, true, TaskGantry.GXAxis.Para.Jog);
                    if (e.KeyCode == Keys.Down) JogAxisStart(Axis, false, TaskGantry.GXAxis.Para.Jog);
                }
            }
            #endregion

            #region Step Move
            //if (b_StepMode)
            if (stepMode != EStepMode.None)
            {
                if (!b_SelectZ)
                {
                    if (e.KeyCode == Keys.Left) MoveAxisStep(Axis, false);
                    if (e.KeyCode == Keys.Right) MoveAxisStep(Axis, true);
                }
                if (e.KeyCode == Keys.Up) MoveAxisStep(Axis, true);
                if (e.KeyCode == Keys.Down) MoveAxisStep(Axis, false);
            }

            //if (e.KeyCode == Keys.S)
            //{
            //    b_StepMode = !b_StepMode;
            //    try
            //    {
            //        CommonControl.SetMotionParam(Axis, 1, Axis.Para.Jog.SlowV, 100);
            //    }
            //    catch
            //    { };
            //    UpdateDisplay();
            //    return;
            //}

            //if (e.KeyCode == Keys.D1)
            //{
            //    d_JogStep = 0.001;
            //    UpdateDisplay();
            //    return;
            //}

            //if (e.KeyCode == Keys.D2)
            //{
            //    d_JogStep = 0.002;
            //    UpdateDisplay();
            //    return;
            //}

            //if (e.KeyCode == Keys.D3)
            //{
            //    d_JogStep = 0.003;
            //    UpdateDisplay();
            //    return;
            //}

            //if (e.KeyCode == Keys.D4)
            //{
            //    d_JogStep = 0.01;
            //    UpdateDisplay();
            //    return;
            //}
            //if (e.KeyCode == Keys.OemMinus)
            //{
            //    if (d_JogStep > 0.001) 
            //    d_JogStep = d_JogStep - 0.001;
            //    UpdateDisplay();
            //    return;
            //}
            //if (e.KeyCode == Keys.Oemplus)
            //{
            //    if (d_JogStep < 3)
            //        d_JogStep = d_JogStep + 0.001;
            //    UpdateDisplay();
            //    return;
            //}
            #endregion
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            CControl2.TAxis Axis = new CControl2.TAxis();
            Axis = TaskGantry.GXAxis;
            CControl2.TAxis Axis2 = new CControl2.TAxis();
            Axis2 = TaskGantry.GZAxis;
            if (e.KeyCode == Keys.Z) b_SelectZ = false;
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) Axis = TaskGantry.GXAxis;
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) Axis = TaskGantry.GYAxis;

            JogAxisStop(TaskGantry.GZAxis);
            JogAxisStop(Axis);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbox_Keyboard.Text = "Keyboard";
        }
        private void tbox_Keyboard_Leave(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        enum EStepMode { None, Step1, Step2, Step3, StepC };
        EStepMode stepMode = EStepMode.None;
        double dJogStepC = 0.050;
        private void btnXY1Step1_Click(object sender, EventArgs e)
        {
            if (stepMode == EStepMode.Step1)
                stepMode = EStepMode.None;
            else
                stepMode = EStepMode.Step1;

            UpdateDisplay();
        }
        private void btnXY1Step2_Click(object sender, EventArgs e)
        {
            if (stepMode == EStepMode.Step2)
                stepMode = EStepMode.None;
            else
                stepMode = EStepMode.Step2;
            UpdateDisplay();
        }
        private void btnXY1Step3_Click(object sender, EventArgs e)
        {
            if (stepMode == EStepMode.Step3)
                stepMode = EStepMode.None;
            else
                stepMode = EStepMode.Step3;
            UpdateDisplay();
        }
        private void btnXY1StepC_Click(object sender, EventArgs e)
        {
            if (stepMode == EStepMode.StepC)
            {
                stepMode = EStepMode.None;
                UpdateDisplay();
                return;
            }

            double d_Min = TaskGantry.GXAxis.Para.Unit.Resolution;
            double d_Max = 3;
            double d = dJogStepC;
            if (!UC.AdjustExec("JogGantry, JogStep", ref d, d_Min, d_Max)) return;
            dJogStepC = d;

            stepMode = EStepMode.StepC;
            UpdateDisplay();
        }

        private void lbl_R_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.R;

            if (UC.AdjustExec("LED, R", ref i, 0, 100))
            {
                RGBA.R = i;
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();
            }
        }
        private void lbl_G_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.G;

            if (UC.AdjustExec("LED, G", ref i, 0, 100))
            {
                RGBA.G = i;
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();
            }
        }
        private void lbl_B_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.B;

            if (UC.AdjustExec("LED, B", ref i, 0, 100))
            {
                RGBA.B = i;
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();
            }
        }
        private void lbl_A_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.A;

            if (UC.AdjustExec("LED, A", ref i, 0, 100))
            {
                RGBA.A = i;
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();
            }
        }
        private void tbar_R_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA.R = tbar_R.Value;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }
        private void tbar_G_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA.G = tbar_G.Value;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }
        private void tbar_B_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA.B = tbar_B.Value;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }
        private void tbar_A_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA.A = tbar_A.Value;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }
        private void btnSetDef_Click(object sender, EventArgs e)
        {
            TaskVision.DefLightRGB = TaskVision.CurrentLightRGBA;
        }
        private void btnSetDef2_Click(object sender, EventArgs e)
        {
            TaskVision.Def2LightRGB = TaskVision.CurrentLightRGBA;
        }

        private void btnLedOnOff_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            UpdateDisplay();
        }
        private void btnLedDef2_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.Def2LightRGB);
            UpdateDisplay();
        }
        private void btnLEDOff_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOff();
            UpdateDisplay();
        }

        private async void btn_AutoFocus_Click(object sender, EventArgs e)
        {
            frm_ProgressReport frmPR = new frm_ProgressReport();
            try
            {
                this.Enabled = false;

                frmPR = new frm_ProgressReport();
                frmPR.Message = "Auto Focus in Progress. Please wait...";
                frmPR.Show();

                await Task.Run(() =>
                {
                    if (!TaskDisp.TaskAutoFocus()) return;
                });
                frmPR.Done = true;
            }
            catch
            { }
            finally
            {
                frmPR.Done = true;
                this.Enabled = true;
                UpdateDisplay();
            }
        }
        private void btn_SetAF1_Click(object sender, EventArgs e)
        {
            double dOld = DispProg.FocusRelPos[0];
            DispProg.FocusRelPos[0] = TaskGantry.GZPos() - TaskDisp.ZDefPos;
            double dNew = DispProg.FocusRelPos[0];
            Event.SET_FOCUS0_UPDATE.Set("Focus 0 Z Pos", dNew.ToString("f3"));

            UpdateDisplay();
        }
        private void btn_GotoAF1_Click(object sender, EventArgs e)
        {
            int SelectedFocus = 0;
            if (!TaskDisp.TaskMoveGZFocus(SelectedFocus)) return;
            UpdateDisplay();
        }
        private void btn_SetAF2_Click(object sender, EventArgs e)
        {
            double dOld = DispProg.FocusRelPos[1];
            DispProg.FocusRelPos[1] = TaskGantry.GZPos() - TaskDisp.ZDefPos;
            double dNew = DispProg.FocusRelPos[1];
            Event.SET_FOCUS1_UPDATE.Set("Focus 1 Z Pos", dNew.ToString("f3"));

            UpdateDisplay();
        }
        private void btn_GotoAF2_Click(object sender, EventArgs e)
        {
            int SelectedFocus = 1;
            if (!TaskDisp.TaskMoveGZFocus(SelectedFocus)) return;
            UpdateDisplay();
        }
        private void btn_SetAF3_Click(object sender, EventArgs e)
        {
            double dOld = DispProg.FocusRelPos[2];
            DispProg.FocusRelPos[2] = TaskGantry.GZPos() - TaskDisp.ZDefPos;
            double dNew = DispProg.FocusRelPos[2];
            Event.SET_FOCUS2_UPDATE.Set("Focus 2 Z Pos", dNew.ToString("f3"));

            UpdateDisplay();
        }
        private void btn_GotoAF3_Click(object sender, EventArgs e)
        {
            int SelectedFocus = 2;
            if (!TaskDisp.TaskMoveGZFocus(SelectedFocus)) return;
            UpdateDisplay();
        }
        private void btn_SetAF4_Click(object sender, EventArgs e)
        {
            double dOld = DispProg.FocusRelPos[3];
            DispProg.FocusRelPos[3] = TaskGantry.GZPos() - TaskDisp.ZDefPos;
            double dNew = DispProg.FocusRelPos[3];
            Event.SET_FOCUS2_UPDATE.Set("Focus 3 Z Pos", dNew.ToString("f3"));

            UpdateDisplay();
        }
        private void btn_GotoAF4_Click(object sender, EventArgs e)
        {
            int SelectedFocus = 3;
            if (!TaskDisp.TaskMoveGZFocus(SelectedFocus)) return;
            UpdateDisplay();
        }

        private void lbl_Keyboard_Click(object sender, EventArgs e)
        {
            tbox_Keyboard.Focus();
        }
        private void lbl_Keyboard_MouseHover(object sender, EventArgs e)
        {
            b_Keyboard = true;
            tbox_Keyboard.Focus();
        }
        private void lbl_Keyboard_MouseLeave(object sender, EventArgs e)
        {
            JogAxisStop(TaskGantry.GXAxis);
            JogAxisStop(TaskGantry.GYAxis);
            JogAxisStop(TaskGantry.GZAxis);
            b_Keyboard = false;
        }

        double d_CurrXPos = 0;
        double d_CurrYPos = 0;
        private void UpdatePosDisplay()
        {
            double XA = 0; double YA = 0; double ZA = 0; double UA = 0; double RXA = 0; double RYA = 0;
            double XR = 0; double YR = 0; double ZR = 0; double UR = 0; double DR = 0;
            try
            {
                d_CurrXPos = XA;
                d_CurrYPos = YA;
                if (tabControl1.SelectedTab == tpXY2)
                {
                    switch (PosSource)
                    {
                        case EPosSource.None:
                            break;
                        case EPosSource.Logi:
                            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                            {
                                XA = TaskGantry.GX2Pos();
                                YA = TaskGantry.GY2Pos();
                            }
                            ZA = TaskGantry.GZ2Pos();
                            break;
                        case EPosSource.Real:
                            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                            {
                                XA = TaskGantry.GX2RPos();
                                YA = TaskGantry.GY2RPos();
                            }
                            ZA = TaskGantry.GZ2RPos();
                            break;
                    }
                }
                else//if (tabControl1.SelectedTab == tpXY)
                {
                    switch (PosSource)
                    {
                        case EPosSource.None:
                            break;
                        case EPosSource.Logi:
                            XA = TaskGantry.GXPos();
                            YA = TaskGantry.GYPos();
                            ZA = TaskGantry.GZPos();
                            UA = TaskGantry.GUPos();
                            break;
                        case EPosSource.Real:
                            XA = TaskGantry.GXRPos();
                            YA = TaskGantry.GYRPos();
                            ZA = TaskGantry.GZRPos();
                            UA = TaskGantry.GURPos();
                            break;
                    }
                }
            }
            catch { };

            #region Calc Ref Position
            if (tabControl1.SelectedTab == tpXY)
            {
                switch (PosSource)
                {
                    case EPosSource.None:
                        break;
                    case EPosSource.Logi:
                        XR = XA - XRefPos;
                        YR = YA - YRefPos;
                        ZR = ZA - ZRefPos;
                        UR = UA - URefPos;
                        break;
                    case EPosSource.Real:
                        XR = XA - XRRefPos;
                        YR = YA - YRRefPos;
                        ZR = ZA - ZRRefPos;
                        UR = UA - URRefPos;
                        break;
                }
                DR = Math.Sqrt(Math.Pow(XR, 2) + Math.Pow(YR, 2));
            }
            if (tabControl1.SelectedTab == tpXY2)
            {
                switch (PosSource)
                {
                    case EPosSource.None:
                        break;
                    case EPosSource.Logi:
                        XR = XA - X2RefPos;
                        YR = YA - Y2RefPos;
                        ZR = ZA - Z2RefPos;
                        break;
                    case EPosSource.Real:
                        XR = XA - X2RRefPos;
                        YR = YA - Y2RRefPos;
                        ZR = ZA - Z2RRefPos;
                        break;
                }
            }
            #endregion

            lblXPos.ForeColor = bMeasMode ? Color.DarkRed : Color.Navy;
            lblYPos.ForeColor = bMeasMode ? Color.DarkRed : Color.Navy;
            lblZPos.ForeColor = bMeasMode ? Color.DarkRed : Color.Navy;

            switch (PosSource)
            {
                default:
                    lblXPos.Text = "-";
                    lblYPos.Text = "-";
                    lblZPos.Text = "-";
                    break;
                case EPosSource.Logi:
                case EPosSource.Real:
                    {

                        lblXPos.Text = bMeasMode ? XR.ToString("f3") : XA.ToString("f3");
                        lblYPos.Text = bMeasMode ? YR.ToString("f3") : YA.ToString("f3");
                        lblZPos.Text = bMeasMode ? ZR.ToString("f3") : ZA.ToString("f3");
                        break;
                    }
            }
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (b_EnableLaser)
            {
                if (TaskLaser.LaserOpened)
                {
                    double d = 0;
                    if (TaskLaser.GetHeight(ref d, false))
                    {
                        lblLaser.ForeColor = Color.Navy;

                        if (d_LaserZero != 0)
                            lblLaser.ForeColor = Color.DarkRed;
                        else
                            lblLaser.ForeColor = Color.Navy;

                        lblLaser.Text = (d - d_LaserZero).ToString("F3");
                    }
                    else
                    {
                        lblLaser.ForeColor = Color.Red;
                        lblLaser.Text = "Err";
                    }
                }
                else
                {
                    lblLaser.Text = "XXX";
                }
            }
            else
                lblLaser.Text = "---";

            if (PosSource == EPosSource.Logi || PosSource == EPosSource.Real)
                UpdatePosDisplay();

            lbl_Keyboard.BackColor = b_Keyboard ? Color.Lime : this.BackColor;
            pnl_Pad.Refresh();

            btn_Trace.BackColor = b_TraceMode ? Color.Lime : this.BackColor;
            btn_TraceSet.Visible = b_TraceMode;
        }
        private void tmr_1s_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            try
            {
                if (tabControl1.SelectedTab == tpXY)
                {
                    if (TaskGantry.SLmtP(TaskGantry.GXAxis)) btn_XP.BackColor = Color.Red; else btn_XP.BackColor = this.BackColor;
                    if (TaskGantry.SLmtN(TaskGantry.GXAxis)) btn_XM.BackColor = Color.Red; else btn_XM.BackColor = this.BackColor;
                    if (TaskGantry.SLmtP(TaskGantry.GYAxis)) btn_YP.BackColor = Color.Red; else btn_YP.BackColor = this.BackColor;
                    if (TaskGantry.SLmtN(TaskGantry.GYAxis)) btn_YM.BackColor = Color.Red; else btn_YM.BackColor = this.BackColor;
                    if (TaskGantry.SLmtP(TaskGantry.GZAxis)) btn_ZP.BackColor = Color.Red; else btn_ZP.BackColor = this.BackColor;
                    if (TaskGantry.SLmtN(TaskGantry.GZAxis)) btn_ZM.BackColor = Color.Red; else btn_ZM.BackColor = this.BackColor;
                }
                if (tabControl1.SelectedTab == tpXY2)
                {
                    if (TaskGantry.SLmtP(TaskGantry.GX2Axis)) btn_X2P.BackColor = Color.Red; else btn_X2P.BackColor = this.BackColor;
                    if (TaskGantry.SLmtN(TaskGantry.GX2Axis)) btn_X2M.BackColor = Color.Red; else btn_X2M.BackColor = this.BackColor;
                    if (TaskGantry.SLmtP(TaskGantry.GY2Axis)) btn_Y2P.BackColor = Color.Red; else btn_Y2P.BackColor = this.BackColor;
                    if (TaskGantry.SLmtN(TaskGantry.GY2Axis)) btn_Y2M.BackColor = Color.Red; else btn_Y2M.BackColor = this.BackColor;
                    if (TaskGantry.SLmtP(TaskGantry.GZ2Axis)) btn_Z2P.BackColor = Color.Red; else btn_Z2P.BackColor = this.BackColor;
                    if (TaskGantry.SLmtN(TaskGantry.GZ2Axis)) btn_Z2M.BackColor = Color.Red; else btn_Z2M.BackColor = this.BackColor;
                }
            }
            catch { };
        }

        bool b_TraceMode = false;
        private bool TraceMode
        {
            set
            {
                b_TraceMode = value;

                DispProg.TraceMode = b_TraceMode;
            }
            get
            {
                return b_TraceMode;
            }
        }
        private void btn_Trace_Click(object sender, EventArgs e)
        {
            TraceMode = !TraceMode;
        }
        private void btn_TraceSet_Click(object sender, EventArgs e)
        {
            if (TraceMode)
            {
                DispProg.SetTracePos();
            }
        }
    }
}
