using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class LoginForm : Form
    {
        private const string ConnectionString =
            "Server=localhost;Database=board_game_store;Uid=root;Pwd=;CharSet=utf8mb4;";

        private int failedAttempts = 0;
        private Timer timerBlock;
        private int secondsLeft = 0;

        private readonly CaptchaGenerator captcha = new CaptchaGenerator();
        private bool passwordVisible = false;

        public LoginForm()
        {
            InitializeComponent();

            timerBlock = new Timer();
            timerBlock.Interval = 1000;
            timerBlock.Tick += timerBlock_Tick;

            pbCaptcha.Visible = false;
            lblCaptchaHint.Visible = false;
            txtCaptcha.Visible = false;
            lblTimer.Visible = false;

            btnLogin.Click += btnLogin_Click;
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
                MessageBox.Show("Логин должен содержать от 4 до 32 символов",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8 || password.Length > 64)
            {
                MessageBox.Show("Пароль должен содержать от 8 до 64 символов",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCaptcha.Visible)
            {
                if (!captcha.Validate(txtCaptcha.Text))
                {
                    MessageBox.Show("Неверная капча. Вход заблокирован на 10 секунд",
                        "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RefreshCaptcha();
                    StartBlockTimer();
                    return;
                }
            }

            string role = Authenticate(login, password);

            if (role != null)
            {
                failedAttempts = 0;
                OpenMainForm(role);
            }
            else
            {
                failedAttempts++;

                if (failedAttempts == 1)
                {
                    MessageBox.Show("Неверный логин или пароль",
                        "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Повторная неудачная попытка. Введите капчу",
                        "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    pbCaptcha.Visible = true;
                    lblCaptchaHint.Visible = true;
                    txtCaptcha.Visible = true;
                    RefreshCaptcha();

                    StartBlockTimer();
                }
            }
        }

        private void pbCaptcha_Click(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }

        private void RefreshCaptcha()
        {
            pbCaptcha.Image?.Dispose();
            pbCaptcha.Image = captcha.Generate();
            txtCaptcha.Clear();
            txtCaptcha.Focus();
        }

        private string Authenticate(string login, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT role FROM users WHERE login = @login AND password_hash = @pass LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@pass", password);

                        object result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
                    RefreshCaptcha();
            }
        }

        private void OpenMainForm(string role)
        {
            this.Hide();

            switch (role)
            {
                case "Администратор":
                    new MainFormAdmin().ShowDialog();
                    break;
                case "Товаровед":
                    new MainFormManager().ShowDialog();
                    break;
                case "Продавец":
                    new MainFormSeller().ShowDialog();
                    break;
                default:
                    MessageBox.Show("Неизвестная роль: " + role,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                    return;
            }

            this.Show();

            txtLogin.Clear();
            txtPassword.Clear();
            txtCaptcha.Clear();
            failedAttempts = 0;
            passwordVisible = false;
            txtPassword.PasswordChar = '*';
            btnShowPassword.Text = "👁";
            pbCaptcha.Visible = false;
            lblCaptchaHint.Visible = false;
            txtCaptcha.Visible = false;
            lblTimer.Visible = false;
        }
    }
}