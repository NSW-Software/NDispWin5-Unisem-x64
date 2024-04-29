namespace NDispWin
{
    partial class frmCLEditor
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
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblCL1 = new System.Windows.Forms.Label();
            this.lblCL0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(82, 6);
            this.label27.Margin = new System.Windows.Forms.Padding(3);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 20);
            this.label27.TabIndex = 28;
            this.label27.Text = "Upper";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(6, 6);
            this.label26.Margin = new System.Windows.Forms.Padding(3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 20);
            this.label26.TabIndex = 27;
            this.label26.Text = "Lower";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCL1
            // 
            this.lblCL1.BackColor = System.Drawing.Color.White;
            this.lblCL1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCL1.Location = new System.Drawing.Point(82, 32);
            this.lblCL1.Margin = new System.Windows.Forms.Padding(3);
            this.lblCL1.Name = "lblCL1";
            this.lblCL1.Size = new System.Drawing.Size(70, 20);
            this.lblCL1.TabIndex = 26;
            this.lblCL1.Text = "label3";
            this.lblCL1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCL1.Click += new System.EventHandler(this.lblCL1_Click);
            // 
            // lblCL0
            // 
            this.lblCL0.BackColor = System.Drawing.Color.White;
            this.lblCL0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCL0.Location = new System.Drawing.Point(6, 32);
            this.lblCL0.Margin = new System.Windows.Forms.Padding(3);
            this.lblCL0.Name = "lblCL0";
            this.lblCL0.Size = new System.Drawing.Size(70, 20);
            this.lblCL0.TabIndex = 25;
            this.lblCL0.Text = "label3";
            this.lblCL0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCL0.Click += new System.EventHandler(this.lblCL0_Click);
            // 
            // frmCLEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(165, 63);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblCL1);
            this.Controls.Add(this.lblCL0);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCLEditor";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmCLEditor";
            this.Load += new System.EventHandler(this.frmCLEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblCL1;
        private System.Windows.Forms.Label lblCL0;
    }
}