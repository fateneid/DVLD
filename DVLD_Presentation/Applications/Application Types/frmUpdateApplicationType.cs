using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Application_Types
{
    public partial class frmUpdateApplicationType : Form
    {

        private int _ApplicationTypeID;
        private clsApplicationType _ApplicationType;

        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if(_ApplicationType == null)
            {
                MessageBox.Show("Application Type does not exist","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtApplicationFees.Text = _ApplicationType.ApplicationFees.ToString();

        }

        private bool _ValidateRequired(Control control, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(control, "This field is required!");
                return false;
            }
            errorProvider1.SetError(control, "");
            return true;
        }

        private void txtApplicationTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtApplicationTypeTitle, e)) return;
        }
        private void txtApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtApplicationFees, e)) return;

            if (!clsValidation.IsDecimal(txtApplicationFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "Fees format is wrong!");
            }
            else errorProvider1.SetError(txtApplicationFees, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error(s)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.ApplicationTypeTitle = txtApplicationTypeTitle.Text.Trim();
            _ApplicationType.ApplicationFees = decimal.Parse(txtApplicationFees.Text.Trim());

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
