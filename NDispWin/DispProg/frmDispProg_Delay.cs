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
    internal partial class frm_DispCore_DispProg_Delay : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;

        public frm_DispCore_DispProg_Delay()
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
            lbl_HeadNo.Visible = CmdLine.Cmd == DispProg.ECmd.WAIT;
            lbl_l_HeadNo.Visible = CmdLine.Cmd == DispProg.ECmd.WAIT;

            lbl_HeadNo.Text = CmdLine.ID.ToString();
            lbl_Delay.Text = CmdLine.IPara[0].ToString();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_Delay_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            UpdateDisplay();
        }

        private void frmDispProg_Delay_Shown(object sender, EventArgs e)
        {
        }
        private void frmDispProg_Delay_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void lbl_Delay_Click(object sender, EventArgs e)
        {
            int i = CmdLine.IPara[0];
            UC.AdjustExec(CmdName + ", Delay (ms)", ref i, 0, 100000);
            CmdLine.IPara[0] = i;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_HeadNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Head No", ref CmdLine.ID, 1, 3);
            UpdateDisplay();
        }

        private void frm_DispCore_DispProg_Delay_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }
    }
}
