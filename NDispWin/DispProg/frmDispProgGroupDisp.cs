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
    internal partial class frmDispProgGroupDisp : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);
        public TPos2 UnitOfst = new TPos2(DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex].X, DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex].Y);

        public frmDispProgGroupDisp()
        {
            InitializeComponent();
            GControl.LogForm(this);

            lvCmdList.Columns.Add("NO", 30);
            lvCmdList.Columns.Add("COMMAND", 90);
            lvCmdList.Columns.Add("PARA", 130);
            lvCmdList.Columns.Add("DISP", 40);
            lvCmdList.Columns.Add("SET", 60);
            lvCmdList.Columns.Add("GOTO", 65);
        }

        private void UpdateDisplay()
        {
            lblHeadNo.Text = CmdLine.ID.ToString();
            lblModelNo.Text = CmdLine.IPara[0].ToString();
            cbEnableWeight.Checked = CmdLine.IPara[1] > 0;
            lblWeight.Text = CmdLine.DPara[1].ToString("f3");

            lblCutTailLength.Text = CmdLine.DPara[10].ToString("f3");
            lblCutTailSpeed.Text = CmdLine.DPara[11].ToString("f3");
            lblCutTailHeight.Text = CmdLine.DPara[12].ToString("f3");
            lblCutTailType.Text = CmdLine.DPara[13].ToString("f0");
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd;
            }
        }

        private void frmDispProgGroupDisp_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            UpdateDisplay();
            UpdateCmdList();
        }
        private void frmDispProgGroupDisp_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void frmDispProgGroupDisp_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void UpdateCmdList()
        {
            lvCmdList.Items.Clear();
            ListViewItem lvi;

            for (int i = 0; i < 100; i++)
            {
                if (CmdLine.Index[i] == 0) break;

                lvi = new ListViewItem(i.ToString("000"));
                lvi.SubItems.Add(Enum.GetName(typeof(EGDispCmd), CmdLine.Index[i]).ToString());
                lvi.SubItems.Add(string.Format("X: {0:f3}, Y: {1:f3}", CmdLine.X[i], CmdLine.Y[i]));
                if (CmdLine.Index[i] == (int)EGDispCmd.DOT ||
                    CmdLine.Index[i] == (int)EGDispCmd.DOT_START ||
                    CmdLine.Index[i] == (int)EGDispCmd.LINE_START)
                    lvi.SubItems.Add(CmdLine.U[i] > 0?"[ x ]":"[ * ]");
                else
                    lvi.SubItems.Add("");
                lvi.SubItems.Add("[ SET ]");
                lvi.SubItems.Add("[ GOTO ]");
                lvCmdList.Items.Add(lvi);
            }
        }

        private void lblHeadNo_Click(object sender, EventArgs e)
        {
            int i = Enum.GetNames(typeof(EHeadNo)).Length;
            UC.AdjustExec(CmdName + ", HeadNo", ref CmdLine.ID, 1, i);
            UpdateDisplay();
        }
        private void lblModelNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Model No", ref CmdLine.IPara[0], 0, TModelList.MAX_MODEL);
            UpdateDisplay();
        }
        private void lblWeight_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", TotalWeight", ref CmdLine.DPara[1], 0, 100);
            UpdateDisplay();
        }
        private void cbTotalWeight_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[1] > 0)
                CmdLine.IPara[1] = 0;
            else
                CmdLine.IPara[1] = 1;

            bool enabled = CmdLine.IPara[1] > 0;
            Log.OnSet(CmdName + ", Enable Total Weight", !enabled, enabled);

            UpdateDisplay();
        }

        int selCmdNo = 0;
        private void lvCmdList_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void lvCmdList_MouseUp(object sender, MouseEventArgs e)
        {
            Point mousePosition = lvCmdList.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hit = lvCmdList.HitTest(mousePosition);
            selCmdNo = -1;
            if (hit.Item == null) return;
            if (hit.Item.Index < 0) return;

            selCmdNo = hit.Item.Index;
            int iCol = hit.Item.SubItems.IndexOf(hit.SubItem);

            if (e.Button == MouseButtons.Left)
            {
                double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
                double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

                if (lvCmdList.Columns[iCol].Text == "COMMAND")
                {
                    int iCmd = CmdLine.Index[selCmdNo];
                    if (UC.AdjustExec(CmdName + ", Command", ref iCmd, EGDispCmd.None))
                    CmdLine.Index[selCmdNo] = iCmd;

                    if (iCmd == 0)
                    {
                        for (int i = selCmdNo; i < 100; i++)
                        {
                            CmdLine.Index[i] = 0;
                        }
                    }

                    UpdateCmdList();
                }
                if (lvCmdList.Columns[iCol].Text == "DISP")
                {
                    CmdLine.U[selCmdNo] = CmdLine.U[selCmdNo] > 0 ? 0 : 1;
                    UpdateCmdList();
                }
                if (lvCmdList.Columns[iCol].Text == "GOTO")
                {
                    if (selCmdNo > 0)
                    {
                        for (int i = 1; i < selCmdNo + 1; i++)
                        {
                            X += CmdLine.X[i];
                            Y += CmdLine.Y[i];
                        }
                    }

                    if (!TaskDisp.TaskMoveGZZ2Up()) return;
                    DispProg.RealTimeOffset(DispProg.ERealTimeOp.Add, ref X, ref Y);
                    if (!TaskGantry.SetMotionParamGXY()) return;
                    if (!TaskGantry.MoveAbsGXY(X, Y)) return;
                }
                if (lvCmdList.Columns[iCol].Text == "SET")
                {
                    double Xs = TaskGantry.GXPos();
                    double Ys = TaskGantry.GYPos();
                    DispProg.RealTimeOffset(DispProg.ERealTimeOp.Minus, ref Xs, ref Ys);

                    if (selCmdNo == 0)
                    {
                        NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
                        CmdLine.X[0] = Xs - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
                        CmdLine.Y[0] = Ys - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
                        NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
                        Log.OnSet(CmdName + ", End XY", Old, New);
                    }
                    else
                    {
                        if (selCmdNo > 0)
                        {
                            for (int i = 1; i < selCmdNo; i++)
                            {
                                X += CmdLine.X[i];
                                Y += CmdLine.Y[i];
                            }
                        }

                        NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[selCmdNo], CmdLine.Y[selCmdNo]);
                        CmdLine.X[selCmdNo] = Xs - X;
                        CmdLine.Y[selCmdNo] = Ys - Y;
                        NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[selCmdNo], CmdLine.Y[selCmdNo]);
                        Log.OnSet(CmdName + ", End XY", Old, New);
                    }

                    UpdateCmdList();
                }

                lvCmdList.Items[Math.Min(selCmdNo, lvCmdList.Items.Count - 1)].Selected = true;
                lvCmdList.Select();
                lvCmdList.TopItem = lvCmdList.Items[0];
                lvCmdList.EnsureVisible(Math.Min(selCmdNo, lvCmdList.Items.Count - 1));
            }
        }

        private void lblCutTailLength_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", CutTail Length (mm)", ref CmdLine.DPara[10], 0, 10);
            UpdateDisplay();
        }
        private void lblCutTailSpeed_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", CutTail Length (mm/s)", ref CmdLine.DPara[11], 0, 100);
            UpdateDisplay();
        }
        private void lblCutTailHeight_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", CutTail Height (mm)", ref CmdLine.DPara[12], 0, 100);
            UpdateDisplay();
        }
        private void lblCutTailType_Click(object sender, EventArgs e)
        {
            int i = (int)CmdLine.DPara[13];
            UC.AdjustExec(CmdName + ", CutTail Type", ref i, ECutTailType.None);
            CmdLine.DPara[13] = i;
            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //validate GDisp Line Commands Sequence and Dot
            bool bLineStarted = false;
            for (int i = 0; i < 100; i++)
            {
                bool breakFor = false;
                switch (CmdLine.Index[i])
                {
                    case (int)EGDispCmd.None:
                        breakFor = true;
                        break;
                    case (int)EGDispCmd.New:
                        MessageBox.Show("Command is defination is incomplete."); return; 
                    case (int)EGDispCmd.DOT:
                        if (bLineStarted) { MessageBox.Show("Invalid sequence. Dot possible after LineStart."); return; }
                        break;
                    case (int)EGDispCmd.LINE_START:
                        if (bLineStarted) { MessageBox.Show("Invalid sequence. Cannot LineStart without LineEnd."); return; }
                        bLineStarted = true;
                        break;
                    case (int)EGDispCmd.LINE_PASS:
                        if (!bLineStarted) { MessageBox.Show("Invalid sequence. LinePass not possible without LineStart."); return; }
                        break;
                    case (int)EGDispCmd.LINE_END:
                        if (!bLineStarted) {MessageBox.Show("Invalid sequence. LineEnd not possible without LineStart."); return; }
                        bLineStarted = false;
                        break;
                }
                if (breakFor)
                {
                    if (bLineStarted) {MessageBox.Show("Invalid sequence. No LineEnd after LineStart."); return; }
                    break;
                }
            }

            //if (CmdLine.IPara[1] > 0)//weighted cannot dot and line
            //{
            //    int iDot = 0;
            //    int iLine = 0;
            //    for (int i = 0; i < 100; i++)
            //    {
            //        bool breakFor = false;
            //        switch (CmdLine.Index[i])
            //        {
            //            case (int)EGDispCmd.None:
            //                breakFor = true;
            //                break;
            //            case (int)EGDispCmd.DOT:
            //                if (iLine > 0) { MessageBox.Show("When Enable Weight, Dot and Line combination is not allowed. Seperate to a different GroupDisp."); return; }
            //                iDot++;
            //                break;
            //            case (int)EGDispCmd.LINE_START:
            //                if (iDot > 0) { MessageBox.Show("When Enable Weight, Dot and Line combination is not allowed. Seperate to a different GroupDisp."); return; }
            //                if (iLine > 0) { MessageBox.Show("When Enable Weight, Only one Line Group is not allowed. Seperate to a different GroupDisp."); return; }
            //                iLine++;
            //                break;
            //            case (int)EGDispCmd.LINE_PASS:
            //            case (int)EGDispCmd.LINE_END:
            //                break;
            //        }
            //        if (breakFor) break;
            //    }
            //}

            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName);
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (CmdLine.Index[i] > 0) continue;
                CmdLine.Index[i] = (int)EGDispCmd.New;
                CmdLine.X[i] = 0;
                CmdLine.Y[i] = 0;
                selCmdNo = i;
                break;
            }

            UpdateCmdList();

            lvCmdList.Items[Math.Min(selCmdNo, lvCmdList.Items.Count - 1)].Selected = true;
            lvCmdList.Select();
            lvCmdList.TopItem = lvCmdList.Items[0];
            lvCmdList.EnsureVisible(Math.Min(selCmdNo, lvCmdList.Items.Count - 1));
        }

        private void cbEnableWeight_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.cbEnableWeight, "Enable Weight. Weight is implemented to each Dot or each group of Lines.");
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (selCmdNo < 0) return;
            if (CmdLine.Index[selCmdNo] == 0) return;//no command to move
            if (selCmdNo == 0) return;//first one

            int I = CmdLine.Index[selCmdNo - 1];
            double X = CmdLine.X[selCmdNo - 1];
            double Y = CmdLine.Y[selCmdNo - 1];
            CmdLine.Index[selCmdNo - 1] = CmdLine.Index[selCmdNo];
            CmdLine.X[selCmdNo - 1] = CmdLine.X[selCmdNo];
            CmdLine.Y[selCmdNo - 1] = CmdLine.Y[selCmdNo];
            CmdLine.Index[selCmdNo] = I;
            CmdLine.X[selCmdNo] = X;
            CmdLine.Y[selCmdNo] = Y;
            UpdateCmdList();

            selCmdNo--;
            lvCmdList.Items[Math.Min(selCmdNo, lvCmdList.Items.Count - 1)].Selected = true;
            lvCmdList.Select();
            lvCmdList.TopItem = lvCmdList.Items[0];
            lvCmdList.EnsureVisible(Math.Min(selCmdNo, lvCmdList.Items.Count - 1));
        }

        private void btnMoveDn_Click(object sender, EventArgs e)
        {
            if (selCmdNo < 0) return;
            if (CmdLine.Index[selCmdNo] == 0) return;//no command to move
            if (CmdLine.Index[selCmdNo + 1] == 0) return;//last one

            int I = CmdLine.Index[selCmdNo + 1];
            double X = CmdLine.X[selCmdNo + 1];
            double Y = CmdLine.Y[selCmdNo + 1];
            CmdLine.Index[selCmdNo + 1] = CmdLine.Index[selCmdNo];
            CmdLine.X[selCmdNo + 1] = CmdLine.X[selCmdNo];
            CmdLine.Y[selCmdNo + 1] = CmdLine.Y[selCmdNo];
            CmdLine.Index[selCmdNo] = I;
            CmdLine.X[selCmdNo] = X;
            CmdLine.Y[selCmdNo] = Y;
            UpdateCmdList();

            selCmdNo++;
            lvCmdList.Items[Math.Min(selCmdNo, lvCmdList.Items.Count - 1)].Selected = true;
            lvCmdList.Select();
            lvCmdList.TopItem = lvCmdList.Items[0];
            lvCmdList.EnsureVisible(Math.Min(selCmdNo, lvCmdList.Items.Count - 1));
        }

        private void btnEditModel_Click(object sender, EventArgs e)
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
    }
}
