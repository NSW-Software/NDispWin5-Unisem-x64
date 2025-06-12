using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NDispWin
{
    internal class TaskZTouch
    {
        static frm_ProgressReport frmPR = new frm_ProgressReport();

        public static bool WaitTouchStageCleaned()
        {
            _Retry:

            frmPR = new frm_ProgressReport();

            bool Touched = false;
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    double d = TaskGantry.ZSensorPos;
                    if (d > 0.020 || d < -0.020)
                    {
                        Touched = true;
                        break;
                    }
                    Thread.Sleep(10);

                    if (frmPR.Cancel) return;
                }
            });

            frmPR.Message = "Clean Touch Stage. OK to continue.";
            //if (
            frmPR.ShowDialog();

            if (frmPR.Cancel) return false;
            if (!Touched) goto _Retry;

            return true;
        }

        public static bool SearchNeedleZTouch(string NeedleName, double X, double Y, double Z, CControl2.TAxis _Axis, ref double TouchZ)
        {
            const double OverTravel = 0.5;
            const double ClearDist = 0.5;
            const double TouchZEncd_Sensitivity = 0.003;

            Z = Z - OverTravel;

            if (!TaskDisp.TaskMoveGZUp()) return false;

            if (TaskDisp.TeachNeedle_DotPromptCleanStage)
            {
                #region Move Needle XY away from ZTouchPos
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y, true)) return false;
                }

                if (!TaskGantry.MoveAbsGXY(TaskDisp.TeachNeedle_CleanStage_Pos.X, TaskDisp.TeachNeedle_CleanStage_Pos.Y, true)) return false;
                #endregion
            }
        _Retry:
            #region Check Condition
            switch (GDefine.ZSensorType)
            {
                default:
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.ZSENSOR_NOT_CONFIG);
                        return false;
                    }
                case GDefine.EZSensorType.Sensor:
                    if (!TaskGantry.SensNeedleZ())
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_NOT_ON);
                        return false;
                    }
                    if (TaskDisp.TeachNeedle_DotPromptCleanStage)
                    {
                        DefineSafety.DoorLock = false;

                        //frm_ProgressReport frm = new frm_ProgressReport();
                        //frm.Message = "Clean Touch Stage. OK to continue.";
                        frm_ProgressReport frm = new frm_ProgressReport
                        {
                            Message = "Clean Touch Stage. OK to continue."
                        };
                        if (frm.ShowDialog() != DialogResult.OK) return false;

                        if (!TaskGantry.CheckDoorSw()) return false;
                        DefineSafety.DoorLock = true;
                    }
                    break;
                case GDefine.EZSensorType.Encoder:
                    try
                    {
                        if (TaskDisp.TeachNeedle_DotPromptCleanStage)
                        {
                            DefineSafety.DoorLock = false;
                            #region
                            int Retried2 = 0;
                            Retried2++;
                            if (Retried2 > 3)
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show("Z Sensor Detection Error. Check Z Sensor.");
                                return false;
                            }

                            if (!WaitTouchStageCleaned()) return false;
                            #endregion
                            if (!TaskGantry.CheckDoorSw()) return false;
                            DefineSafety.DoorLock = true;
                        }
                    }
                    catch { };
                    break;
            }
            #endregion

            #region Move Needle XY to ZTouchPos
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                if (!TaskGantry.MoveAbsGX2Y2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y, true)) return false;
            }

            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(X, Y, true)) return false;
            #endregion

            #region Needle Coarse Search ZSensor
            double CoarseFoundZ = 0;
            if (!TaskGantry.SetMotionParam(_Axis, 1, 25, 100)) goto _Fail;
            if (!TaskGantry.MovePtpAbs(_Axis, Z)) goto _Fail;
            while (true)
            {
                if (GDefine.ZSensorType == GDefine.EZSensorType.Sensor)
                {
                    if (!TaskGantry.SensNeedleZ())
                    {
                        CoarseFoundZ = TaskGantry.LogicalPos(_Axis);
                        break;
                    }
                }
                if (GDefine.ZSensorType == GDefine.EZSensorType.Encoder)
                {
                    double d = TaskGantry.ZSensorPos;
                    if (d > TouchZEncd_Sensitivity || d < -TouchZEncd_Sensitivity)
                    {
                        CoarseFoundZ = TaskGantry.LogicalPos(_Axis);
                        break;
                    }
                }
                if (!TaskGantry.AxisBusy(_Axis)) break;
            }
            if (!TaskGantry.ForceStop(_Axis)) goto _Fail;
            if (!TaskGantry.AxisWait(_Axis)) goto _Fail;

        _RetryCoarse:
            if (CoarseFoundZ == 0)
            {
                #region Manual Jog
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.SEARCH_NEEDLE_ZSENSOR_NOT_FOUND, EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                switch (MsgRes)
                {
                    case EMsgRes.smrOK:
                        frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                        frm.Inst = "Jog " + NeedleName + " Z 5mm above ZSensor";
                        frm.ShowVision = false;
                        frm.ForceGantryMode = EForceGantryMode.None;
                        DialogResult dr = frm.ShowDialog();
                        frm.ForceGantryMode = EForceGantryMode.None;

                        if (dr == DialogResult.Cancel)
                        {
                            if (!TaskDisp.TaskMoveGZUp()) goto _Fail;
                            goto _Fail;
                        }
                        break;
                    case EMsgRes.smrRetry:
                        //goto _RetryCoarse;
                        break;
                    case EMsgRes.smrCancel:
                        if (!TaskDisp.TaskMoveGZUp()) goto _Fail;
                        goto _Fail;
                }
                #endregion

                if (!TaskGantry.SetMotionParam(_Axis, 1, 10, 100)) goto _Fail;
                if (!TaskGantry.MovePtpRel(_Axis, -5)) goto _Fail;
                while (true)
                {
                    if (GDefine.ZSensorType == GDefine.EZSensorType.Sensor)
                    {
                        if (!TaskGantry.SensNeedleZ())
                        {
                            CoarseFoundZ = TaskGantry.LogicalPos(_Axis);
                            break;
                        }
                    }
                    if (GDefine.ZSensorType == GDefine.EZSensorType.Encoder)
                    {
                        double d = TaskGantry.ZSensorPos;
                        if (d > TouchZEncd_Sensitivity || d < -TouchZEncd_Sensitivity)
                        {
                            CoarseFoundZ = TaskGantry.LogicalPos(_Axis);
                            break;
                        }
                    }
                    if (!TaskGantry.AxisBusy(_Axis)) break;
                }
                if (!TaskGantry.ForceStop(_Axis)) goto _Fail;
                if (!TaskGantry.AxisWait(_Axis)) goto _Fail;

                goto _RetryCoarse;
            }
            #endregion

            double[] FineZArr = new double[3] { 0, 0, 0 };
            int i_TouchCount = 0;
            #region Needle Fine Search ZSensor
        _Retouch:
            #region Move Needle Up
            if (!TaskGantry.SetMotionParam(_Axis, 1, 1, 10)) goto _Fail;
            if (!TaskGantry.MovePtpRel(_Axis, ClearDist)) goto _Fail;
            if (!TaskGantry.AxisWait(_Axis)) goto _Fail;
            #endregion

            #region Check condition
            switch (GDefine.ZSensorType)
            {
                case GDefine.EZSensorType.Sensor:
                    if (!TaskGantry.SensNeedleZ())
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_NOT_ON);
                        goto _Fail;
                    }
                    break;
                case GDefine.EZSensorType.Encoder:
                    try
                    {
                        double d = TaskGantry.ZSensorPos;
                        if (d > TouchZEncd_Sensitivity || d < -TouchZEncd_Sensitivity)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.ZTOUCH_ECD_DN_COUNT_FAIL);
                            goto _Fail;
                        }
                    }
                    catch { };
                    break;
            }
            #endregion

            double FineTouchZ = 0;
            if (!TaskGantry.SetMotionParam(_Axis, 0.5, 0.5, 1)) goto _Fail;
            if (!TaskGantry.MovePtpRel(_Axis, -ClearDist - OverTravel)) goto _Fail;
            while (true)
            {
                if (GDefine.ZSensorType == GDefine.EZSensorType.Sensor)
                {
                    if (!TaskGantry.SensNeedleZ())
                    {
                        switch (TaskDisp.TeachNeedle_ZTouchDetectMethod)
                        {
                            default:
                                FineTouchZ = TaskGantry.LogicalPos(_Axis);
                                FineZArr[i_TouchCount] = FineTouchZ;
                                i_TouchCount++;
                                break;
                            case TaskDisp.EZTouchDetectMethod.Lift:
                                if (!TaskGantry.ForceStop(_Axis)) goto _Fail;
                                if (!TaskGantry.AxisWait(_Axis)) goto _Fail;

                                int loops = 0;
                                while (true)
                                {
                                    loops++;
                                    if (!TaskGantry.MovePtpRel(_Axis, 0.001)) goto _Fail;
                                    if (!TaskGantry.AxisWait(_Axis)) goto _Fail;
                                    if (TaskGantry.SensNeedleZ()) break;

                                    if (loops > 50)
                                    {
                                        Msg MsgBox = new Msg();
                                        MsgBox.Show("EMode.Lift Error Lift Sensor detection error.");
                                        goto _Fail;
                                    }
                                }
                                //FineTouchZ = TaskGantry.EncoderPos(_Axis);
                                FineTouchZ = TaskGantry.LogicalPos(_Axis);
                                FineZArr[i_TouchCount] = FineTouchZ;
                                i_TouchCount++;
                                break;
                        }
                        break;
                    }
                }
                if (GDefine.ZSensorType == GDefine.EZSensorType.Encoder)
                {
                    try
                    {
                        double d = TaskGantry.ZSensorPos;
                        if (d > TouchZEncd_Sensitivity || d < -TouchZEncd_Sensitivity)
                        {
                            switch (TaskDisp.TeachNeedle_ZTouchDetectMethod)
                            {
                                default:
                                    FineTouchZ = TaskGantry.LogicalPos(_Axis);
                                    if (!TaskGantry.ForceStop(_Axis)) goto _Fail;
                                    if (!TaskGantry.AxisWait(_Axis)) goto _Fail;

                                    FineZArr[i_TouchCount] = FineTouchZ;
                                    i_TouchCount++;
                                    break;
                                case TaskDisp.EZTouchDetectMethod.Lift:
                                    {
                                        if (!TaskGantry.ForceStop(_Axis)) goto _Fail;
                                        if (!TaskGantry.AxisWait(_Axis)) goto _Fail;

                                        int loops = 0;
                                        while (true)
                                        {
                                            loops++;
                                            double d1 = TaskGantry.ZSensorPos;
                                            if (!TaskGantry.MovePtpRel(_Axis, 0.002)) goto _Fail;
                                            if (!TaskGantry.AxisWait(_Axis)) goto _Fail;

                                            if (d1 == TaskGantry.ZSensorPos)
                                            {
                                                FineTouchZ = TaskGantry.LogicalPos(_Axis);
                                                FineZArr[i_TouchCount] = FineTouchZ;
                                                i_TouchCount++;
                                                break;
                                            }

                                            if (loops > 50)
                                            {
                                                Msg MsgBox = new Msg();
                                                MsgBox.Show("EMode.Lift Error Lift Sensor detection error.");
                                                goto _Fail;
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                    catch { };
                }
                if (!TaskGantry.AxisBusy(_Axis)) break;
            }
            if (!TaskGantry.ForceStop(_Axis)) goto _Fail;
            if (!TaskGantry.AxisWait(_Axis)) goto _Fail;

            if (FineTouchZ == 0)
            {
                #region
                switch (GDefine.ZSensorType)
                {
                    case GDefine.EZSensorType.Sensor:
                        {
                            Msg MsgBox = new Msg();
                            if (MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_NOT_OFF, EMcState.Error, EMsgBtn.smbRetry_Cancel, false) == EMsgRes.smrRetry)
                                goto _Retry;
                        }
                        break;
                    case GDefine.EZSensorType.Encoder:
                        {
                            Msg MsgBox = new Msg();
                            if (MsgBox.Show(ErrCode.ZTOUCH_ECD_UP_COUNT_FAIL, EMcState.Error, EMsgBtn.smbRetry_Cancel, false) == EMsgRes.smrRetry)
                                goto _Retry;
                        }
                        break;
                }
                goto _Fail;
                #endregion
            }

            if (i_TouchCount < 3) goto _Retouch;

            if (!TaskDisp.TaskMoveGZUp()) goto _Fail;

            #region Add Log
            string s_TouchPos = CoarseFoundZ.ToString("f3") + "/";
            double d_Sum = 0;
            for (int i = 0; i < 3; i++)
            {
                d_Sum = d_Sum + FineZArr[i];
                s_TouchPos = s_TouchPos + FineZArr[i].ToString("f3");
                if (i < 2) s_TouchPos = s_TouchPos + ",";
            }
            double d_Ave = d_Sum / 3;
            s_TouchPos = s_TouchPos + "/" + d_Ave.ToString("f4");
            Event.SETUP_TOUCH_POS_UPDATE.Set("TouchPos", s_TouchPos);
            #endregion

            if (FineZArr.Max() - FineZArr.Min() > 0.020)
            {
                switch (GDefine.ZSensorType)
                {
                    case GDefine.EZSensorType.Sensor:
                        {
                            Msg MsgBox = new Msg();
                            if (MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_ABNORMAL, EMcState.Error, EMsgBtn.smbRetry_Cancel, false) == EMsgRes.smrRetry)
                                goto _Retry;
                        }
                        break;
                    case GDefine.EZSensorType.Encoder:
                        {
                            Msg MsgBox = new Msg();
                            if (MsgBox.Show(ErrCode.ZTOUCH_ECD_ABNORMAL, EMcState.Error, EMsgBtn.smbRetry_Cancel, false) == EMsgRes.smrRetry)
                                goto _Retry;
                        }
                        break;
                }
                goto _Fail;
            }
            TouchZ = d_Ave;
            #endregion

            if (!TaskDisp.TaskMoveGZUp()) return false;
            return true;

        _Fail:
            if (!TaskDisp.TaskMoveGZUp()) return false;
            return false;
        }
    }
}
