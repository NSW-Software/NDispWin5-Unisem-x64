using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDispWin
{
    partial class frm_DispCore_VisionSelectBox : Form
    {
        public Bitmap bmp;
        
        private SelectBox selectBox;
        private bool readOnly = false;
        private bool showSelectBox = true;

        public int Step = 0;
        public Rectangle tempSearchRect = new Rectangle();
        public Rectangle SearchRect = new Rectangle();
        public Rectangle PatternRect = new Rectangle();
        public int Threshold = 0;
        
        public frm_DispCore_VisionSelectBox()
        {
            InitializeComponent();

            pbox_Image.Width = TaskVision.ImgWN[0];
            pbox_Image.Height = TaskVision.ImgHN[0];

            pbox_Image.MouseMove += new MouseEventHandler(pbox_Image_MouseMove);
            pbox_Image.MouseDown += new MouseEventHandler(pbox_Image_MouseDown);
            pbox_Image.MouseUp += new MouseEventHandler(pbox_Image_MouseUp);

            this.selectBox = new SelectBox(this, new Rectangle(120, 120, 50, 50));
            this.selectBox.AddHandle(new HandleMove());
            this.selectBox.AddHandle(new HandleResizeNWSE());
            this.selectBox.AddHandle(new HandleResizeSouth());
            this.selectBox.AddHandle(new HandleResizeEast());
            this.selectBox.OnBoxChanged += new EventHandler(selectBox_OnBoxChanged);
        }

        private void frmVisionSelectBox_Load(object sender, EventArgs e)
        {
            Text = "Vision Select";

            if (pbox_Image.Width == 0 && bmp != null) pbox_Image.Width = bmp.Width;
            if (pbox_Image.Height == 0 && bmp != null) pbox_Image.Height = bmp.Height;

            pbox_Image.Image = bmp;
            hScrollBar1.Value = Threshold;
            lbl_Threshold.Text = Threshold.ToString();
            if (Threshold >= 0)
            {
                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = bmp.ToImage<Gray, byte>();//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(bmp);
                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> ImageT = Image.ThresholdBinary(new Emgu.CV.Structure.Gray(Threshold), new Emgu.CV.Structure.Gray(255));
                pbox_Image.Image = ImageT.ToBitmap();
            }

            Step = 0;
            ExecuteStep(Step);
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
            public Rectangle Rect;
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
                //Pen p = new Pen(SelectPictureBox.selectBoxColor, selectBoxThickness);
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

        public class HandleResizeNWSE : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeNWSE; } }
            protected override Point Position { get { return new Point(SelectBox.Rect.Right, SelectBox.Rect.Bottom); } }

            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.Width = e.X - SelectBox.Rect.X;
                SelectBox.Rect.Height = e.Y - SelectBox.Rect.Y;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();

            }
        }
        public class HandleResizeEast : HandleResize
        {
            public override Cursor Cursor { get { return Cursors.SizeWE; } }
            protected override Point Position { get { return new Point(SelectBox.Rect.Right, SelectBox.Rect.Top + SelectBox.Rect.Height / 2); } }
            public override void OnDragging(MouseEventArgs e)
            {
                SelectBox.Rect.Width = e.X - SelectBox.Rect.X;
                SelectBox.Parent.Invalidate();
                SelectBox.Parent.Refresh();
            }
        }
        public class HandleResizeSouth : HandleResize
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
                SelectBox.Rect.Height = e.Y - SelectBox.Rect.Y;
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
                dragStart = new Point(e.X - SelectBox.Rect.X, e.Y - SelectBox.Rect.Y);
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

            if (showSelectBox)
                selectBox.OnPaint(e, !readOnly);

            Color crossColor = Color.Green;
            int crossThickness = 5;
            int crossSize = 20;
            bool showCross = true;

            Pen p = new Pen(crossColor, crossThickness);

            if (showCross)
            {
                Point midPoint = new Point(
                    selectBox.Rect.Left + selectBox.Rect.Width / 2,
                    selectBox.Rect.Top + selectBox.Rect.Height / 2);

                e.Graphics.DrawLine(
                    p,
                    midPoint.X, midPoint.Y - crossSize,
                    midPoint.X, midPoint.Y + crossSize);

                e.Graphics.DrawLine(p, midPoint.X - crossSize, midPoint.Y, midPoint.X + crossSize, midPoint.Y);
            }
        }

        private void ExecuteStep(int Step)
        {
            switch (Step)
            {
                case 0:
                    {
                        btn_OK.Text = "Next";
                        btn_OK.Enabled = true;
                        SelectionRect = SearchRect;
                        lbl_Instruction.Text = "Adjust Window to Search Area.";
                        break;
                    }
                case 1:
                    {
                        btn_OK.Text = "OK";
                        btn_OK.Enabled = true;

                        tempSearchRect = SelectionRect;
                        SelectionRect = PatternRect;
                        Refresh();

                        lbl_Instruction.Text = "Adjust Window to Pattern Area.";
                        break;
                    }
                case 2:
                    {
                        SearchRect = tempSearchRect;
                        PatternRect = SelectionRect;

                        this.DialogResult = DialogResult.OK;
                        break;
                    }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //if (Step == 0)
            //{
                Step++;
                ExecuteStep(Step);
            //}

            //SearchRect = tempSearchRect;
            //PatternRect = SelectionRect;


        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Threshold = hScrollBar1.Value;
            lbl_Threshold.Text = Threshold.ToString();

            if (Threshold >= 0)
            {
                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = bmp.ToImage<Gray, byte>();//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(bmp);
                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> ImageT = Image.ThresholdBinary(new Emgu.CV.Structure.Gray(Threshold), new Emgu.CV.Structure.Gray(255));
                pbox_Image.Image = ImageT.ToBitmap();
            }
            else
                pbox_Image.Image = bmp;
        }

        private void btn_Threshold_Click(object sender, EventArgs e)
        {

        }

        private void btn_ResetROI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Set Search and Pattern Window to default?", "Reset ROI", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            SearchRect = new Rectangle(50,50,200,200);
            PatternRect = new Rectangle(100,100,100,100);
            SelectionRect = SearchRect;

            pbox_Image.Invalidate();
        }
    }
}
