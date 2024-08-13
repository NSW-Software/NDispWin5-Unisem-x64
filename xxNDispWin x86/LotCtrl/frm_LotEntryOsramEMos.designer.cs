namespace NDispWin
{
    partial class frm_LotEntryOsramEMos
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
            this.tbox_DAStartNumber = new System.Windows.Forms.TextBox();
            this.lbl_MCNoCaption = new System.Windows.Forms.Label();
            this.tbox_EmployeeID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbox_11Series = new System.Windows.Forms.TextBox();
            this.tbox_LotNumber = new System.Windows.Forms.TextBox();
            this.lbl_LotNumber = new System.Windows.Forms.Label();
            this.lbl_MaterialNr = new System.Windows.Forms.Label();
            this.btn_StartLot = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_EndLot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbox_DAStartNumber
            // 
            this.tbox_DAStartNumber.Location = new System.Drawing.Point(194, 122);
            this.tbox_DAStartNumber.Name = "tbox_DAStartNumber";
            this.tbox_DAStartNumber.Size = new System.Drawing.Size(312, 22);
            this.tbox_DAStartNumber.TabIndex = 3;
            this.tbox_DAStartNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_DAStartNumber_KeyDown);
            // 
            // lbl_MCNoCaption
            // 
            this.lbl_MCNoCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_MCNoCaption.Location = new System.Drawing.Point(23, 119);
            this.lbl_MCNoCaption.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MCNoCaption.Name = "lbl_MCNoCaption";
            this.lbl_MCNoCaption.Size = new System.Drawing.Size(165, 37);
            this.lbl_MCNoCaption.TabIndex = 70;
            this.lbl_MCNoCaption.Text = "(4) DA START NUMBER";
            // 
            // tbox_EmployeeID
            // 
            this.tbox_EmployeeID.Location = new System.Drawing.Point(194, 26);
            this.tbox_EmployeeID.Name = "tbox_EmployeeID";
            this.tbox_EmployeeID.Size = new System.Drawing.Size(312, 22);
            this.tbox_EmployeeID.TabIndex = 0;
            this.tbox_EmployeeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_EmployeeID_KeyDown);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(23, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 26);
            this.label6.TabIndex = 69;
            this.label6.Text = "(1) EMPLOYEE ID";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_11Series
            // 
            this.tbox_11Series.Location = new System.Drawing.Point(194, 90);
            this.tbox_11Series.Name = "tbox_11Series";
            this.tbox_11Series.Size = new System.Drawing.Size(312, 22);
            this.tbox_11Series.TabIndex = 2;
            this.tbox_11Series.TextChanged += new System.EventHandler(this.tbox_11Series_TextChanged);
            this.tbox_11Series.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_11Series_KeyDown);
            // 
            // tbox_LotNumber
            // 
            this.tbox_LotNumber.Location = new System.Drawing.Point(194, 59);
            this.tbox_LotNumber.Name = "tbox_LotNumber";
            this.tbox_LotNumber.Size = new System.Drawing.Size(312, 22);
            this.tbox_LotNumber.TabIndex = 1;
            this.tbox_LotNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_LotNumber_KeyDown);
            // 
            // lbl_LotNumber
            // 
            this.lbl_LotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_LotNumber.Location = new System.Drawing.Point(23, 55);
            this.lbl_LotNumber.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_LotNumber.Name = "lbl_LotNumber";
            this.lbl_LotNumber.Size = new System.Drawing.Size(165, 26);
            this.lbl_LotNumber.TabIndex = 66;
            this.lbl_LotNumber.Text = "(2) LOT NUMBER";
            this.lbl_LotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MaterialNr
            // 
            this.lbl_MaterialNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_MaterialNr.Location = new System.Drawing.Point(23, 87);
            this.lbl_MaterialNr.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MaterialNr.Name = "lbl_MaterialNr";
            this.lbl_MaterialNr.Size = new System.Drawing.Size(165, 26);
            this.lbl_MaterialNr.TabIndex = 68;
            this.lbl_MaterialNr.Text = "(3) MATERIAL NR";
            this.lbl_MaterialNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_StartLot
            // 
            this.btn_StartLot.Location = new System.Drawing.Point(194, 156);
            this.btn_StartLot.Name = "btn_StartLot";
            this.btn_StartLot.Size = new System.Drawing.Size(80, 40);
            this.btn_StartLot.TabIndex = 4;
            this.btn_StartLot.Text = "START LOT";
            this.btn_StartLot.UseVisualStyleBackColor = true;
            this.btn_StartLot.Click += new System.EventHandler(this.btn_StartLot_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(426, 156);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 40);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_EndLot
            // 
            this.btn_EndLot.Location = new System.Drawing.Point(280, 156);
            this.btn_EndLot.Name = "btn_EndLot";
            this.btn_EndLot.Size = new System.Drawing.Size(80, 40);
            this.btn_EndLot.TabIndex = 6;
            this.btn_EndLot.Text = "END LOT";
            this.btn_EndLot.UseVisualStyleBackColor = true;
            this.btn_EndLot.Click += new System.EventHandler(this.btn_EndLot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 71;
            this.label1.Text = "( RECIPE )";
            // 
            // frm_LotEntryOsramEMos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(540, 223);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_EndLot);
            this.Controls.Add(this.btn_StartLot);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tbox_DAStartNumber);
            this.Controls.Add(this.lbl_MCNoCaption);
            this.Controls.Add(this.tbox_EmployeeID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbox_11Series);
            this.Controls.Add(this.tbox_LotNumber);
            this.Controls.Add(this.lbl_LotNumber);
            this.Controls.Add(this.lbl_MaterialNr);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_LotEntryOsramEMos";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_LotEntryOsramEMos";
            this.Load += new System.EventHandler(this.frm_LotEntryOsramType2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbox_DAStartNumber;
        private System.Windows.Forms.Label lbl_MCNoCaption;
        private System.Windows.Forms.TextBox tbox_EmployeeID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbox_11Series;
        private System.Windows.Forms.TextBox tbox_LotNumber;
        private System.Windows.Forms.Label lbl_LotNumber;
        private System.Windows.Forms.Label lbl_MaterialNr;
        private System.Windows.Forms.Button btn_StartLot;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_EndLot;
        private System.Windows.Forms.Label label1;
    }
}