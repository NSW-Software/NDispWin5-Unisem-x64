namespace DispCore
{
    partial class frm_DispCore_JogGantryVision
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
            this.lbl_Inst = new System.Windows.Forms.Label();
            this.pnl_Inst = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Retry = new System.Windows.Forms.Button();
            this.pnl_Inst.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Inst
            // 
            this.lbl_Inst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Inst.Location = new System.Drawing.Point(0, 0);
            this.lbl_Inst.Name = "lbl_Inst";
            this.lbl_Inst.Size = new System.Drawing.Size(273, 53);
            this.lbl_Inst.TabIndex = 1;
            this.lbl_Inst.Text = "label1";
            // 
            // pnl_Inst
            // 
            this.pnl_Inst.Controls.Add(this.panel2);
            this.pnl_Inst.Controls.Add(this.panel1);
            this.pnl_Inst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Inst.Location = new System.Drawing.Point(0, 0);
            this.pnl_Inst.Name = "pnl_Inst";
            this.pnl_Inst.Size = new System.Drawing.Size(526, 53);
            this.pnl_Inst.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Inst);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 53);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Retry);
            this.panel1.Controls.Add(this.btn_OK);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(273, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(253, 53);
            this.panel1.TabIndex = 3;
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(8, 8);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(170, 8);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Retry
            // 
            this.btn_Retry.AccessibleDescription = "RETRY";
            this.btn_Retry.Location = new System.Drawing.Point(89, 8);
            this.btn_Retry.Name = "btn_Retry";
            this.btn_Retry.Size = new System.Drawing.Size(75, 36);
            this.btn_Retry.TabIndex = 5;
            this.btn_Retry.Text = "RETRY";
            this.btn_Retry.UseVisualStyleBackColor = true;
            this.btn_Retry.Click += new System.EventHandler(this.btn_Retry_Click);
            // 
            // frm_DispCore_JogGantryVision
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(526, 470);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_Inst);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frm_DispCore_JogGantryVision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_JogGantryVision";
            this.Load += new System.EventHandler(this.frmJogGantryVision_Load);
            this.Shown += new System.EventHandler(this.frm_JogGantryVision_Shown);
            this.Activated += new System.EventHandler(this.frm_JogGantryVision_Activated);
            this.Enter += new System.EventHandler(this.frm_JogGantryVision_Enter);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_JogGantryVision_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_JogGantryVision_KeyDown);
            this.pnl_Inst.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Inst;
        private System.Windows.Forms.Panel pnl_Inst;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Retry;
    }
}