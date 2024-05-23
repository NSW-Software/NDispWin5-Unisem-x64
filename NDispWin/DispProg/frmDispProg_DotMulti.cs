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
    internal partial class frm_DispCore_DispProg_DotMulti : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_DotMulti()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            cbAddNew.Visible = TaskDisp.Preference != TaskDisp.EPreference.Unisem;
            btnAddNew.Visible = TaskDisp.Preference != TaskDisp.EPreference.Unisem;
        }

        int SelectDotNo = 0;
        int iEngrLevel = 3;
        private void UpdateDisplay()
        {
            if (CmdLine.ID > Enum.GetNames(typeof(EHeadNo)).Length) CmdLine.ID = 1;
            lbl_HeadNo.Text = CmdLine.ID.ToString();

            int C = 0; int R = 0;
            DispProg.rt_Layouts[0].UnitNoGetRC(DispProg.RunTime.UIndex, ref C, ref R);
            lbl_UnitRC.Text = "C,R = " + C.ToString() + "," + R.ToString();
            lbl_UnitRC.Visible = TaskDisp.Option_EnableRealTimeFineTune && C > 0 && R > 0;

            lbl_ModelNo.Text = CmdLine.IPara[0].ToString();


            if (CmdLine.IPara[1] >= Enum.GetNames(typeof(EDotMode)).Length) CmdLine.IPara[1] = 0;
            lbl_Mode.Text = Enum.GetName(typeof(EDotMode), CmdLine.IPara[1]);

            lbl_DotCount.Text = CmdLine.IPara[5].ToString();

            CmdLine.IPara[6] = 0;
            for (int d = 0; d < CmdLine.IPara[5]; d++)
            {
                CmdLine.IPara[6] = CmdLine.IPara[6] + (int)CmdLine.U[d];
            }
            lbl_DispCount.Text = CmdLine.IPara[6].ToString();

            if (SelectDotNo >= 0)
            {
                lbl_DotNo.Text = (SelectDotNo + 1).ToString();
                gbox_Pos.Text = "Dot " + (SelectDotNo + 1).ToString();

                lbl_X.Text = CmdLine.X[SelectDotNo].ToString("f3");
                lbl_Y.Text = CmdLine.Y[SelectDotNo].ToString("f3");
                lbl_Disp.Text = CmdLine.U[SelectDotNo].ToString("f0");

                string s = "(" +
                (CmdLine.A[SelectDotNo] - CmdLine.DPara[0]).ToString("f3") + "~" + (CmdLine.A[SelectDotNo] + CmdLine.DPara[0]).ToString("f3") +
                ", " +
                (CmdLine.B[SelectDotNo] - CmdLine.DPara[1]).ToString("f3") + "~" + (CmdLine.B[SelectDotNo] + CmdLine.DPara[1]).ToString("f3") +
                ")";
                if (CmdLine.DPara[0] > 0 || CmdLine.DPara[1] > 0)
                {
                    lblPosRanges.Text = s;
                }
            }

            lblAdjTolX.Text = CmdLine.DPara[0].ToString("f3");
            lblAdjTolY.Text = CmdLine.DPara[1].ToString("f3");
            lblAdjTolX.Enabled = NUtils.UserAcc.Active.GroupID >= iEngrLevel;
            lblAdjTolY.Enabled = NUtils.UserAcc.Active.GroupID >= iEngrLevel;
            lblPosRanges.Visible = CmdLine.DPara[0] > 0 || CmdLine.DPara[1] > 0;
            lbl_Dispense.Text = (CmdLine.IPara[2] > 0).ToString();


            lbox_PosHeader.Items.Clear();
            lbox_PosHeader.Items.Add("No" + (char)9 + "X" + (char)9 + "Y" + (char)9 + "Disp");

            lbox_Pos.Items.Clear();
            for (int i = 0; i < CmdLine.IPara[5]; i++)
            {
                lbox_Pos.Items.Add((i + 1).ToString() + (char)9 + CmdLine.X[i].ToString("f3") + (char)9 + CmdLine.Y[i].ToString("f3") + (char)9 + CmdLine.U[i].ToString("f0"));
            }
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
            frm_DispCore_DispProg_ModelList frmModelList = new frm_DispCore_DispProg_ModelList();
            frmModelList.ShowDialog();
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
            double X = Math.Round(CmdLine.X[SelectDotNo], 3);

            if (CmdLine.DPara[0] > 0 || TaskDisp.Preference == TaskDisp.EPreference.Unisem)
            {
                if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
                    UC.AdjustExec(CmdName + ", X1", ref X, CmdLine.A[SelectDotNo] - CmdLine.DPara[0], CmdLine.A[SelectDotNo] + CmdLine.DPara[0]);
                else
                    UC.AdjustExec(CmdName + ", X1", ref X, -1000, 1000);
            }
            else
                UC.AdjustExec(CmdName + ", X1", ref X, -1000, 1000);

            CmdLine.X[SelectDotNo] = X;
            if (NUtils.UserAcc.Active.GroupID >= iEngrLevel)
                CmdLine.A[SelectDotNo] = CmdLine.X[SelectDotNo];

            UpdateDisplay();
            lbox_Pos.SetSelected(SelectDotNo, true);
        }

        private void lbl_Y1_Click(object sender, EventArgs e)
        {
            double Y = Math.Round(CmdLine.Y[SelectDotNo], 3);

            if (CmdLine.DPara[1] > 0 || TaskDisp.Preference == TaskDisp.EPreference.Unisem)
            {
                if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
                    UC.AdjustExec(CmdName + ", Y1", ref Y, CmdLine.B[SelectDotNo] - CmdLine.DPara[1], CmdLine.B[SelectDotNo] + CmdLine.DPara[1]);
                else
                    UC.AdjustExec(CmdName + ", Y1", ref Y, -1000, 1000);
            }
            else
                UC.AdjustExec(CmdName + ", Y1", ref Y, -1000, 1000);

            CmdLine.Y[SelectDotNo] = Y;
            if (NUtils.UserAcc.Active.GroupID >= iEngrLevel)
                CmdLine.B[SelectDotNo] = CmdLine.Y[SelectDotNo];

            UpdateDisplay();
            lbox_Pos.SetSelected(SelectDotNo, true);
        }
        private void btn_SetXY_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckInDispenseArea()) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref X, ref Y);

            //if (NUtils.UserAcc.Active.GroupID < iEngrLevel && CmdLine.DPara[0] > 0)
            if (CmdLine.DPara[0] > 0 || TaskDisp.Preference == TaskDisp.EPreference.Unisem)
            {
                if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
                {
                    double dX = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
                    if (dX < CmdLine.A[SelectDotNo] - CmdLine.DPara[0] || dX > CmdLine.A[SelectDotNo] + CmdLine.DPara[0])
                    {
                        string s = "X Position is out of allowable Setup Limit.";
                        Msg MsgBox = new Msg();
                        MsgBox.Show(s, EMcState.Notice, EMsgBtn.smbOK, false);
                        Log.AddToLog(s);
                        return;
                    }
                }
            }

            if (CmdLine.DPara[1] > 0 || TaskDisp.Preference == TaskDisp.EPreference.Unisem)
            {
                if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
                {
                    double dY = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
                    if (dY < CmdLine.B[SelectDotNo] - CmdLine.DPara[1] || dY > CmdLine.B[SelectDotNo] + CmdLine.DPara[1])
                    {
                        string s = "Y Position is out of allowable Setup Limit.";
                        Msg MsgBox = new Msg();
                        MsgBox.Show(s, EMcState.Notice, EMsgBtn.smbOK, false);
                        Log.AddToLog(s);
                        return;
                    }
                }
            }

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[SelectDotNo], CmdLine.Y[SelectDotNo]);
            CmdLine.X[SelectDotNo] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[SelectDotNo] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[SelectDotNo], CmdLine.Y[SelectDotNo]);
            Log.OnSet(CmdName + ", Dot " + SelectDotNo.ToString() + " Position", Old, New);

            if (NUtils.UserAcc.Active.GroupID >= iEngrLevel)
                CmdLine.A[SelectDotNo] = CmdLine.X[SelectDotNo];

            if (NUtils.UserAcc.Active.GroupID >= iEngrLevel)
                CmdLine.B[SelectDotNo] = CmdLine.Y[SelectDotNo];

            UpdateDisplay();
        }
        private void btn_GotoXY_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[SelectDotNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[SelectDotNo];
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

            UpdateDisplay();

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_EditXY_Click(object sender, EventArgs e)
        {
            frm_DispCore_EditXY frm = new frm_DispCore_EditXY();

            frm.ParamName = "Dot " + SelectDotNo.ToString() + " XY";
            frm.ValueX = CmdLine.X[SelectDotNo];
            frm.ValueY = CmdLine.Y[SelectDotNo];

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (CmdLine.DPara[0] > 0 || TaskDisp.Preference == TaskDisp.EPreference.Unisem)
                {
                    if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
                    {
                        if (frm.ValueX < CmdLine.A[SelectDotNo] - CmdLine.DPara[0] || frm.ValueX > CmdLine.A[SelectDotNo] + CmdLine.DPara[0])
                        {
                            string s = "X Position is out of allowable Setup Limit.";
                            Msg MsgBox = new Msg();
                            MsgBox.Show(s, EMcState.Notice, EMsgBtn.smbOK, false);
                            Log.AddToLog(s);
                            return;
                        }
                    }
                }

                if (CmdLine.DPara[1] > 0 || TaskDisp.Preference == TaskDisp.EPreference.Unisem)
                {
                    if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
                    {
                        if (frm.ValueY < CmdLine.B[SelectDotNo] - CmdLine.DPara[1] || frm.ValueY > CmdLine.B[SelectDotNo] + CmdLine.DPara[1])
                        {
                            string s = "Y Position is out of allowable Setup Limit.";
                            Msg MsgBox = new Msg();
                            MsgBox.Show(s, EMcState.Notice, EMsgBtn.smbOK, false);
                            Log.AddToLog(s);
                            return;
                        }
                    }
                }

                CmdLine.X[SelectDotNo] = frm.ValueX;
                CmdLine.Y[SelectDotNo] = frm.ValueY;
            }

            UpdateDisplay();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (SelectDotNo >= CmdLine.IPara[5] - 1) return;
            SelectDotNo++;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[SelectDotNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[SelectDotNo];
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

            UpdateDisplay();

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (SelectDotNo <= 0) return;
            SelectDotNo--;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[SelectDotNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[SelectDotNo];
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);

            UpdateDisplay();

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_Disp_Click(object sender, EventArgs e)
        {
            int i = (int)CmdLine.U[SelectDotNo];
            if (UC.AdjustExec(CmdName + ", Dot" + SelectDotNo.ToString() + " Disp", ref i, 0, 1000))
                CmdLine.U[SelectDotNo] = (double)i;

            //CmdLine.IPara[6] = 0;
            //for (int d = 0; d < CmdLine.IPara[5]; d++)
            //{
            //    CmdLine.IPara[6] = CmdLine.IPara[6] + (int)CmdLine.U[d];
            //}

            UpdateDisplay();
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
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];
            if (!TaskGantry.CheckInDispenseArea(new PointD(X, Y))) return;

            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            Log.OnAction("OK", CmdName); 
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Log.OnAction("Cancel", CmdName); 
            Close();
        }

        private void lbl_DotCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Dot Count", ref CmdLine.IPara[5], 1, 100);

            if (SelectDotNo > CmdLine.IPara[5])
                SelectDotNo = CmdLine.IPara[5];
            
            UpdateDisplay();
        }

        private void lbl_DotNo_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[5] < 1) return;

            int i = SelectDotNo + 1;
            UC.AdjustExec(CmdName + ", Dot No", ref i, 1, CmdLine.IPara[5]);
            SelectDotNo = i - 1;
            UpdateDisplay();
        }

        private void lbox_Pos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frm_DispCore_DispProg_DotMulti_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void lbox_Pos_Click(object sender, EventArgs e)
        {
            if (lbox_Pos.SelectedIndex < 0) return;

            SelectDotNo = lbox_Pos.SelectedIndex;

            UpdateDisplay();

            lbox_Pos.SetSelected(SelectDotNo, true);
        }

        private void btn_MoveUp_Click(object sender, EventArgs e)
        {
            if (SelectDotNo > 0 && SelectDotNo <= CmdLine.IPara[5])
            {
                double X = 0;
                double Y = 0;
                double U = 0;

                X = CmdLine.X[SelectDotNo - 1];
                Y = CmdLine.Y[SelectDotNo - 1];
                U = CmdLine.U[SelectDotNo - 1];

                CmdLine.X[SelectDotNo - 1] = CmdLine.X[SelectDotNo];
                CmdLine.Y[SelectDotNo - 1] = CmdLine.Y[SelectDotNo];
                CmdLine.U[SelectDotNo - 1] = CmdLine.U[SelectDotNo];

                CmdLine.X[SelectDotNo] = X;
                CmdLine.Y[SelectDotNo] = Y;
                CmdLine.U[SelectDotNo] = U;

                SelectDotNo--;

                UpdateDisplay();

                lbox_Pos.SetSelected(SelectDotNo, true);
            }
        }
        private void btn_MoveDn_Click(object sender, EventArgs e)
        {
            if ( SelectDotNo >= 0 && SelectDotNo < CmdLine.IPara[5] - 1)
            {
                double X = 0;
                double Y = 0;
                double U = 0;

                X = CmdLine.X[SelectDotNo + 1];
                Y = CmdLine.Y[SelectDotNo + 1];
                U = CmdLine.U[SelectDotNo + 1];

                CmdLine.X[SelectDotNo + 1] = CmdLine.X[SelectDotNo];
                CmdLine.Y[SelectDotNo + 1] = CmdLine.Y[SelectDotNo];
                CmdLine.U[SelectDotNo + 1] = CmdLine.U[SelectDotNo];

                CmdLine.X[SelectDotNo] = X;
                CmdLine.Y[SelectDotNo] = Y;
                CmdLine.U[SelectDotNo] = U;

                SelectDotNo++;

                UpdateDisplay();

                lbox_Pos.SetSelected(SelectDotNo, true);
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (SelectDotNo >= 0 && SelectDotNo <= CmdLine.IPara[5])
            {
                if (MessageBox.Show("Delete Dot " + (SelectDotNo + 1).ToString() + "?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;

                for (int i = SelectDotNo; i < CmdLine.IPara[5]; i++)
                {
                    double X = 0;
                    double Y = 0;
                    double U = 0;

                    X = CmdLine.X[i + 1];
                    Y = CmdLine.Y[i + 1];
                    U = CmdLine.U[i + 1];

                    CmdLine.X[i + 1] = CmdLine.X[i];
                    CmdLine.Y[i + 1] = CmdLine.Y[i];
                    CmdLine.U[i + 1] = CmdLine.U[i];

                    CmdLine.X[i] = X;
                    CmdLine.Y[i] = Y;
                    CmdLine.U[i] = U;

                }
                CmdLine.IPara[5]--;
                if (SelectDotNo >= CmdLine.IPara[5]) SelectDotNo--;

                UpdateDisplay();

                if (CmdLine.IPara[5] > 0) lbox_Pos.SetSelected(SelectDotNo, true);
            }
        }

        private void btn_OfstAll_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[5] == 0) return;

            frm_DispCore_EditXY frm = new frm_DispCore_EditXY();
            frm.ParamName = "OfstAll XY";
            if (frm.ShowDialog() == DialogResult.Cancel) return;

            double OfstX = frm.OfstX;
            double OfstY = frm.OfstY;

            if (CmdLine.DPara[0] > 0 || TaskDisp.Preference == TaskDisp.EPreference.Unisem)
                if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
                {
                    for (int i = 0; i < CmdLine.IPara[5]; i++)
                    {
                        double dX = CmdLine.X[i] + OfstX;
                        if (dX < CmdLine.A[i] - CmdLine.DPara[0] || dX > CmdLine.A[i] + CmdLine.DPara[0])
                        {
                            string s = "X Position is out of allowable Setup Limit.";
                            Msg MsgBox = new Msg();
                            MsgBox.Show(s, EMcState.Notice, EMsgBtn.smbOK, false);
                            Log.AddToLog(s);
                            return;
                        }
                    }
                }

            if (CmdLine.DPara[1] > 0 || TaskDisp.Preference == TaskDisp.EPreference.Unisem)
                if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
                {
                    for (int i = 0; i < CmdLine.IPara[5]; i++)
                    {
                        double dY = CmdLine.Y[i] + OfstY;
                        if (dY < CmdLine.B[i] - CmdLine.DPara[1] || dY > CmdLine.B[i] + CmdLine.DPara[1])
                        {
                            string s = "Y Position is out of allowable Setup Limit.";
                            Msg MsgBox = new Msg();
                            MsgBox.Show(s, EMcState.Notice, EMsgBtn.smbOK, false) ;
                            Log.AddToLog(s);
                            return;
                        }
                    }
                }

            Log.OnAction("Update", CmdName + ", Offset All", "0,0", OfstX.ToString() + "," + OfstY.ToString());

            for (int i = 0; i < CmdLine.IPara[5]; i++)
            {
                CmdLine.X[i] = CmdLine.X[i] + OfstX;
                CmdLine.Y[i] = CmdLine.Y[i] + OfstY;
            }

            if (NUtils.UserAcc.Active.GroupID >= iEngrLevel)
                for (int i = 0; i < CmdLine.IPara[5]; i++)
                {
                    CmdLine.A[i] = CmdLine.X[i];
                    CmdLine.B[i] = CmdLine.Y[i];
                }

            UpdateDisplay();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("For postion with Dot Count > 1, interdot interval is Model.StartDelay + Model.EndDelay.");
        }

        private void lblAdjTolX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Adjust Tol X", ref CmdLine.DPara[0], 0, 10);

            for (int i = 0; i < CmdLine.IPara[5]; i++)
            {
                CmdLine.A[i] = CmdLine.X[i];
                CmdLine.B[i] = CmdLine.Y[i];
            }

            UpdateDisplay();
        }

        private void lblAdjTolY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Adjust Tol Y", ref CmdLine.DPara[1], 0, 10);

            for (int i = 0; i < CmdLine.IPara[5]; i++)
            {
                CmdLine.A[i] = CmdLine.X[i];
                CmdLine.B[i] = CmdLine.Y[i];
            }

            UpdateDisplay();
        }

        private void cbAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = (sender as CheckBox).Checked;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[5]++;
            SelectDotNo = CmdLine.IPara[5] - 1;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref X, ref Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[SelectDotNo], CmdLine.Y[SelectDotNo]);
            CmdLine.X[SelectDotNo] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[SelectDotNo] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            if (SelectDotNo > 1) CmdLine.U[SelectDotNo] = CmdLine.U[SelectDotNo - 1];

            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[SelectDotNo], CmdLine.Y[SelectDotNo]);
            Log.OnSet(CmdName + ", Add Dot " + SelectDotNo.ToString() + " Position", Old, New);

            UpdateDisplay();
        }
    }
}
