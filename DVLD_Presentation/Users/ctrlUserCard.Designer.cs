namespace DVLD_Presentation.Users
{
    partial class ctrlUserCard
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
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblIsActiveCaption = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsernameCaption = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserIDCaption = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new DVLD_Presentation.People.ctrlPersonCard();
            this.gbUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.Controls.Add(this.lblIsActive);
            this.gbUserInfo.Controls.Add(this.lblIsActiveCaption);
            this.gbUserInfo.Controls.Add(this.lblUsername);
            this.gbUserInfo.Controls.Add(this.lblUsernameCaption);
            this.gbUserInfo.Controls.Add(this.lblUserID);
            this.gbUserInfo.Controls.Add(this.lblUserIDCaption);
            this.gbUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbUserInfo.Location = new System.Drawing.Point(7, 450);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Size = new System.Drawing.Size(1149, 121);
            this.gbUserInfo.TabIndex = 1;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "Login Information";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(912, 48);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(68, 25);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "[????]";
            // 
            // lblIsActiveCaption
            // 
            this.lblIsActiveCaption.AutoSize = true;
            this.lblIsActiveCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblIsActiveCaption.Location = new System.Drawing.Point(808, 48);
            this.lblIsActiveCaption.Name = "lblIsActiveCaption";
            this.lblIsActiveCaption.Size = new System.Drawing.Size(102, 25);
            this.lblIsActiveCaption.TabIndex = 4;
            this.lblIsActiveCaption.Text = "Is Active:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(596, 48);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(68, 25);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "[????]";
            // 
            // lblUsernameCaption
            // 
            this.lblUsernameCaption.AutoSize = true;
            this.lblUsernameCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUsernameCaption.Location = new System.Drawing.Point(476, 48);
            this.lblUsernameCaption.Name = "lblUsernameCaption";
            this.lblUsernameCaption.Size = new System.Drawing.Size(117, 25);
            this.lblUsernameCaption.TabIndex = 2;
            this.lblUsernameCaption.Text = "Username:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(264, 48);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(68, 25);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "[????]";
            // 
            // lblUserIDCaption
            // 
            this.lblUserIDCaption.AutoSize = true;
            this.lblUserIDCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUserIDCaption.Location = new System.Drawing.Point(169, 48);
            this.lblUserIDCaption.Name = "lblUserIDCaption";
            this.lblUserIDCaption.Size = new System.Drawing.Size(91, 25);
            this.lblUserIDCaption.TabIndex = 0;
            this.lblUserIDCaption.Text = "User ID:";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(2, 5);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1161, 437);
            this.ctrlPersonCard1.TabIndex = 2;
            // 
            // ctrlUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.gbUserInfo);
            this.Name = "ctrlUserCard";
            this.Size = new System.Drawing.Size(1164, 576);
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblIsActiveCaption;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUsernameCaption;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblUserIDCaption;
        private People.ctrlPersonCard ctrlPersonCard1;
    }
}
