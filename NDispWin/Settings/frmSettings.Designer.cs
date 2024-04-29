
namespace NDispWin
{
    partial class frmSettings
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
            this.btnIODiag = new System.Windows.Forms.Button();
            this.btnMotorDiag = new System.Windows.Forms.Button();
            this.btnMotorConfig = new System.Windows.Forms.Button();
            this.btnVision = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnJog = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIODiag
            // 
            this.btnIODiag.ForeColor = System.Drawing.Color.Navy;
            this.btnIODiag.Location = new System.Drawing.Point(3, 3);
            this.btnIODiag.Name = "btnIODiag";
            this.btnIODiag.Size = new System.Drawing.Size(100, 30);
            this.btnIODiag.TabIndex = 0;
            this.btnIODiag.Text = "IO Diagnostics";
            this.btnIODiag.UseVisualStyleBackColor = true;
            this.btnIODiag.Click += new System.EventHandler(this.btnIODiag_Click);
            // 
            // btnMotorDiag
            // 
            this.btnMotorDiag.ForeColor = System.Drawing.Color.Navy;
            this.btnMotorDiag.Location = new System.Drawing.Point(109, 3);
            this.btnMotorDiag.Name = "btnMotorDiag";
            this.btnMotorDiag.Size = new System.Drawing.Size(100, 30);
            this.btnMotorDiag.TabIndex = 1;
            this.btnMotorDiag.Text = "Motor Diag";
            this.btnMotorDiag.UseVisualStyleBackColor = true;
            this.btnMotorDiag.Click += new System.EventHandler(this.btnMotorDiag_Click);
            // 
            // btnMotorConfig
            // 
            this.btnMotorConfig.ForeColor = System.Drawing.Color.Navy;
            this.btnMotorConfig.Location = new System.Drawing.Point(215, 3);
            this.btnMotorConfig.Name = "btnMotorConfig";
            this.btnMotorConfig.Size = new System.Drawing.Size(100, 30);
            this.btnMotorConfig.TabIndex = 2;
            this.btnMotorConfig.Text = "Motor Para";
            this.btnMotorConfig.UseVisualStyleBackColor = true;
            this.btnMotorConfig.Click += new System.EventHandler(this.btnMotorConfig_Click);
            // 
            // btnVision
            // 
            this.btnVision.ForeColor = System.Drawing.Color.Navy;
            this.btnVision.Location = new System.Drawing.Point(321, 3);
            this.btnVision.Name = "btnVision";
            this.btnVision.Size = new System.Drawing.Size(100, 30);
            this.btnVision.TabIndex = 3;
            this.btnVision.Text = "Vision";
            this.btnVision.UseVisualStyleBackColor = true;
            this.btnVision.Click += new System.EventHandler(this.btnVision_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.AutoSize = true;
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.btnSave);
            this.pnlTop.Controls.Add(this.btnJog);
            this.pnlTop.Controls.Add(this.btnConfig);
            this.pnlTop.Controls.Add(this.btnIODiag);
            this.pnlTop.Controls.Add(this.btnVision);
            this.pnlTop.Controls.Add(this.btnMotorDiag);
            this.pnlTop.Controls.Add(this.btnMotorConfig);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(5, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(874, 36);
            this.pnlTop.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ForeColor = System.Drawing.Color.Navy;
            this.btnClose.Location = new System.Drawing.Point(771, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Location = new System.Drawing.Point(665, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnJog
            // 
            this.btnJog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJog.ForeColor = System.Drawing.Color.Navy;
            this.btnJog.Location = new System.Drawing.Point(559, 3);
            this.btnJog.Name = "btnJog";
            this.btnJog.Size = new System.Drawing.Size(100, 30);
            this.btnJog.TabIndex = 5;
            this.btnJog.Text = "Jog";
            this.btnJog.UseVisualStyleBackColor = true;
            this.btnJog.Click += new System.EventHandler(this.btnJog_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.ForeColor = System.Drawing.Color.Navy;
            this.btnConfig.Location = new System.Drawing.Point(427, 3);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(100, 30);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 641);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmSettings";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIODiag;
        private System.Windows.Forms.Button btnMotorDiag;
        private System.Windows.Forms.Button btnMotorConfig;
        private System.Windows.Forms.Button btnVision;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnJog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}