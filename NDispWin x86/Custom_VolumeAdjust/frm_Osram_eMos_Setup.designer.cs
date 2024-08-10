namespace NDispWin
{
    partial class frm_Osram_eMos_Setup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_TimeOut = new System.Windows.Forms.NumericUpDown();
            this.cbox_Rework = new System.Windows.Forms.CheckBox();
            this.btn_ETVUpdatePath = new System.Windows.Forms.Button();
            this.btn_MapRequestPath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbox_ETVUpdatePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbox_MapRequestPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbox_APAName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_ProcessName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gbox_Test = new System.Windows.Forms.GroupBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_DecodeMap = new System.Windows.Forms.Button();
            this.btn_WriteETV = new System.Windows.Forms.Button();
            this.tbox_MatNo = new System.Windows.Forms.TextBox();
            this.tbox_Operator = new System.Windows.Forms.TextBox();
            this.tbox_Lot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbox_FrameID = new System.Windows.Forms.TextBox();
            this.btn_MapRequest = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TimeOut)).BeginInit();
            this.gbox_Test.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.nud_TimeOut);
            this.groupBox1.Controls.Add(this.cbox_Rework);
            this.groupBox1.Controls.Add(this.btn_ETVUpdatePath);
            this.groupBox1.Controls.Add(this.btn_MapRequestPath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbox_ETVUpdatePath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbox_MapRequestPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbox_APAName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbox_ProcessName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EMos Settings";
            // 
            // nud_TimeOut
            // 
            this.nud_TimeOut.Location = new System.Drawing.Point(184, 219);
            this.nud_TimeOut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_TimeOut.Name = "nud_TimeOut";
            this.nud_TimeOut.Size = new System.Drawing.Size(64, 26);
            this.nud_TimeOut.TabIndex = 20;
            this.nud_TimeOut.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbox_Rework
            // 
            this.cbox_Rework.AutoSize = true;
            this.cbox_Rework.Location = new System.Drawing.Point(9, 255);
            this.cbox_Rework.Name = "cbox_Rework";
            this.cbox_Rework.Size = new System.Drawing.Size(77, 22);
            this.cbox_Rework.TabIndex = 18;
            this.cbox_Rework.Text = "Rework";
            this.cbox_Rework.UseVisualStyleBackColor = true;
            this.cbox_Rework.Click += new System.EventHandler(this.cbox_Rework_Click);
            // 
            // btn_ETVUpdatePath
            // 
            this.btn_ETVUpdatePath.Location = new System.Drawing.Point(362, 179);
            this.btn_ETVUpdatePath.Name = "btn_ETVUpdatePath";
            this.btn_ETVUpdatePath.Size = new System.Drawing.Size(38, 22);
            this.btn_ETVUpdatePath.TabIndex = 12;
            this.btn_ETVUpdatePath.Text = "...";
            this.btn_ETVUpdatePath.UseVisualStyleBackColor = true;
            this.btn_ETVUpdatePath.Click += new System.EventHandler(this.btn_ETVUpdatePath_Click);
            // 
            // btn_MapRequestPath
            // 
            this.btn_MapRequestPath.Location = new System.Drawing.Point(362, 122);
            this.btn_MapRequestPath.Name = "btn_MapRequestPath";
            this.btn_MapRequestPath.Size = new System.Drawing.Size(38, 22);
            this.btn_MapRequestPath.TabIndex = 11;
            this.btn_MapRequestPath.Text = "...";
            this.btn_MapRequestPath.UseVisualStyleBackColor = true;
            this.btn_MapRequestPath.Click += new System.EventHandler(this.btn_MapRequestPath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "File Transfer Timeout (s)";
            // 
            // tbox_ETVUpdatePath
            // 
            this.tbox_ETVUpdatePath.Location = new System.Drawing.Point(6, 180);
            this.tbox_ETVUpdatePath.Name = "tbox_ETVUpdatePath";
            this.tbox_ETVUpdatePath.Size = new System.Drawing.Size(348, 26);
            this.tbox_ETVUpdatePath.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "ETV Update Path";
            // 
            // tbox_MapRequestPath
            // 
            this.tbox_MapRequestPath.Location = new System.Drawing.Point(6, 123);
            this.tbox_MapRequestPath.Name = "tbox_MapRequestPath";
            this.tbox_MapRequestPath.Size = new System.Drawing.Size(348, 26);
            this.tbox_MapRequestPath.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Map Request Path";
            // 
            // tbox_APAName
            // 
            this.tbox_APAName.Location = new System.Drawing.Point(102, 64);
            this.tbox_APAName.Name = "tbox_APAName";
            this.tbox_APAName.Size = new System.Drawing.Size(125, 26);
            this.tbox_APAName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "APA Name";
            // 
            // tbox_ProcessName
            // 
            this.tbox_ProcessName.Location = new System.Drawing.Point(102, 34);
            this.tbox_ProcessName.Name = "tbox_ProcessName";
            this.tbox_ProcessName.Size = new System.Drawing.Size(125, 26);
            this.tbox_ProcessName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Process Name";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(339, 316);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Close";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(258, 316);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 30);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // gbox_Test
            // 
            this.gbox_Test.AutoSize = true;
            this.gbox_Test.Controls.Add(this.lblFilename);
            this.gbox_Test.Controls.Add(this.label10);
            this.gbox_Test.Controls.Add(this.label9);
            this.gbox_Test.Controls.Add(this.label8);
            this.gbox_Test.Controls.Add(this.label7);
            this.gbox_Test.Controls.Add(this.btn_DecodeMap);
            this.gbox_Test.Controls.Add(this.btn_WriteETV);
            this.gbox_Test.Controls.Add(this.tbox_MatNo);
            this.gbox_Test.Controls.Add(this.tbox_Operator);
            this.gbox_Test.Controls.Add(this.tbox_Lot);
            this.gbox_Test.Controls.Add(this.label6);
            this.gbox_Test.Controls.Add(this.tbox_FrameID);
            this.gbox_Test.Controls.Add(this.btn_MapRequest);
            this.gbox_Test.Location = new System.Drawing.Point(8, 352);
            this.gbox_Test.Name = "gbox_Test";
            this.gbox_Test.Size = new System.Drawing.Size(406, 224);
            this.gbox_Test.TabIndex = 3;
            this.gbox_Test.TabStop = false;
            this.gbox_Test.Text = "Test";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(109, 136);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(13, 18);
            this.lblFilename.TabIndex = 17;
            this.lblFilename.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 18);
            this.label10.TabIndex = 16;
            this.label10.Text = "FileName";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 18);
            this.label9.TabIndex = 14;
            this.label9.Text = "Operator";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Lot";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Material Nr";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btn_DecodeMap
            // 
            this.btn_DecodeMap.Location = new System.Drawing.Point(121, 169);
            this.btn_DecodeMap.Name = "btn_DecodeMap";
            this.btn_DecodeMap.Size = new System.Drawing.Size(106, 30);
            this.btn_DecodeMap.TabIndex = 6;
            this.btn_DecodeMap.Text = "Decode Map";
            this.btn_DecodeMap.UseVisualStyleBackColor = true;
            this.btn_DecodeMap.Click += new System.EventHandler(this.btn_DecodeMap_Click);
            // 
            // btn_WriteETV
            // 
            this.btn_WriteETV.Location = new System.Drawing.Point(233, 169);
            this.btn_WriteETV.Name = "btn_WriteETV";
            this.btn_WriteETV.Size = new System.Drawing.Size(106, 30);
            this.btn_WriteETV.TabIndex = 7;
            this.btn_WriteETV.Text = "Write ETV File";
            this.btn_WriteETV.UseVisualStyleBackColor = true;
            this.btn_WriteETV.Click += new System.EventHandler(this.btn_WriteETV_Click);
            // 
            // tbox_MatNo
            // 
            this.tbox_MatNo.Location = new System.Drawing.Point(112, 102);
            this.tbox_MatNo.Name = "tbox_MatNo";
            this.tbox_MatNo.Size = new System.Drawing.Size(176, 26);
            this.tbox_MatNo.TabIndex = 11;
            this.tbox_MatNo.TextChanged += new System.EventHandler(this.tbox_MapID_TextChanged);
            // 
            // tbox_Operator
            // 
            this.tbox_Operator.Location = new System.Drawing.Point(112, 75);
            this.tbox_Operator.Name = "tbox_Operator";
            this.tbox_Operator.Size = new System.Drawing.Size(176, 26);
            this.tbox_Operator.TabIndex = 10;
            // 
            // tbox_Lot
            // 
            this.tbox_Lot.Location = new System.Drawing.Point(112, 48);
            this.tbox_Lot.Name = "tbox_Lot";
            this.tbox_Lot.Size = new System.Drawing.Size(176, 26);
            this.tbox_Lot.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "FrameID";
            // 
            // tbox_FrameID
            // 
            this.tbox_FrameID.Location = new System.Drawing.Point(112, 21);
            this.tbox_FrameID.Name = "tbox_FrameID";
            this.tbox_FrameID.Size = new System.Drawing.Size(176, 26);
            this.tbox_FrameID.TabIndex = 5;
            this.tbox_FrameID.TextChanged += new System.EventHandler(this.tbox_MapID_TextChanged);
            // 
            // btn_MapRequest
            // 
            this.btn_MapRequest.Location = new System.Drawing.Point(9, 169);
            this.btn_MapRequest.Name = "btn_MapRequest";
            this.btn_MapRequest.Size = new System.Drawing.Size(106, 30);
            this.btn_MapRequest.TabIndex = 0;
            this.btn_MapRequest.Text = "Map Request";
            this.btn_MapRequest.UseVisualStyleBackColor = true;
            this.btn_MapRequest.Click += new System.EventHandler(this.btn_MapRequest_ClickAsync);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(177, 316);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 30);
            this.btn_Update.TabIndex = 4;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // frm_Osram_eMos_Setup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(428, 598);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.gbox_Test);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Osram_eMos_Setup";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_Osram_eMos_Setup";
            this.Load += new System.EventHandler(this.frm_Osram_eMos_Setup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TimeOut)).EndInit();
            this.gbox_Test.ResumeLayout(false);
            this.gbox_Test.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ETVUpdatePath;
        private System.Windows.Forms.Button btn_MapRequestPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbox_ETVUpdatePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbox_MapRequestPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbox_APAName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_ProcessName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.CheckBox cbox_Rework;
        private System.Windows.Forms.NumericUpDown nud_TimeOut;
        private System.Windows.Forms.GroupBox gbox_Test;
        private System.Windows.Forms.Button btn_WriteETV;
        private System.Windows.Forms.Button btn_DecodeMap;
        private System.Windows.Forms.TextBox tbox_FrameID;
        private System.Windows.Forms.Button btn_MapRequest;
        private System.Windows.Forms.TextBox tbox_Lot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbox_MatNo;
        private System.Windows.Forms.TextBox tbox_Operator;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label label10;
    }
}