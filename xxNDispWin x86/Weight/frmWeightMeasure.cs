using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    using ZedGraph;

    internal partial class frmWeightMeasure : Form
    {
        public List<TaskWeight.EHeadNo> HeadToCal = new List<TaskWeight.EHeadNo>();

        public frmWeightMeasure()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;

            CreateGraph();
            ClearGraph();
        }

        private void frmWeightMeasure_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            Text = "Weight Measurement";
            this.TopMost = true;
            this.BringToFront();

            TaskWeightMeas.logList.Clear();
            TaskWeightMeas.list_Weight.Clear();
            ClearGraph();

            UpdateDisplay();
        }

        private void frmWeightMeasure_FormClosing(object sender, FormClosingEventArgs e)
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
        private void tmrWeightDisplay_Tick_1(object sender, EventArgs e)
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

            if (lbxLog.Items.Count < TaskWeightMeas.logList.Count)
            {
                lbxLog.Items.Add(TaskWeightMeas.logList[lbxLog.Items.Count]);
            }
            if (list_Data.Count < TaskWeightMeas.list_Weight.Count)
            {
                GraphAddData(TaskWeightMeas.list_Weight[TaskWeightMeas.list_Weight.Count - 1]);
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

            cbEnableTargetWeight.Checked = DispProg.WeightMeas.EnableTargetWeight;
            lblTargetWeight.Text = $"{DispProg.WeightMeas.TargetWeight:f3}";
            lblWeightSpecTol.Text = $"+/- {DispProg.WeightMeas.TargetWeightTol:f3}";

            pnlDuration.Visible = !cbEnableTargetWeight.Checked;
            lblDuration.Text = $"{DispProg.WeightMeas.Duration:f3}";

            lblDelay.Text = $"{DispProg.WeightMeas.Delay:f3}";
            lbxLog.Text = $"{DispProg.WeightMeas.SampleCount}";
            lblSampleCount.Text = $"{DispProg.WeightMeas.SampleCount:f3}";
        }

        static ZedGraph.GraphPane myPane = new ZedGraph.GraphPane();
        static ZedGraph.PointPairList list_Data = new ZedGraph.PointPairList();
        static ZedGraph.PointPairList list_USL = new ZedGraph.PointPairList();
        static ZedGraph.PointPairList list_LSL = new ZedGraph.PointPairList();
        static ZedGraph.PointPairList list_Target = new ZedGraph.PointPairList();
        private void CreateGraph()
        {
            // Get a reference to the GraphPane instance in the ZedGraphControl
            myPane = zg1.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Weight Graph";
            myPane.XAxis.Title.Text = "Data Points";
            myPane.YAxis.Title.Text = "Weight (mg)";

            // Fill the symbols with white
            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;

            LineItem myCurve = myPane.AddCurve("", list_Data, Color.Green, SymbolType.None);
            LineItem myCurveTarget = myPane.AddCurve("", list_Target, Color.Blue, SymbolType.None);
            LineItem myCurveUSL = myPane.AddCurve("", list_USL, Color.Red, SymbolType.None);
            LineItem myCurveLSL = myPane.AddCurve("", list_LSL, Color.Red, SymbolType.None);
        }
        private void ClearGraph()
        {
            list_Data.Clear();
            list_Target.Clear();
            list_USL.Clear();
            list_LSL.Clear();

            zg1.AxisChange();
            zg1.Invalidate();
            zg1.Refresh();
        }
        private void DrawGraph()
        {
            zg1.AxisChange();
            zg1.Invalidate();
            zg1.Refresh();
        }
        public void GraphAddData(double data)
        {
            list_Data.Add(list_Data.Count + 1, data);

            if (DispProg.Meas_Spec > 0)
            {
                list_Target.Add(list_Data.Count, DispProg.WeightMeas.TargetWeight);
                list_USL.Add(list_Data.Count, DispProg.WeightMeas.TargetWeight + DispProg.WeightMeas.TargetWeightTol);
                list_LSL.Add(list_Data.Count, DispProg.WeightMeas.TargetWeight - DispProg.WeightMeas.TargetWeightTol);
            }
            else//MeasureSpec is updated, refresh all spec
                GraphUpdateSpec();

            zg1.AxisChange();
            zg1.Invalidate();
            zg1.Refresh();

            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            vsbar_Zoom.Value = 50;
        }
        private void GraphUpdateSpec()
        {
            list_Target.Clear();
            list_USL.Clear();
            list_LSL.Clear();

            for (int i = 1; i < list_Data.Count + 1; i++)
            {
                list_Target.Add(i, DispProg.WeightMeas.TargetWeight);
                list_USL.Add(i, DispProg.WeightMeas.TargetWeight + DispProg.WeightMeas.TargetWeightTol);
                list_LSL.Add(i, DispProg.WeightMeas.TargetWeight - DispProg.WeightMeas.TargetWeightTol);
            }

            zg1.AxisChange();
            zg1.Invalidate();
            zg1.Refresh();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmWeightSettings frm = new frmWeightSettings();
            frm.TopMost = true;
            frm.BringToFront();
            frm.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            TaskWeightMeas.logList.Clear();

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

        private void cbEnableTargetWeight_Click(object sender, EventArgs e)
        {
            DispProg.WeightMeas.EnableTargetWeight = !DispProg.WeightMeas.EnableTargetWeight;

            Log.OnSet("Weight Meas, Enable Auto Cal Frame", !DispProg.WeightMeas.EnableTargetWeight, DispProg.WeightMeas.EnableTargetWeight);

            UpdateDisplay();
        }
        private void lblTargetWeight_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Meas, Target Weight (mg)", ref DispProg.WeightMeas.TargetWeight, 1, 1000);
            UpdateDisplay();
        }
        private void lblWeightSpecTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Meas, Weight Tol (mg)", ref DispProg.WeightMeas.TargetWeightTol, 0.01, 100);
            UpdateDisplay();
        }
        private void lblDuration_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Meas, Duration (s)", ref DispProg.WeightMeas.Duration, 1, 100);
            UpdateDisplay();
        }
        private void lblDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Meas, Delay (s)", ref DispProg.WeightMeas.Delay, 1, 100);
            UpdateDisplay();
        }
        private void lblSampleCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Meas, Sample (count)", ref DispProg.WeightMeas.SampleCount, 1, 5000);
            UpdateDisplay();
        }


        bool measFail = true;
        private bool MeasStart()
        {
            TaskWeightMeas.logList.Clear();

            this.Invoke(new Action(() =>
            {
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
                    bool res = TaskWeightMeas.ExecuteMeas((int)head);

                    measFail = !res;
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

            TaskWeightMeas.logList.Clear();
            TaskWeightMeas.list_Weight.Clear();
            ClearGraph();


            await Task.Run(() => MeasStart());

            if (!Directory.Exists(GDefine.WeightMeasPath)) Directory.CreateDirectory(GDefine.WeightMeasPath);
            string Filename = GDefine.WeightMeasPath + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";
            Refresh();
            TaskWeightMeas.WriteToFile(Filename, 0, this);

            DefineSafety.DoorLock = false;

            UpdateDisplay();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            TaskWeightMeas.bCancel = true;
        }

        private void vsbar_Zoom_Scroll(object sender, ScrollEventArgs e)
        {
            double Range = (TaskWeight.MeasureSpecTol * ((double)vsbar_Zoom.Value / 10));

            myPane.YAxis.Scale.Min = TaskWeight.MeasureSpec - Range;
            myPane.YAxis.Scale.Max = TaskWeight.MeasureSpec + Range;

            zg1.AxisChange();
            zg1.Invalidate();
            zg1.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            string Filename = DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";

            if (!Directory.Exists(GDefine.WeightMeasPath))
                Directory.CreateDirectory(GDefine.WeightMeasPath);

            sfd.DefaultExt = "txt";
            sfd.InitialDirectory = GDefine.WeightMeasPath;
            sfd.FileName = Filename;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Text = "Weight Measurement [" + DispProg.Pump_Type.ToString() + "] - " + sfd.FileName;

                Refresh();
                TaskWeightMeas.WriteToFile(sfd.FileName, 0, this);
                //bSaved = true;
            }
        }
    }
}
