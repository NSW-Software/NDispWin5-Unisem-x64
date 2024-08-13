namespace NDispWin
{
    partial class frm_ProgressReport
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_StartTime = new System.Windows.Forms.Label();
            this.lbl_ElapseTime = new System.Windows.Forms.Label();
            this.tmr_500ms = new System.Windows.Forms.Timer(this.components);
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 52);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(448, 23);
            this.progressBar.TabIndex = 0;
            // 
            // lbl_Message
            // 
            this.lbl_Message.Location = new System.Drawing.Point(6, 3);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(448, 46);
            this.lbl_Message.TabIndex = 1;
            this.lbl_Message.Text = "Message Message2 Message3";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(379, 92);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_StartTime
            // 
            this.lbl_StartTime.AutoSize = true;
            this.lbl_StartTime.Location = new System.Drawing.Point(6, 81);
            this.lbl_StartTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_StartTime.Name = "lbl_StartTime";
            this.lbl_StartTime.Size = new System.Drawing.Size(79, 14);
            this.lbl_StartTime.TabIndex = 3;
            this.lbl_StartTime.Text = "lbl_StartTime";
            // 
            // lbl_ElapseTime
            // 
            this.lbl_ElapseTime.AutoSize = true;
            this.lbl_ElapseTime.Location = new System.Drawing.Point(6, 101);
            this.lbl_ElapseTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_ElapseTime.Name = "lbl_ElapseTime";
            this.lbl_ElapseTime.Size = new System.Drawing.Size(86, 14);
            this.lbl_ElapseTime.TabIndex = 4;
            this.lbl_ElapseTime.Text = "lbl_ElapseTime";
            // 
            // tmr_500ms
            // 
            this.tmr_500ms.Enabled = true;
            this.tmr_500ms.Tick += new System.EventHandler(this.tmr_500ms_Tick);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(298, 92);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frm_ProgressReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(460, 150);
            this.ControlBox = false;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_ElapseTime);
            this.Controls.Add(this.lbl_StartTime);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.progressBar);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_ProgressReport";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Progress Report";
            this.Load += new System.EventHandler(this.frm_ProgressReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_StartTime;
        private System.Windows.Forms.Label lbl_ElapseTime;
        private System.Windows.Forms.Timer tmr_500ms;
        private System.Windows.Forms.Button btn_OK;
    }
}