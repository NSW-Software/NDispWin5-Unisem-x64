using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDispWin
{
    public partial class frm_MHS2ConvCtrl : Form
    {
        public frm_MHS2ConvCtrl()
        {
            InitializeComponent();

            gbox_Buf1.Visible = TaskConv.Buf1.StType == TaskConv.EBufStType.Buffer;
            gbox_Buf2.Visible = TaskConv.Buf2.StType == TaskConv.EBufStType.Buffer;
            gbox_Pre.Visible = TaskConv.Pre.StType > TaskConv.EPreStType.None;

            gboxSmemaLeftIn.Visible = TaskConv.LeftMode == TaskConv.ELeftMode.Smema || TaskConv.LeftMode == TaskConv.ELeftMode.Smema_SmemaRight || TaskConv.LeftMode == TaskConv.ELeftMode.SmemaBiDirection;
            gboxSmemaLeftOut.Visible = TaskConv.LeftMode == TaskConv.ELeftMode.Smema_SmemaRight || TaskConv.LeftMode == TaskConv.ELeftMode.SmemaBiDirection;
            gboxSmemaLeftOut.Text = "Smema Left (Out*)";
            gboxSmemaRightOut.Visible = TaskConv.RightMode == TaskConv.ERightMode.Smema || TaskConv.RightMode == TaskConv.ERightMode.Smema_SmemaLeft || TaskConv.RightMode == TaskConv.ERightMode.SmemaBiDirection;
            gboxSmemaRightIn.Visible = TaskConv.RightMode == TaskConv.ERightMode.Smema_SmemaLeft || TaskConv.RightMode == TaskConv.ERightMode.SmemaBiDirection;
            gboxSmemaRightIn.Text = "Smema Right (In*)";
        }

        private void frm_ConvCtrl_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
        }

        private void UpdateDisplay()
        {
            string S = "";
            lbl_Note.Text = TaskMHS.CustomMode > 0 ? TaskMHS.CustomMode.ToString() : "*";

            S = (TaskConv.Buf1.rt_StType == TaskConv.Buf1.StType) ? "" : "*";
            S = "Buf1 (" + S + TaskConv.Buf1.rt_StType.ToString() + ")";
            gbox_Buf1.Text = S;

            S = (TaskConv.Buf2.rt_StType == TaskConv.Buf2.StType) ? "" : "*";
            S = "Buf2 (" + S + TaskConv.Buf2.rt_StType.ToString() + ")";
            gbox_Buf2.Text = S;

            S = (TaskConv.Pre.rt_StType == TaskConv.Pre.StType) ? "" : "*";
            S = "Pre (" + S + TaskConv.Pre.rt_StType.ToString() + ")";
            gbox_Pre.Text = S;

            S = (TaskConv.Pro.rt_StType == TaskConv.Pro.StType) ? "" : "*";
            S = "Pro (" + S + TaskConv.Pro.rt_StType.ToString() + ")";
            gbox_Pro.Text = S;

            lbl_ConvSt.Text = TaskConv.Status.ToString();
            lbl_ConvSt.BackColor = TaskConv.StatusColor;

            #region Process Station Status
            string text;
            if (TaskConv.In.SensPsnt)
            {
                text = TaskConv.EProcessStatus.Psnt.ToString();
                lbl_InStatus.BackColor = Color.Lime;
            }
            else
            {
                text = TaskConv.EProcessStatus.Empty.ToString();
                lbl_InStatus.BackColor = Color.LightGray;
            }
            if (TaskConv.OutLevelFollowInLevel) text += $"\r(L {TaskConv.In.InLevel})";
            lbl_InStatus.Text = text;

            text = TaskConv.Buf1.Status.ToString();
            if (TaskConv.OutLevelFollowInLevel) text += $"\r(L {TaskConv.Buf1.InLevel})";
            lbl_Buf1St.Text = text;
            lbl_Buf1St.BackColor = TaskConv.Buf1.StatusColor;

            text = TaskConv.Buf2.Status.ToString();
            if (TaskConv.OutLevelFollowInLevel) text += $"\r(L {TaskConv.Buf2.InLevel})";
            lbl_Buf2St.Text = text;
            lbl_Buf2St.BackColor = TaskConv.Buf2.StatusColor;

            text = TaskConv.Pre.Status.ToString();
            if (TaskConv.Pre.Status == TaskConv.EProcessStatus.Heating)
                text = TaskConv.Pre.Status.ToString() + " (" + Math.Max(0, TaskConv.Pre.HeatRemain_s) + ")";
            if (TaskConv.OutLevelFollowInLevel) text += $"\r(L {TaskConv.Pre.InLevel})";
            lbl_PreSt.Text = text;
            lbl_PreSt.BackColor = TaskConv.Pre.StatusColor;

            text = TaskConv.Pro.Status.ToString();
            if (TaskConv.Pro.Status == TaskConv.EProcessStatus.Heating)
                text = TaskConv.Pro.Status.ToString() + " (" + Math.Max(0, TaskConv.Pro.HeatRemain_s) + ")";
            if (TaskConv.OutLevelFollowInLevel) text += $"\r(L {TaskConv.Pro.InLevel})";
            lbl_ProSt.Text = text;
            lbl_ProSt.BackColor = TaskConv.Pro.StatusColor;

            text = TaskConv.Out.Status.ToString();
            if (TaskConv.OutLevelFollowInLevel) text += $"\r(L {TaskConv.Out.InLevel})";
            lbl_OutSt.Text = text;
            lbl_OutSt.BackColor = TaskConv.Out.StatusColor;
            #endregion

            Color color = this.BackColor;
            if (TaskConv.StopInput) color = Color.Lime;
            btn_StopInput.BackColor = color;

            color = this.BackColor;
            if (TaskConv.SkipDisp) color = Color.Lime;
            btn_SkipDisp.BackColor = color;

            color = this.BackColor;
            if (TaskConv.DispEndStop) color = Color.Lime;
            btn_DispEndStop.BackColor = color;

            color = this.BackColor;
            if (TaskConv.UnloadStop) color = Color.Lime;
            btn_UnloadStop.BackColor = color;

            if (TaskConv.BoardIsOpen)
            {
                lblLeftSmemaBdReady.BackColor = TaskConv.In.Smema_DI_BdReady ? Color.Lime : this.BackColor;
                lblLeftSmemaMcReady.BackColor = TaskConv.In.Smema_DO_McReady ? Color.Red : this.BackColor;
                lblLeftSmema2McReady.BackColor = TaskConv.In.Smema2_DI_McReady ? Color.Lime : this.BackColor;
                lblLeftSmema2BdReady.BackColor = TaskConv.In.Smema2_DO_BdReady ? Color.Red : this.BackColor;
            }


            if (TaskConv.BoardIsOpen)
            {
                lbl_RightSmemaMcReady.BackColor = TaskConv.Out.Smema_DI_McReady ? Color.Lime : this.BackColor;
                lbl_RightSmemaBdReady.BackColor = TaskConv.Out.Smema_DO_BdReady ? Color.Red : this.BackColor;
                lblRightSmema2BdReady.BackColor = TaskConv.Out.Smema2_DI_BdReady ? Color.Lime : this.BackColor;
                lblRightSmema2McReady.BackColor = TaskConv.Out.Smema2_DO_McReady ? Color.Red : this.BackColor;
            }

            btn_WaitReturn.Visible = TaskConv.RightMode == TaskConv.ERightMode.Smema_SmemaLeft || TaskConv.RightMode == TaskConv.ERightMode.SmemaBiDirection;
            btn_WaitReturn.BackColor = TaskConv.bWaitingBoardReverse ? Color.Lime : this.BackColor;

            btnWaitReverseSend.Visible = TaskConv.LeftMode == TaskConv.ELeftMode.Smema_SmemaRight || TaskConv.LeftMode == TaskConv.ELeftMode.SmemaBiDirection;
            btnWaitReverseSend.BackColor = TaskConv.bWaitingBoardReverseSendout ? Color.Lime : this.BackColor;
        }

        public bool Enable
        {
            set
            {
                if (value)
                {
                    this.Enable(true, new List<string> { "btn_StopInput", "btn_SkipDisp", "btn_DispEndStop", "btn_UnloadStop" });
                }
                else
                {
                    this.Enable(false, new List<string> { "btn_StopInput", "btn_SkipDisp", "btn_DispEndStop", "btn_UnloadStop" });

                    btn_WaitReturn.Enable(true);
                    btnWaitReverseSend.Enable(true);
                    lblLeftSmemaBdReady.Enable(true);
                    lbl_RightSmemaMcReady.Enable(true);
                    lblLeftSmema2McReady.Enable(true);
                    lblRightSmema2BdReady.Enable(true);
                }
            }
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            EnableParent(false);
            try
            {
                if (!TaskConv.CheckPressureSource()) return;

                TaskConv.Manual_Return();

                //Cancel Disp if Pro is returned
                bool cancelDisp = true;
                if (TaskConv.Buf1.Status == TaskConv.EProcessStatus.Psnt) cancelDisp = false;
                if (TaskConv.Buf2.Status == TaskConv.EProcessStatus.Psnt) cancelDisp = false;
                if (TaskConv.Pre.Status >= TaskConv.EProcessStatus.Heating) cancelDisp = false;
                if (cancelDisp) DispProg.TR_Cancel();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Manual_Return " + ex.Message.ToString());
            }
            finally
            {
                EnableParent(true);
            }
        }
        private void btn_LoadBuf1_Click(object sender, EventArgs e)
        {
            EnableParent(false);
            try
            {
                TaskConv.Manual_LoadBuf1();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Manual_LoadBuf1 " + ex.Message.ToString());
            }
            finally
            {
                EnableParent(true);
            }
        }
        private void btn_LoadBuf2_Click(object sender, EventArgs e)
        {
            EnableParent(false);
            try
            {
                TaskConv.Manual_LoadBuf2();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Manual_LoadBuf2 " + ex.Message.ToString());
            }
            finally
            {
                EnableParent(true);
            }
        }

        private void EnableParent(bool Enable)
        {
            Enabled = Enable;
            try
            {
                if (Parent != null) { Parent.Enabled = Enable; } else return;
                if (Parent.Parent != null) { Parent.Parent.Enabled = Enable; } else return;
                if (Parent.Parent.Parent != null) { Parent.Parent.Parent.Enabled = Enable; } else return;
                if (Parent.Parent.Parent.Parent != null) { Parent.Parent.Parent.Parent.Enabled = Enable; } else return;
                if (Parent.Parent.Parent.Parent.Parent != null) { Parent.Parent.Parent.Parent.Parent.Enabled = Enable; } else  return;
                if (Parent.Parent.Parent.Parent.Parent.Parent != null) { Parent.Parent.Parent.Parent.Parent.Parent.Enabled = Enable; }
            }
            catch (Exception ex)
            {
                Event.DEBUG_INFO.Set(MethodBase.GetCurrentMethod().Name.ToString(), ex.Message.ToString());
            }
        }
        private void btn_LoadPre_Click(object sender, EventArgs e)
        {
            EnableParent(false);
            try
            {
                if (TaskConv.Out.Status == TaskConv.EProcessStatus.Psnt)
                {
                    if (TaskConv.Out.SensPsnt)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.CONV_OUT_SENSOR_PSNT);
                    }
                    else
                        TaskConv.Out.Status = TaskConv.EProcessStatus.Empty;
                }

                if (TaskConv.Pre.SensPsnt)
                {
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.CONV_SENSOR_PART_PSNT, "PRE", EMcState.Error, EMsgBtn.smbStop, true);
                    TaskConv.Status = TaskConv.EConvStatus.Stop;
                }

                if (!TaskConv.CheckPressureSource()) return;

                TaskConv.Manual_LoadPre();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Manual_LoadPre " + ex.Message.ToString());
            }
            finally
            {
                EnableParent(true);
            }
        }
        private void btn_LoadPro_Click(object sender, EventArgs e)
        {
            EnableParent(false);
            try
            {
                if (TaskConv.Out.Status == TaskConv.EProcessStatus.Psnt)
                {
                    if (TaskConv.Out.SensPsnt)
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.CONV_OUT_SENSOR_PSNT);
                    }
                    else
                        TaskConv.Out.Status = TaskConv.EProcessStatus.Empty;
                }

                if (TaskConv.Pro.SensPsnt)
                {
                    Msg MsgBox = new Msg();
                    EMsgRes MsgRes = MsgBox.Show(ErrCode.CONV_SENSOR_PART_PSNT, "PRO", EMcState.Error, EMsgBtn.smbStop, true);
                    TaskConv.Status = TaskConv.EConvStatus.Stop;
                }

                if (!TaskConv.CheckPressureSource()) return;

                TaskConv.Manual_LoadPro();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Manual_LoadPro " + ex.Message.ToString());
            }
            finally
            {
                EnableParent(true);
            }
        }
        private void btn_Unload_Click(object sender, EventArgs e)
        {
            EnableParent(false);
            try
            {
                if (!TaskConv.CheckPressureSource()) return;

                TaskConv.Manual_Unload();
                DispProg.TR_Cancel();
            }
            catch (Exception ex)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Manual_Unload " + ex.Message.ToString());
            }
            finally
            {
                EnableParent(true);
            }
        }

        private void btn_StopInput_Click(object sender, EventArgs e)
        {
            TaskConv.StopInput = !TaskConv.StopInput;
            Event.OP_OPTION_CHANGED.Set("StopInput", TaskConv.StopInput.ToString());

            switch (TaskConv.LeftMode)
            {
                case TaskConv.ELeftMode.Smema:
                case TaskConv.ELeftMode.Smema_SmemaRight:
                case TaskConv.ELeftMode.SmemaBiDirection:
                    TaskConv.In.Smema_DO_McReady = false;
                    break;
            }

            if (TaskConv.Pro.rt_StType == TaskConv.EProStType.Disp12)
            {
                if (TaskConv.Pro.Status == TaskConv.EProcessStatus.WaitDisp2)
                {
                    TaskConv.Pre.Status = TaskConv.EProcessStatus.WaitNone;
                    TaskConv.Pro.Status = TaskConv.EProcessStatus.WaitDisp;
                }
            }
        }
        private void btn_SkipDisp_Click(object sender, EventArgs e)
        {
            TaskConv.SkipDisp = !TaskConv.SkipDisp;
            Event.OP_OPTION_CHANGED.Set("SkipDisp", TaskConv.SkipDisp.ToString());

            UpdateDisplay();
        }
        private void btn_DispEndStop_Click(object sender, EventArgs e)
        {
            TaskConv.DispEndStop = !TaskConv.DispEndStop;
            Event.OP_OPTION_CHANGED.Set("DispEndStop", TaskConv.DispEndStop.ToString());

            UpdateDisplay();
        }
        private void btn_BoardEndStop_Click(object sender, EventArgs e)
        {
            TaskConv.UnloadStop = !TaskConv.UnloadStop;
            Event.OP_OPTION_CHANGED.Set("UnloadStop", TaskConv.UnloadStop.ToString());

            UpdateDisplay();
        }

        private void lbl_ConvSt_DoubleClick(object sender, EventArgs e)
        {
            if (NUtils.UserAcc.Active.GroupID == (int)ELevel.NSW)
                TaskConv.Status = TaskConv.EConvStatus.Ready;
            UpdateDisplay();
        }

        private void lbl_PreSt_DoubleClick(object sender, EventArgs e)
        {
            if (NUtils.UserAcc.Active.GroupID == (int)ELevel.NSW)
                if (TaskConv.Pre.Status == TaskConv.EProcessStatus.Psnt)
                    TaskConv.Pre.Status = (TaskConv.EProcessStatus)0;
                else
                    TaskConv.Pre.Status++;
            UpdateDisplay();
        }

        private void lbl_ProSt_DoubleClick(object sender, EventArgs e)
        {
            if (NUtils.UserAcc.Active.GroupID == (int)ELevel.NSW)
                if (TaskConv.Pro.Status == TaskConv.EProcessStatus.Psnt)
                    TaskConv.Pro.Status = (TaskConv.EProcessStatus)0;
                else
                    TaskConv.Pro.Status++;
            UpdateDisplay();
        }

        private void btn_WaitReturn_Click(object sender, EventArgs e)
        {
            TaskConv.WaitBoardReverse = !TaskConv.WaitBoardReverse;
        }
        private void btnWaitReverseSend_Click(object sender, EventArgs e)
        {
            TaskConv.WaitBoardReverseSend = !TaskConv.WaitBoardReverseSend;
        }

        #region Smema
        private void btn_UL_RecvBoard_Click(object sender, EventArgs e)
        {
            switch (TaskConv.LeftMode)
            {
                case TaskConv.ELeftMode.Smema:
                case TaskConv.ELeftMode.Smema_SmemaRight:
                case TaskConv.ELeftMode.SmemaBiDirection:
                    {
                        if (TaskConv.Out.Status != TaskConv.EProcessStatus.Empty) return;

                        try
                        {
                            Task.Run(() =>
                            {
                                bool InPsnt = false;
                                if (!TaskConv.In.Smema_DO_McReady)
                                {
                                    TaskConv.In.Smema_DO_McReady = true;
                                }

                                Stopwatch sw = Stopwatch.StartNew();
                                while (!TaskConv.In.Smema_DI_BdReady)
                                {
                                    if (sw.Elapsed.TotalSeconds >= 10)
                                    {
                                        TaskConv.In.Smema_DO_McReady = false;
                                        return;
                                    }
                                    Thread.Sleep(5);
                                }

                                if (TaskConv.In.Smema_DI_BdReady)
                                {
                                    InPsnt = false;
                                    if (!TaskConv.In.UL_WaitBdNotReady())
                                    {
                                        TaskConv.In.Smema_DO_McReady = false;
                                        return;
                                    }
                                    InPsnt = true;
                                }
                                else
                                {
                                    InPsnt = false;
                                }

                                if (InPsnt)
                                {
                                    if (TaskConv.Buf1.StType == TaskConv.EBufStType.Buffer && TaskConv.Buf1.Status == TaskConv.EProcessStatus.Empty)
                                    {
                                        TaskConv.MoveInToBuf1();
                                        return;
                                    }
                                    if (TaskConv.Buf2.StType == TaskConv.EBufStType.Buffer && TaskConv.Buf2.Status == TaskConv.EProcessStatus.Empty)
                                    {
                                        TaskConv.MoveInToBuf2();
                                        return;
                                    }
                                    if (TaskConv.Pre.StType >= TaskConv.EPreStType.None || TaskConv.Pre.Status == TaskConv.EProcessStatus.Empty)
                                    {
                                        TaskConv.MoveInToPre();
                                        return;
                                    }
                                    if (TaskConv.Pro.StType >= TaskConv.EProStType.None || TaskConv.Pro.Status == TaskConv.EProcessStatus.Empty)
                                    {
                                        TaskConv.MoveInToPro();
                                        return;
                                    }
                                }
                            });
                        }
                        catch (Exception Ex)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show("UL Recv Board Run Async " + Ex.Message.ToString());
                        }
                        finally
                        {
                        }
                        break;
                    }
            }
        }
        private void btnULSendBoard_Click(object sender, EventArgs e)
        {
            switch (TaskConv.LeftMode)
            {
                case TaskConv.ELeftMode.Smema_SmemaRight:
                case TaskConv.ELeftMode.SmemaBiDirection:
                    {
                        try
                        {
                            Task.Run(() =>
                            {
                                TaskConv.In.Smema2_DO_BdReady = true;
                                Stopwatch sw = Stopwatch.StartNew();
                                while (!TaskConv.In.Smema2_DI_McReady)
                                {
                                    if (sw.Elapsed.TotalSeconds >= 10)
                                    {
                                        TaskConv.In.Smema2_DO_BdReady = false;
                                        return;
                                    }
                                    Thread.Sleep(5);
                                }

                                if (TaskConv.In.Smema2_DI_McReady)
                                {
                                    //TaskConv.In.Smema2_DO_BdReady = true;
                                    if (!TaskConv.Run_ReverseSendOut())
                                    {
                                        //TaskConv.In.Smema2_DO_BdReady = false;
                                        return;
                                    }
                                    if (!TaskConv.In.SensPsnt) TaskConv.bWaitingBoardReverseSendout = false;
                                    //TaskConv.In.Smema2_DO_BdReady = false;

                                _Retry:
                                    int TOut = Environment.TickCount + TaskConv.Setup.Pre[(int)TaskConv.EPara.TimeOut];
                                    while (true)
                                    {
                                        if (!TaskConv.In.SensPsnt) break;
                                        Thread.Sleep(5);
                                        if (Environment.TickCount >= TOut)
                                        {
                                            Msg MsgBox = new Msg();
                                            EMsgRes MsgRes = MsgBox.Show(ErrCode.CONV_SMEMA_LEFT_BOARD_OUT_TIMEOUT, EMcState.Error, EMsgBtn.smbRetry_Stop, false);
                                            switch (MsgRes)
                                            {
                                                case EMsgRes.smrRetry: goto _Retry;
                                                case EMsgRes.smrStop:
                                                    {
                                                        TaskConv.Status = TaskConv.EConvStatus.Stop;
                                                        return;
                                                    }
                                            }
                                        }
                                    }
                                }
                            });
                        }
                        catch (Exception Ex)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show("UL Send Board Run Async " + Ex.Message.ToString());
                        }
                        finally
                        {
                        }
                        break;
                    }
            }
        }

        private void btn_DL_SendBoard_Click(object sender, EventArgs e)
        {
            switch (TaskConv.RightMode)
            {
                case TaskConv.ERightMode.Smema:
                case TaskConv.ERightMode.Smema_SmemaLeft:
                case TaskConv.ERightMode.SmemaBiDirection:
                    {
                        try
                        {
                            Task.Run(() =>
                            {
                                TaskConv.Out.Smema_DO_BdReady = true;
                                Stopwatch sw = Stopwatch.StartNew();
                                while (!TaskConv.Out.Smema_DI_McReady)
                                {
                                    if (sw.Elapsed.TotalSeconds >= 10)
                                    {
                                        TaskConv.Out.Smema_DO_BdReady = false;
                                        return;
                                    }
                                    Thread.Sleep(5);
                                }

                                if (TaskConv.Out.Smema_DI_McReady)
                                {
                                    TaskConv.Out.Smema_DO_BdReady = true;
                                    if (!TaskConv.Unload_Out())
                                    {
                                        TaskConv.Out.Smema_DO_BdReady = false;
                                        return;
                                    }
                                    TaskConv.Out.Smema_DO_BdReady = false;
                                    if (!TaskConv.Out.DL_WaitMcNotReady()) return;
                                }
                            });
                        }
                        catch (Exception Ex)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show("UL Send Board Run Async " + Ex.Message.ToString());
                        }
                        finally
                        {
                        }
                        break;
                    }
            }
        }
        private void btn_DL_RecvBoard_Click(object sender, EventArgs e)
        {
            switch (TaskConv.RightMode)
            {
                case TaskConv.ERightMode.Smema_SmemaLeft:
                case TaskConv.ERightMode.SmemaBiDirection:
                    {
                        try
                        {
                            Task.Run(() =>
                            {
                                TaskConv.Out.Smema2_DO_McReady = true;

                                Stopwatch sw = Stopwatch.StartNew();
                                while (!TaskConv.Out.Smema2_DI_BdReady)
                                {
                                    if (sw.Elapsed.TotalSeconds >= 10)
                                    {
                                        TaskConv.Out.Smema2_DO_McReady = false;
                                        return;
                                    }
                                    Thread.Sleep(5);
                                }

                                TaskConv.Run_ReverseMoveIn();
                            });
                        }
                        catch (Exception Ex)
                        {
                            Msg MsgBox = new Msg();
                            MsgBox.Show("DL Recv Board Run Async " + Ex.Message.ToString());
                        }
                        finally
                        {
                        }
                        break;
                    }
            }
        }
        #endregion

        private void lblLeftSmemaBdReady_MouseDown(object sender, MouseEventArgs e)
        {
            TaskConv.In.Smema_Emulate_DI_BdReady = true;
        }
        private void lblLeftSmemaBdReady_MouseUp(object sender, MouseEventArgs e)
        {
            TaskConv.In.Smema_Emulate_DI_BdReady = false;
        }
        private void lblLeftSmema2McReady_MouseDown(object sender, MouseEventArgs e)
        {
            TaskConv.In.Smema2_Emulate_DI_McReady = true;
        }
        private void lblLeftSmema2McReady_MouseUp(object sender, MouseEventArgs e)
        {
            TaskConv.In.Smema2_Emulate_DI_McReady = false;
        }

        private void lbl_RightSmemaMcReady_MouseDown(object sender, MouseEventArgs e)
        {
            TaskConv.Out.Smema_Emulate_DI_McReady = true;
        }
        private void lbl_RightSmemaMcReady_MouseUp(object sender, MouseEventArgs e)
        {
            TaskConv.Out.Smema_Emulate_DI_McReady = false;
        }
        private void lblRightSmema2BdReady_MouseDown(object sender, MouseEventArgs e)
        {
            TaskConv.Out.Smema2_Emulate_DI_BdReady = true;
        }
        private void lblRightSmema2BdReady_MouseUp(object sender, MouseEventArgs e)
        {
            TaskConv.Out.Smema2_Emulate_DI_BdReady = false;
        }
    }
}
