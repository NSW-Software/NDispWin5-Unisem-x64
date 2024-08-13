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
    public partial class frm_MHS2ConvPara : Form
    {
        private enum TSelectedStation
        {
            Conv,
            Pre,
            Pro,
            Out,
        }
        private TSelectedStation SelectedStation;

        public frm_MHS2ConvPara()
        {
            InitializeComponent();

            combox_PreStType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TaskConv.EPreStType)).Length; i++)
            {
                combox_PreStType.Items.Add(((TaskConv.EPreStType)i).ToString());
            }
            combox_ProStType.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TaskConv.EProStType)).Length; i++)
            {
                combox_ProStType.Items.Add(((TaskConv.EProStType)i).ToString());
            }

            AppLanguage.Func2.WriteLangFile(this);
        }

        private void frm_ConvParam_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            btn_Save.Visible = this.Modal;
            btn_Close.Visible = this.Modal;

            combox_PreStType.SelectedIndex = (int)TaskConv.Pre.StType;
            combox_ProStType.SelectedIndex = (int)TaskConv.Pro.StType;

            UpdateDisplay();
            UpdateDG();
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_BoardID.Text = "Board ID" + ConvIO.BoardID.ToString();
            lbl_BoardID.BackColor = ZEC3002.Ctrl.BoardOpened(ConvIO.BoardID) ? Color.Lime : Color.Red;

            //if (TaskConv.BoardIsOpen) { }
        }

        private void UpdateDisplay()
        {
            //lbl_BoardID.Text = "Board ID" + ConvIO.BoardID.ToString();
            //if (ZEC3002.Ctrl.BoardOpened(ConvIO.BoardID))
            //    lbl_BoardID.BackColor = Color.Lime;
            //else
            //    lbl_BoardID.BackColor = Color.Red;

            //if (!ZEC3002.Ctrl.BoardOpened(ConvIO.BoardID)) { return; }
            cbox_Buffer1.Checked = TaskConv.Buf1.StType == TaskConv.EBufStType.Buffer;
            cbox_Buffer2.Checked = TaskConv.Buf2.StType == TaskConv.EBufStType.Buffer;
        }

        private void UpdateDG()
        {
            btn_Conv.BackColor = SelectedStation == TSelectedStation.Conv ? Color.Gray : this.BackColor;
            btn_PreStation.BackColor = SelectedStation == TSelectedStation.Pre ? Color.Gray : this.BackColor;
            btn_ProStation.BackColor = SelectedStation == TSelectedStation.Pro ? Color.Gray : this.BackColor;
            btn_OutStation.BackColor = SelectedStation == TSelectedStation.Out ? Color.Gray : this.BackColor;

            switch (SelectedStation)
            {
                case TSelectedStation.Conv:
                    dg_Param.RowCount = TaskConv.CONV_PARA_COUNT;
                    for (int i = 0; i < dg_Param.RowCount; i++)
                    {
                        dg_Param.Rows[i].Cells[0].Value = TaskConv.TConvParaStr[i];

                        if (TaskConv.Setup != null)
                        {
                            if (SelectedStation == TSelectedStation.Conv)
                                dg_Param.Rows[i].Cells[1].Value = TaskConv.Setup.ConvPara[i];
                        }
                        else
                        {
                            dg_Param.Rows[i].Cells[1].Value = 0;
                        }

                        string sMin = TaskConv.TConvParaMin[i].ToString();
                        string sMax = TaskConv.TConvParaMax[i].ToString();
                        string sDef = TaskConv.TConvParaDef[i].ToString();
                        dg_Param.Rows[i].Cells[2].Value = "(" + sMin + " ~ " + sMax + " , " + sDef + ")";
                        string S = TaskConv.TConvParaDesc[i];
                        dg_Param.Rows[i].Cells[3].Value = S;
                    }
                    break;
                case TSelectedStation.Pre:
                case TSelectedStation.Pro:
                    dg_Param.RowCount = TaskConv.ST_PARA_COUNT;
                    for (int i = 0; i < dg_Param.RowCount; i++)
                    {
                        dg_Param.Rows[i].Cells[0].Value = TaskConv.TParaStr[i];
                        if (TaskConv.Setup != null)
                        {
                            if (SelectedStation == TSelectedStation.Pre)
                                dg_Param.Rows[i].Cells[1].Value = TaskConv.Setup.Pre[i];
                            if (SelectedStation == TSelectedStation.Pro)
                                dg_Param.Rows[i].Cells[1].Value = TaskConv.Setup.Pro[i];
                        }
                        else
                        {
                            dg_Param.Rows[i].Cells[1].Value = 0;
                        }

                        string sMin = TaskConv.TParaMin[i].ToString();
                        string sMax = TaskConv.TParaMax[i].ToString();
                        string sDef = TaskConv.TParaDef[i].ToString();
                        dg_Param.Rows[i].Cells[2].Value = "(" + sMin + " ~ " + sMax + " , " + sDef + ")";
                        string S = TaskConv.TParaDesc[i];
                        dg_Param.Rows[i].Cells[3].Value = S;// AppLanguage.Func2.GetText(this, "Label", S);
                    }
                    break;
                case TSelectedStation.Out:
                    dg_Param.RowCount = TaskConv.ST_OUT_PARA_COUNT;
                    for (int i = 0; i < dg_Param.RowCount; i++)
                    {
                        dg_Param.Rows[i].Cells[0].Value = TaskConv.TOutParaStr[i];
                        if (TaskConv.Setup != null)
                        {
                            if (SelectedStation == TSelectedStation.Out)
                                dg_Param.Rows[i].Cells[1].Value = TaskConv.Setup.Out[i];
                        }
                        else
                        {
                            dg_Param.Rows[i].Cells[1].Value = 0;
                        }

                        string sMin = TaskConv.TOutParaMin[i].ToString();
                        string sMax = TaskConv.TOutParaMax[i].ToString();
                        string sDef = TaskConv.TOutParaDef[i].ToString();
                        dg_Param.Rows[i].Cells[2].Value = "(" + sMin + " ~ " + sMax + " , " + sDef + ")";
                        string S = TaskConv.TOutParaDesc[i];
                        dg_Param.Rows[i].Cells[3].Value = S;// AppLanguage.Func2.GetText(this, "Label", S);
                    }
                    break;
            }
        }

        private void dg_Param_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbtn_Conv_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Conv;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void rbtn_PreStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Pre;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void rbtn_ProStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Pro;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void rbtn_PosStation_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtn_OutStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Out;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
       }

        private void dg_Param_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //int rIdx = e.RowIndex;
            //int cIdx = e.ColumnIndex;
            //if (dg_Param.CurrentCell.ColumnIndex != 1) { return; }
            //string EditedValue = dg_Param.Rows[rIdx].Cells[cIdx].Value.ToString();

            //switch (SelectedStation)
            //{
            //    case TSelectedStation.Conv:
            //    case TSelectedStation.Conv2:
            //        #region
            //        {
            //            int Min = TaskConv.TConvParaMin[rIdx];
            //            int Max = TaskConv.TConvParaMax[rIdx];

            //            try
            //            {
            //                int Value = Convert.ToInt32(EditedValue);
            //                if (Min > Value || Max < Value) { throw new Exception(""); }

            //                if (SelectedStation == TSelectedStation.Conv)
            //                    TaskConv.Setup.ConvPara[rIdx] = Value;
            //                if (SelectedStation == TSelectedStation.Conv2)
            //                    TaskConv.Setup.Conv2Para[rIdx] = Value;
            //            }
            //            catch
            //            {
            //                Msg MsgBox = new Msg();
            //                MsgBox.Show(ErrCode.CONV_VALUE_OUT_OF_RANGE, EMcState.Error, EMsgBtn.smbOK, false);
            //            }
            //        }
            //        #endregion 
            //        break;
            //    case TSelectedStation.Pre:
            //    case TSelectedStation.Pro:
            //    case TSelectedStation.Pos2:
            //        #region
            //        {
            //            int Min = TaskConv.TParaMin[rIdx];
            //            int Max = TaskConv.TParaMax[rIdx];

            //            try
            //            {
            //                int Value = Convert.ToInt32(EditedValue);
            //                if (Min > Value || Max < Value) { throw new Exception(""); }

            //                if (SelectedStation == TSelectedStation.Pre)
            //                    TaskConv.Setup.Pre[rIdx] = Value;
            //                if (SelectedStation == TSelectedStation.Pro)
            //                    TaskConv.Setup.Pro[rIdx] = Value;
            //                if (SelectedStation == TSelectedStation.Pos2)
            //                    TaskConv.Setup.Pos2[rIdx] = Value;
            //            }
            //            catch
            //            {
            //                Msg MsgBox = new Msg();
            //                MsgBox.Show(ErrCode.CONV_VALUE_OUT_OF_RANGE, EMcState.Error, EMsgBtn.smbOK, false);
            //            }
            //        }
            //        #endregion
            //        break;
            //    case TSelectedStation.Out:
            //    case TSelectedStation.Out2:
            //        #region
            //        {
            //            int Min = TaskConv.TOutParaMin[rIdx];
            //            int Max = TaskConv.TOutParaMax[rIdx];

            //            try
            //            {
            //                int Value = Convert.ToInt32(EditedValue);
            //                if (Min > Value || Max < Value) { throw new Exception(""); }

            //                if (SelectedStation == TSelectedStation.Out)
            //                    TaskConv.Setup.Out[rIdx] = Value;
            //                if (SelectedStation == TSelectedStation.Out2)
            //                    TaskConv.Setup.Out2[rIdx] = Value;
            //            }
            //            catch
            //            {
            //                Msg MsgBox = new Msg();
            //                MsgBox.Show(ErrCode.CONV_VALUE_OUT_OF_RANGE, EMcState.Error, EMsgBtn.smbOK, false);
            //            }
            //        }
            //        #endregion
            //        break;
            //}

            //UpdateDisplay();
            //UpdateDG();
        }
        private void dg_Param_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
        private void dg_Param_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rIdx = e.RowIndex;
            int cIdx = e.ColumnIndex;
            if (dg_Param.CurrentCell.ColumnIndex != 1) { return; };

            dg_Param.Enabled = false;

            switch (SelectedStation)
            {
                case TSelectedStation.Conv:
                    UC.AdjustExec("Conv, " + TaskConv.TConvParaStr[rIdx], ref TaskConv.Setup.ConvPara[rIdx],
                                                   TaskConv.TConvParaMin[rIdx],
                                                   TaskConv.TConvParaMax[rIdx]); break;
                case TSelectedStation.Pre:
                    UC.AdjustExec("Conv, " + TaskConv.TParaStr[rIdx], ref TaskConv.Setup.Pre[rIdx],
                                                  TaskConv.TParaMin[rIdx],
                                                  TaskConv.TParaMax[rIdx]); break;
                case TSelectedStation.Pro:
                    UC.AdjustExec("Conv, " + TaskConv.TParaStr[rIdx], ref TaskConv.Setup.Pro[rIdx],
                                                  TaskConv.TParaMin[rIdx],
                                                  TaskConv.TParaMax[rIdx]); break;
                case TSelectedStation.Out:
                    UC.AdjustExec("Conv, " + TaskConv.TOutParaStr[rIdx], ref TaskConv.Setup.Out[rIdx],
                                                  TaskConv.TOutParaMin[rIdx],
                                                  TaskConv.TOutParaMax[rIdx]); break;
            }

            dg_Param.Enabled = true;
            UpdateDisplay();
            UpdateDG();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TaskConv.SaveRecipe();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void combox_PreStType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //handle invalid mode
            //if (combox_PreStType.SelectedIndex == (int)TaskConv.EPreStType.Disp)
            //{
            //    combox_PreStType.SelectedIndex = 0;
            //}

            TaskConv.Pre.StType = (TaskConv.EPreStType)combox_PreStType.SelectedIndex;
            UpdateDisplay();
        }
        private void combox_ProStType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //handle invalid mode
            if (combox_ProStType.SelectedIndex == (int)TaskConv.EProStType.None)
            {
                combox_ProStType.SelectedIndex = 1;
            }

            TaskConv.Pro.StType = (TaskConv.EProStType)combox_ProStType.SelectedIndex;
        }

        private void cbox_Buf1_Click(object sender, EventArgs e)
        {
            if (TaskConv.Buf1.StType == TaskConv.EBufStType.None)
                TaskConv.Buf1.StType = TaskConv.EBufStType.Buffer;
            else
                TaskConv.Buf1.StType = TaskConv.EBufStType.None;

            TaskConv.Buf1.rt_StType = TaskConv.Buf1.StType;

            UpdateDisplay();
        }

        private void cbox_Buffer2_Click(object sender, EventArgs e)
        {
            if (TaskConv.Buf2.StType == TaskConv.EBufStType.None)
                TaskConv.Buf2.StType = TaskConv.EBufStType.Buffer;
            else
                TaskConv.Buf2.StType = TaskConv.EBufStType.None;

            TaskConv.Buf2.rt_StType = TaskConv.Buf2.StType;

             UpdateDisplay();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_ConvPara_Activated(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void cbox_Conv_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Conv;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void cbox_PreStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Pre;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void cbox_ProStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Pro;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void cbox_OutStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Out;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void btn_Conv_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Conv;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void btn_PreStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Pre;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void btn_ProStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Pro;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }

        private void btn_OutStation_Click(object sender, EventArgs e)
        {
            SelectedStation = TSelectedStation.Out;
            UpdateDisplay();
            UpdateDG();
            dg_Param.Focus();
        }
    }
}
