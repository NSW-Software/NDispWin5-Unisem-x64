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
    public partial class frm_DispProg_WipeStage : Form
    {
        string ParamPrefix = "WipeStage";

        public frm_DispProg_WipeStage()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void btn_Jog_Click(object sender, EventArgs e)
        {
            frm_DispCore_JogGantry2 frm_Jog2 = new frm_DispCore_JogGantry2();
            frm_Jog2.TopMost = true;
            frm_Jog2.Show();

            this.Left = 10;
            this.Top = 25;
            frm_Jog2.Left = this.Right;
            frm_Jog2.Top = this.Top;

        }

        private void frm_DispProg_WipeStage_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = ParamPrefix + " Setup";

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_StartX.Text = TaskDisp.WipeStage.StartXY.X.ToString("f3");
            lbl_StartY.Text = TaskDisp.WipeStage.StartXY.Y.ToString("f3");

            lbl_TotalCol.Text = TaskDisp.WipeStage.OfstCount.X.ToString();
            lbl_TotalRow.Text = TaskDisp.WipeStage.OfstCount.Y.ToString();
            lbl_PitchX.Text = TaskDisp.WipeStage.OfstPitch.X.ToString("f3");
            lbl_PitchY.Text = TaskDisp.WipeStage.OfstPitch.Y.ToString("f3");

            lbl_LastCR_X.Text = (TaskDisp.WipeStage.LastCR.X + 1).ToString();
            lbl_LastCR_Y.Text = (TaskDisp.WipeStage.LastCR.Y + 1).ToString();
            lbl_UsedCount.Text = TaskDisp.WipeStage.UsedCount.ToString();
            lbl_RemainCount.Text = TaskDisp.WipeStage.RemainCount.ToString();

            lbl_Pos1X.Text = TaskDisp.WipeStage.Path[0].X.ToString("f3");
            lbl_Pos1Y.Text = TaskDisp.WipeStage.Path[0].Y.ToString("f3");
            lbl_Pos1Z.Text = TaskDisp.WipeStage.Path[0].Z.ToString("f3");
            lbl_Pos2X.Text = TaskDisp.WipeStage.Path[1].X.ToString("f3");
            lbl_Pos2Y.Text = TaskDisp.WipeStage.Path[1].Y.ToString("f3");
            lbl_Pos2Z.Text = TaskDisp.WipeStage.Path[1].Z.ToString("f3");
            lbl_Pos3X.Text = TaskDisp.WipeStage.Path[2].X.ToString("f3");
            lbl_Pos3Y.Text = TaskDisp.WipeStage.Path[2].Y.ToString("f3");
            lbl_Pos3Z.Text = TaskDisp.WipeStage.Path[2].Z.ToString("f3");
            lbl_Pos4X.Text = TaskDisp.WipeStage.Path[3].X.ToString("f3");
            lbl_Pos4Y.Text = TaskDisp.WipeStage.Path[3].Y.ToString("f3");
            lbl_Pos4Z.Text = TaskDisp.WipeStage.Path[3].Z.ToString("f3");
            lbl_Pos5X.Text = TaskDisp.WipeStage.Path[4].X.ToString("f3");
            lbl_Pos5Y.Text = TaskDisp.WipeStage.Path[4].Y.ToString("f3");
            lbl_Pos5Z.Text = TaskDisp.WipeStage.Path[4].Z.ToString("f3");

            lbl_StageHeightOffset.Text = TaskDisp.WipeStage.WipeHeightOffset.ToString();
            lbl_WipeGap.Text = TaskDisp.WipeStage.WipeGap.ToString();
            lbl_WipeSpeed.Text = TaskDisp.WipeStage.WipeSpeed.ToString();
            lbl_PromptCleanCycles.Text = TaskDisp.WipeStage.PromptCleanCycles.ToString();
            lbl_UseTapeIndexer.Text = TaskDisp.WipeStage.UseTapeIndexer.ToString();
            lbl_RepeatWipe.Text = TaskDisp.WipeStage.RepeatWipe.ToString();
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

        private void btn_StartXY_Click(object sender, EventArgs e)
        {
            double X = TaskDisp.WipeStage.StartXY.X;
            double Y = TaskDisp.WipeStage.StartXY.Y;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void lbl_StartX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", StartX", ref TaskDisp.WipeStage.StartXY.X, -1000, 1000);
            UpdateDisplay();
        }
        private void lbl_StartY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", StartY", ref TaskDisp.WipeStage.StartXY.Y, -1000, 1000);
            UpdateDisplay();
        }
        private void lbl_StartZ_Click(object sender, EventArgs e)
        {

        }
        private void btn_SetStartXY_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(TaskDisp.WipeStage.StartXY.X, TaskDisp.WipeStage.StartXY.Y);
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            TaskDisp.WipeStage.StartXY = new TPos3(X, Y, 0);

            NSW.Net.Point2D New = new NSW.Net.Point2D(TaskDisp.WipeStage.StartXY.X, TaskDisp.WipeStage.StartXY.Y);
            Log.OnAction("Set", ParamPrefix + ", StartXY", Old, New);

            UpdateDisplay();
        }

        private void lbl_TotalCol_Click(object sender, EventArgs e)
        {
            //TPos3 EndXY = TaskDisp.WipeStage.EndXY;

            int i = TaskDisp.WipeStage.OfstCount.X;
            UC.AdjustExec(ParamPrefix + ", OfstCount", ref i, 1, 1000);
            TaskDisp.WipeStage.OfstCount.X = i;

            //TaskDisp.WipeStage.OfstPitch.X = Math.Round((EndXY.X - TaskDisp.WipeStage.StartXY.X) / (TaskDisp.WipeStage.OfstCount.X - 1), 3);

            UpdateDisplay();
        }
        private void lbl_TotalRow_Click(object sender, EventArgs e)
        {
            //TPos3 EndXY = TaskDisp.WipeStage.EndXY;

            int i = TaskDisp.WipeStage.OfstCount.Y;
            UC.AdjustExec(ParamPrefix + ", OsftCount", ref i, 1, 1000);
            TaskDisp.WipeStage.OfstCount.Y = i;

            //TaskDisp.WipeStage.OfstPitch.Y = Math.Round((EndXY.Y - TaskDisp.WipeStage.StartXY.Y) / (TaskDisp.WipeStage.OfstCount.Y - 1), 3);

            UpdateDisplay();
        }

        private void lbl_PitchX_Click(object sender, EventArgs e)
        {
            //double Width = Math.Abs(TaskDisp.WipeStage.EndXY.X - TaskDisp.WipeStage.StartXY.X);

            UC.AdjustExec(ParamPrefix + ", OfstPitch", ref TaskDisp.WipeStage.OfstPitch.X, -10, 10);

            //int NewOfstCountX = (int)Math.Floor(Width / TaskDisp.WipeStage.OfstPitch.X);

            //if (NewOfstCountX < TaskDisp.WipeStage.OfstCount.X)
            //    TaskDisp.WipeStage.OfstCount.X = NewOfstCountX;

            UpdateDisplay();
        }
        private void lbl_PitchY_Click(object sender, EventArgs e)
        {
            //double Height = Math.Abs(TaskDisp.WipeStage.EndXY.Y - TaskDisp.WipeStage.StartXY.Y);

            UC.AdjustExec(ParamPrefix + ", OfstPitch", ref TaskDisp.WipeStage.OfstPitch.Y, -10, 10);

            //int NewOfstCountY = (int)Math.Floor(Width / TaskDisp.WipeStage.OfstPitch.Y);

            //if (NewOfstCountY < TaskDisp.WipeStage.OfstCount.Y)
            //    TaskDisp.WipeStage.OfstCount.Y = NewOfstCountY;

            UpdateDisplay();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            TaskDisp.WipeStage.Reset();
            UpdateDisplay();
        }

        private void btn_Pos1XY_Click(object sender, EventArgs e)
        {
            double X = TaskDisp.WipeStage.StartXY.X + TaskDisp.WipeStage.Path[0].X;
            double Y = TaskDisp.WipeStage.StartXY.Y + TaskDisp.WipeStage.Path[0].Y;
            double Z = TaskDisp.Head_ZSensor_RefPosZ[0] + TaskDisp.WipeStage.WipeHeightOffset + TaskDisp.WipeStage.WipeGap;
            Z = Z + TaskDisp.WipeStage.Path[0].Z;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y, true)) return;
            if (!TaskGantry.MoveAbsGZ(Z, true)) return;
        }
        private void btn_Pos2XY_Click(object sender, EventArgs e)
        {
            double X = TaskDisp.WipeStage.StartXY.X + TaskDisp.WipeStage.Path[1].X + TaskDisp.WipeStage.Path[0].X;
            double Y = TaskDisp.WipeStage.StartXY.Y + TaskDisp.WipeStage.Path[1].Y + TaskDisp.WipeStage.Path[0].Y;
            double Z = TaskDisp.Head_ZSensor_RefPosZ[0] + TaskDisp.WipeStage.WipeHeightOffset + TaskDisp.WipeStage.WipeGap;
            Z = Z + TaskDisp.WipeStage.Path[1].Z;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y, true)) return;
            if (!TaskGantry.MoveAbsGZ(Z, true)) return;
        }
        private void btn_Pos3XY_Click(object sender, EventArgs e)
        {
            double X = TaskDisp.WipeStage.StartXY.X + TaskDisp.WipeStage.Path[2].X + TaskDisp.WipeStage.Path[1].X + TaskDisp.WipeStage.Path[0].X;
            double Y = TaskDisp.WipeStage.StartXY.Y + TaskDisp.WipeStage.Path[2].Y + TaskDisp.WipeStage.Path[1].Y + TaskDisp.WipeStage.Path[0].Y;
            double Z = TaskDisp.Head_ZSensor_RefPosZ[0] + TaskDisp.WipeStage.WipeHeightOffset + TaskDisp.WipeStage.WipeGap;
            Z = Z + TaskDisp.WipeStage.Path[2].Z;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y, true)) return;
            if (!TaskGantry.MoveAbsGZ(Z, true)) return;
        }
        private void btn_Pos4XY_Click(object sender, EventArgs e)
        {
            double X = TaskDisp.WipeStage.StartXY.X + TaskDisp.WipeStage.Path[3].X + TaskDisp.WipeStage.Path[2].X + TaskDisp.WipeStage.Path[1].X + TaskDisp.WipeStage.Path[0].X;
            double Y = TaskDisp.WipeStage.StartXY.Y + TaskDisp.WipeStage.Path[3].Y + TaskDisp.WipeStage.Path[2].Y + TaskDisp.WipeStage.Path[1].Y + TaskDisp.WipeStage.Path[0].Y;
            double Z = TaskDisp.Head_ZSensor_RefPosZ[0] + TaskDisp.WipeStage.WipeHeightOffset + TaskDisp.WipeStage.WipeGap;
            Z = Z + TaskDisp.WipeStage.Path[3].Z;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y, true)) return;
            if (!TaskGantry.MoveAbsGZ(Z, true)) return;
        }
        private void btn_Pos5XY_Click(object sender, EventArgs e)
        {
            double X = TaskDisp.WipeStage.StartXY.X + TaskDisp.WipeStage.Path[4].X + TaskDisp.WipeStage.Path[3].X + TaskDisp.WipeStage.Path[2].X + TaskDisp.WipeStage.Path[1].X + TaskDisp.WipeStage.Path[0].X;
            double Y = TaskDisp.WipeStage.StartXY.Y + TaskDisp.WipeStage.Path[4].Y + TaskDisp.WipeStage.Path[3].Y + TaskDisp.WipeStage.Path[2].Y + TaskDisp.WipeStage.Path[1].Y + TaskDisp.WipeStage.Path[0].Y;
            double Z = TaskDisp.Head_ZSensor_RefPosZ[0] + TaskDisp.WipeStage.WipeHeightOffset + TaskDisp.WipeStage.WipeGap;
            Z = Z + TaskDisp.WipeStage.Path[4].Z;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y, true)) return;
            if (!TaskGantry.MoveAbsGZ(Z, true)) return;
        }


        private void lbl_Pos1X_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path0.X", ref TaskDisp.WipeStage.Path[0].X, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos1Y_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path0.Y", ref TaskDisp.WipeStage.Path[0].Y, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos1Z_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path0.Z", ref TaskDisp.WipeStage.Path[0].Z, -3, 3);
            UpdateDisplay();
        }
        private void lbl_Pos2X_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path1.X", ref TaskDisp.WipeStage.Path[1].X, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos2Y_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path1.Y", ref TaskDisp.WipeStage.Path[1].Y, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos2Z_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path1.Z", ref TaskDisp.WipeStage.Path[1].Z, -3, 3);
            UpdateDisplay();
        }
        private void lbl_Pos3X_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path2.X", ref TaskDisp.WipeStage.Path[2].X, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos3Y_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path2.Y", ref TaskDisp.WipeStage.Path[2].Y, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos3Z_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path2.Z", ref TaskDisp.WipeStage.Path[2].Z, -3, 3);
            UpdateDisplay();
        }
        private void lbl_Pos4X_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path3.X", ref TaskDisp.WipeStage.Path[3].X, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos4Y_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path3.Y", ref TaskDisp.WipeStage.Path[3].Y, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos4Z_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path3.Z", ref TaskDisp.WipeStage.Path[3].Z, -3, 3);
            UpdateDisplay();
        }
        private void lbl_Pos5X_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path4.X", ref TaskDisp.WipeStage.Path[4].X, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos5Y_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path4.Y", ref TaskDisp.WipeStage.Path[4].Y, -50, 50);
            UpdateDisplay();
        }
        private void lbl_Pos5Z_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Path4.Z", ref TaskDisp.WipeStage.Path[4].Z, -3, 3);
            UpdateDisplay();
        }

        private void btn_SetXY1_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[0].X, TaskDisp.WipeStage.Path[0].Y);

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            X = X-TaskDisp.WipeStage.StartXY.X;
            Y = Y-TaskDisp.WipeStage.StartXY.Y;
            TaskDisp.WipeStage.Path[0] = new TPos3(X, Y, 0);

            NSW.Net.Point2D New = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[0].X, TaskDisp.WipeStage.Path[0].Y);
            Log.OnAction("Set", ParamPrefix + ", Path 1", Old, New);

            UpdateDisplay();
        }
        private void btn_SetXY2_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[1].X, TaskDisp.WipeStage.Path[1].Y);

            double X = TaskGantry.GXPos() - TaskDisp.WipeStage.StartXY.X - TaskDisp.WipeStage.Path[0].X;
            double Y = TaskGantry.GYPos() - TaskDisp.WipeStage.StartXY.Y - TaskDisp.WipeStage.Path[0].Y;
            TaskDisp.WipeStage.Path[1] = new TPos3(X, Y, 0);

            NSW.Net.Point2D New = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[1].X, TaskDisp.WipeStage.Path[1].Y);
            Log.OnAction("Set", ParamPrefix + ", Path 2", Old, New);

            UpdateDisplay();
        }
        private void btn_SetXY3_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[2].X, TaskDisp.WipeStage.Path[2].Y);

            double X = TaskGantry.GXPos() - TaskDisp.WipeStage.StartXY.X - TaskDisp.WipeStage.Path[0].X - TaskDisp.WipeStage.Path[1].X;
            double Y = TaskGantry.GYPos() - TaskDisp.WipeStage.StartXY.Y - TaskDisp.WipeStage.Path[0].Y - TaskDisp.WipeStage.Path[1].Y;
            TaskDisp.WipeStage.Path[2] = new TPos3(X, Y, 0);

            NSW.Net.Point2D New = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[2].X, TaskDisp.WipeStage.Path[2].Y);
            Log.OnAction("Set", ParamPrefix + ", Path 3", Old, New);

            UpdateDisplay();
        }
        private void btn_SetXY4_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[3].X, TaskDisp.WipeStage.Path[3].Y);

            double X = TaskGantry.GXPos() - TaskDisp.WipeStage.StartXY.X - TaskDisp.WipeStage.Path[0].X - TaskDisp.WipeStage.Path[1].X - TaskDisp.WipeStage.Path[2].X;
            double Y = TaskGantry.GYPos() - TaskDisp.WipeStage.StartXY.Y - TaskDisp.WipeStage.Path[0].Y - TaskDisp.WipeStage.Path[1].Y - TaskDisp.WipeStage.Path[2].Y;
            TaskDisp.WipeStage.Path[3] = new TPos3(X, Y, 0);

            NSW.Net.Point2D New = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[3].X, TaskDisp.WipeStage.Path[3].Y);
            Log.OnAction("Set", ParamPrefix + ", Path 4", Old, New);

            UpdateDisplay();
        }
        private void btn_SetXY5_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[4].X, TaskDisp.WipeStage.Path[4].Y);

            double X = TaskGantry.GXPos() - TaskDisp.WipeStage.StartXY.X - TaskDisp.WipeStage.Path[0].X - TaskDisp.WipeStage.Path[1].X - TaskDisp.WipeStage.Path[2].X - TaskDisp.WipeStage.Path[3].X;
            double Y = TaskGantry.GYPos() - TaskDisp.WipeStage.StartXY.Y - TaskDisp.WipeStage.Path[0].Y - TaskDisp.WipeStage.Path[1].Y - TaskDisp.WipeStage.Path[2].Y - TaskDisp.WipeStage.Path[3].Y;
            TaskDisp.WipeStage.Path[4] = new TPos3(X, Y, 0);

            NSW.Net.Point2D New = new NSW.Net.Point2D(TaskDisp.WipeStage.Path[4].X, TaskDisp.WipeStage.Path[4].Y);
            Log.OnAction("Set", ParamPrefix + ", Path 5", Old, New);

            UpdateDisplay();
        }

        private void lbl_StageHeightOffset_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Stage Height Offset", ref TaskDisp.WipeStage.WipeHeightOffset, -5, 15);
            UpdateDisplay();
        }
        private void lbl_WipeGap_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Wipe Height", ref TaskDisp.WipeStage.WipeGap, -3, 3);
            UpdateDisplay();
        }
        private void lbl_WipeSpeed_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Wipe Speed", ref TaskDisp.WipeStage.WipeSpeed, 0.1, 500);
            UpdateDisplay();
        }
        private void lbl_PromptCleanCycles_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Prompt Clean Cycles", ref TaskDisp.WipeStage.PromptCleanCycles, 0, 100);
            UpdateDisplay();
        }
        private void lbl_UseTapeIndexer_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", UseTapeIndexer", ref TaskDisp.WipeStage.UseTapeIndexer);
            UpdateDisplay();
        }
        private void lbl_RepeatWipe_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(ParamPrefix + ", Repeat Wipe", ref TaskDisp.WipeStage.RepeatWipe, 0, 10);
            UpdateDisplay();
        }

        private void btn_ExecuteA_Click(object sender, EventArgs e)
        {
            TaskDisp.WipeStage.Execute(true, false);
            UpdateDisplay();
        }
        private void btn_ExecuteB_Click(object sender, EventArgs e)
        {
            TaskDisp.WipeStage.Execute(false, true);
            UpdateDisplay();
        }
    }
}
