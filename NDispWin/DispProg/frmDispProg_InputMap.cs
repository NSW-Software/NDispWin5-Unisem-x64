using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace NDispWin
{
    internal partial class frm_DispCore_DispProg_InputMap : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;
        public TPos2 SubOrigin = new TPos2(0, 0);
        TLayout LocalLayout = new TLayout();

        TMap LocalMap = new TMap();

        //Rectangle r_Window = new Rectangle(0, 0, 0, 0);
        Point p_Pos = new Point(0, 0);
        Size s_Size = new Size(0, 0);
        public frm_DispCore_DispProg_InputMap()
        {
            InitializeComponent();
            GControl.LogForm(this);

            if (TaskDisp.InputMap_Protocol != TaskDisp.EInputMapProtocol.Lumileds_EMap)
                tabControl.TabPages.Remove(tpage_Lumileds_SS_Map);
            if (TaskDisp.InputMap_Protocol != TaskDisp.EInputMapProtocol.TD_COB)
                tabControl.TabPages.Remove(tpage_TD_COB);
            if (TaskDisp.Preference != TaskDisp.EPreference.Unisem)
                tabControl.TabPages.Remove(tpUnisemE142);
            if (TaskDisp.InputMap_Protocol != TaskDisp.EInputMapProtocol.OSRAM_eMos)
                tabControl.TabPages.Remove(tpageEMos);

            if (GDefine.CameraType[0] == GDefine.ECameraType.Spinnaker)
            {
                //if (TaskVision.frmGenImageView.Visible)
                //{
                //    p_Pos = TaskVision.frmGenImageView.Location;
                //    s_Size = TaskVision.frmGenImageView.Size;
                //    TaskVision.frmGenImageView.TopMost = false;
                //    TaskVision.frmGenImageView.Left = this.Width;
                //    TaskVision.frmGenImageView.Width = Screen.PrimaryScreen.Bounds.Width - this.Width;
                //}
            }
        }

        private void UpdateDisplay()
        {
            lbl_ReadID.Text = CmdLine.ID.ToString();

            lbl_Protocol.Text = TaskDisp.InputMap_Protocol.ToString();
            if (TaskDisp.Preference == TaskDisp.EPreference.Unisem)
                lbl_Protocol.Text = "";

            cbox_Enabled.Checked = CmdLine.IPara[0] > 0;//TaskDisp.InputMap_Enabled;
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_Layout_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);

            this.Text = CmdName;

            LocalLayout = DispProg.rt_Layouts[DispProg.rt_LayoutID];
            UpdateDisplay();

            pbox_Layout.Size = pnl_Layout.Size;
            UpdateUnitLocation();

            pbox_Layout.Refresh();
       }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DispProg.Script[ProgNo].CmdList.Line[LineNo].Copy(CmdLine);
            //frm_DispProg2.Done = true;
            Log.OnAction("OK", CmdName);
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //frm_DispProg2.Done = true;
            Log.OnAction("Cancel", CmdName);
            Close();
        }

        private void lbl_ReadID_Click(object sender, EventArgs e)
        {
            UC.AdjustExec(CmdName + ", ReadID", ref CmdLine.ID, 0, DispProg.MAX_IDS);
            LocalLayout = new TLayout(CmdLine);
            UpdateDisplay();
        }

        double UPitch = 0;
        double USize = 0;
        int[] UX = new int[TLayout.MAX_UNITS];
        int[] UY = new int[TLayout.MAX_UNITS];
        TPos2[] Pos = new TPos2[TLayout.MAX_UNITS];

        private void GotoUnitNo(int UnitNo)
        {
            double X = (DispProg.Origin(DispProg.rt_StationNo).X + SubOrigin.X) + CmdLine.DPara[0];
            double Y = (DispProg.Origin(DispProg.rt_StationNo).Y + SubOrigin.Y) + CmdLine.DPara[1];


            X = X + Pos[UnitNo].X;
            Y = Y + Pos[UnitNo].Y;

            if (!TaskDisp.TaskMoveGZZ2Up()) return;

            if (!TaskGantry.SetMotionParamGXY()) return;
            if (!TaskGantry.MoveAbsGXY(X, Y)) return;
        }

        private void UpdateUnitLocation()
        {
            LocalLayout.UpdateUnitLocations(pbox_Layout.Width, pbox_Layout.Height, ref UPitch, ref USize, ref UX, ref UY);

            if (Pos[0] == null)
            {
                for (int j = 0; j < TLayout.MAX_UNITS; j++)
                {
                    Pos[j] = new TPos2();
                }
            }
            LocalLayout.ComputePos(ref Pos);
        }
        private void pbox_Layout_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush SBrush = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(SBrush, new Rectangle(0, 0, pbox_Layout.Width - 1, pbox_Layout.Height - 1));

            for (int i = 0; i < LocalLayout.TUCount; i++)
            {
                int X = UX[i];
                int Y = UY[i];

                SBrush = new SolidBrush(this.BackColor);
                Pen Pen = new Pen(Color.Green);
                Pen.Color = Color.Orange;
                if (LocalLayout.UnitNoIsNeedle2(i) && DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                {
                    Pen.Color = Color.Wheat;
                }

                if (TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync)
                {
                    if (LocalLayout.UnitNoIsHead2(i))
                    {
                        Pen.Color = Color.Blue;
                        if (LocalLayout.UnitNoIsNeedle2(i) && DispProg.Pump_Type == TaskDisp.EPumpType.PP2D)
                        {
                            Pen.Color = Color.SkyBlue;
                        }
                    }
                }

                Rectangle R = new Rectangle((int)(X - USize / 2), (int)(Y - USize / 2), (int)USize, (int)USize);

                e.Graphics.FillRectangle(SBrush, R);
                e.Graphics.DrawRectangle(Pen, R);

                if (LocalMap.Bin[i] == EMapBin.InMapNG)
                {
                    Pen.Color = Color.Black;
                    e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)(Y - USize / 2), (int)(X + USize / 2), (int)(Y + USize / 2));
                    e.Graphics.DrawLine(Pen, (int)(X - USize / 2), (int)(Y + USize / 2), (int)(X + USize / 2), (int)(Y - USize / 2));
                }

                int Size = Math.Max(2, (int)(USize / 3));

                Font Font = new Font(FontFamily.GenericSansSerif, Size);
                Brush Brush = new SolidBrush(Color.DimGray);
                e.Graphics.DrawString(i.ToString(), Font, Brush, R);
            }
        }

        private void lbl_Mag1_Click(object sender, EventArgs e)
        {
            pbox_Layout.Size = pnl_Layout.Size; 
            UpdateUnitLocation();

            pbox_Layout.Refresh();
        }

        private void lbl_MagN_Click(object sender, EventArgs e)
        {
            pbox_Layout.Width = Math.Max(pbox_Layout.Width / 2, pnl_Layout.Width);
            pbox_Layout.Height = Math.Max(pbox_Layout.Height / 2, pnl_Layout.Height);

            pnl_Layout.AutoScrollPosition = new Point((pnl_Layout.HorizontalScroll.Maximum - pnl_Layout.HorizontalScroll.LargeChange) / 2,
                (pnl_Layout.VerticalScroll.Maximum - pnl_Layout.VerticalScroll.LargeChange) / 2);
            
            UpdateUnitLocation();

            pbox_Layout.Refresh();
        }

        private void lbl_MagP_Click(object sender, EventArgs e)
        {
            pbox_Layout.Width = pbox_Layout.Width * 2;
            pbox_Layout.Height = pbox_Layout.Height * 2;

            pnl_Layout.AutoScrollPosition = new Point((pnl_Layout.HorizontalScroll.Maximum - pnl_Layout.HorizontalScroll.LargeChange) / 2,
                (pnl_Layout.VerticalScroll.Maximum - pnl_Layout.VerticalScroll.LargeChange) / 2);

            UpdateUnitLocation();

            pbox_Layout.Refresh();
        }

        private void lbl_Center_Click(object sender, EventArgs e)
        {
            pnl_Layout.AutoScrollPosition = new Point((pnl_Layout.HorizontalScroll.Maximum - pnl_Layout.HorizontalScroll.LargeChange) / 2,
                (pnl_Layout.VerticalScroll.Maximum - pnl_Layout.VerticalScroll.LargeChange) / 2);
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            if (cbSingulated.Checked) DispProg.rt_Singulated = true;

            string TestLotNo = tbox_InputMap_LotNo.Text;
            string TestFrameNo = tbox_InputMap_FrameNo.Text;

            try
            {
                switch (TaskDisp.InputMap_Protocol)
                {
                    case TaskDisp.EInputMapProtocol.None:
                        MessageBox.Show("No Input Map Protocol Selected.");
                        break;
                    case TaskDisp.EInputMapProtocol.Lumileds_EMap:
                        if (!DispProg.TInputMap.Execute(TestLotNo, TestFrameNo, ref LocalMap))
                        {
                            MessageBox.Show("Test Fail Frame ID [" + TestFrameNo + "].");
                            return;
                        }
                        pbox_Layout.Refresh();
                        MessageBox.Show("Test Success Frame ID [" + TestFrameNo + "].");
                        break;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }
        }

        private void tbox_InputMap_LotNo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Point mousePosition = tbox_InputMap_LotNo.PointToClient(Control.MousePosition);
                //cms_PopUp.Show(this.Location.X + tbox_InputMap_LotNo.Left + mousePosition.X, this.Location.Y + tbox_InputMap_LotNo.Top + this.Location.Y);
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbox_InputMap_LotNo.Focused)
                tbox_InputMap_LotNo.Text = Clipboard.GetText();
            if (tbox_InputMap_FrameNo.Focused)
                tbox_InputMap_FrameNo.Text = Clipboard.GetText();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbox_InputMap_LotNo.Focused)
                Clipboard.SetText(tbox_InputMap_LotNo.Text);
            if (tbox_InputMap_FrameNo.Focused)
                Clipboard.SetText(tbox_InputMap_FrameNo.Text);
        }

        private void tbox_InputMap_FrameNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_DispCore_DispProg_InputMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (TaskVision.frmGenImageView.Visible)
            //{
            //    TaskVision.frmGenImageView.Location = p_Pos;
            //    TaskVision.frmGenImageView.Size = s_Size;
            //}

            frm_DispProg2.Done = true;
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            try
            {
                DispProg.TInputMap.Execute("", tbox_SubstrateID.Text, ref LocalMap);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
            pbox_Layout.Refresh();
        }
        private void btn_Dispensed_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbox_UnitNo.Text.Length > 0)
                {
                    int iNo = Convert.ToInt32(tbox_UnitNo.Text);
                    Task_InputMap.TD_COB.MapDB_UpdateSerialNo(tbox_SubstrateID.Text, iNo - 1, true);
                }
                else
                Task_InputMap.TD_COB.MapDB_UpdateSubstrate(tbox_SubstrateID.Text, true);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }
            DispProg.TInputMap.Execute("", tbox_SubstrateID.Text, ref LocalMap);
            pbox_Layout.Refresh();
        }
        private void btn_UnDispensed_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbox_UnitNo.Text.Length > 0)
                {
                    int iNo = Convert.ToInt32(tbox_UnitNo.Text);
                    Task_InputMap.TD_COB.MapDB_UpdateSerialNo(tbox_SubstrateID.Text, iNo - 1, false);
                }
                else
                    Task_InputMap.TD_COB.MapDB_UpdateSubstrate(tbox_SubstrateID.Text, false);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }
            DispProg.TInputMap.Execute("", tbox_SubstrateID.Text, ref LocalMap);
            pbox_Layout.Refresh();
        }

        private void cbox_Enabled_Click(object sender, EventArgs e)
        {
            //TaskDisp.InputMap_Enabled = !TaskDisp.InputMap_Enabled;
            CmdLine.IPara[0] = CmdLine.IPara[0] > 0 ? 0 : 1; 
            
            UpdateDisplay();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            this.Enable(false);
            await Task.Run(() =>
            {
                DispProg.TInputMap.Execute("", tbxStripId.Text, ref LocalMap);
            });
            pbox_Layout.Refresh();
            this.Enable(true);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DispProg.rt_Layouts[DispProg.rt_LayoutID].TUCount; i++)
            {
                int iCol = 0;
                int iRow = 0;
                DispProg.rt_Layouts[DispProg.rt_LayoutID].UnitNoGetRC(i, ref iCol, ref iRow);

                try
                {
                    GDefine.sgc2.map[iCol, iRow] = (int)DispProg.Map.CurrMap[DispProg.rt_LayoutID].Bin[i];
                }
                catch
                {
                }
            }
            GDefine.sgc2.UploadXMLString("");
        }

        private void btnEMosTest_Click(object sender, EventArgs e)
        {
            string lotNo = tboxEMosLotNo.Text;
            string frameNo = tboxEMosFrameNo.Text;
            string materialNr = tboxEMosMaterialNr.Text;

            try
            {
                switch (TaskDisp.InputMap_Protocol)
                {
                    case TaskDisp.EInputMapProtocol.None:
                        MessageBox.Show("No Input Map Protocol Selected.");
                        break;
                    case TaskDisp.EInputMapProtocol.OSRAM_eMos:
                        try
                        {
                            if (!DispProg.TInputMap.Execute(lotNo, frameNo, ref LocalMap, true, lotNo, materialNr))
                            {
                                MessageBox.Show("Test Fail Frame ID [" + frameNo + "].");
                                return;
                            }
                            pbox_Layout.Refresh();
                            MessageBox.Show("Test Success Frame ID [" + frameNo + "].");
                            break;
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("Test Fail Frame ID [" + frameNo + "].");
                            return;
                        }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }
        }
    }
}
