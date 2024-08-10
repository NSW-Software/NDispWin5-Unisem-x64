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
    internal partial class frm_DispCore_DispProg_RecycleB : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public frm_DispCore_DispProg_RecycleB()
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
            lbl_Count.Text = CmdLine.IPara[2].ToString();
            lbl_Method.Text = ((TaskDisp.ERecycleMethod)CmdLine.IPara[3]).ToString();
        }

        private void frm_DispCore_DispProg_RecycleB_Load(object sender, EventArgs e)
        {
            this.Text = "Recycle Barrel";
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            UpdateDisplay();
        }

        private void lbl_Count_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[2], 1, 20);
            UpdateDisplay();
        }

        private void lbl_Method_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[3] < Enum.GetNames(typeof(TaskDisp.ERecycleMethod)).Length)
                CmdLine.IPara[3]++;
            else
                CmdLine.IPara[3] = 0;

            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            frm_DispCore_DispProg.Done = true;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg.Done = true;
            Close();
        }
    }
}
