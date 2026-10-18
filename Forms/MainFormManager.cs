using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormManager : Form
    {
        public MainFormManager()
        {
            InitializeComponent();
            lblUserInfo.Text = CurrentUser.FullName + " (Товаровед)";

            tabMain.SelectedIndex = 0;
            LoadTabContent(tabMain.SelectedTab);
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTabContent(tabMain.SelectedTab);
        }

        private void LoadTabContent(TabPage selectedTab)
        {
            if (selectedTab.Controls.Count > 0) return;

            Form formToLoad = null;

            if (selectedTab == tabGames)
            {
                formToLoad = new GamesForm(false);
            }
            else if (selectedTab == tabOrders)
            {
                formToLoad = new OrdersListForm();
            }
            else if (selectedTab == tabReports)
            {
                formToLoad = new SpecialForm();
            }
            else if (selectedTab == tabProfile)
            {
                formToLoad = new UserProfileForm();
            }

            if (formToLoad != null)
            {
                formToLoad.TopLevel = false;
                formToLoad.FormBorderStyle = FormBorderStyle.None;
                formToLoad.Dock = DockStyle.Fill;
                selectedTab.Controls.Add(formToLoad);
                formToLoad.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageHelper.AskConfirm("Вы действительно хотите выйти?"))
            {
                Application.Exit();
            }
        }
    }
}