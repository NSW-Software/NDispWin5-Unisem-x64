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
    public partial class frm_DispCore_DrawOfstAdjust : Form
    {
        public frm_DispCore_DrawOfstAdjust()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.Text = "Draw Ofst Adjust";
            btn_XM.TextAlign = ContentAlignment.BottomLeft;
            btn_XP.TextAlign = ContentAlignment.TopRight;

            btn_YM.TextAlign = ContentAlignment.BottomRight;
            btn_YP.TextAlign = ContentAlignment.TopLeft;

            btn_ZM.TextAlign = ContentAlignment.BottomRight;
            btn_ZP.TextAlign = ContentAlignment.TopLeft;


            btn_Close.Visible = true;
        }

        private void frm_DispCore_OriginAdjust_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_DrawOfstX.Text = DispProg.OriginDrawOfst.X.ToString("F3");
            lbl_DrawOfstY.Text = DispProg.OriginDrawOfst.Y.ToString("F3");
            lbl_DrawOfstZ.Text = DispProg.OriginDrawOfst.Z.ToString("F3");

            lbl_DrawOfstX2.Text = DrawOfst_X2.ToString("F3");
            lbl_DrawOfstY2.Text = DrawOfst_Y2.ToString("F3");
            lbl_DrawOfstZ2.Text = DrawOfst_Z2.ToString("F3");

            lbl_DrawAdjustMax.Text = TaskDisp.Option_DrawOfstAdjustLimit_XY.ToString("F3") + " ," + TaskDisp.Option_DrawOfstAdjustLimit_Z.ToString("F3");
            lbl_AdjustRate.Text = TaskDisp.Option_DrawOfstAdjustRate.ToString("F3");
        }

        private void lbl_AdjustRate_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Draw Ofst, Adjust Rate", ref TaskDisp.Option_DrawOfstAdjustRate, 0, 0.1);
            UpdateDisplay();
        }

        private void frm_DispCore_OriginAdjust_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            gbox_X2Y2Z2.Visible = (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2);

            UI_Utils.ButtonDrawArrow(ref btn_XM, UI_Utils.EArrow.XN);
            UI_Utils.ButtonDrawArrow(ref btn_XP, UI_Utils.EArrow.XP);
            UI_Utils.ButtonDrawArrow(ref btn_YM, UI_Utils.EArrow.YN);
            UI_Utils.ButtonDrawArrow(ref btn_YP, UI_Utils.EArrow.YP);
            UI_Utils.ButtonDrawArrow(ref btn_ZM, UI_Utils.EArrow.ZN);
            UI_Utils.ButtonDrawArrow(ref btn_ZP, UI_Utils.EArrow.ZP);

            UI_Utils.ButtonDrawArrow(ref btn_X2N, UI_Utils.EArrow.XN);
            UI_Utils.ButtonDrawArrow(ref btn_X2P, UI_Utils.EArrow.XP);
            UI_Utils.ButtonDrawArrow(ref btn_Y2N, UI_Utils.EArrow.YN);
            UI_Utils.ButtonDrawArrow(ref btn_Y2P, UI_Utils.EArrow.YP);
            UI_Utils.ButtonDrawArrow(ref btn_Z2N, UI_Utils.EArrow.ZN);
            UI_Utils.ButtonDrawArrow(ref btn_Z2P, UI_Utils.EArrow.ZP);
            
            UpdateDisplay();
        }

        private void btn_XM_Click(object sender, EventArgs e)
        {
            DispProg.OriginDrawOfst.X = DispProg.OriginDrawOfst.X - TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DispProg.OriginDrawOfst.X) >= TaskDisp.Option_DrawOfstAdjustLimit_XY)
            {
                DispProg.OriginDrawOfst.X = -TaskDisp.Option_DrawOfstAdjustLimit_XY;
            }
            UpdateDisplay();
        }

        private void btn_XP_Click(object sender, EventArgs e)
        {
            DispProg.OriginDrawOfst.X = DispProg.OriginDrawOfst.X + TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DispProg.OriginDrawOfst.X) >= TaskDisp.Option_DrawOfstAdjustLimit_XY)
            {
                DispProg.OriginDrawOfst.X = TaskDisp.Option_DrawOfstAdjustLimit_XY;
            }
            UpdateDisplay();
        }

        private void btn_YM_Click(object sender, EventArgs e)
        {
            DispProg.OriginDrawOfst.Y = DispProg.OriginDrawOfst.Y - TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DispProg.OriginDrawOfst.Y) >= TaskDisp.Option_DrawOfstAdjustLimit_XY)
            {
                DispProg.OriginDrawOfst.Y = -TaskDisp.Option_DrawOfstAdjustLimit_XY;
            }
            UpdateDisplay();
        }

        private void btn_YP_Click(object sender, EventArgs e)
        {
            DispProg.OriginDrawOfst.Y = DispProg.OriginDrawOfst.Y + TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DispProg.OriginDrawOfst.Y) >= TaskDisp.Option_DrawOfstAdjustLimit_XY)
            {
                DispProg.OriginDrawOfst.Y = TaskDisp.Option_DrawOfstAdjustLimit_XY;
            }
            UpdateDisplay();
        }

        private void btn_ZM_Click(object sender, EventArgs e)
        {
            DispProg.OriginDrawOfst.Z = DispProg.OriginDrawOfst.Z - TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DispProg.OriginDrawOfst.Z) >= TaskDisp.Option_DrawOfstAdjustLimit_Z)
            {
                DispProg.OriginDrawOfst.Z = -TaskDisp.Option_DrawOfstAdjustLimit_Z;
            }
            UpdateDisplay();
        }

        private void btn_ZP_Click(object sender, EventArgs e)
        {
            DispProg.OriginDrawOfst.Z = DispProg.OriginDrawOfst.Z + TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DispProg.OriginDrawOfst.Z) >= TaskDisp.Option_DrawOfstAdjustLimit_Z)
            {
                DispProg.OriginDrawOfst.Z = TaskDisp.Option_DrawOfstAdjustLimit_Z;
            }
            UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (GDefine.GantryConfig == GDefine.EGantryConfig.XY_ZX2Y2_Z2)
            {
                //TaskDisp.Head2_DefPos.X = TaskDisp.Head2_DefPos.X + DrawOfst_X2;
                //TaskDisp.Head2_DefPos.Y = TaskDisp.Head2_DefPos.Y + DrawOfst_Y2;
                TaskDisp.Head2_XOffset = TaskDisp.Head2_XOffset + DrawOfst_X2;
                TaskDisp.Head2_YOffset = TaskDisp.Head2_YOffset + DrawOfst_Y2;
                DrawOfst_X2 = 0;
                DrawOfst_Y2 = 0;

                TaskDisp.Head2_ZOffset = TaskDisp.Head2_ZOffset + DrawOfst_Z2;
                DrawOfst_Z2 = 0;
            }
            
            if (this.Modal)
                this.Close();
            else
                this.Visible = false;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            DispProg.OriginDrawOfst.X = 0;
            DispProg.OriginDrawOfst.Y = 0;
            DispProg.OriginDrawOfst.Z = 0;

            UpdateDisplay();
        }

            double DrawOfst_X2 = 0;
            double DrawOfst_Y2 = 0;
            double DrawOfst_Z2 = 0;
        private void btn_X2N_Click(object sender, EventArgs e)
        {
            DrawOfst_X2 = DrawOfst_X2 - TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DrawOfst_X2) >= TaskDisp.Option_DrawOfstAdjustLimit_XY)
            {
                DrawOfst_X2 = TaskDisp.Option_DrawOfstAdjustLimit_XY;
            }
            UpdateDisplay();
        }

        private void btn_X2P_Click(object sender, EventArgs e)
        {
            DrawOfst_X2 = DrawOfst_X2 + TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DrawOfst_X2) >= TaskDisp.Option_DrawOfstAdjustLimit_XY)
            {
                DrawOfst_X2 = TaskDisp.Option_DrawOfstAdjustLimit_XY;
            }
            UpdateDisplay();
        }

        private void btn_Y2N_Click(object sender, EventArgs e)
        {
            DrawOfst_Y2 = DrawOfst_Y2 - TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DrawOfst_Y2) >= TaskDisp.Option_DrawOfstAdjustLimit_XY)
            {
                DrawOfst_Y2 = TaskDisp.Option_DrawOfstAdjustLimit_XY;
            }
            UpdateDisplay();
        }

        private void btn_Y2P_Click(object sender, EventArgs e)
        {
            DrawOfst_Y2 = DrawOfst_Y2 + TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DrawOfst_Y2) >= TaskDisp.Option_DrawOfstAdjustLimit_XY)
            {
                DrawOfst_Y2 = TaskDisp.Option_DrawOfstAdjustLimit_XY;
            }
            UpdateDisplay();
        }

        private void btn_Z2P_Click(object sender, EventArgs e)
        {
            DrawOfst_Z2 = DrawOfst_Z2 + TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DrawOfst_Z2) >= TaskDisp.Option_DrawOfstAdjustLimit_Z)
            {
                DrawOfst_Z2 = TaskDisp.Option_DrawOfstAdjustLimit_Z;
            }
            UpdateDisplay();
        }

        private void btn_Z2N_Click(object sender, EventArgs e)
        {
            DrawOfst_Z2 = DrawOfst_Z2 - TaskDisp.Option_DrawOfstAdjustRate;
            if (Math.Abs(DrawOfst_Z2) >= TaskDisp.Option_DrawOfstAdjustLimit_Z)
            {
                DrawOfst_Z2 = TaskDisp.Option_DrawOfstAdjustLimit_Z;
            }
            UpdateDisplay();
        }
    }
}
