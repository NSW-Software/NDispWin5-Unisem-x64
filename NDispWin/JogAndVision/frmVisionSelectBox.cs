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
using System.Reflection;

namespace NDispWin
{
    using Emgu.CV;
    using Emgu.CV.Structure;
    using Emgu.CV.Util;

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
            GControl.LogForm(this);

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

    //class TFVision
    //{
    //    public enum EToolType { /*PatMatch,*/ PatEdgeCorner, PatCircle };
    //    public static EToolType Tool = EToolType.PatEdgeCorner;

    //    public static bool PatLearn(Image<Gray, byte> nowImg, ref Image<Gray, byte> regImg, ref int threshold, ref Rectangle[] rects)
    //    {
    //        try
    //        {
    //            frmImageSelectBox frmSelectBox = new frmImageSelectBox(nowImg, regImg, "Define Search and Pattern Windows.", rects, new string[] { "Search Window", "Pattern Window" });
    //            frmSelectBox.TopMost = true;
    //            frmSelectBox.Threshold = threshold;
    //            DialogResult dr = frmSelectBox.ShowDialog();

    //            if (dr == DialogResult.OK)
    //            {
    //                regImg = frmSelectBox.regImage.Copy();
    //                threshold = frmSelectBox.Threshold;
    //            }

    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
    //            return false;
    //        }
    //        finally
    //        {
    //        }
    //    }
    //    public static bool PatMatch(Image<Gray, byte> img, Image<Gray, byte> regImg, int threshold, Rectangle[] rect, ref PointF patLoc, ref PointF patOffset, ref double score)
    //    {
    //        Image<Gray, byte> image = null;
    //        Image<Gray, byte> imgTemplate = null;
    //        Image<Gray, float> imgResult = null;
    //        try
    //        {
    //            if (threshold >= 0)
    //            {
    //                image = img.ThresholdBinary(new Gray(threshold), new Gray(255));
    //                imgTemplate = regImg.ThresholdBinary(new Gray(threshold), new Gray(255));
    //            }
    //            else
    //            {
    //                image = img.Copy();
    //                imgTemplate = regImg.Copy();
    //            }

    //            //  Define search rect to include pattern size for part edge detection
    //            Rectangle searchRect = rect[0];
    //            searchRect.X = Math.Max(0, rect[0].X - rect[1].Width);
    //            searchRect.Y = Math.Max(0, rect[0].Y - rect[1].Height);
    //            searchRect.Width = Math.Min(regImg.Width - searchRect.X, rect[0].Width + rect[1].Width * 2);
    //            searchRect.Height = Math.Min(regImg.Height - searchRect.Y, rect[0].Height + rect[1].Height * 2);

    //            imgResult = image.Copy(searchRect).MatchTemplate(imgTemplate.Copy(rect[1]), Emgu.CV.CvEnum.TemplateMatchingType.SqdiffNormed);

    //            double[] minCorr;
    //            double[] maxCorr;
    //            Point[] minPt;
    //            Point[] maxPt;
    //            imgResult.MinMax(out minCorr, out maxCorr, out minPt, out maxPt);

    //            patLoc.X = searchRect.X + (float)minPt[0].X;
    //            patLoc.Y = searchRect.Y + (float)minPt[0].Y;
    //            patOffset.X = patLoc.X - rect[1].X;
    //            patOffset.Y = patLoc.Y - rect[1].Y;
    //            score = (float)(1 - minCorr[0]);

    //            //  Set score to 0 if out of search reigion
    //            if (patLoc.X < rect[0].X || patLoc.Y < rect[0].Y ||
    //                patLoc.X > rect[0].X + rect[0].Width - rect[1].Width ||
    //                patLoc.Y > rect[0].Y + rect[0].Height - rect[1].Height)
    //                score = 0;

    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
    //            return false;
    //        }
    //        finally
    //        {
    //            if (imgTemplate != null) imgTemplate.Dispose();
    //            if (imgResult != null) imgResult.Dispose();
    //        }
    //    }

    //    public static bool PatEdgeLearn(Image<Gray, byte> nowImg, ref Image<Gray, byte> regImg, ref Rectangle[] rects, EArea area, EDirection dir1, EDirection dir2, ETransition trans1, ETransition trans2)
    //    {
    //        Tool = EToolType.PatEdgeCorner;

    //        try
    //        {
    //            string[] s = new string[] { "Search" };
    //            if (area == EArea.Dual_VertHort) s = new string[] { "Window_X", "Window_Y" };
    //            frmImageSelectBox frmSelectBox = new frmImageSelectBox(nowImg, regImg, "Define Search Window.", rects, s);
    //            frmSelectBox.StartPosition = FormStartPosition.Manual;
    //            frmSelectBox.TopMost = true;
    //            frmSelectBox.Location = new Point(0, 0);
    //            frmSelectBox.Size = new Size(800, 600);
    //            frmSelectBox.Areas = area;
    //            frmSelectBox.DirectionX = dir1;
    //            frmSelectBox.DirectionY = dir2;
    //            frmSelectBox.TransX = trans1;
    //            frmSelectBox.TransY = trans2;
    //            DialogResult dr = frmSelectBox.ShowDialog();

    //            if (dr == DialogResult.OK)
    //            {
    //                regImg = frmSelectBox.regImage.Copy();
    //            }

    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
    //            return false;
    //        }
    //        finally
    //        {
    //        }
    //    }
    //    private static float[] ProfileFindTransitions(PointF[] pointPair, ETransition trans, int minAmplitude, ref float amplitude)
    //    {
    //        //identify peaks, valleys
    //        PointF[] peaks = new PointF[] { };
    //        PointF[] valleys = new PointF[] { };
    //        PointF[] boths = new PointF[] { };

    //        for (int i = 1; i < pointPair.Length - 1; i++)
    //        {
    //            if ((pointPair[i].Y > pointPair[i - 1].Y) && (pointPair[i].Y >= pointPair[i + 1].Y))
    //            {
    //                peaks = peaks.Concat(new PointF[] { pointPair[i] }).ToArray();
    //                boths = boths.Concat(new PointF[] { new PointF(pointPair[i].X, Math.Abs(pointPair[i].Y)) }).ToArray();
    //            }

    //            if ((pointPair[i].Y < pointPair[i - 1].Y) && (pointPair[i].Y <= pointPair[i + 1].Y))
    //            {
    //                valleys = valleys.Concat(new PointF[] { pointPair[i] }).ToArray();
    //                boths = boths.Concat(new PointF[] { new PointF(pointPair[i].X, Math.Abs(pointPair[i].Y)) }).ToArray();
    //            }
    //        }
    //        switch (trans)
    //        {
    //            case ETransition.BW:
    //                {
    //                    Array.Sort(peaks, delegate (PointF p1, PointF p2) { return p2.Y.CompareTo(p1.Y); });
    //                    peaks = peaks.Where(x => Math.Abs(x.Y) > minAmplitude).ToArray();
    //                    if (peaks.Length > 0) amplitude = peaks[0].Y;
    //                    return peaks.Select(x => x.X).ToArray();
    //                }
    //            case ETransition.WB:
    //                {
    //                    Array.Sort(valleys, delegate (PointF p1, PointF p2) { return p1.Y.CompareTo(p2.Y); });
    //                    valleys = valleys.Where(x => Math.Abs(x.Y) > minAmplitude).ToArray();
    //                    if (valleys.Length > 0) amplitude = Math.Abs(valleys[0].Y);
    //                    return valleys.Select(x => x.X).ToArray();
    //                }
    //            default://case ETransition.AUTO:
    //                {
    //                    Array.Sort(boths, delegate (PointF p1, PointF p2) { return p2.Y.CompareTo(p1.Y); });
    //                    boths = boths.Where(x => Math.Abs(x.Y) > minAmplitude).ToArray();
    //                    if (boths.Length > 0) amplitude = boths[0].Y;
    //                    return boths.Select(x => x.X).ToArray();
    //                }
    //        }
    //    }
    //    public static bool PatEdgeCorner(Image<Gray, byte> img, Rectangle[] rect, ref List<PointF> stepsX, ref List<PointF> stepsY, ref float amplitude,
    //        int minAmplitude = 10,
    //        EDirection dirV = EDirection.PLUS, EDirection dirH = EDirection.PLUS,
    //        ETransition transV = ETransition.AUTO, ETransition transH = ETransition.AUTO, int gaugeWidth = 20, int gaugeInterval = 5)
    //    {
    //        Image<Gray, byte> tempImg = null;
    //        try
    //        {
    //            tempImg = img.Copy();

    //            byte[,,] dataImg = tempImg.Data;

    //            List<double> prof = new List<double>();
    //            PointF[] profDV = new PointF[] { };

    //            amplitude = 0;
    //            float amplitudeX = 255;
    //            float amplitudeY = 255;

    //            #region find vertival tranistion points ------|-------
    //            tempImg.ROI = rect[0];
    //            for (int s = tempImg.ROI.Top; s < (tempImg.ROI.Bottom - 1); s += gaugeInterval)
    //            {
    //                List<double> stepProf = new List<double>();
    //                PointF[] stepProfDV = new PointF[] { };

    //                if (dirV == EDirection.PLUS)
    //                {
    //                    for (int j = tempImg.ROI.Left; j < (tempImg.ROI.Right - 1); j++)
    //                    {
    //                        uint sum = 0;
    //                        for (int i = s - gaugeWidth / 2; i < s - (gaugeWidth / 2) + gaugeWidth - 1; i++)
    //                        {
    //                            sum += dataImg[i, j, 0];
    //                        }
    //                        float ave = sum / gaugeWidth;

    //                        stepProf.Add(ave);
    //                        float dv = (float)(stepProf.Count > 1 ? ave - stepProf[stepProf.Count - 2] : 0);
    //                        stepProfDV = stepProfDV.Concat(new PointF[] { new PointF(j, dv) }).ToArray();
    //                    }
    //                }
    //                else
    //                {
    //                    for (int j = tempImg.ROI.Right; j > (tempImg.ROI.Left + 1); j--)
    //                    {
    //                        uint sum = 0;
    //                        for (int i = s - gaugeWidth / 2; i < s - (gaugeWidth / 2) + gaugeWidth - 1; i++)
    //                        {
    //                            sum += dataImg[i, j, 0];
    //                        }
    //                        float ave = sum / gaugeWidth;

    //                        stepProf.Add(ave);
    //                        float dv = (float)(stepProf.Count > 1 ? ave - stepProf[stepProf.Count - 2] : 0);
    //                        stepProfDV = stepProfDV.Concat(new PointF[] { new PointF(j, dv) }).ToArray();
    //                    }
    //                }

    //                float amp = 0;
    //                float[] stepX = ProfileFindTransitions(stepProfDV, transV, minAmplitude, ref amp);
    //                if (stepX.Length > 0)
    //                {
    //                    amplitudeX = Math.Min(amplitudeX, amp);
    //                    stepsX.Add(new PointF(stepX[0], s));
    //                }
    //            }
    //            #endregion

    //            #region find horizontal tranistion points ------_-------
    //            prof = new List<double>();
    //            profDV = new PointF[] { };
    //            tempImg.ROI = rect[1];
    //            for (int s = tempImg.ROI.Left; s < (tempImg.ROI.Right - 1); s += gaugeInterval)
    //            {
    //                List<double> stepProf = new List<double>();
    //                PointF[] stepProfDV = new PointF[] { };

    //                if (dirH == EDirection.PLUS)
    //                {
    //                    for (int i = tempImg.ROI.Top; i < (tempImg.ROI.Bottom - 1); i++)
    //                    {
    //                        uint sum = 0;
    //                        for (int j = s - gaugeWidth / 2; j < s - (gaugeWidth / 2) + gaugeWidth - 1; j++)
    //                        {
    //                            sum += dataImg[i, j, 0];
    //                        }
    //                        float ave = sum / gaugeWidth;

    //                        stepProf.Add(ave);
    //                        float dv = (float)(stepProf.Count > 1 ? ave - stepProf[stepProf.Count - 2] : 0);
    //                        stepProfDV = stepProfDV.Concat(new PointF[] { new PointF(i, dv) }).ToArray();
    //                    }
    //                }
    //                else
    //                {
    //                    for (int i = tempImg.ROI.Bottom; i > (tempImg.ROI.Top + 1); i--)
    //                    {
    //                        uint sum = 0;
    //                        for (int j = s - gaugeWidth / 2; j < s - (gaugeWidth / 2) + gaugeWidth - 1; j++)
    //                        {
    //                            sum += dataImg[i, j, 0];
    //                        }
    //                        float ave = sum / gaugeWidth;

    //                        stepProf.Add(ave);
    //                        float dv = (float)(stepProf.Count > 1 ? ave - stepProf[stepProf.Count - 2] : 0);
    //                        stepProfDV = stepProfDV.Concat(new PointF[] { new PointF(i, dv) }).ToArray();
    //                    }
    //                }

    //                float amp = 0;
    //                float[] stepY = ProfileFindTransitions(stepProfDV, transH, minAmplitude, ref amp);
    //                if (stepY.Length > 0)
    //                {
    //                    amplitudeY = Math.Min(amplitudeY, amp);
    //                    stepsY.Add(new PointF(s, stepY[0]));
    //                }
    //            }
    //            #endregion

    //            amplitude = Math.Min(amplitudeX, amplitudeY);

    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
    //            return false;
    //        }
    //        finally
    //        {
    //            tempImg.Dispose();
    //        }
    //    }

    //    public enum EArea { Single, Dual_VertHort };
    //    public enum EDirPair { XRight_YDown, XRight_YUp, XLeft_YDown, XLeft_YUp };
    //    public enum ETransPair { Auto, BW, WB, XBW_YWB, XWB_YBW };

    //    public enum ETransition { AUTO, BW, WB };
    //    public enum EDirection { PLUS, MINUS };
    //    public static bool PatEdgeCorner(Image<Gray, byte> img, Image<Gray, byte> regImg, Rectangle[] rect, ref List<PointF> stepsX, ref List<PointF> stepsY, ref PointF loc, ref PointF ofst, ref float amplitude,
    //        EArea area, EDirection directionX, EDirection directionY, ETransition transitionX, ETransition transitionY)
    //    {
    //        if (area == TFVision.EArea.Single) rect[1] = rect[0];

    //        List<PointF> regPointX = new List<PointF>();
    //        List<PointF> regPointY = new List<PointF>();
    //        float regAmp = 0;
    //        bool resReg = PatEdgeCorner(regImg, rect, ref regPointX, ref regPointY, ref regAmp, 10, directionX, directionY, transitionX, transitionY);
    //        PointF regloc = new PointF(0, 0);

    //        if (regPointX.Count > 0)
    //        {
    //            var sortedListregX = regPointX.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
    //            regloc.X = sortedListregX[sortedListregX.Count / 2].X;
    //            loc.X = regloc.X;
    //        }
    //        if (regPointY.Count > 0)
    //        {
    //            var sortedListregY = regPointY.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
    //            regloc.Y = sortedListregY[sortedListregY.Count / 2].Y;
    //            loc.Y = regloc.Y;
    //        }

    //        List<PointF> pointX = new List<PointF>();
    //        List<PointF> pointY = new List<PointF>();
    //        bool res = PatEdgeCorner(img, rect, ref pointX, ref pointY, ref amplitude, 10, directionX, directionY, transitionX, transitionY);
    //        stepsX = pointX;
    //        stepsY = pointY;

    //        if (pointX.Count == 0 || pointY.Count == 0) amplitude = 0;
    //        if (pointX.Count > 0)
    //        {
    //            var sortedListX = pointX.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
    //            loc.X = sortedListX[sortedListX.Count / 2].X;
    //        }
    //        if (pointY.Count > 0)
    //        {
    //            var sortedListY = pointY.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
    //            loc.Y = sortedListY[sortedListY.Count / 2].Y;
    //        }

    //        ofst = new PointF(0, 0);

    //        if (regPointX.Count > 0 && pointX.Count > 0) ofst.X = loc.X - regloc.X;
    //        if (regPointY.Count > 0 && pointY.Count > 0) ofst.Y = loc.Y - regloc.Y;

    //        return res;
    //    }

    //    public static bool PatCircleLearn(Image<Gray, byte> nowImg, ref Image<Gray, byte> regImg, ref int threshold, ref Rectangle[] rects, EDetContrast detContrast)
    //    {
    //        Tool = EToolType.PatCircle;

    //        try
    //        {
    //            string[] s = new string[] { "Search" };

    //            frmImageSelectBox frmSelectBox = new frmImageSelectBox(nowImg, regImg, "Define Search Window.", rects, s);
    //            frmSelectBox.StartPosition = FormStartPosition.Manual;
    //            frmSelectBox.TopMost = true;
    //            frmSelectBox.Location = new Point(0, 0);
    //            frmSelectBox.Size = new Size(800, 600);
    //            frmSelectBox.Threshold = threshold;
    //            frmSelectBox.detContrast = detContrast;
    //            DialogResult dr = frmSelectBox.ShowDialog();

    //            if (dr == DialogResult.OK)
    //            {
    //                regImg = frmSelectBox.regImage.Copy();
    //            }

    //            threshold = frmSelectBox.Threshold;


    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
    //            return false;
    //        }
    //        finally
    //        {
    //        }
    //    }
    //    public enum EDetContrast { Dark, Bright };
    //    public static int FindCircles(Image<Gray, byte> img, int threshold, EDetContrast detContrast, ref PointF[] Center, ref float[] Radius, ref float[] Roundness)
    //    {
    //        Image<Bgra, Byte> imgColor = img.Convert<Bgra, Byte>();
    //        Image<Gray, Byte> img_Gray = img.PyrDown().PyrUp();

    //        Image<Gray, Byte> img_Bin = null;
    //        try
    //        {
    //            Gray g_Ave = threshold >= 0 ? new Gray(threshold) : img_Gray.GetAverage();

    //            if (detContrast == EDetContrast.Dark)
    //                img_Bin = img_Gray.ThresholdBinaryInv(g_Ave, new Gray(255));
    //            else
    //                img_Bin = img_Gray.ThresholdBinary(g_Ave, new Gray(255));

    //            img_Bin = img_Bin.Erode(1);
    //            img_Bin = img_Bin.Dilate(1);

    //            //CvInvoke.Imshow("10", img_Bin);

    //            VectorOfVectorOfPoint Contour = new VectorOfVectorOfPoint();
    //            CvInvoke.FindContours(img_Bin, Contour, null, Emgu.CV.CvEnum.RetrType.Ccomp, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

    //            if (Contour == null) return 0;
    //            if (Contour.Size == 0) return 0;

    //            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
    //            List<VectorOfPoint> contours2 = new List<VectorOfPoint>();
    //            for (int i = 0; i < Contour.Size; i++)
    //            {
    //                VectorOfPoint cntr = new VectorOfPoint();
    //                CvInvoke.ApproxPolyDP(Contour[i], cntr, 0.01 * CvInvoke.ArcLength(Contour[i], true), true);

    //                double len = CvInvoke.ArcLength(cntr, true);
    //                double area = CvInvoke.ContourArea(Contour[i]);
    //                double roundness = (4 * Math.PI * area) / Math.Pow(len, 2);

    //                //  filter length > 10 pixel and area > 30
    //                //  roundness = 4*Pi*Area / Perimeter^2
    //                if (len > 20 && area > 30 && roundness > 0.7)
    //                {
    //                    contours2.Add(cntr);
    //                }
    //            }

    //            if (contours2.Count == 0) return 0;

    //            contours2.Sort((a, b) => CvInvoke.ContourArea(b).CompareTo(CvInvoke.ContourArea(a)));

    //            Center = contours2.Select(x => new PointF((float)(CvInvoke.Moments(x).M10 / CvInvoke.Moments(x).M00) + img.ROI.X, (float)(CvInvoke.Moments(x).M01 / CvInvoke.Moments(x).M00) + img.ROI.Y)).ToArray();
    //            Radius = contours2.Select(x => CvInvoke.MinEnclosingCircle(x).Radius).ToArray();
    //            Roundness = contours2.Select(x => (float)((4 * Math.PI * CvInvoke.ContourArea(x)) / Math.Pow(CvInvoke.ArcLength(x, true), 2))).ToArray();
    //        }
    //        catch
    //        {
    //            return 0;
    //        }
    //        finally
    //        {
    //            imgColor.Dispose();
    //            img_Gray.Dispose();
    //            img_Bin.Dispose();
    //        }

    //        return Center.Count();
    //    }
    //    public static int PatCircle(Image<Gray, byte> img, Image<Gray, byte> regImg, int threshold, Rectangle[] rect, EDetContrast detContrast, ref PointF loc, ref float rad, ref PointF ofst, ref float roundness)
    //    {
    //        regImg.ROI = rect[0];
    //        PointF[] regCenter = null;
    //        float[] regRadius = null;
    //        float[] regRoundness = null;
    //        int regCount = FindCircles(regImg, threshold, detContrast, ref regCenter, ref regRadius, ref regRoundness);
    //        regImg.ROI = Rectangle.Empty;
    //        if (regCount == 0) return 0;


    //        img.ROI = rect[0];
    //        PointF[] center = null;
    //        float[] radius = null;
    //        float[] imgRoundness = null;
    //        int count = FindCircles(img, threshold, detContrast, ref center, ref radius, ref imgRoundness);
    //        img.ROI = Rectangle.Empty;
    //        if (count == 0) return 0;

    //        loc = center[0];
    //        rad = radius[0];
    //        roundness = imgRoundness[0];
    //        ofst = new PointF(center[0].X - regCenter[0].X, center[0].Y - regCenter[0].Y);

    //        return count;
    //    }
    //}
}
