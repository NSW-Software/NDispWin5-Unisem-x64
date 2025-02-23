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
    internal partial class frm_DispCore_DispProg_PPVolComp : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public bool ShowCond = true;

        public frm_DispCore_DispProg_PPVolComp()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            if (DispProg.Target_Weight > 0)
                tabControl1.TabPages.Remove(tpage_Volume);
            else
                tabControl1.TabPages.Remove(tpage_Weight);
        }

        private void UpdateDisplay()
        {
            TConditions Cond = new TConditions(LineNo, CmdLine);
            lbox_Cond.Items.Clear();
            foreach (string s in Cond.Strings)
            {
                lbox_Cond.Items.Add(s);
            }

            lbl_HeadAVolComp.Text = CmdLine.DPara[0].ToString("f3");
            lbl_HeadBVolComp.Text = CmdLine.DPara[1].ToString("f3");
            lbl_HeadAWeightComp.Text = CmdLine.DPara[2].ToString("f3");
            lbl_HeadBWeightComp.Text = CmdLine.DPara[3].ToString("f3");
            lbl_TargetWeight.Text = "Target Weight (mg) = " + DispProg.Target_Weight.ToString("f3");

            lbox_Cond.Visible = ShowCond;
            btn_Cond.Visible = ShowCond;
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_PPVolComp_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = CmdName;
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            UpdateDisplay();
        }
        private void frm_DispCore_DispProg_PPVolComp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void lbl_HeadAVolComp_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.DPara[0], 3);
            UC.AdjustExec(CmdName + ", Head1 Volume_ul", ref X, -1, 1);
            CmdLine.DPara[0] = X;
            UpdateDisplay();
        }
        private void lbl_HeadBVolComp_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.DPara[1], 3);
            UC.AdjustExec(CmdName + ", Head2 Volume_ul", ref X, -1, 1);
            CmdLine.DPara[1] = X;
            UpdateDisplay();
        }
        private void btn_Copy_Click(object sender, EventArgs e)
        {
            double Old = CmdLine.DPara[1];
            CmdLine.DPara[1] = CmdLine.DPara[0];
            double New = CmdLine.DPara[1];
            Log.OnCopy(CmdName + " Head2 Volume_ul", Old, New);

            UpdateDisplay();
        }

        private void lbl_HeadAWeightComp_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.DPara[2], 3);
            UC.AdjustExec(CmdName + ", Head1 Volume_mg", ref X, -20, 20);
            CmdLine.DPara[2] = X;
            UpdateDisplay();
        }
        private void lbl_HeadBWeightComp_Click(object sender, EventArgs e)
        {
            double X = Math.Round(CmdLine.DPara[3], 3);
            UC.AdjustExec(CmdName + ", Head2 Volume_mg", ref X, -20, 20);
            CmdLine.DPara[3] = X;
            UpdateDisplay();
        }
        private void btn_CopyW_Click(object sender, EventArgs e)
        {
            double Old = CmdLine.DPara[3];
            CmdLine.DPara[3] = CmdLine.DPara[2];
            double New = CmdLine.DPara[2];
            Log.OnCopy(CmdName + " Head2 Volume_mg", Old, New);

            UpdateDisplay();
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            DispProg.PP_VolComp.Do(CmdLine);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);

            TaskDisp.TaskMoveGZUp();

            Log.OnAction("OK", CmdName);
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskMoveGZUp();

            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void btn_Cond_Click(object sender, EventArgs e)
        {
            //TConditions Conds = new TConditions();
            //Conds.Cond[0] = new TCondition(LineNo, (EDispProgCondExec)CmdLine.Index[0], CmdLine.DPara[0]);
            //Conds.Cond[1] = new TCondition(LineNo, (EDispProgCondExec)CmdLine.Index[1], CmdLine.DPara[1]);

            //frm_DispProg_Condition frm = new frm_DispProg_Condition();
            //frm.Conds = new TConditions(Conds);
            //frm.ShowDialog();

            //CmdLine.Index[0] = (int)frm.Conds.Cond[0].Cond;
            //CmdLine.DPara[0] = frm.Conds.Cond[0].Count;
            //CmdLine.Index[1] = (int)frm.Conds.Cond[1].Cond;
            //CmdLine.DPara[1] = frm.Conds.Cond[1].Count;

            frm_DispProg_Condition frm = new frm_DispProg_Condition();
            frm.CmdLine.Copy(CmdLine);
            frm.ShowDialog();
            CmdLine.Copy(frm.CmdLine);

            UpdateDisplay();
        }
    }
}
