namespace NDispWin
{
    partial class frm_DispCore_DispProg_ReadID_ManualEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_Text = new System.Windows.Forms.TextBox();
            this.btn_Retry = new System.Windows.Forms.Button();
            this.btn_Mute = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.ForeColor = System.Drawing.Color.Navy;
            this.btn_Cancel.Location = new System.Drawing.Point(285, 116);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 32;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.ForeColor = System.Drawing.Color.Navy;
            this.btn_OK.Location = new System.Drawing.Point(206, 116);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 31;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 23);
            this.label1.TabIndex = 34;
            this.label1.Text = "Enter Frame ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_Text
            // 
            this.tbox_Text.Location = new System.Drawing.Point(8, 89);
            this.tbox_Text.Name = "tbox_Text";
            this.tbox_Text.Size = new System.Drawing.Size(352, 22);
            this.tbox_Text.TabIndex = 35;
            // 
            // btn_Retry
            // 
            this.btn_Retry.AccessibleDescription = "Retry";
            this.btn_Retry.ForeColor = System.Drawing.Color.Navy;
            this.btn_Retry.Location = new System.Drawing.Point(86, 7);
            this.btn_Retry.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Retry.Name = "btn_Retry";
            this.btn_Retry.Size = new System.Drawing.Size(75, 36);
            this.btn_Retry.TabIndex = 36;
            this.btn_Retry.Text = "Retry";
            this.btn_Retry.UseVisualStyleBackColor = true;
            this.btn_Retry.Click += new System.EventHandler(this.btn_Retry_Click);
            // 
            // btn_Mute
            // 
            this.btn_Mute.AccessibleDescription = "Mute";
            this.btn_Mute.ForeColor = System.Drawing.Color.Navy;
            this.btn_Mute.Location = new System.Drawing.Point(7, 7);
            this.btn_Mute.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Mute.Name = "btn_Mute";
            this.btn_Mute.Size = new System.Drawing.Size(75, 36);
            this.btn_Mute.TabIndex = 37;
            this.btn_Mute.Text = "Mute";
            this.btn_Mute.UseVisualStyleBackColor = true;
            this.btn_Mute.Click += new System.EventHandler(this.btn_Mute_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.AccessibleDescription = "Skip";
            this.btnSkip.ForeColor = System.Drawing.Color.Navy;
            this.btnSkip.Location = new System.Drawing.Point(285, 7);
            this.btnSkip.Margin = new System.Windows.Forms.Padding(2);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 36);
            this.btnSkip.TabIndex = 38;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // frm_DispCore_DispProg_ReadID_ManualEntry
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(374, 170);
            this.ControlBox = false;
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btn_Mute);
            this.Controls.Add(this.btn_Retry);
            this.Controls.Add(this.tbox_Text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_ReadID_ManualEntry";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_DispCore_DispProg_ReadID_ManualEntry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_DispProg_ReadID_ManualEntry_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_ReadID_ManualEntry_FormClosed);
            this.Load += new System.EventHandler(this.frm_DispCore_DispProg_ReadID_ManualEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_Text;
        private System.Windows.Forms.Button btn_Retry;
        private System.Windows.Forms.Button btn_Mute;
        private System.Windows.Forms.Button btnSkip;
    }
}