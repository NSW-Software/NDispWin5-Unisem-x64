using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MsgBox2;

namespace DispCore
{
    internal partial class frm_DispCore_DispProg_DoUnitMark : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_DoUnitMark()
        {
            InitializeComponent();

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Left = 0;
            TopLevel = false;
            TopMost = true;
            Top = 0;

            lbl_NoImage.Visible = false;

            AppLanguage.Func.SetComponent(this);
        }

        public void UpdateDisplay()
        {
            lbl_CameraID.Text = CmdLine.IPara[2].ToString();

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");

            lbl_XYTol.Text = CmdLine.DPara[1].ToString("F3");
            lbl_MinScore.Text = (CmdLine.DPara[0] * 100).ToString("F0");
            lbl_InvertJudgement.Text = Convert.ToBoolean(CmdLine.IPara[0]).ToString();
            //lbl_ContErrorCount.Text = CmdLine.IPara[1].ToString();

            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
            lbl_SkipCount.Text = CmdLine.IPara[5].ToString();
            lbl_FailAction.Text = CmdLine.IPara[6].ToString() + " - " + Enum.GetName(typeof(EFailAction), CmdLine.IPara[6]); 
        }

        private void UpdateImages()
        {
            lbl_NoImage.Visible = false;

            try
            {
                pbox_PatImage.Image = TaskVision.UnitMarkTemplate.Image.ToBitmap();
            }
            catch
            {
                lbl_NoImage.Visible = true;
            }
        }

        private void frmDispProg_DoBadMark_Load(object sender, EventArgs e)
        {
            this.Text = "Command - DO_UNITMARK";

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            TaskVision.SelectedCam = (ECamNo)CmdLine.IPara[2]; 
            TaskVision.LightingOn(TaskVision.UnitMarkLightRGB);

            if (CmdLine.DPara[0] == 0) CmdLine.DPara[0] = 0.85;
            if (CmdLine.DPara[1] == 0) CmdLine.DPara[1] = 2;
            if (CmdLine.IPara[4] == 0) CmdLine.IPara[1] = 150;

            UpdateDisplay();
            UpdateImages();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
        }

        private void btn_SetPt1Pos_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;
            
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            UpdateDisplay();
        }

        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            //if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_XYTol_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[1], 0, 5);
            UpdateDisplay();
        }

        private void lbl_MinScore_Click(object sender, EventArgs e)
        {
            int i = (int)(CmdLine.DPara[0] * 100);
            GDefine.uc.UserAdjustExecute(ref i, 1, 99);
            CmdLine.DPara[0] = (double)i / 100;
            UpdateDisplay();
        }

        private void lbl_InvertJudgement_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[0] == 0)
                CmdLine.IPara[0] = 1;
            else
                CmdLine.IPara[0] = 0;
            UpdateDisplay();
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            string EMsg = "Unit Mark Test";

            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            double X = 0;
            double Y = 0;
            double S = 0;
            int t = Environment.TickCount;

            int CamID = CmdLine.IPara[2];

            try
            {
                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> FoundTemplate = null;
                TaskVision.MatchTemplate(CamID, TaskVision.UnitMarkTemplate, out X, out Y, out S, ref FoundTemplate);
                t = Environment.TickCount - t;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
            }

            double v_ox = X * TaskVision.DistPerPixelX[CamID];
            double v_oy = Y * TaskVision.DistPerPixelY[CamID];
            double v_s = S;

            bool OK = (Math.Abs(v_ox) <= CmdLine.DPara[1]) && (Math.Abs(v_oy) <= CmdLine.DPara[1]) && (Math.Abs(v_s) >= CmdLine.DPara[0]);
            if (CmdLine.IPara[0] > 0) OK = !OK;

            lbl_OfstXY.Text = v_ox.ToString("F3") + ", " + v_oy.ToString("F3");
            lbl_Score.Text = (v_s*100).ToString("F1");
            if (OK)
            {
                lbl_Result.ForeColor = Color.Green;
                lbl_Result.Text = "OK";
            }
            else
            {
                lbl_Result.ForeColor = Color.Red;
                lbl_Result.Text = "NG";
            }
            lbl_Time.Text = t.ToString();
        }

        private void btn_Learn_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            CmdLine.IPara[2] = (int)TaskVision.SelectedCam;
            TaskVision.TeachTemplate(CmdLine.IPara[2], ref TaskVision.UnitMarkTemplate);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateImages();
            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            TaskVision.UnitMarkLightRGB = TaskVision.CurrentLightRGBA;

            TaskVision.LightingOn(TaskVision.DefLightRGB);
            frm_DispCore_DispProg.Done = true;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            frm_DispCore_DispProg.Done = true;
            Close();
        }

        private void lbl_CameraID_Click(object sender, EventArgs e)
        {

        }

        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Settle Time", ref CmdLine.IPara[4], 0, 500);
            UpdateDisplay();
        }

        private void lbl_FailAction_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Fail Action", ref CmdLine.IPara[6], 0, Enum.GetNames(typeof(EFailAction)).Length);
            UpdateDisplay();
        }

        private void lbl_SkipCount_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Skip Count", ref CmdLine.IPara[5], 0, 50);
            UpdateDisplay();
        }

        private void lbl_FocusNo_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Focus No", ref CmdLine.IPara[21], 0, DispProg.MAX_FOCUS_POS - 1);
            UpdateDisplay();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
        }


    }
}
