using DVLD_Presentation.Applications.Application_Types;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.People;
using DVLD_Presentation.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmMain : Form
    {

        public bool IsLoggedOut { get; private set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.WorkingArea;
        }

        // Applications
        // Driving Licenses Services
        // New Driving License
        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //
        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Manage Applications
        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Detain Licenses
        private void ManageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Manage Application Types
        private void manageApplicaitonTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }
        // Manage Test Types
        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // People
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }

        // Users
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();
        }

        // Drivers
        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Account Settings
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            IsLoggedOut = true;
            this.Close();
        }

    }
}
