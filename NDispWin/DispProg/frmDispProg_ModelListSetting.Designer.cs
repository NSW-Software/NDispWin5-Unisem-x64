namespace NDispWin
{
    partial class frm_DispCore_DispProg_ModelListSetting
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
            this.cboxl_ModelList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbox_WarningLimit = new System.Windows.Forms.GroupBox();
            this.lbl_WarnULimit = new System.Windows.Forms.Label();
            this.lbl_WarnLLimit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbox_WarningLimit.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxl_ModelList
            // 
            this.cboxl_ModelList.FormattingEnabled = true;
            this.cboxl_ModelList.Location = new System.Drawing.Point(6, 21);
            this.cboxl_ModelList.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.cboxl_ModelList.Name = "cboxl_ModelList";
            this.cboxl_ModelList.Size = new System.Drawing.Size(156, 361);
            this.cboxl_ModelList.TabIndex = 0;
            this.cboxl_ModelList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cboxl_ModelList_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Basic Para Selection";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.cboxl_ModelList);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 404);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Para Selection";
            // 
            // gbox_WarningLimit
            // 
            this.gbox_WarningLimit.AccessibleDescription = "Warning Limit";
            this.gbox_WarningLimit.AutoSize = true;
            this.gbox_WarningLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_WarningLimit.Controls.Add(this.lbl_WarnULimit);
            this.gbox_WarningLimit.Controls.Add(this.lbl_WarnLLimit);
            this.gbox_WarningLimit.Controls.Add(this.label2);
            this.gbox_WarningLimit.Controls.Add(this.label1);
            this.gbox_WarningLimit.Location = new System.Drawing.Point(182, 8);
            this.gbox_WarningLimit.Name = "gbox_WarningLimit";
            this.gbox_WarningLimit.Size = new System.Drawing.Size(168, 92);
            this.gbox_WarningLimit.TabIndex = 3;
            this.gbox_WarningLimit.TabStop = false;
            this.gbox_WarningLimit.Text = "Warning Limit";
            // 
            // lbl_WarnULimit
            // 
            this.lbl_WarnULimit.BackColor = System.Drawing.Color.White;
            this.lbl_WarnULimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WarnULimit.Location = new System.Drawing.Point(87, 47);
            this.lbl_WarnULimit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_WarnULimit.Name = "lbl_WarnULimit";
            this.lbl_WarnULimit.Size = new System.Drawing.Size(75, 23);
            this.lbl_WarnULimit.TabIndex = 3;
            this.lbl_WarnULimit.Text = "lbl_WarnULimit";
            this.lbl_WarnULimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_WarnULimit.Click += new System.EventHandler(this.lbl_WarnULimit_Click);
            // 
            // lbl_WarnLLimit
            // 
            this.lbl_WarnLLimit.BackColor = System.Drawing.Color.White;
            this.lbl_WarnLLimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WarnLLimit.Location = new System.Drawing.Point(87, 21);
            this.lbl_WarnLLimit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_WarnLLimit.Name = "lbl_WarnLLimit";
            this.lbl_WarnLLimit.Size = new System.Drawing.Size(75, 23);
            this.lbl_WarnLLimit.TabIndex = 2;
            this.lbl_WarnLLimit.Text = "lbl_WarnLLimit";
            this.lbl_WarnLLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_WarnLLimit.Click += new System.EventHandler(this.lbl_WarnLLimit_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Upper";
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Upper";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Lower";
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lower";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_DispCore_DispProg_ModelListSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 445);
            this.Controls.Add(this.gbox_WarningLimit);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DispCore_DispProg_ModelListSetting";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_ModelListSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_DispProg_ModelListSetting_FormClosing);
            this.Load += new System.EventHandler(this.frmDispProg_ModelListSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbox_WarningLimit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cboxl_ModelList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbox_WarningLimit;
        private System.Windows.Forms.Label lbl_WarnULimit;
        private System.Windows.Forms.Label lbl_WarnLLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}