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
using Emgu.CV.Structure;

namespace NDispWin
{
    internal partial class frmVisionView : Form
    {
        public ECamNo SelectedCam = ECamNo.Cam00;
        frm_DispCore_Lighting frm_Lighting = new frm_DispCore_Lighting();
        Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> ImageG = null;

        public frmVisionView()
        {
            InitializeComponent();

            this.Text = "Vision View";

            frm_Lighting.StartPosition = FormStartPosition.Manual;
            frm_Lighting.TopMost = true;
        }

        private void UpdateDisplay()
        {
            string s = "";
            Point ptMouse = pbox_Image.PointToClient(Control.MousePosition);
            if ((ptMouse.X < 0) || (ptMouse.Y < 0) || (ptMouse.X > pbox_Image.Width) || (ptMouse.Y > pbox_Image.Height))
                s = "(X=-, Y=-)";
            else
                s = "(X=" + ptMouse.X.ToString() + ", Y=" + ptMouse.Y.ToString() + ")";
            lbl_Pos.Text = s;

            string S = "LED ";
            S = S + "[";
            S = S + TaskVision.CurrentLightRGBA.R.ToString() + ", ";
            S = S + TaskVision.CurrentLightRGBA.G.ToString() + ", ";
            S = S + TaskVision.CurrentLightRGBA.B.ToString() + ", ";
            S = S + TaskVision.CurrentLightRGBA.A.ToString() + "]";
            btn_LightingAdjust.Text = S;

            if (SelectedCam != TaskVision.SelectedCam)
            {
                SelectedCam = TaskVision.SelectedCam;

                if (SelectedCam == ECamNo.Cam00)
                {
                    btn_Cam1.BackColor = Color.Navy;
                    btn_Cam1.ForeColor = this.BackColor;
                }
                else
                {
                    btn_Cam1.BackColor = this.BackColor;
                    btn_Cam1.ForeColor = Color.Navy;
                }
                if (SelectedCam == ECamNo.Cam01)
                {
                    btn_Cam2.BackColor = Color.Navy;
                    btn_Cam2.ForeColor = this.BackColor;
                }
                else
                {
                    btn_Cam2.BackColor = this.BackColor;
                    btn_Cam2.ForeColor = Color.Navy;
                }
                if (SelectedCam == ECamNo.Cam02)
                {
                    btn_Cam3.BackColor = Color.Navy;
                    btn_Cam3.ForeColor = this.BackColor;
                }
                else
                {
                    btn_Cam3.BackColor = this.BackColor;
                    btn_Cam3.ForeColor = Color.Navy;
                }
            }
        }

        private void frmVisionView_Load(object sender, EventArgs e)
        {
            UpdateMenuVisible(1);

            UpdateDisplay();

            if (GDefine.CameraType[0] == GDefine.ECameraType.Basler) StartGrab();

            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
            {
                try
                {
                    //TaskVision.PtGrey_CamLive((int)SelectedCam);
                }
                catch { };

                TaskVision.fe.GrabbedEvent += new TaskVision.OnGrabbedEventHandler(GrabbedEvent);
            }

            //if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker) StartGrab();

            TaskVision.CameraRun = true;
        }
        private void frmVisionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.Basler) StopGrab();

            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
            {
                //TaskVision.PtGrey_CamStop();
                //TaskVision.fe.GrabbedEvent -= new TaskVision.OnGrabbedEventHandler(GrabbedEvent);
            }
            frm_Lighting.Visible = false;
        }

        private void frmVisionView_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        #region Basler
        BackgroundWorker bgwGrab = new BackgroundWorker();
        private void StartGrab()
        {
            if (bgwGrab != null)
            {
                if (bgwGrab.IsBusy == false)
                {
                    bgwGrab.DoWork += new DoWorkEventHandler(bgwGrab_DoWork);
                    bgwGrab.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwGrab_RunWorkerCompleted);
                    bgwGrab.WorkerReportsProgress = true;
                    bgwGrab.ProgressChanged += new ProgressChangedEventHandler(bgwGrab_ProgressChanged);
                    bgwGrab.WorkerSupportsCancellation = true;
                    bgwGrab.RunWorkerAsync();
                }
            }
        }
        private void StopGrab()
        {
            bgwGrab.CancelAsync();
            GC.Collect();
        }

        void bgwGrab_DoWork(object sender, DoWorkEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.None) return;

            Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> ImageC = null;
            while (true)
            {
                if (bgwGrab.CancellationPending) break;

                if (TaskVision.CameraRun && Visible)
                {
                    TaskVision.GrabN((int)TaskVision.SelectedCam, ref ImageG);
                    ImageC = ImageG.Convert<Emgu.CV.Structure.Bgr, byte>();

                    TaskVision.ImageDrawReticle(ImageG, ImageC);

                    try
                    {
                        pbox_Image.Image = ImageC.ToBitmap();
                    }
                    catch { };
                    Thread.Sleep(30);
                    //Thread.Sleep(3);
                }

                if (!TaskVision.CameraRun)
                {
                    Thread.Sleep(5);
                }
            }
            if (ImageC != null) ImageC.Dispose();
        }
        void bgwGrab_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        void bgwGrab_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        #endregion

        private void GrabbedEvent(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (!TaskVision.CameraRun) return;

            //if (!TaskVision.PGCamera[(int)SelectedCam].IsConnected) return;

            //{
            //    using (Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> ImageG = TaskVision.PGCamera[(int)SelectedCam].Image().ToImage<Gray, byte>())//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(TaskVision.PGCamera[(int)SelectedCam].Image()))
            //    {
            //        try
            //        {
            //            if (ImageG == null) return;

            //            using (Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> ImageC = ImageG.Convert<Emgu.CV.Structure.Bgr, byte>())
            //            {
            //                TaskVision.ImageDrawReticle(ImageG, ImageC);
            //                pbox_Image.Image = ImageC.ToBitmap();
            //                pbox_Image.Invalidate();
            //            }
            //        }
            //        catch (Exception Ex)
            //        {
            //            Log.AddToLog("frm_VisionView.GrabbedEvent, " + Ex.Message.ToString() + ".");
            //            GC.Collect();
            //        }
            //    }
            //    Thread.Sleep(5);
            //}
        }

        Point pt_MouseDn = new Point();
        Point pt = new Point();
        NSW.Net.Point2D pt2D_XYOrg = new NSW.Net.Point2D(0, 0);
        Point pt_DragOrg = new Point();

        enum EMouseMode {None, Move, Drag};
        EMouseMode MouseMode = EMouseMode.None;

        private void pbox_Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                #region Drag Mode
                MouseMode = EMouseMode.Drag;

                Cursor.Current = Cursors.Hand;
                pt_MouseDn = pbox_Image.PointToClient(Control.MousePosition);
                pt_DragOrg = pt_MouseDn;

                pt2D_XYOrg.X = TaskGantry.GXPos();
                pt2D_XYOrg.Y = TaskGantry.GYPos();

                double sv = TaskGantry.GXAxis.Para.StartV;
                double dv = TaskGantry.GXAxis.Para.FastV;
                double ac = TaskGantry.GXAxis.Para.Accel;

                TaskGantry.SetMotionParamGXY(sv, dv, ac);
                #endregion
            }
            if (e.Button == MouseButtons.Right)
            {
                #region Move Mode
                MouseMode = EMouseMode.Move;

                Point ptMouse = pbox_Image.PointToClient(Control.MousePosition);

                double MagX = (double)pbox_Image.Width / TaskVision.ImgWN[(int)TaskVision.SelectedCam];
                double MagY = (double)pbox_Image.Height / TaskVision.ImgHN[(int)TaskVision.SelectedCam];

                int x0 = pbox_Image.Width / 2;
                int y0 = pbox_Image.Height / 2;

                int xm = ptMouse.X - x0;
                int ym = ptMouse.Y - y0;
                ym = -ym;

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                    ym = -ym;

                double X = TaskGantry.GXPos();
                double Y = TaskGantry.GYPos();

                double mX = X + (xm * TaskVision.DistPerPixelX[(int)TaskVision.SelectedCam] / MagX);
                double mY = Y + (ym * TaskVision.DistPerPixelY[(int)TaskVision.SelectedCam] / MagY);

                double sv = TaskGantry.GXAxis.Para.StartV;
                double dv = TaskGantry.GXAxis.Para.SlowV;
                double ac = TaskGantry.GXAxis.Para.Accel;

                if (!TaskGantry.SetMotionParamGXY(sv, dv, ac)) return;
                if (!TaskGantry.MoveAbsGXY(mX, mY)) return;
                #endregion
            }
        }
        private void pbox_Image_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                #region Drag Mode
                MouseMode = EMouseMode.Drag;
                Cursor.Current = Cursors.Default;
                #endregion
            }
            if (e.Button == MouseButtons.Right)
            {
                MouseMode = EMouseMode.None;
            }
        }
        bool Busy = false;
        private void pbox_Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                #region Drag Mode
                if (MouseMode != EMouseMode.Drag) return;

                if (Busy) return;

                Busy = true;
                pt = pbox_Image.PointToClient(Control.MousePosition);

                if (pt.X <= 0 || pt.X >= pbox_Image.Width - 1 ||
                    pt.Y <= 0 || pt.Y >= pbox_Image.Height - 1)
                {
                    goto _ExitMode;
                }

                Point pix_Dist = new Point();
                pix_Dist.X = pt.X - pt_DragOrg.X;
                pix_Dist.Y = pt.Y - pt_DragOrg.Y;
                pix_Dist.X = -pix_Dist.X;

                double MagX = (double)pbox_Image.Width / TaskVision.ImgWN[(int)TaskVision.SelectedCam];
                double MagY = (double)pbox_Image.Height / TaskVision.ImgHN[(int)TaskVision.SelectedCam];

                NSW.Net.Point2D Dist = new NSW.Net.Point2D(0, 0);
                Dist.X = pix_Dist.X * TaskVision.DistPerPixelX[(int)TaskVision.SelectedCam] / MagX;
                Dist.Y = pix_Dist.Y * TaskVision.DistPerPixelY[(int)TaskVision.SelectedCam] / MagY;
                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                    Dist.Y = -Dist.Y;

                double mX = pt2D_XYOrg.X + Dist.X;
                double mY = pt2D_XYOrg.Y + Dist.Y;

                try
                {
                    if (!TaskGantry.MoveAbsGXYNoError(mX, mY, true)) goto _ExitMode;
                    if (TaskGantry.MotorAlarm(TaskGantry.GXAxis, ref TaskGantry._GXAlm, false)) goto _ExitMode;
                    if (TaskGantry.MotorAlarm(TaskGantry.GYAxis, ref TaskGantry._GYAlm, false)) goto _ExitMode;
                }
                catch
                { goto _ExitMode; }

                Application.DoEvents();
                Busy = false;
                return;
            _ExitMode:
                Busy = false;
                //b_DragMode = false;
                MouseMode = EMouseMode.None;
                Cursor.Current = Cursors.Default;
                #endregion
            }
            if (e.Button == MouseButtons.Right)
            {
                #region Scroll Mode
            //    if (MouseMode != EMouseMode.Scroll) return;
            //    //if (!b_ScrollMode) return;

            //    if (Busy) return;

            //    Busy = true;
            //    pt = Cursor.Position;

            //    if (pt.X <= 0)
            //    {
            //        pt_ScrollOrg.X = pt_ScrollOrg.X + Screen.PrimaryScreen.Bounds.Width - 1;
            //        pt.X = pt.X + Screen.PrimaryScreen.Bounds.Width - 1;
            //    }
            //    else
            //        if (pt.X >= Screen.PrimaryScreen.Bounds.Width - 1)
            //        {
            //            pt_ScrollOrg.X = pt_ScrollOrg.X - Screen.PrimaryScreen.Bounds.Width - 1;
            //            pt.X = pt.X - Screen.PrimaryScreen.Bounds.Width - 1;
            //        }

            //    if (pt.Y <= 0)
            //    {
            //        pt_ScrollOrg.Y = pt_ScrollOrg.Y + Screen.PrimaryScreen.Bounds.Height - 1;
            //        pt.Y = pt.Y + Screen.PrimaryScreen.Bounds.Height - 1;
            //    }
            //    else
            //        if (pt.Y >= Screen.PrimaryScreen.Bounds.Height - 1)
            //        {
            //            pt_ScrollOrg.Y = pt_ScrollOrg.Y - Screen.PrimaryScreen.Bounds.Height - 1;
            //            pt.Y = pt.Y - Screen.PrimaryScreen.Bounds.Height - 1;
            //        }

            //    Cursor.Position = new Point(pt.X, pt.Y);
                
            //    {
            //        double DistX = (double)(pt.X - pt_ScrollOrg.X);
            //        double DistY = (double)(pt.Y - pt_ScrollOrg.Y);
            //        DistY = -DistY;

            //        DistX = DistX / 1000;
            //        DistY = DistY / 1000;
            //        if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
            //            DistY = -DistY;

            //        double mX = pt2D_XYOrg.X + DistX;
            //        double mY = pt2D_XYOrg.Y + DistY;

            //        try
            //        {
            //            if (!TaskGantry.MoveAbsGXYNoError(mX, mY, true)) goto _Error;
            //            if (TaskGantry.MotorAlarm(TaskGantry.GXAxis, ref TaskGantry._GXAlm, false)) goto _Error;
            //            if (TaskGantry.MotorAlarm(TaskGantry.GYAxis, ref TaskGantry._GYAlm, false)) goto _Error;
            //        }
            //        catch
            //        { goto _Error; }
            //    }
            //    Application.DoEvents();

            //    Busy = false;
            //    return;
            //_Error:
            //    Busy = false;
            //    //b_ScrollMode = false;
            //    MouseMode = EMouseMode.None;
            //    Cursor.Current = Cursors.Default;
            //    Cursor.Show();
                #endregion
            }
        }
        private void pbox_Image_MouseCaptureChanged(object sender, EventArgs e)
        {
        }
        private void pbox_Image_MouseLeave(object sender, EventArgs e)
        {
        }
        private void pbox_Image_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        #region pnl_Menu1
        private void btn_Menu1_Click(object sender, EventArgs e)
        {
            //pnl_Menu1.Visible = false;
            //pnl_Menu2.Visible = true;
            //pnl_Menu3.Visible = false;
            UpdateMenuVisible(2);
        }
        private void btn_Cam1_Click(object sender, EventArgs e)
        {
            UpdateMenuVisible(1);

            if (GDefine.CameraType[0] == GDefine.ECameraType.Basler)
            {
                TaskVision.SelectedCam = ECamNo.Cam00;
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
            {
                //if (!TaskVision.PtGrey_Connected(0)) return;
                //TaskVision.SelectedCam = ECamNo.Cam00;
                //try
                //{
                //    TaskVision.PtGrey_CamLive(0);
                //}
                //catch (Exception ex)
                //{
                //    Msg MsgBox = new Msg();
                //    MsgBox.Show(ex.Message.ToString());
                //}
            }
            TaskVision.CameraRun = true;
        }
        private void btn_Cam2_Click(object sender, EventArgs e)
        {
            UpdateMenuVisible(1);

            if (GDefine.CameraType[1] == GDefine.ECameraType.Basler)
            {
                TaskVision.SelectedCam = ECamNo.Cam01;
            }


            if (GDefine.CameraType[1] == GDefine.ECameraType.PtGrey)
            {
                //if (!TaskVision.PtGrey_Connected(1)) return;
                //TaskVision.SelectedCam = ECamNo.Cam01;
                //try
                //{
                //    TaskVision.PtGrey_CamLive(1);
                //}
                //catch (Exception ex)
                //{
                //    Msg MsgBox = new Msg();
                //    MsgBox.Show(ex.Message.ToString());
                //}
            }
            TaskVision.CameraRun = true;
        }
        private void btn_Cam3_Click(object sender, EventArgs e)
        {
            UpdateMenuVisible(1);

            if (GDefine.CameraType[2] == GDefine.ECameraType.Basler)
            {
                TaskVision.SelectedCam = ECamNo.Cam02;
            }

            if (GDefine.CameraType[2] == GDefine.ECameraType.PtGrey)
            {
                //if (!TaskVision.PtGrey_Connected(2)) return;
                //TaskVision.SelectedCam = ECamNo.Cam02;
                //try
                //{
                //    TaskVision.PtGrey_CamLive(2);
                //}
                //catch (Exception ex)
                //{
                //    Msg MsgBox = new Msg();
                //    MsgBox.Show(ex.Message.ToString());
                //}
            }
            TaskVision.CameraRun = true;
        }
        private void btn_LightingAdjust_Click(object sender, EventArgs e)
        {
            UpdateMenuVisible(1);

            Point P = Cursor.Position;
            frm_Lighting.Left = P.X - frm_Lighting.Width;
            frm_Lighting.Top = P.Y;
            frm_Lighting.Visible = !frm_Lighting.Visible;
        }
        #endregion

        #region pnl_Menu2
        private void btn_Menu2_Click(object sender, EventArgs e)
        {
            //pnl_Menu1.Visible = false;
            //pnl_Menu2.Visible = false;
            //pnl_Menu3.Visible = true;
            UpdateMenuVisible(3);
        }
        private void btn_ReticleSetup_Click(object sender, EventArgs e)
        {
            //UpdateMenuVisible(2);

            frm_DispCore_ReticleSetup frm = new frm_DispCore_ReticleSetup();
            frm.CamID = 0;
            frm.ShowDialog();
        }
        #endregion

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (Visible) UpdateDisplay();
        }

        private void frmVisionView_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void frmVisionView_KeyUp(object sender, KeyEventArgs e)
        {
        }

        #region Menu Display
        private int VisibleMenu = 1;
        private void UpdateMenuVisible(int MenuNo)
        {
            switch (MenuNo)
            {
                default:
                case 1:
                    pnl_Menu1.Visible = true;
                    pnl_Menu2.Visible = false;
                    pnl_Menu3.Visible = false;
                    break;
                case 2:
                    pnl_Menu1.Visible = false;
                    pnl_Menu2.Visible = true;
                    pnl_Menu3.Visible = false;
                    break;
                case 3:
                    pnl_Menu1.Visible = false;
                    pnl_Menu2.Visible = false;
                    pnl_Menu3.Visible = true;
                    break;
                case 4:
                    pnl_Menu1.Visible = true;
                    pnl_Menu2.Visible = true;
                    pnl_Menu3.Visible = true;
                    break;
            }

            VisibleMenu = 0;
            int H = 3 + pbox_Image.Height;
            if (pnl_Menu1.Visible)
            {
                H = H + pnl_Menu1.Height + 1;
                VisibleMenu++;
            }
            if (pnl_Menu2.Visible)
            {
                H = H + pnl_Menu2.Height + 1;
                VisibleMenu++;
            }
            if (pnl_Menu3.Visible)
            {
                H = H + pnl_Menu3.Height + 1;
                VisibleMenu++;
            }
            H = H + 3;

            this.Height = H + pnl_Menu3.Height; ;
        }

        //bool b_MouseDn = false;
        //Point b_MouseDnPoint = new Point(0, 0);
        //private void btn_Menu_MouseMove(object sender, MouseEventArgs e)
        //{
        //        Point b_MousePoint = new Point(0, 0);
        //        b_MousePoint = MousePosition;

        //        if (b_MouseDn)
        //        {
        //            if (VisibleMenu == 1)
        //            {
        //                if ((b_MousePoint.Y - b_MouseDnPoint.Y) > (btn_Menu3.Height / 4))
        //                {
        //                    UpdateMenuVisible(4);
        //                    b_MouseDn = false;
        //                }
        //            }
        //        }
        //}

        //private void btn_Menu1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (VisibleMenu > 1)
        //    {
        //        UpdateMenuVisible(1);
        //        return;
        //    }

        //    b_MouseDn = true;
        //    b_MouseDnPoint = MousePosition;
        //}
        //private void btn_Menu1_MouseUp(object sender, MouseEventArgs e)
        //{


        //    if (!b_MouseDn)
        //    //    if (VisibleMenu > 1)
        //        {
        //        return;
        //    }

        //    b_MouseDn = false;
        //    UpdateMenuVisible(2);
        //}
        //private void btn_Menu1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btn_Menu_MouseMove(sender, e);
        //}

        //private void btn_Menu2_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (VisibleMenu > 1)
        //    {
        //        UpdateMenuVisible(2);
        //        return;
        //    }

        //    b_MouseDn = true;
        //    b_MouseDnPoint = MousePosition;
        //}
        //private void btn_Menu2_MouseUp(object sender, MouseEventArgs e)
        //{


        //    if (!b_MouseDn)
        //    //    if (VisibleMenu > 1)
        //        {
        //        return;
        //    }

        //    b_MouseDn = false;
        //    UpdateMenuVisible(3);
        //}
        //private void btn_Menu2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btn_Menu_MouseMove(sender, e);
        //}

        //private void btn_Menu3_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (VisibleMenu > 1)
        //    {
        //        UpdateMenuVisible(3);
        //        return;
        //    }
        //    b_MouseDn = true;
        //    b_MouseDnPoint = MousePosition;
        //}
        //private void btn_Menu3_MouseUp(object sender, MouseEventArgs e)
        //{
        //    //if (VisibleMenu > 1)
        //        if (!b_MouseDn)
        //    {
        //        return;
        //    }

        //    b_MouseDn = false;
        //    UpdateMenuVisible(1);
        //}
        //private void btn_Menu3_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btn_Menu_MouseMove(sender, e);
        //}
        //private void btn_Menu3_MouseEnter(object sender, EventArgs e)
        //{
        //    //if (VisibleMenu > 1)
        //    //{
        //    //    UpdateMenuVisible(3);
        //    //    return;
        //    //}
        //}
        #endregion

        #region pnl_Menu3
        private void btn_Live_Click(object sender, EventArgs e)
        {
            UpdateMenuVisible(3);

            if (GDefine.CameraType[(int)SelectedCam] == GDefine.ECameraType.Basler) StartGrab();
            if (GDefine.CameraType[(int)SelectedCam] == GDefine.ECameraType.PtGrey)
            {
                //TaskVision.PtGrey_CamLive((int)SelectedCam);
            }
            if (GDefine.CameraType[(int)SelectedCam] == GDefine.ECameraType.Spinnaker)
            {
                TaskVision.Flir_CamLive((int)SelectedCam);
            }
        }
        private void btn_Grab_Click(object sender, EventArgs e)
        {
            UpdateMenuVisible(3);

            try
            {
                if (GDefine.CameraType[(int)SelectedCam] == GDefine.ECameraType.Basler) StopGrab();
                if (GDefine.CameraType[(int)SelectedCam] == GDefine.ECameraType.PtGrey)
                {
                    //TaskVision.PtGrey_CamStop();
                    //ImageG = TaskVision.PGCamera[(int)SelectedCam].Image().ToImage<Gray, byte>();//new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(TaskVision.PGCamera[(int)SelectedCam].Image());
                }
                if (GDefine.CameraType[(int)SelectedCam] == GDefine.ECameraType.Spinnaker)
                {
                    //TaskVision.FlirCamera[(int)SelectedCam].Grab();
                    //ImageG = TaskVision.FlirCamera[(int)SelectedCam].m_ImageEmgu.m_Image.Clone();
                }
            }
            catch (Exception Ex)
            { MessageBox.Show(Ex.Message.ToString());
            }
        }
        private void btn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            string ImagePath = GDefine.AppPath + "\\" + "Image";
            try
            {
                System.IO.Directory.CreateDirectory(ImagePath);
            }
            catch { };

            ofd.InitialDirectory = ImagePath;
            ofd.Filter = "Jpeg(*.jgp)|*.jpg|Bitmap (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (GDefine.CameraType[(int)SelectedCam] == GDefine.ECameraType.Basler) StopGrab();
                    if (GDefine.CameraType[(int)SelectedCam] == GDefine.ECameraType.PtGrey)
                    {
                        //TaskVision.PtGrey_CamStop();
                    }
                }
                catch { };

                ImageG = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(ofd.FileName);
                TaskVision.LoadedImageG = ImageG.Copy();

                try
                {
                    //Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> ImageC = VisProc.Convert(ImageG);
                    Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> ImageC = ImageG.Convert<Emgu.CV.Structure.Bgr, byte>();

                    TaskVision.ImageDrawReticle(ImageG, ImageC);

                    pbox_Image.Image = ImageC.ToBitmap();
                    pbox_Image.Invalidate();

                    ImageC.Dispose();
                }
                catch
                {
                    GC.Collect();
                    Log.AddToLog("btn_Load_Click, Refresh, Exception GC Collected");
                }

                Thread.Sleep(1);
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            UpdateMenuVisible(3);

            btn_Grab_Click(sender, e);

            SaveFileDialog sfd = new SaveFileDialog();

            string ImagePath = GDefine.AppPath + "\\" + "Image";
            try
            {
                System.IO.Directory.CreateDirectory(ImagePath);
            }
            catch {};

            sfd.InitialDirectory = ImagePath; 
            sfd.Filter = "Jpeg(*.jgp)|*.jpg|Bitmap (*.bmp)|*.bmp";
            sfd.FileName = DateTime.Now.ToString("yyyyMMdd_HHmm") + "_Cam" + ((int)TaskVision.SelectedCam + 1).ToString();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ImageG.Save(sfd.FileName);
            }

            btn_Live_Click(sender, e);
        }
        private void btn_Menu3_Click(object sender, EventArgs e)
        {
            UpdateMenuVisible(1);
        }
        #endregion
    }
}
