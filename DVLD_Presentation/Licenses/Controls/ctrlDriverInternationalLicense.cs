using DVLD_Business;
using System.IO;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses.Controls
{
    public partial class ctrlDriverInternationalLicense : UserControl
    {
        private int _InternationalLicenseID = -1;
        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }
        private clsInternationalLicense _InternationalLicense;
        public clsInternationalLicense InternationalLicense
        {
            get { return _InternationalLicense; }
        }

        public ctrlDriverInternationalLicense()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            string ImagePath = _InternationalLicense.Driver.Person.ImagePath;
            if (!string.IsNullOrWhiteSpace(ImagePath) && File.Exists(ImagePath))
            {
                pbImage.ImageLocation = ImagePath;
                return;
            }

            pbImage.Image = _InternationalLicense.Driver.Person.Gender == 0 ?
            Properties.Resources.Male_512 :
            Properties.Resources.Female_512;
        }

        private void _FillInfo()
        {
            _InternationalLicenseID = _InternationalLicense.InternationalLicenseID;

            lblFullName.Text = _InternationalLicense.Driver.Person.FullName;
            lblIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicense.Driver.Person.NationalNo;
            if (_InternationalLicense.Driver.Person.Gender == 0)
            {
                lblGender.Text = "Male";
                pbGender.Image = Properties.Resources.Man_32;
            }
            else
            {
                lblGender.Text = "Female";
                pbGender.Image = Properties.Resources.Woman_32;
            }
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _InternationalLicense.Driver.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();

            _LoadPersonImage();
        }

        public void ResetInfo()
        {
            _InternationalLicenseID = -1;
            _InternationalLicense = null;

            lblFullName.Text = "[????]";
            lblIntLicenseID.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            pbGender.Image = Properties.Resources.Man_32;
            lblIssueDate.Text = "[????]";
            lblApplicationID.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            pbImage.Image = Properties.Resources.Male_512;
        }

        public bool LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                ResetInfo();
                MessageBox.Show("Could not find International License ID = " + InternationalLicenseID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _FillInfo();

            return true;
        }

    }
}
