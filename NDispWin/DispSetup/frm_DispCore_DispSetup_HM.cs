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
    public partial class frm_DispCore_DispSetup_HM : Form
    {
        public frm_DispCore_DispSetup_HM()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_DispCore_DispSetup_HM_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);
        }

        private void frm_DispCore_DispSetup_HM_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay_CtrlMode();
            //AppLanguage.Func.SetComponent(this);
            AppLanguage.Func2.UpdateText(this);
        }

        enum ECtrlMode { Timed, Purge };
        ECtrlMode CtrlMode_HeadA = ECtrlMode.Timed;
        ECtrlMode CtrlMode_HeadB = ECtrlMode.Timed;
        private void UpdateDisplay_CtrlMode()
        {
            bool b_PurgeModeA = false;
            bool b_PurgeModeB = false;
            TaskDisp.GetDispCtrlMode(true, true, ref b_PurgeModeA, ref b_PurgeModeB);
            if (b_PurgeModeA) CtrlMode_HeadA = ECtrlMode.Purge; else CtrlMode_HeadA = ECtrlMode.Timed;
            if (b_PurgeModeB) CtrlMode_HeadB = ECtrlMode.Purge; else CtrlMode_HeadB = ECtrlMode.Timed;
        }

        private void UpdateDisplay()
        {
            if (CtrlMode_HeadA == ECtrlMode.Timed) btn_ModeA.BackColor = Color.AntiqueWhite; else btn_ModeA.BackColor = Color.Orange;
            if (CtrlMode_HeadB == ECtrlMode.Timed) btn_ModeB.BackColor = Color.AntiqueWhite; else btn_ModeB.BackColor = Color.Orange;
        }

        private void tmt_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        private void btn_ModeA_Click(object sender, EventArgs e)
        {
            if (CtrlMode_HeadA == ECtrlMode.Timed)
                TaskDisp.SetDispCtrlPurgeMode(true, false);
            else
                TaskDisp.SetDispCtrlTimedMode(true, false);

            UpdateDisplay_CtrlMode();
        }
        private void btn_ModeB_Click(object sender, EventArgs e)
        {
            if (CtrlMode_HeadB == ECtrlMode.Timed)
                TaskDisp.SetDispCtrlPurgeMode(false, true);
            else
                TaskDisp.SetDispCtrlTimedMode(false, true);

            UpdateDisplay_CtrlMode();
        }

        private void btn_TrigA_MouseDown(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOn(true, false);
        }

        private void btn_TrigA_MouseUp(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOff(true, false);
        }

        private void btn_TrigB_MouseDown(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOn(false, true);
        }

        private void btn_TrigB_MouseUp(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOff(false, true);
        }
    }
}
