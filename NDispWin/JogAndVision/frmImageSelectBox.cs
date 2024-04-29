using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace NDispWin
{
    using Emgu.CV;
    using Emgu.CV.Structure;
    using Emgu.CV.Util;

    partial class frmImageSelectBox : Form
    {
        enum EImageSource { Current, Registered };
        EImageSource sourceImage = EImageSource.Current;

        enum EROI { None, Search, Pattern };
        EROI roi = EROI.None;

        public Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> nowImage;
        public Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> regImage;
        public Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> selectedImage;
        Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> imgDisplay;

        private SelectBox selectBox;
        private bool readOnly = false;
        private bool showSelectBox = true;
        private bool showBox = false;

        private static double scale = 1;
        private static Point ofst = new Point(0, 0);

        public int Threshold = -1;
        private string instruction = "";
        private Rectangle[] rects;
        readonly private Rectangle[] rectsOri;


        public frmImageSelectBox()
        {
            InitializeComponent();
        }
        public frmImageSelectBox(Image<Emgu.CV.Structure.Gray, byte> nowImg, Image<Emgu.CV.Structure.Gray, byte> regImg, string instruction, Rectangle[] rects, string[] rectNames) : this()
        {
            tsbtnMatchImage.Visible = false;
            tsbtnLearnImage.Visible = false;

            tscbxImage.ComboBox.DataSource = Enum.GetValues(typeof(EImageSource));
            string[] str = new string[] { "None" };
            foreach (string s in rectNames)
            {
                str = str.Concat(new string[] { s }).ToArray();
            }
            tscbxROI.ComboBox.DataSource = str;// Enum.GetValues(typeof(EROI));

            imgboxEmgu.Dock = DockStyle.Fill;
            imgboxEmgu.MouseMove += new MouseEventHandler(imgboxEmgu_MouseMove);
            imgboxEmgu.MouseDown += new MouseEventHandler(imgboxEmgu_MouseDown);
            imgboxEmgu.MouseUp += new MouseEventHandler(imgboxEmgu_MouseUp);

            this.selectBox = new SelectBox(imgboxEmgu, new Rectangle(120, 120, 50, 50));
            this.selectBox.AddHandle(new HandleMove());
            this.selectBox.AddHandle(new HandleResizeNWSE());
            this.selectBox.AddHandle(new HandleResizeSouth());
            this.selectBox.AddHandle(new HandleResizeEast());
            this.selectBox.OnBoxChanged += new EventHandler(selectBox_OnBoxChanged);

            nowImage = nowImg.Copy();
            if (regImg != null) regImage = regImg.Copy();
            selectedImage = nowImage.Copy();
            imgboxEmgu.Size = selectedImage.Size;


            this.rects = rects;
            this.rectsOri = new Rectangle[rects.Length];
            for (int i = 0; i < rects.Length; i++)
            {
                this.rectsOri[i] = rects[i];
            }
            this.instruction = instruction;
        }


        private void frmVisionSelectBox_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            Text = "Image Select Box";
            tbarThreshold.Value = Threshold; ;

            RefreshImgBoxEmgu();

            lbl_Instruction.Text = instruction;

            ZoomFit();
        }

        public Rectangle SelectionRect
        {
            get { return selectBox.Rect; }
            set
            {
                selectBox.Rect = value;
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

        #region Select Box Handles 
        void imgboxEmgu_MouseUp(object sender, MouseEventArgs e)
        {
            if (readOnly) return;
            selectBox.OnMouseUp(e);
        }
        void imgboxEmgu_MouseDown(object sender, MouseEventArgs e)
        {
            if (readOnly) return;
            selectBox.OnMouseDown(e);
        }
        void imgboxEmgu_MouseMove(object sender, MouseEventArgs e)
        {
            if (readOnly) return;
            selectBox.OnMouseMove(e);
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
        private class SelectBox
        {
            public Rectangle Rect;
            public Color color = Color.Lime;
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
                //Pen p = new Pen(Brushes.Lime, 2.0f);
                Pen p = new Pen(color, 2.0f);
                pe.Graphics.DrawRectangle(p, this.Rect);

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
                    int x = (int)((double)(e.X) / scale) + ofst.X;
                    int y = (int)((double)(e.Y) / scale) + ofst.Y;
                    if (sbh.HitTest(x, y))
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
                    int x = (int)((double)(e.X) / scale) + ofst.X;
                    int y = (int)((double)(e.Y) / scale) + ofst.Y;
                    if (sbh.HitTest(x, y))
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
        private abstract class SelectBoxHandle
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

        private abstract class HandleResize : SelectBoxHandle
        {
            public const int HANDLE_SIZE = 10;

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
        private class HandleResizeNWSE : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeNWSE; } }
            protected override Point Position { get { return new Point(SelectBox.Rect.Right, SelectBox.Rect.Bottom); } }

            public override void OnDragging(MouseEventArgs e)
            {
                int x = (int)(double)(e.X / scale) + ofst.X;
                int y = (int)(double)(e.Y / scale) + ofst.Y;
                SelectBox.Rect.Width = x - SelectBox.Rect.X;
                SelectBox.Rect.Height = y - SelectBox.Rect.Y;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();

            }
        }
        private class HandleResizeEast : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeWE; } }
            protected override Point Position { get { return new Point(SelectBox.Rect.Right, SelectBox.Rect.Top + SelectBox.Rect.Height / 2); } }
            public override void OnDragging(MouseEventArgs e)
            {
                int x = (int)(double)(e.X / scale) + ofst.X;
                SelectBox.Rect.Width = x - SelectBox.Rect.X;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        private class HandleResizeSouth : HandleResize
        {
            protected override Point Position
            {
                get
                {
                    return new Point(SelectBox.Rect.Left + SelectBox.Rect.Width / 2,
                      SelectBox.Rect.Bottom);
                }
            }

            public override Cursor Cursor { get { return Cursors.SizeNS; } }

            public override void OnDragging(MouseEventArgs e)
            {
                int y = (int)(double)(e.Y / scale) + ofst.Y;
                SelectBox.Rect.Height = y - SelectBox.Rect.Y;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        private class HandleMove : SelectBoxHandle
        {
            public override Rectangle HandleRect
            {
                get
                {
                    Rectangle sbr = SelectBox.Rect;
                    Rectangle mine = new Rectangle(sbr.X, sbr.Y, sbr.Width, sbr.Height);
                    return mine;
                }
            }

            public override void OnPaint(PaintEventArgs pe) { return; }
            public override Cursor Cursor { get { return Cursors.SizeAll; } }


            Point dragStart;

            public override void OnDragStart(MouseEventArgs e)
            {
                //dragStart = new Point(e.X - SelectBox.Rect.X, e.Y - SelectBox.Rect.Y);
                int x = (int)(double)(e.X / scale) + ofst.X;
                int y = (int)(double)(e.Y / scale) + ofst.Y;
                dragStart = new Point(x - SelectBox.Rect.X, y - SelectBox.Rect.Y);
            }

            public override void OnDragging(MouseEventArgs e)
            {
                //SelectBox.Rect.X = e.X - dragStart.X;
                //SelectBox.Rect.Y = e.Y - dragStart.Y;
                int x = (int)((double)(e.X) / scale) + ofst.X;
                int y = (int)((double)(e.Y) / scale) + ofst.Y;
                SelectBox.Rect.X = x - dragStart.X;
                SelectBox.Rect.Y = y - dragStart.Y;

                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        #endregion

        private void RefreshImgBoxEmgu()
        {
            int threshold = tbarThreshold.Value;
            tsbtnThreshold.Text = "Threshold = " + threshold.ToString();

            imgDisplay = threshold >= 0 ? selectedImage.ThresholdBinary(new Emgu.CV.Structure.Gray(threshold), new Emgu.CV.Structure.Gray(255)) : selectedImage.Copy();
            imgboxEmgu.Image = imgDisplay;
        }

        private void imgboxEmgu_Paint(object sender, PaintEventArgs e)
        {
            scale = imgboxEmgu.ZoomScale;
            ofst.X = imgboxEmgu.HorizontalScrollBar.Value;
            ofst.Y = imgboxEmgu.VerticalScrollBar.Value;

            if (rects != null)
            {
                for (int i = 0; i < rects.Count(); i++)
                {
                    //if (i == (int)roi - 1) continue;
                    //if (name )

                    if (i >= tscbxROI.ComboBox.Items.Count - 1) break;

                   Pen p = new Pen(Color.Yellow, 1);
                    e.Graphics.DrawRectangle(p, rects[i]);
                }
            }

            base.OnPaint(e);
            if (showSelectBox)
            {
                selectBox.color = Color.Lime;
                selectBox.OnPaint(e, !readOnly);
            }

            if (showBox)
            {
                showBox = false;
                selectBox.color = Color.Blue;
                selectBox.OnPaint(e, false);
            }
        }
        private void imgboxEmgu_SizeChanged(object sender, EventArgs e)
        {
            ZoomFit();
        }

        private void tsbtnThreshold_Click(object sender, EventArgs e)
        {
             tbarThreshold.Visible = !tbarThreshold.Visible;
        }
        private void tbarThreshold_Scroll(object sender, EventArgs e)
        {
            Threshold = tbarThreshold.Value;
            tsbtnThreshold.Text = "Threshold = " + Threshold.ToString();

            RefreshImgBoxEmgu();
        }
        private void tsbResetROI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Set Search and Pattern Window to default?", "Reset ROI", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            Rectangle rect = new Rectangle(100, 100, 200, 200);
            for (int i = 0; i < rects.Count(); i++)
            {
                rect.X += i * 20;
                rect.Y += i * 20;
                rects[i] = rect;
            }

            imgboxEmgu.Invalidate();
        }

        private void ZoomFit()
            {
                if (imgDisplay == null) return;

                double XScale = (double)imgboxEmgu.Width / imgDisplay.Width;
                double YScale = (double)imgboxEmgu.Height / imgDisplay.Height;
                imgboxEmgu.SetZoomScale(Math.Min(XScale, YScale), new Point(0, 0));
            }
        private void tsbtnZM_Click(object sender, EventArgs e)
        {
            imgboxEmgu.SetZoomScale(imgboxEmgu.ZoomScale - 0.2, new Point(imgboxEmgu.Width / 2, imgboxEmgu.Height / 2));

        }
        private void tsbtnZF_Click(object sender, EventArgs e)
        {
            ZoomFit();
        }
        private void tsbtnZP_Click(object sender, EventArgs e)
        {
            imgboxEmgu.SetZoomScale(imgboxEmgu.ZoomScale + 0.2, new Point(imgboxEmgu.Width / 2, imgboxEmgu.Height / 2));
        }

        private void tsbOK_Click(object sender, EventArgs e)
        {
            tscbxImage.ComboBox.SelectedItem = EImageSource.Registered;
            tscbxROI.ComboBox.SelectedItem = EROI.None;

            tscbxROI_SelectedIndexChanged(sender, e);
            
            this.DialogResult = DialogResult.OK;
        }
        private void tsbCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rects.Length; i++)
            {
                this.rects[i] = this.rectsOri[i];
            }
            this.DialogResult = DialogResult.Cancel;
        }

        private void tsbtnMatchImage_Click(object sender, EventArgs e)
        {
            tscbxImage.SelectedItem = EImageSource.Current;
            tscbxROI.ComboBox.SelectedItem = EROI.None;

            PointF pLoc = new PointF(0, 0);
            PointF pLOfst = new PointF(0, 0);
            double score = 0;
            TFVision.PatMatch(nowImage, regImage, Threshold, rects, ref pLoc, ref pLOfst, ref score);

            SelectionRect = new Rectangle((int)pLoc.X, (int)pLoc.Y, rects[1].Width, rects[1].Height);
            showBox = true;

            imgboxEmgu.Invalidate();
        }
        private void tsbtnLearnImage_Click(object sender, EventArgs e)
        {
            tscbxImage.ComboBox.SelectedItem = EImageSource.Registered;
            tscbxROI.ComboBox.SelectedItem = EROI.None;

            imgboxEmgu.Invalidate();
        }

        private void tscbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceImage = (EImageSource)tscbxImage.ComboBox.SelectedIndex;

            if (nowImage == null) return;

            if (sourceImage == EImageSource.Registered && regImage == null)
            {
                DialogResult dr = MessageBox.Show("Image is not registered. Register current image?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        regImage = nowImage.Copy();
                        break;
                    case DialogResult.No:
                        sourceImage = EImageSource.Current;
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            switch (sourceImage)
            {
                case EImageSource.Registered:
                    selectedImage = regImage.Copy();
                    break;
                default:
                    selectedImage = nowImage.Copy();
                    break;
            }

            tsbtnUpdate.Enabled = sourceImage == EImageSource.Current;

            RefreshImgBoxEmgu();
        }
        private void tscbxROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rects == null)
            {
                showSelectBox = false;
                return;
            }

            if (roi > (int)EROI.None)
            {
                if (tscbxROI.ComboBox.SelectedIndex == 0)
                {
                    showSelectBox = false;
                    return;
                }

                rects[(int)roi - 1] = SelectionRect;

                roi = (EROI)tscbxROI.ComboBox.SelectedIndex;
                SelectionRect = rects[(int)roi - 1];
            }

            if (roi == (int)EROI.None)
            {
                if (tscbxROI.ComboBox.SelectedIndex == 0)
                {
                    showSelectBox = false;
                    return;
                }

                roi = (EROI)tscbxROI.ComboBox.SelectedIndex;
                SelectionRect = rects[(int)roi - 1];
            }

            showSelectBox = tscbxROI.SelectedIndex > 0;

            imgboxEmgu.Invalidate();
        }

        private void tsbtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Update Current Image as Registered Image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dr)
            {
                case DialogResult.Yes:
                    regImage = nowImage.Copy();
                    tscbxImage.SelectedItem = EImageSource.Registered;
                    break;
                default:
                    break;
            }
        }

        public TFVision.ETransition trans = TFVision.ETransition.AUTO;
        public TFVision.EArea Areas = TFVision.EArea.Single;
        public TFVision.EDirection DirectionX = TFVision.EDirection.PLUS;
        public TFVision.EDirection DirectionY = TFVision.EDirection.PLUS;
        public TFVision.ETransition TransX = TFVision.ETransition.AUTO;
        public TFVision.ETransition TransY = TFVision.ETransition.AUTO;
        public TFVision.EDetContrast detContrast = TFVision.EDetContrast.Dark;

        private void tsbtnExecute_Click(object sender, EventArgs e)
        {
            tscbxROI.ComboBox.SelectedIndex = 0;

            PointF loc = new PointF(0, 0);
            PointF ofst = new PointF(0, 0);

            switch (TFVision.Tool)
            {
                case TFVision.EToolType.PatEdgeCorner:
                    {
                        float amplitude = 0;

                        List<PointF> locX = new List<PointF>();
                        List<PointF> locY = new List<PointF>();

                        TFVision.PatEdgeCorner(selectedImage, regImage, rects, ref locX, ref locY, ref loc, ref ofst, ref amplitude, Areas, DirectionX, DirectionY, TransX, TransY);
                        imgboxEmgu.Refresh();

                        Graphics g;
                        g = imgboxEmgu.CreateGraphics();

                        scale = imgboxEmgu.ZoomScale;
                        ofst.X = imgboxEmgu.HorizontalScrollBar.Value;
                        ofst.Y = imgboxEmgu.VerticalScrollBar.Value;

                        Pen p = new Pen(Color.Blue, 1);
                        p.Color = amplitude > 10 ? Color.Lime : Color.Red;
                        foreach (PointF pf in locX)
                        {
                            float x_x = (float)((pf.X - ofst.X) * scale);
                            float x_y = (float)((pf.Y - ofst.Y) * scale);

                            g.DrawLine(p, x_x, x_y - 2, x_x, x_y + 2);
                            g.DrawLine(p, x_x - 2, x_y, x_x + 2, x_y);
                        }

                        foreach (PointF pf in locY)
                        {
                            float y_x = (float)((pf.X - ofst.X) * scale);
                            float y_y = (float)((pf.Y - ofst.Y) * scale);

                            g.DrawLine(p, y_x, y_y - 2, y_x, y_y + 2);
                            g.DrawLine(p, y_x - 2, y_y, y_x + 2, y_y);
                        }

                        float x = (float)((loc.X - ofst.X) * scale);
                        float xy1 = (float)((rects[0].Y - ofst.Y) * scale);
                        float xy2 = (float)((rects[0].Y + rects[0].Height - ofst.Y) * scale);
                        g.DrawLine(p, x, xy1, x, xy2);

                        float y = (float)((loc.Y - ofst.Y) * scale);
                        float yx1 = (float)((rects[1].X - ofst.X) * scale);
                        float yx2 = (float)((rects[1].X + rects[1].Width - ofst.X) * scale);
                        g.DrawLine(p, yx1, y, yx2, y);

                        g.DrawLine(p, x, y - 5, x, y + 5);
                        g.DrawLine(p, x - 5, y, x + 5, y);

                        break;
                    }
                case TFVision.EToolType.PatCircle:
                    {
                        float radius = 0;
                        float roundness = 0;
                        int found = TFVision.PatCircle(selectedImage, regImage, Threshold, rects, detContrast, ref loc, ref radius, ref ofst, ref roundness);
                        imgboxEmgu.Refresh();

                        Graphics g;
                        g = imgboxEmgu.CreateGraphics();

                        scale = imgboxEmgu.ZoomScale;
                        ofst.X = imgboxEmgu.HorizontalScrollBar.Value;
                        ofst.Y = imgboxEmgu.VerticalScrollBar.Value;

                        Pen p = new Pen(Color.Lime, 1);
                        p.Color = found > 0 ? Color.Lime : Color.Red;

                        if (found > 0)
                        {
                            PointF center = new PointF((float)((loc.X - ofst.X) * scale), (float)((loc.Y - ofst.Y) * scale));
                            PointF location = new PointF((float)((loc.X - ofst.X - radius) * scale), (float)((loc.Y - ofst.Y - radius) * scale));
                            SizeF size = new SizeF((float)(radius * 2 * scale), (float)(radius * 2 * scale));

                            g.DrawLine(p, center.X, center.Y - 5, center.X, center.Y + 5);
                            g.DrawLine(p, center.X - 5, center.Y, center.X + 5, center.Y);
                            g.DrawArc(p, new RectangleF(location, size), 0, 360.0f);
                        }
                        else
                        {
                            PointF location = new PointF((float)(rects[0].X * scale), (float)(rects[0].Y * scale));
                            SizeF size = new SizeF((float)(rects[0].Width * scale), (float)(rects[0].Height * scale));
                            g.DrawRectangles(p, new RectangleF[] { new RectangleF(location, size) });
                        }
                        break;
                    }
            }
        }

        private void tsmiLoadImage_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            //Thread t = new Thread((ThreadStart)(() =>
            //{
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "Image Files (*.tif;*.tiff;*.gif;*.bmp;*.jpg;*.jpeg;*.jp2;*.png;)|*.tif;*.tiff;*.gif;*.bmp;*.jpg;*.jpeg;*.jp2;*.png;|All files (*.*)|*.*||";
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    nowImage = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(openFileDialog1.FileName);

                    if (regImage == null)
                    {
                        DialogResult dr = MessageBox.Show("Image is not registered. Register current image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                regImage = nowImage.Copy();
                                break;
                            case DialogResult.No:
                                break;
                        }
                    }

                }
            //}));

            //t.SetApartmentState(ApartmentState.STA);
            //t.Start();
            //t.Join();

            tscbxImage.SelectedItem = EImageSource.Current;
            tscbxImage_SelectedIndexChanged(sender, e);
            ZoomFit();

            this.TopMost = true;
        }

        private void tsmiSaveImage_Click(object sender, EventArgs e)
        {

        }

        bool bLive = false;
        private void tsbtnJog_Click(object sender, EventArgs e)
        {
            //if (!bLive)
            //{
                TaskVision.flirCamera2[0].imgBoxEmgu = imgboxEmgu;
                imgboxEmgu.Image = TaskVision.flirCamera2[0].m_ImageEmgu.m_Image;
                bLive = true;

                foreach (ToolStripItem c in toolStrip1.Items)
                {
                    c.Enabled = c.Name == "tsbtnJog" || c.Name == "tsbtnCancel";
                }

                frm_DispCore_JogGantry2 frm_Jog2 = new frm_DispCore_JogGantry2();
            frm_Jog2.TopMost = true;
            frm_Jog2.StartPosition = FormStartPosition.Manual;
            frm_Jog2.Location = new Point(640, 480);
            frm_Jog2.ShowDialog();
            //}
            //else
            //{
            nowImage = TaskVision.flirCamera2[0].m_ImageEmgu.m_Image.Copy();
                //bLive = false;

                foreach (ToolStripItem c in toolStrip1.Items)
                {
                    c.Enabled = true;
                }

                tscbxImage_SelectedIndexChanged(sender, e);
            //}
        }
    }

    class TFVision
    {
        public enum EToolType { /*PatMatch,*/ PatEdgeCorner, PatCircle };
        public static EToolType Tool = EToolType.PatEdgeCorner;

        public static bool PatLearn(Image<Gray, byte> nowImg, ref Image<Gray, byte> regImg, ref int threshold, ref Rectangle[] rects)
        {
            try
            {
                frmImageSelectBox frmSelectBox = new frmImageSelectBox(nowImg, regImg, "Define Search and Pattern Windows.", rects, new string[] { "Search Window", "Pattern Window" });
                frmSelectBox.TopMost = true;
                frmSelectBox.Threshold = threshold;
                DialogResult dr = frmSelectBox.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    regImg = frmSelectBox.regImage.Copy();
                    threshold = frmSelectBox.Threshold;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
                return false;
            }
            finally
            {
            }
        }
        public static bool PatMatch(Image<Gray, byte> img, Image<Gray, byte> regImg, int threshold, Rectangle[] rect, ref PointF patLoc, ref PointF patOffset, ref double score)
        {
            Image<Gray, byte> image = null;
            Image<Gray, byte> imgTemplate = null;
            Image<Gray, float> imgResult = null;
            try
            {
                if (threshold >= 0)
                {
                    image = img.ThresholdBinary(new Gray(threshold), new Gray(255));
                    imgTemplate = regImg.ThresholdBinary(new Gray(threshold), new Gray(255));
                }
                else
                {
                    image = img.Copy();
                    imgTemplate = regImg.Copy();
                }

                //  Define search rect to include pattern size for part edge detection
                Rectangle searchRect = rect[0];
                searchRect.X = Math.Max(0, rect[0].X - rect[1].Width);
                searchRect.Y = Math.Max(0, rect[0].Y - rect[1].Height);
                searchRect.Width = Math.Min(regImg.Width - searchRect.X, rect[0].Width + rect[1].Width * 2);
                searchRect.Height = Math.Min(regImg.Height - searchRect.Y, rect[0].Height + rect[1].Height * 2);

                imgResult = image.Copy(searchRect).MatchTemplate(imgTemplate.Copy(rect[1]), Emgu.CV.CvEnum.TemplateMatchingType.SqdiffNormed);

                double[] minCorr;
                double[] maxCorr;
                Point[] minPt;
                Point[] maxPt;
                imgResult.MinMax(out minCorr, out maxCorr, out minPt, out maxPt);

                patLoc.X = searchRect.X + (float)minPt[0].X;
                patLoc.Y = searchRect.Y + (float)minPt[0].Y;
                patOffset.X = patLoc.X - rect[1].X;
                patOffset.Y = patLoc.Y - rect[1].Y;
                score = (float)(1 - minCorr[0]);

                //  Set score to 0 if out of search reigion
                if (patLoc.X < rect[0].X || patLoc.Y < rect[0].Y ||
                    patLoc.X > rect[0].X + rect[0].Width - rect[1].Width ||
                    patLoc.Y > rect[0].Y + rect[0].Height - rect[1].Height)
                    score = 0;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
                return false;
            }
            finally
            {
                if (imgTemplate != null) imgTemplate.Dispose();
                if (imgResult != null) imgResult.Dispose();
            }
        }

        public static bool PatEdgeLearn(Image<Gray, byte> nowImg, ref Image<Gray, byte> regImg, ref Rectangle[] rects, EArea area, EDirection dir1, EDirection dir2, ETransition trans1, ETransition trans2)
        {
            Tool = EToolType.PatEdgeCorner;

            try
            {
                string[] s = new string[] { "Search" };
                if (area == EArea.Dual_VertHort) s = new string[] { "Window_X", "Window_Y" };
                frmImageSelectBox frmSelectBox = new frmImageSelectBox(nowImg, regImg, "Define Search Window.", rects, s);
                frmSelectBox.StartPosition = FormStartPosition.Manual;
                frmSelectBox.TopMost = true;
                frmSelectBox.Location = new Point(0, 0);
                frmSelectBox.Size = new Size(800, 600);
                frmSelectBox.Areas = area;
                frmSelectBox.DirectionX = dir1;
                frmSelectBox.DirectionY = dir2;
                frmSelectBox.TransX = trans1;
                frmSelectBox.TransY = trans2;
                DialogResult dr = frmSelectBox.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    regImg = frmSelectBox.regImage.Copy();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
                return false;
            }
            finally
            {
            }
        }
        private static float[] ProfileFindTransitions(PointF[] pointPair, ETransition trans, int minAmplitude, ref float amplitude)
        {
            //identify peaks, valleys
            PointF[] peaks = new PointF[] { };
            PointF[] valleys = new PointF[] { };
            PointF[] boths = new PointF[] { };

            for (int i = 1; i < pointPair.Length - 1; i++)
            {
                if ((pointPair[i].Y > pointPair[i - 1].Y) && (pointPair[i].Y >= pointPair[i + 1].Y))
                {
                    peaks = peaks.Concat(new PointF[] { pointPair[i] }).ToArray();
                    boths = boths.Concat(new PointF[] { new PointF(pointPair[i].X, Math.Abs(pointPair[i].Y)) }).ToArray();
                }

                if ((pointPair[i].Y < pointPair[i - 1].Y) && (pointPair[i].Y <= pointPair[i + 1].Y))
                {
                    valleys = valleys.Concat(new PointF[] { pointPair[i] }).ToArray();
                    boths = boths.Concat(new PointF[] { new PointF(pointPair[i].X, Math.Abs(pointPair[i].Y)) }).ToArray();
                }
            }
            switch (trans)
            {
                case ETransition.BW:
                    {
                        Array.Sort(peaks, delegate (PointF p1, PointF p2) { return p2.Y.CompareTo(p1.Y); });
                        peaks = peaks.Where(x => Math.Abs(x.Y) > minAmplitude).ToArray();
                        if (peaks.Length > 0) amplitude = peaks[0].Y;
                        return peaks.Select(x => x.X).ToArray();
                    }
                case ETransition.WB:
                    {
                        Array.Sort(valleys, delegate (PointF p1, PointF p2) { return p1.Y.CompareTo(p2.Y); });
                        valleys = valleys.Where(x => Math.Abs(x.Y) > minAmplitude).ToArray();
                        if (valleys.Length > 0) amplitude = Math.Abs(valleys[0].Y);
                        return valleys.Select(x => x.X).ToArray();
                    }
                default://case ETransition.AUTO:
                    {
                        Array.Sort(boths, delegate (PointF p1, PointF p2) { return p2.Y.CompareTo(p1.Y); });
                        boths = boths.Where(x => Math.Abs(x.Y) > minAmplitude).ToArray();
                        if (boths.Length > 0) amplitude = boths[0].Y;
                        return boths.Select(x => x.X).ToArray();
                    }
            }
        }
        public static bool PatEdgeCorner(Image<Gray, byte> img, Rectangle[] rect, ref List<PointF> stepsX, ref List<PointF> stepsY, ref float amplitude,
            int minAmplitude = 10,
            EDirection dirV = EDirection.PLUS, EDirection dirH = EDirection.PLUS,
            ETransition transV = ETransition.AUTO, ETransition transH = ETransition.AUTO, int gaugeWidth = 20, int gaugeInterval = 5)
        {
            Image<Gray, byte> tempImg = null;
            try
            {
                tempImg = img.Copy();

                byte[,,] dataImg = tempImg.Data;

                List<double> prof = new List<double>();
                PointF[] profDV = new PointF[] { };

                amplitude = 0;
                float amplitudeX = 255;
                float amplitudeY = 255;

                #region find vertival tranistion points ------|-------
                tempImg.ROI = rect[0];
                for (int s = tempImg.ROI.Top; s < (tempImg.ROI.Bottom - 1); s += gaugeInterval)
                {
                    List<double> stepProf = new List<double>();
                    PointF[] stepProfDV = new PointF[] { };

                    if (dirV == EDirection.PLUS)
                    {
                        for (int j = tempImg.ROI.Left; j < (tempImg.ROI.Right - 1); j++)
                        {
                            uint sum = 0;
                            for (int i = s - gaugeWidth / 2; i < s - (gaugeWidth / 2) + gaugeWidth - 1; i++)
                            {
                                sum += dataImg[i, j, 0];
                            }
                            float ave = sum / gaugeWidth;

                            stepProf.Add(ave);
                            float dv = (float)(stepProf.Count > 1 ? ave - stepProf[stepProf.Count - 2] : 0);
                            stepProfDV = stepProfDV.Concat(new PointF[] { new PointF(j, dv) }).ToArray();
                        }
                    }
                    else
                    {
                        for (int j = tempImg.ROI.Right; j > (tempImg.ROI.Left + 1); j--)
                        {
                            uint sum = 0;
                            for (int i = s - gaugeWidth / 2; i < s - (gaugeWidth / 2) + gaugeWidth - 1; i++)
                            {
                                sum += dataImg[i, j, 0];
                            }
                            float ave = sum / gaugeWidth;

                            stepProf.Add(ave);
                            float dv = (float)(stepProf.Count > 1 ? ave - stepProf[stepProf.Count - 2] : 0);
                            stepProfDV = stepProfDV.Concat(new PointF[] { new PointF(j, dv) }).ToArray();
                        }
                    }

                    float amp = 0;
                    float[] stepX = ProfileFindTransitions(stepProfDV, transV, minAmplitude, ref amp);
                    if (stepX.Length > 0)
                    {
                        amplitudeX = Math.Min(amplitudeX, amp);
                        stepsX.Add(new PointF(stepX[0], s));
                    }
                }
                #endregion

                #region find horizontal tranistion points ------_-------
                prof = new List<double>();
                profDV = new PointF[] { };
                tempImg.ROI = rect[1];
                for (int s = tempImg.ROI.Left; s < (tempImg.ROI.Right - 1); s += gaugeInterval)
                {
                    List<double> stepProf = new List<double>();
                    PointF[] stepProfDV = new PointF[] { };

                    if (dirH == EDirection.PLUS)
                    {
                        for (int i = tempImg.ROI.Top; i < (tempImg.ROI.Bottom - 1); i++)
                        {
                            uint sum = 0;
                            for (int j = s - gaugeWidth / 2; j < s - (gaugeWidth / 2) + gaugeWidth - 1; j++)
                            {
                                sum += dataImg[i, j, 0];
                            }
                            float ave = sum / gaugeWidth;

                            stepProf.Add(ave);
                            float dv = (float)(stepProf.Count > 1 ? ave - stepProf[stepProf.Count - 2] : 0);
                            stepProfDV = stepProfDV.Concat(new PointF[] { new PointF(i, dv) }).ToArray();
                        }
                    }
                    else
                    {
                        for (int i = tempImg.ROI.Bottom; i > (tempImg.ROI.Top + 1); i--)
                        {
                            uint sum = 0;
                            for (int j = s - gaugeWidth / 2; j < s - (gaugeWidth / 2) + gaugeWidth - 1; j++)
                            {
                                sum += dataImg[i, j, 0];
                            }
                            float ave = sum / gaugeWidth;

                            stepProf.Add(ave);
                            float dv = (float)(stepProf.Count > 1 ? ave - stepProf[stepProf.Count - 2] : 0);
                            stepProfDV = stepProfDV.Concat(new PointF[] { new PointF(i, dv) }).ToArray();
                        }
                    }

                    float amp = 0;
                    float[] stepY = ProfileFindTransitions(stepProfDV, transH, minAmplitude, ref amp);
                    if (stepY.Length > 0)
                    {
                        amplitudeY = Math.Min(amplitudeY, amp);
                        stepsY.Add(new PointF(s, stepY[0]));
                    }
                }
                #endregion

                amplitude = Math.Min(amplitudeX, amplitudeY);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
                return false;
            }
            finally
            {
                tempImg.Dispose();
            }
        }

        public enum EArea { Single, Dual_VertHort };
        public enum EDirPair { XRight_YDown, XRight_YUp, XLeft_YDown, XLeft_YUp };
        public enum ETransPair { Auto, BW, WB, XBW_YWB, XWB_YBW };

        public enum ETransition { AUTO, BW, WB };
        public enum EDirection { PLUS, MINUS };
        public static bool PatEdgeCorner(Image<Gray, byte> img, Image<Gray, byte> regImg, Rectangle[] rect, ref List<PointF> stepsX, ref List<PointF> stepsY, ref PointF loc, ref PointF ofst, ref float amplitude, 
            EArea area, EDirection directionX, EDirection directionY, ETransition transitionX, ETransition transitionY)
        {
            if (area == TFVision.EArea.Single) rect[1] = rect[0];

            List<PointF> regPointX = new List<PointF>();
            List<PointF> regPointY = new List<PointF>();
            float regAmp = 0;
            bool resReg = PatEdgeCorner(regImg, rect, ref regPointX, ref regPointY, ref regAmp, 10, directionX, directionY, transitionX, transitionY);
            PointF regloc = new PointF(0, 0);

            if (regPointX.Count > 0)
            {
                var sortedListregX = regPointX.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
                regloc.X = sortedListregX[sortedListregX.Count / 2].X;
                loc.X = regloc.X;
            }
            if (regPointY.Count > 0)
            {
                var sortedListregY = regPointY.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                regloc.Y = sortedListregY[sortedListregY.Count / 2].Y;
                loc.Y = regloc.Y;
            }

            List<PointF> pointX = new List<PointF>();
            List<PointF> pointY = new List<PointF>();
            bool res = PatEdgeCorner(img, rect, ref pointX, ref pointY, ref amplitude, 10, directionX, directionY, transitionX, transitionY);
            stepsX = pointX;
            stepsY = pointY;

            if (pointX.Count == 0 || pointY.Count == 0) amplitude = 0;
            if (pointX.Count > 0)
            {
                var sortedListX = pointX.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
                loc.X = sortedListX[sortedListX.Count / 2].X;
            }
            if (pointY.Count > 0)
            {
                var sortedListY = pointY.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                loc.Y = sortedListY[sortedListY.Count / 2].Y;
            }

            ofst = new PointF(0, 0);

            if (regPointX.Count > 0 && pointX.Count > 0) ofst.X = loc.X - regloc.X;
            if (regPointY.Count > 0 && pointY.Count > 0) ofst.Y = loc.Y - regloc.Y;

            return res;
        }

        public static bool PatCircleLearn(Image<Gray, byte> nowImg, ref Image<Gray, byte> regImg, ref int threshold, ref Rectangle[] rects, EDetContrast detContrast)
        {
            Tool = EToolType.PatCircle;

            try
            {
                string[] s = new string[] { "Search" };
 
                frmImageSelectBox frmSelectBox = new frmImageSelectBox(nowImg, regImg, "Define Search Window.", rects, s);
                frmSelectBox.StartPosition = FormStartPosition.Manual;
                frmSelectBox.TopMost = true;
                frmSelectBox.Location = new Point(0, 0);
                frmSelectBox.Size = new Size(800, 600);
                frmSelectBox.Threshold = threshold;
                frmSelectBox.detContrast = detContrast;
                DialogResult dr = frmSelectBox.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    regImg = frmSelectBox.regImage.Copy();
                }

                threshold = frmSelectBox.Threshold;


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
                return false;
            }
            finally
            {
            }
        }
        public enum EDetContrast { Dark, Bright };
        public static int FindCircles(Image<Gray, byte> img, int threshold, EDetContrast detContrast, ref PointF[] Center, ref float[] Radius, ref float[] Roundness)
        {
            Image<Bgra, Byte> imgColor = img.Convert<Bgra, Byte>();
            Image<Gray, Byte> img_Gray = img.PyrDown().PyrUp();

            Image<Gray, Byte> img_Bin = null;
            try
            {
                Gray g_Ave = threshold >= 0 ? new Gray(threshold) : img_Gray.GetAverage();

                if (detContrast == EDetContrast.Dark)
                    img_Bin = img_Gray.ThresholdBinaryInv(g_Ave, new Gray(255));
                else
                    img_Bin = img_Gray.ThresholdBinary(g_Ave, new Gray(255));

                img_Bin = img_Bin.Erode(1);
                img_Bin = img_Bin.Dilate(1);

                //CvInvoke.Imshow("10", img_Bin);

                VectorOfVectorOfPoint Contour = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(img_Bin, Contour, null, Emgu.CV.CvEnum.RetrType.Ccomp, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                if (Contour == null) return 0;
                if (Contour.Size == 0) return 0;

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                List<VectorOfPoint> contours2 = new List<VectorOfPoint>();
                for (int i = 0; i < Contour.Size; i++)
                {
                    VectorOfPoint cntr = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(Contour[i], cntr, 0.01 * CvInvoke.ArcLength(Contour[i], true), true);

                    double len = CvInvoke.ArcLength(cntr, true);
                    double area = CvInvoke.ContourArea(Contour[i]);
                    double roundness = (4 * Math.PI * area) / Math.Pow(len, 2);

                    //  filter length > 10 pixel and area > 30
                    //  roundness = 4*Pi*Area / Perimeter^2
                    if (len > 20 && area > 30 && roundness > 0.7)
                    {
                        contours2.Add(cntr);
                    }
                }

                if (contours2.Count == 0) return 0;

                contours2.Sort((a, b) => CvInvoke.ContourArea(b).CompareTo(CvInvoke.ContourArea(a)));

                Center = contours2.Select(x => new PointF((float)(CvInvoke.Moments(x).M10 / CvInvoke.Moments(x).M00) + img.ROI.X, (float)(CvInvoke.Moments(x).M01 / CvInvoke.Moments(x).M00) + img.ROI.Y)).ToArray();
                Radius = contours2.Select(x => CvInvoke.MinEnclosingCircle(x).Radius).ToArray();
                Roundness = contours2.Select(x => (float)((4 * Math.PI * CvInvoke.ContourArea(x)) / Math.Pow(CvInvoke.ArcLength(x, true), 2))).ToArray();
            }
            catch
            {
                return 0;
            }
            finally
            {
                imgColor.Dispose();
                img_Gray.Dispose();
                img_Bin.Dispose();
            }

            return Center.Count();
        }
        public static int PatCircle(Image<Gray, byte> img, Image<Gray, byte> regImg, int threshold, Rectangle[] rect, EDetContrast detContrast, ref PointF loc, ref float rad, ref PointF ofst, ref float roundness)
        {
            regImg.ROI = rect[0];
            PointF[] regCenter = null;
            float[] regRadius = null;
            float[] regRoundness = null;
            int regCount = FindCircles(regImg, threshold, detContrast, ref regCenter, ref regRadius, ref regRoundness);
            regImg.ROI = Rectangle.Empty;
            if (regCount == 0) return 0;


            img.ROI = rect[0];
            PointF[] center = null;
            float[] radius = null;
            float[] imgRoundness = null;
            int count = FindCircles(img, threshold, detContrast, ref center, ref radius, ref imgRoundness);
            img.ROI = Rectangle.Empty;
            if (count == 0) return 0;

            loc = center[0];
            rad = radius[0];
            roundness = imgRoundness[0];
            ofst = new PointF(center[0].X - regCenter[0].X, center[0].Y - regCenter[0].Y);

            return count;
        }
    }
}
