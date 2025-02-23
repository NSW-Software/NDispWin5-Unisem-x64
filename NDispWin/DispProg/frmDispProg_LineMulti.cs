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
    internal partial class frm_DispCore_DispProg_LineMulti : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_LineMulti()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        int SelectLineNo = 0;
        private void UpdateDisplay()
        {
            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;
            lbl_HeadNo.Text = CmdLine.ID.ToString();
            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();

            lbl_LineCount.Text = CmdLine.IPara[5].ToString();
            lbl_LineNo.Text = (SelectLineNo).ToString();
            gbox_Pos.Text = "Line " + (SelectLineNo).ToString();

            lbl_X.Text = CmdLine.X[SelectLineNo].ToString("f3");
            lbl_Y.Text = CmdLine.Y[SelectLineNo].ToString("f3");
            if (SelectLineNo > 0)
            {
                double Len = Math.Sqrt(
                Math.Pow(CmdLine.X[SelectLineNo] - CmdLine.X[SelectLineNo - 1], 2) +
                Math.Pow(CmdLine.Y[SelectLineNo] - CmdLine.Y[SelectLineNo - 1], 2));
                lbl_Length.Text = Len.ToString("f3");
            }
            else
                lbl_Length.Text = "-";

            lbl_Disp.Text = CmdLine.U[SelectLineNo].ToString("f0");
            lbl_ModelNo.Text = CmdLine.Z[SelectLineNo].ToString();

            lbox_Pos.Items.Clear();
            lbox_Pos.Items.Add("No" + (char)9 + "X" + (char)9 + "Y" + (char)9 + "Model" + (char)9 + "Disp");
            for (int i = 0; i < CmdLine.IPara[5]; i++)
            {
                lbox_Pos.Items.Add((i).ToString() + (char)9 + CmdLine.X[i].ToString("f3") + (char)9 + CmdLine.Y[i].ToString("f3") + (char)9 + CmdLine.Z[i].ToString("f0") + (char)9 + CmdLine.U[i].ToString("f0"));
            }
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


            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
 
            UpdateDisplay();
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
            UC.AdjustExec(CmdName + ", HeadNo", ref CmdLine.ID, 1, 3);
            UpdateDisplay();
        }

        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            //UC.AdjustExec(CmdName + ", ModelNo", ref CmdLine.IPara[0], 0, 15);
            int i = (int)CmdLine.Z[SelectLineNo];
            UC.AdjustExec(CmdName + ", Line" + SelectLineNo.ToString() + ", ModelNo", ref i, 0, 15);
            CmdLine.Z[SelectLineNo] = (int)i;
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
            double X = Math.Round(CmdLine.X[SelectLineNo], 3);
            UC.AdjustExec(CmdName + ", X1", ref X, -1000, 1000);
            CmdLine.X[SelectLineNo] = X;
            UpdateDisplay();
        }

        private void lbl_Y1_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[SelectLineNo], 3);
            UC.AdjustExec(CmdName + ", Y1", ref Y, -1000, 1000);
            CmdLine.Y[SelectLineNo] = Y;
            UpdateDisplay();
        }
        private void btn_SetXY_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[SelectLineNo], CmdLine.Y[SelectLineNo]);
            CmdLine.X[SelectLineNo] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[SelectLineNo] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[SelectLineNo], CmdLine.Y[SelectLineNo]);
            Log.OnSet(CmdName + ", Line " + SelectLineNo.ToString() + " Position", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoXY_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[SelectLineNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[SelectLineNo];

            UpdateDisplay();

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_EditXY_Click(object sender, EventArgs e)
        {
            frm_DispCore_EditXY frm = new frm_DispCore_EditXY();

            frm.ParamName = "Line " + SelectLineNo.ToString() + " XY";
            frm.ValueX = CmdLine.X[SelectLineNo];
            frm.ValueY = CmdLine.Y[SelectLineNo];

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CmdLine.X[SelectLineNo] = frm.ValueX;
                CmdLine.Y[SelectLineNo] = frm.ValueY;
            }

            UpdateDisplay();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (SelectLineNo >= CmdLine.IPara[5] - 1) return;
            SelectLineNo++;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[SelectLineNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[SelectLineNo];

            UpdateDisplay();

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (SelectLineNo <= 0) return;
            SelectLineNo--;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[SelectLineNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[SelectLineNo];

            UpdateDisplay();

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_Disp_Click(object sender, EventArgs e)
        {
            int i = (int)CmdLine.U[SelectLineNo];
            if (UC.AdjustExec(CmdName + ", Line" + SelectLineNo.ToString() + " Disp", ref i, 0, 100))
                CmdLine.U[SelectLineNo] = (double)i;

            //CmdLine.IPara[6] = 0;
            //for (int d = 0; d < CmdLine.IPara[5]; d++)
            //{
            //    CmdLine.IPara[6] = CmdLine.IPara[6] + (int)CmdLine.U[d];
            //}

            UpdateDisplay();
        }

        private void frmDispProg_Dot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //do tab
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName); 
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName); 
            Close();
        }

        private void lbl_DotCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Line Count", ref CmdLine.IPara[5], 1, 100);

            if (SelectLineNo > CmdLine.IPara[5])
                SelectLineNo = CmdLine.IPara[5];
            
            UpdateDisplay();
        }

        private void lbl_DotNo_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[5] < 1) return;

            int i = SelectLineNo;
            UC.AdjustExec(CmdName + ", Line No", ref i, 1, CmdLine.IPara[5]);
            SelectLineNo = i;
            UpdateDisplay();
        }

        private void lbox_Pos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectLineNo = lbox_Pos.SelectedIndex - 1;
            lbox_Pos.Focus();

            if (SelectLineNo < 0) return;
            
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[SelectLineNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[SelectLineNo];

            UpdateDisplay();

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_Length_Click(object sender, EventArgs e)
        {
            if (SelectLineNo <= 0) return;

            NSW.Net.Point2D Pt_Start = new NSW.Net.Point2D(CmdLine.X[SelectLineNo - 1], CmdLine.Y[SelectLineNo - 1]);
            NSW.Net.Point2D Pt_End = new NSW.Net.Point2D(CmdLine.X[SelectLineNo], CmdLine.Y[SelectLineNo]);
            NSW.Net.Polar Polar = new NSW.Net.Polar(Pt_Start, Pt_End);

            double d = Math.Round(Polar.R,3);
            if (UC.AdjustExec(CmdName + ", Len " + SelectLineNo.ToString() + "", ref d, 0, 100))
                Polar.R = d;

            CmdLine.X[SelectLineNo] = Polar.DatumPoint2D.X;
            CmdLine.Y[SelectLineNo] = Polar.DatumPoint2D.Y;
            UpdateDisplay();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GDefine.CmdHelpFile);
        }
    }
}
