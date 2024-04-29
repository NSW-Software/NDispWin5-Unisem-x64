namespace NDispWin
{
    partial class frm_DispCore_DispProg_UseHeight
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_HeightID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Height ID";
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Height ID ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(113, 49);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 22;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(32, 49);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 21;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_HeightID
            // 
            this.lbl_HeightID.BackColor = System.Drawing.Color.White;
            this.lbl_HeightID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeightID.Location = new System.Drawing.Point(111, 7);
            this.lbl_HeightID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeightID.Name = "lbl_HeightID";
            this.lbl_HeightID.Size = new System.Drawing.Size(61, 23);
            this.lbl_HeightID.TabIndex = 116;
            this.lbl_HeightID.Text = "0";
            this.lbl_HeightID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeightID.Click += new System.EventHandler(this.lbl_HeightID_Click);
            // 
            // frm_DispCore_DispProg_UseHeight
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(205, 102);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_HeightID);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_UseHeight";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_UseHeight";
            this.Load += new System.EventHandler(this.frmDispProg_UseHeight_Load);
            this.Shown += new System.EventHandler(this.frmDispProg_UseHeight_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmDispProg_UseHeight_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_UseHeight_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_HeightID;
    }
}