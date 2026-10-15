using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormManager : Form
    {
        private GamesForm gamesForm;
        private OrdersListForm ordersForm;
        private UserProfileForm profileForm;

        public MainFormManager()
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

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabMain.SelectedTab == tabGames)
                {
                    if (gamesForm == null || gamesForm.IsDisposed)
                    {
                        gamesForm = new GamesForm(false);
                        LoadFormInTab(gamesForm, tabGames);
                    }
                }
                else if (tabMain.SelectedTab == tabOrders)
                {
                    if (ordersForm == null || ordersForm.IsDisposed)
                    {
                        ordersForm = new OrdersListForm();
                        LoadFormInTab(ordersForm, tabOrders);
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