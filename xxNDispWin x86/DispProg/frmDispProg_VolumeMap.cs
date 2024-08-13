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
    internal partial class frm_DispCore_DispProg_VolumeMap : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_VolumeMap()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            //AppLanguage.Func.SetComponent(this);

            lview_Table.Items.Clear();

            lview_Table.Columns.Add("No");
            lview_Table.Columns[0].Width = 40;//No
            lview_Table.Columns.Add("Ref");
            lview_Table.Columns[1].Width = 100;//Reference
            lview_Table.Columns.Add("Value");
            lview_Table.Columns[2].Width = 100;//Value
        }

        private void frmDispProg_VolumeMap_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;
            UpdateDisplay();
            UpdateList();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void UpdateDisplay()
        {
            lbl_Method.Text = Enum.GetName(typeof(EVMMethod), CmdLine.IPara[0]).ToString();
            //if (CmdLine.IPara[0] == 0) CmdLine.IPara[2] = 1;
            lbl_RefType.Text = Enum.GetName(typeof(EVMCntrType), CmdLine.IPara[1]).ToString();
            lbl_RefPoint.Text = CmdLine.IPara[2].ToString();
            lbl_AdjType.Text = Enum.GetName(typeof(EVMAdjType), CmdLine.IPara[3]).ToString();

            if (CmdLine.IPara[1] == (int)EVMCntrType.Frame) lbl_CurrentRef.Text = Stats.BoardCount.ToString() + " (Frame)";
            int t = GDefine.GetTickCount();
            if (CmdLine.IPara[1] == (int)EVMCntrType.Time) lbl_CurrentRef.Text = ((double)(GDefine.GetTickCount() - Stats.StartTime)/60000).ToString("f1") + " (min)";

            gbox_Rate.Visible = CmdLine.IPara[0] == 0;
            gbox_Trend.Visible = CmdLine.IPara[0] == 1;
            lbl_RefCount.Text = CmdLine.Index[0].ToString();
            if (CmdLine.IPara[1] == (int)EVMCntrType.Frame) lbl_RefCount.Text = lbl_RefCount.Text + " (Frame)";
            if (CmdLine.IPara[1] == (int)EVMCntrType.Time) lbl_RefCount.Text = lbl_RefCount.Text + " (min)";

            lbl_Value.Text = CmdLine.X[0].ToString("f3") + " ";
            if (CmdLine.IPara[3] == (int)EVMAdjType.Value) lbl_Value.Text = lbl_Value.Text + "(ul)";
            if (CmdLine.IPara[3] == (int)EVMAdjType.Pcnt) lbl_Value.Text = lbl_Value.Text + "(%)";
        }
        private void UpdateList()
        {
            lview_Table.Items.Clear();

            for (int i = 0; i < CmdLine.IPara[2] + 1; i++)
            {
                string[] Line = new string[3];
                if (i == 0)
                {
                    Line[0] = "No ";
                    Line[1] = "Ref ";
                    if (CmdLine.IPara[1] == (int)EVMCntrType.Frame) Line[1] = Line[1] + "(Frame)";
                    //if (CmdLine.IPara[1] == (int)EVMRefType.Unit) Line[1] = Line[1] + "(Unit)";
                    if (CmdLine.IPara[1] == (int)EVMCntrType.Time) Line[1] = Line[1] + "(min)";
                    Line[2] = "Value ";
                    if (CmdLine.IPara[3] == (int)EVMAdjType.Value) Line[2] = Line[2] + "(ul)";
                    if (CmdLine.IPara[3] == (int)EVMAdjType.Pcnt) Line[2] = Line[2] + "(%)";
                    ListViewItem lviHeader = new ListViewItem(Line);
                    lview_Table.Items.Add(lviHeader);
                    continue;
                }
                
                Line[0] = (i - 1).ToString();
                Line[1] = CmdLine.Index[i - 1].ToString();

                if (i > 0)
                {
                    CmdLine.Index[i] = Math.Max(CmdLine.Index[i], CmdLine.Index[i - 1] + 1);
                    //Line[1] = Line[i - 1];
                }
                Line[2] = CmdLine.X[i - 1].ToString("f3");
                ListViewItem lvi = new ListViewItem(Line);
                lview_Table.Items.Add(lvi);
            }
        }

        private void lview_Table_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void lview_Table_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private void lview_Table_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePosition = lview_Table.PointToClient(Control.MousePosition);
                ListViewHitTestInfo hit = lview_Table.HitTest(mousePosition);
                if (hit.Item != null)
                {
                    //if (hit.Item.Index < 1) return;
                    int i_RowNo = hit.Item.Index;
                    if (i_RowNo < 1) return;
                    int i_ColNo = hit.Item.SubItems.IndexOf(hit.SubItem);
                    if (i_ColNo < 1) return;

                    //this.Text = i_RowNo.ToString() + "," + i_ColNo.ToString();

                    //StdUserControl.UserCtrl uc = new StdUserControl.UserCtrl();

                    if (i_ColNo == 1)
                    {
                        UC.AdjustExec(CmdName + ", Ref", ref CmdLine.Index[i_RowNo - 1], 1, 1000);
                    }
                    if (i_ColNo == 2)
                    {
                        UC.AdjustExec(CmdName + ", Value", ref CmdLine.X[i_RowNo - 1], -10, 10);
                    }

                    UpdateList();
                }
                else return;
            }
        }

        private void lbl_Method_Click(object sender, EventArgs e)
        {
            EVMMethod E = EVMMethod.Rate;
            UC.AdjustExec(CmdName + ", Method", ref CmdLine.IPara[0], E);
            
            UpdateDisplay();
        }
        private void lbl_Reference_Click(object sender, EventArgs e)
        {
            EVMCntrType E = EVMCntrType.Frame;
            UC.AdjustExec(CmdName + ", Reference", ref CmdLine.IPara[1], E);

            UpdateDisplay();
            UpdateList();
        }
        private void lbl_AdjType_Click(object sender, EventArgs e)
        {
            EVMAdjType E = EVMAdjType.Value;
            UC.AdjustExec(CmdName + ", AdjType", ref CmdLine.IPara[3], E);

            UpdateDisplay();
            UpdateList();
        }

        private void lbl_RefPoint_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", RefPoint", ref CmdLine.IPara[2], 1, 100);

            UpdateDisplay();
            UpdateList();
        }
        private void lbl_Value_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Value", ref CmdLine.X[0], -10, 10);

            UpdateDisplay();
        }
        private void lbl_RefCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", RefCount", ref CmdLine.Index[0], 1, 1000);

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

        private void frm_DispCore_DispProg_VolumeMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void gbox_Trend_Enter(object sender, EventArgs e)
        {

        }
    }
}
