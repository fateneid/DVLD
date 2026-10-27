using DVLD_Business;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.Tests;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Local_Driving_License
{
    public partial class frmListLocalLicenseApplications : Form
    {
        private DataView _DataSource = clsLocalDrivingLicenseApplication.GetAll().DefaultView;
        private int _LocalAppID
        { 
            get 
            {
                return dgvAllLocalDrivingLicenseApplications.CurrentRow == null ? -1 :
                    (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;
            } 
        }

        public frmListLocalLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            dgvAllLocalDrivingLicenseApplications.DataSource = _DataSource;
            _SetupGridColumns();
            lblRecordsCount.Text = _DataSource.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
        }

        private void _SetupGridColumns()
        {

            dgvAllLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.AppID";
            dgvAllLocalDrivingLicenseApplications.Columns["ClassName"].HeaderText = "Driving Name";
            dgvAllLocalDrivingLicenseApplications.Columns["NationalNo"].HeaderText = "National No.";
            dgvAllLocalDrivingLicenseApplications.Columns["FullName"].HeaderText = "Full Name";
            dgvAllLocalDrivingLicenseApplications.Columns["ApplicationDate"].HeaderText = "Application Date";
            dgvAllLocalDrivingLicenseApplications.Columns["PassedTests"].HeaderText = "Passed Tests";
            dgvAllLocalDrivingLicenseApplications.Columns["AppStatus"].HeaderText = "Status";

            dgvAllLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].DisplayIndex = 0;
            dgvAllLocalDrivingLicenseApplications.Columns["ClassName"].DisplayIndex = 1;
            dgvAllLocalDrivingLicenseApplications.Columns["NationalNo"].DisplayIndex = 2;
            dgvAllLocalDrivingLicenseApplications.Columns["FullName"].DisplayIndex = 3;
            dgvAllLocalDrivingLicenseApplications.Columns["ApplicationDate"].DisplayIndex = 4;
            dgvAllLocalDrivingLicenseApplications.Columns["PassedTests"].DisplayIndex = 5;
            dgvAllLocalDrivingLicenseApplications.Columns["AppStatus"].DisplayIndex = 6;

            dgvAllLocalDrivingLicenseApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAllLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].FillWeight = 55;
            dgvAllLocalDrivingLicenseApplications.Columns["ClassName"].FillWeight = 160;
            dgvAllLocalDrivingLicenseApplications.Columns["NationalNo"].FillWeight = 90;
            dgvAllLocalDrivingLicenseApplications.Columns["FullName"].FillWeight = 160;
            dgvAllLocalDrivingLicenseApplications.Columns["ApplicationDate"].FillWeight = 100;
            dgvAllLocalDrivingLicenseApplications.Columns["PassedTests"].FillWeight = 70;
            dgvAllLocalDrivingLicenseApplications.Columns["AppStatus"].FillWeight = 70;

        }

        private void _ApplyFilter(string filter)
        {
            _DataSource.RowFilter = filter;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }
        private void _ReloadData()
        {
            _DataSource = clsLocalDrivingLicenseApplication.GetAll().DefaultView;
            dgvAllLocalDrivingLicenseApplications.DataSource = _DataSource;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }

        private void _DeleteLocalDrivingLicenseApplication()
        {
            if (MessageBox.Show("Are you sure you want to delete this application?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                clsLocalDrivingLicenseApplication LocalApplication = clsLocalDrivingLicenseApplication.Find(_LocalAppID);

                if (LocalApplication == null)
                    return;

                if (!LocalApplication.Delete())
                {
                    MessageBox.Show("Could not delete application, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Application deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ReloadData();
            }
        }
        private void _CancelLocalDrivingLicenseApplication()
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLocalDrivingLicenseApplication LocalApplication = clsLocalDrivingLicenseApplication.Find(_LocalAppID);

                if (LocalApplication == null)
                    return;

                if (!LocalApplication.ChangeStatus(clsApplication.enApplicationStatus.Cancelled))
                {
                    MessageBox.Show("Could not cancel the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Application cancelled successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ReloadData();
            }
        }
        private void _ScheduleTest(clsTestType.enTestType TestType) 
        {
            frmListTestAppointments frm = new frmListTestAppointments(_LocalAppID, TestType);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNone = cbFilterBy.Text == "None";
            bool isStatus = cbFilterBy.Text == "Status";

            txtSearch.Visible = !isNone && !isStatus;
            cbSearchStatus.Visible = isStatus;

            cbSearchStatus.SelectedIndex = 0;
            txtSearch.Clear();
        }
        private void cbSearchStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchStatus.SelectedIndex == 0)
            {
                _ApplyFilter("");
            }
            else
            {
                _ApplyFilter($"AppStatus = '{cbSearchStatus.Text}'");
            }
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "L.D.L.AppID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _ApplyFilter("");
                return;
            }

            string colName = "";
            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    colName = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    colName = "NationalNo";
                    break;
                case "Full Name":
                    colName = "FullName";
                    break;
                default:
                    return;
            }

            if (colName == "LocalDrivingLicenseApplicationID")
            {
                _ApplyFilter($"{colName} = {txtSearch.Text}");
            }
            else
            {
                _ApplyFilter($"{colName} LIKE '{txtSearch.Text}%'");
            }

        }

        private void btnAddLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalLicenseApplication frm = new frmAddUpdateLocalLicenseApplication();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmsLocalApp_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int LocalAppID = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;
            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.Find(LocalAppID);

            bool IsNew = LocalApp.ApplicationStatus == clsApplication.enApplicationStatus.New;

            int PassedTests = (int)dgvAllLocalDrivingLicenseApplications.CurrentRow.Cells["PassedTests"].Value;

            bool PassedVisionTest = LocalApp.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = LocalApp.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalApp.DoesPassTestType(clsTestType.enTestType.StreetTest);


            // Application options
            editApplicationToolStripMenuItem.Enabled = IsNew;
            deleteApplicationToolStripMenuItem.Enabled = IsNew;
            cancelApplicationToolStripMenuItem.Enabled = IsNew;
            scheduleTestToolStripMenuItem.Enabled = IsNew && PassedTests < 3;

            // License options
            issueDrivingLicenseToolStripMenuItem.Enabled = IsNew && PassedTests == 3;
            showLicenseToolStripMenuItem.Enabled = LocalApp.IsLicenseIssued();

            // Schedule test options
            scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;
            scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;
            scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalLicenseApplicationInfo frm = new frmShowLocalLicenseApplicationInfo(_LocalAppID);

            frm.ShowDialog();
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalLicenseApplication frm = new frmAddUpdateLocalLicenseApplication(_LocalAppID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeleteLocalDrivingLicenseApplication();
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CancelLocalDrivingLicenseApplication();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.WrittenTest);
        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueLocalLicenseFirstTime frm = new frmIssueLocalLicenseFirstTime(_LocalAppID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = clsLocalDrivingLicenseApplication.Find(_LocalAppID).GetActiveLicenseID();

            frmShowLocalLicenseInfo frm = new frmShowLocalLicenseInfo(LicenseID);
            frm.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPersonLicenseHistory frm = new frmListPersonLicenseHistory(clsLocalDrivingLicenseApplication.Find(_LocalAppID).ApplicantPersonID);
            frm.ShowDialog();
        }

    }
}

