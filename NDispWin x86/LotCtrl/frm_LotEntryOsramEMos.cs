using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    public partial class frm_LotEntryOsramEMos : Form
    {
        public frm_LotEntryOsramEMos()
        {
            InitializeComponent();
        }

        private void frm_LotEntryOsramType2_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            Text = "Lot Entry Osram EMos";

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            bool Enabled = LotInfo2.LotStatus != LotInfo2.ELotStatus.Activated;
            tbox_LotNumber.Enabled = Enabled;
            tbox_11Series.Enabled = Enabled;
            tbox_EmployeeID.Enabled = Enabled;
            tbox_DAStartNumber.Enabled = Enabled;

            btn_StartLot.Enabled = Enabled;
            btn_EndLot.Enabled = !Enabled;

            tbox_LotNumber.Text = LotInfo2.LotNumber;
            tbox_11Series.Text = LotInfo2.Osram.ElevenSeries;
            tbox_EmployeeID.Text = LotInfo2.sOperatorID;
            tbox_DAStartNumber.Text = LotInfo2.Osram.DAStartNumber;
        }

        private void UpdateVar()
        {
            LotInfo2.LotNumber = tbox_LotNumber.Text;
            LotInfo2.Osram.ElevenSeries = tbox_11Series.Text;
            LotInfo2.sOperatorID = tbox_EmployeeID.Text;
            LotInfo2.Osram.DAStartNumber = tbox_DAStartNumber.Text;
        }

        private void btn_StartLot_Click(object sender, EventArgs e)
        {
            UpdateVar();

            if (LotInfo2.sOperatorID.Length == 0)
            {
                MessageBox.Show("Please enter Employee ID.", "Error", MessageBoxButtons.OK);
                tbox_EmployeeID.Focus();
                return;
            }
            if (LotInfo2.LotNumber.Length == 0)
            {
                MessageBox.Show("Please enter Lot Number.", "Error", MessageBoxButtons.OK);
                tbox_LotNumber.Focus();
                return;
            }
            if (LotInfo2.Osram.ElevenSeries.Length == 0)
            {
                MessageBox.Show("Please enter 11-Series.", "Error", MessageBoxButtons.OK);
                tbox_11Series.Focus();
                return;
            } 
            if (LotInfo2.Osram.DAStartNumber.Length == 0)
            {
                MessageBox.Show("Please enter DA Start Number.", "Error", MessageBoxButtons.OK);
                tbox_DAStartNumber.Focus();
                return;
            }

            bool loadOK = false;
            MsgBox.Processing("Load Dispense Recipe in Progress. Please wait.", LoadRecipe);
            void LoadRecipe()
            {
                string RecipeName = LotInfo2.Osram.DAStartNumber;
                if (RecipeName.Length == 0)
                {
                    Event.OP_DISP_AUTO_LOAD_DEVICE_INVALID.Set();
                    Msg MsgBox = new Msg();
                    MsgBox.Show("Auto Load - Invalid Recipe.");
                    return;
                }
                else
                if (RecipeName.Length >= 0)
                {
                    string fileName = GDefine.RecipeDir.FullName + RecipeName + GDefine.RecipeExt;
                    if (!File.Exists(fileName))
                    {
                        Event.OP_DISP_AUTO_LOAD_DEVICE_NO_FOUND.Set("Name", fileName);
                        Msg MsgBox = new Msg();
                        MsgBox.Show("Auto Load - Recipe not found.");
                        return;
                    }
                    else
                    {
                        if (!DispProg.LoadProgName(RecipeName)) return;
                    }
                }

                GDefineN.PerformanceReset();
                Stats.Reset();

                Event.OP_DISP_AUTO_LOAD_SUCCESSFUL.Set("File", GDefine.ProgRecipeName);
                loadOK = true;
            }
            if (!loadOK)
            {
                return;
            }

            LotInfo2.LotActive = true;
            Event.OP_LOT_START.Set("LotInfo", $"{LotInfo2.sOperatorID},{LotInfo2.LotNumber},{LotInfo2.Osram.ElevenSeries},{LotInfo2.Osram.DAStartNumber}");

            UpdateDisplay();

            btn_Close.Focus();
        }
        private void btn_EndLot_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm End Lot?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LotInfo2.LotActive = false;
                Event.OP_LOT_END.Set("LotInfo", $"{LotInfo2.sOperatorID},{LotInfo2.LotNumber},{LotInfo2.Osram.ElevenSeries},{LotInfo2.Osram.DAStartNumber}");

                LotInfo2.LotNumber = "";
                LotInfo2.Osram.ElevenSeries = "";
                LotInfo2.sOperatorID = "";
                LotInfo2.Osram.DAStartNumber = "";

                UpdateDisplay();

                tbox_EmployeeID.Focus();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void tbox_EmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbox_LotNumber.Focus();
            }
        }
        private void tbox_LotNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbox_11Series.Focus();
            }
        }
        private void tbox_11Series_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tbox_DAStartNumber.Focus();
            }
        }
        private void tbox_DAStartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btn_StartLot.Focus();
            }
        }

        private void tbox_11Series_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
