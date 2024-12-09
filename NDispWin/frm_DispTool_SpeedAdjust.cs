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
    public partial class frm_DispTool_SpeedAdjust : Form
    {
        public bool SettingMode = false;
        public Point pPanelLeft = new Point(0, 0);
        public Point pPanelRight = new Point(0, 0);

        public frm_DispTool_SpeedAdjust()
        {
            InitializeComponent();
            GControl.LogForm(this);

            gboxSettings.Visible = false;
        }

        private void frm_DispTool_SpeedAdjust_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = "HM Pump Setup";

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            btnSettings.Visible = (ELevel)NUtils.UserAcc.Active.GroupID >= ELevel.Engineer;

            lbl_HeadA_DispSpeed.Text = DispProg.HM_HeadA_Disp_RPM.ToString("f2");
            lbl_HeadA_DispTime.Text = DispProg.HM_HeadA_Disp_Time.ToString();

            lbl_HeadA_BSuckSpeed.Text = DispProg.HM_HeadA_BSuck_RPM.ToString("f2");
            lbl_HeadA_BSuckTime.Text = DispProg.HM_HeadA_BSuck_Time.ToString("f2");

            lbl_FPressA.Text = FPressCtrl.GetPress(DispProg.FPress[0]).ToString(FPressCtrl.PressUnitStrFmt);
            lbl_PressUnit.Text = "(" + FPressCtrl.PressUnitStr + ")";

            lbl_DispSpeed_AdjMin.Text = DispProg.HM_Disp_RPM_AdjMin.ToString("f2");
            lbl_DispSpeed_AdjMax.Text = DispProg.HM_Disp_RPM_AdjMax.ToString("f2");
            lbl_DispTime_AdjMin.Text = DispProg.HM_Disp_Time_AdjMin.ToString();
            lbl_DispTime_AdjMax.Text = DispProg.HM_Disp_Time_AdjMax.ToString();
            lbl_FPress_AdjMin.Text = FPressCtrl.GetPress(DispProg.FPress_AdjMin).ToString(FPressCtrl.PressUnitStrFmt);
            lbl_FPress_AdjMax.Text = FPressCtrl.GetPress(DispProg.FPress_AdjMax).ToString(FPressCtrl.PressUnitStrFmt);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            TaskDisp.SetDispSpeed(true, true, DispProg.HM_HeadA_Disp_RPM, DispProg.HM_HeadB_Disp_RPM);
            TaskDisp.SetDispTime(true, true, DispProg.HM_HeadA_Disp_Time, DispProg.HM_HeadB_Disp_Time);
            TaskDisp.SetBSuckSpeed(true, true, DispProg.HM_HeadA_BSuck_RPM, DispProg.HM_HeadB_BSuck_RPM);
            TaskDisp.SetBSuckTime(true, true, DispProg.HM_HeadA_BSuck_Time, DispProg.HM_HeadB_BSuck_Time);

            Close();
        }

        private double[] GetMinMaxRPM
        {
            get
            {
                double d_MinSpeed = 1;
                double d_MaxSpeed = TaskDisp.HM_Max_RPM;

                if (DispProg.HM_Disp_RPM_AdjMin != 0) d_MinSpeed = DispProg.HM_Disp_RPM_AdjMin;
                if (DispProg.HM_Disp_RPM_AdjMax != 0) d_MaxSpeed = DispProg.HM_Disp_RPM_AdjMax;

                return new double[2] { d_MinSpeed, d_MaxSpeed };
            }
        }
        private void lbl_HeadASpeed_Click(object sender, EventArgs e)
        {
            DispProg.HM_HeadA_Disp_RPM = Math.Round(DispProg.HM_HeadA_Disp_RPM, 1);
            UC.AdjustExec("HeadA Disp Speed (RPM)", ref DispProg.HM_HeadA_Disp_RPM, GetMinMaxRPM[0], GetMinMaxRPM[1]);
            UpdateDisplay();
        }

        private int[] GetMinMaxDispTime
        {
            get
            {
                int min = 0;
                int max = 5000;

                if (DispProg.HM_Disp_Time_AdjMin != 0) min = DispProg.HM_Disp_Time_AdjMin;
                if (DispProg.HM_Disp_Time_AdjMax != 0) max = DispProg.HM_Disp_Time_AdjMax;

                return new int[2] {min, max};
            }
        }
        private void lbl_HeadA_DispTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("HeadA Disp Time (ms)", ref DispProg.HM_HeadA_Disp_Time, GetMinMaxDispTime[0], GetMinMaxDispTime[1]);
            UpdateDisplay();
        }

        private void lbl_HeadA_BSuckSpeed_Click(object sender, EventArgs e)
        {
            DispProg.HM_HeadA_BSuck_RPM = Math.Round(DispProg.HM_HeadA_BSuck_RPM, 1);
            UC.AdjustExec("HeadA Back Suck (RPM)", ref DispProg.HM_HeadA_BSuck_RPM, GetMinMaxRPM[0], GetMinMaxRPM[1]);
            UpdateDisplay();
        }

        private void lbl_HeadA_BSuckTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("HeadA Back Suck (Time)", ref DispProg.HM_HeadA_BSuck_Time, 0, 5000);
            UpdateDisplay();
        }

        private double[] GetMinMaxFPress
        {
            get
            {
                double d_Min = FPressCtrl.GetPressMin;
                double d_Max = FPressCtrl.GetPressMax;

                if (DispProg.FPress_AdjMin != 0) d_Min = FPressCtrl.GetPress(DispProg.FPress_AdjMin);
                if (DispProg.FPress_AdjMax != 0) d_Max = FPressCtrl.GetPress(DispProg.FPress_AdjMax);

                return new double[2] { d_Min, d_Max };
            }
        }
        private void lbl_FPressA_Click(object sender, EventArgs e)
        {
            FPressCtrl.AdjustPress_MPa(0, ref DispProg.FPress, GetMinMaxFPress[0], GetMinMaxFPress[1]);
            UpdateDisplay();
        }

        const int MinTime = 0;
        const int MaxTime = 5000;
        private void lbl_DispTime_AdjMin_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Pump Adjust, Disp Time Adj Min (ms)", ref DispProg.HM_Disp_Time_AdjMin, MinTime, MaxTime);
            UpdateDisplay();
        }
        private void lbl_DispTime_AdjMax_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Pump Adjust, Disp Time Adj Max (ms)", ref DispProg.HM_Disp_Time_AdjMax, MinTime, MaxTime);
            UpdateDisplay();
        }
        private void lbl_DispSpeed_AdjMin_Click(object sender, EventArgs e)
        {
            double d_MinSpeed = 0;
            double d_MaxSpeed = TaskDisp.HM_Max_RPM;

            UC.AdjustExec("Pump Adjust, Disp Speed Adj Min (RPM)", ref DispProg.HM_Disp_RPM_AdjMin, d_MinSpeed, d_MaxSpeed);
            UpdateDisplay();
        }
        private void lbl_DispSpeed_AdjMax_Click(object sender, EventArgs e)
        {
            double d_MinSpeed = 0;
            double d_MaxSpeed = TaskDisp.HM_Max_RPM;

            UC.AdjustExec("Pump Adjust, Disp Speed Adj Max (RPM)", ref DispProg.HM_Disp_RPM_AdjMax, d_MinSpeed, d_MaxSpeed);
            UpdateDisplay();
        }
        private void lbl_FPress_AdjMin_Click(object sender, EventArgs e)
        {
            double d = FPressCtrl.GetPress(DispProg.FPress_AdjMin);
            d = Math.Round(d, FPressCtrl.PressUnitDP);
            UC.AdjustExec("Pump Adjust, FPress Adj Min", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            DispProg.FPress_AdjMin = FPressCtrl.PressGetMPa(d);
            UpdateDisplay();
        }
        private void lbl_FPress_AdjMax_Click(object sender, EventArgs e)
        {
            double d = FPressCtrl.GetPress(DispProg.FPress_AdjMax);
            d = Math.Round(d, FPressCtrl.PressUnitDP);
            UC.AdjustExec("Pump Adjust, FPress Adj Max", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            DispProg.FPress_AdjMax = FPressCtrl.PressGetMPa(d);
            UpdateDisplay();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            gboxSettings.Visible = !gboxSettings.Visible;
        }

        private void lblHMTimer_Click(object sender, EventArgs e)
        {
            int i = DispProg.HM_Timer;
            UC.AdjustExec("Setup HM, Trigger Timer (s)", ref i, 0, 3600);
            DispProg.HM_Timer = i;
            UpdateDisplay();
        }

        private void btnTrig_MouseDown(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOn(true, false);
        }
        private void btnTrig_MouseUp(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOn(false, false);
        }
        bool trigTimerRunning = false;
        int tTrigOff = 0;
        private async void btnTimerTrig_Click(object sender, EventArgs e)
        {
            if (DispProg.HM_Timer > 0)
            {
                if (trigTimerRunning)
                {
                    trigTimerRunning = false;
                    return;
                }

                trigTimerRunning = true;
                await Task.Run(() =>
                {
                    try
                    {
                        this.Enable(false);
                        btnTimerTrig.Enable(true);

                        FPressCtrl.SetPress_MPa(DispProg.FPress);
                        TaskGantry.BVac1 = false;
                        TaskGantry.BPress1 = true;
                        TaskDisp.TrigOn(true, false);

                        tTrigOff = Environment.TickCount + (DispProg.HM_Timer * 1000);
                        while (Environment.TickCount < tTrigOff)
                        {
                            if (!trigTimerRunning) break;
                            Thread.Sleep(0);
                        }
                    }
                    finally
                    {
                        TaskDisp.TrigOn(false, false);
                        TaskGantry.BPress1 = false;
                        TaskGantry.BVac1 = true;

                        trigTimerRunning = false;
                        tTrigOff = 0;
                        this.Enable(true);
                    }
                });
                UpdateDisplay();
            }
        }
    }
}
