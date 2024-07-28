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
    internal partial class frm_TeachNeedle_LaserCrosshair : Form
    {
        public frmJogGantry PageJog = new frmJogGantry();
        public frmVisionView PageVision = new frmVisionView();

        public frm_TeachNeedle_LaserCrosshair()
        {
            InitializeComponent();
            GControl.LogForm(this);

            Width = 1024;
            Height = 768;
            StartPosition = FormStartPosition.CenterScreen;

            //AppLanguage.Func.SetComponent(this);
        }

        private void frm_TeachNeedle_LaserCrosshair_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            PageJog.FormBorderStyle = FormBorderStyle.None;

            PageJog.TopLevel = false;
            PageJog.Parent = this;
            PageJog.Width = 516;
            PageJog.Height = 280;
            PageJog.Top = 460;
            PageJog.Left = 518 - 20;
            PageJog.Show();

            PageVision.FormBorderStyle = FormBorderStyle.None;
            PageVision.TopLevel = false;
            PageVision.Parent = this;
            PageVision.Width = 516;
            PageVision.Height = 460;
            PageVision.Top = 40;
            PageVision.Left = 518 - 20;
            PageVision.Show();

            ResetTeachNeedle();

            pnl_MoveLaser.Visible = GDefine.HSensorType > GDefine.EHeightSensorType.None;
            pnl_MoveH2N1.Visible = (GDefine.HeadConfig == GDefine.EHeadConfig.Dual &&
                (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync));

            UpdateDisplay();
            //AppLanguage.Func.SetComponent(this);
        }

        private void frm_TeachNeedle_LaserCrosshair_FormClosing(object sender, FormClosingEventArgs e)
        {
            PageVision.Close();
            PageJog.Close();
        }

        double Camera_ZSensor_Pos_X = TaskDisp.Camera_ZSensor_Pos.X;
        double Camera_ZSensor_Pos_Y = TaskDisp.Camera_ZSensor_Pos.Y;
        double Laser_RefPos_Z = TaskDisp.Laser_RefPosZ;

        double H1N1TouchPos = TaskDisp.Head_ZSensor_RefPosZ[0];
        //double H1N2TouchPos = TaskDisp.Head_ZSensor_RefPosZ[0];
        double H2N1TouchPos = TaskDisp.Head_ZSensor_RefPosZ[1];
        //double H2N2TouchPos = TaskDisp.Head_ZSensor_RefPosZ[1];
        //double H1N1_ZDiff = 0;
        //double H1N2_ZDiff = 0;
        //double H2N1_ZDiff = 0;
        //double H2N2_ZDiff = 0;

        double Camera_Cal_Pos_X = TaskDisp.Camera_Cal_Pos.X;
        double Camera_Cal_Pos_Y = TaskDisp.Camera_Cal_Pos.Y;

        double Head_Ofst_0_X = TaskDisp.Head_Ofst[0].X;
        double Head_Ofst_0_Y = TaskDisp.Head_Ofst[0].Y;

        double Head_Ofst_1_X = TaskDisp.Head_Ofst[1].X;
        double Head_Ofst_1_Y = TaskDisp.Head_Ofst[1].Y;

        //double Camera_Cal_Needle1_Z = TaskDisp.Camera_Cal_Needle1_Z;
        //double Camera_Cal_Needle2_Z = TaskDisp.Camera_Cal_Needle2_Z;

        TPos3 Head2_DefPos = new TPos3(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y, TaskDisp.Head2_DefPos.Z);

        private void UpdateDisplay()
        {
            if (Math.Abs(Laser_RefPos_Z) <= 20)
            {
                lbl_LaserValue.BackColor = this.BackColor;
                lbl_LaserValue.Text = Laser_RefPos_Z.ToString("f3");
            }
            else
            {
                lbl_LaserValue.BackColor = Color.Red;
                lbl_LaserValue.Text = "Err";
            }
        }

        private bool MoveLaser()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                if (!TaskGantry.MoveGX2Y2DefPos(true)) return false;
            }

            if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
            {
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(Camera_ZSensor_Pos_X + TaskDisp.Laser_Ofst.X, Camera_ZSensor_Pos_Y + TaskDisp.Laser_Ofst.Y)) return false;

                tmr_Laser.Enabled = true;
            }

            return true;
        }
        private bool MoveLaserNext()
        {
            tmr_Laser.Enabled = false;

            Camera_ZSensor_Pos_X = TaskGantry.GXPos() - TaskDisp.Laser_Ofst.X;
            Camera_ZSensor_Pos_Y = TaskGantry.GYPos() - TaskDisp.Laser_Ofst.Y;

            return true;
        }

        private bool MoveCameraToRef()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(Camera_Cal_Pos_X, Camera_Cal_Pos_Y)) return false;

            TaskVision.SelectedCam = ECamNo.Cam00;
            TaskVision.LightingOn(TaskDisp.BCamera_Cal_LightRGB);

            return true;
        }
        private bool MoveCameraToRefNext()
        {
            TaskVision.FindCircle = 0;
            TaskVision.TextString = "";

            TaskDisp.BCamera_Cal_LightRGB = TaskVision.CurrentLightRGBA;

            Camera_Cal_Pos_X = TaskGantry.GXPos();
            Camera_Cal_Pos_Y = TaskGantry.GYPos();

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }

        TPos3 H1N1 = new TPos3();
        private bool MoveH1N1ToRef()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            //TaskVision.SelectedCam = ECamNo.Cam02;
            TaskVision.LightingOn(TaskDisp.BCamera_CalNeedle_LightRGB);
            //PageVision.FindCircle = 2;

            H1N1.X = Camera_Cal_Pos_X + Head_Ofst_0_X;
            H1N1.Y = Camera_Cal_Pos_Y + Head_Ofst_0_Y;
            H1N1.Z = 0;//TaskDisp.Head_ZSensor_RefPosZ[0];

            if (!TaskDisp.MoveNeedleToBCamera("Head 1 Needle 1", H1N1.X, H1N1.Y, H1N1.Z + 1, 0))
            {
                return false;
            }

            return true;
        }
        private bool MoveH1N1ToRefNext()
        {
            TaskVision.FindCircle = 0;
            TaskVision.TextString = "";

            TaskDisp.BCamera_CalNeedle_LightRGB = TaskVision.CurrentLightRGBA;

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            double Z = TaskGantry.GZPos();

            Head_Ofst_0_X = X - Camera_Cal_Pos_X;
            Head_Ofst_0_Y = Y - Camera_Cal_Pos_Y;
            H1N1TouchPos = TaskGantry.GZPos();

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }

        TPos3 H2N1 = new TPos3();
        private bool MoveH2N1ToRef()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            TaskVision.LightingOn(TaskDisp.BCamera_CalNeedle_LightRGB);

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                #region Head2 Needle1
                if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                if (!TaskGantry.MoveGX2Y2DefPos(true)) return false;

                H2N1.X = Camera_Cal_Pos_X + Head_Ofst_0_X - TaskDisp.Head2_DefDistX;
                H2N1.Y = Camera_Cal_Pos_Y + Head_Ofst_0_Y;
                H2N1.Z = TaskDisp.Head_ZSensor_RefPosZ[1];

                if (!TaskDisp.MoveNeedleToBCamera("Head 2 Needle 1", H2N1.X, H2N1.Y, 0, H2N1.Z + 1)) return false;
                #endregion
            }
            else
                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                    H2N1.X = Camera_Cal_Pos_X + Head_Ofst_0_X - TaskDisp.Head_PitchX;
                    H2N1.Y = Camera_Cal_Pos_Y + Head_Ofst_0_Y;
                    H2N1.Z = H1N1TouchPos;

                    if (!TaskDisp.MoveNeedleToBCamera("Head 2 Needle 1", H2N1.X, H2N1.Y, H2N1.Z + 1, 0)) return false;
                }

            return true;
        }
        private bool MoveH2N1ToRefNext()
        {
            TaskVision.FindCircle = 0;
            TaskVision.TextString = "";

            TaskDisp.BCamera_CalNeedle_LightRGB = TaskVision.CurrentLightRGBA;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                double X2 = TaskGantry.GX2Pos();
                double Y2 = TaskGantry.GY2Pos();
                double Z2 = TaskGantry.GZ2Pos();

                //Head_Ofst_1_X = X - BCamera_Cal_Pos_X;
                //Head_Ofst_1_Y = Y - BCamera_Cal_Pos_Y;

                Head2_DefPos.X = X2;
                Head2_DefPos.Y = Y2;
                Head2_DefPos.Z = Z2;

                Head_Ofst_1_X = Head_Ofst_0_X - TaskDisp.Head2_DefDistX;
                Head_Ofst_1_Y = Head_Ofst_0_Y;

                H2N1TouchPos = TaskGantry.GZ2Pos();
            }

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }

        private void ResetTeachNeedle()
        {
            pnl_Start.Enabled = true;
            pnl_MoveLaser.Enabled = false;
            pnl_MoveCamera.Enabled = false;
            pnl_MoveH1N1.Enabled = false;
            pnl_MoveH2N1.Enabled = false;
            btn_Complete.Enabled = false;
            TaskVision.FindCircle = 0;
        }


        private void tmr_Laser_Tick(object sender, EventArgs e)
        {
            if (!this.Visible) return; 
            
            if (!TaskLaser.GetHeight(ref Laser_RefPos_Z, false))
                lbl_LaserValue.Text = "Err";

            UpdateDisplay();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (TaskDisp.Option_PromptRunSingleHead)
            {
                if ((GDefine.GantryConfig == GDefine.EGantryConfig.XYZ || GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                    && GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                {
                    if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Single)
                    {
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show(ErrCode.SINGLE_HEAD_RUN_CHECK, EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                        if (MsgRes == EMsgRes.smrCancel)
                        {
                            return;
                        }
                    }
                }
            }

            this.Enabled = false;

            btn_Start.Enabled = false;

            if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
            {
                if (!MoveLaser())
                {
                    ResetTeachNeedle();
                    goto _End;
                }
                pnl_MoveLaser.Enabled = true;
            }
            else
            {
                //if (!SearchNeedles(1))
                if (!MoveCameraToRef())
                {
                    ResetTeachNeedle();
                    goto _End;
                }
                //pnl_SearchNeedleZ.Enabled = true;
                pnl_MoveCamera.Enabled = true;
            }

        _End:
            this.Enabled = true;
        }

        private void btn_MoveLaserNext_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            pnl_MoveLaser.Enabled = false;

            MoveLaserNext();
            //if (!SearchNeedles(1))
            if (!MoveCameraToRef())
            {
                ResetTeachNeedle();
                goto _End;
            }

            pnl_MoveCamera.Enabled = true;

        _End:
            this.Enabled = true;
        }

        private void btn_MoveCameraNext_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            pnl_MoveCamera.Enabled = false;

            MoveCameraToRefNext();
            if (!MoveH1N1ToRef())
            {
                ResetTeachNeedle();
                goto _End;
            }

            pnl_MoveH1N1.Enabled = true;
        _End:
            this.Enabled = true;
        }

        private void btn_MoveH1N1Next_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            pnl_MoveH1N1.Enabled = false;
            MoveH1N1ToRefNext();

            if (GDefine.HeadConfig == GDefine.EHeadConfig.Dual &&
                (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync))
            {
                if (!MoveH2N1ToRef())
                {
                    ResetTeachNeedle();
                    goto _End;
                }

                pnl_MoveH2N1.Enabled = true;
            }
            else
            {
                if (!TaskDisp.TaskMoveGZZ2Up()) goto _End;
                btn_Complete.Enabled = true;
            }
        _End:
            this.Enabled = true;
        }

        private void btn_MoveH2N1Next_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            pnl_MoveH2N1.Enabled = false;
            MoveH2N1ToRefNext();

            if (!TaskDisp.TaskMoveGZZ2Up()) goto _End;
            btn_Complete.Enabled = true;

        _End:
            this.Enabled = true;
        }

        private void btn_H2N1Retry_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            tmr_Laser.Enabled = false;

            ResetTeachNeedle();

            TaskDisp.TaskMoveGZZ2Up();

            //Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Complete_Click(object sender, EventArgs e)
        {
            TaskDisp.Camera_ZSensor_Pos.X = Camera_ZSensor_Pos_X;
            TaskDisp.Camera_ZSensor_Pos.Y = Camera_ZSensor_Pos_Y;
            TaskDisp.Laser_RefPosZ = Laser_RefPos_Z;

            TaskDisp.Head_ZSensor_RefPosZ[0] = H1N1TouchPos;
            TaskDisp.Head_ZSensor_RefPosZ[1] = H2N1TouchPos;

            TaskDisp.Camera_Cal_Pos.X = Camera_Cal_Pos_X;
            TaskDisp.Camera_Cal_Pos.Y = Camera_Cal_Pos_Y;

            TaskDisp.Head_Ofst[0].X = Head_Ofst_0_X;
            TaskDisp.Head_Ofst[0].Y = Head_Ofst_0_Y;

            TaskDisp.Head_Ofst[1].X = Head_Ofst_1_X;
            TaskDisp.Head_Ofst[1].Y = Head_Ofst_1_Y;

            TaskDisp.Head2_DefPos = new TPos3(Head2_DefPos.X, Head2_DefPos.Y, Head2_DefPos.Z);

            TaskVision.SelectedCam = ECamNo.Cam00;
            TaskVision.LightingOn(TaskVision.DefLightRGB);

            TaskDisp.SaveSetup();

            //Close();
            DialogResult = DialogResult.OK;
        }
    }
}
