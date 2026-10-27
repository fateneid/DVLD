using DVLD_Business;
using System.IO;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses.Controls
{
    public partial class ctrlDriverLocalLicense : UserControl
    {
        private int _LicenseID = -1;
        public int LicenseID
        {
            get { return _LicenseID; }
        }
        private clsLicense _License;
        public clsLicense SelectedLicense
        {
            get { return _License; }
        }

        public ctrlDriverLocalLicense()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            string ImagePath = _License.Driver.Person.ImagePath;
            if (!string.IsNullOrWhiteSpace(ImagePath) && File.Exists(ImagePath))
            {
                pbImage.ImageLocation = ImagePath;
                return;
            }

            pbImage.Image = _License.Driver.Person.Gender == 0 ?
            Properties.Resources.Male_512 :
            Properties.Resources.Female_512;

        }

        private void _FillInfo()
        {
            _LicenseID = _License.LicenseID;

            lblClass.Text = _License.LicenseClass.ClassName;
            lblFullName.Text = _License.Driver.Person.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.Driver.Person.NationalNo;

            if (_License.Driver.Person.Gender == 0)
            {
                lblGender.Text = "Male";
                pbGender.Image = Properties.Resources.Man_32;
            }
            else
            {
                lblGender.Text = "Female";
                pbGender.Image = Properties.Resources.Woman_32;
            }

            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = string.IsNullOrWhiteSpace(_License.Notes)? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License.Driver.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = _License.IsDetained? "Yes" : "No";

            _LoadPersonImage();

        }
        
        public void ResetInfo()
        {
            _LicenseID = -1;
            _License = null;

            lblClass.Text = "[????]";
            lblFullName.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            pbGender.Image = Properties.Resources.Man_32;
            lblGender.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblNotes.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblIsDetained.Text = "[????]";
            pbImage.Image = Properties.Resources.Male_512;
        }

        public bool LoadInfo(int LicenseID)
        {
            _License = clsLicense.Find(LicenseID);
            if (_License == null)
            {
                ResetInfo();
                MessageBox.Show("Could not find License ID = " + LicenseID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _FillInfo();

            return true;
        }


    }
}
