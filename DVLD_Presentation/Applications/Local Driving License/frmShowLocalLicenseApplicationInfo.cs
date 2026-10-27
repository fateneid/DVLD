using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Local_Driving_License
{
    public partial class frmShowLocalLicenseApplicationInfo : Form
    {

        public frmShowLocalLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            ctrlLocalDrivingLicenseApplicationCard1.LoadInfo(LocalDrivingLicenseApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
