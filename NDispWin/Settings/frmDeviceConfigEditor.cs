using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using CControl;

namespace NDispWin
{
    internal partial class frmDeviceConfigEditor : Form
    {
        public CControl2.TDevice Device = new CControl2.TDevice();

        public frmDeviceConfigEditor()
        {
            InitializeComponent();
            Close();
        }

        public frmDeviceConfigEditor(CControl2.TDevice _Device, string Title)
        {
            InitializeComponent();
            GControl.LogForm(this);

            Text = "Device Config Editor [" + Title + "]";

            combox_Type.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(CControl2.EDeviceType)).Length; i++)
            {
                string S = Enum.GetName(typeof(CControl2.EDeviceType), i);
                combox_Type.Items.Add(S);
            }

            combox_ID.Items.Clear();
            for (int i = 0; i < 4; i++)
            {
                combox_ID.Items.Add(i.ToString() + " (0x" + i.ToString("X2") + ")");
            }

            Device = _Device;
        }

        private void frmDeviceConfigEditor_Load(object sender, EventArgs e)
        {
            combox_Type.SelectedIndex = (int)Device.Type;
            combox_ID.SelectedIndex = (int)Device.ID;
            updateDisplay();
        }

        private void updateDisplay()
        {
            tbox_IPAddress.Text = Device.IPAddress;
            tbox_Label.Text = Device.Label;
            tbox_Name.Text = Device.Name;

            switch (Device.Type)
            {
                case CControl2.EDeviceType.PISO:
                case CControl2.EDeviceType.P1240:
                case CControl2.EDeviceType.P1245:
                case CControl2.EDeviceType.P1265:
                case CControl2.EDeviceType.P1285:
                    l_lbl_ID.Visible = true;
                    combox_ID.Visible = true;
                    l_lbl_IPAddress.Visible = false;
                    tbox_IPAddress.Visible = false;
                    l_lbl_Label.Visible = true;
                    tbox_Label.Visible = true;
                    l_lbl_Name.Visible = true;
                    tbox_Name.Visible = true;
                    break;
                case CControl2.EDeviceType.ZKAZM302:
                case CControl2.EDeviceType.ZKAZM304:
                case CControl2.EDeviceType.ZKAZIO3001:
                    l_lbl_ID.Visible = true;
                    combox_ID.Visible = true;
                    l_lbl_IPAddress.Visible = true;
                    tbox_IPAddress.Visible = true;
                    l_lbl_Label.Visible = true;
                    tbox_Label.Visible = true;
                    l_lbl_Name.Visible = true;
                    tbox_Name.Visible = true;
                    break;
                default:
                    l_lbl_ID.Visible = false;
                    combox_ID.Visible = false;
                    l_lbl_IPAddress.Visible = false;
                    tbox_IPAddress.Visible = false;
                    l_lbl_Label.Visible = false;
                    tbox_Label.Visible = false;
                    l_lbl_Name.Visible = false;
                    tbox_Name.Visible = false;
                    break;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void combox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device.Type = (CControl2.EDeviceType)combox_Type.SelectedIndex;
            string S = Enum.GetName(typeof(CControl2.EDeviceType), Device.Type);
            Device.Name = S + "_" + Device.ID.ToString();
            updateDisplay();
        }
        private void combox_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device.ID = (byte)(CControl2.EDeviceType)combox_ID.SelectedIndex;
            string S = Enum.GetName(typeof(CControl2.EDeviceType), Device.Type);
            Device.Name = S + "_" + Device.ID.ToString();
            updateDisplay();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
