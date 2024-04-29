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
    internal partial class frm_DispCore_DispProg_WeightCal : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;

        public frm_DispCore_DispProg_WeightCal()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
            TConditions Cond = new TConditions(LineNo, CmdLine);
            lbox_Cond.Items.Clear();
            foreach (string s in Cond.Strings)
            {
                lbox_Cond.Items.Add(s);
            }

            btn_Setting.Visible = CmdLine.Cmd == DispProg.ECmd.WEIGHT_CAL;
        }

        private void frm_DispProg_WeightCal_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            this.Text = CmdName;

            UpdateDisplay();
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            switch (CmdLine.Cmd)
            {
                case DispProg.ECmd.WEIGHT_CAL:
                    frm_DispCore_WeightCal frm = new frm_DispCore_WeightCal();
                    frm.ShowDialog();
                    break;
            }
        }
            private void btn_Exec_Click(object sender, EventArgs e)
        {
            switch (CmdLine.Cmd)
            {
                case DispProg.ECmd.WEIGHT_CAL:
                    frm_DispCore_WeightCal frm = new frm_DispCore_WeightCal();
                    frm.CalMode = frm_DispCore_WeightCal.ECalMode.Auto;
                    frm.ShowDialog();
                    frm.BringToFront();
                    break;
            }
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

        private void btn_Cond_Click(object sender, EventArgs e)
        {
            frm_DispProg_Condition frm = new frm_DispProg_Condition();
            frm.CmdLine.Copy(CmdLine);
            frm.ShowDialog();
            CmdLine.Copy(frm.CmdLine);

            UpdateDisplay();
        }
    }
}
