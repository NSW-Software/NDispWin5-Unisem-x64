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
    public partial class frmMHS2PromptNewDIO : Form
    {
        public frmMHS2PromptNewDIO()
        {
            InitializeComponent();
            GControl.LogForm(this);

            combox_McModel.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(ConvIO.EMHS2McModel)).Length; i++)
                combox_McModel.Items.Add(Enum.GetName(typeof(ConvIO.EMHS2McModel), i).ToString());
            combox_McModel.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Configuration";
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            switch (combox_McModel.SelectedIndex)
            {
                default:
                    ConvIO.SetA25XDIOAdd();
                    break;
                case 1:
                    ConvIO.SetA30XDIOAdd();
                    break;
            }
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
