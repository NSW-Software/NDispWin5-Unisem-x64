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
    internal partial class frm_DispCore_ReticleSetup : Form
    {
        int ReticleIdx = 0;
        public int CamID = 0;

        public frm_DispCore_ReticleSetup()
        {
            InitializeComponent();
            Text = "Reticle Setup";

            combox_ReticleType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TaskVision.EReticleType)).Count(); i++)
            {
                combox_ReticleType.Items.Add(Enum.GetName(typeof(TaskVision.EReticleType), i).ToString());
            }
        }

        private void frmReticleSetup_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (ReticleIdx < 0) return;

            l_gbox_Position.Visible = !(TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.None || 
                TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.CenterCrossHair ||
                TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.CenterReticle);
            l_gbox_Size.Visible = !(TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.None ||
                TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.CenterCrossHair ||
                TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.CenterReticle);
            l_lbl_Text.Visible = (TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.Text);
            lbl_Text.Visible = (TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.Text);
            l_lbl_Scale.Visible = (TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.CenterReticle);
            lbl_Scale.Visible = (TaskVision.Reticles.Type[ReticleIdx] == TaskVision.EReticleType.CenterReticle);

            combox_ReticleType.SelectedIndex = (int)TaskVision.Reticles.Type[ReticleIdx];
            lbl_Color.BackColor = TaskVision.Reticles.Color[ReticleIdx];
            lbl_Color.Text = TaskVision.Reticles.Color[ReticleIdx].Name.ToString();
            lbl_XY.Text = TaskVision.Reticles.Rect[ReticleIdx].X.ToString() + ", " + TaskVision.Reticles.Rect[ReticleIdx].Y.ToString();
            lbl_WH.Text = TaskVision.Reticles.Rect[ReticleIdx].Width.ToString() + ", " + TaskVision.Reticles.Rect[ReticleIdx].Height.ToString();
            lbl_Text.Text = TaskVision.Reticles.Text[ReticleIdx];
            lbl_Scale.Text = TaskVision.Reticles.Scale[ReticleIdx].ToString("F2");

            lbox_Reticle.Items.Clear();
            for (int i = 0; i < TaskVision.Reticles.Count; i++)
            {
                if (TaskVision.Reticles.Type[i] == TaskVision.EReticleType.CenterCrossHair ||
                    TaskVision.Reticles.Type[i] == TaskVision.EReticleType.CenterReticle)
                {
                    lbox_Reticle.Items.Add(TaskVision.Reticles.Type[i].ToString() + ", " + 
                        TaskVision.Reticles.Color[i].Name.ToString());
                }
                else
                {
                    lbox_Reticle.Items.Add(TaskVision.Reticles.Type[i].ToString() + ", " +
                        TaskVision.Reticles.Color[i].Name.ToString() + ", " +
                        "(" + TaskVision.Reticles.Rect[i].X.ToString() + ", " +
                        TaskVision.Reticles.Rect[i].Y.ToString() + ", " +
                        TaskVision.Reticles.Rect[i].Width.ToString() + ", " +
                        TaskVision.Reticles.Rect[i].Height.ToString() + ")"
                        );
                }
            }

            btn_Step.Text = i_StepSize.ToString();
        }

        private void combox_ReticleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskVision.Reticles.Type[ReticleIdx] = (TaskVision.EReticleType)combox_ReticleType.SelectedIndex;
            UpdateDisplay();
            lbox_Reticle.SelectedIndex = ReticleIdx;
        }

        private void lbl_Color_Click(object sender, EventArgs e)
        {
            if (ReticleIdx < 0) return;

            colorDialog.SolidColorOnly = true;
            colorDialog.AnyColor = false;
            colorDialog.AllowFullOpen = false;
            colorDialog.Color = TaskVision.Reticles.Color[ReticleIdx];
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                TaskVision.Reticles.Color[ReticleIdx] = colorDialog.Color;
            }
            UpdateDisplay();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            int idx = lbox_Reticle.SelectedIndex;
            if (idx < 0) return;

            if (idx == TaskVision.Reticles.Count - 1)
            {
                ReticleIdx--;
                lbox_Reticle.SelectedIndex = ReticleIdx;
            }
            else
            for (int i = idx; i < TaskVision.Reticles.Count; i++)
            {
                TaskVision.Reticles.Type[i] = TaskVision.Reticles.Type[i + 1];
                TaskVision.Reticles.Color[i] = TaskVision.Reticles.Color[i + 1];
                TaskVision.Reticles.Rect[i] = TaskVision.Reticles.Rect[i + 1];
            }
            TaskVision.Reticles.Count--;
            UpdateDisplay();
            lbox_Reticle.SelectedIndex = ReticleIdx;
        }

        private void lbox_Reticle_Click(object sender, EventArgs e)
        {
            if (ReticleIdx < 0) return;

            ReticleIdx = lbox_Reticle.SelectedIndex;
            //if (ReticleIdx < 0) ReticleIdx = -1;
            UpdateDisplay();
            lbox_Reticle.SelectedIndex = ReticleIdx;
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            if (TaskVision.Reticles.Count >= 10) return; 

            TaskVision.Reticles.Count++;
            ReticleIdx = TaskVision.Reticles.Count - 1;
            UpdateDisplay();
            lbox_Reticle.SelectedIndex = ReticleIdx;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TaskVision.SaveSetup();
        }

        int i_StepSize = 1;
        private void btn_XN_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (TaskVision.Reticles.Rect[ReticleIdx].X > 0) TaskVision.Reticles.Rect[ReticleIdx].X -= i_StepSize;
            UpdateDisplay();
        }
        private void btn_XN_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private void btn_XP_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (TaskVision.Reticles.Rect[ReticleIdx].X < TaskVision.ImgWN[CamID]) TaskVision.Reticles.Rect[ReticleIdx].X += i_StepSize;
            UpdateDisplay();
        }
        private void btn_XP_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_YN_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (TaskVision.Reticles.Rect[ReticleIdx].Y > 0) TaskVision.Reticles.Rect[ReticleIdx].Y -= i_StepSize;
            UpdateDisplay();
        }
        private void btn_YN_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private void btn_YP_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (TaskVision.Reticles.Rect[ReticleIdx].Y < TaskVision.ImgHN[CamID]) TaskVision.Reticles.Rect[ReticleIdx].Y += i_StepSize;
            UpdateDisplay();
        }
        private void btn_YP_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_C_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            TaskVision.Reticles.Rect[ReticleIdx].X = (int)(TaskVision.ImgWN[CamID] / 2);
            TaskVision.Reticles.Rect[ReticleIdx].Y = (int)(TaskVision.ImgHN[CamID] / 2);
            UpdateDisplay();
        }
        private void btn_WN_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (TaskVision.Reticles.Rect[ReticleIdx].Width > 0) TaskVision.Reticles.Rect[ReticleIdx].Width -= i_StepSize;
            UpdateDisplay();
        }
        private void btn_WN_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_WP_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (TaskVision.Reticles.Rect[ReticleIdx].Width < TaskVision.ImgWN[CamID]) TaskVision.Reticles.Rect[ReticleIdx].Width += i_StepSize;
            UpdateDisplay();
        }
        private void btn_WP_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_HN_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (TaskVision.Reticles.Rect[ReticleIdx].Height > 0) TaskVision.Reticles.Rect[ReticleIdx].Height -= i_StepSize;
            UpdateDisplay();
        }
        private void btn_HN_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_HP_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (TaskVision.Reticles.Rect[ReticleIdx].Height < TaskVision.ImgHN[CamID]) TaskVision.Reticles.Rect[ReticleIdx].Height += i_StepSize;
            UpdateDisplay();
        }
        private void btn_HP_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Step_Click(object sender, EventArgs e)
        {
            switch (i_StepSize)
            {
                case 1: i_StepSize = 5; break;
                case 5: i_StepSize = 10; break;
                default: i_StepSize = 1; break;
            }
            UpdateDisplay();
        }

        private void lbl_Text_Click(object sender, EventArgs e)
        {
            if (ReticleIdx < 0) return;
            UC.EntryExec("Reticle Setup, Text", ref TaskVision.Reticles.Text[ReticleIdx], false);
            UpdateDisplay();
        }

        private void lbl_Scale_Click(object sender, EventArgs e)
        {
            if (ReticleIdx < 0) return;
            double d = Math.Round(TaskVision.Reticles.Scale[ReticleIdx], 2);
            UC.AdjustExec("Reticle Setup, Scale", ref d, 0.01, 2);
            TaskVision.Reticles.Scale[ReticleIdx] = d;
            UpdateDisplay();
        }

        private void btn_XP_Click(object sender, EventArgs e)
        {

        }
    }
}
