namespace NDispWin
{
    partial class frmDispCore_DispProg_GPOut
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
            this.lbl_State = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_GPOutNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_State
            // 
            this.lbl_State.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_State.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_State.Location = new System.Drawing.Point(230, 10);
            this.lbl_State.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(75, 24);
            this.lbl_State.TabIndex = 43;
            this.lbl_State.Text = "lbl_State";
            this.lbl_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_State.Click += new System.EventHandler(this.lbl_State_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "State";
            this.label2.Location = new System.Drawing.Point(144, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 42;
            this.label2.Text = "State";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_GPOutNo
            // 
            this.lbl_GPOutNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_GPOutNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_GPOutNo.Location = new System.Drawing.Point(65, 10);
            this.lbl_GPOutNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_GPOutNo.Name = "lbl_GPOutNo";
            this.lbl_GPOutNo.Size = new System.Drawing.Size(75, 24);
            this.lbl_GPOutNo.TabIndex = 41;
            this.lbl_GPOutNo.Text = "lbl_GPOutNo";
            this.lbl_GPOutNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_GPOutNo.Click += new System.EventHandler(this.lbl_GPOutNo_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "";
            this.label3.Location = new System.Drawing.Point(11, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 40;
            this.label3.Text = "Out No ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(235, 55);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(70, 36);
            this.btn_Cancel.TabIndex = 57;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(161, 55);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(70, 36);
            this.btn_OK.TabIndex = 56;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frmDispCore_DispProg_GPOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 109);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_State);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_GPOutNo);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDispCore_DispProg_GPOut";
            this.Text = "frmDispProg_GPOut";
            this.Load += new System.EventHandler(this.frmDispProg_GPOut_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_GPOutNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}