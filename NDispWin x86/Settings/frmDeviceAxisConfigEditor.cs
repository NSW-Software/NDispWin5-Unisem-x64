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
    internal partial class frmDeviceAxisConfigEditor : Form
    {
        public CControl2.TAxis Axis = new CControl2.TAxis();

        public frmDeviceAxisConfigEditor()
        {
            InitializeComponent();
            GControl.LogForm(this);

            Close();
        }
        public frmDeviceAxisConfigEditor(CControl2.TAxis _Axis)
        {
            InitializeComponent();
            GControl.LogForm(this);

            combox_Device.Items.Clear();
            combox_Device.Items.Add(TaskGantry.Device_0.Name);
            combox_Device.Items.Add(TaskGantry.Device_1.Name);

            combox_Mask.Items.Clear();
            for (int i = 0; i < 9; i++)
            {
                combox_Mask.Items.Add(i.ToString() + " (0x" + i.ToString("X2") + ")");
            }
            Axis = _Axis;

            combox_MotorNo.Items.Clear();
            for (int i = 1; i <= 8; i++)
            {
                combox_MotorNo.Items.Add("M" + i.ToString());
            }
        }
        private void frmDeviceAxisConfigEditor_Load(object sender, EventArgs e)
        {
            Text = "Device Axis Editor [" + Axis.Name + "]";

            if (Axis.Device.Type == TaskGantry.Device_0.Type && Axis.Device.ID == TaskGantry.Device_0.ID) combox_Device.SelectedIndex = 0;
            if (Axis.Device.Type == TaskGantry.Device_1.Type && Axis.Device.ID == TaskGantry.Device_1.ID) combox_Device.SelectedIndex = 1;

            combox_MotorNo.SelectedIndex = (int)Axis.Mask;
            combox_Mask.SelectedIndex = (int)Axis.Mask;
            tbox_Label.Text = Axis.Label;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (combox_Device.SelectedIndex == 0) Axis.Device = TaskGantry.Device_0;
            if (combox_Device.SelectedIndex == 1) Axis.Device = TaskGantry.Device_1;

            Axis.Mask = (byte)combox_Mask.SelectedIndex;
            Axis.Label = tbox_Label.Text;

            DialogResult = DialogResult.OK;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void combox_Device_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbox_Label_TextChanged(object sender, EventArgs e)
        {

        }

        private void combox_MotorNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            combox_Mask.SelectedIndex = combox_MotorNo.SelectedIndex;
        }
    }
}
