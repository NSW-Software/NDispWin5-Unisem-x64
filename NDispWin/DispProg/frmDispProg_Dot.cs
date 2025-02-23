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
    internal partial class frm_DispCore_DispProg_Dot : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_Dot()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            gbxOptions.Visible = TaskDisp.Preference != TaskDisp.EPreference.Unisem;
        }

        private void UpdateDisplay()
        {
            btn_Help.Visible = CmdLine.Cmd == DispProg.ECmd.DOT_P;

            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;
            lbl_HeadNo.Text = CmdLine.ID.ToString();

            int C = 0; int R = 0;
            try
            {
                DispProg.rt_Layouts[0].UnitNoGetRC(DispProg.RunTime.UIndex, ref C, ref R);
            }
            catch { }                
            lbl_UnitRC.Text = "C,R = " + C.ToString() + "," + R.ToString();
            lbl_UnitRC.Visible = TaskDisp.Option_EnableRealTimeFineTune && C > 0 && R > 0;

            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();

            lbl_ModelNo.Text = CmdLine.IPara[0].ToString();

            if (CmdLine.IPara[1] >= Enum.GetNames(typeof(EDotMode)).Length) CmdLine.IPara[1] = 0;

            lbl_Mode.Text = Enum.GetName(typeof(EDotMode), CmdLine.IPara[1]);

            lbl_X1.Text = CmdLine.X[0].ToString("F3");
            lbl_Y1.Text = CmdLine.Y[0].ToString("F3");

            int ModelNo = CmdLine.IPara[0];
            double t_StartWait = 0;
            double t_StartDelay = 0;
            double t_EndDelay = 0;
            double t_EndWait = 0;

            t_StartWait = (int)DispProg.ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DnWait];
            t_StartDelay = (int)DispProg.ModelList.Model[ModelNo].Para[(int)TModelList.EModel.StartDelay];
            t_EndDelay = (int)DispProg.ModelList.Model[ModelNo].Para[(int)TModelList.EModel.EndDelay];
            t_EndWait = (int)DispProg.ModelList.Model[ModelNo].Para[(int)TModelList.EModel.PostWait];

            //lbl_DownTime.Text = (t_StartWait + t_StartDelay + t_EndDelay + t_EndWait).ToString("F3");

            //PreMoveZ
            if (CmdLine.IPara[3] == 0)
                lbl_PreMoveZ.Text = "FALSE";
            else
                lbl_PreMoveZ.Text = "TRUE";
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

        private void lbl_HeadNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", HeadNo", ref CmdLine.ID, 1, 3);
            UpdateDisplay();
        }

        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", ModelNo", ref CmdLine.IPara[0], 0, 15);
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
            double X = Math.Round(CmdLine.X[0], 3);
            UC.AdjustExec(CmdName + ", X1", ref X, -1000, 1000);
            CmdLine.X[0] = X;
            UpdateDisplay();
        }

        private void lbl_Y1_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[0], 3);
            UC.AdjustExec(CmdName + ", Y1", ref Y, -1000, 1000);
            CmdLine.Y[0] = Y;
            UpdateDisplay();
        }
        private void btn_SetXY_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckInDispenseArea()) return;

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref X, ref Y);

            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            Log.OnSet(CmdName + ", Set XY", Old, new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]));

            UpdateDisplay();
        }
        private void btn_GotoXY_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_EditXY_Click(object sender, EventArgs e)
        {
            frm_DispCore_EditXY frm = new frm_DispCore_EditXY();
            frm.ParamName = LineNo.ToString() + " Dot XY";
            frm.ValueX = CmdLine.X[0];
            frm.ValueY = CmdLine.Y[0];

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CmdLine.X[0] = frm.ValueX;
                CmdLine.Y[0] = frm.ValueY;
            }

            UpdateDisplay();
        }

        private void lbl_PreMoveZ_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[3] > 0)
                CmdLine.IPara[3] = 0;
            else
                CmdLine.IPara[3] = 1;
            UpdateDisplay();
        }

        private void btn_Trig_Click(object sender, EventArgs e)
        {
            bool DispA = true;
            bool DispB = (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double);

            if (!TaskDisp.CtrlCheckReady(DispA, DispB)) return;
            int t_Disp = GDefine.GetTickCount();

            if (!TaskDisp.TrigOn(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitResponse(DispA, DispB)) return;
            if (!TaskDisp.TrigOff(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitComplete(DispA, DispB)) return;
            t_Disp = GDefine.GetTickCount() - t_Disp;
            lbl_TrigTime.Text = t_Disp.ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];
            if (!TaskGantry.CheckInDispenseArea(new PointD(X, Y))) return;

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

        private void frm_DispCore_DispProg_Dot_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            //myProcess.StartInfo.FileName = "acrord32.exe";
            //myProcess.StartInfo.Arguments = "/n /A \"search=Commnd DOT_P\" " + filename;
            //myProcess.Start();

            System.Diagnostics.Process.Start(GDefine.CmdHelpFile);
        }

        private void gbox_Pos_Enter(object sender, EventArgs e)
        {

        }

        private void cbAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = (sender as CheckBox).Checked;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckInDispenseArea()) return;

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
            Log.OnSet(CmdName + ", Add XY", new NSW.Net.Point2D(0,0), new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]));

            UpdateDisplay();
        }
    }
}
