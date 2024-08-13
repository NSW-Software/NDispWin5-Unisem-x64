namespace NDispWin
{
    partial class frm_DispCore_DispProg_Comment
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_Comment = new System.Windows.Forms.Label();
            this.cbSaveToEvent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Comment";
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comment";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.ForeColor = System.Drawing.Color.Navy;
            this.btn_Cancel.Location = new System.Drawing.Point(364, 34);
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
            this.btn_OK.Location = new System.Drawing.Point(285, 34);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 31;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_Comment
            // 
            this.lbl_Comment.BackColor = System.Drawing.Color.White;
            this.lbl_Comment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Comment.Location = new System.Drawing.Point(86, 7);
            this.lbl_Comment.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Comment.Name = "lbl_Comment";
            this.lbl_Comment.Size = new System.Drawing.Size(353, 23);
            this.lbl_Comment.TabIndex = 33;
            this.lbl_Comment.Text = "Comment";
            this.lbl_Comment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Comment.Click += new System.EventHandler(this.lbl_Comment_Click);
            // 
            // cbSaveToLog
            // 
            this.cbSaveToEvent.AutoSize = true;
            this.cbSaveToEvent.Location = new System.Drawing.Point(86, 42);
            this.cbSaveToEvent.Name = "cbSaveToLog";
            this.cbSaveToEvent.Size = new System.Drawing.Size(129, 22);
            this.cbSaveToEvent.TabIndex = 34;
            this.cbSaveToEvent.Text = "Save Event File";
            this.cbSaveToEvent.UseVisualStyleBackColor = true;
            this.cbSaveToEvent.Click += new System.EventHandler(this.cbSaveToEvent_Click);
            // 
            // frm_DispCore_DispProg_Comment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(450, 87);
            this.ControlBox = false;
            this.Controls.Add(this.cbSaveToEvent);
            this.Controls.Add(this.lbl_Comment);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_Comment";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_Comment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_Comment_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_Comment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_Comment;
        private System.Windows.Forms.CheckBox cbSaveToEvent;
    }
}