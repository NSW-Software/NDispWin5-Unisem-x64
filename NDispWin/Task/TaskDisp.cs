using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Reflection;

using Euresys.Open_eVision_2_5;
using Emgu.CV;

namespace NDispWin
{
    internal class FuncPurgeStage
    {
        public int ModelNo = 0;

        public enum EPattern { Dot, Line };
        public EPattern Pattern = EPattern.Dot;
        public PointD PatternSize = new PointD(0, 0);

        public TPos3 StartXY = new TPos3();
        public TPos3 EndXY
        {
            get
            {
                TPos3 Pos3 = new TPos3(StartXY);
                Pos3.X = Pos3.X + (PitchXY.X * (CRCount.X - 1));
                Pos3.Y = Pos3.Y + (PitchXY.Y * (CRCount.Y - 1));
                return Pos3;
            }
            set
            {
                PitchXY.X = Math.Round((value.X - StartXY.X) / (CRCount.X - 1), 3);
                PitchXY.Y = Math.Round((value.Y - StartXY.Y) / (CRCount.Y - 1), 3);
            }
        }
        public TPos3 PitchXY = new TPos3(1, -1, 0);
        public Point CRCount = new Point(5, 5);
        public Point LastCR = new Point(1, 1);
        public Point NextCR
        {
            get
            {
                Point Next = new Point(LastCR.X, LastCR.Y);

                if (LastCR.X >= CRCount.X - 1 && LastCR.Y >= CRCount.Y - 1)
                {
                    Next.X = 0;
                    Next.Y = 0;
                    return Next;
                }
                else
                    if (LastCR.X < CRCount.X - 1)//inc X
                {
                    Next.X++;
                    return Next;
                }
                else//inc Y
                {
                    Next.X = 0;
                    Next.Y++;
                    return Next;
                }
            }
        }
        public bool EndOfCount
        {
            get
            {
                return (LastCR.X >= CRCount.X - 1 && LastCR.Y >= CRCount.Y - 1);
            }
        }
        public double StageHeightOffset = 0;//relative height from TouchZ

        public int TotalCount
        {
            get { return CRCount.X * CRCount.Y; }
        }
        public int UsedCount
        {
            get
            {
                if (LastCR.X < 0) return 0;

                int C = Math.Max(LastCR.X, 0);
                int R = Math.Max(LastCR.Y, 0);
                return (CRCount.X * R) + (C + 1);
            }
        }
        public int RemainCount
        {
            get { return TotalCount - UsedCount; }
        }

        private int Cycles = 0;
        public int PromptCleanCycles = 0;

        public void Reset()
        {
            LastCR = new Point(-1, 0);
            Cycles = 0;
        }

        public void SaveSetup()
        {
            string Filename = GDefine.SetupPath + "\\PurgeStage.Setup.ini";

            NUtils.IniFile Inifile = new NUtils.IniFile(Filename);
            Inifile.WriteInteger("Model", "ModelNo", ModelNo);

            Inifile.WriteInteger("Pattern", "Type", (int)Pattern);
            Inifile.WriteDouble("Pattern", "X", PatternSize.X);
            Inifile.WriteDouble("Pattern", "Y", PatternSize.Y);

            Inifile.WriteDouble("Start", "X", StartXY.X);
            Inifile.WriteDouble("Start", "Y", StartXY.Y);
            Inifile.WriteDouble("Pitch", "X", PitchXY.X);
            Inifile.WriteDouble("Pitch", "Y", PitchXY.Y);
            Inifile.WriteInteger("CRCount", "X", CRCount.X);
            Inifile.WriteInteger("CRCount", "Y", CRCount.Y);
            Inifile.WriteInteger("Setting", "PromptCleanCycles", PromptCleanCycles);
            Inifile.WriteDouble("Setting", "StageHeightOffset", StageHeightOffset);
        }
        public void LoadSetup()
        {
            string Filename = GDefine.SetupPath + "\\PurgeStage.Setup.ini";

            NUtils.IniFile Inifile = new NUtils.IniFile(Filename);
            ModelNo = Inifile.ReadInteger("Model", "ModelNo", 0);

            Pattern = EPattern.Dot;
            try
            {
                Pattern = (EPattern)Inifile.ReadInteger("Pattern", "Type", 0);
            }
            catch { };
            PatternSize.X = Inifile.ReadDouble("Pattern", "X", 0);
            PatternSize.Y = Inifile.ReadDouble("Pattern", "Y", 0);

            StartXY.X = Inifile.ReadDouble("Start", "X", 0);
            StartXY.Y = Inifile.ReadDouble("Start", "Y", 0);
            PitchXY.X = Inifile.ReadDouble("Pitch", "X", 1);
            PitchXY.Y = Inifile.ReadDouble("Pitch", "Y", 1);
            CRCount.X = Inifile.ReadInteger("CRCount", "X", 10);
            CRCount.Y = Inifile.ReadInteger("CRCount", "Y", 10);
            PromptCleanCycles = Inifile.ReadInteger("Setting", "PromptCleanCycles", 0);
            StageHeightOffset = Inifile.ReadDouble("Setting", "StageHeightOffset", 0);
        }

        public bool MoveAwayRelative()
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                Y = Y - 50;
            else
                Y = Y + 50;

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return false;

            return true;
        }
        internal bool Execute(int PurgeCount)//return true if commplete
        {
            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.SP:
                case TaskDisp.EPumpType.PP:
                case TaskDisp.EPumpType.PPD:
                    break;
                default:
                    MessageBox.Show("Purge Stage do not support selected Pump Type.");
                    return false;
            }

            if (TaskDisp.PurgeStage.StartXY.X == 0 || TaskDisp.PurgeStage.StartXY.Y == 0)
            {
                MessageBox.Show("Purge Stage fail. Positions not setup.");
                return false;
            }


            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            if (!TaskGantry.SetMotionParamGXY()) return false;

            TModelPara Model = new TModelPara(DispProg.ModelList, ModelNo);
            for (int i = 0; i < PurgeCount; i++)
            {
                double X = StartXY.X + (PitchXY.X * NextCR.X);
                double Y = StartXY.Y + (PitchXY.Y * NextCR.Y);

                if (!TaskGantry.MoveAbsGXY(X, Y)) return false;


                if (Model.DispGap <= 0)
                {
                    DialogResult dr = MessageBox.Show("Model Disp Gap less equal of less than 0(zero).", "Error", MessageBoxButtons.OK);
                    return false;
                }

                switch (DispProg.Pump_Type)
                {
                    case TaskDisp.EPumpType.PP:
                    //case TaskDisp.EPumpType.PP2D:
                    case TaskDisp.EPumpType.PPD:
                        {
                            double VolToDispA_ul = DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj;
                            double VolToDispB_ul = DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj;

                            if (Model.DispVol > 0)
                            {
                                VolToDispA_ul = Model.DispVol;
                                VolToDispB_ul = Model.DispVol;
                            }

                            if (VolToDispA_ul != DispProg.progDispVol[0] || VolToDispB_ul != DispProg.progDispVol[1])
                            {
                                if (!TaskDisp.SetDispVolume(true, false, VolToDispA_ul, VolToDispB_ul))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, "SetDispVolume ");
                                    return false;
                                }
                                DispProg.progDispVol[0] = VolToDispA_ul;
                                DispProg.progDispVol[1] = VolToDispB_ul;
                            }
                            if (Model.BSuckVol > 0)
                            {
                                if (!TaskDisp.Thread_SetBackSuckVolume_Run(true, false, Model.BSuckVol, Model.BSuckVol)) return false;
                            }
                            if (Model.PumpSpeed > 0)
                            {
                                if (!TaskDisp.Thread_SetDispSpeed_Run(true, false, Model.PumpSpeed, Model.PumpSpeed)) return false;
                            }

                            if (Model.FPressA != DispProg.pressVal[0] || Model.FPressB != DispProg.pressVal[1])
                            {
                                FPressCtrl.Thread.Set_PressUnit(new double[2] { Model.FPressA, Model.FPressB });
                                DispProg.pressVal = new double[] { Model.FPressA, Model.FPressB };
                            }
                        }
                        break;
                    case TaskDisp.EPumpType.SP:
                        if (Model.FPressA != DispProg.pressVal[0] || Model.FPressB != DispProg.pressVal[1])
                        {
                            FPressCtrl.Thread.Set_PressUnit(new double[2] { Model.FPressA, Model.FPressB });
                            DispProg.pressVal = new double[] { Model.FPressA, Model.FPressB };
                        }
                        break;
                }

                #region move z to DispGap
                double Z_Ret = TaskDisp.Head_ZSensor_RefPosZ[0] + StageHeightOffset + Model.DispGap + Model.RetGap;
                double Z_Disp = TaskDisp.Head_ZSensor_RefPosZ[0] + StageHeightOffset + Model.DispGap;

                if (!TaskGantry.SetMotionParamGZZ2()) return false;
                if (!TaskGantry.MovePtpAbs(TaskGantry.GZAxis, Z_Ret)) return false;
                if (!TaskGantry.WaitGZ()) return false;

                double sv = Model.DnStartV;
                double dv = Model.DnSpeed;
                double ac = Model.DnAccel;
                if (!TaskGantry.SetMotionParamEx(TaskGantry.GZAxis, sv, dv, ac)) return false;
                if (!TaskGantry.MovePtpAbs(TaskGantry.GZAxis, Z_Disp)) return false;
                if (!TaskGantry.WaitGZ()) return false;

                switch (DispProg.Pump_Type)
                {
                    case TaskDisp.EPumpType.SP:
                        {
                            if (Model.DnWait > 0)
                            {
                                int t = GDefine.GetTickCount() + Model.DnWait;
                                while (true) { if (GDefine.GetTickCount() >= t) break; Thread.Sleep(0); }
                            }

                            if (Pattern == EPattern.Dot)
                            {
                                if (Model.DispTime > 0)
                                    TaskDisp.SP.SP_Shot(Model.DispTime);//StartDelay);
                                else
                                    TaskDisp.SP.SP_Shot((double)DispProg.SP.DispTime[0]);
                            }
                            else//Line
                            {
                                TaskGantry.BVac1 = false;
                                TaskGantry.BPress1 = true;
                                TaskGantry.DispPortC1 = true;

                                if (Model.StartDelay > 0)
                                {
                                    int t = GDefine.GetTickCount() + (int)Model.StartDelay;
                                    while (true) { if (GDefine.GetTickCount() >= t) break; Thread.Sleep(0); }
                                }
                                if (!TaskGantry.SetMotionParamEx(TaskGantry.GXAxis, Model.LineStartV, Model.LineSpeed, Model.LineAccel)) return false;
                                if (!TaskGantry.MoveLineRel(TaskGantry.GXAxis, TaskGantry.GYAxis, PatternSize.X, PatternSize.Y)) return false;

                                if (Model.EndDelay > 0)
                                {
                                    int t = GDefine.GetTickCount() + (int)Model.EndDelay;
                                    while (true) { if (GDefine.GetTickCount() >= t) break; Thread.Sleep(0); }
                                }

                                TaskGantry.DispPortC1 = false;
                                TaskGantry.BVac1 = true;
                                TaskGantry.BPress1 = false;

                                if (!TaskGantry.WaitGXY()) return false;
                                if (!TaskGantry.MoveLineRel(TaskGantry.GXAxis, TaskGantry.GYAxis, PatternSize.X, PatternSize.Y)) return false;
                                if (!TaskGantry.WaitGXY()) return false;
                            }

                            if (Model.PostWait > 0)
                            {
                                int t = GDefine.GetTickCount() + Model.PostWait;
                                while (true) { if (GDefine.GetTickCount() >= t) break; Thread.Sleep(0); }
                            }
                            break;
                        }
                    case TaskDisp.EPumpType.PP:
                    //case TaskDisp.EPumpType.PP2D:
                    case TaskDisp.EPumpType.PPD:
                        {
                            if (!TaskDisp.Thread_SetDispVolume_Wait()) return false;
                            if (Model.BSuckVol > 0)
                                if (!TaskDisp.Thread_SetBackSuckVolume_Wait()) return false;
                            if (Model.PumpSpeed > 0)
                                if (!TaskDisp.Thread_SetDispSpeed_Wait()) return false;

                            if (!TaskDisp.CtrlWaitReady(true, false)) return false;
                            if (!TaskDisp.TrigOn(true, false)) return false;
                            if (!TaskDisp.CtrlWaitResponse(true, false)) return false;
                            if (!TaskDisp.TrigOff(true, false)) return false;
                            //if (b_Head1Run) DispProg.Stats.DispCount_Inc(0);
                            //if (b_Head2Run) DispProg.Stats.DispCount_Inc(1);

                            int t_Start = GDefine.GetTickCount() + (int)Model.StartDelay;

                            if (Model.StartDelay > 0)
                            {
                                while (GDefine.GetTickCount() < t_Start)
                                {
                                    if (Model.StartDelay > 75) Thread.Sleep(1);
                                }
                                goto _Ret;
                            }

                            if (!TaskDisp.CtrlWaitComplete(true, false)) return false;
                            break;
                        }
                }
            _Ret:

                LastCR = NextCR;

                sv = Model.RetStartV;
                dv = Model.RetSpeed;
                ac = Model.RetAccel;
                if (!TaskGantry.SetMotionParamEx(TaskGantry.GZAxis, sv, dv, ac)) return false;
                if (!TaskGantry.MovePtpRel(TaskGantry.GZAxis, Model.RetGap)) return false;
                if (!TaskGantry.WaitGZ()) return false;
                if (Model.RetWait > 0)
                {
                    int t = GDefine.GetTickCount() + Model.RetWait;
                    while (true) { if (GDefine.GetTickCount() >= t) break; Thread.Sleep(0); }
                }

                sv = Model.UpStartV;
                dv = Model.UpSpeed;
                ac = Model.UpAccel;
                if (!TaskGantry.SetMotionParamEx(TaskGantry.GZAxis, sv, dv, ac)) return false;
                if (!TaskGantry.MovePtpRel(TaskGantry.GZAxis, Model.UpGap)) return false;
                if (!TaskGantry.WaitGZ()) return false;
                if (Model.UpWait > 0)
                {
                    int t = GDefine.GetTickCount() + Model.UpWait;
                    while (true) { if (GDefine.GetTickCount() >= t) break; Thread.Sleep(0); }
                }

                #endregion

                if (EndOfCount)
                {
                    Cycles++;
                    if (PromptCleanCycles > 0)
                    {
                        if (Cycles % PromptCleanCycles == 0)
                        {
                            if (!MoveAwayRelative()) return false;
                            DialogResult dr = MessageBox.Show("Purge Stage Full, Clean Purge Stage", "Action", MessageBoxButtons.OKCancel);
                            if (dr == DialogResult.OK)
                            {
                                //return false;
                                //LastCR = new Point(-1, -1);
                            }
                            if (dr == DialogResult.Cancel) return false;
                        }
                    }
                }
            }
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            return true;
        }
    }

    internal class FuncWipeStage
    {
        public TPos3 StartXY = new TPos3();
        public Point OfstCount = new Point(5, 5);
        public TPos3 OfstPitch = new TPos3(1, -1, 0);
        public TPos3 EndXY
        {
            get
            {
                TPos3 Pos3 = new TPos3(StartXY);
                Pos3.X = Pos3.X + (OfstPitch.X * (OfstCount.X - 1));
                Pos3.Y = Pos3.Y + (OfstPitch.Y * (OfstCount.Y - 1));
                return Pos3;
            }
            set
            {
                OfstPitch.X = Math.Round((value.X - StartXY.X) / (OfstCount.X - 1), 3);
                OfstPitch.Y = Math.Round((value.Y - StartXY.Y) / (OfstCount.Y - 1), 3);
            }
        }

        public int TotalCount
        {
            get { return OfstCount.X * OfstCount.Y; }
        }
        public int UsedCount
        {
            get
            {
                if (LastCR.X < 0) return 0;

                int C = Math.Max(LastCR.X, 0);
                int R = Math.Max(LastCR.Y, 0);
                return (OfstCount.X * R) + (C + 1);
            }
        }
        public int RemainCount
        {
            get { return TotalCount - UsedCount; }
        }
        public bool EndOfCount
        {
            get
            {
                return (LastCR.X >= OfstCount.X - 1 && LastCR.Y >= OfstCount.Y - 1);
            }
        }

        public const int MAX_PATH = 5;
        public TPos3[] Path = new TPos3[MAX_PATH] { new TPos3(0, 0, 0), new TPos3(0, 0, 0), new TPos3(0, 0, 0), new TPos3(0, 0, 0), new TPos3(0, 0, 0) };

        public Point LastCR = new Point(1, 1);
        public Point NextCR
        {
            get
            {
                Point Next = new Point(LastCR.X, LastCR.Y);

                if (LastCR.X >= OfstCount.X - 1 && LastCR.Y >= OfstCount.Y - 1)
                {
                    Next.X = 0;
                    Next.Y = 0;
                    return Next;
                }
                else
                    if (LastCR.X < OfstCount.X - 1)//inc X
                {
                    Next.X++;
                    return Next;
                }
                else//inc Y
                {
                    Next.X = 0;
                    Next.Y++;
                    return Next;
                }
            }
        }

        public double WipeHeightOffset = 15;//relative height from TouchZ
        public double WipeGap = 0;
        public double WipeSpeed = 5;
        private int Cycles = 0;
        public int PromptCleanCycles = 0;
        public bool UseTapeIndexer = false;
        public int RepeatWipe = 0;

        public void Reset()
        {
            LastCR = new Point(-1, 0);
        }

        public void SaveSetup()
        {
            string Filename = GDefine.SetupPath + "\\WipeStage.Setup.ini";

            NUtils.IniFile Inifile = new NUtils.IniFile(Filename);

            Inifile.WriteDouble("Start", "X", StartXY.X);
            Inifile.WriteDouble("Start", "Y", StartXY.Y);

            for (int i = 0; i < MAX_PATH; i++)
            {
                Inifile.WriteDouble("Path_" + i.ToString(), "X", Path[i].X);
                Inifile.WriteDouble("Path_" + i.ToString(), "Y", Path[i].Y);
                Inifile.WriteDouble("Path_" + i.ToString(), "Z", Path[i].Z);
            }

            Inifile.WriteInteger("OfstCount", "X", OfstCount.X);
            Inifile.WriteInteger("OfstCount", "Y", OfstCount.Y);
            Inifile.WriteDouble("OfstPitch", "X", OfstPitch.X);
            Inifile.WriteDouble("OfstPitch", "Y", OfstPitch.Y);

            Inifile.WriteDouble("Setting", "WipeHeightOffset", WipeHeightOffset);
            Inifile.WriteDouble("Setting", "WipeGap", WipeGap);
            Inifile.WriteDouble("Setting", "WipeSpeed", WipeSpeed);
            Inifile.WriteInteger("Setting", "PromptCleanCycles", PromptCleanCycles);
            Inifile.WriteBool("Setting", "UseTapeIndexer", UseTapeIndexer);
            Inifile.WriteInteger("Setting", "RepeatWipe", RepeatWipe);
        }
        public void LoadSetup()
        {
            string Filename = GDefine.SetupPath + "\\WipeStage.Setup.ini";

            NUtils.IniFile Inifile = new NUtils.IniFile(Filename);

            StartXY.X = Inifile.ReadDouble("Start", "X", 0);
            StartXY.Y = Inifile.ReadDouble("Start", "Y", 0);

            for (int i = 0; i < MAX_PATH; i++)
            {
                Path[i].X = Inifile.ReadDouble("Path_" + i.ToString(), "X", 0);
                Path[i].Y = Inifile.ReadDouble("Path_" + i.ToString(), "Y", 0);
                Path[i].Z = Inifile.ReadDouble("Path_" + i.ToString(), "Z", 0);
            }

            OfstCount.X = Inifile.ReadInteger("OfstCount", "X", 10);
            OfstCount.Y = Inifile.ReadInteger("OfstCount", "Y", 10);
            OfstPitch.X = Inifile.ReadDouble("OfstPitch", "X", 0.2);
            OfstPitch.Y = Inifile.ReadDouble("OfstPitch", "Y", 0.2);

            WipeHeightOffset = Inifile.ReadDouble("Setting", "WipeHeightOffset", 15);
            WipeGap = Inifile.ReadDouble("Setting", "WipeGap", 0);
            WipeSpeed = Inifile.ReadDouble("Setting", "WipeSpeed", 5);
            PromptCleanCycles = Inifile.ReadInteger("Setting", "PromptCleanCycles", 0);
            UseTapeIndexer = Inifile.ReadBool("Setting", "UseTapeIndexer", false);
            RepeatWipe = Inifile.ReadInteger("Setting", "RepeatWipe", 0);
        }

        public bool MoveAwayRelative()
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                Y = Y - 50;
            else
                Y = Y + 50;

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return false;

            return true;
        }
        internal bool Execute(bool HeadA, bool HeadB)//return true if commplete
        {
            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.Vermes:
                case TaskDisp.EPumpType.Vermes1560:
                case TaskDisp.EPumpType.PJ:
                    break;
                default:
                    MessageBox.Show("Wipe Stage do not support selected Pump Type.");
                    return false;
            }

            if (!HeadA && !HeadB) return false;

            int i_Repeat = 0;
            if (HeadB && GDefine.GantryConfig != GDefine.EGantryConfig.XY_ZX2Y2_Z2) return false;

            if (StartXY.X == 0 || StartXY.Y == 0)
            {
                MessageBox.Show("Wipe Stage fail. Positions not setup.");
                return false;
            }

        _Repeat:
            if (UseTapeIndexer)
            {
                if (!TaskGantry.TapeReady)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.CLEAN_TAPE_CTRL_NOT_READY);
                }

                if (TaskGantry.TapeAlarm)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.CLEAN_TAPE_CTRL_ALARM);
                }

                TaskGantry.TapeTrig = true;
                Thread.Sleep(10);
                TaskGantry.TapeTrig = false;
            }

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                if (!TaskGantry.MoveAbsGX2Y2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y)) return false;
            }

            double X = StartXY.X + (OfstPitch.X * NextCR.X);
            double Y = StartXY.Y + (OfstPitch.Y * NextCR.Y);

            if (HeadA)
            {
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(X, Y)) return false;

                double d_WipeZ = TaskDisp.Head_ZSensor_RefPosZ[0] + WipeHeightOffset + WipeGap;
                if (!TaskGantry.SetMotionParamGZ()) return false;
                if (!TaskGantry.MovePtpAbs(TaskGantry.GZAxis, d_WipeZ)) return false;
                if (!TaskGantry.WaitGZ()) return false;
            }

            if (HeadB && GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(X - TaskDisp.Head2_DefDistX, Y, true)) return false;

                double d_WipeZ = TaskDisp.Head_ZSensor_RefPosZ[1] + WipeHeightOffset + WipeGap;
                if (!TaskGantry.SetMotionParamGZ2()) return false;
                if (!TaskGantry.MovePtpAbs(TaskGantry.GZ2Axis, d_WipeZ)) return false;
                if (!TaskGantry.WaitGZ2()) return false;
            }

            int t = GDefine.GetTickCount() + 100;
            while (true) { if (GDefine.GetTickCount() >= t) break; Thread.Sleep(0); }

            if (UseTapeIndexer)
            {
                int t1 = GDefine.GetTickCount() + 5000;
                while (true)
                {
                    if (TaskGantry.TapeReady) break;

                    if (GDefine.GetTickCount() >= t1) break;
                    Thread.Sleep(0);
                }

                if (GDefine.GetTickCount() >= t1)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.CLEAN_TAPE_CTRL_READY_TIMEOUT);
                    return false;
                }

                if (TaskGantry.TapeAlarm)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.CLEAN_TAPE_CTRL_ALARM);
                }
            }

            TaskGantry.SetMotionParamGXY(10, WipeSpeed, 1000);
            double dX = X;
            double dY = Y;
            for (int i = 0; i < MAX_PATH; i++)
            {
                if (Path[i].X == 0 && Path[i].Y == 0 && Path[i].Y == 0) break;

                dX = dX + Path[i].X;
                dY = dY + Path[i].Y;

                if (HeadA)
                {
                    if (!TaskGantry.MoveAbsGXY(dX, dY, true)) return false;
                    if (!TaskGantry.MoveRelGZ(Path[i].Z, true)) return false;
                }

                if (HeadB && GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.MoveAbsGXY(dX - TaskDisp.Head2_DefDistX, dY, true)) return false;
                    if (!TaskGantry.MoveRelGZ2(Path[i].Z, true)) return false;
                }
            }

            LastCR = NextCR;

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (i_Repeat < RepeatWipe)
            {
                i_Repeat++;
                goto _Repeat;
            }

            if (EndOfCount)
            {
                Cycles++;
                if (PromptCleanCycles > 0)
                {
                    if (Cycles % PromptCleanCycles == 0)
                    {
                        if (!MoveAwayRelative()) return false;
                        DialogResult dr = MessageBox.Show("Wipe Stage Full, Clean Wipe Stage", "Action", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            Reset();
                            //return false;
                            //LastCR = new Point(-1, -1);
                        }
                        if (dr == DialogResult.Cancel) return false;
                    }
                }
            }

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            return true;
        }
    }

    internal static class TaskDisp
    {
        public const int MAX_HEADCOUNT = 2;//maximun no of heads

        public static double ZDefPos = 0.1;
        public const int MoveZUp_TimeOut = 500;

        #region Camera Cal Pos
        public static TPos2 Camera_Cal_Pos = new TPos2(0, 0);//camera calibration, Camera Cal XYPos Current
        public static TPos2 Camera_Cal_Pos_Setup = new TPos2(0, 0);//camera calibration, Camera Cal XYPos Setup
        public static double Camera_Cal_Pos_Tol = 0;//camera calibration, Camera Cal XYPos Tol
        public static double Camera_Cal_Needle1_Z = 0;//camera calibration, Needle1 Z
        public static double Camera_Cal_Needle2_Z = 0;//camera calibration, Needle2 Z
        public static TLightRGBA Camera_Cal_LightRGB = new TLightRGBA(25, 25, 25, 0);

        public static TPos2 BCamera_Cal_Pos = new TPos2(0, 0);//bottom camera calibration, BottomCamera XYPos
        public static TPos2 BCamera_Cal_Pos_Setup = new TPos2(0, 0);//bottom camera calibration, Camera Cal XYPos Setup
        public static double BCamera_Cal_Needle1_Z = 0;//BCamera calibration, Needle1 Z
        public static double BCamera_Cal_Needle2_Z = 0;//BCamera calibration, Needle2 Z
        public static TLightRGBA BCamera_Cal_LightRGB = new TLightRGBA(25, 25, 25, 0);
        public static TLightRGBA BCamera_CalNeedle_LightRGB = new TLightRGBA(25, 25, 25, 0);

        public static TPos2 Camera_ZSensor_Pos = new TPos2(0, 0);//ZSensor, Camera XYPos

        public static TLightRGBA Camera_ZSensor_LightRGB = new TLightRGBA(25, 25, 25, 0);
        public static TLightRGBA Camera_LaserOfst_LightRGB = new TLightRGBA(25, 25, 25, 0);
        public static TLightRGBA Camera_TouchDot_LightRGB = new TLightRGBA(25, 25, 25, 0);
        public static TLightRGBA Camera_TouchDotSet_LightRGB = new TLightRGBA(25, 25, 25, 0);
        public static TLightRGBA TempSensor_Cal_LightRGB = new TLightRGBA(25, 25, 25, 0);

        public enum EHead { One, Two };
        #endregion

        #region Head Cal Pos
        public static double[] Head_ZSensor_RefPosZ = new double[2] { 0, 0 };//Head touch ZSensor ZPos
        public static double[] Head_ZSensor_RefPosZ_Setup = new double[2] { 0, 0 };//Head touch ZSensor ZPos
        public static double Head_ZSensor_RefPosZ_Tol = 0;

        public static TPos3[] Head_Ofst = new TPos3[MAX_HEADCOUNT] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };//Head[] xy distance from Camera, Head[] z offset(correction)
        //public static TPos3[] Head_Ofst_Setup = new TPos3[MAX_HEADCOUNT] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };//Head[] xy distance from Camera Setup, Head[] z offset(correction)
        public static double Head_Ofst_XY_Tol = 0;//Head[] xy distance from Camera Tol
        public static double Head_Ofst_Z_Tol = 0;//Head[] z offset(correction) Tol

        public static TPos3 Head2_DefPos = new TPos3(0, 0, 0);
        public static double Head2_DefDistX = 70;//head2 offset from head1, used in xyz and x2y2z2
        //public static double Head2_MinDistX = 0;//head2 offset from head1
        //public static double Head2_DefDistX// = 0;//head2 offset from head1
        //{
        //    get
        //    {
        //        return Head2_DefDistX;
        //    }
        //}

        public static double Head2_XOffset = 0;
        public static double Head2_YOffset = 0;
        public static double Head2_ZOffset = 0;
        //public static double Head_ZComp_Y_Dist = 0;//head Z compensation
        //public static double Head_ZComp_Y_ZOffset = 0;
        //public static double ZCompensationRatio()
        //{
        //    if (Head_ZComp_Y_Dist == 0) return 0;

        //    return Head_ZComp_Y_ZOffset / Head_ZComp_Y_Dist;
        //}
        #endregion

        #region Laser Cal Pos
        public static TPos2 Laser_Ofst = new TPos2(0, 0);//Laser xy distance from Camera
        public static TPos2 Laser_Ofst_Setup = new TPos2(0, 0);//Laser xy distance from Camera
        public static double Laser_Ofst_XY_Tol = 0;
        public static double Laser_RefPosZ = 0;//Laser Z at ZSensor
        public static double Laser_CalValue = 0;//Difference between touch stage and lifter
        #endregion

        #region Temp Sensor Cal Pos
        public static TPos2 TempSensor_Cal_Pos = new TPos2(0, 0);//Temp Sensor Cal, Camera XYPos
        public static TPos2 TempSensor_Ofst = new TPos2(0, 0);//Temp Sensor xy distance from Camera
        #endregion

        public static double Aperture_Dia = 0;//Size of current Aperture
        public static double Aperture_Dia_Setup = 0;//Size of measure Aperture, update after Setup Needle Offset
        public static double Aperture_Dia_Tol = 0;//Allowable Aperture Tol

        public enum EHeadOperation { Single, Double, Sync };
        public static EHeadOperation Head_Operation = EHeadOperation.Single;
        public static bool ForceSingle = false;

        public static double MultiHead_XYTol = 0.1;//multiple head sync operation
        public static double MultiHead_ZTol = 0.1;//multiple head sync operation
        public static bool TeachNeedle_ForceInTol = false;

        public enum EPumpType { /*Auto*/None, Single, PP, PPD, HM, PP2D, Vermes, TP, TPRV, PJ, SP, Vermes1560 };
        public static double Head_LastPitchX = 0;
        public static double Head_LastNeedlePitchY = 0;

        public static int Head1_CtrlNo = 1;
        public static int Head1_CtrlHeadNo = 1;
        public static int Head2_CtrlNo = 2;
        public static int Head2_CtrlHeadNo = 1;

        //public static bool CheckDispReady = true;
        public static int DispReady_TimeOut = 5000;
        public static int DispResponse_TimeOut = 5000;
        public static int DispComplete_TimeOut = 5000;

        public enum EMaintPos { Clean, Purge, Flush }

        public static TPos3[] Needle_Clean_Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
        public static TPos3[] Needle_Purge_Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
        public static TPos3[] Needle_Flush_Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };

        public static int Needle_Clean_UsePos = 0;
        public static int Needle_Clean_Time = 0;
        public static int Needle_Clean_Wait = 0;
        public static int Needle_Clean_Count = 0;
        public static int Needle_Clean_PostVacTime = 0;

        //public static bool Needle_Purge_UseCleanPos;
        public static int Needle_Purge_UsePos = 0;
        public static int Needle_Purge_Time = 0;
        public static int Needle_Purge_Wait = 0;
        public static int Needle_Purge_Count = 0;
        public static int Needle_Purge_PostVacTime = 0;

        public static int Needle_Flush_UsePos = 0;
        public static int Needle_Flush_Time = 0;
        public static int Needle_Flush_Wait = 0;
        public static int Needle_Flush_Count = 0;
        public static int Needle_Flush_PostVacTime = 0;

        public static int Idle_TimeToIdle = 0;//(s)
        public static int Idle_PurgeDuration = 0;//(ms)
        public static int Idle_PostVacTime = 0;//(ms)
        public static int Idle_PurgeInterval = 5;//(s)

        public static string[] WeightProgramName = new string[2] { "", "" };
        public static EHeadNo[] WeightProgramHead = new EHeadNo[2] { EHeadNo.Head1, EHeadNo.Head1 };

        public static TPos3[] Needle_Maint_Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
        public static TPos3[] Machine_Maint_Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
        public static TPos3[] P1NeedleInspCamPos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
        public static TPos3[] P2NeedleInspCamPos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };

        public static int DispTool_CleanFillCount = 3;
        public static int DispTool_PurgeShotCount = 10;
        public static double DispTool_BarrelPressTime = 10;
        public static int DispTool_RecycleBarrelCount = 5;
        public static int DispTool_RecycleNeedleCount = 5;
        public static double DispTool_RecycleNeedleVolume = 10;//unit ul
        public static double DispTool_RemoveAirTime = 1;

        public static bool Option_EnableRunSingleHead = false;
        public static bool Option_PromptRunSingleHead = false;
        public static bool Option_EnableChuckVac = false;

        public static bool Option_EnableDrawOfstAdjust = false;
        public static double Option_DrawOfstAdjustLimit_XY = 0.5;
        public static double Option_DrawOfstAdjustLimit_Z = 0.1;
        public static double Option_DrawOfstAdjustRate = 0.005;

        public static bool Option_EnableStartIdle = false;
        public static int Option_IdlePurgeTimer = 0;//s
        public static bool Option_EnableScriptCheck = false;
        public static bool Option_EnableScriptCheckUnitMode = false;
        public static bool Option_EnableRealTimeFineTune = false;

        public static int Option_VolumeDisplayDecimalPoint = 3;
        public static string VolumeDisplayDecimalPoint
        {
            get { return "f" + TaskDisp.Option_VolumeDisplayDecimalPoint.ToString(); }
        }

        public static bool Option_HideHPCManualControls = false;
        public static double Option_XYShortDist = 0;//0 - disable, >0 short dist value
        public static double Option_XYShortDistPeakSpeedRatio = 1;//0..1, 1 not suppress

        public static bool CopyLogToServer = false;
        public static string LogServerPath = "c:\\NSW_Server\\";

        public static bool Material_EnableTimer = false;
        public static bool MaterialExpiryForbidContinue = false;
        public static int Material_Life_Multiplier = 1;
        public static DateTime Material_Life_EndTime = DateTime.Now;
        public static DateTime Material_LifePreAlert_Time = DateTime.Now;//volatile
        public static int Material_ExpiryPreAlertTime = 0;//minutes

        public static bool Option_EnableMaterialLow = false;
        public static bool Option_EnableDualMaterial = false;
        public static bool MaterialLowForbidContinue = false;

        public static double Option_ShrinkLast2CLine = 0;
        public static double Option_ExtendLastCLine = 0;
        public static double Option_CLineSpeedRatio = 1;

        public enum ETeachNeedleMethod
        {
            None,
            ZSensor_Mark_Set,
            ZSensor_BCamera,
            StepByStep,
            Laser_CrossHair,
            Laser_ZSensor_Dot_Set
        };
        public static ETeachNeedleMethod TeachNeedle_Method = ETeachNeedleMethod.None;
        public static bool TeachNeedle_PromptOnLotStart = false;
        public static bool TeachNeedle_Completed = false;//volatile
        public static bool TeachNeedle_Bypass = false;//volatile

        public static double TeachNeedle_ZOfst = 0;
        public static int TeachNeedle_WaitTime = 0;

        public static double TeachNeedle_NeedleGap = 0.5;
        public static int TeachNeedle_DotTime = 15;
        public static double TeachNeedle_DotVolume = 0.1;//ul

        public static bool TeachNeedle_LaserPromptCleanStage = false;
        public static double TeachNeedle_LaserChangeRate = 0.2;
        public static bool TeachNeedle_DotPromptCleanStage = true;
        public static TPos2 TeachNeedle_CleanStage_Pos = new TPos2(0, 0);

        public static bool TeachNeedle_WaitNextClick = false;

        public enum EZTouchDetectMethod { Default, Lift };
        public static EZTouchDetectMethod TeachNeedle_ZTouchDetectMethod = EZTouchDetectMethod.Default;

        public static double FlowRateOld = 18;

        public enum EVolumeOfstProtocol { None, AOT_HeightCloseLoop, AOT_FrontTestCloseLoop, DoNotUse_3, Lextar_FrontTestCloseLoop, DoNotUse_5, DoNotUse_6 };
        public static EVolumeOfstProtocol VolumeOfst_Protocol = EVolumeOfstProtocol.None;
        
        public static string VolumeOfst_EqID = "EqID";
        public static string VolumeOfst_LocalPath = "";
        public static string VolumeOfst_DataPath = "";
        public static string VolumeOfst_DataPath2 = "";

        public static void Lmds_WriteLotFile(string s)
        {
            try
            {
                if (LotInfo2.Lmds.sMesLot == "")
                {
                    LotInfo2.Lmds.sMesLot = LotInfo2.Lmds.sMesLot_Last;
                }
                if (LotInfo2.Lmds.sMesLot == "") return;

                string[] paths = new string[5] { GDefine.DataPath, "LotEntry", "Lot", DateTime.Now.ToString("yyyy"), LotInfo2.Lmds.sMesLot + ".txt" };

                string fileName = Path.Combine(paths);
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));

                if (File.Exists(fileName))
                    File.AppendAllText(fileName, s);
                else
                    File.WriteAllText(fileName, s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lmds_WriteLotFile " + ex.Message.ToString());
            }
        }
        public static void Lmds_LotStart()
        {
            try
            {
                //NSW.Net.RegistryUtils Reg = new NSW.Net.RegistryUtils();

                //string LotStatus = Reg.ReadKey("NSWAUTOMATION_LotInfo", "Lot Status", "DEACTIVATED");
                //string MESProduct = Reg.ReadKey("NSWAUTOMATION_LotInfo", "MES Product", "");
                //string CATCode = Reg.ReadKey("NSWAUTOMATION_LotInfo", "CAT Code", "");
                //string MESLot = Reg.ReadKey("NSWAUTOMATION_LotInfo", "MES Lot", "");
                //string SAPWO = Reg.ReadKey("NSWAUTOMATION_LotInfo", "SAP WO", "");
                //string MarketTarget = Reg.ReadKey("NSWAUTOMATION_LotInfo", "Market Target", "");
                //string OptID = Reg.ReadKey("NSWAUTOMATION_LotInfo", "Operator ID", "");
                //string Shift = Reg.ReadKey("NSWAUTOMATION_LotInfo", "Shift", "");
                //string StartTime = Reg.ReadKey("NSWAUTOMATION_LotInfo", "Start Time", "");
                //string EndTime = Reg.ReadKey("NSWAUTOMATION_LotInfo", "End Time", "");
                //string SPD = Reg.ReadKey("NSWAUTOMATION_LotInfo", "SPD", "");
                //string CatridgeAID = Reg.ReadKey("NSWAUTOMATION_LotInfo", "CatridgeAID", "");
                //string CatridgeBID = Reg.ReadKey("NSWAUTOMATION_LotInfo", "CatridgeBID", "");
                //string CatridgeCID = Reg.ReadKey("NSWAUTOMATION_LotInfo", "CatridgeCID", "");
                //string CatridgeDID = Reg.ReadKey("NSWAUTOMATION_LotInfo", "CatridgeDID", "");

                //if (LotInfo2.LotStatus == LotInfo2.ELotStatus.Activated)//.StartsWith("Activated"))
                {
                    string s = DateTime.Now.ToString("o") + (char)9 + "Start Lot" + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "MESProduct" + (char)9 + LotInfo2.Lmds.sMesProduct + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "CATCode" + (char)9 + LotInfo2.Lmds.sCatCode + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "MESLot" + (char)9 + LotInfo2.Lmds.sMesLot + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "SAPWO" + (char)9 + LotInfo2.Lmds.sSapWo + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "MarketTarget" + (char)9 + LotInfo2.Lmds.sMarketTarget + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "OptID" + (char)9 + LotInfo2.sOperatorID + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "Shift" + (char)9 + LotInfo2.sShift + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "SPD" + (char)9 + LotInfo2.sMachineID + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "CatridgeAID" + (char)9 + LotInfo2.sCatridgeAID + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "CatridgeBID" + (char)9 + LotInfo2.sCatridgeBID + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "CatridgeCID" + (char)9 + LotInfo2.sCatridgeCID + "\r\n";
                    s = s + DateTime.Now.ToString("o") + (char)9 + "CatridgeDID" + (char)9 + LotInfo2.sCatridgeDID + "\r\n";
                    Lmds_WriteLotFile(s);
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
            }
        }
        public static void Lmds_LotEnd()
        {
            string s = DateTime.Now.ToString("o") + (char)9 + "End Lot" + "\r\n";
            Lmds_WriteLotFile(s);
        }

        public enum EInputMapProtocol { None, Lumileds_EMap, TD_COB, OSRAM_eMos };
        public static EInputMapProtocol InputMap_Protocol = EInputMapProtocol.None;
        public static bool InputMap_Enabled;

        public static void LoadSetup_IOHandShake()
        {
            string Filename = GDefine.SetupPath + "\\Disp.Setup." + DispProg.Pump_Type.ToString() + ".ini";
            NUtils.IniFile IniFile = new NUtils.IniFile(Filename);

            switch (DispProg.Pump_Type)
            {
                default:
                    DispReady_TimeOut = IniFile.ReadInteger("Options", "DispReadyTimeOut", 0);
                    DispResponse_TimeOut = IniFile.ReadInteger("Options", "DispBusyTimeOut", 0);
                    DispComplete_TimeOut = IniFile.ReadInteger("Options", "DispCompleteTimeOut", 0);
                    DispReadyLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispReadyLogic", (int)EDispIOLogic.None);
                    DispResponseLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispResponseLogic", (int)EDispIOLogic.None);
                    DispCompleteLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispCompleteLogic", (int)EDispIOLogic.None);
                    break;
                case EPumpType.PP:
                case EPumpType.PP2D:
                case EPumpType.PPD:
                    {
                        DispReady_TimeOut = IniFile.ReadInteger("Options", "DispReadyTimeOut", 30000);
                        DispResponse_TimeOut = IniFile.ReadInteger("Options", "DispBusyTimeOut", 2000);
                        DispComplete_TimeOut = IniFile.ReadInteger("Options", "DispCompleteTimeOut", 30000);
                        DispReadyLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispReadyLogic", (int)EDispIOLogic.High);
                        DispResponseLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispResponseLogic", (int)EDispIOLogic.Low);
                        DispCompleteLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispCompleteLogic", (int)EDispIOLogic.High);
                        break;
                    }
                case EPumpType.HM:
                    {
                        DispReady_TimeOut = IniFile.ReadInteger("Options", "DispReadyTimeOut", 500);
                        DispResponse_TimeOut = IniFile.ReadInteger("Options", "DispBusyTimeOut", 50);
                        DispComplete_TimeOut = IniFile.ReadInteger("Options", "DispCompleteTimeOut", 5000);
                        DispReadyLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispReadyLogic", (int)EDispIOLogic.High);
                        DispResponseLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispResponseLogic", (int)EDispIOLogic.Low);
                        DispCompleteLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispCompleteLogic", (int)EDispIOLogic.High);
                        break;
                    }
                case EPumpType.Vermes:
                case EPumpType.Vermes1560:
                    {
                        DispReady_TimeOut = IniFile.ReadInteger("Options", "DispReadyTimeOut", 500);
                        DispResponse_TimeOut = IniFile.ReadInteger("Options", "DispBusyTimeOut", 50);
                        DispComplete_TimeOut = IniFile.ReadInteger("Options", "DispCompleteTimeOut", 5000);
                        DispReadyLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispReadyLogic", (int)EDispIOLogic.High);
                        DispResponseLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispResponseLogic", (int)EDispIOLogic.Low);
                        DispCompleteLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispCompleteLogic", (int)EDispIOLogic.High);
                        break;
                    }
            }

            DispErrorLogic = (EDispIOLogic)IniFile.ReadInteger("Options", "DispErrorLogic", (int)EDispIOLogic.None);

            double x = IniFile.ReadDouble("Needle0", "CleanPos_X", 0);
            double y = IniFile.ReadDouble("Needle0", "CleanPos_Y", 0);
            if (x == 0 && y == 0)
            {
                Filename = GDefine.SetupPath + "\\Disp.Setup.ini";
                IniFile = new NUtils.IniFile(Filename);
            }

            #region Needle Clean, Purge, Flush
            for (int i = 0; i < MAX_HEADCOUNT; i++)
            {
                Needle_Clean_Pos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "CleanPos_X", 0);
                Needle_Clean_Pos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "CleanPos_Y", 0);
                Needle_Clean_Pos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "CleanPos_Z", 0);

                Needle_Purge_Pos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "PurgePos_X", 0);
                Needle_Purge_Pos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "PurgePos_Y", 0);
                Needle_Purge_Pos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "PurgePos_Z", 0);

                Needle_Flush_Pos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "FlushPos_X", 0);
                Needle_Flush_Pos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "FlushPos_Y", 0);
                Needle_Flush_Pos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "FlushPos_Z", 0);

                P1NeedleInspCamPos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "P1InspCamPos_X", 0);
                P1NeedleInspCamPos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "P1InspCamPos_Y", 0);
                P1NeedleInspCamPos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "P1InspCamPos_Z", 0);

                P2NeedleInspCamPos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "P2InspCamPos_X", 0);
                P2NeedleInspCamPos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "P2InspCamPos_Y", 0);
                P2NeedleInspCamPos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "P2InspCamPos_Z", 0);
            }
            Needle_Clean_UsePos = IniFile.ReadInteger("NeedleClean", "UsePos", 0);
            Needle_Clean_Time = IniFile.ReadInteger("NeedleClean", "Time", 1000);
            Needle_Clean_Wait = IniFile.ReadInteger("NeedleClean", "Wait", 100);
            Needle_Clean_Count = IniFile.ReadInteger("NeedleClean", "Count", 1);
            Needle_Clean_PostVacTime = IniFile.ReadInteger("NeedleClean", "PostVacTime", 0);

            Needle_Purge_UsePos = IniFile.ReadInteger("NeedlePurge", "UsePos", 1);
            Needle_Purge_Time = IniFile.ReadInteger("NeedlePurge", "Time", 1000);
            Needle_Purge_Wait = IniFile.ReadInteger("NeedlePurge", "Wait", 100);
            Needle_Purge_Count = IniFile.ReadInteger("NeedlePurge", "Count", 1);
            Needle_Purge_PostVacTime = IniFile.ReadInteger("NeedlePurge", "PostVacTime", 100);

            Needle_Flush_UsePos = IniFile.ReadInteger("NeedleFlush", "UsePos", 2);
            Needle_Flush_Time = IniFile.ReadInteger("NeedleFlush", "Time", 15000);
            Needle_Flush_Wait = IniFile.ReadInteger("NeedleFlush", "Wait", 100);
            Needle_Flush_Count = IniFile.ReadInteger("NeedleFlush", "Count", 1);
            Needle_Flush_PostVacTime = IniFile.ReadInteger("NeedleFlush", "PostVacTime", 0);
            #endregion
        }
        public static void SaveSetup_IOHandShake()
        {
            string Filename = GDefine.SetupPath + "\\Disp.Setup." + DispProg.Pump_Type.ToString() + ".ini";
            NUtils.IniFile IniFile = new NUtils.IniFile(Filename);

            IniFile.WriteInteger("Options", "DispReadyTimeOut", DispReady_TimeOut);
            IniFile.WriteInteger("Options", "DispBusyTimeOut", DispResponse_TimeOut);
            IniFile.WriteInteger("Options", "DispCompleteTimeOut", DispComplete_TimeOut);
            IniFile.WriteInteger("Options", "DispReadyLogic", (int)DispReadyLogic);
            IniFile.WriteInteger("Options", "DispResponseLogic", (int)DispResponseLogic);
            IniFile.WriteInteger("Options", "DispCompleteLogic", (int)DispCompleteLogic);
            IniFile.WriteInteger("Options", "DispErrorLogic", (int)DispErrorLogic);

            #region needle Clean
            for (int i = 0; i < MAX_HEADCOUNT; i++)
            {
                IniFile.WriteDouble("Needle" + i.ToString(), "CleanPos_X", Needle_Clean_Pos[i].X);
                IniFile.WriteDouble("Needle" + i.ToString(), "CleanPos_Y", Needle_Clean_Pos[i].Y);
                IniFile.WriteDouble("Needle" + i.ToString(), "CleanPos_Z", Needle_Clean_Pos[i].Z);

                IniFile.WriteDouble("Needle" + i.ToString(), "PurgePos_X", Needle_Purge_Pos[i].X);
                IniFile.WriteDouble("Needle" + i.ToString(), "PurgePos_Y", Needle_Purge_Pos[i].Y);
                IniFile.WriteDouble("Needle" + i.ToString(), "PurgePos_Z", Needle_Purge_Pos[i].Z);

                IniFile.WriteDouble("Needle" + i.ToString(), "FlushPos_X", Needle_Flush_Pos[i].X);
                IniFile.WriteDouble("Needle" + i.ToString(), "FlushPos_Y", Needle_Flush_Pos[i].Y);
                IniFile.WriteDouble("Needle" + i.ToString(), "FlushPos_Z", Needle_Flush_Pos[i].Z);

                IniFile.WriteDouble("Needle" + i.ToString(), "P1InspCamPos_X", P1NeedleInspCamPos[i].X);
                IniFile.WriteDouble("Needle" + i.ToString(), "P1InspCamPos_Y", P1NeedleInspCamPos[i].Y);
                IniFile.WriteDouble("Needle" + i.ToString(), "P1InspCamPos_Z", P1NeedleInspCamPos[i].Z);

                IniFile.WriteDouble("Needle" + i.ToString(), "P2InspCamPos_X", P2NeedleInspCamPos[i].X);
                IniFile.WriteDouble("Needle" + i.ToString(), "P2InspCamPos_Y", P2NeedleInspCamPos[i].Y);
                IniFile.WriteDouble("Needle" + i.ToString(), "P2InspCamPos_Z", P2NeedleInspCamPos[i].Z);
            }
            IniFile.WriteInteger("NeedleClean", "UsePos", Needle_Clean_UsePos);
            IniFile.WriteInteger("NeedleClean", "Time", Needle_Clean_Time);
            IniFile.WriteInteger("NeedleClean", "Wait", Needle_Clean_Wait);
            IniFile.WriteInteger("NeedleClean", "Count", Needle_Clean_Count);
            IniFile.WriteInteger("NeedleClean", "PostVacTime", Needle_Clean_PostVacTime);

            IniFile.WriteInteger("NeedlePurge", "UsePos", Needle_Purge_UsePos);
            IniFile.WriteInteger("NeedlePurge", "Time", Needle_Purge_Time);
            IniFile.WriteInteger("NeedlePurge", "Wait", Needle_Purge_Wait);
            IniFile.WriteInteger("NeedlePurge", "Count", Needle_Purge_Count);
            IniFile.WriteInteger("NeedlePurge", "PostVacTime", Needle_Purge_PostVacTime);

            IniFile.WriteInteger("NeedleFlush", "UsePos", Needle_Flush_UsePos);
            IniFile.WriteInteger("NeedleFlush", "Time", Needle_Flush_Time);
            IniFile.WriteInteger("NeedleFlush", "Wait", Needle_Flush_Wait);
            IniFile.WriteInteger("NeedleFlush", "Count", Needle_Flush_Count);
            IniFile.WriteInteger("NeedleFlush", "PostVacTime", Needle_Flush_PostVacTime);
            #endregion
        }

        public enum EPreference { None, Lextar, Lumileds, Osram, Cree, TD_4FCOB, Unisem, Analog };
        public static EPreference Preference = EPreference.None;
        public static string CustomPath = "";

        public static bool EnableRecipeFile = true;
        public enum ESECSGEMProtocol { None, SECSGEMConnect2 };
        public static ESECSGEMProtocol SECSGEMProtocol = ESECSGEMProtocol.None;

        public static void LoadSetup()
        {
            string Filename = GDefine.SetupPath + "\\Disp.Setup.ini";
            NUtils.IniFile IniFile = new NUtils.IniFile(Filename);

            ZDefPos = IniFile.ReadDouble("Gantry", "ZDefPos", 0.1);

            #region Camera Cal Pos
            Camera_Cal_Pos.X = IniFile.ReadDouble("Camera", "Cal_Pos_X", 0);
            Camera_Cal_Pos.Y = IniFile.ReadDouble("Camera", "Cal_Pos_Y", 0);
            Camera_Cal_Pos_Setup.X = IniFile.ReadDouble("Camera", "Cal_Pos_X_Setup", 0);
            Camera_Cal_Pos_Setup.Y = IniFile.ReadDouble("Camera", "Cal_Pos_Y_Setup", 0);
            Camera_Cal_Pos_Tol = IniFile.ReadDouble("Camera", "Cal_Pos_Tol", 0.2);
            Camera_Cal_Needle1_Z = IniFile.ReadDouble("Camera", "Cal_Needle1_Z", 0);
            Camera_Cal_Needle2_Z = IniFile.ReadDouble("Camera", "Cal_Needle2_Z", 0);
            Camera_Cal_LightRGB.R = IniFile.ReadInteger("Camera", "Cal_LightRGB_R", 25);
            Camera_Cal_LightRGB.G = IniFile.ReadInteger("Camera", "Cal_LightRGB_G", 25);
            Camera_Cal_LightRGB.B = IniFile.ReadInteger("Camera", "Cal_LightRGB_B", 25);
            Camera_Cal_LightRGB.A = IniFile.ReadInteger("Camera", "Cal_LightRGB_A", 25);

            BCamera_Cal_Pos.X = IniFile.ReadDouble("BCamera", "Cal_Pos_X", 0);
            BCamera_Cal_Pos.Y = IniFile.ReadDouble("BCamera", "Cal_Pos_Y", 0);
            BCamera_Cal_Pos_Setup.X = IniFile.ReadDouble("BCamera", "Cal_Pos_X_Setup", 0);
            BCamera_Cal_Pos_Setup.Y = IniFile.ReadDouble("BCamera", "Cal_Pos_Y_Setup", 0);
            BCamera_Cal_Needle1_Z = IniFile.ReadDouble("BCamera", "Cal_Needle1_Z", 0);
            BCamera_Cal_Needle2_Z = IniFile.ReadDouble("BCamera", "Cal_Needle2_Z", 0);
            BCamera_Cal_LightRGB.R = IniFile.ReadInteger("BCamera", "Cal_LightRGB_R", 25);
            BCamera_Cal_LightRGB.G = IniFile.ReadInteger("BCamera", "Cal_LightRGB_G", 25);
            BCamera_Cal_LightRGB.B = IniFile.ReadInteger("BCamera", "Cal_LightRGB_B", 25);
            BCamera_Cal_LightRGB.A = IniFile.ReadInteger("BCamera", "Cal_LightRGB_A", 25);
            BCamera_CalNeedle_LightRGB.R = IniFile.ReadInteger("BCamera", "CalNeedle_LightRGB_R", 25);
            BCamera_CalNeedle_LightRGB.G = IniFile.ReadInteger("BCamera", "CalNeedle_LightRGB_G", 25);
            BCamera_CalNeedle_LightRGB.B = IniFile.ReadInteger("BCamera", "CalNeedle_LightRGB_B", 25);
            BCamera_CalNeedle_LightRGB.A = IniFile.ReadInteger("BCamera", "CalNeedle_LightRGB_A", 25);

            Camera_ZSensor_Pos.X = IniFile.ReadDouble("Camera", "ZSensor_X", 0);
            Camera_ZSensor_Pos.Y = IniFile.ReadDouble("Camera", "ZSensor_Y", 0);
            Camera_ZSensor_LightRGB.R = IniFile.ReadInteger("Camera", "ZSensor_LightRGB_R", 25);
            Camera_ZSensor_LightRGB.G = IniFile.ReadInteger("Camera", "ZSensor_LightRGB_G", 25);
            Camera_ZSensor_LightRGB.B = IniFile.ReadInteger("Camera", "ZSensor_LightRGB_B", 25);
            Camera_ZSensor_LightRGB.A = IniFile.ReadInteger("Camera", "ZSensor_LightRGB_A", 25);
            Camera_LaserOfst_LightRGB.R = IniFile.ReadInteger("Camera", "LaserOfst_LightRGB_R", 25);
            Camera_LaserOfst_LightRGB.G = IniFile.ReadInteger("Camera", "LaserOfst_LightRGB_G", 25);
            Camera_LaserOfst_LightRGB.B = IniFile.ReadInteger("Camera", "LaserOfst_LightRGB_B", 25);
            Camera_LaserOfst_LightRGB.A = IniFile.ReadInteger("Camera", "LaserOfst_LightRGB_A", 25);
            Camera_TouchDot_LightRGB.R = IniFile.ReadInteger("Camera", "TouchDot_LightRGB_R", 25);
            Camera_TouchDot_LightRGB.G = IniFile.ReadInteger("Camera", "TouchDot_LightRGB_G", 25);
            Camera_TouchDot_LightRGB.B = IniFile.ReadInteger("Camera", "TouchDot_LightRGB_B", 25);
            Camera_TouchDot_LightRGB.A = IniFile.ReadInteger("Camera", "TouchDot_LightRGB_A", 25);
            Camera_TouchDotSet_LightRGB.R = IniFile.ReadInteger("Camera", "TouchDotSet_LightRGB_R", 25);
            Camera_TouchDotSet_LightRGB.G = IniFile.ReadInteger("Camera", "TouchDotSet_LightRGB_G", 25);
            Camera_TouchDotSet_LightRGB.B = IniFile.ReadInteger("Camera", "TouchDotSet_LightRGB_B", 25);
            Camera_TouchDotSet_LightRGB.A = IniFile.ReadInteger("Camera", "TouchDotSet_LightRGB_A", 25);
            #endregion

            #region Head Cal Pos
            for (int i = 0; i < MAX_HEADCOUNT; i++)
            {
                Head_ZSensor_RefPosZ[i] = IniFile.ReadDouble("Head" + i.ToString(), "ZSensor_RefPos_Z", 0);
                Head_ZSensor_RefPosZ_Setup[i] = IniFile.ReadDouble("Head" + i.ToString(), "ZSensor_RefPos_Z_Setup", 0);
            }
            Head_ZSensor_RefPosZ_Tol = IniFile.ReadDouble("Head", "ZSensor_RefPos_Z_Tol", 0);
            for (int i = 0; i < MAX_HEADCOUNT; i++)
            {
                Head_Ofst[i].X = IniFile.ReadDouble("Head" + i.ToString(), "Ofst_X", 0);
                Head_Ofst[i].Y = IniFile.ReadDouble("Head" + i.ToString(), "Ofst_Y", 0);
                Head_Ofst[i].Z = IniFile.ReadDouble("Head" + i.ToString(), "Ofst_Z", 0);
                //Head_Ofst_Setup[i].X = IniFile.ReadDouble("Head" + i.ToString(), "Ofst_X_Setup", 0);
                //Head_Ofst_Setup[i].Y = IniFile.ReadDouble("Head" + i.ToString(), "Ofst_Y_Setup", 0);
                //Head_Ofst_Setup[i].Z = IniFile.ReadDouble("Head" + i.ToString(), "Ofst_Z_Setup", 0);
            }
            Head_Ofst_XY_Tol = IniFile.ReadDouble("Head", "Ofst_XY_Tol", 0);
            Head_Ofst_Z_Tol = IniFile.ReadDouble("Head", "Ofst_Z_Tol", 0);

            Head2_DefDistX = IniFile.ReadDouble("Head2", "Ofst_X", 70);
            Head2_DefPos.X = IniFile.ReadDouble("Head2", "DefPos_X", 0);
            Head2_DefPos.Y = IniFile.ReadDouble("Head2", "DefPos_Y", 0);
            //Head2_MinDistX = IniFile.ReadDouble("Head2", "MinDist_X", 70);

            Head2_XOffset = IniFile.ReadDouble("Head2", "XOffset", 0);
            Head2_YOffset = IniFile.ReadDouble("Head2", "YOffset", 0);
            Head2_ZOffset = IniFile.ReadDouble("Head2", "ZOffset", 0);

            //Head_ZComp_Y_Dist = IniFile.ReadDouble("Head", "ZComp_Y_Dist", 0);
            //Head_ZComp_Y_ZOffset = IniFile.ReadDouble("Head", "ZComp_Y_ZOffset", 0);
            #endregion

            #region Laser Pos
            Laser_Ofst.X = IniFile.ReadDouble("Laser", "Ofst_X", 0);
            Laser_Ofst.Y = IniFile.ReadDouble("Laser", "Ofst_Y", 0);
            Laser_Ofst_Setup.X = IniFile.ReadDouble("Laser", "Ofst_X_Setup", 0);
            Laser_Ofst_Setup.Y = IniFile.ReadDouble("Laser", "Ofst_Y_Setup", 0);
            Laser_Ofst_XY_Tol = IniFile.ReadDouble("Laser", "Ofst_XY_Tol", 0);
            Laser_RefPosZ = IniFile.ReadDouble("Laser", "RefPos_Z", 0);
            //Laser_RefPosZ_Setup = IniFile.ReadDouble("Laser", "RefPos_Z_Setup", 0);
            Laser_CalValue = IniFile.ReadDouble("Laser", "CalValue", 0);
            #endregion

            DispProg.SP.IntPulseOnDelay[0] = IniFile.ReadDouble("SP", "IntPulseOnDelay", 0);
            DispProg.SP.IntPulseOffDelay[0] = IniFile.ReadDouble("SP", "IntPulseOffDelay", 0);

            TaskDisp.Vermes3200[0].Heater.SetTemp = (uint)IniFile.ReadInteger("Vermes_0", "TempOfst", 0);
            TaskDisp.Vermes3200[1].Heater.SetTemp = (uint)IniFile.ReadInteger("Vermes_1", "TempOfst", 0);

            TempSensor_Cal_Pos.X = IniFile.ReadDouble("TempSensor", "Cal_Pos_X", 0);
            TempSensor_Cal_Pos.Y = IniFile.ReadDouble("TempSensor", "Cal_Pos_Y", 0);
            TempSensor_Ofst.X = IniFile.ReadDouble("TempSensor", "Ofst_X", 0);
            TempSensor_Ofst.Y = IniFile.ReadDouble("TempSensor", "Ofst_Y", 0);
            TempSensor_Cal_LightRGB.R = IniFile.ReadInteger("Camera", "TempSensor_LightRGB_R", 25);
            TempSensor_Cal_LightRGB.G = IniFile.ReadInteger("Camera", "TempSensor_LightRGB_G", 25);
            TempSensor_Cal_LightRGB.B = IniFile.ReadInteger("Camera", "TempSensor_LightRGB_B", 25);
            TempSensor_Cal_LightRGB.A = IniFile.ReadInteger("Camera", "TempSensor_LightRGB_A", 25);

            Aperture_Dia = IniFile.ReadDouble("Aperture", "Dia", 0);
            Aperture_Dia_Setup = IniFile.ReadDouble("Aperture", "Dia_Setup", 0);
            Aperture_Dia_Tol = IniFile.ReadDouble("Aperture", "Dia_Tol", 0);

            #region Needle Clean, Purge, Flush
            //for (int i = 0; i < MAX_HEADCOUNT; i++)
            //{
            //    Needle_Clean_Pos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "CleanPos_X", 0);
            //    Needle_Clean_Pos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "CleanPos_Y", 0);
            //    Needle_Clean_Pos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "CleanPos_Z", 0);

            //    Needle_Purge_Pos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "PurgePos_X", 0);
            //    Needle_Purge_Pos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "PurgePos_Y", 0);
            //    Needle_Purge_Pos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "PurgePos_Z", 0);

            //    Needle_Flush_Pos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "FlushPos_X", 0);
            //    Needle_Flush_Pos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "FlushPos_Y", 0);
            //    Needle_Flush_Pos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "FlushPos_Z", 0);
            //}
            //Needle_Clean_UsePos = IniFile.ReadInteger("NeedleClean", "UsePos", 0);
            //Needle_Clean_Time = IniFile.ReadInteger("NeedleClean", "Time", 1000);
            //Needle_Clean_Wait = IniFile.ReadInteger("NeedleClean", "Wait", 100);
            //Needle_Clean_Count = IniFile.ReadInteger("NeedleClean", "Count", 1);
            //Needle_Clean_PostVacTime = IniFile.ReadInteger("NeedleClean", "PostVacTime", 0);

            //Needle_Purge_UsePos = IniFile.ReadInteger("NeedlePurge", "UsePos", 1);
            //Needle_Purge_Time = IniFile.ReadInteger("NeedlePurge", "Time", 1000);
            //Needle_Purge_Wait = IniFile.ReadInteger("NeedlePurge", "Wait", 100);
            //Needle_Purge_Count = IniFile.ReadInteger("NeedlePurge", "Count", 1);
            //Needle_Purge_PostVacTime = IniFile.ReadInteger("NeedlePurge", "PostVacTime", 100);

            //Needle_Flush_UsePos = IniFile.ReadInteger("NeedleFlush", "UsePos", 2);
            //Needle_Flush_Time = IniFile.ReadInteger("NeedleFlush", "Time", 15000);
            //Needle_Flush_Wait = IniFile.ReadInteger("NeedleFlush", "Wait", 100);
            //Needle_Flush_Count = IniFile.ReadInteger("NeedleFlush", "Count", 1);
            //Needle_Flush_PostVacTime = IniFile.ReadInteger("NeedleFlush", "PostVacTime", 0);
            #endregion

            Idle_TimeToIdle = IniFile.ReadInteger("Idle", "TimeToIdle", 0);
            Idle_PurgeDuration = IniFile.ReadInteger("Idle", "PurgeDuration", 100);
            Idle_PostVacTime = IniFile.ReadInteger("Idle", "PostVacTime", 100);
            Idle_PurgeInterval = IniFile.ReadInteger("Idle", "PurgeInterval", 60);

            #region Needle Weight
            //for (int i = 0; i < MAX_HEADCOUNT; i++)
            //{
            //    Needle_Weight_Pos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "WeightPos_X", 0);
            //    Needle_Weight_Pos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "WeightPos_Y", 0);
            //    Needle_Weight_Pos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "WeightPos_Z", 0);
            //}
            //WeightProgramName = IniFile.ReadString("Weight", "ProgramName", "");
            for (int i = 0; i < 2; i++)
            {
                WeightProgramName[i] = IniFile.ReadString("Weight", "ProgramName" + i.ToString(), "");
                WeightProgramHead[i] = (EHeadNo)IniFile.ReadInteger("Weight", "ProgramHead" + i.ToString(), 0);
            }
            #endregion
            #region Needle Maint Pos
            for (int i = 0; i < MAX_HEADCOUNT; i++)
            {
                Needle_Maint_Pos[i].X = IniFile.ReadDouble("Needle" + i.ToString(), "MaintPos_X", 0);
                Needle_Maint_Pos[i].Y = IniFile.ReadDouble("Needle" + i.ToString(), "MaintPos_Y", 0);
                Needle_Maint_Pos[i].Z = IniFile.ReadDouble("Needle" + i.ToString(), "MaintPos_Z", 0);

                Machine_Maint_Pos[i].X = IniFile.ReadDouble("Machine" + i.ToString(), "MaintPos_X", 0);
                Machine_Maint_Pos[i].Y = IniFile.ReadDouble("Machine" + i.ToString(), "MaintPos_Y", 0);
                Machine_Maint_Pos[i].Z = IniFile.ReadDouble("Machine" + i.ToString(), "MaintPos_Z", 0);
            }
            #endregion

            Maint.PP.FillCountLimit[0] = IniFile.ReadInteger("Maint", "FillCountLimit0", 0);
            Maint.PP.FillCountLimit[1] = IniFile.ReadInteger("Maint", "FillCountLimit1", 0);
            Maint.Disp.CountLimit[0] = IniFile.ReadInteger("Maint", "UnitLimit0", 0);
            Maint.Disp.CountLimit[1] = IniFile.ReadInteger("Maint", "UnitLimit1", 0);

            TeachNeedle_Method = (ETeachNeedleMethod)IniFile.ReadInteger("TeachNeedle", "Method", (int)ETeachNeedleMethod.None);
            TeachNeedle_PromptOnLotStart = IniFile.ReadBool("TeachNeedle", "PromptOnLotStart", false);

            TeachNeedle_ZOfst = IniFile.ReadDouble("TeachNeedle", "ZOfst", 0);
            TeachNeedle_WaitTime = IniFile.ReadInteger("TeachNeedle", "DownTime", 0);

            TeachNeedle_NeedleGap = IniFile.ReadDouble("TeachNeedle", "NeedleGap", 0.5);
            TeachNeedle_DotTime = IniFile.ReadInteger("TeachNeedle", "DotTime", 15);
            TeachNeedle_DotVolume = IniFile.ReadDouble("TeachNeedle", "DotVolume", 0.1);

            TeachNeedle_LaserPromptCleanStage = IniFile.ReadBool("TeachNeedle", "LaserPromptCleanStage", false);
            TeachNeedle_LaserChangeRate = IniFile.ReadDouble("TeachNeedle", "LaserChangeRate", 0.25);
            TeachNeedle_DotPromptCleanStage = IniFile.ReadBool("TeachNeedle", "DotPromptCleanStage", false);
            //TeachNeedle_CleanStageClearDist = IniFile.ReadDouble("TeachNeedle", "CleanStageClearDist", 0);
            TeachNeedle_CleanStage_Pos.X = IniFile.ReadDouble("TeachNeedle", "CleanStage_Pos_X", 0);
            TeachNeedle_CleanStage_Pos.Y = IniFile.ReadDouble("TeachNeedle", "CleanStage_Pos_Y", 0);


            //MultiHead_Type = (EMultiHeadType)IniFile.ReadInteger("MultiHead", "Type", (int)EMultiHeadType.Single);
            //MultiHead_PitchX = IniFile.ReadDouble("MultiHead", "PitchX", 68);
            MultiHead_XYTol = IniFile.ReadDouble("MultiHead", "XYTol", 0.05);
            MultiHead_ZTol = IniFile.ReadDouble("MultiHead", "ZTol", 0.05);
            TeachNeedle_ForceInTol = IniFile.ReadBool("TeachNeedle", "ForceInTol", false);

            //Pump_Type = (EPumpType)IniFile.ReadInteger("Pump", "Type", (int)EPumpType.Single);
            //Pump_NeedlePitchY = IniFile.ReadDouble("Pump", "NeedlePitchY", -26.4);
            TeachNeedle_ZTouchDetectMethod = EZTouchDetectMethod.Default;
            try
            {
                TeachNeedle_ZTouchDetectMethod = (EZTouchDetectMethod)IniFile.ReadInteger("TeachNeedle", "ZTouchDetectMethod", (int)EZTouchDetectMethod.Default);
            }
            catch { };

            Head1_CtrlNo = IniFile.ReadInteger("Head1", "CtrlNo", -1);
            Head1_CtrlHeadNo = IniFile.ReadInteger("Head1", "CtrlHeadNo", -1);
            Head2_CtrlNo = IniFile.ReadInteger("Head2", "CtrlNo", -1);
            Head2_CtrlHeadNo = IniFile.ReadInteger("Head2", "CtrlHeadNo", -1);

            DispTool_CleanFillCount = IniFile.ReadInteger("DispTool", "CleanFillCount", 2);
            DispTool_PurgeShotCount = IniFile.ReadInteger("DispTool", "PurgeShotCount", 10);
            DispTool_BarrelPressTime = IniFile.ReadDouble("DispTool", "BarrelPressTime", 10);
            DispTool_RecycleBarrelCount = IniFile.ReadInteger("DispTool", "RecycleBarrelCount", 5);
            DispTool_RemoveAirTime = IniFile.ReadDouble("DispTool", "RemoveAirTime", 1);
            DispTool_RecycleNeedleCount = IniFile.ReadInteger("DispTool", "RecycleNeedleCount", 5);
            DispTool_RecycleNeedleVolume = IniFile.ReadDouble("DispTool", "RecycleNeedleVolume", 10);

            Option_EnableRunSingleHead = IniFile.ReadBool("Option", "EnableRunSingleHead", false);
            Option_PromptRunSingleHead = IniFile.ReadBool("Option", "PromptRunSingleHead", false);
            Option_EnableChuckVac = IniFile.ReadBool("Option", "EnableChuckVac", false);

            Option_EnableDrawOfstAdjust = IniFile.ReadBool("Option", "EnableDrawOfstAdjust", false);
            Option_DrawOfstAdjustLimit_XY = IniFile.ReadDouble("Option", "DrawOfstAdjustLimit_XY", 0.5);
            Option_DrawOfstAdjustLimit_Z = IniFile.ReadDouble("Option", "DrawOfstAdjustLimit_Z", 0.1);
            Option_DrawOfstAdjustRate = IniFile.ReadDouble("Option", "DrawOfstAdjustRate", 0.1);

            Option_EnableStartIdle = IniFile.ReadBool("Option", "EnableStartIdle", false);
            Option_IdlePurgeTimer = IniFile.ReadInteger("Option", "IdlePurgeTimer", 0);
            Option_EnableScriptCheck = IniFile.ReadBool("Option", "EnableScriptCheck", false);
            Option_EnableScriptCheckUnitMode = IniFile.ReadBool("Option", "EnableScriptCheckUnitMode", false);
            Option_EnableRealTimeFineTune = IniFile.ReadBool("Option", "EnableRealTimeFineTune", false);

            Option_VolumeDisplayDecimalPoint = IniFile.ReadInteger("Option", "VolumeDisplayDecimalPoint", 3);

            Option_HideHPCManualControls = IniFile.ReadBool("Option", "HideHPCManualControls", false);
            Option_XYShortDist = IniFile.ReadDouble("Option", "XYShortDist", 0);
            Option_XYShortDistPeakSpeedRatio = IniFile.ReadDouble("Option", "XYShortDistPeakSpeedRatio", 1);

            Material_EnableTimer = IniFile.ReadBool("Material", "EnableTimer", false);
            MaterialExpiryForbidContinue = IniFile.ReadBool("Material", "ExpiryForbidContinue", false);
            Material_Life_Multiplier = IniFile.ReadInteger("Material", "LifeMultiplier", 1);
            Material_ExpiryPreAlertTime = IniFile.ReadInteger("Material", "ExpiryPreAlertTime", 0);

            Option_EnableMaterialLow = IniFile.ReadBool("Option", "EnableMaterialLow", false);
            Option_EnableDualMaterial = IniFile.ReadBool("Option", "EnableDualMaterial", false);
            MaterialLowForbidContinue = IniFile.ReadBool("Option", "MaterialLowForbidContinue", false);
            Option_ShrinkLast2CLine = IniFile.ReadDouble("Option", "ShrinkLast2CLine", 0);
            Option_ExtendLastCLine = IniFile.ReadDouble("Option", "ExtendLastCLine", 0);
            Option_CLineSpeedRatio = IniFile.ReadDouble("Option", "CLineSpeedRatio", 1);

            Material.EnableUnitCounter = IniFile.ReadBool("Material", "EnableUnitCounter", false);
            Material.Unit.Limit[0] = IniFile.ReadInteger("Material", "UnitLimit0", 0);
            Material.Unit.Limit[1] = IniFile.ReadInteger("Material", "UnitLimit1", 0);

            CopyLogToServer = IniFile.ReadBool("Log", "CopyToServer", false);
            LogServerPath = IniFile.ReadString("Log", "ServerPath", LogServerPath);

            VolumeOfst_Protocol = (TaskDisp.EVolumeOfstProtocol)IniFile.ReadInteger("VolumeOfst", "Protocol", 0);
            VolumeOfst_EqID = IniFile.ReadString("VolumeOfst", "EqID", "EqID");
            VolumeOfst_LocalPath = IniFile.ReadString("VolumeOfst", "LocalPath", "c:\\VolumeOfst");
            VolumeOfst_DataPath = IniFile.ReadString("VolumeOfst", "DataPath", "c:\\VolumeOfst\\DataPath");
            VolumeOfst_DataPath2 = IniFile.ReadString("VolumeOfst", "DataPath2", "c:\\VolumeOfst\\DataPath2");

            InputMap_Protocol = (EInputMapProtocol)IniFile.ReadInteger("InputMap", "Protocol", 0);

            if (InputMap_Protocol == EInputMapProtocol.Lumileds_EMap)
            {
                Task_InputMap.Lumileds_SS_EMap.LoadSetup();
            }
            if (InputMap_Protocol == EInputMapProtocol.OSRAM_eMos) Task_InputMap.OsramEMos.LoadSetup();

            Preference = EPreference.None;
            try { Preference = (EPreference)IniFile.ReadInteger("Setting", "Preference", 0); } catch { };
            CustomPath = IniFile.ReadString("Setting", "CustomPath", "");

            EnableRecipeFile = IniFile.ReadBool("Setting", "EnableRecipeFile", false);

            string s = IniFile.ReadString("SECSGEM", "Protocol", ESECSGEMProtocol.None.ToString());
            Enum.TryParse(s, out SECSGEMProtocol);

            GDefine.sgc2.EnableSECSGEMConnect2 = IniFile.ReadBool("sgc2", "EnableSECSGEMConnect2", false);
            GDefine.sgc2.EnableAlarm = IniFile.ReadBool("sgc2", "EnableAlarm", false);
            GDefine.sgc2.EnableEvent = IniFile.ReadBool("sgc2", "EnableEvent", false);
            GDefine.sgc2.EnableRMS = IniFile.ReadBool("sgc2", "EnableRMS", false);
            GDefine.sgc2.TimeOut = IniFile.ReadInteger("sgc2", "TimeOut", 30000);

            GDefine.sgc2.EnableDnloadStripMapE142 = IniFile.ReadBool("sgc2", "EnableDnloadStripMapE142", false);
            s = IniFile.ReadString("sgc2", "StripMapDnloadFlip", SECSGEMConnect2.EStripMapFlip.Normal.ToString());
            Enum.TryParse(s, out GDefine.sgc2.StripMapDnloadFlip);
            GDefine.sgc2.EnableUploadStripMapE142 = IniFile.ReadBool("sgc2", "EnableUploadStripMapE142", false);
            s = IniFile.ReadString("sgc2", "StripMapUploadFlip", SECSGEMConnect2.EStripMapFlip.Normal.ToString());
            Enum.TryParse(s, out GDefine.sgc2.StripMapUploadFlip);

            TaskDispCtrl.DispFuncs.Load();
            Pump.Action.Load();
            PurgeStage.LoadSetup();
            WipeStage.LoadSetup();
        }
        public static void SaveSetup()
        {
            string Filename = GDefine.SetupPath + "\\Disp.Setup.ini";
            //NSW.Net.IniFile IniFile = new NSW.Net.IniFile(Filename);
            //IniFile.Create(Filename);
            NUtils.IniFile IniFile = new NUtils.IniFile(Filename);

            IniFile.WriteDouble("Gantry", "ZDefPos", ZDefPos);

            #region Camera Cal Pos
            IniFile.WriteDouble("Camera", "Cal_Pos_X", Camera_Cal_Pos.X);
            IniFile.WriteDouble("Camera", "Cal_Pos_Y", Camera_Cal_Pos.Y);
            IniFile.WriteDouble("Camera", "Cal_Pos_X_Setup", Camera_Cal_Pos_Setup.X);
            IniFile.WriteDouble("Camera", "Cal_Pos_Y_Setup", Camera_Cal_Pos_Setup.Y);
            IniFile.WriteDouble("Camera", "Cal_Pos_Tol", Camera_Cal_Pos_Tol);
            IniFile.WriteDouble("Camera", "Cal_Needle1_Z", Camera_Cal_Needle1_Z);
            IniFile.WriteDouble("Camera", "Cal_Needle2_Z", Camera_Cal_Needle2_Z);
            IniFile.WriteInteger("Camera", "Cal_LightRGB_R", Camera_Cal_LightRGB.R);
            IniFile.WriteInteger("Camera", "Cal_LightRGB_G", Camera_Cal_LightRGB.G);
            IniFile.WriteInteger("Camera", "Cal_LightRGB_B", Camera_Cal_LightRGB.B);
            IniFile.WriteInteger("Camera", "Cal_LightRGB_A", Camera_Cal_LightRGB.A);

            IniFile.WriteDouble("BCamera", "Cal_Pos_X", BCamera_Cal_Pos.X);
            IniFile.WriteDouble("BCamera", "Cal_Pos_Y", BCamera_Cal_Pos.Y);
            IniFile.WriteDouble("BCamera", "Cal_Pos_X_Setup", BCamera_Cal_Pos_Setup.X);
            IniFile.WriteDouble("BCamera", "Cal_Pos_Y_Setup", BCamera_Cal_Pos_Setup.Y);
            IniFile.WriteDouble("BCamera", "Cal_Needle1_Z", BCamera_Cal_Needle1_Z);
            IniFile.WriteDouble("BCamera", "Cal_Needle2_Z", BCamera_Cal_Needle2_Z);
            IniFile.WriteInteger("BCamera", "Cal_LightRGB_R", BCamera_Cal_LightRGB.R);
            IniFile.WriteInteger("BCamera", "Cal_LightRGB_G", BCamera_Cal_LightRGB.G);
            IniFile.WriteInteger("BCamera", "Cal_LightRGB_B", BCamera_Cal_LightRGB.B);
            IniFile.WriteInteger("BCamera", "Cal_LightRGB_A", BCamera_Cal_LightRGB.A);
            IniFile.WriteInteger("BCamera", "CalNeedle_LightRGB_R", BCamera_CalNeedle_LightRGB.R);
            IniFile.WriteInteger("BCamera", "CalNeedle_LightRGB_G", BCamera_CalNeedle_LightRGB.G);
            IniFile.WriteInteger("BCamera", "CalNeedle_LightRGB_B", BCamera_CalNeedle_LightRGB.B);
            IniFile.WriteInteger("BCamera", "CalNeedle_LightRGB_A", BCamera_CalNeedle_LightRGB.A);

            IniFile.WriteDouble("Camera", "ZSensor_X", Camera_ZSensor_Pos.X);
            IniFile.WriteDouble("Camera", "ZSensor_Y", Camera_ZSensor_Pos.Y);
            IniFile.WriteInteger("Camera", "ZSensor_LightRGB_R", Camera_ZSensor_LightRGB.R);
            IniFile.WriteInteger("Camera", "ZSensor_LightRGB_G", Camera_ZSensor_LightRGB.G);
            IniFile.WriteInteger("Camera", "ZSensor_LightRGB_B", Camera_ZSensor_LightRGB.B);
            IniFile.WriteInteger("Camera", "ZSensor_LightRGB_A", Camera_ZSensor_LightRGB.A);
            IniFile.WriteInteger("Camera", "LaserOfst_LightRGB_R", Camera_LaserOfst_LightRGB.R);
            IniFile.WriteInteger("Camera", "LaserOfst_LightRGB_G", Camera_LaserOfst_LightRGB.G);
            IniFile.WriteInteger("Camera", "LaserOfst_LightRGB_B", Camera_LaserOfst_LightRGB.B);
            IniFile.WriteInteger("Camera", "LaserOfst_LightRGB_A", Camera_LaserOfst_LightRGB.A);
            IniFile.WriteInteger("Camera", "TouchDot_LightRGB_R", Camera_TouchDot_LightRGB.R);
            IniFile.WriteInteger("Camera", "TouchDot_LightRGB_G", Camera_TouchDot_LightRGB.G);
            IniFile.WriteInteger("Camera", "TouchDot_LightRGB_B", Camera_TouchDot_LightRGB.B);
            IniFile.WriteInteger("Camera", "TouchDot_LightRGB_A", Camera_TouchDot_LightRGB.A);
            IniFile.WriteInteger("Camera", "TouchDotSet_LightRGB_R", Camera_TouchDotSet_LightRGB.R);
            IniFile.WriteInteger("Camera", "TouchDotSet_LightRGB_G", Camera_TouchDotSet_LightRGB.G);
            IniFile.WriteInteger("Camera", "TouchDotSet_LightRGB_B", Camera_TouchDotSet_LightRGB.B);
            IniFile.WriteInteger("Camera", "TouchDotSet_LightRGB_A", Camera_TouchDotSet_LightRGB.A);
            #endregion

            #region Head Cal Pos
            for (int i = 0; i < MAX_HEADCOUNT; i++)
            {
                IniFile.WriteDouble("Head" + i.ToString(), "ZSensor_RefPos_Z", Head_ZSensor_RefPosZ[i]);
                IniFile.WriteDouble("Head" + i.ToString(), "ZSensor_RefPos_Z_Setup", Head_ZSensor_RefPosZ_Setup[i]);
            }
            IniFile.WriteDouble("Head", "ZSensor_RefPos_Z_Tol", Head_ZSensor_RefPosZ_Tol);

            for (int i = 0; i < MAX_HEADCOUNT; i++)
            {
                IniFile.WriteDouble("Head" + i.ToString(), "Ofst_X", Head_Ofst[i].X);
                IniFile.WriteDouble("Head" + i.ToString(), "Ofst_Y", Head_Ofst[i].Y);
                IniFile.WriteDouble("Head" + i.ToString(), "Ofst_Z", Head_Ofst[i].Z);
                //IniFile.WriteDouble("Head" + i.ToString(), "Ofst_X_Setup", Head_Ofst_Setup[i].X);
                //IniFile.WriteDouble("Head" + i.ToString(), "Ofst_Y_Setup", Head_Ofst_Setup[i].Y);
                //IniFile.WriteDouble("Head" + i.ToString(), "Ofst_Z_Setup", Head_Ofst_Setup[i].Z);
            }
            IniFile.WriteDouble("Head", "Ofst_XY_Tol", Head_Ofst_XY_Tol);
            IniFile.WriteDouble("Head", "Ofst_Z_Tol", Head_Ofst_Z_Tol);

            IniFile.WriteDouble("Head2", "Ofst_X", Head2_DefDistX);
            IniFile.WriteDouble("Head2", "DefPos_X", Head2_DefPos.X);
            IniFile.WriteDouble("Head2", "DefPos_Y", Head2_DefPos.Y);
            //IniFile.WriteDouble("Head2", "MinDist_X", Head2_MinDistX);

            IniFile.WriteDouble("Head2", "XOffset", Head2_XOffset);
            IniFile.WriteDouble("Head2", "YOffset", Head2_YOffset);
            IniFile.WriteDouble("Head2", "ZOffset", Head2_ZOffset);

            //IniFile.WriteDouble("Head", "ZComp_Y_Dist", Head_ZComp_Y_Dist);
            //IniFile.WriteDouble("Head", "ZComp_Y_ZOffset", Head_ZComp_Y_ZOffset);
            #endregion

            #region Laser Pos
            IniFile.WriteDouble("Laser", "Ofst_X", Laser_Ofst.X);
            IniFile.WriteDouble("Laser", "Ofst_Y", Laser_Ofst.Y);
            IniFile.WriteDouble("Laser", "Ofst_X_Setup", Laser_Ofst_Setup.X);
            IniFile.WriteDouble("Laser", "Ofst_Y_Setup", Laser_Ofst_Setup.Y);
            IniFile.WriteDouble("Laser", "Ofst_XY_Tol", Laser_Ofst_XY_Tol);
            IniFile.WriteDouble("Laser", "RefPos_Z", Laser_RefPosZ);
            IniFile.WriteDouble("Laser", "CalValue", Laser_CalValue);
            #endregion

            IniFile.WriteDouble("SP", "IntPulseOnDelay", DispProg.SP.IntPulseOnDelay[0]);
            IniFile.WriteDouble("SP", "IntPulseOffDelay", DispProg.SP.IntPulseOffDelay[0]);

            IniFile.WriteInteger("Vermes_0", "TempOfst", TaskDisp.Vermes3200[0].Heater.SetTemp);
            IniFile.WriteInteger("Vermes_1", "TempOfst", TaskDisp.Vermes3200[1].Heater.SetTemp);

            IniFile.WriteDouble("TempSensor", "Cal_Pos_X", TempSensor_Cal_Pos.X);
            IniFile.WriteDouble("TempSensor", "Cal_Pos_Y", TempSensor_Cal_Pos.Y);
            IniFile.WriteDouble("TempSensor", "Ofst_X", TempSensor_Ofst.X);
            IniFile.WriteDouble("TempSensor", "Ofst_Y", TempSensor_Ofst.Y);
            IniFile.WriteInteger("Camera", "TempSensor_LightRGB_R", TempSensor_Cal_LightRGB.R);
            IniFile.WriteInteger("Camera", "TempSensor_LightRGB_G", TempSensor_Cal_LightRGB.G);
            IniFile.WriteInteger("Camera", "TempSensor_LightRGB_B", TempSensor_Cal_LightRGB.B);
            IniFile.WriteInteger("Camera", "TempSensor_LightRGB_A", TempSensor_Cal_LightRGB.A);

            IniFile.WriteDouble("Aperture", "Dia", Aperture_Dia);
            IniFile.WriteDouble("Aperture", "Dia_Setup", Aperture_Dia_Setup);
            IniFile.WriteDouble("Aperture", "Dia_Tol", Aperture_Dia_Tol);

            #region needle Clean
            //for (int i = 0; i < MAX_HEADCOUNT; i++)
            //{
            //    IniFile.WriteDouble("Needle" + i.ToString(), "CleanPos_X", Needle_Clean_Pos[i].X);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "CleanPos_Y", Needle_Clean_Pos[i].Y);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "CleanPos_Z", Needle_Clean_Pos[i].Z);

            //    IniFile.WriteDouble("Needle" + i.ToString(), "PurgePos_X", Needle_Purge_Pos[i].X);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "PurgePos_Y", Needle_Purge_Pos[i].Y);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "PurgePos_Z", Needle_Purge_Pos[i].Z);

            //    IniFile.WriteDouble("Needle" + i.ToString(), "FlushPos_X", Needle_Flush_Pos[i].X);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "FlushPos_Y", Needle_Flush_Pos[i].Y);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "FlushPos_Z", Needle_Flush_Pos[i].Z);
            //}
            //IniFile.WriteInteger("NeedleClean", "UsePos", Needle_Clean_UsePos);
            //IniFile.WriteInteger("NeedleClean", "Time", Needle_Clean_Time);
            //IniFile.WriteInteger("NeedleClean", "Wait", Needle_Clean_Wait);
            //IniFile.WriteInteger("NeedleClean", "Count", Needle_Clean_Count);
            //IniFile.WriteInteger("NeedleClean", "PostVacTime", Needle_Clean_PostVacTime);

            ////IniFile.WriteBool("NeedlePurge", "UseCleanPos", Needle_Purge_UseCleanPos);
            //IniFile.WriteInteger("NeedlePurge", "UsePos", Needle_Purge_UsePos);
            //IniFile.WriteInteger("NeedlePurge", "Time", Needle_Purge_Time);
            //IniFile.WriteInteger("NeedlePurge", "Wait", Needle_Purge_Wait);
            //IniFile.WriteInteger("NeedlePurge", "Count", Needle_Purge_Count);
            //IniFile.WriteInteger("NeedlePurge", "PostVacTime", Needle_Purge_PostVacTime);

            //IniFile.WriteInteger("NeedleFlush", "UsePos", Needle_Flush_UsePos);
            //IniFile.WriteInteger("NeedleFlush", "Time", Needle_Flush_Time);
            //IniFile.WriteInteger("NeedleFlush", "Wait", Needle_Flush_Wait);
            //IniFile.WriteInteger("NeedleFlush", "Count", Needle_Flush_Count);
            //IniFile.WriteInteger("NeedleFlush", "PostVacTime", Needle_Flush_PostVacTime);
            #endregion

            IniFile.WriteInteger("Idle", "TimeToIdle", Idle_TimeToIdle);
            IniFile.WriteInteger("Idle", "PurgeDuration", Idle_PurgeDuration);
            IniFile.WriteInteger("Idle", "PostVacTime", Idle_PostVacTime);
            IniFile.WriteInteger("Idle", "PurgeInterval", Idle_PurgeInterval);

            #region Needle PreDisp
            //for (int i = 0; i < MAX_HEADCOUNT; i++)
            //{
            //    IniFile.WriteDouble("Needle" + i.ToString(), "PreDispPos_X", Needle_PreDisp_Pos[i].X);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "PreDispPos_Y", Needle_PreDisp_Pos[i].Y);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "PreDispPos_Z", Needle_PreDisp_Pos[i].Z);
            //}
            //IniFile.WriteInteger("NeedlePreDisp", "Time", Needle_PreDisp_Time);
            #endregion

            #region Needle Weight
            //for (int i = 0; i < MAX_HEADCOUNT; i++)
            //{
            //    IniFile.WriteDouble("Needle" + i.ToString(), "WeightPos_X", Needle_Weight_Pos[i].X);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "WeightPos_Y", Needle_Weight_Pos[i].Y);
            //    IniFile.WriteDouble("Needle" + i.ToString(), "WeightPos_Z", Needle_Weight_Pos[i].Z);
            //}
            //IniFile.WriteString("Weight", "ProgramName", WeightProgramName);
            for (int i = 0; i < 2; i++)
            {
                IniFile.WriteString("Weight", "ProgramName" + i.ToString(), WeightProgramName[i]);
                IniFile.WriteInteger("Weight", "ProgramHead" + i.ToString(), (int)WeightProgramHead[i]);
            }
            #endregion
            #region Needle Maint
            for (int i = 0; i < MAX_HEADCOUNT; i++)
            {
                IniFile.WriteDouble("Needle" + i.ToString(), "MaintPos_X", Needle_Maint_Pos[i].X);
                IniFile.WriteDouble("Needle" + i.ToString(), "MaintPos_Y", Needle_Maint_Pos[i].Y);
                IniFile.WriteDouble("Needle" + i.ToString(), "MaintPos_Z", Needle_Maint_Pos[i].Z);

                IniFile.WriteDouble("Machine" + i.ToString(), "MaintPos_X", Machine_Maint_Pos[i].X);
                IniFile.WriteDouble("Machine" + i.ToString(), "MaintPos_Y", Machine_Maint_Pos[i].Y);
                IniFile.WriteDouble("Machine" + i.ToString(), "MaintPos_Z", Machine_Maint_Pos[i].Z);
            }
            #endregion

            IniFile.WriteInteger("Maint", "FillCountLimit0", Maint.PP.FillCountLimit[0]);
            IniFile.WriteInteger("Maint", "FillCountLimit1", Maint.PP.FillCountLimit[1]);
            IniFile.WriteInteger("Maint", "UnitLimit0", Maint.Disp.CountLimit[0]);
            IniFile.WriteInteger("Maint", "UnitLimit1", Maint.Disp.CountLimit[1]);

            IniFile.WriteInteger("TeachNeedle", "Method", (int)TeachNeedle_Method);
            IniFile.WriteBool("TeachNeedle", "PromptOnLotStart", TeachNeedle_PromptOnLotStart);
            IniFile.WriteDouble("TeachNeedle", "ZOfst", TeachNeedle_ZOfst);
            IniFile.WriteInteger("TeachNeedle", "DownTime", TeachNeedle_WaitTime);

            IniFile.WriteDouble("TeachNeedle", "NeedleGap", TeachNeedle_NeedleGap);
            IniFile.WriteInteger("TeachNeedle", "DotTime", TeachNeedle_DotTime);
            IniFile.WriteDouble("TeachNeedle", "DotVolume", TeachNeedle_DotVolume);

            IniFile.WriteBool("TeachNeedle", "LaserPromptCleanStage", TeachNeedle_LaserPromptCleanStage);
            IniFile.WriteDouble("TeachNeedle", "LaserChangeRate", TeachNeedle_LaserChangeRate);
            IniFile.WriteBool("TeachNeedle", "DotPromptCleanStage", TeachNeedle_DotPromptCleanStage);
            //IniFile.WriteDouble("TeachNeedle", "CleanStageClearDist", TeachNeedle_CleanStageClearDist);
            IniFile.WriteDouble("TeachNeedle", "CleanStage_Pos_X", TeachNeedle_CleanStage_Pos.X);
            IniFile.WriteDouble("TeachNeedle", "CleanStage_Pos_Y", TeachNeedle_CleanStage_Pos.Y);

            IniFile.WriteDouble("MultiHead", "XYTol", MultiHead_XYTol);
            IniFile.WriteDouble("MultiHead", "ZTol", MultiHead_ZTol);
            IniFile.WriteBool("TeachNeedle", "ForceInTol", TeachNeedle_ForceInTol);

            IniFile.WriteInteger("TeachNeedle", "ZTouchDetectMethod", (int)TeachNeedle_ZTouchDetectMethod);

            IniFile.WriteInteger("Head1", "CtrlNo", Head1_CtrlNo);
            IniFile.WriteInteger("Head1", "CtrlHeadNo", Head1_CtrlHeadNo);
            IniFile.WriteInteger("Head2", "CtrlNo", Head2_CtrlNo);
            IniFile.WriteInteger("Head2", "CtrlHeadNo", Head2_CtrlHeadNo);

            IniFile.WriteInteger("DispTool", "CleanFillCount", DispTool_CleanFillCount);
            IniFile.WriteInteger("DispTool", "PurgeShotCount", DispTool_PurgeShotCount);
            IniFile.WriteDouble("DispTool", "BarrelPressTime", DispTool_BarrelPressTime);
            IniFile.WriteInteger("DispTool", "RecycleBarrelCount", DispTool_RecycleBarrelCount);
            IniFile.WriteDouble("DispTool", "RemoveAirTime", DispTool_RemoveAirTime);
            IniFile.WriteInteger("DispTool", "RecycleNeedleCount", DispTool_RecycleNeedleCount);
            IniFile.WriteDouble("DispTool", "RecycleNeedleVolume", DispTool_RecycleNeedleVolume);

            IniFile.WriteBool("Option", "EnableRunSingleHead", Option_EnableRunSingleHead);
            IniFile.WriteBool("Option", "PromptRunSingleHead", Option_PromptRunSingleHead);
            IniFile.WriteBool("Option", "EnableChuckVac", Option_EnableChuckVac);

            IniFile.WriteBool("Option", "EnableDrawOfstAdjust", Option_EnableDrawOfstAdjust);
            IniFile.WriteDouble("Option", "DrawOfstAdjustLimit_XY", Option_DrawOfstAdjustLimit_XY);
            IniFile.WriteDouble("Option", "DrawOfstAdjustLimit_Z", Option_DrawOfstAdjustLimit_Z);
            IniFile.WriteDouble("Option", "Option_DrawOfstAdjustRate", Option_DrawOfstAdjustRate);
            
            IniFile.WriteBool("Option", "EnableStartIdle", Option_EnableStartIdle);
            IniFile.WriteInteger("Option", "IdlePurgeTimer", Option_IdlePurgeTimer);
            IniFile.WriteBool("Option", "EnableScriptCheck", Option_EnableScriptCheck);
            IniFile.WriteBool("Option", "EnableScriptCheckUnitMode", Option_EnableScriptCheckUnitMode);
            IniFile.WriteBool("Option", "EnableRealTimeFineTune", Option_EnableRealTimeFineTune);

            IniFile.WriteBool("Option", "HideHPCManualControls", Option_HideHPCManualControls);
            IniFile.WriteDouble("Option", "XYShortDist", Option_XYShortDist);
            IniFile.WriteDouble("Option", "XYShortDistPeakSpeedRatio", Option_XYShortDistPeakSpeedRatio);

            IniFile.WriteInteger("Option", "VolumeDisplayDecimalPoint", Option_VolumeDisplayDecimalPoint);

            IniFile.WriteBool("Material", "EnableTimer", Material_EnableTimer);
            IniFile.WriteInteger("Material", "LifeMultiplier", Material_Life_Multiplier);
            IniFile.WriteBool("Material", "ExpiryForbidContinue", MaterialExpiryForbidContinue);
            IniFile.WriteInteger("Material", "ExpiryPreAlertTime", Material_ExpiryPreAlertTime);

            IniFile.WriteBool("Option", "EnableMaterialLow", Option_EnableMaterialLow);
            IniFile.WriteBool("Option", "EnableDualMaterial", Option_EnableDualMaterial);
            IniFile.WriteBool("Option", "MaterialExpiryForbidContinue", MaterialExpiryForbidContinue);
            IniFile.WriteDouble("Option", "ShrinkLast2CLine", Option_ShrinkLast2CLine);
            IniFile.WriteDouble("Option", "ExtendLastCLine", Option_ExtendLastCLine);
            IniFile.WriteDouble("Option", "CLineSpeedRatio", Option_CLineSpeedRatio);

            IniFile.WriteBool("Material", "EnableUnitCounter", Material.EnableUnitCounter);
            IniFile.WriteInteger("Material", "UnitLimit0", Material.Unit.Limit[0]);
            IniFile.WriteInteger("Material", "UnitLimit1", Material.Unit.Limit[1]);

            IniFile.WriteBool("Log", "CopyToServer", CopyLogToServer);
            IniFile.WriteString("Log", "ServerPath", LogServerPath);

            IniFile.WriteInteger("VolumeOfst", "Protocol", (int)VolumeOfst_Protocol);
            IniFile.WriteString("VolumeOfst", "EqID", VolumeOfst_EqID);
            IniFile.WriteString("VolumeOfst", "LocalPath", VolumeOfst_LocalPath);
            IniFile.WriteString("VolumeOfst", "DataPath", VolumeOfst_DataPath);
            IniFile.WriteString("VolumeOfst", "DataPath2", VolumeOfst_DataPath2);

            IniFile.WriteInteger("InputMap", "Protocol", (int)InputMap_Protocol);

            if (InputMap_Protocol == EInputMapProtocol.Lumileds_EMap)
            {
                Task_InputMap.Lumileds_SS_EMap.SaveSetup();
            }

            IniFile.WriteInteger("Setting", "Preference", (int)Preference);
            IniFile.WriteString("Setting", "CustomPath", CustomPath);

            IniFile.WriteBool("Setting", "EnableRecipeFile", EnableRecipeFile);

            IniFile.WriteString("SECSGEM", "Protocol", SECSGEMProtocol.ToString());

            IniFile.WriteBool("sgc2", "EnableSECSGEMConnect2", GDefine.sgc2.EnableSECSGEMConnect2);
            IniFile.WriteBool("sgc2", "EnableAlarm", GDefine.sgc2.EnableAlarm);
            IniFile.WriteBool("sgc2", "EnableEvent", GDefine.sgc2.EnableEvent);
            IniFile.WriteBool("sgc2", "EnableRMS", GDefine.sgc2.EnableRMS);
            IniFile.WriteInteger("sgc2", "TimeOut", GDefine.sgc2.TimeOut);

            IniFile.WriteBool("sgc2", "EnableDnloadStripMapE142", GDefine.sgc2.EnableDnloadStripMapE142);
            IniFile.WriteString("sgc2", "StripMapDnloadFlip", GDefine.sgc2.StripMapDnloadFlip.ToString());
            IniFile.WriteBool("sgc2", "EnableUploadStripMapE142", GDefine.sgc2.EnableUploadStripMapE142);
            IniFile.WriteString("sgc2", "StripMapUploadFlip", GDefine.sgc2.StripMapUploadFlip.ToString());

            TaskDispCtrl.DispFuncs.Save();
            PurgeStage.SaveSetup();
            WipeStage.SaveSetup();
        }

        public static double Head_PitchX
        {
            get
            {
                if (DispProg.Head_PitchX < 0)
                {
                    return Head_LastPitchX;
                }
                else
                    if (DispProg.Head_PitchX == 0)
                {
                    Head_LastPitchX = DispProg.rt_Layouts[0].HeadPitch;
                    return DispProg.rt_Layouts[0].HeadPitch;
                }
                else
                {
                    Head_LastPitchX = DispProg.Head_PitchX;
                    return DispProg.Head_PitchX;
                }
            }
        }
        public static double Head_NeedlePitchY
        {
            get
            {
                if (DispProg.Head_NeedlePitchY == 0)
                {
                    Head_LastNeedlePitchY = DispProg.rt_Layouts[0].NeedlePitch;
                    return DispProg.rt_Layouts[0].NeedlePitch;
                }
                else
                {
                    Head_LastNeedlePitchY = DispProg.Head_NeedlePitchY;
                    return DispProg.Head_NeedlePitchY;
                }
            }
        }

        public static void PP_SetWeight(double[] Weight, bool Disp, bool PromptError)
        {
            switch (DispProg.Pump_Type)
            {
                case EPumpType.PP:
                case EPumpType.PP2D:
                case EPumpType.PPD:
                    {
                        if (TaskWeight.CurrentCal[0] <= 0 || TaskWeight.CurrentCal[1] <= 0)
                        {
                            throw new Exception("Weight Not Calibrated.");
                        }

                        try
                        {
                            if (Disp)
                            {
                                DispProg.Disp_Weight[0] = Weight[0];
                                DispProg.Disp_Weight[1] = Weight[1];
                            }

                            double VolA = Weight[0] / TaskWeight.CurrentCal[0];
                            DispProg.PP_HeadA_DispBaseVol = VolA + DispProg.PP_HeadA_BackSuckVol;
                            double VolB = Weight[1] / TaskWeight.CurrentCal[1];
                            DispProg.PP_HeadB_DispBaseVol = VolB + DispProg.PP_HeadB_BackSuckVol;
                        }
                        catch
                        {
                            throw;
                        }

                        break;
                    }
            }

            if (!TaskDisp.SetDispVolume(
            true, true,
                DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj + DispProg.rt_Head1VolumeOfst,
                DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj + DispProg.rt_Head2VolumeOfst))
            {
                throw new Exception("Set Volume Error");
            }

        }

        public enum ECalHeadOffsetMethod
        {
            CrossHair = 0,
            BCamera = 2,
        }
        public static bool CalHeadOffset(ECalHeadOffsetMethod Type)
        {
            string s_Type = Enum.GetName(typeof(ECalHeadOffsetMethod), (int)Type).ToString();
            string EMsg = "CalHeadOffset_" + s_Type;

            Event.TEACH_NEEDLE_OFST.Set("Type", s_Type);

            double Cal_Pos_X = Camera_Cal_Pos.X;
            double Cal_Pos_Y = Camera_Cal_Pos.Y;
            TLightRGBA LightRGB_TopCamera = new TLightRGBA(25, 25, 25, 0);
            TLightRGBA LightRGB_Needle = new TLightRGBA(25, 25, 25, 0);
            switch (Type)
            {
                case ECalHeadOffsetMethod.BCamera:
                    Cal_Pos_X = BCamera_Cal_Pos.X;
                    Cal_Pos_Y = BCamera_Cal_Pos.Y;
                    LightRGB_TopCamera = BCamera_Cal_LightRGB;
                    LightRGB_Needle = BCamera_CalNeedle_LightRGB;
                    break;
                //case ECalHeadOffsetMethod.ZSensor:
                //    Cal_Pos_X = Camera_ZSensor_Pos.X;
                //    Cal_Pos_Y = Camera_ZSensor_Pos.Y;
                //    LightRGB = Camera_ZSensor_LightRGB;
                //    break;
                default://ECalHeadOffsetMethod.CrossHair:
                    Cal_Pos_X = Camera_Cal_Pos.X;
                    Cal_Pos_Y = Camera_Cal_Pos.Y;
                    LightRGB_TopCamera = Camera_Cal_LightRGB;
                    LightRGB_Needle = BCamera_CalNeedle_LightRGB;
                    break;
            }
            Cal_Pos_X = Cal_Pos_X + Head_Ofst[0].X;
            Cal_Pos_Y = Cal_Pos_Y + Head_Ofst[0].Y;

            if (Cal_Pos_X < TaskGantry.GXAxis.Para.SwLimit.PosN || Cal_Pos_X > TaskGantry.GXAxis.Para.SwLimit.PosP ||
              Cal_Pos_Y < TaskGantry.GYAxis.Para.SwLimit.PosN || Cal_Pos_Y > TaskGantry.GYAxis.Para.SwLimit.PosP)
            {
                Cal_Pos_X = 0;
                Cal_Pos_Y = 0;
            }

            try
            {
                #region Move Head1 Needle XY to Cal Pos
                //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                //if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                //{
                //    if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                //    if (!TaskGantry.MoveGX2Y2MinDist(true)) return false;
                //}
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(Cal_Pos_X, Cal_Pos_Y)) return false;
                #endregion

                #region User Instruction: Move Z1 to Cal Pos
                TaskVision.LightingOn(LightRGB_Needle);

                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();
                double Z = TaskGantry.GZPos();

                switch (Type)
                {
                    default:
                        #region
                        {
                            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                            frm.Inst = "Jog XYZ to locate Head 1 Needle1 to " + s_Type + " Position";
                            frm.ShowVision = false;
                            DialogResult dr = frm.ShowDialog();
                            frm.ForceGantryMode = EForceGantryMode.None;

                            X = TaskGantry.GXPos();
                            Y = TaskGantry.GYPos();
                            Z = TaskGantry.GZPos();
                            //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                            //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                            if (!TaskDisp.TaskMoveGZFocus(0)) return false;
                            if (dr == DialogResult.Cancel)
                            {
                                return false;
                            }
                            break;
                        }
                    #endregion
                    case ECalHeadOffsetMethod.BCamera:
                        switch (GDefine.BottomCamType)
                        {
                            default:
                                #region
                                {
                                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                    frm.Inst = "Jog XYZ to locate Head 1 Needle1 to " + s_Type + " Position";
                                    frm.ShowVision = false;
                                    DialogResult dr = frm.ShowDialog();
                                    frm.ForceGantryMode = EForceGantryMode.None;

                                    X = TaskGantry.GXPos();
                                    Y = TaskGantry.GYPos();
                                    Z = TaskGantry.GZPos();
                                    //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                    //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                                    if (!TaskDisp.TaskMoveGZFocus(0)) return false;
                                    if (dr == DialogResult.Cancel)
                                    {
                                        return false;
                                    }
                                    break;
                                }
                            #endregion
                            case GDefine.EBottomCamType.ATNC:
                                #region
                                {
                                    if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Spinnaker)
                                    {
                                        //TaskVision.frmGenImageView.GrabStop();
                                        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam02);
                                        //TaskVision.frmGenImageView.Grab();
                                    }

                                    TaskVision.SelectedCam = ECamNo.Cam02;

                                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                    frm.Inst = "Jog XYZ to locate Head 1 Needle1 to " + s_Type + " Position";
                                    frm.ShowVision = true;
                                    TaskVision.FindCircle = 2;
                                    DialogResult dr = frm.ShowDialog();
                                    frm.ForceGantryMode = EForceGantryMode.None;
                                    TaskVision.FindCircle = 0;

                                    X = TaskGantry.GXPos();
                                    Y = TaskGantry.GYPos();
                                    Z = TaskGantry.GZPos();
                                    if (dr == DialogResult.Cancel)
                                    {
                                        return false;
                                    }

                                    _RetryNew:
                                    int RetryCount = 0;
                                    string ATNCMsg = "ATNC: BUSY";
                                    Color ATNCMsgColor = Color.Orange;
                                    _Retry:
                                    //int t = GDefine.GetTickCount() + 200;
                                    //while (GDefine.GetTickCount() < t) Thread.Sleep(0);
                                    if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Spinnaker)
                                    {
                                        //TaskVision.frmGenImageView.GrabStop();
                                        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam02);
                                        //TaskVision.frmGenImageView.Grab();
                                    }


                                    int t = GDefine.GetTickCount() + 200;
                                    while (GDefine.GetTickCount() < t)
                                    {
                                        Application.DoEvents();
                                        Thread.Sleep(5);
                                    }

                                    Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                                    //if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Basler)
                                    //{
                                    TaskVision.GrabN((int)ECamNo.Cam02, ref Image);
                                    //}

                                    PointF[] Center = new PointF[1024];
                                    float[] Radius = new float[1024];
                                    //int i_Circles = TaskVision.FindCircles(Image, true, ref Center, ref Radius);
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

                                        if (RetryCount < 3)
                                        {
                                            RetryCount++;
                                            goto _Retry;
                                        }
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
                                    frm = new frm_DispCore_JogGantryVision();
                                    frm.Inst = "Confirm Head 1 Needle1 XYZ to " + s_Type + " Position";
                                    frm.ShowVision = true;
                                    TaskVision.FindCircle = 2;
                                    TaskVision.TextString = ATNCMsg;
                                    TaskVision.TextColor = ATNCMsgColor;
                                    TaskVision.SelectedCam = ECamNo.Cam02;
                                    dr = frm.ShowDialog();
                                    frm.ForceGantryMode = EForceGantryMode.None;
                                    TaskVision.FindCircle = 0;

                                    X = TaskGantry.GXPos();
                                    Y = TaskGantry.GYPos();
                                    Z = TaskGantry.GZPos();
                                    if (dr == DialogResult.Retry)
                                    {
                                        goto _RetryNew;
                                    }
                                    if (dr == DialogResult.Cancel)
                                    {
                                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                        return false;
                                    }
                                    //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                    //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                                    if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                                    Aperture_Dia_Setup = Radius[0];
                                    Aperture_Dia = Aperture_Dia_Setup;
                                    break;
                                }
                                #endregion
                        }
                        break;
                }
                LightRGB_Needle = TaskVision.CurrentLightRGBA;
                #endregion

                #region User Instruction: Move Camera XY to Cal Pos
                //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(X - Head_Ofst[0].X, Y - Head_Ofst[0].Y)) return false;

                TaskVision.SelectedCam = ECamNo.Cam00;
                TaskVision.LightingOn(LightRGB_TopCamera);

                switch (Type)
                {
                    default:
                        #region
                        {
                            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                            frm.Inst = "Jog Camera to " + s_Type + " Position";
                            frm.ShowVision = true;
                            frm.ForceGantryMode = EForceGantryMode.XYZ;
                            DialogResult dr = frm.ShowDialog();
                            frm.ForceGantryMode = EForceGantryMode.None;

                            //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                            //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                            if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                            if (dr == DialogResult.Cancel)
                            {
                                return false;
                            }
                            break;
                        }
                    #endregion
                    case ECalHeadOffsetMethod.BCamera:
                        { 
                        MessageBox.Show("Function not Supported.");
                        //switch (GDefine.BottomCamType)
                        //{
                        //    default:
                        //        #region
                        //        {
                        //            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                        //            frm.Inst = "Jog Camera to " + s_Type + " Position";
                        //            frm.ShowVision = true;
                        //            frm.ForceGantryMode = EForceGantryMode.XYZ;
                        //            DialogResult dr = frm.ShowDialog();
                        //            frm.ForceGantryMode = EForceGantryMode.None;

                        //            //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                        //            //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                        //            if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                        //            if (dr == DialogResult.Cancel)
                        //            {
                        //                return false;
                        //            }
                        //            break;
                        //        }
                        //    #endregion
                        //    case GDefine.EBottomCamType.ATNC:
                                //#region
                                //{
                                //    if (GDefine.CameraType[(int)ECamNo.Cam00] == GDefine.ECameraType.Spinnaker)
                                //    {
                                //        //TaskVision.frmGenImageView.GrabStop();
                                //        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam00);
                                //        //TaskVision.frmGenImageView.Grab();
                                //        //TaskVision.frmGenImageView.Reticles.Clear();
                                //    }

                                //    TaskVision.SelectedCam = ECamNo.Cam00;
                                //    TaskVision.LightingOn(LightRGB_TopCamera);

                                //    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                //    frm.Inst = "Jog Camera to " + s_Type + " Position";
                                //    frm.ShowVision = true;
                                //    TaskVision.FindCircle = 1;
                                //    frm.ForceGantryMode = EForceGantryMode.XYZ;
                                //    DialogResult dr = frm.ShowDialog();
                                //    frm.ForceGantryMode = EForceGantryMode.None;
                                //    TaskVision.FindCircle = 0;

                                //    //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                //    //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                                //    if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                                //    if (dr == DialogResult.Cancel)
                                //    {
                                //        return false;
                                //    }
                                //    TaskDisp.BCamera_Cal_LightRGB = TaskVision.CurrentLightRGBA;

                                //    _RetryNew:
                                //    int RetryCount = 0;
                                //    string ATNCMsg = "ATNC: BUSY";
                                //    Color ATNCMsgColor = Color.Orange;
                                //    _Retry:
                                //    if (GDefine.CameraType[(int)ECamNo.Cam00] == GDefine.ECameraType.Spinnaker)
                                //    {
                                //        //TaskVision.frmGenImageView.GrabStop();
                                //        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam00);
                                //        //TaskVision.frmGenImageView.Grab();
                                //    }

                                //    int t = GDefine.GetTickCount() + 200;
                                //    while (GDefine.GetTickCount() < t) Thread.Sleep(0);

                                //    Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                                //    //if (GDefine.CameraType[(int)ECamNo.Cam00] == GDefine.ECameraType.Basler)
                                //    {
                                //        TaskVision.GrabN(0, ref Image);
                                //    }
                                //    if (GDefine.CameraType[(int)ECamNo.Cam00] == GDefine.ECameraType.PtGrey)
                                //    {
                                //        TaskVision.PtGrey_CamStop();
                                //        TaskVision.PtGrey_CamArm((int)ECamNo.Cam00);
                                //        TaskVision.PtGrey_CamTrig((int)ECamNo.Cam00);
                                //        TaskVision.PtGrey_CamImage((int)ECamNo.Cam00, ref Image);
                                //        TaskVision.PtGrey_CamLive((int)ECamNo.Cam00);
                                //    }


                                //    PointF Center = new PointF(0, 0);// new PointF[1024];
                                //    float Radius = 0f;// new float[1024];
                                //    //int i_Circles = TaskVision.FindCircles(Image, true, ref Center, ref Radius);
                                //    int i_Circles = TaskVision.FindAperture(Image, ref Center, ref Radius);

                                //    if (i_Circles > 0)
                                //    {
                                //        double OfstX = (Center.X - (double)(Image.Width / 2)) * TaskVision.DistPerPixelX[0];
                                //        double OfstY = (Center.Y - (double)(Image.Height / 2)) * TaskVision.DistPerPixelY[0];
                                //        OfstY = -OfstY;

                                //        double GX = TaskGantry.GXPos();
                                //        double GY = TaskGantry.GYPos();

                                //        if (Math.Abs(OfstX) < 0.015 && Math.Abs(OfstY) < 0.015)
                                //        {
                                //            ATNCMsg = "ATNC: OK";
                                //            ATNCMsgColor = Color.Lime;
                                //            goto _End;
                                //        }

                                //        if (!TaskGantry.SetMotionParamGXY()) return false;
                                //        if (!TaskGantry.MoveAbsGXY(GX + OfstX, GY + OfstY)) return false;

                                //        if (RetryCount < 3)
                                //        {
                                //            RetryCount++;
                                //            goto _Retry;
                                //        }
                                //        ATNCMsg = "ATNC ERROR: CORRECTION FAIL";
                                //        ATNCMsgColor = Color.Red;
                                //    }
                                //    ATNCMsg = "ATNC ERROR: APERTURE NOT FOUND";
                                //    ATNCMsgColor = Color.Red;
                                //    _End:
                                //    frm = new frm_DispCore_JogGantryVision();
                                //    frm.Inst = "Confirm Camera to " + s_Type + " Position";
                                //    frm.ShowVision = true;
                                //    TaskVision.FindCircle = 1;
                                //    TaskVision.TextString = ATNCMsg;
                                //    TaskVision.TextColor = ATNCMsgColor;
                                //    frm.ForceGantryMode = EForceGantryMode.XYZ;
                                //    dr = frm.ShowDialog();
                                //    frm.ForceGantryMode = EForceGantryMode.None;
                                //    TaskVision.FindCircle = 0;

                                //    //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                //    //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                                //    if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                                //    if (dr == DialogResult.Retry)
                                //    {
                                //        goto _RetryNew;
                                //    }
                                //    if (dr == DialogResult.Cancel)
                                //    {
                                //        return false;
                                //    }

                                //    break;
                                //}
                                //#endregion
                        //}
                        break;
                        }
                }

                LightRGB_TopCamera = TaskVision.CurrentLightRGBA;
                #endregion

                //TaskVision.LightingOn(TaskVision.DefLightRGB);
                #region Computate Head1 Values
                Cal_Pos_X = TaskGantry.GXPos();
                Cal_Pos_Y = TaskGantry.GYPos();
                TPos3[] _Head_Ofst = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
                switch (Type)
                {
                    case ECalHeadOffsetMethod.CrossHair:
                        Camera_Cal_Pos_Setup.X = TaskGantry.GXPos();
                        Camera_Cal_Pos_Setup.Y = TaskGantry.GYPos();
                        Camera_Cal_Pos.X = Camera_Cal_Pos_Setup.X;
                        Camera_Cal_Pos.Y = Camera_Cal_Pos_Setup.Y;
                        Camera_Cal_Needle1_Z = Z;
                        //Head_Ofst_Setup[0].X = X - Camera_Cal_Pos.X;
                        //Head_Ofst_Setup[0].Y = Y - Camera_Cal_Pos.Y;
                        //Head_Ofst[0].X = Head_Ofst_Setup[0].X;
                        //Head_Ofst[0].Y = Head_Ofst_Setup[0].Y;
                        _Head_Ofst[0].X = X - Camera_Cal_Pos.X;
                        _Head_Ofst[0].Y = Y - Camera_Cal_Pos.Y;
                        break;
                    case ECalHeadOffsetMethod.BCamera:
                        BCamera_Cal_Pos_Setup.X = TaskGantry.GXPos();
                        BCamera_Cal_Pos_Setup.Y = TaskGantry.GYPos();
                        BCamera_Cal_Pos.X = BCamera_Cal_Pos_Setup.X;
                        BCamera_Cal_Pos.Y = BCamera_Cal_Pos_Setup.Y;
                        BCamera_Cal_Needle1_Z = Z;
                        //Head_Ofst_Setup[0].X = X - BCamera_Cal_Pos.X;
                        //Head_Ofst_Setup[0].Y = Y - BCamera_Cal_Pos.Y;
                        //Head_Ofst[0].X = Head_Ofst_Setup[0].X;
                        //Head_Ofst[0].Y = Head_Ofst_Setup[0].Y;
                        _Head_Ofst[0].X = X - BCamera_Cal_Pos.X;
                        _Head_Ofst[0].Y = Y - BCamera_Cal_Pos.Y;
                        break;
                }

                Event.SETUP_HEAD1_OFST_UPDATE.Set("HeadOffset", Head_Ofst[0].X.ToString("f3") + "," + Head_Ofst[0].Y.ToString("f3"));
                if (TaskDisp.Head_Ofst_XY_Tol > 0)
                {
                    double deltaX = _Head_Ofst[0].X - Head_Ofst[0].X;
                    double deltaY = _Head_Ofst[0].Y - Head_Ofst[0].Y;
                    if (Math.Abs(deltaX) >= TaskDisp.Head_Ofst_XY_Tol || Math.Abs(deltaX) >= TaskDisp.Head_Ofst_XY_Tol)
                    {
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show("Head1 Offset Changes " + deltaX.ToString("f3") + "," + deltaY.ToString("f3") + " exceed tolerance.", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                        switch (MsgRes)
                        {
                            case EMsgRes.smrOK:
                                break;
                            case EMsgRes.smrCancel:
                                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                return false;
                        }
                    }
                }

                Head_Ofst[0].X = _Head_Ofst[0].X;
                Head_Ofst[0].Y = _Head_Ofst[0].Y;
                #endregion


                if (GDefine.GantryConfig == GDefine.EGantryConfig.XYZ && GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                {
                    TPos3 oldHead1_Ofst = new TPos3(Head_Ofst[1]);

                    #region Compute Head2 Values
                    double HeadPitchX = DispProg.Head_PitchX;
                    if (DispProg.Head_PitchX == 0) HeadPitchX = DispProg.rt_Layouts[0].HeadPitch;
                    //Head_Ofst_Setup[1].X = Head_Ofst[0].X - HeadPitchX;
                    //Head_Ofst_Setup[1].Y = Head_Ofst[0].Y;
                    //Head_Ofst[1].X = Head_Ofst_Setup[1].X;
                    //Head_Ofst[1].Y = Head_Ofst_Setup[1].Y;
                    _Head_Ofst[1].X = Head_Ofst[0].X - HeadPitchX;
                    _Head_Ofst[1].Y = Head_Ofst[0].Y;
                    #endregion

                    Head_Ofst[1].X = _Head_Ofst[1].X;
                    Head_Ofst[1].Y = _Head_Ofst[1].Y;

                    if (TaskDisp.Head_Ofst_XY_Tol > 0)
                    {
                        double deltaX = _Head_Ofst[1].X - Head_Ofst[1].X;
                        double deltaY = _Head_Ofst[1].Y - Head_Ofst[1].Y;
                        if (Math.Abs(deltaX) >= TaskDisp.Head_Ofst_XY_Tol || Math.Abs(deltaX) >= TaskDisp.Head_Ofst_XY_Tol)
                        {
                            Msg MsgBox = new Msg();
                            EMsgRes MsgRes = MsgBox.Show("Head2 Offset Changes " + deltaX.ToString("f3") + "," + deltaY.ToString("f3") + " exceed tolerance.", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                            switch (MsgRes)
                            {
                                case EMsgRes.smrOK:
                                    break;
                                case EMsgRes.smrCancel:
                                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                    return false;
                            }
                        }
                    }

                    Event.SETUP_HEAD2_OFST_UPDATE.Set("Head2Offset", Head_Ofst[1].X.ToString("f3") + "," + Head_Ofst[1].Y.ToString("f3"));
                }

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    #region Move Head2 XY to Cal Pos
                    //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                    if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                    if (!TaskGantry.SetMotionParamGXY()) return false;
                    if (!TaskGantry.MoveAbsGXY(Cal_Pos_X + Head_Ofst[0].X - Head2_DefDistX, Cal_Pos_Y + Head_Ofst[0].Y, false)) return false;
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGXY()) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                    #endregion

                    #region User Instruction: Move Z2 to Cal Pos
                    TaskVision.LightingOn(LightRGB_Needle);

                    double X2 = TaskGantry.GX2Pos();
                    double Y2 = TaskGantry.GY2Pos();
                    double Z2 = TaskGantry.GZ2Pos();

                    switch (Type)
                    {
                        default:
                            #region
                            {
                                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                frm.Inst = "Jog X2Y2Z2 to locate Head 2 Needle1 to " + s_Type + " Position";
                                frm.ShowVision = false;
                                frm.ForceGantryMode = EForceGantryMode.X2Y2Z2;
                                DialogResult dr = frm.ShowDialog();
                                frm.ForceGantryMode = EForceGantryMode.None;

                                X2 = TaskGantry.GX2Pos();
                                Y2 = TaskGantry.GY2Pos();
                                Z2 = TaskGantry.GZ2Pos();

                                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }
                                break;
                            }
                        #endregion
                        case ECalHeadOffsetMethod.BCamera:
                            switch (GDefine.BottomCamType)
                            {
                                default:
                                    #region
                                    {
                                        frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                        frm.Inst = "Jog X2Y2Z2 to locate Head 2 Needle1 to " + s_Type + " Position";
                                        frm.ShowVision = false;
                                        frm.ForceGantryMode = EForceGantryMode.X2Y2Z2;
                                        DialogResult dr = frm.ShowDialog();
                                        frm.ForceGantryMode = EForceGantryMode.None;

                                        X2 = TaskGantry.GX2Pos();
                                        Y2 = TaskGantry.GY2Pos();
                                        Z2 = TaskGantry.GZ2Pos();

                                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                        if (dr == DialogResult.Cancel)
                                        {
                                            return false;
                                        }
                                        break;
                                    }
                                #endregion
                                case GDefine.EBottomCamType.ATNC:
                                    #region
                                    {
                                        if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Spinnaker)
                                        {
                                            //TaskVision.frmGenImageView.GrabStop();
                                            //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam02);
                                            //TaskVision.frmGenImageView.Grab();
                                            //TaskVision.frmGenImageView.Reticles.Clear();
                                        }

                                        TaskVision.SelectedCam = ECamNo.Cam02;

                                        frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                        frm.Inst = "Jog X2Y2Z2 to locate Head 2 Needle1 to " + s_Type + " Position";
                                        frm.ShowVision = true;
                                        frm.ForceGantryMode = EForceGantryMode.X2Y2Z2;
                                        TaskVision.FindCircle = 2;
                                        DialogResult dr = frm.ShowDialog();
                                        frm.ForceGantryMode = EForceGantryMode.None;
                                        TaskVision.FindCircle = 0;

                                        X2 = TaskGantry.GX2Pos();
                                        Y2 = TaskGantry.GY2Pos();
                                        Z2 = TaskGantry.GZ2Pos();
                                        if (dr == DialogResult.Cancel)
                                        {
                                            return false;
                                        }

                                        _RetryNew:
                                        int RetryCount = 0;
                                        string ATNCMsg = "ATNC: BUSY";
                                        Color ATNCMsgColor = Color.Orange;
                                        _Retry:
                                        if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Spinnaker)
                                        {
                                            //TaskVision.frmGenImageView.GrabStop();
                                            //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam02);
                                            //TaskVision.frmGenImageView.Grab();
                                        }

                                        int t = GDefine.GetTickCount() + 200;
                                        while (GDefine.GetTickCount() < t) Thread.Sleep(0);

                                        Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                                        //if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Basler)
                                        {
                                            TaskVision.GrabN((int)ECamNo.Cam02, ref Image);
                                        }
                                        if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.PtGrey)
                                        {
                                            //TaskVision.PtGrey_CamStop();
                                            //TaskVision.PtGrey_CamArm((int)ECamNo.Cam02);
                                            //TaskVision.PtGrey_CamTrig((int)ECamNo.Cam02);
                                            //TaskVision.PtGrey_CamImage((int)ECamNo.Cam02, ref Image);
                                            //TaskVision.PtGrey_CamLive((int)ECamNo.Cam02);
                                        }


                                        PointF[] Center = new PointF[1024];
                                        float[] Radius = new float[1024];
                                        //int i_Circles = TaskVision.FindCircles(Image, true, ref Center, ref Radius);
                                        int i_Circles = TaskVision.FindApertureNeedle(Image, ref Center, ref Radius);

                                        if (i_Circles >= 2)
                                        {
                                            double OfstX = (Center[0].X - Center[1].X) * TaskVision.DistPerPixelX[2];
                                            double OfstY = (Center[0].Y - Center[1].Y) * TaskVision.DistPerPixelY[2];
                                            OfstY = -OfstY;

                                            double GX2 = TaskGantry.GX2Pos();
                                            double GY2 = TaskGantry.GY2Pos();

                                            if (Math.Abs(OfstX) < 0.015 && Math.Abs(OfstY) < 0.015)
                                            {
                                                ATNCMsg = "ATNC: OK";
                                                ATNCMsgColor = Color.Lime;
                                                goto _End;
                                            }

                                            if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                                            if (!TaskGantry.MoveAbsGX2Y2(GX2 + OfstX, GY2 + OfstY)) return false;

                                            if (RetryCount < 3)
                                            {
                                                RetryCount++;
                                                goto _Retry;
                                            }
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
                                        frm = new frm_DispCore_JogGantryVision();
                                        frm.Inst = "Confirm Head 2 Needle1 XYZ to " + s_Type + " Position";
                                        frm.ShowVision = true;
                                        TaskVision.FindCircle = 2;
                                        TaskVision.TextString = ATNCMsg;
                                        TaskVision.TextColor = ATNCMsgColor;
                                        TaskVision.SelectedCam = ECamNo.Cam02;
                                        dr = frm.ShowDialog();
                                        frm.ForceGantryMode = EForceGantryMode.None;
                                        TaskVision.FindCircle = 0;

                                        X2 = TaskGantry.GX2Pos();
                                        Y2 = TaskGantry.GY2Pos();
                                        Z2 = TaskGantry.GZ2Pos();
                                        if (dr == DialogResult.Retry)
                                        {
                                            goto _RetryNew;
                                        }
                                        if (dr == DialogResult.Cancel)
                                        {
                                            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                            return false;
                                        }
                                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                        Aperture_Dia_Setup = Radius[0];
                                        Aperture_Dia = Aperture_Dia_Setup;
                                        break;
                                    }
                                    #endregion
                            }
                            break;
                    }
                    LightRGB_Needle = TaskVision.CurrentLightRGBA;
                    #endregion

                    #region User Instruction: Move Camera XY to Cal pos
                    //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                    if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                    if (!TaskGantry.SetMotionParamGXY()) return false;
                    if (!TaskGantry.MoveAbsGXY(Cal_Pos_X, Cal_Pos_Y)) return false;

                    TaskVision.SelectedCam = ECamNo.Cam00;
                    TaskVision.LightingOn(LightRGB_TopCamera);

                    switch (Type)
                    {
                        default:
                            #region
                            {
                                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                frm.Inst = "Jog Camera to Calibrated Needle2 Position";
                                frm.ShowVision = true;
                                frm.ForceGantryMode = EForceGantryMode.XYZ;
                                DialogResult dr = frm.ShowDialog();
                                frm.ForceGantryMode = EForceGantryMode.None;

                                //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }
                                break;
                            }
                        #endregion
                        case ECalHeadOffsetMethod.BCamera:
                            switch (GDefine.BottomCamType)
                            {
                                default:
                                    #region
                                    {
                                        frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                        frm.Inst = "Jog Camera to Calibrated Needle2 Position";
                                        frm.ShowVision = true;
                                        frm.ForceGantryMode = EForceGantryMode.XYZ;
                                        DialogResult dr = frm.ShowDialog();
                                        frm.ForceGantryMode = EForceGantryMode.None;

                                        //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                        //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                                        if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                                        if (dr == DialogResult.Cancel)
                                        {
                                            return false;
                                        }
                                        break;
                                    }
                                #endregion
                                case GDefine.EBottomCamType.ATNC:
                                    {
                                        break;
                                    }
                            }
                            break;
                    }

                    LightRGB_TopCamera = TaskVision.CurrentLightRGBA;
                    #endregion

                    TPos3 oldHead1_Ofst = new TPos3(Head_Ofst[1]);

                    #region Computate Head2 Values
                    TPos2 Cal_Pos2 = new TPos2(0, 0);
                    TPos2 Head2_Ofst = new TPos2(0, 0);
                    switch (Type)
                    {
                        case ECalHeadOffsetMethod.CrossHair:
                            Cal_Pos2.X = TaskGantry.GXPos();
                            Cal_Pos2.Y = TaskGantry.GYPos();
                            Camera_Cal_Needle2_Z = Z2;
                            Head2_Ofst.X = Camera_Cal_Pos.X - Cal_Pos2.X;
                            Head2_Ofst.Y = Camera_Cal_Pos.Y - Cal_Pos2.Y;
                            break;
                        case ECalHeadOffsetMethod.BCamera:
                            Cal_Pos2.X = TaskGantry.GXPos();
                            Cal_Pos2.Y = TaskGantry.GYPos();
                            BCamera_Cal_Needle2_Z = Z2;
                            Head2_Ofst.X = BCamera_Cal_Pos.X - Cal_Pos2.X;
                            Head2_Ofst.Y = BCamera_Cal_Pos.Y - Cal_Pos2.Y;
                            break;
                    }

                    Head2_DefPos.X = X2 + Head2_Ofst.X;
                    Head2_DefPos.Y = Y2 + Head2_Ofst.Y;

                    //Head_Ofst_Setup[1].X = Head_Ofst[0].X - Head2_DefDistX;
                    //Head_Ofst_Setup[1].Y = Head_Ofst[0].Y;
                    //Head_Ofst[1].X = Head_Ofst_Setup[1].X;
                    //Head_Ofst[1].Y = Head_Ofst_Setup[1].Y;
                    Head_Ofst[1].X = Head_Ofst[0].X - Head2_DefDistX;
                    Head_Ofst[1].Y = Head_Ofst[0].Y;
                    #endregion

                    Event.SETUP_HEAD2_OFST_UPDATE.Set("Head2Offset", Head_Ofst[1].X.ToString("f3") + "," + Head_Ofst[1].Y.ToString("f3"));
                }

                switch (Type)
                {
                    case ECalHeadOffsetMethod.BCamera:
                        TaskDisp.BCamera_Cal_LightRGB = LightRGB_TopCamera;
                        TaskDisp.BCamera_CalNeedle_LightRGB = LightRGB_Needle;
                        break;
                    default:
                        TaskDisp.Camera_Cal_LightRGB = LightRGB_TopCamera;
                        TaskDisp.BCamera_CalNeedle_LightRGB = LightRGB_Needle;
                        break;
                }
                TaskVision.LightingOn(TaskVision.DefLightRGB);
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            finally
            {
                //if (GDefine.CameraType[(int)ECamNo.Cam00] == GDefine.ECameraType.Spinnaker)
                //{
                //    TaskVision.frmGenImageView.Reticles.Clear();
                //}
                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                {
                    try
                    {
                        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam02);
                        //TaskVision.frmGenImageView.GrabStop();

                        //TaskVision.frmGenImageView.SelectIndex((int)ECamNo.Cam00);
                        //TaskVision.frmGenImageView.Hide();
                        //TaskVision.frmGenImageView.Reticles.Clear();
                    }
                    catch
                    {
                    }
                }
            }
            return true;
        }
        //public static bool SearchNeedle(string NeedleName, double X, double Y, double Z, CControl2.TAxis _Axis, ref double TouchZ)
        //{
        //    #region Move Needle XY to ZSensor
        //    if (!TaskGantry.SetMotionParamGXY()) return false;
        //    if (!TaskGantry.MoveAbsGXY(X, Y, false)) return false;
        //    if (!TaskGantry.WaitGXY()) return false;
        //    if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
        //    {
        //        if (!TaskGantry.SetMotionParamGX2Y2()) return false;
        //        if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
        //        if (!TaskGantry.WaitGX2Y2()) return false;
        //    }
        //    #endregion
        //_Retry:
        //    if (!TaskGantry.SensNeedleZ())
        //    {
        //        Msg MsgBox = new Msg();
        //        MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_NOT_ON);
        //        return false;
        //    }

        //    double CoarseFoundZ = 0;
        //    List<double> FineFoundZ = new List<double>();
        //    #region Needle Coarse Search ZSensor
        //    if (!TaskGantry.SetMotionParam(_Axis, 1, 10, 100)) return false;
        //    if (!TaskGantry.MovePtpAbs(_Axis, Z)) return false;
        //    while (true)
        //    {
        //        if (!TaskGantry.SensNeedleZ()) { break; }
        //        if (!TaskGantry.AxisBusy(_Axis)) break;
        //    }
        //    if (!TaskGantry.ForceStop(_Axis)) return false;
        //    if (!TaskGantry.AxisWait(_Axis)) return false;

        //    if (TaskGantry.SensNeedleZ())
        //    {
        //        #region Manual Jog
        //    _Retry1:
        //        Msg MsgBox = new Msg();
        //        EMsgRes MsgRes = MsgBox.Show(ErrCode.SEARCH_NEEDLE_ZSENSOR_NOT_FOUND, EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
        //        switch (MsgRes)
        //        {
        //            case EMsgRes.smrOK:
        //                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
        //                frm.Inst = "Jog " + NeedleName + " Z 5mm above ZSensor";
        //                frm.ShowVision = false;
        //                frm.ForceGantryMode = frm_DispCore_JogGantry.EForceGantryMode.None;
        //                DialogResult dr = frm.ShowDialog();
        //                frm.ForceGantryMode = frm_DispCore_JogGantry.EForceGantryMode.None;

        //                if (dr == DialogResult.Cancel)
        //                {
        //                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
        //                    return false;
        //                }
        //                break;
        //            case EMsgRes.smrRetry:
        //                break;
        //            case EMsgRes.smrCancel:
        //                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
        //                return false;
        //        }

        //        double GZ = TaskGantry.LogicalPos(_Axis);
        //        CoarseFoundZ = GZ;
        //        if (!TaskGantry.SetMotionParam(_Axis, 1, 10, 100)) return false;
        //        if (!TaskGantry.MovePtpAbs(_Axis, GZ - 5)) return false;
        //        while (true)
        //        {
        //            if (!TaskGantry.SensNeedleZ()) { break; }
        //            if (!TaskGantry.AxisBusy(_Axis)) break;
        //        }
        //        if (!TaskGantry.ForceStop(_Axis)) return false;
        //        if (!TaskGantry.AxisWait(_Axis)) return false;

        //        if (TaskGantry.SensNeedleZ())
        //        {
        //            goto _Retry1;
        //        }
        //        #endregion
        //    }
        //    #endregion

        //    #region Needle Fine Search ZSensor
        //    int i_TouchCount = 0;
        //_Retouch:
        //    if (!TaskGantry.SetMotionParam(_Axis, 1, 5, 100)) return false;
        //    if (!TaskGantry.MovePtpRel(_Axis, 0.5)) return false;
        //    if (!TaskGantry.AxisWait(_Axis)) return false;

        //    if (!TaskGantry.SensNeedleZ())
        //    {
        //        Msg MsgBox = new Msg();
        //        MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_NOT_ON);
        //        return false;
        //    }

        //    if (!TaskGantry.SetMotionParam(_Axis, 1, 1, 100)) return false;
        //    if (!TaskGantry.MovePtpRel(_Axis, -1)) return false;
        //    while (true)
        //    {
        //        if (!TaskGantry.SensNeedleZ())
        //        {
        //            TouchZ = TaskGantry.LogicalPos(_Axis);
        //            FineFoundZ.Add(TouchZ);
        //            i_TouchCount++;
        //            break;
        //        }
        //        if (!TaskGantry.AxisBusy(_Axis)) break;
        //    }
        //    if (!TaskGantry.ForceStop(_Axis)) return false;
        //    if (!TaskGantry.AxisWait(_Axis)) return false;

        //    if (TaskGantry.SensNeedleZ())
        //    {
        //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
        //        Msg MsgBox = new Msg();
        //        MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_NOT_OFF);
        //        return false;
        //    }

        //    if (i_TouchCount < 3) goto _Retouch;

        //    if (FineFoundZ.Max() - FineFoundZ.Min() > 0.05)
        //    {
        //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
        //        Msg MsgBox = new Msg();
        //        if (MsgBox.Show(ErrCode.NEEDLE_ZSENSOR_ABNORMAL, EMcState.Error, EMsgBtn.smbRetry_Cancel, false) == EMsgRes.smrRetry)
        //        {
        //            goto _Retry;
        //        }
        //        return false;
        //    }

        //    TouchZ = FineFoundZ.Average();

        //    #endregion

        //    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
        //    return true;
        //}
        public static bool SetNeedle(string NeedleName, double X, double Y, double Z, CControl2.TAxis _Axis, ref double TouchZ)
        {
            #region Move Needle XY to ZSensor
            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(X, Y, false)) return false;
            if (!TaskGantry.WaitGXY()) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                if (!TaskGantry.WaitGX2Y2()) return false;
            }
            #endregion

            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("Move Z Down?", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);

                switch (MsgRes)
                {
                    case EMsgRes.smrOK:
                        if (!TaskGantry.SetMotionParam(_Axis, TaskGantry.GZAxis.Para.Accel, TaskGantry.GZAxis.Para.StartV, TaskGantry.GZAxis.Para.MedV)) return false;
                        if (!TaskGantry.MovePtpAbs(_Axis, Z)) return false;
                        if (!TaskGantry.AxisWait(_Axis)) return false;
                        break;
                        //case EMsgRes.smrCancel:
                }
            }

            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
            frm.Inst = "Jog " + NeedleName + " to Touch Position";
            frm.ShowVision = false;
            frm.ForceGantryMode = EForceGantryMode.None;
            DialogResult dr = frm.ShowDialog();
            frm.ForceGantryMode = EForceGantryMode.None;

            if (dr == DialogResult.Cancel)
            {
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                return false;
            }

            TouchZ = TaskGantry.LogicalPos(_Axis);

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }
        public static bool GotoNeedle(string NeedleName, double X, double Y, double Z, CControl2.TAxis _Axis)
        {
            #region Move Needle XY to ZSensor
            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(X, Y, false)) return false;
            if (!TaskGantry.WaitGXY()) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                if (!TaskGantry.WaitGX2Y2()) return false;
            }
            #endregion

            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("Move Z Down?", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);

                switch (MsgRes)
                {
                    case EMsgRes.smrOK:
                        if (!TaskGantry.SetMotionParam(_Axis, TaskGantry.GZAxis.Para.Accel, TaskGantry.GZAxis.Para.StartV, TaskGantry.GZAxis.Para.MedV)) return false;
                        if (!TaskGantry.MovePtpAbs(_Axis, Z - 1)) return false;
                        if (!TaskGantry.AxisWait(_Axis)) return false;
                        break;
                        //case EMsgRes.smrCancel:
                }
            }

            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("Adjust Needle 2 Position.", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
            }
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            return true;
        }
        public static bool CalZSensorZ(bool CalLaser)
        {
            string EMsg = "Cal ZSensor";
            if (CalLaser) EMsg = "Cal ZSensor Laser";

            double TouchZ1 = 0;
            double TouchZ1B = 0;
            double TouchZ2 = 0;
            double TouchZ2B = 0;

            try
            {
                #region Teach Camera Position
                //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                #region Move Camera XY to ZSensor
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(Camera_ZSensor_Pos.X, Camera_ZSensor_Pos.Y, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
                if (!TaskGantry.WaitGXY()) return false;
                #endregion

                TaskVision.LightingOn(TaskDisp.Camera_ZSensor_LightRGB);
                #region user instruction
                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Camera XY to ZSensor Position";
                frm.ShowVision = true;
                frm.ForceGantryMode = EForceGantryMode.XYZ;
                DialogResult dr = frm.ShowDialog();
                frm.ForceGantryMode = EForceGantryMode.None;
                #endregion

                //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                #region handle user entry
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                #endregion
                TaskDisp.Camera_ZSensor_LightRGB = TaskVision.CurrentLightRGBA;
                TaskVision.LightingOn(TaskVision.DefLightRGB);
                #endregion

                double CX = TaskGantry.GXPos();
                double CY = TaskGantry.GYPos();

                double LaserPosX = 0;
                double LaserPosY = 0;

                #region Teach Laser Position
                if (CalLaser && (GDefine.HSensorType > GDefine.EHeightSensorType.None))
                {
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                    if (!TaskGantry.SetMotionParamGXY()) return false;
                    if (!TaskGantry.MoveAbsGXY(CX + Laser_Ofst.X, CY + Laser_Ofst.Y)) return false;

                    TaskVision.LightingOff();

                    frm = new frm_DispCore_JogGantryVision();
                    frm.Inst = "Jog Laser XY to ZSensor Position";
                    frm.ShowVision = false;
                    dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel)
                    {
                        return false;
                    }

                    LaserPosX = TaskGantry.GXPos();
                    LaserPosY = TaskGantry.GYPos();

                    //string s = (LaserPosX - CX).ToString("f3") + "," + (LaserPosY - CY).ToString("f3");
                    //Event.Log("Laser Ofst", s);

                    _RetryLaser:
                    int t = GDefine.GetTickCount() + TaskLaser.SettleTime;
                    while (GDefine.GetTickCount() < t) { Thread.Sleep(1); }

                    double d_ZSensor_LaserZ_Old = TaskDisp.Laser_RefPosZ;
                    double d_ZSensor_LaserZ_New = TaskDisp.Laser_RefPosZ;
                    if (!TaskLaser.GetHeight(ref d_ZSensor_LaserZ_New)) return false;

                    switch (ValidateLaserChangeRate(d_ZSensor_LaserZ_Old, d_ZSensor_LaserZ_New))
                    {
                        case EAction.Accept:
                            break;
                        case EAction.Retry:
                            goto _RetryLaser;
                        case EAction.Stop:
                            return false;
                    }
                    TaskDisp.Laser_RefPosZ = d_ZSensor_LaserZ_New;
                    Event.SETUP_REFZ_UPDATE.Set("RefPosZ", d_ZSensor_LaserZ_New.ToString("f3"));
                }
                #endregion

                #region Search Needle1
                if (DispProg.Pump_Type != EPumpType.PP2D)
                {
                    if (!TaskZTouch.SearchNeedleZTouch("Needle 1", CX + Head_Ofst[0].X, CY + Head_Ofst[0].Y, Head_ZSensor_RefPosZ[0], TaskGantry.GZAxis, ref TouchZ1)) return false;
                }
                if (DispProg.Pump_Type == EPumpType.PP2D)
                {
                    #region
                    if (!TaskZTouch.SearchNeedleZTouch("Needle 1A", CX + Head_Ofst[0].X, CY + Head_Ofst[0].Y, Head_ZSensor_RefPosZ[0], TaskGantry.GZAxis, ref TouchZ1)) return false;

                    _Retry1B:
                    if (!TaskZTouch.SearchNeedleZTouch("Needle 1B", CX + Head_Ofst[0].X, CY + Head_Ofst[0].Y - Head_NeedlePitchY, Head_ZSensor_RefPosZ[0], TaskGantry.GZAxis, ref TouchZ1B)) return false;

                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show("Master Z = " + TouchZ1.ToString("f3") + "@Current Z = " + TouchZ1B.ToString("f3"), "", "", EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                    switch (MsgRes)
                    {
                        case EMsgRes.smrOK:
                            break;
                        case EMsgRes.smrRetry:
                            goto _Retry1B;
                        case EMsgRes.smrCancel:
                            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                            return false;
                    }
                    #endregion
                }
                #endregion

                #region Computation
                Camera_ZSensor_Pos.X = CX;
                Camera_ZSensor_Pos.Y = CY;

                Head_ZSensor_RefPosZ_Setup[0] = TouchZ1;
                Head_ZSensor_RefPosZ[0] = Head_ZSensor_RefPosZ_Setup[0];
                Head_Ofst[0].Z = 0;
                //TaskDisp.Camera_ZSensor_LightRGB = TaskVision.CurrentLightRGBA;

                TPos2 oldLaser_Ofst = new TPos2(Laser_Ofst);
                if (CalLaser && GDefine.HSensorType > GDefine.EHeightSensorType.None)
                {
                    Laser_Ofst_Setup.X = LaserPosX - CX;
                    Laser_Ofst.X = Laser_Ofst_Setup.X;
                    Laser_Ofst_Setup.Y = LaserPosY - CY;
                    Laser_Ofst.Y = Laser_Ofst_Setup.Y;

                    Event.SETUP_LASER_OFST_UPDATE.Set("LaserOffset", Laser_Ofst.X.ToString("f3") + "," + Laser_Ofst.Y.ToString("f3"));
                }
                #endregion

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskZTouch.SearchNeedleZTouch("Needle 2", CX + Head_Ofst[0].X - Head2_DefDistX, CY + Head_Ofst[0].Y, Head_ZSensor_RefPosZ[1], TaskGantry.GZ2Axis, ref TouchZ2)) return false;
                }
                else
                {
                    if (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double)
                    {
                        if (DispProg.Pump_Type != EPumpType.PP2D)
                        {
                            #region
                            _Retry2:
                            if (!TaskZTouch.SearchNeedleZTouch("Needle 2", CX + Head_Ofst[0].X - Head_PitchX, CY + Head_Ofst[0].Y, Head_ZSensor_RefPosZ[0], TaskGantry.GZAxis, ref TouchZ2)) return false;

                            Msg MsgBox = new Msg();
                            EMsgRes MsgRes = MsgBox.Show("Master Z = " + TouchZ1.ToString("f3") + "@Current Z = " + TouchZ2.ToString("f3"), EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                            switch (MsgRes)
                            {
                                case EMsgRes.smrOK:
                                    break;
                                case EMsgRes.smrRetry:
                                    goto _Retry2;
                                case EMsgRes.smrCancel:
                                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                    return false;
                            }
                        }
                        #endregion
                        if (DispProg.Pump_Type == EPumpType.PP2D)
                        {
                            #region
                            _Retry2A:
                            if (!TaskZTouch.SearchNeedleZTouch("Needle 2A", CX + Head_Ofst[0].X - Head_PitchX, CY + Head_Ofst[0].Y, Head_ZSensor_RefPosZ[0], TaskGantry.GZAxis, ref TouchZ2)) return false;
                            {
                                Msg MsgBox = new Msg();
                                EMsgRes MsgRes = MsgBox.Show("Master Z = " + TouchZ1.ToString("f3") + "@Current Z = " + TouchZ2.ToString("f3"), EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                                switch (MsgRes)
                                {
                                    case EMsgRes.smrOK:
                                        break;
                                    case EMsgRes.smrRetry:
                                        goto _Retry2A;
                                    case EMsgRes.smrCancel:
                                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                        return false;
                                }
                            }
                            _Retry2B:
                            if (!TaskZTouch.SearchNeedleZTouch("Needle 2B", CX + Head_Ofst[0].X - Head_PitchX, CY + Head_Ofst[0].Y - Head_NeedlePitchY, Head_ZSensor_RefPosZ[0], TaskGantry.GZAxis, ref TouchZ2B)) return false;
                            {
                                Msg MsgBox = new Msg();
                                EMsgRes MsgRes = MsgBox.Show("Master Z = " + TouchZ1.ToString("f3") + "@Current Z = " + TouchZ2B.ToString("f3"), EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                                switch (MsgRes)
                                {
                                    case EMsgRes.smrOK:
                                        break;
                                    case EMsgRes.smrRetry:
                                        goto _Retry2B;
                                    case EMsgRes.smrCancel:
                                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                        return false;
                                }
                            }
                            #endregion
                        }
                    }
                }

                #region Computation
                Head_ZSensor_RefPosZ_Setup[1] = TouchZ2;
                Head_ZSensor_RefPosZ[1] = Head_ZSensor_RefPosZ_Setup[1];
                Head_Ofst[1].Z = 0;
                #endregion
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }

        public static bool TaskTeachNeedle_ZSensor_Mark()
        {
            if (TeachNeedle_Method == ETeachNeedleMethod.None) return true;

            GDefine.Status = EStatus.Busy;
            if (!TaskMoveGZZ2Up()) return false;

            //double d_ZSensor_LaserZ = 0;
            double d_ZSensor_LaserZ_New = TaskDisp.Laser_RefPosZ;
            double d_TouchZ1 = Head_ZSensor_RefPosZ[0];
            double d_TouchZ2 = Head_ZSensor_RefPosZ[1];
            Head_Ofst[0].Z = 0;
            Head_Ofst[1].Z = 0;
            double d_Touch_LaserZ = 0;

            if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
            {
                #region Move to Laser Pos, Get LaserTouchZValue
                TPos3 XY = new TPos3(Camera_ZSensor_Pos.X + Laser_Ofst.X, Camera_ZSensor_Pos.Y + Laser_Ofst.Y, 0);
                if (!GotoXYPos(XY, Head2_DefPos)) return false;

                _RetryLaser:
                int t = GDefine.GetTickCount() + TaskLaser.SettleTime;
                while (GDefine.GetTickCount() < t) { Thread.Sleep(1); }

                double d_ZSensor_LaserZ_Old = TaskDisp.Laser_RefPosZ;
                if (!TaskLaser.GetHeight(ref d_ZSensor_LaserZ_New)) return false;

                switch (ValidateLaserChangeRate(d_ZSensor_LaserZ_Old, d_ZSensor_LaserZ_New))
                {
                    case EAction.Accept:
                        break;
                    case EAction.Retry:
                        goto _RetryLaser;
                    case EAction.Stop:
                        return false;
                }
                TaskDisp.Laser_RefPosZ = d_ZSensor_LaserZ_New;
                Event.SETUP_REFZ_UPDATE.Set("RefPos", d_ZSensor_LaserZ_New.ToString("f3"));
                #endregion
            }

            if (GDefine.ZSensorType > (GDefine.EZSensorType)0)
            {
                //Move to Needle1, Search Z
                if (!TaskZTouch.SearchNeedleZTouch("Needle 1", Camera_ZSensor_Pos.X + Head_Ofst[(int)EHead.One].X, Camera_ZSensor_Pos.Y + Head_Ofst[(int)EHead.One].Y, d_TouchZ1, TaskGantry.GZAxis, ref d_TouchZ1)) return false;

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    //Move to Needle2, Search Z
                    if (!TaskZTouch.SearchNeedleZTouch("Needle 2", Camera_ZSensor_Pos.X + Head_Ofst[(int)EHead.Two].X, Camera_ZSensor_Pos.Y + Head_Ofst[(int)EHead.Two].Y, d_TouchZ2, TaskGantry.GZ2Axis, ref d_TouchZ2)) return false;
                }
                Head_Ofst[0].Z = d_TouchZ1 - Head_ZSensor_RefPosZ_Setup[(int)EHead.One];
                Head_Ofst[1].Z = d_TouchZ2 - Head_ZSensor_RefPosZ_Setup[(int)EHead.Two];
            }

            if (!TaskMoveGZZ2Up()) return false;

            if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
            {
                #region Move to Laser to Pos
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(Camera_Cal_Pos.X + Laser_Ofst.X, Camera_Cal_Pos.Y + Laser_Ofst.Y)) return false;

                int t = GDefine.GetTickCount() + TaskLaser.SettleTime;
                while (GDefine.GetTickCount() < t) { Thread.Sleep(1); }

                if (!TaskLaser.GetHeight(ref d_Touch_LaserZ)) return false;
                #endregion
            }

            if (!TaskGantry.MoveAbsGXY(Camera_Cal_Pos.X + Head_Ofst[0].X, Camera_Cal_Pos.Y + Head_Ofst[0].Y)) return false;

            if (!TaskGantry.SetMotionParamGZ(5, 20, 100)) return false;
            if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
            {
                if (!TaskGantry.MoveAbsGZ(TaskDisp.Head_ZSensor_RefPosZ[0] + (d_Touch_LaserZ - d_ZSensor_LaserZ_New) + Head_Ofst[0].Z + TeachNeedle_ZOfst)) return false;
            }
            else
            {
                if (!TaskGantry.MoveAbsGZ(TaskDisp.Camera_Cal_Needle1_Z + Head_Ofst[0].Z)) return false;
            }

            double NeedleX = TaskGantry.GXPos();
            double NeedleY = TaskGantry.GYPos();

            int t1 = GDefine.GetTickCount() + TeachNeedle_WaitTime;
            while (GDefine.GetTickCount() < t1) { Thread.Sleep(1); }

            if (!TaskMoveGZZ2Up()) return false;

            if (!TaskGantry.MoveAbsGXY(Camera_Cal_Pos.X, Camera_Cal_Pos.Y)) return false;

            TaskVision.LightingOn(Camera_Cal_LightRGB);
            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
            frm.Inst = "Jog Camera to Calibrated Needle1 Position";
            frm.ShowVision = true;
            frm.ForceGantryMode = EForceGantryMode.XYZ;
            DialogResult dr = frm.ShowDialog();
            frm.ForceGantryMode = EForceGantryMode.None;

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (dr == DialogResult.Cancel)
            {
                return true;
            }
            TaskDisp.Camera_Cal_LightRGB = TaskVision.CurrentLightRGBA;

            double CamX = TaskGantry.GXPos();
            double CamY = TaskGantry.GYPos();

            TPos3 oldHead_Ofst0 = new TPos3(Head_Ofst[0]);
            Head_Ofst[0].X = NeedleX - CamX;
            Head_Ofst[0].Y = NeedleY - CamY;

            Event.SETUP_HEAD1_OFST_UPDATE.Set("HeadOffset", Head_Ofst[0].X.ToString("f3") + "," + Head_Ofst[0].Y.ToString("f3"));

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                TPos2 GXY = new TPos2(Camera_Cal_Pos.X + Head_Ofst[0].X - Head2_DefDistX + 2, Camera_Cal_Pos.Y + Head_Ofst[0].Y);
                TPos2 GX2Y2 = new TPos2(Head2_DefPos.X, Head2_DefPos.Y);
                if (!TaskDisp.GotoXYPos(GXY, GX2Y2)) return false;

                double NeedleX2 = TaskGantry.GX2Pos() + 2;
                double NeedleY2 = TaskGantry.GY2Pos();

                if (!TaskGantry.SetMotionParamGZ2(5, 20, 100)) return false;

                if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
                {
                    if (!TaskGantry.MoveAbsGZ2(TaskDisp.Head_ZSensor_RefPosZ[1] + (d_Touch_LaserZ - d_ZSensor_LaserZ_New) + Head_Ofst[1].Z + TeachNeedle_ZOfst)) return false;
                }
                else
                {
                    if (!TaskGantry.MoveAbsGZ2(TaskDisp.Camera_Cal_Needle2_Z + Head_Ofst[1].Z)) return false;
                }

                int t = GDefine.GetTickCount() + TeachNeedle_WaitTime;
                while (GDefine.GetTickCount() < t) { Thread.Sleep(1); }

                if (!TaskMoveGZZ2Up()) return false;

                if (!TaskGantry.MoveAbsGXY(Camera_Cal_Pos.X + 2, Camera_Cal_Pos.Y)) return false;


                TaskVision.LightingOn(TaskDisp.Camera_Cal_LightRGB);
                frm_DispCore_JogGantryVision frm2 = new frm_DispCore_JogGantryVision();
                frm2.Inst = "Jog Camera to Calibrated Needle2 Position";
                frm2.ShowVision = true;
                frm2.ForceGantryMode = EForceGantryMode.XYZ;
                DialogResult dr2 = frm2.ShowDialog();
                frm2.ForceGantryMode = EForceGantryMode.None;

                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                if (dr2 == DialogResult.Cancel)
                {
                    return true;
                }
                TaskDisp.Camera_Cal_LightRGB = TaskVision.CurrentLightRGBA;

                TPos2 Camera_Cal_Pos2 = new TPos2(0, 0);
                Camera_Cal_Pos2.X = TaskGantry.GXPos();
                Camera_Cal_Pos2.Y = TaskGantry.GYPos();



                TPos2 Head2Ofst = new TPos2(0, 0);
                Head2Ofst.X = Camera_Cal_Pos.X - Camera_Cal_Pos2.X;
                Head2Ofst.Y = Camera_Cal_Pos.Y - Camera_Cal_Pos2.Y;

                Head2_DefPos.X = NeedleX2 + Head2Ofst.X;
                Head2_DefPos.Y = NeedleY2 + Head2Ofst.Y;

                TPos3 oldHead_Ofst1 = new TPos3(Head_Ofst[1]);
                Head_Ofst[1].X = Head_Ofst[0].X - Head2_DefDistX;
                Head_Ofst[1].Y = Head_Ofst[0].Y;

                Event.SETUP_HEAD2_OFST_UPDATE.Set("Head2Offset", Head_Ofst[1].X.ToString("f3") + "," + Head_Ofst[1].Y.ToString("f3"));
            }

            TaskDisp.Head_ZSensor_RefPosZ[0] = d_TouchZ1;// dTouchPos + H1N2TouchPos) / 2;
            TaskDisp.Head_ZSensor_RefPosZ[1] = d_TouchZ2;// (H2N1TouchPos + H2N2TouchPos) / 2;

            TaskVision.LightingOn(TaskVision.DefLightRGB);

            GDefine.Status = EStatus.Ready;
            return true;
            //_Error:
            //    GDefine.Status = EStatus.ErrorInit;
            //    frm_DispCore_Msg.Page.ShowMsg(EMsg, frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK);
            //    return false;
        }

        public static bool MoveNeedleToBCamera(string NeedleName, double X, double Y, double Z, double Z2)
        {
            if (Z > 0) Z = ZDefPos;
            if (Z2 > 0) Z2 = ZDefPos;

            #region Move Needle XY to Cal Pos
            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return false;
            if (Z != ZDefPos)
            {
                if (!TaskGantry.SetMotionParamGZ(1, 50, 1000)) return false;
                if (!TaskGantry.MoveAbsGZ(Z)) return false;
            }
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (Z2 != ZDefPos)
                {
                    if (!TaskGantry.SetMotionParamGZ2(1, 50, 1000)) return false;
                    if (!TaskGantry.MoveAbsGZ2(Z2)) return false;
                }
            }
            #endregion

            return true;
        }
        public static bool TaskTeachNeedle_ZSensor_BCamera()
        {
            #region Move Z Up
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            #endregion

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                if (!TaskGantry.MoveGX2Y2DefPos(true)) return false;
            }

            double CX = Camera_ZSensor_Pos.X;
            double CY = Camera_ZSensor_Pos.Y;
            double d_LaserValue = 0;

            #region ZSensor Measure Laser
            if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
            {
                #region move laser xy to ZSensor
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(CX + Laser_Ofst.X, CY + Laser_Ofst.Y)) return false;
                #endregion

                int t = GDefine.GetTickCount() + TaskLaser.SettleTime;
                while (GDefine.GetTickCount() < t) { Thread.Sleep(1); }

                if (!TaskLaser.GetHeight(ref d_LaserValue)) return false;
            }
            #endregion

            double d_H1N1TouchPos = Head_ZSensor_RefPosZ[0];
            double d_H1N2TouchPos = Head_ZSensor_RefPosZ[0];
            double d_H2N1TouchPos = Head_ZSensor_RefPosZ[1];
            double d_H2N2TouchPos = Head_ZSensor_RefPosZ[1];
            double d_BCamera_Cal_Needle1_Z = BCamera_Cal_Needle1_Z;
            double d_BCamera_Cal_Needle2_Z = BCamera_Cal_Needle2_Z;

            #region Search Head1 Needles
            #region
            if (!TaskZTouch.SearchNeedleZTouch("Head 1 Needle 1", CX + Head_Ofst[0].X, CY + Head_Ofst[0].Y, d_H1N1TouchPos, TaskGantry.GZAxis, ref d_H1N1TouchPos)) return false;
            d_H1N2TouchPos = d_H1N1TouchPos;
            #endregion
            if (DispProg.Pump_Type == EPumpType.PP2D)
            {
                #region
                _RetryZ1N2:
                if (!TaskZTouch.SearchNeedleZTouch("Head 1 Needle 2", CX + Head_Ofst[0].X, CY + Head_Ofst[0].Y - Head_NeedlePitchY, d_H1N2TouchPos, TaskGantry.GZAxis, ref d_H1N2TouchPos)) return false;

                double ZDiff = d_H1N2TouchPos - d_H1N1TouchPos;
                if (Math.Abs(ZDiff) > MultiHead_ZTol)
                {
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show("Head 1 Needle 2 Out of Tolerance." + "@" + "Head 1 Needle 2 Difference = " + ZDiff.ToString("F3"), EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                    switch (MsgRes)
                    {
                        case EMsgRes.smrOK:
                            break;
                        case EMsgRes.smrRetry:
                            goto _RetryZ1N2;
                        case EMsgRes.smrCancel:
                            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                            return false;
                    }
                }
                #endregion
            }
            #endregion

            #region Search Head2 Needles
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                #region Search Head 2 Needle 1
                if (!TaskZTouch.SearchNeedleZTouch("Head 2 Needle 1", CX + Head_Ofst[0].X - Head2_DefDistX, CY + Head_Ofst[0].Y, d_H2N1TouchPos, TaskGantry.GZ2Axis, ref d_H2N1TouchPos)) return false;
                d_H2N2TouchPos = d_H2N1TouchPos;
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                #endregion

                if (DispProg.Pump_Type == EPumpType.PP2D)
                {
                    #region Search Head 2 Needle 2
                    _RetryZ2N2:
                    if (!TaskZTouch.SearchNeedleZTouch("Head 2 Needle 2", CX + Head_Ofst[0].X - Head2_DefDistX, CY + Head_Ofst[0].Y - Head_NeedlePitchY, d_H2N2TouchPos, TaskGantry.GZ2Axis, ref d_H2N2TouchPos)) return false;
                    double Z2N2Diff = d_H2N2TouchPos - d_H2N1TouchPos;
                    if (Math.Abs(Z2N2Diff) > MultiHead_ZTol)
                    {
                        #region Handle Tolerance
                        //MsgID = frm_DispCore_Msg.Page.ShowMsg("Head 2 Needle 2 Out of Tolerance." + (char)13 +
                        //    "Head 2 Needle 2 Difference = " + Z2N2Diff.ToString("F3"),
                        //    frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK | frm_DispCore_Msg.TMsgBtn.smbRetry | frm_DispCore_Msg.TMsgBtn.smbCancel);
                        //while (!frm_DispCore_Msg.Page.ShowMsgClear(MsgID))
                        //{
                        //    Application.DoEvents();
                        //}
                        //switch (frm_DispCore_Msg.Page.GetMsgRes(MsgID))
                        //{
                        //    case frm_DispCore_Msg.TMsgRes.smrOK:
                        //        break;
                        //    case frm_DispCore_Msg.TMsgRes.smrRetry:
                        //        goto _RetryZ2N2;
                        //    case frm_DispCore_Msg.TMsgRes.smrCancel:
                        //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                        //        return false;
                        //}
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show("Head 2 Needle 2 Out of Tolerance." + "@" + "Head 2 Needle 2 Difference = " + Z2N2Diff.ToString("F3"), EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                        switch (MsgRes)
                        {
                            case EMsgRes.smrOK:
                                break;
                            case EMsgRes.smrRetry:
                                goto _RetryZ2N2;
                            case EMsgRes.smrCancel:
                                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                return false;
                        }
                        #endregion
                    }
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    #endregion
                }
            }
            else
            {
                //if (MultiHead_OpType == EMultiHeadType.Twin)
                if (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double)
                {
                    #region Search Head 2 Needle 1
                    _RetryZ2N1:
                    if (!TaskZTouch.SearchNeedleZTouch("Head 2 Needle 1", CX + Head_Ofst[0].X - Head_PitchX, CY + Head_Ofst[0].Y, d_H2N1TouchPos, TaskGantry.GZAxis, ref d_H2N1TouchPos)) return false;
                    d_H2N2TouchPos = d_H2N1TouchPos;
                    double Z2N1Diff = d_H2N1TouchPos - d_H1N1TouchPos;
                    if (Math.Abs(Z2N1Diff) > MultiHead_ZTol)
                    {
                        #region Handle Tolerance
                        //MsgID = frm_DispCore_Msg.Page.ShowMsg("Head 2 Needle 1 Out of Tolerance." + (char)13 +
                        //    "Head 2 Needle 1 Difference = " + Z2N1Diff.ToString("F3"),
                        //    frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK | frm_DispCore_Msg.TMsgBtn.smbRetry | frm_DispCore_Msg.TMsgBtn.smbCancel);
                        //while (!frm_DispCore_Msg.Page.ShowMsgClear(MsgID))
                        //{
                        //    Application.DoEvents();
                        //}
                        //switch (frm_DispCore_Msg.Page.GetMsgRes(MsgID))
                        //{
                        //    case frm_DispCore_Msg.TMsgRes.smrOK:
                        //        break;
                        //    case frm_DispCore_Msg.TMsgRes.smrRetry:
                        //        goto _RetryZ2N1;
                        //    case frm_DispCore_Msg.TMsgRes.smrCancel:
                        //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                        //        return false;
                        //}
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show("Head 2 Needle 1 Out of Tolerance." + "@" + "Head 2 Needle 1 Difference = " + Z2N1Diff.ToString("F3"), EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                        switch (MsgRes)
                        {
                            case EMsgRes.smrOK:
                                break;
                            case EMsgRes.smrRetry:
                                goto _RetryZ2N1;
                            case EMsgRes.smrCancel:
                                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                return false;
                        }
                        #endregion
                    }
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    #endregion
                    if (DispProg.Pump_Type == EPumpType.PP2D)
                    {
                        #region Search Head 2 Needle 2
                        _RetryZ2N2:
                        if (!TaskZTouch.SearchNeedleZTouch("Head 2 Needle 2", CX + Head_Ofst[0].X - Head_PitchX, CY + Head_Ofst[0].Y - Head_NeedlePitchY, d_H2N2TouchPos, TaskGantry.GZAxis, ref d_H2N2TouchPos)) return false;
                        double Z2N2Diff = d_H2N2TouchPos - d_H1N1TouchPos;
                        if (Math.Abs(Z2N2Diff) > MultiHead_ZTol)
                        {
                            #region Handle Tolerance
                            //MsgID = frm_DispCore_Msg.Page.ShowMsg("Head 2 Needle 2 Out of Tolerance." + (char)13 +
                            //    "Head 2 Needle 2 Difference = " + Z2N2Diff.ToString("F3"),
                            //    frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK | frm_DispCore_Msg.TMsgBtn.smbRetry | frm_DispCore_Msg.TMsgBtn.smbCancel);
                            //while (!frm_DispCore_Msg.Page.ShowMsgClear(MsgID))
                            //{
                            //    Application.DoEvents();
                            //}
                            //switch (frm_DispCore_Msg.Page.GetMsgRes(MsgID))
                            //{
                            //    case frm_DispCore_Msg.TMsgRes.smrOK:
                            //        break;
                            //    case frm_DispCore_Msg.TMsgRes.smrRetry:
                            //        goto _RetryZ2N2;
                            //    case frm_DispCore_Msg.TMsgRes.smrCancel:
                            //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                            //        return false;
                            //}
                            Msg MsgBox = new Msg();
                            EMsgRes MsgRes = MsgBox.Show("Head 2 Needle 2 Out of Tolerance." + "@" + "Head 2 Needle 2 Difference = " + Z2N2Diff.ToString("F3"), EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                            switch (MsgRes)
                            {
                                case EMsgRes.smrOK:
                                    break;
                                case EMsgRes.smrRetry:
                                    goto _RetryZ2N2;
                                case EMsgRes.smrCancel:
                                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                    return false;
                            }
                            #endregion
                        }
                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                        #endregion
                    }
                }
            }
            #endregion

            #region computation
            Head_Ofst[0].Z = 0;
            Head_Ofst[1].Z = 0;
            #endregion

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            #region Step 1: Move Camera to Bottom Camera Pos
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            #region Move Needle XY to Cal Pos
            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(BCamera_Cal_Pos.X, BCamera_Cal_Pos.Y)) return false;
            #endregion
            TaskVision.LightingOn(BCamera_Cal_LightRGB);

            #region User Entry Instruction
            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
            frm.Inst = "Jog Camera to BCamera";
            frm.ShowVision = true;
            frm.ForceGantryMode = EForceGantryMode.XYZ;
            DialogResult dr = frm.ShowDialog();
            frm.ForceGantryMode = EForceGantryMode.None;
            #endregion
            #region Move Z Up
            //if (!TaskGantry.SetMotionParamGZZ2()) return false;
            //if (!TaskGantry.MoveAbsGZZ2((float)0)) return false;
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            #endregion
            #region Handle User Entry
            if (dr == DialogResult.Cancel)
            {
                return false;
            }
            TaskDisp.BCamera_Cal_LightRGB = TaskVision.CurrentLightRGBA;
            #endregion
            #endregion

            BCamera_Cal_Pos.X = TaskGantry.GXPos();
            BCamera_Cal_Pos.Y = TaskGantry.GYPos();

            _RetryHead1:
            #region Head 1 Needle 1
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
            TPos3 H1N1 = new TPos3();
            H1N1.X = BCamera_Cal_Pos.X + Head_Ofst[0].X;
            H1N1.Y = BCamera_Cal_Pos.Y + Head_Ofst[0].Y;
            H1N1.Z = d_H1N1TouchPos - Head_ZSensor_RefPosZ[0] + BCamera_Cal_Needle1_Z;

            Application.DoEvents();

            if (!MoveNeedleToBCamera("Head 1 Needle 1", H1N1.X, H1N1.Y, H1N1.Z, 0))
            {
                return false;
            }

            #region User Entry Instruction
            frm = new frm_DispCore_JogGantryVision();
            frm.Inst = "Jog Head 1 Needle1 XY to Crosshair";
            frm.ShowVision = false;
            frm.ForceGantryMode = EForceGantryMode.XYZ;
            dr = frm.ShowDialog();
            frm.ForceGantryMode = EForceGantryMode.None;
            #endregion
            #region Handle User Entry
            if (dr == DialogResult.Cancel)
            {
                return false;
            }
            #endregion
            #endregion

            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();
            double Z = TaskGantry.GZPos();

            d_BCamera_Cal_Needle1_Z = TaskGantry.GZPos();
            TPos3 oldHead_Ofst0 = new TPos3(Head_Ofst[0]);
            Head_Ofst[0].X = X - BCamera_Cal_Pos.X;
            Head_Ofst[0].Y = Y - BCamera_Cal_Pos.Y;

            Event.SETUP_HEAD1_OFST_UPDATE.Set("HeadOffset", Head_Ofst[0].X.ToString("f3") + "," + Head_Ofst[0].Y.ToString("f3"));

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (DispProg.Pump_Type == EPumpType.PP2D)
            {
                #region Head1 Needle 2
                TPos3 H1N2 = new TPos3();
                H1N2.X = BCamera_Cal_Pos.X + Head_Ofst[0].X;
                H1N2.Y = BCamera_Cal_Pos.Y + Head_Ofst[0].Y - Head_NeedlePitchY;
                H1N2.Z = d_H1N2TouchPos - Head_ZSensor_RefPosZ[0] + BCamera_Cal_Needle1_Z;
                if (!MoveNeedleToBCamera("Head 1 Needle 2", H1N2.X, H1N2.Y, H1N2.Z, 0)) return false;

                //MsgID = frm_DispCore_Msg.Page.ShowMsg("Check Head 1 Needle 2 Position", frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbRetry | frm_DispCore_Msg.TMsgBtn.smbOK | frm_DispCore_Msg.TMsgBtn.smbCancel);
                //while (!frm_DispCore_Msg.Page.ShowMsgClear(MsgID))
                //{
                //    Application.DoEvents();
                //}
                //switch (frm_DispCore_Msg.Page.GetMsgRes(MsgID))
                //{
                //    case frm_DispCore_Msg.TMsgRes.smrOK:
                //        break;
                //    case frm_DispCore_Msg.TMsgRes.smrRetry:
                //        goto _RetryHead1;
                //    case frm_DispCore_Msg.TMsgRes.smrCancel:
                //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                //        return false;
                //}

                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("Check Head 1 Needle 2 Position", EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                switch (MsgRes)
                {
                    case EMsgRes.smrOK:
                        break;
                    case EMsgRes.smrRetry:
                        goto _RetryHead1;
                    case EMsgRes.smrCancel:
                        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                        return false;
                }
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                #endregion
            }

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                _RetryHead2:
                #region Head2 Needle1
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                    if (!TaskGantry.MoveGX2Y2DefPos(true)) return false;
                }

                TPos3 H2N1 = new TPos3();
                H2N1.X = BCamera_Cal_Pos.X + Head_Ofst[0].X - Head2_DefDistX;
                H2N1.Y = BCamera_Cal_Pos.Y + Head_Ofst[0].Y;
                H2N1.Z = d_H2N1TouchPos - Head_ZSensor_RefPosZ[1] + BCamera_Cal_Needle2_Z;

                Application.DoEvents();

                if (!MoveNeedleToBCamera("Head 2 Needle 1", H2N1.X, H2N1.Y, 0, H2N1.Z))
                {
                    return false;
                }

                #region User Entry Instruction
                frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Head 2 Needle1 XY to Crosshair";
                frm.ShowVision = false;
                frm.ForceGantryMode = EForceGantryMode.X2Y2Z2;
                dr = frm.ShowDialog();
                frm.ForceGantryMode = EForceGantryMode.None;
                #endregion
                #region Handle User Entry
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                #endregion
                d_BCamera_Cal_Needle2_Z = TaskGantry.GZ2Pos();
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                #endregion

                #region Head2 Computation
                Head2_DefPos.X = TaskGantry.GX2Pos();
                Head2_DefPos.Y = TaskGantry.GY2Pos();
                Head_Ofst[1].X = Head_Ofst[0].X - Head2_DefDistX;
                Head_Ofst[1].Y = Head_Ofst[0].Y;
                #endregion

                if (DispProg.Pump_Type == EPumpType.PP2D)
                {
                    #region Head2 Needle2
                    TPos3 H2N2 = new TPos3();
                    H2N2.X = BCamera_Cal_Pos.X + Head_Ofst[0].X - Head2_DefDistX;
                    H2N2.Y = BCamera_Cal_Pos.Y + Head_Ofst[0].Y - Head_NeedlePitchY;
                    H2N2.Z = d_H2N2TouchPos - Head_ZSensor_RefPosZ[1] + BCamera_Cal_Needle2_Z;

                    if (!MoveNeedleToBCamera("Head 2 Needle 2", H2N2.X, H2N2.Y, 0, H2N2.Z)) return false;

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
                    //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    //        return false;
                    //}
                    //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show("Check Head 2 Needle 2 Position", EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                    switch (MsgRes)
                    {
                        case EMsgRes.smrOK:
                            break;
                        case EMsgRes.smrRetry:
                            goto _RetryHead2;
                        case EMsgRes.smrCancel:
                            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                            return false;
                    }
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    #endregion
                }
            }
            else
                if (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double)
            {
                _RetryHead2:
                #region Head 2 Needle1
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                {
                    TPos3 H2N1 = new TPos3();
                    H2N1.X = BCamera_Cal_Pos.X + Head_Ofst[0].X - Head_PitchX;
                    H2N1.Y = BCamera_Cal_Pos.Y + Head_Ofst[0].Y;
                    H2N1.Z = d_H2N1TouchPos - Head_ZSensor_RefPosZ[0] + BCamera_Cal_Needle1_Z;

                    if (!MoveNeedleToBCamera("Head 2 Needle 1", H2N1.X, H2N1.Y, H2N1.Z, 0)) return false;

                    //MsgID = frm_DispCore_Msg.Page.ShowMsg("Adjust Head 2 Needle 1 Position", frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK | frm_DispCore_Msg.TMsgBtn.smbCancel);
                    //while (!frm_DispCore_Msg.Page.ShowMsgClear(MsgID))
                    //{
                    //    Application.DoEvents();
                    //}
                    //switch (frm_DispCore_Msg.Page.GetMsgRes(MsgID))
                    //{
                    //    case frm_DispCore_Msg.TMsgRes.smrOK:
                    //        break;
                    //    case frm_DispCore_Msg.TMsgRes.smrCancel:
                    //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    //        return false;
                    //}
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show("Adjust Head 2 Needle 1 Position", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                    switch (MsgRes)
                    {
                        case EMsgRes.smrOK:
                            break;
                        case EMsgRes.smrCancel:
                            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                            return false;
                    }
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                }
                #endregion

                if (DispProg.Pump_Type == EPumpType.PP2D)
                {
                    #region Head2 Needle2
                    TPos3 H2N2 = new TPos3();
                    H2N2.X = BCamera_Cal_Pos.X + Head_Ofst[0].X - Head_PitchX;
                    H2N2.Y = BCamera_Cal_Pos.Y + Head_Ofst[0].Y - Head_NeedlePitchY;
                    H2N2.Z = d_H2N2TouchPos - Head_ZSensor_RefPosZ[0] + BCamera_Cal_Needle1_Z;

                    if (!MoveNeedleToBCamera("Head 2 Needle 2", H2N2.X, H2N2.Y, H2N2.Z, 0)) return false;

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
                    //        if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    //        return false;
                    //}
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show("Check Head 2 Needle 2 Position", EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, false);
                    switch (MsgRes)
                    {
                        case EMsgRes.smrOK:
                            break;
                        case EMsgRes.smrRetry:
                            goto _RetryHead2;
                        case EMsgRes.smrCancel:
                            if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                            return false;
                    }
                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                    #endregion
                }
            }

            #region Compute Result
            Laser_RefPosZ = d_LaserValue;
            Head_ZSensor_RefPosZ[0] = (d_H1N1TouchPos + d_H1N2TouchPos) / 2;
            Head_ZSensor_RefPosZ[1] = (d_H2N1TouchPos + d_H2N2TouchPos) / 2;

            BCamera_Cal_Needle1_Z = d_BCamera_Cal_Needle1_Z;
            BCamera_Cal_Needle2_Z = d_BCamera_Cal_Needle2_Z;
            #endregion

            if (!TaskVision.LightingOn(TaskVision.DefLightRGB)) return false;
            return true;
        }
        public static bool TeachNeedleOfst_Touch_Dot_Set()
        {
            string EMsg = "Teach Needle Ofst Touch_Dot_Set";

            Event.TEACH_NEEDLE_OFST.Set("Type", "Touch_Dot_Set");

            try
            {
                switch (DispProg.Pump_Type)
                {
                    case EPumpType.HM:
                    case EPumpType.PP:
                    case EPumpType.PP2D:
                    case EPumpType.PPD:
                        #region
                        _RetryD1:
                        if (!TaskGantry.DispAReady())
                        {
                            Msg MsgBox = new Msg();
                            EMsgRes MsgRes = MsgBox.Show(ErrCode.DISPCTRL1_NOT_READY, EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, true);

                            switch (MsgRes)
                            {
                                case EMsgRes.smrOK:
                                    break;
                                case EMsgRes.smrRetry:
                                    goto _RetryD1;
                                case EMsgRes.smrCancel:
                                    return false;
                            }
                        }
                        _RetryD2:
                        if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2 &&
                            (DispProg.Head_Operation == EHeadOperation.Sync || DispProg.Head_Operation == EHeadOperation.Double) &&
                            !TaskGantry.DispBReady())
                        {
                            Msg MsgBox = new Msg();
                            EMsgRes MsgRes = MsgBox.Show(ErrCode.DISPCTRL2_NOT_READY, EMcState.Notice, EMsgBtn.smbOK_Retry_Cancel, true);

                            switch (MsgRes)
                            {
                                case EMsgRes.smrOK:
                                    break;
                                case EMsgRes.smrRetry:
                                    goto _RetryD2;
                                case EMsgRes.smrCancel:
                                    return false;
                            }
                        }
                        break;
                        #endregion
                }

                TaskDisp.FPressOn(new bool[2] { true, true });

                TPos2 _Camera_ZSensor_Pos = new TPos2(Camera_ZSensor_Pos);
                double[] _Head_ZSensor_RefPosZ = new double[2] { Head_ZSensor_RefPosZ[0], Head_ZSensor_RefPosZ[1] };
                TPos3[] _Head_Ofst = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
                _Head_Ofst[0].X = Head_Ofst[0].X;
                _Head_Ofst[0].Y = Head_Ofst[0].Y;
                _Head_Ofst[0].Z = Head_Ofst[0].Z;
                _Head_Ofst[1].X = Head_Ofst[1].X;
                _Head_Ofst[1].Y = Head_Ofst[1].Y;
                _Head_Ofst[1].Z = Head_Ofst[1].Z;

                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                #region Set Camera XY to ZSensor Loc
                #region Move Camera XY to ZSensor
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(Camera_ZSensor_Pos.X, Camera_ZSensor_Pos.Y, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
                if (!TaskGantry.WaitGXY()) return false;
                #endregion

                TaskVision.LightingOn(TaskDisp.Camera_TouchDot_LightRGB);

                #region user instruction
                {
                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                    frm.Inst = "Jog Camera XY to ZSensor Position";
                    frm.ShowVision = true;
                    frm.ForceGantryMode = EForceGantryMode.XYZ;
                    DialogResult dr = frm.ShowDialog();
                    frm.ForceGantryMode = EForceGantryMode.None;

                    if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                    if (dr == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                #endregion

                _Camera_ZSensor_Pos.X = TaskGantry.GXPos();
                _Camera_ZSensor_Pos.Y = TaskGantry.GYPos();
                TaskDisp.Camera_TouchDot_LightRGB = TaskVision.CurrentLightRGBA;
                TaskVision.LightingOff();
                #endregion

                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                #region Set Needle1 XY to ZSensor Loc, Search Needle1
                #region Move Needle XY to ZSensor
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(_Camera_ZSensor_Pos.X + Head_Ofst[0].X, _Camera_ZSensor_Pos.Y + Head_Ofst[0].Y, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
                if (!TaskGantry.WaitGXY()) return false;
                #endregion

                #region user instruction
                {
                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                    frm.Inst = "Jog Needle 1 XY to ZSensor Position";
                    frm.ShowVision = false;
                    frm.ForceGantryMode = EForceGantryMode.XYZ;
                    DialogResult dr = frm.ShowDialog();
                    frm.ForceGantryMode = EForceGantryMode.None;

                    if (dr == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                #endregion

                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();
                double Z = Head_ZSensor_RefPosZ[0];// TaskGantry.GZPos();

                double N1TouchZ = 0;
                if (!TaskZTouch.SearchNeedleZTouch("Needle1", X, Y, Z, TaskGantry.GZAxis, ref N1TouchZ)) return false;
                _Head_ZSensor_RefPosZ[0] = N1TouchZ;
                #endregion

                _Head_Ofst[0].X = X - _Camera_ZSensor_Pos.X;
                _Head_Ofst[0].Y = Y - _Camera_ZSensor_Pos.Y;

                _Retry1:
                #region Needle 1Dot
                double N1_Dot_X = X;
                double N1_Dot_Y = Y;

                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(N1_Dot_X, N1_Dot_Y, true)) return false;

                if (!TaskGantry.SetMotionParamGZ()) return false;
                if (!TaskGantry.MoveAbsGZ(_Head_ZSensor_RefPosZ[0] + TeachNeedle_NeedleGap + 1)) return false;

                if (!TaskGantry.SetMotionParam(TaskGantry.GZAxis, 1, 10, 100)) return false;
                if (!TaskGantry.MoveAbsGZ(_Head_ZSensor_RefPosZ[0] + TeachNeedle_NeedleGap)) return false;

                int t = GDefine.GetTickCount() + 100;
                while (GDefine.GetTickCount() <= t) { Thread.Sleep(0); }

                #region Dot DispA
                if (TeachNeedle_DotTime == 0) return false;

                switch (DispProg.Pump_Type)
                {
                    case TaskDisp.EPumpType.PP:
                    case TaskDisp.EPumpType.PP2D:
                    case TaskDisp.EPumpType.PPD:
                    case TaskDisp.EPumpType.Vermes:
                    case TaskDisp.EPumpType.Vermes1560:
                        if (!TaskGantry.DispAReady()) return false;
                        if (!TaskDisp.CtrlWaitReady(true, false)) return false;
                        break;
                }
                switch (DispProg.Pump_Type)
                {
                    case TaskDisp.EPumpType.PP:
                    case TaskDisp.EPumpType.PP2D:
                    case TaskDisp.EPumpType.PPD:
                        if (!TaskDisp.SetDispVolume(true, false, DispProg.PP_HeadA_BackSuckVol + TeachNeedle_DotVolume, DispProg.PP_HeadB_BackSuckVol + TeachNeedle_DotVolume)) return false;
                        break;
                    case TaskDisp.EPumpType.Vermes:
                        if (TaskDisp.Vermes3200[0].IsOpen)
                        {
                            TaskDisp.Vermes3200[0].Param.NP = 1;
                            TaskDisp.Vermes3200[0].Set(true);
                        }
                        break;
                    case TaskDisp.EPumpType.Vermes1560:
                        if (TaskDisp.Vermes1560[0].IsOpen)
                        {
                            TaskDisp.Vermes1560[0].NP[0] = 1;
                            TaskDisp.Vermes1560[0].UpdateSetup();
                        }
                        break;
                }

                if (!TrigOn(true, false)) return false;

                t = GDefine.GetTickCount() + TeachNeedle_DotTime;
                while (GDefine.GetTickCount() <= t) { }

                if (!TrigOff(true, false)) return false;

                switch (DispProg.Pump_Type)
                {
                    case TaskDisp.EPumpType.PP:
                    case TaskDisp.EPumpType.PP2D:
                    case TaskDisp.EPumpType.PPD:
                    case TaskDisp.EPumpType.Vermes:
                    case TaskDisp.EPumpType.Vermes1560:
                        if (!TaskDisp.CtrlWaitResponse(true, false)) return false;
                        if (!CtrlWaitComplete(true, false)) return false;
                        break;
                }
                #endregion

                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(N1_Dot_X - _Head_Ofst[0].X, N1_Dot_Y - _Head_Ofst[0].Y, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
                if (!TaskGantry.WaitGXY()) return false;
                #endregion

                TaskVision.LightingOn(TaskDisp.Camera_TouchDot_LightRGB);

                #region user instruction
                {
                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                    frm.Inst = "Jog Camera XY to Dot Position";
                    frm.ShowVision = true;
                    frm.ForceGantryMode = EForceGantryMode.XYZ;
                    DialogResult dr = frm.ShowDialog();
                    frm.ForceGantryMode = EForceGantryMode.None;
                    switch (dr)
                    {
                        case DialogResult.Retry:
                            goto _Retry1;
                        case DialogResult.Cancel:
                            return false;
                    }
                }
                #endregion

                TaskDisp.Camera_TouchDot_LightRGB = TaskVision.CurrentLightRGBA;

                _Head_Ofst[0].X = N1_Dot_X - TaskGantry.GXPos();
                _Head_Ofst[0].Y = N1_Dot_Y - TaskGantry.GYPos();

                if (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double)
                {
                    TaskVision.LightingOff();
                    switch (GDefine.GantryConfig)
                    {
                        case GDefine.EGantryConfig.XY_ZX2Y2_Z2:
                            #region
                            {
                                #region Move Head2 XY to Cal Pos
                                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                if (!TaskGantry.SetMotionParamGXY()) return false;
                                if (!TaskGantry.MoveAbsGXY(_Camera_ZSensor_Pos.X + _Head_Ofst[0].X - Head2_DefDistX, _Camera_ZSensor_Pos.Y + _Head_Ofst[0].Y, false)) return false;
                                if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                                if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                                if (!TaskGantry.WaitGX2Y2()) return false;
                                if (!TaskGantry.WaitGXY()) return false;
                                #endregion

                                #region user instruction
                                {
                                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                    frm.Inst = "Jog Needle 2 XY to ZSensor Position";
                                    frm.ShowVision = false;
                                    frm.ForceGantryMode = EForceGantryMode.X2Y2Z2;
                                    DialogResult dr = frm.ShowDialog();
                                    frm.ForceGantryMode = EForceGantryMode.None;

                                    if (dr == DialogResult.Cancel)
                                    {
                                        return false;
                                    }
                                }
                                #endregion

                                X = TaskGantry.GXPos();
                                Y = TaskGantry.GYPos();
                                Z = Head_ZSensor_RefPosZ[1];

                                double N2TouchZ = 0;
                                if (!TaskZTouch.SearchNeedleZTouch("Needle2", X, Y, Z, TaskGantry.GZ2Axis, ref N2TouchZ)) return false;
                                _Head_ZSensor_RefPosZ[1] = N2TouchZ;

                                _Retry2:
                                #region Needle 2 Dot
                                double N2_Dot_X = X;
                                double N2_Dot_Y = Y;

                                if (!TaskGantry.SetMotionParamGXY()) return false;
                                if (!TaskGantry.MoveAbsGXY(N2_Dot_X, N2_Dot_Y, true)) return false;

                                if (!TaskGantry.SetMotionParamGZ2()) return false;
                                if (!TaskGantry.MoveAbsGZ2(_Head_ZSensor_RefPosZ[1] + TeachNeedle_NeedleGap + 1)) return false;

                                if (!TaskGantry.SetMotionParam(TaskGantry.GZ2Axis, 1, 10, 100)) return false;
                                if (!TaskGantry.MoveAbsGZ2(_Head_ZSensor_RefPosZ[1] + TeachNeedle_NeedleGap)) return false;

                                t = GDefine.GetTickCount() + 100;
                                while (GDefine.GetTickCount() <= t) { Thread.Sleep(0); }

                                #region Dot DispB
                                if (TeachNeedle_DotTime == 0) return false;
                                switch (DispProg.Pump_Type)
                                {
                                    case TaskDisp.EPumpType.PP:
                                    case TaskDisp.EPumpType.PP2D:
                                    case TaskDisp.EPumpType.PPD:
                                    case TaskDisp.EPumpType.Vermes:
                                    case TaskDisp.EPumpType.Vermes1560:
                                        if (!TaskGantry.DispBReady()) return false;
                                        if (!TaskDisp.CtrlWaitReady(false, true)) return false;
                                        break;
                                }

                                switch (DispProg.Pump_Type)
                                {
                                    case TaskDisp.EPumpType.PP:
                                    case TaskDisp.EPumpType.PP2D:
                                    case TaskDisp.EPumpType.PPD:
                                        if (!TaskDisp.SetDispVolume(false, true, DispProg.PP_HeadA_BackSuckVol + TeachNeedle_DotVolume, DispProg.PP_HeadB_BackSuckVol + TeachNeedle_DotVolume)) return false;
                                        break;
                                    case TaskDisp.EPumpType.Vermes:
                                        if (TaskDisp.Vermes3200[1].IsOpen)
                                        {
                                            TaskDisp.Vermes3200[1].Param.NP = 1;
                                            TaskDisp.Vermes3200[1].Set();
                                        }
                                        break;
                                    case TaskDisp.EPumpType.Vermes1560:
                                        if (TaskDisp.Vermes1560[1].IsOpen)
                                        {
                                            TaskDisp.Vermes1560[1].NP[0] = 1;
                                            TaskDisp.Vermes1560[1].UpdateSetup();
                                        }
                                        break;
                                }

                                if (!TrigOn(false, true)) return false;

                                t = GDefine.GetTickCount() + TeachNeedle_DotTime;
                                while (GDefine.GetTickCount() <= t) { }

                                if (!TrigOff(false, true)) return false;
                                switch (DispProg.Pump_Type)
                                {
                                    case TaskDisp.EPumpType.PP:
                                    case TaskDisp.EPumpType.PP2D:
                                    case TaskDisp.EPumpType.PPD:
                                    case TaskDisp.EPumpType.Vermes:
                                    case TaskDisp.EPumpType.Vermes1560:
                                        if (!TaskDisp.CtrlWaitResponse(false, true)) return false;
                                        if (!CtrlWaitComplete(false, true)) return false;
                                        break;
                                }
                                #endregion

                                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                                if (!TaskGantry.SetMotionParamGXY()) return false;
                                if (!TaskGantry.MoveAbsGXY(N2_Dot_X - _Head_Ofst[0].X + Head2_DefDistX, N2_Dot_Y - _Head_Ofst[0].Y, false)) return false;
                                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                                {
                                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                                    if (!TaskGantry.WaitGX2Y2()) return false;
                                }
                                if (!TaskGantry.WaitGXY()) return false;
                                #endregion

                                TaskVision.LightingOn(TaskDisp.Camera_TouchDotSet_LightRGB);
                                TaskDisp.Camera_TouchDotSet_LightRGB = TaskVision.CurrentLightRGBA;

                                #region user instruction
                                {
                                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                    frm.Inst = "Jog Camera XY to Dot Position";
                                    frm.ShowVision = true;
                                    frm.ForceGantryMode = EForceGantryMode.XYZ;
                                    DialogResult dr = frm.ShowDialog();
                                    frm.ForceGantryMode = EForceGantryMode.None;

                                    //if (dr == DialogResult.Cancel)
                                    //{
                                    //    return false;
                                    //}
                                    switch (dr)
                                    {
                                        case DialogResult.Retry:
                                            goto _Retry2;
                                        case DialogResult.Cancel:
                                            return false;
                                    }
                                }
                                #endregion

                                X = TaskGantry.GXPos();
                                Y = TaskGantry.GYPos();

                                double Head2_Correct_X = X - (N2_Dot_X - _Head_Ofst[0].X + Head2_DefDistX);
                                double Head2_Correct_Y = Y - (N2_Dot_Y - _Head_Ofst[0].Y);

                                double X2 = TaskGantry.GX2Pos();
                                double Y2 = TaskGantry.GY2Pos();

                                Head2_DefPos.X = X2 - Head2_Correct_X;
                                Head2_DefPos.Y = Y2 - Head2_Correct_Y;
                                break;
                            }
                        #endregion
                        case GDefine.EGantryConfig.XYZ:
                            #region
                            {
                                #region Move Head2 XY to Cal Pos
                                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                if (!TaskGantry.SetMotionParamGXY()) return false;
                                if (!TaskGantry.MoveAbsGXY(_Camera_ZSensor_Pos.X + _Head_Ofst[0].X - Head_PitchX, _Camera_ZSensor_Pos.Y + _Head_Ofst[0].Y, false)) return false;
                                //if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                                //if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                                //if (!TaskGantry.WaitGX2Y2()) return false;
                                if (!TaskGantry.WaitGXY()) return false;
                                #endregion

                                #region user instruction
                                {
                                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                    frm.Inst = "Adjust Needle 2 XY to ZSensor Position";
                                    frm.ShowVision = false;
                                    frm.ForceGantryMode = EForceGantryMode.X2Y2Z2;
                                    DialogResult dr = frm.ShowDialog();
                                    frm.ForceGantryMode = EForceGantryMode.None;

                                    if (dr == DialogResult.Cancel)
                                    {
                                        return false;
                                    }
                                }
                                #endregion

                                X = TaskGantry.GXPos();
                                Y = TaskGantry.GYPos();
                                Z = Head_ZSensor_RefPosZ[0];

                                _RetryTouch2:
                                double N2TouchZ = 0;
                                if (!TaskZTouch.SearchNeedleZTouch("Needle2", X, Y, Z, TaskGantry.GZAxis, ref N2TouchZ)) return false;
                                _Head_ZSensor_RefPosZ[1] = N2TouchZ;

                                if (Math.Abs(N2TouchZ - N1TouchZ) > MultiHead_ZTol)
                                #region user instruction
                                {
                                    double d = N2TouchZ - N1TouchZ;
                                    double a = d / 0.5;
                                    string dir = "CW";
                                    if (a < 0) dir = "CCW";

                                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                    frm.Inst = "Needle 2 Z Offset " + d.ToString("f3") + (char)13 +
                                        "Adjust " + dir + " " + Math.Abs(a).ToString("f1") + " turns.";
                                    frm.ShowVision = false;
                                    frm.ForceGantryMode = EForceGantryMode.XYZ;
                                    DialogResult dr = frm.ShowDialog();
                                    frm.ForceGantryMode = EForceGantryMode.None;

                                    switch (dr)
                                    {
                                        case DialogResult.OK:
                                            if (Math.Abs(d) > MultiHead_ZTol) goto _RetryTouch2;
                                            break;
                                        case DialogResult.Cancel:
                                            return false;
                                        case DialogResult.Retry:
                                            goto _RetryTouch2;
                                    }
                                }
                                #endregion

                                _Retry2:
                                #region Needle 2 Dot
                                double N2_Dot_X = X;
                                double N2_Dot_Y = Y;

                                if (!TaskGantry.SetMotionParamGXY()) return false;
                                if (!TaskGantry.MoveAbsGXY(N2_Dot_X, N2_Dot_Y, true)) return false;

                                if (!TaskGantry.SetMotionParamGZ()) return false;
                                if (!TaskGantry.MoveAbsGZ(_Head_ZSensor_RefPosZ[0] + TeachNeedle_NeedleGap + 1)) return false;

                                if (!TaskGantry.SetMotionParam(TaskGantry.GZAxis, 1, 10, 100)) return false;
                                if (!TaskGantry.MoveAbsGZ(_Head_ZSensor_RefPosZ[0] + TeachNeedle_NeedleGap)) return false;

                                t = GDefine.GetTickCount() + 100;
                                while (GDefine.GetTickCount() <= t) { Thread.Sleep(0); }

                                #region Dot DispB
                                if (TeachNeedle_DotTime == 0) return false;

                                switch (DispProg.Pump_Type)
                                {
                                    case TaskDisp.EPumpType.PP:
                                    case TaskDisp.EPumpType.PP2D:
                                    case TaskDisp.EPumpType.PPD:
                                    case TaskDisp.EPumpType.Vermes:
                                    case TaskDisp.EPumpType.Vermes1560:
                                        if (!TaskGantry.DispBReady()) return false;
                                        if (!TaskDisp.CtrlWaitReady(false, true)) return false;
                                        break;
                                }

                                switch (DispProg.Pump_Type)
                                {
                                    case TaskDisp.EPumpType.PP:
                                    case TaskDisp.EPumpType.PP2D:
                                    case TaskDisp.EPumpType.PPD:
                                        if (!TaskDisp.SetDispVolume(false, true, DispProg.PP_HeadA_BackSuckVol + TeachNeedle_DotVolume, DispProg.PP_HeadB_BackSuckVol + TeachNeedle_DotVolume)) return false;
                                        break;
                                    case TaskDisp.EPumpType.Vermes:
                                        if (TaskDisp.Vermes3200[1].IsOpen)
                                        {
                                            TaskDisp.Vermes3200[1].Param.NP = 1;
                                            TaskDisp.Vermes3200[1].Set();
                                        }
                                        break;
                                    case TaskDisp.EPumpType.Vermes1560:
                                        if (TaskDisp.Vermes1560[1].IsOpen)
                                        {
                                            TaskDisp.Vermes1560[1].NP[0] = 1;
                                            TaskDisp.Vermes1560[1].UpdateSetup();
                                        }
                                        break;
                                }

                                if (!TrigOn(false, true)) return false;

                                t = GDefine.GetTickCount() + TeachNeedle_DotTime;
                                while (GDefine.GetTickCount() <= t) { }

                                if (!TrigOff(false, true)) return false;

                                switch (DispProg.Pump_Type)
                                {
                                    case TaskDisp.EPumpType.PP:
                                    case TaskDisp.EPumpType.PP2D:
                                    case TaskDisp.EPumpType.PPD:
                                    case TaskDisp.EPumpType.Vermes:
                                    case TaskDisp.EPumpType.Vermes1560:
                                        if (!TaskDisp.CtrlWaitResponse(false, true)) return false;
                                        if (!CtrlWaitComplete(false, true)) return false;
                                        break;
                                }
                                #endregion

                                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                                if (!TaskGantry.SetMotionParamGXY()) return false;
                                if (!TaskGantry.MoveAbsGXY(N2_Dot_X - _Head_Ofst[0].X + Head_PitchX, N2_Dot_Y - _Head_Ofst[0].Y, false)) return false;
                                if (!TaskGantry.WaitGXY()) return false;
                                #endregion

                                TaskVision.LightingOn(TaskDisp.Camera_TouchDotSet_LightRGB);
                                TaskDisp.Camera_TouchDotSet_LightRGB = TaskVision.CurrentLightRGBA;

                                #region user instruction
                                {
                                    frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                    frm.Inst = "Adjust Needle 2 XY to Crosshair Position";
                                    frm.ShowVision = true;
                                    frm.ForceGantryMode = EForceGantryMode.XYZ;
                                    DialogResult dr = frm.ShowDialog();
                                    frm.ForceGantryMode = EForceGantryMode.None;

                                    //if (dr == DialogResult.Cancel)
                                    //{
                                    //    return false;
                                    //}
                                    switch (dr)
                                    {
                                        case DialogResult.Retry:
                                            goto _Retry2;
                                        case DialogResult.Cancel:
                                            return false;
                                    }
                                }
                                #endregion

                                X = TaskGantry.GXPos();
                                Y = TaskGantry.GYPos();

                                _Head_Ofst[1].X = _Head_Ofst[0].X - Head_PitchX;
                                _Head_Ofst[1].Y = _Head_Ofst[0].Y;
                                _Head_Ofst[1].Z = _Head_Ofst[0].Z;
                                break;
                            }
                            #endregion
                    }
                }

                Event.SETUP_HEAD1_OFST_UPDATE.Set("HeadOffset", Head_Ofst[0].X.ToString("f3") + "," + Head_Ofst[0].Y.ToString("f3"));
                if (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double)
                {
                    Event.SETUP_HEAD2_OFST_UPDATE.Set("Head2Offset", Head_Ofst[1].X.ToString("f3") + "," + Head_Ofst[1].Y.ToString("f3"));
                }

                if (TaskDisp.Head_Ofst_XY_Tol > 0)
                {
                    double deltaX = _Head_Ofst[0].X - Head_Ofst[0].X;
                    double deltaY = _Head_Ofst[0].Y - Head_Ofst[0].Y;
                    if (Math.Abs(deltaX) >= TaskDisp.Head_Ofst_XY_Tol || Math.Abs(deltaX) >= TaskDisp.Head_Ofst_XY_Tol)
                    {
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show("Head1 Offset Changes " + deltaX.ToString("f3") + "," + deltaY.ToString("f3") + " exceed tolerance.", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                        switch (MsgRes)
                        {
                            case EMsgRes.smrOK:
                                break;
                            case EMsgRes.smrCancel:
                                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                                return false;
                        }
                    }
                }
                #region Computation
                Camera_ZSensor_Pos.X = _Camera_ZSensor_Pos.X;
                Camera_ZSensor_Pos.Y = _Camera_ZSensor_Pos.Y;
                Head_ZSensor_RefPosZ[0] = _Head_ZSensor_RefPosZ[0];
                Head_ZSensor_RefPosZ[1] = _Head_ZSensor_RefPosZ[1];
                Head_Ofst[0] = new TPos3(_Head_Ofst[0]);
                Head_Ofst[1] = new TPos3(_Head_Ofst[1]);
                #endregion
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            finally
            {
                TaskDisp.FPressOff();
            }
            return true;
        }

        public static bool TaskCalLaserOfstPoint()
        {
            string EMsg = "Cal Laser Ofst Point";

            try
            {
                #region Teach Camera Position
                //if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                //if (!TaskDisp.TaskMoveAbsGZ(DispProg.CameraZPos)) return false;
                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                #region Move Camera XY to ZSensor
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(Camera_ZSensor_Pos.X, Camera_ZSensor_Pos.Y, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
                if (!TaskGantry.WaitGXY()) return false;
                #endregion

                TaskVision.LightingOn(TaskDisp.Camera_LaserOfst_LightRGB);
                #region user instruction
                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Camera XY to Crosshair Position";
                frm.ShowVision = true;
                frm.ForceGantryMode = EForceGantryMode.XYZ;
                DialogResult dr = frm.ShowDialog();
                frm.ForceGantryMode = EForceGantryMode.None;
                #endregion
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                #region handle user entry
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                #endregion
                TaskDisp.Camera_LaserOfst_LightRGB = TaskVision.CurrentLightRGBA;
                TaskVision.LightingOn(TaskVision.DefLightRGB);
                #endregion

                double CX = TaskGantry.GXPos();
                double CY = TaskGantry.GYPos();

                double LaserPosX = 0;
                double LaserPosY = 0;
                //double LaserZValue = 0;

                #region Teach Laser Position
                //if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
                //{
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(CX + Laser_Ofst.X, CY + Laser_Ofst.Y)) return false;

                frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Laser XY to CrossHair Position";
                frm.ShowVision = false;
                dr = frm.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }

                LaserPosX = TaskGantry.GXPos();
                LaserPosY = TaskGantry.GYPos();
                //double i = 0;
                //if (!TaskLaser.GetHeight(ref i)) return false;
                //LaserZValue = i;

                //string s = (LaserPosX - CX).ToString("f3") + "," + (LaserPosY - CY).ToString("f3") + "/" + LaserZValue.ToString("f4");
                //Event.Log("Laser Ofst/Laser Value", s);
                string s = (LaserPosX - CX).ToString("f3") + "," + (LaserPosY - CY).ToString("f3");
                Event.SETUP_LASER_OFST_UPDATE.Set("LaserOffset", s);

                _RetryLaser:
                int t = GDefine.GetTickCount() + TaskLaser.SettleTime;
                while (GDefine.GetTickCount() < t) { Thread.Sleep(1); }

                double d_ZSensor_LaserZ_Old = TaskDisp.Laser_RefPosZ;
                double d_ZSensor_LaserZ_New = TaskDisp.Laser_RefPosZ;
                if (!TaskLaser.GetHeight(ref d_ZSensor_LaserZ_New)) return false;

                switch (ValidateLaserChangeRate(d_ZSensor_LaserZ_Old, d_ZSensor_LaserZ_New))
                {
                    case EAction.Accept:
                        break;
                    case EAction.Retry:
                        goto _RetryLaser;
                    case EAction.Stop:
                        return false;
                }
                TaskDisp.Laser_RefPosZ = d_ZSensor_LaserZ_New;
                Event.SETUP_REFZ_UPDATE.Set("RefPos", d_ZSensor_LaserZ_New.ToString("f3"));

                #endregion

                double TouchZ1 = 0;
                #region Search Needle1
                if (!SetNeedle("Needle 1", CX + Head_Ofst[0].X, CY + Head_Ofst[0].Y, Head_ZSensor_RefPosZ[0], TaskGantry.GZAxis, ref TouchZ1)) return false;
                #endregion

                #region Computation
                Camera_ZSensor_Pos.X = CX;
                Camera_ZSensor_Pos.Y = CY;

                Head_ZSensor_RefPosZ_Setup[0] = TouchZ1;
                Head_ZSensor_RefPosZ[0] = Head_ZSensor_RefPosZ_Setup[0];
                //Head_Ofst_Setup[0].Z = 0;
                //Head_Ofst[0].Z = Head_Ofst_Setup[0].Z;
                Head_Ofst[0].Z = 0;

                Laser_Ofst_Setup.X = LaserPosX - CX;
                Laser_Ofst.X = Laser_Ofst_Setup.X;
                Laser_Ofst_Setup.Y = LaserPosY - CY;
                Laser_Ofst.Y = Laser_Ofst_Setup.Y;
                #endregion

                double TouchZ2 = 0;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                    {
                        if (!SetNeedle("Needle 2", CX + Head_Ofst[0].X - Head2_DefDistX, CY + Head_Ofst[0].Y, Head_ZSensor_RefPosZ[1], TaskGantry.GZ2Axis, ref TouchZ2)) return false;
                    }
                }
                else
                {
                    if (GDefine.HeadConfig == GDefine.EHeadConfig.Dual)
                    {

                        if (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double)
                        {
                            if (!GotoNeedle("Needle 2", CX + Head_Ofst[0].X - Head_PitchX, CY + Head_Ofst[0].Y, Head_ZSensor_RefPosZ[0], TaskGantry.GZAxis)) return false;
                        }
                    }
                }


                #region Computation
                Head_ZSensor_RefPosZ_Setup[1] = TouchZ2;
                Head_ZSensor_RefPosZ[1] = Head_ZSensor_RefPosZ_Setup[1];
                //Head_Ofst_Setup[1].Z = 0;
                //Head_Ofst[1].Z = Head_Ofst_Setup[1].Z;
                Head_Ofst[1].Z = 0;
                #endregion
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        public static bool TaskCalLaserOfstEdge()
        {
            string EMsg = "Cal Laser Ofst Search";

            try
            {
                #region Teach Camera Position
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                #region Move Camera XY to ZSensor
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(Camera_ZSensor_Pos.X, Camera_ZSensor_Pos.Y, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
                if (!TaskGantry.WaitGXY()) return false;
                #endregion

                TaskVision.LightingOn(TaskDisp.Camera_LaserOfst_LightRGB);
                #region user instruction
                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Camera XY to Crosshair Position";
                frm.ShowVision = true;
                frm.ForceGantryMode = EForceGantryMode.XYZ;
                DialogResult dr = frm.ShowDialog();
                frm.ForceGantryMode = EForceGantryMode.None;
                #endregion
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                #region handle user entry
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                #endregion
                //TaskDisp.Camera_Cal_LightRGB = TaskVision.CurrentLightRGBA;
                TaskVision.LightingOff();
                //LightingTaskVision.DefLightRGB);
                #endregion

                double CX = TaskGantry.GXPos();
                double CY = TaskGantry.GYPos();

                //#region Teach Laser Position
                //if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
                //{
                TaskLaser.TrigMode = false;

                #region Move Laser to ZSensor Pos
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(CX + Laser_Ofst.X, CY + Laser_Ofst.Y)) return false;
                #endregion

                frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Laser XY to CrossHair Position";
                frm.ShowVision = false;
                dr = frm.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                double LaserPosX = TaskGantry.GXPos();
                double LaserPosY = TaskGantry.GYPos();

                int t = GDefine.GetTickCount() + TaskVision.SettleTime;
                while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                double Ref_Height = 0;
                if (!TaskLaser.GetHeight(ref Ref_Height)) return false;


                double d_SearchSpeed = 2.5;
                List<double> XEdge = new List<double>();
                List<double> YEdge = new List<double>();

                double d_DetectDelta = 0.25;
                #region Find Edges
                for (int i = 0; i < 4; i++)//***dir XP,YP,XN,YN
                {
                    double X_Dist = 0;
                    double Y_Dist = 0;
                    #region define search distance
                    switch (i)
                    {
                        case 0:
                            X_Dist = 6;
                            Y_Dist = 0;
                            break;
                        case 1:
                            X_Dist = 0;
                            Y_Dist = 6;
                            break;
                        case 2:
                            X_Dist = -6;
                            Y_Dist = 0;
                            break;
                        case 3:
                            X_Dist = 0;
                            Y_Dist = -6;
                            break;
                    }
                    #endregion

                    if (!TaskGantry.SetMotionParamGXY()) return false;
                    if (!TaskGantry.MoveAbsGXY(LaserPosX, LaserPosY)) return false;

                    int tt = GDefine.GetTickCount() + TaskLaser.SettleTime;
                    while (GDefine.GetTickCount() < tt) { Thread.Sleep(1); }

                    if (!TaskLaser.GetHeight(ref Ref_Height))
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.LASER_OUT_OF_RANGE_ERR);
                        return false;
                    }

                    if (i == 0 || i == 2)
                    {
                        #region Search X dir
                        TaskGantry.SetMotionParam(TaskGantry.GXAxis, d_SearchSpeed, d_SearchSpeed, TaskGantry.GXAxis.Para.Accel);
                        if (!TaskGantry.MovePtpAbs(TaskGantry.GXAxis, LaserPosX + X_Dist)) return false;

                        while (TaskGantry.AxisBusy(TaskGantry.GXAxis))
                        {
                            double Height = 0;
                            TaskLaser.GetHeight(ref Height, false);

                            if (Math.Abs(Height - Ref_Height) > d_DetectDelta)
                            {
                                double X = TaskGantry.GXPos();
                                XEdge.Add(X);
                                break;
                            }
                        }

                        if (!TaskGantry.AxisBusy(TaskGantry.GXAxis))
                        {
                            TaskGantry.ForceStop(TaskGantry.GXAxis);
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.LASER_SEARCH_ERR);
                            return false;
                        }

                        TaskGantry.ForceStop(TaskGantry.GXAxis);
                        #endregion
                    }
                    if (i == 1 || i == 3)
                    {
                        #region Search Y dir
                        TaskGantry.SetMotionParam(TaskGantry.GYAxis, d_SearchSpeed, d_SearchSpeed, TaskGantry.GXAxis.Para.Accel);
                        if (!TaskGantry.MovePtpAbs(TaskGantry.GYAxis, LaserPosY + Y_Dist)) return false;

                        while (TaskGantry.AxisBusy(TaskGantry.GYAxis))
                        {
                            double Height = 0;
                            TaskLaser.GetHeight(ref Height, false);

                            if (Math.Abs(Height - Ref_Height) > d_DetectDelta)
                            {
                                double Y = TaskGantry.GYPos();
                                YEdge.Add(Y);
                                break;
                            }
                        }

                        if (!TaskGantry.AxisBusy(TaskGantry.GYAxis))
                        {
                            TaskGantry.ForceStop(TaskGantry.GYAxis);
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.LASER_SEARCH_ERR);
                            return false;
                        }

                        TaskGantry.ForceStop(TaskGantry.GYAxis);
                        #endregion
                    }

                    while (TaskGantry.IsBusyGXY())
                    {
                        Application.DoEvents();
                        Thread.Sleep(0);
                    }
                }
                #endregion

                double LaserPos_X = XEdge.Average();
                double LaserPos_Y = YEdge.Average();

                #region Move to Laser Pos, Get LaserZValue
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(LaserPos_X, LaserPos_Y)) return false;
                //if (!TaskGantry.AxesWait(TaskGantry.GXAxis, TaskGantry.GYAxis))

                //double d_LaserZValue = 0;
                //if (!TaskLaser.GetHeight(ref d_LaserZValue))
                //{
                //    Msg MsgBox = new Msg();
                //    MsgBox.Show(ErrCode.LASER_OUT_OF_RANGE_ERR);
                //    return false;
                //}

                _RetryLaser:
                t = GDefine.GetTickCount() + TaskLaser.SettleTime;
                while (GDefine.GetTickCount() < t) { Thread.Sleep(1); }

                double d_ZSensor_LaserZ_Old = TaskDisp.Laser_RefPosZ;
                double d_ZSensor_LaserZ_New = TaskDisp.Laser_RefPosZ;
                if (!TaskLaser.GetHeight(ref d_ZSensor_LaserZ_New)) return false;

                switch (ValidateLaserChangeRate(d_ZSensor_LaserZ_Old, d_ZSensor_LaserZ_New))
                {
                    case EAction.Accept:
                        break;
                    case EAction.Retry:
                        goto _RetryLaser;
                    case EAction.Stop:
                        return false;
                }
                TaskDisp.Laser_RefPosZ = d_ZSensor_LaserZ_New;
                Event.SETUP_REFZ_UPDATE.Set("RefPos", d_ZSensor_LaserZ_New.ToString("f3"));
                #endregion

                TaskDisp.Camera_LaserOfst_LightRGB = TaskVision.CurrentLightRGBA;
                TaskVision.LightingOn(TaskVision.DefLightRGB);

                #region Computation
                Camera_ZSensor_Pos.X = CX;
                Camera_ZSensor_Pos.Y = CY;

                Laser_Ofst_Setup.X = LaserPos_X - CX;
                Laser_Ofst.X = Laser_Ofst_Setup.X;
                Laser_Ofst_Setup.Y = LaserPos_Y - CY;
                Laser_Ofst.Y = Laser_Ofst_Setup.Y;
                //Laser_RefPosZ = d_LaserZValue;
                #endregion
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }

        public static bool TaskCalTempSensorOfstPoint()
        {
            string EMsg = "Cal Temp Sensor Ofst Point";

            try
            {
                #region Teach Camera Position
                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                #region Move Camera XY to ZSensor
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(TempSensor_Cal_Pos.X, TempSensor_Cal_Pos.Y, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
                if (!TaskGantry.WaitGXY()) return false;
                #endregion

                TaskVision.LightingOn(TaskDisp.TempSensor_Cal_LightRGB);

                #region user instruction
                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Camera XY to Cal Position";
                frm.ShowVision = true;
                frm.ForceGantryMode = EForceGantryMode.XYZ;
                DialogResult dr = frm.ShowDialog();
                frm.ForceGantryMode = EForceGantryMode.None;
                #endregion

                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                TaskDisp.TempSensor_Cal_LightRGB = TaskVision.CurrentLightRGBA;
                TaskVision.LightingOn(TaskVision.DefLightRGB);
                #endregion


                double cX = TaskGantry.GXPos();
                double cY = TaskGantry.GYPos();

                #region Teach TmepSensor Position
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(cX + TempSensor_Ofst.X, cY + TempSensor_Ofst.Y)) return false;

                frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Temp Sensor to Cal Position";
                frm.ShowVision = false;
                dr = frm.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                #endregion

                TempSensor_Cal_Pos = new TPos2(cX, cY);

                double temp = 0;
                TFTempSensor.GetTemp(ref temp);
                Event.SETUP_TEMPSENSOR_OFST_UPDATE.Set("Value", $"{temp}");

                TPos2 tempCalPos = new TPos2(TaskGantry.GXPos(), TaskGantry.GYPos());
                TempSensor_Ofst = new TPos2(tempCalPos.X - cX, tempCalPos.Y - cY);
                Event.SETUP_TEMPSENSOR_OFST_UPDATE.Set("TempSensorOffset", $"{TempSensor_Ofst.X:f3},{TempSensor_Ofst.Y:f3}");
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        public static bool TaskCalTempSensorOfstEdge()
        {
            string EMsg = "Cal Temp Sensor Ofst Search";

            try
            {
                #region Teach Camera Position
                if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                #region Move Camera XY to ZSensor
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(TempSensor_Cal_Pos.X, TempSensor_Cal_Pos.Y, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y, false)) return false;
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
                if (!TaskGantry.WaitGXY()) return false;
                #endregion

                TaskVision.LightingOn(TaskDisp.TempSensor_Cal_LightRGB);

                #region user instruction
                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Camera XY to Cal Position";
                frm.ShowVision = true;
                frm.ForceGantryMode = EForceGantryMode.XYZ;
                DialogResult dr = frm.ShowDialog();
                frm.ForceGantryMode = EForceGantryMode.None;
                #endregion

                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                TaskDisp.TempSensor_Cal_LightRGB = TaskVision.CurrentLightRGBA;
                TaskVision.LightingOn(TaskVision.DefLightRGB);
                #endregion


                double cXcam = TaskGantry.GXPos();
                double cYcam = TaskGantry.GYPos();

                #region Teach TempSensor Position
                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(cXcam + TempSensor_Ofst.X, cYcam + TempSensor_Ofst.Y)) return false;

                frm = new frm_DispCore_JogGantryVision();
                frm.Inst = "Jog Temp Sensor to Cal Position";
                frm.ShowVision = false;
                dr = frm.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                #endregion

                double refTemp = 0;
                TFTempSensor.GetTemp(ref refTemp);

                double d_SearchSpeed = 2.5;
                List<double> XEdge = new List<double>();
                List<double> YEdge = new List<double>();

                double d_DetectDelta = 0.5;//changes 2 C

                double cX = TaskGantry.GXPos();
                double cY = TaskGantry.GYPos();

                #region Find Edges
                for (int i = 0; i < 4; i++)//***dir XP,YP,XN,YN
                {
                    double X_Dist = 0;
                    double Y_Dist = 0;
                    #region define search distance
                    switch (i)
                    {
                        case 0:
                            X_Dist = 6;
                            Y_Dist = 0;
                            break;
                        case 1:
                            X_Dist = 0;
                            Y_Dist = 6;
                            break;
                        case 2:
                            X_Dist = -6;
                            Y_Dist = 0;
                            break;
                        case 3:
                            X_Dist = 0;
                            Y_Dist = -6;
                            break;
                    }
                    #endregion

                    if (!TaskGantry.SetMotionParamGXY()) return false;
                    if (!TaskGantry.MoveAbsGXY(cX, cY)) return false;

                    int tt = GDefine.GetTickCount() + TaskLaser.TempSensor_SettleTime;
                    while (GDefine.GetTickCount() < tt) { Thread.Sleep(1); }

                    TFTempSensor.GetTemp(ref refTemp);

                    if (i == 0 || i == 2)
                    {
                        #region Search X dir
                        TaskGantry.SetMotionParam(TaskGantry.GXAxis, d_SearchSpeed, d_SearchSpeed, TaskGantry.GXAxis.Para.Accel);
                        if (!TaskGantry.MovePtpAbs(TaskGantry.GXAxis, cX + X_Dist)) return false;

                        while (TaskGantry.AxisBusy(TaskGantry.GXAxis))
                        {
                            double temp = 0;
                            //TaskLaser.GetHeight(ref Height, false);
                            TFTempSensor.GetTemp(ref temp);

                            if (Math.Abs(temp - refTemp) > d_DetectDelta)
                            {
                                double X = TaskGantry.GXPos();
                                XEdge.Add(X);
                                break;
                            }
                        }

                        if (!TaskGantry.AxisBusy(TaskGantry.GXAxis))
                        {
                            TaskGantry.ForceStop(TaskGantry.GXAxis);
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.TEMPSENSOR_SEARCH_FAIL);
                            return false;
                        }

                        TaskGantry.ForceStop(TaskGantry.GXAxis);
                        #endregion
                    }
                    if (i == 1 || i == 3)
                    {
                        #region Search Y dir
                        TaskGantry.SetMotionParam(TaskGantry.GYAxis, d_SearchSpeed, d_SearchSpeed, TaskGantry.GXAxis.Para.Accel);
                        if (!TaskGantry.MovePtpAbs(TaskGantry.GYAxis, cY + Y_Dist)) return false;

                        while (TaskGantry.AxisBusy(TaskGantry.GYAxis))
                        {
                            double Height = 0;
                            TaskLaser.GetHeight(ref Height, false);
                            double temp = 0;
                            TFTempSensor.GetTemp(ref temp);

                            if (Math.Abs(temp - refTemp) > d_DetectDelta)
                            {
                                double Y = TaskGantry.GYPos();
                                YEdge.Add(Y);
                                break;
                            }
                        }

                        if (!TaskGantry.AxisBusy(TaskGantry.GYAxis))
                        {
                            TaskGantry.ForceStop(TaskGantry.GYAxis);
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.TEMPSENSOR_SEARCH_FAIL);
                            return false;
                        }

                        TaskGantry.ForceStop(TaskGantry.GYAxis);
                        #endregion
                    }

                    while (TaskGantry.IsBusyGXY())
                    {
                        Application.DoEvents();
                        Thread.Sleep(0);
                    }
                }
                #endregion

                cX = XEdge.Average();
                cY = YEdge.Average();

                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(cX, cY)) return false;

                TempSensor_Cal_Pos = new TPos2(cXcam, cYcam);

                TPos2 tempCalPos = new TPos2(TaskGantry.GXPos(), TaskGantry.GYPos());
                //TempSensor_Ofst = new TPos2(cX - cXcam, cY - cYcam);
                //Event.SETUP_TEMPSENSOR_OFST_UPDATE.Set("TempSensorOffset", $"{TempSensor_Ofst.X:f3},{TempSensor_Ofst.Y:f3}");
                TempSensor_Ofst = new TPos2(cX - cXcam, cY - cYcam);
                Event.SETUP_TEMPSENSOR_OFST_UPDATE.Set("TempSensorOffset", $"{TempSensor_Ofst.X:f3},{TempSensor_Ofst.Y:f3}");
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }



        private enum EAction { Accept, Retry, Stop };
        private static EAction ValidateLaserChangeRate(double OldValue, double NewValue)
        {
            if (TaskDisp.TeachNeedle_LaserChangeRate == 0) return EAction.Accept;

            double ChangeRate = NewValue - OldValue;
            if (Math.Abs(ChangeRate) >= TaskDisp.TeachNeedle_LaserChangeRate)
            {
                Msg MsgBox = new Msg();
                EMsgRes Res = MsgBox.Show("Exceed Laser Height Change Rate " + ChangeRate.ToString("f3") + " Old/New " + OldValue.ToString("F3") + "/" + NewValue.ToString("f3") + " mm.",
                    "OK - Accept change. @Retry - Retry Laser. @Cancel - Abort.", "",
                    EMcState.Warning, EMsgBtn.smbOK_Retry_Cancel, false);

                switch (Res)
                {
                    case EMsgRes.smrOK: return EAction.Accept;
                    case EMsgRes.smrRetry: return EAction.Retry;
                    default:
                    case EMsgRes.smrCancel: return EAction.Stop;
                }
            }

            return EAction.Accept;
        }

        public static bool TaskTeachNeedle_Laser_Touch_Dot_Set()
        {
            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (GDefine.HSensorType > GDefine.EHeightSensorType.None)
            {
                #region Move to Laser Pos, Get LaserTouchZValue
                TPos3 XY = new TPos3(Camera_ZSensor_Pos.X + Laser_Ofst.X, Camera_ZSensor_Pos.Y + Laser_Ofst.Y, 0);
                if (!GotoXYPos(XY, Head2_DefPos)) return false;

                if (TaskDisp.TeachNeedle_LaserPromptCleanStage)
                {
                    DefineSafety.DoorLock = false;
                    #region

                    //#region Check Condition
                    switch (GDefine.ZSensorType)
                    {
                        default:
                        case GDefine.EZSensorType.Sensor:
                            break;
                        case GDefine.EZSensorType.Encoder:
                            try
                            {
                                 if (!TaskZTouch.WaitTouchStageCleaned()) return false;
                            }
                            catch { }
                            break;
                    }
                    #endregion
                    if (!TaskGantry.CheckDoorSw()) return false;
                    DefineSafety.DoorLock = true;
                }

                _RetryLaser:
                int t = GDefine.GetTickCount() + TaskLaser.SettleTime;
                while (GDefine.GetTickCount() < t) { Thread.Sleep(1); }

                double d_ZSensor_LaserZ_Old = TaskDisp.Laser_RefPosZ;
                double d_ZSensor_LaserZ_New = TaskDisp.Laser_RefPosZ;
                if (!TaskLaser.GetHeight(ref d_ZSensor_LaserZ_New)) return false;

                switch (ValidateLaserChangeRate(d_ZSensor_LaserZ_Old, d_ZSensor_LaserZ_New))
                {
                    case EAction.Accept:
                        break;
                    case EAction.Retry:
                        goto _RetryLaser;
                    case EAction.Stop:
                        return false;
                }
                TaskDisp.Laser_RefPosZ = d_ZSensor_LaserZ_New;
                Event.SETUP_REFZ_UPDATE.Set("RefPos", d_ZSensor_LaserZ_New.ToString("f3"));
                #endregion
            }

            if (!TeachNeedleOfst_Touch_Dot_Set()) return false;

            return true;
        }

        public static bool DispTool_TeachNeedle()
        {
            if (!TaskGantry.CheckDoorSw()) return false;

            bool OK = false;
            switch (TaskDisp.TeachNeedle_Method)
            {
                case TaskDisp.ETeachNeedleMethod.ZSensor_Mark_Set:
                    OK = TaskDisp.TaskTeachNeedle_ZSensor_Mark();
                    break;
                case TaskDisp.ETeachNeedleMethod.ZSensor_BCamera:
                    //return 
                    OK = TaskDisp.TaskTeachNeedle_ZSensor_BCamera();
                    break;
                case TaskDisp.ETeachNeedleMethod.StepByStep:
                    //frm_TeachNeedle_StepByStep frm = new frm_TeachNeedle_StepByStep();
                    //return
                    //OK = frm.ShowDialog() == DialogResult.OK;
                    MessageBox.Show("Function not Supported.");
                    break;
                case TaskDisp.ETeachNeedleMethod.Laser_CrossHair:
                    frm_TeachNeedle_LaserCrosshair frm2 = new frm_TeachNeedle_LaserCrosshair();
                    //return
                    OK = frm2.ShowDialog() == DialogResult.OK;
                    break;
                case TaskDisp.ETeachNeedleMethod.Laser_ZSensor_Dot_Set:
                    //return
                    DefineSafety.DoorLock = true;
                    OK = TaskDisp.TaskTeachNeedle_Laser_Touch_Dot_Set();
                    DefineSafety.DoorLock = false;
                    break;
            }

            TaskDisp.TeachNeedle_Completed = OK;

            return OK;
        }

        public static double Z1Offset
        {
            get
            {
                //return Head_ZSensor_RefPosZ[0] - Head_ZSensor_RefPosZ_Setup[0];
                return Head_ZSensor_RefPosZ[0] - Head_ZSensor_RefPosZ_Setup[0];
            }
        }
        public static double Z2Offset
        {
            get
            {
                return Head_ZSensor_RefPosZ[1] - Head_ZSensor_RefPosZ_Setup[1];
            }
        }

        /// <summary>
        /// Move Z to ZDefPos if not at Home Sensor position. 
        /// </summary>
        /// <returns></returns>
        public static bool TaskMoveGZUp()
        {
            string EMsg = "TaskMoveGZUp";

            GDefine.Status = EStatus.Busy;

            try
            {
                if (TaskGantry.SensHome(TaskGantry.GZAxis)) goto _End;

                if (!TaskGantry.SetMotionParamGZZ2()) return false;
                if (!TaskGantry.MoveAbsGZ(TaskDisp.ZDefPos)) return false;

                int t = GDefine.GetTickCount() + MoveZUp_TimeOut;
                while (!TaskGantry.SensHome(TaskGantry.GZAxis))
                {
                    if (GDefine.GetTickCount() >= t)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.GZ_MOVE_TO_HOME_SENSOR_FAIL, EMsg, true);
                        return false;
                    }
                }

                _End:
                if (TaskGantry.GZPos() < 0)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.ABNORMAL_MOTOR_POSITION_ERROR, "GZ", true);
                    GDefine.Status = EStatus.ErrorInit;
                    return false;
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            };

            GDefine.Status = EStatus.Ready;
            return true;
        }
        /// <summary>
        /// Move Z2 to ZDefPos if not at Home Sensor position. 
        /// </summary>
        /// <returns></returns>
        public static bool TaskMoveGZ2Up()
        {
            string EMsg = "TaskMoveGZ2Up";

            try
            {
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (TaskGantry.SensHome(TaskGantry.GZ2Axis)) goto _End;

                    if (!TaskGantry.SetMotionParamGZZ2()) return false;
                    if (!TaskGantry.MoveAbsGZ2(TaskDisp.ZDefPos)) return false;

                    int t = GDefine.GetTickCount() + MoveZUp_TimeOut;
                    while (!TaskGantry.SensHome(TaskGantry.GZ2Axis))
                    {
                        if (GDefine.GetTickCount() >= t)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.GZ2_MOVE_TO_HOME_SENSOR_FAIL, EMsg, true);
                            return false;
                        }
                    }
                }

                _End:
                if (TaskGantry.GZ2Pos() < 0)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.ABNORMAL_MOTOR_POSITION_ERROR, "GZ2", true);
                    GDefine.Status = EStatus.ErrorInit;
                    return false;
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            };
            return true;
        }
        /// <summary>
        /// Move all Z to ZDefPos if not at Home Sensor position. 
        /// </summary>
        /// <returns></returns>
        public static bool TaskMoveGZZ2Up()
        {
            string EMsg = "TaskMoveGZZ2Up";

            try
            {
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (TaskGantry.SensHome(TaskGantry.GZAxis) && TaskGantry.SensHome(TaskGantry.GZ2Axis)) goto _End;
                }
                else
                {
                    if (TaskGantry.SensHome(TaskGantry.GZAxis)) goto _End;
                }

                if (!TaskGantry.SetMotionParamGZZ2()) return false;
                if (!TaskGantry.MoveAbsGZZ2(TaskDisp.ZDefPos)) return false;

                int t = GDefine.GetTickCount() + MoveZUp_TimeOut;
                while (!TaskGantry.SensHome(TaskGantry.GZAxis))
                {
                    if (GDefine.GetTickCount() >= t)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.GZ_MOVE_TO_HOME_SENSOR_FAIL, EMsg, true);
                        return false;
                    }
                    Thread.Sleep(2);
                }

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    while (!TaskGantry.SensHome(TaskGantry.GZ2Axis))
                    {
                        if (GDefine.GetTickCount() >= t)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.GZ2_MOVE_TO_HOME_SENSOR_FAIL, EMsg, true);
                            return false;
                        }
                        Thread.Sleep(2);
                    }
                }

                _End:
                if (TaskGantry.GZPos() < -0.1)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.ABNORMAL_MOTOR_POSITION_ERROR, "GZ", true);
                    GDefine.Status = EStatus.ErrorInit;
                    return false;
                }
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (TaskGantry.GZ2Pos() < -0.1)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.ABNORMAL_MOTOR_POSITION_ERROR, "GZ2", true);
                        GDefine.Status = EStatus.ErrorInit;
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            };

            //GDefine.Status = EStatus.Ready;
            return true;
        }
        /// <summary>
        /// Move GZ to FocusPos(FocusNo) and GZ2 to DefPos
        /// </summary>
        /// <param name="FocusNo"></param>
        /// <returns></returns>
        public static bool TaskMoveGZFocus(int FocusNo)
        {
            string EMsg = "TaskMoveGZFocus";

            //GDefine.Status = EStatus.Busy;

            try
            {
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                    if (!TaskDisp.TaskMoveGZ2Up()) return false;

                if (!TaskGantry.SetMotionParamGZ()) return false;
                if (!TaskGantry.MoveAbsGZ(ZDefPos + DispProg.FocusRelPos[FocusNo])) return false;

                int t = GDefine.GetTickCount() + MoveZUp_TimeOut;
                while (!TaskGantry.SensHome(TaskGantry.GZAxis))
                {
                    if (GDefine.GetTickCount() >= t)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.GZ_FOCUS_POS_NOT_SAFE, EMsg, true);
                        return false;
                    }
                    Thread.Sleep(2);
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            };

            return true;
        }

        /// <summary>
        /// Execute Auto Focus algo.
        /// </summary>
        /// <returns>True if complete.</returns>
        public static bool TaskAutoFocus()
        {
            int CoarseMoveDelay = 5;
            int FineMoveDelay = 10;
            double d_CoarseDist = 0.5;
            double d_FineDist = 0.025;
            int Coarse_Max_Ite = (int)(5 / 0.2);
            int Fine_Max_Ite = (int)((d_CoarseDist * 2) / d_FineDist);

            uint MaxFV = 0;
            uint FV = 0;
            TaskVision.GrabGetFocusValue(ref MaxFV);

            if (MaxFV < 100000)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Auto Focus Fail. Contrast too low.");
                goto _Fail;
            }

            TaskGantry.SetMotionParamGZ(0.1, 10, 500);

            #region Coarse Search
            int Ite = 0;
            if (!TaskGantry.MoveRelGZ(d_CoarseDist, true)) goto _Fail;
            int t = GDefine.GetTickCount() + CoarseMoveDelay;
            while (GDefine.GetTickCount() <= t)
            {
                Thread.Sleep(5);
            };
            TaskVision.GrabGetFocusValue(ref FV);
            Ite++;

            if (FV > MaxFV)//***plus dir search
            {
                while (true)
                {
                    MaxFV = Math.Max(FV, MaxFV);

                    if (!TaskGantry.MoveRelGZ(d_CoarseDist, true)) goto _Fail;
                    t = GDefine.GetTickCount() + CoarseMoveDelay;
                    while (GDefine.GetTickCount() <= t)
                    {
                        Thread.Sleep(0);
                    };
                    TaskVision.GrabGetFocusValue(ref FV);
                    Ite++;

                    if (FV < MaxFV)//***plus dir coarse search end
                    {
                        //***move to start fine search pos
                        if (!TaskGantry.MoveRelGZ(-d_CoarseDist * 2, true)) goto _Fail;
                        t = GDefine.GetTickCount() + CoarseMoveDelay;
                        while (GDefine.GetTickCount() <= t)
                        {
                            Thread.Sleep(0);
                        };

                        break;
                    }
                    if (Ite >= Coarse_Max_Ite)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show("Auto Focus Fail. Exceed Plus Coarse Iteration.");
                        goto _Fail;
                    }
                    Thread.Sleep(5);
                }
            }
            else//***minus dir search
            {
                if (!TaskGantry.MoveRelGZ(-d_CoarseDist, true)) goto _Fail;

                while (true)
                {
                    MaxFV = Math.Max(FV, MaxFV);

                    if (!TaskGantry.MoveRelGZ(-d_CoarseDist, true)) goto _Fail;
                    t = GDefine.GetTickCount() + CoarseMoveDelay;
                    while (GDefine.GetTickCount() <= t)
                    {
                        Thread.Sleep(0);
                    };
                    TaskVision.GrabGetFocusValue(ref FV);
                    Ite++;

                    if (FV < MaxFV)//***minus dir coarse search end
                    {
                        break;
                    }
                    if (Ite >= Coarse_Max_Ite)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show("Auto Focus Fail. Exceed Minus Coarse Iteration.");
                        goto _Fail;
                    }
                    Thread.Sleep(0);
                }
            }
            #endregion

            #region Fine Search - Search in Plus dir only
            Ite = 0;
            TaskVision.GrabGetFocusValue(ref MaxFV);
            FV = 0;

            int iLessFocusCount = 0;
            uint iLastFV = MaxFV;
            double dFocusPos = 0;
            while (true)
            {
                MaxFV = Math.Max(MaxFV, FV);
                iLastFV = FV;

                if (!TaskGantry.MoveRelGZ(d_FineDist, true)) goto _Fail;
                t = GDefine.GetTickCount() + FineMoveDelay;
                while (GDefine.GetTickCount() <= t)
                {
                    Thread.Sleep(0);
                };
                TaskVision.GrabGetFocusValue(ref FV);
                Ite++;

                if (FV > MaxFV)
                {
                    dFocusPos = TaskGantry.GZPos();
                }
                if (FV < iLastFV)
                {
                    iLessFocusCount++;
                }
                else
                    iLessFocusCount = 0;

                if (iLessFocusCount >= 3)
                {
                    if (!TaskGantry.MoveAbsGZ(dFocusPos, true)) goto _Fail;
                    t = GDefine.GetTickCount() + FineMoveDelay;
                    while (GDefine.GetTickCount() <= t)
                    {
                        Thread.Sleep(0);
                    };
                    break;
                }
                if (Ite >= Fine_Max_Ite)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show("Auto Focus Fail. Exceed Fine Iteration.");
                    goto _Fail;
                }
            }
            #endregion

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                TaskVision.flirCamera2[0].GrabCont();
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                TaskVision.genTLCamera[0].StartGrab();
            return true;

        _Fail:
            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
            {// TaskVision.PtGrey_CamLive(0);
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                TaskVision.flirCamera2[0].GrabCont();
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                TaskVision.genTLCamera[0].StartGrab();
            return false;
        }

        public static bool TaskMoveAbsGZ(double GZPos)
        {
            string EMsg = "TaskMoveAbsGZ";

            GDefine.Status = EStatus.Busy;

            if (GZPos > ZDefPos) GZPos = ZDefPos;

            try
            {
                if (!TaskGantry.SetMotionParamGZ()) return false;
                if (!TaskGantry.MoveAbsGZ(GZPos, false)) return false;
                if (!TaskGantry.WaitGZ()) return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            };

            GDefine.Status = EStatus.Ready;
            return true;
        }
        public static bool TaskMoveRelGZ(double RelPos)
        {
            string EMsg = "TaskMoveAbsGZ";

            GDefine.Status = EStatus.Busy;

            try
            {
                if (!TaskGantry.SetMotionParamGZ()) return false;
                if (!TaskGantry.MoveRelGZ(RelPos, false)) return false;
                if (!TaskGantry.WaitGZ()) return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            };

            GDefine.Status = EStatus.Ready;
            return true;
        }
        public static bool TaskMoveAbsGZ2(double GZ2Pos)
        {
            string EMsg = "TaskMoveAbsGZ2";

            GDefine.Status = EStatus.Busy;

            if (GZ2Pos > ZDefPos) GZ2Pos = ZDefPos;

            try
            {
                if (!TaskGantry.SetMotionParamGZ2()) return false;
                if (!TaskGantry.MoveAbsGZ2(GZ2Pos, false)) return false;
                if (!TaskGantry.WaitGZ2()) return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            };

            GDefine.Status = EStatus.Ready;
            return true;
        }
        public static bool TaskMoveAbsGZZ2(double GZPos, double GZ2Pos, double StartV, double DriveV, double Accel)
        {
            string EMsg = "TaskMoveAbsGZZ2";

            GDefine.Status = EStatus.Busy;

            if (GZPos > ZDefPos) GZPos = ZDefPos;
            if (GZ2Pos > ZDefPos) GZ2Pos = ZDefPos;

            try
            {
                if (!TaskGantry.SetMotionParamGZZ2(StartV, DriveV, Accel)) return false;
                if (!TaskGantry.MoveAbsGZ(GZPos, false)) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                    if (!TaskGantry.MoveAbsGZ2(GZ2Pos, false)) return false;

                if (!TaskGantry.WaitGZ()) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                    if (!TaskGantry.WaitGZ2()) return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            };

            GDefine.Status = EStatus.Ready;
            return true;
        }
        public static bool TaskMoveAbsGZZ2(double GZPos, double GZ2Pos)
        {
            return TaskMoveAbsGZZ2(GZPos, GZ2Pos, TaskGantry.GZAxis.Para.StartV, TaskGantry.GZAxis.Para.FastV, TaskGantry.GZAxis.Para.Accel);
        }

        public static bool GotoGX2Y2Pos(TPos3 Pos3)
        {
            string EMsg = "GotoX2Y2Pos";

            try
            {
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamExGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(Pos3.X, Pos3.Y)) return false;
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg, true);
                return false;

            }
            return true;
        }
        public static bool GotoXYPos(TPos3 PosXY, TPos3 PosX2Y2)
        {
            string EMsg = "GotoXYPos";

            try
            {
                if (!TaskGantry.SetMotionParamGXY()) return false;
                if (!TaskGantry.MoveAbsGXY(PosXY.X, PosXY.Y, false)) return false;

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                    if (!TaskGantry.MoveAbsGX2Y2(PosX2Y2.X, PosX2Y2.Y, false)) return false;
                }

                if (!TaskGantry.WaitGXY()) return false;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
                {
                    if (!TaskGantry.WaitGX2Y2()) return false;
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg, true);
                return false;

            }
            return true;
        }
        public static bool GotoXYPos(TPos2 PosXY, TPos2 PosX2Y2)
        {
            TPos3 _PosXY = new TPos3(PosXY.X, PosXY.Y, 0);
            TPos3 _PosX2Y2 = new TPos3(PosX2Y2.X, PosX2Y2.Y, 0);

            return GotoXYPos(_PosXY, _PosX2Y2);
        }

        public static bool TaskMoveCamOffset()
        {
            string EMsg = "Task Move Cam Offset";

            GDefine.Status = EStatus.Busy;
            if (!TaskMoveGZZ2Up()) return false;

            try
            {
                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();

                TPos2 GXY = new TPos2(X, Y);
                GXY.X = GXY.X - Head_Ofst[0].X;
                GXY.Y = GXY.Y - Head_Ofst[0].Y;

                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

                if (!GotoXYPos(GXY, GX2Y2)) return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg, true);
                return false;
            }

            GDefine.Status = EStatus.Ready;
            return true;
        }
        public static bool TaskMoveNeedleOffset()
        {
            string EMsg = "Task Move Needle Offset";

            GDefine.Status = EStatus.Busy;
            if (!TaskMoveGZZ2Up()) return false;

            try
            {
                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();

                TPos2 GXY = new TPos2(X, Y);
                GXY.X = GXY.X + Head_Ofst[0].X;
                GXY.Y = GXY.Y + Head_Ofst[0].Y;

                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

                if (!GotoXYPos(GXY, GX2Y2)) return false;
                TaskMoveCamOffsetHeadNo = -1;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            }

            GDefine.Status = EStatus.Ready;
            return true;
        }
        public static bool TaskMoveLaserOffset()
        {
            string EMsg = "Task Move Laser Offset";

            GDefine.Status = EStatus.Busy;
            if (!TaskMoveGZZ2Up()) return false;

            try
            {
                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();

                TPos2 GXY = new TPos2(X, Y);
                GXY.X = GXY.X + Laser_Ofst.X;
                GXY.Y = GXY.Y + Laser_Ofst.Y;

                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

                if (!GotoXYPos(GXY, GX2Y2)) return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            }

            GDefine.Status = EStatus.Ready;
            return true;
        }
        internal static int TaskMoveCamOffsetHeadNo = -1;
        public static bool TaskToggleCamOffset()//start 0
        {
            string EMsg = "TaskMoveCamOffset";

            if (!TaskMoveGZZ2Up()) return false;

            GDefine.Status = EStatus.Busy;
            try
            {
                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();
                TPos2 GXY = new TPos2(X, Y);

                if (TaskMoveCamOffsetHeadNo < 0)
                {
                    GXY.X = GXY.X - Head_Ofst[0].X;
                    GXY.Y = GXY.Y - Head_Ofst[0].Y;
                    TaskMoveCamOffsetHeadNo = 0;
                }
                else
                {
                    if (DispProg.Head_Operation == EHeadOperation.Single) goto _End;

                    if (TaskMoveCamOffsetHeadNo == 0)
                    {
                        GXY.X = GXY.X + Head_PitchX;
                        TaskMoveCamOffsetHeadNo = 1;
                    }
                    else
                        if (TaskMoveCamOffsetHeadNo > 0)
                    {
                        GXY.X = GXY.X - Head_PitchX;
                        TaskMoveCamOffsetHeadNo = 0;
                    }
                }

                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

                if (!GotoXYPos(GXY, GX2Y2)) goto _Error;
                if (!TaskDisp.TaskMoveGZFocus(0)) return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.GANTRY_MOTION_EX_ERR, EMsg, true);
                return false;
            }
            _End:
            GDefine.Status = EStatus.Ready;
            return true;
            _Error:
            GDefine.Status = EStatus.ErrorInit;
            return true;
        }

        public static bool TaskGotoTPos2(TPos3[] Pos)
        {
            string EMsg = "Task Goto TPos3";

            GDefine.Status = EStatus.Busy;
            if (!TaskMoveGZZ2Up()) return false;

            try
            {
                if (!GotoXYPos(Pos[(int)EHead.One], Pos[(int)EHead.Two])) return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            }
            GDefine.Status = EStatus.Ready;

            return true;
        }

        public static bool TaskPurgeCleanNeedle(bool PromptZDown, TPos3[] Pos, bool DispA, bool DispB, bool OnVac, bool Trig, bool MoveUp, int Time, int Delay, int Count, int PostVacTime)
        {
            string EMsg = "Task Purge Clean Needle";

            TaskDisp.FPressOn(new bool[2] { true, TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync });

            try
            {
                GDefine.Status = EStatus.Busy;
                if (!TaskMoveGZZ2Up()) return false;

                if (!GotoXYPos(Pos[(int)EHead.One], Pos[(int)EHead.Two])) return false;

                if (PromptZDown)
                {
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.MOVE_ZAXIS_TO_POSITION, EMcState.Warning, EMsgBtn.smbOK_Cancel, false);
                    if (MsgRes == EMsgRes.smrCancel)
                    {
                        goto _End;
                    }
                }
                if (!TaskGantry.SetMotionParamGZZ2()) return false;
                if (!TaskMoveAbsGZZ2(Pos[(int)EHead.One].Z + Z1Offset, Pos[(int)EHead.Two].Z + Z2Offset)) return false;

                bool IsDispAPurgeMode = false;
                bool IsDispBPurgeMode = false;
                if (!GetDispCtrlMode(DispA, DispB, ref IsDispAPurgeMode, ref IsDispBPurgeMode)) goto _Stop;
                if (!SetDispCtrlPurgeMode(DispA, DispB)) goto _Stop;

                switch (DispProg.Pump_Type)
                {
                    case TaskDisp.EPumpType.Vermes:
                        for (int i = 0; i < 2; i++)
                        {
                            if (TaskDisp.Vermes3200[i].IsOpen)
                            {
                                if (TaskDisp.Vermes3200[i].Param.NP != 0)
                                {
                                    TaskDisp.Vermes3200[i].Param.NP = 0;
                                    TaskDisp.Vermes3200[i].Set();
                                }
                            }
                        }
                        break;
                    case TaskDisp.EPumpType.Vermes1560:
                        for (int i = 0; i < 2; i++)
                        {
                            if (TaskDisp.Vermes1560[i].IsOpen)
                            {
                                if (TaskDisp.Vermes1560[i].NP[0] != 0)
                                {
                                    TaskDisp.Vermes1560[i].NP[0] = 0;
                                    TaskDisp.Vermes1560[i].UpdateSetup();
                                }
                            }
                        }
                        break;
                }

                int cycles = 0;
                if (TaskDisp.Vermes3200[0].IsOpen) cycles = Vermes3200[0].ValveCycles;
                if (TaskDisp.Vermes1560[0].IsOpen) cycles = Vermes1560[0].ValveCycles;

                if (DispA || DispB)
                {
                    #region
                    int iCount = Count;
                    while (iCount > 0)
                    {
                        if (DispA || DispB)
                        {
                            if (Trig && Time > 0)
                            {
                                if (!TaskDisp.CtrlWaitReady(DispA, DispB)) goto _Stop;
                            }

                            if (OnVac) TaskGantry.SvCleanVac = true;
                        }

                        if (Time > 0)
                        {
                            if (Trig)
                            {
                                if (!TaskDisp.CtrlWaitReady(DispA, DispB)) goto _Stop;
                                if (!TrigOn(DispA, DispB)) goto _Stop;
                                if (!TaskDisp.CtrlWaitResponse(DispA, DispB)) goto _Stop;
                            }

                            int t = GDefine.GetTickCount() + Time;
                            while (GDefine.GetTickCount() <= t) { Thread.Sleep(1); }

                            if (!TrigOff(DispA, DispB)) goto _Stop;
                            if (!CtrlWaitComplete(DispA, DispB)) goto _Stop;
                        }

                        if (Delay == 0) Delay = 10;
                        if (Delay > 0)
                        {
                            int t = GDefine.GetTickCount() + Delay;
                            while (GDefine.GetTickCount() <= t) { Thread.Sleep(1); }
                        }

                        if (OnVac) TaskGantry.SvCleanVac = false;

                        iCount--;
                    }
                    #endregion
                }
                if (MoveUp)
                {
                    if (!TaskMoveGZZ2Up()) return false;
                }

                if (DispProg.DispCtrl_ForceTimeMode)
                {
                    SetDispCtrlTimedMode(DispA, DispB);
                }
                else
                {
                    if (!IsDispAPurgeMode)
                        SetDispCtrlTimedMode(DispA, DispB);
                }

                switch (DispProg.Pump_Type)
                {
                    case TaskDisp.EPumpType.Vermes:
                        for (int i = 0; i < 2; i++)
                        {
                            if (TaskDisp.Vermes3200[i].IsOpen)
                            {
                                double interval = Vermes3200[i].Param.RI + Vermes3200[i].Param.OT + Vermes3200[i].Param.FA + Vermes3200[i].Param.DL;
                                double t = Time;
                                int np = (int)(Math.Ceiling(t / interval)) * Count;
                                //Stats.DispCount_Inc(i, np);

                                int runCycles = Vermes3200[i].ValveCycles - cycles;
                                NDispWin.Material.Unit.Count[i] += np;
                            }
                        }
                        break;
                    case TaskDisp.EPumpType.Vermes1560:
                        for (int i = 0; i < 2; i++)
                        {
                            if (TaskDisp.Vermes1560[i].IsOpen)
                            {
                                double interval = Vermes1560[i].OT[i] + Vermes1560[i].CT[i];
                                double t = Time;
                                int np = (int)(Math.Ceiling(t / interval)) * Count;
                                //Stats.DispCount_Inc(i, np);

                                int runCycles = Vermes1560[i].ValveCycles - cycles;
                                NDispWin.Material.Unit.Count[i] += np;
                            }
                        }
                        break;
                }

                if (PostVacTime > 0)
                {
                    var vacClean = Task.Run(() =>
                    {
                        TaskGantry.SvCleanVac = true;
                        Thread.Sleep(PostVacTime);
                        TaskGantry.SvCleanVac = false;
                    });
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            }
            finally
            {
                TaskDisp.FPressOff();
                //TaskMoveGZZ2Up();
            }
        _End:
            GDefine.Status = EStatus.Ready;
            return true;
        _Stop:
            TrigOff(DispA, DispB);
            TaskGantry.SvCleanVac = false;
            TaskMoveGZZ2Up();
            GDefine.Status = EStatus.Stop;
            return false;
        }

        public static bool TaskCleanNeedle(bool DispA, bool DispB, bool Trig, bool MoveUp, int Time, int Delay, int Count, int PostVacTime)
        {
            bool OnVac = true;

            TPos3[] Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
            switch ((EMaintPos)Needle_Clean_UsePos)
            {
                case EMaintPos.Clean:
                    Pos = new TPos3[2] { new TPos3(Needle_Clean_Pos[0]), new TPos3(Needle_Clean_Pos[1]) };
                    break;
                case EMaintPos.Purge:
                    Pos = new TPos3[2] { new TPos3(Needle_Purge_Pos[0]), new TPos3(Needle_Purge_Pos[1]) };
                    break;
                case EMaintPos.Flush:
                    Pos = new TPos3[2] { new TPos3(Needle_Flush_Pos[0]), new TPos3(Needle_Flush_Pos[1]) };
                    break;
            }

            Event.CLEAN_NEEDLE.Set();
            return TaskPurgeCleanNeedle(false, Pos, DispA, DispB, OnVac, Trig, MoveUp, Time, Delay, Count, PostVacTime);
        }
        public static bool TaskGotoCleanNeedlePromtZ(bool PromptZDown)//goto only
        {
            bool DispA = false;
            bool DispB = false;
            bool OnVac = false;
            bool MoveUp = false;
            Event.CLEAN_NEEDLE.Set("Goto", PromptZDown.ToString());
            return TaskPurgeCleanNeedle(PromptZDown, Needle_Clean_Pos, DispA, DispB, OnVac, false, MoveUp, 0, 0, 0, 0);
        }
        public static bool TaskCleanNeedle(bool DispA, bool DispB, bool Trig)//head selection
        {
            return TaskCleanNeedle(DispA, DispB, Trig, true, Needle_Clean_Time, Needle_Clean_Wait, Needle_Clean_Count, Needle_Clean_PostVacTime);
        }
        public static bool TaskCleanNeedle(bool Trig)//auto select head2
        {
            bool DispB = (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double);
            return TaskCleanNeedle(true, DispB, Trig);
        }

        public static bool TaskPurgeNeedle(bool DispA, bool DispB, bool Trig, bool MoveUp, int Time, int Delay, int Count, int PostVacTime)
        {
            bool OnVac = false;

            TPos3[] Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
            switch ((EMaintPos)Needle_Purge_UsePos)
            {
                case EMaintPos.Clean:
                    Pos = new TPos3[2] { new TPos3(Needle_Clean_Pos[0]), new TPos3(Needle_Clean_Pos[1]) };
                    break;
                case EMaintPos.Purge:
                    Pos = new TPos3[2] { new TPos3(Needle_Purge_Pos[0]), new TPos3(Needle_Purge_Pos[1]) };
                    break;
                case EMaintPos.Flush:
                    Pos = new TPos3[2] { new TPos3(Needle_Flush_Pos[0]), new TPos3(Needle_Flush_Pos[1]) };
                    break;
            }
            Event.PURGE_NEEDLE.Set();
            return TaskPurgeCleanNeedle(false, Pos, DispA, DispB, OnVac, Trig, MoveUp, Time, Delay, Count, PostVacTime);
        }
        public static bool TaskGotoPurgeNeedlePrompZ(bool PromptZDown)//goto only - no purge
        {
            bool DispA = false;
            bool DispB = false;
            bool MoveUp = false;
            bool OnVac = false;
            Event.PURGE_NEEDLE.Set("Goto", PromptZDown.ToString());
            return TaskPurgeCleanNeedle(PromptZDown, Needle_Purge_Pos, DispA, DispB, OnVac, false, MoveUp, 0, 0, 0, 0);
        }
        public static bool TaskPurgeNeedle(bool DispA, bool DispB, bool Trig)//head selection
        {
            return TaskPurgeNeedle(DispA, DispB, Trig, true, Needle_Purge_Time, Needle_Purge_Wait, Needle_Purge_Count, Needle_Purge_PostVacTime);
        }
        public static bool TaskPurgeNeedle(bool Trig)//auto select head2
        {
            bool DispB = (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double);
            return TaskPurgeNeedle(true, DispB, Trig);
        }

        public static bool TaskFlushNeedle(bool DispA, bool DispB, bool Trig, bool MoveUp, int Time, int Delay, int Count, int PostVacTime)
        {
            bool OnVac = false;

            TPos3[] Pos = new TPos3[2] { new TPos3(0, 0, 0), new TPos3(0, 0, 0) };
            switch ((EMaintPos)Needle_Flush_UsePos)
            {
                case EMaintPos.Clean:
                    Pos = new TPos3[2] { new TPos3(Needle_Clean_Pos[0]), new TPos3(Needle_Clean_Pos[1]) };
                    break;
                case EMaintPos.Purge:
                    Pos = new TPos3[2] { new TPos3(Needle_Purge_Pos[0]), new TPos3(Needle_Purge_Pos[1]) };
                    break;
                case EMaintPos.Flush:
                    Pos = new TPos3[2] { new TPos3(Needle_Flush_Pos[0]), new TPos3(Needle_Flush_Pos[1]) };
                    break;
            }

            Event.FLUSH_NEEDLE.Set();
            return TaskPurgeCleanNeedle(false, Pos, DispA, DispB, OnVac, Trig, MoveUp, Time, Delay, Count, PostVacTime);
        }
        public static bool TaskGotoFlushNeedlePrompZ(bool PromptZDown)//goto only - no purge
        {
            bool DispA = false;
            bool DispB = false;
            bool MoveUp = false;
            bool OnVac = false;
            Event.FLUSH_NEEDLE.Set("Goto", PromptZDown.ToString());
            return TaskPurgeCleanNeedle(PromptZDown, Needle_Flush_Pos, DispA, DispB, OnVac, false, MoveUp, 0, 0, 0, 0);
        }
        public static bool TaskFlushNeedle(bool DispA, bool DispB, bool Trig)//head selection
        {
            return TaskFlushNeedle(DispA, DispB, Trig, true, Needle_Flush_Time, Needle_Flush_Wait, Needle_Flush_Count, Needle_Flush_PostVacTime);
        }
        public static bool TaskFlushNeedle(bool Trig)//auto select head2
        {
            bool DispB = (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double);
            return TaskFlushNeedle(true, DispB, Trig);
        }

        public static bool TaskShotNeedle(TPos3[] Pos, bool DispA, bool DispB, int Delay, int Count)
        {
            int Counter = 0;

            while (Counter < Count)
            {
                //if (!TaskDisp.TrigOn(DispA, DispB)) return false;
                //if (!TaskDisp.CtrlWaitResponse(DispA, DispB)) return false;
                //if (!TaskDisp.TrigOff(DispA, DispB)) return false;
                //if (!TaskDisp.CtrlWaitComplete(DispA, DispB)) return false;

                //if (Count > 1) Thread.Sleep(Delay);
                //Counter++;

                if (!TaskDisp.TrigOn(DispA, DispB)) return false;
                Thread.Sleep(10);
                if (!TaskDisp.TrigOff(DispA, DispB)) return false;
                Thread.Sleep(Delay);
                if (!TaskDisp.CtrlWaitComplete(DispA, DispB)) return false;
                Counter++;
            }

            return true;
        }

        public static bool TaskGotoPMaint()
        {
            GDefine.Status = EStatus.Busy;
            if (!TaskMoveGZZ2Up()) return false;

            //if (!GotoXYPos(Needle_Maint_Pos[(int)EHead.One], Needle_Maint_Pos[(int)EHead.Two])) return false;

            if (!GotoGX2Y2Pos(Needle_Maint_Pos[(int)EHead.Two])) return false;
            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(Needle_Maint_Pos[(int)EHead.One].X, Needle_Maint_Pos[(int)EHead.One].Y, true)) return false;

            if (!TaskMoveAbsGZZ2(Needle_Maint_Pos[(int)EHead.One].Z, Needle_Maint_Pos[(int)EHead.Two].Z)) return false;

            GDefine.Status = EStatus.Ready;
            return true;
        }
        public static bool TaskGotoMMaint()
        {
            GDefine.Status = EStatus.Busy;
            if (!TaskMoveGZZ2Up()) return false;

            if (!GotoGX2Y2Pos(Machine_Maint_Pos[(int)EHead.Two])) return false;
            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(Machine_Maint_Pos[(int)EHead.One].X, Machine_Maint_Pos[(int)EHead.One].Y, true)) return false;

            if (!TaskMoveAbsGZZ2(Machine_Maint_Pos[(int)EHead.One].Z, Machine_Maint_Pos[(int)EHead.Two].Z)) return false;

            GDefine.Status = EStatus.Ready;
            return true;
        }

        public static bool TaskGotoPos(double X, double Y, double Z, double X2, double Y2, double Z2)
        {
            GDefine.Status = EStatus.Busy;

            if (!TaskDisp.TaskMoveGZZ2Up()) return false;

            if (!TaskGantry.SetMotionParamGXY()) return false;
            if (!TaskGantry.MoveAbsGXY(X, Y, false)) return false;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                if (!TaskGantry.MoveAbsGX2Y2(X2, Y2, false)) return false;
            }

            if (!TaskGantry.WaitGXY()) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.WaitGX2Y2()) return false;
            }

            if (!TaskGantry.SetMotionParamGZ()) return false;
            if (!TaskGantry.MoveAbsGZ(Z, false)) return false;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamGZ2()) return false;
                if (!TaskGantry.MoveAbsGZ2(Z2, false)) return false;
            }

            if (!TaskGantry.WaitGZ()) return false;
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.WaitGZ2()) return false;
            }

            GDefine.Status = EStatus.Ready;
            return true;
        }
        public static bool TaskGotoPos(TPos3[] tPos3)
        {
            return TaskGotoPos(tPos3[0].X, tPos3[0].Y, tPos3[0].Z, tPos3[1].X, tPos3[1].Y, tPos3[1].Z);
        }
        public static bool TaskGotoGX2Y2DefPos()
        {
            GDefine.Status = EStatus.Busy;

            if (!TaskMoveGZZ2Up()) return false;

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                if (!TaskGantry.SetMotionParamGX2Y2()) return false;
                if (!TaskGantry.MoveAbsGX2Y2(Head2_DefPos.X, Head2_DefPos.Y)) return false;
            }
            GDefine.Status = EStatus.Ready;
            return true;
        }

        public static bool TaskNeedleInsp(int headSelect/*1,2*/)
        {
            GDefine.Status = EStatus.Busy;
            if (!TaskMoveGZZ2Up()) return false;

            switch (headSelect)
            {
                case 1: if (!TaskGotoPos(P1NeedleInspCamPos)) return false; break;
                case 2: if (!TaskGotoPos(P2NeedleInspCamPos)) return false; break;
            }

            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < 500)
            {
                Thread.Sleep(0);
            }

            if (!TaskGantry.NICamRun)
            {
                if (!TaskMoveGZZ2Up()) return false;
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.NEEDLE_INSP_NOT_IN_RUN_MODE, EMcState.Warning, EMsgBtn.smbOK, false);
                goto _Stop;
            }

            if (TaskGantry.NICamBusy)
            {
                if (!TaskMoveGZZ2Up()) return false;
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.NEEDLE_INSP_IS_BUSY, EMcState.Warning, EMsgBtn.smbOK, false);
                goto _Stop;
            }

            TaskGantry.NICamTrig = true;

            sw.Restart();
            while (!TaskGantry.NICamBusy)
            {
                Thread.Sleep(0);
                if (sw.ElapsedMilliseconds > 1000)
                {
                    TaskGantry.NICamTrig = false;
                    if (!TaskMoveGZZ2Up()) return false;
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.NEEDLE_INSP_RESPONSE_TIMEOUT, EMcState.Warning, EMsgBtn.smbOK, false);
                    goto _Stop;
                }
            }
            TaskGantry.NICamTrig = false;

            sw.Restart();
            while (TaskGantry.NICamBusy)
            {
                Thread.Sleep(0);
                if (sw.ElapsedMilliseconds > 1000)
                {
                    if (!TaskMoveGZZ2Up()) return false;
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.NEEDLE_INSP_BUSY_TIMEOUT, EMcState.Warning, EMsgBtn.smbOK, false);
                    goto _Stop;
                }
            }

            if (!TaskGantry.NICamSigOK)
            {
                if (!TaskMoveGZZ2Up()) return false;
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.NEEDLE_INSP_FAIL, $"Pump{headSelect}", EMcState.Warning, EMsgBtn.smbOK, false);
                goto _Stop;
            }

            return true;

        _Stop:
            TaskGantry.NICamTrig = false;
            if (!TaskMoveGZZ2Up()) return false;
            GDefine.Status = EStatus.Ready;
            return false;
        }

        public enum EProfile
        {
            None = 0,
            Triangle = 2,
            Trapezoid = 3,
        }
        public static void GetMotionData(double u, double v, double a, double dt, ref double ta, ref double da, ref double tc, ref double dc, ref double td, ref double dd, ref EProfile Profile)
        {
            /*
             * a = (v-u)/t
             * 
             * //accel region
             * s = ut + 1/2*at^2
             * 2s - 2ut = at^2
             * at^2 + 2ut = 2s
             * t^2 + 2ut/a = 2s/a
             * t^2 + 2ut/a + (u/a)^2 = 2s/a + (u/a)^2
             * (t + u/a)^2 = 2s/a + (u/a)^2
             * t + u/a = sqrt(2s/a + (u/a)^2)
             * t = sqrt(2s/a + (u/a)^2) - u/a
             * 
             * const region
             * t = s/v
             */

            //getAccelDecelDistance
            //time accel, dist accel
            ta = (v - u) / a;//1000;
            //s = ut + 1/2*at^2
            da = u * ta + 0.5 * a * Math.Pow(ta, 2);

            //time decel, dist decel
            td = 0;
            dd = 0;
            //time const, dist const
            tc = 0;
            dc = 0;

            dt = Math.Abs(dt);

            Profile = EProfile.None;

            //trapezoid curve
            if (da < (dt / 2))
            {
                //time decel, dist decel
                td = ta;
                dd = da;

                //time const, dist const
                dc = dt - 2 * da;
                tc = dc / v;

                Profile = EProfile.Trapezoid;
            }
            else//triangle curve
            {
                da = dt / 2;
                ta = Math.Sqrt(2 * ((da) / a) + Math.Pow(u / a, 2)) - (u / a);

                td = ta;
                dd = da;

                tc = 0;
                dc = 0;

                Profile = EProfile.Triangle;
            }
        }
        public static void GetMotionData(double u, double v, double a, double dt, ref double tt)
        {
            double ta = 0;
            double da = 0;
            double tc = 0;
            double dc = 0;
            double td = 0;
            double dd = 0;
            EProfile Profile = EProfile.None;

            GetMotionData(u, v, a, dt, ref ta, ref da, ref tc, ref dc, ref td, ref dd, ref Profile);
            tt = ta + tc + td;
        }
        public static double DistAtTime(double u, double v, double a, double dt, double t)
        {
            double ta = 0;
            double da = 0;
            double tc = 0;
            double dc = 0;
            double td = 0;
            double dd = 0;
            EProfile Profile = EProfile.None;

            GetMotionData(u, v, a, dt, ref ta, ref da, ref tc, ref dc, ref td, ref dd, ref Profile);

            if (Profile == EProfile.Trapezoid)
            {
                if (t > ta + tc + td) return dt;

                if (t <= ta)
                {
                    //s = ut + 1/2*at^2
                    return u * ta + 0.5 * a * Math.Pow(ta, 2);
                }
                else
                    if (t > ta || t <= ta + tc)
                {
                    double tc_ = t - ta;
                    double dc_ = v * tc_;

                    return da + dc_;
                }
                else
                        if (t > ta + tc || t <= ta + tc + td)
                {
                    double td_ = t - (ta + tc);
                    double dd_ = v * td + 0.5 * -a * Math.Pow(-td, 2);

                    return da + dc + dd_;
                }
                else return 0;
            }
            else
                if (Profile == EProfile.Triangle)
            {
                if (t > ta + td) return dt;

                if (t <= ta)
                {
                    //s = ut + 1/2*at^2
                    return u * ta + 0.5 * a * Math.Pow(ta, 2);
                }
                else
                    if (t > ta || t <= ta + td)
                {
                    double td_ = t - (ta + tc);
                    double dd_ = v * td + 0.5 * -a * Math.Pow(-td, 2);

                    return da + dc + dd_;
                }
                else return 0;
            }
            else
                return 0;
        }

        public static Nspira_HPC_Series.HPC[] HPC = new Nspira_HPC_Series.HPC[2];
        static Nspira_HPC_Series.FormHPC[] frm_HPC = new Nspira_HPC_Series.FormHPC[2];

        public static HPC15.HPC[] HPC_15 = new HPC15.HPC[2];
        static HPC15.frm_HPC15[] frm_HPC15 = new HPC15.frm_HPC15[2];

        public static Vermes.TEVermesMDS3200[] Vermes3200 = new Vermes.TEVermesMDS3200[2] { new Vermes.TEVermesMDS3200(), new Vermes.TEVermesMDS3200() };
        public static TEVermesMDS1560[] Vermes1560 = new TEVermesMDS1560[] { new TEVermesMDS1560(), new TEVermesMDS1560() };
        public static TEVermesHeaterHC48[] Vermes_HC48 = new TEVermesHeaterHC48[] { new TEVermesHeaterHC48(), new TEVermesHeaterHC48() };

        public static bool OpenDispCtrl(int CtrlNo)
        {
            string EMsg = "OpenDispCtrl";

            switch (GDefine.DispCtrlType[CtrlNo])
            {
                case GDefine.EDispCtrlType.None:
                default:
                    return false;
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    #region
                    if (HPC[CtrlNo] == null) HPC[CtrlNo] = new Nspira_HPC_Series.HPC();

                    if (HPC[CtrlNo].IsOpen)
                    {
                        CloseDispCtrl(CtrlNo);
                    }
                    if (!HPC[CtrlNo].IsOpen)
                    {
                        string ComNo = "COM" + GDefine.DispCtrlComport[CtrlNo].ToString();
                        try
                        {
                            if (!HPC[CtrlNo].OpenPort(ComNo))
                            {
                                Msg MsgBox = new Msg();
                                if (CtrlNo == 0) MsgBox.Show(ErrCode.DISPCTRL1_OPEN_ERR);
                                if (CtrlNo == 1) MsgBox.Show(ErrCode.DISPCTRL2_OPEN_ERR);
                                return false;
                            }
                        }
                        catch (Exception Ex)
                        {
                            EMsg = EMsg + (char)13 + Ex.Message;
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL_COMM_EX_ERR);
                            return false;
                        }
                    }
                    return true;
                #endregion
                case GDefine.EDispCtrlType.HPC15:
                    #region
                    if (HPC_15[CtrlNo] == null) HPC_15[CtrlNo] = new HPC15.HPC();

                    if (HPC_15[CtrlNo].IsOpen)
                    {
                        CloseDispCtrl(CtrlNo);
                    }
                    if (!HPC_15[CtrlNo].IsOpen)
                    {
                        string ComNo = "COM" + GDefine.DispCtrlComport[CtrlNo].ToString();
                        try
                        {
                            if (!HPC_15[CtrlNo].OpenPort(ComNo, CtrlNo))
                            {
                                Msg MsgBox = new Msg();
                                if (CtrlNo == 0) MsgBox.Show(ErrCode.DISPCTRL1_OPEN_ERR);
                                if (CtrlNo == 1) MsgBox.Show(ErrCode.DISPCTRL2_OPEN_ERR);
                                return false;
                            }
                        }
                        catch (Exception Ex)
                        {
                            EMsg = EMsg + (char)13 + Ex.Message;
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL_COMM_EX_ERR);
                            return false;
                        }
                    }
                    return true;
                #endregion
                case GDefine.EDispCtrlType.Vermes:
                    if (TaskDisp.Vermes3200[CtrlNo].IsOpen)
                        TaskDisp.Vermes3200[CtrlNo].Close();

                    try
                    {
                        TaskDisp.Vermes3200[CtrlNo].AppPath = GDefine.AppPath + "\\Vermes";
                        TaskDisp.Vermes3200[CtrlNo].CtrlID = CtrlNo;
                        if (!TaskDisp.Vermes3200[CtrlNo].IsOpen)
                            TaskDisp.Vermes3200[CtrlNo].Open("COM" + GDefine.DispCtrlComport[CtrlNo].ToString());
                    }
                    catch (Exception Ex)
                    {
                        EMsg = EMsg + (char)13 + Ex.Message;
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL_COMM_EX_ERR, EMsg);
                        return false;
                    }

                    return true;
                case GDefine.EDispCtrlType.Vermes1560:
                    if (TaskDisp.Vermes1560[CtrlNo].IsOpen)
                        TaskDisp.Vermes1560[CtrlNo].Close();

                    try
                    {
                        TaskDisp.Vermes1560[CtrlNo].CtrlID = CtrlNo;
                        if (!TaskDisp.Vermes1560[CtrlNo].IsOpen)
                            TaskDisp.Vermes1560[CtrlNo].Open("COM" + GDefine.DispCtrlComport[CtrlNo].ToString());
                    }
                    catch (Exception Ex)
                    {
                        EMsg = EMsg + (char)13 + Ex.Message;
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL_COMM_EX_ERR);
                        return false;
                    }

                    return true;
            }
        }
        public static void CloseDispCtrl(int CtrlNo)
        {
            try
            {
                switch (GDefine.DispCtrlType[CtrlNo])
                {
                    case GDefine.EDispCtrlType.None:
                    default:
                        break;
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        HPC[CtrlNo].ClosePort();
                        break;
                    case GDefine.EDispCtrlType.HPC15:
                        HPC_15[CtrlNo].ClosePort();
                        break;
                    case GDefine.EDispCtrlType.Vermes:
                        TaskDisp.Vermes3200[CtrlNo].Close();
                        break;
                    case GDefine.EDispCtrlType.Vermes1560:
                        TaskDisp.Vermes1560[CtrlNo].Close();
                        break;
                }
            }
            catch { };
        }
        public static bool DispCtrlOpened(int CtrlNo)
        {
            switch (GDefine.DispCtrlType[CtrlNo])
            {
                case GDefine.EDispCtrlType.None:
                default:
                    return false;
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    if (HPC[CtrlNo] == null) HPC[CtrlNo] = new Nspira_HPC_Series.HPC();
                    return HPC[CtrlNo].IsOpen;
                case GDefine.EDispCtrlType.HPC15:
                    if (HPC_15[CtrlNo] == null) HPC_15[CtrlNo] = new HPC15.HPC();
                    return HPC_15[CtrlNo].IsOpen;
                case GDefine.EDispCtrlType.Vermes:
                    return TaskDisp.Vermes3200[CtrlNo].IsOpen;
                case GDefine.EDispCtrlType.Vermes1560:
                    return TaskDisp.Vermes1560[CtrlNo].IsOpen;
            }
        }
        public static void ShowDispCtrl(int CtrlNo)
        {
            switch (GDefine.DispCtrlType[CtrlNo])
            {
                case GDefine.EDispCtrlType.None:
                default:
                    break;
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    if (HPC[CtrlNo] == null) HPC[CtrlNo] = new Nspira_HPC_Series.HPC();
                    if (frm_HPC[CtrlNo] == null) frm_HPC[CtrlNo] = new Nspira_HPC_Series.FormHPC();

                    frm_HPC[CtrlNo].HPC = HPC[CtrlNo];
                    frm_HPC[CtrlNo].Show();
                    break;
                case GDefine.EDispCtrlType.HPC15:
                    if (HPC_15[CtrlNo] == null) HPC_15[CtrlNo] = new HPC15.HPC();
                    if (frm_HPC15[CtrlNo] == null) frm_HPC15[CtrlNo] = new HPC15.frm_HPC15();
                    {
                        frm_HPC_Control frm = new frm_HPC_Control();
                        frm.CtrlNo = CtrlNo;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        frm.BringToFront();
                    }
                    break;
                case GDefine.EDispCtrlType.Vermes:
                    {
                        Vermes.frmVermesMDS3200 frm = new Vermes.frmVermesMDS3200();
                        frm.CtrlNo = CtrlNo;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        break;
                    }
                case GDefine.EDispCtrlType.Vermes1560:
                    {
                        frmVermesMDS1560 frm = new frmVermesMDS1560();
                        frm.vm = TaskDisp.Vermes1560[CtrlNo];
                        frm.TopMost = true;
                        frm.ShowDialog();
                        int.TryParse(TaskDisp.Vermes1560[CtrlNo].sp.PortName.Remove(0, 3), out GDefine.DispCtrlComport[CtrlNo]);
                        break;
                    }
            }
        }

        #region Controller IO HandShake
        public static bool b_HeadAIsFilling = false;
        public static bool b_HeadBIsFilling = false;

        public enum EDispIOLogic { None, Low, High };
        public static EDispIOLogic DispReadyLogic = EDispIOLogic.High;
        public static EDispIOLogic DispResponseLogic = EDispIOLogic.Low;
        public static EDispIOLogic DispCompleteLogic = EDispIOLogic.None;
        public static EDispIOLogic DispErrorLogic = EDispIOLogic.None;

        public static bool CtrlCheckReady(bool DispA, bool DispB)
        {
            if (DispReadyLogic == EDispIOLogic.None) return true;

            if (DispReadyLogic == EDispIOLogic.Low)
            {
                if (DispA && TaskGantry.DispAReady())
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL1_NOT_READY, "", true);
                    return false;
                }
                if (DispB && TaskGantry.DispBReady())
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL1_NOT_READY, "", true);
                    return false;
                }
            }

            if (DispReadyLogic == EDispIOLogic.High)
            {
                if (DispA && !TaskGantry.DispAReady())
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL1_NOT_READY, "", true);
                    return false;
                }
                if (DispB && !TaskGantry.DispBReady())
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL1_NOT_READY, "", true);
                    return false;
                }
            }

            return true;
        }
        public static bool CtrlWaitReady(bool DispA, bool DispB)
        {
            if (!DispA && !DispB) return true;

            if (DispReadyLogic == EDispIOLogic.None || TaskDisp.DispReady_TimeOut <= 0) return true;

            if (DispReadyLogic == EDispIOLogic.Low)
            {
                #region
                int t = GDefine.GetTickCount() + TaskDisp.DispReady_TimeOut;
                while (true)
                {
                    TaskDisp.Thread_CheckIsFilling_Run(DispA, DispB);
                    if (DispA && DispB)
                    {
                        if (!TaskGantry.DispAReady() && !TaskGantry.DispBReady()) break;
                    }
                    else
                        if (DispA && !TaskGantry.DispAReady()) break;
                    else
                            if (DispB && !TaskGantry.DispBReady()) break;
                    if (GDefine.GetTickCount() >= t) break;
                    Thread.Sleep(1);
                }

                if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
                {
                    switch (GDefine.DispCtrlType[Head1_CtrlNo])
                    {
                        case GDefine.EDispCtrlType.HPC_OBSOLETE:
                            break;
                        case GDefine.EDispCtrlType.HPC15:
                            string Err1 = "0";
                            string Err2 = "0";
                            HPC_15[Head1_CtrlNo].ReadPumpABErrorCode(ref Err1, ref Err2);

                            if (Err1 != "0")
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL_ROTARY_TIMEOUT, "Pump 1");
                                HPC_15[Head1_CtrlNo].ClearErrorCode();
                                return false;
                            }
                            if (Err2 != "0")
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL_ROTARY_TIMEOUT, "Pump 2");
                                HPC_15[Head1_CtrlNo].ClearErrorCode();
                                return false;
                            }
                            break;
                    }
                }

                if (DispA && TaskGantry.DispAReady())
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL1_READY_TIMEOUT, "", true);
                    return false;
                }
                if (DispB && TaskGantry.DispBReady())
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL2_READY_TIMEOUT, "", true);
                    return false;
                }
                #endregion
            }

            if (DispReadyLogic == EDispIOLogic.High)
            {
                #region
                int t = GDefine.GetTickCount() + TaskDisp.DispReady_TimeOut;
                while (true)
                {
                    if (DispA && DispB)
                    {
                        if (TaskGantry.DispAReady() && TaskGantry.DispBReady()) break;
                    }
                    else
                        if (DispA && TaskGantry.DispAReady()) break;
                    else
                        if (DispB && TaskGantry.DispBReady()) break;

                    if (GDefine.GetTickCount() >= t) break;
                    Thread.Sleep(1);
                }

                if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
                {
                    switch (GDefine.DispCtrlType[Head1_CtrlNo])
                    {
                        case GDefine.EDispCtrlType.HPC_OBSOLETE:
                            break;
                        case GDefine.EDispCtrlType.HPC15:
                            string Err1 = "0";
                            string Err2 = "0";
                            HPC_15[Head1_CtrlNo].ReadPumpABErrorCode(ref Err1, ref Err2);

                            if (Err1 != "0")
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL_ROTARY_TIMEOUT, "Pump 1");
                                HPC_15[Head1_CtrlNo].ClearErrorCode();
                                return false;
                            }
                            if (Err2 != "0")
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL_ROTARY_TIMEOUT, "Pump 2");
                                HPC_15[Head1_CtrlNo].ClearErrorCode();
                                return false;
                            }
                            break;
                    }
                }

                if (DispA && !TaskGantry.DispAReady())
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL1_READY_TIMEOUT, "", true);
                    return false;
                }
                if (DispB && !TaskGantry.DispBReady())
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL2_READY_TIMEOUT, "", true);
                    return false;
                }
                #endregion
            }

            return true;
        }
        static int i_NoRespCount = 0;
        public static bool CtrlWaitResponse(bool DispA, bool DispB)
        {
            if (!DispA && !DispB) return true;

            if (DispResponseLogic == EDispIOLogic.None || TaskDisp.DispResponse_TimeOut <= 0)
            {
                Thread.Sleep(20);
                return true;
            }

            if (DispResponseLogic == EDispIOLogic.Low)
            {
                #region
                bool DispALow = false;
                bool DispBLow = false;
                int t = GDefine.GetTickCount() + TaskDisp.DispResponse_TimeOut;

                if (DispA && !DispB)
                {
                    DispBLow = true;
                }
                else
                    if (!DispA && DispB)
                {
                    DispALow = true;
                }

                while (true)
                {
                    if (!DispALow) DispALow = !TaskGantry.DispAReady();
                    if (!DispBLow) DispBLow = !TaskGantry.DispBReady();
                    if (DispALow && DispBLow) break;
                    if (GDefine.GetTickCount() > t) break;
                    Thread.Sleep(1);
                }

                if (DispALow && DispBLow) i_NoRespCount = 0;

                if (GDefine.GetTickCount() >= t)
                {
                    i_NoRespCount++;
                    TrigOff(true, true);

                    if (i_NoRespCount > 1)
                    {
                        if (!DispALow)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_RESPONSE_TIMEOUT, "", true);
                            return false;
                        }
                        if (!DispBLow)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL2_RESPONSE_TIMEOUT, "", true);
                            return false;
                        }
                    }
                }
                #endregion
            }

            if (DispResponseLogic == EDispIOLogic.High)
            {
                #region
                bool DispAHigh = false;
                bool DispBHigh = false;
                int t = GDefine.GetTickCount() + TaskDisp.DispResponse_TimeOut;

                if (DispA && !DispB)
                {
                    DispBHigh = true;
                }
                else
                    if (!DispA && DispB)
                {
                    DispAHigh = true;
                }

                while (true)
                {
                    if (!DispAHigh) DispAHigh = TaskGantry.DispAReady();
                    if (!DispBHigh) DispBHigh = TaskGantry.DispBReady();
                    if (DispAHigh && DispBHigh) break;
                    if (GDefine.GetTickCount() > t) break;
                    Thread.Sleep(1);
                }

                if (DispAHigh && DispBHigh) i_NoRespCount = 0;

                if (GDefine.GetTickCount() >= t)
                {
                    i_NoRespCount++;
                    TrigOff(true, true);

                    if (i_NoRespCount > 1)
                    {
                        if (!DispAHigh)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_RESPONSE_TIMEOUT, "", true);
                            return false;
                        }
                        if (!DispBHigh)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL2_RESPONSE_TIMEOUT, "", true);
                            return false;
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        public static bool CtrlWaitComplete(bool DispA, bool DispB)
        {
            if (DispCompleteLogic == EDispIOLogic.None || TaskDisp.DispComplete_TimeOut <= 0) return true;

            if (DispCompleteLogic == EDispIOLogic.Low)
            {
                #region
                bool DispALow = false;
                bool DispBLow = false;
                int t = GDefine.GetTickCount() + TaskDisp.DispComplete_TimeOut;

                if (DispA && !DispB)
                {
                    DispBLow = true;
                }
                else
                    if (!DispA && DispB)
                {
                    DispALow = true;
                }

                while (true)
                {
                    if (!DispALow) DispALow = !TaskGantry.DispAReady();
                    if (!DispBLow) DispBLow = !TaskGantry.DispBReady();
                    if (DispALow && DispBLow) break;
                    if (GDefine.GetTickCount() > t) break;
                    TaskDisp.Thread_CheckIsFilling_Run(DispA, DispB);
                    Thread.Sleep(1);
                }

                if (DispALow && DispBLow) i_NoRespCount = 0;

                if (GDefine.GetTickCount() >= t)
                {
                    i_NoRespCount++;
                    TrigOff(true, true);

                    if (i_NoRespCount > 1)
                    {
                        if (!DispALow)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMPLETE_TIMEOUT, "", true);
                            return false;
                        }
                        if (!DispBLow)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL2_COMPLETE_TIMEOUT, "", true);
                            return false;
                        }
                    }
                }
                #endregion
            }

            if (DispCompleteLogic == EDispIOLogic.High)
            {
                #region
                bool DispAHigh = false;
                bool DispBHigh = false;
                int t = GDefine.GetTickCount() + TaskDisp.DispComplete_TimeOut;

                if (DispA && !DispB)
                {
                    DispBHigh = true;
                }
                else
                    if (!DispA && DispB)
                {
                    DispAHigh = true;
                }

                while (true)
                {
                    if (!DispAHigh) DispAHigh = TaskGantry.DispAReady();
                    if (!DispBHigh) DispBHigh = TaskGantry.DispBReady();
                    if (DispAHigh && DispBHigh) break;
                    if (GDefine.GetTickCount() > t) break;
                    TaskDisp.Thread_CheckIsFilling_Run(DispA, DispB);
                    Thread.Sleep(1);
                }

                if (DispAHigh && DispBHigh) i_NoRespCount = 0;

                if (GDefine.GetTickCount() >= t)
                {
                    i_NoRespCount++;
                    TrigOff(true, true);

                    if (i_NoRespCount > 1)
                    {
                        if (!DispAHigh)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMPLETE_TIMEOUT, "", true);
                            return false;
                        }
                        if (!DispBHigh)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL2_COMPLETE_TIMEOUT, "", true);
                            return false;
                        }
                    }
                }
                #endregion
            }
            return true;
        }

        public class CtrlError
        {
            public static bool IsError()
            {
                switch (DispErrorLogic)
                {
                    default:
                    case EDispIOLogic.None:
                        return false;
                    case EDispIOLogic.High:
                        return TaskGantry.DispCtrlError;
                    case EDispIOLogic.Low:
                        return !TaskGantry.DispCtrlError;
                }
            }

            static bool b_CtrlError = false;
            public static void ResetFlag()
            {
                b_CtrlError = false;
            }
            public static bool UpdateErrorFlag()
            {
                if (DispErrorLogic == EDispIOLogic.None) return false;

                if (b_CtrlError) return b_CtrlError;

                b_CtrlError = IsError();
                return b_CtrlError;
            }
            public static bool IsErrorFlag()
            {
                if (DispErrorLogic == EDispIOLogic.None) return false;

                return b_CtrlError;
            }
        }

        public static bool TrigOn(bool DispA, bool DispB)
        {
            b_HeadAIsFilling = false;
            b_HeadBIsFilling = false;

            if (DispA) TaskGantry.DispATrigSet(TaskGantry.TOutputState.On);
            if (DispB) TaskGantry.DispBTrigSet(TaskGantry.TOutputState.On);

            return true;
        }
        public static bool TrigOff(bool DispA, bool DispB)
        {
            //try
            //{
            if (DispA) TaskGantry.DispATrigSet(TaskGantry.TOutputState.Off);
            if (DispB) TaskGantry.DispBTrigSet(TaskGantry.TOutputState.Off);
            //}
            //catch (Exception ex)
            //{
            //    frm_DispCore_Msg.Page.ShowMsg(ex.Message.ToString(), frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK);
            //    return false;
            //}
            return true;
        }

        public static void FPress(bool[] Disp)
        {
            TaskGantry.TOutputState[] OS = new TaskGantry.TOutputState[2] { TaskGantry.TOutputState.Off, TaskGantry.TOutputState.Off };

            if (Disp[0]) OS[0] = TaskGantry.TOutputState.On; else OS[0] = TaskGantry.TOutputState.Off;
            if (Disp[1]) OS[1] = TaskGantry.TOutputState.On; else OS[1] = TaskGantry.TOutputState.Off;

            TaskGantry.FPress1(OS[0]);
            TaskGantry.FPress2(OS[1]);
        }

        public static void FPressOn(bool[] Disp)
        {
            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.Vermes:
                case TaskDisp.EPumpType.Vermes1560:
                case TaskDisp.EPumpType.PJ:
                    {
                        bool[] On = new bool[2] { Disp[0], Disp[1] };
                        TaskDisp.FPress(On);
                    }
                    break;
            }
        }
        public static void FPressOff()
        {
            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.Vermes:
                case TaskDisp.EPumpType.Vermes1560:
                case TaskDisp.EPumpType.PJ:
                    {
                        bool[] On = new bool[2] { false, false };
                        TaskDisp.FPress(On);
                    }
                    break;
            }
        }
        #endregion

        internal static double HM_Max_RPM = 1000;

        #region Controller Comm HandShake
        public static bool CheckDispCtrlConnection()
        {
            string EMsg = "CheckDispCtrlConnection";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    {
                        bool On = false;
                        if (!HPC[0].GetTrigger(Nspira_HPC_Series.eHead.A, ref On))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }
                        break;
                    }
                case GDefine.EDispCtrlType.HPC15:
                    {
                        bool On = false;
                        if (!HPC_15[0].GetTrigMode(HPC15.eHead.A, ref On))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }
                        break;
                    }
            }
            switch (GDefine.DispCtrlType[1])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    {
                        bool On = false;
                        if (!HPC[1].GetTrigger(Nspira_HPC_Series.eHead.A, ref On))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL2_COMM_ERR, EMsg);
                            return false;
                        }
                        break;
                    }
                case GDefine.EDispCtrlType.HPC15:
                    {
                        bool On = false;
                        if (!HPC_15[1].GetTrigMode(HPC15.eHead.A, ref On))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL2_COMM_ERR, EMsg);
                            return false;
                        }
                        break;
                    }
            }
            return true;
        }

        public static void SaveHPCData(string RecipeName)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (GDefine.DispCtrlType[i])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        {
                            if (!TaskOption.Ctrl_SavePara) return;

                            try
                            {
                                if (HPC[i].IsOpen)
                                    //HPC[i].SaveDispParam(true, RecipeName, Nspira_HPC_Series.eHead.A);
                                    HPC[i].SaveRecipe(RecipeName);
                            }
                            catch { };
                            break;
                        }
                    case GDefine.EDispCtrlType.HPC15:
                        {
                            try
                            {
                                if (HPC_15[i].IsOpen)
                                    HPC_15[i].SaveRecipe(RecipeName);
                            }
                            catch { };
                            break;
                        }
                }
            }
        }
        public static void LoadHPCData(string RecipeName)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (GDefine.DispCtrlType[i])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        {
                            if (!TaskOption.Ctrl_LoadPara) return;

                            try
                            {
                                if (HPC[i].IsOpen)
                                {
                                    HPC[i].LoadRecipe(RecipeName);
                                    //HPC[i].DownloadFrmCtrl();
                                    //HPC[i].LoadDispParam(true, RecipeName, Nspira_HPC_Series.eHead.A);
                                    //HPC[i].UploadToCtrl();
                                }
                            }
                            catch { };
                            break;
                        }
                    case GDefine.EDispCtrlType.HPC15:
                        {
                            try
                            {
                                if (HPC_15[i].IsOpen)
                                {
                                    HPC_15[i].LoadRecipe(RecipeName);
                                    HPC_15[i].UploadToCtrl();

                                    HM_Max_RPM = HPC_15[i].HM_Max_RPM;
                                }
                            }
                            catch { };
                            break;
                        }
                }
            }
        }

        public static void saveHPCDataXML(string fileName)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (GDefine.DispCtrlType[i])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        {
                            throw new Exception("HPC Version 1 not supported.");
                        }
                    case GDefine.EDispCtrlType.HPC15:
                        {
                            try
                            {
                                if (HPC_15[i].IsOpen)
                                    HPC_15[i].saveRecipeXML(fileName, "root", "Program");
                            }
                            catch { };
                            break;
                        }
                }
            }
        }
        public static void loadHPCDataXML(string fileName)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (GDefine.DispCtrlType[i])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        {
                            throw new Exception("HPC Version 1 not supported.");
                        }
                    case GDefine.EDispCtrlType.HPC15:
                        {
                            try
                            {
                                if (HPC_15[i].IsOpen)
                                {
                                    HPC_15[i].loadRecipeXML(fileName, "root", "Program");
                                    HPC_15[i].UploadToCtrl();

                                    HM_Max_RPM = HPC_15[i].HM_Max_RPM;
                                }
                            }
                            catch { };
                            break;
                        }
                }
            }
        }

        public static bool HeadIsValid(int HeadNo)
        {
            if (HeadNo == 1)
            {
                if ((Head1_CtrlNo >= 0) && (Head1_CtrlNo <= 1) && (Head1_CtrlHeadNo >= 0) && (Head1_CtrlHeadNo <= 1) &&
                (GDefine.DispCtrlType[Head1_CtrlNo] == GDefine.EDispCtrlType.HPC_OBSOLETE || GDefine.DispCtrlType[Head1_CtrlNo] == GDefine.EDispCtrlType.HPC15)) return true;
            }

            if (HeadNo == 2)
            {
                if ((Head2_CtrlNo >= 0) && (Head2_CtrlNo <= 1) && (Head2_CtrlHeadNo >= 0) && (Head2_CtrlHeadNo <= 1) &&
                (GDefine.DispCtrlType[Head2_CtrlNo] == GDefine.EDispCtrlType.HPC_OBSOLETE || GDefine.DispCtrlType[Head2_CtrlNo] == GDefine.EDispCtrlType.HPC15)) return true;
            }
            return false;
        }

        public static bool DoInitPP(bool DispA, bool DispB)
        {
            string EMsg = "DoInit";

            try
            {
                if (DispA && HeadIsValid(1))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        switch (GDefine.DispCtrlType[Head1_CtrlNo])
                        {
                            case GDefine.EDispCtrlType.HPC_OBSOLETE:

                                if (!HPC[Head1_CtrlNo].SetPPInit((Nspira_HPC_Series.eHead)Head1_CtrlHeadNo, false))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                            case GDefine.EDispCtrlType.HPC15:
                                if (!HPC_15[Head1_CtrlNo].SetInitPP((HPC15.eHead)Head1_CtrlHeadNo))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                        }
                    }
                }

                if (DispB && HeadIsValid(2))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        switch (GDefine.DispCtrlType[Head2_CtrlNo])
                        {
                            case GDefine.EDispCtrlType.HPC_OBSOLETE:
                                if (!HPC[Head2_CtrlNo].SetPPInit((Nspira_HPC_Series.eHead)Head2_CtrlHeadNo, false))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                            case GDefine.EDispCtrlType.HPC15:
                                if (!HPC_15[Head2_CtrlNo].SetInitPP((HPC15.eHead)Head2_CtrlHeadNo))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                        }
                    }
                }
                return true;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
        }

        public static bool IsFilling()
        {
            return b_HeadAIsFilling || b_HeadBIsFilling;
        }
        public static void IsFilling(ref bool DispA, ref bool DispB)
        {
            DispA = b_HeadAIsFilling;
            DispB = b_HeadBIsFilling;
        }
        public static bool DoFill(bool DispA, bool DispB)
        {
            string EMsg = "DoFill";

            if (DispA && HeadIsValid(1))
            {
                if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
                {
                    switch (GDefine.DispCtrlType[Head1_CtrlNo])
                    {
                        case GDefine.EDispCtrlType.HPC_OBSOLETE:
                            if (!HPC[Head1_CtrlNo].SetFill((Nspira_HPC_Series.eHead)Head1_CtrlHeadNo, false))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case GDefine.EDispCtrlType.HPC15:
                            if (!HPC_15[Head1_CtrlNo].SetFillPP((HPC15.eHead)Head1_CtrlHeadNo))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                    }
                    b_HeadAIsFilling = true;
                }
            }

            if (DispB && HeadIsValid(2))
            {
                if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
                {
                    switch (GDefine.DispCtrlType[Head2_CtrlNo])
                    {
                        case GDefine.EDispCtrlType.HPC_OBSOLETE:
                            if (!HPC[Head2_CtrlNo].SetFill((Nspira_HPC_Series.eHead)Head2_CtrlHeadNo, false))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case GDefine.EDispCtrlType.HPC15:
                            if (!HPC_15[Head2_CtrlNo].SetFillPP((HPC15.eHead)Head2_CtrlHeadNo))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;

                    }
                    b_HeadBIsFilling = true;
                }
            }

            Maint.PP.FillCount_Inc(DispA, DispB);

            return true;
        }
        public static bool DoFill()
        {
            bool DispB = (Head_Operation == EHeadOperation.Sync || Head_Operation == EHeadOperation.Double);

            return DoFill(true, DispB);
        }
        public static bool DoCleanFill(bool DispA, bool DispB)
        {
            string EMsg = "DoCleanFill";

            if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
            {
                switch (GDefine.DispCtrlType[Head1_CtrlNo])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        throw new Exception(EMsg + " Function not supported.");
                    case GDefine.EDispCtrlType.HPC15:
                        if (!HPC_15[Head1_CtrlNo].CleanFill(DispA && HeadIsValid(1), DispB && HeadIsValid(2)))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }
                        if (DispA && HeadIsValid(1)) b_HeadAIsFilling = true;
                        if (DispB && HeadIsValid(2)) b_HeadBIsFilling = true;
                        break;
                }
            }

            Maint.PP.FillCount_Inc(DispA, DispB);

            return true;
        }

        public static bool GetDispCtrlMode(bool DispA, bool DispB, ref bool PurgeA, ref bool PurgeB)
        {
            string EMsg = "GetDispCtrlMode";

            if (GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC_OBSOLETE || GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC15)
            {
                #region
                if (!TaskDisp.DispCtrlOpened(0))
                    if (!TaskDisp.OpenDispCtrl(0)) return false;

                if (DispA && HeadIsValid(1))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.HM)
                    {
                        switch (GDefine.DispCtrlType[Head1_CtrlNo])
                        {
                            case GDefine.EDispCtrlType.HPC_OBSOLETE:
                                if (!HPC[Head1_CtrlNo].GetTrigger((Nspira_HPC_Series.eHead)Head1_CtrlHeadNo, ref PurgeA))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                            case GDefine.EDispCtrlType.HPC15:
                                if (!HPC_15[Head1_CtrlNo].GetTrigMode((HPC15.eHead)Head1_CtrlHeadNo, ref PurgeA))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                        }
                    }
                }

                if (DispB && HeadIsValid(2))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.HM)
                    {
                        switch (GDefine.DispCtrlType[Head2_CtrlNo])
                        {
                            case GDefine.EDispCtrlType.HPC_OBSOLETE:
                                if (!HPC[Head2_CtrlNo].GetTrigger((Nspira_HPC_Series.eHead)Head2_CtrlHeadNo, ref PurgeB))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                            case GDefine.EDispCtrlType.HPC15:
                                if (!HPC_15[Head2_CtrlNo].GetTrigMode((HPC15.eHead)Head2_CtrlHeadNo, ref PurgeB))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        public static bool SetDispCtrlMode(bool DispA, bool DispB, bool Purge)
        {
            string EMsg = "SetDispCtrlMode";

            if (GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC_OBSOLETE || GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC15)
            {
                #region
                if (!TaskDisp.DispCtrlOpened(0))
                    if (!TaskDisp.OpenDispCtrl(0)) return false;

                if (DispA && HeadIsValid(1))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.HM)
                    {
                        switch (GDefine.DispCtrlType[Head1_CtrlNo])
                        {
                            case GDefine.EDispCtrlType.HPC_OBSOLETE:
                                if (!HPC[Head1_CtrlNo].SetPurgeMode((Nspira_HPC_Series.eHead)Head1_CtrlHeadNo, Purge))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                            case GDefine.EDispCtrlType.HPC15:
                                if (!HPC_15[Head1_CtrlNo].SetDispMode((HPC15.eHead)Head1_CtrlHeadNo, Purge))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                        }
                    }
                }

                if (DispB && HeadIsValid(2))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.HM)
                    {
                        switch (GDefine.DispCtrlType[Head2_CtrlNo])
                        {
                            case GDefine.EDispCtrlType.HPC_OBSOLETE:
                                if (!HPC[Head2_CtrlNo].SetPurgeMode((Nspira_HPC_Series.eHead)Head2_CtrlHeadNo, Purge))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                            case GDefine.EDispCtrlType.HPC15:
                                if (!HPC_15[Head2_CtrlNo].SetDispMode((HPC15.eHead)Head2_CtrlHeadNo, Purge))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        public static bool SetDispCtrlPurgeMode(bool DispA, bool DispB)
        {
            return SetDispCtrlMode(DispA, DispB, true);
        }
        public static bool SetDispCtrlTimedMode(bool DispA, bool DispB)
        {
            return SetDispCtrlMode(DispA, DispB, false);
        }

        private static bool GetSingleIntParam(bool DispA, bool DispB, Nspira_HPC_Series.TaskCmd.EParam Param, ref int ValueA, ref int ValueB)
        {
            string EMsg = "GetSingleIntParam";

            try
            {
                if (DispA && HeadIsValid(1))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.HM)
                    {
                        string s_Value = "";
                        if (!HPC[Head1_CtrlNo].Read_SingleParam("", (Nspira_HPC_Series.eHead)Head1_CtrlHeadNo, Param, 0, ref s_Value))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }

                        ValueA = 0;
                        try
                        {
                            ValueA = Convert.ToInt32(s_Value);
                        }
                        catch
                        {
                            throw new Exception("Convert Error");
                        }
                    }
                }

                if (DispB && HeadIsValid(2))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.HM)
                    {
                        string s_Value = "";
                        if (!HPC[Head2_CtrlNo].Read_SingleParam("", (Nspira_HPC_Series.eHead)Head2_CtrlHeadNo, Param, 0, ref s_Value))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }

                        ValueB = 0;
                        try
                        {
                            ValueB = Convert.ToInt32(s_Value);
                        }
                        catch
                        {
                            throw new Exception("Convert Error");
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        private static bool GetSingleIntParam(bool DispA, bool DispB, HPC15.TaskPLCCmd.EParam Param, ref int ValueA, ref int ValueB)
        {
            string EMsg = "GetSingleIntParam";

            try
            {
                if (DispA && HeadIsValid(1))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        string s_Value = "";
                        if (!HPC_15[Head1_CtrlNo].ReadSingleParam("", (HPC15.eHead)Head1_CtrlHeadNo, Param, 0, ref s_Value))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }

                        ValueA = 0;
                        try
                        {
                            ValueA = Convert.ToInt32(s_Value);
                        }
                        catch
                        {
                            throw new Exception("Convert Error");
                        }
                    }
                }

                if (DispB && HeadIsValid(2))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        string s_Value = "";
                        if (!HPC_15[Head2_CtrlNo].ReadSingleParam("", (HPC15.eHead)Head2_CtrlHeadNo, Param, 0, ref s_Value))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }

                        ValueB = 0;
                        try
                        {
                            ValueB = Convert.ToInt32(s_Value);
                        }
                        catch
                        {
                            throw new Exception("Convert Error");
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }

        private static bool SetSingleShortParam(bool DispA, bool DispB, Nspira_HPC_Series.TaskCmd.EParam Param, short ValueA, short ValueB)
        {
            string EMsg = "SetSingleIntParam";

            try
            {
                if (DispA && HeadIsValid(1))
                {
                    //if (Pump_Type == EPumpType.PP2 || Pump_Type == EPumpType.PP2D || Pump_Type == EPumpType.PPD)
                    //{
                    if (!HPC[Head1_CtrlNo].Write_SingleParam("", (Nspira_HPC_Series.eHead)Head1_CtrlHeadNo, Param, 0, ValueA))
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                        return false;
                    }
                    //}
                }

                if (DispB && HeadIsValid(2))
                {
                    //if (Pump_Type == EPumpType.PP2 || Pump_Type == EPumpType.PP2D || Pump_Type == EPumpType.PPD)
                    //{
                    if (!HPC[Head2_CtrlNo].Write_SingleParam("", (Nspira_HPC_Series.eHead)Head2_CtrlHeadNo, Param, 0, ValueB))
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                        return false;
                    }
                    //}
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        private static bool SetSingleShortParam(bool DispA, bool DispB, HPC15.TaskPLCCmd.EParam Param, short ValueA, short ValueB)
        {
            string EMsg = "SetSingleIntParam";

            try
            {
                if (DispA && HeadIsValid(1))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        if (!HPC_15[Head1_CtrlNo].WriteSingleParam("", (HPC15.eHead)Head1_CtrlHeadNo, Param, 0, ValueA))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }
                    }
                }

                if (DispB && HeadIsValid(2))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        if (!HPC_15[Head2_CtrlNo].WriteSingleParam("", (HPC15.eHead)Head2_CtrlHeadNo, Param, 0, ValueB))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }
        private static bool SetSingleShortParam(bool DispA, bool DispB, HPC15.TaskPLCCmd.EParam Param, ushort ValueA, ushort ValueB)
        {
            string EMsg = "SetSingleIntParam";

            try
            {
                if (DispA && HeadIsValid(1))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        if (!HPC_15[Head1_CtrlNo].WriteSingleParam("", (HPC15.eHead)Head1_CtrlHeadNo, Param, 0, ValueA))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }
                    }
                }

                if (DispB && HeadIsValid(2))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        if (!HPC_15[Head2_CtrlNo].WriteSingleParam("", (HPC15.eHead)Head2_CtrlHeadNo, Param, 0, ValueB))
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                            return false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return false;
            }
            return true;
        }

        public static bool SetDispType(TaskDisp.EPumpType PumpType)
        {
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC15:
                    switch (PumpType)
                    {
                        case EPumpType.HM:
                            return HPC_15[0].SetDispType(HPC15.eDispType.HM);
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            return HPC_15[0].SetDispType(HPC15.eDispType.PP2);
                        case EPumpType.PPD:
                            return HPC_15[0].SetDispType(HPC15.eDispType.PPD2);
                        default:
                            break;
                    }
                    break;

            }
            return false;
        }

        public static int ReadErrorCode()
        {
            int errCode = 0;//Errcode = 0, 1=pump1 error, 2=pump2 error 
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC15:
                    string err = "";
                    HPC_15[0].ReadErrorCode(ref err);
                    int.TryParse(err, out errCode);
                    break;
            }
            return errCode;
        }

        static Mutex mtx = new Mutex();
        public static bool CheckIsFilling(bool DispA, bool DispB)
        {
            mtx.WaitOne();
            try
            {

                string EMsg = "CheckIsFilling";
                if (b_HeadAIsFilling || b_HeadBIsFilling) return true;

                if (DispA && HeadIsValid(1))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        switch (GDefine.DispCtrlType[Head1_CtrlNo])
                        {
                            case GDefine.EDispCtrlType.HPC_OBSOLETE:
                                if (!HPC[Head1_CtrlNo].GetFiling((Nspira_HPC_Series.eHead)Head1_CtrlHeadNo, ref b_HeadAIsFilling))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                            case GDefine.EDispCtrlType.HPC15:
                                if (!HPC_15[Head1_CtrlNo].GetFilling((HPC15.eHead)Head1_CtrlHeadNo, ref b_HeadAIsFilling))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                        }
                    }

                    if (DispProg.Head_Operation == TaskDisp.EHeadOperation.Sync)
                    {
                        if (b_HeadAIsFilling) DoFill(false, true);
                    }
                }
                if (DispB && HeadIsValid(2))
                {
                    if (DispProg.Pump_Type == EPumpType.PP || DispProg.Pump_Type == EPumpType.PP2D || DispProg.Pump_Type == EPumpType.PPD)
                    {
                        switch (GDefine.DispCtrlType[Head2_CtrlNo])
                        {
                            case GDefine.EDispCtrlType.HPC_OBSOLETE:
                                if (!HPC[Head2_CtrlNo].GetFiling((Nspira_HPC_Series.eHead)Head2_CtrlHeadNo, ref b_HeadBIsFilling))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                            case GDefine.EDispCtrlType.HPC15:
                                if (!HPC_15[Head2_CtrlNo].GetFilling((HPC15.eHead)Head2_CtrlHeadNo, ref b_HeadBIsFilling))
                                {
                                    Msg MsgBox = new Msg();
                                    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                    return false;
                                }
                                break;
                        }
                    }

                    if (DispProg.Head_Operation == TaskDisp.EHeadOperation.Sync)
                    {
                        if (b_HeadAIsFilling) DoFill(false, true);
                        if (b_HeadBIsFilling) DoFill(true, false);
                    }
                }
                return true;
            }
            finally
            {
                mtx.ReleaseMutex();
            }
        }
        static Task taskCheckIsFilling = null;
        static bool taskCheckIsFillingError = false;
        public static void Thread_CheckIsFilling_Run(bool DispA, bool DispB)
        {
            if (taskCheckIsFilling != null && !taskCheckIsFilling.IsCompleted)
            {
                return;
            }
            taskCheckIsFilling = Task.Run(() =>
            {
                try
                {
                    taskCheckIsFillingError = !CheckIsFilling(DispA, DispB);
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set("Thread_CheckIsFilling_Run", ex.Message.ToString());
                };
            });
        }
        public static bool Thread_CheckIsFilling_Error()
        {
                if (taskCheckIsFilling == null) return false;
                return taskCheckIsFillingError;
        }

        static Task taskSetDispSpeed = null;
        static bool taskSetDispSpeedError = false;
        public static bool SetDispSpeed(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            mtx.WaitOne();
            try
            {
                switch (GDefine.DispCtrlType[0])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        return SetSingleShortParam(DispA, DispB, Nspira_HPC_Series.TaskCmd.EParam.Disp_SP, (short)ValueA, (short)ValueB);
                    case GDefine.EDispCtrlType.HPC15:
                        if (!HPC_15[0].IsOpen)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, "");
                            return false;
                        }

                        if (DispA) Event.PUMP1_DISP_SPEED_UPDATE.Set("Pump1DispSpeed", ValueA.ToString());
                        if (DispB) Event.PUMP2_DISP_SPEED_UPDATE.Set("Pump2DispSpeed", ValueB.ToString());

                        return HPC_15[0].SetDispSpeed(DispA, DispB, ValueA, ValueB);
                }
                return true;
            }
            finally
            {
                mtx.ReleaseMutex();
            }

        }

        public static bool Thread_SetDispSpeed_Run(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            if (taskSetDispSpeed != null && !taskSetDispSpeed.IsCompleted)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISPCTRL_THREAD_BUSY, "SetDispSpeed " + taskSetDispSpeed.Status.ToString());
                return false;
            }
            taskSetDispSpeed = Task.Run(() =>
            {
                try
                {
                    taskSetDispSpeedError = !SetDispSpeed(DispA, DispB, ValueA, ValueB);
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set("Thread_SetDispSpeed_Run", ex.Message.ToString());
                };
            });
            return true;
        }
        public static bool Thread_SetDispSpeed_Wait()
        {
            if (taskSetDispSpeed == null) return true;

            var sw = Stopwatch.StartNew();
            while (!taskSetDispSpeed.IsCompleted)
            {
                if (sw.ElapsedMilliseconds > 500)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL_THREAD_TIMEOUT, "SetDispSpeed " + taskSetDispSpeed.Status.ToString());
                    return false;
                }
                Thread.Sleep(0);
            }

            if (taskSetDispSpeedError)
            {
                TaskDisp.TrigOff(true, true);
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISPCTRL_THREAD_ERROR, "SetDispSpeed");
                return false;
            }

            return true;
        }
        public static bool SetDispTime(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            mtx.WaitOne();
            try
            {
                switch (GDefine.DispCtrlType[0])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        return SetSingleShortParam(DispA, DispB, Nspira_HPC_Series.TaskCmd.EParam.Disp_Vol, (short)ValueA, (short)ValueB);
                    case GDefine.EDispCtrlType.HPC15:
                        if (!HPC_15[0].IsOpen)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, "");
                            return false;
                        }
                        if (DispA) Event.PUMP1_DISP_TIME_UPDATE.Set("Pump1DispTime", ValueA.ToString());
                        if (DispB) Event.PUMP2_DISP_TIME_UPDATE.Set("Pump2DispTime", ValueB.ToString());
                        return HPC_15[0].SetDispAmount(DispA, DispB, ValueA, ValueB);
                }
                return true;
            }
            finally
            {
                mtx.ReleaseMutex();
            }
        }

        public static bool SetBSuckSpeed(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    return SetSingleShortParam(DispA, DispB, Nspira_HPC_Series.TaskCmd.EParam.BS_SP, (short)ValueA, (short)ValueB);
                case GDefine.EDispCtrlType.HPC15:
                    if (!HPC_15[0].IsOpen)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, "");
                        return false;
                    }
                    if (DispB) Event.PUMP2_BACKSUCK_SPEED_UPDATE.Set("Pump2BacksukcSpeed", ValueB.ToString());

                    return HPC_15[0].SetBSuckSpeed(DispA, DispB, ValueA, ValueB);
            }
            return true;
        }
        public static bool SetBSuckTime(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    return SetSingleShortParam(DispA, DispB, Nspira_HPC_Series.TaskCmd.EParam.BS_Vol, (short)ValueA, (short)ValueB);
                case GDefine.EDispCtrlType.HPC15:
                    if (!HPC_15[0].IsOpen)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, "");
                        return false;
                    }
                    if (DispA) Event.PUMP1_BACKSUCK_TIME_UPDATE.Set("Pump1BacksukcTime", ValueA.ToString());
                    if (DispB) Event.PUMP2_BACKSUCK_TIME_UPDATE.Set("Pump2BacksukcTime", ValueB.ToString());
                    return HPC_15[0].SetBackSuckAmount(DispA, DispB, ValueA, ValueB);
            }
            return true;
        }

        static Task taskSetDispVolume = null;
        static bool taskSetDispVolumeError = false;
        static double valueA = 0;
        static double valueB = 0;
        public static bool SetDispVolume(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            mtx.WaitOne();
            try
            {
                switch (GDefine.DispCtrlType[0])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        short ShortA = Convert.ToInt16(ValueA * 100);
                        short ShortB = Convert.ToInt16(ValueB * 100);
                        return SetSingleShortParam(DispA, DispB, Nspira_HPC_Series.TaskCmd.EParam.Disp_Vol, ShortA, ShortB);
                    case GDefine.EDispCtrlType.HPC15:
                        {
                            double newValueA = ValueA * DispProg.PP_Head_VolumeRatio[0];
                            double newValueB = ValueB * DispProg.PP_Head_VolumeRatio[1];

                            if (DispA)// && valueA != newValueA)
                                Event.PUMP1_DISP_VOL_UPDATE.Set("Pump1DispVol", $"{valueA:f4} to {newValueA:f4}");
                            if (DispB)// && valueB != newValueB)
                                Event.PUMP2_DISP_VOL_UPDATE.Set("Pump2DispVol", $"{valueB:f4} to {newValueB:f4}");

                            bool res = HPC_15[0].SetDispAmount(DispA, DispB, newValueA, newValueB);
                            if (DispA) valueA = newValueA;
                            if (DispB) valueB = newValueB;

                            return res;
                        }
                }
                return true;
            }
            finally
            {
                mtx.ReleaseMutex();
            }
        }
        public static bool Thread_SetDispVolume_Run(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            if (taskSetDispVolume != null && !taskSetDispVolume.IsCompleted)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISPCTRL_THREAD_BUSY, "SetDispVolume " + taskSetDispVolume.Status.ToString());
                return false;
            }

            taskSetDispVolume = Task.Run(() =>
            {
                try
                {
                    taskSetDispVolumeError = !SetDispVolume(DispA, DispB, ValueA, ValueB);
                }
                catch (Exception ex)
                {
                    taskSetDispVolumeError = true;
                    Event.DEBUG_INFO.Set("Thread_SetDispVolumne_Run", ex.Message.ToString());
                };
            });
            return true;
        }
        public static bool Thread_SetDispVolume_Wait()
        {
            if (taskSetDispVolume == null) return true;

            var sw = Stopwatch.StartNew();
            while (!taskSetDispVolume.IsCompleted)
            {
                if (sw.ElapsedMilliseconds > 500)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL_THREAD_TIMEOUT, "SetDispVolume " + taskSetDispVolume.Status.ToString());
                    return false;
                }
                Thread.Sleep(0);
            }

            if (taskSetDispVolumeError)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISPCTRL_THREAD_ERROR, "SetDispVolume");
                return false;
            }

            return true;
        }

        static Task taskSetBackSuckVolume = null;
        static bool taskSetBackSuckVolumeError = false;
        static double bsValueA = 0;
        static double bsValueB = 0;
        public static bool SetBackSuckVolume(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            mtx.WaitOne();
            try
            {
                switch (GDefine.DispCtrlType[0])
                {
                    case GDefine.EDispCtrlType.HPC_OBSOLETE:
                        short ShortA = Convert.ToInt16(ValueA * 100);
                        short ShortB = Convert.ToInt16(ValueB * 100);
                        return SetSingleShortParam(DispA, DispB, Nspira_HPC_Series.TaskCmd.EParam.BS_Vol, ShortA, ShortB);
                    case GDefine.EDispCtrlType.HPC15:
                        {
                            double newValueA = ValueA * DispProg.PP_Head_VolumeRatio[0];
                            double newValueB = ValueB * DispProg.PP_Head_VolumeRatio[1];

                            if (DispA)// && bsValueA != newValueA)
                                Event.PUMP1_BACKSUCK_VOL_UPDATE.Set("Pump1BackSuckVol", $"{bsValueA:f4} to {newValueA:f4}");
                            if (DispB)// && bsValueB != newValueB)
                                Event.PUMP2_BACKSUCK_VOL_UPDATE.Set("Pump2BackSuckVol", $"{bsValueB:f4} to {newValueB:f4}");

                            bsValueA = newValueA;
                            bsValueB = newValueB;
                            return HPC_15[0].SetBackSuckAmount(DispA, DispB, newValueA, newValueB);
                        }
                }
                return true;
            }
            finally
            {
                mtx.ReleaseMutex();
            }
        }

        public static bool Thread_SetBackSuckVolume_Run(bool DispA, bool DispB, double ValueA, double ValueB)
        {
            if (taskSetBackSuckVolume != null && !taskSetBackSuckVolume.IsCompleted)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISPCTRL_THREAD_BUSY, "SetBacksuckVolume " + taskSetBackSuckVolume.Status.ToString());
                return false;
            }
            taskSetBackSuckVolume = Task.Run(() =>
            {
                try
                {
                    taskSetBackSuckVolumeError = !SetBackSuckVolume(DispA, DispB, ValueA, ValueB);
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set("Thread_SetBackSuckVolumne_Run", ex.Message.ToString());
                };
            });
            return true;
        }
        public static bool Thread_SetBackSuckVolume_Wait()
        {
            if (taskSetBackSuckVolume == null) return true;

            var sw = Stopwatch.StartNew();
            while (!taskSetBackSuckVolume.IsCompleted)
            {
                if (sw.ElapsedMilliseconds > 500)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.DISPCTRL_THREAD_TIMEOUT, "SetBackSuckVolume " + taskSetBackSuckVolume.Status.ToString());
                    return false;
                }
                Thread.Sleep(0);
            }

            if (taskSetBackSuckVolumeError)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISPCTRL_THREAD_ERROR, "SetBackSuckVolume");
                return false;
            }

            return true;
        }

        public static bool RemoveAirOn(bool DispA, bool DispB)
        {
            string EMsg = "RemoveAirOn";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    //Nspira_HPC_Series.eHead head = DispA ? Nspira_HPC_Series.eHead.A : Nspira_HPC_Series.eHead.B;
                    //if (!HPC[Head1_CtrlNo].MoveRemoveAir(head, 0))
                    //{
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                    //    return false;
                    //}
                    //break;
                    throw new Exception("HPC Version 1 not supported.");
                case GDefine.EDispCtrlType.HPC15:
                    switch (DispProg.Pump_Type)
                    {
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            if (!HPC_15[Head1_CtrlNo].RemoveAirOn(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case EPumpType.PPD:
                            if (!HPC_15[Head1_CtrlNo].PPDRemoveAirOn(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                    }
                    break;
            }
            return true;
        }
        public static bool RemoveAirOff(bool DispA, bool DispB)
        {
            string EMsg = "RemoveAirOff";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    //if (!HPC[Head1_CtrlNo].RemoveAirOff(DispA, DispB))
                    //{
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                    //    return false;
                    //}
                    //break;
                    throw new Exception("HPC Version 1 not supported.");
                case GDefine.EDispCtrlType.HPC15:
                    switch (DispProg.Pump_Type)
                    {
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            if (!HPC_15[Head1_CtrlNo].RemoveAirOff(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case EPumpType.PPD:
                            if (!HPC_15[Head1_CtrlNo].PPDRemoveAirOff(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                    }
                    break;
            }
            return true;
        }

        public static bool BarrelPressOn(bool DispA, bool DispB)
        {
            string EMsg = "BarrelPressOn";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    //if (!HPC[Head1_CtrlNo].BarrelPressOn(DispA, DispB))
                    //{
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                    //    return false;
                    //}
                    //break;
                    throw new Exception("HPC Version 1 not supported.");
                case GDefine.EDispCtrlType.HPC15:
                    switch (DispProg.Pump_Type)
                    {
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            if (!HPC_15[Head1_CtrlNo].BarrelPressOn(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case EPumpType.PPD:
                            if (!HPC_15[Head1_CtrlNo].PPDBarrelPressOn(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                    }
                    break;
            }
            return true;
        }
        public static bool BarrelPressOff(bool DispA, bool DispB)
        {
            string EMsg = "BarrelPressOn";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    //if (!HPC[Head1_CtrlNo].BarrelPressOff(DispA, DispB))
                    //{
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                    //    return false;
                    //}
                    //break;
                    throw new Exception("HPC Version 1 not supported.");
                case GDefine.EDispCtrlType.HPC15:
                    switch (DispProg.Pump_Type)
                    {
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            if (!HPC_15[Head1_CtrlNo].BarrelPressOff(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case EPumpType.PPD:
                            if (!HPC_15[Head1_CtrlNo].PPDBarrelPressOff(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                    }
                    break;
            }
            return true;
        }

        public enum ERecycleMethod { Full, FiveSteps };
        public static bool RecycleBarrel(bool DispA, bool DispB, ERecycleMethod Method)
        {
            string EMsg = "RecycleBarrel";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    //if (!HPC[Head1_CtrlNo].RecycleBarrel(DispA, DispB, (Nspira_HPC_Series.HPC.ERecycleMethod)Method))
                    //{
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                    //    return false;
                    //}
                    //break;
                    throw new Exception("HPC Version 1 not supported.");
                case GDefine.EDispCtrlType.HPC15:
                    switch (DispProg.Pump_Type)
                    {
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            if (!HPC_15[Head1_CtrlNo].RecycleBarrel(DispA, DispB, (HPC15.HPC.ERecycleMethod)Method))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case EPumpType.PPD:
                            if (!HPC_15[Head1_CtrlNo].PPDRecycleBarrel(DispA, DispB, (HPC15.HPC.ERecycleMethod)Method))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                    }
                    break;
            }
            Maint.PP.FillCount_Inc(DispA, DispB);
            return true;
        }

        public static bool CleanFill(bool DispA, bool DispB)
        {
            string EMsg = "CleanFill";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    Nspira_HPC_Series.eHead head = DispA ? Nspira_HPC_Series.eHead.A : Nspira_HPC_Series.eHead.B;
                    if (!HPC[Head1_CtrlNo].SetCleanAndFill(head, DispA && DispB))
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                        return false;
                    }
                    b_HeadAIsFilling = true;
                    break;
                case GDefine.EDispCtrlType.HPC15:
                    switch (DispProg.Pump_Type)
                    {
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            if (!HPC_15[Head1_CtrlNo].CleanFill(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            b_HeadBIsFilling = true;
                            break;
                        case EPumpType.PPD:
                            if (!HPC_15[Head1_CtrlNo].PPDCleanFill(DispA, DispB))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            b_HeadBIsFilling = true;
                            break;
                    }
                    break;
            }
            Maint.PP.FillCount_Inc(DispA, DispB);
            return true;
        }
        public static bool PurgeShot(bool DispA, bool DispB)
        {
            string EMsg = "PurgeShot";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    //if (!HPC[Head1_CtrlNo].PurgeShot(DispA, DispB, 1))
                    //{
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                    //    return false;
                    //}
                    //break;
                    throw new Exception("HPC Version 1 not supported.");
                case GDefine.EDispCtrlType.HPC15:
                    switch (DispProg.Pump_Type)
                    {
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            if (!HPC_15[Head1_CtrlNo].PurgeShot(DispA, DispB, 1))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case EPumpType.PPD:
                            if (!HPC_15[Head1_CtrlNo].PPDPurgeShot(DispA, DispB, 1))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                    }
                    break;
            }
            return true;
        }
        public static bool RecycleNeedle(bool DispA, bool DispB, int Count)
        {
            string EMsg = "RecycleNeedle";
            switch (GDefine.DispCtrlType[0])
            {
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    //if (!HPC[Head1_CtrlNo].RecycleNeedle(DispA, DispB, Count))
                    //{
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                    //    return false;
                    //}
                    //break;
                    throw new Exception("HPC Version 1 not supported.");
                case GDefine.EDispCtrlType.HPC15:
                    switch (DispProg.Pump_Type)
                    {
                        case EPumpType.PP:
                        case EPumpType.PP2D:
                            if (!HPC_15[Head1_CtrlNo].RecycleNeedle(DispA, DispB, Count))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                        case EPumpType.PPD:
                            if (!HPC_15[Head1_CtrlNo].PPDRecycleNeedle(DispA, DispB, Count))
                            {
                                Msg MsgBox = new Msg();
                                MsgBox.Show(ErrCode.DISPCTRL1_COMM_ERR, EMsg);
                                return false;
                            }
                            break;
                    }
                    break;
            }
            Maint.PP.FillCount_Inc(DispA, DispB);
            return true;
        }
        #endregion

        public static void PP_CalcDispTime(ref double Time)//get disp time
        {
            double d_DispVol_A_ul = HPC_15[0].Param.Disp_Amount[0, 0];
            double d_DispVol_B_ul = HPC_15[0].Param.Disp_Amount[0, 1];
            double d_DispVol_ul = Math.Max(d_DispVol_A_ul, d_DispVol_B_ul);//max of 2

            double d_PistonDia_mm = HPC_15[0].PP_Dia_mm;
            double d_PistonArea_mm2 = Math.PI * Math.Pow(d_PistonDia_mm / 2, 2);

            double d_DispDist_mm = d_DispVol_ul / d_PistonArea_mm2;

            double d_InitialSpeed_mm_s = 0;
            double d_MaxSpeed_mm_s = HPC_15[0].Param.Disp_SP_mm_s[0, 0];
            double d_AccelTime_s = (double)HPC_15[0].Param.Disp_AC[0, 0] / 1000;
            double d_DecelTime_s = (double)HPC_15[0].Param.Disp_DC[0, 0] / 1000;

            double d_AccelDist_mm = (d_MaxSpeed_mm_s - d_InitialSpeed_mm_s) * d_AccelTime_s;
            double d_DecelDist_mm = (d_MaxSpeed_mm_s - d_InitialSpeed_mm_s) * d_DecelTime_s;
            double d_ConstDist_mm = d_DispDist_mm - d_AccelDist_mm - d_DecelDist_mm;

            double d_ConstTime_s = d_ConstDist_mm / d_MaxSpeed_mm_s;

            double d_TotalTime_s = d_AccelTime_s + d_ConstTime_s + d_DecelTime_s;

            //double d_TotalTime_s2 = 0;
            //GetMotionData(d_InitialSpeed_mm_s, d_MaxSpeed_mm_s, d_AccelTime_s, d_DispDist_mm, ref d_TotalTime_s2);

            Time = d_TotalTime_s;
        }

        public static void LoadPPDispPara()
        {
            if (GDefine.DispCtrlType[0] != GDefine.EDispCtrlType.HPC_OBSOLETE) return;
            
            throw new Exception("HPC Version 1 not supported.");

            //DispProg.PP_HeadA_Min_Volume = 0;
            //DispProg.PP_HeadB_Min_Volume = 0;

            //double DiaA = 6;
            //double StrokeA = 19.5;
            //double OpVolA = 90;
            //if (HeadIsValid(1))
            //{
            //    int ValueA = 0;
            //    int ValueB = 0;

            //    try
            //    {
            //        GetSingleIntParam(true, false, Nspira_HPC_Series.TaskCmd.EParam.DA_PP_PistonDia, ref ValueA, ref ValueB);
            //        DiaA = (double)ValueA / 1000;
            //        GetSingleIntParam(true, false, Nspira_HPC_Series.TaskCmd.EParam.Piston_Stroke, ref ValueA, ref ValueB);
            //        StrokeA = Math.Abs((double)ValueA / 1000);
            //        GetSingleIntParam(true, false, Nspira_HPC_Series.TaskCmd.EParam.ProcessVolumePercentage, ref ValueA, ref ValueB);
            //        OpVolA = Math.Abs((double)ValueA / 100);
            //        //GetSingleIntParam(true, false, Nspira_HPC_Series.TaskPLCCmd.EParam.D, ref ValueA, ref ValueB);
            //        //OpVolA = Math.Abs((double)ValueA / 100);
            //    }
            //    catch (Exception Ex)
            //    {
            //        //EMsg = EMsg + (char)13 + Ex.Message;
            //        //throw new Exception(Ex.Message);
            //    }
            //}

            //double DiaB = 6;
            //double StrokeB = 19.5;
            //double OpVolB = 90;
            //if (HeadIsValid(2))
            //{
            //    int ValueA = 0;
            //    int ValueB = 0;
            //    try
            //    {
            //        GetSingleIntParam(false, true, Nspira_HPC_Series.TaskCmd.EParam.Piston_Dia, ref ValueA, ref ValueB);
            //        DiaB = (double)ValueB / 1000;
            //        GetSingleIntParam(false, true, Nspira_HPC_Series.TaskCmd.EParam.Piston_Stroke, ref ValueA, ref ValueB);
            //        StrokeB = Math.Abs((double)ValueB / 1000);
            //        GetSingleIntParam(false, true, Nspira_HPC_Series.TaskCmd.EParam.ProcessVolumePercentage, ref ValueA, ref ValueB);
            //        OpVolB = Math.Abs((double)ValueB / 100);
            //    }
            //    catch (Exception Ex)
            //    {
            //        //throw new Exception(Ex.Message);
            //    }
            //}

            //DispProg.PP_HeadA_Max_Volume = Math.PI * Math.Pow(DiaA / 2, 2) * (StrokeA * OpVolA);
            //DispProg.PP_HeadB_Max_Volume = Math.PI * Math.Pow(DiaB / 2, 2) * (StrokeB * OpVolB);
            //DispProg.PP_HeadA_Max_Volume = Math.Round(DispProg.PP_HeadA_Max_Volume, 3);
            //DispProg.PP_HeadB_Max_Volume = Math.Round(DispProg.PP_HeadB_Max_Volume, 3);

            //HPC_15[0].SetDispSpeed(DispA, DispB, ValueA, ValueB);
        }
        public static double MaxAmount()
        {
            switch (GDefine.DispCtrlType[0])
            {
                default:
                    return 0;
                case GDefine.EDispCtrlType.HPC_OBSOLETE:
                    return DispProg.PP_HeadA_Max_Volume;
                case GDefine.EDispCtrlType.HPC15:
                    return HPC_15[0].MaxAmount(HPC15.eDispUnit.ul);
            }
        }

        //public static CReader.DataMan DataMan = new CReader.DataMan();
        public static bool IDReader_Enabled = true;
        public static bool IDReader_Read(bool ShowImg, ref string ReadData)
        {
                    {
                        Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;

                        _Retry:
                        if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                        {
                            //TaskVision.flirCamera2[0].Snap();
                            if (!TaskVision.flirCamera2[0].Snap()) return false;
                            Image = TaskVision.flirCamera2[0].m_ImageEmgu.m_Image.Clone();
                            TaskVision.flirCamera2[0].GrabCont();
                        }
                        if (GDefine.CameraType[0] is GDefine.ECameraType.MVSGenTL)
                        {
                            TaskVision.genTLCamera[0].GrabOneImage();
                            Image = TaskVision.genTLCamera[0].mImage.Clone();
                            if (TaskVision.frmMVCGenTLCamera.Visible) TaskVision.genTLCamera[0].StartGrab();
                        }

                        if (DispProg.frm_CamView.Visible) DispProg.frm_CamView.Image = Image.ToBitmap();
                        try
                        {
                            //Euresys.Open_eVision_2_5.EImageBW8 m_Source = new Euresys.Open_eVision_2_5.EImageBW8();
                            //Euresys.Open_eVision_2_5.EMatrixCode m_MatrixCode = new Euresys.Open_eVision_2_5.EMatrixCode();
                            //Euresys.Open_eVision_2_5.EMatrixCodeReader m_MatrixCodeReader = new Euresys.Open_eVision_2_5.EMatrixCodeReader();
                            EImageBW8 m_Source = new EImageBW8();
                            EMatrixCode m_MatrixCode = new EMatrixCode();
                            EMatrixCodeReader m_MatrixCodeReader = new EMatrixCodeReader();

                            using (Image)
                            {
                                Bitmap bmp = Image.ToBitmap();

                                string s_tempfile = @"c:\temp.bmp";
                                bmp.Save(s_tempfile);

                                m_Source.Load(s_tempfile);
                                m_MatrixCode = m_MatrixCodeReader.Read(m_Source);

                                ReadData = m_MatrixCode.DecodedString;
                                if (ReadData.Length > 0) return true;
                                return false;
                            }
                        }
                        catch (Exception Ex)
                        {
                            Msg MsgBox = new Msg();
                            EMsgRes Resp = MsgBox.Show("IDReader_Read DataMatrix Error.", "", Ex.Message.ToString(),  EMcState.Error, EMsgBtn.smbRetry_Cancel, true);
                            switch (Resp)
                            {
                                case EMsgRes.smrRetry: goto _Retry;
                            }

                            return false;
                        }
                    }
        }

        public static bool TaskIdlePurge(int Mask)
        {
            string EMsg = "Task Idle Purge";

            bool DispA = ((Mask & 0x01) == 0x01);
            bool DispB = ((Mask & 0x02) == 0x02);

            try
            {
                GDefine.Status = EStatus.Busy;

                TaskDisp.FPressOn(new bool[2] { DispA, DispB });

                TPos3[] Pos3 = new TPos3[2] { TaskDisp.Needle_Purge_Pos[0], TaskDisp.Needle_Purge_Pos[1] };

                if (!TaskDisp.TaskMoveGZZ2Up()) return false;
                if (!TaskDisp.GotoXYPos(Pos3[0], Pos3[1])) return false;

                if (!TaskGantry.SetMotionParamGZZ2()) return false;
                if (!TaskDisp.TaskMoveAbsGZZ2(Pos3[0].Z, Pos3[1].Z)) return false;

                bool IsDispAPurgeMode = false;
                bool IsDispBPurgeMode = false;
                if (!TaskDisp.GetDispCtrlMode(DispA, DispB, ref IsDispAPurgeMode, ref IsDispBPurgeMode)) goto _Stop;
                if (!TaskDisp.SetDispCtrlPurgeMode(DispA, DispB)) goto _Stop;

                switch (DispProg.Pump_Type)
                {
                    case TaskDisp.EPumpType.Vermes:
                        for (int i = 0; i < 2; i++)
                        {
                            if (TaskDisp.Vermes3200[i].IsOpen)
                            {
                                if (TaskDisp.Vermes3200[i].Param.NP != 0)// TaskDisp.Idle_PurgeDuration)
                                {
                                    TaskDisp.Vermes3200[i].Param.NP = 0;// (uint)TaskDisp.Idle_PurgeDuration;
                                    TaskDisp.Vermes3200[i].Set();
                                }
                            }
                        }
                        break;
                    case TaskDisp.EPumpType.Vermes1560:
                        for (int i = 0; i < 2; i++)
                        {
                            if (TaskDisp.Vermes1560[i].IsOpen)
                            {
                                if (TaskDisp.Vermes1560[i].NP[0] != 0)
                                {
                                    TaskDisp.Vermes1560[i].NP[0] = 0;
                                    TaskDisp.Vermes1560[i].UpdateSetup();
                                }
                            }
                        }
                        break;
                }

                if (DispA || DispB)
                {
                    if (!TaskDisp.CtrlWaitReady(DispA, DispB)) goto _Stop;
                    if (!TaskDisp.TrigOn(DispA, DispB)) goto _Stop;
                    if (!TaskDisp.CtrlWaitResponse(DispA, DispB)) goto _Stop;

                    int t = GDefine.GetTickCount() + TaskDisp.Idle_PurgeDuration;
                    while (GDefine.GetTickCount() <= t) { Thread.Sleep(1); }

                    if (!TaskDisp.TrigOff(DispA, DispB)) goto _Stop;
                    if (!TaskDisp.CtrlWaitComplete(DispA, DispB)) goto _Stop;
                }

                if (!TaskDisp.TaskMoveGZZ2Up()) return false;

                if (DispProg.DispCtrl_ForceTimeMode)
                {
                    TaskDisp.SetDispCtrlTimedMode(DispA, DispB);
                }
                else
                {
                    if (!IsDispAPurgeMode)
                        TaskDisp.SetDispCtrlTimedMode(DispA, DispB);
                }

                if (Idle_PostVacTime > 0)
                {
                    //#region On Vac
                    //try
                    //{
                    //    TaskGantry.SvCleanVac(TaskGantry.TOutputState.On);
                    //}
                    //catch (Exception Ex)
                    //{
                    //    EMsg = EMsg + (char)13 + Ex.Message.ToString();
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                    //    return false;
                    //}
                    //#endregion
                    TaskGantry.SvCleanVac = true;

                    int t = GDefine.GetTickCount() + Idle_PostVacTime;
                    while (GDefine.GetTickCount() <= t) { Thread.Sleep(1); }

                    //#region Off Vac
                    //try
                    //{
                    //    TaskGantry.SvCleanVac(TaskGantry.TOutputState.Off);
                    //}
                    //catch (Exception Ex)
                    //{
                    //    EMsg = EMsg + (char)13 + Ex.Message.ToString();
                    //    Msg MsgBox = new Msg();
                    //    MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                    //    return false;
                    //}
                    //#endregion                    
                    TaskGantry.SvCleanVac = false;
                }

                GDefine.Status = EStatus.Ready;
                return true;
                _Stop:
                TaskDisp.TrigOff(DispA, DispB);
                GDefine.Status = EStatus.Stop;
                return false;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg, true);
                return false;
            }
            finally
            {
                TaskDisp.FPressOff();
            }
        }

        public static class TP
        {
            public static void TrigOn()
            {
                TaskGantry.BPress1 = true;
                TaskGantry.BVac1 = false;
            }
            public static void TrigOff()
            {
                TaskGantry.BPress1 = false;
                TaskGantry.BVac1 = true;
            }

            public static void AddOnPaths(CControl2.TAxis[] Axis)
            {
                CControl2.TOutput[] FPress = new CControl2.TOutput[] { TaskGantry._SvFPress1 };
                CControl2.TOutput[] Vac = new CControl2.TOutput[] { TaskGantry._SvFVac1 };

                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);//Prevent error by API of P1285 - KN
                CommonControl.P1245.PathAddDO(Axis, FPress, true);
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);//Prevent error by API of P1285 - KN
                CommonControl.P1245.PathAddDO(Axis, Vac, false);
            }
            public static void AddOffPaths(CControl2.TAxis[] Axis)
            {
                CControl2.TOutput[] FPress = new CControl2.TOutput[] { TaskGantry._SvFPress1 };
                CControl2.TOutput[] Vac = new CControl2.TOutput[] { TaskGantry._SvFVac1 };

                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);//Prevent error by API of P1285 - KN
                CommonControl.P1245.PathAddDO(Axis, FPress, false);
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);//Prevent error by API of P1285 - KN
                CommonControl.P1245.PathAddDO(Axis, Vac, true);
            }
            public static void TP_Shot(double ShotTime)
            {
                CControl2.TAxis[] Axis = new CControl2.TAxis[] { TaskGantry.GXAxis, TaskGantry.GYAxis, TaskGantry.GZAxis, TaskGantry.GZ2Axis };
                CommonControl.P1245.PathFree(Axis);

                ShotTime = Math.Max(ShotTime, 0);//Always 0 or +ve

                AddOnPaths(Axis);
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, ShotTime, 0, null, null);
                AddOffPaths(Axis);

                double[] RelRetDist = new double[4] { 0, 0, 0.000001, 0.000001 };//Purposely small value, follow SP_Shot, to prevent error by API of P1285 - KN
                double[] RelDummyPos = new double[4] { 0, 0, 0.000001, 0.000001 };
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel4DDirect, false, 1, 1, RelRetDist, RelDummyPos);

                CommonControl.P1245.PathEnd(Axis);
                CommonControl.P1245.PathMove(Axis);

                TaskGantry.WaitGXY();
            }
        }

        public static class SP
        {
            public static void SP_AddOnPaths(CControl2.TAxis[] Axis)
            {
                CControl2.TOutput[] FPress = new CControl2.TOutput[] { TaskGantry._SvFPress1 };
                CControl2.TOutput[] Vac = new CControl2.TOutput[] { TaskGantry._SvFVac1 };
                CControl2.TOutput[] PPress = new CControl2.TOutput[] { TaskGantry._SvPortC1 };

                double totalPulseOnDelay = DispProg.SP.PulseOnDelay[0] + DispProg.SP.IntPulseOnDelay[0];

                if (totalPulseOnDelay > 0)//PPress On Lagging
                {
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, FPress, true);
                    CommonControl.P1245.PathAddDO(Axis, Vac, false);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, totalPulseOnDelay, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, PPress, true);
                }
                else
                    if (totalPulseOnDelay < 0)//PPress On Leading
                {
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, PPress, true);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, Math.Abs(totalPulseOnDelay), 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, FPress, true);
                    CommonControl.P1245.PathAddDO(Axis, Vac, false);
                }
                else
                {
                    CommonControl.P1245.PathAddDO(Axis, Vac, false);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, FPress, true);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, PPress, true);
                }
            }
            public static void SP_AddOffPaths(CControl2.TAxis[] Axis)
            {
                CControl2.TOutput[] FPress = new CControl2.TOutput[] { TaskGantry._SvFPress1 };
                CControl2.TOutput[] Vac = new CControl2.TOutput[] { TaskGantry._SvFVac1 };
                CControl2.TOutput[] PPress = new CControl2.TOutput[] { TaskGantry._SvPortC1 };

                double totalPulseOffDelay = DispProg.SP.PulseOffDelay[0] + DispProg.SP.IntPulseOffDelay[0];

                if (totalPulseOffDelay > 0)//PPress Off Lagging
                {
                    CommonControl.P1245.PathAddDO(Axis, FPress, false);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, Vac, true);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, totalPulseOffDelay, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, PPress, false);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                }
                else
                    if (totalPulseOffDelay < 0)//PPress Off Leading
                {
                    CommonControl.P1245.PathAddDO(Axis, PPress, false);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, Math.Abs(totalPulseOffDelay), 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, FPress, false);
                    CommonControl.P1245.PathAddDO(Axis, Vac, true);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                }
                else
                {
                    CommonControl.P1245.PathAddDO(Axis, FPress, false);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, Vac, true);
                    CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                    CommonControl.P1245.PathAddDO(Axis, PPress, false);
                }
            }

            public static void SP_AddPausePaths(CControl2.TAxis[] Axis)
            {
                CControl2.TOutput[] FPress = new CControl2.TOutput[] { TaskGantry._SvFPress1 };
                CControl2.TOutput[] Vac = new CControl2.TOutput[] { TaskGantry._SvFVac1 };
                CControl2.TOutput[] PPress = new CControl2.TOutput[] { TaskGantry._SvPortC1 };

                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                CommonControl.P1245.PathAddDO(Axis, FPress, false);
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                CommonControl.P1245.PathAddDO(Axis, PPress, false);
            }
            public static void SP_AddResumePaths(CControl2.TAxis[] Axis)
            {
                CControl2.TOutput[] FPress = new CControl2.TOutput[] { TaskGantry._SvFPress1 };
                CControl2.TOutput[] Vac = new CControl2.TOutput[] { TaskGantry._SvFVac1 };
                CControl2.TOutput[] PPress = new CControl2.TOutput[] { TaskGantry._SvPortC1 };

                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                CommonControl.P1245.PathAddDO(Axis, FPress, true);
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, 0, 0, null, null);
                CommonControl.P1245.PathAddDO(Axis, PPress, true);
            }

            public static void SP_Shot(double ShotTime)
            {
                CControl2.TAxis[] Axis = new CControl2.TAxis[] { TaskGantry.GXAxis, TaskGantry.GYAxis, TaskGantry.GZAxis, TaskGantry.GZ2Axis };
                CommonControl.P1245.PathFree(Axis);

                if (DispProg.SP.PulseOnDelay[0] > 0)//PPress On Lagging
                    ShotTime = ShotTime - DispProg.SP.PulseOnDelay[0];

                if (DispProg.SP.PulseOffDelay[0] < 0)//PPress Off Leading
                    ShotTime = ShotTime - DispProg.SP.PulseOffDelay[0];

                ShotTime = Math.Max(ShotTime, 0);//Always 0 or +ve

                SP_AddOnPaths(Axis);
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.GPDELAY, false, ShotTime, 0, null, null);
                SP_AddOffPaths(Axis);

                //Add dummy move command - prevent error  by API - KN
                double[] RelRetDist = new double[4] { 0, 0, 0.000001, 0.000001 };//Purpose small value to as 0 will error by API - KN
                double[] RelDummyPos = new double[4] { 0, 0, 0.000001, 0.000001 };
                CommonControl.P1245.PathAddCmd(Axis, CControl2.EPath_MoveCmd.Rel4DDirect, false, 1, 1, RelRetDist, RelDummyPos);

                CommonControl.P1245.PathEnd(Axis);
                CommonControl.P1245.PathMove(Axis);

                TaskGantry.WaitGXY();
            }
        }
        public static FuncPurgeStage PurgeStage = new FuncPurgeStage();
        public static FuncWipeStage WipeStage = new FuncWipeStage();
    }

    public class FPressCtrl
    {
        public static TAIO AIO = new TAIO();

        public static bool Enabled
        {
            get
            {
                //return (SystemConfig.FPressAdjType == SystemConfig.EFPressAdjType.USB4704 ||
                switch (SysConfig.FPressAdjType)
                {
                    case SysConfig.EFPressAdjType.USB4704:
                    case SysConfig.EFPressAdjType.ITVRC2L:
                        return true;
                    default:
                        return false;
                }
            }
        }
        //public class TIO
        //{
        static double BPressRegFR = 0.9;//Mpa
        static double BPressRegAnalogR = 10;//0~10Vdc
        private const double MinMPa = 0;
        private const double MaxMPa = 0.7;

        static double[] _ValueRaw = new double[2] { 0, 0 };
        static double[] Value = new double[2] { 0, 0 };
        public static double[] Gain = new double[2] { 1, 1 };

        public static void SetMPa(int Ch, double[] SetValue, bool Compensate)//def unit = MPa
        {
            if (SysConfig.FPressAdjType != SysConfig.EFPressAdjType.USB4704) return;

            try
            {
                double[] val = new double[2] { Value[0], Value[1] };

                _ValueRaw[Ch] = SetValue[Ch];
                val[Ch] = SetValue[Ch] / BPressRegFR * BPressRegAnalogR;

                if (Compensate)
                {
                    val[Ch] = val[Ch] * Gain[Ch];
                }

                if (val[Ch] < 0) val[Ch] = 0;
                if (val[Ch] > 10) val[Ch] = 5;

                AIO.Write(val);
                Value[0] = val[0];
                Value[1] = val[1];
            }
            catch
            {
                throw;
            }
        }
        public static void CalTo(int Ch, double ActualValue)
        {
            if (SysConfig.FPressAdjType != SysConfig.EFPressAdjType.USB4704) return;

            try
            {
                if (_ValueRaw[Ch] == 0) Gain[Ch] = 1;
                else
                    Gain[Ch] = _ValueRaw[Ch] / ActualValue;
            }
            catch
            {
                throw;
            }
        }

        //public static void SetMPa(int Ch, double SetValue, bool Compensate)//def unit = MPa
        //{
        //    double[] Values = new double[2] { SetValue, SetValue };

        //    try
        //    {
        //        SetMPa(Ch, Values, Compensate);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        public static void AIO_SetPress_MPa(double[] Value_MPa)//def unit = MPa
        {
            if (SysConfig.FPressAdjType != SysConfig.EFPressAdjType.USB4704) return;

            try
            {
                _ValueRaw[0] = Value_MPa[0];
                _ValueRaw[1] = Value_MPa[1];

                double[] val = new double[2];

                val[0] = Value_MPa[0] / BPressRegFR * BPressRegAnalogR * Gain[0];
                val[1] = Value_MPa[1] / BPressRegFR * BPressRegAnalogR * Gain[1];

                if (val[0] < 0) val[0] = 0;
                if (val[0] > 10) val[0] = 5;
                if (val[1] < 0) val[1] = 0;
                if (val[1] > 10) val[1] = 5;

                AIO.Write(val);
                Value[0] = val[0];
                Value[1] = val[1];
            }
            catch
            {
                throw;
            }
        }
        //public static void SetPress(double[] Value_Any)
        //{
        //    if (SystemConfig.FPressAdjType != SystemConfig.EFPressAdjType.USB4704) return;

        //    double[] Value_MPa = new double[2] { Value_Any[0], Value_Any[1] };
        //    SetPress_MPa(Value_MPa);
        //}


        //public static bool AdjustPress(int Ch, ref double Value, double Min, double Max)
        //{
        //    //double d = Value[Ch] * 145.038;
        //    double d = Value * PressUnitFactor;
        //    d = Math.Round(d, 3);
        //    if (UC.AdjustExec("FPress " + (Ch + 1).ToString(), ref d, Min, Max))
        //    {
        //        //Value[Ch] = d / 145.038;
        //        Value = d / PressUnitFactor;// 145.038;

        //        try
        //        {
        //            SetMPa(Ch, Value, true);
        //        }
        //        catch (Exception Ex)
        //        {
        //            MessageBox.Show(Ex.Message.ToString());
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        public static double PressGetMPa(double Value)
        {
            //return (Value / 145.038);
            return (Value / PressUnitFactor);
        }
        public static double GetPress(double Value)//return selected unit
        {
            //return (Value * 145.038);
            return (Value * PressUnitFactor);
        }
        public static string GetPressStr(double Value)
        {
            //return (Value * 145.038);
            return (Value * PressUnitFactor).ToString(PressUnitStrFmt);
        }
        public static double GetPressMin
        {
            get
            {
                //return FPressCtrl.MinMPa * 145.038;
                return FPressCtrl.MinMPa * PressUnitFactor;
            }
        }
        public static double GetPressMax
        {
            get
            {
                //return FPressCtrl.MaxMPa * 145.038;
                return FPressCtrl.MaxMPa * PressUnitFactor;
            }
        }

        public enum EPressUnit { MPa, bar, PSI, kPa };//MPa is default unit
        private static EPressUnit _PressUnit = EPressUnit.MPa;
        public static EPressUnit PressUnit
        {
            get
            {
                return _PressUnit;
            }
            set
            {
                _PressUnit = value;
            }
        }
        public static string PressUnitStr
        {
            get { return _PressUnit.ToString(); }
        }
        private static double[] _PressUnitFactor = new double[4] { 1, 10, 145.038, 1000 };
        private static double PressUnitFactor
        {
            get
            {
                return _PressUnitFactor[(int)_PressUnit];
            }
        }
        private static int[] _PressUnitDP = new int[4] { 3, 2, 3, 1 };
        public static int PressUnitDP
        {
            get
            {
                return _PressUnitDP[(int)_PressUnit];
            }
        }
        public static string PressUnitStrFmt
        {
            get
            {
                return "F" + _PressUnitDP[(int)_PressUnit];
            }
        }
        public static double OutputPressFactor = 1;

        public static TFPress_RS232[] ITV = new TFPress_RS232[2] { new TFPress_RS232(), new TFPress_RS232() };
        const double MIN_ITV_MPa = 0;
        const double MAX_ITV_MPa = 0.9;

        public static void Open()
        {
            if (SysConfig.FPressAdjType != SysConfig.EFPressAdjType.ITVRC2L) return;

            try
            {
                ITV[0].PortName = "COM" + GDefine.FPressComport[0];
                ITV[0].Open();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("PRESS Control ITV[0] Open " + (char)9 + ex.Message.ToString());
            }

            if (GDefine.FPressComport[1] > 0)
            {
                try
                {
                    ITV[1].PortName = "COM" + GDefine.FPressComport[1];
                    ITV[1].Open();
                }
                catch (Exception ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show("PRESS Control ITV[1] Open " + (char)9 + ex.Message.ToString());
                }
            }
        }
        public static void Close()
        {
            try
            {
                ITV[0].Close();
            }
            catch { };

            try
            {
                ITV[1].Close();
            }
            catch { };
        }

        public static void Tx_SetMPa(int Ch, double Value_MPa)
        {
            int V1024 = (int)((Value_MPa / MAX_ITV_MPa) * 1023);

            if (V1024 < 0) V1024 = 0;
            if (V1024 > 1023) V1024 = 1023;
            ITV[Ch].WriteLine("SET " + V1024.ToString());
        }
        public static void Rx_SetMPa(int Ch)
        {
            string Rx = "";
            ITV[Ch].ReadLine(ref Rx);

            if (Rx.Contains("OUT OF RANGE"))
                throw new Exception("FPress Ch" + Ch.ToString() + "_ITV_Set_Out Of Range.");
            if (Rx.Contains("UNKNOWN"))
                throw new Exception("FPress Ch" + Ch.ToString() + "_ITV_Set_Unknown Command.");
        }

        static Mutex mtx = new Mutex();
        public static void Set_MPa(int Ch, double Value_MPa)
        {
            mtx.WaitOne();
            try
            {
                double d_Value = Value_MPa;
                d_Value = d_Value * OutputPressFactor;
                Tx_SetMPa(Ch, d_Value);
                Rx_SetMPa(Ch);
            }
            finally
            {
                mtx.ReleaseMutex();
            }
        }
        public static void Set_PressUnit(int Ch, double Value)
        {
            double V = Value / _PressUnitFactor[(int)_PressUnit];
            Set_MPa(Ch, V);
        }

        public static void GetL(int Ch, ref double Value)
        {
            ITV[Ch].WriteLine("REQ");

            string Rx = "";
            ITV[Ch].ReadLine(ref Rx);
            int Data1024 = 0;
            try
            {
                Data1024 = Convert.ToInt32(Rx);
            }
            catch { };

            double V = ((double)Data1024 / 1023 * MAX_ITV_MPa);
            Value = V * _PressUnitFactor[(int)_PressUnit];
            Value = Value / OutputPressFactor;
        }
        public static void GetR(int Ch, ref double Value)
        {
            ITV[Ch].WriteLine("MON");

            string Rx = "";
            ITV[Ch].ReadLine(ref Rx);
            int Data1024 = 0;
            try
            {
                Data1024 = Convert.ToInt32(Rx);
            }
            catch { };

            double V = ((double)Data1024 / 1023 * MAX_ITV_MPa);
            Value = V * _PressUnitFactor[(int)_PressUnit];
            Value = Value / OutputPressFactor;
        }


        public class Thread
        {
            static Task taskSetPress0 = null;
            static Task taskSetPress1 = null;
            static bool taskSetPress0Error = false;
            static bool taskSetPress1Error = false;

            public static bool Set_PressUnit_Old(double[] Values)//v5.2.89 Old
            {
                switch (SysConfig.FPressAdjType)
                {
                    case SysConfig.EFPressAdjType.ITVRC2L: break;
                    default:
                        return true;
                }

                if (Values[0] != 0)
                {
                    if (taskSetPress0 != null && !taskSetPress0.IsCompleted)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.PRESSCTRL_THREAD_BUSY, "Pressure1 " + taskSetPress0.Status.ToString());
                        return false;
                    }
                    taskSetPress0 = Task.Run(() =>
                    {
                        try
                        {
                            taskSetPress0Error = false;
                            FPressCtrl.Set_MPa(0, Values[0]);
                        }
                        catch
                        {
                            taskSetPress0Error = true;
                        };
                    });
                }
                if (Values[1] != 0)
                {
                    if (taskSetPress1 != null && !taskSetPress1.IsCompleted)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.PRESSCTRL_THREAD_BUSY, "Pressure2 " + taskSetPress1.Status.ToString());
                        return false;
                    }
                    taskSetPress1 = Task.Run(() =>
                    {
                        try
                        {
                            taskSetPress1Error = false;
                            FPressCtrl.Set_MPa(1, Values[1]);
                        }
                        catch
                        {
                            taskSetPress1Error = true;
                        };
                    });
                }
                return true;
            }
            public static bool Set_PressUnit(double[] Values)//v5.2.89 New - without threading
            {
                switch (SysConfig.FPressAdjType)
                {
                    case SysConfig.EFPressAdjType.ITVRC2L: break;
                    default:
                        return true;
                }

                bool[] pError = new bool[] { false, false };
                if (Values[0] != 0)
                {
                    try
                    {
                        FPressCtrl.Set_MPa(0, Values[0]);
                    }
                    catch
                    {
                        pError[0] = true;
                    };
                }
                if (Values[1] != 0)
                {
                    try
                    {
                        FPressCtrl.Set_MPa(1, Values[1]);
                    }
                    catch
                    {
                        pError[1] = true;
                    };
                }

                if (pError[0] || pError[1])
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.PRESSCTRL_ERROR, (pError[0] ? "Pressure1 " : "") + (pError[1] ? "Pressure2 " : ""));
                }
                return true;
            }
            public static bool Set_PressUnitWait()
            {
                if (taskSetPress0 != null)
                {
                    int retried = 0;
                _retry:
                    var sw = Stopwatch.StartNew();
                    while (!taskSetPress0.IsCompleted)
                    {
                        if (sw.ElapsedMilliseconds > 500)
                        {
                            if (retried++ < 1)
                            {
                                Event.DEBUG_INFO.Set("Set_PressureUnitWait", "Pressure1 Retried");
                                goto _retry;
                            }
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.PRESSCTRL_THREAD_TIMEOUT, "Pressure1 " + taskSetPress0.Status.ToString());
                            return false;
                        }
                        System.Threading.Thread.Sleep(0);
                    }

                    if (taskSetPress0Error)
                    {
                        TaskDisp.TrigOff(true, true);
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.PRESSCTRL_THREAD_ERROR, "Pressure1");
                        return false;
                    }
                }
                if (taskSetPress1 != null)
                {
                    int retried = 0;
                _retry:
                    var sw = Stopwatch.StartNew();
                    while (!taskSetPress1.IsCompleted)
                    {
                        if (sw.ElapsedMilliseconds > 500)
                        {
                            if (retried++ < 1)
                            {
                                Event.DEBUG_INFO.Set("Set_PressureUnitWait", "Pressure2 Retried");
                                goto _retry;
                            }
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.PRESSCTRL_THREAD_TIMEOUT, "Pressure2 " + taskSetPress1.Status.ToString());
                            return false;
                        }
                        System.Threading.Thread.Sleep(0);
                    }

                    if (taskSetPress1Error)
                    {
                        TaskDisp.TrigOff(true, true);
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.PRESSCTRL_THREAD_ERROR, "Pressure2");
                        return false;
                    }
                }
                return true;
            }
        }
        public static void SetPress_MPa(double[] Value_MPa)
        {
            switch (SysConfig.FPressAdjType)
            {
                case SysConfig.EFPressAdjType.USB4704:
                    AIO_SetPress_MPa(Value_MPa);
                    break;
                case SysConfig.EFPressAdjType.ITVRC2L:
                    for (int i = 0; i < 2; i++)
                    {
                        Set_MPa(i, Value_MPa[i]);
                    }
                    break;
            }
        }
        public static bool AdjustPress_MPa(int Ch, ref double[] Value_MPa, double Min, double Max)
        {
            double d = Value_MPa[Ch] * PressUnitFactor;
            d = Math.Round(d, PressUnitDP);
            if (UC.AdjustExec("FPress " + (Ch + 1).ToString(), ref d, Min, Max))
            {
                Value_MPa[Ch] = d / PressUnitFactor;
                try
                {
                    SetPress_MPa(Value_MPa);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
                return true;
            }
            return false;
        }
    }

    public class TempCtrl
    {
        public static void Open()
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
                GDefine.Autonics_TX.OpenPort(GDefine.TempCtrl_PortName);
        }
        public static bool IsOpen
        {
            get
            {
                if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
                    return GDefine.Autonics_TX.IsOpen;
                return false;
            }
        }
        public static void Close()
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
                GDefine.Autonics_TX.ClosePort();
        }
        public static void Init()
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
            {
                for (int i = 0; i < 4 - 1; i++)
                {
                    switch (GDefine.TempCtrl_Module[i])
                    {
                        case GDefine.ETempCtrlModule.LifterHeat:
                            GDefine.Autonics_TX.Stop((byte)(i + 1));
                            GDefine.Autonics_TX.Init((byte)(i + 1));
                            GDefine.Autonics_TX.Set((byte)(i + 1), Modbus.Autonics_TX.EControlOutputMode.Heat);
                            GDefine.Autonics_TX.Set((byte)(i + 1), Modbus.Autonics_TX.EInputType.J_ICH);
                            break;
                        case GDefine.ETempCtrlModule.PumpCooler:
                            GDefine.Autonics_TX.Init((byte)(i + 1));
                            GDefine.Autonics_TX.Set((byte)(i + 1), Modbus.Autonics_TX.EControlOutputMode.Cool);
                            GDefine.Autonics_TX.Set((byte)(i + 1), Modbus.Autonics_TX.EInputType.DPt_100H);
                            break;
                        case GDefine.ETempCtrlModule.ExternalHeat_RTD:
                            GDefine.Autonics_TX.Stop((byte)(i + 1));
                            GDefine.Autonics_TX.Init((byte)(i + 1));
                            GDefine.Autonics_TX.Set((byte)(i + 1), Modbus.Autonics_TX.EControlOutputMode.Heat);
                            GDefine.Autonics_TX.Set((byte)(i + 1), Modbus.Autonics_TX.EInputType.DPt_100H);
                            break;
                    }
                }
            }
        }

        public static void Pool()
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
            {
                for (int i = 0; i < 4 - 1; i++)
                {
                    switch (GDefine.TempCtrl_Module[i])
                    {
                        case GDefine.ETempCtrlModule.LifterHeat:
                        case GDefine.ETempCtrlModule.PumpCooler:
                        case GDefine.ETempCtrlModule.ExternalHeat_RTD:
                            GDefine.Autonics_TX.Pool((byte)(i + 1));
                            break;
                    }
                }
            }
        }
        public static bool Run()//return false if error
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
            {
                bool err = false;
                for (int i = 0; i < 4 - 1; i++)
                {
                    switch (GDefine.TempCtrl_Module[i])
                    {
                        case GDefine.ETempCtrlModule.LifterHeat:
                        case GDefine.ETempCtrlModule.PumpCooler:
                        case GDefine.ETempCtrlModule.ExternalHeat_RTD:
                                if (!GDefine.Autonics_TX.Run((byte)(i + 1))) err = true;
                            break;
                    }
                };
                return !err;
            }
            return true;
        }

        public static int PV(int Channel)
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
            {
                switch (GDefine.TempCtrl_Module[Channel])
                {
                    case GDefine.ETempCtrlModule.LifterHeat:
                    case GDefine.ETempCtrlModule.PumpCooler:
                    case GDefine.ETempCtrlModule.ExternalHeat_RTD:
                        return GDefine.Autonics_TX.PV[Channel];
                }
            }
            return 0;
        }
        public static int SV(int Channel)
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
            {
                switch (GDefine.TempCtrl_Module[Channel])
                {
                    case GDefine.ETempCtrlModule.LifterHeat:
                    case GDefine.ETempCtrlModule.PumpCooler:
                    case GDefine.ETempCtrlModule.ExternalHeat_RTD:
                        return GDefine.Autonics_TX.SV[Channel];
                }
            }
            return 0;
        }
        public static int AL1_Dev(int Channel)
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
            {
                switch (GDefine.TempCtrl_Module[Channel])
                {
                    case GDefine.ETempCtrlModule.LifterHeat:
                    case GDefine.ETempCtrlModule.PumpCooler:
                    case GDefine.ETempCtrlModule.ExternalHeat_RTD:
                        return GDefine.Autonics_TX.AL1_Dev[Channel];
                }
            }
            return 0;
        }
        public static bool AL1(int Channel)
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
            {
                switch (GDefine.TempCtrl_Module[Channel])
                {
                    case GDefine.ETempCtrlModule.LifterHeat:
                    case GDefine.ETempCtrlModule.PumpCooler:
                    case GDefine.ETempCtrlModule.ExternalHeat_RTD:
                        return GDefine.Autonics_TX.AL1[Channel];
                }
            }
            return false;
        }

        public static bool Set(int Channel, double SV, double Range)
        {
            if (GDefine.TempCtrl_Type == GDefine.ETempCtrl.Autonics_TX_TK)
                switch (GDefine.TempCtrl_Module[Channel])
                {
                    case GDefine.ETempCtrlModule.LifterHeat:
                    case GDefine.ETempCtrlModule.PumpCooler:
                    case GDefine.ETempCtrlModule.ExternalHeat_RTD:
                        return GDefine.Autonics_TX.Set((byte)(Channel + 1), (short)Math.Round(SV), (short)Math.Round(Range));
                }

            return true;
        }
    }

    public class Maint
    {
        public class PP
        {
            public static int[] FillCount = new int[2] { 0, 0 };
            public static void FillCount_Inc(bool A, bool B)
            {
                if (A) FillCount[0]++;
                if (B) FillCount[1]++;
                GDefine.SaveDefault();
            }
            public static DateTime[] StartDateTime = new DateTime[2] { DateTime.Now, DateTime.Now };
            public static int[] FillCountLimit = new int[2] { 0, 0 };
        }
        public class Disp
        {
            public static int[] Count = new int[2] { 0, 0 };
            public static DateTime[] CountResetDateTime = new DateTime[2] { DateTime.Now, DateTime.Now };
            public static int[] CountLimit = new int[2] { 0, 0 };
        }
    }

    public class Material
    {
        public static bool EnableUnitCounter = false;
        public class Unit
        {
            public static int[] Count = new int[2] { 0, 0 };
            public static int[] Limit = new int[2] { 0, 0 };
        }
    }

    class ExtVision
    {
        public enum EType { None, KeyenceCVX }

        static TcpClient client = null;
        static NetworkStream stream;
        static int timeOut = 3000;

        const string ERR_HEADER = "ER";
        const string CMD_ECHO = "EC";
        const string CMD_RUNMODE = "R0";
        const string CMD_SETUPMODE = "S0";
        const string CMD_TRIG1 = "T1";

        public static void Connect()
        {
            if (GDefine.ExtVisType != EType.KeyenceCVX) return;

            if (client == null) client = new TcpClient();

            if (!client.Connected)
            {
                try
                {
                    //client = new TcpClient(ipAddress, port);
                    client = new TcpClient(GDefine.ExtVisIPAddress, GDefine.ExtVisPort);
                    stream = client.GetStream();
                    Log.ExtVision.WriteByMonthDay("Connect " + GDefine.ExtVisIPAddress + ":" + GDefine.ExtVisPort.ToString());
                }
                catch
                {
                    Log.ExtVision.WriteByMonthDay("Connect Failed " + GDefine.ExtVisIPAddress + ":" + GDefine.ExtVisPort.ToString());
                }
            }
        }
        public static void Disconnect()
        {
            if (GDefine.ExtVisType != EType.KeyenceCVX) return;

            if (client.Connected)
            {
                Log.ExtVision.WriteByMonthDay("Disconnect ");
                stream.Close();
                client.Close();
                client = null;
            }
        }
        public static bool Connected
        {
            get
            {
                if (client == null) return false;

                return client.Connected;
            }
        }

        private static void TX(string msg)
        {
            if (client.Connected)
            {
                // Translate the message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg + "\r");

                // Send the message to the connected TcpServer. 
                try
                {
                    stream.Write(data, 0, data.Length);
                    Log.ExtVision.WriteByMonthDay("<: " + msg);
                }
                catch
                {
                    Log.ExtVision.WriteByMonthDay("<: TX Exception Error.");
                }
            }
        }
        private static void RX(ref string msg)
        {
            Byte[] data = new Byte[256];
            msg = "";
            int t = GDefine.GetTickCount() + timeOut;
            if (client.Connected)
            {
                while (true)
                {
                    if (GDefine.GetTickCount() > t)
                    {
                        throw new Exception("Keyence CVX Read TimeOut.");
                    }


                    if (stream.DataAvailable)
                    {
                        try
                        {
                            Int32 bytes = stream.Read(data, 0, data.Length);
                            string stringRX = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                            msg = stringRX;
                            Log.ExtVision.WriteByMonthDay(">: " + msg.Replace("\r", "").ToString());
                            if (msg.Contains("\r")) break;
                        }
                        catch
                        {
                            Log.ExtVision.WriteByMonthDay("<: RX Exception Error.");
                        }
                    }
                }
            }
        }

        public static bool Send(string cmd, string txdata, ref string rxdata)
        {
            if (GDefine.ExtVisType != EType.KeyenceCVX) return false;

            try
            {
                if (txdata != "")
                    TX(cmd + "," + txdata);
                else
                    TX(cmd);
                string rx = "";
                RX(ref rx);

                if (rx.Contains(cmd))
                {
                    rxdata = rx.Replace(cmd, "").Replace("\r", "").Replace(",", "");
                }
                else
                    throw new Exception("Keyence CVX Send Receive Message Mis-match.");
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());

                return false;
            }

            return true;
        }

        public static bool Send_Echo(string data)
        {
            if (GDefine.ExtVisType == EType.None) throw new Exception("Ext Vision not defined.");

            try
            {
                const string txdata = "echo";
                string rxdata = "";
                Send(CMD_ECHO, txdata, ref rxdata);

                if (rxdata != txdata)
                {
                    throw new Exception("Keyence CVX Send Echo fail.");
                }
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());

                return false;
            }

            return true;
        }
        public static bool Send_RunMode()
        {
            if (GDefine.ExtVisType == EType.None) throw new Exception("Ext Vision not defined.");

            try
            {
                string rxdata = "";
                Send(CMD_RUNMODE, "", ref rxdata);

                if (rxdata.StartsWith(CMD_RUNMODE)) return true;

                if (rxdata.StartsWith(ERR_HEADER))
                {
                    //ER,R0,03
                    string[] list = rxdata.Split(new char[] { ',' });
                    throw new Exception("Keyence CVX Send RunMode Error " + list[list.Count() - 1] + ".");
                }
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());
                return false;
            }

            return true;
        }
        public static bool Send_SetupMode()
        {
            if (GDefine.ExtVisType == EType.None) throw new Exception("Ext Vision not defined.");

            try
            {
                string rxdata = "";
                Send(CMD_SETUPMODE, "", ref rxdata);

                if (rxdata.StartsWith(CMD_SETUPMODE)) return true;

                if (rxdata.StartsWith(ERR_HEADER))
                {
                    //ER,S0,03
                    string[] list = rxdata.Split(new char[] { ',' });
                    throw new Exception("Keyence CVX Send SetupMode Error " + list[list.Count() - 1] + ".");
                }
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());
                return false;
            }

            return true;
        }
        public static bool Send_Trig1(ref bool OK)
        {
            if (GDefine.ExtVisType == EType.None) throw new Exception("Ext Vision not defined.");

            OK = false;
            string Cmd = CMD_TRIG1;
            try
            {
                if (stream.DataAvailable)
                {
                    string rx1 = "";
                    RX(ref rx1);
                    if (rx1.Length > 0) Log.ExtVision.WriteByMonthDay("<: Clear RX Buffer. " + rx1.Replace("\r", ""));
                }

                string rxdata = "";
                Send(Cmd, "", ref rxdata);

                if (rxdata.StartsWith(ERR_HEADER))
                {
                    //ER,T1,03
                    string[] list = rxdata.Split(new char[] { ',' });

                    //set runmode and trig again
                    if (rxdata.EndsWith("03"))
                    {
                        if (!Send_RunMode()) return false;
                        Send(Cmd, "", ref rxdata);
                        if (!rxdata.Contains(ERR_HEADER)) goto _Con;
                    }
                    throw new Exception("Keyence CVX Send " + Cmd.ToString() + " Error " + list[list.Count() - 1] + ".");
                }
                _Con:
                string rx = "";
                RX(ref rx);
                rxdata = rx.Replace("\r", "");
                OK = (rxdata == "0");

                return true;
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show(ex.Message.ToString());
                return false;
            }
        }
    }

    class TempSensor
    {

    }

    class RLMS//Registry Lot Management System
    {
        const string SUBKEY = "NSWAUTOMATION_RLMS";
        static double dHeartBeatInterval = 5;

        public static bool CheckHeartBeat()
        {
            NUtils.RegistryWR RegWR = new NUtils.RegistryWR("Software");
            string dateTime = RegWR.ReadKey(SUBKEY, "HeartBeat", "");

            if (dateTime.Length == 0) return false;

            DateTime dt = DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", null);


            if (Application.ExecutablePath.Contains("Debug"))
                return ((DateTime.Now - dt).TotalMinutes < dHeartBeatInterval);
            else
                return ((DateTime.Now - dt).TotalSeconds < dHeartBeatInterval);
        }
        public static bool LotStarted()
        {

            NUtils.RegistryWR RegWR = new NUtils.RegistryWR("Software");
            int iLotStatus = RegWR.ReadKey(SUBKEY, "LotStatus", 0);//0=not active, 1=active

            return (iLotStatus > 0);
        }
        public static bool CheckBoardID(string BoardID)
        {
            NUtils.RegistryWR RegWR = new NUtils.RegistryWR("Software");
            //reset result
            RegWR.WriteKey(SUBKEY, "BoardResult", 0);
            //write id
            RegWR.WriteKey(SUBKEY, "BoardID", BoardID);

            //wait BoardResult, timeout 5s
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            while (true)
            {
                int i = RegWR.ReadKey(SUBKEY, "BoardResult", 0);
                if (i == 0) { }
                else
                if (i == 1) return true;
                else
                if (i > 1) return false;

                if (sw.ElapsedMilliseconds > 5000)
                {
                    return false;
                }

                Thread.Sleep(5);
            }
        }
    }
}

