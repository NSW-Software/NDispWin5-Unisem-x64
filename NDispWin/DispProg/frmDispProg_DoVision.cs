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
using System.IO;

using Emgu.CV;

/*todo
use temp values to be able to cancel
*/

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_DoVision : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        NVision.frm_VisTools frm_VisionTools = new NVision.frm_VisTools();

        public frm_DispCore_DispProg_DoVision()
        {
            InitializeComponent();
            GControl.LogForm(this);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void UpdateDisplay()
        {
            TConditions Cond = new TConditions(LineNo, CmdLine);
            lbox_Cond.Items.Clear();
            foreach (string s in Cond.Strings)
            {
                lbox_Cond.Items.Add(s);
            }

            lbl_VisionID.Text = CmdLine.ID.ToString();
            lbl_CameraID.Text = CmdLine.IPara[1].ToString();

            lbl_FocusNo.Text = CmdLine.IPara[21].ToString();

            //lbl_AlignType.Enabled = true;
            lbl_AlignType.Text = CmdLine.IPara[2].ToString() + " - " + Enum.GetName(typeof(EAlignType), CmdLine.IPara[2]);

            //lbl_SaveImages.Text = DispProg.SaveDoVisionImages.ToString();
            lbl_SaveImages.Text = (CmdLine.IPara[3] > 0).ToString();
            //lbl_SaveDirectory.Text = DispProg.ImageLocation;
            lbl_SaveDirectory.Text = CmdLine.String;

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");

            #region Settings
            double StartV = CmdLine.DPara[10];
            if (StartV == 0)
            {
                StartV = TaskGantry.GXAxis.Para.StartV;
                lbl_StartV.Text = "(" + StartV.ToString("f1") + ")";
            }
            else lbl_StartV.Text = StartV.ToString("f1");

            double DriveV = CmdLine.DPara[11];
            if (DriveV == 0)
            {
                DriveV = TaskGantry.GXAxis.Para.FastV;
                lbl_DriveV.Text = "(" + DriveV.ToString("f1") + ")";
            }
            else lbl_DriveV.Text = DriveV.ToString("f1");

            double Accel = CmdLine.DPara[12];
            if (Accel == 0)
            {
                Accel = TaskGantry.GXAxis.Para.Accel;
                lbl_Accel.Text = "(" + Accel.ToString("f1") + ")";
            }
            else lbl_Accel.Text = Accel.ToString("f1");
            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
            lblInspPrior.Text = CmdLine.IPara[7].ToString();
            #endregion

            lbl_SkipCount.Text = CmdLine.IPara[5].ToString();
            lbl_FailAction.Text = CmdLine.IPara[6].ToString() + " - " + Enum.GetName(typeof(EFailAction), CmdLine.IPara[6]);
            lbl_AcceptTol.Text = CmdLine.DPara[6].ToString("f3");
            lbl_XYTol.Text = CmdLine.DPara[1].ToString("f3");
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

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            btn_Align.Visible = CmdLine.Cmd == DispProg.ECmd.DO_VIS_INSP;
            lbllblAlignType.Visible = CmdLine.Cmd != DispProg.ECmd.DO_VIS_INSP;
            lbl_AlignType.Visible = CmdLine.Cmd != DispProg.ECmd.DO_VIS_INSP;

            lblInspPrior.Visible = CmdLine.Cmd == DispProg.ECmd.DO_VIS_INSP;
            lbllblInspectPrior.Visible = CmdLine.Cmd == DispProg.ECmd.DO_VIS_INSP;


            TaskVision.SelectedCam = (ECamNo)CmdLine.IPara[1];
            TaskVision.LightingOn(TaskVision.LightRGB[CmdLine.ID]);


            if (CmdLine.IPara[0] < 1) CmdLine.IPara[0] = 1;
            if (CmdLine.IPara[0] > 2) CmdLine.IPara[0] = 2;

            if (CmdLine.DPara[0] == 0) CmdLine.DPara[0] = 0.85;
            if (CmdLine.DPara[1] == 0) CmdLine.DPara[1] = 2;
            if (CmdLine.DPara[2] == 0) CmdLine.DPara[2] = 5;

            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;//Settle Time

            DispProg.frm_CamView.Show();
            DispProg.frm_CamView.BringToFront();
            DispProg.frm_CamView.TopMost = true;
            DispProg.frm_CamView.Top = 5;
            DispProg.frm_CamView.Left = this.Parent.Width - DispProg.frm_CamView.Width;

            frm_VisionTools.TopLevel = false;
            frm_VisionTools.Parent = pnl_Tools;
            frm_VisionTools.Height = pnl_Tools.Height;
            frm_VisionTools.Dock = DockStyle.Fill;

            frm_VisionTools.frm_CameraView = DispProg.frm_CamView;

            frm_VisionTools.VisTools = DispProg.VisionTools[CmdLine.ID];
            frm_VisionTools.Refreah_lv_Tools();

            frm_VisionTools.Visible = true;
            frm_VisionTools.FormBorderStyle = FormBorderStyle.None;

            UpdateDisplay();
            lbox_Info.Items.Clear();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
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
        }
        private void lbl_CameraID_Click(object sender, EventArgs e)
        {
        }

        private void lbl_AlignType_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("CmdName + , Align Type", ref CmdLine.IPara[2], 0, 6);
            UpdateDisplay();
        }
        #endregion 

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            //frm_DispProg2.Done = true;

            DispProg.frm_CamView.Hide();
            Log.OnAction("OK", CmdName);
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            //frm_DispProg2.Done = true;

            DispProg.frm_CamView.Hide();
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
            Log.OnSet(CmdName + ", Pt1", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoPt1Pos_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_LoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(ofd.FileName);

                DispProg.frm_CamView.Image = bmp;
                //DispProg.frm_CamView.Shrink();
            }
        }
        private void btn_Grab_Click(object sender, EventArgs e)
        {
            DispProg.frm_CamView.Show();
            DispProg.frm_CamView.BringToFront();

            CmdLine.IPara[1] = (int)TaskVision.SelectedCam;
            int CamID = CmdLine.IPara[1];

            try
            {
                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> Image = null;
                if (GDefine.CameraType[CamID] == GDefine.ECameraType.MVSGenTL)
                {
                    TaskVision.genTLCamera[CamID].GrabOneImage();
                    Image = TaskVision.genTLCamera[CamID].mImage.Clone();
                    TaskVision.genTLCamera[0].StartGrab();
                }
                else
                {

                    TaskVision.GrabN(CamID, ref Image);
                }

                DispProg.frm_CamView.Image = Image.ToBitmap();

                if (GDefine.CameraType[CamID] == GDefine.ECameraType.PtGrey)
                {
                    //TaskVision.PtGrey_CamLive(CamID);
                }
            }
            catch
            { }

            //DispProg.frm_CamView.Shrink();

            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGBA;
            UpdateDisplay();
        }


        private void btn_GrabExec_Click(object sender, EventArgs e)
        {
            btn_Grab_Click(sender, e);
            try
            {
                DispProg.VisionTools[CmdLine.ID].Exec(DispProg.frm_CamView.Image);
                DispProg.frm_CamView.TempImage = DispProg.VisionTools[CmdLine.ID].Image_Result().ToBitmap();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ex.Message.ToString());
            }
        }

        private void btn_Align_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

                TaskVision.LightingOn(TaskVision.LightRGB[CmdLine.ID]);

                int t = GDefine.GetTickCount();
                int CamID = CmdLine.IPara[1];

                double X = 0;
                double Y = 0;
                double A = 0;
                double S = 0;
                bool OK = false;

                TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();
                TaskVision.ExecVision(CamID, CmdLine.ID, ref X, ref Y, ref A, ref S, ref OK);
                if (GDefine.CameraType[CamID] == GDefine.ECameraType.PtGrey)
                {
                    //TaskVision.PtGrey_CamLive(CamID);
                }
                if (GDefine.CameraType[CamID] == GDefine.ECameraType.MVSGenTL)
                {
                    TaskVision.genTLCamera[0].StartGrab();
                }

                DoRefData.XF = X;
                DoRefData.YF = Y;
                DoRefData.Angle = A;
                DoRefData.SF = S;
                if (OK) DoRefData.RefResult = ERefResult.OK;
                else
                    DoRefData.RefResult = ERefResult.FailOther;

                t = GDefine.GetTickCount() - t;

                if (DoRefData.RefResult == ERefResult.OK)
                {
                    double GX = TaskGantry.GXPos() + DoRefData.XF;
                    double GY = TaskGantry.GYPos() + DoRefData.YF;

                    double StartV = CmdLine.DPara[10]; if (StartV == 0) StartV = TaskGantry.GXAxis.Para.StartV;
                    double DriveV = CmdLine.DPara[11]; if (DriveV == 0) DriveV = TaskGantry.GXAxis.Para.FastV;
                    double Accel = CmdLine.DPara[12]; if (Accel == 0) Accel = TaskGantry.GXAxis.Para.Accel;

                    TPos2 GXYPos = new TPos2();
                    GXYPos.X = TaskGantry.GXPos() + DoRefData.XF;
                    GXYPos.Y = TaskGantry.GYPos() + DoRefData.YF;
                    TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                    GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;
                    TaskDisp.GotoXYPos(GXYPos, GX2Y2);
                }

                lbox_Info.BackColor = Color.Lime;
                if (DoRefData.RefResult != ERefResult.OK)
                {
                    lbox_Info.BackColor = Color.Red;
                    goto _End;
                }

                _End:
                lbox_Info.Items.Clear();
                lbox_Info.Items.Add("XOfst" + (char)9 + "YOfst" + (char)9 + "Angle" + (char)9 + "Score");
                lbox_Info.Items.Add(DoRefData.XF.ToString("F3") + (char)9 + DoRefData.YF.ToString("F3") + (char)9 + DoRefData.Angle.ToString("f1") + (char)9 + (DoRefData.SF * 100).ToString("f1"));
                lbox_Info.Items.Add("Result:" + (char)9 + "OK" + (char)9 + t.ToString() + "ms");
                lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ex.Message.ToString());
            }
        }
        private void btn_Test_Click(object sender, EventArgs e)
        {
            int t = GDefine.GetTickCount();

            try
            {
                //if (!TaskDisp.TaskMoveGZZ2Up()) goto _Fail;
                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) goto _Fail;

                TPos2 GXXPos = new TPos2();
                GXXPos.X = DispProg.Origin(ERunStationNo.Station1).X + CmdLine.X[0];
                GXXPos.Y = DispProg.Origin(ERunStationNo.Station1).Y + CmdLine.Y[0];
                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;
                if (!TaskDisp.GotoXYPos(GXXPos, GX2Y2)) goto _Fail;

                int SettleTime = CmdLine.IPara[4];
                int t1 = GDefine.GetTickCount() + SettleTime;
                while (GDefine.GetTickCount() <= t1) { Thread.Sleep(1); }

                int CamID = CmdLine.IPara[1];

                double X = 0;
                double Y = 0;
                double A = 0;
                double S = 0;
                bool OK = false;

                TaskVision.TDoRefData DoRefData = new TaskVision.TDoRefData();

                TaskVision.ExecVision(CamID, CmdLine.ID, ref X, ref Y, ref A, ref S, ref OK);

                if (GDefine.CameraType[CamID] == GDefine.ECameraType.MVSGenTL)
                {
                    TaskVision.genTLCamera[0].StartGrab();
                }

                DoRefData.XF = X;
                DoRefData.YF = Y;
                DoRefData.Angle = A;
                DoRefData.SF = S;
                if (OK) DoRefData.RefResult = ERefResult.OK;
                else
                    DoRefData.RefResult = ERefResult.FailOther;

                t = GDefine.GetTickCount() - t;

                lbox_Info.Items.Add("XOfst" + (char)9 + "YOfst" + (char)9 + "Angle" + (char)9 + "Score");
                lbox_Info.Items.Add(DoRefData.XF.ToString("F3") + (char)9 + DoRefData.YF.ToString("F3") + (char)9 + DoRefData.Angle.ToString("f1") + (DoRefData.SF * 100).ToString());

                if (DoRefData.RefResult != ERefResult.OK) goto _Fail;

                lbox_Info.Items.Add("Result:" + (char)9 + "OK" + (char)9 + t.ToString() + "ms");
                lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;
                return;

            _Fail:
                lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;
                lbox_Info.BackColor = Color.Red;
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ex.Message.ToString());
            }
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

        #region Settings
        private void lbl_StartV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Start Speed (mm/s)", ref CmdLine.DPara[10], 0, 50);
            UpdateDisplay();
        }
        private void lbl_DriveV_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Drive Speed (mm/s)", ref CmdLine.DPara[11], 0, 1000);
            UpdateDisplay();
        }
        private void lbl_Accel_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Accel (mm/s2)", ref CmdLine.DPara[12], 0, 5000);
            UpdateDisplay();
        }
        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Settle Time (ms)", ref CmdLine.IPara[4], 0, 500);
            UpdateDisplay();
        }
        private void lblInspPrior_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Insp Prior (units)", ref CmdLine.IPara[7], 0, 50);
            UpdateDisplay();
        }
        #endregion

        #region Options
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
        #endregion

        private void lbl_SaveImages_Click(object sender, EventArgs e)
        {
            //UC.AdjustExec("DoVision, SaveImage", ref DispProg.SaveDoVisionImages);
            bool b = CmdLine.IPara[3] > 0;
            UC.AdjustExec("DoVision, SaveImage", ref b);
            CmdLine.IPara[3] = b ? 1 : 0;
            UpdateDisplay();
        }

        private void btn_ClearImages_Click(object sender, EventArgs e)
        {
        }

        private void tpage_Advance_Click(object sender, EventArgs e)
        {

        }

        private void lbl_SaveDirectory_Click(object sender, EventArgs e)
        {
            //UC.EntryExec("DoVision, ImageLocation", ref DispProg.ImageLocation, false);
            UC.EntryExec("DoVision, ImageLocation", ref CmdLine.String, false);
            UpdateDisplay();
        }

        private void frm_DispCore_DispProg_DoVision_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void lbl_AcceptTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Accept Tol (mm)", ref CmdLine.DPara[6], 0, 1);
            UpdateDisplay();
        }

        private void btn_Cond_Click(object sender, EventArgs e)
        {
            frm_DispProg_Condition frm = new frm_DispProg_Condition();
            frm.CmdLine.Copy(CmdLine);
            frm.ShowDialog();
            CmdLine.Copy(frm.CmdLine);

            UpdateDisplay();
        }

        private void lblXYTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Accept Tol (mm)", ref CmdLine.DPara[1], 0, 5);
            UpdateDisplay();
        }
    }
}
