namespace NDispWin
{
    partial class frmCmdSelect
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
            this.cbLayout = new System.Windows.Forms.CheckBox();
            this.lbxCmd = new System.Windows.Forms.ListBox();
            this.cbVision = new System.Windows.Forms.CheckBox();
            this.cbHeight = new System.Windows.Forms.CheckBox();
            this.cbDisp = new System.Windows.Forms.CheckBox();
            this.cbMaint = new System.Windows.Forms.CheckBox();
            this.cbMap = new System.Windows.Forms.CheckBox();
            this.cbMeasure = new System.Windows.Forms.CheckBox();
            this.cbVolume = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.cbSortAZ = new System.Windows.Forms.CheckBox();
            this.btnEditCmd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLayout
            // 
            this.cbLayout.AutoSize = true;
            this.cbLayout.Location = new System.Drawing.Point(6, 45);
            this.cbLayout.Name = "cbLayout";
            this.cbLayout.Size = new System.Drawing.Size(90, 18);
            this.cbLayout.TabIndex = 0;
            this.cbLayout.Text = "Layout/Misc";
            this.cbLayout.UseVisualStyleBackColor = true;
            this.cbLayout.Click += new System.EventHandler(this.UpdateCmdList);
            // 
            // lbxCmd
            // 
            this.lbxCmd.FormattingEnabled = true;
            this.lbxCmd.ItemHeight = 14;
            this.lbxCmd.Location = new System.Drawing.Point(119, 8);
            this.lbxCmd.Name = "lbxCmd";
            this.lbxCmd.Size = new System.Drawing.Size(189, 466);
            this.lbxCmd.TabIndex = 1;
            this.lbxCmd.Click += new System.EventHandler(this.lbxCmd_Click);
            // 
            // cbVision
            // 
            this.cbVision.AutoSize = true;
            this.cbVision.Location = new System.Drawing.Point(6, 69);
            this.cbVision.Name = "cbVision";
            this.cbVision.Size = new System.Drawing.Size(80, 18);
            this.cbVision.TabIndex = 2;
            this.cbVision.Text = "Ref/Vision";
            this.cbVision.UseVisualStyleBackColor = true;
            this.cbVision.Click += new System.EventHandler(this.UpdateCmdList);
            // 
            // cbHeight
            // 
            this.cbHeight.AutoSize = true;
            this.cbHeight.Location = new System.Drawing.Point(6, 93);
            this.cbHeight.Name = "cbHeight";
            this.cbHeight.Size = new System.Drawing.Size(62, 18);
            this.cbHeight.TabIndex = 3;
            this.cbHeight.Text = "Height";
            this.cbHeight.UseVisualStyleBackColor = true;
            this.cbHeight.Click += new System.EventHandler(this.UpdateCmdList);
            // 
            // cbDisp
            // 
            this.cbDisp.AutoSize = true;
            this.cbDisp.Location = new System.Drawing.Point(6, 117);
            this.cbDisp.Name = "cbDisp";
            this.cbDisp.Size = new System.Drawing.Size(48, 18);
            this.cbDisp.TabIndex = 4;
            this.cbDisp.Text = "Disp";
            this.cbDisp.UseVisualStyleBackColor = true;
            this.cbDisp.Click += new System.EventHandler(this.UpdateCmdList);
            // 
            // cbMaint
            // 
            this.cbMaint.AutoSize = true;
            this.cbMaint.Location = new System.Drawing.Point(6, 141);
            this.cbMaint.Name = "cbMaint";
            this.cbMaint.Size = new System.Drawing.Size(55, 18);
            this.cbMaint.TabIndex = 5;
            this.cbMaint.Text = "Maint";
            this.cbMaint.UseVisualStyleBackColor = true;
            this.cbMaint.Click += new System.EventHandler(this.UpdateCmdList);
            // 
            // cbMap
            // 
            this.cbMap.AutoSize = true;
            this.cbMap.Location = new System.Drawing.Point(6, 165);
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(48, 18);
            this.cbMap.TabIndex = 6;
            this.cbMap.Text = "Map";
            this.cbMap.UseVisualStyleBackColor = true;
            this.cbMap.Click += new System.EventHandler(this.UpdateCmdList);
            // 
            // cbMeasure
            // 
            this.cbMeasure.AutoSize = true;
            this.cbMeasure.Location = new System.Drawing.Point(6, 189);
            this.cbMeasure.Name = "cbMeasure";
            this.cbMeasure.Size = new System.Drawing.Size(71, 18);
            this.cbMeasure.TabIndex = 7;
            this.cbMeasure.Text = "Measure";
            this.cbMeasure.UseVisualStyleBackColor = true;
            this.cbMeasure.Click += new System.EventHandler(this.UpdateCmdList);
            // 
            // cbVolume
            // 
            this.cbVolume.AutoSize = true;
            this.cbVolume.Location = new System.Drawing.Point(6, 213);
            this.cbVolume.Name = "cbVolume";
            this.cbVolume.Size = new System.Drawing.Size(93, 18);
            this.cbVolume.TabIndex = 8;
            this.cbVolume.Text = "Volume Map";
            this.cbVolume.UseVisualStyleBackColor = true;
            this.cbVolume.Click += new System.EventHandler(this.UpdateCmdList);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.cbAll);
            this.groupBox1.Controls.Add(this.cbLayout);
            this.groupBox1.Controls.Add(this.cbVision);
            this.groupBox1.Controls.Add(this.cbVolume);
            this.groupBox1.Controls.Add(this.cbHeight);
            this.groupBox1.Controls.Add(this.cbMeasure);
            this.groupBox1.Controls.Add(this.cbDisp);
            this.groupBox1.Controls.Add(this.cbMap);
            this.groupBox1.Controls.Add(this.cbMaint);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 252);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command";
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(6, 21);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(38, 18);
            this.cbAll.TabIndex = 9;
            this.cbAll.Text = "All";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.Click += new System.EventHandler(this.cbAll_Click);
            // 
            // cbSortAZ
            // 
            this.cbSortAZ.AutoSize = true;
            this.cbSortAZ.Location = new System.Drawing.Point(14, 266);
            this.cbSortAZ.Name = "cbSortAZ";
            this.cbSortAZ.Size = new System.Drawing.Size(77, 18);
            this.cbSortAZ.TabIndex = 11;
            this.cbSortAZ.Text = "Sort A>Z";
            this.cbSortAZ.UseVisualStyleBackColor = true;
            this.cbSortAZ.Click += new System.EventHandler(this.cbSortAZ_Click);
            // 
            // btnEditCmd
            // 
            this.btnEditCmd.Location = new System.Drawing.Point(8, 451);
            this.btnEditCmd.Name = "btnEditCmd";
            this.btnEditCmd.Size = new System.Drawing.Size(75, 23);
            this.btnEditCmd.TabIndex = 12;
            this.btnEditCmd.Text = "Edit Cmd";
            this.btnEditCmd.UseVisualStyleBackColor = true;
            this.btnEditCmd.Click += new System.EventHandler(this.btnEditCmd_Click);
            // 
            // frmCmdSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(325, 491);
            this.Controls.Add(this.btnEditCmd);
            this.Controls.Add(this.cbSortAZ);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbxCmd);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCmdSelect";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmCmdSelect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCmdSelect_FormClosed);
            this.Load += new System.EventHandler(this.frmCmdSelect_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbLayout;
        private System.Windows.Forms.ListBox lbxCmd;
        private System.Windows.Forms.CheckBox cbVision;
        private System.Windows.Forms.CheckBox cbHeight;
        private System.Windows.Forms.CheckBox cbDisp;
        private System.Windows.Forms.CheckBox cbMaint;
        private System.Windows.Forms.CheckBox cbMap;
        private System.Windows.Forms.CheckBox cbMeasure;
        private System.Windows.Forms.CheckBox cbVolume;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.CheckBox cbSortAZ;
        private System.Windows.Forms.Button btnEditCmd;
    }
}