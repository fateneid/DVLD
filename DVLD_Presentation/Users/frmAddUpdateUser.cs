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
using System.Xml.Serialization;

namespace DVLD_Presentation.Users
{
    public partial class frmAddUpdateUser : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        private clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    _AddNew();
                    break;
                case enMode.Update:
                    _Update();
                    break;
            }
        }

        private void _AddNew()
        {
            _User = new clsUser();

            lblModeCaption.Text = "Add New User";
            this.Text = "Add New User";

            lblUserID.Text = "????";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;

            btnNext.Enabled = false;
            btnSave.Enabled = false;
            ctrlPersonCardWithFilter1.FilterEnabled = true;

        }
        private void _Update()
        {
            lblModeCaption.Text = "Update User";
            this.Text = "Update User";

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;

            btnNext.Enabled = true;
            btnSave.Enabled = true;
            ctrlPersonCardWithFilter1.FilterEnabled = false;

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            btnNext.Enabled = PersonID != -1;
            if(PersonID == -1)
            {
                MessageBox.Show("Please Select an exist person", "Person not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void tcAddUpdateUser_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpLoginInfo && !btnNext.Enabled)
            {
                e.Cancel = true;
            }
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

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtUserName, e)) return;

            if (txtUserName.Text.Trim() != _User.UserName && clsUser.IsUserExist(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username is used by another user");
            }
            else errorProvider1.SetError(txtUserName, "");
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtPassword, e)) return;
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtConfirmPassword, e)) return;

            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password confirmation does not match the Password!");
            }
            else errorProvider1.SetError(txtConfirmPassword, "");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUser.IsUserExistByPersonID(ctrlPersonCardWithFilter1.PersonID)
                && _Mode == enMode.AddNew)
            {
                MessageBox.Show("Selected Person already is a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
                return;
            }
            tcAddUpdateUser.SelectedTab = tpLoginInfo;
            btnSave.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error(s)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update;
                lblModeCaption.Text = "Update User";
                this.Text = "Update User";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
