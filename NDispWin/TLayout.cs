using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.IO;
using System.Threading.Tasks;

namespace NDispWin
{
    class TLayout
    {
        internal enum EULayoutType { Matrix, Random }
        internal enum ECLayoutType { Matrix, MultiP }
        internal enum ELoopDir { XFZ, YFZ, XFU, YFU };

        internal const int MAX_UNITS = 40000;//160000;//8192
        internal const int MAX_RC = 400;
        internal const int MAX_MULTI = 100;

        public int ID = 0;

        public ELoopDir LoopDir = ELoopDir.XFZ;
        public int Zone = 1;

        internal enum EMapOrigin { Left, Right }

        //public int MasterCCol = 0;
        //public int MasterCRow = 0;

        public double StartX = 0;
        public double StartY = 0;

        public bool EnableWafer = false;

        public EULayoutType ULayoutType = EULayoutType.Matrix;
        public int UCount = 0;//unit in cluster count
        public int UColCount = 0;
        public int URowCount = 0;
        public double UColPX = 0;
        public double UColPY = 0;
        public double URowPX = 0;
        public double URowPY = 0;
        public double[] UColX = new double[MAX_UNITS];
        public double[] UColY = new double[MAX_UNITS];
        public double[] URowX = new double[MAX_UNITS];
        public double[] URowY = new double[MAX_UNITS];

        public ECLayoutType CColLayoutType = ECLayoutType.Matrix;
        public ECLayoutType CRowLayoutType = ECLayoutType.Matrix;
        public int CColCount = 0;
        public int CRowCount = 0;
        public double CColPX = 0;
        public double CColPY = 0;
        public double CRowPX = 0;
        public double CRowPY = 0;
        public double[] CColX = new double[MAX_MULTI];
        public double[] CColY = new double[MAX_MULTI];
        public double[] CRowX = new double[MAX_MULTI];
        public double[] CRowY = new double[MAX_MULTI];

        //public double TLI_X = 0;
        //public double TLI_Y = 0;
        //public double TRI_X = 0;
        //public double TRI_Y = 0;
        //public double BLI_X = 0;
        //public double BLI_Y = 0;
        //public double BRI_X = 0;
        //public double BRI_Y = 0;

        public Point TLI = new Point(0, 0);
        public Point TRI = new Point(0, 0);
        public Point BLI = new Point(0, 0);
        public Point BRI = new Point(0, 0);
        public PointF TLPos = new PointF(0, 0);//rel position

        public int TUCount = 0;//total unit in board count
        public int TColCount = 0;//total col in board count
        public int TRowCount = 0;//total row in board count

        public TLayout()
        {
        }
        public TLayout(DispProg.TLine Line)
        {
            ID = Line.ID;

            LoopDir = (ELoopDir)Line.IPara[1];
            Zone = Line.IPara[10];

            StartX = Line.DPara[0];
            StartY = Line.DPara[1];

            EnableWafer = Line.IPara[11] > 0;

            ULayoutType = (EULayoutType)Line.IPara[3];

            UCount = Line.Index[0];

            UColCount = Line.Index[2];
            URowCount = Line.Index[4];
            UColPX = Line.DPara[2];
            UColPY = Line.DPara[3];
            URowPX = Line.DPara[4];
            URowPY = Line.DPara[5];

            CColLayoutType = (ECLayoutType)Line.IPara[6];
            CRowLayoutType = (ECLayoutType)Line.IPara[7];

            CColCount = Line.Index[6];
            CRowCount = Line.Index[8];
            CColPX = Line.DPara[6];
            CColPY = Line.DPara[7];
            CRowPX = Line.DPara[8];
            CRowPY = Line.DPara[9];

            if (ULayoutType == EULayoutType.Matrix)
            {
                UCount = UColCount * URowCount;
            }

            for (int i = 0; i < DispProg.TLine.MAX_PARA; i++)
            {
                UColX[i] = Line.X[i];
                UColY[i] = Line.Y[i];
                URowX[i] = Line.Z[i];
                URowY[i] = Line.U[i];
                CColX[i] = Line.A[i];
                CColY[i] = Line.B[i];
                CRowX[i] = Line.C[i];
                CRowY[i] = Line.D[i];
            }

            TLI.X = Line.IPara[12];
            TLI.Y = Line.IPara[13];
            TRI.X = Line.IPara[14];
            TRI.Y = Line.IPara[15];
            BLI.X = Line.IPara[16];
            BLI.Y = Line.IPara[17];
            BRI.X = Line.IPara[18];
            BRI.Y = Line.IPara[19];
            TLPos.X = (float)Line.DPara[12];
            TLPos.Y = (float)Line.DPara[13];

            TUCount = UCount * CColCount * CRowCount;
            TColCount = UColCount * CColCount;
            TRowCount = URowCount * CRowCount;

            if (TUCount > MAX_UNITS) throw new Exception("Unit Count exceed " + MAX_UNITS.ToString() + ".");
        }
        public void Copy(TLayout Source)
        {
            ID = Source.ID;

            LoopDir = Source.LoopDir;
            Zone = Source.Zone;

            StartX = Source.StartX;
            StartY = Source.StartY;

            EnableWafer = Source.EnableWafer;

            ULayoutType = Source.ULayoutType;

            UCount = Source.UCount;

            UColCount = Source.UColCount;
            URowCount = Source.URowCount;
            UColPX = Source.UColPX;
            UColPY = Source.UColPY;
            URowPX = Source.URowPX;
            URowPY = Source.URowPY;

            CColLayoutType = Source.CColLayoutType;
            CRowLayoutType = Source.CRowLayoutType;

            CColCount = Source.CColCount;
            CRowCount = Source.CRowCount;
            CColPX = Source.CColPX;
            CColPY = Source.CColPY;
            CRowPX = Source.CRowPX;
            CRowPY = Source.CRowPY;

            UCount = Source.UCount;

            for (int i = 0; i < DispProg.TLine.MAX_PARA; i++)
            {
                UColX[i] = Source.UColX[i];
                UColY[i] = Source.UColY[i];
                URowX[i] = Source.URowX[i];
                URowY[i] = Source.URowY[i];
                CColX[i] = Source.CColX[i];
                CColY[i] = Source.CColY[i];
                CRowX[i] = Source.CRowX[i];
                CRowY[i] = Source.CRowY[i];
            }

            TLI = Source.TLI;
            TRI = Source.TRI;
            BLI = Source.BLI;
            BRI = Source.TRI;
            TLPos = Source.TLPos;

            TUCount = Source.TUCount;
            TColCount = Source.TColCount;
            TRowCount = Source.TRowCount;
        }

        public double SizeX
        {
            get
            {
                return (((UColCount * CColCount) + CColCount) - 1) * UColPX;
            }
        }
        public double SizeY
        {
            get
            {
                return (((URowCount * CRowCount) + CRowCount) - 1) * URowPY;
            }
        }

        public EMapOrigin MapOrigin
        {
            get
            {
                if (Convert.ToInt32(UColPX) < 0) return EMapOrigin.Right;
                else
                    return EMapOrigin.Left;
            }
        }
        public void UnitNoGetRC(int Index, ref int ColNo, ref int RowNo)
        {
            if (ULayoutType == EULayoutType.Random) throw new Exception("Unit Layout Random not supported");

            switch (LoopDir)
            {
                case ELoopDir.XFZ:
                default:
                    RowNo = Index / TColCount;
                    ColNo = Index % TColCount;
                    break;
                case ELoopDir.YFZ:
                    ColNo = Index / TRowCount;
                    RowNo = Index % TRowCount;
                    break;
                case ELoopDir.XFU:
                    RowNo = Index / TColCount;
                    ColNo = Index % TColCount;

                    if (RowNo % 2 == 1)
                        ColNo = TColCount - ColNo - 1;
                    break;
                case ELoopDir.YFU:
                    ColNo = Index / TRowCount;
                    RowNo = Index % TRowCount;

                    if (ColNo % 2 == 1)
                        RowNo = TRowCount - RowNo - 1;
                    break;
            }
        }
        public void UnitNoGetRC(int Index, ref int UColNo, ref int URowNo, ref int CColNo, ref int CRowNo)
        {
            if (ULayoutType == EULayoutType.Random) throw new Exception("Unit Layout Random not supported");

            int RowNo = 0;
            int ColNo = 0;

            UnitNoGetRC(Index, ref ColNo, ref RowNo);

            CColNo = ColNo / UColCount;
            UColNo = ColNo % UColCount;

            CRowNo = RowNo / URowCount;
            URowNo = RowNo % URowCount;
        }

        public void RCGetUnitNo(ref int UnitNo, int ColNo, int RowNo)
        {
            if (ULayoutType == EULayoutType.Random) throw new Exception("Unit Layout Random not supported");

            switch (LoopDir)
            {
                case ELoopDir.XFZ:
                default:
                    UnitNo = ColNo + (TColCount * RowNo);
                    break;
                case ELoopDir.YFZ:
                    UnitNo = RowNo + (TRowCount * ColNo);
                    break;
                case ELoopDir.XFU:
                    {
                        int PriorUnitCount = (TColCount * RowNo);

                        if (RowNo % 2 == 0)//odd row
                            UnitNo = PriorUnitCount + ColNo;
                        else//even row
                            UnitNo = PriorUnitCount + (TColCount - ColNo - 1);
                    }
                    break;
                case ELoopDir.YFU:
                    {
                        int PriorUnitCount = (TRowCount * ColNo);

                        if (ColNo % 2 == 0)//odd col
                            UnitNo = PriorUnitCount + RowNo;
                        else//even col
                            UnitNo = PriorUnitCount + (TRowCount - RowNo - 1);
                    }
                    break;
            }
        }

        //public bool _UnitNoGetHead2UnitNo(int Index, ref int Index2, ref bool IsValid)
        //{
        //    int RowNo = 0;
        //    int ColNo = 0;
        //    UnitNoGetRC(Index, ref ColNo, ref RowNo);

        //    Index2 = 0;
        //    int ColNo2 = 0;
        //    int RowNo2 = 0;

        //    int Head2ColOfst = 0;
        //    if (Zone == 2)
        //    {
        //        Head2ColOfst = (int)Math.Ceiling((double)TColCount / 4);
        //        if ((ColNo >= Head2ColOfst && ColNo < Head2ColOfst * 2) || (ColNo >= Head2ColOfst * 3 && ColNo < Head2ColOfst * 4)) return false;
        //    }
        //    else
        //    {
        //        Head2ColOfst = (int)Math.Ceiling((double)TColCount / 2);
        //        if (ColNo >= Head2ColOfst) return false;
        //    }

        //    ColNo2 = ColNo + Head2ColOfst;
        //    RowNo2 = RowNo;
        //    IsValid = ColNo2 < TColCount;

        //    RCGetUnitNo(ref Index2, ColNo2, RowNo2);
            
        //    return true;
        //}
        //public bool UnitNoGetHead2UnitNo(int Index, ref int Index2, ref bool IndexIsHead1, ref bool Index2IsValid)
        //{
        //    int RowNo = 0;
        //    int ColNo = 0;
        //    UnitNoGetRC(Index, ref ColNo, ref RowNo);

        //    Index2 = 0;
        //    int ColNo2 = 0;
        //    int RowNo2 = 0;

        //    int Head2ColOfst = 0;
        //    if (Zone == 2)
        //    {
        //        Head2ColOfst = (int)Math.Ceiling((double)TColCount / 4);
        //        //if ((ColNo >= Head2ColOfst && ColNo < Head2ColOfst * 2) || (ColNo >= Head2ColOfst * 3 && ColNo < Head2ColOfst * 4)) return false;
        //        IndexIsHead1 = ((ColNo < Head2ColOfst) || (ColNo > Head2ColOfst * 2 && ColNo < Head2ColOfst * 3));
        //    }
        //    else
        //    {
        //        Head2ColOfst = (int)Math.Ceiling((double)TColCount / 2);
        //        //if (ColNo >= Head2ColOfst) return false;
        //        IndexIsHead1 = ColNo < Head2ColOfst;//) return false;
        //    }

        //    ColNo2 = ColNo + Head2ColOfst;
        //    RowNo2 = RowNo;
        //    Index2IsValid = ColNo2 < TColCount;

        //    RCGetUnitNo(ref Index2, ColNo2, RowNo2);

        //    if (IndexIsHead1) return false;
        //    //if (!Index2IsValid) return false;
        //    return true;
        //}
        public void UnitNoGetInfo(int UnitNo, ref bool UnitNoIsHead1, ref bool UnitNoIsHead2, ref int UnitNo2, ref bool UnitNo2IsValid)
        {
            UnitNoIsHead1 = false;
            UnitNoIsHead2 = false;
            UnitNo2 = 0;
            UnitNo2IsValid = false;

            int RowNo = 0;
            int ColNo = 0;
            UnitNoGetRC(UnitNo, ref ColNo, ref RowNo);

            int ColNo2 = 0;
            int RowNo2 = 0;

            int Head2ColOfst = 0;
            if (Zone == 2)
            {
                Head2ColOfst = (int)Math.Ceiling((double)TColCount / 4);
                if ((ColNo >= Head2ColOfst && ColNo < Head2ColOfst * 2) || (ColNo >= Head2ColOfst * 3 && ColNo < Head2ColOfst * 4))
                {
                    UnitNoIsHead2 = true;
                    //return false;
                }
                else
                    UnitNoIsHead1 = true;
                //IndexIsHead1 = ((ColNo < Head2ColOfst) || (ColNo > Head2ColOfst * 2 && ColNo < Head2ColOfst * 3));
            }
            else
            {
                Head2ColOfst = (int)Math.Ceiling((double)TColCount / 2);
                if (ColNo >= Head2ColOfst)
                {
                    UnitNoIsHead2 = true;
                }
                else
                    UnitNoIsHead1 = true;
                //IndexIsHead1 = ColNo < Head2ColOfst;//) return false;
            }

            ColNo2 = ColNo + Head2ColOfst;
            RowNo2 = RowNo;
            UnitNo2IsValid = ColNo2 < TColCount;

            RCGetUnitNo(ref UnitNo2, ColNo2, RowNo2);

            //if (IndexIsHead1) return false;
            //if (!Index2IsValid) return false;
            //return true;
        }
        public bool UnitNoGetHead2UnitNo(int Index, ref int Index2, ref bool Index2IsValid)
        {
            bool UnitNoIsHead1 = false;
            bool UnitNoIsHead2 = false;
            //int UnitNo2 = 0;
            //bool UnitNo2IsValid = false;

            //bool IndexIsHead1 = true;
            //UnitNoGetHead2UnitNo(Index, ref Index2, ref IndexIsHead1, ref Index2IsValid);
            UnitNoGetInfo(Index, ref UnitNoIsHead1, ref UnitNoIsHead2, ref Index2, ref Index2IsValid);

            return UnitNoIsHead1 && Index2IsValid;
        }
        //public bool UnitNoGetHead2UnitNo(int Index, ref int Index2)
        //{
        //    bool IndexIsHead1 = true;
        //    bool Index2IsValid = true;
        //    return UnitNoGetHead2UnitNo(Index, ref Index2, ref IndexIsHead1, ref Index2IsValid);
        //}
        public bool UnitNoGetHead2RC(int Index, ref int UColNo, ref int URowNo, ref int CColNo, ref int CRowNo)
        {
           // int Index2 = 0;
           // bool IsValid = true;
           // //bool IsHead1 = UnitNoGetHead2UnitNo(Index, ref Index2, ref IsValid);
           ////UnitNoGetRC(Index2, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);
           // bool IndexIsHead1 = false;
           // UnitNoGetHead2UnitNo(Index, ref Index2, ref IndexIsHead1, ref IsValid);
           // UnitNoGetRC(Index2, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);

           // //return IsHead1;
           // return IndexIsHead1;

            bool UnitNoIsHead1 = false;
            bool UnitNoIsHead2 = false;
            int Index2 = 0;
            bool UnitNo2IsValid = false;

            UnitNoGetInfo(Index, ref UnitNoIsHead1, ref UnitNoIsHead2, ref Index2, ref UnitNo2IsValid);
            UnitNoGetRC(Index2, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);

            return UnitNoIsHead1 && UnitNo2IsValid;
        }

        public bool UnitNoIsHead2(int Index)
        {
            //int Index2 = 0;
            //bool IsValid = true;
            ////bool IsHead1 = UnitNoGetHead2UnitNo(Index, ref Index2, ref IsValid);
            //bool IndexIsHead1 = false;
            //UnitNoGetHead2UnitNo(Index, ref Index2, ref IndexIsHead1, ref IsValid);
            
            ////if (!IsValid) return false;
            ////if (IsHead1) return false;
            //if (IndexIsHead1) return false;
            //return true;
            //return IsValid;
            bool UnitNoIsHead1 = false;
            bool UnitNoIsHead2 = false;
            int Index2 = 0;
            bool UnitNo2IsValid = false;

            UnitNoGetInfo(Index, ref UnitNoIsHead1, ref UnitNoIsHead2, ref Index2, ref UnitNo2IsValid);
            return UnitNoIsHead2;
        }

        public bool UnitNoIsNeedle2(int Index)
        {
            int UColNo = 0;
            int URowNo = 0;
            int CColNo = 0;
            int CRowNo = 0;

            UnitNoGetRC(Index, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);
            return (URowNo + (CRowNo * URowCount) >= Math.Ceiling((double)TRowCount / 2));
        }
        public bool UnitNoGetNeedle2UnitNo(int Index, ref int Needle2Index)
        {
            int ColNo = 0;
            int RowNo = 0;
            UnitNoGetRC(Index, ref ColNo, ref RowNo);

            int Needle2Ofst = TRowCount / 2;

            if (RowNo >= Needle2Ofst) return false;

            int RowNo2 = RowNo + Needle2Ofst;
            RCGetUnitNo(ref Needle2Index, ColNo, RowNo2);
            return true;
        }
        public bool UnitNoGetNeedle1UnitNo(int Index, ref int Needle1Index)
        {
            int ColNo2 = 0;
            int RowNo2 = 0;
            UnitNoGetRC(Index, ref ColNo2, ref RowNo2);

            int Needle2Ofst = TRowCount / 2;

            if (RowNo2 < Needle2Ofst) return false;

            int RowNo = RowNo2 - Needle2Ofst;
            RCGetUnitNo(ref Needle1Index, ColNo2, RowNo);
            return true;
        }

        public void UpdateUnitLocations(int Width, int Height, ref double UPitch, ref double USize, ref int[] X, ref int[] Y)
        {
            UPitch = Math.Min((double)Width / ((UColCount * CColCount) + CColCount), (double)Height / ((URowCount * CRowCount) + CRowCount));
            double UPitchX = UPitch;
            double UPitchY = UPitch;
            double BoardW = ((UColCount * CColCount) + CColCount) * UPitchX;
            double BoardH = ((URowCount * CRowCount) + CRowCount) * UPitchY;

            double SX = (Width / 2) - (BoardW / 2) + UPitchX;//default UColPX >= 0
            if (this.UColPX < 0)
            {
                //double SX = Width - ((Width / 2) - (BoardW / 2) + UPitch);
                //double SX = Width - (Width / 2) + (BoardW / 2) - UPitch;
                SX = (Width / 2) + (BoardW / 2) - UPitchX;
                UPitchX = -UPitchX;
            }

            double SY = (Height / 2) - (BoardH / 2) + UPitchY;//default UColPY <= 0
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
            {
                if (this.URowPY < 0)
                {
                    SY = (Height / 2) + (BoardH / 2) - UPitchY;
                    UPitchY = -UPitchY;
                }
            }
            else
            {
                if (this.URowPY > 0)
                {
                    SY = (Height / 2) + (BoardH / 2) - UPitchY;
                    UPitchY = -UPitchY;
                }
            }
            //if (this.URowPY > 0)
            //{
            //    UPitchY = -UPitchY;
            //}
            //double SY = (Height / 2) - (BoardH / 2) + UPitchY;//default UColPY <= 0

            double CColPitch = (UColCount + 1) * UPitchX;
            double CRowPitch = (URowCount + 1) * UPitchY;
            USize = UPitch * 0.8;

            for (int i = 0; i < TUCount; i++)
            {
                int UColNo = 0;
                int URowNo = 0;
                int CColNo = 0;
                int CRowNo = 0;
                UnitNoGetRC(i, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);

                X[i] = (int)(SX + (CColNo * CColPitch) + (UColNo * UPitchX));
                Y[i] = (int)(SY + (CRowNo * CRowPitch) + (URowNo * UPitchY));
            }
        }

        //public bool UnitNoIsSettable(int UnitNo)
        //{
        //    int UColNo = 0;
        //    int URowNo = 0;
        //    int CColNo = 0;
        //    int CRowNo = 0;
        //    UnitNoGetRC(UnitNo, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);

        //    //Master Cluster
        //    if (CColNo == MasterCCol && CRowNo == MasterCRow)
        //    {
        //        if (UColNo == 0 && URowNo == 0) return true;
        //        if (UColNo == 0 && URowNo == URowCount - 1) return true;
        //        if (URowNo == 0 && UColNo == UColCount - 1) return true;
        //    }
        //    switch (CColLayoutType)
        //    {
        //        case ECLayoutType.Matrix:
        //            if (CRowNo == MasterCRow && CColNo == CColCount - 1&& UColNo == 0 && URowNo == 0) return true;
        //            break;
        //        case ECLayoutType.MultiP:
        //            if (CRowNo == MasterCRow && UColNo == 0 && URowNo == 0) return true;
        //            break;
        //    }
        //    switch (CRowLayoutType)
        //    {
        //        case ECLayoutType.Matrix:
        //            if (CColNo == MasterCCol && CRowNo == CRowCount - 1 && UColNo == 0 && URowNo == 0) return true;
        //            break;
        //        case ECLayoutType.MultiP:
        //            if (CColNo == MasterCCol && UColNo == 0 && URowNo == 0) return true;
        //            break;
        //    } 

        //    return false;
        //}

        public void ComputePos(ref TPos2[] Pos)
        {
            if (!EnableWafer)
            {
                for (int i = 0; i < TUCount; i++)
                {
                    double urx = 0;//unit relative x
                    double ury = 0;//unit relative y
                    int CColNo = 0;
                    int CRowNo = 0;
                    int UColNo = 0;
                    int URowNo = 0;

                    UnitNoGetRC(i, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);

                    urx = UColPX * UColNo + URowPX * URowNo;
                    ury = UColPY * UColNo + URowPY * URowNo;

                    double crx = 0;//clstr relative x
                    double cry = 0;//clstr relative y
                    switch (CColLayoutType)
                    {
                        case ECLayoutType.Matrix:
                        default:
                            crx = crx + CColPX * CColNo;
                            cry = cry + CColPY * CColNo;
                            break;
                        case ECLayoutType.MultiP:
                            crx = crx + CColX[CColNo];
                            cry = cry + CColY[CColNo];
                            break;
                    }
                    switch (CRowLayoutType)
                    {
                        case ECLayoutType.Matrix:
                        default:
                            crx = crx + CRowPX * CRowNo;
                            cry = cry + CRowPY * CRowNo;
                            break;
                        case ECLayoutType.MultiP:
                            crx = crx + CRowX[CRowNo];
                            cry = cry + CRowY[CRowNo];
                            break;
                    }

                    Pos[i].X = urx + crx;
                    Pos[i].Y = ury + cry;
                }
            }
            else//  Wafer uses UColPX,PY and URowPX,PY only
            {
                for (int i = 0; i < TUCount; i++)
                {
                    double urx = 0;//unit relative x
                    double ury = 0;//unit relative y
                    int ColNo = 0;
                    int RowNo = 0;

                    UnitNoGetRC(i, ref ColNo, ref RowNo);

                    urx = UColPX * (ColNo - TLI.X) + URowPX * (RowNo - TLI.Y);
                    ury = UColPY * (ColNo - TLI.X) + URowPY * (RowNo - TLI.Y);

                    Pos[i].X = urx;
                    Pos[i].Y = ury;
                }
            }
        }

        public double HeadPitch
        {
            get
            {
                double Pitch = 0;

                int UColNo = 0;
                int URowNo = 0;
                int CColNo = 0;
                int CRowNo = 0;
                try
                {
                    UnitNoGetHead2RC(0, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);
                }
                catch { };
                if (CColLayoutType == ECLayoutType.Matrix)
                {
                    Pitch = (CColNo * CColPX) + (UColNo * UColPX);
                }
                if (CColLayoutType == ECLayoutType.MultiP)
                {
                    Pitch = (CColX[CColNo]) + (UColNo * UColPX);
                }
                return Pitch;// Math.Abs(Pitch);
            }
        }
        public double NeedlePitch
        {
            get
            {
                double Pitch = 0;

                int Needle2UnitNo = 0;
                try
                {
                    UnitNoGetNeedle2UnitNo(0, ref Needle2UnitNo);
                }
                catch { };

                int UColNo = 0;
                int URowNo = 0;
                int CColNo = 0;
                int CRowNo = 0;
                try
                {
                    UnitNoGetRC(Needle2UnitNo, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);
                }
                catch { };

                if (CColLayoutType == ECLayoutType.Matrix)
                {
                    Pitch = (CRowNo * CRowPY) + (URowNo * URowPY);
                }
                if (CColLayoutType == ECLayoutType.MultiP)
                {
                    Pitch = (CRowY[CRowNo]) + (URowNo * URowPY);
                }
                Pitch = Math.Abs(Pitch);
                return -Pitch;
            }
        }

        public void MaskMap()
        {

        }

        public bool LastInCluster(int Index1)
        {
            int UColNo = 0; int URowNo = 0; int CColNo = 0; int CRowNo = 0;
            this.UnitNoGetRC(Index1, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);
            int NextUColNo = 0; int NextURowNo = 0; int NextCColNo = 0; int NextCRowNo = 0;
            this.UnitNoGetRC(Index1 + 1, ref NextUColNo, ref NextURowNo, ref NextCColNo, ref NextCRowNo);
            return (NextCColNo != CColNo || NextCRowNo != CRowNo);
        }
    }

    class TWLayout
    {
        int ID = 0;

        double WaferSize = 200;//Wafer Diamenter, mm
        PointF DieSize = new PointF(1,1);//Die Size, mm
        PointF Die00Offset = new PointF(0, 0);//First Die Offset from Center Line, mm

        const int MAX_INCL_RECT = 50;
        Rectangle[] IncludedRect = new Rectangle[50];

        //const int MAX_REF = 10;
        //Point[] RefIndice = new Point[MAX_REF];
    }

    public class intVal
    {
        public string Name = "";
        int iValue = 0;
        int iAdjMin = int.MinValue;
        int iAdjMax = int.MaxValue;
        public int AbsMin = int.MinValue;
        public int AbsMax = int.MaxValue;

        public intVal(string Name)
        {
            this.Name = Name;
            this.iValue = 0;
        }
        public intVal(string Name, int Value)
        {
            this.Name = Name;
            this.iValue = Value;
        }
        public intVal(string Name, int Value, int AbsMin, int AbsMax)
        {
            this.Name = Name;
            this.iValue = Value;
            this.iAdjMin = AbsMin;
            this.iAdjMax = AbsMax;
            this.AbsMin = AbsMin;
            this.AbsMax = AbsMax;
        }
        public int Value
        {
            get { return this.iValue; }
            set { this.iValue = value; }
        }
    }
    public class doubleVal
    {
        public string Name = "";
        double iValue = 0;
        double iAdjMin = double.MinValue;
        double iAdjMax = double.MaxValue;
        double iAbsMin = double.MinValue;
        double iAbsMax = double.MaxValue;

        public doubleVal(string Name)
        {
            this.Name = Name;
            this.iValue = 0;
        }
        public doubleVal(string Name, double Value)
        {
            this.Name = Name;
            this.iValue = Value;
        }
        public doubleVal(string Name, double Value, double AbsMin, double AbsMax)
        {
            this.Name = Name;
            this.iValue = Value;
            this.iAdjMin = AbsMin;
            this.iAdjMax = AbsMax;
            this.iAbsMin = AbsMin;
            this.iAbsMax = AbsMax;
        }
        public double Value
        {
            get { return this.iValue; }
            set { this.iValue = value; }
        }
        public double AbsMin
        {
            get { return this.iAbsMin; }
        }
        public double AbsMax
        {
            get { return this.iAbsMax; }
        }
    }

    class TLayoutMatrix
    {
        internal enum ELoopDir { XFZ, YFZ, XFU, YFU };

        internal const int MAX_RC = 256;
        internal const int MAX_UNITS = MAX_RC * MAX_RC;
        internal const int MAX_VRC = 128;
        internal const int MAX_WRC = 32;

        public int ID = 0;
        public ELoopDir LoopDir = ELoopDir.XFZ;

        public doubleVal StartPosX = new doubleVal("LayoutMatrix_StartPosX", 0, -999, 999);
        public doubleVal StartPosY = new doubleVal("LayoutMatrix_StartPosY", 0, -999, 999);

        public intVal UColCount = new intVal("LayoutMatrix_UColCount", 1, 1, MAX_RC);
        public intVal URowCount = new intVal("LayoutMatrix_URowCount", 1, 1, MAX_RC);
        public int UCount
        {
            get
            {
                return UColCount.Value * URowCount.Value;
            }
        }
        public doubleVal UColPX = new doubleVal("LayoutMatrix_UColPX", 0, -100, 100);
        public doubleVal UColPY = new doubleVal("LayoutMatrix_UColPY", 0, -10, 10);
        public doubleVal URowPX = new doubleVal("LayoutMatrix_URowPX", 0, -10, 10);
        public doubleVal URowPY = new doubleVal("LayoutMatrix_URowPY", 0, -100, 100);

        public intVal VColCount = new intVal("LayoutMatrix_VColCount", 1, 1, MAX_VRC);
        public intVal VRowCount = new intVal("LayoutMatrix_VRowCount", 1, 1, MAX_VRC);
        public int VCount
        {
            get
            {
                return VColCount.Value * VRowCount.Value;
            }
        }
        public doubleVal VColPX = new doubleVal("LayoutMatrix_VColPX", 0, -999, 999);
        public doubleVal VColPY = new doubleVal("LayoutMatrix_VColPY", 0, -10, 10);
        public doubleVal VRowPX = new doubleVal("LayoutMatrix_VRowPX", 0, -10, 10);
        public doubleVal VRowPY = new doubleVal("LayoutMatrix_VRowPY", 0, -999, 999);

        public intVal WColCount = new intVal("LayoutMatrix_WColCount", 1, 1, MAX_WRC);
        public intVal WRowCount = new intVal("LayoutMatrix_WRowCount", 1, 1, MAX_WRC);
        public int WCount
        {
            get
            {
                return WColCount.Value * WRowCount.Value;
            }
        }
        public doubleVal WColPX = new doubleVal("LayoutMatrix_WColPX", 0, -999, 999);
        public doubleVal WColPY = new doubleVal("LayoutMatrix_WColPY", 0, -10, 10);
        public doubleVal WRowPX = new doubleVal("LayoutMatrix_WRowPX", 0, -10, 10);
        public doubleVal WRowPY = new doubleVal("LayoutMatrix_WRowPY", 0, -999, 999);

        public int TColCount
        {
            get
            {
                return UColCount.Value * VColCount.Value * WColCount.Value;
            }
        }
        public int TRowCount
        {
            get
            {
                return URowCount.Value * VRowCount.Value * WRowCount.Value;
            }
        }
        public int TCount
        {
            get
            {
                return TColCount * TRowCount;
            }
        }

        public TLayoutMatrix()
        {
        }

        public void Save(string FullFilename)
        {
            if (Path.GetExtension(FullFilename).Length == 0) FullFilename = FullFilename + ".ini";

            List<string> Lines = new List<string>();

            string Line = "";
            Line = "Start," + StartPosX.Value.ToString("f4") + "," + StartPosY.Value.ToString("f4") + (char)9;
            Lines.Add(Line);
            Line = "UData," + UColCount.Value.ToString() + "," + URowCount.Value.ToString() + ", " + UColPX.Value.ToString() + "," + UColPY.Value.ToString() + ", " + URowPX.Value.ToString() + "," + URowPY.Value.ToString() + (char)9;
            Lines.Add(Line);
            Line = "VData," + VColCount.Value.ToString() + "," + VRowCount.Value.ToString() + ", " + VColPX.Value.ToString() + "," + VColPY.Value.ToString() + ", " + VRowPX.Value.ToString() + "," + VRowPY.Value.ToString() + (char)9;
            Lines.Add(Line);
            Line = "WData," + WColCount.Value.ToString() + "," + WRowCount.Value.ToString() + ", " + WColPX.Value.ToString() + "," + WColPY.Value.ToString() + ", " + WRowPX.Value.ToString() + "," + WRowPY.Value.ToString() + (char)9;
            Lines.Add(Line);

            System.IO.File.WriteAllLines(FullFilename, Lines);
        }
        public void Load(string FullFilename)
        {
            StartPosX.Value = 0;
            StartPosY.Value = 0;

            UColCount.Value = 1;
            URowCount.Value = 1;
            UColPX.Value = 0;
            UColPY.Value = 0;
            URowPX.Value = 0;
            URowPY.Value = 0;

            VColCount.Value = 1;
            VRowCount.Value = 1;
            VColPX.Value = 0;
            VColPY.Value = 0;
            VRowPX.Value = 0;
            VRowPY.Value = 0;

            WColCount.Value = 1;
            WRowCount.Value = 1;
            WColPX.Value = 0;
            WColPY.Value = 0;
            WRowPX.Value = 0;
            WRowPY.Value = 0;

            if (!File.Exists(FullFilename)) return;

            string[] Lines = System.IO.File.ReadAllLines(FullFilename);
            Parallel.For(0, Lines.Length, x =>
            {
                string[] Line = Lines[x].Split((char)9);

                for (int i = 0; i < Line.Count(); i++)
                {
                    if (Line[i].StartsWith("Start"))
                    {
                        string[] line = Line[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            StartPosX.Value = Convert.ToDouble(line[1]);
                            StartPosY.Value = Convert.ToDouble(line[2]);
                        }
                        catch { }
                    }
                    if (Line[i].StartsWith("UData"))
                    {
                        string[] line = Line[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            UColCount.Value = Convert.ToInt32(line[1]);
                            URowCount.Value = Convert.ToInt32(line[2]);
                            UColPX.Value = Convert.ToDouble(line[3]);
                            UColPY.Value = Convert.ToDouble(line[4]);
                            URowPX.Value = Convert.ToDouble(line[5]);
                            URowPY.Value = Convert.ToDouble(line[6]);
                        }
                        catch { }
                    }
                    if (Line[i].StartsWith("VData"))
                    {
                        string[] line = Line[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            VColCount.Value = Convert.ToInt32(line[1]);
                            VRowCount.Value = Convert.ToInt32(line[2]);
                            VColPX.Value = Convert.ToDouble(line[3]);
                            VColPY.Value = Convert.ToDouble(line[4]);
                            VRowPX.Value = Convert.ToDouble(line[5]);
                            VRowPY.Value = Convert.ToDouble(line[6]);
                        }
                        catch { }
                    }
                    if (Line[i].StartsWith("WData"))
                    {
                        string[] line = Line[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            WColCount.Value = Convert.ToInt32(line[1]);
                            WRowCount.Value = Convert.ToInt32(line[2]);
                            WColPX.Value = Convert.ToDouble(line[3]);
                            WColPY.Value = Convert.ToDouble(line[4]);
                            WRowPX.Value = Convert.ToDouble(line[5]);
                            WRowPY.Value = Convert.ToDouble(line[6]);
                        }
                        catch { }
                    }
                }
            });
        }

        public double Rel_X(int C, int R)
        {
            int UC = C % UColCount.Value;//0 based unit col
            int UR = R % URowCount.Value;//0 based unit row
            int VC = (C / UColCount.Value) % VColCount.Value;//0 based L1 Col
            int VR = (R / URowCount.Value) % VRowCount.Value;//0 based L1 Row
            int WC = (C / (UColCount.Value * VColCount.Value)) % WColCount.Value;//0 based L2 Col
            int WR = (R / (URowCount.Value * VRowCount.Value)) % WRowCount.Value;//0 based L2 Row

            return (UC * UColPX.Value + UR * URowPX.Value) + (VC * VColPX.Value + VR * VRowPX.Value) + (WC * WColPX.Value + WR * WRowPX.Value);
        }
        public double Rel_Y(int C, int R)
        {
            int UC = C % UColCount.Value;//0 based unit col
            int UR = R % URowCount.Value;//0 based unit row
            int VC = (C / UColCount.Value) % VColCount.Value;//0 based L1 Col
            int VR = (R / URowCount.Value) % VRowCount.Value;//0 based L1 Row
            int WC = (C / (UColCount.Value * VColCount.Value)) % WColCount.Value;//0 based L2 Col
            int WR = (R / (URowCount.Value * VRowCount.Value)) % WRowCount.Value;//0 based L2 Row

            return (UC * UColPY.Value + UR * URowPY.Value) + (VC * VColPY.Value + VR * VRowPY.Value) + (WC * WColPY.Value + WR * WRowPY.Value);
        }
    }

    public struct PointD
    {
        bool b_isEmpty;
        double x;
        double y;
        public PointD(double X, double Y)
        {
            this.b_isEmpty = false;
            this.x = X;
            this.y = Y;
        }
        public bool IsEmpty
        {
            get
            {
                return b_isEmpty;
            }
        }
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        //public static PointD operator +(PointD PointD)
        //{
        //    this.x += PointD.X;
        //    this.y += PointD.Y;
        //    return new PointD(x, y);
        //}

        public static PointD operator +(PointD Left, PointD Right)
        {
            Left.X += Right.X;
            Left.Y += Right.Y;
            return Left;
        }
        public static PointD operator -(PointD Left, PointD Right)
        {
            Left.X -= Right.X;
            Left.Y -= Right.Y;
            return Left;
        }
        public PointD Add(PointD PointD)
        {
            this.X += PointD.X;
            this.y += PointD.y;
            return this;
        }
        public PointD Subtract(PointD PointD)
        {
            this.X -= PointD.X;
            this.y -= PointD.y;
            return this;
        }
        public PointD Invert()
        {
            this.X = -this.X;
            this.y = -this.y;
            return this;
        }
    }

    //public class TPnPLayout
    //{
    //    internal enum ELoopDir { XFZ, YFZ, XFU, YFU };

    //    internal const int MAX_RC = 256;
    //    internal const int MAX_UNITS = MAX_RC * MAX_RC;
    //    internal const int MAX_VRC = 128;
    //    internal const int MAX_WRC = 32;

    //    public int ID = 0;
    //    //public ELoopDir LoopDir = ELoopDir.XFZ;

    //    public double StartPosX = 0;
    //    public double StartPosY = 0;

    //    public int UColCount = 1;
    //    public int URowCount = 1;
    //    public int UCount
    //    {
    //        get
    //        {
    //            return UColCount * URowCount;
    //        }
    //    }
    //    public double UColPX = 0;
    //    public double UColPY = 0;
    //    public double URowPX = 0;
    //    public double URowPY = 0;

    //    public int TColCount
    //    {
    //        get
    //        {
    //            return UColCount;//.Value * VColCount.Value * WColCount.Value;
    //        }
    //    }
    //    public int TRowCount
    //    {
    //        get
    //        {
    //            return URowCount;//.Value * VRowCount.Value * WRowCount.Value;
    //        }
    //    }
    //    public int TCount
    //    {
    //        get
    //        {
    //            return TColCount * TRowCount;
    //        }
    //    }

    //    public TPnPLayout()
    //    {
    //        this.StartPosX = 0;
    //        this.StartPosY = 0;

    //        this.UColCount = 1;
    //        this.URowCount = 1;
    //        this.UColPX = 0;
    //        this.UColPY = 0;
    //        this.URowPX = 0;
    //        this.URowPY = 0;
    //    }

    //    public TPnPLayout(TPnPLayout Layout)
    //    {
    //        this.StartPosX = Layout.StartPosX;
    //        this.StartPosY = Layout.StartPosY;

    //        this.UColCount = Layout.UColCount;
    //        this.URowCount = Layout.URowCount;
    //        this.UColPX = Layout.UColPX;
    //        this.UColPY = Layout.UColPY;
    //        this.URowPX = Layout.URowPX;
    //        this.URowPY = Layout.URowPY;
    //    }

    //    public void Copy(TPnPLayout Layout)
    //    {
    //        this.StartPosX = Layout.StartPosX;
    //        this.StartPosY = Layout.StartPosY;

    //        this.UColCount = Layout.UColCount;
    //        this.URowCount = Layout.URowCount;
    //        this.UColPX = Layout.UColPX;
    //        this.UColPY = Layout.UColPY;
    //        this.URowPX = Layout.URowPX;
    //        this.URowPY = Layout.URowPY;
    //    }

    //    public void Save(string FullFilename, string SectionName)
    //    {
    //        if (Path.GetExtension(FullFilename).Length == 0) FullFilename = FullFilename + ".ini";

    //        NUtils.IniFile Inifile = new NUtils.IniFile(FullFilename);

    //        string s_Line = "";
    //        s_Line = StartPosX.ToString("f4") + "," + StartPosY.ToString("f4");
    //        Inifile.WriteString(SectionName, "StartXY", s_Line);

    //        s_Line = UColCount.ToString("f4") + "," + URowCount.ToString("f4") + "," + UColPX.ToString("f4") + "," + UColPY.ToString("f4") + "," + URowPX.ToString("f4") + "," + URowPY.ToString("f4");
    //        Inifile.WriteString(SectionName, "UCount_CR_ColPXY_RowPXY", s_Line);
    //    }
    //    public void Load(string FullFilename, string SectionName)
    //    {
    //        StartPosX = 0;
    //        StartPosY = 0;

    //        UColCount = 1;
    //        URowCount = 1;
    //        UColPX = 0;
    //        UColPY = 0;
    //        URowPX = 0;
    //        URowPY = 0;

    //        if (Path.GetExtension(FullFilename).Length == 0) FullFilename = FullFilename + ".ini";

    //        NUtils.IniFile Inifile = new NUtils.IniFile(FullFilename);

    //        string s_Line = "";

    //        s_Line = Inifile.ReadString(SectionName, "StartXY", "0,0");
    //        string[] line = s_Line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    //        try
    //        {
    //            StartPosX = Convert.ToDouble(line[0]);
    //            StartPosY = Convert.ToDouble(line[1]);
    //        }
    //        catch { }

    //        s_Line = Inifile.ReadString(SectionName, "UCount_CR_ColPXY_RowPXY", "1,1,0,0,0,0");
    //        line = s_Line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    //        try
    //        {
    //            UColCount = Convert.ToInt32(line[0]);
    //            URowCount = Convert.ToInt32(line[1]);
    //            UColPX = Convert.ToInt32(line[2]);
    //            UColPY = Convert.ToInt32(line[3]);
    //            URowPX = Convert.ToInt32(line[4]);
    //            URowPY = Convert.ToInt32(line[5]);
    //        }
    //        catch { }
    //    }

    //    public double Rel_X(int C, int R)
    //    {
    //        int UC = C % UColCount;//.Value;//0 based unit col
    //        int UR = R % URowCount;//.Value;//0 based unit row
    //        //int VC = (C / UColCount.Value) % VColCount.Value;//0 based L1 Col
    //        //int VR = (R / URowCount.Value) % VRowCount.Value;//0 based L1 Row
    //        //int WC = (C / (UColCount.Value * VColCount.Value)) % WColCount.Value;//0 based L2 Col
    //        //int WR = (R / (URowCount.Value * VRowCount.Value)) % WRowCount.Value;//0 based L2 Row

    //        return (UC * UColPX + UR * URowPX);// + (VC * VColPX.Value + VR * VRowPX.Value) + (WC * WColPX.Value + WR * WRowPX.Value);
    //    }
    //    public double Rel_Y(int C, int R)
    //    {
    //        int UC = C % UColCount;//.Value;//0 based unit col
    //        int UR = R % URowCount;//.Value;//0 based unit row
    //        //int VC = (C / UColCount.Value) % VColCount.Value;//0 based L1 Col
    //        //int VR = (R / URowCount.Value) % VRowCount.Value;//0 based L1 Row
    //        //int WC = (C / (UColCount.Value * VColCount.Value)) % WColCount.Value;//0 based L2 Col
    //        //int WR = (R / (URowCount.Value * VRowCount.Value)) % WRowCount.Value;//0 based L2 Row

    //        return (UC * UColPY + UR * URowPY);// + (VC * VColPY.Value + VR * VRowPY.Value) + (WC * WColPY.Value + WR * WRowPY.Value);
    //    }

    //    public double Rel_X(Point Index)
    //    {
    //        return Rel_X(Index.X, Index.Y);
    //    }
    //    public double Rel_Y(Point Index)
    //    {
    //        return Rel_Y(Index.X, Index.Y);
    //    }


    //    public Point CurrentIdx = new Point(0, 0);
    //    public bool Empty = true;
    //    public void IndexReset()
    //    {
    //        Empty = false;
    //        CurrentIdx = new Point(0, 0);
    //    }
    //    public bool IndexInc()//return index success, fail = cannot index
    //    {
    //        if (CurrentIdx.X < TColCount - 1)
    //        {
    //            CurrentIdx.X++;
    //        }
    //        else
    //        {
    //            if (CurrentIdx.Y < TRowCount - 1)
    //            {
    //                CurrentIdx.X = 0;
    //                CurrentIdx.Y++;
    //            }
    //            else
    //            {
    //                Empty = true;
    //                return false;
    //            }
    //        }

    //        return true;
    //    }
    //}

}
