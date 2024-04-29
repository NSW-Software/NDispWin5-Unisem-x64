using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDispWin
{
    public partial class uctrl_FPress : UserControl
    {
        public int SelectCh = 0;

        public uctrl_FPress()
        {
            InitializeComponent();
        }

        public void UpdateDisplay()
        {
            lbl_SetFPress.Text = (DispProg.FPress[SelectCh] * 145.038).ToString("f1");
        }

        private void btn_SetFPress_Click(object sender, EventArgs e)
        {
            //DispProg.FPress[SelectCh] = Convert.ToDouble(lbl_SetFPress.Text) / 145.038;
            ////DispProg.FPress[1] = Convert.ToDouble(lbl_SetBPressB.Text) / 145.038;

            //try
            //{
            //    FPressCtrl.SetMPa(DispProg.FPress);
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message.ToString());
            //}
        }

        private void lbl_SetFPress_Click(object sender, EventArgs e)
        {
            //double d = DispProg.FPress[SelectCh] * 145.038;
            //d = Math.Round(d, 3);
            ////GDefine.uc.UserAdjustExecute(ref d, FPressCtrl.MinMPa * 145.038, FPressCtrl.MaxMPa * 145.038);
            //if (UC.AdjustExec("FPress " + (SelectCh + 1).ToString(), ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax))
            //{
            //    DispProg.FPress[SelectCh] = d / 145.038;
            //    UpdateDisplay();

            //    try
            //    {
            //        FPressCtrl.SetPress_MPa(DispProg.FPress);
            //    }
            //    catch (Exception Ex)
            //    {
            //        MessageBox.Show(Ex.Message.ToString());
            //    }
            //}
        }

        private void uctrl_FPress_Load(object sender, EventArgs e)
        {

        }
    }
}
