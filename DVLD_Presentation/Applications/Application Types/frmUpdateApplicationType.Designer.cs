namespace DVLD_Presentation.Applications.Application_Types
{
    partial class frmUpdateApplicationType
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtApplicationFees = new System.Windows.Forms.TextBox();
            this.txtApplicationTypeTitle = new System.Windows.Forms.TextBox();
            this.lblApplicationTypeID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationTypeIDCaption = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblApplicationFeesCaption = new System.Windows.Forms.Label();
            this.lblApplicationTypeTitleCaption = new System.Windows.Forms.Label();
            this.lblUpdateApplicationTypeCaption = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.btnClose.Location = new System.Drawing.Point(283, 278);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 40);
            this.btnClose.TabIndex = 150;
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
            this.btnSave.Location = new System.Drawing.Point(434, 278);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 40);
            this.btnSave.TabIndex = 149;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtApplicationFees
            // 
            this.txtApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationFees.Location = new System.Drawing.Point(171, 215);
            this.txtApplicationFees.Name = "txtApplicationFees";
            this.txtApplicationFees.Size = new System.Drawing.Size(398, 28);
            this.txtApplicationFees.TabIndex = 175;
            this.txtApplicationFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtApplicationFees_Validating);
            // 
            // txtApplicationTypeTitle
            // 
            this.txtApplicationTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationTypeTitle.Location = new System.Drawing.Point(171, 159);
            this.txtApplicationTypeTitle.Name = "txtApplicationTypeTitle";
            this.txtApplicationTypeTitle.Size = new System.Drawing.Size(398, 28);
            this.txtApplicationTypeTitle.TabIndex = 174;
            this.txtApplicationTypeTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtApplicationTypeTitle_Validating);
            // 
            // lblApplicationTypeID
            // 
            this.lblApplicationTypeID.AutoSize = true;
            this.lblApplicationTypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationTypeID.Location = new System.Drawing.Point(178, 108);
            this.lblApplicationTypeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationTypeID.Name = "lblApplicationTypeID";
            this.lblApplicationTypeID.Size = new System.Drawing.Size(54, 22);
            this.lblApplicationTypeID.TabIndex = 172;
            this.lblApplicationTypeID.Text = "????";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(116, 101);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 173;
            this.pictureBox1.TabStop = false;
            // 
            // lblApplicationTypeIDCaption
            // 
            this.lblApplicationTypeIDCaption.AutoSize = true;
            this.lblApplicationTypeIDCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationTypeIDCaption.Location = new System.Drawing.Point(29, 106);
            this.lblApplicationTypeIDCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationTypeIDCaption.Name = "lblApplicationTypeIDCaption";
            this.lblApplicationTypeIDCaption.Size = new System.Drawing.Size(35, 22);
            this.lblApplicationTypeIDCaption.TabIndex = 171;
            this.lblApplicationTypeIDCaption.Text = "ID:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Presentation.Properties.Resources.money_32;
            this.pictureBox5.Location = new System.Drawing.Point(116, 211);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(36, 36);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 170;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Presentation.Properties.Resources.ApplicationTitle;
            this.pictureBox2.Location = new System.Drawing.Point(116, 155);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 169;
            this.pictureBox2.TabStop = false;
            // 
            // lblApplicationFeesCaption
            // 
            this.lblApplicationFeesCaption.AutoSize = true;
            this.lblApplicationFeesCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFeesCaption.Location = new System.Drawing.Point(29, 216);
            this.lblApplicationFeesCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationFeesCaption.Name = "lblApplicationFeesCaption";
            this.lblApplicationFeesCaption.Size = new System.Drawing.Size(60, 22);
            this.lblApplicationFeesCaption.TabIndex = 168;
            this.lblApplicationFeesCaption.Text = "Fees:";
            // 
            // lblApplicationTypeTitleCaption
            // 
            this.lblApplicationTypeTitleCaption.AutoSize = true;
            this.lblApplicationTypeTitleCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationTypeTitleCaption.Location = new System.Drawing.Point(29, 160);
            this.lblApplicationTypeTitleCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationTypeTitleCaption.Name = "lblApplicationTypeTitleCaption";
            this.lblApplicationTypeTitleCaption.Size = new System.Drawing.Size(56, 22);
            this.lblApplicationTypeTitleCaption.TabIndex = 167;
            this.lblApplicationTypeTitleCaption.Text = "Title:";
            // 
            // lblUpdateApplicationTypeCaption
            // 
            this.lblUpdateApplicationTypeCaption.AutoSize = true;
            this.lblUpdateApplicationTypeCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateApplicationTypeCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(44)))), ((int)(((byte)(106)))));
            this.lblUpdateApplicationTypeCaption.Location = new System.Drawing.Point(142, 29);
            this.lblUpdateApplicationTypeCaption.Name = "lblUpdateApplicationTypeCaption";
            this.lblUpdateApplicationTypeCaption.Size = new System.Drawing.Size(314, 30);
            this.lblUpdateApplicationTypeCaption.TabIndex = 176;
            this.lblUpdateApplicationTypeCaption.Text = "Update Application Type";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmUpdateApplicationType
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(599, 346);
            this.Controls.Add(this.lblUpdateApplicationTypeCaption);
            this.Controls.Add(this.txtApplicationFees);
            this.Controls.Add(this.txtApplicationTypeTitle);
            this.Controls.Add(this.lblApplicationTypeID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblApplicationTypeIDCaption);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblApplicationFeesCaption);
            this.Controls.Add(this.lblApplicationTypeTitleCaption);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "frmUpdateApplicationType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Application Type";
            this.Load += new System.EventHandler(this.frmUpdateApplicationType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtApplicationFees;
        private System.Windows.Forms.TextBox txtApplicationTypeTitle;
        private System.Windows.Forms.Label lblApplicationTypeID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationTypeIDCaption;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblApplicationFeesCaption;
        private System.Windows.Forms.Label lblApplicationTypeTitleCaption;
        private System.Windows.Forms.Label lblUpdateApplicationTypeCaption;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}