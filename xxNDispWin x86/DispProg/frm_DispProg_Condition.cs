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
    public partial class frm_DispProg_Condition : Form
    {
        internal DispProg.TLine CmdLine = new DispProg.TLine();
        DispProg.TLine n_CmdLine = new DispProg.TLine();

        public frm_DispProg_Condition()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopMost = true;
            BringToFront();
        }
        private void frm_DispProg_Condition_Load(object sender, EventArgs e)
        {
            n_CmdLine.Copy(CmdLine);
            Text = "Condition - " + CmdName; 
            UpdateDisplay();
        }

        private string CmdName
        {
            get
            {
                return n_CmdLine.Cmd.ToString();
            }
        }

        public void UpdateDisplay()
        {
            lbl_Condition1.Text = Enum.GetName(typeof(EDispProgCondExec), n_CmdLine.Cond[0]).ToString();
            lbl_Count1.Text = n_CmdLine.Cond[1].ToString();
            lbl_Operator1.Text = Enum.GetName(typeof(EDispProgCondOperand), n_CmdLine.Cond[2]).ToString();

            lbl_Condition2.Text = Enum.GetName(typeof(EDispProgCondExec), n_CmdLine.Cond[0 + 5]).ToString();
            lbl_Count2.Text = n_CmdLine.Cond[1 + 5].ToString();
            lbl_Operator2.Text = Enum.GetName(typeof(EDispProgCondOperand), n_CmdLine.Cond[2 + 5]).ToString();
        }

        private void lbl_Condition1_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Cond1", ref n_CmdLine.Cond[0], EDispProgCondExec.None);
            UpdateDisplay();
        }

        private void lbl_Count1_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Value1", ref n_CmdLine.Cond[1], 0, 10000);
            UpdateDisplay();
        }

        private void lbl_Operator1_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Operator1", ref n_CmdLine.Cond[2], EDispProgCondOperand.Or);
            UpdateDisplay();
        }

        private void lbl_Condition2_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Cond2", ref n_CmdLine.Cond[0 + 5], EDispProgCondExec.None);
            UpdateDisplay();
        }

        private void lbl_Count2_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Value2", ref n_CmdLine.Cond[1 + 5], 0, 10000);
            UpdateDisplay();
        }

        private void lbl_Operator2_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Operator2", ref n_CmdLine.Cond[2 + 5], EDispProgCondOperand.Or);
            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            CmdLine.Copy(n_CmdLine);
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
