namespace NDispWin
{
    partial class frmDispProg_NeedleInsp
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
            this.btn_Cond = new System.Windows.Forms.Button();
            this.lbox_Cond = new System.Windows.Forms.ListBox();
            this.btnExecP1 = new System.Windows.Forms.Button();
            this.btnExecP2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(370, 108);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(87, 39);
            this.btn_Cancel.TabIndex = 176;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(278, 108);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(87, 39);
            this.btn_OK.TabIndex = 175;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cond
            // 
            this.btn_Cond.AccessibleDescription = "Cond";
            this.btn_Cond.Location = new System.Drawing.Point(370, 47);
            this.btn_Cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cond.Name = "btn_Cond";
            this.btn_Cond.Size = new System.Drawing.Size(87, 39);
            this.btn_Cond.TabIndex = 173;
            this.btn_Cond.Text = "Cond";
            this.btn_Cond.UseVisualStyleBackColor = true;
            this.btn_Cond.Click += new System.EventHandler(this.btn_Cond_Click);
            // 
            // lbox_Cond
            // 
            this.lbox_Cond.FormattingEnabled = true;
            this.lbox_Cond.ItemHeight = 14;
            this.lbox_Cond.Location = new System.Drawing.Point(9, 8);
            this.lbox_Cond.Name = "lbox_Cond";
            this.lbox_Cond.Size = new System.Drawing.Size(448, 32);
            this.lbox_Cond.TabIndex = 174;
            // 
            // btnExecP1
            // 
            this.btnExecP1.AccessibleDescription = "Exec P1";
            this.btnExecP1.Location = new System.Drawing.Point(9, 108);
            this.btnExecP1.Margin = new System.Windows.Forms.Padding(2);
            this.btnExecP1.Name = "btnExecP1";
            this.btnExecP1.Size = new System.Drawing.Size(87, 39);
            this.btnExecP1.TabIndex = 177;
            this.btnExecP1.Text = "Exec P1";
            this.btnExecP1.UseVisualStyleBackColor = true;
            this.btnExecP1.Click += new System.EventHandler(this.btnExecP1_Click);
            // 
            // btnExecP2
            // 
            this.btnExecP2.AccessibleDescription = "Exec P2";
            this.btnExecP2.Location = new System.Drawing.Point(100, 108);
            this.btnExecP2.Margin = new System.Windows.Forms.Padding(2);
            this.btnExecP2.Name = "btnExecP2";
            this.btnExecP2.Size = new System.Drawing.Size(87, 39);
            this.btnExecP2.TabIndex = 178;
            this.btnExecP2.Text = "Exec P2";
            this.btnExecP2.UseVisualStyleBackColor = true;
            this.btnExecP2.Click += new System.EventHandler(this.btnExecP2_Click);
            // 
            // frmDispProg_NeedleInsp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(500, 186);
            this.Controls.Add(this.btnExecP2);
            this.Controls.Add(this.btnExecP1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cond);
            this.Controls.Add(this.lbox_Cond);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmDispProg_NeedleInsp";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Text = "frmDispProg_NeedleInsp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDispProg_NeedleInsp_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_NeedleInsp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cond;
        private System.Windows.Forms.ListBox lbox_Cond;
        private System.Windows.Forms.Button btnExecP1;
        private System.Windows.Forms.Button btnExecP2;
    }
}