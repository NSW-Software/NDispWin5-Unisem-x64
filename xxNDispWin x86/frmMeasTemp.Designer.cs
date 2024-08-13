
namespace NDispWin
{
    partial class frmMeasTemp
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
            this.pnlType = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMeasID = new System.Windows.Forms.Label();
            this.gbox_HeightPositions = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbGoto = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbxPositions = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.pnlType.SuspendLayout();
            this.gbox_HeightPositions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlType
            // 
            this.pnlType.AutoSize = true;
            this.pnlType.Controls.Add(this.label3);
            this.pnlType.Controls.Add(this.lblMeasID);
            this.pnlType.Location = new System.Drawing.Point(8, 8);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(351, 28);
            this.pnlType.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Meas ID";
            this.label3.Location = new System.Drawing.Point(2, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 44;
            this.label3.Text = "Meas ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMeasID
            // 
            this.lblMeasID.BackColor = System.Drawing.SystemColors.Window;
            this.lblMeasID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMeasID.Location = new System.Drawing.Point(81, 2);
            this.lblMeasID.Margin = new System.Windows.Forms.Padding(2);
            this.lblMeasID.Name = "lblMeasID";
            this.lblMeasID.Size = new System.Drawing.Size(75, 24);
            this.lblMeasID.TabIndex = 45;
            this.lblMeasID.Text = "lblMeasID";
            this.lblMeasID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMeasID.Click += new System.EventHandler(this.lblMeasID_Click);
            // 
            // gbox_HeightPositions
            // 
            this.gbox_HeightPositions.AccessibleDescription = "Height Positions";
            this.gbox_HeightPositions.AutoSize = true;
            this.gbox_HeightPositions.Controls.Add(this.btnUpdate);
            this.gbox_HeightPositions.Controls.Add(this.cbGoto);
            this.gbox_HeightPositions.Controls.Add(this.btnDelete);
            this.gbox_HeightPositions.Controls.Add(this.btnAdd);
            this.gbox_HeightPositions.Controls.Add(this.lbxPositions);
            this.gbox_HeightPositions.Location = new System.Drawing.Point(7, 41);
            this.gbox_HeightPositions.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_HeightPositions.Name = "gbox_HeightPositions";
            this.gbox_HeightPositions.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_HeightPositions.Size = new System.Drawing.Size(352, 305);
            this.gbox_HeightPositions.TabIndex = 55;
            this.gbox_HeightPositions.TabStop = false;
            this.gbox_HeightPositions.Text = "Positions";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleDescription = "";
            this.btnUpdate.Location = new System.Drawing.Point(270, 61);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbGoto
            // 
            this.cbGoto.AutoSize = true;
            this.cbGoto.Location = new System.Drawing.Point(271, 130);
            this.cbGoto.Name = "cbGoto";
            this.cbGoto.Size = new System.Drawing.Size(53, 18);
            this.cbGoto.TabIndex = 32;
            this.cbGoto.Text = "Goto";
            this.cbGoto.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleDescription = "";
            this.btnDelete.Location = new System.Drawing.Point(270, 95);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleDescription = "";
            this.btnAdd.Location = new System.Drawing.Point(270, 27);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbxPositions
            // 
            this.lbxPositions.ForeColor = System.Drawing.Color.Navy;
            this.lbxPositions.FormattingEnabled = true;
            this.lbxPositions.ItemHeight = 14;
            this.lbxPositions.Location = new System.Drawing.Point(8, 27);
            this.lbxPositions.Name = "lbxPositions";
            this.lbxPositions.Size = new System.Drawing.Size(257, 256);
            this.lbxPositions.TabIndex = 29;
            this.lbxPositions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbxPositions_MouseClick);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = "OK";
            this.btnOK.Location = new System.Drawing.Point(205, 350);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 36);
            this.btnOK.TabIndex = 56;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(284, 350);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTest
            // 
            this.btnTest.AccessibleDescription = "Test";
            this.btnTest.Location = new System.Drawing.Point(7, 350);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 36);
            this.btnTest.TabIndex = 58;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmMeasTemp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(373, 416);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.gbox_HeightPositions);
            this.Controls.Add(this.pnlType);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmMeasTemp";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmMeasTemp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMeasTemp_FormClosed);
            this.Load += new System.EventHandler(this.frmMeasTemp_Load);
            this.pnlType.ResumeLayout(false);
            this.gbox_HeightPositions.ResumeLayout(false);
            this.gbox_HeightPositions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMeasID;
        private System.Windows.Forms.GroupBox gbox_HeightPositions;
        private System.Windows.Forms.CheckBox cbGoto;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbxPositions;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnUpdate;
    }
}