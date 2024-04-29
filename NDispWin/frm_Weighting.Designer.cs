namespace WGH_Series
{
    partial class frm_Weighing
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
            this.btn_Connect = new System.Windows.Forms.Button();
            this.gbox_Port = new System.Windows.Forms.GroupBox();
            this.cbox_WeighingType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.cbox_ComNo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_ReadImme = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Continuous = new System.Windows.Forms.Button();
            this.btn_Taring = new System.Windows.Forms.Button();
            this.btn_ReadStable = new System.Windows.Forms.Button();
            this.lbl_Value = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tmr_Read = new System.Windows.Forms.Timer(this.components);
            this.gbox_Functions = new System.Windows.Forms.GroupBox();
            this.btn_Zero = new System.Windows.Forms.Button();
            this.gbox_Port.SuspendLayout();
            this.gbox_Functions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.AccessibleDescription = "Connect";
            this.btn_Connect.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Connect.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Connect.Location = new System.Drawing.Point(268, 16);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(100, 30);
            this.btn_Connect.TabIndex = 238;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // gbox_Port
            // 
            this.gbox_Port.AutoSize = true;
            this.gbox_Port.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Port.Controls.Add(this.cbox_WeighingType);
            this.gbox_Port.Controls.Add(this.label1);
            this.gbox_Port.Controls.Add(this.btn_Disconnect);
            this.gbox_Port.Controls.Add(this.btn_Connect);
            this.gbox_Port.Controls.Add(this.cbox_ComNo);
            this.gbox_Port.Controls.Add(this.label5);
            this.gbox_Port.Location = new System.Drawing.Point(10, 10);
            this.gbox_Port.Margin = new System.Windows.Forms.Padding(5);
            this.gbox_Port.Name = "gbox_Port";
            this.gbox_Port.Size = new System.Drawing.Size(480, 93);
            this.gbox_Port.TabIndex = 5;
            this.gbox_Port.TabStop = false;
            this.gbox_Port.Text = "Setting";
            // 
            // cbox_WeighingType
            // 
            this.cbox_WeighingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_WeighingType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbox_WeighingType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_WeighingType.ForeColor = System.Drawing.Color.Navy;
            this.cbox_WeighingType.FormattingEnabled = true;
            this.cbox_WeighingType.Items.AddRange(new object[] {
            "JB1603",
            "ALD214"});
            this.cbox_WeighingType.Location = new System.Drawing.Point(112, 19);
            this.cbox_WeighingType.Name = "cbox_WeighingType";
            this.cbox_WeighingType.Size = new System.Drawing.Size(150, 22);
            this.cbox_WeighingType.TabIndex = 241;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 240;
            this.label1.Text = "Weight Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.AccessibleDescription = "Disconnect";
            this.btn_Disconnect.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Disconnect.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Disconnect.Location = new System.Drawing.Point(374, 16);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(100, 30);
            this.btn_Disconnect.TabIndex = 239;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = false;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // cbox_ComNo
            // 
            this.cbox_ComNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ComNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbox_ComNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_ComNo.ForeColor = System.Drawing.Color.Navy;
            this.cbox_ComNo.FormattingEnabled = true;
            this.cbox_ComNo.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12"});
            this.cbox_ComNo.Location = new System.Drawing.Point(112, 50);
            this.cbox_ComNo.Name = "cbox_ComNo";
            this.cbox_ComNo.Size = new System.Drawing.Size(150, 22);
            this.cbox_ComNo.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 88;
            this.label5.Text = "Com No";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_ReadImme
            // 
            this.btn_ReadImme.AccessibleDescription = "";
            this.btn_ReadImme.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ReadImme.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ReadImme.Location = new System.Drawing.Point(112, 21);
            this.btn_ReadImme.Name = "btn_ReadImme";
            this.btn_ReadImme.Size = new System.Drawing.Size(100, 30);
            this.btn_ReadImme.TabIndex = 243;
            this.btn_ReadImme.Text = "Read Imme";
            this.btn_ReadImme.UseVisualStyleBackColor = false;
            this.btn_ReadImme.Click += new System.EventHandler(this.btn_ReadImme_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.AccessibleDescription = "Stop";
            this.btn_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Stop.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Stop.Location = new System.Drawing.Point(112, 75);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(100, 30);
            this.btn_Stop.TabIndex = 242;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Continuous
            // 
            this.btn_Continuous.AccessibleDescription = "Continuous";
            this.btn_Continuous.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Continuous.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Continuous.Location = new System.Drawing.Point(6, 75);
            this.btn_Continuous.Name = "btn_Continuous";
            this.btn_Continuous.Size = new System.Drawing.Size(100, 30);
            this.btn_Continuous.TabIndex = 241;
            this.btn_Continuous.Text = "Continuous";
            this.btn_Continuous.UseVisualStyleBackColor = false;
            this.btn_Continuous.Click += new System.EventHandler(this.btn_Continue_Click);
            // 
            // btn_Taring
            // 
            this.btn_Taring.AccessibleDescription = "Tare";
            this.btn_Taring.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Taring.Location = new System.Drawing.Point(270, 21);
            this.btn_Taring.Name = "btn_Taring";
            this.btn_Taring.Size = new System.Drawing.Size(100, 30);
            this.btn_Taring.TabIndex = 240;
            this.btn_Taring.Text = "Tare";
            this.btn_Taring.UseVisualStyleBackColor = false;
            this.btn_Taring.Click += new System.EventHandler(this.btn_Taring_Click);
            // 
            // btn_ReadStable
            // 
            this.btn_ReadStable.AccessibleDescription = "";
            this.btn_ReadStable.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ReadStable.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ReadStable.Location = new System.Drawing.Point(6, 21);
            this.btn_ReadStable.Name = "btn_ReadStable";
            this.btn_ReadStable.Size = new System.Drawing.Size(100, 30);
            this.btn_ReadStable.TabIndex = 239;
            this.btn_ReadStable.Text = "Read Stable";
            this.btn_ReadStable.UseVisualStyleBackColor = false;
            this.btn_ReadStable.Click += new System.EventHandler(this.btn_ReadStable_Click);
            // 
            // lbl_Value
            // 
            this.lbl_Value.BackColor = System.Drawing.Color.Black;
            this.lbl_Value.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Value.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_Value.Location = new System.Drawing.Point(8, 111);
            this.lbl_Value.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Value.Name = "lbl_Value";
            this.lbl_Value.Size = new System.Drawing.Size(480, 65);
            this.lbl_Value.TabIndex = 127;
            this.lbl_Value.Text = "---";
            this.lbl_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Clsoe";
            this.btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Close.Location = new System.Drawing.Point(388, 309);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 36);
            this.btn_Close.TabIndex = 240;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tmr_Read
            // 
            this.tmr_Read.Enabled = true;
            this.tmr_Read.Interval = 50;
            this.tmr_Read.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gbox_Functions
            // 
            this.gbox_Functions.Controls.Add(this.btn_Zero);
            this.gbox_Functions.Controls.Add(this.btn_ReadImme);
            this.gbox_Functions.Controls.Add(this.btn_Stop);
            this.gbox_Functions.Controls.Add(this.btn_ReadStable);
            this.gbox_Functions.Controls.Add(this.btn_Continuous);
            this.gbox_Functions.Controls.Add(this.btn_Taring);
            this.gbox_Functions.Location = new System.Drawing.Point(8, 182);
            this.gbox_Functions.Margin = new System.Windows.Forms.Padding(5);
            this.gbox_Functions.Name = "gbox_Functions";
            this.gbox_Functions.Size = new System.Drawing.Size(480, 121);
            this.gbox_Functions.TabIndex = 243;
            this.gbox_Functions.TabStop = false;
            this.gbox_Functions.Text = "Functions";
            this.gbox_Functions.Visible = false;
            // 
            // btn_Zero
            // 
            this.btn_Zero.AccessibleDescription = "Zero";
            this.btn_Zero.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Zero.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Zero.Location = new System.Drawing.Point(376, 21);
            this.btn_Zero.Name = "btn_Zero";
            this.btn_Zero.Size = new System.Drawing.Size(100, 30);
            this.btn_Zero.TabIndex = 244;
            this.btn_Zero.Text = "Zero";
            this.btn_Zero.UseVisualStyleBackColor = false;
            this.btn_Zero.Click += new System.EventHandler(this.btn_Zero_Click);
            // 
            // frm_Weighing
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(501, 360);
            this.ControlBox = false;
            this.Controls.Add(this.gbox_Functions);
            this.Controls.Add(this.lbl_Value);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.gbox_Port);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Weighing";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Weight Dialog";
            this.Load += new System.EventHandler(this.frm_Weighing_Load);
            this.gbox_Port.ResumeLayout(false);
            this.gbox_Functions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.GroupBox gbox_Port;
        private System.Windows.Forms.ComboBox cbox_ComNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ComboBox cbox_WeighingType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Value;
        private System.Windows.Forms.Button btn_Continuous;
        private System.Windows.Forms.Button btn_Taring;
        private System.Windows.Forms.Button btn_ReadStable;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_ReadImme;
        private System.Windows.Forms.GroupBox gbox_Functions;
        private System.Windows.Forms.Timer tmr_Read;
        private System.Windows.Forms.Button btn_Zero;
    }
}

