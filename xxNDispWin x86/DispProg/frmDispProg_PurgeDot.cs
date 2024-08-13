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
    internal partial class frm_DispCore_DispProg_PurgeDot : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_PurgeDot()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            //AppLanguage.Func.SetComponent(this);
        }

        private void UpdateDisplay()
        {
            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;
            lbl_HeadNo.Text = CmdLine.ID.ToString();
            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();

            lbl_ModelNo.Text = CmdLine.IPara[0].ToString();

            if (CmdLine.IPara[1] >= Enum.GetNames(typeof(EDotMode)).Length) CmdLine.IPara[1] = 0;

            lbl_Mode.Text = Enum.GetName(typeof(EDotMode), CmdLine.IPara[1]);

            TConditions Cond = new TConditions(LineNo, CmdLine);
            lbox_Cond.Items.Clear();
            foreach (string s in Cond.Strings)
            {
                lbox_Cond.Items.Add(s);
            }

            if (CmdLine.IPara[4] == 0)
                lbl_Position.Text = "Auto";
            else
                lbl_Position.Text = "Manual";

            gbox_Pos.Visible = (CmdLine.IPara[4] > 0);

            lbl_X1.Text = CmdLine.X[0].ToString("F3");
            lbl_Y1.Text = CmdLine.Y[0].ToString("F3");
            lbl_Z1.Text = CmdLine.Z[0].ToString("F3");

            pnl_X2Y2Z2.Visible = GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2;
            
            lbl_X2.Text = CmdLine.X[1].ToString("F3");
            lbl_Y2.Text = CmdLine.Y[1].ToString("F3");
            lbl_Z2.Text = CmdLine.Z[1].ToString("F3");
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_PurgeDot_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = CmdName;
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            UpdateDisplay();
        }

        private void lbl_HeadNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", HeadNo", ref CmdLine.ID, 1, 3);
            UpdateDisplay();
        }

        private void lbl_Dispense_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[2] > 0) CmdLine.IPara[2] = 0; else CmdLine.IPara[2] = 1;
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

        private void lbl_Position_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Position", ref CmdLine.IPara[4], 0, 1);
            UpdateDisplay();
        }

        private void btn_EditModel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
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

        private void lbl_Z1_Click(object sender, EventArgs e)
        {
            double Z = Math.Round(CmdLine.Z[0], 3);
            UC.AdjustExec(CmdName + ", Z1", ref Z, -1000, 1000);
            CmdLine.Z[0] = Z;
            UpdateDisplay();
        }

        private void lbl_X2_Click(object sender, EventArgs e)
        {
            double X2 = Math.Round(CmdLine.X[0], 3);
            UC.AdjustExec(CmdName + ", X2", ref X2, -1000, 1000);
            CmdLine.X[1] = X2;
            UpdateDisplay();
        }

        private void lbl_Y2_Click(object sender, EventArgs e)
        {
            double Y2 = Math.Round(CmdLine.Y[0], 3);
            UC.AdjustExec(CmdName + ", Y2", ref Y2, -1000, 1000);
            CmdLine.Y[1] = Y2;
            UpdateDisplay();
        }

        private void lbl_Z2_Click(object sender, EventArgs e)
        {
            double Z2 = Math.Round(CmdLine.Z[0], 3);
            UC.AdjustExec(CmdName + ", Z2", ref Z2, -1000, 1000);
            CmdLine.Z[1] = Z2;
            UpdateDisplay();
        }

        private void btn_SetPt1Pos_Click(object sender, EventArgs e)
        {
            TPos3 Old1 = new TPos3(CmdLine.X[0], CmdLine.Y[0], CmdLine.Z[0]);
            TPos3 Old2 = new TPos3(CmdLine.X[1], CmdLine.Y[1], CmdLine.Z[1]);

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            double Z = TaskGantry.GZPos();
            CmdLine.X[0] = X;
            CmdLine.Y[0] = Y;
            CmdLine.Z[0] = Z;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                double X2 = TaskGantry.GX2Pos();
                double Y2 = TaskGantry.GY2Pos();
                double Z2 = TaskGantry.GZ2Pos();
                CmdLine.X[1] = X2;
                CmdLine.Y[1] = Y2;
                CmdLine.Z[1] = Z2;
            }
            TPos3 New1 = new TPos3(CmdLine.X[0], CmdLine.Y[0], CmdLine.Z[0]);
            TPos3 New2 = new TPos3(CmdLine.X[1], CmdLine.Y[1], CmdLine.Z[1]);
            Log.OnSet(CmdName + " Position XYZ1", Old1, New1);
            Log.OnSet(CmdName + " Position XYZ2", Old2, New2);

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            UpdateDisplay();
        }

        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            double X = CmdLine.X[0];
            double Y = CmdLine.Y[0];
            double Z = CmdLine.Z[0];

            double X2 = CmdLine.X[1];
            double Y2 = CmdLine.Y[1];
            double Z2 = CmdLine.Z[1];
            
            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXYX2Y2()) return;

            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.MoveAbsGX2Y2(X2, Y2)) return;
                if (!TaskGantry.WaitGX2Y2()) return;
            }
            if (!TaskGantry.WaitGXY()) return;

                DialogResult dr = MessageBox.Show("Move Z to Purge Dot Position?.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    return;
                }
                if (!TaskGantry.SetMotionParamGZZ2()) return;
                if (!TaskDisp.TaskMoveAbsGZZ2(Z + TaskDisp.Head_Ofst[0].Z, Z2 + TaskDisp.Head_Ofst[1].Z)) return;
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            #region assign position
            double dx = 0;//CmdList.Line[Line].PosX[0];
            double dy = 0;//CmdList.Line[Line].PosY[0];
            double dz = 0;//CmdList.Line[Line].PosZ[0];

            double dx2 = 0;//dx + CmdList.Line[Line].PosX[1] - TaskDisp.Head2_DefPos.X + TaskDisp.Head2_DefDistX;
            double dy2 = 0;//dy + CmdList.Line[Line].PosY[2] - TaskDisp.Head2_DefPos.Y;
            double dz2 = 0;//CmdList.Line[Line].PosZ[2];
            if (CmdLine.IPara[4] == 0)//Position = Auto
            {
                dx = TaskDisp.Needle_Purge_Pos[0].X;
                dy = TaskDisp.Needle_Purge_Pos[0].Y;
                dz = TaskDisp.Needle_Purge_Pos[0].Z;

                dx2 = TaskDisp.Needle_Purge_Pos[1].X;
                dy2 = TaskDisp.Needle_Purge_Pos[1].Y;
                dz2 = TaskDisp.Needle_Purge_Pos[1].Z;
            }
            else//Position = Manual
            {
                dx = CmdLine.X[0];
                dy = CmdLine.Y[0];
                dz = CmdLine.Z[0];

                dx2 = CmdLine.X[1];
                dy2 = CmdLine.Y[1];
                dz2 = CmdLine.Z[1];
            }
            dz = dz + TaskDisp.Head_Ofst[0].Z;
            dz2 = dz2 + TaskDisp.Head_Ofst[1].Z;
            //double ZDiff = (TaskDisp.Head_ZSensor_RefPosZ[1] + TaskDisp.Head_Ofst[1].Z - (TaskDisp.Head_ZSensor_RefPosZ[0] + TaskDisp.Head_Ofst[0].Z));
            //double dz2 = dz + ZDiff;
            #endregion

            EHeadNo HeadNo = (EHeadNo)CmdLine.ID;
            #region Force Head Operation
            if (DispProg.b_ForceHead1)
            {
                if (HeadNo == EHeadNo.Head2)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.PROGRAM_HEAD_ERROR);
                    return;
                }
                HeadNo = EHeadNo.Head1;
            }
            if (DispProg.b_ForceHead2)
            {
                if (GDefine.HeadConfig != GDefine.EHeadConfig.Dual || DispProg.Head_Operation == TaskDisp.EHeadOperation.Single)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.PROGRAM_HEAD_ERROR);
                    return;
                }
                HeadNo = EHeadNo.Head2;
            }
            #endregion

            try
            {
                DispProg.Script[0].DoPurgeDot(CmdLine, HeadNo, (ERunMode)ERunMode.Normal, dx, dy, dz, dx2, dy2, dz2);
            }
            catch {};
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            //frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName);
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            //frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void frm_DispCore_DispProg_PurgeDot_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void btn_Cond_Click(object sender, EventArgs e)
        {
            frm_DispProg_Condition frm = new frm_DispProg_Condition();
            frm.CmdLine.Copy(CmdLine);
            frm.ShowDialog();
            CmdLine.Copy(frm.CmdLine);

            UpdateDisplay();
        }
    }
}
