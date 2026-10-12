using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class LoginForm : Form
    {
        private static string ConnectionString => DbConfig.BuildConnectionString();

        private int failedAttempts = 0;
        private int secondsLeft = 0;
        private bool passwordVisible = false;
        private readonly Timer timerBlock;
        private readonly CaptchaGenerator captcha = new CaptchaGenerator();

        public LoginForm()
        {
            InitializeComponent();

            timerBlock = new Timer { Interval = 1000 };
            timerBlock.Tick += timerBlock_Tick;

            // Все элементы капчи изначально скрыты
            lblCaptcha.Visible = false;
            pbCaptcha.Visible = false;
            txtCaptcha.Visible = false;
            lblCaptchaHint.Visible = false;
            lblTimer.Visible = false;
            lblError.Visible = false;
        }

        /// <summary>
        /// Показать / скрыть пароль.
        /// </summary>
        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            txtPassword.PasswordChar = passwordVisible ? '\0' : '*';
            btnShowPassword.Text = passwordVisible ? "🙈" : "👁";
            txtPassword.Focus();
            txtPassword.SelectionStart = txtPassword.Text.Length;
        }

        /// <summary>
        /// Кнопка «Войти».
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (login.Length < 4 || login.Length > 32)
            {
                ShowError("Логин должен содержать от 4 до 32 символов");
                return;
            }
            if (password.Length < 8 || password.Length > 64)
            {
                ShowError("Пароль должен содержать от 8 до 64 символов");
                return;
            }

            if (pbCaptcha.Visible && !captcha.Validate(txtCaptcha.Text))
            {
                ShowError("Неверная капча. Вход заблокирован на 10 секунд");
                RefreshCaptcha();
                StartBlockTimer();
                return;
            }

            if (Authenticate(login, password))
            {
                failedAttempts = 0;
                OpenMainForm();
            }
            else
            {
                HandleFailedAttempt();
            }
        }

        /// <summary>
        /// Клик по картинке капчи — обновить.
        /// </summary>
        private void pbCaptcha_Click(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }

        private void RefreshCaptcha()
        {
            if (pbCaptcha.Image != null) pbCaptcha.Image.Dispose();
            pbCaptcha.Image = captcha.Generate();
            txtCaptcha.Clear();
            txtCaptcha.Focus();
        }

        /// <summary>
        /// Проверка логина и пароля в БД.
        /// </summary>
        private bool Authenticate(string login, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT user_id, full_name, role FROM users " +
                                 "WHERE login=@l AND password_hash=@p LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@l", login);
                        cmd.Parameters.AddWithValue("@p", password);

                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                CurrentUser.UserId = Convert.ToInt32(r["user_id"]);
                                CurrentUser.FullName = r["full_name"].ToString();
                                CurrentUser.Role = r["role"].ToString();
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void HandleFailedAttempt()
        {
            failedAttempts++;

            if (failedAttempts == 1)
            {
                ShowError("Неверный логин или пароль");
            }
            else
            {
                ShowError("Повторная неудачная попытка. Введите капчу");
                lblCaptcha.Visible = true;
                pbCaptcha.Visible = true;
                txtCaptcha.Visible = true;
                lblCaptchaHint.Visible = true;
                RefreshCaptcha();
                StartBlockTimer();
            }
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }

        private void StartBlockTimer()
        {
            secondsLeft = 10;
            lblTimer.Visible = true;
            lblTimer.Text = "00:10";
            btnLogin.Enabled = false;
            txtLogin.Enabled = false;
            txtPassword.Enabled = false;
            txtCaptcha.Enabled = false;
            btnShowPassword.Enabled = false;
            timerBlock.Start();
        }

        private void timerBlock_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            lblTimer.Text = "00:" + secondsLeft.ToString("D2");

            if (secondsLeft <= 0)
            {
                timerBlock.Stop();
                lblTimer.Visible = false;
                btnLogin.Enabled = true;
                txtLogin.Enabled = true;
                txtPassword.Enabled = true;
                txtCaptcha.Enabled = true;
                btnShowPassword.Enabled = true;
                if (txtCaptcha.Visible) RefreshCaptcha();
            }
        }

        private void OpenMainForm()
        {
            Hide();

            if (CurrentUser.Role == "Администратор")
                new MainFormAdmin().ShowDialog();
            else if (CurrentUser.Role == "Товаровед")
                new MainFormManager().ShowDialog();
            else if (CurrentUser.Role == "Продавец")
                new MainFormSeller().ShowDialog();

            Show();
            ResetForm();
        }

        private void ResetForm()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtCaptcha.Clear();
            failedAttempts = 0;
            passwordVisible = false;
            txtPassword.PasswordChar = '*';
            btnShowPassword.Text = "👁";
            lblCaptcha.Visible = false;
            pbCaptcha.Visible = false;
            txtCaptcha.Visible = false;
            lblCaptchaHint.Visible = false;
            lblTimer.Visible = false;
            lblError.Visible = false;
        }

        /// <summary>
        /// Открыть настройки БД.
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        /// <summary>
        /// Выход из приложения.
        /// </summary>
        private void btnExitApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из приложения?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}