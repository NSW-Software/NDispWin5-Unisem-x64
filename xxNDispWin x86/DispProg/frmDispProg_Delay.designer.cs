namespace NDispWin
{
    partial class frm_DispCore_DispProg_Delay
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
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_Delay = new System.Windows.Forms.Label();
            this.lbl_l_HeadNo = new System.Windows.Forms.Label();
            this.lbl_HeadNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.ForeColor = System.Drawing.Color.Navy;
            this.btn_Cancel.Location = new System.Drawing.Point(131, 71);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 30;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.ForeColor = System.Drawing.Color.Navy;
            this.btn_OK.Location = new System.Drawing.Point(50, 71);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 29;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "Delay (ms)";
            this.label15.Location = new System.Drawing.Point(7, 34);
            this.label15.Margin = new System.Windows.Forms.Padding(2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 23);
            this.label15.TabIndex = 32;
            this.label15.Text = "Delay (ms)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Delay
            // 
            this.lbl_Delay.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Delay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Delay.Location = new System.Drawing.Point(131, 34);
            this.lbl_Delay.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Delay.Name = "lbl_Delay";
            this.lbl_Delay.Size = new System.Drawing.Size(75, 23);
            this.lbl_Delay.TabIndex = 33;
            this.lbl_Delay.Text = "1000";
            this.lbl_Delay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Delay.Click += new System.EventHandler(this.lbl_Delay_Click);
            // 
            // lbl_l_HeadNo
            // 
            this.lbl_l_HeadNo.AccessibleDescription = "Head No";
            this.lbl_l_HeadNo.Location = new System.Drawing.Point(7, 7);
            this.lbl_l_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_l_HeadNo.Name = "lbl_l_HeadNo";
            this.lbl_l_HeadNo.Size = new System.Drawing.Size(120, 23);
            this.lbl_l_HeadNo.TabIndex = 115;
            this.lbl_l_HeadNo.Text = "Head No";
            this.lbl_l_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadNo
            // 
            this.lbl_HeadNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadNo.Location = new System.Drawing.Point(131, 7);
            this.lbl_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadNo.Name = "lbl_HeadNo";
            this.lbl_HeadNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadNo.TabIndex = 116;
            this.lbl_HeadNo.Text = "lbl_HeadNo";
            this.lbl_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadNo.Click += new System.EventHandler(this.lbl_HeadNo_Click);
            // 
            // frm_DispCore_DispProg_Delay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(218, 116);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_l_HeadNo);
            this.Controls.Add(this.lbl_HeadNo);
            this.Controls.Add(this.lbl_Delay);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_Delay";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_Delay";
            this.Load += new System.EventHandler(this.frmDispProg_Delay_Load);
            this.Shown += new System.EventHandler(this.frmDispProg_Delay_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmDispProg_Delay_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_Delay_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_Delay;
        private System.Windows.Forms.Label lbl_l_HeadNo;
        private System.Windows.Forms.Label lbl_HeadNo;
    }
}