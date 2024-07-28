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
    internal partial class frmMotorPara : Form
    {
        private static CControl2.TAxis PAxis = new CControl2.TAxis();
        enum EAxis { GX, GY, GZ, GX2, GY2, GZ2}
        EAxis SelectedAxis = EAxis.GX;

        public frmMotorPara()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;

            //AppLanguage.Func.SetComponent(this);
        }

        private void UpdateDisplay()
        {
            switch (GDefine.GantryConfig)
            {
                case GDefine.EGantryConfig.XY_ZX2Y2_Z2:
                    #region
                    btn_GX2Axis.Visible = true;
                    btn_GY2Axis.Visible = true;
                    btn_GZ2Axis.Visible = true;
                    break;
                    #endregion
            }
            
            btn_GXAxis.BackColor = SystemColors.Control;
            btn_GYAxis.BackColor = SystemColors.Control;
            btn_GZAxis.BackColor = SystemColors.Control;
            btn_GX2Axis.BackColor = SystemColors.Control;
            btn_GY2Axis.BackColor = SystemColors.Control;
            btn_GZ2Axis.BackColor = SystemColors.Control;

            switch (SelectedAxis)
            {
                case EAxis.GX: btn_GXAxis.BackColor = Color.Lime; break;
                case EAxis.GY: btn_GYAxis.BackColor = Color.Lime; break;
                case EAxis.GZ: btn_GZAxis.BackColor = Color.Lime; break;
                case EAxis.GX2: btn_GX2Axis.BackColor = Color.Lime; break;
                case EAxis.GY2: btn_GY2Axis.BackColor = Color.Lime; break;
                case EAxis.GZ2: btn_GZ2Axis.BackColor = Color.Lime; break;
            }

            #region Param
            lbl_InvertMtrOn.Text = PAxis.Para.InvertMtrOn.ToString();
            lbl_InvertDir.Text = PAxis.Para.InvertPulse.ToString();
            switch (PAxis.Para.MotorAlarmType)
            {
                case CControl2.EMotorAlarmType.None:
                    lbl_MtrAlmLogic.Text = "None";
                    break;
                case CControl2.EMotorAlarmType.NC:
                    lbl_MtrAlmLogic.Text = "NC";
                    break;
                case CControl2.EMotorAlarmType.NO:
                    lbl_MtrAlmLogic.Text = "NO";
                    break;
            }
            lbl_DistPerPulse.Text = PAxis.Para.Unit.Resolution.ToString("F5");

            lbl_SLmtP.Text = PAxis.Para.SwLimit.PosP.ToString("F3");
            lbl_SLmtN.Text = PAxis.Para.SwLimit.PosN.ToString("F3");
            if (PAxis.Para.Home.Dir == CControl2.EHomeDir.N)
            {
                lbl_HomeDir.Text = "Negative";
            }
            else
            {
                lbl_HomeDir.Text = "Positive";
            }
            lbl_HomeSlowV.Text = PAxis.Para.Home.SlowV.ToString("F3");
            lbl_HomeFastV.Text = PAxis.Para.Home.FastV.ToString("F3");
            lbl_HomeTimeOut.Text = PAxis.Para.Home.Timeout.ToString();

            lbl_Accel.Text = PAxis.Para.Accel.ToString("F3");
            lbl_StartV.Text = PAxis.Para.StartV.ToString("F3");
            lbl_SlowV.Text = PAxis.Para.SlowV.ToString("F3");
            lbl_FastV.Text = PAxis.Para.FastV.ToString("F3");

            lbl_JogSlowV.Text = PAxis.Para.Jog.SlowV.ToString("F3");
            lbl_JogMedV.Text = PAxis.Para.Jog.MedV.ToString("F3");
            lbl_JogFastV.Text = PAxis.Para.Jog.FastV.ToString("F3");
            #endregion

            lbl_HomeSeq.Text = Enum.GetName(typeof(TaskGantry.EHomeSequence), TaskGantry.HomeSequence).ToString();
            lbl_ZHeightForSlowSpeed.Text = TaskGantry.ZHeightForSlowSpeed.ToString("f3");
            lblTLX.Text = $"{TaskGantry.DispenseWindow[0].X:f3}";
            lblTLY.Text = $"{TaskGantry.DispenseWindow[0].Y:f3}";
            lblBRX.Text = $"{TaskGantry.DispenseWindow[1].X:f3}";
            lblBRY.Text = $"{TaskGantry.DispenseWindow[1].Y:f3}";
            lblSafeZ.Text = $"{TaskGantry.DispenseWindowZ:f3}";

            lblConfigFile.Text = "Config File: " + (TaskGantry.UseConfigFile ? GDefine.ConfigFile : "none");
        }
        private void UpdatePara()
        {
            if (SelectedAxis < EAxis.GX) { return; }
            switch (SelectedAxis)
            {
                case EAxis.GX:
                    TaskGantry.GXAxis = PAxis;
                    CommonControl.UpdateAxis(TaskGantry.GXAxis);
                    break;
                case EAxis.GY:
                    TaskGantry.GYAxis = PAxis;
                    CommonControl.UpdateAxis(TaskGantry.GYAxis);
                    break;
                case EAxis.GZ:
                    TaskGantry.GZAxis = PAxis;
                    CommonControl.UpdateAxis(TaskGantry.GZAxis);
                    break;
                case EAxis.GX2:
                    TaskGantry.GX2Axis = PAxis;
                    CommonControl.UpdateAxis(TaskGantry.GX2Axis);
                    break;
                case EAxis.GY2:
                    TaskGantry.GY2Axis = PAxis;
                    CommonControl.UpdateAxis(TaskGantry.GY2Axis);
                    break;
                case EAxis.GZ2:
                    TaskGantry.GZ2Axis = PAxis;
                    CommonControl.UpdateAxis(TaskGantry.GZ2Axis);
                    break;
            }
        }

        private void frmConfigMotorPara_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Motor Para";
            SelectedAxis = EAxis.GX;
            PAxis = TaskGantry.GXAxis;

            UpdateDisplay();
        }
        private void frmMotorPara_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void frm_DispCore_MotorPara_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btn_GXAxis_Click(object sender, EventArgs e)
        {
            UpdatePara();
            SelectedAxis = EAxis.GX;
            PAxis = TaskGantry.GXAxis;
            UpdateDisplay();
        }
        private void btn_GYAxis_Click(object sender, EventArgs e)
        {
            UpdatePara();
            SelectedAxis = EAxis.GY;
            PAxis = TaskGantry.GYAxis;
            UpdateDisplay();
        }
        private void btn_GZAxis_Click(object sender, EventArgs e)
        {
            UpdatePara();
            SelectedAxis = EAxis.GZ;
            PAxis = TaskGantry.GZAxis;
            UpdateDisplay();
        }
        private void btn_GX2Axis_Click(object sender, EventArgs e)
        {
            UpdatePara();
            SelectedAxis = EAxis.GX2;
            PAxis = TaskGantry.GX2Axis;
            UpdateDisplay();
        }
        private void btn_GY2_Click(object sender, EventArgs e)
        {
            UpdatePara();
            SelectedAxis = EAxis.GY2;
            PAxis = TaskGantry.GY2Axis;
            UpdateDisplay();
        }
        private void btn_GZ2_Click(object sender, EventArgs e)
        {
            UpdatePara();
            SelectedAxis = EAxis.GZ2;
            PAxis = TaskGantry.GZ2Axis;
            UpdateDisplay();
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            switch (SelectedAxis)
            {
                case EAxis.GX: TaskGantry.GXHome(); break;
                case EAxis.GY: TaskGantry.GYHome(); break;
                case EAxis.GZ: TaskGantry.GZHome(); break;
                case EAxis.GX2: TaskGantry.GX2Home(); break;
                case EAxis.GY2: TaskGantry.GY2Home(); break;
                case EAxis.GZ2: TaskGantry.GZ2Home(); break;
            }
        }
 
        private void lbl_InvertMtrOn_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Motor Para, " + SelectedAxis.ToString() + " Invert MotorOn", ref PAxis.Para.InvertMtrOn);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_DistPerPulse_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Motor Para, Dist Per Pulse (mm)", ref PAxis.Para.Unit.Resolution, 0.0001, 0.1);
            CommonControl.UpdateAxis(PAxis);
            GDefine.Status = EStatus.ErrorInit;
            UpdateDisplay();
        }
        private void lbl_HomeDir_Click(object sender, EventArgs e)
        {
            int i = (int)PAxis.Para.Home.Dir;
            UC.AdjustExec("Motor Para, " + SelectedAxis.ToString() + " Home Dir", ref i, CControl2.EHomeDir.N);
            PAxis.Para.Home.Dir = (CControl2.EHomeDir)i;
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_InvertDir_Click(object sender, EventArgs e)
        {
            bool b = PAxis.Para.InvertPulse;
            UC.AdjustExec("Motor Para, " + SelectedAxis.ToString() + " Invert Dir", ref b);
            PAxis.Para.InvertPulse = b;
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_MtrAlmLogic_Click(object sender, EventArgs e)
        {
            int i = (int)PAxis.Para.MotorAlarmType;
            UC.AdjustExec("Motor Para, " + SelectedAxis.ToString() + " Motor Alarm Logic", ref i, CControl2.EMotorAlarmType.None);
            PAxis.Para.MotorAlarmType = (CControl2.EMotorAlarmType)i;

            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_SLmtP_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Motor Para, Software Limit Positive (mm)", ref PAxis.Para.SwLimit.PosP, 0, 1000);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_SLmtN_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Motor Para, Software Limit Negative (mm)", ref PAxis.Para.SwLimit.PosN, -1000, 0);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }

        private void lbl_HomeSlowV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(PAxis, ref Min, ref Max);
            UC.AdjustExec("Motor Para, Home Slow Speed (mm/s)", ref PAxis.Para.Home.SlowV, Min, Max / 5);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_HomeFastV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(PAxis, ref Min, ref Max);
            UC.AdjustExec("Motor Para, Home Fast Speed (mm/s)", ref PAxis.Para.Home.FastV, Min, Max / 5);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_HomeTimeOut_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Motor Para, Home Timeout (ms)", ref PAxis.Para.Home.Timeout, 0, 60000);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }

        private void lbl_JogSlowV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(PAxis, ref Min, ref Max);
            Max = 10;
            UC.AdjustExec("Motor Para, Jog Slow Speed (mm/s)", ref PAxis.Para.Jog.SlowV, Min, Max);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_JogMedV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(PAxis, ref Min, ref Max);
            Max = 100;
            UC.AdjustExec("Motor Para, Jog Med Speed (mm/s)", ref PAxis.Para.Jog.MedV, Min, Max);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_JogFastV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(PAxis, ref Min, ref Max);
            Min = 0;
            Max = 100;
            UC.AdjustExec("Motor Para, Jog Fast Speed (mm/s)", ref PAxis.Para.Jog.FastV, Min, Max);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }

        private void lbl_StartV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(PAxis, ref Min, ref Max);
            UC.AdjustExec("Motor Para, Operation Start Speed (mm/s)", ref PAxis.Para.StartV, Min, Max);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_SlowV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(PAxis, ref Min, ref Max);
            UC.AdjustExec("Motor Para, Operation Slow Speed (mm/s)", ref PAxis.Para.SlowV, Min, Max);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_FastV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(PAxis, ref Min, ref Max);
            UC.AdjustExec("Motor Para, Operation Fast Speed (mm/s)", ref PAxis.Para.FastV, Min, Max);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }
        private void lbl_Accel_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorAccelRange(PAxis, ref Min, ref Max);
            UC.AdjustExec("Motor Para, Operation Accel (mm/s2)", ref PAxis.Para.Accel, Min, Max);
            CommonControl.UpdateAxis(PAxis);
            UpdateDisplay();
        }

        private void lbl_HomeSeq_Click(object sender, EventArgs e)
        {
            TaskGantry.EHomeSequence E = TaskGantry.EHomeSequence.ZXY;
            int i = (int)TaskGantry.HomeSequence;
            UC.AdjustExec("Motor Para, Home Sequence", ref i, E);
            TaskGantry.HomeSequence = (TaskGantry.EHomeSequence)i;
            UpdateDisplay();
        }

        private void btn_Jog2_Click(object sender, EventArgs e)
        {
            frmJogGantry frm_Jog2 = new frmJogGantry();
            frm_Jog2.TopMost = true;
            frm_Jog2.Show();
        }

        private void lbl_ZHeightForSlowXY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Motor Para, Z Height For Slow Speed", ref TaskGantry.ZHeightForSlowSpeed, -200, 10);
            UpdateDisplay();
        }

        private void lblTLX_Click(object sender, EventArgs e)
        {
            double d = (double)TaskGantry.DispenseWindow[0].X;
            UC.AdjustExec("Motor Para, Dispense Window TLX", ref d, -999, 999);
            TaskGantry.DispenseWindow[0].X = d;
            UpdateDisplay();
        }
        private void lblTLY_Click(object sender, EventArgs e)
        {
            double d = (double)TaskGantry.DispenseWindow[0].Y;
            UC.AdjustExec("Motor Para, Dispense Window TLY", ref d, -999, 999);
            TaskGantry.DispenseWindow[0].Y = d;
            UpdateDisplay();
        }
        private void lblBRX_Click(object sender, EventArgs e)
        {
            double d = (double)TaskGantry.DispenseWindow[1].X;
            UC.AdjustExec("Motor Para, Dispense Window BRX", ref d, -999, 999);
            TaskGantry.DispenseWindow[1].X = d;
            UpdateDisplay();
        }
        private void lblBRY_Click(object sender, EventArgs e)
        {
            double d = (double)TaskGantry.DispenseWindow[1].Y;
            UC.AdjustExec("Motor Para, Dispense Window BRY", ref d, -999, 999);
            TaskGantry.DispenseWindow[1].Y = d;
            UpdateDisplay();
        }
        private void lblSafeZ_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Motor Para, Dispense Window SafeZ", ref TaskGantry.DispenseWindowZ, -200, 10);
            UpdateDisplay();
        }
    }
}
