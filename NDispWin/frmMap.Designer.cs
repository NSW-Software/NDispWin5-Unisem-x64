namespace NDispWin
{
    partial class frm_DispCore_Map
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
            this.pbox_Map = new System.Windows.Forms.PictureBox();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.pbox_Image = new System.Windows.Forms.PictureBox();
            this.lbl_ReadID = new System.Windows.Forms.Label();
            this.lblEditMap = new System.Windows.Forms.Label();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.lbl_MapCurr = new System.Windows.Forms.Label();
            this.lbl_MapPrev = new System.Windows.Forms.Label();
            this.lbl_ImgCurr = new System.Windows.Forms.Label();
            this.lbl_ImgPrev = new System.Windows.Forms.Label();
            this.lbl_Clear = new System.Windows.Forms.Label();
            this.lbl_123 = new System.Windows.Forms.Label();
            this.lbl_LayoutNo = new System.Windows.Forms.Label();
            this.lbl_MoveTo = new System.Windows.Forms.Label();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).BeginInit();
            this.pnl_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbox_Map
            // 
            this.pbox_Map.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbox_Map.Location = new System.Drawing.Point(0, 49);
            this.pbox_Map.Margin = new System.Windows.Forms.Padding(0);
            this.pbox_Map.Name = "pbox_Map";
            this.pbox_Map.Size = new System.Drawing.Size(282, 277);
            this.pbox_Map.TabIndex = 0;
            this.pbox_Map.TabStop = false;
            this.pbox_Map.SizeChanged += new System.EventHandler(this.pbox_Map_SizeChanged);
            this.pbox_Map.Paint += new System.Windows.Forms.PaintEventHandler(this.pbox_Map_Paint);
            this.pbox_Map.DoubleClick += new System.EventHandler(this.pbox_Map_DoubleClick);
            this.pbox_Map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbox_Map_MouseClick);
            this.pbox_Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbox_Map_MouseDown);
            this.pbox_Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbox_Map_MouseMove);
            this.pbox_Map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbox_Map_MouseUp);
            this.pbox_Map.Resize += new System.EventHandler(this.pbox_Map_Resize);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Interval = 50;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // pbox_Image
            // 
            this.pbox_Image.BackColor = System.Drawing.SystemColors.Control;
            this.pbox_Image.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbox_Image.Location = new System.Drawing.Point(162, 64);
            this.pbox_Image.Margin = new System.Windows.Forms.Padding(0);
            this.pbox_Image.Name = "pbox_Image";
            this.pbox_Image.Size = new System.Drawing.Size(282, 277);
            this.pbox_Image.TabIndex = 7;
            this.pbox_Image.TabStop = false;
            // 
            // lbl_ReadID
            // 
            this.lbl_ReadID.AutoSize = true;
            this.lbl_ReadID.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_ReadID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_ReadID.Location = new System.Drawing.Point(29, 9);
            this.lbl_ReadID.Name = "lbl_ReadID";
            this.lbl_ReadID.Size = new System.Drawing.Size(46, 14);
            this.lbl_ReadID.TabIndex = 9;
            this.lbl_ReadID.Text = "ReadID";
            // 
            // lblEditMap
            // 
            this.lblEditMap.AccessibleDescription = "Edit";
            this.lblEditMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEditMap.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditMap.ForeColor = System.Drawing.Color.Navy;
            this.lblEditMap.Location = new System.Drawing.Point(669, 0);
            this.lblEditMap.Name = "lblEditMap";
            this.lblEditMap.Size = new System.Drawing.Size(35, 22);
            this.lblEditMap.TabIndex = 12;
            this.lblEditMap.Text = "Edit";
            this.lblEditMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEditMap.Click += new System.EventHandler(this.lblEditMap_Click);
            // 
            // lbl_Close
            // 
            this.lbl_Close.AccessibleDescription = "Close";
            this.lbl_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Close.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Close.ForeColor = System.Drawing.Color.Navy;
            this.lbl_Close.Location = new System.Drawing.Point(704, 0);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(60, 22);
            this.lbl_Close.TabIndex = 4;
            this.lbl_Close.Text = "X";
            this.lbl_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Close.Click += new System.EventHandler(this.lbl_Close_Click);
            // 
            // lbl_MapCurr
            // 
            this.lbl_MapCurr.AccessibleDescription = "MapCurr";
            this.lbl_MapCurr.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_MapCurr.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MapCurr.ForeColor = System.Drawing.Color.Navy;
            this.lbl_MapCurr.Location = new System.Drawing.Point(599, 0);
            this.lbl_MapCurr.Name = "lbl_MapCurr";
            this.lbl_MapCurr.Size = new System.Drawing.Size(70, 22);
            this.lbl_MapCurr.TabIndex = 3;
            this.lbl_MapCurr.Text = "MapCurr";
            this.lbl_MapCurr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MapCurr.Click += new System.EventHandler(this.lbl_MapCurr_Click);
            // 
            // lbl_MapPrev
            // 
            this.lbl_MapPrev.AccessibleDescription = "MapPrev";
            this.lbl_MapPrev.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_MapPrev.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MapPrev.ForeColor = System.Drawing.Color.Navy;
            this.lbl_MapPrev.Location = new System.Drawing.Point(529, 0);
            this.lbl_MapPrev.Name = "lbl_MapPrev";
            this.lbl_MapPrev.Size = new System.Drawing.Size(70, 22);
            this.lbl_MapPrev.TabIndex = 2;
            this.lbl_MapPrev.Text = "MapPrev";
            this.lbl_MapPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MapPrev.Click += new System.EventHandler(this.lbl_MapPrev_Click);
            // 
            // lbl_ImgCurr
            // 
            this.lbl_ImgCurr.AccessibleDescription = "ImgCurr";
            this.lbl_ImgCurr.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_ImgCurr.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ImgCurr.ForeColor = System.Drawing.Color.Navy;
            this.lbl_ImgCurr.Location = new System.Drawing.Point(469, 0);
            this.lbl_ImgCurr.Name = "lbl_ImgCurr";
            this.lbl_ImgCurr.Size = new System.Drawing.Size(60, 22);
            this.lbl_ImgCurr.TabIndex = 0;
            this.lbl_ImgCurr.Text = "ImgCurr";
            this.lbl_ImgCurr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ImgCurr.Visible = false;
            this.lbl_ImgCurr.Click += new System.EventHandler(this.lbl_ImgCurr_Click);
            // 
            // lbl_ImgPrev
            // 
            this.lbl_ImgPrev.AccessibleDescription = "ImgPrev";
            this.lbl_ImgPrev.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_ImgPrev.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ImgPrev.ForeColor = System.Drawing.Color.Navy;
            this.lbl_ImgPrev.Location = new System.Drawing.Point(409, 0);
            this.lbl_ImgPrev.Name = "lbl_ImgPrev";
            this.lbl_ImgPrev.Size = new System.Drawing.Size(60, 22);
            this.lbl_ImgPrev.TabIndex = 10;
            this.lbl_ImgPrev.Text = "ImgPrev";
            this.lbl_ImgPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ImgPrev.Visible = false;
            this.lbl_ImgPrev.Click += new System.EventHandler(this.lbl_ImgPrev_Click);
            // 
            // lbl_Clear
            // 
            this.lbl_Clear.AccessibleDescription = "Clear";
            this.lbl_Clear.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Clear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Clear.ForeColor = System.Drawing.Color.Navy;
            this.lbl_Clear.Location = new System.Drawing.Point(349, 0);
            this.lbl_Clear.Name = "lbl_Clear";
            this.lbl_Clear.Size = new System.Drawing.Size(60, 22);
            this.lbl_Clear.TabIndex = 6;
            this.lbl_Clear.Text = "Clear";
            this.lbl_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Clear.Click += new System.EventHandler(this.lbl_Clear_Click);
            // 
            // lbl_123
            // 
            this.lbl_123.AccessibleDescription = "123";
            this.lbl_123.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_123.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_123.ForeColor = System.Drawing.Color.Navy;
            this.lbl_123.Location = new System.Drawing.Point(289, 0);
            this.lbl_123.Name = "lbl_123";
            this.lbl_123.Size = new System.Drawing.Size(60, 22);
            this.lbl_123.TabIndex = 5;
            this.lbl_123.Text = "123";
            this.lbl_123.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_123.Click += new System.EventHandler(this.lbl_123_Click);
            // 
            // lbl_LayoutNo
            // 
            this.lbl_LayoutNo.AccessibleDescription = "";
            this.lbl_LayoutNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_LayoutNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LayoutNo.ForeColor = System.Drawing.Color.Navy;
            this.lbl_LayoutNo.Location = new System.Drawing.Point(229, 0);
            this.lbl_LayoutNo.Name = "lbl_LayoutNo";
            this.lbl_LayoutNo.Size = new System.Drawing.Size(60, 22);
            this.lbl_LayoutNo.TabIndex = 11;
            this.lbl_LayoutNo.Text = "ID";
            this.lbl_LayoutNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_LayoutNo.Click += new System.EventHandler(this.lbl_LayoutNo_Click);
            // 
            // lbl_MoveTo
            // 
            this.lbl_MoveTo.AccessibleDescription = "MoveTo";
            this.lbl_MoveTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_MoveTo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MoveTo.ForeColor = System.Drawing.Color.Navy;
            this.lbl_MoveTo.Location = new System.Drawing.Point(169, 0);
            this.lbl_MoveTo.Name = "lbl_MoveTo";
            this.lbl_MoveTo.Size = new System.Drawing.Size(60, 22);
            this.lbl_MoveTo.TabIndex = 9;
            this.lbl_MoveTo.Text = "MoveTo";
            this.lbl_MoveTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MoveTo.Click += new System.EventHandler(this.lbl_MoveTo_Click);
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.Controls.Add(this.lblState);
            this.pnl_Bottom.Controls.Add(this.lbl_MoveTo);
            this.pnl_Bottom.Controls.Add(this.lbl_LayoutNo);
            this.pnl_Bottom.Controls.Add(this.lbl_123);
            this.pnl_Bottom.Controls.Add(this.lbl_Clear);
            this.pnl_Bottom.Controls.Add(this.lbl_ImgPrev);
            this.pnl_Bottom.Controls.Add(this.lbl_ImgCurr);
            this.pnl_Bottom.Controls.Add(this.lbl_MapPrev);
            this.pnl_Bottom.Controls.Add(this.lbl_MapCurr);
            this.pnl_Bottom.Controls.Add(this.lblEditMap);
            this.pnl_Bottom.Controls.Add(this.lbl_Close);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 513);
            this.pnl_Bottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(764, 22);
            this.pnl_Bottom.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(602, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Wheat;
            this.button2.Location = new System.Drawing.Point(603, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(603, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightYellow;
            this.button4.Location = new System.Drawing.Point(602, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "button2";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lblState
            // 
            this.lblState.AccessibleDescription = "MoveTo";
            this.lblState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblState.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.Navy;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(88, 22);
            this.lblState.TabIndex = 13;
            this.lblState.Text = "(View Only)";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_DispCore_Map
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(764, 535);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_ReadID);
            this.Controls.Add(this.pbox_Image);
            this.Controls.Add(this.pbox_Map);
            this.Controls.Add(this.pnl_Bottom);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frm_DispCore_Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_Map_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_Map_FormClosed);
            this.Load += new System.EventHandler(this.frmMap_Load);
            this.VisibleChanged += new System.EventHandler(this.frmMap_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).EndInit();
            this.pnl_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox_Map;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.PictureBox pbox_Image;
        private System.Windows.Forms.Label lbl_ReadID;
        private System.Windows.Forms.Label lblEditMap;
        private System.Windows.Forms.Label lbl_Close;
        private System.Windows.Forms.Label lbl_MapCurr;
        private System.Windows.Forms.Label lbl_MapPrev;
        private System.Windows.Forms.Label lbl_ImgCurr;
        private System.Windows.Forms.Label lbl_ImgPrev;
        private System.Windows.Forms.Label lbl_Clear;
        private System.Windows.Forms.Label lbl_123;
        private System.Windows.Forms.Label lbl_LayoutNo;
        private System.Windows.Forms.Label lbl_MoveTo;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblState;
    }
}