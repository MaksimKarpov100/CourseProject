using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormAdmin : Form
    {
        public MainFormAdmin()
        {
            InitializeComponent();
            lblTitle.Text = "Board Game Store — " + CurrentUser.FullName;
            lblRole.Text = "Роль: " + CurrentUser.Role;
        }

        private void btnUsers_Click(object sender, EventArgs e) { new UsersForm().ShowDialog(); }
        private void btnGames_Click(object sender, EventArgs e) { new GamesForm(false).ShowDialog(); }
        private void btnOrders_Click(object sender, EventArgs e) { new OrdersListForm().ShowDialog(); }
        private void btnDiscounts_Click(object sender, EventArgs e) { new DiscountsForm().ShowDialog(); }
        private void btnSpecial_Click(object sender, EventArgs e) { new SpecialForm().ShowDialog(); }
        private void btnCatalogs_Click(object sender, EventArgs e) { new CatalogsForm(0).ShowDialog(); }
        private void btnProfile_Click(object sender, EventArgs e) { new UserProfileForm().ShowDialog(); }
        private void btnExit_Click(object sender, EventArgs e) { this.Close(); }
    }
}