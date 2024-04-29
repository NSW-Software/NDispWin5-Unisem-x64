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
    public partial class frm_Setup_PJ : Form
    {
        public frm_Setup_PJ()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_Setup_PJ_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = "PreciseJet (PJ) Pump Adjust";
            TaskGantry.BPress1 = true;
            UpdateDisplay();
        }

        private void frm_Setup_PJ_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskGantry.BPress1 = false;
        }

        private void UpdateDisplay()
        {
            //lbl_FPressA.Text = FPressCtrl.GetPress(0, ref DispProg.FPress).ToString("f1");
            lbl_FPressA.Text = FPressCtrl.GetPress(DispProg.FPress[0]).ToString("f1");
            if (TaskGantry._SvFPress1.Status)
                btn_BPress.BackColor = Color.Red;
            else
                btn_BPress.BackColor = this.BackColor;
            if (TaskGantry._SvPortC1.Status)
                btn_POpen.BackColor = Color.Red;
            else
                btn_POpen.BackColor = this.BackColor;
            lbl_PressUnit.Text = "(" + FPressCtrl.PressUnitStr + ")";

            lbl_OpenTime.Text = DispProg.PJ.OpenTime[0].ToString();
            lbl_CloseDelay.Text = DispProg.PJ.CloseDelay[0].ToString();
            lbl_PulseCount.Text = DispProg.PJ.Pulse[0].ToString();

            double f= 0;
            try
            {
                double P = DispProg.PJ.OpenTime[0] + DispProg.PJ.CloseDelay[0];
                P = P / 1000;
                f = 1 / P;
            }
            catch
            { }

            lbl_Frequency.Text = f.ToString("f2");
        }

        int i_DownTime = 0;
        int i_ToggleDelay = 500;
        private void btn_BPress_Click(object sender, EventArgs e)
        {

        }
        private void btn_BPress_MouseDown(object sender, MouseEventArgs e)
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
        private void btn_BPress_MouseUp(object sender, MouseEventArgs e)
        {
            if (Environment.TickCount > i_DownTime + i_ToggleDelay)
            {
                TaskGantry.BPress1 = false;
            }
            UpdateDisplay();
        }

        private void btn_POpen_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void btn_POpen_MouseDown(object sender, MouseEventArgs e)
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
        private void btn_POpen_MouseUp(object sender, MouseEventArgs e)
        {
            if (Environment.TickCount > i_DownTime + i_ToggleDelay)
            {
                TaskGantry.DispPortC1 = false;
            }
            UpdateDisplay();
        }

        private void lbl_FPressA_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;

            FPressCtrl.AdjustPress_MPa(0, ref DispProg.FPress, d_Min, d_Max);
            UpdateDisplay();
        }

        private void lbl_OpenTime_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("PJ.OpenTime", ref DispProg.PJ.OpenTime[0], 0.1, 50))
                UpdateDisplay();
        }
        private void lbl_CloseDelay_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("PJ.CloseDelay", ref DispProg.PJ.CloseDelay[0], 0.1, 50))
                UpdateDisplay();
        }

        private void btn_Shot_Click(object sender, EventArgs e)
        {
            Enabled = false;

            try
            {
                CControl2.TAxis[] Axis = new CControl2.TAxis[] { TaskGantry.GXAxis, TaskGantry.GYAxis };
                CommonControl.P1245.PathFree(Axis);

                CControl2.TOutput[] Output = new CControl2.TOutput[] { TaskGantry._SvPortC1 };
                //CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);

                for (int i = 0; i < DispProg.PJ.Pulse[0]; i++)
                {
                    CommonControl.P1245.PathAddDO(Axis, Output, true);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, (double)DispProg.PJ.OpenTime[0], 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, Output, false);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, (double)DispProg.PJ.CloseDelay[0], 0, null, null);
                }
                CommonControl.P1245.PathEnd(Axis);
                CommonControl.P1245.PathMove(Axis);
            }
            catch (Exception Ex) 
            {
                MessageBox.Show("Ex error - " + Ex.Message.ToString());
            }

            Enabled = true;
        }

        private void lbl_PulseCount_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("PJ.Pulse", ref DispProg.PJ.Pulse[0], 1, 100))
                UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
