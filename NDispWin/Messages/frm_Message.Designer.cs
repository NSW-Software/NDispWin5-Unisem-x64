namespace NDispWin
{
    partial class frm_Message
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_StartTime = new System.Windows.Forms.Label();
            this.lbl_ElapseTime = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.pBar_Progress = new System.Windows.Forms.ProgressBar();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Message2 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(360, 143);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(70, 30);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_StartTime
            // 
            this.lbl_StartTime.AutoSize = true;
            this.lbl_StartTime.Location = new System.Drawing.Point(116, 142);
            this.lbl_StartTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartTime.Name = "lbl_StartTime";
            this.lbl_StartTime.Size = new System.Drawing.Size(79, 14);
            this.lbl_StartTime.TabIndex = 1;
            this.lbl_StartTime.Text = "lbl_StartTime";
            // 
            // lbl_ElapseTime
            // 
            this.lbl_ElapseTime.AutoSize = true;
            this.lbl_ElapseTime.Location = new System.Drawing.Point(116, 160);
            this.lbl_ElapseTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ElapseTime.Name = "lbl_ElapseTime";
            this.lbl_ElapseTime.Size = new System.Drawing.Size(86, 14);
            this.lbl_ElapseTime.TabIndex = 2;
            this.lbl_ElapseTime.Text = "lbl_ElapseTime";
            // 
            // lbl_Message
            // 
            this.lbl_Message.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Message.Location = new System.Drawing.Point(5, 5);
            this.lbl_Message.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(407, 39);
            this.lbl_Message.TabIndex = 3;
            this.lbl_Message.Text = "lbl_Message sdf  sdfsdf";
            // 
            // pBar_Progress
            // 
            this.pBar_Progress.Location = new System.Drawing.Point(13, 13);
            this.pBar_Progress.Maximum = 60;
            this.pBar_Progress.Name = "pBar_Progress";
            this.pBar_Progress.Size = new System.Drawing.Size(417, 20);
            this.pBar_Progress.TabIndex = 4;
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Interval = 250;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Elapse Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start Time";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.lbl_Message2);
            this.panel1.Controls.Add(this.lbl_Message);
            this.panel1.Location = new System.Drawing.Point(13, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 98);
            this.panel1.TabIndex = 7;
            // 
            // lbl_Message2
            // 
            this.lbl_Message2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Message2.ForeColor = System.Drawing.Color.Red;
            this.lbl_Message2.Location = new System.Drawing.Point(5, 54);
            this.lbl_Message2.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_Message2.Name = "lbl_Message2";
            this.lbl_Message2.Size = new System.Drawing.Size(407, 39);
            this.lbl_Message2.TabIndex = 4;
            this.lbl_Message2.Text = "lbl_Message2";
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(284, 143);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(70, 30);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frm_Message
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(448, 189);
            this.ControlBox = false;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pBar_Progress);
            this.Controls.Add(this.lbl_ElapseTime);
            this.Controls.Add(this.lbl_StartTime);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Message";
            this.Opacity = 0.9;
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_Message";
            this.Load += new System.EventHandler(this.frm_Message_Load);
            this.Shown += new System.EventHandler(this.frm_Message_Shown);
            this.VisibleChanged += new System.EventHandler(this.frm_Message_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Message_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_StartTime;
        private System.Windows.Forms.Label lbl_ElapseTime;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.ProgressBar pBar_Progress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Message2;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Button btn_OK;
    }
}