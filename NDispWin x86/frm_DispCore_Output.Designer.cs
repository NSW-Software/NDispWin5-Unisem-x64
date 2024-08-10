namespace DispCore
{
    partial class frm_DispCore_OutputWindow
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
            this.lbox_Output = new System.Windows.Forms.ListBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbox_Output
            // 
            this.lbox_Output.FormattingEnabled = true;
            this.lbox_Output.Location = new System.Drawing.Point(6, 6);
            this.lbox_Output.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbox_Output.Name = "lbox_Output";
            this.lbox_Output.Size = new System.Drawing.Size(658, 498);
            this.lbox_Output.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(589, 511);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Interval = 500;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // frm_DispCore_OutputWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(702, 577);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbox_Output);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_DispCore_OutputWindow";
            this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text = "Output Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbox_Output;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Timer tmr_Display;
    }
}