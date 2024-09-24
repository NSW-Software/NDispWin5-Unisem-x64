using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
            GControl.LogForm(this);

            List<string> LangList = AppLanguage.Func2.GetLangList();
            
            cbxLanguage.Items.Clear();
            cbxLanguage2.Items.Clear();
            for (int i = 0; i < LangList.Count(); i++)
            {
                cbxLanguage.Items.Add(LangList[i]);
                cbxLanguage2.Items.Add(LangList[i]);
            }
            cbxLanguage.SelectedIndex = GDefineN.Language1;
            cbxLanguage2.SelectedIndex = GDefineN.Language2;
            lblAltErrMsgFile.Text = Path.GetFileNameWithoutExtension(GDefineN.AltErrMsgFile);

            cbxCustomerList.DataSource = Enum.GetNames(typeof(LotInfo2.ECustomer));
                try { cbxCustomerList.SelectedIndex = (int)LotInfo2.Customer; } catch { };

            UpdateDisplay();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = "Options";
            StartPosition = FormStartPosition.CenterScreen;
            UpdateDisplay();

            if (NUtils.UserAcc.Active.GroupID < (int)ELevel.Admin)
                tpOptions.TabPages.Remove(tpAdvance);
        }

        private void UpdateDisplay()
        {
            tboxCustomPath.Text = TaskDisp.CustomPath;

            btnEditDataTable.Enabled = LotInfo2.Customer != LotInfo2.ECustomer.LUMDisp || LotInfo2.Customer != LotInfo2.ECustomer.LUMConfocal;

            cbEnableMaterialCounter.Checked = Material.EnableUnitCounter;
            lblMaterialUnitCounterALimit.Text = UI_Utils.GetKK(Material.Unit.Count[0]) + " / " + UI_Utils.GetKK(Material.Unit.Limit[0]);
            lblMaterialUnitCounterBLimit.Text = UI_Utils.GetKK(Material.Unit.Count[1]) + " / " + UI_Utils.GetKK(Material.Unit.Limit[1]);

            cbEnableMaterialLow.Checked = TaskDisp.Option_EnableMaterialLow;
            cbEnableDualMaterial.Checked = TaskDisp.Option_EnableDualMaterial;
            cbMaterialLowForbidContinue.Checked = TaskDisp.MaterialLowForbidContinue;

            cbEnableMaterialExpiry.Checked = TaskDisp.Material_EnableTimer;
            cbMaterialExpiryForbidContinue.Checked = TaskDisp.MaterialExpiryForbidContinue;
            lblMaterialLifeTimeMultipler.Text = TaskDisp.Material_Life_Multiplier.ToString();
            lblMaterialExpiryPreAlertTime.Text = TaskDisp.Material_ExpiryPreAlertTime.ToString();

            cbEnableProcessLog.Checked = DispProg.Options_EnableProcessLog;

            #region Maint Page
            lbl_DispCounter.Text = StrTools.GetKK(Maint.Disp.Count[0]) + " / " + StrTools.GetKK(Maint.Disp.CountLimit[0]);
            lbl_UnitCounterAStartDateTime.Text = "Reset Date: " + Maint.Disp.CountResetDateTime[0].ToString("g");

            lbl_FillCounterALimit.Text = StrTools.GetKK(Maint.PP.FillCount[0]) + " / " + StrTools.GetKK(Maint.PP.FillCountLimit[0]);
            lbl_FillCounterAStartDateTime.Text = "Reset Date: " + Maint.PP.StartDateTime[0].ToString("g");
            #endregion

            #region Cal Page
            lblDefZPos.Text = TaskDisp.ZDefPos.ToString("f3");
            lblDefLaserValue.Text = TaskDisp.Laser_CalValue.ToString("f3");

            lblVacuumEarlyOff.Text = $"{TaskDisp.Option_VacuumEarlyOn:f3}";
            lblLast2CLineEarlyOff.Text = $"{TaskDisp.Option_Last2CLineEarlyOff:f3}";
            lblShrinkLast2CLine.Text = $"{TaskDisp.Option_ShrinkLast2CLine:f3}";

            lblExtendLastCLine.Text = $"{TaskDisp.Option_ExtendLastCLine:f3}";
            lblCLineSpeedRatio.Text = $"{TaskDisp.Option_CLineSpeedRatio:f3}";
            #endregion

            lblCustomerPreference.Text = TaskDisp.Preference.ToString();
            cbEnableLotEntry.Checked = GDefine.EnableLotEntry;

            cbEnableStartButton.Checked = GDefineN.Enabled_BtnStart;
            cbEnableStopButton.Checked = GDefineN.Enabled_BtnStop;
            cbEnableResetButton.Checked = GDefineN.Enabled_BtnReset;

            cbEnableLowPressure.Checked = GDefineN.Enabled_LowPressure;
            cbEnableBuzzer.Checked = GDefineN.Enable_Buzzer;

            cbEnableDoorSensor.Checked = GDefineN.EnableDoorSens;
            cbEnableDoorLock.Checked = GDefineN.EnableDoorLock;
            lblDTEnable.Text = DateTime.Now < DefineSafety.dtEnable ? "Disabled Until: " + DefineSafety.dtEnable.ToString("yyyy-MM-dd HH:mm:ss"): "-";

            if (TaskDisp.Preference == TaskDisp.EPreference.Lumileds)
            {
                TaskConv.EnableDoorSens = true;
            }

            cbEnableDoorSensor.Enabled = TaskDisp.Preference != TaskDisp.EPreference.Lumileds;
            cboxEnableMapEditLock.Checked = GDefineN.EnableMapEditLock;
            cbDisableAutoRunMapEdit.Checked = GDefineN.DisableAutoRunMapEdit;
            cbAutoPageShowImage.Checked = GDefineN.AutoPageShowImage;

            lblSECSGEMProtocol.Text = TaskDisp.SECSGEMProtocol.ToString();

            lblUseRecipeFile.Text = TaskDisp.EnableRecipeFile.ToString();

            cbEnableEventDebugLog.Checked = GDefineN.EnableEventDebugLog;
        }

        private void lblAltErrMsgFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "c:\\Program Files\\NSWAutomation\\MsgBox\\NDisp3Win";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string FileName = ofd.FileName;
                lblAltErrMsgFile.Text = Path.GetFileNameWithoutExtension(FileName);
            }
            UpdateDisplay();
        }

        private void cbox_CustomerList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LotInfo2.Customer = (LotInfo2.ECustomer)cbxCustomerList.SelectedIndex;
        }
        private void btnEditDataTable_Click(object sender, EventArgs e)
        {
            //LotCtrl.frmData fData = new LotCtrl.frmData();
            //fData.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            GDefineN.Language1 = cbxLanguage.SelectedIndex;
            GDefineN.Language2 = cbxLanguage2.SelectedIndex;

            GDefine.EnableLotEntry = cbEnableLotEntry.Checked;
            GDefineN.Enabled_BtnStart = cbEnableStartButton.Checked;

            GDefineN.Enabled_BtnStop = cbEnableStopButton.Checked;
            GDefineN.Enabled_BtnReset = cbEnableResetButton.Checked;

            GDefineN.Enabled_LowPressure = cbEnableLowPressure.Checked;
            GDefineN.Enable_Buzzer = cbEnableBuzzer.Checked;

            GDefineN.EnableDoorSens = cbEnableDoorSensor.Checked;
            GDefineN.EnableDoorLock = cbEnableDoorLock.Checked;

            GDefineN.EnableMapEditLock = cboxEnableMapEditLock.Checked;
            GDefineN.AutoPageShowImage = cbAutoPageShowImage.Checked;

            GDefineN.DisableAutoRunMapEdit = cbDisableAutoRunMapEdit.Checked;

            bool.TryParse(lblUseRecipeFile.Text, out TaskDisp.EnableRecipeFile);

            Close();
        }

        private void btnAccessConfig_Click(object sender, EventArgs e)
        {
            NUtils.UserAcc.Users.ConfigDlg();
        }

        private void lblCustomerPreference_Click(object sender, EventArgs e)
        {
            int i = (int)TaskDisp.Preference;
            if (!UC.AdjustExec("Options, Customer Name", ref i, TaskDisp.EPreference.None)) return;
            lblCustomerPreference.Text = ((TaskDisp.EPreference)i).ToString();
            Enum.TryParse(lblCustomerPreference.Text, out TaskDisp.Preference);

            UpdateDisplay();
        }

        private void lblEnableRecipeFile_Click(object sender, EventArgs e)
        {
            bool b = (bool)TaskDisp.EnableRecipeFile;
            if (!UC.AdjustExec("Options, Enable Recipe File", ref b)) return;
            TaskDisp.EnableRecipeFile = b;
            lblUseRecipeFile.Text = b.ToString();

            UpdateDisplay();
        }

        private void btnSECSGEMConnect2_Click(object sender, EventArgs e)
        {
            if (TaskDisp.SECSGEMProtocol == TaskDisp.ESECSGEMProtocol.SECSGEMConnect2)
            {
                frmSECSGEMConnect2 frm = new frmSECSGEMConnect2();
                frm.sgc2 = GDefine.sgc2;
                frm.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TaskDisp.SaveSetup();
        }

        private async void btnCalDefZPos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Calibrate Default Z Position?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (MessageBox.Show("Please move camera at Calibrate Height Position. Press OK to Continue.", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            frm_ProgressReport frmPR = new frm_ProgressReport();
            try
            {
                this.Enabled = false;

                frmPR = new frm_ProgressReport();
                frmPR.Message = "Def Z Calibration in Progress. Please wait...";
                frmPR.Show();

                double z = 5;
                await Task.Run(() =>
                {
                    if (!TaskDisp.TaskAutoFocus()) return;

                    z = TaskGantry.GZPos();
                });
                frmPR.Close();//Done = true;

                if (MessageBox.Show("Update DefZPos from " + TaskDisp.ZDefPos.ToString("f3") + " to " + z.ToString("f3"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    TaskDisp.ZDefPos = z;
                    Event.CAL_DEFZPOS_UPDATE.Set("Default Z Position", z.ToString("f3"));
                }
                else
                {
                    Event.CAL_DEFZPOS_CANCEL.Set();
                }
            }
            catch
            { }
            finally
            {
                frmPR.Close();//.Done = true;
                this.Enabled = true;
                UpdateDisplay();
            }
        }
        private void btn_GotoDefZPos_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveAbsGZZ2(TaskDisp.ZDefPos, TaskDisp.ZDefPos)) return;
        }
        private void lbl_ZDefPos_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Options, Z Default Position", ref TaskDisp.ZDefPos, 0.1, 5);
            if (!TaskDisp.TaskMoveAbsGZZ2(TaskDisp.ZDefPos, TaskDisp.ZDefPos)) return;
            UpdateDisplay();
        }

        private void btnCalDefLaserValue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Calibrate Laser Default Value?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (MessageBox.Show("Please move laser to Calibrate Height position. Press OK to Continue.", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            if (!TaskLaser.LaserOpened) return;

            double d = 0;
            if (TaskLaser.GetHeight(ref d, false))
            {
                //double dNew = d - TaskDisp.Laser_RefPosZ;

                if (MessageBox.Show("Update Laser Default Value from " + TaskDisp.Laser_CalValue.ToString("f3") + " to " + d.ToString("f3"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    TaskDisp.Laser_CalValue = d;
                    Event.CAL_LASER_CAL_VALUE_UPDATE.Set("Laser Cal Value", d.ToString("f3"));
                }
                else
                {
                    Event.CAL_LASER_CAL_VALUE_CANCEL.Set();
                }
            }

            UpdateDisplay();
        }
        private void lblDefLaserValue_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Options, Laser Cal Value", ref TaskDisp.Laser_CalValue, -15, 15);
            UpdateDisplay();
        }

        frmJogGantry frm_Jog2 = new frmJogGantry();
        private void btnJog_Click(object sender, EventArgs e)
        {
            frm_Jog2.TopMost = true;
            frm_Jog2.Show();
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Jog2.Close();
            frm_Jog2.Dispose();
        }

        private void lblSECSGEMProtocol_Click(object sender, EventArgs e)
        {
            int i = (int)TaskDisp.SECSGEMProtocol;
            if (!UC.AdjustExec("Options, SECSGEM Protocol", ref i, TaskDisp.ESECSGEMProtocol.None)) return;
            Enum.TryParse(((TaskDisp.ESECSGEMProtocol)i).ToString(), out TaskDisp.SECSGEMProtocol);

            lblSECSGEMProtocol.Text = ((TaskDisp.ESECSGEMProtocol)i).ToString();

            UpdateDisplay();
        }

        private void cbEnableMaterialLow_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Material Low", ref TaskDisp.Option_EnableMaterialLow);
            UpdateDisplay();
        }
        private void cbEnableDualMaterial_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, Enable Dual Material", ref TaskDisp.Option_EnableDualMaterial);
            UpdateDisplay();
        }

        private void cbEnableMaterialTimer_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, EnableMaterialExpiry", ref TaskDisp.Material_EnableTimer);
            UpdateDisplay();
        }
        private void lblMaterialLifeTimeMultipler_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, MaterialLifeMultiplier", ref TaskDisp.Material_Life_Multiplier, 1, 3600);
            UpdateDisplay();
        }
        private void cbMaterialLowForbidContinue_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, MaterialExpiryForbidContinue", ref TaskDisp.MaterialExpiryForbidContinue);
            UpdateDisplay();
        }

        private void cbForbidMaterialExpriyContinue_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Option, MateriaLowForbidContinue", ref TaskDisp.MaterialLowForbidContinue);
            UpdateDisplay();
        }


        private void cbEnableMaterialCounter_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Material, EnableUnitCounter", ref Material.EnableUnitCounter);
            UpdateDisplay();
        }

        private void lblMaterialUnitCounterALimit_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Material Unit Counter A Limit", ref Material.Unit.Limit[0], 0, 1000000000);
            UpdateDisplay();
        }
        private void lblMaterialUnitCounterAReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset Material Unit Counter A", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Log.OnSet("Reset Material Unit Counter A", Material.Unit.Count[0], 0);
                Material.Unit.Count[0] = 0;
                GDefine.SaveDefault();
            }
            UpdateDisplay();
        }
        private void lblMaterialUnitCounterBLimit_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Material Unit Counter B Limit", ref Material.Unit.Limit[1], 0, 1000000000);
            UpdateDisplay();
        }
        private void lblMaterialUnitCounterBReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset Material Unit Counter B", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Log.OnSet("Reset Material Unit Counter B", Material.Unit.Count[1], 0);
                Material.Unit.Count[1] = 0;
                GDefine.SaveDefault();
            }
            UpdateDisplay();
        }

        private async void btnConvertProgramToRecipe_ClickAsync(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Convert all Programs to Recipe?. Exisging recipes will be overwritten.", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;

            this.Enable(false);
            frm_ProgressReport frm = new frm_ProgressReport();
            frm.Message = "Conversion in Progress. Please wait...";
            frm.Show();

            int i = 0;
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    string[] progFiles = Directory.GetFiles(GDefine.ProgPath, "*.prg");

                    foreach (string s in progFiles)
                    {
                        string progName = Path.GetFileNameWithoutExtension(s);

                        string sourceFileName = GDefine.ProgPath + "\\" + progName + "." + GDefine.ProgExt;
                        if (!DispProg.Load(sourceFileName, true))
                        {
                            Log.AddToLog("Convert " + progName + ".prg to recipe failed.");
                        }

                        string destFileName = GDefine.RecipeDir.FullName + progName + GDefine.RecipeExt;
                        DispProg.Save(destFileName);

                        Log.AddToLog("Convert " + progName + ".prg to recipe success.");
                        i++;
                    }
                });
            }
            catch
            {

            }
            finally
            {
                frm.Close();
                this.Enable(true);
            }
            MessageBox.Show("Converted " + i.ToString() + " Programs to Recipes.");
        }

        private void tboxCustomPath_Leave(object sender, EventArgs e)
        {
            TaskDisp.CustomPath = tboxCustomPath.Text;
        }

        private void btnSelectCustomPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = TaskDisp.CustomPath;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
                TaskDisp.CustomPath = fbd.SelectedPath;

            UpdateDisplay();
        }

        private void btnSafetyEnable_Click(object sender, EventArgs e)
        {
            if (NUtils.UserAcc.Active.GroupID < (int)ELevel.Engineer)
            {
                int i_UserIdx = NUtils.UserAcc.Active.UserIndex;
                NUtils.UserAcc.Users.LoginDlg();
                if (NUtils.UserAcc.Active.GroupID < (int)ELevel.Engineer)
                {
                    return;
                }
            }

            int m = 0;
            UC.AdjustExec("Safety Bypass (minutes)", ref m, 0, 60);
            DefineSafety.dtEnable = DateTime.Now.AddMinutes(m);

            UpdateDisplay();
        }

        private void lblMaterialExpiryPreAlertTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Material, ExpiryPreAlertTime", ref TaskDisp.Material_ExpiryPreAlertTime, 0, 720);
            UpdateDisplay();
        }

        private void cbEnableEventDebugLog_Click(object sender, EventArgs e)
        {
            GDefineN.EnableEventDebugLog = !GDefineN.EnableEventDebugLog;
            UpdateDisplay();
        }

        private void lbl_UnitCounterA_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Maint Disp Counter", ref Maint.Disp.CountLimit[0], 0, 100000000);
            UpdateDisplay();
        }
        private void lbl_FillCounterALimit_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Maint Disp Counter Limit", ref Maint.PP.FillCountLimit[0], 0, 100000000);
            UpdateDisplay();
        }
        private void btn_UnitCounterAReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset Disp Counter", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Log.OnSet("Reset Unit Counter", Maint.Disp.Count[0], 0);
                Maint.Disp.Count[0] = 0;
                Maint.Disp.CountResetDateTime[0] = DateTime.Now;
                GDefine.SaveDefault();
            }
            UpdateDisplay();
        }
        private void btn_FillCounterAReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset Fill Counter", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Log.OnSet("Reset Fill Counter", Maint.PP.FillCount[0], 0);
                Maint.PP.FillCount[0] = 0;
                Maint.PP.StartDateTime[0] = DateTime.Now;
                GDefine.SaveDefault();
            }
            UpdateDisplay();
        }

        private void lblVacuumEarlyOff_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Option VacuumEarlyOff", ref TaskDisp.Option_VacuumEarlyOn, 0, 0.1))
            {
                TaskDisp.Option_Last2CLineEarlyOff = 0;
                TaskDisp.Option_ShrinkLast2CLine = 0;
            }
            UpdateDisplay();
        }
        private void lblLast2CLineEarlyOff_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Option DecreaseEndOutput", ref TaskDisp.Option_Last2CLineEarlyOff, 0, 0.1))
            {
                TaskDisp.Option_VacuumEarlyOn = 0;
                TaskDisp.Option_ShrinkLast2CLine = 0;
            }
            UpdateDisplay();
        }
        private void lblShrinkLast2CLine_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Option ShrinkLast2CLine", ref TaskDisp.Option_ShrinkLast2CLine, 0, 0.4))
            {
                TaskDisp.Option_VacuumEarlyOn = 0;
                TaskDisp.Option_Last2CLineEarlyOff = 0;
            }
            UpdateDisplay();
        }

        private void lblExtendLastCLine_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Option ExtendLastCLine", ref TaskDisp.Option_ExtendLastCLine, 0, 10))
                UpdateDisplay();
        }
        private void lblCLineSpeedRatio_Click(object sender, EventArgs e)
        {
            if (UC.AdjustExec("Option CLineSpeedRatio", ref TaskDisp.Option_CLineSpeedRatio, 0.7, 1.3))
                UpdateDisplay();
        }

        private void btnEditErrorMap_Click(object sender, EventArgs e)
        {
            if (!File.Exists(DispProg.ErrorMapFile))
                MessageBox.Show("Error Map do not exist.");
            else
            System.Diagnostics.Process.Start(DispProg.ErrorMapFile);
        }
        private void btnClearErrorMap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear Error Map?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            DispProg.ErrorMap.Clear();
        }
        private void btnCreateErrorMap_Click(object sender, EventArgs e)
        {
            if (File.Exists(DispProg.ErrorMapFile))
            {
                DialogResult dr = MessageBox.Show("Error Map exist. Create will be delete existing file. Continue to create?", "", MessageBoxButtons.OKCancel);
                if (dr != DialogResult.OK) return;
            }

            DispProg.ErrorMap.Clear();
            DispProg.ErrorMap.Save(DispProg.ErrorMapFile);

            MessageBox.Show("New Error Map Created.");
        }

        private void cbEnableProcessLog_Click(object sender, EventArgs e)
        {
            DispProg.Options_EnableProcessLog = !DispProg.Options_EnableProcessLog;
            Log.OnSet("EnableProcessLog", !DispProg.Options_EnableProcessLog, DispProg.Options_EnableProcessLog);
            UpdateDisplay();
        }

        private void cbDisbleAutoRunMapEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
