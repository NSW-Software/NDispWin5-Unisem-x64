using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace NDispWin
{
    public partial class frm_DispCore_DispTools : Form
    {
        frm_DispCore_DispSetup_PP frm_PP = new frm_DispCore_DispSetup_PP();
        frm_DispCore_DispSetup_HM frm_HM = new frm_DispCore_DispSetup_HM();
        frm_Setup_PJ frm_PJ = new frm_Setup_PJ();

        public frm_DispCore_DispTools()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;

            Label Txt_MaterialTimer = new Label(); Txt_MaterialTimer.AccessibleDescription = "Material Timer"; Txt_MaterialTimer.Visible = false; this.Controls.Add(Txt_MaterialTimer);

            pnl_LextarFrontTest.Location = new Point(4, 4);
            pnl_LextarFrontTest.Visible = (TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.Lextar_FrontTestCloseLoop);
        }

        private void EnableControls(bool Enable, Button Button1, Button Button2)
        {
            for (int i = 0; i <= Controls.Count - 1; i++)
            {
                if (Controls[i] is Button)
                {
                    (Controls[i] as Button).Enabled = Enable;
                }
                if (Controls[i] is Label)
                {
                    (Controls[i] as Label).Enabled = Enable;
                }

                if (Controls[i] is GroupBox || Controls[i] is Panel || Controls[i] is TabControl)
                {
                    for (int j = 0; j <= Controls[i].Controls.Count - 1; j++)
                    {
                        if (Controls[i].Controls[j] is TabPage)
                        {
                            for (int k = 0; k <= Controls[i].Controls[j].Controls.Count - 1; k++)
                            {
                                if (Controls[i].Controls[j].Controls[k] is Button)
                                {
                                    (Controls[i].Controls[j].Controls[k] as Button).Enabled = Enable;
                                }
                            }
                        }

                        if (Controls[i].Controls[j] is Button)
                        {
                            (Controls[i].Controls[j] as Button).Enabled = Enable;
                        }
                        if (Controls[i].Controls[j] is Label)
                        {
                            (Controls[i].Controls[j] as Label).Enabled = Enable;
                        }
                    }
                }
            }
            Button1.Enabled = true;
            Button2.Enabled = true;
        }
        private void EnableControls(bool Enable)
        {
            EnableControls(Enable, btn_Close, btn_Close);
        }
        private void EnableControls()
        {
            EnableControls(true, btn_Close, btn_Close);
        }

        private void UpdateDisplay()
        {
            if (TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.Lextar_FrontTestCloseLoop)
            {
                #region
                lbl_WaitTimer.Enabled = true;

                switch (Lextar_FrontTestCloseLoop.Mode)
                {
                    case Lextar_FrontTestCloseLoop.EMode.Auto:
                    case Lextar_FrontTestCloseLoop.EMode.Manual:
                        bool b_DPConnected = false;
                        try
                        {
                            b_DPConnected = Directory.Exists(TaskDisp.VolumeOfst_DataPath);
                            if (b_DPConnected)
                                b_DPConnected = Directory.Exists(TaskDisp.VolumeOfst_DataPath2);
                        }
                        catch
                        { }
                        if (b_DPConnected)
                            lbl_Connection.BackColor = Color.Lime;
                        else
                            lbl_Connection.BackColor = Color.Red;

                        switch (Lextar_FrontTestCloseLoop.Status)
                        {
                            case Lextar_FrontTestCloseLoop.EStatus.None:
                                lbl_WaitData.Text = "Idle";
                                lbl_WaitData.BackColor = this.BackColor;
                                break;
                            case Lextar_FrontTestCloseLoop.EStatus.Waiting:
                                TimeSpan dt = DateTime.Now - Lextar_FrontTestCloseLoop.dt_LastDataUpdate;
                                string s_Elapse = "";
                                if (dt.Minutes > 0) s_Elapse = dt.Minutes.ToString() + " m ";
                                s_Elapse = s_Elapse + dt.Seconds.ToString() + " s";
                                lbl_WaitData.Text = "Waiting Data..." + (char)13 + s_Elapse;

                                if (dt.Minutes >= Lextar_FrontTestCloseLoop.WaitTimer_m)
                                    lbl_WaitData.BackColor = Color.Red;
                                else
                                    lbl_WaitData.BackColor = this.BackColor;
                                break;
                            case Lextar_FrontTestCloseLoop.EStatus.Updated:
                                lbl_WaitData.Text = "Updated";
                                lbl_WaitData.BackColor = Color.Lime;
                                break;
                        }
                        break;
                    case Lextar_FrontTestCloseLoop.EMode.Disable:
                    default:
                        lbl_Connection.BackColor = Color.Orange;

                        lbl_WaitData.Text = "-";
                        lbl_WaitData.BackColor = this.BackColor;
                        break;
                }
                NUtils.RegistryWR RegRW = new NUtils.RegistryWR("Software");
                int OutMagNo = RegRW.ReadKey("MHS\\Elev\\Out", "LevelNo", 0);

                btn_UploadData.Visible = NDispWin.Lextar_FrontTestCloseLoop.Mode == Lextar_FrontTestCloseLoop.EMode.Manual;
                btn_UploadData.Text = "Upload Data" + (char)13 + "[" + OutMagNo.ToString() + "]";
                btn_VolumeOffset.Text = "Volume Offset" + (char)13 + "[" + Lextar_FrontTestCloseLoop.Mode.ToString() + "]";
                //btn_VolOfstModeNone.Text = "Mode: " + Lextar_FrontTestCloseLoop.Mode.ToString();

                lbl_WaitTimer.Text = "Wait Timer" + (char)13 + Lextar_FrontTestCloseLoop.WaitTimer_m.ToString() + " m";

                switch (NDispWin.Lextar_FrontTestCloseLoop.Mode)
                {
                    case Lextar_FrontTestCloseLoop.EMode.Disable:
                        btn_VolOfstModeNone.BackColor = Color.Lime;
                        btn_VolOfstModeAuto.BackColor = this.BackColor;
                        btn_VolOfstModeManual.BackColor = this.BackColor;
                        btn_VolumeOffset.BackColor = Color.Orange;
                        break;
                    case Lextar_FrontTestCloseLoop.EMode.Auto:
                        btn_VolOfstModeNone.BackColor = this.BackColor;
                        btn_VolOfstModeAuto.BackColor = Color.Lime;
                        btn_VolOfstModeManual.BackColor = this.BackColor;
                        btn_VolumeOffset.BackColor = Color.Lime;
                        break;
                    case Lextar_FrontTestCloseLoop.EMode.Manual:
                        btn_VolOfstModeNone.BackColor = this.BackColor;
                        btn_VolOfstModeAuto.BackColor = this.BackColor;
                        btn_VolOfstModeManual.BackColor = Color.Lime;
                        btn_VolumeOffset.BackColor = Color.Yellow;
                        break;
                }
                #endregion
            }

            btn_ForceSingle.Visible = TaskDisp.Option_EnableRunSingleHead && GDefine.HeadConfig == GDefine.EHeadConfig.Dual;
            UI_Utils.SetControlSelected(btn_ForceSingle, TaskDisp.ForceSingle);

            btn_DrawOfstAdjust.Visible = TaskDisp.Option_EnableDrawOfstAdjust;
            lbl_OrignOfst.Visible = TaskDisp.Option_EnableDrawOfstAdjust;
            //lbl_OrignOfst.Text = "(" + DispProg.OriginOfst[(int)DispProg.rt_StationNo].X.ToString("F3") + ", " +
            //                       DispProg.OriginOfst[(int)DispProg.rt_StationNo].Y.ToString("F3") + ", " +
            //                       DispProg.OriginOfst[(int)DispProg.rt_StationNo].Z.ToString("F3") + ")";
            lbl_OrignOfst.Text = "(" + DispProg.OriginDrawOfst.GetString + ")";
            if (DispProg.OriginDrawOfst.X != 0 || DispProg.OriginDrawOfst.Y != 0 || DispProg.OriginDrawOfst.Z != 0)
                lbl_OrignOfst.ForeColor = Color.Orange;
            else
                lbl_OrignOfst.ForeColor = Color.Navy;

            btn_Weight.Visible = ((int)GDefine.WeightStType > 0);

            btn_DispWeight.Visible = (TaskDisp.WeightProgramName[0].Length > 0 && File.Exists(GDefine.ProgPath + "\\" + TaskDisp.WeightProgramName[0] + "." + GDefine.ProgExt));
            btn_DispWeight.Text = TaskDisp.WeightProgramName[0] + " [" + TaskDisp.WeightProgramHead[0].ToString() + "]";
            btn_DispWeight2.Visible = (TaskDisp.WeightProgramName[1].Length > 0 && File.Exists(GDefine.ProgPath + "\\" + TaskDisp.WeightProgramName[1] + "." + GDefine.ProgExt));
            btn_DispWeight2.Text = TaskDisp.WeightProgramName[1] + " [" + TaskDisp.WeightProgramHead[1].ToString() + "]";

            lbl_MaterialTimer.Visible = TaskDisp.Material_EnableTimer;
            lbl_MaterialExpiryDT.Visible = TaskDisp.Material_EnableTimer;
            if (TaskDisp.Material_EnableTimer)
            {
                string s_MaterialTimer = AppLanguage.Func2.GetText(this, "Label", "Material Timer") + (char)13;
                int i_LifeTimer_s = (int)TaskDisp.Material_Life_EndTime.Subtract(DateTime.Now).TotalSeconds;
                if (i_LifeTimer_s > 0)
                {
                    if (i_LifeTimer_s <= 0)
                    {
                        lbl_MaterialTimer.Text = s_MaterialTimer + "Expired";
                    }
                    else
                    {
                        int i_LifeTimer_m = i_LifeTimer_s / 60;
                        int i_LifeTimer_h = i_LifeTimer_m / 60;

                        lbl_MaterialTimer.Text = s_MaterialTimer +
                        i_LifeTimer_h.ToString() + " H " +
                        (i_LifeTimer_m % 60).ToString() + " M " +
                        (i_LifeTimer_s % 60).ToString() + " S";
                    }

                    lbl_MaterialExpiryDT.Text = "Material Expiry" + (char)13 + TaskDisp.Material_Life_EndTime.ToString("yyyy/MM/dd HH:mm");
                    lbl_MaterialExpiryDT.BackColor = this.BackColor;
                }
                else
                {
                    lbl_MaterialTimer.Text = s_MaterialTimer + "0";
                    lbl_MaterialExpiryDT.Text = "Material Expired";
                    lbl_MaterialExpiryDT.BackColor = Color.Red;
                }
            }
            lbl_SensMat1Low.Visible = TaskDisp.Option_EnableMaterialLow;
            lbl_SensMat2Low.Visible = TaskDisp.Option_EnableMaterialLow;

            btnMaterialChange.Visible = Material.EnableUnitCounter;

            btn_StartIdle.Visible = TaskDisp.Option_EnableStartIdle;
            btn_PumpAction.Visible = Pump.Action.Enabled;
            btn_PurgeStage.Visible = (DispProg.PurgeStage.Count > 0);

            if (DispProg.Pump_Type == TaskDisp.EPumpType.PP || DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
            {
                frm_PP.TopLevel = false;
                frm_PP.Parent = pnl_DispTool_PumpTool;
                frm_PP.FormBorderStyle = FormBorderStyle.None;
                frm_PP.AutoSize = false;
                frm_PP.Dock = DockStyle.Fill;
                frm_PP.BringToFront();
                frm_PP.Show();
            }
            else
                frm_PP.Visible = false;

            if (DispProg.Pump_Type == TaskDisp.EPumpType.HM)
            {
                frm_HM.TopLevel = false;
                frm_HM.Parent = pnl_DispTool_PumpTool;
                frm_HM.FormBorderStyle = FormBorderStyle.None;
                frm_HM.AutoSize = false;
                frm_HM.Dock = DockStyle.Fill;
                frm_HM.BringToFront();
                frm_HM.Show();
            }
            else
                frm_HM.Visible = false;

            if (DispProg.Pump_Type == TaskDisp.EPumpType.PJ)
            {
                frm_PJ.TopLevel = false;
                frm_PJ.Parent = pnl_DispTool_PumpTool;
                frm_PJ.FormBorderStyle = FormBorderStyle.None;
                frm_PJ.AutoSize = false;
                frm_PJ.Dock = DockStyle.Fill;
                frm_PJ.BringToFront();
                frm_PJ.Show();
            }
            else
                frm_PJ.Visible = false;
        }

        private void frmDispTools_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);

            Text = "Dispense Tools";

            AppLanguage.Func2.UpdateText(this);

            btn_Close.Visible = this.Modal;// AllowClose;

            UpdateDisplay();
        }

        private void frm_DispCore_DispTools_Shown(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                try
                {
                    //TaskVision.frmGenImageView.GrabStop();
                    //TaskVision.frmGenImageView.Hide();
                    //TaskVision.frmGenImageView.EnableCamReticles = true;
                }
                catch { }
            }
        }

        private void frmDispTools_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        public void SetEnable(bool Enable)
        {
            EnableControls(Enable);
            pnl_DispTool_PumpTool.Enabled = Enable;
            btn_UploadData.Enabled = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            TaskDisp.TaskMoveGZZ2Up();
            Close();
        }

        bool b_ConnectOnce = true;
        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (b_ConnectOnce)
            {
                b_ConnectOnce = false;
            }
            UpdateDisplay();
            //GControl.UpdateFormControl(this);
        }
        private void tmr_5s_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            try
            {
                GDefine.RefreshInput(lbl_SensMat1Low, TaskGantry.SensMat1Low());
                GDefine.RefreshInput(lbl_SensMat2Low, TaskGantry.SensMat2Low());
            }
            catch { };
        }

        private void btn_ForceSingle_Click(object sender, EventArgs e)
        {
            TaskDisp.ForceSingle = !TaskDisp.ForceSingle;
            if (TaskDisp.ForceSingle)
                TaskDisp.Head_Operation = TaskDisp.EHeadOperation.Single;
            else
                TaskDisp.Head_Operation = DispProg.Head_Operation;

            DispProg.rt_PromptedSingleHeadRun = false;

            Event.DISPTOOLS_FORCE_SINGLE.Set("ForceSingle", TaskDisp.ForceSingle.ToString());
            UpdateDisplay();
        }
        private void btn_Origin_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            Event.DISPTOOLS_ORIGIN.Set();

            try
            {
                if (!TaskDisp.TaskMoveGZZ2Up()) return;
                if (!TaskGantry.SetMotionParamGXYX2Y2()) return;

                TPos2 GXY = new TPos2(DispProg.Origin(DispProg.rt_StationNo).X, DispProg.Origin(DispProg.rt_StationNo).Y);
                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

                if (!TaskDisp.GotoXYPos(GXY, GX2Y2)) return;

                TaskVision.LightingOn(TaskVision.DefLightRGB);

                frm_DispProg_View frm = new frm_DispProg_View();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DispProg.RunMode = ERunMode.Camera;
                    DispProg.OriginBase[(int)DispProg.rt_StationNo].X = TaskGantry.GXPos();
                    DispProg.OriginBase[(int)DispProg.rt_StationNo].Y = TaskGantry.GYPos();
                }
            }
            catch { };
        }
        frm_DispCore_DrawOfstAdjust frm_OriginAdjust = new frm_DispCore_DrawOfstAdjust();
        private void btn_OriginAdjust_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_ORIGIN_ADJUST.Set();

            frm_OriginAdjust.TopLevel = false;
            frm_OriginAdjust.Parent = this;
            frm_OriginAdjust.BringToFront();
            frm_OriginAdjust.Show();
        }
        private void lbl_OriginOfst_Click(object sender, EventArgs e)
        {
            btn_OriginAdjust_Click(sender, e);
        }
        private void lbl_MaterialTimer_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (UC.AdjustExec("Material Life (Minute x " + TaskDisp.Material_Life_Multiplier.ToString() + ")", ref i, 0, 720))
            {
                if (i == 0)
                {
                    TaskDisp.Material_Life_EndTime = DateTime.Now;
                }
                else
                {
                    TaskDisp.Material_Life_EndTime = DateTime.Now.AddSeconds(i * 60 * TaskDisp.Material_Life_Multiplier);
                }
                TaskDisp.Material_LifePreAlert_Time = TaskDisp.Material_Life_EndTime.AddMinutes((double)-TaskDisp.Material_ExpiryPreAlertTime);

                Event.DISPTOOLS_ADJ_MATERIAL_TIMER.Set("Timer", i.ToString());
            }

            UpdateDisplay();
        }

        private void dtp_ExpiryTime_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dtp_ScanEntry_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string S = dtp_ScanEntry.Text;
                try
                {
                    int YYYY = Convert.ToInt32(S.Remove(4));
                    int MM = Convert.ToInt32(S.Remove(0, 4).Remove(2));
                    int DD = Convert.ToInt32(S.Remove(0, 6).Remove(2));
                    int hh = Convert.ToInt32(S.Remove(0, 8).Remove(2));
                    int mm = 0;
                    if (S.Length > 12) mm = Convert.ToInt32(S.Remove(0, 10).Remove(2));
                    else mm = Convert.ToInt32(S.Remove(0, 10));

                    dtp_ExpiryDate.Value = new DateTime(YYYY, MM, DD);
                    dtp_ExpiryTime.Value = new DateTime(YYYY, MM, DD, hh, mm, 0, DateTimeKind.Unspecified);

                    btn_dtpOK_Click(sender, e);
                }
                catch
                {
                    dtp_ScanEntry.Text = "";
                };

                UpdateDisplay();
            }
        }
        private void dtp_ScanEntry_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void dtp_ScanEntry_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void dtp_ScanEntry_Layout(object sender, LayoutEventArgs e)
        {

        }
        private void dtp_ScanEntry_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void dtp_ExpiryDate_ValueChanged(object sender, EventArgs e)
        {

        }
        private void lbl_MaterialExpiryDT_Click(object sender, EventArgs e)
        {
            gbox_DateTime.Location = lbl_MaterialExpiryDT.Location;
            gbox_DateTime.BringToFront();

            EnableControls(false, btn_Close, btn_dtpOK);
            btn_dtpCancel.Enable(true);

            gbox_DateTime.Visible = true;
            dtp_ScanEntry.Text = "";
            dtp_ScanEntry.Focus();
        }
        private void btn_dtpOK_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_ADJ_MATERIAL_EXP.Set();

            TaskDisp.Material_Life_EndTime = dtp_ExpiryDate.Value.Date.Add(dtp_ExpiryTime.Value.TimeOfDay);
            TaskDisp.Material_LifePreAlert_Time = TaskDisp.Material_Life_EndTime.AddMinutes((double)-TaskDisp.Material_ExpiryPreAlertTime);
            gbox_DateTime.Visible = false;

            EnableControls();
            UpdateDisplay();
        }
        private void btn_dtpCancel_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_ADJ_MATERIAL_EXP_CANCEL.Set();

            gbox_DateTime.Visible = false;

            EnableControls();
            UpdateDisplay();
        }


        private void btn_GotoMMaint_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            Event.DISPTOOLS_GOTO_MACHINE_MAINT_POS.Set();

            DefineSafety.DoorLock = true;
            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();
            TaskDisp.TaskGotoMMaint();
            frm.Close();
            DefineSafety.DoorLock = false;
        }
        private void btn_GotoPMaint_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            Event.DISPTOOLS_GOTO_PUMP_MAINT_POS.Set();

            DefineSafety.DoorLock = true;
            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();
            TaskDisp.TaskGotoPMaint();
            frm.Close();
            DefineSafety.DoorLock = false;
        }
        string LastProgName = "";
        private void StartDispWeight(string ProgramName, EHeadNo HeadNo)
        {
            EnableControls(false, btn_Close, btn_Close);
            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!File.Exists(GDefine.ProgPath + "\\" + ProgramName + "." + GDefine.ProgExt)) goto _End;

            if (!TaskGantry.CheckReadyStop()) goto _End;

            LastProgName = GDefine.ProgRecipeName;
            DispProg.Load(GDefine.ProgPath + "\\" + ProgramName, false);
            DispProg.ModelList.SetDispVolumeDefault();

            DispProg.RunMode = ERunMode.Normal;

            if (HeadNo == EHeadNo.Head1) DispProg.b_ForceHead1 = true;
            if (HeadNo == EHeadNo.Head2) DispProg.b_ForceHead2 = true;

            Thread.Sleep(0);
            UpdateDisplay();
            while (DispProg.TR_IsBusy())
            {
                if (frm.Cancel) DispProg.TR_Cancel();

                Thread.Sleep(5);
            }
            Thread.Sleep(2);

            _End:
            frm.Close();
            EnableControls(true, btn_Close, btn_Close);
        }
        private void EndDispWeight()
        {
            DispProg.Load(GDefine.ProgPath + "\\" + LastProgName, false);
        }
        private void btn_DispWeight_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            StartDispWeight(TaskDisp.WeightProgramName[0], TaskDisp.WeightProgramHead[0]);
            EndDispWeight();
            UpdateDisplay();
        }
        private void btn_DispWeight2_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            StartDispWeight(TaskDisp.WeightProgramName[1], TaskDisp.WeightProgramHead[1]);
            EndDispWeight();
            UpdateDisplay();
        }

        private void btn_TeachNeedle_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_TEACH_NEEDLE.Set();

            //Msg MsgBox = new Msg();
            //EMsgRes Res = MsgBox.Show("Continue to Teach Needle - " + TaskDisp.TeachNeedle_Method.ToString(), EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
            //switch (Res)
            //{
            //    case EMsgRes.smrCancel:
            //        {
            //            Event.DISPTOOLS_TEACH_NEEDLE_CANCEL.Set();
            //            return;
            //        }
            //}
            string Msg = "Continue to Teach Needle - " + TaskDisp.TeachNeedle_Method.ToString();
            if (MessageBox.Show(Msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            TaskDisp.DispTool_TeachNeedle();
        }
        private void btn_View_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            Event.DISPTOOLS_VIEW.Set();

            try
            {
                if (!TaskDisp.TaskMoveGZZ2Up()) return;
                if (!TaskGantry.SetMotionParamGXYX2Y2()) return;

                TPos2 GXY = new TPos2(DispProg.Origin(DispProg.rt_StationNo).X, DispProg.Origin(DispProg.rt_StationNo).Y);
                TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
                GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

                TaskVision.LightingOn(TaskVision.DefLightRGB);

                frm_DispProg_View frm = new frm_DispProg_View();
                frm.ShowSetBtn = false;
                frm.ShowCamOfstBtn = true;

                frm.ShowDialog();
            }
            catch { };
        }
        private void btn_PurgeStage_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_PURGE_STAGE.Set();

            TModelPara Model = new TModelPara(DispProg.ModelList, 0);
            TaskDisp.PurgeStage.Execute(DispProg.PurgeStage.Count);
        }
        private void btn_PumpAction_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            gbox_PumpAction.Location = new Point(342, 142);

            btn_PumpAction1.Text = Pump.Action.ActionGroup[0].Name;
            btn_PumpAction2.Text = Pump.Action.ActionGroup[1].Name;
            btn_PumpAction3.Text = Pump.Action.ActionGroup[2].Name;
            btn_PumpAction4.Text = Pump.Action.ActionGroup[3].Name;
            btn_PumpAction5.Text = Pump.Action.ActionGroup[4].Name;

            btn_PumpAction1.Visible = Pump.Action.ActionGroup[0].Name.Length > 0;
            btn_PumpAction2.Visible = Pump.Action.ActionGroup[1].Name.Length > 0;
            btn_PumpAction3.Visible = Pump.Action.ActionGroup[2].Name.Length > 0;
            btn_PumpAction4.Visible = Pump.Action.ActionGroup[3].Name.Length > 0;
            btn_PumpAction5.Visible = Pump.Action.ActionGroup[4].Name.Length > 0;

            EnableControls(false, btn_Close, btn_PumpActionCancel);

            btn_PumpAction1.Enabled = true;
            btn_PumpAction2.Enabled = true;
            btn_PumpAction3.Enabled = true;
            btn_PumpAction4.Enabled = true;
            btn_PumpAction5.Enabled = true;

            gbox_PumpAction.Visible = true;
        }
        private void btn_PumpAction1_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_PUMP_ACTION_1.Set();

            gbox_PumpAction.Visible = false;
            try
            {
                Pump.Action.ActionGroup[0].Execute();
            }
            catch
            { }
            finally
            {
                EnableControls();
            }
        }
        private void btn_PumpAction2_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_PUMP_ACTION_2.Set();

            gbox_PumpAction.Visible = false;
            try
            {
                Pump.Action.ActionGroup[1].Execute();
            }
            catch
            { }
            finally
            {
                EnableControls();
            }
        }
        private void btn_PumpAction3_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_PUMP_ACTION_3.Set();

            gbox_PumpAction.Visible = false;
            try
            {
                Pump.Action.ActionGroup[2].Execute();
            }
            catch
            { }
            finally
            {
                EnableControls();
            }
        }
        private void btn_PumpAction4_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_PUMP_ACTION_4.Set();

            gbox_PumpAction.Visible = false;
            try
            {
                Pump.Action.ActionGroup[3].Execute();
            }
            catch
            { }
            finally
            {
                EnableControls();
            }
        }
        private void btn_PumpAction5_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_PUMP_ACTION_5.Set();

            gbox_PumpAction.Visible = false;
            try
            {
                Pump.Action.ActionGroup[4].Execute();
            }
            catch
            { }
            finally
            {
                EnableControls();
            }
        }
        private void btn_PumpActionCancel_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_PUMP_ACTION_CANCEL.Set();

            gbox_PumpAction.Visible = false;
            EnableControls();
        }


        private void btn_CleanNeedle_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();
            TaskDisp.TaskCleanNeedle(true);
            frm.Close();
        }
        private void btn_PurgeNeedle_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();
            TaskDisp.TaskPurgeNeedle(true);
            frm.Close();
        }
        private void btn_CPF_Click(object sender, EventArgs e)
        {
            gbox_CPF.Location = new Point(480, 4);
            gbox_CPF.BringToFront();

            EnableControls(false, btn_Close, btn_CPF_Cancel);

            btn_CPF_Clean.Enabled = true;
            btn_CPF_Purge.Enabled = true;
            btn_CPF_Flush.Enabled = true;

            gbox_CPF.Visible = true;
        }
        private void btn_CPFClean_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            Event.DISPTOOLS_CLEAN.Set();

            DefineSafety.DoorLock = true;

            try
            {
                //frm_DispCore_Progress frm = new frm_DispCore_Progress();
                //frm.Show();
                //TaskDisp.TaskCleanNeedle(true);
                //frm.Close();
                MsgBox.Processing("Task Clean Needle in progress.", () => TaskDisp.TaskCleanNeedle(true));
            }
            catch
            { }
            finally
            {
                TaskDisp.FPressOff();
                DefineSafety.DoorLock = false;
                EnableControls();
            }
            gbox_CPF.Visible = false;
        }
        private void btn_CPF_Purge_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            Event.DISPTOOLS_PURGE.Set();

            DefineSafety.DoorLock = true;

            try
            {
                //frm_DispCore_Progress frm = new frm_DispCore_Progress();
                //frm.Show();
                //TaskDisp.TaskPurgeNeedle(true);
                //frm.Close();
                MsgBox.Processing("Task Purge Needle in progress.", () => TaskDisp.TaskPurgeNeedle(true));
            }
            catch
            { }
            finally
            {
                TaskDisp.FPressOff();
                DefineSafety.DoorLock = false;
                EnableControls();
            }
            gbox_CPF.Visible = false;
        }
        private void btn_CPF_Flush_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            Event.DISPTOOLS_FLUSH.Set();

            DefineSafety.DoorLock = true;

            try
            {
                //frm_DispCore_Progress frm = new frm_DispCore_Progress();
                //frm.Show();
                //TaskDisp.TaskFlushNeedle(true);
                //frm.Close();
                MsgBox.Processing("Task Flush Needle in progress.", () => TaskDisp.TaskFlushNeedle(true));
            }
            catch
            { }
            finally
            {
                TaskDisp.FPressOff();
                DefineSafety.DoorLock = false;
                EnableControls();
            }
            gbox_CPF.Visible = false;
        }
        private void btn_CPF_Cancel_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_CLEANPURGE_CANCEL.Set();

            gbox_CPF.Visible = false;
            EnableControls();
        }
        private void btn_StartIdle_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_START_IDLE.Set();

            frm_DispCore_IdlePurge frm = new frm_DispCore_IdlePurge();

            int i_HeadSelect = 0;

            switch (DispProg.Head_Operation)
            {
                case TaskDisp.EHeadOperation.Double:
                case TaskDisp.EHeadOperation.Sync:
                    i_HeadSelect = 3;
                    break;
                case TaskDisp.EHeadOperation.Single:
                    i_HeadSelect = 1;
                    break;
            }
            frm.i_DispSelect = i_HeadSelect;
            frm.AutoStart = true;
            frm.ShowDialog();
        }

        private void btn_Weight_Click(object sender, EventArgs e)
        {
            gbox_Weight.Location = btn_Weight.Location;
            gbox_Weight.BringToFront();

            EnableControls(false, btn_Close, btn_WeightCancel);
            btn_WeightAdjust.Enabled = true;
            btn_WeightCalibrate.Enabled = true;
            btn_WeightMeasure.Enabled = true;

            gbox_Weight.Visible = true;
        }
        private void btn_WeightAdjust_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_WEIGHT_ADJUST.Set();

            gbox_Weight.Visible = false;
            EnableControls();

            frm_DispCore_WeightAdjust frm = new frm_DispCore_WeightAdjust();
            frm.ShowDialog();
        }
        private void btn_WeightCalibrate_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_WEIGHT_CALIBRATE.Set();

            gbox_Weight.Visible = false;
            EnableControls();

            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.SP:
                case TaskDisp.EPumpType.TP:
                    frmFlowRateCal frmFR = new frmFlowRateCal();
                    frmFR.ShowDialog();
                    break;
                default:
                    frm_DispCore_WeightCal frm = new frm_DispCore_WeightCal();
                    frm.ShowDialog();
                    break;
            }
        }
        private void btn_WeightMeasure_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_WEIGHT_MEASURE.Set();

            gbox_Weight.Visible = false;
            EnableControls();

            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.SP:
                case TaskDisp.EPumpType.TP:
                    frmWeightMeasure frmMeas = new frmWeightMeasure();
                    frmMeas.ShowDialog();
                    break;
                default:
                    frm_DispCore_WeightMeasure frm = new frm_DispCore_WeightMeasure();
                    frm.ShowDialog();
                    break;
            }
        }
        private void btn_WeightCancel_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_WEIGHT_CANCEL.Set();

            gbox_Weight.Visible = false;
            EnableControls();
        }
        frm_Setup_PJ frmPJ = new frm_Setup_PJ();
        frm_Setup_SP frmSP = new frm_Setup_SP();
        private void btn_PumpAdjust_Click(object sender, EventArgs e)
        {
            Event.DISPTOOLS_PUMP_ADJUST.Set();

            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.PP:
                case TaskDisp.EPumpType.PP2D:
                case TaskDisp.EPumpType.PPD:
                    {
                        frm_DispTool_VolumeAdjust frm = new frm_DispTool_VolumeAdjust();
                        frm.AdjustUnit = frm_DispTool_VolumeAdjust.EAdjustUnit.ul;
                        frm.SettingMode = false;
                        frm.ShowDialog();
                        break;
                    }
                case TaskDisp.EPumpType.HM:
                    {
                        frm_DispTool_SpeedAdjust frm = new frm_DispTool_SpeedAdjust();
                        frm.SettingMode = false;
                        frm.ShowDialog();
                        break;
                    }
                case TaskDisp.EPumpType.PJ:
                    {
                        if (frmPJ.IsDisposed)
                        {
                            frmPJ.Close();
                            frmPJ = new frm_Setup_PJ();
                        }

                        frmPJ.Visible = true;
                        frmPJ.BringToFront();
                        frmPJ.TopMost = true;
                        break;
                    }
                case TaskDisp.EPumpType.SP:
                    {
                        if (frmSP.IsDisposed)
                        {
                            frmSP.Close();
                            frmSP = new frm_Setup_SP();
                        }
                        frmSP.Visible = true;
                        frmSP.BringToFront();
                        frmSP.TopMost = true;
                        break;
                    }
            }
        }


        private void btn_UploadData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            double[] Base = new double[2] { DispProg.PP_HeadA_DispBaseVol, DispProg.PP_HeadB_DispBaseVol };
            double[] Adjust = new double[2] { DispProg.PP_HeadA_DispVol_Adj, DispProg.PP_HeadB_DispVol_Adj };
            double[] Offset = new double[2] { DispProg.rt_Head1VolumeOfst, DispProg.rt_Head2VolumeOfst };
            double[] Backsuck = new double[2] { DispProg.PP_HeadA_BackSuckVol, DispProg.PP_HeadB_BackSuckVol };

            //send the previous level no starting from 1
            NUtils.RegistryWR RegRW = new NUtils.RegistryWR("Software");
            int OutLevel = RegRW.ReadKey("MHS\\Elev\\Out", "LevelNo", 0);
            int OutTLevel = RegRW.ReadKey("MHS\\Elev\\Out", "TLevel", 0);
            if (OutLevel == 0) OutLevel = OutTLevel;

            try
            {
                NDispWin.Lextar_FrontTestCloseLoop.EquipmentID = TaskDisp.VolumeOfst_EqID;
                NDispWin.Lextar_FrontTestCloseLoop.LocalPath = TaskDisp.VolumeOfst_LocalPath;
                NDispWin.Lextar_FrontTestCloseLoop.DataFilePath = TaskDisp.VolumeOfst_DataPath;
                NDispWin.Lextar_FrontTestCloseLoop.DataFilePath2 = TaskDisp.VolumeOfst_DataPath2;
                Lextar_FrontTestCloseLoop.UploadDataFile(OutLevel, Base, Adjust, Offset, Backsuck);
                Lextar_FrontTestCloseLoop.dt_LastDataUpdate = DateTime.Now;
                Lextar_FrontTestCloseLoop.Status = Lextar_FrontTestCloseLoop.EStatus.Waiting;
            }
            catch
            {

            }
            finally
            {
                this.Enabled = true;
            }
        }
        private void lbl_FrameNo_Click(object sender, EventArgs e)
        {
            NUtils.RegistryWR RegRW = new NUtils.RegistryWR("Software");
            int OutMagNo = RegRW.ReadKey("Elev", "OutMagNo", 0);

            int i = Stats.BoardCount;
            if (UC.AdjustExec("Disp Tools.Frame No", ref i, 0, 1000))
            {
                Stats.BoardCount = i;
                UpdateDisplay();
            } 
            EnableControls();
        }
        private void btn_VolumeOffset_Click(object sender, EventArgs e)
        {
            gbox_VolumeOfst.Location = (sender as Button).Location;

            EnableControls(false, btn_Close, btn_VolOfstClose);

            btn_VolOfstModeNone.Enabled = true;
            btn_VolOfstModeAuto.Enabled = true;
            btn_VolOfstModeManual.Enabled = true;

            btn_UploadData.Enabled = true;
            btn_VolOfstReset.Enabled = true;
            btn_VolOfstClose.Enabled = true;

            gbox_VolumeOfst.BringToFront();
            gbox_VolumeOfst.Visible = true;
        }
        private void btn_VolOfstMode_Click(object sender, EventArgs e)
        {
            if (Lextar_FrontTestCloseLoop.Mode == Lextar_FrontTestCloseLoop.EMode.Disable) return;

            if (NUtils.UserAcc.Active.GroupID < 2)
            {
                int i_UserIdx = NUtils.UserAcc.Active.UserIndex;
                NUtils.UserAcc.Users.LoginDlg();
                if (NUtils.UserAcc.Active.GroupID < 2) goto _End;
                NUtils.UserAcc.Active.UserIndex = i_UserIdx;
            }

            Lextar_FrontTestCloseLoop.Mode = Lextar_FrontTestCloseLoop.EMode.Disable;
            UpdateDisplay();

            _End:
            gbox_VolumeOfst.Visible = false;
            EnableControls();
        }
        private void btn_VolOfstModeAuto_Click(object sender, EventArgs e)
        {
            if (Lextar_FrontTestCloseLoop.Mode == Lextar_FrontTestCloseLoop.EMode.Auto) return;

            if (NUtils.UserAcc.Active.GroupID < 2)
            {
                int i_UserIdx = NUtils.UserAcc.Active.UserIndex;
                NUtils.UserAcc.Users.LoginDlg();
                if (NUtils.UserAcc.Active.GroupID < 2) goto _End;
                NUtils.UserAcc.Active.UserIndex = i_UserIdx;
            }

            Lextar_FrontTestCloseLoop.Mode = Lextar_FrontTestCloseLoop.EMode.Auto;
            UpdateDisplay();

            _End:
            gbox_VolumeOfst.Visible = false;
            EnableControls();
        }
        private void btn_VolOfstModeManual_Click(object sender, EventArgs e)
        {
            if (Lextar_FrontTestCloseLoop.Mode == Lextar_FrontTestCloseLoop.EMode.Manual) return;

            if (NUtils.UserAcc.Active.GroupID < 2)
            {
                int i_UserIdx = NUtils.UserAcc.Active.UserIndex;
                NUtils.UserAcc.Users.LoginDlg();
                if (NUtils.UserAcc.Active.GroupID < 2) goto _End;
                NUtils.UserAcc.Active.UserIndex = i_UserIdx;
            }

            Lextar_FrontTestCloseLoop.Mode = Lextar_FrontTestCloseLoop.EMode.Manual;
            UpdateDisplay();

            _End:
            gbox_VolumeOfst.Visible = false;
            EnableControls();
        }
        private void btn_VolOfstClose_Click(object sender, EventArgs e)
        {
            gbox_VolumeOfst.Visible = false;
            EnableControls();
        }
        private void btn_VolOfstReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset Volume Offset?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DispProg.ClearVolumeOffset();
                Stats.BoardCount = 0;
                Lextar_FrontTestCloseLoop.dt_LastDataUpdate = DateTime.Now;
                Lextar_FrontTestCloseLoop.Status = Lextar_FrontTestCloseLoop.EStatus.None;
            }
            UpdateDisplay();

            gbox_VolumeOfst.Visible = false;
            EnableControls();
        }
        private void lbl_WaitTimer_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Wait Timer (m)", ref Lextar_FrontTestCloseLoop.WaitTimer_m, 1, 720);
            UpdateDisplay();
        }

        private void btnMaterialChange_Click(object sender, EventArgs e)
        {
            if (Material.EnableUnitCounter)
            {
                if (MessageBox.Show("Reset Material Unit Counter?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Log.OnSet("Reset Material Unit Counter A", Material.Unit.Count[0], 0);
                    Material.Unit.Count[0] = 0;
                    Log.OnSet("Reset Material Unit Counter B", Material.Unit.Count[1], 0);
                    Material.Unit.Count[1] = 0;
                    GDefine.SaveDefault();
                }
                UpdateDisplay();
            }
        }

        private void lbl_LmdsCT_Status_Click(object sender, EventArgs e)
        {

        }

        private void lbl_LotID_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Program_Click(object sender, EventArgs e)
        {

        }

        private void btn_LotInfo_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Connection_Click(object sender, EventArgs e)
        {

        }
    }
}
