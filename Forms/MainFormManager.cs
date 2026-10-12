using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormManager : Form
    {
        public MainFormManager()
        {
            InitializeComponent();
            lblTitle.Text = "Board Game Store — " + CurrentUser.FullName;
            lblRole.Text = "Роль: " + CurrentUser.Role;
        }

        private void btnGames_Click(object sender, EventArgs e) { new GamesForm(false).ShowDialog(); }
        private void btnOrders_Click(object sender, EventArgs e) { new OrdersListForm().ShowDialog(); }
        private void btnExit_Click(object sender, EventArgs e) { this.Close(); }
    }
}