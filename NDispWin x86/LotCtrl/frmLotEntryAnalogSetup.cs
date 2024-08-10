using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDispWin
{
    public partial class frmLotEntryAnalogSetup : Form
    {
        public frmLotEntryAnalogSetup()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmLotEntryAnalogSetup_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            lbxRecipeItem.DataSource = LotInfo2.Analog.RecipeTable.RecipeItem;
            btnUpdate.Enabled = false;

            UpdateDisplay();
        }

        int selectedIndex = 0;

        private void UpdateDisplay()
        {
            tbxMachineNo.Text = LotInfo2.Analog.DefaultMachineNo;
            cbManualExpiry.Checked = LotInfo2.Analog.ManualExpiryEntry;
            nudMaterialLife.Value = (decimal)LotInfo2.Analog.DefaultMaterialLife;

            tbxBuildSheetNo.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].BuildSheetNo;
            tbxProcessBarcode.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].ProcessBarcode;
            tbxMaterialPartNo.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].MaterialPartNo;
            tbxRecipe.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Recipe;
            tbxHandlerRecipe.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].HandlerRecipe;
            tbxPump.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Pump;
            tbxNeedleType.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].NeedleType;
            cbSupportBlockUsed.Checked = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].SupportBlock != "0";
            rtbxPrompt1.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Prompt1;
            rtbxPrompt2.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Prompt2;
            rtbxRemark1.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Remark1;
            rtbxRemark2.Text = LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Remark2;
        }
        private void UpdateVars()
        {
            LotInfo2.Analog.DefaultMachineNo = tbxMachineNo.Text;
            LotInfo2.Analog.ManualExpiryEntry = cbManualExpiry.Checked;
            LotInfo2.Analog.DefaultMaterialLife = (int)nudMaterialLife.Value;
        }

        private void lbxRecipeItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxRecipeItem.SelectedIndex >= 0)
            {
                if (btnUpdate.Enabled)
                {
                    if (lbxRecipeItem.SelectedIndex != selectedIndex)
                    {
                        btnUpdate_Click(sender, e);
                    }
                }
                selectedIndex = lbxRecipeItem.SelectedIndex;
            }

            UpdateDisplay();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].BuildSheetNo = tbxBuildSheetNo.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].ProcessBarcode = tbxProcessBarcode.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].MaterialPartNo = tbxMaterialPartNo.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Recipe = tbxRecipe.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].HandlerRecipe = tbxHandlerRecipe.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Pump = tbxPump.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].NeedleType = tbxNeedleType.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].SupportBlock = cbSupportBlockUsed.Checked ? "1" : "0";
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Prompt1 = rtbxPrompt1.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Prompt2 = rtbxPrompt2.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Remark1 = rtbxRemark1.Text;
            LotInfo2.Analog.RecipeTable.RecipeItem[selectedIndex].Remark2 = rtbxRemark2.Text;

            LotInfo2.Analog.RecipeTable.RecipeItem.ResetBindings();
            btnUpdate.Enabled = false;
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".csv";
            ofd.InitialDirectory = GDefine.AppPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LotInfo2.Analog.RecipeTable.LoadRecipeTable(ofd.FileName);
                LotInfo2.Analog.RecipeTable.RecipeItem.ResetBindings();
                UpdateDisplay();
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            UpdateVars();

            LotInfo2.Analog.RecipeTable.SaveSetup();
            LotInfo2.Analog.RecipeTable.SaveRecipeTable();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            UpdateVars();

            Close();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            LotInfo2.Analog.RecipeTable.MoveUp(selectedIndex);
        }
        private void btnMoveDn_Click(object sender, EventArgs e)
        {
            LotInfo2.Analog.RecipeTable.MoveDn(selectedIndex);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            LotInfo2.Analog.RecipeTable.Delete(selectedIndex);
        }

        private void tbxBuildSheetNo_MouseDown(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
        }

        private void lblMaterialExpiryPreAlert_Click(object sender, EventArgs e)
        {
        }

        private void tbxMachineNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
