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
    public partial class frm_DesktopSetup : Form
    {
        public frm_DesktopSetup()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_DesktopSetup_Load(object sender, EventArgs e)
        {
            this.Text = "Table Setup";

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblLoadPos.Text = $"{GDefine.Table.LoadPos.X:f3},{GDefine.Table.LoadPos.Y:f3}";
            cbox_CycleRun.Checked = GDefine.Table.CycleRun;
            //combox_NumberOfStations.SelectedIndex = GDefine.Table.NumberOfStations - 1;
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            GDefine.Table.LoadPos.X = NDispWin.TaskGantry.GXPos();
            GDefine.Table.LoadPos.Y = NDispWin.TaskGantry.GYPos();
            UpdateDisplay();
        }
        private void btn_Goto_Click(object sender, EventArgs e)
        {
            GDefine.Table.TaskMoveToLoad();
        }
        private void cbox_CycleRun_Click(object sender, EventArgs e)
        {
            GDefine.Table.CycleRun = !GDefine.Table.CycleRun;
            UpdateDisplay();
        }  
        private void combox_NumberOfStations_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GDefine.Table.NumberOfStations = combox_NumberOfStations.SelectedIndex + 1;
            UpdateDisplay();
        }

        frmJogGantry frm_Jog = new frmJogGantry();
        private void btn_Jog_Click(object sender, EventArgs e)
        {
            frm_Jog = new frmJogGantry();
            frm_Jog.TopMost = true;
            frm_Jog.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GDefine.Table.Save();
            Close();
        }
    }
}
