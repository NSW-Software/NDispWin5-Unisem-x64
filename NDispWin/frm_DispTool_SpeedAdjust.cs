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
    public partial class frm_DispTool_SpeedAdjust : Form
    {
        public bool SettingMode = false;
        public Point pPanelLeft = new Point(0, 0);
        public Point pPanelRight = new Point(0, 0);

        public frm_DispTool_SpeedAdjust()
        {
            InitializeComponent();
            GControl.LogForm(this);

            pnl_FPressA.Visible = FPressCtrl.Enabled;
            lbl_FPressA.Visible = FPressCtrl.Enabled;
            lbl_FPressB.Visible = FPressCtrl.Enabled;
            pnl_FPress2.Visible = FPressCtrl.Enabled;

            pPanelLeft = gbox_HeadA.Location;
            pPanelRight = gbox_HeadB.Location;
        }

        private void frm_DispTool_SpeedAdjust_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Pump Speed Adjust";
            gbox_Settings.Visible = SettingMode;

            if (DispProg.rt_Layouts[0].MapOrigin == TLayout.EMapOrigin.Right)
            {
                gbox_HeadA.Location = pPanelRight;
                gbox_HeadB.Location = pPanelLeft;
            }

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_HeadA_DispSpeed.Text = DispProg.HM_HeadA_Disp_RPM.ToString("f2");
            lbl_HeadB_DispSpeed.Text = DispProg.HM_HeadB_Disp_RPM.ToString("f2");
            lbl_HeadA_DispTime.Text = DispProg.HM_HeadA_Disp_Time.ToString();
            lbl_HeadB_DispTime.Text = DispProg.HM_HeadB_Disp_Time.ToString();

            lbl_DispSpeed_AdjMin.Text = DispProg.HM_Disp_RPM_AdjMin.ToString("f2");
            lbl_DispSpeed_AdjMax.Text = DispProg.HM_Disp_RPM_AdjMax.ToString("f2");
            lbl_DispTime_AdjMin.Text = DispProg.HM_Disp_Time_AdjMin.ToString();
            lbl_DispTime_AdjMax.Text = DispProg.HM_Disp_Time_AdjMax.ToString();

            if (!SettingMode)
            {
                lbl_HeadA_BSuckSpeed.BackColor = this.BackColor;
                lbl_HeadB_BSuckSpeed.BackColor = this.BackColor;
                lbl_HeadA_BSuckTime.BackColor = this.BackColor;
                lbl_HeadB_BSuckTime.BackColor = this.BackColor;
            }
            lbl_HeadA_BSuckSpeed.Text = DispProg.HM_HeadA_BSuck_RPM.ToString("f2");
            lbl_HeadB_BSuckSpeed.Text = DispProg.HM_HeadB_BSuck_RPM.ToString("f2");
            lbl_HeadA_BSuckTime.Text = DispProg.HM_HeadA_BSuck_Time.ToString("f2");
            lbl_HeadB_BSuckTime.Text = DispProg.HM_HeadB_BSuck_Time.ToString("f2");

            lbl_FPressA.Text = FPressCtrl.GetPress(DispProg.FPress[0]).ToString(FPressCtrl.PressUnitStrFmt);
            lbl_FPressB.Text = FPressCtrl.GetPress(DispProg.FPress[1]).ToString(FPressCtrl.PressUnitStrFmt);
            lbl_PressUnit.Text = "(" + FPressCtrl.PressUnitStr + ")";

            lbl_FPress_AdjMin.Text = FPressCtrl.GetPress(DispProg.FPress_AdjMin).ToString(FPressCtrl.PressUnitStrFmt);
            lbl_FPress_AdjMax.Text = FPressCtrl.GetPress(DispProg.FPress_AdjMax).ToString(FPressCtrl.PressUnitStrFmt);
        }
       
        private void btn_Close_Click(object sender, EventArgs e)
        {
            //TaskDisp.UpdateDispSpeed(LogPump.EVolAdjType.Manual, true, true);
            //TaskDisp.UpdateDispTime(LogPump.EVolAdjType.Manual, true, true);
            //TaskDisp.UpdateBSuckSpeed(LogPump.EVolAdjType.Manual, true, true);
            //TaskDisp.UpdateBSuckTime(LogPump.EVolAdjType.Manual, true, true);

            TaskDisp.SetDispSpeed(true, true, DispProg.HM_HeadA_Disp_RPM, DispProg.HM_HeadB_Disp_RPM);
            TaskDisp.SetDispTime(true, true, DispProg.HM_HeadA_Disp_Time, DispProg.HM_HeadB_Disp_Time);
            TaskDisp.SetBSuckSpeed(true, true, DispProg.HM_HeadA_BSuck_RPM, DispProg.HM_HeadB_BSuck_RPM);
            TaskDisp.SetBSuckTime(true, true, DispProg.HM_HeadA_BSuck_Time, DispProg.HM_HeadB_BSuck_Time);

            Close();
        }

        private void btn_CopyA_Click(object sender, EventArgs e)
        {
            DispProg.HM_HeadB_Disp_RPM = DispProg.HM_HeadA_Disp_RPM;
            DispProg.HM_HeadB_Disp_Time = DispProg.HM_HeadA_Disp_Time;
            DispProg.HM_HeadB_BSuck_RPM = DispProg.HM_HeadA_BSuck_RPM;
            DispProg.HM_HeadB_BSuck_Time = DispProg.HM_HeadA_BSuck_Time;

            UpdateDisplay();
        }

        private void lbl_HeadASpeed_Click(object sender, EventArgs e)
        {
            double d_MinSpeed = 1;
            double d_MaxSpeed = TaskDisp.HM_Max_RPM;
            DispProg.HM_HeadA_Disp_RPM = Math.Round(DispProg.HM_HeadA_Disp_RPM, 1);

            if (!SettingMode)
            {
                if (DispProg.HM_Disp_RPM_AdjMin != 0) d_MinSpeed = DispProg.HM_Disp_RPM_AdjMin;
                if (DispProg.HM_Disp_RPM_AdjMax != 0) d_MaxSpeed = DispProg.HM_Disp_RPM_AdjMax;
            }

            UC.AdjustExec("HeadA Disp Speed (RPM)", ref DispProg.HM_HeadA_Disp_RPM, d_MinSpeed, d_MaxSpeed);
            UpdateDisplay();
        }
        private void lbl_HeadBSpeed_Click(object sender, EventArgs e)
        {
            double d_MinSpeed = 1;
            double d_MaxSpeed = TaskDisp.HM_Max_RPM;
            DispProg.HM_HeadB_Disp_RPM = Math.Round(DispProg.HM_HeadB_Disp_RPM, 1);

            if (!SettingMode)
            {
                if (DispProg.HM_Disp_RPM_AdjMin != 0) d_MinSpeed = DispProg.HM_Disp_RPM_AdjMin;
                if (DispProg.HM_Disp_RPM_AdjMax != 0) d_MaxSpeed = DispProg.HM_Disp_RPM_AdjMax;
            }

            UC.AdjustExec("HeadB Disp Speed (RPM)", ref DispProg.HM_HeadB_Disp_RPM, d_MinSpeed, d_MaxSpeed);
            UpdateDisplay();
        }
        private void lbl_HeadA_DispTime_Click(object sender, EventArgs e)
        {
            int Min = 0;
            int Max = 5000;
            if (!SettingMode)
            {
                if (DispProg.HM_Disp_Time_AdjMin != 0) Min = DispProg.HM_Disp_Time_AdjMin;
                if (DispProg.HM_Disp_Time_AdjMax != 0) Max = DispProg.HM_Disp_Time_AdjMax;
            }

            UC.AdjustExec("HeadA Disp Time (ms)", ref DispProg.HM_HeadA_Disp_Time, Min, Max);
            UpdateDisplay();
        }
        private void lbl_HeadB_DispTime_Click(object sender, EventArgs e)
        {
            int Min = 0;
            int Max = 5000;
            if (!SettingMode)
            {
                if (DispProg.HM_Disp_Time_AdjMin != 0) Min = DispProg.HM_Disp_Time_AdjMin;
                if (DispProg.HM_Disp_Time_AdjMax != 0) Max = DispProg.HM_Disp_Time_AdjMax;
            }

            UC.AdjustExec("HeadB Disp Time (ms)", ref DispProg.HM_HeadB_Disp_Time, Min, Max);
            UpdateDisplay();
        }

        private void lbl_HeadA_BSuckSpeed_Click(object sender, EventArgs e)
        {
            if (!SettingMode) return;

            double d_MinSpeed = 1;
            double d_MaxSpeed = TaskDisp.HM_Max_RPM;
            DispProg.HM_HeadA_BSuck_RPM = Math.Round(DispProg.HM_HeadA_BSuck_RPM, 1);

            UC.AdjustExec("HeadA Back Suck (RPM)", ref DispProg.HM_HeadA_BSuck_RPM, d_MinSpeed, d_MaxSpeed);
            UpdateDisplay();
        }
        private void lbl_HeadB_BSuckSpeed_Click(object sender, EventArgs e)
        {
            if (!SettingMode) return;

            double d_MinSpeed = 1;
            double d_MaxSpeed = TaskDisp.HM_Max_RPM;
            DispProg.HM_HeadB_BSuck_RPM = Math.Round(DispProg.HM_HeadB_BSuck_RPM, 1);

            UC.AdjustExec("HeadB Back Suck (RPM)", ref DispProg.HM_HeadB_BSuck_RPM, d_MinSpeed, d_MaxSpeed);
            UpdateDisplay();
        }
        private void lbl_HeadA_BSuckTime_Click(object sender, EventArgs e)
        {
            if (!SettingMode) return;

            UC.AdjustExec("HeadA Back Suck (Time)", ref DispProg.HM_HeadA_BSuck_Time, 0, 5000);
            UpdateDisplay();
        }
        private void lbl_HeadB_BSuckTime_Click(object sender, EventArgs e)
        {
            if (!SettingMode) return;

            UC.AdjustExec("HeadB Back Suck (Time)", ref DispProg.HM_HeadB_BSuck_Time, 0, 5000);
            UpdateDisplay();
        }

        private void lbl_FPressA_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;
            if (!SettingMode)
            {
                if (DispProg.FPress_AdjMin != 0) d_Min = FPressCtrl.GetPress(DispProg.FPress_AdjMin);
                if (DispProg.FPress_AdjMax != 0) d_Max = FPressCtrl.GetPress(DispProg.FPress_AdjMax);
            }

            FPressCtrl.AdjustPress_MPa(0, ref DispProg.FPress, d_Min, d_Max);
            UpdateDisplay();
        }
        private void lbl_FPressB_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;
            if (!SettingMode)
            {
                if (DispProg.FPress_AdjMin != 0) d_Min = FPressCtrl.GetPress(DispProg.FPress_AdjMin);
                if (DispProg.FPress_AdjMax != 0) d_Max = FPressCtrl.GetPress(DispProg.FPress_AdjMax);
            }

            FPressCtrl.AdjustPress_MPa(1, ref DispProg.FPress, d_Min, d_Max);
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
    }
}
