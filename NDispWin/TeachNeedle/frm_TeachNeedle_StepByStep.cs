using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NDispWin
{
    internal partial class frm_TeachNeedle_StepByStep : Form
    {
        public frm_DispCore_JogGantry2 PageJog = new frm_DispCore_JogGantry2();
        public frmVisionView PageVision = new frmVisionView();

        frmCamera frmCamera = new frmCamera();

        public frm_TeachNeedle_StepByStep()
        {
            InitializeComponent();
            GControl.LogForm(this);

            Width = 1024;
            Height = 768;
            StartPosition = FormStartPosition.CenterScreen;

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                frmCamera.Width = 800;
                frmCamera.Height = 600;

                frmCamera.flirCamera = TaskVision.flirCamera2;
                frmCamera.CamReticles = Reticle.Reticles; //TaskVision.reticles;
                frmCamera.FormBorderStyle = FormBorderStyle.None;
                frmCamera.SelectCamera(0);
                frmCamera.TopLevel = false;
                frmCamera.Parent = panel2;
                frmCamera.Dock = DockStyle.Top;
                frmCamera.Show();

                frmCamera.ShowCamReticles = false;
                frmCamera.Grab();
            }
        }

        private void frmTeachNeedle_Load(object sender, EventArgs e)
        {
            tmr_Reticle.Enabled = true;

            AppLanguage.Func2.UpdateText(this);

            PageJog.FormBorderStyle = FormBorderStyle.None;

            PageJog.TopLevel = false;
            PageJog.Parent = panel2;
            PageJog.Width = 516;
            PageJog.Height = 280;
            PageJog.Top = 460 + 50;
            PageJog.Left = 0;
            PageJog.BringToFront();
            PageJog.Show();

            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
            {
                TaskVision.frmMVCGenTLCamera.Width = 800;
                TaskVision.frmMVCGenTLCamera.Height = 600;

                TaskVision.frmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                TaskVision.frmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                TaskVision.frmMVCGenTLCamera.TopLevel = false;
                TaskVision.frmMVCGenTLCamera.Parent = panel2;
                TaskVision.frmMVCGenTLCamera.Dock = DockStyle.Top;
                TaskVision.frmMVCGenTLCamera.Show();

                TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                TaskVision.genTLCamera[0].StartGrab();
            }

            switch (GDefine.CameraType[0])
            {
                case GDefine.ECameraType.MVCGenTL:
                case GDefine.ECameraType.Spinnaker2:
                    {
                        //PageJog.TopLevel = false;
                        //PageJog.Parent = panel2;
                        //PageJog.Width = 516;
                        //PageJog.Height = 280;
                        //PageJog.Top = 460 + 50;
                        //PageJog.Left = 0;
                        //PageJog.BringToFront();
                        //PageJog.Show();
                    }
                        break;

                case GDefine.ECameraType.Spinnaker:
                    {
                        PageVision.Visible = false;

                        //PageJog.TopLevel = false;
                        //PageJog.Parent = this;
                        //PageJog.Width = 516;
                        //PageJog.Height = 280;
                        //PageJog.Top = 460 + 50;
                        //PageJog.Left = 518 - 20;
                        //PageJog.Show();

                        try
                        {
                            Invoke(new Action(() =>
                            {
                                //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam02);
                                //TaskVision.frmGenImageView.GrabStop();

                                //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam00);
                                //TaskVision.frmGenImageView.Show();
                                //TaskVision.frmGenImageView.TopMost = true;

                                //TaskVision.frmGenImageView.Top = 40;//= ts_Function.Bottom + 40;
                                //TaskVision.frmGenImageView.Width = 516;
                                //TaskVision.frmGenImageView.Height = 460;// frm_Jog.Top - ts_Function.Bottom - 40;

                                //TaskVision.frmGenImageView.EnableCamReticles = true;
                                //TaskVision.frmGenImageView.ZoomFit();

                                //TaskVision.frmGenImageView.Grab();
                            }));
                        }
                        catch
                        {
                            Log.AddToLog("frm_TeachNeedle_StepByStep.Load Invoke Exception Error.");
                        }
                        break;
                    }
                default:
                    {
                        PageVision.FormBorderStyle = FormBorderStyle.None;
                        PageVision.TopLevel = false;
                        PageVision.Parent = this;
                        PageVision.Width = 516;
                        PageVision.Height = 460;
                        PageVision.Top = 40;
                        PageVision.Left = 518 - 20;
                        PageVision.Show();
                        break;
                    }
            } 

            ResetTeachNeedle();

            pnl_MoveLaser.Visible = GDefine.HSensorType > GDefine.EHeightSensorType.None;

            pnl_SearchNeedleH1N2.Visible = DispProg.Pump_Type == TaskDisp.EPumpType.PP2D;
            pnl_SearchNeedleH2N1.Visible = TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync;
            pnl_SearchNeedleH2N2.Visible = (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync) && DispProg.Pump_Type == TaskDisp.EPumpType.PP2D;

            pnl_MoveH1N2.Visible = DispProg.Pump_Type == TaskDisp.EPumpType.PP2D;
            pnl_MoveH2N1.Visible = TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync;
            pnl_MoveH2N2.Visible = (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync) && DispProg.Pump_Type == TaskDisp.EPumpType.PP2D;

            UpdateDisplay();
        }
        private void frm_TeachNeedle_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr_Reticle.Enabled = false;

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam02);
                        //TaskVision.frmGenImageView.GrabStop();

                        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam00);
                        //TaskVision.frmGenImageView.Hide();
                        //TaskVision.frmGenImageView.Reticles.Clear();
                    }));
                }
                catch
                {
                    Log.AddToLog("frm_TeachNeedle_StepByStep. OnClose Invoke Exception Error.");
                }
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL) TaskVision.frmMVCGenTLCamera.Close();

            TaskVision.SelectedCam = ECamNo.Cam00;
            TaskVision.LightingOn(TaskVision.DefLightRGB);

            PageVision.Close();
            PageJog.Close();
        }

        double Camera_ZSensor_Pos_X = TaskDisp.Camera_ZSensor_Pos.X;
        double Camera_ZSensor_Pos_Y = TaskDisp.Camera_ZSensor_Pos.Y;
        double Laser_RefPos_Z = TaskDisp.Laser_RefPosZ;

        double H1N1TouchPos = TaskDisp.Head_ZSensor_RefPosZ[0];
        double H1N2TouchPos = TaskDisp.Head_ZSensor_RefPosZ[0];
        double H2N1TouchPos = TaskDisp.Head_ZSensor_RefPosZ[1];
        double H2N2TouchPos = TaskDisp.Head_ZSensor_RefPosZ[1];
        double H1N1_ZDiff = 0;
        double H1N2_ZDiff = 0;
        double H2N1_ZDiff = 0;
        double H2N2_ZDiff = 0;

        double BCamera_Cal_Pos_X = TaskDisp.BCamera_Cal_Pos.X;
        double BCamera_Cal_Pos_Y = TaskDisp.BCamera_Cal_Pos.Y;

        double Head_Ofst_0_X = TaskDisp.Head_Ofst[0].X;
        double Head_Ofst_0_Y = TaskDisp.Head_Ofst[0].Y;

        double Head_Ofst_1_X = TaskDisp.Head_Ofst[1].X;
        double Head_Ofst_1_Y = TaskDisp.Head_Ofst[1].Y;

        double BCamera_Cal_Needle1_Z = TaskDisp.BCamera_Cal_Needle1_Z;
        double BCamera_Cal_Needle2_Z = TaskDisp.BCamera_Cal_Needle2_Z;

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

            lbl_ZTol.Text = TaskDisp.MultiHead_ZTol.ToString("f3");

            lbl_H1N1TouchPos.Text = H1N1TouchPos.ToString("f3");
            if (Math.Abs(H1N1_ZDiff) <= TaskDisp.MultiHead_ZTol) lbl_H1N1_ZDiff.BackColor = Color.Lime; else lbl_H1N1_ZDiff.BackColor = Color.Red;
            lbl_H1N2TouchPos.Text = H1N2TouchPos.ToString("f3");
            lbl_H1N2_ZDiff.Text = H1N2_ZDiff.ToString("f3");
            if (Math.Abs(H1N2_ZDiff) <= TaskDisp.MultiHead_ZTol) lbl_H1N2_ZDiff.BackColor = Color.Lime; else lbl_H1N2_ZDiff.BackColor = Color.Red;
            lbl_H2N1TouchPos.Text = H2N1TouchPos.ToString("f3");
            lbl_H2N1_ZDiff.Text = H2N1_ZDiff.ToString("f3");
            if (Math.Abs(H2N1_ZDiff) <= TaskDisp.MultiHead_ZTol) lbl_H2N1_ZDiff.BackColor = Color.Lime; else lbl_H2N1_ZDiff.BackColor = Color.Red;
            lbl_H2N2TouchPos.Text = H2N2TouchPos.ToString("f3");
            lbl_H2N2_ZDiff.Text = H2N2_ZDiff.ToString("f3");
            if (Math.Abs(H2N2_ZDiff) <= TaskDisp.MultiHead_ZTol) lbl_H2N2_ZDiff.BackColor = Color.Lime; else lbl_H2N2_ZDiff.BackColor = Color.Red;

            if (Math.Abs(H1N2_ZDiff) <= TaskDisp.MultiHead_ZTol && Math.Abs(H2N1_ZDiff) <= TaskDisp.MultiHead_ZTol && Math.Abs(H2N2_ZDiff) <= TaskDisp.MultiHead_ZTol)
            {
                lbl_NeedleZResult.Text = "OK";
                lbl_NeedleZResult.BackColor = Color.Lime;
            }
            else
            {
                lbl_NeedleZResult.Text = "NG";
                lbl_NeedleZResult.BackColor = Color.Red;
            }

            double AdjAngle = -(H2N1_ZDiff / 0.5) * 360;
            UI_Utils.LabelDrawAngleAdjust(ref lbl_Angle, AdjAngle);
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

        private bool SearchNeedles(int NeedleNo)
        {
            if (NeedleNo == 2) goto _H1N2;
            if (NeedleNo == 3) goto _H2N1;
            if (NeedleNo == 4) goto _H2N2;

            #region H1N1
            if (!TaskZTouch.SearchNeedleZTouch("Head 1 Needle 1", Camera_ZSensor_Pos_X + TaskDisp.Head_Ofst[0].X, Camera_ZSensor_Pos_Y + TaskDisp.Head_Ofst[0].Y, H1N1TouchPos, TaskGantry.GZAxis, ref H1N1TouchPos)) return false;
            H1N2TouchPos = H1N1TouchPos;
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            UpdateDisplay();
            Application.DoEvents();
            #endregion
        _H1N2:
            #region H1N2
            if (DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
            {
                if (!TaskZTouch.SearchNeedleZTouch("Head 1 Needle 2", Camera_ZSensor_Pos_X + TaskDisp.Head_Ofst[0].X, Camera_ZSensor_Pos_Y + TaskDisp.Head_Ofst[0].Y - TaskDisp.Head_NeedlePitchY, H1N1TouchPos, TaskGantry.GZAxis, ref H1N2TouchPos)) return false;
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            }
            H1N2_ZDiff = H1N1TouchPos - H1N2TouchPos;
            UpdateDisplay();
            Application.DoEvents();
            #endregion
        _H2N1:
            #region H2N1
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                //if (TaskDisp.MultiHead_OpType == TaskDisp.EMultiHeadType.Twin)
                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (!TaskZTouch.SearchNeedleZTouch("Head 2", Camera_ZSensor_Pos_X + TaskDisp.Head_Ofst[0].X - TaskDisp.Head2_DefDistX, Camera_ZSensor_Pos_Y + TaskDisp.Head_Ofst[0].Y, H2N1TouchPos, TaskGantry.GZ2Axis, ref H2N1TouchPos)) return false;
                    H2N2TouchPos = H2N1TouchPos;
                    H2N1_ZDiff = 0;
                }
            }
            else
            {
                //if (TaskDisp.MultiHead_OpType == TaskDisp.EMultiHeadType.Twin)
                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (!TaskZTouch.SearchNeedleZTouch("Head 2 Needle 1", Camera_ZSensor_Pos_X + TaskDisp.Head_Ofst[0].X - TaskDisp.Head_PitchX, Camera_ZSensor_Pos_Y + TaskDisp.Head_Ofst[0].Y, H2N1TouchPos, TaskGantry.GZAxis, ref H2N1TouchPos)) return false;
                    H2N2TouchPos = H2N1TouchPos;
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    H2N1_ZDiff = H1N1TouchPos - H2N1TouchPos;
                }
            }
            UpdateDisplay();
            Application.DoEvents();
            #endregion
        _H2N2:
            #region H2N2
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                //if (TaskDisp.MultiHead_OpType == TaskDisp.EMultiHeadType.Twin)
                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                    {
                        if (!TaskZTouch.SearchNeedleZTouch("Head 2 Needle 2", Camera_ZSensor_Pos_X + TaskDisp.Head_Ofst[0].X - TaskDisp.Head2_DefDistX, Camera_ZSensor_Pos_Y + TaskDisp.Head_Ofst[0].Y - TaskDisp.Head_NeedlePitchY, H2N1TouchPos, TaskGantry.GZ2Axis, ref H2N2TouchPos)) return false;
                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                        H2N2_ZDiff = H2N1TouchPos - H2N2TouchPos;
                    }
                }
            }
            else
            {
                //if (TaskDisp.MultiHead_OpType == TaskDisp.EMultiHeadType.Twin)
                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                    {
                        if (!TaskZTouch.SearchNeedleZTouch("Head 2 Needle 2", Camera_ZSensor_Pos_X + TaskDisp.Head_Ofst[0].X - TaskDisp.Head_PitchX, Camera_ZSensor_Pos_Y + TaskDisp.Head_Ofst[0].Y - TaskDisp.Head_NeedlePitchY, H2N1TouchPos, TaskGantry.GZAxis, ref H2N2TouchPos)) return false;
                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                        H2N2_ZDiff = H1N1TouchPos - H2N2TouchPos;
                    }
                }
            }
            UpdateDisplay();
            Application.DoEvents();
            #endregion

            if (TaskDisp.TeachNeedle_ForceInTol)
            {
                btn_SearchNeedleZNext.Enabled = ((Math.Abs(H1N1_ZDiff) <= TaskDisp.MultiHead_ZTol) && (Math.Abs(H1N2_ZDiff) <= TaskDisp.MultiHead_ZTol) &&
                    (Math.Abs(H2N1_ZDiff) <= TaskDisp.MultiHead_ZTol) && (Math.Abs(H2N2_ZDiff) <= TaskDisp.MultiHead_ZTol));
            }
            else
            btn_SearchNeedleZNext.Enabled = true;

            UpdateDisplay();
            return true;
        }
        private bool SearchNeedlesNext()
        {
            return true;
        }

        private bool MoveCameraToRef()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(TaskDisp.BCamera_Cal_Pos.X, TaskDisp.BCamera_Cal_Pos.Y)) return false;

            switch (GDefine.CameraType[(int)ECamNo.Cam00])
            {
                case GDefine.ECameraType.Spinnaker:
                    {
                        //TaskVision.frmGenImageView.GrabStop();
                        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam00);
                        //TaskVision.frmGenImageView.Grab();
                        break;
                    }
                case GDefine.ECameraType.Spinnaker2:
                    {
                        frmCamera.SelectCamera(0);
                        frmCamera.Grab();
                        break;
                    }
                case GDefine.ECameraType.MVCGenTL:
                    {
                        TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                        TaskVision.genTLCamera[0].StartGrab();
                        break;
                    }
            }
            TaskVision.SelectedCam = ECamNo.Cam00;
            TaskVision.LightingOn(TaskDisp.BCamera_Cal_LightRGB);

            if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC)
            {
                TaskVision.FindCircle = 1;
                string ATNCMsg = "ATNC: BUSY";
                Color ATNCMsgColor = Color.Orange;
                TaskVision.TextString = ATNCMsg;
                TaskVision.TextColor = ATNCMsgColor;

                int t1 = GDefine.GetTickCount() + 500;
                while (GDefine.GetTickCount() < t1)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);
                }

                int RetryCount = 0;
                _Retry:
                int t = GDefine.GetTickCount() + 200;
                while (GDefine.GetTickCount() < t)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);
                }

                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                switch (GDefine.CameraType[(int)ECamNo.Cam00])
                {
                    case GDefine.ECameraType.Spinnaker2:
                        Image = TaskVision.flirCamera2[(int)ECamNo.Cam00].m_ImageEmgu.m_Image.Clone();
                        break;
                    case GDefine.ECameraType.MVCGenTL:
                        Image = TaskVision.genTLCamera[(int)ECamNo.Cam00].mImage.Clone();
                        break;
                    default:
                        TaskVision.GrabN(0, ref Image);
                        break;
                }

                if (GDefine.CameraType[(int)ECamNo.Cam00] == GDefine.ECameraType.PtGrey)
                {
                    TaskVision.PtGrey_CamLive(0);
                }

                PointF Center = new PointF(0, 0);
                float Radius = 0f;
                int i_Circles = TaskVision.FindAperture(Image, ref Center, ref Radius);

                if (i_Circles > 0)
                {
                    double OfstX = (Center.X - (double)(Image.Width / 2)) * TaskVision.DistPerPixelX[0];
                    double OfstY = (Center.Y - (double)(Image.Height / 2)) * TaskVision.DistPerPixelY[0];
                    OfstY = -OfstY;

                    double GX = TaskGantry.GXPos();
                    double GY = TaskGantry.GYPos();

                    if (Math.Abs(OfstX) < 0.015 && Math.Abs(OfstY) < 0.015)
                    {
                        ATNCMsg = "ATNC: OK";
                        ATNCMsgColor = Color.Lime;
                        goto _End;
                    }

                    if (!TaskGantry.SetMotionParamGXY()) return false;
                    if (!TaskGantry.MoveAbsGXY(GX + OfstX, GY + OfstY)) return false;

                    RetryCount++;
                    if (RetryCount < 3) goto _Retry;

                    ATNCMsg = "ATNC ERROR: CORRECTION FAIL";
                    ATNCMsgColor = Color.Red;
                }
                ATNCMsg = "ATNC ERROR: APERTURE NOT FOUND";
                ATNCMsgColor = Color.Red;
                _End:
                TaskVision.TextString = ATNCMsg;
                TaskVision.TextColor = ATNCMsgColor;
            }

            int t2 = GDefine.GetTickCount() + 200;
            while (GDefine.GetTickCount() < t2)
            {
                Application.DoEvents();
                Thread.Sleep(5);
            }

            return true;
        }
        private bool MoveCameraToRefNext()
        {
            TaskVision.FindCircle = 0;
            TaskVision.TextString = "";

            TaskDisp.BCamera_Cal_LightRGB = TaskVision.CurrentLightRGBA;

            BCamera_Cal_Pos_X = TaskGantry.GXPos();
            BCamera_Cal_Pos_Y = TaskGantry.GYPos();

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }

        TPos3 H1N1 = new TPos3();
        private bool MoveH1N1ToRef()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Spinnaker)
            {
                //TaskVision.frmGenImageView.GrabStop();
                //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam02);
                //TaskVision.frmGenImageView.Grab();
            }


            TaskVision.SelectedCam = ECamNo.Cam02;
            TaskVision.LightingOn(TaskDisp.BCamera_CalNeedle_LightRGB);
            TaskVision.FindCircle = 2;

            H1N1.X = BCamera_Cal_Pos_X + Head_Ofst_0_X;
            H1N1.Y = BCamera_Cal_Pos_Y + Head_Ofst_0_Y;
            H1N1.Z = H1N1TouchPos - TaskDisp.Head_ZSensor_RefPosZ[0] + BCamera_Cal_Needle1_Z;

            if (!TaskDisp.MoveNeedleToBCamera("Head 1 Needle 1", H1N1.X, H1N1.Y, H1N1.Z, 0))
            {
                return false;
            }

            if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC)
            {
                TaskVision.FindCircle = 2;
                string ATNCMsg = "ATNC: BUSY";
                Color ATNCMsgColor = Color.Orange;
                TaskVision.TextString = ATNCMsg;
                TaskVision.TextColor = ATNCMsgColor;

                int t1 = GDefine.GetTickCount() + 500;
                while (GDefine.GetTickCount() < t1)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);
                }

                int RetryCount = 0;
                _Retry:
                int t = GDefine.GetTickCount() + 200;
                while (GDefine.GetTickCount() < t)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);
                }

                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                //    TaskVision.GrabN((int)ECamNo.Cam02, ref Image);
                switch (GDefine.CameraType[(int)ECamNo.Cam00])
                {
                    case GDefine.ECameraType.Spinnaker2:
                        Image = TaskVision.flirCamera2[(int)ECamNo.Cam00].m_ImageEmgu.m_Image.Clone();
                        break;
                    case GDefine.ECameraType.MVCGenTL:
                        Image = TaskVision.genTLCamera[(int)ECamNo.Cam00].mImage.Clone();
                        break;
                    default:
                        TaskVision.GrabN(0, ref Image);
                        break;
                }
                if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.PtGrey)
                {
                    TaskVision.PtGrey_CamLive((int)ECamNo.Cam02);
                }

                PointF[] Center = new PointF[1024];
                float[] Radius = new float[1024];
                int i_Circles = TaskVision.FindApertureNeedle(Image, ref Center, ref Radius);

                if (i_Circles >= 2)
                {
                    double OfstX = (Center[0].X - Center[1].X) * TaskVision.DistPerPixelX[2];
                    double OfstY = (Center[0].Y - Center[1].Y) * TaskVision.DistPerPixelY[2];
                    OfstY = -OfstY;

                    double GX = TaskGantry.GXPos();
                    double GY = TaskGantry.GYPos();

                    if (Math.Abs(OfstX) < 0.015 && Math.Abs(OfstY) < 0.015)
                    {
                        ATNCMsg = "ATNC: OK";
                        ATNCMsgColor = Color.Lime;
                        goto _End;
                    }

                    if (!TaskGantry.SetMotionParamGXY()) return false;
                    if (!TaskGantry.MoveAbsGXY(GX + OfstX, GY + OfstY)) return false;
                    RetryCount++;

                    if (RetryCount < 3) goto _Retry;

                    ATNCMsg = "ATNC ERROR: CORRECTION FAIL";
                    ATNCMsgColor = Color.Red;
                }
                else
                    if (i_Circles >= 1)
                {
                    ATNCMsg = "ATNC ERROR: NEEDLE NOT FOUND";
                    ATNCMsgColor = Color.Red;
                }
                else
                {
                    ATNCMsg = "ATNC ERROR: APERTURE NOT FOUND";
                    ATNCMsgColor = Color.Red;
                }
                _End:
                TaskVision.TextString = ATNCMsg;
                TaskVision.TextColor = ATNCMsgColor;
            }

            int t2 = GDefine.GetTickCount() + 200;
            while (GDefine.GetTickCount() < t2)
            {
                Application.DoEvents();
                Thread.Sleep(5);
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

            Head_Ofst_0_X = X - BCamera_Cal_Pos_X;
            Head_Ofst_0_Y = Y - BCamera_Cal_Pos_Y;
            BCamera_Cal_Needle1_Z = TaskGantry.GZPos();

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }

        TPos3 H1N2 = new TPos3();
        private bool MoveH1N2ToRef()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            TaskVision.SelectedCam = ECamNo.Cam02;
            TaskVision.LightingOn(TaskDisp.BCamera_CalNeedle_LightRGB);
            TaskVision.FindCircle = 2;

            H1N2.X = BCamera_Cal_Pos_X + Head_Ofst_0_X;
            H1N2.Y = BCamera_Cal_Pos_Y + Head_Ofst_0_Y - TaskDisp.Head_NeedlePitchY;
            H1N2.Z = H1N1TouchPos - TaskDisp.Head_ZSensor_RefPosZ[0] + BCamera_Cal_Needle1_Z;

            if (!TaskDisp.MoveNeedleToBCamera("Head 1 Needle 2", H1N2.X, H1N2.Y, H1N2.Z, 0))
            {
                return false;
            }

            if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC)
            {
                TaskVision.FindCircle = 2;
            }

            return true;
        }
        private bool MoveH1N2ToRefNext()
        {
            TaskVision.FindCircle = 0;
            TaskVision.TextString = "";

            TaskDisp.BCamera_CalNeedle_LightRGB = TaskVision.CurrentLightRGBA;
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }

        TPos3 H2N1 = new TPos3();
        private bool MoveH2N1ToRef()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            TaskVision.SelectedCam = ECamNo.Cam02;
            TaskVision.LightingOn(TaskDisp.BCamera_CalNeedle_LightRGB);
            TaskVision.FindCircle = 2;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                #region Head2 Needle1
                if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                if (!TaskGantry.MoveGX2Y2DefPos(true)) return false;

                H2N1.X = BCamera_Cal_Pos_X + Head_Ofst_0_X - TaskDisp.Head2_DefDistX;
                H2N1.Y = BCamera_Cal_Pos_Y + Head_Ofst_0_Y;
                H2N1.Z = H2N1TouchPos - TaskDisp.Head_ZSensor_RefPosZ[1] + BCamera_Cal_Needle2_Z;

                if (!TaskDisp.MoveNeedleToBCamera("Head 2 Needle 1", H2N1.X, H2N1.Y, 0, H2N1.Z)) return false;
                #endregion

                if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC)
                {
                    TaskVision.FindCircle = 2;
                    string ATNCMsg = "ATNC: BUSY";
                    Color ATNCMsgColor = Color.Orange;
                    TaskVision.TextString = ATNCMsg;
                    TaskVision.TextColor = ATNCMsgColor;

                    int t1 = GDefine.GetTickCount() + 500;
                    while (GDefine.GetTickCount() < t1)
                    {
                        Application.DoEvents();
                        Thread.Sleep(5);
                    }

                    int RetryCount = 0;
                _Retry:
                    int t = GDefine.GetTickCount() + 200;
                    while (GDefine.GetTickCount() < t) Thread.Sleep(0);

                    Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                    //if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Basler)
                    //{
                        TaskVision.GrabN((int)ECamNo.Cam02, ref Image);
                    //}
                    if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.PtGrey)
                    {
                        TaskVision.PtGrey_CamLive((int)ECamNo.Cam02);
                    }

                    PointF[] Center = new PointF[1024];
                    float[] Radius = new float[1024];
                    int i_Circles = TaskVision.FindApertureNeedle(Image, ref Center, ref Radius);

                    if (i_Circles >= 2)
                    {
                        double OfstX = (Center[0].X - Center[1].X) * TaskVision.DistPerPixelX[2];
                        double OfstY = (Center[0].Y - Center[1].Y) * TaskVision.DistPerPixelY[2];
                        OfstY = -OfstY;

                        if (Math.Abs(OfstX) < 0.015 && Math.Abs(OfstY) < 0.015)
                        {
                            ATNCMsg = "ATNC: OK";
                            ATNCMsgColor = Color.Lime;
                            goto _End;
                        }

                        double GX2 = TaskGantry.GX2Pos();
                        double GY2 = TaskGantry.GY2Pos();

                        if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                        if (!TaskGantry.MoveAbsGX2Y2(GX2 + OfstX, GY2 + OfstY)) return false;
                        RetryCount++;

                        if (RetryCount < 3) goto _Retry;

                        ATNCMsg = "ATNC ERROR: CORRECTION FAIL";
                        ATNCMsgColor = Color.Red;
                    }
                    else
                        if (i_Circles >= 1)
                        {
                            ATNCMsg = "ATNC ERROR: NEEDLE NOT FOUND";
                            ATNCMsgColor = Color.Red;
                        }
                        else
                        {
                            ATNCMsg = "ATNC ERROR: APERTURE NOT FOUND";
                            ATNCMsgColor = Color.Red;
                        }
                _End:
                    TaskVision.TextString = ATNCMsg;
                    TaskVision.TextColor = ATNCMsgColor;
                }

                int t2 = GDefine.GetTickCount() + 200;
                while (GDefine.GetTickCount() < t2)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);
                }
                
                return true;
            }
            else
                //if (TaskDisp.MultiHead_OpType == TaskDisp.EMultiHeadType.Twin)
                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Double || TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                    H2N1.X = BCamera_Cal_Pos_X + Head_Ofst_0_X - TaskDisp.Head_PitchX;
                    H2N1.Y = BCamera_Cal_Pos_Y + Head_Ofst_0_Y;
                    H2N1.Z = H2N1TouchPos - H1N1TouchPos + BCamera_Cal_Needle1_Z;

                    if (!TaskDisp.MoveNeedleToBCamera("Head 2 Needle 1", H2N1.X, H2N1.Y, H2N1.Z, 0)) return false;

                    if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC)
                    {
                        TaskVision.FindCircle = 2;
                    }
                    return true;
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
                
                
                BCamera_Cal_Needle2_Z = Z2;
            }

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;


            
            //if (TaskDisp.Pump_OpType == TaskDisp.EPumpType.PP2D)
            //{
            //    #region Head2 Needle2
                //TPos3 H2N2 = new TPos3();
                //H2N2.X = BCamera_Cal_Pos.X + Head_Ofst[0].X - MultiHead_OpPitchX;
                //H2N2.Y = BCamera_Cal_Pos.Y + Head_Ofst[0].Y - Pump_OpNeedlePitchY;
                //H2N2.Z = TouchZ2N2 + (BCamera_Cal_Needle1_Z - Head_ZSensor_RefPosZ[0]);

                //if (!MoveNeedleToBCamera("Head 2 Needle 2", H2N2.X, H2N2.Y, H2N2.Z, 0)) return false;

                //MsgID = frm_DispCore_Msg.Page.ShowMsg("Check Head 2 Needle 2 Position", frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbRetry | frm_DispCore_Msg.TMsgBtn.smbOK | frm_DispCore_Msg.TMsgBtn.smbCancel);
                //while (!frm_DispCore_Msg.Page.ShowMsgClear(MsgID))
                //{
                //    Application.DoEvents();
                //}
                //switch (frm_DispCore_Msg.Page.GetMsgRes(MsgID))
                //{
                //    case frm_DispCore_Msg.TMsgRes.smrOK:
                //        break;
                //    case frm_DispCore_Msg.TMsgRes.smrRetry:
                //        goto _RetryHead2;
                //    case frm_DispCore_Msg.TMsgRes.smrCancel:
                //        //if (!TaskGantry.SetMotionParamGZZ2()) return false;
                //        //if (!TaskGantry.MoveAbsGZZ2((float)0)) return false;
                //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                //        return false;
                //}
                //#region Move Z Up
                ////if (!TaskGantry.SetMotionParamGZZ2()) return false;
                ////if (!TaskGantry.MoveAbsGZZ2((float)0)) return false;
                //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                //#endregion
            //    #endregion
            //}

            //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            //return true;
        }

        TPos3 H2N2 = new TPos3();
        private bool MoveH2N2ToRef()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            TaskVision.SelectedCam = ECamNo.Cam02;
            TaskVision.LightingOn(TaskDisp.BCamera_CalNeedle_LightRGB);

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                H2N2.X = BCamera_Cal_Pos_X + Head_Ofst_0_X - TaskDisp.Head2_DefDistX;
                H2N2.Y = BCamera_Cal_Pos_Y + Head_Ofst_0_Y - TaskDisp.Head_NeedlePitchY;
                H2N2.Z = H1N1TouchPos - TaskDisp.Head_ZSensor_RefPosZ[0] + BCamera_Cal_Needle1_Z;

                if (!TaskDisp.MoveNeedleToBCamera("Head 2 Needle 2", H2N2.X, H2N2.Y, 0, H2N2.Z))
                {
                    return false;
                }

                if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC)
                {
                    TaskVision.FindCircle = 2;
                }
            }
            else
            {
                H2N2.X = BCamera_Cal_Pos_X + Head_Ofst_0_X - TaskDisp.Head_PitchX;
                H2N2.Y = BCamera_Cal_Pos_Y + Head_Ofst_0_Y - TaskDisp.Head_NeedlePitchY;
                H2N2.Z = H1N1TouchPos - TaskDisp.Head_ZSensor_RefPosZ[0] + BCamera_Cal_Needle1_Z;

                if (!TaskDisp.MoveNeedleToBCamera("Head 2 Needle 2", H2N2.X, H2N2.Y, H2N2.Z, 0))
                {
                    return false;
                }
                
                if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC)
                {
                    TaskVision.FindCircle = 2;
                }
            }

            TaskVision.SelectedCam = ECamNo.Cam02;
            TaskVision.LightingOn(TaskDisp.BCamera_CalNeedle_LightRGB);

            return true;
        }
        private bool MoveH2N2ToRefNext()
        {
            TaskVision.FindCircle = 0;
            TaskVision.TextString = "";

            TaskDisp.BCamera_CalNeedle_LightRGB = TaskVision.CurrentLightRGBA;
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }

        private void ResetTeachNeedle()
        {
            pnl_Start.Enabled = true;
            pnl_MoveLaser.Enabled = false;
            pnl_SearchNeedleZ.Enabled = false;
            pnl_MoveCamera.Enabled = false;
            pnl_MoveH1N1.Enabled = false;
            pnl_MoveH1N2.Enabled = false;
            pnl_MoveH2N1.Enabled = false;
            pnl_MoveH2N2.Enabled = false;
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
            #region Check Condition
            switch (GDefine.ZSensorType)
            {
                default:
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.ZSENSOR_NOT_CONFIG);
                        return;
                    }
                case GDefine.EZSensorType.Sensor:
                    if (!TaskGantry.SensNeedleZ())
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_NOT_ON);
                        return;
                    }
                    break;
                case GDefine.EZSensorType.Encoder:
                    try
                    {
                        double d = TaskGantry.ZSensorPos;
                        if (d > 0.001 || d < -0.001)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.ZTOUCH_ECD_NOT_READY);
                            return;
                        }
                    }
                    catch { };
                    TaskGantry.ZSensorPos = 0;
                    break;
            }
            #endregion

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        //TaskVision.frmGenImageView.Reticles.Clear();
                    }));
                }
                catch
                {
                    Log.AddToLog("frm_TeachNeedle_StepByStep.Start Invoke Exception Error.");
                }

            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                frmCamera.Reticles.Clear();

            }

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
                if (!SearchNeedles(1))
                {
                    ResetTeachNeedle();
                    goto _End;
                }
                pnl_SearchNeedleZ.Enabled = true;
            }

        _End:
            this.Enabled = true;
        }

        private void btn_MoveLaserNext_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            pnl_MoveLaser.Enabled = false;

            MoveLaserNext();
            if (!SearchNeedles(1))
            {
                ResetTeachNeedle();
                goto _End;
            }

            pnl_SearchNeedleZ.Enabled = true;

        _End:
            this.Enabled = true;
        }

        private void btn_SearchNeedleZRetryH1N1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (!SearchNeedles(1))
            {
                ResetTeachNeedle();
                goto _End;
            }
        _End:
            this.Enabled = true;
        }
        private void btn_SearchNeedleZRetryH1N2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (!SearchNeedles(2))
            {
                ResetTeachNeedle();
                goto _End;
            }
        _End:
            this.Enabled = true;
        }
        private void btn_SearchNeedleZRetryH2N1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (!SearchNeedles(3))
            {
                ResetTeachNeedle();
                goto _End;
            }
        _End:
            this.Enabled = true;
        }
        private void btn_SearchNeedleZRetryH2N2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (!SearchNeedles(4))
            {
                ResetTeachNeedle();
                goto _End;
            }
        _End:
            this.Enabled = true;
        }
        private void btn_SearchNeedleZNext_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            pnl_SearchNeedleZ.Enabled = false;

            SearchNeedlesNext();
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
            if (TaskDisp.TeachNeedle_ForceInTol)
            {
                 if ((Math.Abs(d_OfstX) > TaskDisp.MultiHead_XYTol) || (Math.Abs(d_OfstY) > TaskDisp.MultiHead_XYTol))
                {
                    return;
                }
            }

            this.Enabled = false;

            pnl_MoveH1N1.Enabled = false;
            MoveH1N1ToRefNext();

            if (DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
            {
                if (!MoveH1N2ToRef())
                {
                    ResetTeachNeedle();
                    goto _End;
                }
                pnl_MoveH1N2.Enabled = true;
            }
            else
            {
                switch (TaskDisp.Head_Operation)
                {
                    case TaskDisp.EHeadOperation.Single:
                        if (!TaskDisp.TaskMoveGZZ2Up()) goto _End;
                        btn_Complete.Enabled = true;
                        break;
                    case TaskDisp.EHeadOperation.Double:
                    case TaskDisp.EHeadOperation.Sync:
                        if (!MoveH2N1ToRef())
                            {
                                ResetTeachNeedle();
                                goto _End;
                            }

                            pnl_MoveH2N1.Enabled = true;
                            break;
                }
            }
        _End:
            this.Enabled = true;
        }
        private void btn_MoveH1N2Next_Click(object sender, EventArgs e)
        {
            if (TaskDisp.TeachNeedle_ForceInTol)
            {
                if ((Math.Abs(d_OfstX) > TaskDisp.MultiHead_XYTol) || (Math.Abs(d_OfstY) > TaskDisp.MultiHead_XYTol))
                {
                    return;
                }
            }

            this.Enabled = false;

            pnl_MoveH1N2.Enabled = false;
            //switch (TaskDisp.MultiHead_OpType)
            switch (TaskDisp.Head_Operation)
            {
                //case TaskDisp.EMultiHeadType.Single:
                case TaskDisp.EHeadOperation.Single:
                    {
                        if (!TaskDisp.TaskMoveGZZ2Up()) goto _End;

                        btn_Complete.Enabled = true;

                        break;
                    }
                //case TaskDisp.EMultiHeadType.Twin:
                case TaskDisp.EHeadOperation.Double:
                case TaskDisp.EHeadOperation.Sync:
                    {
                        if (!MoveH2N1ToRef())
                        {
                            ResetTeachNeedle();
                            goto _End;
                        }

                        pnl_MoveH2N1.Enabled = true;

                        break;
                    }
            }
        _End:
            this.Enabled = true;
        }
        private void btn_H1N2Retry_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            ResetTeachNeedle();

            if (!MoveH1N1ToRef())
            {
                ResetTeachNeedle();
                goto _End;
            }

            pnl_MoveH1N1.Enabled = true;
        _End:
            this.Enabled = true;
        }
        private void btn_MoveH2N1Next_Click(object sender, EventArgs e)
        {
            if (TaskDisp.TeachNeedle_ForceInTol)
            {
                if ((Math.Abs(d_OfstX) > TaskDisp.MultiHead_XYTol) || (Math.Abs(d_OfstY) > TaskDisp.MultiHead_XYTol))
                {
                    return;
                }
            }

            this.Enabled = false;

            pnl_MoveH2N1.Enabled = false;
            MoveH2N1ToRefNext();

            switch (DispProg.Pump_Type)
            {
                default:
                    if (!TaskDisp.TaskMoveGZZ2Up()) goto _End;
                    btn_Complete.Enabled = true;
                    break;
                case TaskDisp.EPumpType.PP2D:
                    if (!MoveH2N2ToRef())
                    {
                        ResetTeachNeedle();
                        goto _End;
                    }
                    pnl_MoveH2N2.Enabled = true;
                    break;
            }
        _End:
            this.Enabled = true;
        }
        private void btn_H2N1Retry_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            ResetTeachNeedle();

            if (!MoveH1N1ToRef())
            {
                ResetTeachNeedle();
                goto _End;
            }

            pnl_MoveH1N1.Enabled = true;
        _End:
            this.Enabled = true;
        }
        private void btn_MoveH2N2Next_Click(object sender, EventArgs e)
        {
            if (TaskDisp.TeachNeedle_ForceInTol)
            {
                if ((Math.Abs(d_OfstX) > TaskDisp.MultiHead_XYTol) || (Math.Abs(d_OfstY) > TaskDisp.MultiHead_XYTol))
                {
                    return;
                }
            }

            this.Enabled = false;

            pnl_MoveH2N2.Enabled = false;

            MoveH2N2ToRefNext();

            btn_Complete.Enabled = true;
        //_End:
            this.Enabled = true;
        }
        private void btn_H2N2Retry_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            ResetTeachNeedle();

            if (!MoveH1N1ToRef())
            {
                ResetTeachNeedle();
                goto _End;
            }

            pnl_MoveH1N1.Enabled = true;
        _End:
            this.Enabled = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            tmr_Laser.Enabled = false;

            ResetTeachNeedle();

            //if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            //{
            //    TaskVision.frmGenImageView.GrabStop();
            //    TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam00);
            //    try
            //    {
            //        Invoke(new Action(() =>
            //        {
            //            TaskVision.frmGenImageView.Reticles.Clear();
            //        }));
            //    }
            //    catch
            //    {
            //        Log.AddToLog("frm_TeachNeedle_StepByStep.Complete Invoke Exception Error.");
            //    }
            //}
            //TaskVision.SelectedCam = ECamNo.Cam00;
            //TaskVision.LightingOn(TaskVision.DefLightRGB);

            TaskDisp.TaskMoveGZZ2Up();

            //Close();
            DialogResult = DialogResult.Cancel;
        }
        private void btn_Complete_Click(object sender, EventArgs e)
        {
            TaskDisp.Camera_ZSensor_Pos.X = Camera_ZSensor_Pos_X;
            TaskDisp.Camera_ZSensor_Pos.Y = Camera_ZSensor_Pos_Y;
            TaskDisp.Laser_RefPosZ = Laser_RefPos_Z;

            TaskDisp.Head_ZSensor_RefPosZ[0] = (H1N1TouchPos + H1N2TouchPos) / 2;
            TaskDisp.Head_ZSensor_RefPosZ[1] = (H2N1TouchPos + H2N2TouchPos) / 2;

            TaskDisp.BCamera_Cal_Pos.X = BCamera_Cal_Pos_X;
            TaskDisp.BCamera_Cal_Pos.Y = BCamera_Cal_Pos_Y;

            TaskDisp.BCamera_Cal_Needle1_Z = BCamera_Cal_Needle1_Z;
            TaskDisp.BCamera_Cal_Needle2_Z = BCamera_Cal_Needle2_Z;

            TaskDisp.Head_Ofst[0].X = Head_Ofst_0_X;
            TaskDisp.Head_Ofst[0].Y = Head_Ofst_0_Y;

            TaskDisp.Head_Ofst[1].X = Head_Ofst_1_X;
            TaskDisp.Head_Ofst[1].Y = Head_Ofst_1_Y;

            TaskDisp.Head2_DefPos = new TPos3(Head2_DefPos.X, Head2_DefPos.Y, Head2_DefPos.Z);
        

            //if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            //{
            //    TaskVision.frmGenImageView.GrabStop();
            //    TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam00);
            //    try
            //    {
            //        Invoke(new Action(() =>
            //        {
            //            TaskVision.frmGenImageView.Reticles.Clear();
            //        }));
            //    }
            //    catch
            //    {
            //        Log.AddToLog("frm_TeachNeedle_StepByStep.Complete Invoke Exception Error.");
            //    }
            //}

            //TaskVision.SelectedCam = ECamNo.Cam00;
            //TaskVision.LightingOn(TaskVision.DefLightRGB);

            TaskDisp.SaveSetup();

            //Close();
            DialogResult = DialogResult.OK;
        }

        private void frm_TeachNeedle_StepByStep_FormClosed(object sender, FormClosedEventArgs e)
        {
 
        }

        double d_OfstX = 0.5;
        double d_OfstY = 0.5;
        private void tmr_Reticle_Tick(object sender, EventArgs e)
        {
            if (GDefine.BottomCamType != GDefine.EBottomCamType.ATNC) return;

            //switch (GDefine.CameraType[(int)ECamNo.Cam02])
            //{
            //    case GDefine.ECameraType.Spinnaker:
            //        //if (TaskVision.FindCircle == 1)
            //        //{
            //        //    #region
            //        //    PointF Center = new PointF(0, 0);
            //        //    float Radius = 0f;
            //        //    using (Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(TaskVision.frmGenImageView.imgBoxEmgu.Image.Bitmap))
            //        //    {
            //        //        int i_Circles = TaskVision.FindAperture(Image, ref Center, ref Radius);

            //        //        if (i_Circles > 0)
            //        //        {
            //        //            Color Color = Color.Lime;

            //        //            double OfstX = (Center.X - (double)Image.Width / 2) * TaskVision.DistPerPixelX[0];
            //        //            double OfstY = (Center.Y - (double)Image.Height / 2) * TaskVision.DistPerPixelY[0];
            //        //            OfstY = -OfstY;

            //        //            if (Math.Abs(OfstX) > 0.05 || Math.Abs(OfstY) > 0.05) Color = Color.Red;

            //        //            PointF pLoc = new PointF((float)Center.X - Radius, (float)Center.Y - Radius);
            //        //            SizeF sSize = new SizeF((float)Radius * 2, (float)Radius * 2);
            //        //            NImager.TReticle retFoundAperture = new NImager.TReticle(NImager.TReticle.EType.Circle, pLoc, sSize, Color);
            //        //            TaskVision.frmGenImageView.EnableReticles = true;
            //        //            if (TaskVision.frmGenImageView.Reticles.Count < 1)
            //        //                TaskVision.frmGenImageView.Reticles.Add(retFoundAperture);
            //        //            else
            //        //                TaskVision.frmGenImageView.Reticles.Reticle[0] = retFoundAperture;

            //        //            NImager.TReticle retCross = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(Center.X, Center.Y), new SizeF(25, 25), Color);
            //        //            if (TaskVision.frmGenImageView.Reticles.Count < 2)
            //        //                TaskVision.frmGenImageView.Reticles.Add(retCross);
            //        //            else
            //        //                TaskVision.frmGenImageView.Reticles.Reticle[1] = retCross;

            //        //            String s3 = (OfstX.ToString("F3") + "," + OfstY.ToString("F3"));
            //        //            NImager.TReticle retText = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(Center.X + 5, Center.Y + 5), new SizeF(0, 25), Color, s3);
            //        //            if (TaskVision.frmGenImageView.Reticles.Count < 3)
            //        //                TaskVision.frmGenImageView.Reticles.Add(retText);
            //        //            else
            //        //                TaskVision.frmGenImageView.Reticles.Reticle[2] = retText;
            //        //        }
            //        //    }
            //        //    #endregion
            //        //}
            //        //if (TaskVision.FindCircle == 2)
            //        //{
            //        //    #region
            //        //    PointF[] Center = new PointF[1024];
            //        //    float[] Radius = new float[1024];
            //        //    using (Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(TaskVision.frmGenImageView.imgBoxEmgu.Image.Bitmap))
            //        //    {
            //        //        int i_Circles = TaskVision.FindApertureNeedle(Image, ref Center, ref Radius);

            //        //        Color Color = Color.Orange;
            //        //        Color Color2 = Color.Lime;

            //        //        int iRetNo = 0;
            //        //        if (i_Circles > 0)
            //        //        {
            //        //            PointF pLoc = new PointF((float)Center[0].X - Radius[0], (float)Center[0].Y - Radius[0]);
            //        //            SizeF sSize = new SizeF((float)Radius[0] * 2, (float)Radius[0] * 2);

            //        //            NImager.TReticle retFoundAperture = new NImager.TReticle(NImager.TReticle.EType.Circle, pLoc, sSize, Color);
            //        //            TaskVision.frmGenImageView.EnableReticles = true;
            //        //            if (TaskVision.frmGenImageView.Reticles.Count <= iRetNo)
            //        //                TaskVision.frmGenImageView.Reticles.Add(retFoundAperture);
            //        //            else
            //        //                TaskVision.frmGenImageView.Reticles.Reticle[iRetNo] = retFoundAperture;

            //        //            iRetNo++;
            //        //            NImager.TReticle retCross = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(Center[0].X, Center[0].Y), new SizeF(25, 25), Color);
            //        //            if (TaskVision.frmGenImageView.Reticles.Count <= iRetNo)
            //        //                TaskVision.frmGenImageView.Reticles.Add(retCross);
            //        //            else
            //        //                TaskVision.frmGenImageView.Reticles.Reticle[iRetNo] = retCross;
            //        //        }

            //        //        if (i_Circles > 1)
            //        //        {
            //        //            d_OfstX = (Center[0].X - Center[1].X) * TaskVision.DistPerPixelX[2];
            //        //            d_OfstY = (Center[0].Y - Center[1].Y) * TaskVision.DistPerPixelY[2];
            //        //            d_OfstY = -d_OfstY;

            //        //            if (Math.Abs(d_OfstX) > TaskDisp.MultiHead_XYTol || Math.Abs(d_OfstY) > TaskDisp.MultiHead_XYTol) Color2 = Color.Red;

            //        //            iRetNo++;
            //        //            PointF pLoc = new PointF((float)Center[1].X - Radius[1], (float)Center[1].Y - Radius[1]);
            //        //            SizeF sSize = new SizeF((float)Radius[1] * 2, (float)Radius[1] * 2);
            //        //            NImager.TReticle retFoundNeedle = new NImager.TReticle(NImager.TReticle.EType.Circle, pLoc, sSize, Color2);
            //        //            TaskVision.frmGenImageView.EnableReticles = true;
            //        //            if (TaskVision.frmGenImageView.Reticles.Count <= iRetNo)
            //        //                TaskVision.frmGenImageView.Reticles.Add(retFoundNeedle);
            //        //            else
            //        //                TaskVision.frmGenImageView.Reticles.Reticle[iRetNo] = retFoundNeedle;

            //        //            iRetNo++;
            //        //            NImager.TReticle retCross = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(Center[1].X, Center[1].Y), new SizeF(25, 25), Color2);
            //        //            if (TaskVision.frmGenImageView.Reticles.Count <= iRetNo)
            //        //                TaskVision.frmGenImageView.Reticles.Add(retCross);
            //        //            else
            //        //                TaskVision.frmGenImageView.Reticles.Reticle[iRetNo] = retCross;

            //        //            iRetNo++;
            //        //            String s3 = (d_OfstX.ToString("F3") + "," + d_OfstY.ToString("F3"));
            //        //            NImager.TReticle retText = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(Center[1].X + 5, Center[1].Y + 5), new SizeF(0, 25), Color2, s3);
            //        //            if (TaskVision.frmGenImageView.Reticles.Count <= iRetNo)
            //        //                TaskVision.frmGenImageView.Reticles.Add(retText);
            //        //            else
            //        //                TaskVision.frmGenImageView.Reticles.Reticle[iRetNo] = retText;
            //        //        }
            //        //    }
            //        //    #endregion
            //        //}
            //        break;
            //    case GDefine.ECameraType.Spinnaker2:
            //        frmCamera.Reticles.Clear();
            //        if (TaskVision.FindCircle == 1)
            //        {
            //            #region
            //            PointF Center = new PointF(0, 0);
            //            float Radius = 0f;
            //            using (Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(TaskVision.frmGenImageView.imgBoxEmgu.Image.Bitmap))
            //            {
            //                int i_Circles = TaskVision.FindAperture(Image, ref Center, ref Radius);

            //                if (i_Circles > 0)
            //                {
            //                    Color Color = Color.Lime;

            //                    double OfstX = (Center.X - (double)Image.Width / 2) * TaskVision.DistPerPixelX[0];
            //                    double OfstY = (Center.Y - (double)Image.Height / 2) * TaskVision.DistPerPixelY[0];
            //                    OfstY = -OfstY;

            //                    if (Math.Abs(OfstX) > 0.05 || Math.Abs(OfstY) > 0.05) Color = Color.Red;


            //                    frmCamera.ShowCamReticles = false;
            //                    TReticles reticles = new TReticles();
            //                    frmCamera.ShowReticles = true;

            //                    PointF pLoc = new PointF((float)Center.X - Radius, (float)Center.Y - Radius);
            //                    SizeF sSize = new SizeF((float)Radius * 2, (float)Radius * 2);
            //                    frmCamera.Reticles.Reticle[0] = new TReticle2(TReticle2.EType.Circle, pLoc, sSize, Color);
            //                    frmCamera.Reticles.Reticle[1] = new TReticle2(TReticle2.EType.Cross, new PointF(Center.X, Center.Y), new SizeF(25, 25), Color);
            //                    String s3 = (OfstX.ToString("F3") + "," + OfstY.ToString("F3"));
            //                    frmCamera.Reticles.Reticle[2] = new TReticle2(TReticle2.EType.Text, new PointF(Center.X + 5, Center.Y + 5), new SizeF(0, 25), Color, s3);
            //                }
            //            }
            //            #endregion
            //        }
            //        if (TaskVision.FindCircle == 2)
            //        {
            //            #region
            //            PointF[] Center = new PointF[1024];
            //            float[] Radius = new float[1024];
            //            using (Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(TaskVision.frmGenImageView.imgBoxEmgu.Image.Bitmap))
            //            {
            //                int i_Circles = TaskVision.FindApertureNeedle(Image, ref Center, ref Radius);

            //                Color Color = Color.Orange;
            //                Color Color2 = Color.Lime;

            //                frmCamera.ShowCamReticles = false;
            //                TReticles reticles = new TReticles();
            //                frmCamera.ShowReticles = true;

            //                int iRetNo = 0;
            //                if (i_Circles > 0)
            //                {
            //                    PointF pLoc = new PointF((float)Center[0].X - Radius[0], (float)Center[0].Y - Radius[0]);
            //                    SizeF sSize = new SizeF((float)Radius[0] * 2, (float)Radius[0] * 2);

            //                    frmCamera.Reticles.Reticle[iRetNo] = new TReticle2(TReticle2.EType.Circle, pLoc, sSize, Color);
            //                    iRetNo++;
            //                    frmCamera.Reticles.Reticle[iRetNo] = new TReticle2(TReticle2.EType.Cross, new PointF(Center[0].X, Center[0].Y), new SizeF(25, 25), Color);
            //                    iRetNo++;
            //                }

            //                if (i_Circles > 1)
            //                {
            //                    d_OfstX = (Center[0].X - Center[1].X) * TaskVision.DistPerPixelX[2];
            //                    d_OfstY = (Center[0].Y - Center[1].Y) * TaskVision.DistPerPixelY[2];
            //                    d_OfstY = -d_OfstY;

            //                    if (Math.Abs(d_OfstX) > TaskDisp.MultiHead_XYTol || Math.Abs(d_OfstY) > TaskDisp.MultiHead_XYTol) Color2 = Color.Red;

            //                    PointF pLoc = new PointF((float)Center[1].X - Radius[1], (float)Center[1].Y - Radius[1]);
            //                    SizeF sSize = new SizeF((float)Radius[1] * 2, (float)Radius[1] * 2);
            //                    frmCamera.Reticles.Reticle[iRetNo] = new TReticle2(TReticle2.EType.Circle, pLoc, sSize, Color2);
            //                    iRetNo++;
            //                    frmCamera.Reticles.Reticle[iRetNo] = new TReticle2(TReticle2.EType.Cross, new PointF(Center[1].X, Center[1].Y), new SizeF(25, 25), Color2);
            //                    iRetNo++;
            //                    String s3 = (d_OfstX.ToString("F3") + "," + d_OfstY.ToString("F3"));
            //                    frmCamera.Reticles.Reticle[iRetNo] = new TReticle2(TReticle2.EType.Text, new PointF(Center[1].X + 5, Center[1].Y + 5), new SizeF(0, 25), Color2, s3);
            //                    iRetNo++;
            //                }
            //            }
            //            #endregion
            //        }
            //        break;
            //}
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

