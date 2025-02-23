using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NDispWin
{
    public class TaskDispCtrl
    {
        public enum EDispFunc
        {
            None = 0,
            Delay = 1,

            GoMMaint = 10,
            GoPMaint = 11,
            //GoClean = 12,
            //GoPurge = 13,
            //Purge = 20,

            Shot = 20,

            DoClean = 30,
            DoPurge = 31,

            CleanFill = 40,
            RecycleBarrelF = 41,
            RecycleBarrel5S = 42,
            RecycleNeedle = 43,
        }
        public const int MAX_FUNC_CODE = 100;

        public class TFunc
        {
            public EDispFunc DispFunc;
            public int Count;
            public int Time;
            public int Wait;
            public int PostVacTime;
            public TFunc()
            {
                DispFunc = 0;
                Count = 1;
                Time = 0;
                Wait = 0;
                PostVacTime = 0;
            }
            public void Copy(TFunc Source)
            {
                DispFunc = Source.DispFunc;
                Count = Source.Count;
                Time = Source.Time;
                Wait = Source.Wait;
                PostVacTime = 0;
            }
        }
        public class TFuncs
        {
            public const int MAX_SEQ = 10;
            public string Name = "";
            public int SeqCount = 0;
            public TFunc[] Funcs = new TFunc[MAX_SEQ];
            public TFuncs()
            {
                Name = "";
                for (int i = 0; i < MAX_SEQ; i++)
                    Funcs[i] = new TFunc();
            }

            public bool Execute(bool b_Head1, bool b_Head2)
            {
                TaskDisp.FPressOn(new bool[2] { true, TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync });

                try
                {
                    for (int i = 0; i < MAX_SEQ; i++)
                    {
                        switch (Funcs[i].DispFunc)
                        {
                            case EDispFunc.None:
                                break;
                            case EDispFunc.Delay:
                                #region
                                int t_End = GDefine.GetTickCount() + Funcs[i].Time;
                                while (GDefine.GetTickCount() <= t_End)
                                {
                                    Thread.Sleep(5);
                                }
                                break;
                            #endregion

                            case EDispFunc.DoClean:
                                #region
                                if (Funcs[i].Count == 0)
                                {
                                    if (!TaskDisp.TaskCleanNeedle(b_Head1, b_Head2, true)) return false;
                                }
                                else
                                {
                                    if (!TaskDisp.TaskCleanNeedle(b_Head1, b_Head2, true, true, Funcs[i].Time, Funcs[i].Wait, Funcs[i].Count, Funcs[i].PostVacTime)) return false;
                                }
                                break;
                            #endregion
                            case EDispFunc.DoPurge:
                                #region
                                if (Funcs[i].Count == 0)
                                {
                                    if (!TaskDisp.TaskPurgeNeedle(b_Head1, b_Head2, true)) return false;
                                }
                                else
                                {
                                    if (!TaskDisp.TaskPurgeNeedle(b_Head1, b_Head2, true, true, Funcs[i].Time, Funcs[i].Wait, Funcs[i].Count, Funcs[i].PostVacTime)) return false;
                                }
                                break;
                            #endregion
                            case EDispFunc.GoPMaint:
                                if (!TaskDisp.TaskGotoPMaint()) return false;
                                break;
                            case EDispFunc.GoMMaint:
                                if (!TaskDisp.TaskGotoMMaint()) return false;
                                break;
                            case EDispFunc.Shot:
                                if (!TaskDisp.TaskMoveGZUp()) return false;
                                if (!TaskDisp.TaskGotoPMaint()) return false;

                                if (!TaskDisp.TaskShotNeedle(TaskDisp.Needle_Maint_Pos, b_Head1, b_Head2, Funcs[i].Wait, Funcs[i].Count))
                                {
                                    TaskDisp.TaskMoveGZUp();
                                    return false;
                                }
                                TaskDisp.TaskMoveGZUp();
                                break;
                            //case EDispFunc.Purge:
                            //    if (Funcs[i].Count == 0)
                            //        if (!TaskDisp.TaskPurgeCleanNeedle(false, TaskDisp.Needle_Maint_Pos, b_Head1, b_Head2, false, true, false, TaskDisp.Needle_Purge_Time, TaskDisp.Needle_Purge_Wait, 1)) return false;
                            //        else
                            //            if (!TaskDisp.TaskPurgeCleanNeedle(false, TaskDisp.Needle_Maint_Pos, b_Head1, b_Head2, false, true, false, Funcs[i].Time, Funcs[i].Wait, Funcs[i].Count)) return false;
                            //    break;
                            case EDispFunc.CleanFill:
                                #region
                                {
                                    if (!TaskDisp.TaskMoveGZUp()) return false;
                                    if (!TaskDisp.TaskGotoPMaint()) return false;

                                    int Counter = 0;

                                    while (Counter < Funcs[i].Count)
                                    {
                                        if (!TaskDisp.CleanFill(b_Head1, b_Head2))
                                        {
                                            TaskDisp.TaskMoveGZUp();
                                            return false;
                                        }
                                        Counter++;
                                    }
                                    TaskDisp.TaskMoveGZUp();
                                    break;
                                }
                            #endregion
                            case EDispFunc.RecycleBarrelF:
                                #region
                                {
                                    if (!TaskDisp.TaskMoveGZUp()) return false;
                                    if (!TaskDisp.TaskGotoPMaint()) return false;

                                    int Counter = 0;

                                    while (Counter < Funcs[i].Count)
                                    {
                                        if (!TaskDisp.RecycleBarrel(b_Head1, b_Head2, TaskDisp.ERecycleMethod.Full))
                                        {
                                            TaskDisp.TaskMoveGZUp();
                                            return false;
                                        }
                                        Counter++;
                                    }
                                    TaskDisp.TaskMoveGZUp();
                                    break;
                                }
                            #endregion
                            case EDispFunc.RecycleBarrel5S:
                                #region
                                {
                                    if (!TaskDisp.TaskMoveGZUp()) return false;
                                    if (!TaskDisp.TaskGotoPMaint()) return false;

                                    int Counter = 0;

                                    while (Counter < Funcs[i].Count)
                                    {
                                        if (!TaskDisp.RecycleBarrel(b_Head1, b_Head2, TaskDisp.ERecycleMethod.FiveSteps))
                                        {
                                            TaskDisp.TaskMoveGZUp();
                                            return false;
                                        }
                                        Counter++;
                                    }
                                    TaskDisp.TaskMoveGZUp();
                                    break;
                                }
                            #endregion
                            case EDispFunc.RecycleNeedle:
                                #region
                                {
                                    if (!TaskDisp.TaskMoveGZUp()) return false;
                                    if (!TaskDisp.TaskGotoPMaint()) return false;
                                    if (!TaskDisp.RecycleNeedle(b_Head1, b_Head2, Funcs[i].Count))
                                    {
                                        TaskDisp.TaskMoveGZUp();
                                        return false;
                                    }
                                    if (!TaskDisp.TaskMoveGZUp()) return false;
                                    break;
                                }
                                #endregion
                        }
                    }

                    return true;
                }
                finally
                {
                    //switch (DispProg.Pump_Type)
                    //{
                    //    case TaskDisp.EPumpType.Vermes:
                    //        {
                    //            bool[] On = new bool[2] { false, false };
                    //            TaskDisp.FPress(On);
                    //        }
                    //        break;
                    //}
                    TaskDisp.FPressOff();
                }
            }
        }
        public class TDispFuncs
        {
            public const int MAX_GROUP = 5;
            public TFuncs[] Group = new TFuncs[MAX_GROUP];
            public TDispFuncs()
            {
                for (int i = 0; i < MAX_GROUP; i++)
                    Group[i] = new TFuncs();
            }
            public bool Save()
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                string Filename = GDefine.SetupPath + "\\DispFunc.Setup.ini";
                IniFile.Create(Filename);

                for (int i = 0; i < MAX_GROUP; i++)
                {
                    IniFile.WriteString("DispCtrl_FuncGroup_" + i.ToString(), "Name", this.Group[i].Name);
                    IniFile.WriteInteger("DispCtrl_FuncGroup_" + i.ToString(), "SeqCount", this.Group[i].SeqCount);
                    for (int j = 0; j < TFuncs.MAX_SEQ; j++)
                    {
                        IniFile.WriteInteger("DispCtrl_FuncGroup_" + i.ToString(), "Func_" + j.ToString(), (int)this.Group[i].Funcs[j].DispFunc);
                        IniFile.WriteInteger("DispCtrl_FuncGroup_" + i.ToString(), "Time_" + j.ToString(), this.Group[i].Funcs[j].Time);
                        IniFile.WriteInteger("DispCtrl_FuncGroup_" + i.ToString(), "Count_" + j.ToString(), this.Group[i].Funcs[j].Count);
                        IniFile.WriteInteger("DispCtrl_FuncGroup_" + i.ToString(), "PostVacTime_" + j.ToString(), this.Group[i].Funcs[j].PostVacTime);
                    }
                }
                return true;
            }
            public bool Load()
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                string Filename = GDefine.SetupPath + "\\DispFunc.Setup.ini";
                IniFile.Create(Filename);

                for (int i = 0; i < MAX_GROUP; i++)
                {
                    this.Group[i].Name = IniFile.ReadString("DispCtrl_FuncGroup_" + i.ToString(), "Name", "");
                    this.Group[i].SeqCount = IniFile.ReadInteger("DispCtrl_FuncGroup_" + i.ToString(), "SeqCount", 0);
                    for (int j = 0; j < TFuncs.MAX_SEQ; j++)
                    {
                        this.Group[i].Funcs[j].DispFunc = (EDispFunc)IniFile.ReadInteger("DispCtrl_FuncGroup_" + i.ToString(), "Func_" + j.ToString(), 0);
                        this.Group[i].Funcs[j].Time = IniFile.ReadInteger("DispCtrl_FuncGroup_" + i.ToString(), "Time_" + j.ToString(), 0);
                        this.Group[i].Funcs[j].Count = IniFile.ReadInteger("DispCtrl_FuncGroup_" + i.ToString(), "Count_" + j.ToString(), 1);
                        this.Group[i].Funcs[j].PostVacTime = IniFile.ReadInteger("DispCtrl_FuncGroup_" + i.ToString(), "PostVacTime_" + j.ToString(), 0);
                    }
                }
                return true;
            }
        }
        public static TDispFuncs DispFuncs = new TDispFuncs();

        public static int GetIndex(EDispFunc Func)
        {
            int Index = 0;
            for (int i = 0; i < 100; i++)
            {
                if (Enum.GetName(typeof(EDispFunc), i) != null)
                {
                    if (Func.ToString() == Enum.GetName(typeof(EDispFunc), i).ToString()) return Index;
                    Index++;
                }
            }
            return -1;
        }
        public static EDispFunc IndexGetFunction(int Index)
        {
            int Index2 = 0;
            for (int i = 0; i < 100; i++)
            {
                if (Enum.GetName(typeof(EDispFunc), i) != null)
                {
                    if (Index == Index2) return (EDispFunc)i;
                    Index2++;
                }
            }
            return EDispFunc.None;
        }
        public static string GetStringPara(TFunc Func)
        {
            string s = Func.DispFunc.ToString();

            switch (Func.DispFunc)
            {
                case TaskDispCtrl.EDispFunc.None:
                case TaskDispCtrl.EDispFunc.GoMMaint:
                case TaskDispCtrl.EDispFunc.GoPMaint:
                    return s;
                case TaskDispCtrl.EDispFunc.Delay:
                    return s + " " + Func.Time.ToString() + "ms";
                case TaskDispCtrl.EDispFunc.DoClean:
                case TaskDispCtrl.EDispFunc.DoPurge:
                    {
                        if (Func.Count == 0)
                            return s + " " + "(Auto)";
                        else
                            return s + " " + Func.Time.ToString() + "ms + " + Func.Wait.ToString() + "ms " + "x" + Func.Count.ToString();
                    }
                case TaskDispCtrl.EDispFunc.CleanFill:
                case TaskDispCtrl.EDispFunc.RecycleBarrelF:
                case TaskDispCtrl.EDispFunc.RecycleBarrel5S:
                case TaskDispCtrl.EDispFunc.RecycleNeedle:
                    return s + " " + "x" + Func.Count.ToString();
                case TaskDispCtrl.EDispFunc.Shot:
                    return s + " Wait " + Func.Wait.ToString() + "ms " + "x" + Func.Count.ToString();
            }
            return "";
        }

        public static void AddFunc(int Group)
        {
            if (DispFuncs.Group[Group].SeqCount >= 10) return;
            
            DispFuncs.Group[Group].SeqCount++;
            int Seq = DispFuncs.Group[Group].SeqCount - 1;
            DispFuncs.Group[Group].Funcs[Seq].DispFunc = EDispFunc.None;
            DispFuncs.Group[Group].Funcs[Seq].Count = 1;
            DispFuncs.Group[Group].Funcs[Seq].Time = 0;
        }
        public static void DeleteFunc(int Group, int FuncIndex)
        {
            for (int i = FuncIndex; i < TFuncs.MAX_SEQ - 1; i++)
                DispFuncs.Group[Group].Funcs[i].Copy(DispFuncs.Group[Group].Funcs[i + 1]);
            DispFuncs.Group[Group].SeqCount--;
        }
        public static void MoveUp(int Group, int FuncIndex)
        {
            if (FuncIndex <= 0) return;

            TFunc TempFunc = new TFunc();

            TempFunc.Copy(DispFuncs.Group[Group].Funcs[FuncIndex - 1]);
            DispFuncs.Group[Group].Funcs[FuncIndex - 1].Copy(DispFuncs.Group[Group].Funcs[FuncIndex]);
            DispFuncs.Group[Group].Funcs[FuncIndex].Copy(TempFunc);
        }
        public static void MoveDn(int Group, int FuncIndex)
        {
            if (FuncIndex == DispFuncs.Group[Group].SeqCount - 1) return;

            TFunc TempFunc = new TFunc();

            TempFunc.Copy(DispFuncs.Group[Group].Funcs[FuncIndex + 1]);
            DispFuncs.Group[Group].Funcs[FuncIndex + 1].Copy(DispFuncs.Group[Group].Funcs[FuncIndex]);
            DispFuncs.Group[Group].Funcs[FuncIndex].Copy(TempFunc);
        }
    }

    public class Pump
    {
        public enum EAction
        {
            None = 0,

            MoveTo_PumpMaint = 1,
            MoveTo_MachineMaint = 2,
            MoveTo_Clean = 5,
            MoveTo_Purge = 6,
            MoveTo_Flush = 7,

            Prompt_InstValveKit = 20,
            Prompt_RemoveValveKit = 25,
            
            Prompt_AttachBarrel = 30,
            Prompt_AttachBarrelAdaptor = 31,
            Prompt_AdjustBarrelPressure = 32,

            Prompt_RemoveBarrel = 45,
            Prompt_RemoveBarrelAdaptor = 46,

            Prompt_Clean = 50,
            Prompt_Purge = 55,
            Prompt_Flush = 56,
            
            Prompt_TeachNeedle = 60,
            
            Prompt_WeightCal = 70,
            Prompt_WeightMeas = 75,
            
            Prompt_Custom = 90,
        }
        private static string ActionDesc(EAction Action)
        {
            switch (Action)
            {
                case EAction.None:
                    return "None";
                case EAction.MoveTo_PumpMaint:
                    return "Move Pump to Pump Maintenance Pos.";
                case EAction.MoveTo_MachineMaint:
                    return "Move Pump to Machine Maintenance Pos.";
                case EAction.MoveTo_Clean:
                    return "Move Pump to Clean Pos.";
                case EAction.MoveTo_Purge:
                    return "Move Pump to Purge Pos.";
                case EAction.MoveTo_Flush:
                    return "Move Pump to Flush Pos.";
                case EAction.Prompt_InstValveKit:
                    return "Install Valve Kits." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_AttachBarrel:
                    return "Attach Barrels." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_AttachBarrelAdaptor:
                    return "Attach Barrel Adaptors." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_AdjustBarrelPressure:
                    return "Adjust Barrels Pressure." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_Clean:
                    return "Clean Pump." + (char)13 + (char)10 + "OK - Clean Pump." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_Purge:
                    return "Purge Pump." + (char)13 + (char)10 + "OK - Purge Pump." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_Flush:
                    return "Flush Pump." + (char)13 + (char)10 + "OK - Flush Pump." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_TeachNeedle:
                    return "Teach Needles." + (char)13 + (char)10 + "OK - Start Teach Needle." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_WeightCal:
                    return "Perform Weight Calibration." + (char)13 + (char)10 + "OK - Start Weight Calibration." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_WeightMeas:
                    return "Perform Weight Measures." + (char)13 + (char)10 + "OK - Start Weight Measurement." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_RemoveBarrel:
                    return "Remove Barrels." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_RemoveBarrelAdaptor:
                    return "Remove Barrel Adaptors." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_RemoveValveKit:
                    return "Remove Valve Kits." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
                case EAction.Prompt_Custom:
                    return "Custom Message." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
                default:
                    return "Undefined Description." + (char)13 + (char)10 + "OK - Continue." + (char)13 + (char)10 + "Cancel - Abort.";
            }
        }

        public class TAction
        {
            public EAction Action = EAction.None;
            public string DefDesc
            {
                get
                {
                    return ActionDesc(Action);
                }
            }
            public string CustomDesc = "";//custom description
            public string AltDesc = "";//secondary language

            public TAction()
            {

            }
            public TAction(TAction Action)
            {
                this.Action = Action.Action;
                this.CustomDesc = Action.CustomDesc;
                this.AltDesc = Action.AltDesc;
            }
        }
        public class TActionSeq
        {
            public string Name = "";
            public const int MAX_SEQ = 16;
            public TAction[] Action = new TAction[MAX_SEQ]
            {
                new TAction(), new TAction(), new TAction(), new TAction(),
                new TAction(), new TAction(), new TAction(), new TAction(), 
                new TAction(), new TAction(), new TAction(), new TAction(), 
                new TAction(), new TAction(), new TAction(), new TAction()
            };

            public void MoveUp(int Seq)
            {
                if (Seq == 0) return;

                TAction TempAction = new TAction(Action[Seq - 1]);

                Action[Seq - 1] = new TAction(Action[Seq]);
                Action[Seq] = new TAction(TempAction);
            }
            public void MoveDn(int Seq)
            {
                if (Seq == MAX_SEQ - 1) return;

                TAction TempAction = new TAction(Action[Seq + 1]);

                Action[Seq + 1] = new TAction(Action[Seq]);
                Action[Seq] = new TAction(TempAction);
            }
            public bool Execute()
            {
                for (int i = 0; i < MAX_SEQ; i++)
                {
                    if (Action[i].Action == EAction.None) continue;

                    if (Action[i].Action.ToString().Contains("MoveTo"))
                    {
                    }
                    else
                    {
                        string S = ActionDesc(Action[i].Action);
                        if (Action[i].CustomDesc.Length > 0)
                            S = Action[i].CustomDesc;
                        S = S + (char)13 + (char)13 + Action[i].AltDesc;

                        DialogResult dr = MessageBox.Show(S, "Prompt", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.Cancel) return false;
                    }

                    switch (Action[i].Action)
                    {
                        case EAction.None:
                            break;
                        case EAction.MoveTo_PumpMaint:
                            if (!TaskDisp.TaskGotoPMaint()) return false;
                            break;
                        case EAction.MoveTo_MachineMaint:
                            if (!TaskDisp.TaskGotoMMaint()) return false;
                            break;
                        case EAction.MoveTo_Clean:
                            if (!TaskDisp.TaskGotoCleanNeedlePromtZ(false)) return false;
                            break;
                        case EAction.MoveTo_Purge:
                            if (!TaskDisp.TaskGotoPurgeNeedlePrompZ(false)) return false;
                            break;
                        case EAction.MoveTo_Flush:
                            if (!TaskDisp.TaskGotoFlushNeedlePrompZ(false)) return false;
                            break;
                        case EAction.Prompt_InstValveKit:
                            TaskDisp.TeachNeedle_Completed = false;
                            break;
                        case EAction.Prompt_AttachBarrel:
                            break;
                        case EAction.Prompt_AttachBarrelAdaptor:
                            break;
                        case EAction.Prompt_AdjustBarrelPressure:
                            break;
                        case EAction.Prompt_Clean:
                            {
                                bool b_Head1 = true;
                                bool b_Head2 = (DispProg.Head_Operation == TaskDisp.EHeadOperation.Sync);
                                if (!TaskDisp.TaskCleanNeedle(b_Head1, b_Head2, true)) return false;
                            }
                            break;
                        case EAction.Prompt_Purge:
                            {
                                bool b_Head1 = true;
                                bool b_Head2 = (DispProg.Head_Operation == TaskDisp.EHeadOperation.Sync);
                                if (!TaskDisp.TaskPurgeNeedle(b_Head1, b_Head2, true)) return false;
                            }
                            break;
                        case EAction.Prompt_Flush:
                            {
                                bool b_Head1 = true;
                                bool b_Head2 = (DispProg.Head_Operation == TaskDisp.EHeadOperation.Sync);
                                if (!TaskDisp.TaskFlushNeedle(b_Head1, b_Head2, true)) return false;
                            }
                            break;
                        case EAction.Prompt_TeachNeedle:
                            if (!TaskDisp.DispTool_TeachNeedle()) return false;
                            break;
                        case EAction.Prompt_WeightCal:
                            {
                                if (!TaskGantry.CheckDoorSw()) return false;
                                frm_DispCore_WeightCal frm = new frm_DispCore_WeightCal();
                                frm.ShowDialog();
                                break;
                            }
                        case EAction.Prompt_WeightMeas:
                            {
                                if (!TaskGantry.CheckDoorSw()) return false;
                                frm_DispCore_WeightMeasure frm = new frm_DispCore_WeightMeasure();
                                frm.ShowDialog();
                                break;
                            }
                        case EAction.Prompt_RemoveBarrel:
                            break;
                        case EAction.Prompt_RemoveBarrelAdaptor:
                            break;
                        case EAction.Prompt_RemoveValveKit:
                            TaskDisp.TeachNeedle_Completed = false;
                            break;
                        case EAction.Prompt_Custom:
                            break;
                    }
                }
                return true;
            }
        }
        public class Actions
        {
            public const int MAX_GROUP = 5;
            public TActionSeq[] ActionGroup = new TActionSeq[MAX_GROUP]
            {
                new TActionSeq(), new TActionSeq(), new TActionSeq(), new TActionSeq(), new TActionSeq()
            };

            public bool Enabled
            {
                get
                {
                    for (int g = 0; g < Actions.MAX_GROUP; g++)
                    {
                        if (ActionGroup[g].Name.Length > 0) return true;
                    }
                    return false;
                }
            }
            public void Load(string FullFilename)
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                IniFile.Create(FullFilename);

                for (int g = 0; g < MAX_GROUP; g++)
                {
                    ActionGroup[g].Name = IniFile.ReadString("Group_" + g.ToString(), "Name", "");
                    for (int i = 0; i < TActionSeq.MAX_SEQ; i++)
                    {
                        ActionGroup[g].Action[i].Action = (EAction)IniFile.ReadInteger("Group_" + g.ToString(), "Action_" + i.ToString(), 0);
                        if (ActionGroup[g].Action[i].Action == EAction.None) continue;
                        ActionGroup[g].Action[i].CustomDesc = IniFile.ReadString("Group_" + g.ToString(), "CustomDesc_" + i.ToString(), "");
                        ActionGroup[g].Action[i].AltDesc = IniFile.ReadString("Group_" + g.ToString(), "AltDesc_" + i.ToString(), "");
                    }
                }
            }
            public void Load()
            {
                string Filename = GDefine.SetupPath + "\\PumpAction.Setup.ini";
                Load(Filename);
            }
            public void Save(string FullFilename)
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                IniFile.Create(FullFilename);

                for (int g = 0; g < MAX_GROUP; g++)
                {
                    IniFile.WriteString("Group_" + g.ToString(), "Name", ActionGroup[g].Name);
                    for (int i = 0; i < TActionSeq.MAX_SEQ; i++)
                    {
                        IniFile.WriteInteger("Group_" + g.ToString(), "Action_" + i.ToString(), (int)ActionGroup[g].Action[i].Action);
                        IniFile.WriteString("Group_" + g.ToString(), "CustomDesc_" + i.ToString(), ActionGroup[g].Action[i].CustomDesc);
                        IniFile.WriteString("Group_" + g.ToString(), "AltDesc_" + i.ToString(), ActionGroup[g].Action[i].AltDesc);
                    }
                }
            }
            public void Save()
            {
                string Filename = GDefine.SetupPath + "\\PumpAction.Setup.ini";
                Save(Filename);
            }
        }
        public static Actions Action = new Actions();
    }
}
