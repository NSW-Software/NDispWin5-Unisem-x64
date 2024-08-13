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
    public partial class frm_Osram_eMos_Setup : Form
    {
        public frm_Osram_eMos_Setup()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_Osram_eMos_Setup_Load(object sender, EventArgs e)
        {
            Text = "Osram eMos Setup";

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            //cbox_Enable.Checked = Task_InputMap.Enabled;
            tbox_ProcessName.Text = Task_InputMap.OsramEMos.ProcessName;
            tbox_APAName.Text = Task_InputMap.OsramEMos.APAName;
            tbox_MapRequestPath.Text = Task_InputMap.OsramEMos.MapRequestPath;
            tbox_ETVUpdatePath.Text = Task_InputMap.OsramEMos.ETVUpdatePath;
            try { nud_TimeOut.Value = Task_InputMap.OsramEMos.TimeOut_s; } catch { }
            cbox_Rework.Checked = Task_InputMap.OsramEMos.Rework;
        }

        private void UpdateVars()
        {
            //if (cbox_Enable.Checked != Task_InputMap.Enabled)
            //    Log.OnAction("Change", "InputMap_OsramEMos.Enable", cbox_Enable.Checked.ToString(), Task_InputMap.Enabled.ToString());
            //Task_InputMap.Enabled = cbox_Enable.Checked;

            if (tbox_ProcessName.Text != Task_InputMap.OsramEMos.ProcessName)
                Log.OnAction("Change", "InputMap_OsramEMos.ProcessName", tbox_ProcessName.Text, Task_InputMap.OsramEMos.ProcessName);
            Task_InputMap.OsramEMos.ProcessName = tbox_ProcessName.Text;

            if (tbox_APAName.Text != Task_InputMap.OsramEMos.APAName)
                Log.OnAction("Change", "Task_InputMap.OsramEMos.APAName", tbox_APAName.Text, Task_InputMap.OsramEMos.APAName);
            Task_InputMap.OsramEMos.APAName = tbox_APAName.Text;

            tbox_MapRequestPath.Text += tbox_MapRequestPath.Text.EndsWith(@"\") ? "" : @"\";
            if (tbox_MapRequestPath.Text != Task_InputMap.OsramEMos.MapRequestPath)
            {
                Log.OnAction("Change", "Task_InputMap.OsramEMos.MapRequestPath", tbox_MapRequestPath.Text, Task_InputMap.OsramEMos.MapRequestPath);
                Task_InputMap.OsramEMos.MapRequestPath = tbox_MapRequestPath.Text;
            }

            tbox_ETVUpdatePath.Text += tbox_ETVUpdatePath.Text.EndsWith(@"\") ? "" : @"\";
            if (tbox_ETVUpdatePath.Text != Task_InputMap.OsramEMos.ETVUpdatePath)
                Log.OnAction("Change", "Task_InputMap.OsramEMos.ETVUpdatePath", tbox_ETVUpdatePath.Text, Task_InputMap.OsramEMos.ETVUpdatePath);
            Task_InputMap.OsramEMos.ETVUpdatePath = tbox_ETVUpdatePath.Text;

            if (nud_TimeOut.Value != Task_InputMap.OsramEMos.TimeOut_s)
                Log.OnAction("Change", "Task_InputMap.OsramEMos.TimeOut_ms", (double)nud_TimeOut.Value, Task_InputMap.OsramEMos.TimeOut_s);
            Task_InputMap.OsramEMos.TimeOut_s = (int)nud_TimeOut.Value;

            if (cbox_Rework.Checked != Task_InputMap.OsramEMos.Rework)
                Log.OnAction("Change", "Task_InputMap.OsramEMos.Rework", cbox_Rework.Checked, Task_InputMap.OsramEMos.Rework);
            Task_InputMap.OsramEMos.Rework = cbox_Rework.Checked;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            UpdateVars();
            Task_InputMap.OsramEMos.SaveSetup();
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_MapRequestPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Task_InputMap.OsramEMos.MapRequestPath;
            if (fbd.ShowDialog() == DialogResult.OK)
                Task_InputMap.OsramEMos.MapRequestPath = fbd.SelectedPath;
            Task_InputMap.OsramEMos.MapRequestPath += Task_InputMap.OsramEMos.MapRequestPath.EndsWith(@"\") ? "" : @"\";

            UpdateDisplay();
        }

        private void btn_ETVUpdatePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Task_InputMap.OsramEMos.ETVUpdatePath;
            if (fbd.ShowDialog() == DialogResult.OK)
                Task_InputMap.OsramEMos.ETVUpdatePath = fbd.SelectedPath;
            Task_InputMap.OsramEMos.ETVUpdatePath += Task_InputMap.OsramEMos.ETVUpdatePath.EndsWith(@"\") ? "" : @"\";
            UpdateDisplay();
        }

        private async void btn_MapRequest_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    Task_InputMap.OsramEMos.SendMapRequest(s_MapID, tbox_Lot.Text, tbox_Operator.Text, tbox_MatNo.Text, Task_InputMap.OsramEMos.Rework);
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }
            MessageBox.Show("Map Request - Success.");
        }

        int[,] Map = new int[TLayout.MAX_RC, TLayout.MAX_RC];
        Size MapSize = new Size(1, 1);
        private void btn_DecodeMap_Click(object sender, EventArgs e)
        {
            try
            {
                Task_InputMap.OsramEMos.DecodeMap(s_MapID, ref Map, ref MapSize);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }
            MessageBox.Show("Decode Map - Success.");
        }

        private void btn_WriteETV_Click(object sender, EventArgs e)
        {
            try
            {
                Task_InputMap.OsramEMos.WriteETVFile(s_MapID, Map, MapSize);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }
            MessageBox.Show("Write ETV - Success.");
        }

        private void btn_GenerateErrorFile_Click(object sender, EventArgs e)
        {
            Task_InputMap.OsramEMos.GenErrorFile(s_MapID);
        }

        private void btn_GenMapFile_Click(object sender, EventArgs e)
        {
        }

        private void cbox_Rework_Click(object sender, EventArgs e)
        {
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateVars();
        }

        string s_MapID = "";
        private void tbox_MapID_TextChanged(object sender, EventArgs e)
        {
            s_MapID = tbox_MatNo.Text + "-" + tbox_FrameID.Text;
            lblFilename.Text = s_MapID;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
