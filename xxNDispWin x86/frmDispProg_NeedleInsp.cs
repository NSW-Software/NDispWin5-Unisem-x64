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
    internal partial class frmDispProg_NeedleInsp : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frmDispProg_NeedleInsp()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frmDispProg_NeedleInsp_Load(object sender, EventArgs e)
        {

            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);


            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            Text = CmdName;
            //CmdLine.Cmd = $"Command - {DispProg.ECmd.PURGE}";

            UpdateDisplay();
        }
        private void frmDispProg_NeedleInsp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }
        private void UpdateDisplay()
        {
            TConditions Cond = new TConditions(LineNo, CmdLine);
            lbox_Cond.Items.Clear();
            foreach (string s in Cond.Strings)
            {
                lbox_Cond.Items.Add(s);
            }
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }
        private void btn_Cond_Click(object sender, EventArgs e)
        {
            frm_DispProg_Condition frm = new frm_DispProg_Condition();
            frm.CmdLine.Copy(CmdLine);
            frm.ShowDialog();
            CmdLine.Copy(frm.CmdLine);

            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            Log.OnAction("OK", CmdName);
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void btnExecP1_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskNeedleInsp(1);
        }

        private void btnExecP2_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskNeedleInsp(2);
        }
    }
}
