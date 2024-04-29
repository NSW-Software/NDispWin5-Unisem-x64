namespace DispCore
{
    partial class frm_OsramSCC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_EndLot = new System.Windows.Forms.Button();
            this.tbox_Tx = new System.Windows.Forms.TextBox();
            this.btn_Tx = new System.Windows.Forms.Button();
            this.lbox_Log = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.tbox_Port = new System.Windows.Forms.TextBox();
            this.tbox_IPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.btn_EndLot);
            this.groupBox2.Controls.Add(this.tbox_Tx);
            this.groupBox2.Controls.Add(this.btn_Tx);
            this.groupBox2.Location = new System.Drawing.Point(12, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 87);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tx";
            // 
            // btn_EndLot
            // 
            this.btn_EndLot.Location = new System.Drawing.Point(6, 45);
            this.btn_EndLot.Name = "btn_EndLot";
            this.btn_EndLot.Size = new System.Drawing.Size(75, 23);
            this.btn_EndLot.TabIndex = 4;
            this.btn_EndLot.Text = "End Lot";
            this.btn_EndLot.UseVisualStyleBackColor = true;
            this.btn_EndLot.Click += new System.EventHandler(this.btn_EndLot_Click);
            // 
            // tbox_Tx
            // 
            this.tbox_Tx.Location = new System.Drawing.Point(6, 19);
            this.tbox_Tx.Name = "tbox_Tx";
            this.tbox_Tx.Size = new System.Drawing.Size(457, 20);
            this.tbox_Tx.TabIndex = 3;
            // 
            // btn_Tx
            // 
            this.btn_Tx.Location = new System.Drawing.Point(469, 17);
            this.btn_Tx.Name = "btn_Tx";
            this.btn_Tx.Size = new System.Drawing.Size(75, 23);
            this.btn_Tx.TabIndex = 1;
            this.btn_Tx.Text = "Tx";
            this.btn_Tx.UseVisualStyleBackColor = true;
            this.btn_Tx.Click += new System.EventHandler(this.btn_Tx_Click);
            // 
            // lbox_Log
            // 
            this.lbox_Log.FormattingEnabled = true;
            this.lbox_Log.Location = new System.Drawing.Point(12, 195);
            this.lbox_Log.Name = "lbox_Log";
            this.lbox_Log.Size = new System.Drawing.Size(550, 251);
            this.lbox_Log.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.tbox_Port);
            this.groupBox1.Controls.Add(this.tbox_IPAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 84);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(469, 16);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(166, 17);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // tbox_Port
            // 
            this.tbox_Port.Location = new System.Drawing.Point(70, 45);
            this.tbox_Port.Name = "tbox_Port";
            this.tbox_Port.Size = new System.Drawing.Size(90, 20);
            this.tbox_Port.TabIndex = 3;
            this.tbox_Port.Text = "9000";
            this.tbox_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbox_IPAddress
            // 
            this.tbox_IPAddress.Location = new System.Drawing.Point(70, 19);
            this.tbox_IPAddress.Name = "tbox_IPAddress";
            this.tbox_IPAddress.Size = new System.Drawing.Size(90, 20);
            this.tbox_IPAddress.TabIndex = 2;
            this.tbox_IPAddress.Text = "192.168.0.32";
            this.tbox_IPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // tmr_Display
            // 
            this.tmr_Display.Interval = 1000;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // frm_OsramSCC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(577, 464);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbox_Log);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_OsramSCC";
            this.Text = "frm_OsramSCC";
            this.Load += new System.EventHandler(this.frm_OsramSCC_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_OsramSCC_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbox_Tx;
        private System.Windows.Forms.Button btn_Tx;
        private System.Windows.Forms.ListBox lbox_Log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox tbox_Port;
        private System.Windows.Forms.TextBox tbox_IPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Button btn_EndLot;
    }
}