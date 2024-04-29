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
    internal partial class frmDispProg_ExtVis : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frmDispProg_ExtVis()
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
            lbl_X.Text = CmdLine.X[0].ToString("F3");
            lbl_Y.Text = CmdLine.Y[0].ToString("F3");
            lbl_Z.Text = CmdLine.Z[0].ToString("F3");

            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_ExtVis_Load(object sender, EventArgs e)
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
        private void frmDispProg_ExtVis_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btn_Set_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref X, ref Y);

            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            Log.OnSet(CmdName + ", Set XY", Old, new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]));

            UpdateDisplay();
        }

        private void btn_Goto_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];
            double Z = CmdLine.Z[0];

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;

            TaskGantry.SetMotionParamGXY();
            if (!TaskGantry.MoveAbsGXY(X, Y, true)) return;

            if (!TaskGantry.SetMotionParamGZ()) return;
            if (!TaskGantry.MoveAbsGZ(Z, false)) return;
        }

        private void lbl_X_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.X[0], 3);
            UC.AdjustExec(CmdName + ", X", ref X, -1000, 1000);
            CmdLine.X[0] = X;
            UpdateDisplay();
        }

        private void lbl_Y_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[0], 3);
            UC.AdjustExec(CmdName + ", Y", ref Y, -1000, 1000);
            CmdLine.Y[0] = Y;
            UpdateDisplay();
        }

        private void lbl_Z_Click(object sender, EventArgs e)
        {
            double Z = Math.Round(CmdLine.Z[0], 3);
            UC.AdjustExec(CmdName + ", Z", ref Z, -1000, 1000);
            CmdLine.Z[0] = Z;
            UpdateDisplay();
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            bool OK = false;
            ExtVision.Send_Trig1(ref OK);
        }

        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Settle Time (ms)", ref CmdLine.IPara[4], 0, 5000);
            UpdateDisplay();
        }
    }
}
