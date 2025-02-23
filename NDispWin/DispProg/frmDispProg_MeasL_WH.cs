using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_MeasL_WH : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_MeasL_WH()
        {
            InitializeComponent();
            GControl.LogForm(this);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Left = 0;
            TopLevel = false;
            TopMost = true;
            Top = 0;

            CreateGraph();

            //AppLanguage.Func.SetComponent(this);
        }

        public void UpdateDisplay()
        {
            lbl_MeasNo.Text = CmdLine.ID.ToString();

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");
            lbl_X2Y2.Text = CmdLine.X[1].ToString("F3") + ", " + CmdLine.Y[1].ToString("F3");

            lbl_MSpeed.Text = CmdLine.DPara[0].ToString("F3");
            lbl_MInterval.Text = CmdLine.DPara[0].ToString("F3");
            lbl_SampleTimes.Text = CmdLine.IPara[0].ToString("F3");
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_ML_WH_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = CmdName;

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            if (CmdLine.DPara[0] == 0) CmdLine.DPara[0] = 1;
            if (CmdLine.IPara[0] == 0) CmdLine.IPara[0] = 1;

            gbox_Data.Visible = false;

            UpdateDisplay();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
        }

        private void lbl_MeasNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", MeasNo", ref CmdLine.ID, 0, 15);
            UpdateDisplay();
        }

        private void btn_SetPt1Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            Log.OnSet(CmdName + ", Pt1", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetPt2Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            CmdLine.X[1] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            Log.OnSet(CmdName + ", Pt2", Old, New);

            UpdateDisplay();
        }

        private void btn_GotoPt2Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_MSpeed_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Meas Speed (mm/s)", ref CmdLine.DPara[0], 1, 20);
            UpdateDisplay();
        }

        private void lbl_MInterval_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Meas Interval", ref CmdLine.DPara[1], 0, 0.05);
            UpdateDisplay();
        }

        private void lbl_Sample_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Sample", ref CmdLine.IPara[0], 1, 30);
            UpdateDisplay();
        }

        TaskMeasure.WHData WHData = new TaskMeasure.WHData();

        List<double> WData = new List<double>();

        private void btn_Test_Click(object sender, EventArgs e)
        {
            Enabled = false;

            WHData.Clear();

            WData.Clear();
            lbox_Data.Items.Clear();

            double XS = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double YS = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];
            double XE = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double YE = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];
            double MSpeed = CmdLine.DPara[0];

            int Sample = Math.Max(1, CmdLine.IPara[0]);

            NSW.Net.Stats Stats = new NSW.Net.Stats();
            for (int i = 0; i < Sample; i++)
            {
                TaskMeasure.MeasL_WH(ref WHData, XS, YS, XE, YE, MSpeed);
                WData.Add(WHData.Height());
                lbox_Data.Items.Add(i.ToString() + (char)9 + WHData.Height().ToString("F3"));
            }
            lbox_Data.Items.Add("******************************");
            lbox_Data.Items.Add("StDev" + (char)9 + Stats.StDev(WData).ToString("F3"));
            lbox_Data.Items.Add("Min" + (char)9 + WData.Min().ToString("F3"));
            lbox_Data.Items.Add("Max" + (char)9 + WData.Max().ToString("F3"));
            lbox_Data.Items.Add("Max-Min" + (char)9 + (WData.Max() - WData.Min()).ToString("F3"));
            lbox_Data.Items.Add("Ave" + (char)9 + WData.Average().ToString("F3"));
           
            lbl_Width.Text = WHData.Width().ToString("F3");
            //lbl_Height.Text = WHData.Height().ToString("F3");
            //NSW.Net.Stats Stats = new NSW.Net.Stats();
            lbl_Height.Text = Stats.Median(WData).ToString("F3");

            DrawGraph();

            Enabled = true;
        }

        static GraphPane myPane = new GraphPane();
        static PointPairList list = new PointPairList();
        static PointPairList listS = new PointPairList();
        static PointPairList listD = new PointPairList();
        private void CreateGraph()
        {
            // Get a reference to the GraphPane instance in the ZedGraphControl
            myPane = zg1.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Profile";
            myPane.XAxis.Title.Text = "Distance";
            myPane.YAxis.Title.Text = "Height";
            //myPane.Y2Axis.Title.Text = "Parameter B";


            // Fill the symbols with white
            //myCurve.Symbol.Fill = new Fill(Color.White);
            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;

            LineItem myCurve = myPane.AddCurve("", list, Color.Red, SymbolType.None);
            LineItem mySCurve = myPane.AddCurve("", listS, Color.Blue, SymbolType.None);
            LineItem myDCurve = myPane.AddCurve("", listD, Color.Green, SymbolType.None);
            myDCurve.Line.Width = 2;
        }
        private void ClearGraph()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    list[i].Clear();
            //}
        }
        private void DrawGraph()
        {
            // Make up some data points based on the Sine function
            list.Clear();
            for (int i = 0; i < WHData.Count; i++)
            {
                list.Add(WHData.Dist[i], WHData.Data[i]);
                //                double x = (double)i * 5.0;
  //              double y = Math.Sin((double)i * Math.PI / 15.0) * 16.0;
    //            double y2 = y * 13.5;
      //          list.Add(x, y);
        //        list2.Add(x, y2);
            }
            // Generate a red curve with diamond symbols, and "Alpha" in the legend
            listS.Clear();
            for (int i = 0; i < WHData.Count; i++)
            {
                if (WHData.SData.Count > i)
                listS.Add(WHData.Dist[i], WHData.SData[i]);
            }

            listD.Clear();
            for (int i = 0; i < WHData.Count; i++)
            {
                if (WHData.DData.Count > i)
                listD.Add(WHData.Dist[i], WHData.DData[i]);
            }

            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;

            zg1.AxisChange();
            zg1.Invalidate();
            zg1.Refresh();
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            TaskVision.BdOrientLightRGB = TaskVision.CurrentLightRGBA;

            TaskVision.LightingOn(TaskVision.DefLightRGB);
            //frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName);
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            //frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                WHData.Load(ofd.FileName);

                //listS.Clear();
                //listD.Clear();
                WHData.SData.Clear();
                WHData.DData.Clear();

                DrawGraph();
                //lbl_Width.Text = WHData.Width().ToString("F3");
                //lbl_Height.Text = WHData.Height().ToString("F3");
                //lbl_DataPts.Text = WHData.Count.ToString("F3");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                WHData.Save(sfd.FileName);
            }
        }

        private void zg1_Load(object sender, EventArgs e)
        {

        }

        private void zg1_Click(object sender, EventArgs e)
        {
            //if (zg1.Dock != DockStyle.Fill) 
            //    zg1.Dock = DockStyle.Fill;
            //else
            //    zg1.Dock = DockStyle.None;
        }

        private void zg1_DoubleClick(object sender, EventArgs e)
        {
            if (zg1.Dock != DockStyle.Fill)
                zg1.Dock = DockStyle.Fill;
            else
                zg1.Dock = DockStyle.None;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gbox_Data.Visible = !gbox_Data.Visible;
        }

        private void btn_RunAtPos_Click(object sender, EventArgs e)
        {
            Enabled = false;

            WHData.Clear();

            WData.Clear();
            lbox_Data.Items.Clear();

            double XS = TaskGantry.GXPos();
            double YS = TaskGantry.GYPos();
            double DistX = CmdLine.X[1] - CmdLine.X[0];
            double DistY = CmdLine.Y[1] - CmdLine.Y[0];
            double XE = XS + DistX;
            double YE = YS + DistY;
            double MSpeed = CmdLine.DPara[0];

            int Sample = Math.Max(1, CmdLine.IPara[0]);

            NSW.Net.Stats Stats = new NSW.Net.Stats();
            for (int i = 0; i < Sample; i++)
            {
                TaskMeasure.MeasL_WH(ref WHData, XS, YS, XE, YE, MSpeed);
                WData.Add(WHData.Height());
                lbox_Data.Items.Add(i.ToString() + (char)9 + WHData.Height().ToString("F3"));
            }
            lbox_Data.Items.Add("******************************");
            lbox_Data.Items.Add("StDev" + (char)9 + Stats.StDev(WData).ToString("F3"));
            lbox_Data.Items.Add("Min" + (char)9 + WData.Min().ToString("F3"));
            lbox_Data.Items.Add("Max" + (char)9 + WData.Max().ToString("F3"));
            lbox_Data.Items.Add("Max-Min" + (char)9 + (WData.Max() - WData.Min()).ToString("F3"));
            lbox_Data.Items.Add("Ave" + (char)9 + WData.Average().ToString("F3"));

            lbl_Width.Text = WHData.Width().ToString("F3");
            //lbl_Height.Text = WHData.Height().ToString("F3");
            //NSW.Net.Stats Stats = new NSW.Net.Stats();
            lbl_Height.Text = Stats.Median(WData).ToString("F3");

            DrawGraph();

            Enabled = true;
        }

        private void btn_Analyze1_Click(object sender, EventArgs e)
        {
            try
            {
                WHData.SData.Clear();
                WHData.DData.Clear();
                WHData.Analyse(1);
                double W1 = WHData.Width(0);
                double H1 = WHData.Height(0);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
            DrawGraph();
            UpdateResult();
        }

        private void btn_Analyze2_Click(object sender, EventArgs e)
        {
            try
            {
                WHData.SData.Clear();
                WHData.DData.Clear();
                WHData.Analyse(2);
                double W1 = WHData.Width(0);
                double W2 = WHData.Width(1);
                double ID = WHData.ID;
                double OD = WHData.OD;

                double H1 = WHData.Height(0);
                double H2 = WHData.Height(1);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
            DrawGraph();
            UpdateResult();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateResult()
        {
            lbox_Result.Items.Clear();
            //lbox_Result.Items.Add("");

            string S = "H1" + (char)9 + "H2" + (char)9 + "W1" + (char)9 + "W2" + (char)9 + "ID" + (char)9 + "OD" + (char)9;
            lbox_Result.Items.Add(S);

            S = WHData.Height(0).ToString("f3") + (char)9 + WHData.Height(1).ToString("f3") + (char)9 +
                WHData.Width(0).ToString("f3") + (char)9 + WHData.Width(1).ToString("f3") + (char)9 +
                WHData.ID.ToString("f3") + (char)9 + WHData.OD.ToString("f3") + (char)9;
            lbox_Result.Items.Add(S);
        }

        private void frm_DispCore_DispProg_MeasL_WH_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

    }
}
