namespace NDispWin
{
    partial class frmDispProg_ExtVis
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_Z = new System.Windows.Forms.Label();
            this.lbl_Y = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_X = new System.Windows.Forms.Label();
            this.btn_Goto = new System.Windows.Forms.Button();
            this.btn_Set = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpage_Settings = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_SettleTime = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpage_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Position";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.lbl_Z);
            this.groupBox2.Controls.Add(this.lbl_Y);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbl_X);
            this.groupBox2.Controls.Add(this.btn_Goto);
            this.groupBox2.Controls.Add(this.btn_Set);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox2.Size = new System.Drawing.Size(450, 88);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position";
            // 
            // lbl_Z
            // 
            this.lbl_Z.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Z.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Z.Location = new System.Drawing.Point(131, 48);
            this.lbl_Z.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Z.Name = "lbl_Z";
            this.lbl_Z.Size = new System.Drawing.Size(75, 23);
            this.lbl_Z.TabIndex = 118;
            this.lbl_Z.Text = "-999.999";
            this.lbl_Z.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Z.Click += new System.EventHandler(this.lbl_Z_Click);
            // 
            // lbl_Y
            // 
            this.lbl_Y.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Y.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Y.Location = new System.Drawing.Point(210, 21);
            this.lbl_Y.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(75, 23);
            this.lbl_Y.TabIndex = 108;
            this.lbl_Y.Text = "9.999";
            this.lbl_Y.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Y.Click += new System.EventHandler(this.lbl_Y_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 115;
            this.label1.Text = "X, Y (mm)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_X
            // 
            this.lbl_X.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_X.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X.Location = new System.Drawing.Point(131, 21);
            this.lbl_X.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(75, 23);
            this.lbl_X.TabIndex = 107;
            this.lbl_X.Text = "-999.999";
            this.lbl_X.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_X.Click += new System.EventHandler(this.lbl_X_Click);
            // 
            // btn_Goto
            // 
            this.btn_Goto.AccessibleDescription = "Goto";
            this.btn_Goto.Location = new System.Drawing.Point(368, 15);
            this.btn_Goto.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Goto.Name = "btn_Goto";
            this.btn_Goto.Size = new System.Drawing.Size(75, 36);
            this.btn_Goto.TabIndex = 117;
            this.btn_Goto.Text = "Goto";
            this.btn_Goto.UseVisualStyleBackColor = true;
            this.btn_Goto.Click += new System.EventHandler(this.btn_Goto_Click);
            // 
            // btn_Set
            // 
            this.btn_Set.AccessibleDescription = "Set";
            this.btn_Set.Location = new System.Drawing.Point(289, 15);
            this.btn_Set.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(75, 36);
            this.btn_Set.TabIndex = 5;
            this.btn_Set.Text = "Set";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Z (mm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.btn_Execute);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Location = new System.Drawing.Point(5, 171);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(450, 50);
            this.panel2.TabIndex = 126;
            // 
            // btn_Execute
            // 
            this.btn_Execute.AccessibleDescription = "Execute";
            this.btn_Execute.Location = new System.Drawing.Point(7, 7);
            this.btn_Execute.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(75, 36);
            this.btn_Execute.TabIndex = 104;
            this.btn_Execute.Text = "Execute";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.btn_Execute_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(368, 7);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 103;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(289, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 102;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpage_Settings);
            this.tabControl1.Location = new System.Drawing.Point(5, 98);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 68);
            this.tabControl1.TabIndex = 127;
            // 
            // tpage_Settings
            // 
            this.tpage_Settings.BackColor = System.Drawing.SystemColors.Control;
            this.tpage_Settings.Controls.Add(this.label12);
            this.tpage_Settings.Controls.Add(this.lbl_SettleTime);
            this.tpage_Settings.Location = new System.Drawing.Point(4, 23);
            this.tpage_Settings.Name = "tpage_Settings";
            this.tpage_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Settings.Size = new System.Drawing.Size(442, 41);
            this.tpage_Settings.TabIndex = 0;
            this.tpage_Settings.Text = "Settings";
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Settle Time (ms)";
            this.label12.Location = new System.Drawing.Point(5, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 23);
            this.label12.TabIndex = 159;
            this.label12.Text = "Settle Time (ms)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SettleTime
            // 
            this.lbl_SettleTime.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_SettleTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SettleTime.Location = new System.Drawing.Point(132, 5);
            this.lbl_SettleTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SettleTime.Name = "lbl_SettleTime";
            this.lbl_SettleTime.Size = new System.Drawing.Size(50, 23);
            this.lbl_SettleTime.TabIndex = 160;
            this.lbl_SettleTime.Text = "0";
            this.lbl_SettleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_SettleTime.Click += new System.EventHandler(this.lbl_SettleTime_Click);
            // 
            // frmDispProg_ExtVis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(469, 250);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmDispProg_ExtVis";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmDispProg_ExtVis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDispProg_ExtVis_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_ExtVis_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpage_Settings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_Z;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Button btn_Goto;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpage_Settings;
        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_SettleTime;
    }
}