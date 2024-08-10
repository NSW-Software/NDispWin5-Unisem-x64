using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_SpiralFill : Form
    {
        public static DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);
        
        public frm_DispCore_DispProg_SpiralFill()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void UpdateDisplay()
        {
            AppLanguage.Func2.UpdateText(this);

            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;

            lbl_HeadNo.Text = CmdLine.ID.ToString();
            lbl_ModelNo.Text = CmdLine.IPara[0].ToString();
            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();

            double StartX = CmdLine.X[6];
            double StartY = CmdLine.Y[6] -(CmdLine.DPara[6]/2);
            lbl_StartX.Text = StartX.ToString("F3");
            lbl_StartY.Text = StartY.ToString("F3");
            lbl_CenterX.Text = CmdLine.X[6].ToString("f3");
            lbl_CenterY.Text = CmdLine.Y[6].ToString("f3");
            lbl_Diameter.Text = CmdLine.DPara[6].ToString("f0");
            lbl_Angle.Text = CmdLine.DPara[7].ToString("f3");
            lbl_Pitch.Text = CmdLine.DPara[8].ToString("f3");

            pbox_.Refresh();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd;
            }
        }

        private void frmDispProg_Arc_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            this.Text = CmdName;

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };

            UpdateDisplay();
        }
        private void frmDispProg_Arc_Activated(object sender, EventArgs e)
        {
        }
        private void frmDispProg_Arc_Shown(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispProg_Arc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void lbl_HeadNo_Click(object sender, EventArgs e)
        {
            int i = Enum.GetNames(typeof(EHeadNo)).Length;
            UC.AdjustExec(CmdName + ", HeadNo", ref CmdLine.ID, 1, i);
            UpdateDisplay();
        }
        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", ModelNo", ref CmdLine.IPara[0], 0, TModelList.MAX_MODEL);
            UpdateDisplay();
        }
        private void lbl_Dispense_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[2] > 0) CmdLine.IPara[2] = 0; else CmdLine.IPara[2] = 1;
            UpdateDisplay();
        }
        private void btn_EditModel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
        }

        private void btn_GotoStartPos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[6];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[6];
            Y = Y - (CmdLine.DPara[6] / 2); 

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_CenterX_Click(object sender, EventArgs e)
        {
            double d = CmdLine.X[6];
            UC.AdjustExec(CmdName + ", Center X", ref d, -999, 999);
            CmdLine.X[6] = d;

            UpdateDisplay();
        }
        private void lbl_CenterY_Click(object sender, EventArgs e)
        {
            double d = CmdLine.Y[6];
            UC.AdjustExec(CmdName + ", Center Y", ref d, -999, 999);
            CmdLine.Y[6] = d;

            UpdateDisplay();
        }
        private void btn_SetCenterPos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[6], CmdLine.Y[6]);
            double CX = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            double CY = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CX, CY);
            CmdLine.X[6] = CX;
            CmdLine.Y[6] = CY;
            Log.OnSet(CmdName + ", Center XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoCenterPos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[6];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[6];

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_Diameter_Click(object sender, EventArgs e)
        {
            double d = CmdLine.DPara[6];
            if (UC.AdjustExec(CmdName + ", Diameter", ref d, 2, 100)) CmdLine.DPara[6] = d;
            UpdateDisplay();
        }
        private void lbl_Angle_Click(object sender, EventArgs e)
        {
            double d = CmdLine.DPara[7];
            if (UC.AdjustExec(CmdName + ", Angle", ref d, 180, 360)) CmdLine.DPara[7] = d;
            UpdateDisplay();
        }
        private void lbl_Pitch_Click(object sender, EventArgs e)
        {
            double d = CmdLine.DPara[8];
            if (UC.AdjustExec(CmdName + ", Pitch", ref d, 0.1, 25)) CmdLine.DPara[8] = d;
            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            Log.OnAction("OK", CmdName); 
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Log.OnAction("Cancel", CmdName); 
            Close();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //draw pattern
            try
            {
                PointF Abs_Center = new PointF((float)CmdLine.X[6], (float)CmdLine.Y[6]);
                float Diameter = (float)CmdLine.DPara[6];
                    float Sweep = (float)CmdLine.DPara[7];
                float Pitch = (float)CmdLine.DPara[8];
                float Radius = Diameter / 2;

                List<float> l_Radius = new List<float>();
                List<float> l_Start = new List<float>();
                List<float> l_Sweep = new List<float>();
                List<PointF> l_AbsEnd = new List<PointF>();
                List<PointF> l_AbsCenter = new List<PointF>();


                l_Radius.Add(Diameter / 2);
                l_Start.Add(-90);
                l_Sweep.Add(270);
                l_AbsCenter.Add(new PointF(Abs_Center.X, Abs_Center.Y));
                l_AbsEnd.Add(new PointF(l_AbsCenter[0].X - Radius, l_AbsCenter[0].Y));

                int i_ArcNo = 0;
                while (true)
                {
                    i_ArcNo++;
                    l_Radius.Add(l_Radius[i_ArcNo - 1] - (Pitch / 2));
                    if (l_Radius[i_ArcNo] < Pitch / 2) break;
                    l_Start.Add(l_Start[i_ArcNo - 1] + l_Sweep[i_ArcNo - 1]);
                    l_Sweep.Add(180);
                    if (i_ArcNo % 2 == 1)
                    {
                        l_AbsCenter.Add(new PointF(l_AbsCenter[i_ArcNo - 1].X - (Pitch / 2), l_AbsCenter[i_ArcNo - 1].Y));
                        l_AbsEnd.Add(new PointF(l_AbsCenter[i_ArcNo].X + l_Radius[i_ArcNo], l_AbsCenter[i_ArcNo].Y));
                    }
                    else
                    {
                        l_AbsCenter.Add(new PointF(l_AbsCenter[i_ArcNo - 1].X + (Pitch / 2), l_AbsCenter[i_ArcNo - 1].Y));
                        l_AbsEnd.Add(new PointF(l_AbsCenter[i_ArcNo].X - l_Radius[i_ArcNo], l_AbsCenter[i_ArcNo].Y));
                    }
                    if (i_ArcNo == 99) break;
                }

                float[] la_Radius = l_Radius.ToArray();
                float[] la_Start = l_Start.ToArray();
                float[] la_Sweep = l_Sweep.ToArray();
                PointF[] la_AbsCenter = l_AbsCenter.ToArray();
                PointF[] la_AbsEnd = l_AbsEnd.ToArray();
                float[] la_Length = l_Sweep.ToArray();
                float TLength = 0;

                float Rotate = Sweep - 270;

                Matrix m = new Matrix();
                m.Reset();
                m.RotateAt(-Rotate, la_AbsCenter[0], MatrixOrder.Append);

                la_Sweep[0] = la_Sweep[0] + Rotate;

                int idx = 0;
                foreach (float f in la_Start)
                {
                    if (idx == 0) { }
                    else
                    {
                        la_Start[idx] = la_Start[idx] + Rotate;
                    }

                    la_Length[idx] = la_Radius[idx] * (float)(la_Sweep[idx] / 180 * Math.PI);
                    TLength = TLength + la_Length[idx];

                    idx++;
                }
                m.TransformPoints(la_AbsCenter);
                m.TransformPoints(la_AbsEnd);

                float R = (pbox_.Height - 20) / (la_Radius[0] * 2);

                float[] dla_Radius = l_Radius.ToArray();
                float[] dla_Start = l_Start.ToArray();
                float[] dla_Sweep = l_Sweep.ToArray();
                PointF[] dla_AbsCenter = l_AbsCenter.ToArray();
                PointF[] dla_AbsEnd = l_AbsEnd.ToArray();

                idx = 0;
                foreach (float f in dla_Start)
                {
                    dla_Radius[idx] = dla_Radius[idx] * R;
                    dla_AbsCenter[idx].X = dla_AbsCenter[idx].X * R;
                    dla_AbsCenter[idx].Y = dla_AbsCenter[idx].Y * R;
                    dla_AbsEnd[idx].X = dla_AbsEnd[idx].X * R;
                    dla_AbsEnd[idx].Y = dla_AbsEnd[idx].Y * R;
                    idx++;
                }

                PointF Ofst = new PointF(-dla_AbsCenter[0].X + (pbox_.Width / 2), -dla_AbsCenter[0].Y + (pbox_.Height / 2));

                idx = 0;
                foreach (float f in dla_Start)
                {
                    dla_AbsCenter[idx].X = dla_AbsCenter[idx].X + Ofst.X;
                    dla_AbsCenter[idx].Y = dla_AbsCenter[idx].Y + Ofst.Y;
                    dla_AbsEnd[idx].X = dla_AbsEnd[idx].X + Ofst.X;
                    dla_AbsEnd[idx].Y = dla_AbsEnd[idx].Y + Ofst.Y;
                    idx++;
                }


                dla_Sweep[0] = dla_Sweep[0] + Rotate;

                idx = 0;
                foreach (float f in la_Start)
                {
                    if (idx == 0) { }
                    else
                    {
                        dla_Start[idx] = dla_Start[idx] + Rotate;
                    }
                    idx++;
                }

                PointF Pivot = dla_AbsCenter[0];//, pictureBox1.Height / 2);
                m = new Matrix();
                m.Reset();
                m.RotateAt(Rotate, Pivot, MatrixOrder.Append);
                m.TransformPoints(dla_AbsCenter);
                m.TransformPoints(dla_AbsEnd);

                SolidBrush SBrush = new SolidBrush(this.BackColor);
                Pen Pen = new Pen(Color.Navy);

                e.Graphics.Clear(this.BackColor);

                idx = 0;
                foreach (float f in dla_Start)
                {
                    Pen = new Pen(Color.Red);
                    e.Graphics.DrawArc(Pen, dla_AbsCenter[idx].X - dla_Radius[idx], (dla_AbsCenter[idx].Y - dla_Radius[idx]), dla_Radius[idx] * 2, dla_Radius[idx] * 2, dla_Start[idx], dla_Sweep[idx]);

                    Pen = new Pen(Color.Blue);
                    e.Graphics.DrawRectangle(Pen, dla_AbsEnd[idx].X - 2, -(dla_AbsEnd[idx].Y) - 2, 4, 4);

                    //Pen = new Pen(Color.Red);
                    //e.Graphics.DrawArc(Pen, dla_AbsCenter[idx].X - dla_Radius[idx], -(dla_AbsCenter[idx].Y + dla_Radius[idx]), dla_Radius[idx] * 2, dla_Radius[idx] * 2, dla_Start[idx], dla_Sweep[idx]);

                    //Pen = new Pen(Color.Blue);
                    //e.Graphics.DrawRectangle(Pen, dla_AbsEnd[idx].X - 2, -(dla_AbsEnd[idx].Y) - 2, 4, 4);

                    idx++;
                }
            }
            catch//(Exception Ex)
            {
            };
        }
    }
}
