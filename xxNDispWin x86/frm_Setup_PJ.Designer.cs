namespace NDispWin
{
    partial class frm_Setup_PJ
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
            this.lbl_FPressA = new System.Windows.Forms.Label();
            this.lbl_PressUnit = new System.Windows.Forms.Label();
            this.btn_POpen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_BPress = new System.Windows.Forms.Button();
            this.lbl_OpenTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_CloseDelay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Shot = new System.Windows.Forms.Button();
            this.lbl_PulseCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Frequency = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_FPressA
            // 
            this.lbl_FPressA.BackColor = System.Drawing.Color.White;
            this.lbl_FPressA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressA.Location = new System.Drawing.Point(180, 58);
            this.lbl_FPressA.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressA.Name = "lbl_FPressA";
            this.lbl_FPressA.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPressA.TabIndex = 63;
            this.lbl_FPressA.Text = "000.001";
            this.lbl_FPressA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressA.Click += new System.EventHandler(this.lbl_FPressA_Click);
            // 
            // lbl_PressUnit
            // 
            this.lbl_PressUnit.AccessibleDescription = "";
            this.lbl_PressUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_PressUnit.Location = new System.Drawing.Point(124, 58);
            this.lbl_PressUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PressUnit.Name = "lbl_PressUnit";
            this.lbl_PressUnit.Size = new System.Drawing.Size(50, 30);
            this.lbl_PressUnit.TabIndex = 65;
            this.lbl_PressUnit.Text = "(psi)";
            this.lbl_PressUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_POpen
            // 
            this.btn_POpen.AccessibleDescription = "P  Open";
            this.btn_POpen.Location = new System.Drawing.Point(246, 99);
            this.btn_POpen.Name = "btn_POpen";
            this.btn_POpen.Size = new System.Drawing.Size(75, 30);
            this.btn_POpen.TabIndex = 62;
            this.btn_POpen.Text = "P Open";
            this.btn_POpen.UseVisualStyleBackColor = true;
            this.btn_POpen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_POpen_MouseClick);
            this.btn_POpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_POpen_MouseDown);
            this.btn_POpen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_POpen_MouseUp);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "F Pressure";
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(8, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 30);
            this.label6.TabIndex = 64;
            this.label6.Text = "F Pressure";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_BPress
            // 
            this.btn_BPress.AccessibleDescription = "B Press";
            this.btn_BPress.Location = new System.Drawing.Point(246, 58);
            this.btn_BPress.Name = "btn_BPress";
            this.btn_BPress.Size = new System.Drawing.Size(75, 30);
            this.btn_BPress.TabIndex = 61;
            this.btn_BPress.Text = "B Press";
            this.btn_BPress.UseVisualStyleBackColor = true;
            this.btn_BPress.Click += new System.EventHandler(this.btn_BPress_Click);
            this.btn_BPress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_BPress_MouseDown);
            this.btn_BPress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_BPress_MouseUp);
            // 
            // lbl_OpenTime
            // 
            this.lbl_OpenTime.BackColor = System.Drawing.Color.White;
            this.lbl_OpenTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_OpenTime.Location = new System.Drawing.Point(180, 179);
            this.lbl_OpenTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_OpenTime.Name = "lbl_OpenTime";
            this.lbl_OpenTime.Size = new System.Drawing.Size(60, 30);
            this.lbl_OpenTime.TabIndex = 66;
            this.lbl_OpenTime.Text = "000.001";
            this.lbl_OpenTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_OpenTime.Click += new System.EventHandler(this.lbl_OpenTime_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "";
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(124, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 30);
            this.label3.TabIndex = 68;
            this.label3.Text = "(ms)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Open Time";
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(8, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 30);
            this.label4.TabIndex = 67;
            this.label4.Text = "Open Time";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CloseDelay
            // 
            this.lbl_CloseDelay.BackColor = System.Drawing.Color.White;
            this.lbl_CloseDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CloseDelay.Location = new System.Drawing.Point(180, 215);
            this.lbl_CloseDelay.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_CloseDelay.Name = "lbl_CloseDelay";
            this.lbl_CloseDelay.Size = new System.Drawing.Size(60, 30);
            this.lbl_CloseDelay.TabIndex = 69;
            this.lbl_CloseDelay.Text = "000.001";
            this.lbl_CloseDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_CloseDelay.Click += new System.EventHandler(this.lbl_CloseDelay_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "";
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(124, 215);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 30);
            this.label7.TabIndex = 71;
            this.label7.Text = "(ms)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Close Delay";
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(8, 215);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 30);
            this.label8.TabIndex = 70;
            this.label8.Text = "Close Delay";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Shot
            // 
            this.btn_Shot.AccessibleDescription = "Trigger";
            this.btn_Shot.Location = new System.Drawing.Point(246, 251);
            this.btn_Shot.Name = "btn_Shot";
            this.btn_Shot.Size = new System.Drawing.Size(75, 30);
            this.btn_Shot.TabIndex = 72;
            this.btn_Shot.Text = "Shot";
            this.btn_Shot.UseVisualStyleBackColor = true;
            this.btn_Shot.Click += new System.EventHandler(this.btn_Shot_Click);
            // 
            // lbl_PulseCount
            // 
            this.lbl_PulseCount.BackColor = System.Drawing.Color.White;
            this.lbl_PulseCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PulseCount.Location = new System.Drawing.Point(180, 251);
            this.lbl_PulseCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PulseCount.Name = "lbl_PulseCount";
            this.lbl_PulseCount.Size = new System.Drawing.Size(60, 30);
            this.lbl_PulseCount.TabIndex = 73;
            this.lbl_PulseCount.Text = "000.001";
            this.lbl_PulseCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PulseCount.Click += new System.EventHandler(this.lbl_PulseCount_Click);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "";
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(124, 251);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 30);
            this.label5.TabIndex = 75;
            this.label5.Text = "(count)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "Pulse";
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(8, 251);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 30);
            this.label9.TabIndex = 74;
            this.label9.Text = "Pulse";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Frequency";
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(8, 287);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 30);
            this.label1.TabIndex = 76;
            this.label1.Text = "Frequency";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Frequency
            // 
            this.lbl_Frequency.AccessibleDescription = "";
            this.lbl_Frequency.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Frequency.Location = new System.Drawing.Point(180, 287);
            this.lbl_Frequency.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Frequency.Name = "lbl_Frequency";
            this.lbl_Frequency.Size = new System.Drawing.Size(60, 30);
            this.lbl_Frequency.TabIndex = 77;
            this.lbl_Frequency.Text = "0";
            this.lbl_Frequency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "";
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(124, 287);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 30);
            this.label11.TabIndex = 78;
            this.label11.Text = "(Hz)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(246, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 79;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // frm_Setup_PJ
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(349, 383);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_Frequency);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_PulseCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Shot);
            this.Controls.Add(this.lbl_CloseDelay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_OpenTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_FPressA);
            this.Controls.Add(this.lbl_PressUnit);
            this.Controls.Add(this.btn_POpen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_BPress);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Setup_PJ";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_Setup_PJ";
            this.Load += new System.EventHandler(this.frm_Setup_PJ_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Setup_PJ_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_FPressA;
        private System.Windows.Forms.Label lbl_PressUnit;
        private System.Windows.Forms.Button btn_POpen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_BPress;
        private System.Windows.Forms.Label lbl_OpenTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_CloseDelay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Shot;
        private System.Windows.Forms.Label lbl_PulseCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Frequency;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Close;
    }
}