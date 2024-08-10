using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DispCore
{
    internal partial class frm_DispCore_DispProg_MeasL_H : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_MeasL_H()
        {
            InitializeComponent();

            TopLevel = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            AppLanguage.Func.SetComponent(this);
        }

        const int MAX_POINTS = 20;
        int i_PointNo = 0;//index starts from 0

        private void UpdateDisplay()
        {
            lbl_HeightID.Text = CmdLine.ID.ToString();
            lbl_AlignType.Text = CmdLine.IPara[2].ToString() + " - " + Enum.GetName(typeof(EAlignType), CmdLine.IPara[2]);

            if (CmdLine.IPara[0] != 3)
                btn_HeightType.BackColor = Color.Lime;
            else
                btn_HeightType.BackColor = this.BackColor;

            if (CmdLine.IPara[0] == 3)
                btn_PlaneType.BackColor = Color.Lime;
            else
                btn_PlaneType.BackColor = this.BackColor;

            //cbox_UseSecHeightID.Checked = (CmdLine.IPara[2] == 1);

            gbox_HeightPositions.Visible = CmdLine.IPara[0] != 3;
            CmdLine.IPara[1] = Math.Max(1, CmdLine.IPara[1]);
            lbl_PointCount.Text = CmdLine.IPara[1].ToString();
            lbl_PointNo.Text = (i_PointNo + 1).ToString();
            lbl_PointXY.Text = CmdLine.X[i_PointNo].ToString("F3") + ", " + CmdLine.Y[i_PointNo].ToString("F3");

            btn_Prev.Enabled = (i_PointNo != 0);
            btn_Next.Enabled = (i_PointNo < CmdLine.IPara[1] - 1);

            gbox_PlanePositions.Visible = CmdLine.IPara[0] == 3;
            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");
            lbl_X2Y2.Text = CmdLine.X[1].ToString("F3") + ", " + CmdLine.Y[1].ToString("F3");
            lbl_X3Y3.Text = CmdLine.X[2].ToString("F3") + ", " + CmdLine.Y[2].ToString("F3");

            //gbox_SecHeight.Visible = (CmdLine.IPara[2] == 1);
            //lbl_SecXY.Text = CmdLine.PosX[20].ToString("F3") + ", " + CmdLine.PosY[20].ToString("F3"); 

            lbl_ZDiff.Text = CmdLine.DPara[0].ToString("F3");

            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
            lbl_SkipCount.Text = CmdLine.IPara[5].ToString();
            lbl_FailAction.Text = CmdLine.IPara[6].ToString() + " - " + Enum.GetName(typeof(EFailAction), CmdLine.IPara[6]); 
        }

        private void frmDispProg_MeasL_H_Load(object sender, EventArgs e)
        {
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            this.Text = "Command - DO_HEIGHT";

            if (CmdLine.DPara[0] == 0) CmdLine.DPara[0] = 0.5;
            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;//Settle Time


            UpdateDisplay();
        }

        private void lbl_HeightID_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Height ID", ref CmdLine.ID, 0, DispProg.MAX_IDS - 1);
            UpdateDisplay();
        }

        private void lbl_AlignType_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute(ref CmdLine.IPara[2], 0, 6);
            UpdateDisplay();
        }

        private void btn_HeightType_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[0] = 1;
            UpdateDisplay();
        }

        private void btn_PlaneType_Click(object sender, EventArgs e)
        {
            CmdLine.IPara[0] = 3;
            UpdateDisplay();
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
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[0];

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

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
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[1];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[1];

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetPt3Pos_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            CmdLine.X[2] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[2] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            UpdateDisplay();
        }

        private void btn_GotoPt3Pos_Click(object sender, EventArgs e)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[2];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[2];

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void lbl_ZDiff_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Z Diff", ref CmdLine.DPara[0], 0, 5);
            UpdateDisplay();
        }
        
        private void lbl_PointCount_Click(object sender, EventArgs e)
        {
            GDefine.uc.UserAdjustExecute("Point Count", ref CmdLine.IPara[1], 1, MAX_POINTS);
            i_PointNo = Math.Min(i_PointNo, CmdLine.IPara[1] - 1);
            UpdateDisplay();
        }

        private void lbl_PointNo_Click(object sender, EventArgs e)
        {
            int i = i_PointNo + 1;
            GDefine.uc.UserAdjustExecute("Point No", ref i, 1, MAX_POINTS);
            i_PointNo = i - 1;
            UpdateDisplay();
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (i_PointNo == 0) return;
            i_PointNo--;
            UpdateDisplay();

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[i_PointNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[i_PointNo];

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (i_PointNo == MAX_POINTS - 1) return;
            i_PointNo++;
            UpdateDisplay();

            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[i_PointNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[i_PointNo];

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_GotoPt_Click(object sender, EventArgs e)
        {
            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;
            
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[i_PointNo];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[i_PointNo];

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_SetPt_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            CmdLine.X[i_PointNo] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[i_PointNo] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            UpdateDisplay();
        }

        private void btn_SetSecX1Y1_Click(object sender, EventArgs e)
        {
            double X = TaskGantry.GXPos();
            double Y = TaskGantry.GYPos();

            CmdLine.X[MAX_POINTS] = X - (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X);
            CmdLine.Y[MAX_POINTS] = Y - (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y);

            UpdateDisplay();
        }

        private void btn_GotoSecXY_Click(object sender, EventArgs e)
        {
            //if (!TaskGantry.SetMotionParamGZZ2()) return;
            //if (!TaskGantry.MoveAbsGZZ2(0)) return;
            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.X[MAX_POINTS];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.Y[MAX_POINTS];

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            string EMsg = "MeasL_HTest";

            List<double> Z = new List<double>();

            int t = GDefine.GetTickCount();

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            int i_PointIndex = 0;//index starts from 0
            int i_PointCount = 1;

            if (CmdLine.IPara[0] == 3)//Plane Align
                i_PointCount = 3;
            else//Height Align
                i_PointCount = CmdLine.IPara[1];

            while (i_PointIndex < i_PointCount)
            {
                TPos2 GXY = new TPos2();
                GXY.X = DispProg.Origin(ERunStationNo.St1).X + CmdLine.X[i_PointIndex];// +(SecIDRelX * i_IDIndex);
                GXY.Y = DispProg.Origin(ERunStationNo.St1).Y + CmdLine.Y[i_PointIndex];// +(SecIDRelY * i_IDIndex);
                GXY.X = GXY.X + TaskDisp.Laser_Ofst.X;
                GXY.Y = GXY.Y + TaskDisp.Laser_Ofst.Y;

                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_MinDistX;
                TaskDisp.GotoXYPos(GXY, GX2Y2);//) goto _Error;

                int t1 = GDefine.GetTickCount() + CmdLine.IPara[4];// TaskVision.Laser_SettleTime;
                while (GDefine.GetTickCount() <= t1) { Thread.Sleep(1); }

                //get value
                double v = 0;
                double i = 0;

                bool b_OK = TaskLaser.GetHeight(ref i);
                //OK.Add(b_OK);
                if (!b_OK) goto _GetHeightFail;

                v = i;
                Z.Add(v - TaskDisp.Laser_RefPosZ);


                i_PointIndex++;
            }

            t = GDefine.GetTickCount() - t;

            //string s_TestName = "HeightID " + CmdLine.ID.ToString();
            string str = "";// s_TestName + " ";

            if (CmdLine.IPara[0] == 3)//Plane Align
            {
                double Diff = Z.Max() - Z.Min();
                if (Diff > CmdLine.DPara[0])
                {
                    str = str + "Result: NG ";
                    str = str + "(Height Tolerance Fail)";
                }
                else
                    str = str + "Result: OK";
                lbox_Info.Items.Add(str);

                //str = s_TestName + " Data:" + (char)9;
                str = "Data:" + (char)9;
                for (int i = 0; i < 3; i++)
                {
                    str = str + "Point" + i.ToString() + (char)9;
                }
                str = str + "Diff" + (char)9 + "Time" + (char)9;
                lbox_Info.Items.Add(str);

                //str = s_TestName + " Data:" + (char)9;
                str = "Data:" + (char)9;
                for (int i = 0; i < 3; i++)
                {
                    str = str + Z[i].ToString("F3") + (char)9;
                }
                str = str + Diff.ToString("f3") + (char)9 + t.ToString();
                lbox_Info.Items.Add(str);
            }
            else//Height Align
            {
                double Diff = Z.Max() - Z.Min();
                if (Diff > CmdLine.DPara[0])
                {
                    str = str + "Result: NG ";
                    str = str + "(Height Tolerance Fail)";
                }
                else
                    str = str + "Result: OK";
                lbox_Info.Items.Add(str);

                //str = s_TestName + " Data:" + (char)9;
                str = "Data:" + (char)9;
                str = str + "Points" + (char)9 + "Min" + (char)9 + "Max" + (char)9 + "Average" + (char)9 + "Diff" + (char)9;
                str = str + "Time";
                lbox_Info.Items.Add(str);

                //str = s_TestName + " Data:" + (char)9;
                str = "Data:" + (char)9;
                str = str + Z.Count.ToString() + (char)9 + Z.Min().ToString("F3") + (char)9 + Z.Max().ToString("F3") + (char)9 + Z.Average().ToString("F3") + (char)9 + Diff.ToString("F3") + (char)9;
                str = str + t.ToString();
                lbox_Info.Items.Add(str);
            }

            lbox_Info.SelectedIndex = lbox_Info.Items.Count - 1;

            return;

        _GetHeightFail:
            lbox_Info.Items.Add("Get Height Fail");
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            frm_DispCore_DispProg.Done = true;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg.Done = true;
            Close();
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
    }
}
