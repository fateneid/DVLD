using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Users
{
    public partial class frmShowUserInfo : Form
    {

        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            ctrlUserCard1.LoadInfo(UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
