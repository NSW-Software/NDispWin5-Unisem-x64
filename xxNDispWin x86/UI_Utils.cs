using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NDispWin
{
    internal class UI_Utils
    {
        //public UI_Utils()
        //{

        //}

        public static void DrawSelected(Label Label, bool Selected)
        {
            if (Selected)
            {
                Label.BackColor = Color.Navy;
                Label.ForeColor = SystemColors.Control;
            }
            else
            {
                Label.BackColor = SystemColors.Control;
                Label.ForeColor = Color.Navy;
            }
        }
        public static void SetControlSelected(object sender, bool Selected)
        {
            if (Selected)
            {
                (sender as Button).ForeColor = SystemColors.Control;
                (sender as Button).BackColor = Color.Navy;
            }
            else
            {
                (sender as Button).ForeColor = Color.Navy;
                (sender as Button).BackColor = SystemColors.Control;
            }
        }
        public static void SetControlSelected2(object sender, bool Selected)
        {
            if (Selected)
            {
                (sender as Label).BackColor = Color.Gold;
            }
            else
            {
                (sender as Label).BackColor = SystemColors.Control;
            }
        }
        public enum FileIcon
        {
            New,
            Open,
            Save,
            SaveAs,
            File,
        }
        public static void ButtonDrawFileIcon(ref Button btn, FileIcon Icon)
        {
            btn.Text = "";
            int Size = btn.Height;

            Graphics g;
            Bitmap bmp = new Bitmap(Size, Size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Color ForeColor = Color.Navy;

            if (btn.Enabled)
            {
                ForeColor = Color.Navy;
            }
            else
            {
                ForeColor = Color.Gray;
            }

            Pen Pen = new Pen(ForeColor, 1);
            SolidBrush SBrush = new SolidBrush(ForeColor);

            g.Clear(Color.Transparent);
            btn.BackColor = Color.Transparent;

            switch (Icon)
            {
                case FileIcon.New:
                    #region
                    {
                        int HW = (int)(0.3F * Size);
                        int HH = (int)(0.35F * Size);
                        int T = (int)(0.5F * HW);
                        int CX = Size / 2;
                        int CY = Size / 2;

                        Point[] Points = new Point[9];
                        Points[0] = new Point(CX - HW, CY - HH);
                        Points[1] = new Point(CX + HW - T, CY - HH);
                        Points[2] = new Point(CX + HW, CY - HH + T);
                        Points[3] = new Point(CX + HW, CY + HH);
                        Points[4] = new Point(CX - HW, CY + HH);
                        Points[5] = new Point(CX - HW, CY - HH);

                        Points[6] = new Point(CX + HW - T, CY - HH);
                        Points[7] = new Point(CX + HW - T, CY - HH + T);
                        Points[8] = new Point(CX + HW, CY - HH + T);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points);

                        break;
                    }
                    #endregion
                case FileIcon.Open:
                    #region
                    {
                        int HW = (int)(0.3F * Size);
                        int HH = (int)(0.35F * Size);
                        int T = (int)(0.5F * HW);
                        int CX = Size / 2;
                        int CY = Size / 2;

                        Point[] Points = new Point[5];
                        Points[0] = new Point(CX - HW + 3, CY - 2);
                        Points[1] = new Point(CX + HW + 3, CY - 2);
                        Points[2] = new Point(CX + HW - 3, CY + HH);
                        Points[3] = new Point(CX - HW - 3, CY + HH);
                        Points[4] = new Point(CX - HW + 3, CY - 2);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points);

                        Point[] Points2 = new Point[6];
                        Points2[0] = new Point(CX - HW - 3, CY + HH);
                        Points2[1] = new Point(CX - HW - 3, CY - HH);
                        Points2[2] = new Point(CX - HW + 8, CY - HH);
                        Points2[3] = new Point(CX - HW + 8, CY - HH + 3);
                        Points2[4] = new Point(CX + HW - 3, CY - HH + 3);
                        Points2[5] = new Point(CX + HW - 3, CY - 2);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points2);

                        break;
                    }
                    #endregion
                case FileIcon.Save:
                    #region
                    {
                        int HW = (int)(0.35F * Size);
                        int HH = (int)(0.35F * Size);
                        int T = (int)(0.15F * HW);
                        int CX = Size / 2;
                        int CY = Size / 2;

                        Point[] Points = new Point[7];
                        Points[0] = new Point(CX - HW, CY - HH + T);
                        Points[1] = new Point(CX - HW + T, CY - HH);
                        Points[2] = new Point(CX + HW - T, CY - HH);
                        Points[3] = new Point(CX + HW, CY - HH + T);
                        Points[4] = new Point(CX + HW, CY + HH);
                        Points[5] = new Point(CX - HW, CY + HH);
                        Points[6] = new Point(CX - HW, CY - HH + T);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points);

                        int SHW = (int)((double)HW * 0.8);
                        int SHH = (int)((double)HH * 0.5);
                        Point[] Points2 = new Point[5];
                        Points2[0] = new Point(CX - SHW, CY - SHH + 5);
                        Points2[1] = new Point(CX - SHW, CY + SHH + 5);
                        Points2[2] = new Point(CX + SHW, CY + SHH + 5);
                        Points2[3] = new Point(CX + SHW, CY - SHH + 5);
                        Points2[4] = new Point(CX - SHW, CY - SHH + 5);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points2);

                        SHW = (int)((double)HW * 0.6);
                        SHH = (int)((double)HH * 0.4);
                        Point[] Points3 = new Point[5];
                        Points3[0] = new Point(CX - SHW, CY - SHH - 9);
                        Points3[1] = new Point(CX - SHW, CY + SHH - 9);
                        Points3[2] = new Point(CX + SHW, CY + SHH - 9);
                        Points3[3] = new Point(CX + SHW, CY - SHH - 9);
                        Points3[4] = new Point(CX - SHW, CY - SHH - 9);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points3);
                        
                        break;
                    }
                    #endregion
                case FileIcon.SaveAs:
                    #region
                    {
                        int HW = (int)(0.35F * Size);
                        int HH = (int)(0.35F * Size);
                        int T = (int)(0.15F * HW);
                        int CX = Size / 2;
                        int CY = Size / 2;

                                                Point[] Points = new Point[7];
                        Points[0] = new Point(CX - HW, CY - HH + T);
                        Points[1] = new Point(CX - HW + T, CY - HH);
                        Points[2] = new Point(CX + HW - T, CY - HH);
                        Points[3] = new Point(CX + HW, CY - HH + T);
                        Points[4] = new Point(CX + HW, CY + HH);
                        Points[5] = new Point(CX - HW, CY + HH);
                        Points[6] = new Point(CX - HW, CY - HH + T);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points);

                        int SHW = (int)((double)HW * 0.8);
                        int SHH = (int)((double)HH * 0.5);
                        Point[] Points2 = new Point[5];
                        Points2[0] = new Point(CX - SHW, CY - SHH + 5);
                        Points2[1] = new Point(CX - SHW, CY + SHH + 5);
                        Points2[2] = new Point(CX + SHW, CY + SHH + 5);
                        Points2[3] = new Point(CX + SHW, CY - SHH + 5);
                        Points2[4] = new Point(CX - SHW, CY - SHH + 5);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points2);

                        SHW = (int)((double)HW * 0.6);
                        SHH = (int)((double)HH * 0.4);
                        Point[] Points3 = new Point[5];
                        Points3[0] = new Point(CX - SHW, CY - SHH - 9);
                        Points3[1] = new Point(CX - SHW, CY + SHH - 9);
                        Points3[2] = new Point(CX + SHW, CY + SHH - 9);
                        Points3[3] = new Point(CX + SHW, CY - SHH - 9);
                        Points3[4] = new Point(CX - SHW, CY - SHH - 9);

                        Pen.Width = 2;
                        g.DrawLines(Pen, Points3);

                        SHW = (int)((double)HW * 0.5);
                        SHH = (int)((double)HH * 0.5);

                        Pen.Width = 1;
                        g.DrawLine(Pen, new Point(CX - 10, CY - SHH - 10), new Point(CX - 10, CY + SHH - 10));
                        g.DrawLine(Pen, new Point(CX - SHW - 10, CY - 10), new Point(CX + SHW - 10, CY - 10));
                        g.DrawLine(Pen, new Point(CX - SHW - 10, CY - SHH - 10), new Point(CX + SHW - 10, CY + SHH - 10));
                        g.DrawLine(Pen, new Point(CX - SHW - 10, CY + SHH - 10), new Point(CX + SHW - 10, CY - SHH - 10));

                        break;
                    }
                    #endregion
                case FileIcon.File:
                    #region
                    {
                        int HW = (int)(0.35F * Size);
                        int HH = (int)(0.35F * Size);
                        //int T = (int)(0.15F * HW);
                        int CX = Size / 2;
                        int CY = Size / 2;

                        Point[] Points = new Point[5];
                        int SX = (int)((double)Size * 0.35);
                        int SY = (int)((double)Size * 0.4);
                        int EX = (int)((double)Size * 0.75);
                        int EY = (int)((double)Size * 0.85);
                        Points[0] = new Point(SX, SY);
                        Points[1] = new Point(EX, SY);
                        Points[2] = new Point(EX, EY);
                        Points[3] = new Point(SX, EY);
                        Points[4] = new Point(SX, SY);
                        Pen.Width = 2;
                        g.DrawLines(Pen, Points);

                        g.DrawLine(Pen, new Point(SX + 2, SY + 3), new Point(EX - 2, SY + 3));
                        g.DrawLine(Pen, new Point(SX + 2, SY + 6), new Point(EX - 2, SY + 6));
                        g.DrawLine(Pen, new Point(SX + 2, SY + 9), new Point(EX - 2, SY + 9));
                        g.DrawLine(Pen, new Point(SX + 2, SY + 12), new Point(EX - 2, SY + 12));

                        Points = new Point[4];
                        Points[0] = new Point(CX - HW, CY - HH);
                        Points[1] = new Point(CX + HW, CY - HH);
                        Points[2] = new Point(CX + HW, CY + HH - 5);
                        Points[3] = new Point(EX, CY + HH - 5);
                        Pen.Width = 2;
                        g.DrawLines(Pen, Points);

                        Points = new Point[3];
                        Points[0] = new Point(SX, CY + HH - 5);
                        Points[1] = new Point(CX - HW, CY + HH - 5);
                        Points[2] = new Point(CX - HW, CY - HH);
                        Pen.Width = 2;
                        g.DrawLines(Pen, Points);

                        Points = new Point[2];
                        Points[0] = new Point(CX - HW, CY - HH + 4);
                        Points[1] = new Point(CX + HW, CY - HH + 4);
                        Pen.Width = 2;
                        g.DrawLines(Pen, Points);

                        break;
                    }
                    #endregion
            }
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.Image = bmp;
            g.Dispose();
        }

        public enum Path
        {
            XFZ,
            YFZ,
            XFU,
            YFU,
        }
        public static void ButtonDrawPath(ref Button btn, Path Path)
        {
            btn.Text = "";
            int Size = 20;
            
            Graphics g;
            Bitmap bmp = new Bitmap(Size, Size, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(bmp);
            Pen Pen = new Pen(Color.Blue, 1);

            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;// HighQualityBicubic;
            //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            g.Clear(btn.BackColor);

            switch (Path)
            {
                case Path.XFZ:
                    {
                        float L = 0.05F * Size;
                        float R = 0.95F * Size;
                        float CX = 0.5F * Size;
                        float T = 0.05F * Size;
                        float B = 0.85F * Size;
                        float CY = 0.45F * Size;

                        PointF[] PointFs = new PointF[6];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(R, T);
                        PointFs[2] = new PointF(L, CY);
                        PointFs[3] = new PointF(R, CY);
                        PointFs[4] = new PointF(L, B);
                        PointFs[5] = new PointF(R, B);
                        g.DrawLines(Pen, PointFs);

                        g.DrawLine(Pen, new PointF(R, B), new PointF(R - 5, B - 2));
                        g.DrawLine(Pen, new PointF(R, B), new PointF(R - 5, B + 2));
                        break;
                    }
                case Path.YFZ:
                    {
                        float L = 0.05F * Size;
                        float R = 0.85F * Size;
                        float CX = 0.45F * Size;
                        float T = 0.05F * Size;
                        float B = 0.95F * Size;
                        float CY = 0.5F * Size;

                        PointF[] PointFs = new PointF[6];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(L, B);
                        PointFs[2] = new PointF(CX, T);
                        PointFs[3] = new PointF(CX, B);
                        PointFs[4] = new PointF(R, T);
                        PointFs[5] = new PointF(R, B);
                        g.DrawLines(Pen, PointFs);

                        g.DrawLine(Pen, new PointF(R, B), new PointF(R - 2, B - 5));
                        g.DrawLine(Pen, new PointF(R, B), new PointF(R + 2, B - 5));
                        break;
                    }
                case Path.XFU:
                    {
                        float L = 0.05F * Size;
                        float R = 0.95F * Size;
                        float CX = 0.5F * Size;
                        float T = 0.05F * Size;
                        float B = 0.85F * Size;
                        float CY = 0.45F * Size;

                        PointF[] PointFs = new PointF[6];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(R, T);
                        PointFs[2] = new PointF(R, CY);
                        PointFs[3] = new PointF(L, CY);
                        PointFs[4] = new PointF(L, B);
                        PointFs[5] = new PointF(R, B);
                        g.DrawLines(Pen, PointFs);

                        g.DrawLine(Pen, new PointF(R, B), new PointF(R - 5, B - 2));
                        g.DrawLine(Pen, new PointF(R, B), new PointF(R - 5, B + 2));
                        break;
                    }
                case Path.YFU:
                    {
                        float L = 0.05F * Size;
                        float R = 0.85F * Size;
                        float CX = 0.45F * Size;
                        float T = 0.05F * Size;
                        float B = 0.95F * Size;
                        float CY = 0.5F * Size;

                        PointF[] PointFs = new PointF[6];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(L, B);
                        PointFs[2] = new PointF(CX, B);
                        PointFs[3] = new PointF(CX, T);
                        PointFs[4] = new PointF(R, T);
                        PointFs[5] = new PointF(R, B);
                        g.DrawLines(Pen, PointFs);

                        g.DrawLine(Pen, new PointF(R, B), new PointF(R - 2, B - 5));
                        g.DrawLine(Pen, new PointF(R, B), new PointF(R + 2, B - 5));
                        break;
                    }
            }
            btn.Image = bmp;
            g.Dispose();
        }

        public enum RunIcon
        {
            Lock,
            Play,
            Resume,
            Pause,
            Stop,
            Cancel,
            SlowMo,
            Dual,
            ForceSingle,
        }
        public static void ButtonDrawIcon(ref Button btn, RunIcon Icon, bool Selected)
        {
            btn.Text = "";
            int Size = (int)(0.9*btn.Height);

            Graphics g;
            Bitmap bmp = new Bitmap(Size, Size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;// QualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Color ForeColor = Color.Navy;
            Color BackColor = Color.Transparent;// SystemColors.Control;

            if (btn.Enabled)
            {
                if (Selected)
                {
                    ForeColor = SystemColors.Control;
                    BackColor = Color.Navy;
                }
                else
                {
                    ForeColor = Color.Navy;
                    BackColor = Color.Transparent;//SystemColors.Control;
                }
            }
            else
            {
                if (Selected)
                {
                    ForeColor = SystemColors.Control;
                    BackColor = Color.Gray;
                }
                else
                {
                    ForeColor = Color.Gray;
                    BackColor = Color.Transparent;// SystemColors.Control;
                }
            }

            Pen Pen = new Pen(ForeColor, 1);
            SolidBrush SBrush = new SolidBrush(ForeColor);

            g.Clear(Color.Transparent);// BackColor);
            btn.BackColor = BackColor;

            switch (Icon)
            {
                case RunIcon.Lock:
                    #region
                    {
                        float L = 0.2F * Size - 1;
                        float T = 0.45F * Size;
                        float W = 0.6F * Size;
                        float H = 0.4F * Size;

                        Pen.Width = 2;
                        g.DrawRectangle(Pen, L, T, W, H);

                        float L3 = 0.3F * Size - 1;
                        float T3 = 0.5F * Size;
                        float W3 = 0.4F * Size;
                        float H3 = 0.3F * Size;

                        Pen.Width = 1;
                        g.DrawRectangle(Pen, L3, T3, W3, H3);


                        float L1 = 0.27F * Size - 1;
                        float T1 = 0.1F * Size;
                        float W1 = 0.46F * Size;
                        float H1 = 0.46F * Size;

                        Pen.Width = 3;
                        g.DrawArc(Pen, L1, T1, W1, H1, 180F, 180F);
                        g.DrawLine(Pen, L1, T1 + H1/2 - 1, L1, T);
                        g.DrawLine(Pen, L1 + W1, T1 + H1 / 2 - 1, L1 + W1, T);

                        break;
                    }
                    #endregion
                case RunIcon.Play:
                    #region
                    {
                        Pen.Width = 1;
                        float Dia = 0.9F * Size;
                        g.DrawArc(Pen, new RectangleF((Size - Dia) / 2, (Size - Dia) / 2, Dia-1, Dia-1), 0F, 360F);

                        float L = 0.25F * Size + 2;
                        float R = 0.75F * Size - 1;
                        float CX = 0.5F * Size - 1;
                        float T = 0.25F * Size - 1;
                        float B = 0.75F * Size;
                        float CY = CX;

                        PointF[] PointFs = new PointF[3];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(R, CY);
                        PointFs[2] = new PointF(L, B);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);

                        break;
                    }
                    #endregion
                case RunIcon.Resume:
                    #region
                    {
                        Pen.Width = 1;
                        float Dia = 0.9F * Size;
                        g.DrawArc(Pen, new RectangleF((Size - Dia) / 2, (Size - Dia) / 2, Dia - 1, Dia - 1), 0F, 360F);

                        float L = 0.4F * Size + 2;
                        float R = 0.75F * Size - 1;
                        float CX = 0.5F * Size - 1;
                        float T = 0.25F * Size - 1;
                        float B = 0.75F * Size;
                        float CY = CX;

                        PointF[] PointFs = new PointF[3];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(R, CY);
                        PointFs[2] = new PointF(L, B);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);

                        L = 0.25F * Size + 2;
                        R = 0.4F * Size - 1;
                        T = 0.25F * Size - 1;
                        B = 0.75F * Size;

                        PointFs = new PointF[4];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(R, T);
                        PointFs[2] = new PointF(R, B);
                        PointFs[3] = new PointF(L, B);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);


                        break;
                    }
                    #endregion
                case RunIcon.Stop:
                    #region
                    {
                        Pen.Width = 1;
                        float Dia = 0.9F * Size;
                        g.DrawArc(Pen, new RectangleF((Size - Dia) / 2, (Size - Dia) / 2, Dia-1, Dia-1), 0F, 360F);

                        float L = 0.3F * Size - 1;
                        float R = 0.7F * Size - 1;
                        float CX = 0.5F * Size;
                        float T = L;
                        float B = R;
                        float CY = CX;

                        PointF[] PointFs = new PointF[4];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(R, T);
                        PointFs[2] = new PointF(R, B);
                        PointFs[3] = new PointF(L, B);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);

                        break;
                    }
                    #endregion
                case RunIcon.Cancel:
                    #region
                    {
                        Pen.Width = 1;
                        float Dia = 0.9F * Size;
                        g.DrawArc(Pen, new RectangleF((Size - Dia) / 2, (Size - Dia) / 2, Dia - 1, Dia - 1), 0F, 360F);

                        float L = 0.3F * Size - 1;
                        float R = 0.7F * Size - 1;
                        float CX = 0.5F * Size;
                        float T = L;
                        float B = R;
                        float CY = CX;
                        float W = 2;

                        PointF[] PointFs = new PointF[5];
                        Pen.Width = 2;

                        PointFs[0] = new PointF(L - W, T + W);
                        PointFs[1] = new PointF(L + W, T - W);
                        PointFs[2] = new PointF(R + W, B - W);
                        PointFs[3] = new PointF(R - W, B + W);
                        PointFs[4] = new PointF(L - W, T + W);
                        g.FillPolygon(SBrush, PointFs);

                        PointFs[0] = new PointF(R - W, T - W);
                        PointFs[1] = new PointF(R + W, T + W);
                        PointFs[2] = new PointF(L + W, B + W);
                        PointFs[3] = new PointF(L - W, B - W);
                        PointFs[4] = new PointF(R - W, T - W);
                        g.FillPolygon(SBrush, PointFs);
                        break;
                    }
                    #endregion
                case RunIcon.Pause:
                    #region
                    {
                        Pen.Width = 1;
                        float Dia = 0.9F * Size;
                        g.DrawArc(Pen, new RectangleF((Size - Dia) / 2, (Size - Dia) / 2, Dia-1, Dia-1), 0F, 360F);

                        float L = 0.3F * Size - 1;
                        float R = 0.45F * Size - 1;
                        float T = 0.3F * Size;
                        float B = 0.7F * Size;

                        PointF[] PointFs = new PointF[4];
                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(R, T);
                        PointFs[2] = new PointF(R, B);
                        PointFs[3] = new PointF(L, B);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);

                        L = 0.55F * Size - 1;
                        R = 0.7F * Size - 1;
                        T = 0.3F * Size;
                        B = 0.7F * Size;

                        PointFs[0] = new PointF(L, T);
                        PointFs[1] = new PointF(R, T);
                        PointFs[2] = new PointF(R, B);
                        PointFs[3] = new PointF(L, B);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);

                        break;
                    }
                    #endregion
                case RunIcon.SlowMo:
                    #region
                    {
                        float L = 0.1F * Size - 1;
                        float R = 0.9F * Size - 1;
                        float R2 = 0.85F * Size - 1;
                        float CX = 0.5F * Size;
                        float T = 0.6F * Size;
                        float B = R;
                        float CY = CX;

                        PointF[] PointFs = new PointF[3];
                        PointFs[0] = new PointF(L, B);
                        PointFs[1] = new PointF(R, T);
                        PointFs[2] = new PointF(R2, B);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);
                        float Dia = 0.12F * Size;
                        g.FillPie(SBrush, R - 2, T - 2, Dia, Dia, 0F, 360F);

                        Dia = 0.65F * Size;
                        g.FillPie(SBrush, (Size - Dia) / 2 - 5, (Size - Dia) / 2 - 1, Dia, Dia, 0F, 360F);
                        g.FillRectangle(SBrush, CX - 5, CY, Dia / 2, Dia / 2); 
                        Pen.Width = 1;
                        Pen.Color = BackColor;
                        g.DrawArc(Pen, (Size - Dia) / 2 - 5, (Size - Dia) / 2 - 1, Dia, Dia, 0F, 360F);

                        break;
                    }
                    #endregion
                case RunIcon.Dual:
                    #region
                    {
                        float L1 = 0.1F * Size - 1;
                        float R1 = 0.4F * Size - 1;
                        float T1 = 0.1F * Size;
                        float B1 = 0.9F * Size;

                        PointF[] PointFs = new PointF[5];
                        PointFs[0] = new PointF(L1, T1);
                        PointFs[1] = new PointF(L1, B1 - 10);
                        PointFs[2] = new PointF((R1 + L1)/2, B1 - 5);
                        PointFs[3] = new PointF(R1, B1 - 10);
                        PointFs[4] = new PointF(R1, T1);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);
                        g.DrawLine(Pen, PointFs[2], new PointF((R1 + L1)/2, B1));

                        float L2 = 0.6F * Size - 1;
                        float R2 = 0.9F * Size - 1;
                        float T2 = 0.1F * Size;
                        float B2 = 0.9F * Size;

                        PointFs[0] = new PointF(L2, T2);
                        PointFs[1] = new PointF(L2, B2 - 10);
                        PointFs[2] = new PointF((R2 + L2) / 2, B1-5);
                        PointFs[3] = new PointF(R2, B2 - 10);
                        PointFs[4] = new PointF(R2, T2);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);
                        g.DrawLine(Pen, PointFs[2], new PointF((R2 + L2) / 2, B2));

                        break;
                    }
                    #endregion
                case RunIcon.ForceSingle:
                    #region
                    {
                        float L1 = 0.1F * Size - 1;
                        float R1 = 0.4F * Size - 1;
                        float T1 = 0.1F * Size;
                        float B1 = 0.9F * Size;

                        PointF[] PointFs = new PointF[5];
                        PointFs[0] = new PointF(L1, T1);
                        PointFs[1] = new PointF(L1, B1 - 10);
                        PointFs[2] = new PointF((R1 + L1) / 2, B1 - 5);
                        PointFs[3] = new PointF(R1, B1 - 10);
                        PointFs[4] = new PointF(R1, T1);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);
                        g.DrawLine(Pen, PointFs[2], new PointF((R1 + L1) / 2, B1));

                        float L2 = 0.6F * Size - 1;
                        float R2 = 0.9F * Size - 1;
                        float T2 = 0.1F * Size;
                        float B2 = 0.9F * Size;

                        PointFs[0] = new PointF(L2, T2);
                        PointFs[1] = new PointF(L2, B2 - 10);
                        PointFs[2] = new PointF((R2 + L2) / 2, B1 - 5);
                        PointFs[3] = new PointF(R2, B2 - 10);
                        PointFs[4] = new PointF(R2, T2);

                        Pen.Width = 2;
                        g.FillPolygon(SBrush, PointFs);
                        g.DrawLine(Pen, PointFs[2], new PointF((R2 + L2) / 2, B2));

                        float L3 = 0.55F * Size - 1;
                        float R3 = 0.95F * Size - 1;
                        float T3 = 0.3F * Size;
                        float B3 = 0.7F * Size;
                        float W = 1.5F;
                        SBrush.Color = SystemColors.Control; ;

                        PointFs[0] = new PointF(L3 - W, T3 + W);
                        PointFs[1] = new PointF(L3 + W, T3 - W);
                        PointFs[2] = new PointF(R3 + W, B3 - W);
                        PointFs[3] = new PointF(R3 - W, B3 + W);
                        PointFs[4] = new PointF(L3 - W, T3 + W);
                        g.FillPolygon(SBrush, PointFs);

                        PointFs[0] = new PointF(R3 - W, T3 - W);
                        PointFs[1] = new PointF(R3 + W, T3 + W);
                        PointFs[2] = new PointF(L3 + W, B3 + W);
                        PointFs[3] = new PointF(L3 - W, B3 - W);
                        PointFs[4] = new PointF(R3 - W, T3 - W);
                        g.FillPolygon(SBrush, PointFs);

                        Pen.Width = 2;
                        g.DrawLine(Pen, new PointF(L3, T3), new PointF(R3, B3));
                        g.DrawLine(Pen, new PointF(R3, T3), new PointF(L3, B3));
                        break;
                    }
                    #endregion
            }
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.Image = bmp;
            g.Dispose();
        }
        public static void LabelDrawAngleAdjust(ref Label lbl, double Angle)
        {
            int FSize = Math.Min(lbl.Width, lbl.Height);
            int Size = (int)(FSize - 4);

            Graphics g;
            Bitmap bmp = new Bitmap(FSize, FSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;// QualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Color ForeColor = Color.Navy;
            Color BackColor = Color.Transparent;// SystemColors.Control;

            Pen Pen = new Pen(ForeColor, 1);
            SolidBrush SBrush = new SolidBrush(ForeColor);

            g.Clear(Color.Transparent);// BackColor);
            lbl.BackColor = BackColor;

            lbl.Text = "";
            if (Angle != 0)
            {
                double AbsAngle = Math.Abs(Angle);
                if (AbsAngle >= 360)
                {
                    int Turn = (int)(Math.Round(AbsAngle / 360));
                    lbl.Text = Turn.ToString() + "+";
                }
                else
                    lbl.Text = AbsAngle.ToString("f0");

                lbl.TextAlign = ContentAlignment.BottomRight;


                g.FillPie(SBrush, (float)2 + 5, (float)2 + 5, (float)(Size - 10), (float)(Size - 10), -90F, -(float)Angle);

                float aStart = -90F;
                float aEnd = (float)-Angle;

                if (aEnd > 0)
                {
                    PointF[] PointFs = new PointF[3];
                    PointFs[0] = new PointF(2 + Size / 2, 2);
                    PointFs[1] = new PointF(2 + Size / 2 + 8, 2 - 3);
                    PointFs[2] = new PointF(2 + Size / 2 + 8, 2 + 4);

                    Pen.Width = 1;
                    g.FillPolygon(SBrush, PointFs);
                    g.DrawArc(Pen, 2, 2, Size, Size, aStart, 315);
                }
                else
                {
                    PointF[] PointFs = new PointF[3];
                    PointFs[0] = new PointF(2 + (Size / 2), 2);
                    PointFs[1] = new PointF(2 + (Size / 2) - 8, 2 - 3);
                    PointFs[2] = new PointF(2 + (Size / 2) - 8, 2 + 4);

                    Pen.Width = 1;
                    g.FillPolygon(SBrush, PointFs);
                    g.DrawArc(Pen, 2, 2, Size, Size, aStart, -315);
                }
            }

            lbl.ImageAlign = ContentAlignment.MiddleLeft;
            lbl.Image = bmp;
            g.Dispose();
        }

        public enum EArrow
        {
            XN,
            XP,
            YN,
            YP,
            XNYN,
            XNYP,
            XPYN,
            XPYP,
            ZN,
            ZP,
            UN,
            UP,
        }

        public static void ButtonDrawArrow(ref Button Btn, EArrow Arrow, Color Color)
        {
            Graphics g;
            Bitmap bmp = new Bitmap(Btn.Width, Btn.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(bmp);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Color ArrowDrawColor = Color;

            Pen P = new Pen(ArrowDrawColor, 2);
            if (!Btn.Enabled) P.Color = Color.Gray;

            int HalfSize = (int)((double)Btn.Width * 0.25);
            int CX = Btn.Width / 2;
            int CY = Btn.Height / 2;

            switch (Arrow)
            {
                case EArrow.XN:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX - HalfSize, CY);
                        Points[1] = new Point(CX + HalfSize, CY + HalfSize);
                        Points[2] = new Point(CX + HalfSize, CY - HalfSize);
                        Points[3] = new Point(CX - HalfSize, CY);

                        g.DrawLines(P, Points);

                        break;
                    }
                    #endregion
                case EArrow.XP:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX + HalfSize, CY);
                        Points[1] = new Point(CX - HalfSize, CY + HalfSize);
                        Points[2] = new Point(CX - HalfSize, CY - HalfSize);
                        Points[3] = new Point(CX + HalfSize, CY); 

                        g.DrawLines(P, Points);

                        break;
                    }
                    #endregion
                case EArrow.YN:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX, CY + HalfSize);
                        Points[1] = new Point(CX + HalfSize, CY - HalfSize);
                        Points[2] = new Point(CX - HalfSize, CY - HalfSize);
                        Points[3] = new Point(CX, CY + HalfSize);
                        
                        g.DrawLines(P, Points);

                        break;
                    }
                    #endregion
                case EArrow.YP:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX, CY - HalfSize);
                        Points[1] = new Point(CX + HalfSize, CY + HalfSize);
                        Points[2] = new Point(CX - HalfSize, CY + HalfSize);
                        Points[3] = new Point(CX, CY - HalfSize);

                        g.DrawLines(P, Points);
                        
                        break;
                    }
                    #endregion

                case EArrow.XNYP:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX - HalfSize, CY - HalfSize);
                        Points[1] = new Point(CX + HalfSize, CY);
                        Points[2] = new Point(CX, CY + HalfSize);
                        Points[3] = new Point(CX - HalfSize, CY - HalfSize);

                        g.DrawLines(P, Points);

                        break;
                    }
                    #endregion
                case EArrow.XNYN:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX - HalfSize, CY + HalfSize);
                        Points[1] = new Point(CX, CY - HalfSize);
                        Points[2] = new Point(CX + HalfSize, CY);
                        Points[3] = new Point(CX - HalfSize, CY + HalfSize);

                        g.DrawLines(P, Points);

                        break;
                    }
                    #endregion
                case EArrow.XPYP:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX + HalfSize, CY - HalfSize);
                        Points[1] = new Point(CX, CY + HalfSize);
                        Points[2] = new Point(CX - HalfSize, CY);
                        Points[3] = new Point(CX + HalfSize, CY - HalfSize);

                        g.DrawLines(P, Points);

                        break;
                    }
                    #endregion
                case EArrow.XPYN:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX + HalfSize, CY + HalfSize);
                        Points[1] = new Point(CX, CY - HalfSize);
                        Points[2] = new Point(CX - HalfSize, CY);
                        Points[3] = new Point(CX + HalfSize, CY + HalfSize);

                        g.DrawLines(P, Points);

                        break;
                    }
                    #endregion

                case EArrow.ZN:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX, CY + HalfSize);
                        Points[1] = new Point(CX + HalfSize, CY - HalfSize + 5);
                        Points[2] = new Point(CX - HalfSize, CY - HalfSize + 5);
                        Points[3] = new Point(CX, CY + HalfSize);
                        
                        g.DrawLines(P, Points);
                        g.DrawLine(P, new Point(CX + HalfSize, CY - HalfSize), new Point(CX - HalfSize, CY - HalfSize));

                        break;
                    }
                    #endregion
                case EArrow.ZP:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX, CY - HalfSize);
                        Points[1] = new Point(CX + HalfSize, CY + HalfSize - 5);
                        Points[2] = new Point(CX - HalfSize, CY + HalfSize - 5);
                        Points[3] = new Point(CX, CY - HalfSize);
                        
                        g.DrawLines(P, Points);
                        g.DrawLine(P, new Point(CX + HalfSize, CY + HalfSize), new Point(CX - HalfSize, CY + HalfSize));

                        break;
                    }
                    #endregion
                case EArrow.UN:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX - HalfSize, CY + 5);
                        Points[1] = new Point(CX + HalfSize - 10, CY + HalfSize + 5);
                        Points[2] = new Point(CX + HalfSize - 10, CY - HalfSize + 5);
                        Points[3] = new Point(CX - HalfSize, CY + 5);

                        g.DrawLines(P, Points);
                        g.DrawLine(P, new Point(CX + HalfSize - 5, CY + HalfSize), new Point(CX + HalfSize, CY - HalfSize));

                        break;
                    }
                    #endregion
                case EArrow.UP:
                    #region
                    {
                        Point[] Points = new Point[4];
                        Points[0] = new Point(CX + HalfSize, CY + 5);
                        Points[1] = new Point(CX - HalfSize + 10, CY + HalfSize + 5);
                        Points[2] = new Point(CX - HalfSize + 10, CY - HalfSize + 5);
                        Points[3] = new Point(CX + HalfSize, CY + 5);

                        g.DrawLines(P, Points);
                        g.DrawLine(P, new Point(CX - HalfSize + 5, CY + HalfSize), new Point(CX - HalfSize, CY - HalfSize));

                        break;
                    }
                    #endregion
            }
            Btn.ImageAlign = ContentAlignment.MiddleCenter;
            Btn.Image = bmp;
            g.Dispose();
        }
        public static void ButtonDrawArrow(ref Button Btn, EArrow Arrow)
        {
            ButtonDrawArrow(ref Btn, Arrow, Color.Navy);
        }


        public static string GetKK(int value)
        {
            int a = value;
            string sa = a.ToString();
            if (a > 1000000)
            { a = a / 1000000; sa = a.ToString() + " kk"; }
            else
            if (a > 1000)
            { a = a / 1000; sa = a.ToString() + " k"; }

            return sa;
        }
    }

    public static class GuiExtensionMethods
    {
        public static void Enable(this Control con, bool enable)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    if (c is Form || c is Panel || c is GroupBox || c is SplitContainer || c is SplitterPanel || c is ListView)
                    {
                        foreach (Control c2 in c.Controls)
                        {
                            c2.Enable(enable);
                        }
                    }
                    if (c is ToolStrip)
                    {
                        foreach (ToolStripItem tsi in (c as ToolStrip).Items)
                        {
                            tsi.Enabled = enable;
                        }
                    }
                    c.Enable(enable);
                }

                try
                {
                    if (!(con is Form || con is Panel || con is GroupBox || con is SplitContainer || con is SplitterPanel || con is ToolStrip || con is ListView))
                        con.Invoke((MethodInvoker)(() => con.Enabled = enable));
                    if (con is ToolStrip)
                    {
                        foreach (ToolStripItem tsi in (con as ToolStrip).Items)
                        {
                            tsi.Enabled = enable;
                        }
                    }
                }
                catch
                {
                }
            }
        }
        public static void Enable(this ToolStripItem tsi, bool enable)
        {
            tsi.Enabled = enable;
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }

    public static class AsyncWindowExtension
    {
        public static Task<DialogResult> ShowDialogAsync(this Form self)
        {
            if (self == null) throw new ArgumentNullException("self");

            TaskCompletionSource<DialogResult> completion = new TaskCompletionSource<DialogResult>();
            self.BeginInvoke(new Action(() => completion.SetResult(self.ShowDialog())));

            return completion.Task;
        }
    }

    namespace AsyncShowDialog
    {
    }
}
