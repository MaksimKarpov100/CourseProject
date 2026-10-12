using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormSeller : Form
    {
        public MainFormSeller()
        {
            InitializeComponent();
            lblTitle.Text = "Board Game Store — " + CurrentUser.FullName;
            lblRole.Text = "Роль: " + CurrentUser.Role;
        }

        private void btnViewGames_Click(object sender, EventArgs e) { new GamesForm(true).ShowDialog(); }
        private void btnNewOrder_Click(object sender, EventArgs e) { new OrderAddForm().ShowDialog(); }
        private void btnCustomers_Click(object sender, EventArgs e) { new CatalogsForm(1).ShowDialog(); }
        private void btnOrders_Click(object sender, EventArgs e) { new OrdersListForm().ShowDialog(); }
        private void btnExit_Click(object sender, EventArgs e) { this.Close(); }
    }
}