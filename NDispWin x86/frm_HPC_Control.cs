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
    public partial class frm_HPC_Control : Form
    {
        public int CtrlNo = 0;

        public frm_HPC_Control()
        {
            InitializeComponent();
            GControl.LogForm(this);

            Text = "HPC15";

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void frm_HPC_Control_Load(object sender, EventArgs e)
        {
            HPC15.frm_HPC15 frm = new HPC15.frm_HPC15();

            frm.OptionEnable_ManualCtrl = TaskDisp.Option_HideHPCManualControls;

            frm.TopLevel = false;
            frm.Parent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, pnl_Top.Bottom);
            frm.HPC = TaskDisp.HPC_15[CtrlNo];
            frm.LogPath = GDefine.DataPath + "\\Parameter";
            frm.Show();

            pnl_FPress.Visible = FPressCtrl.Enabled;

            pnl_FPress.Top = frm.Bottom;


            //uctrl_FPress1.SelectCh = CtrlNo + 0;
            //uctrl_FPress2.SelectCh = CtrlNo + 1;
            //uctrl_FPress1.UpdateDisplay();
            //uctrl_FPress2.UpdateDisplay();

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_FPressA.Text = FPressCtrl.GetPress(DispProg.FPress[0]).ToString(FPressCtrl.PressUnitStrFmt);
            lbl_FPressB.Text = FPressCtrl.GetPress(DispProg.FPress[1]).ToString(FPressCtrl.PressUnitStrFmt);
            lbl_FPressUnit.Text = "(" + FPressCtrl.PressUnitStr + ")";
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uctrl_FPress1_Load(object sender, EventArgs e)
        {

        }

        private void lbl_FPressA_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;

            FPressCtrl.AdjustPress_MPa(0, ref DispProg.FPress, d_Min, d_Max);
            UpdateDisplay();
        }

        private void lbl_FPressB_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;

            FPressCtrl.AdjustPress_MPa(1, ref DispProg.FPress, d_Min, d_Max);
            UpdateDisplay();
        }
    }
}
