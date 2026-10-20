using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class LoginForm : Form
    {
        private int failedAttempts = 0;
        private int secondsLeft = 0;
        private Timer timerBlock;
        private CaptchaGenerator captchaGen = new CaptchaGenerator();

        public LoginForm()
        {
            InitializeComponent();

            try { pbLogo.Image = Image.FromFile("dice.png"); } catch { }

            timerBlock = new Timer();
            timerBlock.Interval = 1000;
            timerBlock.Tick += timerBlock_Tick;

            LoadCaptcha();
        }

        // --- ЭФФЕКТЫ ПРИ НАВЕДЕНИИ ---
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53))))); // Светлее
            btnLogin.Cursor = Cursors.Hand; // Курсор-рука
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47))))); // Исходный
            btnLogin.Cursor = Cursors.Default;
        }

        // --- ЛОГИКА ---
        private void LoadCaptcha()
        {
            pbCaptcha.Image = captchaGen.Generate();
            txtCaptcha.Clear();
        }

        private void pbCaptcha_Click(object sender, EventArgs e)
        {
            LoadCaptcha();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
                btnShowPassword.Text = "🙈";
            }
            else
            {
                txtPassword.PasswordChar = '●';
                btnShowPassword.Text = "👁";
            }
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string captcha = txtCaptcha.Text.Trim();

            if (login.Length < 4 || login.Length > 32)
            {
                ValidationHelper.ShowWarning("Логин должен быть от 4 до 32 символов");
                return;
            }

            if (password.Length < 8 || password.Length > 64)
            {
                ValidationHelper.ShowWarning("Пароль должен быть от 8 до 64 символов");
                return;
            }

            if (pbCaptcha.Visible && !captchaGen.Validate(captcha))
            {
                ValidationHelper.ShowWarning("Неверная капча! Подождите 10 секунд.");
                LoadCaptcha();
                StartBlockTimer();
                return;
            }

            bool isValid = false;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string hash = PasswordHelper.GetHash(password);

                    MySqlCommand cmd = new MySqlCommand("SELECT user_id, full_name, role FROM users WHERE login=@l AND password_hash=@p", conn);
                    cmd.Parameters.AddWithValue("@l", login);
                    cmd.Parameters.AddWithValue("@p", hash);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            isValid = true;
                            CurrentUser.UserId = Convert.ToInt32(r["user_id"]);
                            CurrentUser.FullName = r["full_name"].ToString();
                            CurrentUser.Role = r["role"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ValidationHelper.ShowError("Ошибка БД: " + ex.Message);
                return;
            }

            if (isValid)
            {
                this.Hide();
                if (CurrentUser.Role == "Администратор") new MainFormAdmin().ShowDialog();
                else if (CurrentUser.Role == "Товаровед") new MainFormManager().ShowDialog();
                else if (CurrentUser.Role == "Продавец") new MainFormSeller().ShowDialog();

                this.Close();
                Application.Exit();
            }
            else
            {
                failedAttempts++;
                ValidationHelper.ShowWarning("Неверный логин или пароль!");

                if (failedAttempts >= 2)
                {
                    lblCaptcha.Visible = true;
                    txtCaptcha.Visible = true;
                    pbCaptcha.Visible = true;
                    lblCaptchaHint.Visible = true;
                    LoadCaptcha();
                }

                txtPassword.Clear();
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

                if (txtCaptcha.Visible) LoadCaptcha();
            }
        }
    }
}