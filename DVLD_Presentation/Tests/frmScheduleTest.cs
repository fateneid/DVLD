using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Properties;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests
{
    public partial class frmScheduleTest : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        public enum enCreationMode { FirstTime = 0, RetakeTest = 1 };
        private enCreationMode _CreationMode;
        private int _LocalDrivingLicenseApplicationID = -1, _TestAppointmentID = -1;
        private clsTestType.enTestType _TestTypeID;
        private clsTestAppointment _TestAppointment;
        private clsLocalDrivingLicenseApplication _LocalApp;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();

            if (TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            lblUserMessage.Visible = false;
            _LoadTestTypeImageAndTitle();

            if (!_LoadLocalAppInfo())
            {
                this.Close();
                return;
            }

            switch (_Mode)
            {
                case enMode.AddNew:
                    _AddNew();
                    break;
                case enMode.Update:
                    _Update();
                    break;
            }

            if (!_HandlePreviousTestConstraint() || !_HandleActiveTestAppointmentConstraint())
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Left = (gbScheduleTest.ClientSize.Width - lblUserMessage.Width) / 2;
                btnSave.Enabled = false;
                dtDate.Enabled = false;
                return;
            }
        }
        private void frmScheduleTest_Activated(object sender, EventArgs e)
        {
            dtDate.Focus();
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.Vision_512;
                        gbScheduleTest.Text = "Vision Test";
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        pbTestType.Image = Resources.Written_Test_512;
                        gbScheduleTest.Text = "Written Test";
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.driving_test_512;
                        gbScheduleTest.Text = "Street Test";
                        break;
                    }
            }
        }
        private bool _LoadLocalAppInfo()
        {
            _LocalApp = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if (_LocalApp == null)
            {
                MessageBox.Show("No Local Application with ID = " + _LocalDrivingLicenseApplicationID, "Local Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            lblLocalAppID.Text = _LocalApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LocalApp.LicenseClass.ClassName;
            lblFullName.Text = _LocalApp.Person.FullName;
            lblTrial.Text = _LocalApp.TotalTrialsPerTest(_TestTypeID).ToString();

            if (!_LocalApp.HasTakenTestType(_TestTypeID))
                _CreationMode = enCreationMode.FirstTime;
            else
            {
                _CreationMode = enCreationMode.RetakeTest;
                lblTitle.Text = "Schedule Retake Test";
                lblTitle.Left = (gbScheduleTest.ClientSize.Width - lblTitle.Width) / 2;
            }

            return true;
        }
        private void _LoadDefaultRetakeTestInfo()
        {
            gbRetakeTestInfo.Enabled = false;

            lblRetakeAppID.Text = "N/A";
            lblRetakeAppFees.Text = "0";
            lblTotalFees.Text = lblFees.Text;
        }

        private void _AddNew()
        {
            _TestAppointment = new clsTestAppointment();
            decimal Fees = clsTestType.Find(_TestTypeID).TestTypeFees;
            dtDate.MinDate = DateTime.Now;
            dtDate.Value = dtDate.MinDate;
            lblFees.Text = Fees.ToString();

            if (_CreationMode == enCreationMode.FirstTime)
            {
                _LoadDefaultRetakeTestInfo();
            }
            else
            {
                decimal RetakeAppFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees;

                lblRetakeAppID.Text = "N/A";
                lblRetakeAppFees.Text = RetakeAppFees.ToString();
                lblTotalFees.Text = (RetakeAppFees + Fees).ToString();
            }
        }
        private void _Update()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("No Test Appointment with ID = " + _TestAppointmentID, "Test Appointment Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) > 0)
                dtDate.MinDate = _TestAppointment.AppointmentDate;
            else
                dtDate.MinDate = DateTime.Now;
            dtDate.Value = _TestAppointment.AppointmentDate;
            lblFees.Text = _TestAppointment.PaidFees.ToString();

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                _LoadDefaultRetakeTestInfo();
            }
            else
            {
                lblRetakeAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplication.PaidFees.ToString();
                lblTotalFees.Text = (_TestAppointment.RetakeTestApplication.PaidFees + _TestAppointment.PaidFees).ToString();
            }

            if (_TestAppointment.IsLocked) 
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment is locked.";
                dtDate.Enabled = false;
                btnSave.Enabled = false;
            }

        }

        private bool _HandlePreviousTestConstraint() 
        {
            if (_TestTypeID == clsTestType.enTestType.WrittenTest &&
                !clsLocalDrivingLicenseApplication.DoesPassTestType(_LocalDrivingLicenseApplicationID, clsTestType.enTestType.VisionTest))
            {
                lblUserMessage.Text = "The Vision Test must be passed before scheduling the Written Test.";
                return false;
            }
            if (_TestTypeID == clsTestType.enTestType.StreetTest &&
                !clsLocalDrivingLicenseApplication.DoesPassTestType(_LocalDrivingLicenseApplicationID, clsTestType.enTestType.WrittenTest))
            {
                lblUserMessage.Text = "The Written Test must be passed before scheduling the Street Test.";
                return false;
            }
            return true;
        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew &&
               clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                lblUserMessage.Text = "An active appointment already exists for this test.";
                return false;
            }
            return true;
        }
        private bool _CreateRetakeTestApp()
        {
            clsApplication RetakeTestApp = new clsApplication();

            RetakeTestApp.ApplicationTypeID = clsApplication.enApplicationType.RetakeTest;
            RetakeTestApp.ApplicantPersonID = _LocalApp.ApplicantPersonID;
            RetakeTestApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            RetakeTestApp.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees;
            RetakeTestApp.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!RetakeTestApp.Save())
            {
                MessageBox.Show("Failed to Create application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _TestAppointment.RetakeTestApplicationID = RetakeTestApp.ApplicationID;

            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (_CreationMode == enCreationMode.RetakeTest && !_CreateRetakeTestApp())
                    return;

                _TestAppointment.TestTypeID = _TestTypeID;
                _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
                _TestAppointment.PaidFees = clsTestType.Find(_TestTypeID).TestTypeFees;
                _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }

            _TestAppointment.AppointmentDate = dtDate.Value;

            if (_TestAppointment.Save())
            {
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
