using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace NDispWin
{
    internal class TaskMeasure
    {
        public class WHData
        {
            public List<double> Dist = new List<double>();
            public List<double> Data = new List<double>();
            public List<double> SData = new List<double>();
            public List<double> DData = new List<double>();

            public void Add(double Dist, double Data)
            {
                this.Dist.Add(Dist);
                this.Data.Add(Data);
            }
            public int Count
            {
                get { return this.Data.Count(); }
            }
            public void MinMax(ref double Min, ref double Max)
            {
                if (this.Data.Count > 0)
                {
                    Min = this.Data.Min();
                    Max = this.Data.Max();
                }
            }
            public double Height()
            {
                double Min = 0;
                double Max = 0;
                MinMax(ref Min, ref Max);
                return Max - Min;
            }
            //public void DoMedianLow()
            //{
            //    int SweepSize = 10;
            //    List<double> NewData = new List<double>();
            //    for (int i = SweepSize; i < Data.Count; i++)
            //    {
            //        List<double> SweepSample = new List<double>();
            //        for (int j = 0; j < SweepSize; j++)
            //        {
            //            SweepSample.Add(Data[i - j]);
            //        }
            //        NSW.Net.Stats Stats = new NSW.Net.Stats();
            //        double Median = Stats.Median(SweepSample);

            //        if (i == SweepSize)
            //        {
            //            for (int k = 0; k < SweepSize; k++)
            //            {
            //                NewData.Add(Median);
            //            }
            //        }
            //        else
            //            NewData.Add(Median);
            //    }
            //    Data.Clear();
            //    Data = NewData;
            //}
            public double Width()
            {
                double Min = 0;
                double Max = 0;
                MinMax(ref Min, ref Max);

                double Thld = 0.025;
                int SweepSize = 3;

                double Start = 0;
                double End = 0;
                for (int i = SweepSize; i < Data.Count; i++)
                {
                    //List<double> SweepSample = new List<double>();
                    //for (int j = 0; j < SweepSize; j++)
                    //{
                    //    SweepSample.Add(Data[i - j]);
                    //}
                    //NSW.Net.Stats Stats = new NSW.Net.Stats();
                    //double Median = Stats.Median(SweepSample);

                    if (Start == 0)
                    {
                        //                        if (Data[i] >= Median + Thld)
                        if (Data[i] >= Data[i - 1] + Thld)
                        {
                            Start = Dist[i];
                            break;
                        }
                    }
                }
                for (int i = Data.Count - 2; i > SweepSize; i--)
                {
                    //List<double> SweepSample = new List<double>();
                    //for (int j = 0; j < SweepSize; j++)
                    //{
                    //    SweepSample.Add(Data[i - j]);
                    //}
                    //NSW.Net.Stats Stats = new NSW.Net.Stats();
                    //double Median = Stats.Median(SweepSample);

                    if (End == 0)
                    {
                        //if (Data[i] >= Median + Thld)
                        if (Data[i] >= Data[i + 1] + Thld)
                        {
                            End = Dist[i];
                            break;
                        }
                    }
                }

                return End - Start;
            }
            public void Clear()
            {
                this.Dist.Clear();
                this.Data.Clear();
            }
            public void Save(string FFileName)
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                IniFile.Create(FFileName);

                for (int i = 0; i < Dist.Count(); i++)
                {
                    IniFile.WriteDouble("Dist", i.ToString(), Dist[i]);
                    IniFile.WriteDouble("Data", i.ToString(), Data[i]);
                }
            }
            public void Load(string FFileName)
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                IniFile.Create(FFileName);

                Dist.Clear();
                Data.Clear();
                for (int i = 0; i < 65535; i++)
                {
                    double d_Dist = IniFile.ReadDouble("Dist", i.ToString(), 0);
                    double d_Data = IniFile.ReadDouble("Data", i.ToString(), 0);
                    if (d_Data == 0) break;
                    Dist.Add(d_Dist);
                    Data.Add(d_Data);
                }
            }
            public List<double> Smooth(int factor)
            {
                List<double> SArr = new List<double>();
                List<double> Arr = new List<double>();
                NSW.Net.Stats Stat = new NSW.Net.Stats();
                for (int i = 0; i < Data.Count; i++)
                {
                    if (i < Math.Floor((double)factor / 2) || i >= Data.Count - Math.Floor((double)factor / 2))
                    {
                        SArr.Add(Data[i]);
                        //SArr.Add(Data[i]);
                    }
                    else
                    {
                        Arr.Clear();
                        for (int j = 0; j < factor; j++)
                        {
                            Arr.Add(Data[i - (int)Math.Floor((double)factor / 2) + j]);
                        }
                        //NewData.Dist.Add(Data[i]);
                        //SArr.Add(Stat.Median(Arr));
                        SArr.Add(Stat.Percentile(Arr, 50, NSW.Net.PercentileMethod.Excel));
                    }
                }
                return SArr;
            }

            private double SampleWidth = 0.2;//mm

            private double AveDistPerData = 0;
            private double StartHeight = 0;
            private double EndHeight = 0;
            private double Peak1 = 0;
            private double Peak2 = 0;
            public double Height_Start
            {
                get
                {
                    if (Data.Count == 0) throw new Exception("Invalid Data Count.");
                    //return;
                    List<double> Arr = new List<double>();
                    List<double> SArr = new List<double>();
                    NSW.Net.Stats Stat = new NSW.Net.Stats();

                    //smooth data
                    #region
                    int Sm = 20;
                    for (int i = 0; i < Data.Count; i++)
                    {
                        if (i < Math.Floor((double)Sm / 2) || i >= Data.Count - Math.Floor((double)Sm / 2))
                        {
                            SArr.Add(Data[i]);
                        }
                        else
                        {
                            Arr.Clear();
                            for (int j = 0; j < Sm; j++)
                            {
                                Arr.Add(Data[i - (int)Math.Floor((double)Sm / 2) + j]);
                            }
                            SArr.Add(Stat.Percentile(Arr, 50, NSW.Net.PercentileMethod.Excel));//.Average());
                        }
                    }
                    #endregion

                    SData.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                            SData.Add(SArr[i]);// StartHeight);
                    }

                    for (int i = 0; i < Data.Count; i++)
                    {
                        // Data[i] = SArr[i];
                    }
                    //calc ave dist per data
                    AveDistPerData = (Dist[10] - Dist[0]) / 10;
                    int Samples = (int)(SampleWidth / AveDistPerData);

                    //calc start height
                    Arr.Clear();
                    for (int i = 0; i < Samples; i++)
                    {
                        Arr.Add(SArr[i]);
                    }
                    StartHeight = Stat.Median(Arr);

                    //calc end height
                    Arr.Clear();
                    for (int i = Data.Count - Samples; i < Data.Count; i++)
                    {
                        Arr.Add(SArr[i]);
                    }
                    EndHeight = Stat.Median(Arr);

                    //peak if (y(t) - y(t-dt) > m) && (y(t) - y(t+dt) > m)
                    //where dt and m are parameters to control time-delay and sensitivity
                    double Sensitivity = 0.2; //0.2
                    double DistDelay = 0.5;// 0.5;
                    int dt = (int)(DistDelay / AveDistPerData);

                    //int Peak = 0;
                    List<int> PeakIndex = new List<int>();
                    List<double> Peak = new List<double>();

                    Arr.Clear();
                    //SData.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                        //if (i < Samples)
                        //{
                        //    SData.Add(StartHeight);
                        //}
                        //else
                        //    if (i >= Data.Count - Samples)
                        //    {
                        //        SData.Add(EndHeight);
                        //    }
                        //    else

                        if (i < dt || i >= Data.Count - dt)
                        {
                            //SData.Add(Data.Min());
                        }
                        else
                            if ((SArr[i] - SArr[i - dt] > Sensitivity) && (SArr[i] - SArr[i + dt] > Sensitivity))
                            {
                                PeakIndex.Add(i);
                                Arr.Add(SArr[i]);
                                //SData.Add(Data.Max());
                            }
                            else
                            {
                                if (Arr.Count > 0)
                                {
                                    Peak.Add(Stat.Median(Arr));
                                    Arr.Clear();
                                }
                                //SData.Add(Data.Min());
                            }
                    }

                    if (Peak.Count < 2) throw new Exception("Peak not found");
                    Peak1 = Peak[0];
                    Peak2 = Peak[1];

                    double H1 = Peak[0] - StartHeight;
                    double H2 = Peak[1] - EndHeight;
                    double H_Ave = (H1 + H2) / 2;



                    int W_Count = 0;
                    List<double> CX = new List<double>();
                    double CrossOver = SArr.Min() + (SArr.Max() - SArr.Min()) * 0.4;
                    
                    double Profile = StartHeight;//Data.Min();
                    DData.Clear();

                    for (int i = 0; i < Data.Count; i++)
                    {
                        //if (SData.Count < i) 
                        DData.Add(Profile);//Data.Min());
                        if (i == 0 || i == Data.Count - 1) continue;

                        if (SArr[i] < CrossOver && SArr[i + 1] > CrossOver)
                        {
                            //if (W_Count == 0)
                            //Start = i;
                            CX.Add(Dist[i]);
                            Profile = Peak[W_Count];// Data.Max();
                            W_Count++;
                        }

                        if (SArr[i - 1] > CrossOver && SArr[i] < CrossOver)
                        {
                            CX.Add(Dist[i]);
                            //Width.Add(Dist[i] - Dist[Start]);

                            Profile = CrossOver;// Data.Min();
                            if (W_Count == 2) Profile = EndHeight;
                        }
                        
                        DData[i] = Profile;
                    }

                    if (CX.Count < 4) throw new Exception("Edge not found");
                    double Width1 = CX[1] - CX[0];
                    double Width2 = CX[3] - CX[2];
                    double Width_Ave = (Width1 + Width2)/2;
                    double ID = CX[2] - CX[1];
                    double OD = CX[3] - CX[0];

                    return 0;
                }
            }


            List<int> EdgeUp_Idx = new List<int>();
            List<int> EdgeDn_Idx = new List<int>();
            List<double> BHeight = new List<double>();
            List<double> Peak = new List<double>();
            public void Analyse(int Peaks)
            {
                NSW.Net.Stats Stat = new NSW.Net.Stats();

                List<double> Arr = new List<double>();

                SData = Smooth(10);

                //find edges;
                EdgeUp_Idx.Clear();
                EdgeDn_Idx.Clear();
                BHeight.Clear();
                Peak.Clear();


                double Threshold = SData.Min() + (SData.Max() - SData.Min()) * 0.5;

                for (int i = 0; i < Data.Count; i++)
                {
                    //Edge_up if (y(t) < th && y(t+1) > th)
                    //Edge_dn if (y(t-1) > th && y(t) < th)
                    //where th is CrossOver threshold
                    if (i == 0 || i == Data.Count - 1) continue;

                    if (SData[i] < Threshold && SData[i + 1] > Threshold)
                    {
                        EdgeUp_Idx.Add(i);
                    }

                    if (SData[i - 1] > Threshold && SData[i] < Threshold)
                    {
                        EdgeDn_Idx.Add(i);
                    }
                }

                if (EdgeUp_Idx.Count < Peaks) throw new Exception("Edges not found.");


                //calc ave dist per data
                AveDistPerData = (Dist[10] - Dist[0]) / 10;
                int Samples = (int)(SampleWidth / AveDistPerData);

                BHeight.Clear();
                //calc start height
                Arr.Clear();
                for (int i = 0; i < Samples; i++)
                {
                    Arr.Add(SData[i]);
                }
                BHeight.Add(Stat.Median(Arr));

                //calc end height
                Arr.Clear();
                for (int i = Data.Count - Samples; i < Data.Count; i++)
                {
                    Arr.Add(SData[i]);
                }
                BHeight.Add(Stat.Median(Arr));

                List<int> Peak_Idx = new List<int>();
                for (int i = 0; i < EdgeUp_Idx.Count; i++)
                {
                    Peak_Idx.Add((EdgeUp_Idx[i] + EdgeDn_Idx[i]) / 2);
                }

                for (int p = 0; p < Peak_Idx.Count; p++)
                {
                    Arr.Clear();
                    for (int i = 0; i < Samples; i++)
                    {
                        Arr.Add(SData[i + Peak_Idx[p] - (Samples / 2)]);
                    }
                    Peak.Add(Stat.Median(Arr));
                }

                //if (Peaks > 1)
                //{
                //    Arr.Clear();
                //    for (int i = 0; i < Samples; i++)
                //    {
                //        Arr.Add(SData[i + Peak_Idx[1] - Samples / 2]);
                //    }
                //    Peak.Add(Stat.Median(Arr));
                //}

                if (Peak.Count < Peaks) throw new Exception("Peaks not found.");

                DData.Clear();
                double Profile = BHeight[0];
                for (int i = 0; i < Data.Count; i++)
                {
                    DData.Add(Profile);

                    if (i == EdgeUp_Idx[0])
                        Profile = Peak[0];

                    if (i == EdgeDn_Idx[0])
                        Profile = Threshold;

                    if (EdgeUp_Idx.Count > 1)
                    {
                        if (i == EdgeUp_Idx[1])
                            Profile = Peak[1];

                        if (i == EdgeDn_Idx[1])
                            Profile = BHeight[1];
                    }
                }
            }

            public double Width(int PeakNo)//-1=Average, 0..1
            {
                if (EdgeUp_Idx.Count < PeakNo + 1 || EdgeDn_Idx.Count < PeakNo + 1) return 0;// throw new Exception("Invalid Dn Edge.");

                switch (PeakNo)
                {
                    case -1:
                        {
                            double SumDn = 0;
                            double SumUp = 0;
                            for (int i = 0; i < EdgeDn_Idx.Count; i++)
                            {
                                SumDn = SumDn + Dist[EdgeDn_Idx[PeakNo]];
                                SumUp = SumUp + Dist[EdgeUp_Idx[PeakNo]];
                            }
                            return (SumDn - SumUp) / EdgeDn_Idx.Count;
                        }
                    default:
                        return Dist[EdgeDn_Idx[PeakNo]] - Dist[EdgeUp_Idx[PeakNo]];
                }
            }
            public double ID
            {
                get
                {
                    if (EdgeUp_Idx.Count < 2 || EdgeDn_Idx.Count < 2) return 0;// throw new Exception("Invalid Dn Edge.");
                    //if (EdgeUp_Idx.Count < 2) throw new Exception("Invalid Up Edge.");
                    //if (EdgeDn_Idx.Count < 2) throw new Exception("Invalid Dn Edge.");

                    return Dist[EdgeUp_Idx[1]] - Dist[EdgeDn_Idx[0]];

                    //return 0;
                }
            }
            public double OD
            {
                get
                {
                    //if (EdgeUp_Idx.Count < 2) throw new Exception("Invalid Up Edge.");
                    //if (EdgeDn_Idx.Count < 2) throw new Exception("Invalid Dn Edge.");
                    if (EdgeUp_Idx.Count < 2 || EdgeDn_Idx.Count < 2) return 0;// throw new Exception("Invalid Dn Edge.");


                    return Dist[EdgeDn_Idx[1]] - Dist[EdgeUp_Idx[0]];
                }
            }
            public double Height(int PeakNo)
            {
                if (Peak.Count < PeakNo + 1) return 0;// throw new Exception("Peak not found.");

                switch (PeakNo)
                {
                    case -1:
                        {
                            double d = 0;
                            for (int i = 0; i < Peak.Count; i++)
                            {
                                d = d + Peak[i] - BHeight[i];
                            }
                            return d / Peak.Count;
                        }
                    default:
                        return Peak[PeakNo] - BHeight[PeakNo];
                }
            }
        }
        public static bool MeasL_WH(ref WHData WHData, double XS, double YS, double XE, double YE, double MSpeed)
        {
            GDefine.Status = EStatus.Busy;

            //TPos2 GXY = new TPos2(XS + TaskDisp.Laser_Ofst.X, YS + TaskDisp.Laser_Ofst.Y);
            //TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
            //GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_MinDistX;
            //if (!TaskDisp.GotoXYPos(GXY, GX2Y2)) goto _Error;
            if (!TaskDisp.TaskMoveGZUp()) goto _Error;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) goto _Error;
            TPos2 GXY = new TPos2(XS + TaskDisp.Laser_Ofst.X, YS + TaskDisp.Laser_Ofst.Y);
            if (!TaskGantry.SetMotionParamGXY()) goto _Error;
            if (!TaskGantry.MoveAbsGXY(GXY.X, GXY.Y)) goto _Error;

            int t = GDefine.GetTickCount() + 250;
            while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

            TaskGantry.SetMotionParamGXY(TaskGantry.GXAxis.Para.StartV, MSpeed, TaskGantry.GXAxis.Para.Accel);
            if (!TaskGantry.MoveAbsGXY(XE + TaskDisp.Laser_Ofst.X, YE + TaskDisp.Laser_Ofst.Y, false)) goto _Error;

            while (TaskGantry.IsBusyGXY())
            {
                double Dist = 0;
                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();
                Dist = Math.Pow(X - XS, 2) + Math.Pow(Y - YS, 2);
                Dist = Math.Sqrt(Dist);

                double Height = 0;
                try
                {
                    TaskLaser.GetHeight(ref Height, false);
                }
                catch
                {
                    goto _Stop;
                }
                WHData.Add(Dist, Height);
                Thread.Sleep(5);
            }

            GDefine.Status = EStatus.Ready;
            return true;
        _Error:
            GDefine.Status = EStatus.ErrorInit;
            return false;
        _Stop:
            GDefine.Status = EStatus.Stop;
            return false;
        }
    }

    internal class TaskMeasureH
    {
        public enum EMeasPattern
        {
            Point = 0,
            LineInline = 1,
            LinePerpend = 2,
            Cross = 3,
        }
        public enum EMeasJudge
        {
            Median = 0,
            Min = 1,
            Max = 2,
            Ave = 3,
        }
        public class MeasL_H_Data
        {
            public int Col = 0;
            public int Row = 0;

            public double Ref1 = 0;
            public double Ref2 = 0;
            public double Meas = 0;
            public double Height = 0;
        }
        public class MeasL_H_Profile
        {
            public List<double> Ref1 = new List<double>();
            public List<double> Ref2 = new List<double>();
            public List<double> Meas = new List<double>();
        }
        public class MeasL_H_Data_Arr
        {
            public List<int> Col = new List<int>();
            public List<int> Row = new List<int>();

           public List<double> Ref1 = new List<double>();
            public List<double> Ref2 = new List<double>();
            public List<double> Meas = new List<double>();
            public List<double> Height = new List<double>();

            public void Clear()
            {
                this.Col.Clear();
                this.Row.Clear();

                this.Ref1.Clear();
                this.Ref2.Clear();
                this.Meas.Clear();
                this.Height.Clear();
            }
            public void Add(MeasL_H_Data Data)
            {
                this.Col.Add(Data.Col);
                this.Row.Add(Data.Row);

                this.Ref1.Add(Data.Ref1);
                this.Ref2.Add(Data.Ref2);
                this.Meas.Add(Data.Meas);
                this.Height.Add(Data.Height);
            }
            public bool Save()
            {
                string dp = "f4";
                if (Col.Count == 0) return true;

                string Path = GDefine.DataPath + "\\" + "MEASL_H";

                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);


                string Filename = GDefine.DataPath + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_HData.txt";
                try
                {
                    FileStream F = new FileStream(Filename, FileMode.Append, FileAccess.Write, FileShare.Write);
                    StreamWriter W = new StreamWriter(F);

                    W.WriteLine("MEASL_H - Report");
                    W.WriteLine("*****************************");
                    W.WriteLine(DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                    W.WriteLine("*****************************");

                    string S = "Unit" + (char)9 +
                        "Col" + (char)9 +
                        "Row" + (char)9 +
                        "Height" + (char)9 +
                        "Ref1" + (char)9 +
                        "Ref2" + (char)9 +
                        "Meas" + (char)9;
                    W.WriteLine(S);

                    for (int i = 0; i < Col.Count; i++)
                    {
                        S = (i + 1).ToString() + (char)9;
                        S = S + Col[i].ToString() + (char)9;
                        S = S + Row[i].ToString() + (char)9;
                        S = S + Height[i].ToString(dp) + (char)9;
                        S = S + Ref1[i].ToString(dp) + (char)9;
                        S = S + Ref2[i].ToString(dp) + (char)9;
                        S = S + Meas[i].ToString(dp) + (char)9;

                        W.WriteLine(S);
                    }
                    W.WriteLine("*****************************");
                    NSW.Net.Stats Stats = new NSW.Net.Stats();
                    W.WriteLine("StDev" + (char)9 + Stats.StDev(Height).ToString(dp));
                    W.WriteLine("Min" + (char)9 + Height.Min().ToString(dp));
                    W.WriteLine("Max" + (char)9 + Height.Max().ToString(dp));
                    W.WriteLine("Max-Min" + (char)9 + (Height.Max() - Height.Min()).ToString(dp));
                    W.WriteLine("Ave" + (char)9 + Height.Average().ToString(dp));
                    W.WriteLine("*****************************");
                    W.Close();
                }
                catch
                {
                }
                return true;
            }
        }
        public static void LineGetParallelLine(double P1X, double P1Y, double P2X, double P2Y, double Len, ref double P1X1, ref double P1Y1, ref double P1X2, ref double P1Y2)
        {
            NSW.Net.Point2D Ref1XY = new NSW.Net.Point2D(P1X + TaskDisp.Laser_Ofst.X, P1Y + TaskDisp.Laser_Ofst.Y);
            NSW.Net.Point2D Ref2XY = new NSW.Net.Point2D(P2X + TaskDisp.Laser_Ofst.X, P2Y + TaskDisp.Laser_Ofst.Y);

            NSW.Net.Polar Ref1P = new NSW.Net.Polar(Ref1XY, Ref2XY);
            NSW.Net.Polar Ref1P1 = new NSW.Net.Polar(Len / 2, Ref1P.A + Math.PI);
            NSW.Net.Polar Ref1P2 = new NSW.Net.Polar(Len / 2, Ref1P.A);

            NSW.Net.Point2D Ref1P1_XY = new NSW.Net.Point2D(Ref1P1);
            NSW.Net.Point2D Ref1P2_XY = new NSW.Net.Point2D(Ref1P2);

            Ref1P1_XY = Ref1P1_XY.Translate(Ref1XY);
            Ref1P2_XY = Ref1P2_XY.Translate(Ref1XY);

            P1X1 = Ref1P1_XY.X;
            P1Y1 = Ref1P1_XY.Y;
            P1X2 = Ref1P2_XY.X;
            P1Y2 = Ref1P2_XY.Y;
        }
        public static void LineGetPerpendLine(double P1X, double P1Y, double P2X, double P2Y, double Len, ref double P1X1, ref double P1Y1, ref double P1X2, ref double P1Y2)
        {
            NSW.Net.Point2D Ref1XY = new NSW.Net.Point2D(P1X + TaskDisp.Laser_Ofst.X, P1Y + TaskDisp.Laser_Ofst.Y);
            NSW.Net.Point2D Ref2XY = new NSW.Net.Point2D(P2X + TaskDisp.Laser_Ofst.X, P2Y + TaskDisp.Laser_Ofst.Y);

            NSW.Net.Polar Ref1P = new NSW.Net.Polar(Ref1XY, Ref2XY);
            NSW.Net.Polar Ref1P1 = new NSW.Net.Polar(Len / 2, Ref1P.A + (Math.PI / 2));
            NSW.Net.Polar Ref1P2 = new NSW.Net.Polar(Len / 2, Ref1P.A - (Math.PI / 2));

            NSW.Net.Point2D Ref1P1_XY = Ref1P1.Point2D;
            NSW.Net.Point2D Ref1P2_XY = Ref1P2.Point2D;

            Ref1P1_XY = Ref1P1_XY.Translate(Ref1XY);
            Ref1P2_XY = Ref1P2_XY.Translate(Ref1XY);

            P1X1 = Ref1P1_XY.X;
            P1Y1 = Ref1P1_XY.Y;
            P1X2 = Ref1P2_XY.X;
            P1Y2 = Ref1P2_XY.Y;
        }
        public static bool MeasL_H(DispProg.TLine CmdLine, ref MeasL_H_Profile Profile, ref MeasL_H_Data Data, double X1, double Y1, double X2, double Y2)
        {
            GDefine.Status = EStatus.Busy;

            try
            {
                double MSpeed = CmdLine.DPara[0];
                double StartV = CmdLine.DPara[1];
                double DriveV = CmdLine.DPara[2];
                double Accel = CmdLine.DPara[3];

                int SettleTime = CmdLine.IPara[4];
                EMeasPattern Ref1Pattern = (EMeasPattern)CmdLine.IPara[5];
                EMeasJudge Ref1Judge = (EMeasJudge)CmdLine.IPara[6];
                EMeasPattern Ref2Pattern = (EMeasPattern)CmdLine.IPara[10];
                EMeasJudge Ref2Judge = (EMeasJudge)CmdLine.IPara[11];
                EMeasPattern MeasPattern = (EMeasPattern)CmdLine.IPara[15];
                EMeasJudge MeasJudge = (EMeasJudge)CmdLine.IPara[16];
                double SampleRate = CmdLine.DPara[20];

                double RefLineLen = CmdLine.DPara[5];
                double MeasLineLen = CmdLine.DPara[8];

                TaskDisp.TaskGotoGX2Y2DefPos();

                //TaskLaser.Sensor.IFD2451.Meas.SampleRateVal = SampleRate;
                TaskLaser.SampleRate = SampleRate;

                NSW.Net.Stats Stats = new NSW.Net.Stats();

                switch (Ref1Pattern)
                #region
                {
                    default:
                    case EMeasPattern.Point:
                        #region
                        {
                            //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
                            TaskLaser.TrigMode = false;

                            if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                            if (!TaskGantry.MoveAbsGXY(X1 + TaskDisp.Laser_Ofst.X, Y1 + TaskDisp.Laser_Ofst.Y, true)) goto _Error;
                            int t = GDefine.GetTickCount() + SettleTime;
                            while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                            double Value = 0;
                            TaskLaser.GetHeight(ref Value);
                            Profile.Ref1.Add(Value);
                            Data.Ref1 = Value;
                        }
                        #endregion
                        break;
                    case EMeasPattern.LineInline:
                    case EMeasPattern.LinePerpend:
                    case EMeasPattern.Cross:
                        #region
                        {
                            //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.Software;

                            double P1X = X1;
                            double P1Y = Y1;
                            double P2X = X2;
                            double P2Y = Y2;
                            switch (Ref1Pattern)
                            {
                                case EMeasPattern.LineInline:
                                case EMeasPattern.Cross:
                                    #region
                                    LineGetParallelLine(X1, Y1, X2, Y2, RefLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                                    TaskLaser.TrigMode = true;

                                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P1X, P1Y)) goto _Error;
                                    
                                    int t = GDefine.GetTickCount() + SettleTime;
                                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                                    //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                                    if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P2X, P2Y, false)) goto _Error;

                                    //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                                    TaskLaser.SwTrig();

                                    if (!TaskGantry.WaitGXY()) goto _Error;

                                    int DataAvail = 0;
                                    TaskLaser.DataAvail(ref DataAvail);
                                    double[] ScaleData = new double[DataAvail];
                                    int Count = 0;
                                    TaskLaser.TransferData(ScaleData, ref Count);
                                    //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                                    for (int i = 0; i < Count; i++)
                                    {
                                        Profile.Ref1.Add(ScaleData[i]);
                                    }
                                    #endregion
                                    break;
                            }
                            switch (Ref1Pattern)
                            {
                                case EMeasPattern.LinePerpend:
                                case EMeasPattern.Cross:
                                    #region
                                    LineGetPerpendLine(X1, Y1, X2, Y2, RefLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                                    TaskLaser.TrigMode = true;
                                    
                                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P1X, P1Y)) goto _Error;

                                    int t = GDefine.GetTickCount() + SettleTime;
                                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                                    //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                                    if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P2X, P2Y, false)) goto _Error;

                                    //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                                    TaskLaser.SwTrig();

                                    if (!TaskGantry.WaitGXY()) goto _Error;

                                    int DataAvail = 0;
                                    TaskLaser.DataAvail(ref DataAvail);
                                    double[] ScaleData = new double[DataAvail];
                                    int Count = 0;
                                    TaskLaser.TransferData(ScaleData, ref Count);
                                    //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                                    for (int i = 0; i < Count; i++)
                                    {
                                        Profile.Ref1.Add(ScaleData[i]);
                                    }
                                    #endregion
                                    break;
                            }
  
                            switch (Ref1Judge)
                            {
                                #region
                                case EMeasJudge.Min:
                                    Data.Ref1 = Profile.Ref1.Min();
                                    break;
                                case EMeasJudge.Max:
                                    Data.Ref1 = Profile.Ref1.Max();
                                    break;
                                case EMeasJudge.Ave:
                                    Data.Ref1 = Profile.Ref1.Average();
                                    break;
                                default:
                                case EMeasJudge.Median:
                                    Data.Ref1 = Stats.Median(Profile.Ref1);
                                    break;
                                #endregion
                            }
                        }
                        #endregion
                        break;
                }
                #endregion

                double X_Mid = (X1 + X2) / 2;
                double Y_Mid = (Y1 + Y2) / 2;
                switch (MeasPattern)
                #region
                {
                    default:
                    case EMeasPattern.Point:
                        #region
                        {
                            //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
                            TaskLaser.TrigMode = false;

                            if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                            if (!TaskGantry.MoveAbsGXY(X_Mid + TaskDisp.Laser_Ofst.X, Y_Mid + TaskDisp.Laser_Ofst.Y, true)) goto _Error;
                            int t = GDefine.GetTickCount() + SettleTime;
                            while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                            double Value = 0;
                            TaskLaser.GetHeight(ref Value);
                            Profile.Meas.Add(Value);
                            Data.Meas = Value;
                        }
                        #endregion
                        break;
                    case EMeasPattern.LineInline:
                    case EMeasPattern.LinePerpend:
                    case EMeasPattern.Cross:
                        #region
                        {
                            //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.Software;

                            double P1X = X1;
                            double P1Y = Y1;
                            double P2X = X2;
                            double P2Y = Y2;
                            switch (MeasPattern)
                            {
                                case EMeasPattern.LineInline:
                                case EMeasPattern.Cross:
                                    #region
                                    LineGetParallelLine(X_Mid, Y_Mid, X2, Y2, MeasLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                                    TaskLaser.TrigMode = true;

                                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P1X, P1Y)) goto _Error;

                                    int t = GDefine.GetTickCount() + SettleTime;
                                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                                    //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                                    if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P2X, P2Y, false)) goto _Error;
                                    
                                    //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                                    TaskLaser.SwTrig();

                                    if (!TaskGantry.WaitGXY()) goto _Error;

                                    int DataAvail = 0;
                                    TaskLaser.DataAvail(ref DataAvail);
                                    double[] ScaleData = new double[DataAvail];
                                    int Count = 0;
                                    TaskLaser.TransferData(ScaleData, ref Count);
                                    //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                                    for (int i = 0; i < Count; i++)
                                    {
                                        Profile.Meas.Add(ScaleData[i]);
                                    }
                                    #endregion
                                    break;
                            }
                            switch (MeasPattern)
                            {
                                case EMeasPattern.LinePerpend:
                                case EMeasPattern.Cross:
                                    #region
                                    LineGetPerpendLine(X_Mid, Y_Mid, X2, Y2, MeasLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                                    TaskLaser.TrigMode = true;

                                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P1X, P1Y)) goto _Error;

                                    int t = GDefine.GetTickCount() + SettleTime;
                                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                                    //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                                    if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P2X, P2Y, false)) goto _Error;

                                    //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                                    TaskLaser.SwTrig();

                                    if (!TaskGantry.WaitGXY()) goto _Error;

                                    int DataAvail = 0;
                                    TaskLaser.DataAvail(ref DataAvail);
                                    double[] ScaleData = new double[DataAvail];
                                    int Count = 0;
                                    TaskLaser.TransferData(ScaleData, ref Count);
                                    //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                                    for (int i = 0; i < Count; i++)
                                    {
                                        Profile.Meas.Add(ScaleData[i]);
                                    }
                                    #endregion
                                    break;
                            }

                            switch (MeasJudge)
                            {
                                #region
                                case EMeasJudge.Min:
                                    Data.Meas = Profile.Meas.Min();
                                    break;
                                case EMeasJudge.Max:
                                    Data.Meas = Profile.Meas.Max();
                                    break;
                                case EMeasJudge.Ave:
                                    Data.Meas = Profile.Meas.Average();
                                    break;
                                default:
                                case EMeasJudge.Median:
                                    Data.Meas = Stats.Median(Profile.Meas);
                                    break;
                                #endregion
                            }
                        }
                        #endregion
                        break;
                }
                #endregion

                switch (Ref2Pattern)
                #region
                {
                    default:
                    case EMeasPattern.Point:
                        #region
                        {
                            //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
                            TaskLaser.TrigMode = false;

                            if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                            if (!TaskGantry.MoveAbsGXY(X2 + TaskDisp.Laser_Ofst.X, Y2 + TaskDisp.Laser_Ofst.Y, true)) goto _Error;
                            int t = GDefine.GetTickCount() + SettleTime;
                            while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                            double Value = 0;
                            TaskLaser.GetHeight(ref Value);
                            Profile.Ref2.Add(Value);
                            Data.Ref2 = Value;
                        }
                        #endregion
                        break;
                    case EMeasPattern.LineInline:
                    case EMeasPattern.LinePerpend:
                    case EMeasPattern.Cross:
                        #region
                        {
                            //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.Software;

                            double P1X = X1;
                            double P1Y = Y1;
                            double P2X = X2;
                            double P2Y = Y2;
                            switch (Ref2Pattern)
                            {
                                case EMeasPattern.LineInline:
                                case EMeasPattern.Cross:
                                    #region
                                    LineGetParallelLine(X2, Y2, X1, Y1, RefLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                                    TaskLaser.TrigMode = true;

                                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P2X, P2Y)) goto _Error;
                                    
                                    int t = GDefine.GetTickCount() + SettleTime;
                                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                                    //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                                    if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P1X, P1Y, false)) goto _Error;

                                    //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                                    TaskLaser.SwTrig();

                                    if (!TaskGantry.WaitGXY()) goto _Error;

                                    int DataAvail = 0;
                                    TaskLaser.DataAvail(ref DataAvail);
                                    double[] ScaleData = new double[DataAvail];
                                    int Count = 0;
                                    TaskLaser.TransferData(ScaleData, ref Count);
                                    //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                                    for (int i = 0; i < Count; i++)
                                    {
                                        Profile.Ref2.Add(ScaleData[i]);
                                    }
                                    #endregion
                                    break;
                            }
                            switch (Ref2Pattern)
                            {
                                case EMeasPattern.LinePerpend:
                                case EMeasPattern.Cross:
                                    #region
                                    LineGetPerpendLine(X2, Y2, X1, Y1, RefLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                                    TaskLaser.TrigMode = true;

                                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P2X, P2Y)) goto _Error;
                                    int t = GDefine.GetTickCount() + SettleTime;
                                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                                    //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                                    if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                                    if (!TaskGantry.MoveAbsGXY(P1X, P1Y, false)) goto _Error;

                                    //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                                    TaskLaser.SwTrig();

                                    if (!TaskGantry.WaitGXY()) goto _Error;

                                    int DataAvail = 0;
                                    TaskLaser.DataAvail(ref DataAvail);
                                    double[] ScaleData = new double[DataAvail];
                                    int Count = 0;
                                    TaskLaser.TransferData(ScaleData, ref Count);
                                    //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                                    for (int i = 0; i < Count; i++)
                                    {
                                        Profile.Ref2.Add(ScaleData[i]);
                                    }
                                    #endregion
                                    break;
                            }

                            switch (Ref2Judge)
                            {
                                #region
                                case EMeasJudge.Min:
                                    Data.Ref2 = Profile.Ref2.Min();
                                    break;
                                case EMeasJudge.Max:
                                    Data.Ref2 = Profile.Ref2.Max();
                                    break;
                                case EMeasJudge.Ave:
                                    Data.Ref2 = Profile.Ref2.Average();
                                    break;
                                default:
                                case EMeasJudge.Median:
                                    Data.Ref2 = Stats.Median(Profile.Ref2);
                                    break;
                                #endregion
                            }
                        }
                        #endregion
                        break;
                }
                #endregion

                double Ref = (Data.Ref1 + Data.Ref2) / 2;
                Data.Height = Data.Meas - Ref;
            }
            catch (Exception ex)
            {
                string EMsg = "MeasL_H" + (char)13 + ex.Message;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                goto _Stop;
            }

            TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
            GDefine.Status = EStatus.Ready;
            return true;
        _Error:
            TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
            GDefine.Status = EStatus.ErrorInit;
            return false;
        _Stop:
            TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
            GDefine.Status = EStatus.Stop;
            return false;
        }
    }

    internal class TaskHProfile//Height Profile
    {
        public class HProfile
        {
            public List<double> Dist = new List<double>();
            public List<double> Data = new List<double>();
            public List<double> SData = new List<double>();
            public List<double> DData = new List<double>();

            public void Add(double Dist, double Data)
            {
                this.Dist.Add(Dist);
                this.Data.Add(Data);
            }
            public int Count
            {
                get { return this.Data.Count(); }
            }
            public void MinMax(ref double Min, ref double Max)
            {
                if (this.Data.Count > 0)
                {
                    Min = this.Data.Min();
                    Max = this.Data.Max();
                }
            }
            public double Height()
            {
                double Min = 0;
                double Max = 0;
                MinMax(ref Min, ref Max);
                return Max - Min;
            }
            //public void DoMedianLow()
            //{
            //    int SweepSize = 10;
            //    List<double> NewData = new List<double>();
            //    for (int i = SweepSize; i < Data.Count; i++)
            //    {
            //        List<double> SweepSample = new List<double>();
            //        for (int j = 0; j < SweepSize; j++)
            //        {
            //            SweepSample.Add(Data[i - j]);
            //        }
            //        NSW.Net.Stats Stats = new NSW.Net.Stats();
            //        double Median = Stats.Median(SweepSample);

            //        if (i == SweepSize)
            //        {
            //            for (int k = 0; k < SweepSize; k++)
            //            {
            //                NewData.Add(Median);
            //            }
            //        }
            //        else
            //            NewData.Add(Median);
            //    }
            //    Data.Clear();
            //    Data = NewData;
            //}
            public double Width()
            {
                double Min = 0;
                double Max = 0;
                MinMax(ref Min, ref Max);

                double Thld = 0.025;
                int SweepSize = 3;

                double Start = 0;
                double End = 0;
                for (int i = SweepSize; i < Data.Count; i++)
                {
                    //List<double> SweepSample = new List<double>();
                    //for (int j = 0; j < SweepSize; j++)
                    //{
                    //    SweepSample.Add(Data[i - j]);
                    //}
                    //NSW.Net.Stats Stats = new NSW.Net.Stats();
                    //double Median = Stats.Median(SweepSample);

                    if (Start == 0)
                    {
                        //                        if (Data[i] >= Median + Thld)
                        if (Data[i] >= Data[i - 1] + Thld)
                        {
                            Start = Dist[i];
                            break;
                        }
                    }
                }
                for (int i = Data.Count - 2; i > SweepSize; i--)
                {
                    //List<double> SweepSample = new List<double>();
                    //for (int j = 0; j < SweepSize; j++)
                    //{
                    //    SweepSample.Add(Data[i - j]);
                    //}
                    //NSW.Net.Stats Stats = new NSW.Net.Stats();
                    //double Median = Stats.Median(SweepSample);

                    if (End == 0)
                    {
                        //if (Data[i] >= Median + Thld)
                        if (Data[i] >= Data[i + 1] + Thld)
                        {
                            End = Dist[i];
                            break;
                        }
                    }
                }

                return End - Start;
            }
            public void Clear()
            {
                this.Dist.Clear();
                this.Data.Clear();
            }
            public void Save(string FFileName)
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                IniFile.Create(FFileName);

                for (int i = 0; i < Dist.Count(); i++)
                {
                    IniFile.WriteDouble("Dist", i.ToString(), Dist[i]);
                    IniFile.WriteDouble("Data", i.ToString(), Data[i]);
                }
            }
            public void Load(string FFileName)
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                IniFile.Create(FFileName);

                Dist.Clear();
                Data.Clear();
                for (int i = 0; i < 65535; i++)
                {
                    double d_Dist = IniFile.ReadDouble("Dist", i.ToString(), 0);
                    double d_Data = IniFile.ReadDouble("Data", i.ToString(), 0);
                    if (d_Data == 0) break;
                    Dist.Add(d_Dist);
                    Data.Add(d_Data);
                }
            }
            public List<double> Smooth(int factor)
            {
                List<double> SArr = new List<double>();
                List<double> Arr = new List<double>();
                NSW.Net.Stats Stat = new NSW.Net.Stats();
                for (int i = 0; i < Data.Count; i++)
                {
                    if (i < Math.Floor((double)factor / 2) || i >= Data.Count - Math.Floor((double)factor / 2))
                    {
                        SArr.Add(Data[i]);
                        //SArr.Add(Data[i]);
                    }
                    else
                    {
                        Arr.Clear();
                        for (int j = 0; j < factor; j++)
                        {
                            Arr.Add(Data[i - (int)Math.Floor((double)factor / 2) + j]);
                        }
                        //NewData.Dist.Add(Data[i]);
                        //SArr.Add(Stat.Median(Arr));
                        SArr.Add(Stat.Percentile(Arr, 50, NSW.Net.PercentileMethod.Excel));
                    }
                }
                return SArr;
            }


            private double SampleWidth = 0.2;//mm

            private double AveDistPerData = 0;
            private double StartHeight = 0;
            private double EndHeight = 0;
            private double Peak1 = 0;
            private double Peak2 = 0;
            public double Height_Start
            {
                get
                {
                    if (Data.Count == 0) throw new Exception("Invalid Data Count.");
                    //return;
                    List<double> Arr = new List<double>();
                    List<double> SArr = new List<double>();
                    NSW.Net.Stats Stat = new NSW.Net.Stats();

                    //smooth data
                    #region
                    int Sm = 20;
                    for (int i = 0; i < Data.Count; i++)
                    {
                        if (i < Math.Floor((double)Sm / 2) || i >= Data.Count - Math.Floor((double)Sm / 2))
                        {
                            SArr.Add(Data[i]);
                        }
                        else
                        {
                            Arr.Clear();
                            for (int j = 0; j < Sm; j++)
                            {
                                Arr.Add(Data[i - (int)Math.Floor((double)Sm / 2) + j]);
                            }
                            SArr.Add(Stat.Percentile(Arr, 50, NSW.Net.PercentileMethod.Excel));//.Average());
                        }
                    }
                    #endregion

                    SData.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                        SData.Add(SArr[i]);// StartHeight);
                    }

                    for (int i = 0; i < Data.Count; i++)
                    {
                        // Data[i] = SArr[i];
                    }
                    //calc ave dist per data
                    AveDistPerData = (Dist[10] - Dist[0]) / 10;
                    int Samples = (int)(SampleWidth / AveDistPerData);

                    //calc start height
                    Arr.Clear();
                    for (int i = 0; i < Samples; i++)
                    {
                        Arr.Add(SArr[i]);
                    }
                    StartHeight = Stat.Median(Arr);

                    //calc end height
                    Arr.Clear();
                    for (int i = Data.Count - Samples; i < Data.Count; i++)
                    {
                        Arr.Add(SArr[i]);
                    }
                    EndHeight = Stat.Median(Arr);

                    //peak if (y(t) - y(t-dt) > m) && (y(t) - y(t+dt) > m)
                    //where dt and m are parameters to control time-delay and sensitivity
                    double Sensitivity = 0.2; //0.2
                    double DistDelay = 0.5;// 0.5;
                    int dt = (int)(DistDelay / AveDistPerData);

                    //int Peak = 0;
                    List<int> PeakIndex = new List<int>();
                    List<double> Peak = new List<double>();

                    Arr.Clear();
                    //SData.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                        //if (i < Samples)
                        //{
                        //    SData.Add(StartHeight);
                        //}
                        //else
                        //    if (i >= Data.Count - Samples)
                        //    {
                        //        SData.Add(EndHeight);
                        //    }
                        //    else

                        if (i < dt || i >= Data.Count - dt)
                        {
                            //SData.Add(Data.Min());
                        }
                        else
                            if ((SArr[i] - SArr[i - dt] > Sensitivity) && (SArr[i] - SArr[i + dt] > Sensitivity))
                        {
                            PeakIndex.Add(i);
                            Arr.Add(SArr[i]);
                            //SData.Add(Data.Max());
                        }
                        else
                        {
                            if (Arr.Count > 0)
                            {
                                Peak.Add(Stat.Median(Arr));
                                Arr.Clear();
                            }
                            //SData.Add(Data.Min());
                        }
                    }

                    if (Peak.Count < 2) throw new Exception("Peak not found");
                    Peak1 = Peak[0];
                    Peak2 = Peak[1];

                    double H1 = Peak[0] - StartHeight;
                    double H2 = Peak[1] - EndHeight;
                    double H_Ave = (H1 + H2) / 2;



                    int W_Count = 0;
                    List<double> CX = new List<double>();
                    double CrossOver = SArr.Min() + (SArr.Max() - SArr.Min()) * 0.4;

                    double Profile = StartHeight;
                    DData.Clear();

                    for (int i = 0; i < Data.Count; i++)
                    {
                        DData.Add(Profile);
                        if (i == 0 || i == Data.Count - 1) continue;

                        if (SArr[i] < CrossOver && SArr[i + 1] > CrossOver)
                        {
                            CX.Add(Dist[i]);
                            Profile = Peak[W_Count];
                            W_Count++;
                        }

                        if (SArr[i - 1] > CrossOver && SArr[i] < CrossOver)
                        {
                            CX.Add(Dist[i]);
                            //Width.Add(Dist[i] - Dist[Start]);

                            Profile = CrossOver;// Data.Min();
                            if (W_Count == 2) Profile = EndHeight;
                        }

                        DData[i] = Profile;
                    }

                    if (CX.Count < 4) throw new Exception("Edge not found");
                    double Width1 = CX[1] - CX[0];
                    double Width2 = CX[3] - CX[2];
                    double Width_Ave = (Width1 + Width2) / 2;
                    double ID = CX[2] - CX[1];
                    double OD = CX[3] - CX[0];

                    return 0;
                }
            }


            List<int> EdgeUp_Idx = new List<int>();
            List<int> EdgeDn_Idx = new List<int>();
            List<double> BHeight = new List<double>();
            List<double> Peak = new List<double>();
            public void Analyse(int Peaks)
            {
                NSW.Net.Stats Stat = new NSW.Net.Stats();

                List<double> Arr = new List<double>();

                SData = Smooth(10);

                //find edges;
                EdgeUp_Idx.Clear();
                EdgeDn_Idx.Clear();
                BHeight.Clear();
                Peak.Clear();


                double Threshold = SData.Min() + (SData.Max() - SData.Min()) * 0.5;

                for (int i = 0; i < Data.Count; i++)
                {
                    //Edge_up if (y(t) < th && y(t+1) > th)
                    //Edge_dn if (y(t-1) > th && y(t) < th)
                    //where th is CrossOver threshold
                    if (i == 0 || i == Data.Count - 1) continue;

                    if (SData[i] < Threshold && SData[i + 1] > Threshold)
                    {
                        EdgeUp_Idx.Add(i);
                    }

                    if (SData[i - 1] > Threshold && SData[i] < Threshold)
                    {
                        EdgeDn_Idx.Add(i);
                    }
                }

                if (EdgeUp_Idx.Count < Peaks) throw new Exception("Edges not found.");


                //calc ave dist per data
                AveDistPerData = (Dist[10] - Dist[0]) / 10;
                int Samples = (int)(SampleWidth / AveDistPerData);

                BHeight.Clear();
                //calc start height
                Arr.Clear();
                for (int i = 0; i < Samples; i++)
                {
                    Arr.Add(SData[i]);
                }
                BHeight.Add(Stat.Median(Arr));

                //calc end height
                Arr.Clear();
                for (int i = Data.Count - Samples; i < Data.Count; i++)
                {
                    Arr.Add(SData[i]);
                }
                BHeight.Add(Stat.Median(Arr));

                List<int> Peak_Idx = new List<int>();
                for (int i = 0; i < EdgeUp_Idx.Count; i++)
                {
                    Peak_Idx.Add((EdgeUp_Idx[i] + EdgeDn_Idx[i]) / 2);
                }

                for (int p = 0; p < Peak_Idx.Count; p++)
                {
                    Arr.Clear();
                    for (int i = 0; i < Samples; i++)
                    {
                        Arr.Add(SData[i + Peak_Idx[p] - (Samples / 2)]);
                    }
                    Peak.Add(Stat.Median(Arr));
                }

                //if (Peaks > 1)
                //{
                //    Arr.Clear();
                //    for (int i = 0; i < Samples; i++)
                //    {
                //        Arr.Add(SData[i + Peak_Idx[1] - Samples / 2]);
                //    }
                //    Peak.Add(Stat.Median(Arr));
                //}

                if (Peak.Count < Peaks) throw new Exception("Peaks not found.");

                DData.Clear();
                double Profile = BHeight[0];
                for (int i = 0; i < Data.Count; i++)
                {
                    DData.Add(Profile);

                    if (i == EdgeUp_Idx[0])
                        Profile = Peak[0];

                    if (i == EdgeDn_Idx[0])
                        Profile = Threshold;

                    if (EdgeUp_Idx.Count > 1)
                    {
                        if (i == EdgeUp_Idx[1])
                            Profile = Peak[1];

                        if (i == EdgeDn_Idx[1])
                            Profile = BHeight[1];
                    }
                }
            }

            public double Width(int PeakNo)//-1=Average, 0..1
            {
                if (EdgeUp_Idx.Count < PeakNo + 1 || EdgeDn_Idx.Count < PeakNo + 1) return 0;// throw new Exception("Invalid Dn Edge.");

                switch (PeakNo)
                {
                    case -1:
                        {
                            double SumDn = 0;
                            double SumUp = 0;
                            for (int i = 0; i < EdgeDn_Idx.Count; i++)
                            {
                                SumDn = SumDn + Dist[EdgeDn_Idx[PeakNo]];
                                SumUp = SumUp + Dist[EdgeUp_Idx[PeakNo]];
                            }
                            return (SumDn - SumUp) / EdgeDn_Idx.Count;
                        }
                    default:
                        return Dist[EdgeDn_Idx[PeakNo]] - Dist[EdgeUp_Idx[PeakNo]];
                }
            }
            public double ID
            {
                get
                {
                    if (EdgeUp_Idx.Count < 2 || EdgeDn_Idx.Count < 2) return 0;// throw new Exception("Invalid Dn Edge.");
                    //if (EdgeUp_Idx.Count < 2) throw new Exception("Invalid Up Edge.");
                    //if (EdgeDn_Idx.Count < 2) throw new Exception("Invalid Dn Edge.");

                    return Dist[EdgeUp_Idx[1]] - Dist[EdgeDn_Idx[0]];

                    //return 0;
                }
            }
            public double OD
            {
                get
                {
                    //if (EdgeUp_Idx.Count < 2) throw new Exception("Invalid Up Edge.");
                    //if (EdgeDn_Idx.Count < 2) throw new Exception("Invalid Dn Edge.");
                    if (EdgeUp_Idx.Count < 2 || EdgeDn_Idx.Count < 2) return 0;// throw new Exception("Invalid Dn Edge.");


                    return Dist[EdgeDn_Idx[1]] - Dist[EdgeUp_Idx[0]];
                }
            }
            public double Height(int PeakNo)
            {
                if (Peak.Count < PeakNo + 1) return 0;// throw new Exception("Peak not found.");

                switch (PeakNo)
                {
                    case -1:
                        {
                            double d = 0;
                            for (int i = 0; i < Peak.Count; i++)
                            {
                                d = d + Peak[i] - BHeight[i];
                            }
                            return d / Peak.Count;
                        }
                    default:
                        return Peak[PeakNo] - BHeight[PeakNo];
                }
            }
        }
        public static bool MeasL_WH(ref HProfile Profile, double XS, double YS, double XE, double YE, double MSpeed)
        {
            GDefine.Status = EStatus.Busy;

            if (!TaskDisp.TaskMoveGZUp()) goto _Error;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) goto _Error;
            TPos2 GXY = new TPos2(XS + TaskDisp.Laser_Ofst.X, YS + TaskDisp.Laser_Ofst.Y);
            if (!TaskGantry.SetMotionParamGXY()) goto _Error;
            if (!TaskGantry.MoveAbsGXY(GXY.X, GXY.Y)) goto _Error;

            int t = GDefine.GetTickCount() + 250;
            while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

            TaskGantry.SetMotionParamGXY(TaskGantry.GXAxis.Para.StartV, MSpeed, TaskGantry.GXAxis.Para.Accel);
            if (!TaskGantry.MoveAbsGXY(XE + TaskDisp.Laser_Ofst.X, YE + TaskDisp.Laser_Ofst.Y, false)) goto _Error;

            while (TaskGantry.IsBusyGXY())
            {
                double Dist = 0;
                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();
                Dist = Math.Pow(X - XS, 2) + Math.Pow(Y - YS, 2);
                Dist = Math.Sqrt(Dist);

                double Height = 0;
                try
                {
                    TaskLaser.GetHeight(ref Height, false);
                }
                catch
                {
                    goto _Stop;
                }
                Profile.Add(Dist, Height);
                Thread.Sleep(5);
            }

            GDefine.Status = EStatus.Ready;
            return true;
            _Error:
            GDefine.Status = EStatus.ErrorInit;
            return false;
            _Stop:
            GDefine.Status = EStatus.Stop;
            return false;
        }
    }

    internal class TaskMeasMen
    {
        public class Data
        {
            public int Index = 0;

            public int Col = 0;
            public int Row = 0;

            public int CCol = 0;
            public int CRow = 0;

            public double Ref1 = 0;
            public double Ref2 = 0;
            public double Meas = 0;
            public double Height = 0;

            public bool Save(string s_Col1, string s_Col2, string s_Col3)
            {
                string dp = "f4";
                if (Col == 0) return true;

                string Path = GDefine.DataPath + "\\" + "Meas_Meniscus";

                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);

                string Filename = Path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                if (!File.Exists(Filename))
                {
                    FileStream F = new FileStream(Filename, FileMode.Append, FileAccess.Write, FileShare.Write);
                    StreamWriter W = new StreamWriter(F);
                    try
                    {

                        string S = //"Unit" + (char)9 +
                             "DateTime" + (char)9 +
                             "Header1" + (char)9 +
                             "Header2" + (char)9 +
                             "Header3" + (char)9 +
                             "Col" + (char)9 +
                             "Row" + (char)9 +
                             "Height" + (char)9 +
                             "Ref1" + (char)9 +
                             "Ref2" + (char)9 +
                             "Meas" + (char)9;
                        W.WriteLine(S);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        W.Close();
                    }
                }

                try
                {
                    FileStream F = new FileStream(Filename, FileMode.Append, FileAccess.Write, FileShare.Write);
                    StreamWriter W = new StreamWriter(F);

                    string S = "";
                    if (!File.Exists(Filename))
                    {
                        S = "DateTime" + (char)9 +
                            "Header1" + (char)9 +
                            "Header2" + (char)9 +
                            "Header3" + (char)9 +
                            "Col" + (char)9 +
                            "Row" + (char)9 +
                            "Height" + (char)9 +
                            "Ref1" + (char)9 +
                            "Ref2" + (char)9 +
                            "Meas" + (char)9;
                        W.WriteLine(S);
                    }

                    S = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    S = S + s_Col1 + (char)9;
                    S = S + s_Col2 + (char)9;
                    S = S + s_Col3 + (char)9;
                    S = S + Col.ToString() + (char)9;
                    S = S + Row.ToString() + (char)9;
                    S = S + Height.ToString(dp) + (char)9;
                    S = S + Ref1.ToString(dp) + (char)9;
                    S = S + Ref2.ToString(dp) + (char)9;
                    S = S + Meas.ToString(dp) + (char)9;

                    W.WriteLine(S);
                    W.Close();
                }
                catch
                {
                }
                return true;
            }
        }
        public class MeasL_H_Profile
        {
            public List<double> Ref1 = new List<double>();
            public List<double> Ref2 = new List<double>();
            public List<double> Meas = new List<double>();
        }
        public class Datas
        {
            public List<int> Index = new List<int>();

            public List<int> Col = new List<int>();
            public List<int> Row = new List<int>();
            public List<int> CCol = new List<int>();
            public List<int> CRow = new List<int>();

            public List<double> Ref1 = new List<double>();
            public List<double> Ref2 = new List<double>();
            public List<double> Meas = new List<double>();
            public List<double> Height = new List<double>();

            public int Count
            {
                get
                {
                    return Index.Count;
                }
            }

            public void Clear()
            {
                this.Index.Clear();

                this.Col.Clear();
                this.Row.Clear();
                this.CCol.Clear();
                this.CRow.Clear();

                this.Ref1.Clear();
                this.Ref2.Clear();
                this.Meas.Clear();
                this.Height.Clear();
            }
            public void Add(Data Data)
            {
                this.Index.Add(Data.Index);

                this.Col.Add(Data.Col);
                this.Row.Add(Data.Row);
                this.CCol.Add(Data.CCol);
                this.CRow.Add(Data.CRow);

                this.Ref1.Add(Data.Ref1);
                this.Ref2.Add(Data.Ref2);
                this.Meas.Add(Data.Meas);
                this.Height.Add(Data.Height);
            }

            public bool SaveLmds(string tileID)
            {
                string dp = "f4";
                if (Index.Count == 0) return true;


                string path = GDefine.DataPath + "\\" + "Meas_Meniscus" + "\\" + (LotInfo2.Lmds.sMesLot.Length > 0 ? LotInfo2.Lmds.sMesLot : "Orphan");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string filename = path + "\\" + LotInfo2.Lmds.sMesProduct + "_" + LotInfo2.Lmds.sMesLot + "_" + tileID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";


                if (!File.Exists(filename))
                {
                    FileStream F = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Write);
                    StreamWriter W = new StreamWriter(F);
                    try
                    {
                        W.WriteLine("#PRODUCT ID:" + (char)9 + LotInfo2.Lmds.sMesProduct);
                        W.WriteLine("#TILE ID:" + (char)9 + tileID);
                        W.WriteLine("#CAT CODE:" + (char)9 + LotInfo2.Lmds.sCatCode);
                        W.WriteLine("#LOT NO:" + (char)9 + "" + LotInfo2.Lmds.sMesLot);
                        W.WriteLine("#MARKET TARGET:" + (char)9 + LotInfo2.Lmds.sMarketTarget);
                        W.WriteLine("#SAP WO:" + (char)9 + LotInfo2.Lmds.sSapWo);
                        W.WriteLine("#M/C ID:" + (char)9 + LotInfo2.sMachineID);
                        W.WriteLine("#DATE/TIME IN:" + (char)9 + LotInfo2.sStartTime);
                        W.WriteLine("#DATE/TIME OUT:" + (char)9 + DateTime.Now.ToString("dd-MM-yyyy") + " / " + DateTime.Now.ToString("HH:mm ss"));
                        W.WriteLine("#OPERATOR:" + (char)9 + LotInfo2.sOperatorID);
                        W.WriteLine("");

                        string S = "No" + (char)9 +
                            "Col" + (char)9 +
                            "Row" + (char)9 +
                            "CCol" + (char)9 +
                            "CRow" + (char)9 +
                            "Meniscus" + (char)9 +
                            "Ref1" + (char)9 +
                            "Ref2" + (char)9 +
                            "Meas" + (char)9;
                        W.WriteLine(S);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        W.Close();
                    }
                }

                {
                    FileStream F = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Write);
                    StreamWriter W = new StreamWriter(F);
                    try
                    {

                        for (int i = 0; i < Index.Count; i++)
                        {
                            string S = "";
                            S = S + Index[i].ToString() + (char)9;
                            S = S + Col[i].ToString() + (char)9;
                            S = S + Row[i].ToString() + (char)9;
                            S = S + CCol[i].ToString() + (char)9;
                            S = S + CRow[i].ToString() + (char)9;
                            S = S + Height[i].ToString(dp) + (char)9;
                            S = S + Ref1[i].ToString(dp) + (char)9;
                            S = S + Ref2[i].ToString(dp) + (char)9;
                            S = S + Meas[i].ToString(dp) + (char)9;

                            W.WriteLine(S);
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        W.Close();
                    }
                }

                if (TaskDisp.CustomPath.Length > 0)
                {
                    try
                    {
                        string path2 = TaskDisp.CustomPath + "\\" + (LotInfo2.Lmds.sMesLot.Length > 0 ? LotInfo2.Lmds.sMesLot : "Orphan");

                        if (!Directory.Exists(path2))
                            Directory.CreateDirectory(path2);

                        string filename2 = path2 + "\\" + Path.GetFileName(filename);

                        if (File.Exists(filename))
                        {
                            File.Copy(filename, filename2, true);
                        }
                    }
                    catch
                    {
                        Msg MsgBox = new Msg();
                        EMsgRes MsgRes = MsgBox.Show("Copy Meniscus Data to Custom Path failed.");
                    };
                }

                return true;
            }
        }
        public static bool Execute(DispProg.TLine CmdLine, ref MeasL_H_Profile Profile, ref Data Data, double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            GDefine.Status = EStatus.Busy;

            try
            {
                TModelPara Model = new TModelPara(DispProg.ModelList, CmdLine.IPara[0]);

                double MSpeed = CmdLine.DPara[0];
                double StartV = Model.LineStartV;
                double DriveV = Model.LineSpeed;
                double Accel = Model.LineAccel;

                int SettleTime = CmdLine.IPara[4];

                TaskDisp.TaskGotoGX2Y2DefPos();

                NSW.Net.Stats Stats = new NSW.Net.Stats();

                //switch (Ref1Pattern)
                #region
                //{
                //    default:
                //    case EMeasPattern.Point:
                //        #region
                {
                    //            //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
                    TaskLaser.TrigMode = false;

                    if (!TaskGantry.SetMotionParamGXY()) goto _Error;
                    if (!TaskGantry.MoveAbsGXY(X1 + TaskDisp.Laser_Ofst.X, Y1 + TaskDisp.Laser_Ofst.Y, true)) goto _Error;
                    int t = GDefine.GetTickCount() + SettleTime;
                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                    double Value = 0;
                    TaskLaser.GetHeight(ref Value);
                    Profile.Ref1.Add(Value);
                    Data.Ref1 = Value;
                }
                //    #endregion
                //    break;
                //case EMeasPattern.LineInline:
                //case EMeasPattern.LinePerpend:
                //case EMeasPattern.Cross:
                //    #region
                //    {
                //        //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.Software;

                //        double P1X = X1;
                //        double P1Y = Y1;
                //        double P2X = X2;
                //        double P2Y = Y2;
                //        switch (Ref1Pattern)
                //        {
                //            case EMeasPattern.LineInline:
                //            case EMeasPattern.Cross:
                //                #region
                //                LineGetParallelLine(X1, Y1, X2, Y2, RefLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                //                TaskLaser.TrigMode = true;

                //                if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                //                if (!TaskGantry.MoveAbsGXY(P1X, P1Y)) goto _Error;

                //                int t = GDefine.GetTickCount() + SettleTime;
                //                while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                //                //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                //                if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                //                if (!TaskGantry.MoveAbsGXY(P2X, P2Y, false)) goto _Error;

                //                //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                //                TaskLaser.SwTrig();

                //                if (!TaskGantry.WaitGXY()) goto _Error;

                //                int DataAvail = 0;
                //                TaskLaser.DataAvail(ref DataAvail);
                //                double[] ScaleData = new double[DataAvail];
                //                int Count = 0;
                //                TaskLaser.TransferData(ScaleData, ref Count);
                //                //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                //                for (int i = 0; i < Count; i++)
                //                {
                //                    Profile.Ref1.Add(ScaleData[i]);
                //                }
                //                #endregion
                //                break;
                //        }
                //        switch (Ref1Pattern)
                //        {
                //            case EMeasPattern.LinePerpend:
                //            case EMeasPattern.Cross:
                //                #region
                //                LineGetPerpendLine(X1, Y1, X2, Y2, RefLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                //                TaskLaser.TrigMode = true;

                //                if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                //                if (!TaskGantry.MoveAbsGXY(P1X, P1Y)) goto _Error;

                //                int t = GDefine.GetTickCount() + SettleTime;
                //                while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                //                //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                //                if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                //                if (!TaskGantry.MoveAbsGXY(P2X, P2Y, false)) goto _Error;

                //                //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                //                TaskLaser.SwTrig();

                //                if (!TaskGantry.WaitGXY()) goto _Error;

                //                int DataAvail = 0;
                //                TaskLaser.DataAvail(ref DataAvail);
                //                double[] ScaleData = new double[DataAvail];
                //                int Count = 0;
                //                TaskLaser.TransferData(ScaleData, ref Count);
                //                //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                //                for (int i = 0; i < Count; i++)
                //                {
                //                    Profile.Ref1.Add(ScaleData[i]);
                //                }
                //                #endregion
                //                break;
                //        }

                //        switch (Ref1Judge)
                //        {
                //            #region
                //            case EMeasJudge.Min:
                //                Data.Ref1 = Profile.Ref1.Min();
                //                break;
                //            case EMeasJudge.Max:
                //                Data.Ref1 = Profile.Ref1.Max();
                //                break;
                //            case EMeasJudge.Ave:
                //                Data.Ref1 = Profile.Ref1.Average();
                //                break;
                //            default:
                //            case EMeasJudge.Median:
                //                Data.Ref1 = Stats.Median(Profile.Ref1);
                //                break;
                //                #endregion
                //        }
                //    }
                //    #endregion
                //    break;
                //}
                #endregion

                double X_Meas = X3;
                double Y_Meas = Y3;
                //switch (MeasPattern)
                    #region
                    //{
                    //    default:
                    //    case EMeasPattern.Point:
                    #region
                    {
                        //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
                        TaskLaser.TrigMode = false;

                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                    if (!TaskGantry.MoveAbsGXY(X_Meas + TaskDisp.Laser_Ofst.X, Y_Meas + TaskDisp.Laser_Ofst.Y, true)) goto _Error;
                    int t = GDefine.GetTickCount() + SettleTime;
                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                    double Value = 0;
                    TaskLaser.GetHeight(ref Value);
                    Profile.Meas.Add(Value);
                    Data.Meas = Value;
                }
                #endregion
                //        break;
                //    case EMeasPattern.LineInline:
                //    case EMeasPattern.LinePerpend:
                //    case EMeasPattern.Cross:
                //        #region
                //        {
                //            TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.Software;

                //            double P1X = X1;
                //            double P1Y = Y1;
                //            double P2X = X2;
                //            double P2Y = Y2;
                //            switch (MeasPattern)
                //            {
                //                case EMeasPattern.LineInline:
                //                case EMeasPattern.Cross:
                //                    #region
                //                    LineGetParallelLine(X_Mid, Y_Mid, X2, Y2, MeasLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                //                    TaskLaser.TrigMode = true;

                //                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                //                    if (!TaskGantry.MoveAbsGXY(P1X, P1Y)) goto _Error;

                //                    int t = GDefine.GetTickCount() + SettleTime;
                //                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                //                    TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                //                    if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                //                    if (!TaskGantry.MoveAbsGXY(P2X, P2Y, false)) goto _Error;

                //                    TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                //                    TaskLaser.SwTrig();

                //                    if (!TaskGantry.WaitGXY()) goto _Error;

                //                    int DataAvail = 0;
                //                    TaskLaser.DataAvail(ref DataAvail);
                //                    double[] ScaleData = new double[DataAvail];
                //                    int Count = 0;
                //                    TaskLaser.TransferData(ScaleData, ref Count);
                //                    TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                //                    for (int i = 0; i < Count; i++)
                //                    {
                //                        Profile.Meas.Add(ScaleData[i]);
                //                    }
                //                    #endregion
                //                    break;
                //            }
                //            switch (MeasPattern)
                //            {
                //                case EMeasPattern.LinePerpend:
                //                case EMeasPattern.Cross:
                //                    #region
                //                    LineGetPerpendLine(X_Mid, Y_Mid, X2, Y2, MeasLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                //                    TaskLaser.TrigMode = true;

                //                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                //                    if (!TaskGantry.MoveAbsGXY(P1X, P1Y)) goto _Error;

                //                    int t = GDefine.GetTickCount() + SettleTime;
                //                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                //                    TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                //                    if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                //                    if (!TaskGantry.MoveAbsGXY(P2X, P2Y, false)) goto _Error;

                //                    TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                //                    TaskLaser.SwTrig();

                //                    if (!TaskGantry.WaitGXY()) goto _Error;

                //                    int DataAvail = 0;
                //                    TaskLaser.DataAvail(ref DataAvail);
                //                    double[] ScaleData = new double[DataAvail];
                //                    int Count = 0;
                //                    TaskLaser.TransferData(ScaleData, ref Count);
                //                    TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                //                    for (int i = 0; i < Count; i++)
                //                    {
                //                        Profile.Meas.Add(ScaleData[i]);
                //                    }
                //                    #endregion
                //                    break;
                //            }

                //            switch (MeasJudge)
                //            {
                //                #region
                //                case EMeasJudge.Min:
                //                    Data.Meas = Profile.Meas.Min();
                //                    break;
                //                case EMeasJudge.Max:
                //                    Data.Meas = Profile.Meas.Max();
                //                    break;
                //                case EMeasJudge.Ave:
                //                    Data.Meas = Profile.Meas.Average();
                //                    break;
                //                default:
                //                case EMeasJudge.Median:
                //                    Data.Meas = Stats.Median(Profile.Meas);
                //                    break;
                //                    #endregion
                //            }
                //        }
                //        #endregion
                //        break;
                //}
                #endregion

                //switch (Ref2Pattern)
                #region
                //{
                //    default:
                //    case EMeasPattern.Point:
                #region
                {
                    //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
                    TaskLaser.TrigMode = false;

                    if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                    if (!TaskGantry.MoveAbsGXY(X2 + TaskDisp.Laser_Ofst.X, Y2 + TaskDisp.Laser_Ofst.Y, true)) goto _Error;
                    int t = GDefine.GetTickCount() + SettleTime;
                    while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                    double Value = 0;
                    TaskLaser.GetHeight(ref Value);
                    Profile.Ref2.Add(Value);
                    Data.Ref2 = Value;
                }
                #endregion
                //    break;
                //case EMeasPattern.LineInline:
                //case EMeasPattern.LinePerpend:
                //case EMeasPattern.Cross:
                //    #region
                //    {
                //        //TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.Software;

                //        double P1X = X1;
                //        double P1Y = Y1;
                //        double P2X = X2;
                //        double P2Y = Y2;
                //        switch (Ref2Pattern)
                //        {
                //            case EMeasPattern.LineInline:
                //            case EMeasPattern.Cross:
                //                #region
                //                LineGetParallelLine(X2, Y2, X1, Y1, RefLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                //                TaskLaser.TrigMode = true;

                //                if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                //                if (!TaskGantry.MoveAbsGXY(P2X, P2Y)) goto _Error;

                //                int t = GDefine.GetTickCount() + SettleTime;
                //                while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                //                //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                //                if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                //                if (!TaskGantry.MoveAbsGXY(P1X, P1Y, false)) goto _Error;

                //                //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                //                TaskLaser.SwTrig();

                //                if (!TaskGantry.WaitGXY()) goto _Error;

                //                int DataAvail = 0;
                //                TaskLaser.DataAvail(ref DataAvail);
                //                double[] ScaleData = new double[DataAvail];
                //                int Count = 0;
                //                TaskLaser.TransferData(ScaleData, ref Count);
                //                //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                //                for (int i = 0; i < Count; i++)
                //                {
                //                    Profile.Ref2.Add(ScaleData[i]);
                //                }
                //                #endregion
                //                break;
                //        }
                //        switch (Ref2Pattern)
                //        {
                //            case EMeasPattern.LinePerpend:
                //            case EMeasPattern.Cross:
                //                #region
                //                LineGetPerpendLine(X2, Y2, X1, Y1, RefLineLen, ref P1X, ref P1Y, ref P2X, ref P2Y);

                //                TaskLaser.TrigMode = true;

                //                if (!TaskGantry.SetMotionParamGXY(StartV, DriveV, Accel)) goto _Error;
                //                if (!TaskGantry.MoveAbsGXY(P2X, P2Y)) goto _Error;
                //                int t = GDefine.GetTickCount() + SettleTime;
                //                while (GDefine.GetTickCount() <= t) Thread.Sleep(0);

                //                //TaskLaser.Sensor.IFD2451.Trig.Count = -1;

                //                if (!TaskGantry.SetMotionParamGXY(MSpeed, MSpeed, Accel)) goto _Error;
                //                if (!TaskGantry.MoveAbsGXY(P1X, P1Y, false)) goto _Error;

                //                //TaskLaser.Sensor.IFD2451.Trig.SwTrig();
                //                TaskLaser.SwTrig();

                //                if (!TaskGantry.WaitGXY()) goto _Error;

                //                int DataAvail = 0;
                //                TaskLaser.DataAvail(ref DataAvail);
                //                double[] ScaleData = new double[DataAvail];
                //                int Count = 0;
                //                TaskLaser.TransferData(ScaleData, ref Count);
                //                //TaskLaser.Sensor.IFD2451.Trig.StopMeas();

                //                for (int i = 0; i < Count; i++)
                //                {
                //                    Profile.Ref2.Add(ScaleData[i]);
                //                }
                //                #endregion
                //                break;
                //        }

                //        switch (Ref2Judge)
                //        {
                //            #region
                //            case EMeasJudge.Min:
                //                Data.Ref2 = Profile.Ref2.Min();
                //                break;
                //            case EMeasJudge.Max:
                //                Data.Ref2 = Profile.Ref2.Max();
                //                break;
                //            case EMeasJudge.Ave:
                //                Data.Ref2 = Profile.Ref2.Average();
                //                break;
                //            default:
                //            case EMeasJudge.Median:
                //                Data.Ref2 = Stats.Median(Profile.Ref2);
                //                break;
                //                #endregion
                //        }
                //    }
                #endregion
                //        break;
                //#endregion

                double Ref = (Data.Ref1 + Data.Ref2) / 2;
                Data.Height = Data.Meas - Ref;
            }
            catch (Exception ex)
            {
                string EMsg = "MeasL_H" + (char)13 + ex.Message;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR);
                goto _Stop;
            }

            TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
            GDefine.Status = EStatus.Ready;
            return true;
            _Error:
            TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
            GDefine.Status = EStatus.ErrorInit;
            return false;
            _Stop:
            TaskLaser.Sensor.IFD2451.Trig.Mode = CLaser.MEDAQ.E_IFD2451_TrigMode.None;
            GDefine.Status = EStatus.Stop;
            return false;
        }

    }
}
