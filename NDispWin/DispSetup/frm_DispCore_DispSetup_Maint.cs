using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace NDispWin
{
    public partial class frm_DispCore_DispSetup_Maint : Form
    {
        public frm_DispCore_DispSetup_Maint()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_DispCore_DispSetup_Maint_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
        }
        private void frm_DispCore_DispSetup_Maint_Shown(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispSetup_Maint_VisibleChanged(object sender, EventArgs e)
        {
            //bNICamTrigggering = false;
            UpdateDisplay();
        }
        private void frm_DispCore_DispSetup_Maint_FormClosing(object sender, FormClosingEventArgs e)
        {
            bNICamTrigggering = false;
        }

        private void UpdateDisplay()
        {
            lblMMaintPosXYZ.Text = $"X:{TaskDisp.Machine_Maint_Pos[0].X:f3},Y:{TaskDisp.Machine_Maint_Pos[0].Y:f3},Z:{TaskDisp.Machine_Maint_Pos[0].Z:f3}\r" +
                $"X2:{TaskDisp.Machine_Maint_Pos[1].X:f3},Y2:{TaskDisp.Machine_Maint_Pos[1].Y:f3},Z2:{TaskDisp.Machine_Maint_Pos[1].Z:f3}";
            lblNMaintPosXYZ.Text = $"X:{TaskDisp.Needle_Maint_Pos[0].X:f3},Y:{TaskDisp.Needle_Maint_Pos[0].Y:f3},Z:{TaskDisp.Needle_Maint_Pos[0].Z:f3}\r" +
                $"X2:{TaskDisp.Needle_Maint_Pos[1].X:f3},Y2:{TaskDisp.Needle_Maint_Pos[1].Y:f3},Z2:{TaskDisp.Needle_Maint_Pos[1].Z:f3}";

            lblP1NeedleInspCamPos.Text = $"X:{TaskDisp.P1NeedleInspCamPos[0].X:f3},Y:{TaskDisp.P1NeedleInspCamPos[0].Y:f3},Z:{TaskDisp.P1NeedleInspCamPos[0].Z:f3}\r" +
                $"X2:{TaskDisp.P1NeedleInspCamPos[1].X:f3},Y2:{TaskDisp.P1NeedleInspCamPos[1].Y:f3},Z2:{TaskDisp.P1NeedleInspCamPos[1].Z:f3}";
            lblP2NeedleInspCamPos.Text = $"X:{TaskDisp.P2NeedleInspCamPos[0].X:f3},Y:{TaskDisp.P2NeedleInspCamPos[0].Y:f3},Z:{TaskDisp.P2NeedleInspCamPos[0].Z:f3}\r" +
                $"X2:{TaskDisp.P2NeedleInspCamPos[1].X:f3},Y2:{TaskDisp.P2NeedleInspCamPos[1].Y:f3},Z2:{TaskDisp.P2NeedleInspCamPos[1].Z:f3}";

            btnTrig.BackColor = bNICamTrigggering ? Color.Red : this.BackColor;
        }

        private void btn_SetMMaintPos_Click(object sender, EventArgs e)
        {
            TaskDisp.Machine_Maint_Pos[0].X = TaskGantry.GXPos();
            TaskDisp.Machine_Maint_Pos[0].Y = TaskGantry.GYPos();
            TaskDisp.Machine_Maint_Pos[0].Z = TaskGantry.GZPos();

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                TaskDisp.Machine_Maint_Pos[1].X = TaskGantry.GX2Pos();
                TaskDisp.Machine_Maint_Pos[1].Y = TaskGantry.GY2Pos();
                TaskDisp.Machine_Maint_Pos[1].Z = TaskGantry.GZ2Pos();
            }
            else
            {
                TaskDisp.Machine_Maint_Pos[1].X = 0;
                TaskDisp.Machine_Maint_Pos[1].Y = 0;
                TaskDisp.Machine_Maint_Pos[1].Z = 0;
            }
            TaskDisp.TaskMoveGZUp();
            UpdateDisplay();
        }

        private void btn_GotoMMaintPos_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskGotoMMaint();
        }

        private void btn_SetPMaintPos_Click(object sender, EventArgs e)
        {
            TaskDisp.Needle_Maint_Pos[0].X = TaskGantry.GXPos();
            TaskDisp.Needle_Maint_Pos[0].Y = TaskGantry.GYPos();
            TaskDisp.Needle_Maint_Pos[0].Z = TaskGantry.GZPos();

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                TaskDisp.Needle_Maint_Pos[1].X = TaskGantry.GX2Pos();
                TaskDisp.Needle_Maint_Pos[1].Y = TaskGantry.GY2Pos();
                TaskDisp.Needle_Maint_Pos[1].Z = TaskGantry.GZ2Pos();
            }
            else
            {
                TaskDisp.Needle_Maint_Pos[1].X = 0;
                TaskDisp.Needle_Maint_Pos[1].Y = 0;
                TaskDisp.Needle_Maint_Pos[1].Z = 0;
            }
            TaskDisp.TaskMoveGZUp();
            UpdateDisplay();
        }

        private void btn_GotoPMaintPos_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskGotoPMaint();
        }

        private void btn_PumpActionSetup_Click(object sender, EventArgs e)
        {
            frm_PumpActionEditor frm = new frm_PumpActionEditor();
            frm.ShowDialog();
        }

        private void btnSetP1NICamPos_Click(object sender, EventArgs e)
        {
            TaskDisp.P1NeedleInspCamPos[0].X = TaskGantry.GXPos();
            TaskDisp.P1NeedleInspCamPos[0].Y = TaskGantry.GYPos();
            TaskDisp.P1NeedleInspCamPos[0].Z = TaskGantry.GZPos();

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                TaskDisp.P1NeedleInspCamPos[1].X = TaskGantry.GX2Pos();
                TaskDisp.P1NeedleInspCamPos[1].Y = TaskGantry.GY2Pos();
                TaskDisp.P1NeedleInspCamPos[1].Z = TaskGantry.GZ2Pos();
            }
            else
            {
                TaskDisp.P1NeedleInspCamPos[1].X = 0;
                TaskDisp.P1NeedleInspCamPos[1].Y = 0;
                TaskDisp.P1NeedleInspCamPos[1].Z = 0;
            }
            TaskDisp.TaskMoveGZUp();
            UpdateDisplay();
        }
        private void btnGotoP1NICamPos_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskGotoPos(TaskDisp.P1NeedleInspCamPos);
        }
        private void btnExecP1NICam_Click(object sender, EventArgs e)
        {
            bNICamTrigggering = false;
            UpdateDisplay();
            TaskDisp.TaskNeedleInsp(1);
        }

        private void btnSetP2NICamPos_Click(object sender, EventArgs e)
        {
            TaskDisp.P2NeedleInspCamPos[0].X = TaskGantry.GXPos();
            TaskDisp.P2NeedleInspCamPos[0].Y = TaskGantry.GYPos();
            TaskDisp.P2NeedleInspCamPos[0].Z = TaskGantry.GZPos();

            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                TaskDisp.P2NeedleInspCamPos[1].X = TaskGantry.GX2Pos();
                TaskDisp.P2NeedleInspCamPos[1].Y = TaskGantry.GY2Pos();
                TaskDisp.P2NeedleInspCamPos[1].Z = TaskGantry.GZ2Pos();
            }
            else
            {
                TaskDisp.P2NeedleInspCamPos[1].X = 0;
                TaskDisp.P2NeedleInspCamPos[1].Y = 0;
                TaskDisp.P2NeedleInspCamPos[1].Z = 0;
            }
            TaskDisp.TaskMoveGZUp();
            UpdateDisplay();
        }
        private void btnGotoP2NICamPos_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskGotoPos(TaskDisp.P2NeedleInspCamPos);
        }
        private void btnExecP2NICam_Click(object sender, EventArgs e)
        {
            bNICamTrigggering = false;
            UpdateDisplay();
            TaskDisp.TaskNeedleInsp(2);
        }

        bool bNICamTrigggering = false;
        private void Triggering()
        {
            Task.Run(() =>
            {
                while (bNICamTrigggering)
                {
                    TaskGantry.NICamTrig = true;
                    System.Threading.Thread.Sleep(1);
                    TaskGantry.NICamTrig = false;
                    System.Threading.Thread.Sleep(99);
                }
            });
        }

        private void btnTrig_Click(object sender, EventArgs e)
        {
            bNICamTrigggering = !bNICamTrigggering;
            if (bNICamTrigggering) Triggering();
            UpdateDisplay();
        }

    }
}
