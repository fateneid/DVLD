using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Properties;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointment;
        private clsTest _Test;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadInfo();
            _LoadTestTypeImageAndTitle();

            rbPass.Focus();
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestAppointment.TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.Vision_512;
                        gbTakeTest.Text = "Vision Test";
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        pbTestType.Image = Resources.Written_Test_512;
                        gbTakeTest.Text = "Written Test";
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.driving_test_512;
                        gbTakeTest.Text = "Street Test";
                        break;
                    }
            }
        }
        private void _LoadInfo()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("No Local Application with ID = " + _TestAppointmentID, "Local Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            if (_TestAppointment.AppointmentDate != DateTime.Today) 
            {
                MessageBox.Show("The test can only be taken on its scheduled date.", "Invalid Test Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            lblLocalAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _TestAppointment.LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblFullName.Text = _TestAppointment.LocalDrivingLicenseApplication.Person.FullName;
            lblTrial.Text = _TestAppointment.LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestAppointment.TestTypeID).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = "Not Taken Yet";

            rbPass.Checked = true;
            rtxtNotes.Text = "";

            btnSave.Enabled = !_TestAppointment.IsLocked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail result after you save?.",
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _Test = new clsTest();
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = rtxtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {                
                lblTestID.Text = _Test.TestID.ToString();

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
