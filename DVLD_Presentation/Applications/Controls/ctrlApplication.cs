using DVLD_Business;
using DVLD_Presentation.People;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Controls
{
    public partial class ctrlApplication : UserControl
    {

        private int _ApplicationID = -1;
        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        private clsApplication _Application;
        public clsApplication SelectedApplication
        {
            get { return _Application; }
        }

        public ctrlApplication()
        {
            InitializeComponent();
        }

        private void _FillInfo()
        {
            _ApplicationID = _Application.ApplicationID;

            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.ApplicationStatus.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationType.ApplicationTypeTitle;
            lblApplicant.Text = _Application.Person.FullName;
            lblDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _Application.User.UserName;

            llViewPersonInfo.Enabled = true;
        }

        public void ResetInfo()
        {
            _ApplicationID = -1;
            _Application = null;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblFees.Text = "[????]";
            lblType.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedBy.Text = "[????]";

            llViewPersonInfo.Enabled = false;
        }

        public void LoadInfo(int ApplicationID)
        {
            _Application = clsApplication.Find(ApplicationID);
            if (_Application == null)
            {
                ResetInfo();
                MessageBox.Show("No Application with Application ID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInfo();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();

            LoadInfo(_ApplicationID);
        }

    }
}
