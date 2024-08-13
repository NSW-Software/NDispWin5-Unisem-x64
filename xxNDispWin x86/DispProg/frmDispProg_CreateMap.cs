using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_CreateMap : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        private SelectBox selectBox;
        private bool readOnly = false;
        private bool showSelectBox = false;
        private bool showHandles = true;
        enum EMode { None, Pattern, Outline };
        private EMode Mode = EMode.None;

        public frm_DispCore_DispProg_CreateMap()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            pbox_Image.SizeMode = PictureBoxSizeMode.Normal;
            pbox_Image.Dock = DockStyle.None;
            pbox_Image.SizeMode = PictureBoxSizeMode.AutoSize;
            pbox_Image.MouseMove += new MouseEventHandler(pbox_Image_MouseMove);
            pbox_Image.MouseDown += new MouseEventHandler(pbox_Image_MouseDown);
            pbox_Image.MouseUp += new MouseEventHandler(pbox_Image_MouseUp);

            this.selectBox = new SelectBox(this, new Rectangle(120, 120, 50, 50));
            this.selectBox.AddHandle(new HandleMove());
            //this.selectBox.AddHandle(new HandleResizeNWSE());
            this.selectBox.AddHandle(new HandleResizeNorth());
            this.selectBox.AddHandle(new HandleResizeSouth());
            this.selectBox.AddHandle(new HandleResizeEast());
            this.selectBox.AddHandle(new HandleResizeWest());
            this.selectBox.AddHandle(new HandleResizeNE());
            this.selectBox.AddHandle(new HandleResizeNW());
            this.selectBox.AddHandle(new HandleResizeSE());
            this.selectBox.AddHandle(new HandleResizeSW());
            this.selectBox.OnBoxChanged += new EventHandler(selectBox_OnBoxChanged);
        }

        private void EnableControl(bool Enable, Button Button1, Button Button2)
        {
            for (int i = 0; i <= Controls.Count - 1; i++)
            {
                if (Controls[i] is Button)
                {
                    (Controls[i] as Button).Enabled = Enable;
                }
                if (Controls[i] is GroupBox)
                {
                    for (int j = 0; j <= Controls[i].Controls.Count - 1; j++)
                    {
                        if (Controls[i].Controls[j] is Button)
                        {
                            (Controls[i].Controls[j] as Button).Enabled = Enable;
                        }
                    }
                }
            }
            Button1.Enabled = true;
            Button2.Enabled = true;
        }
        private void EnableControl()
        {
            EnableControl(true, btn_Learn, btn_Learn);
        }

        private void SetSelected(object sender, bool Selected)
        {
            if (Selected)
            {
                (sender as Button).BackColor = Color.Navy;
                (sender as Button).ForeColor = this.BackColor;
            }
            else
            {
                (sender as Button).BackColor = this.BackColor;
                (sender as Button).ForeColor = Color.Navy;
            }
        }

        private void UpdateDisplay()
        {
            lbl_LayoutID.Text = CmdLine.IPara[0].ToString();
            lbl_ImageID.Text = CmdLine.IPara[1].ToString();

            lbl_Mode.Text = Enum.GetName(typeof(ECMMethod), CmdLine.IPara[2]);

            SetSelected(btn_Pattern, Mode == EMode.Pattern);
            SetSelected(btn_Outline, Mode == EMode.Outline);

            lbl_Score.Text = (CmdLine.DPara[0] * 100).ToString();
            gbox_PatternSettings.Visible = CmdLine.IPara[2] == (int)ECMMethod.Pattern;

            lbl_Thld.Text = CmdLine.IPara[10].ToString();
            lbl_MinPixel.Text = (CmdLine.DPara[10] * 100).ToString("f1");
            gbox_BinarySettings.Visible = CmdLine.IPara[2] == (int)ECMMethod.Binary;
            lbl_Ref.Text = (DispProg.rt_RefWhitePixelPcnt * 100).ToString("f1") + ", " +
                (DispProg.rt_MinWhitePixelPcnt * 100).ToString("f1") + ", " +
                (DispProg.rt_MaxWhitePixelPcnt * 100).ToString("f1");
            lbl_OKMinMax.Text = DispProg.rt_GenMap_OKCount.ToString() + ", " +
                (DispProg.rt_OKMinWhitePixelPcnt * 100).ToString("f1") + ", " +
                (DispProg.rt_OKMaxWhitePixelPcnt * 100).ToString("f1");
            lbl_NGMinMax.Text = DispProg.rt_GenMap_NGCount.ToString() + ", " +
                (DispProg.rt_NGMinWhitePixelPcnt * 100).ToString("f1") + ", " +
                (DispProg.rt_NGMaxWhitePixelPcnt * 100).ToString("f1");

            lbl_OKYield.Text = (CmdLine.DPara[4] * 100).ToString();
            lbl_CurrentOKYield.Text = (((double)DispProg.rt_GenMap_OKCount / (DispProg.rt_GenMap_OKCount + DispProg.rt_GenMap_NGCount)) * 100).ToString("f1");
        }

        private void SelectImage()
        {
            if (TaskVision.BoardImage[CmdLine.IPara[1]] != null)
            {
                LocalImgG = TaskVision.BoardImage[CmdLine.IPara[1]].Clone();
                TempLocalImgG = LocalImgG.Clone();

                pbox_Image.Image = TempLocalImgG.ToBitmap();
            }
            else
            {
                Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> Img = null;
                Img = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte>(pbox_Image.Width, pbox_Image.Height);
                VisUtils.DrawText(Img, new Point(5, 5), "No Image", 10, Color.Red);
                pbox_Image.Image = Img.ToBitmap();
                Img.Dispose();
            }

            if (TaskVision.CreateMapTemplate.Image != null)
            {
                pbox_CreateMapTemplate.Image = TaskVision.CreateMapTemplate.Image.ToBitmap();
            }
            else
            {
                Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> Img = null;
                Img = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte>(pbox_CreateMapTemplate.Width, pbox_CreateMapTemplate.Height);
                VisUtils.DrawText(Img, new Point(5, 5), "No Image", 10, Color.Red);
                pbox_CreateMapTemplate.Image = Img.ToBitmap();
                Img.Dispose();
            }
        }

        TLayout InLayout = new TLayout();
        private void UpdateLayout()
        {
            for (int i = 0; i < DispProg.TCmdList.MAX_CMD; i++)
            {
                if (DispProg.Script[0].CmdList.Line[i].Cmd == DispProg.ECmd.LAYOUT &&
                  CmdLine.IPara[0] == DispProg.Script[0].CmdList.Line[i].ID)
                {
                    InLayout = new TLayout(DispProg.Script[0].CmdList.Line[i]);// DispProg.rt_Layout);
                    //MapBin = (EMapBin[])DispProg.rt_Layouts[DispProg.rt_LayoutID].PreMap.Bin.Clone();
                    MapBin = (EMapBin[])DispProg.Map.PreMap[DispProg.rt_LayoutID].Bin.Clone();
                    break;
                }
            }
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_CreateMap_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            this.Text = CmdName;

            SelectImage();
            UpdateLayout();

            ViewZoom();
            UpdateDisplay();
        }

        private void frmDispProg_CreateMap_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmDispProg_CreateMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void frmDispProg_CreateMap_VisibleChanged(object sender, EventArgs e)
        {
            //if (!Visible) return;

            //CmdLine = DispProg.Script[ProgNo].CmdList.Line[LineNo];
            //this.Text = "Command - " + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Cmd).ToString();

            //UpdateDisplay();
        }

        Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> LocalImgG = null;
        Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> TempLocalImgG = null;
        Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> LocalImgC = null;


        #region Para
        private void lbl_LayoutID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", LayoutID", ref CmdLine.IPara[0], 0, DispProg.MAX_IDS);
            UpdateLayout();
            UpdateDisplay();
        }
        private void lbl_ImageID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", ImageID", ref CmdLine.IPara[1], 0, TaskVision.MAX_BOARD_ID);
            SelectImage();
            UpdateDisplay();
            RefreshImage();
        }
        #endregion

        #region Select
        public Rectangle SelectionRect
        {
            get
            {
                double MagRatio = 1;
                if (PyrRatio > 0)
                    MagRatio = Math.Pow(2, PyrRatio);
                if (PyrRatio < 0)
                    MagRatio = 1 / Math.Pow(2, -PyrRatio);

                Rectangle Rect = new Rectangle
                (
                    (int)(selectBox.Rect.Location.X / MagRatio),
                    (int)(selectBox.Rect.Location.Y / MagRatio),
                    (int)(selectBox.Rect.Width / MagRatio),
                    (int)(selectBox.Rect.Height / MagRatio));

                return Rect;
            }
            set
            {
                double MagRatio = 1;
                if (PyrRatio > 0)
                    MagRatio = Math.Pow(2, PyrRatio);
                if (PyrRatio < 0)
                    MagRatio = 1 / Math.Pow(2, -PyrRatio);

                selectBox.Rect = new Rectangle(
                    (int)(value.Location.X * MagRatio),
                    (int)(value.Location.Y * MagRatio),
                    (int)(value.Width * MagRatio),
                    (int)(value.Height * MagRatio));

                Invalidate();
            }
        }
        public RectangleF SelectionRectF
        {
            get
            {
                double MagRatio = 1;
                if (PyrRatio > 0)
                    MagRatio = Math.Pow(2, PyrRatio);
                if (PyrRatio < 0)
                    MagRatio = 1 / Math.Pow(2, -PyrRatio);

                RectangleF Rect = new RectangleF
                (
                    (float)(selectBox.Rect.Location.X / MagRatio),
                    (float)(selectBox.Rect.Location.Y / MagRatio),
                    (float)(selectBox.Rect.Width / MagRatio),
                    (float)(selectBox.Rect.Height / MagRatio));
                return Rect;
            }
            set
            {
                double MagRatio = 1;
                if (PyrRatio > 0)
                    MagRatio = Math.Pow(2, PyrRatio);
                if (PyrRatio < 0)
                    MagRatio = 1 / Math.Pow(2, -PyrRatio);

                selectBox.Rect = new RectangleF(
                    (float)(value.Location.X * MagRatio),
                    (float)(value.Location.Y * MagRatio),
                    (float)(value.Width * MagRatio),
                    (float)(value.Height * MagRatio));

                Invalidate();
            }
        }
        public bool ReadOnly
        {
            get { return readOnly; }

            set
            {
                readOnly = value;
                Invalidate();
            }
        }

        void pbox_Image_MouseUp(object sender, MouseEventArgs e)
        {
            if (readOnly) return;
            selectBox.OnMouseUp(e);
        }

        void pbox_Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (readOnly) return;
            selectBox.OnMouseDown(e);
        }

        void pbox_Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (readOnly) return;
            selectBox.OnMouseMove(e);
        }
        private void pbox_Image_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        public event EventHandler SelectionChanged;
        void selectBox_OnBoxChanged(object sender, EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }

        /// <summary>
        /// Select Box
        /// </summary>
        public class SelectBox
        {
            public RectangleF Rect;

            private List<SelectBoxHandle> handles = new List<SelectBoxHandle>();
            Control parent;
            SelectBoxHandle activeHandle = null;

            public SelectBox(Control parent, Rectangle rect)
            {
                this.Rect = rect;
                this.parent = parent;
            }

            public void AddHandle(SelectBoxHandle handle)
            {
                handle.SelectBox = this;
                handles.Add(handle);
            }

            public virtual void OnPaint(PaintEventArgs pe, bool drawHandles)
            {
                Pen p = new Pen(Brushes.DarkBlue, 2.0f);

                pe.Graphics.DrawRectangle(p, this.Rect.X, this.Rect.Y, this.Rect.Width, this.Rect.Height);

                if (drawHandles)
                {
                    foreach (SelectBoxHandle sbh in handles)
                        sbh.OnPaint(pe);
                }
            }

            public bool HitTest(int x, int y)
            {
                return this.Rect.Contains(x, y);
            }

            public virtual void OnMouseMove(MouseEventArgs e)
            {
                bool cursorChanged = false;

                foreach (SelectBoxHandle sbh in handles)
                {
                    if (sbh.HitTest(e.X, e.Y))
                    {
                        parent.Cursor = sbh.Cursor;
                        cursorChanged = true;
                    }
                }

                if (!cursorChanged)
                {
                    parent.Cursor = Cursors.Default;
                }

                if (activeHandle != null)
                {
                    activeHandle.OnDragging(e);
                }
            }

            public virtual void OnMouseDown(MouseEventArgs e)
            {
                foreach (SelectBoxHandle sbh in handles)
                {
                    if (sbh.HitTest(e.X, e.Y))
                    {
                        activeHandle = sbh;
                    }
                }

                if (activeHandle != null)
                {
                    activeHandle.OnDragStart(e);
                }
            }

            public virtual void OnMouseUp(MouseEventArgs e)
            {
                if (activeHandle != null)
                {
                    activeHandle.OnDragEnd(e);
                    activeHandle = null;

                    if (OnBoxChanged != null)
                        OnBoxChanged(this, null);
                }
            }
            public Control Parent
            {
                get { return parent; }
            }

            public event EventHandler OnBoxChanged;
        }

        /// <summary>
        /// SelectBox Handle
        /// </summary>
        public abstract class SelectBoxHandle
        {
            public const int INFLATE_SIZE = 2;
            private SelectBox sb = null;

            public SelectBox SelectBox
            {
                get { return this.sb; }
                set { this.sb = value; }
            }

            public abstract Rectangle HandleRect { get; }
            public abstract Cursor Cursor { get; }
            public abstract void OnPaint(PaintEventArgs pe);

            public bool HitTest(int x, int y)
            {
                Rectangle inflated = HandleRect;
                inflated.Inflate(INFLATE_SIZE, INFLATE_SIZE);
                return (inflated.Contains(x, y));
            }

            public virtual void OnDragStart(MouseEventArgs e) { }
            public virtual void OnDragEnd(MouseEventArgs e) { }
            public virtual void OnDragging(MouseEventArgs e) { }
        }

        public abstract class HandleResize : SelectBoxHandle
        {
            public const int HANDLE_SIZE = 6;

            public override void OnPaint(PaintEventArgs pe)
            {
                pe.Graphics.FillRectangle(Brushes.White, HandleRect);
                pe.Graphics.DrawRectangle(Pens.Black, HandleRect);
            }

            public override Rectangle HandleRect
            {
                get
                {
                    return new Rectangle(new Point(
                      Position.X - HANDLE_SIZE / 2,
                      Position.Y - HANDLE_SIZE / 2),
                      new Size(HANDLE_SIZE, HANDLE_SIZE));
                }
            }

            protected abstract Point Position { get; }
        }

        //public class HandleResizeNWSE : HandleResize
        //{
        //    public override Cursor Cursor { get { return Cursors.SizeNWSE; } }
        //    protected override Point Position { get { return new Point((int)SelectBox.Rect.Right, (int)SelectBox.Rect.Bottom); } }

        //    public override void OnDragging(MouseEventArgs e)
        //    {
        //        SelectBox.Rect.Width = e.X - SelectBox.Rect.X;
        //        SelectBox.Rect.Height = e.Y - SelectBox.Rect.Y;
        //        SelectBox.Parent.Invalidate();
        //        SelectBox.Parent.Refresh();

        //    }
        //}

        private class HandleResizeNorth : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeNS; } }
            protected override Point Position { get { return new Point((int)(SelectBox.Rect.Left + SelectBox.Rect.Width / 2), (int)SelectBox.Rect.Top); } }

            Point dragStart;
            Size sizeStart;
            public override void OnDragStart(MouseEventArgs e)
            {
                dragStart = new Point(e.X, e.Y);
                sizeStart = new Size((int)SelectBox.Rect.Width, (int)SelectBox.Rect.Height);
            }
            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.Y = e.Y;
                SelectBox.Rect.Height = sizeStart.Height + (dragStart.Y - e.Y);
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        public class HandleResizeEast : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeWE; } }
            protected override Point Position { get { return new Point((int)SelectBox.Rect.Right, (int)(SelectBox.Rect.Top + SelectBox.Rect.Height / 2)); } }
            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.Width = e.X - SelectBox.Rect.X;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        public class HandleResizeWest : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeWE; } }
            protected override Point Position { get { return new Point((int)SelectBox.Rect.Left, (int)(SelectBox.Rect.Top + SelectBox.Rect.Height / 2)); } }
            Point dragStart;
            Size sizeStart;
            public override void OnDragStart(MouseEventArgs e)
            {
                dragStart = new Point(e.X, e.Y);
                sizeStart = new Size((int)SelectBox.Rect.Width, (int)SelectBox.Rect.Height);
            }
            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.X = e.X;
                SelectBox.Rect.Width = sizeStart.Width + (dragStart.X - e.X);
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        public class HandleResizeSouth : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeNS; } }
            protected override Point Position { get { return new Point((int)(SelectBox.Rect.Left + SelectBox.Rect.Width / 2), (int)SelectBox.Rect.Bottom); } }
            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.Height = e.Y - SelectBox.Rect.Y;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        private class HandleResizeNE : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeNESW; } }
            protected override Point Position { get { return new Point((int)SelectBox.Rect.Right, (int)SelectBox.Rect.Top); } }

            Point dragStart;
            Size sizeStart;
            public override void OnDragStart(MouseEventArgs e)
            {
                dragStart = new Point(e.X, e.Y);
                sizeStart = new Size((int)SelectBox.Rect.Width, (int)SelectBox.Rect.Height);
            }
            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.Y = e.Y;
                SelectBox.Rect.Height = sizeStart.Height + (dragStart.Y - e.Y);
                SelectBox.Rect.Width = e.X - SelectBox.Rect.X;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        private class HandleResizeSE : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeNWSE; } }
            protected override Point Position { get { return new Point((int)SelectBox.Rect.Right, (int)SelectBox.Rect.Bottom); } }

            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.Width = e.X - SelectBox.Rect.X;
                SelectBox.Rect.Height = e.Y - SelectBox.Rect.Y;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        private class HandleResizeSW : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeNESW; } }
            protected override Point Position { get { return new Point((int)SelectBox.Rect.Left, (int)SelectBox.Rect.Bottom); } }

            Point dragStart;
            Size sizeStart;
            public override void OnDragStart(MouseEventArgs e)
            {
                dragStart = new Point(e.X, e.Y);
                sizeStart = new Size((int)SelectBox.Rect.Width, (int)SelectBox.Rect.Height);
            }
            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.X = e.X;
                SelectBox.Rect.Width = sizeStart.Width + (dragStart.X - e.X);
                SelectBox.Rect.Height = e.Y - SelectBox.Rect.Y;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        private class HandleResizeNW : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeNWSE; } }
            protected override Point Position { get { return new Point((int)SelectBox.Rect.Left, (int)SelectBox.Rect.Top); } }

            Point dragStart;
            Size sizeStart;
            public override void OnDragStart(MouseEventArgs e)
            {
                dragStart = new Point(e.X, e.Y);
                sizeStart = new Size((int)SelectBox.Rect.Width, (int)SelectBox.Rect.Height);
            }
            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.X = e.X;
                SelectBox.Rect.Y = e.Y;
                SelectBox.Rect.Width = sizeStart.Width + (dragStart.X - e.X);
                SelectBox.Rect.Height = sizeStart.Height + (dragStart.Y - e.Y);
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }

        public class HandleMove : SelectBoxHandle
        {
            public override Rectangle HandleRect
            {
                get
                {
                    Rectangle sbr = new Rectangle((int)SelectBox.Rect.X, (int)SelectBox.Rect.Y, (int)SelectBox.Rect.Width, (int)SelectBox.Rect.Height);
                    Rectangle mine = new Rectangle(sbr.X, sbr.Y, sbr.Width, sbr.Height);
                    return mine;
                }
            }

            public override void OnPaint(PaintEventArgs pe) { return; }
            public override Cursor Cursor { get { return Cursors.SizeAll; } }

            Point dragStart;

            public override void OnDragStart(MouseEventArgs e)
            {
                dragStart = new Point(e.X - (int)SelectBox.Rect.X, e.Y - (int)SelectBox.Rect.Y);
            }

            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.X = e.X - dragStart.X;
                SelectBox.Rect.Y = e.Y - dragStart.Y;
                SelectBox.Parent.Invalidate();

                SelectBox.Parent.Refresh();
            }
        }

        private void pbox_Image_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            if (showSelectBox) selectBox.OnPaint(e, showHandles);

            //Color crossColor = Color.Green;
            //int crossThickness = 5;
            //int crossSize = 20;
            //bool showCross = false;

            //Pen p = new Pen(crossColor, crossThickness);

            //if (showCross)
            //{
            //    Point midPoint = new Point(
            //        selectBox.Rect.Left + selectBox.Rect.Width / 2,
            //        selectBox.Rect.Top + selectBox.Rect.Height / 2);

            //    e.Graphics.DrawLine(
            //        p,
            //        midPoint.X, midPoint.Y - crossSize,
            //        midPoint.X, midPoint.Y + crossSize);

            //    e.Graphics.DrawLine(p, midPoint.X - crossSize, midPoint.Y, midPoint.X + crossSize, midPoint.Y);
            //}
        }
        #endregion

        static int PyrRatio = 0;
        private void RefreshImage()
        {
            if (LocalImgG != null)
            {
                //LocalImgC = TempLocalImgG.Convert<Emgu.CV.Structure.Bgr, byte>();

                //Rectangle Rect = new Rectangle();
                //Rect.X = (int)CmdLine.X[0];
                //Rect.Y = (int)CmdLine.Y[0];
                //Rect.Width = (int)CmdLine.X[1];
                //Rect.Height = (int)CmdLine.Y[1];
                //GrabberNET.VisUtils.DrawRect(LocalImgC, Rect, Color.Lime);

                //Rect.X = (int)(CmdLine.X[0] + CmdLine.X[2]);
                //Rect.Y = (int)(CmdLine.Y[0] + CmdLine.Y[2]);
                //GrabberNET.VisUtils.DrawRect(LocalImgC, Rect, Color.Lime);

                //Rect.X = (int)(CmdLine.X[0] + (CmdLine.X[1] / 2));
                //Rect.Y = (int)(CmdLine.Y[0] + (CmdLine.Y[1] / 2));
                //Rect.Width = (int)(CmdLine.X[2]);
                //Rect.Height = (int)(CmdLine.Y[2]);
                //GrabberNET.VisUtils.DrawRect(LocalImgC, Rect, Color.Yellow);

                //pbox_Image.Image = LocalImgC.ToBitmap();

                LocalImgC = TempLocalImgG.Convert<Emgu.CV.Structure.Bgr, byte>();
                if (PyrRatio > 0)
                    for (int i = 0; i < PyrRatio; i++)
                    {


                        LocalImgC = LocalImgC.PyrUp();
                    }
                if (PyrRatio < 0)
                    for (int i = 0; i > PyrRatio; i--)
                    {


                        LocalImgC = LocalImgC.PyrDown();
                    }


                //Rectangle Rect = new Rectangle();
                //Rect.X = (int)CmdLine.X[0];
                //Rect.Y = (int)CmdLine.Y[0];
                //Rect.Width = (int)CmdLine.X[1];
                //Rect.Height = (int)CmdLine.Y[1];
                //GrabberNET.VisUtils.DrawRect(LocalImgC, Rect, Color.Lime);

                //Rect.X = (int)(CmdLine.X[0] + CmdLine.X[2]);
                //Rect.Y = (int)(CmdLine.Y[0] + CmdLine.Y[2]);
                //GrabberNET.VisUtils.DrawRect(LocalImgC, Rect, Color.Lime);

                //Rect.X = (int)(CmdLine.X[0] + (CmdLine.X[1] / 2));
                //Rect.Y = (int)(CmdLine.Y[0] + (CmdLine.Y[1] / 2));
                //Rect.Width = (int)(CmdLine.X[2]);
                //Rect.Height = (int)(CmdLine.Y[2]);
                //GrabberNET.VisUtils.DrawRect(LocalImgC, Rect, Color.Yellow);

                pbox_Image.Image = LocalImgC.ToBitmap();
            }
            else
            {
                Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> _Img = null;
                _Img = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte>(pbox_Image.Width, pbox_Image.Height);
                VisUtils.DrawText(_Img, new Point(5, 5), "No Image", 10, Color.Red);
                pbox_Image.Image = _Img.ToBitmap();
                _Img.Dispose();
            }
        }

        #region Tab - Advance
        private void btn_LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //VisUtils.Load(ref LocalImgG, ofd.FileName);
                LocalImgG = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(ofd.FileName);
                TempLocalImgG = LocalImgG.Clone();
                pbox_Image.Image = LocalImgG.ToBitmap();
            }
        }
        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //VisUtils.Save(LocalImgG, sfd.FileName);
                LocalImgG.Save(sfd.FileName);
            }
        }

        private void btn_Learn_Click(object sender, EventArgs e)
        {
            Rectangle SR = new Rectangle(0, 0, LocalImgG.Width, LocalImgG.Height);
            Rectangle PR = new Rectangle((int)CmdLine.X[0], (int)CmdLine.Y[0], (int)CmdLine.X[1], (int)CmdLine.Y[1]);

            VisUtils.Learn(LocalImgG, TaskVision.CreateMapTemplate, SR, PR);

            pbox_CreateMapTemplate.Image = TaskVision.CreateMapTemplate.Image.ToBitmap();
        }
        List<VisUtils.EMatchResult> MatchResults = new List<VisUtils.EMatchResult>();
        private void btn_Match_Click(object sender, EventArgs e)
        {
            string EMsg = "Match";

            try
            {
                DispProg.CreateMatchMap(CmdLine, LocalImgG, MatchResults);

                //LocalImgC = GrabberNET.VisProc.Convert(TempLocalImgG);
                LocalImgC = TempLocalImgG.Convert<Emgu.CV.Structure.Bgr, byte>();
                float SMin = 1;
                float SMax = 0;
                for (int i = 0; i < MatchResults.Count; i++)
                {
                    Rectangle R = new Rectangle();
                    R.X = (int)MatchResults[i].X;
                    R.Y = (int)MatchResults[i].Y;
                    R.Width = (int)CmdLine.X[5];
                    R.Height = (int)CmdLine.Y[5];
                    float S = MatchResults[i].S;

                    SMin = Math.Min(S, SMin);
                    SMax = Math.Max(S, SMax);

                    Color C = Color.Lime;

                    VisUtils.DrawRect(LocalImgC, R, C);
                    VisUtils.DrawText(LocalImgC, new Point(R.X, R.Y), S.ToString("f2"), 8, C);
                }

                lbl_ResultCount.Text = MatchResults.Count.ToString();
                lbl_ResultMin.Text = SMin.ToString();
                lbl_ResultMax.Text = SMax.ToString();

                ViewZoom();
                pbox_Image.Image = LocalImgC.ToBitmap();
            }
            catch (Exception Ex)
            {
                EMsg = EMsg + (char)13 + Ex.Message.ToString();
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.UNKNOWN_EX_ERR, EMsg);
            }
        }
        #endregion

        #region Tab - Basic
        private void lbl_Mode_Click(object sender, EventArgs e)
        {
            //if (CmdLine.IPara[2] < Enum.GetNames(typeof(ECMMethod)).Length - 1)
            //    CmdLine.IPara[2]++;
            //else
            //    CmdLine.IPara[2] = 0;

            ECMMethod E = ECMMethod.Binary;
            //double i = (int)(CmdLine.DPara[10] * 100);
            UC.AdjustExec(CmdName + ", Mode", ref CmdLine.IPara[2], E);
            //CmdLine.DPara[10] = (double)i / 100;

            UpdateDisplay();
        }

        enum EImageMode { Raw, Process, };
        EImageMode ImgMode = EImageMode.Raw;
        private void btn_ImgMode_Click(object sender, EventArgs e)
        {
            if ((int)ImgMode < Enum.GetNames(typeof(EImageMode)).Length - 1)
                ImgMode++;
            else
                ImgMode = (EImageMode)0;

            if (ImgMode == EImageMode.Raw)
            {
                TempLocalImgG = LocalImgG.Clone();
            }
            else
            {
                //    TempLocalImgG = LocalImgG.Clone();
                //}
                ECMMethod Method = (ECMMethod)CmdLine.IPara[2];
                switch (Method)
                {
                    case ECMMethod.Pattern:
                        {
                            TempLocalImgG = LocalImgG.Clone();
                            break;
                        }
                    case ECMMethod.Binary:
                        {
                            TempLocalImgG = LocalImgG.ThresholdBinary(new Emgu.CV.Structure.Gray(CmdLine.IPara[10]), new Emgu.CV.Structure.Gray(255));
                            break;
                        }
                }
            }
            RefreshImage();
        }

        private void btn_Pattern_Click(object sender, EventArgs e)
        {
            ViewMag0();

            Mode = EMode.Pattern;
            UpdateDisplay();

            EnableControl(false, btn_ModeOK, btn_ModeCancel);

            Rectangle Rect = new Rectangle();
            Rect.X = (int)CmdLine.X[0];
            Rect.Y = (int)CmdLine.Y[0];
            Rect.Width = (int)CmdLine.X[1];
            Rect.Height = (int)CmdLine.Y[1];

            if (Rect.X < 0) Rect.X = 0;
            if (Rect.Y < 0) Rect.Y = 0;
            if (Rect.X > LocalImgG.Width) Rect.X = LocalImgG.Width - Rect.Width;
            if (Rect.Y > LocalImgG.Height) Rect.Y = LocalImgG.Height - Rect.Height;
            if (Rect.Width <= 0) Rect.Width = 100;
            if (Rect.Height <= 0) Rect.Height = 100;

            SelectionRect = Rect;
            //ViewActual();
            showSelectBox = true;
            showHandles = true;
            RefreshImage();
        }
        private void btn_Outline_Click(object sender, EventArgs e)
        {
            Mode = EMode.Outline;
            UpdateDisplay();

            ViewMag0();

            EnableControl(false, btn_ModeOK, btn_ModeCancel);

            Rectangle Rect = new Rectangle();
            Rect.X = (int)(CmdLine.X[0] + (CmdLine.X[1] / 2) - CmdLine.X[2]);//);
            Rect.Y = (int)(CmdLine.Y[0] + (CmdLine.Y[1] / 2));
            Rect.Width = (int)(CmdLine.X[2]);
            Rect.Height = (int)(CmdLine.Y[2]);

            //if (Rect.X < 0) Rect.X = 0;
            if (Rect.X < 0)
            {
                Rect.Width += Rect.X;
                Rect.X = 10;
            }
            if (Rect.Y < 0) Rect.Y = 0;
            if (Rect.X > LocalImgG.Width) Rect.X = LocalImgG.Width - Rect.Width;
            if (Rect.Y > LocalImgG.Height) Rect.Y = LocalImgG.Height - Rect.Height;
            if (Rect.Width <= 0) Rect.Width = 100;
            if (Rect.Height <= 0) Rect.Height = 100;

            SelectionRect = Rect;
            //ViewActual();
            showSelectBox = true;
            showHandles = true;
            RefreshImage();

            SetScrollPos();
        }

        private void btn_ModeOK_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case EMode.Pattern:
                    {
                        Rectangle Old = new Rectangle((int)CmdLine.X[0], (int)CmdLine.Y[0], (int)CmdLine.X[1], (int)CmdLine.Y[1]);
                        CmdLine.X[0] = SelectionRect.X;
                        CmdLine.Y[0] = SelectionRect.Y;
                        CmdLine.X[1] = SelectionRect.Width;
                        CmdLine.Y[1] = SelectionRect.Height;

                        Rectangle SearchRegion = new Rectangle(0, 0, LocalImgG.Width, LocalImgG.Height);
                        Rectangle PatternRegion = new Rectangle((int)CmdLine.X[0], (int)CmdLine.Y[0], (int)CmdLine.X[1], (int)CmdLine.Y[1]);

                        VisUtils.Learn(LocalImgG, TaskVision.CreateMapTemplate, SearchRegion, PatternRegion);

                        //if (CmdLine.X[0] + CmdLine.X[1] / 2 + CmdLine.X[2] > LocalImgG.Width)
                        //{
                        //    CmdLine.X[2] = LocalImgG.Width - CmdLine.X[0] - CmdLine.X[1];
                        //}

                        //if (CmdLine.Y[0] + CmdLine.Y[1] / 2 + CmdLine.Y[2] > LocalImgG.Height)
                        //{
                        //    CmdLine.Y[2] = LocalImgG.Height - CmdLine.Y[0] - CmdLine.Y[1];
                        //}
                        pbox_CreateMapTemplate.Image = TaskVision.CreateMapTemplate.Image.ToBitmap();

                        Log.OnAction("Change", CmdName + ", Pattern", Old, PatternRegion);
                    }
                    break;
                case EMode.Outline:
                    {
                        NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[2], CmdLine.Y[2]);
                        CmdLine.X[2] = SelectionRect.Width;
                        CmdLine.Y[2] = SelectionRect.Height;
                        NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[2], CmdLine.Y[2]);

                        Log.OnAction("Change", CmdName + ", Outline", Old, New);
                    }
                    break;
            }

            Mode = EMode.None;
            showSelectBox = false;

            ViewZoom();
            RefreshImage();

            EnableControl(true, btn_ModeOK, btn_ModeCancel);
            UpdateDisplay();
        }
        private void btn_ModeCancel_Click(object sender, EventArgs e)
        {
            Mode = EMode.None;
            showSelectBox = false;

            ViewZoom();
            RefreshImage();

            EnableControl(true, btn_ModeOK, btn_ModeCancel);
            UpdateDisplay();
        }

        EMapBin[] MapBin = new EMapBin[TLayout.MAX_UNITS];
        private void btn_Test_Click(object sender, EventArgs e)
        {
            LocalImgC = TempLocalImgG.Convert<Emgu.CV.Structure.Bgr, byte>();// GrabberNET.VisProc.Convert(TempLocalImgG);

            ECMMethod Method = (ECMMethod)CmdLine.IPara[2];
            switch (Method)
            {
                case ECMMethod.Pattern:
                    {
                        DispProg.CreateMatchMap(CmdLine, LocalImgG, MatchResults);
                        DispProg.ResetMaps();
                        DispProg.GenerateMap(CmdLine, InLayout, MatchResults, ref MapBin);
                        break;
                    }
                case ECMMethod.Binary:
                    {
                        DispProg.ResetMaps();
                        DispProg.GenerateMap(CmdLine, InLayout, LocalImgG, ref MapBin);
                        break;
                    }
            }

            for (int i = 0; i < InLayout.TUCount; i++)
            {
                Rectangle R = new Rectangle();
                R.X = (int)DispProg.rt_MapX[i];
                R.Y = (int)DispProg.rt_MapY[i];
                R.Width = (int)CmdLine.X[1];
                R.Height = (int)CmdLine.Y[1];

                Color C = new Color();
                if (MapBin[i] == EMapBin.MapOK) C = Color.Lime;
                else
                    if (MapBin[i] == EMapBin.PreMapNG) C = Color.Orange;
                else
                    C = Color.Red;

                VisUtils.DrawRect(LocalImgC, R, C);
            }

            ViewZoom();
            pbox_Image.Image = LocalImgC.ToBitmap();

            UpdateDisplay();
        }

        private void lbl_Score_Click(object sender, EventArgs e)
        {
            int i = (int)(CmdLine.DPara[0] * 100);
            UC.AdjustExec(CmdName + ", Score (%)", ref i, 0, 99);
            CmdLine.DPara[0] = (double)i / 100;
            UpdateDisplay();
        }

        private void btn_Auto_Click(object sender, EventArgs e)
        {
            LocalImgC = TempLocalImgG.Convert<Emgu.CV.Structure.Bgr, byte>();// GrabberNET.VisProc.Convert(TempLocalImgG);

            ECMMethod Method = (ECMMethod)CmdLine.IPara[2];
            switch (Method)
            {
                case ECMMethod.Pattern:
                    {
                        DispProg.CreateMatchMap(CmdLine, LocalImgG, MatchResults);
                        DispProg.ResetMaps();
                        DispProg.GenerateMap(CmdLine, InLayout, MatchResults, ref MapBin);
                        break;
                    }
                case ECMMethod.Binary:
                    {
                        DispProg.ResetMaps();
                        DispProg.GenerateMap(CmdLine, InLayout, LocalImgG, ref MapBin);

                        CmdLine.DPara[10] = (DispProg.rt_MinWhitePixelPcnt * 0.8);
                        break;
                    }
            }
            UpdateDisplay();
        }

        private void lbl_MinPixel_Click(object sender, EventArgs e)
        {
            double i = (int)(CmdLine.DPara[10] * 100);
            UC.AdjustExec(CmdName + ", MinPixel", ref i, 1, 100);
            CmdLine.DPara[10] = (double)i / 100;
            UpdateDisplay();
        }
        private void lbl_Thld_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Threshold (0-255)", ref CmdLine.IPara[10], 0, 255);

            TempLocalImgG = LocalImgG.ThresholdBinary(new Emgu.CV.Structure.Gray(CmdLine.IPara[10]), new Emgu.CV.Structure.Gray(255));
            pbox_Image.Image = TempLocalImgG.ToBitmap();

            UpdateDisplay();
        }
        private void btn_ThldM_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[10] > 0)
            {
                double Old = CmdLine.IPara[10];
                CmdLine.IPara[10]--;
                double New = CmdLine.IPara[10];

                TempLocalImgG = LocalImgG.ThresholdBinary(new Emgu.CV.Structure.Gray(CmdLine.IPara[10]), new Emgu.CV.Structure.Gray(255));
                pbox_Image.Image = TempLocalImgG.ToBitmap();

                Log.OnAction("Change", CmdName + " Thld", Old, New);
                UpdateDisplay();
            }
        }
        private void btn_ThldP_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[10] < 255)
            {
                double Old = CmdLine.IPara[10];
                CmdLine.IPara[10]++;
                double New = CmdLine.IPara[10];

                TempLocalImgG = LocalImgG.ThresholdBinary(new Emgu.CV.Structure.Gray(CmdLine.IPara[10]), new Emgu.CV.Structure.Gray(255));
                pbox_Image.Image = TempLocalImgG.ToBitmap();

                Log.OnAction("Change", CmdName + " Thld", Old, New);
                UpdateDisplay();
            }
        }
        #endregion

        #region Tab - Judgement
        private void lbl_OKYield_Click(object sender, EventArgs e)
        {
            double i = (int)(CmdLine.DPara[4] * 100);
            UC.AdjustExec(CmdName + ", OK Yield",  ref i, 10, 100);
            CmdLine.DPara[4] = (double)i / 100;
            UpdateDisplay();
        }
        #endregion

        private void ViewZoom()
        {
            double Ratio = 0;

            pbox_Image.Dock = DockStyle.Fill;
            pbox_Image.SizeMode = PictureBoxSizeMode.Zoom;

            try
            {
                double RatioX = (double)pnl_Image.Width / (double)LocalImgG.Width;
                double RatioY = (double)pnl_Image.Height / (double)LocalImgG.Height;
                Ratio = RatioX < RatioY ? RatioX : RatioY;

                int NewWidth = Convert.ToInt32(LocalImgG.Width * Ratio);
                int NewHeight = Convert.ToInt32(LocalImgG.Height * Ratio);

                int PosX = Convert.ToInt32(pnl_Image.Width - ((double)NewWidth / 2));
                int PosY = Convert.ToInt32(pnl_Image.Height - ((double)NewHeight / 2));
            }
            catch { };
        }
        private void ViewMag0()
        {
            RectangleF RectF = SelectionRectF;
            PyrRatio = 0;
            SelectionRectF = RectF;
            RefreshImage();

            pbox_Image.Dock = DockStyle.None;
            pbox_Image.SizeMode = PictureBoxSizeMode.AutoSize;

            pnl_Image.AutoScrollPosition = new Point(0, 0);
        }
        private void ViewMagN()
        {
            //if (PyrRatio <= -2) return;
            if (LocalImgC.Width / 2 < 200 || LocalImgC.Height / 2 < 200) return;

            RectangleF RectF = SelectionRectF;
            PyrRatio--;
            SelectionRectF = RectF;
            RefreshImage();

            pbox_Image.Dock = DockStyle.None;
            pbox_Image.SizeMode = PictureBoxSizeMode.AutoSize;

            SetScrollPos();
        }
        private void ViewMagP()
        {
            //if (PyrRatio >= 3) return;
            if (LocalImgC.Width * 2 > 10000 || LocalImgC.Height * 2 > 10000) return;
            
            RectangleF RectF = SelectionRectF;
            PyrRatio++;
            SelectionRectF = RectF;
            RefreshImage();

            pbox_Image.Dock = DockStyle.None;
            pbox_Image.SizeMode = PictureBoxSizeMode.AutoSize;

            SetScrollPos();
        }
        private void SetScrollPos()
        {
            int HScrollLen = pnl_Image.HorizontalScroll.Maximum - pnl_Image.HorizontalScroll.LargeChange;
            int VScrollLen = pnl_Image.VerticalScroll.Maximum - pnl_Image.VerticalScroll.LargeChange;

            double PosX = 0;
            double PosY = 0;

            switch (Mode)
            {
                case EMode.Pattern:
                    PosX = (double)selectBox.Rect.X / pbox_Image.Width;
                    PosY = (double)selectBox.Rect.Y / pbox_Image.Height;
                    break;
                case EMode.Outline:
                    PosX = (double)(selectBox.Rect.X + selectBox.Rect.Width) / pbox_Image.Width;
                    PosY = (double)(selectBox.Rect.Y + selectBox.Rect.Height) / pbox_Image.Height;
                    break;
            }

            int HScrollPos = (int)(PosX * HScrollLen);
            int VScrollPos = (int)(PosY * VScrollLen);

            pnl_Image.AutoScrollPosition = new Point(HScrollPos, VScrollPos);
        }

        private void lbl_Zoom_Click(object sender, EventArgs e)
        {
            ViewZoom();
        }
        private void lbl_Mag1_Click(object sender, EventArgs e)
        {
            ViewMag0();
        }
        private void lbl_MagN_Click(object sender, EventArgs e)
        {
            ViewMagN();
        }
        private void lbl_MagP_Click(object sender, EventArgs e)
        {
            ViewMagP();
        }
        private void lbl_Center_Click(object sender, EventArgs e)
        {
            pnl_Image.AutoScrollPosition = new Point((pnl_Image.HorizontalScroll.Maximum - pnl_Image.HorizontalScroll.LargeChange) / 2,
            (pnl_Image.VerticalScroll.Maximum - pnl_Image.VerticalScroll.LargeChange) / 2);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);

            TaskVision.LightingOn(TaskVision.DefLightRGB);

            DispProg.ResetMaps();

            //frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName);
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName);
            Close();
        }


    }
}
