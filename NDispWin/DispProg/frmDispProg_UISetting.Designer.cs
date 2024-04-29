namespace NDispWin
{
    partial class frm_DispCore_DispProg_UISetting
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
            this.btn_MoveDn = new System.Windows.Forms.Button();
            this.btn_MoveUp = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lbox_Function = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbox_FunctionList = new System.Windows.Forms.ListBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpage_Command = new System.Windows.Forms.TabPage();
            this.btn_RemoveAll = new System.Windows.Forms.Button();
            this.btn_AddAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbox_CommandList = new System.Windows.Forms.ListBox();
            this.btn_RemoveCommand = new System.Windows.Forms.Button();
            this.lbox_Command = new System.Windows.Forms.ListBox();
            this.btn_AddCommand = new System.Windows.Forms.Button();
            this.tpage_TRControlPanel = new System.Windows.Forms.TabPage();
            this.btn_TRRemoveAll = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpage_Command.SuspendLayout();
            this.tpage_TRControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_MoveDn
            // 
            this.btn_MoveDn.AccessibleDescription = "Move Dn";
            this.btn_MoveDn.Location = new System.Drawing.Point(132, 162);
            this.btn_MoveDn.Name = "btn_MoveDn";
            this.btn_MoveDn.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveDn.TabIndex = 8;
            this.btn_MoveDn.Text = "Move Dn";
            this.btn_MoveDn.UseVisualStyleBackColor = true;
            this.btn_MoveDn.Click += new System.EventHandler(this.btn_MoveDn_Click);
            // 
            // btn_MoveUp
            // 
            this.btn_MoveUp.AccessibleDescription = "Move Up";
            this.btn_MoveUp.Location = new System.Drawing.Point(132, 133);
            this.btn_MoveUp.Name = "btn_MoveUp";
            this.btn_MoveUp.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveUp.TabIndex = 7;
            this.btn_MoveUp.Text = "Move Up";
            this.btn_MoveUp.UseVisualStyleBackColor = true;
            this.btn_MoveUp.Click += new System.EventHandler(this.btn_MoveUp_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.AccessibleDescription = "Remove";
            this.btn_Remove.Location = new System.Drawing.Point(132, 191);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(75, 23);
            this.btn_Remove.TabIndex = 6;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.AccessibleDescription = "Add >>";
            this.btn_Add.Location = new System.Drawing.Point(132, 29);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "Add >>";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lbox_Function
            // 
            this.lbox_Function.ForeColor = System.Drawing.Color.Navy;
            this.lbox_Function.FormattingEnabled = true;
            this.lbox_Function.ItemHeight = 14;
            this.lbox_Function.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.lbox_Function.Location = new System.Drawing.Point(213, 29);
            this.lbox_Function.Name = "lbox_Function";
            this.lbox_Function.Size = new System.Drawing.Size(120, 214);
            this.lbox_Function.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Function List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbox_FunctionList
            // 
            this.lbox_FunctionList.ForeColor = System.Drawing.Color.Navy;
            this.lbox_FunctionList.FormattingEnabled = true;
            this.lbox_FunctionList.ItemHeight = 14;
            this.lbox_FunctionList.Location = new System.Drawing.Point(6, 29);
            this.lbox_FunctionList.Name = "lbox_FunctionList";
            this.lbox_FunctionList.Size = new System.Drawing.Size(120, 214);
            this.lbox_FunctionList.TabIndex = 2;
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(281, 6);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 36);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpage_Command);
            this.tabControl1.Controls.Add(this.tpage_TRControlPanel);
            this.tabControl1.Location = new System.Drawing.Point(6, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(350, 419);
            this.tabControl1.TabIndex = 2;
            // 
            // tpage_Command
            // 
            this.tpage_Command.Controls.Add(this.btn_RemoveAll);
            this.tpage_Command.Controls.Add(this.btn_AddAll);
            this.tpage_Command.Controls.Add(this.label2);
            this.tpage_Command.Controls.Add(this.lbox_CommandList);
            this.tpage_Command.Controls.Add(this.btn_RemoveCommand);
            this.tpage_Command.Controls.Add(this.lbox_Command);
            this.tpage_Command.Controls.Add(this.btn_AddCommand);
            this.tpage_Command.Location = new System.Drawing.Point(4, 23);
            this.tpage_Command.Name = "tpage_Command";
            this.tpage_Command.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Command.Size = new System.Drawing.Size(342, 392);
            this.tpage_Command.TabIndex = 0;
            this.tpage_Command.Text = "Command";
            this.tpage_Command.UseVisualStyleBackColor = true;
            // 
            // btn_RemoveAll
            // 
            this.btn_RemoveAll.AccessibleDescription = "Remove All";
            this.btn_RemoveAll.Location = new System.Drawing.Point(132, 331);
            this.btn_RemoveAll.Name = "btn_RemoveAll";
            this.btn_RemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveAll.TabIndex = 13;
            this.btn_RemoveAll.Text = "Remove All";
            this.btn_RemoveAll.UseVisualStyleBackColor = true;
            this.btn_RemoveAll.Click += new System.EventHandler(this.btn_RemoveAll_Click);
            // 
            // btn_AddAll
            // 
            this.btn_AddAll.AccessibleDescription = "Add All";
            this.btn_AddAll.Location = new System.Drawing.Point(132, 58);
            this.btn_AddAll.Name = "btn_AddAll";
            this.btn_AddAll.Size = new System.Drawing.Size(75, 23);
            this.btn_AddAll.TabIndex = 12;
            this.btn_AddAll.Text = "Add All";
            this.btn_AddAll.UseVisualStyleBackColor = true;
            this.btn_AddAll.Click += new System.EventHandler(this.btn_AddAll_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "List";
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "List";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbox_CommandList
            // 
            this.lbox_CommandList.ForeColor = System.Drawing.Color.Navy;
            this.lbox_CommandList.FormattingEnabled = true;
            this.lbox_CommandList.ItemHeight = 14;
            this.lbox_CommandList.Location = new System.Drawing.Point(6, 29);
            this.lbox_CommandList.Name = "lbox_CommandList";
            this.lbox_CommandList.Size = new System.Drawing.Size(120, 354);
            this.lbox_CommandList.TabIndex = 7;
            // 
            // btn_RemoveCommand
            // 
            this.btn_RemoveCommand.AccessibleDescription = "Remove";
            this.btn_RemoveCommand.Location = new System.Drawing.Point(132, 360);
            this.btn_RemoveCommand.Name = "btn_RemoveCommand";
            this.btn_RemoveCommand.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveCommand.TabIndex = 10;
            this.btn_RemoveCommand.Text = "Remove";
            this.btn_RemoveCommand.UseVisualStyleBackColor = true;
            this.btn_RemoveCommand.Click += new System.EventHandler(this.btn_RemoveCommand_Click);
            // 
            // lbox_Command
            // 
            this.lbox_Command.ForeColor = System.Drawing.Color.Navy;
            this.lbox_Command.FormattingEnabled = true;
            this.lbox_Command.ItemHeight = 14;
            this.lbox_Command.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.lbox_Command.Location = new System.Drawing.Point(213, 29);
            this.lbox_Command.Name = "lbox_Command";
            this.lbox_Command.Size = new System.Drawing.Size(120, 354);
            this.lbox_Command.TabIndex = 8;
            // 
            // btn_AddCommand
            // 
            this.btn_AddCommand.AccessibleDescription = "Add >>";
            this.btn_AddCommand.Location = new System.Drawing.Point(132, 29);
            this.btn_AddCommand.Name = "btn_AddCommand";
            this.btn_AddCommand.Size = new System.Drawing.Size(75, 23);
            this.btn_AddCommand.TabIndex = 9;
            this.btn_AddCommand.Text = "Add >>";
            this.btn_AddCommand.UseVisualStyleBackColor = true;
            this.btn_AddCommand.Click += new System.EventHandler(this.btn_AddCommand_Click);
            // 
            // tpage_TRControlPanel
            // 
            this.tpage_TRControlPanel.Controls.Add(this.btn_TRRemoveAll);
            this.tpage_TRControlPanel.Controls.Add(this.btn_MoveDn);
            this.tpage_TRControlPanel.Controls.Add(this.label1);
            this.tpage_TRControlPanel.Controls.Add(this.btn_MoveUp);
            this.tpage_TRControlPanel.Controls.Add(this.lbox_FunctionList);
            this.tpage_TRControlPanel.Controls.Add(this.btn_Remove);
            this.tpage_TRControlPanel.Controls.Add(this.lbox_Function);
            this.tpage_TRControlPanel.Controls.Add(this.btn_Add);
            this.tpage_TRControlPanel.Location = new System.Drawing.Point(4, 23);
            this.tpage_TRControlPanel.Name = "tpage_TRControlPanel";
            this.tpage_TRControlPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_TRControlPanel.Size = new System.Drawing.Size(342, 392);
            this.tpage_TRControlPanel.TabIndex = 1;
            this.tpage_TRControlPanel.Text = "TR Control Panel";
            this.tpage_TRControlPanel.UseVisualStyleBackColor = true;
            // 
            // btn_TRRemoveAll
            // 
            this.btn_TRRemoveAll.AccessibleDescription = "Remove All";
            this.btn_TRRemoveAll.Location = new System.Drawing.Point(132, 220);
            this.btn_TRRemoveAll.Name = "btn_TRRemoveAll";
            this.btn_TRRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btn_TRRemoveAll.TabIndex = 9;
            this.btn_TRRemoveAll.Text = "Remove All";
            this.btn_TRRemoveAll.UseVisualStyleBackColor = true;
            this.btn_TRRemoveAll.Click += new System.EventHandler(this.btn_TRRemoveAll_Click);
            // 
            // frm_DispCore_DispProg_UISetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(390, 498);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_DispCore_DispProg_UISetting";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "UI Setting";
            this.Load += new System.EventHandler(this.frmDispProg_UISetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpage_Command.ResumeLayout(false);
            this.tpage_TRControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListBox lbox_Function;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbox_FunctionList;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_MoveDn;
        private System.Windows.Forms.Button btn_MoveUp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpage_Command;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbox_CommandList;
        private System.Windows.Forms.Button btn_RemoveCommand;
        private System.Windows.Forms.ListBox lbox_Command;
        private System.Windows.Forms.Button btn_AddCommand;
        private System.Windows.Forms.TabPage tpage_TRControlPanel;
        private System.Windows.Forms.Button btn_AddAll;
        //private Microsoft.VisualBasic.PowerPacks.Printing.PrintForm printForm1;
        private System.Windows.Forms.Button btn_RemoveAll;
        private System.Windows.Forms.Button btn_TRRemoveAll;
    }
}