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
    internal partial class frm_DispCore_DispProg_GoPos : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_GoPos()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            pnl_X2Y2Z2.Visible = GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2;
        }

        private void UpdateDisplay()
        {
            lbl_X.Text = CmdLine.X[0].ToString("F3");
            lbl_Y.Text = CmdLine.Y[0].ToString("F3");
            lbl_Z.Text = CmdLine.Z[0].ToString("F3");
            lbl_X2.Text = CmdLine.X[1].ToString("F3");
            lbl_Y2.Text = CmdLine.Y[1].ToString("F3");
            lbl_Z2.Text = CmdLine.Z[1].ToString("F3");
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_MoveLine_Load(object sender, EventArgs e)
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
        private void frmDispProg_MoveLine_Shown(object sender, EventArgs e)
        {
        }
        private void frmDispProg_MoveLine_VisibleChanged(object sender, EventArgs e)
        {
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

        private void lbl_X2_Click(object sender, EventArgs e)
        {
            double X2 = Math.Round(CmdLine.X[1], 3);
            UC.AdjustExec(CmdName + ", X2", ref X2, -1000, 1000);
            CmdLine.X[1] = X2;
            UpdateDisplay();
        }

        private void lbl_Y2_Click(object sender, EventArgs e)
        {
            double Y2 = Math.Round(CmdLine.Y[1], 3);
            UC.AdjustExec(CmdName + ", Y2", ref Y2, -1000, 1000);
            CmdLine.Y[1] = Y2;
            UpdateDisplay();
        }

        private void lbl_Z2_Click(object sender, EventArgs e)
        {
            double Z2 = Math.Round(CmdLine.Z[1], 3);
            UC.AdjustExec(CmdName + ", Z2", ref Z2, -1000, 1000);
            CmdLine.Z[1] = Z2;
            UpdateDisplay();
        }

        private void lbl_RX_Click(object sender, EventArgs e)
        {
            double RX = Math.Round(CmdLine.A[0], 3);
            UC.AdjustExec(CmdName + ", RX", ref RX, -25, 25);
            CmdLine.A[0] = RX;
            UpdateDisplay();
        }

        private void lbl_RY_Click(object sender, EventArgs e)
        {
            double RY = Math.Round(CmdLine.B[0], 3);
            UC.AdjustExec(CmdName + ", RY", ref RY, -25, 25);
            CmdLine.B[0] = RY;
            UpdateDisplay();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            CmdLine.X[0] = TaskGantry.GXPos();
            CmdLine.Y[0] = TaskGantry.GYPos();
            CmdLine.Z[0] = TaskGantry.GZPos();
            CmdLine.X[1] = TaskGantry.GX2Pos();
            CmdLine.Y[1] = TaskGantry.GY2Pos();
            CmdLine.Z[1] = TaskGantry.GZ2Pos();

            UpdateDisplay();
        }

        private void btn_Goto_Click(object sender, EventArgs e)
        {
            double X = CmdLine.X[0];
            double Y = CmdLine.Y[0];
            double Z = CmdLine.Z[0];
            double X2 = CmdLine.X[1];
            double Y2 = CmdLine.Y[1];
            double Z2 = CmdLine.Z[1];

            if (!TaskDisp.TaskGotoPos(X, Y, Z, X2, Y2, Z2)) return;
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

        private void frm_DispCore_DispProg_GoPos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
