using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDispWin
{
    public partial class frmVermesMDS1560 : Form
    {
        NUtils.UserCtrl uc = new NUtils.UserCtrl();

        public TEVermesMDS1560 vm = null;

        public frmVermesMDS1560()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        int cycles = 0;
        private void frmVermesMDS1560_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = "MDS1560 CtrlID " + vm.CtrlID.ToString();
            UpdateInfo();

            TaskGantry.BPress1 = (vm.CtrlID == 0);
            TaskGantry.BPress2 = (vm.CtrlID == 1);

            if (vm.IsOpen)
            {
                try
                {
                    cycles = vm.ValveCycles;
                }
                catch { };
            }

            UpdateDisplay();
        }

        private void frmVermesMDS1560_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskGantry.BPress1 = false;
            TaskGantry.BPress2 = false;

            if (vm.IsOpen)
            {
                try
                {
                    int runCycles = vm.ValveCycles - cycles;
                    NDispWin.Material.Unit.Count[vm.CtrlID] += runCycles;
                }
                catch { };
            }
        }

        private void UpdateInfo()
        {
            rtbInfo.Clear();
            rtbInfo.Text = vm.sIDN + '\r';
            rtbInfo.AppendText(vm.sMDVInfo + '\r');
        }

        private void UpdateDisplay()
        {
            lblOT.Text = vm.OT[0].ToString();
            lblCT.Text = vm.CT[0].ToString();
            lblNP.Text = vm.NP[0].ToString();

            tbxComPort.Text = vm.sp.PortName;
            btnConnect.Enabled = !vm.IsOpen;
            cbLogComm.Checked = vm.LogComm;

            lblHeaterTarget.Text = vm.Target.ToString("f1");

            if (vm.CtrlID == 0)
                GDefine.RefreshOutput(btn_SvFPress, TaskGantry.BPress1);
            else
                GDefine.RefreshOutput(btn_SvFPress, TaskGantry.BPress2);

            lbl_FPress.Text = FPressCtrl.GetPressStr(DispProg.FPress[vm.CtrlID]);
            lbl_FPressUnit.Text = FPressCtrl.PressUnitStr;
        }

        #region Comm Page
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (vm.Open(tbxComPort.Text))
                    tsslStatus.Text = "Connected to MDS1560 at " + vm.sp.PortName;
                else
                    tsslStatus.Text = "Connect to MDS1560 at " + vm.sp.PortName + " failed.";

                UpdateInfo();
            }
            catch (Exception Ex)
            {
                tsslStatus.Text = Ex.Message.ToString();
            }
            UpdateDisplay();
        }
        private void btnDisconn_Click(object sender, EventArgs e)
        {
            try
            {
                vm.Close();
                UpdateInfo();
            }
            catch (Exception Ex)
            {
                tsslStatus.Text = Ex.Message.ToString();
            }
            tsslStatus.Text = "Disconnected MDS1560";
            UpdateDisplay();
        }
        private void cbLogComm_Click(object sender, EventArgs e)
        {
            vm.LogComm = !vm.LogComm;
            UpdateDisplay();
        }
        #endregion

        private void btnRefreshCycles_Click(object sender, EventArgs e)
        {
            int t = Environment.TickCount;
            try
            {
                lblCycles.Text = vm.ValveCycles.ToString();
            }
            catch (Exception Ex)
            {
                tsslStatus.Text = Ex.Message.ToString();
                return;
            }
            tsslStatus.Text = (Environment.TickCount - t).ToString() + "ms";
            UpdateDisplay();
        }

        private void btnValveOpen_Click(object sender, EventArgs e)
        {
        }
        private void btnValveOpen_MouseDown(object sender, MouseEventArgs e)
        {
            int t = Environment.TickCount;
            try
            {
                vm.ValveOpen();
            }
            catch (Exception Ex)
            {
                tsslStatus.Text = Ex.Message.ToString();
                return;
            }
        }
        private void btnValveOpen_MouseUp(object sender, MouseEventArgs e)
        {
            int t = Environment.TickCount;
            try
            {
                vm.ValveClose();
            }
            catch (Exception Ex)
            {
                tsslStatus.Text = Ex.Message.ToString();
                return;
            }
        }

        private void lblOT_Click(object sender, EventArgs e)
        {
            double d = vm.OT[0];
            uc.AdjustExec("CtrlID " + (vm.CtrlID + 1).ToString() + " OT (ms)", ref d, 0, 5000);//0=external, min 0.7
            if (d > 0 && d < 0.7) d = 0.7;

            vm.OT[0] = d;

            this.Enabled = false;
            try
            {
                vm.UpdateSetup();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }

            UpdateDisplay();
        }
        private void lblCT_Click(object sender, EventArgs e)
        {
            double d = vm.CT[0];
            uc.AdjustExec("CtrlID " + (vm.CtrlID + 1).ToString() + " CT (ms)", ref d, 0.7, 5000);
            vm.CT[0] = d;

            this.Enabled = false;
            try
            {
                vm.UpdateSetup();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }

            UpdateDisplay();

        }
        private void lblNP_Click(object sender, EventArgs e)
        {
            int i = vm.NP[0];
            uc.AdjustExec("CtrlID " + (vm.CtrlID + 1).ToString() + " NP (ms)", ref i, 0, 1000000);//0=infinite
            vm.NP[0] = i;

            this.Enabled = false;
            try
            {
                vm.UpdateSetup();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }

            UpdateDisplay();
        }
        private void lblHeaterTarget_Click(object sender, EventArgs e)
        {
            double d = vm.Target;
            uc.AdjustExec("HC48 " + " Heater Target", ref d, 0, 99);

            this.Enabled = false;
            try
            {
                vm.SetTarget(d);
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
            vm.Target = d;

            UpdateDisplay();
        }

        private void btn_Trigger_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            int t = Environment.TickCount;
            try
            {
                vm.Run();
            }
            catch (Exception Ex)
            {
                tsslStatus.Text = Ex.Message.ToString();
                return;
            }
            finally
            {
                this.Enabled = true;
            }
            tsslStatus.Text = (Environment.TickCount - t).ToString() + "ms";
        }
        private void btnTrigIO_MouseDown(object sender, MouseEventArgs e)
        {
            if (vm.CtrlID == 0)
                TaskGantry.DispATrig = true;
            else
                TaskGantry.DispBTrig = true;
        }
        private void btnTrigIO_MouseUp(object sender, MouseEventArgs e)
        {
            if (vm.CtrlID == 0)
                TaskGantry.DispATrig = false;
            else
                TaskGantry.DispBTrig = false;
        }
        private void btnTrigIO_Click(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_SvFPress_Click(object sender, EventArgs e)
        {
            if (vm.CtrlID == 0)
            {
                TaskGantry.BPress1 = !TaskGantry.BPress1;
            }
            else
            {
                TaskGantry.BPress2 = !TaskGantry.BPress2;
            }
            UpdateDisplay();
        }
        private void lbl_FPress_Click(object sender, EventArgs e)
        {
            double d_Min = FPressCtrl.GetPressMin;
            double d_Max = FPressCtrl.GetPressMax;

            FPressCtrl.AdjustPress_MPa(vm.CtrlID, ref DispProg.FPress, d_Min, d_Max);
            UpdateDisplay();
        }

        private async void tmrHeaterTarget_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (vm.IsOpen)
            {
                tmrHeaterTarget.Stop();

                double temp = 0;
                await Task.Run(() =>
                {
                    try
                    {
                        vm.GetValue(ref temp);
                    }
                    catch { };
                });
                lblHeaterValue.Text = temp.ToString("f1");

                tmrHeaterTarget.Start();
            }
            else
            {
                lblHeaterValue.Text = "-";
            }
        }
    }
}
