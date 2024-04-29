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
    internal partial class frm_DispCore_DispProg_MoveLine : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);
        public TPos2 UnitOfst = new TPos2(DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex].X, DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex].Y);

        public frm_DispCore_DispProg_MoveLine()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            gboxOptions.Visible = TaskDisp.Preference != TaskDisp.EPreference.Unisem;
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

            int C = 0; int R = 0;
            try
            {
                DispProg.rt_Layouts[0].UnitNoGetRC(DispProg.RunTime.UIndex, ref C, ref R);
            }
            catch { }
                lbl_UnitRC.Text = "C,R = " + C.ToString() + "," + R.ToString();
            lbl_UnitRC.Visible = TaskDisp.Option_EnableRealTimeFineTune && C > 0 && R > 0;

            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();
            lbl_Cont.Text = (CmdLine.IPara[10] > 0).ToString();
            lbl_Radius.Text = CmdLine.DPara[10].ToString("f3");

            lbl_EarlyCutoff.Text = CmdLine.IPara[3].ToString();

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

                lbl_Time.Text = "SD/MT/ED (ms): " + d_StartDelay.ToString() + "/" + (t_XYMoveTime*1000).ToString("f0") + "/" + d_EndDelay.ToString();
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
        }

        private string CmdName
        {
            get
            {
                string Cmd = "";
                if (CmdLine.Cmd == DispProg.ECmd.LINE)
                    Cmd = "LINE";
                else
                    Cmd = "MOVE";

                
                return LineNo.ToString("d3") + " " + Cmd;
            }
        }

        private void frmDispProg_MoveLine_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            bool b_LineMode = (CmdLine.Cmd == DispProg.ECmd.LINE);

            l_lbl_ModelNo.Visible = b_LineMode;
            lbl_ModelNo.Visible = b_LineMode;
            btn_EditModel.Visible = b_LineMode;
            _lbl_Dispense.Visible = b_LineMode;
            lbl_Dispense.Visible = b_LineMode;

            lbl_Cont.Visible = b_LineMode;
            l_lbl_Cont.Visible = b_LineMode;

            btn_OfstAll.Visible = !b_LineMode;
            btn_GotoStartXY.Visible = b_LineMode;
            lbl_StartXY.Visible = b_LineMode;
            _lbl_StartXY.Visible = b_LineMode;

            gboxOptions.Visible = TaskDisp.Preference != TaskDisp.EPreference.Unisem && !b_LineMode;

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
        private void frm_DispCore_DispProg_MoveLine_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void lbl_HeadNo_Click(object sender, EventArgs e)
        {
            int i = Enum.GetNames(typeof(EHeadNo)).Length;
            UC.AdjustExec(CmdName + ", HeadNo", ref CmdLine.ID, 1, i);
            UpdateDisplay();
        }

        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Model No", ref CmdLine.IPara[0], 0, TModelList.MAX_MODEL);
            UpdateDisplay();
        }

        private void lbl_Dispense_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[2] > 0) CmdLine.IPara[2] = 0; else CmdLine.IPara[2] = 1;

            bool b_Value = CmdLine.IPara[2] > 0;
            Log.OnSet("Dispense", !b_Value, b_Value);
            UpdateDisplay();
        }

        private void lbl_Cont_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[10] > 0) CmdLine.IPara[10] = 0; else CmdLine.IPara[10] = 1;

            bool b_Value = CmdLine.IPara[10] > 0;
            Log.OnSet("Cont", !b_Value, b_Value);
            UpdateDisplay();
        }

        private void btn_EditModel_Click(object sender, EventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                //TaskVision.frmGenImageView.TopMost = false;
            }
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                //TaskVision.frmGenImageView.TopMost = true;
            }
        }

        private void lbl_X_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.X[0], 3);
            UC.AdjustExec(CmdName + ", X ", ref X, -1000, 1000);
            CmdLine.X[0] = X;
            UpdateDisplay();
        }

        private void lbl_Y_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[0], 3);
            UC.AdjustExec(CmdName + ", X ", ref Y, -1000, 1000);
            CmdLine.Y[0] = Y;
            UpdateDisplay();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref X, ref Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]); 
            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            Log.OnSet(CmdName + ", End XY", Old, New); 

            UpdateDisplay();
        }

        private void btn_Goto_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            int t = GDefine.GetTickCount();

            if (b_MeasTime)
            {
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
                    if (!TaskGantry.MoveAbsGXY(X, Y)) return;
                    lbl_Time2.Text = "Act MT (ms) " + (GDefine.GetTickCount() - t).ToString();
                }
                b_MeasTime = false;
            }
            else
            {
                if (!TaskGantry.SetMotionParamGXY()) return;
                if (!TaskGantry.MoveAbsGXY(X, Y)) return;
                lbl_Time2.Text = "-";

            }
        }

        bool b_MeasTime = false;
        private void btn_GotoStartXY_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + StartPt.X;
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + StartPt.Y;

            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            b_MeasTime = true;
        }

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
            //frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName);
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void btn_Trig_Click(object sender, EventArgs e)
        {
            bool DispA = true;
            bool DispB = (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double);

            if (!TaskDisp.CtrlCheckReady(DispA, DispB)) return;
            int t_Time = GDefine.GetTickCount();

            if (!TaskDisp.TrigOn(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitResponse(DispA, DispB)) return;
            if (!TaskDisp.TrigOff(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitComplete(DispA, DispB)) return;
            int t_TrigTime = GDefine.GetTickCount() - t_Time;
            lbl_TrigTime.Text = t_TrigTime.ToString() + " ms";

            UpdateDisplay();
        }

        double d_TempLength = 0;
        private void btn_SetLength_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Start = new NSW.Net.Point2D(StartPt.X, StartPt.Y);
            NSW.Net.Point2D End = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);

            NSW.Net.Polar EndPt = new NSW.Net.Polar(Start, End);
            double Old = EndPt.R;
            EndPt.R = d_TempLength;
            double New = EndPt.R;
            Log.OnSet(CmdName + ", Length", Old, New);

            CmdLine.X[0] = StartPt.X + EndPt.Point2D.X;
            CmdLine.Y[0] = StartPt.Y + EndPt.Point2D.Y;

            lbl_Length.BackColor = this.BackColor;

            UpdateDisplay();
        }

        private void lbl_Length_Click(object sender, EventArgs e)
        {
            d_TempLength = Math.Round(d_Length, 3);
            UC.AdjustExec(CmdName + ", Length (mm)",  ref d_TempLength, 0.001, 1000);

            lbl_Length.BackColor = Color.Orange;
            lbl_Length.Text = d_TempLength.ToString("f3");
        }

        private void lbl_Radius_Click(object sender, EventArgs e)
        {
            double d = Math.Round(CmdLine.DPara[10], 3);
            UC.AdjustExec(CmdName + ", Radius (mm)", ref d, 0, 5);
            CmdLine.DPara[10] = d;
            UpdateDisplay();
        }

        private void lbl_EarlyCutoff_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Early CutOff (ms)", ref CmdLine.IPara[3], 0, 5000);
            UpdateDisplay();
        }

        private void btn_OfstAll_Click(object sender, EventArgs e)
        {
            frm_DispCore_EditXY frm = new frm_DispCore_EditXY();
            frm.ParamName = "OfstAll XY";
            double OfstX = 0;
            double OfstY = 0;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OfstX = frm.OfstX;
                OfstY = frm.OfstY;
                Log.OnAction("Update", CmdName + ", Offset All", "0,0", OfstX.ToString() + "," + OfstY.ToString());

                CmdLine.X[0] = CmdLine.X[0] + OfstX;
                CmdLine.Y[0] = CmdLine.Y[0] + OfstY;

                for (int i = LineNo; i < DispProg.Script[0].CmdList.Count; i++)
                {
                    if (DispProg.Script[0].CmdList.Line[i].Cmd == DispProg.ECmd.LINE ||
                        DispProg.Script[0].CmdList.Line[i].Cmd == DispProg.ECmd.ARC ||
                        DispProg.Script[0].CmdList.Line[i].Cmd == DispProg.ECmd.CIRC)
                    {
                        DispProg.Script[0].CmdList.Line[i].X[0] = DispProg.Script[0].CmdList.Line[i].X[0] + OfstX;
                        DispProg.Script[0].CmdList.Line[i].Y[0] = DispProg.Script[0].CmdList.Line[i].Y[0] + OfstY;
                    }
                    if (DispProg.Script[0].CmdList.Line[i].Cmd == DispProg.ECmd.ARC ||
                        DispProg.Script[0].CmdList.Line[i].Cmd == DispProg.ECmd.CIRC)
                    {
                        DispProg.Script[0].CmdList.Line[i].X[1] = DispProg.Script[0].CmdList.Line[i].X[1] + OfstX;
                        DispProg.Script[0].CmdList.Line[i].Y[1] = DispProg.Script[0].CmdList.Line[i].Y[1] + OfstY;
                    }

                    if (DispProg.Script[0].CmdList.Line[i].Cmd == DispProg.ECmd.END_LAYOUT) break;
                }
            }
            UpdateDisplay();
        }

        private void cbAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = (sender as CheckBox).Checked;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (DispProg.LastLine > -1)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION, EMcState.Notice, EMsgBtn.smbOK, false);
                return;
            }

            //**Reached MAX_CMD
            if (DispProg.Script[0].CmdList.Count >= DispProg.TCmdList.MAX_CMD) return;

            //Update current line
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);

            //In2ert new line
            LineNo++;
            DispProg.Script[0].Insert(ref LineNo, DispProg.ECmd.DOT);

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref X, ref Y);

            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            Log.OnSet(CmdName + ", Add XY", new NSW.Net.Point2D(0, 0), new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]));

            UpdateDisplay();
        }
    }
}
