using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace NDispWin
{
    internal partial class frm_DispCore_DispSetup_Custom : Form
    {
        public frm_DispCore_DispSetup_Custom()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }
               
        private void frm_DispCore_DispSetup_HeadCal_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
        }

        private void frm_DispCore_DispSetup_HeadCal_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            btn_EditVolumeOfst.Visible = false;

            pnl_VolumeOffsetPath.Visible =
            (TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.AOT_FrontTestCloseLoop ||
             TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.AOT_HeightCloseLoop ||
             TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.Lextar_FrontTestCloseLoop
             );

            lbl_VolumeOfstProtocol.Text = ((int)TaskDisp.VolumeOfst_Protocol).ToString() + " : " + TaskDisp.VolumeOfst_Protocol.ToString();
            lbl_EquipmentID.Text = TaskDisp.VolumeOfst_EqID;
            lbl_LocalPath.Text = TaskDisp.VolumeOfst_LocalPath;
            lbl_DataPath.Text = TaskDisp.VolumeOfst_DataPath;
            lbl_DataPath2.Text = TaskDisp.VolumeOfst_DataPath2;

            lbl_InputMap_Protocol.Text = ((int)TaskDisp.InputMap_Protocol).ToString() + " : " + TaskDisp.InputMap_Protocol.ToString();
            btnInputMapSetup.Visible = TaskDisp.InputMap_Protocol == TaskDisp.EInputMapProtocol.OSRAM_eMos;
            pnl_InputMapPaths_Lmd_EMap.Visible = TaskDisp.InputMap_Protocol == TaskDisp.EInputMapProtocol.Lumileds_EMap;
            lbl_InputMap_DataPath.Text = Task_InputMap.Lumileds_SS_EMap.MapPath[0];
            tbox_Prefix.Text = Task_InputMap.Lumileds_SS_EMap.FilenamePrefix[0];
            tbox_Suffix.Text = Task_InputMap.Lumileds_SS_EMap.FilenameSuffix[0];
            lbl_InputMap_DataPath2.Text = Task_InputMap.Lumileds_SS_EMap.MapPath[1];
            tbox_Prefix2.Text = Task_InputMap.Lumileds_SS_EMap.FilenamePrefix[1];
            tbox_Suffix2.Text = Task_InputMap.Lumileds_SS_EMap.FilenameSuffix[1];
            lbl_InputMap_DataPath3.Text = Task_InputMap.Lumileds_SS_EMap.MapPath[2];
            tbox_Prefix3.Text = Task_InputMap.Lumileds_SS_EMap.FilenamePrefix[2];
            tbox_Suffix3.Text = Task_InputMap.Lumileds_SS_EMap.FilenameSuffix[2];
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        private void lbl_Protocol_Click(object sender, EventArgs e)
        {
            TaskDisp.EVolumeOfstProtocol E = TaskDisp.EVolumeOfstProtocol.None;
            int i = (int)TaskDisp.VolumeOfst_Protocol;
            UC.AdjustExec("DispSetup, VolumeOfst Protocol", ref i, E);
            TaskDisp.VolumeOfst_Protocol = (TaskDisp.EVolumeOfstProtocol)i;

            UpdateDisplay();
        }

        private void lbl_LocalPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = TaskDisp.VolumeOfst_LocalPath;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
                TaskDisp.VolumeOfst_LocalPath = fbd.SelectedPath;

            UpdateDisplay();
        }
        private void lbl_DataPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = TaskDisp.VolumeOfst_DataPath;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
                TaskDisp.VolumeOfst_DataPath = fbd.SelectedPath;

            UpdateDisplay();
        }
        private void lbl_DataPath2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = TaskDisp.VolumeOfst_DataPath2;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
                TaskDisp.VolumeOfst_DataPath2 = fbd.SelectedPath;

            UpdateDisplay();
        }
        private void btn_CheckDataPath_Click(object sender, EventArgs e)
        {
            Color C = Color.Lime;
            if (!Directory.Exists(TaskDisp.VolumeOfst_LocalPath))
                C = Color.Red;
            lbl_LocalPath.BackColor = C;

            C = Color.Lime;
            if (!Directory.Exists(TaskDisp.VolumeOfst_DataPath))
                C = Color.Red;
            lbl_DataPath.BackColor = C;

            C = Color.Lime;
            if (!Directory.Exists(TaskDisp.VolumeOfst_DataPath2))
                C = Color.Red;
            lbl_DataPath2.BackColor = C;

            System.Threading.Thread.Sleep(1000);

            lbl_LocalPath.BackColor = this.BackColor;
            lbl_DataPath.BackColor = this.BackColor;
            lbl_DataPath2.BackColor = this.BackColor;
        }

        private void lbl_EquipmentID_Click(object sender, EventArgs e)
        {
            UC.EntryExec("DispSetup, VolumeOfst Protocol EqID", ref TaskDisp.VolumeOfst_EqID, false);

            UpdateDisplay();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            switch (TaskDisp.VolumeOfst_Protocol)
            {
                default:
                    MessageBox.Show("No Setup Available.");
                    break;
            }
        }

        private void lbl_InputMap_Protocol_Click(object sender, EventArgs e)
        {
            int i_Max = Enum.GetNames(typeof(TaskDisp.EInputMapProtocol)).Length;

            TaskDisp.EInputMapProtocol E = TaskDisp.EInputMapProtocol.None;
            int i = (int)TaskDisp.InputMap_Protocol;
            UC.AdjustExec("DispSetup, Input Map Protocol", ref i, E);
            TaskDisp.InputMap_Protocol = (TaskDisp.EInputMapProtocol)i;

            if (TaskDisp.InputMap_Protocol == TaskDisp.EInputMapProtocol.OSRAM_eMos)
            {
                Task_InputMap.OsramEMos.LoadSetup();
            }
            UpdateDisplay();
        }
        private void lbl_InputMap_DataPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Task_InputMap.Lumileds_SS_EMap.MapPath[0];
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Task_InputMap.Lumileds_SS_EMap.MapPath[0] = fbd.SelectedPath;
                if (!Task_InputMap.Lumileds_SS_EMap.MapPath[0].EndsWith(@"\"))
                    Task_InputMap.Lumileds_SS_EMap.MapPath[0] = Task_InputMap.Lumileds_SS_EMap.MapPath[0] + @"\";
            }

            UpdateDisplay();
        }
        private void lbl_InputMap_DataPath2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Task_InputMap.Lumileds_SS_EMap.MapPath[1];
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Task_InputMap.Lumileds_SS_EMap.MapPath[1] = fbd.SelectedPath;
                if (!Task_InputMap.Lumileds_SS_EMap.MapPath[1].EndsWith(@"\"))
                    Task_InputMap.Lumileds_SS_EMap.MapPath[1] = Task_InputMap.Lumileds_SS_EMap.MapPath[1] + @"\";
            }

            UpdateDisplay();
        }
        private void lbl_InputMap_DataPath3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Task_InputMap.Lumileds_SS_EMap.MapPath[2];
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Task_InputMap.Lumileds_SS_EMap.MapPath[2] = fbd.SelectedPath;
                if (!Task_InputMap.Lumileds_SS_EMap.MapPath[2].EndsWith(@"\"))
                    Task_InputMap.Lumileds_SS_EMap.MapPath[2] = Task_InputMap.Lumileds_SS_EMap.MapPath[2] + @"\";
            }

            UpdateDisplay();
        }

        private void btn_InputMap_CheckDataPath_Click(object sender, EventArgs e)
        {
            lbl_InputMap_DataPath.BackColor = Directory.Exists(Task_InputMap.Lumileds_SS_EMap.MapPath[0]) ? Color.Lime : Color.Red;

           if (Task_InputMap.Lumileds_SS_EMap.MapPath[1].Length > 0)
                lbl_InputMap_DataPath2.BackColor = Directory.Exists(Task_InputMap.Lumileds_SS_EMap.MapPath[1]) ? Color.Lime : Color.Red;

            if (Task_InputMap.Lumileds_SS_EMap.MapPath[2].Length > 0)
                lbl_InputMap_DataPath3.BackColor = Directory.Exists(Task_InputMap.Lumileds_SS_EMap.MapPath[2]) ? Color.Lime : Color.Red;

            System.Threading.Thread.Sleep(1000);

            lbl_InputMap_DataPath.BackColor = Color.White;
            lbl_InputMap_DataPath2.BackColor = Color.White;
            lbl_InputMap_DataPath3.BackColor = Color.White;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (!Task_InputMap.Lumileds_SS_EMap.MapPath[0].EndsWith(@"\"))
                Task_InputMap.Lumileds_SS_EMap.MapPath[0] = Task_InputMap.Lumileds_SS_EMap.MapPath[0] + @"\";
            Task_InputMap.Lumileds_SS_EMap.FilenamePrefix[0] = tbox_Prefix.Text;
            Task_InputMap.Lumileds_SS_EMap.FilenameSuffix[0] = tbox_Suffix.Text;

            if (Task_InputMap.Lumileds_SS_EMap.MapPath[1].Length > 0)
            {
                if (!Task_InputMap.Lumileds_SS_EMap.MapPath[1].EndsWith(@"\"))
                    Task_InputMap.Lumileds_SS_EMap.MapPath[1] = Task_InputMap.Lumileds_SS_EMap.MapPath[1] + @"\";
                Task_InputMap.Lumileds_SS_EMap.FilenamePrefix[1] = tbox_Prefix2.Text;
                Task_InputMap.Lumileds_SS_EMap.FilenameSuffix[1] = tbox_Suffix2.Text;
            }

            if (Task_InputMap.Lumileds_SS_EMap.MapPath[2].Length > 0)
            {
                if (!Task_InputMap.Lumileds_SS_EMap.MapPath[2].EndsWith(@"\"))
                    Task_InputMap.Lumileds_SS_EMap.MapPath[2] = Task_InputMap.Lumileds_SS_EMap.MapPath[2] + @"\";
                Task_InputMap.Lumileds_SS_EMap.FilenamePrefix[2] = tbox_Prefix3.Text;
                Task_InputMap.Lumileds_SS_EMap.FilenameSuffix[2] = tbox_Suffix3.Text;
            }

            UpdateDisplay();
        }

        private void btnInputMapSetup_Click(object sender, EventArgs e)
        {
            if (TaskDisp.InputMap_Protocol == TaskDisp.EInputMapProtocol.OSRAM_eMos)
            {
                frm_Osram_eMos_Setup frm = new frm_Osram_eMos_Setup();
                frm.ShowDialog();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                Task_InputMap.Lumileds_SS_EMap.MapPath[i] = "";
                Task_InputMap.Lumileds_SS_EMap.FilenamePrefix[i] = "";
                Task_InputMap.Lumileds_SS_EMap.FilenameSuffix[i] = "";
            }
            UpdateDisplay();
        }

        private void tbox_Suffix_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
