using DVLD_Business;
using System.IO;
using System.Windows.Forms;

namespace DVLD_Presentation.People.Controls
{
    public partial class ctrlPerson : UserControl
    {

        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }
        private clsPerson _Person;
        public clsPerson SelectedPerson
        {
            get { return _Person; }
        }

        public ctrlPerson()
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

        private void _FillInfo()
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

        public void ResetInfo()
        {
            _PersonID = -1;
            _Person = null;

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

        public void LoadInfo(int PersonID)
        {
        
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetInfo();
                MessageBox.Show("No Person with Person ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInfo();

        }

        public void LoadInfo(string NationalNo)
        {

            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInfo();

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
       
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadInfo(_PersonID);
            }

        }

    }

}
