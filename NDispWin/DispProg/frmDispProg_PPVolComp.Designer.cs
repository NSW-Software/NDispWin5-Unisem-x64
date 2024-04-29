namespace NDispWin
{
    partial class frm_DispCore_DispProg_PPVolComp
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_HeadBVolComp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_HeadAVolComp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_HeadBWeightComp = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_HeadAWeightComp = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpage_Volume = new System.Windows.Forms.TabPage();
            this.tpage_Weight = new System.Windows.Forms.TabPage();
            this.btn_CopyW = new System.Windows.Forms.Button();
            this.lbox_Cond = new System.Windows.Forms.ListBox();
            this.btn_Cond = new System.Windows.Forms.Button();
            this.lbl_TargetWeight = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpage_Volume.SuspendLayout();
            this.tpage_Weight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.btn_Execute);
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Controls.Add(this.btn_OK);
            this.panel3.Location = new System.Drawing.Point(8, 211);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(437, 50);
            this.panel3.TabIndex = 135;
            // 
            // btn_Execute
            // 
            this.btn_Execute.AccessibleDescription = "Execute";
            this.btn_Execute.Location = new System.Drawing.Point(7, 7);
            this.btn_Execute.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(75, 36);
            this.btn_Execute.TabIndex = 117;
            this.btn_Execute.Text = "Execute";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.btn_Execute_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(355, 7);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 101;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(276, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 100;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Copy
            // 
            this.btn_Copy.AccessibleDescription = "Copy";
            this.btn_Copy.ForeColor = System.Drawing.Color.Navy;
            this.btn_Copy.Location = new System.Drawing.Point(350, 32);
            this.btn_Copy.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(75, 36);
            this.btn_Copy.TabIndex = 135;
            this.btn_Copy.Text = "Copy";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "";
            this.label3.Location = new System.Drawing.Point(296, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 134;
            this.label3.Text = "(ul)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.Location = new System.Drawing.Point(84, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 133;
            this.label2.Text = "(ul)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Head B";
            this.label1.Location = new System.Drawing.Point(217, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 131;
            this.label1.Text = "Head B";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadBVolComp
            // 
            this.lbl_HeadBVolComp.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadBVolComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadBVolComp.Location = new System.Drawing.Point(350, 5);
            this.lbl_HeadBVolComp.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadBVolComp.Name = "lbl_HeadBVolComp";
            this.lbl_HeadBVolComp.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadBVolComp.TabIndex = 132;
            this.lbl_HeadBVolComp.Text = "label2";
            this.lbl_HeadBVolComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadBVolComp.Click += new System.EventHandler(this.lbl_HeadBVolComp_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Head A";
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Head A";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadAVolComp
            // 
            this.lbl_HeadAVolComp.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadAVolComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadAVolComp.Location = new System.Drawing.Point(138, 5);
            this.lbl_HeadAVolComp.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadAVolComp.Name = "lbl_HeadAVolComp";
            this.lbl_HeadAVolComp.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadAVolComp.TabIndex = 114;
            this.lbl_HeadAVolComp.Text = "label11";
            this.lbl_HeadAVolComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadAVolComp.Click += new System.EventHandler(this.lbl_HeadAVolComp_Click);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "";
            this.label5.Location = new System.Drawing.Point(296, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 23);
            this.label5.TabIndex = 141;
            this.label5.Text = "(mg)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.Location = new System.Drawing.Point(84, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 23);
            this.label6.TabIndex = 140;
            this.label6.Text = "(mg)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Head B";
            this.label7.Location = new System.Drawing.Point(217, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 138;
            this.label7.Text = "Head B";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadBWeightComp
            // 
            this.lbl_HeadBWeightComp.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadBWeightComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadBWeightComp.Location = new System.Drawing.Point(350, 5);
            this.lbl_HeadBWeightComp.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadBWeightComp.Name = "lbl_HeadBWeightComp";
            this.lbl_HeadBWeightComp.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadBWeightComp.TabIndex = 139;
            this.lbl_HeadBWeightComp.Text = "label2";
            this.lbl_HeadBWeightComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadBWeightComp.Click += new System.EventHandler(this.lbl_HeadBWeightComp_Click);
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "Head A";
            this.label9.Location = new System.Drawing.Point(5, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 23);
            this.label9.TabIndex = 136;
            this.label9.Text = "Head A";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadAWeightComp
            // 
            this.lbl_HeadAWeightComp.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadAWeightComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadAWeightComp.Location = new System.Drawing.Point(138, 5);
            this.lbl_HeadAWeightComp.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadAWeightComp.Name = "lbl_HeadAWeightComp";
            this.lbl_HeadAWeightComp.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadAWeightComp.TabIndex = 137;
            this.lbl_HeadAWeightComp.Text = "label11";
            this.lbl_HeadAWeightComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadAWeightComp.Click += new System.EventHandler(this.lbl_HeadAWeightComp_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpage_Volume);
            this.tabControl1.Controls.Add(this.tpage_Weight);
            this.tabControl1.Location = new System.Drawing.Point(8, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 105);
            this.tabControl1.TabIndex = 137;
            // 
            // tpage_Volume
            // 
            this.tpage_Volume.AccessibleDescription = "Volume";
            this.tpage_Volume.BackColor = System.Drawing.SystemColors.Control;
            this.tpage_Volume.Controls.Add(this.btn_Copy);
            this.tpage_Volume.Controls.Add(this.label4);
            this.tpage_Volume.Controls.Add(this.label3);
            this.tpage_Volume.Controls.Add(this.lbl_HeadAVolComp);
            this.tpage_Volume.Controls.Add(this.label2);
            this.tpage_Volume.Controls.Add(this.lbl_HeadBVolComp);
            this.tpage_Volume.Controls.Add(this.label1);
            this.tpage_Volume.Location = new System.Drawing.Point(4, 23);
            this.tpage_Volume.Name = "tpage_Volume";
            this.tpage_Volume.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Volume.Size = new System.Drawing.Size(431, 78);
            this.tpage_Volume.TabIndex = 0;
            this.tpage_Volume.Text = "Volume";
            // 
            // tpage_Weight
            // 
            this.tpage_Weight.AccessibleDescription = "Weight";
            this.tpage_Weight.BackColor = System.Drawing.SystemColors.Control;
            this.tpage_Weight.Controls.Add(this.lbl_TargetWeight);
            this.tpage_Weight.Controls.Add(this.btn_CopyW);
            this.tpage_Weight.Controls.Add(this.label7);
            this.tpage_Weight.Controls.Add(this.label5);
            this.tpage_Weight.Controls.Add(this.label9);
            this.tpage_Weight.Controls.Add(this.label6);
            this.tpage_Weight.Controls.Add(this.lbl_HeadBWeightComp);
            this.tpage_Weight.Controls.Add(this.lbl_HeadAWeightComp);
            this.tpage_Weight.Location = new System.Drawing.Point(4, 23);
            this.tpage_Weight.Name = "tpage_Weight";
            this.tpage_Weight.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Weight.Size = new System.Drawing.Size(431, 78);
            this.tpage_Weight.TabIndex = 1;
            this.tpage_Weight.Text = "Weight";
            // 
            // btn_CopyW
            // 
            this.btn_CopyW.AccessibleDescription = "Copy";
            this.btn_CopyW.Location = new System.Drawing.Point(350, 32);
            this.btn_CopyW.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CopyW.Name = "btn_CopyW";
            this.btn_CopyW.Size = new System.Drawing.Size(75, 36);
            this.btn_CopyW.TabIndex = 142;
            this.btn_CopyW.Text = "Copy";
            this.btn_CopyW.UseVisualStyleBackColor = true;
            this.btn_CopyW.Click += new System.EventHandler(this.btn_CopyW_Click);
            // 
            // lbox_Cond
            // 
            this.lbox_Cond.FormattingEnabled = true;
            this.lbox_Cond.ItemHeight = 14;
            this.lbox_Cond.Location = new System.Drawing.Point(8, 8);
            this.lbox_Cond.Name = "lbox_Cond";
            this.lbox_Cond.Size = new System.Drawing.Size(437, 46);
            this.lbox_Cond.TabIndex = 139;
            // 
            // btn_Cond
            // 
            this.btn_Cond.AccessibleDescription = "Cond";
            this.btn_Cond.Location = new System.Drawing.Point(368, 59);
            this.btn_Cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cond.Name = "btn_Cond";
            this.btn_Cond.Size = new System.Drawing.Size(75, 36);
            this.btn_Cond.TabIndex = 138;
            this.btn_Cond.Text = "Cond";
            this.btn_Cond.UseVisualStyleBackColor = true;
            this.btn_Cond.Click += new System.EventHandler(this.btn_Cond_Click);
            // 
            // lbl_TargetWeight
            // 
            this.lbl_TargetWeight.AccessibleDescription = "";
            this.lbl_TargetWeight.Location = new System.Drawing.Point(5, 50);
            this.lbl_TargetWeight.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TargetWeight.Name = "lbl_TargetWeight";
            this.lbl_TargetWeight.Size = new System.Drawing.Size(317, 23);
            this.lbl_TargetWeight.TabIndex = 143;
            this.lbl_TargetWeight.Text = "Target Weight";
            this.lbl_TargetWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_DispCore_DispProg_PPVolComp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(494, 317);
            this.ControlBox = false;
            this.Controls.Add(this.lbox_Cond);
            this.Controls.Add(this.btn_Cond);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frm_DispCore_DispProg_PPVolComp";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_PPVolComp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_PPVolComp_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_PPVolComp_Load);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpage_Volume.ResumeLayout(false);
            this.tpage_Weight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_HeadBVolComp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_HeadAVolComp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_HeadBWeightComp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_HeadAWeightComp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpage_Volume;
        private System.Windows.Forms.TabPage tpage_Weight;
        private System.Windows.Forms.Button btn_CopyW;
        private System.Windows.Forms.ListBox lbox_Cond;
        private System.Windows.Forms.Button btn_Cond;
        private System.Windows.Forms.Label lbl_TargetWeight;
    }
}