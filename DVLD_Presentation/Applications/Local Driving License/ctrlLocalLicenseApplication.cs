using DVLD_Business;
using DVLD_Presentation.Licenses;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Local_Driving_License
{
    public partial class ctrlLocalLicenseApplication : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplication?.LocalDrivingLicenseApplicationID ?? -1; }
        }

        public ctrlLocalLicenseApplication()
        {
            InitializeComponent();
        }

        private void _FillInfo()
        {
            ctrlApplicationCard1.LoadInfo(_LocalDrivingLicenseApplication.ApplicationID);

            lblLDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestsCount().ToString() + "/3";

            llShowLicenseInfo.Enabled = _LocalDrivingLicenseApplication.IsLicenseIssued();

        }

        public void ResetInfo()
        {
            ctrlApplicationCard1.ResetInfo();

            _LocalDrivingLicenseApplication = null;

            lblLDLApplicationID.Text = "[????]";
            lblAppliedForLicense.Text = "[????]";
            lblPassedTests.Text = "[????]";

            llShowLicenseInfo.Enabled = false;

        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                ResetInfo();
                MessageBox.Show("No Local Driving License Application with ID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInfo();

        }
        public void LoadInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                ResetInfo();
                MessageBox.Show("No Application with ID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInfo();

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLocalLicenseInfo frm = new frmShowLocalLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            frm.ShowDialog();
        }


    }
}
