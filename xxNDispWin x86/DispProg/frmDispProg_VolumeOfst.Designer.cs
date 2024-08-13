namespace NDispWin
{
    partial class frm_DispCore_DispProg_VolumeOfst
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
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Path2 = new System.Windows.Forms.Label();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Path = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gbox_PathSetup = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Purge = new System.Windows.Forms.Button();
            this.lbox_Log = new System.Windows.Forms.ListBox();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_Protocol = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.gbox_PathSetup.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Path2";
            this.label3.Location = new System.Drawing.Point(5, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 137;
            this.label3.Text = "Path2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Path2
            // 
            this.lbl_Path2.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Path2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Path2.Location = new System.Drawing.Point(59, 49);
            this.lbl_Path2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Path2.Name = "lbl_Path2";
            this.lbl_Path2.Size = new System.Drawing.Size(361, 23);
            this.lbl_Path2.TabIndex = 138;
            this.lbl_Path2.Text = "lbl_RefType";
            this.lbl_Path2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Path2.Click += new System.EventHandler(this.lbl_Path2_Click);
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Mode.Location = new System.Drawing.Point(59, 76);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(100, 23);
            this.lbl_Mode.TabIndex = 136;
            this.lbl_Mode.Text = "Manual";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Mode.Click += new System.EventHandler(this.lbl_Mode_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Mode";
            this.label2.Location = new System.Drawing.Point(5, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 135;
            this.label2.Text = "Mode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Path";
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Path
            // 
            this.lbl_Path.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Path.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Path.Location = new System.Drawing.Point(59, 20);
            this.lbl_Path.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(361, 23);
            this.lbl_Path.TabIndex = 113;
            this.lbl_Path.Text = "lbl_RefType";
            this.lbl_Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Path.Click += new System.EventHandler(this.lbl_Path_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 392);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(427, 48);
            this.panel2.TabIndex = 140;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(345, 5);
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
            this.btn_OK.Location = new System.Drawing.Point(266, 5);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 100;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // gbox_PathSetup
            // 
            this.gbox_PathSetup.AutoSize = true;
            this.gbox_PathSetup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_PathSetup.Controls.Add(this.label3);
            this.gbox_PathSetup.Controls.Add(this.btn_Clear);
            this.gbox_PathSetup.Controls.Add(this.lbl_Path2);
            this.gbox_PathSetup.Controls.Add(this.btn_Reset);
            this.gbox_PathSetup.Controls.Add(this.lbl_Mode);
            this.gbox_PathSetup.Controls.Add(this.btn_Purge);
            this.gbox_PathSetup.Controls.Add(this.label2);
            this.gbox_PathSetup.Controls.Add(this.lbox_Log);
            this.gbox_PathSetup.Controls.Add(this.label1);
            this.gbox_PathSetup.Controls.Add(this.lbl_Path);
            this.gbox_PathSetup.Controls.Add(this.btn_Execute);
            this.gbox_PathSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox_PathSetup.Location = new System.Drawing.Point(5, 39);
            this.gbox_PathSetup.Name = "gbox_PathSetup";
            this.gbox_PathSetup.Size = new System.Drawing.Size(427, 353);
            this.gbox_PathSetup.TabIndex = 141;
            this.gbox_PathSetup.TabStop = false;
            this.gbox_PathSetup.Enter += new System.EventHandler(this.gbox_PathSetup_Enter);
            // 
            // btn_Clear
            // 
            this.btn_Clear.AccessibleDescription = "Clear";
            this.btn_Clear.Location = new System.Drawing.Point(348, 146);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 24);
            this.btn_Clear.TabIndex = 147;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.AccessibleDescription = "Reset";
            this.btn_Reset.Location = new System.Drawing.Point(266, 104);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 36);
            this.btn_Reset.TabIndex = 146;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Purge
            // 
            this.btn_Purge.AccessibleDescription = "Purge";
            this.btn_Purge.Location = new System.Drawing.Point(347, 104);
            this.btn_Purge.Name = "btn_Purge";
            this.btn_Purge.Size = new System.Drawing.Size(75, 36);
            this.btn_Purge.TabIndex = 145;
            this.btn_Purge.Text = "Purge";
            this.btn_Purge.UseVisualStyleBackColor = true;
            this.btn_Purge.Click += new System.EventHandler(this.btn_Purge_Click);
            // 
            // lbox_Log
            // 
            this.lbox_Log.FormattingEnabled = true;
            this.lbox_Log.ItemHeight = 14;
            this.lbox_Log.Location = new System.Drawing.Point(6, 146);
            this.lbox_Log.Name = "lbox_Log";
            this.lbox_Log.Size = new System.Drawing.Size(416, 186);
            this.lbox_Log.TabIndex = 144;
            // 
            // btn_Execute
            // 
            this.btn_Execute.AccessibleDescription = "Execute";
            this.btn_Execute.Location = new System.Drawing.Point(6, 104);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(75, 36);
            this.btn_Execute.TabIndex = 142;
            this.btn_Execute.Text = "Execute";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.btn_Execute_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbl_Protocol);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(427, 34);
            this.panel5.TabIndex = 143;
            // 
            // lbl_Protocol
            // 
            this.lbl_Protocol.AccessibleDescription = "";
            this.lbl_Protocol.Location = new System.Drawing.Point(85, 5);
            this.lbl_Protocol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Protocol.Name = "lbl_Protocol";
            this.lbl_Protocol.Size = new System.Drawing.Size(50, 23);
            this.lbl_Protocol.TabIndex = 19;
            this.lbl_Protocol.Text = "Path";
            this.lbl_Protocol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Protocol";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_DispCore_DispProg_VolumeOfst
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(437, 442);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbox_PathSetup);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_VolumeOfst";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_VolumeOfst";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_VolumeOfst_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_VolumeOfst_Load);
            this.panel2.ResumeLayout(false);
            this.gbox_PathSetup.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Path;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox gbox_PathSetup;
        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.ListBox lbox_Log;
        private System.Windows.Forms.Button btn_Purge;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Path2;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Protocol;
    }
}