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
    internal partial class frm_DispCore_DispProg_Repeat : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_Repeat()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void UpdateDisplay()
        {
            lbl_StartX.Text = CmdLine.DPara[0].ToString("f3");
            lbl_StartY.Text = CmdLine.DPara[1].ToString("f3");

            lbl_UColCount.Text = CmdLine.Index[2].ToString("f0");
            lbl_URowCount.Text = CmdLine.Index[4].ToString("f0");

            lbl_UColPX.Text = CmdLine.DPara[2].ToString("f3");
            lbl_UColPY.Text = CmdLine.DPara[3].ToString("f3");
            lbl_URowPX.Text = CmdLine.DPara[4].ToString("f3");
            lbl_URowPY.Text = CmdLine.DPara[5].ToString("f3");

            string s = "Invalid";
            try { s = ((TLayout.ELoopDir)CmdLine.IPara[1]).ToString(); } catch { };
            lbl_LoopDir.Text = s;

            lbl_CR.Text = CR.X.ToString() + "," + CR.Y.ToString();

            lbl_CurrCol.Text = DispProg.rt_RepeatCR.X.ToString();
            lbl_CurrRow.Text = DispProg.rt_RepeatCR.Y.ToString();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_Repeat_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            UpdateDisplay();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
        }

        private void frmDispProg_Repeat_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
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

        private void lbl_StartX_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", StartX", ref CmdLine.DPara[0], -500, 500)) return;
            UpdateDisplay();
        }

        private void lbl_StartY_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", StartY", ref CmdLine.DPara[1], -500, 500)) return;
            UpdateDisplay();
        }

        private void lbl_UColCount_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", Col Count", ref CmdLine.Index[2], 1, 100)) return;
            UpdateDisplay();
        }

        private void lbl_URowCount_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", Row Count", ref CmdLine.Index[4], 1, 100)) return;
            UpdateDisplay();
        }

        private void lbl_UColPX_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", Col PitchX", ref CmdLine.DPara[2], -10, 10)) return;
            UpdateDisplay();
        }

        private void lbl_UColPY_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", Col PitchY", ref CmdLine.DPara[3], -10, 10)) return;
            UpdateDisplay();
        }

        private void lbl_URowPX_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", Row PitchX", ref CmdLine.DPara[4], -10, 10)) return;
            UpdateDisplay();
        }

        private void lbl_URowPY_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", Row PitchY", ref CmdLine.DPara[5], -10, 10)) return;
            UpdateDisplay();
        }

        private void lbl_CurrCol_Click(object sender, EventArgs e)
        {
            int i = DispProg.rt_RepeatCR.X;
            if (!UC.AdjustExec(CmdName + ", Current Col", ref i, 0, CmdLine.Index[2])) return;
            DispProg.rt_RepeatCR.X = i;
            UpdateDisplay();
        }

        private void lbl_CurrRow_Click(object sender, EventArgs e)
        {
            int i = DispProg.rt_RepeatCR.Y;
            if (!UC.AdjustExec(CmdName + ", Current Row", ref i, 0, CmdLine.Index[4])) return;
            DispProg.rt_RepeatCR.Y = i;
            UpdateDisplay();
        }

        private void btn_SetStart_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[0], CmdLine.DPara[1]);
            CmdLine.DPara[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.DPara[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[0], CmdLine.DPara[1]);
            Log.OnSet(CmdName + ", Start XY", Old, New);

            UpdateDisplay();
        }

        private void btn_GotoStart_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetUColPitch_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            double LX = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            double LY = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[2], CmdLine.DPara[3]);
            CmdLine.DPara[2] = (LX - CmdLine.DPara[0]) / (CmdLine.Index[2] - 1);
            CmdLine.DPara[3] = (LY - CmdLine.DPara[1]) / (CmdLine.Index[2] - 1);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[2], CmdLine.DPara[3]);
            Log.OnSet(CmdName + ", ColPitch XY", Old, New);

            UpdateDisplay();
        }

        private void btn_GotoUColPitch_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];

            X = X + (CmdLine.DPara[2] * (CmdLine.Index[2] - 1));
            Y = Y + (CmdLine.DPara[3] * (CmdLine.Index[2] - 1));

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetURowPitch_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            double LX = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            double LY = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[4], CmdLine.DPara[5]);
            CmdLine.DPara[4] = (LX - CmdLine.DPara[0]) / (CmdLine.Index[4] - 1);
            CmdLine.DPara[5] = (LY - CmdLine.DPara[1]) / (CmdLine.Index[4] - 1);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[4], CmdLine.DPara[5]);
            Log.OnSet(CmdName + ", RowPitch XY", Old, New);

            UpdateDisplay();
        }

        private void btn_GotoURowPitch_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];

            X = X + (CmdLine.DPara[4] * (CmdLine.Index[4] - 1));
            Y = Y + (CmdLine.DPara[5] * (CmdLine.Index[4] - 1));

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        Point CR = new Point(0, 0);
        private void btn_First_Click(object sender, EventArgs e)
        {
            CR = new Point(0, 0);

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];

            if (!TaskDisp.TaskMoveGZUp()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            UpdateDisplay();
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            CR.X = CmdLine.Index[2] - 1;
            CR.Y = CmdLine.Index[4] - 1;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
            X = X + (CmdLine.DPara[2] * CR.X) + (CmdLine.DPara[4] * CR.Y);
            Y = Y + (CmdLine.DPara[3] * CR.X) + (CmdLine.DPara[5] * CR.Y);

            if (!TaskDisp.TaskMoveGZUp()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            UpdateDisplay();
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            int CCount = CmdLine.Index[2];
            int RCount = CmdLine.Index[4];

            if (CR.X <= 0)
            {
                if (CR.Y <= 0)//end of repeat
                {
                    CR = new Point(0, 0);
                }
                else
                {
                    CR.X = CCount - 1;
                    CR.Y--;
                }
            }
            else
                CR.X--;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
            X = X + (CmdLine.DPara[2] * CR.X) + (CmdLine.DPara[4] * CR.Y);
            Y = Y + (CmdLine.DPara[3] * CR.X) + (CmdLine.DPara[5] * CR.Y);

            if (!TaskDisp.TaskMoveGZUp()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            UpdateDisplay();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            int CCount = CmdLine.Index[2];
            int RCount = CmdLine.Index[4];

            if (CR.X >= CCount - 1)
            {
                if (CR.Y >= RCount - 1)//end of repeat
                {
                    CR = new Point(CCount - 1, RCount - 1);
                }
                else
                {
                    CR.X = 0;
                    CR.Y++;
                }
            }
            else
                CR.X++;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
            X = X + (CmdLine.DPara[2] * CR.X) + (CmdLine.DPara[4] * CR.Y);
            Y = Y + (CmdLine.DPara[3] * CR.X) + (CmdLine.DPara[5] * CR.Y);

            if (!TaskDisp.TaskMoveGZUp()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            UpdateDisplay();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Msg MsgBox = new Msg();
            EMsgRes MsgRes = MsgBox.Show("Update Index to Program", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);

            if (MsgRes == EMsgRes.smrOK)
            {
                DispProg.rt_RepeatCR = CR;
            }

            UpdateDisplay();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbl_LoopDir_Click(object sender, EventArgs e)
        {
            if (!UC.AdjustExec(CmdName + ", LoopDir", ref CmdLine.IPara[1], TLayout.ELoopDir.XFU)) return;
            UpdateDisplay();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
