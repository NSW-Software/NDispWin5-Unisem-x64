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
    internal partial class frm_DispCore_DispProg_PurgeClean : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;

        public frm_DispCore_DispProg_PurgeClean()
        {
            InitializeComponent();
            GControl.LogForm(this);

            Label Auto = new Label(); Auto.AccessibleDescription = "Auto"; Auto.Visible = false; this.Controls.Add(Auto);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            //AppLanguage.Func.SetComponent(this);
        }

        private void UpdateDisplay()
        {
            TConditions Cond = new TConditions(LineNo, CmdLine);
            lbox_Cond.Items.Clear();
            foreach (string s in Cond.Strings)
            {
                lbox_Cond.Items.Add(s);
            }

            int Time = 0;
            int Wait = 0;
            int Count = 0;
            int PostVacTime = 0;
            if (CmdLine.Cmd == DispProg.ECmd.PURGE)
            {
                Count = TaskDisp.Needle_Purge_Count;
                Time = TaskDisp.Needle_Purge_Time;
                Wait = TaskDisp.Needle_Purge_Wait;
                PostVacTime = TaskDisp.Needle_Purge_PostVacTime;
            }
            if (CmdLine.Cmd == DispProg.ECmd.CLEAN)
            {
                Count = TaskDisp.Needle_Clean_Count;
                Time = TaskDisp.Needle_Clean_Time;
                Wait = TaskDisp.Needle_Clean_Wait;
                PostVacTime = TaskDisp.Needle_Clean_PostVacTime;
            }

            lbl_Time.Enabled = CmdLine.IPara[2] != 0;
            lbl_Delay.Enabled = CmdLine.IPara[2] != 0;
            lbl_PostVacTime.Enabled = CmdLine.IPara[2] != 0;
            lblPurgeStageCount.Text = $"{CmdLine.IPara[5]}"; 

            if (CmdLine.IPara[2] == 0)
            {
                lbl_Count.Text = "(A) " + Count.ToString();
                lbl_Time.Text = "(A) " + Time.ToString();
                lbl_Delay.Text = "(A) " + Wait.ToString();
                lbl_PostVacTime.Text = "(A) " + PostVacTime.ToString();
            }
            else
            {
                lbl_Count.Text = CmdLine.IPara[2].ToString();
                lbl_Time.Text = CmdLine.IPara[0].ToString();
                lbl_Delay.Text = CmdLine.IPara[1].ToString();
                lbl_PostVacTime.Text = CmdLine.IPara[3].ToString();
            }
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_Purge_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            Text = CmdName;

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            if (CmdLine.Cmd == DispProg.ECmd.PURGE)
                this.Text = "Command - PURGE";
            if (CmdLine.Cmd == DispProg.ECmd.CLEAN)
                this.Text = "Command - CLEAN";

            UpdateDisplay();
        }

        private void lbl_Time_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PurgeClean, Time", ref CmdLine.IPara[0], 0, 10000);
            UpdateDisplay();
        }

        private void lbl_Delay_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PurgeClean, Delay", ref CmdLine.IPara[1], 0, 5000);
            UpdateDisplay();
        }

        private void lbl_Count_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PurgeClean, Count", ref CmdLine.IPara[2], 0, 100);
            UpdateDisplay();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PurgeClean, Post Vac Time", ref CmdLine.IPara[3], 0, 5000);
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

        private void frm_DispCore_DispProg_PurgeClean_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void btn_Setup_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispSetup_CleanPurge frm = new frm_DispCore_DispSetup_CleanPurge();
            frm.ShowDialog();
        }

        private void btn_Cond_Click(object sender, EventArgs e)
        {
            frm_DispProg_Condition frm = new frm_DispProg_Condition();
            frm.CmdLine.Copy(CmdLine);
            frm.ShowDialog();
            CmdLine.Copy(frm.CmdLine);

            UpdateDisplay();
        }

        private void lbox_Cond_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
