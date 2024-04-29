using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_DoBdCapture : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        enum ERotate { None, CW_90, CCW_90};

        public frm_DispCore_DispProg_DoBdCapture()
        {
            InitializeComponent();
            GControl.LogForm(this);

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            combox_ScanMode.Items.Clear();
            combox_ScanMode.Items.Add("Area");
            combox_ScanMode.Items.Add("Line");

            combox_Path.Items.Clear();
            combox_Path.Items.Add("X First Z Path");
            combox_Path.Items.Add("Y First Z Path");
            combox_Path.Items.Add("X First U Path");
            combox_Path.Items.Add("Y First U Path");

            combox_Resolution.Items.Clear();
            for (int i = 0; i < 50; i++)
            {
                combox_Resolution.Items.Add(((i + 1)*2).ToString());
            }

            cbxRotate.DataSource = Enum.GetNames(typeof(ERotate));
        }

        private void UpdateDisplay()
        {
            lbl_ImageID.Text = CmdLine.ID.ToString();
            lbl_CameraID.Text = CmdLine.IPara[1].ToString();
            lbl_FocusNo.Text = CmdLine.IPara[21].ToString();

            lbl_StartXY.Text = CmdLine.X[0].ToString("F3") + "," + CmdLine.Y[0].ToString("F3");
            lbl_EndXY.Text = CmdLine.X[1].ToString("F3") + "," + CmdLine.Y[1].ToString("F3");
            //lbl_SizeX.Text = (CmdLine.X[1] - CmdLine.X[0]).ToString();
            //lbl_SizeY.Text = (CmdLine.Y[1] - CmdLine.Y[0]).ToString();

            lblMaxSize.Text = CmdLine.IPara[5].ToString();

            lbl_Exposure.Text = CmdLine.DPara[5].ToString();
            lbl_Gain.Text = CmdLine.DPara[6].ToString();
            //CmdLine.IPara[8] = Math.Max(CmdLine.IPara[8], cbxRotate.Items.Count - 1);
            cbxRotate.SelectedIndex = CmdLine.IPara[8];

            double ScanSpeed = CmdLine.DPara[13];
            if (ScanSpeed == 0)
            {
                ScanSpeed = (CmdLine.IPara[10] + 1) *2 * 4;
                lbl_ScanSpeed.Text = "(" + ScanSpeed.ToString() + ")";
            }
            else
                lbl_ScanSpeed.Text = ScanSpeed.ToString();

            if (CmdLine.IPara[3] == 0)
                lbl_Setting.Text = "Scan Mode Area. ";// +
                    //"FOV CR (" + CmdLine.Index[0].ToString() + "," + CmdLine.Index[1].ToString() + ")";
            else
                lbl_Setting.Text = "Scan Mode Line. " +
                    "Resolution " + ((CmdLine.IPara[10] + 1) * 2).ToString() + ", Speed " + ScanSpeed.ToString() + " mm/s";

            #region Motion Setting
            double StartV = CmdLine.DPara[10];
            if (StartV == 0)
            {
                StartV = TaskGantry.GXAxis.Para.StartV;
                lbl_StartV.Text = "(" + StartV.ToString() + ")";
            }
            else
                lbl_StartV.Text = StartV.ToString();

            double DriveV = CmdLine.DPara[11];
            if (DriveV == 0)
            {
                DriveV = TaskGantry.GXAxis.Para.FastV;
                lbl_DriveV.Text = "(" + DriveV.ToString() + ")";
            }
            else
                lbl_DriveV.Text = DriveV.ToString();

            double Accel = CmdLine.DPara[12];
            if (Accel == 0)
            {
                Accel = TaskGantry.GXAxis.Para.Accel;
                lbl_Accel.Text = "(" + Accel.ToString() + ")";
            }
            else
                lbl_Accel.Text = Accel.ToString();

            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
            #endregion

        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frm_DispCore_DispProg_DoBdCapture_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = CmdName;

            TaskVision.SelectedCam = (ECamNo)CmdLine.IPara[1];
            TaskVision.LightingOn(TaskVision.BdCaptureLightRGB);

            if (CmdLine.Index[0] == 0) CmdLine.Index[0] = 1;
            if (CmdLine.Index[1] == 0) CmdLine.Index[1] = 1;

            if (CmdLine.DPara[5] == 0) CmdLine.DPara[5] = 8;

            combox_ScanMode.SelectedIndex = CmdLine.IPara[3];
            //CmdLine.IPara[8] = 1;//0, 1=90, 2=-90

            combox_Path.SelectedIndex = CmdLine.IPara[2];
            combox_Resolution.SelectedIndex = CmdLine.IPara[10];

            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> BdImg = null;
            if (TaskVision.BoardImage[CmdLine.ID] != null)
            {
                BdImg = TaskVision.BoardImage[CmdLine.ID].Clone();
                pbox_Image.Image = BdImg.ToBitmap();
            }
            else
            {
                Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> Img = null;
                Img = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte>(pbox_Image.Width, pbox_Image.Height);
                VisUtils.DrawText(Img, new Point(5, 5), "No Image", 10, Color.Red);
                pbox_Image.Image = Img.ToBitmap();
                Img.Dispose();
            }

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };

            UpdateDisplay();
        }
        private void frm_DispCore_DispProg_DoBdCapture_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }
        private void frm_DispCore_DispProg_DoBdCapture_VisibleChanged(object sender, EventArgs e)
        {
        }

        #region Basic
        private void lbl_CameraID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Cam ID", ref CmdLine.IPara[1], 0, 2);
            UpdateDisplay();
        }
        private void lbl_ImageID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Map ID", ref CmdLine.ID, 0, 9);
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
        private void lbl_SetStartPos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            CmdLine.X[0] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[0] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            Log.OnSet(CmdName + ", Start XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoStartPos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            UpdateDisplay();
        }
        private void btn_SetEndPos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            NSW.Net.Point2D Old = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            CmdLine.X[1] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[1] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);
            NSW.Net.Point2D New = new NSW.Net.Point2D(CmdLine.X[0], CmdLine.Y[0]);
            Log.OnSet(CmdName + ", End XY", Old, New);

            UpdateDisplay();
        }
        private void btn_GotoEndPos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            UpdateDisplay();
        }
        private void lbl_FovC_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", FovC", ref CmdLine.Index[0], -99, 99);
            UpdateDisplay();
        }
        private void lbl_FovR_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", FovR", ref CmdLine.Index[1], -99, 99);
            UpdateDisplay();
        }
        #endregion

        #region Scan Setting
        private void combox_ScanMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[3] = combox_ScanMode.SelectedIndex;

            UpdateDisplay();
        }
        private void lblMaxSize_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", MaxSize", ref CmdLine.IPara[5], 0, 32768);
            UpdateDisplay();
        }

        private void lbl_Exposure_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Camera Exposure (ms)", ref CmdLine.DPara[5], 0.010, 50);
            UpdateDisplay();
        }
        private void lbl_Gain_Click(object sender, EventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.PtGrey)
            {
                bool Avail = false;
                double Min = 0;
                double Max = 0;
                double Value = 0;
                TaskVision.PGCamera[1].GetProperty(PtGrey.TCamera.EProperty.Gain, ref Avail, ref Min, ref Max, ref Value);
                UC.AdjustExec(CmdName + ", Gain", ref CmdLine.DPara[6], Min, Max);
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                //TaskVision.flirCamera2[CamNo].Gain = Line.DPara[6];
                double Min = 1;
                double Max = 24;
                UC.AdjustExec(CmdName + ", Gain", ref CmdLine.DPara[6], Min, Max);
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVCGenTL)
            {
                double Min = 1;
                double Max = 24;
                UC.AdjustExec(CmdName + ", Gain", ref CmdLine.DPara[6], Min, Max);
            }
            UpdateDisplay();
        }
        private void cbxRotate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[8] = (sender as ComboBox).SelectedIndex;
        }

        private void combox_Path_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[2] = combox_Path.SelectedIndex;

            UpdateDisplay();
        }
        private void combox_Resolution_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmdLine.IPara[10] = combox_Resolution.SelectedIndex;

            UpdateDisplay();
        }
        private void lbl_ScanSpeed_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Scan Speed (mm/s)", ref CmdLine.DPara[13], 0, 500);

            UpdateDisplay();
        }
        #endregion

        #region Motion Setting
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
            UC.AdjustExec(CmdName + ", Accel (mm/s2)", ref CmdLine.DPara[12], 0, 10000);
            UpdateDisplay();
        }
        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Settle Time (ms)", ref CmdLine.IPara[4], 0, 500);
            UpdateDisplay();
        }
        #endregion

        private void btn_Capture_Click(object sender, EventArgs e)
        {
            Enabled = false;

            int ImageID = CmdLine.ID;

            TaskVision.BdCaptureLightRGB = TaskVision.CurrentLightRGBA;

            try
            {
                double X0 = DispProg.Origin(DispProg.rt_StationNo).X + CmdLine.X[0];
                double Y0 = DispProg.Origin(DispProg.rt_StationNo).Y + CmdLine.Y[0];
                double X1 = DispProg.Origin(DispProg.rt_StationNo).X + CmdLine.X[1];
                double Y1 = DispProg.Origin(DispProg.rt_StationNo).Y + CmdLine.Y[1];
                //CmdLine.IPara[1] = (int)TaskVision.SelectedCam;

                if (CmdLine.IPara[3] == 0)
                {
                    //int LoopDir = CmdLine.IPara[2];

                    int t = GDefine.GetTickCount();
                    if (!DispProg.DoBdCapture(CmdLine, ImageID, X0, Y0, X1, Y1)) return;
                    lbl_Status.Text = "Execution Time = " + (GDefine.GetTickCount() - t).ToString() + " ms.";
                }
                if (CmdLine.IPara[3] == 1)
                {
                    int t = GDefine.GetTickCount();
                    
                    DispProg.DoLineCapture(CmdLine, X0, Y0, X1, Y1);
                    lbl_Status.Text = "Execution Time = " + (GDefine.GetTickCount() - t).ToString() + " ms.";
                }
                try
                {
                    pbox_Image.Image = TaskVision.BoardImage[ImageID].ToBitmap();
                }
                catch { };

                UpdateDisplay();
            }
            catch (Exception Ex)
            {
                GDefine.Status = EStatus.ErrorInit;
                Msg MsgBox = new Msg();
                MsgBox.Show(Ex.Message.ToString());
            }
            finally
            {

                switch (GDefine.CameraType[0])
                {
                    //case GDefine.ECameraType.PtGrey:
                    //    TaskVision.PtGrey_CamStop();
                    //    break;
                    case GDefine.ECameraType.Spinnaker2:
                        TaskVision.flirCamera2[(int)TaskVision.SelectedCam].GrabCont();
                        break;
                    case GDefine.ECameraType.MVCGenTL:
                        TaskVision.genTLCamera[(int)TaskVision.SelectedCam].StartGrab();
                        break;
                    default:
                        throw new Exception("Camera not supported.");
                }

                Enabled = true;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);

            TaskVision.BdCaptureLightRGB = TaskVision.CurrentLightRGBA;
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            //frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName);
            Close();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            //frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName);
            Close();
        }
    }
}
