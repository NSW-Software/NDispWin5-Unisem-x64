using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
//using GrabberNET;
using LEDStudio.Net;
using System.Xml;
//using SpinnakerNET;
//using FlyCapture2Managed;
using System.ComponentModel;

/*todo
- camera init error handling
- camera close
*/

namespace NDispWin
{
    using Emgu.CV;
    using Emgu.CV.Structure;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Util;
    using Emgu.Util;

    public struct TLightRGBA
    {
        public int R;
        public int G;
        public int B;
        public int A;
        public TLightRGBA(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    class VisUtils
    {
        public static void DrawLine(Image<Bgr, byte> ImageC, Point Pt1, Point Pt2, Color Color)
        {
            CvInvoke.Line(ImageC, Pt1, Pt2, new MCvScalar(Color.B, Color.G, Color.R), 1, LineType.EightConnected, 0);
        }
        public static void DrawRect(Image<Bgr, byte> ImageC, Rectangle Rect, Color Color)
        {
            CvInvoke.Rectangle(ImageC, new Rectangle(new Point(Rect.Left, Rect.Top), new Size(Rect.Width, Rect.Height)), new MCvScalar(Color.B, Color.G, Color.R), 1, LineType.EightConnected, 0);
        }
        public static void DrawCircle(Image<Bgr, byte> ImageC, Point Pt, int Radius, Color Color)
        {
            CvInvoke.Circle(ImageC, Pt, Radius, new MCvScalar(Color.B, Color.G, Color.R), 1, LineType.EightConnected, 0);
        }

        public static void DrawPlus(Image<Bgr, byte> ImageC, Point Pt, int Size, Color Color)
        {
            Point pt1 = Pt;
            Point pt2 = Pt;
            pt1.X -= Size / 2;
            pt2.X += Size / 2;
            CvInvoke.Line(ImageC, pt1, pt2, new MCvScalar(Color.B, Color.G, Color.R), 1, LineType.EightConnected, 0);
            Point pt3 = Pt;
            Point pt4 = Pt;
            pt3.Y -= Size / 2;
            pt4.Y += Size / 2;
            CvInvoke.Line(ImageC, pt3, pt4, new MCvScalar(Color.B, Color.G, Color.R), 1, LineType.EightConnected, 0);
        }
        public static void DrawCross(Image<Bgr, byte> ImageC, Point Pt, int Size, Color Color)
        {
            Point pt1 = Pt;
            Point pt2 = Pt;
            pt1.X -= Size / 2;
            pt1.Y -= Size / 2;
            pt2.X += Size / 2;
            pt2.Y += Size / 2;
            CvInvoke.Line(ImageC, pt1, pt2, new MCvScalar(Color.B, Color.G, Color.R), 1, LineType.EightConnected, 0);
            Point pt3 = Pt;
            Point pt4 = Pt;
            pt3.X += Size / 2;
            pt3.Y -= Size / 2;
            pt4.X -= Size / 2;
            pt4.Y += Size / 2;
            CvInvoke.Line(ImageC, pt3, pt4, new MCvScalar(Color.B, Color.G, Color.R), 1, LineType.EightConnected, 0);
        }
        public enum TTextAlign
        {
            TopLeft = 1,
            TopCenter = 2,
            TopRight = 3,
            MiddleLeft = 4,
            MiddleCenter = 5,
            MiddleRight = 6,
            BottomLeft = 0,
            BottomCenter = 7,
            BottomRight = 8,
        }
        public static void DrawText(Image<Bgr, byte> ImageC, Point Pt, string Text, double Size_Pixel, TTextAlign TextAlign, Color Color)
        {
            CvInvoke.PutText(ImageC, Text, Pt, FontFace.HersheyComplex, 1, new MCvScalar(Color.B, Color.G, Color.R));
        }
        public static void DrawText(Image<Bgr, byte> ImageC, Point Pt, string Text, double Size_Pixel, Color Color)
        {
            DrawText(ImageC, Pt, Text, Size_Pixel, TTextAlign.TopLeft, Color);
        }

        public class EMatchTemplate
        {
            public Image<Gray, Byte> Image = null;
            public Rectangle SearchRoi = new Rectangle(10, 10, 100, 100);
            public Rectangle PatternRoi = new Rectangle(20, 20, 50, 50);
            public double Correlation = 0;
            public bool Save(string Path, string TemplateName)
            {
                while (Path.EndsWith("/"))
                {
                    Path = Path.Remove(Path.Length);
                }

                string FileExExt = Path + "/" + TemplateName;

                NUtils.IniFile Inifile = new NUtils.IniFile(FileExExt + ".ini");

                Inifile.WriteInteger("Search", "X", SearchRoi.X);
                Inifile.WriteInteger("Search", "Y", SearchRoi.Y);
                Inifile.WriteInteger("Search", "W", SearchRoi.Width);
                Inifile.WriteInteger("Search", "H", SearchRoi.Height);
                Inifile.WriteInteger("Template", "X", PatternRoi.X);
                Inifile.WriteInteger("Template", "Y", PatternRoi.Y);
                Inifile.WriteInteger("Template", "W", PatternRoi.Width);
                Inifile.WriteInteger("Template", "H", PatternRoi.Height);
                Inifile.WriteDouble("Reference", "Correlation", Correlation);

                try
                {
                    Image.Save(FileExExt + ".bmp");
                }
                catch { };

                return true;
            }
            public bool SaveXML(string fileName, string templateName)
            {
                NUtils.XmlFile xmlFile = new NUtils.XmlFile(fileName, "root");
                try
                {

                    xmlFile.Open();

                    int[] intArr = new int[4];
                    intArr = new int[4] { SearchRoi.X, SearchRoi.Y, SearchRoi.Width, SearchRoi.Height };
                    xmlFile.SetValue("Program", "Vision", templateName, "SearchRoi", intArr);
                    intArr = new int[4] { PatternRoi.X, PatternRoi.Y, PatternRoi.Width, PatternRoi.Height };
                    xmlFile.SetValue("Program", "Vision", templateName, "PatternRoi", intArr);
                    xmlFile.SetValue("Program", "Vision", templateName, "Correlation", Correlation);

                    Bitmap bmp = null;
                    try
                    {
                        if (Image != null) bmp = Image.ToBitmap();
                        xmlFile.SetValue("Program", "Vision", templateName, "Template", bmp);
                    }
                    finally
                    {
                        if (bmp != null) bmp.Dispose();
                    }
                }
                finally
                {
                    xmlFile.Save();
                }
                return true;
            }
            public bool SaveXML(XmlWriter writer)//write subentries
            {
                try
                {
                    int[] intArr = new int[4];
                    intArr = new int[4] { SearchRoi.X, SearchRoi.Y, SearchRoi.Width, SearchRoi.Height };
                    DispProg.WriteSubEntry(writer, "SearchRoi", intArr);
                    intArr = new int[4] { PatternRoi.X, PatternRoi.Y, PatternRoi.Width, PatternRoi.Height };
                    DispProg.WriteSubEntry(writer, "PatternRoi", intArr);
                    DispProg.WriteSubEntry(writer, "Correlation", Correlation);

                    Bitmap bmp = null;
                    try
                    {
                        if (Image != null) bmp = Image.ToBitmap();
                        DispProg.WriteSubEntry(writer, "Template", bmp);
                    }
                    finally
                    {
                        if (bmp != null) bmp.Dispose();
                    }

                }
                catch { }

                return true;
            }

            public bool Load(string Path, string TemplateName)
            {
                while (Path.EndsWith("/"))
                {
                    Path = Path.Remove(Path.Length);
                }

                string FileExExt = Path + "/" + TemplateName;

                NUtils.IniFile Inifile = new NUtils.IniFile(FileExExt + ".ini");

                SearchRoi.X = Inifile.ReadInteger("Search", "X", 10);
                SearchRoi.Y = Inifile.ReadInteger("Search", "Y", 10);
                SearchRoi.Width = Inifile.ReadInteger("Search", "W", 100);
                SearchRoi.Height = Inifile.ReadInteger("Search", "H", 100);
                PatternRoi.X = Inifile.ReadInteger("Template", "X", 20);
                PatternRoi.Y = Inifile.ReadInteger("Template", "Y", 20);
                PatternRoi.Width = Inifile.ReadInteger("Template", "W", 50);
                PatternRoi.Height = Inifile.ReadInteger("Template", "H", 50);
                Correlation = Inifile.ReadDouble("Reference", "Correlation", 0);

                try
                {
                    Image = new Image<Gray, byte>(FileExExt + ".bmp");
                }
                catch { };
                return true;
            }
            public bool LoadXML(string fileName, string templateName)
            {
                NUtils.XmlFile xmlFile = new NUtils.XmlFile(fileName, "Recipe");
                try
                {
                    xmlFile.Open();

                    int[] intArr = new int[4];
                    intArr = new int[4] { 10, 10, 100, 100 };
                    intArr = xmlFile.GetValue("Program", "Vision", templateName, "SearchRoi", intArr);
                    SearchRoi.X = intArr[0];
                    SearchRoi.Y = intArr[1];
                    SearchRoi.Width = intArr[2];
                    SearchRoi.Height = intArr[3];

                    intArr = new int[4] { 20, 20, 50, 50 };
                    intArr = xmlFile.GetValue("Program", "Vision", templateName, "PatternRoi", intArr);
                    PatternRoi.X = intArr[0];
                    PatternRoi.Y = intArr[1];
                    PatternRoi.Width = intArr[2];
                    PatternRoi.Height = intArr[3];

                    Correlation = xmlFile.GetValue("Program", "Vision", templateName, "Correlation", 0);

                    Bitmap bmp = null;
                    try
                    {
                        bmp = xmlFile.GetValue("Program", "Vision", templateName, "Template", (Bitmap)null);
                        Image = null;
                        if (bmp != null) Image = bmp.ToImage<Gray, byte>();//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(bmp);
                    }
                    finally
                    {
                        if (bmp != null) bmp.Dispose();
                    }
                }
                finally
                {
                }
                return true;
            }
            public bool LoadXML(XmlReader reader, ref TLightRGBA LightRGB)
            {
                try
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                        if (reader.Name == "subentry")
                        {
                            string attName = reader["name"];

                            switch (attName)
                            {
                                case "Lighting":
                                    {
                                        int[] intArr = new int[4] { 25, 0, 0, 0 };
                                        intArr = DispProg.ReadSubEntry(reader, intArr);
                                        LightRGB.R = intArr[0];
                                        LightRGB.G = intArr[1];
                                        LightRGB.B = intArr[2];
                                        LightRGB.A = intArr[3];
                                    }
                                    break;
                                case "SearchRoi":
                                    {
                                        int[] intArr = new int[4] { 10, 10, 100, 100 };
                                        intArr = DispProg.ReadSubEntry(reader, intArr);
                                        SearchRoi.X = intArr[0];
                                        SearchRoi.Y = intArr[1];
                                        SearchRoi.Width = intArr[2];
                                        SearchRoi.Height = intArr[3];
                                    }
                                    break;
                                case "PatternRoi":
                                    {
                                        int[] intArr = new int[4] { 20, 20, 80, 80 };
                                        intArr = DispProg.ReadSubEntry(reader, intArr);
                                        PatternRoi.X = intArr[0];
                                        PatternRoi.Y = intArr[1];
                                        PatternRoi.Width = intArr[2];
                                        PatternRoi.Height = intArr[3];
                                    }
                                    break;
                                case "Correlation":
                                    Correlation = DispProg.ReadSubEntry(reader, 0);
                                    break;
                                case "Template":
                                    Bitmap bmp = null;
                                    try
                                    {
                                        bmp = DispProg.ReadSubEntry(reader, bmp);
                                        Image = null;
                                        if (bmp != null) Image = bmp.ToImage<Gray, byte>();//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(bmp);
                                    }
                                    finally
                                    {
                                        if (bmp != null) bmp.Dispose();
                                    }
                                    break;
                            }
                        }
                    }
                }
                catch
                {
                }
                return true;
            }
            public bool LoadXML(XmlReader reader)
            {
                TLightRGBA rgba = new TLightRGBA();
                return LoadXML(reader, ref rgba);
            }
        }
        public static void Learn(Image<Gray, Byte> SourceImage, EMatchTemplate Template, Rectangle SearchRoi, Rectangle PatternRoi)
        {
            Image<Gray, float> imgResult = null;
            try
            {
                Template.Image = SourceImage.Copy(PatternRoi);
                Template.SearchRoi = SearchRoi;
                Template.PatternRoi = PatternRoi;

                //Image<Gray, float> imgResult = null;
                double[] minCorr;
                double[] maxCorr;
                Point[] minPt;
                Point[] maxPt;
                imgResult = SourceImage.MatchTemplate(Template.Image, (TemplateMatchingType)_MatchType);

                imgResult.MinMax(out minCorr, out maxCorr, out minPt, out maxPt);
                switch (_MatchType)
                {
                    case EMatchType.CV_TM_SQDIFF:
                    case EMatchType.CV_TM_SQDIFF_NORMED:
                        Template.Correlation = minCorr[0];
                        break;
                    case EMatchType.CV_TM_CCOEFF:
                    case EMatchType.CV_TM_CCOEFF_NORMED:
                    case EMatchType.CV_TM_CCORR:
                    case EMatchType.CV_TM_CCORR_NORMED:
                        Template.Correlation = maxCorr[0];
                        break;
                }
            }
            catch { throw; }
            finally
            {
                imgResult.Dispose();
            }
        }
        public enum EMatchType
        {
            // Summary:
            //     R(x,y)=sumx',y'[T(x',y')-I(x+x',y+y')]2
            CV_TM_SQDIFF = 0,
            //
            // Summary:
            //     R(x,y)=sumx',y'[T(x',y')-I(x+x',y+y')]2/sqrt[sumx',y'T(x',y')2 sumx',y'I(x+x',y+y')2]
            CV_TM_SQDIFF_NORMED = 1,
            //
            // Summary:
            //     R(x,y)=sumx',y'[T(x',y') I(x+x',y+y')]
            CV_TM_CCORR = 2,
            //
            // Summary:
            //     R(x,y)=sumx',y'[T(x',y') I(x+x',y+y')]/sqrt[sumx',y'T(x',y')2 sumx',y'I(x+x',y+y')2]
            CV_TM_CCORR_NORMED = 3,
            //
            // Summary:
            //     R(x,y)=sumx',y'[T'(x',y') I'(x+x',y+y')], where T'(x',y')=T(x',y') - 1/(wxh)
            //     sumx",y"T(x",y") I'(x+x',y+y')=I(x+x',y+y') - 1/(wxh) sumx",y"I(x+x",y+y")
            CV_TM_CCOEFF = 4,
            //
            // Summary:
            //     R(x,y)=sumx',y'[T'(x',y') I'(x+x',y+y')]/sqrt[sumx',y'T'(x',y')2 sumx',y'I'(x+x',y+y')2]
            CV_TM_CCOEFF_NORMED = 5,
        }
        public struct EMatchResult
        {
            public float X;
            public float Y;
            public float S;
        }
        private static EMatchType _MatchType = EMatchType.CV_TM_SQDIFF_NORMED;
        public static EMatchType MatchType
        {
            get { return _MatchType; }
            set { _MatchType = value; }
        }
        public static void Match(Image<Gray, Byte> SourceImage, Image<Gray, Byte> PatternImage, float MinScore, int ResultCount, List<EMatchResult> MatchResults)
        {
            Image<Gray, float> imgMatchResult = null;
            //imgMatchResult = SourceImage.MatchTemplate(PatternImage, (TM_TYPE)_MatchType);
            imgMatchResult = SourceImage.MatchTemplate(PatternImage, (TemplateMatchingType)_MatchType);

            //Image<Gray, float> imgResult2 = null;
            //CvInvoke.cvNormalize(imgMatchResult, imgMatchResult, 0, 1, NORM_TYPE.CV_MINMAX, imgResult2);

            if (ResultCount == 1)
            {
                double[] minCorr;
                double[] maxCorr;
                Point[] minPt;
                Point[] maxPt;
                imgMatchResult.MinMax(out minCorr, out maxCorr, out minPt, out maxPt);

                EMatchResult R = new EMatchResult();
                switch (_MatchType)
                {
                    case EMatchType.CV_TM_SQDIFF:
                    case EMatchType.CV_TM_SQDIFF_NORMED:
                        R.X = (float)minPt[0].X;
                        R.Y = (float)minPt[0].Y;
                        R.S = (float)(1 - minCorr[0]);
                        MatchResults.Add(R);
                        break;
                    case EMatchType.CV_TM_CCOEFF:
                    case EMatchType.CV_TM_CCOEFF_NORMED:
                    case EMatchType.CV_TM_CCORR:
                    case EMatchType.CV_TM_CCORR_NORMED:
                        R.X = (float)minPt[0].X;
                        R.Y = (float)minPt[0].Y;
                        R.S = (float)(maxCorr[0]);
                        MatchResults.Add(R);
                        break;
                }
            }
            else
            {

                float[, ,] Matches = imgMatchResult.Data;

                List<int> X = new List<int>();
                List<int> Y = new List<int>();
                List<float> S = new List<float>();
                List<int> Filtered = new List<int>();

                int TW = PatternImage.Width;
                int TH = PatternImage.Height;

                #region Pass1 Filter Score
                int iLast = -1;
                int jLast = -1;
                float sLast = 10;
                float Score = 0;
                float MaxScore = 0;
                for (int j = 0; j < Matches.GetLength(0); j += TH)
                    for (int i = 0; i < Matches.GetLength(1); i += TW)
                    {
                        for (int j2 = j; j2 < j + TH; j2++)
                        {
                            for (int i2 = i; i2 < i + TW; i2++)
                            {
                                if (j2 >= Matches.GetLength(0)) continue;
                                if (i2 >= Matches.GetLength(1)) continue;

                                switch (_MatchType)
                                {
                                    case EMatchType.CV_TM_SQDIFF:
                                    case EMatchType.CV_TM_SQDIFF_NORMED:
                                        Score = (1 - Matches[j2, i2, 0]);
                                        break;
                                    case EMatchType.CV_TM_CCOEFF:
                                    case EMatchType.CV_TM_CCOEFF_NORMED:
                                    case EMatchType.CV_TM_CCORR:
                                    case EMatchType.CV_TM_CCORR_NORMED:
                                        Score = Matches[j2, i2, 0];
                                        break;
                                }

                                if (sLast == 10)
                                {
                                    sLast = Score;//Matches[j2, i2, 0];
                                    iLast = i2;
                                    jLast = j2;
                                    //MaxScore = Score;
                                    continue;
                                }
                                if (/*Score >= MinScore &&*/ Score > sLast)
                                {
                                    iLast = i2;
                                    jLast = j2;
                                    //MaxScore = Score;
                                    sLast = Score;
                                }
                            }
                        }
                        if (/*MaxScore*/sLast >= MinScore)
                        {
                            X.Add(iLast);
                            Y.Add(jLast);
                            //S.Add(1 - Matches[jLast, iLast, 0]);
                            S.Add(/*MaxScore*/sLast);
                            Filtered.Add(0);
                        }
                        sLast = 10;
                    }
                #endregion

                #region Pass2 Filter Overlap
                for (int i = 0; i < X.Count; i++)
                {
                    for (int j = 0; j < X.Count; j++)
                    {
                        if (i == j) continue;

                        if ((X[j] >= X[i] && X[j] <= X[i] + TW && Y[j] >= Y[i] && Y[j] <= Y[i] + TH) ||
                            (X[j] >= X[i] && X[j] <= X[i] + TW && Y[j] + TH >= Y[i] && Y[j] + TH <= Y[i] + TH) ||
                            (X[j] + TW >= X[i] && X[j] + TW <= X[i] + TW && Y[j] >= Y[i] && Y[j] <= Y[i] + TH) ||
                            (X[j] + TW >= X[i] && X[j] + TW <= X[i] + TW && Y[j] + TH >= Y[i] && Y[j] + TH <= Y[i] + TH))
                        {
                            float A = S[i];
                            float B = S[j];

                            if (B <= A)
                            {
                                Filtered[j] = -1;
                            }
                            //break;
                        }
                    }
                }
                List<int> X2 = new List<int>();
                List<int> Y2 = new List<int>();
                List<float> S2 = new List<float>();
                for (int i = 0; i < X.Count; i++)
                {
                    if (Filtered[i] == 0)
                    {
                        X2.Add(X[i]);
                        Y2.Add(Y[i]);
                        S2.Add(S[i]);
                    }
                }
                #endregion

                #region Update MatchResult
                for (int i = 0; i < X2.Count; i++)
                {
                    EMatchResult R = new EMatchResult();
                    R.X = X2[i];
                    R.Y = Y2[i];
                    R.S = S2[i];

                    if (i == 0)
                    {
                        MatchResults.Add(R);
                        continue;
                    }
                    for (int j = 0; j < MatchResults.Count; j++)
                    {
                        if (j == MatchResults.Count - 1)
                        {
                            MatchResults.Add(R);
                            break;
                        }
                        if (R.S > MatchResults[j].S)
                        {
                            MatchResults.Insert(j, R);
                            break;
                        }
                    }
                }
                #endregion

                if (ResultCount > 0)
                {
                    while (MatchResults.Count > ResultCount)
                    {
                        MatchResults.RemoveAt(MatchResults.Count - 1);
                    }
                }
            }
        }
        public static void Match(Image<Gray, Byte> SourceImage, EMatchTemplate Template, float MinScore, ref float Score, ref float X, ref float Y, ref float OX, ref float OY)
        {
            try
            {
                Image<Gray, Byte> _SourceImage = new Image<Gray, byte>(SourceImage.Data);
                _SourceImage.ROI = Template.SearchRoi;

                List<EMatchResult> MatchResults = new List<EMatchResult>();
                Match(_SourceImage, Template.Image, MinScore, 1, MatchResults);
                if (MatchResults.Count > 0)
                {
                    Score = MatchResults[0].S;
                    X = MatchResults[0].X + Template.SearchRoi.X;
                    Y = MatchResults[0].Y + Template.SearchRoi.Y;
                    OX = X - Template.PatternRoi.X;
                    OY = Y - Template.PatternRoi.Y;
                }
                else
                    Score = 0;
            }
            catch { throw; }
        }
        public static void Match(Image<Gray, Byte> SourceImage, EMatchTemplate Template, float MinScore, int ResultCount, List<EMatchResult> MatchResults)
        {
            try
            {
                Image<Gray, Byte> _SourceImage = new Image<Gray, byte>(SourceImage.Data);
                _SourceImage.ROI = Template.SearchRoi;

                List<EMatchResult> _MatchResults = new List<EMatchResult>();
                Match(_SourceImage, Template.Image, MinScore, ResultCount, _MatchResults);
                MatchResults.Clear();
                for (int i = 0; i < _MatchResults.Count; i++)
                {
                    EMatchResult R = new EMatchResult();
                    R.X = _MatchResults[i].X + Template.SearchRoi.X;
                    R.Y = _MatchResults[i].Y + Template.SearchRoi.Y;
                    R.S = _MatchResults[i].S;
                    MatchResults.Add(R);
                }
            }
            catch { throw; }
        }
    }


    class PtGrey
    {
        //public class TCamera
        //{
        //    private ManagedCameraBase m_camera = new ManagedCamera();
        //    private ManagedImage m_rawImage = new ManagedImage();
        //    private ManagedImage m_processedImage = new ManagedImage();
        //    private CameraInfo m_camInfo = new CameraInfo();
        //    private AutoResetEvent m_grabThreadExited = new AutoResetEvent(false);
        //    private BackgroundWorker m_grabThread;

        //    public TCamera()
        //    {
        //    }

        //    public bool Open(string ipAddress)
        //    {
        //        try
        //        {
        //            ManagedBusManager busMgr = new ManagedBusManager();
        //            uint numCameras = busMgr.GetNumOfCameras();

        //            IPAddress IP = IPAddress.Parse(ipAddress);

        //            ManagedPGRGuid guid = busMgr.GetCameraFromIPAddress(IP);

        //            m_camera.Connect(guid);
        //            m_camInfo = m_camera.GetCameraInfo();

        //            SetDefProperties();
        //        }
        //        catch
        //        {
        //            throw;
        //            //return false;
        //        }

        //        return true;
        //    }
        //    public void Close()
        //    {
        //        b_Grabbing = false;
        //        try
        //        {
        //            m_camera.StopCapture();
        //        }
        //        catch
        //        { }

        //        try
        //        {
        //            m_camera.Disconnect();
        //        }
        //        catch
        //        { }
        //    }

        //    public bool IsConnected
        //    {
        //        get { return m_camera.IsConnected(); }
        //    }
        //    public bool IsGrabbing
        //    {
        //        get { return b_Grabbing; }
        //    }

        //    private Object localLock2 = new Object();
        //    public Bitmap Image()
        //    {
        //        //lock (localLock2)
        //        //{
        //        return m_processedImage.bitmap;
        //        //}
        //    }

        //    #region Camera Properties
        //    public void SetDefProperties()
        //    {
        //        //SetProperty(PropertyType.Brightness, 0);

        //        //Property      
        //        //Brightness


        //        //Brightness Valaue = 0;
        //        CameraProperty Prop = m_camera.GetProperty(PropertyType.Brightness);
        //        Prop.absControl = false;
        //        Prop.absValue = 0;
        //        m_camera.SetProperty(Prop);

        //        //AutoExposure Auto=false, OnOff=true and Value=0 EV;
        //        Prop = m_camera.GetProperty(PropertyType.AutoExposure);
        //        Prop.autoManualMode = false;
        //        Prop.onOff = true;
        //        Prop.absControl = true;
        //        Prop.absValue = 0;
        //        m_camera.SetProperty(Prop);

        //        //Sharpness Auto=false, OnOff=false
        //        Prop = m_camera.GetProperty(PropertyType.Sharpness);
        //        Prop.autoManualMode = false;
        //        Prop.onOff = true;
        //        //Prop.absControl = true;
        //        Prop.valueA = 1024;
        //        m_camera.SetProperty(Prop);

        //        //Gamma OnOff=false
        //        Prop = m_camera.GetProperty(PropertyType.Gamma);
        //        Prop.autoManualMode = false;
        //        Prop.onOff = true;
        //        Prop.absControl = true;
        //        Prop.absValue = 1;
        //        m_camera.SetProperty(Prop);

        //        TriggerMode = false;

        //        //Shutter Auto=false
        //        Prop = m_camera.GetProperty(PropertyType.Shutter);
        //        Prop.autoManualMode = false;
        //        Prop.absControl = true;
        //        Prop.absValue = 0;
        //        m_camera.SetProperty(Prop);

        //        //Gain Auto=false, Value=0 dB
        //        Prop = m_camera.GetProperty(PropertyType.Gain);
        //        Prop.autoManualMode = false;
        //        Prop.onOff = true;
        //        Prop.absControl = true;
        //        Prop.absValue = 0;
        //        m_camera.SetProperty(Prop);

        //        //FrameRate Auto=false, OnOff=true
        //        Prop = m_camera.GetProperty(PropertyType.FrameRate);
        //        Prop.autoManualMode = false;
        //        Prop.onOff = true;
        //        Prop.absControl = true;
        //        Prop.absValue = 25;
        //        m_camera.SetProperty(Prop);
        //    }
        //    public enum EProperty
        //    {
        //        Gain = (int)PropertyType.Gain,
        //        Shutter = (int)PropertyType.Shutter,
        //        FrameRate = (int)PropertyType.FrameRate,
        //    }
        //    public void GetProperty(EProperty Property, ref bool Avail, ref double Min, ref double Max, ref double Value)
        //    {
        //        CameraProperty Prop = m_camera.GetProperty((PropertyType)Property);
        //        if (!Prop.present)
        //        {
        //            Avail = false;
        //        }
        //        else
        //        {
        //            CameraPropertyInfo PropInfo = m_camera.GetPropertyInfo((PropertyType)Property);
        //            Min = PropInfo.absMin;
        //            Max = PropInfo.absMax;
        //            Value = Prop.absValue;
        //        }
        //    }
        //    public void GetProperty(EProperty Property, ref bool Avail, ref bool Value)
        //    {
        //        CameraProperty Prop = m_camera.GetProperty((PropertyType)Property);
        //        if (!Prop.present)
        //        {
        //            Avail = false;
        //        }
        //        else
        //        {
        //            Value = Prop.onOff;
        //        }
        //    }
        //    private void SetProperty(PropertyType Property, double Value)
        //    {
        //        CameraProperty Prop = m_camera.GetProperty((PropertyType)Property);
        //        if (!Prop.present) return;

        //        Prop.absValue = (float)Value;

        //        m_camera.SetProperty(Prop);
        //    }
        //    public void SetProperty(EProperty Property, double Value)
        //    {
        //        SetProperty((PropertyType)Property, Value);
        //    }
        //    public void SetProperty(EProperty Property, bool Value)
        //    {
        //        CameraProperty Prop = m_camera.GetProperty((PropertyType)Property);
        //        if (!Prop.present) return;

        //        Prop.onOff = Value;

        //        m_camera.SetProperty(Prop);
        //    }

        //    private const uint sk_imageDataFmtReg = 0x1048;
        //    private const uint sk_mirrorImageCtrlReg = 0x1054;
        //    public void GetRegister_Mirror(ref uint Value)
        //    {
        //        uint reg = 0;
        //        uint mirrorCtrlRegister = sk_imageDataFmtReg;
        //        uint mirrorMask = 0x1 << 8;
        //        const uint iidcVersion = 132;
        //        if (m_camInfo.iidcVersion >= iidcVersion)
        //        {
        //            mirrorCtrlRegister = sk_mirrorImageCtrlReg;
        //            mirrorMask = 0x1;
        //        }

        //        try
        //        {
        //            reg = m_camera.ReadRegister(mirrorCtrlRegister);
        //        }
        //        catch (FC2Exception ex)
        //        {
        //            throw;
        //        }

        //        Value = reg;
        //    }
        //    public void SetRegister_Mirror(uint Value)
        //    {
        //        uint mirrorCtrlRegister = sk_imageDataFmtReg;
        //        uint mirrorMask = 0x1 << 8;
        //        const uint iidcVersion = 132;
        //        if (m_camInfo.iidcVersion >= iidcVersion)
        //        {
        //            mirrorCtrlRegister = sk_mirrorImageCtrlReg;
        //            mirrorMask = 0x1;
        //        }

        //        if (Value > 0)
        //        {
        //            Value |= mirrorMask;
        //        }
        //        else
        //        {
        //            Value &= ~mirrorMask;
        //        }

        //        try
        //        {
        //            m_camera.WriteRegister(mirrorCtrlRegister, Value);
        //        }
        //        catch (FC2Exception ex)
        //        {
        //            throw;
        //        }
        //    }

        //    public void GetImageSettings(ref uint maxHeight, ref uint maxWidth, ref uint Left, ref uint Top, ref uint Width, ref uint Height)
        //    {
        //        try
        //        {
        //            ManagedCamera camera = (ManagedCamera)m_camera;

        //            // Query for available Format 7 modes
        //            const Mode k_fmt7Mode = Mode.Mode0;
        //            bool supported = false;
        //            Format7Info fmt7Info = camera.GetFormat7Info(k_fmt7Mode, ref supported);
        //            maxHeight = fmt7Info.maxHeight;
        //            maxWidth = fmt7Info.maxWidth;

        //            Format7ImageSettings imageSettings = new Format7ImageSettings();
        //            uint packetSize = 0;
        //            float speed = 0;
        //            camera.GetFormat7Configuration(imageSettings, ref packetSize, ref speed);

        //            Left = imageSettings.offsetX;
        //            Top = imageSettings.offsetY;
        //            Width = imageSettings.width;
        //            Height = imageSettings.height;
        //        }
        //        catch { throw; }
        //    }
        //    public void SetImageSettings(uint Left, uint Top, uint Width, uint Height)
        //    {
        //        try
        //        {
        //            ManagedCamera camera = (ManagedCamera)m_camera;

        //            Format7ImageSettings imageSettings = new Format7ImageSettings();
        //            uint packetSize = 0;
        //            float speed = 0;

        //            camera.GetFormat7Configuration(imageSettings, ref packetSize, ref speed);

        //            imageSettings.offsetX = Left;
        //            imageSettings.offsetY = Top;
        //            imageSettings.width = Width;
        //            imageSettings.height = Height;

        //            camera.SetFormat7Configuration(imageSettings, speed);
        //        }
        //        catch
        //        { throw; }
        //    }
        //    #endregion

        //    public delegate void OnAcquiredEventHandler(object sender, EventArgs e);
        //    public event OnAcquiredEventHandler AcquiredEvent;
        //    private void OnAcquiredEvent()
        //    {
        //        if (AcquiredEvent != null) AcquiredEvent(this, EventArgs.Empty);
        //    }

        //    public delegate void OnGrabbedEventHandler(object sender, EventArgs e);
        //    public event OnGrabbedEventHandler GrabbedEvent;
        //    private void OnGrabbedEvent()
        //    {
        //        if (GrabbedEvent != null) GrabbedEvent(this, EventArgs.Empty);
        //    }

        //    private bool b_Grabbing;
        //    public void StartGrab()
        //    {
        //        if (!m_camera.IsConnected()) return;

        //        //if (m_frameCount == 0)
        //        if (b_Grabbing) return;

        //        // Get the camera configuration
        //        FC2Config config = m_camera.GetConfiguration();

        //        // Set the grab timeout to 1 seconds
        //        config.grabTimeout = 500;

        //        // Set the camera configuration
        //        m_camera.SetConfiguration(config);

        //        m_camera.StartCapture();
        //        b_Grabbing = true;

        //        if (!TrigMode)
        //        {
        //            m_grabThread = new BackgroundWorker();
        //            m_grabThread.DoWork += new DoWorkEventHandler(GrabLoop);
        //            m_grabThread.WorkerReportsProgress = true;
        //            m_grabThread.RunWorkerAsync();
        //        }
        //    }

        //    private Object localLock = new Object();
        //    public void GrabLoop(object sender, DoWorkEventArgs e)
        //    {
        //        while (b_Grabbing)
        //        {
        //            try
        //            {
        //                m_camera.RetrieveBuffer(m_rawImage);
        //            }
        //            catch (FC2Exception ex)
        //            {
        //                continue;
        //            }

        //            OnAcquiredEvent();

        //            lock (localLock)
        //            {
        //                m_rawImage.Convert(FlyCapture2Managed.PixelFormat.PixelFormatBgr, m_processedImage);
        //            }

        //            OnGrabbedEvent();
        //        }

        //        m_grabThreadExited.Set();
        //    }
        //    public void StopGrab()
        //    {
        //        if (!m_camera.IsConnected()) return;

        //        if (!b_Grabbing) return;

        //        b_Grabbing = false;

        //        try
        //        {
        //            m_camera.StopCapture();
        //        }
        //        catch (FC2Exception ex)
        //        {
        //            throw;
        //        }
        //        catch (NullReferenceException)
        //        {
        //            throw;
        //        }
        //    }

        //    //private bool TrigSoure = 
        //    private bool TrigMode = false;
        //    public bool TriggerMode
        //    {
        //        get
        //        {
        //            TriggerMode triggerMode = m_camera.GetTriggerMode();
        //            return triggerMode.onOff;
        //        }
        //        set
        //        {
        //            if (value)
        //            {
        //                // Get current trigger settings
        //                TriggerMode triggerMode = m_camera.GetTriggerMode();

        //                // Set camera to trigger mode 0
        //                // A source of 7 means software trigger
        //                triggerMode.onOff = true;
        //                triggerMode.mode = 0;
        //                triggerMode.parameter = 0;

        //                //            if (useSoftwareTrigger)
        //                {
        //                    // A source of 7 means software trigger
        //                    //triggerMode.source = 7;
        //                }
        //                //            else
        //                {
        //                    // Triggering the camera externally using source 0.
        //                    triggerMode.source = 0;
        //                }

        //                // Set the trigger mode
        //                m_camera.SetTriggerMode(triggerMode);
        //                TrigMode = true;

        //                //wait trigger ready
        //                const uint k_softwareTrigger = 0x62C;
        //                uint regVal = 0;
        //                do
        //                {
        //                    regVal = m_camera.ReadRegister(k_softwareTrigger);
        //                }
        //                while ((regVal >> 31) != 0);
        //            }
        //            else
        //            {
        //                // Turn off trigger mode
        //                TriggerMode triggerMode = m_camera.GetTriggerMode();
        //                triggerMode.onOff = false;
        //                TrigMode = false;
        //                m_camera.SetTriggerMode(triggerMode);
        //            }

        //        }
        //    }
        //    public void SoftTrigger()
        //    {
        //        m_camera.FireSoftwareTrigger(false);
        //    }
        //    public void RetreiveBuffer()
        //    {
        //        //Stopwatch sw;
        //        //sw = Stopwatch.StartNew();
        //        //MsgBox2.Log.AddToLog("RetrieveBuffer - Start");
        //        try
        //        {
        //            m_camera.RetrieveBuffer(m_rawImage);
        //        }
        //        catch (FC2Exception ex)
        //        {
        //            //continue;
        //        }
        //        //MsgBox2.Log.AddToLog("RetrieveBuffer - AcquireEnd " + sw.ElapsedMilliseconds.ToString("f3"));
        //        //sw.Restart();

        //        lock (localLock)
        //        {
        //            m_rawImage.Convert(FlyCapture2Managed.PixelFormat.PixelFormatBgr, m_processedImage);
        //        }
        //        //MsgBox2.Log.AddToLog("RetrieveBuffer - ConvertEnd " + sw.ElapsedMilliseconds.ToString("f3"));
        //    }

        //    //private FlyCapture2Managed.Gui.CameraControlDialog m_camCtlDlg = new FlyCapture2Managed.Gui.CameraControlDialog();
        //    //public bool ControlDlg
        //    //{
        //    //    get
        //    //    {
        //    //        m_camCtlDlg.Connect(m_camera);
        //    //        return m_camCtlDlg.IsVisible();
        //    //    }
        //    //    set
        //    //    {
        //    //        m_camCtlDlg.Connect(m_camera);
        //    //        if (value)
        //    //        {
        //    //            m_camCtlDlg.Show();
        //    //        }
        //    //        else
        //    //        {
        //    //            if (m_camCtlDlg.IsVisible())
        //    //            {
        //    //                m_camCtlDlg.Hide();
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}
    }

    class TaskVision
    {
        //static Basler Basler = new Basler();  
        public static int MAX_CAMERA = 3;
        //public static Basler.TCamera[] CameraN = new Basler.TCamera[MAX_CAMERA];
        //public static PtGrey.TCamera[] PGCamera = new PtGrey.TCamera[MAX_CAMERA];

        //public static NImager.frmImageView frmGenImageView = new NImager.frmImageView();
        //public static NImager.GenericCamera[] FlirCamera = new NImager.GenericCamera[MAX_CAMERA];

        public static MVC.MVC_GenTL[] genTLCamera = new MVC.MVC_GenTL[4] { new MVC.MVC_GenTL(), new MVC.MVC_GenTL(), new MVC.MVC_GenTL(), new MVC.MVC_GenTL() };
        public static frmMVCGenTLCamera frmMVCGenTLCamera = new frmMVCGenTLCamera();

        public static FlirCamera[] flirCamera2 = new FlirCamera[4] { new NDispWin.FlirCamera(), new NDispWin.FlirCamera(), new NDispWin.FlirCamera(), new NDispWin.FlirCamera() };
        public static frmCamera frmCamera = new frmCamera();

        public static ECamNo SelectedCam = ECamNo.Cam00;

        internal enum EReticleType
        {
            None,
            CenterCrossHair,
            CenterCrossHair2,
            CenterReticle,
            Line,
            Cross,
            Circle,
            Rectangle,
            Text
        }
        internal const int MAX_RETICLE = 10;
        internal class TReticle
        {
            public int Count;
            public EReticleType[] Type;
            public Color[] Color;
            public Rectangle[] Rect;
            public string[] Text;
            public double[] Scale;

            public TReticle()
            {
                Count = 1;
                Type = new EReticleType[MAX_RETICLE];
                Color = new Color[MAX_RETICLE];
                Rect = new Rectangle[MAX_RETICLE];
                Text = new string[MAX_RETICLE];
                Scale = new double[MAX_RETICLE];
                for (int i = 0; i < MAX_RETICLE; i++)
                {
                    if (i == 0) Type[i] = EReticleType.CenterCrossHair; else Type[i] = EReticleType.None;
                    Color[i] = System.Drawing.Color.Lime;
                    Rect[i] = new Rectangle(100, 100, 100, 100);
                    Text[i] = "";
                    Scale[i] = 0.1;
                }
            }
        }
        internal static TReticle Reticles = new TReticle();

        public enum ECalStepCHair { None, TL, TR, BR, BL, C, L, R, T, B }
        public static ECalStepCHair DrawCalStep = ECalStepCHair.None;
        public static int FindCircle = 0;
        public static string TextString = "";
        public static Color TextColor = Color.Lime;
        public static void ImageDrawReticle(Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image, Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> ImageC)
        {
            #region Vision Cal
            if (DrawCalStep == ECalStepCHair.TL)
            {
                VisUtils.DrawPlus(ImageC, new Point(50, 50), 100, Color.Green);
                VisUtils.DrawText(ImageC, new Point(50 + 5, 50 + 5), DrawCalStep.ToString(), 12, Color.Green);
            }
            if (DrawCalStep == ECalStepCHair.TR)
            {
                VisUtils.DrawPlus(ImageC, new Point(Image.Width - 50, 50), 100, Color.Lime);
                VisUtils.DrawText(ImageC, new Point(Image.Width - 50 + 5, 50 + 5), DrawCalStep.ToString(), 12, Color.Green);
            }
            if (DrawCalStep == ECalStepCHair.BR)
            {
                VisUtils.DrawPlus(ImageC, new Point(Image.Width - 50, Image.Height - 50), 100, Color.Lime);
                VisUtils.DrawText(ImageC, new Point(Image.Width - 50 + 5, Image.Height - 50 + 5), DrawCalStep.ToString(), 12, Color.Green);
            }
            if (DrawCalStep == ECalStepCHair.BL)
            {
                VisUtils.DrawPlus(ImageC, new Point(50, Image.Height - 50), 100, Color.Lime);
                VisUtils.DrawText(ImageC, new Point(50 + 5, Image.Height - 50 + 5), DrawCalStep.ToString(), 12, Color.Green);
            }
            if (DrawCalStep == ECalStepCHair.C)
            {
                VisUtils.DrawPlus(ImageC, new Point(Image.Width / 2, Image.Height / 2), 100, Color.Lime);
                VisUtils.DrawText(ImageC, new Point(Image.Width / 2 + 5, Image.Height / 2 + 5),DrawCalStep.ToString(), 12, Color.Green);
            }
            if (DrawCalStep == ECalStepCHair.T)
            {
                VisUtils.DrawPlus(ImageC, new Point(Image.Width / 2, 50), 100, Color.Green);
                VisUtils.DrawText(ImageC, new Point(Image.Width / 2 + 5, 50 + 5), DrawCalStep.ToString(), 12, Color.Green);
            }
            if (DrawCalStep == ECalStepCHair.B)
            {
                VisUtils.DrawPlus(ImageC, new Point(Image.Width / 2, Image.Height - 50), 100, Color.Green);
                VisUtils.DrawText(ImageC, new Point(Image.Width / 2 + 5, Image.Height - 50 + 5), DrawCalStep.ToString(), 12, Color.Green);
            }
            if (DrawCalStep == ECalStepCHair.L)
            {
                VisUtils.DrawPlus(ImageC, new Point(50, Image.Height / 2), 100, Color.Lime);
                VisUtils.DrawText(ImageC, new Point(50 + 5, Image.Height / 2 + 5), DrawCalStep.ToString(), 12, Color.Green);
            }
            if (DrawCalStep == ECalStepCHair.R)
            {
                VisUtils.DrawPlus(ImageC, new Point(Image.Width - 50, Image.Height / 2), 100, Color.Lime);
                VisUtils.DrawText(ImageC, new Point(Image.Width - 50 + 5, Image.Height / 2 + 5), DrawCalStep.ToString(), 12, Color.Green);
            }
            #endregion
            for (int i = 0; i < TaskVision.Reticles.Count; i++)
            {
                #region Reticles
                if (TaskVision.SelectedCam == ECamNo.Cam00)
                {
                    TaskVision.EReticleType Type = TaskVision.Reticles.Type[i];
                    Color C = TaskVision.Reticles.Color[i];
                    int X = TaskVision.Reticles.Rect[i].X;
                    int Y = TaskVision.Reticles.Rect[i].Y;
                    int W = TaskVision.Reticles.Rect[i].Width;
                    int H = TaskVision.Reticles.Rect[i].Height;
                    string T = TaskVision.Reticles.Text[i];
                    double Scale = TaskVision.Reticles.Scale[i];

                    if (Type == TaskVision.EReticleType.CenterCrossHair)
                    {
                        VisUtils.DrawLine(ImageC, new Point(0, Image.Height / 2), new Point(Image.Width, Image.Height / 2), C);
                        VisUtils.DrawLine(ImageC, new Point(Image.Width / 2, 0), new Point(Image.Width / 2, Image.Height), C);
                    }
                    if (Type == TaskVision.EReticleType.CenterCrossHair2)
                    {
                        int OX1 = Image.Width * 1 / 8;
                        int OX3 = Image.Width * 3 / 8;
                        int OX5 = Image.Width * 5 / 8;
                        int OX7 = Image.Width * 7 / 8;

                        int OY1 = Image.Height * 1 / 8;
                        int OY3 = Image.Height * 3 / 8;
                        int OY5 = Image.Height * 5 / 8;
                        int OY7 = Image.Height * 7 / 8;

                        VisUtils.DrawLine(ImageC, new Point(0, Image.Height / 2), new Point(OX1, Image.Height / 2), C);
                        VisUtils.DrawLine(ImageC, new Point(OX3, Image.Height / 2), new Point(OX5, Image.Height / 2), C);
                        VisUtils.DrawLine(ImageC, new Point(OX7, Image.Height / 2), new Point(Image.Width, Image.Height / 2), C);

                        VisUtils.DrawLine(ImageC, new Point(Image.Width / 2, 0), new Point(Image.Width / 2, OY1), C);
                        VisUtils.DrawLine(ImageC, new Point(Image.Width / 2, OY3), new Point(Image.Width / 2, OY5), C);
                        VisUtils.DrawLine(ImageC, new Point(Image.Width / 2, OY7), new Point(Image.Width / 2, Image.Height), C);
                    }
                    if (Type == TaskVision.EReticleType.CenterReticle)
                    {
                        int cX = Image.Width / 2;
                        int cY = Image.Height / 2;

                        for (int x = 0; x < 30; x++)
                        {
                            if (Scale <= 0) Scale = 1;
                            int ncXP = (int)(cX + ((x + 1) / TaskVision.DistPerPixelX[(int)TaskVision.SelectedCam] * Scale));
                            int ncXN = (int)(cX - ((x + 1) / TaskVision.DistPerPixelX[(int)TaskVision.SelectedCam] * Scale));
                            int ncYP = (int)(cY + ((x + 1) / TaskVision.DistPerPixelY[(int)TaskVision.SelectedCam] * Scale));
                            int ncYN = (int)(cY - ((x + 1) / TaskVision.DistPerPixelY[(int)TaskVision.SelectedCam] * Scale));
                            int nc = 3;
                            if ((x + 1) == 5) nc = 6;
                            if ((x + 1) == 10) nc = 10;
                            if ((x + 1) == 15) nc = 6;
                            if ((x + 1) == 20) nc = 10;
                            if ((x + 1) == 25) nc = 6;
                            if ((x + 1) == 30) nc = 10;
                            VisUtils.DrawLine(ImageC, new Point(ncXP, cY - nc), new Point(ncXP, cY + nc), C);
                            VisUtils.DrawLine(ImageC, new Point(ncXN, cY - nc), new Point(ncXN, cY + nc), C);

                            VisUtils.DrawLine(ImageC, new Point(cX - nc, ncYP), new Point(cX + nc, ncYP), C);
                            VisUtils.DrawLine(ImageC, new Point(cX - nc, ncYN), new Point(cX + nc, ncYN), C);

                        }
                        VisUtils.DrawText(ImageC, new Point(10, Image.Height - 20), "1 : " + Scale.ToString("F2") + "mm", 10, C);
                    }
                    if (Type == TaskVision.EReticleType.Circle)
                    {
                        VisUtils.DrawCircle(ImageC, new Point(X, Y), W / 2, C);
                    }
                    if (Type == TaskVision.EReticleType.Cross)
                    {
                        VisUtils.DrawLine(ImageC, new Point(X, Y - H / 2), new Point(X, Y + H / 2), C);
                        VisUtils.DrawLine(ImageC, new Point(X - W / 2, Y), new Point(X + W / 2, Y), C);
                    }
                    if (Type == TaskVision.EReticleType.Line)
                    {
                        VisUtils.DrawLine(ImageC, new Point(X, Y), new Point(W, H), C);
                    }
                    if (Type == TaskVision.EReticleType.Rectangle)
                    {
                        VisUtils.DrawRect(ImageC, new Rectangle(X - W / 2, Y - H / 2, W, H), C);
                    }
                    if (Type == TaskVision.EReticleType.Text)
                    {
                        VisUtils.DrawText(ImageC, new Point(X, Y), T, H, C);
                    }
                }
                #endregion
                Thread.Sleep(5);
            }
            if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC && FindCircle == 1)
            {
                #region
                PointF Center = new PointF(0, 0);
                float Radius = 0f;
                int i_Circles = TaskVision.FindAperture(Image, ref Center, ref Radius);

                if (i_Circles > 0)
                {
                    Color Color = Color.Lime;

                    double OfstX = (Center.X - (double)Image.Width / 2) * TaskVision.DistPerPixelX[0];
                    double OfstY = (Center.Y - (double)Image.Height / 2) * TaskVision.DistPerPixelY[0];
                    //OfstX = OfstX;
                    OfstY = -OfstY;

                    if (Math.Abs(OfstX) > 0.05 || Math.Abs(OfstY) > 0.05) Color = Color.Red;

                    Emgu.CV.Structure.CircleF Circ = new Emgu.CV.Structure.CircleF(Center, Radius);
                    ImageC.Draw(Circ, new Emgu.CV.Structure.Bgr(Color), 1);

                    Emgu.CV.Structure.LineSegment2DF Line;
                    Line = new Emgu.CV.Structure.LineSegment2DF(new PointF(Center.X, Center.Y - 10), new PointF(Center.X, Center.Y + 10));
                    ImageC.Draw(Line, new Emgu.CV.Structure.Bgr(Color), 1);
                    Line = new Emgu.CV.Structure.LineSegment2DF(new PointF(Center.X - 10, Center.Y), new PointF(Center.X + 10, Center.Y));
                    ImageC.Draw(Line, new Emgu.CV.Structure.Bgr(Color), 1);

                    String s = (Radius * (TaskVision.DistPerPixelX[(int)SelectedCam] + TaskVision.DistPerPixelY[(int)SelectedCam])).ToString("f3");
                    //Emgu.CV.Structure.MCvFont Font = new Emgu.CV.Structure.MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);
                    Point P = new Point((int)Center.X + 5, (int)Center.Y - 5);
                    //ImageC.Draw(s, ref Font, P, new Emgu.CV.Structure.Bgr(Color));
                    CvInvoke.PutText(ImageC, s, P, FontFace.HersheyComplex, 0.5, new MCvScalar(Color.B, Color.G, Color.R));

                    String s3 = (OfstX.ToString("F3") + "," + OfstY.ToString("F3"));
                    Point P3 = new Point(5, Image.Height - 5);
                    //ImageC.Draw(s3, ref Font, P3, new Emgu.CV.Structure.Bgr(Color));
                    CvInvoke.PutText(ImageC, s3, P3, FontFace.HersheyComplex, 0.5, new MCvScalar(Color.B, Color.G, Color.R));
                }
                #endregion
            }
            if (GDefine.BottomCamType == GDefine.EBottomCamType.ATNC && FindCircle == 2)
            {
                #region
                PointF[] Center = new PointF[1024];
                float[] Radius = new float[1024];
                int i_Circles = TaskVision.FindApertureNeedle(Image, ref Center, ref Radius);

                Color Color1 = Color.Orange;
                Color Color2 = Color.Lime;

                if (i_Circles > 0)
                {
                    Emgu.CV.Structure.CircleF Circ = new Emgu.CV.Structure.CircleF(Center[0], Radius[0]);
                    ImageC.Draw(Circ, new Emgu.CV.Structure.Bgr(Color1), 1);

                    Emgu.CV.Structure.LineSegment2DF Line;
                    Line = new Emgu.CV.Structure.LineSegment2DF(new PointF(Center[0].X, Center[0].Y - 10), new PointF(Center[0].X, Center[0].Y + 10));
                    ImageC.Draw(Line, new Emgu.CV.Structure.Bgr(Color1), 1);
                    Line = new Emgu.CV.Structure.LineSegment2DF(new PointF(Center[0].X - 10, Center[0].Y), new PointF(Center[0].X + 10, Center[0].Y));
                    ImageC.Draw(Line, new Emgu.CV.Structure.Bgr(Color1), 1);

                    String s = (Radius[0] * (TaskVision.DistPerPixelX[(int)SelectedCam] + TaskVision.DistPerPixelY[(int)SelectedCam])).ToString("f3");
                    //Emgu.CV.Structure.MCvFont Font = new Emgu.CV.Structure.MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);
                    Point P = new Point((int)Center[0].X + 5, (int)Center[0].Y - 5);
                    //ImageC.Draw(s, ref Font, P, new Emgu.CV.Structure.Bgr(Color1));
                    CvInvoke.PutText(ImageC, s, P, FontFace.HersheyComplex, 0.5, new MCvScalar(Color1.B, Color1.G, Color1.R));
                }

                if (i_Circles > 1)
                {
                    double OfstX = (Center[0].X - Center[1].X) * TaskVision.DistPerPixelX[2];
                    double OfstY = (Center[0].Y - Center[1].Y) * TaskVision.DistPerPixelY[2];
                    //OfstX = OfstX;
                    OfstY = -OfstY;

                    if (Math.Abs(OfstX) > 0.05 || Math.Abs(OfstY) > 0.05) Color2 = Color.Red;

                    Emgu.CV.Structure.CircleF Circ2 = new Emgu.CV.Structure.CircleF(Center[1], Radius[1]);
                    ImageC.Draw(Circ2, new Emgu.CV.Structure.Bgr(Color2), 1);

                    Emgu.CV.Structure.LineSegment2DF Line2;
                    Line2 = new Emgu.CV.Structure.LineSegment2DF(new PointF(Center[1].X, Center[1].Y - 10), new PointF(Center[1].X, Center[1].Y + 10));
                    ImageC.Draw(Line2, new Emgu.CV.Structure.Bgr(Color2), 1);
                    Line2 = new Emgu.CV.Structure.LineSegment2DF(new PointF(Center[1].X - 10, Center[1].Y), new PointF(Center[1].X + 10, Center[1].Y));
                    ImageC.Draw(Line2, new Emgu.CV.Structure.Bgr(Color2), 1);

                    String s2 = (Radius[1] * (TaskVision.DistPerPixelX[(int)SelectedCam] + TaskVision.DistPerPixelY[(int)SelectedCam])).ToString("f3");
                    //Emgu.CV.Structure.MCvFont Font = new Emgu.CV.Structure.MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);
                    Point P2 = new Point((int)Center[1].X + 5, (int)Center[1].Y + 15);
                    //ImageC.Draw(s2, ref Font, P2, new Emgu.CV.Structure.Bgr(Color2));
                    CvInvoke.PutText(ImageC, s2, P2, FontFace.HersheyComplex, 0.5, new MCvScalar(Color2.B, Color2.G, Color2.R));

                    String s3 = (OfstX.ToString("F3") + "," + OfstY.ToString("F3"));
                    Point P3 = new Point(5, Image.Height - 5);
                    //ImageC.Draw(s3, ref Font, P3, new Emgu.CV.Structure.Bgr(Color2));
                    CvInvoke.PutText(ImageC, s3, P3, FontFace.HersheyComplex, 0.5, new MCvScalar(Color2.B, Color2.G, Color2.R));
                }
                #endregion
            }
            if (TextString.Length > 0)
            {
                //Emgu.CV.Structure.MCvMCvFont Font = new Emgu.CV.Structure.MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);
                //Point P = new Point((int)5, (int)15);
                //ImageC.Draw(TextString, ref Font, P, new Emgu.CV.Structure.Bgr(TaskVision.TextColor));
                CvInvoke.PutText(ImageC, TextString, new Point((int)5, (int)15), FontFace.HersheyComplex, 1, new MCvScalar(TextColor.B, TextColor.G, TextColor.R));
            }

            if (TaskVision.FoundPattern.Drawing)
            {
                if (GDefine.GetTickCount() >= TaskVision.FoundPattern.t_DrawEnd) TaskVision.FoundPattern.Drawing = false;

                PointF Point = new PointF((float)TaskVision.FoundPattern.Rect.X + (float)TaskVision.FoundPattern.Rect.Width / 2, (float)TaskVision.FoundPattern.Rect.Y + (float)TaskVision.FoundPattern.Rect.Height / 2);
                SizeF Size = new SizeF((float)TaskVision.FoundPattern.Rect.Width, (float)TaskVision.FoundPattern.Rect.Height);
                //Emgu.CV.Structure.MCvBox2D Box = new Emgu.CV.Structure.MCvBox2D(Point, Size, (float)-TaskVision.FoundPattern.Angle);
                RotatedRect Box = new RotatedRect(Point, Size, (float)-TaskVision.FoundPattern.Angle);


                if (TaskVision.FoundPattern.OK)
                    ImageC.Draw(Box, new Emgu.CV.Structure.Bgr(Color.Lime), 2);
                else
                    ImageC.Draw(Box, new Emgu.CV.Structure.Bgr(Color.Red), 2);
            }

            Thread.Sleep(5);
        }

        private static LEDStudio.Net.LCSerial LCSerial = new LEDStudio.Net.LCSerial();
        private static LEDStudio.Net.LCSerialLegacy LCSerLegacy = new LEDStudio.Net.LCSerialLegacy();

        public enum ECalMode {Ave_XY, Only_X, Only_Y, Aperture}
        public static ECalMode[] CalMode = new ECalMode[MAX_CAMERA];

        public static int SettleTime = 0;
        public static double[] DistPerPixelX = new double[MAX_CAMERA];//(float)0.001;
        public static double[] DistPerPixelY = new double[MAX_CAMERA];//(float)0.001;

        public static double[] ExposureTime = new double[MAX_CAMERA];//ms
        public static double[] Gain = new double[MAX_CAMERA];


        public static void LoadSetup()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            string Filename = GDefine.SetupPath + "\\Vision.Setup.ini";
            IniFile.Create(Filename);

            SettleTime = IniFile.ReadInteger("Vision", "SettleTime", 100);

            DistPerPixelX[0] = IniFile.ReadFloat("Vision", "DistPerPixelX_0", (float)0.001);
            DistPerPixelY[0] = IniFile.ReadFloat("Vision", "DistPerPixelY_0", (float)0.001);

            if (DistPerPixelX[0] == 0.001)
            {
                int i = 0;
                DistPerPixelX[i] = IniFile.ReadFloat("Vision", "DistPerPixelX", (float)0.001);
                DistPerPixelY[i] = IniFile.ReadFloat("Vision", "DistPerPixelY", (float)0.001);
            }
            for (int i = 1; i < TaskVision.MAX_CAMERA; i++)
            {
                DistPerPixelX[i] = IniFile.ReadFloat("Vision", "DistPerPixelX_" + i.ToString(), (float)0.001);
                DistPerPixelY[i] = IniFile.ReadFloat("Vision", "DistPerPixelY_" + i.ToString(), (float)0.001);
            }

            for (int i = 0; i < TaskVision.MAX_CAMERA; i++)
            {
                CalMode[i] = (ECalMode)IniFile.ReadInteger("Camera" + i.ToString(), "CalMode", (int)ECalMode.Ave_XY);

                ExposureTime[i] = IniFile.ReadFloat("Camera" + i.ToString(), "ExposureTime", 8.000f);
                Gain[i] = IniFile.ReadFloat("Camera" + i.ToString(), "Gain", 0);
            }
        }
        public static void SaveSetup()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            string Filename = GDefine.SetupPath + "\\Vision.Setup.ini";
            IniFile.Create(Filename);

            IniFile.WriteInteger("Vision", "SettleTime", SettleTime);
            for (int i = 0; i < TaskVision.MAX_CAMERA; i++)
            {
                IniFile.WriteFloat("Vision", "DistPerPixelX_" + i.ToString(), DistPerPixelX[i]);
                IniFile.WriteFloat("Vision", "DistPerPixelY_" + i.ToString(), DistPerPixelY[i]);
            }

            for (int i = 0; i < TaskVision.MAX_CAMERA; i++)
            {
                IniFile.WriteInteger("Camera" + i.ToString(), "CalMode", (int)CalMode[i]);

                IniFile.WriteFloat("Camera" + i.ToString(), "ExposureTime", ExposureTime[i]);
                IniFile.WriteFloat("Camera" + i.ToString(), "Gain", Gain[i]);
            }
        }

        public static bool OpenCamera(int CamNo)
        {
            string EMsg = "OpenCamera";

            switch (GDefine.CameraType[CamNo])
            {
                case GDefine.ECameraType.None: return true;
                case GDefine.ECameraType.Basler:
                case GDefine.ECameraType.PtGrey:
                case GDefine.ECameraType.Spinnaker:
                case GDefine.ECameraType.Spinnaker2:
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.CAMERA_DRIVER_NOT_SUPPORT);
                        return false;
                    }
                case GDefine.ECameraType.MVSGenTL:
                    {
                        try
                        {
                            if (!genTLCamera[CamNo].IsConnected)
                            {
                                //string ctifile = @"C:\Program Files (x86)\Common Files\MVS\Runtime\Win32_i86\MvProducerGEV.cti";
                                //string ctifile = @"C:\Program Files (x86)\FLIR Systems\Spinnaker\cti\vs2015\FLIR_GenTL_v140.cti";
                                //if (GDefine.CameraSerialNo[CamNo] != null && GDefine.CameraSerialNo[CamNo].Length > 0)
                                    //genTLCamera[CamNo].OpenDevice($"Cam{CamNo + 1}", GDefine.CameraSerialNo[CamNo], ctifile);
                                //else
                                    genTLCamera[CamNo].OpenDevice($"Cam{CamNo + 1}", GDefine.CameraIPAddress[CamNo]);

                                if (!genTLCamera[CamNo].IsConnected)
                                {
                                    Msg MsgBox = new Msg();
                                    int i_Err = 0;
                                    if (CamNo == 0) i_Err = ErrCode.CAMERA1_OPEN_ERR;
                                    if (CamNo == 1) i_Err = ErrCode.CAMERA2_OPEN_ERR;
                                    if (CamNo == 2) i_Err = ErrCode.CAMERA3_OPEN_ERR;

                                    EMsgRes MsgRes = MsgBox.Show(i_Err, EMcState.Error, EMsgBtn.smbOK_Cancel, false);
                                    if (MsgRes == EMsgRes.smrCancel)
                                    {
                                        Intf.Terminate = true;
                                    }

                                    genTLCamera[CamNo].CloseDevice();
                                    return false;
                                }

                                genTLCamera[CamNo].Exposure = ExposureTime[CamNo] * 1000;
                                genTLCamera[CamNo].Gain = Gain[CamNo];

                                genTLCamera[CamNo].GrabOneImage();
                                ImgHN[CamNo] = (int)genTLCamera[CamNo].ImageHeight;
                                ImgWN[CamNo] = (int)genTLCamera[CamNo].ImageWidth;
                                //genTLCamera[0].StartGrab();
                            }
                        }
                        catch (Exception Ex)
                        {
                            try
                            {
                                genTLCamera[CamNo].CloseDevice();
                            }
                            catch { }

                            EMsg = EMsg + Ex.Message;
                            Msg MsgBox = new Msg();
                            MsgBox.Show(ErrCode.CAMERA_COMM_EX_ERR, EMsg);
                            return false;
                        }
                        return true;
                    }
            }
            return false;
        }
        public static bool OpenCameras()
        {
            bool OK = true;
            for (int i = 0; i < MAX_CAMERA; i++)
            {
                if (!OpenCamera(i)) OK = false;
                if (Intf.Terminate) break;
            }
            return OK;
        }
        public static void CloseCamera(int CamNo)
        {
            if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker2)
            {
                flirCamera2[CamNo].DisConnect();
            }
            if (GDefine.CameraType[CamNo] == GDefine.ECameraType.MVSGenTL)
            {
                genTLCamera[CamNo].CloseDevice();
            }
        }
        public static void CloseCameras()
        {
            for (int i = 0; i < MAX_CAMERA; i++)
            {
                CloseCamera(i);
            }
        }

        public static bool CameraOpened(int CamNo)
        {
            if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker2)
            {
                return flirCamera2[CamNo].IsConnected;
            }
            if (GDefine.CameraType[CamNo] == GDefine.ECameraType.MVSGenTL)
            {
                return genTLCamera[CamNo].IsConnected;
            }

            return false;
        }
        public static bool CameraRun = true;

        static Mutex MutexGrab = new Mutex();
        public static int[] ImgWN = new int[MAX_CAMERA];
        public static int[] ImgHN = new int[MAX_CAMERA];
        static Bitmap bmp = null;

        public static Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>[] ImageT = new Image<Gray,byte>[3];

        public static bool GrabN(int CamNo, ref Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image)
        {
            if (GDefine.CameraType[CamNo] == GDefine.ECameraType.None)
            {
                Image = new Image<Gray, byte>(@"e:\Capture.png");
            }
            if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Basler)
            {
                //#region
                //if (!Basler.Initialized) return false;

                //MutexGrab.WaitOne();
                //try
                //{
                //    if (CameraN[CamNo].Grab())
                //    {
                //        CameraN[CamNo].ToBitmap(ref bmp);

                //        const int w = 659;
                //        const int h = 494;
                //        if (bmp.Width > w)
                //        {
                //            int x = (bmp.Width - w) / 2;
                //            int y = (bmp.Height - h) / 2;
                //            Image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(bmp).Copy(new Rectangle(x,y, w,h));
                //        }
                //        else
                //        Image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(bmp);

                        
                //        MutexGrab.ReleaseMutex();
                //    }
                //    else
                //    {
                //        Image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(480, 480, new Emgu.CV.Structure.Gray(128));
                //        throw new Exception("Grab Fail");
                //    }
                //}
                //catch
                //{
                //    Image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(480, 480, new Emgu.CV.Structure.Gray(128));
                //    MutexGrab.ReleaseMutex();
                //}
                //#endregion
            }
            if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker)
            {
                //Image = FlirCamera[CamNo].m_ImageEmgu.m_Image.Clone();
            }
            if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker2 || GDefine.CameraType[CamNo] is GDefine.ECameraType.MVSGenTL)
            {
                throw new Exception("TaskVision.GrabN funtion is not supported.");
            }
            return true;
        }

        //public static bool PtGrey_Connected(int CamNo)
        //{
        //    if (PGCamera[CamNo] == null) return false;

        //    return PGCamera[CamNo].IsConnected;
        //}
        //public static void PtGrey_CamStop()
        //{
        //    for (int i = 0; i < MAX_CAMERA; i++)
        //    {
        //        try
        //        {
        //            if (!PtGrey_Connected(i)) continue;
        //            if (PGCamera[i].IsGrabbing) PGCamera[i].StopGrab();
        //        }
        //        catch { throw; }
        //    }
        //}
        //public static void PtGrey_CamLive(int CamNo)
        //{
        //    try
        //    {
        //        for (int i = 0; i < MAX_CAMERA; i++)
        //        {
        //            if (!PtGrey_Connected(i)) continue;

        //            if (i != CamNo)
        //                if (PGCamera[i].IsGrabbing) PGCamera[i].StopGrab();
        //        }

        //        if (PGCamera[CamNo].TriggerMode || !PGCamera[CamNo].IsGrabbing)
        //        {
        //            PGCamera[CamNo].StopGrab();
        //            PGCamera[CamNo].TriggerMode = false;
        //            PGCamera[CamNo].SetProperty(PtGrey.TCamera.EProperty.FrameRate, true);
        //            PGCamera[CamNo].SetProperty(PtGrey.TCamera.EProperty.FrameRate, 30);
        //            PGCamera[CamNo].StartGrab();
        //        }
        //    }
        //    catch
        //    { throw; }
        //}
        //public static void PtGrey_CamArm(int CamNo)
        //{
        //    try
        //    {
        //        for (int i = 0; i < MAX_CAMERA; i++)
        //        {
        //            if (!PtGrey_Connected(i)) continue;

        //            if (i != CamNo)
        //                if (PGCamera[i].IsGrabbing) PGCamera[i].StopGrab();
        //        }

        //        if (!PGCamera[CamNo].TriggerMode || !PGCamera[CamNo].IsGrabbing)
        //        {
        //            PGCamera[CamNo].StopGrab();
        //            PGCamera[CamNo].TriggerMode = true;
        //            PGCamera[CamNo].StartGrab();
        //        }
        //    }
        //    catch
        //    { throw; }
        //}
        //public static void PtGrey_CamTrig(int CamNo)
        //{
        //    if (!PtGrey_Connected(CamNo)) return;
        //    PGCamera[CamNo].SoftTrigger();
        //}
        //public static void PtGrey_CamImage(int CamNo, ref Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image)
        //{
        //    PGCamera[CamNo].RetreiveBuffer();
        //    Image = PGCamera[CamNo].Image().ToImage<Gray, byte>();//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(PGCamera[CamNo].Image());
        //    fe.OnGrabbedEvent();
        //}
        
        public static bool Flir_Connected(int CamNo)
        {
            //if (FlirCamera[CamNo] == null) return false;

            //return FlirCamera[CamNo].IsConnected();
            return false;
        }
        public static void Flir_CamStop()
        {
            //for (int i = 0; i < MAX_CAMERA; i++)
            //{
            //    try
            //    {
            //        if (!Flir_Connected(i)) continue;
            //        if (FlirCamera[i].IsGrabbing()) FlirCamera[i].GrabStop();
            //    }
            //    catch { throw; }
            //}
        }
        public static void Flir_CamLive(int CamNo)
        {
            //try
            //{
            //    if (FlirCamera[CamNo] == null) return;

            //    for (int i = 0; i < MAX_CAMERA; i++)
            //    {
            //        if (!Flir_Connected(i)) continue;

            //        if (i != CamNo)
            //            if (FlirCamera[i].IsGrabbing()) FlirCamera[i].GrabStop();
            //    }

            //    if (!FlirCamera[CamNo].IsGrabbing())
            //    {
            //        FlirCamera[CamNo].Grab();
            //    }
            //}
            //catch
            //{ throw; }
        }

        public static void GrabGetFocusValue(ref uint FV)
        {
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> img = null;

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                TaskVision.flirCamera2[(int)ECamNo.Cam00].Snap();
                img = TaskVision.flirCamera2[(int)ECamNo.Cam00].m_ImageEmgu.m_Image.Clone();
            }
            else
            if (GDefine.CameraType[0] is GDefine.ECameraType.MVSGenTL)
            {
                genTLCamera[(int)ECamNo.Cam00].GrabOneImage();
                img = genTLCamera[(int)ECamNo.Cam00].mImage.Clone();
                if (TaskVision.frmMVCGenTLCamera.Visible) TaskVision.genTLCamera[(int)ECamNo.Cam00].StartGrab();
            }
            else
            {
                GrabN(0, ref img);
            }

            int W = 200;
                int H = 200;
            img.ROI = new Rectangle((img.Width - W) / 2, (img.Height - H) / 2, W, H);

            FV = NVision.Image.FocusValue(img);
        }

        public delegate void OnGrabbedEventHandler(object sender, EventArgs e);
        public class FEvent
        {
            public event OnGrabbedEventHandler GrabbedEvent;
            public void OnGrabbedEvent()
            {
                if (GrabbedEvent != null) GrabbedEvent(this, EventArgs.Empty);
            }
        }
        public static FEvent fe = new FEvent();

        private static void TaskVision_GrabbedEvent1(object sender, EventArgs e)
        {
            //if (PGCamera[0].TriggerMode)
            //{
            //    ImageT[0] = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(PGCamera[0].Image());
            //    TrigImageReady = true;
            //}
            fe.OnGrabbedEvent();
        }
        private static void TaskVision_GrabbedEvent2(object sender, EventArgs e)
        {
            //if (PGCamera[1].TriggerMode)
            //{
            //    ImageT[1] = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(PGCamera[1].Image());
            //    TrigImageReady = true;
            //}
            fe.OnGrabbedEvent();
        }
        private static void TaskVision_GrabbedEvent3(object sender, EventArgs e)
        {
            //if (PGCamera[2].TriggerMode)
            //{
            //    ImageT[2] = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(PGCamera[2].Image());
            //    TrigImageReady = true;
            //}
            fe.OnGrabbedEvent();
        }

        public const int MAX_REF_TEMPLATE = 16;
        public const int MAX_PAT = 4;
        public const int MAX_FOV = 100;
        public static VisUtils.EMatchTemplate UnitMarkTemplate = new VisUtils.EMatchTemplate();
        public static VisUtils.EMatchTemplate BdOrientTemplate = new VisUtils.EMatchTemplate();
        public static VisUtils.EMatchTemplate CreateMapTemplate = new VisUtils.EMatchTemplate();
        public static VisUtils.EMatchTemplate[,] RefTemplate = new VisUtils.EMatchTemplate[MAX_REF_TEMPLATE, MAX_PAT];

        public static TLightRGBA CurrentLightRGBA = new TLightRGBA();
        public static TLightRGBA DefLightRGB = new TLightRGBA();
        public static TLightRGBA Def2LightRGB = new TLightRGBA();
        public static TLightRGBA UnitMarkLightRGB = new TLightRGBA();
        public static TLightRGBA BdOrientLightRGB = new TLightRGBA();
        public static TLightRGBA BdCaptureLightRGB = new TLightRGBA();
        public static TLightRGBA Read2DLightRGB = new TLightRGBA();
        public static TLightRGBA[] LightRGB = new TLightRGBA[MAX_REF_TEMPLATE];

        public static bool SaveTemplates(string Path, string TemplateName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(Path, TemplateName + ".Lighting.ini");

            IniFile.WriteInteger("Reticles", "Count", Reticles.Count);
            for (int i = 0; i < MAX_RETICLE; i++)
            #region
            {
                IniFile.WriteInteger("Reticles" + i.ToString(), "Type", (int)Reticles.Type[i]);
                IniFile.WriteInteger("Reticles" + i.ToString(), "Color", Reticles.Color[i].ToArgb());
                IniFile.WriteInteger("Reticles" + i.ToString(), "X", Reticles.Rect[i].X);
                IniFile.WriteInteger("Reticles" + i.ToString(), "Y", Reticles.Rect[i].Y);
                IniFile.WriteInteger("Reticles" + i.ToString(), "W", Reticles.Rect[i].Width);
                IniFile.WriteInteger("Reticles" + i.ToString(), "H", Reticles.Rect[i].Height);
                IniFile.WriteString("Reticles" + i.ToString(), "Text", Reticles.Text[i]);
            }
            #endregion

            IniFile.WriteInteger("Def", "R", DefLightRGB.R);
            IniFile.WriteInteger("Def", "G", DefLightRGB.G);
            IniFile.WriteInteger("Def", "B", DefLightRGB.B);
            IniFile.WriteInteger("Def", "A", DefLightRGB.A);

            IniFile.WriteInteger("UnitMark", "R", UnitMarkLightRGB.R);
            IniFile.WriteInteger("UnitMark", "G", UnitMarkLightRGB.G);
            IniFile.WriteInteger("UnitMark", "B", UnitMarkLightRGB.B);
            IniFile.WriteInteger("UnitMark", "A", UnitMarkLightRGB.A);
            if (UnitMarkTemplate.Image != null)
                try
                {
                    UnitMarkTemplate.Save(Path, TemplateName + "_UnitMark");
                }
                catch { };

            IniFile.WriteInteger("BdOrient", "R", BdOrientLightRGB.R);
            IniFile.WriteInteger("BdOrient", "G", BdOrientLightRGB.G);
            IniFile.WriteInteger("BdOrient", "B", BdOrientLightRGB.B);
            IniFile.WriteInteger("BdOrient", "A", BdOrientLightRGB.A);
            if (BdOrientTemplate.Image != null)
                try
                {
                    BdOrientTemplate.Save(Path, TemplateName + "_BdOrient");
                }
                catch { };

            IniFile.WriteInteger("BdCapture", "R", BdCaptureLightRGB.R);
            IniFile.WriteInteger("BdCapture", "G", BdCaptureLightRGB.G);
            IniFile.WriteInteger("BdCapture", "B", BdCaptureLightRGB.B);
            IniFile.WriteInteger("BdCapture", "A", BdCaptureLightRGB.A);
            if (CreateMapTemplate.Image != null)
                try
                {
                    CreateMapTemplate.Save(Path, TemplateName + "_CreateMap");
                }
                catch { };

            IniFile.WriteInteger("ReadID", "R", Read2DLightRGB.R);
            IniFile.WriteInteger("ReadID", "G", Read2DLightRGB.G);
            IniFile.WriteInteger("ReadID", "B", Read2DLightRGB.B);
            IniFile.WriteInteger("ReadID", "A", Read2DLightRGB.A);

            for (int i = 0; i < MAX_REF_TEMPLATE; i++)
            {
                IniFile.WriteInteger(i.ToString(), "R", LightRGB[i].R);
                IniFile.WriteInteger(i.ToString(), "G", LightRGB[i].G);
                IniFile.WriteInteger(i.ToString(), "B", LightRGB[i].B);
                IniFile.WriteInteger(i.ToString(), "A", LightRGB[i].A);
            }

            for (int i = 0; i < MAX_REF_TEMPLATE; i++)
            {
                for (int j = 0; j < MAX_PAT; j++)
                {
                    try
                    {
                        RefTemplate[i, j].Save(Path, TemplateName + "_Ref" + i.ToString() + "_" + j.ToString());
                    }
                    catch { };
                }
            }

            return true;
        }
        public static bool LoadTemplates(string Path, string TemplateName)
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            IniFile.Create(Path, TemplateName + ".Lighting.ini");

            Reticles.Count = IniFile.ReadInteger("Reticles", "Count", 1);
            for (int i = 0; i < MAX_RETICLE; i++)
            #region
            {
                if (i == 0)
                {
                    Reticles.Type[i] = (EReticleType)IniFile.ReadInteger("Reticles" + i.ToString(), "Type", 1);
                    Reticles.Color[i] = Color.Lime;
                }
                else
                {
                    Reticles.Type[i] = (EReticleType)IniFile.ReadInteger("Reticles" + i.ToString(), "Type", 0);
                    int c = IniFile.ReadInteger("Reticles" + i.ToString(), "Color", 0);
                    Reticles.Color[i] = Color.FromArgb(c);
                }
                Reticles.Rect[i].X = IniFile.ReadInteger("Reticles" + i.ToString(), "X", 100);
                Reticles.Rect[i].Y = IniFile.ReadInteger("Reticles" + i.ToString(), "Y", 100);
                Reticles.Rect[i].Width = IniFile.ReadInteger("Reticles" + i.ToString(), "W", 100);
                Reticles.Rect[i].Height = IniFile.ReadInteger("Reticles" + i.ToString(), "H", 100);
                Reticles.Text[i] = IniFile.ReadString("Reticles" + i.ToString(), "Text", "");
            }
            #endregion

            DefLightRGB.R = IniFile.ReadInteger("Def", "R", 25);
            DefLightRGB.G = IniFile.ReadInteger("Def", "G", 0);
            DefLightRGB.B = IniFile.ReadInteger("Def", "B", 0);

            #region UnitMark
            UnitMarkLightRGB.R = IniFile.ReadInteger("UnitMark", "R", 25);
            UnitMarkLightRGB.G = IniFile.ReadInteger("UnitMark", "G", 0);
            UnitMarkLightRGB.B = IniFile.ReadInteger("UnitMark", "B", 0);
            UnitMarkLightRGB.A = IniFile.ReadInteger("UnitMark", "A", 0);
            string F = Path + "\\" + TemplateName + "_UnitMark" + ".bmp";
            if (File.Exists(F))
                try
                {
                    UnitMarkTemplate.Load(Path, TemplateName + "_UnitMark");
                }
                catch { };
            #endregion

            #region BdOrient
            BdOrientLightRGB.R = IniFile.ReadInteger("BdOrient", "R", 25);
            BdOrientLightRGB.G = IniFile.ReadInteger("BdOrient", "G", 0);
            BdOrientLightRGB.B = IniFile.ReadInteger("BdOrient", "B", 0);
            BdOrientLightRGB.A = IniFile.ReadInteger("BdOrient", "A", 0);
            F = Path + "\\" + TemplateName + "_BdOrient" + ".bmp";
            if (File.Exists(F))
                try
                {
                    BdOrientTemplate.Load(Path, TemplateName + "_BdOrient");
                }
                catch { };
            #endregion

            Read2DLightRGB.R = IniFile.ReadInteger("ReadID", "R", 0);
            Read2DLightRGB.G = IniFile.ReadInteger("ReadID", "G", 0);
            Read2DLightRGB.B = IniFile.ReadInteger("ReadID", "B", 0);
            Read2DLightRGB.A = IniFile.ReadInteger("ReadID", "A", 0);

            #region BdCapture, CreateMap
            BdCaptureLightRGB.R = IniFile.ReadInteger("BdCapture", "R", 25);
            BdCaptureLightRGB.G = IniFile.ReadInteger("BdCapture", "G", 0);
            BdCaptureLightRGB.B = IniFile.ReadInteger("BdCapture", "B", 0);
            BdCaptureLightRGB.A = IniFile.ReadInteger("BdCapture", "A", 0);
            F = Path + "\\" + TemplateName + "_CreateMap" + ".bmp";
            if (File.Exists(F))
                try
                {
                    CreateMapTemplate.Load(Path, TemplateName + "_CreateMap");
                }
                catch { };
            #endregion

            #region Ref
            for (int i = 0; i < MAX_REF_TEMPLATE; i++)
            {
                LightRGB[i].R = IniFile.ReadInteger(i.ToString(), "R", 25);
                LightRGB[i].G = IniFile.ReadInteger(i.ToString(), "G", 0);
                LightRGB[i].B = IniFile.ReadInteger(i.ToString(), "B", 0);
                LightRGB[i].A = IniFile.ReadInteger(i.ToString(), "A", 0);
            }

            for (int i = 0; i < MAX_REF_TEMPLATE; i++)
            {
                for (int j = 0; j < MAX_PAT; j++)
                {
                    try
                    {
                        F = Path + "\\" + TemplateName + "_Ref" + i.ToString() + "_" + j.ToString() + ".bmp";
                        if (File.Exists(F))
                            RefTemplate[i, j].Load(Path, TemplateName + "_Ref" + i.ToString() + "_" + j.ToString());

                        if (RefTemplate[i, j].PatternRoi.X == 0) RefTemplate[i, j].PatternRoi.X = 100;
                        if (RefTemplate[i, j].PatternRoi.Y == 0) RefTemplate[i, j].PatternRoi.Y = 100;
                        if (RefTemplate[i, j].PatternRoi.Width == 0) RefTemplate[i, j].PatternRoi.Width = 100;
                        if (RefTemplate[i, j].PatternRoi.Height == 0) RefTemplate[i, j].PatternRoi.Height = 100;

                        if (RefTemplate[i, j].SearchRoi.X == 0 && RefTemplate[i, j].SearchRoi.Y == 0 &&
                            RefTemplate[i, j].SearchRoi.Width == 0 && RefTemplate[i, j].SearchRoi.Height == 0)
                        {
                            RefTemplate[i, j].SearchRoi.X = 50;
                            RefTemplate[i, j].SearchRoi.Y = 50;
                            RefTemplate[i, j].SearchRoi.Width = 200;
                            RefTemplate[i, j].SearchRoi.Height = 200;
                        }
                    }
                    catch { };
                }
            }
            #endregion

            try
            {
                LightingOn(DefLightRGB);
            }
            catch { };
            return true;
        }

        public const int MAX_BOARD_ID = 16;
        public static Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>[] BoardImage = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>[MAX_BOARD_ID];
        public static int[] BoardImage_ID = new int[MAX_BOARD_ID];
        public static Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>[] PrevBoardImage = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>[MAX_BOARD_ID];
        public static int[] PrevBoardImage_ID = new int[MAX_BOARD_ID];

        public static Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> LoadedImageG = null;//image manual loaded loaded 

        public static bool SaveBoardImages(string Path, string Name)
        {
            for (int i = 0; i < MAX_BOARD_ID; i++)
            {
                if (BoardImage[i] != null)
                {
                    string Filename = Path + "\\" + Name + "_BoardImage_" + i.ToString() + ".bmp";
                    try
                    {
                        BoardImage[i].Save(Filename);
                    }
                    catch { }
                }
            }
            return true;
        }
        public static bool LoadBoardImages(string Path, string Name)
        {
            for (int i = 0; i < MAX_BOARD_ID; i++)
            {
                string Filename = Path + "\\" + Name + "_BoardImage_" + i.ToString() + ".bmp";
                if (File.Exists(Filename))
                {
                    try
                    {
                        BoardImage[i] = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(Filename);
                    }
                    catch { }
                }
                else
                    BoardImage[i] = null;
            }
            return true;
        }

        public static bool SaveTemplatesXML(XmlWriter writer)
        {
            writer.WriteStartElement("entry");
            writer.WriteAttributeString("name", "Recticle");
            DispProg.WriteSubEntry(writer, "Count", Reticles.Count);
            writer.WriteEndElement();//end entry

            for (int i = 0; i < MAX_RETICLE; i++)
            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "Recticle" + i.ToString());
                DispProg.WriteSubEntry(writer, "Type", (int)Reticles.Type[i]);
                DispProg.WriteSubEntry(writer, "Color", Reticles.Color[i].ToArgb());
                int[] rect = new int[4] { Reticles.Rect[i].X, Reticles.Rect[i].Y, Reticles.Rect[i].Width, Reticles.Rect[i].Height };
                DispProg.WriteSubEntry(writer, "Para", rect);
                DispProg.WriteSubEntry(writer, "Text", Reticles.Text[i]);
                writer.WriteEndElement();//end entry
            }

            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "Def");
                int[] intArr = new int[4];
                intArr = new int[4] { DefLightRGB.R, DefLightRGB.G, DefLightRGB.B, DefLightRGB.A };
                DispProg.WriteSubEntry(writer, "Lighting", intArr);
                writer.WriteEndElement();//end entry
            }

            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "Def2");
                int[] intArr = new int[4];
                intArr = new int[4] { Def2LightRGB.R, Def2LightRGB.G, Def2LightRGB.B, Def2LightRGB.A };
                DispProg.WriteSubEntry(writer, "Lighting", intArr);
                writer.WriteEndElement();//end entry
            }

            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "UnitMark");
                int[] intArr = new int[4];
                intArr = new int[4] { UnitMarkLightRGB.R, UnitMarkLightRGB.G, UnitMarkLightRGB.B, UnitMarkLightRGB.A };
                DispProg.WriteSubEntry(writer, "Lighting", intArr);

                try
                {
                    UnitMarkTemplate.SaveXML(writer);
                }
                catch { };

                writer.WriteEndElement();//end entry
            }

            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "BdOrient");
                int[] intArr = new int[4];
                intArr = new int[4] { UnitMarkLightRGB.R, UnitMarkLightRGB.G, UnitMarkLightRGB.B, UnitMarkLightRGB.A };
                DispProg.WriteSubEntry(writer, "Lighting", intArr);

                try
                {
                    BdOrientTemplate.SaveXML(writer);
                }
                catch { };

                writer.WriteEndElement();//end entry
            }

            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "BdCapture");
                int[] intArr = new int[4];
                intArr = new int[4] { BdCaptureLightRGB.R, BdCaptureLightRGB.G, BdCaptureLightRGB.B, BdCaptureLightRGB.A };
                DispProg.WriteSubEntry(writer, "Lighting", intArr);
                writer.WriteEndElement();//end entry
            }

            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "Read2D");
                int[] intArr = new int[4];
                intArr = new int[4] { Read2DLightRGB.R, Read2DLightRGB.G, Read2DLightRGB.B, Read2DLightRGB.A };
                DispProg.WriteSubEntry(writer, "Lighting", intArr);
                writer.WriteEndElement();//end entry
            }

            for (int i = 0; i < MAX_REF_TEMPLATE; i++)
            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "Ref" + i.ToString());
                int[] intArr = new int[4];
                intArr = new int[4] { LightRGB[i].R, LightRGB[i].G, LightRGB[i].B, LightRGB[i].A };
                DispProg.WriteSubEntry(writer, "Lighting", intArr);
                writer.WriteEndElement();//end entry
            }

            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "BoardImage");
                for (int i = 0; i < MAX_BOARD_ID; i++)
                {
                    Bitmap bmp = null;
                    try
                    {
                        if (BoardImage[i] != null) bmp = BoardImage[i].ToBitmap();
                        DispProg.WriteSubEntry(writer, i.ToString(), bmp);
                    }
                    finally
                    {
                        if (bmp != null) bmp.Dispose();
                    }
                }
                writer.WriteEndElement();//end entry
            }

            {
                writer.WriteStartElement("entry");
                writer.WriteAttributeString("name", "CreateMap");
                try
                {
                    CreateMapTemplate.SaveXML(writer);
                }
                catch { };
                writer.WriteEndElement();//end entry
            }


            for (int i = 0; i < MAX_REF_TEMPLATE; i++)
            {
                for (int j = 0; j < MAX_PAT; j++)
                {
                    writer.WriteStartElement("entry");
                    writer.WriteAttributeString("name", "Ref" + i.ToString() + "_" + j.ToString());
                    try
                    {
                        RefTemplate[i, j].SaveXML(writer);
                    }
                    catch { };
                    writer.WriteEndElement();//end entry
                }
            }

            return true;
        }
        private static void ReadReticleSubEntries(XmlReader reader, int iRetNo)
        {
            while (reader.Read())
            {
                if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                if (reader.Name == "subentry")
                {
                    string attName = reader["name"];

                    switch (attName)
                    {
                        case "Type":
                            Reticles.Type[iRetNo] = EReticleType.None;
                            int i = DispProg.ReadSubEntry(reader, 0);
                            try
                            {
                                Reticles.Type[iRetNo] = (EReticleType)i;
                            }
                            catch { };

                            if (iRetNo == 0 && Reticles.Type[iRetNo] == EReticleType.None)
                            {
                                Reticles.Type[iRetNo] = EReticleType.CenterCrossHair;
                            }

                            break;
                        case "Color":
                            int c = DispProg.ReadSubEntry(reader, 0);
                            Reticles.Color[iRetNo] = Color.FromArgb(c);
                            if (iRetNo == 0 && c == 0)
                            {
                                Reticles.Color[iRetNo] = Color.Lime;
                            }
                            break;
                        case "Para":
                            int[] intArr = new int[4] { 100, 100, 100, 100 };
                            intArr = DispProg.ReadSubEntry(reader, intArr);
                            Reticles.Rect[iRetNo].X = intArr[0];
                            Reticles.Rect[iRetNo].Y = intArr[1];
                            Reticles.Rect[iRetNo].Width = intArr[2];
                            Reticles.Rect[iRetNo].Height = intArr[3];
                            break;
                        case "Text":
                            Reticles.Text[iRetNo] = DispProg.ReadSubEntry(reader, "");
                            break;
                    }
                }
            }
        }
        private static void ReadLightingSubEntry(XmlReader reader, int iNo)
        {
            while (reader.Read())
            {
                if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                if (reader.Name == "subentry")
                {
                    string attName = reader["name"];

                    switch (attName)
                    {
                        case "Lighting":
                            int[] intArr = new int[4] { 25, 0, 0, 0 };
                            intArr = DispProg.ReadSubEntry(reader, intArr);
                            LightRGB[iNo].R = intArr[0];
                            LightRGB[iNo].G = intArr[1];
                            LightRGB[iNo].B = intArr[2];
                            LightRGB[iNo].A = intArr[3];
                            break;
                    }
                }
            }
        }
        public static bool LoadTemplatesXML(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "section" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                if (reader.Name == "entry" && reader["name"] == "Recticle")
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                        if (reader.Name == "subentry")
                        {
                            string attName = reader["name"];

                            switch (attName)
                            {
                                case "Count":
                                    Reticles.Count = DispProg.ReadSubEntry(reader, 1); break;
                            }
                        }
                    }
                }

                    if (reader.Name == "entry" && reader["name"] == "Recticle0") ReadReticleSubEntries(reader, 0);
                    if (reader.Name == "entry" && reader["name"] == "Recticle1") ReadReticleSubEntries(reader, 1);
                if (reader.Name == "entry" && reader["name"] == "Recticle2") ReadReticleSubEntries(reader, 2);
                if (reader.Name == "entry" && reader["name"] == "Recticle3") ReadReticleSubEntries(reader, 3);
                if (reader.Name == "entry" && reader["name"] == "Recticle4") ReadReticleSubEntries(reader, 4);
                if (reader.Name == "entry" && reader["name"] == "Recticle5") ReadReticleSubEntries(reader, 5);
                if (reader.Name == "entry" && reader["name"] == "Recticle6") ReadReticleSubEntries(reader, 6);
                if (reader.Name == "entry" && reader["name"] == "Recticle7") ReadReticleSubEntries(reader, 7);
                if (reader.Name == "entry" && reader["name"] == "Recticle8") ReadReticleSubEntries(reader, 8);
                if (reader.Name == "entry" && reader["name"] == "Recticle9") ReadReticleSubEntries(reader, 9);

                if (reader.Name == "entry" && reader["name"] == "Def")
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                        if (reader.Name == "subentry")
                        {
                            string attName = reader["name"];

                            switch (attName)
                            {
                                case "Lighting":
                                    int[] intArr = new int[4] { 25, 0, 0, 0 };
                                    intArr = DispProg.ReadSubEntry(reader, intArr);
                                    DefLightRGB.R = intArr[0];
                                    DefLightRGB.G = intArr[1];
                                    DefLightRGB.B = intArr[2];
                                    DefLightRGB.A = intArr[3];
                                    break;
                            }
                        }
                    }
                }

                if (reader.Name == "entry" && reader["name"] == "Def2")
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                        if (reader.Name == "subentry")
                        {
                            string attName = reader["name"];

                            switch (attName)
                            {
                                case "Lighting":
                                    int[] intArr = new int[4] { 25, 0, 0, 0 };
                                    intArr = DispProg.ReadSubEntry(reader, intArr);
                                    Def2LightRGB.R = intArr[0];
                                    Def2LightRGB.G = intArr[1];
                                    Def2LightRGB.B = intArr[2];
                                    Def2LightRGB.A = intArr[3];
                                    break;
                            }
                        }
                    }
                }

                if (reader.Name == "entry" && reader["name"] == "UnitMark")
                    UnitMarkTemplate.LoadXML(reader, ref UnitMarkLightRGB);

                if (reader.Name == "entry" && reader["name"] == "BdOrient")
                    BdOrientTemplate.LoadXML(reader, ref BdOrientLightRGB);

                if (reader.Name == "entry" && reader["name"] == "BdCapture")
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                        if (reader.Name == "subentry")
                        {
                            string attName = reader["name"];

                            switch (attName)
                            {
                                case "Lighting":
                                    int[] intArr = new int[4] { 25, 0, 0, 0 };
                                    intArr = DispProg.ReadSubEntry(reader, intArr);
                                    BdCaptureLightRGB.R = intArr[0];
                                    BdCaptureLightRGB.G = intArr[1];
                                    BdCaptureLightRGB.B = intArr[2];
                                    BdCaptureLightRGB.A = intArr[3];
                                    break;
                            }
                        }
                    }
                }

                if (reader.Name == "entry" && reader["name"] == "BoardImage")
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                        if (reader.Name == "subentry")
                        {
                            int iNo = -1;
                            string attName = reader["name"];

                            try
                            {
                                iNo = int.Parse(attName);
                            }
                            catch { };

                            if (iNo >= 0)
                            {
                                try
                                {
                                    Bitmap bmp = null;
                                    bmp = DispProg.ReadSubEntry(reader, bmp);
                                    BoardImage[iNo] = null;
                                    if (bmp != null) BoardImage[iNo] = bmp.ToImage<Gray, byte>();//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(bmp);
                                }
                                finally
                                {
                                    if (bmp != null) bmp.Dispose();
                                }
                                break;
                            }
                        }
                    }
                }

                if (reader.Name == "entry" && reader["name"] == "CreateMap")
                    CreateMapTemplate.LoadXML(reader);

                if (reader.Name == "entry" && reader["name"] == "Read2D")
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                        if (reader.Name == "subentry")
                        {
                            string attName = reader["name"];

                            switch (attName)
                            {
                                case "Lighting":
                                    int[] intArr = new int[4] { 25, 0, 0, 0 };
                                    intArr = DispProg.ReadSubEntry(reader, intArr);
                                    Read2DLightRGB.R = intArr[0];
                                    Read2DLightRGB.G = intArr[1];
                                    Read2DLightRGB.B = intArr[2];
                                    Read2DLightRGB.A = intArr[3];
                                    break;
                            }
                        }
                    }
                }

                if (reader.Name == "entry" && reader["name"] == "Ref0") ReadLightingSubEntry(reader, 0);
                if (reader.Name == "entry" && reader["name"] == "Ref1") ReadLightingSubEntry(reader, 1);
                if (reader.Name == "entry" && reader["name"] == "Ref2") ReadLightingSubEntry(reader, 2);
                if (reader.Name == "entry" && reader["name"] == "Ref3") ReadLightingSubEntry(reader, 3);
                if (reader.Name == "entry" && reader["name"] == "Ref4") ReadLightingSubEntry(reader, 4);
                if (reader.Name == "entry" && reader["name"] == "Ref5") ReadLightingSubEntry(reader, 5);
                if (reader.Name == "entry" && reader["name"] == "Ref6") ReadLightingSubEntry(reader, 6);
                if (reader.Name == "entry" && reader["name"] == "Ref7") ReadLightingSubEntry(reader, 7);
                if (reader.Name == "entry" && reader["name"] == "Ref8") ReadLightingSubEntry(reader, 8);
                if (reader.Name == "entry" && reader["name"] == "Ref9") ReadLightingSubEntry(reader, 9);
                if (reader.Name == "entry" && reader["name"] == "Ref10") ReadLightingSubEntry(reader, 10);
                if (reader.Name == "entry" && reader["name"] == "Ref11") ReadLightingSubEntry(reader, 11);
                if (reader.Name == "entry" && reader["name"] == "Ref12") ReadLightingSubEntry(reader, 12);
                if (reader.Name == "entry" && reader["name"] == "Ref13") ReadLightingSubEntry(reader, 13);
                if (reader.Name == "entry" && reader["name"] == "Ref14") ReadLightingSubEntry(reader, 14);
                if (reader.Name == "entry" && reader["name"] == "Ref15") ReadLightingSubEntry(reader, 15);

                if (reader.Name == "entry" && reader["name"] == "Ref0_0") RefTemplate[0, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref0_1") RefTemplate[0, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref0_2") RefTemplate[0, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref0_3") RefTemplate[0, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref1_0") RefTemplate[1, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref1_1") RefTemplate[1, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref1_2") RefTemplate[1, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref1_3") RefTemplate[1, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref2_0") RefTemplate[2, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref2_1") RefTemplate[2, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref2_2") RefTemplate[2, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref2_3") RefTemplate[2, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref3_0") RefTemplate[3, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref3_1") RefTemplate[3, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref3_2") RefTemplate[3, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref3_3") RefTemplate[3, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref4_0") RefTemplate[4, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref4_1") RefTemplate[4, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref4_2") RefTemplate[4, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref4_3") RefTemplate[4, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref5_0") RefTemplate[5, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref5_1") RefTemplate[5, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref5_2") RefTemplate[5, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref5_3") RefTemplate[5, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref6_0") RefTemplate[6, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref6_1") RefTemplate[6, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref6_2") RefTemplate[6, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref6_3") RefTemplate[6, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref7_0") RefTemplate[7, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref7_1") RefTemplate[7, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref7_2") RefTemplate[7, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref7_3") RefTemplate[7, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref8_0") RefTemplate[8, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref8_1") RefTemplate[8, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref8_2") RefTemplate[8, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref8_3") RefTemplate[8, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref9_0") RefTemplate[9, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref9_1") RefTemplate[9, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref9_2") RefTemplate[9, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref9_3") RefTemplate[9, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref10_0") RefTemplate[10, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref10_1") RefTemplate[10, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref10_2") RefTemplate[10, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref10_3") RefTemplate[10, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref11_0") RefTemplate[11, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref11_1") RefTemplate[11, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref11_2") RefTemplate[11, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref11_3") RefTemplate[11, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref12_0") RefTemplate[12, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref12_1") RefTemplate[12, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref12_2") RefTemplate[12, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref12_3") RefTemplate[12, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref13_0") RefTemplate[13, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref13_1") RefTemplate[13, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref13_2") RefTemplate[13, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref13_3") RefTemplate[13, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref14_0") RefTemplate[14, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref14_1") RefTemplate[14, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref14_2") RefTemplate[14, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref14_3") RefTemplate[14, 3].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref15_0") RefTemplate[15, 0].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref15_1") RefTemplate[15, 1].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref15_2") RefTemplate[15, 2].LoadXML(reader);
                if (reader.Name == "entry" && reader["name"] == "Ref15_3") RefTemplate[15, 3].LoadXML(reader);
            }
        

            return true;
        }


        public static void TaskVisionInit()
        {
            try
            {
                for (int i = 0; i < MAX_CAMERA; i++)
                {
                    //CameraN[i] = new Basler.TCamera();
                }
            }
            catch { throw; }

            try
            {
                for (int i = 0; i < MAX_REF_TEMPLATE; i++)
                {
                    for (int j = 0; j < MAX_PAT; j++)
                    {
                        RefTemplate[i, j] = new VisUtils.EMatchTemplate();
                    }
                }
            }
            catch { throw; }
        }

        public static bool CalVisionXY(ECamNo CamID)
        {
            string EMsg = "CalVision";

            SelectedCam = CamID;

            try
            {
                if (!Application.ExecutablePath.Contains("Debug"))
                    if (!TaskDisp.TaskMoveGZFocus(0)) return false;

                switch (CalMode[(int)CamID])
                {
                    case ECalMode.Ave_XY:
                    case ECalMode.Only_X:
                    case ECalMode.Only_Y:
                        {
                            #region
                            double NewDistPerPixelX = 0;
                            double NewDistPerPixelY = 0;
                            if (TaskVision.CalMode[(int)CamID] == ECalMode.Ave_XY)
                            {
                                #region
                                #region Step 1 - TL
                                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                //    TaskVision.frmGenImageView.Reticles.Clear();
                                //    NImager.TReticle Reticle = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(50, 50), new SizeF(100, 100), Color.Green);
                                //    TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                //    Reticle = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(50, 50), new SizeF(100, 100), Color.Green, "TL");
                                //    TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                //    TaskVision.frmGenImageView.EnableReticles = true;

                                //    TaskVision.frmGenImageView.SelectIndex((int)CamID);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(50, 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(50, 50), new SizeF(25, 25), Color.Green, "TL");
                                    frm.frmCamera.ShowCamReticles = false;
                                    frm.frmCamera.ShowReticles = true;
                                    frm.frmCamera.Reticles = reticles;
                                    frm.frmCamera.SelectCamera(0);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(50, 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(50, 50), new SizeF(25, 25), Color.Green, "TL");
                                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                                    TaskVision.frmMVCGenTLCamera.ShowReticles = true;
                                    TaskVision.frmMVCGenTLCamera.Reticles = reticles;
                                    TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                                }
                                else
                                {
                                    frm.PageVision.SelectedCam = CamID;
                                    frm.ShowVision = true;
                                    DrawCalStep = ECalStepCHair.TL;
                                }
                                frm.Inst = "Step 1/4: Jog Crosshair " + DrawCalStep.ToString() + " to a Ref Point";
                                DialogResult dr = frm.ShowDialog();

                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                }

                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }

                                double X1 = TaskGantry.GXPos();
                                double Y1 = TaskGantry.GYPos();
                                #endregion

                                #region Step 2 - TR
                                frm = new frm_DispCore_JogGantryVision();
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                    //NImager.TReticle Reticle = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, 50), new SizeF(100, 100), Color.Green);
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //Reticle = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(ImgWN[(int)CamID] - 50, 50), new SizeF(100, 100), Color.Green, "TR");
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //TaskVision.frmGenImageView.EnableReticles = true;
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] - 50, 50), new SizeF(25, 25), Color.Green, "TR");
                                    frm.frmCamera.ShowCamReticles = false;
                                    frm.frmCamera.ShowReticles = true;
                                    frm.frmCamera.Reticles = reticles;
                                    frm.frmCamera.SelectCamera(0);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] - 50, 50), new SizeF(25, 25), Color.Green, "TR");
                                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                                    TaskVision.frmMVCGenTLCamera.ShowReticles = true;
                                    TaskVision.frmMVCGenTLCamera.Reticles = reticles;
                                    TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                                }
                                else
                                {
                                    frm.ShowVision = true;
                                    DrawCalStep = ECalStepCHair.TR;
                                }
                                frm.Inst = "Step 2/4: Jog Crosshair " + DrawCalStep.ToString() + " to same Ref Point";
                                dr = frm.ShowDialog();

                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                }
                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }
                                double X2 = TaskGantry.GXPos();
                                double Y2 = TaskGantry.GYPos();
                                #endregion

                                #region Step 3 - BR
                                frm = new frm_DispCore_JogGantryVision();
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                    //NImager.TReticle Reticle = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //Reticle = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green, "BR");
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //TaskVision.frmGenImageView.EnableReticles = true;
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] - 50), new SizeF(25, 25), Color.Green, "BR");
                                    frm.frmCamera.ShowCamReticles = false;
                                    frm.frmCamera.ShowReticles = true;
                                    frm.frmCamera.Reticles = reticles;
                                    frm.frmCamera.SelectCamera(0);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] - 50), new SizeF(25, 25), Color.Green, "BR");
                                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                                    TaskVision.frmMVCGenTLCamera.ShowReticles = true;
                                    TaskVision.frmMVCGenTLCamera.Reticles = reticles;
                                    TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                                }
                                else
                                {
                                    frm.ShowVision = true;
                                    DrawCalStep = ECalStepCHair.BR;
                                }
                                frm.Inst = "Step 3/4: Jog Crosshair " + DrawCalStep.ToString() + " to same Ref Point";
                                dr = frm.ShowDialog();

                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                }

                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }
                                double X3 = TaskGantry.GXPos();
                                double Y3 = TaskGantry.GYPos();
                                #endregion

                                #region Step 4- BL
                                frm = new frm_DispCore_JogGantryVision();
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                    //NImager.TReticle Reticle = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(50, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //Reticle = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(50, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green, "BL");
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //TaskVision.frmGenImageView.EnableReticles = true;
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(50, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(50, ImgHN[(int)CamID] - 50), new SizeF(25, 25), Color.Green, "BL");
                                    frm.frmCamera.ShowCamReticles = false;
                                    frm.frmCamera.ShowReticles = true;
                                    frm.frmCamera.Reticles = reticles;
                                    frm.frmCamera.SelectCamera(0);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(50, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(50, ImgHN[(int)CamID] - 50), new SizeF(25, 25), Color.Green, "BL");
                                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                                    TaskVision.frmMVCGenTLCamera.ShowReticles = true;
                                    TaskVision.frmMVCGenTLCamera.Reticles = reticles;
                                    TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                                }
                                else
                                {
                                    frm.ShowVision = true;
                                    DrawCalStep = ECalStepCHair.BL;
                                }
                                frm.Inst = "Step 4/4: Jog Crosshair " + DrawCalStep.ToString() + " to same Ref Point";
                                frm.ShowDialog();

                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                }

                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }
                                double X4 = TaskGantry.GXPos();
                                double Y4 = TaskGantry.GYPos();
                                #endregion

                                #region Computation
                                int CalPixelX = TaskVision.ImgWN[(int)CamID] - 100;
                                int CalPixelY = TaskVision.ImgHN[(int)CamID] - 100;

                                double X = (X2 - X1 + X3 - X4) / 2;
                                double Y = (Y4 - Y1 + Y3 - Y2) / 2;

                                NewDistPerPixelX = (double)(X / CalPixelX);
                                NewDistPerPixelY = (double)(Y / CalPixelY);
                                NewDistPerPixelX = Math.Abs(NewDistPerPixelX);
                                NewDistPerPixelY = Math.Abs(NewDistPerPixelY);
                                #endregion
                                #endregion
                            }
                            if (TaskVision.CalMode[(int)CamID] == ECalMode.Only_X)
                            {
                                #region Step 1 - L
                                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                if (GDefine.CameraType[(int)CamID] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                    //NImager.TReticle Reticle = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(50, ImgHN[(int)CamID] / 2), new SizeF(100, 100), Color.Green);
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //Reticle = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(50, ImgHN[(int)CamID]/2), new SizeF(100, 100), Color.Green, "CL");
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //TaskVision.frmGenImageView.EnableReticles = true;

                                    //TaskVision.frmGenImageView.SelectIndex((int)CamID);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(50, ImgHN[(int)CamID] / 2), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(50, ImgHN[(int)CamID] / 2), new SizeF(25, 25), Color.Green, "CL");
                                    frm.frmCamera.ShowCamReticles = false;
                                    frm.frmCamera.ShowReticles = true;
                                    frm.frmCamera.Reticles = reticles;
                                    frm.frmCamera.SelectCamera((int)CamID);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(50, ImgHN[(int)CamID] / 2), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(50, ImgHN[(int)CamID] / 2), new SizeF(25, 25), Color.Green, "CL");
                                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                                    TaskVision.frmMVCGenTLCamera.ShowReticles = true;
                                    TaskVision.frmMVCGenTLCamera.Reticles = reticles;
                                    TaskVision.frmMVCGenTLCamera.SelectCamera((int)CamID);
                                }
                                else
                                {
                                    frm.PageVision.SelectedCam = CamID;
                                    frm.ShowVision = true;
                                    DrawCalStep = ECalStepCHair.L;
                                }

                                frm.Inst = "Step 1/2: Jog Crosshair " + DrawCalStep.ToString() + " to a Ref Point";
                                DialogResult dr = frm.ShowDialog();

                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                }
                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }

                                double X1 = TaskGantry.GXPos();
                                double Y1 = TaskGantry.GYPos();
                                #endregion

                                #region Step 2 - R
                                frm = new frm_DispCore_JogGantryVision();
                                if (GDefine.CameraType[(int)CamID] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                    //NImager.TReticle Reticle = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] / 2), new SizeF(100, 100), Color.Green);
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //Reticle = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID]/2), new SizeF(100, 100), Color.Green, "CR");
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //TaskVision.frmGenImageView.EnableReticles = true;

                                    //TaskVision.frmGenImageView.SelectIndex((int)CamID);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] / 2), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] / 2), new SizeF(25, 25), Color.Green, "CR");
                                    frm.frmCamera.ShowCamReticles = false;
                                    frm.frmCamera.ShowReticles = true;
                                    frm.frmCamera.Reticles = reticles;
                                    frm.frmCamera.SelectCamera((int)CamID);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] / 2), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] - 50, ImgHN[(int)CamID] / 2), new SizeF(25, 25), Color.Green, "CR");
                                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                                    TaskVision.frmMVCGenTLCamera.ShowReticles = true;
                                    TaskVision.frmMVCGenTLCamera.Reticles = reticles;
                                    TaskVision.frmMVCGenTLCamera.SelectCamera((int)CamID);
                                }
                                else
                                {
                                    frm.ShowVision = true;
                                    DrawCalStep = ECalStepCHair.R;
                                }
                                frm.Inst = "Step 2/2: Jog Crosshair " + DrawCalStep.ToString() + " to same Ref Point";
                                dr = frm.ShowDialog();

                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                }

                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }
                                double X2 = TaskGantry.GXPos();
                                double Y2 = TaskGantry.GYPos();
                                #endregion

                                #region Computation
                                int CalPixelX = TaskVision.ImgWN[(int)CamID] - 100;
                                int CalPixelY = TaskVision.ImgHN[(int)CamID] - 100;

                                double X = Math.Abs(X2 - X1);
                                double Y = Math.Abs(Y2 - Y1);

                                double NewDistPerPixel = 0;
                                if (Y > X)//camera rotate 90 deg
                                {
                                    NewDistPerPixel = (double)(Y / CalPixelX);
                                }
                                else
                                {
                                    NewDistPerPixel = (double)(X / CalPixelX);
                                }

                                NewDistPerPixelX = Math.Abs(NewDistPerPixel);
                                NewDistPerPixelY = Math.Abs(NewDistPerPixel);
                                #endregion
                            }
                            if (TaskVision.CalMode[(int)CamID] == ECalMode.Only_Y)
                            {
                                #region Step 1 - T
                                frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                                if (GDefine.CameraType[(int)CamID] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                    //NImager.TReticle Reticle = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(ImgWN[(int)CamID] / 2, 50), new SizeF(100, 100), Color.Green);
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //Reticle = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(ImgWN[(int)CamID] / 2, 50), new SizeF(100, 100), Color.Green, "CT");
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //TaskVision.frmGenImageView.EnableReticles = true;

                                    //TaskVision.frmGenImageView.SelectIndex((int)CamID);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] / 2, 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] / 2, 50), new SizeF(25, 25), Color.Green, "CT");
                                    frm.frmCamera.ShowCamReticles = false;
                                    frm.frmCamera.ShowReticles = true;
                                    frm.frmCamera.Reticles = reticles;
                                    frm.frmCamera.SelectCamera((int)CamID);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] / 2, 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] / 2, 50), new SizeF(25, 25), Color.Green, "CT");
                                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                                    TaskVision.frmMVCGenTLCamera.ShowReticles = true;
                                    TaskVision.frmMVCGenTLCamera.Reticles = reticles;
                                    TaskVision.frmMVCGenTLCamera.SelectCamera((int)CamID);
                                }
                                else
                                {
                                    frm.PageVision.SelectedCam = CamID;
                                    frm.ShowVision = true;
                                    DrawCalStep = ECalStepCHair.T;
                                }
                                frm.Inst = "Step 1/2: Jog Crosshair " + DrawCalStep.ToString() + " to a Ref Point";
                                DialogResult dr = frm.ShowDialog();

                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                }
                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }

                                double X1 = TaskGantry.GXPos();
                                double Y1 = TaskGantry.GYPos();
                                #endregion

                                #region Step 2 - B
                                frm = new frm_DispCore_JogGantryVision();
                                if (GDefine.CameraType[(int)CamID] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                    //NImager.TReticle Reticle = new NImager.TReticle(NImager.TReticle.EType.Cross, new PointF(ImgWN[(int)CamID] / 2, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //Reticle = new NImager.TReticle(NImager.TReticle.EType.Text, new PointF(ImgWN[(int)CamID] / 2, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green, "CB");
                                    //TaskVision.frmGenImageView.Reticles.Add(Reticle);
                                    //TaskVision.frmGenImageView.EnableReticles = true;

                                    //TaskVision.frmGenImageView.SelectIndex((int)CamID);
                                }
                                else
                                                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] / 2, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] / 2, ImgHN[(int)CamID] - 50), new SizeF(25, 25), Color.Green, "CB");
                                    frm.frmCamera.ShowCamReticles = false;
                                    frm.frmCamera.ShowReticles = true;
                                    frm.frmCamera.Reticles = reticles;
                                    frm.frmCamera.SelectCamera((int)CamID);
                                }
                                else
                                if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
                                {
                                    TReticles reticles = new TReticles();
                                    reticles.Reticle[0] = new TReticle2(TReticle2.EType.Cross, new PointF(ImgWN[(int)CamID] / 2, ImgHN[(int)CamID] - 50), new SizeF(100, 100), Color.Green);
                                    reticles.Reticle[1] = new TReticle2(TReticle2.EType.Text, new PointF(ImgWN[(int)CamID] / 2, ImgHN[(int)CamID] - 50), new SizeF(25, 25), Color.Green, "CB");
                                    TaskVision.frmMVCGenTLCamera.ShowCamReticles = false;
                                    TaskVision.frmMVCGenTLCamera.ShowReticles = true;
                                    TaskVision.frmMVCGenTLCamera.Reticles = reticles;
                                    TaskVision.frmMVCGenTLCamera.SelectCamera((int)CamID);
                                }
                                else
                                {
                                    frm.ShowVision = true;
                                    DrawCalStep = ECalStepCHair.B;
                                }
                                frm.Inst = "Step 2/2: Jog Crosshair " + DrawCalStep.ToString() + " to same Ref Point";
                                dr = frm.ShowDialog();

                                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
                                {
                                    //TaskVision.frmGenImageView.Reticles.Clear();
                                }
                                if (dr == DialogResult.Cancel)
                                {
                                    return false;
                                }
                                double X2 = TaskGantry.GXPos();
                                double Y2 = TaskGantry.GYPos();
                                #endregion

                                #region Computation
                                int CalPixelX = TaskVision.ImgWN[(int)CamID] - 100;
                                int CalPixelY = TaskVision.ImgHN[(int)CamID] - 100;

                                double X = Math.Abs(X2 - X1);
                                double Y = Math.Abs(Y2 - Y1);

                                double NewDistPerPixel = 0;
                                if (X > Y)//camera rotate 90 deg
                                {
                                    NewDistPerPixel = (double)(X / CalPixelY);
                                }
                                else
                                {
                                    NewDistPerPixel = (double)(Y / CalPixelY);
                                }

                                NewDistPerPixelX = Math.Abs(NewDistPerPixel);
                                NewDistPerPixelY = Math.Abs(NewDistPerPixel);
                                #endregion
                            }

                            DrawCalStep = ECalStepCHair.None;

                            Msg MsgBox = new Msg();
                            EMsgRes MsgRes = MsgBox.Show("Cal Vision " + CalMode[(int)CamID].ToString() + " Completed. Cal Mode.@" +
                                     "Old DistPerPixel = " + DistPerPixelX[(int)CamID].ToString("F6") + "," + DistPerPixelX[(int)CamID].ToString("F6") + "@" +
                                     "New DistPerPixel = " + NewDistPerPixelX.ToString("F6") + "," + NewDistPerPixelY.ToString("F6") + "@" +
                                     "Update new values?", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);

                            switch (MsgRes)
                            {
                                case EMsgRes.smrOK:
                                    {
                                        DistPerPixelX[(int)CamID] = NewDistPerPixelX;
                                        DistPerPixelY[(int)CamID] = NewDistPerPixelY;
                                        break;
                                    }
                            }

                            break;
                            #endregion
                        }
                    case ECalMode.Aperture:
                        {
                            #region
                            #region step 1
                            TaskVision.LightingOn(TaskDisp.BCamera_CalNeedle_LightRGB);
                        _Retry:
                            frm_DispCore_JogGantryVision frm = new frm_DispCore_JogGantryVision();
                            frm.PageVision.SelectedCam = CamID;
                            TaskVision.FindCircle = 1;
                            frm.Inst = "Step 1/4: Confirm Aperture Recognition.";
                            frm.ShowVision = true;
                            DialogResult dr = frm.ShowDialog();
                            Application.DoEvents();
                            TaskVision.FindCircle = 0;

                            if (dr == DialogResult.Cancel)
                            {
                                return false;
                            }

                            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                            //if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.Basler)
                            //{
                            TaskVision.GrabN((int)ECamNo.Cam02, ref Image);
                            //}
                            if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.PtGrey)
                            {
                                //TaskVision.PtGrey_CamLive((int)ECamNo.Cam02);
                            }
                            if (GDefine.CameraType[(int)ECamNo.Cam02] == GDefine.ECameraType.MVSGenTL)
                                TaskVision.genTLCamera[(int)ECamNo.Cam02].StartGrab();

                            PointF Center = new PointF(0, 0);
                            float Radius = 0f;
                            int i_Circles = TaskVision.FindAperture(Image, ref Center, ref Radius);

                            if (i_Circles == 0) goto _Retry;

                            int t = GDefine.GetTickCount() + 200;
                            while (GDefine.GetTickCount() < t) Thread.Sleep(0);
                            #endregion

                        _Retry2:
                            #region step 2
                            TaskVision.LightingOn(TaskDisp.BCamera_Cal_LightRGB);

                            frm = new frm_DispCore_JogGantryVision();
                            SelectedCam = (int)ECamNo.Cam00;
                            frm.Inst = "Step 2/4: Jog Main Camera Crosshair (CX) to Aperture Edge 12 O'Clock";
                            frm.ShowVision = true;
                            DrawCalStep = ECalStepCHair.C;
                            dr = frm.ShowDialog();
                            Application.DoEvents();

                            if (dr == DialogResult.Cancel)
                            {
                                return false;
                            }

                            double X1 = TaskGantry.GXPos();
                            double Y1 = TaskGantry.GYPos();
                            #endregion

                            #region step 3
                            frm = new frm_DispCore_JogGantryVision();
                            frm.Inst = "Step 3/4: Jog Main Camera Crosshair (CX) to Aperture Edge 4 O'Clock";
                            frm.ShowVision = true;
                            DrawCalStep = ECalStepCHair.C;
                            dr = frm.ShowDialog();
                            Application.DoEvents();

                            if (dr == DialogResult.Cancel)
                            {
                                return false;
                            }
                            double X2 = TaskGantry.GXPos();
                            double Y2 = TaskGantry.GYPos();
                            #endregion

                            #region step 4
                            frm = new frm_DispCore_JogGantryVision();
                            frm.Inst = "Step 4/4: Jog Camera Crosshair (CX) to Aperture Edge 8 O'Clock";
                            frm.ShowVision = true;
                            DrawCalStep = ECalStepCHair.C;
                            dr = frm.ShowDialog();
                            Application.DoEvents();

                            if (dr == DialogResult.Cancel)
                            {
                                return false;
                            }
                            double X3 = TaskGantry.GXPos();
                            double Y3 = TaskGantry.GYPos();
                            #endregion

                            #region computation
                            double CX = 0;
                            double CY = 0;
                            double R = 0;
                            if (!GDefine.Arc3PGetInfo(X1, Y1, X2, Y2, X3, Y3, ref CX, ref CY, ref R))
                            {
                                Msg MsgBox = new Msg();
                                if (MsgBox.Show("Computation Error", "Retry Point Selection", "", EMcState.Error, EMsgBtn.smbOK_Cancel, false) == EMsgRes.smrCancel)
                                {
                                    return false;
                                }
                                goto _Retry2;
                            }

                            double CalPixelRad = Radius;
                            double MeasureRad = R;

                            double NewDistPerPixel = (double)(MeasureRad / CalPixelRad);
                            #endregion

                            DrawCalStep = ECalStepCHair.None;

                            {
                                Msg MsgBox = new Msg();
                                EMsgRes MsgRes = MsgBox.Show("Cal Vision " + CalMode[(int)CamID].ToString() + " Completed.@" +
                                             "Old DistPerPixel = " + DistPerPixelX[(int)CamID].ToString("F6") + "@" +
                                         "New DistPerPixel = " + NewDistPerPixel.ToString("F6") + "@" +
                                         "Update new values?", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);

                                switch (MsgRes)
                                {
                                    case EMsgRes.smrOK:
                                        {
                                            DistPerPixelX[(int)CamID] = NewDistPerPixel;
                                            DistPerPixelY[(int)CamID] = NewDistPerPixel;
                                            TaskDisp.Aperture_Dia = MeasureRad;
                                            TaskDisp.Aperture_Dia_Setup = MeasureRad;
                                            break;
                                        }
                                }
                            }
                            break;
                            #endregion
                        }
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

        public static bool TeachTemplate(int CamNo, ref VisUtils.EMatchTemplate Template, ref int Threshold)
        {
            string EMsg = "Teach Template";

            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
            try
            {
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Basler)
                {
                    GrabN(CamNo, ref Image);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.PtGrey)
                {
                    //TaskVision.PtGrey_CamStop();
                    //TaskVision.PtGrey_CamArm(CamNo);
                    //TaskVision.PtGrey_CamTrig(CamNo);
                    //TaskVision.PtGrey_CamImage(CamNo, ref Image);
                    //TaskVision.PtGrey_CamLive(CamNo);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker)
                {
                    GrabN(CamNo, ref Image);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker2)
                {
                    Image = flirCamera2[CamNo].m_ImageEmgu.m_Image.Clone();
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.MVSGenTL)
                {
                    genTLCamera[CamNo].GrabOneImage();
                    Image = genTLCamera[CamNo].mImage.Clone();
                    if (TaskVision.frmMVCGenTLCamera.Visible) genTLCamera[CamNo].StartGrab();
                }

                frm_DispCore_VisionSelectBox frmSelectBox = new frm_DispCore_VisionSelectBox();

                frmSelectBox.bmp = Image.ToBitmap();

                Rectangle SearchRect = Template.SearchRoi;
                if (SearchRect.X < 0 || SearchRect.X > Image.Width ||
                    SearchRect.Y < 0 || SearchRect.Y > Image.Height ||
                    SearchRect.Width > Image.Width ||
                    SearchRect.Height > Image.Height)
                {
                    SearchRect.X = 50;
                    SearchRect.Y = 50;
                    SearchRect.Width = 200;
                    SearchRect.Height = 200;
                }
                frmSelectBox.SearchRect = SearchRect;
                Rectangle PatternRect = Template.PatternRoi;
                if (PatternRect.X < 0 || PatternRect.X > Image.Width ||
                    PatternRect.Y < 0 || PatternRect.Y > Image.Height ||
                    PatternRect.Width > Image.Width ||
                    PatternRect.Height > Image.Height)
                {
                    PatternRect.X = 100;
                    PatternRect.Y = 100;
                    PatternRect.Width = 100;
                    PatternRect.Height = 100;
                }
                frmSelectBox.PatternRect = Template.PatternRoi;

                //DialogResult dr = frmSelectBox.ShowDialog();

                //if (dr == DialogResult.OK)
                //    VisUtils.Learn(Image, Template, frmSelectBox.SearchRect, frmSelectBox.PatternRect);

                //return true;

                frmSelectBox.Threshold = Threshold;

                DialogResult dr = frmSelectBox.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Threshold = frmSelectBox.Threshold;
                    if (Threshold >= 0)
                    {
                        Image = Image.ThresholdBinary(new Gray(Threshold), new Gray(255));
                    }
                    VisUtils.Learn(Image, Template, frmSelectBox.SearchRect, frmSelectBox.PatternRect);
                }
                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(EMsg + (char)13 + Ex.Message);
            }
            finally
            {
                if (Image != null) Image.Dispose();
            }
        }
        public static bool MatchTemplate(int CamNo, VisUtils.EMatchTemplate Template, int Threshold, out double X, out double Y, out double S, ref Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> FoundImage)
        {
            string EMsg = "Match Template";

            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
            try
            {
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Basler)
                {
                    GrabN(CamNo, ref Image);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.PtGrey)
                {
                    //TaskVision.PtGrey_CamStop();
                    //TaskVision.PtGrey_CamArm(CamNo);
                    //TaskVision.PtGrey_CamTrig(CamNo);
                    //TaskVision.PtGrey_CamImage(CamNo, ref Image);
                    //TaskVision.PtGrey_CamLive(CamNo);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker)
                {
                    GrabN(CamNo, ref Image);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.flirCamera2[CamNo].Snap();
                    Image = flirCamera2[CamNo].m_ImageEmgu.m_Image.Clone();
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.MVSGenTL)
                {
                    genTLCamera[CamNo].GrabOneImage();
                    Image = genTLCamera[CamNo].mImage.Clone();
                    if (TaskVision.frmMVCGenTLCamera.Visible) genTLCamera[CamNo].StartGrab();
                }

                float RX = 0;
                float RY = 0;
                float Score = 0;
                float OX = 0;
                float OY = 0;

                if (Threshold >= 0)
                    Image = Image.ThresholdBinary(new Gray(Threshold), new Gray(255));

                VisUtils.Match(Image, Template, 0.25F, ref Score, ref RX, ref RY, ref OX, ref OY);

                X = OX;
                Y = OY;
                S = Score;
                Y = -Y;

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                    Y = -Y;

                Rectangle Rect = new Rectangle((int)RX, (int)RY,
                    Template.PatternRoi.Width,
                    Template.PatternRoi.Height);
                FoundImage = Image.Copy(Rect);

                return true;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(EMsg);
            }
            finally
            {
                if (Image != null) Image.Dispose();
            }
        }

        public static bool TeachReference(int CamNo, int RefID, int RefNo, ref int Threshold)
        {
            if (RefNo <= 0) RefNo = 0;

            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
            try
            {
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.None)
                {
                    Image = TaskVision.LoadedImageG.Copy();
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Basler)
                {
                    GrabN(CamNo, ref Image);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.PtGrey)
                {
                    //TaskVision.PtGrey_CamStop();
                    //TaskVision.PtGrey_CamArm(CamNo);
                    //TaskVision.PtGrey_CamTrig(CamNo);
                    //TaskVision.PtGrey_CamImage(CamNo, ref  Image);
                    //TaskVision.PtGrey_CamLive(CamNo);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker)
                {
                    GrabN(CamNo, ref Image);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.flirCamera2[CamNo].Snap();
                    Image = flirCamera2[CamNo].m_ImageEmgu.m_Image.Clone();
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.MVSGenTL)
                {
                    genTLCamera[CamNo].GrabOneImage();
                    Image = genTLCamera[CamNo].mImage.Clone();
                    if (TaskVision.frmMVCGenTLCamera.Visible) genTLCamera[CamNo].StartGrab();
                }

                frm_DispCore_VisionSelectBox frmSelectBox = new frm_DispCore_VisionSelectBox();
                frmSelectBox.TopMost = true;

                frmSelectBox.bmp = Image.ToBitmap();

                Rectangle SearchRect = RefTemplate[RefID, RefNo].SearchRoi;
                if (SearchRect.X < 0 || SearchRect.X > Image.Width ||
                    SearchRect.Y < 0 || SearchRect.Y > Image.Height ||
                    SearchRect.Width > Image.Width ||
                    SearchRect.Height > Image.Height)
                {
                    SearchRect.X = 50;
                    SearchRect.Y = 50;
                    SearchRect.Width = 200;
                    SearchRect.Height = 200;
                }
                frmSelectBox.SearchRect = SearchRect;
                Rectangle PatternRect = RefTemplate[RefID, RefNo].PatternRoi;
                if (PatternRect.X < 0 || PatternRect.X > Image.Width ||
                    PatternRect.Y < 0 || PatternRect.Y > Image.Height ||
                    PatternRect.Width > Image.Width ||
                    PatternRect.Height > Image.Height)
                {
                    PatternRect.X = 100;
                    PatternRect.Y = 100;
                    PatternRect.Width = 100;
                    PatternRect.Height = 100;
                }
                frmSelectBox.PatternRect = RefTemplate[RefID, RefNo].PatternRoi;
                frmSelectBox.Threshold = Threshold;

                DialogResult dr = frmSelectBox.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Threshold = frmSelectBox.Threshold;
                    if (Threshold >= 0)
                    {
                        Image = Image.ThresholdBinary(new Gray(Threshold), new Gray(255));
                    }
                    VisUtils.Learn(Image, RefTemplate[RefID, RefNo], frmSelectBox.SearchRect, frmSelectBox.PatternRect);
                }
                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                if (Image != null) Image.Dispose();
            }
        }

        public static bool MatchReference(ref Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> InImage, int RefID, int RefNo, int Threshold, out double X, out double Y, out double S, ref Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> FoundImage)
        {
            string EMsg = "MatchReference";

            if (RefNo <= 0) RefNo = 0;

            int Retried = 0;

            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = InImage.Copy();
            try
            {
                float RX = 0;
                float RY = 0;
                float Score = 0;
                float OX = 0;
                float OY = 0;

                if (Threshold >= 0)
                    Image = Image.ThresholdBinary(new Gray(Threshold), new Gray(255));

                VisUtils.Match(Image, RefTemplate[RefID, RefNo], 0.5F, ref Score, ref RX, ref RY, ref OX, ref OY);

                X = OX;
                Y = OY;
                S = Score;
                Y = -Y;

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                    Y = -Y;

                Rectangle Rect = new Rectangle((int)RX, (int)RY,
                    RefTemplate[RefID, RefNo].PatternRoi.Width,
                    RefTemplate[RefID, RefNo].PatternRoi.Height);
                //FoundImage = VisProc.Copy(Image, Rect);
                FoundImage = Image.Copy(Rect);

                FoundPattern.Rect = Rect;
                FoundPattern.OK = true;
                FoundPattern.Draw();

                return true;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + " Retried" + Retried.ToString() + (char)13 + Ex.Message.ToString();
                throw new Exception(EMsg);
            }
            finally
            {
                if (Image != null) Image.Dispose();
            }
        }
        public static bool MatchReference(ref Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> InImage, int RefID, int RefNo, int Threshold, out double X, out double Y, out double S)
        {
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> FoundImage = null;
            try
            {
                return MatchReference(ref InImage, RefID, RefNo, Threshold, out X, out Y, out S, ref FoundImage);
            }
            catch { throw; }
            finally
            {
                if (FoundImage != null) FoundImage.Dispose();
            }
        }
        public static bool MatchReference(int CamNo, int RefID, int RefNo, int Threshold, out double X, out double Y, out double S, ref Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> FoundImage)
        {
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
            try
            {
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Basler)
                {
                    GrabN(CamNo, ref Image);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker)
                {
                    GrabN(CamNo, ref Image);
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker2)
                {
                    X = 0; Y = 0;  S = 0;
                    if (!TaskVision.flirCamera2[CamNo].Snap()) return false;
                    Image = flirCamera2[CamNo].m_ImageEmgu.m_Image.Clone();
                }
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.MVSGenTL)
                {
                    X = 0; Y = 0; S = 0;
                    genTLCamera[CamNo].GrabOneImage();
                    Image = genTLCamera[CamNo].mImage.Clone();
                    if (TaskVision.frmMVCGenTLCamera.Visible) genTLCamera[CamNo].StartGrab();
                }

                return MatchReference(ref Image, RefID, RefNo, Threshold, out X, out Y, out S, ref FoundImage);
            }
            catch { throw; }
            finally
            {
                if (Image != null) Image.Dispose();
            }
        }
        public static bool MatchReference(int CamNo, int RefID, int RefNo, int Threshold, out double X, out double Y, out double S)
        {
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> FoundImage = null;
            try
            {
                return MatchReference(CamNo, RefID, RefNo, Threshold, out X, out Y, out S, ref FoundImage);
            }
            catch { throw; }
            finally
            {
                if (FoundImage != null) FoundImage.Dispose();
            }
        }


        public static Image<Gray, byte> Image = null;
        public static Emgu.CV.UI.ImageBox imgBoxEmgu = new Emgu.CV.UI.ImageBox();
        public static bool ExecVision(int CamNo, int RefID, ref double X, ref double Y, ref double A, ref double S, ref bool OK, ref string data, ref Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image)
        {
            string EMsg = "ExecVision";

            try
            {
                Image = null;

                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.flirCamera2[CamNo].Snap();
                    Image = TaskVision.flirCamera2[CamNo].m_ImageEmgu.m_Image.Clone();
                }
                else
                if (GDefine.CameraType[CamNo] == GDefine.ECameraType.MVSGenTL)
                {
                    genTLCamera[CamNo].GrabOneImage();
                    Image = genTLCamera[CamNo].mImage.Clone();
                    if (TaskVision.frmMVCGenTLCamera.Visible) genTLCamera[CamNo].StartGrab();
                }
                else
                    TaskVision.GrabN(CamNo, ref Image);

                if (DispProg.frm_CamView.Visible) DispProg.frm_CamView.Image = Image.ToBitmap();

                DispProg.VisionTools[RefID].Exec(Image);

                X = DispProg.VisionTools[RefID].D_OX * TaskVision.DistPerPixelX[CamNo];
                Y = -DispProg.VisionTools[RefID].D_OY * TaskVision.DistPerPixelY[CamNo];
                A = DispProg.VisionTools[RefID].D_A;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                {
                    Y = -Y;
                    A = -A;
                }
                S = DispProg.VisionTools[RefID].D_Q;
                OK = DispProg.VisionTools[RefID].B_OK;

                string logPatLoc = "";
                string logAreaRatioData = "";
                for (int t = 0; t < DispProg.VisionTools[RefID].Count; t++)
                {
                    switch (DispProg.VisionTools[RefID].Tool[t].VisTool)
                    {
                        case NVision.TVisTool.EVisTool.PatLoc:
                            {
                                logPatLoc += "{ ";
                                logPatLoc = logPatLoc +
                                "X1," + (DispProg.VisionTools[RefID].D_X1 * TaskVision.DistPerPixelX[CamNo]).ToString("f3") + "," +
                                "Y1," + (DispProg.VisionTools[RefID].D_Y1 * TaskVision.DistPerPixelY[CamNo]).ToString("f3") + "," +
                                "X2," + (DispProg.VisionTools[RefID].D_X2 * TaskVision.DistPerPixelX[CamNo]).ToString("f3") + "," +
                                "Y2," + (DispProg.VisionTools[RefID].D_Y2 * TaskVision.DistPerPixelY[CamNo]).ToString("f3") + "," +
                                "X," + (DispProg.VisionTools[RefID].D_X * TaskVision.DistPerPixelX[CamNo]).ToString("f3") + "," +
                                "Y," + (DispProg.VisionTools[RefID].D_Y * TaskVision.DistPerPixelY[CamNo]).ToString("f3") + "," +
                                "OX," + (X = DispProg.VisionTools[RefID].D_OX * TaskVision.DistPerPixelX[CamNo]).ToString("f3") + "," +
                                "OY," + (-DispProg.VisionTools[RefID].D_OY * TaskVision.DistPerPixelY[CamNo]).ToString("f3") + "," +
                                "A," + DispProg.VisionTools[RefID].D_A.ToString("f3") + "," +
                                "Q," + DispProg.VisionTools[RefID].D_Q.ToString("f3");
                                logPatLoc += " }";
                            }
                            break;
                        case NVision.TVisTool.EVisTool.AreaRatio:
                            {
                                logAreaRatioData += "{";
                                logAreaRatioData = logAreaRatioData + DispProg.VisionTools[RefID].Tool[t].ResultString + " ";
                                string resData = "";
                                for (int r = 0; r < DispProg.VisionTools[RefID].Tool[t].RoiCount; r++)
                                    resData = resData + (resData.Length >0 ? ",":"") + DispProg.VisionTools[RefID].Tool[t].IRes[r].ToString("f2");
                                logAreaRatioData = logAreaRatioData + resData;
                                logAreaRatioData += " }";
                            }
                            break;
                    }
                }
                data = "OK," + OK.ToString() + "," + logPatLoc + logAreaRatioData;

                //***Draw Pattern
                FoundPattern.Rect = DispProg.VisionTools[RefID].Rect;
                FoundPattern.Rect.X = (int)(DispProg.VisionTools[RefID].D_X - (FoundPattern.Rect.Width / 2));
                FoundPattern.Rect.Y = (int)(DispProg.VisionTools[RefID].D_Y - (FoundPattern.Rect.Height / 2));
                FoundPattern.Angle = DispProg.VisionTools[RefID].D_A;
                FoundPattern.OK = OK;
                FoundPattern.Draw();

                Rectangle SearchRect = new Rectangle(
                    (int)(DispProg.VisionTools[RefID].D_X - FoundPattern.Rect.Width),
                    (int)(DispProg.VisionTools[RefID].D_Y - FoundPattern.Rect.Height),
                    FoundPattern.Rect.Width * 2,
                    FoundPattern.Rect.Height * 2);

                DispProg.FoundDoRef1 = Image.Copy().Convert<Emgu.CV.Structure.Bgr, byte>();
                DispProg.FoundDoRef1_X = FoundPattern.Rect.X;
                DispProg.FoundDoRef1_Y = FoundPattern.Rect.Y;
                DispProg.FoundDoRef1_S = S;
                DispProg.FoundDoRef1_OK = OK;

                return true;
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(EMsg);
            }
            finally
            {
            }
        }
        public static bool ExecVision(int CamNo, int RefID, ref double X, ref double Y, ref double A, ref double S, ref bool OK)
        {
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
            string data = "";
            try
            {
                return ExecVision(CamNo, RefID, ref X, ref Y, ref A, ref S, ref OK, ref data, ref Image);
            }
            catch
            {
                throw;
            }
            finally
            {
                Image.Dispose();
            }
        }
  

        public class TFoundPattern
        {
            public bool Drawing = false;
            public int t_DrawEnd = 0;
            public Rectangle Rect = new Rectangle(0, 0, 0, 0);
            public double Angle = 0;
            public bool OK = false;
            //public Color Color = Color.Orange;
            public void Draw()
            {
                Drawing = true;
                t_DrawEnd = GDefine.GetTickCount() + 250;
            }
        }
        public static TFoundPattern FoundPattern = new TFoundPattern();

        internal class TDoRefData
        {
            public double X1;
            public double Y1;
            public double S1;
            public Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Img1 = null;
            public double X2;
            public double Y2;
            public double S2;
            public Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Img2 = null;
            public double XF;
            public double YF;
            public double SF;
            public double Angle;//degree
            public double PatDistDiff;
            public ERefResult RefResult;

            public TDoRefData()
            {
                X1 = 0;
                Y1 = 0;
                S1 = 0;
                X2 = 0;
                Y2 = 0;
                S2 = 0;
                XF = 0;
                YF = 0;
                SF = 0;
                PatDistDiff = 0;
                RefResult = ERefResult.FailOther;
            }
        }
        internal static TDoRefData DoRef(DispProg.TLine CmdLine, int RefNo)
        {
            string EMsg = "DoRef";

            TDoRefData DoRefData = new TDoRefData();

            int RefID = CmdLine.ID;
            int CamID = CmdLine.IPara[1];
            ERefPatType RefPatType = (ERefPatType)CmdLine.IPara[3];

            int RefPat1 = (int)EVisionRef.No1;
            int RefPat2 = (int)EVisionRef.No1Pat2;
            if (RefNo == (int)EVisionRef.No2)
            {
                RefPat1 = (int)EVisionRef.No2;
                RefPat2 = (int)EVisionRef.No2Pat2;
            }

            int Threshold = (int)CmdLine.DPara[5];

            #region Do Pattern 1
            try
            {
                TaskVision.MatchReference(CamID, RefID, RefPat1, Threshold, out DoRefData.X1, out DoRefData.Y1, out DoRefData.S1, ref DoRefData.Img1);
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                return DoRefData;
            }

            DoRefData.X1 = DoRefData.X1 * TaskVision.DistPerPixelX[CamID];
            DoRefData.Y1 = DoRefData.Y1 * TaskVision.DistPerPixelY[CamID];
            #endregion

            if (RefPatType > ERefPatType.Single)
            {
                #region Do Pattern 2

                try
                {
                    TaskVision.MatchReference(CamID, RefID, RefPat2, Threshold, out DoRefData.X2, out DoRefData.Y2, out DoRefData.S2, ref DoRefData.Img2);
                }
                catch (Exception Ex)
                {
                    EMsg = EMsg + (char)13 + Ex.Message.ToString();
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
                    return DoRefData;
                }

                DoRefData.X2 = DoRefData.X2 * TaskVision.DistPerPixelX[CamID];
                DoRefData.Y2 = DoRefData.Y2 * TaskVision.DistPerPixelY[CamID];
                #endregion
            }

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                TaskVision.flirCamera2[0].GrabCont();
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                if (TaskVision.frmMVCGenTLCamera.Visible) genTLCamera[0].StartGrab();
            }

            switch (RefPatType)
            {
                default://case ERefPatType.One:
                    {
                        #region
                        DoRefData.XF = DoRefData.X1;
                        DoRefData.YF = DoRefData.Y1;
                        DoRefData.SF = DoRefData.S1;

                        if (DoRefData.S1 < CmdLine.DPara[0])
                        {
                            DoRefData.RefResult = ERefResult.FailMinScore;
                            return DoRefData;
                        }

                        if (Math.Abs(DoRefData.X1) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y1) > CmdLine.DPara[1])
                        {
                            DoRefData.RefResult = ERefResult.FailRefXYTol;
                            return DoRefData;
                        }

                        break;
                        #endregion
                    }
                case ERefPatType.AverageOfTwo:
                    {
                        #region
                        DoRefData.XF = (DoRefData.X1 + DoRefData.X2) / 2;
                        DoRefData.YF = (DoRefData.Y1 + DoRefData.Y2) / 2;
                        DoRefData.SF = (DoRefData.S1 + DoRefData.S2) / 2;

                        int Pat1X = TaskVision.RefTemplate[CmdLine.ID, RefPat1].PatternRoi.X;
                        int Pat1Y = TaskVision.RefTemplate[CmdLine.ID, RefPat1].PatternRoi.Y;
                        int Pat2X = TaskVision.RefTemplate[CmdLine.ID, RefPat2].PatternRoi.X;
                        int Pat2Y = TaskVision.RefTemplate[CmdLine.ID, RefPat2].PatternRoi.Y;

                        NSW.Net.Polar OriL = new NSW.Net.Polar(new NSW.Net.Point2D(Pat1X, Pat1Y), new NSW.Net.Point2D(Pat2X, Pat2Y));
                        NSW.Net.Polar NewL = new NSW.Net.Polar(new NSW.Net.Point2D(Pat1X + DoRefData.X1, Pat1Y + DoRefData.Y1), new NSW.Net.Point2D(Pat2X + DoRefData.X2, Pat2Y + DoRefData.Y2));

                        DoRefData.PatDistDiff = NewL.R - OriL.R;

                        if ((DoRefData.S1 < CmdLine.DPara[0] || Math.Abs(DoRefData.X1) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y1) > CmdLine.DPara[1]) ||
                            (DoRefData.S2 < CmdLine.DPara[0] || Math.Abs(DoRefData.X2) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y2) > CmdLine.DPara[1]))
                        {
                            if (DoRefData.S1 < CmdLine.DPara[0] || DoRefData.S2 < CmdLine.DPara[0])
                            {
                                DoRefData.RefResult = ERefResult.FailMinScore;
                                return DoRefData;
                            }

                            if ((Math.Abs(DoRefData.X1) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y1) > CmdLine.DPara[1]) ||
                                (Math.Abs(DoRefData.X2) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y2) > CmdLine.DPara[1]))
                            {
                                DoRefData.RefResult = ERefResult.FailRefXYTol;
                                return DoRefData;
                            }
                        }

                        if (Math.Abs(DoRefData.PatDistDiff) > CmdLine.DPara[4])
                        {
                            DoRefData.RefResult = ERefResult.FailPatDistTol;
                            return DoRefData;
                        }

                        break;
                        #endregion
                    }
                case ERefPatType.BestOfTwo:
                    {
                        #region
                        if (DoRefData.S2 > DoRefData.S1)
                        {
                            DoRefData.XF = DoRefData.X2;
                            DoRefData.YF = DoRefData.Y2;
                            DoRefData.SF = DoRefData.S2;
                        }
                        else
                        {
                            DoRefData.XF = DoRefData.X1;
                            DoRefData.YF = DoRefData.Y1;
                            DoRefData.SF = DoRefData.S1;
                        }

                        int Pat1X = TaskVision.RefTemplate[CmdLine.ID, RefPat1].PatternRoi.X;
                        int Pat1Y = TaskVision.RefTemplate[CmdLine.ID, RefPat1].PatternRoi.Y;
                        int Pat2X = TaskVision.RefTemplate[CmdLine.ID, RefPat2].PatternRoi.X;
                        int Pat2Y = TaskVision.RefTemplate[CmdLine.ID, RefPat2].PatternRoi.Y;

                        NSW.Net.Polar OriL = new NSW.Net.Polar(new NSW.Net.Point2D(Pat1X, Pat1Y), new NSW.Net.Point2D(Pat2X, Pat2Y));
                        NSW.Net.Polar NewL = new NSW.Net.Polar(new NSW.Net.Point2D(Pat1X + DoRefData.X1, Pat1Y + DoRefData.Y1), new NSW.Net.Point2D(Pat2X + DoRefData.X2, Pat2Y + DoRefData.Y2));

                        DoRefData.PatDistDiff = NewL.R - OriL.R;

                        if ((DoRefData.S1 < CmdLine.DPara[0] || Math.Abs(DoRefData.X1) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y1) > CmdLine.DPara[1]) &&
                            (DoRefData.S2 < CmdLine.DPara[0] || Math.Abs(DoRefData.X2) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y2) > CmdLine.DPara[1]))
                        {
                            if (DoRefData.S1 < CmdLine.DPara[0] || DoRefData.S2 < CmdLine.DPara[0])
                            {
                                DoRefData.RefResult = ERefResult.FailMinScore;
                                return DoRefData;
                            }
                            if ((Math.Abs(DoRefData.X1) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y1) > CmdLine.DPara[1]) ||
                                (Math.Abs(DoRefData.X2) > CmdLine.DPara[1] || Math.Abs(DoRefData.Y2) > CmdLine.DPara[1]))
                            {
                                DoRefData.RefResult = ERefResult.FailRefXYTol;
                                return DoRefData;
                            }
                        }
                        break;
                        #endregion
                    }
            }
            DoRefData.RefResult = ERefResult.OK;
            return DoRefData;
        }

        public static int FindCircles(Image<Gray, Byte> Image, bool DetBlack, ref PointF[] Center, ref float[] Radius)
        {
            VectorOfVectorOfPoint Contour = new VectorOfVectorOfPoint();

            try
            {
                Image<Gray, Byte> img_Gray = Image.PyrDown().PyrUp();
                Gray g_Ave = img_Gray.GetAverage();

                Image<Gray, Byte> img_Bin = null;
                if (DetBlack)
                    img_Bin = img_Gray.ThresholdBinaryInv(g_Ave, new Gray(255));
                else
                    img_Bin = img_Gray.ThresholdBinary(g_Ave, new Gray(255));

                CvInvoke.FindContours(img_Bin, Contour, null, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);   
            }
            catch
            {
                return 0;
            }

            if (Contour == null) return 0;
            if (Contour.Size == 0) return 0;
            int Index = 0;

            for (int i = 0; i < Contour.Size; i++)
            {
                if (i >= 1024) continue;

                VectorOfPoint contour = Contour[i];
                Rectangle rect = CvInvoke.BoundingRectangle(contour);
                float X = rect.X + (float)(rect.Width / 2);
                float Y = rect.Y + (float)(rect.Height / 2);
                float R = (float)((rect.Width + rect.Height) / 4);

                Center[i] = new PointF(X, Y);
                Radius[i] = R;
                Index++;// = i;
            }

            for (int i = 0; i < Index - 1; i++)
            {
                int i_Max_Index = i;
                for (int j = i; j < Index; j++)
                {
                    if (Radius[j] > Radius[i_Max_Index])
                    {
                        i_Max_Index = j;
                    }
                }
                PointF TempPt = new PointF(Center[i].X, Center[i].Y);
                float TempRad = Radius[i];

                Radius[i] = Radius[i_Max_Index];
                Center[i] = Center[i_Max_Index];

                Radius[i_Max_Index] = TempRad;
                Center[i_Max_Index] = TempPt;
            }

            return Index;
        }
        public static int FindAperture(Image<Gray, Byte> Image, ref PointF Center, ref float Radius)
        {
            PointF[] CenterA = new PointF[1024];
            float[] RadiusA = new float[1024];
            int i_Circles = TaskVision.FindCircles(Image, true, ref CenterA, ref RadiusA);

            if (i_Circles == 0) return 0;

            if (i_Circles > 0)
            {
                Center = CenterA[0];
                Radius = RadiusA[0];
            }

            return 1;
        }
        public static int FindApertureNeedle(Image<Gray, Byte> Image, ref PointF[] Center, ref float[] Radius)
        {
            PointF[] CenterA = new PointF[1024];
            float[] RadiusA = new float[1024];
            int i_Circles = TaskVision.FindCircles(Image, true, ref CenterA, ref RadiusA);

            if (i_Circles == 0) return 0;

            if (i_Circles > 0)
            {
                Center[0] = CenterA[0];
                Radius[0] = RadiusA[0];
            }

            PointF[] CenterN = new PointF[1024];
            float[] RadiusN = new float[1024];
            i_Circles = TaskVision.FindCircles(Image, false, ref CenterN, ref RadiusN);

            if (i_Circles == 0) return 1;

            if (i_Circles > 0)
            {
                for (int i = 0; i < i_Circles; i++)
                {
                    Center[1] = CenterN[i];
                    Radius[1] = RadiusN[i];

                    double Dist = Math.Sqrt(Math.Pow(Center[0].X - Center[1].X, 2) + Math.Pow(Center[0].Y - Center[1].Y, 2));

                    if (Radius[1] >= 10 && Dist <= (Radius[0] - Radius[1]))
                    {
                        return 2;
                    }
                }
            }
            return 1;
        }

        public static bool LightingOpened = false;
        public static bool OpenLighting()
        {
            if (GDefine.LCType == GDefine.ELCType.None)
            {
                return true;
            }
            switch (GDefine.LCType)
            {
                case GDefine.ELCType.LCSerial:
                    {
                        if (!LCSerial.Open((byte)GDefine.LCComport)) goto _ErrorOpen;
                        if (!LCSerial.SetMultiplier(LEDStudio.Net.LCSerial.TCtrlNo.Ctrl0, (byte)0x02)) goto _ErrorSet;
                        if (!LCSerial.SetMode(LEDStudio.Net.LCSerial.TCtrlNo.Ctrl0, LEDStudio.Net.LCSerial.TChannel.No1, LEDStudio.Net.LC.TMode.Constant)) goto _ErrorSet;
                        if (!LCSerial.SetMode(LEDStudio.Net.LCSerial.TCtrlNo.Ctrl0, LEDStudio.Net.LCSerial.TChannel.No2, LEDStudio.Net.LC.TMode.Constant)) goto _ErrorSet;
                        if (!LCSerial.SetMode(LEDStudio.Net.LCSerial.TCtrlNo.Ctrl0, LEDStudio.Net.LCSerial.TChannel.No3, LEDStudio.Net.LC.TMode.Constant)) goto _ErrorSet;
                        if (!LCSerial.SetMode(LEDStudio.Net.LCSerial.TCtrlNo.Ctrl0, LEDStudio.Net.LCSerial.TChannel.No4, LEDStudio.Net.LC.TMode.Constant)) goto _ErrorSet;
                        LightingOpened = true;
                        return true;
                    }
                case GDefine.ELCType.LCSerLegacy:
                    {
                        if (!LCSerLegacy.Open((byte)GDefine.LCComport)) goto _ErrorOpen;
                        if (!LCSerLegacy.SetMode(LEDStudio.Net.LCSerial.TChannel.No1, LEDStudio.Net.LC.TMode.Constant)) goto _ErrorSet;
                        if (!LCSerLegacy.SetMode(LEDStudio.Net.LCSerial.TChannel.No2, LEDStudio.Net.LC.TMode.Constant)) goto _ErrorSet;
                        if (!LCSerLegacy.SetMode(LEDStudio.Net.LCSerial.TChannel.No3, LEDStudio.Net.LC.TMode.Constant)) goto _ErrorSet;
                        if (!LCSerLegacy.SetMode(LEDStudio.Net.LCSerial.TChannel.No4, LEDStudio.Net.LC.TMode.Constant)) goto _ErrorSet;
                        LightingOpened = true;
                        return true;
                    }
                default:
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.LEDCTRL_UNKNOWN_CTRL_ERR);
                        return false;
                    }
            }

        _ErrorOpen:
            {
                LCSerial.Close();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.LEDCTRL_OPEN_ERR);
                return false;
            }
        _ErrorSet:
            {
                LCSerial.Close();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.LEDCTRL_SETVALUE_ERR);
                return false;
            }
        }
        public static void CloseLighting()
        {
            if (GDefine.LCType == GDefine.ELCType.None)
            {
                //return true;
            }
            if (GDefine.LCType == GDefine.ELCType.LCSerial)
            {
                LCSerial.OutputOff(0, 0x0F);
                LCSerial.Close();
                LightingOpened = false;
            }
            if (GDefine.LCType == GDefine.ELCType.LCSerLegacy)
            {
                try
                {
                    LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No1, 0);
                    LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No2, 0);
                    LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No3, 0);
                    LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No4, 0);
                    LCSerLegacy.Close();
                    LightingOpened = false;
                }
                catch { };
            }
        }
        public static bool LightingOn(int R, int G, int B, int A)
        {
            if (CurrentLightRGBA.R == R && CurrentLightRGBA.G == G && CurrentLightRGBA.B == B && CurrentLightRGBA.A == A) return true;

            #region
            float RP = R;
            if (RP > 100) RP = 100;
            RP = RP / 100 * 255;

            float GP = G;
            if (GP > 100) GP = 100;
            GP = GP / 100 * 255;

            float BP = B;
            if (BP > 100) BP = 100;
            BP = BP / 100 * 255;

            float AP = A;
            if (AP > 100) AP = 100;
            AP = AP / 100 * 255;
            #endregion

            if (GDefine.LCType == GDefine.ELCType.LCSerial)
            {
                if (!LightingOpened)
                {
                    if (!OpenLighting()) return false;
                }
                #region
                {
                    if (!LCSerial.OutputOn(0x00, 0x0F)) return false;

                    LCSerial.SetConstInt(0, 0x01, (byte)RP);
                    LCSerial.SetConstInt(0, 0x02, (byte)GP);
                    LCSerial.SetConstInt(0, 0x04, (byte)BP);
                    LCSerial.SetConstInt(0, 0x08, (byte)AP);
                }
                #endregion
            }
            if (GDefine.LCType == GDefine.ELCType.LCSerLegacy)
            {
                if (!LightingOpened)
                {
                    if (!OpenLighting()) return false;
                }
                #region
                {
                    LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No1, (byte)RP);
                    LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No2, (byte)GP);
                    LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No3, (byte)BP);
                    LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No4, (byte)AP);
                }
                #endregion
            }
            CurrentLightRGBA.R = R;
            CurrentLightRGBA.G = G;
            CurrentLightRGBA.B = B;
            CurrentLightRGBA.A = A;

            return true;
        }
        public static bool LightingOn(TLightRGBA RGB)
        {
            return LightingOn(RGB.R, RGB.G, RGB.B, RGB.A);
        }
        public static bool LightingOff()
        {
            if (CurrentLightRGBA.R == 0 && CurrentLightRGBA.G == 0 && CurrentLightRGBA.B == 0 && CurrentLightRGBA.A == 0) return true;

            CurrentLightRGBA.R = 0;
            CurrentLightRGBA.G = 0;
            CurrentLightRGBA.B = 0;
            CurrentLightRGBA.A = 0;

            if (GDefine.LCType == GDefine.ELCType.LCSerial)
            {
                if (!LightingOpened)
                {
                    if (!OpenLighting()) return false;
                }

                LCSerial.OutputOff(0, 0x0F);
            }
            if (GDefine.LCType == GDefine.ELCType.LCSerLegacy)
            {
                if (!LightingOpened)
                {
                    if (!OpenLighting()) return false;
                }

                if (!LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No1, 0)) return false;
                if (!LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No2, 0)) return false;
                if (!LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No3, 0)) return false;
                if (!LCSerLegacy.SetConstInt(LEDStudio.Net.LC.TChannel.No4, 0)) return false;
            }
            return true;
        }
    }

    class TaskMCamera
    {
        public static MVC.MVC_GenTL[] MCamera = new MVC.MVC_GenTL[2] { new MVC.MVC_GenTL(), new MVC.MVC_GenTL() };

        public static bool OpenCamera(int CamNo)
        {
            string EMsg = "OpenCamera";
            if (GDefine.MCameraType[CamNo] == GDefine.ECameraType.None) return true;

            switch (GDefine.MCameraType[CamNo])
            {
                default: throw new Exception("Camera type not supported.");
                case GDefine.ECameraType.MVSGenTL:
                    #region
                    try
                    {
                        if (!MCamera[CamNo].IsConnected)
                        {
                            //string ctifile = @"C:\Program Files (x86)\FLIR Systems\Spinnaker\cti\vs2015\FLIR_GenTL_v140.cti";
                            string ctifile = @"C:\Program Files (x86)\Common Files\MVS\Runtime\Win32_i86\MvProducerGEV.cti";
                            if (GDefine.MCameraSerialNo[CamNo] != null && GDefine.MCameraSerialNo[CamNo].Length > 0)
                                MCamera[CamNo].OpenDevice($"MCam{CamNo + 1}", GDefine.MCameraSerialNo[CamNo], ctifile);
                            else
                                MCamera[CamNo].OpenDevice($"MCam{CamNo + 1}", GDefine.MCameraIPAddress[CamNo]);

                            if (!MCamera[CamNo].IsConnected)
                            {
                                Msg MsgBox = new Msg();

                                EMsgRes MsgRes = MsgBox.Show(ErrCode.CAMERA1_OPEN_ERR, "", EMcState.Notice, EMsgBtn.smbOK, false);
                                if (MsgRes == EMsgRes.smrCancel)
                                {
                                    Intf.Terminate = true;
                                }

                                MCamera[CamNo].CloseDevice();
                                return false;
                            }

                            TaskMCamera.MCamera[CamNo].Exposure = GDefine.MCameraExposure[CamNo];
                            TaskMCamera.MCamera[CamNo].Gain = GDefine.MCameraGain[CamNo];
                            TaskMCamera.MCamera[CamNo].ReverseX = GDefine.MCameraReverseX[CamNo];
                            TaskMCamera.MCamera[CamNo].ReverseY = GDefine.MCameraReverseY[CamNo];
                        }
                    }
                    catch (Exception Ex)
                    {
                        try
                        {
                            MCamera[CamNo].CloseDevice();
                        }
                        catch { }

                        EMsg = EMsg + Ex.Message;
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.CAMERA1_OPEN_ERR);
                        return false;
                    }
                    break;
                    #endregion
            }

            return true;
        }
        public static bool OpenCameras()
        {
            bool OK = true;
            for (int i = 0; i < GDefine.MAX_MCAMERA; i++)
            {
                if (!OpenCamera(i)) OK = false;
                if (Intf.Terminate) break;
            }
            return OK;
        }
        public static void CloseCamera(int CamNo)
        {
            switch (GDefine.MCameraType[CamNo])
            {
                default: break;
                case GDefine.ECameraType.MVSGenTL:
                    MCamera[CamNo].CloseDevice();
                    break;
            }
        }
        public static void CloseCameras()
        {
            for (int i = 0; i < GDefine.MAX_MCAMERA; i++)
            {
                CloseCamera(i);
            }
        }
        public static bool CameraOpened(int CamNo)
        {
            switch (GDefine.MCameraType[CamNo])
            {
                default: return false;
                case GDefine.ECameraType.MVSGenTL:
                    {
                        return MCamera[CamNo].IsConnected;
                    }
            }

        }
    }
}
