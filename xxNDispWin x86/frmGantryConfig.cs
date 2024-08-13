using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DispCore
{
    public partial class frmSystemConfig : Form
    {
        public frmSystemConfig()
        {
            InitializeComponent();
            UpdateCombox();

            combox_GantryConfigType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.EGantryConfigType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.EGantryConfigType), i);
                combox_GantryConfigType.Items.Add(s);
            }
            combox_ZSensorType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.EZSensorType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.EZSensorType), i);
                combox_ZSensorType.Items.Add(s);
            }
            combox_XYSensorType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.EXYSensorType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.EXYSensorType), i);
                combox_XYSensorType.Items.Add(s);
            }
            combox_CleanStType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.ECleanStType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.ECleanStType), i);
                combox_CleanStType.Items.Add(s);
            }
            combox_PurgeStType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.EPurgeStType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.EPurgeStType), i);
                combox_PurgeStType.Items.Add(s);
            }
            combox_PreDispStType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.EPreDispStType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.EPreDispStType), i);
                combox_PreDispStType.Items.Add(s);
            }
            combox_WeightStType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.EWeightStType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.EWeightStType), i);
                combox_WeightStType.Items.Add(s);
            }
            combox_WeightComport.Items.Clear();
            for (int i = 1; i < 17; i++)
            {
                combox_WeightComport.Items.Add(i.ToString());
            }
            combox_CameraType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.ECameraType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.ECameraType), i);
                combox_CameraType.Items.Add(s);
            }
            combox_LCType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.ELCType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.ELCType), i);
                combox_LCType.Items.Add(s);
            }
            combox_LCComport.Items.Clear();
            for (int i = 1; i < 17; i++)
            {
                combox_LCComport.Items.Add(i.ToString());
            }
            combox_HeightSensorType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(GDefine.EHeightSensorType)).Count(); i++)
            {
                string s = Enum.GetName(typeof(GDefine.EHeightSensorType), i);
                combox_HeightSensorType.Items.Add(s);
            }
            combox_HeightSensorComport.Items.Clear();
            for (int i = 1; i < 17; i++)
            {
                combox_HeightSensorComport.Items.Add(i.ToString());
            }
        }

        private void UpdateCombox()
        {
            combox_GantrySystem.Items.Clear();
            combox_GantrySystem.Items.Add("Custom");
            if (Directory.Exists(GDefine.ConfigPath))
            {
                string[] files = Directory.GetFiles(GDefine.ConfigPath);
                if (files.Count() > 0)
                {
                    string ConfigName = "";
                    foreach (string s in files)
                    {
                        ConfigName = s;
                        if (!ConfigName.Contains("Gantry.Config.")) continue;
                        ConfigName = Path.GetFileNameWithoutExtension(s);
                        ConfigName = ConfigName.Replace("Gantry.Config.", "");
                        combox_GantrySystem.Items.Add(ConfigName);
                    }
                }
            }
            combox_GantrySystem.SelectedIndex = 0;
        }

        private void UpdateDisplay()
        {
            GDefine.UpdateInfo(lbl_Device0Info, TaskGantry.Device_0);
            GDefine.UpdateInfo(lbl_Device1Info, TaskGantry.Device_1);
        }

        private void frmGantryConfig_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void frmGantryConfig_Load()
        {

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            GDefine.LoadSystemConfig(combox_GantrySystem.Text);
            UpdateDisplay();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            //combox_GantrySystem.SelectedIndex = 0;
            //GDefine.SaveSystemConfig("");
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = GDefine.ConfigPath;
            sfd.Filter = "GantryConfig|*.ini";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string ConfigName = sfd.FileName;
                ConfigName = Path.GetFileNameWithoutExtension(ConfigName);
                GDefine.SaveSystemConfig(ConfigName);
                UpdateCombox();
            }
        }

        private void lbl_Device0Info_Click(object sender, EventArgs e)
        {
            frmDeviceConfigEditor frm = new frmDeviceConfigEditor(TaskGantry.Device_0);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry.Device_0 = frm.Device;
        }
        private void lbl_Device1Info_Click(object sender, EventArgs e)
        {
            frmDeviceConfigEditor frm = new frmDeviceConfigEditor(TaskGantry.Device_1);
            if (frm.ShowDialog() == DialogResult.OK) TaskGantry.Device_1 = frm.Device;
        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            combox_GantrySystem.SelectedIndex = 0;
            GDefine.SaveSystemConfig("");
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }





    }
}

