using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDispWin
{
    internal partial class frmFlowRateCal : Form
    {
        public List<TaskWeight.EHeadNo> HeadToCal = new List<TaskWeight.EHeadNo>();

        public frmFlowRateCal()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;
        }

        bool autoExec = false;
        public frmFlowRateCal(bool head1Execute, bool head2Execute)
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;

            if (head1Execute) AddHead(TaskWeight.EHeadNo.One);
            if (head2Execute) AddHead(TaskWeight.EHeadNo.Two);
            autoExec = true;
        }

        private void frmFlowRateCal_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            Text = "Flow Rate Calibration";
            this.TopMost = true;
            this.BringToFront();

            UpdateDisplay();

            if (autoExec) btnStart_Click(sender, e);
        }
        private void frmFlowRateCal_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskDisp.FPressOff();

            TaskWeight.SoftZeroReset();
            try
            {
                TaskDisp.TaskMoveGZZ2Up();
            }
            catch { };
        }

        bool bErr = false;
        readonly string dp = "f4";
        private void tmrWeightDisplay_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            if ((int)GDefine.WeightStType == 0)
            {
                lbl_WeightCurrentValue.Text = "------";
                return;
            }
            if (!TaskWeight.WeightIsOpen)
            {
                lbl_WeightCurrentValue.Text = "ERR";
                return;
            }

            tmrWeightDisplay.Enabled = false;
            double d_mg = 0;

            if (bErr) return;
            bErr = !TaskWeight.WeightValue(ref d_mg);

            lbl_WeightCurrentValue.Text = d_mg.ToString(dp);
            tmrWeightDisplay.Enabled = true;

            if (lbxLog.Items.Count < TaskFlowRate.logList.Count)
            {
                lbxLog.Items.Add(TaskFlowRate.logList[lbxLog.Items.Count]);
            }
        }

        private void UpdateDisplay()
        {
            if (HeadToCal.Contains(TaskWeight.EHeadNo.One))
                btn_Head1.BackColor = Color.Lime;
            else
                btn_Head1.BackColor = this.BackColor;

            if (HeadToCal.Contains(TaskWeight.EHeadNo.Two))
                btn_Head2.BackColor = Color.Lime;
            else
                btn_Head2.BackColor = this.BackColor;

            lblCurrentFlowRate.Text = TaskFlowRate.Value[0].ToString("f3");
            lblCurrentFlowRate2.Text = TaskFlowRate.Value[1].ToString("f3");

            cbAutoCalibrateFrame.Checked = DispProg.FlowRate.EnableAutoCalFrame;
            lblAutoCalFrameInterval.Text = Stats.AutoFlowRateFrameCounter.ToString() + " / " + DispProg.FlowRate.AutoCalFrameInterval;

            cbAutoCalibrateUnit.Checked = DispProg.FlowRate.EnableAutoCalUnit;
            lblAutoCalUnitInterval.Text = Stats.AutoFlowRateUnitCounter.ToString() + " / " + DispProg.FlowRate.AutoCalUnitInterval;

            lblNoToAverage.Text = DispProg.FlowRate.NoToAve.ToString();
            lblDuration.Text = DispProg.FlowRate.Duration.ToString();
            lblDelay.Text = DispProg.FlowRate.Delay.ToString();

            lblMinPressure.Text = DispProg.FlowRate.MinPressure.ToString("f3");
            lblMaxPressure.Text = DispProg.FlowRate.MaxPressure.ToString("f3");

            pnlTargetFlowRate.Visible = DispProg.FlowRate.EnableTargetFlowRate;
            cbEnableTargetFlowrate.Checked = DispProg.FlowRate.EnableTargetFlowRate;
            lblTargetFlowRate.Text = DispProg.FlowRate.TargetFlowrate.ToString("f3");
            lblTargetFlowRateTol.Text = DispProg.FlowRate.TargetFlowRateTol.ToString("f3");

            lblSlope.Text = DispProg.FlowRate.MaterialSlope.ToString("f5");
            lblIntercept.Text = DispProg.FlowRate.MaterialIntercept.ToString("f5");
            lblTimeCompensate.Text = DispProg.FlowRate.TimeCompensate.ToString("f2");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmWeightSettings frm = new frmWeightSettings();
            frm.TopMost = true;
            frm.BringToFront();
            frm.ShowDialog();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            frm_ProgressReport frm = new frm_ProgressReport();
            frm.Message = "Save " + GDefine.ProgRecipeName + "?";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm = new frm_ProgressReport();
                frm.Message = "Saving in Progress. Please wait...";
                frm.Show();
                try
                {
                    await Task.Factory.StartNew(() =>
                    {
                        DispProg.Save();
                    });
                }
                finally
                {
                    frm.Close();
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            TaskFlowRate.logList.Clear();

            DialogResult = DialogResult.Abort;
            Close();
        }

        public void AddHead(TaskWeight.EHeadNo Head)
        {
            if (!HeadToCal.Contains(Head))
            {
                HeadToCal.Add(Head);
                HeadToCal.Sort();
            }
        }
        public void RemoveHead(TaskWeight.EHeadNo Head)
        {
            HeadToCal.Remove(Head);
        }
        private void btn_Head1_Click(object sender, EventArgs e)
        {
            if (!HeadToCal.Contains(TaskWeight.EHeadNo.One))
                AddHead(TaskWeight.EHeadNo.One);
            else
                RemoveHead(TaskWeight.EHeadNo.One);

            UpdateDisplay();
        }
        private void btn_Head2_Click(object sender, EventArgs e)
        {
            if (!HeadToCal.Contains(TaskWeight.EHeadNo.Two))
                AddHead(TaskWeight.EHeadNo.Two);
            else
                RemoveHead(TaskWeight.EHeadNo.Two);

            UpdateDisplay();
        }

        private void btn_Tare_Click(object sender, EventArgs e)
        {
            TaskWeight.SoftZero();
        }

        #region Tabpage - Settings
        private void cbAutoCalibrateFrame_Click(object sender, EventArgs e)
        {
            DispProg.FlowRate.EnableAutoCalFrame = !DispProg.FlowRate.EnableAutoCalFrame;

            Log.OnSet("FlowRate Cal, Enable Auto Cal Frame", !DispProg.FlowRate.EnableAutoCalFrame, DispProg.FlowRate.EnableAutoCalFrame);

            UpdateDisplay();
        }
        private void lblAutoCalFrameInterval_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Auto Cal Interval (frames)", ref DispProg.FlowRate.AutoCalFrameInterval, 0, 500);
            UpdateDisplay();
        }
        private void cbAutoCalibrateUnit_Click(object sender, EventArgs e)
        {
            DispProg.FlowRate.EnableAutoCalUnit = !DispProg.FlowRate.EnableAutoCalUnit;

            Log.OnSet("FlowRate Cal, Enable Auto Cal Unit", !DispProg.FlowRate.EnableAutoCalUnit, DispProg.FlowRate.EnableAutoCalUnit);

            UpdateDisplay();
        }
        private void lblAutoCalUnitInterval_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Auto Cal Interval (Unit)", ref DispProg.FlowRate.AutoCalUnitInterval, 0, 500);
            UpdateDisplay();
        }

        private void lblNoToAverage_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, No To Average", ref DispProg.FlowRate.NoToAve, 1, 100);
            UpdateDisplay();
        }
        private void lblDuration_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Duration (s)", ref DispProg.FlowRate.Duration, 1, 100);
            UpdateDisplay();
        }
        private void lblDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Delay (s)", ref DispProg.FlowRate.Delay, 1, 100);
            UpdateDisplay();
        }

        private void lblMinPressure_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Min Pressure (mPa)", ref DispProg.FlowRate.MinPressure, 0, 0.45);
            UpdateDisplay();
        }
        private void lblMaxPressure_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Max Pressure (mPa)", ref DispProg.FlowRate.MaxPressure, 0, 0.45);
            UpdateDisplay();
        }

        private void cbEnableTargetFlowrate_Click(object sender, EventArgs e)
        {
            DispProg.FlowRate.EnableTargetFlowRate = !DispProg.FlowRate.EnableTargetFlowRate;
            UpdateDisplay();
        }

        private void lblTargetFlowRate_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Target FlowRate (mg/s)", ref DispProg.FlowRate.TargetFlowrate, 0.1, 100);
            UpdateDisplay();
        }
        private void lblTargetFlowRateTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Target FlowRate Tol (mg/s)", ref DispProg.FlowRate.TargetFlowRateTol, 0.001, 10);
            UpdateDisplay();
        }


        #endregion

        #region Tabpage - Advance
        private void lblSlope_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Material Slope", ref DispProg.FlowRate.MaterialSlope, -10, 10);
            UpdateDisplay();
        }
        private void lblIntercept_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Material Intersect", ref DispProg.FlowRate.MaterialIntercept, -10, 10);
            UpdateDisplay();
        }
        private void btnAutoFit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Auto fit the material slope with the current results?", "Flowrate Auto Fit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                TaskFlowRate.ExecuteApproximateFit();
                UpdateDisplay();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Reset material slope and intercept?", "Flowrate Auto Fit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                DispProg.FlowRate.MaterialSlope = 0;
                DispProg.FlowRate.MaterialIntercept = 0;
                UpdateDisplay();
            }
        }
        private void btnResetInteval_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Reset Interval Counter?", "Flowrate", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                DispProg.FlowRate.AutoCalFrameInterval = 0;
                DispProg.FlowRate.AutoCalUnitInterval = 0;
                UpdateDisplay();
            }

        }
        private void lblTimeCompensate_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("FlowRate Cal, Time Compensate (%)", ref DispProg.FlowRate.TimeCompensate, -10, 10);
            UpdateDisplay();
        }
        #endregion

        bool calFail = true;
        private bool CalStart()
        {
            TaskFlowRate.logList.Clear();
            this.Invoke(new Action(() =>
            {
                lblResult1.BackColor = this.BackColor;
                lblResult1.Text = "-";
                lblResult2.BackColor = this.BackColor;
                lblResult2.Text = "-";

                lbxLog.Items.Clear();
            }));


            if (HeadToCal.Count == 0) return true;

            this.Enable(false);
            this.Invoke(new Action(() =>
            {
                btnCancel.Enabled = true;
            }));

            try
            {
                foreach (TaskWeight.EHeadNo head in HeadToCal)
                {
                    bool res = TaskFlowRate.ExecuteCal((int)head);

                    this.Invoke(new Action(() =>
                    {
                        if (head == TaskWeight.EHeadNo.One)
                        {
                            lblResult1.BackColor = res ? Color.Lime : Color.Red;
                            lblResult1.Text = res ? "Pass" : "Fail";
                        }
                        if (head == TaskWeight.EHeadNo.Two)
                        {
                            lblResult2.BackColor = res ? Color.Lime : Color.Red;
                            lblResult2.Text = "Pass";
                        }
                    }));

                    calFail = !res;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                this.Enable(true);
            }

            return true;
        }
        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            if (HeadToCal.Count == 0)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("No Head is selected.", EMcState.Notice, EMsgBtn.smbOK, false);
            }

            await Task.Run(() => CalStart());


            if (autoExec)
            {
                if (!calFail)
                {
                    TaskFlowRate.logList.Clear();

                    DialogResult = DialogResult.OK;
                    this.Close();
                };
            }

            DefineSafety.DoorLock = false;

            UpdateDisplay();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            TaskFlowRate.bCancel = true;
        }
    }
}
