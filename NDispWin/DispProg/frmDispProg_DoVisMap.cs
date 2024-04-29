using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispCore
{
    internal partial class frmDispProg_DoVisMap : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frmDispProg_DoVisMap()
        {
            InitializeComponent();

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void UpdateDisplay()
        {
            lbl_MapID.Text = CmdLine.ID.ToString();

            lbl_FovC.Text = CmdLine.Index[0].ToString();
            lbl_FovR.Text = CmdLine.Index[1].ToString();

            #region Path
            btn_XFirstZPath.BackColor = this.BackColor;
            btn_YFirstZPath.BackColor = this.BackColor;
            btn_XFirstUPath.BackColor = this.BackColor;
            btn_YFirstUPath.BackColor = this.BackColor;
            switch (CmdLine.IPara[1])
            {
                case 1:
                    btn_YFirstZPath.BackColor = Color.Lime;
                    break;
                case 2:
                    btn_XFirstUPath.BackColor = Color.Lime;
                    break;
                case 3:
                    btn_YFirstUPath.BackColor = Color.Lime;
                    break;
                case 0:
                default:
                    btn_XFirstZPath.BackColor = Color.Lime;
                    break;
            }
            #endregion

            lbl_FovStartXY.Text = CmdLine.PosX[0].ToString("F3") + "," + CmdLine.PosY[0].ToString("F3");
        }

        private void frmDispProg_DoVisMap_Load(object sender, EventArgs e)
        {

        }

        private void frmDispProg_DoVisMap_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;

            CmdLine = DispProg.Script[ProgNo].CmdList.Line[LineNo];
            this.Text = "Command - " + Enum.GetName(typeof(DispProg.ECmd), CmdLine).ToString();// DO_VISMAP";

            
            TaskVision.LightingOn(TaskVision.LightRGB[CmdLine.ID]);

            if (CmdLine.Index[0] == 0) CmdLine.Index[0] = 1;
            if (CmdLine.Index[1] == 0) CmdLine.Index[1] = 1;

            UpdateDisplay();
        }

        private void lbl_MapID_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.ID, 0, 99);
            UpdateDisplay();
        }

        private void lbl_FovC_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.Index[0], -99, 99);
            UpdateDisplay();
        }

        private void lbl_FovR_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.Index[1], -99, 99);
            UpdateDisplay();
        }

        private void btn_XFirstZPath_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = 0;
            UpdateDisplay();
        }

        private void btn_YFirstZPath_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = 1;
            UpdateDisplay();
        }

        private void btn_XFirstUPath_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = 2;
            UpdateDisplay();
        }

        private void btn_YFirstUPath_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[1] = 3;
            UpdateDisplay();
        }

        private void lbl_SetStartPos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            CmdLine.PosX[0] = X - (DispProg.Origin[(int)DispProg.StationNo].X + SubOrigin.X);
            CmdLine.PosY[0] = Y - (DispProg.Origin[(int)DispProg.StationNo].Y + SubOrigin.Y);

            UpdateDisplay();
        }

        private void btn_GotoStartPos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin[(int)DispProg.StationNo].X + SubOrigin.X) + CmdLine.PosX[0];
            double Y = (DispProg.Origin[(int)DispProg.StationNo].Y + SubOrigin.Y) + CmdLine.PosY[0];

            if (!TaskGantry.SetMotionParamGZZ2()) return;
            if (!TaskGantry.MoveAbsGZZ2(0)) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;

            UpdateDisplay();
        }

        private void GetNextPos(ref int IndexX, ref int IndexY)
        {
            int MaxX = Math.Abs(CmdLine.Index[0]);
            int MaxY = Math.Abs(CmdLine.Index[1]);

            switch (CmdLine.IPara[1])
            {
                #region
                case 1://YF ZPath
                    if (IndexY >= MaxY - 1)
                    {
                        IndexX++;
                        IndexY = 0;
                    }
                    else
                    {
                        IndexY++;
                    }
                    break;
                case 2://XF UPath
                    if (IndexY % 2 == 0)
                    {
                        if (IndexX >= MaxX - 1)
                        {
                            IndexY++;
                        }
                        else
                        {
                            IndexX++;
                        }
                    }
                    else
                    {
                        if (IndexX <= 0)
                        {
                            IndexY++;
                        }
                        else
                        {
                            IndexX--;
                        }
                    }
                    break;
                case 3://YF UPath
                    if (IndexX % 2 == 0)
                    {
                        if (IndexY >= MaxY - 1)
                        {
                            IndexX++;
                        }
                        else
                        {
                            IndexY++;
                        }
                    }
                    else
                    {
                        if (IndexY <= 0)
                        {
                            IndexX++;
                        }
                        else
                        {
                            IndexY--;
                        }
                    }
                    break;
                case 0:
                default://XF ZPath
                    if (IndexX >= MaxX - 1)
                    {
                            IndexY++;
                            IndexX = 0;
                    }
                    else
                    {
                        IndexX++;
                    }
                    break;
                #endregion
            }
        }

        private void btn_Capture_Click(object sender, EventArgs e)
        {
            string EMsg = "DoVisMapCapture";

            int t = GDefine.GetTickCount();

            double XO = DispProg.Origin[0].X + CmdLine.PosX[0];
            double YO = DispProg.Origin[0].Y + CmdLine.PosY[0];
            double FovX = TaskVision.ImgW * TaskVision.DistPerPixelX;
            if (CmdLine.Index[0] < 0) FovX = -FovX;
            double FovY = TaskVision.ImgH * TaskVision.DistPerPixelY;
            if (CmdLine.Index[1] < 0) FovY = -FovY;

            int MaxX = Math.Abs(CmdLine.Index[0]);
            int MaxY = Math.Abs(CmdLine.Index[1]);
            int TotalFov = Math.Abs(MaxX * MaxY);

            int IndexX = 0;
            int IndexY = 0;

            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>[,] Img = new Emgu.CV.Image<Emgu.CV.Structure.Gray,byte>[100,100];
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>[] ImgLine = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>[100];
            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> FImg = null;

            try
            {
                if (!TaskGantry.SetMotionParamGZZ2()) return;
                if (!TaskGantry.MoveAbsGZZ2(0)) return;

                if (!TaskGantry.SetMotionParamGXY()) return;
                for (int i = 0; i < TotalFov; i++)
                {
                    double X = XO + (IndexX * FovX);
                    double Y = YO + (IndexY * FovY);

                    if (!TaskGantry.MoveAbsGXY(X, Y)) return;

                    int t1 = GDefine.GetTickCount() + TaskVision.Vision_SettleTime;
                    while (GDefine.GetTickCount() <= t1) { Application.DoEvents(); }

                    TaskVision.Grab(ref Img[IndexX, IndexY]);

                    pbox_Image.Image = Img[IndexX, IndexY].ToBitmap();

                    GetNextPos(ref IndexX, ref IndexY);
                }

                for (int y = 0; y < MaxY; y++)
                {
                    for (int x = 0; x < MaxX; x++)
                    {
                        if (x == 0)
                            ImgLine[y] = GrabberNET.VisProc.Copy(Img[x, y]);
                        else
                        {
                            if (CmdLine.Index[0] < 0)
                                ImgLine[y] = GrabberNET.VisProc.ConcateH(Img[x, y], ImgLine[y]);
                            else
                                ImgLine[y] = GrabberNET.VisProc.ConcateH(ImgLine[y], Img[x, y]);
                        }
                    }
                    if (y == 0)
                        FImg = ImgLine[y];
                    else
                    {
                        if (CmdLine.Index[1] < 0)
                            FImg = GrabberNET.VisProc.ConcateV(ImgLine[y], FImg);
                        else
                            FImg = GrabberNET.VisProc.ConcateV(FImg, ImgLine[y]);
                    }
                }
                pbox_Image.Image = FImg.ToBitmap();
            }
            catch (Exception Ex)
            {
                EMsg = Ex.Message.ToString();
                frm_Msg.Page.ShowMsg(EMsg, frm_Msg.TMsgBtn.smbAlmClr | frm_Msg.TMsgBtn.smbOK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        
        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo] = CmdLine;
            TaskVision.LightRGB[CmdLine.ID] = TaskVision.CurrentLightRGB;
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            frmDispProg.Done = true;
            Visible = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            frmDispProg.Done = true;
            Visible = false;
        }
    }
}
