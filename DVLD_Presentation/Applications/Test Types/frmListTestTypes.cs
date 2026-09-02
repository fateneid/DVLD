using DVLD_Business;
using DVLD_Presentation.Applications.Application_Types;
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
    public partial class frmListTestTypes : Form
    {

        private DataTable _DataSource;

        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _ReloadData();
            _SetupGridColumns();
            lblRecordsCount.Text = _DataSource.Rows.Count.ToString();
        }

        private void _SetupGridColumns()
        {
            dgvAllTestTypes.Columns["TestTypeID"].HeaderText = "ID";
            dgvAllTestTypes.Columns["TestTypeID"].DisplayIndex = 0;
            dgvAllTestTypes.Columns["TestTypeID"].Width = 90;

            dgvAllTestTypes.Columns["TestTypeTitle"].HeaderText = "Title";
            dgvAllTestTypes.Columns["TestTypeTitle"].DisplayIndex = 1;
            dgvAllTestTypes.Columns["TestTypeTitle"].Width = 200;

            dgvAllTestTypes.Columns["TestTypeDescription"].HeaderText = "Description";
            dgvAllTestTypes.Columns["TestTypeDescription"].DisplayIndex = 2;
            dgvAllTestTypes.Columns["TestTypeDescription"].Width = 520;

            dgvAllTestTypes.Columns["TestTypeFees"].HeaderText = "Fees";
            dgvAllTestTypes.Columns["TestTypeFees"].DisplayIndex = 3;
            dgvAllTestTypes.Columns["TestTypeFees"].Width = 110;
        }

        private void _ReloadData()
        {
            _DataSource = clsTestType.GetAllTestTypes();
            dgvAllTestTypes.DataSource = _DataSource;
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((clsTestType.enTestType)dgvAllTestTypes.CurrentRow.Cells["TestTypeID"].Value);

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
