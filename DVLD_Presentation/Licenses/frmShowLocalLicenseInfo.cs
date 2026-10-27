using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses
{
    public partial class frmShowLocalLicenseInfo : Form
    {
        private int _LicenseID = -1;
        public frmShowLocalLicenseInfo(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }

        private void frmShowLocalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (!ctrlDriverLicense1.LoadInfo(_LicenseID))
            {
                this.Close();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
