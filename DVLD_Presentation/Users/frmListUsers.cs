using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Users
{
    public partial class frmListUsers : Form
    {

        private DataView _DataSource = clsUser.GetAllUsers().DefaultView;

        public frmListUsers()
        {
            InitializeComponent();

        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            dgvAllUsers.DataSource = _DataSource;
            _SetupGridColumns();
            lblRecordsCount.Text = _DataSource.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
        }

        private void _SetupGridColumns() 
        { 

            dgvAllUsers.Columns["UserID"].HeaderText = "User ID";
            dgvAllUsers.Columns["UserID"].DisplayIndex = 0;
            dgvAllUsers.Columns["UserID"].Width = 110;

            dgvAllUsers.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllUsers.Columns["PersonID"].DisplayIndex = 1;
            dgvAllUsers.Columns["PersonID"].Width = 120;

            dgvAllUsers.Columns["FullName"].HeaderText = "Full Name";
            dgvAllUsers.Columns["FullName"].DisplayIndex = 2;
            dgvAllUsers.Columns["FullName"].Width = 450;

            dgvAllUsers.Columns["UserName"].HeaderText = "UserName";
            dgvAllUsers.Columns["UserName"].DisplayIndex = 3;
            dgvAllUsers.Columns["UserName"].Width = 140;

            dgvAllUsers.Columns["IsActive"].HeaderText = "Is Active";
            dgvAllUsers.Columns["IsActive"].DisplayIndex = 4;
            dgvAllUsers.Columns["IsActive"].Width = 90;

        }

        private void _ApplyFilter(string filter)
        {
            _DataSource.RowFilter = filter;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }
        private void _ReloadData()
        {
            _DataSource = clsUser.GetAllUsers().DefaultView;
            dgvAllUsers.DataSource = _DataSource;
            lblRecordsCount.Text = _DataSource.Count.ToString();
        }

        private void _ShowUser(int UserID)
        {
            frmShowUserInfo frm = new frmShowUserInfo(UserID);

            frm.ShowDialog();
            _ReloadData();
        }
        private void _DeleteUser(int UserID)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + UserID + "]?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (!clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User deletion failed because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("User deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ReloadData();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNone = cbFilterBy.Text == "None";
            bool isIsActive = cbFilterBy.Text == "Is Active";

            txtSearch.Visible = !isNone && !isIsActive;
            cbSearchIsActive.Visible = isIsActive;

            cbSearchIsActive.SelectedIndex = 0;
            txtSearch.Clear();
        }
        private void cbSearchIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchIsActive.Text == "All")
            {
                _ApplyFilter("");
            }
            else
            {
                _ApplyFilter($"IsActive = {cbSearchIsActive.Text == "Yes"}");
            }
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
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
                case "User ID":
                    colName = "UserID";
                    break;
                case "UserName":
                    colName = "UserName";
                    break;
                case "Person ID":
                    colName = "PersonID";
                    break;
                case "Full Name":
                    colName = "FullName";
                    break;
                default:
                    return;
            }

            if (colName == "PersonID" || colName == "UserID")
            {
                _ApplyFilter($"{colName} = {txtSearch.Text}");
            }
            else
            {
                _ApplyFilter($"{colName} LIKE '{txtSearch.Text}%'");
            }

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAllUsers_DoubleClick(object sender, EventArgs e)
        {
            _ShowUser((int)dgvAllUsers.CurrentRow.Cells["UserID"].Value);
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowUser((int)dgvAllUsers.CurrentRow.Cells["UserID"].Value);
        }
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells["UserID"].Value);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ReloadData();
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeleteUser((int)dgvAllUsers.CurrentRow.Cells["UserID"].Value);
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells["UserID"].Value);
            frm.ShowDialog();
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
