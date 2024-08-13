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
    internal partial class frmCmdSelect : Form
    {
        public DispProg.ECmd Command = DispProg.ECmd.NONE;

        public frmCmdSelect()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.StartPosition = FormStartPosition.Manual;
        }

        BindingList<string> Cmd = new BindingList<string>();
        BindingList<string> showCmd = new BindingList<string>();

        private void frmCmdSelect_Load(object sender, EventArgs e)
        {
            Text = "Command Select";

            BindingList<string> Cmd = new BindingList<string>();
            foreach (DispProg.ECmd cmd in Enum.GetValues(typeof(DispProg.ECmd)))
            {
                Cmd.Add(cmd.ToString());
            }

            showCmd = new BindingList<string>(Cmd.Select(x => x).ToList());

            UpdateDisplay();
            UpdateCmdList(sender, e);
        }

        private void UpdateDisplay()
        {
            if ((DispProgUI.CommandSelection & 0x1000) == 0x1000) DispProgUI.CommandSelection = 0xFFFF;

            cbAll.Checked = (DispProgUI.CommandSelection & 0x1000) == 0x1000;
            cbLayout.Checked = (DispProgUI.CommandSelection & 0x0002) == 0x0002;
            cbVision.Checked = (DispProgUI.CommandSelection & 0x0004) == 0x0004;
            cbHeight.Checked = (DispProgUI.CommandSelection & 0x0008) == 0x0008;
            cbDisp.Checked = (DispProgUI.CommandSelection & 0x0010) == 0x0010;
            cbMaint.Checked = (DispProgUI.CommandSelection & 0x0020) == 0x0020;
            cbMap.Checked = (DispProgUI.CommandSelection & 0x0040) == 0x0040;
            cbMeasure.Checked = (DispProgUI.CommandSelection & 0x0080) == 0x0080;
            cbVolume.Checked = (DispProgUI.CommandSelection & 0x0100) == 0x0100;

            cbSortAZ.Checked = DispProgUI.CommandSortAZ;
        }

        private void UpdateCmdList(object sender, EventArgs e)
        {
            List<DispProg.ECmd> enabledECmds = DispProgUI.Command.Select(x => (DispProg.ECmd)x).ToList();

            List<DispProg.ECmd> selectedECmds = new List<DispProg.ECmd>();

            foreach (DispProg.ECmd cmd in enabledECmds)
            {
                if (
                    (cbLayout.Checked && (int)cmd > 0 && (int)cmd < 200) ||
                    (cbVision.Checked && (int)cmd >= 200 && (int)cmd < 300) ||
                    (cbHeight.Checked && (int)cmd >= 300 && (int)cmd < 400) ||
                    (cbDisp.Checked && (int)cmd >= 400 && (int)cmd < 500) ||
                    (cbMaint.Checked && (int)cmd >= 500 && (int)cmd < 600) ||
                    (cbMap.Checked && (int)cmd >= 600 && (int)cmd < 700) ||
                    (cbMeasure.Checked && (int)cmd >= 700 && (int)cmd < 800) ||
                    (cbVolume.Checked && (int)cmd >= 800 && (int)cmd < 900)
                    ) 
                    selectedECmds.Add(cmd);
            }

            if (DispProgUI.CommandSortAZ)
                selectedECmds = selectedECmds.OrderBy(x => x.ToString()).ToList();
            else
                selectedECmds = selectedECmds.OrderBy(x => x).ToList();

            showCmd = new BindingList<string>(selectedECmds.Select(x => x.ToString()).ToList());
            lbxCmd.DataSource = showCmd;
            showCmd.ResetBindings();
        }

        private void cbAll_Click(object sender, EventArgs e)
        {
            if ((DispProgUI.CommandSelection & 0x1000) == 0x1000)
            {
                DispProgUI.CommandSelection = 0x00;
            }
            else
                DispProgUI.CommandSelection = 0xFFFF;


            UpdateDisplay();
            UpdateCmdList(sender, e);
        }

        private void cbSortAZ_Click(object sender, EventArgs e)
        {
            DispProgUI.CommandSortAZ = (sender as CheckBox).Checked;

            UpdateCmdList(sender, e);
        }

        private void lbxCmd_Click(object sender, EventArgs e)
        {
            if ((sender as ListBox).SelectedIndex < 0) return;

            string cmdString = (sender as ListBox).SelectedItem.ToString();
            Enum.TryParse(cmdString, out Command);

            DialogResult = DialogResult.OK;
        }

        private void frmCmdSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cbAll.Checked) DispProgUI.CommandSelection = 0x1000;

            if (cbLayout.Checked) DispProgUI.CommandSelection = (DispProgUI.CommandSelection | 0x0002);
            if (cbVision.Checked) DispProgUI.CommandSelection = (DispProgUI.CommandSelection | 0x0004);
            if (cbHeight.Checked) DispProgUI.CommandSelection = (DispProgUI.CommandSelection | 0x0008);
            if (cbDisp.Checked) DispProgUI.CommandSelection = (DispProgUI.CommandSelection | 0x0010);
            if (cbMaint.Checked) DispProgUI.CommandSelection = (DispProgUI.CommandSelection | 0x0020);
            if (cbMap.Checked) DispProgUI.CommandSelection = (DispProgUI.CommandSelection | 0x0040);
            if (cbMeasure.Checked) DispProgUI.CommandSelection = (DispProgUI.CommandSelection | 0x0080);
            if (cbVolume.Checked) DispProgUI.CommandSelection = (DispProgUI.CommandSelection | 0x0100);

            DispProgUI.Save();
        }

        private void btnEditCmd_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_UISetting frm = new frm_DispCore_DispProg_UISetting();
            frm.ShowDialog();
            DispProgUI.Save();
            UpdateCmdList(sender, e);
        }
    }
}
