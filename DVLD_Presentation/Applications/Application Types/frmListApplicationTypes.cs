using DVLD_Business;
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

namespace DVLD_Presentation.Applications.Application_Types
{
    public partial class frmListApplicationTypes : Form
    {

        private DataTable _DataSource;

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _ReloadData();
            _SetupGridColumns();
            lblRecordsCount.Text = _DataSource.Rows.Count.ToString();
        }

        private void _SetupGridColumns()
        {
            dgvAllApplicationTypes.Columns["ApplicationTypeID"].HeaderText = "ID";
            dgvAllApplicationTypes.Columns["ApplicationTypeID"].DisplayIndex = 0;
            dgvAllApplicationTypes.Columns["ApplicationTypeID"].Width = 130;

            dgvAllApplicationTypes.Columns["ApplicationTypeTitle"].HeaderText = "Title";
            dgvAllApplicationTypes.Columns["ApplicationTypeTitle"].DisplayIndex = 1;
            dgvAllApplicationTypes.Columns["ApplicationTypeTitle"].Width = 510;

            dgvAllApplicationTypes.Columns["ApplicationFees"].HeaderText = "Fees";
            dgvAllApplicationTypes.Columns["ApplicationFees"].DisplayIndex = 2;
            dgvAllApplicationTypes.Columns["ApplicationFees"].Width = 170;
        }

        private void _ReloadData()
        {
            _DataSource = clsApplicationType.GetAllApplicationTypes();
            dgvAllApplicationTypes.DataSource = _DataSource;
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dgvAllApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
