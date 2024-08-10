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

/*todo
use temp values to be able to cancel
*/

namespace DispCore
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

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            AppLanguage.Func.SetComponent(this);
        }

        private void UpdateDisplay()
        {
            lbl_RefID.Text = CmdLine.ID.ToString();
            lbl_CameraID.Text = CmdLine.IPara[1].ToString();
            
            cbox_Use2RefPts.Checked = (CmdLine.IPara[0] == 2);
            lbl_PatternType.Text = CmdLine.IPara[3].ToString() + " - " + Enum.GetName(typeof(ERefPatType), CmdLine.IPara[3]);

            lbl_AlignType.Text = CmdLine.IPara[2].ToString() + " - " + Enum.GetName(typeof(EAlignType), CmdLine.IPara[2]);

            pnl_Ref1Pat2.Visible = CmdLine.IPara[3] > 0;
            pnl_Ref2Pat2.Visible = CmdLine.IPara[3] > 0;

            gbox_Ref2.Visible = (CmdLine.IPara[0] == 2);
            //pbox_Ref2.Visible = (CmdLine.IPara[0] == 2);
            btn_Learn2.Visible = (CmdLine.IPara[0] == 2);

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");
            lbl_X2Y2.Text = CmdLine.X[1].ToString("F3") + ", " + CmdLine.Y[1].ToString("F3");

            lbl_MinScore.Text = (CmdLine.DPara[0] * 100).ToString("F0");
            lbl_XYTol.Text = CmdLine.DPara[1].ToString("F3");
            lbl_AngleTol.Text = CmdLine.DPara[2].ToString("F3");
            lbl_PatDistTol.Text = CmdLine.DPara[4].ToString("F3");
            lbl_RefDistTol.Text = CmdLine.DPara[3].ToString("F3");

            pnl_PatDistTol.Visible = CmdLine.IPara[3] > 0;
            pnl_RefTol.Visible = CmdLine.IPara[0] == 2;

            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
            lbl_SkipCount.Text = CmdLine.IPara[5].ToString();
            lbl_FailAction.Text = CmdLine.IPara[6].ToString() + " - " + Enum.GetName(typeof(EFailAction), CmdLine.IPara[6]);

            lbl_NewLine.Text = (CmdLine.IPara[9] > 0).ToString();
            lbl_AddLogicalX.Text = CmdLine.IPara[10].ToString();
            lbl_AddLogicalY.Text = CmdLine.IPara[11].ToString();
            lbl_AddActualX.Text = CmdLine.IPara[12].ToString();
            lbl_AddActualY.Text = CmdLine.IPara[13].ToString();
            lbl_AddOfstX.Text = CmdLine.IPara[14].ToString();
            lbl_AddOfstY.Text = CmdLine.IPara[15].ToString();
        }

        private void UpdateImages()
        {
            try
            {
                pbox_Ref1Pat1.Image = TaskVision.RefTemplate[CmdLine.ID, (int)EVisionRef.No1].Image.ToBitmap();
            }
            catch
            {
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

        private void frmDispProg_Vision_Load(object sender, EventArgs e)
        {
            this.Text = "Command - DO_REF";

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            TaskVision.SelectedCam = (ECamNo)CmdLine.IPara[1];
            TaskVision.LightingOn(TaskVision.LightRGB[CmdLine.ID]);

            if (CmdLine.IPara[0] < 1) CmdLine.IPara[0] = 1;
            if (CmdLine.IPara[0] > 2) CmdLine.IPara[0] = 2;

            if (CmdLine.DPara[0] == 0) CmdLine.DPara[0] = 0.85;
            if (CmdLine.DPara[1] == 0) CmdLine.DPara[1] = 2;
            if (CmdLine.DPara[2] == 0) CmdLine.DPara[2] = 5;

            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;//Settle Time

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
            GDefine.uc.UserAdjustExecute(ref CmdLine.ID, 0, TaskVision.MAX_REF_TEMPLATE);
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
            GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[2], 0, 6);
            UpdateDisplay();
        }
        #endregion 

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //if (CmdLine.IPara[0] > 0)
            //{
            //TaskVision.RefTemplate[CmdLine.ID + 1] = TaskVision.RefTemplate[CmdLine.ID].C
            //}

            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            frm_DispCore_DispProg.Done = true;
            Close();
            //Visible = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            frm_DispCore_DispProg.Done = true;
            Close();
            //Visible = false;
        }

        private void btn_SetPt1Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            UpdateDisplay();
        }

        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetPt2Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            CmdLine.X[1] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            UpdateDisplay();
        }

        private void btn_GotoPt2Pos_Click(object sender, EventArgs e)
        {
            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_Learn1_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];
            TaskVision.TeachReference(CamID, CmdLine.ID, (int)EVisionRef.No1);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
            UpdateImages();
        }
        private void btn_Learn1Pat2_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];
            TaskVision.TeachReference(CamID, CmdLine.ID, (int)EVisionRef.No1Pat2);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
            UpdateImages();
        }
        private void btn_Learn2_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];
            TaskVision.TeachReference(CamID, CmdLine.ID, (int)EVisionRef.No2);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
            UpdateImages();
        }
        private void btn_Learn2Pat2_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];
            TaskVision.TeachReference(CamID, CmdLine.ID, (int)EVisionRef.No2Pat2);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
            UpdateImages();
        }

        private bool Match(string TestName, EVisionRef VisionRef, double XPos, double YPos, ref TaskVision.TDoRefData DoRefData)
        {
            #region
            // string EMsg = "DoRef" + TestName;

            // int CamID = CmdLine.IPara[1];
            // ERefPatType RefPatType = (ERefPatType)CmdLine.IPara[3];

            // string s_FailMode = "";

            // double X = 0;
            // double Y = 0;
            // double S = 0;

            // int t = Environment.TickCount;

            // try
            // {
            //     TaskVision.MatchReference(CamID, CmdLine.ID, (int)VisionRef, out X, out Y, out S);
            //     t = Environment.TickCount - t;
            // }
            // catch (Exception Ex)
            // {
            //     EMsg = EMsg + (char)13 + Ex.Message.ToString();
            //     ErrCode.ShowErrOKNoAssist(ErrCode.UNKNOWN_EX_ERR, EMsg);
            // }

            // double vX1 = X * TaskVision.DistPerPixelX[CamID];
            // double vY1 = Y * TaskVision.DistPerPixelY[CamID];
            // double vS1 = S;

            // lbox_Info.Items.Add(TestName + "Item: " + (char)9 +
            //     "Score" + (char)9 + "XOfst" + (char)9 + "YOfst" + (char)9 + "Time");
            // lbox_Info.Items.Add(TestName + "Pat1: " + (char)9 +
            //     (vS1 * 100).ToString("F1") + (char)9 + vX1.ToString("F3") + (char)9 + vY1.ToString("F3"));

            // double vX2 = vX1;
            // double vY2 = vY1;
            // double vS2 = vS1;

            // double vXF = vX1;
            // double vYF = vY1;
            // double vSF = vS1;
            // if (RefPatType > ERefPatType.Single)
            // {
            //     try
            //     {
            //         TaskVision.MatchReference(CamID, CmdLine.ID, (int)VisionRefPat2, out X, out Y, out S);
            //         t = Environment.TickCount - t;
            //     }
            //     catch (Exception Ex)
            //     {
            //         EMsg = EMsg + (char)13 + Ex.Message.ToString();
            //         ErrCode.ShowErrOKNoAssist(ErrCode.UNKNOWN_EX_ERR, EMsg);
            //     }

            //     vX2 = X * TaskVision.DistPerPixelX[CamID];
            //     vY2 = Y * TaskVision.DistPerPixelY[CamID];
            //     vS2 = S;
            //     lbox_Info.Items.Add(TestName + "Pat2: " + (char)9 +
            //         (vS2 * 100).ToString("F1") + (char)9 + vX1.ToString("F3") + (char)9 + vY1.ToString("F3"));
            //}

            // switch (RefPatType)
            // {
            //     default://case ERefPatType.One:
            //         {
            //             if (vS1 < CmdLine.DPara[0])
            //             {
            //                 s_FailMode = "(Fail Min Score)";
            //                 goto _End;
            //             }

            //             if (Math.Abs(vX1) > CmdLine.DPara[1] || Math.Abs(vY1) > CmdLine.DPara[1])
            //             {
            //                 s_FailMode = "(Fail XY Tol)";
            //                 goto _End;
            //             }

            //             vXF = vX1;
            //             vYF = vY1;
            //             vSF = vS1;

            //             break;
            //         }
            //     case ERefPatType.AverageOfTwo:
            //         {
            //             if (vS1 < CmdLine.DPara[0] && vS2 < CmdLine.DPara[0])
            //             {
            //                 s_FailMode = "(Fail Min Score)";
            //                 goto _End;
            //             }

            //             if ((Math.Abs(vX1) > CmdLine.DPara[1] || Math.Abs(vY1) > CmdLine.DPara[1]) &&
            //                 (Math.Abs(vX2) > CmdLine.DPara[1] || Math.Abs(vY2) > CmdLine.DPara[1]))
            //             {
            //                 s_FailMode = "(Fail XY Tol)";
            //                 goto _End;
            //             }

            //             int Pat1X = TaskVision.RefTemplate[CmdLine.ID, (int)VisionRef].PatternRoi.X;
            //             int Pat1Y = TaskVision.RefTemplate[CmdLine.ID, (int)VisionRef].PatternRoi.Y;
            //             int Pat2X = TaskVision.RefTemplate[CmdLine.ID, (int)VisionRefPat2].PatternRoi.X;
            //             int Pat2Y = TaskVision.RefTemplate[CmdLine.ID, (int)VisionRefPat2].PatternRoi.Y;

            //             NSW.Net.Polar OriL = new Polar(new Point2D(Pat1X, Pat1Y), new Point2D(Pat2X, Pat2Y));
            //             NSW.Net.Polar NewL = new Polar(new Point2D(vX1, vY1), new Point2D(vX2, vY2));

            //             if (Math.Abs(NewL.R - OriL.R) > CmdLine.DPara[4])
            //             {
            //                 s_FailMode = "(Fail Pat Dist Tol)";
            //                 goto _End;
            //             }

            //             vXF = (vX1 + vX2) / 2;
            //             vYF = (vY1 + vY2) / 2;
            //             vSF = (vS1 + vS2) / 2;

            //             break;
            //         }
            //     case ERefPatType.BestOfTwo:
            //         {
            //             if (vS1 < CmdLine.DPara[0])
            //             {
            //                 s_FailMode = "(Pat1 Fail Min Score)";
            //                 goto _End;
            //             } 
            //             if (Math.Abs(vX1) > CmdLine.DPara[1] || Math.Abs(vY1) > CmdLine.DPara[1])
            //             {
            //                 s_FailMode = "(Fail XY Tol)";
            //                 goto _End;
            //             }

            //             if (vS2 > vS1)
            //             {
            //                 vXF = vX2;
            //                 vYF = vY2;
            //                 vSF = vS2;
            //             }

            //             break;
            //         }
            // }
            // _End:

            // if (s_FailMode.Length > 0)
            // {
            //     string str = TestName + " Result: NG ";
            //     //if (S < CmdLine.DPara[0])
            //     //    str = str + "(Fail Min Score)";
            //     //if (Math.Abs(vX1) > CmdLine.DPara[1] || Math.Abs(vY1) > CmdLine.DPara[1])
            //     //    str = str + "(Fail XY Tol)";
            //     str = str + s_FailMode;
            //     lbox_Info.Items.Add(str + " " + t.ToString() + "ms");
            // }
            // else
            //     lbox_Info.Items.Add(TestName + " Result: OK" + " " + t.ToString() + "ms");

            // lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;

            // XOfst = vXF;
            // YOfst = vYF;
            // Score = vSF; 
            // return (Score >= CmdLine.DPara[0]);
            #endregion
            
            int CamID = CmdLine.IPara[1];
            ERefPatType RefPatType = (ERefPatType)CmdLine.IPara[3];
            //ERefResult RefResult = ERefResult.OK;

            int t = Environment.TickCount;
            //TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
            //DoRefData = TaskVision.DoRef(CmdLine, (int)VisionRef);
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
            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.St1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.St1).Y + CmdLine.Y[0];

            TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
            lbox_Info.Items.Clear();
            lbox_Info.BackColor = this.BackColor;

            //TaskVision.Pause = true;
            Match("Test1", EVisionRef.No1, GXYRef1.X, GXYRef1.Y, ref DoRefData);
            //TaskVision.Pause = false;
        }
        private void btn_Test2_Click(object sender, EventArgs e)
        {
            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.St1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.St1).Y + CmdLine.Y[0]; 
            double RelRef2X = CmdLine.X[1] - CmdLine.X[0];
            double RelRef2Y = CmdLine.Y[1] - CmdLine.Y[0];
            TPos2 GXYRef2 = new TPos2();
            GXYRef2.X = GXYRef1.X + RelRef2X;
            GXYRef2.Y = GXYRef1.Y + RelRef2Y;

            TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
            lbox_Info.Items.Clear();
            lbox_Info.BackColor = this.BackColor;

            //TaskVision.Pause = true;
            Match("Test2", EVisionRef.No2, GXYRef2.X, GXYRef2.Y, ref DoRefData);
            //TaskVision.Pause = false;

            if (DoRefData.RefResult != ERefResult.OK)
                lbox_Info.BackColor = Color.Red;
            
            if (DoRefData.RefResult != ERefResult.OK)
                lbox_Info.BackColor = Color.Red;
        }

        private void btn_Align1_Click(object sender, EventArgs e)
        {
            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.St1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.St1).Y + CmdLine.Y[0];

            TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
            lbox_Info.Items.Clear();
            lbox_Info.BackColor = this.BackColor;

            //TaskVision.Pause = true;
            if (!Match("Align1", EVisionRef.No1, GXYRef1.X, GXYRef1.Y, ref DoRefData)) return;
            //TaskVision.Pause = false;

            if (DoRefData.RefResult != ERefResult.OK)
                lbox_Info.BackColor = Color.Red;

            double X = TaskGantry.GXPos() + DoRefData.XF;
            double Y = TaskGantry.GYPos() + DoRefData.YF;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }
        private void btn_Align2_Click(object sender, EventArgs e)
        {
            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.St1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.St1).Y + CmdLine.Y[0]; 
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

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_TestAll_Click(object sender, EventArgs e)
        {
            #region
            //string EMsg = "DoRefTestAll";

            //int CamID = CmdLine.IPara[1];

            //double RelRef2X = CmdLine.X[1] - CmdLine.X[0];
            //double RelRef2Y = CmdLine.Y[1] - CmdLine.Y[0];

            //int i_IDIndex = 0;
            //int i_IDCount = 1;
            //if (CmdLine.IPara[1] > 0) i_IDCount = 2;

            //try
            //{
            //    while (i_IDIndex < i_IDCount)
            //    {
            //        int t = GDefine.GetTickCount();

            //        TPos2 GXY1 = new TPos2();

            //        if (i_IDIndex == 0)
            //        {
            //            GXY1.X = DispProg.Origin(ERunStationNo.St1).X + CmdLine.X[0];
            //            GXY1.Y = DispProg.Origin(ERunStationNo.St1).Y + CmdLine.Y[0];
            //        }
            //        else
            //        {
            //            GXY1.X = DispProg.Origin(ERunStationNo.St1).X + CmdLine.X[2];
            //            GXY1.Y = DispProg.Origin(ERunStationNo.St1).Y + CmdLine.Y[2];
            //        }

            //        if (!TaskDisp.TaskMoveGZZ2Up()) return;

            //        TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
            //        GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_MinDistX;
            //        TaskDisp.GotoXYPos(GXY1, GX2Y2);

            //        int t1 = GDefine.GetTickCount() + TaskVision.Vision_SettleTime;
            //        while (GDefine.GetTickCount() <= t1) { Thread.Sleep(1); }

            //        double vX1 = 0;
            //        double vY1 = 0;
            //        double vS1 = 0;
            //        TaskVision.MatchReference(CamID, CmdLine.ID, (int)EVisionRef.No1, out vX1, out vY1, out vS1);
            //        vX1 = vX1 * TaskVision.DistPerPixelX[CamID];
            //        vY1 = vY1 * TaskVision.DistPerPixelY[CamID];

            //        double X2 = GXY1.X + RelRef2X;
            //        double Y2 = GXY1.Y + RelRef2Y;

            //        double vX2 = 0;
            //        double vY2 = 0;
            //        double vS2 = 1;
            //        double d_AngleDeg = 0;
            //        if (CmdLine.IPara[0] == 2)
            //        {
            //            if (!TaskGantry.SetMotionParamGXY()) return;
            //            if (!TaskGantry.MoveAbsGXY(X2, Y2)) return;

            //            t1 = GDefine.GetTickCount() + TaskVision.Vision_SettleTime;
            //            while (GDefine.GetTickCount() <= t1) { Thread.Sleep(1); }

            //            TaskVision.MatchReference(CamID, CmdLine.ID, (int)EVisionRef.No2, out vX2, out vY2, out vS2);
            //            vX2 = vX2 * TaskVision.DistPerPixelX[CamID];
            //            vY2 = vY2 * TaskVision.DistPerPixelY[CamID];

            //            Point2D Pt1 = new Point2D(GXY1.X, GXY1.Y);
            //            Point2D Pt2 = new Point2D(X2, Y2);
            //            Point2D nPt1 = new Point2D(GXY1.X + vX1, GXY1.Y + vY1);
            //            Point2D nPt2 = new Point2D(X2 + vX2, Y2 + vY2);
            //            double a = nPt2.Angle(nPt1, Pt1, Pt2);
            //            if (a > Math.PI) a = a - (Math.PI * 2);
            //            d_AngleDeg = a * 180 / Math.PI;
            //        }
            //        t = GDefine.GetTickCount() - t;

            //        string s_TestName = "TestAll ID" + (CmdLine.ID + i_IDIndex).ToString();

            //        string str = s_TestName + " ";                     
            //        if (Math.Min(vS1, vS2) < CmdLine.DPara[0] ||
            //            Math.Abs(vX1) > CmdLine.DPara[1] || Math.Abs(vY1) > CmdLine.DPara[1] || 
            //            Math.Abs(d_AngleDeg) > CmdLine.DPara[2])
            //        {
            //            str = str + "Result: NG ";
            //            if (Math.Min(vS1, vS2) < CmdLine.DPara[0])
            //                str = str + "(Fail Min Score)";
            //            if (Math.Abs(vX1) > CmdLine.DPara[1] || Math.Abs(vY1) > CmdLine.DPara[1])
            //                str = str + "(Fail XY Tol)";
            //            if (Math.Abs(d_AngleDeg) > CmdLine.DPara[2])
            //                str = str + "(Fail Angle Tol)";
            //        }
            //        else
            //            str = str + "Result: OK";
            //        lbox_Info.Items.Add(str);

            //        str = s_TestName + " Data:"  + (char)9;
            //        str = str + "Score1" + (char)9;
            //        if (CmdLine.IPara[0] == 2)
            //            str = str + "Score2" + (char)9;
            //        str = str + "XOfst" + (char)9 + "YOfst" + (char)9;
            //        if (CmdLine.IPara[0] == 2)
            //            str = str + "Angle" + (char)9;
            //        str = str + "Time";
            //        lbox_Info.Items.Add(str);

            //        str = s_TestName + " Data:"  + (char)9;
            //        str = str + (vS1 * 100).ToString("F1") + (char)9;
            //        if (CmdLine.IPara[0] == 2)
            //            str = str + (vS2 * 100).ToString("F1") + (char)9;
            //        str = str + vX1.ToString("F3") + (char)9 +vY1.ToString("F3") + (char)9;
            //        if (CmdLine.IPara[0] == 2)
            //            str = str + d_AngleDeg.ToString("F3") + (char)9;
            //        str = str + t.ToString();
            //        lbox_Info.Items.Add(str);

            //        //lbl_OfstXY.Text = (vX1).ToString("F3") + ", " + (vY1).ToString("F3");
            //        //if (Math.Abs(vX1) > CmdLine.DPara[1] || Math.Abs(vY1) > CmdLine.DPara[1])
            //        //    lbl_OfstXY.ForeColor = Color.Red;
            //        //else
            //        //    lbl_OfstXY.ForeColor = Color.Green;
            //        //lbl_Score.Text = "Min(" + (vS1 * 100).ToString("F1") + "," + (vS2 * 100).ToString("F1") + ")=" + (Math.Min(vS1, vS2) * 100).ToString("F1");
            //        //if (Math.Min(vS1, vS2) < CmdLine.DPara[0])
            //        //{
            //        //    lbl_Score.ForeColor = Color.Red;
            //        //}
            //        //else
            //        //    lbl_Score.ForeColor = Color.Green;

            //        //Point2D Pt1 = new Point2D(X1, Y1);
            //        //Point2D Pt2 = new Point2D(X2, Y2);
            //        //Point2D nPt1 = new Point2D(X1 + vX1, Y1 + vY1);
            //        //Point2D nPt2 = new Point2D(X2 + vX2, Y2 + vY2);

            //        //double a = nPt2.Angle(nPt1, Pt1, Pt2);
            //        //if (a > Math.PI) a = a - (Math.PI * 2);
            //        //lbl_Angle.Text = (a * 180 / Math.PI).ToString("F3");
            //        //if (Math.Abs(a * 180 / Math.PI) > CmdLine.DPara[2])
            //        //    lbl_Angle.ForeColor = Color.Red;
            //        //else
            //        //    lbl_Angle.ForeColor = Color.Green;

            //        i_IDIndex++;
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    EMsg = EMsg + (char)13 + Ex.Message.ToString();
            //    //frm_DispCore_Msg.Page.ShowMsg(EMsg, frm_DispCore_Msg.TMsgBtn.smbAlmClr | frm_DispCore_Msg.TMsgBtn.smbOK);
            //    ErrCode.ShowErrOKNoAssist(ErrCode.UNKNOWN_EX_ERR, EMsg);
            //}

            ////lbl_Time.Text = (GDefine.GetTickCount() - t).ToString();
            //lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;
            #endregion

            lbox_Info.Items.Clear();
            lbox_Info.BackColor = this.BackColor;

            //string EMsg = "DoRefTestAll";
            int t = GDefine.GetTickCount();

            if (!TaskDisp.TaskMoveGZZ2Up()) goto _Fail;

            TPos2 GXYRef1 = new TPos2();
            GXYRef1.X = DispProg.Origin(ERunStationNo.St1).X + CmdLine.X[0];
            GXYRef1.Y = DispProg.Origin(ERunStationNo.St1).Y + CmdLine.Y[0];
            TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
            GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_MinDistX;
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

            if (Math.Abs(d_RefDistOfst) > CmdLine.DPara[3])
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
            GDefine.uc.UserAdjustExecute(ref i, 1, 99);
            CmdLine.DPara[0] = (double)i / 100;
            UpdateDisplay();
        }

        private void lbl_XYTol_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[1], 0, 5);
            UpdateDisplay();
        }

        private void lbl_AngleTol_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[2], 0, 5);
            UpdateDisplay();
        }

        private void lbl_RefDistTol_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[3], 0, 1);
            UpdateDisplay();
        }

        private void lbl_PatDistTol_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.DPara[4], 0, 1);
            UpdateDisplay();
        }

        private void lbl_PatternType_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[3], 0, Enum.GetNames(typeof(ERefPatType)).Length);
            UpdateDisplay();
        }

        private void pbox_Ref2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_img_Ref1Pat2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Settle Time", ref CmdLine.IPara[4], 0, 500);
            UpdateDisplay();
        }

        private void lbl_SkipCount_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Skip Count", ref CmdLine.IPara[5], 0, 50);
            UpdateDisplay();
        }

        private void lbl_FailAction_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Fail Action", ref CmdLine.IPara[6], 0, Enum.GetNames(typeof(EFailAction)).Length);
            UpdateDisplay();
        }

        private void lbl_NewLine_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("New Line", ref CmdLine.IPara[9], 0, 1);
            UpdateDisplay();
        }

        private void lbl_AddLogicalX_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Logical X", ref CmdLine.IPara[10], 0, 15);
            UpdateDisplay();
        }

        private void lbl_AddLogicalY_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Logical Y", ref CmdLine.IPara[11], -1, 15);
            UpdateDisplay();
        }

        private void lbl_AddActualX_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Actual X", ref CmdLine.IPara[12], -1, 15);
            UpdateDisplay();
        }

        private void lbl_AddActualY_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Actual Y", ref CmdLine.IPara[13], -1, 15);
            UpdateDisplay();
        }

        private void lbl_AddOfstX_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Ofst X", ref CmdLine.IPara[14], -1, 15);
            UpdateDisplay();
        }

        private void lbl_AddOfstY_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Ofst Y", ref CmdLine.IPara[15], -1, 15);
            UpdateDisplay();
        }
    }
}
