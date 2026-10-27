using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class MainFormManager : Form
    {
        private OrdersListForm ordersForm;
        private GamesForm gamesForm;
        private CatalogsForm catalogsForm;

        public MainFormManager()
        {
            InitializeComponent();
            lblUserInfo.Text = CurrentUser.FullName + " (" + CurrentUser.Role + ")";
        }

        private void MainFormManager_Load(object sender, EventArgs e)
        {
            tabMain.SelectedTab = tabGames;
            if (gamesForm == null || gamesForm.IsDisposed) { gamesForm = new GamesForm(true); LoadFormInTab(gamesForm, tabGames); }
        }

        private void LoadFormInTab(Form form, TabPage page)
        {
            form.TopLevel = false; form.FormBorderStyle = FormBorderStyle.None; form.Dock = DockStyle.Fill;
            page.Controls.Add(form); form.Show();
            foreach (Control c in form.Controls) if (c.Name == "btnBack") c.Visible = false;
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabMain.SelectedTab == tabGames) { if (gamesForm == null || gamesForm.IsDisposed) { gamesForm = new GamesForm(true); LoadFormInTab(gamesForm, tabGames); } else gamesForm.RefreshData(); }
                else if (tabMain.SelectedTab == tabOrders) { if (ordersForm == null || ordersForm.IsDisposed) { ordersForm = new OrdersListForm(); LoadFormInTab(ordersForm, tabOrders); } else ordersForm.RefreshData(); }
                else if (tabMain.SelectedTab == tabCatalogs) { if (catalogsForm == null || catalogsForm.IsDisposed) { catalogsForm = new CatalogsForm(0); LoadFormInTab(catalogsForm, tabCatalogs); } else catalogsForm.RefreshData(); }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnExit_Click(object sender, EventArgs e) { if (MessageBox.Show("Выйти?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close(); }
    }
}