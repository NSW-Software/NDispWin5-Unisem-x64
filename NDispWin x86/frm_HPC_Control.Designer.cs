namespace NDispWin
{
    partial class frm_HPC_Control
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
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pnl_FPress = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.lbl_FPressB = new System.Windows.Forms.Label();
            this.lbl_FPressUnit = new System.Windows.Forms.Label();
            this.lbl_FPressA = new System.Windows.Forms.Label();
            this.pnl_Top.SuspendLayout();
            this.pnl_FPress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Top
            // 
            this.pnl_Top.AutoSize = true;
            this.pnl_Top.Controls.Add(this.btn_Close);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(801, 36);
            this.pnl_Top.TabIndex = 2;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(728, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(70, 30);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pnl_FPress
            // 
            this.pnl_FPress.AutoSize = true;
            this.pnl_FPress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_FPress.Controls.Add(this.label18);
            this.pnl_FPress.Controls.Add(this.lbl_FPressA);
            this.pnl_FPress.Controls.Add(this.lbl_FPressUnit);
            this.pnl_FPress.Controls.Add(this.lbl_FPressB);
            this.pnl_FPress.Location = new System.Drawing.Point(0, 71);
            this.pnl_FPress.Name = "pnl_FPress";
            this.pnl_FPress.Padding = new System.Windows.Forms.Padding(3);
            this.pnl_FPress.Size = new System.Drawing.Size(410, 42);
            this.pnl_FPress.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "F Pressure";
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(6, 14);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 15);
            this.label18.TabIndex = 56;
            this.label18.Text = "F Pressure";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FPressB
            // 
            this.lbl_FPressB.BackColor = System.Drawing.Color.White;
            this.lbl_FPressB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressB.Location = new System.Drawing.Point(344, 6);
            this.lbl_FPressB.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressB.Name = "lbl_FPressB";
            this.lbl_FPressB.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPressB.TabIndex = 54;
            this.lbl_FPressB.Text = "24.0";
            this.lbl_FPressB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressB.Click += new System.EventHandler(this.lbl_FPressB_Click);
            // 
            // lbl_FPressUnit
            // 
            this.lbl_FPressUnit.AccessibleDescription = "";
            this.lbl_FPressUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_FPressUnit.Location = new System.Drawing.Point(82, 14);
            this.lbl_FPressUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressUnit.Name = "lbl_FPressUnit";
            this.lbl_FPressUnit.Size = new System.Drawing.Size(50, 15);
            this.lbl_FPressUnit.TabIndex = 57;
            this.lbl_FPressUnit.Text = "(ul)";
            this.lbl_FPressUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_FPressA
            // 
            this.lbl_FPressA.BackColor = System.Drawing.Color.White;
            this.lbl_FPressA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressA.Location = new System.Drawing.Point(138, 6);
            this.lbl_FPressA.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressA.Name = "lbl_FPressA";
            this.lbl_FPressA.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPressA.TabIndex = 55;
            this.lbl_FPressA.Text = "24.0";
            this.lbl_FPressA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressA.Click += new System.EventHandler(this.lbl_FPressA_Click);
            // 
            // frm_HPC_Control
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(801, 423);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_FPress);
            this.Controls.Add(this.pnl_Top);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_HPC_Control";
            this.Text = "frm_HPC_Control";
            this.Load += new System.EventHandler(this.frm_HPC_Control_Load);
            this.pnl_Top.ResumeLayout(false);
            this.pnl_FPress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel pnl_FPress;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbl_FPressB;
        private System.Windows.Forms.Label lbl_FPressUnit;
        private System.Windows.Forms.Label lbl_FPressA;
    }
}