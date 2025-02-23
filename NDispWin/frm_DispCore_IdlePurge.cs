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
    public partial class frm_DispCore_IdlePurge : Form
    {
        public bool AutoStart = false;
        public int i_DispSelect = 0;

        public frm_DispCore_IdlePurge()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.Text = "Idle Window";
        }

        private void frm_DispCore_IdlePurge_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            if (AutoStart) btn_Start_Click(sender, e);
            UpdateDisplay();
        }

        private void frm_DispCore_IdlePurge_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr_Idle.Enabled = false;
            try
            {
                TaskDisp.TaskMoveGZUp();
            }
            catch { };
        }

        private void UpdateDisplay()
        {
            UI_Utils.SetControlSelected(btn_SelectDisp1, (i_DispSelect & 0x01) == 0x01);
            UI_Utils.SetControlSelected(btn_SelectDisp2, (i_DispSelect & 0x02) == 0x02);

            if (TaskDisp.Idle_TimeToIdle == 0)
                lbl_IdleTimeToIdle.Text = TaskDisp.Idle_TimeToIdle.ToString() + " (Disabled)";
            else
                lbl_IdleTimeToIdle.Text = TaskDisp.Idle_TimeToIdle.ToString();

            lbl_IdlePurgeDuration.Text = TaskDisp.Idle_PurgeDuration.ToString();
            lbl_IdlePurgePostVacTime.Text = TaskDisp.Idle_PostVacTime.ToString();
            lbl_IdlePurgeInterval.Text = TaskDisp.Idle_PurgeInterval.ToString();
        }

        private void btn_SelectDisp1_Click(object sender, EventArgs e)
        {
            if ((i_DispSelect & 0x01) == 0x01)
                i_DispSelect = i_DispSelect & (0x01 ^ 0xFF);
            else
                i_DispSelect = i_DispSelect | 0x01;
            UpdateDisplay();
        }

        private void btn_SelectDisp2_Click(object sender, EventArgs e)
        {
            if ((i_DispSelect & 0x02) == 0x02)
                i_DispSelect = i_DispSelect & (0x02 ^ 0xFF);
            else
                i_DispSelect = i_DispSelect | 0x02;
            UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            tmr_Idle_Tick(sender, e);
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            tmr_Idle.Enabled = false;
            tmr_Sec.Enabled = false;
            DefineSafety.DoorLock = false;
            this.Enable(true);
        }

        private void lbl_IdleTimeToIdle_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Idle Time To Idle (s)", ref TaskDisp.Idle_TimeToIdle, 0, 3600);
            UpdateDisplay();
        }

        private void lbl_IdlePurgeTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Idle Purge Duration (ms)", ref TaskDisp.Idle_PurgeDuration, 10, 10000);
            UpdateDisplay();
        }

        private void lbl_IdlePurgePostVacTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Idle Post Vac Time (ms)", ref TaskDisp.Idle_PostVacTime, 0, 5000);
            UpdateDisplay();
        }

        private void lbl_IdlePurgeInterval_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Idle Purge Interval (s)", ref TaskDisp.Idle_PurgeInterval, 5, 600);
            UpdateDisplay();
        }

        int tmr_NextPurge = 0;
        private void tmr_Idle_Tick(object sender, EventArgs e)
        {
            if (TaskDisp.Idle_PurgeInterval == 0) return;

            if (!GDefine.SwDoor)
            {
                btn_Stop_Click(sender, e);
                TaskGantry.CheckDoorSw();
                return;
            }

            this.Enable(false);
            btn_Stop.Enable(true);

            tmr_NextPurge = TaskDisp.Idle_PurgeInterval;
            tmr_Idle.Interval = TaskDisp.Idle_PurgeInterval * 1000;
            tmr_Sec.Enabled = true;
            tmr_Idle.Enabled = false;

            if (!TaskDisp.TaskIdlePurge(i_DispSelect))
            {
                tmr_Idle.Enabled = false;
                tmr_Sec.Enabled = false;
                this.Enable(true);
            }
            tmr_Idle.Enabled = true;
        }

        private void tmr_Sec_Tick(object sender, EventArgs e)
        {
            this.Focus();
            this.TopMost = true;
            this.BringToFront();

            tmr_NextPurge--;
            lblDesc.Text = "Purge in " + tmr_NextPurge + " s.";
        }
    }
}
