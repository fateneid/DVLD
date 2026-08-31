using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("Could not Find User with id = " + _UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserCard1.LoadUserInfo(_UserID);
            
        }

        private bool _ValidateRequired(Control control, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(control, "This field is required!");
                return false;
            }
            errorProvider1.SetError(control, "");
            return true;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtCurrentPassword, e)) return;

            if (txtCurrentPassword.Text.Trim() != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
            }
            else errorProvider1.SetError(txtCurrentPassword, "");
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtNewPassword, e)) return;
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtConfirmPassword, e)) return;

            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password confirmation does not match the Password!");
            }
            else errorProvider1.SetError(txtConfirmPassword, "");
        }

        private void _ResetFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            errorProvider1.Clear();
            txtCurrentPassword.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error(s)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_User.ChangePassword(txtNewPassword.Text.Trim())) 
            {
                MessageBox.Show("Password Changed Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetFields();
            }
            else 
            {
                MessageBox.Show("Error: Password Is not Changed Successfully.");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
