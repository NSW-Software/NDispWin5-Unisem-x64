namespace NDispWin
{
    partial class frm_DispCore_DispSetup
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
            this.btn_HeadOfstTouchDotSet = new System.Windows.Forms.Button();
            this.btn_CalLaserOfst = new System.Windows.Forms.Button();
            this.btn_CalLaser = new System.Windows.Forms.Button();
            this.btn_CalHeadOfst = new System.Windows.Forms.Button();
            this.btn_CalHeadOfstBCam = new System.Windows.Forms.Button();
            this.btn_CalZSensor = new System.Windows.Forms.Button();
            this.btn_Jog = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTempSensorOfstManual = new System.Windows.Forms.CheckBox();
            this.btnCalTempSensorOfstPoint = new System.Windows.Forms.Button();
            this.cbox_BypassTeachNeedleCheck = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Custom = new System.Windows.Forms.Label();
            this.lbl_Options = new System.Windows.Forms.Label();
            this.lbl_Weight = new System.Windows.Forms.Label();
            this.lbl_Maint = new System.Windows.Forms.Label();
            this.lbl_CleanPurge = new System.Windows.Forms.Label();
            this.lbl_DispControl = new System.Windows.Forms.Label();
            this.lbl_TeachNeedle = new System.Windows.Forms.Label();
            this.lbl_HeadCalSetting = new System.Windows.Forms.Label();
            this.lbl_HeadCal = new System.Windows.Forms.Label();
            this.tmr_Reticle = new System.Windows.Forms.Timer(this.components);
            this.tmr1s = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_HeadOfstTouchDotSet
            // 
            this.btn_HeadOfstTouchDotSet.AccessibleDescription = "Head Offset Touch Dot";
            this.btn_HeadOfstTouchDotSet.Location = new System.Drawing.Point(229, 32);
            this.btn_HeadOfstTouchDotSet.Margin = new System.Windows.Forms.Padding(2);
            this.btn_HeadOfstTouchDotSet.Name = "btn_HeadOfstTouchDotSet";
            this.btn_HeadOfstTouchDotSet.Size = new System.Drawing.Size(107, 36);
            this.btn_HeadOfstTouchDotSet.TabIndex = 182;
            this.btn_HeadOfstTouchDotSet.Text = "Head Offset Touch Dot";
            this.btn_HeadOfstTouchDotSet.UseVisualStyleBackColor = true;
            this.btn_HeadOfstTouchDotSet.Click += new System.EventHandler(this.btn_HeadOfstTouchDotSet_Click);
            // 
            // btn_CalLaserOfst
            // 
            this.btn_CalLaserOfst.AccessibleDescription = "Laser Offset";
            this.btn_CalLaserOfst.Location = new System.Drawing.Point(451, 103);
            this.btn_CalLaserOfst.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CalLaserOfst.Name = "btn_CalLaserOfst";
            this.btn_CalLaserOfst.Size = new System.Drawing.Size(107, 36);
            this.btn_CalLaserOfst.TabIndex = 5;
            this.btn_CalLaserOfst.Text = "Laser Offset";
            this.btn_CalLaserOfst.UseVisualStyleBackColor = true;
            this.btn_CalLaserOfst.Click += new System.EventHandler(this.btn_CalLaserOfst_Click);
            // 
            // btn_CalLaser
            // 
            this.btn_CalLaser.AccessibleDescription = "Laser";
            this.btn_CalLaser.Location = new System.Drawing.Point(340, 103);
            this.btn_CalLaser.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CalLaser.Name = "btn_CalLaser";
            this.btn_CalLaser.Size = new System.Drawing.Size(107, 36);
            this.btn_CalLaser.TabIndex = 4;
            this.btn_CalLaser.Text = "Laser";
            this.btn_CalLaser.UseVisualStyleBackColor = true;
            this.btn_CalLaser.Click += new System.EventHandler(this.btn_CalLaser_Click);
            // 
            // btn_CalHeadOfst
            // 
            this.btn_CalHeadOfst.AccessibleDescription = "Head Offset";
            this.btn_CalHeadOfst.Location = new System.Drawing.Point(7, 32);
            this.btn_CalHeadOfst.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CalHeadOfst.Name = "btn_CalHeadOfst";
            this.btn_CalHeadOfst.Size = new System.Drawing.Size(107, 36);
            this.btn_CalHeadOfst.TabIndex = 0;
            this.btn_CalHeadOfst.Text = "Head Offset";
            this.btn_CalHeadOfst.UseVisualStyleBackColor = true;
            this.btn_CalHeadOfst.Click += new System.EventHandler(this.btn_CalHeadOfst_Click);
            // 
            // btn_CalHeadOfstBCam
            // 
            this.btn_CalHeadOfstBCam.AccessibleDescription = "Head Offset BCamera";
            this.btn_CalHeadOfstBCam.Location = new System.Drawing.Point(118, 32);
            this.btn_CalHeadOfstBCam.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CalHeadOfstBCam.Name = "btn_CalHeadOfstBCam";
            this.btn_CalHeadOfstBCam.Size = new System.Drawing.Size(107, 36);
            this.btn_CalHeadOfstBCam.TabIndex = 3;
            this.btn_CalHeadOfstBCam.Text = "Head Offset BCamera";
            this.btn_CalHeadOfstBCam.UseVisualStyleBackColor = true;
            this.btn_CalHeadOfstBCam.Click += new System.EventHandler(this.btn_CalHeadOfstBCamera_Click);
            // 
            // btn_CalZSensor
            // 
            this.btn_CalZSensor.AccessibleDescription = "Z Sensor";
            this.btn_CalZSensor.Location = new System.Drawing.Point(451, 32);
            this.btn_CalZSensor.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CalZSensor.Name = "btn_CalZSensor";
            this.btn_CalZSensor.Size = new System.Drawing.Size(107, 36);
            this.btn_CalZSensor.TabIndex = 2;
            this.btn_CalZSensor.Text = "Z Sensor";
            this.btn_CalZSensor.UseVisualStyleBackColor = true;
            this.btn_CalZSensor.Click += new System.EventHandler(this.btn_CalZSensor_Click);
            // 
            // btn_Jog
            // 
            this.btn_Jog.AccessibleDescription = "Jog";
            this.btn_Jog.Location = new System.Drawing.Point(578, 650);
            this.btn_Jog.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Jog.Name = "btn_Jog";
            this.btn_Jog.Size = new System.Drawing.Size(70, 36);
            this.btn_Jog.TabIndex = 143;
            this.btn_Jog.Text = "Jog";
            this.btn_Jog.UseVisualStyleBackColor = true;
            this.btn_Jog.Click += new System.EventHandler(this.btn_Jog_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(726, 650);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(70, 36);
            this.btn_Close.TabIndex = 140;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.Location = new System.Drawing.Point(652, 650);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(70, 36);
            this.btn_Save.TabIndex = 139;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbTempSensorOfstManual);
            this.panel1.Controls.Add(this.btnCalTempSensorOfstPoint);
            this.panel1.Controls.Add(this.cbox_BypassTeachNeedleCheck);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.btn_HeadOfstTouchDotSet);
            this.panel1.Controls.Add(this.btn_CalLaserOfst);
            this.panel1.Controls.Add(this.btn_CalLaser);
            this.panel1.Controls.Add(this.btn_CalHeadOfst);
            this.panel1.Controls.Add(this.btn_CalHeadOfstBCam);
            this.panel1.Controls.Add(this.btn_CalZSensor);
            this.panel1.Location = new System.Drawing.Point(166, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(630, 640);
            this.panel1.TabIndex = 173;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cbTempSensorOfstManual
            // 
            this.cbTempSensorOfstManual.AutoSize = true;
            this.cbTempSensorOfstManual.Location = new System.Drawing.Point(118, 144);
            this.cbTempSensorOfstManual.Name = "cbTempSensorOfstManual";
            this.cbTempSensorOfstManual.Size = new System.Drawing.Size(63, 18);
            this.cbTempSensorOfstManual.TabIndex = 187;
            this.cbTempSensorOfstManual.Text = "Manual";
            this.cbTempSensorOfstManual.UseVisualStyleBackColor = true;
            // 
            // btnCalTempSensorOfstPoint
            // 
            this.btnCalTempSensorOfstPoint.AccessibleDescription = "TempSensor Offset";
            this.btnCalTempSensorOfstPoint.Location = new System.Drawing.Point(118, 103);
            this.btnCalTempSensorOfstPoint.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalTempSensorOfstPoint.Name = "btnCalTempSensorOfstPoint";
            this.btnCalTempSensorOfstPoint.Size = new System.Drawing.Size(107, 36);
            this.btnCalTempSensorOfstPoint.TabIndex = 185;
            this.btnCalTempSensorOfstPoint.Text = "TempSensor Offset";
            this.btnCalTempSensorOfstPoint.UseVisualStyleBackColor = true;
            this.btnCalTempSensorOfstPoint.Click += new System.EventHandler(this.btnCalTempSensorOfst_Click);
            // 
            // cbox_BypassTeachNeedleCheck
            // 
            this.cbox_BypassTeachNeedleCheck.AccessibleDescription = "Bypass Teach Needle Check";
            this.cbox_BypassTeachNeedleCheck.AutoSize = true;
            this.cbox_BypassTeachNeedleCheck.Location = new System.Drawing.Point(8, 221);
            this.cbox_BypassTeachNeedleCheck.Name = "cbox_BypassTeachNeedleCheck";
            this.cbox_BypassTeachNeedleCheck.Size = new System.Drawing.Size(179, 18);
            this.cbox_BypassTeachNeedleCheck.TabIndex = 184;
            this.cbox_BypassTeachNeedleCheck.Text = "Bypass Teach Needle Check";
            this.cbox_BypassTeachNeedleCheck.UseVisualStyleBackColor = true;
            this.cbox_BypassTeachNeedleCheck.CheckedChanged += new System.EventHandler(this.cbox_BypassTeachNeedleCheck_CheckedChanged);
            this.cbox_BypassTeachNeedleCheck.Click += new System.EventHandler(this.cbox_BypassTeachNeedleCheck_Click);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label26.Dock = System.Windows.Forms.DockStyle.Top;
            this.label26.Location = new System.Drawing.Point(5, 5);
            this.label26.Margin = new System.Windows.Forms.Padding(2);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label26.Size = new System.Drawing.Size(618, 23);
            this.label26.TabIndex = 183;
            this.label26.Text = "Head Calibration";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbl_Custom);
            this.panel2.Controls.Add(this.lbl_Options);
            this.panel2.Controls.Add(this.lbl_Weight);
            this.panel2.Controls.Add(this.lbl_Maint);
            this.panel2.Controls.Add(this.lbl_CleanPurge);
            this.panel2.Controls.Add(this.lbl_DispControl);
            this.panel2.Controls.Add(this.lbl_TeachNeedle);
            this.panel2.Controls.Add(this.lbl_HeadCalSetting);
            this.panel2.Controls.Add(this.lbl_HeadCal);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(150, 640);
            this.panel2.TabIndex = 182;
            // 
            // lbl_Custom
            // 
            this.lbl_Custom.AccessibleDescription = "Custom";
            this.lbl_Custom.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Custom.Location = new System.Drawing.Point(5, 293);
            this.lbl_Custom.Name = "lbl_Custom";
            this.lbl_Custom.Size = new System.Drawing.Size(138, 36);
            this.lbl_Custom.TabIndex = 184;
            this.lbl_Custom.Text = "Custom";
            this.lbl_Custom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Custom.Click += new System.EventHandler(this.lbl_VolumeOfst_Click);
            // 
            // lbl_Options
            // 
            this.lbl_Options.AccessibleDescription = "Options";
            this.lbl_Options.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Options.Location = new System.Drawing.Point(5, 257);
            this.lbl_Options.Name = "lbl_Options";
            this.lbl_Options.Size = new System.Drawing.Size(138, 36);
            this.lbl_Options.TabIndex = 192;
            this.lbl_Options.Text = "Options";
            this.lbl_Options.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Options.Click += new System.EventHandler(this.lbl_Options_Click);
            // 
            // lbl_Weight
            // 
            this.lbl_Weight.AccessibleDescription = "Weight";
            this.lbl_Weight.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Weight.Location = new System.Drawing.Point(5, 221);
            this.lbl_Weight.Name = "lbl_Weight";
            this.lbl_Weight.Size = new System.Drawing.Size(138, 36);
            this.lbl_Weight.TabIndex = 191;
            this.lbl_Weight.Text = "Weight";
            this.lbl_Weight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Weight.Click += new System.EventHandler(this.lbl_Weight_Click);
            // 
            // lbl_Maint
            // 
            this.lbl_Maint.AccessibleDescription = "Maintenance";
            this.lbl_Maint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Maint.Location = new System.Drawing.Point(5, 185);
            this.lbl_Maint.Name = "lbl_Maint";
            this.lbl_Maint.Size = new System.Drawing.Size(138, 36);
            this.lbl_Maint.TabIndex = 190;
            this.lbl_Maint.Text = "Maintenance";
            this.lbl_Maint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Maint.Click += new System.EventHandler(this.lbl_Maint_Click);
            // 
            // lbl_CleanPurge
            // 
            this.lbl_CleanPurge.AccessibleDescription = "Clean Purge";
            this.lbl_CleanPurge.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_CleanPurge.Location = new System.Drawing.Point(5, 149);
            this.lbl_CleanPurge.Name = "lbl_CleanPurge";
            this.lbl_CleanPurge.Size = new System.Drawing.Size(138, 36);
            this.lbl_CleanPurge.TabIndex = 189;
            this.lbl_CleanPurge.Text = "Clean Purge";
            this.lbl_CleanPurge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_CleanPurge.Click += new System.EventHandler(this.lbl_CleanPurge_Click);
            // 
            // lbl_DispControl
            // 
            this.lbl_DispControl.AccessibleDescription = "Disp Control";
            this.lbl_DispControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_DispControl.Location = new System.Drawing.Point(5, 113);
            this.lbl_DispControl.Name = "lbl_DispControl";
            this.lbl_DispControl.Size = new System.Drawing.Size(138, 36);
            this.lbl_DispControl.TabIndex = 188;
            this.lbl_DispControl.Text = "Disp Control";
            this.lbl_DispControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DispControl.Click += new System.EventHandler(this.lbl_DispControl_Click);
            // 
            // lbl_TeachNeedle
            // 
            this.lbl_TeachNeedle.AccessibleDescription = "Teach Needle";
            this.lbl_TeachNeedle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_TeachNeedle.Location = new System.Drawing.Point(5, 77);
            this.lbl_TeachNeedle.Name = "lbl_TeachNeedle";
            this.lbl_TeachNeedle.Size = new System.Drawing.Size(138, 36);
            this.lbl_TeachNeedle.TabIndex = 187;
            this.lbl_TeachNeedle.Text = "Teach Needle";
            this.lbl_TeachNeedle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_TeachNeedle.Click += new System.EventHandler(this.lbl_TeachNeedle_Click);
            // 
            // lbl_HeadCalSetting
            // 
            this.lbl_HeadCalSetting.AccessibleDescription = "Head Cal Setting";
            this.lbl_HeadCalSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_HeadCalSetting.Location = new System.Drawing.Point(5, 41);
            this.lbl_HeadCalSetting.Name = "lbl_HeadCalSetting";
            this.lbl_HeadCalSetting.Size = new System.Drawing.Size(138, 36);
            this.lbl_HeadCalSetting.TabIndex = 186;
            this.lbl_HeadCalSetting.Text = "Head Cal Setting";
            this.lbl_HeadCalSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadCalSetting.Click += new System.EventHandler(this.lbl_HeadCalSetting_Click);
            // 
            // lbl_HeadCal
            // 
            this.lbl_HeadCal.AccessibleDescription = "Head Calibration";
            this.lbl_HeadCal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_HeadCal.Location = new System.Drawing.Point(5, 5);
            this.lbl_HeadCal.Name = "lbl_HeadCal";
            this.lbl_HeadCal.Size = new System.Drawing.Size(138, 36);
            this.lbl_HeadCal.TabIndex = 185;
            this.lbl_HeadCal.Text = "Head Calibration";
            this.lbl_HeadCal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadCal.Click += new System.EventHandler(this.lbl_HeadCal_Click);
            // 
            // tmr_Reticle
            // 
            this.tmr_Reticle.Tick += new System.EventHandler(this.tmr_Reticle_Tick);
            // 
            // tmr1s
            // 
            this.tmr1s.Interval = 1000;
            this.tmr1s.Tick += new System.EventHandler(this.tmr1s_Tick);
            // 
            // frm_DispCore_DispSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(811, 705);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Jog);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frm_DispCore_DispSetup";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispSetup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_DispSetup_FormClosing);
            this.Load += new System.EventHandler(this.frmDispSetup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDispSetup_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CalHeadOfst;
        private System.Windows.Forms.Button btn_CalHeadOfstBCam;
        private System.Windows.Forms.Button btn_CalZSensor;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Jog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_CalLaser;
        private System.Windows.Forms.Button btn_CalLaserOfst;
        private System.Windows.Forms.Button btn_HeadOfstTouchDotSet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbl_HeadCal;
        private System.Windows.Forms.Label lbl_Custom;
        private System.Windows.Forms.Label lbl_Maint;
        private System.Windows.Forms.Label lbl_CleanPurge;
        private System.Windows.Forms.Label lbl_DispControl;
        private System.Windows.Forms.Label lbl_TeachNeedle;
        private System.Windows.Forms.Label lbl_HeadCalSetting;
        private System.Windows.Forms.Label lbl_Options;
        private System.Windows.Forms.Label lbl_Weight;
        private System.Windows.Forms.Timer tmr_Reticle;
        private System.Windows.Forms.CheckBox cbox_BypassTeachNeedleCheck;
        private System.Windows.Forms.Timer tmr1s;
        private System.Windows.Forms.Button btnCalTempSensorOfstPoint;
        private System.Windows.Forms.CheckBox cbTempSensorOfstManual;
    }
}