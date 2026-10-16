using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class LoginForm : Form
    {
        private int fails = 0;
        private int secondsLeft = 0;
        private Timer timerBlock;
        private bool passwordVisible = false;
        private CaptchaGenerator captcha = new CaptchaGenerator();

        public LoginForm()
        {
            InitializeComponent();

            timerBlock = new Timer();
            timerBlock.Interval = 1000;
            timerBlock.Tick += timerBlock_Tick;

            lblCaptcha.Visible = false;
            pbCaptcha.Visible = false;
            txtCaptcha.Visible = false;
            lblCaptchaHint.Visible = false;
            lblTimer.Visible = false;
            lblError.Visible = false;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            if (passwordVisible)
            {
                txtPassword.PasswordChar = '\0';
                btnShowPassword.Text = "🙈";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnShowPassword.Text = "👁";
            }

            txtPassword.Focus();
            txtPassword.SelectionStart = txtPassword.Text.Length;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (login.Length < 4 || login.Length > 32)
            {
                ShowError("Логин: от 4 до 32 символов");
                return;
            }

            if (password.Length < 8 || password.Length > 64)
            {
                ShowError("Пароль: от 8 до 64 символов");
                return;
            }

            if (pbCaptcha.Visible)
            {
                if (!captcha.Validate(txtCaptcha.Text))
                {
                    ShowError("Неверная капча. Подождите 10 секунд");
                    RefreshCaptcha();
                    StartBlockTimer();
                    return;
                }
            }

            if (CheckLogin(login, password))
            {
                fails = 0;
                OpenMainForm();
            }
            else
            {
                fails++;

                if (fails == 1)
                {
                    ShowError("Неверный логин или пароль");
                }
                else
                {
                    ShowError("Повторная ошибка. Введите капчу");

                    lblCaptcha.Visible = true;
                    pbCaptcha.Visible = true;
                    txtCaptcha.Visible = true;
                    lblCaptchaHint.Visible = true;

                    RefreshCaptcha();
                    StartBlockTimer();
                }
            }
        }

        private bool CheckLogin(string login, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "SELECT user_id, full_name, role, password_hash " +
                        "FROM users WHERE login=@l LIMIT 1", conn);
                    cmd.Parameters.AddWithValue("@l", login);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string stored = reader["password_hash"].ToString();
                            int userId = Convert.ToInt32(reader["user_id"]);
                            string fullName = reader["full_name"].ToString();
                            string role = reader["role"].ToString();

                            bool ok;

                            if (stored.Length == 64 && IsHex(stored))
                            {
                                ok = PasswordHelper.CheckPassword(password, stored);
                            }
                            else
                            {
                                ok = (stored == password);
                            }

                            if (ok)
                            {
                                CurrentUser.UserId = userId;
                                CurrentUser.FullName = fullName;
                                CurrentUser.Role = role;

                                reader.Close();

                                if (!(stored.Length == 64 && IsHex(stored)))
                                {
                                    UpdatePasswordHash(userId, password);
                                }

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка БД: " + ex.Message);
            }

            return false;
        }

        private bool IsHex(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                bool ok = (c >= '0' && c <= '9') ||
                          (c >= 'a' && c <= 'f') ||
                          (c >= 'A' && c <= 'F');

                if (!ok) return false;
            }

            return true;
        }

        private void UpdatePasswordHash(int userId, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string hash = PasswordHelper.GetHash(password);

                    MySqlCommand cmd = new MySqlCommand(
                        "UPDATE users SET password_hash=@h WHERE user_id=@id", conn);
                    cmd.Parameters.AddWithValue("@h", hash);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
            }
        }

        private void RefreshCaptcha()
        {
            if (pbCaptcha.Image != null)
            {
                pbCaptcha.Image.Dispose();
            }

            pbCaptcha.Image = captcha.Generate();
            txtCaptcha.Clear();
            txtCaptcha.Focus();
        }

        private void pbCaptcha_Click(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }

        private void ShowError(string text)
        {
            lblError.Text = text;
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

                if (txtCaptcha.Visible)
                {
                    RefreshCaptcha();
                }
            }
        }

        private void OpenMainForm()
        {
            Hide();

            if (CurrentUser.Role == "Администратор")
            {
                new MainFormAdmin().ShowDialog();
            }
            else if (CurrentUser.Role == "Товаровед")
            {
                new MainFormManager().ShowDialog();
            }
            else if (CurrentUser.Role == "Продавец")
            {
                new MainFormSeller().ShowDialog();
            }

            Show();
            ResetForm();
        }

        private void ResetForm()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtCaptcha.Clear();

            fails = 0;
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            if (MessageHelper.AskConfirm("Выйти из приложения?"))
            {
                Application.Exit();
            }
        }
    }
}