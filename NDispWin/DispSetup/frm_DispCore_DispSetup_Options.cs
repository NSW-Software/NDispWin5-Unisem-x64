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
    internal partial class frm_DispCore_DispSetup_Options : Form
    {
        public frm_DispCore_DispSetup_Options()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_DispCore_DispSetup_Options_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
        }
        private void frm_DispCore_DispSetup_Options_Shown(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispSetup_Options_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            cbox_EnableRunSingleHead.Checked = TaskDisp.Option_EnableRunSingleHead;
            cbox_PromptRunSingleHead.Checked = TaskDisp.Option_PromptRunSingleHead;
            cbox_EnableMaterialLow.Checked = TaskDisp.Option_EnableMaterialLow;
            cbox_EnableDualMaterial.Checked = TaskDisp.Option_EnableDualMaterial;
            cbox_EnableChuckVac.Checked = TaskDisp.Option_EnableChuckVac;

            cbox_EnableMaterialTimer.Checked = TaskDisp.Material_EnableTimer;
            lbl_MaterialLifeTimeMultipler.Text = TaskDisp.Material_Life_Multiplier.ToString();

            cbox_EnableDrawOfstAdjust.Checked = TaskDisp.Option_EnableDrawOfstAdjust;
            lbl_OriginAdjustLimitXY.Text = TaskDisp.Option_DrawOfstAdjustLimit_XY.ToString("F3");
            lbl_OriginAdjustLimitZ.Text = TaskDisp.Option_DrawOfstAdjustLimit_Z.ToString("F3");
            lblOption_DrawOfstAdjustRate.Text = TaskDisp.Option_DrawOfstAdjustRate.ToString("F3");

            cbox_EnableStartIdle.Checked = TaskDisp.Option_EnableStartIdle;
            lbl_IdlePurgeTimer.Text = TaskDisp.Option_IdlePurgeTimer.ToString();

            cbox_EnableScriptCheck.Checked = TaskDisp.Option_EnableScriptCheck;
            cbox_EnableScriptCheckUnitMode.Checked = TaskDisp.Option_EnableScriptCheckUnitMode;
            cbox_EnableRealTimeFineTune.Checked = TaskDisp.Option_EnableRealTimeFineTune;

            lbl_Option_VolumeDisplayDecimalPlace.Text = TaskDisp.Option_VolumeDisplayDecimalPoint.ToString();

            lbl_XYPeakSpeedRatio.Text = TaskDisp.Option_XYShortDistPeakSpeedRatio.ToString();
            lbl_XYShortDist.Text = TaskDisp.Option_XYShortDist.ToString("f3");

            cbox_CopyLogToServer.Checked = TaskDisp.CopyLogToServer;
            tbox_LogServerPath.Text = TaskDisp.LogServerPath;

        }

        private void cbox_EnableRunSingleHead_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable RunSingle Head", ref TaskDisp.Option_EnableRunSingleHead);
            UpdateDisplay();
        }
        private void cbox_PromptRunSingleHead_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, PromptRunSingleHead", ref TaskDisp.Option_PromptRunSingleHead);
            UpdateDisplay();
        }
        private void cbox_EnableMaterialLow_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Material Low", ref TaskDisp.Option_EnableMaterialLow);
            UpdateDisplay();
        }
        private void cbox_EnableDualMaterial_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Dual Material", ref TaskDisp.Option_EnableDualMaterial);
            UpdateDisplay();
        }

        private void cbox_EnableDrawOfstAdjust_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Draw Offset", ref TaskDisp.Option_EnableDrawOfstAdjust);
            UpdateDisplay();
        }

        private void lbl_DrawOfstAdjustLimitXY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Draw Adjust Limit XY", ref TaskDisp.Option_DrawOfstAdjustLimit_XY, 0, 3);
            UpdateDisplay();
        }
        private void lbl_DrawOfstAdjustLimitZ_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Draw Adjust Limit Z", ref TaskDisp.Option_DrawOfstAdjustLimit_Z, 0, 3);
            UpdateDisplay();
        }
        private void lblOption_DrawOfstAdjustRate_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Draw Ofst Adjust Rate", ref TaskDisp.Option_DrawOfstAdjustRate, 0.001, 1);
            UpdateDisplay();
        }

        private void cbox_EnableStartIdle_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Start Idle", ref TaskDisp.Option_EnableStartIdle);
            UpdateDisplay();
        }
        private void cbox_EnableChuckVac_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Chuck Vacuum", ref TaskDisp.Option_EnableChuckVac);
            UpdateDisplay();
        }
        private void lbl_MaterialLifeTimeMultipler_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, MaterialLifeMultiplier", ref TaskDisp.Material_Life_Multiplier, 1, 3600);
            UpdateDisplay();
        }
        private void cbox_EnableScriptCheck_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Script Check", ref TaskDisp.Option_EnableScriptCheck);
            UpdateDisplay();
        }

        private void cbox_EnableScriptCheckUnitMode_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Script Check Unit Mode", ref TaskDisp.Option_EnableScriptCheckUnitMode);
            UpdateDisplay();
        }

        private void cbox_EnableMaterialTimer_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, EnableMaterialTimer", ref TaskDisp.Material_EnableTimer);
            UpdateDisplay();
        }

        private void cbox_EnableScriptCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbox_EnableRealTimeFineTune_Click(object sender, EventArgs e)
        {
            TaskDisp.Option_EnableRealTimeFineTune = !TaskDisp.Option_EnableRealTimeFineTune;
            UpdateDisplay();
        }

        private void lbl_Option_VolumeDisplayDecimalPlace_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup Options, Volume Display Decimal Point", ref TaskDisp.Option_VolumeDisplayDecimalPoint, 2, 5);
            UpdateDisplay();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup Options, Idle Purge Timer (s)", ref TaskDisp.Option_IdlePurgeTimer, 0, 3600);
            UpdateDisplay();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbox_EnableHPCManualCtrls_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup Options, Hide HPC Manual Controls", ref TaskDisp.Option_HideHPCManualControls);
            UpdateDisplay();
        }

        private void lbl_XYPeakSpeedRatio_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup Options, XY Peak Speed Ratio", ref TaskDisp.Option_XYShortDistPeakSpeedRatio, 0.05, 1);
            UpdateDisplay();
        }

        private void lbl_XYShortDist_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup Options, XY Short Dist", ref TaskDisp.Option_XYShortDist, 0, 1000);
            UpdateDisplay();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbox_CopyLogToServer_Click(object sender, EventArgs e)
        {
            TaskDisp.CopyLogToServer = !TaskDisp.CopyLogToServer;
            Log.OnSet("Disp Setup Options, Copy Log To Server", !TaskDisp.CopyLogToServer, TaskDisp.CopyLogToServer);
            UpdateDisplay();
        }

        private void tbox_LogServerPath_Validated(object sender, EventArgs e)
        {
            TaskDisp.LogServerPath = tbox_LogServerPath.Text;

            TaskDisp.LogServerPath = TaskDisp.LogServerPath + (TaskDisp.LogServerPath.EndsWith(@"\") ? "" : @"\");
            UpdateDisplay();
        }

        private void tbox_LogServerPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbox_EnableMaterialTimer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
