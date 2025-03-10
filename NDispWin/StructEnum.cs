using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using NSW.Net;
using System.Xml;

namespace NDispWin
{
    public enum ELevel
    {
        None,
        Operator,
        Technician,
        Engineer,
        Admin,
        NSW
    }

    public enum ERunStationNo
    {
        Station1,
        Station2,
        Station3,
        Station4,
        Station5,
        Station6,
        Station7,
        Station8,
    }
    public enum ERunRegion
    {
        All = 0,//Run all
        H1 = 1,//H1 = First Half; A251(Pump1)
        H2 = 2,//H2 = Second Half; Pump3 and 4
    }
    public enum ERunMode
    {
        Normal = 0,
        Dry = 1,
        Camera = 2,
    }
    public enum EBoardStatus
    {
        None = 0,
        Ready = 1,
        Busy = 2,
        Stop = 3,
        Error = 4,
        Reject = 10,
    }

    internal enum EHeadNo
    {
        Head1 = 1,
        Head2 = 2,
        Head12 = 3,
    }
    internal enum EVisionRef
    {
        No1 = 0,
        No2 = 1,
        No1Pat2 = 2,
        No2Pat2 = 3,
    }
    internal enum ERefPatType
    {
        Single = 0,
        AverageOfTwo = 1,
        BestOfTwo = 2,
        //CoarseFine = 3,
    }
    internal enum ERefResult
    {
        OK = 0,
        FailMinScore = 1,
        FailRefXYTol = 2,
        FailPatDistTol = 3,
        FailRefDistTol = 4,
        FailAngle = 5,
        FailOther = 6
    }
    internal enum EDotMode
    {
        Cont = 0,
        ExtTimed = 1,
    }
    internal enum ECondEvent
    {
        None = 0,
        IsFilling = 1,
        Counter = 10,
    }
    internal enum ELogic
    {
        And = 0,
        Or = 1
    }
    internal enum ECondition
    {
        Equal = 0,
        NotEqual = 1,
        GreaterThan = 2,
        LessThan = 3,
        GreaterOrEqual = 4,
        LessOrEqual = 5,
        Between = 6,
        NotBetween = 7,
    }

    internal enum EAlignType { Board, Clstr, ClstrCol, ClstrRow, Unit, UnitCol, UnitRow }

    internal enum ECntrType { Frame, Unit, Time };
    internal enum ECntrActionType { None, Message }

    internal enum EMoveLineRev { None, OddRow, OddCol}

    internal class TRefData
    {
        public bool Ready;
        public double DatumX;
        public double DatumY;
        public double NewDatumX;
        public double NewDatumY;
        public double Angle;
        public bool OK;
        public TRefData()
        {
            Ready = false;
            DatumX = 0;
            DatumY = 0;
            NewDatumX = 0;
            NewDatumY = 0;
            Angle = 0;
            OK = true;
        }
        public void Clear()
        {
            Ready = false;
            DatumX = 0;
            DatumY = 0;
            NewDatumX = 0;
            NewDatumY = 0;
            Angle = 0;
            OK = true;
        }
        public void Copy(TRefData SourceData)
        {
            Ready = SourceData.Ready;
            DatumX = SourceData.DatumX;
            DatumY = SourceData.DatumY;
            NewDatumX = SourceData.NewDatumX;
            NewDatumY = SourceData.NewDatumY;
            Angle = SourceData.Angle;
            OK = SourceData.OK;
        }
    }
    internal class TRefDatas
    {
        public TRefData[] Data = new TRefData[TLayout.MAX_UNITS];
        public TRefDatas()
        {
            for (int i = 0; i < TLayout.MAX_UNITS; i++)
            {
                Data[i] = new TRefData();
            }
        }
    }

    internal class THeightData
    {
        public bool Ready;
        public double A;
        public double B;
        public double C;
        public List<TPos3> DataPoints;
        public bool OK;
        public THeightData()
        {
            Clear();
        }
        public void Clear()
        {
            Ready = false;
            A = 0;
            B = 0;
            C = 0;
            DataPoints = new List<TPos3>();
            OK = true;
        }
        public void Copy(THeightData SourceData)
        {
            Ready = SourceData.Ready;
            A = SourceData.A;
            B = SourceData.B;
            C = SourceData.C;
            OK = SourceData.OK;
            DataPoints = SourceData.DataPoints;
        }
    }

    public enum EVMMethod { Rate, Trend, };
    public enum EVMCntrType { Frame, Time };
    public enum EVMAdjType { Value, Pcnt };
    internal class TVolumeMap
    {
        public const int MAX_MAP = 1024;
        public bool Enabled = false;
        public EVMCntrType RefType = EVMCntrType.Frame;
        public EVMAdjType AdjType = EVMAdjType.Value;
        public double[] Value = new double[MAX_MAP];
        public TVolumeMap()
        {
            Enabled = false;
            RefType = EVMCntrType.Frame;
            AdjType = EVMAdjType.Value;
            for (int i = 0; i < MAX_MAP; i++)
                Value[i] = 0;
        }
        public void Clear()
        {
            Enabled = false;
            RefType = EVMCntrType.Frame;
            AdjType = EVMAdjType.Value;
            for (int i = 0; i < MAX_MAP; i++)
                Value[i] = 0;
        }
    }

    internal enum EVolumeOfstMode {Manual, Auto};

    internal enum EFailAction { Normal, PromptReject, AutoReject }

    public enum ECMMethod { Pattern, Binary }

    internal enum EExecCond { None, ContinueBoard, StartNthBoard };//condition to execute cmd, Cond Operator Cond Param

    public enum EMapBin
    {
        None = 0, BinNG = 100,
        MapOK = 1, MapNG = 101,
        RefOK = 2, RefNG = 102,
        RefOK2 = 7, RefNG2 = 107,
        HeightOK = 3, HeightNG = 103,
        UnitMarkOK = 4, UnitMarkNG = 104,
        VVIOK = 6, VVING = 106,
        Continue1 = 10,
        Continue2 = 11,
        Continue3 = 12,
        Continue4 = 13,
        Continue5 = 14,
        Continue6 = 15,
        Continue7 = 16,
        Continue8 = 17,
        Complete = 200,
        CompleteOK = 201,
        CompleteNG = 202,
        InMapNG = 210,
        Bypass = 220,
        PreMapNG = 255,
    }
    #region Map Category
    internal class TMap
    {
        public EMapBin[] Bin = new EMapBin[TLayout.MAX_UNITS];
        public TMap()
        {
            for (int i = 0; i < TLayout.MAX_UNITS; i++)
            {
                Bin[i] = new int();
                Bin[i] = 0;
            }
        }
        public TMap(TMap SourceMap)
        {
            for (int i = 0; i < TLayout.MAX_UNITS; i++)
            {
                this.Bin[i] = new int();
                this.Bin[i] = SourceMap.Bin[i];
            }
        }
        public void Clear()
        {
            for (int i = 0; i < TLayout.MAX_UNITS; i++)
            {
                Bin[i] = 0;
            }
        }
        public bool Save(string FullFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));
            if (File.Exists(FullFilename)) File.Delete(FullFilename);

            IniFile Inifile = new IniFile();
            Inifile.Create(FullFilename);
            for (int i = 0; i < TLayout.MAX_UNITS; i++)
            {
                if (Bin[i] > 0) Inifile.WriteInteger("PreMap", i.ToString(), (byte)Bin[i]);
            }

            return true;
        }
        public bool SaveXML(XmlWriter writer, int ID, int UnitCount = 0)
        {
            int[] intArr = new int[UnitCount];
            for (int i = 0; i < UnitCount; i++)
            {
                intArr[i] = (int)Bin[i];
            }

            DispProg.WriteSubEntry(writer, ID.ToString(), intArr);

            return true;
        }

        public bool Load(string FullFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            Clear();

            if (File.Exists(FullFilename))
            {
                IniFile Inifile = new IniFile();
                Inifile.Create(FullFilename);
                for (int i = 0; i < TLayout.MAX_UNITS; i++)
                {
                    Bin[i] = (EMapBin)Inifile.ReadInteger("PreMap", i.ToString(), 0);
                }
            }

            return true;
        }
        public bool LoadXML(XmlReader reader, int ID)
        {
            Clear();

            try
            {
                int[] intArr = new int[TLayout.MAX_UNITS];
                intArr = DispProg.ReadSubEntry(reader, intArr);

                for (int i = 0; i < TLayout.MAX_UNITS; i++)
                {
                    Bin[i] = (EMapBin)intArr[i];
                }
            }
            catch
            {
            }

            return true;
        }

        public void AppendInProcess(string fileName, int unitIndex, Point rc)//append in process map to a file using minimal resources, unitIndex no start index 0
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine($"{unitIndex},{rc.X},{rc.Y},{(int)Bin[unitIndex]}");
                }
            }
            catch
            {
            }
        }

        public bool LoadInProcess(string fileName)//load in process map
        {
            if (!File.Exists(fileName)) return false;

            string fileLines = "";
            StreamReader sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite));
            try
            {
                fileLines = sr.ReadToEnd();
                sr.Close();
            }
            finally
            {
                sr.Dispose();
            }

            string[] lines = fileLines.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in  lines)
            {
                string[] s = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                int unitIndex = 0;
                try
                {
                    s[0] = s[0].Trim();
                    unitIndex = Convert.ToInt16(s[0]);
                }
                catch 
                {
                    continue;
                }

                int bin = (int)EMapBin.None;
                try
                {
                    s[3] = s[3].Trim();
                    bin = Convert.ToInt16(s[3]);
                }
                catch
                {
                    continue;
                }
                Bin[unitIndex] = (EMapBin)bin;
            }

            return true;
        }

    }
    public class TMapColor
    {
        public Pen[] Pen;
        public SolidBrush[] SBrush;
        public TMapColor()
        {
            this.Pen = Enumerable.Range(0, 256).Select(x => new Pen(Color.Black)).ToArray();
            this.SBrush = Enumerable.Range(0, 256).Select(x => new SolidBrush(Color.Transparent)).ToArray();

            Pen[(byte)EMapBin.None] = new Pen(Color.Black);//0
            SBrush[(byte)EMapBin.None] = new SolidBrush(Color.Honeydew);
            Pen[(byte)EMapBin.MapOK] = new Pen(Color.Black);//1
            SBrush[(byte)EMapBin.MapOK] = new SolidBrush(Color.LightYellow);
            Pen[(byte)EMapBin.MapNG] = new Pen(Color.Black);//101
            SBrush[(byte)EMapBin.MapNG] = new SolidBrush(Color.Black);
            Pen[(byte)EMapBin.RefOK] = new Pen(Color.Black);//2
            SBrush[(byte)EMapBin.RefOK] = new SolidBrush(Color.Yellow);
            Pen[(byte)EMapBin.RefNG] = new Pen(Color.Black);//102
            SBrush[(byte)EMapBin.RefNG] = new SolidBrush(Color.Red);

            Pen[(byte)EMapBin.RefOK2] = new Pen(Color.Black);//7
            SBrush[(byte)EMapBin.RefOK2] = new SolidBrush(Color.Wheat);
            Pen[(byte)EMapBin.RefNG2] = new Pen(Color.Black);//107
            SBrush[(byte)EMapBin.RefNG2] = new SolidBrush(Color.Red);

            Pen[(byte)EMapBin.HeightOK] = new Pen(Color.Black);//3
            SBrush[(byte)EMapBin.HeightOK] = new SolidBrush(Color.Orange);
            Pen[(byte)EMapBin.HeightNG] = new Pen(Color.Black);//103
            SBrush[(byte)EMapBin.HeightNG] = new SolidBrush(Color.Red);
            Pen[(byte)EMapBin.UnitMarkOK] = new Pen(Color.Black);//4
            SBrush[(byte)EMapBin.UnitMarkOK] = new SolidBrush(Color.OrangeRed);
            Pen[(byte)EMapBin.UnitMarkNG] = new Pen(Color.Black);//104
            SBrush[(byte)EMapBin.UnitMarkNG] = new SolidBrush(Color.Red);
            Pen[(byte)EMapBin.VVIOK] = new Pen(Color.Black);//6
            SBrush[(byte)EMapBin.VVIOK] = new SolidBrush(Color.DarkGreen);
            Pen[(byte)EMapBin.VVING] = new Pen(Color.Black);//106
            SBrush[(byte)EMapBin.VVING] = new SolidBrush(Color.Pink);

            Pen[(byte)EMapBin.Continue1] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Continue1] = new SolidBrush(Color.PaleGreen);
            Pen[(byte)EMapBin.Continue2] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Continue2] = new SolidBrush(Color.PaleGreen);
            Pen[(byte)EMapBin.Continue3] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Continue3] = new SolidBrush(Color.PaleGreen);
            Pen[(byte)EMapBin.Continue4] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Continue4] = new SolidBrush(Color.PaleGreen);
            Pen[(byte)EMapBin.Continue5] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Continue5] = new SolidBrush(Color.PaleGreen);
            Pen[(byte)EMapBin.Continue6] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Continue6] = new SolidBrush(Color.PaleGreen);
            Pen[(byte)EMapBin.Continue7] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Continue7] = new SolidBrush(Color.PaleGreen);
            Pen[(byte)EMapBin.Continue8] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Continue8] = new SolidBrush(Color.PaleGreen);

            Pen[(byte)EMapBin.Complete] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Complete] = new SolidBrush(Color.Lime);
            Pen[(byte)EMapBin.CompleteOK] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.CompleteOK] = new SolidBrush(Color.Lime);
            Pen[(byte)EMapBin.CompleteNG] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.CompleteNG] = new SolidBrush(Color.Pink);

            Pen[(byte)EMapBin.InMapNG] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.InMapNG] = new SolidBrush(Color.Maroon);
            Pen[(byte)EMapBin.Bypass] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.Bypass] = new SolidBrush(Color.DarkGray);
            Pen[(byte)EMapBin.PreMapNG] = new Pen(Color.Black);
            SBrush[(byte)EMapBin.PreMapNG] = new SolidBrush(Color.Gray);
        }
    }
    #endregion

    internal class TModelList
    {
        public const int MAX_MODEL = 16;
        public const int MAX_PARA = 29;
        public enum EModel
        {
            DnStartV,
            DnSpeed,
            DnAccel,
            DispGap,

            DnWait,
            StartDelay,

            DispTime,
            DispVol,
            BSuckVol,
            LineStartV,
            LineSpeed,
            LineSpd2,
            LineAccel,
            PumpSpeed,

            FPressA,
            FPressB,

            EndDelay,
            PostWait,

            RetStartV,
            RetSpeed,
            RetAccel,
            RetGap,
            RetWait,

            UpStartV,
            UpSpeed,
            UpAccel,
            UpGap,
            UpWait,

            LiftDist
        }

        public double PanelGap = 10;
        public double FirstGapWait = 500;
        public TPara[] Model = new TPara[MAX_MODEL];

        public class TPara
        {
            public double[] Para = new double[MAX_PARA];
            public TPara()
            {
                Para[(int)EModel.DnStartV] = 0;
                Para[(int)EModel.DnSpeed] = 0;
                Para[(int)EModel.DnAccel] = 0;
                Para[(int)EModel.DispGap] = 2;

                Para[(int)EModel.DnWait] = 25;
                Para[(int)EModel.StartDelay] = 10;

                Para[(int)EModel.DispTime] = 0;
                Para[(int)EModel.DispVol] = 0;
                Para[(int)EModel.BSuckVol] = 0;
                Para[(int)EModel.LineStartV] = 0;
                Para[(int)EModel.LineSpeed] = 10;
                Para[(int)EModel.LineSpd2] = 0;
                Para[(int)EModel.LineAccel] = 0;
                Para[(int)EModel.PumpSpeed] = 0;

                Para[(int)EModel.FPressA] = 0;
                Para[(int)EModel.FPressB] = 0;

                Para[(int)EModel.EndDelay] = 10;
                Para[(int)EModel.PostWait] = 25;

                Para[(int)EModel.RetStartV] = 0;
                Para[(int)EModel.RetSpeed] = 0;
                Para[(int)EModel.RetAccel] = 0;
                Para[(int)EModel.RetGap] = 10;
                Para[(int)EModel.RetWait] = 25;

                Para[(int)EModel.UpStartV] = 0;
                Para[(int)EModel.UpSpeed] = 0;
                Para[(int)EModel.UpAccel] = 0;
                Para[(int)EModel.UpGap] = 0;
                Para[(int)EModel.UpWait] = 0;

                Para[(int)EModel.LiftDist] = 0;
            }
        }
        public static string[] PPModelUnits = { "mm/s", "mm/s", "mm/s2", "mm", 
                                                    "ms", "ms", 
                                                    "ms", 
                                                    "ul", "ul", "mm/s", "mm/s", "mm/s","mm/s2", "mm/s",
                                                    "unit","unit",
                                                    "ms", "ms", 
                                                    "mm/s", "mm/s", "mm/s2", "mm", "ms", 
                                                    "mm/s", "mm/s", "mm/s2", "mm", "ms",
                                                    "mm" };

        public static string[] HMModelUnits = { "mm/s", "mm/s", "mm/s2", "mm", 
                                                    "ms", "ms",
                                                    "ms",
                                                    "ms", "ms", "mm/s", "mm/s", "mm/s", "mm/s2", "rpm",
                                                    "unit","unit",
                                                    "ms", "ms", 
                                                    "mm/s", "mm/s", "mm/s2", "mm", "ms", 
                                                    "mm/s", "mm/s", "mm/s2", "mm", "ms",
                                                    "mm" };

        public List<int> BasicPara = new List<int>();
        public static double[] WarnLLimit = {1,1,100,0,
                                                    0, 0,
                                                    0,
                                                    0, 0, 0, 1, 1, 5, 0,
                                                    0, 0,
                                                    0, 0,
                                                    0, 0, 100, 4, 0,
                                                    0, 0, 100, 4, 0,
                                                    -2};
        public static double[] WarnULimit = {200,600,5000,50,
                                                    0, 0,
                                                    5000,
                                                    1000, 1000, 200, 25, 25, 5000, 500,
                                                    130, 130,
                                                    0, 0,
                                                    200, 600, 5000, 50, 0,
                                                    200, 600, 5000, 50, 0,
                                                    2};
        public TModelList()
        {
            for (int i = 0; i < MAX_MODEL; i++)
                Model[i] = new TPara();

            BasicPara.Add((int)TModelList.EModel.DispGap);

            BasicPara.Add((int)TModelList.EModel.DnWait);
            BasicPara.Add((int)TModelList.EModel.StartDelay);
            BasicPara.Add((int)TModelList.EModel.LineSpeed);
            BasicPara.Add((int)TModelList.EModel.EndDelay);
            BasicPara.Add((int)TModelList.EModel.DnWait);

            BasicPara.Add((int)TModelList.EModel.RetGap);
            BasicPara.Add((int)TModelList.EModel.RetWait);
        }

        public bool Load(string FullFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            if (!File.Exists(FullFilename)) return true;

            try
            {
                FileStream F = new FileStream(FullFilename, FileMode.Open, FileAccess.ReadWrite, FileShare.Write);
                StreamReader R = new StreamReader(F);

                string S = R.ReadToEnd();
                R.Close();

                string[] Lines = S.Split(new char[] { (char)10 }, StringSplitOptions.RemoveEmptyEntries);

                #region read common para
                string[] L1 = Lines[1].Split((char)9);
                try
                {
                    PanelGap = (double)Convert.ToDouble(L1[0]);
                    FirstGapWait = (double)Convert.ToDouble(L1[1]);
                }
                catch { };
                #endregion

                #region read para
                int[] ParaIndex = new int[TModelList.MAX_PARA];
                string[] header = Lines[2].Split((char)9);
                int idx = 0;
                foreach (string s in header)
                {
                    string Name = s.Trim();
                    if (Name.Length == 0) continue;

                    int tag = 0;
                    for (int i = 0; i < TModelList.MAX_PARA; i++)
                    {
                        if (Enum.GetName(typeof(EModel), i) != null)
                        {
                            if (Name == Enum.GetName(typeof(EModel), i)) break;
                            tag++;
                        }
                    }
                    ParaIndex[idx] = tag;
                    idx++;
                }

                //handle new Para. fill new para
                int i_Cntr = 0;
                int i_InvIdx = TModelList.MAX_PARA - 1;
                for (int i = 0; i < TModelList.MAX_PARA; i++)
                {
                    while (ParaIndex[i] != i_Cntr)
                    {
                        ParaIndex[i_InvIdx] = i_Cntr;
                        i_InvIdx--;
                        i_Cntr++;
                        if (ParaIndex[i_InvIdx] != 0) break;
                    }
                    if (ParaIndex[i_InvIdx] != 0) break;
                    i_Cntr++;
                }

                for (int l = 0; l < TModelList.MAX_MODEL; l++)
                {
                    string[] modelLine = Lines[l + 3].Split((char)9);

                    for (int i = 0; i < TModelList.MAX_PARA; i++)
                    {
                        double v = 0;
                        try
                        {
                            v = (double)Convert.ToDouble(modelLine[i]);
                        }
                        catch
                        {
                            v = 0;
                        }

                        try
                        {
                            Model[l].Para[ParaIndex[i]] = v;
                        }
                        catch { };
                    }
                }
                #endregion
            }
            catch { };
            return true;
        }
        public bool Save(string FullFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            FileStream F = new FileStream(FullFilename, FileMode.Create, FileAccess.Write, FileShare.Write);
            StreamWriter W = new StreamWriter(F);
            try
            {
                #region write common para
                W.WriteLine("PanelGap" + (char)9 + "FirstGapWait");
                W.WriteLine(PanelGap.ToString("F3") + (char)9 + FirstGapWait.ToString("F3"));
                #endregion

                #region write header
                string Header = "";
                for (int i = 0; i < 1000; i++)
                {
                    string S = Enum.GetName(typeof(EModel), i);
                    if (S != null)
                    {
                        Header = Header + S + (char)9;
                    }
                }
                W.WriteLine(Header);
                #endregion

                #region write para
                for (int i = 0; i < TModelList.MAX_MODEL; i++)
                {
                    string modelLine = "";
                    for (int j = 0; j < TModelList.MAX_PARA; j++)
                    {
                        string S = "";
                        S = Model[i].Para[j].ToString("F3");

                        modelLine = modelLine + S + (char)9;
                    }
                    W.WriteLine(modelLine);
                }
                #endregion
            }
            finally
            {
                W.Close();
            }
            return true;
        }
        public bool LoadXML(string FullFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            if (!File.Exists(FullFilename)) return true;

            NUtils.XmlFile xmlFile = new NUtils.XmlFile(FullFilename, "");

            xmlFile.Open();

            try
            {
                #region read common para
                PanelGap = xmlFile.GetValue("Program", "Model", "Common", "PanelGap", PanelGap);
                FirstGapWait = xmlFile.GetValue("Program", "Model", "Common", "FirstGapWait", FirstGapWait);
                #endregion

                #region read header
                string[] header = new string[MAX_PARA];
                header = xmlFile.GetValue("Program", "Model", "Model", "Header", header);

                int[] paraIndex = new int[TModelList.MAX_PARA];
                int idx = 0;
                foreach (string s in header)
                {
                    if (s == null) continue;
                    string name = s.Trim();
                    if (name.Length == 0) continue;

                    int tag = 0;
                    for (int i = 0; i < TModelList.MAX_PARA; i++)
                    {
                        if (Enum.GetName(typeof(EModel), i) != null)
                        {
                            if (name == Enum.GetName(typeof(EModel), i)) break;
                            tag++;
                        }
                    }
                    if (tag < TModelList.MAX_PARA)
                    {
                        paraIndex[idx] = tag;
                        idx++;
                    }
                }
                #endregion

                #region handle new Para. fill new para
                int i_Cntr = 0;
                int i_InvIdx = TModelList.MAX_PARA - 1;
                for (int i = 0; i < TModelList.MAX_PARA; i++)
                {
                    while (paraIndex[i] != i_Cntr)
                    {
                        paraIndex[i_InvIdx] = i_Cntr;
                        i_InvIdx--;
                        i_Cntr++;
                        if (paraIndex[i_InvIdx] != 0) break;
                    }
                    if (paraIndex[i_InvIdx] != 0) break;
                    i_Cntr++;
                }
                #endregion

                #region read para
                for (int modelNo = 0; modelNo < TModelList.MAX_MODEL; modelNo++)
                {
                    double[] modelPara = new double[TModelList.MAX_PARA];
                    modelPara = xmlFile.GetValue("Program", "Model", "Model", modelNo.ToString(), modelPara);
                    for (int j = 0; j < TModelList.MAX_PARA; j++)
                    {
                        Model[modelNo].Para[paraIndex[j]] = modelPara[j];
                    }
                }
                #endregion
            }
            finally
            {
            }
            return true;
        }
        public bool SaveXML(string FullFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            NUtils.XmlFile xmlFile = new NUtils.XmlFile(FullFilename, "");

            xmlFile.Open();

            try
            {
                #region write common para
                xmlFile.SetValue("Program", "Model", "Common", "PanelGap", PanelGap);
                xmlFile.SetValue("Program", "Model", "Common", "FirstGapWait", FirstGapWait);
                #endregion
                 
                #region write header
                string[] header = new string[MAX_PARA];
                for (int i = 0; i < MAX_PARA; i++)
                {
                    header[i] = Enum.GetName(typeof(EModel), i);
                }
                xmlFile.SetValue("Program", "Model", "Model", "Header", header);
                #endregion

                #region write para
                for (int modelNo = 0; modelNo < TModelList.MAX_MODEL; modelNo++)
                {
                    double[] modelPara = new double[TModelList.MAX_PARA];
                    for (int j = 0; j < TModelList.MAX_PARA; j++)
                    {
                        modelPara[j] = Model[modelNo].Para[j];
                    }
                    xmlFile.SetValue("Program", "Model", "Model", modelNo.ToString(), modelPara);
                }
                #endregion
            }
            finally
            {
                xmlFile.Save();
            }
            return true;
        }
        public void LoadXML(XmlReader reader)
        {
            try
            {
                while (reader.Read())
                {
                    if (reader.Name == "section" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                    if (reader.Name == "entry" && reader["name"] == "Common")
                    {
                        while (reader.Read())
                        {
                            if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                            if (reader.Name == "subentry")
                            {
                                string attName = reader["name"];

                                switch (attName)
                                {
                                    case "PanelGap":
                                        PanelGap = DispProg.ReadSubEntry(reader, PanelGap); break;
                                    case "FirstGapWait":
                                        FirstGapWait = DispProg.ReadSubEntry(reader, 1); break;
                                }
                            }
                        }
                    }

                    string[] header = new string[MAX_PARA];
                    int[] paraIndex = new int[TModelList.MAX_PARA];
                    double[] modelPara = new double[MAX_PARA];
                    if (reader.Name == "entry" && reader["name"] == "Model")
                    {
                        while (reader.Read())
                        {
                            if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                            if (reader.Name == "subentry")
                            {
                                string attName = reader["name"];
                                int iNo = -1;
                                switch (attName)
                                {
                                    case "Header":
                                        header = DispProg.ReadSubEntry(reader, header);

                                        #region read header
                                        int idx = 0;
                                        foreach (string s in header)
                                        {
                                            if (s == null) continue;
                                            string name = s.Trim();
                                            if (name.Length == 0) continue;

                                            int tag = 0;
                                            for (int i = 0; i < TModelList.MAX_PARA; i++)
                                            {
                                                if (Enum.GetName(typeof(EModel), i) != null)
                                                {
                                                    if (name == Enum.GetName(typeof(EModel), i)) break;
                                                    tag++;
                                                }
                                            }
                                            if (tag < TModelList.MAX_PARA)
                                            {
                                                paraIndex[idx] = tag;
                                                idx++;
                                            }
                                        }
                                        #endregion

                                        #region handle new Para. fill new para
                                        int i_Cntr = 0;
                                        int i_InvIdx = TModelList.MAX_PARA - 1;
                                        for (int i = 0; i < TModelList.MAX_PARA; i++)
                                        {
                                            while (paraIndex[i] != i_Cntr)
                                            {
                                                paraIndex[i_InvIdx] = i_Cntr;
                                                i_InvIdx--;
                                                i_Cntr++;
                                                if (paraIndex[i_InvIdx] != 0) break;
                                            }
                                            if (paraIndex[i_InvIdx] != 0) break;
                                            i_Cntr++;
                                        }
                                        #endregion

                                        break;
                                    case "0": iNo = 0; break;
                                    case "1": iNo = 1; break;
                                    case "2": iNo = 2; break;
                                    case "3": iNo = 3; break;
                                    case "4": iNo = 4; break;
                                    case "5": iNo = 5; break;
                                    case "6": iNo = 6; break;
                                    case "7": iNo = 7; break;
                                    case "8": iNo = 8; break;
                                    case "9": iNo = 9; break;
                                    case "10": iNo = 10; break;
                                    case "11": iNo = 11; break;
                                    case "12": iNo = 12; break;
                                    case "13": iNo = 13; break;
                                    case "14": iNo = 14; break;
                                    case "15": iNo = 15; break;
                                }

                                if (iNo >= 0)
                                {
                                    modelPara = DispProg.ReadSubEntry(reader, modelPara);
                                    for (int j = 0; j < TModelList.MAX_PARA; j++)
                                    {
                                        Model[iNo].Para[paraIndex[j]] = modelPara[j];
                                        //if (paraIndex[j] == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[iNo].Set($"{Model[iNo].Para[paraIndex[j]]:f3}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public void SaveXML(XmlWriter writer)
        {
            writer.WriteStartElement("entry");
            writer.WriteAttributeString("name", "Common");
            DispProg.WriteSubEntry(writer, "PanelGap", PanelGap);
            DispProg.WriteSubEntry(writer, "FirstGapWait", FirstGapWait);
            writer.WriteEndElement();//endentry

            writer.WriteStartElement("entry");
            writer.WriteAttributeString("name", "Model");
            #region write header
            string[] header = new string[MAX_PARA];
            for (int i = 0; i < MAX_PARA; i++)
            {
                header[i] = Enum.GetName(typeof(EModel), i);
            }
            DispProg.WriteSubEntry(writer, "Header", header);
            #endregion
            #region write para
            for (int modelNo = 0; modelNo < TModelList.MAX_MODEL; modelNo++)
            {
                double[] modelPara = new double[TModelList.MAX_PARA];
                for (int j = 0; j < TModelList.MAX_PARA; j++)
                {
                    modelPara[j] = Model[modelNo].Para[j];
                }
                DispProg.WriteSubEntry(writer, modelNo.ToString(), modelPara);
            }
            #endregion
            writer.WriteEndElement();//endentry
        }

        public void SetDispVolumeDefault()
        {
            for (int i = 0; i < TModelList.MAX_MODEL; i++)
            {
                    Model[i].Para[(int)EModel.DispVol] = 0;
            }
        }

        public bool LoadSetting(string FullFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            if (!File.Exists(FullFilename)) return true;

            try
            {
                FileStream F = new FileStream(FullFilename, FileMode.Open, FileAccess.ReadWrite, FileShare.Write);
                StreamReader R = new StreamReader(F);

                string S = R.ReadToEnd();
                R.Close();

                string[] Lines = S.Split(new char[] { (char)10 }, StringSplitOptions.RemoveEmptyEntries);

                #region read BasicPara list
                string[] Para = Lines[1].Split((char)9);
                BasicPara.Clear();
                foreach (string s in Para)
                {
                    string Name = s.Trim();
                    if (Name.Length == 0) continue;

                    for (int i = 0; i < 1000; i++)
                    {
                        if (Enum.GetName(typeof(EModel), i) != null)
                        {
                            if (Name == Enum.GetName(typeof(EModel), i))
                            {
                                BasicPara.Add(i);
                                break;
                            }
                        }
                    }
                }
                #endregion

                #region read Spec
                int[] ParaIndex = new int[TModelList.MAX_PARA];
                string[] header = Lines[2].Split((char)9);
                int idx = 0;
                foreach (string s in header)
                {
                    string Name = s.Trim();
                    if (Name.Length == 0) continue;

                    int tag = 0;
                    for (int i = 0; i < 1000; i++)
                    {
                        if (Enum.GetName(typeof(EModel), i) != null)
                        {
                            if (Name == Enum.GetName(typeof(EModel), i)) break;
                            tag++;
                        }
                    }
                    ParaIndex[idx] = tag;
                    idx++;
                }

                for (int l = 0; l < TModelList.MAX_MODEL; l++)
                {
                    string[] LSpecLine = Lines[3].Split((char)9);
                    string[] USpecLine = Lines[4].Split((char)9);

                    for (int i = 0; i < TModelList.MAX_PARA; i++)
                    {
                        double lv = 0;
                        try
                        {
                            lv = (double)Convert.ToDouble(LSpecLine[i]);
                        }
                        catch
                        {
                            lv = 0;
                        }
                        TModelList.WarnLLimit[ParaIndex[i]] = lv;

                        double uv = 0;
                        try
                        {
                            uv = (double)Convert.ToDouble(USpecLine[i]);
                        }
                        catch
                        {
                            uv = 0;
                        }
                        TModelList.WarnLLimit[ParaIndex[i]] = uv;
                    }
                }
                #endregion
            }
            catch { };
            return true;
        }
        public bool SaveSetting(string FullFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FullFilename)))
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilename));

            FileStream F = new FileStream(FullFilename, FileMode.Create, FileAccess.Write, FileShare.Write);
            StreamWriter W = new StreamWriter(F);
            try
            {
                #region write BasicPara list
                W.WriteLine("BasicPara");
                string ParaName = "";
                for (int i = 0; i < BasicPara.Count(); i++)
                {
                    string S = Enum.GetName(typeof(EModel), BasicPara[i]);
                    if (S != null)
                    {
                        ParaName = ParaName + S + (char)9;
                    }
                }
                W.WriteLine(ParaName);

                string Para = "";
                for (int i = 0; i < 1000; i++)
                {
                    string S = Enum.GetName(typeof(EModel), i);
                    if (S != null)
                    {
                        Para = Para + S + (char)9;
                    }
                }
                W.WriteLine(Para);
                #endregion

                #region write header
                string Header = "";
                for (int i = 0; i < 1000; i++)
                {
                    string S = Enum.GetName(typeof(EModel), i);
                    if (S != null)
                    {
                        Header = Header + S + (char)9;
                    }
                }
                W.WriteLine(Header);
                #endregion

                #region write LSpec
                string LSpecValue = "";
                for (int j = 0; j < TModelList.MAX_PARA; j++)
                {
                    string S = "";
                    S = TModelList.WarnLLimit[j].ToString("F3");

                    LSpecValue = LSpecValue + S + (char)9;
                }
                W.WriteLine(LSpecValue);
                #endregion

                #region write USpec
                string USpecValue = "";
                for (int j = 0; j < TModelList.MAX_PARA; j++)
                {
                    string S = "";
                    S = TModelList.WarnULimit[j].ToString("F3");

                    USpecValue = USpecValue + S + (char)9;
                }
                W.WriteLine(USpecValue);
                #endregion
            }
            finally
            {
                W.Close();
            }
            return true;
        }
    }
    internal class TModelPara
    {
        public double DnStartV = 0;
        public double DnSpeed = 0;
        public double DnAccel = 0;
        public double DispGap = 0;

        public int DnWait = 0;
        public double StartDelay = 0;

        public double DispTime = 0;

        public double DispVol = 0;
        public double BSuckVol = 0;

        public double LineStartV = 0;
        public double LineSpeed = 0;
        public double LineSpeed2 = 0;
        public double LineSpeedAct = 0;
        public double LineAccel = 0;
        public double PumpSpeed = 0;

        public double FPressA = 0;
        public double FPressB = 0;

        public double EndDelay = 0;
        public int PostWait = 0;

        public double RetStartV = 0;
        public double RetSpeed = 0;
        public double RetAccel = 0;
        public double RetGap = 0;
        public int RetWait = 0;

        public double UpStartV = 0;
        public double UpSpeed = 0;
        public double UpAccel = 0;
        public double UpGap = 0;
        public int UpWait = 0;

        public double LiftDist = 0;

        public double PanelGap = 0;
        public int FirstGapWait = 0;

        public TModelPara(TModelList ModelList, int ModelNo)
        {
            try
            {
                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DnStartV] == 0)
                    DnStartV = TaskGantry.GZAxis.Para.StartV;
                else
                    DnStartV = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DnStartV];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DnSpeed] == 0)
                    DnSpeed = TaskGantry.GZAxis.Para.FastV;
                else
                    DnSpeed = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DnSpeed];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DnAccel] == 0)
                    DnAccel = TaskGantry.GZAxis.Para.Accel;
                else
                    DnAccel = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DnAccel];

                DispGap = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DispGap];

                DnWait = (int)ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DnWait];
                StartDelay = (int)ModelList.Model[ModelNo].Para[(int)TModelList.EModel.StartDelay];

                DispTime = (int)ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DispTime];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DispVol] == 0)
                    DispVol = 0;
                else
                    DispVol = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.DispVol];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.BSuckVol] == 0)
                    BSuckVol = 0;
                else
                    BSuckVol = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.BSuckVol];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.PumpSpeed] == 0)
                    PumpSpeed = 0;
                else
                    PumpSpeed = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.PumpSpeed];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineStartV] == 0)
                    LineStartV = TaskGantry.GXAxis.Para.StartV;
                else
                    LineStartV = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineStartV];

                LineSpeedAct = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineSpeed];
                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineSpeed] == 0)
                    LineSpeed = TaskGantry.GXAxis.Para.FastV;
                else
                    LineSpeed = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineSpeed];

                //if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineSpeed2] == 0)
                //    LineSpeed2 = LineSpeed;
                //else
                    LineSpeed2 = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineSpd2];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineAccel] == 0)
                    LineAccel = TaskGantry.GXAxis.Para.Accel;
                else
                    LineAccel = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LineAccel];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.FPressA] == 0)
                    FPressA = DispProg.FPress[0];
                else
                    FPressA = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.FPressA];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.FPressB] == 0)
                    FPressB = DispProg.FPress[1];
                else
                    FPressB = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.FPressB];

                EndDelay = (int)ModelList.Model[ModelNo].Para[(int)TModelList.EModel.EndDelay];
                PostWait = (int)ModelList.Model[ModelNo].Para[(int)TModelList.EModel.PostWait];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.RetStartV] == 0)
                    RetStartV = TaskGantry.GZAxis.Para.StartV;
                else
                    RetStartV = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.RetStartV];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.RetSpeed] == 0)
                    RetSpeed = TaskGantry.GZAxis.Para.FastV;
                else
                    RetSpeed = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.RetSpeed];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.RetAccel] == 0)
                    RetAccel = TaskGantry.GZAxis.Para.Accel;
                else
                    RetAccel = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.RetAccel];

                RetGap = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.RetGap];
                RetWait = (int)ModelList.Model[ModelNo].Para[(int)TModelList.EModel.RetWait];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.UpStartV] == 0)
                    UpStartV = TaskGantry.GZAxis.Para.StartV;
                else
                    UpStartV = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.UpStartV];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.UpSpeed] == 0)
                    UpSpeed = TaskGantry.GZAxis.Para.FastV;
                else
                    UpSpeed = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.UpSpeed];

                if (ModelList.Model[ModelNo].Para[(int)TModelList.EModel.UpAccel] == 0)
                    UpAccel = TaskGantry.GZAxis.Para.Accel;
                else
                    UpAccel = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.UpAccel];

                UpGap = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.UpGap];
                UpWait = (int)ModelList.Model[ModelNo].Para[(int)TModelList.EModel.UpWait];

                LiftDist = ModelList.Model[ModelNo].Para[(int)TModelList.EModel.LiftDist];

                PanelGap = ModelList.PanelGap;
                FirstGapWait = (int)ModelList.FirstGapWait;

                if (GDefine.OperationSpeed == EOperationSpeed.SlowMo)
                {
                    DnWait = (int)(DnWait * GDefine.Operation_SpeedMode_SlowSpeedTimeFactor);
                    StartDelay = (int)(StartDelay * GDefine.Operation_SpeedMode_SlowSpeedTimeFactor);
                    EndDelay = (int)(EndDelay * GDefine.Operation_SpeedMode_SlowSpeedTimeFactor);
                    PostWait = (int)(PostWait * GDefine.Operation_SpeedMode_SlowSpeedTimeFactor);
                    RetWait = (int)(RetWait * GDefine.Operation_SpeedMode_SlowSpeedTimeFactor);
                    UpWait = (int)(UpWait * GDefine.Operation_SpeedMode_SlowSpeedTimeFactor);
                }
            }
            catch
            {
                throw;
            }
        }
    }


    internal class TCounter
    {
        public int[] Count = new int[10];
        public TCounter()
        {
            for (int i = 0; i < 10; i++)
            {
                Count[i] = new int();
                Count[i] = 0;
            }
        }
    }
    internal class DispProgUI
    {
        public static List<int> CommandList = new List<int>();
        public static List<int> Command = new List<int>();
        public static int CommandSelection = 0x1000;
        public static bool CommandSortAZ = false;

        internal enum EFunction
        {
            //None = 0,
            Init = 1,
            LsrOfst = 4,
            CamOfst = 5,
            NdleOfst = 6,

            PMaint = 10,
            MMaint = 11,

            Clean = 15,
            Purge = 16,
            PurgeStage = 18,

            TrigA = 20,
            TrigB = 21,
            ChuckVac = 25,
            CleanVac = 26,

            Map = 30,
            Ctrl1 = 35,
            Ctrl2 = 36,

            PPFill = 40,
            PPDFill = 41,

            PumpAdj = 50,
            DrawOfst = 55,

            ULoadPre = 61,
            LoadPro = 64,
            //Output = 70,{removed}

            MHS_Return = 70,
            MHS_LoadPre = 71,
            MHS_LoadPro = 72,
            MHS_LoadFwd = 73,
            MHS_Unload = 74,

            WipeA = 80,
            WipeB = 81,
        }
        public static List<int> FunctionList = new List<int>();
        public static List<int> Function = new List<int>();

        public static void AddDefault()
        {
            Command.Clear();
            //Add default commands
            Command.Add((int)DispProg.ECmd.LAYOUT);
            Command.Add((int)DispProg.ECmd.FOR_LAYOUT);
            Command.Add((int)DispProg.ECmd.END_LAYOUT);
            Command.Add((int)DispProg.ECmd.DOT);
            Command.Add((int)DispProg.ECmd.MOVE);
            Command.Add((int)DispProg.ECmd.LINE);
            Command.Add((int)DispProg.ECmd.ARC);
            Command.Add((int)DispProg.ECmd.CIRC);
            Command.Add((int)DispProg.ECmd.DWELL);
            Command.Add((int)DispProg.ECmd.DO_REF);
            Command.Add((int)DispProg.ECmd.USE_REF);
            Command.Add((int)DispProg.ECmd.SUB);
        }

        public static void Load()
        {
            IniFile IniFile = new IniFile();
            IniFile.Create(GDefine.DispProgUISettingFile);

            CommandList.Clear();
            for (int i = 0; i < 1000; i++)
            {
                string s = Enum.GetName(typeof(DispProg.ECmd), i);
                if (s != null) CommandList.Add(i);
            }

            AddDefault();
            for (int i = 0; i < 1000; i++)
            {
                int i_Command = 0;
                i_Command = IniFile.ReadInteger("Command", i.ToString(), 0);
                if (i_Command == 0) break;

                if (!Enum.IsDefined(typeof(DispProg.ECmd), i_Command)) continue;

                if (i_Command > 0 && !Command.Contains(i_Command)) Command.Add(i_Command);
            }
            CommandSelection = IniFile.ReadInteger("Command", "Selection", 0x1000);
            CommandSortAZ = IniFile.ReadBool("Command", "SortAZ", false);

            FunctionList.Clear();
            for (int i = 0; i < 100; i++)
            {
                string s = Enum.GetName(typeof(EFunction), i);
                if (s != null) FunctionList.Add(i);
            }
            Function.Clear();
            for (int i = 0; i < 100; i++)
            {
                int i_Function = 0;
                i_Function = IniFile.ReadInteger("TRControlPanel", i.ToString(), 0);
                if (i_Function > 0) Function.Add(i_Function);
                if (i_Function == 0) break;
            }
        }
        public static void Save()
        {
            File.Delete(GDefine.DispProgUISettingFile);

            IniFile IniFile = new IniFile();
            IniFile.Create(GDefine.DispProgUISettingFile);

            for (int i = 0; i < Command.Count; i++)
            {
                IniFile.WriteInteger("Command", i.ToString(), Command[i]);
            }
            IniFile.WriteInteger("Command", Command.Count.ToString(), 0);
            IniFile.WriteInteger("Command", "Selection", CommandSelection);
            IniFile.WriteBool("Command", "SortAZ", CommandSortAZ);

            for (int i = 0; i < Function.Count; i++)
            {
                IniFile.WriteInteger("TRControlPanel", i.ToString(), Function[i]);
            }
            IniFile.WriteInteger("TRControlPanel", Function.Count.ToString(), 0);
        }
    }

    public enum ECamNo { Cam00, Cam01, Cam02, None, };

    internal class StructEnum
    {
    }
}
