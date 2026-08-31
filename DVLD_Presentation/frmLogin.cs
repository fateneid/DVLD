using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string username = "", password = "";       
            if(clsGlobal.LoadRememberedCredentials(ref username, ref password))
            {
                txtUsername.Text = username;
                txtPassword.Text = password;
                chRememberMe.Checked = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string UserName = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();

           clsUser user = clsUser.FindByUsernameAndPassword(UserName, Password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!user.IsActive)
            {
                txtUsername.Focus();
                MessageBox.Show("Your account is inactive. Please contact your administrator", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsGlobal.CurrentUser = user;

            if (chRememberMe.Checked)
                clsGlobal.SaveRememberedCredentials(UserName, Password);
            else
                clsGlobal.ClearRememberedCredentials();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
