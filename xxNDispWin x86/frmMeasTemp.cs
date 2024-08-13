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
    internal partial class frmMeasTemp : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frmMeasTemp()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        int count = 0;
        List<PointF> positions = new List<PointF>();
        const int MAX_POINTS = 20;

        private void frmMeasTemp_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;//Settle Time

            count = CmdLine.IPara[1];
            for (int i = 0; i < count; i++)
            {
                positions.Add(new PointF((float)CmdLine.X[i], (float)CmdLine.Y[i]));
            }

            UpdateDisplay();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void UpdateDisplay()
        {
            lblMeasID.Text = CmdLine.ID.ToString();

            lbxPositions.Items.Clear();
            for (int i = 0; i < positions.Count; i++)
            {
                lbxPositions.Items.Add($"{positions[i].X:f3},{positions[i].Y:f3}");
            }
        }

        private void lblMeasID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Meas ID", ref CmdLine.ID, 0, DispProg.MAX_IDS - 1);
            UpdateDisplay();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = positions.Count;
            for (int i = 0; i < positions.Count; i++)
            {
                CmdLine.X[i] = positions[i].X;
                CmdLine.Y[i] = positions[i].Y;
            }

            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            Log.OnAction("OK", CmdName);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = positions.Count;
            for (int i = 0; i < positions.Count; i++)
            {
                CmdLine.X[i] = positions[i].X;
                CmdLine.Y[i] = positions[i].Y;
            }
            MeasTemp.Execute(CmdLine, DispProg.RunMode, DispProg.Origin(DispProg.rt_StationNo).X, DispProg.Origin(DispProg.rt_StationNo).Y, DispProg.Origin(DispProg.rt_StationNo).Z);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(0, 0);
            double x = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            double y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(x, y);
            positions.Add(new PointF((float)x, (float)y));

            Log.OnSet(CmdName + ", Add " + positions.Count + 1.ToString() + " XY", Old, New);
            UpdateDisplay();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            double xo = positions[lbxPositions.SelectedIndex].X;
            double yo = positions[lbxPositions.SelectedIndex].Y;

            NSW.Net.Point2D Old = new NSW.Net.Point2D(xo, yo);
            double x = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            double y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(x, y);
            positions[lbxPositions.SelectedIndex] = new PointF((float)x, (float)y);

            Log.OnSet(CmdName + ", Update " + lbxPositions.SelectedIndex.ToString() + " XY", Old, New);
            UpdateDisplay();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            positions.RemoveAt(lbxPositions.SelectedIndex);
            UpdateDisplay();
        }

        private void lbxPositions_MouseClick(object sender, MouseEventArgs e)
        {
            if (!cbGoto.Checked) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + positions[lbxPositions.SelectedIndex].X;
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + positions[lbxPositions.SelectedIndex].Y;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void frmMeasTemp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }
    }
}