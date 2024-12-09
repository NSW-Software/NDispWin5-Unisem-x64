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
    public partial class frm_MHS2ConvIO : Form
    {
        public frm_MHS2ConvIO()
        {
            InitializeComponent();
            GControl.LogForm(this);

            AppLanguage.Func2.WriteLangFile(this);
        }

        private void frm_ConvIO_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            btn_Save.Visible = this.Modal;
            btn_Close.Visible = this.Modal;
        }

        private void UpdateStatus()
        {
            if (TaskConv.BoardIsOpen)
            {
                GDefineMHS.RefreshInput(lbl_In_SensPsnt, TaskConv.In.SensPsnt);
                GDefineMHS.RefreshInput(lbl_In_SensLFPsnt, TaskConv.In.SensLFPsnt);
                GDefineMHS.RefreshOutput(btn_In_SvBlowSuck, TaskConv.In.SvBlowSuck);

                GDefineMHS.RefreshInput(lbl_Buf1_SensPsnt, TaskConv.Buf1.SensPsnt);
                GDefineMHS.RefreshInput(lbl_Buf1_SensStopperUp, TaskConv.Buf1.SensStopperUp);
                GDefineMHS.RefreshOutput(btn_Buf1_SvStopperUp, TaskConv.Buf1.SvStopperUp);
                GDefineMHS.RefreshInput(lbl_Buf2_SensPsnt, TaskConv.Buf2.SensPsnt);
                GDefineMHS.RefreshInput(lbl_Buf2_SensStopperUp, TaskConv.Buf2.SensStopperUp);
                GDefineMHS.RefreshOutput(btn_Buf2_SvStopperUp, TaskConv.Buf2.SvStopperUp);

                GDefineMHS.RefreshInput(lbl_Pre_SensPsnt, TaskConv.Pre.SensPsnt);
                GDefineMHS.RefreshInput(lbl_Pre_SensStopperUp, TaskConv.Pre.SensStopperUp);
                GDefineMHS.RefreshOutput(btn_Pre_SvStopperUp, TaskConv.Pre.SvStopperUp);
                GDefineMHS.RefreshInput(lbl_Pre_SensLifterUp, TaskConv.Pre.SensLifterUp);
                GDefineMHS.RefreshInput(lbl_Pre_SensLifterDn, TaskConv.Pre.SensLifterDn);
                GDefineMHS.RefreshOutput(btn_Pre_SvLifterUp, TaskConv.Pre.SvLifterUp);
                GDefineMHS.RefreshInput(lbl_Pre_SensPrecisorExt, TaskConv.Pre.SensPrecisorExt);
                GDefineMHS.RefreshOutput(btn_Pre_SvPrecisorExt, TaskConv.Pre.SvPrecisorExt);
                GDefineMHS.RefreshInput(lbl_Pre_VacSw, TaskConv.Pre.SensVac);
                GDefineMHS.RefreshOutput(btn_Pre_SvVac, TaskConv.Pre.SvVac);

                GDefineMHS.RefreshInput(lbl_Pro_SensPsnt, TaskConv.Pro.SensPsnt);
                GDefineMHS.RefreshInput(lbl_Pro_SensStopperUp, TaskConv.Pro.SensStopperUp);
                GDefineMHS.RefreshOutput(btn_Pro_SvStopperUp, TaskConv.Pro.SvStopperUp);
                GDefineMHS.RefreshInput(lbl_Pro_SensLifterUp, TaskConv.Pro.SensLifterUp);
                GDefineMHS.RefreshInput(lbl_Pro_SensLifterDn, TaskConv.Pro.SensLifterDn);
                GDefineMHS.RefreshOutput(btn_Pro_SvLifterUp, TaskConv.Pro.SvLifterUp);
                GDefineMHS.RefreshInput(lbl_Pro_SensPrecisorExt, TaskConv.Pro.SensPrecisorExt);
                GDefineMHS.RefreshOutput(btn_Pro_SvPrecisorExt, TaskConv.Pro.SvPrecisorExt);
                GDefineMHS.RefreshInput(lbl_Pro_VacSw, TaskConv.Pro.SensVac);
                GDefineMHS.RefreshInput(lbl_Pro_VacSw2, TaskConv.Pro.SensVac2);
                GDefineMHS.RefreshOutput(btn_Pro_SvVac, TaskConv.Pro.SvVac);
                GDefineMHS.RefreshOutput(btn_Pro_SvVac2, TaskConv.Pro.SvVac2);

                GDefineMHS.RefreshInput(lbl_Out_SensPsnt, TaskConv.Out.SensPsnt);
                GDefineMHS.RefreshInput(lbl_Out_SensLFPsnt, TaskConv.Out.SensLFPsnt);
                GDefineMHS.RefreshInput(lbl_Out_SensKickerExt, TaskConv.Out.SensKickerExt);
                GDefineMHS.RefreshInput(lbl_Out_SensKickerRet, TaskConv.Out.SensKickerRet);
                GDefineMHS.RefreshOutput(btn_Out_SvKickerExt, TaskConv.Out.SvKickerExt);

                GDefineMHS.RefreshInput(lbl_Out_SensKickerRet, TaskConv.Out.SensKickerRet);
                GDefineMHS.RefreshOutput(btn_Out_SvKickerExt, TaskConv.Out.SvKickerExt);

                GDefineMHS.RefreshInput(lbl_Pre_HeaterAlm, TaskConv.Pre.HeaterAlarm);
                GDefineMHS.RefreshInput(lbl_Pro_HeaterAlm, TaskConv.Pro.HeaterAlarm);

                GDefineMHS.RefreshInput(lbl_MainPressure, TaskConv.PressureSource);
                GDefineMHS.RefreshOutput(btn_VacPump, TaskConv.VacPump);
                GDefineMHS.RefreshOutput(btn_Conv_MotorOn, TaskConv.Conv.MtrEnable);

                GDefineMHS.RefreshInput(lbl_SensDoor, TaskConv.SensDoor);
                GDefineMHS.RefreshInput(lbl_SensDLock, TaskConv.SensDoorLock);
                GDefineMHS.RefreshOutput(btn_DoorLock, TaskConv.DoorLock);

                GDefineMHS.RefreshInput(lblLeftSmema_BdReady, TaskConv.In.Smema_DI_BdReady);
                GDefineMHS.RefreshOutput(btnLeftSmema_McReady, TaskConv.In.Smema_DO_McReady);
                GDefineMHS.RefreshInput(lblSmema2_McReady, TaskConv.In.Smema2_DI_McReady_True);
                GDefineMHS.RefreshOutput(btnSmema2_BdReady, TaskConv.In.Smema2_DO_BdReady_True);

                GDefineMHS.RefreshInput(lblRightSmema_McReady, TaskConv.Out.Smema_DI_McReady);
                GDefineMHS.RefreshOutput(btnRightSmema_BdReady, TaskConv.Out.Smema_DO_BdReady);
                GDefineMHS.RefreshInput(lblSmema2_BdReady, TaskConv.Out.Smema2_DI_BdReady_True);
                GDefineMHS.RefreshOutput(btnSmema2_McReady, TaskConv.Out.Smema2_DO_McReady_True);

                GDefineMHS.RefreshOutput(btn_TL_Red, TaskConv.TowerLight.TL_Red);
                GDefineMHS.RefreshOutput(btn_TL_Yellow, TaskConv.TowerLight.TL_Yellow);
                GDefineMHS.RefreshOutput(btn_TL_Green, TaskConv.TowerLight.TL_Green);
                GDefineMHS.RefreshOutput(btn_TL_Buzzer, TaskConv.TowerLight.TL_Buzzer);
            }

            if (TaskElev.BoardIsOpen)
            {
                lbl_CWPos.Text = TaskElev.Pos(ElevIO.CWAxis).ToString("f3");
                double d = ((double)TaskConv.Setup.ConvPara[(int)TaskConv.EConvPara.Width] / 1000);
                lbl_ConvWidth.Text = d.ToString("f3");
            }
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_BoardID.Text = "Board ID" + ConvIO.BoardID.ToString();
            lbl_BoardID.BackColor = ZEC3002.Ctrl.BoardOpened(ConvIO.BoardID) ? Color.Lime : Color.Red;

            UpdateStatus();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            TaskConv.SaveRecipe();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                TaskConv.OpenBoard(ConvIO.BoardID, ConvIO.DIOModel);
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("OpenBoard " + ex.Message.ToString());
            }
        }

        private void btn_RevSlow_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;
                TaskConv.Conv.Rev_Slow();
            }
            catch
            {
                TaskConv.Conv.Stop();
            }
        }
        private void btn_RevSlow_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Stop();
            }
            catch
            {
            }
        }
        private void btn_FwdSlow_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;
                TaskConv.Conv.Fwd_Slow();
            }
            catch
            {
                TaskConv.Conv.Stop();
            }
        }
        private void btn_FwdSlow_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Stop();
            }
            catch
            {
            }
        }
        private void btn_Rev_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;
                TaskConv.Conv.Rev_Fast();
            }
            catch
            {
                TaskConv.Conv.Stop();
            }
        }
        private void btn_Rev_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Stop();
            }
            catch
            {
            }
        }
        private void btn_Fwd_MouseDown(object sender, MouseEventArgs e)
        {

            try
            {
                if (e.Button != MouseButtons.Left) return;
                TaskConv.Conv.Fwd_Fast();
            }
            catch
            {
                TaskConv.Conv.Stop();
            }
        }
        private void btn_Fwd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                TaskConv.Conv.Stop();
            }
            catch
            {
            }
        }

        private void btn_In_SvBlowSuck_Click(object sender, EventArgs e)
        {
            TaskConv.In.SvBlowSuck = !TaskConv.In.SvBlowSuck;
        }

        private void btn_Buf1_SvStopperUp_Click(object sender, EventArgs e)
        {
            TaskConv.Buf1.SvStopperUp = !TaskConv.Buf1.SvStopperUp;
        }
        private void btn_Buf2_SvStopperUp_Click(object sender, EventArgs e)
        {
            TaskConv.Buf2.SvStopperUp = !TaskConv.Buf2.SvStopperUp;
        }

        private void btn_Pre_SvStopperUp_Click(object sender, EventArgs e)
        {
            TaskConv.Pre.SvStopperUp = !TaskConv.Pre.SvStopperUp;
        }
        private void btn_Pre_SvLifterUp_Click(object sender, EventArgs e)
        {
            TaskConv.Pre.SvLifterUp = !TaskConv.Pre.SvLifterUp;
        }
        private void btn_Pre_SvPrecisorExt_Click(object sender, EventArgs e)
        {
            TaskConv.Pre.SvPrecisorExt = !TaskConv.Pre.SvPrecisorExt;
        }
        private void btn_Pre_SvVac_Click(object sender, EventArgs e)
        {
            TaskConv.Pre.SvVac = !TaskConv.Pre.SvVac;
        }

        private void btn_Pro_SvStopperUp_Click(object sender, EventArgs e)
        {
            TaskConv.Pro.SvStopperUp = !TaskConv.Pro.SvStopperUp;
        }
        private void btn_Pro_SvLifterUp_Click(object sender, EventArgs e)
        {
            TaskConv.Pro.SvLifterUp = !TaskConv.Pro.SvLifterUp;
        }
        private void btn_Pro_SvPrecisorExt_Click(object sender, EventArgs e)
        {
            TaskConv.Pro.SvPrecisorExt = !TaskConv.Pro.SvPrecisorExt;
        }
        private void btn_Pro_SvVac1_Click(object sender, EventArgs e)
        {
            TaskConv.Pro.SvVac = !TaskConv.Pro.SvVac;
        }
        private void btn_Pro_SvVac2_Click(object sender, EventArgs e)
        {
            TaskConv.Pro.SvVac2 = !TaskConv.Pro.SvVac2;
        }

        private void btn_Out_SvKickerExt_Click(object sender, EventArgs e)
        {
            TaskConv.Out.SvKickerExt = !TaskConv.Out.SvKickerExt;
        }

        private void btn_VacPump_Click(object sender, EventArgs e)
        {
            TaskConv.VacPump = !TaskConv.VacPump;
        }
        private void btn_Conv_MotorOn_Click(object sender, EventArgs e)
        {
            TaskConv.Conv.MtrEnable = !TaskConv.Conv.MtrEnable;
        }
        private void btn_DoorLock_Click(object sender, EventArgs e)
        {
            TaskConv.DoorLock = !TaskConv.DoorLock;
        }

        private void btnLeftSmema_McReady_Click(object sender, EventArgs e)
        {
            TaskConv.In.Smema_DO_McReady = !TaskConv.In.Smema_DO_McReady;
        }
        private void btnSmema2_BdReady_Click(object sender, EventArgs e)
        {
            TaskConv.In.Smema2_DO_BdReady = !TaskConv.In.Smema2_DO_BdReady;
        }
        private void btnRightSmemaOutBdReady_Click(object sender, EventArgs e)
        {
            TaskConv.Out.Smema_DO_BdReady = !TaskConv.Out.Smema_DO_BdReady;
        }
        private void btnSmema2_McReady_Click(object sender, EventArgs e)
        {
            TaskConv.Out.Smema2_DO_McReady = !TaskConv.Out.Smema2_DO_McReady;
        }

        private void btn_TL_Red_Click(object sender, EventArgs e)
        {
            TaskConv.TowerLight.TL_Red = !TaskConv.TowerLight.TL_Red;
        }
        private void btn_TL_Yellow_Click(object sender, EventArgs e)
        {
            TaskConv.TowerLight.TL_Yellow = !TaskConv.TowerLight.TL_Yellow;
        }
        private void btn_TL_Green_Click(object sender, EventArgs e)
        {
            TaskConv.TowerLight.TL_Green = !TaskConv.TowerLight.TL_Green;
        }
        private void btn_TL_Buzzer_Click(object sender, EventArgs e)
        {
            TaskConv.TowerLight.TL_Buzzer = !TaskConv.TowerLight.TL_Buzzer;
        }

        ToolTip toolTip = new ToolTip();
        private void controlIO_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                toolTip.Show(ConvIO.NameGetInputInfo(((Label)sender).Name), (Label)sender);
            }
            if (sender is Button)
            {
                toolTip.Show(ConvIO.NameGetOutputInfo(((Button)sender).Name), (Button)sender);
            }
        }

        private void JogConvStart(bool PosDir, bool Slow)
        {
            double Speed = Slow ? ElevIO.CWAxis.MotorPara.Jog.SlowV: ElevIO.CWAxis.MotorPara.Jog.MedV;

            if (!TaskElev.SetMotionParam(ref ElevIO.CWAxis, 1, Speed, 100)) return;

            if (PosDir)
                TaskElev.JogP(ElevIO.CWAxis);
            else
                TaskElev.JogN(ElevIO.CWAxis);
        }
        private void JogConvStop()
        {
            TaskElev.ForceStop(ElevIO.CWAxis);
            UpdateStatus();
        }
        private void btn_CW_JogMFast_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            JogConvStart(false, false);
        }
        private void btn_CW_JogMFast_MouseUp(object sender, MouseEventArgs e)
        {
            JogConvStop();
        }
        private void btn_CW_JogMSlow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            JogConvStart(false, true);
        }
        private void btn_CW_JogMSlow_MouseUp(object sender, MouseEventArgs e)
        {
            JogConvStop();
        }
        private void btn_CW_JogPSlow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            JogConvStart(true, true);
        }
        private void btn_CW_JogPSlow_MouseUp(object sender, MouseEventArgs e)
        {
            JogConvStop();
        }
        private void btn_CW_JogPFast_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            JogConvStart(true, false);
        }
        private void btn_CW_JogPFast_MouseUp(object sender, MouseEventArgs e)
        {
            JogConvStop();
        }

        private void lbl_CWPos_Click(object sender, EventArgs e)
        {
            double d = TaskElev.CWPos;
            UC.AdjustExec("Set Current Conveyor Width (mm)", ref d, 0, 150);
            TaskElev.CWPos = d;
        }
        private void btn_Goto_Click(object sender, EventArgs e)
        {
            double d = (double)TaskConv.Setup.ConvPara[(int)TaskConv.EConvPara.Width];
            d = d / 1000;

            if (d > 0)
            {
                if (!TaskElev.SetMotionParam(ref ElevIO.CWAxis)) return;
                if (!TaskElev.CWMove(d)) return;
            }
            UpdateStatus();
        }
        private void lbl_ConvWidth_Click(object sender, EventArgs e)
        {
            double d = (double)TaskConv.Setup.ConvPara[(int)TaskConv.EConvPara.Width];
            d = d / 1000;

            UC.AdjustExec("Set Conveyor Width (mm)", ref d, 0, 150);

            TaskConv.Setup.ConvPara[(int)TaskConv.EConvPara.Width] = (int)(d * 1000);
        }

        private void btn_MouseCaptureChanged(object sender, EventArgs e)
        {
            JogConvStop();
        }
    }
}
