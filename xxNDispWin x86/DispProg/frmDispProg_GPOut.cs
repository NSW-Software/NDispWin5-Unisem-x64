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
    internal partial class frmDispCore_DispProg_GPOut : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;

        public frmDispCore_DispProg_GPOut()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            AppLanguage.Func2.UpdateText(this);
        }

        private void UpdateDisplay()
        {
            lbl_GPOutNo.Text = CmdLine.ID.ToString();
            lbl_State.Text = CmdLine.IPara[0].ToString();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_GPOut_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            UpdateDisplay();
        }

        private void lbl_GPOutNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", GPOutNo", ref CmdLine.ID, 1, 6);
            UpdateDisplay();
        }

        private void lbl_State_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", State", ref CmdLine.IPara[0], 0, 1);
            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
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
    }
}
