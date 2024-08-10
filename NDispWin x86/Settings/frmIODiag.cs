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
    internal partial class frmIODiag : Form
    {
        public frmIODiag()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void UpdateDisplay()
        {
            #region Controller IO Tab
            try
            {
                GDefine.RefreshInput(lbl_DispAReady, TaskGantry.DispAReady());
                GDefine.RefreshOutput(lbl_DispATrig, TaskGantry.DispATrigSet(TaskGantry.TOutputState.St));
            }
            catch { };
            GDefine.UpdateInfo(lbl_DispAReadyInfo, TaskGantry._DispARdy);
            GDefine.UpdateInfo(lbl_DispATrigInfo, TaskGantry._DispATrg);

            try
            {
                GDefine.RefreshInput(lbl_DispBReady, TaskGantry.DispBReady());
                GDefine.RefreshOutput(lbl_DispBTrig, TaskGantry.DispBTrigSet(TaskGantry.TOutputState.St));
            }
            catch { };
            GDefine.UpdateInfo(lbl_DispBReadyInfo, TaskGantry._DispBRdy);
            GDefine.UpdateInfo(lbl_DispBTrigInfo, TaskGantry._DispBTrg);

            try
            {
                GDefine.RefreshInput(lbl_DispError, TaskGantry.DispCtrlError);
            }
            catch { };
            GDefine.UpdateInfo(lbl_DispErrorInfo, TaskGantry._DispError);

            try
            {
                GDefine.RefreshInput(lbl_TapeReady, TaskGantry.TapeReady);
                GDefine.RefreshOutput(btn_TapeTrig, TaskGantry.TapeTrig);
                GDefine.RefreshInput(lbl_TapeAlarm, TaskGantry.TapeAlarm);
                GDefine.RefreshOutput(btn_TapeReset, TaskGantry.TapeReset);
            }
            catch { };
            GDefine.UpdateInfo(lbl_TapeReadyInfo, TaskGantry._TapeReady);
            GDefine.UpdateInfo(lbl_TapeTrigInfo, TaskGantry._TapeTrig);
            GDefine.UpdateInfo(lbl_TapeAlarmInfo, TaskGantry._TapeAlarm);
            GDefine.UpdateInfo(lbl_TapeResetInfo, TaskGantry._TapeReset);

            #endregion


            try
            {
                GDefine.RefreshInput(lbl_SensNeedleZ, TaskGantry.SensNeedleZ());
                GDefine.RefreshOutput(btn_CleanVac, TaskGantry.SvCleanVac);
            }
            catch { };

            try
            {
                GDefine.RefreshInput(lbl_BtnStart, TaskGantry.BtnStart());
                GDefine.RefreshInput(lbl_BtnStop, TaskGantry.BtnStop());
            }
            catch { };

            try
            {
                GDefine.RefreshOutput(btn_ChuckVacuum, TaskGantry.ChuckVac);
                GDefine.RefreshInput(lbl_SensChuckVac, TaskGantry.SensChuckVac);
            }
            catch { };

            try
            {
                GDefine.RefreshInput(lbl_SensMat1Low, TaskGantry.SensMat1Low());
                GDefine.RefreshInput(lbl_SensMat2Low, TaskGantry.SensMat2Low());
            }
            catch { };


            GDefine.UpdateInfo(lbl_SensNeedleZInfo, TaskGantry._SensNeedleZ);
            GDefine.UpdateInfo(lbl_CleanVacInfo, TaskGantry._SvCleanVac);

            GDefine.UpdateInfo(lbl_BtnStartInfo, TaskGantry._BtnStart);
            GDefine.UpdateInfo(lbl_BtnStopInfo, TaskGantry._BtnStop);

            GDefine.UpdateInfo(lbl_ChuckVacInfo, TaskGantry._SvChuckVac);
            GDefine.UpdateInfo(lbl_SensChuckVacInfo, TaskGantry._SensChuckVac);

            GDefine.UpdateInfo(lbl_SensMat1Low1Info, TaskGantry._SensMat1Low);
            GDefine.UpdateInfo(lbl_SensMat2Low2Info, TaskGantry._SensMat2Low);


            try
            {
                GDefine.RefreshOutput(btn_SvFPress1, TaskGantry.FPress1(TaskGantry.TOutputState.St));
                GDefine.UpdateInfo(lbl_SvFPress1Info, TaskGantry._SvFPress1);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_SvFPress2, TaskGantry.FPress2(TaskGantry.TOutputState.St));
                GDefine.UpdateInfo(lbl_SvFPress2Info, TaskGantry._SvFPress2);
            }
            catch { };

            try
            {
                GDefine.RefreshOutput(btn_SvVac1, TaskGantry.BVac1);
                GDefine.UpdateInfo(lbl_SvVac1Info, TaskGantry._SvFVac1);
            }
            catch { };

            try
            {
                GDefine.RefreshOutput(btn_SvPortA1, TaskGantry.DispPortA1);
                GDefine.UpdateInfo(lbl_SvPortA1Info, TaskGantry._SvPortA1);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_SvPortB1, TaskGantry.DispPortB1);
                GDefine.UpdateInfo(lbl_SvPortB1Info, TaskGantry._SvPortB1);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_SvPortC1, TaskGantry.DispPortC1);
                GDefine.UpdateInfo(lbl_SvPortC1Info, TaskGantry._SvPortC1);
            }
            catch { };

            try
            {
                GDefine.RefreshOutput(btn_Buzzer, TaskGantry.Buzzer(TaskGantry.TOutputState.St));
                GDefine.UpdateInfo(lbl_BuzzerInfo, TaskGantry._Buzzer);
            }
            catch { };

            #region GPOut1~6
            try
            {
                GDefine.RefreshOutput(btn_GPOut1, TaskGantry.GPOut1);
                GDefine.UpdateInfo(lbl_GPOut1Info, TaskGantry._GPOut1);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_GPOut2, TaskGantry.GPOut2);
                GDefine.UpdateInfo(lbl_GPOut2Info, TaskGantry._GPOut2);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_GPOut3, TaskGantry.GPOut3);
                GDefine.UpdateInfo(lbl_GPOut3Info, TaskGantry._GPOut3);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_GPOut4, TaskGantry.GPOut4);
                GDefine.UpdateInfo(lbl_GPOut4Info, TaskGantry._GPOut4);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_GPOut5, TaskGantry.GPOut5);
                GDefine.UpdateInfo(lbl_GPOut5Info, TaskGantry._GPOut5);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_GPOut6, TaskGantry.GPOut6);
                GDefine.UpdateInfo(lbl_GPOut6Info, TaskGantry._GPOut6);
            }
            catch { };

            try
            {
                GDefine.RefreshInput(lbl_SensDoor, TaskGantry.SensDoor);
                GDefine.UpdateInfo(lbl_SensDoorInfo, TaskGantry._SensDoor);
            }
            catch { };
            try
            {
                GDefine.RefreshOutput(btn_LockDoor, TaskGantry.LockDoor);
                GDefine.UpdateInfo(lbl_LockDoorInfo, TaskGantry._LockDoor);
            }
            catch { };

            #endregion

            try
            {
                lbl_ZSensorPos.Text = TaskGantry.ZSensorPos.ToString("f4");
            }
            catch { };

            lbl_SZDistPerPulse.Text = TaskGantry.SZAxis.Para.Unit.Resolution.ToString("f4");
            GDefine.UpdateInfo(lbl_SZPosInfo, TaskGantry.SZAxis);

            if (tabControl1.SelectedTab == tabControl1.TabPages["tpNeedleInsp"])
            {
                try
                {
                    GDefine.RefreshInput(lblNICamSigOK, TaskGantry.NICamSigOK);
                    GDefine.RefreshInput(lblNICamBusy, TaskGantry.NICamBusy);
                    GDefine.RefreshInput(lblNICamRun, TaskGantry.NICamRun);
                    GDefine.RefreshOutput(btnNICamTrig, TaskGantry.NICamTrig);
                }
                catch { };
                GDefine.UpdateInfo(lblNICamSigOKInfo, TaskGantry._NICamSigOK);
                GDefine.UpdateInfo(lblNICamBusyInfo, TaskGantry._NICamBusy);
                GDefine.UpdateInfo(lblNICamRunInfo, TaskGantry._NICamRun);
                GDefine.UpdateInfo(lblNICamTrigInfo, TaskGantry._NICamTrig);
            }
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        private void frmIODiag_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = "IO Diagnotics";

            UpdateDisplay();
        }

        #region Controller IO
        private void lbl_DispATrig_Click(object sender, EventArgs e)
        {
            if (TrigTime_ms == 0)
            {
                if (TaskGantry.DispATrigSet(TaskGantry.TOutputState.St))
                    TaskGantry.DispATrigSet(TaskGantry.TOutputState.Off);
                else
                    TaskGantry.DispATrigSet(TaskGantry.TOutputState.On);
            }
            else
            {
                TaskGantry.DispATrigSet(TaskGantry.TOutputState.On);
                int t = GDefine.GetTickCount() + TrigTime_ms;
                while (GDefine.GetTickCount() <= t) { };
                TaskGantry.DispATrigSet(TaskGantry.TOutputState.Off);
            }
        }
        private void lbl_DispBTrig_Click(object sender, EventArgs e)
        {
            if (TrigTime_ms == 0)
            {
                if (TaskGantry.DispBTrigSet(TaskGantry.TOutputState.St))
                    TaskGantry.DispBTrigSet(TaskGantry.TOutputState.Off);
                else
                    TaskGantry.DispBTrigSet(TaskGantry.TOutputState.On);
            }
            else
            {
                TaskGantry.DispBTrigSet(TaskGantry.TOutputState.On);
                int t = GDefine.GetTickCount() + TrigTime_ms;
                while (GDefine.GetTickCount() <= t) { };
                TaskGantry.DispBTrigSet(TaskGantry.TOutputState.Off);
            }
        }

        private void lbl_DispAReadyInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._DispARdy);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._DispARdy = frm.Input;
        }
        private void lbl_DispBReadyInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._DispBRdy);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._DispBRdy = frm.Input;
        }

        private void lbl_DispATrigInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._DispATrg);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._DispATrg = frm.Output;
        }
        private void lbl_DispBTrigInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._DispBTrg);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._DispBTrg = frm.Output;
        }

        private void lbl_DispErrorInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._DispError);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._DispError = frm.Input;
        }

        int TrigTime_ms = 0;
        private void lbl_TrigTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("IO Diag, Trig Time (ms)", ref TrigTime_ms, 0, 5000);
            lbl_TrigTime.Text = TrigTime_ms.ToString();
        }
        #endregion

        private void btn_CleanVac_Click(object sender, EventArgs e)
        {
            TaskGantry.SvCleanVac = !TaskGantry.SvCleanVac;
        }

        private void lbl_SensNeedleZInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SensNeedleZ);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SensNeedleZ = frm.Input;
        }
        private void lbl_PurgeVacInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvCleanVac);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvCleanVac = frm.Output;
        }
        private void lbl_BtnStartInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._BtnStart);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._BtnStart = frm.Input;
        }
        private void lbl_BtnStopInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._BtnStop);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._BtnStop = frm.Input;
        }

        private void frmIODiag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void btn_ChuckVacuum_Click(object sender, EventArgs e)
        {
            TaskGantry.ChuckVac = !TaskGantry.ChuckVac;
        }
        private void lbl_ChuckVacuumInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvChuckVac);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvChuckVac = frm.Output;
        }

        private void btn_ZSensorReset_Click(object sender, EventArgs e)
        {
            TaskGantry.ZSensorPos = 0;
            UpdateDisplay();
        }

        private void lbl_SensMat1LowInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SensMat1Low);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SensMat1Low = frm.Input;
        }
        private void lbl_SensMat2LowInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SensMat2Low);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SensMat2Low = frm.Input;
        }

        private void btn_Buzzer_Click(object sender, EventArgs e)
        {
            if (TaskGantry.Buzzer(TaskGantry.TOutputState.St))
                TaskGantry.Buzzer(TaskGantry.TOutputState.Off);
            else
                TaskGantry.Buzzer(TaskGantry.TOutputState.On);
        }
        private void lbl_AlarmInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._Buzzer);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._Buzzer = frm.Output;
        }

        private void btn_FPress1_Click(object sender, EventArgs e)
        {
            if (TaskGantry.FPress1(TaskGantry.TOutputState.St))
                TaskGantry.FPress1(TaskGantry.TOutputState.Off);
            else
                TaskGantry.FPress1(TaskGantry.TOutputState.On);
        }
        private void btn_FPress2_Click(object sender, EventArgs e)
        {
            if (TaskGantry.FPress2(TaskGantry.TOutputState.St))
                TaskGantry.FPress2(TaskGantry.TOutputState.Off);
            else
                TaskGantry.FPress2(TaskGantry.TOutputState.On);
        }
        private void lbl_SvFPress1Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvFPress1);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvFPress1 = frm.Output;
        }
        private void lbl_SvFPress2Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvFPress2);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvFPress2 = frm.Output;
        }

        private void btn_SvVac1_Click(object sender, EventArgs e)
        {
            TaskGantry.BVac1 = !TaskGantry.BVac1;
        }

        private void btn_SvPortA1_Click(object sender, EventArgs e)
        {
            TaskGantry.DispPortA1 = !TaskGantry.DispPortA1;
        }

        private void btn_SvPortB1_Click(object sender, EventArgs e)
        {
            TaskGantry.DispPortB1 = !TaskGantry.DispPortB1;
        }

        private void btn_SvPortC1_Click(object sender, EventArgs e)
        {
            TaskGantry.DispPortC1 = !TaskGantry.DispPortC1;
        }

        private void lbl_SvVac1Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvFVac1);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvFVac1 = frm.Output;
        }

        private void lbl_SvPortA1Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvPortA1);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvPortA1 = frm.Output;
        }

        private void lbl_SvPortB1Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvPortB1);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvPortB1 = frm.Output;
        }

        private void lbl_SvPortC1Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvPortC1);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvPortC1 = frm.Output;
        }

        private void cbox_MCCAddress_Click(object sender, EventArgs e)
        {

        }

        private void cbox_MCCAddress_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbl_GenOut1Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._GPOut1);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._GPOut1 = frm.Output;
        }
        private void lbl_GenOut2Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._GPOut2);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._GPOut2 = frm.Output;
        }
        private void lbl_GenOut3Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._GPOut3);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._GPOut3 = frm.Output;
        }
        private void lbl_GenOut4Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._GPOut4);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._GPOut4 = frm.Output;
        }
        private void lbl_GPOut5Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._GPOut5);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._GPOut5 = frm.Output;
        }
        private void lbl_GPOut6Info_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._GPOut6);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._GPOut6 = frm.Output;
        }

        private void btn_GenOut1_Click(object sender, EventArgs e)
        {
            TaskGantry.GPOut1 ^= true;
        }
        private void btn_GenOut2_Click(object sender, EventArgs e)
        {
            TaskGantry.GPOut2 ^= true;
        }
        private void btn_GenOut3_Click(object sender, EventArgs e)
        {
            TaskGantry.GPOut3 ^= true;
        }
        private void btn_GenOut4_Click(object sender, EventArgs e)
        {
            TaskGantry.GPOut4 ^= true;
        }
        private void btn_GPOut5_Click(object sender, EventArgs e)
        {
            TaskGantry.GPOut5 ^= true;
        }
        private void btn_GPOut6_Click(object sender, EventArgs e)
        {
            TaskGantry.GPOut6 ^= true;
        }

        private void lbl_ZSensorDistPerPulse_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("ZSensor, Dist Per Pulse (mm)", ref TaskGantry.SZAxis.Para.Unit.Resolution, 0.0001, 0.1);
            //CommonControl.UpdateAxis(TaskGantry.SZAxis);
            TaskGantry.UpdateAxis(TaskGantry.SZAxis);
            GDefine.ZSensor_DistPerPulse = TaskGantry.SZAxis.Para.Unit.Resolution;

            UpdateDisplay();
        }
        private void lbl_SZPosInfo_Click(object sender, EventArgs e)
        {
            frmDeviceAxisConfigEditor frm = new frmDeviceAxisConfigEditor(TaskGantry.SZAxis);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TaskGantry.SZAxis = frm.Axis;
            }
            UpdateDisplay();
        }

        private void btn_DoorLock_Click(object sender, EventArgs e)
        {
            TaskGantry.LockDoor ^= true;
        }

        private void lbl_SensDoor_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SensDoor);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SensDoor = frm.Input;
        }

        private void lbl_LockDoor_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._LockDoor);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._LockDoor = frm.Output;
        }

        private void lbl_SensChuckVacInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SensChuckVac);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SensChuckVac = frm.Input;
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Motor No: M1~M8" + (char)10 +
                "" + (char)10 +
                "MCT Lbl" + (char)9 + "IO No" + (char)10 +
                "-------" + (char)9 + "-------" + (char)10 +
                "DI1" + (char)9 + "DI1" + (char)10 +
                "DI2" + (char)9 + "DI2" + (char)10 +
                "DI3" + (char)9 + "DI3" + (char)10 +
                "DI4" + (char)9 + "DI4" + (char)10 +
                "Lmt+" + (char)9 + "DI10" + (char)10 +
                "Lmt-" + (char)9 + "DI11" + (char)10 +
                "DO4" + (char)9 + "DO4" + (char)10 +
                "DO5" + (char)9 + "DO5" + (char)10 +
                "DO6" + (char)9 + "DO6" + (char)10 +
                "DO7" + (char)9 + "DO7");
        }

        private void btn_TapeCleanTrig_Click(object sender, EventArgs e)
        {
            TaskGantry.TapeTrig = !TaskGantry.TapeTrig;
        }

        private void btn_TapeCleanReset_Click(object sender, EventArgs e)
        {
            TaskGantry.TapeReset = !TaskGantry.TapeReset;
        }

        private void lbl_TapeReadyInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._TapeReady);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._TapeReady = frm.Input;
        }

        private void lbl_TapeTrigInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._TapeTrig);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._TapeTrig = frm.Output;
        }

        private void lbl_TapeAlarmInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._TapeAlarm);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._TapeAlarm = frm.Input;
        }

        private void lbl_TapeResetInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._TapeReset);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._TapeReset = frm.Output;
        }

        private void btn_SvPnpPrecise_Click(object sender, EventArgs e)
        {
            TaskGantry.SvPnpPrecise = !TaskGantry.SvPnpPrecise;
        }

        private void btn_SvPnpVacuum_Click(object sender, EventArgs e)
        {
            TaskGantry.SvPnpVac = !TaskGantry.SvPnpVac;
        }

        private void btn_SvPnpPurge_Click(object sender, EventArgs e)
        {
            TaskGantry.SvPnpPurge = !TaskGantry.SvPnpPurge;
        }

        private void lbl_SvPnpPreciseInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvPnpPrecise);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvPnpPrecise = frm.Output;
        }

        private void lbl_SensPnpPreciseInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SensPnpPrecise);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SensPnpPrecise = frm.Input;
        }

        private void lbl_SensPnpContactInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SensPnpContact);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SensPnpContact = frm.Input;
        }

        private void lbl_SvPnpVacInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvPnpVac);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvPnpVac = frm.Output;
        }

        private void lbl_SvPnpPurgeInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SvPnpPurge);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SvPnpPurge = frm.Output;
        }

        private void lbl_SensPnpVacInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._SensPnpVac);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._SensPnpVac = frm.Input;
        }

        private void lbl_ZSensorPos_Click(object sender, EventArgs e)
        {

        }

        #region Needle Inspection Cam
        private void lblNICamSigOKInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._NICamSigOK);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._NICamSigOK = frm.Input;
        }

        private void lblNICamBusyInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._NICamBusy);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._NICamBusy = frm.Input;
        }

        private void lblNICamErrorInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._NICamRun);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._NICamRun = frm.Input;
        }

        private void lblNICamTrigInfo_Click(object sender, EventArgs e)
        {
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(TaskGantry._NICamTrig);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry._NICamTrig = frm.Output;
        }

        private void btnNICamTrig_Click(object sender, EventArgs e)
        {
            TaskGantry.NICamTrig ^= true;
        }
        #endregion
    }
}
