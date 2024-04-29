using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace NDispWin
{
    internal partial class frmDispProgDoRefEdge : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);


        public frmDispProgDoRefEdge()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            cbox_Use2RefPts.Visible = true;

            cbxTool1.DataSource = Enum.GetValues(typeof(TFVision.EToolType));
            cbxTool2.DataSource = Enum.GetValues(typeof(TFVision.EToolType));

            cbxWindows1.DataSource = Enum.GetValues(typeof(TFVision.EArea));
            cbxWindows2.DataSource = Enum.GetValues(typeof(TFVision.EArea));
            cbxDirection1.DataSource = Enum.GetValues(typeof(TFVision.EDirPair));
            cbxDirection2.DataSource = Enum.GetValues(typeof(TFVision.EDirPair));
            cbxTrans1.DataSource = Enum.GetValues(typeof(TFVision.ETransPair));
            cbxTrans2.DataSource = Enum.GetValues(typeof(TFVision.ETransPair));

            cbxDetContrast1.DataSource = Enum.GetValues(typeof(TFVision.EDetContrast));
            cbxDetContrast2.DataSource = Enum.GetValues(typeof(TFVision.EDetContrast));
        }

        private void UpdateDisplay()
        {
            lbl_RefID.Text = CmdLine.ID.ToString();
            lbl_FocusNo.Text = CmdLine.IPara[21].ToString();

            lbl_AlignType.Text = CmdLine.IPara[2].ToString() + " - " + Enum.GetName(typeof(EAlignType), CmdLine.IPara[2]);

            cbxTool1.SelectedIndex = CmdLine.IPara[8];
            cbxTool2.SelectedIndex = CmdLine.IPara[9];

            pnlEdge1.Visible = cbxTool1.SelectedIndex == (int)TFVision.EToolType.PatEdgeCorner;
            pnlEdge2.Visible = cbxTool2.SelectedIndex == (int)TFVision.EToolType.PatEdgeCorner;
            cbxWindows1.SelectedIndex = CmdLine.IPara[14];
            cbxWindows2.SelectedIndex = CmdLine.IPara[15];
            cbxDirection1.SelectedIndex = CmdLine.IPara[10];
            cbxDirection2.SelectedIndex = CmdLine.IPara[11];
            cbxTrans1.SelectedIndex = CmdLine.IPara[12];
            cbxTrans2.SelectedIndex = CmdLine.IPara[13];

            pnlCircle1.Visible = cbxTool1.SelectedIndex == (int)TFVision.EToolType.PatCircle;
            pnlCircle2.Visible = cbxTool2.SelectedIndex == (int)TFVision.EToolType.PatCircle;
            cbxDetContrast1.SelectedIndex = CmdLine.IPara[16];
            cbxDetContrast2.SelectedIndex = CmdLine.IPara[17];

            cbox_Use2RefPts.Checked = (CmdLine.IPara[0] == 2);
            gbox_Ref2.Visible = (CmdLine.IPara[0] == 2);
            lbl_AcceptTol.Text = CmdLine.DPara[6].ToString("f3");

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");
            lbl_X2Y2.Text = CmdLine.X[1].ToString("F3") + ", " + CmdLine.Y[1].ToString("F3");

            lbl_XYTol.Text = CmdLine.DPara[1].ToString("F3");
            lbl_AngleTol.Text = CmdLine.DPara[2].ToString("F3");
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProgDoRefEdge_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            TaskVision.SelectedCam = (ECamNo)CmdLine.IPara[1];
            TaskVision.LightingOn(TaskVision.LightRGB[CmdLine.ID]);

            if (CmdLine.IPara[0] < 1) CmdLine.IPara[0] = 1;
            if (CmdLine.IPara[0] > 2) CmdLine.IPara[0] = 2;

            if (CmdLine.DPara[0] == 0) CmdLine.DPara[0] = 0.85;
            if (CmdLine.DPara[1] == 0) CmdLine.DPara[1] = 2;
            if (CmdLine.DPara[2] == 0) CmdLine.DPara[2] = 5;

            if (CmdLine.DPara[6] == 0) CmdLine.DPara[6] = 1;//Accept Tol

            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;//Settle Time

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };

            UpdateDisplay();
        }

        private void frmDispProgDoRefEdge_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            Log.OnAction("OK", CmdName);
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            Log.OnAction("Cancel", CmdName);
            Close();
        }


        private void lbl_FocusNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Focus No", ref CmdLine.IPara[21], 0, DispProg.MAX_FOCUS_POS - 1);
            UpdateDisplay();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
        }
        private void lbl_RefID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", RefID", ref CmdLine.ID, 0, TaskVision.MAX_REF_TEMPLATE);
            UpdateDisplay();
        }
        private void cbox_Use2RefPts_Click(object sender, EventArgs e)
        {
            if (cbox_Use2RefPts.Checked) CmdLine.IPara[0] = 2; else CmdLine.IPara[0] = 1;
            UpdateDisplay();
        }

        private void btn_SetPt1Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            Log.OnSet(CmdName + ", Pt1 XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetPt2Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            CmdLine.X[1] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[1], CmdLine.Y[1]);
            Log.OnSet(CmdName + ", Pt1 XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt2Pos_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private /*async*/ void btn_Learn1_Click(object sender, EventArgs e)
        {
            int id = CmdLine.ID;
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> img = null;
            try
            {
                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.flirCamera2[0].Snap();
                    img = TaskVision.flirCamera2[0].m_ImageEmgu.m_Image.Clone();
                    TaskVision.flirCamera2[0].GrabCont();
                }
                else
                    throw new Exception("Camera Type not Supported.");

                Rectangle[] rects = new Rectangle[] { TaskVision.RefTemplate[id, 0].SearchRoi, TaskVision.RefTemplate[id, 2].SearchRoi };

                switch ((TFVision.EToolType)CmdLine.IPara[8])
                {
                    case TFVision.EToolType.PatEdgeCorner:
                        TFVision.EArea area = (TFVision.EArea)CmdLine.IPara[14];
                        TFVision.EDirPair dirPair = (TFVision.EDirPair)CmdLine.IPara[10];
                        TFVision.ETransPair transPair = (TFVision.ETransPair)CmdLine.IPara[12];
                        TFVision.EDirection dir1 = dirPair == TFVision.EDirPair.XRight_YDown || dirPair == TFVision.EDirPair.XRight_YUp ? TFVision.EDirection.PLUS : TFVision.EDirection.MINUS;
                        TFVision.EDirection dir2 = dirPair == TFVision.EDirPair.XRight_YDown || dirPair == TFVision.EDirPair.XLeft_YDown ? TFVision.EDirection.PLUS : TFVision.EDirection.MINUS;
                        TFVision.ETransition trans1 = transPair == TFVision.ETransPair.Auto ? TFVision.ETransition.AUTO : transPair == TFVision.ETransPair.BW || transPair == TFVision.ETransPair.XBW_YWB ? TFVision.ETransition.BW : TFVision.ETransition.WB;
                        TFVision.ETransition trans2 = transPair == TFVision.ETransPair.Auto ? TFVision.ETransition.AUTO : transPair == TFVision.ETransPair.WB || transPair == TFVision.ETransPair.XWB_YBW ? TFVision.ETransition.WB : TFVision.ETransition.BW;

                        //await Task.Run(() =>
                        //{
                            TFVision.PatEdgeLearn(img, ref TaskVision.RefTemplate[id, 0].Image, ref rects, area, dir1, dir2, trans1, trans2);
                        //});
                        break;
                    case TFVision.EToolType.PatCircle:
                        TFVision.EDetContrast detContrast = (TFVision.EDetContrast)CmdLine.IPara[16];
                        int threshold = (int)CmdLine.DPara[5];
                        //await Task.Run(() =>
                        //{
                            TFVision.PatCircleLearn(img, ref TaskVision.RefTemplate[id, 0].Image, ref threshold, ref rects, detContrast);
                        //});
                        CmdLine.DPara[5] = threshold;
                        break;
                }

                TaskVision.RefTemplate[id, 0].SearchRoi = rects[0];
                TaskVision.RefTemplate[id, 2].SearchRoi = rects[1];
                TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;

                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.frmCamera.SelectCamera(0);
                    TaskVision.frmCamera.Grab();
                }

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
            }
            finally
            {
                if (img != null) img.Dispose();
            }
            UpdateDisplay();
        }
        private /*async*/ void btn_Learn2_Click(object sender, EventArgs e)
        {
            int id = CmdLine.ID;
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> img = null;
            try
            {
                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.flirCamera2[0].Snap();
                    img = TaskVision.flirCamera2[0].m_ImageEmgu.m_Image.Clone();
                    TaskVision.flirCamera2[0].GrabCont();
                }
                else
                    throw new Exception("Camera Type not Supported.");

                Rectangle[] rects = new Rectangle[] { TaskVision.RefTemplate[id, 1].SearchRoi, TaskVision.RefTemplate[id, 3].SearchRoi };

                switch ((TFVision.EToolType)CmdLine.IPara[9])
                {
                    case TFVision.EToolType.PatEdgeCorner:
                        TFVision.EArea area = (TFVision.EArea)CmdLine.IPara[15];
                        TFVision.EDirPair dirPair = (TFVision.EDirPair)CmdLine.IPara[11];
                        TFVision.ETransPair transPair = (TFVision.ETransPair)CmdLine.IPara[13];
                        TFVision.EDirection dir1 = dirPair == TFVision.EDirPair.XRight_YDown || dirPair == TFVision.EDirPair.XRight_YUp ? TFVision.EDirection.PLUS : TFVision.EDirection.MINUS;
                        TFVision.EDirection dir2 = dirPair == TFVision.EDirPair.XRight_YDown || dirPair == TFVision.EDirPair.XLeft_YDown ? TFVision.EDirection.PLUS : TFVision.EDirection.MINUS;
                        TFVision.ETransition trans1 = transPair == TFVision.ETransPair.Auto ? TFVision.ETransition.AUTO : transPair == TFVision.ETransPair.BW || transPair == TFVision.ETransPair.XBW_YWB ? TFVision.ETransition.BW : TFVision.ETransition.WB;
                        TFVision.ETransition trans2 = transPair == TFVision.ETransPair.Auto ? TFVision.ETransition.AUTO : transPair == TFVision.ETransPair.WB || transPair == TFVision.ETransPair.XWB_YBW ? TFVision.ETransition.WB : TFVision.ETransition.BW;

                        //await Task.Run(() =>
                        //{
                            TFVision.PatEdgeLearn(img, ref TaskVision.RefTemplate[id, 1].Image, ref rects, area, dir1, dir2, trans1, trans2);
                        //});
                        break;
                    case TFVision.EToolType.PatCircle:
                        TFVision.EDetContrast detContrast = (TFVision.EDetContrast)CmdLine.IPara[17];
                        int threshold = (int)CmdLine.DPara[5];
                        //await Task.Run(() =>
                        //{
                            TFVision.PatCircleLearn(img, ref TaskVision.RefTemplate[id, 1].Image, ref threshold , ref rects, detContrast);
                        //});
                        CmdLine.DPara[5] = threshold;
                        break;
                }

                TaskVision.RefTemplate[id, 1].SearchRoi = rects[0];
                TaskVision.RefTemplate[id, 3].SearchRoi = rects[1];

                TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
            }
            finally
            {
                if (img != null) img.Dispose();
            }
            UpdateDisplay();

        }

        private bool Find(int refNo, ref PointF ofst, ref float amplitude, ref int found, ref float roundness )
        {
            int id = CmdLine.ID;
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> img = null;
            try
            {
                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.flirCamera2[0].Snap();
                    img = TaskVision.flirCamera2[0].m_ImageEmgu.m_Image.Clone();
                    TaskVision.flirCamera2[0].GrabCont();
                }
                else
                    throw new Exception("Camera Type not Supported.");

                PointF patLoc = new PointF(0, 0);
                PointF patOfst = new PointF(0, 0);

                TFVision.EToolType toolType = (TFVision.EToolType)(refNo == 0 ? CmdLine.IPara[8] : CmdLine.IPara[9]);

                switch (toolType)
                {
                    case TFVision.EToolType.PatEdgeCorner:
                        {
                            Rectangle[] rects = new Rectangle[2] { TaskVision.RefTemplate[id, refNo].SearchRoi, TaskVision.RefTemplate[id, refNo + 2].SearchRoi };

                            TFVision.EArea area = refNo == 0 ? (TFVision.EArea)CmdLine.IPara[14] : (TFVision.EArea)CmdLine.IPara[15];
                            TFVision.EDirPair dirPair = refNo == 0 ? (TFVision.EDirPair)CmdLine.IPara[10] : (TFVision.EDirPair)CmdLine.IPara[11];
                            TFVision.ETransPair transPair = refNo == 0 ? (TFVision.ETransPair)CmdLine.IPara[12] : (TFVision.ETransPair)CmdLine.IPara[13];

                            TFVision.EDirection dir1 = dirPair == TFVision.EDirPair.XRight_YDown || dirPair == TFVision.EDirPair.XRight_YUp ? TFVision.EDirection.PLUS : TFVision.EDirection.MINUS;
                            TFVision.EDirection dir2 = dirPair == TFVision.EDirPair.XRight_YDown || dirPair == TFVision.EDirPair.XLeft_YDown ? TFVision.EDirection.PLUS : TFVision.EDirection.MINUS;
                            TFVision.ETransition trans1 = transPair == TFVision.ETransPair.Auto ? TFVision.ETransition.AUTO : transPair == TFVision.ETransPair.BW || transPair == TFVision.ETransPair.XBW_YWB ? TFVision.ETransition.BW : TFVision.ETransition.WB;
                            TFVision.ETransition trans2 = transPair == TFVision.ETransPair.Auto ? TFVision.ETransition.AUTO : transPair == TFVision.ETransPair.WB || transPair == TFVision.ETransPair.XWB_YBW ? TFVision.ETransition.WB : TFVision.ETransition.BW;

                            List<PointF> pointsX = new List<PointF>();
                            List<PointF> pointsY = new List<PointF>();

                            if (GDefine.CameraType[CmdLine.IPara[1]] == GDefine.ECameraType.None)
                            {
                                if (!TFVision.PatEdgeCorner(TaskVision.LoadedImageG, TaskVision.RefTemplate[id, refNo].Image, rects, ref pointsX, ref pointsY, ref patLoc, ref patOfst, ref amplitude, area, dir1, dir2, trans1, trans2)) return false;
                            }
                            else
                            {
                                if (!TFVision.PatEdgeCorner(img, TaskVision.RefTemplate[id, refNo].Image, rects, ref pointsX, ref pointsY, ref patLoc, ref patOfst, ref amplitude, area, dir1, dir2, trans1, trans2)) return false;
                            }

                            double scale = TaskVision.flirCamera2[0].imgBoxEmgu.ZoomScale;
                            double ox = TaskVision.flirCamera2[0].imgBoxEmgu.HorizontalScrollBar.Value;
                            double oy = TaskVision.flirCamera2[0].imgBoxEmgu.VerticalScrollBar.Value;

                            Graphics g;
                            g = TaskVision.flirCamera2[0].imgBoxEmgu.CreateGraphics();
                            Pen p = new Pen(Color.Blue, 2);
                            p.Color = amplitude > 10 ? Color.Lime : Color.Red;
                            float ix = (float)((patLoc.X - ox) * scale);
                            float iy = (float)((patLoc.Y - oy) * scale);

                            g.DrawLine(p, ix, iy - 20, ix, iy + 20);
                            g.DrawLine(p, ix - 20, iy, ix + 20, iy);

                            break;
                        }
                    case TFVision.EToolType.PatCircle:
                        {
                            float patRadius = 0;

                            Rectangle[] rects = new Rectangle[2] { TaskVision.RefTemplate[id, refNo].SearchRoi, TaskVision.RefTemplate[id, refNo + 2].SearchRoi };

                            TFVision.EDetContrast detContrast = refNo == 0 ? (TFVision.EDetContrast)CmdLine.IPara[16] : (TFVision.EDetContrast)CmdLine.IPara[17];
                            int threshold = (int)CmdLine.DPara[5];

                            List<PointF> pointsX = new List<PointF>();
                            List<PointF> pointsY = new List<PointF>();

                            found = TFVision.PatCircle(GDefine.CameraType[CmdLine.IPara[1]] == GDefine.ECameraType.None ? TaskVision.LoadedImageG : img,
                                TaskVision.RefTemplate[id, refNo].Image, threshold, rects, detContrast, ref patLoc, ref patRadius, ref patOfst, ref roundness);
                            if (found == 0) return false;


                            double scale = TaskVision.flirCamera2[0].imgBoxEmgu.ZoomScale;
                            double ox = TaskVision.flirCamera2[0].imgBoxEmgu.HorizontalScrollBar.Value;
                            double oy = TaskVision.flirCamera2[0].imgBoxEmgu.VerticalScrollBar.Value;

                            Graphics g;
                            g = TaskVision.flirCamera2[0].imgBoxEmgu.CreateGraphics();
                            Pen p = new Pen(Color.Lime, 2);
                            p.Color = (found > 0 && roundness > 0.85) ? Color.Lime : Color.Red;

                            if (found > 0)
                            {
                                PointF center = new PointF((float)((patLoc.X - ox) * scale), (float)((patLoc.Y - oy) * scale));
                                PointF location = new PointF((float)((patLoc.X - ox - patRadius) * scale), (float)((patLoc.Y - oy - patRadius) * scale));
                                SizeF size = new SizeF((float)(patRadius * 2 * scale), (float)(patRadius * 2 * scale));

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
                
                ofst.X = (float)(patOfst.X * TaskVision.DistPerPixelX[CmdLine.IPara[1]]);
                ofst.Y = -(float)(patOfst.Y * TaskVision.DistPerPixelY[CmdLine.IPara[1]]);

                if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE)
                {
                    ofst.Y = -ofst.Y;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name.ToString() + '\r' + ex.Message.ToString());
            }
            finally
            {
                if (img != null) img.Dispose();
            }
            return true;
        }

        private void btn_Test1_Click(object sender, EventArgs e)
        {
            if (GDefine.Status == EStatus.Ready)
                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            int t = Environment.TickCount;
            PointF ofst = new PointF(0, 0);
            float amplitude = 0;
            int found = 0;
            float roundness = 0;
            Find(0, ref ofst, ref amplitude, ref found, ref roundness);
            t = Environment.TickCount - t;

            TFVision.EToolType toolType = (TFVision.EToolType)CmdLine.IPara[8];
            switch (toolType)
            {
                case TFVision.EToolType.PatEdgeCorner:
                    {
                        rtbInfo.BackColor = amplitude < 0 ? Color.Red : this.BackColor;
                        rtbInfo.Text = $"Test1: X,Y (mm) {ofst.X:f3},{ofst.Y:f3} Amplitude {amplitude:f1} Time(ms) {t:f0}";
                        break;
                    }
                case TFVision.EToolType.PatCircle:
                    {
                        rtbInfo.BackColor = roundness < 0.85 ? Color.Red : this.BackColor;
                        rtbInfo.Text = $"Test1: X,Y (mm) {ofst.X:f3},{ofst.Y:f3} Found {found} Roundness {roundness:f3} Time(ms) {t:f0}";
                        break;
                    }
            }
            UpdateDisplay();
        }
        private void btn_Align1_Click(object sender, EventArgs e)
        {
            rtbInfo.Clear();

            if (GDefine.Status == EStatus.Ready)
                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            PointF patLoc = new PointF(0, 0);
            PointF ofst = new PointF(0, 0);
            TFVision.EToolType toolType = (TFVision.EToolType)CmdLine.IPara[8];
            switch (toolType)
            {
                case TFVision.EToolType.PatEdgeCorner:
                    {
                        int t = Environment.TickCount;
                        float amplitude = 0;
                        if (!DispProg.DoRefEdge(CmdLine, 0, TaskGantry.GXPos(), TaskGantry.GYPos(), ref patLoc, ref ofst, ref amplitude)) return;
                        t = Environment.TickCount - t;

                        rtbInfo.BackColor = amplitude < 0 ? Color.Red : this.BackColor;
                        rtbInfo.Text = $"Align1: X,Y (mm) {ofst.X:f3},{ofst.Y:f3} Amplitude {amplitude:f1} Time(ms) {t:f0}";
                        break;
                    }
                case TFVision.EToolType.PatCircle:
                    {
                        int t = Environment.TickCount;
                        int found = 0;
                        float roundness = 0;
                        if (!DispProg.DoRefCircle(CmdLine, 0, TaskGantry.GXPos(), TaskGantry.GYPos(), ref patLoc, ref ofst, ref found, ref roundness)) return;
                        t = Environment.TickCount - t;

                        rtbInfo.BackColor = roundness < 0.85 ? Color.Red : this.BackColor;
                        rtbInfo.Text = $"Align1: X,Y (mm) {ofst.X:f3},{ofst.Y:f3} Found {found} Roundness {roundness:f3} Time(ms) {t:f0}";
                        break;
                    }
            }
        }

        private void btn_Test2_Click(object sender, EventArgs e)
        {
            if (GDefine.Status == EStatus.Ready)
                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            int t = Environment.TickCount;
            PointF ofst = new PointF(0, 0);
            float amplitude = 0;
            int found = 0;
            float roundness = 0;
            Find(1, ref ofst, ref amplitude, ref found, ref roundness);
            t = Environment.TickCount - t;

            TFVision.EToolType toolType = (TFVision.EToolType)CmdLine.IPara[9];
            switch (toolType)
            {
                case TFVision.EToolType.PatEdgeCorner:
                    {
                        rtbInfo.BackColor = amplitude < 0 ? Color.Red : this.BackColor;
                        rtbInfo.Text = $"Test2: X,Y (mm) {ofst.X:f3},{ofst.Y:f3} Amplitude {amplitude:f1} Time(ms) {t:f0}";
                        break;
                    }
                case TFVision.EToolType.PatCircle:
                    {
                        rtbInfo.BackColor = roundness < 0.85 ? Color.Red : this.BackColor;
                        rtbInfo.Text = $"Test2: X,Y (mm) {ofst.X:f3},{ofst.Y:f3} Found {found} Roundness {roundness:f3} Time(ms) {t:f0}";
                        break;
                    }
            }
            UpdateDisplay();
        }
        private void btn_Align2_Click(object sender, EventArgs e)
        {
            if (GDefine.Status == EStatus.Ready)
                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            PointF patLoc = new PointF(0, 0);
            PointF ofst = new PointF(0, 0);
            TFVision.EToolType toolType = (TFVision.EToolType)CmdLine.IPara[9];
            switch (toolType)
            {
                case TFVision.EToolType.PatEdgeCorner:
                    {
                        int t = Environment.TickCount;
                        float amplitude = 0;
                        if (!DispProg.DoRefEdge(CmdLine, 0, TaskGantry.GXPos(), TaskGantry.GYPos(), ref patLoc, ref ofst, ref amplitude)) return;
                        t = Environment.TickCount - t;

                        rtbInfo.BackColor = amplitude < 0 ? Color.Red : this.BackColor;
                        rtbInfo.Text = $"Align2: X,Y (mm) {ofst.X:f3},{ofst.Y:f3} Amplitude {amplitude:f1} Time(ms) {t:f0}";
                        break;
                    }
                case TFVision.EToolType.PatCircle:
                    {
                        int t = Environment.TickCount;
                        int found = 0;
                        float roundness = 0;
                        if (!DispProg.DoRefCircle(CmdLine, 0, TaskGantry.GXPos(), TaskGantry.GYPos(), ref patLoc, ref ofst, ref found, ref roundness)) return;
                        t = Environment.TickCount - t;

                        rtbInfo.BackColor = roundness < 0.85 ? Color.Red : this.BackColor;
                        rtbInfo.Text = $"Align2: X,Y (mm) {ofst.X:f3},{ofst.Y:f3} Found {found} Roundness {roundness:f3} Time(ms) {t:f0}";
                        break;
                    }
            }
        }

        private void cbxCorner1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[10] = cbxDirection1.SelectedIndex;
        }
        private void cbxCorner2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[11] = cbxDirection2.SelectedIndex;
        }

        private void cbxTrans1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[12] = cbxTrans1.SelectedIndex;
        }
        private void cbxTrans2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[13] = cbxTrans2.SelectedIndex;
        }

        private void lbl_AlignType_Click(object sender, EventArgs e)
        {
            EAlignType E = EAlignType.Board;
            UC.AdjustExec(CmdName + ", Align Type", ref CmdLine.IPara[2], E);
            UpdateDisplay();
        }
        private void lbl_XYTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", XY Tol (mm)", ref CmdLine.DPara[1], 0, 5);
            UpdateDisplay();
        }
        private void lbl_AngleTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Angle Tol (mm)", ref CmdLine.DPara[2], 0, 5);
            UpdateDisplay();
        }
        private void lbl_AcceptTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Accept Tol (mm)", ref CmdLine.DPara[6], 0, 1);
            UpdateDisplay();
        }

        private void cbxWindows1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdLine.IPara[14] = cbxWindows1.SelectedIndex;
        }
        private void cbxWindows2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdLine.IPara[15] = cbxWindows2.SelectedIndex;
        }

        private void cbxTool1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[8] = cbxTool1.SelectedIndex;
            UpdateDisplay();
        }
        private void cbxTool2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[9] = cbxTool2.SelectedIndex;
            UpdateDisplay();
        }

        private void cbxDetContrast1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[16] = cbxDetContrast1.SelectedIndex;
            UpdateDisplay();
        }
        private void cbxDetContrast2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[17] = cbxDetContrast2.SelectedIndex;
            UpdateDisplay();
        }

        private void btn_AlignAll_Click(object sender, EventArgs e)
        {
            rtbInfo.Clear();
            rtbInfo.BackColor = this.BackColor;

            int tt = Environment.TickCount;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;

            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            TPos2 pt1 = new TPos2();
            pt1.X = DispProg.Origin(ERunStationNo.Station1).X + CmdLine.X[0];
            pt1.Y = DispProg.Origin(ERunStationNo.Station1).Y + CmdLine.Y[0];

            PointF patLoc1 = new PointF(0, 0);
            PointF ofst1 = new PointF(0, 0);
            TFVision.EToolType toolType = (TFVision.EToolType)CmdLine.IPara[8];
            switch (toolType)
            {
                case TFVision.EToolType.PatEdgeCorner:
                    {
                        int t = Environment.TickCount;
                        float amplitude = 0;
                        if (!DispProg.DoRefEdge(CmdLine, 0, pt1.X, pt1.Y, ref patLoc1, ref ofst1, ref amplitude)) return;
                        t = Environment.TickCount - t;
                        
                        rtbInfo.BackColor = amplitude < 0 ? Color.Red : this.BackColor;
                        rtbInfo.Text += $"Align1: X,Y (mm) {ofst1.X:f3},{ofst1.Y:f3} Amplitude {amplitude:f1} Time(ms) {t:f0}";
                        break;
                    }
                case TFVision.EToolType.PatCircle:
                    {
                        int t = Environment.TickCount;
                        int found = 0;
                        float roundness = 0;
                        if (!DispProg.DoRefCircle(CmdLine, 0, pt1.X, pt1.Y, ref patLoc1, ref ofst1, ref found, ref roundness)) return;
                        t = Environment.TickCount - t;

                        rtbInfo.BackColor = roundness < 0.85 ? Color.Red : this.BackColor;
                        rtbInfo.Text += $"Align1: X,Y (mm) {ofst1.X:f3},{ofst1.Y:f3} Found {found} Roundness {roundness:f3} Time(ms) {t:f0}";
                        break;
                    }
            }

            double relRef2X = CmdLine.X[1] - CmdLine.X[0];
            double relRef2Y = CmdLine.Y[1] - CmdLine.Y[0];
            TPos2 pt2 = new TPos2();
            pt2.X = pt1.X + relRef2X;
            pt2.Y = pt1.Y + relRef2Y;

            PointF patLoc2 = new PointF(0, 0);
            PointF ofst2 = new PointF(0, 0);
            toolType = (TFVision.EToolType)CmdLine.IPara[9];
            switch (toolType)
            {
                case TFVision.EToolType.PatEdgeCorner:
                    {
                        int t = Environment.TickCount;
                        float amplitude = 0;
                        if (!DispProg.DoRefEdge(CmdLine, 0, pt2.X, pt2.Y, ref patLoc2, ref ofst2, ref amplitude)) return;
                        t = Environment.TickCount - t;

                        rtbInfo.BackColor = amplitude < 0 ? Color.Red : this.BackColor;
                        rtbInfo.Text += '\n' + $"Align2: X,Y (mm) {ofst2.X:f3},{ofst2.Y:f3} Amplitude {amplitude:f1} Time(ms) {t:f0}";
                        break;
                    }
                case TFVision.EToolType.PatCircle:
                    {
                        int t = Environment.TickCount;
                        int found = 0;
                        float roundness = 0;
                        if (!DispProg.DoRefCircle(CmdLine, 0, pt2.X, pt2.Y, ref patLoc2, ref ofst2, ref found, ref roundness)) return;
                        t = Environment.TickCount - t;

                        rtbInfo.BackColor = roundness < 0.85 ? Color.Red : this.BackColor;
                        rtbInfo.Text += '\n' + $"Align2: X,Y (mm) {ofst2.X:f3},{ofst2.Y:f3} Found {found} Roundness {roundness:f3} Time(ms) {t:f0}";
                        break;
                    }
            }

            #region Compute Angle
            NSW.Net.Point2D Pt1 = new NSW.Net.Point2D(pt1.X, pt1.Y);
            NSW.Net.Point2D Pt2 = new NSW.Net.Point2D(pt2.X, pt2.Y);
            NSW.Net.Point2D nPt1 = new NSW.Net.Point2D(pt1.X + ofst1.X, pt1.Y + ofst1.X);
            NSW.Net.Point2D nPt2 = new NSW.Net.Point2D(pt2.X + ofst2.X, pt2.Y + ofst2.Y);
            double a = nPt2.Angle(nPt1, Pt1, Pt2);
            if (a > Math.PI) a = a - (Math.PI * 2);
            double d_AngleOfst_Deg = a * 180 / Math.PI;
            #endregion

            //if (Math.Abs(d_AngleOfst_Deg) > CmdLine.DPara[2])
            {
                rtbInfo.Text += $"\nAngle (deg) {d_AngleOfst_Deg:f3}";
            }

            rtbInfo.Text += $"\nTotal Time (ms) {Environment.TickCount - tt}";
        }
    }
}
