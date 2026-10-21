using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace BoardGame_Store
{
    public partial class MainFormManager : Form
    {
        private GamesForm gamesForm;
        private CatalogsForm catalogsForm;

        public MainFormManager()
        {
            InitializeComponent();
            lblUserInfo.Text = CurrentUser.FullName + " (" + CurrentUser.Role + ")";

            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
        }

        private void MainFormManager_Load(object sender, EventArgs e)
        {
            tabMain.SelectedTab = tabGames;

            if (gamesForm == null || gamesForm.IsDisposed)
            {
                gamesForm = new GamesForm(true);
                LoadFormInTab(gamesForm, tabGames);
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
                if (tabMain.SelectedTab == tabGames)
                {
                    if (gamesForm == null || gamesForm.IsDisposed)
                    {
                        gamesForm = new GamesForm(true);
                        LoadFormInTab(gamesForm, tabGames);
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
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT o.order_id, c.full_name, o.order_date, o.total_amount " +
                                 "FROM orders o JOIN customers c ON o.customer_id = c.customer_id " +
                                 "WHERE o.order_date >= @df AND o.order_date < @dt " +
                                 "ORDER BY o.order_date ASC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@df", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@dt", dtpTo.Value.Date.AddDays(1));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("За выбранный период нет данных.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    decimal totalSum = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalSum += Convert.ToDecimal(row["total_amount"]);
                    }

                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine("sep=;");
                    csv.AppendLine("Номер заказа;Клиент;Дата оформления;Сумма");

                    foreach (DataRow row in dt.Rows)
                    {
                        csv.AppendLine(row["order_id"].ToString() + ";" +
                                       row["full_name"].ToString() + ";" +
                                       Convert.ToDateTime(row["order_date"]).ToString("dd.MM.yyyy HH:mm") + ";" +
                                       Convert.ToDecimal(row["total_amount"]).ToString("0.00"));
                    }

                    csv.AppendLine(";;ИТОГО ЗА ПЕРИОД:;" + totalSum.ToString("0.00"));

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "Excel документ (*.csv)|*.csv";
                        sfd.FileName = "Отчет_с_" + dtpFrom.Value.ToString("ddMMyyyy") + "_по_" + dtpTo.Value.ToString("ddMMyyyy") + ".csv";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.UTF8);
                            MessageBox.Show("Отчет успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process.Start(sfd.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отчета: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из системы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}