using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispCore
{
    public partial class frm_InfoPanel2x3_Program : Form
    {
        public frm_InfoPanel2x3_Program()
        {
            InitializeComponent();
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            lbl_Flowrate1.Text = TaskWeight.CurrentCal[0].ToString("f4");
            lbl_Flowrate2.Text = TaskWeight.CurrentCal[1].ToString("f4");
        }
    }
}
