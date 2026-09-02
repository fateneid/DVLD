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

namespace DVLD_Presentation.Applications.Test_Types
{
    public partial class frmUpdateTestType : Form
    {

        private clsTestType.enTestType _TestTypeID;
        private clsTestType _TestType;

        public frmUpdateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("Test Type does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTestTypeID.Text = ((int)_TestTypeID).ToString();
            txtTestTypeTitle.Text = _TestType.TestTypeTitle;
            rtxtTestTypeDescription.Text = _TestType.TestTypeDescription;
            txtTestTypeFees.Text = _TestType.TestTypeFees.ToString();

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

        private void txtTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtTestTypeTitle, e)) return;
        }
        private void txtTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateRequired(txtTestTypeFees, e)) return;

            if (!clsValidation.IsDecimal(txtTestTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Fees format is wrong!");
            }
            else errorProvider1.SetError(txtTestTypeFees, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error(s)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.TestTypeTitle = txtTestTypeTitle.Text.Trim();
            _TestType.TestTypeDescription = rtxtTestTypeDescription.Text.Trim();
            _TestType.TestTypeFees = decimal.Parse(txtTestTypeFees.Text.Trim());

            if (_TestType.Save())
            {
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
