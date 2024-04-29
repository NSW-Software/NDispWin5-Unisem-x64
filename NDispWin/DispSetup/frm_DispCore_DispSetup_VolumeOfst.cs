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

namespace DispCore
{
    internal partial class frm_DispCore_DispSetup_VolumeOfst : Form
    {
        public frm_DispCore_DispSetup_VolumeOfst()
        {
            InitializeComponent();
            AppLanguage.Func.SetComponent(this);
        }
               
        private void frm_DispCore_DispSetup_HeadCal_Load(object sender, EventArgs e)
        {
            //CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            //this.Text = "Command - " + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Cmd).ToString();
        }

        private void frm_DispCore_DispSetup_HeadCal_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            //string Protocol = "None";
            //switch (TaskDisp.VolumeOfst_Protocol)
            //{
            //    default:
            //        break;
            //    case 1: Protocol = "Custom_AOT_HeightCloseLoop"; break;
            //    case 2: Protocol = "Custom_AOT_FrontTestCloseLoop"; break;
            //    case 3: Protocol = "Custom_OSRAM_SCC"; break;
            //}
            lbl_VolumeOfstProtocol.Text = ((int)TaskDisp.VolumeOfst_Protocol).ToString() + " : " + TaskDisp.VolumeOfst_Protocol.ToString();

            lbl_EquipmentID.Text = TaskDisp.VolumeOfst_EqID;
            lbl_LocalPath.Text = TaskDisp.VolumeOfst_LocalPath;
            lbl_DataPath.Text = TaskDisp.VolumeOfst_DataPath;
            lbl_DataPath2.Text = TaskDisp.VolumeOfst_DataPath2;

            btn_EditVolumeOfst.Visible = (TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.OSRAM_SCC);


            lbl_InputMap_Protocol.Text = ((int)TaskDisp.InputMap_Protocol).ToString() + " : " + TaskDisp.InputMap_Protocol.ToString();
            lbl_InputMap_LocalPath.Text = TaskDisp.InputMap_LocalPath;
            lbl_InputMap_DataPath.Text = TaskDisp.InputMap_DataPath;
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        private void lbl_Protocol_Click(object sender, EventArgs e)
        {
            int i_Max = Enum.GetNames(typeof(TaskDisp.EVolumeOfstProtocol)).Length;

            int i = (int)TaskDisp.VolumeOfst_Protocol;

            GDefine.uc.UserAdjustExecute("Protocol", ref i, 0, i_Max - 1);

            TaskDisp.VolumeOfst_Protocol = (TaskDisp.EVolumeOfstProtocol)i;


            if (TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.OSRAM_SCC)
            {
                TaskDisp.OsramSCC.LoadSetup();
            }
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

            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);

            lbl_LocalPath.BackColor = this.BackColor;
            lbl_DataPath.BackColor = this.BackColor;
            lbl_DataPath2.BackColor = this.BackColor;
        }

        private void lbl_EquipmentID_Click(object sender, EventArgs e)
        {
            GDefine.uc.KeyBoardExecute(ref TaskDisp.VolumeOfst_EqID, false);

            UpdateDisplay();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            TaskDisp.OsramSCC.ShowWindow();
        }

        private void lbl_InputMap_Protocol_Click(object sender, EventArgs e)
        {
            int i_Max = Enum.GetNames(typeof(TaskDisp.EInputMapProtocol)).Length;

            int i = (int)TaskDisp.InputMap_Protocol;
            GDefine.uc.UserAdjustExecute("Input Map Protocol", ref i, 0, i_Max - 1);
            TaskDisp.InputMap_Protocol = (TaskDisp.EInputMapProtocol)i;

            UpdateDisplay();
        }
        private void lbl_InputMap_DataPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = TaskDisp.InputMap_DataPath;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
                TaskDisp.InputMap_DataPath = fbd.SelectedPath;

            UpdateDisplay();
        }
        private void lbl_InputMap_LocalPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = TaskDisp.InputMap_LocalPath;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
                TaskDisp.InputMap_LocalPath = fbd.SelectedPath;

            UpdateDisplay();
        }

        private void btn_InputMap_CheckDataPath_Click(object sender, EventArgs e)
        {
            Color C = Color.Lime;
            if (!Directory.Exists(TaskDisp.InputMap_DataPath))
                C = Color.Red;
            lbl_InputMap_DataPath.BackColor = C;

            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);

            lbl_InputMap_DataPath.BackColor = this.BackColor;
        }
    }
}
