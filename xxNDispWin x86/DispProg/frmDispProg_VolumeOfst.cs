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
    internal partial class frm_DispCore_DispProg_VolumeOfst : Form
    {
        public DispProg.TLine CmdLine = new DispProg.TLine();
        public int ProgNo = 0;
        public int LineNo = 0;

        public frm_DispCore_DispProg_VolumeOfst()
        {
            InitializeComponent();
            GControl.LogForm(this);

            gbox_PathSetup.Visible = false;
            switch (TaskDisp.VolumeOfst_Protocol)
            {
                case TaskDisp.EVolumeOfstProtocol.AOT_FrontTestCloseLoop:
                case TaskDisp.EVolumeOfstProtocol.AOT_HeightCloseLoop:
                    gbox_PathSetup.Visible = true;
                    break;
            }
        }

        private string CmdName
        {
            get
            {
                return LineNo.ToString("d3") + " " + CmdLine.Cmd.ToString();
            }
        }

        private void frmDispProg_VolumeOfst_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = CmdName;
            CmdLine.Copy(DispProg.Script[ProgNo].CmdList.Line[LineNo]);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_Protocol.Text = TaskDisp.VolumeOfst_Protocol.ToString();

            lbl_Path.Text = TaskDisp.VolumeOfst_DataPath;
            lbl_Path2.Text = TaskDisp.VolumeOfst_DataPath2;
            lbl_Mode.Text = Enum.GetName(typeof(EVolumeOfstMode), CmdLine.IPara[0]);
        }

        private void lbl_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = TaskDisp.VolumeOfst_DataPath;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string Old = TaskDisp.VolumeOfst_DataPath;
                TaskDisp.VolumeOfst_DataPath = fbd.SelectedPath;
                string New = TaskDisp.VolumeOfst_DataPath;
                Log.OnAction("Select", CmdName + "Path", Old, New);
            }

            UpdateDisplay();
        }
        private void lbl_Path2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = TaskDisp.VolumeOfst_DataPath2;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string Old = TaskDisp.VolumeOfst_DataPath;
                TaskDisp.VolumeOfst_DataPath2 = fbd.SelectedPath;
                string New = TaskDisp.VolumeOfst_DataPath2;
                Log.OnAction("Select", CmdName + "Path2", Old, New);
            }

            UpdateDisplay();
        }
        private void lbl_Mode_Click(object sender, EventArgs e)
        {
            if (CmdLine.IPara[0] == 0)
                CmdLine.IPara[0] = 1;
            else
                CmdLine.IPara[0] = 0;

            UpdateDisplay();
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

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            double Ofst1 = 0;
            double Ofst2 = 0;

            try
            {
                if (DispProg.DoVolumeOfst_FileCount() < 0)
                {
                    MessageBox.Show("DataPath not found.");
                    return;
                }

                if (DispProg.DoVolumeOfst_FileCount() == 0) return;

                if (DispProg.DoVolumeOfst(ref Ofst1, ref Ofst2))
                {
                    lbox_Log.Items.Add("Volume Ofst");
                    lbox_Log.Items.Add("Ofst1=" + Ofst1.ToString("f3"));
                    lbox_Log.Items.Add("Ofst2=" + Ofst2.ToString("f3"));
                }

                double headA_Vol = DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj + DispProg.rt_Head1VolumeOfst;
                double headB_Vol = DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj + DispProg.rt_Head2VolumeOfst;
                TaskDisp.SetDispVolume(true, true, headA_Vol, headB_Vol);
            }
            catch (Exception Ex)
            {
                lbox_Log.Items.Add(Ex.Message.ToString());
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            DispProg.ClearVolumeOffset();
            lbox_Log.Items.Add("Clear Volume Offset.");
        }
        private void btn_Purge_Click(object sender, EventArgs e)
        {
            try
            {
                if (DispProg.DoVolumeOfst_FileCount() < 0)
                {
                    MessageBox.Show("DataPath not found.");
                    return;
                }

                if (DispProg.DoVolumeOfst_FileCount() == 0) return;

                DispProg.DoVolumeOfst_Purge();
                
                lbox_Log.Items.Add("Purged files.");
            }
            catch (Exception Ex)
            {
                lbox_Log.Items.Add(Ex.Message.ToString());
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            lbox_Log.Items.Clear();
        }

        private void frm_DispCore_DispProg_VolumeOfst_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_DispProg2.Done = true;
        }

        private void gbox_PathSetup_Enter(object sender, EventArgs e)
        {

        }
    }
}
