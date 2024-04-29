namespace DispCore
{
    partial class frm_DispCore_DispSetup_VolumeOfst
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
            this.lbl_DataPath = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_VolumeOfstProtocol = new System.Windows.Forms.Label();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_EquipmentID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_LocalPath = new System.Windows.Forms.Label();
            this.lbl_DataPath2 = new System.Windows.Forms.Label();
            this.btn_CheckVolumeOfstDataPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_InputMap_LocalPath = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_InputMap_CheckDataPath = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_InputMap_DataPath = new System.Windows.Forms.Label();
            this.lbl_InputMap_Protocol = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_EditVolumeOfst = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_DataPath
            // 
            this.lbl_DataPath.BackColor = System.Drawing.Color.White;
            this.lbl_DataPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DataPath.Location = new System.Drawing.Point(155, 103);
            this.lbl_DataPath.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_DataPath.Name = "lbl_DataPath";
            this.lbl_DataPath.Size = new System.Drawing.Size(440, 23);
            this.lbl_DataPath.TabIndex = 169;
            this.lbl_DataPath.Text = "-100";
            this.lbl_DataPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_DataPath.Click += new System.EventHandler(this.lbl_DataPath_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Data Path";
            this.label4.Location = new System.Drawing.Point(7, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 23);
            this.label4.TabIndex = 162;
            this.label4.Text = "Data Path";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Data Path2";
            this.label6.Location = new System.Drawing.Point(7, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 23);
            this.label6.TabIndex = 160;
            this.label6.Text = "Data Path2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_VolumeOfstProtocol
            // 
            this.lbl_VolumeOfstProtocol.BackColor = System.Drawing.Color.White;
            this.lbl_VolumeOfstProtocol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_VolumeOfstProtocol.Location = new System.Drawing.Point(155, 22);
            this.lbl_VolumeOfstProtocol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_VolumeOfstProtocol.Name = "lbl_VolumeOfstProtocol";
            this.lbl_VolumeOfstProtocol.Size = new System.Drawing.Size(218, 23);
            this.lbl_VolumeOfstProtocol.TabIndex = 159;
            this.lbl_VolumeOfstProtocol.Text = "-100";
            this.lbl_VolumeOfstProtocol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_VolumeOfstProtocol.Click += new System.EventHandler(this.lbl_Protocol_Click);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Equipment ID";
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 205;
            this.label3.Text = "Equipment ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_EquipmentID
            // 
            this.lbl_EquipmentID.BackColor = System.Drawing.Color.White;
            this.lbl_EquipmentID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_EquipmentID.Location = new System.Drawing.Point(155, 49);
            this.lbl_EquipmentID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_EquipmentID.Name = "lbl_EquipmentID";
            this.lbl_EquipmentID.Size = new System.Drawing.Size(440, 23);
            this.lbl_EquipmentID.TabIndex = 206;
            this.lbl_EquipmentID.Text = "-100";
            this.lbl_EquipmentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_EquipmentID.Click += new System.EventHandler(this.lbl_EquipmentID_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Local Path";
            this.label1.Location = new System.Drawing.Point(7, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 203;
            this.label1.Text = "Local Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LocalPath
            // 
            this.lbl_LocalPath.BackColor = System.Drawing.Color.White;
            this.lbl_LocalPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LocalPath.Location = new System.Drawing.Point(155, 76);
            this.lbl_LocalPath.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_LocalPath.Name = "lbl_LocalPath";
            this.lbl_LocalPath.Size = new System.Drawing.Size(440, 23);
            this.lbl_LocalPath.TabIndex = 204;
            this.lbl_LocalPath.Text = "-100";
            this.lbl_LocalPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_LocalPath.Click += new System.EventHandler(this.lbl_LocalPath_Click);
            // 
            // lbl_DataPath2
            // 
            this.lbl_DataPath2.BackColor = System.Drawing.Color.White;
            this.lbl_DataPath2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DataPath2.Location = new System.Drawing.Point(155, 130);
            this.lbl_DataPath2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_DataPath2.Name = "lbl_DataPath2";
            this.lbl_DataPath2.Size = new System.Drawing.Size(440, 23);
            this.lbl_DataPath2.TabIndex = 199;
            this.lbl_DataPath2.Text = "-100";
            this.lbl_DataPath2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_DataPath2.Click += new System.EventHandler(this.lbl_DataPath2_Click);
            // 
            // btn_CheckVolumeOfstDataPath
            // 
            this.btn_CheckVolumeOfstDataPath.AccessibleDescription = "Check";
            this.btn_CheckVolumeOfstDataPath.Location = new System.Drawing.Point(525, 158);
            this.btn_CheckVolumeOfstDataPath.Name = "btn_CheckVolumeOfstDataPath";
            this.btn_CheckVolumeOfstDataPath.Size = new System.Drawing.Size(70, 30);
            this.btn_CheckVolumeOfstDataPath.TabIndex = 199;
            this.btn_CheckVolumeOfstDataPath.Text = "Check";
            this.btn_CheckVolumeOfstDataPath.UseVisualStyleBackColor = true;
            this.btn_CheckVolumeOfstDataPath.Click += new System.EventHandler(this.btn_CheckDataPath_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Protocol";
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 23);
            this.label2.TabIndex = 202;
            this.label2.Text = "Protocol";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 634);
            this.panel3.TabIndex = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Input Map";
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbl_InputMap_LocalPath);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btn_InputMap_CheckDataPath);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbl_InputMap_DataPath);
            this.groupBox2.Controls.Add(this.lbl_InputMap_Protocol);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(622, 157);
            this.groupBox2.TabIndex = 204;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Map";
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Local Path";
            this.label8.Location = new System.Drawing.Point(7, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 23);
            this.label8.TabIndex = 214;
            this.label8.Text = "Local Path";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_InputMap_LocalPath
            // 
            this.lbl_InputMap_LocalPath.BackColor = System.Drawing.Color.White;
            this.lbl_InputMap_LocalPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_InputMap_LocalPath.Location = new System.Drawing.Point(155, 49);
            this.lbl_InputMap_LocalPath.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_InputMap_LocalPath.Name = "lbl_InputMap_LocalPath";
            this.lbl_InputMap_LocalPath.Size = new System.Drawing.Size(440, 23);
            this.lbl_InputMap_LocalPath.TabIndex = 213;
            this.lbl_InputMap_LocalPath.Text = "-100";
            this.lbl_InputMap_LocalPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_InputMap_LocalPath.Click += new System.EventHandler(this.lbl_InputMap_LocalPath_Click);
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "Data Path";
            this.label11.Location = new System.Drawing.Point(7, 76);
            this.label11.Margin = new System.Windows.Forms.Padding(2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 23);
            this.label11.TabIndex = 211;
            this.label11.Text = "Data Path";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_InputMap_CheckDataPath
            // 
            this.btn_InputMap_CheckDataPath.AccessibleDescription = "Check";
            this.btn_InputMap_CheckDataPath.Location = new System.Drawing.Point(525, 104);
            this.btn_InputMap_CheckDataPath.Name = "btn_InputMap_CheckDataPath";
            this.btn_InputMap_CheckDataPath.Size = new System.Drawing.Size(70, 30);
            this.btn_InputMap_CheckDataPath.TabIndex = 210;
            this.btn_InputMap_CheckDataPath.Text = "Check";
            this.btn_InputMap_CheckDataPath.UseVisualStyleBackColor = true;
            this.btn_InputMap_CheckDataPath.Click += new System.EventHandler(this.btn_InputMap_CheckDataPath_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Protocol";
            this.label7.Location = new System.Drawing.Point(7, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 23);
            this.label7.TabIndex = 206;
            this.label7.Text = "Protocol";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_InputMap_DataPath
            // 
            this.lbl_InputMap_DataPath.BackColor = System.Drawing.Color.White;
            this.lbl_InputMap_DataPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_InputMap_DataPath.Location = new System.Drawing.Point(155, 76);
            this.lbl_InputMap_DataPath.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_InputMap_DataPath.Name = "lbl_InputMap_DataPath";
            this.lbl_InputMap_DataPath.Size = new System.Drawing.Size(440, 23);
            this.lbl_InputMap_DataPath.TabIndex = 209;
            this.lbl_InputMap_DataPath.Text = "-100";
            this.lbl_InputMap_DataPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_InputMap_DataPath.Click += new System.EventHandler(this.lbl_InputMap_DataPath_Click);
            // 
            // lbl_InputMap_Protocol
            // 
            this.lbl_InputMap_Protocol.BackColor = System.Drawing.Color.White;
            this.lbl_InputMap_Protocol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_InputMap_Protocol.Location = new System.Drawing.Point(155, 22);
            this.lbl_InputMap_Protocol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_InputMap_Protocol.Name = "lbl_InputMap_Protocol";
            this.lbl_InputMap_Protocol.Size = new System.Drawing.Size(218, 23);
            this.lbl_InputMap_Protocol.TabIndex = 205;
            this.lbl_InputMap_Protocol.Text = "-100";
            this.lbl_InputMap_Protocol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_InputMap_Protocol.Click += new System.EventHandler(this.lbl_InputMap_Protocol_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Volume Offset";
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbl_EquipmentID);
            this.groupBox1.Controls.Add(this.btn_EditVolumeOfst);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_LocalPath);
            this.groupBox1.Controls.Add(this.lbl_VolumeOfstProtocol);
            this.groupBox1.Controls.Add(this.lbl_DataPath2);
            this.groupBox1.Controls.Add(this.lbl_DataPath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btn_CheckVolumeOfstDataPath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(622, 211);
            this.groupBox1.TabIndex = 203;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volume Offset";
            // 
            // btn_EditVolumeOfst
            // 
            this.btn_EditVolumeOfst.Location = new System.Drawing.Point(378, 23);
            this.btn_EditVolumeOfst.Name = "btn_EditVolumeOfst";
            this.btn_EditVolumeOfst.Size = new System.Drawing.Size(75, 23);
            this.btn_EditVolumeOfst.TabIndex = 203;
            this.btn_EditVolumeOfst.Text = "Edit";
            this.btn_EditVolumeOfst.UseVisualStyleBackColor = true;
            this.btn_EditVolumeOfst.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // frm_DispCore_DispSetup_VolumeOfst
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(630, 640);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DispCore_DispSetup_VolumeOfst";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_DispCore_DispSetup_VolumeOfst";
            this.Load += new System.EventHandler(this.frm_DispCore_DispSetup_HeadCal_Load);
            this.VisibleChanged += new System.EventHandler(this.frm_DispCore_DispSetup_HeadCal_VisibleChanged);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_VolumeOfstProtocol;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Label lbl_DataPath;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_DataPath2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_CheckVolumeOfstDataPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_LocalPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_EquipmentID;
        private System.Windows.Forms.Button btn_EditVolumeOfst;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_InputMap_DataPath;
        private System.Windows.Forms.Label lbl_InputMap_Protocol;
        private System.Windows.Forms.Button btn_InputMap_CheckDataPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_InputMap_LocalPath;
    }
}