namespace NDispWin
{
    partial class frm_DispCore_DispProg_ReadID
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
            this.gbox_Pos1 = new System.Windows.Forms.GroupBox();
            this.lbl_X1Y1 = new System.Windows.Forms.Label();
            this.btn_GotoXY = new System.Windows.Forms.Button();
            this.btn_SetPt1Pos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Exec = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_SettleTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbox_Enabled = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lbl_FocusNo = new System.Windows.Forms.Label();
            this.gbox_Pos1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(330, 244);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 24;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(249, 244);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 23;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // gbox_Pos1
            // 
            this.gbox_Pos1.AccessibleDescription = "Position";
            this.gbox_Pos1.AutoSize = true;
            this.gbox_Pos1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Pos1.Controls.Add(this.lbl_X1Y1);
            this.gbox_Pos1.Controls.Add(this.btn_GotoXY);
            this.gbox_Pos1.Controls.Add(this.btn_SetPt1Pos);
            this.gbox_Pos1.Controls.Add(this.label1);
            this.gbox_Pos1.Location = new System.Drawing.Point(4, 61);
            this.gbox_Pos1.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Pos1.Name = "gbox_Pos1";
            this.gbox_Pos1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_Pos1.Size = new System.Drawing.Size(401, 73);
            this.gbox_Pos1.TabIndex = 20;
            this.gbox_Pos1.TabStop = false;
            this.gbox_Pos1.Text = "Position";
            // 
            // lbl_X1Y1
            // 
            this.lbl_X1Y1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X1Y1.Location = new System.Drawing.Point(86, 26);
            this.lbl_X1Y1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X1Y1.Name = "lbl_X1Y1";
            this.lbl_X1Y1.Size = new System.Drawing.Size(175, 23);
            this.lbl_X1Y1.TabIndex = 5;
            this.lbl_X1Y1.Text = "lbl_X1Y1";
            this.lbl_X1Y1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_GotoXY
            // 
            this.btn_GotoXY.AccessibleDescription = "Pox XY";
            this.btn_GotoXY.Location = new System.Drawing.Point(319, 22);
            this.btn_GotoXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoXY.Name = "btn_GotoXY";
            this.btn_GotoXY.Size = new System.Drawing.Size(75, 30);
            this.btn_GotoXY.TabIndex = 4;
            this.btn_GotoXY.Text = "Goto";
            this.btn_GotoXY.UseVisualStyleBackColor = true;
            this.btn_GotoXY.Click += new System.EventHandler(this.btn_GotoPt1Pos_Click);
            // 
            // btn_SetPt1Pos
            // 
            this.btn_SetPt1Pos.AccessibleDescription = "Set";
            this.btn_SetPt1Pos.Location = new System.Drawing.Point(265, 22);
            this.btn_SetPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPt1Pos.Name = "btn_SetPt1Pos";
            this.btn_SetPt1Pos.Size = new System.Drawing.Size(50, 30);
            this.btn_SetPt1Pos.TabIndex = 3;
            this.btn_SetPt1Pos.Text = "Set";
            this.btn_SetPt1Pos.UseVisualStyleBackColor = true;
            this.btn_SetPt1Pos.Click += new System.EventHandler(this.btn_SetPt1Pos_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "(mm)";
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Position";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Exec
            // 
            this.btn_Exec.AccessibleDescription = "Exec";
            this.btn_Exec.Location = new System.Drawing.Point(7, 244);
            this.btn_Exec.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.btn_Exec.Name = "btn_Exec";
            this.btn_Exec.Size = new System.Drawing.Size(75, 36);
            this.btn_Exec.TabIndex = 13;
            this.btn_Exec.Text = "Exec";
            this.btn_Exec.UseVisualStyleBackColor = true;
            this.btn_Exec.Click += new System.EventHandler(this.btn_Exec_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Setting";
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lbl_SettleTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(7, 174);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox1.Size = new System.Drawing.Size(398, 66);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // lbl_SettleTime
            // 
            this.lbl_SettleTime.BackColor = System.Drawing.Color.White;
            this.lbl_SettleTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SettleTime.Location = new System.Drawing.Point(165, 22);
            this.lbl_SettleTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SettleTime.Name = "lbl_SettleTime";
            this.lbl_SettleTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_SettleTime.TabIndex = 29;
            this.lbl_SettleTime.Text = "0";
            this.lbl_SettleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_SettleTime.Click += new System.EventHandler(this.lbl_SettleTime_Click);
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "Settle Time (ms)";
            this.label10.Location = new System.Drawing.Point(7, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "Settle Time (ms)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Result
            // 
            this.lbl_Result.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Result.Location = new System.Drawing.Point(95, 143);
            this.lbl_Result.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(224, 23);
            this.lbl_Result.TabIndex = 31;
            this.lbl_Result.Text = "0";
            this.lbl_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Result";
            this.label4.Location = new System.Drawing.Point(11, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 30;
            this.label4.Text = "Result";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ID
            // 
            this.lbl_ID.BackColor = System.Drawing.Color.White;
            this.lbl_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ID.Location = new System.Drawing.Point(88, 4);
            this.lbl_ID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(75, 23);
            this.lbl_ID.TabIndex = 45;
            this.lbl_ID.Text = "lbl_ID";
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ID.Click += new System.EventHandler(this.lbl_ID_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "ID";
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 46;
            this.button1.Text = "Read";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_ReadID_Click);
            // 
            // cbox_Enabled
            // 
            this.cbox_Enabled.AutoSize = true;
            this.cbox_Enabled.Location = new System.Drawing.Point(168, 7);
            this.cbox_Enabled.Name = "cbox_Enabled";
            this.cbox_Enabled.Size = new System.Drawing.Size(72, 22);
            this.cbox_Enabled.TabIndex = 220;
            this.cbox_Enabled.Text = "Enable";
            this.cbox_Enabled.UseVisualStyleBackColor = true;
            this.cbox_Enabled.Click += new System.EventHandler(this.cbox_Enabled_Click);
            // 
            // label19
            // 
            this.label19.AccessibleDescription = "Focus No";
            this.label19.Location = new System.Drawing.Point(4, 31);
            this.label19.Margin = new System.Windows.Forms.Padding(2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 23);
            this.label19.TabIndex = 222;
            this.label19.Text = "Focus No";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FocusNo
            // 
            this.lbl_FocusNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_FocusNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FocusNo.Location = new System.Drawing.Point(88, 31);
            this.lbl_FocusNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FocusNo.Name = "lbl_FocusNo";
            this.lbl_FocusNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_FocusNo.TabIndex = 223;
            this.lbl_FocusNo.Text = "0";
            this.lbl_FocusNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FocusNo.Click += new System.EventHandler(this.lbl_FocusNo_Click);
            // 
            // frm_DispCore_DispProg_ReadID
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(419, 298);
            this.ControlBox = false;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Exec);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_FocusNo);
            this.Controls.Add(this.lbl_Result);
            this.Controls.Add(this.cbox_Enabled);
            this.Controls.Add(this.lbl_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbox_Pos1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_ReadID";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "frmDispProg_ReadID";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_ReadID_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_ReadID_Load);
            this.gbox_Pos1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox gbox_Pos1;
        private System.Windows.Forms.Label lbl_X1Y1;
        private System.Windows.Forms.Button btn_GotoXY;
        private System.Windows.Forms.Button btn_SetPt1Pos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Exec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.Label lbl_SettleTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbox_Enabled;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_FocusNo;
    }
}