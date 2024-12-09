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
    public partial class frm_MHS2ElevIO : Form
    {
        public frm_MHS2ElevIO()
        {
            InitializeComponent();
            GControl.LogForm(this);

            AppLanguage.Func2.WriteLangFile(this);
        }

        private void frm_ElevIO_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            btn_Save.Visible = this.Modal;
            btn_Close.Visible = this.Modal;
        }

        private void UpdateStatus()
        {
            #region
            GDefineMHS.RefreshInput(lbl_Left_SensLZHome, ElevIO.SensLZHome);
            GDefineMHS.RefreshInput(lbl_Left_SensDoor, ElevIO.Left_SensDoor);
            GDefineMHS.RefreshInput(lbl_LP_PusherHome, ElevIO.LP_PusherHome);
            GDefineMHS.RefreshInput(lbl_LP_PusherLmt, ElevIO.LP_PusherLmt);
            GDefineMHS.RefreshInput(lbl_LZ_MtrAlm, ElevIO.LZ_MtrAlm);
            GDefineMHS.RefreshOutput(btn_LZ_MtrOn, ElevIO.LZAxis.MotorStatus);

            GDefineMHS.RefreshInput(lbl_Left_SensMagPsnt1, ElevIO.Left_SensMagPsnt1);
            GDefineMHS.RefreshInput(lbl_Left_SensMagPsnt2, ElevIO.Left_SensMagPsnt2);
            GDefineMHS.RefreshInput(lbl_Left_SensMagPsnt3, ElevIO.Left_SensMagPsnt3);
            GDefineMHS.RefreshInput(lbl_Left_SensMagPsnt4, ElevIO.Left_SensMagPsnt4);
            //GDefine.RefreshInput(lbl_Ax2SDI5, ElevIO.Ax2SDI5);
            GDefineMHS.RefreshOutput(btn_CW_MtrOn, ElevIO.CWAxis.MotorStatus);

            GDefineMHS.RefreshInput(lbl_Right_SensRZHome, ElevIO.SensRZHome);
            GDefineMHS.RefreshInput(lbl_Right_SensDoor, ElevIO.Right_SensDoor);
            //GDefine.RefreshInput(lbl_Ax3SDI3, ElevIO.Right_PusherHome);
            //GDefine.RefreshInput(lbl_Ax3SDI4, ElevIO.Right_PusherLmt);
            GDefineMHS.RefreshInput(lbl_RZ_MtrAlm, ElevIO.RZ_MtrAlm);
            GDefineMHS.RefreshOutput(btn_RZ_MtrOn, ElevIO.RZAxis.MotorStatus);

            GDefineMHS.RefreshInput(lbl_Right_SensMagPsnt1, ElevIO.Right_SensMagPsnt1);
            GDefineMHS.RefreshInput(lbl_Right_SensMagPsnt2, ElevIO.Right_SensMagPsnt2);
            GDefineMHS.RefreshInput(lbl_Right_SensMagPsnt3, ElevIO.Right_SensMagPsnt3);
            GDefineMHS.RefreshInput(lbl_Right_SensMagPsnt4, ElevIO.Right_SensMagPsnt4);
            //GDefine.RefreshInput(lbl_Ax4SDI5, ElevIO.Ax4SDI5);
            GDefineMHS.RefreshOutput(btn_LP_MtrOn, ElevIO.LPAxis.MotorStatus);

            GDefineMHS.RefreshInput(lbl_LP_PusherJam, ElevIO.LP_PusherJam);
            //GDefine.RefreshInput(lbl_DI2, ElevIO.DI2);
            //GDefine.RefreshInput(lbl_DI3, ElevIO.DI3);
            //GDefine.RefreshInput(lbl_DI4, ElevIO.DI4);
            //GDefine.RefreshInput(lbl_DI5, ElevIO.DI5);
            //GDefine.RefreshInput(lbl_DI6, ElevIO.DI6);
            //GDefine.RefreshInput(lbl_DI7, ElevIO.DI7);

            GDefineMHS.RefreshOutput(btn_LP_PusherRun, ElevIO.LP_PusherRun);
            GDefineMHS.RefreshOutput(btn_LP_PusherRev, ElevIO.LP_PusherRev);
            //GDefine.RefreshOutput(lbl_DO3, ElevIO.DO3);
            //GDefine.RefreshOutput(lbl_DO4, ElevIO.DO4);
            //GDefine.RefreshOutput(lbl_DO5, ElevIO.DO5);
            //GDefine.RefreshOutput(lbl_DO6, ElevIO.DO6);
            //GDefine.RefreshOutput(lbl_DO7, ElevIO.DO7);
            //GDefine.RefreshOutput(lbl_DO8, ElevIO.DO8);
            #endregion
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_BoardID.Text = "Board ID" + ElevIO.BoardID.ToString();
            lbl_BoardID.BackColor = ZEC3002.Ctrl.BoardOpened(ElevIO.BoardID) ? Color.Lime : Color.Red;

            if (TaskElev.BoardIsOpen) UpdateStatus();
        }

        private void btn_LZAxisMtrOn_Click(object sender, EventArgs e)
        {
            ElevIO.MtrOnOff(ref ElevIO.LZAxis, !ElevIO.LZAxis.MotorStatus);
        }
        private void btn_Ax2MtrOn_Click(object sender, EventArgs e)
        {
            ElevIO.MtrOnOff(ref ElevIO.CWAxis, !ElevIO.CWAxis.MotorStatus);
        }
        private void btn_RZAxisMtrOn_Click(object sender, EventArgs e)
        {
            ElevIO.MtrOnOff(ref ElevIO.RZAxis, !ElevIO.RZAxis.MotorStatus);
        }
        private void btn_LPAxisMtrOn_Click(object sender, EventArgs e)
        {
            ElevIO.MtrOnOff(ref ElevIO.LPAxis, !ElevIO.LPAxis.MotorStatus);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ElevIO.SaveDIOAdd(GDefine.MHSDIOAddFile);
            ElevIO.SaveMotorPara(GDefine.MHSMotorParaFile);
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_PusherRun_Click(object sender, EventArgs e)
        {
            TaskElev.Left.OutPusherRun = !TaskElev.Left.OutPusherRun;
        }
        private void btn_PusherRev_Click(object sender, EventArgs e)
        {
            TaskElev.Left.OutPusherRet = !TaskElev.Left.OutPusherRet;
        }

        ToolTip toolTip = new ToolTip();
        private void controlIO_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                toolTip.Show(ElevIO.NameGetInputInfo(((Label)sender).Name), (Label)sender);
            }
            if (sender is Button)
            {
                toolTip.Show(ElevIO.NameGetOutputInfo(((Button)sender).Name), (Button)sender);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
