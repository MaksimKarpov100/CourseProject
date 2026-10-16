using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DbConfig.Load();

            bool ready = TryPrepare();

            if (!ready)
            {
                MessageBox.Show(
                    "База данных не найдена или к ней нет доступа.\n\n" +
                    "Импортируйте дамп через «Настройки БД» → «Импорт SQL-дампа».",
                    "Подготовка БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                SettingsForm settings = new SettingsForm();
                settings.ShowDialog();

                ready = TryPrepare();
            }

            if (ready)
            {
                Application.Run(new LoginForm());
            }
            else
            {
                MessageBox.Show(
                    "База данных не подготовлена. Приложение будет закрыто.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static bool TryPrepare()
        {
            try
            {
                DbInitializer.EnsureDefaultUsers();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при подготовке пользователей:\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}