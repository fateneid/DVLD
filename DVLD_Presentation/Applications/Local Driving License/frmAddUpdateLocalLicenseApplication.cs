using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalLicenseApplication : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalLicenseApplication()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        public frmAddUpdateLocalLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _FillLicenseClasses();

            switch (_Mode)
            {
                case enMode.AddNew:
                    _AddNew();
                    break;
                case enMode.Update:
                    _Update();
                    break;
            }
        }
        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void _AddNew()
        {
            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

            lblModeCaption.Text = "New Local Driving License Application";
            this.Text = "New Local Driving License Application";

            lblDLApplicationID.Text = "????";
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = 2;
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            btnNext.Enabled = false;
            btnSave.Enabled = false;
            ctrlPersonCardWithFilter1.FilterEnabled = true;

        }
        private void _Update()
        {
            lblModeCaption.Text = "Update Local Driving License Application";
            this.Text = "Update Local Driving License Application";

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID, "Local Driving License Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);

            lblDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedItem = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.User.UserName;

            btnNext.Enabled = true;
            btnSave.Enabled = true;
            ctrlPersonCardWithFilter1.FilterEnabled = false;

        }

        private void _FillLicenseClasses()
        {
            DataTable dt = clsLicenseClass.GetAll();

            foreach (DataRow dr in dt.Rows)
            {
                cbLicenseClass.Items.Add(dr["ClassName"]);
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            btnNext.Enabled = PersonID != -1;
            if (PersonID == -1)
            {
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void tcAddUpdateLocalDrivingLicesnseApplication_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpApplicationInfo && ctrlPersonCardWithFilter1.PersonID == -1)
            {
                e.Cancel = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcAddUpdateLocalDrivingLicesnseApplication.SelectedTab = tpApplicationInfo;
            btnSave.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;
            int PersonID = ctrlPersonCardWithFilter1.PersonID;
           
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.DoesPersonHaveActiveApplicationForThisClass(PersonID, LicenseClassID))
            {
                MessageBox.Show(
                    "The selected person already has an active application for this license class. Please select a different license class.",
                    "Application Already Exists",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }     
            if(clsLicense.HasActiveByPersonIDAndClassID(PersonID, LicenseClassID))
            {
                MessageBox.Show(
                    "Person already has an active license with the same applied driving class, Choose diffrent driving class",
                    "Not allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }
            if (!clsLocalDrivingLicenseApplication.IsPersonEligibleForLicenseClass(PersonID, LicenseClassID))
            {
                MessageBox.Show(
                    "The applicant does not meet the minimum age requirement for this license class.",
                    "Not Eligible",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLicenseClass.Focus();
                return;
            }

            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            _LocalDrivingLicenseApplication.ApplicantPersonID = PersonID;
            if (_Mode == enMode.AddNew)
            {
                _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }

            if (_LocalDrivingLicenseApplication.Save())
            {
                lblDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
