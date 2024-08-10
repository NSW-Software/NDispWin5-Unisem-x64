
namespace NDispWin
{
    partial class frmLotEntryAnalog
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxDeviceName = new System.Windows.Forms.TextBox();
            this.tbxLotNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxBuildSheetNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxProcessBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSubstratePartNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMaterialPartNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxMaterialLotNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxMaterialExpiryDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxOperatorID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxShift = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxMachineNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnStartLot = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEndLot = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbox_DateTime = new System.Windows.Forms.GroupBox();
            this.btn_dtpOK = new System.Windows.Forms.Button();
            this.dtp_ExpiryTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_ExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.btnMaterialExpiryDate = new System.Windows.Forms.Button();
            this.gbox_DateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(467, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "LOT INFO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(43, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "DEVICE NAME";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxDeviceName
            // 
            this.tbxDeviceName.Location = new System.Drawing.Point(214, 65);
            this.tbxDeviceName.Name = "tbxDeviceName";
            this.tbxDeviceName.Size = new System.Drawing.Size(226, 22);
            this.tbxDeviceName.TabIndex = 2;
            this.tbxDeviceName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // tbxLotNo
            // 
            this.tbxLotNo.Location = new System.Drawing.Point(214, 97);
            this.tbxLotNo.Name = "tbxLotNo";
            this.tbxLotNo.Size = new System.Drawing.Size(226, 22);
            this.tbxLotNo.TabIndex = 4;
            this.tbxLotNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(43, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "LOT#";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxBuildSheetNo
            // 
            this.tbxBuildSheetNo.Location = new System.Drawing.Point(214, 129);
            this.tbxBuildSheetNo.Name = "tbxBuildSheetNo";
            this.tbxBuildSheetNo.Size = new System.Drawing.Size(226, 22);
            this.tbxBuildSheetNo.TabIndex = 6;
            this.tbxBuildSheetNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(43, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "BUILD SHEET#";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxProcessBarcode
            // 
            this.tbxProcessBarcode.Location = new System.Drawing.Point(214, 161);
            this.tbxProcessBarcode.Name = "tbxProcessBarcode";
            this.tbxProcessBarcode.Size = new System.Drawing.Size(226, 22);
            this.tbxProcessBarcode.TabIndex = 8;
            this.tbxProcessBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(43, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "PROCESS BARCODE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxSubstratePartNo
            // 
            this.tbxSubstratePartNo.Location = new System.Drawing.Point(214, 193);
            this.tbxSubstratePartNo.Name = "tbxSubstratePartNo";
            this.tbxSubstratePartNo.Size = new System.Drawing.Size(226, 22);
            this.tbxSubstratePartNo.TabIndex = 10;
            this.tbxSubstratePartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(43, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "SUBSTRATE PART#";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxMaterialPartNo
            // 
            this.tbxMaterialPartNo.Location = new System.Drawing.Point(214, 225);
            this.tbxMaterialPartNo.Name = "tbxMaterialPartNo";
            this.tbxMaterialPartNo.Size = new System.Drawing.Size(226, 22);
            this.tbxMaterialPartNo.TabIndex = 12;
            this.tbxMaterialPartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(43, 222);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 26);
            this.label7.TabIndex = 11;
            this.label7.Text = "MATERIAL PART#";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxMaterialLotNo
            // 
            this.tbxMaterialLotNo.Location = new System.Drawing.Point(214, 257);
            this.tbxMaterialLotNo.Name = "tbxMaterialLotNo";
            this.tbxMaterialLotNo.Size = new System.Drawing.Size(226, 22);
            this.tbxMaterialLotNo.TabIndex = 14;
            this.tbxMaterialLotNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(43, 254);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "MATERIAL LOT#";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxMaterialExpiryDate
            // 
            this.tbxMaterialExpiryDate.Location = new System.Drawing.Point(214, 289);
            this.tbxMaterialExpiryDate.Name = "tbxMaterialExpiryDate";
            this.tbxMaterialExpiryDate.Size = new System.Drawing.Size(193, 22);
            this.tbxMaterialExpiryDate.TabIndex = 16;
            this.tbxMaterialExpiryDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(43, 286);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 26);
            this.label9.TabIndex = 15;
            this.label9.Text = "MATERIAL EXPIRY DATE";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxOperatorID
            // 
            this.tbxOperatorID.Location = new System.Drawing.Point(214, 321);
            this.tbxOperatorID.Name = "tbxOperatorID";
            this.tbxOperatorID.Size = new System.Drawing.Size(226, 22);
            this.tbxOperatorID.TabIndex = 18;
            this.tbxOperatorID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(43, 318);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 26);
            this.label10.TabIndex = 17;
            this.label10.Text = "OPERATOR ID";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxShift
            // 
            this.tbxShift.Location = new System.Drawing.Point(214, 353);
            this.tbxShift.Name = "tbxShift";
            this.tbxShift.Size = new System.Drawing.Size(226, 22);
            this.tbxShift.TabIndex = 20;
            this.tbxShift.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(43, 350);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 26);
            this.label11.TabIndex = 19;
            this.label11.Text = "SHIFT";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxMachineNo
            // 
            this.tbxMachineNo.Location = new System.Drawing.Point(214, 385);
            this.tbxMachineNo.Name = "tbxMachineNo";
            this.tbxMachineNo.Size = new System.Drawing.Size(226, 22);
            this.tbxMachineNo.TabIndex = 22;
            this.tbxMachineNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(43, 382);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(165, 26);
            this.label12.TabIndex = 21;
            this.label12.Text = "MACHINE NO";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(309, 457);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(80, 50);
            this.btnSetup.TabIndex = 26;
            this.btnSetup.TabStop = false;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnStartLot
            // 
            this.btnStartLot.Location = new System.Drawing.Point(8, 457);
            this.btnStartLot.Name = "btnStartLot";
            this.btnStartLot.Size = new System.Drawing.Size(80, 50);
            this.btnStartLot.TabIndex = 23;
            this.btnStartLot.Text = "Start Lot";
            this.btnStartLot.UseVisualStyleBackColor = true;
            this.btnStartLot.Click += new System.EventHandler(this.btnStartLot_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(395, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 50);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEndLot
            // 
            this.btnEndLot.Enabled = false;
            this.btnEndLot.Location = new System.Drawing.Point(94, 457);
            this.btnEndLot.Name = "btnEndLot";
            this.btnEndLot.Size = new System.Drawing.Size(80, 50);
            this.btnEndLot.TabIndex = 24;
            this.btnEndLot.Text = "End Lot";
            this.btnEndLot.UseVisualStyleBackColor = true;
            this.btnEndLot.Click += new System.EventHandler(this.btnEndLot_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(180, 457);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 50);
            this.btnClear.TabIndex = 25;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gbox_DateTime
            // 
            this.gbox_DateTime.AutoSize = true;
            this.gbox_DateTime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_DateTime.Controls.Add(this.btn_dtpOK);
            this.gbox_DateTime.Controls.Add(this.dtp_ExpiryTime);
            this.gbox_DateTime.Controls.Add(this.dtp_ExpiryDate);
            this.gbox_DateTime.Location = new System.Drawing.Point(8, 62);
            this.gbox_DateTime.Name = "gbox_DateTime";
            this.gbox_DateTime.Size = new System.Drawing.Size(260, 110);
            this.gbox_DateTime.TabIndex = 92;
            this.gbox_DateTime.TabStop = false;
            this.gbox_DateTime.Text = "Date Time";
            this.gbox_DateTime.Visible = false;
            // 
            // btn_dtpOK
            // 
            this.btn_dtpOK.AccessibleDescription = "OK";
            this.btn_dtpOK.Location = new System.Drawing.Point(134, 49);
            this.btn_dtpOK.Name = "btn_dtpOK";
            this.btn_dtpOK.Size = new System.Drawing.Size(120, 40);
            this.btn_dtpOK.TabIndex = 92;
            this.btn_dtpOK.Text = "OK";
            this.btn_dtpOK.UseVisualStyleBackColor = true;
            this.btn_dtpOK.Click += new System.EventHandler(this.btn_dtpOK_Click);
            // 
            // dtp_ExpiryTime
            // 
            this.dtp_ExpiryTime.CustomFormat = "hh:mm";
            this.dtp_ExpiryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_ExpiryTime.Location = new System.Drawing.Point(134, 21);
            this.dtp_ExpiryTime.Name = "dtp_ExpiryTime";
            this.dtp_ExpiryTime.ShowUpDown = true;
            this.dtp_ExpiryTime.Size = new System.Drawing.Size(120, 22);
            this.dtp_ExpiryTime.TabIndex = 91;
            // 
            // dtp_ExpiryDate
            // 
            this.dtp_ExpiryDate.CustomFormat = "";
            this.dtp_ExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ExpiryDate.Location = new System.Drawing.Point(8, 21);
            this.dtp_ExpiryDate.Name = "dtp_ExpiryDate";
            this.dtp_ExpiryDate.Size = new System.Drawing.Size(120, 22);
            this.dtp_ExpiryDate.TabIndex = 90;
            // 
            // btnMaterialExpiryDate
            // 
            this.btnMaterialExpiryDate.Location = new System.Drawing.Point(413, 288);
            this.btnMaterialExpiryDate.Name = "btnMaterialExpiryDate";
            this.btnMaterialExpiryDate.Size = new System.Drawing.Size(27, 23);
            this.btnMaterialExpiryDate.TabIndex = 93;
            this.btnMaterialExpiryDate.Text = "...";
            this.btnMaterialExpiryDate.UseVisualStyleBackColor = true;
            this.btnMaterialExpiryDate.Click += new System.EventHandler(this.btnMaterialExpiryDate_Click);
            // 
            // frmLotEntryAnalog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(499, 538);
            this.ControlBox = false;
            this.Controls.Add(this.btnMaterialExpiryDate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnStartLot);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEndLot);
            this.Controls.Add(this.tbxMachineNo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbxShift);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxOperatorID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbxMaterialExpiryDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbxMaterialLotNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxMaterialPartNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxSubstratePartNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxProcessBarcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxBuildSheetNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxLotNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDeviceName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbox_DateTime);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLotEntryAnalog";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Lot Info";
            this.Load += new System.EventHandler(this.frmLotEntryAnalog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLotEntryAnalog_KeyDown);
            this.gbox_DateTime.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxDeviceName;
        private System.Windows.Forms.TextBox tbxLotNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxBuildSheetNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxProcessBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSubstratePartNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMaterialPartNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxMaterialLotNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxMaterialExpiryDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxOperatorID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxShift;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxMachineNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnStartLot;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEndLot;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbox_DateTime;
        private System.Windows.Forms.Button btn_dtpOK;
        private System.Windows.Forms.DateTimePicker dtp_ExpiryTime;
        private System.Windows.Forms.DateTimePicker dtp_ExpiryDate;
        private System.Windows.Forms.Button btnMaterialExpiryDate;
    }
}