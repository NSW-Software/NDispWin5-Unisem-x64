
namespace NDispWin
{
    partial class frmLotEntryAnalogSetup
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
            this.lbxRecipeItem = new System.Windows.Forms.ListBox();
            this.tbxMachineNo = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbxBuildSheetNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbxProcessBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxMaterialPartNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxRecipe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxHandlerRecipe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPump = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxNeedleType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSupportBlockUsed = new System.Windows.Forms.CheckBox();
            this.rtbxPrompt1 = new System.Windows.Forms.RichTextBox();
            this.rtbxPrompt2 = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbxRemark2 = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rtbxRemark1 = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbManualExpiry = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nudMaterialLife = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaterialLife)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxRecipeItem
            // 
            this.lbxRecipeItem.FormattingEnabled = true;
            this.lbxRecipeItem.ItemHeight = 14;
            this.lbxRecipeItem.Location = new System.Drawing.Point(12, 12);
            this.lbxRecipeItem.Name = "lbxRecipeItem";
            this.lbxRecipeItem.Size = new System.Drawing.Size(442, 452);
            this.lbxRecipeItem.TabIndex = 0;
            this.lbxRecipeItem.SelectedIndexChanged += new System.EventHandler(this.lbxRecipeItem_SelectedIndexChanged);
            // 
            // tbxMachineNo
            // 
            this.tbxMachineNo.ForeColor = System.Drawing.Color.Navy;
            this.tbxMachineNo.Location = new System.Drawing.Point(135, 470);
            this.tbxMachineNo.Name = "tbxMachineNo";
            this.tbxMachineNo.Size = new System.Drawing.Size(99, 22);
            this.tbxMachineNo.TabIndex = 65;
            this.tbxMachineNo.TextChanged += new System.EventHandler(this.tbxMachineNo_TextChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(743, 490);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 30);
            this.btn_Save.TabIndex = 78;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(662, 490);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 30);
            this.btn_Load.TabIndex = 77;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(824, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 76;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tbxBuildSheetNo
            // 
            this.tbxBuildSheetNo.Location = new System.Drawing.Point(132, 25);
            this.tbxBuildSheetNo.Name = "tbxBuildSheetNo";
            this.tbxBuildSheetNo.Size = new System.Drawing.Size(226, 22);
            this.tbxBuildSheetNo.TabIndex = 80;
            this.tbxBuildSheetNo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 26);
            this.label6.TabIndex = 79;
            this.label6.Text = "BUILD SHEET#";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(283, 409);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 81;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbxProcessBarcode
            // 
            this.tbxProcessBarcode.Location = new System.Drawing.Point(132, 53);
            this.tbxProcessBarcode.Name = "tbxProcessBarcode";
            this.tbxProcessBarcode.Size = new System.Drawing.Size(226, 22);
            this.tbxProcessBarcode.TabIndex = 84;
            this.tbxProcessBarcode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 83;
            this.label1.Text = "PROCESS BARCODE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxMaterialPartNo
            // 
            this.tbxMaterialPartNo.Location = new System.Drawing.Point(132, 81);
            this.tbxMaterialPartNo.Name = "tbxMaterialPartNo";
            this.tbxMaterialPartNo.Size = new System.Drawing.Size(226, 22);
            this.tbxMaterialPartNo.TabIndex = 86;
            this.tbxMaterialPartNo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 85;
            this.label2.Text = "MATERIAL PART#";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxRecipe
            // 
            this.tbxRecipe.Location = new System.Drawing.Point(132, 109);
            this.tbxRecipe.Name = "tbxRecipe";
            this.tbxRecipe.Size = new System.Drawing.Size(226, 22);
            this.tbxRecipe.TabIndex = 88;
            this.tbxRecipe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 26);
            this.label3.TabIndex = 87;
            this.label3.Text = "RECIPE PROGRAM";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxHandlerRecipe
            // 
            this.tbxHandlerRecipe.Location = new System.Drawing.Point(132, 137);
            this.tbxHandlerRecipe.Name = "tbxHandlerRecipe";
            this.tbxHandlerRecipe.Size = new System.Drawing.Size(226, 22);
            this.tbxHandlerRecipe.TabIndex = 90;
            this.tbxHandlerRecipe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 26);
            this.label4.TabIndex = 89;
            this.label4.Text = "RECIPE HANDLER";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxPump
            // 
            this.tbxPump.Location = new System.Drawing.Point(132, 165);
            this.tbxPump.Name = "tbxPump";
            this.tbxPump.Size = new System.Drawing.Size(226, 22);
            this.tbxPump.TabIndex = 92;
            this.tbxPump.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 26);
            this.label5.TabIndex = 91;
            this.label5.Text = "PUMP";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxNeedleType
            // 
            this.tbxNeedleType.Location = new System.Drawing.Point(132, 193);
            this.tbxNeedleType.Name = "tbxNeedleType";
            this.tbxNeedleType.Size = new System.Drawing.Size(226, 22);
            this.tbxNeedleType.TabIndex = 94;
            this.tbxNeedleType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 189);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 26);
            this.label7.TabIndex = 93;
            this.label7.Text = "NEEDLE TYPE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 242);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 26);
            this.label9.TabIndex = 97;
            this.label9.Text = "Prompt1";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbSupportBlockUsed
            // 
            this.cbSupportBlockUsed.AutoSize = true;
            this.cbSupportBlockUsed.Location = new System.Drawing.Point(132, 221);
            this.cbSupportBlockUsed.Name = "cbSupportBlockUsed";
            this.cbSupportBlockUsed.Size = new System.Drawing.Size(153, 18);
            this.cbSupportBlockUsed.TabIndex = 98;
            this.cbSupportBlockUsed.Text = "SUPPORT BLOCK USED";
            this.cbSupportBlockUsed.UseVisualStyleBackColor = true;
            this.cbSupportBlockUsed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // rtbxPrompt1
            // 
            this.rtbxPrompt1.Location = new System.Drawing.Point(71, 245);
            this.rtbxPrompt1.Name = "rtbxPrompt1";
            this.rtbxPrompt1.Size = new System.Drawing.Size(287, 35);
            this.rtbxPrompt1.TabIndex = 99;
            this.rtbxPrompt1.Text = "";
            this.rtbxPrompt1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // rtbxPrompt2
            // 
            this.rtbxPrompt2.Location = new System.Drawing.Point(71, 286);
            this.rtbxPrompt2.Name = "rtbxPrompt2";
            this.rtbxPrompt2.Size = new System.Drawing.Size(287, 35);
            this.rtbxPrompt2.TabIndex = 101;
            this.rtbxPrompt2.Text = "";
            this.rtbxPrompt2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 283);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 26);
            this.label10.TabIndex = 100;
            this.label10.Text = "Prompt2";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbxRemark2
            // 
            this.rtbxRemark2.Location = new System.Drawing.Point(71, 368);
            this.rtbxRemark2.Name = "rtbxRemark2";
            this.rtbxRemark2.Size = new System.Drawing.Size(287, 35);
            this.rtbxRemark2.TabIndex = 105;
            this.rtbxRemark2.Text = "";
            this.rtbxRemark2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 365);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 26);
            this.label11.TabIndex = 104;
            this.label11.Text = "Remark2";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbxRemark1
            // 
            this.rtbxRemark1.Location = new System.Drawing.Point(71, 327);
            this.rtbxRemark1.Name = "rtbxRemark1";
            this.rtbxRemark1.Size = new System.Drawing.Size(287, 35);
            this.rtbxRemark1.TabIndex = 103;
            this.rtbxRemark1.Text = "";
            this.rtbxRemark1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxBuildSheetNo_MouseDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 324);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(165, 26);
            this.label12.TabIndex = 102;
            this.label12.Text = "Remark1";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rtbxRemark2);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.tbxBuildSheetNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtbxRemark1);
            this.groupBox1.Controls.Add(this.tbxProcessBarcode);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rtbxPrompt2);
            this.groupBox1.Controls.Add(this.tbxMaterialPartNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rtbxPrompt1);
            this.groupBox1.Controls.Add(this.tbxRecipe);
            this.groupBox1.Controls.Add(this.cbSupportBlockUsed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxHandlerRecipe);
            this.groupBox1.Controls.Add(this.tbxNeedleType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxPump);
            this.groupBox1.Location = new System.Drawing.Point(541, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox1.Size = new System.Drawing.Size(364, 457);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recipe Item ";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 467);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 26);
            this.label8.TabIndex = 107;
            this.label8.Text = "MACHINE NO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(460, 12);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 108;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDn
            // 
            this.btnMoveDn.Location = new System.Drawing.Point(460, 41);
            this.btnMoveDn.Name = "btnMoveDn";
            this.btnMoveDn.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDn.TabIndex = 109;
            this.btnMoveDn.Text = "Move Dn";
            this.btnMoveDn.UseVisualStyleBackColor = true;
            this.btnMoveDn.Click += new System.EventHandler(this.btnMoveDn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(460, 441);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 110;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbManualExpiry
            // 
            this.cbManualExpiry.AutoSize = true;
            this.cbManualExpiry.Location = new System.Drawing.Point(241, 470);
            this.cbManualExpiry.Name = "cbManualExpiry";
            this.cbManualExpiry.Size = new System.Drawing.Size(132, 18);
            this.cbManualExpiry.TabIndex = 111;
            this.cbManualExpiry.Text = "Manual Expiry Entry";
            this.cbManualExpiry.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(12, 495);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 26);
            this.label13.TabIndex = 106;
            this.label13.Text = "MATERIAL LIFE (Hours)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudMaterialLife
            // 
            this.nudMaterialLife.Location = new System.Drawing.Point(167, 498);
            this.nudMaterialLife.Name = "nudMaterialLife";
            this.nudMaterialLife.Size = new System.Drawing.Size(67, 22);
            this.nudMaterialLife.TabIndex = 112;
            this.nudMaterialLife.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmLotEntryAnalogSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(923, 534);
            this.ControlBox = false;
            this.Controls.Add(this.nudMaterialLife);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbManualExpiry);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnMoveDn);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxMachineNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbxRecipeItem);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLotEntryAnalogSetup";
            this.Text = "Lot Entry Setup";
            this.Load += new System.EventHandler(this.frmLotEntryAnalogSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaterialLife)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxRecipeItem;
        private System.Windows.Forms.TextBox tbxMachineNo;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbxBuildSheetNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbxProcessBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxMaterialPartNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxRecipe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxHandlerRecipe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPump;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxNeedleType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbSupportBlockUsed;
        private System.Windows.Forms.RichTextBox rtbxPrompt1;
        private System.Windows.Forms.RichTextBox rtbxPrompt2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtbxRemark2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox rtbxRemark1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox cbManualExpiry;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudMaterialLife;
    }
}