namespace NDispWin
{
    partial class frm_DispCore_DispProg_ManageProgram
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
            this.lbox_Program = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbox_Program
            // 
            this.lbox_Program.FormattingEnabled = true;
            this.lbox_Program.ItemHeight = 14;
            this.lbox_Program.Location = new System.Drawing.Point(6, 21);
            this.lbox_Program.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbox_Program.Name = "lbox_Program";
            this.lbox_Program.Size = new System.Drawing.Size(429, 410);
            this.lbox_Program.TabIndex = 0;
            this.lbox_Program.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbox_Program_MouseClick);
            this.lbox_Program.SelectedIndexChanged += new System.EventHandler(this.lbox_Program_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbox_Program);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox1.Size = new System.Drawing.Size(441, 446);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Program List";
            // 
            // btn_Delete
            // 
            this.btn_Delete.AccessibleDescription = "Delete";
            this.btn_Delete.Location = new System.Drawing.Point(459, 33);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 36);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(459, 407);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 36);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // frm_DispCore_DispProg_ManageProgram
            // 
            this.AccessibleDescription = "Manage Program";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(576, 487);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frm_DispCore_DispProg_ManageProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Program";
            this.Load += new System.EventHandler(this.frmManageProgram_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbox_Program;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Close;
    }
}