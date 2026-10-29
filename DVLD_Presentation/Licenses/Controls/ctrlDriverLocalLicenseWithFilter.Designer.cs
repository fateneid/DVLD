namespace DVLD_Presentation.Licenses.Controls
{
    partial class ctrlDriverLocalLicenseWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.txtFindByValue = new System.Windows.Forms.TextBox();
            this.lblFindByLicenseIDCaption = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlDriverLocalLicense1 = new DVLD_Presentation.Licenses.Controls.ctrlDriverLocalLicense();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindLicense);
            this.gbFilter.Controls.Add(this.txtFindByValue);
            this.gbFilter.Controls.Add(this.lblFindByLicenseIDCaption);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(10, 2);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1150, 100);
            this.gbFilter.TabIndex = 2;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLicense.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFindLicense.Image = global::DVLD_Presentation.Properties.Resources.License_View_32;
            this.btnFindLicense.Location = new System.Drawing.Point(802, 28);
            this.btnFindLicense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(48, 48);
            this.btnFindLicense.TabIndex = 149;
            this.btnFindLicense.UseVisualStyleBackColor = false;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // txtFindByValue
            // 
            this.txtFindByValue.Location = new System.Drawing.Point(436, 37);
            this.txtFindByValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindByValue.Name = "txtFindByValue";
            this.txtFindByValue.Size = new System.Drawing.Size(333, 30);
            this.txtFindByValue.TabIndex = 147;
            this.txtFindByValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindByValue_KeyPress);
            this.txtFindByValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFindByValue_Validating);
            // 
            // lblFindByLicenseIDCaption
            // 
            this.lblFindByLicenseIDCaption.AutoSize = true;
            this.lblFindByLicenseIDCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindByLicenseIDCaption.Location = new System.Drawing.Point(300, 40);
            this.lblFindByLicenseIDCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFindByLicenseIDCaption.Name = "lblFindByLicenseIDCaption";
            this.lblFindByLicenseIDCaption.Size = new System.Drawing.Size(121, 25);
            this.lblFindByLicenseIDCaption.TabIndex = 145;
            this.lblFindByLicenseIDCaption.Text = "License ID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlDriverLocalLicense1
            // 
            this.ctrlDriverLocalLicense1.BackColor = System.Drawing.Color.White;
            this.ctrlDriverLocalLicense1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDriverLocalLicense1.Location = new System.Drawing.Point(5, 101);
            this.ctrlDriverLocalLicense1.Name = "ctrlDriverLocalLicense1";
            this.ctrlDriverLocalLicense1.Size = new System.Drawing.Size(1160, 455);
            this.ctrlDriverLocalLicense1.TabIndex = 3;
            // 
            // ctrlDriverLocalLicenseWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlDriverLocalLicense1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrlDriverLocalLicenseWithFilter";
            this.Size = new System.Drawing.Size(1170, 560);
            this.Load += new System.EventHandler(this.ctrlDriverLocalLicenseWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.TextBox txtFindByValue;
        private System.Windows.Forms.Label lblFindByLicenseIDCaption;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlDriverLocalLicense ctrlDriverLocalLicense1;
    }
}
