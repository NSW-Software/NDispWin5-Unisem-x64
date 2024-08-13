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
    public partial class frmLotEntryAnalogPrompt : Form
    {
        public frmLotEntryAnalogPrompt()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void UpdateDisplay()
        {
            tbxBuildSheetNo.Text = LotInfo2.Analog.LoadedRecipeItem.BuildSheetNo;
            tbxProcessBarcode.Text = LotInfo2.Analog.LoadedRecipeItem.ProcessBarcode;
            tbxMaterialPartNo.Text = LotInfo2.Analog.LoadedRecipeItem.MaterialPartNo;
            tbxRecipe.Text = LotInfo2.Analog.LoadedRecipeItem.Recipe;
            tbxHandlerRecipe.Text = LotInfo2.Analog.LoadedRecipeItem.HandlerRecipe;
            tbxPump.Text = LotInfo2.Analog.LoadedRecipeItem.Pump;
            tbxNeedleType.Text = LotInfo2.Analog.LoadedRecipeItem.NeedleType;
            cbSupportBlockUsed.Checked = LotInfo2.Analog.LoadedRecipeItem.SupportBlock != "0";
            rtbxPrompt1.Text = LotInfo2.Analog.LoadedRecipeItem.Prompt1;
            rtbxPrompt2.Text = LotInfo2.Analog.LoadedRecipeItem.Prompt2;
            rtbxRemark1.Text = LotInfo2.Analog.LoadedRecipeItem.Remark1;
            rtbxRemark2.Text = LotInfo2.Analog.LoadedRecipeItem.Remark2;
        }

        private void frmLotEntryAnalogPrompt_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAcknowledge_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
