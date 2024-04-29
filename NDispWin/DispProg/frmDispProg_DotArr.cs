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
    internal partial class frm_DispCore_DispProg_DotArr : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_DotArr()
        {
            InitializeComponent();

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            AppLanguage.Func.SetComponent(this);
        }

        private void UpdateDisplay()
        {
            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;
            lbl_HeadNo.Text = CmdLine.ID.ToString();
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
        }

        private void frmDispProg_Dot_Load(object sender, EventArgs e)
        {
            this.Text = "Dot";
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
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
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
        }       

        private void lbl_HeadNo_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.ID, 1, 3);
            UpdateDisplay();
        }

        private void lbl_ModelNo_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[0], 0, 15);
            UpdateDisplay();
        }

        private void lbl_Mode_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[1], 0, 1);
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
            GDefine.uc.UserAdjustExecute(ref X, -1000, 1000);
            CmdLine.X[0] = X;
            UpdateDisplay();
        }

        private void lbl_Y1_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[0], 3);
            GDefine.uc.UserAdjustExecute(ref Y, -1000, 1000);
            CmdLine.Y[0] = Y;
            UpdateDisplay();
        }
        private void btn_SetPt1Pos_Click(object sender, EventArgs e)
        {
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

            //X = X + DispProg.OriginDrawOfst.X;
            //Y = Y + DispProg.OriginDrawOfst.Z;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

       
        private void frmDispProg_Dot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //do tab
            }
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

        private void frmDispProg_Dot_Click(object sender, EventArgs e)
        {

        }

        private void cbox_Disp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void btn_Trig_Click(object sender, EventArgs e)
        {
            //if (!TaskDisp.TrigCheckReady((SelectedHead == 1), (SelectedHead == 2))) return;

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
            int t_Disp = GDefine.GetTickCount();

            if (!TaskDisp.TrigOn(DispA, DispB)) return;
            //if (!TaskDisp.HPCWaitNotReady(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitResponse(DispA, DispB)) return;
            if (!TaskDisp.TrigOff(DispA, DispB)) return;
            //if (!TaskDisp.CtrlWaitReady(DispA, DispB)) return;
            if (!TaskDisp.CtrlWaitComplete(DispA, DispB)) return;
            t_Disp = GDefine.GetTickCount() - t_Disp;
            lbl_TrigTime.Text = t_Disp.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



    }
}
