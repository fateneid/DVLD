namespace DVLD_Presentation.Applications.Local_Driving_License
{
    partial class frmAddUpdateLocalLicenseApplication
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tcAddUpdateLocalDrivingLicesnseApplication = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter1 = new DVLD_Presentation.People.Controls.ctrlPersonWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblCreatedByCaption = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblApplicationFeesCaption = new System.Windows.Forms.Label();
            this.lblDLApplicationID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDLApplicationIDCaption = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblLicenseClassCaption = new System.Windows.Forms.Label();
            this.lblApplicationDateCaption = new System.Windows.Forms.Label();
            this.lblModeCaption = new System.Windows.Forms.Label();
            this.object_e1391651_1e89_4672_b32e_ae75ea858627 = new System.Windows.Forms.Label();
            this.tcAddUpdateLocalDrivingLicesnseApplication.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Image = global::DVLD_Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(888, 793);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 52);
            this.btnClose.TabIndex = 152;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Image = global::DVLD_Presentation.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1054, 793);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 52);
            this.btnSave.TabIndex = 151;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcAddUpdateLocalDrivingLicesnseApplication
            // 
            this.tcAddUpdateLocalDrivingLicesnseApplication.Controls.Add(this.tpPersonalInfo);
            this.tcAddUpdateLocalDrivingLicesnseApplication.Controls.Add(this.tpApplicationInfo);
            this.tcAddUpdateLocalDrivingLicesnseApplication.Location = new System.Drawing.Point(22, 95);
            this.tcAddUpdateLocalDrivingLicesnseApplication.Name = "tcAddUpdateLocalDrivingLicesnseApplication";
            this.tcAddUpdateLocalDrivingLicesnseApplication.SelectedIndex = 0;
            this.tcAddUpdateLocalDrivingLicesnseApplication.Size = new System.Drawing.Size(1191, 686);
            this.tcAddUpdateLocalDrivingLicesnseApplication.TabIndex = 150;
            this.tcAddUpdateLocalDrivingLicesnseApplication.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcAddUpdateLocalDrivingLicesnseApplication_Selecting);
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 29);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(1183, 653);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(7, 15);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1168, 556);
            this.ctrlPersonCardWithFilter1.TabIndex = 150;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.Image = global::DVLD_Presentation.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(1010, 582);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(156, 52);
            this.btnNext.TabIndex = 149;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tpApplicationInfo.Controls.Add(this.pictureBox4);
            this.tpApplicationInfo.Controls.Add(this.lblCreatedByCaption);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClass);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.pictureBox3);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationFeesCaption);
            this.tpApplicationInfo.Controls.Add(this.lblDLApplicationID);
            this.tpApplicationInfo.Controls.Add(this.pictureBox1);
            this.tpApplicationInfo.Controls.Add(this.lblDLApplicationIDCaption);
            this.tpApplicationInfo.Controls.Add(this.pictureBox5);
            this.tpApplicationInfo.Controls.Add(this.pictureBox2);
            this.tpApplicationInfo.Controls.Add(this.lblLicenseClassCaption);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationDateCaption);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(1183, 653);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCreatedBy.Location = new System.Drawing.Point(409, 309);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(56, 25);
            this.lblCreatedBy.TabIndex = 173;
            this.lblCreatedBy.Text = "????";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Presentation.Properties.Resources.User_32__2;
            this.pictureBox4.Location = new System.Drawing.Point(343, 303);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(36, 36);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 172;
            this.pictureBox4.TabStop = false;
            // 
            // lblCreatedByCaption
            // 
            this.lblCreatedByCaption.AutoSize = true;
            this.lblCreatedByCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByCaption.Location = new System.Drawing.Point(125, 309);
            this.lblCreatedByCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedByCaption.Name = "lblCreatedByCaption";
            this.lblCreatedByCaption.Size = new System.Drawing.Size(127, 25);
            this.lblCreatedByCaption.TabIndex = 171;
            this.lblCreatedByCaption.Text = "Created By:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblApplicationFees.Location = new System.Drawing.Point(409, 256);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(56, 25);
            this.lblApplicationFees.TabIndex = 170;
            this.lblApplicationFees.Text = "????";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(409, 195);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(364, 33);
            this.cbLicenseClass.TabIndex = 169;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblApplicationDate.Location = new System.Drawing.Point(409, 142);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(56, 25);
            this.lblApplicationDate.TabIndex = 168;
            this.lblApplicationDate.Text = "????";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Presentation.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(343, 250);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 162;
            this.pictureBox3.TabStop = false;
            // 
            // lblApplicationFeesCaption
            // 
            this.lblApplicationFeesCaption.AutoSize = true;
            this.lblApplicationFeesCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFeesCaption.Location = new System.Drawing.Point(125, 256);
            this.lblApplicationFeesCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationFeesCaption.Name = "lblApplicationFeesCaption";
            this.lblApplicationFeesCaption.Size = new System.Drawing.Size(180, 25);
            this.lblApplicationFeesCaption.TabIndex = 161;
            this.lblApplicationFeesCaption.Text = "Application Fees:";
            // 
            // lblDLApplicationID
            // 
            this.lblDLApplicationID.AutoSize = true;
            this.lblDLApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLApplicationID.Location = new System.Drawing.Point(409, 89);
            this.lblDLApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDLApplicationID.Name = "lblDLApplicationID";
            this.lblDLApplicationID.Size = new System.Drawing.Size(56, 25);
            this.lblDLApplicationID.TabIndex = 157;
            this.lblDLApplicationID.Text = "????";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(343, 83);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 158;
            this.pictureBox1.TabStop = false;
            // 
            // lblDLApplicationIDCaption
            // 
            this.lblDLApplicationIDCaption.AutoSize = true;
            this.lblDLApplicationIDCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLApplicationIDCaption.Location = new System.Drawing.Point(125, 89);
            this.lblDLApplicationIDCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDLApplicationIDCaption.Name = "lblDLApplicationIDCaption";
            this.lblDLApplicationIDCaption.Size = new System.Drawing.Size(210, 25);
            this.lblDLApplicationIDCaption.TabIndex = 156;
            this.lblDLApplicationIDCaption.Text = "L.D.L.Application ID:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Presentation.Properties.Resources.LocalDriving_License;
            this.pictureBox5.Location = new System.Drawing.Point(343, 193);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(36, 36);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 155;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Presentation.Properties.Resources.Calendar_32;
            this.pictureBox2.Location = new System.Drawing.Point(343, 136);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 154;
            this.pictureBox2.TabStop = false;
            // 
            // lblLicenseClassCaption
            // 
            this.lblLicenseClassCaption.AutoSize = true;
            this.lblLicenseClassCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClassCaption.Location = new System.Drawing.Point(125, 199);
            this.lblLicenseClassCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseClassCaption.Name = "lblLicenseClassCaption";
            this.lblLicenseClassCaption.Size = new System.Drawing.Size(155, 25);
            this.lblLicenseClassCaption.TabIndex = 153;
            this.lblLicenseClassCaption.Text = "License Class:";
            // 
            // lblApplicationDateCaption
            // 
            this.lblApplicationDateCaption.AutoSize = true;
            this.lblApplicationDateCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDateCaption.Location = new System.Drawing.Point(125, 142);
            this.lblApplicationDateCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationDateCaption.Name = "lblApplicationDateCaption";
            this.lblApplicationDateCaption.Size = new System.Drawing.Size(177, 25);
            this.lblApplicationDateCaption.TabIndex = 152;
            this.lblApplicationDateCaption.Text = "Application Date:";
            // 
            // lblModeCaption
            // 
            this.lblModeCaption.AutoSize = true;
            this.lblModeCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(44)))), ((int)(((byte)(106)))));
            this.lblModeCaption.Location = new System.Drawing.Point(249, 26);
            this.lblModeCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModeCaption.Name = "lblModeCaption";
            this.lblModeCaption.Size = new System.Drawing.Size(736, 46);
            this.lblModeCaption.TabIndex = 149;
            this.lblModeCaption.Text = "New Local Driving License Application";
            // 
            // object_e1391651_1e89_4672_b32e_ae75ea858627
            // 
            this.object_e1391651_1e89_4672_b32e_ae75ea858627.AutoSize = true;
            this.object_e1391651_1e89_4672_b32e_ae75ea858627.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.object_e1391651_1e89_4672_b32e_ae75ea858627.Location = new System.Drawing.Point(407, 254);
            this.object_e1391651_1e89_4672_b32e_ae75ea858627.Name = "object_e1391651_1e89_4672_b32e_ae75ea858627";
            this.object_e1391651_1e89_4672_b32e_ae75ea858627.Size = new System.Drawing.Size(56, 25);
            this.object_e1391651_1e89_4672_b32e_ae75ea858627.TabIndex = 170;
            // 
            // frmAddUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1235, 871);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcAddUpdateLocalDrivingLicesnseApplication);
            this.Controls.Add(this.lblModeCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Application";
            this.Activated += new System.EventHandler(this.frmAddUpdateLocalDrivingLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmAddUpdateLocalDrivingLicenseApplication_Load);
            this.tcAddUpdateLocalDrivingLicesnseApplication.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tcAddUpdateLocalDrivingLicesnseApplication;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblApplicationFeesCaption;
        private System.Windows.Forms.Label lblDLApplicationID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDLApplicationIDCaption;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblLicenseClassCaption;
        private System.Windows.Forms.Label lblApplicationDateCaption;
        private System.Windows.Forms.Label lblModeCaption;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblCreatedByCaption;
        private System.Windows.Forms.Label object_e1391651_1e89_4672_b32e_ae75ea858627;
        private People.Controls.ctrlPersonWithFilter ctrlPersonCardWithFilter1;
    }
}