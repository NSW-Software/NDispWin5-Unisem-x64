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
    public partial class frm_DispProg_PurgeStage : Form
    {
        string ParamPrefix = "PurgeStage";

        public frm_DispProg_PurgeStage()
        {
            InitializeComponent();
        }

        private void frm_DispProg_PurgeStage_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_ModelNo.Text = TaskDisp.PurgeStage.ModelNo.ToString();

            lbl_StartX.Text = TaskDisp.PurgeStage.StartXY.X.ToString("f3");
            lbl_StartY.Text = TaskDisp.PurgeStage.StartXY.Y.ToString("f3");
            lbl_EndX.Text = TaskDisp.PurgeStage.EndXY.X.ToString("f3");
            lbl_EndY.Text = TaskDisp.PurgeStage.EndXY.Y.ToString("f3");
            lbl_PitchX.Text = TaskDisp.PurgeStage.PitchXY.X.ToString("f3");
            lbl_PitchY.Text = TaskDisp.PurgeStage.PitchXY.Y.ToString("f3");
            lbl_TotalCol.Text = TaskDisp.PurgeStage.CRCount.X.ToString();
            lbl_TotalRow.Text = TaskDisp.PurgeStage.CRCount.Y.ToString();
            lbl_LastCR_X.Text = (TaskDisp.PurgeStage.LastCR.X + 1).ToString();
            lbl_LastCR_Y.Text = (TaskDisp.PurgeStage.LastCR.Y + 1).ToString();

            lbl_UsedCount.Text = TaskDisp.PurgeStage.UsedCount.ToString();
            lbl_RemainCount.Text = TaskDisp.PurgeStage.RemainCount.ToString();

            lbl_PurgeCount.Text = TaskDisp.PurgeStage.PurgeCount.ToString();
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
        //private void lbl_X2_Click(object sender, EventArgs e)
        //{
        //    double EndX = TaskDisp.PurgeStage.EndXY.X;
        //    UC.AdjustExec(ParamPrefix + ", X2", ref EndX, -1000, 1000);


        //    UpdateDisplay();
        //}
        //private void lbl_Y2_Click(object sender, EventArgs e)
        //{
        //    UC.AdjustExec(ParamPrefix + ", Y2", ref TaskDisp.PurgeStage.EndXY.Y, -1000, 1000);
        //    UpdateDisplay();
        //}
        private void lbl_PitchX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", PitchX", ref TaskDisp.PurgeStage.PitchXY.X, -10, 10);
            UpdateDisplay();
        }
        private void lbl_PitchY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", PitchY", ref TaskDisp.PurgeStage.PitchXY.Y, -10, 10);
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
            double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();

            TaskDisp.PurgeStage.StartXY = new TPos3(X, Y, 0);
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
            TaskDisp.PurgeStage.EndXY = new TPos3(TaskGantry.GXPos(), TaskGantry.GYPos(), TaskGantry.GZPos());
            UpdateDisplay();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            TaskDisp.PurgeStage.LastCR = new Point(-1, 0);
            UpdateDisplay();
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            DispProg.RunMode = ERunMode.Normal;
            TaskDisp.PurgeStage.Execute();

            UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbl_PurgeCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", PurgeCount", ref TaskDisp.PurgeStage.PurgeCount, 0, 100);
            UpdateDisplay();
        }

        private void btn_Jog_Click(object sender, EventArgs e)
        {
            frm_DispCore_JogGantry2 frm_Jog2 = new frm_DispCore_JogGantry2();
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


    }
}
