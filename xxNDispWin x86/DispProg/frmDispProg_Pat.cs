using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispCore
{
    internal partial class frm_DispCore_DispProg_Pat : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        enum EArcCircMode { ThreePtSTE, ThreePtSCE, TwoPtSC };
        EArcCircMode ArcCircMode = EArcCircMode.ThreePtSTE;

        public frm_DispCore_DispProg_Pat()
        {
            InitializeComponent();

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            //AppLanguage.Func.SetComponent(this);
        }

        static NSW.Net.Point2D StartPt = new NSW.Net.Point2D(0, 0);
        static NSW.Net.Point2D CenterPt = new NSW.Net.Point2D(0, 0);
        static double Radius = 0;
        static double StartA = 0;
        static double EndA = 0;
        static double SweepA = 0;//unit = rad
        static double Dir = 0;
        bool StartPtValid = false;

        private void UpdateDisplayOnce()
        {
            int Line = LineNo;
            while (Line > 0)
            {
                Line--;
                if (DispProg.Script[ProgNo].CmdList.Line[Line].Cmd == DispProg.ECmd.LINE ||
                    DispProg.Script[ProgNo].CmdList.Line[Line].Cmd == DispProg.ECmd.MOVE ||
                    DispProg.Script[ProgNo].CmdList.Line[Line].Cmd == DispProg.ECmd.DOT)
                {
                    StartPt.X = DispProg.Script[ProgNo].CmdList.Line[Line].X[0];
                    StartPt.Y = DispProg.Script[ProgNo].CmdList.Line[Line].Y[0];
                    StartPtValid = true;
                    break;
                }
                if (DispProg.Script[ProgNo].CmdList.Line[Line].Cmd == DispProg.ECmd.ARC)
                {
                    StartPt.X = DispProg.Script[ProgNo].CmdList.Line[Line].X[1];
                    StartPt.Y = DispProg.Script[ProgNo].CmdList.Line[Line].Y[1];
                    StartPtValid = true;
                    break;
                }
            }
        }
        private void UpdateDisplay()
        {
            AppLanguage.Func2.UpdateText(this);

            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;

            lbl_HeadNo.Text = CmdLine.ID.ToString();
            lbl_ModelNo.Text = CmdLine.IPara[0].ToString();

            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();
            lbl_Cont.Text = (CmdLine.IPara[10] > 0).ToString();
            lbl_EarlyCutoff.Text = CmdLine.IPara[3].ToString();

            UI_Utils.SetControlSelected(btn_3PtsSTE, ArcCircMode == EArcCircMode.ThreePtSTE);
                        UI_Utils.SetControlSelected(btn_3PtsSCE, ArcCircMode == EArcCircMode.ThreePtSCE);
                        UI_Utils.SetControlSelected(btn_2PtSC, ArcCircMode == EArcCircMode.TwoPtSC);

                        pnl_Pt1.Enabled = (ArcCircMode == EArcCircMode.ThreePtSTE);
                        pnl_Pt2.Enabled = (ArcCircMode != EArcCircMode.TwoPtSC);
            pnl_PtC.Enabled = (ArcCircMode == EArcCircMode.TwoPtSC || ArcCircMode == EArcCircMode.ThreePtSCE);

            lbl_X1.Text = CmdLine.X[0].ToString("F3");
            lbl_Y1.Text = CmdLine.Y[0].ToString("F3");
            lbl_X2.Text = CmdLine.X[1].ToString("F3");
            lbl_Y2.Text = CmdLine.Y[1].ToString("F3");

            lbl_Diameter.BackColor = SystemColors.Window;
            lbl_Angle.BackColor = SystemColors.Window;
            lbl_Length.BackColor = SystemColors.Window;

            if (StartPtValid && LineNo > 0)
            {
                lbl_StartXY.Text = StartPt.X.ToString("F3") + ", " + StartPt.Y.ToString("F3");

                double X2 = CmdLine.X[0];
                double Y2 = CmdLine.Y[0];
                double X3 = CmdLine.X[1];
                double Y3 = CmdLine.Y[1];
                if (TaskGantry.GXAxis.Para.InvertPulse)
                {
                    //X2 = -X2;
                    //X3 = -X3;
                }
                if (TaskGantry.GYAxis.Para.InvertPulse)
                {
                    //Y2 = -Y2;
                    //Y3 = -Y3;
                }

                try
                {
                    GDefine.Arc3PGetInfo(StartPt.X, StartPt.Y, X2, Y2, X3, Y3, ref CenterPt.X, ref CenterPt.Y, ref Radius, ref StartA, ref EndA, ref SweepA, ref Dir);
                }
                catch
                {
                    //lbl_CenterXY.Text = "invalid";
                    lbl_XC.Text = "invalid";
                    lbl_YC.Text = "invalid";
                    lbl_XCMove.Text = "invalid";
                    lbl_YCMove.Text = "invalid";
                    lbl_Dir.Text = "invalid";
                    lbl_Diameter.Text = "invalid";
                    lbl_Length.Text = "invalid";
                    lbl_Angle.Text = "invalid";

                    return;
                }
                //lbl_CenterXY.Text = CenterPt.X.ToString("F3") + ", " + CenterPt.Y.ToString("F3");
                lbl_XC.Text = CenterPt.X.ToString("F3");
                lbl_YC.Text = CenterPt.Y.ToString("F3");
                lbl_XCMove.Text = CenterPt.X.ToString("F3");
                lbl_YCMove.Text = CenterPt.Y.ToString("F3");
                string s_Dir = "CW";
                //if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                //    if (Dir < 0) s_Dir = "CCW";
                //else
                //    if (Dir > 0) s_Dir = "CCW";
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE) Dir = -Dir;
                if (Dir < 0) s_Dir = "CCW";
                lbl_Dir.Text = s_Dir;

                lbl_Diameter.Text = (Radius * 2).ToString("F4");
                if (CmdLine.Cmd == DispProg.ECmd.CIRC)
                    lbl_Length.Text = (Radius * 2 * Math.PI).ToString("F4");
                else
                    lbl_Length.Text = (Radius * Math.Abs(SweepA)).ToString("F4");
                if (CmdLine.Cmd == DispProg.ECmd.CIRC)
                    lbl_Angle.Text = (360).ToString("F3");
                else
                    lbl_Angle.Text = (SweepA / Math.PI * 180).ToString("F3");
            }
            else
            {
                lbl_StartXY.Text = "undetermined";
                //lbl_CenterXY.Text = "undetermined";
                lbl_XC.Text = "undetermined";
                lbl_YC.Text = "undetermined";
                lbl_XCMove.Text = "undetermined";
                lbl_YCMove.Text = "undetermined";
                lbl_Dir.Text = "undetermined";
                lbl_Diameter.Text = "undetermined";
                lbl_Length.Text = "undetermined";
                lbl_Angle.Text = "undetermined";
            }
        }

        private string CmdName
        {
            get
            {
                string Cmd = "";
                if (CmdLine.Cmd == DispProg.ECmd.CIRC)
                    Cmd = "CIRC";
                else
                    Cmd = "ARC";


                return LineNo.ToString("d3") + " " + Cmd;
            }
        }

        private void frmDispProg_Arc_Load(object sender, EventArgs e)
        {
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            this.Text = CmdName;

            btn_3PtsSCE.Visible = (CmdLine.Cmd == DispProg.ECmd.ARC);
            btn_2PtSC.Visible = (CmdLine.Cmd == DispProg.ECmd.CIRC);
            //btn_3PtsSTE.Visible = true;// (CmdLine.Cmd == DispProg.ECmd.ARC);

            lbl_Angle.Enabled = (CmdLine.Cmd == DispProg.ECmd.ARC);
            btn_SetAngle.Enabled = (CmdLine.Cmd == DispProg.ECmd.ARC);

            lbl_Length.Enabled = (CmdLine.Cmd == DispProg.ECmd.ARC);
            btn_SetLength.Enabled = (CmdLine.Cmd == DispProg.ECmd.ARC);

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };

            UpdateDisplayOnce();
            UpdateDisplay();
        }

        private void frmDispProg_Arc_Shown(object sender, EventArgs e)
        {
        }
        private void frmDispProg_Arc_Activated(object sender, EventArgs e)
        {
        }
        private void frmDispProg_Arc_VisibleChanged(object sender, EventArgs e)
        {
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

        private void cbox_Disp_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[2] > 0) CmdLine.IPara[2] = 0; else CmdLine.IPara[2] = 1;
            UpdateDisplay();
        }

        private void btn_EditModel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
        }

        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void lbl_X1_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.X[0], 3);
            UC.AdjustExec(CmdName + ", X", ref X, -1000, 1000);
            CmdLine.X[0] = X;
            UpdateDisplay();
        }

        private void lbl_Y1_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[0], 3);
            UC.AdjustExec(CmdName + ", Y", ref Y, -1000, 1000);
            CmdLine.Y[0] = Y;
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
            Log.OnSet(CmdName + ", Point 2 XY", Old, New);

            UpdateDisplay();
        }

        private void lbl_X2_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.X[1], 3);
            UC.AdjustExec(CmdName + ", X2", ref X, -1000, 1000);
            CmdLine.X[1] = X;
            UpdateDisplay();
        }

        private void lbl_Y2_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[1], 3);
            UC.AdjustExec(CmdName + ", Y2", ref Y, -1000, 1000);
            CmdLine.Y[1] = Y;
            UpdateDisplay();
        }

        private void btn_SetPt2Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            CmdLine.X[1] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            Log.OnSet(CmdName + ", Point 3 XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt2Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_GotoStartXY_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + StartPt.X;
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + StartPt.Y;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetXYC_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CenterPt.X, CenterPt.Y);
            CenterPt.X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CenterPt.Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CenterPt.X, CenterPt.Y);
            Log.OnSet(CmdName + ", Center XY", Old, New);


            if (CmdLine.Cmd == DispProg.ECmd.CIRC)
            {
                double X2 = 0;
                double Y2 = 0;
                double X3 = 0;
                double Y3 = 0;
                GDefine.CircStartCenterGet3Points(StartPt.X, StartPt.Y, CenterPt.X, CenterPt.Y, ref X2, ref Y2, ref X3, ref Y3, Dir);
                CmdLine.X[0] = X2;
                CmdLine.Y[0] = Y2;
                CmdLine.X[1] = X3;
                CmdLine.Y[1] = Y3;
            }

            if (CmdLine.Cmd == DispProg.ECmd.ARC)
            {
                double X2 = 0;
                double Y2 = 0;
                double X3 = CmdLine.X[1];
                double Y3 = CmdLine.Y[1];
                GDefine.CircStartCenterGetThruPoint(StartPt.X, StartPt.Y, CenterPt.X, CenterPt.Y, X3, Y3, ref X2, ref Y2, Dir);
                CmdLine.X[0] = X2;
                CmdLine.Y[0] = Y2;
            }

            UpdateDisplay();
        }

        private void btn_GotoXYC_Click(object sender, EventArgs e)
        {
            btn_GotoXYCMove_Click(sender, e);
        }

        private void lbl_XC_Click(object sender, EventArgs e)
        {
            if (LineNo == 0)
            {
                MessageBox.Show("Set Diameter not valid for first command");
                UpdateDisplay();
                return;
            }

            if (!(DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.LINE ||
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.MOVE ||
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.ARC))
            {
                MessageBox.Show("Set Diameter not valid when previous command not of draw type");
                UpdateDisplay();
                return;
            }

            DialogResult dr = MessageBox.Show("Set Diameter will update previous command position", "", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel) return;

            double X = Math.Round(CenterPt.X, 3);
            UC.AdjustExec(CmdName + ", Center X", ref X, -1000, 1000);

            NSW.Net.Point2D NewCenter = new NSW.Net.Point2D(X, CenterPt.Y);

            //***Convert to Cartesion
            NSW.Net.Point2D Pt_1 = new NSW.Net.Point2D(StartPt.X, StartPt.Y);
            NSW.Net.Point2D Pt_2 = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            NSW.Net.Point2D Pt_3 = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);

            //***Translate Position
            Pt_1 = Pt_1.Translate(CenterPt, NewCenter);
            Pt_2 = Pt_2.Translate(CenterPt, NewCenter);
            Pt_3 = Pt_3.Translate(CenterPt, NewCenter);

            StartPt.X = Pt_1.X;
            StartPt.Y = Pt_1.Y;
            CmdLine.X[0] = Pt_2.X;
            CmdLine.Y[0] = Pt_2.Y;
            CmdLine.X[1] = Pt_3.X;
            CmdLine.Y[1] = Pt_3.Y;

            UpdateDisplay();
        }

        private void lbl_YC_Click(object sender, EventArgs e)
        {
            if (LineNo == 0)
            {
                MessageBox.Show("Set Diameter not valid for first command");
                UpdateDisplay();
                return;
            }

            if (!(DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.LINE ||
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.MOVE ||
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.ARC))
            {
                MessageBox.Show("Set Diameter not valid when previous command not of draw type");
                UpdateDisplay();
                return;
            }

            DialogResult dr = MessageBox.Show("Set Diameter will update previous command position", "", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel) return;

            double Y = Math.Round(CenterPt.Y, 3);
            UC.AdjustExec(CmdName + ", Center Y", ref Y, -1000, 1000);

            NSW.Net.Point2D NewCenter = new NSW.Net.Point2D(CenterPt.X, Y);

            //***Convert to Cartesion
            NSW.Net.Point2D Pt_1 = new NSW.Net.Point2D(StartPt.X, StartPt.Y);
            NSW.Net.Point2D Pt_2 = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            NSW.Net.Point2D Pt_3 = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);

            //***Translate Position
            Pt_1 = Pt_1.Translate(CenterPt, NewCenter);
            Pt_2 = Pt_2.Translate(CenterPt, NewCenter);
            Pt_3 = Pt_3.Translate(CenterPt, NewCenter);

            StartPt.X = Pt_1.X;
            StartPt.Y = Pt_1.Y;
            CmdLine.X[0] = Pt_2.X;
            CmdLine.Y[0] = Pt_2.Y;
            CmdLine.X[1] = Pt_3.X;
            CmdLine.Y[1] = Pt_3.Y;

            UpdateDisplay();
        }

        private void btn_SetXYCMove_Click(object sender, EventArgs e)
        {
            if (LineNo == 0)
            {
                MessageBox.Show("Set Center XY not valid for first command");
                UpdateDisplay();
                return;
            }

            if (!(DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.LINE ||
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.MOVE ||
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.ARC))
            {
                MessageBox.Show("Set Center XY not valid when previous command not of draw type");
                UpdateDisplay();
                return;
            }

            DialogResult dr = MessageBox.Show("Set Center XY will update previous command position", "", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();


            NSW.Net.Point2D NewCenter = new NSW.Net.Point2D(0,0);
            NewCenter.X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            NewCenter.Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CenterPt.X, CenterPt.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(NewCenter.X, NewCenter.Y);
            Log.OnSet(CmdName + ", Center XY", Old, New);


            //***Convert to Cartesion
            NSW.Net.Point2D Pt_1 = new NSW.Net.Point2D(StartPt.X, StartPt.Y);
            NSW.Net.Point2D Pt_2 = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            NSW.Net.Point2D Pt_3 = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);

            //***Translate Position
            Pt_1 = Pt_1.Translate(CenterPt, NewCenter);
            Pt_2 = Pt_2.Translate(CenterPt, NewCenter);
            Pt_3 = Pt_3.Translate(CenterPt, NewCenter);



            StartPt.X = Pt_1.X;
            StartPt.Y = Pt_1.Y;
            CmdLine.X[0] = Pt_2.X;
            CmdLine.Y[0] = Pt_2.Y;
            CmdLine.X[1] = Pt_3.X;
            CmdLine.Y[1] = Pt_3.Y;

            UpdateDisplay();
        }

        private void btn_GotoXYCMove_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CenterPt.X;
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CenterPt.Y;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_ChangeDir_Click(object sender, EventArgs e)
        {
        }
        private void lbl_Diameter_Click(object sender, EventArgs e)
        {
            double d = Math.Round(Radius * 2, 4);
            if (UC.AdjustExec(CmdName + ", Diameter (mm)", ref d, 1, 50))
            {
                Radius = d / 2;

                lbl_Diameter.BackColor = Color.Orange;
                lbl_Diameter.Text = d.ToString("F4");
            }
            else
                UpdateDisplay();
        }
        private void btn_SetDiameterC_Click(object sender, EventArgs e)
        {
            if (LineNo == 0)
            {
                MessageBox.Show("Set Diameter not valid for first command");
                UpdateDisplay();
                return;
            }

            if (!(DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.LINE ||
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.MOVE ||
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.ARC))
            {
                MessageBox.Show("Set Diameter not valid when previous command not of draw type");
                UpdateDisplay();
                return;
            }

            DialogResult dr = MessageBox.Show("Set Diameter will update previous command position", "", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                UpdateDisplay();
                return;
            }

            NSW.Net.Point2D Pt_1 = new NSW.Net.Point2D(StartPt.X, StartPt.Y);
            NSW.Net.Point2D Pt_2 = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            NSW.Net.Point2D Pt_3 = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);

            NSW.Net.Polar Polar_1 = new NSW.Net.Polar(CenterPt, StartPt);
            NSW.Net.Polar Polar_2 = new NSW.Net.Polar(CenterPt, Pt_2);
            NSW.Net.Polar Polar_3 = new NSW.Net.Polar(CenterPt, Pt_3);

            double Old = Polar_1.R;
            Polar_1.R = Radius;
            Polar_2.R = Radius;
            Polar_3.R = Radius;
            double New = Polar_1.R;
            Log.OnSet(CmdName + ", Diameter", Old, New);

            CmdLine.X[0] = Polar_2.Point2D.X + CenterPt.X;
            CmdLine.Y[0] = Polar_2.Point2D.Y + CenterPt.Y;
            CmdLine.X[1] = Polar_3.Point2D.X + CenterPt.X;
            CmdLine.Y[1] = Polar_3.Point2D.Y + CenterPt.Y;

            StartPt.X = Polar_1.Point2D.X + CenterPt.X;
            StartPt.Y = Polar_1.Point2D.Y + CenterPt.Y;

            UpdateDisplay();
        }

        int SelectedHead = 1;
        private void lbl_Head_Click(object sender, EventArgs e)
        {
            if (SelectedHead == 2) SelectedHead = 1;
            else
                SelectedHead = 2;

            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);

            if (DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.LINE || 
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.MOVE)
            {
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].X[0] = StartPt.X;
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Y[0] = StartPt.Y;
            }
            if (DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Cmd == DispProg.ECmd.ARC)
            {
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].X[1] = StartPt.X;
                DispProg.Script[ProgNo].CmdList.Line[LineNo - 1].Y[1] = StartPt.Y; 
            }

            //frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName); 
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName); 
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_Dispense_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[2] > 0) CmdLine.IPara[2] = 0; else CmdLine.IPara[2] = 1;
            UpdateDisplay();
        }

        private void lbl_Cont_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[10] > 0) CmdLine.IPara[10] = 0; else CmdLine.IPara[10] = 1;
            UpdateDisplay();
        }

        private void lbl_Dir_Click(object sender, EventArgs e)
        {
            double tempX = CmdLine.X[0];
            double tempY = CmdLine.Y[0];

            CmdLine.X[0] = CmdLine.X[1];
            CmdLine.Y[0] = CmdLine.Y[1];

            CmdLine.X[1] = tempX;
            CmdLine.Y[1] = tempY;

            UpdateDisplay();
        }


        double d_TempSweepAngle;
        private void lbl_Angle_Click(object sender, EventArgs e)
        {
            double d = Math.Round(SweepA / Math.PI *180, 3);
            if (UC.AdjustExec(CmdName + ", Angle (deg)", ref d, 30, 359))
            {
                d_TempSweepAngle = d * Math.PI / 180;
                lbl_Angle.BackColor = Color.Orange;
                lbl_Angle.Text = d.ToString("F4");
            }
            else
                UpdateDisplay();
        }
        private void btn_SetAngle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Set Diameter will update next command position", "", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                UpdateDisplay();
                return;
            }

            NSW.Net.Point2D Pt_1 = new NSW.Net.Point2D(StartPt.X, StartPt.Y);
            NSW.Net.Point2D Pt_2 = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            NSW.Net.Point2D Pt_3 = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);

            NSW.Net.Polar Polar_Start = new NSW.Net.Polar(CenterPt, Pt_1);
            NSW.Net.Polar Polar_2 = new NSW.Net.Polar(CenterPt, Pt_2);
            NSW.Net.Polar Polar_3 = new NSW.Net.Polar(CenterPt, Pt_3);


            if (Dir < 0)
            {
                Polar_2.A = Polar_Start.A + (d_TempSweepAngle/2);
                Polar_3.A = Polar_Start.A + d_TempSweepAngle;
            }
            else
            {
                Polar_2.A = Polar_Start.A - (d_TempSweepAngle/2);
                Polar_3.A = Polar_Start.A - d_TempSweepAngle;
            }

            CmdLine.X[0] = Polar_2.Point2D.X + CenterPt.X;
            CmdLine.Y[0] = Polar_2.Point2D.Y + CenterPt.Y;
            CmdLine.X[1] = Polar_3.Point2D.X + CenterPt.X;
            CmdLine.Y[1] = Polar_3.Point2D.Y + CenterPt.Y;

            UpdateDisplay();
        }

        double d_TempLength;
        private void lbl_Length_Click(object sender, EventArgs e)
        {
            double d = Math.Round(Radius * Math.Abs(SweepA), 3);
            if (UC.AdjustExec(CmdName + ", Length (ms)", ref d, 0.5, Radius * 2 * Math.PI))
            {
                d_TempLength = d;
                lbl_Length.BackColor = Color.Orange;
                lbl_Length.Text = d.ToString("F4");
            }
            else
                UpdateDisplay();
        }
        private void btn_SetLength_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Set Length will update next command position", "", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                UpdateDisplay();
                return;
            }

            NSW.Net.Point2D Pt_1 = new NSW.Net.Point2D(StartPt.X, StartPt.Y);
            NSW.Net.Point2D Pt_2 = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            NSW.Net.Point2D Pt_3 = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);

            NSW.Net.Polar Polar_Start = new NSW.Net.Polar(CenterPt, Pt_1);
            NSW.Net.Polar Polar_2 = new NSW.Net.Polar(CenterPt, Pt_2);
            NSW.Net.Polar Polar_3 = new NSW.Net.Polar(CenterPt, Pt_3);

            double d_NewSweepAngle = d_TempLength / Radius;

            if (Dir < 0)
            {
                Polar_2.A = Polar_Start.A + (d_NewSweepAngle / 2);
                Polar_3.A = Polar_Start.A + d_NewSweepAngle;
            }
            else
            {
                Polar_2.A = Polar_Start.A - (d_NewSweepAngle / 2);
                Polar_3.A = Polar_Start.A - d_NewSweepAngle;
            }

            CmdLine.X[0] = Polar_2.Point2D.X + CenterPt.X;
            CmdLine.Y[0] = Polar_2.Point2D.Y + CenterPt.Y;
            CmdLine.X[1] = Polar_3.Point2D.X + CenterPt.X;
            CmdLine.Y[1] = Polar_3.Point2D.Y + CenterPt.Y;

            UpdateDisplay();
        }

        private void btn_3PtsSTE_Click(object sender, EventArgs e)
        {
            ArcCircMode = EArcCircMode.ThreePtSTE;
            UpdateDisplay();
        }

        private void btn_3PtsSCE_Click(object sender, EventArgs e)
        {
            ArcCircMode = EArcCircMode.ThreePtSCE;
            UpdateDisplay();
        }

        private void btn_2PtSC_Click(object sender, EventArgs e)
        {
            ArcCircMode = EArcCircMode.TwoPtSC;
            UpdateDisplay();
        }


        private void lbl_EarlyCutoff_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Early Cutoff (ms)", ref CmdLine.IPara[3], 0, 5000);
            UpdateDisplay();
        }

        private void frm_DispCore_DispProg_Arc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispCore_DispProg.Done = true;
            frm_DispProg2.Done = true;
        }



    }
}
