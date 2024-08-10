namespace NDispWin
{
    partial class frm_DispCore_DispTools
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
            this.btn_CleanNeedle = new System.Windows.Forms.Button();
            this.btn_PurgeNeedle = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_TeachNeedle = new System.Windows.Forms.Button();
            this.btn_GotoPMaint = new System.Windows.Forms.Button();
            this.btn_WeightMeasure = new System.Windows.Forms.Button();
            this.btn_GotoMMaint = new System.Windows.Forms.Button();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.btn_DispWeight = new System.Windows.Forms.Button();
            this.pnl_DispTool_PumpTool = new System.Windows.Forms.Panel();
            this.lbl_MaterialTimer = new System.Windows.Forms.Label();
            this.btn_ForceSingle = new System.Windows.Forms.Button();
            this.btn_DispWeight2 = new System.Windows.Forms.Button();
            this.btn_PumpAdjust = new System.Windows.Forms.Button();
            this.btn_DrawOfstAdjust = new System.Windows.Forms.Button();
            this.lbl_OrignOfst = new System.Windows.Forms.Label();
            this.btn_Origin = new System.Windows.Forms.Button();
            this.btn_WeightCalibrate = new System.Windows.Forms.Button();
            this.btn_PumpAction = new System.Windows.Forms.Button();
            this.gbox_PumpAction = new System.Windows.Forms.GroupBox();
            this.btn_PumpActionCancel = new System.Windows.Forms.Button();
            this.btn_PumpAction5 = new System.Windows.Forms.Button();
            this.btn_PumpAction4 = new System.Windows.Forms.Button();
            this.btn_PumpAction3 = new System.Windows.Forms.Button();
            this.btn_PumpAction2 = new System.Windows.Forms.Button();
            this.btn_PumpAction1 = new System.Windows.Forms.Button();
            this.gbox_CPF = new System.Windows.Forms.GroupBox();
            this.btn_CPF_Cancel = new System.Windows.Forms.Button();
            this.btn_CPF_Flush = new System.Windows.Forms.Button();
            this.btn_CPF_Purge = new System.Windows.Forms.Button();
            this.btn_CPF_Clean = new System.Windows.Forms.Button();
            this.btn_CPF = new System.Windows.Forms.Button();
            this.gbox_VolumeOfst = new System.Windows.Forms.GroupBox();
            this.btn_VolOfstModeManual = new System.Windows.Forms.Button();
            this.btn_VolOfstModeAuto = new System.Windows.Forms.Button();
            this.lbl_WaitTimer = new System.Windows.Forms.Label();
            this.btn_VolOfstReset = new System.Windows.Forms.Button();
            this.btn_VolOfstClose = new System.Windows.Forms.Button();
            this.btn_VolOfstModeNone = new System.Windows.Forms.Button();
            this.btn_VolumeOffset = new System.Windows.Forms.Button();
            this.btn_StartIdle = new System.Windows.Forms.Button();
            this.btn_UploadData = new System.Windows.Forms.Button();
            this.pnl_LextarFrontTest = new System.Windows.Forms.Panel();
            this.lbl_WaitData = new System.Windows.Forms.Label();
            this.lbl_Connection = new System.Windows.Forms.Label();
            this.btn_WeightAdjust = new System.Windows.Forms.Button();
            this.gbox_Weight = new System.Windows.Forms.GroupBox();
            this.btn_WeightCancel = new System.Windows.Forms.Button();
            this.btn_Weight = new System.Windows.Forms.Button();
            this.btn_PurgeStage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_SensMat2Low = new System.Windows.Forms.Label();
            this.lbl_SensMat1Low = new System.Windows.Forms.Label();
            this.tmr_5s = new System.Windows.Forms.Timer(this.components);
            this.lbl_MaterialExpiryDT = new System.Windows.Forms.Label();
            this.dtp_ExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_ExpiryTime = new System.Windows.Forms.DateTimePicker();
            this.gbox_DateTime = new System.Windows.Forms.GroupBox();
            this.btn_dtpCancel = new System.Windows.Forms.Button();
            this.btn_dtpOK = new System.Windows.Forms.Button();
            this.dtp_ScanEntry = new System.Windows.Forms.TextBox();
            this.btn_View = new System.Windows.Forms.Button();
            this.btnMaterialChange = new System.Windows.Forms.Button();
            this.gbox_PumpAction.SuspendLayout();
            this.gbox_CPF.SuspendLayout();
            this.gbox_VolumeOfst.SuspendLayout();
            this.pnl_LextarFrontTest.SuspendLayout();
            this.gbox_Weight.SuspendLayout();
            this.gbox_DateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CleanNeedle
            // 
            this.btn_CleanNeedle.AccessibleDescription = "Clean Needle";
            this.btn_CleanNeedle.Location = new System.Drawing.Point(668, 492);
            this.btn_CleanNeedle.Name = "btn_CleanNeedle";
            this.btn_CleanNeedle.Size = new System.Drawing.Size(120, 40);
            this.btn_CleanNeedle.TabIndex = 0;
            this.btn_CleanNeedle.Text = "Clean Needle";
            this.btn_CleanNeedle.UseVisualStyleBackColor = true;
            this.btn_CleanNeedle.Visible = false;
            this.btn_CleanNeedle.Click += new System.EventHandler(this.btn_CleanNeedle_Click);
            // 
            // btn_PurgeNeedle
            // 
            this.btn_PurgeNeedle.AccessibleDescription = "Purge Needle";
            this.btn_PurgeNeedle.Location = new System.Drawing.Point(668, 538);
            this.btn_PurgeNeedle.Name = "btn_PurgeNeedle";
            this.btn_PurgeNeedle.Size = new System.Drawing.Size(120, 40);
            this.btn_PurgeNeedle.TabIndex = 1;
            this.btn_PurgeNeedle.Text = "Purge Needle";
            this.btn_PurgeNeedle.UseVisualStyleBackColor = true;
            this.btn_PurgeNeedle.Visible = false;
            this.btn_PurgeNeedle.Click += new System.EventHandler(this.btn_PurgeNeedle_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(658, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 40);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_TeachNeedle
            // 
            this.btn_TeachNeedle.AccessibleDescription = "Teach Needle";
            this.btn_TeachNeedle.Location = new System.Drawing.Point(382, 4);
            this.btn_TeachNeedle.Name = "btn_TeachNeedle";
            this.btn_TeachNeedle.Size = new System.Drawing.Size(120, 40);
            this.btn_TeachNeedle.TabIndex = 3;
            this.btn_TeachNeedle.Text = "Teach Needle";
            this.btn_TeachNeedle.UseVisualStyleBackColor = true;
            this.btn_TeachNeedle.Click += new System.EventHandler(this.btn_TeachNeedle_Click);
            // 
            // btn_GotoPMaint
            // 
            this.btn_GotoPMaint.AccessibleDescription = "Goto Pump Maint Pos";
            this.btn_GotoPMaint.Location = new System.Drawing.Point(256, 50);
            this.btn_GotoPMaint.Name = "btn_GotoPMaint";
            this.btn_GotoPMaint.Size = new System.Drawing.Size(120, 40);
            this.btn_GotoPMaint.TabIndex = 4;
            this.btn_GotoPMaint.Text = "Goto Pump Maint Pos";
            this.btn_GotoPMaint.UseVisualStyleBackColor = true;
            this.btn_GotoPMaint.Click += new System.EventHandler(this.btn_GotoPMaint_Click);
            // 
            // btn_WeightMeasure
            // 
            this.btn_WeightMeasure.AccessibleDescription = "Measure";
            this.btn_WeightMeasure.Location = new System.Drawing.Point(8, 115);
            this.btn_WeightMeasure.Name = "btn_WeightMeasure";
            this.btn_WeightMeasure.Size = new System.Drawing.Size(120, 40);
            this.btn_WeightMeasure.TabIndex = 5;
            this.btn_WeightMeasure.Text = "Measure";
            this.btn_WeightMeasure.UseVisualStyleBackColor = true;
            this.btn_WeightMeasure.Click += new System.EventHandler(this.btn_WeightMeasure_Click);
            // 
            // btn_GotoMMaint
            // 
            this.btn_GotoMMaint.AccessibleDescription = "Goto Machine Maint Pos";
            this.btn_GotoMMaint.Location = new System.Drawing.Point(256, 4);
            this.btn_GotoMMaint.Name = "btn_GotoMMaint";
            this.btn_GotoMMaint.Size = new System.Drawing.Size(120, 40);
            this.btn_GotoMMaint.TabIndex = 8;
            this.btn_GotoMMaint.Text = "Goto Machine Maint Pos";
            this.btn_GotoMMaint.UseVisualStyleBackColor = true;
            this.btn_GotoMMaint.Click += new System.EventHandler(this.btn_GotoMMaint_Click);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Interval = 500;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // btn_DispWeight
            // 
            this.btn_DispWeight.AccessibleDescription = "Disp Weight";
            this.btn_DispWeight.Location = new System.Drawing.Point(256, 96);
            this.btn_DispWeight.Name = "btn_DispWeight";
            this.btn_DispWeight.Size = new System.Drawing.Size(120, 40);
            this.btn_DispWeight.TabIndex = 35;
            this.btn_DispWeight.Text = "Disp Weight";
            this.btn_DispWeight.UseVisualStyleBackColor = true;
            this.btn_DispWeight.Click += new System.EventHandler(this.btn_DispWeight_Click);
            // 
            // pnl_DispTool_PumpTool
            // 
            this.pnl_DispTool_PumpTool.Location = new System.Drawing.Point(4, 232);
            this.pnl_DispTool_PumpTool.Margin = new System.Windows.Forms.Padding(1);
            this.pnl_DispTool_PumpTool.Name = "pnl_DispTool_PumpTool";
            this.pnl_DispTool_PumpTool.Size = new System.Drawing.Size(650, 330);
            this.pnl_DispTool_PumpTool.TabIndex = 38;
            // 
            // lbl_MaterialTimer
            // 
            this.lbl_MaterialTimer.AccessibleDescription = "";
            this.lbl_MaterialTimer.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_MaterialTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MaterialTimer.Location = new System.Drawing.Point(130, 142);
            this.lbl_MaterialTimer.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MaterialTimer.Name = "lbl_MaterialTimer";
            this.lbl_MaterialTimer.Size = new System.Drawing.Size(120, 40);
            this.lbl_MaterialTimer.TabIndex = 57;
            this.lbl_MaterialTimer.Text = "Material Timer 168H 60M 10S";
            this.lbl_MaterialTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MaterialTimer.Click += new System.EventHandler(this.lbl_MaterialTimer_Click);
            // 
            // btn_ForceSingle
            // 
            this.btn_ForceSingle.AccessibleDescription = "Force Single";
            this.btn_ForceSingle.Location = new System.Drawing.Point(130, 4);
            this.btn_ForceSingle.Name = "btn_ForceSingle";
            this.btn_ForceSingle.Size = new System.Drawing.Size(120, 40);
            this.btn_ForceSingle.TabIndex = 59;
            this.btn_ForceSingle.Text = "Force Single";
            this.btn_ForceSingle.UseVisualStyleBackColor = true;
            this.btn_ForceSingle.Click += new System.EventHandler(this.btn_ForceSingle_Click);
            // 
            // btn_DispWeight2
            // 
            this.btn_DispWeight2.AccessibleDescription = "Disp Weight 2";
            this.btn_DispWeight2.Location = new System.Drawing.Point(256, 142);
            this.btn_DispWeight2.Name = "btn_DispWeight2";
            this.btn_DispWeight2.Size = new System.Drawing.Size(120, 40);
            this.btn_DispWeight2.TabIndex = 60;
            this.btn_DispWeight2.Text = "Disp Weight 2";
            this.btn_DispWeight2.UseVisualStyleBackColor = true;
            this.btn_DispWeight2.Click += new System.EventHandler(this.btn_DispWeight2_Click);
            // 
            // btn_PumpAdjust
            // 
            this.btn_PumpAdjust.AccessibleDescription = "Pump Adjust";
            this.btn_PumpAdjust.Location = new System.Drawing.Point(508, 142);
            this.btn_PumpAdjust.Name = "btn_PumpAdjust";
            this.btn_PumpAdjust.Size = new System.Drawing.Size(120, 40);
            this.btn_PumpAdjust.TabIndex = 61;
            this.btn_PumpAdjust.Text = "Pump Adjust";
            this.btn_PumpAdjust.UseVisualStyleBackColor = true;
            this.btn_PumpAdjust.Click += new System.EventHandler(this.btn_PumpAdjust_Click);
            // 
            // btn_DrawOfstAdjust
            // 
            this.btn_DrawOfstAdjust.AccessibleDescription = "Offset Adjust";
            this.btn_DrawOfstAdjust.Location = new System.Drawing.Point(130, 96);
            this.btn_DrawOfstAdjust.Name = "btn_DrawOfstAdjust";
            this.btn_DrawOfstAdjust.Size = new System.Drawing.Size(120, 40);
            this.btn_DrawOfstAdjust.TabIndex = 63;
            this.btn_DrawOfstAdjust.Text = "Offset Adjust";
            this.btn_DrawOfstAdjust.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_DrawOfstAdjust.UseVisualStyleBackColor = true;
            this.btn_DrawOfstAdjust.Click += new System.EventHandler(this.btn_OriginAdjust_Click);
            // 
            // lbl_OrignOfst
            // 
            this.lbl_OrignOfst.BackColor = System.Drawing.Color.Transparent;
            this.lbl_OrignOfst.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrignOfst.Location = new System.Drawing.Point(133, 116);
            this.lbl_OrignOfst.Name = "lbl_OrignOfst";
            this.lbl_OrignOfst.Size = new System.Drawing.Size(114, 18);
            this.lbl_OrignOfst.TabIndex = 65;
            this.lbl_OrignOfst.Text = "(-1.000,-1.000,-1.000)";
            this.lbl_OrignOfst.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_OrignOfst.Click += new System.EventHandler(this.lbl_OriginOfst_Click);
            // 
            // btn_Origin
            // 
            this.btn_Origin.AccessibleDescription = "Origin";
            this.btn_Origin.Location = new System.Drawing.Point(130, 50);
            this.btn_Origin.Name = "btn_Origin";
            this.btn_Origin.Size = new System.Drawing.Size(120, 40);
            this.btn_Origin.TabIndex = 66;
            this.btn_Origin.Text = "Origin";
            this.btn_Origin.UseVisualStyleBackColor = true;
            this.btn_Origin.Click += new System.EventHandler(this.btn_Origin_Click);
            // 
            // btn_WeightCalibrate
            // 
            this.btn_WeightCalibrate.AccessibleDescription = "Calibrate";
            this.btn_WeightCalibrate.Location = new System.Drawing.Point(8, 69);
            this.btn_WeightCalibrate.Name = "btn_WeightCalibrate";
            this.btn_WeightCalibrate.Size = new System.Drawing.Size(120, 40);
            this.btn_WeightCalibrate.TabIndex = 67;
            this.btn_WeightCalibrate.Text = "Calibrate";
            this.btn_WeightCalibrate.UseVisualStyleBackColor = true;
            this.btn_WeightCalibrate.Click += new System.EventHandler(this.btn_WeightCalibrate_Click);
            // 
            // btn_PumpAction
            // 
            this.btn_PumpAction.AccessibleDescription = "Pump Action";
            this.btn_PumpAction.Location = new System.Drawing.Point(382, 142);
            this.btn_PumpAction.Name = "btn_PumpAction";
            this.btn_PumpAction.Size = new System.Drawing.Size(120, 40);
            this.btn_PumpAction.TabIndex = 72;
            this.btn_PumpAction.Text = "Pump Action";
            this.btn_PumpAction.UseVisualStyleBackColor = true;
            this.btn_PumpAction.Click += new System.EventHandler(this.btn_PumpAction_Click);
            // 
            // gbox_PumpAction
            // 
            this.gbox_PumpAction.AccessibleDescription = "Pump Action";
            this.gbox_PumpAction.AutoSize = true;
            this.gbox_PumpAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_PumpAction.Controls.Add(this.btn_PumpActionCancel);
            this.gbox_PumpAction.Controls.Add(this.btn_PumpAction5);
            this.gbox_PumpAction.Controls.Add(this.btn_PumpAction4);
            this.gbox_PumpAction.Controls.Add(this.btn_PumpAction3);
            this.gbox_PumpAction.Controls.Add(this.btn_PumpAction2);
            this.gbox_PumpAction.Controls.Add(this.btn_PumpAction1);
            this.gbox_PumpAction.Location = new System.Drawing.Point(658, 50);
            this.gbox_PumpAction.Name = "gbox_PumpAction";
            this.gbox_PumpAction.Padding = new System.Windows.Forms.Padding(5);
            this.gbox_PumpAction.Size = new System.Drawing.Size(286, 194);
            this.gbox_PumpAction.TabIndex = 0;
            this.gbox_PumpAction.TabStop = false;
            this.gbox_PumpAction.Text = "Pump Action";
            this.gbox_PumpAction.Visible = false;
            // 
            // btn_PumpActionCancel
            // 
            this.btn_PumpActionCancel.AccessibleDescription = "Cancel";
            this.btn_PumpActionCancel.Location = new System.Drawing.Point(148, 125);
            this.btn_PumpActionCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btn_PumpActionCancel.Name = "btn_PumpActionCancel";
            this.btn_PumpActionCancel.Size = new System.Drawing.Size(128, 40);
            this.btn_PumpActionCancel.TabIndex = 78;
            this.btn_PumpActionCancel.Text = "Cancel";
            this.btn_PumpActionCancel.UseVisualStyleBackColor = true;
            this.btn_PumpActionCancel.Click += new System.EventHandler(this.btn_PumpActionCancel_Click);
            // 
            // btn_PumpAction5
            // 
            this.btn_PumpAction5.AccessibleDescription = "";
            this.btn_PumpAction5.Location = new System.Drawing.Point(10, 125);
            this.btn_PumpAction5.Margin = new System.Windows.Forms.Padding(5);
            this.btn_PumpAction5.Name = "btn_PumpAction5";
            this.btn_PumpAction5.Size = new System.Drawing.Size(128, 40);
            this.btn_PumpAction5.TabIndex = 77;
            this.btn_PumpAction5.Text = "Pump Action 5";
            this.btn_PumpAction5.UseVisualStyleBackColor = true;
            this.btn_PumpAction5.Click += new System.EventHandler(this.btn_PumpAction5_Click);
            // 
            // btn_PumpAction4
            // 
            this.btn_PumpAction4.AccessibleDescription = "";
            this.btn_PumpAction4.Location = new System.Drawing.Point(148, 75);
            this.btn_PumpAction4.Margin = new System.Windows.Forms.Padding(5);
            this.btn_PumpAction4.Name = "btn_PumpAction4";
            this.btn_PumpAction4.Size = new System.Drawing.Size(128, 40);
            this.btn_PumpAction4.TabIndex = 76;
            this.btn_PumpAction4.Text = "Pump Action 4";
            this.btn_PumpAction4.UseVisualStyleBackColor = true;
            this.btn_PumpAction4.Click += new System.EventHandler(this.btn_PumpAction4_Click);
            // 
            // btn_PumpAction3
            // 
            this.btn_PumpAction3.AccessibleDescription = "";
            this.btn_PumpAction3.Location = new System.Drawing.Point(10, 75);
            this.btn_PumpAction3.Margin = new System.Windows.Forms.Padding(5);
            this.btn_PumpAction3.Name = "btn_PumpAction3";
            this.btn_PumpAction3.Size = new System.Drawing.Size(128, 40);
            this.btn_PumpAction3.TabIndex = 75;
            this.btn_PumpAction3.Text = "Pump Action 3";
            this.btn_PumpAction3.UseVisualStyleBackColor = true;
            this.btn_PumpAction3.Click += new System.EventHandler(this.btn_PumpAction3_Click);
            // 
            // btn_PumpAction2
            // 
            this.btn_PumpAction2.AccessibleDescription = "";
            this.btn_PumpAction2.Location = new System.Drawing.Point(148, 25);
            this.btn_PumpAction2.Margin = new System.Windows.Forms.Padding(5);
            this.btn_PumpAction2.Name = "btn_PumpAction2";
            this.btn_PumpAction2.Size = new System.Drawing.Size(128, 40);
            this.btn_PumpAction2.TabIndex = 74;
            this.btn_PumpAction2.Text = "Pump Action 2";
            this.btn_PumpAction2.UseVisualStyleBackColor = true;
            this.btn_PumpAction2.Click += new System.EventHandler(this.btn_PumpAction2_Click);
            // 
            // btn_PumpAction1
            // 
            this.btn_PumpAction1.AccessibleDescription = "";
            this.btn_PumpAction1.Location = new System.Drawing.Point(10, 25);
            this.btn_PumpAction1.Margin = new System.Windows.Forms.Padding(5);
            this.btn_PumpAction1.Name = "btn_PumpAction1";
            this.btn_PumpAction1.Size = new System.Drawing.Size(128, 40);
            this.btn_PumpAction1.TabIndex = 73;
            this.btn_PumpAction1.Text = "Pump Action 1";
            this.btn_PumpAction1.UseVisualStyleBackColor = true;
            this.btn_PumpAction1.Click += new System.EventHandler(this.btn_PumpAction1_Click);
            // 
            // gbox_CPF
            // 
            this.gbox_CPF.AccessibleDescription = "Clean Purge";
            this.gbox_CPF.AutoSize = true;
            this.gbox_CPF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_CPF.Controls.Add(this.btn_CPF_Cancel);
            this.gbox_CPF.Controls.Add(this.btn_CPF_Flush);
            this.gbox_CPF.Controls.Add(this.btn_CPF_Purge);
            this.gbox_CPF.Controls.Add(this.btn_CPF_Clean);
            this.gbox_CPF.Location = new System.Drawing.Point(658, 246);
            this.gbox_CPF.Name = "gbox_CPF";
            this.gbox_CPF.Padding = new System.Windows.Forms.Padding(5);
            this.gbox_CPF.Size = new System.Drawing.Size(140, 244);
            this.gbox_CPF.TabIndex = 73;
            this.gbox_CPF.TabStop = false;
            this.gbox_CPF.Text = "Clean Purge";
            this.gbox_CPF.Visible = false;
            // 
            // btn_CPF_Cancel
            // 
            this.btn_CPF_Cancel.AccessibleDescription = "Cancel";
            this.btn_CPF_Cancel.Location = new System.Drawing.Point(10, 175);
            this.btn_CPF_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.btn_CPF_Cancel.Name = "btn_CPF_Cancel";
            this.btn_CPF_Cancel.Size = new System.Drawing.Size(120, 40);
            this.btn_CPF_Cancel.TabIndex = 78;
            this.btn_CPF_Cancel.Text = "Cancel";
            this.btn_CPF_Cancel.UseVisualStyleBackColor = true;
            this.btn_CPF_Cancel.Click += new System.EventHandler(this.btn_CPF_Cancel_Click);
            // 
            // btn_CPF_Flush
            // 
            this.btn_CPF_Flush.AccessibleDescription = "Flush";
            this.btn_CPF_Flush.Location = new System.Drawing.Point(10, 125);
            this.btn_CPF_Flush.Margin = new System.Windows.Forms.Padding(5);
            this.btn_CPF_Flush.Name = "btn_CPF_Flush";
            this.btn_CPF_Flush.Size = new System.Drawing.Size(120, 40);
            this.btn_CPF_Flush.TabIndex = 75;
            this.btn_CPF_Flush.Text = "Flush";
            this.btn_CPF_Flush.UseVisualStyleBackColor = true;
            this.btn_CPF_Flush.Click += new System.EventHandler(this.btn_CPF_Flush_Click);
            // 
            // btn_CPF_Purge
            // 
            this.btn_CPF_Purge.AccessibleDescription = "Purge";
            this.btn_CPF_Purge.Location = new System.Drawing.Point(10, 75);
            this.btn_CPF_Purge.Margin = new System.Windows.Forms.Padding(5);
            this.btn_CPF_Purge.Name = "btn_CPF_Purge";
            this.btn_CPF_Purge.Size = new System.Drawing.Size(120, 40);
            this.btn_CPF_Purge.TabIndex = 74;
            this.btn_CPF_Purge.Text = "Purge";
            this.btn_CPF_Purge.UseVisualStyleBackColor = true;
            this.btn_CPF_Purge.Click += new System.EventHandler(this.btn_CPF_Purge_Click);
            // 
            // btn_CPF_Clean
            // 
            this.btn_CPF_Clean.AccessibleDescription = "Clean";
            this.btn_CPF_Clean.Location = new System.Drawing.Point(10, 25);
            this.btn_CPF_Clean.Margin = new System.Windows.Forms.Padding(5);
            this.btn_CPF_Clean.Name = "btn_CPF_Clean";
            this.btn_CPF_Clean.Size = new System.Drawing.Size(120, 40);
            this.btn_CPF_Clean.TabIndex = 73;
            this.btn_CPF_Clean.Text = "Clean";
            this.btn_CPF_Clean.UseVisualStyleBackColor = true;
            this.btn_CPF_Clean.Click += new System.EventHandler(this.btn_CPFClean_Click);
            // 
            // btn_CPF
            // 
            this.btn_CPF.AccessibleDescription = "Clean Purge";
            this.btn_CPF.Location = new System.Drawing.Point(508, 4);
            this.btn_CPF.Name = "btn_CPF";
            this.btn_CPF.Size = new System.Drawing.Size(120, 40);
            this.btn_CPF.TabIndex = 74;
            this.btn_CPF.Text = "Clean Purge";
            this.btn_CPF.UseVisualStyleBackColor = true;
            this.btn_CPF.Click += new System.EventHandler(this.btn_CPF_Click);
            // 
            // gbox_VolumeOfst
            // 
            this.gbox_VolumeOfst.AutoSize = true;
            this.gbox_VolumeOfst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_VolumeOfst.Controls.Add(this.btn_VolOfstModeManual);
            this.gbox_VolumeOfst.Controls.Add(this.btn_VolOfstModeAuto);
            this.gbox_VolumeOfst.Controls.Add(this.lbl_WaitTimer);
            this.gbox_VolumeOfst.Controls.Add(this.btn_VolOfstReset);
            this.gbox_VolumeOfst.Controls.Add(this.btn_VolOfstClose);
            this.gbox_VolumeOfst.Controls.Add(this.btn_VolOfstModeNone);
            this.gbox_VolumeOfst.Location = new System.Drawing.Point(821, 407);
            this.gbox_VolumeOfst.Name = "gbox_VolumeOfst";
            this.gbox_VolumeOfst.Padding = new System.Windows.Forms.Padding(5);
            this.gbox_VolumeOfst.Size = new System.Drawing.Size(400, 244);
            this.gbox_VolumeOfst.TabIndex = 75;
            this.gbox_VolumeOfst.TabStop = false;
            this.gbox_VolumeOfst.Text = "Volume Offset";
            this.gbox_VolumeOfst.Visible = false;
            // 
            // btn_VolOfstModeManual
            // 
            this.btn_VolOfstModeManual.AccessibleDescription = "Manual";
            this.btn_VolOfstModeManual.Location = new System.Drawing.Point(270, 25);
            this.btn_VolOfstModeManual.Margin = new System.Windows.Forms.Padding(5);
            this.btn_VolOfstModeManual.Name = "btn_VolOfstModeManual";
            this.btn_VolOfstModeManual.Size = new System.Drawing.Size(120, 40);
            this.btn_VolOfstModeManual.TabIndex = 85;
            this.btn_VolOfstModeManual.Text = "Manual";
            this.btn_VolOfstModeManual.UseVisualStyleBackColor = true;
            this.btn_VolOfstModeManual.Click += new System.EventHandler(this.btn_VolOfstModeManual_Click);
            // 
            // btn_VolOfstModeAuto
            // 
            this.btn_VolOfstModeAuto.AccessibleDescription = "Auto";
            this.btn_VolOfstModeAuto.Location = new System.Drawing.Point(140, 25);
            this.btn_VolOfstModeAuto.Margin = new System.Windows.Forms.Padding(5);
            this.btn_VolOfstModeAuto.Name = "btn_VolOfstModeAuto";
            this.btn_VolOfstModeAuto.Size = new System.Drawing.Size(120, 40);
            this.btn_VolOfstModeAuto.TabIndex = 84;
            this.btn_VolOfstModeAuto.Text = "Auto";
            this.btn_VolOfstModeAuto.UseVisualStyleBackColor = true;
            this.btn_VolOfstModeAuto.Click += new System.EventHandler(this.btn_VolOfstModeAuto_Click);
            // 
            // lbl_WaitTimer
            // 
            this.lbl_WaitTimer.AccessibleDescription = "";
            this.lbl_WaitTimer.BackColor = System.Drawing.Color.White;
            this.lbl_WaitTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WaitTimer.Location = new System.Drawing.Point(10, 125);
            this.lbl_WaitTimer.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_WaitTimer.Name = "lbl_WaitTimer";
            this.lbl_WaitTimer.Size = new System.Drawing.Size(120, 40);
            this.lbl_WaitTimer.TabIndex = 81;
            this.lbl_WaitTimer.Text = "Wait Timer";
            this.lbl_WaitTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_WaitTimer.Click += new System.EventHandler(this.lbl_WaitTimer_Click);
            // 
            // btn_VolOfstReset
            // 
            this.btn_VolOfstReset.AccessibleDescription = "Reset";
            this.btn_VolOfstReset.Location = new System.Drawing.Point(10, 75);
            this.btn_VolOfstReset.Margin = new System.Windows.Forms.Padding(5);
            this.btn_VolOfstReset.Name = "btn_VolOfstReset";
            this.btn_VolOfstReset.Size = new System.Drawing.Size(120, 40);
            this.btn_VolOfstReset.TabIndex = 80;
            this.btn_VolOfstReset.Text = "Reset";
            this.btn_VolOfstReset.UseVisualStyleBackColor = true;
            this.btn_VolOfstReset.Click += new System.EventHandler(this.btn_VolOfstReset_Click);
            // 
            // btn_VolOfstClose
            // 
            this.btn_VolOfstClose.AccessibleDescription = "Close";
            this.btn_VolOfstClose.Location = new System.Drawing.Point(10, 175);
            this.btn_VolOfstClose.Margin = new System.Windows.Forms.Padding(5);
            this.btn_VolOfstClose.Name = "btn_VolOfstClose";
            this.btn_VolOfstClose.Size = new System.Drawing.Size(120, 40);
            this.btn_VolOfstClose.TabIndex = 79;
            this.btn_VolOfstClose.Text = "Close";
            this.btn_VolOfstClose.UseVisualStyleBackColor = true;
            this.btn_VolOfstClose.Click += new System.EventHandler(this.btn_VolOfstClose_Click);
            // 
            // btn_VolOfstModeNone
            // 
            this.btn_VolOfstModeNone.AccessibleDescription = "None";
            this.btn_VolOfstModeNone.Location = new System.Drawing.Point(10, 25);
            this.btn_VolOfstModeNone.Margin = new System.Windows.Forms.Padding(5);
            this.btn_VolOfstModeNone.Name = "btn_VolOfstModeNone";
            this.btn_VolOfstModeNone.Size = new System.Drawing.Size(120, 40);
            this.btn_VolOfstModeNone.TabIndex = 74;
            this.btn_VolOfstModeNone.Text = "None";
            this.btn_VolOfstModeNone.UseVisualStyleBackColor = true;
            this.btn_VolOfstModeNone.Click += new System.EventHandler(this.btn_VolOfstMode_Click);
            // 
            // btn_VolumeOffset
            // 
            this.btn_VolumeOffset.AccessibleDescription = "Volume Offset";
            this.btn_VolumeOffset.Location = new System.Drawing.Point(0, 46);
            this.btn_VolumeOffset.Name = "btn_VolumeOffset";
            this.btn_VolumeOffset.Size = new System.Drawing.Size(120, 40);
            this.btn_VolumeOffset.TabIndex = 76;
            this.btn_VolumeOffset.Text = "Volume Offset (Manual)";
            this.btn_VolumeOffset.UseVisualStyleBackColor = true;
            this.btn_VolumeOffset.Click += new System.EventHandler(this.btn_VolumeOffset_Click);
            // 
            // btn_StartIdle
            // 
            this.btn_StartIdle.AccessibleDescription = "Start Idle";
            this.btn_StartIdle.Location = new System.Drawing.Point(508, 50);
            this.btn_StartIdle.Name = "btn_StartIdle";
            this.btn_StartIdle.Size = new System.Drawing.Size(120, 40);
            this.btn_StartIdle.TabIndex = 77;
            this.btn_StartIdle.Text = "Start Idle";
            this.btn_StartIdle.UseVisualStyleBackColor = true;
            this.btn_StartIdle.Click += new System.EventHandler(this.btn_StartIdle_Click);
            // 
            // btn_UploadData
            // 
            this.btn_UploadData.AccessibleDescription = "Upload Data";
            this.btn_UploadData.Location = new System.Drawing.Point(0, 92);
            this.btn_UploadData.Name = "btn_UploadData";
            this.btn_UploadData.Size = new System.Drawing.Size(120, 40);
            this.btn_UploadData.TabIndex = 78;
            this.btn_UploadData.Text = "Upload Data";
            this.btn_UploadData.UseVisualStyleBackColor = true;
            this.btn_UploadData.Click += new System.EventHandler(this.btn_UploadData_Click);
            // 
            // pnl_LextarFrontTest
            // 
            this.pnl_LextarFrontTest.AutoSize = true;
            this.pnl_LextarFrontTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_LextarFrontTest.Controls.Add(this.lbl_WaitData);
            this.pnl_LextarFrontTest.Controls.Add(this.lbl_Connection);
            this.pnl_LextarFrontTest.Controls.Add(this.btn_VolumeOffset);
            this.pnl_LextarFrontTest.Controls.Add(this.btn_UploadData);
            this.pnl_LextarFrontTest.Location = new System.Drawing.Point(950, 13);
            this.pnl_LextarFrontTest.Name = "pnl_LextarFrontTest";
            this.pnl_LextarFrontTest.Size = new System.Drawing.Size(123, 181);
            this.pnl_LextarFrontTest.TabIndex = 79;
            // 
            // lbl_WaitData
            // 
            this.lbl_WaitData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WaitData.Location = new System.Drawing.Point(0, 138);
            this.lbl_WaitData.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_WaitData.Name = "lbl_WaitData";
            this.lbl_WaitData.Size = new System.Drawing.Size(120, 40);
            this.lbl_WaitData.TabIndex = 80;
            this.lbl_WaitData.Text = "Waiting Data";
            this.lbl_WaitData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Connection
            // 
            this.lbl_Connection.AccessibleDescription = "Connection";
            this.lbl_Connection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Connection.Location = new System.Drawing.Point(0, 0);
            this.lbl_Connection.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Connection.Name = "lbl_Connection";
            this.lbl_Connection.Size = new System.Drawing.Size(120, 40);
            this.lbl_Connection.TabIndex = 79;
            this.lbl_Connection.Text = "Connection";
            this.lbl_Connection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_WeightAdjust
            // 
            this.btn_WeightAdjust.AccessibleDescription = "Adjust";
            this.btn_WeightAdjust.Location = new System.Drawing.Point(8, 23);
            this.btn_WeightAdjust.Name = "btn_WeightAdjust";
            this.btn_WeightAdjust.Size = new System.Drawing.Size(120, 40);
            this.btn_WeightAdjust.TabIndex = 81;
            this.btn_WeightAdjust.Text = "Adjust";
            this.btn_WeightAdjust.UseVisualStyleBackColor = true;
            this.btn_WeightAdjust.Click += new System.EventHandler(this.btn_WeightAdjust_Click);
            // 
            // gbox_Weight
            // 
            this.gbox_Weight.AutoSize = true;
            this.gbox_Weight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Weight.Controls.Add(this.btn_WeightCancel);
            this.gbox_Weight.Controls.Add(this.btn_WeightAdjust);
            this.gbox_Weight.Controls.Add(this.btn_WeightCalibrate);
            this.gbox_Weight.Controls.Add(this.btn_WeightMeasure);
            this.gbox_Weight.Location = new System.Drawing.Point(950, 200);
            this.gbox_Weight.Name = "gbox_Weight";
            this.gbox_Weight.Padding = new System.Windows.Forms.Padding(5);
            this.gbox_Weight.Size = new System.Drawing.Size(136, 228);
            this.gbox_Weight.TabIndex = 82;
            this.gbox_Weight.TabStop = false;
            this.gbox_Weight.Text = "Weight";
            this.gbox_Weight.Visible = false;
            // 
            // btn_WeightCancel
            // 
            this.btn_WeightCancel.AccessibleDescription = "Cancel";
            this.btn_WeightCancel.Location = new System.Drawing.Point(8, 161);
            this.btn_WeightCancel.Name = "btn_WeightCancel";
            this.btn_WeightCancel.Size = new System.Drawing.Size(120, 40);
            this.btn_WeightCancel.TabIndex = 82;
            this.btn_WeightCancel.Text = "Cancel";
            this.btn_WeightCancel.UseVisualStyleBackColor = true;
            this.btn_WeightCancel.Click += new System.EventHandler(this.btn_WeightCancel_Click);
            // 
            // btn_Weight
            // 
            this.btn_Weight.AccessibleDescription = "Weight";
            this.btn_Weight.Location = new System.Drawing.Point(508, 96);
            this.btn_Weight.Name = "btn_Weight";
            this.btn_Weight.Size = new System.Drawing.Size(120, 40);
            this.btn_Weight.TabIndex = 83;
            this.btn_Weight.Text = "Weight";
            this.btn_Weight.UseVisualStyleBackColor = true;
            this.btn_Weight.Click += new System.EventHandler(this.btn_Weight_Click);
            // 
            // btn_PurgeStage
            // 
            this.btn_PurgeStage.AccessibleDescription = "Purge Stage";
            this.btn_PurgeStage.Location = new System.Drawing.Point(382, 96);
            this.btn_PurgeStage.Name = "btn_PurgeStage";
            this.btn_PurgeStage.Size = new System.Drawing.Size(120, 40);
            this.btn_PurgeStage.TabIndex = 85;
            this.btn_PurgeStage.Text = "Purge Stage";
            this.btn_PurgeStage.UseVisualStyleBackColor = true;
            this.btn_PurgeStage.Click += new System.EventHandler(this.btn_PurgeStage_Click);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "";
            this.button1.Location = new System.Drawing.Point(508, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.TabIndex = 86;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // lbl_SensMat2Low
            // 
            this.lbl_SensMat2Low.AccessibleDescription = "Low 2";
            this.lbl_SensMat2Low.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SensMat2Low.Location = new System.Drawing.Point(317, 188);
            this.lbl_SensMat2Low.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_SensMat2Low.Name = "lbl_SensMat2Low";
            this.lbl_SensMat2Low.Size = new System.Drawing.Size(59, 19);
            this.lbl_SensMat2Low.TabIndex = 88;
            this.lbl_SensMat2Low.Text = "Low 2";
            this.lbl_SensMat2Low.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_SensMat1Low
            // 
            this.lbl_SensMat1Low.AccessibleDescription = "Low 1";
            this.lbl_SensMat1Low.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SensMat1Low.Location = new System.Drawing.Point(256, 188);
            this.lbl_SensMat1Low.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_SensMat1Low.Name = "lbl_SensMat1Low";
            this.lbl_SensMat1Low.Size = new System.Drawing.Size(59, 19);
            this.lbl_SensMat1Low.TabIndex = 87;
            this.lbl_SensMat1Low.Text = "Low 1";
            this.lbl_SensMat1Low.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmr_5s
            // 
            this.tmr_5s.Enabled = true;
            this.tmr_5s.Interval = 5000;
            this.tmr_5s.Tick += new System.EventHandler(this.tmr_5s_Tick);
            // 
            // lbl_MaterialExpiryDT
            // 
            this.lbl_MaterialExpiryDT.AccessibleDescription = "";
            this.lbl_MaterialExpiryDT.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_MaterialExpiryDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MaterialExpiryDT.Location = new System.Drawing.Point(130, 188);
            this.lbl_MaterialExpiryDT.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MaterialExpiryDT.Name = "lbl_MaterialExpiryDT";
            this.lbl_MaterialExpiryDT.Size = new System.Drawing.Size(120, 40);
            this.lbl_MaterialExpiryDT.TabIndex = 89;
            this.lbl_MaterialExpiryDT.Text = "Material Expiry 2018/03/22 24:00";
            this.lbl_MaterialExpiryDT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MaterialExpiryDT.Click += new System.EventHandler(this.lbl_MaterialExpiryDT_Click);
            // 
            // dtp_ExpiryDate
            // 
            this.dtp_ExpiryDate.CustomFormat = "";
            this.dtp_ExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ExpiryDate.Location = new System.Drawing.Point(8, 21);
            this.dtp_ExpiryDate.Name = "dtp_ExpiryDate";
            this.dtp_ExpiryDate.Size = new System.Drawing.Size(120, 26);
            this.dtp_ExpiryDate.TabIndex = 90;
            this.dtp_ExpiryDate.ValueChanged += new System.EventHandler(this.dtp_ExpiryDate_ValueChanged);
            // 
            // dtp_ExpiryTime
            // 
            this.dtp_ExpiryTime.CustomFormat = "hh:mm";
            this.dtp_ExpiryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_ExpiryTime.Location = new System.Drawing.Point(8, 49);
            this.dtp_ExpiryTime.Name = "dtp_ExpiryTime";
            this.dtp_ExpiryTime.ShowUpDown = true;
            this.dtp_ExpiryTime.Size = new System.Drawing.Size(120, 26);
            this.dtp_ExpiryTime.TabIndex = 91;
            this.dtp_ExpiryTime.ValueChanged += new System.EventHandler(this.dtp_ExpiryTime_ValueChanged);
            // 
            // gbox_DateTime
            // 
            this.gbox_DateTime.AutoSize = true;
            this.gbox_DateTime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_DateTime.Controls.Add(this.btn_dtpCancel);
            this.gbox_DateTime.Controls.Add(this.btn_dtpOK);
            this.gbox_DateTime.Controls.Add(this.dtp_ExpiryTime);
            this.gbox_DateTime.Controls.Add(this.dtp_ExpiryDate);
            this.gbox_DateTime.Controls.Add(this.dtp_ScanEntry);
            this.gbox_DateTime.Location = new System.Drawing.Point(1079, 13);
            this.gbox_DateTime.Name = "gbox_DateTime";
            this.gbox_DateTime.Size = new System.Drawing.Size(134, 188);
            this.gbox_DateTime.TabIndex = 91;
            this.gbox_DateTime.TabStop = false;
            this.gbox_DateTime.Text = "Date Time";
            this.gbox_DateTime.Visible = false;
            // 
            // btn_dtpCancel
            // 
            this.btn_dtpCancel.AccessibleDescription = "Cancel";
            this.btn_dtpCancel.Location = new System.Drawing.Point(8, 123);
            this.btn_dtpCancel.Name = "btn_dtpCancel";
            this.btn_dtpCancel.Size = new System.Drawing.Size(120, 40);
            this.btn_dtpCancel.TabIndex = 94;
            this.btn_dtpCancel.Text = "Cancel";
            this.btn_dtpCancel.UseVisualStyleBackColor = true;
            this.btn_dtpCancel.Click += new System.EventHandler(this.btn_dtpCancel_Click);
            // 
            // btn_dtpOK
            // 
            this.btn_dtpOK.AccessibleDescription = "OK";
            this.btn_dtpOK.Location = new System.Drawing.Point(8, 77);
            this.btn_dtpOK.Name = "btn_dtpOK";
            this.btn_dtpOK.Size = new System.Drawing.Size(120, 40);
            this.btn_dtpOK.TabIndex = 92;
            this.btn_dtpOK.Text = "OK";
            this.btn_dtpOK.UseVisualStyleBackColor = true;
            this.btn_dtpOK.Click += new System.EventHandler(this.btn_dtpOK_Click);
            // 
            // dtp_ScanEntry
            // 
            this.dtp_ScanEntry.Location = new System.Drawing.Point(19, 84);
            this.dtp_ScanEntry.Name = "dtp_ScanEntry";
            this.dtp_ScanEntry.Size = new System.Drawing.Size(100, 26);
            this.dtp_ScanEntry.TabIndex = 93;
            this.dtp_ScanEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtp_ScanEntry_KeyDown);
            this.dtp_ScanEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtp_ScanEntry_KeyPress);
            this.dtp_ScanEntry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtp_ScanEntry_KeyUp);
            this.dtp_ScanEntry.Layout += new System.Windows.Forms.LayoutEventHandler(this.dtp_ScanEntry_Layout);
            this.dtp_ScanEntry.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtp_ScanEntry_PreviewKeyDown);
            // 
            // btn_View
            // 
            this.btn_View.AccessibleDescription = "View";
            this.btn_View.Location = new System.Drawing.Point(382, 50);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(120, 40);
            this.btn_View.TabIndex = 92;
            this.btn_View.Text = "View";
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btnMaterialChange
            // 
            this.btnMaterialChange.AccessibleDescription = "";
            this.btnMaterialChange.Location = new System.Drawing.Point(4, 188);
            this.btnMaterialChange.Name = "btnMaterialChange";
            this.btnMaterialChange.Size = new System.Drawing.Size(120, 40);
            this.btnMaterialChange.TabIndex = 94;
            this.btnMaterialChange.Text = "Material Change";
            this.btnMaterialChange.UseVisualStyleBackColor = true;
            this.btnMaterialChange.Visible = false;
            this.btnMaterialChange.Click += new System.EventHandler(this.btnMaterialChange_Click);
            // 
            // frm_DispCore_DispTools
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1284, 571);
            this.ControlBox = false;
            this.Controls.Add(this.btnMaterialChange);
            this.Controls.Add(this.gbox_VolumeOfst);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.gbox_DateTime);
            this.Controls.Add(this.lbl_SensMat2Low);
            this.Controls.Add(this.lbl_SensMat1Low);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_PurgeStage);
            this.Controls.Add(this.btn_Weight);
            this.Controls.Add(this.gbox_Weight);
            this.Controls.Add(this.pnl_LextarFrontTest);
            this.Controls.Add(this.btn_StartIdle);
            this.Controls.Add(this.btn_CPF);
            this.Controls.Add(this.gbox_CPF);
            this.Controls.Add(this.gbox_PumpAction);
            this.Controls.Add(this.btn_PumpAction);
            this.Controls.Add(this.lbl_MaterialTimer);
            this.Controls.Add(this.btn_Origin);
            this.Controls.Add(this.lbl_OrignOfst);
            this.Controls.Add(this.btn_DrawOfstAdjust);
            this.Controls.Add(this.btn_PumpAdjust);
            this.Controls.Add(this.btn_DispWeight2);
            this.Controls.Add(this.btn_ForceSingle);
            this.Controls.Add(this.btn_DispWeight);
            this.Controls.Add(this.pnl_DispTool_PumpTool);
            this.Controls.Add(this.btn_GotoMMaint);
            this.Controls.Add(this.btn_GotoPMaint);
            this.Controls.Add(this.btn_TeachNeedle);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_PurgeNeedle);
            this.Controls.Add(this.btn_CleanNeedle);
            this.Controls.Add(this.lbl_MaterialExpiryDT);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_DispCore_DispTools";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "frm_DispTools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_DispTools_FormClosing);
            this.Load += new System.EventHandler(this.frmDispTools_Load);
            this.Shown += new System.EventHandler(this.frm_DispCore_DispTools_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDispTools_KeyDown);
            this.gbox_PumpAction.ResumeLayout(false);
            this.gbox_CPF.ResumeLayout(false);
            this.gbox_VolumeOfst.ResumeLayout(false);
            this.pnl_LextarFrontTest.ResumeLayout(false);
            this.gbox_Weight.ResumeLayout(false);
            this.gbox_DateTime.ResumeLayout(false);
            this.gbox_DateTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CleanNeedle;
        private System.Windows.Forms.Button btn_PurgeNeedle;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_TeachNeedle;
        private System.Windows.Forms.Button btn_GotoPMaint;
        private System.Windows.Forms.Button btn_WeightMeasure;
        //private Microsoft.VisualBasic.PowerPacks.Printing.PrintForm printForm1;
        private System.Windows.Forms.Button btn_GotoMMaint;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Button btn_DispWeight;
        private System.Windows.Forms.Panel pnl_DispTool_PumpTool;
        private System.Windows.Forms.Label lbl_MaterialTimer;
        private System.Windows.Forms.Button btn_ForceSingle;
        private System.Windows.Forms.Button btn_DispWeight2;
        private System.Windows.Forms.Button btn_PumpAdjust;
        private System.Windows.Forms.Button btn_DrawOfstAdjust;
        private System.Windows.Forms.Label lbl_OrignOfst;
        private System.Windows.Forms.Button btn_Origin;
        private System.Windows.Forms.Button btn_WeightCalibrate;
        private System.Windows.Forms.Button btn_PumpAction;
        private System.Windows.Forms.GroupBox gbox_PumpAction;
        private System.Windows.Forms.Button btn_PumpAction5;
        private System.Windows.Forms.Button btn_PumpAction4;
        private System.Windows.Forms.Button btn_PumpAction3;
        private System.Windows.Forms.Button btn_PumpAction2;
        private System.Windows.Forms.Button btn_PumpAction1;
        private System.Windows.Forms.Button btn_PumpActionCancel;
        private System.Windows.Forms.GroupBox gbox_CPF;
        private System.Windows.Forms.Button btn_CPF_Cancel;
        private System.Windows.Forms.Button btn_CPF_Flush;
        private System.Windows.Forms.Button btn_CPF_Purge;
        private System.Windows.Forms.Button btn_CPF_Clean;
        private System.Windows.Forms.Button btn_CPF;
        private System.Windows.Forms.GroupBox gbox_VolumeOfst;
        private System.Windows.Forms.Button btn_VolOfstModeNone;
        private System.Windows.Forms.Button btn_VolumeOffset;
        private System.Windows.Forms.Button btn_VolOfstClose;
        private System.Windows.Forms.Button btn_VolOfstReset;
        private System.Windows.Forms.Button btn_StartIdle;
        private System.Windows.Forms.Button btn_UploadData;
        private System.Windows.Forms.Panel pnl_LextarFrontTest;
        private System.Windows.Forms.Label lbl_Connection;
        private System.Windows.Forms.Label lbl_WaitData;
        private System.Windows.Forms.Label lbl_WaitTimer;
        private System.Windows.Forms.Button btn_WeightAdjust;
        private System.Windows.Forms.GroupBox gbox_Weight;
        private System.Windows.Forms.Button btn_Weight;
        private System.Windows.Forms.Button btn_WeightCancel;
        private System.Windows.Forms.Button btn_PurgeStage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_SensMat2Low;
        private System.Windows.Forms.Label lbl_SensMat1Low;
        private System.Windows.Forms.Timer tmr_5s;
        private System.Windows.Forms.Label lbl_MaterialExpiryDT;
        private System.Windows.Forms.DateTimePicker dtp_ExpiryDate;
        private System.Windows.Forms.DateTimePicker dtp_ExpiryTime;
        private System.Windows.Forms.GroupBox gbox_DateTime;
        private System.Windows.Forms.Button btn_dtpOK;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.TextBox dtp_ScanEntry;
        private System.Windows.Forms.Button btn_dtpCancel;
        private System.Windows.Forms.Button btn_VolOfstModeManual;
        private System.Windows.Forms.Button btn_VolOfstModeAuto;
        private System.Windows.Forms.Button btnMaterialChange;
    }
}