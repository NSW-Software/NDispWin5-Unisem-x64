namespace NDispWin
{
    partial class frm_DispCore_IdlePurge
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_IdlePurgeInterval = new System.Windows.Forms.Label();
            this.lbl_IdlePurgeDuration = new System.Windows.Forms.Label();
            this.lbl_IdleTimeToIdle = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_SelectDisp1 = new System.Windows.Forms.Button();
            this.btn_SelectDisp2 = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tmr_Idle = new System.Windows.Forms.Timer(this.components);
            this.pbar_TimeToPurge = new System.Windows.Forms.ProgressBar();
            this.tmr_Sec = new System.Windows.Forms.Timer(this.components);
            this.lbl_IdlePurgePostVacTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(263, 6);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 30);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(263, 42);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 30);
            this.btn_Stop.TabIndex = 0;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "Purge Interval (s)";
            this.label11.Location = new System.Drawing.Point(5, 125);
            this.label11.Margin = new System.Windows.Forms.Padding(2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 23);
            this.label11.TabIndex = 188;
            this.label11.Text = "Purge Interval (s)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AccessibleDescription = "Purge Duration (ms)";
            this.label17.Location = new System.Drawing.Point(5, 71);
            this.label17.Margin = new System.Windows.Forms.Padding(2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(150, 23);
            this.label17.TabIndex = 187;
            this.label17.Text = "Purge Duration (ms)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_IdlePurgeInterval
            // 
            this.lbl_IdlePurgeInterval.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_IdlePurgeInterval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_IdlePurgeInterval.Location = new System.Drawing.Point(162, 125);
            this.lbl_IdlePurgeInterval.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_IdlePurgeInterval.Name = "lbl_IdlePurgeInterval";
            this.lbl_IdlePurgeInterval.Size = new System.Drawing.Size(75, 23);
            this.lbl_IdlePurgeInterval.TabIndex = 186;
            this.lbl_IdlePurgeInterval.Text = "999";
            this.lbl_IdlePurgeInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_IdlePurgeInterval.Click += new System.EventHandler(this.lbl_IdlePurgeInterval_Click);
            // 
            // lbl_IdlePurgeDuration
            // 
            this.lbl_IdlePurgeDuration.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_IdlePurgeDuration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_IdlePurgeDuration.Location = new System.Drawing.Point(162, 71);
            this.lbl_IdlePurgeDuration.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_IdlePurgeDuration.Name = "lbl_IdlePurgeDuration";
            this.lbl_IdlePurgeDuration.Size = new System.Drawing.Size(75, 23);
            this.lbl_IdlePurgeDuration.TabIndex = 184;
            this.lbl_IdlePurgeDuration.Text = "999";
            this.lbl_IdlePurgeDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_IdlePurgeDuration.Click += new System.EventHandler(this.lbl_IdlePurgeTime_Click);
            // 
            // lbl_IdleTimeToIdle
            // 
            this.lbl_IdleTimeToIdle.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_IdleTimeToIdle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_IdleTimeToIdle.Location = new System.Drawing.Point(162, 44);
            this.lbl_IdleTimeToIdle.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_IdleTimeToIdle.Name = "lbl_IdleTimeToIdle";
            this.lbl_IdleTimeToIdle.Size = new System.Drawing.Size(75, 23);
            this.lbl_IdleTimeToIdle.TabIndex = 185;
            this.lbl_IdleTimeToIdle.Text = "999";
            this.lbl_IdleTimeToIdle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_IdleTimeToIdle.Visible = false;
            this.lbl_IdleTimeToIdle.Click += new System.EventHandler(this.lbl_IdleTimeToIdle_Click);
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "Time To Idle (ms)";
            this.label15.Location = new System.Drawing.Point(5, 44);
            this.label15.Margin = new System.Windows.Forms.Padding(2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 23);
            this.label15.TabIndex = 183;
            this.label15.Text = "Time To Idle (s)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Visible = false;
            // 
            // btn_SelectDisp1
            // 
            this.btn_SelectDisp1.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_SelectDisp1.Location = new System.Drawing.Point(80, 6);
            this.btn_SelectDisp1.Name = "btn_SelectDisp1";
            this.btn_SelectDisp1.Size = new System.Drawing.Size(75, 30);
            this.btn_SelectDisp1.TabIndex = 190;
            this.btn_SelectDisp1.Text = "Disp 1";
            this.btn_SelectDisp1.UseVisualStyleBackColor = false;
            this.btn_SelectDisp1.Click += new System.EventHandler(this.btn_SelectDisp1_Click);
            // 
            // btn_SelectDisp2
            // 
            this.btn_SelectDisp2.Location = new System.Drawing.Point(161, 6);
            this.btn_SelectDisp2.Name = "btn_SelectDisp2";
            this.btn_SelectDisp2.Size = new System.Drawing.Size(75, 30);
            this.btn_SelectDisp2.TabIndex = 191;
            this.btn_SelectDisp2.Text = "Disp 2";
            this.btn_SelectDisp2.UseVisualStyleBackColor = true;
            this.btn_SelectDisp2.Click += new System.EventHandler(this.btn_SelectDisp2_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(263, 153);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 192;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tmr_Idle
            // 
            this.tmr_Idle.Interval = 1000;
            this.tmr_Idle.Tick += new System.EventHandler(this.tmr_Idle_Tick);
            // 
            // pbar_TimeToPurge
            // 
            this.pbar_TimeToPurge.Location = new System.Drawing.Point(8, 153);
            this.pbar_TimeToPurge.Name = "pbar_TimeToPurge";
            this.pbar_TimeToPurge.Size = new System.Drawing.Size(229, 23);
            this.pbar_TimeToPurge.TabIndex = 193;
            this.pbar_TimeToPurge.Value = 10;
            // 
            // tmr_Sec
            // 
            this.tmr_Sec.Interval = 1000;
            this.tmr_Sec.Tick += new System.EventHandler(this.tmr_Sec_Tick);
            // 
            // lbl_IdlePurgePostVacTime
            // 
            this.lbl_IdlePurgePostVacTime.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_IdlePurgePostVacTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_IdlePurgePostVacTime.Location = new System.Drawing.Point(162, 98);
            this.lbl_IdlePurgePostVacTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_IdlePurgePostVacTime.Name = "lbl_IdlePurgePostVacTime";
            this.lbl_IdlePurgePostVacTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_IdlePurgePostVacTime.TabIndex = 195;
            this.lbl_IdlePurgePostVacTime.Text = "999";
            this.lbl_IdlePurgePostVacTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_IdlePurgePostVacTime.Click += new System.EventHandler(this.lbl_IdlePurgePostVacTime_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Post Vac Time (ms)";
            this.label7.Location = new System.Drawing.Point(5, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 23);
            this.label7.TabIndex = 194;
            this.label7.Text = "Post Vac Time (ms)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_DispCore_IdlePurge
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(345, 193);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_IdlePurgePostVacTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbar_TimeToPurge);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_SelectDisp2);
            this.Controls.Add(this.btn_SelectDisp1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lbl_IdlePurgeInterval);
            this.Controls.Add(this.lbl_IdlePurgeDuration);
            this.Controls.Add(this.lbl_IdleTimeToIdle);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_IdlePurge";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_DispCore_IdlePurge";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_IdlePurge_FormClosing);
            this.Load += new System.EventHandler(this.frm_DispCore_IdlePurge_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_IdlePurgeInterval;
        private System.Windows.Forms.Label lbl_IdlePurgeDuration;
        private System.Windows.Forms.Label lbl_IdleTimeToIdle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_SelectDisp1;
        private System.Windows.Forms.Button btn_SelectDisp2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Timer tmr_Idle;
        private System.Windows.Forms.ProgressBar pbar_TimeToPurge;
        private System.Windows.Forms.Timer tmr_Sec;
        private System.Windows.Forms.Label lbl_IdlePurgePostVacTime;
        private System.Windows.Forms.Label label7;
    }
}