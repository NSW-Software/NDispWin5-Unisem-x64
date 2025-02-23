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
    public partial class frm_DispCore_DispSetup_TeachNeedle : Form
    {
        public frm_DispCore_DispSetup_TeachNeedle()
        {
            InitializeComponent(); 
            GControl.LogForm(this);
        }

        private void frm_DispCore_DispSetup_TeachNeedle_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
        }
        private void frm_DispCore_DispSetup_TeachNeedle_Shown(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispSetup_TeachNeedle_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            lbl_TeachNeedleMethod.Text = Enum.GetName(typeof(TaskDisp.ETeachNeedleMethod), TaskDisp.TeachNeedle_Method).ToString();
            cbox_RequireOnLotStart.Checked = TaskDisp.TeachNeedle_PromptOnLotStart;

            lbl_MultiHeadXYTol.Text = TaskDisp.MultiHead_XYTol.ToString("f3");
            lbl_MultiHeadZTol.Text = TaskDisp.MultiHead_ZTol.ToString("f3");
            cbox_PromptCleanStage.Checked = TaskDisp.TeachNeedle_DotPromptCleanStage;
            lbl_CleanStagePos.Text = TaskDisp.TeachNeedle_CleanStage_Pos.X.ToString("F3") + "," + TaskDisp.TeachNeedle_CleanStage_Pos.Y.ToString("F3");

            gbox_ZSensorMarkSet.Visible = TaskDisp.TeachNeedle_Method == TaskDisp.ETeachNeedleMethod.ZSensor_Mark_Set;
            if (TaskDisp.TeachNeedle_Method == TaskDisp.ETeachNeedleMethod.ZSensor_Mark_Set)
            {
                lbl_TeachNeedleZOfst.Text = TaskDisp.TeachNeedle_ZOfst.ToString("F3");
                lbl_TeachNeedleDownTime.Text = TaskDisp.TeachNeedle_WaitTime.ToString();
            }

            lbl_NeedleGap.Text = TaskDisp.TeachNeedle_NeedleGap.ToString("f3");
            lbl_DotTime.Text = TaskDisp.TeachNeedle_DotTime.ToString();
            lbl_DotVol.Text = TaskDisp.TeachNeedle_DotVolume.ToString();

            cbox_PromptLaserClean.Checked = TaskDisp.TeachNeedle_LaserPromptCleanStage;
            lbl_LaserChangeRate.Text = TaskDisp.TeachNeedle_LaserChangeRate.ToString("f3");

            lbl_ZTouchDetectMethod.Text = TaskDisp.TeachNeedle_ZTouchDetectMethod.ToString();
        }

        private void lbl_TeachNeedleMethod_Click(object sender, EventArgs e)
        {
            int i = (int)TaskDisp.TeachNeedle_Method;
            //if (GDefine.uc.UserAdjustExecute("", ref i, 0, Enum.GetNames(typeof(TaskDisp.ETeachNeedleMethod)).Length - 1))
            //    TaskDisp.TeachNeedle_Method = (TaskDisp.ETeachNeedleMethod)i;
            if (UC.AdjustExec("Disp Setup, Teach Needle Method", ref i, TaskDisp.TeachNeedle_Method))
                TaskDisp.TeachNeedle_Method = (TaskDisp.ETeachNeedleMethod)i;
            UpdateDisplay();
        }

        private void lbl_TeachNeedleZOfst_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Teach Needle Z Offset (mm)", ref TaskDisp.TeachNeedle_ZOfst, -1, 1);
            UpdateDisplay();
        }
        private void lbl_TeachNeedleDownTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Teach Needle Down Time (ms)", ref TaskDisp.TeachNeedle_WaitTime, 0, 2500);
            UpdateDisplay();
        }

        private void lbl_MultiHeadZTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, MultiHead Z Tol (mm)", ref TaskDisp.MultiHead_ZTol, 0, 1);
            UpdateDisplay();
        }

        private void gbox_StepByStep_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_NeedleGap_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Teach Needle Gap (mm)", ref TaskDisp.TeachNeedle_NeedleGap, 0, 10);
            UpdateDisplay();
        }

        private void lbl_DotTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Dot Time (ms)", ref TaskDisp.TeachNeedle_DotTime, 1, 1000);
            UpdateDisplay();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_DotVol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Dot Volume (ul)", ref TaskDisp.TeachNeedle_DotVolume, 0.001, 5);
            UpdateDisplay();
        }

        private void cbox_PromptLaserClean_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Laser Prompt Clean Stage", ref TaskDisp.TeachNeedle_LaserPromptCleanStage);
            UpdateDisplay();
        }

        private void lbl_LaserHeightChangeRate_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Laser Height Change Rate (mm)", ref TaskDisp.TeachNeedle_LaserChangeRate, 0, 1);
            UpdateDisplay();
        }

        private void cbox_PromptCleanStage_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cbox_PromptCleanStage_Click(object sender, EventArgs e)
        {
            TaskDisp.TeachNeedle_DotPromptCleanStage = !TaskDisp.TeachNeedle_DotPromptCleanStage;
            UpdateDisplay();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            TaskDisp.TeachNeedle_CleanStage_Pos.X = TaskGantry.GXPos();
            TaskDisp.TeachNeedle_CleanStage_Pos.Y = TaskGantry.GYPos();

            UpdateDisplay();
        }

        private void btn_Goto_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(TaskDisp.TeachNeedle_CleanStage_Pos.X, TaskDisp.TeachNeedle_CleanStage_Pos.Y)) return;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cbox_RequireOnLotStart_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Teach Needle Require OnLotStart", ref TaskDisp.TeachNeedle_PromptOnLotStart);
            UpdateDisplay();
        }

        private void lbl_MultiHeadXYTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, MultiHead XY Tol (mm)", ref TaskDisp.MultiHead_XYTol, 0, 1);
            UpdateDisplay();
        }

        private void lbl_ZTouchDetectMethod_Click(object sender, EventArgs e)
        {
            int i = (int)TaskDisp.TeachNeedle_ZTouchDetectMethod;
            UC.AdjustExec("Disp Setup, ZTouchDetectMethod", ref i, TaskDisp.EZTouchDetectMethod.Default);
            TaskDisp.TeachNeedle_ZTouchDetectMethod = (TaskDisp.EZTouchDetectMethod)i;
            UpdateDisplay();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_TeachNeedle_ForceInTol_Click(object sender, EventArgs e)
        {

        }
    }
}
