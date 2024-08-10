namespace NDispWin
{
    partial class frmDevice
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
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnDeleteRecipe = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_LoadHandler = new System.Windows.Forms.Button();
            this.lbl_Handler = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_LoadProgram = new System.Windows.Forms.Button();
            this.lbl_Program = new System.Windows.Forms.Label();
            this.lbl_Recipe = new System.Windows.Forms.Label();
            this.btnSaveDevice = new System.Windows.Forms.Button();
            this.btnLoadDevice = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox10
            // 
            this.groupBox10.AccessibleDescription = "DEVICE RECIPE";
            this.groupBox10.AutoSize = true;
            this.groupBox10.Controls.Add(this.btnDeleteRecipe);
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Controls.Add(this.btn_LoadHandler);
            this.groupBox10.Controls.Add(this.lbl_Handler);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.btn_LoadProgram);
            this.groupBox10.Controls.Add(this.lbl_Program);
            this.groupBox10.Controls.Add(this.lbl_Recipe);
            this.groupBox10.Controls.Add(this.btnSaveDevice);
            this.groupBox10.Controls.Add(this.btnLoadDevice);
            this.groupBox10.Location = new System.Drawing.Point(8, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(633, 174);
            this.groupBox10.TabIndex = 16;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Device Recipe";
            // 
            // btnDeleteRecipe
            // 
            this.btnDeleteRecipe.AccessibleDescription = "Delete";
            this.btnDeleteRecipe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteRecipe.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteRecipe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteRecipe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteRecipe.Location = new System.Drawing.Point(390, 21);
            this.btnDeleteRecipe.Name = "btnDeleteRecipe";
            this.btnDeleteRecipe.Size = new System.Drawing.Size(75, 40);
            this.btnDeleteRecipe.TabIndex = 98;
            this.btnDeleteRecipe.Text = "Delete";
            this.btnDeleteRecipe.UseVisualStyleBackColor = true;
            this.btnDeleteRecipe.Click += new System.EventHandler(this.btnDeleteRecipe_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Handler";
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 97;
            this.label3.Text = "Handler";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_LoadHandler
            // 
            this.btn_LoadHandler.AccessibleDescription = "LOAD";
            this.btn_LoadHandler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_LoadHandler.BackColor = System.Drawing.SystemColors.Control;
            this.btn_LoadHandler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LoadHandler.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LoadHandler.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_LoadHandler.Location = new System.Drawing.Point(471, 67);
            this.btn_LoadHandler.Name = "btn_LoadHandler";
            this.btn_LoadHandler.Size = new System.Drawing.Size(75, 40);
            this.btn_LoadHandler.TabIndex = 95;
            this.btn_LoadHandler.Text = "Load";
            this.btn_LoadHandler.UseVisualStyleBackColor = true;
            this.btn_LoadHandler.Click += new System.EventHandler(this.btnLoadHandler_Click);
            // 
            // lbl_Handler
            // 
            this.lbl_Handler.BackColor = System.Drawing.Color.White;
            this.lbl_Handler.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Handler.Location = new System.Drawing.Point(112, 75);
            this.lbl_Handler.Name = "lbl_Handler";
            this.lbl_Handler.Size = new System.Drawing.Size(278, 25);
            this.lbl_Handler.TabIndex = 94;
            this.lbl_Handler.Text = "lbl_Handler";
            this.lbl_Handler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Program";
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 93;
            this.label5.Text = "Program";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_LoadProgram
            // 
            this.btn_LoadProgram.AccessibleDescription = "LOAD";
            this.btn_LoadProgram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_LoadProgram.BackColor = System.Drawing.SystemColors.Control;
            this.btn_LoadProgram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LoadProgram.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LoadProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_LoadProgram.Location = new System.Drawing.Point(471, 113);
            this.btn_LoadProgram.Name = "btn_LoadProgram";
            this.btn_LoadProgram.Size = new System.Drawing.Size(75, 40);
            this.btn_LoadProgram.TabIndex = 91;
            this.btn_LoadProgram.Text = "Load";
            this.btn_LoadProgram.UseVisualStyleBackColor = true;
            this.btn_LoadProgram.Click += new System.EventHandler(this.btn_LoadProgram_Click);
            // 
            // lbl_Program
            // 
            this.lbl_Program.BackColor = System.Drawing.Color.White;
            this.lbl_Program.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Program.Location = new System.Drawing.Point(112, 128);
            this.lbl_Program.Name = "lbl_Program";
            this.lbl_Program.Size = new System.Drawing.Size(278, 25);
            this.lbl_Program.TabIndex = 90;
            this.lbl_Program.Text = "lbl_Program";
            this.lbl_Program.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Recipe
            // 
            this.lbl_Recipe.BackColor = System.Drawing.Color.White;
            this.lbl_Recipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Recipe.Location = new System.Drawing.Point(6, 29);
            this.lbl_Recipe.Name = "lbl_Recipe";
            this.lbl_Recipe.Size = new System.Drawing.Size(378, 25);
            this.lbl_Recipe.TabIndex = 15;
            this.lbl_Recipe.Text = "lbl_Recipe";
            this.lbl_Recipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveDevice
            // 
            this.btnSaveDevice.AccessibleDescription = "Save";
            this.btnSaveDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveDevice.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveDevice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveDevice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveDevice.Location = new System.Drawing.Point(552, 21);
            this.btnSaveDevice.Name = "btnSaveDevice";
            this.btnSaveDevice.Size = new System.Drawing.Size(75, 40);
            this.btnSaveDevice.TabIndex = 14;
            this.btnSaveDevice.Text = "Save";
            this.btnSaveDevice.UseVisualStyleBackColor = true;
            this.btnSaveDevice.Click += new System.EventHandler(this.btnSaveDevice_Click);
            // 
            // btnLoadDevice
            // 
            this.btnLoadDevice.AccessibleDescription = "Load";
            this.btnLoadDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadDevice.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoadDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoadDevice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadDevice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoadDevice.Location = new System.Drawing.Point(471, 21);
            this.btnLoadDevice.Name = "btnLoadDevice";
            this.btnLoadDevice.Size = new System.Drawing.Size(75, 40);
            this.btnLoadDevice.TabIndex = 13;
            this.btnLoadDevice.Text = "Load";
            this.btnLoadDevice.UseVisualStyleBackColor = true;
            this.btnLoadDevice.Click += new System.EventHandler(this.btnLoadDevice_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Close.Location = new System.Drawing.Point(560, 188);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 40);
            this.btn_Close.TabIndex = 97;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // frmDevice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(659, 240);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.groupBox10);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDevice";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDevice";
            this.Load += new System.EventHandler(this.frmDevice_Load);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnDeleteRecipe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_LoadHandler;
        private System.Windows.Forms.Label lbl_Handler;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_LoadProgram;
        private System.Windows.Forms.Label lbl_Program;
        private System.Windows.Forms.Label lbl_Recipe;
        private System.Windows.Forms.Button btnSaveDevice;
        private System.Windows.Forms.Button btnLoadDevice;
        private System.Windows.Forms.Button btn_Close;
    }
}