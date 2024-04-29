namespace NDispWin
{
    partial class frm_DispCore_DispSetup_Maint
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblMMaintPosXYZ = new System.Windows.Forms.Label();
            this.btn_SetMMaintPos = new System.Windows.Forms.Button();
            this.btn_GotoMMaintPos = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNMaintPosXYZ = new System.Windows.Forms.Label();
            this.btn_SetPMaintPos = new System.Windows.Forms.Button();
            this.btn_GotoPMaintPos = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btn_PumpActionSetup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTrig = new System.Windows.Forms.Button();
            this.btnExecP2NICam = new System.Windows.Forms.Button();
            this.btnExecP1NICam = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblP2NeedleInspCamPos = new System.Windows.Forms.Label();
            this.btnSetP2NICamPos = new System.Windows.Forms.Button();
            this.btnGotoP2NICamPos = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblP1NeedleInspCamPos = new System.Windows.Forms.Label();
            this.btnSetP1NICamPos = new System.Windows.Forms.Button();
            this.btnGotoP1NICamPos = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.AccessibleDescription = "Machine Maint Pos";
            this.groupBox6.AutoSize = true;
            this.groupBox6.Controls.Add(this.lblMMaintPosXYZ);
            this.groupBox6.Controls.Add(this.btn_SetMMaintPos);
            this.groupBox6.Controls.Add(this.btn_GotoMMaintPos);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Location = new System.Drawing.Point(5, 5);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(590, 75);
            this.groupBox6.TabIndex = 173;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Machine Maint Pos";
            // 
            // lblMMaintPosXYZ
            // 
            this.lblMMaintPosXYZ.BackColor = System.Drawing.SystemColors.Control;
            this.lblMMaintPosXYZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMMaintPosXYZ.Location = new System.Drawing.Point(131, 15);
            this.lblMMaintPosXYZ.Margin = new System.Windows.Forms.Padding(2);
            this.lblMMaintPosXYZ.Name = "lblMMaintPosXYZ";
            this.lblMMaintPosXYZ.Size = new System.Drawing.Size(313, 36);
            this.lblMMaintPosXYZ.TabIndex = 157;
            this.lblMMaintPosXYZ.Text = "-999.999,-999.999,-99.999";
            this.lblMMaintPosXYZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_SetMMaintPos
            // 
            this.btn_SetMMaintPos.AccessibleDescription = "Set";
            this.btn_SetMMaintPos.Location = new System.Drawing.Point(447, 15);
            this.btn_SetMMaintPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetMMaintPos.Name = "btn_SetMMaintPos";
            this.btn_SetMMaintPos.Size = new System.Drawing.Size(59, 36);
            this.btn_SetMMaintPos.TabIndex = 147;
            this.btn_SetMMaintPos.Text = "Set";
            this.btn_SetMMaintPos.UseVisualStyleBackColor = true;
            this.btn_SetMMaintPos.Click += new System.EventHandler(this.btn_SetMMaintPos_Click);
            // 
            // btn_GotoMMaintPos
            // 
            this.btn_GotoMMaintPos.AccessibleDescription = "Goto";
            this.btn_GotoMMaintPos.Location = new System.Drawing.Point(510, 15);
            this.btn_GotoMMaintPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoMMaintPos.Name = "btn_GotoMMaintPos";
            this.btn_GotoMMaintPos.Size = new System.Drawing.Size(75, 36);
            this.btn_GotoMMaintPos.TabIndex = 146;
            this.btn_GotoMMaintPos.Text = "Goto";
            this.btn_GotoMMaintPos.UseVisualStyleBackColor = true;
            this.btn_GotoMMaintPos.Click += new System.EventHandler(this.btn_GotoMMaintPos_Click);
            // 
            // label37
            // 
            this.label37.AccessibleDescription = "XYZ (mm)";
            this.label37.Location = new System.Drawing.Point(7, 22);
            this.label37.Margin = new System.Windows.Forms.Padding(2);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(120, 23);
            this.label37.TabIndex = 143;
            this.label37.Text = "Position (mm)";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = "Pump Maint Pos";
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.lblNMaintPosXYZ);
            this.groupBox3.Controls.Add(this.btn_SetPMaintPos);
            this.groupBox3.Controls.Add(this.btn_GotoPMaintPos);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(5, 84);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 75);
            this.groupBox3.TabIndex = 174;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pump Maint Pos";
            // 
            // lblNMaintPosXYZ
            // 
            this.lblNMaintPosXYZ.BackColor = System.Drawing.SystemColors.Control;
            this.lblNMaintPosXYZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNMaintPosXYZ.Location = new System.Drawing.Point(131, 15);
            this.lblNMaintPosXYZ.Margin = new System.Windows.Forms.Padding(2);
            this.lblNMaintPosXYZ.Name = "lblNMaintPosXYZ";
            this.lblNMaintPosXYZ.Size = new System.Drawing.Size(313, 36);
            this.lblNMaintPosXYZ.TabIndex = 157;
            this.lblNMaintPosXYZ.Text = "-999.999,-999.999,-99.999";
            this.lblNMaintPosXYZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_SetPMaintPos
            // 
            this.btn_SetPMaintPos.AccessibleDescription = "Set";
            this.btn_SetPMaintPos.Location = new System.Drawing.Point(447, 15);
            this.btn_SetPMaintPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPMaintPos.Name = "btn_SetPMaintPos";
            this.btn_SetPMaintPos.Size = new System.Drawing.Size(59, 36);
            this.btn_SetPMaintPos.TabIndex = 147;
            this.btn_SetPMaintPos.Text = "Set";
            this.btn_SetPMaintPos.UseVisualStyleBackColor = true;
            this.btn_SetPMaintPos.Click += new System.EventHandler(this.btn_SetPMaintPos_Click);
            // 
            // btn_GotoPMaintPos
            // 
            this.btn_GotoPMaintPos.AccessibleDescription = "Goto";
            this.btn_GotoPMaintPos.Location = new System.Drawing.Point(510, 15);
            this.btn_GotoPMaintPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoPMaintPos.Name = "btn_GotoPMaintPos";
            this.btn_GotoPMaintPos.Size = new System.Drawing.Size(75, 36);
            this.btn_GotoPMaintPos.TabIndex = 146;
            this.btn_GotoPMaintPos.Text = "Goto";
            this.btn_GotoPMaintPos.UseVisualStyleBackColor = true;
            this.btn_GotoPMaintPos.Click += new System.EventHandler(this.btn_GotoPMaintPos_Click);
            // 
            // label17
            // 
            this.label17.AccessibleDescription = "XYZ (mm)";
            this.label17.Location = new System.Drawing.Point(7, 22);
            this.label17.Margin = new System.Windows.Forms.Padding(2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 23);
            this.label17.TabIndex = 143;
            this.label17.Text = "XYZ (mm)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_PumpActionSetup
            // 
            this.btn_PumpActionSetup.AccessibleDescription = "Setup";
            this.btn_PumpActionSetup.Location = new System.Drawing.Point(6, 21);
            this.btn_PumpActionSetup.Name = "btn_PumpActionSetup";
            this.btn_PumpActionSetup.Size = new System.Drawing.Size(104, 36);
            this.btn_PumpActionSetup.TabIndex = 175;
            this.btn_PumpActionSetup.Text = "Setup";
            this.btn_PumpActionSetup.UseVisualStyleBackColor = true;
            this.btn_PumpActionSetup.Click += new System.EventHandler(this.btn_PumpActionSetup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Pump Action";
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btn_PumpActionSetup);
            this.groupBox1.Location = new System.Drawing.Point(4, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 82);
            this.groupBox1.TabIndex = 176;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pump Action";
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Needle Insp Camera Pos";
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.btnTrig);
            this.groupBox2.Controls.Add(this.btnExecP2NICam);
            this.groupBox2.Controls.Add(this.btnExecP1NICam);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblP2NeedleInspCamPos);
            this.groupBox2.Controls.Add(this.btnSetP2NICamPos);
            this.groupBox2.Controls.Add(this.btnGotoP2NICamPos);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblP1NeedleInspCamPos);
            this.groupBox2.Controls.Add(this.btnSetP1NICamPos);
            this.groupBox2.Controls.Add(this.btnGotoP1NICamPos);
            this.groupBox2.Location = new System.Drawing.Point(5, 163);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 155);
            this.groupBox2.TabIndex = 178;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Needle Insp Camera Pos";
            // 
            // btnTrig
            // 
            this.btnTrig.AccessibleDescription = "Trig";
            this.btnTrig.Location = new System.Drawing.Point(510, 95);
            this.btnTrig.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrig.Name = "btnTrig";
            this.btnTrig.Size = new System.Drawing.Size(75, 36);
            this.btnTrig.TabIndex = 173;
            this.btnTrig.Text = "Trig";
            this.btnTrig.UseVisualStyleBackColor = true;
            this.btnTrig.Click += new System.EventHandler(this.btnTrig_Click);
            // 
            // btnExecP2NICam
            // 
            this.btnExecP2NICam.AccessibleDescription = "Exec";
            this.btnExecP2NICam.Location = new System.Drawing.Point(510, 55);
            this.btnExecP2NICam.Margin = new System.Windows.Forms.Padding(2);
            this.btnExecP2NICam.Name = "btnExecP2NICam";
            this.btnExecP2NICam.Size = new System.Drawing.Size(75, 36);
            this.btnExecP2NICam.TabIndex = 172;
            this.btnExecP2NICam.Text = "Exec";
            this.btnExecP2NICam.UseVisualStyleBackColor = true;
            this.btnExecP2NICam.Click += new System.EventHandler(this.btnExecP2NICam_Click);
            // 
            // btnExecP1NICam
            // 
            this.btnExecP1NICam.AccessibleDescription = "Exec";
            this.btnExecP1NICam.Location = new System.Drawing.Point(510, 15);
            this.btnExecP1NICam.Margin = new System.Windows.Forms.Padding(2);
            this.btnExecP1NICam.Name = "btnExecP1NICam";
            this.btnExecP1NICam.Size = new System.Drawing.Size(75, 36);
            this.btnExecP1NICam.TabIndex = 171;
            this.btnExecP1NICam.Text = "Exec";
            this.btnExecP1NICam.UseVisualStyleBackColor = true;
            this.btnExecP1NICam.Click += new System.EventHandler(this.btnExecP1NICam_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.Location = new System.Drawing.Point(5, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 23);
            this.label6.TabIndex = 170;
            this.label6.Text = "Pump 2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblP2NeedleInspCamPos
            // 
            this.lblP2NeedleInspCamPos.BackColor = System.Drawing.SystemColors.Control;
            this.lblP2NeedleInspCamPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblP2NeedleInspCamPos.Location = new System.Drawing.Point(131, 55);
            this.lblP2NeedleInspCamPos.Margin = new System.Windows.Forms.Padding(2);
            this.lblP2NeedleInspCamPos.Name = "lblP2NeedleInspCamPos";
            this.lblP2NeedleInspCamPos.Size = new System.Drawing.Size(233, 36);
            this.lblP2NeedleInspCamPos.TabIndex = 169;
            this.lblP2NeedleInspCamPos.Text = "-999.999,-999.999,-99.999";
            this.lblP2NeedleInspCamPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSetP2NICamPos
            // 
            this.btnSetP2NICamPos.AccessibleDescription = "Set";
            this.btnSetP2NICamPos.Location = new System.Drawing.Point(368, 55);
            this.btnSetP2NICamPos.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetP2NICamPos.Name = "btnSetP2NICamPos";
            this.btnSetP2NICamPos.Size = new System.Drawing.Size(59, 36);
            this.btnSetP2NICamPos.TabIndex = 168;
            this.btnSetP2NICamPos.Text = "Set";
            this.btnSetP2NICamPos.UseVisualStyleBackColor = true;
            this.btnSetP2NICamPos.Click += new System.EventHandler(this.btnSetP2NICamPos_Click);
            // 
            // btnGotoP2NICamPos
            // 
            this.btnGotoP2NICamPos.AccessibleDescription = "Goto";
            this.btnGotoP2NICamPos.Location = new System.Drawing.Point(431, 55);
            this.btnGotoP2NICamPos.Margin = new System.Windows.Forms.Padding(2);
            this.btnGotoP2NICamPos.Name = "btnGotoP2NICamPos";
            this.btnGotoP2NICamPos.Size = new System.Drawing.Size(75, 36);
            this.btnGotoP2NICamPos.TabIndex = 167;
            this.btnGotoP2NICamPos.Text = "Goto";
            this.btnGotoP2NICamPos.UseVisualStyleBackColor = true;
            this.btnGotoP2NICamPos.Click += new System.EventHandler(this.btnGotoP2NICamPos_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "";
            this.label8.Location = new System.Drawing.Point(5, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 23);
            this.label8.TabIndex = 166;
            this.label8.Text = "Pump 1";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblP1NeedleInspCamPos
            // 
            this.lblP1NeedleInspCamPos.BackColor = System.Drawing.SystemColors.Control;
            this.lblP1NeedleInspCamPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblP1NeedleInspCamPos.Location = new System.Drawing.Point(131, 15);
            this.lblP1NeedleInspCamPos.Margin = new System.Windows.Forms.Padding(2);
            this.lblP1NeedleInspCamPos.Name = "lblP1NeedleInspCamPos";
            this.lblP1NeedleInspCamPos.Size = new System.Drawing.Size(233, 36);
            this.lblP1NeedleInspCamPos.TabIndex = 157;
            this.lblP1NeedleInspCamPos.Text = "-999.999,-999.999,-99.999";
            this.lblP1NeedleInspCamPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSetP1NICamPos
            // 
            this.btnSetP1NICamPos.AccessibleDescription = "Set";
            this.btnSetP1NICamPos.Location = new System.Drawing.Point(368, 15);
            this.btnSetP1NICamPos.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetP1NICamPos.Name = "btnSetP1NICamPos";
            this.btnSetP1NICamPos.Size = new System.Drawing.Size(59, 36);
            this.btnSetP1NICamPos.TabIndex = 147;
            this.btnSetP1NICamPos.Text = "Set";
            this.btnSetP1NICamPos.UseVisualStyleBackColor = true;
            this.btnSetP1NICamPos.Click += new System.EventHandler(this.btnSetP1NICamPos_Click);
            // 
            // btnGotoP1NICamPos
            // 
            this.btnGotoP1NICamPos.AccessibleDescription = "Goto";
            this.btnGotoP1NICamPos.Location = new System.Drawing.Point(431, 15);
            this.btnGotoP1NICamPos.Margin = new System.Windows.Forms.Padding(2);
            this.btnGotoP1NICamPos.Name = "btnGotoP1NICamPos";
            this.btnGotoP1NICamPos.Size = new System.Drawing.Size(75, 36);
            this.btnGotoP1NICamPos.TabIndex = 146;
            this.btnGotoP1NICamPos.Text = "Goto";
            this.btnGotoP1NICamPos.UseVisualStyleBackColor = true;
            this.btnGotoP1NICamPos.Click += new System.EventHandler(this.btnGotoP1NICamPos_Click);
            // 
            // frm_DispCore_DispSetup_Maint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DispCore_DispSetup_Maint";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_DispCore_DispSetup_Maint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_DispSetup_Maint_FormClosing);
            this.Load += new System.EventHandler(this.frm_DispCore_DispSetup_Maint_Load);
            this.Shown += new System.EventHandler(this.frm_DispCore_DispSetup_Maint_Shown);
            this.VisibleChanged += new System.EventHandler(this.frm_DispCore_DispSetup_Maint_VisibleChanged);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblMMaintPosXYZ;
        private System.Windows.Forms.Button btn_SetMMaintPos;
        private System.Windows.Forms.Button btn_GotoMMaintPos;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblNMaintPosXYZ;
        private System.Windows.Forms.Button btn_SetPMaintPos;
        private System.Windows.Forms.Button btn_GotoPMaintPos;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_PumpActionSetup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblP1NeedleInspCamPos;
        private System.Windows.Forms.Button btnSetP1NICamPos;
        private System.Windows.Forms.Button btnGotoP1NICamPos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblP2NeedleInspCamPos;
        private System.Windows.Forms.Button btnSetP2NICamPos;
        private System.Windows.Forms.Button btnGotoP2NICamPos;
        private System.Windows.Forms.Button btnExecP2NICam;
        private System.Windows.Forms.Button btnExecP1NICam;
        private System.Windows.Forms.Button btnTrig;
    }
}