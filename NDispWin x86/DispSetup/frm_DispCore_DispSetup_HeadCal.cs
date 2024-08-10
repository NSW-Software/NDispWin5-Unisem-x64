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
    internal partial class frm_DispCore_DispSetup_HeadCal : Form
    {
        public frm_DispCore_DispSetup_HeadCal()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }
               
        private void frm_DispCore_DispSetup_HeadCal_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
        }

        private void frm_DispCore_DispSetup_HeadCal_VisibleChanged(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_CamCalPos_Setup.Text = TaskDisp.Camera_Cal_Pos_Setup.X.ToString("F3") + ", " + TaskDisp.Camera_Cal_Pos_Setup.Y.ToString("F3");
            lbl_CamCalPos.Text = TaskDisp.Camera_Cal_Pos.X.ToString("F3") + ", " + TaskDisp.Camera_Cal_Pos.Y.ToString("F3");
            lbl_CamCalPos_Tol.Text = TaskDisp.Camera_Cal_Pos_Tol.ToString("F3");

            lbl_BCamCalPos_Setup.Text = TaskDisp.BCamera_Cal_Pos_Setup.X.ToString("F3") + ", " + TaskDisp.BCamera_Cal_Pos_Setup.Y.ToString("F3");
            lbl_BCamCalPos.Text = TaskDisp.BCamera_Cal_Pos.X.ToString("F3") + ", " + TaskDisp.BCamera_Cal_Pos.Y.ToString("F3");
            lbl_BCamCalPos_Tol.Text = TaskDisp.Camera_Cal_Pos_Tol.ToString("F3");

            //lbl_Head1OffsetXY_Setup.Text = TaskDisp.Head_Ofst_Setup[0].X.ToString("F3") + ", " + TaskDisp.Head_Ofst_Setup[0].Y.ToString("F3");
            //lbl_Head1OffsetZ_Setup.Text = TaskDisp.Head_Ofst_Setup[0].Z.ToString("F3");
            lbl_Head1OffsetXY.Text = TaskDisp.Head_Ofst[0].X.ToString("F3") + ", " + TaskDisp.Head_Ofst[0].Y.ToString("F3");
            lbl_Head1OffsetZ.Text = TaskDisp.Head_Ofst[0].Z.ToString("F3");
            lbl_Head1OffsetXY_Tol.Text = TaskDisp.Head_Ofst_XY_Tol.ToString("F3");

            //lbl_Head2OffsetXY_Setup.Text = TaskDisp.Head_Ofst_Setup[1].X.ToString("F3") + ", " + TaskDisp.Head_Ofst_Setup[1].Y.ToString("F3");
            //lbl_Head2OffsetZ_Setup.Text = TaskDisp.Head_Ofst_Setup[1].Z.ToString("F3");
            lbl_Head2OffsetXY.Text = TaskDisp.Head_Ofst[1].X.ToString("F3") + ", " + TaskDisp.Head_Ofst[1].Y.ToString("F3");
            lbl_Head2OffsetZ.Text = TaskDisp.Head_Ofst[1].Z.ToString("F3");
            lbl_Head2OffsetXY_Tol.Text = TaskDisp.Head_Ofst_XY_Tol.ToString("F3");

            lbl_ApertureDia.Text = TaskDisp.Aperture_Dia.ToString("f3");
            lbl_ApertureDia_Setup.Text = TaskDisp.Aperture_Dia_Setup.ToString("f3");
            lbl_ApertureDia_Tol.Text = TaskDisp.Aperture_Dia_Tol.ToString("f3");

            lbl_ZSensorCalPos.Text = TaskDisp.Camera_ZSensor_Pos.X.ToString("F3") + ", " + TaskDisp.Camera_ZSensor_Pos.Y.ToString("F3");

            lbl_HeadZSensRefZ.Text = TaskDisp.Head_ZSensor_RefPosZ[0].ToString("F3") + ", " + TaskDisp.Head_ZSensor_RefPosZ[1].ToString("F3");
            lbl_HeadZSensRefZ_Setup.Text = TaskDisp.Head_ZSensor_RefPosZ_Setup[0].ToString("F3") + ", " + TaskDisp.Head_ZSensor_RefPosZ_Setup[1].ToString("F3");
            lbl_HeadZSensRefZ_Tol.Text = TaskDisp.Head_ZSensor_RefPosZ_Tol.ToString("F3");

            lbl_LaserOfst.Text = TaskDisp.Laser_Ofst.X.ToString("F3") + ", " + TaskDisp.Laser_Ofst.Y.ToString("F3");
            lbl_LaserOfst_Setup.Text = TaskDisp.Laser_Ofst_Setup.X.ToString("F3") + ", " + TaskDisp.Laser_Ofst_Setup.Y.ToString("F3");
            lbl_LaserOfst_Tol.Text = TaskDisp.Laser_Ofst_XY_Tol.ToString("F3");
            
            lbl_LaserRefZ.Text = TaskDisp.Laser_RefPosZ.ToString("F3");

            pnl_Head2.Visible = (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2);
            lbl_Head2DefDistX.Text = TaskDisp.Head2_DefDistX.ToString("F3");
            lbl_Head2DefPosX.Text = TaskDisp.Head2_DefPos.X.ToString("F3");
            lbl_Head2DefPosY.Text = TaskDisp.Head2_DefPos.Y.ToString("F3");

            lbl_X2Offset.Text = TaskDisp.Head2_XOffset.ToString("F3");
            lbl_Y2Offset.Text = TaskDisp.Head2_YOffset.ToString("F3");
            lbl_Z2Offset.Text = TaskDisp.Head2_ZOffset.ToString("F3");

            lbl_ZDefPos.Text = TaskDisp.ZDefPos.ToString("f3");
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        private void btn_ResetHeadOffset_Click(object sender, EventArgs e)
        {
            TaskDisp.Camera_Cal_Pos.X = 0;
            TaskDisp.Camera_Cal_Pos.Y = 0;

            TaskDisp.BCamera_Cal_Pos.X = 0;
            TaskDisp.BCamera_Cal_Pos.Y = 0;

            TaskDisp.Head_Ofst[0].X = 0;
            TaskDisp.Head_Ofst[0].Y = 0;
            TaskDisp.Head_Ofst[0].Z = 0;

            TaskDisp.Head2_DefPos.X = 0;
            TaskDisp.Head2_DefPos.Y = 0;

            TaskDisp.Head_Ofst[1].X = 0;
            TaskDisp.Head_Ofst[1].Y = 0;
            TaskDisp.Head_Ofst[1].Z = 0;

            UpdateDisplay();
        }

        private void lbl_CamCalPos_Tol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Camera Cal Pos Tolerance (mm)", ref TaskDisp.Camera_Cal_Pos_Tol, 0, 1000);
        }

        private void lbl_Head1OffsetXY_Tol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Head Offset XY Tolerance (mm)", ref TaskDisp.Head_Ofst_XY_Tol, 0, 1000);
        }

        private void lbl_Head1OffsetZ_Tol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Head Offset Z Tolerance (mm)", ref TaskDisp.Head_Ofst_Z_Tol, 0, 1000);
        }

        private void lbl_ApertureDiaTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Aperture Diameter Tol (mm)", ref TaskDisp.Aperture_Dia_Tol, 0, 0.5);
            UpdateDisplay();
        }

        private void btn_ResetZSensor_Click(object sender, EventArgs e)
        {
            TaskDisp.Camera_ZSensor_Pos.X = 0;
            TaskDisp.Camera_ZSensor_Pos.Y = 0;
            TaskDisp.Head_ZSensor_RefPosZ[0] = 0;
            TaskDisp.Head_ZSensor_RefPosZ[1] = 0;
            TaskDisp.Laser_Ofst.X = 0;
            TaskDisp.Laser_Ofst.Y = 0;

            UpdateDisplay();
        }

        private void lbl_ZSensorRefZ_Tol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, ZSensor Ref Z Tol (mm)", ref TaskDisp.Head_ZSensor_RefPosZ_Tol, 0, 5000);
        }

        private void lbl_LaserOfset_Tol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Laser Offset Tol (mm)", ref TaskDisp.Laser_Ofst_XY_Tol, 0, 5000);
        }

        private void lbl_Head2DefDistX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Head2 Def Dist X (mm)", ref TaskDisp.Head2_DefDistX, -150, 150);
            UpdateDisplay();
        }

        private void btn_GotoHead2DefPos_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskGotoGX2Y2DefPos();
        }

        private void lbl_Z2Offset_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Head2 Z Offset (mm)", ref TaskDisp.Head2_ZOffset, -0.25, 0.25);
            UpdateDisplay();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_HeadZSensRefZ_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Disp Setup, Head1 Z Sensor RefZPos", ref TaskDisp.Head_ZSensor_RefPosZ[0], -100, 0))
            {
                UC.AdjustExec("Disp Setup, Head2 Z Sensor RefZPos", ref TaskDisp.Head_ZSensor_RefPosZ[1], -100, 0);
            }
            UpdateDisplay();
        }

        private void lbl_ZDefPos_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Z Default Position", ref TaskDisp.ZDefPos, 0.1, 5);
            if (!TaskDisp.TaskMoveAbsGZZ2(TaskDisp.ZDefPos, TaskDisp.ZDefPos)) return;
            UpdateDisplay();
        }

        private void btn_GotoZDefPos_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveAbsGZZ2(TaskDisp.ZDefPos, TaskDisp.ZDefPos)) return;
        }

        private void lbl_X2Offset_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Head2 X Offset (mm)", ref TaskDisp.Head2_XOffset, -0.25, 0.25);
            UpdateDisplay();
        }

        private void lbl_Y2Offset_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Head2 Y Offset (mm)", ref TaskDisp.Head2_YOffset, -0.25, 0.25);
            UpdateDisplay();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lbl_LaserOfst_Setup_Click(object sender, EventArgs e)
        {

        }

        private void lbl_HeadZSensRefZ_Setup_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Head2DefPosXY_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Head2DefPosX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Head2 Def Pos X (mm)", ref TaskDisp.Head2_DefPos.X, -100, 100);
            UpdateDisplay();
        }

        private void lbl_Head2DefPosY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Setup, Head2 Def Pos Y (mm)", ref TaskDisp.Head2_DefPos.Y, -100, 100);
            UpdateDisplay();
        }
    }
}
