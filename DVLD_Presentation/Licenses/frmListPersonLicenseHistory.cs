using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses
{
    public partial class frmListPersonLicenseHistory : Form
    {
        public frmListPersonLicenseHistory()
        {
            InitializeComponent();

            ctrlPersonCardWithFilter1.FilterFocus();
            ctrlPersonCardWithFilter1.FilterEnabled = true;
        }
        public frmListPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();

            ctrlPersonCardWithFilter1.LoadInfo(PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            if (PersonID != -1)
                ctrlPersonCardWithFilter1.FilterFocus();
            _LoadDriverLicenses(PersonID);
        }

        private void _LoadLocalLicenses(int DriverID)
        {
            dgvLocalLicenses.DataSource = clsLicense.GetDriverLicenses(DriverID);
            lblLocalRecordsCount.Text = dgvLocalLicenses.Rows.Count.ToString();

            dgvLocalLicenses.Columns["LicenseID"].HeaderText = "License ID";
            dgvLocalLicenses.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvLocalLicenses.Columns["ClassName"].HeaderText = "Class Name";
            dgvLocalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvLocalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvLocalLicenses.Columns["IsActive"].HeaderText = "Is Active";

            dgvLocalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocalLicenses.Columns["LicenseID"].FillWeight = 15;
            dgvLocalLicenses.Columns["ApplicationID"].FillWeight = 15;
            dgvLocalLicenses.Columns["ClassName"].FillWeight = 25;
            dgvLocalLicenses.Columns["IssueDate"].FillWeight = 20;
            dgvLocalLicenses.Columns["ExpirationDate"].FillWeight = 20;
            dgvLocalLicenses.Columns["IsActive"].FillWeight = 10;

        }
        private void _LoadInternationalLicenses(int DriverID)
        {
            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetDriverLicenses(DriverID);
            lblInternationalRecordsCount.Text = dgvInternationalLicenses.Rows.Count.ToString();

            dgvInternationalLicenses.Columns["InternationalLicenseID"].HeaderText = "Int.License ID";
            dgvInternationalLicenses.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L.License ID";
            dgvInternationalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvInternationalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvInternationalLicenses.Columns["IsActive"].HeaderText = "Is Active";

            dgvInternationalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInternationalLicenses.Columns["InternationalLicenseID"].FillWeight = 15;
            dgvInternationalLicenses.Columns["ApplicationID"].FillWeight = 15;
            dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].FillWeight = 15;
            dgvInternationalLicenses.Columns["IssueDate"].FillWeight = 25;
            dgvInternationalLicenses.Columns["ExpirationDate"].FillWeight = 25;
            dgvInternationalLicenses.Columns["IsActive"].FillWeight = 15;

        }
        private void _LoadDriverLicenses(int PersonID)
        {
            int DriverID = clsDriver.FindByPersonID(PersonID)?.DriverID ?? -1;
            _LoadLocalLicenses(DriverID);
            _LoadInternationalLicenses(DriverID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLocalLicenses_DoubleClick(object sender, EventArgs e)
        {
            frmShowLocalLicenseInfo frm = new frmShowLocalLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells["LicenseID"].Value);
            frm.ShowDialog();
        }
        private void dgvInternationalLicenses_DoubleClick(object sender, EventArgs e)
        {

        }
        private void showLocalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalLicenseInfo frm = new frmShowLocalLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells["LicenseID"].Value);
            frm.ShowDialog();
        }
        private void showInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
