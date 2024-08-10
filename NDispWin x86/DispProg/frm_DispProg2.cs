using 
    System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static NDispWin.Intf;

namespace NDispWin
{
    internal partial class frm_DispProg2 : Form
    {
        frmJogGantry frm_Jog = null;
        frm_DispCore_DispProg_Setting frm_Setting = new frm_DispCore_DispProg_Setting();
        frm_DispCore_Map frmMap = new frm_DispCore_Map();

        TPos2 SubOfst = new TPos2(0, 0);
        int SelProg = 0;
        bool b_ProgEdit = false;

        public frm_DispProg2()
        {
            InitializeComponent();
            GControl.LogForm(this);

            DispProgUI.Load();

            lv_Program.Columns.Add("No");
            lv_Program.Columns.Add("Cmd");
            lv_Program.Columns.Add("ID_Para");
            lv_Program.Columns[0].Width = 40;
            lv_Program.Columns[1].Width = 110;
            lv_Program.Columns[2].Width = 448;

            RefreshFunction();

            this.WindowState = FormWindowState.Maximized;
        }

        private void UpdateDisplay()
        {
            this.Text = Application.ProductName + " v" + Application.ProductVersion + " - Program - " + GDefine.ProgRecipeName;

            rtbAdmin.Visible = NUtils.UserAcc.Active.GroupID >= (int)ELevel.Admin;
            rtbAdmin.Text = $"Weighted/Normal X,Y,Z: {DispProg.ErrorMap.OfstX:f3},{DispProg.ErrorMap.OfstY:f3},{DispProg.ErrorMap.OfstZ:f3} " +
                          $"/ {DispProg.ErrorMap.OfstX_:f3},{DispProg.ErrorMap.OfstY_:f3},{DispProg.ErrorMap.OfstZ_:f3}";

            tslbl_ProgName.Text = GDefine.ProgRecipeName;
            tslbl_ProgName.ToolTipText = "Program: " +  GDefine.ProgRecipeName;

            switch (DispProg.rt_StationNo)
            {
                case ERunStationNo.Station1: tsdd_Station.Text = tsmi_Station1.Text; break;
                case ERunStationNo.Station2: tsdd_Station.Text = tsmi_Station2.Text; break;
                case ERunStationNo.Station3: tsdd_Station.Text = tsmi_Station3.Text; break;
                case ERunStationNo.Station4: tsdd_Station.Text = tsmi_Station4.Text; break;
                case ERunStationNo.Station5: tsdd_Station.Text = tsmi_Station5.Text; break;
                case ERunStationNo.Station6: tsdd_Station.Text = tsmi_Station6.Text; break;
                case ERunStationNo.Station7: tsdd_Station.Text = tsmi_Station7.Text; break;
                case ERunStationNo.Station8: tsdd_Station.Text = tsmi_Station8.Text; break;
            }

            tsslbl_PumpType.Text = "Pump Type: " + DispProg.Pump_Type.ToString();
            tsslbl_HeadOp.Text = "Head Op: " + DispProg.Head_Operation.ToString();

            tsslbl_RecipeType.Text = TaskDisp.EnableRecipeFile ? "[xml]" : "[prg]";

            switch (GDefine.Status)
            {
                case EStatus.Busy: tslbl_Status.ForeColor = Color.MediumPurple; break;
                case EStatus.Disable: tslbl_Status.ForeColor = SystemColors.Control; break;
                case EStatus.ErrorInit: tslbl_Status.ForeColor = Color.Red; break;
                case EStatus.Ready: tslbl_Status.ForeColor = Color.Green; break;
                case EStatus.Stop: tslbl_Status.ForeColor = Color.Orange; break;
                case EStatus.Unknown: tslbl_Status.ForeColor = Color.Olive; break;
                case EStatus.EndStop: tslbl_Status.ForeColor = Color.Orange; break;
                case EStatus.IdlePurge: tslbl_Status.ForeColor = Color.Green; break;
            }
            tslbl_Status.Text = GDefine.Status.ToString();

            tsbtn_Lock.Checked = b_ProgEdit;

            lv_Program.Enabled = b_ProgEdit;

            Application.OpenForms[0].Invoke(new Action(() =>
            {
                lv_Program.ForeColor = b_ProgEdit ? Color.Black : Color.DarkGray;
            }));

            tsbtn_ProgLineAdd.Enabled = b_ProgEdit;
            tsbtn_ProgLineInsert.Enabled = b_ProgEdit;
            tsbtn_ProgLineDel.Enabled = b_ProgEdit;
            tsbtn_ProgLineMoveUp.Enabled = b_ProgEdit;
            tsbtn_ProgLineMoveDn.Enabled = b_ProgEdit;
            tsbtn_OffsetAll.Enabled = b_ProgEdit;

            #region RunMode display
            tsbtn_Snail.Enabled = (DispProg.RunMode == ERunMode.Dry || DispProg.RunMode == ERunMode.Camera);

            //tsbtn_Cancel.Enabled = (DispProg.LastLine > 0);
            if (DispProg.LastLine < 0) tsbtn_Cancel.Enabled = false;

            tsddbtn_ForceSingle.Visible = TaskDisp.Option_EnableRunSingleHead && GDefine.HeadConfig == GDefine.EHeadConfig.Dual;
            if (!TaskDisp.ForceSingle) tsddbtn_ForceSingle.Image = tsmi_Dual.Image; else tsddbtn_ForceSingle.Image = tsmi_ForceSingle.Image;

            try
            {
                if (TaskGantry.DispATrigSet(TaskGantry.TOutputState.St))
                    tsslbl_DispATrig.BackColor = Color.Red;
                else
                    tsslbl_DispATrig.BackColor = SystemColors.Control;
                if (TaskGantry.DispBTrigSet(TaskGantry.TOutputState.St))
                    tsslbl_DispBTrig.BackColor = Color.Red;
                else
                    tsslbl_DispBTrig.BackColor = SystemColors.Control;
            }
            catch { };
            #endregion

            if (Dirty && Done)
            {
                Dirty = false;
                DispProg.Script[0].Validate(0);
                RefreshProgramList();
                try
                {
                    lv_Program.Items[ProgLine].Selected = true;
                }
                catch { }
                DispProg.rt_LayoutChanged = true;
            }

            if (DispProg.RefreshProg)
            {
                DispProg.RefreshProg = false;
                RefreshProgramList();
            }
        }
        public void RefreshProgramList()
        {
            if (SelProg < 0) return;

            #region Update lv_Prgram
            ListViewItem lvi = new ListViewItem();
            string No = "";
            string Cmd = "";
            string ID = "";
            string Para = "";
            string Indent = "";

            DispProg.TCmdList CmdLine = DispProg.Script[SelProg].CmdList;
            lv_Program.Items.Clear();
            for (int i = 0; i < CmdLine.Count; i++)
            {
                DispProg.TLine CLine = new DispProg.TLine(CmdLine.Line[i]);

                No = i.ToString("000") + (char)9;
                Cmd = "";
                ID = "";
                Para = "";

                switch (CmdLine.Line[i].Cmd)
                {
                    #region
                    case DispProg.ECmd.LAYOUT:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CLine.Cmd);

                        Para = "[" + CLine.ID.ToString() + "] ";
                        if (CLine.IPara[3] == 0) Para = Para + "Unit M CR(" + CLine.Index[2].ToString() + "," + CLine.Index[4].ToString() + ") ";
                        if (CLine.IPara[3] == 1) Para = Para + "Unit Rand(" + CLine.Index[0].ToString() + ") ";

                        if (CLine.IPara[6] == 0) Para = Para + "Clstr CR(M" + CLine.Index[6].ToString() + ",";
                        if (CLine.IPara[6] == 1) Para = Para + "Clstr CR(MP" + CLine.Index[6].ToString() + ",";

                        if (CLine.IPara[7] == 0) Para = Para + "M" + CLine.Index[8].ToString() + ") ";
                        if (CLine.IPara[7] == 1) Para = Para + "MP" + CLine.Index[8].ToString() + ") ";

                        //if (CLine.IPara[2] == 0) Para = Para + "SINGLE ";
                        //if (CLine.IPara[2] == 1) Para = Para + "SYNC ";

                        Para = Para + Enum.GetName(typeof(TLayout.ELoopDir), CLine.IPara[1]);
                        break;
                    #endregion
                    case DispProg.ECmd.FOR_LAYOUT:
                        #region
                        {
                            Cmd = Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "[" + CmdLine.Line[i].ID.ToString() + "]";

                            Indent = Indent + "  ";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.END_LAYOUT:
                        #region
                        {
                            try { Indent = Indent.Remove(0, 2); }
                            catch { };
                            Cmd = Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "[" + CmdLine.Line[i].ID.ToString() + "]";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.REPEAT:
                        #region
                        Cmd = Indent + CLine.Cmd.ToString();

                        Para = "C,R (" + CLine.Index[2].ToString() + "," + CLine.Index[4].ToString() + ") ";

                        TLayout.ELoopDir repeatLoopDir = TLayout.ELoopDir.XFZ;
                        try { repeatLoopDir = (TLayout.ELoopDir)CLine.IPara[1]; } catch { }
                        string s = repeatLoopDir.ToString() + " "; 
                        Para = Para + s + "C,R Pitch ((" + 
                            CLine.DPara[2].ToString("f3") + "," + CLine.DPara[3].ToString("f3") + "),(" + 
                            CLine.DPara[4].ToString("f3") + "," + CLine.DPara[5].ToString("f3") + ")) ";
                        break;
                    #endregion
                    case DispProg.ECmd.SUB:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd) + CmdLine.Line[i].ID.ToString();
                            Para = "(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ")";
                            Para = Para + " " + CmdLine.Line[i].String;
                            if (CmdLine.Line[i].DPara[0] > 0)
                            {
                                Para = Para + " " + CmdLine.Line[i].DPara[0].ToString("F1") + " mg";
                            }
                            break;
                        }
                    #endregion
                    //case DispProg.ECmd.COND_ON:
                    //    #region
                    //    {
                    //        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                    //        ID = "[" + CmdLine.Line[i].ID.ToString() + "]";
                    //        Para = ID + " ";
                    //        if (CmdLine.Line[i].Index[0] == 1)
                    //            Para = Para + "Event = PP Fill";
                    //        else
                    //            if (CmdLine.Line[i].IPara[0] > 0)
                    //            Para = Para + "Counter >= " + CmdLine.Line[i].IPara[0].ToString();

                    //        Indent = Indent + "  ";
                    //        break;
                    //    }
                    //#endregion
                    //case DispProg.ECmd.COND_OFF:
                    //    #region
                    //    {
                    //        try { Indent = Indent.Remove(0, 2); }
                    //        catch { };
                    //        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                    //        break;
                    //    }
                    //#endregion
                    case DispProg.ECmd.SET_GPOUT:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            ID = "[" + CmdLine.Line[i].ID.ToString() + "]";

                            string Name = "";
                            switch (CmdLine.Line[i].ID)
                            {
                                case 1: Name = TaskGantry._GPOut1.Label; break;
                                case 2: Name = TaskGantry._GPOut2.Label; break;
                                case 3: Name = TaskGantry._GPOut3.Label; break;
                                case 4: Name = TaskGantry._GPOut4.Label; break;
                                case 5: Name = TaskGantry._GPOut5.Label; break;
                                case 6: Name = TaskGantry._GPOut6.Label; break;
                            }

                            Para = ID + " " + Name + " " + (CmdLine.Line[i].IPara[0] == 0 ? "OFF" : "ON");
                            break;
                        }
                    #endregion
                    //case DispProg.ECmd.COUNTER:
                    //    #region
                    //    {
                    //        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                    //        ID = "[" + CmdLine.Line[i].ID.ToString() + "]";
                    //        if (CmdLine.Line[i].IPara[0] == 0)
                    //            Para = ID + " " + "RESET";
                    //        else
                    //            Para = ID + " " + CmdLine.Line[i].IPara[0].ToString();

                    //        Para = Para + " (" + DispProg.Counter.Count[CmdLine.Line[i].ID].ToString() + ")";

                    //        break;
                    //    }
                    //#endregion
                    //case DispProg.ECmd.CNTR_ACTION:
                    //    #region
                    //    {
                    //        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                    //        //ID = "[" + CmdLine.Line[i].ID.ToString() + "]";
                    //        Para = "";
                    //        Para = Para + Enum.GetName(typeof(ECntrType), CmdLine.Line[i].IPara[0]).ToString() + " ";
                    //        Para = Para + CmdLine.Line[i].IPara[1].ToString() + " ";
                    //        Para = Para + Enum.GetName(typeof(ECntrActionType), CmdLine.Line[i].IPara[2]).ToString() + " ";
                    //        break;
                    //    }
                    //#endregion
                    case DispProg.ECmd.DELAY:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = CmdLine.Line[i].IPara[0] + "ms";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.WEIGHT_CAL:
                        #region
                        {
                            if (CmdLine.Line[i].Cond[0] == 13) Cmd = "[X] ";
                            Cmd = Indent + Cmd + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            if (CmdLine.Line[i].Cond[0] > 0)
                                Para = $"Cond1,{CmdLine.Line[i].Cond[0]},{CmdLine.Line[i].Cond[1]} ";
                            if (CmdLine.Line[i].Cond[5] > 0)
                                Para = Para + $"Cond2,{CmdLine.Line[i].Cond[5]},{CmdLine.Line[i].Cond[6]} ";

                            Para = Para + " " + CmdLine.Line[i].DPara[0].ToString();
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.SEPERATOR:
                        #region
                        {
                            Cmd = Indent + "-----------------";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.COMMENT:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = CmdLine.Line[i].String;

                            if (CmdLine.Line[i].IPara[0] > 0) Para = Para + " (Add to event log.) ";

                            break;
                        }
                    #endregion
                    case DispProg.ECmd.DO_REF:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "[" + CmdLine.Line[i].ID.ToString() + "] ";

                            Para = Para + Enum.GetName(typeof(EAlignType), CmdLine.Line[i].IPara[2]) + " ";

                            if (CmdLine.Line[i].IPara[7] > 0) Para = Para + "A ";

                            Para = Para + "P1(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ") ";
                            if (CmdLine.Line[i].IPara[0] == 2)
                            {
                                Para = Para + "P2(" + CmdLine.Line[i].X[1].ToString("F3") + "," + CmdLine.Line[i].Y[1].ToString("F3") + ")";
                            }
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.DO_REF_CHECK:
                    case DispProg.ECmd.DO_VISION_CHECK:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "[" + CmdLine.Line[i].ID.ToString() + "] ";

                            Para = Para + $"MinScore {CmdLine.Line[i].DPara[0]:f3}, XYTol {CmdLine.Line[i].DPara[1]:f3} ";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.DO_REF_EDGE:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "[" + CmdLine.Line[i].ID.ToString() + "] ";

                            Para = Para + Enum.GetName(typeof(EAlignType), CmdLine.Line[i].IPara[2]) + " ";

                            Para = Para + "P1(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ") ";
                            if (CmdLine.Line[i].IPara[0] == 2)
                            {
                                Para = Para + "P2(" + CmdLine.Line[i].X[1].ToString("F3") + "," + CmdLine.Line[i].Y[1].ToString("F3") + ")";
                            }
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.USE_REF:
                    case DispProg.ECmd.USE_VISION:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            ID = "[" + CmdLine.Line[i].ID.ToString() + "]";
                            Para = ID;
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.DO_VISION:
                    case DispProg.ECmd.DO_VIS_INSP:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "[" + CmdLine.Line[i].ID.ToString() + "] ";

                            Para = Para + Enum.GetName(typeof(EAlignType), CmdLine.Line[i].IPara[2]) + " ";

                            if (CmdLine.Line[i].Cond[0] > 0)
                                Para = $"Cond1,{CmdLine.Line[i].Cond[0]},{CmdLine.Line[i].Cond[1]} ";
                            if (CmdLine.Line[i].Cond[5] > 0)
                                Para = Para + $"Cond2,{CmdLine.Line[i].Cond[5]},{CmdLine.Line[i].Cond[6]} ";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.SINGULATED_ID:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.READ_ID:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "[" + CmdLine.Line[i].ID.ToString() + "] ";
                            Para = Para + (CmdLine.Line[i].IPara[0] > 0 ? "" : "[Disabled] ");
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.DO_HEIGHT:
                        #region
                        //Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        //Para = "[" + CmdLine.Line[i].ID.ToString() + "] ";

                        //Para = Para + Enum.GetName(typeof(EAlignType), CmdLine.Line[i].IPara[2]) + " ";

                        //if (CmdLine.Line[i].IPara[0] != 3) CmdLine.Line[i].IPara[0] = 1;

                        //if (CmdLine.Line[i].IPara[7] > 0) Para = Para + "A ";

                        //if (CmdLine.Line[i].IPara[0] == 1)
                        //{
                        //    Para = Para + "2D " + CmdLine.Line[i].IPara[1].ToString() + " Point(s) ";
                        //}
                        //if (CmdLine.Line[i].IPara[0] == 3)
                        //{
                        //    Para = Para + "3D " + "(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ")" + " (" + CmdLine.Line[i].X[1].ToString("F3") + "," + CmdLine.Line[i].Y[1].ToString("F3") + ")" + " (" + CmdLine.Line[i].X[2].ToString("F3") + "," + CmdLine.Line[i].Y[2].ToString("F3") + ")";
                        //}
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        Para = "[" + CmdLine.Line[i].ID.ToString() + "] ";

                        Para = Para + Enum.GetName(typeof(EAlignType), CmdLine.Line[i].IPara[2]) + " ";

                        //if (CmdLine.Line[i].IPara[0] != 3) CmdLine.Line[i].IPara[0] = 1;
                        if (!(CmdLine.Line[i].IPara[0] == 3 || CmdLine.Line[i].IPara[0] == 4)) CmdLine.Line[i].IPara[0] = 1;

                        if (CmdLine.Line[i].IPara[7] > 0) Para = Para + "A ";

                        if (CmdLine.Line[i].IPara[0] == 1)
                        {
                            Para = Para + "2D " + CmdLine.Line[i].IPara[1].ToString() + " Point(s) ";
                        }
                        if (CmdLine.Line[i].IPara[0] == 3)
                        {
                            Para = Para + "3D " + "(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ")" + " (" + CmdLine.Line[i].X[1].ToString("F3") + "," + CmdLine.Line[i].Y[1].ToString("F3") + ")" + " (" + CmdLine.Line[i].X[2].ToString("F3") + "," + CmdLine.Line[i].Y[2].ToString("F3") + ")";
                        }
                        if (CmdLine.Line[i].IPara[0] == 4)
                        {
                            Para = Para + "Least Square Fit " + CmdLine.Line[i].IPara[1].ToString() + " Point(s) ";
                        }
                        break;
                    #endregion
                    case DispProg.ECmd.MEAS_TEMP:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        Para = $"[{CmdLine.Line[i].ID}] ";
                        Para = Para + $"Points {CmdLine.Line[i].IPara[1]} ";
                        break;
                    #endregion
                    case DispProg.ECmd.USE_HEIGHT:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        ID = "[" + CmdLine.Line[i].ID.ToString() + "]";
                        Para = ID;
                        break;
                    #endregion
                    case DispProg.ECmd.DOT:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";
                        ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                        Para = ID + " M" + CmdLine.Line[i].IPara[0].ToString() + " ";
                        Para = Para + " D(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ") ";

                        if (CmdLine.Line[i].IPara[1] == 1)
                        {
                            Para = Para + " Ext Timed ";
                        }
                        else
                            if (CmdLine.Line[i].DPara[0] > 0)
                        {
                            Para = Para + " " + CmdLine.Line[i].DPara[0].ToString("F1") + " mg ";
                        }
                        if (CmdLine.Line[i].IPara[3] > 0)
                            Para = Para + "PreMoveZ ";

                        break;
                    #endregion
                    case DispProg.ECmd.DOT_MULTI:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";

                        ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                        Para = ID + " M" + CmdLine.Line[i].IPara[0].ToString() + " ";
                        //Para = Para + " Pos/Dot " + CmdLine.Line[i].IPara[5].ToString() + "/" + CmdLine.Line[i].IPara[6].ToString();
                        Para = Para + " Count " + CmdLine.Line[i].IPara[5].ToString();
                        break;
                    #endregion
                    case DispProg.ECmd.DOTLINE_MULTI:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";

                        ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                        Para = ID + " M" + CmdLine.Line[i].IPara[0].ToString() + " ";
                        Para = Para + " Lines " + CmdLine.Line[i].IPara[5].ToString() + ", Dots " + CmdLine.Line[i].IPara[6].ToString();
                        break;
                    #endregion
                    case DispProg.ECmd.DOT_P:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";
                        ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                        Para = ID + " M" + CmdLine.Line[i].IPara[0].ToString() + " ";
                        Para = Para + " D(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ") ";

                        if (CmdLine.Line[i].IPara[1] == 1)
                        {
                            Para = Para + " Ext Timed ";
                        }
                        else
                            if (CmdLine.Line[i].DPara[0] > 0)
                        {
                            Para = Para + " " + CmdLine.Line[i].DPara[0].ToString("F1") + " mg ";
                        }
                        break;
                    #endregion
                    //case DispProg.ECmd.FILL_PAT:
                    //    #region
                    //    Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                    //    if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";

                    //    ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                    //    Para = ID + " M" + CmdLine.Line[i].IPara[0].ToString() + " ";
                    //    Para = Para + Enum.GetName(typeof(DispProg.EFillPatType), CmdLine.Line[i].IPara[1]) + " ";
                    //    Para = Para + "Section " + CmdLine.Line[i].IPara[4].ToString() + ", " + CmdLine.Line[i].DPara[4].ToString();
                    //    break;
                    //#endregion
                    //case DispProg.ECmd.SPIRAL_FILL:
                    //    #region
                    //    Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                    //    if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";

                    //    ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                    //    Para = ID + " Dia, Sweep, Pitch " +
                    //        CmdLine.Line[i].DPara[6].ToString() + "," +
                    //        CmdLine.Line[i].DPara[7].ToString() + "," +
                    //        CmdLine.Line[i].DPara[8].ToString();
                    //    break;
                    //#endregion
                    //case DispProg.ECmd.GROUP_DISP:
                    //    #region
                    //    Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                    //    ID = "H" + CmdLine.Line[i].ID.ToString() + " ";
                    //    Para = ID + " " + "M" + CmdLine.Line[i].IPara[0].ToString() + " ";
                    //    if (CmdLine.Line[i].IPara[1] > 0)
                    //        Para = Para + "Weight " + CmdLine.Line[i].DPara[1].ToString("f3") + " mg";

                    //    break;
                    //#endregion
                    case DispProg.ECmd.MOVE:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        ID = "H" + CmdLine.Line[i].ID.ToString() + " ";
                        Para = ID + " ";
                        Para = Para + "P(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ") ";
                        if (CmdLine.Line[i].IPara[3] > 0)
                            Para = Para + "PreMoveZ ";
                        if (CmdLine.Line[i].IPara[4] > 0)
                            Para = Para + Enum.GetName(typeof(EMoveLineRev), CmdLine.Line[i].IPara[4]) + " ";
                        break;
                    #endregion
                    case DispProg.ECmd.LINE:
                        #region
                        {
                            Cmd = Indent;
                            if (CmdLine.Line[i].IPara[10] > 0)
                                Cmd = Cmd + "C";
                            Cmd = Cmd + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);

                            if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";
                            ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                            Para = ID + " " + "M" + CmdLine.Line[i].IPara[0].ToString() + " E(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ")";

                            if (CmdLine.Line[i].IPara[10] > 0)
                            {
                                Para = Para + " " + "R" + CmdLine.Line[i].DPara[10].ToString("f3");
                            }

                            if (CmdLine.Line[i].DPara[0] > 0)
                                Para = Para + " " + CmdLine.Line[i].DPara[0].ToString("F1") + " mg";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.LINE_MULTI:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";
                        ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                        Para = ID + " M" + CmdLine.Line[i].IPara[0].ToString() + " ";
                        Para = Para + CmdLine.Line[i].IPara[5].ToString() + " lines";
                        break;
                    #endregion
                    case DispProg.ECmd.ARC:
                    case DispProg.ECmd.CIRC:
                        #region
                        {
                            #region calculations
                            NSW.Net.Point2D StartPt = new NSW.Net.Point2D(0, 0);
                            NSW.Net.Point2D CenterPt = new NSW.Net.Point2D(0, 0);
                            double Radius = 0;
                            double StartA = 0;
                            double EndA = 0;
                            double SweepA = 0;
                            double Dir = 0;
                            try
                            {
                                int Line = i;
                                while (Line > 0)
                                {
                                    if (CmdLine.Line[Line-1].Cmd == DispProg.ECmd.LINE ||
                                        CmdLine.Line[Line - 1].Cmd == DispProg.ECmd.MOVE ||
                                        CmdLine.Line[Line - 1].Cmd == DispProg.ECmd.DOT)
                                    {
                                        StartPt.X = CmdLine.Line[Line - 1].X[0];
                                        StartPt.Y = CmdLine.Line[Line - 1].Y[0];
                                        //StartPtValid = true;
                                        break;
                                    }
                                    if (CmdLine.Line[Line - 1].Cmd == DispProg.ECmd.ARC)
                                    {
                                        StartPt.X = CmdLine.Line[Line - 1].X[1];
                                        StartPt.Y = CmdLine.Line[Line].Y[1];
                                        //StartPtValid = true;
                                        break;
                                    }
                                    Line--;
                                }

                                double X2 = CmdLine.Line[i].X[0];
                                double Y2 = CmdLine.Line[i].Y[0];
                                double X3 = CmdLine.Line[i].X[1];
                                double Y3 = CmdLine.Line[i].Y[1];
                                GDefine.Arc3PGetInfo(StartPt.X, StartPt.Y, X2, Y2, X3, Y3, ref CenterPt.X, ref CenterPt.Y, ref Radius, ref StartA, ref EndA, ref SweepA, ref Dir);
                            }
                            catch { };
                            #endregion
                            string s_Dir = "CW";
                            if (GDefine.GantryConfig == GDefine.EGantryConfig.XZ_YTABLE) Dir = -Dir;
                            if (Dir < 0) s_Dir = "CCW";

                            Cmd = Indent;
                            if (CmdLine.Line[i].IPara[10] > 0) Cmd = Cmd + "C";
                            Cmd = Cmd + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd) + " " + s_Dir;
                            if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";
                            ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                            Para = ID + " " + "M" + CmdLine.Line[i].IPara[0].ToString() + " " + "T(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ") " + "E(" + CmdLine.Line[i].X[1].ToString("F3") + "," + CmdLine.Line[i].Y[1].ToString("F3") + ")";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.DWELL:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";
                        ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                        Para = ID + " " + "M" + CmdLine.Line[i].IPara[0].ToString() + ", Time " + CmdLine.Line[i].IPara[1].ToString() + " ms";

                        if (CmdLine.Line[i].DPara[0] > 0)
                        {
                            Para = Para + " " + CmdLine.Line[i].DPara[0].ToString("F1") + " mg";
                        }
                        break;
                    #endregion
                    case DispProg.ECmd.WAIT:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "H" + CmdLine.Line[i].ID.ToString() + " ";
                            Para = Para + CmdLine.Line[i].IPara[0] + "ms";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.WIPE_STAGE:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].Cond[0] > 0)
                            Para = $"Cond1,{CmdLine.Line[i].Cond[0]},{CmdLine.Line[i].Cond[1]} ";
                        if (CmdLine.Line[i].Cond[5] > 0)
                            Para = Para + $"Cond2,{CmdLine.Line[i].Cond[5]},{CmdLine.Line[i].Cond[6]} ";


                        if (CmdLine.Line[i].Cmd == DispProg.ECmd.PP_RECYCLE_B || CmdLine.Line[i].Cmd == DispProg.ECmd.PP_RECYCLE_N)
                            Para = Para + "Count " + CmdLine.Line[i].IPara[2].ToString();
                        if (CmdLine.Line[i].Cmd == DispProg.ECmd.PP_RECYCLE_B)
                            Para = Para + ", " + "Method " + ((TaskDisp.ERecycleMethod)CmdLine.Line[i].IPara[3]).ToString();
                        break;
                    #endregion
                    case DispProg.ECmd.PURGE_DOT:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].IPara[2] > 0) Cmd = Cmd + "*";
                        ID = "H" + CmdLine.Line[i].ID.ToString() + "";
                        Para = ID + " " + "M" + CmdLine.Line[i].IPara[0].ToString();
                        if (CmdLine.Line[i].IPara[4] == 0)
                        {
                            Para = Para + " P(Auto)";
                        }
                        else
                            Para = Para + " P(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + CmdLine.Line[i].Z[0].ToString("F3") + ")";

                        if (CmdLine.Line[i].IPara[1] == 1)
                        {
                            Para = Para + " Ext Timed";
                        }
                        else
                        {
                            Para = Para + " Cont";
                        }

                        break;
                    #endregion
                    case DispProg.ECmd.DO_BDCAPTURE:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        ID = "[" + CmdLine.Line[i].ID.ToString() + "]";
                        if (CmdLine.Line[i].IPara[3] == 0)
                        {
                            Para = ID + " Area " + "Fov RC(" + CmdLine.Line[i].Index[0].ToString() + "," + CmdLine.Line[i].Index[1].ToString() + ") " +
                                "S(" + CmdLine.Line[i].X[0].ToString("F3") + "," + CmdLine.Line[i].Y[0].ToString("F3") + ")";
                        }
                        else
                        {
                            Para = ID + " Line ";
                        }
                        break;
                    #endregion
                    case DispProg.ECmd.CLEAN:
                    case DispProg.ECmd.PURGE:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].Cond[0] > 0)
                            Para = $"Cond1,{CmdLine.Line[i].Cond[0]},{CmdLine.Line[i].Cond[1]} ";
                        if (CmdLine.Line[i].Cond[5] > 0)
                            Para = Para + $"Cond2,{CmdLine.Line[i].Cond[5]},{CmdLine.Line[i].Cond[6]} ";

                        if (CmdLine.Line[i].IPara[2] == 0)
                        {
                            if (CmdLine.Line[i].Cmd == DispProg.ECmd.CLEAN)
                                Para = Para + $"(Auto) {TaskDisp.Needle_Clean_Count},{TaskDisp.Needle_Clean_Time}ms,{TaskDisp.Needle_Clean_Wait}ms,{TaskDisp.Needle_Clean_PostVacTime}ms";
                            if (CmdLine.Line[i].Cmd == DispProg.ECmd.PURGE)
                                Para = Para + $"(Auto) {TaskDisp.Needle_Purge_Count},{TaskDisp.Needle_Purge_Time}ms,{TaskDisp.Needle_Purge_Wait}ms,{TaskDisp.Needle_Purge_PostVacTime}ms";
                        }
                        else
                            Para = Para + $"(Custom) {CmdLine.Line[i].IPara[2]},{CmdLine.Line[i].IPara[0]}ms,{CmdLine.Line[i].IPara[1]}ms,{CmdLine.Line[i].IPara[3]}ms";
                        break;
                    #endregion
                    case DispProg.ECmd.PP_FILL:
                    case DispProg.ECmd.PP_CLEANFILL:
                    case DispProg.ECmd.PP_RECYCLE_B:
                    case DispProg.ECmd.PP_RECYCLE_N:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        if (CmdLine.Line[i].Cond[0] > 0)
                            Para = $"Cond1,{CmdLine.Line[i].Cond[0]},{CmdLine.Line[i].Cond[1]} ";
                        if (CmdLine.Line[i].Cond[5] > 0)
                            Para = Para + $"Cond2,{CmdLine.Line[i].Cond[5]},{CmdLine.Line[i].Cond[6]} ";

                        Para = Para + " ";
                        if (CmdLine.Line[i].Cmd == DispProg.ECmd.PP_RECYCLE_B || CmdLine.Line[i].Cmd == DispProg.ECmd.PP_RECYCLE_N)
                                Para = Para + "Count " + CmdLine.Line[i].IPara[2].ToString();
                        if (CmdLine.Line[i].Cmd == DispProg.ECmd.PP_RECYCLE_B)
                            Para = Para + ", " + "Method " + ((TaskDisp.ERecycleMethod)CmdLine.Line[i].IPara[3]).ToString();
                        break;
                    #endregion
                    case DispProg.ECmd.PP_VOL_COMP:
                        #region
                        Cmd = Indent + ((DispProg.ECmd)CmdLine.Line[i].Cmd).ToString();
                        if (DispProg.Target_Weight == 0)
                        {
                            Para = "Vol (ul) (";
                            Para = Para + CmdLine.Line[i].DPara[0].ToString("f3") + ",";
                            Para = Para + CmdLine.Line[i].DPara[1].ToString("f3") + ")";
                        }
                        else
                        {
                            Para = "Vol (mg) (";
                            Para = Para + CmdLine.Line[i].DPara[2].ToString("f3") + ",";
                            Para = Para + CmdLine.Line[i].DPara[3].ToString("f3") + ")";
                        }
                        break;
                    #endregion
                    case DispProg.ECmd.PP_VOL_ADJINC:
                        #region
                        Cmd = Indent + ((DispProg.ECmd)CmdLine.Line[i].Cmd).ToString();
                        Para = "Inc (ul) (";
                        Para = Para + CmdLine.Line[i].DPara[0].ToString("f3") + ",";
                        Para = Para + CmdLine.Line[i].DPara[1].ToString("f3") + ")";
                        break;
                    #endregion
                    case DispProg.ECmd.CREATE_MAP:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        ID = "[" + CmdLine.Line[i].ID.ToString() + "]";
                        Para = ID + " " + "Unit CR(" + CmdLine.Line[i].Index[1].ToString() + "," + CmdLine.Line[i].Index[2].ToString() + ") ";
                        if (CmdLine.Line[i].Index[3] > 1 || CmdLine.Line[i].Index[4] > 1)
                            Para = Para + "Clstr CR(" + CmdLine.Line[i].Index[3].ToString() + "," + CmdLine.Line[i].Index[4].ToString() + ")";
                        break;
                    #endregion
                    case DispProg.ECmd.INPUT_MAP:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        ID = "[" + CmdLine.Line[i].ID.ToString() + "] ";
                        Para = Para + (CmdLine.Line[i].IPara[0] > 0 ? "" : "[Disabled] ");
                        Para = Para + ID + TaskDisp.InputMap_Protocol.ToString();
                        break;
                    #endregion
                    case DispProg.ECmd.LAYOUT_PREMAP:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        ID = "[" + CmdLine.Line[i].ID.ToString() + "]";
                        Para = ID;
                        break;
                    #endregion
                    case DispProg.ECmd.VOLUME_OFST:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            ID = "";
                            string Mode = Enum.GetName(typeof(EVolumeOfstMode), CmdLine.Line[i].IPara[0]);
                            Para = ID + "" + Mode + " (" + CmdLine.Line[i].String + ")";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.MEAS_MENISCUS:
                    case DispProg.ECmd.CHECK_MENISCUS:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            if (CmdLine.Line[i].Cond[0] > 0)
                                Para = $"Cond1,{CmdLine.Line[i].Cond[0]},{CmdLine.Line[i].Cond[1]} ";
                            if (CmdLine.Line[i].Cond[5] > 0)
                                Para = Para + $"Cond2,{CmdLine.Line[i].Cond[5]},{CmdLine.Line[i].Cond[6]} ";
                            break;
                        }
                    #endregion
                    case DispProg.ECmd.TEMPLOGGER_LOG:
                        #region
                        {
                            Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                            Para = "[" + CmdLine.Line[i].ID.ToString() + "] ";
                            break;
                        }
                    #endregion
                    #endregion
                    default:
                        #region
                        Cmd = Indent + Enum.GetName(typeof(DispProg.ECmd), CmdLine.Line[i].Cmd);
                        break;
                        #endregion
                }
                lvi = new ListViewItem(new string[] { No, Cmd, /*ID,*/ Para });
                lv_Program.Items.Add(lvi);
            }
            #endregion
            if (ProgLine > 24)
                lv_Program.EnsureVisible(Math.Min(lv_Program.Items.Count - 1, ProgLine + 24));
        }
        public void UpdateSubOffset()
        {
            if (SelProg == 0)
            {
                SubOfst.X = 0;
                SubOfst.Y = 0;
                return;
            }

            for (int i = 0; i < DispProg.TCmdList.MAX_CMD; i++)
            {
                if (DispProg.Script[0].CmdList.Line[i].Cmd == DispProg.ECmd.SUB)
                    if (DispProg.Script[0].CmdList.Line[i].ID == SelProg)
                    {
                        SubOfst.X = DispProg.Script[0].CmdList.Line[i].X[0];
                        SubOfst.Y = DispProg.Script[0].CmdList.Line[i].Y[0];
                        break;
                    }
            }
        }
        private void tmr_UpdateDisplay_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (TaskDisp.Option_EnableChuckVac)
            {
                tslbl_ChuckVac.Visible = true;
                tslbl_ChuckVac.BackColor = TaskGantry.ChuckVac ? Color.Lime : this.BackColor;
            }

            UpdateDisplay();
        }

        public static frmCamera frmCamera = new frmCamera();
        private void frmDispProg_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);

            DispProg.SetupMode = true;

            Done = true;

            if (!Modal) this.WindowState = FormWindowState.Maximized;

            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                frmCamera.Dispose();
                //Invoke(new Action(() =>
                //{
                    TaskVision.frmMVCGenTLCamera = new frmMVCGenTLCamera();
                    TaskVision.frmMVCGenTLCamera.CamReticles = Reticle.Reticles;
                    TaskVision.frmMVCGenTLCamera.FormBorderStyle = FormBorderStyle.None;
                    TaskVision.frmMVCGenTLCamera.TopLevel = false;
                    TaskVision.frmMVCGenTLCamera.Parent = splitContainer2.Panel1;
                    TaskVision.frmMVCGenTLCamera.Dock = DockStyle.Fill;
                    TaskVision.frmMVCGenTLCamera.Show();

                    if (TaskVision.genTLCamera[0].IsConnected)
                    {
                        TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                        TaskVision.frmMVCGenTLCamera.ShowCamReticles = true;
                        TaskVision.genTLCamera[0].StartGrab();
                    }
                //}));

            }
            frm_Jog = new frmJogGantry();
            frm_Jog.FormBorderStyle = FormBorderStyle.None;
            frm_Jog.TopLevel = false;
            frm_Jog.Parent = splitContainer2.Panel2;
            frm_Jog.Dock = DockStyle.Right;
            frm_Jog.Show();

            splitContainer1.Panel1MinSize = 200;
            splitContainer1.SplitterDistance = 500;
            splitContainer2.Panel1MinSize = 100;
            splitContainer2.SplitterDistance = splitContainer2.Height - 230;

            UpdateDisplay();
            RefreshProgramList();

            AppLanguage.Func2.UpdateText(this);

            if (DispProg.rt_StationNo < 0) DispProg.rt_StationNo = 0;

            tscombox_Script.SelectedIndex = 0;

            switch (DispProg.RunMode)
            {
                case ERunMode.Camera:
                    tsddbtn_RunMode.Image = tsmi_RunMode_Camera.Image;
                    tsddbtn_RunMode.Text = tsmi_RunMode_Camera.Text;
                    break;
                case ERunMode.Dry:
                    tsddbtn_RunMode.Image = tsmi_RunMode_Dry.Image;
                    tsddbtn_RunMode.Text = tsmi_RunMode_Dry.Text;
                    break;
                case ERunMode.Normal:
                    tsddbtn_RunMode.Image = tsmi_RunMode_Normal.Image;
                    tsddbtn_RunMode.Text = tsmi_RunMode_Normal.Text;
                    break;
            }

            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.None:
                case TaskDisp.EPumpType.Single:
                case TaskDisp.EPumpType.TP:
                case TaskDisp.EPumpType.TPRV:
                    break;
                default:
                    if (!TaskDisp.DispCtrlOpened(0)) TaskDisp.OpenDispCtrl(0);
                    break;
            }

            if (DispProg.OriginDrawOfst.X != 0 || DispProg.OriginDrawOfst.Y != 0)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.PROGRAM_DRAW_OFFSET_UPDATE, EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                if (MsgRes == EMsgRes.smrOK)
                {
                    DispProg.Script[0].DrawOffset_Update();
                }
                RefreshProgramList();
            }

            if (GDefine.CameraType[(int)TaskVision.SelectedCam] == GDefine.ECameraType.MVSGenTL)
            {
                TaskVision.genTLCamera[(int)TaskVision.SelectedCam].GrabOneImage();
                TaskVision.Image = TaskVision.genTLCamera[(int)TaskVision.SelectedCam].mImage.Clone();
                if (TaskVision.frmMVCGenTLCamera.Visible) TaskVision.genTLCamera[(int)TaskVision.SelectedCam].StartGrab();
            }
        }
        private void frm_DispCore_DispProg_Activated(object sender, EventArgs e)
        {
        }
        private void frmDispProg_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Layout.Close();
            frm_Layout.Dispose();

            TaskDisp.TaskMoveGZZ2Up();

            DispProg.SetupMode = false;

            if (frm_Jog != null)
            {
                frm_Jog.Close();
                frm_Jog.Dispose();
            }
            if (frm_Setting != null) frm_Setting.Close();

            NUtils.RegistryWR Reg = new NUtils.RegistryWR();
            Reg.WriteKey(GDefine.RegSubKey_DispProg, "MapWind", frmMap.Bounds);
            if (frmMap != null)
            {
                frmMap.Close();
                frmMap.Dispose();
            }

            if (frmSP != null) frmSP.Close();
            if (frmPJ != null) frmPJ.Close();

            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                TaskVision.frmMVCGenTLCamera.Close();
            }
        }
        private void frm_DispProg2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void frm_DispProg2_Shown(object sender, EventArgs e)
        {
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                TaskVision.frmMVCGenTLCamera.ZoomFit();
            }
        }

        private void frm_DispProg2_Resize(object sender, EventArgs e)
        {
        }
        private void frm_DispProg2_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void splitContainer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            splitContainer1.SplitterDistance = 500;
        }
        private void splitContainer2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height - 230;
        }

        private void FormEnable()
        {
            this.Enabled = true;
            frm_Jog.Enabled = frm_Jog.Visible;
        }
        private void FormDisable()
        {
            this.Enabled = false;
            frm_Jog.Enabled = !frm_Jog.Visible;
        }

        #region Main Strip
        private void tsmi_Station1_Click(object sender, EventArgs e)
        {
            DispProg.rt_StationNo = ERunStationNo.Station1;
            UpdateDisplay();
        }
        private void tsmi_Station2_Click(object sender, EventArgs e)
        {
            DispProg.rt_StationNo = ERunStationNo.Station2;
            UpdateDisplay();
        }
        private void tsmi_Station3_Click(object sender, EventArgs e)
        {
            DispProg.rt_StationNo = ERunStationNo.Station3;
            UpdateDisplay();
        }
        private void tsmi_Station4_Click(object sender, EventArgs e)
        {
            DispProg.rt_StationNo = ERunStationNo.Station4;
            UpdateDisplay();
        }
        private void tsmi_Station5_Click(object sender, EventArgs e)
        {
            DispProg.rt_StationNo = ERunStationNo.Station5;
            UpdateDisplay();
        }
        private void tsmi_Station6_Click(object sender, EventArgs e)
        {
            DispProg.rt_StationNo = ERunStationNo.Station6;
            UpdateDisplay();
        }
        private void tsmi_Station7_Click(object sender, EventArgs e)
        {
            DispProg.rt_StationNo = ERunStationNo.Station7;
            UpdateDisplay();
        }
        private void tsmi_Station8_Click(object sender, EventArgs e)
        {
            DispProg.rt_StationNo = ERunStationNo.Station8;
            UpdateDisplay();
        }
        private void tsbtn_SetZ_Click(object sender, EventArgs e)
        {
            frm_ProgressReport frm = new frm_ProgressReport();
            frm.Message = "Set ProductZ?";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm1 = new frm_ProgressReport();
                frm1.Message = "Setting ProductZ. Please wait...";

                Task.Factory.StartNew(() =>
                {
                    double z = DispProg.OriginBase[(int)DispProg.rt_StationNo].Z;

                    DispProg.OriginBase[(int)DispProg.rt_StationNo].Z = TaskGantry.GZPos() - TaskDisp.Head_Ofst[0].Z - TaskDisp.Z1Offset;
                    DispProg.OriginDrawOfst.Z = 0;

                    Log.OnSet("SetZ", z, DispProg.OriginBase[(int)DispProg.rt_StationNo].Z);

                    if (!TaskDisp.TaskMoveGZZ2Up()) return;

                    frm1.Done = true;
                });
            }
        }
        private void tsbtn_SetOrigin_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckInDispenseArea()) return;

           frm_ProgressReport frm = new frm_ProgressReport();
            frm.Message = "Set Origin?";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm1 = new frm_ProgressReport();
                frm1.Message = "Setting Origin. Please wait...";

                Task.Factory.StartNew(() =>
                {
                    DispProg.RunMode = ERunMode.Camera;
                    tsddbtn_RunMode.Image = tsmi_RunMode_Camera.Image;
                    tsddbtn_RunMode.Text = tsmi_RunMode_Camera.Text;

                    if (DispProg.RunMode == ERunMode.Camera)//Normal || DispProg.RunMode == ERunMode.Dry)
                    {
                        double x = DispProg.OriginBase[(int)DispProg.rt_StationNo].X;
                        double y = DispProg.OriginBase[(int)DispProg.rt_StationNo].Y;

                        DispProg.OriginBase[(int)DispProg.rt_StationNo].X = TaskGantry.GXPos();
                        DispProg.OriginBase[(int)DispProg.rt_StationNo].Y = TaskGantry.GYPos();

                        Log.OnSet("Origin", new NSW.Net.Point2D(x, y), new NSW.Net.Point2D(DispProg.OriginBase[(int)DispProg.rt_StationNo].X, DispProg.OriginBase[(int)DispProg.rt_StationNo].Y));
                    }

                    frm1.Done = true;
                });
            }
            
            DispProg.RunTime.UIndex = 0;
        }
        private void tsbtn_CamGoOrigin_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.TaskMoveGZFocus(0)) return;

            if (!TaskGantry.SetMotionParamGXYX2Y2()) return;

            TPos2 GXY = new TPos2(DispProg.Origin(DispProg.rt_StationNo).X, DispProg.Origin(DispProg.rt_StationNo).Y);
            TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
            GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

            if (!TaskDisp.GotoXYPos(GXY, GX2Y2)) return;
        }
        private void tsbtn_NeedleGoOrigin_Click(object sender, EventArgs e)
        {
            //btn_Dummy.Focus();
            if (!TaskDisp.TaskMoveGZFocus(0)) return;

            if (!TaskGantry.SetMotionParamGXYX2Y2()) return;

            TPos2 GXY = new TPos2(DispProg.Origin(DispProg.rt_StationNo).X, DispProg.Origin(DispProg.rt_StationNo).Y);
            TPos2 GX2Y2 = new TPos2(TaskDisp.Head2_DefPos.X, TaskDisp.Head2_DefPos.Y);
            GX2Y2.X = GX2Y2.X - TaskDisp.Head2_DefDistX + TaskDisp.Head2_DefDistX;

            GXY.X = GXY.X + TaskDisp.Head_Ofst[0].X;
            GXY.Y = GXY.Y + TaskDisp.Head_Ofst[0].Y;

            if (!TaskDisp.GotoXYPos(GXY, GX2Y2)) return;
        }
        private void tslbl_Status_DoubleClick(object sender, EventArgs e)
        {
            GDefine.Status = EStatus.Ready;
            UpdateDisplay();
        }

        private void tsbtn_MasterAlign_Click(object sender, EventArgs e)
        {
            try
            {
                DispProg.MasterAlign();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }
        #endregion

        #region Program Load/Save
        private void ts_ProgNew_Click(object sender, EventArgs e)
        {
            frm_ProgressReport frm = new frm_ProgressReport();
            frm.Message = "Create New Program?";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm1 = new frm_ProgressReport();
                frm1.Message = "Creating in Progress. Please wait...";

                    DispProg.NewScript();
                    GDefine.ProgRecipeName = "new";
            }

            UpdateDisplay();
            RefreshProgramList();
        }

        frm_ProgressReport frm1 = new frm_ProgressReport();
        private async void ts_ProgOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = GDefine.ProgPath;
            ofd.Filter = "Program|*." + GDefine.ProgExt;
            if (TaskDisp.EnableRecipeFile)
            {
                ofd.InitialDirectory = GDefine.RecipeDir.FullName;
                ofd.Filter = "Recipe|*" + GDefine.RecipeExt + "|" + "Program|*." + GDefine.ProgExt;
                ofd.DefaultExt = GDefine.RecipeExt;
            }

            ofd.FileName = GDefine.ProgRecipeName;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.Cancel) return;

            this.Enabled = false;

            frm1 = new frm_ProgressReport();
            frm1.Message = "Loading in Progress. Please wait...";
            frm1.Show();

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    GDefine.ProgRecipeName = Path.GetFileNameWithoutExtension(ofd.FileName);
                    DispProg.Load(ofd.FileName, true);
                    Dirty = true;
                });
            }
            finally
            {
                this.Enabled = true;
                frm1.Close();
            }

            UpdateDisplay();
            RefreshProgramList();
        }
        private void Save()
        {
            while (GDefine.ProgRecipeName.EndsWith(" ")) GDefine.ProgRecipeName = GDefine.ProgRecipeName.Remove(GDefine.ProgRecipeName.Length - 1);
            string fileName = GDefine.ProgPath + "\\" + GDefine.ProgRecipeName + "." + GDefine.ProgExt;
            if (TaskDisp.EnableRecipeFile) fileName = GDefine.RecipeDir.FullName + GDefine.ProgRecipeName + GDefine.RecipeExt;
            DispProg.Save(fileName);
            UpdateDisplay();
        }
        private async void ts_ProgSave_Click(object sender, EventArgs e)
        {
            if (GDefine.ProgRecipeName == "new" || GDefine.ProgRecipeName == "default")
            {
                SaveAs();
                return;
            }

            frm_ProgressReport frm = new frm_ProgressReport();
            frm.Message = "Save " + GDefine.ProgRecipeName + "?";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm1 = new frm_ProgressReport();
                frm1.Message = "Saving in Progress. Please wait...";
                frm1.Show();
                try
                {
                    await Task.Factory.StartNew(() =>
                    {
                        Save();
                    });
                }
                finally
                {
                    frm1.Close();
                }
            }
        }
        private async void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (TaskDisp.EnableRecipeFile)
            {
                sfd.InitialDirectory = GDefine.RecipeDir.FullName;
                sfd.Filter = "Recipe|*" + GDefine.RecipeExt + "|" + "Program|*." + GDefine.ProgExt;
            }
            else
            {
                sfd.InitialDirectory = GDefine.ProgPath;
                sfd.Filter = "Program|*." + GDefine.ProgExt;
            }

            sfd.AddExtension = true;
            if (GDefine.ProgRecipeName == "new" || GDefine.ProgRecipeName == "default")
                sfd.FileName = "";
            else
                sfd.FileName = GDefine.ProgRecipeName;

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.Cancel) return;

            frm1 = new frm_ProgressReport();
            frm1.Message = "Saving in Progress. Please wait...";
            frm1.Show();
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    DispProg.Save(sfd.FileName);
                    frm1.Done = true;
                });
            }
            finally
            {
                frm1.Close();
            }

            UpdateDisplay();
        }
        private void ts_ProgSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        private void ts_ProgManage_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_ManageProgram frm = new frm_DispCore_DispProg_ManageProgram();
            frm.ShowDialog();
        }
        private void ts_ProgSetting_Click(object sender, EventArgs e)
        {
            frm_Setting.BringToFront();
            frm_Setting.TopMost = true;
            frm_Setting.Show();
            frm_Setting.Location = new Point(0, 0);
        }
        private void ts_ProgModel_Click(object sender, EventArgs e)
        {
            //btn_Dummy.Focus();
            frm_Setting.Visible = false;

            //b_MapVisible = frmMap.Visible;
            //frmMap.Visible = false;

            frm_DispCore_DispProg_ModelList frmModel = new frm_DispCore_DispProg_ModelList();
            frmModel.TopMost = true;
            frmModel.ShowDialog();
            frmModel.BringToFront();

            //frmMap.Visible = b_MapVisible;
        }
        #endregion

        #region Program Edit
        public static bool Done = true;
        public static bool Dirty = false;

        int ProgLine = 0;
        frm_DispCore_DispProg_Layout frm_Layout = new frm_DispCore_DispProg_Layout();
        frm_DispCore_DispProg_DoVision frm_DO_VIS_INSP = new frm_DispCore_DispProg_DoVision();
        private void lv_Program_MouseDown(object sender, MouseEventArgs e)
        {
            int SelectedProgram = SelProg;
            if (SelectedProgram < 0) return;

            if (e.Button == MouseButtons.Left)
            {
            }

            if (e.Button == MouseButtons.Right)
            #region
            {
                Point mousePosition = lv_Program.PointToClient(Control.MousePosition);
                ListViewHitTestInfo hit = lv_Program.HitTest(mousePosition);
                if (hit.Item == null)
                {
                    return;
                }

                ProgLine = hit.Item.Index;
                lv_Program.Items[ProgLine].Selected = true;

                if (DispProg.Script[SelProg].CmdList.Line[ProgLine].Cmd == DispProg.ECmd.FOR_LAYOUT || DispProg.Script[SelProg].CmdList.Line[ProgLine].Cmd == DispProg.ECmd.LAYOUT)
                {
                    cmsCopyPosition.Visible = false;
                    cmsPastePosition.Visible = false;
                    cmsCopyGroup.Visible = true;
                    //cmsPasteGroup.Visible = true;
                    cmsPasteGroup.Visible = cmdList != null;
                }
                else
                {
                    cmsCopyPosition.Visible = true;
                    cmsPastePosition.Visible = true;
                    cmsCopyGroup.Visible = false;
                    //cmsPasteGroup.Visible = false;
                    cmsPasteGroup.Visible = cmdList != null;
                }
                cms_CopyPaste.Show(this.Location.X + pnl_Prog.Left + mousePosition.X, this.Location.Y + pnl_Prog.Top + mousePosition.Y + 40);
            }
            #endregion
        }
        private void lv_Program_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                #region Mouse Left
                {
                    if (!Done) return;

                    Point mousePosition = lv_Program.PointToClient(Control.MousePosition);
                    ListViewHitTestInfo hit = lv_Program.HitTest(mousePosition);
                    if (hit.Item != null)
                    {
                        ProgLine = hit.Item.Index;
                        lv_Program.Items[ProgLine].Selected = true;
                        goto _SelectEdit;
                    }
                    else
                    {
                        return;
                    }
                    _SelectEdit:
                    int ColIndex = hit.Item.SubItems.IndexOf(hit.SubItem);
                    if (DispProg.Script[SelProg].CmdList.Count == 0) return;

                    switch (ColIndex)
                    {
                        case 1:
                            UpdateSubOffset();
                            switch (DispProg.Script[SelProg].CmdList.Line[ProgLine].Cmd)
                            {
                                case DispProg.ECmd.NONE:
                                    #region
                                    {
                                        return;
                                    }
                                #endregion
                                case DispProg.ECmd.LAYOUT:
                                    #region
                                    {
                                        //frm_DispCore_DispProg_Layout frm = new frm_DispCore_DispProg_Layout();
                                        //frm.TopLevel = false;
                                        //frm.Parent = this;
                                        //frm.ProgNo = SelProg;
                                        //frm.LineNo = ProgLine;
                                        //frm.SubOrigin = SubOfst;
                                        //frm.BringToFront();
                                        //b_Dirty = true;
                                        //Done = false;
                                        //frm.Show();
                                        //break;

                                        //if (frm_Layout == null)
                                        frm_Layout = new frm_DispCore_DispProg_Layout();
                                        frm_Layout.ProgNo = SelProg;
                                        frm_Layout.LineNo = ProgLine;
                                        frm_Layout.SubOrigin = SubOfst;
                                        frm_Layout.BringToFront();
                                        frm_Layout.TopMost = true;
                                        Dirty = true;
                                        Done = false;
                                        frm_Layout.Show();
                                        frm_Layout.Left = 0;
                                        frm_Layout.Top = 0;
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.REPEAT:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Repeat frm = new frm_DispCore_DispProg_Repeat();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.SUB:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Sub frm = new frm_DispCore_DispProg_Sub();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.SET_GPOUT:
                                    #region
                                    {
                                        frmDispCore_DispProg_GPOut frm = new frmDispCore_DispProg_GPOut();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.COMMENT:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Comment frm = new frm_DispCore_DispProg_Comment();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        //frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.DO_REF:
                                    #region
                                    {
                                        frm_DispCore_DispProg_DoRef frm = new frm_DispCore_DispProg_DoRef();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DO_REF_CHECK:
                                case DispProg.ECmd.DO_VISION_CHECK:
                                    #region
                                    {
                                        frmDoRefCheck frm = new frmDoRefCheck();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DO_REF_EDGE:
                                    #region
                                    {
                                        frmDispProgDoRefEdge frm = new frmDispProgDoRefEdge();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DO_VISION:
                                    #region
                                    {
                                        frm_DispCore_DispProg_DoVision frm = new frm_DispCore_DispProg_DoVision();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        frm.TopMost = true;
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DO_BDORIENT:
                                    #region
                                    {
                                        frm_DispCore_DispProg_BdOrient frm = new frm_DispCore_DispProg_BdOrient();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DO_UNITMARK:
                                    #region
                                    {
                                        frm_DispCore_DispProg_DoUnitMark frm = new frm_DispCore_DispProg_DoUnitMark();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.DO_VIS_INSP:
                                    #region
                                    {
                                        //frm_DispCore_DispProg_DoVision frm_DO_VIS_INSP = new frm_DispCore_DispProg_DoVision();
                                        frm_DO_VIS_INSP = new frm_DispCore_DispProg_DoVision();
                                        frm_DO_VIS_INSP.TopLevel = false;
                                        frm_DO_VIS_INSP.Parent = this;
                                        frm_DO_VIS_INSP.ProgNo = SelProg;
                                        frm_DO_VIS_INSP.LineNo = ProgLine;
                                        frm_DO_VIS_INSP.SubOrigin = SubOfst;
                                        frm_DO_VIS_INSP.BringToFront();
                                        frm_DO_VIS_INSP.TopMost = true;
                                        Dirty = true;
                                        Done = false;
                                        frm_DO_VIS_INSP.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.READ_ID:
                                    #region
                                    {
                                        frm_DispCore_DispProg_ReadID frm = new frm_DispCore_DispProg_ReadID();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.USE_REF:
                                case DispProg.ECmd.USE_VISION:
                                case DispProg.ECmd.LAYOUT_PREMAP:
                                case DispProg.ECmd.TEMPLOGGER_LOG:
                                    #region
                                    {
                                        frm_DispCore_DispProg_UseRef frm = new frm_DispCore_DispProg_UseRef();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DO_HEIGHT:
                                case DispProg.ECmd.HEIGHT_SET:
                                    #region
                                    {
                                        frm_DispCore_DispProg_DoHeight frm = new frm_DispCore_DispProg_DoHeight();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.USE_HEIGHT:
                                    #region
                                    {
                                        frm_DispCore_DispProg_UseHeight frm = new frm_DispCore_DispProg_UseHeight();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        //frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.MEAS_TEMP:
                                    #region
                                    {
                                        frmMeasTemp frm = new frmMeasTemp();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DOT:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Dot frm = new frm_DispCore_DispProg_Dot();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DOT_MULTI:
                                    #region
                                    {
                                        frm_DispCore_DispProg_DotMulti frm = new frm_DispCore_DispProg_DotMulti();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DOTLINE_MULTI:
                                    #region
                                    {
                                        frm_DispCore_DispProg_DotMulti frm = new frm_DispCore_DispProg_DotMulti();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DOT_P:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Dot frm = new frm_DispCore_DispProg_Dot();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.MOVE:
                                case DispProg.ECmd.LINE:
                                    #region
                                    {
                                        frm_DispCore_DispProg_MoveLine frm = new frm_DispCore_DispProg_MoveLine();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.LINE_MULTI:
                                    #region
                                    {
                                        frm_DispCore_DispProg_LineMulti frm = new frm_DispCore_DispProg_LineMulti();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.ARC:
                                case DispProg.ECmd.CIRC:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Arc frm = new frm_DispCore_DispProg_Arc();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DWELL:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Dwell frm = new frm_DispCore_DispProg_Dwell();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.WAIT:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Delay frm = new frm_DispCore_DispProg_Delay();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        //frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.DO_BDCAPTURE:
                                    #region
                                    {
                                        frm_DispCore_DispProg_DoBdCapture frm = new frm_DispCore_DispProg_DoBdCapture();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.CREATE_MAP:
                                    #region
                                    {
                                        frm_DispCore_DispProg_CreateMap frm = new frm_DispCore_DispProg_CreateMap();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.INPUT_MAP:
                                    #region
                                    {
                                        frm_DispCore_DispProg_InputMap frm = new frm_DispCore_DispProg_InputMap();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        //frm.TopMost = true;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.PURGE:
                                case DispProg.ECmd.CLEAN:
                                    #region
                                    {
                                        frm_DispCore_DispProg_PurgeClean frm = new frm_DispCore_DispProg_PurgeClean();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        //frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.WIPE_STAGE:
                                case DispProg.ECmd.PP_FILL:
                                case DispProg.ECmd.PP_CLEANFILL:
                                case DispProg.ECmd.PP_RECYCLE_B:
                                case DispProg.ECmd.PP_RECYCLE_N:
                                    #region
                                    {
                                        frm_DispCore_DispProg_PPFillRecycle frm = new frm_DispCore_DispProg_PPFillRecycle();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.PP_VOL_COMP:
                                    #region
                                    {
                                        frm_DispCore_DispProg_PPVolComp frm = new frm_DispCore_DispProg_PPVolComp();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.PP_VOL_ADJINC:
                                    #region
                                    {
                                        frm_DispCore_DispProg_PPVolComp frm = new frm_DispCore_DispProg_PPVolComp();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.ShowCond = false;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.PURGE_DOT:
                                    #region
                                    {
                                        frm_DispCore_DispProg_PurgeDot frm = new frm_DispCore_DispProg_PurgeDot();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.GO_POS:
                                    #region
                                    {
                                        frm_DispCore_DispProg_GoPos frm = new frm_DispCore_DispProg_GoPos();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.DELAY:
                                    #region
                                    {
                                        frm_DispCore_DispProg_Delay frm = new frm_DispCore_DispProg_Delay();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        //frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion

                                case DispProg.ECmd.EXT_VISION:
                                    #region
                                    {
                                        frmDispProg_ExtVis frm = new frmDispProg_ExtVis();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.NEEDLE_INSP:
                                    #region
                                    {
                                        frmDispProg_NeedleInsp frm = new frmDispProg_NeedleInsp();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.WEIGHT_CAL:
                                    {
                                        frm_DispCore_DispProg_WeightCal frm = new frm_DispCore_DispProg_WeightCal();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;

                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }

                                case DispProg.ECmd.MEASL_WH:
                                    #region
                                    {
                                        frm_DispCore_DispProg_MeasL_WH frm = new frm_DispCore_DispProg_MeasL_WH();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.MEASL_H:
                                    #region
                                    {
                                        frm_DispCore_DispProg_MeasL_H frm = new frm_DispCore_DispProg_MeasL_H();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.MEAS_MENISCUS:
                                case DispProg.ECmd.CHECK_MENISCUS:
                                    #region
                                    {
                                        frm_DispCore_MeasMen frm = new frm_DispCore_MeasMen();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.SubOrigin = SubOfst;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.VOLUME_MAP:
                                    #region
                                    {
                                        frm_DispCore_DispProg_VolumeMap frm = new frm_DispCore_DispProg_VolumeMap();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                case DispProg.ECmd.VOLUME_OFST:
                                    #region
                                    {
                                        frm_DispCore_DispProg_VolumeOfst frm = new frm_DispCore_DispProg_VolumeOfst();
                                        frm.TopLevel = false;
                                        frm.Parent = this;
                                        frm.ProgNo = SelProg;
                                        frm.LineNo = ProgLine;
                                        frm.BringToFront();
                                        Dirty = true;
                                        Done = false;
                                        frm.Show();
                                        break;
                                    }
                                #endregion
                                default:
                                    {
                                        break;
                                    }
                            }
                            lv_Program.Items[ProgLine].Selected = true;
                            DispProg.TracedLine = -1;

                            break;
                        case 2:
                            lv_Program.Items[ProgLine].Selected = true;
                            if (!DispProg.TraceMode) return;

                            switch (DispProg.Script[SelProg].CmdList.Line[ProgLine].Cmd)
                            {
                                case DispProg.ECmd.DOT:
                                case DispProg.ECmd.MOVE:
                                case DispProg.ECmd.LINE:
                                case DispProg.ECmd.ARC:
                                case DispProg.ECmd.DOT_P:
                                case DispProg.ECmd.DO_HEIGHT:
                                case DispProg.ECmd.DO_REF:
                                case DispProg.ECmd.DO_VISION:
                                case DispProg.ECmd.DO_REF_EDGE:
                                    double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOfst.X) + DispProg.Script[SelProg].CmdList.Line[ProgLine].X[0];
                                    double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOfst.Y) + DispProg.Script[SelProg].CmdList.Line[ProgLine].Y[0];
                                    if (!TaskDisp.TaskMoveGZZ2Up()) return;

                                    if (!TaskGantry.SetMotionParamGXY()) return;
                                    if (!TaskGantry.MoveAbsGXY(X, Y)) return;

                                    DispProg.TracedLine = ProgLine;
                                    break;
                                default:
                                    DispProg.TracedLine = -1;
                                    break;
                            }
                            break;
                        default:
                            lv_Program.Items[ProgLine].Selected = true;
                            DispProg.TracedLine = -1;
                            return;
                            //break;
                    }

                }
                #endregion

                if (e.Button == MouseButtons.Right)
                #region Mouse Right
                {

                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }
        private void lv_Program_MouseLeave(object sender, EventArgs e)
        {
        }

        double[] X = new double[DispProg.TLine.MAX_PARA];
        double[] Y = new double[DispProg.TLine.MAX_PARA];
        double[] Z = new double[DispProg.TLine.MAX_PARA];
        double[] U = new double[DispProg.TLine.MAX_PARA];
        private void tsmi_CopyPosition_Click(object sender, EventArgs e)
        {
            if (ProgLine < 0) return;
            DispProg.Script[SelProg].CmdList.Line[ProgLine].X.CopyTo(X, 0);
            DispProg.Script[SelProg].CmdList.Line[ProgLine].Y.CopyTo(Y, 0);
            DispProg.Script[SelProg].CmdList.Line[ProgLine].Z.CopyTo(Z, 0);
            DispProg.Script[SelProg].CmdList.Line[ProgLine].U.CopyTo(U, 0);
        }
        private void tsmi_PastePosition_Click(object sender, EventArgs e)
        {
            if (ProgLine < 0) return;
            X.CopyTo(DispProg.Script[SelProg].CmdList.Line[ProgLine].X, 0);
            Y.CopyTo(DispProg.Script[SelProg].CmdList.Line[ProgLine].Y, 0);
            Z.CopyTo(DispProg.Script[SelProg].CmdList.Line[ProgLine].Z, 0);
            U.CopyTo(DispProg.Script[SelProg].CmdList.Line[ProgLine].U, 0);

            RefreshProgramList();
        }

        DispProg.TLine[] cmdList = null;
        private void cmsCopyGroup_Click(object sender, EventArgs e)
        {
            if (ProgLine < 0) return;

            cmdList = null;
            int lastRow = 0;
            for (int i = ProgLine; i < DispProg.Script[SelProg].CmdList.Count; i++)
            {
                if (DispProg.Script[SelProg].CmdList.Line[i].Cmd == DispProg.ECmd.END_LAYOUT)
                {
                    lastRow = i;
                    break;
                }
            }

            cmdList = Enumerable.Range(ProgLine, lastRow - ProgLine + 1).Select(x => DispProg.Script[SelProg].CmdList.Line[x]).ToArray();
        }
        private void cmsPasteGroup_Click(object sender, EventArgs e)
        {
            if (ProgLine < 0) return;

            foreach (DispProg.TLine cmd in cmdList)
            {
                ProgLine++;
                DispProg.Script[SelProg].Insert(ref ProgLine, DispProg.ECmd.NONE);
                DispProg.Script[SelProg].CmdList.Line[ProgLine] = new DispProg.TLine(cmd);
            }

            DispProg.Script[0].Validate(0);
            RefreshProgramList();
        }

        private void tscombox_Script_Click(object sender, EventArgs e)
        {
        }
        private void tscombox_Script_DropDownClosed(object sender, EventArgs e)
        {
            SelProg = tscombox_Script.SelectedIndex;
            RefreshProgramList();
        }
        private void tsbtn_Lock_Click(object sender, EventArgs e)
        {
            b_ProgEdit = !b_ProgEdit;
            UpdateDisplay();
        }
        private void tsbtn_ProgLineAdd_Click(object sender, EventArgs e)
        {
            //if (DispProg.LastLine > -1)
            //{
            //    Msg MsgBox = new Msg();
            //    EMsgRes MsgRes = MsgBox.Show(ErrCode.PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION, EMcState.Notice, EMsgBtn.smbOK, false);
            //    return;
            //}

            //Refresh_cmsCommand(SelProg > 0);
            //cms_Command.Show(this.Location.X + lv_Program.Location.X, this.Location.Y + lv_Program.Location.Y);
            //ProgLine = DispProg.Script[SelProg].CmdList.Count;

            frmCmdSelect frm = new frmCmdSelect();
            frm.Location = ts_ProgEdit.Location;//new Point(this.Location.X + lv_Program.Location.X, this.Location.Y + lv_Program.Location.Y);
            if (frm.ShowDialog() != DialogResult.OK) return;
            if (ProgLine >= DispProg.TCmdList.MAX_CMD) return;//Reached MAX_CMD

            ProgLine = DispProg.Script[SelProg].CmdList.Count;

            DispProg.Script[SelProg].Insert(ref ProgLine, frm.Command);
            DispProg.Script[SelProg].Validate(ProgLine);
            RefreshProgramList();
            lv_Program.Items[ProgLine].Selected = true;
        }
        private void tsbtn_ProgLineInsert_Click(object sender, EventArgs e)
        {
            //if (DispProg.LastLine > -1)
            //{
            //    Msg MsgBox = new Msg();
            //    EMsgRes MsgRes = MsgBox.Show(ErrCode.PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION, EMcState.Notice, EMsgBtn.smbOK, false);
            //    return;
            //}

            //Refresh_cmsCommand(SelProg > 0);
            //cms_Command.Show(this.Location.X + lv_Program.Location.X, this.Location.Y + lv_Program.Location.Y);

            frmCmdSelect frm = new frmCmdSelect();
            frm.Location = ts_ProgEdit.Location;//new Point(this.Location.X + lv_Program.Location.X, this.Location.Y + lv_Program.Location.Y);
            if (frm.ShowDialog() != DialogResult.OK) return;
            if (ProgLine >= DispProg.TCmdList.MAX_CMD) return;//Reached MAX_CMD

            DispProg.Script[SelProg].Insert(ref ProgLine, frm.Command);
            DispProg.Script[SelProg].Validate(ProgLine);
            RefreshProgramList();
            lv_Program.Items[ProgLine].Selected = true;
        }
        private void tsbtn_ProgLineDel_Click(object sender, EventArgs e)
        {
            //btn_Dummy.Focus();

            if (DispProg.LastLine > -1)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION, EMcState.Notice, EMsgBtn.smbOK, false);
                return;
            }

            DispProg.Script[SelProg].Delete(ref ProgLine);
            DispProg.Script[SelProg].Validate(0);

            RefreshProgramList();

            if (ProgLine > 0)
                //lv_Program.Items[ProgLine - 1].Selected = true;
            lv_Program.Items[ProgLine].Selected = true;
        }
        private void tsbtn_ProgLineMoveUp_Click(object sender, EventArgs e)
        {
            //btn_Dummy.Focus();

            if (DispProg.LastLine > -1)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION, EMcState.Notice, EMsgBtn.smbOK, false);
                return;
            }

            if (ProgLine == 0) return;
            DispProg.Script[SelProg].MoveUp(ref ProgLine);
            DispProg.Script[SelProg].Validate(ProgLine);

            RefreshProgramList();
            lv_Program.Items[ProgLine].Selected = true;
        }
        private void tsbtn_ProgLineMoveDn_Click(object sender, EventArgs e)
        {
            //btn_Dummy.Focus();

            if (DispProg.LastLine > -1)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION, EMcState.Notice, EMsgBtn.smbOK, false);
                return;
            }

            if (ProgLine == DispProg.Script[SelProg].CmdList.Count) return;
            DispProg.Script[SelProg].MoveDn(ref ProgLine);
            DispProg.Script[SelProg].Validate(ProgLine);

            RefreshProgramList();
            lv_Program.Items[ProgLine].Selected = true;
        }
        private void tsbtn_OffsetAll_Click(object sender, EventArgs e)
        {
            frm_DispCore_EditXY frm = new frm_DispCore_EditXY();
            frm.ParamName = "OfstAll XY";
            double OfstX = 0;
            double OfstY = 0;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Update Offset To All Dispense Pattern?", "Offset All", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return; 

                OfstX = frm.OfstX;
                OfstY = frm.OfstY;
                Log.OnAction("Update", "Offset All", "0,0", OfstX.ToString() + "," + OfstY.ToString());

                //CmdLine.X[0] = CmdLine.X[0] + OfstX;
                //CmdLine.Y[0] = CmdLine.Y[0] + OfstY;

                for (int i = 0; i < DispProg.Script[0].CmdList.Count; i++)
                {
                    switch (DispProg.Script[0].CmdList.Line[i].Cmd)
                    {
                        case DispProg.ECmd.DOT:
                        case DispProg.ECmd.DOT_P:
                        case DispProg.ECmd.MOVE:
                        case DispProg.ECmd.LINE:
                            DispProg.Script[0].CmdList.Line[i].X[0] = DispProg.Script[0].CmdList.Line[i].X[0] + OfstX;
                            DispProg.Script[0].CmdList.Line[i].Y[0] = DispProg.Script[0].CmdList.Line[i].Y[0] + OfstY;
                            break;
                        case DispProg.ECmd.ARC:
                        case DispProg.ECmd.CIRC:
                            DispProg.Script[0].CmdList.Line[i].X[0] = DispProg.Script[0].CmdList.Line[i].X[0] + OfstX;
                            DispProg.Script[0].CmdList.Line[i].Y[0] = DispProg.Script[0].CmdList.Line[i].Y[0] + OfstY;
                            DispProg.Script[0].CmdList.Line[i].X[1] = DispProg.Script[0].CmdList.Line[i].X[1] + OfstX;
                            DispProg.Script[0].CmdList.Line[i].Y[1] = DispProg.Script[0].CmdList.Line[i].Y[1] + OfstY;
                            break;
                        case DispProg.ECmd.DOT_MULTI:
                        case DispProg.ECmd.DOTLINE_MULTI:
                            for (int j = 0; j < DispProg.Script[0].CmdList.Line[i].IPara[5]; j++)
                            {
                                DispProg.Script[0].CmdList.Line[i].X[j] = DispProg.Script[0].CmdList.Line[i].X[j] + OfstX;
                                DispProg.Script[0].CmdList.Line[i].Y[j] = DispProg.Script[0].CmdList.Line[i].Y[j] + OfstY;
                            }
                            break;
                    }
                }
            }
            RefreshProgramList();
            UpdateDisplay();
        }
        #endregion

        #region Program Execution
        private void tmr_Run_Tick(object sender, EventArgs e)
        {
            tmr_Run.Stop();
            if (taskRun != null && !taskRun.IsCompleted)
            {
                if (!GDefine.InPressureInRange)
                {
                    DispProg.TR_Pause();
                    bCycle = false;
                    this.Enable(true);
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.LOW_AIR_PRESSURE);
                }
            }
            tmr_Run.Start();
        }
        private void tsmi_RunMode_Camera_Click(object sender, EventArgs e)
        {
            DispProg.RunMode = ERunMode.Camera;
            tsddbtn_RunMode.Image = tsmi_RunMode_Camera.Image;
            tsddbtn_RunMode.Text = tsmi_RunMode_Camera.Text;
        }
        private void tsmi_RunMode_Normal_Click(object sender, EventArgs e)
        {
            DispProg.RunMode = ERunMode.Normal;
            tsddbtn_RunMode.Image = tsmi_RunMode_Normal.Image;
            tsddbtn_RunMode.Text = tsmi_RunMode_Normal.Text;
        }
        private void tsmi_RunMode_Dry_Click(object sender, EventArgs e)
        {
            DispProg.RunMode = ERunMode.Dry;
            tsddbtn_RunMode.Image = tsmi_RunMode_Dry.Image;
            tsddbtn_RunMode.Text = tsmi_RunMode_Dry.Text;
        }
        private void tsbtn_Snail_Click(object sender, EventArgs e)
        {
            if (GDefine.OperationSpeed != EOperationSpeed.SlowMo)
                GDefine.OperationSpeed = EOperationSpeed.SlowMo;
            else
            {
                if (DispProg.TR_IsBusy())
                    GDefine.OperationSpeed = EOperationSpeed.Normal;
                else
                    GDefine.OperationSpeed = EOperationSpeed.Safe;
            }
            UpdateDisplay();
        }
        private void tsmi_ForceSingle_Click(object sender, EventArgs e)
        {
            TaskDisp.ForceSingle = true;
            //!TaskDisp.ForceSingle;
            //if (TaskDisp.ForceSingle)
            //    TaskDisp.Head_Operation = TaskDisp.EHeadOperation.Single;
            //else
            //    TaskDisp.Head_Operation = DispProg.Head_Operation;

            TaskDisp.Head_Operation = TaskDisp.EHeadOperation.Single;
            DispProg.rt_PromptedSingleHeadRun = false;
            tsddbtn_ForceSingle.Image = tsmi_ForceSingle.Image;
        }
        private void tsmi_Dual_Click(object sender, EventArgs e)
        {
            TaskDisp.ForceSingle = false;

            TaskDisp.Head_Operation = DispProg.Head_Operation;
            DispProg.rt_PromptedSingleHeadRun = false;
            tsddbtn_ForceSingle.Image = tsmi_Dual.Image;
        }

        bool bCycle = false;
        Task taskRun = null;
        private void TaskRun()
        {
            DispProg.TR_Run();
            frm_Main.b_MonitorLowPressure = false;

            //v5.2.43 Requested by YL approved by David 
            DefineSafety.DoorLock = false;
            if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.Psnt)
                NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.InProcess;

            //v5.2.70 Requested by YL
            if (TaskConv.Pre.rt_StType == TaskConv.EPreStType.Disp1 && TaskConv.Pro.rt_StType == TaskConv.EProStType.Disp2)
            {
                if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.Psnt)
                {
                    NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                    NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.WaitNone;
                }
                if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.Psnt)
                {
                    NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.WaitNone;
                    NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                }
            }
        }

        private void TaskCycleRun()
        {
            while (bCycle)
            {
                if (!DispProg.TR_Run()) bCycle = false;
            }
            frm_Main.b_MonitorLowPressure = false;

            //v5.2.43 Requested by YL approved by David 
            DefineSafety.DoorLock = false;
            if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.Psnt)
                NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.InProcess;

            //v5.2.70 Requested by YL
            if (TaskConv.Pre.rt_StType == TaskConv.EPreStType.Disp1 && TaskConv.Pro.rt_StType == TaskConv.EProStType.Disp2)
            {
                if (NDispWin.TaskConv.Pre.Status == NDispWin.TaskConv.EProcessStatus.Psnt)
                {
                    NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                    NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.WaitNone;
                }
                if (NDispWin.TaskConv.Pro.Status == NDispWin.TaskConv.EProcessStatus.Psnt)
                {
                    NDispWin.TaskConv.Pre.Status = NDispWin.TaskConv.EProcessStatus.WaitNone;
                    NDispWin.TaskConv.Pro.Status = NDispWin.TaskConv.EProcessStatus.InProcess;
                }
            }
        }

        private async void tsbtn_Run_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            if (!TaskGantry.CheckReadyStop()) return;

            if (!TaskDisp.TeachNeedle_Bypass && !TaskDisp.TeachNeedle_Completed)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show(ErrCode.TEACH_NEEDLE_REQUIRED, EMcState.Notice, EMsgBtn.smbOK, false);
                return;
            }

            if (GDefineN.LowPressureValid() && !GDefineN.DI_InPressureInRange)
            {
                GDefine.Status = EStatus.Stop;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.LOW_AIR_PRESSURE);
            }

            if ((TaskConv.Pro.Status == TaskConv.EProcessStatus.InProcess
                || TaskConv.Pro.Status == TaskConv.EProcessStatus.WaitDisp)
                && TaskConv.Pro.UseVac 
                && !TaskConv.Pro.SensVac)
            {
                GDefine.Status = EStatus.Stop;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.CONV_VACUUM_LOW);
            }

            try
            {
                if (DispProg.fPoolVermes)
                {
                    DispProg.fPoolVermes = false;
                    if (!TaskDisp.Vermes3200[0].InRange)
                    {
                        GDefine.Status = EStatus.Stop;
                        Msg MsgBox = new Msg();
                        MsgBox.Show((int)EErrCode.DISPCTRL_TEMPERATURE_OUT_OF_TOLERANCE);
                    }
                }
            }
            catch (Exception ex)
            {
                GDefine.Status = EStatus.Stop;
                Msg MsgBox = new Msg();
                MsgBox.Show(ErrCode.DISPCTRL_ERR, $" {ex.Message}");
            }


            if (!DispProg.Script[0].TaskCheckScript()) return;

            this.Enable(false);
            tsbtn_Stop.Enable(true);
            b_ProgEdit = false; ;

            UpdateDisplay();

            GDefine.InPressureInRange = true;
            frm_Main.b_MonitorLowPressure = true;

            await Task.Run(() => TaskRun());

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                frmCamera.SelectCamera(0);
                frmCamera.Grab();
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                TaskVision.genTLCamera[0].StartGrab();
            }

            this.Enable(true);
        }
        private void tsbtn_Resume_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            if (!DispProg.Script[0].TaskCheckScript()) return;

            if (DispProg.LastLine > 0)
            {
                //tsbtn_Cancel_Click(sender, e);
                DispProg.TR_Cancel();
            }
            DispProg.ResumeMap();

            tsbtn_Run_Click(sender, e);
        }
        private void tsbtn_Cancel_Click(object sender, EventArgs e)
        {
            bCycle = false;

            Msg MsgBox = new Msg();
            EMsgRes res = MsgBox.Show("Cancel will clear all current run state.", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
            switch (res)
            {
                case EMsgRes.smrCancel: return;
                default:
                    break;
            }
            DispProg.TR_Cancel();
            tsbtn_Cancel.Enabled = (DispProg.LastLine > 0);
            UpdateDisplay();
        }
        private void tsbtn_Stop_Click(object sender, EventArgs e)
        {
            bCycle = false;
            DispProg.TR_Pause();
            UpdateDisplay();
        }
        private async void tsbtn_Cycle_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckReadyStop()) return;

            b_ProgEdit = false;
            this.Enable(false);
            tsbtn_Stop.Enable(true);
            bCycle = true;

            GDefine.InPressureInRange = true;
            //Intf.CmdSend("MonitorPressureInRange", 1);
            frm_Main.b_MonitorLowPressure = true;

            await Task.Run(() => TaskCycleRun());

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker2)
            {
                frmCamera.SelectCamera(0);
                frmCamera.Grab();
            }
            if (GDefine.CameraType[0] == GDefine.ECameraType.MVSGenTL)
            {
                TaskVision.frmMVCGenTLCamera.SelectCamera(0);
                TaskVision.genTLCamera[0].StartGrab();
            }

            this.Enable(true);
        }
        #endregion

        #region Function
        ToolStripItem[] tsmi_Items = new ToolStripItem[29];
        ToolStripItem tsmi_Setting = new ToolStripMenuItem();
        private void RefreshFunction()
        {
            InitFunction_tsmi();
            ts_Function.Items.Clear();
            for (int i = 0; i < DispProgUI.Function.Count; i++)
            {
                foreach (ToolStripItem tsi in tsmi_Items)
                {
                    if (tsi == null) continue;

                    if (DispProgUI.Function[i] == Convert.ToInt64(tsi.Tag))
                    {
                        ts_Function.Items.Add(tsi);
                        tsi.Visible = true;
                        break;
                    }
                }
            }
            ts_Function.Items.Add(tsmi_Setting);
        }
        private void SetProp(ref ToolStripItem tsi, string Text, string Name, object Tag, EventHandler E)
        {
            tsi = new ToolStripMenuItem();
            tsi.AutoSize = false;
            tsi.Text = Text;
            tsi.AccessibleDescription = Text;
            //tsi.Image = new Bitmap(Properties.Resources.Sq_30x30);
            //string Folder = Path.GetDirectoryName(Application.ExecutablePath);
            if (!Directory.Exists(GDefine.ResourcesPath))
                try
                {
                    Directory.CreateDirectory(GDefine.ResourcesPath);
                }
                catch { }
            string ImageFile = GDefine.ResourcesPath + "\\Prog\\" + Text + ".bmp";
            if (File.Exists(ImageFile))
                tsi.Image = new Bitmap(ImageFile);
            else
                tsi.Image = new Bitmap(Properties.Resources.Sq_30x30);
            tsi.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            tsi.ImageTransparentColor = Color.White;
            tsi.TextImageRelation = TextImageRelation.ImageAboveText;
            tsi.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsi.Name = Name;
            tsi.Overflow = ToolStripItemOverflow.AsNeeded;
            tsi.Size = new Size(50, 50);
            tsi.Tag = Tag;
            tsi.Click += new EventHandler(E);
        }
        private void InitFunction_tsmi()
        {
            SetProp(ref tsmi_Items[0], "Init", "tsmi_Init", 1, tsbtn_Init_Click);
            SetProp(ref tsmi_Items[1], "LsrOfst", "tsmi_LsrOfst", 4, tsbtn_LsrOfst_Click);
            SetProp(ref tsmi_Items[2], "CamOfst", "tsmi_CamOfst", 5, tsbtn_CamOfst_Click);
            SetProp(ref tsmi_Items[3], "NdleOfst", "tsmi_NdleOfst", 6, tsbtn_NdleOfst_Click);

            SetProp(ref tsmi_Items[4], "PMaint", "tsmi_PMaint", 10, tsbtn_PMaint_Click);
            SetProp(ref tsmi_Items[5], "MMaint", "tsmi_MMaint", 11, tsbtn_MMaint_Click);

            SetProp(ref tsmi_Items[6], "Clean", "Clean", 15, tsbtn_Clean_Click);
            SetProp(ref tsmi_Items[7], "Purge", "Purge", 16, tsbtn_Purge_Click);

            SetProp(ref tsmi_Items[8], "PurgeStage", "PurgeStage", 18, tsbtn_PurgeStage_Click);

            SetProp(ref tsmi_Items[9], "WipeA", "tsmi_WipeA", (int)DispProgUI.EFunction.WipeA, tsbtn_WipeA_Click);
            SetProp(ref tsmi_Items[10], "WipeB", "tsmi_WipeB", (int)DispProgUI.EFunction.WipeB, tsbtn_WipeB_Click);

            SetProp(ref tsmi_Items[11], "TrigA", "TrigB", 20, tsbtn_TrigA_Click);
            SetProp(ref tsmi_Items[12], "TrigB", "TrigB", 21, tsbtn_TrigB_Click);
            SetProp(ref tsmi_Items[13], "ChuckVac", "ChuckVac", 25, tsbtn_ChuckVac_Click);
            SetProp(ref tsmi_Items[14], "CleanVac", "CleanVac", 26, tsbtn_CleanVac_Click);

            SetProp(ref tsmi_Items[15], "Map", "Map", 30, tsbtn_Map_Click);
            SetProp(ref tsmi_Items[16], "Ctrl1", "Ctrl1", 35, tsbtn_Ctrl1_Click);
            SetProp(ref tsmi_Items[17], "Ctrl2", "Ctrl2", 36, tsbtn_Ctrl2_Click);

            SetProp(ref tsmi_Items[18], "PPFill", "PPFill", 40, tsbtn_PPFill_Click);
            SetProp(ref tsmi_Items[19], "PPDFill", "PPDFill", 41, tsbtn_PPDFill_Click);

            SetProp(ref tsmi_Items[20], "PumpAdj", "PumpAdj", (int)DispProgUI.EFunction.PumpAdj, tsbtn_PumpAdj_Click);
            SetProp(ref tsmi_Items[21], "DrawOfst", "DrawOfst", (int)DispProgUI.EFunction.DrawOfst, tsbtn_DrawOfst_Click);

            SetProp(ref tsmi_Items[22], "ULoadPre", "ULoadPre", (int)DispProgUI.EFunction.ULoadPre, tsbtn_ULoadPre_Click);
            SetProp(ref tsmi_Items[23], "LoadPro", "LoadPro", (int)DispProgUI.EFunction.LoadPro, tsbtn_LoadPro_Click);

            SetProp(ref tsmi_Items[24], "Return", "tsmi_MHS_Return", (int)DispProgUI.EFunction.MHS_Return, tsbtn_MHS_Return_Click);
            SetProp(ref tsmi_Items[25], "LoadPre", "tsmi_MHS_LoadPre", (int)DispProgUI.EFunction.MHS_LoadPre, tsbtn_MHS_LoadPre_Click);
            SetProp(ref tsmi_Items[26], "LoadPro", "tsmi_MHS_LoadPro", (int)DispProgUI.EFunction.MHS_LoadPro, tsbtn_MHS_LoadPro_Click);
            SetProp(ref tsmi_Items[27], "LoadFwd", "tsmi_MHS_LoadFwd", (int)DispProgUI.EFunction.MHS_LoadFwd, tsbtn_MHS_LoadFwd_Click);
            SetProp(ref tsmi_Items[28], "Unload", "tsmi_MHS_Unload", (int)DispProgUI.EFunction.MHS_Unload, tsbtn_MHS_Unload_Click);

            SetProp(ref tsmi_Setting, "Setting", "Setting", 0, tsmi_CommandSelect_Click);
            tsmi_Setting.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsmi_Setting.Overflow = ToolStripItemOverflow.Always;
        }

        private void tsmi_CommandSelect_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispProg_UISetting frm = new frm_DispCore_DispProg_UISetting();
            frm.ShowDialog();
            RefreshFunction();
            DispProgUI.Save();
        }

        private async void tsbtn_Init_Click(object sender, EventArgs e)
        {
            FormDisable();

            frm_ProgressReport frm1 = new frm_ProgressReport();
            frm1.Message = "Homing in Progress. Please wait...";
            frm1.ShowButtons = false;
            frm1.Show();

            try
            {
                await Task.Run(() => TaskGantry.Home());
            }
            finally
            {
                frm1.Close();
                FormEnable();
            }


            UpdateDisplay();
        }
        private void tsbtn_LsrOfst_Click(object sender, EventArgs e)
        {
            FormDisable();
            TaskDisp.TaskMoveLaserOffset();
            FormEnable();
        }
        private void tsbtn_CamOfst_Click(object sender, EventArgs e)
        {
            FormDisable();
            TaskDisp.TaskToggleCamOffset();
            FormEnable();
        }
        private void tsbtn_NdleOfst_Click(object sender, EventArgs e)
        {
            FormDisable();
            TaskDisp.TaskMoveNeedleOffset();
            FormEnable();
        }
        private void tsbtn_PMaint_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            FormDisable();
            TaskDisp.TaskGotoPMaint();
            FormEnable();

            DefineSafety.DoorLock = false;
        }
        private void tsbtn_MMaint_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            FormDisable();
            TaskDisp.TaskGotoMMaint();
            FormEnable();

            DefineSafety.DoorLock = false;
        }
        private void tsbtn_Clean_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            FormDisable();

            try
            {
                TaskDisp.TaskCleanNeedle(true);
            }
            finally
            {
                TaskDisp.FPressOff();
                FormEnable();
                DefineSafety.DoorLock = false;
            }
        }
        private void tsbtn_Purge_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            FormDisable();
            try
            {
                TaskDisp.TaskPurgeNeedle(true);
            }
            finally
            {
                TaskDisp.FPressOff();
                FormEnable();
                DefineSafety.DoorLock = false;
            }
        }
        private async void tsbtn_WipeA_Click(object sender, EventArgs e)
        {
            FormDisable();
            try
            {
                await Task.Run(() =>
                TaskDisp.WipeStage.Execute(true, false)
                );
            }
            finally
            {
                FormEnable();
            }
        }
        private async void tsbtn_WipeB_Click(object sender, EventArgs e)
        {
            FormDisable();
            try
            {
                await Task.Run(() =>
                TaskDisp.WipeStage.Execute(false, true)
                );
            }
            finally
            {
                FormEnable();
            }
        }
        private async void tsbtn_PurgeStage_Click(object sender, EventArgs e)
        {
            FormDisable();
            try
            {
                await Task.Run(() =>
                TaskDisp.PurgeStage.Execute(DispProg.PurgeStage.Count)
                );
            }
            finally
            {
                frm1.Close();
                FormEnable();
            }
        }
        private void tsbtn_TrigA_Click(object sender, EventArgs e)
        {
            if (TaskGantry.DispATrigSet(TaskGantry.TOutputState.St))
                TaskGantry.DispATrigSet(TaskGantry.TOutputState.Off);
            else
                TaskGantry.DispATrigSet(TaskGantry.TOutputState.On);
        }
        private void tsbtn_TrigB_Click(object sender, EventArgs e)
        {
            if (TaskGantry.DispBTrigSet(TaskGantry.TOutputState.St))
                TaskGantry.DispBTrigSet(TaskGantry.TOutputState.Off);
            else
                TaskGantry.DispBTrigSet(TaskGantry.TOutputState.On);
        }
        private void tsbtn_ChuckVac_Click(object sender, EventArgs e)
        {
            TaskGantry.ChuckVac = !TaskGantry.ChuckVac;
            if (TaskGantry.ChuckVac)
            {
                Thread.Sleep(250);
                if (!TaskGantry.CheckSensChuckVacOn()) TaskGantry.ChuckVac = false;
            }
        }
        private void tsbtn_CleanVac_Click(object sender, EventArgs e)
        {
            TaskGantry.SvCleanVac = !TaskGantry.SvCleanVac;
        }
        private void tsbtn_Map_Click(object sender, EventArgs e)
        {
            if (frmMap.IsDisposed)
            {
                frmMap.Close();
                frmMap = new frm_DispCore_Map();
            }

            NUtils.RegistryWR Reg = new NUtils.RegistryWR();
            Rectangle rect = Reg.ReadKey(GDefine.RegSubKey_DispProg, "MapWind", new Rectangle(0, 0, 640, 480));
            if (rect.Left < 0) rect.X = 0;
            if (rect.Top < 0) rect.Y = 0;
            if (rect.Left >= this.Bounds.Width - 100) rect.X = 0;
            if (rect.Top >= this.Bounds.Height - 100) rect.Y = 0;
            frmMap.Bounds = rect;

            if (frmMap.Left == 0)
                frmMap.StartPosition = FormStartPosition.CenterScreen;
            else
                frmMap.StartPosition = FormStartPosition.Manual;

            frmMap.AllowHide = true;
            frmMap.Visible = true;
            frmMap.BringToFront();
            frmMap.TopMost = true;
        }
        private void tsbtn_Ctrl1_Click(object sender, EventArgs e)
        {
            TaskDisp.ShowDispCtrl(0);
        }
        private void tsbtn_Ctrl2_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.DispCtrlOpened(1)) return;
            TaskDisp.ShowDispCtrl(1);
        }
        private void tsbtn_PPFill_Click(object sender, EventArgs e)
        {
            TaskDisp.DoFill();
        }
        private void tsbtn_PPDFill_Click(object sender, EventArgs e)
        {
            //TaskDisp.DoFill();
        }

        frm_Setup_PJ frmPJ = new frm_Setup_PJ();
        frm_Setup_SP frmSP = new frm_Setup_SP();
        private void tsbtn_PumpAdj_Click(object sender, EventArgs e)
        {
            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.PP:
                case TaskDisp.EPumpType.PP2D:
                case TaskDisp.EPumpType.PPD:
                    {
                        frm_DispTool_VolumeAdjust frm = new frm_DispTool_VolumeAdjust();
                        frm.AdjustUnit = frm_DispTool_VolumeAdjust.EAdjustUnit.ul;
                        frm.SettingMode = true;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        break;
                    }
                case TaskDisp.EPumpType.HM:
                    {
                        frm_DispTool_SpeedAdjust frm = new frm_DispTool_SpeedAdjust();
                        frm.SettingMode = true;
                        frm.TopMost = true;
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
                        //frmSP.SettingMode = true;
                        frmSP.Visible = true;
                        frmSP.BringToFront();
                        frmSP.TopMost = true;
                        break;
                    }
            }
        }
        private void tsbtn_DrawOfst_Click(object sender, EventArgs e)
        {
            frm_DispCore_DrawOfstAdjust frm_OriginAdjust = new frm_DispCore_DrawOfstAdjust();
            frm_OriginAdjust.TopLevel = false;
            frm_OriginAdjust.Parent = this;
            frm_OriginAdjust.BringToFront();
            frm_OriginAdjust.Show();
        }
        private void tsbtn_ULoadPre_Click(object sender, EventArgs e)
        {
            if (DispProg.LastLine >= 0)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("Dispense not complete. End Dispense and Unload to Pre?", "", "", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                if (MsgRes == EMsgRes.smrCancel) return;
            }
            DispProg.TR_Cancel();

            //Intf.CmdSend("Cmd_ULoadPre", 0);
            TaskConv.Manual_Return();
        }
        private void tsbtn_LoadPro_Click(object sender, EventArgs e)
        {
            DispProg.TR_Cancel();
            //Intf.CmdSend("Cmd_LoadPro", 0);
            TaskConv.Manual_LoadPro();
        }
        private void tsbtn_MHS_Return_Click(object sender, EventArgs e)
        {
            if (DispProg.LastLine >= 0)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("Dispense not complete. End Dispense and Return board?", "", "", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                if (MsgRes == EMsgRes.smrCancel) return;
            }
            DispProg.TR_Cancel();

            //Intf.CmdSend("MHS_Cmd_Return", 0);
            TaskConv.Manual_Return();
        }
        private void tsbtn_MHS_LoadPre_Click(object sender, EventArgs e)
        {
            DispProg.TR_Cancel();
            //Intf.CmdSend("MHS_Cmd_LoadPre", 0);
            TaskConv.Manual_LoadPre();
        }
        private void tsbtn_MHS_LoadPro_Click(object sender, EventArgs e)
        {
            DispProg.TR_Cancel();
            //Intf.CmdSend("MHS_Cmd_LoadPro", 0);
            TaskConv.Manual_LoadPro();
        }
        private void tsbtn_MHS_LoadFwd_Click(object sender, EventArgs e)
        {
            if (DispProg.LastLine >= 0)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("Dispense not complete. End Dispense and Load Forward board?", "", "", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                if (MsgRes == EMsgRes.smrCancel) return;
            }
            DispProg.TR_Cancel();

            //Intf.CmdSend("MHS_Cmd_LoadFwd", 0);
            TaskConv.Manual_LoadForward();
        }
        private void tsbtn_MHS_Unload_Click(object sender, EventArgs e)
        {
            if (DispProg.LastLine >= 0)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("Dispense not complete. End Dispense and Unload board?", "", "", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);
                if (MsgRes == EMsgRes.smrCancel) return;
            }
            DispProg.TR_Cancel();

            //Intf.CmdSend("MHS_Cmd_Unload", 0);
            TaskConv.Manual_Unload();
        }
        #endregion

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (Modal)
                Close();
            else
            {
                InitFunction_tsmi();
                if (!DispProg.Script[0].TaskCheckScript()) return;
                Visible = false;
                DispProg.SetupMode = false;
            }
        }

        private void tmr15s_Tick(object sender, EventArgs e)
        {
            Task.Run(() => { Task_InputMap.OsramEMos.PurgeETVFiles(); });
        }
    }
}
 