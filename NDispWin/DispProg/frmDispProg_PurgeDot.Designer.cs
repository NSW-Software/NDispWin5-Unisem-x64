namespace NDispWin
{
    partial class frm_DispCore_DispProg_PurgeDot
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Position = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Dispense = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._lbl_Dispense = new System.Windows.Forms.Label();
            this.btn_EditModel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.lbl_ModelNo = new System.Windows.Forms.Label();
            this.lbl_HeadNo = new System.Windows.Forms.Label();
            this.gbox_Pos = new System.Windows.Forms.GroupBox();
            this.pnl_X2Y2Z2 = new System.Windows.Forms.Panel();
            this.lbl_Z2 = new System.Windows.Forms.Label();
            this.lbl_X2 = new System.Windows.Forms.Label();
            this.lbl_Y2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_Z1 = new System.Windows.Forms.Label();
            this.lbl_Y1 = new System.Windows.Forms.Label();
            this.btn_GotoPt1Pos = new System.Windows.Forms.Button();
            this.lbl_X1 = new System.Windows.Forms.Label();
            this.btn_SetPt1Pos = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cond = new System.Windows.Forms.Button();
            this.lbox_Cond = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.gbox_Pos.SuspendLayout();
            this.pnl_X2Y2Z2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Position);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_Dispense);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._lbl_Dispense);
            this.panel1.Controls.Add(this.btn_EditModel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_Mode);
            this.panel1.Controls.Add(this.lbl_ModelNo);
            this.panel1.Controls.Add(this.lbl_HeadNo);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(429, 118);
            this.panel1.TabIndex = 132;
            // 
            // lbl_Position
            // 
            this.lbl_Position.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Position.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Position.Location = new System.Drawing.Point(111, 88);
            this.lbl_Position.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Position.Name = "lbl_Position";
            this.lbl_Position.Size = new System.Drawing.Size(75, 23);
            this.lbl_Position.TabIndex = 132;
            this.lbl_Position.Text = "lbl_Position";
            this.lbl_Position.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Position.Click += new System.EventHandler(this.lbl_Position_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Position";
            this.label8.Location = new System.Drawing.Point(7, 88);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 131;
            this.label8.Text = "Position";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Head No";
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Head No";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Dispense
            // 
            this.lbl_Dispense.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Dispense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Dispense.Location = new System.Drawing.Point(347, 7);
            this.lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Dispense.Name = "lbl_Dispense";
            this.lbl_Dispense.Size = new System.Drawing.Size(75, 23);
            this.lbl_Dispense.TabIndex = 130;
            this.lbl_Dispense.Text = "TRUE";
            this.lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Dispense.Click += new System.EventHandler(this.lbl_Dispense_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Model No";
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Model No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lbl_Dispense
            // 
            this._lbl_Dispense.AccessibleDescription = "Dispense";
            this._lbl_Dispense.Location = new System.Drawing.Point(268, 7);
            this._lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this._lbl_Dispense.Name = "_lbl_Dispense";
            this._lbl_Dispense.Size = new System.Drawing.Size(75, 23);
            this._lbl_Dispense.TabIndex = 129;
            this._lbl_Dispense.Text = "Dispense";
            this._lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_EditModel
            // 
            this.btn_EditModel.AccessibleDescription = "Edit";
            this.btn_EditModel.Location = new System.Drawing.Point(190, 34);
            this.btn_EditModel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EditModel.Name = "btn_EditModel";
            this.btn_EditModel.Size = new System.Drawing.Size(75, 23);
            this.btn_EditModel.TabIndex = 3;
            this.btn_EditModel.Text = "Edit";
            this.btn_EditModel.UseVisualStyleBackColor = true;
            this.btn_EditModel.Click += new System.EventHandler(this.btn_EditModel_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Mode";
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Mode.Location = new System.Drawing.Point(111, 61);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(75, 23);
            this.lbl_Mode.TabIndex = 112;
            this.lbl_Mode.Text = "lbl_Mode";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Mode.Click += new System.EventHandler(this.lbl_Mode_Click);
            // 
            // lbl_ModelNo
            // 
            this.lbl_ModelNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_ModelNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ModelNo.Location = new System.Drawing.Point(111, 34);
            this.lbl_ModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ModelNo.Name = "lbl_ModelNo";
            this.lbl_ModelNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_ModelNo.TabIndex = 113;
            this.lbl_ModelNo.Text = "lbl_ModelNo";
            this.lbl_ModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_ModelNo.Click += new System.EventHandler(this.lbl_ModelNo_Click);
            // 
            // lbl_HeadNo
            // 
            this.lbl_HeadNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadNo.Location = new System.Drawing.Point(111, 7);
            this.lbl_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadNo.Name = "lbl_HeadNo";
            this.lbl_HeadNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadNo.TabIndex = 114;
            this.lbl_HeadNo.Text = "lbl_HeadNo";
            this.lbl_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadNo.Click += new System.EventHandler(this.lbl_HeadNo_Click);
            // 
            // gbox_Pos
            // 
            this.gbox_Pos.AccessibleDescription = "Position";
            this.gbox_Pos.AutoSize = true;
            this.gbox_Pos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Pos.Controls.Add(this.pnl_X2Y2Z2);
            this.gbox_Pos.Controls.Add(this.lbl_Z1);
            this.gbox_Pos.Controls.Add(this.lbl_Y1);
            this.gbox_Pos.Controls.Add(this.btn_GotoPt1Pos);
            this.gbox_Pos.Controls.Add(this.lbl_X1);
            this.gbox_Pos.Controls.Add(this.btn_SetPt1Pos);
            this.gbox_Pos.Controls.Add(this.label5);
            this.gbox_Pos.Location = new System.Drawing.Point(7, 201);
            this.gbox_Pos.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Pos.Name = "gbox_Pos";
            this.gbox_Pos.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_Pos.Size = new System.Drawing.Size(430, 129);
            this.gbox_Pos.TabIndex = 133;
            this.gbox_Pos.TabStop = false;
            this.gbox_Pos.Text = "Position";
            // 
            // pnl_X2Y2Z2
            // 
            this.pnl_X2Y2Z2.AutoSize = true;
            this.pnl_X2Y2Z2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_X2Y2Z2.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_X2Y2Z2.Controls.Add(this.lbl_Z2);
            this.pnl_X2Y2Z2.Controls.Add(this.lbl_X2);
            this.pnl_X2Y2Z2.Controls.Add(this.lbl_Y2);
            this.pnl_X2Y2Z2.Controls.Add(this.label10);
            this.pnl_X2Y2Z2.Location = new System.Drawing.Point(5, 47);
            this.pnl_X2Y2Z2.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_X2Y2Z2.Name = "pnl_X2Y2Z2";
            this.pnl_X2Y2Z2.Size = new System.Drawing.Size(341, 27);
            this.pnl_X2Y2Z2.TabIndex = 116;
            // 
            // lbl_Z2
            // 
            this.lbl_Z2.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Z2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Z2.Location = new System.Drawing.Point(264, 2);
            this.lbl_Z2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Z2.Name = "lbl_Z2";
            this.lbl_Z2.Size = new System.Drawing.Size(75, 23);
            this.lbl_Z2.TabIndex = 115;
            this.lbl_Z2.Text = "-999.999";
            this.lbl_Z2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Z2.Click += new System.EventHandler(this.lbl_Z2_Click);
            // 
            // lbl_X2
            // 
            this.lbl_X2.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_X2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X2.Location = new System.Drawing.Point(106, 2);
            this.lbl_X2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X2.Name = "lbl_X2";
            this.lbl_X2.Size = new System.Drawing.Size(75, 23);
            this.lbl_X2.TabIndex = 113;
            this.lbl_X2.Text = "-999.999";
            this.lbl_X2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_X2.Click += new System.EventHandler(this.lbl_X2_Click);
            // 
            // lbl_Y2
            // 
            this.lbl_Y2.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Y2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Y2.Location = new System.Drawing.Point(185, 2);
            this.lbl_Y2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Y2.Name = "lbl_Y2";
            this.lbl_Y2.Size = new System.Drawing.Size(75, 23);
            this.lbl_Y2.TabIndex = 114;
            this.lbl_Y2.Text = "-999.999";
            this.lbl_Y2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Y2.Click += new System.EventHandler(this.lbl_Y2_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(2, 2);
            this.label10.Margin = new System.Windows.Forms.Padding(2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 23);
            this.label10.TabIndex = 112;
            this.label10.Text = "X2, Y2, Z2 (mm)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Z1
            // 
            this.lbl_Z1.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Z1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Z1.Location = new System.Drawing.Point(269, 22);
            this.lbl_Z1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Z1.Name = "lbl_Z1";
            this.lbl_Z1.Size = new System.Drawing.Size(75, 23);
            this.lbl_Z1.TabIndex = 111;
            this.lbl_Z1.Text = "-999.999";
            this.lbl_Z1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Z1.Click += new System.EventHandler(this.lbl_Z1_Click);
            // 
            // lbl_Y1
            // 
            this.lbl_Y1.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Y1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Y1.Location = new System.Drawing.Point(190, 22);
            this.lbl_Y1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Y1.Name = "lbl_Y1";
            this.lbl_Y1.Size = new System.Drawing.Size(75, 23);
            this.lbl_Y1.TabIndex = 110;
            this.lbl_Y1.Text = "-999.999";
            this.lbl_Y1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Y1.Click += new System.EventHandler(this.lbl_Y1_Click);
            // 
            // btn_GotoPt1Pos
            // 
            this.btn_GotoPt1Pos.AccessibleDescription = "Goto";
            this.btn_GotoPt1Pos.Location = new System.Drawing.Point(348, 76);
            this.btn_GotoPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoPt1Pos.Name = "btn_GotoPt1Pos";
            this.btn_GotoPt1Pos.Size = new System.Drawing.Size(75, 36);
            this.btn_GotoPt1Pos.TabIndex = 8;
            this.btn_GotoPt1Pos.Text = "Goto";
            this.btn_GotoPt1Pos.UseVisualStyleBackColor = true;
            this.btn_GotoPt1Pos.Click += new System.EventHandler(this.btn_GotoPt1Pos_Click);
            // 
            // lbl_X1
            // 
            this.lbl_X1.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_X1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X1.Location = new System.Drawing.Point(111, 22);
            this.lbl_X1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X1.Name = "lbl_X1";
            this.lbl_X1.Size = new System.Drawing.Size(75, 23);
            this.lbl_X1.TabIndex = 109;
            this.lbl_X1.Text = "-999.999";
            this.lbl_X1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_X1.Click += new System.EventHandler(this.lbl_X1_Click);
            // 
            // btn_SetPt1Pos
            // 
            this.btn_SetPt1Pos.AccessibleDescription = "Set";
            this.btn_SetPt1Pos.Location = new System.Drawing.Point(269, 76);
            this.btn_SetPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPt1Pos.Name = "btn_SetPt1Pos";
            this.btn_SetPt1Pos.Size = new System.Drawing.Size(75, 36);
            this.btn_SetPt1Pos.TabIndex = 7;
            this.btn_SetPt1Pos.Text = "Set";
            this.btn_SetPt1Pos.UseVisualStyleBackColor = true;
            this.btn_SetPt1Pos.Click += new System.EventHandler(this.btn_SetPt1Pos_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "X, Y, Z (mm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.btn_Execute);
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Controls.Add(this.btn_OK);
            this.panel3.Location = new System.Drawing.Point(7, 334);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(430, 50);
            this.panel3.TabIndex = 134;
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
            this.btn_Cancel.Location = new System.Drawing.Point(348, 7);
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
            this.btn_OK.Location = new System.Drawing.Point(269, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 100;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cond
            // 
            this.btn_Cond.AccessibleDescription = "Cond";
            this.btn_Cond.Location = new System.Drawing.Point(362, 130);
            this.btn_Cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cond.Name = "btn_Cond";
            this.btn_Cond.Size = new System.Drawing.Size(75, 36);
            this.btn_Cond.TabIndex = 169;
            this.btn_Cond.Text = "Cond";
            this.btn_Cond.UseVisualStyleBackColor = true;
            this.btn_Cond.Click += new System.EventHandler(this.btn_Cond_Click);
            // 
            // lbox_Cond
            // 
            this.lbox_Cond.FormattingEnabled = true;
            this.lbox_Cond.ItemHeight = 14;
            this.lbox_Cond.Location = new System.Drawing.Point(7, 130);
            this.lbox_Cond.Name = "lbox_Cond";
            this.lbox_Cond.Size = new System.Drawing.Size(350, 32);
            this.lbox_Cond.TabIndex = 170;
            // 
            // frm_DispCore_DispProg_PurgeDot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(524, 402);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cond);
            this.Controls.Add(this.lbox_Cond);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.gbox_Pos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_PurgeDot";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_PurgeDot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_PurgeDot_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_PurgeDot_Load);
            this.panel1.ResumeLayout(false);
            this.gbox_Pos.ResumeLayout(false);
            this.gbox_Pos.PerformLayout();
            this.pnl_X2Y2Z2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Dispense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lbl_Dispense;
        private System.Windows.Forms.Button btn_EditModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label lbl_ModelNo;
        private System.Windows.Forms.Label lbl_HeadNo;
        private System.Windows.Forms.GroupBox gbox_Pos;
        private System.Windows.Forms.Label lbl_Y1;
        private System.Windows.Forms.Button btn_GotoPt1Pos;
        private System.Windows.Forms.Label lbl_X1;
        private System.Windows.Forms.Button btn_SetPt1Pos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Position;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Z1;
        private System.Windows.Forms.Panel pnl_X2Y2Z2;
        private System.Windows.Forms.Label lbl_Z2;
        private System.Windows.Forms.Label lbl_X2;
        private System.Windows.Forms.Label lbl_Y2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.Button btn_Cond;
        private System.Windows.Forms.ListBox lbox_Cond;
    }
}