namespace NDispWin
{
    partial class frm_MHS2ConvPara
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lbl_BoardID = new System.Windows.Forms.Label();
            this.dg_Param = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RANGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_OutStation = new System.Windows.Forms.Button();
            this.btn_ProStation = new System.Windows.Forms.Button();
            this.btn_PreStation = new System.Windows.Forms.Button();
            this.btn_Conv = new System.Windows.Forms.Button();
            this.combox_ProStType = new System.Windows.Forms.ComboBox();
            this.cbox_Buffer2 = new System.Windows.Forms.CheckBox();
            this.cbox_Buffer1 = new System.Windows.Forms.CheckBox();
            this.combox_PreStType = new System.Windows.Forms.ComboBox();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Param)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(699, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 134;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.Location = new System.Drawing.Point(618, 0);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 30);
            this.btn_Save.TabIndex = 132;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_BoardID
            // 
            this.lbl_BoardID.AccessibleDescription = "";
            this.lbl_BoardID.BackColor = System.Drawing.Color.Red;
            this.lbl_BoardID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_BoardID.Location = new System.Drawing.Point(3, 3);
            this.lbl_BoardID.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_BoardID.Name = "lbl_BoardID";
            this.lbl_BoardID.Size = new System.Drawing.Size(120, 26);
            this.lbl_BoardID.TabIndex = 131;
            this.lbl_BoardID.Text = "Board ID0";
            this.lbl_BoardID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dg_Param
            // 
            this.dg_Param.AllowUserToAddRows = false;
            this.dg_Param.AllowUserToDeleteRows = false;
            this.dg_Param.AllowUserToResizeColumns = false;
            this.dg_Param.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg_Param.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dg_Param.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Param.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dg_Param.ColumnHeadersHeight = 29;
            this.dg_Param.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_Param.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Distance,
            this.RANGE,
            this.DESC});
            this.dg_Param.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Param.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dg_Param.Location = new System.Drawing.Point(5, 101);
            this.dg_Param.MultiSelect = false;
            this.dg_Param.Name = "dg_Param";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Param.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dg_Param.RowHeadersVisible = false;
            this.dg_Param.RowHeadersWidth = 51;
            this.dg_Param.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Blue;
            this.dg_Param.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dg_Param.RowTemplate.Height = 24;
            this.dg_Param.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Param.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dg_Param.ShowCellToolTips = false;
            this.dg_Param.ShowEditingIcon = false;
            this.dg_Param.Size = new System.Drawing.Size(772, 447);
            this.dg_Param.TabIndex = 139;
            this.dg_Param.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Param_CellContentClick);
            this.dg_Param.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Param_CellEndEdit);
            this.dg_Param.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Param_CellMouseClick);
            this.dg_Param.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Param_CellMouseDoubleClick);
            // 
            // Index
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.Index.DefaultCellStyle = dataGridViewCellStyle11;
            this.Index.HeaderText = "Param";
            this.Index.MinimumWidth = 6;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Index.Width = 200;
            // 
            // Distance
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Green;
            this.Distance.DefaultCellStyle = dataGridViewCellStyle12;
            this.Distance.HeaderText = "Value";
            this.Distance.MinimumWidth = 6;
            this.Distance.Name = "Distance";
            this.Distance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Distance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Distance.Width = 80;
            // 
            // RANGE
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Gray;
            this.RANGE.DefaultCellStyle = dataGridViewCellStyle13;
            this.RANGE.HeaderText = "(Min ~ Max, Default )";
            this.RANGE.MinimumWidth = 6;
            this.RANGE.Name = "RANGE";
            this.RANGE.ReadOnly = true;
            this.RANGE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RANGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RANGE.Width = 150;
            // 
            // DESC
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Gray;
            this.DESC.DefaultCellStyle = dataGridViewCellStyle14;
            this.DESC.HeaderText = "Desc";
            this.DESC.MinimumWidth = 6;
            this.DESC.Name = "DESC";
            this.DESC.ReadOnly = true;
            this.DESC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DESC.Width = 450;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_OutStation);
            this.panel1.Controls.Add(this.btn_ProStation);
            this.panel1.Controls.Add(this.btn_PreStation);
            this.panel1.Controls.Add(this.btn_Conv);
            this.panel1.Controls.Add(this.combox_ProStType);
            this.panel1.Controls.Add(this.cbox_Buffer2);
            this.panel1.Controls.Add(this.cbox_Buffer1);
            this.panel1.Controls.Add(this.combox_PreStType);
            this.panel1.Controls.Add(this.lbl_BoardID);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 96);
            this.panel1.TabIndex = 140;
            // 
            // btn_OutStation
            // 
            this.btn_OutStation.AccessibleDescription = "Out Station";
            this.btn_OutStation.Location = new System.Drawing.Point(443, 35);
            this.btn_OutStation.Name = "btn_OutStation";
            this.btn_OutStation.Size = new System.Drawing.Size(100, 23);
            this.btn_OutStation.TabIndex = 159;
            this.btn_OutStation.Text = "Out Station";
            this.btn_OutStation.UseVisualStyleBackColor = true;
            this.btn_OutStation.Click += new System.EventHandler(this.btn_OutStation_Click);
            // 
            // btn_ProStation
            // 
            this.btn_ProStation.AccessibleDescription = "Pro Station";
            this.btn_ProStation.Location = new System.Drawing.Point(337, 35);
            this.btn_ProStation.Name = "btn_ProStation";
            this.btn_ProStation.Size = new System.Drawing.Size(100, 23);
            this.btn_ProStation.TabIndex = 158;
            this.btn_ProStation.Text = "Pro Station";
            this.btn_ProStation.UseVisualStyleBackColor = true;
            this.btn_ProStation.Click += new System.EventHandler(this.btn_ProStation_Click);
            // 
            // btn_PreStation
            // 
            this.btn_PreStation.AccessibleDescription = "Pre Station";
            this.btn_PreStation.Location = new System.Drawing.Point(231, 35);
            this.btn_PreStation.Name = "btn_PreStation";
            this.btn_PreStation.Size = new System.Drawing.Size(100, 23);
            this.btn_PreStation.TabIndex = 157;
            this.btn_PreStation.Text = "Pre Station";
            this.btn_PreStation.UseVisualStyleBackColor = true;
            this.btn_PreStation.Click += new System.EventHandler(this.btn_PreStation_Click);
            // 
            // btn_Conv
            // 
            this.btn_Conv.AccessibleDescription = "Conv";
            this.btn_Conv.Location = new System.Drawing.Point(3, 35);
            this.btn_Conv.Name = "btn_Conv";
            this.btn_Conv.Size = new System.Drawing.Size(75, 23);
            this.btn_Conv.TabIndex = 155;
            this.btn_Conv.Text = "Conv";
            this.btn_Conv.UseVisualStyleBackColor = true;
            this.btn_Conv.Click += new System.EventHandler(this.btn_Conv_Click);
            // 
            // combox_ProStType
            // 
            this.combox_ProStType.FormattingEnabled = true;
            this.combox_ProStType.Location = new System.Drawing.Point(337, 63);
            this.combox_ProStType.Name = "combox_ProStType";
            this.combox_ProStType.Size = new System.Drawing.Size(80, 22);
            this.combox_ProStType.TabIndex = 145;
            this.combox_ProStType.SelectionChangeCommitted += new System.EventHandler(this.combox_ProStType_SelectionChangeCommitted);
            // 
            // cbox_Buffer2
            // 
            this.cbox_Buffer2.AccessibleDescription = "Buffer2";
            this.cbox_Buffer2.AutoSize = true;
            this.cbox_Buffer2.Location = new System.Drawing.Point(156, 38);
            this.cbox_Buffer2.Name = "cbox_Buffer2";
            this.cbox_Buffer2.Size = new System.Drawing.Size(66, 18);
            this.cbox_Buffer2.TabIndex = 144;
            this.cbox_Buffer2.Text = "Buffer2";
            this.cbox_Buffer2.UseVisualStyleBackColor = true;
            this.cbox_Buffer2.Click += new System.EventHandler(this.cbox_Buffer2_Click);
            // 
            // cbox_Buffer1
            // 
            this.cbox_Buffer1.AccessibleDescription = "Buffer1";
            this.cbox_Buffer1.AutoSize = true;
            this.cbox_Buffer1.Location = new System.Drawing.Point(84, 38);
            this.cbox_Buffer1.Name = "cbox_Buffer1";
            this.cbox_Buffer1.Size = new System.Drawing.Size(66, 18);
            this.cbox_Buffer1.TabIndex = 143;
            this.cbox_Buffer1.Text = "Buffer1";
            this.cbox_Buffer1.UseVisualStyleBackColor = true;
            this.cbox_Buffer1.Click += new System.EventHandler(this.cbox_Buf1_Click);
            // 
            // combox_PreStType
            // 
            this.combox_PreStType.FormattingEnabled = true;
            this.combox_PreStType.Location = new System.Drawing.Point(231, 63);
            this.combox_PreStType.Name = "combox_PreStType";
            this.combox_PreStType.Size = new System.Drawing.Size(80, 22);
            this.combox_PreStType.TabIndex = 140;
            this.combox_PreStType.SelectionChangeCommitted += new System.EventHandler(this.combox_PreStType_SelectionChangeCommitted);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // frm_MHS2ConvPara
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.dg_Param);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.Name = "frm_MHS2ConvPara";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_MHS2ConvPara";
            this.Activated += new System.EventHandler(this.frm_ConvPara_Activated);
            this.Load += new System.EventHandler(this.frm_ConvParam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Param)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_BoardID;
        private System.Windows.Forms.DataGridView dg_Param;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn RANGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC;
        private System.Windows.Forms.ComboBox combox_PreStType;
        private System.Windows.Forms.CheckBox cbox_Buffer2;
        private System.Windows.Forms.CheckBox cbox_Buffer1;
        private System.Windows.Forms.ComboBox combox_ProStType;
        private System.Windows.Forms.Button btn_OutStation;
        private System.Windows.Forms.Button btn_ProStation;
        private System.Windows.Forms.Button btn_PreStation;
        private System.Windows.Forms.Button btn_Conv;
    }
}