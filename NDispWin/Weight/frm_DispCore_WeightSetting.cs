using System;
using System.Windows.Forms;

namespace NDispWin
{
    public partial class frm_DispCore_WeightSetting : Form
    {
        public frm_DispCore_WeightSetting()
        {
            InitializeComponent();
            GControl.LogForm(this);

            //UpdateCombox();
            btn_SetNeedle2WeightPos.Visible = GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2;

            btn_Close.Visible = true;
        }

        private void frm_DispCore_WeightSetting_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            UpdateDisplay();
        }
        private void frm_DispCore_WeightSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskDisp.TaskMoveGZUp();
        }

        private void UpdateDisplay()
        {
            //combox_SetupName.Text = GDefine.WeightSetup;
            this.Text = "Weight Settings [" + DispProg.Pump_Type.ToString() + "]";

            #region Meas Tab
            //lbl_MeasSpec.Text = DispProg.Target_Weight.ToString("f5");
            lbl_MeasSpec.Text = TaskWeight.MeasureSpec.ToString("f5");
            lbl_MeasSpecTol.Text = TaskWeight.MeasureSpecTol.ToString("f5");
            d_TolPcnt = (TaskWeight.MeasureSpecTol / TaskWeight.MeasureSpec) * 100;
            d_TolPcnt = Math.Round(d_TolPcnt, 1);
            lbl_MeasSpecTolPc.Text = d_TolPcnt.ToString("f1");
            lbl_MeasCount.Text = TaskWeight.MeasureCount.ToString();
            lbl_Meas_RequireOnLotStart.Text = TaskWeight.Meas_RequireOnLotStart.ToString();
            #endregion

            //lbl_DotsPerSample.Text = (DispProg.DotsPerSample_Meas > 0 ? "P|" : "") + TaskWeight.iDotsPerSample.ToString();
            //lbl_OutputResult.Text = (DispProg.DotsPerSample_Meas > 0 ? "P|" : "") + TaskWeight.eOutputResult.ToString();
            lbl_DotsPerSample.Text = TaskWeight.DotsPerSample.ToString();
            lbl_OutputResult.Text = TaskWeight.OutputResult.ToString();
            lblCalSample.Text = (DispProg.DotsPerSample_Cal > 0 ? "Recipe Dots/Sample " + 
                TaskWeight.iDotsPerSample(TaskWeight.EMeasType.Cal).ToString() + ", " + TaskWeight.eOutputResult(TaskWeight.EMeasType.Cal).ToString() : "");
            lblMeasSample.Text = (DispProg.DotsPerSample_Meas > 0 ? "Recipe Dots/Sample " +
                TaskWeight.iDotsPerSample(TaskWeight.EMeasType.Meas).ToString() + ", " + TaskWeight.eOutputResult(TaskWeight.EMeasType.Meas).ToString() : "");

            #region Calibration Tab
            lbl_Target.Text = TaskWeight.Cal_Meas_Weight.ToString("f4");
            lbl_CalTol.Text = TaskWeight.CalTol.ToString("f4");
            switch (TaskWeight.CalMeasType)
            {
                case TaskWeight.ECalMeasType.Density:
                    lbl_TargetTolUnit.Text = "(+/-" + TaskWeight.WEIGHT_UNIT + ")";
                    break;
                case TaskWeight.ECalMeasType.FR_mg_s:
                    lbl_TargetTolUnit.Text = "(+/-" + TaskWeight.CalMeasUnit + ")";
                    break;
                case TaskWeight.ECalMeasType.FR_mg_dot:
                    lbl_TargetTolUnit.Text = "(+/-" + TaskWeight.CalMeasUnit + ")";
                    break;
            }
            lbl_CalMaxAttempt.Text = TaskWeight.CalMaxAttempt.ToString();
            lbl_CalAcceptCount.Text = TaskWeight.CalAcceptCount.ToString();

            lbl_FPressMaxAdjRateUnit.Text = "(" + FPressCtrl.PressUnitStr + ")";
            lbl_InitialAdjPress.Text = FPressCtrl.GetPressStr(TaskWeight.CalMaxPressAdjRate);

            lbl_FPressUnit.Text = "(" + FPressCtrl.PressUnitStr + ")";
            lbl_FPressMin.Text = FPressCtrl.GetPress(DispProg.FPress_AdjMin).ToString(FPressCtrl.PressUnitStrFmt);
            lbl_FPressMax.Text = FPressCtrl.GetPress(DispProg.FPress_AdjMax).ToString(FPressCtrl.PressUnitStrFmt);


            lbl_CurrentCal1.Text = TaskWeight.CurrentCal[0].ToString("f4");
            lbl_CurrentCal2.Text = TaskWeight.CurrentCal[1].ToString("f4");

            lbl_Cal_RequireOnLotStart.Text = TaskWeight.Cal_RequireOnLotStart.ToString();
            lbl_Cal_RequireOnLoadProgram.Text = TaskWeight.Cal_RequireOnLoadProgram.ToString();
            #endregion

            lbl_Needle1WeightPosXYZ.Text = TaskWeight.Needle_Weight_Pos[0].GetString;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                lbl_Needle2WeightPosZ2.Text = TaskWeight.Needle_Weight_Pos[1].Z.ToString("F3");
            }
            else
            {
                lbl_Needle2WeightPosZ2.Text = TaskWeight.Needle_Weight_Pos[0].Z.ToString("F3");
            }

            lbl_WeightPurgeCount.Text = TaskWeight.PurgeCount.ToString();

            lbl_IgnoreAfterFillCount.Text = TaskWeight.IgnoreAfterFillCount.ToString();

            lbl_WeightPreWaitTime.Text = TaskWeight.PreWaitTime.ToString();
            if (TaskWeight.DispTime == 0)
                lbl_WeightDispTime.Text = "(Auto)";
            else
                lbl_WeightDispTime.Text = TaskWeight.DispTime.ToString();
            lbl_WeightPostWaitTime.Text = TaskWeight.PostWaitTime.ToString();
            lbl_ZUpDist.Text = TaskWeight.ZUpDist.ToString();
            lbl_ZUpSpeed.Text = TaskWeight.ZUpSpeed.ToString();

            lbl_StartMeasDelay.Text = TaskWeight.StartMeasDelay.ToString();
            lbl_EndMeasDelay.Text = TaskWeight.EndMeasDelay.ToString();

            lbl_MeasPosMthd.Text = TaskWeight.MeasPosMethod.ToString();
            lbl_MeasPosPCD.Text = TaskWeight.MeasPosPCD.ToString();
            lbl_MeasPosCount.Text = TaskWeight.MeasPosCount.ToString();

            lbl_CleanOnStart.Text = TaskWeight.CleanOnStart.ToString();
        }

        private void btn_SetNeedleWeightPos_Click(object sender, EventArgs e)
        {
            TaskWeight.Needle_Weight_Pos[0].X = TaskGantry.GXPos();
            TaskWeight.Needle_Weight_Pos[0].Y = TaskGantry.GYPos();
            TaskWeight.Needle_Weight_Pos[0].Z = TaskGantry.GZPos();

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                //TaskDisp.Needle_Weight_Pos[1].X = TaskGantry.GX2Pos() - TaskDisp.Head2_DefDistX;
                //TaskDisp.Needle_Weight_Pos[1].Y = TaskGantry.GY2Pos();
                //TaskDisp.Needle_Weight_Pos[1].Z = 0;// TaskGantry.GZ2Pos();
            }
            else
            {
                TaskWeight.Needle_Weight_Pos[1].X = 0;
                TaskWeight.Needle_Weight_Pos[1].Y = 0;
                TaskWeight.Needle_Weight_Pos[1].Z = 0;
            }
            TaskDisp.TaskMoveGZUp();
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
                //TaskWeight.Needle_Weight_Pos[1].X = TaskGantry.GX2Pos();
                //TaskWeight.Needle_Weight_Pos[1].Y = TaskGantry.GY2Pos();
                TaskWeight.Needle_Weight_Pos[1].Z = TaskGantry.GZ2Pos();
            }
            else
            {

            }
            TaskDisp.TaskMoveGZUp();
            UpdateDisplay();
        }
        private void btn_GotoNeedle2WeightPos_Click(object sender, EventArgs e)
        {
            TaskWeight.TaskGotoWeight(2, true);
        }

        #region Cal Setting
        private void lbl_CalTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Cal Target Tolerance (+/-mg)", ref TaskWeight.CalTol, 0.00001, 100);
            UpdateDisplay();
        }
        private void lbl_CalAttempt_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Cal Max Attempt (count)", ref TaskWeight.CalMaxAttempt, 5, TaskWeight.MAX_ATTEMPT);
            UpdateDisplay();
        }
        private void lbl_CalAcceptCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Cal Accept Count (count)", ref TaskWeight.CalAcceptCount, 1, 5);
            UpdateDisplay();
        }
        #endregion

        #region Sample Setting
        private void lbl_DotsPerSample_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Dots/Sample (count)", ref TaskWeight.DotsPerSample, 1, 500);
            UpdateDisplay();
        }
        private void lbl_OutputResult_Click(object sender, EventArgs e)
        {
            //if (TaskWeight.OutputResult == TaskWeight.EOutputResult.Total)
            //    TaskWeight.OutputResult = TaskWeight.EOutputResult.Average;
            //else
            //    TaskWeight.OutputResult = TaskWeight.EOutputResult.Total;

            int i = (int)TaskWeight.OutputResult;
            UC.AdjustExec("Weight Setting, Output Result", ref i, TaskWeight.OutputResult);
            TaskWeight.OutputResult = (TaskWeight.EOutputResult)i;

            UpdateDisplay();
        }
        #endregion

        #region Measure Settings
        //private void lbl_MeasureSpec_Click(object sender, EventArgs e)
        //{
        //    UC.AdjustExec("Weight Setting, Spec (mg)", ref TaskWeight.MeasureSpec, 0.001, 1000);
        //    TaskDisp.UpdateVolByWeight(TaskWeight.MeasureSpec, TaskWeight.MeasureSpec);
        //    UpdateDisplay();
        //}
        double d_TolPcnt = 0;
        private void lbl_SpecTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Spec Limit (+/-mg)", ref TaskWeight.MeasureSpecTol, 0.001, 100);
            d_TolPcnt = TaskWeight.MeasureSpecTol / TaskWeight.MeasureSpec;
            d_TolPcnt = Math.Round(d_TolPcnt, 3);
            UpdateDisplay();
        }
        private void lbl_SpecTolPc_Click(object sender, EventArgs e)
        {
            double d = d_TolPcnt;
            if (UC.AdjustExec("Weight Setting, Spec Limit (+/-%mg)", ref d, 0.01, 10))
            {
                //TaskWeight.MeasureSpecTol = DispProg.Target_Weight * (d / 100);
                TaskWeight.MeasureSpecTol = TaskWeight.MeasureSpec * (d / 100);
                TaskWeight.MeasureSpecTol = Math.Round(TaskWeight.MeasureSpecTol, 5);
            }
            UpdateDisplay();
        }
        private void lbl_MeasCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Meas Count (count)", ref TaskWeight.MeasureCount, 1, 2500);
            UpdateDisplay();
        }
        #endregion

        #region Common Settings
        private void lbl_WeightPurgeCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Purge Time (ms)", ref TaskWeight.PurgeCount, 0, 10000);
            UpdateDisplay();
        }
        private void lbl_IgnoreAfterFillCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Ignore After Fill Count (count)", ref TaskWeight.IgnoreAfterFillCount, 0, 10);
            UpdateDisplay();
        }

        private void lbl_WeightPreWaitTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, PreWait Time (ms)", ref TaskWeight.PreWaitTime, 0, 10000);
            UpdateDisplay();
        }
        private void lbl_WeightDispTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Dispense Time (ms)", ref TaskWeight.DispTime, 0, 60000);
            UpdateDisplay();
        }
        private void lbl_WeightPostWaitTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, PreWait Time (ms)", ref TaskWeight.PostWaitTime, 0, 10000);
            UpdateDisplay();
        }

        private void lbl_ZUpDist_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Z Up Dist (mm)", ref TaskWeight.ZUpDist, 0, 10000);
            UpdateDisplay();
        }
        private void lbl_ZUpSpeed_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Z Up Speed (mm/s)", ref TaskWeight.ZUpSpeed, 1, 500);
            UpdateDisplay();
        }

        private void lbl_StartMeasDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Start Measure Delay (ms)", ref TaskWeight.StartMeasDelay, 0, 30000);
            UpdateDisplay();
        }
        private void lbl_EndMeasDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, End Measure Delay (ms)", ref TaskWeight.EndMeasDelay, 0, 30000);
            UpdateDisplay();

        }

        private void lbl_MeasPosMthd_Click(object sender, EventArgs e)
        {
            int i = (int)TaskWeight.MeasPosMethod;
            UC.AdjustExec("Weight Setting, Measure Pos Method", ref i, TaskWeight.MeasPosMethod);
            TaskWeight.MeasPosMethod = (TaskWeight.EMeasPosMethod)i;
            UpdateDisplay();
        }
        private void lbl_MeasPosPCD_Click(object sender, EventArgs e)
        {            
            UC.AdjustExec("Weight Setting, Measure Pos PCD (mm)", ref TaskWeight.MeasPosPCD, 0, 20);
            UpdateDisplay();
        }
        private void lbl_MeasPosCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Measure Pos Count", ref TaskWeight.MeasPosCount, 1, 36);
            UpdateDisplay();
        }
        #endregion

        //private void combox_SetupName_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    if (combox_SetupName.SelectedItem.ToString().Contains("[New]"))
        //    {
        //        SaveFileDialog sfd = new SaveFileDialog();
        //        sfd.DefaultExt = ".ini";
        //        sfd.InitialDirectory = GDefine.WeightPath;
        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            GDefine.WeightSetup = Path.GetFileNameWithoutExtension(sfd.FileName);
        //            TaskWeight.SaveSetup(GDefine.WeightSetup);

        //            UpdateCombox();
        //        }
        //    }
        //    else
        //    {
        //        GDefine.WeightSetup = combox_SetupName.SelectedItem.ToString();
        //        TaskWeight.LoadSetup(GDefine.WeightSetup);
        //    }

        //    UpdateDisplay();
        //}
        private void btn_Save_Click(object sender, EventArgs e)
        {
            TaskWeight.SaveDefault();
            TaskWeight.SaveSetup(DispProg.Pump_Type.ToString());
        }

        frm_DispCore_JogGantryVision frm_Jog = new frm_DispCore_JogGantryVision();
        private void btn_Jog_Click(object sender, EventArgs e)
        {
            frm_Jog.ShowVision = false;
            frm_Jog.TopMost = true;
            frm_Jog.Show();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbl_CleanOnStart_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Clean On Start", ref TaskWeight.CleanOnStart);
            UpdateDisplay();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbl_CurrentCal1_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, CurrentCal[0]", ref TaskWeight.CurrentCal[0], 0, 10);
            UpdateDisplay();
        }

        private void lbl_CurrentCal2_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, CurrentCal[1]", ref TaskWeight.CurrentCal[1], 0, 10);
            UpdateDisplay();
        }

        private void lbl_FPressMin_Click(object sender, EventArgs e)
        {
            double Press = FPressCtrl.GetPress(DispProg.FPress_AdjMin);
            UC.AdjustExec("Weight Setting, FPress Min", ref Press, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            DispProg.FPress_AdjMin = FPressCtrl.PressGetMPa(Press);
            UpdateDisplay();
        }

        private void lbl_FPressMax_Click(object sender, EventArgs e)
        {
            double Press = FPressCtrl.GetPress(DispProg.FPress_AdjMax);
            UC.AdjustExec("Weight Setting, FPress Max", ref Press, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            DispProg.FPress_AdjMax = FPressCtrl.PressGetMPa(Press);
            UpdateDisplay();
        }

        private void lbl_InitialAdjPress_Click(object sender, EventArgs e)
        {
            double Press = FPressCtrl.GetPress(TaskWeight.CalMaxPressAdjRate);

            UC.AdjustExec("Weight Setting, CalMaxPressAdjRate", ref Press, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            TaskWeight.CalMaxPressAdjRate = FPressCtrl.PressGetMPa(Press);
            
            UpdateDisplay();
        }

        private void lbl_Meas_RequireOnLotStart_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Meas_RequireOnLotStart", ref TaskWeight.Meas_RequireOnLotStart);
            UpdateDisplay();
        }

        private void lbl_Cal_RequireOnLotStart_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Cal_RequireOnLotStart", ref TaskWeight.Cal_RequireOnLotStart);
            UpdateDisplay();
        }

        private void lbl_RequireCal_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Cal_RequireOnLoadProgram_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Setting, Cal_RequireOnLoadProgram", ref TaskWeight.Cal_RequireOnLoadProgram);
            UpdateDisplay();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }
    }
}
