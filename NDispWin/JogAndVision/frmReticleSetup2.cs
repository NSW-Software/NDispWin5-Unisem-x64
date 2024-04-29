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
    internal partial class frm_ReticleSetup2 : Form
    {
        public TReticles Reticles = new TReticles();
        public int ImageW = 1440;
        public int ImageH = 1040;

        int ReticleIdx = -1;

        public frm_ReticleSetup2()
        {
            InitializeComponent();
            Text = "Reticle Setup";

            combox_ReticleType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TReticle2.EType)).Count(); i++)
            {
                combox_ReticleType.Items.Add(Enum.GetName(typeof(TReticle2.EType), i).ToString());
            }
        }

        private void frmReticleSetup_Load(object sender, EventArgs e)
        {
            ReticleIdx = 0;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (ReticleIdx < 0) return;

            l_gbox_Position.Visible = !(Reticles.Reticle[ReticleIdx].Type == TReticle2.EType.None ||
              Reticles.Reticle[ReticleIdx].Type == TReticle2.EType.CenterCross);
            l_gbox_Size.Visible = !(Reticles.Reticle[ReticleIdx].Type == TReticle2.EType.None ||
                Reticles.Reticle[ReticleIdx].Type == TReticle2.EType.CenterCross);
            l_lbl_Text.Visible = (Reticles.Reticle[ReticleIdx].Type == TReticle2.EType.Text);
            tbox_Text.Visible = (Reticles.Reticle[ReticleIdx].Type == TReticle2.EType.Text);

            combox_ReticleType.SelectedIndex = (int)Reticles.Reticle[ReticleIdx].Type;
            lbl_Color.BackColor = Reticles.Reticle[ReticleIdx].Color;
            lbl_Color.Text = Reticles.Reticle[ReticleIdx].Color.Name.ToString();
            lbl_XY.Text = Reticles.Reticle[ReticleIdx].Location.X.ToString() + ", " + Reticles.Reticle[ReticleIdx].Location.Y.ToString();
            lbl_WH.Text = Reticles.Reticle[ReticleIdx].Size.Width.ToString() + ", " + Reticles.Reticle[ReticleIdx].Size.Height.ToString();
            tbox_Text.Text = Reticles.Reticle[ReticleIdx].Text;

            lbox_Reticle.Items.Clear();
            for (int i = 0; i < TReticles.MAX_RETICLES; i++)
            {
                if (Reticles.Reticle[i].Size.Width <= 0) Reticles.Reticle[i].Size.Width = 50;
                if (Reticles.Reticle[i].Size.Height <= 0) Reticles.Reticle[i].Size.Height = 50;

                if (Reticles.Reticle[i].Type == TReticle2.EType.CenterCross)
                {
                    lbox_Reticle.Items.Add(Reticles.Reticle[i].Type.ToString() + ", " +
                        Reticles.Reticle[i].Color.Name.ToString());
                }
                else
                if (Reticles.Reticle[i].Type == TReticle2.EType.None)
                {
                    lbox_Reticle.Items.Add(Reticles.Reticle[i].Type.ToString());
                }
                else
                {
                    lbox_Reticle.Items.Add(Reticles.Reticle[i].Type.ToString() + ", " +
                        Reticles.Reticle[i].Color.Name.ToString() + ", " +
                        "(" +
                        Reticles.Reticle[i].Location.X.ToString() + ", " +
                        Reticles.Reticle[i].Location.Y.ToString() + ", " +
                        Reticles.Reticle[i].Size.Width.ToString() + ", " +
                        Reticles.Reticle[i].Size.Height.ToString() + ")"
                        );
                }
            }

            btn_Step.Text = i_StepSize.ToString();
            btn_SizeMode.Text = b_SizeCenterMode ? "C" : "S";
        }

        private void combox_ReticleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Reticles.Count <= 0) return;
            ReticleIdx = Math.Max(0, ReticleIdx);

            Reticles.Reticle[ReticleIdx].Type = (TReticle2.EType)combox_ReticleType.SelectedIndex;
            UpdateDisplay();
            //lbox_Reticle.SelectedIndex = ReticleIdx;
        }

        private void lbl_Color_Click(object sender, EventArgs e)
        {
            if (ReticleIdx < 0) return;

            colorDialog.SolidColorOnly = true;
            colorDialog.AnyColor = false;
            colorDialog.AllowFullOpen = false;
            colorDialog.Color = Reticles.Reticle[ReticleIdx].Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Reticles.Reticle[ReticleIdx].Color = colorDialog.Color;
            }
            UpdateDisplay();
        }
        private void lbox_Reticle_Click(object sender, EventArgs e)
        {
            if (ReticleIdx < 0) return;

            ReticleIdx = lbox_Reticle.SelectedIndex;
            //if (ReticleIdx < 0) ReticleIdx = -1;
            UpdateDisplay();
            lbox_Reticle.SelectedIndex = ReticleIdx;
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
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbox_Text_TextChanged(object sender, EventArgs e)
        {
            if (ReticleIdx < 0) return;

            Reticles.Reticle[ReticleIdx].Text = tbox_Text.Text;
            UpdateDisplay();
        }

        int i_StepSize = 1;
        bool b_SizeCenterMode = false;
        private void btn_XN_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (Reticles.Reticle[ReticleIdx].Location.X > 0) Reticles.Reticle[ReticleIdx].Location.X -= i_StepSize;
            b_SizeCenterMode = false;
            UpdateDisplay();
        }
        private void btn_XN_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private void btn_XP_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (Reticles.Reticle[ReticleIdx].Location.X < ImageW) Reticles.Reticle[ReticleIdx].Location.X += i_StepSize;
            b_SizeCenterMode = false;
            UpdateDisplay();
        }
        private void btn_XP_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_YN_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (Reticles.Reticle[ReticleIdx].Location.Y > 0) Reticles.Reticle[ReticleIdx].Location.Y -= i_StepSize;
            b_SizeCenterMode = false;
            UpdateDisplay();
        }
        private void btn_YN_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private void btn_YP_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;
            if (Reticles.Reticle[ReticleIdx].Location.Y < ImageH) Reticles.Reticle[ReticleIdx].Location.Y += i_StepSize;
            b_SizeCenterMode = false;
            UpdateDisplay();
        }
        private void btn_YP_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btn_WN_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;

            if (b_SizeCenterMode)
                if (Reticles.Reticle[ReticleIdx].Location.X > 0) Reticles.Reticle[ReticleIdx].Location.X += ((float)i_StepSize / 2);

            if (Reticles.Reticle[ReticleIdx].Size.Width > 0) Reticles.Reticle[ReticleIdx].Size.Width -= i_StepSize;
            UpdateDisplay();
        }
        private void btn_WN_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_WP_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;

            if (b_SizeCenterMode)
                if (Reticles.Reticle[ReticleIdx].Location.X < ImageW) Reticles.Reticle[ReticleIdx].Location.X -= ((float)i_StepSize / 2);

            if (Reticles.Reticle[ReticleIdx].Size.Width < ImageW) Reticles.Reticle[ReticleIdx].Size.Width += i_StepSize;
            UpdateDisplay();
        }
        private void btn_WP_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_HN_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;

            if (b_SizeCenterMode)
                if (Reticles.Reticle[ReticleIdx].Location.Y > 0) Reticles.Reticle[ReticleIdx].Location.Y += ((float)i_StepSize / 2);

            if (Reticles.Reticle[ReticleIdx].Size.Height > 0) Reticles.Reticle[ReticleIdx].Size.Height -= i_StepSize;
            UpdateDisplay();
        }
        private void btn_HN_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btn_HP_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReticleIdx < 0) return;

            if (b_SizeCenterMode)
                if (Reticles.Reticle[ReticleIdx].Location.Y < ImageH) Reticles.Reticle[ReticleIdx].Location.Y -= ((float)i_StepSize / 2);

            if (Reticles.Reticle[ReticleIdx].Size.Height < ImageH) Reticles.Reticle[ReticleIdx].Size.Height += i_StepSize;
            UpdateDisplay();
        }
        private void btn_HP_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btn_SizeMode_Click(object sender, EventArgs e)
        {
            b_SizeCenterMode = !b_SizeCenterMode;
            UpdateDisplay();
        }
        private void btn_Center_Click(object sender, EventArgs e)
        {
            if (ReticleIdx < 0) return;

            Reticles.Reticle[ReticleIdx].Location.X = ((ImageW - Reticles.Reticle[ReticleIdx].Size.Width) / 2);
            Reticles.Reticle[ReticleIdx].Location.Y = ((ImageH - Reticles.Reticle[ReticleIdx].Size.Height) / 2);
            b_SizeCenterMode = true;
            UpdateDisplay();
        }

        private void lbox_Reticle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
