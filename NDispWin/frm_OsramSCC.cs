using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispCore
{
    public partial class frm_OsramSCC : Form
    {
        public OsramSCC OsramSCC;// = new OsramSCC();
        public string IPAddress = "127.0.0.1";
        public int IPPort = 1118;

        public frm_OsramSCC()
        {
            InitializeComponent();
            tmr_Display.Enabled = true;
        }

        private void frm_OsramSCC_Load(object sender, EventArgs e)
        {
            this.Text = "OSRAM SCC";
            tbox_IPAddress.Text = IPAddress;
            tbox_Port.Text = IPPort.ToString();
        }

        private void UpdateDisplay()
        {
            if (!OsramSCC.Connected)
                btn_Connect.Text = "Connect";
            else
                btn_Connect.Text = "Disconnect";

            //tbox_IPAddress.Text = IPAddress;
            //tbox_Port.Text = IPPort.ToString();
        }

        public void AddLog(string S)
        {
            lbox_Log.Invoke(new EventHandler(delegate
            {
                lbox_Log.Items.Insert(0, DateTime.Now.ToLongTimeString() + " " + S);
                    while (lbox_Log.Items.Count > 10)
                    {
                        lbox_Log.Items.RemoveAt(lbox_Log.Items.Count - 1);
                    }
            }));
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OsramSCC.Connected)
                {
                    OsramSCC.Connect(tbox_IPAddress.Text, Convert.ToInt32(tbox_Port.Text));
                }
                else
                {
                    OsramSCC.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            UpdateDisplay();
            tbox_IPAddress.Text = IPAddress;
            tbox_Port.Text = IPPort.ToString();

        }

        private void btn_Tx_Click(object sender, EventArgs e)
        {
            OsramSCC.Tx(tbox_Tx.Text);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void frm_OsramSCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //this.Hide();
        }

        bool b_IsWaiting = false;
        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (Visible) UpdateDisplay();

            if (!OsramSCC.Connected)
            {
                //if (b_SCC_NewWait)
                //{
                //    AddLog("Waiting for SCC...");
                //    b_SCC_NewWait = false;
                //}
                try
                {
                    if (!b_IsWaiting)
                    {
                        AddLog("Waiting for SCC...");
                        b_IsWaiting = true;
                    }
                    OsramSCC.Connect(IPAddress, IPPort);
                    if (OsramSCC.Connected) b_IsWaiting = false;
                }
                catch
                { }
            }
        }

        private void btn_EndLot_Click(object sender, EventArgs e)
        {
            OsramSCC.SendEndLot();
        }
    }
}
