namespace NDispWin
{
    partial class frm_DispCore_DispProg_PurgeClean
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_Count = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Delay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_PostVacTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Setup = new System.Windows.Forms.Button();
            this.btn_Cond = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbox_Cond = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(167, 232);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 32;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(86, 232);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 31;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_Count
            // 
            this.lbl_Count.BackColor = System.Drawing.Color.White;
            this.lbl_Count.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Count.Location = new System.Drawing.Point(133, 106);
            this.lbl_Count.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(75, 23);
            this.lbl_Count.TabIndex = 35;
            this.lbl_Count.Text = "1";
            this.lbl_Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Count.Click += new System.EventHandler(this.lbl_Count_Click);
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "Count (times)";
            this.label15.Location = new System.Drawing.Point(7, 106);
            this.label15.Margin = new System.Windows.Forms.Padding(2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 23);
            this.label15.TabIndex = 34;
            this.label15.Text = "Count (times)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Time
            // 
            this.lbl_Time.BackColor = System.Drawing.Color.White;
            this.lbl_Time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Time.Location = new System.Drawing.Point(133, 133);
            this.lbl_Time.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(75, 23);
            this.lbl_Time.TabIndex = 37;
            this.lbl_Time.Text = "(Auto) 100";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Time.Click += new System.EventHandler(this.lbl_Time_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Time (ms)";
            this.label2.Location = new System.Drawing.Point(7, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "Time (ms)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Delay
            // 
            this.lbl_Delay.BackColor = System.Drawing.Color.White;
            this.lbl_Delay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Delay.Location = new System.Drawing.Point(133, 160);
            this.lbl_Delay.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Delay.Name = "lbl_Delay";
            this.lbl_Delay.Size = new System.Drawing.Size(75, 23);
            this.lbl_Delay.TabIndex = 39;
            this.lbl_Delay.Text = "1";
            this.lbl_Delay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Delay.Click += new System.EventHandler(this.lbl_Delay_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Wait (ms)";
            this.label3.Location = new System.Drawing.Point(7, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Wait (ms)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PostVacTime
            // 
            this.lbl_PostVacTime.BackColor = System.Drawing.Color.White;
            this.lbl_PostVacTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PostVacTime.Location = new System.Drawing.Point(133, 187);
            this.lbl_PostVacTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_PostVacTime.Name = "lbl_PostVacTime";
            this.lbl_PostVacTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_PostVacTime.TabIndex = 41;
            this.lbl_PostVacTime.Text = "1";
            this.lbl_PostVacTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_PostVacTime.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Post Vac Time (ms)";
            this.label4.Location = new System.Drawing.Point(7, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Post Vac Time (ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Setup
            // 
            this.btn_Setup.AccessibleDescription = "Setup";
            this.btn_Setup.Location = new System.Drawing.Point(7, 232);
            this.btn_Setup.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Setup.Name = "btn_Setup";
            this.btn_Setup.Size = new System.Drawing.Size(75, 36);
            this.btn_Setup.TabIndex = 42;
            this.btn_Setup.Text = "Setup";
            this.btn_Setup.UseVisualStyleBackColor = true;
            this.btn_Setup.Click += new System.EventHandler(this.btn_Setup_Click);
            // 
            // btn_Cond
            // 
            this.btn_Cond.AccessibleDescription = "Cond";
            this.btn_Cond.Location = new System.Drawing.Point(167, 59);
            this.btn_Cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cond.Name = "btn_Cond";
            this.btn_Cond.Size = new System.Drawing.Size(75, 36);
            this.btn_Cond.TabIndex = 43;
            this.btn_Cond.Text = "Cond";
            this.btn_Cond.UseVisualStyleBackColor = true;
            this.btn_Cond.Click += new System.EventHandler(this.btn_Cond_Click);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "Cancel";
            this.button1.Location = new System.Drawing.Point(167, 232);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 32;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbox_Cond
            // 
            this.lbox_Cond.FormattingEnabled = true;
            this.lbox_Cond.ItemHeight = 14;
            this.lbox_Cond.Location = new System.Drawing.Point(8, 8);
            this.lbox_Cond.Name = "lbox_Cond";
            this.lbox_Cond.Size = new System.Drawing.Size(234, 46);
            this.lbox_Cond.TabIndex = 44;
            this.lbox_Cond.SelectedIndexChanged += new System.EventHandler(this.lbox_Cond_SelectedIndexChanged);
            // 
            // frm_DispCore_DispProg_PurgeClean
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(272, 305);
            this.ControlBox = false;
            this.Controls.Add(this.lbox_Cond);
            this.Controls.Add(this.btn_Cond);
            this.Controls.Add(this.btn_Setup);
            this.Controls.Add(this.lbl_PostVacTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Delay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Count);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_PurgeClean";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_PurgeClean";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_PurgeClean_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_Purge_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_Count;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Delay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_PostVacTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Setup;
        private System.Windows.Forms.Button btn_Cond;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbox_Cond;
    }
}