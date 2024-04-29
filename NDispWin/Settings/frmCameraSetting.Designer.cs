namespace NDispWin
{
    partial class frmCameraSetting
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
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.lbl_CalMode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ShowJog = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Gain = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Exposure = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnl_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Main
            // 
            this.pnl_Main.AutoSize = true;
            this.pnl_Main.Controls.Add(this.lbl_CalMode);
            this.pnl_Main.Controls.Add(this.label4);
            this.pnl_Main.Controls.Add(this.btn_ShowJog);
            this.pnl_Main.Controls.Add(this.btn_Close);
            this.pnl_Main.Controls.Add(this.label3);
            this.pnl_Main.Controls.Add(this.lbl_Gain);
            this.pnl_Main.Controls.Add(this.label2);
            this.pnl_Main.Controls.Add(this.lbl_Exposure);
            this.pnl_Main.Controls.Add(this.label8);
            this.pnl_Main.Location = new System.Drawing.Point(12, 12);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(239, 141);
            this.pnl_Main.TabIndex = 0;
            this.pnl_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Main_Paint);
            // 
            // lbl_CalMode
            // 
            this.lbl_CalMode.BackColor = System.Drawing.Color.White;
            this.lbl_CalMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CalMode.Location = new System.Drawing.Point(160, 114);
            this.lbl_CalMode.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CalMode.Name = "lbl_CalMode";
            this.lbl_CalMode.Size = new System.Drawing.Size(75, 25);
            this.lbl_CalMode.TabIndex = 162;
            this.lbl_CalMode.Text = "Ave_XY";
            this.lbl_CalMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_CalMode.Click += new System.EventHandler(this.lbl_CalMode_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Cal Mode";
            this.label4.AccessibleName = "Cal Mode";
            this.label4.Location = new System.Drawing.Point(2, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 161;
            this.label4.Text = "Cal Mode";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_ShowJog
            // 
            this.btn_ShowJog.AccessibleDescription = "Jog";
            this.btn_ShowJog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ShowJog.Location = new System.Drawing.Point(2, -79);
            this.btn_ShowJog.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ShowJog.Name = "btn_ShowJog";
            this.btn_ShowJog.Size = new System.Drawing.Size(87, 39);
            this.btn_ShowJog.TabIndex = 160;
            this.btn_ShowJog.Text = "Jog";
            this.btn_ShowJog.UseVisualStyleBackColor = true;
            this.btn_ShowJog.Click += new System.EventHandler(this.btn_ShowJog_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(150, 2);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(87, 39);
            this.btn_Close.TabIndex = 159;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "(us)";
            this.label3.AccessibleName = "";
            this.label3.Location = new System.Drawing.Point(106, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 158;
            this.label3.Text = "(us)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Gain
            // 
            this.lbl_Gain.BackColor = System.Drawing.Color.White;
            this.lbl_Gain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Gain.Location = new System.Drawing.Point(160, 85);
            this.lbl_Gain.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Gain.Name = "lbl_Gain";
            this.lbl_Gain.Size = new System.Drawing.Size(75, 25);
            this.lbl_Gain.TabIndex = 157;
            this.lbl_Gain.Text = "12345679";
            this.lbl_Gain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Gain.Click += new System.EventHandler(this.lbl_Gain_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Gain";
            this.label2.AccessibleName = "Gain";
            this.label2.Location = new System.Drawing.Point(2, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 156;
            this.label2.Text = "Gain";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Exposure
            // 
            this.lbl_Exposure.BackColor = System.Drawing.Color.White;
            this.lbl_Exposure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Exposure.Location = new System.Drawing.Point(160, 56);
            this.lbl_Exposure.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Exposure.Name = "lbl_Exposure";
            this.lbl_Exposure.Size = new System.Drawing.Size(75, 25);
            this.lbl_Exposure.TabIndex = 154;
            this.lbl_Exposure.Text = "12345679";
            this.lbl_Exposure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Exposure.Click += new System.EventHandler(this.lbl_Exposure_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Exposure";
            this.label8.AccessibleName = "Exposure";
            this.label8.Location = new System.Drawing.Point(2, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 25);
            this.label8.TabIndex = 153;
            this.label8.Text = "Exposure";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCameraSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 181);
            this.Controls.Add(this.pnl_Main);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmCameraSetting";
            this.Text = "Camera Setting";
            this.Load += new System.EventHandler(this.frm_DispCore_CameraSetting_Load);
            this.pnl_Main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.Label lbl_Exposure;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Gain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ShowJog;
        private System.Windows.Forms.Label lbl_CalMode;
        private System.Windows.Forms.Label label4;
    }
}