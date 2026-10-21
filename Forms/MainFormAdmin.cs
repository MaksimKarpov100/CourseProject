using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormAdmin : Form
    {
        private OrdersListForm ordersForm;
        private GamesForm gamesForm;
        private UsersForm usersForm;
        private CatalogsForm catalogsForm;
        private DiscountsForm discountsForm;
        private SpecialForm specialForm;

        public MainFormAdmin()
        {
            InitializeComponent();
            lblUserInfo.Text = CurrentUser.FullName + " (" + CurrentUser.Role + ")";

            tabMain.SelectedTab = tabOrders;
            if (ordersForm == null || ordersForm.IsDisposed)
            {
                ordersForm = new OrdersListForm();
                LoadFormInTab(ordersForm, tabOrders);
            }
        }

        private void LoadFormInTab(Form form, TabPage page)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            page.Controls.Add(form);
            form.Show();

            foreach (Control c in form.Controls)
            {
                if (c.Name == "btnBack")
                {
                    c.Visible = false;
                }
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                else if (tabMain.SelectedTab == tabUsers)
                {
                    if (usersForm == null || usersForm.IsDisposed)
                    {
                        usersForm = new UsersForm();
                        LoadFormInTab(usersForm, tabUsers);
                    }
                }
                else if (tabMain.SelectedTab == tabCatalogs)
                {
                    if (catalogsForm == null || catalogsForm.IsDisposed)
                    {
                        catalogsForm = new CatalogsForm(0);
                        LoadFormInTab(catalogsForm, tabCatalogs);
                    }
                }
                else if (tabMain.SelectedTab == tabDiscounts)
                {
                    if (discountsForm == null || discountsForm.IsDisposed)
                    {
                        discountsForm = new DiscountsForm();
                        LoadFormInTab(discountsForm, tabDiscounts);
                    }
                }
                else if (tabMain.SelectedTab == tabSpecial)
                {
                    if (specialForm == null || specialForm.IsDisposed)
                    {
                        specialForm = new SpecialForm();
                        LoadFormInTab(specialForm, tabSpecial);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка вкладки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Выйти из системы?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}