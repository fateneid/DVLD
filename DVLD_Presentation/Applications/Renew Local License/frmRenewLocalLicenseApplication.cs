using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Renew_Local_License
{
    public partial class frmRenewLocalLicenseApplication : Form
    {
        private clsLicense _OldLicense, _NewLicense;

        public frmRenewLocalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLocalLicenseWithFilter1.FilterEnabled = true;
            llShowLicenseHistory.Enabled = false;
            llShowNewLicenseInfo.Enabled = false;
            btnRenewLocalLicense.Enabled = false;

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            rtxtNotes.Clear();
        }
        private void frmRenewLocalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLocalLicenseWithFilter1.FilterFocus();
        }

        private void ctrlDriverLocalLicenseWithFilter1_OnLicenseSelected(int OldLicenseID)
        {
            _OldLicense = null;
            _NewLicense = null;

            llShowLicenseHistory.Enabled = OldLicenseID != -1;
            llShowNewLicenseInfo.Enabled = false;
            btnRenewLocalLicense.Enabled = false;

            if (OldLicenseID == -1)
            {
                lblOldLicenseID.Text = "[????]";
                lblLicenseFees.Text = "[????]";
                lblExpirationDate.Text = "[????]";
                lblTotalFees.Text = "[????]";
                ctrlDriverLocalLicenseWithFilter1.FilterFocus();
                return;
            }

            _OldLicense = ctrlDriverLocalLicenseWithFilter1.SelectedLicense;

            lblOldLicenseID.Text = OldLicenseID.ToString();
            lblLicenseFees.Text = _OldLicense.LicenseClass.ClassFees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(_OldLicense.LicenseClass.DefaultValidityLength).ToShortDateString();
            lblTotalFees.Text = (Convert.ToDecimal(lblLicenseFees.Text) + Convert.ToDecimal(lblApplicationFees.Text)).ToString();

            if (!_OldLicense.IsActive)
            {
                MessageBox.Show("This license is not active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_OldLicense.ExpirationDate > DateTime.Now.AddDays(30))
            {
                DateTime RenewalDate = _OldLicense.ExpirationDate.AddDays(-30);
                MessageBox.Show("This license is not eligible for renewal yet." +
                                $"\nExpiration Date: {_OldLicense.ExpirationDate:d}" +
                                $"\nEarliest Renewal Date: {RenewalDate:d}\n" +
                                $"\nYou can renew this license starting from {RenewalDate:d}.",
                                "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnRenewLocalLicense.Enabled = true;
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLocalLicenseInfo frm = new frmShowLocalLicenseInfo(_NewLicense?.LicenseID?? -1);
            frm.ShowDialog();
        }
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListPersonLicenseHistory frm =
                new frmListPersonLicenseHistory(_OldLicense?.Driver?.PersonID ?? -1);
            frm.ShowDialog();
        }

        private void btnRenewLocalLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _NewLicense = _OldLicense.Renew(rtxtNotes.Text, clsGlobal.CurrentUser.UserID);
            if (_NewLicense != null)
            {
                lblRLApplicationID.Text = _NewLicense.ApplicationID.ToString();
                lblRenewedLicenseID.Text = _NewLicense.LicenseID.ToString();

                llShowLicenseHistory.Enabled = true;
                llShowNewLicenseInfo.Enabled = true;
                btnRenewLocalLicense.Enabled = false;
                ctrlDriverLocalLicenseWithFilter1.FilterEnabled = false;

                MessageBox.Show("License renewed successfully with ID = " + _NewLicense.LicenseID,
                     "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("License renewal failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
