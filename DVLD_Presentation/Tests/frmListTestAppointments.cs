using DVLD_Business;
using DVLD_Presentation.Properties;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private int _TestAppointmentID
        {
            get
            {
                return dgvAllTestAppointments.CurrentRow == null ? -1 :
                    (int)dgvAllTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value;
            }
        }
        private bool _TestResultSaved = false;
        private clsTestType.enTestType _TestTypeID;
        private DataTable _DataSource;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationCard1.LoadInfo(_LocalDrivingLicenseApplicationID);
            _LoadTestTypeImageAndTitle();
            _ReloadData();
            _SetupGridColumns();
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID) 
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.Vision_512;
                        lblTitle.Text = "Vision Test Appointments";
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        pbTestType.Image = Resources.Written_Test_512;
                        lblTitle.Text = "Written Test Appointments";
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.driving_test_512;
                        lblTitle.Text = "Street Test Appointments";
                        break;
                    }
            }
            this.Text = lblTitle.Text;
        }
        private void _SetupGridColumns()
        {
            dgvAllTestAppointments.Columns["TestAppointmentID"].HeaderText = "Appointment ID";
            dgvAllTestAppointments.Columns["TestAppointmentID"].DisplayIndex = 0;

            dgvAllTestAppointments.Columns["AppointmentDate"].HeaderText = "Appointment Date";
            dgvAllTestAppointments.Columns["AppointmentDate"].DisplayIndex = 1;

            dgvAllTestAppointments.Columns["PaidFees"].HeaderText = "Paid Fees";
            dgvAllTestAppointments.Columns["PaidFees"].DisplayIndex = 2;

            dgvAllTestAppointments.Columns["IsLocked"].HeaderText = "Is Locked";
            dgvAllTestAppointments.Columns["IsLocked"].DisplayIndex = 3;

            dgvAllTestAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAllTestAppointments.Columns["TestAppointmentID"].FillWeight = 25;
            dgvAllTestAppointments.Columns["AppointmentDate"].FillWeight = 30;
            dgvAllTestAppointments.Columns["PaidFees"].FillWeight = 25;
            dgvAllTestAppointments.Columns["IsLocked"].FillWeight = 20;

        }

        private void _ReloadData()
        {
            _DataSource = clsTestAppointment.GetAllByLAppIDAndTestTypeID(_LocalDrivingLicenseApplicationID, _TestTypeID);
            dgvAllTestAppointments.DataSource = _DataSource;
            lblRecordsCount.Text = _DataSource.Rows.Count.ToString();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicenseApplication.DoesPassTestType(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmsTestAppointment_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            takeTestToolStripMenuItem.Enabled = !(bool)dgvAllTestAppointments.CurrentRow.Cells["IsLocked"].Value;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, _TestAppointmentID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest(_TestAppointmentID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _TestResultSaved = true;

                ctrlLocalDrivingLicenseApplicationCard1.LoadInfo(_LocalDrivingLicenseApplicationID);
                _ReloadData();
            }
        }

        private void frmListTestAppointments_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_TestResultSaved)
                this.DialogResult = DialogResult.OK;
        }

    }
}