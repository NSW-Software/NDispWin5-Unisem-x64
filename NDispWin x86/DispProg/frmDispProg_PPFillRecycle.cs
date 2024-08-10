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
    internal partial class frm_DispCore_DispProg_PPFillRecycle : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public frm_DispCore_DispProg_PPFillRecycle()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void UpdateDisplay()
        {
            TConditions Cond = new TConditions(LineNo, CmdLine);
            lbox_Cond.Items.Clear();
            foreach (string s in Cond.Strings)
            {
                lbox_Cond.Items.Add(s);
            }

            lbl_Count.Text = CmdLine.IPara[2].ToString();
            lbl_Method.Text = ((TaskDisp.ERecycleMethod)CmdLine.IPara[3]).ToString();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frm_DispCore_DispProg_RecycleB_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            this.Text = CmdName;

            pnl_Count.Visible = (CmdLine.Cmd == DispProg.ECmd.PP_RECYCLE_B || CmdLine.Cmd == DispProg.ECmd.PP_RECYCLE_N);
            pnl_Method.Visible = (CmdLine.Cmd == DispProg.ECmd.PP_RECYCLE_B);

            UpdateDisplay();
        }

        private void lbl_Count_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Count", ref CmdLine.IPara[2], 1, 20);
            UpdateDisplay();
        }

        private void lbl_Method_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[3] < Enum.GetNames(typeof(TaskDisp.ERecycleMethod)).Length - 1)
                CmdLine.IPara[3]++;
            else
                CmdLine.IPara[3] = 0;

            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            Log.OnAction("OK", CmdName);
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void frm_DispCore_DispProg_PPRecycleB_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
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
