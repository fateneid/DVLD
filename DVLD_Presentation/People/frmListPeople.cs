using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.People;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmListPeople : Form
    {
        private DataView _DataSource;
        private string _CurrentFilter = "";

        public frmListPeople()
        {
            InitializeComponent();

            _DataSource = clsPerson.GetAllPeople().DefaultView;
            dgvAllPeople.DataSource = _DataSource;
            _SetupGridColumns();
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _ApplyFilter();
        }

        private void _ReloadData()
        {
            _DataSource = clsPerson.GetAllPeople().DefaultView;
            dgvAllPeople.DataSource = _DataSource;
            _ApplyFilter();
        }

        private void _ApplyFilter()
        {
            _DataSource.RowFilter = _CurrentFilter;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }

        private void _SetupGridColumns()
        {

            dgvAllPeople.Columns["Gender"].Visible = false;
            dgvAllPeople.Columns["NationalityCountryID"].Visible = false;
            dgvAllPeople.Columns["Address"].Visible = false;
            dgvAllPeople.Columns["ImagePath"].Visible = false;

            dgvAllPeople.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllPeople.Columns["NationalNo"].HeaderText = "National No.";
            dgvAllPeople.Columns["FirstName"].HeaderText = "First Name";
            dgvAllPeople.Columns["SecondName"].HeaderText = "Second Name";
            dgvAllPeople.Columns["ThirdName"].HeaderText = "Third Name";
            dgvAllPeople.Columns["LastName"].HeaderText = "Last Name";
            dgvAllPeople.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            dgvAllPeople.Columns["GenderCaption"].HeaderText = "Gender";
            dgvAllPeople.Columns["CountryName"].HeaderText = "Nationality";

            dgvAllPeople.Columns["PersonID"].DisplayIndex = 0;
            dgvAllPeople.Columns["NationalNo"].DisplayIndex = 1;
            dgvAllPeople.Columns["FirstName"].DisplayIndex = 2;
            dgvAllPeople.Columns["SecondName"].DisplayIndex = 3;
            dgvAllPeople.Columns["ThirdName"].DisplayIndex = 4;
            dgvAllPeople.Columns["LastName"].DisplayIndex = 5;
            dgvAllPeople.Columns["GenderCaption"].DisplayIndex = 6;
            dgvAllPeople.Columns["DateOfBirth"].DisplayIndex = 7;
            dgvAllPeople.Columns["CountryName"].DisplayIndex = 8;
            dgvAllPeople.Columns["Phone"].DisplayIndex = 9;
            dgvAllPeople.Columns["Email"].DisplayIndex = 10;

        }

        private void _ClearFilter() 
        {
            _CurrentFilter = "";
            txtSearch.Text = "";
            cbSearchGender.SelectedIndex = 0;
            _ApplyFilter();
        }

        private void _ShowPerson(int PersonID)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
            _ReloadData();
        }

        private void _DeletePerson(int PersonID) 
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + PersonID + "]?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (!clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person deletion failed because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Person deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ReloadData();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNone = cbFilterBy.Text == "None";
            bool isGender = cbFilterBy.Text == "Gender";

            txtSearch.Visible = !isNone && !isGender;
            cbSearchGender.Visible = isGender;

            _ClearFilter();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                _ClearFilter();
                return;
            }

            string colName = "";
            switch (cbFilterBy.Text) 
            {
                case "Person ID": 
                    colName = "PersonID";
                    break;
                case "National No.":
                    colName = "NationalNo";
                    break;
                case "First Name":
                    colName = "FirstName";
                    break;
                case "Second Name":
                    colName = "SecondName";
                    break;
                case "Third Name":
                    colName = "ThirdName";
                    break;
                case "Last Name":
                    colName = "LastName";
                    break;
                case "Nationality":
                    colName = "CountryName";
                    break;
                case "Phone":
                    colName = "Phone";
                    break;
                case "Email":
                    colName = "Email";
                    break;
            }

            if (colName == "PersonID") 
            {
                _CurrentFilter = $"{colName} = {txtSearch.Text}";
            }
            else
            {
                _CurrentFilter = $"{colName} LIKE '{txtSearch.Text}%'";
            }

            _ApplyFilter();

        }
        
        private void cbSearchGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchGender.SelectedIndex == 0)
            {
                _ClearFilter();
            }
            else
            {
                _CurrentFilter = $"GenderCaption = '{cbSearchGender.Text}'";
                _ApplyFilter();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEdit frm = new frmAddEdit();
            frm.ShowDialog();
            _ReloadData();
        }

        private void dgvAllPeople_DoubleClick(object sender, EventArgs e)
        {
            _ShowPerson((int)dgvAllPeople.CurrentRow.Cells["PersonID"].Value);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPerson((int)dgvAllPeople.CurrentRow.Cells["PersonID"].Value);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEdit frm = new frmAddEdit();
            frm.ShowDialog();
            _ReloadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEdit frm = new frmAddEdit((int)dgvAllPeople.CurrentRow.Cells["PersonID"].Value);
            frm.ShowDialog();
            _ReloadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeletePerson((int)dgvAllPeople.CurrentRow.Cells["PersonID"].Value);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
