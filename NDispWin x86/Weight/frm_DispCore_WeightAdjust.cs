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
    public partial class frm_DispCore_WeightAdjust : Form
    {
        double[] NewWeight = new double[2] { 0, 0 };
        public frm_DispCore_WeightAdjust()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;

            //AppLanguage.Func.SetComponent(this);

            this.BringToFront();
        }

        private void frm_DispCore_WeightAdjust_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            btn_Update.Enabled = false;

            NewWeight[0] = DispProg.Disp_Weight[0];
            NewWeight[1] = DispProg.Disp_Weight[1];

            UpdateDisplay();
        }

        string dp4 = "f4";
        private void UpdateDisplay()
        {
            Text = "Weight Adjust";

            lbl_Weight1.Text = DispProg.Disp_Weight[0].ToString(dp4);
            lbl_Weight2.Text = DispProg.Disp_Weight[1].ToString(dp4);
            lbl_CurrentCal1.Text = TaskWeight.CurrentCal[0].ToString(dp4);
            lbl_CurrentCal2.Text = TaskWeight.CurrentCal[1].ToString(dp4);
            lbl_NewWeight1.Text = NewWeight[0].ToString(dp4);
            lbl_NewWeight2.Text = NewWeight[1].ToString(dp4);
        }

        private void lbl_NewWeigh1_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Weight Adjust, Weight 1", ref NewWeight[0], 0, 1000))
                btn_Update.Enabled = true;
            UpdateDisplay();
        }

        private void lbl_NewWeigh2_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Weight Adjust, Weight 2", ref NewWeight[1], 0, 1000))
                btn_Update.Enabled = true;
            UpdateDisplay();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (DispProg.Target_Weight > 0) TaskDisp.PP_SetWeight(NewWeight, true, true);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }

            string s_Old = NewWeight[0].ToString() + "," +  NewWeight[1].ToString();
            string s_New = DispProg.Disp_Weight[0].ToString() + DispProg.Disp_Weight[1].ToString();

            Log.OnAction("Update", "Weight Adjust, New Weight", s_Old, s_New);
            Event.OP_WEIGHT_ADJUST.Set("Weight", s_New);

            btn_Update.Enabled = false;
            UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
