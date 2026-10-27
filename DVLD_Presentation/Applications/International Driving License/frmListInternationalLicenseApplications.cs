using DVLD_Business;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.People;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.International_Driving_License
{
    public partial class frmListInternationalLicenseApplications : Form
    {
        private DataView _DataSource = clsInternationalLicense.GetAll().DefaultView;
        private int _InternationalLicenseID
        {
            get
            {
                return dgvAllInternationalLicenseApplications.CurrentRow == null ? -1 :
                    (int)dgvAllInternationalLicenseApplications.CurrentRow.Cells["InternationalLicenseID"].Value;
            }
        }

        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            dgvAllInternationalLicenseApplications.DataSource = _DataSource;
            _SetupGridColumns();
            lblRecordsCount.Text = _DataSource.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
        }

        private void _SetupGridColumns()
        {
            dgvAllInternationalLicenseApplications.Columns["InternationalLicenseID"].HeaderText = "Int.License ID";
            dgvAllInternationalLicenseApplications.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvAllInternationalLicenseApplications.Columns["DriverID"].HeaderText = "Driver ID";
            dgvAllInternationalLicenseApplications.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L.License ID";
            dgvAllInternationalLicenseApplications.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvAllInternationalLicenseApplications.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvAllInternationalLicenseApplications.Columns["IsActive"].HeaderText = "Is Active";

            dgvAllInternationalLicenseApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllInternationalLicenseApplications.Columns["InternationalLicenseID"].FillWeight = 15;
            dgvAllInternationalLicenseApplications.Columns["ApplicationID"].FillWeight = 15;
            dgvAllInternationalLicenseApplications.Columns["DriverID"].FillWeight = 15;
            dgvAllInternationalLicenseApplications.Columns["IssuedUsingLocalLicenseID"].FillWeight = 15;
            dgvAllInternationalLicenseApplications.Columns["IssueDate"].FillWeight = 20;
            dgvAllInternationalLicenseApplications.Columns["ExpirationDate"].FillWeight = 20;
            dgvAllInternationalLicenseApplications.Columns["IsActive"].FillWeight = 12;
        }

        private void _ApplyFilter(string filter)
        {
            _DataSource.RowFilter = filter;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }
        private void _ReloadData()
        {
            _DataSource = clsInternationalLicense.GetAll().DefaultView;
            dgvAllInternationalLicenseApplications.DataSource = _DataSource;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNone = cbFilterBy.Text == "None";
            bool isActive = cbFilterBy.Text == "Is Active";

            txtSearch.Visible = !isNone && !isActive;
            cbSearchIsActive.Visible = isActive;

            cbSearchIsActive.SelectedIndex = 0;
            txtSearch.Clear();
        }
        private void cbSearchIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchIsActive.SelectedIndex == 0)
            {
                _ApplyFilter("");
            }
            else
            {
                _ApplyFilter($"IsActive = {cbSearchIsActive.Text == "Yes"}");
            }
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
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
                case "Int.License ID":
                    colName = "InternationalLicenseID";
                    break;
                case "Application ID":
                    colName = "ApplicationID";
                    break;
                case "Driver ID":
                    colName = "DriverID";
                    break;
                case "L.License ID":
                    colName = "IssuedUsingLocalLicenseID";
                    break;
                default:
                    return;
            }

            _ApplyFilter($"{colName} = {txtSearch.Text}");

        }

        private void btnAddNewInternationalLicenseApplication_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense frm = new frmIssueInternationalLicense();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsInternationalLicense.Find(_InternationalLicenseID).Driver.PersonID;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsInternationalLicense.Find(_InternationalLicenseID).Driver.PersonID;

            frmListPersonLicenseHistory frm = new frmListPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

    }

}
