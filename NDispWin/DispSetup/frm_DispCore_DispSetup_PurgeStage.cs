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
    public partial class frm_DispProg_PurgeStage : Form
    {
        string ParamPrefix = "PurgeStage";

        public frm_DispProg_PurgeStage()
        {
            InitializeComponent();
            GControl.LogForm(this);

            cbxPType.DataSource = Enum.GetValues(typeof(FuncPurgeStage.EPattern));
            cbxPType.SelectedIndex = (int)TaskDisp.PurgeStage.Pattern;
        }

        private void frm_DispProg_PurgeStage_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = ParamPrefix + " Setup";

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_ModelNo.Text = TaskDisp.PurgeStage.ModelNo.ToString();

            lblPSizeX.Text = TaskDisp.PurgeStage.PatternSize.X.ToString("f3");
            lblPSizeY.Text = TaskDisp.PurgeStage.PatternSize.Y.ToString("f3");

            lbl_StartX.Text = TaskDisp.PurgeStage.StartXY.X.ToString("f3");
            lbl_StartY.Text = TaskDisp.PurgeStage.StartXY.Y.ToString("f3");
            lbl_EndX.Text = TaskDisp.PurgeStage.EndXY.X.ToString("f3");
            lbl_EndY.Text = TaskDisp.PurgeStage.EndXY.Y.ToString("f3");

            lbl_SizeX.Text = Math.Abs(TaskDisp.PurgeStage.EndXY.X - TaskDisp.PurgeStage.StartXY.X).ToString("f3");
            lbl_SizeY.Text = Math.Abs(TaskDisp.PurgeStage.EndXY.Y - TaskDisp.PurgeStage.StartXY.Y).ToString("f3");

            lbl_PitchX.Text = TaskDisp.PurgeStage.PitchXY.X.ToString("f3");
            lbl_PitchY.Text = TaskDisp.PurgeStage.PitchXY.Y.ToString("f3");
            lbl_TotalCol.Text = TaskDisp.PurgeStage.CRCount.X.ToString();
            lbl_TotalRow.Text = TaskDisp.PurgeStage.CRCount.Y.ToString();
            lbl_LastCR_X.Text = (TaskDisp.PurgeStage.LastCR.X + 1).ToString();
            lbl_LastCR_Y.Text = (TaskDisp.PurgeStage.LastCR.Y + 1).ToString();

            lbl_UsedCount.Text = TaskDisp.PurgeStage.UsedCount.ToString();
            lbl_RemainCount.Text = TaskDisp.PurgeStage.RemainCount.ToString();

            lbl_PromptCleanCycles.Text = TaskDisp.PurgeStage.PromptCleanCycles.ToString();
            lbl_StageHeightOffset.Text = TaskDisp.PurgeStage.StageHeightOffset.ToString();

            lbl_TestPurgeCount.Text = TestPurgeCount.ToString();
        }

        private void lbl_X1_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", X1", ref TaskDisp.PurgeStage.StartXY.X, -1000, 1000);
            UpdateDisplay();
        }
        private void lbl_Y1_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Y1", ref TaskDisp.PurgeStage.StartXY.Y, -1000, 1000);
            UpdateDisplay();
        }
    
        private void lbl_PitchX_Click(object sender, EventArgs e)
        {
            double Width = Math.Abs(TaskDisp.PurgeStage.EndXY.X - TaskDisp.PurgeStage.StartXY.X);

            UC.AdjustExec(ParamPrefix + ", PitchX", ref TaskDisp.PurgeStage.PitchXY.X, -10, 10);

            int NewCRCountX = (int)Math.Floor(Width / TaskDisp.PurgeStage.PitchXY.X);

            if (NewCRCountX < TaskDisp.PurgeStage.CRCount.X)
                TaskDisp.PurgeStage.CRCount.X = NewCRCountX;

            UpdateDisplay();
        }
        private void lbl_PitchY_Click(object sender, EventArgs e)
        {
            double Height = Math.Abs(TaskDisp.PurgeStage.EndXY.Y - TaskDisp.PurgeStage.StartXY.Y);

            UC.AdjustExec(ParamPrefix + ", PitchY", ref TaskDisp.PurgeStage.PitchXY.Y, -10, 10);
            
            int NewCRCountY = (int)Math.Floor(Width / TaskDisp.PurgeStage.PitchXY.Y);

            if (NewCRCountY < TaskDisp.PurgeStage.CRCount.Y)
                TaskDisp.PurgeStage.CRCount.Y = NewCRCountY;

            UpdateDisplay();
        }
        private void lbl_CRCountX_Click(object sender, EventArgs e)
        {
            TPos3 EndXY = TaskDisp.PurgeStage.EndXY;

            int i = TaskDisp.PurgeStage.CRCount.X;
            UC.AdjustExec(ParamPrefix + ", ColCount", ref i, 1, 1000);
            TaskDisp.PurgeStage.CRCount.X = i;

            TaskDisp.PurgeStage.PitchXY.X = Math.Round((EndXY.X - TaskDisp.PurgeStage.StartXY.X) / (TaskDisp.PurgeStage.CRCount.X - 1), 3);
            
            UpdateDisplay();
        }
        private void lbl_CRCountR_Click(object sender, EventArgs e)
        {
            TPos3 EndXY = TaskDisp.PurgeStage.EndXY;

            int i = TaskDisp.PurgeStage.CRCount.Y;
            UC.AdjustExec(ParamPrefix + ", RowCount", ref i, 1, 1000);
            TaskDisp.PurgeStage.CRCount.Y = i;

            TaskDisp.PurgeStage.PitchXY.Y = Math.Round((EndXY.Y - TaskDisp.PurgeStage.StartXY.Y) / (TaskDisp.PurgeStage.CRCount.Y - 1), 3);
 
            UpdateDisplay();
        }

        private void btn_StartXY_Click(object sender, EventArgs e)
        {
            double X = TaskDisp.PurgeStage.StartXY.X;
            double Y = TaskDisp.PurgeStage.StartXY.Y;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_SetStartXY_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(TaskDisp.PurgeStage.StartXY.X, TaskDisp.PurgeStage.StartXY.Y);

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            TaskDisp.PurgeStage.StartXY = new TPos3(X, Y, 0);

            NSW.Net.Point2D New = new NSW.Net.Point2D(TaskDisp.WipeStage.StartXY.X, TaskDisp.WipeStage.StartXY.Y);
            Log.OnAction("Set", ParamPrefix + ", StartXY", Old, New);

            UpdateDisplay();
        }

        private void btn_EndXY_Click(object sender, EventArgs e)
        {
            double X = TaskDisp.PurgeStage.EndXY.X;
            double Y = TaskDisp.PurgeStage.EndXY.Y;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_SetEndXY_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(TaskDisp.WipeStage.EndXY.X, TaskDisp.WipeStage.EndXY.Y);

            TaskDisp.PurgeStage.EndXY = new TPos3(TaskGantry.GXPos(), TaskGantry.GYPos(), TaskGantry.GZPos());

            NSW.Net.Point2D New = new NSW.Net.Point2D(TaskDisp.WipeStage.EndXY.X, TaskDisp.WipeStage.EndXY.Y);
            Log.OnAction("Set", ParamPrefix + ", EndXY", Old, New);

            UpdateDisplay();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            TaskDisp.PurgeStage.Reset();
            UpdateDisplay();
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            DispProg.RunMode = ERunMode.Normal;
            //TaskDisp.PurgeStage.Execute(DispProg.PurgeStage.Count);
            TaskDisp.PurgeStage.Execute(TestPurgeCount);

            UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                TaskDisp.TaskMoveGZZ2Up();
            }
            catch { };
            Close();
        }

        private void lbl_CleanCycles_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", PromptCleanCycles", ref TaskDisp.PurgeStage.PromptCleanCycles, 0, 100);
            UpdateDisplay();
        }

        private void btn_Jog_Click(object sender, EventArgs e)
        {
            frmJogGantry frm_Jog2 = new frmJogGantry();
            frm_Jog2.TopMost = true;
            frm_Jog2.Show();
        }

        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", ModelNo", ref TaskDisp.PurgeStage.ModelNo, 0, TModelList.MAX_MODEL);
            UpdateDisplay();
        }

        private void btn_EditModel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
        }

        private void lbl_StageZOffset_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Stage Height Offset", ref TaskDisp.PurgeStage.StageHeightOffset, -5, 15);
            UpdateDisplay();
        }

        int TestPurgeCount = 3;
        private void lbl_PurgeCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Test Purge Count", ref TestPurgeCount, 1, 100);
            UpdateDisplay();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cbxPType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TaskDisp.PurgeStage.Pattern = (FuncPurgeStage.EPattern)(sender as ComboBox).SelectedIndex;
            UpdateDisplay();
        }

        private void lblPSizeX_Click(object sender, EventArgs e)
        {
            double d = TaskDisp.PurgeStage.PatternSize.X;
            UC.AdjustExec(ParamPrefix + ", Pattern Size X", ref d, 0, 20);
            TaskDisp.PurgeStage.PatternSize.X = d;
            UpdateDisplay();
        }

        private void lblPSizeY_Click(object sender, EventArgs e)
        {
            double d = TaskDisp.PurgeStage.PatternSize.Y;
            UC.AdjustExec(ParamPrefix + ", Pattern Size Y", ref d, 0, 20);
            TaskDisp.PurgeStage.PatternSize.Y = d;
            UpdateDisplay();
        }
    }
}
