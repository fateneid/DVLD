using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses.Controls
{
    public partial class ctrlDriverLocalLicenseWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
            get
            {
                return _FilterEnabled;
            }
        }
        public int LicenseID
        {
            get { return ctrlDriverLocalLicense1.LicenseID; }
        }
        public clsLicense SelectedLicense
        {
            get { return ctrlDriverLocalLicense1.SelectedLicense; }
        }

        public ctrlDriverLocalLicenseWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlDriverLocalLicenseWithFilter_Load(object sender, EventArgs e)
        {
            txtFindByValue.Focus();
        }

        private void txtFindByValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFindLicense.PerformClick();
            }

            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtFindByValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFindByValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFindByValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFindByValue, "");
            }
        }

        private void _FindNow()
        {
            ctrlDriverLocalLicense1.LoadInfo(int.Parse(txtFindByValue.Text.Trim()));

            if (FilterEnabled)
            {
                OnLicenseSelected?.Invoke(ctrlDriverLocalLicense1.LicenseID);
            }
        }

        public void FilterFocus()
        {
            txtFindByValue.Focus();
        }

        public void LoadInfo(int LicenseID)
        {
            txtFindByValue.Text = LicenseID.ToString();
            _FindNow();
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("This field can not be blank!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();
        }

    }
}
