using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    public partial class frm_DispCore_DispSetup_Weight : Form
    {
        public frm_DispCore_DispSetup_Weight()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_DispCore_DispSetup_Weight_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
        }
        private void frm_DispCore_DispSetup_Weight_Shown(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispSetup_Weight_Activated(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispSetup_Weight_VisibleChanged(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            //l_gbox_Weight.Visible = ((int)GDefine.WeightStType > 0);
            //lbl_Needle1WeightPosXYZ.Text = TaskDisp.Needle_Weight_Pos[0].X.ToString("F3") + "," +
            //    TaskDisp.Needle_Weight_Pos[0].Y.ToString("F3") + "," +
            //    TaskDisp.Needle_Weight_Pos[0].Z.ToString("F3");
            //lbl_Needle2WeightPosZ2.Text = TaskDisp.Needle_Weight_Pos[1].Z.ToString("F3");
            
            lbl_WeightProgram1.Text = TaskDisp.WeightProgramName[0];
            lbl_WeightProgram2.Text = TaskDisp.WeightProgramName[1];
            lbl_WeightProgram1Head.Text = TaskDisp.WeightProgramHead[0].ToString();
            lbl_WeightProgram2Head.Text = TaskDisp.WeightProgramHead[1].ToString();

            if (TaskDisp.WeightProgramName[0].Length > 0 && !File.Exists(GDefine.ProgPath + "\\" + TaskDisp.WeightProgramName[0] + "." + GDefine.ProgExt))
                lbl_WeightProgram1.BackColor = Color.Red;
            else
                lbl_WeightProgram1.BackColor = Color.White;

            if (TaskDisp.WeightProgramName[1].Length > 0 && !File.Exists(GDefine.ProgPath + "\\" + TaskDisp.WeightProgramName[1] + "." + GDefine.ProgExt))
                lbl_WeightProgram2.BackColor = Color.Red;
            else
                lbl_WeightProgram2.BackColor = Color.White;
        }

        //private void btn_SetNeedleWeightPos_Click(object sender, EventArgs e)
        //{
        //    TaskDisp.Needle_Weight_Pos[0].X = TaskGantry.GXPos();
        //    TaskDisp.Needle_Weight_Pos[0].Y = TaskGantry.GYPos();
        //    TaskDisp.Needle_Weight_Pos[0].Z = TaskGantry.GZPos();

        //    if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
        //    {
        //        //TaskDisp.Needle_Weight_Pos[1].X = TaskGantry.GX2Pos() - TaskDisp.Head2_DefDistX;
        //        //TaskDisp.Needle_Weight_Pos[1].Y = TaskGantry.GY2Pos();
        //        //TaskDisp.Needle_Weight_Pos[1].Z = 0;// TaskGantry.GZ2Pos();
        //    }
        //    else
        //    {
        //        TaskDisp.Needle_Weight_Pos[1].X = 0;
        //        TaskDisp.Needle_Weight_Pos[1].Y = 0;
        //        TaskDisp.Needle_Weight_Pos[1].Z = 0;
        //    }
        //    TaskDisp.TaskMoveGZZ2Up();
        //    UpdateDisplay();
        //}
        //private void btn_GotoNeedleWeightPos_Click(object sender, EventArgs e)
        //{
        //    TaskDisp.TaskGotoWeight(1, true);
        //}
        //private void btn_SetNeedle2WeightPos_Click(object sender, EventArgs e)
        //{
        //    if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
        //    {
        //        TaskDisp.Needle_Weight_Pos[1].Z = TaskGantry.GZ2Pos();
        //    }
        //    TaskDisp.TaskMoveGZZ2Up();
        //    UpdateDisplay();
        //}
        //private void btn_GotoNeedle2WeightPos_Click(object sender, EventArgs e)
        //{
        //    TaskDisp.TaskGotoWeight(2, true);
        //}

        private void lbl_WeightProgram1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = GDefine.ProgPath;
            ofd.Filter = "Program|*.prg";
            ofd.FileName = GDefine.ProgRecipeName;
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.Cancel) return;

            TaskDisp.WeightProgramName[0] = Path.GetFileNameWithoutExtension(ofd.FileName);

            UpdateDisplay();
        }
        private void lbl_WeightProgram2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = GDefine.ProgPath;
            ofd.Filter = "Program|*.prg";
            ofd.FileName = GDefine.ProgRecipeName;
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.Cancel) return;

            TaskDisp.WeightProgramName[1] = Path.GetFileNameWithoutExtension(ofd.FileName);

            UpdateDisplay();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            TaskDisp.WeightProgramName[0] = "";
            TaskDisp.WeightProgramName[1] = "";
            TaskDisp.WeightProgramHead[0] = EHeadNo.Head1;
            TaskDisp.WeightProgramHead[1] = EHeadNo.Head1;
            UpdateDisplay();
        }

        private void lbl_WeightProgram1Head_Click(object sender, EventArgs e)
        {
            if (TaskDisp.WeightProgramHead[0] == EHeadNo.Head12)
                TaskDisp.WeightProgramHead[0] = EHeadNo.Head1;
            else
                TaskDisp.WeightProgramHead[0]++;
            UpdateDisplay();
        }

        private void lbl_WeightProgram2Head_Click(object sender, EventArgs e)
        {
            if (TaskDisp.WeightProgramHead[1] == EHeadNo.Head12)
                TaskDisp.WeightProgramHead[1] = EHeadNo.Head1;
            else
                TaskDisp.WeightProgramHead[1]++;
            UpdateDisplay();
        }

        private void btn_GotoNeedleWeightPos_Click(object sender, EventArgs e)
        {

        }
    }
}
