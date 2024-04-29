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
    internal partial class frm_DispCore_DispProg_ModelListSetting : Form
    {
        public frm_DispCore_DispProg_ModelListSetting()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.Location = new Point(0, 0);

            Label DnStartV = new Label(); DnStartV.AccessibleDescription = "DnStartV"; DnStartV.Visible = false; this.Controls.Add(DnStartV);
            Label DnSpeed = new Label(); DnSpeed.AccessibleDescription = "DnSpeed"; DnSpeed.Visible = false; this.Controls.Add(DnSpeed);
            Label DnAccel = new Label(); DnAccel.AccessibleDescription = "DnAccel"; DnAccel.Visible = false; this.Controls.Add(DnAccel);
            Label DispGap = new Label(); DispGap.AccessibleDescription = "DispGap"; DispGap.Visible = false; this.Controls.Add(DispGap);
            Label DnWait = new Label(); DnWait.AccessibleDescription = "DnWait"; DnWait.Visible = false; this.Controls.Add(DnWait);

            Label StartDelay = new Label(); StartDelay.AccessibleDescription = "StartDelay"; StartDelay.Visible = false; this.Controls.Add(StartDelay);
            Label LineStartV = new Label(); LineStartV.AccessibleDescription = "LineStartV"; LineStartV.Visible = false; this.Controls.Add(LineStartV);
            Label LineSpeed = new Label(); LineSpeed.AccessibleDescription = "LineSpeed"; LineSpeed.Visible = false; this.Controls.Add(LineSpeed);
            Label LineAccel = new Label(); LineAccel.AccessibleDescription = "LineAccel"; LineAccel.Visible = false; this.Controls.Add(LineAccel);
            Label PumpSpeed = new Label(); PumpSpeed.AccessibleDescription = "PumpSpeed"; PumpSpeed.Visible = false; this.Controls.Add(PumpSpeed);
            Label EndDelay = new Label(); EndDelay.AccessibleDescription = "EndDelay"; EndDelay.Visible = false; this.Controls.Add(EndDelay);
            Label PostWait = new Label(); PostWait.AccessibleDescription = "PostWait"; PostWait.Visible = false; this.Controls.Add(PostWait);
            Label FPressA = new Label(); FPressA.AccessibleDescription = "FPressA"; EndDelay.Visible = false; this.Controls.Add(FPressA);
            Label PPressA = new Label(); PPressA.AccessibleDescription = "PPressA"; PostWait.Visible = false; this.Controls.Add(PPressA);

            Label RetStartV = new Label(); RetStartV.AccessibleDescription = "RetStartV"; RetStartV.Visible = false; this.Controls.Add(RetStartV);
            Label RetSpeed = new Label(); RetSpeed.AccessibleDescription = "RetSpeed"; RetSpeed.Visible = false; this.Controls.Add(RetSpeed);
            Label RetAccel = new Label(); RetAccel.AccessibleDescription = "RetAccel"; RetAccel.Visible = false; this.Controls.Add(RetAccel);
            Label RetGap = new Label(); RetGap.AccessibleDescription = "RetGap"; RetGap.Visible = false; this.Controls.Add(RetGap);
            Label RetWait = new Label(); RetWait.AccessibleDescription = "RetWait"; RetWait.Visible = false; this.Controls.Add(RetWait);

            Label UpStartV = new Label(); UpStartV.AccessibleDescription = "UpStartV"; UpStartV.Visible = false; this.Controls.Add(UpStartV);
            Label UpSpeed = new Label(); UpSpeed.AccessibleDescription = "UpSpeed"; UpSpeed.Visible = false; this.Controls.Add(UpSpeed);
            Label UpAccel = new Label(); UpAccel.AccessibleDescription = "UpAccel"; UpAccel.Visible = false; this.Controls.Add(UpAccel);
            Label UpGap = new Label(); UpGap.AccessibleDescription = "UpGap"; UpGap.Visible = false; this.Controls.Add(UpGap);
            Label UpWait = new Label(); UpWait.AccessibleDescription = "UpWait"; UpWait.Visible = false; this.Controls.Add(UpWait);

            Label LiftGap = new Label(); LiftGap.AccessibleDescription = "LiftGap"; LiftGap.Visible = false; this.Controls.Add(LiftGap);
        }

        private void frmDispProg_ModelListSetting_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            Text = "Model List Setting";

            cboxl_ModelList.Items.Clear();
            for (int i = 0; i < TModelList.MAX_PARA; i++)
            {
                bool Show = true;
                Show = DispProg.ModelList.BasicPara.Contains(i);
                string S = Enum.GetName(typeof(TModelList.EModel), i);
                S = AppLanguage.Func2.GetText(this, "Label", S);
                cboxl_ModelList.Items.Add(S, Show);
            }

            UpdateDisplayLimit();
        }

        int i_SelIndex = -1;
        private void cboxl_ModelList_MouseDown(object sender, MouseEventArgs e)
        {
            i_SelIndex = cboxl_ModelList.SelectedIndex;
            UpdateDisplayLimit();
        }

        private void UpdateDisplayLimit()
        {
            bool ShowLimit = (i_SelIndex >= 0);
            ShowLimit = ShowLimit &&
                (TModelList.WarnLLimit[i_SelIndex] > 0 || TModelList.WarnULimit[i_SelIndex] > 0);

            gbox_WarningLimit.Visible = ShowLimit;

            if (!ShowLimit) return;

            string S = "Warning Limit";
            S = AppLanguage.Func2.GetText(this, "Label", S);

            if (DispProg.Pump_Type == TaskDisp.EPumpType.PP || DispProg.Pump_Type == TaskDisp.EPumpType.PP2D || DispProg.Pump_Type == TaskDisp.EPumpType.PPD)
                gbox_WarningLimit.Text = S + " (" + TModelList.PPModelUnits[i_SelIndex].ToString() + ")";
            if (DispProg.Pump_Type == TaskDisp.EPumpType.HM)
                gbox_WarningLimit.Text = S + " (" + TModelList.HMModelUnits[i_SelIndex].ToString() + ")";
            lbl_WarnLLimit.Text = TModelList.WarnLLimit[i_SelIndex].ToString("F3");
            lbl_WarnULimit.Text = TModelList.WarnULimit[i_SelIndex].ToString("F3");
        }

        private void lbl_WarnLLimit_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Model Setting, Warning Lower Limit", ref TModelList.WarnLLimit[i_SelIndex], 0, 30000);
            UpdateDisplayLimit();
        }

        private void lbl_WarnULimit_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Model Setting, Warning Lower Limit", ref TModelList.WarnULimit[i_SelIndex], 0, 30000);
            UpdateDisplayLimit();
        }

        private void frm_DispCore_DispProg_ModelListSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            DispProg.ModelList.BasicPara.Clear();
            for (int i = 0; i < TModelList.MAX_PARA; i++)
            {
                if (cboxl_ModelList.GetItemChecked(i))
                {
                    DispProg.ModelList.BasicPara.Add(i);
                }
            }

            DispProg.ModelList.SaveSetting(GDefine.ModelSettingFile);
        }
    }
}
