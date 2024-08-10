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
    internal partial class frm_DispCore_DispProg_ReadID_ManualEntry : Form
    {
        public string ID = "";

        public frm_DispCore_DispProg_ReadID_ManualEntry()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.KeyPreview = true;
        }

        private void frm_DispCore_DispProg_ReadID_ManualEntry_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Read ID Manual Entry";

            tbox_Text.Text = "";
            tbox_Text.Select();
       }
        private void frm_DispCore_DispProg_ReadID_ManualEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            IO.SetState(EMcState.Mute);
        }
        private void frm_DispCore_DispProg_ReadID_ManualEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            ID = tbox_Text.Text;
            Log.OnAction("Entry", "Read ID " + (char)9 + ID);   
            DialogResult = DialogResult.OK;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ID = "";
            DialogResult = DialogResult.Cancel;
        }
        private void btn_Retry_Click(object sender, EventArgs e)
        {
            ID = "";
            DialogResult = DialogResult.Retry;
        }
        private void btn_Mute_Click(object sender, EventArgs e)
        {
            IO.SetState(EMcState.Mute);
            tbox_Text.Select();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            ID = "";
            DialogResult = DialogResult.Ignore;//  Skip
        }
    }
}
