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
    internal partial class frm_DispCore_DispProg_DotAngArr : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_DotAngArr()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            //AppLanguage.Func.SetComponent(this);
        }

        private void UpdateDisplay()
        {
            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;
            lbl_HeadNo.Text = CmdLine.ID.ToString();

            int C = 0; int R = 0;
            DispProg.rt_Layouts[0].UnitNoGetRC(DispProg.RunTime.UIndex, ref C, ref R);
            lbl_UnitRC.Text = "C,R = " + C.ToString() + "," + R.ToString();
            lbl_UnitRC.Visible = TaskDisp.Option_EnableRealTimeFineTune && C > 0 && R > 0;

            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();

            lbl_ModelNo.Text = CmdLine.IPara[0].ToString();

            if (CmdLine.IPara[1] >= Enum.GetNames(typeof(EDotMode)).Length) CmdLine.IPara[1] = 0;

            lbl_Mode.Text = Enum.GetName(typeof(EDotMode), CmdLine.IPara[1]);

            lbl_X1.Text = CmdLine.X[0].ToString("F3");
            lbl_Y1.Text = CmdLine.Y[0].ToString("F3");

            lbl_CX.Text = CmdLine.X[1].ToString("F3");
            lbl_CY.Text = CmdLine.Y[2].ToString("F3");

            lbl_Angle.Text = CmdLine.DPara[5].ToString("f3");
            lbl_Count.Text = CmdLine.IPara[5].ToString();

            lbl_CurrCount.Text = (PointNo + 1).ToString() + " / " + CmdLine.IPara[5].ToString();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_Dot_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = CmdName;
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            UpdateDisplay();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };

        }
        private void frmDispProg_Dot_Shown(object sender, EventArgs e)
        {
        }

        private void frmDispProg_Dot_VisibleChanged(object sender, EventArgs e)
        {
        }
        private void btn_EditModel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
        }       

        private void lbl_HeadNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Head No", ref CmdLine.ID, 1, 3);
            UpdateDisplay();
        }
        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Model No", ref CmdLine.IPara[0], 0, 15);
            UpdateDisplay();
        }
        private void lbl_Mode_Click(object sender, EventArgs e)
        {
            EDotMode E = EDotMode.Cont;
            UC.AdjustExec(CmdName + ", Mode", ref CmdLine.IPara[1], E);
            if (CmdLine.IPara[1] > 1) CmdLine.IPara[1] = 1;
            UpdateDisplay();
        }
        private void lbl_Dispense_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[2] > 0) CmdLine.IPara[2] = 0; else CmdLine.IPara[2] = 1;
            UpdateDisplay();
        }

        private void lbl_X1_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.X[0], 3);
            UC.AdjustExec(CmdName + ", X1", ref X, -1000, 1000);
            CmdLine.X[0] = X;
            UpdateDisplay();
        }
        private void lbl_Y1_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[0], 3);
            UC.AdjustExec(CmdName + ", Y1", ref Y, -1000, 1000);
            CmdLine.Y[0] = Y;
            UpdateDisplay();
        }
        private void btn_SetPt1Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref X, ref Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            Log.OnSet(CmdName + ", Start XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            PointNo = 0;
        }

        private void lbl_CX_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.X[1], 3);
            UC.AdjustExec(CmdName + ", Center X", ref X, -1000, 1000);
            CmdLine.X[1] = X;
            UpdateDisplay();

        }
        private void lbl_CY_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[1], 3);
            UC.AdjustExec(CmdName + ", Center Y", ref Y, -1000, 1000);
            CmdLine.Y[1] = Y;
            UpdateDisplay();
        }
        private void btn_SetC_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref X, ref Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            CmdLine.X[1] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            Log.OnSet(CmdName + ", Center XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoC_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_Angle_Click(object sender, EventArgs e)
        {
            double d = Math.Round(CmdLine.DPara[5], 3);
            UC.AdjustExec(CmdName + ", Angle", ref d, -1000, 1000);
            CmdLine.DPara[5] = d;
            UpdateDisplay();
        }
        private void lbl_Count_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Count", ref CmdLine.IPara[5], 1, 99);
            UpdateDisplay();
        }

        int PointNo = 0;

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            int Points = CmdLine.IPara[5];
            double Angle = CmdLine.DPara[5]/180*Math.PI;//***unit = radian

            NSW.Net.Point2D p2D_Center = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            NSW.Net.Point2D p2D_Start = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);

            NSW.Net.Polar p_Point = new NSW.Net.Polar(p2D_Center, p2D_Start);

            double X_R = 0;
            double Y_R = 0;
            if (PointNo > 0)
            {
                PointNo--;
                p_Point.Rotate(PointNo * Angle);

                X_R = p_Point.DatumPoint2D.X;
                Y_R = p_Point.DatumPoint2D.Y;

                double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + X_R;
                double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + Y_R;
                DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

                if (!TaskDisp.TaskMoveGZUp()) return;

                if (!TaskGantry.SetMotionParamGXY()) return;
                if (!TaskGantry.MoveAbsGXY(X, Y)) return;
            }

            UpdateDisplay();
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            int Points = CmdLine.IPara[5];
            double Angle = CmdLine.DPara[5] / 180 * Math.PI;//***unit = radian

            NSW.Net.Point2D p2D_Center = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            NSW.Net.Point2D p2D_Start = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);

            NSW.Net.Polar p_Point = new NSW.Net.Polar(p2D_Center, p2D_Start);

            double X_R = 0;
            double Y_R = 0;
            if (PointNo < Points - 1)
            {
                PointNo++;
                p_Point.Rotate(PointNo * Angle);

                X_R = p_Point.DatumPoint2D.X;
                Y_R = p_Point.DatumPoint2D.Y;

                double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + X_R;
                double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + Y_R;
                DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

                if (!TaskDisp.TaskMoveGZUp()) return;

                if (!TaskGantry.SetMotionParamGXY()) return;
                if (!TaskGantry.MoveAbsGXY(X, Y)) return;
            }

            UpdateDisplay();
        }

        private void btn_Trig_Click(object sender, EventArgs e)
        {
            //if (!TaskDisp.TrigCheckReady((SelectedHead == 1), (SelectedHead == 2))) return;

            //bool DispA = false;
            //bool DispB = false;
            //try
            //{
            //    DispA = TaskGantry.DispAReady();
            //    DispB = TaskGantry.DispBReady();
            //}
            //catch { };

            bool DispA = true;
            bool DispB = (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double);

            if (!TaskDisp.CtrlCheckReady(DispA, DispB)) return;
            int t_Disp = GDefine.GetTickCount();

            if (!TaskDisp.TrigOn(DispA, DispB)) return;
            //if (!TaskDisp.HPCWaitNotReady(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitResponse(DispA, DispB)) return;
            if (!TaskDisp.TrigOff(DispA, DispB)) return;
            //if (!TaskDisp.CtrlWaitReady(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitComplete(DispA, DispB)) return;
            t_Disp = GDefine.GetTickCount() - t_Disp;
            lbl_TrigTime.Text = t_Disp.ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
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

        private void frm_DispCore_DispProg_DotAngArr_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }
    }
}
