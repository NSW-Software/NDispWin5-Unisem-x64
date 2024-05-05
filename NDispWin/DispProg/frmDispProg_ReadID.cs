using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_ReadID : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);

        public frm_DispCore_DispProg_ReadID()
        {
            InitializeComponent();
            GControl.LogForm(this);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Left = 0;
            TopLevel = false;
            TopMost = true;
            Top = 0;
        }

        public void UpdateDisplay()
        {
            lbl_ID.Text = CmdLine.ID.ToString();
            cbox_Enabled.Checked = CmdLine.IPara[0] > 0;//TaskDisp.IDReader_Enabled;

            lbl_FocusNo.Text = CmdLine.IPara[21].ToString();

            lbl_X1Y1.Text = CmdLine.X[0].ToString("F3") + ", " + CmdLine.Y[0].ToString("F3");
            lbl_SettleTime.Text = CmdLine.IPara[4].ToString();
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_ReadID_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Command - READ_ID";

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            TaskVision.LightingOn(TaskVision.Read2DLightRGB);

            if (CmdLine.IPara[4] == 0) CmdLine.IPara[4] = 150;

            UpdateDisplay();

            try
            {
                TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21]);
            }
            catch { };
        }

        private void btn_SetPt1Pos_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

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
            //if (!TaskDisp.TaskMoveGZZ2Up()) return;
            if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

            if (!TaskGantry.MoveGX2Y2DefPos(true)) return;
            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void btn_Exec_Click(object sender, EventArgs e)
        {
            try
            {
                TaskVision.LightingOn(TaskVision.Read2DLightRGB);
                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

                lbl_Result.Text = "";
                double X = DispProg.Origin(ERunStationNo.Station1).X + CmdLine.X[0];
                double Y = DispProg.Origin(ERunStationNo.Station1).Y + CmdLine.Y[0];
                DispProg.Read_ID(CmdLine, X, Y);

                lbl_Result.Text = DispProg.rt_Read_IDs[CmdLine.ID, 0];
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }

        private void lbl_ID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", ID", ref CmdLine.ID, 0, DispProg.MAX_IDS);
            UpdateDisplay();
        }
        private void lbl_SettleTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", Settle Time (ms)", ref CmdLine.IPara[4], 0, 500);
            UpdateDisplay();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            TaskVision.Read2DLightRGB = TaskVision.CurrentLightRGBA;

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

        private void frm_DispCore_DispProg_ReadID_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void btn_ReadID_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = "";
                lbl_Result.Text = ID;

                if (!TaskDisp.TaskMoveGZFocus(CmdLine.IPara[21])) return;

                TaskDisp.IDReader_Read(false, ref ID);
                lbl_Result.Text = ID;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }

        private void cbox_Enabled_Click(object sender, EventArgs e)
        {
            //TaskDisp.IDReader_Enabled = !TaskDisp.IDReader_Enabled;
            CmdLine.IPara[0] = cbox_Enabled.Checked ? 1 : 0;

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
    }
}
