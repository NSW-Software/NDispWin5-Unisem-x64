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
    internal partial class frmDoRefCheck : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frmDoRefCheck()
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

            lbl_RefID.Text = CmdLine.ID.ToString();
            lbl_MinScore.Text = (CmdLine.DPara[0] * 100).ToString("F0");
            lbl_XYTol.Text = CmdLine.DPara[1].ToString("F3");
        }
        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDoRefCheck_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = CmdName;

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            TaskVision.LightingOn(TaskVision.LightRGB[CmdLine.ID]);

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };


            UpdateDisplay();
        }
        private void frmDoRefCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
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

        private void lbl_RefID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", RefID", ref CmdLine.ID, 0, TaskVision.MAX_REF_TEMPLATE);
            UpdateDisplay();
        }
        private void btn_Cond_Click(object sender, EventArgs e)
        {
            frm_DispProg_Condition frm = new frm_DispProg_Condition();
            frm.CmdLine.Copy(CmdLine);
            frm.ShowDialog();
            CmdLine.Copy(frm.CmdLine);

            UpdateDisplay();
        }
        private void lbl_MinScore_Click(object sender, EventArgs e)
        {
            int i = (int)(CmdLine.DPara[0] * 100);
            UC.AdjustExec(CmdName + ", Min Score (%)", ref i, 1, 99);
            CmdLine.DPara[0] = (double)i / 100;
            UpdateDisplay();
        }
        private void lbl_XYTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", XY Tol (mm)", ref CmdLine.DPara[1], 0, 5);
            UpdateDisplay();
        }
    }
}
