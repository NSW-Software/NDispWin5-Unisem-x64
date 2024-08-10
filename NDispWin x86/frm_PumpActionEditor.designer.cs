namespace NDispWin
{
    partial class frm_PumpActionEditor
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
            this.lbox_GroupPumpActionList = new System.Windows.Forms.ListBox();
            this.btn_MoveUp = new System.Windows.Forms.Button();
            this.btn_MoveDn = new System.Windows.Forms.Button();
            this.gbox_ActionInfo = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combox_Action = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbox_AltDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_CustomDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_DefDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbox_Name = new System.Windows.Forms.TextBox();
            this.combox_Group = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.btn_ClearName = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbox_ActionInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbox_GroupPumpActionList
            // 
            this.lbox_GroupPumpActionList.FormattingEnabled = true;
            this.lbox_GroupPumpActionList.ItemHeight = 14;
            this.lbox_GroupPumpActionList.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.lbox_GroupPumpActionList.Location = new System.Drawing.Point(9, 47);
            this.lbox_GroupPumpActionList.Name = "lbox_GroupPumpActionList";
            this.lbox_GroupPumpActionList.Size = new System.Drawing.Size(201, 228);
            this.lbox_GroupPumpActionList.TabIndex = 2;
            this.lbox_GroupPumpActionList.SelectedIndexChanged += new System.EventHandler(this.lbox_GroupPumpActionList_SelectedIndexChanged);
            this.lbox_GroupPumpActionList.Click += new System.EventHandler(this.lbox_GroupPumpActionList_Click);
            // 
            // btn_MoveUp
            // 
            this.btn_MoveUp.AccessibleDescription = "Move Up";
            this.btn_MoveUp.Location = new System.Drawing.Point(216, 47);
            this.btn_MoveUp.Name = "btn_MoveUp";
            this.btn_MoveUp.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveUp.TabIndex = 4;
            this.btn_MoveUp.Text = "Move Up";
            this.btn_MoveUp.UseVisualStyleBackColor = true;
            this.btn_MoveUp.Click += new System.EventHandler(this.btn_MoveUp_Click);
            // 
            // btn_MoveDn
            // 
            this.btn_MoveDn.AccessibleDescription = "Move Dn";
            this.btn_MoveDn.Location = new System.Drawing.Point(216, 76);
            this.btn_MoveDn.Name = "btn_MoveDn";
            this.btn_MoveDn.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveDn.TabIndex = 5;
            this.btn_MoveDn.Text = "Move Dn";
            this.btn_MoveDn.UseVisualStyleBackColor = true;
            this.btn_MoveDn.Click += new System.EventHandler(this.btn_MoveDn_Click);
            // 
            // gbox_ActionInfo
            // 
            this.gbox_ActionInfo.AutoSize = true;
            this.gbox_ActionInfo.Controls.Add(this.label5);
            this.gbox_ActionInfo.Controls.Add(this.combox_Action);
            this.gbox_ActionInfo.Controls.Add(this.label3);
            this.gbox_ActionInfo.Controls.Add(this.tbox_AltDesc);
            this.gbox_ActionInfo.Controls.Add(this.label2);
            this.gbox_ActionInfo.Controls.Add(this.tbox_CustomDesc);
            this.gbox_ActionInfo.Controls.Add(this.label1);
            this.gbox_ActionInfo.Controls.Add(this.tbox_DefDesc);
            this.gbox_ActionInfo.Location = new System.Drawing.Point(311, 36);
            this.gbox_ActionInfo.Name = "gbox_ActionInfo";
            this.gbox_ActionInfo.Size = new System.Drawing.Size(282, 308);
            this.gbox_ActionInfo.TabIndex = 7;
            this.gbox_ActionInfo.TabStop = false;
            this.gbox_ActionInfo.Text = "gbox_ActionInfo";
            this.gbox_ActionInfo.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Action";
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "Action";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_Action
            // 
            this.combox_Action.FormattingEnabled = true;
            this.combox_Action.Location = new System.Drawing.Point(96, 19);
            this.combox_Action.Name = "combox_Action";
            this.combox_Action.Size = new System.Drawing.Size(180, 22);
            this.combox_Action.TabIndex = 18;
            this.combox_Action.SelectionChangeCommitted += new System.EventHandler(this.combox_Action_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Alt Desc";
            this.label3.Location = new System.Drawing.Point(6, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Alt Desc";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_AltDesc
            // 
            this.tbox_AltDesc.Location = new System.Drawing.Point(96, 211);
            this.tbox_AltDesc.Multiline = true;
            this.tbox_AltDesc.Name = "tbox_AltDesc";
            this.tbox_AltDesc.Size = new System.Drawing.Size(180, 76);
            this.tbox_AltDesc.TabIndex = 16;
            this.tbox_AltDesc.Leave += new System.EventHandler(this.tbox_AltDesc_Leave);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Custom Desc";
            this.label2.Location = new System.Drawing.Point(6, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Custom Desc";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_CustomDesc
            // 
            this.tbox_CustomDesc.Location = new System.Drawing.Point(96, 129);
            this.tbox_CustomDesc.Multiline = true;
            this.tbox_CustomDesc.Name = "tbox_CustomDesc";
            this.tbox_CustomDesc.Size = new System.Drawing.Size(180, 76);
            this.tbox_CustomDesc.TabIndex = 14;
            this.tbox_CustomDesc.Leave += new System.EventHandler(this.tbox_CustomDesc_Leave);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Default Desc";
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Default Desc";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_DefDesc
            // 
            this.tbox_DefDesc.BackColor = System.Drawing.SystemColors.Control;
            this.tbox_DefDesc.Location = new System.Drawing.Point(96, 47);
            this.tbox_DefDesc.Multiline = true;
            this.tbox_DefDesc.Name = "tbox_DefDesc";
            this.tbox_DefDesc.Size = new System.Drawing.Size(180, 76);
            this.tbox_DefDesc.TabIndex = 12;
            this.tbox_DefDesc.Text = "dsf sdfdsfdsf f sd dfs dfs dfs ds ds dsf ds fds f sd f dsf dsf fds dfs dsf f dfs " +
                "dsfd s f f f ds f ds f  sd fs f s s f fd ds sdf dsf  sd fsd  fds sd  dfs dfs";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Name";
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_Name
            // 
            this.tbox_Name.Location = new System.Drawing.Point(72, 19);
            this.tbox_Name.Name = "tbox_Name";
            this.tbox_Name.Size = new System.Drawing.Size(117, 22);
            this.tbox_Name.TabIndex = 10;
            this.tbox_Name.Leave += new System.EventHandler(this.tbox_Name_Leave);
            // 
            // combox_Group
            // 
            this.combox_Group.FormattingEnabled = true;
            this.combox_Group.Location = new System.Drawing.Point(74, 8);
            this.combox_Group.Name = "combox_Group";
            this.combox_Group.Size = new System.Drawing.Size(138, 22);
            this.combox_Group.TabIndex = 9;
            this.combox_Group.SelectionChangeCommitted += new System.EventHandler(this.combox_Group_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Group";
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Group";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(490, 368);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 30);
            this.btn_Close.TabIndex = 23;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.Location = new System.Drawing.Point(384, 368);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 30);
            this.btn_Save.TabIndex = 22;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.AccessibleDescription = "Load";
            this.btn_Load.Location = new System.Drawing.Point(278, 368);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(100, 30);
            this.btn_Load.TabIndex = 24;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Execute
            // 
            this.btn_Execute.AccessibleDescription = "Execute";
            this.btn_Execute.Location = new System.Drawing.Point(8, 368);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(100, 30);
            this.btn_Execute.TabIndex = 25;
            this.btn_Execute.Text = "Execute";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.btn_Execute_Click);
            // 
            // btn_ClearName
            // 
            this.btn_ClearName.Location = new System.Drawing.Point(192, 19);
            this.btn_ClearName.Name = "btn_ClearName";
            this.btn_ClearName.Size = new System.Drawing.Size(18, 21);
            this.btn_ClearName.TabIndex = 26;
            this.btn_ClearName.Text = "X";
            this.btn_ClearName.UseVisualStyleBackColor = true;
            this.btn_ClearName.Click += new System.EventHandler(this.btn_ClearName_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Action List";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbox_GroupPumpActionList);
            this.groupBox1.Controls.Add(this.btn_ClearName);
            this.groupBox1.Controls.Add(this.btn_MoveUp);
            this.groupBox1.Controls.Add(this.btn_MoveDn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbox_Name);
            this.groupBox1.Location = new System.Drawing.Point(8, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 296);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action List";
            // 
            // frm_PumpActionEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(614, 418);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Execute);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.combox_Group);
            this.Controls.Add(this.gbox_ActionInfo);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_PumpActionEditor";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_PumpActionEditor";
            this.Load += new System.EventHandler(this.frm_PumpActionEditor_Load);
            this.gbox_ActionInfo.ResumeLayout(false);
            this.gbox_ActionInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbox_GroupPumpActionList;
        private System.Windows.Forms.Button btn_MoveUp;
        private System.Windows.Forms.Button btn_MoveDn;
        private System.Windows.Forms.GroupBox gbox_ActionInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbox_Name;
        private System.Windows.Forms.ComboBox combox_Group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbox_AltDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_CustomDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_DefDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combox_Action;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.Button btn_ClearName;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}