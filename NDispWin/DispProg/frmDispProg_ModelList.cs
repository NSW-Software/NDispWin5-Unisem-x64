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
    internal partial class frm_DispCore_DispProg_ModelList : Form
    {
        bool Advance = false;
        
        public frm_DispCore_DispProg_ModelList()
        {
            InitializeComponent();
            GControl.LogForm(this);

            Label DnStartV = new Label(); DnStartV.AccessibleDescription = "DnStartV"; DnStartV.Visible = false; this.Controls.Add(DnStartV);
            DnStartV.ForeColor = this.BackColor; 
            Label DnSpeed = new Label(); DnSpeed.AccessibleDescription = "DnSpeed"; DnSpeed.Visible = false; this.Controls.Add(DnSpeed);
            Label DnAccel = new Label(); DnAccel.AccessibleDescription = "DnAccel"; DnAccel.Visible = false; this.Controls.Add(DnAccel);
            Label DispGap = new Label(); DispGap.AccessibleDescription = "DispGap"; DispGap.Visible = false; this.Controls.Add(DispGap);

            Label DnWait = new Label(); DnWait.AccessibleDescription = "DnWait"; DnWait.Visible = false; this.Controls.Add(DnWait);
            Label StartDelay = new Label(); StartDelay.AccessibleDescription = "StartDelay"; StartDelay.Visible = false; this.Controls.Add(StartDelay);

            Label DispVol = new Label(); DispVol.AccessibleDescription = "DispVol"; DispVol.Visible = false; this.Controls.Add(DispVol);
            Label LineStartV = new Label(); LineStartV.AccessibleDescription = "LineStartV"; LineStartV.Visible = false; this.Controls.Add(LineStartV);
            Label LineSpeed = new Label(); LineSpeed.AccessibleDescription = "LineSpeed"; LineSpeed.Visible = false; this.Controls.Add(LineSpeed);
            Label LineSpeed2 = new Label(); LineSpeed2.AccessibleDescription = "LineSpd2"; LineSpeed2.Visible = false; this.Controls.Add(LineSpeed2);
            Label LineAccel = new Label(); LineAccel.AccessibleDescription = "LineAccel"; LineAccel.Visible = false; this.Controls.Add(LineAccel);
            Label PumpSpeed = new Label(); PumpSpeed.AccessibleDescription = "PumpSpeed"; PumpSpeed.Visible = false; this.Controls.Add(PumpSpeed);
            Label EndDelay = new Label(); EndDelay.AccessibleDescription = "EndDelay"; EndDelay.Visible = false; this.Controls.Add(EndDelay);
            Label PostWait = new Label(); PostWait.AccessibleDescription = "PostWait"; PostWait.Visible = false; this.Controls.Add(PostWait);

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

            Label Auto = new Label(); Auto.AccessibleDescription = "Auto"; Auto.Visible = false; this.Controls.Add(Auto);

            lv_No.Columns.Add("");
            for (int i = -2; i < TModelList.MAX_MODEL + 2; i++)
            {
                if (i < 0)
                    lv_No.Items.Add("");
                else
                    if (i < TModelList.MAX_MODEL) lv_No.Items.Add(i.ToString());
                if (i == TModelList.MAX_MODEL + 0)
                    lv_No.Items.Add("All");
                if (i == TModelList.MAX_MODEL + 1)
                    lv_No.Items.Add("All");
            }

            for (int i = 0; i < TModelList.MAX_PARA; i++)
            {
                lv_Model.Columns.Add("");
                lv_Model.Columns[i].Width = 70;
            }

            TopMost = true;
            BringToFront();
        }

        private void frmDispProg_Model_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Model List [" + GDefine.ProgRecipeName + "]";

            Advance = false;
            UpdateDisplay();
            RefreshModelList();
        }

        private void UpdateDisplay()
        {
            if (!Advance)
            {
                btn_Basic.FlatStyle = FlatStyle.Popup;
                btn_Advance.FlatStyle = FlatStyle.Standard;
            }
            else
            {
                btn_Basic.FlatStyle = FlatStyle.Standard;
                btn_Advance.FlatStyle = FlatStyle.Popup;
            }
            lbl_PanelGap.Text = DispProg.ModelList.PanelGap.ToString("F3");
            lbl_FirstGapWait.Text = DispProg.ModelList.FirstGapWait.ToString();
        }

        public void RefreshModelList()
        {
            lv_Model.Items.Clear();

            if (!Advance)
            {
                for (int model = -2; model < TModelList.MAX_MODEL + 2; model++)
                {
                    string[] Line = new string[TModelList.MAX_PARA];

                    if (model == -2)
                    {
                        for (int i = 0; i < DispProg.ModelList.BasicPara.Count(); i++)
                        {
                            string S = Enum.GetName(typeof(TModelList.EModel), DispProg.ModelList.BasicPara[i]);
                            Line[i] = AppLanguage.Func2.GetText(this, "Label", S);
                        }
                    }
                    if (model == -1)
                    {
                        for (int i = 0; i < DispProg.ModelList.BasicPara.Count(); i++)
                        {
                            if (DispProg.Pump_Type == TaskDisp.EPumpType.PP || DispProg.Pump_Type == TaskDisp.EPumpType.PP2D || DispProg.Pump_Type == TaskDisp.EPumpType.PPD)
                                Line[i] = "(" + TModelList.PPModelUnits[DispProg.ModelList.BasicPara[i]] + ")";
                            else
                                Line[i] = "(" + TModelList.HMModelUnits[DispProg.ModelList.BasicPara[i]] + ")";

                            string S = Enum.GetName(typeof(TModelList.EModel), DispProg.ModelList.BasicPara[i]);
                            if (S.Contains("Press")) Line[i] = "(" + FPressCtrl.PressUnitStr + ")";
                        }
                    }
                    if (model >= 0 && model < TModelList.MAX_MODEL)
                    {
                        for (int i = 0; i < DispProg.ModelList.BasicPara.Count(); i++)
                        {
                            string S = Enum.GetName(typeof(TModelList.EModel), DispProg.ModelList.BasicPara[i]);

                            Line[i] = DispProg.ModelList.Model[model].Para[DispProg.ModelList.BasicPara[i]].ToString();
                            if (DispProg.ModelList.Model[model].Para[DispProg.ModelList.BasicPara[i]] == 0)
                            {
                                if (S.Contains("StartV") || S.Contains("Speed") || S.Contains("Spd") || S.Contains("Accel"))
                                {
                                    Line[i] = AppLanguage.Func2.GetText(this, "Label", "Auto");
                                }
                                else
                                if (S.Contains("Vol") || S.Contains("Press"))
                                {
                                    Line[i] = AppLanguage.Func2.GetText(this, "Label", "Default");
                                }
                            }
                            else
                            {
                                if (S.Contains("Press")) Line[i] = FPressCtrl.GetPressStr(DispProg.ModelList.Model[model].Para[DispProg.ModelList.BasicPara[i]]);
                            }
                        }
                    }
                    if (model == TModelList.MAX_MODEL)
                        for (int i = 0; i < DispProg.ModelList.BasicPara.Count(); i++)
                        {
                            Line[i] = "ABS";
                        }

                    if (model == TModelList.MAX_MODEL + 1)
                        for (int i = 0; i < DispProg.ModelList.BasicPara.Count(); i++)
                        {
                            Line[i] = "REL";
                        }

                    ListViewItem lvi = new ListViewItem(Line);
                    lv_Model.Items.Add(lvi);
                }
            }

            if (Advance)
            {
                for (int model = -2; model < TModelList.MAX_MODEL + 2; model++)
                {
                    string[] Line = new string[TModelList.MAX_PARA];

                    if (model == -2)
                    {
                        for (int i = 0; i < TModelList.MAX_PARA; i++)
                        {
                            string S = Enum.GetName(typeof(TModelList.EModel), i);
                            //Line[i] = S;
                            Line[i] = AppLanguage.Func2.GetText(this, "Label", S);
                        }
                    }
                    if (model == -1)
                    {
                        for (int i = 0; i < TModelList.MAX_PARA; i++)
                        {
                            if (DispProg.Pump_Type == TaskDisp.EPumpType.PP || DispProg.Pump_Type == TaskDisp.EPumpType.PP2D || DispProg.Pump_Type == TaskDisp.EPumpType.PPD)
                                Line[i] = "(" + TModelList.PPModelUnits[i] + ")";
                            else
                                Line[i] = "(" + TModelList.HMModelUnits[i] + ")";

                            string S = Enum.GetName(typeof(TModelList.EModel), i);
                            if (S.Contains("Press")) Line[i] = "(" + FPressCtrl.PressUnitStr + ")";
                        }
                    }
                    if (model >= 0 && model < TModelList.MAX_MODEL)
                    {
                        for (int i = 0; i < TModelList.MAX_PARA; i++)
                        {
                            string S = Enum.GetName(typeof(TModelList.EModel), i);

                            Line[i] = DispProg.ModelList.Model[model].Para[i].ToString();
                            if (DispProg.ModelList.Model[model].Para[i] == 0)
                            {
                                if (S.Contains("StartV") || S.Contains("Speed") || S.Contains("Spd") || S.Contains("Accel"))
                                {
                                    Line[i] = AppLanguage.Func2.GetText(this, "Label", "Auto");
                                }
                                else
                                if (S.Contains("Vol") || S.Contains("Press"))
                                {
                                    Line[i] = AppLanguage.Func2.GetText(this, "Label", "Default");
                                }
                            }
                            else
                            {
                                if (S.Contains("Press")) Line[i] = FPressCtrl.GetPressStr(DispProg.ModelList.Model[model].Para[i]);
                            }

                        }
                    }
                    if (model == TModelList.MAX_MODEL)
                        for (int i = 0; i < TModelList.MAX_PARA; i++)
                        {
                            Line[i] = "ABS";
                        }

                    if (model == TModelList.MAX_MODEL + 1)
                        for (int i = 0; i < TModelList.MAX_PARA; i++)
                        {
                            Line[i] = "REL";
                        }
                    ListViewItem lvi = new ListViewItem(Line);
                    lv_Model.Items.Add(lvi);
                }
            }
        }

        private void btn_Basic_Click(object sender, EventArgs e)
        {
            Advance = false;
            UpdateDisplay();
            RefreshModelList();
        }
        private void btn_Advance_Click(object sender, EventArgs e)
        {
            Advance = true;
            UpdateDisplay();
            RefreshModelList();
        }

        private void lv_Model_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i_ModelNo;
                int i_IndexNo;

                Point mousePosition = lv_Model.PointToClient(Control.MousePosition);
                ListViewHitTestInfo hit = lv_Model.HitTest(mousePosition);
                if (hit.Item != null)
                {
                    if (hit.Item.Index < 2) return;

                    i_ModelNo = hit.Item.Index - 2;
                    i_IndexNo = hit.Item.SubItems.IndexOf(hit.SubItem);

                    if (Advance)
                    {
                        #region Advance Editor
                        #region Define Limit
                        string ParaName = Enum.GetName(typeof(TModelList.EModel), i_IndexNo);
                        double Min = 0;
                        double Max = 0;
                        try
                        {
                            if (ParaName.Contains("StartV"))
                            {
                                CommonControl.GetMotorSpeedRange(TaskGantry.GZAxis, ref Min, ref Max);
                                Min = 0;
                                Max = Math.Min(100, Max);
                            }
                            if (ParaName.Contains("Speed") || ParaName.Contains("Spd"))
                            {
                                if (ParaName.Contains("Pump"))
                                {
                                    Min = 0;
                                    Max = 0;
                                    if (GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC_OBSOLETE)
                                    {
                                        Min = -8000;
                                        Max = 0;
                                    }
                                    if (GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC15)
                                    {
                                        Min = 0;
                                        Max = TaskDisp.HM_Max_RPM;
                                    }
                                }
                                else
                                {
                                    CommonControl.GetMotorSpeedRange(TaskGantry.GZAxis, ref Min, ref Max);
                                    Min = 0;
                                    Max = Math.Min(500, Max);
                                }
                            }
                            if (ParaName.Contains("Accel"))
                            {
                                CommonControl.GetMotorAccelRange(TaskGantry.GZAxis, ref Min, ref Max);
                                Min = 0;
                                Max = Math.Min(5000, Max);
                            }
                            if (ParaName.Contains("Gap"))
                            {
                                Min = 0;
                                Max = 50;
                            }
                            if (ParaName.Contains("Dist"))
                            {
                                Min = -50;
                                Max = 50;
                            }
                            if (ParaName.Contains("Wait") || ParaName.Contains("Delay") || ParaName.Contains("Time"))
                            {
                                Min = 0;
                                Max = 20000;
                            }
                            if (ParaName.Contains("Vol"))
                            {
                                Min = TModelList.WarnLLimit[i_IndexNo];
                                Max = TModelList.WarnULimit[i_IndexNo];
                            }
                            if (ParaName.Contains("Press"))
                            {
                                Min = 0;
                                Max = 130;
                            }
                            if (ParaName.Contains("Ch"))
                            {
                                Min = 0;
                                Max = 9;
                            }
                        }
                        catch { };
                        #endregion

                        if (i_ModelNo >= 0 && i_ModelNo < TModelList.MAX_MODEL)
                        {
                            #region
                            double d_ParaValue = DispProg.ModelList.Model[i_ModelNo].Para[i_IndexNo];
                            if (!UC.AdjustExec("Model " + i_ModelNo.ToString() + ", " + ParaName, ref d_ParaValue, Min, Max)) return;

                            if (TModelList.WarnLLimit[i_IndexNo] > 0 || TModelList.WarnULimit[i_IndexNo] > 0)
                            {
                                if (d_ParaValue < TModelList.WarnLLimit[i_IndexNo])
                                {
                                    DialogResult dr = MessageBox.Show(ParaName + "=" + d_ParaValue + " is value less than Warning Limit." + (char)13 + "Continue with the new value?", "Warning", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.No) return;
                                }
                                if (d_ParaValue > TModelList.WarnULimit[i_IndexNo])
                                {
                                    DialogResult dr = MessageBox.Show(ParaName + "=" + d_ParaValue + " is value more than Warning Limit." + (char)13 + "Continue with the new value?", "Warning", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.No) return;
                                }
                            }
                            DispProg.ModelList.Model[i_ModelNo].Para[i_IndexNo] = d_ParaValue;
                            if (i_IndexNo == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[i_ModelNo].Set($"{DispProg.ModelList.Model[i_ModelNo].Para[i_IndexNo]:f3}");
                            #endregion
                        }
                        if (i_ModelNo == TModelList.MAX_MODEL)//***Adjust Abs All Model
                        {
                            #region
                            double d_ParaValue = DispProg.ModelList.Model[0].Para[i_IndexNo];
                            if (!UC.AdjustExec("Models (All), " + ParaName + " Absolute Adjust", ref d_ParaValue, Min, Max)) return;

                            if (TModelList.WarnLLimit[i_IndexNo] > 0 || TModelList.WarnULimit[i_IndexNo] > 0)
                            {
                                if (d_ParaValue < TModelList.WarnLLimit[i_IndexNo])
                                {
                                    DialogResult dr = MessageBox.Show(ParaName + "=" + d_ParaValue + " is value less than Warning Limit." + (char)13 + "Continue with the new value?", "Warning", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.No) return;
                                }
                                if (d_ParaValue > TModelList.WarnULimit[i_IndexNo])
                                {
                                    DialogResult dr = MessageBox.Show(ParaName + "=" + d_ParaValue + " is value more than Warning Limit." + (char)13 + "Continue with the new value?", "Warning", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.No) return;
                                }
                            }
                            for (int model = 0; model < TModelList.MAX_MODEL; model++)
                            {
                                DispProg.ModelList.Model[model].Para[i_IndexNo] = d_ParaValue;
                                if (i_IndexNo == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[i_ModelNo].Set($"{DispProg.ModelList.Model[model].Para[i_IndexNo]:f3}");
                            }
                            #endregion
                        }
                        if (i_ModelNo == TModelList.MAX_MODEL + 1)//***Adjust Rel All Model
                        {
                            #region
                            double d_ParaValue = 0;
                            if (!UC.AdjustExec("Models (All), " + ParaName + " Relative Adjust", ref d_ParaValue, -(Min + Max) / 2, (Min + Max) / 2)) return;

                            for (int model = 0; model < TModelList.MAX_MODEL; model++)
                            {
                                DispProg.ModelList.Model[model].Para[i_IndexNo] = DispProg.ModelList.Model[model].Para[i_IndexNo] + d_ParaValue;
                                if (i_IndexNo == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[i_ModelNo].Set($"{DispProg.ModelList.Model[model].Para[i_IndexNo]:f3}");

                                if (ParaName.Contains("Speed") && ParaName.Contains("Pump") && GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC_OBSOLETE)
                                {

                                }
                                else
                                {
                                    if (DispProg.ModelList.Model[model].Para[i_IndexNo] < 0)
                                        DispProg.ModelList.Model[model].Para[i_IndexNo] = 0;
                                }
                            }
                            #endregion
                        }


                        UpdateDisplay();
                        #endregion
                    }
                    else
                    {
                        #region Basic Editor
                        if (i_IndexNo >= DispProg.ModelList.BasicPara.Count()) return;

                        #region Define Limit
                        string ParaName = Enum.GetName(typeof(TModelList.EModel), DispProg.ModelList.BasicPara[i_IndexNo]);
                        double Min = 0;
                        double Max = 0;
                        try
                        {
                            if (ParaName.Contains("StartV"))
                            {
                                CommonControl.GetMotorSpeedRange(TaskGantry.GZAxis, ref Min, ref Max);
                                Min = 0;
                                Max = Math.Min(100, Max);
                            }
                            if (ParaName.Contains("Speed") || ParaName.Contains("Spd"))
                            {
                                if (ParaName.Contains("Pump"))
                                {
                                    Min = 0;
                                    Max = 0;
                                    if (GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC_OBSOLETE)
                                    {
                                        Min = -8000;
                                        Max = 0;
                                    }
                                    if (GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC15)
                                    {
                                        Min = 0;
                                        Max = TaskDisp.HM_Max_RPM;
                                    }
                                }
                                else
                                {
                                    CommonControl.GetMotorSpeedRange(TaskGantry.GZAxis, ref Min, ref Max);
                                    Min = 0;
                                    Max = Math.Min(500, Max);
                                }
                            }
                            if (ParaName.Contains("Accel"))
                            {
                                CommonControl.GetMotorAccelRange(TaskGantry.GZAxis, ref Min, ref Max);
                                Min = 0;
                                Max = Math.Min(5000, Max);
                            }
                            if (ParaName.Contains("Gap"))
                            {
                                Min = -1;
                                Max = 50;
                            }
                            if (ParaName.Contains("Dist"))
                            {
                                Min = -50;
                                Max = 50;
                            }
                            if (ParaName.Contains("Wait") || ParaName.Contains("Delay") || ParaName.Contains("Time"))
                                {
                                    Min = 0;
                                    Max = 20000;
                                }
                            if (ParaName.Contains("Vol"))
                            {
                                Min = TModelList.WarnLLimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]];
                                Max = TModelList.WarnULimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]];
                            }
                            if (ParaName.Contains("Press"))
                            {
                                Min = 0;
                                Max = 130;
                            }
                            if (ParaName.Contains("Ch"))
                            {
                                Min = 0;
                                Max = 9;
                            }
                        }
                        catch { };
                        #endregion

                        if (i_ModelNo >= 0 && i_ModelNo < TModelList.MAX_MODEL)
                        {
                            #region
                            double d_ParaValue = DispProg.ModelList.Model[i_ModelNo].Para[(int)DispProg.ModelList.BasicPara[i_IndexNo]];
                            if (!UC.AdjustExec("Model " + i_ModelNo.ToString() + ", " + ParaName, ref d_ParaValue, Min, Max)) return;

                            if (TModelList.WarnLLimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]] > 0 ||
                                TModelList.WarnULimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]] > 0)
                            {
                                if (d_ParaValue < TModelList.WarnLLimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]])
                                {
                                    DialogResult dr = MessageBox.Show(ParaName + "=" + d_ParaValue + " is value less than Warning Limit." + (char)13 + "Continue with the new value?", "Warning", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.No) return;
                                }
                                if (d_ParaValue > TModelList.WarnULimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]])
                                {
                                    DialogResult dr = MessageBox.Show(ParaName + "=" + d_ParaValue + " is value more than Warning Limit." + (char)13 + "Continue with the new value?", "Warning", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.No) return;
                                }
                            }
                            DispProg.ModelList.Model[i_ModelNo].Para[(int)DispProg.ModelList.BasicPara[i_IndexNo]] = d_ParaValue;
                            if (/*i_IndexNo*/DispProg.ModelList.BasicPara[i_IndexNo] == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[i_ModelNo].Set($"{DispProg.ModelList.Model[i_ModelNo].Para[i_IndexNo]:f3}");
                            UpdateDisplay();
                            #endregion
                        }
                        if (i_ModelNo == TModelList.MAX_MODEL)//***Adjust Abs All Model
                        {
                            #region
                            double d_ParaValue = DispProg.ModelList.Model[0].Para[(int)DispProg.ModelList.BasicPara[i_IndexNo]];
                            if (!UC.AdjustExec("Models (All), " + ParaName + " Absolute Adjust", ref d_ParaValue, Min, Max)) return;

                            if (TModelList.WarnLLimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]] > 0 ||
                                TModelList.WarnULimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]] > 0)
                            {
                                if (d_ParaValue < TModelList.WarnLLimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]])
                                {
                                    DialogResult dr = MessageBox.Show(ParaName + "=" + d_ParaValue + " is value less than Warning Limit." + (char)13 + "Continue with the new value?", "Warning", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.No) return;
                                }
                                if (d_ParaValue > TModelList.WarnULimit[(int)DispProg.ModelList.BasicPara[i_IndexNo]])
                                {
                                    DialogResult dr = MessageBox.Show(ParaName + "=" + d_ParaValue + " is value more than Warning Limit." + (char)13 + "Continue with the new value?", "Warning", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.No) return;
                                }
                            }
                            for (int model = 0; model < TModelList.MAX_MODEL; model++)
                            {
                                DispProg.ModelList.Model[model].Para[(int)DispProg.ModelList.BasicPara[i_IndexNo]] = d_ParaValue;
                                //if (i_IndexNo == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[i_ModelNo].Set($"{DispProg.ModelList.Model[model].Para[i_IndexNo]:f3}");
                                if (/*i_IndexNo*/DispProg.ModelList.BasicPara[i_IndexNo] == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[i_ModelNo].Set($"{DispProg.ModelList.Model[i_ModelNo].Para[i_IndexNo]:f3}");
                            }
                            #endregion
                        }
                        if (i_ModelNo == TModelList.MAX_MODEL + 1)//***Adjust Rel All Model
                        {
                            #region
                            double d_ParaValue = 0;
                            if (!UC.AdjustExec("Models (All), " + ParaName + " Relative Adjust", ref d_ParaValue, -(Min + Max) / 2, (Min + Max) / 2)) return;

                            for (int model = 0; model < TModelList.MAX_MODEL; model++)
                            {
                                DispProg.ModelList.Model[model].Para[(int)DispProg.ModelList.BasicPara[i_IndexNo]] = DispProg.ModelList.Model[model].Para[(int)DispProg.ModelList.BasicPara[i_IndexNo]] + d_ParaValue;
                                //if (i_IndexNo == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[i_ModelNo].Set($"{DispProg.ModelList.Model[model].Para[i_IndexNo]:f3}");
                                if (/*i_IndexNo*/DispProg.ModelList.BasicPara[i_IndexNo] == (int)TModelList.EModel.LineSpeed) Para.LineSpeed[i_ModelNo].Set($"{DispProg.ModelList.Model[i_ModelNo].Para[i_IndexNo]:f3}");

                                if (ParaName.Contains("Speed") && ParaName.Contains("Pump") && GDefine.DispCtrlType[0] == GDefine.EDispCtrlType.HPC_OBSOLETE)
                                {

                                }
                                else
                                {
                                    if (DispProg.ModelList.Model[model].Para[(int)DispProg.ModelList.BasicPara[i_IndexNo]] < 0)
                                        DispProg.ModelList.Model[model].Para[(int)DispProg.ModelList.BasicPara[i_IndexNo]] = 0;
                                }
                            }
                            #endregion
                        }


                        #endregion
                    }

                    RefreshModelList();
                }
                else return;
            }
        }

        private void lbl_PanelGap_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Model, Panel Gap", ref DispProg.ModelList.PanelGap, 0, 20);
            UpdateDisplay();
        }
        private void lbl_FirstGapWait_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Model, First Gap Wait", ref DispProg.ModelList.FirstGapWait, 0, 5000);
            UpdateDisplay();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DispProg.ModelList.Save(GDefine.ProgPath + "\\" + GDefine.ProgRecipeName + ".Model.ini");
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DispProg.ModelList.Load(GDefine.ProgPath + "\\" + GDefine.ProgRecipeName + ".model.ini");
            Log.OnAction("Cancel", "Model");
            Close();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Log.OnAction("OK", "Model");
            Close();
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            RefreshModelList();

            this.TopMost = false;

            frm_DispCore_DispProg_ModelListSetting frm = new frm_DispCore_DispProg_ModelListSetting();
            frm.BringToFront();
            frm.ShowDialog();

            this.TopMost = true;
        }
        private void lv_Model_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
