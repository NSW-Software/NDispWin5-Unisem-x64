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
    public partial class frm_AOT_TestCloseLoop : Form
    {
        public enum EType { Prompt, Info, }
        public EType Type = EType.Info;

        public string TestFile = "";
        public DateTime Time;
        public double M1 = 0;
        public double M2 = 0;
        public double T1 = 0;
        public double T2 = 0;
        public double D1 = 0;
        public double D2 = 0;
        public double O1 = 0;
        public double O2 = 0;

        public frm_AOT_TestCloseLoop()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.Text = "AOT_TestCloseLoop";
        }

        private void frm_AOT_TestCloseLoop_Load(object sender, EventArgs e)
        {
            lbl_Message1.Text = "Last uolume Offset" + "\r\n" + "前補償數據";

            lbl_l_TestFile.Text = "TestFile" + "\r\n" + "前測檔案";
            lbl_l_Time.Text = "update Time" + "\r\n" + "更新時間";
            lbl_Needle.Text = "Needle" + "\r\n" + "針";
            lbl_MedianY.Text = "Test Median Y" + "\r\n" + "Y 前測中位數";
            lbl_TargetY.Text = "Test Target Y" + "\r\n" + "Y 前測中心";
            lbl_Diff.Text = "Difference Y" + "\r\n" + "Y 误差";
            lbl_Adjustment.Text = "uolume Offset (ul)" + "\r\n" + "點膠補償重量 (μl)";
            lbl_Message2.Text = "update uolume Offset?" + "\r\n" + "更新重量補償？";

            switch (Type)
            {
                case EType.Info:
                    lbl_Message1.Visible = true;
                    lbl_Message2.Visible = false;
                    btn_Yes.Visible = false;
                    btn_No.Visible = false;
                    btn_Close.Visible = true;
                    break;
                case EType.Prompt:
                    lbl_Message1.Visible = false;
                    lbl_Message2.Visible = true;
                    btn_Yes.Visible = true;
                    btn_No.Visible = true;
                    btn_Close.Visible = false;
                    break;
            }
            updateDisplay();
        }

        private void updateDisplay()
        {
            lbl_TestFile.Text = TestFile;
            if (Time.Year > 2000)
                lbl_Time.Text = Time.ToString();
            else
                lbl_Time.Text = "none";
            lbl_M1.Text = M1.ToString("f3");
            lbl_M2.Text = M2.ToString("f3");
            lbl_T1.Text = T1.ToString("f3");
            lbl_T2.Text = T2.ToString("f3");
            lbl_D1.Text = D1.ToString("f3");
            lbl_D2.Text = D2.ToString("f3");

            if (O1 <= 0)
                lbl_O1.Text = O1.ToString("f3");
            else
                lbl_O1.Text = "+" + O1.ToString("f3");

            if (O2 <= 0)
                lbl_O2.Text = O2.ToString("f3");
            else
                lbl_O2.Text = "+" + O2.ToString("f3");
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void lbl_Adjustment_Click(object sender, EventArgs e)
        {

        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
