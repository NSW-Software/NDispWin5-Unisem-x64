using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Emgu.CV;
using Emgu.CV.Structure;

namespace NDispWin
{
    public partial class frmCamera : Form
    {
        const int MAX_CAMERA = 4;
        public FlirCamera[] flirCamera = new FlirCamera[MAX_CAMERA];
        int m_iSelectedCam = 0;

        //  camera reticles
        public TReticles[] CamReticles = new TReticles[MAX_CAMERA];
        public bool ShowCamReticles = false;

        //  temp reticles
        public bool ShowReticles = false;
        public TReticles Reticles = new TReticles();

        public frmCamera()
        {
            InitializeComponent();

            pnl_Image.Dock = DockStyle.Fill;
            imgBoxEmgu.Dock = DockStyle.Fill;
        }

        private void UpdateControls()
        {
            if (flirCamera[m_iSelectedCam] == null) return;

            if (!this.IsHandleCreated) return;

            Action action = () =>
            {
                tsbtn_Cam1.Checked = m_iSelectedCam == 0;
                tsbtn_Cam2.Checked = m_iSelectedCam == 1;
                tsbtn_Cam3.Checked = m_iSelectedCam == 2;
                tsbtn_Cam4.Checked = m_iSelectedCam == 3;

                tsbtn_Grab.Checked = flirCamera[m_iSelectedCam].IsGrabbing();
                tsbtn_Stop.Checked = !flirCamera[m_iSelectedCam].IsGrabbing();

                showCamReticlesToolStripMenuItem.Checked = ShowCamReticles;

                string status = "Live Status ";
                status = status + (flirCamera[0].IsGrabbing() ? "1" : "0");
                status = status + (flirCamera[1].IsGrabbing() ? "1" : "0");
                status = status + (flirCamera[2].IsGrabbing() ? "1" : "0");
                status = status + (flirCamera[3].IsGrabbing() ? "1" : "0");
                tssl_Status.Text = status;

                tsmi_TriggerSource.Text = "Trig: " + (flirCamera[m_iSelectedCam].m_isTrigMode ? (flirCamera[m_iSelectedCam].m_isHardware ? "Hardware" : "Software") : "None");
            };
            Invoke(action);
        }
        private void SelectIndex(int index)
        {
            m_iSelectedCam = index;

            if (flirCamera[m_iSelectedCam] == null) return;

            flirCamera[m_iSelectedCam].imgBoxEmgu = imgBoxEmgu;
            imgBoxEmgu.Image = flirCamera[m_iSelectedCam].m_ImageEmgu.m_Image;
        }
        public void SelectCamera(int index)
        {
            if (flirCamera[m_iSelectedCam] == null) return;

            bool IsGrabbing = flirCamera[m_iSelectedCam].IsGrabbing();
            flirCamera[m_iSelectedCam].GrabStop();
            SelectIndex(index);
            if (m_bZoomFit) ZoomFit();
            if (IsGrabbing) flirCamera[m_iSelectedCam].GrabCont();
            UpdateControls();

            Invalidate();
            Refresh();
        }
        public void Grab()
        {
            if (flirCamera[m_iSelectedCam] == null) return;

            flirCamera[m_iSelectedCam].GrabCont();
            UpdateControls();
        }

        private void frmCamera_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }
        private void frmCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            flirCamera[m_iSelectedCam].GrabStop();
        }

        private void imgBoxEmgu_Paint(object sender, PaintEventArgs e)
        {
            tssl_FPS.Text = flirCamera[m_iSelectedCam].m_dFPS.ToString("f1") + " Hz";

            if (ShowCamReticles)
                for (int i = 0; i < TReticles.MAX_RETICLES; i++)
                    DrawReticles(CamReticles[m_iSelectedCam].Reticle[i], e);

            if (ShowReticles)
                for (int i = 0; i < TReticles.MAX_RETICLES; i++)
                    DrawReticles(Reticles.Reticle[i], e);
        }
        private void imgBoxEmgu_Validated(object sender, EventArgs e)
        {
        }
        private void imgBoxEmgu_Validating(object sender, CancelEventArgs e)
        {
            tssl_FPS.Text = flirCamera[m_iSelectedCam].m_dFPS.ToString("f1");
        }

        private void tsbtn_Cam1_Click(object sender, EventArgs e)
        {
            bool IsGrabbing = flirCamera[m_iSelectedCam].IsGrabbing();
            flirCamera[m_iSelectedCam].GrabStop();
            SelectIndex(0);
            if (m_bZoomFit) ZoomFit();
            if (IsGrabbing) flirCamera[m_iSelectedCam].Grab();
            UpdateControls();
        }
        private void tsbtn_Cam2_Click(object sender, EventArgs e)
        {
            bool IsGrabbing = flirCamera[m_iSelectedCam].IsGrabbing();
            flirCamera[m_iSelectedCam].GrabStop();
            SelectIndex(1);
            if (m_bZoomFit) ZoomFit();
            if (IsGrabbing) flirCamera[m_iSelectedCam].Grab();
            UpdateControls();
        }
        private void tsbtn_Cam3_Click(object sender, EventArgs e)
        {
            bool IsGrabbing = flirCamera[m_iSelectedCam].IsGrabbing();
            flirCamera[m_iSelectedCam].GrabStop();
            SelectIndex(2);
            if (m_bZoomFit) ZoomFit();
            if (IsGrabbing) flirCamera[m_iSelectedCam].GrabCont();
            UpdateControls();
        }
        private void tsbtn_Cam4_Click(object sender, EventArgs e)
        {
            bool IsGrabbing = flirCamera[m_iSelectedCam].IsGrabbing();
            flirCamera[m_iSelectedCam].GrabStop();
            SelectIndex(3);
            if (m_bZoomFit) ZoomFit();
            if (IsGrabbing) flirCamera[m_iSelectedCam].GrabCont();
            UpdateControls();
        }

        private void tsbtn_Capture_Click(object sender, EventArgs e)
        {
            flirCamera[m_iSelectedCam].Snap();
            UpdateControls();
        }
        private void tsbtn_Grab_Click(object sender, EventArgs e)
        {
            flirCamera[m_iSelectedCam].GrabCont();
            UpdateControls();
        }
        private void tsbtn_Stop_Click(object sender, EventArgs e)
        {
            flirCamera[m_iSelectedCam].GrabStop();
            UpdateControls();
        }

        bool m_bZoomFit = false;
        public void ZoomFit()
        {
            if (flirCamera[m_iSelectedCam] == null) return;

            double XScale = (double)pnl_Image.Width / flirCamera[m_iSelectedCam].m_ImageEmgu.m_Image.Width;
            double YScale = (double)pnl_Image.Height / flirCamera[m_iSelectedCam].m_ImageEmgu.m_Image.Height;
            imgBoxEmgu.SetZoomScale(Math.Min(XScale, YScale), new Point(0, 0));
            m_bZoomFit = true;
            UpdateControls();
        }
        public void ZoomActual()
        {
            imgBoxEmgu.SetZoomScale(1, new Point(0, 0));
            m_bZoomFit = false;
            UpdateControls();
        }
        public void ZoomIn()
        {
            imgBoxEmgu.SetZoomScale(imgBoxEmgu.ZoomScale + 0.2, new Point(imgBoxEmgu.Width / 2, imgBoxEmgu.Height / 2));
            m_bZoomFit = false;
            UpdateControls();
        }
        public void ZoomOut()
        {
            imgBoxEmgu.SetZoomScale(imgBoxEmgu.ZoomScale - 0.2, new Point(imgBoxEmgu.Width / 2, imgBoxEmgu.Height / 2));
            m_bZoomFit = false;
            UpdateControls();
        }

        private void tsbtn_ZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }
        private void tsbtn_ZoomFit_Click(object sender, EventArgs e)
        {
            ZoomFit();
        }
        private void tsbtn_ZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void pnl_Image_Resize(object sender, EventArgs e)
        {
            ZoomFit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //string InitDir = @"c:\Program Files\NSWAutomation\Image\";
            openFileDialog1.Filter = "Image Files (*.tif;*.tiff;*.gif;*.bmp;*.jpg;*.jpeg;*.jp2;*.png;)|*.tif;*.tiff;*.gif;*.bmp;*.jpg;*.jpeg;*.jp2;*.png;|All files (*.*)|*.*||";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                flirCamera[m_iSelectedCam].GrabStop();
                ZoomFit();
                UpdateControls();

                Image<Gray, Byte> imageopen = new Image<Gray, byte>(openFileDialog1.FileName);

                Rectangle ocvRectLoad = new Rectangle();
                Rectangle ocvRectImage = new Rectangle();

                ocvRectLoad.X = 0;
                ocvRectLoad.Y = 0;
                ocvRectLoad.Width = imageopen.Width;
                ocvRectLoad.Height = imageopen.Height;

                ocvRectImage.X = 0;
                ocvRectImage.Y = 0;
                ocvRectImage.Width = imgBoxEmgu.Image.GetInputArray().GetSize().Width;
                ocvRectImage.Height = imgBoxEmgu.Image.GetInputArray().GetSize().Height;
                //ocvRectImage.Height = imgBoxEmgu.Image.Size.Height;

                if (imageopen.Width > imgBoxEmgu.Image.GetInputArray().GetSize().Width)
                    ocvRectLoad.Width = imgBoxEmgu.Image.GetInputArray().GetSize().Width;
                else
                if (imageopen.Width < imgBoxEmgu.Image.GetInputArray().GetSize().Width)
                    ocvRectImage.Width = imageopen.Width;

                if (imageopen.Height > imgBoxEmgu.Image.GetInputArray().GetSize().Height)
                    ocvRectLoad.Height = imgBoxEmgu.Image.GetInputArray().GetSize().Height;
                else
                if (imageopen.Height < imgBoxEmgu.Image.GetInputArray().GetSize().Height)
                    ocvRectImage.Height = imageopen.Height;

                imageopen.ROI = ocvRectLoad;

                Image<Gray, Byte> imgRoi = (imgBoxEmgu.Image as Image<Gray, Byte>).GetSubRect(ocvRectImage);

                imageopen.CopyTo(imgRoi);

                imgBoxEmgu.Refresh();
            }

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog1 = new SaveFileDialog();

            string InitDir = @"c:\Program Files\NSWAutomation\Image\";
            if (!Directory.Exists(InitDir)) try { Directory.CreateDirectory(InitDir); } catch { }
            openFileDialog1.InitialDirectory = InitDir;
            openFileDialog1.Filter = "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|BMP (*.bmp)|*.bmp|PNG (*.png)|*.png|All files (*.*)|*.*||";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var tempData = (Image<Gray, byte>)imgBoxEmgu.Image;
                tempData.Save(openFileDialog1.FileName);
                //imgBoxEmgu.Image.Save(openFileDialog1.FileName);
            }
        }

        enum EMouseDn { None, Left, Right };
        EMouseDn mouseDn = EMouseDn.None;
        Point mouseDnPos = new Point(0, 0);
        PointF XYPos = new PointF(0, 0);
        private void imgBoxEmgu_Move(object sender, EventArgs e)
        {

        }
        private void imgBoxEmgu_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.imgBoxEmgu.Image == null) return;

            int offsetX = (int)(e.Location.X / imgBoxEmgu.ZoomScale);
            int offsetY = (int)(e.Location.Y / imgBoxEmgu.ZoomScale);
            int horizontalScrollBarValue = imgBoxEmgu.HorizontalScrollBar.Visible ? (int)imgBoxEmgu.HorizontalScrollBar.Value : 0;
            int verticalScrollBarValue = imgBoxEmgu.VerticalScrollBar.Visible ? (int)imgBoxEmgu.VerticalScrollBar.Value : 0;
            int iX = offsetX + horizontalScrollBarValue;
            int iY = offsetY + verticalScrollBarValue;
            tssl_Pos.Text = "(" + Convert.ToString(iX) + ", " + Convert.ToString(iY) + ")";

            if (this.imgBoxEmgu.Image.GetInputArray().GetChannels() == 1)
            {
                Image<Gray, Byte> img = (imgBoxEmgu.Image as Image<Gray, Byte>);
                if (iX < img.Width - 1 && iY < img.Height - 1)
                {
                    // ** Gray
                    Gray byCurrent = img[iY, iX];
                    tssl_Pos.Text += " G:" + byCurrent.Intensity.ToString();
                }
            }
            else
            if (this.imgBoxEmgu.Image.GetInputArray().GetChannels() == 3)
            {
                Image<Bgr, Byte> img = (imgBoxEmgu.Image as Image<Bgr, Byte>);
                if (iX < img.Width - 1 && iY < img.Height - 1)
                {
                    // ** Color
                    Bgr bgr = img[iY, iX];
                    tssl_Pos.Text += " R:" + bgr.Red.ToString() + " G:" + bgr.Green.ToString() + " B:" + bgr.Blue.ToString();
                }
            }
        }
        private void imgBoxEmgu_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.imgBoxEmgu.Image == null) return;

            if (e.Button == MouseButtons.Left)
            {
                XYPos.X = (float)TaskGantry.GXPos();
                XYPos.Y = (float)TaskGantry.GYPos();
                mouseDnPos = e.Location;
                try
                {
                    CommonControl.SetMotionParam(TaskGantry.GXAxis, 10, TaskGantry.GXAxis.Para.Jog.MedV, 500);
                }
                catch { };
                mouseDn = EMouseDn.Left;
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                //mouseDn = EMouseDn.Right;
                float locX = imgBoxEmgu.HorizontalScrollBar.Value + (float)(e.Location.X / imgBoxEmgu.ZoomScale);
                float locY = imgBoxEmgu.VerticalScrollBar.Value + (float)(e.Location.Y / imgBoxEmgu.ZoomScale);

                int centerX = this.imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2;
                int centerY = this.imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2;

                float ofstX = (float)(locX - centerX);
                float ofstY = (float)(locY - centerY);

                float ofstX_L = ofstX * (float)TaskVision.DistPerPixelX[0];
                float ofstY_L = -ofstY * (float)TaskVision.DistPerPixelY[0];
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                {
                    ofstY_L = -ofstY_L;
                }

                try
                {
                    if (TaskGantry.IsBusyGXY()) return;
                    CommonControl.SetMotionParam(TaskGantry.GXAxis, 1, TaskGantry.GXAxis.Para.Jog.MedV, 100);
                    CommonControl.SetMotionParam(TaskGantry.GYAxis, 1, TaskGantry.GYAxis.Para.Jog.MedV, 100);
                    CommonControl.MoveLineRel2(TaskGantry.GXAxis, TaskGantry.GYAxis, ofstX_L, ofstY_L);
                }
                catch { };
            }
        }
        private void imgBoxEmgu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDn = EMouseDn.None;
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsmi_ShowStatusBar.Checked = !tsmi_ShowStatusBar.Checked;
            ss_Bottom.Visible = tsmi_ShowStatusBar.Checked;
        }
        private void setupReticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ReticleSetup2 frm = new frm_ReticleSetup2();

            frm.ImageW = imgBoxEmgu.Image.GetInputArray().GetSize().Width;
            frm.ImageH = imgBoxEmgu.Image.GetInputArray().GetSize().Height;
            frm.Reticles = CamReticles[m_iSelectedCam];
            frm.TopMost = true;

            frm.Show();
            frm.BringToFront();

            imgBoxEmgu.Refresh();
        }

        private void DrawReticles(TReticle2 Reticle, PaintEventArgs e)
        {
            if (Reticle.Size.Width <= 0) Reticle.Size.Width = 50;
            if (Reticle.Size.Height <= 0) Reticle.Size.Height = 50;

            Pen pen = new Pen(Reticle.Color);
            switch (Reticle.Type)
            {
                case TReticle2.EType.None: break;
                case TReticle2.EType.Line:
                    {
                        PointF Start = Reticle.Location;
                        PointF End = new PointF(Reticle.Location.X + Reticle.Size.Width, Reticle.Location.Y + Reticle.Size.Height);
                        e.Graphics.DrawLine(pen, Start, End);
                        break;
                    }
                case TReticle2.EType.Rectangle:
                    {
                        RectangleF Rect = new RectangleF(Reticle.Location, Reticle.Size);
                        e.Graphics.DrawRectangle(pen, Rect.X, Rect.Y, Rect.Width, Rect.Height);
                        break;
                    }
                case TReticle2.EType.Circle:
                    {
                        RectangleF Rect = new RectangleF(Reticle.Location, Reticle.Size);
                        e.Graphics.DrawArc(pen, Rect.X, Rect.Y, Rect.Width, Rect.Height, 0, 360);
                        break;
                    }
                case TReticle2.EType.Cross:
                    {
                        PointF S1 = new PointF(Reticle.Location.X, Reticle.Location.Y - Reticle.Size.Height / 2);
                        PointF E1 = new PointF(Reticle.Location.X, Reticle.Location.Y + Reticle.Size.Height / 2);
                        PointF S2 = new PointF(Reticle.Location.X - Reticle.Size.Width / 2, Reticle.Location.Y);
                        PointF E2 = new PointF(Reticle.Location.X + Reticle.Size.Width / 2, Reticle.Location.Y);
                        e.Graphics.DrawLine(pen, S1, E1);
                        e.Graphics.DrawLine(pen, S2, E2);
                        break;
                    }
                case TReticle2.EType.CenterCross:
                    {
                        RectangleF Rect = new RectangleF(Reticle.Location, Reticle.Size);
                        e.Graphics.DrawLine(pen, new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, 0), new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, imgBoxEmgu.Image.GetInputArray().GetSize().Height));
                        e.Graphics.DrawLine(pen, new Point(0, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2), new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2));
                        break;
                    }
                case TReticle2.EType.CenterCross3:
                    {
                        RectangleF Rect = new RectangleF(Reticle.Location, Reticle.Size);
                        float w = imgBoxEmgu.Image.GetInputArray().GetSize().Width / 5;
                        float h = imgBoxEmgu.Image.GetInputArray().GetSize().Height / 5;
                        pen.DashPattern = new float[2] { h, h };
                        e.Graphics.DrawLine(pen, new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, 0), new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, imgBoxEmgu.Image.GetInputArray().GetSize().Height));
                        pen.DashPattern = new float[2] { w, w };
                        e.Graphics.DrawLine(pen, new Point(0, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2), new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2));
                        break;
                    }
                case TReticle2.EType.CenterCross50u:
                    {
                        RectangleF Rect = new RectangleF(Reticle.Location, Reticle.Size);
                        e.Graphics.DrawLine(pen, new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, 0), new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, imgBoxEmgu.Image.GetInputArray().GetSize().Height));
                        e.Graphics.DrawLine(pen, new Point(0, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2), new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2));

                        Point ptCenter = new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2);
                        PointF pix050 = new PointF((float)(0.05 / TaskVision.DistPerPixelX[0]), (float)(0.05 / TaskVision.DistPerPixelY[0]));

                        int xLines = (int)(imgBoxEmgu.Image.GetInputArray().GetSize().Width / pix050.X);
                        int yLines = (int)(imgBoxEmgu.Image.GetInputArray().GetSize().Height / pix050.Y);

                        for (int x = 0; x < xLines / 2; x++)
                        {
                            int tickLen = 4;
                            if (x % 2 == 0) tickLen = 8;
                            if (x % 20 == 0) tickLen = 20;
                            e.Graphics.DrawLine(pen, ptCenter.X + (pix050.X * x), ptCenter.Y - tickLen, ptCenter.X + (pix050.X * x), ptCenter.Y + tickLen);
                            e.Graphics.DrawLine(pen, ptCenter.X - (pix050.X * x), ptCenter.Y - tickLen, ptCenter.X - (pix050.X * x), ptCenter.Y + tickLen);
                        }
                        for (int y = 0; y < yLines / 2; y++)
                        {
                            int tickLen = 4;
                            if (y % 2 == 0) tickLen = 8;
                            if (y % 20 == 0) tickLen = 15;
                            e.Graphics.DrawLine(pen, ptCenter.X - tickLen, ptCenter.Y + (pix050.Y * y), ptCenter.X + tickLen, ptCenter.Y + (pix050.Y * y));
                            e.Graphics.DrawLine(pen, ptCenter.X - tickLen, ptCenter.Y - (pix050.Y * y), ptCenter.X + tickLen, ptCenter.Y - (pix050.Y * y));
                        }

                        //PointF Start = Reticle.Location;
                        float fSize = 25;
                        Font font = new Font(FontFamily.GenericSerif, fSize, GraphicsUnit.Pixel);
                        e.Graphics.DrawString("mm", font, new SolidBrush(Reticle.Color), new Point(0, ptCenter.Y + 20));

                        break;
                    }
                case TReticle2.EType.CenterCross100u:
                    {
                        RectangleF Rect = new RectangleF(Reticle.Location, Reticle.Size);
                        e.Graphics.DrawLine(pen, new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, 0), new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, imgBoxEmgu.Image.GetInputArray().GetSize().Height));
                        e.Graphics.DrawLine(pen, new Point(0, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2), new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2));

                        Point ptCenter = new Point(imgBoxEmgu.Image.GetInputArray().GetSize().Width / 2, imgBoxEmgu.Image.GetInputArray().GetSize().Height / 2);
                        PointF pix100 = new PointF((float)(0.1 / TaskVision.DistPerPixelX[0]), (float)(0.1 / TaskVision.DistPerPixelY[0]));

                        int xLines = (int)(imgBoxEmgu.Image.GetInputArray().GetSize().Width / pix100.X);
                        int yLines = (int)(imgBoxEmgu.Image.GetInputArray().GetSize().Height / pix100.Y);

                        for (int x = 0; x < xLines/2; x++)
                        {
                            int tickLen = 5;
                            if (x % 10 == 0) tickLen = 15;
                            e.Graphics.DrawLine(pen, ptCenter.X + (pix100.X * x), ptCenter.Y - tickLen, ptCenter.X + (pix100.X * x), ptCenter.Y + tickLen);
                            e.Graphics.DrawLine(pen, ptCenter.X - (pix100.X * x), ptCenter.Y - tickLen, ptCenter.X - (pix100.X * x), ptCenter.Y + tickLen);
                        }
                        for (int y = 0; y < yLines / 2; y++)
                        {
                            int tickLen = 5;
                            if (y  % 10 == 0) tickLen = 15;
                            e.Graphics.DrawLine(pen, ptCenter.X - tickLen, ptCenter.Y + (pix100.Y * y), ptCenter.X + tickLen, ptCenter.Y + (pix100.Y * y));
                            e.Graphics.DrawLine(pen, ptCenter.X - tickLen, ptCenter.Y - (pix100.Y * y), ptCenter.X + tickLen, ptCenter.Y - (pix100.Y * y));
                        }

                        float fSize = 25;
                        Font font = new Font(FontFamily.GenericSerif, fSize, GraphicsUnit.Pixel);
                        e.Graphics.DrawString("mm", font, new SolidBrush(Reticle.Color), new Point(0, ptCenter.Y + 20));

                        break;
                    }
                case TReticle2.EType.Text:
                    {
                        PointF Start = Reticle.Location;
                        float fSize = Reticle.Size.Height;// 20.0f;
                        Font font = new Font(FontFamily.GenericSerif, fSize, GraphicsUnit.Pixel);
                        e.Graphics.DrawString(Reticle.Text, font, new SolidBrush(Reticle.Color), Start);
                        break;
                    }
            }
        }

        private void showCamReticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCamReticles = !ShowCamReticles;
            imgBoxEmgu.Refresh();

            UpdateControls();
        }

        private void tsmiTriggerNone_Click(object sender, EventArgs e)
        {
            flirCamera[m_iSelectedCam].TriggerMode = false;
            UpdateControls();
        }
        private void tsmiSoftwareTrigger_Click(object sender, EventArgs e)
        {
            flirCamera[m_iSelectedCam].TriggerSourceSw = true;
            flirCamera[m_iSelectedCam].TriggerMode = true;

            UpdateControls();
        }
        private void tsmiHardwareTrigger_Click(object sender, EventArgs e)
        {
            flirCamera[m_iSelectedCam].TriggerSourceHw = true;
            flirCamera[m_iSelectedCam].TriggerMode = true;

            UpdateControls();
        }
        private void GrabSaveImage()
        {
            TaskVision.flirCamera2[m_iSelectedCam].m_ImageEmgu.m_Image.Save(@"c:\Test_" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ".jpg");
        }
        Task taskGrab = null;
        private void tsmiTrigger_Click(object sender, EventArgs e)
        {
            flirCamera[m_iSelectedCam].SoftwareTrigger();

            taskGrab = new Task(new Action(GrabSaveImage));
            taskGrab.Start();
            Task.WaitAll(taskGrab);
        }
    }
}
