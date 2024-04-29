using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NSW.Net;
using System.Threading;

using Emgu.CV;

/*todo
use temp values to be able to cancel
*/

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_DoRef : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_DoRef()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            //AppLanguage.Func.SetComponent(this);
        }

        private void UpdateDisplay()
        {


            lbl_RefID.Text = CmdLine.ID.ToString();
            lbl_CameraID.Text = CmdLine.IPara[1].ToString();
            lbl_FocusNo.Text = CmdLine.IPara[21].ToString();

            cbox_Use2RefPts.Checked = (CmdLine.IPara[0] == 2);
            lbl_PatternType.Text = CmdLine.IPara[3].ToString() + " - " + Enum.GetName(typeof(ERefPatType), CmdLine.IPara[3]);

            lbl_AlignType.Text = CmdLine.IPara[2].ToString() + " - " + Enum.GetName(typeof(EAlignType), CmdLine.IPara[2]);
            if (CmdLine.IPara[20] > 0)
                lbl_Mode.Text = "OTF";
            else
                lbl_Mode.Text = "Normal";

            pnl_Ref1Pat2.Visible = CmdLine.IPara[3] > 0;
            pnl_Ref2Pat2.Visible = CmdLine.IPara[3] > 0;

            gbox_Ref2.Visible = (CmdLine.IPara[0] == 2);
            btn_Learn2.Visible = (CmdLine.IPara[0] == 2);

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");
            lbl_X2Y2.Text = CmdLine.X[1].ToString("F3") + ", " + CmdLine.Y[1].ToString("F3");

            lbl_MinScore.Text = (CmdLine.DPara[0] * 100).ToString("F0");
            lbl_XYTol.Text = CmdLine.DPara[1].ToString("F3");
            lbl_AngleTol.Text = CmdLine.DPara[2].ToString("F3");
            lbl_AcceptTol.Text = CmdLine.DPara[6].ToString("f3");
            lbl_RefDistTol.Text = CmdLine.DPara[3].ToString("F3");
            pnl_RefTol.Visible = CmdLine.IPara[0] == 2;

            bool OTF = CmdLine.IPara[20] > 0;
            if (!OTF)
            {
                #region
                double StartV = CmdLine.DPara[10];
                if (StartV == 0)
                {
                    StartV = TaskGantry.GXAxis.Para.StartV;
                    lbl_StartV.Text = "(" + StartV.ToString("f3") + ")";
                }
                else lbl_StartV.Text = StartV.ToString("f3");
                lbl_StartV.Enabled = true;
                lbl_StartV.BackColor = Color.White;

                double DriveV = CmdLine.DPara[11];
                if (DriveV == 0)
                {
                    DriveV = TaskGantry.GXAxis.Para.FastV;
                    lbl_DriveV.Text = "(" + DriveV.ToString("f3") + ")";
                }
                else lbl_DriveV.Text = DriveV.ToString("f3");

                double Accel = CmdLine.DPara[12];
                if (Accel == 0)
                {
                    Accel = TaskGantry.GXAxis.Para.Accel;
                    lbl_Accel.Text = "(" + Accel.ToString("f3") + ")";
                }
                else lbl_Accel.Text = Accel.ToString("f3");
                lbl_Accel.Enabled = true;
                lbl_Accel.BackColor = Color.White;
                lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
                #endregion
            }
            else
            {
                #region
                lbl_StartV.Enabled = false;
                lbl_StartV.BackColor = this.BackColor;

                double DriveV = CmdLine.DPara[11];
                if (DriveV == 0)
                {
                    DriveV = 100;
                    lbl_DriveV.Text = "(" + DriveV.ToString("f3") + ")";
                }
                else lbl_DriveV.Text = DriveV.ToString("f3");

                double Accel = 2500;//Math.Pow(DriveV, 2) / (2 * ADDist);
                lbl_Accel.Text = "(" + Accel.ToString("f3") + ")";
                lbl_Accel.Enabled = false;
                lbl_Accel.BackColor = this.BackColor;
                lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
                #endregion
            }
            
            lbl_SkipCount.Text = CmdLine.IPara[5].ToString();
            lbl_FailAction.Text = CmdLine.IPara[6].ToString() + " - " + Enum.GetName(typeof(EFailAction), CmdLine.IPara[6]);
            lbl_UpdateAllLayouts.Text = (CmdLine.IPara[7] > 0).ToString();

            lbl_ShowSkipButton.Text = Convert.ToBoolean(CmdLine.IPara[11]).ToString();

            lbl_VrfyScore.Text = (CmdLine.DPara[7] * 100).ToString("f0");
        }

        private void UpdateImages()
        {
            try
            {
                pbox_Ref1Pat1.Image = TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No1].Image.ToBitmap();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                pbox_Ref1Pat2.Image = TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No1Pat2].Image.ToBitmap();
            }
            catch
            {
            }
            try
            {
                pbox_Ref2Pat1.Image = TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No2].Image.ToBitmap();
            }
            catch
            {
            }
            try
            {
                pbox_Ref2Pat2.Image = TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No2Pat2].Image.ToBitmap();
            }
            catch
            {
            }
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_Vision_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = CmdName;

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            TaskVision.SelectedCam = (ECamNo)CmdLine.IPara[1];
            TaskVision.LightingOn(TaskVision.LightRGB[CmdLine.ID]);

            if (CmdLine.IPara[0] < 1) CmdLine.IPara[0] = 1;
            if (CmdLine.IPara[0] > 2) CmdLine.IPara[0] = 2;

            if (CmdLine.DPara[0] == 0) CmdLine.DPara[0] = 0.85;
            if (CmdLine.DPara[1] == 0) CmdLine.DPara[1] = 2;
            if (CmdLine.DPara[2] == 0) CmdLine.DPara[2] = 5;

            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;//Settle Time

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };


            UpdateDisplay();
            UpdateImages();
            lbox_Info.Items.Clear();
        }

        private void frmDispProg_DoRef_Shown(object sender, EventArgs e)
        {

        }
        private void frmDispProg_DoRef_VisibleChanged(object sender, EventArgs e)
        {
        }

        #region Page Header
        private void lbl_RefID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", RefID", ref CmdLine.ID, 0, TaskVision.MAX_REF_TEMPLATE);
            UpdateDisplay();
            UpdateImages();
        }
        private void lbl_CameraID_Click(object sender, EventArgs e)
        {
            //GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[2], 0, TaskVision.MAX_CAMERA);
            //UpdateDisplay();
            //UpdateImages();
        }
        private void cbox_Use2RefPts_Click(object sender, EventArgs e)
        {
            if (cbox_Use2RefPts.Checked) CmdLine.IPara[0] = 2; else CmdLine.IPara[0] = 1;
            UpdateDisplay();
        }

        private void lbl_AlignType_Click(object sender, EventArgs e)
        {
            EAlignType E = EAlignType.Board;
            UC.AdjustExec(CmdName + ", Align Type", ref CmdLine.IPara[2], E);
            UpdateDisplay();
        }

        private void lbl_Mode_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[20] > 0) CmdLine.IPara[20] = 0;
            else
                CmdLine.IPara[20] = 1;
            UpdateDisplay();
        }
        #endregion 

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

        private void btn_Learn1_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];

            int Threshold = (int)CmdLine.DPara[5];
            TaskVision.TeachReference(CamID, CmdLine.ID, (int)EVisionRef.No1, ref Threshold);
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                TaskVision.flirCamera2[0].GrabCont();
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
            {
                TaskVision.genTLCamera[0].StartGrab();
            }
            CmdLine.DPara[5] = (double)Threshold;

            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
            UpdateImages();
        }
        private void btn_Learn1Pat2_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];
            int Threshold = (int)CmdLine.DPara[5];
            TaskVision.TeachReference(CamID, CmdLine.ID, (int)EVisionRef.No1Pat2, ref Threshold);
            CmdLine.DPara[5] = (double)Threshold;
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
            UpdateImages();
        }
        private void btn_Learn2_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];
            int Threshold = (int)CmdLine.DPara[5];
            TaskVision.TeachReference(CamID, CmdLine.ID, (int)EVisionRef.No2, ref Threshold);
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                TaskVision.flirCamera2[0].GrabCont();
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
            {
                TaskVision.genTLCamera[0].StartGrab();
            }
            CmdLine.DPara[5] = (double)Threshold;
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
            UpdateImages();
        }
        private void btn_Learn2Pat2_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];
            int Threshold = (int)CmdLine.DPara[5];
            TaskVision.TeachReference(CamID, CmdLine.ID, (int)EVisionRef.No2Pat2, ref Threshold);
            CmdLine.DPara[5] = (double)Threshold;
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
            UpdateImages();
        }

        private bool Match(string TestName, EVisionRef VisionRef, double XPos, double YPos, ref TaskVision.TDoRefData DoRefData)
        {
            int CamID = CmdLine.IPara[1];
            ERefPatType RefPatType = (ERefPatType)CmdLine.IPara[3];

            int t = Environment.TickCount;
            DoRefData = TaskVision.DoRef(CmdLine, (int)VisionRef);
            t = Environment.TickCount - t;

            lbox_Info.Items.Add(TestName + " Item: " + (char)9 +
                "Score" + (char)9 + "XOfst" + (char)9 + "YOfst" + (char)9 + "PatDiff");

            if (RefPatType > ERefPatType.Single)
            {
                lbox_Info.Items.Add(TestName + " Pat1: " + (char)9 +
                    (DoRefData.S1 * 100).ToString("F1") + (char)9 + DoRefData.X1.ToString("F3") + (char)9 + DoRefData.Y1.ToString("F3"));
                lbox_Info.Items.Add(TestName + " Pat2: " + (char)9 +
                    (DoRefData.S2 * 100).ToString("F1") + (char)9 + DoRefData.X2.ToString("F3") + (char)9 + DoRefData.Y2.ToString("F3"));
            }
            lbox_Info.Items.Add(TestName + " Ref: " + (char)9 +
                (DoRefData.SF * 100).ToString("F1") + (char)9 + DoRefData.XF.ToString("F3") + (char)9 + DoRefData.YF.ToString("F3") + (char)9 + DoRefData.PatDistDiff.ToString("F3"));

            if (DoRefData.RefResult != ERefResult.OK)
            {
                string str = TestName + " Result: " + (char)9 + "NG ";
                str = str + Enum.GetName(typeof(ERefResult), (int)DoRefData.RefResult);
                lbox_Info.Items.Add(str + (char)9 + t.ToString() + "ms");
            }
            else
                lbox_Info.Items.Add(TestName + " Result: " + (char)9 + "OK " + (char)9 + t.ToString() + "ms");

            lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;

            return (DoRefData.RefResult == ERefResult.OK);
        }

        private void btn_Test1_Click(object sender, EventArgs e)
        {
            if (GDefine.Status == EStatus.Ready)
                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.Station1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.Station1).Y + CmdLine.Y[0];

            //TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
            //lbox_Info.Items.Clear();
            //lbox_Info.BackColor = this.BackColor;
            //Match("Test1", EVisionRef.No1, GXYRef1.X, GXYRef1.Y, ref DoRefData);

            double ox = 0;
            double oy = 0;
            double s = 0;

            int t = Environment.TickCount;

            int Threshold = (int)CmdLine.DPara[5];
            if (GDefine.CameraType[CmdLine.IPara[1]] == GDefine.ECameraType.None)
            {
                if (!TaskVision.MatchReference(ref TaskVision.LoadedImageG, CmdLine.ID, (int)EVisionRef.No1, Threshold, out ox, out oy, out s)) return;
            }
            else
            {
                if (!TaskVision.MatchReference(CmdLine.IPara[1], CmdLine.ID, (int)EVisionRef.No1, Threshold, out ox, out oy, out s)) return;
                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.flirCamera2[0].GrabCont();
                }
                if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
                {
                    TaskVision.genTLCamera[0].StartGrab();
                }
            }

            t = Environment.TickCount - t;

            ox = ox * TaskVision.DistPerPixelX[CmdLine.IPara[1]];
            oy = oy * TaskVision.DistPerPixelY[CmdLine.IPara[1]];

            lbox_Info.Items.Clear();

            lbox_Info.Items.Add("" + (char)9 + "Score" + (char)9 + "XOfst" + (char)9 + "YOfst" + (char)9 + "Time");
            lbox_Info.Items.Add("" + (char)9 + (s * 100).ToString("F1") + (char)9 + ox.ToString("F3") + (char)9 + oy.ToString("F3") + (char)9 + t.ToString() + "ms");

            lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;
        }
        private void btn_Test2_Click(object sender, EventArgs e)
        {
            if (GDefine.Status == EStatus.Ready)
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.Station1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.Station1).Y + CmdLine.Y[0]; 
            double RelRef2X = CmdLine.X[1] - CmdLine.X[0];
            double RelRef2Y = CmdLine.Y[1] - CmdLine.Y[0];
            TPos2 GXYRef2 = new TPos2();
            GXYRef2.X = GXYRef1.X + RelRef2X;
            GXYRef2.Y = GXYRef1.Y + RelRef2Y;

            //TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
            //lbox_Info.Items.Clear();
            //lbox_Info.BackColor = this.BackColor;

            ////TaskVision.Pause = true;
            //Match("Test2", EVisionRef.No2, GXYRef2.X, GXYRef2.Y, ref DoRefData);
            ////TaskVision.Pause = false;

            //if (DoRefData.RefResult != ERefResult.OK)
            //    lbox_Info.BackColor = Color.Red;
            
            //if (DoRefData.RefResult != ERefResult.OK)
            //    lbox_Info.BackColor = Color.Red;

            double ox = 0;
            double oy = 0;
            double s = 0;

            int t = Environment.TickCount;

            int Threshold = (int)CmdLine.DPara[5];
            if (GDefine.CameraType[CmdLine.IPara[1]] == GDefine.ECameraType.None)
            {
                if (!TaskVision.MatchReference(ref TaskVision.LoadedImageG, CmdLine.ID, (int)EVisionRef.No2, Threshold, out ox, out oy, out s)) return;
            }
            else
            {
                if (!TaskVision.MatchReference(CmdLine.IPara[1], CmdLine.ID, (int)EVisionRef.No2, Threshold, out ox, out oy, out s)) return;

                if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
                {
                    TaskVision.flirCamera2[0].GrabCont();
                }
                if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
                {
                    TaskVision.genTLCamera[0].StartGrab();
                }
            }

            t = Environment.TickCount - t;

            ox = ox * TaskVision.DistPerPixelX[CmdLine.IPara[1]];
            oy = oy * TaskVision.DistPerPixelY[CmdLine.IPara[1]];

            lbox_Info.Items.Clear();

            lbox_Info.Items.Add("" + (char)9 + "Score" + (char)9 + "XOfst" + (char)9 + "YOfst" + (char)9 + "Time");
            lbox_Info.Items.Add("" + (char)9 + (s * 100).ToString("F1") + (char)9 + ox.ToString("F3") + (char)9 + oy.ToString("F3") + (char)9 + t.ToString() + "ms");

            lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;
        }

        private void btn_Align1_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;
 
            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.Station1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.Station1).Y + CmdLine.Y[0];

            TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
            lbox_Info.Items.Clear();
            lbox_Info.BackColor = this.BackColor;

            if (!Match("Align1", EVisionRef.No1, GXYRef1.X, GXYRef1.Y, ref DoRefData)) return;

            if (DoRefData.RefResult != ERefResult.OK)
                lbox_Info.BackColor = Color.Red;

            double X = TaskGantry.GXPos() + DoRefData.XF;
            double Y = TaskGantry.GYPos() + DoRefData.YF;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_Align2_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.Station1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.Station1).Y + CmdLine.Y[0]; 
            double RelRef2X = CmdLine.X[1] - CmdLine.X[0];
            double RelRef2Y = CmdLine.Y[1] - CmdLine.Y[0];
            TPos2 GXYRef2 = new TPos2();
            GXYRef2.X = GXYRef1.X + RelRef2X;
            GXYRef2.Y = GXYRef1.Y + RelRef2Y;

            TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
            lbox_Info.Items.Clear();
            lbox_Info.BackColor = this.BackColor;

            //TaskVision.Pause = true;
            if (!Match("Align2", EVisionRef.No2, GXYRef2.X, GXYRef2.Y, ref DoRefData)) return;
            //TaskVision.Pause = false;

            if (DoRefData.RefResult != ERefResult.OK)
                lbox_Info.BackColor = Color.Red;

            double X = TaskGantry.GXPos() + DoRefData.XF;
            double Y = TaskGantry.GYPos() + DoRefData.YF;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_TestAll_Click(object sender, EventArgs e)
        {
            lbox_Info.Items.Clear();
            lbox_Info.BackColor = this.BackColor;

            //string EMsg = "DoRefTestAll";
            int t = GDefine.GetTickCount();

            //if (!TaskDisp.TaskMoveGZZ2Up()) goto _Fail;
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.Station1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.Station1).Y + CmdLine.Y[0];
            TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
            GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;
            if (!TaskDisp.GotoXYPos(GXYRef1, GX2Y2)) goto _Fail;

            int SettleTime = CmdLine.IPara[4];
            int t1 = GDefine.GetTickCount() + SettleTime;
            while (GDefine.GetTickCount() <= t1) { Thread.Sleep(1); }

            TaskVision.TDoRefData DoRef1Data = new TaskVision.TDoRefData();
            if (!Match("Test All 1", EVisionRef.No1, GXYRef1.X, GXYRef1.Y, ref DoRef1Data)) goto _Fail;

            double RelRef2X = CmdLine.X[1] - CmdLine.X[0];
            double RelRef2Y = CmdLine.Y[1] - CmdLine.Y[0];
            TPos2 GXYRef2 = new TPos2();
            GXYRef2.X = GXYRef1.X + RelRef2X;
            GXYRef2.Y = GXYRef1.Y + RelRef2Y;
            if (!TaskDisp.GotoXYPos(GXYRef2, GX2Y2)) goto _Fail;

            int t2 = GDefine.GetTickCount() + SettleTime;
            while (GDefine.GetTickCount() <= t2) { Thread.Sleep(1); }

            TaskVision.TDoRefData DoRef2Data = new TaskVision.TDoRefData();
            if (!Match("Test All 2", EVisionRef.No2, GXYRef2.X, GXYRef2.Y, ref DoRef2Data)) goto _Fail;

            t = GDefine.GetTickCount() - t;

            #region Compute RefDistOfst
            double OriRef1X1 = GXYRef1.X + TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No1].PatternRoi.X;
            double OriRef1Y1 = GXYRef1.Y + TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No1].PatternRoi.Y;
            double OriRef2X1 = GXYRef2.X + TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No2].PatternRoi.X;
            double OriRef2Y1 = GXYRef2.Y + TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No2].PatternRoi.Y;

            Polar OriRef1 = new Polar(OriRef1X1, OriRef1Y1);
            Polar OriRef2 = new Polar(OriRef2X1, OriRef2Y1);
            double OriLength = Math.Abs(OriRef2.R - OriRef1.R);

            Polar NewRef1 = new Polar(OriRef1X1 + DoRef1Data.XF, OriRef1Y1 + DoRef1Data.YF);
            Polar NewRef2 = new Polar(OriRef2X1 + DoRef2Data.XF, OriRef2Y1 + DoRef2Data.YF);
            double NewLength = Math.Abs(NewRef1.R - NewRef2.R);

            double d_RefDistOfst = Math.Abs(NewLength - OriLength);
            #endregion

            #region Compute Angle
            Point2D Pt1 = new Point2D(GXYRef1.X, GXYRef1.Y);
            Point2D Pt2 = new Point2D(GXYRef2.X, GXYRef2.Y);
            Point2D nPt1 = new Point2D(GXYRef1.X + DoRef1Data.XF, GXYRef1.Y + DoRef1Data.YF);
            Point2D nPt2 = new Point2D(GXYRef2.X + DoRef2Data.XF, GXYRef2.Y + DoRef2Data.YF);
            double a = nPt2.Angle(nPt1, Pt1, Pt2);
            if (a > Math.PI) a = a - (Math.PI * 2);
            double d_AngleOfst_Deg = a * 180 / Math.PI;
            #endregion

            string TestName = "Test All";

            lbox_Info.Items.Add(TestName + (char)9 +
                "Score" + (char)9 + "XOfst" + (char)9 + "YOfst" + (char)9 +
                "RefDiff" + (char)9 + "AngleDiff");
            lbox_Info.Items.Add(TestName + (char)9 +
                (Math.Min(DoRef1Data.SF, DoRef2Data.SF) * 100).ToString("F1") + (char)9 + DoRef1Data.XF.ToString("F3") + (char)9 + DoRef1Data.YF.ToString("F3") + (char)9 +
                d_RefDistOfst.ToString("F3") + (char)9 + d_AngleOfst_Deg.ToString("F3"));

            ERefResult RefResult = ERefResult.FailOther;
            if (Math.Abs(d_AngleOfst_Deg) > CmdLine.DPara[2])
            {
                RefResult = ERefResult.FailAngle;
                string str = TestName + (char)9 + "Result:" + (char)9 + "NG ";
                str = str + Enum.GetName(typeof(ERefResult), (int)RefResult);
                lbox_Info.Items.Add(str + (char)9 + t.ToString() + "ms");
                goto _Fail;
            }

            if (CmdLine.DPara[3] != 0 && Math.Abs(d_RefDistOfst) > CmdLine.DPara[3])
            {
                RefResult = ERefResult.FailRefDistTol;
                string str = TestName + (char)9 + "Result:" + (char)9 + "NG ";
                str = str + Enum.GetName(typeof(ERefResult), (int)RefResult);
                lbox_Info.Items.Add(str + (char)9 + t.ToString() + "ms");
                goto _Fail;
            }

            lbox_Info.Items.Add(TestName + (char)9 + "Result:" + (char)9 + "OK" + (char)9 + t.ToString() + "ms");

        //_End:
            lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;
            return;

        _Fail:
            lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;
            lbox_Info.BackColor = Color.Red;
        }

        private void lbl_MinScore_Click(object sender, EventArgs e)
        {
            int i = (int)(CmdLine.DPara[0] * 100);
            UC.AdjustExec(CmdName + ", Min Score (%)", ref i, 1, 99);
            CmdLine.DPara[0] = (double)i / 100;
            UpdateDisplay();
        }

        private void lbl_XYTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", XY Tol (mm)", ref CmdLine.DPara[1], 0, 5);
            UpdateDisplay();
        }

        private void lbl_AngleTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Angle Tol (mm)", ref CmdLine.DPara[2], 0, 10);
            UpdateDisplay();
        }

        private void lbl_RefDistTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Ref Dist Tol (mm)", ref CmdLine.DPara[3], 0, 1);
            UpdateDisplay();
        }

        //private void lbl_PatDistTol_Click(object sender, EventArgs e)
        //{
        //    UC.AdjustExec(CmdName + ", Pat Dist Tol (mm)", ref CmdLine.DPara[4], 0, 1);
        //    UpdateDisplay();
        //}

        private void lbl_PatternType_Click(object sender, EventArgs e)
        {
            ERefPatType E = ERefPatType.Single;
            UC.AdjustExec(CmdName + ", Pattern Type", ref CmdLine.IPara[3], E);
            UpdateDisplay();
        }

        private void pbox_Ref2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_img_Ref1Pat2_Click(object sender, EventArgs e)
        {

        }

        #region Settings
        private void lbl_StartV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Start Speed (mm/s)", ref CmdLine.DPara[10], 0.001, 50);
            UpdateDisplay();
        }
        private void lbl_DriveV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Drive Speed (mm/s)", ref CmdLine.DPara[11], 0, 300);
            UpdateDisplay();
        }
        private void lbl_Accel_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Accel (mm/s2)", ref CmdLine.DPara[12], 0, 10000);
            UpdateDisplay();
        }
        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Settle Time (ms)", ref CmdLine.IPara[4], 0, 500);
            UpdateDisplay();
        }
        #endregion

        private void lbl_SkipCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Skip Count", ref CmdLine.IPara[5], 0, 99);
            UpdateDisplay();
        }

        private void lbl_FailAction_Click(object sender, EventArgs e)
        {
            EFailAction E = EFailAction.Normal;
            UC.AdjustExec(CmdName + ", Fail Action", ref CmdLine.IPara[6], E);
            UpdateDisplay();
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

        private void lbl_AcceptTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Accept Tol (mm)", ref CmdLine.DPara[6], 0, 1);
            UpdateDisplay();
        }

        private void frm_DispCore_DispProg_DoRef_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void lbl_UpdateAllLayout_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Update All Layouts", ref CmdLine.IPara[7], 0, 1);
            UpdateDisplay();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ShowSkipButton_Click(object sender, EventArgs e)
        {
            bool b = CmdLine.IPara[11] > 0;
            UC.AdjustExec(CmdName + ", Show Skip Button", ref b);
            CmdLine.IPara[11] = b ? 1 : 0;
            UpdateDisplay();
        }

        private void lbl_VrfyScore_Click(object sender, EventArgs e)
        {
            int i = (int)(CmdLine.DPara[7] * 100);
            UC.AdjustExec(CmdName + ", Vrfy Score (%)", ref i, 0, 99);
            CmdLine.DPara[7] = (double)i / 100;
            UpdateDisplay();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
