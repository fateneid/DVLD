using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.People
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
            get
            {
                return _FilterEnabled;
            }
        }
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }
        public clsPerson SelectedPerson
        {
            get { return ctrlPersonCard1.SelectedPerson; }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 1;
            txtFindByValue.Focus();
        }

        private void txtFindByValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFindPerson.PerformClick();
            }

            if (cbFindBy.Text == "Person ID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }
        private void txtFindByValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFindByValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFindByValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFindByValue, "");
            }
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFindByValue.Clear();
            txtFindByValue.Focus();
        }

        private void _FindNow()
        {
            switch (cbFindBy.Text) 
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFindByValue.Text.Trim()));
                    break;
                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(txtFindByValue.Text.Trim());
                    break;
            }

            if (FilterEnabled)
            {
                OnPersonSelected?.Invoke(ctrlPersonCard1.PersonID);
            }
        }

        public void FilterFocus()
        {
            txtFindByValue.Focus();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFindBy.SelectedIndex = 0;
            txtFindByValue.Text = PersonID.ToString();
            _FindNow();
        }

        private void _DataBackEvent(int PersonID)
        {
            cbFindBy.SelectedIndex = 0;
            txtFindByValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);

            if (FilterEnabled)
            {
                OnPersonSelected?.Invoke(PersonID);
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("This field can not be blank!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FindNow();

        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();

            frm.DataBack += _DataBackEvent;
            frm.ShowDialog();

        }

    }
}
