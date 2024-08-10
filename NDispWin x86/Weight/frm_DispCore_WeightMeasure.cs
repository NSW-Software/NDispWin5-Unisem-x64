using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace NDispWin
{
    using ZedGraph;

    internal partial class frm_DispCore_WeightMeasure : Form
    {
        public List<TaskWeight.EHeadNo> HeadToCal = new List<TaskWeight.EHeadNo>();

        string dp = "f5";

        public frm_DispCore_WeightMeasure()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;

            CreateGraph();
            ClearGraph();

            lbox_Result.Items.Clear();
            ResultUpdateHeader();
            TaskWeight.WeightMeas_Reset();
        }

        private void frmWeightSetup_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            Text = "Weight Measurement [" + DispProg.Pump_Type.ToString() + "]";

            AppLanguage.Func2.UpdateText(this);

            lbox_Result.Items.Clear();

            TaskWeight.Cal_Meas_Weight = DispProg.Cal_Meas_Weight == 0 ? DispProg.Target_Weight : DispProg.Cal_Meas_Weight;
            TaskWeight.MeasureSpec = DispProg.Meas_Spec;
            if (DispProg.Meas_Spec_Tol > 0) TaskWeight.MeasureSpecTol = DispProg.Meas_Spec_Tol;

            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.PP:
                case TaskDisp.EPumpType.PP2D:
                case TaskDisp.EPumpType.PPD:
                    TaskWeight.CalMeasType = TaskWeight.ECalMeasType.Density;
                    TaskWeight.CalAdjustType = TaskWeight.ECalAdjustType.Volume;
                    if (TaskWeight.Cal_Meas_Weight > 0)
                        TaskDisp.PP_SetWeight(new double[2] { TaskWeight.Cal_Meas_Weight, TaskWeight.Cal_Meas_Weight }, false, true);
                    break;
                case TaskDisp.EPumpType.HM:
                    TaskWeight.CalMeasType = TaskWeight.ECalMeasType.FR_mg_s;
                    TaskWeight.CalAdjustType = TaskWeight.ECalAdjustType.Speed;
                    break;
                case TaskDisp.EPumpType.Vermes:
                case TaskDisp.EPumpType.Vermes1560:
                    TaskWeight.CalMeasType = TaskWeight.ECalMeasType.FR_mg_dot;
                    TaskWeight.CalAdjustType = TaskWeight.ECalAdjustType.Pressure;
                    break;
                case TaskDisp.EPumpType.SP:
                    TaskWeight.CalMeasType = TaskWeight.ECalMeasType.FR_mg_s;
                    TaskWeight.CalAdjustType = TaskWeight.ECalAdjustType.Pressure;
                    break;
                default:
                    MessageBox.Show("Pump Type " + DispProg.Pump_Type.ToString() + " not supported.");
                    break;
            }

            if (!TaskWeight.WeightIsOpen)
            {
                TaskWeight.WeightOpen();
            }

            UpdateDisplay();
        }
        private void frm_DispCore_WeightMeasure_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskDisp.FPressOff();
            TaskWeight.SoftZeroReset();

            try
            {
                TaskDisp.TaskMoveGZZ2Up();
            }
            catch { };
        }

        private void UpdateDisplay()
        {
            switch (TaskWeight.CalMeasType)
            {
                case TaskWeight.ECalMeasType.Density:
                    lbl_CurrentCalName.Text = "Density";
                    //lbl_CurrentCalUnit.Text = "(" + TaskWeight.WEIGHT_UNIT + ")";
                    break;
                case TaskWeight.ECalMeasType.FR_mg_s:
                    lbl_CurrentCalName.Text = "FlowRate";
                    //lbl_CurrentCalUnit.Text = "(" + TaskWeight.CalMeasUnit + ")";
                    break;
                case TaskWeight.ECalMeasType.FR_mg_dot:
                    lbl_CurrentCalName.Text = "FlowRate";
                    //lbl_CurrentCalUnit.Text = "(" + TaskWeight.CalMeasUnit + ")";
                    break;
            }

            lbl_CurrentCal1.Text = TaskWeight.CurrentCal[0].ToString("f4");
            lbl_CurrentCal2.Text = TaskWeight.CurrentCal[1].ToString("f4");

            if (HeadToCal.Contains(TaskWeight.EHeadNo.One))
                btn_Head1.BackColor = Color.Lime;
            else
                btn_Head1.BackColor = this.BackColor;

            if (HeadToCal.Contains(TaskWeight.EHeadNo.Two))
                btn_Head2.BackColor = Color.Lime;
            else
                btn_Head2.BackColor = this.BackColor;

            lbl_Spec.Text = TaskWeight.MeasureSpec.ToString(dp);
            lbl_Tol.Text = TaskWeight.MeasureSpecTol.ToString(dp);
            d_TolPcnt = (TaskWeight.MeasureSpecTol / TaskWeight.MeasureSpec) * 100;
            d_TolPcnt = Math.Round(d_TolPcnt, 1);
            lbl_TolPcnt.Text = d_TolPcnt.ToString("f2");

            lbl_WeightSampleCount.Text = TaskWeight.MeasureCount.ToString();
            lbl_DotsPerSample.Text = (DispProg.DotsPerSample_Meas > 0 ? "P|" : "") + TaskWeight.iDotsPerSample(TaskWeight.EMeasType.Meas).ToString();
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
                list_Target.Add(list_Data.Count, TaskWeight.MeasureSpec);
                list_USL.Add(list_Data.Count, TaskWeight.MeasureSpec + TaskWeight.MeasureSpecTol);
                list_LSL.Add(list_Data.Count, TaskWeight.MeasureSpec - TaskWeight.MeasureSpecTol);
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
                list_Target.Add(i, TaskWeight.MeasureSpec);
                list_USL.Add(i, TaskWeight.MeasureSpec + TaskWeight.MeasureSpecTol);
                list_LSL.Add(i, TaskWeight.MeasureSpec - TaskWeight.MeasureSpecTol);
            }

            zg1.AxisChange();
            zg1.Invalidate();
            zg1.Refresh();
        }

        public void UpdateStats()
        {
            double Min = TaskWeight.list_WM_MeasWeight.Min();
            double Max = TaskWeight.list_WM_MeasWeight.Max();
            double Ave = TaskWeight.list_WM_MeasWeight.Average();

            NSW.Net.Stats Stat = new NSW.Net.Stats();
            double StDev = Stat.StDev(TaskWeight.list_WM_MeasWeight);

            lbl_Min.Text = Min.ToString(dp);
            lbl_Max.Text = Max.ToString(dp);
            lbl_Range.Text = (Max - Min).ToString(dp);
            lbl_Ave.Text = Ave.ToString(dp);
            lbl_StDev.Text = StDev.ToString(dp);
        }

        bool bErr = false;
        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_Status.Text = TaskWeight.Meas_Status.ToString();

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


            tmr_WeightDisplay.Enabled = false;
            double d_mg = 0;
            if (bErr) return;
            bErr = !TaskWeight.WeightValue(ref d_mg);
            lbl_WeightCurrentValue.Text = d_mg.ToString("f3");
            tmr_WeightDisplay.Enabled = true;
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            frm_DispCore_WeightSetting frm = new frm_DispCore_WeightSetting();

            frm.TopMost = true;
            frm.BringToFront();
            frm.ShowDialog();

            UpdateDisplay();
        }

        bool bSaved = false;
        private void btn_SaveToFile_Click(object sender, EventArgs e)
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
                TaskWeight.WriteToFile(sfd.FileName, 0, this);
                bSaved = true;
            }
        }

        private void btn_Zero_Click(object sender, EventArgs e)
        {
            TaskWeight.SoftZero();
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

        private void tmr_Run_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            Text = "Weight Measurement [" + DispProg.Pump_Type.ToString() + "]";

            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            if (HeadToCal.Count == 0)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("No Head is selected.", EMcState.Notice, EMsgBtn.smbOK, false);
            }

            ClearGraph();

            MeasStart(true);

            Event.OP_WEIGHT_MEASURE.Set();

            DefineSafety.DoorLock = false;

            UpdateDisplay();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            MeasStart(false);
            UpdateDisplay();
        }

        #region Settings
        private void lbl_Spec_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Weight Measure, Spec (mg)", ref TaskWeight.MeasureSpec, 0.0001, 1000))
            {
                //TaskDisp.UpdateVolByWeight(TaskWeight.MeasureSpec, TaskWeight.MeasureSpec);

                GraphUpdateSpec();
            }
            UpdateDisplay();
        }
        double d_TolPcnt = 0;
        private void lbl_Tol_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Weight Measure, Spec Limit (+/-mg)", ref TaskWeight.MeasureSpecTol, 0.001, 100))
            {
                d_TolPcnt = TaskWeight.MeasureSpecTol / TaskWeight.MeasureSpec;
                d_TolPcnt = Math.Round(d_TolPcnt, 3);

                GraphUpdateSpec();
            }
            UpdateDisplay();
        }
        private void lbl_TolPcnt_Click(object sender, EventArgs e)
        {
            double d = d_TolPcnt;
            if (UC.AdjustExec("Weight Measure, Spec Limit (+/-%mg)", ref d, 0.01, 10))
            {
                TaskWeight.MeasureSpecTol = TaskWeight.MeasureSpec * (d / 100);
                TaskWeight.MeasureSpecTol = Math.Round(TaskWeight.MeasureSpecTol, 5);

                GraphUpdateSpec();
            }
            UpdateDisplay();
        }
        private void lbl_WeightMeasureCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Measure, Count (count)", ref TaskWeight.MeasureCount, 1, 2500);
            UpdateDisplay();
        }
        #endregion
        private void btn_ReComputeResult_Click(object sender, EventArgs e)
        {
            //if (list_TestResult.Count == 0) return;

            //try
            //{
            //    Spec = Convert.ToDouble(lbl_Spec.Text);
            //}
            //catch
            //{
            //    Msg MsgBox = new Msg();
            //    MsgBox.Show(ErrCode.WEIGHT_INVALID_SPEC);
            //    return;
            //}

            //try
            //{
            //    Tol = Convert.ToDouble(lbl_Tol.Text);
            //}
            //catch
            //{
            //    Msg MsgBox = new Msg();
            //    MsgBox.Show(ErrCode.WEIGHT_INVALID_SPEC_LIMIT);
            //    return;
            //}

            if (TaskWeight.list_WM_MeasWeight.Count == 0) return;

            lbox_Result.Items.Clear();

            ResultUpdateHeader();

            for (int i = 0; i < TaskWeight.list_WM_PurgeWeight.Count; i++)
            {
                lbox_Result.Items.Add("[Purge]" + (char)9 + TaskWeight.list_WM_PurgeWeight[i].ToString(dp));
            }

            for (int i = 0; i < TaskWeight.list_WM_MeasWeight.Count; i++)
            {
                lbox_Result.Items.Add("[" + (i + 1).ToString() + "]" + (char)9 + TaskWeight.list_WM_MeasWeight[i].ToString(dp));
            }

            ComputeResult();
        }

        private void ResultUpdateHeader()
        {
            lbox_Result.Items.Add("Samples" + (char)9 + TaskWeight.MeasureCount.ToString());
            lbox_Result.Items.Add("Dots" + (char)9 + TaskWeight.iDotsPerSample(TaskWeight.EMeasType.Meas).ToString() + (DispProg.DotsPerSample_Meas > 0 ? " *P" : ""));
            lbox_Result.Items.Add("Output" + (char)9 + TaskWeight.eOutputResult(TaskWeight.EMeasType.Meas).ToString() + (DispProg.DotsPerSample_Meas > 0 ? " *P" : ""));
            lbox_Result.Items.Add("Unit" + (char)9 + "mg");
        }
        private void ComputeResult()
        {
            double Min = 0;
            double Max = 0;
            double Ave = 0;
            double StDev = 0;
            double Cpl = 0;
            double Cpu = 0;
            double Cpk = 0;
            double Cp = 0;

            Min = TaskWeight.list_WM_MeasWeight.Min();
            Max = TaskWeight.list_WM_MeasWeight.Max();
            Ave = TaskWeight.list_WM_MeasWeight.Average();
            NSW.Net.Stats Stat = new NSW.Net.Stats();
            StDev = Stat.StDev(TaskWeight.list_WM_MeasWeight);

            Cpl = (Ave - (TaskWeight.MeasureSpec - TaskWeight.MeasureSpecTol)) / (3 * StDev);
            Cpu = ((TaskWeight.MeasureSpec + TaskWeight.MeasureSpecTol) - Ave) / (3 * StDev);
            Cpk = Math.Min(Cpl, Cpu);
            Cp = (TaskWeight.MeasureSpecTol * 2) / (6 * StDev);


            lbox_Result.Items.Add("");

            #region
            lbox_Result.Items.Add("Spec" + (char)9 + TaskWeight.MeasureSpec.ToString(dp));
            lbox_Result.Items.Add("LSpec" + (char)9 + (TaskWeight.MeasureSpec - TaskWeight.MeasureSpecTol).ToString(dp));
            lbox_Result.Items.Add("USpec" + (char)9 + (TaskWeight.MeasureSpec + TaskWeight.MeasureSpecTol).ToString(dp));
            lbox_Result.Items.Add("Min" + (char)9 + Min.ToString(dp));
            lbox_Result.Items.Add("Max" + (char)9 + Max.ToString(dp));
            lbox_Result.Items.Add("Range" + (char)9 + (Max - Min).ToString(dp));
            lbox_Result.Items.Add("Ave" + (char)9 + Ave.ToString(dp));
            lbox_Result.Items.Add("StDev" + (char)9 + StDev.ToString(dp));
            lbox_Result.Items.Add("Cpl" + (char)9 + Cpl.ToString(dp));
            lbox_Result.Items.Add("Cpu" + (char)9 + Cpu.ToString(dp));
            lbox_Result.Items.Add("Cpk" + (char)9 + Cpk.ToString(dp));
            lbox_Result.Items.Add("Cp" + (char)9 + Cp.ToString(dp));
            lbox_Result.Items.Add("");
            #endregion

            lbox_Result.SelectedIndex = lbox_Result.Items.Count - 1;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (!bSaved && TaskWeight.list_WM_MeasWeight.Count > 0)
            {
                //if (MessageBox.Show("Current Weight Data is not saved. Save the weight data?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btn_SaveToFile_Click(sender, e);
                //    if (!bSaved) return;
                //}
                if (!Directory.Exists(GDefine.WeightMeasPath)) Directory.CreateDirectory(GDefine.WeightMeasPath);
                string Filename = GDefine.WeightMeasPath + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmm") + "_Head0" + ".txt";
                TaskWeight.WriteToFile(Filename, 0, this);
                bSaved = true;
            }

            if (DispProg.Target_Weight > 0) TaskDisp.PP_SetWeight(DispProg.Disp_Weight, true, true);
            Close();
        }

        private void btn_Ctrl1_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.DispCtrlOpened(0)) return;
            TaskDisp.ShowDispCtrl(0);
        }
        private void btn_Ctrl2_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.DispCtrlOpened(1)) return;
            TaskDisp.ShowDispCtrl(1);
        }

        private void lbox_Result_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private bool MeasStart(bool New)
        {
            if (HeadToCal.Count == 0) return true;

            if (DispProg.Head_Operation == TaskDisp.EHeadOperation.Single)
            {
                if (HeadToCal.Contains(TaskWeight.EHeadNo.Two))
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.WEIGHT_PROG_HEAD_OP_SINGLE_SELECTED);
                    return false;
                }
            }

            foreach (TaskWeight.EHeadNo Head in HeadToCal)
            {
                #region Check Ready
                if (Head == TaskWeight.EHeadNo.One)
                    if (!TaskDisp.CtrlCheckReady(true, false))
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL1_NOT_READY);
                        return false;
                    }
                if (Head == TaskWeight.EHeadNo.Two)
                    if (!TaskDisp.CtrlCheckReady(false, true))
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL2_NOT_READY);
                        return false;
                    }
                #endregion
                
                this.Enable(false);
                vsbar_Zoom.Enabled = true;
                try
                {
                    lbox_Result.Items.Clear();
                    ResultUpdateHeader();
                    TaskWeight.WeightMeas_Reset();

                    TaskWeight.TimeStart = DateTime.Now;

                    bool Res = TaskWeight.WeightMeas_Execute(lbox_Result, this, list_Data, (int)Head + 1);

                    if (TaskWeight.list_WM_MeasWeight.Count >= TaskWeight.MeasureCount) ComputeResult();

                    TaskWeight.TimeEnd = DateTime.Now;

                    if (!Res) return false;

                    TaskWeight.Meas_Status = TaskWeight.EWeightMeasStatus.Measured;

                    if (!Directory.Exists(GDefine.WeightMeasPath)) Directory.CreateDirectory(GDefine.WeightMeasPath);
                    string Filename = GDefine.WeightMeasPath + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmm") + "_Head" + ((int)Head + 1).ToString() + ".txt";
                    TaskWeight.WriteToFile(Filename, (int)Head + 1, this);
                    bSaved = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    this.Enable(true);
                }
            }

            UpdateDisplay();

            return true;
        }

        private void vsbar_Zoom_Scroll(object sender, ScrollEventArgs e)
        {
            double Range = (TaskWeight.MeasureSpecTol * ((double)vsbar_Zoom.Value / 10)) ;

            myPane.YAxis.Scale.Min = TaskWeight.MeasureSpec - Range;
            myPane.YAxis.Scale.Max = TaskWeight.MeasureSpec + Range;

            zg1.AxisChange();
            zg1.Invalidate();
            zg1.Refresh();
        }
    }
    
}
