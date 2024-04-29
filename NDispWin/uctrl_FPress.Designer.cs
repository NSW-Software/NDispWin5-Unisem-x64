namespace NDispWin
{
    partial class uctrl_FPress
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label22 = new System.Windows.Forms.Label();
            this.lbl_SetFPress = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AccessibleDescription = "F Pressure";
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Location = new System.Drawing.Point(0, 8);
            this.label22.Margin = new System.Windows.Forms.Padding(3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 15);
            this.label22.TabIndex = 46;
            this.label22.Text = "F Pressure";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SetFPress
            // 
            this.lbl_SetFPress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SetFPress.BackColor = System.Drawing.Color.White;
            this.lbl_SetFPress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SetFPress.Location = new System.Drawing.Point(132, 0);
            this.lbl_SetFPress.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_SetFPress.Name = "lbl_SetFPress";
            this.lbl_SetFPress.Size = new System.Drawing.Size(60, 30);
            this.lbl_SetFPress.TabIndex = 46;
            this.lbl_SetFPress.Text = "24.0";
            this.lbl_SetFPress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_SetFPress.Click += new System.EventHandler(this.lbl_SetFPress_Click);
            // 
            // label19
            // 
            this.label19.AccessibleDescription = "";
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Location = new System.Drawing.Point(76, 8);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 15);
            this.label19.TabIndex = 47;
            this.label19.Text = "(Psi)";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uctrl_FPress
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.lbl_SetFPress);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label19);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uctrl_FPress";
            this.Size = new System.Drawing.Size(192, 33);
            this.Load += new System.EventHandler(this.uctrl_FPress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbl_SetFPress;
        private System.Windows.Forms.Label label19;
    }
}
