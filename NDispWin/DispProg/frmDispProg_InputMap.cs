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
        }

        private void UpdateDisplay()
        {
            lbl_ReadID.Text = CmdLine.ID.ToString();
            lbl_Protocol.Text = "";
            cbox_Enabled.Checked = CmdLine.IPara[0] > 0;
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

        private void frm_DispCore_DispProg_InputMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void cbox_Enabled_Click(object sender, EventArgs e)
        {
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
    }
}
