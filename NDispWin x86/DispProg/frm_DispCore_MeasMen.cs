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
    internal partial class frm_DispCore_MeasMen : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_MeasMen()
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
            TConditions Cond = new TConditions(LineNo, CmdLine);
            lbox_Cond.Items.Clear();
            foreach (string s in Cond.Strings)
            {
                lbox_Cond.Items.Add(s);
            }

            lbl_MeasID.Text = CmdLine.ID.ToString();
            lbl_ModelNo.Text = CmdLine.IPara[0].ToString();

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");
            lbl_X2Y2.Text = CmdLine.X[1].ToString("F3") + ", " + CmdLine.Y[1].ToString("F3");
            lbl_X3Y3.Text = CmdLine.X[2].ToString("F3") + ", " + CmdLine.Y[2].ToString("F3");

            lbl_StartDelay.Text = CmdLine.IPara[3].ToString();
            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
            lblContError.Text = CmdLine.IPara[5].ToString();

            lbl_MeniscusSpec.Text = CmdLine.DPara[5].ToString("f3");
            lbl_MeniscusTol.Text = CmdLine.DPara[6].ToString("f3");
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frm_DispCore_MeasMen_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;//Settle Time

            UpdateDisplay();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
        }

        private void lbl_MeasID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Height ID", ref CmdLine.ID, 0, DispProg.MAX_IDS - 1);
            UpdateDisplay();
        }
        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", ModelNo", ref CmdLine.IPara[0], 0, 15);
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

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

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

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetPt3Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[2], CmdLine.Y[2]);
            CmdLine.X[2] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[2] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[2], CmdLine.Y[2]);
            Log.OnSet(CmdName + ", Measure XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt3Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[2];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[2];

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Settle Time (ms)", ref CmdLine.IPara[4], 0, 500);
            UpdateDisplay();
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            Enabled = false;

            NSW.Net.Stats Stats = new NSW.Net.Stats();
            string dp = "f4";

            try
            {
                lbox_Data.Items.Clear();

                TaskMeasMen.Data Data = new TaskMeasMen.Data();
                TaskMeasMen.MeasL_H_Profile Profile = new TaskMeasMen.MeasL_H_Profile();

                double X1 = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
                double Y1 = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];
                double X2 = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
                double Y2 = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];
                double X3 = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[2];
                double Y3 = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[2];
                TaskMeasMen.Execute(CmdLine, ref Profile, ref Data, X1, Y1, X2, Y2, X3, Y3);

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
            finally
            {
                Enabled = true;
            }
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

        private void btn_Cond_Click(object sender, EventArgs e)
        {
            frm_DispProg_Condition frm = new frm_DispProg_Condition();
            frm.CmdLine.Copy(CmdLine);
            frm.ShowDialog();
            CmdLine.Copy(frm.CmdLine);

            UpdateDisplay();
        }

        private void lbox_Cond_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_EditModel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
        }

        private void lbl_MeniscusSpec_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Meniscus Spec (mm)", ref CmdLine.DPara[5], -5, 5);
            UpdateDisplay();
        }

        private void lbl_MeniscusTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Meniscus Tol (mm)", ref CmdLine.DPara[6], 0, 1);
            UpdateDisplay();
        }

        private void lbl_StartDelay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Start Wait (ms)", ref CmdLine.IPara[3], 0, 30000);
            UpdateDisplay();
        }

        private void lbl_X3Y3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Set Meas XY to default (0, 0)?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                CmdLine.X[2] = 0;
                CmdLine.Y[2] = 0;
            }

            UpdateDisplay();
        }

        private void lblContError_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Cont Error (count)", ref CmdLine.IPara[5], 0, 1000);
            UpdateDisplay();
        }
    }
}
