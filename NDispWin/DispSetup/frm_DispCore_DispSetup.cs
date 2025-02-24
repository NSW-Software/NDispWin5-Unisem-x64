using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    internal partial class frm_DispCore_DispSetup : Form
    {
        frmJogGantry frm_Jog = new frmJogGantry();

        bool b_HeadOfstCalibrated = false;
        bool b_ZSensorCalibrated = false;

        public frm_DispCore_DispSetup()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;
            ShowPage(lbl_HeadCal, null);
        }

        private void UpdateDisplay()
        {
            btn_CalHeadOfstBCam.Visible = GDefine.BottomCamType > GDefine.EBottomCamType.None;
            btn_CalHeadOfst.Visible = !btn_CalHeadOfstBCam.Visible;

            btn_CalLaser.Visible = (GDefine.ZSensorType == GDefine.EZSensorType.None && GDefine.HSensorType > GDefine.EHeightSensorType.None);
            btn_CalZSensor.Visible = GDefine.ZSensorType > GDefine.EZSensorType.None;

            cbox_BypassTeachNeedleCheck.Checked = TaskDisp.TeachNeedle_Bypass;

            btnCalTempSensorOfstPoint.Visible = SysConfig.TempSensorType == SysConfig.ETempSensorType.UE_thermoCT;
            cbTempSensorOfstManual.Visible = SysConfig.TempSensorType == SysConfig.ETempSensorType.UE_thermoCT;
        }

        private void frmDispSetup_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);

            tmr_Reticle.Enabled = true;

            AppLanguage.Func2.UpdateText(this);

            this.Text = "Dispenser Setup";

            tmr1s.Enabled = true;
            UpdateDisplay();
        }
        private void frm_DispCore_DispSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr_Reticle.Enabled = false;

            if (frm_Jog != null) frm_Jog.Hide();

            if (frmMaint != null) frmMaint.Close();

        }

        private void btn_CalHeadOfst_Click(object sender, EventArgs e)
        {
            b_HeadOfstCalibrated = TaskDisp.CalHeadOffset(TaskDisp.ECalHeadOffsetMethod.CrossHair);
            TaskDisp.TeachNeedle_Completed = b_HeadOfstCalibrated && b_ZSensorCalibrated;
            UpdateDisplay();
        }
        private void btn_CalHeadOfstBCamera_Click(object sender, EventArgs e)
        {
            b_HeadOfstCalibrated = TaskDisp.CalHeadOffset(TaskDisp.ECalHeadOffsetMethod.BCamera);
            TaskDisp.TeachNeedle_Completed = b_HeadOfstCalibrated && b_ZSensorCalibrated;
            UpdateDisplay();
        }
        private void btn_HeadOfstTouchDotSet_Click(object sender, EventArgs e)
        {
            b_HeadOfstCalibrated = TaskDisp.TeachNeedleOfst_Touch_Dot_Set();
            b_ZSensorCalibrated = b_HeadOfstCalibrated;//Touch_Dot_Set includes Z Touch.
            TaskDisp.TeachNeedle_Completed = b_HeadOfstCalibrated && b_ZSensorCalibrated;
            UpdateDisplay();
        }

        private void btn_CalZSensor_Click(object sender, EventArgs e)
        {
            b_ZSensorCalibrated = TaskDisp.CalZSensorZ(true);
            TaskDisp.TeachNeedle_Completed = b_HeadOfstCalibrated && b_ZSensorCalibrated;
            UpdateDisplay();
        }
        private void btn_CalLaser_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskCalLaserOfstPoint();
            UpdateDisplay();
        }
        private void btn_CalLaserOfst_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskCalLaserOfstEdge();
            UpdateDisplay();
        }

        private void btn_Jog_Click(object sender, EventArgs e)
        {
            frm_Jog = new frmJogGantry();
            frm_Jog.TopMost = true;
            frm_Jog.Show();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            TaskDisp.SaveSetup_IOHandShake();

            TaskDisp.SaveSetup();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskMoveGZUp();
            TaskDisp.CheckDispCtrlConnection();

            Close();
        }

        private void frmDispSetup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TaskDisp.TaskMoveGZUp();
                Close();
            }
        }

        frm_DispCore_DispSetup_HeadCal frmHeadCal = new frm_DispCore_DispSetup_HeadCal();
        frm_DispCore_DispSetup_TeachNeedle frmTeachNeedle = new frm_DispCore_DispSetup_TeachNeedle();
        frm_DispCore_DispSetup_DispControl frmDispControl = new frm_DispCore_DispSetup_DispControl();
        frm_DispCore_DispSetup_CleanPurge frmCleanPurge = new frm_DispCore_DispSetup_CleanPurge();
        frm_DispCore_DispSetup_Weight frmWeight = new frm_DispCore_DispSetup_Weight();
        frm_DispCore_DispSetup_Maint frmMaint = new frm_DispCore_DispSetup_Maint();
        frm_DispCore_DispSetup_Options frmOption = new frm_DispCore_DispSetup_Options();
        frm_DispCore_DispSetup_Custom frmVolOfst = new frm_DispCore_DispSetup_Custom();

        private void ShowPage(object sender, Form frm)
        {
            UI_Utils.SetControlSelected2(lbl_HeadCal, false);
            UI_Utils.SetControlSelected2(lbl_HeadCalSetting, false);
            UI_Utils.SetControlSelected2(lbl_TeachNeedle, false);
            UI_Utils.SetControlSelected2(lbl_DispControl, false);
            UI_Utils.SetControlSelected2(lbl_CleanPurge, false);
            UI_Utils.SetControlSelected2(lbl_Weight, false);
            UI_Utils.SetControlSelected2(lbl_Maint, false);
            UI_Utils.SetControlSelected2(lbl_Options, false);
            UI_Utils.SetControlSelected2(lbl_Custom, false);

            UI_Utils.SetControlSelected2(sender, true);

            frmHeadCal.Visible = false;
            frmTeachNeedle.Visible = false;
            frmDispControl.Visible = false;
            frmCleanPurge.Visible = false;
            frmWeight.Visible = false;
            frmMaint.Visible = false;
            frmOption.Visible = false;
            frmVolOfst.Visible = false;

            if (frm != null)
            {
                frm.TopLevel = false;
                frm.Parent = this;//panel1;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Padding = new Padding(0);
                frm.AutoSize = false;
                //frm.Dock = DockStyle.Fill;
                frm.Location = panel1.Location;
                frm.Size = panel1.Size;
                frm.BringToFront();
                frm.Show();

                frm.Visible = true;
            }
        }
        private void lbl_HeadCal_Click(object sender, EventArgs e)
        {
            ShowPage(sender, null);
        }
        private void lbl_HeadCalSetting_Click(object sender, EventArgs e)
        {
            ShowPage(sender, frmHeadCal);
        }
        private void lbl_TeachNeedle_Click(object sender, EventArgs e)
        {
            ShowPage(sender, frmTeachNeedle);
        }
        private void lbl_DispControl_Click(object sender, EventArgs e)
        {
            ShowPage(sender, frmDispControl);
        }
        private void lbl_CleanPurge_Click(object sender, EventArgs e)
        {
            ShowPage(sender, frmCleanPurge);
        }
        private void lbl_Maint_Click(object sender, EventArgs e)
        {
            ShowPage(sender, frmMaint);
        }
        private void lbl_Weight_Click(object sender, EventArgs e)
        {
            ShowPage(sender, frmWeight);
        }
        private void lbl_Options_Click(object sender, EventArgs e)
        {
            ShowPage(sender, frmOption);
        }
        private void lbl_VolumeOfst_Click(object sender, EventArgs e)
        {
            ShowPage(sender, frmVolOfst);
        }

        private void tmr_Reticle_Tick(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbox_BypassTeachNeedleCheck_Click(object sender, EventArgs e)
        {
            TaskDisp.TeachNeedle_Bypass = !TaskDisp.TeachNeedle_Bypass;

            if (TaskDisp.TeachNeedle_Bypass) Event.SETUP_BYPASS_TEACH_NEEDLE.Set();

            UpdateDisplay();
        }

        private void cbox_BypassTeachNeedleCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tmr1s_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;
        }

        private void btnCalTempSensorOfst_Click(object sender, EventArgs e)
        {
            if (cbTempSensorOfstManual.Checked)
                TaskDisp.TaskCalTempSensorOfstPoint();
            else
                TaskDisp.TaskCalTempSensorOfstEdge();

            UpdateDisplay();
        }
    }
}
