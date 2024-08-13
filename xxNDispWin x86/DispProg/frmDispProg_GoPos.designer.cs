namespace NDispWin
{
    partial class frm_DispCore_DispProg_GoPos
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
            this.lbl_Y = new System.Windows.Forms.Label();
            this.lbl_X = new System.Windows.Forms.Label();
            this.btn_Set = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Goto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnl_X2Y2Z2 = new System.Windows.Forms.Panel();
            this.lbl_Z2 = new System.Windows.Forms.Label();
            this.lbl_Y2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_X2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_Z = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.pnl_X2Y2Z2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Position";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.pnl_X2Y2Z2);
            this.groupBox2.Controls.Add(this.lbl_Z);
            this.groupBox2.Controls.Add(this.lbl_Y);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbl_X);
            this.groupBox2.Controls.Add(this.btn_Goto);
            this.groupBox2.Controls.Add(this.btn_Set);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox2.Size = new System.Drawing.Size(450, 152);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // pnl_X2Y2Z2
            // 
            this.pnl_X2Y2Z2.AutoSize = true;
            this.pnl_X2Y2Z2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_X2Y2Z2.Controls.Add(this.lbl_Z2);
            this.pnl_X2Y2Z2.Controls.Add(this.lbl_Y2);
            this.pnl_X2Y2Z2.Controls.Add(this.label7);
            this.pnl_X2Y2Z2.Controls.Add(this.lbl_X2);
            this.pnl_X2Y2Z2.Controls.Add(this.label9);
            this.pnl_X2Y2Z2.Location = new System.Drawing.Point(8, 76);
            this.pnl_X2Y2Z2.Name = "pnl_X2Y2Z2";
            this.pnl_X2Y2Z2.Size = new System.Drawing.Size(279, 54);
            this.pnl_X2Y2Z2.TabIndex = 119;
            // 
            // lbl_Z2
            // 
            this.lbl_Z2.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Z2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Z2.Location = new System.Drawing.Point(123, 29);
            this.lbl_Z2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Z2.Name = "lbl_Z2";
            this.lbl_Z2.Size = new System.Drawing.Size(75, 23);
            this.lbl_Z2.TabIndex = 125;
            this.lbl_Z2.Text = "-999.999";
            this.lbl_Z2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Z2.Click += new System.EventHandler(this.lbl_Z2_Click);
            // 
            // lbl_Y2
            // 
            this.lbl_Y2.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Y2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Y2.Location = new System.Drawing.Point(202, 2);
            this.lbl_Y2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Y2.Name = "lbl_Y2";
            this.lbl_Y2.Size = new System.Drawing.Size(75, 23);
            this.lbl_Y2.TabIndex = 122;
            this.lbl_Y2.Text = "9.999";
            this.lbl_Y2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Y2.Click += new System.EventHandler(this.lbl_Y2_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "";
            this.label7.Location = new System.Drawing.Point(-1, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 23);
            this.label7.TabIndex = 123;
            this.label7.Text = "X2, Y2 (mm)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_X2
            // 
            this.lbl_X2.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_X2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X2.Location = new System.Drawing.Point(123, 2);
            this.lbl_X2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X2.Name = "lbl_X2";
            this.lbl_X2.Size = new System.Drawing.Size(75, 23);
            this.lbl_X2.TabIndex = 121;
            this.lbl_X2.Text = "-999.999";
            this.lbl_X2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_X2.Click += new System.EventHandler(this.lbl_X2_Click);
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "";
            this.label9.Location = new System.Drawing.Point(-1, 29);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 23);
            this.label9.TabIndex = 120;
            this.label9.Text = "Z2 (mm)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Location = new System.Drawing.Point(6, 222);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(450, 50);
            this.panel2.TabIndex = 125;
            // 
            // frm_DispCore_DispProg_GoPos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(469, 281);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_GoPos";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_GoPos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_GoPos_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_MoveLine_Load);
            this.Shown += new System.EventHandler(this.frmDispProg_MoveLine_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmDispProg_MoveLine_VisibleChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnl_X2Y2Z2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Button btn_Goto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Z;
        private System.Windows.Forms.Panel pnl_X2Y2Z2;
        private System.Windows.Forms.Label lbl_Z2;
        private System.Windows.Forms.Label lbl_Y2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_X2;
        private System.Windows.Forms.Label label9;
    }
}