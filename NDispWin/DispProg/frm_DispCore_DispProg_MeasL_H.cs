using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_MeasL_H : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_MeasL_H()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            combox_Ref1Pattern.Items.Clear();
            combox_Ref2Pattern.Items.Clear();
            combox_MeasPattern.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TaskMeasureH.EMeasPattern)).Length; i++)
            {
                combox_Ref1Pattern.Items.Add(((TaskMeasureH.EMeasPattern)i).ToString());
                combox_Ref2Pattern.Items.Add(((TaskMeasureH.EMeasPattern)i).ToString());
                combox_MeasPattern.Items.Add(((TaskMeasureH.EMeasPattern)i).ToString());
            }

            combox_Ref1Judge.Items.Clear();
            combox_Ref2Judge.Items.Clear();
            combox_MeasJudge.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TaskMeasureH.EMeasJudge)).Length; i++)
            {
                combox_Ref1Judge.Items.Add(((TaskMeasureH.EMeasJudge)i).ToString());
                combox_Ref2Judge.Items.Add(((TaskMeasureH.EMeasJudge)i).ToString());
                combox_MeasJudge.Items.Add(((TaskMeasureH.EMeasJudge)i).ToString());
            }

            //AppLanguage.Func.SetComponent(this);
        }
        
        private void UpdateDisplay()
        {
            lbl_MeasID.Text = CmdLine.ID.ToString();
            //lbl_AlignType.Text = CmdLine.IPara[2].ToString() + " - " + Enum.GetName(typeof(EAlignType), CmdLine.IPara[2]);

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");
            lbl_X2Y2.Text = CmdLine.X[1].ToString("F3") + ", " + CmdLine.Y[1].ToString("F3");

            combox_Ref1Pattern.SelectedIndex = CmdLine.IPara[5];
            combox_Ref1Judge.SelectedIndex = CmdLine.IPara[6];
            combox_MeasPattern.SelectedIndex = CmdLine.IPara[10];
            combox_MeasJudge.SelectedIndex = CmdLine.IPara[11];
            combox_Ref2Pattern.SelectedIndex = CmdLine.IPara[15];
            combox_Ref2Judge.SelectedIndex = CmdLine.IPara[16];

            double SampleRate_kHz = CmdLine.DPara[20];
            lbl_SampleRate.Text = SampleRate_kHz.ToString("f1");
            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();

            lbl_StartV.Text = CmdLine.DPara[1].ToString("f3");
            lbl_DriveV.Text = CmdLine.DPara[2].ToString("f3");
            lbl_Accel.Text = CmdLine.DPara[3].ToString("f3");
            double MSpeed = CmdLine.DPara[0];
            lbl_MSpeed.Text = MSpeed.ToString("f3");

            lbl_RefLength.Text = CmdLine.DPara[5].ToString("f3");
            lbl_MeasLength.Text = CmdLine.DPara[8].ToString("f3");

            lbl_Resolution.Text = (MSpeed / (SampleRate_kHz * 1000)).ToString("f5");
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_MeasL_H_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;//Settle Time

            if (CmdLine.DPara[0] == 0) CmdLine.DPara[0] = 1.0;
            if (CmdLine.DPara[1] == 0) CmdLine.DPara[1] = TaskGantry.GXAxis.Para.StartV;
            if (CmdLine.DPara[2] == 0) CmdLine.DPara[2] = TaskGantry.GXAxis.Para.FastV;
            if (CmdLine.DPara[3] == 0) CmdLine.DPara[3] = TaskGantry.GXAxis.Para.Accel;

            if (CmdLine.DPara[5] == 0) CmdLine.DPara[5] = 0.5;
            if (CmdLine.DPara[8] == 0) CmdLine.DPara[8] = 1.0;

            if (CmdLine.DPara[20] == 0) CmdLine.DPara[20] = 1.0;//SampleRate

            UpdateDisplay();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
        }

        private void lbl_HeightID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Height ID", ref CmdLine.ID, 0, DispProg.MAX_IDS - 1);
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
            Log.OnSet(CmdName + ", Point 1 XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZUp()) return;

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
            Log.OnSet(CmdName + ", Point 2 XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt2Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            Enabled = false;

            NSW.Net.Stats Stats = new NSW.Net.Stats();
            string dp = "f4";

            try
            {
                lbox_Ref1Data.Items.Clear();
                lbox_MeasData.Items.Clear();
                lbox_Ref2Data.Items.Clear();
                lbox_Data.Items.Clear();

                TaskMeasureH.MeasL_H_Data Data = new TaskMeasureH.MeasL_H_Data();
                TaskMeasureH.MeasL_H_Profile Profile = new TaskMeasureH.MeasL_H_Profile();

                double X1 = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
                double Y1 = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];
                double X2 = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
                double Y2 = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];
                TaskMeasureH.MeasL_H(CmdLine, ref Profile, ref Data, X1, Y1, X2, Y2);

                #region Ref1 List Display
                if (Profile.Ref1.Count > 0)
                {
                    for (int i = 0; i < Profile.Ref1.Count; i++)
                    {
                        lbox_Ref1Data.Items.Add((i + 1).ToString() + (char)9 + Profile.Ref1[i].ToString(dp));
                    }
                    lbox_Ref1Data.Items.Add("***************");
                    lbox_Ref1Data.Items.Add("Count " + (char)9 + Profile.Ref1.Count.ToString(dp));
                    lbox_Ref1Data.Items.Add("Min " + (char)9 + Profile.Ref1.Min().ToString(dp));
                    lbox_Ref1Data.Items.Add("Max " + (char)9 + Profile.Ref1.Max().ToString(dp));
                    lbox_Ref1Data.Items.Add("Ave " + (char)9 + Profile.Ref1.Average().ToString(dp));
                    lbox_Ref1Data.Items.Add("Median " + (char)9 + Stats.Median(Profile.Ref1).ToString(dp));
                    lbox_Ref1Data.Items.Add("StDev " + (char)9 + Stats.StDev(Profile.Ref1).ToString(dp));
                    lbox_Ref1Data.Items.Add("***************");
                }
                #endregion

                #region Meas List Display
                if (Profile.Meas.Count > 0)
                {
                    for (int i = 0; i < Profile.Meas.Count; i++)
                    {
                        lbox_MeasData.Items.Add((i + 1).ToString() + (char)9 + Profile.Meas[i].ToString(dp));
                    }
                    lbox_MeasData.Items.Add("***************");
                    lbox_MeasData.Items.Add("Count " + (char)9 + Profile.Meas.Count.ToString(dp));
                    lbox_MeasData.Items.Add("Min " + (char)9 + Profile.Meas.Min().ToString(dp));
                    lbox_MeasData.Items.Add("Max " + (char)9 + Profile.Meas.Max().ToString(dp));
                    lbox_MeasData.Items.Add("Ave " + (char)9 + Profile.Meas.Average().ToString(dp));
                    lbox_MeasData.Items.Add("Median " + (char)9 + Stats.Median(Profile.Meas).ToString(dp));
                    lbox_MeasData.Items.Add("StDev " + (char)9 + Stats.StDev(Profile.Meas).ToString(dp));
                    lbox_MeasData.Items.Add("***************");
                }
                #endregion

                #region Ref2 List Display
                if (Profile.Ref2.Count > 0)
                {
                    for (int i = 0; i < Profile.Ref2.Count; i++)
                    {
                        lbox_Ref2Data.Items.Add((i + 1).ToString() + (char)9 + Profile.Ref2[i].ToString());
                    };
                    lbox_Ref2Data.Items.Add("***************");
                    lbox_Ref2Data.Items.Add("Count " + (char)9 + Profile.Ref2.Count.ToString(dp));
                    lbox_Ref2Data.Items.Add("Min " + (char)9 + Profile.Ref2.Min().ToString(dp));
                    lbox_Ref2Data.Items.Add("Max " + (char)9 + Profile.Ref2.Max().ToString(dp));
                    lbox_Ref2Data.Items.Add("Ave " + (char)9 + Profile.Ref2.Average().ToString(dp));
                    lbox_Ref2Data.Items.Add("Median " + (char)9 + Stats.Median(Profile.Ref2).ToString(dp));
                    lbox_Ref2Data.Items.Add("StDev " + (char)9 + Stats.StDev(Profile.Ref2).ToString(dp));
                    lbox_Ref2Data.Items.Add("***************");
                }
                #endregion

                #region Summary List Display
                string S =
                    "Col" + (char)9 +
                    "Row" + (char)9 +
                    "Height" + (char)9 +
                    "Ref1" + (char)9 +
                    "Ref2" + (char)9 +
                    "Meas" + (char)9;
                lbox_Data.Items.Add(S);

                S = "";
                S = S + Data.Col.ToString() + (char)9;
                S = S + Data.Row.ToString() + (char)9;
                S = S + Data.Height.ToString(dp) + (char)9;
                S = S + Data.Ref1.ToString(dp) + (char)9;
                S = S + Data.Ref2.ToString(dp) + (char)9;
                S = S + Data.Meas.ToString(dp) + (char)9;

                lbox_Data.Items.Add(S);
                #endregion 
            }
            catch (Exception ex)
            {
                Msg Msg = new Msg();
                Msg.Show(ex.Message.ToString());
            }

            Enabled = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            Log.OnAction("OK", CmdName); 
            frm_DispProg2.Done = true;
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName); 
            Close();
        }

        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Settle Time (ms)", ref CmdLine.IPara[4], 0, 500);
            UpdateDisplay();
        }

        private void lbl_StartV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(TaskGantry.GXAxis, ref Min, ref Max);
            UC.AdjustExec(CmdName + ", Start Speed (mm/s)", ref CmdLine.DPara[1], Min, Max);
            UpdateDisplay();
        }

        private void lbl_DriveV_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(TaskGantry.GXAxis, ref Min, ref Max);
            UC.AdjustExec(CmdName + ", Drive Speed (mm/s)", ref CmdLine.DPara[2], Min, Max);
            UpdateDisplay();
        }

        private void lbl_Accel_Click(object sender, EventArgs e)
        {
            double Min = 0;
            double Max = 0;
            CommonControl.GetMotorSpeedRange(TaskGantry.GXAxis, ref Min, ref Max);
            UC.AdjustExec(CmdName + ", Accel (mm/s)", ref CmdLine.DPara[3], Min, Max);
            UpdateDisplay();
        }

        private void lbl_MSpeed_Click(object sender, EventArgs e)
        {
            double Min = 1;
            double Max = 20;
            CommonControl.GetMotorSpeedRange(TaskGantry.GXAxis, ref Min, ref Max);
            UC.AdjustExec(CmdName + ", Measure Speed (mm/s)", ref CmdLine.DPara[0], Min, Max);
            UpdateDisplay();
        }

        private void lbl_SampleRate_Click(object sender, EventArgs e)
        {
            double Min = 0.1;
            double Max = 2.5;// Enum.GetNames(typeof(CLaser.MEDAQ.IFD2451.ESampleRate)).Length;
            double Val = CmdLine.DPara[20];
            UC.AdjustExec(CmdName + ", Sample Rate", ref Val, Min, Max);

            List<double> list = new List<double> { 0.1, 0.2, 0.3, 1.0, 2.5 };

            // find closest to number
            double Closest = list.OrderBy(item => Math.Abs(Val - item)).First();

            CmdLine.DPara[20] = Closest;

            UpdateDisplay();
        }

        private void lbl_RefLength_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Ref Length (mm)", ref CmdLine.DPara[5], 0.05, 5);
            UpdateDisplay();
        }

        private void lbl_MeasLength_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Meas Length (mm)", ref CmdLine.DPara[8], 0.05, 10);
            UpdateDisplay();
        }

        private void lbl_Resolution_Click(object sender, EventArgs e)
        {
            //GDefine.uc.UserAdjustExecute("Meas Length", ref CmdLine.DPara[5], 0.05, 10);
        }

        private void combox_Ref1Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdLine.IPara[5] = combox_Ref1Pattern.SelectedIndex;
            UpdateDisplay();
        }

        private void combox_Ref2Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdLine.IPara[15] = combox_Ref2Pattern.SelectedIndex;
            UpdateDisplay();
        }

        private void combox_MeasPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdLine.IPara[10] = combox_MeasPattern.SelectedIndex;
            UpdateDisplay();
        }

        private void combox_Ref1Judge_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdLine.IPara[6] = combox_Ref1Judge.SelectedIndex;
            UpdateDisplay();
        }

        private void combox_Ref2Judge_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdLine.IPara[16] = combox_Ref2Judge.SelectedIndex;
            UpdateDisplay();
        }

        private void combox_MeasJudge_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdLine.IPara[11] = combox_MeasJudge.SelectedIndex;
            UpdateDisplay();
        }

        private void btn_Data_Click(object sender, EventArgs e)
        {
            gbox_Data.Visible = !gbox_Data.Visible;
        }
    }
}
