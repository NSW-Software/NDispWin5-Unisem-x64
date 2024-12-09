using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace NDispWin
{
    internal partial class frm_DispCore_DispSetup_Custom : Form
    {
        public frm_DispCore_DispSetup_Custom()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }
               
        private void frm_DispCore_DispSetup_HeadCal_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
        }

        private void frm_DispCore_DispSetup_HeadCal_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;
            UpdateDisplay();
        }
    }
}
