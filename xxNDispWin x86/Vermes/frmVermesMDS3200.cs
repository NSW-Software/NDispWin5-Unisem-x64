using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Vermes
{
    public partial class frmVermesMDS3200 : Form
    {
        NUtils.UserCtrl uc = new NUtils.UserCtrl();

        public TEVermesMDS3200 MDS3200 = null;

        public int CtrlNo = 0;

        public frmVermesMDS3200()
        {
            InitializeComponent();
            NDispWin.GControl.LogForm(this);

            Text = "Vermes Control" + (CtrlNo + 1).ToString();
        }

        int cycles = 0;
        private void frm_Control_Load(object sender, EventArgs e)
        {
            NDispWin.GControl.UpdateFormControl(this);
            ShowMenu(EMenu.Param);

            MDS3200 = NDispWin.TaskDisp.Vermes3200[CtrlNo];
            LogPath = NDispWin.GDefine.DataPath + "\\Parameter";

            MDS3200.vh = NDispWin.TaskDisp.Vermes_HC48[0];

            NDispWin.TaskGantry.BPress1 = (CtrlNo == 0);
            NDispWin.TaskGantry.BPress2 = (CtrlNo == 1);

            pnl_FPress.Visible = NDispWin.FPressCtrl.Enabled;

            if (MDS3200.IsOpen)
            {
                try
                {
                    cycles = MDS3200.ValveCycles;
                }
                catch { };
            }
            UpdateDisplay();
        }
        private void frmVermesMDS3200_FormClosing(object sender, FormClosingEventArgs e)
        {
            NDispWin.TaskGantry.BPress1 = false;
            NDispWin.TaskGantry.BPress2 = false;

            if (MDS3200.IsOpen)
            {
                try
                {
                    int runCycles = MDS3200.ValveCycles - cycles;
                    NDispWin.Material.Unit.Count[CtrlNo] += runCycles;
                }
                catch { };
            }
        }

        public string LogPath
        {
            set
            {
                uc.LogPath = value;
            }
        }

        private void UpdateDisplay()
        {
            lbl_CtrlNo.Text = (MDS3200.CtrlID + 1).ToString();

            lbl_Model.Text = MDS3200.CtrlModel.ToString();
            lbl_IDN.Text = MDS3200._DeviceInfo;
            lbl_CtrlID.Text = MDS3200._ControllerID;
            lbl_ValveID.Text = MDS3200._ValveID;
            lbl_Cycles.Text = MDS3200._Cycles.ToString();

            lbl_RI.Text = MDS3200.Param.RI.ToString("f2");
            lbl_OT.Text = MDS3200.Param.OT.ToString("f1");
            lbl_FA.Text = MDS3200.Param.FA.ToString("f2");
            lbl_NL.Text = MDS3200.Param.NL.ToString();
            lbl_NP.Text = MDS3200.Param.NP.ToString();
            lbl_DL.Text = MDS3200.Param.DL.ToString("f1");

            lblRI_CL.Text = $"{MDS3200.Param.RI_CL[0]:F2} ~ {MDS3200.Param.RI_CL[1]:F2}";
            lblOT_CL.Text = $"{MDS3200.Param.OT_CL[0]:F2} ~ {MDS3200.Param.OT_CL[1]:F2}";
            lblFA_CL.Text = $"{MDS3200.Param.FA_CL[0]:F2} ~ {MDS3200.Param.FA_CL[1]:F2}";
            lblNL_CL.Text = $"{MDS3200.Param.NL_CL[0]:F2} ~ {MDS3200.Param.NL_CL[1]:F2}";

            bool engrLevel = NUtils.UserAcc.Active.GroupID >= iEngrLevel;
            lblRI_CL.Enabled = engrLevel;
            lblOT_CL.Enabled = engrLevel;
            lblFA_CL.Enabled = engrLevel;
            lblNL_CL.Enabled = engrLevel;

            lbl_SetTemp.Text = $"{MDS3200.SetTemp:f1}";
            lblTempOfst.Text = $"{MDS3200.Heater.TempOfst:f1}";
            lblTempRange.Text = $"{MDS3200.Tolerance:f1}";

            lbl_ComPort.Text = "COM" + MDS3200._ComPortNo.ToString();

            cbEnableLog.Checked = MDS3200.bVermesLog;


            if (CtrlNo == 0)
                NDispWin.GDefine.RefreshOutput(btn_SvFPress, NDispWin.TaskGantry.BPress1);
            else
                NDispWin.GDefine.RefreshOutput(btn_SvFPress, NDispWin.TaskGantry.BPress2);

            lbl_FPress.Text = NDispWin.FPressCtrl.GetPressStr(NDispWin.DispProg.FPress[CtrlNo]);
            lbl_FPressUnit.Text = NDispWin.FPressCtrl.PressUnitStr;
        }

        enum EMenu { Param, Maint, Setup, Comm };
        private void ShowMenu(EMenu Menu)
        {
            switch (Menu)
            {
                case EMenu.Param:
                    gbox_Param.BringToFront();
                    gbox_Maint.Location = gbox_Param.Location;
                    gbox_Comm.Location = gbox_Param.Location;
                    gbox_Setup.Location = gbox_Param.Location;
                    gbox_Maint.Size = gbox_Param.Size;
                    gbox_Comm.Size = gbox_Param.Size;
                    gbox_Setup.Size = gbox_Param.Size;
                    break;
                case EMenu.Maint:
                    gbox_Maint.BringToFront();
                    break;
                case EMenu.Setup:
                    gbox_Setup.BringToFront();
                    break;
                case EMenu.Comm:
                    gbox_Comm.BringToFront();
                    break;
            }
        }

        private void btn_ValveUp_Click(object sender, EventArgs e)
        {
            int t = Environment.TickCount;
            try
            {
                MDS3200.ValveUp();
            }
            catch (Exception Ex)
            {
                lbl_BPanel.Text = Ex.Message.ToString();
                return;
            }
            lbl_BPanel.Text = (Environment.TickCount - t).ToString() + "ms";
        }
        private void btn_ValveDn_Click(object sender, EventArgs e)
        {
            int t = Environment.TickCount;
            try
            {
                MDS3200.ValveDown();
            }
            catch (Exception Ex)
            {
                lbl_BPanel.Text = Ex.Message.ToString();
                return;
            }
            lbl_BPanel.Text = (Environment.TickCount - t).ToString() + "ms";
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Trigger_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            int t = Environment.TickCount;
            try
            {
                MDS3200.ValveOpen();
            }
            catch (Exception Ex)
            {
                lbl_BPanel.Text = Ex.Message.ToString();
                return;
            }
            finally
            {
                this.Enabled = true;
            }
            lbl_BPanel.Text = (Environment.TickCount - t).ToString() + "ms";
        }

        private void SetParam()
        {
            int t = 0;
            try
            {
                t = Environment.TickCount;
                MDS3200.Set();
            }
            catch (Exception Ex)
            {
                lbl_BPanel.Text = Ex.Message.ToString();
                throw;
            }
            lbl_BPanel.Text = (Environment.TickCount - t).ToString() + "ms";
        }

        int iEngrLevel = 3;
        private void lbl_RI_Click(object sender, EventArgs e)
        {
            double d = MDS3200.Param.RI;
            double min = 0.01;
            double max = 300;
            if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
            {
                min = Math.Max(min, MDS3200.Param.RI_CL[0]);
                max = Math.Min(max, MDS3200.Param.RI_CL[1]);
            }
            uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Rising (ms)", ref d, min, max);
            MDS3200.Param.RI = d;

            this.Enabled = false;
            try
            {
                SetParam();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }

            UpdateDisplay();
        }
        private void lbl_OT_Click(object sender, EventArgs e)
        {
            double d = MDS3200.Param.OT;
            double min = 0;
            double max = 3000;
            if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
            {
                min = Math.Max(min, MDS3200.Param.OT_CL[0]);
                max = Math.Min(max, MDS3200.Param.OT_CL[1]);
            }
            uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Open Time (ms)", ref d, min, max);
            MDS3200.Param.OT = Math.Round(d, 1);

            this.Enabled = false;
            try
            {
                SetParam();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }

            UpdateDisplay();
        }
        private void lbl_FA_Click(object sender, EventArgs e)
        {
            double d = MDS3200.Param.FA;
            double min = 0.01;
            double max = 300;
            if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
            {
                min = Math.Max(min, MDS3200.Param.FA_CL[0]);
                max = Math.Min(max, MDS3200.Param.FA_CL[1]);
            }
            uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Falling (ms)", ref d, min, max);
            MDS3200.Param.FA = d;

            try
            {
                SetParam();
            }
            catch { };

            UpdateDisplay();
        }
        private void lbl_NL_Click(object sender, EventArgs e)
        {
            int i = (int)MDS3200.Param.NL;
            double min = 1;
            double max = 100;
            if (NUtils.UserAcc.Active.GroupID < iEngrLevel)
            {
                min = Math.Max(min, MDS3200.Param.NL_CL[0]);
                max = Math.Min(max, MDS3200.Param.NL_CL[1]);
            }
            uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Needle Lift (%)", ref i, 1, 100);
            MDS3200.Param.NL = (uint)i;

            try
            {
                SetParam();
            }
            catch { };

            UpdateDisplay();
        }
        private void lbl_Pulse_Click(object sender, EventArgs e)
        {
            int i = (int)MDS3200.Param.NP;
            uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Pulse", ref i, 0, 32000);
            MDS3200.Param.NP = (uint)i;

            try
            {
                SetParam();
            }
            catch { };

            UpdateDisplay();
        }
        private void lbl_Delay_Click(object sender, EventArgs e)
        {
            double d = MDS3200.Param.DL;
            uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Delay (ms)", ref d, 0.1, 1000);
            MDS3200.Param.DL = d;

            try
            {
                SetParam();
            }
            catch { };

            UpdateDisplay();
        }

        private void lbl_ComPort_Click(object sender, EventArgs e)
        {
            int i = (int)MDS3200._ComPortNo;
            uc.AdjustExec(ref i, 1, 20);
            MDS3200._ComPortNo = (uint)i;

            UpdateDisplay();
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (MDS3200.IsOpen) MDS3200.Close();

                MDS3200.Open("COM" + MDS3200._ComPortNo.ToString());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
            UpdateDisplay();
        }
        private void Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                MDS3200.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
            UpdateDisplay();
        }
        private void cbEnableLog_Click(object sender, EventArgs e)
        {
            MDS3200.bVermesLog = cbEnableLog.Checked;
        }

        private void btn_Param_Click(object sender, EventArgs e)
        {
            ShowMenu(EMenu.Param);
        }
        private void btn_Maint_Click(object sender, EventArgs e)
        {
            ShowMenu(EMenu.Maint);
        }
        private void btn_Setup_Click(object sender, EventArgs e)
        {
            ShowMenu(EMenu.Setup);
        }
        private void btn_Comm_Click(object sender, EventArgs e)
        {
            ShowMenu(EMenu.Comm);
        }

        private async void tmr_Heater_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            //switch (MDS3200.CtrlModel)
            //{
            //    case TEVermesMDS3200.ECtrlModel.MDS3200P:
            //        if (MDS3200.vh.IsOpen)
            //        {
            //            tmr_Heater.Enabled = false;

            //            double temp = 0;
            //            await Task.Run(() =>
            //            {
            //                try
            //                {
            //                    MDS3200.vh.GetValue(ref temp);
            //                }
            //                catch { };
            //            });

            //            tmr_Heater.Enabled = true;
            //            lbl_Temp.Text = $"{temp:f1}";
            //        }
            //        else
            //        {
            //            lbl_Temp.Text = $"---";
            //        }
            //        break;
            //}


            tmr_Heater.Enabled = false;

            try
            {
                if (MDS3200.Heater.On)
                {
                    double temp = 0;
                    //await Task.Run(() =>
                    //{
                    //    try
                    //    {
                    temp = MDS3200.Temp;
                    //    }
                    //    catch { };
                    //});

                    lbl_Temp.Text = $"{temp:f1}";
                }
                else
                {
                    lbl_Temp.Text = "OFF";
                }
            }
            catch
            {
                lbl_Temp.Text = $"---";
            }
            finally
            {
                tmr_Heater.Enabled = true;
            }
        }

        private void lbl_SetTemp_Click(object sender, EventArgs e)
        {
            int t = Environment.TickCount;

            try
            {
                int i = (int)MDS3200.SetTemp;
                uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Set Temp (C)", ref i, 1, 180);
                MDS3200.SetTemp = (uint)i;
            }
            catch (Exception Ex)
            {
                lbl_BPanel.Text = Ex.Message.ToString();
            }

            lbl_BPanel.Text = (Environment.TickCount - t).ToString() + "ms";

            UpdateDisplay();
        }
        private void lblTempRange_Click(object sender, EventArgs e)
        {
            int ui = (int)MDS3200.Tolerance;
            uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Temp Tolerance (C)", ref ui, 0, 10);
            MDS3200.Tolerance = (uint)ui;

            UpdateDisplay();
        }

        private void btn_HeaterOn_Click(object sender, EventArgs e)
        {
            int t = Environment.TickCount;
            try
            {
                MDS3200.HeaterOn();
            }
            catch (Exception Ex)
            {
                lbl_BPanel.Text = Ex.Message.ToString();
            }
            lbl_BPanel.Text = (Environment.TickCount - t).ToString() + "ms";
        }

        private void btn_HeaterOff_Click(object sender, EventArgs e)
        {
            int t = Environment.TickCount;
            try
            {
                MDS3200.HeaterOff();
            }
            catch (Exception Ex)
            {
                lbl_BPanel.Text = Ex.Message.ToString();
            }
            lbl_BPanel.Text = (Environment.TickCount - t).ToString() + "ms";
        }

        private void gbox_Heater_Enter(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void gbox_Maint_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Cycles_Click(object sender, EventArgs e)
        {
            try
            {
                MDS3200._Cycles = (uint)MDS3200.ValveCycles;
            }
            catch (Exception Ex)
            {
            }
            UpdateDisplay();
        }

        private void btn_Tx_Click(object sender, EventArgs e)
        {
            try
            {
                MDS3200.TX(tbox_Tx.Text);
                lbox_TxRx.Items.Insert(0, "<- " + tbox_Tx.Text);
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }

        private void btn_Rx_Click(object sender, EventArgs e)
        {
            try
            {
                string rx = "";
                MDS3200.RX_Resp(ref rx);
                //string[] ls = new string[];
                string[] Line = rx.Split((char)10);
                foreach (string s in Line)
                {
                    string ss = s.Trim();
                    if (ss.Length > 0)
                        lbox_TxRx.Items.Insert(0, "-> " + ss);
                }
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            lbox_TxRx.Items.Clear();
        }

        private void gbox_Setup_Enter(object sender, EventArgs e)
        {

        }

        private void btnTrigIO_MouseDown(object sender, MouseEventArgs e)
        {
            if (CtrlNo == 0)
                NDispWin.TaskGantry.DispATrig = true;
            else
                NDispWin.TaskGantry.DispBTrig = true;
        }

        private void btnTrigIO_MouseUp(object sender, MouseEventArgs e)
        {
            if (CtrlNo == 0)
                NDispWin.TaskGantry.DispATrig = false;
            else
                NDispWin.TaskGantry.DispBTrig = false;
        }

        private void lbl_FPress_Click(object sender, EventArgs e)
        {
            double d_Min = NDispWin.FPressCtrl.GetPressMin;
            double d_Max = NDispWin.FPressCtrl.GetPressMax;

            NDispWin.FPressCtrl.AdjustPress_MPa(CtrlNo, ref NDispWin.DispProg.FPress, d_Min, d_Max);
            UpdateDisplay();

        }

        private void btn_SvFPress_Click(object sender, EventArgs e)
        {
            if (CtrlNo == 0)
            {
                NDispWin.TaskGantry.BPress1 = !NDispWin.TaskGantry.BPress1;
            }
            else
            {
                NDispWin.TaskGantry.BPress2 = !NDispWin.TaskGantry.BPress2;
            }

            UpdateDisplay();
        }

        private void lblRI_CL_Click(object sender, EventArgs e)
        {
            NDispWin.frmCLEditor frm = new NDispWin.frmCLEditor($"CtrlID {MDS3200.CtrlID + 1} RI_CL", MDS3200.Param.RI_CL, 0.01, 300);
            frm.Location = Cursor.Position;
            frm.ShowDialog();
            MDS3200.Param.RI_CL = frm.Value.ToArray();
            UpdateDisplay();
        }
        private void lblOT_CL_Click(object sender, EventArgs e)
        {
            NDispWin.frmCLEditor frm = new NDispWin.frmCLEditor($"CtrlID {MDS3200.CtrlID + 1} OT_CL", MDS3200.Param.OT_CL, 0, 3000);
            frm.Location = Cursor.Position;
            frm.ShowDialog();
            MDS3200.Param.OT_CL = frm.Value.ToArray();
            UpdateDisplay();
        }
        private void lblFA_CL_Click(object sender, EventArgs e)
        {
            NDispWin.frmCLEditor frm = new NDispWin.frmCLEditor($"CtrlID {MDS3200.CtrlID + 1} FA_CL", MDS3200.Param.FA_CL, 0.01, 300);
            frm.Location = Cursor.Position;
            frm.ShowDialog();
            MDS3200.Param.FA_CL = frm.Value.ToArray();
            UpdateDisplay();
        }
        private void lblNL_CL_Click(object sender, EventArgs e)
        {
            NDispWin.frmCLEditor frm = new NDispWin.frmCLEditor($"CtrlID {MDS3200.CtrlID + 1} NL_CL", MDS3200.Param.NL_CL, 1, 100);
            frm.Location = Cursor.Position;
            frm.ShowDialog();
            MDS3200.Param.NL_CL[0] = (uint)frm.Value[0];
            MDS3200.Param.NL_CL[1] = (uint)frm.Value[1];
            UpdateDisplay();
        }
        private void btnTrigIO_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Temp_Click(object sender, EventArgs e)
        {

        }

        private void lblTempOfst_Click(object sender, EventArgs e)
        {
            int t = Environment.TickCount;

            try
            {
                int i = (int)MDS3200.Heater.TempOfst;
                uc.AdjustExec("CtrlID " + (MDS3200.CtrlID + 1).ToString() + " Temp Ofst (C)", ref i, -10, 10);
                MDS3200.Heater.TempOfst = i;
                    
                MDS3200.SetTemp = MDS3200.SetTemp;
            }
            catch (Exception Ex)
            {
                lbl_BPanel.Text = Ex.Message.ToString();
            }

            lbl_BPanel.Text = (Environment.TickCount - t).ToString() + "ms";

            UpdateDisplay();
        }

    }
}
