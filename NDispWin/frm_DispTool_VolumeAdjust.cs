using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NDispWin
{
    public partial class frm_DispTool_VolumeAdjust : Form
    {
        public bool SettingMode = false;
        public enum EAdjustUnit { ul, ms };
        public EAdjustUnit AdjustUnit = EAdjustUnit.ul;

        public double[] dispVolAdj = new double[] { DispProg.PP_HeadA_DispBaseVol, DispProg.PP_HeadB_DispBaseVol };
        public double[] dispBaseVol = new double[] { DispProg.PP_HeadA_DispVol_Adj, DispProg.PP_HeadB_DispVol_Adj };
        public double[] dispBacksuckVol = new double[] { DispProg.PP_HeadA_BackSuckVol, DispProg.PP_HeadB_BackSuckVol };

        public frm_DispTool_VolumeAdjust()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void frm_DispTool_VolumeAdjust_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            Text = "Dispense Parameters";

            #region Lextar customized
            if (!SettingMode && TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.Lextar_FrontTestCloseLoop)
            {
                bool b_Lextar_AutoMode = Lextar_FrontTestCloseLoop.Mode == Lextar_FrontTestCloseLoop.EMode.Auto;

                lbl_HeadA_AdjVal.Enabled = !b_Lextar_AutoMode;
                btn_HeadA_M.Enabled = !b_Lextar_AutoMode;
                btn_HeadA_P.Enabled = !b_Lextar_AutoMode;
                lbl_HeadA_AdjPcnt.Enabled = !b_Lextar_AutoMode;
                lbl_HeadB_AdjVal.Enabled = !b_Lextar_AutoMode;
                btn_HeadB_M.Enabled = !b_Lextar_AutoMode;
                btn_HeadB_P.Enabled = !b_Lextar_AutoMode;
                lbl_HeadB_AdjPcnt.Enabled = !b_Lextar_AutoMode;

                btn_CopyA.Enabled = !b_Lextar_AutoMode;
            }
            #endregion

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_FrameCount.Text = Stats.BoardCount.ToString();

            int t = GDefine.GetTickCount() - Stats.StartTime;
            lbl_Runtime.Text = ((double)t / 60000).ToString("f1");

            gbox_Settings.Visible = SettingMode;
            lbl_HeadA_BackSuck.Enabled = SettingMode;
            lbl_HeadB_BackSuck.Enabled = SettingMode;

            lbl_HeadABase.Enabled = SettingMode;
            lbl_HeadBBase.Enabled = SettingMode;

            string s_DispUnit = "(" + AdjustUnit.ToString() + ")";
            lbl_l_HeadABackSuckUnit.Text = s_DispUnit;
            lbl_l_HeadAVolCompUnit.Text = s_DispUnit;

            string ValueFormat = TaskDisp.VolumeDisplayDecimalPoint;
            if (AdjustUnit == EAdjustUnit.ms) ValueFormat = "f0";

            lbl_HeadABase.Text = DispProg.PP_HeadA_DispBaseVol.ToString(ValueFormat);
            lbl_HeadBBase.Text = DispProg.PP_HeadB_DispBaseVol.ToString(ValueFormat);

            lbl_HeadABaseAdjust.Visible = TaskDisp.Preference == TaskDisp.EPreference.Lextar;
            lbl_HeadBBaseAdjust.Visible = TaskDisp.Preference == TaskDisp.EPreference.Lextar;
            lbl_HeadABaseAdjust.Text = (DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj).ToString(ValueFormat);
            lbl_HeadBBaseAdjust.Text = (DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj).ToString(ValueFormat);

            lbl_HeadA_AdjVal.Text = DispProg.PP_HeadA_DispVol_Adj.ToString(ValueFormat);
            lbl_HeadB_AdjVal.Text = DispProg.PP_HeadB_DispVol_Adj.ToString(ValueFormat);

            lbl_HeadA_AdjPcnt.Text = (DispProg.PP_HeadA_DispVol_Adj / DispProg.PP_HeadA_DispBaseVol * 100).ToString("f1");
            lbl_HeadB_AdjPcnt.Text = (DispProg.PP_HeadB_DispVol_Adj / DispProg.PP_HeadB_DispBaseVol * 100).ToString("f1");

            double DispA_Vol_ul = DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj;
            double DispB_Vol_ul = DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj;

            double DispA_Ofst = DispProg.rt_Head1VolumeOfst;
            double DispB_Ofst = DispProg.rt_Head2VolumeOfst;
            if (DispProg.rt_VolumeMap.Enabled)
            {
                DispProg.GetVolumeMapOffset(ref DispA_Ofst, ref DispB_Ofst);
            }

            DispA_Vol_ul = DispA_Vol_ul + DispA_Ofst - DispProg.PP_HeadA_BackSuckVol;
            DispB_Vol_ul = DispB_Vol_ul + DispB_Ofst - DispProg.PP_HeadB_BackSuckVol;

            lbl_HeadAOffset.Text = DispA_Ofst.ToString(ValueFormat);
            lbl_HeadBOffset.Text = DispB_Ofst.ToString(ValueFormat);

            lbl_HeadA_BackSuck.Text = DispProg.PP_HeadA_BackSuckVol.ToString(ValueFormat);
            lbl_HeadB_BackSuck.Text = DispProg.PP_HeadB_BackSuckVol.ToString(ValueFormat);

            lbl_HeadACurrent.Text = DispA_Vol_ul.ToString(ValueFormat);
            lbl_HeadBCurrent.Text = DispB_Vol_ul.ToString(ValueFormat);

            pnl_VolCompA.Visible = DispProg.rt_VolComp.Count > 0;
            lbl_HeadA_VolComp.Visible = DispProg.rt_VolComp.Count > 0;
            lbl_HeadB_VolComp.Visible = DispProg.rt_VolComp.Count > 0;
            double CompA = 0;
            double CompB = 0;
            DispProg.PP_VolComp.Get(0, ref CompA, ref CompB);
            lbl_HeadA_VolComp.Text = CompA.ToString(ValueFormat);
            lbl_HeadB_VolComp.Text = CompB.ToString(ValueFormat);

            lbl_HeadA_Ratio.Text = DispProg.PP_Head_VolumeRatio[0].ToString(TaskDisp.VolumeDisplayDecimalPoint);
            lbl_HeadB_Ratio.Text = DispProg.PP_Head_VolumeRatio[1].ToString(TaskDisp.VolumeDisplayDecimalPoint);

            lbl_AdjustTol.Text = DispProg.PP_Head_DispOffsetTol.ToString();
            lbl_AdjustReso.Text = DispProg.PP_Head_DispAdjustReso.ToString();

            pnl_FPress.Visible = FPressCtrl.Enabled;
            lbl_FPressA.Visible = FPressCtrl.Enabled;
            lbl_FPressB.Visible = FPressCtrl.Enabled;
            if (FPressCtrl.Enabled)
            {
                lbl_FPressUnit.Text = "(" + FPressCtrl.PressUnitStr.ToString() + ")";
                lbl_FPressA.Text = FPressCtrl.GetPress(DispProg.FPress[0]).ToString("f1");
                lbl_FPressB.Text = FPressCtrl.GetPress(DispProg.FPress[1]).ToString("f1");
            }
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            gbox_VolumeOfst.Visible = DispProg.rt_VolumeOfst || (TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.Lextar_FrontTestCloseLoop);
            int VolumeOfstFileCount = -1;
            try
            {
                VolumeOfstFileCount = DispProg.DoVolumeOfst_FileCount();
            }
            catch { }

            if (VolumeOfstFileCount >= 0)
            {
                lbl_Online.Text = "Online";
                lbl_Online.BackColor = Color.Lime;
            }
            else
            {
                lbl_Online.Text = "Offline";
                lbl_Online.BackColor = Color.Red;
            }

            lbl_Mode.Text = DispProg.rt_VolumeOfst_Mode.ToString();

            if (TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.AOT_HeightCloseLoop)
            {
                if (VolumeOfstFileCount > 0)
                    btn_Update.BackColor = Color.Lime;
                else
                    btn_Update.BackColor = this.BackColor;
            }
        }

        #region HeadA and HeadB
        private void lbl_HeadABase_Click(object sender, EventArgs e)
        {
            double d_MinVol_ul = 0;// DispProg.PP_HeadA_Min_Volume; ;
            double d_MaxVol_ul = TaskDisp.MaxAmount();// DispProg.PP_HeadA_Max_Volume;
            if (AdjustUnit == EAdjustUnit.ms) d_MaxVol_ul = 30000;

            DispProg.PP_HeadA_DispBaseVol = Math.Round(DispProg.PP_HeadA_DispBaseVol, TaskDisp.Option_VolumeDisplayDecimalPoint);

            if (UC.AdjustExec("Volume Adjust, Head 1 Base", ref DispProg.PP_HeadA_DispBaseVol, d_MinVol_ul, d_MaxVol_ul))
            {
                DispProg.PP_HeadA_DispVol_Adj = 0;
                UpdateDisplay();
            }
        }
        private void lbl_HeadBBase_Click(object sender, EventArgs e)
        {
            double d_MinVol_ul = 0;// DispProg.PP_HeadA_Min_Volume; ;
            double d_MaxVol_ul = TaskDisp.MaxAmount();// DispProg.PP_HeadA_Max_Volume;
            if (AdjustUnit == EAdjustUnit.ms) d_MaxVol_ul = 30000;

            DispProg.PP_HeadB_DispBaseVol = Math.Round(DispProg.PP_HeadB_DispBaseVol, TaskDisp.Option_VolumeDisplayDecimalPoint);

            if (UC.AdjustExec("Volume Adjust, Head 2 Base", ref DispProg.PP_HeadB_DispBaseVol, d_MinVol_ul, d_MaxVol_ul))
            {
                DispProg.PP_HeadB_DispVol_Adj = 0;
                UpdateDisplay();
            }
        }

        private void lbl_HeadAAdjVal_Click(object sender, EventArgs e)
        {
            double d_Adj_ul = 0.169;
            try
            {
                d_Adj_ul = DispProg.PP_HeadA_DispBaseVol * (double)DispProg.PP_Head_DispOffsetTol / 100;
                d_Adj_ul = Math.Max(0.001, Math.Round(d_Adj_ul, 3));
            }
            catch { };

            DispProg.PP_HeadA_DispVol_Adj = Math.Round(DispProg.PP_HeadA_DispVol_Adj, TaskDisp.Option_VolumeDisplayDecimalPoint);
            if (UC.AdjustExec("Volume Adjust, Head 1 Adj Val", ref DispProg.PP_HeadA_DispVol_Adj, -d_Adj_ul, d_Adj_ul))
            {
                UpdateDisplay();
            }
        }
        private void lbl_HeadBAdjVal_Click(object sender, EventArgs e)
        {
            double d_Adj_ul = 0.169;
            try
            {
                d_Adj_ul = DispProg.PP_HeadB_DispBaseVol * (double)DispProg.PP_Head_DispOffsetTol / 100;
                d_Adj_ul = Math.Max(0.001, Math.Round(d_Adj_ul, 3));
            }
            catch { };

            DispProg.PP_HeadB_DispVol_Adj = Math.Round(DispProg.PP_HeadB_DispVol_Adj, TaskDisp.Option_VolumeDisplayDecimalPoint);
            if (UC.AdjustExec("Volume Adjust, Head 2 Adj Val", ref DispProg.PP_HeadB_DispVol_Adj, -d_Adj_ul, d_Adj_ul))
            {
                UpdateDisplay();
            }
        }

        private void lbl_HeadAAdjPcnt_Click(object sender, EventArgs e)
        {
            double d_Adj_Pcnt = DispProg.PP_Head_DispOffsetTol;

            double HA_AdjPcnt = Math.Round((DispProg.PP_HeadA_DispVol_Adj / DispProg.PP_HeadA_DispBaseVol * 100), 1);
            if (UC.AdjustExec("Volume Adjust, Head 1 Adj (%)", ref HA_AdjPcnt, -d_Adj_Pcnt, d_Adj_Pcnt))
            {
                DispProg.PP_HeadA_DispVol_Adj = DispProg.PP_HeadA_DispBaseVol * (HA_AdjPcnt / 100);
                UpdateDisplay();
            }
        }
        private void lbl_HeadBAdjPcnt_Click(object sender, EventArgs e)
        {
            double d_Adj_Pcnt = DispProg.PP_Head_DispOffsetTol;

            double HB_AdjPcnt = Math.Round((DispProg.PP_HeadB_DispVol_Adj / DispProg.PP_HeadB_DispBaseVol * 100), 1);
            if (UC.AdjustExec("Volume Adjust, Head 2 Adj (%)", ref HB_AdjPcnt, -d_Adj_Pcnt, d_Adj_Pcnt))
            {
                DispProg.PP_HeadB_DispVol_Adj = DispProg.PP_HeadB_DispBaseVol * (HB_AdjPcnt / 100);
                UpdateDisplay();
            }
        }

        private void btn_CopyA_Click(object sender, EventArgs e)
        {
            DispProg.PP_HeadB_DispBaseVol = DispProg.PP_HeadA_DispBaseVol;
            DispProg.PP_HeadB_DispVol_Adj = DispProg.PP_HeadA_DispVol_Adj;
            if (SettingMode)
            {
                if (DispProg.PP_HeadB_BackSuckVol != DispProg.PP_HeadA_BackSuckVol)
                {
                    DispProg.PP_HeadB_BackSuckVol = DispProg.PP_HeadA_BackSuckVol;
                }
            }
            UpdateDisplay();
        }

        private void btn_HA_M_Click(object sender, EventArgs e)
        {
            double Limit = DispProg.PP_HeadA_DispBaseVol * (double)DispProg.PP_Head_DispOffsetTol / 100;
            Limit = Math.Max(0.001, Math.Round(Limit, 3));
            if (DispProg.PP_HeadA_DispVol_Adj - DispProg.PP_Head_DispAdjustReso >= -Limit)
            {
                DispProg.PP_HeadA_DispVol_Adj = DispProg.PP_HeadA_DispVol_Adj - DispProg.PP_Head_DispAdjustReso;
            }
            else
            {
                DispProg.PP_HeadA_DispVol_Adj = -Limit;
            }
            UpdateDisplay();
        }
        private void btn_HA_P_Click(object sender, EventArgs e)
        {
            double Limit = DispProg.PP_HeadA_DispBaseVol * (double)DispProg.PP_Head_DispOffsetTol / 100;
            Limit = Math.Max(0.001, Math.Round(Limit, 3));
            if (DispProg.PP_HeadA_DispVol_Adj + DispProg.PP_Head_DispAdjustReso <= Limit)
            {
                DispProg.PP_HeadA_DispVol_Adj = DispProg.PP_HeadA_DispVol_Adj + DispProg.PP_Head_DispAdjustReso;
            }
            else
            {
                DispProg.PP_HeadA_DispVol_Adj = Limit;
            }
            UpdateDisplay();
        }

        private void btn_HB_M_Click(object sender, EventArgs e)
        {
            double Limit = DispProg.PP_HeadB_DispBaseVol * (double)DispProg.PP_Head_DispOffsetTol / 100;
            Limit = Math.Max(0.001, Math.Round(Limit, 3));
            if (DispProg.PP_HeadB_DispVol_Adj - DispProg.PP_Head_DispAdjustReso >= -Limit)
            {
                DispProg.PP_HeadB_DispVol_Adj = DispProg.PP_HeadB_DispVol_Adj - DispProg.PP_Head_DispAdjustReso;
            }
            else
            {
                DispProg.PP_HeadB_DispVol_Adj = -Limit;
            }
            UpdateDisplay();
        }
        private void btn_HB_P_Click(object sender, EventArgs e)
        {
            double Limit = DispProg.PP_HeadB_DispBaseVol * (double)DispProg.PP_Head_DispOffsetTol / 100;
            Limit = Math.Max(0.001, Math.Round(Limit, 3));
            if (DispProg.PP_HeadB_DispVol_Adj + DispProg.PP_Head_DispAdjustReso <= Limit)
            {
                DispProg.PP_HeadB_DispVol_Adj = DispProg.PP_HeadB_DispVol_Adj + DispProg.PP_Head_DispAdjustReso;
            }
            else
            {
                DispProg.PP_HeadB_DispVol_Adj = Limit;
            }
            UpdateDisplay();
        }

        private void lbl_HeadA_BackSuck_Click(object sender, EventArgs e)
        {
            double d_MinVol_ul = 0;// DispProg.PP_HeadA_Min_Volume; ;
            double d_MaxVol_ul = TaskDisp.MaxAmount();// DispProg.PP_HeadA_Max_Volume;
            if (AdjustUnit == EAdjustUnit.ms) d_MaxVol_ul = 10000;

            DispProg.PP_HeadA_BackSuckVol = Math.Round(DispProg.PP_HeadA_BackSuckVol, TaskDisp.Option_VolumeDisplayDecimalPoint);

            UC.AdjustExec("Volume Adjust, Head 1 Back Suck", ref DispProg.PP_HeadA_BackSuckVol, d_MinVol_ul, d_MaxVol_ul);
            UpdateDisplay();
        }
        private void lbl_HeadB_BackSuck_Click(object sender, EventArgs e)
        {
            double d_MinVol_ul = 0;// DispProg.PP_HeadA_Min_Volume; ;
            double d_MaxVol_ul = TaskDisp.MaxAmount();// DispProg.PP_HeadA_Max_Volume;
            if (AdjustUnit == EAdjustUnit.ms) d_MaxVol_ul = 10000;

            DispProg.PP_HeadB_BackSuckVol = Math.Round(DispProg.PP_HeadB_BackSuckVol, TaskDisp.Option_VolumeDisplayDecimalPoint);

            UC.AdjustExec("Volume Adjust, Head 2 Back Suck", ref DispProg.PP_HeadB_BackSuckVol, d_MinVol_ul, d_MaxVol_ul);
                UpdateDisplay();
        }

        private void lbl_HeadA_VolComp_Click(object sender, EventArgs e)
        {
            if (DispProg.Target_Weight > 0)
            {
                MessageBox.Show("Vol Comp is not valid in Weight Mode.");
                return;
            }

            double CompA = 0;
            double CompB = 0;
            if (!DispProg.PP_VolComp.Get(0, ref CompA, ref CompB)) return;

            if (UC.AdjustExec("Volume Adjust, Head 1 Vol Comp", ref CompA, -0.1, 0.1))
                DispProg.PP_VolComp.Set(0, CompA, CompB);

            UpdateDisplay();
        }
        private void lbl_HeadB_VolComp_Click(object sender, EventArgs e)
        {
            if (DispProg.Target_Weight > 0)
            {
                MessageBox.Show("Vol Comp is not valid in Weight Mode.");
                return;
            }

            double CompA = 0;
            double CompB = 0;
            if (!DispProg.PP_VolComp.Get(0, ref CompA, ref CompB)) return;

            if (UC.AdjustExec("Volume Adjust, Head 2 Vol Comp", ref CompB, -0.1, 0.1))
                DispProg.PP_VolComp.Set(0, CompA, CompB);

            UpdateDisplay();
        }
        #endregion

        #region Settings
        private void lbl_AdjustTol_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Volume Adjust, Adjust Resolution", ref DispProg.PP_Head_DispOffsetTol, 1, 50);
            UpdateDisplay();
        }
        private void lbl_AdjustReso_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Volume Adjust, Adjust Resolution", ref DispProg.PP_Head_DispAdjustReso, 0.001, 10);
            UpdateDisplay();
        }
        #endregion

        //bool Updating = false;
        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                double Ofst1 = 0;
                double Ofst2 = 0;

                DispProg.DoVolumeOfst(ref Ofst1, ref Ofst2);

                double headA_Vol = DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj + DispProg.rt_Head1VolumeOfst;
                double headB_Vol = DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj + DispProg.rt_Head2VolumeOfst;
                TaskDisp.SetDispVolume(true, true, headA_Vol, headB_Vol);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
            UpdateDisplay();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset Volume Offset?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DispProg.ClearVolumeOffset();
            }
            UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            double HA_Vol = DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj + DispProg.rt_Head1VolumeOfst;
            double HB_Vol = DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj + DispProg.rt_Head2VolumeOfst;
            TaskDisp.SetDispVolume(true, true, HA_Vol, HB_Vol);
            TaskDisp.SetBackSuckVolume(true, true, DispProg.PP_HeadA_BackSuckVol, DispProg.PP_HeadB_BackSuckVol);
            Close();
        }

        private void tmr_Second_Tick(object sender, EventArgs e)
        {
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            DispProg.DoVolumeOfst_ShowInfo();
        }

        private void uctrl_FPressB_Load(object sender, EventArgs e)
        {

        }

        private void gbox_HeadA_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_FPressA_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;
            if (!SettingMode)
            {
                if (DispProg.FPress_AdjMin != 0) d_Min = DispProg.FPress_AdjMin;
                if (DispProg.FPress_AdjMax != 0) d_Max = DispProg.FPress_AdjMax;
            }

            FPressCtrl.AdjustPress_MPa(0, ref DispProg.FPress, d_Min, d_Max);
            UpdateDisplay();
        }

        private void lbl_FPressB_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;
            if (!SettingMode)
            {
                if (DispProg.FPress_AdjMin != 0) d_Min = DispProg.FPress_AdjMin;
                if (DispProg.FPress_AdjMax != 0) d_Max = DispProg.FPress_AdjMax;
            }

            FPressCtrl.AdjustPress_MPa(1, ref DispProg.FPress, d_Min, d_Max);
            UpdateDisplay();
        }

        private void lbl_HeadA_Ratio_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Volume Adjust, Head 1 Volume Ratio (x)", ref DispProg.PP_Head_VolumeRatio[0], 0.5, 1.5);
            UpdateDisplay();
        }

        private void lbl_HeadB_Ratio_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Volume Adjust, Head 2 Volume Ratio (x)", ref DispProg.PP_Head_VolumeRatio[1], 0.5, 1.5);
            UpdateDisplay();
        }

        private void lbl_FrameCount_Click(object sender, EventArgs e)
        {
            int i = Stats.BoardCount;
            if (UC.AdjustExec("Volume Adjust, Frame Count", ref i, 0, 10000))
            {
                Stats.BoardCount = i;
            }
            UpdateDisplay();
        }
    }
}