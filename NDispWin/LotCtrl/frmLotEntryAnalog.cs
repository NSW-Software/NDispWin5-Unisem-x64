using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    public partial class frmLotEntryAnalog : Form
    {
        public frmLotEntryAnalog()
        {
            InitializeComponent();

            gbox_DateTime.BringToFront();

            LotInfo2.Analog.RecipeTable.LoadSetup();
            LotInfo2.Analog.RecipeTable.LoadRecipeTable();

            if (LotInfo2.Analog.MachineNo == "") LotInfo2.Analog.MachineNo = LotInfo2.Analog.DefaultMachineNo;

            StartPosition = FormStartPosition.CenterScreen;
        }

        void ClearData()
        {
            LotInfo2.Analog.DeviceName = "";
            LotInfo2.Analog.LotNo = "";
            LotInfo2.Analog.BuildSheetNo = "";
            LotInfo2.Analog.ProcessBarcode = "";
            LotInfo2.Analog.SubstratePartNo = "";
            LotInfo2.Analog.MaterialPartNo = "";
            LotInfo2.Analog.MaterialLotNo = "";
            LotInfo2.Analog.MaterialExpiryDate = "";
            LotInfo2.Analog.OperatorID = "";
            LotInfo2.Analog.Shift = "";
        }

        void UpdateDisplay()
        {
            tbxDeviceName.Text = LotInfo2.Analog.DeviceName;
            tbxLotNo.Text = LotInfo2.Analog.LotNo;
            tbxBuildSheetNo.Text = LotInfo2.Analog.BuildSheetNo;
            tbxProcessBarcode.Text = LotInfo2.Analog.ProcessBarcode;
            tbxSubstratePartNo.Text = LotInfo2.Analog.SubstratePartNo;
            tbxMaterialPartNo.Text = LotInfo2.Analog.MaterialPartNo;
            tbxMaterialLotNo.Text = LotInfo2.Analog.MaterialLotNo;
            tbxMaterialExpiryDate.Text = LotInfo2.Analog.MaterialExpiryDate;
            tbxOperatorID.Text = LotInfo2.Analog.OperatorID;
            tbxShift.Text = LotInfo2.Analog.Shift;
            tbxMachineNo.Text = LotInfo2.Analog.MachineNo;
        }

        void EnableControls(bool enabled)
        {
            tbxDeviceName.Enabled =
            tbxLotNo.Enabled =
            tbxBuildSheetNo.Enabled =
            tbxProcessBarcode.Enabled =
            tbxSubstratePartNo.Enabled =
            tbxMaterialPartNo.Enabled =
            tbxMaterialLotNo.Enabled =
            tbxMaterialExpiryDate.Enabled =
            tbxOperatorID.Enabled =
            tbxShift.Enabled =
            tbxMachineNo.Enabled = enabled;

            btnStartLot.Enabled = btnClear.Enabled = btnSetup.Enabled = enabled;
            btnEndLot.Enabled = !enabled;
        }


        private void frmLotEntryAnalog_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            Utils.DisableNumCapslock();

            UpdateDisplay();
            EnableControls(LotInfo2.LotStatus != LotInfo2.ELotStatus.Activated);

            if (tbxLotNo.Text.Length == 0) tbxLotNo.Focus();
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            Utils.DisableNumCapslock();

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if ((sender as TextBox).Name.Contains("DeviceName")) tbxLotNo.Focus();
                if ((sender as TextBox).Name.Contains("LotNo")) tbxBuildSheetNo.Focus();
                if ((sender as TextBox).Name.Contains("BuildSheetNo")) tbxProcessBarcode.Focus();
                if ((sender as TextBox).Name.Contains("ProcessBarcode")) tbxSubstratePartNo.Focus();
                if ((sender as TextBox).Name.Contains("SubstratePartNo")) tbxMaterialPartNo.Focus();
                if ((sender as TextBox).Name.Contains("MaterialPartNo")) tbxMaterialLotNo.Focus();
                if ((sender as TextBox).Name.Contains("MaterialLotNo"))
                {
                    if (LotInfo2.Analog.ManualExpiryEntry)
                    {
                        btnMaterialExpiryDate_Click(sender, e);
                    }
                    else
                        tbxMaterialExpiryDate.Focus();
                }
                if ((sender as TextBox).Name.Contains("MaterialExpiryDate")) tbxOperatorID.Focus();
                if ((sender as TextBox).Name.Contains("OperatorID")) tbxShift.Focus();
                if ((sender as TextBox).Name.Contains("Shift"))
                {
                    if (tbxMachineNo.Text.Length > 0) btnStartLot.Focus();
                    else
                        tbxMachineNo.Focus();
                }
                if ((sender as TextBox).Name.Contains("MachineNo")) btnStartLot.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
            UpdateDisplay();
            tbxDeviceName.Focus();
        }

        private void btnStartLot_Click(object sender, EventArgs e)
        {
            if (tbxDeviceName.Text.Length == 0 ||
            tbxLotNo.Text.Length == 0 ||
            tbxBuildSheetNo.Text.Length == 0 ||
            tbxProcessBarcode.Text.Length == 0 ||
            tbxSubstratePartNo.Text.Length == 0 ||
            tbxMaterialPartNo.Text.Length == 0 ||
            tbxMaterialLotNo.Text.Length == 0 ||
            tbxMaterialExpiryDate.Text.Length == 0 ||
            tbxOperatorID.Text.Length == 0 ||
            tbxShift.Text.Length == 0 ||
            tbxMachineNo.Text.Length == 0)
            {
                MessageBox.Show("Lot Info detail is not complete. Pls fill in all information.");

                if (tbxLotNo.Text.Length == 0) { tbxLotNo.Focus(); return; }
                if (tbxBuildSheetNo.Text.Length == 0) { tbxBuildSheetNo.Focus(); return; }
                if (tbxProcessBarcode.Text.Length == 0) { tbxProcessBarcode.Focus(); return; }
                if (tbxSubstratePartNo.Text.Length == 0) { tbxSubstratePartNo.Focus(); return; }
                if (tbxMaterialPartNo.Text.Length == 0) { tbxMaterialPartNo.Focus(); return; }
                if (tbxMaterialLotNo.Text.Length == 0) { tbxMaterialLotNo.Focus(); return; }
                if (tbxMaterialExpiryDate.Text.Length == 0) { tbxMaterialExpiryDate.Focus(); return; }
                if (tbxOperatorID.Text.Length == 0) { tbxOperatorID.Focus(); return; }
                if (tbxShift.Text.Length == 0) { tbxShift.Focus(); return; }
                if (tbxMachineNo.Text.Length == 0) { tbxMachineNo.Focus(); return; }

                return;
            }

            if (!LotInfo2.Analog.RecipeTable.LookupRecipe(tbxBuildSheetNo.Text, tbxProcessBarcode.Text, tbxMaterialPartNo.Text))
            {
                MessageBox.Show("No matching Recipe found.");
                return;
            }

            LotInfo2.Analog.DeviceName = tbxDeviceName.Text;
            LotInfo2.Analog.LotNo = tbxLotNo.Text;
            LotInfo2.Analog.BuildSheetNo = tbxBuildSheetNo.Text;
            LotInfo2.Analog.ProcessBarcode = tbxProcessBarcode.Text;
            LotInfo2.Analog.SubstratePartNo = tbxSubstratePartNo.Text;
            LotInfo2.Analog.MaterialPartNo = tbxMaterialPartNo.Text;
            LotInfo2.Analog.MaterialLotNo = tbxMaterialLotNo.Text;
            LotInfo2.Analog.MaterialExpiryDate = tbxMaterialExpiryDate.Text;
            LotInfo2.Analog.OperatorID = tbxOperatorID.Text;
            LotInfo2.Analog.Shift = tbxShift.Text;
            LotInfo2.Analog.MachineNo = tbxMachineNo.Text;

            if (LotInfo2.Analog.LoadedRecipeItem.Recipe.Length == 0)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Auto Load - Invalid Recipe.");
                return;
            }
            if (LotInfo2.Analog.LoadedRecipeItem.HandlerRecipe.Length == 0)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Auto Load - Invalid Hanlder Recipe.");
                return;
            }

            string recipeFilename = GDefine.RecipeDir.FullName + LotInfo2.Analog.LoadedRecipeItem.Recipe + GDefine.RecipeExt;
            string hRecipeFilename = GDefine.MHSRecipePath + "\\" + LotInfo2.Analog.LoadedRecipeItem.HandlerRecipe + GDefine.MHSRecipeExt;

            if (!File.Exists(recipeFilename))
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Auto Load - Recipe Program not found.");
                return;
            }
            if (!File.Exists(hRecipeFilename))
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Auto Load - Handler Recipe not found.");
                return;
            }

            frmLotEntryAnalogPrompt frm = new frmLotEntryAnalogPrompt();
            if (frm.ShowDialog()  == DialogResult.Cancel)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Program Information Cancelled.");
                return;
            }

            if (!DispProg.LoadProgName(LotInfo2.Analog.LoadedRecipeItem.Recipe)) return;
            TaskMHS.LoadRecipe(LotInfo2.Analog.LoadedRecipeItem.HandlerRecipe);

            LotInfo2.Analog.LogStart();
            LotInfo2.LotStatus = LotInfo2.ELotStatus.Activated;

            UpdateDisplay();
            EnableControls(false);

            btnClose.Focus();
        }

        private void btnEndLot_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm End Lot?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LotInfo2.Analog.LogEnd();
                LotInfo2.LotStatus = LotInfo2.ELotStatus.Deactivated;

                ClearData();

                UpdateDisplay();
                EnableControls(true);
                tbxDeviceName.Focus();
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            frmLotEntryAnalogSetup frm = new frmLotEntryAnalogSetup();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_dtpOK_Click(object sender, EventArgs e)
        {
            TaskDisp.Material_Life_EndTime = dtp_ExpiryDate.Value.Date.Add(dtp_ExpiryTime.Value.TimeOfDay);
            TaskDisp.Material_LifePreAlert_Time = TaskDisp.Material_Life_EndTime.AddMinutes((double)-TaskDisp.Material_ExpiryPreAlertTime);
            gbox_DateTime.Visible = false;
            LotInfo2.Analog.MaterialExpiryDate = TaskDisp.Material_Life_EndTime.ToString("yyyy/MM/dd HH:mm");
            tbxMaterialExpiryDate.Text = LotInfo2.Analog.MaterialExpiryDate;

            tbxOperatorID.Focus();
        }

        private void btnMaterialExpiryDate_Click(object sender, EventArgs e)
        {
            if (LotInfo2.Analog.ManualExpiryEntry)
            {
                gbox_DateTime.Location = tbxMaterialExpiryDate.Location;
                dtp_ExpiryDate.Value = DateTime.Now.AddHours(LotInfo2.Analog.DefaultMaterialLife);
                dtp_ExpiryTime.Value = DateTime.Now.AddHours(LotInfo2.Analog.DefaultMaterialLife);
                gbox_DateTime.Visible = true;
                btn_dtpOK.Focus();
            }
        }

        private void frmLotEntryAnalog_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}