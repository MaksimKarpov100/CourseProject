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
        private UserProfileForm profileForm;

        public MainFormAdmin()
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

            foreach (Control c in form.Controls)
            {
                if (c.Name == "btnBack")
                {
                    c.Visible = false;
                }
            }
        }

        public void SwitchToTab(string tabKey)
        {
            switch (tabKey)
            {
                case "orders":
                    tabMain.SelectedTab = tabOrders;
                    break;
                case "games":
                    tabMain.SelectedTab = tabGames;
                    break;
                case "users":
                    tabMain.SelectedTab = tabUsers;
                    break;
                case "catalogs":
                    tabMain.SelectedTab = tabCatalogs;
                    break;
                case "discounts":
                    tabMain.SelectedTab = tabDiscounts;
                    break;
                case "special":
                    tabMain.SelectedTab = tabSpecial;
                    break;
                case "profile":
                    tabMain.SelectedTab = tabProfile;
                    break;
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
                else if (tabMain.SelectedTab == tabProfile)
                {
                    if (profileForm == null || profileForm.IsDisposed)
                    {
                        profileForm = new UserProfileForm();
                        LoadFormInTab(profileForm, tabProfile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка вкладки: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageHelper.AskConfirm("Выйти из системы?"))
            {
                this.Close();
            }
        }
    }
}