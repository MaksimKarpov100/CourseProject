using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class UserProfileForm : Form
    {
        public UserProfileForm()
        {
            InitializeComponent();

            txtFullName.Text = CurrentUser.FullName;
            txtLogin.Text = CurrentUser.Role;
            txtRole.Text = CurrentUser.Role;
            txtPhone.Text = "+7 (900) ***-**-**";

            txtFullName.ReadOnly = true;
            txtLogin.ReadOnly = true;
            txtRole.ReadOnly = true;
            txtPhone.ReadOnly = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}