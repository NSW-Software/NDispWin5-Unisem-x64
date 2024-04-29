using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace NDispWin
{
    using NSW.Net;

    class DispProgCmd
    {
    }

    internal class GroupDisp
    {
        public static bool Execute(DispProg.TLine Line, ERunMode RunMode, double f_origin_x, double f_origin_y, double f_origin_z)
        {
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2) throw new Exception("Group Disp do not support Dual Head Config.");

            string EMsg = Line.Cmd.ToString();

            try
            {
                GDefine.Status = EStatus.Busy;

                bool b_Head2IsValid = false;
                bool b_SyncHead2 = false;
                bool[] b_HeadRun = new bool[2] { false, false };
                if (!DispProg.SelectHead(Line, ref b_HeadRun, ref b_Head2IsValid, ref b_SyncHead2)) goto _End;

                TModelPara Model = new TModelPara(DispProg.ModelList, Line.IPara[0]);
                bool Disp = (Line.IPara[2] > 0);

                #region Move GZ2 Up if invalid
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2 && !b_Head2IsValid)
                {
                    switch (RunMode)
                    {
                        case ERunMode.Normal:
                        case ERunMode.Dry:
                            if (!TaskDisp.TaskMoveGZ2Up()) return false;
                            break;
                    }
                }
                #endregion

                #region assign and translate position
                double dx = f_origin_x + DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex].X + Line.X[0];
                double dy = f_origin_y + DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex].Y + Line.Y[0];
                DispProg.TranslatePos(dx, dy, DispProg.rt_Head1RefData, ref dx, ref dy);

                double dx2 = f_origin_x + DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex2].X + Line.X[0];
                double dy2 = f_origin_y + DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex2].Y + Line.Y[0];
                DispProg.TranslatePos(dx2, dy2, DispProg.rt_Head2RefData, ref dx2, ref dy2);

                dx = dx + DispProg.BiasKernel.X[DispProg.RunTime.Bias_Head_CR.X, DispProg.RunTime.Bias_Head_CR.Y];
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                    dy = dy - DispProg.BiasKernel.Y[DispProg.RunTime.Bias_Head_CR.X, DispProg.RunTime.Bias_Head_CR.Y];
                else
                    dy = dy + DispProg.BiasKernel.Y[DispProg.RunTime.Bias_Head_CR.X, DispProg.RunTime.Bias_Head_CR.Y];

                double X1 = dx;
                double Y1 = dy;
                double X2 = dx2;
                double Y2 = dy2;
                #endregion

                X1 = X1 + DispProg.OriginDrawOfst.X;
                Y1 = Y1 + DispProg.OriginDrawOfst.Y;
                X2 = X2 + DispProg.OriginDrawOfst.X;
                Y2 = Y2 + DispProg.OriginDrawOfst.Y;

                double X2_Ofst = X2 - X1;
                double Y2_Ofst = Y2 - Y1;

                TPos2 GXY = new TPos2(X1, Y1);
                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                #region Move To Pos
                switch (RunMode)
                {
                    case ERunMode.Normal:
                    case ERunMode.Dry:
                        {
                            if (!b_SyncHead2)
                            {
                                if (b_HeadRun[0])//(HeadNo == EHeadNo.Head1)
                                {
                                    GXY.X = GXY.X + TaskDisp.Head_Ofst[0].X;
                                    GXY.Y = GXY.Y + TaskDisp.Head_Ofst[0].Y;
                                }
                                if (b_HeadRun[1])//(HeadNo == EHeadNo.Head2)
                                {
                                    GXY.X = GXY.X + TaskDisp.Head_Ofst[1].X;
                                    GXY.Y = GXY.Y + TaskDisp.Head_Ofst[1].Y;
                                }
                            }
                            else
                            {
                                GXY.X = GXY.X + TaskDisp.Head_Ofst[0].X;
                                GXY.Y = GXY.Y + TaskDisp.Head_Ofst[0].Y;

                                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + X2_Ofst + TaskDisp.Head2_XOffset;
                                GX2Y2.Y = GX2Y2.Y + Y2_Ofst + TaskDisp.Head2_YOffset;
                            }
                            break;
                        }
                    case ERunMode.Camera:
                    default:
                        {
                            break;
                        }
                }

                if (!TaskGantry.SetMotionParamGXY()) goto _Error;
                if (!TaskGantry.MoveAbsGXY(GXY.X, GXY.Y, false)) goto _Error;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (b_HeadRun[1])
                    {
                        if (!TaskGantry.SetMotionParamGX2Y2()) goto _Error;
                        if (!TaskGantry.MoveAbsGX2Y2(GX2Y2.X, GX2Y2.Y, false)) goto _Error;
                    }
                }
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                    TaskGantry.WaitGX2Y2();
                TaskGantry.WaitGXY();
                #endregion

                double Z1 = 0;
                double Z2 = 0;
                #region Assign Z positions
                double dz = f_origin_z;
                dz = dz + TaskDisp.Head_Ofst[0].Z;
                double ZDiff = (TaskDisp.Head_ZSensor_RefPosZ[1] + TaskDisp.Head_Ofst[1].Z - (TaskDisp.Head_ZSensor_RefPosZ[0] + TaskDisp.Head_Ofst[0].Z));
                double dz2 = dz + ZDiff;

                Z1 = dz;
                Z2 = dz2;
                #endregion
                #region Update Z Offset
                Z1 = Z1 + TaskDisp.Z1Offset;
                Z2 = Z2 + TaskDisp.Z2Offset + TaskDisp.Head2_ZOffset;
                #endregion

                #region If ZPlane Valid, Update Z Values
                double LX1 = GXY.X - TaskDisp.Head_Ofst[0].X;
                double LY1 = GXY.Y - TaskDisp.Head_Ofst[0].Y;
                double LX2 = LX1 + (X2 - X1);
                double LY2 = LY1 + (Y2 - Y1);
                DispProg.UpdateZHeight(b_SyncHead2, LX1, LY1, LX2, LY2, ref Z1, ref Z2);
                #endregion
                #region move z to DispGap
                switch (RunMode)
                {
                    case ERunMode.Normal:
                    case ERunMode.Dry:
                        {

                            double sv = Model.DnStartV;
                            double dv = Model.DnSpeed;
                            double ac = Model.DnAccel;
                            if (!TaskGantry.SetMotionParamGZZ2(sv, dv, ac)) goto _Stop;
                            if (!DispProg.MoveZAbs(b_HeadRun[0], b_HeadRun[1], Z1 + Model.DispGap + Model.RetGap, Z2 + Model.DispGap + Model.RetGap)) return false;


                            break;
                        }
                    case ERunMode.Camera:
                    default:
                        {
                            break;
                        }
                }
                #endregion

                double[] lineSpeed = new double[10] { Model.LineSpeed, Model.LineSpeed, Model.LineSpeed, Model.LineSpeed, Model.LineSpeed, Model.LineSpeed, Model.LineSpeed, Model.LineSpeed, Model.LineSpeed, Model.LineSpeed };

                #region Weighted
                double totalWeight = Line.DPara[1];
                double totalDispTime = Model.DispTime > 0 ? Model.DispTime : DispProg.SP.DispTime[0];
                if (Model.DispVol > 0) totalDispTime = Model.DispVol;
                double totalDelayTime = 0;
                int lineIndex = 0;
                double totalLength = 0;
                if (Line.IPara[1] > 0)//enabled Weighted
                {
                    totalDispTime = totalWeight / TaskFlowRate.Value[0] * 1000;//ms
                    totalDispTime = totalDispTime * (1 + (DispProg.FlowRate.TimeCompensate / 100));


                    if (TaskFlowRate.Value[0] <= 0) throw new Exception("Invalid Flowrate. Perform Flowrate cal.");
                    if (totalWeight <= 0) throw new Exception("Weight value is invalid. Define weight value.");

                    //Calculate total length and delays of the group lines
                    lineIndex = 0;
                    for (int i = 0; i < 100; i++)
                    {
                        bool breakFor = false;
                        switch (Line.Index[i])
                        {
                            case (int)EGDispCmd.None:
                                breakFor = true;
                                break;
                            case (int)EGDispCmd.DOT:
                                if (DispProg.Pump_Type == TaskDisp.EPumpType.SP)
                                {
                                    //PPress On Lagging
                                    if (DispProg.SP.PulseOnDelay[0] > 0) totalDelayTime += DispProg.SP.PulseOnDelay[0];
                                }
                                if (Model.StartDelay > 0) totalDelayTime += Model.StartDelay;
                                if (Model.EndDelay > 0) totalDelayTime += Model.EndDelay;
                                if (DispProg.Pump_Type == TaskDisp.EPumpType.SP)
                                {
                                    //PPress Off Leading
                                    if (DispProg.SP.PulseOffDelay[0] < 0) totalDelayTime += DispProg.SP.PulseOffDelay[0];
                                }
                                if (totalDelayTime > totalDispTime) throw new Exception("Delay Time too long to achieve weight value. Decrease StartDelay and EndDelay time.");
                                breakFor = true;
                                break;
                            case (int)EGDispCmd.LINE_START:
                                totalLength = 0;
                                totalDelayTime = 0;
                                if (DispProg.Pump_Type == TaskDisp.EPumpType.SP)
                                {
                                    //PPress On Lagging
                                    if (DispProg.SP.PulseOnDelay[0] > 0) totalDelayTime += DispProg.SP.PulseOnDelay[0];
                                }
                                if (Model.StartDelay > 0) totalDelayTime += Model.StartDelay;
                                break;
                            case (int)EGDispCmd.LINE_PASS:
                                {
                                    double lineLength = Math.Sqrt(Math.Pow(Line.X[i], 2) + Math.Pow(Line.Y[i], 2));
                                    totalLength += lineLength;
                                }
                                break;
                            case (int)EGDispCmd.LINE_END:
                                {
                                    double lineLength = Math.Sqrt(Math.Pow(Line.X[i], 2) + Math.Pow(Line.Y[i], 2));
                                    totalLength += lineLength;

                                    if (Model.EndDelay > 0) totalDelayTime += Model.EndDelay;
                                    if (DispProg.Pump_Type == TaskDisp.EPumpType.SP)
                                    {
                                        //PPress Off Leading
                                        if (DispProg.SP.PulseOffDelay[0] < 0) totalDelayTime += DispProg.SP.PulseOffDelay[0];
                                    }

                                    double lineTime = totalDispTime - totalDelayTime;
                                    if (lineTime <= 0) throw new Exception("Delay Time too long to achieve weight value. Decrease StartDelay and EndDelay time.");

                                    //////set u = 0, 


                                    //dT = totalLength - total length of the lines
                                    double dT = totalLength;
                                    //tT = totalTime - total time for total lines move
                                    double tT = lineTime / 1000;//unit seconds
                                    //a = accel
                                    double a = Model.LineAccel;
                                    //
                                    //set u=0
                                    //
                                    //Triangle profile
                                    //Peak v, vP = a * (tT/2)
                                    double vP = a * tT / 2;
                                    //Triangle distance
                                    double dA = 0.5 * vP * tT;

                                    if (dA < dT) throw new Exception("Line Accel cannot achive line distance. Increase Line Accel.");

                                    //Excess distance, dE
                                    double dE = dA - dT;

                                    //dE = 1 / 2 * vE * tE, tE = tT / vP * vE
                                    //dE = 1 / 2 * vE * tT / vP * vE
                                    //vE2* tT/ vP = 2 * dE
                                    //vE2 = 2 * dE * vP / tT
                                    //vE = Sqrt(2 * dE * vP / tT)
                                    //Excess speed, vE
                                    double vE = Math.Sqrt(2 * dE * vP / tT);
                                    //Constant Speed
                                    double v = vP - vE;

                                    lineSpeed[lineIndex] = v;
                                    if (GDefine.LogLevel == 1) Log.AddToLog("Line " + lineIndex.ToString() + " " + v.ToString("f3") + "mm/s");

                                    if (lineSpeed[lineIndex] > 100) throw new Exception("Line Speed over 100mm/s. Run Aborted.");

                                    lineIndex++;
                                }
                                break;
                        }
                        if (breakFor) break;
                    }
                }
                #endregion

                int t = GDefine.GetTickCount();
                #region Prepare Paths
                CControl2.TAxis[] Axis = new CControl2.TAxis[] { TaskGantry.GXAxis, TaskGantry.GYAxis, TaskGantry.GZAxis };
                CommonControl.P1245.PathFree(Axis);
                CommonControl.P1245.SetAccel(Axis, Model.LineAccel);
                bool b_Blend = false;
                #endregion

                double relX = 0;
                double relY = 0;
                double relGap = Model.RetGap;
                lineIndex = 0;
                for (int i = 0; i < 100; i++)
                {
                    bool breakFor = false;
                    switch (Line.Index[i])
                    {
                        case (int)EGDispCmd.None:
                            breakFor = true;
                            break;
                        case (int)EGDispCmd.DOT:
                        case (int)EGDispCmd.DOT_START:
                            if (i > 0)
                                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, Model.LineSpeed, 0, new double[3] { Line.X[i], Line.Y[i], 0 }, null);
                            #region Path Move to Disp Gap
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                case ERunMode.Dry:
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, Model.DnSpeed, Model.DnStartV, new double[3] { 0, 0, -relGap }, null);
                                    relGap = 0;
                                    break;
                            }
                            if (Model.DnWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.DnWait, 0, null, null);
                            #endregion
                            #region Path Pump On
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                    {
                                        switch (DispProg.Pump_Type)
                                        {
                                            case TaskDisp.EPumpType.SP:
                                                if (Line.U[i] == 0) TaskDisp.SP.SP_AddOnPaths(Axis);
                                                if (Model.StartDelay > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.StartDelay, 0, null, null);
                                                break;
                                            case TaskDisp.EPumpType.TP:
                                                if (Line.U[i] == 0) TaskDisp.TP.AddOnPaths(Axis);
                                                if (Model.StartDelay > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.StartDelay, 0, null, null);
                                                break;
                                            default:
                                                CControl2.TOutput[] Output = new CControl2.TOutput[] { };
                                                DispProg.Outputs(b_HeadRun, ref Output);
                                                if (Line.U[i] == 0) CommonControl.P1245.PathAddDO(Axis, Output, RunMode == ERunMode.Normal);
                                                if (Model.StartDelay > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.StartDelay, 0, null, null);
                                                break;
                                        }
                                    }
                                    break;
                            }
                            #endregion

                            double nettDotTime = totalDispTime - totalDelayTime;

                            if (nettDotTime > 0)
                                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, nettDotTime, 0, null, null);

                            #region Path Pump Off
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                case ERunMode.Dry:
                                    {
                                        switch (DispProg.Pump_Type)
                                        {
                                            case TaskDisp.EPumpType.SP:
                                                TaskDisp.SP.SP_AddOffPaths(Axis);
                                                break;
                                            case TaskDisp.EPumpType.TP:
                                                TaskDisp.TP.AddOffPaths(Axis);
                                                break;
                                            default:
                                                CControl2.TOutput[] Output = new CControl2.TOutput[] { };
                                                DispProg.Outputs(b_HeadRun, ref Output);
                                                CommonControl.P1245.PathAddDO(Axis, Output, false);
                                                if (b_HeadRun[0] && RunMode == ERunMode.Normal) Stats.DispCount_Inc(0);
                                                if (b_HeadRun[1] && RunMode == ERunMode.Normal) Stats.DispCount_Inc(1);
                                                break;
                                        }
                                    }
                                    break;
                            }
                            if (b_HeadRun[0] && RunMode == ERunMode.Normal) Stats.DispCount_Inc(0);
                            if (b_HeadRun[1] && RunMode == ERunMode.Normal) Stats.DispCount_Inc(1);
                            #endregion
                            if (Model.PostWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.PostWait, 0, null, null);
                            #region Path Retract and Up
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                case ERunMode.Dry:
                                    {
                                        if (Model.RetGap > 0)
                                        {
                                            CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, Model.RetSpeed, Model.RetStartV, new double[3] { 0, 0, Model.RetGap }, null);
                                            relGap += Model.RetGap;
                                            if (Model.RetWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.RetWait, 0, null, null);
                                        }
                                        if (Line.Index[i] == (int)EGDispCmd.DOT && Model.UpGap > 0)
                                        {
                                            CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DDirect, b_Blend, Model.UpSpeed, Model.UpStartV, new double[3] { 0, 0, Model.UpGap }, null);
                                            relGap += Model.UpGap;
                                            if (Model.UpWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.UpWait, 0, null, null);
                                        }
                                        break;
                                    }
                                case ERunMode.Camera:
                                default:
                                    {
                                        if (Model.RetWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.RetWait, 0, null, null);
                                        if (Line.Index[i] == (int)EGDispCmd.DOT && Model.UpWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.UpWait, 0, null, null);
                                        break;
                                    }
                            }
                            #endregion
                            break;
                        case (int)EGDispCmd.DOT_END:
                            #region Path Retract and Up
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                case ERunMode.Dry:
                                    {
                                        //if (Model.UpGap > 0)
                                        {
                                            CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, Model.LineSpeed, 0, new double[3] { Line.X[i], Line.Y[i], 0 }, null);

                                            if (Model.UpGap > 0)
                                            {
                                                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DDirect, b_Blend, Model.UpSpeed, Model.UpStartV, new double[3] { 0, 0, Model.UpGap }, null);
                                                relGap += Model.UpGap;
                                                if (Model.UpWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.UpWait, 0, null, null);
                                            }
                                        }
                                        break;
                                    }
                                case ERunMode.Camera:
                                default:
                                    {
                                        CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, Model.UpSpeed, 0, new double[3] { Line.X[i], Line.Y[i], 0 }, null);
                                        if (Model.UpWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.UpWait, 0, null, null);
                                        break;
                                    }
                            }
                            #endregion
                            break;
                        case (int)EGDispCmd.LINE_START:
                            if (i > 0)
                            {
                                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, TaskGantry.GXAxis.Para.FastV, 0, new double[3] { Line.X[i] - relX, Line.Y[i] - relY, 0 }, null);
                                relX = 0;
                                relY = 0;
                            }
                            #region Path Move to Disp Gap
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                case ERunMode.Dry:
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, Model.DnSpeed, Model.DnStartV, new double[3] { 0, 0, -relGap }, null);
                                    relGap = 0;
                                    break;
                            }
                            if (Model.DnWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.DnWait, 0, null, null);
                            #endregion
                            #region Path Pump On
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                    {
                                        switch (DispProg.Pump_Type)
                                        {
                                            case TaskDisp.EPumpType.SP:
                                                if (Line.U[i] == 0) TaskDisp.SP.SP_AddOnPaths(Axis);
                                                if (Model.StartDelay > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.StartDelay, 0, null, null);
                                                break;
                                            case TaskDisp.EPumpType.TP:
                                                if (Line.U[i] == 0) TaskDisp.TP.AddOnPaths(Axis);
                                                if (Model.StartDelay > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.StartDelay, 0, null, null);
                                                break;
                                            default:
                                                CControl2.TOutput[] Output = new CControl2.TOutput[] { };
                                                DispProg.Outputs(b_HeadRun, ref Output);
                                                if (Line.U[i] == 0) CommonControl.P1245.PathAddDO(Axis, Output, RunMode == ERunMode.Normal);
                                                if (Model.StartDelay > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.StartDelay, 0, null, null);
                                                break;
                                        }
                                    }
                                    break;
                            }
                            #endregion
                            break;
                        case (int)EGDispCmd.LINE_PASS:
                            #region Path Pass
                            CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, lineSpeed[lineIndex], 0, new double[3] { Line.X[i], Line.Y[i], 0 }, null);
                            #endregion
                            break;
                        case (int)EGDispCmd.LINE_END:
                            #region Path Pass
                            CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, lineSpeed[lineIndex], 0, new double[3] { Line.X[i], Line.Y[i], 0 }, null);
                            #endregion
                            #region Path Pump Off
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                case ERunMode.Dry:
                                    {
                                        switch (DispProg.Pump_Type)
                                        {
                                            case TaskDisp.EPumpType.SP:
                                                TaskDisp.SP.SP_AddOffPaths(Axis);
                                                break;
                                            case TaskDisp.EPumpType.TP:
                                                TaskDisp.TP.AddOffPaths(Axis);
                                                break;
                                            default:
                                                CControl2.TOutput[] Output = new CControl2.TOutput[] { };
                                                DispProg.Outputs(b_HeadRun, ref Output);
                                                CommonControl.P1245.PathAddDO(Axis, Output, false);
                                                if (b_HeadRun[0] && RunMode == ERunMode.Normal) Stats.DispCount_Inc(0);
                                                if (b_HeadRun[1] && RunMode == ERunMode.Normal) Stats.DispCount_Inc(1);
                                                break;
                                        }
                                    }
                                    break;
                            }
                            if (b_HeadRun[0] && RunMode == ERunMode.Normal) Stats.DispCount_Inc(0);
                            if (b_HeadRun[1] && RunMode == ERunMode.Normal) Stats.DispCount_Inc(1);
                            #endregion
                            #region Path CutTail
                            double lineLength = Math.Sqrt(Math.Pow(Line.X[i], 2) + Math.Pow(Line.Y[i], 2));
                            double extRelX = Line.X[i] * Line.DPara[10] / lineLength;
                            double extRelY = Line.Y[i] * Line.DPara[10] / lineLength;
                            double cutTailSpeed = Line.DPara[11];
                            double cutTailSSpeed = Math.Min(Model.LineStartV, cutTailSpeed);
                            double cutTailHeight = Line.DPara[12];
                            ECutTailType cutTailType = ECutTailType.None;
                            try { cutTailType = (ECutTailType)Line.DPara[13]; } catch { };

                            switch (cutTailType)
                            {
                                case ECutTailType.None:
                                    break;
                                case ECutTailType.Fwd:
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { extRelX, extRelY, cutTailHeight }, null);
                                    relX = extRelX;
                                    relY = extRelY;
                                    break;
                                case ECutTailType.Bwd:
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { -extRelX, -extRelY, cutTailHeight }, null);
                                    relX = -extRelX;
                                    relY = -extRelY;
                                    break;
                                case ECutTailType.SqFwd:
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { 0, 0, cutTailHeight }, null);
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { extRelX, extRelY, 0 }, null);
                                    relX = extRelX;
                                    relY = extRelY;
                                    break;
                                case ECutTailType.SqBwd:
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { 0, 0, cutTailHeight }, null);
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { -extRelX, -extRelY, 0 }, null);
                                    relX = -extRelX;
                                    relY = -extRelY;
                                    break;
                                case ECutTailType.Rev:
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { extRelX, extRelY, 0 }, null);
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { -extRelX, -extRelY, cutTailHeight }, null);
                                    break;
                                case ECutTailType.SqRev:
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { extRelX, extRelY, 0 }, null);
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { 0, 0, cutTailHeight }, null);
                                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, cutTailSpeed, cutTailSSpeed, new double[3] { -extRelX, -extRelY, 0 }, null);
                                    break;
                            }
                            relGap += cutTailHeight;
                            lineIndex++;
                            #endregion
                            #region Path Retract and Up
                            switch (RunMode)
                            {
                                case ERunMode.Normal:
                                case ERunMode.Dry:
                                    {
                                        if (Model.RetGap > 0)
                                        {
                                            CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, Model.RetSpeed, Model.RetStartV, new double[3] { 0, 0, Model.RetGap }, null);
                                            relGap += Model.RetGap;
                                            if (Model.RetWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.RetWait, 0, null, null);
                                        }
                                        if (Model.UpGap > 0)
                                        {
                                            CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel4DDirect, b_Blend, Model.UpSpeed, Model.UpStartV, new double[3] { 0, 0, Model.UpGap }, null);
                                            relGap += Model.UpGap;
                                            if (Model.UpWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.UpWait, 0, null, null);
                                        }
                                        break;
                                    }
                                case ERunMode.Camera:
                                default:
                                    {
                                        if (Model.RetWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.RetWait, 0, null, null);
                                        if (Model.UpWait > 0) CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, b_Blend, Model.UpWait, 0, null, null);
                                        break;
                                    }
                            }
                            #endregion
                            break;
                    }
                    if (breakFor) break;
                }

                #region Move Paths
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel3DLine, b_Blend, TaskGantry.GXAxis.Para.FastV, 0, new double[3] { 0.001, 0.001, 0 }, null);

                uint index = 0, curr = 0, remain = 0;
                CommonControl.P1245.PathInfo(Axis, ref index, ref curr, ref remain);
                if (remain > 0) CommonControl.P1245.PathEnd(Axis);
                CommonControl.P1245.PathMove(Axis);
                while (true)
                {
                    if (!CommonControl.P1245.AxisBusy(Axis)) break;
                }
                if (GDefine.LogLevel == 1) Log.AddToLog("Line Time " + (GDefine.GetTickCount() - t).ToString("f3") + "ms");
                #endregion}
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                TaskDisp.TrigOff(true, true);
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(EMsg);
            }
        _End:
            GDefine.Status = EStatus.Ready;
            return true;
        _Stop:
            GDefine.Status = EStatus.Stop;
            return false;
        _Error:
            GDefine.Status = EStatus.ErrorInit;
            return false;
        }
    }

    internal class MeasTemp
    {
        public static bool Execute(DispProg.TLine Line, ERunMode RunMode, double f_origin_x, double f_origin_y, double f_origin_z)
        {
            int points = Line.IPara[1];
            if (points == 0) return true;

            try
            {
                GDefine.Status = EStatus.Busy;

                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                switch (RunMode)
                {
                    case ERunMode.Dry:
                    case ERunMode.Normal:
                        TaskVision.LightingOff();
                        break;
                    case ERunMode.Camera:
                        TaskVision.LightingOn(TaskVision.DefLightRGB);
                        break;
                }

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);

                    if (!TaskGantry.SetMotionParamGX2Y2()) goto _Error;
                    if (!TaskGantry.MoveAbsGX2Y2(GX2Y2.X, GX2Y2.Y, false)) goto _Error;

                    TaskGantry.WaitGX2Y2();
                }

                List<TPos2> pos = new List<TPos2>();
                List<double> temp = new List<double>();
                for (int i = 0; i < points; i++)
                {
                    #region assign and translate position
                    double dx = f_origin_x + DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex].X + Line.X[i];
                    double dy = f_origin_y + DispProg.rt_LayoutRelPos[DispProg.RunTime.UIndex].Y + Line.Y[i];
                    DispProg.TranslatePos(dx, dy, DispProg.rt_Head1RefData, ref dx, ref dy);

                    TPos2 GXY = new TPos2(dx, dy);
                    #endregion

                    #region Move To Pos
                    switch (RunMode)
                    {
                        case ERunMode.Normal:
                        case ERunMode.Dry:
                            {
                                GXY.X = GXY.X + TaskDisp.TempSensor_Ofst.X;
                                GXY.Y = GXY.Y + TaskDisp.TempSensor_Ofst.Y;
                                break;
                            }
                        case ERunMode.Camera:
                        default:
                            {
                                break;
                            }
                    }

                    if (!TaskGantry.SetMotionParamGXY()) goto _Error;
                    if (!TaskGantry.MoveAbsGXY(GXY.X, GXY.Y, false)) goto _Error;
                    TaskGantry.WaitGXY();
                    #endregion

                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    //int SettleTime = Line.IPara[4];
                    while (sw.ElapsedMilliseconds < TaskLaser.TempSensor_SettleTime) Thread.Sleep(0);

                    double d = 0;
                    TFTempSensor.GetTemp(ref d);

                    pos.Add(GXY);
                    temp.Add(d);
                }

                if (DispProg.Options_EnableProcessLog)
                {
                    string str = $"MeasTemp\t";
                    //str += $"MeasID\t{Line.ID}\t";
                    //str += $"UnitNo={DispProg.RunTime.UIndex}\t";
                    str += $"C,R={DispProg.RunTime.Head_CR[0].X},{DispProg.RunTime.Head_CR[0].Y}\t";
                    for (int i = 0; i < temp.Count; i++)
                    {
                        str += $"X,Y,T={pos[i].X:f3},{pos[i].Y:f3},{temp[i]:f1}\t";
                    }
                    GLog.WriteProcessLog(str);
                }
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                throw new Exception(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + Ex.Message.ToString());
            }
            GDefine.Status = EStatus.Ready;
            return true;
        _Error:
            GDefine.Status = EStatus.ErrorInit;
            return false;
        }
    }
}