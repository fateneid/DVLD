using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using DVLD_Presentation.Global_Classes;
using System.IO;

namespace DVLD_Presentation
{
    public partial class frmAddEdit : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGender { Male = 0, Female = 1 };

        private enMode _Mode;
        private bool _ImageChanged = false;
        private readonly string _ImagesDirectory = @"C:\DVLD_Images";

        int _PersonID;
        clsPerson _Person;

        public frmAddEdit()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEdit(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = enMode.Update;
        }

        private void frmAddEdit_Load(object sender, EventArgs e)
        {
            _FillCountries();
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

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
            _Person = new clsPerson();

            lblModeCaption.Text = "Add New Person";
            lblPersonID.Text = "N/A";

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            dtDateOfBirth.Value = dtDateOfBirth.MaxDate;
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            cbCountry.SelectedItem = "Egypt";
            txtAddress.Text = "";

            pbImage.ImageLocation = null;
            llRemoveImage.Visible = false;

        }

        private void _Update()
        {

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblModeCaption.Text = "Update Person";
            lblPersonID.Text = _PersonID.ToString();

            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtDateOfBirth.Value = _Person.DateOfBirth;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedItem = _Person.CountryInfo.CountryName;
            txtAddress.Text = _Person.Address;

            _LoadPersonImage();

            if (_Person.Gender == (short)enGender.Male) rbMale.Checked = true;
            else rbFemale.Checked = true;

        }

        private void _FillCountries()
        {
            DataTable dt = clsCountry.GetAllCountries();

            foreach (DataRow dr in dt.Rows)
            {
                cbCountry.Items.Add(dr["CountryName"]);
            }
        }

        private void _LoadPersonImage()
        {
            if (!string.IsNullOrWhiteSpace(_Person?.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pbImage.ImageLocation = _Person.ImagePath;
                llRemoveImage.Visible = true;
                return;
            }

            pbImage.ImageLocation = null;
            pbImage.Image = rbMale.Checked?
                Properties.Resources.Male_512: 
                Properties.Resources.Female_512;

            llRemoveImage.Visible = false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbImage.Load(selectedFilePath);

                _ImageChanged = true;
                llRemoveImage.Visible = true;
            }
        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Person.ImagePath = "";
            _LoadPersonImage();
            _ImageChanged = true;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _LoadPersonImage();
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _LoadPersonImage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error(s)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string oldImagePath = _Person.ImagePath;
            string newImagePath = pbImage.ImageLocation;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.DateOfBirth = dtDateOfBirth.Value;
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;
            _Person.Address = txtAddress.Text.Trim();

            if (_ImageChanged)
            {
                _Person.ImagePath = clsImageHelper.SaveImage(newImagePath, _ImagesDirectory);

                if (string.IsNullOrEmpty(_Person.ImagePath))
                {
                    MessageBox.Show("Unable to save image.");
                    return;
                }
            }
            else
            { 
                _Person.ImagePath = oldImagePath; 
            }

            _Person.Gender = (short)(rbMale.Checked ? enGender.Male : enGender.Female);

            if (_Person.Save())
            {
                if (_ImageChanged) clsImageHelper.DeleteImage(oldImagePath);
                _ImageChanged = false;

                MessageBox.Show("Data Saved Successfully.");
                _Mode = enMode.Update;
                lblModeCaption.Text = "Update Person";
                lblPersonID.Text = _Person.PersonID.ToString();
            }
            else
            {
                if (_ImageChanged) clsImageHelper.DeleteImage(_Person.ImagePath);
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _ValidateRequired(Control control, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(control.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(control, "This field is required!");
                return false;
            }
            errorProvider1.SetError(control, "");
            return true;
        }

        private void RequiredField_Validating(object sender, CancelEventArgs e)
        {
            _ValidateRequired((Control)sender, e);
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, "");
                return;
            }

            if(!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Format!");
            }
            else errorProvider1.SetError(txtEmail, "");

        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtNationalNo, e)) return;

            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
            }
            else errorProvider1.SetError(txtNationalNo, "");

        }

    }

}
