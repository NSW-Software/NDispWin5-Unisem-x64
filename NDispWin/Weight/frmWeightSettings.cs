using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDispWin
{
    public partial class frmWeightSettings : Form
    {
        public frmWeightSettings()
        {
            InitializeComponent(); 
            GControl.LogForm(this);
        }

        private void frmWeightSettings_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = "Weight Settings";
            UpdateDisplay();
        }

        private void frmWeightSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmWeightSettings_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void UpdateDisplay()
        {
            this.Text = "Weight Settings [" + DispProg.Pump_Type.ToString() + "]";

            lbl_Needle1WeightPosXYZ.Text = TaskWeight.Needle_Weight_Pos[0].GetString;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                lbl_Needle2WeightPosZ2.Text = TaskWeight.Needle_Weight_Pos[1].Z.ToString("F3");
            }
            else
            {
                lbl_Needle2WeightPosZ2.Text = TaskWeight.Needle_Weight_Pos[0].Z.ToString("F3");
            }

            lblCleanOnStart.Text = TaskWeight.CleanOnStart.ToString();
            lblNoOfPurge.Text = TaskWeight.PurgeCount.ToString();

            lblStartMeasDelay.Text = TaskWeight.StartMeasDelay.ToString();
            lblWeightPreWaitTime.Text = TaskWeight.PreWaitTime.ToString();

            lblZUpDist.Text = TaskWeight.ZUpDist.ToString();
            lblZUpSpeed.Text = TaskWeight.ZUpSpeed.ToString();

            lblWeightPostWaitTime.Text = TaskWeight.PostWaitTime.ToString();
            lblEndMeasDelay.Text = TaskWeight.EndMeasDelay.ToString();

            lblMeasPosMthd.Text = TaskWeight.MeasPosMethod.ToString();
            lblMeasPosPCD.Text = TaskWeight.MeasPosPCD.ToString();
            lblMeasPosCount.Text = TaskWeight.MeasPosCount.ToString();
        }

        private void lblCleanOnStart_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Clean On Start", ref TaskWeight.CleanOnStart);
            UpdateDisplay();
        }
        private void lblNoOfPurge_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, No Of Purge (count)", ref TaskWeight.PurgeCount, 0, 100);
            UpdateDisplay();
       }

        private void lblStartMeasDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Start Measure Delay (ms)", ref TaskWeight.StartMeasDelay, 0, 30000);
            UpdateDisplay();
        }
        private void lblWeightPreWaitTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, PreWait Time (ms)", ref TaskWeight.PreWaitTime, 0, 10000);
            UpdateDisplay();
        }

        private void lblZUpDist_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Z Up Dist (mm)", ref TaskWeight.ZUpDist, 0, 10000);
            UpdateDisplay();
        }
        private void lblZUpSpeed_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Z Up Speed (mm/s)", ref TaskWeight.ZUpSpeed, 1, 500);
            UpdateDisplay();
        }

        private void lblWeightPostWaitTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, PreWait Time (ms)", ref TaskWeight.PostWaitTime, 0, 10000);
            UpdateDisplay();
        }
        private void lblEndMeasDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, End Measure Delay (ms)", ref TaskWeight.EndMeasDelay, 0, 30000);
            UpdateDisplay();
        }

        private void lblMeasPosMthd_Click(object sender, EventArgs e)
        {
            int i = (int)TaskWeight.MeasPosMethod;
            UC.AdjustExec("Weight Setting, Measure Pos Method", ref i, TaskWeight.MeasPosMethod);
            TaskWeight.MeasPosMethod = (TaskWeight.EMeasPosMethod)i;
            UpdateDisplay();
        }
        private void lblMeasPosPCD_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Measure Pos PCD (mm)", ref TaskWeight.MeasPosPCD, 0, 20);
            UpdateDisplay();
        }
        private void lblMeasPosCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Measure Pos Count", ref TaskWeight.MeasPosCount, 1, 36);
            UpdateDisplay();
        }

        private void btn_SetNeedleWeightPos_Click(object sender, EventArgs e)
        {
            TaskWeight.Needle_Weight_Pos[0].X = TaskGantry.GXPos();
            TaskWeight.Needle_Weight_Pos[0].Y = TaskGantry.GYPos();
            TaskWeight.Needle_Weight_Pos[0].Z = TaskGantry.GZPos();

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
            }
            else
            {
                TaskWeight.Needle_Weight_Pos[1].X = 0;
                TaskWeight.Needle_Weight_Pos[1].Y = 0;
                TaskWeight.Needle_Weight_Pos[1].Z = 0;
            }
            TaskDisp.TaskMoveGZZ2Up();
            UpdateDisplay();

        }
        private void btn_GotoNeedleWeightPos_Click(object sender, EventArgs e)
        {
            TaskWeight.TaskGotoWeight(1, true);
        }
        private void btn_SetNeedle2WeightPos_Click(object sender, EventArgs e)
        {
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                TaskWeight.Needle_Weight_Pos[1].Z = TaskGantry.GZ2Pos();
            }
            else
            {

            }
            TaskDisp.TaskMoveGZZ2Up();
            UpdateDisplay();
        }
        private void btn_GotoNeedle2WeightPos_Click(object sender, EventArgs e)
        {
            TaskWeight.TaskGotoWeight(2, true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TaskWeight.SaveSetup(DispProg.Pump_Type.ToString());
        }
        private void btnJog_Click(object sender, EventArgs e)
        {
            frm_DispCore_JogGantry2 frm_Jog = new frm_DispCore_JogGantry2();
            frm_Jog.TopMost = true;
            frm_Jog.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
