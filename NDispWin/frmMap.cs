using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Emgu.CV;

namespace NDispWin
{
    public partial class frm_DispCore_Map : Form
    {
        public bool ViewOnly = false;
        public bool AllowHide = false;
        public bool EnableEditLock = false;//Unlock map for editing
        public static int LayoutNo = 0;

        static TLayout[] LocalLayout = new TLayout[DispProg.MAX_IDS];
        class TLayoutInfo
        {
            internal double UPitch = 0;
            internal double USize = 0;
            internal int[] UX = new int[TLayout.MAX_UNITS];
            internal int[] UY = new int[TLayout.MAX_UNITS];
        }
        static TLayoutInfo[] LayoutInfo = new TLayoutInfo[DispProg.MAX_IDS];

        public frm_DispCore_Map()
        {
            InitializeComponent();
            GControl.LogForm(this);

            for (int i = 0; i < DispProg.MAX_IDS; i++)
            {
                LocalLayout[i] = new TLayout();
                LayoutInfo[i] = new TLayoutInfo();
            }
        }

        private void frmMap_Load(object sender, EventArgs e)
        {
            this.Text = "Product Map";

            AppLanguage.Func2.UpdateText(this);

            pbox_Image.Dock = DockStyle.Fill;
            pbox_Image.SizeMode = PictureBoxSizeMode.Zoom;

            pbox_Map.Dock = DockStyle.Fill;
            pbox_Map.BringToFront();
            pnl_Bottom.BringToFront();

            lbl_Close.Visible = AllowHide;
            lbl_MoveTo.Visible = AllowHide;

            EnableEditLock = GDefineN.EnableMapEditLock;
            lblEditMap.Visible = EnableEditLock;
            bMapEdit = !EnableEditLock;

            RefreshMapInfo();
        }
        private void frm_DispCore_Map_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void frm_DispCore_Map_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void RefreshMapInfo()
        {
            const int BottomPanelHeight = 20;

            for (int i = 0; i < DispProg.rt_LayoutCount; i++)
            {
                LocalLayout[i].Copy(DispProg.rt_Layouts[i]);
                LocalLayout[i].UpdateUnitLocations(pbox_Map.Width, pbox_Map.Height - BottomPanelHeight, ref LayoutInfo[i].UPitch, ref LayoutInfo[i].USize, ref LayoutInfo[i].UX, ref LayoutInfo[i].UY);
            }

            pbox_Map.Refresh();
        }
        private void DrawSelected(Label Label, bool Selected)
        {
            if (Selected)
            {
                Label.BackColor = Color.Navy;
                Label.ForeColor = this.BackColor;
            }
            else
            {
                Label.BackColor = this.BackColor;
                Label.ForeColor = Color.Navy;
            }
        }
        private void UpdateDisplay()
        {
            DrawSelected(lbl_MapCurr, Display == EDisplay.MapCurr);
            DrawSelected(lbl_MapPrev, Display == EDisplay.MapPrev);
            DrawSelected(lbl_ImgCurr, Display == EDisplay.ImgCurr);
            DrawSelected(lbl_ImgPrev, Display == EDisplay.ImgPrev);
            DrawSelected(lbl_MoveTo, b_MoveTo);
            DrawSelected(lblEditMap, bMapEdit);

            lbl_LayoutNo.Text = "ID " + LayoutNo.ToString();
        }
 
        private void frmMap_VisibleChanged(object sender, EventArgs e)
        {
            Display = EDisplay.MapCurr;
            UpdateDisplay();
            RefreshMapInfo();
        }

        private void pbox_Map_SizeChanged(object sender, EventArgs e)
        {
        }

        private void pbox_Map_Resize(object sender, EventArgs e)
        {
            RefreshMapInfo();
            pbox_Map.Refresh();
        }
        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            tmr_Display.Interval = 500;

            if (DispProg.TR_IsBusy()) b_MoveTo = false;

            if (Painting) return;

            if (Display == EDisplay.MapCurr || Display == EDisplay.MapPrev)
            {
                pbox_Map.BringToFront();
                pbox_Map.Refresh();
            }
            if (Display == EDisplay.ImgCurr)
            {
                pbox_Image.BringToFront();
                if (TaskVision.BoardImage_ID[0] != BoardImageID) PaintImage(sender);
            }
            if (Display == EDisplay.ImgPrev)
            {
                pbox_Image.BringToFront();
                if (TaskVision.PrevBoardImage_ID[0] != PrevBoardImageID) PaintImage(sender);
            }

            lblState.Text = ViewOnly ? "(View Only)" : "";
            lbl_LayoutNo.Text = "ID " + LayoutNo.ToString();
        }

        enum EDisplay { MapCurr, MapPrev, ImgCurr, ImgPrev }
        EDisplay Display = EDisplay.ImgCurr;

        bool Painting = false;

        bool DrawRC = false;
        bool DrawUnitNo = false;

        public bool bMapEdit = true;
        bool b_MoveTo = false;

        private void pbox_Map_Paint(object sender, PaintEventArgs e)
        {
            if (Painting) return;

            Painting = true;

            lbl_ReadID.Text = DispProg.rt_Read_IDs[0, 0] + (DispProg.rt_Singulated ? " Singulated" : "") + (ViewOnly ? " View Only" : "");

            EMapBin[] MapBin = new EMapBin[TLayout.MAX_UNITS];
            if (Display == EDisplay.MapPrev)
                MapBin = (EMapBin[])DispProg.Map.PrevMap[LayoutNo].Bin.Clone();
            else
                MapBin = (EMapBin[])DispProg.Map.CurrMap[LayoutNo].Bin.Clone();

            if (DispProg.rt_LayoutChanged)

            {
                RefreshMapInfo();
                DispProg.rt_LayoutChanged = false;
            }

            Brush SBrush = new SolidBrush(this.BackColor);

            e.Graphics.FillRectangle(SBrush, new Rectangle(0, 0, pbox_Map.Width - 1, pbox_Map.Height - 1));

            double USize = LayoutInfo[LayoutNo].USize;
            double UUPitch = LayoutInfo[LayoutNo].UPitch;
            {
                Pen Pen = new Pen(Color.Black);
                Brush Brush = new SolidBrush(Color.Black);
                e.Graphics.DrawString(DispProg.rt_Read_IDs[0, 0], Font, Brush, new Point(0,0));
            }

            for (int i = 0; i < LocalLayout[LayoutNo].TUCount; i++)
            {
                #region
                int X = LayoutInfo[LayoutNo].UX[i];
                int Y = LayoutInfo[LayoutNo].UY[i];

                //Pen Pen = new Pen(Color.Transparent);
                Pen Pen = new Pen(Color.Black);
                Pen = DispProg.MapColor.Pen[(byte)MapBin[i]];
           
                SBrush = DispProg.MapColor.SBrush[(byte)MapBin[i]];

                if (b_MoveTo)
                {
                    //SBrush = new SolidBrush(Color.Navy);
                    //Pen.Color = Color.Navy;
                }

                if (LocalLayout[LayoutNo].UnitNoIsNeedle2(i) && DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                {
                    Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                }
                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (LocalLayout[LayoutNo].UnitNoIsHead2(i))
                    {
                        Pen.Color = Color.SteelBlue;
                        if (LocalLayout[LayoutNo].UnitNoIsNeedle2(i) && DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                        {
                            Pen.Color = Color.SkyBlue;
                        }
                    }
                }

                Rectangle R = new Rectangle((int)(X - USize / 2), (int)(Y - USize / 2), (int)USize, (int)USize);
                e.Graphics.FillRectangle(SBrush, R);
                e.Graphics.DrawRectangle(Pen, R);

                if (MapBin[i] == EMapBin.CompleteOK || MapBin[i] == EMapBin.CompleteNG)
                { e.Graphics.DrawLine(Pen, (int)(X), (int)(Y - USize / 2), (int)(X), (int)(Y + USize / 2)); }

                switch (MapBin[i])
                {
                    case EMapBin.Continue1: break;
                    case EMapBin.Continue2:
                        e.Graphics.DrawLine(Pen, (int)(X - USize/2), (int)Y, (int)(X + USize / 2), (int)Y);
                        break;
                    case EMapBin.Continue3:
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)Y, (int)(X + USize / 2), (int)Y);
                        e.Graphics.DrawLine(Pen, (int)X, (int)Y, (int)X, (int)(Y + USize / 2));
                        break;
                    case EMapBin.Continue4:
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)Y, (int)(X + USize / 2), (int)Y);
                        e.Graphics.DrawLine(Pen, (int)X, (int)(Y - USize/2), (int)X, (int)(Y + USize / 2));
                        break;
                    case EMapBin.Continue5:
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)Y, (int)(X + USize / 2), (int)Y);
                        e.Graphics.DrawLine(Pen, (int)X, (int)(Y - USize / 2), (int)X, (int)(Y + USize / 2));
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)(Y - USize / 2), (int)X, (int)Y);
                        break;
                    case EMapBin.Continue6:
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)Y, (int)(X + USize / 2), (int)Y);
                        e.Graphics.DrawLine(Pen, (int)X, (int)(Y - USize / 2), (int)X, (int)(Y + USize / 2));
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)(Y - USize / 2), (int)X, (int)Y);
                        e.Graphics.DrawLine(Pen, (int)(X + USize / 2), (int)(Y - USize / 2), (int)X, (int)Y);
                        break;
                    case EMapBin.Continue7:
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)Y, (int)(X + USize / 2), (int)Y);
                        e.Graphics.DrawLine(Pen, (int)X, (int)(Y - USize / 2), (int)X, (int)(Y + USize / 2));
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)(Y - USize / 2), (int)(X + USize / 2), (int)(Y + USize / 2));
                        e.Graphics.DrawLine(Pen, (int)(X + USize / 2), (int)(Y - USize / 2), (int)X, (int)Y);
                        break;
                    case EMapBin.Continue8:
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)Y, (int)(X + USize / 2), (int)Y);
                        e.Graphics.DrawLine(Pen, (int)X, (int)(Y - USize / 2), (int)X, (int)(Y + USize / 2));
                        e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)(Y - USize / 2), (int)(X + USize / 2), (int)(Y + USize / 2));
                        e.Graphics.DrawLine(Pen, (int)(X + USize / 2), (int)(Y - USize / 2), (int)(X - USize / 2), (int)(Y + USize / 2));
                        break;
                }

                if (DrawRC)
                {
                    float Size = Math.Max(2, (float)(USize / 2.5));
                    if (Size > 12) Size = 12;

                    if (Size > 3)
                    {
                        Font Font = new Font(FontFamily.GenericSansSerif, Size);
                        Brush Brush = new SolidBrush(Color.Black);

                        int UColNo = 0;
                        int URowNo = 0;
                        int CColNo = 0;
                        int CRowNo = 0;
                        int ColNo = 0;
                        int RowNo = 0;
                        LocalLayout[LayoutNo].UnitNoGetRC(i, ref UColNo, ref URowNo, ref CColNo, ref CRowNo);
                        LocalLayout[LayoutNo].UnitNoGetRC(i, ref ColNo, ref RowNo);

                        if (
                            (LocalLayout[LayoutNo].UColPX >= 0 && UColNo == 0) ||
                            (LocalLayout[LayoutNo].UColPX < 0 && UColNo == LocalLayout[LayoutNo].UColCount - 1 && CColNo == LocalLayout[LayoutNo].CColCount - 1))
                        {
                            Rectangle Rect = new Rectangle((int)(X - USize * 3 / 2 - 1), (int)(Y - USize / 2), (int)(USize), (int)(USize));
                            StringFormat SF = new StringFormat();
                            SF.Alignment = StringAlignment.Far;
                            SF.LineAlignment = StringAlignment.Center;
                            e.Graphics.DrawString((RowNo + 1).ToString(), Font, Brush, Rect, SF);
                        }
                        if (
                            (LocalLayout[LayoutNo].UColPX >= 0 && UColNo == LocalLayout[LayoutNo].UColCount - 1 && CColNo == LocalLayout[LayoutNo].CColCount - 1) ||
                            (LocalLayout[LayoutNo].UColPX < 0 && UColNo == 0)
                        )
                        {
                            Rectangle Rect = new Rectangle((int)(X + USize / 2 + 1), (int)(Y - USize / 2), (int)(USize), (int)(USize));
                            StringFormat SF = new StringFormat();
                            SF.Alignment = StringAlignment.Near;
                            SF.LineAlignment = StringAlignment.Center;
                            e.Graphics.DrawString((RowNo + 1).ToString(), Font, Brush, Rect, SF);
                        }
                        if (
                            (LocalLayout[LayoutNo].URowPY >= 0 && URowNo == 0) ||
                            (LocalLayout[LayoutNo].URowPY < 0 && URowNo == LocalLayout[LayoutNo].URowCount - 1 && CRowNo == LocalLayout[LayoutNo].CRowCount - 1)
                            )
                        {
                            Rectangle Rect = new Rectangle((int)(X - USize / 2), (int)(Y - USize * 3 / 2 - 1), (int)(USize), (int)(USize));
                            StringFormat SF = new StringFormat();
                            SF.Alignment = StringAlignment.Center;
                            SF.LineAlignment = StringAlignment.Far;
                            e.Graphics.DrawString((ColNo + 1).ToString(), Font, Brush, Rect, SF);
                        }
                        if (
                            (LocalLayout[LayoutNo].URowPY >= 0 && URowNo == LocalLayout[LayoutNo].URowCount - 1 && CRowNo == LocalLayout[LayoutNo].CRowCount - 1) ||
                            (LocalLayout[LayoutNo].URowPY < 0 && URowNo == 0)
                            )
                        {
                            Rectangle Rect = new Rectangle((int)(X - USize / 2), (int)(Y + USize / 2 + 2), (int)(USize), (int)(USize));
                            StringFormat SF = new StringFormat();
                            SF.Alignment = StringAlignment.Center;
                            SF.LineAlignment = StringAlignment.Near;
                            e.Graphics.DrawString((ColNo + 1).ToString(), Font, Brush, Rect, SF);
                        }
                    }
                }
                if (DrawUnitNo)
                {
                    float Size = Math.Max(2, (float)(USize / 2.9));
                    if (Size > 12) Size = 12;

                    if (Size > 3)
                    {
                        Font Font = new Font(FontFamily.GenericSansSerif, Size);
                        Brush Brush = new SolidBrush(Color.DimGray);
                        StringFormat SF = new StringFormat();
                        SF.Alignment = StringAlignment.Center;
                        SF.LineAlignment = StringAlignment.Center;
                        e.Graphics.DrawString(i.ToString(), Font, Brush, R, SF);
                    }
                }

                Thread.Sleep(0);
                #endregion
            }
            for (int i = 0; i < LocalLayout[LayoutNo].TUCount; i++)//display unit RC
            {
                #region
                int X = LayoutInfo[LayoutNo].UX[i];
                int Y = LayoutInfo[LayoutNo].UY[i];

                int X1 = (int)(X - USize / 2);
                int Y1 = (int)(Y - USize / 2);
                int X2 = (int)(X + USize / 2);
                int Y2 = (int)(Y + USize / 2);

                if (PtMove.X >= X1 && PtMove.X <= X2 && PtMove.Y >= Y1 && PtMove.Y <= Y2)
                {
                    int ColNo = 0;
                    int RowNo = 0;
                    LocalLayout[LayoutNo].UnitNoGetRC(i, ref ColNo, ref RowNo);

                    PointF Pt = PtMove;

                    StringFormat SF = new StringFormat();
                    if (PtMove.X < pbox_Map.Width / 2)
                        SF.Alignment = StringAlignment.Near;
                    else
                        SF.Alignment = StringAlignment.Far;

                    if (PtMove.Y < (pbox_Map.Height - 20) / 2)
                        SF.LineAlignment = StringAlignment.Near;
                    else
                        SF.LineAlignment = StringAlignment.Far;

                    if (PtMove.X < pbox_Map.Width / 2 && PtMove.Y < (pbox_Map.Height - 20) / 2)
                    {
                        Pt.X = Pt.X + 10;
                        Pt.Y = Pt.Y + 10;
                    }


                    Font Font = new Font(FontFamily.GenericSansSerif, 12);
                    Brush Brush = new SolidBrush(Color.White);
                    e.Graphics.DrawString((ColNo + 1).ToString() + "," + (RowNo + 1).ToString(), Font, Brush, new PointF(Pt.X + 1, Pt.Y + 1), SF);
                    e.Graphics.DrawString((ColNo + 1).ToString() + "," + (RowNo + 1).ToString(), Font, Brush, new PointF(Pt.X - 1, Pt.Y - 1), SF);
                    Font = new Font(FontFamily.GenericSansSerif, 12);
                    Brush = new SolidBrush(Color.Maroon);
                    e.Graphics.DrawString((ColNo + 1).ToString() + "," + (RowNo + 1).ToString(), Font, Brush, Pt, SF);
                }
                Thread.Sleep(0);
                #endregion
            }

            if (MouseDn)
            {
                    Pen Pen = new Pen(Color.Black);
                    e.Graphics.DrawRectangle(Pen, SelectRect);
            }

            Painting = false;
        }

        List<int> SelectedIndex = new List<int>();
        Point PtDown = new Point(0, 0);
        Point PtMove = new Point(0, 0);
        Rectangle SelectRect = new Rectangle();
        bool SelectionInProgress = false;
        static bool MouseDn = false;
        private void pbox_Map_MouseDown(object sender, MouseEventArgs e)
        {
            if (ViewOnly) return;
            if (!bMapEdit) return;
            if (b_MoveTo) return;
            if (Display != EDisplay.MapCurr) return;

            MouseDn = true;
            PtDown = e.Location;

            SelectRect = new Rectangle(PtDown.X, PtDown.Y, 0, 0);

            UpdateDisplay();
        }
        private void pbox_Map_MouseUp(object sender, MouseEventArgs e)
        {
            if (ViewOnly) return;
            if (!bMapEdit) return;
            if (b_MoveTo) return;
            if (Display != EDisplay.MapCurr) return;

            MouseDn = false;
            Point PtUp = e.Location;

            double USize = LayoutInfo[LayoutNo].USize;
            double UUPitch = LayoutInfo[LayoutNo].UPitch;

            for (int i = 0; i < LocalLayout[LayoutNo].TUCount; i++)
            {
                #region
                int X = LayoutInfo[LayoutNo].UX[i];
                int Y = LayoutInfo[LayoutNo].UY[i];

                int XTL = (int)(X - USize / 2);
                int YTL = (int)(Y - USize / 2);
                int XTR = (int)(X + USize / 2);
                int YTR = (int)(Y - USize / 2);
                int XBL = (int)(X - USize / 2);
                int YBL = (int)(Y + USize / 2);
                int XBR = (int)(X + USize / 2);
                int YBR = (int)(Y + USize / 2);

                Point unitTL = new Point((int)(X - USize / 2), (int)(Y - USize / 2));
                Point unitBR = new Point((int)(X + USize / 2), (int)(Y + USize / 2));
                
                Rectangle unit = new Rectangle((int)(X - USize / 2), (int)(Y - USize / 2), (int)USize, (int)USize);

                //Comparing Left and Right border for intersection, the Top and Bottom. 
                if ((Math.Max(unit.X, SelectRect.X) < Math.Min(unit.X + USize, SelectRect.X + SelectRect.Width)
                    && Math.Max(unit.Y, SelectRect.Y) < Math.Min(unit.Y + USize, SelectRect.Y + SelectRect.Height)))
                //if ((XTL >= SelectRect.X && XTL <= SelectRect.X + SelectRect.Width && YTL >= SelectRect.Y && YTL <= SelectRect.Y + SelectRect.Height) ||
                //    (XTR >= SelectRect.X && XTR <= SelectRect.X + SelectRect.Width && YTR >= SelectRect.Y && YTR <= SelectRect.Y + SelectRect.Height) ||
                //    (XBL >= SelectRect.X && XBL <= SelectRect.X + SelectRect.Width && YBL >= SelectRect.Y && YBL <= SelectRect.Y + SelectRect.Height) ||
                //    (XBR >= SelectRect.X && XBR <= SelectRect.X + SelectRect.Width && YBR >= SelectRect.Y && YBR <= SelectRect.Y + SelectRect.Height))
                {
                    if (DispProg.Map.CurrMap[LayoutNo].Bin[i] == EMapBin.PreMapNG) continue;

                    //if (DispProg.LastLine > 0)
                    //{
                    //    if (DispProg.Map.CurrMap[LayoutNo].Bin[i] < EMapBin.BinNG)
                    //        DispProg.Map.CurrMap[LayoutNo].Bin[i] = EMapBin.Bypass;
                    //}
                    else
                    {
                        if (DispProg.Map.CurrMap[LayoutNo].Bin[i] == EMapBin.Bypass)
                            DispProg.Map.CurrMap[LayoutNo].Bin[i] = EMapBin.None;
                        else
                            DispProg.Map.CurrMap[LayoutNo].Bin[i] = EMapBin.Bypass;
                    }
                }

                if (DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                {
                    int i2 = 0;
                    if (!LocalLayout[LayoutNo].UnitNoIsNeedle2(i))
                    {
                        LocalLayout[LayoutNo].UnitNoGetNeedle2UnitNo(i, ref i2);
                    }
                    else
                    {
                        LocalLayout[LayoutNo].UnitNoGetNeedle1UnitNo(i, ref i2);
                    }

                    DispProg.Map.CurrMap[LayoutNo].Bin[i2] = DispProg.Map.CurrMap[LayoutNo].Bin[i];
                }
                #endregion
            }
            SelectRect = new Rectangle(0, 0, 0, 0);
            SelectionInProgress = false;
            pbox_Map.Refresh();
        }
        private void pbox_Map_MouseMove(object sender, MouseEventArgs e)
        {
            double USize = LayoutInfo[LayoutNo].USize;
            double UPitch = LayoutInfo[LayoutNo].UPitch;

            if (Display != EDisplay.MapCurr) return;

            PtMove = e.Location;

            if (MouseDn &&
                ((Math.Abs(PtMove.X - PtDown.X) > UPitch) || (Math.Abs(PtMove.Y - PtDown.Y) > UPitch)))
            {
                SelectRect = new Rectangle(Math.Min(PtDown.X, PtMove.X), Math.Min(PtDown.Y, PtMove.Y),
                    Math.Max(PtDown.X, PtMove.X) - Math.Min(PtDown.X, PtMove.X), Math.Max(PtDown.Y, PtMove.Y) - Math.Min(PtDown.Y, PtMove.Y));

                SelectionInProgress = true;
                UpdateDisplay();
            }

            pbox_Map.Refresh();
        }
        private void pbox_Map_MouseClick(object sender, MouseEventArgs e)
        {
            if (ViewOnly) return;
            if (!bMapEdit) return;

            double USize = LayoutInfo[LayoutNo].USize;
            double UUPitch = LayoutInfo[LayoutNo].UPitch;

            if (b_MoveTo)
            {
                #region
                for (int i = 0; i < LocalLayout[LayoutNo].TUCount; i++)
                {
                    int X = LayoutInfo[LayoutNo].UX[i];
                    int Y = LayoutInfo[LayoutNo].UY[i];

                    int X1 = (int)(X - USize / 2);
                    int Y1 = (int)(Y - USize / 2);
                    int X2 = (int)(X + USize / 2);
                    int Y2 = (int)(Y + USize / 2);

                    if (e.X >= X1 && e.X <= X2 && e.Y >= Y1 && e.Y <= Y2)
                    {
                        DispProg.Script[0].MoveTo(i);
                        break;
                    }
                }
                UpdateDisplay();
                return;
                #endregion
            }

            if (Display != EDisplay.MapCurr) return;

            if (SelectionInProgress) return;

            for (int i = 0; i < LocalLayout[LayoutNo].TUCount; i++)
            {
                int X = LayoutInfo[LayoutNo].UX[i];
                int Y = LayoutInfo[LayoutNo].UY[i];

                int X1 = (int)(X - USize / 2);
                int Y1 = (int)(Y - USize / 2);
                int X2 = (int)(X + USize / 2);
                int Y2 = (int)(Y + USize / 2);

                if (e.X >= X1 && e.X <= X2 && e.Y >= Y1 && e.Y <= Y2)
                {
                    if (DispProg.Map.CurrMap[LayoutNo].Bin[i] == EMapBin.PreMapNG) continue;

                    //if (DispProg.LastLine > 0)
                    //{
                    //    if (DispProg.Map.CurrMap[LayoutNo].Bin[i] < EMapBin.BinNG)
                    //        DispProg.Map.CurrMap[LayoutNo].Bin[i] = EMapBin.Bypass;
                    //}
                    //else
                    {
                        if (DispProg.Map.CurrMap[LayoutNo].Bin[i] == EMapBin.Bypass)
                            DispProg.Map.CurrMap[LayoutNo].Bin[i] = EMapBin.None;
                        else
                            DispProg.Map.CurrMap[LayoutNo].Bin[i] = EMapBin.Bypass;
                    }

                    if (DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                    {
                        int i2 = 0;
                        if (!LocalLayout[LayoutNo].UnitNoIsNeedle2(i))
                        {
                            LocalLayout[LayoutNo].UnitNoGetNeedle2UnitNo(i, ref i2);
                        }
                        else
                        {
                            LocalLayout[LayoutNo].UnitNoGetNeedle1UnitNo(i, ref i2);
                        }

                        DispProg.Map.CurrMap[LayoutNo].Bin[i2] = DispProg.Map.CurrMap[LayoutNo].Bin[i];
                    }
                }
            }
            pbox_Map.Refresh();
        }
        private void pbox_Map_DoubleClick(object sender, EventArgs e)
        {
        }

        int BoardImageID = -1;
        int PrevBoardImageID = -1;
        private void PaintImage(object sender)
        {
            pbox_Image.BringToFront();

            if (Display == EDisplay.ImgCurr)
                if (TaskVision.BoardImage[0] != null)
                {
                    pbox_Image.Image = TaskVision.BoardImage[0].ToBitmap();
                    BoardImageID = TaskVision.BoardImage_ID[0];
                }
                else
                {
                    BoardImageID = TaskVision.BoardImage_ID[0];
                    pbox_Image.Refresh();
                }

            if (Display == EDisplay.ImgPrev)
            {
                if (TaskVision.PrevBoardImage[0] != null)
                {
                    pbox_Image.Image = TaskVision.PrevBoardImage[0].ToBitmap();
                    PrevBoardImageID = TaskVision.PrevBoardImage_ID[0];
                }
                else
                {
                    PrevBoardImageID = TaskVision.PrevBoardImage_ID[0];
                    pbox_Image.Refresh();
                }
            }
        }

        private void lbl_MapPrev_Click(object sender, EventArgs e)
        {
            b_MoveTo = false;
            Display = EDisplay.MapPrev;
            UpdateDisplay();
        }
        private void lbl_MapCurr_Click(object sender, EventArgs e)
        {
            b_MoveTo = false;
            Display = EDisplay.MapCurr;
            UpdateDisplay();
        }
        private void lbl_ImgCurr_Click(object sender, EventArgs e)
        {
            b_MoveTo = false;
            Display = EDisplay.ImgCurr;
            PaintImage(sender);
            UpdateDisplay();
        }
        private void lbl_ImgPrev_Click(object sender, EventArgs e)
        {
            b_MoveTo = false;
            Display = EDisplay.ImgPrev;
            PaintImage(sender);
            UpdateDisplay();
        }

        private void lbl_123_Click(object sender, EventArgs e)
        {
            if (!DrawRC && !DrawUnitNo)
            {
                DrawRC = true;
                return;
            }

            if (DrawRC && !DrawUnitNo)
            {
                DrawRC = false;
                DrawUnitNo = true;
                return;
            }

            if (!DrawRC && DrawUnitNo)
            {
                DrawRC = true;
                DrawUnitNo = true;
                return;
            }

            if (DrawRC && DrawUnitNo)
            {
                DrawRC = false;
                DrawUnitNo = false;
                return;
            }
        }
        private void lbl_Clear_Click(object sender, EventArgs e)
        {
            if (ViewOnly) return;

            SelectedIndex.Clear();
            for (int i = 0; i < LocalLayout[LayoutNo].TUCount; i++)
            {
                if (DispProg.Map.CurrMap[LayoutNo].Bin[i] == EMapBin.PreMapNG) continue;
                DispProg.Map.CurrMap[LayoutNo].Bin[i] = EMapBin.None;
            }
            UpdateDisplay();
            pbox_Map.Refresh();
        }
        private void lbl_MoveTo_Click(object sender, EventArgs e)
        {
            if (DispProg.TR_IsBusy()) return;

            b_MoveTo = !b_MoveTo;
            Display = EDisplay.MapCurr;
            UpdateDisplay();
        }
        private void lbl_LayoutNo_Click(object sender, EventArgs e)
        {
            if (LayoutNo < DispProg.rt_LayoutCount - 1)
                LayoutNo++;
            else
                LayoutNo = 0;
            UpdateDisplay();
        }

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            b_MoveTo = false;
            this.Visible = false;
        }

        private void lblEditMap_Click(object sender, EventArgs e)
        {
            bMapEdit = !bMapEdit;
            UpdateDisplay();
        }
    }
}
