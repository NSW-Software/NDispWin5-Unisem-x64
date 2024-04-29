
namespace NDispWin
{
    partial class frmDoRefCheck
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
            this.lbl_RefID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_MinScore = new System.Windows.Forms.Label();
            this.lbl_XYTol = new System.Windows.Forms.Label();
            this.btn_Cond = new System.Windows.Forms.Button();
            this.lbox_Cond = new System.Windows.Forms.ListBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_RefID
            // 
            this.lbl_RefID.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_RefID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_RefID.Location = new System.Drawing.Point(111, 9);
            this.lbl_RefID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_RefID.Name = "lbl_RefID";
            this.lbl_RefID.Size = new System.Drawing.Size(75, 24);
            this.lbl_RefID.TabIndex = 22;
            this.lbl_RefID.Text = "lbl_RefID";
            this.lbl_RefID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_RefID.Click += new System.EventHandler(this.lbl_RefID_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Ref ID";
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ref ID ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "Min Score (%)";
            this.label14.Location = new System.Drawing.Point(7, 138);
            this.label14.Margin = new System.Windows.Forms.Padding(2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 24);
            this.label14.TabIndex = 26;
            this.label14.Text = "Min Score (%)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "XY Tol (mm)";
            this.label15.Location = new System.Drawing.Point(7, 166);
            this.label15.Margin = new System.Windows.Forms.Padding(2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 24);
            this.label15.TabIndex = 25;
            this.label15.Text = "XY Tol (mm)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MinScore
            // 
            this.lbl_MinScore.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MinScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MinScore.Location = new System.Drawing.Point(134, 138);
            this.lbl_MinScore.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MinScore.Name = "lbl_MinScore";
            this.lbl_MinScore.Size = new System.Drawing.Size(75, 24);
            this.lbl_MinScore.TabIndex = 27;
            this.lbl_MinScore.Text = "9.999";
            this.lbl_MinScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MinScore.Click += new System.EventHandler(this.lbl_MinScore_Click);
            // 
            // lbl_XYTol
            // 
            this.lbl_XYTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_XYTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_XYTol.Location = new System.Drawing.Point(134, 166);
            this.lbl_XYTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_XYTol.Name = "lbl_XYTol";
            this.lbl_XYTol.Size = new System.Drawing.Size(75, 24);
            this.lbl_XYTol.TabIndex = 28;
            this.lbl_XYTol.Text = "9.999";
            this.lbl_XYTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_XYTol.Click += new System.EventHandler(this.lbl_XYTol_Click);
            // 
            // btn_Cond
            // 
            this.btn_Cond.AccessibleDescription = "Cond";
            this.btn_Cond.Location = new System.Drawing.Point(318, 75);
            this.btn_Cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cond.Name = "btn_Cond";
            this.btn_Cond.Size = new System.Drawing.Size(75, 36);
            this.btn_Cond.TabIndex = 169;
            this.btn_Cond.Text = "Cond";
            this.btn_Cond.UseVisualStyleBackColor = true;
            this.btn_Cond.Click += new System.EventHandler(this.btn_Cond_Click);
            // 
            // lbox_Cond
            // 
            this.lbox_Cond.FormattingEnabled = true;
            this.lbox_Cond.ItemHeight = 14;
            this.lbox_Cond.Location = new System.Drawing.Point(8, 38);
            this.lbox_Cond.Name = "lbox_Cond";
            this.lbox_Cond.Size = new System.Drawing.Size(385, 32);
            this.lbox_Cond.TabIndex = 170;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(318, 204);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 172;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(239, 204);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 171;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frmDoRefCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(420, 258);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cond);
            this.Controls.Add(this.lbox_Cond);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lbl_MinScore);
            this.Controls.Add(this.lbl_XYTol);
            this.Controls.Add(this.lbl_RefID);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmDoRefCheck";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "DoRefCheck";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDoRefCheck_FormClosed);
            this.Load += new System.EventHandler(this.frmDoRefCheck_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_RefID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_MinScore;
        private System.Windows.Forms.Label lbl_XYTol;
        private System.Windows.Forms.Button btn_Cond;
        private System.Windows.Forms.ListBox lbox_Cond;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}