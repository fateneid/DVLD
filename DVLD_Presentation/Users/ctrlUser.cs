using DVLD_Business;
using System.Windows.Forms;

namespace DVLD_Presentation.Users
{
    public partial class ctrlUser : UserControl
    {

        private clsUser _User;
        public int UserID
        {
            get { return _User?.UserID ?? -1; }
        }

        public ctrlUser()
        {
            InitializeComponent();
        }

        private void _FillInfo()
        {
            ctrlPersonCard1.LoadInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }

        public void ResetInfo()
        {
            ctrlPersonCard1.ResetInfo();

            _User = null;

            lblUserID.Text = "[????]";
            lblUsername.Text = "[????]";
            lblIsActive.Text = "[????]";
        }

        public void LoadInfo(int UserID)
        {
            _User = clsUser.Find(UserID);
            if (_User == null)
            {
                ResetInfo();
                MessageBox.Show("No User with User ID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInfo();
        }

    }
}
