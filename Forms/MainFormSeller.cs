using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormSeller : Form
    {
        public MainFormSeller()
        {
            InitializeComponent();
        }

        private void btnViewGames_Click(object sender, EventArgs e)
        {
            new GamesForm().ShowDialog();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            new OrderAddForm().ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            new CustomersForm().ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            new OrdersListForm().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}