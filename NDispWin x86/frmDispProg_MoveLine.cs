using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DispCore
{
    internal partial class frm_DispCore_DispProg_MoveLine : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_MoveLine()
        {
            InitializeComponent();

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            AppLanguage.Func.SetComponent(this);
        }

        static NSW.Net.Point2D StartPt = new NSW.Net.Point2D(0, 0);
        bool StartPtValid = false;
        private void UpdateDisplayOnce()
        {
            int Line = LineNo;
            while (Line > 0)
            {
                Line--;
                if (DispProg.Script[ProgNo].CmdList.Line[Line].Cmd == DispProg.ECmd.LINE ||
                    DispProg.Script[ProgNo].CmdList.Line[Line].Cmd == DispProg.ECmd.MOVE ||
                    DispProg.Script[ProgNo].CmdList.Line[Line].Cmd == DispProg.ECmd.DOT)
                {
                    StartPt.X = DispProg.Script[ProgNo].CmdList.Line[Line].X[0];
                    StartPt.Y = DispProg.Script[ProgNo].CmdList.Line[Line].Y[0];
                    StartPtValid = true;
                    break;
                }
                if (DispProg.Script[ProgNo].CmdList.Line[Line].Cmd == DispProg.ECmd.ARC)
                {
                    StartPt.X = DispProg.Script[ProgNo].CmdList.Line[Line].X[1];
                    StartPt.Y = DispProg.Script[ProgNo].CmdList.Line[Line].Y[1];
                    StartPtValid = true;
                    break;
                }
            }
        }

        double d_Length = 0;
        private void UpdateDisplay()
        {
            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;
            lbl_HeadNo.Text = CmdLine.ID.ToString();
            //combox_HeadID.SelectedIndex = CmdLine.ID;
            
            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();
            lbl_Cont.Text = (CmdLine.IPara[10] > 0).ToString();
            lbl_Radius.Text = CmdLine.DPara[10].ToString("f3");
            lbl_Smooth.Text = CmdLine.IPara[11].ToString();


            //combox_ModelNo.SelectedIndex = CmdLine.Para;
            lbl_ModelNo.Text = CmdLine.IPara[0].ToString();

            lbl_X.Text = CmdLine.X[0].ToString("F3");
            lbl_Y.Text = CmdLine.Y[0].ToString("F3");

            if (StartPtValid && LineNo > 0)
            {
                lbl_StartXY.Text = StartPt.X.ToString("F3") + ", " + StartPt.Y.ToString("F3");

                double LX = CmdLine.X[0] - StartPt.X;
                double LY = CmdLine.Y[0] - StartPt.Y;
                d_Length = Math.Sqrt(Math.Pow(LX, 2) + Math.Pow(LY, 2));

                lbl_Length.Text = d_Length.ToString("F3");

                double d_LineStartV = DispProg.ModelList.Model[CmdLine.IPara[0]].Para[(int)TModelList.EModel.LineStartV];
                double d_LineSpeed = DispProg.ModelList.Model[CmdLine.IPara[0]].Para[(int)TModelList.EModel.LineSpeed];
                double d_LineAccel = DispProg.ModelList.Model[CmdLine.IPara[0]].Para[(int)TModelList.EModel.LineAccel];
                double t_XYMoveTime = 0;
                TaskGantry.GetMotionDataEx(d_LineStartV, d_LineSpeed, d_LineAccel, d_Length, ref t_XYMoveTime);

                double d_StartDelay = DispProg.ModelList.Model[CmdLine.IPara[0]].Para[(int)TModelList.EModel.StartDelay];
                double d_EndDelay = DispProg.ModelList.Model[CmdLine.IPara[0]].Para[(int)TModelList.EModel.EndDelay];

                lbl_Time.Text = d_StartDelay.ToString() + " " + (t_XYMoveTime*1000).ToString("f0") + " " + d_EndDelay.ToString() + " ms";
            }
            else
            {
                lbl_StartXY.Text = "undetermined";
                lbl_Length.Text = "undetermined";
            }

            if (CmdLine.IPara[3] == 0)
                lbl_PreMoveZ.Text = "FALSE";
            else
                lbl_PreMoveZ.Text = "TRUE";

            lbl_ReverseDir.Text = Enum.GetName(typeof(EMoveLineRev), CmdLine.IPara[4]).ToString(); 

            lbl_Head.Text = "Head " + SelectedHead.ToString();
            
            lbl_Weight.Text = CmdLine.DPara[0].ToString("F1");
            lbl_WeightTol.Text = CmdLine.DPara[1].ToString("F1");

            lbl_TrigTime.Text = CmdLine.DPara[2].ToString();
            lbl_TimeTol.Text = CmdLine.DPara[3].ToString();
        }

        private void frmDispProg_MoveLine_Load(object sender, EventArgs e)
        {
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            bool b_LineMode = true;
            if (CmdLine.Cmd == DispProg.ECmd.LINE)
            {
                this.Text = "Command - LINE";
                b_LineMode = true;
            }
            else
            {
                this.Text = "Command - MOVE";
                b_LineMode = false;
            }

            l_lbl_ModelNo.Visible = b_LineMode;
            lbl_ModelNo.Visible = b_LineMode;
            btn_EditModel.Visible = b_LineMode;
            _lbl_Dispense.Visible = b_LineMode;
            lbl_Dispense.Visible = b_LineMode;

            lbl_Cont.Visible = b_LineMode;
            l_lbl_Cont.Visible = b_LineMode;
            pnl_Radius.Visible = b_LineMode;

            gbox_Options.Visible = !b_LineMode;

            //l_lbl_Weight.Visible = b_LineMode;
            //lbl_Weight.Visible = b_LineMode;
            //lbl_WeightTol.Visible = b_LineMode;
            //btn_CalWeight.Visible = b_LineMode;
            gbox_Calibration.Visible = b_LineMode;

            UpdateDisplayOnce();
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

        private void lbl_HeadNo_Click(object sender, EventArgs e)
        {
            int i = Enum.GetNames(typeof(EHeadNo)).Length;
            GDefine.uc.UserAdjustExecute(ref CmdLine.ID, 1, i);
            UpdateDisplay();
        }

        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[0], 0, TModelList.MAX_MODEL);
            UpdateDisplay();
        }

        private void lbl_Dispense_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[2] > 0) CmdLine.IPara[2] = 0; else CmdLine.IPara[2] = 1;
            UpdateDisplay();
        }

        private void lbl_Cont_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[10] > 0) CmdLine.IPara[10] = 0; else CmdLine.IPara[10] = 1;
            UpdateDisplay();
        }

        private void btn_EditModel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
        }

        private void lbl_X_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.X[0], 3);
            GDefine.uc.UserAdjustExecute(ref X, -1000, 1000);
            CmdLine.X[0] = X;
            UpdateDisplay();
        }

        private void lbl_Y_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[0], 3);
            GDefine.uc.UserAdjustExecute(ref Y, -1000, 1000);
            CmdLine.Y[0] = Y;
            UpdateDisplay();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            UpdateDisplay();
        }

        private void btn_Goto_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            //if (!TaskGantry.SetMotionParamGZ()) return;
            //if (!TaskGantry.MoveAbsGZ(0)) return;

            int t = GDefine.GetTickCount();

            if (CmdLine.Cmd == DispProg.ECmd.LINE)
            {
                double d_LineStartV = DispProg.ModelList.Model[CmdLine.IPara[0]].Para[(int)TModelList.EModel.LineStartV];
                if (d_LineStartV == 0)
                    d_LineStartV = TaskGantry.GXAxis.Para.StartV;

                double d_LineSpeed = DispProg.ModelList.Model[CmdLine.IPara[0]].Para[(int)TModelList.EModel.LineSpeed];
                if (d_LineSpeed == 0)
                    d_LineSpeed = TaskGantry.GXAxis.Para.StartV;

                double d_LineAccel = DispProg.ModelList.Model[CmdLine.IPara[0]].Para[(int)TModelList.EModel.LineAccel];
                if (d_LineAccel == 0)
                    d_LineAccel = TaskGantry.GXAxis.Para.Accel;
                
                if (!TaskGantry.SetMotionParamEx(TaskGantry.GXAxis, d_LineStartV, d_LineSpeed, d_LineAccel)) return;
            }
            else
            {
                if (!TaskGantry.SetMotionParamGXY()) return;
            }

            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
            lbl_Time2.Text = (GDefine.GetTickCount() - t).ToString() + " ms";
        }

        private void btn_GotoStartXY_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + StartPt.X;
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + StartPt.Y;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            //if (!TaskGantry.SetMotionParamGZ()) return;
            //if (!TaskGantry.MoveAbsGZ(0)) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        //private void btn_Run_Click(object sender, EventArgs e)
        //{
        //    if (CmdLine.Cmd == DispProg.ECmd.LINE)
        //    {
        //        #region
        //        if (!TaskGantry.SetMotionParamGZ()) return;
        //        if (!TaskGantry.MoveAbsGZ(0)) return;

        //        double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + StartPt.X;
        //        double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + StartPt.Y;

        //        if (!TaskGantry.SetMotionParamGXY()) return;
        //        if (!TaskGantry.MoveAbsGXY(X, Y)) return;

        //        int ModelNo = CmdLine.IPara[0];
        //        double t_StartDelay = 0;
        //        double d_LineStartV = 0;
        //        double d_LineSpeed = 0;
        //        double d_LineAccel = 0;
        //        double t_EndDelay = 0;

        //        t_StartDelay = (int)DispProg.ModelList.Model[ModelNo].Para[(int)DispProg.TModelList.EModel.StartDelay];

        //        if (DispProg.ModelList.Model[ModelNo].Para[(int)DispProg.TModelList.EModel.LineStartV] == 0)
        //            d_LineStartV = TaskGantry.GZAxis.Para.StartV;
        //        else
        //            d_LineStartV = DispProg.ModelList.Model[ModelNo].Para[(int)DispProg.TModelList.EModel.LineStartV];

        //        if (DispProg.ModelList.Model[ModelNo].Para[(int)DispProg.TModelList.EModel.LineSpeed] == 0)
        //            d_LineSpeed = TaskGantry.GZAxis.Para.FastV;
        //        else
        //            d_LineSpeed = DispProg.ModelList.Model[ModelNo].Para[(int)DispProg.TModelList.EModel.LineSpeed];

        //        if (DispProg.ModelList.Model[ModelNo].Para[(int)DispProg.TModelList.EModel.LineAccel] == 0)
        //            d_LineAccel = TaskGantry.GZAxis.Para.Accel;
        //        else
        //            d_LineAccel = DispProg.ModelList.Model[ModelNo].Para[(int)DispProg.TModelList.EModel.LineAccel];

        //        t_EndDelay = (int)DispProg.ModelList.Model[ModelNo].Para[(int)DispProg.TModelList.EModel.EndDelay];

        //        X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.PosX[0];
        //        Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.PosY[0];

        //        int t_Move = GDefine.GetTickCount();

        //        int t_Start = GDefine.GetTickCount() + (int)t_StartDelay;
        //        while (GDefine.GetTickCount() < t_Start) Application.DoEvents();

        //        if (!TaskGantry.SetMotionParamGXY(d_LineStartV, d_LineSpeed, d_LineAccel)) return;
        //        if (!TaskGantry.MoveAbsGXY(X, Y)) return;

        //        int t_End = GDefine.GetTickCount() + (int)t_EndDelay;
        //        while (GDefine.GetTickCount() < t_Start) Application.DoEvents();

        //        t_Move = GDefine.GetTickCount() - t_Move;
        //        lbl_MoveTime.Text = t_Move.ToString();
        //        #endregion
        //    }
        //    else
        //    {

        //    }
        //}

        //int t_TrigTime = 0;
        //int t_TimeTol = 0;


        private void lbl_PreMoveZ_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[3] > 0)
                CmdLine.IPara[3] = 0;
            else
                CmdLine.IPara[3] = 1;
            UpdateDisplay();
        }

        private void lbl_ReverseDir_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[4]++;

            int Max = Enum.GetNames(typeof(EMoveLineRev)).Length - 1;
            if (CmdLine.IPara[4] > Max)
                CmdLine.IPara[4] = 0;

            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            frm_DispCore_DispProg.Done = true;
            Close();
            //Visible = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg.Done = true;
            Close();
            //Visible = false;
        }



        private void lbl_StartXY_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int SelectedHead = 1;
        private void lbl_Head_Click(object sender, EventArgs e)
        {
            if (SelectedHead == 2) SelectedHead = 1;
            else
                SelectedHead = 2;

            UpdateDisplay();
        }
        #region Cal Speed to Time
        private void lbl_TrigTime_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[2], 0, 30000);
            UpdateDisplay();
        }
        private void lbl_TimeTol_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[3], 0, 100);
            UpdateDisplay();
        }
        private void btn_Trig_Click(object sender, EventArgs e)
        {
            //if (!TaskDisp.CtrlCheckReady((SelectedHead == 1), (SelectedHead == 2))) return;
 
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
            int t_Time = GDefine.GetTickCount();

            if (!TaskDisp.TrigOn(DispA, DispB)) return;
            //if (!TaskDisp.HPCWaitNotReady(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitResponse(DispA, DispB)) return;
            if (!TaskDisp.TrigOff(DispA, DispB)) return;
            //if (!TaskDisp.CtrlWaitReady(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitComplete(DispA, DispB)) return;
            int t_TrigTime = GDefine.GetTickCount() - t_Time;

            CmdLine.DPara[2] = (int)t_TrigTime;
            UpdateDisplay();

            MessageBox.Show("Trigger Time is " + t_TrigTime.ToString() + " ms");
        }
        private void btn_CalSpeedToTime_Click(object sender, EventArgs e)
        {
            DispProg.TCmdList CmdList = new DispProg.TCmdList();
            CmdList.Copy(DispProg.Script[ProgNo].CmdList);
            CmdList.Line[LineNo].Copy(CmdLine);

            int d = 0;
            if (DispProg.Script[ProgNo].CalSpeedToTime(SelectedHead, ref CmdList, LineNo, (int)CmdLine.DPara[3], ref d))
            {
                CmdLine.DPara[2] = (int)d;
            }

            UpdateDisplay();
        }
        #endregion

        #region Cal Speed to Weight
        private void lbl_Weight_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[0], 0, 500);
            UpdateDisplay();
        }
        private void lbl_WeightTol_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[1], 0, 100);
            UpdateDisplay();
        }
        private void btn_Measure_Click(object sender, EventArgs e)
        {
            DispProg.TCmdList CmdList = new DispProg.TCmdList();
            CmdList.Copy(DispProg.Script[ProgNo].CmdList);
            CmdList.Line[LineNo].Copy(CmdLine);

            TaskDisp.CalWeight(SelectedHead, DispProg.Script[ProgNo], CmdList, LineNo, true);
        }
        private void btn_CalWeight_Click(object sender, EventArgs e)
        {
            DispProg.TCmdList CmdList = new DispProg.TCmdList();
            CmdList.Copy(DispProg.Script[ProgNo].CmdList);
            CmdList.Line[LineNo].Copy(CmdLine);

            TaskDisp.CalWeight(SelectedHead, DispProg.Script[ProgNo], CmdList, LineNo, false);
        }
        #endregion


        double d_TempLength = 0;
        private void btn_SetLength_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Start = new NSW.Net.Point2D(StartPt.X, StartPt.Y);
            NSW.Net.Point2D End = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);

            NSW.Net.Polar EndPt = new NSW.Net.Polar(Start, End);
            EndPt.R = d_TempLength;

            CmdLine.X[0] = StartPt.X + EndPt.Point2D.X;
            CmdLine.Y[0] = StartPt.Y + EndPt.Point2D.Y;

            lbl_Length.BackColor = this.BackColor;

            UpdateDisplay();
        }

        private void lbl_Length_Click(object sender, EventArgs e)
        {
            d_TempLength = Math.Round(d_Length, 3);
            GDefine.uc.UserAdjustExecute(ref d_TempLength, 0.001, 1000);

            lbl_Length.BackColor = Color.Orange;
            lbl_Length.Text = d_TempLength.ToString("f3");
        }

        private void lbl_Radius_Click(object sender, EventArgs e)
        {
            double d = Math.Round(CmdLine.DPara[10], 3);
            GDefine.uc.UserAdjustExecute(ref d, 0, 5);
            CmdLine.DPara[10] = d;
            UpdateDisplay();

        }

        private void lbl_Smooth_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[11], 0, 200);
            UpdateDisplay();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void _lbl_Length_Click(object sender, EventArgs e)
        {

        }

        private void gbox_Options_Enter(object sender, EventArgs e)
        {

        }




    }
}
