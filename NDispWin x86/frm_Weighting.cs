using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WGH_Series
{
    public partial class frm_Weighing : Form
    {
        string s_DisplayDecimal = "f6";

        public frm_Weighing()
        {
            InitializeComponent();
            NDispWin.GControl.LogForm(this);

            this.Text = "Weight Dialog " + this.ProductVersion.ToString();

            cbox_WeighingType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TEWeight.EWeighType)).Length; i++)
            {
                cbox_WeighingType.Items.Add(((TEWeight.EWeighType)i).ToString());
            }

            cbox_ComNo.SelectedIndex = 0;
            cbox_WeighingType.SelectedIndex = 0;

            if (TEWeight.IsOpen)
            {
                cbox_ComNo.Text = TEWeight.PortNo;
                cbox_WeighingType.SelectedIndex = (int)TEWeight.TypeWeight;
                gbox_Functions.Visible = true;
            }

            UpdateDisplay();
        }

        private void frm_Weighing_Load(object sender, EventArgs e)
        {
        }

        private void UpdateDisplay()
        {
            btn_ReadStable.Enabled = !b_Pooling;
            btn_ReadImme.Enabled = !b_Pooling;
            btn_Continuous.Enabled = !b_Pooling;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Visible) { return; }

            if (!TEWeight.IsOpen) { return; }
            if (!b_Pooling) { UpdateDisplay(); return; }

            tmr_Read.Stop();

            double gValue = 0;
            try
            {
                TEWeight.ReadImme(ref gValue);
                lbl_Value.Text = gValue.ToString(s_DisplayDecimal) + " g";
            }
            catch
            {
                lbl_Value.Text = "Err";
            }

            tmr_Read.Start();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            b_Pooling = false;
            Close();
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            TEWeight.EWeighType WeightType = (TEWeight.EWeighType)cbox_WeighingType.SelectedIndex;
            try
            {
                TEWeight.Open(cbox_ComNo.Text, WeightType);
                gbox_Functions.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                TEWeight.Close();
                gbox_Functions.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_ReadStable_Click(object sender, EventArgs e)
        {
            try
            {
                double gValue = 0;
                TEWeight.ReadStable(ref gValue);
                lbl_Value.Text = gValue.ToString(s_DisplayDecimal) + " g";
            }
            catch (Exception ex)
            {
                lbl_Value.Text = "Err";
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btn_ReadImme_Click(object sender, EventArgs e)
        {
            try
            {
                double gValue = 0;
                TEWeight.ReadImme(ref gValue);
                lbl_Value.Text = gValue.ToString(s_DisplayDecimal) + " g";
            }
            catch (Exception ex)
            {
                lbl_Value.Text = "Err";
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        private void btn_Taring_Click(object sender, EventArgs e)
        {
            bool b_IsPooling = b_Pooling;
            b_Pooling = false;

            lbl_Value.Text = "-----";

            Enabled = false;
            try
            {
                TEWeight.Tare();
                double gValue = 0;
                TEWeight.ReadImme(ref gValue);
                lbl_Value.Text = gValue.ToString(s_DisplayDecimal) + " g";
            }
            catch (Exception ex)
            {
                lbl_Value.Text = "Err";
                MessageBox.Show(ex.Message.ToString());
            }
            Enabled = true;

            b_Pooling = b_IsPooling;
        }

        bool b_Pooling = false;
        private void btn_Continue_Click(object sender, EventArgs e)
        {
            if (!TEWeight.IsOpen) { return; }

            b_Pooling = true;
            UpdateDisplay();
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            b_Pooling = false;
            UpdateDisplay();
        }

        private void btn_Zero_Click(object sender, EventArgs e)
        {
            bool b_IsPooling = b_Pooling;
            b_Pooling = false;

            lbl_Value.Text = "-----";

            Enabled = false;
            try
            {
                TEWeight.Zero();
                double gValue = 0;
                TEWeight.ReadImme(ref gValue);
                lbl_Value.Text = gValue.ToString(s_DisplayDecimal) + " g";
            }
            catch (Exception ex)
            {
                lbl_Value.Text = "Err";
                MessageBox.Show(ex.Message.ToString());
            }
            Enabled = true;

            b_Pooling = b_IsPooling;
        }
    }
}
