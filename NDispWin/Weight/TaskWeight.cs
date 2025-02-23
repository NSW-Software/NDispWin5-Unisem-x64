using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace NDispWin
{
    internal class TaskWeight
    {
        const double FACTOR_MPaToPSI = 145.038;

        public enum EMeasureHead { L, R };
        public static EMeasureHead MeasureHead = EMeasureHead.L;
        public enum EHeadNo { One, Two };

        public static TPos3[] Needle_Weight_Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };

        public static int PurgeCount = 2;
        public static int MeasureCount = 10;

        public enum EOutputResult { Total, Average };

        public static int DotsPerSample = 1;
        public static EOutputResult OutputResult = EOutputResult.Total;

        public static int IgnoreAfterFillCount = 2;

        public static int PreWaitTime = 100;
        public static int DispTime = 100;
        public static int PostWaitTime = 100;
        public static double ZUpDist = 0;
        public static double ZUpSpeed = 100;

        public enum EMeasPosMethod { Fix, PCD };
        public static EMeasPosMethod MeasPosMethod = EMeasPosMethod.Fix;
        public static int MeasPosPCD = 5;
        public static int MeasPosCount = 8;

        public static int StartMeasDelay = 3000;
        public static int EndMeasDelay = 15000;
        public static bool CleanOnStart = false;

        public enum EMeasType { Cal, Meas }
        public static int iDotsPerSample(EMeasType measType)
        {
            if (measType == EMeasType.Cal)
            {
                if (DispProg.DotsPerSample_Cal > 0)
                    return DispProg.DotsPerSample_Cal;
            }
            if (measType == EMeasType.Meas)
            {
                if (DispProg.DotsPerSample_Meas > 0)
                    return DispProg.DotsPerSample_Meas;
            }
            return DotsPerSample;
        }
        public static EOutputResult eOutputResult(EMeasType measType)
        {
            if (measType == EMeasType.Cal)
            {
                if (DispProg.DotsPerSample_Cal > 0)
                    return DispProg.OutputResult_Cal;
            }
            if (measType == EMeasType.Meas)
            {
                if (DispProg.DotsPerSample_Meas > 0)
                    return DispProg.OutputResult_Meas;
            }
            return OutputResult;
        }

        public static double MeasureSpec = 5;//volatile
        public static double MeasureSpecTol = 0.5;
        public enum EWeightMeasStatus { None, Require, Measured, Fail };
        public static bool Meas_RequireOnLotStart = false;
        public static EWeightMeasStatus Meas_Status = EWeightMeasStatus.None;

        public static double Cal_Meas_Weight = 1;//volatile
        public static double CalTol = 0.10;
        public static int CalMaxAttempt = 10;
        public static int CalAcceptCount = 3;
        public static double CalMaxPressAdjRate = 5;//unit MPa def 0.03
        public static double[] CurrentCal = new double[TaskDisp.MAX_HEADCOUNT];
        public enum EWeightCalStatus { None, Require, Calibrated, Fail };
        public static bool Cal_RequireOnLotStart = false;
        public static bool Cal_RequireOnLoadProgram = false;
        public static EWeightCalStatus Cal_Status = EWeightCalStatus.None;

        public static void LoadDefault()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(GDefine.WeightPath + "\\" + "Weight" + ".def");

            for (int i = 0; i < TaskDisp.MAX_HEADCOUNT; i++)
            {
                CurrentCal[i] = IniFile.ReadDouble("Weight", "CurrentCal" + i.ToString(), 1);
            }
        }
        public static void SaveDefault()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(GDefine.WeightPath + "\\" + "Weight" + ".def");

            for (int i = 0; i < TaskDisp.MAX_HEADCOUNT; i++)
            {
                IniFile.WriteDouble("Weight", "CurrentCal" + i.ToString(), CurrentCal[i]);
            }
        }

        public static void LoadSetup(string SetupName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(GDefine.WeightPath + "\\" + SetupName + ".ini");

            for (int i = 0; i < TaskDisp.MAX_HEADCOUNT; i++)
            {
                Needle_Weight_Pos[i].X = IniFile.ReadFloat("Needle" + i.ToString(), "WeightPos_X", 0);
                Needle_Weight_Pos[i].Y = IniFile.ReadFloat("Needle" + i.ToString(), "WeightPos_Y", 0);
                Needle_Weight_Pos[i].Z = IniFile.ReadFloat("Needle" + i.ToString(), "WeightPos_Z", 0);
            }

            #region Sample Setting
            DotsPerSample = IniFile.ReadInteger("Sample", "DotsPerSample", 1);
            OutputResult = (EOutputResult)IniFile.ReadInteger("Sample", "OutputResult", 0);
            #endregion

            #region Common Setting
            PurgeCount = IniFile.ReadInteger("Common", "PurgeCount", 2);
            IgnoreAfterFillCount = IniFile.ReadInteger("Common", "IgnoreAfterFillCount", 2);

            PreWaitTime = IniFile.ReadInteger("Common", "PreWaitTime", 50);
            DispTime = IniFile.ReadInteger("Common", "DispTime", 100);
            PostWaitTime = IniFile.ReadInteger("Common", "PostWaitTime", 200);
            ZUpDist = IniFile.ReadDouble("Common", "ZUpDist", 0);
            ZUpSpeed = IniFile.ReadDouble("Common", "ZUpSpeed", 100);

            StartMeasDelay = IniFile.ReadInteger("Common", "StartMeasDelay", 3000);
            EndMeasDelay = IniFile.ReadInteger("Common", "EndMeasDelay", 15000);
            CleanOnStart = IniFile.ReadBool("Common", "CleanOnStart", false);

            MeasPosMethod = (EMeasPosMethod)IniFile.ReadInteger("Common", "MeasPosMethod", 0);
            MeasPosPCD = IniFile.ReadInteger("Common", "MeasPosPCD", 5);
            MeasPosCount = IniFile.ReadInteger("Common", "MeasPosCount", 8);
            #endregion

            #region Cal Setting
            CalTol = IniFile.ReadFloat("Cal", "Tol", 0.1);
            CalMaxAttempt = IniFile.ReadInteger("Cal", "MaxAttempt", 10);
            CalAcceptCount = IniFile.ReadInteger("Cal", "AcceptCount", 3);
            CalMaxPressAdjRate = IniFile.ReadDouble("Cal", "InitialAdjPress", 0.03);
            Cal_RequireOnLotStart = IniFile.ReadBool("Cal", "RequireOnLotStart", false);
            #endregion

            #region Measurement
            MeasureCount = IniFile.ReadInteger("Measure", "Count", 10);
            MeasureSpecTol = IniFile.ReadFloat("Measure", "SpecTol", 0.05);
            Meas_RequireOnLotStart = IniFile.ReadBool("Measure", "RequireOnLotStart", false);
            #endregion
        }
        public static void SaveSetup(string SetupName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(GDefine.WeightPath + "\\" + SetupName + ".ini");

            for (int i = 0; i < TaskDisp.MAX_HEADCOUNT; i++)
            {
                IniFile.WriteFloat("Needle" + i.ToString(), "WeightPos_X", Needle_Weight_Pos[i].X);
                IniFile.WriteFloat("Needle" + i.ToString(), "WeightPos_Y", Needle_Weight_Pos[i].Y);
                IniFile.WriteFloat("Needle" + i.ToString(), "WeightPos_Z", Needle_Weight_Pos[i].Z);
            }

            #region Sample Setting
            IniFile.WriteInteger("Sample", "DotsPerSample", DotsPerSample);
            IniFile.WriteInteger("Sample", "OutputResult", (int)OutputResult);
            #endregion

            #region Common Setting
            IniFile.WriteInteger("Common", "PurgeCount", PurgeCount);
            IniFile.WriteInteger("Common", "IgnoreAfterFillCount", IgnoreAfterFillCount);

            IniFile.WriteInteger("Common", "PreWaitTime", PreWaitTime);
            IniFile.WriteInteger("Common", "DispTime", DispTime);
            IniFile.WriteInteger("Common", "PostWaitTime", PostWaitTime);
            IniFile.WriteDouble("Common", "ZUpDist", ZUpDist);
            IniFile.WriteDouble("Common", "ZUpSpeed", ZUpSpeed);

            IniFile.WriteInteger("Common", "StartMeasDelay", StartMeasDelay);
            IniFile.WriteInteger("Common", "EndMeasDelay", EndMeasDelay);

            IniFile.WriteInteger("Common", "MeasPosMethod", (int)MeasPosMethod);
            IniFile.WriteInteger("Common", "MeasPosPCD", MeasPosPCD);
            IniFile.WriteInteger("Common", "MeasPosCount", MeasPosCount);
            IniFile.WriteBool("Common", "CleanOnStart", CleanOnStart);
            #endregion

            #region Cal Setting
            IniFile.WriteFloat("Cal", "Tol", CalTol);
            IniFile.WriteInteger("Cal", "MaxAttempt", CalMaxAttempt);
            IniFile.WriteInteger("Cal", "AcceptCount", CalAcceptCount);
            IniFile.WriteDouble("Cal", "InitialAdjPress", CalMaxPressAdjRate);
            IniFile.WriteBool("Cal", "RequireOnLotStart", Cal_RequireOnLotStart);
            IniFile.WriteBool("Cal", "RequireOnLoadProgram", Cal_RequireOnLoadProgram);
            #endregion

            #region Measurement
            IniFile.WriteInteger("Measure", "Count", MeasureCount);
            IniFile.WriteFloat("Measure", "SpecTol", MeasureSpecTol);
            IniFile.WriteBool("Measure", "RequireOnLotStart", Meas_RequireOnLotStart);
            #endregion
        }

        public static bool WeightOpen()
        {
            if (GDefine.WeightStType == WGH_Series.TEWeight.EWeighType.None) return true;

            try
            {
                if (WGH_Series.TEWeight.IsOpen)
                {
                    WGH_Series.TEWeight.Close();
                }

                if (!WGH_Series.TEWeight.IsOpen)
                {
                    string ComNo = "COM" + GDefine.WeightComport.ToString();
                    WGH_Series.TEWeight.Open(ComNo, GDefine.WeightStType);

                    double g = 0;
                    WGH_Series.TEWeight.ReadImme(ref g);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("WeightOpen " + (char)9 + ex.Message.ToString());
                return false;
            }
            return true;
        }
        public static void WeightClose()
        {
            try
            {
                if (WGH_Series.TEWeight.IsOpen)
                {
                    WGH_Series.TEWeight.Close();
                }
            }
            catch { }
        }
        public static bool WeightIsOpen
        {
            get { return WGH_Series.TEWeight.IsOpen; }
        }
        public static bool WeightTare()
        {
            if (GDefine.WeightStType == WGH_Series.TEWeight.EWeighType.None) return false;

            try
            {
                if (!WGH_Series.TEWeight.IsOpen)
                {
                    if (!WeightOpen()) return false;
                }

                WGH_Series.TEWeight.Tare();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("WeightTare " + (char)9 + ex.Message.ToString());
                return false;
            }
            return true;
        }
        public static bool WeightZero()
        {
            if (GDefine.WeightStType == WGH_Series.TEWeight.EWeighType.None) return false;

            try
            {
                if (!WGH_Series.TEWeight.IsOpen)
                {
                    if (!WeightOpen()) return false;
                }

                WGH_Series.TEWeight.Zero();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("WeightZero " + (char)9 + ex.Message.ToString());
                return false;
            }
            return true;
        }
        static double SoftZeroValue = 0;
        public static bool SoftZero()
        {
            double mg = 0;
            try
            {
                WeightGrossValue(ref mg);
                SoftZeroValue = mg;
            }
            catch { }
            return true;
        }
        public static void SoftZeroReset()
        {
            SoftZeroValue = 0;
        }

        readonly static Mutex MutexWeight = new Mutex();
        public static bool WeightGrossValue(ref double mg)
        {
            MutexWeight.WaitOne();

            if ((int)GDefine.WeightStType == 0)
            {
                return false;
            }

            if (!WeightIsOpen)
            {
                if (!WeightOpen()) return false;
            }

            try
            {
                double g = 0;
                mg = 0;
                WGH_Series.TEWeight.ReadImme(ref g);
                mg = g * 1000;
            }
            catch (Exception Ex)
            {
                MutexWeight.ReleaseMutex();
                Msg MsgBox = new Msg();
                MsgBox.Show("WeightValue " + Ex.Message.ToString());
                return false;
            }
            MutexWeight.ReleaseMutex();
            return true;
        }
        public static bool WeightValue(ref double mg)
        {
            bool b = WeightGrossValue(ref mg);
            mg = mg - SoftZeroValue;
            return b;
        }


        /// <summary>
        /// Move to PCD Position
        /// </summary>
        /// <param name="Head">HeadNo; Start from 1</param>
        /// <param name="PCD">Pitch Center Diameter</param>
        /// <param name="TotalPos">Total Positions</param>
        /// <param name="PosNo">Position No, Start from 0</param>
        /// <param name="StartEnd">Move to Start=0, End=1</param>
        /// <returns></returns>
        public static bool MoveWeightXY_PCD(int Head, double PCD, double TotalPos, int PosNo, int StartEnd)
        {
            TPos2 GXY = new TPos2(Needle_Weight_Pos[0].X, Needle_Weight_Pos[0].Y);
            TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);

            NSW.Net.Point2D Center = new NSW.Net.Point2D(GXY.X, GXY.Y);
            NSW.Net.Point2D PtNo1 = new NSW.Net.Point2D(GXY.X + PCD / 2, GXY.Y);

            double Ang_Res_Rad = (Math.PI * 2) / TotalPos;
            double Ang_Start_Rad = Ang_Res_Rad * PosNo;
            double Ang_End_Rad = Ang_Res_Rad * (PosNo + (TotalPos / 2));

            NSW.Net.Point2D PtNo_n_Start = PtNo1.Rotate(Center, Ang_Start_Rad);
            NSW.Net.Point2D PtNo_n_End = PtNo1.Rotate(Center, Ang_End_Rad);

            if (StartEnd == 0)
                GXY = new TPos2(PtNo_n_Start.X, PtNo_n_Start.Y);
            else
                GXY = new TPos2(PtNo_n_End.X, PtNo_n_End.Y);

            if (Head == 2)
            {
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    GXY.X = GXY.X - TaskDisp.Head2_DefDistX;
                }
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XYZ && GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                {
                    GXY.X = GXY.X - TaskDisp.Head_PitchX;
                }
            }

            //if (!TaskDisp.GotoXYPos(GXY, GX2Y2)) return false;

            if (!TaskGantry.SetMotionParamEx(TaskGantry.GXAxis, TaskGantry.GXAxis.Para.SlowV, TaskWeight.ZUpSpeed, TaskGantry.GXAxis.Para.Accel)) return false;
            if (!TaskGantry.MoveAbsGXY(GXY.X, GXY.Y, false)) return false;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                if (!TaskGantry.MoveAbsGX2Y2(GX2Y2.X, GX2Y2.Y, false)) return false;
            }

            if (!TaskGantry.WaitGXY()) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.WaitGX2Y2()) return false;
            }



            GDefine.Status = EStatus.Ready;
            return true;
        }
        /// <summary>
        /// Move selected head to Weight XY Position
        /// </summary>
        /// <param name="Head">1=Head1, 2=Head2</param>
        /// <returns></returns>
        public static bool TaskGotoWeightXY(int Head)
        {
            GDefine.Status = EStatus.Busy;

            if (!TaskDisp.TaskMoveGZUp()) return false;

            TPos2 GXY = new TPos2(Needle_Weight_Pos[0].X, Needle_Weight_Pos[0].Y);
            TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);

            if (Head == 2)
            {
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    GXY.X = GXY.X - TaskDisp.Head2_DefDistX;
                }
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XYZ && GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                {
                    GXY.X = GXY.X - TaskDisp.Head_PitchX;
                }
            }

            if (!TaskDisp.GotoXYPos(GXY, GX2Y2)) return false;

            GDefine.Status = EStatus.Ready;
            return true;
        }
        /// <summary>
        /// Move selected head to Weight Z Position
        /// </summary>
        /// <param name="Head"></param>
        /// <returns></returns>
        public static bool TaskGotoWeightZ(int Head)
        {
            string EMsg = "TaskGotoWeightZ";

            GDefine.Status = EStatus.Busy;

            if (Head == 1)
            {
                if (!TaskDisp.TaskMoveAbsGZZ2(Needle_Weight_Pos[0].Z, 0)) return false;
            }
            if (Head == 2)
            {
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskDisp.TaskMoveAbsGZZ2(0, Needle_Weight_Pos[1].Z)) return false;
                }
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XYZ && GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                {
                    if (!TaskDisp.TaskMoveAbsGZZ2(Needle_Weight_Pos[0].Z, 0)) return false;
                }
            }

            GDefine.Status = EStatus.Ready;
            return true;
        }
        /// <summary>
        /// Move selected head to Weight XY, Promt Move to Z Position
        /// </summary>
        /// <param name="Head">1=Head1, 2=Head2</param>
        /// <param name="PromptZDown">Prompt to Move Z Down</param>
        /// <returns></returns>
        public static bool TaskGotoWeight(int Head, bool PromptZDown)
        {
            string EMsg = "TaskGotoWeight";

            GDefine.Status = EStatus.Busy;

            if (!TaskGotoWeightXY(Head)) return false;
            if (PromptZDown)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.MOVE_ZAXIS_TO_POSITION, EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                if (MsgRes == EMsgRes.smrCancel)
                {
                    goto _End;
                }
            }
            if (!TaskGotoWeightZ(Head)) return false;
            _End:
            GDefine.Status = EStatus.Ready;
            return true;
        }
        /// <summary>
        /// Move selected head to Weight XYZ Position
        /// </summary>
        /// <param name="Head">1=Head1, 2=Head2</param>
        /// <param name="PromptZDown">Prompt to Move Z Down</param>
        /// <returns></returns>
        public static bool TaskGotoWeight(int Head)//Start from 1
        {
            return TaskGotoWeight(Head, false);
        }

        static int PosNo = 0;
        public static bool Weight_DownWeightUp(int HeadNo, EMeasType measType, ref double Weight, ref bool IsFilling)
        {
            int t = 0;

            IsFilling = false;

            bool b_Head1Run = (HeadNo == 1);
            bool b_Head2Run = (HeadNo == 2);

            double d_Start_mg = 0;
            double d_End_mg = 0;

            if (MeasPosMethod == EMeasPosMethod.PCD)
            {
                if (PosNo >= MeasureCount) PosNo = 0;
                if (!TaskWeight.MoveWeightXY_PCD(HeadNo, MeasPosPCD, MeasPosCount, PosNo, 0)) return false;
            }

            if (StartMeasDelay == 0)
            {
                if (!WeightValue(ref d_Start_mg)) goto _Error;
                if (!TaskWeight.TaskGotoWeightZ(HeadNo)) goto _Error;
            }
            else
            {
                if (!TaskWeight.TaskGotoWeightZ(HeadNo)) goto _Error;

                #region StartMeasDelay
                t = GDefine.GetTickCount() + TaskWeight.StartMeasDelay;
                while (GDefine.GetTickCount() < t) { Application.DoEvents(); Thread.Sleep(5); }
                #endregion

                if (!WeightValue(ref d_Start_mg)) goto _Error;
            }

            #region PreWaitTime
            t = GDefine.GetTickCount() + TaskWeight.PreWaitTime;
            while (GDefine.GetTickCount() < t) { Application.DoEvents(); Thread.Sleep(5); }
            #endregion

            //int cycles = 0;
            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.Vermes:
                case TaskDisp.EPumpType.Vermes1560:
                    {
                        //if (TaskDisp.Vermes3200[0].IsOpen) cycles = TaskDisp.Vermes3200[0].ValveCycles;
                        //if (TaskDisp.Vermes1560[0].IsOpen) cycles = TaskDisp.Vermes1560[0].ValveCycles;

                            if (!TaskDisp.CtrlWaitReady(b_Head1Run, b_Head2Run)) goto _Error;
                        if (!TaskDisp.TrigOn(b_Head1Run, b_Head2Run)) goto _Error;
                        if (!TaskDisp.CtrlWaitResponse(b_Head1Run, b_Head2Run)) goto _Error;
                        if (!TaskDisp.TrigOff(b_Head1Run, b_Head2Run)) goto _Error;
                        if (!TaskDisp.CtrlWaitComplete(b_Head1Run, b_Head2Run)) goto _Error;

                        if (DispProg.Pump_Type == TaskDisp.EPumpType.Vermes)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                if (TaskDisp.Vermes3200[i].IsOpen)
                                {
                                    int np = (int)TaskDisp.Vermes3200[i].Param.NP;
                                    NDispWin.Material.Unit.Count[i] += np;


                                    //int runCycles = TaskDisp.Vermes3200[i].ValveCycles - cycles;
                                    //NDispWin.Material.Unit.Count[i] += runCycles;
                                }
                            }
                        }
                        if (DispProg.Pump_Type == TaskDisp.EPumpType.Vermes1560)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                if (TaskDisp.Vermes1560[i].IsOpen)
                                {
                                    int np = (int)TaskDisp.Vermes1560[i].NP[0];
                                    NDispWin.Material.Unit.Count[i] += np;

                                    //int runCycles = TaskDisp.Vermes1560[i].ValveCycles - cycles;
                                    //NDispWin.Material.Unit.Count[i] += runCycles;
                                }
                            }
                        }
                        break;
                    }
                default:
                    {
                        if (TaskWeight.DispTime == 0)
                        {
                            #region Signal Handshake PP Handshake
                            for (int i = 0; i < iDotsPerSample(measType); i++)
                            {
                                if (!TaskDisp.CtrlWaitReady(b_Head1Run, b_Head2Run)) goto _Error;
                                if (!TaskDisp.TrigOn(b_Head1Run, b_Head2Run)) goto _Error;
                                if (!TaskDisp.CtrlWaitResponse(b_Head1Run, b_Head2Run)) goto _Error;
                                if (!TaskDisp.TrigOff(b_Head1Run, b_Head2Run)) goto _Error;
                                Application.DoEvents();
                                if (!TaskDisp.CtrlWaitComplete(b_Head1Run, b_Head2Run)) goto _Error;
                                TaskDisp.Thread_CheckIsFilling_Run(b_Head1Run, b_Head2Run);
                                Thread.Sleep(500);
                                //return;
                                TaskDisp.Thread_CheckIsFilling_Run(b_Head1Run, b_Head2Run);
                                if (!IsFilling)
                                    IsFilling = TaskDisp.IsFilling();
                            }
                            #endregion
                        }
                        else
                        {
                            #region Signal Handshake
                            for (int i = 0; i < iDotsPerSample(measType); i++)
                            {
                                if (!TaskDisp.CtrlWaitReady(b_Head1Run, b_Head2Run)) goto _Error;
                                if (!TaskDisp.TrigOn(b_Head1Run, b_Head2Run)) goto _Error;
                                if (!TaskDisp.CtrlWaitResponse(b_Head1Run, b_Head2Run)) goto _Error;

                                t = GDefine.GetTickCount() + TaskWeight.DispTime;
                                while (GDefine.GetTickCount() < t)
                                {
                                    Thread.Sleep(1);
                                }
                                if (!TaskDisp.TrigOff(b_Head1Run, b_Head2Run)) goto _Error;
                            }
                            #endregion
                        }
                        break;
                    }
            }

            #region PostWaitTime
            t = GDefine.GetTickCount() + TaskWeight.PostWaitTime;
            while (GDefine.GetTickCount() < t)
            {
                Application.DoEvents();
                Thread.Sleep(5);
                TaskDisp.Thread_CheckIsFilling_Run(b_Head1Run, b_Head2Run);
            }
            #endregion

            if (!IsFilling) IsFilling = TaskDisp.IsFilling();

            if (MeasPosMethod == EMeasPosMethod.PCD)
            {
                if (!TaskWeight.MoveWeightXY_PCD(HeadNo, MeasPosPCD, MeasPosCount, PosNo, 1)) return false;
                PosNo++;
            }

            if (ZUpDist > 0)
            {
                try
                {
                    if (!TaskGantry.SetMotionParamGZZ2(TaskGantry.GZAxis.Para.StartV, TaskWeight.ZUpSpeed, TaskGantry.GZAxis.Para.Accel)) goto _Error;

                    if (b_Head1Run)
                        if (!TaskGantry.MoveRelGZ(ZUpDist, true)) goto _Error;
                    if (b_Head2Run)
                    {
                        if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                        {
                            if (!TaskGantry.MoveRelGZ2(ZUpDist, true)) goto _Error;
                        }
                        if (GDefine.GantryConfig == GDefine.EGantryConfig.XYZ && GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                        {
                            if (!TaskGantry.MoveRelGZ(ZUpDist, true)) goto _Error;
                        }
                    }

                }
                catch
                {
                    goto _Error;
                }
            }

            #region EndMeasDelay
            t = GDefine.GetTickCount() + TaskWeight.EndMeasDelay;
            while (GDefine.GetTickCount() < t) { Application.DoEvents(); Thread.Sleep(5); }
            #endregion

            if (!WeightValue(ref d_End_mg)) goto _Error;

            Weight = d_End_mg - d_Start_mg;
            return true;

        _Error:
            return false;
        }
        //Original weight method.
        public static bool Weight_DownWeightUp(int headIdx, double time_s, ref double weight)
        //Now weight method. Used by TaskFlowRate and TaskMeasWeight, applicable to SP and TP only.
        {
            int t = 0;

            double d_Start_mg = 0;
            double d_End_mg = 0;

            if (MeasPosMethod == EMeasPosMethod.PCD)
            {
                if (PosNo >= MeasureCount) PosNo = 0;
                if (!TaskWeight.MoveWeightXY_PCD(headIdx, MeasPosPCD, MeasPosCount, PosNo, 0)) return false;
            }

            if (!TaskWeight.TaskGotoWeightZ(headIdx + 1)) goto _Error;

            #region StartMeasDelay
            t = GDefine.GetTickCount() + TaskWeight.StartMeasDelay;
            while (GDefine.GetTickCount() < t) { Thread.Sleep(5); }
            #endregion

            if (!WeightValue(ref d_Start_mg)) goto _Error;

            t = GDefine.GetTickCount() + TaskWeight.PreWaitTime;
            while (GDefine.GetTickCount() < t) { Thread.Sleep(5); }

            //TaskDisp.SP.SP_Shot(DispProg.FlowRate.Duration * 1000);
            switch (DispProg.Pump_Type)
            {

                case TaskDisp.EPumpType.SP:
                    TaskDisp.SP.SP_Shot(time_s*1000);
                    break;
                case TaskDisp.EPumpType.TP:
                    TaskDisp.TP.TP_Shot(time_s * 1000);
                    break;
            }

            t = GDefine.GetTickCount() + TaskWeight.PostWaitTime;
            while (GDefine.GetTickCount() < t) { Thread.Sleep(5); }

            if (MeasPosMethod == EMeasPosMethod.PCD)
            {
                if (!TaskWeight.MoveWeightXY_PCD(headIdx, MeasPosPCD, MeasPosCount, PosNo, 1)) return false;
                PosNo++;
            }

            if (ZUpDist > 0)
            {
                try
                {
                    if (!TaskGantry.SetMotionParamGZZ2(TaskGantry.GZAxis.Para.StartV, TaskWeight.ZUpSpeed, TaskGantry.GZAxis.Para.Accel)) goto _Error;

                    if (headIdx == 0)
                    {
                        if (!TaskGantry.MoveRelGZ(ZUpDist, true)) goto _Error;
                    }
                    if (headIdx == 1)
                    {
                        if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                        {
                            if (!TaskGantry.MoveRelGZ2(ZUpDist, true)) goto _Error;
                        }
                        if (GDefine.GantryConfig == GDefine.EGantryConfig.XYZ && GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                        {
                            if (!TaskGantry.MoveRelGZ(ZUpDist, true)) goto _Error;
                        }
                    }

                }
                catch
                {
                    goto _Error;
                }
            }

            t = GDefine.GetTickCount() + TaskWeight.EndMeasDelay;
            while (GDefine.GetTickCount() < t) { Thread.Sleep(5); }

            if (!WeightValue(ref d_End_mg)) goto _Error;

            weight = d_End_mg - d_Start_mg;
            return true;

        _Error:
            return false;
        }

        public const int MAX_ATTEMPT = 20;
        const string dp_WEIGH = "f5";//mg
        const string dp_VOLUME = "f4";
        const string dp_SPEED_RPM = "f2";
        const string dp_FPRESS = "f4";
        const string dp_DENSITY = "f4";
        const string dp_FLOWRATE = "f6";

        #region Weight Cal
        public enum ECalMeasType { Density, FR_mg_s, FR_mg_dot };
        public static ECalMeasType CalMeasType = ECalMeasType.Density;//calibration measurement unit
        public static string[] CAL_MEAS_UNIT = new string[3] { "mg/ml", "mg/s", "mg/d" };
        public const string WEIGHT_UNIT = "mg";
        public static string CalMeasUnit
        {
            get
            {
                return CAL_MEAS_UNIT[(int)CalMeasType];
            }
        }
        public enum ECalAdjustType { Volume, Speed, Pressure }//adjustment type to calibrate
        public static ECalAdjustType CalAdjustType = ECalAdjustType.Volume;

        static readonly List<double> list_WC_PurgeWeight = new List<double>();
        static readonly List<double> list_WC_MeasWeight = new List<double>();

        static bool b_IsFilling = false;
        public static void WeightCal_Reset()
        {
            list_WC_PurgeWeight.Clear();
            list_WC_MeasWeight.Clear();
        }

        private static bool WeightCal_ExecuteSingle(ListBox ListBox, int HeadNo, ref double Weight)//HeadNo start 1
        {
            string s_Log = "";

            double d_DispVol = 0;
            double d_BSVol = 0;
            double d_Speed = 0;
            double d_FPress = 0;
            double d_mg = 0;

            switch (TaskWeight.CalMeasType)
            {
                case TaskWeight.ECalMeasType.Density:
                    #region
                    if (HeadNo == 1)
                    {
                        d_DispVol = DispProg.PP_HeadA_DispBaseVol;
                        d_BSVol = DispProg.PP_HeadA_BackSuckVol;
                    }
                    else
                    {
                        d_DispVol = DispProg.PP_HeadB_DispBaseVol;
                        d_BSVol = DispProg.PP_HeadB_BackSuckVol;
                    }
                    #endregion
                    break;
                case TaskWeight.ECalMeasType.FR_mg_s:
                    #region
                    if (HeadNo == 1)
                    {
                        d_Speed = DispProg.HM_HeadA_Disp_RPM;
                    }
                    else
                    {
                        d_Speed = DispProg.HM_HeadB_Disp_RPM;
                    }
                    #endregion
                    break;
                case TaskWeight.ECalMeasType.FR_mg_dot:
                    int i_HeadNo = HeadNo - 1;
                    #region
                    d_FPress = DispProg.FPress[i_HeadNo] * FACTOR_MPaToPSI;
                    #endregion
                    break;
            }


            if (!Weight_DownWeightUp(HeadNo, EMeasType.Cal, ref d_mg, ref b_IsFilling))
            {
                return false;
            }

            if (eOutputResult(EMeasType.Cal) == TaskWeight.EOutputResult.Average)
            {
                d_mg = d_mg / iDotsPerSample(EMeasType.Cal);
            }

            Weight = d_mg;

            if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.Density)
            {
                double d_Density = d_mg / (d_DispVol - d_BSVol);
                s_Log = "Volume/Weight/Density" + (char)9 + d_DispVol.ToString(dp_VOLUME) + "-" + d_BSVol.ToString(dp_VOLUME) + "/" + d_mg.ToString(dp_WEIGH) + "/" + d_Density.ToString(dp_DENSITY);
            }
            if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.FR_mg_s)
            {
                s_Log = "Speed/Weight/FlowRate" + (char)9 + d_Speed.ToString(dp_SPEED_RPM) + "/" + d_mg.ToString(dp_WEIGH) + "/" + (d_mg / (TaskWeight.DispTime / 1000)).ToString(dp_FLOWRATE);
            }
            if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.FR_mg_dot)
            {
                s_Log = "Fluid Press/Weight" + (char)9 + d_FPress.ToString(dp_FPRESS) + "/" + d_mg.ToString(dp_WEIGH);
            }
            ListBox.Items.Add(s_Log);
            Log.WeightCal.WriteByMonthDay(s_Log);
            ListBox.Items.Add("");
            ListBox.SelectedIndex = ListBox.Items.Count - 1;

            if (d_mg <= 0)
            {
                TaskDisp.TaskMoveGZUp();
                s_Log = "[Head" + HeadNo + " Error] Low Weight Error.";
                ListBox.Items.Add(s_Log);
                Log.WeightCal.WriteByMonthDay(s_Log);
                ListBox.Items.Add("");
                ListBox.SelectedIndex = ListBox.Items.Count - 1;
                return false;
            }

            return true;
        }
        public static bool WeightCal_Execute(double Target_Weight, ListBox ListBox, int HeadNo)//HeadNo start 1
                                                                                               //pressure unit for cal is Psi
        {
            string s_Log;
            double d_Vol;
            double d_Speed;
            double d_mg = 0;

            List<double> AdjPress = new List<double>();

            s_Log = "[Head" + HeadNo + " Target]";
            ListBox.Items.Add(s_Log);
            Log.WeightCal.WriteByMonthDay(s_Log);
            s_Log = Target_Weight.ToString(dp_WEIGH);
            ListBox.Items.Add(s_Log);
            Log.WeightCal.WriteByMonthDay(s_Log);
            ListBox.Items.Add("");

            if (CleanOnStart)
            {
                if (!TaskDisp.TaskCleanNeedle(false)) goto _SpeedError;
            }

            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.Vermes:
                case TaskDisp.EPumpType.Vermes1560:
                    TaskDisp.FPressOn(new bool[2] { HeadNo == 1, HeadNo == 2 });
                    break;
            }
        
            #region Set Pump Para
            switch (TaskWeight.CalMeasType)
            {
                case TaskWeight.ECalMeasType.Density:
                    #region
                    double HA_Vol = DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj + DispProg.rt_Head1VolumeOfst;
                    double HB_Vol = DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj + DispProg.rt_Head2VolumeOfst;
                    if (HeadNo == 1)
                    {
                        d_Vol = DispProg.PP_HeadA_DispBaseVol;
                        DispProg.PP_HeadA_DispVol_Adj = 0;
                        DispProg.rt_Head1VolumeOfst = 0;
                        TaskDisp.SetDispVolume(true, false, HA_Vol, HB_Vol);
                    }
                    else
                    {
                        d_Vol = DispProg.PP_HeadB_DispBaseVol;
                        DispProg.PP_HeadB_DispVol_Adj = 0;
                        DispProg.rt_Head2VolumeOfst = 0;
                        TaskDisp.SetDispVolume(false, true, HA_Vol, HB_Vol);
                    }
                    #endregion
                    break;
                case TaskWeight.ECalMeasType.FR_mg_s:
                    #region
                    if (HeadNo == 1)
                    {
                        //d_Speed = DispProg.HM_HeadA_Disp_RPM;
                        //TaskDisp.UpdateDispSpeed(LogPump.EVolAdjType.Auto, true, false);
                        TaskDisp.SetDispSpeed(true, false, DispProg.HM_HeadA_Disp_RPM, DispProg.HM_HeadB_Disp_RPM);
                    }
                    else
                    {
                        //d_Speed = DispProg.HM_HeadB_Disp_RPM;
                        //TaskDisp.UpdateDispSpeed(LogPump.EVolAdjType.Auto, false, true);
                        TaskDisp.SetDispSpeed(false, true, DispProg.HM_HeadA_Disp_RPM, DispProg.HM_HeadB_Disp_RPM);
                    }
                    #endregion
                    break;
                case TaskWeight.ECalMeasType.FR_mg_dot:
                    int i_HeadNo = HeadNo - 1;
                    #region
                    TaskDisp.Vermes3200[i_HeadNo].Param.NP = (uint)iDotsPerSample(EMeasType.Cal);
                    TaskDisp.Vermes3200[i_HeadNo].Set();
                    FPressCtrl.SetPress_MPa(DispProg.FPress);
                    #endregion
                    break;
            }
            #endregion

            if (!TaskWeight.TaskGotoWeight(HeadNo)) goto _SpeedError;

            while (list_WC_PurgeWeight.Count < PurgeCount)
            {
                frm_Message frm_Message = new frm_Message();
                try
                {
                    #region
                    frm_Message.Message = "Weight Cal - Purge in Progress. Pls wait...";
                    frm_Message.Show();

                    s_Log = "[Head" + HeadNo + " Purge " + (list_WC_PurgeWeight.Count + 1).ToString() + "]";
                    ListBox.Items.Add(s_Log);
                    Log.WeightCal.WriteByMonthDay(s_Log);

                    if (!WeightCal_ExecuteSingle(ListBox, HeadNo, ref d_mg)) goto _Abort;

                    list_WC_PurgeWeight.Add(d_mg);

                    if (frm_Message.Cancel)
                    {
                        goto _Cancel;
                    }

                    #endregion
                }
                catch { }
                finally
                {
                    frm_Message.Close();
                }
            }

            bool FPressOutRange = false;

            while (list_WC_MeasWeight.Count < TaskWeight.CalMaxAttempt)
            {
                frm_Message frm_Message = new frm_Message();
                try
                {
                    #region
                    if (list_WC_MeasWeight.Count == 0)
                    {
                        int i_HeadNo = HeadNo - 1;
                        //return false;
                        double CurrFPress = DispProg.FPress[i_HeadNo] * 145.038;
                        AdjPress.Add(0);
                    }
                    if (list_WC_MeasWeight.Count > 0)
                    {
                        switch (TaskWeight.CalMeasType)
                        {
                            case TaskWeight.ECalMeasType.Density:
                                #region
                                double HA_Vol = DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj + DispProg.rt_Head1VolumeOfst;
                                double HB_Vol = DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj + DispProg.rt_Head2VolumeOfst;
                                if (HeadNo == 1)
                                {
                                    d_Vol = (Target_Weight / list_WC_MeasWeight[list_WC_MeasWeight.Count - 1]) * DispProg.PP_HeadA_DispBaseVol;
                                    DispProg.PP_HeadA_DispBaseVol = d_Vol;
                                    //bool b = TaskDisp.SetDispVolume(true, false, HA_Vol, HB_Vol);
                                    bool b = TaskDisp.SetDispVolume(true, false, d_Vol, d_Vol);
                                }
                                else
                                {
                                    d_Vol = (Target_Weight / list_WC_MeasWeight[list_WC_MeasWeight.Count - 1]) * DispProg.PP_HeadB_DispBaseVol;
                                    DispProg.PP_HeadB_DispBaseVol = d_Vol;
                                    TaskDisp.SetDispVolume(false, true, d_Vol, d_Vol);
                                }
                                break;
                            #endregion
                            case TaskWeight.ECalMeasType.FR_mg_s:
                                #region
                                if (HeadNo == 1)
                                {
                                    d_Speed = Math.Min(DispProg.HM_HeadA_Disp_RPM * (Target_Weight * (TaskWeight.DispTime / 1000) / list_WC_MeasWeight[list_WC_MeasWeight.Count - 1]), 1000);
                                    if (d_Speed <= 0)
                                    {
                                        frm_Message.Close();
                                        goto _SpeedError;
                                    }
                                    DispProg.HM_HeadA_Disp_RPM = d_Speed;
                                    //TaskDisp.UpdateDispSpeed(LogPump.EVolAdjType.Auto, true, false);
                                    TaskDisp.SetDispSpeed(true, false, DispProg.HM_HeadA_Disp_RPM, DispProg.HM_HeadB_Disp_RPM);
                                }
                                else
                                {
                                    d_Speed = Math.Min(DispProg.HM_HeadB_Disp_RPM * (Target_Weight * (TaskWeight.DispTime / 1000) / list_WC_MeasWeight[list_WC_MeasWeight.Count - 1]), 1000);
                                    if (d_Speed <= 0)
                                    {
                                        frm_Message.Close();
                                        goto _SpeedError;
                                    }
                                    DispProg.HM_HeadB_Disp_RPM = d_Speed;
                                    //TaskDisp.UpdateDispSpeed(LogPump.EVolAdjType.Auto, false, true);
                                    TaskDisp.SetDispSpeed(false, true, DispProg.HM_HeadA_Disp_RPM, DispProg.HM_HeadB_Disp_RPM);
                                }
                                break;
                            #endregion
                            case TaskWeight.ECalMeasType.FR_mg_dot:
                                int i_HeadNo = HeadNo - 1;

                                if (list_WC_MeasWeight.Count == 1)
                                #region InitialAdjust
                                {
                                    double CurrFPress = DispProg.FPress[i_HeadNo] * FACTOR_MPaToPSI;
                                    double NewFPress = 0;
                                    if (Target_Weight > list_WC_MeasWeight[list_WC_MeasWeight.Count - 1])
                                        NewFPress = CurrFPress + TaskWeight.CalMaxPressAdjRate * FACTOR_MPaToPSI;
                                    else
                                        NewFPress = CurrFPress - TaskWeight.CalMaxPressAdjRate * FACTOR_MPaToPSI;

                                    FPressOutRange = ((DispProg.FPress_AdjMin * FACTOR_MPaToPSI > 0 && NewFPress < DispProg.FPress_AdjMin * FACTOR_MPaToPSI) || 
                                        (DispProg.FPress_AdjMax * FACTOR_MPaToPSI > 0 && NewFPress > DispProg.FPress_AdjMax * FACTOR_MPaToPSI));

                                    AdjPress.Add(TaskWeight.CalMaxPressAdjRate * FACTOR_MPaToPSI);
                                    DispProg.FPress[i_HeadNo] = NewFPress / FACTOR_MPaToPSI;
                                    FPressCtrl.SetPress_MPa(DispProg.FPress);
                                }
                                #endregion
                                else
                                #region
                                {
                                    double CurrFPress = DispProg.FPress[i_HeadNo] * FACTOR_MPaToPSI;

                                    double LastWeightChange = Math.Abs(list_WC_MeasWeight[list_WC_MeasWeight.Count - 1] - list_WC_MeasWeight[list_WC_MeasWeight.Count - 2]);
                                    double NewAdjustPress = 0;//5.2.97
                                    if(LastWeightChange != 0)
                                    {
                                        double PressureRatePerWeight = Math.Abs(AdjPress[list_WC_MeasWeight.Count - 1] / LastWeightChange);
                                        NewAdjustPress = Math.Abs(Target_Weight - list_WC_MeasWeight[list_WC_MeasWeight.Count - 1]) * PressureRatePerWeight;
                                        NewAdjustPress = Math.Min(TaskWeight.CalMaxPressAdjRate * FACTOR_MPaToPSI, NewAdjustPress);
                                    }

                                    if (Target_Weight < list_WC_MeasWeight[list_WC_MeasWeight.Count - 1])
                                        NewAdjustPress = -NewAdjustPress;

                                    double NewFPress = CurrFPress + NewAdjustPress;

                                    FPressOutRange = ((DispProg.FPress_AdjMin > 0 && NewFPress < DispProg.FPress_AdjMin) || (DispProg.FPress_AdjMax > 0 && NewFPress > DispProg.FPress_AdjMax));

                                    AdjPress.Add(NewAdjustPress);
                                    DispProg.FPress[i_HeadNo] = NewFPress / FACTOR_MPaToPSI;
                                    FPressCtrl.SetPress_MPa(DispProg.FPress);
                                }
                                #endregion
                                break;
                        }
                    }
                    frm_Message.Message = "Weight Cal - Weight in Progress. Pls wait...";
                    frm_Message.Show();

                    s_Log = "[Head" + HeadNo + " Meas " + (list_WC_MeasWeight.Count + 1).ToString() + "]";
                    ListBox.Items.Add(s_Log);
                    Log.WeightCal.WriteByMonthDay(s_Log);

                    if (!WeightCal_ExecuteSingle(ListBox, HeadNo, ref d_mg)) goto _Abort;

                    if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.Density)
                    {
                        list_WC_MeasWeight.Add(d_mg);
                    }
                    if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.FR_mg_s)
                    {
                        list_WC_MeasWeight.Add(d_mg);// / (TaskWeight.DispTime / 1000));
                    }
                    if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.FR_mg_dot)
                    {
                        list_WC_MeasWeight.Add(d_mg);
                    }


                    if (list_WC_MeasWeight.Count >= TaskWeight.CalAcceptCount)
                    {
                        #region
                        List<double> l_Accept = new List<double>();
                        for (int i = list_WC_MeasWeight.Count - TaskWeight.CalAcceptCount; i < list_WC_MeasWeight.Count; i++)
                        {
                            if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.FR_mg_s)
                            {
                                l_Accept.Add(list_WC_MeasWeight[i] / (TaskWeight.DispTime / 1000));
                            }
                            else
                                l_Accept.Add(list_WC_MeasWeight[i]);
                        }

                        bool Accept = true;
                        foreach (double d in l_Accept)
                        {
                            if ((d < Target_Weight - TaskWeight.CalTol) || (d > Target_Weight + TaskWeight.CalTol))
                            {
                                Accept = false;
                                break;
                            }
                        }

                        if (Accept)
                        {
                            double W = l_Accept.Average();

                            if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.Density)
                            {
                                if (HeadNo == 1)
                                {
                                    TaskWeight.CurrentCal[HeadNo - 1] = W / (DispProg.PP_HeadA_DispBaseVol - DispProg.PP_HeadA_BackSuckVol);
                                }
                                if (HeadNo == 2)
                                {
                                    TaskWeight.CurrentCal[HeadNo - 1] = W / (DispProg.PP_HeadB_DispBaseVol - DispProg.PP_HeadB_BackSuckVol);
                                }
                                Log.WeightCal.WriteByMonthDay("Density " + HeadNo.ToString() + (char)9 + TaskWeight.CurrentCal[HeadNo - 1].ToString(dp_FLOWRATE));
                            }
                            if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.FR_mg_s)
                            {
                                if (HeadNo == 1)
                                {
                                    TaskWeight.CurrentCal[HeadNo - 1] = W / (TaskWeight.DispTime / 1000);
                                }
                                if (HeadNo == 2)
                                {
                                    TaskWeight.CurrentCal[HeadNo - 1] = W / (TaskWeight.DispTime / 1000);
                                }
                                Log.WeightCal.WriteByMonthDay("FlowRate " + HeadNo.ToString() + (char)9 + TaskWeight.CurrentCal[HeadNo - 1].ToString(dp_FLOWRATE));
                            }
                            if (TaskWeight.CalMeasType == TaskWeight.ECalMeasType.FR_mg_dot)
                            {
                                if (HeadNo == 1)
                                {
                                    TaskWeight.CurrentCal[HeadNo - 1] = W;// / TaskWeight.DispTime;
                                }
                                if (HeadNo == 2)
                                {
                                    TaskWeight.CurrentCal[HeadNo - 1] = W;// / TaskWeight.DispTime;
                                }
                                Para.DotWeight.Set($"{W:f6}");
                                Log.WeightCal.WriteByMonthDay("Weight " + HeadNo.ToString() + (char)9 + TaskWeight.CurrentCal[HeadNo - 1].ToString(dp_FLOWRATE));
                            }
                            TaskWeight.SaveDefault();
                            TaskDisp.FPressOff();

                            TaskDisp.TaskMoveGZUp();
                            s_Log = "[Completed]";
                            ListBox.Items.Add(s_Log);
                            Log.WeightCal.WriteByMonthDay(s_Log);
                            ListBox.Items.Add("");
                            ListBox.SelectedIndex = ListBox.Items.Count - 1;

                            return true;
                        }
                        #endregion
                    }

                    if (list_WC_MeasWeight.Count >= TaskWeight.CalMaxAttempt)
                    {
                        TaskDisp.TaskMoveGZUp();
                        s_Log = "[Head" + HeadNo + " Error] Max Attempt Fail to Achieve Target.";
                        ListBox.Items.Add(s_Log);
                        Log.WeightCal.WriteByMonthDay(s_Log);
                        ListBox.Items.Add("");
                        ListBox.SelectedIndex = ListBox.Items.Count - 1;
                        return false;
                    }

                    if (frm_Message.Cancel)
                    {
                        frm_Message.Close();
                        goto _Cancel;
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    frm_Message.Close();
                }

                #region Check Press Limit
                if (FPressOutRange)
                {
                    TaskDisp.TaskMoveGZUp();
                    s_Log = "[Head" + HeadNo + " Error] FPress Out Of Range.";
                    ListBox.Items.Add(s_Log);
                    Log.WeightCal.WriteByMonthDay(s_Log);
                    ListBox.Items.Add("");
                    ListBox.SelectedIndex = ListBox.Items.Count - 1;
                    return false;
                }
                #endregion 
            }

            return true;

        _Abort:
            TaskDisp.FPressOff();

            TaskDisp.TaskMoveGZUp();

            return false;


        _Cancel:
            TaskDisp.FPressOff();

            TaskDisp.TaskMoveGZUp();

            s_Log = "[Head" + HeadNo + " Cancelled]";
            ListBox.Items.Add(s_Log);
            Log.WeightCal.WriteByMonthDay(s_Log);
            ListBox.Items.Add("");

            return false;

        _SpeedError:
            TaskDisp.FPressOff();

            TaskDisp.TaskMoveGZUp();

            s_Log = "[Head" + HeadNo + " Error]";
            ListBox.Items.Add(s_Log);
            Log.WeightCal.WriteByMonthDay(s_Log);
            ListBox.Items.Add("");

            return false;
        }
        #endregion

        #region Weight Measure
        internal static DateTime TimeStart = DateTime.Now;
        internal static DateTime TimeEnd = DateTime.Now;
        public static List<double> list_WM_PurgeWeight = new List<double>();
        public static List<double> list_WM_MeasWeight = new List<double>();

        #region Screen Capture
        public enum ECaptureMode
        {
            Screen, Window
        }
        public class ScreenCapture
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

            [StructLayout(LayoutKind.Sequential)]
            private struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetDesktopWindow();

            /// <summary> Capture Active Window, Desktop, Window or Control 
            /// by hWnd or .NET Contro/Form and save it to a specified file.  </summary>
            /// <param name="filename">Filename.
            /// <para>* If extension is omitted, it's calculated from the type of file</para>
            /// <para>* If path is omitted, defaults to %TEMP%</para>
            /// <para>* Use %NOW% to put a timestamp in the filename</para></param>
            /// <param name="mode">Optional. 
            /// The default value is CaptureMode.Window.</param>
            /// <param name="format">Optional file save mode.  
            /// Default is PNG</param>
            public void CaptureAndSave(string filename, ECaptureMode mode, ImageFormat format)
            {
                mode = ECaptureMode.Window;
                format = null;
                ImageSave(filename, format, Capture(mode));
            }

            /// <summary> Capture a specific window (or control) 
            /// and save it to a specified file.  </summary>
            /// <param name="filename">Filename.
            /// <para>* If extension is omitted, it's calculated from the type of file</para>
            /// <para>* If path is omitted, defaults to %TEMP%</para>
            /// <para>* Use %NOW% to put a timestamp in the filename</para></param>
            /// <param name="handle">hWnd (handle) of the window to capture</param>
            /// <param name="format">Optional file save mode.  Default is PNG</param>
            public void CaptureAndSave(string filename, IntPtr handle, ImageFormat format)
            {
                format = null;
                ImageSave(filename, format, Capture(handle));
            }

            /// <summary> Capture a specific window (or control) and 
            /// save it to a specified file.  </summary>
            /// <param name="filename">Filename.
            /// <para>* If extension is omitted, it's calculated from the type of file</para>
            /// <para>* If path is omitted, defaults to %TEMP%</para>
            /// <para>* Use %NOW% to put a timestamp in the filename</para></param>
            /// <param name="c">Object to capture</param>
            /// <param name="format">Optional file save mode.  Default is PNG</param>
            public void CaptureAndSave(string filename, Control c, ImageFormat format)
            {
                format = null;
                ImageSave(filename, format, Capture(c));
            }
            /// <summary> Capture the active window (default) or 
            /// the desktop and return it as a bitmap </summary>
            /// <param name="mode">Optional. 
            /// The default value is CaptureMode.Window.</param>
            public Bitmap Capture(ECaptureMode mode)
            {
                mode = ECaptureMode.Window;
                return Capture(mode == ECaptureMode.Screen ?
                            GetDesktopWindow() : GetForegroundWindow());
            }

            /// <summary> Capture a .NET Control, Form, UserControl, etc. </summary>
            /// <param name="c">Object to capture</param>
            /// <returns> Bitmap of control's area </returns>
            public Bitmap Capture(Control c)
            {
                return Capture(c.Handle);
            }

            /// <summary> Capture a specific window and return it as a bitmap </summary>
            /// <param name="handle">hWnd (handle) of the window to capture</param>
            public Bitmap Capture(IntPtr handle)
            {
                Rectangle bounds;
                Rect rect = new Rect();
                GetWindowRect(handle, ref rect);
                bounds = new Rectangle(rect.Left, rect.Top,
                        rect.Right - rect.Left, rect.Bottom - rect.Top);
                CursorPosition = new Point(Cursor.Position.X - rect.Left,
                            Cursor.Position.Y - rect.Top);

                Bitmap result = new Bitmap(bounds.Width, bounds.Height);
                using (Graphics g = Graphics.FromImage(result))
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

                return result;
            }

            /// <summary> Position of the cursor relative 
            /// to the start of the capture </summary>

            public Point CursorPosition;

            /// <summary> Save an image to a specific file </summary>
            /// <param name="filename">Filename.
            /// <para>* If extension is omitted, it's calculated from the type of file</para>
            /// <para>* If path is omitted, defaults to %TEMP%</para>
            /// <para>* Use %NOW% to put a timestamp in the filename</para></param>
            /// <param name="format">Optional file save mode.  Default is PNG</param>
            /// <param name="image">Image to save.  Usually a BitMap, but can be any
            /// Image.</param>
            void ImageSave(string filename, ImageFormat format, Image image)
            {
                format = format ?? ImageFormat.Png;
                if (!filename.Contains("."))
                    filename = filename.Trim() + "." + format.ToString().ToLower();

                if (!filename.Contains(@"\"))
                    filename = Path.Combine(Environment.GetEnvironmentVariable
                        ("TEMP") ?? @"C:\Temp", filename);

                filename = filename.Replace("%NOW%",
                            DateTime.Now.ToString("yyyy-MM-dd@hh.mm.ss"));
                image.Save(filename, format);
            }
        }
        public class ScreenCapture2
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetDesktopWindow();

            [StructLayout(LayoutKind.Sequential)]
            private struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

            public static Image CaptureDesktop()
            {
                return CaptureWindow(GetDesktopWindow());
            }

            public static Bitmap CaptureActiveWindow()
            {
                return CaptureWindow(GetForegroundWindow());
            }

            public static Bitmap CaptureWindow(IntPtr handle)
            {
                var rect = new Rect();
                GetWindowRect(handle, ref rect);
                var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                var result = new Bitmap(bounds.Width, bounds.Height);

                using (var graphics = Graphics.FromImage(result))
                {
                    graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }

                return result;
            }
        }
        #endregion
        public static bool WriteToFile(string FullFilename, int HeadNo, frm_DispCore_WeightMeasure frm)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            FileStream F = new FileStream(FullFilename, FileMode.Create, FileAccess.Write, FileShare.Write);
            StreamWriter W = new StreamWriter(F);

            try
            {
                List<string> Lines = new List<string>();

                Lines.Add("Head" + (char)9 + HeadNo.ToString());
                Lines.Add("Unit" + (char)9 + "mg");

                #region Parameters
                Lines.Add("Dots/Sample" + (char)9 + iDotsPerSample(EMeasType.Meas).ToString() + (DispProg.DotsPerSample_Meas > 0 ? " *P" : ""));
                Lines.Add("Output Result" + (char)9 + eOutputResult(EMeasType.Meas).ToString() + (DispProg.DotsPerSample_Meas > 0 ? " *P" : ""));
                Lines.Add("Purge Count" + (char)9 + PurgeCount.ToString());
                Lines.Add("Pre Wait Time (ms)" + (char)9 + PreWaitTime.ToString());
                Lines.Add("Disp Wait Time (ms)" + (char)9 + DispTime.ToString());
                Lines.Add("Post Wait Time (ms)" + (char)9 + PostWaitTime.ToString());
                Lines.Add("Z Up Dist (ms)" + (char)9 + ZUpDist.ToString());
                Lines.Add("Z Up Speed (ms)" + (char)9 + ZUpSpeed.ToString());

                Lines.Add("Start Meas Delay (ms)" + (char)9 + StartMeasDelay.ToString());
                Lines.Add("End Meas Delay (ms)" + (char)9 + EndMeasDelay.ToString());
                #endregion

                Lines.Add("FPress1" + (char)9 + DispProg.FPress[0].ToString(dp_FPRESS));
                Lines.Add("FPress2" + (char)9 + DispProg.FPress[1].ToString(dp_FPRESS));

                Lines.Add("Calibration1" + (char)9 + TaskWeight.CurrentCal[0].ToString(dp_FLOWRATE));
                Lines.Add("Calibration2" + (char)9 + TaskWeight.CurrentCal[1].ToString(dp_FLOWRATE));

                Lines.Add("DTStart" + (char)9 + TimeStart.ToString("yyyy-MM-dd HH:mm:ss"));
                Lines.Add("DTEnd" + (char)9 + TimeEnd.ToString("yyyy-MM-dd HH:mm:ss"));

                for (int i = 0; i < list_WM_MeasWeight.Count; i++)
                {
                    Lines.Add((i + 1).ToString() + (char)9 + list_WM_MeasWeight[i].ToString(dp_WEIGH));
                }

                double Min = 0;
                double Max = 0;
                double Ave = 0;
                try
                {
                    Min = list_WM_MeasWeight.Min();
                    Max = list_WM_MeasWeight.Max();
                    Ave = list_WM_MeasWeight.Average();
                }
                catch { };

                NSW.Net.Stats Stat = new NSW.Net.Stats();
                double StDev = Stat.StDev(list_WM_MeasWeight);
                double Cpl = (Ave - (TaskWeight.MeasureSpec - TaskWeight.MeasureSpecTol)) / (3 * StDev);
                double Cpu = ((TaskWeight.MeasureSpec + TaskWeight.MeasureSpecTol) - Ave) / (3 * StDev);
                double Cpk = Math.Min(Cpl, Cpu);
                double Cp = (TaskWeight.MeasureSpecTol * 2) / (6 * StDev);

                Lines.Add("Spec" + (char)9 + TaskWeight.MeasureSpec.ToString(dp_WEIGH));
                Lines.Add("LSpec" + (char)9 + (TaskWeight.MeasureSpec - TaskWeight.MeasureSpecTol).ToString(dp_WEIGH));
                Lines.Add("USpec" + (char)9 + (TaskWeight.MeasureSpec + TaskWeight.MeasureSpecTol).ToString(dp_WEIGH));
                Lines.Add("Min" + (char)9 + Min.ToString(dp_WEIGH));
                Lines.Add("Max" + (char)9 + Max.ToString(dp_WEIGH));
                Lines.Add("Range" + (char)9 + (Max - Min).ToString(dp_WEIGH));
                Lines.Add("Ave" + (char)9 + Ave.ToString(dp_WEIGH));
                Lines.Add("StDev" + (char)9 + StDev.ToString(dp_WEIGH));
                Lines.Add("Cpl" + (char)9 + Cpl.ToString(dp_WEIGH));
                Lines.Add("Cpu" + (char)9 + Cpu.ToString(dp_WEIGH));
                Lines.Add("Cpk" + (char)9 + Cpk.ToString(dp_WEIGH));
                Lines.Add("Cp" + (char)9 + Cp.ToString(dp_WEIGH));

                foreach (string line in Lines)
                    W.WriteLine(line);
            }
            finally
            {
                W.Close();
            }


            ScreenCapture SC = new ScreenCapture();
            string File = Path.GetDirectoryName(FullFilename) + "\\" + Path.GetFileNameWithoutExtension(FullFilename) + ".png";
            frm.TopMost = true;
            frm.Focus();
            frm.BringToFront();
            frm.TopMost = false;
            frm.Refresh();
            SC.CaptureAndSave(File, frm, ImageFormat.Png);

            return true;
        }
        public static void WeightMeas_Reset()
        {
            list_WM_PurgeWeight.Clear();
            list_WM_MeasWeight.Clear();
        }
        static bool b_Ignore = false;
        static int i_IgnoreCount = 0;
        public static bool WeightMeas_Execute(ListBox ListBox, frm_DispCore_WeightMeasure frm, ZedGraph.PointPairList list_Data, int HeadNo)
        {
            i_IgnoreCount = 0;

            double d_mg = 0;

            if (TaskWeight.CleanOnStart)
            {
                if (!TaskDisp.TaskCleanNeedle(false)) goto _Error;
            }

            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.Vermes:
                case TaskDisp.EPumpType.Vermes1560:
                    TaskDisp.FPressOn(new bool[2] { HeadNo == 1, HeadNo == 2 });
                    break;
            }

            if (DispProg.Pump_Type == TaskDisp.EPumpType.Vermes)
            {
                int i_HeadIdx = HeadNo - 1;
                TaskDisp.Vermes3200[i_HeadIdx].Param.NP = (uint)iDotsPerSample(EMeasType.Meas);
                TaskDisp.Vermes3200[i_HeadIdx].Set();
            }
            if (DispProg.Pump_Type == TaskDisp.EPumpType.Vermes1560)
            {
                int i_HeadIdx = HeadNo - 1;
                TaskDisp.Vermes1560[i_HeadIdx].NP[0] = (int)iDotsPerSample(EMeasType.Meas);
                TaskDisp.Vermes1560[i_HeadIdx].UpdateSetup();
            }

            if (!TaskWeight.TaskGotoWeight(HeadNo)) goto _Error;

            while (list_WM_PurgeWeight.Count < TaskWeight.PurgeCount)
            {
                frm_Message frm_Message = new frm_Message();
                try
                {
                    #region
                    frm_Message.Message = "Weight Measure in Progress. Pls wait...";
                    frm_Message.Show();

                    if (!TaskWeight.Weight_DownWeightUp(HeadNo, EMeasType.Meas, ref d_mg, ref b_IsFilling))
                    {
                        goto _Error;
                    }

                    if (eOutputResult(EMeasType.Meas) == TaskWeight.EOutputResult.Average)
                    {
                        d_mg = d_mg / iDotsPerSample(EMeasType.Meas);
                    }
                    ListBox.Items.Add("[Purge]" + (char)9 + d_mg.ToString(dp_WEIGH));
                    list_WM_PurgeWeight.Add(d_mg);

                    if (frm_Message.Cancel)
                    {
                        goto _Cancel;
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    frm_Message.Close();
                }
            }

            while (list_WM_MeasWeight.Count < TaskWeight.MeasureCount)
            {
                frm_Message frm_Message = new frm_Message();
                try
                {
                    #region
                    frm_Message.Message = "Weight Measure in Progress. Pls wait...";
                    frm_Message.Show();

                    if (!TaskWeight.Weight_DownWeightUp(HeadNo, EMeasType.Meas, ref d_mg, ref b_IsFilling))
                    {
                        frm_Message.Close();
                        goto _Error;
                    }

                    if (b_IsFilling)
                    {
                        b_Ignore = true;
                    }

                    if (i_IgnoreCount >= TaskWeight.IgnoreAfterFillCount)
                    {
                        i_IgnoreCount = 0;
                        b_Ignore = false;
                    }

                    if (!b_Ignore)
                    {
                        if (eOutputResult(EMeasType.Meas) == TaskWeight.EOutputResult.Average)
                        {
                            d_mg = d_mg / iDotsPerSample(EMeasType.Meas);
                        }
                        list_WM_MeasWeight.Add(d_mg);
                        if (DispProg.Meas_Spec == 0) TaskWeight.MeasureSpec = list_WM_MeasWeight.Average();
                        frm.GraphAddData(d_mg);
                        frm.UpdateStats();
                        ListBox.Items.Add("[" + (list_WM_MeasWeight.Count).ToString() + "]" + (char)9 + d_mg.ToString(dp_WEIGH));
                        ListBox.SelectedIndex = ListBox.Items.Count - 1;
                    }
                    else
                    {
                        if (i_IgnoreCount == 0)
                        {
                            if (!TaskDisp.TaskCleanNeedle(false)) goto _Error;
                            if (!TaskWeight.TaskGotoWeight((int)HeadNo)) goto _Error;
                        }

                        i_IgnoreCount++;
                        if (eOutputResult(EMeasType.Meas) == TaskWeight.EOutputResult.Average)
                            d_mg = d_mg / iDotsPerSample(EMeasType.Meas);
                        ListBox.Items.Add("[x]" + (char)9 + d_mg.ToString(dp_WEIGH));
                        ListBox.SelectedIndex = ListBox.Items.Count - 1;
                    }

                    if (frm_Message.Cancel)
                    {
                        goto _Cancel;
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    frm_Message.Close();
                }
            }

            TaskDisp.TaskMoveGZUp();

            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();
            return true;

        _Error:
            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();
            ListBox.Items.Add("Error");
            return false;

        _Cancel:
            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();
            ListBox.Items.Add("Head" + HeadNo + " Cancelled.");
            return false;
        }
        #endregion
    }

    internal class TaskFlowRate
    {
        public static double[] Value = new double[2] { 0, 0 };

        public static void LoadDefault()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(GDefine.WeightPath + "\\" + "FlowRate" + ".def");

            for (int i = 0; i < TaskDisp.MAX_HEADCOUNT; i++)
            {
                Value[i] = IniFile.ReadDouble("Cal", "FlowRate" + i.ToString(), 0);
            }
        }
        public static void SaveDefault()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(GDefine.WeightPath + "\\" + "FlowRate" + ".def");

            for (int i = 0; i < TaskDisp.MAX_HEADCOUNT; i++)
            {
                IniFile.WriteDouble("Cal", "FlowRate" + i.ToString(), Value[i]);
            }
        }

        const string dp_WEIGHT = "f3";
        const int maxAttempt = 10;

        public static void AddLog(string sLog)
        {
            logList.Add(sLog);
            Log.WeightCal.WriteByMonthDay(sLog);
        }

        public static bool bCancel = false;
        public static List<string> logList = new List<string>();
        static List<double> list_Weight = new List<double>();
        static List<double> list_Press = new List<double>();
        static List<double> list_Cal = new List<double>();
        public static bool ExecuteCal(int headNo)//headNo start 0, press MPa
        {
            bCancel = false;

            string s_Log;

            if (headNo == 0) Event.OP_FLOWRATE1_CALIBRATION.Set();
            if (headNo == 1) Event.OP_FLOWRATE2_CALIBRATION.Set();

            AddLog("[Head" + (headNo + 1) + "]");

            s_Log = "Target " + DispProg.FlowRate.TargetFlowrate * DispProg.FlowRate.Duration + " mg @ " + DispProg.FlowRate.TargetFlowrate.ToString("f3") + " mg/s +/-" + DispProg.FlowRate.TargetFlowRateTol.ToString("f3");
            AddLog(s_Log);
            s_Log = "Pressure " + DispProg.FPress[headNo].ToString("f3") + "MPa";
            AddLog(s_Log);
            if (DispProg.FlowRate.MaterialSlope != 0)
            {
                s_Log = "Approx Fit y = " + DispProg.FlowRate.MaterialSlope.ToString("f5") + "x + " + DispProg.FlowRate.MaterialIntercept.ToString("f5");
                AddLog(s_Log);
            }

            if (TaskWeight.CleanOnStart)
            {
                if (!TaskDisp.TaskCleanNeedle(false)) goto _Error;
            }

            if (bCancel) goto _Cancel;

            if (!TaskWeight.TaskGotoWeight(headNo)) goto _Error;

            if (DispProg.FPress[headNo] < DispProg.FlowRate.MinPressure || DispProg.FPress[headNo] > DispProg.FlowRate.MaxPressure)
            {
                s_Log = "Set Pressure Exceeds Allowable Pressure Range.";
                AddLog(s_Log);
                goto _Abort;
            }

            FPressCtrl.SetPress_MPa(DispProg.FPress);

            List<double> list_Purge = new List<double>();
            while (list_Purge.Count < TaskWeight.PurgeCount)
            {
                try
                {
                    #region
                    s_Log = "Purge " + (list_Purge.Count + 1).ToString();
                    AddLog(s_Log);

                    double weight = 0;
                    if (!TaskWeight.Weight_DownWeightUp(headNo, DispProg.FlowRate.Duration, ref weight)) goto _Abort;
                    list_Purge.Add(weight);

                    s_Log = "Weight " + weight.ToString(dp_WEIGHT) + " mg";
                    AddLog(s_Log);

                    if (bCancel) goto _Cancel;
                    #endregion
                }
                catch { }
                finally
                {
                }
            }

            double startPress = DispProg.FPress[headNo];
            list_Weight.Clear();
            list_Press.Clear();
            list_Cal.Clear();
            if (DispProg.FlowRate.EnableTargetFlowRate)
            {
                while (list_Cal.Count < maxAttempt)
                {
                    try
                    {
                        #region
                        s_Log = "Cal " + (list_Cal.Count + 1).ToString();
                        AddLog(s_Log);

                        double weight = 0;
                        if (!TaskWeight.Weight_DownWeightUp(headNo, DispProg.FlowRate.Duration, ref weight)) goto _Abort;
                        double fr = weight / DispProg.FlowRate.Duration;

                        s_Log = "Weight " + weight.ToString(dp_WEIGHT) + " mg, FlowRate " + fr.ToString("f3") + " mg/s";
                        AddLog(s_Log);

                        if (weight <= 0)
                        {
                            s_Log = "Invald Weight Value.";
                            AddLog(s_Log);
                            goto _Abort;
                        }

                        double targetWeight = DispProg.FlowRate.TargetFlowrate * DispProg.FlowRate.Duration;
                        double newPressure = startPress * (targetWeight / weight);

                        double matSlope = DispProg.FlowRate.MaterialSlope;
                        if (DispProg.FlowRate.MaterialSlope == 0)
                        {
                            //matSlope = weight / targetWeight;
                        }
                        else
                            newPressure = startPress + (targetWeight - weight) * matSlope;

                        s_Log = "Pressure " + startPress.ToString("f3") + "MPa > " + newPressure.ToString("f3") + " MPa";
                        AddLog(s_Log);

                        list_Weight.Add(weight);
                        list_Press.Add(startPress);
                        list_Cal.Add(fr);
                        startPress = newPressure;

                        if (bCancel) goto _Cancel;

                        if (newPressure < DispProg.FlowRate.MinPressure || newPressure > DispProg.FlowRate.MaxPressure)
                        {
                            s_Log = "Set Pressure Exceeds Allowable Pressure Range.";
                            AddLog(s_Log);
                            goto _Abort;
                        }

                        double[] press = new double[2] { newPressure, newPressure * DispProg.FPress[1] / DispProg.FPress[0] };
                        FPressCtrl.SetPress_MPa(press);

                        List<double> listAccept = new List<double>();
                        List<double> listAcceptPress = new List<double>();
                        bool bComplete = false;
                        if (list_Cal.Count >= DispProg.FlowRate.NoToAve)
                        {
                            bComplete = true;
                            for (int i = list_Cal.Count - 1; i >= list_Cal.Count - DispProg.FlowRate.NoToAve; i--)
                            {
                                if ((list_Cal[i] < DispProg.FlowRate.TargetFlowrate - DispProg.FlowRate.TargetFlowRateTol)) bComplete = false;
                                if ((list_Cal[i] > DispProg.FlowRate.TargetFlowrate + DispProg.FlowRate.TargetFlowRateTol)) bComplete = false;
                                listAccept.Add(list_Cal[i]);
                                listAcceptPress.Add(list_Press[i]);
                            }
                        }

                        if (bComplete)
                        {
                            Value[headNo] = listAccept.Average();

                            double avePress1 = listAcceptPress.Average();
                            double avePress2 = avePress1 * DispProg.FPress[1] / DispProg.FPress[0];
                            DispProg.FPress = new double[2] { avePress1, avePress2 };
                            FPressCtrl.SetPress_MPa(DispProg.FPress);

                            Stats.AutoFlowRateFrameCounter = 0;
                            Stats.AutoFlowRateUnitCounter = 0;

                            s_Log = "Flowrate " + Value[headNo].ToString("f3") + " mg/s, Pressure " + DispProg.FPress[headNo].ToString("f3") + " MPa";
                            AddLog(s_Log);

                            TaskDisp.TaskMoveGZUp();
                            s_Log = "Cal Completed.";
                            AddLog(s_Log);

                            TaskDisp.FPressOff();
                            TaskWeight.SaveDefault();

                            return true;
                        }

                        if (list_Cal.Count >= maxAttempt)
                        {
                            TaskDisp.TaskMoveGZUp();
                            s_Log = "Cal Failed. Exceed Max Attempt.";
                            AddLog(s_Log);
                            return false;
                        }

                        #endregion
                    }
                    catch { }
                    finally
                    {
                    }
                }
            }
            else//Disable TargetFlowrate
            {
                while (list_Cal.Count < DispProg.FlowRate.NoToAve)
                {
                    try
                    {
                        #region
                        s_Log = "Cal " + (list_Cal.Count + 1).ToString();
                        AddLog(s_Log);

                        double weight = 0;
                        if (!TaskWeight.Weight_DownWeightUp(headNo, DispProg.FlowRate.Duration, ref weight)) goto _Abort;
                        double fr = weight / DispProg.FlowRate.Duration;

                        s_Log = "Weight " + weight.ToString(dp_WEIGHT) + " mg, FlowRate " + fr.ToString("f3") + " mg/s";
                        AddLog(s_Log);

                        if (weight <= 0)
                        {
                            s_Log = "Invald Weight Value.";
                            AddLog(s_Log);
                            goto _Abort;
                        }

                        list_Weight.Add(weight);
                        list_Press.Add(startPress);
                        list_Cal.Add(fr);

                        if (bCancel) goto _Cancel;

                        if (list_Cal.Count >= DispProg.FlowRate.NoToAve)
                        { 
                            Value[headNo] = list_Cal.Average();

                            Stats.AutoFlowRateFrameCounter = 0;
                            Stats.AutoFlowRateUnitCounter = 0;

                            s_Log = "Flowrate " + Value[headNo].ToString("f3") + " mg/s, Pressure " + DispProg.FPress[headNo].ToString("f3") + " MPa";
                            AddLog(s_Log);

                            TaskDisp.TaskMoveGZUp();
                            s_Log = "Cal Completed.";
                            AddLog(s_Log);

                            TaskDisp.FPressOff();
                            TaskWeight.SaveDefault();

                            return true;
                        }

                        if (list_Cal.Count >= maxAttempt)
                        {
                            TaskDisp.TaskMoveGZUp();
                            s_Log = "Cal Failed. Exceed Max Attempt.";
                            AddLog(s_Log);
                            return false;
                        }

                        #endregion
                    }
                    catch { }
                    finally
                    {
                    }
                }
            }

            return true;

            _Abort:
            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();
            return false;

            _Cancel:
            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();

            s_Log = "Cal Cancelled.";
            AddLog(s_Log);
            return false;

            _Error:
            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();

            s_Log = "Cal Error.";
            AddLog(s_Log);
            return false;
        }

        private static bool ApproximateFit(double[] x, double[] y, ref double m, ref double c)
        {
            if (x.Length < 2 || y.Length < 2) return false; 

            int n = x.Length;
            double sum_x = 0, sum_y = 0, sum_xy = 0, sum_x2 = 0;

            for (int i = 0; i < n; i++)
            {
                sum_x += x[i];
                sum_y += y[i];
                sum_xy += x[i] * y[i];
                sum_x2 += Math.Pow(x[i], 2);
            }

            m = (n * sum_xy - sum_x * sum_y) / (n * sum_x2 - Math.Pow(sum_x, 2));

            c = (sum_y - m * sum_x) / n;

            return true;
        }
        public static bool ExecuteApproximateFit()
        {
            double m = 0, c = 0;
            if (!ApproximateFit(list_Weight.ToArray(), list_Press.ToArray(), ref m, ref c)) return false;

            DispProg.FlowRate.MaterialSlope = m;
            DispProg.FlowRate.MaterialIntercept = c;

            string s_Log = "Auto Approx Fit y = " + m.ToString("f5") + "x + " + c.ToString("f5");
            AddLog(s_Log);

            return true;
        }
    }

    internal class TaskWeightMeas
    {
        const string dp_WEIGHT = "f3";

        public static List<string> logList = new List<string>();
        public static List<double> list_Weight = new List<double>();
        public static void AddLog(string sLog)
        {
            logList.Add(sLog);
            Log.WeightMeas.WriteByMonthDay(sLog);
        }

        public static bool bCancel = false;
        public static bool ExecuteMeas(int headNo)//headNo start 0, press MPa
        {
            bCancel = false;

            string s_Log;

            if (headNo == 0) Event.OP_WEIGHT1_MEASURE.Set();
            if (headNo == 1) Event.OP_WEIGHT2_MEASURE.Set();

            AddLog("[Head" + (headNo + 1) + "]");

            FPressCtrl.SetPress_MPa(DispProg.FPress);

            if (DispProg.FlowRate.MaterialSlope != 0)
            {
                s_Log = "Approx Fit y = " + DispProg.FlowRate.MaterialSlope.ToString("f5") + "x + " + DispProg.FlowRate.MaterialIntercept.ToString("f5");
                AddLog(s_Log);
            }

            double totalDispTime_s = DispProg.WeightMeas.Duration;
            if (DispProg.WeightMeas.EnableTargetWeight)
            {
                s_Log = "Flowrate " + TaskFlowRate.Value[headNo].ToString("f3") + " mg/s";
                AddLog(s_Log);
                totalDispTime_s = DispProg.WeightMeas.TargetWeight / TaskFlowRate.Value[headNo];//s * 1000;//ms
                totalDispTime_s = totalDispTime_s * (1 + (DispProg.FlowRate.TimeCompensate / 100));
                s_Log = "Target Weight " + DispProg.WeightMeas.TargetWeight.ToString("f3") + " mg";
                AddLog(s_Log);
            }
            s_Log = "Press " + DispProg.FPress[headNo].ToString("f3") + " MPa @ " + "Disp Time " + totalDispTime_s.ToString("f3") + " s"; 
            AddLog(s_Log);

            //if (DispProg.Pump_Type == TaskDisp.EPumpType.SP)
            //{
            //    //PPress On Lagging
            //    if (DispProg.SP.PulseOnDelay[0] > 0) totalDelayTime += DispProg.SP.PulseOnDelay[0];
            //}
            //if (DispProg.Pump_Type == TaskDisp.EPumpType.SP)
            //{
            //    //PPress Off Leading
            //    if (DispProg.SP.PulseOffDelay[0] < 0) totalDelayTime += DispProg.SP.PulseOffDelay[0];
            //}

            //if (totalDelayTime > totalDispTime) throw new Exception("Delay Time too long to achieve weight value. Decrease StartDelay and EndDelay time.");

            if (TaskWeight.CleanOnStart)
            {
                if (!TaskDisp.TaskCleanNeedle(false)) goto _Error;
            }

            if (bCancel) goto _Cancel;

            if (!TaskWeight.TaskGotoWeight(headNo)) goto _Error;

            List<double> list_Purge = new List<double>();
            while (list_Purge.Count < TaskWeight.PurgeCount)
            {
                try
                {
                    #region
                    double weight = 0;
                    if (!TaskWeight.Weight_DownWeightUp(headNo, totalDispTime_s, ref weight)) goto _Abort;
                    list_Purge.Add(weight);

                    s_Log = "Purge" + (list_Purge.Count).ToString()  +  " " + weight.ToString(dp_WEIGHT) + " mg";
                    AddLog(s_Log);

                    if (bCancel) goto _Cancel;
                    #endregion
                }
                catch { }
                finally
                {
                }
            }

            list_Weight.Clear();
            while (list_Weight.Count < DispProg.WeightMeas.SampleCount)
            {
                try
                {
                    #region
                    double weight = 0;
                    if (!TaskWeight.Weight_DownWeightUp(headNo, totalDispTime_s, ref weight)) goto _Abort;

                    list_Weight.Add(weight);
                    s_Log = "[" + (list_Weight.Count).ToString() + "] " + weight.ToString(dp_WEIGHT);
                    AddLog(s_Log);

                    //if (weight <= 0)
                    //{
                    //    s_Log = "Invald Weight Value.";
                    //    AddLog(s_Log);
                    //    goto _Abort;
                    //}

                    if (bCancel) goto _Cancel;
                    #endregion
                }
                catch { }
                finally
                {
                }
            }

            return true;

        _Abort:
            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();
            return false;

        _Cancel:
            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();

            s_Log = "Meas Cancelled.";
            AddLog(s_Log);
            return false;

        _Error:
            TaskDisp.FPressOff();
            TaskDisp.TaskMoveGZUp();

            s_Log = "Meas Error.";
            AddLog(s_Log);
            return false;
        }

        #region Screen Capture
        public enum ECaptureMode
        {
            Screen, Window
        }
        public class ScreenCapture
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

            [StructLayout(LayoutKind.Sequential)]
            private struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetDesktopWindow();

            /// <summary> Capture Active Window, Desktop, Window or Control 
            /// by hWnd or .NET Contro/Form and save it to a specified file.  </summary>
            /// <param name="filename">Filename.
            /// <para>* If extension is omitted, it's calculated from the type of file</para>
            /// <para>* If path is omitted, defaults to %TEMP%</para>
            /// <para>* Use %NOW% to put a timestamp in the filename</para></param>
            /// <param name="mode">Optional. 
            /// The default value is CaptureMode.Window.</param>
            /// <param name="format">Optional file save mode.  
            /// Default is PNG</param>
            public void CaptureAndSave(string filename, ECaptureMode mode, ImageFormat format)
            {
                mode = ECaptureMode.Window;
                format = null;
                ImageSave(filename, format, Capture(mode));
            }

            /// <summary> Capture a specific window (or control) 
            /// and save it to a specified file.  </summary>
            /// <param name="filename">Filename.
            /// <para>* If extension is omitted, it's calculated from the type of file</para>
            /// <para>* If path is omitted, defaults to %TEMP%</para>
            /// <para>* Use %NOW% to put a timestamp in the filename</para></param>
            /// <param name="handle">hWnd (handle) of the window to capture</param>
            /// <param name="format">Optional file save mode.  Default is PNG</param>
            public void CaptureAndSave(string filename, IntPtr handle, ImageFormat format)
            {
                format = null;
                ImageSave(filename, format, Capture(handle));
            }

            /// <summary> Capture a specific window (or control) and 
            /// save it to a specified file.  </summary>
            /// <param name="filename">Filename.
            /// <para>* If extension is omitted, it's calculated from the type of file</para>
            /// <para>* If path is omitted, defaults to %TEMP%</para>
            /// <para>* Use %NOW% to put a timestamp in the filename</para></param>
            /// <param name="c">Object to capture</param>
            /// <param name="format">Optional file save mode.  Default is PNG</param>
            public void CaptureAndSave(string filename, Control c, ImageFormat format)
            {
                format = null;
                ImageSave(filename, format, Capture(c));
            }
            /// <summary> Capture the active window (default) or 
            /// the desktop and return it as a bitmap </summary>
            /// <param name="mode">Optional. 
            /// The default value is CaptureMode.Window.</param>
            public Bitmap Capture(ECaptureMode mode)
            {
                mode = ECaptureMode.Window;
                return Capture(mode == ECaptureMode.Screen ?
                            GetDesktopWindow() : GetForegroundWindow());
            }

            /// <summary> Capture a .NET Control, Form, UserControl, etc. </summary>
            /// <param name="c">Object to capture</param>
            /// <returns> Bitmap of control's area </returns>
            public Bitmap Capture(Control c)
            {
                return Capture(c.Handle);
            }

            /// <summary> Capture a specific window and return it as a bitmap </summary>
            /// <param name="handle">hWnd (handle) of the window to capture</param>
            public Bitmap Capture(IntPtr handle)
            {
                Rectangle bounds;
                Rect rect = new Rect();
                GetWindowRect(handle, ref rect);
                bounds = new Rectangle(rect.Left, rect.Top,
                        rect.Right - rect.Left, rect.Bottom - rect.Top);
                CursorPosition = new Point(Cursor.Position.X - rect.Left,
                            Cursor.Position.Y - rect.Top);

                Bitmap result = new Bitmap(bounds.Width, bounds.Height);
                using (Graphics g = Graphics.FromImage(result))
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

                return result;
            }

            /// <summary> Position of the cursor relative 
            /// to the start of the capture </summary>

            public Point CursorPosition;

            /// <summary> Save an image to a specific file </summary>
            /// <param name="filename">Filename.
            /// <para>* If extension is omitted, it's calculated from the type of file</para>
            /// <para>* If path is omitted, defaults to %TEMP%</para>
            /// <para>* Use %NOW% to put a timestamp in the filename</para></param>
            /// <param name="format">Optional file save mode.  Default is PNG</param>
            /// <param name="image">Image to save.  Usually a BitMap, but can be any
            /// Image.</param>
            void ImageSave(string filename, ImageFormat format, Image image)
            {
                format = format ?? ImageFormat.Png;
                if (!filename.Contains("."))
                    filename = filename.Trim() + "." + format.ToString().ToLower();

                if (!filename.Contains(@"\"))
                    filename = Path.Combine(Environment.GetEnvironmentVariable
                        ("TEMP") ?? @"C:\Temp", filename);

                filename = filename.Replace("%NOW%",
                            DateTime.Now.ToString("yyyy-MM-dd@hh.mm.ss"));
                image.Save(filename, format);
            }
        }
        public class ScreenCapture2
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetDesktopWindow();

            [StructLayout(LayoutKind.Sequential)]
            private struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

            public static Image CaptureDesktop()
            {
                return CaptureWindow(GetDesktopWindow());
            }

            public static Bitmap CaptureActiveWindow()
            {
                return CaptureWindow(GetForegroundWindow());
            }

            public static Bitmap CaptureWindow(IntPtr handle)
            {
                var rect = new Rect();
                GetWindowRect(handle, ref rect);
                var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                var result = new Bitmap(bounds.Width, bounds.Height);

                using (var graphics = Graphics.FromImage(result))
                {
                    graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }

                return result;
            }
        }
        #endregion
        public static bool WriteToFile(string FullFilename, int HeadNo, frmWeightMeasure frm)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            FileStream F = new FileStream(FullFilename, FileMode.Create, FileAccess.Write, FileShare.Write);
            StreamWriter W = new StreamWriter(F);

            try
            {
                List<string> Lines = new List<string>();

                foreach (string s in logList)
                {
                    Lines.Add(s);
                }

                foreach (string line in Lines)
                    W.WriteLine(line);
            }
            finally
            {
                W.Close();
            }


            ScreenCapture SC = new ScreenCapture();
            string File = Path.GetDirectoryName(FullFilename) + "\\" + Path.GetFileNameWithoutExtension(FullFilename) + ".png";
            frm.TopMost = true;
            frm.Focus();
            frm.BringToFront();
            frm.TopMost = false;
            frm.Refresh();
            SC.CaptureAndSave(File, frm, ImageFormat.Png);

            return true;
        }
    }
}
