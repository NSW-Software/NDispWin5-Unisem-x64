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
    public partial class frm_DispCore_DispSetup_CleanPurge : Form
    {
        public frm_DispCore_DispSetup_CleanPurge()
        {
            InitializeComponent();
            GControl.LogForm(this);
            

            combox_CleanPosition.Items.Clear();
            combox_PurgePosition.Items.Clear();
            combox_FlushPosition.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TaskDisp.EMaintPos)).Count(); i++)
            {
                combox_CleanPosition.Items.Add(Enum.GetName(typeof(TaskDisp.EMaintPos), i).ToString());
                combox_PurgePosition.Items.Add(Enum.GetName(typeof(TaskDisp.EMaintPos), i).ToString());
                combox_FlushPosition.Items.Add(Enum.GetName(typeof(TaskDisp.EMaintPos), i).ToString());
            }

            combox_CleanPosition.Text = Enum.GetName(typeof(TaskDisp.EMaintPos), TaskDisp.Needle_Clean_UsePos).ToString();
            combox_PurgePosition.Text = Enum.GetName(typeof(TaskDisp.EMaintPos), TaskDisp.Needle_Purge_UsePos).ToString();
            combox_FlushPosition.Text = Enum.GetName(typeof(TaskDisp.EMaintPos), TaskDisp.Needle_Flush_UsePos).ToString();
        }

        private void frm_DispCore_DispSetup_CleanPurge_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            if (this.Modal)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }
        private void frm_DispCore_DispSetup_CleanPurge_Shown(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispSetup_CleanPurge_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            btn_Save.Visible = this.Modal;
            btn_Close.Visible = this.Modal;

            groupBox1.Text = "Positions [" + DispProg.Pump_Type.ToString() + "]";

            #region Clean
            lbl_Needle1CleanPosXYZ.Text = TaskDisp.Needle_Clean_Pos[0].X.ToString("F3") + "," +
                TaskDisp.Needle_Clean_Pos[0].Y.ToString("F3") + "," +
                TaskDisp.Needle_Clean_Pos[0].Z.ToString("F3");
            lbl_Needle2CleanPosXYZ.Text = TaskDisp.Needle_Clean_Pos[1].X.ToString("F3") + "," +
                TaskDisp.Needle_Clean_Pos[1].Y.ToString("F3") + "," +
                TaskDisp.Needle_Clean_Pos[1].Z.ToString("F3");
            lbl_NeedleCleanTime.Text = TaskDisp.Needle_Clean_Time.ToString();
            lbl_NeedleCleanWait.Text = TaskDisp.Needle_Clean_Wait.ToString();
            lbl_NeedleCleanCount.Text = TaskDisp.Needle_Clean_Count.ToString();
            lbl_NeedleCleanPostVacTime.Text = TaskDisp.Needle_Clean_PostVacTime.ToString();
            #endregion
            #region Purge
            //lbl_NeedlePurgeUseCleanPos.Text = TaskDisp.Needle_Purge_UseCleanPos.ToString();
            //btn_SetPurgePos.Visible = !TaskDisp.Needle_Purge_UseCleanPos;
            lbl_Needle1PurgePosXYZ.Text = TaskDisp.Needle_Purge_Pos[0].X.ToString("F3") + "," +
                TaskDisp.Needle_Purge_Pos[0].Y.ToString("F3") + "," +
                TaskDisp.Needle_Purge_Pos[0].Z.ToString("F3");
            lbl_Needle2PurgePosXYZ.Text = TaskDisp.Needle_Purge_Pos[1].X.ToString("F3") + "," +
                TaskDisp.Needle_Purge_Pos[1].Y.ToString("F3") + "," +
                TaskDisp.Needle_Purge_Pos[1].Z.ToString("F3");
            lbl_NeedlePurgeTime.Text = TaskDisp.Needle_Purge_Time.ToString();
            lbl_NeedlePurgeWait.Text = TaskDisp.Needle_Purge_Wait.ToString();
            lbl_NeedlePurgeCount.Text = TaskDisp.Needle_Purge_Count.ToString();
            lbl_NeedlePurgePostVacTime.Text = TaskDisp.Needle_Purge_PostVacTime.ToString();
            #endregion
            #region Flush
            //lbl_NeedleFlushUseCleanPos.Text = TaskDisp.Needle_Flush_UseCleanPos.ToString();
            //btn_SetFlushPos.Visible = !TaskDisp.Needle_Flush_UseCleanPos;
            lbl_Needle1FlushPosXYZ.Text = TaskDisp.Needle_Flush_Pos[0].X.ToString("F3") + "," +
                TaskDisp.Needle_Flush_Pos[0].Y.ToString("F3") + "," +
                TaskDisp.Needle_Flush_Pos[0].Z.ToString("F3");
            lbl_Needle2FlushPosXYZ.Text = TaskDisp.Needle_Flush_Pos[1].X.ToString("F3") + "," +
                TaskDisp.Needle_Flush_Pos[1].Y.ToString("F3") + "," +
                TaskDisp.Needle_Flush_Pos[1].Z.ToString("F3");
            lbl_NeedleFlushTime.Text = TaskDisp.Needle_Flush_Time.ToString();
            lbl_NeedleFlushWait.Text = TaskDisp.Needle_Flush_Wait.ToString();
            lbl_NeedleFlushCount.Text = TaskDisp.Needle_Flush_Count.ToString();
            lbl_NeedleFlushPostVacTime.Text = TaskDisp.Needle_Flush_PostVacTime.ToString();
            #endregion
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            TPos3 old = new TPos3(TaskDisp.Needle_Clean_Pos[0]);

            TaskDisp.Needle_Clean_Pos[0].X = TaskGantry.GXPos();
            TaskDisp.Needle_Clean_Pos[0].Y = TaskGantry.GYPos();
            TaskDisp.Needle_Clean_Pos[0].Z = TaskGantry.GZPos() - TaskDisp.Z1Offset;

            TaskDisp.Needle_Clean_Pos[1].X = 0;
            TaskDisp.Needle_Clean_Pos[1].Y = 0;
            TaskDisp.Needle_Clean_Pos[1].Z = 0;

            TaskDisp.TaskMoveGZUp();
            Log.OnSet("Clean Position", old, TaskDisp.Needle_Clean_Pos[0]);
            UpdateDisplay();
        }
        private void btn_Goto_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskGotoCleanNeedlePromtZ(true);
        }

        private void btn_SetPurgePos_Click(object sender, EventArgs e)
        {
            TPos3 old = new TPos3(TaskDisp.Needle_Purge_Pos[0]);

            TaskDisp.Needle_Purge_Pos[0].X = TaskGantry.GXPos();
            TaskDisp.Needle_Purge_Pos[0].Y = TaskGantry.GYPos();
            TaskDisp.Needle_Purge_Pos[0].Z = TaskGantry.GZPos() - TaskDisp.Z1Offset;

            TaskDisp.Needle_Purge_Pos[1].X = 0;
            TaskDisp.Needle_Purge_Pos[1].Y = 0;
            TaskDisp.Needle_Purge_Pos[1].Z = 0;

            TaskDisp.TaskMoveGZUp();
            Log.OnSet("Purge Position", old, TaskDisp.Needle_Purge_Pos[0]);
            UpdateDisplay();
        }
        private void btn_GotoPurgePos_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskGotoPurgeNeedlePrompZ(true);
        }

        private void btn_SetFlushPos_Click(object sender, EventArgs e)
        {
            TPos3 old = new TPos3(TaskDisp.Needle_Flush_Pos[0]);

            TaskDisp.Needle_Flush_Pos[0].X = TaskGantry.GXPos();
            TaskDisp.Needle_Flush_Pos[0].Y = TaskGantry.GYPos();
            TaskDisp.Needle_Flush_Pos[0].Z = TaskGantry.GZPos() - TaskDisp.Z1Offset;

            TaskDisp.Needle_Flush_Pos[1].X = 0;
            TaskDisp.Needle_Flush_Pos[1].Y = 0;
            TaskDisp.Needle_Flush_Pos[1].Z = 0;

            TaskDisp.TaskMoveGZUp();
            Log.OnSet("Flush Position", old, TaskDisp.Needle_Flush_Pos[0]);
            UpdateDisplay();
        }

        private void btn_GotoFlushPos_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskGotoFlushNeedlePrompZ(true);
        }

        private void btn_CleanNeedle_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskCleanNeedle(true);
            TaskDisp.FPressOff();
        }
    
        private void lbl_NeedleCleanTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Clean Time (ms)", ref  TaskDisp.Needle_Clean_Time, 0, 10000);
            
            UpdateDisplay();
        }
        private void lbl_NeedleCleanWait_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Clean Wait (ms)", ref TaskDisp.Needle_Clean_Wait, 0, 5000);
            UpdateDisplay();
        }
        private void lbl_NeedleCleanCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Clean Count", ref TaskDisp.Needle_Clean_Count, 1, 100);
            UpdateDisplay();
        }
        private void lbl_NeedleCleanPostVacTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Neelde Clean Post Vac Time (ms)", ref TaskDisp.Needle_Clean_PostVacTime, 0, 5000);
            UpdateDisplay();
        }

        private void btn_PurgeNeedle_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskPurgeNeedle(true);
            TaskDisp.FPressOff();
        }
        private void lbl_NeedlePurgeTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Purge Time (ms)", ref TaskDisp.Needle_Purge_Time, 0, 10000);
            UpdateDisplay();
        }
        private void lbl_NeedlePurgeWait_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Purge Time (ms)", ref TaskDisp.Needle_Purge_Wait, 0, 5000);
            UpdateDisplay();
        }
        private void lbl_NeedlePurgeCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Purge Count", ref TaskDisp.Needle_Purge_Count, 1, 100);
            UpdateDisplay();
        }
        private void lbl_NeedlePurgePostVacTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Purge Post Vac Time (ms)", ref TaskDisp.Needle_Purge_PostVacTime, 0, 5000);
            UpdateDisplay();
        }

        private void btn_Flush_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskFlushNeedle(true);
            TaskDisp.FPressOff();
        }
        private void lbl_NeedleFlushTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Flush Time (ms)", ref TaskDisp.Needle_Flush_Time, 0, 120000);
            UpdateDisplay();
        }
        private void lbl_NeedleFlushWait_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Flush Time (ms)", ref TaskDisp.Needle_Flush_Wait, 0, 5000);
            UpdateDisplay();
        }
        private void lbl_NeedleFlushCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Flush Count", ref TaskDisp.Needle_Flush_Count, 1, 100);
            UpdateDisplay();
        }
        private void lbl_NeedleFlushPostVacTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Needle Flush Post Vac Time (ms)", ref TaskDisp.Needle_Flush_PostVacTime, 0, 5000);
            UpdateDisplay();
        }

        private void combox_CleanPosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TaskDisp.Needle_Clean_UsePos = combox_CleanPosition.SelectedIndex;
            UpdateDisplay();
        }
        private void combox_FlushPosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TaskDisp.Needle_Flush_UsePos = combox_FlushPosition.SelectedIndex;
            UpdateDisplay();
        }
        private void combox_PurgePosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TaskDisp.Needle_Purge_UsePos = combox_PurgePosition.SelectedIndex;
            UpdateDisplay();
        }

        private void btn_PurgeStage_Click(object sender, EventArgs e)
        {
            frm_DispProg_PurgeStage frm = new frm_DispProg_PurgeStage();
            frm.ShowDialog();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TaskDisp.SaveSetup_IOHandShake();
            TaskDisp.SaveSetup();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_WipeStage_Click(object sender, EventArgs e)
        {
            frm_DispProg_WipeStage frm = new frm_DispProg_WipeStage();
            frm.ShowDialog();
        }
    }
}
