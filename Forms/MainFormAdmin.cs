using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks; // Добавлено для фонового запуска
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

        private Timer inactivityTimer;
        private int inactivitySeconds = 0;
        private const int TimeoutLimit = 300;
        private bool isLoggingOut = false;

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

            SetupInactivityTimer();

            Task.Run(() => MakeAutoBackup());
        }

        private void MakeAutoBackup()
        {
            try
            {
                string backupFolder = Path.Combine(Application.StartupPath, "Backups");
                if (!Directory.Exists(backupFolder)) Directory.CreateDirectory(backupFolder);

                string fileName = "auto_backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";
                string filePath = Path.Combine(backupFolder, fileName);

                string mysqldump = "";
                this.Invoke(new Action(() => {
                    using (SpecialForm dummyForm = new SpecialForm())
                    {
                        mysqldump = dummyForm.FindMysqldumpPath();
                    }
                }));

                if (string.IsNullOrEmpty(mysqldump)) return;

                string args = $"-u {DbConfig.User} ";
                if (!string.IsNullOrEmpty(DbConfig.Password)) args += $"-p{DbConfig.Password} ";
                args += $"--databases {DbConfig.Database} --result-file=\"{filePath}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = mysqldump,
                    Arguments = args,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                }
            }
            catch
            {

            }
        }

        private void SetupInactivityTimer()
        {
            inactivityTimer = new Timer();
            inactivityTimer.Interval = 1000;
            inactivityTimer.Tick += InactivityTimer_Tick;
            inactivityTimer.Start();

            this.MouseMove += ResetInactivity;
            this.KeyDown += ResetInactivity;
            this.MouseClick += ResetInactivity;
            this.KeyPress += ResetInactivity;
        }

        private void ResetInactivity(object sender, EventArgs e)
        {
            inactivitySeconds = 0;
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            inactivitySeconds++;

            if (inactivitySeconds >= TimeoutLimit)
            {
                inactivityTimer.Stop();

                MessageBox.Show("Сеанс завершен из-за неактивности (5 минут бездействия).",
                                "Автоматический выход",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                isLoggingOut = true; 
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageHelper.AskConfirm("Вы уверены, что хотите выйти из системы?") == true)
            {
                isLoggingOut = true;
                this.Close();
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
                if (c.Name == "btnBack") c.Visible = false;
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
                    else
                    {
                        ordersForm.RefreshData();
                    }
                }
                else if (tabMain.SelectedTab == tabGames)
                {
                    if (gamesForm == null || gamesForm.IsDisposed)
                    {
                        gamesForm = new GamesForm(false);
                        LoadFormInTab(gamesForm, tabGames);
                    }
                    else
                    {
                        gamesForm.RefreshData();
                    }
                }
                else if (tabMain.SelectedTab == tabUsers)
                {
                    if (usersForm == null || usersForm.IsDisposed)
                    {
                        usersForm = new UsersForm();
                        LoadFormInTab(usersForm, tabUsers);
                    }
                    else
                    {
                        usersForm.RefreshData();
                    }
                }
                else if (tabMain.SelectedTab == tabCatalogs)
                {
                    if (catalogsForm == null || catalogsForm.IsDisposed)
                    {
                        catalogsForm = new CatalogsForm(0);
                        LoadFormInTab(catalogsForm, tabCatalogs);
                    }
                    else
                    {
                        catalogsForm.RefreshData();
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
                MessageHelper.ShowError("Ошибка при переключении вкладки: " + ex.Message);
            }
        }

    }
}