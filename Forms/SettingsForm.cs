using System;
using System.IO;
using System.Text;
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
                string connectionString = "Server=" + txtServer.Text.Trim() + ";" +
                                          "Port=" + (int)nudPort.Value + ";" +
                                          "Uid=" + txtUser.Text.Trim() + ";" +
                                          "Pwd=" + txtPassword.Text + ";" +
                                          "CharSet=utf8mb4;" +
                                          "AllowPublicKeyRetrieval=True;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
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

            string infoMessage = "";
            infoMessage = infoMessage + "Настройки сохранены\n";
            infoMessage = infoMessage + "Сервер: " + DbConfig.Server + "\n";
            infoMessage = infoMessage + "База: " + DbConfig.Database + "\n";
            infoMessage = infoMessage + "Пользователь: " + DbConfig.User;

            MessageHelper.ShowInfo(infoMessage);
        }

        private void btnImportSql_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQL файлы (*.sql)|*.sql";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string sqlScript = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                string connectionString = "Server=" + txtServer.Text.Trim() + ";Port=" + (int)nudPort.Value + ";Uid=" + txtUser.Text.Trim() + ";Pwd=" + txtPassword.Text + ";CharSet=utf8mb4;AllowPublicKeyRetrieval=True;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlScript, conn))
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

                try
                {
                    DbInitializer.EnsureDefaultUsers();
                }
                catch
                {

                }

                MessageHelper.ShowInfo("База восстановлена! Настройки сохранены.");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка импорта SQL: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}