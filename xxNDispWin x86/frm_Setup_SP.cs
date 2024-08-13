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
    public partial class frm_Setup_SP : Form
    {
        public frm_Setup_SP()
        {
            InitializeComponent(); 
            GControl.LogForm(this);
        }

        private void frmSetup_SP_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = "SynchroPulse (PS) Pump Setup";

            tmr500ms.Enabled = true;
            
            UpdateDisplay();
        }
        private void frm_Setup_SP_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr500ms.Enabled = false;
        }

        private void UpdateDisplay()
        {
            btnSettings.Visible = (ELevel)NUtils.UserAcc.Active.GroupID >= ELevel.Engineer;
            gbAdvance.Enabled = (ELevel)NUtils.UserAcc.Active.GroupID >= ELevel.Engineer;

            if (TaskGantry._SvFPress1.Status)
                btn_FPress.BackColor = Color.Red;
            else
                btn_FPress.BackColor = this.BackColor;

            if (TaskGantry._SvPortC1.Status)
                btn_PPress.BackColor = Color.Red;
            else
                btn_PPress.BackColor = this.BackColor;

            lbl_FPressA.Text = FPressCtrl.GetPressStr(DispProg.FPress[0]);
            lbl_FPressH.Text = FPressCtrl.GetPressStr(DispProg.FPressH[0]);
            lbl_FPressB.Text = FPressCtrl.GetPressStr(DispProg.FPress[1]);

            lbl_PressUnit.Text = "(" + FPressCtrl.PressUnitStr + ")";
            lbl_Press2Unit.Text = "(" + FPressCtrl.PressUnitStr + ")";

            lbl_DispTime.Text = DispProg.SP.DispTime[0].ToString();

            lbl_PulseOnDelay.Text = Math.Abs(DispProg.SP.PulseOnDelay[0]).ToString();
            lbl_PulseOffDelay.Text = Math.Abs(DispProg.SP.PulseOffDelay[0]).ToString();

            rbPOnDelay.Checked = DispProg.SP.PulseOnDelay[0] >= 0;
            rbPOnEarly.Checked = DispProg.SP.PulseOnDelay[0] < 0;
            rbPOffDelay.Checked = DispProg.SP.PulseOffDelay[0] >= 0;
            rbPOffEarly.Checked = DispProg.SP.PulseOffDelay[0] < 0;

            lbl_FPress_AdjMin.Text = $"{DispProg.FPress_AdjMin:f3}";
            lbl_FPress_AdjMax.Text = $"{DispProg.FPress_AdjMax:f3}";
            lbl_PPress_AdjMin.Text = $"{DispProg.PPress_AdjMin:f3}";
            lbl_PPress_AdjMax.Text = $"{DispProg.PPress_AdjMax:f3}";
        }

        int i_DownTime = 0;
        int i_ToggleDelay = 500;
        private void btn_FPress_Click(object sender, EventArgs e)
        {

        }
        private void btn_FPress_MouseDown(object sender, MouseEventArgs e)
        {
            if (TaskGantry.BPress1)
            {
                TaskGantry.BPress1 = false;
            }
            else
            {
                i_DownTime = Environment.TickCount;
                TaskGantry.BPress1 = true;
            }
            UpdateDisplay();
        }
        private void btn_FPress_MouseUp(object sender, MouseEventArgs e)
        {
            if (Environment.TickCount > i_DownTime + i_ToggleDelay)
            {
                TaskGantry.BPress1 = false;
            }
            UpdateDisplay();
        }

        private void btn_PPress_Click(object sender, EventArgs e)
        {

        }
        private void btn_PPress_MouseDown(object sender, MouseEventArgs e)
        {
            if (TaskGantry.DispPortC1)
            {
                TaskGantry.DispPortC1 = false;
            }
            else
            {
                i_DownTime = Environment.TickCount;
                TaskGantry.DispPortC1 = true;
            }
            UpdateDisplay();

        }
        private void btn_PPress_MouseUp(object sender, MouseEventArgs e)
        {
            if (Environment.TickCount > i_DownTime + i_ToggleDelay)
            {
                TaskGantry.DispPortC1 = false;
            }
            UpdateDisplay();
        }

        bool FPressHTimerRunning = false;
        int tcFPressHOff = 0;
        private async void btn_FPressH_Click(object sender, EventArgs e)
        {
            if (DispProg.FPressH_Timer > 0)
            {
                if (FPressHTimerRunning)
                {
                    FPressHTimerRunning = false;
                    return;
                }

                FPressHTimerRunning = true;
                await Task.Run(() =>
                {
                    try
                    {
                        this.Enable(false);
                        btn_FPressH.Enable(true);

                        FPressCtrl.SetPress_MPa(DispProg.FPressH);
                        TaskGantry.BVac1 = false;
                        TaskGantry.BPress1 = true;

                        tcFPressHOff = Environment.TickCount + (DispProg.FPressH_Timer * 1000);
                        while (Environment.TickCount < tcFPressHOff)
                        {
                            if (!FPressHTimerRunning) break;
                            Thread.Sleep(0);
                        }
                    }
                    finally
                    {
                        TaskGantry.BPress1 = false;
                        TaskGantry.BVac1 = true;
                        FPressCtrl.SetPress_MPa(DispProg.FPress);
                        //UpdateDisplay();

                        FPressHTimerRunning = false;
                        tcFPressHOff = 0;
                        this.Enable(true);
                    }
                });
                UpdateDisplay();
            }
        }
        private void btn_FPressH_MouseDown(object sender, MouseEventArgs e)
        {
            if (DispProg.FPressH_Timer == 0)
            {
                if (TaskGantry.BPress1)
                {
                    TaskGantry.BPress1 = false;
                    FPressCtrl.SetPress_MPa(DispProg.FPress);
                }
                else
                {
                    FPressCtrl.SetPress_MPa(DispProg.FPressH);
                    i_DownTime = Environment.TickCount;
                    TaskGantry.BVac1 = false;
                    TaskGantry.BPress1 = true;
                }
                UpdateDisplay();
            }
        }
        private void btn_FPressH_MouseUp(object sender, MouseEventArgs e)
        {
            if (DispProg.FPressH_Timer == 0)
            {
                TaskGantry.BPress1 = false;
                TaskGantry.BVac1 = true;
                FPressCtrl.SetPress_MPa(DispProg.FPress);
                UpdateDisplay();
            }
        }

        private void btn_POpen_Click(object sender, EventArgs e)
        {

        }

        private void btn_Shot_Click(object sender, EventArgs e)
        {
            Enabled = false;

            TaskGantry.BPress1 = false;
            TaskGantry.DispPortC1 = false;

            try
            {
                TaskDisp.SP.SP_Shot((double)DispProg.SP.DispTime[0]);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ex error - " + Ex.Message.ToString());
            }

            UpdateDisplay();
            Enabled = true;
        }

        private void lbl_FPressA_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;
                if (DispProg.FPress_AdjMin != 0) d_Min = FPressCtrl.GetPress(DispProg.FPress_AdjMin);
                if (DispProg.FPress_AdjMax != 0) d_Max = FPressCtrl.GetPress(DispProg.FPress_AdjMax);

            try
            {
                FPressCtrl.AdjustPress_MPa(0, ref DispProg.FPress, d_Min, d_Max);
                Para.FPress0.Set($"{DispProg.FPress[0]:f3}");
                UpdateDisplay();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ex error - " + Ex.Message.ToString());
            }
        }
        private void lbl_FPressH_Click(object sender, EventArgs e)
        {
            try
            {
                FPressCtrl.AdjustPress_MPa(0, ref DispProg.FPressH, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
                FPressCtrl.SetPress_MPa(DispProg.FPress);
                UpdateDisplay();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ex error - " + Ex.Message.ToString());
            }
        }
        private void lbl_FPressB_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;
            if (DispProg.FPress_AdjMin != 0) d_Min = FPressCtrl.GetPress(DispProg.PPress_AdjMin);
            if (DispProg.FPress_AdjMax != 0) d_Max = FPressCtrl.GetPress(DispProg.PPress_AdjMax);

            try
            {
                FPressCtrl.AdjustPress_MPa(1, ref DispProg.FPress, d_Min, d_Max);
                Para.FPress1.Set($"{DispProg.FPress[1]:f3}");
                UpdateDisplay();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ex error - " + Ex.Message.ToString());
            }
        }

        private void lbl_DispTime_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("SP.DispTime", ref DispProg.SP.DispTime[0], 0, 5000))
                UpdateDisplay();
        }
        private void lbl_PulseOnDelay_Click(object sender, EventArgs e)
        {
            double d = Math.Abs(DispProg.SP.PulseOnDelay[0]);

            if (UC.AdjustExec("SP.PulseOnDelay", ref d, 0, 5000))
            {
                if (rbPOnEarly.Checked) d = -d;
                DispProg.SP.PulseOnDelay[0] = d;
            }
            UpdateDisplay();
        }
        private void lbl_PulseOffDelay_Click(object sender, EventArgs e)
        {
            double d = Math.Abs(DispProg.SP.PulseOffDelay[0]);

            if (UC.AdjustExec("SP.PulseOffDelay", ref d, 0, 5000))
            {
                if (rbPOffEarly.Checked) d = -d;
                DispProg.SP.PulseOffDelay[0] = d;
            }
            UpdateDisplay();
        }

        private void lbl_PulseCount_Click(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Press2Unit_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lbl_PressUnit_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnPPressOnDelayHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Define the interval to trigger P Pressure after F Pressure. The interval can be delay or early of F Pressure.");
        }

        private void rbPOnDelay_Click(object sender, EventArgs e)
        {
            DispProg.SP.PulseOnDelay[0] = Math.Abs(DispProg.SP.PulseOnDelay[0]);
            UpdateDisplay();
        }

        private void rbPOnEarly_Click(object sender, EventArgs e)
        {
            DispProg.SP.PulseOnDelay[0] = -Math.Abs(DispProg.SP.PulseOnDelay[0]);
            UpdateDisplay();
        }

        private void rbPOffDly_Click(object sender, EventArgs e)
        {
            DispProg.SP.PulseOffDelay[0] = Math.Abs(DispProg.SP.PulseOffDelay[0]);
            UpdateDisplay();
        }

        private void rbPOffEarly_Click(object sender, EventArgs e)
        {
            DispProg.SP.PulseOffDelay[0] = -Math.Abs(DispProg.SP.PulseOffDelay[0]);
            UpdateDisplay();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            gbSettings.Visible = !gbSettings.Visible;
        }

        private void lbl_FPress_AdjMin_Click(object sender, EventArgs e)
        {
            double d = FPressCtrl.GetPress(DispProg.FPress_AdjMin);
            d = Math.Round(d, FPressCtrl.PressUnitDP);
            UC.AdjustExec("Setup SP, FPress Adj Min", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            DispProg.FPress_AdjMin = FPressCtrl.PressGetMPa(d);
            UpdateDisplay();
        }

        private void lbl_FPress_AdjMax_Click(object sender, EventArgs e)
        {
            double d = FPressCtrl.GetPress(DispProg.FPress_AdjMax);
            d = Math.Round(d, FPressCtrl.PressUnitDP);
            UC.AdjustExec("Setup SP, FPress Adj Max", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            DispProg.FPress_AdjMax = FPressCtrl.PressGetMPa(d);
            UpdateDisplay();
        }

        private void lbl_PPress_AdjMin_Click(object sender, EventArgs e)
        {
            double d = FPressCtrl.GetPress(DispProg.PPress_AdjMin);
            d = Math.Round(d, FPressCtrl.PressUnitDP);
            UC.AdjustExec("Setup SP, PPress Adj Min", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            DispProg.PPress_AdjMin = FPressCtrl.PressGetMPa(d);
            UpdateDisplay();
        }

        private void lbl_PPress_AdjMax_Click(object sender, EventArgs e)
        {
            double d = FPressCtrl.GetPress(DispProg.PPress_AdjMax);
            d = Math.Round(d, FPressCtrl.PressUnitDP);
            UC.AdjustExec("Setup SP, PPress Adj Max", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            DispProg.PPress_AdjMax = FPressCtrl.PressGetMPa(d);
            UpdateDisplay();
        }

        private void lblFPressHTimer_Click(object sender, EventArgs e)
        {
            int i = DispProg.FPressH_Timer;
            UC.AdjustExec("Setup SP, FPressH Timer (s)", ref i, 0, 3600);
            DispProg.FPressH_Timer = i;
            UpdateDisplay();
        }

        private void tmr500ms_Tick(object sender, EventArgs e)
        {
            double d = (double)(tcFPressHOff - Environment.TickCount) / 1000;
            int t = (int)Math.Ceiling(d);
            string st = t > 0 ? $"{t} / " : "";
            lblFPressHTimer.Text = $"{st}{DispProg.FPressH_Timer}";
        }
    }
}
