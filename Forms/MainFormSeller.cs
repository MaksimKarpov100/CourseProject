using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormSeller : Form
    {
        private OrdersListForm ordersForm;
        private GamesForm gamesForm;
        private CatalogsForm catalogsForm;

        public MainFormSeller()
        {
            InitializeComponent();
            lblUserInfo.Text = CurrentUser.FullName + " (" + CurrentUser.Role + ")";
        }

        private void LoadFormInTab(Form form, TabPage page)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            page.Controls.Add(form);
            form.Show();
            foreach (Control c in form.Controls) if (c.Name == "btnBack") c.Visible = false;
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabOrders)
            {
                if (ordersForm == null || ordersForm.IsDisposed)
                {
                    ordersForm = new OrdersListForm();
                    LoadFormInTab(ordersForm, tabOrders);
                }
            }
            else if (tabMain.SelectedTab == tabGames)
            {
                if (gamesForm == null || gamesForm.IsDisposed)
                {
                    gamesForm = new GamesForm(false);
                    LoadFormInTab(gamesForm, tabGames);
                }
            }
            else if (tabMain.SelectedTab == tabCustomers)
            {
                if (catalogsForm == null || catalogsForm.IsDisposed)
                {
                    catalogsForm = new CatalogsForm(1);
                    LoadFormInTab(catalogsForm, tabCustomers);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из системы?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();
        }
    }
}