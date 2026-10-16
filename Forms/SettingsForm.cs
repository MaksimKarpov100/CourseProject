using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            txtServer.Text = DbConfig.Server;
            nudPort.Value = DbConfig.Port;
            txtDatabase.Text = DbConfig.Database;
            txtUser.Text = DbConfig.User;
            txtPassword.Text = DbConfig.Password;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = "Server=" + txtServer.Text.Trim() + ";" +
                            "Port=" + (int)nudPort.Value + ";" +
                            "Uid=" + txtUser.Text.Trim() + ";" +
                            "Pwd=" + txtPassword.Text + ";" +
                            "CharSet=utf8mb4;" +
                            "AllowPublicKeyRetrieval=True;";

                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                }

                MessageHelper.ShowInfo("Подключение к серверу MySQL успешно!");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка подключения:\n" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbConfig.Server = txtServer.Text.Trim();
            DbConfig.Port = (int)nudPort.Value;
            DbConfig.Database = txtDatabase.Text.Trim();
            DbConfig.User = txtUser.Text.Trim();
            DbConfig.Password = txtPassword.Text;

            DbConfig.Save();

            MessageHelper.ShowInfo("Настройки сохранены\n" +
                "Сервер: " + DbConfig.Server + "\n" +
                "База: " + DbConfig.Database + "\n" +
                "Пользователь: " + DbConfig.User);
        }

        private void btnImportSql_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQL|*.sql|Все файлы|*.*";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string sql = File.ReadAllText(ofd.FileName, System.Text.Encoding.UTF8);

                string cs = "Server=" + txtServer.Text.Trim() + ";" +
                            "Port=" + (int)nudPort.Value + ";" +
                            "Uid=" + txtUser.Text.Trim() + ";" +
                            "Pwd=" + txtPassword.Text + ";" +
                            "CharSet=utf8mb4;" +
                            "AllowPublicKeyRetrieval=True;";

                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandTimeout = 300;
                        cmd.ExecuteNonQuery();
                    }
                }

                DbConfig.Server = txtServer.Text.Trim();
                DbConfig.Port = (int)nudPort.Value;
                DbConfig.Database = txtDatabase.Text.Trim();
                DbConfig.User = txtUser.Text.Trim();
                DbConfig.Password = txtPassword.Text;
                DbConfig.Save();

                MessageHelper.ShowInfo("Импорт БД завершён успешно\nБаза: " + DbConfig.Database);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка импорта:\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}