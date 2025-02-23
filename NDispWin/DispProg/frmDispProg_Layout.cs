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
    internal partial class frm_DispCore_DispProg_Layout : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);
        TLayout LocalLayout = new TLayout();

        public frm_DispCore_DispProg_Layout()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        int UnitNo = 0;
        int CColNo = 0;
        int CRowNo = 0;
        private void UpdateDisplay()
        {
            lbl_LayoutID.Text = CmdLine.ID.ToString();
            lbl_Zone.Text = CmdLine.IPara[10].ToString();
            #region Path
            switch (CmdLine.IPara[1])
            {
                case 1:
                    UI_Utils.ButtonDrawPath(ref btn_Path, UI_Utils.Path.YFZ);
                    break;
                case 2:
                    UI_Utils.ButtonDrawPath(ref btn_Path, UI_Utils.Path.XFU);
                    break;
                case 3:
                    UI_Utils.ButtonDrawPath(ref btn_Path, UI_Utils.Path.YFU);
                    break;
                case 0:
                default:
                    UI_Utils.ButtonDrawPath(ref btn_Path, UI_Utils.Path.XFZ);
                    break;
            }
            #endregion

            #region Basic
            lbl_b_UColCount.Text = CmdLine.Index[2].ToString();
            lbl_b_URowCount.Text = CmdLine.Index[4].ToString();
            lbl_b_CColCount.Text = CmdLine.Index[6].ToString();
            lbl_b_CRowCount.Text = CmdLine.Index[8].ToString();
            #endregion

            #region Advance
            lbl_StartX.Text = CmdLine.DPara[0].ToString("f3");
            lbl_StartY.Text = CmdLine.DPara[1].ToString("f3");
            lbl_UnitLayout.Text = Enum.GetName(typeof(TLayout.EULayoutType), CmdLine.IPara[3]);
            lbl_CColLayout.Text = Enum.GetName(typeof(TLayout.ECLayoutType), CmdLine.IPara[6]);
            lbl_CRowLayout.Text = Enum.GetName(typeof(TLayout.ECLayoutType), CmdLine.IPara[7]);

            lbl_UColCount.Text = CmdLine.Index[2].ToString();
            lbl_URowCount.Text = CmdLine.Index[4].ToString();
            lbl_UColPX.Text = CmdLine.DPara[2].ToString("f3");
            lbl_UColPY.Text = CmdLine.DPara[3].ToString("f3");
            lbl_URowPX.Text = CmdLine.DPara[4].ToString("f3");
            lbl_URowPY.Text = CmdLine.DPara[5].ToString("f3");

            lbl_UnitCount.Text = CmdLine.Index[0].ToString();
            lbl_UnitDX.Text = CmdLine.Index[UnitNo].ToString();
            lbl_UnitDY.Text = CmdLine.Index[UnitNo].ToString();

            lbl_CColCount.Text = CmdLine.Index[6].ToString();
            lbl_CRowCount.Text = CmdLine.Index[8].ToString();
            lbl_CColPX.Text = CmdLine.DPara[6].ToString("f3");
            lbl_CColPY.Text = CmdLine.DPara[7].ToString("f3");
            lbl_CRowPX.Text = CmdLine.DPara[8].ToString("f3");
            lbl_CRowPY.Text = CmdLine.DPara[9].ToString("f3");

            lbl_CColCount2.Text = CmdLine.Index[6].ToString();
            lbl_CRowCount2.Text = CmdLine.Index[8].ToString();
            lbl_CColNo.Text = CColNo.ToString();
            lbl_CRowNo.Text = CRowNo.ToString();
            lbl_CColDX.Text = CmdLine.A[CColNo].ToString("f3");
            lbl_CColDY.Text = CmdLine.B[CColNo].ToString("f3");
            lbl_CRowDX.Text = CmdLine.C[CRowNo].ToString("f3");
            lbl_CRowDY.Text = CmdLine.D[CRowNo].ToString("f3");

            gbox_ULayoutMatrix.Visible = (CmdLine.IPara[3] == 0);
            gbox_ULayoutRandom.Visible = (CmdLine.IPara[3] == 1);

            gbox_CLayoutMatrix.Visible = (CmdLine.IPara[6] == 0 || CmdLine.IPara[7] == 0);
            gbox_CLayoutMPitch.Visible = (CmdLine.IPara[6] == 1 || CmdLine.IPara[7] == 1);

            pnl_CColMatrixLayout.Visible = (CmdLine.IPara[6] == 0);
            pnl_CColMPitchLayout.Visible = (CmdLine.IPara[6] == 1);
            pnl_CRowMatrixLayout.Visible = (CmdLine.IPara[7] == 0);
            pnl_CRowMPitchLayout.Visible = (CmdLine.IPara[7] == 1);
            #endregion

            UI_Utils.DrawSelected(lbl_MoveTo, MouseMode == EMouseMode.MoveTo);
            UI_Utils.DrawSelected(lbl_PreMap, MouseMode == EMouseMode.PreMap);

            lbl_ClearAll.Visible = (MouseMode == EMouseMode.PreMap);
            lbl_SetAll.Visible = (MouseMode == EMouseMode.PreMap);

            label8.Text = SelectedPreMapIndex.ToString();

            lbl_EnableWafer.Text = (CmdLine.IPara[11] > 0).ToString();

            if (LocalLayout.EnableWafer)
            {
                if (tabControl1.TabPages.Contains(tpage_Basic)) tabControl1.TabPages.Remove(tpage_Basic);
                if (tabControl1.TabPages.Contains(tpage_Advance)) tabControl1.TabPages.Remove(tpage_Advance);
                if (!tabControl1.TabPages.Contains(tpage_Wafer)) tabControl1.TabPages.Add(tpage_Wafer);
            }
            else
            {
                if (!tabControl1.TabPages.Contains(tpage_Basic)) tabControl1.TabPages.Add(tpage_Basic);
                if (!tabControl1.TabPages.Contains(tpage_Advance)) tabControl1.TabPages.Add(tpage_Advance);
                if (tabControl1.TabPages.Contains(tpage_Wafer)) tabControl1.TabPages.Remove(tpage_Wafer);
            }

            lbl_UColCount3.Text = CmdLine.Index[2].ToString();
            lbl_URowCount3.Text = CmdLine.Index[4].ToString();

            lblTLPos.Text = String.Format("{0:f3}, {1:f3}", CmdLine.DPara[0], CmdLine.DPara[1]);
            lblUnitPitch.Text = String.Format("{0:f4}, {1:f4}", CmdLine.DPara[2], CmdLine.DPara[4]);

            lbl_TLX.Text = CmdLine.IPara[12].ToString();
            lbl_TLY.Text = CmdLine.IPara[13].ToString();
            lbl_TRX.Text = CmdLine.IPara[14].ToString();
            lbl_TRY.Text = CmdLine.IPara[13].ToString();
            lbl_BLX.Text = CmdLine.IPara[12].ToString();
            lbl_BLY.Text = CmdLine.IPara[17].ToString();
            label15.Text = CmdLine.IPara[14].ToString();
            label32.Text = CmdLine.IPara[17].ToString();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_Layout_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
                        
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            #region Para Check
            CmdLine.Index[2] = Math.Max(1, CmdLine.Index[2]);
            CmdLine.Index[4] = Math.Max(1, CmdLine.Index[4]);
            CmdLine.Index[6] = Math.Max(1, CmdLine.Index[6]);
            CmdLine.Index[8] = Math.Max(1, CmdLine.Index[8]);

            CmdLine.IPara[10] = Math.Max(1, CmdLine.IPara[10]);

            CmdLine.X[0] = 0;
            CmdLine.Y[0] = 0;
            CmdLine.Z[0] = 0;
            CmdLine.U[0] = 0;
            CmdLine.A[0] = 0;
            CmdLine.B[0] = 0;
            CmdLine.C[0] = 0;
            CmdLine.D[0] = 0;

            #endregion

            LocalLayout = new TLayout(CmdLine);

            SetMapOrigin(LocalLayout.MapOrigin);
            
            UpdateDisplay();

            pbox_Layout.Size = pnl_Layout.Size;
            UpdateUnitLocation();

            SelectedPreMap = DispProg.Map.PreMap[0];
            pbox_Layout.Refresh();


            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
       }
        private void frm_DispCore_DispProg_Layout_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        //int i_MapOrigin = 0;
        //private void SetMapOrigin(int Start)//0-left else right
        private void SetMapOrigin(TLayout.EMapOrigin Start)//0-left else right
        {
            if (Start == TLayout.EMapOrigin.Left)
            {
                lbl_b_U00.Left = 114;
                lbl_b_URowCount.Left = 114;
                lbl_b_CRowCount.Left = 114;

                btn_b_GotoStartXY.Left = 57;
                btn_b_GotoURowLast.Left = 57;
                btn_b_GotoCRowLast.Left = 57;

                btn_b_SetStartXY.Left = 17;
                btn_b_SetURowLast.Left = 17;
                btn_b_SetCRowLast.Left = 17;

                lbl_b_UColCount.Left = 172;
                btn_b_SetUColLast.Left = 172;
                btn_b_GotoUColLast.Left = 212;

                lbl_b_CColCount.Left = 432;
                btn_b_SetCColLast.Left = 432;
                btn_b_GotoCColLast.Left = 472;
            }
            else
            {
                lbl_b_U00.Left = 493;
                lbl_b_URowCount.Left = 493;
                lbl_b_CRowCount.Left = 493;

                btn_b_GotoStartXY.Left = 563;
                btn_b_GotoURowLast.Left = 563;
                btn_b_GotoCRowLast.Left = 563;

                btn_b_SetStartXY.Left = 523;
                btn_b_SetURowLast.Left = 523;
                btn_b_SetCRowLast.Left = 523;

                lbl_b_UColCount.Left = 432;
                btn_b_SetUColLast.Left = 432;
                btn_b_GotoUColLast.Left = 472;
                
                lbl_b_CColCount.Left = 172;
                btn_b_SetCColLast.Left = 172;
                btn_b_GotoCColLast.Left = 212;
            }
        }
        
        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
           
            DispProg.rt_Layouts[LocalLayout.ID] = new TLayout(CmdLine);
            DispProg.Map.CurrMap[LocalLayout.ID].Bin = (EMapBin[])DispProg.Map.PreMap[LocalLayout.ID].Bin.Clone();

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

        private void lbl_LayoutID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + " LayoutID", ref CmdLine.ID, 0, DispProg.MAX_IDS);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }

        private void btn_Path_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[1] >= 3) CmdLine.IPara[1] = 0;
            else
                CmdLine.IPara[1]++;
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();

            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }
        private void lbl_Zone_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + " Zone", ref CmdLine.IPara[10], 1, 2);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();

            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }

        private void SetStartXY()
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[0], CmdLine.DPara[1]);
            CmdLine.DPara[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.DPara[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[0], CmdLine.DPara[1]);
            Log.OnSet(CmdName + " StartXY", Old, New);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void SetUColPitch()
        {
            if (CmdLine.Index[2] <= 1) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[2], CmdLine.DPara[3]);
            CmdLine.DPara[2] = (X - CmdLine.DPara[0]) / (CmdLine.Index[2] - 1);
            CmdLine.DPara[3] = (Y - CmdLine.DPara[1]) / (CmdLine.Index[2] - 1);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[2], CmdLine.DPara[3]);
            Log.OnSet(CmdName + " UColPitch", Old, New);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void SetURowPitch()
        {
            if (CmdLine.Index[4] <= 1) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[4], CmdLine.DPara[5]);
            CmdLine.DPara[4] = (X - CmdLine.DPara[0]) / (CmdLine.Index[4] - 1);
            CmdLine.DPara[5] = (Y - CmdLine.DPara[1]) / (CmdLine.Index[4] - 1);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[4], CmdLine.DPara[5]);
            Log.OnSet(CmdName + " URowPitch", Old, New);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void SetCColMatrixPitch()
        {
            if (CmdLine.Index[6] <= 1) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[6], CmdLine.DPara[7]);
            CmdLine.DPara[6] = (X - CmdLine.DPara[0]) / (CmdLine.Index[6] - 1);
            CmdLine.DPara[7] = (Y - CmdLine.DPara[1]) / (CmdLine.Index[6] - 1);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[6], CmdLine.DPara[7]);
            Log.OnSet(CmdName + " CColMatrixPitch", Old, New);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void SetCRowMatrixPitch()
        {
            if (CmdLine.Index[8] <= 1) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[8], CmdLine.DPara[9]);
            CmdLine.DPara[8] = (X - CmdLine.DPara[0]) / (CmdLine.Index[8] - 1);
            CmdLine.DPara[9] = (Y - CmdLine.DPara[1]) / (CmdLine.Index[8] - 1);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[8], CmdLine.DPara[9]);
            Log.OnSet(CmdName + " CRowMatrixPitch", Old, New);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void SetCColMultiPitch(int CColNo)
        {
            if (CColNo == 0 || CColNo >= LocalLayout.CColCount) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.A[CColNo], CmdLine.B[CColNo]);
            CmdLine.A[CColNo] = X - CmdLine.DPara[0];
            CmdLine.B[CColNo] = Y - CmdLine.DPara[1];
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.A[CColNo], CmdLine.B[CColNo]);
            Log.OnSet(CmdName + " CColMultiPitch", Old, New);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void SetCRowMultiPitch(int CRowNo)
        {
            if (CRowNo == 0 || CRowNo >= LocalLayout.CRowCount) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.C[CColNo], CmdLine.D[CColNo]);
            CmdLine.C[CRowNo] = X - CmdLine.DPara[0];
            CmdLine.D[CRowNo] = Y - CmdLine.DPara[1];
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.C[CColNo], CmdLine.D[CColNo]);
            Log.OnSet(CmdName + " CColMultiPitch", Old, New);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        #region Advance - Header
        private void lbl_StartX_Click(object sender, EventArgs e)
        {

        }
        private void lbl_StartY_Click(object sender, EventArgs e)
        {

        }
        private void btn_SetStartXY_Click(object sender, EventArgs e)
        {
            SetStartXY();
        }
        private void btn_GotoStartXY_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + LocalLayout.StartX;// CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + LocalLayout.StartY;// CmdLine.DPara[1];

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_UnitLayout_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[3] > 0) CmdLine.IPara[3] = 0;
            else
                CmdLine.IPara[3]++;

            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void lbl_CColLayout_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[6] > 0) CmdLine.IPara[6] = 0;
            else
                CmdLine.IPara[6]++;

            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            pbox_Layout.Refresh();
        }
        private void lbl_CRowLayout_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[7] > 0) CmdLine.IPara[7] = 0;
            else
                CmdLine.IPara[7]++;

            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            pbox_Layout.Refresh();
        }
        private void lbl_UColCount_Click(object sender, EventArgs e)
        {
            DispProg.TLine tCmdLine = new DispProg.TLine(CmdLine);

            if (!UC.AdjustExec(CmdName + ", Unit Col Count", ref tCmdLine.Index[2], 1, TLayout.MAX_RC)) return;

            try
            {
                TLayout tLayout = new TLayout(tCmdLine);
            }
            catch
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                return;
            }
            CmdLine.Copy(tCmdLine);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }
        private void lbl_URowCount_Click(object sender, EventArgs e)
        {
            DispProg.TLine tCmdLine = new DispProg.TLine(CmdLine);

            if (!UC.AdjustExec(CmdName + ", Unit Row Count", ref tCmdLine.Index[4], 1, TLayout.MAX_RC)) return;

            try
            {
                TLayout tLayout = new TLayout(tCmdLine);
            }
            catch
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                return;
            }
            CmdLine.Copy(tCmdLine);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }

        private void lbl_UColPX_Click(object sender, EventArgs e)
        {
             UC.AdjustExec("Layout, Unit Col Pitch X (mm)", ref CmdLine.DPara[2], -999, 999);
            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            pbox_Layout.Refresh();
            UpdateDisplay();
        }
        private void lbl_UColPY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Layout, Unit Col Pitch Y (mm)", ref CmdLine.DPara[3], -999, 999);
            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            pbox_Layout.Refresh();
            UpdateDisplay();
        }
        private void lbl_URowPX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Layout, Unit Row Pitch X (mm)", ref CmdLine.DPara[4], -999, 999);
            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            pbox_Layout.Refresh();
            UpdateDisplay();
        }
        private void lbl_URowPY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Layout, Unit Row Pitch Y (mm)", ref CmdLine.DPara[5], -999, 999);
            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            pbox_Layout.Refresh();
            UpdateDisplay();
        }
        private void btn_SetUColPitch_Click(object sender, EventArgs e)
        {
            SetUColPitch();
        }
        private void btn_GotoUColPitch_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
            X = X + (CmdLine.DPara[2] * (CmdLine.Index[2] - 1));
            Y = Y + (CmdLine.DPara[3] * (CmdLine.Index[2] - 1));

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_SetURowPitch_Click(object sender, EventArgs e)
        {
            SetURowPitch();
        }
        private void btn_GotoURowPitch_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
            X = X + (CmdLine.DPara[4] * (CmdLine.Index[4] - 1));
            Y = Y + (CmdLine.DPara[5] * (CmdLine.Index[4] - 1));

            if (!TaskDisp.TaskMoveGZUp()) return;

            try
            {
                if (!TaskGantry.SetMotionParamGXY()) return;
                if (!TaskGantry.MoveAbsGXY(X, Y)) return;
            }
            catch { };
        }
        #endregion

        private void GotoRandomUnitNo(int UnitNo)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];
            X = X + CmdLine.X[UnitNo];
            Y = Y + CmdLine.Y[UnitNo];

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        #region Advance - UnitLayoutRandom
        private void lbl_UnitCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Random Unit Count", ref CmdLine.Index[0], 1, 99);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();

            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }
        private void lbl_UnitNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Random Unit No", ref UnitNo, 1, 99);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void lbl_UnitDX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Random Dist X (mm)", ref CmdLine.X[UnitNo], -99, 99);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void lbl_UnitDY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Random Dist Y (mm)", ref CmdLine.Y[UnitNo], -99, 99);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void btn_GotoPrevUnitNo_Click(object sender, EventArgs e)
        {
            if (UnitNo > 0) UnitNo--;
            GotoRandomUnitNo(UnitNo);
        }
        private void btn_GotoUnitNo_Click(object sender, EventArgs e)
        {
            GotoRandomUnitNo(UnitNo);
        }
        private void btn_GotoNextUnitNo_Click(object sender, EventArgs e)
        {
            if (UnitNo < LocalLayout.UCount) UnitNo++;
            GotoRandomUnitNo(UnitNo);
        }
        private void btn_SetUnitNo_Click(object sender, EventArgs e)
        {
            if (UnitNo == 0 || UnitNo >= LocalLayout.UCount) return;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            X = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            Y = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            CmdLine.X[UnitNo] = X - CmdLine.X[0];
            CmdLine.Y[UnitNo] = Y - CmdLine.Y[0];

            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        #endregion

        #region Advance - ClstrLayoutMatrix
        private void lbl_CColCount_Click(object sender, EventArgs e)
        {
            DispProg.TLine tCmdLine = new DispProg.TLine(CmdLine);

            if (!UC.AdjustExec(CmdName + ", Cluster Col Count", ref tCmdLine.Index[6], 1, TLayout.MAX_RC)) return;
         
            try
            {
                TLayout tLayout = new TLayout(tCmdLine);
            }
            catch
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                return;
            }
            CmdLine.Copy(tCmdLine);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }
        private void lbl_CRowCount_Click(object sender, EventArgs e)
        {
            DispProg.TLine tCmdLine = new DispProg.TLine(CmdLine);

            if (!UC.AdjustExec(CmdName + ", Cluster Row Count", ref tCmdLine.Index[8], 1, TLayout.MAX_RC)) return;

            try
            {
                TLayout tLayout = new TLayout(tCmdLine);
            }
            catch
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                return;
            }
            CmdLine.Copy(tCmdLine);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }
        private void lbl_CColPX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Layout, Cluster Col Pitch X (mm)", ref CmdLine.DPara[6], -99, 99);
            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void lbl_CColPY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Layout, Cluster Col Pitch Y (mm)", ref CmdLine.DPara[7], -99, 99);
            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void lbl_CRowPX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Layout, Cluster Row Pitch X (mm)", ref CmdLine.DPara[8], -99, 99);
            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void lbl_CRowPY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Layout, Cluster Row Pitch Y (mm)", ref CmdLine.DPara[9], -99, 99);
            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void btn_SetCCol_Click(object sender, EventArgs e)
        {
            if (LocalLayout.CColLayoutType == TLayout.ECLayoutType.Matrix)
                SetCColMatrixPitch();

            if (LocalLayout.CColLayoutType == TLayout.ECLayoutType.MultiP)
            {
                int UnitNo = 0;
                LocalLayout.RCGetUnitNo(ref UnitNo, (LocalLayout.CColCount - 1) * LocalLayout.UColCount, 0);
                SetCColMultiPitch(UnitNo);
            }
        }
        private void btn_GotoCCol_Click(object sender, EventArgs e)
        {
            if (LocalLayout.CColLayoutType == TLayout.ECLayoutType.Matrix)
            {
                double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
                double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
                X = X + (CmdLine.DPara[6] * (CmdLine.Index[6] - 1));
                Y = Y + (CmdLine.DPara[7] * (CmdLine.Index[6] - 1));

                if (!TaskDisp.TaskMoveGZUp()) return;

                if (!TaskGantry.SetMotionParamGXY()) return;
                if (!TaskGantry.MoveAbsGXY(X, Y)) return;
            }

            if (LocalLayout.CColLayoutType == TLayout.ECLayoutType.MultiP)
            {
                int UnitNo = 0;
                LocalLayout.RCGetUnitNo(ref UnitNo, (LocalLayout.CColCount - 1) * LocalLayout.UColCount, 0);
                GotoUnitNo(UnitNo);
            }
        }
        private void btn_SetCRow_Click(object sender, EventArgs e)
        {
            if (LocalLayout.CRowLayoutType == TLayout.ECLayoutType.Matrix)
                SetCRowMatrixPitch();

            if (LocalLayout.CRowLayoutType == TLayout.ECLayoutType.MultiP)
            {
                int UnitNo = 0;
                LocalLayout.RCGetUnitNo(ref UnitNo, 0, (LocalLayout.CRowCount - 1) * LocalLayout.URowCount);
                SetCRowMultiPitch(UnitNo);
            }
        }
        private void btn_GotoCRow_Click(object sender, EventArgs e)
        {
            if (LocalLayout.CRowLayoutType == TLayout.ECLayoutType.Matrix)
            {
                double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
                double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
                X = X + (CmdLine.DPara[8] * (CmdLine.Index[8] - 1));
                Y = Y + (CmdLine.DPara[9] * (CmdLine.Index[8] - 1));

                if (!TaskDisp.TaskMoveGZUp()) return;

                if (!TaskGantry.SetMotionParamGXY()) return;
                if (!TaskGantry.MoveAbsGXY(X, Y)) return;
            }
            if (LocalLayout.CRowLayoutType == TLayout.ECLayoutType.MultiP)
            {
                int UnitNo = 0;
                LocalLayout.RCGetUnitNo(ref UnitNo, 0, (LocalLayout.CRowCount - 1) * LocalLayout.URowCount);
                GotoUnitNo(UnitNo);
            }
        }
        #endregion

        #region Advance - ClstrLayoutMPitch
        private void lbl_CColNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", MPitch Cluster Col Count", ref CColNo, 0, LocalLayout.CColCount - 1);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void lbl_CRowNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + " MPitch Cluster Row Count", ref CRowNo, 0, LocalLayout.CRowCount - 1);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void lbl_CColDX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + " MPitch Cluster Col Dist X (mm)", ref CmdLine.A[CColNo], -199, 199);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void lbl_CColDY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + " MPitch Cluster Col Dist Y (mm)", ref CmdLine.B[CColNo], -199, 199);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void lbl_CRowDX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + " MPitch Cluster Row Dist X (mm)", ref CmdLine.C[CRowNo], -199, 199);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void lbl_CRowDY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + " MPitch Cluster Row Dist Y (mm)", ref CmdLine.D[CRowNo], -199, 199);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }
        private void btn_SetCColNo_Click(object sender, EventArgs e)
        {
            SetCColMultiPitch(CColNo);
        }
        private void btn_SetCRowNo_Click(object sender, EventArgs e)
        {
            SetCRowMultiPitch(CRowNo);
        }
        private void btn_GotoCColNo_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
            X = X + CmdLine.A[CColNo];
            Y = Y + CmdLine.B[CColNo];

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_GotoCRowNo_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
            X = X + CmdLine.C[CRowNo];
            Y = Y + CmdLine.D[CRowNo];

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        #endregion

        private void lbl_MasterCCol_Click(object sender, EventArgs e)
        {
            //GDefine.uc.UserAdjustExecute(ref CmdLine.Index[12], 0, 99);

            //CmdLine.Index[12] = Math.Min(CmdLine.Index[12], CmdLine.Index[6] - 1);

            //LocalLayout = new TLayout(CmdLine);
            //UpdateDisplay();

            //UpdateUnitLocation();
            //pbox_Layout.Refresh();
        }
        private void lbl_MasterCRow_Click(object sender, EventArgs e)
        {
            //GDefine.uc.UserAdjustExecute(ref CmdLine.Index[13], 0, 99);

            //CmdLine.Index[13] = Math.Min(CmdLine.Index[13], CmdLine.Index[7] - 1);
            
            //LocalLayout = new TLayout(CmdLine);
            //UpdateDisplay();

            //UpdateUnitLocation();
            //pbox_Layout.Refresh();
        }

        double UPitch = 0;
        double USize = 0;
        int[] UX = new int[TLayout.MAX_UNITS];
        int[] UY = new int[TLayout.MAX_UNITS];
        TPos2[] Pos = new TPos2[TLayout.MAX_UNITS];

        private void GotoUnitNo(int UnitNo)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + LocalLayout.StartX;//CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + LocalLayout.StartY;//CmdLine.DPara[1];


            X = X + Pos[UnitNo].X;
            Y = Y + Pos[UnitNo].Y;

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void UpdateUnitLocation()
        {
            LocalLayout.UpdateUnitLocations(pbox_Layout.Width, pbox_Layout.Height, ref UPitch, ref USize, ref UX, ref UY);

            if (Pos[0] == null)
            {
                for (int j = 0; j < TLayout.MAX_UNITS; j++)
                {
                    Pos[j] = new TPos2();
                }
            }
            LocalLayout.ComputePos(ref Pos);
        }
        private void pbox_Layout_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush SBrush = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(SBrush, new Rectangle(0, 0, pbox_Layout.Width - 1, pbox_Layout.Height - 1));

            for (int i = 0; i < LocalLayout.TUCount; i++)
            {
                int X = UX[i];
                int Y = UY[i];

                SBrush = new SolidBrush(this.BackColor);
                Pen Pen = new Pen(Color.Green);
                Pen.Color = Color.Orange;
                if (LocalLayout.UnitNoIsNeedle2(i) && DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                {
                    Pen.Color = Color.Wheat;
                }
                //if (LocalLayout.HeadMode == 1)
                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (LocalLayout.UnitNoIsHead2(i))
                    {
                        Pen.Color = Color.Blue;
                        if (LocalLayout.UnitNoIsNeedle2(i) && DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                        {
                            Pen.Color = Color.SkyBlue;
                        }
                    }
                }

                //if (DispProg.Map.PreMap[LocalLayout.ID].Bin[i] == EMapBin.PreMapNG)
                //{
                //    Pen.Color = DispProg.MapColor.Pen[(byte)EMapBin.PreMapNG].Color;
                //}
                if (SelectedPreMap.Bin[i] == EMapBin.PreMapNG)
                {
                    Pen.Color = DispProg.MapColor.Pen[(byte)EMapBin.PreMapNG].Color;
                }


                Rectangle R = new Rectangle((int)(X - USize / 2), (int)(Y - USize / 2), (int)USize, (int)USize);

                if (MouseMode == EMouseMode.MoveTo)
                {
                    //if (LocalLayout.UnitNoIsSettable(i))
                    //{
                        SBrush = new SolidBrush(Color.LightBlue);
                    //}
                }
                
                e.Graphics.FillRectangle(SBrush, R);
                e.Graphics.DrawRectangle(Pen, R);

                if (SelectedPreMap.Bin[i] == EMapBin.PreMapNG)
                {
                    e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)(Y - USize / 2), (int)(X + USize / 2), (int)(Y + USize / 2));
                    e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)(Y + USize / 2), (int)(X + USize / 2), (int)(Y - USize / 2));
                }

                int Size = Math.Max(2, (int)(USize / 3));

                Font Font = new Font(FontFamily.GenericSansSerif, Size);
                Brush Brush = new SolidBrush(Color.DimGray);
                e.Graphics.DrawString(i.ToString(), Font, Brush, R);
            }

            //if (MouseDn)
            if (SelectionInProgress)
            {
                Pen Pen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(Pen, SelectRect);
            }
        }

        static bool MouseDn = false;
        Point PtDown = new Point(0, 0);
        Point PtMove = new Point(0, 0);
        Point PtUp = new Point(0, 0);
        Rectangle SelectRect = new Rectangle();
        bool SelectionInProgress = false;
        enum EMouseMode { None, MoveTo, PreMap }
        EMouseMode MouseMode = EMouseMode.None;

        int SelectedPreMapIndex = 0;
        TMap SelectedPreMap = new TMap();

        private void pbox_Layout_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseMode == EMouseMode.PreMap)
            {
                PtMove = e.Location;

                int BR_UnitNo = 0;
                LocalLayout.RCGetUnitNo(ref BR_UnitNo, LocalLayout.TColCount - 1, LocalLayout.TRowCount - 1);

                if (!MouseDn)
                {
                    switch (LocalLayout.MapOrigin)
                    {
                        case TLayout.EMapOrigin.Left:
                            #region Board Selection
                            if (PtMove.X < UX[0] - USize / 2 && PtMove.Y < UY[0] - USize / 2)
                            {
                                SelectionInProgress = true;
                                SelectRect = new Rectangle((int)(UX[0]), (int)(UY[0]), (int)(UX[BR_UnitNo] - UX[0]), (int)(UY[BR_UnitNo] - UY[0]));
                            }
                            #endregion
                            else
                                if (PtMove.X < UX[0] - USize / 2)
                            {
                                for (int i = 0; i < LocalLayout.CRowCount; i++)
                                #region Cluster Row Selection
                                {
                                    int RowNo = 0;
                                    LocalLayout.RCGetUnitNo(ref RowNo, 0, (i * LocalLayout.URowCount) + LocalLayout.URowCount - 1);
                                    int Y1 = UY[RowNo];
                                    int NextRowNo = 0;
                                    LocalLayout.RCGetUnitNo(ref NextRowNo, 0, (i * LocalLayout.URowCount) + LocalLayout.URowCount);
                                    int Y2 = UY[NextRowNo];

                                    int LastColNo = 0;
                                    LocalLayout.RCGetUnitNo(ref LastColNo, LocalLayout.TColCount - 1, i);

                                    if (PtMove.Y > Y1 + USize / 2)
                                    {
                                        if (PtMove.Y < Y2 - USize / 2 || PtMove.Y > UY[BR_UnitNo])
                                        {
                                            SelectionInProgress = true;

                                            int SelTL_UnitNo = 0;
                                            LocalLayout.RCGetUnitNo(ref SelTL_UnitNo, 0, (i * LocalLayout.URowCount));
                                            int SelBR_UnitNo = 0;
                                            LocalLayout.RCGetUnitNo(ref SelBR_UnitNo, LocalLayout.TColCount - 1, (i * LocalLayout.URowCount) + LocalLayout.URowCount - 1);

                                            SelectRect = new Rectangle((int)(UX[SelTL_UnitNo]), (int)(UY[SelTL_UnitNo]), (int)(UX[SelBR_UnitNo] - UX[SelTL_UnitNo]), (int)(UY[SelBR_UnitNo] - UY[SelTL_UnitNo]));
                                        }
                                    }
                                }
                                #endregion
                                for (int j = 0; j < LocalLayout.TRowCount; j++)
                                #region Row Selection
                                {
                                    int RowNo = 0;
                                    LocalLayout.RCGetUnitNo(ref RowNo, 0, j);
                                    int Y = UY[RowNo];

                                    int LastColNo = 0;
                                    LocalLayout.RCGetUnitNo(ref LastColNo, LocalLayout.TColCount - 1, j);

                                    if (PtMove.Y > Y - USize / 2 && PtMove.Y < Y + USize / 2)
                                    {
                                        SelectionInProgress = true;
                                        SelectRect = new Rectangle((int)(UX[0] - USize), (int)(UY[RowNo]), (int)(UX[LastColNo] - UX[0] + USize * 2), 1);// (int)(UY[RowNo]));//, (int)(UY[LastColNo] - UY[RowNo] + USize));
                                    }
                                }
                                #endregion
                            }
                            else
                                    if (PtMove.Y < UY[0] - USize / 2)
                            {
                                for (int i = 0; i < LocalLayout.CColCount; i++)
                                #region Cluster Col Selection
                                {
                                    int ColNo = 0;
                                    LocalLayout.RCGetUnitNo(ref ColNo, (i * LocalLayout.UColCount) + LocalLayout.UColCount - 1, 0);
                                    int X1 = UX[ColNo];
                                    int NextColNo = 0;
                                    LocalLayout.RCGetUnitNo(ref NextColNo, (i * LocalLayout.UColCount) + LocalLayout.UColCount, 0);
                                    int X2 = UX[NextColNo];

                                    int LastRowNo = 0;
                                    LocalLayout.RCGetUnitNo(ref LastRowNo, i, LocalLayout.TRowCount - 1);

                                    if (PtMove.X > X1 + USize / 2)
                                    {
                                        if (PtMove.X < X2 - USize / 2 || PtMove.X > UX[BR_UnitNo])
                                        {
                                            SelectionInProgress = true;

                                            int SelTL_UnitNo = 0;
                                            LocalLayout.RCGetUnitNo(ref SelTL_UnitNo, (i * LocalLayout.UColCount), 0);
                                            int SelBR_UnitNo = 0;
                                            LocalLayout.RCGetUnitNo(ref SelBR_UnitNo, (i * LocalLayout.UColCount) + LocalLayout.UColCount - 1, LocalLayout.TRowCount - 1);

                                            SelectRect = new Rectangle((int)(UX[SelTL_UnitNo]), (int)(UY[SelTL_UnitNo]), (int)(UX[SelBR_UnitNo] - UX[SelTL_UnitNo]), (int)(UY[SelBR_UnitNo] - UY[SelTL_UnitNo]));
                                        }
                                    }
                                }
                                #endregion
                                for (int i = 0; i < LocalLayout.TColCount; i++)
                                #region Col Selection
                                {
                                    int ColNo = 0;
                                    LocalLayout.RCGetUnitNo(ref ColNo, i, 0);
                                    int X = UX[ColNo];

                                    int LastRowNo = 0;
                                    LocalLayout.RCGetUnitNo(ref LastRowNo, i, LocalLayout.TRowCount - 1);

                                    if (PtMove.X > X - USize / 2 && PtMove.X < X + USize / 2)
                                    {
                                        SelectionInProgress = true;
                                        SelectRect = new Rectangle((int)(UX[ColNo]), (int)(UY[0] - USize), 1, (int)(UY[LastRowNo] - UY[0] + USize * 2));
                                    }
                                }
                                #endregion
                            }
                            else
                                SelectionInProgress = false;

                            break;
                        case TLayout.EMapOrigin.Right:
                            #region Board Selection
                            if (PtMove.X > UX[0] + USize / 2 && PtMove.Y < UY[0] - USize / 2)
                            {
                                SelectionInProgress = true;
                                SelectRect = new Rectangle((int)(UX[BR_UnitNo]), (int)(UY[0]), (int)Math.Abs(UX[BR_UnitNo] - UX[0]), (int)Math.Abs(UY[BR_UnitNo] - UY[0]));
                            }
                            #endregion
                            else
                                if (PtMove.X > UX[0] + USize / 2)
                            {
                                for (int i = 0; i < LocalLayout.CRowCount; i++)
                                    #region Cluster Row Selection
                                    //{
                                    //    int RowNo = 0;
                                    //    LocalLayout.RCGetUnitNo(ref RowNo, 0, (i * LocalLayout.URowCount) + LocalLayout.URowCount - 1);
                                    //    int Y1 = UY[RowNo];
                                    //    int NextRowNo = 0;
                                    //    LocalLayout.RCGetUnitNo(ref NextRowNo, 0, (i * LocalLayout.URowCount) + LocalLayout.URowCount);
                                    //    int Y2 = UY[NextRowNo];

                                    //    int LastColNo = 0;
                                    //    LocalLayout.RCGetUnitNo(ref LastColNo, LocalLayout.TColCount - 1, i);

                                    //    if (PtMove.Y > Y1 + USize / 2)
                                    //    {
                                    //        if (PtMove.Y < Y2 - USize / 2 || PtMove.Y > UY[BR_UnitNo])
                                    //        {
                                    //        
                                    SelectionInProgress = true;


                                //            int SelTL_UnitNo = 0;
                                //            LocalLayout.RCGetUnitNo(ref SelTL_UnitNo, 0, (i * LocalLayout.URowCount));
                                //            int SelBR_UnitNo = 0;
                                //            LocalLayout.RCGetUnitNo(ref SelBR_UnitNo, LocalLayout.TColCount - 1, (i * LocalLayout.URowCount) + LocalLayout.URowCount - 1);

                                //            SelectRect = new Rectangle((int)(UX[SelTL_UnitNo]), (int)(UY[SelTL_UnitNo]), (int)(UX[SelBR_UnitNo] - UX[SelTL_UnitNo]), (int)(UY[SelBR_UnitNo] - UY[SelTL_UnitNo]));
                                //        }
                                //    }
                                //}
                                #endregion
                                for (int j = 0; j < LocalLayout.TRowCount; j++)
                                #region Row Selection
                                {
                                    int RowNo = 0;
                                    LocalLayout.RCGetUnitNo(ref RowNo, 0, j);
                                    int Y = UY[RowNo];

                                    int LastColNo = 0;
                                    LocalLayout.RCGetUnitNo(ref LastColNo, LocalLayout.TColCount - 1, j);

                                    if (PtMove.Y > Y - USize / 2 && PtMove.Y < Y + USize / 2)
                                    {
                                        SelectionInProgress = true;
                                        SelectRect = new Rectangle((int)(UX[LastColNo] - USize), (int)(UY[RowNo]), (int)(UX[0] - UX[LastColNo] + USize * 2), 1);// (int)(UY[RowNo]));//, (int)(UY[LastColNo] - UY[RowNo] + USize));
                                    }
                                }
                                #endregion
                            }
                            else
                                    if (PtMove.Y < UY[0] - USize / 2)
                            {
                                for (int i = 0; i < LocalLayout.CColCount; i++)
                                #region Cluster Col Selection
                                {
                                    //int ColNo = 0;
                                    //LocalLayout.RCGetUnitNo(ref ColNo, (i * LocalLayout.UColCount) + LocalLayout.UColCount - 1, 0);
                                    //int X1 = UX[ColNo];
                                    //int NextColNo = 0;
                                    //LocalLayout.RCGetUnitNo(ref NextColNo, (i * LocalLayout.UColCount) + LocalLayout.UColCount, 0);
                                    //int X2 = UX[NextColNo];

                                    //int LastRowNo = 0;
                                    //LocalLayout.RCGetUnitNo(ref LastRowNo, i, LocalLayout.TRowCount - 1);

                                    //if (PtMove.X > X1 + USize / 2)
                                    //{
                                    //    if (PtMove.X < X2 - USize / 2 || PtMove.X > UX[BR_UnitNo])
                                    //    {
                                    //        SelectionInProgress = true;

                                    //        int SelTL_UnitNo = 0;
                                    //        LocalLayout.RCGetUnitNo(ref SelTL_UnitNo, (i * LocalLayout.UColCount), 0);
                                    //        int SelBR_UnitNo = 0;
                                    //        LocalLayout.RCGetUnitNo(ref SelBR_UnitNo, (i * LocalLayout.UColCount) + LocalLayout.UColCount - 1, LocalLayout.TRowCount - 1);

                                    //        SelectRect = new Rectangle((int)(UX[SelTL_UnitNo]), (int)(UY[SelTL_UnitNo]), (int)(UX[SelBR_UnitNo] - UX[SelTL_UnitNo]), (int)(UY[SelBR_UnitNo] - UY[SelTL_UnitNo]));
                                    //    }
                                    //}
                                }
                                #endregion
                                for (int i = 0; i < LocalLayout.TColCount; i++)
                                #region Col Selection
                                {
                                    int ColNo = 0;
                                    LocalLayout.RCGetUnitNo(ref ColNo, i, 0);
                                    int X = UX[ColNo];

                                    int LastRowNo = 0;
                                    LocalLayout.RCGetUnitNo(ref LastRowNo, i, LocalLayout.TRowCount - 1);

                                    if (PtMove.X > X - USize / 2 && PtMove.X < X + USize / 2)
                                    {
                                        SelectionInProgress = true;
                                        SelectRect = new Rectangle((int)(UX[ColNo]), (int)(UY[0] - USize), 1, (int)(UY[LastRowNo] - UY[0] + USize * 2));
                                    }
                                }
                                #endregion
                            }
                            else
                                SelectionInProgress = false;

                            break;
                    }
                }

                if (MouseDn && ((Math.Abs(PtMove.X - PtDown.X) > UPitch) || (Math.Abs(PtMove.Y - PtDown.Y) > UPitch)))
                {
                    SelectRect = new Rectangle(Math.Min(PtDown.X, PtMove.X), Math.Min(PtDown.Y, PtMove.Y),
                        Math.Max(PtDown.X, PtMove.X) - Math.Min(PtDown.X, PtMove.X), Math.Max(PtDown.Y, PtMove.Y) - Math.Min(PtDown.Y, PtMove.Y));

                    SelectionInProgress = true;
                    UpdateDisplay();
                }
            }
            pbox_Layout.Refresh();
            UpdateDisplay();
        }
        private void pbox_Layout_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseMode == EMouseMode.MoveTo)
            #region
            {
                for (int i = 0; i < LocalLayout.TUCount; i++)
                {
                    int X = UX[i];
                    int Y = UY[i];

                    int X1 = (int)(X - USize / 2);
                    int Y1 = (int)(Y - USize / 2);
                    int X2 = (int)(X + USize / 2);
                    int Y2 = (int)(Y + USize / 2);

                    if (e.X >= X1 && e.X <= X2 && e.Y >= Y1 && e.Y <= Y2)
                    {
                        //if (LocalLayout.UnitNoIsSettable(i))
                        //{
                        //    if (MouseDnWait(sender, e))
                        //    {
                        //        int CColNo = 0;
                        //        int CRowNo = 0;
                        //        int UColNo = 0;
                        //        int URowNo = 0;
                        //        LocalLayout.UnitNoGetRC(i, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);

                        //        if (CColNo == 0 && CRowNo == 0 && UColNo == 0 && URowNo == 0)
                        //            SetStartXY();
                        //        else
                        //            if (CColNo == 0 && CRowNo == 0 && UColNo == 0 && URowNo == (LocalLayout.URowCount-1))
                        //                SetURowPitch();
                        //            else
                        //                if (CColNo == 0 && CRowNo == 0 && UColNo == (LocalLayout.UColCount - 1) && URowNo == 0)
                        //                    SetUColPitch();
                        //                else
                        //                    if (LocalLayout.CColLayoutType == ECLayoutType.Matrix && CColNo == (LocalLayout.CColCount -1) && CRowNo == 0 && UColNo == 0 && URowNo == 0)
                        //                        SetCColMatrixPitch();
                        //                    else
                        //                        if (LocalLayout.CColLayoutType == ECLayoutType.MultiP && CRowNo == 0 && UColNo == 0 && URowNo == 0)
                        //                            SetCColMultiPitch(CColNo);
                        //                        else
                        //                            if (LocalLayout.CRowLayoutType == ECLayoutType.Matrix && CColNo == 0 && CRowNo == (LocalLayout.CRowCount - 1) && UColNo == 0 && URowNo == 0)
                        //                                SetCRowMatrixPitch();
                        //                            else
                        //                                if (LocalLayout.CRowLayoutType == ECLayoutType.MultiP && CColNo == 0 && UColNo == 0 && URowNo == 0)
                        //                                    SetCRowMultiPitch(CRowNo);
                        //    }
                        //    else
                        //        GotoUnitNo(i);
                        //}
                        //else
                        {
                            GotoUnitNo(i);
                        }
                    }
                }
            }
            #endregion
            if (MouseMode == EMouseMode.PreMap)
            {
                #region
                MouseDn = true;
                PtDown = e.Location;
                if (SelectionInProgress)
                {

                }
                else
                {
                    SelectRect = new Rectangle(PtDown.X, PtDown.Y, 0, 0);
                }
                #endregion
            }
        }
        private void pbox_Layout_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseMode == EMouseMode.MoveTo)
            {
                //MouseDnEnd(sender);
            }

            if (MouseMode == EMouseMode.PreMap)
            {
                #region
                MouseDn = false;
                Point PtUp = e.Location;
        
                for (int i = 0; i < LocalLayout.TUCount; i++)
                {
                    int X = UX[i];
                    int Y = UY[i];

                    float Sel_X = SelectRect.X + ((float)SelectRect.Width / 2);
                    float Sel_Y = SelectRect.Y + ((float)SelectRect.Height / 2);

                    if (Math.Abs(X - Sel_X) < ((double)Math.Abs(USize + SelectRect.Width) / 2) &&
                        Math.Abs(Y - Sel_Y) < ((double)Math.Abs(USize + SelectRect.Height) / 2))
                    {
                        if (SelectedPreMap.Bin[i] == EMapBin.PreMapNG)
                            SelectedPreMap.Bin[i] = EMapBin.None;
                        else
                            SelectedPreMap.Bin[i] = EMapBin.PreMapNG;

                        if (DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                        {
                            int i2 = 0;
                            if (!LocalLayout.UnitNoIsNeedle2(i))
                            {
                                LocalLayout.UnitNoGetNeedle2UnitNo(i, ref i2);
                            }
                            else
                            {
                                LocalLayout.UnitNoGetNeedle1UnitNo(i, ref i2);
                            }
                            //DispProg.Map.PreMap[LocalLayout.ID].Bin[i2] = DispProg.Map.PreMap[LocalLayout.ID].Bin[i];
                            SelectedPreMap.Bin[i2] = SelectedPreMap.Bin[i];
                        }
                    }
                }
                #endregion
            }
            SelectionInProgress = false;
            pbox_Layout.Refresh();
            UpdateDisplay();
        }
        private void pbox_Layout_MouseLeave(object sender, EventArgs e)
        {
            SelectionInProgress = false;
        }
        private void pbox_Layout_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void pbox_Layout_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void lbl_GotoSet_Click(object sender, EventArgs e)
        {
            if (MouseMode == EMouseMode.MoveTo)
                MouseMode = EMouseMode.None;
            else
                MouseMode = EMouseMode.MoveTo;

            UpdateDisplay();
            pbox_Layout.Refresh();
        }
        private void lbl_PreMap_Click(object sender, EventArgs e)
        {
            if (MouseMode == EMouseMode.PreMap)
                MouseMode = EMouseMode.None;
            else
                MouseMode = EMouseMode.PreMap;
            
            UpdateDisplay();
            pbox_Layout.Refresh();
        }

        private void lbl_ClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LocalLayout.TUCount; i++)
            {
                //DispProg.Map.PreMap[LocalLayout.ID].Bin[i] = EMapBin.None;
                SelectedPreMap.Bin[i] = EMapBin.None;
            }
            UpdateDisplay();
            pbox_Layout.Refresh();
        }
        private void lbl_SetAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LocalLayout.TUCount; i++)
            {
                //DispProg.Map.PreMap[LocalLayout.ID].Bin[i] = EMapBin.PreMapNG;
                SelectedPreMap.Bin[i] = EMapBin.PreMapNG;
            }
            UpdateDisplay();
            pbox_Layout.Refresh();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Mag1_Click(object sender, EventArgs e)
        {
            pbox_Layout.Size = pnl_Layout.Size; 
            UpdateUnitLocation();

            pbox_Layout.Refresh();
        }

        private void lbl_MagN_Click(object sender, EventArgs e)
        {
            pbox_Layout.Width = Math.Max(pbox_Layout.Width / 2, pnl_Layout.Width);
            pbox_Layout.Height = Math.Max(pbox_Layout.Height / 2, pnl_Layout.Height);

            pnl_Layout.AutoScrollPosition = new Point((pnl_Layout.HorizontalScroll.Maximum - pnl_Layout.HorizontalScroll.LargeChange) / 2,
                (pnl_Layout.VerticalScroll.Maximum - pnl_Layout.VerticalScroll.LargeChange) / 2);
            
            UpdateUnitLocation();

            pbox_Layout.Refresh();
        }

        private void lbl_MagP_Click(object sender, EventArgs e)
        {
            pbox_Layout.Width = pbox_Layout.Width * 2;
            pbox_Layout.Height = pbox_Layout.Height * 2;

            pnl_Layout.AutoScrollPosition = new Point((pnl_Layout.HorizontalScroll.Maximum - pnl_Layout.HorizontalScroll.LargeChange) / 2,
                (pnl_Layout.VerticalScroll.Maximum - pnl_Layout.VerticalScroll.LargeChange) / 2);

            UpdateUnitLocation();

            pbox_Layout.Refresh();
        }

        private void lbl_Center_Click(object sender, EventArgs e)
        {
            pnl_Layout.AutoScrollPosition = new Point((pnl_Layout.HorizontalScroll.Maximum - pnl_Layout.HorizontalScroll.LargeChange) / 2,
                (pnl_Layout.VerticalScroll.Maximum - pnl_Layout.VerticalScroll.LargeChange) / 2);
        }

        private void lbl_PreMapIndex_Click(object sender, EventArgs e)   
        {
            if (!UC.AdjustExec(CmdName + ", PreMap No", ref SelectedPreMapIndex, 0, DispProg.MAX_IDS - 1)) return;

            label8.Text = SelectedPreMapIndex.ToString();
            SelectedPreMap = DispProg.Map.PreMap[SelectedPreMapIndex];
            pbox_Layout.Refresh();
        }

        private void lbl_PrevPreMap_Click(object sender, EventArgs e)
        {
            //if (SelectedPreMapIndex >= 4)
            //    SelectedPreMapIndex = 0;
            //else
            //    SelectedPreMapIndex++;

            if (SelectedPreMapIndex > 0)
                SelectedPreMapIndex--;

            label8.Text = SelectedPreMapIndex.ToString();
            SelectedPreMap = DispProg.Map.PreMap[SelectedPreMapIndex];
            pbox_Layout.Refresh();
        }
        private void lbl_NextPreMap_Click(object sender, EventArgs e)
        {
            if (SelectedPreMapIndex < 15)
                SelectedPreMapIndex++;

            label8.Text = SelectedPreMapIndex.ToString();
            SelectedPreMap = DispProg.Map.PreMap[SelectedPreMapIndex];
            pbox_Layout.Refresh();
        }

        private void btn_SwapStartLoc_Click(object sender, EventArgs e)
        {
            //if (i_MapOrigin == 0) i_MapOrigin = 1; else i_MapOrigin = 0;
            //SetMapOrigin(i_MapOrigin);

            if (LocalLayout.MapOrigin == TLayout.EMapOrigin.Left)
                SetMapOrigin(TLayout.EMapOrigin.Right);
            else
                SetMapOrigin(TLayout.EMapOrigin.Left);
        }






        private void lbl_TLX_Click(object sender, EventArgs e)
        {
            DispProg.TLine tCmdLine = new DispProg.TLine(CmdLine);

            if (!UC.AdjustExec(CmdName + ", TLX", ref tCmdLine.IPara[12], 0, TLayout.MAX_RC)) return;

            try
            {
                TLayout tLayout = new TLayout(tCmdLine);
            }
            catch
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                return;
            }
            CmdLine.Copy(tCmdLine);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }
        private void lbl_TLY_Click(object sender, EventArgs e)
        {
            DispProg.TLine tCmdLine = new DispProg.TLine(CmdLine);

            if (!UC.AdjustExec(CmdName + ", TLY", ref tCmdLine.IPara[13], 0, TLayout.MAX_RC)) return;

            try
            {
                TLayout tLayout = new TLayout(tCmdLine);
            }
            catch
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                return;
            }
            CmdLine.Copy(tCmdLine);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }
        private void lbl_TRX_Click(object sender, EventArgs e)
        {
            DispProg.TLine tCmdLine = new DispProg.TLine(CmdLine);

            if (!UC.AdjustExec(CmdName + ", TRX", ref tCmdLine.IPara[14], 0, TLayout.MAX_RC)) return;

            try
            {
                TLayout tLayout = new TLayout(tCmdLine);
            }
            catch
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                return;
            }
            CmdLine.Copy(tCmdLine);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }
        private void lbl_BLY_Click(object sender, EventArgs e)
        {
            DispProg.TLine tCmdLine = new DispProg.TLine(CmdLine);

            if (!UC.AdjustExec(CmdName + ", BRY", ref tCmdLine.IPara[17], 0, TLayout.MAX_RC)) return;

            try
            {
                TLayout tLayout = new TLayout(tCmdLine);
            }
            catch
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                return;
            }
            CmdLine.Copy(tCmdLine);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }

        private void btnSetTLPos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            //NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[12], CmdLine.DPara[13]);
            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.DPara[0], CmdLine.DPara[1]);
            CmdLine.DPara[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.DPara[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.DPara[0], CmdLine.DPara[1]);
            Log.OnSet(CmdName + " SetTL", Old, New);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void btnGotoTLPos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btnSetTRPitch_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D oldColPitch = new NSW.Net.Point2D(CmdLine.DPara[3], CmdLine.DPara[3]);

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            double dX = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) - CmdLine.DPara[0];
            double dY = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) - CmdLine.DPara[1];

            if (CmdLine.IPara[14] == CmdLine.IPara[12])
            {
                CmdLine.DPara[2] = 0;
                CmdLine.DPara[3] = 0;
            }
            else
            {
                CmdLine.DPara[2] = dX / (CmdLine.IPara[14] - CmdLine.IPara[12]);
                CmdLine.DPara[3] = dY / (CmdLine.IPara[14] - CmdLine.IPara[12]);
            }
            NSW.Net.Point2D newColPitch = new NSW.Net.Point2D(CmdLine.DPara[2], CmdLine.DPara[3]);
            Log.OnSet(CmdName + " SetTR Pitch", oldColPitch, newColPitch);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void btnGotoTRPos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0] +
            CmdLine.DPara[2] * (CmdLine.IPara[14] - CmdLine.IPara[12]);
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1] +
            CmdLine.DPara[3] * (CmdLine.IPara[14] - CmdLine.IPara[12]);

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btnSetBLPitch_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D oldRowPitch = new NSW.Net.Point2D(CmdLine.DPara[4], CmdLine.DPara[5]);

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            double dX = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) - CmdLine.DPara[0];
            double dY = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) - CmdLine.DPara[1];

            if (CmdLine.IPara[17] == CmdLine.IPara[13])
            {
                CmdLine.DPara[4] = 0;
                CmdLine.DPara[5] = 0;
            }
            else
            {
                CmdLine.DPara[4] = dX / (CmdLine.IPara[17] - CmdLine.IPara[13]);
                CmdLine.DPara[5] = dY / (CmdLine.IPara[17] - CmdLine.IPara[13]);
            }
            NSW.Net.Point2D newRowPitch = new NSW.Net.Point2D(CmdLine.DPara[4], CmdLine.DPara[5]);
            Log.OnSet(CmdName + " SetBL Pitch", oldRowPitch, newRowPitch);

            LocalLayout = new TLayout(CmdLine);
            UpdateUnitLocation();
            UpdateDisplay();
        }
        private void btnGotoBLPos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0] +
            CmdLine.DPara[4] * (CmdLine.IPara[17] - CmdLine.IPara[13]);
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1] +
            CmdLine.DPara[5] * (CmdLine.IPara[17] - CmdLine.IPara[13]);

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btnGotoBR_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0] +
            CmdLine.DPara[2] * (CmdLine.IPara[14] - CmdLine.IPara[12]) +
            CmdLine.DPara[4] * (CmdLine.IPara[17] - CmdLine.IPara[13]);
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1] +
            CmdLine.DPara[3] * (CmdLine.IPara[14] - CmdLine.IPara[12]) +
            CmdLine.DPara[5] * (CmdLine.IPara[17] - CmdLine.IPara[13]);

            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_EnableWafer_Click(object sender, EventArgs e)
        {
            bool b = CmdLine.IPara[11] > 0;
            if (UC.AdjustExec(CmdName + " Enable Wafer", ref b))
            {
                CmdLine.IPara[11] = Convert.ToInt32(b);
                LocalLayout = new TLayout(CmdLine);
                UpdateDisplay();
            }
            UpdateUnitLocation();
            pbox_Layout.Refresh();
        }

        private void btnAlignTheta_Click(object sender, EventArgs e)
        {
            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
            //frm.PageVision.SelectedCam = 0;
            frm.ShowVision = true;

            double tempTLX = CmdLine.DPara[0];
            double tempTLY = CmdLine.DPara[1];

            double x = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];
            if (!TaskDisp.TaskMoveGZUp()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(x, y)) return;

            _Repeat:
            frm.Inst = "Move Crosshair to TL Ref.";
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) return;

            double dx = CmdLine.DPara[2] * (CmdLine.IPara[14] - CmdLine.IPara[12]) + CmdLine.DPara[3] * (CmdLine.IPara[15] - CmdLine.IPara[13]);

            if (!TaskDisp.TaskMoveGZUp()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MovePtpRel(TaskGantry.GXAxis, dx)) return;

            frm.Inst = "Move TR Ref to Crosshair.";
            dr = frm.ShowDialog();
            if (dr != DialogResult.OK) return;

            if (!TaskDisp.TaskMoveGZUp()) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MovePtpRel(TaskGantry.GXAxis, -dx)) return;

            goto _Repeat;
        }
    }
}
