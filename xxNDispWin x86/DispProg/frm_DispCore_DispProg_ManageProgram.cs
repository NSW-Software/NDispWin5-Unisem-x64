using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DispCore
{
    public partial class frmManageProgram : Form
    {
        public frmManageProgram()
        {
            InitializeComponent();
        }

        private void frmManageProgram_Load(object sender, EventArgs e)
        {

        }

        private void RefreshProgramList()
        {
            lbox_Program.Items.Clear();

            
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
