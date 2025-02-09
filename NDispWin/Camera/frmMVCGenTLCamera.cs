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
using System.Threading;

using Emgu.CV;
using Emgu.CV.Structure;

namespace NDispWin
{
    public partial class frmMVCGenTLCamera : Form
    {
        const int MAX_CAMERA = 3;
        int m_iSelectedCam = 0;

        //  camera reticles
        public TReticles[] CamReticles = new TReticles[MAX_CAMERA];
        public bool ShowCamReticles = false;

        //  temp reticles
        public bool ShowReticles = false;
        public TReticles Reticles = new TReticles();

        public frmMVCGenTLCamera(TReticles reticles, bool show)
        {
            InitializeComponent();
            GControl.LogForm(this);

            pnl_Image.Dock = DockStyle.Fill;
            imgBoxEmgu.Dock = DockStyle.Fill;
            imgBoxEmgu2.Dock = DockStyle.Fill;

            Reticles = new TReticles(reticles);
            ShowReticles = true;
        }
        public frmMVCGenTLCamera() : this(new TReticles(), false)
        {
        }

        private void UpdateControls()
        {
            if (TaskVision.genTLCamera[m_iSelectedCam] == null) return;

            if (!this.IsHandleCreated) return;

            Action action = () =>
            {
                tsbtnCam1.Checked = m_iSelectedCam == 0;
                tsbtnCam2.Checked = m_iSelectedCam == 1;
                tsbtnCam3.Checked = m_iSelectedCam == 2;
                tsbtnCam1.Enabled = TaskVision.genTLCamera[0].IsConnected;
                tsbtnCam2.Enabled = TaskVision.genTLCamera[1].IsConnected;
                tsbtnCam3.Enabled = TaskVision.genTLCamera[2].IsConnected;

                tsbtn_Grab.Checked = TaskVision.genTLCamera[m_iSelectedCam].IsGrabbing;
                tsbtn_Stop.Checked = !TaskVision.genTLCamera[m_iSelectedCam].IsGrabbing;

                showCamReticlesToolStripMenuItem.Checked = ShowCamReticles;

                string status = "Live Status ";
                status = status + (TaskVision.genTLCamera[0].IsGrabbing ? "1" : "0");
                status = status + (TaskVision.genTLCamera[1].IsGrabbing ? "1" : "0");
                status = status + (TaskVision.genTLCamera[2].IsGrabbing ? "1" : "0");
                tssl_Status.Text = status;

                triggerModeToolStripMenuItem.Text = "TrigMode: " + (TaskVision.genTLCamera[m_iSelectedCam].TriggerMode ? "On" : " Off");
                tsmiTriggerSource.Text = "TrigSource: " + (TaskVision.genTLCamera[m_iSelectedCam].TriggerSourceHw ? "Hardware" : "Software");
            };
            Invoke(action);
        }
        public void SelectCamera(int index)
        {
            if (TaskVision.genTLCamera[index] == null) return;

            for (int i = 0; i < 3; i++)
            {
                if (TaskVision.genTLCamera[i] != null) TaskVision.genTLCamera[i].StopGrab();
            }

            TaskVision.genTLCamera[0].RegisterPictureBox(imgBoxEmgu);
            TaskVision.genTLCamera[1].RegisterPictureBox(imgBoxEmgu2);

            m_iSelectedCam = index;
            switch (m_iSelectedCam)
            {
                default:
                case 0: imgBoxEmgu.BringToFront(); break;
                case 1: imgBoxEmgu2.BringToFront(); break;
            }

            TaskVision.genTLCamera[m_iSelectedCam].StartGrab();

            Task.Run(() =>
            {//suspect due to object lock execution is aborted by object
                Thread.Sleep(250);
                ZoomFit();
            });

            UpdateControls();
        }

        private void frmCamera_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }
        private void frmCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (TaskVision.genTLCamera[i] != null) TaskVision.genTLCamera[i].StopGrab();
            }
        }
        private void frmMVCGenTLCamera_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void frmMVCGenTLCamera_Shown(object sender, EventArgs e)
        {
        }

        private void tsbtn_Cam1_Click(object sender, EventArgs e)
        {
            SelectCamera(0);
        }
        private void tsbtn_Cam2_Click(object sender, EventArgs e)
        {
            SelectCamera(1);
        }
        private void tsbtn_Cam3_Click(object sender, EventArgs e)
        {
            SelectCamera(2);
        }

        private void tsbtn_Capture_Click(object sender, EventArgs e)
        {
            TaskVision.genTLCamera[m_iSelectedCam].GrabOneImage();
            UpdateControls();
        }
        private void tsbtn_Grab_Click(object sender, EventArgs e)
        {
            TaskVision.genTLCamera[m_iSelectedCam].StartGrab();
            UpdateControls();
        }
        private void tsbtn_Stop_Click(object sender, EventArgs e)
        {
            TaskVision.genTLCamera[m_iSelectedCam].StopGrab();
            UpdateControls();
        }

        public Emgu.CV.UI.ImageBox imgBox
        {
            get
            {
                switch (m_iSelectedCam)
                {
                    default:
                    case 0: return imgBoxEmgu;
                    case 1: return imgBoxEmgu2;
                }
            }
        }

        public void ZoomFit()
        {
            if (!TaskVision.genTLCamera[m_iSelectedCam].IsConnected) return;

            double XScale = (double)pnl_Image.Width / TaskVision.genTLCamera[m_iSelectedCam].ImageWidth;
            double YScale = (double)pnl_Image.Height / TaskVision.genTLCamera[m_iSelectedCam].ImageHeight;
_Retry:
            try
            {
                imgBox.SetZoomScale(Math.Min(XScale, YScale), new Point(0, 0));
            }
            catch
            {
                goto _Retry;
            }
            finally
            {
            }
            UpdateControls();
        }
        public void ZoomActual()
        {
            imgBox.SetZoomScale(1, new Point(0, 0));
            UpdateControls();
        }
        public void ZoomIn()
        {
            imgBox.SetZoomScale(imgBox.ZoomScale + 0.2, new Point(imgBox.Width / 2, imgBox.Height / 2));
            UpdateControls();
        }
        public void ZoomOut()
        {
            imgBox.SetZoomScale(imgBox.ZoomScale - 0.2, new Point(imgBox.Width / 2, imgBox.Height / 2));
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.tif;*.tiff;*.gif;*.bmp;*.jpg;*.jpeg;*.jp2;*.png;)|*.tif;*.tiff;*.gif;*.bmp;*.jpg;*.jpeg;*.jp2;*.png;|All files (*.*)|*.*||";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TaskVision.genTLCamera[m_iSelectedCam].StopGrab();
                ZoomFit();
                UpdateControls();

                Image<Gray, Byte> imageopen = new Image<Gray, byte>(ofd.FileName);

                imgBox.Image = imageopen.Clone();
                imgBox.Refresh();
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
                TaskVision.genTLCamera[m_iSelectedCam].mImage.Save(openFileDialog1.FileName);
            }
        }


        private void imgBoxEmgu_Paint(object sender, PaintEventArgs e)
        {
            if (ShowCamReticles)
                for (int i = 0; i < TReticles.MAX_RETICLES; i++)
                    DrawReticles(CamReticles[m_iSelectedCam].Reticle[i], e);

            if (ShowReticles)
                for (int i = 0; i < TReticles.MAX_RETICLES; i++)
                    DrawReticles(Reticles.Reticle[i], e);
        }
        Point mouseDnPos = new Point(0, 0);
        PointF XYPos = new PointF(0, 0);
        private void imgBoxEmgu_MouseMove(object sender, MouseEventArgs e)
        {
            if (!TaskVision.genTLCamera[m_iSelectedCam].IsGrabbing) return;

            int offsetX = (int)(e.Location.X / (sender as Emgu.CV.UI.ImageBox).ZoomScale);
            int offsetY = (int)(e.Location.Y / (sender as Emgu.CV.UI.ImageBox).ZoomScale);
            int horizontalScrollBarValue = (sender as Emgu.CV.UI.ImageBox).HorizontalScrollBar.Visible ? (int)(sender as Emgu.CV.UI.ImageBox).HorizontalScrollBar.Value : 0;
            int verticalScrollBarValue = (sender as Emgu.CV.UI.ImageBox).VerticalScrollBar.Visible ? (int)(sender as Emgu.CV.UI.ImageBox).VerticalScrollBar.Value : 0;
            int iX = offsetX + horizontalScrollBarValue;
            int iY = offsetY + verticalScrollBarValue;
            tssl_Pos.Text = "(" + Convert.ToString(iX) + ", " + Convert.ToString(iY) + ")";
        }
        private void imgBoxEmgu_MouseDown(object sender, MouseEventArgs e)
        {
            if (!TaskVision.genTLCamera[m_iSelectedCam].IsGrabbing) return;

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
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                float locX = (sender as Emgu.CV.UI.ImageBox).HorizontalScrollBar.Value + (float)(e.Location.X / (sender as Emgu.CV.UI.ImageBox).ZoomScale);
                float locY = (sender as Emgu.CV.UI.ImageBox).VerticalScrollBar.Value + (float)(e.Location.Y / (sender as Emgu.CV.UI.ImageBox).ZoomScale);

                int centerX = (int)TaskVision.genTLCamera[m_iSelectedCam].ImageWidthMax /2;
                int centerY = (int)TaskVision.genTLCamera[m_iSelectedCam].ImageHeightMax / 2;

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
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsmi_ShowStatusBar.Checked = !tsmi_ShowStatusBar.Checked;
            ss_Bottom.Visible = tsmi_ShowStatusBar.Checked;
        }
        private void setupReticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ReticleSetup2 frm = new frm_ReticleSetup2();

            frm.ImageW = (int)TaskVision.genTLCamera[m_iSelectedCam].ImageWidth;// imgBoxEmgu.Image.Size.Width;
            frm.ImageH = (int)TaskVision.genTLCamera[m_iSelectedCam].ImageHeight;//imgBoxEmgu.Image.Size.Height;
            frm.Reticles = CamReticles[m_iSelectedCam];
            frm.TopMost = true;

            frm.Show();
            frm.BringToFront();
        }

        private void DrawReticles(TReticle2 Reticle, PaintEventArgs e)
        {
            if (Reticle.Size.Width <= 0) Reticle.Size.Width = 50;
            if (Reticle.Size.Height <= 0) Reticle.Size.Height = 50;

            int width = (int)TaskVision.genTLCamera[m_iSelectedCam].ImageWidth;
            int height = (int)TaskVision.genTLCamera[m_iSelectedCam].ImageHeight;

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
                        e.Graphics.DrawLine(pen, new Point(width / 2, 0), new Point(width / 2, height));
                        e.Graphics.DrawLine(pen, new Point(0, height / 2), new Point(width, height / 2));
                        break;
                    }
                case TReticle2.EType.CenterCross3:
                    {
                        RectangleF Rect = new RectangleF(Reticle.Location, Reticle.Size);
                        float w = width / 5;
                        float h = height / 5;
                        pen.DashPattern = new float[2] { h, h };
                        e.Graphics.DrawLine(pen, new Point(width / 2, 0), new Point(width / 2, height));
                        pen.DashPattern = new float[2] { w, w };
                        e.Graphics.DrawLine(pen, new Point(0, height / 2), new Point(width, height / 2));
                        break;
                    }
                case TReticle2.EType.CenterCross50u:
                    {
                        RectangleF Rect = new RectangleF(Reticle.Location, Reticle.Size);
                        e.Graphics.DrawLine(pen, new Point(width / 2, 0), new Point(width / 2, height));
                        e.Graphics.DrawLine(pen, new Point(0, height / 2), new Point(width, height / 2));

                        Point ptCenter = new Point(width / 2, height / 2);
                        PointF pix050 = new PointF((float)(0.05 / TaskVision.DistPerPixelX[0]), (float)(0.05 / TaskVision.DistPerPixelY[0]));

                        int xLines = (int)(width / pix050.X);
                        int yLines = (int)(height / pix050.Y);

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
                        e.Graphics.DrawLine(pen, new Point(width / 2, 0), new Point(width / 2, height));
                        e.Graphics.DrawLine(pen, new Point(0, height / 2), new Point(width, height / 2));

                        Point ptCenter = new Point(width / 2, height / 2);
                        PointF pix100 = new PointF((float)(0.1 / TaskVision.DistPerPixelX[0]), (float)(0.1 / TaskVision.DistPerPixelY[0]));

                        int xLines = (int)(width / pix100.X);
                        int yLines = (int)(height / pix100.Y);

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
            UpdateControls();
        }

        private void tsmiTriggerModeOff_Click(object sender, EventArgs e)
        {
            TaskVision.genTLCamera[m_iSelectedCam].TriggerMode = false;
            UpdateControls();
        }
        private void tsmiTriggerModeOn_Click(object sender, EventArgs e)
        {
            TaskVision.genTLCamera[m_iSelectedCam].TriggerMode = true;
            UpdateControls();
        }
        private void tsmiTriggerSourceSoftware_Click(object sender, EventArgs e)
        {
            TaskVision.genTLCamera[m_iSelectedCam].TriggerSourceHw = false;
            TaskVision.genTLCamera[m_iSelectedCam].TriggerMode = true;

            UpdateControls();
        }
        private void tsmiTriggerSourceHardware_Click(object sender, EventArgs e)
        {
            TaskVision.genTLCamera[m_iSelectedCam].TriggerSourceHw = true;
            TaskVision.genTLCamera[m_iSelectedCam].TriggerMode = true;

            UpdateControls();
        }
        private void tsmiTrigger_Click(object sender, EventArgs e)
        {
            TaskVision.genTLCamera[m_iSelectedCam].SoftwareTrigger();
        }

        private void rsbShowCamReticle_Click(object sender, EventArgs e)
        {
            ShowCamReticles = !ShowCamReticles;
            UpdateControls();
        }
    }
}
