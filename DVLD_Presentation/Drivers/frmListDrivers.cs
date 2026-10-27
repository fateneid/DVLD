using DVLD_Business;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.People;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Presentation.Drivers
{
    public partial class frmListDrivers : Form
    {
        private DataView _DataSource = clsDriver.GetAll().DefaultView;
        private int _PersonID
        {
            get
            {
                return dgvAllDrivers.CurrentRow == null ? -1 :
                    (int)dgvAllDrivers.CurrentRow.Cells["PersonID"].Value;
            }
        }

        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            dgvAllDrivers.DataSource = _DataSource;
            _SetupGridColumns();
            lblRecordsCount.Text = _DataSource.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
        }

        private void _SetupGridColumns()
        {
            dgvAllDrivers.Columns["DriverID"].HeaderText = "Driver ID";
            dgvAllDrivers.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllDrivers.Columns["NationalNo"].HeaderText = "National No.";
            dgvAllDrivers.Columns["FullName"].HeaderText = "Full Name";
            dgvAllDrivers.Columns["CreatedDate"].HeaderText = "Date";
            dgvAllDrivers.Columns["ActiveLicenses"].HeaderText = "Active Licenses";

            dgvAllDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllDrivers.Columns["DriverID"].FillWeight = 15;
            dgvAllDrivers.Columns["PersonID"].FillWeight = 15;
            dgvAllDrivers.Columns["NationalNo"].FillWeight = 15;
            dgvAllDrivers.Columns["FullName"].FillWeight = 30;
            dgvAllDrivers.Columns["CreatedDate"].FillWeight = 20;
            dgvAllDrivers.Columns["ActiveLicenses"].FillWeight = 15;
        }

        private void _ApplyFilter(string filter)
        {
            _DataSource.RowFilter = filter;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }
        private void _ReloadData()
        {
            _DataSource = clsDriver.GetAll().DefaultView;
            dgvAllDrivers.DataSource = _DataSource;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }

        private void _ShowPerson(int PersonID)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);

            frm.ShowDialog();
            _ReloadData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNone = cbFilterBy.Text == "None";
            txtSearch.Visible = !isNone;
            txtSearch.Clear();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _ApplyFilter("");
                return;
            }

            string colName = "";
            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    colName = "DriverID";
                    break;
                case "Person ID":
                    colName = "PersonID";
                    break;
                case "National No.":
                    colName = "NationalNo";
                    break;
                case "Full Name":
                    colName = "FullName";
                    break;
                default:
                    return;
            }

            if (colName == "DriverID" || colName == "PersonID")
            {
                _ApplyFilter($"{colName} = {txtSearch.Text}");
            }
            else
            {
                _ApplyFilter($"{colName} LIKE '{txtSearch.Text}%'");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAllDrivers_DoubleClick(object sender, EventArgs e)
        {
            _ShowPerson(_PersonID);
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPerson(_PersonID);
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPersonLicenseHistory frm = new frmListPersonLicenseHistory(_PersonID);
            frm.ShowDialog();
        }

    }
}
