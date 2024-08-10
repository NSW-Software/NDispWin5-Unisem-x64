namespace NDispWin
{
    partial class frm_DispCore_Progress
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
            this.pBar_Progress = new System.Windows.Forms.ProgressBar();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.lbl_ElapseTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBar_Progress
            // 
            this.pBar_Progress.Location = new System.Drawing.Point(8, 8);
            this.pBar_Progress.Name = "pBar_Progress";
            this.pBar_Progress.Size = new System.Drawing.Size(374, 25);
            this.pBar_Progress.Step = 1;
            this.pBar_Progress.TabIndex = 0;
            this.pBar_Progress.Value = 50;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(307, 75);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.Location = new System.Drawing.Point(8, 46);
            this.lbl_Message.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(374, 23);
            this.lbl_Message.TabIndex = 3;
            this.lbl_Message.Text = "lbl_Message";
            this.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // lbl_ElapseTime
            // 
            this.lbl_ElapseTime.Location = new System.Drawing.Point(388, 8);
            this.lbl_ElapseTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_ElapseTime.Name = "lbl_ElapseTime";
            this.lbl_ElapseTime.Size = new System.Drawing.Size(62, 25);
            this.lbl_ElapseTime.TabIndex = 4;
            this.lbl_ElapseTime.Text = "00:00:00";
            this.lbl_ElapseTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_DispCore_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(459, 124);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_ElapseTime);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.pBar_Progress);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_DispCore_Progress";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.frmProgress_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProgress_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBar_Progress;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Label lbl_ElapseTime;
    }
}