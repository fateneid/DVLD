using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.People
{
    public partial class ctrlPersonCard : UserControl
    {

        private int _PersonID = -1;
        private clsPerson _Person;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPerson
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (!string.IsNullOrWhiteSpace(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pbImage.ImageLocation = _Person.ImagePath;
                return;
            }

            pbImage.Image = _Person.Gender == 0? 
            Properties.Resources.Male_512:
            Properties.Resources.Female_512;
           
        }

        private void _FillPersonInfo()
        {
            _PersonID = _Person.PersonID;

            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;

            if (_Person.Gender == 0)
            {
                lblGender.Text = "Male";
                pbGender.Image = Properties.Resources.Man_32;
            }
            else
            {
                lblGender.Text = "Female";
                pbGender.Image = Properties.Resources.Woman_32;
            }

            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = _Person.CountryInfo.CountryName;

            _LoadPersonImage();

            llEditPersonInfo.Enabled = true;

        }

        private void _ResetPersonInfo()
        {
            _PersonID = -1;

            lblPersonID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            pbGender.Image = Properties.Resources.Man_32;
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblPhone.Text = "[????]";
            lblCountry.Text = "[????]";
            pbImage.Image = Properties.Resources.Male_512;

            llEditPersonInfo.Enabled = false;

        }

        public void LoadPersonInfo(int PersonID)
        {
        
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person with Person ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }

        public void LoadPersonInfo(string NationalNo)
        {

            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEdit frm = new frmAddEdit(_PersonID);
            frm.ShowDialog();

            LoadPersonInfo(_PersonID);

        }


    }

}
