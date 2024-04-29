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
    internal partial class frmDeviceIOConfigEditor : Form
    {
        enum EEditMode { Input, Output };
        EEditMode EditMode = EEditMode.Input;

        public CControl2.TInput Input = new CControl2.TInput();
        public CControl2.TOutput Output = new CControl2.TOutput();

        private void updateCombox()
        {
            combox_Device.Items.Clear();
            combox_Device.Items.Add(TaskGantry.Device_0.Name);
            combox_Device.Items.Add(TaskGantry.Device_1.Name);

            combox_AxisPort.Items.Clear();
            for (int i = 0; i < 9; i++)
            {
                combox_AxisPort.Items.Add(i.ToString() + " (0x" + i.ToString("X2") + ")");
            }

            combox_Mask.Items.Clear();
            for (int i = 0; i < 16; i++)
            {
                int h = (int)Math.Pow(2, i);
                combox_Mask.Items.Add(h.ToString() + " (0x" + h.ToString("X4") + ")");
            }

            combox_MotorNo.Items.Clear();
            for (int i = 1; i <= 8; i++)
            {
                combox_MotorNo.Items.Add("M" + i.ToString());
            }
        }

        public frmDeviceIOConfigEditor()
        {
            InitializeComponent();
            GControl.LogForm(this);

            updateCombox();
            Close();
        }
        public frmDeviceIOConfigEditor(CControl2.TInput _Input)
        {
            InitializeComponent();
            GControl.LogForm(this);
            
            updateCombox();
            EditMode = EEditMode.Input;
            Input = _Input;
        }
        public frmDeviceIOConfigEditor(CControl2.TOutput _Output)
        {
            InitializeComponent();
            GControl.LogForm(this);
            
            updateCombox();
            EditMode = EEditMode.Output;
            Output = _Output;
        }

        private void frmDeviceConfigEditor_Load(object sender, EventArgs e)
        {
            combox_IONo.Items.Clear();
            for (int i = 0; i < 16; i++)
            {
                if (EditMode == EEditMode.Input)
                {
                    combox_IONo.Items.Add("DI" + i.ToString("00"));
                }
                if (EditMode == EEditMode.Output)
                {
                    combox_IONo.Items.Add("D0" + (i + 4).ToString("00"));
                }
            }

            if (EditMode == EEditMode.Input)
            {
                Text = "Device IO Editor [" + Input.Name + "]";

                if (Input.Device.Type == TaskGantry.Device_0.Type || Input.Device.ID == TaskGantry.Device_0.ID) combox_Device.SelectedIndex = 0;
                if (Input.Device.Type == TaskGantry.Device_1.Type || Input.Device.ID == TaskGantry.Device_1.ID) combox_Device.SelectedIndex = 1; 



                combox_AxisPort.SelectedIndex = (int)Input.Axis_Port;
                combox_MotorNo.SelectedIndex = combox_AxisPort.SelectedIndex;

                int i = -1;
                switch (Input.Mask)
                {
                    #region
                    case 0x0001: i = 0; break;
                    case 0x0002: i = 1; break;
                    case 0x0004: i = 2; break;
                    case 0x0008: i = 3; break;
                    case 0x0010: i = 4; break;
                    case 0x0020: i = 5; break;
                    case 0x0040: i = 6; break;
                    case 0x0080: i = 7; break;
                    case 0x0100: i = 8; break;
                    case 0x0200: i = 9; break;
                    case 0x0400: i = 10; break;
                    case 0x0800: i = 11; break;
                    case 0x1000: i = 12; break;
                    case 0x2000: i = 13; break;
                    case 0x4000: i = 14; break;
                    case 0x8000: i = 15; break;
                    #endregion
                }                
                combox_Mask.SelectedIndex = i;
                combox_IONo.SelectedIndex = i;

                tbox_Label.Text = Input.Label;
            }
            if (EditMode == EEditMode.Output)
            {
                Text = "Device Editor [" + Output.Name + "]";

                if (Output.Device.Type == TaskGantry.Device_0.Type || Output.Device.ID == TaskGantry.Device_0.ID) combox_Device.SelectedIndex = 0;
                if (Output.Device.Type == TaskGantry.Device_1.Type || Output.Device.ID == TaskGantry.Device_1.ID) combox_Device.SelectedIndex = 1;

                combox_AxisPort.SelectedIndex = (int)Output.Axis_Port;
                combox_MotorNo.SelectedIndex = combox_AxisPort.SelectedIndex;

                int i = -1;
                switch (Output.Mask)
                {
                    #region
                    case 0x0001: i = 0; break;
                    case 0x0002: i = 1; break;
                    case 0x0004: i = 2; break;
                    case 0x0008: i = 3; break;
                    case 0x0010: i = 4; break;
                    case 0x0020: i = 5; break;
                    case 0x0040: i = 6; break;
                    case 0x0080: i = 7; break;
                    case 0x0100: i = 8; break;
                    case 0x0200: i = 9; break;
                    case 0x0400: i = 10; break;
                    case 0x0800: i = 11; break;
                    case 0x1000: i = 12; break;
                    case 0x2000: i = 13; break;
                    case 0x4000: i = 14; break;
                    case 0x8000: i = 15; break;
                    #endregion
                }
                combox_Mask.SelectedIndex = i;
                combox_IONo.SelectedIndex = i;

                tbox_Label.Text = Output.Label;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (EditMode == EEditMode.Input)
            {
                if (combox_Device.SelectedIndex == 0) Input.Device = TaskGantry.Device_0;
                if (combox_Device.SelectedIndex == 1) Input.Device = TaskGantry.Device_1;

                Input.Axis_Port = (byte)combox_AxisPort.SelectedIndex;
                Input.Mask = (ushort)Math.Pow(2, combox_Mask.SelectedIndex);
                Input.Label = tbox_Label.Text;
            }
            if (EditMode == EEditMode.Output)
            {
                if (combox_Device.SelectedIndex == 0) Output.Device = TaskGantry.Device_0;
                if (combox_Device.SelectedIndex == 1) Output.Device = TaskGantry.Device_1;

                Output.Axis_Port = (byte)combox_AxisPort.SelectedIndex;
                Output.Mask = (ushort)Math.Pow(2, combox_Mask.SelectedIndex);
                Output.Label = tbox_Label.Text;
            }
            DialogResult = DialogResult.OK;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void combox_IONo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            combox_Mask.SelectedIndex = combox_IONo.SelectedIndex;
        }

        private void combox_MotorNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            combox_AxisPort.SelectedIndex = combox_MotorNo.SelectedIndex;
        }
    }
}
