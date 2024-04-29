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
    public partial class frmSettings: Form
    {
        public frmSettings()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = "Settings";
            PublishForm(new frmIODiag());
        }

        private void btnJog_Click(object sender, EventArgs e)
        {
            frm_DispCore_JogGantry2 frm_Jog2 = new frm_DispCore_JogGantry2();
            frm_Jog2.TopMost = true;
            frm_Jog2.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //frmConfig.UpdateVar();
            GDefine.SaveSystemConfig("");
            GDefine.Table.Save();
            TaskGantry.SaveMotorPara();
            TaskVision.SaveSetup();
            TaskLaser.SaveSetup();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskMoveGZZ2Up();
            Close();
        }

        List<Form> FormList = new List<Form>();
        List<ToolStripButton> Tsi = new List<ToolStripButton>();
        private void PublishForm(Form frm)
        {
            var fx = FormList.FirstOrDefault();
            if (fx != null && fx.GetType() == frm.GetType()) return;
            foreach (var f in FormList)
            {
                f.Close();
                f.Dispose();
            }
            FormList.Clear();
            FormList.Add(frm);

            frm.AutoScroll = true;
            frm.TopMost = false;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Parent = this;
            frm.BringToFront();
            frm.Show();
        }

        private void btnIODiag_Click(object sender, EventArgs e)
        {
            PublishForm(new frmIODiag());
        }

        private void btnMotorDiag_Click(object sender, EventArgs e)
        {
            PublishForm(new frmMotorDiag());
        }

        private void btnMotorConfig_Click(object sender, EventArgs e)
        {
            PublishForm(new frmMotorPara());
        }

        private void btnVision_Click(object sender, EventArgs e)
        {
            PublishForm(new frmVisionSetup());
        }

        //frmSystemConfig frmConfig = new frmSystemConfig();
        private void btnConfig_Click(object sender, EventArgs e)
        {
            PublishForm(new frmSystemConfig());
        }
    }
}
