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
    public partial class frmCLEditor : Form
    {
        string name = "";
        public double[] Value = new double[] { 0, 0 };
        double min = 0;
        double max = 0;

        public frmCLEditor()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }
        public frmCLEditor(string name, double[] value, double min, double max)
        {
            InitializeComponent();

            TopMost = true;
            this.name = name;
            this.Value = value;
            this.min = min;
            this.max = max;
        }
        public frmCLEditor(string name, uint[] value, uint min, uint max)
        {
            InitializeComponent();

            TopMost = true;
            this.name = name;
            this.Value = new double[] { value[0], value[1] };
            this.min = min;
            this.max = max;
        }

        private void frmCLEditor_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            Text = "Contorl Limit Editor";
            lblCL0.Text = $"{Value[0]}";
            lblCL1.Text = $"{Value[1]}";
        }

        private void lblCL0_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(name, ref Value[0], min, max);
            UpdateDisplay();
        }

        private void lblCL1_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(name, ref Value[1], min, max);
            UpdateDisplay();
        }
    }
}
