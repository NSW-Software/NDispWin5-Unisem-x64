using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_Setting : Form
    {
        public frm_DispCore_DispProg_Setting()
        {
            InitializeComponent();
            GControl.LogForm(this);

            cbxStripMapDnloadFlip.DataSource = Enum.GetValues(typeof(SECSGEMConnect2.EStripMapFlip));
            cbxStripMapUploadFlip.DataSource = Enum.GetValues(typeof(SECSGEMConnect2.EStripMapFlip));
        }

        private string CmdName
        {
            get
            {
                return "DispProg Setting";
            }
        }

        private void frmDispProg_Setting_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            UpdateDisplay();

            cbEnableDnloadMap.Checked = GDefine.EnableDnloadStripMapE142;
            cbxStripMapDnloadFlip.SelectedIndex = (int)GDefine.StripMapDnloadFlip;
            cbEnableUploadMap.Checked = GDefine.EnableUploadStripMapE142;
            cbxStripMapUploadFlip.SelectedIndex = (int)GDefine.StripMapUploadFlip;
        }

        int SelectedStation = 0;
        private void UpdateDisplay()
        {
            Text = CmdName + " [" + GDefine.ProgRecipeName + "]";

            #region Station
            lbl_StationCount.Text = DispProg.StationCount.ToString();
            lbl_Station1Pos.Text = DispProg.Origin(ERunStationNo.Station1).X.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station1).Y.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station1).Z.ToString("F3");
            lbl_Station2Pos.Text = DispProg.Origin(ERunStationNo.Station2).X.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station2).Y.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station2).Z.ToString("F3");
            lbl_Station3Pos.Text = DispProg.Origin(ERunStationNo.Station3).X.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station3).Y.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station3).Z.ToString("F3");
            lbl_Station4Pos.Text = DispProg.Origin(ERunStationNo.Station4).X.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station4).Y.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station4).Z.ToString("F3");
            lbl_Station5Pos.Text = DispProg.Origin(ERunStationNo.Station5).X.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station5).Y.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station5).Z.ToString("F3");
            lbl_Station6Pos.Text = DispProg.Origin(ERunStationNo.Station6).X.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station6).Y.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station6).Z.ToString("F3");
            lbl_Station7Pos.Text = DispProg.Origin(ERunStationNo.Station7).X.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station7).Y.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station7).Z.ToString("F3");
            lbl_Station8Pos.Text = DispProg.Origin(ERunStationNo.Station8).X.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station8).Y.ToString("F3") + ", " + DispProg.Origin(ERunStationNo.Station8).Z.ToString("F3");

            lbl_Station1Pos.BackColor = this.BackColor;
            lbl_Station2Pos.BackColor = this.BackColor;
            lbl_Station3Pos.BackColor = this.BackColor;
            lbl_Station4Pos.BackColor = this.BackColor;
            lbl_Station5Pos.BackColor = this.BackColor;
            lbl_Station6Pos.BackColor = this.BackColor;
            lbl_Station7Pos.BackColor = this.BackColor;
            lbl_Station8Pos.BackColor = this.BackColor;
            switch (SelectedStation)
            {
                case 0:
                    lbl_Station1Pos.BackColor = Color.Lime;
                    break;
                case 1:
                    lbl_Station2Pos.BackColor = Color.Lime;
                    break;
                case 2:
                    lbl_Station3Pos.BackColor = Color.Lime;
                    break;
                case 3:
                    lbl_Station4Pos.BackColor = Color.Lime;
                    break;
                case 4:
                    lbl_Station5Pos.BackColor = Color.Lime;
                    break;
                case 5:
                    lbl_Station6Pos.BackColor = Color.Lime;
                    break;
                case 6:
                    lbl_Station7Pos.BackColor = Color.Lime;
                    break;
                case 7:
                    lbl_Station8Pos.BackColor = Color.Lime;
                    break;
            }

            lbl_StationNo.Text = "Station " + (SelectedStation + 1).ToString();
            lbl_StationX.Text = DispProg.Origin((ERunStationNo)SelectedStation).X.ToString("F3");
            lbl_StationY.Text = DispProg.Origin((ERunStationNo)SelectedStation).Y.ToString("F3");
            lbl_StationZ.Text = DispProg.Origin((ERunStationNo)SelectedStation).Z.ToString("F3");
            #endregion

            #region Head Setup
            lbl_PumpType.Text = DispProg.Pump_Type.ToString();
            lbl_HeadOperation.Text = Enum.GetName(typeof(TaskDisp.EHeadOperation), DispProg.Head_Operation).ToString();

            pnl_HeadPitchX.Visible = (DispProg.Head_Operation == TaskDisp.EHeadOperation.Sync || DispProg.Head_Operation == TaskDisp.EHeadOperation.Double);

            pnl_HeadNeedlePitchY.Visible = DispProg.Pump_Type == TaskDisp.EPumpType.PP2D;

            if (DispProg.Head_PitchX < 0)
                lbl_MultiHeadPitchX.Text = "(Follow) " + TaskDisp.Head_PitchX;
            else
                if (DispProg.Head_PitchX == 0)
                    lbl_MultiHeadPitchX.Text = "(Auto) " + DispProg.rt_Layouts[0].HeadPitch.ToString("f3");
                else
                    lbl_MultiHeadPitchX.Text = DispProg.Head_PitchX.ToString("f3");

            if (DispProg.Head_NeedlePitchY == 0)
                lbl_PumpNeedlePitchY.Text = "(Auto) " + DispProg.rt_Layouts[0].NeedlePitch.ToString("f3");
            else
                lbl_PumpNeedlePitchY.Text = DispProg.Head_NeedlePitchY.ToString("f3");


            lbl_TargetWeight.Text = DispProg.Target_Weight.ToString("f4");
            
            lbl_CalWeight.Text = DispProg.Cal_Meas_Weight > 0? DispProg.Cal_Meas_Weight.ToString("f4") : "(" + DispProg.Target_Weight.ToString("f4") + ")";
            lblCalWeightTol.Text = DispProg.Cal_Weight_Tol == 0 ? "(Default)" : DispProg.Cal_Weight_Tol.ToString("f4");
            lbl_DotsPerSampleCal.Text = DispProg.DotsPerSample_Cal == 0 ? "(Default)" : DispProg.DotsPerSample_Cal.ToString();
            lbl_OutputResultCal.Text = DispProg.DotsPerSample_Cal == 0 ? "(Default)" : DispProg.OutputResult_Cal.ToString();

            lbl_MeasSpec.Text = DispProg.Meas_Spec.ToString("f4");
            lbl_MeasSpecTol.Text = DispProg.Meas_Spec_Tol.ToString("f4");
            lbl_DotsPerSample.Text = DispProg.DotsPerSample_Meas == 0 ? "(Default)" : DispProg.DotsPerSample_Meas.ToString();
            lbl_OutputResult.Text = DispProg.DotsPerSample_Meas == 0 ? "(Default)" : DispProg.OutputResult_Meas.ToString();
            #endregion

            #region Advance
            lblPP_HPC15CtrlDefaultMode.Text = DispProg.PP_HPC15CtrlDefaultMode.ToString();
            lblHM_HPC15CtrlDefaultMode.Text = DispProg.HM_HPC15CtrlDefaultMode.ToString();

            lblCheckBoardInputYield.Text = $"{DispProg.Options_CheckBoardInputYield * 100:f2}";
            lblCheckBoardYield.Text = $"{DispProg.Options_CheckBoardYield*100:f2}";

            lbl_PurgeStageCount.Text = DispProg.PurgeStage.Count.ToString();
            lbl_PurgeStageInterval.Text = DispProg.PurgeStage.Interval.ToString();
            lbl_PurgeStageOnStartCount.Text = DispProg.PurgeStage.OnStartCount.ToString();

            gboxTempCtrl.Visible = GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK;
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
            {
                //TempCtrl.Pool();
                if (GDefine.TempCtrl_Module[0] > GDefine.ETempCtrlModule.None)
                {
                    lbl_TempCtrlModule0.Text = GDefine.TempCtrl_Module[0].ToString();
                    lbl_PV0.Text = TempCtrl.PV(0).ToString();
                    lbl_SV0.Text = TempCtrl.SV(0).ToString();
                    lbl_Dev0.Text = TempCtrl.AL1_Dev(0).ToString();
                }
                if (GDefine.TempCtrl_Module[1] > GDefine.ETempCtrlModule.None)
                {
                    lbl_TempCtrlModule1.Text = GDefine.TempCtrl_Module[1].ToString();
                    lbl_PV1.Text = TempCtrl.PV(1).ToString();
                    lbl_SV1.Text = TempCtrl.SV(1).ToString();
                    lbl_Dev1.Text = TempCtrl.AL1_Dev(1).ToString();
                }
                if (GDefine.TempCtrl_Module[2] > GDefine.ETempCtrlModule.None)
                {
                    lbl_TempCtrlModule2.Text = GDefine.TempCtrl_Module[2].ToString();
                    lbl_PV2.Text = TempCtrl.PV(2).ToString();
                    lbl_SV2.Text = TempCtrl.SV(2).ToString();
                    lbl_Dev2.Text = TempCtrl.AL1_Dev(2).ToString();
                }
                if (GDefine.TempCtrl_Module[3] > GDefine.ETempCtrlModule.None)
                {
                    lbl_TempCtrlModule3.Text = GDefine.TempCtrl_Module[3].ToString();
                    lbl_PV3.Text = TempCtrl.PV(3).ToString();
                    lbl_SV3.Text = TempCtrl.SV(3).ToString();
                    lbl_Dev3.Text = TempCtrl.AL1_Dev(3).ToString();
                }
            }
 
            lbl_BiasKernelFile.Text = DispProg.BiasKernelFile;
            #endregion
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            UpdateDisplay();
            Visible = false;

            try
            {
                TaskDisp.TaskMoveGZUp();
            }
            catch { }

            return;
        }

        private void frmDispProg_Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void frm_DispCore_DispProg_Setting_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.lbl_TargetWeight, "Target Weight to dispense (mg).");
            toolTip1.SetToolTip(this.lbl_CalWeight, "Calibration and measurement weight (mg). If 0, value = Target Weight.");
            toolTip1.SetToolTip(this.lbl_MeasSpec, "Measurement Spec (mg). If 0, value = average of measurements.");
            toolTip1.SetToolTip(this.lbl_MeasSpecTol, "Measurement Spec Tolerance (mg).");
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        #region Station
        private void lbl_StationCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Station Count", ref DispProg.StationCount, 1, 8);

            UpdateDisplay();
        }
        private void lbl_Station1Pos_Click(object sender, EventArgs e)
        {
            SelectedStation = 0;
            UpdateDisplay();
        }
        private void lbl_Station2Pos_Click(object sender, EventArgs e)
        {
            SelectedStation = 1;
            UpdateDisplay();
        }
        private void lbl_Station3Pos_Click(object sender, EventArgs e)
        {
            SelectedStation = 2;
            UpdateDisplay();
        }
        private void lbl_Station4Pos_Click(object sender, EventArgs e)
        {
            SelectedStation = 3;
            UpdateDisplay();
        }
        private void lbl_Station5Pos_Click(object sender, EventArgs e)
        {
            SelectedStation = 4;
            UpdateDisplay();
        }
        private void lbl_Station6Pos_Click(object sender, EventArgs e)
        {
            SelectedStation = 5;
            UpdateDisplay();
        }
        private void lbl_Station7Pos_Click(object sender, EventArgs e)
        {
            SelectedStation = 6;
            UpdateDisplay();
        }
        private void lbl_Station8Pos_Click(object sender, EventArgs e)
        {
            SelectedStation = 7;
            UpdateDisplay();
        }

        private void lbl_StationX_Click(object sender, EventArgs e)
        {
            double N = TaskGantry.GXAxis.Para.SwLimit.PosN;
            double P = TaskGantry.GXAxis.Para.SwLimit.PosP;

            double d = Math.Round(DispProg.Origin((ERunStationNo)SelectedStation).X, 3);
            if (!UC.AdjustExec(CmdName + ", Station " + (SelectedStation + 1).ToString() + " X Position", ref d, N, P)) return;
            DispProg.OriginBase[SelectedStation].X = d;

            UpdateDisplay();
        }
        private void lbl_StationY_Click(object sender, EventArgs e)
        {
            double N = TaskGantry.GYAxis.Para.SwLimit.PosN;
            double P = TaskGantry.GYAxis.Para.SwLimit.PosP;

            double d = Math.Round(DispProg.Origin((ERunStationNo)SelectedStation).Y, 3);
            if (!UC.AdjustExec(CmdName + ", Station " + (SelectedStation + 1).ToString() + " Y Position", ref d, N, P)) return;
            DispProg.OriginBase[SelectedStation].Y = d;

            UpdateDisplay();
        }
        private void lbl_StationZ_Click(object sender, EventArgs e)
        {
            double N = TaskGantry.GZAxis.Para.SwLimit.PosN;
            double P = TaskGantry.GZAxis.Para.SwLimit.PosP;

            double d = Math.Round(DispProg.Origin((ERunStationNo)SelectedStation).Z, 3);
            if (!UC.AdjustExec(CmdName + ", Station " + (SelectedStation + 1).ToString() + " Z Position", ref d, N, P)) return;
            DispProg.OriginBase[SelectedStation].Z = d;
            DispProg.OriginDrawOfst.Z = 0;

            UpdateDisplay();
        }

        private void btn_GotoStationZ_Click(object sender, EventArgs e)
        {
            Msg MsgBox = new Msg();
            EMsgRes MsgRes = MsgBox.Show(ErrCode.MOVE_ZAXIS_TO_POSITION, "", EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
            if (MsgRes == EMsgRes.smrCancel) return;

            if (!TaskGantry.SetMotionParamGZZ2()) return;
            if (!TaskGantry.MoveAbsGZ(DispProg.Origin((ERunStationNo)SelectedStation).Z)) return;
        }
        private void btn_GotoStationXY_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZUp()) return;

            if (!TaskGantry.SetMotionParamGXYX2Y2()) return;

            TPos2 GXY = new TPos2(DispProg.Origin((ERunStationNo)SelectedStation).X, DispProg.Origin((ERunStationNo)SelectedStation).Y);
            TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
            GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

            if (!TaskDisp.GotoXYPos(GXY, GX2Y2)) return;
        }
        private void btn_SetStationXY_Click(object sender, EventArgs e)
        {
            NSW.Net.Point2D Old = new NSW.Net.Point2D(DispProg.OriginBase[SelectedStation].X, DispProg.OriginBase[SelectedStation].Y);
            DispProg.OriginBase[SelectedStation].X = TaskGantry.GXPos();
            DispProg.OriginBase[SelectedStation].Y = TaskGantry.GYPos();
            NSW.Net.Point2D New = new NSW.Net.Point2D(DispProg.OriginBase[SelectedStation].X, DispProg.OriginBase[SelectedStation].Y);
            Log.OnSet(CmdName + ", Station " + SelectedStation.ToString() + " XY", Old, New);

            UpdateDisplay();
        }
        private void btn_SetStationZ_Click(object sender, EventArgs e)
        {
            double Old = DispProg.OriginBase[SelectedStation].Z;
            DispProg.OriginBase[SelectedStation].Z = TaskGantry.GZPos();// - TaskDisp.Head_Ofst[0].Z - TaskDisp.Z1Offset;
            DispProg.OriginDrawOfst.Z = 0;
            double New = DispProg.OriginBase[SelectedStation].Z;
            Log.OnSet(CmdName + ", Station " + SelectedStation.ToString() + " Z", Old, New);

            UpdateDisplay();

            if (!TaskDisp.TaskMoveGZUp()) return;
        }

        #endregion

        #region Head Setup
        private void lbl_PumpType_Click(object sender, EventArgs e)
        {
            int i = (int)DispProg.Pump_Type;
            //GDefine.uc.UserAdjustExecute(ref i, 0, Enum.GetNames(typeof(TaskDisp.EPumpType)).Length - 1);
            if (UC.AdjustExec("Disp Prog.Pump Type", ref i, DispProg.Pump_Type))
            {
                DispProg.Pump_Type = (TaskDisp.EPumpType)i;
                TaskDisp.SetDispType(DispProg.Pump_Type);
                TaskWeight.LoadSetup(DispProg.Pump_Type.ToString());
                TaskDisp.LoadSetup_IOHandShake();
            }
            UpdateDisplay();
        }
        private void lbl_HeadNeedlePitchY_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog.Head Needle Pitch Y (mm)", ref DispProg.Head_NeedlePitchY, -50, 0);
            UpdateDisplay();
        }
        private void lbl_HeadOperation_Click(object sender, EventArgs e)
        {
            TaskDisp.EHeadOperation en = TaskDisp.EHeadOperation.Single;
            int i = (int)DispProg.Head_Operation;
            UC.AdjustExec("Disp Prog.Head Operation", ref i, en);// 0, 2);
            DispProg.Head_Operation = (TaskDisp.EHeadOperation)i;
            TaskDisp.Head_Operation = DispProg.Head_Operation;

            UpdateDisplay();
        }
        private void lbl_MultiHeadPitchX_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog.Head Needle Pitch X (mm)", ref DispProg.Head_PitchX, -150, 150);
            UpdateDisplay();
        }

        private void lbl_TargetWeight_Click(object sender, EventArgs e)
        {
            DispProg.Target_Weight = Math.Round(DispProg.Target_Weight, 4);

            UC.AdjustExec("Disp Prog, Target Weight", ref DispProg.Target_Weight, 0, 1000);
            DispProg.Disp_Weight[0] = DispProg.Target_Weight;
            DispProg.Disp_Weight[1] = DispProg.Target_Weight;

            if (DispProg.Target_Weight > 0) TaskDisp.PP_SetWeight(DispProg.Disp_Weight, true, false);

            UpdateDisplay();
        }
        private void lbl_CalWeight_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, Cal Weight", ref DispProg.Cal_Meas_Weight, 0, 1000);
            UpdateDisplay();
        }
        private void lblCalWeightTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, Cal Weight Tol", ref DispProg.Cal_Weight_Tol, 0, 100);
            UpdateDisplay();
        }
        private void lbl_DotsPerSampleCal_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, DotsPerSample Cal", ref DispProg.DotsPerSample_Cal, 0, 500);

            UpdateDisplay();
        }
        private void lbl_OutputResultCal_Click(object sender, EventArgs e)
        {
            int i = (int)DispProg.OutputResult_Cal;
            UC.AdjustExec("Disp Prog, Output Result Cal", ref i, TaskWeight.EOutputResult.Total);
            DispProg.OutputResult_Cal = (TaskWeight.EOutputResult)i;

            UpdateDisplay();
        }

        private void lbl_MeasSpec_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, Meas Spec", ref DispProg.Meas_Spec, 0, 1000);
            UpdateDisplay();
        }
        private void lbl_MeasSpecTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, Meas Spec Tol", ref DispProg.Meas_Spec_Tol, 0, 100);
            UpdateDisplay();
        }

        private void lbl_DotsPerSampleMeas_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, DotsPerSample Meas", ref DispProg.DotsPerSample_Meas, 0, 500);

            UpdateDisplay();
        }
        private void lbl_OutputResultMeas_Click(object sender, EventArgs e)
        {
            int i = (int)DispProg.OutputResult_Meas;
            UC.AdjustExec("Disp Prog, Output Result Meas", ref i, TaskWeight.EOutputResult.Total);
            DispProg.OutputResult_Meas = (TaskWeight.EOutputResult)i;

            UpdateDisplay();
        }
        #endregion

        #region Advance
        private void lbl_ForceTimeMode_Click(object sender, EventArgs e)
        {
            int i = (int)DispProg.PP_HPC15CtrlDefaultMode;
            if (UC.AdjustExec("Disp Prog.PP_HPC15CtrlDefaultMode", ref i, DispProg.PP_HPC15CtrlDefaultMode))
            {
                DispProg.PP_HPC15CtrlDefaultMode = (TaskDisp.EHPC15Mode)i;
            }
            UpdateDisplay();
        }
        private void lblHM_HPC15CtrlDefaultMode_Click(object sender, EventArgs e)
        {
            int i = (int)DispProg.HM_HPC15CtrlDefaultMode;
            if (UC.AdjustExec("Disp Prog.HM_HPC15CtrlDefaultMode", ref i, DispProg.HM_HPC15CtrlDefaultMode))
            {
                DispProg.HM_HPC15CtrlDefaultMode = (TaskDisp.EHPC15Mode)i;
            }
            UpdateDisplay();
        }

        private void lbl_PurgeStageCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, Purge Stage Count", ref DispProg.PurgeStage.Count, 0, 100);
            UpdateDisplay();
        }
        private void lbl_PurgeStageInterval_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, Purge Stage Interval", ref DispProg.PurgeStage.Interval, 0, 5000);
            UpdateDisplay();
        }
        private void lbl_PurgeStageOnStartCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Prog, Purge Stage OnStart Count", ref DispProg.PurgeStage.OnStartCount, 0, 100);
            UpdateDisplay();
        }

        private void lbl_SV0_Click(object sender, EventArgs e)
        {
            int i = 0;

            UC.AdjustExec("Disp Prog, Temp SV" + i.ToString(), ref DispProg.HeaterSV[i], 0, 180);
            if (GDefine.TempCtrl_Module[i] > 0) TempCtrl.Set(i, DispProg.HeaterSV[i], DispProg.HeaterRange[i]);

            UpdateDisplay();
        }
        private void lbl_Dev0_Click(object sender, EventArgs e)
        {
            int i = 0;

            UC.AdjustExec("Disp Prog, Temp Range" + i.ToString(), ref DispProg.HeaterRange[i], 0, 10);
            if (GDefine.TempCtrl_Module[i] > 0) TempCtrl.Set(i, DispProg.HeaterSV[i], DispProg.HeaterRange[i]);

            UpdateDisplay();
        }
        private void lbl_SV1_Click(object sender, EventArgs e)
        {
            int i = 1;

            UC.AdjustExec("Disp Prog, Heat Module" + i.ToString(), ref DispProg.HeaterSV[i], 0, 180);
            if (GDefine.TempCtrl_Module[i] > 0) TempCtrl.Set(i, DispProg.HeaterSV[i], DispProg.HeaterRange[i]);

            UpdateDisplay();
        }
        private void lbl_Dev1_Click(object sender, EventArgs e)
        {
            int i = 1;

            UC.AdjustExec("Disp Prog, Temp Range" + i.ToString(), ref DispProg.HeaterRange[i], 0, 10);
            if (GDefine.TempCtrl_Module[i] > 0) TempCtrl.Set(i, DispProg.HeaterSV[i], DispProg.HeaterRange[i]);

            UpdateDisplay();
        }
        private void lbl_SV2_Click(object sender, EventArgs e)
        {
            int i = 2;

            UC.AdjustExec("Disp Prog, Heat Module" + i.ToString(), ref DispProg.HeaterSV[i], 0, 180);
            if (GDefine.TempCtrl_Module[i] > 0) TempCtrl.Set(i, DispProg.HeaterSV[i], DispProg.HeaterRange[i]);

            UpdateDisplay();
        }
        private void lbl_Dev2_Click(object sender, EventArgs e)
        {
            int i = 2;

            UC.AdjustExec("Disp Prog, Temp Range" + i.ToString(), ref DispProg.HeaterRange[i], 0, 10);
            if (GDefine.TempCtrl_Module[i] > 0) TempCtrl.Set(i, DispProg.HeaterSV[i], DispProg.HeaterRange[i]);

            UpdateDisplay();
        }
        private void lbl_SV3_Click(object sender, EventArgs e)
        {
            int i = 3;

            UC.AdjustExec("Disp Prog, Heat Module" + i.ToString(), ref DispProg.HeaterSV[i], 0, 180);
            if (GDefine.TempCtrl_Module[i] > 0) TempCtrl.Set(i, DispProg.HeaterSV[i], DispProg.HeaterRange[i]);

            UpdateDisplay();
        }
        private void lbl_Dev3_Click(object sender, EventArgs e)
        {
            int i = 3;

            UC.AdjustExec("Disp Prog, Temp Range" + i.ToString(), ref DispProg.HeaterRange[i], 0, 10);
            if (GDefine.TempCtrl_Module[i] > 0) TempCtrl.Set(i, DispProg.HeaterSV[i], DispProg.HeaterRange[i]);

            UpdateDisplay();
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GDefine.BiasKernelPath + @"\" + DispProg.BiasKernelFile + ".txt");
        }
        private void btn_ClearBiasKernel_Click(object sender, EventArgs e)
        {
            DispProg.BiasKernelFile = "";
            DispProg.BiasKernel.Clear();
        }
        private void btn_LoadBiasKernel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = GDefine.BiasKernelPath;
            ofd.Filter = "BiasKernel|*." + "txt";

            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.Cancel) return;

            DispProg.BiasKernelFile = Path.GetFileNameWithoutExtension(ofd.FileName);
            DispProg.BiasKernel.Load(GDefine.BiasKernelPath + @"\" + DispProg.BiasKernelFile + ".txt");
            UpdateDisplay();
        }
        private void btn_SaveBiasKernel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = GDefine.BiasKernelPath;
            sfd.Filter = "BiasKernel|*." + "txt";
            if (DispProg.BiasKernelFile.Length == 0) sfd.FileName = "new";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.Cancel) return;

            DispProg.BiasKernelFile = Path.GetFileNameWithoutExtension(sfd.FileName);
            DispProg.BiasKernel.Save(GDefine.BiasKernelPath + @"\" + DispProg.BiasKernelFile + ".txt", DispProg.rt_Layouts[0].TRowCount, DispProg.rt_Layouts[0].TColCount);
            UpdateDisplay();
        }

        private void lblCheckBoardInYield_Click(object sender, EventArgs e)
        {
            double d = DispProg.Options_CheckBoardInputYield * 100;
            UC.AdjustExec("Check Board In Yield (%)", ref d, 0, 100);
            DispProg.Options_CheckBoardInputYield = d / 100;
            UpdateDisplay();
        }
        private void lblCheckBoardYield_Click(object sender, EventArgs e)
        {
            double d = DispProg.Options_CheckBoardYield * 100;
            UC.AdjustExec("Check Board Out Yield (%)", ref d, 0, 100);
            DispProg.Options_CheckBoardYield = d / 100;
            UpdateDisplay();
        }

        private void cbEnableDnloadMap_Click(object sender, EventArgs e)
        {
            GDefine.EnableDnloadStripMapE142 = (sender as CheckBox).Checked;
            Log.OnSet("EnableDnloadStripMapE142", GDefine.EnableDnloadStripMapE142);
        }
        private void cbxStripMapDnloadFlip_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GDefine.StripMapDnloadFlip = cbxStripMapDnloadFlip.SelectedIndex;
        }
        private void cbEnableUploadMap_Click(object sender, EventArgs e)
        {
            GDefine.EnableUploadStripMapE142 = (sender as CheckBox).Checked;
            Log.OnSet("EnableUploadStripMapE142", GDefine.EnableUploadStripMapE142);
        }
        private void cbxStripMapUploadFlip_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GDefine.StripMapUploadFlip = cbxStripMapUploadFlip.SelectedIndex;
        }
        #endregion


    }
}
