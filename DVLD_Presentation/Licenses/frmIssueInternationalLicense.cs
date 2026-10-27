using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses
{
    public partial class frmIssueInternationalLicense : Form
    {
        private int _InternationalLicenseID;
        private clsInternationalLicense _InternationalLicense;

        public frmIssueInternationalLicense()
        {
            InitializeComponent();

            ctrlDriverLocalLicenseWithFilter1.FilterFocus();
            ctrlDriverLocalLicenseWithFilter1.FilterEnabled = true;
        }
        public frmIssueInternationalLicense(int LocalLicenseID)
        {
            InitializeComponent();

            ctrlDriverLocalLicenseWithFilter1.LoadInfo(LocalLicenseID);
            ctrlDriverLocalLicenseWithFilter1.FilterEnabled = false;
        }

        private void frmIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
         
        private void ctrlDriverLocalLicenseWithFilter1_OnLicenseSelected(int LicenseID)
        {
            llShowLicenseHistory.Enabled = LicenseID != -1;
            llShowLicenseInfo.Enabled = false;
            btnIssueInternationalLicense.Enabled = false;

            if (LicenseID == -1)
            {
                ctrlDriverLocalLicenseWithFilter1.FilterFocus();
                return;
            }

            lblLocalLicenseID.Text = LicenseID.ToString();

            if (ctrlDriverLocalLicenseWithFilter1.SelectedLicense.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!clsInternationalLicense.CanIssueInternationalLicense(ctrlDriverLocalLicenseWithFilter1.SelectedLicense))
            {
                MessageBox.Show("Selected License is not valid/active, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _InternationalLicenseID = clsInternationalLicense.GetActiveByLocalLicenseID(LicenseID);
            if (_InternationalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + _InternationalLicenseID,
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = true;
                return;
            }

            btnIssueInternationalLicense.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListPersonLicenseHistory frm =
                new frmListPersonLicenseHistory(ctrlDriverLocalLicenseWithFilter1.SelectedLicense.Driver.PersonID);
            frm.ShowDialog();
        }

        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _InternationalLicense = clsInternationalLicense.IssueInternationalLicense(
                ctrlDriverLocalLicenseWithFilter1.LicenseID, clsGlobal.CurrentUser.UserID);
            if (_InternationalLicense != null )
            {
                _InternationalLicenseID = _InternationalLicense.InternationalLicenseID;

                lblILApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                lblILicense.Text = _InternationalLicenseID.ToString();

                llShowLicenseHistory.Enabled = true;
                llShowLicenseInfo.Enabled = true;
                btnIssueInternationalLicense.Enabled = false;
                ctrlDriverLocalLicenseWithFilter1.FilterEnabled = false;

                MessageBox.Show("International License Issued Successfully with ID = " + _InternationalLicenseID,
                     "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("International License Was not Issued!",
                 "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
