namespace NDispWin
{
    partial class frm_DispCore_Lighting
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
            this.tbar_R = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_R = new System.Windows.Forms.Label();
            this.lbl_G = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbar_G = new System.Windows.Forms.TrackBar();
            this.lbl_B = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbar_B = new System.Windows.Forms.TrackBar();
            this.lbl_A = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbar_A = new System.Windows.Forms.TrackBar();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Off = new System.Windows.Forms.Button();
            this.btn_SetDef = new System.Windows.Forms.Button();
            this.btn_On = new System.Windows.Forms.Button();
            this.btn_Ch1M = new System.Windows.Forms.Button();
            this.btn_Ch1P = new System.Windows.Forms.Button();
            this.btn_Ch2P = new System.Windows.Forms.Button();
            this.btn_Ch2M = new System.Windows.Forms.Button();
            this.btn_Ch3P = new System.Windows.Forms.Button();
            this.btn_Ch3M = new System.Windows.Forms.Button();
            this.btn_Ch4P = new System.Windows.Forms.Button();
            this.btn_Ch4M = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_A)).BeginInit();
            this.SuspendLayout();
            // 
            // tbar_R
            // 
            this.tbar_R.LargeChange = 10;
            this.tbar_R.Location = new System.Drawing.Point(121, 9);
            this.tbar_R.Margin = new System.Windows.Forms.Padding(0);
            this.tbar_R.Maximum = 100;
            this.tbar_R.Name = "tbar_R";
            this.tbar_R.Size = new System.Drawing.Size(122, 42);
            this.tbar_R.TabIndex = 4;
            this.tbar_R.TickFrequency = 10;
            this.tbar_R.Scroll += new System.EventHandler(this.tbar_R_Scroll);
            this.tbar_R.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbar_R_MouseDown);
            this.tbar_R.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbar_R_MouseUp);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "CH1";
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "CH1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_R
            // 
            this.lbl_R.BackColor = System.Drawing.Color.White;
            this.lbl_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_R.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_R.Location = new System.Drawing.Point(68, 9);
            this.lbl_R.Name = "lbl_R";
            this.lbl_R.Size = new System.Drawing.Size(50, 30);
            this.lbl_R.TabIndex = 6;
            this.lbl_R.Text = "100";
            this.lbl_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_R.Click += new System.EventHandler(this.lbl_R_Click);
            // 
            // lbl_G
            // 
            this.lbl_G.BackColor = System.Drawing.Color.White;
            this.lbl_G.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_G.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_G.Location = new System.Drawing.Point(68, 45);
            this.lbl_G.Name = "lbl_G";
            this.lbl_G.Size = new System.Drawing.Size(50, 30);
            this.lbl_G.TabIndex = 9;
            this.lbl_G.Text = "100";
            this.lbl_G.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_G.Click += new System.EventHandler(this.lbl_G_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "CH2";
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "CH2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbar_G
            // 
            this.tbar_G.LargeChange = 10;
            this.tbar_G.Location = new System.Drawing.Point(121, 45);
            this.tbar_G.Margin = new System.Windows.Forms.Padding(0);
            this.tbar_G.Maximum = 100;
            this.tbar_G.Name = "tbar_G";
            this.tbar_G.Size = new System.Drawing.Size(122, 42);
            this.tbar_G.TabIndex = 7;
            this.tbar_G.TickFrequency = 10;
            this.tbar_G.Scroll += new System.EventHandler(this.tbar_G_Scroll);
            this.tbar_G.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbar_R_MouseDown);
            this.tbar_G.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbar_R_MouseUp);
            // 
            // lbl_B
            // 
            this.lbl_B.BackColor = System.Drawing.Color.White;
            this.lbl_B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_B.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_B.Location = new System.Drawing.Point(68, 81);
            this.lbl_B.Name = "lbl_B";
            this.lbl_B.Size = new System.Drawing.Size(50, 30);
            this.lbl_B.TabIndex = 12;
            this.lbl_B.Text = "100";
            this.lbl_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_B.Click += new System.EventHandler(this.lbl_B_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "CH3";
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "CH3";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tbar_B
            // 
            this.tbar_B.LargeChange = 10;
            this.tbar_B.Location = new System.Drawing.Point(121, 81);
            this.tbar_B.Margin = new System.Windows.Forms.Padding(0);
            this.tbar_B.Maximum = 100;
            this.tbar_B.Name = "tbar_B";
            this.tbar_B.Size = new System.Drawing.Size(122, 42);
            this.tbar_B.TabIndex = 10;
            this.tbar_B.TickFrequency = 10;
            this.tbar_B.Scroll += new System.EventHandler(this.tbar_B_Scroll);
            this.tbar_B.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbar_R_MouseDown);
            this.tbar_B.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbar_R_MouseUp);
            // 
            // lbl_A
            // 
            this.lbl_A.BackColor = System.Drawing.Color.White;
            this.lbl_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_A.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_A.Location = new System.Drawing.Point(68, 117);
            this.lbl_A.Name = "lbl_A";
            this.lbl_A.Size = new System.Drawing.Size(50, 30);
            this.lbl_A.TabIndex = 15;
            this.lbl_A.Text = "100";
            this.lbl_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_A.Click += new System.EventHandler(this.lbl_A_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "CH4";
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(12, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 30);
            this.label8.TabIndex = 14;
            this.label8.Text = "CH4";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // tbar_A
            // 
            this.tbar_A.LargeChange = 10;
            this.tbar_A.Location = new System.Drawing.Point(121, 117);
            this.tbar_A.Margin = new System.Windows.Forms.Padding(0);
            this.tbar_A.Maximum = 100;
            this.tbar_A.Name = "tbar_A";
            this.tbar_A.Size = new System.Drawing.Size(122, 42);
            this.tbar_A.TabIndex = 13;
            this.tbar_A.TickFrequency = 10;
            this.tbar_A.Scroll += new System.EventHandler(this.tbar_A_Scroll);
            this.tbar_A.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbar_R_MouseDown);
            this.tbar_A.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbar_R_MouseUp);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(277, 159);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 16;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Off
            // 
            this.btn_Off.AccessibleDescription = "Off";
            this.btn_Off.Location = new System.Drawing.Point(96, 159);
            this.btn_Off.Name = "btn_Off";
            this.btn_Off.Size = new System.Drawing.Size(75, 30);
            this.btn_Off.TabIndex = 17;
            this.btn_Off.Text = "Off";
            this.btn_Off.UseVisualStyleBackColor = true;
            this.btn_Off.Click += new System.EventHandler(this.btn_Off_Click);
            // 
            // btn_SetDef
            // 
            this.btn_SetDef.AccessibleDescription = "Set";
            this.btn_SetDef.Location = new System.Drawing.Point(177, 159);
            this.btn_SetDef.Name = "btn_SetDef";
            this.btn_SetDef.Size = new System.Drawing.Size(75, 30);
            this.btn_SetDef.TabIndex = 18;
            this.btn_SetDef.Text = "Set";
            this.btn_SetDef.UseVisualStyleBackColor = true;
            this.btn_SetDef.Click += new System.EventHandler(this.btn_SetDef_Click);
            // 
            // btn_On
            // 
            this.btn_On.AccessibleDescription = "On";
            this.btn_On.Location = new System.Drawing.Point(15, 159);
            this.btn_On.Name = "btn_On";
            this.btn_On.Size = new System.Drawing.Size(75, 30);
            this.btn_On.TabIndex = 19;
            this.btn_On.Text = "On";
            this.btn_On.UseVisualStyleBackColor = true;
            this.btn_On.Click += new System.EventHandler(this.btn_On_Click);
            // 
            // btn_Ch1M
            // 
            this.btn_Ch1M.AccessibleDescription = "";
            this.btn_Ch1M.Location = new System.Drawing.Point(246, 9);
            this.btn_Ch1M.Name = "btn_Ch1M";
            this.btn_Ch1M.Size = new System.Drawing.Size(50, 30);
            this.btn_Ch1M.TabIndex = 20;
            this.btn_Ch1M.Text = "-";
            this.btn_Ch1M.UseVisualStyleBackColor = true;
            this.btn_Ch1M.Click += new System.EventHandler(this.btn_Ch1M_Click);
            this.btn_Ch1M.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ch1M_MouseDown);
            this.btn_Ch1M.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Ch1M_MouseUp);
            // 
            // btn_Ch1P
            // 
            this.btn_Ch1P.AccessibleDescription = "";
            this.btn_Ch1P.Location = new System.Drawing.Point(302, 9);
            this.btn_Ch1P.Name = "btn_Ch1P";
            this.btn_Ch1P.Size = new System.Drawing.Size(50, 30);
            this.btn_Ch1P.TabIndex = 20;
            this.btn_Ch1P.Text = "+";
            this.btn_Ch1P.UseVisualStyleBackColor = true;
            this.btn_Ch1P.Click += new System.EventHandler(this.btn_Ch1P_Click);
            this.btn_Ch1P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ch1P_MouseDown);
            this.btn_Ch1P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Ch1P_MouseUp);
            // 
            // btn_Ch2P
            // 
            this.btn_Ch2P.AccessibleDescription = "";
            this.btn_Ch2P.Location = new System.Drawing.Point(302, 45);
            this.btn_Ch2P.Name = "btn_Ch2P";
            this.btn_Ch2P.Size = new System.Drawing.Size(50, 30);
            this.btn_Ch2P.TabIndex = 22;
            this.btn_Ch2P.Text = "+";
            this.btn_Ch2P.UseVisualStyleBackColor = true;
            this.btn_Ch2P.Click += new System.EventHandler(this.btn_Ch2P_Click);
            this.btn_Ch2P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ch2P_MouseDown);
            this.btn_Ch2P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Ch2P_MouseUp);
            // 
            // btn_Ch2M
            // 
            this.btn_Ch2M.AccessibleDescription = "";
            this.btn_Ch2M.Location = new System.Drawing.Point(246, 45);
            this.btn_Ch2M.Name = "btn_Ch2M";
            this.btn_Ch2M.Size = new System.Drawing.Size(50, 30);
            this.btn_Ch2M.TabIndex = 21;
            this.btn_Ch2M.Text = "-";
            this.btn_Ch2M.UseVisualStyleBackColor = true;
            this.btn_Ch2M.Click += new System.EventHandler(this.btn_Ch2M_Click);
            this.btn_Ch2M.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ch2M_MouseDown);
            this.btn_Ch2M.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Ch2M_MouseUp);
            // 
            // btn_Ch3P
            // 
            this.btn_Ch3P.AccessibleDescription = "";
            this.btn_Ch3P.Location = new System.Drawing.Point(302, 81);
            this.btn_Ch3P.Name = "btn_Ch3P";
            this.btn_Ch3P.Size = new System.Drawing.Size(50, 30);
            this.btn_Ch3P.TabIndex = 24;
            this.btn_Ch3P.Text = "+";
            this.btn_Ch3P.UseVisualStyleBackColor = true;
            this.btn_Ch3P.Click += new System.EventHandler(this.btn_Ch3P_Click);
            this.btn_Ch3P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ch3P_MouseDown);
            this.btn_Ch3P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Ch3P_MouseUp);
            // 
            // btn_Ch3M
            // 
            this.btn_Ch3M.AccessibleDescription = "";
            this.btn_Ch3M.Location = new System.Drawing.Point(246, 81);
            this.btn_Ch3M.Name = "btn_Ch3M";
            this.btn_Ch3M.Size = new System.Drawing.Size(50, 30);
            this.btn_Ch3M.TabIndex = 23;
            this.btn_Ch3M.Text = "-";
            this.btn_Ch3M.UseVisualStyleBackColor = true;
            this.btn_Ch3M.Click += new System.EventHandler(this.btn_Ch3M_Click);
            this.btn_Ch3M.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ch3M_MouseDown);
            this.btn_Ch3M.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Ch3M_MouseUp);
            // 
            // btn_Ch4P
            // 
            this.btn_Ch4P.AccessibleDescription = "";
            this.btn_Ch4P.Location = new System.Drawing.Point(302, 117);
            this.btn_Ch4P.Name = "btn_Ch4P";
            this.btn_Ch4P.Size = new System.Drawing.Size(50, 30);
            this.btn_Ch4P.TabIndex = 26;
            this.btn_Ch4P.Text = "+";
            this.btn_Ch4P.UseVisualStyleBackColor = true;
            this.btn_Ch4P.Click += new System.EventHandler(this.btn_Ch4P_Click);
            this.btn_Ch4P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ch4P_MouseDown);
            this.btn_Ch4P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Ch4P_MouseUp);
            // 
            // btn_Ch4M
            // 
            this.btn_Ch4M.AccessibleDescription = "";
            this.btn_Ch4M.Location = new System.Drawing.Point(246, 117);
            this.btn_Ch4M.Name = "btn_Ch4M";
            this.btn_Ch4M.Size = new System.Drawing.Size(50, 30);
            this.btn_Ch4M.TabIndex = 25;
            this.btn_Ch4M.Text = "-";
            this.btn_Ch4M.UseVisualStyleBackColor = true;
            this.btn_Ch4M.Click += new System.EventHandler(this.btn_Ch4M_Click);
            this.btn_Ch4M.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ch4M_MouseDown);
            this.btn_Ch4M.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Ch4M_MouseUp);
            // 
            // frm_DispCore_Lighting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(388, 212);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Ch4P);
            this.Controls.Add(this.btn_Ch4M);
            this.Controls.Add(this.btn_Ch3P);
            this.Controls.Add(this.btn_Ch3M);
            this.Controls.Add(this.btn_Ch2P);
            this.Controls.Add(this.btn_Ch2M);
            this.Controls.Add(this.btn_Ch1P);
            this.Controls.Add(this.btn_Ch1M);
            this.Controls.Add(this.btn_On);
            this.Controls.Add(this.btn_SetDef);
            this.Controls.Add(this.btn_Off);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_A);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbar_A);
            this.Controls.Add(this.lbl_B);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbar_B);
            this.Controls.Add(this.lbl_G);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbar_G);
            this.Controls.Add(this.lbl_R);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbar_R);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_Lighting";
            this.Text = "frm_DispCore_Lighting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_Lighting_FormClosing);
            this.Load += new System.EventHandler(this.frmVisionView_Lighting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbar_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_A)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbar_R;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_R;
        private System.Windows.Forms.Label lbl_G;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbar_G;
        private System.Windows.Forms.Label lbl_B;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbar_B;
        private System.Windows.Forms.Label lbl_A;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tbar_A;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Off;
        private System.Windows.Forms.Button btn_SetDef;
        private System.Windows.Forms.Button btn_On;
        private System.Windows.Forms.Button btn_Ch1M;
        private System.Windows.Forms.Button btn_Ch1P;
        private System.Windows.Forms.Button btn_Ch2P;
        private System.Windows.Forms.Button btn_Ch2M;
        private System.Windows.Forms.Button btn_Ch3P;
        private System.Windows.Forms.Button btn_Ch3M;
        private System.Windows.Forms.Button btn_Ch4P;
        private System.Windows.Forms.Button btn_Ch4M;
    }
}