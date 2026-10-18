using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class LoginForm : Form
    {
        private int failedAttempts = 0;
        private CaptchaGenerator captchaGen = new CaptchaGenerator();

        public LoginForm()
        {
            InitializeComponent();
            LoadCaptcha();
        }

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
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0'; 
            }
            else
            {
                txtPassword.PasswordChar = '*'; 
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
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

            if (failedAttempts >= 3 && !captchaGen.Validate(captcha))
            {
                lblError.Text = "Неверная капча!";
                lblError.Visible = true;
                LoadCaptcha();
                return;
            }

            bool isValid = false;
            string role = "";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string hash = PasswordHelper.GetHash(password);

                    MySqlCommand cmd = new MySqlCommand(
                        "SELECT user_id, full_name, role FROM users WHERE login=@l AND password_hash=@p", conn);
                    cmd.Parameters.AddWithValue("@l", login);
                    cmd.Parameters.AddWithValue("@p", hash);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            isValid = true;
                            role = r["role"].ToString();

                            CurrentUser.UserId = Convert.ToInt32(r["user_id"]);
                            CurrentUser.FullName = r["full_name"].ToString();
                            CurrentUser.Role = role;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка подключения к БД: " + ex.Message);
                return;
            }

            if (isValid)
            {
                this.Hide(); 
                if (CurrentUser.Role == "Администратор")
                    new MainFormAdmin().ShowDialog();
                else if (CurrentUser.Role == "Товаровед")
                    new MainFormManager().ShowDialog();
                else if (CurrentUser.Role == "Продавец")
                    new MainFormSeller().ShowDialog();

                this.Close();
                Application.Exit();
            }
            else
            {
                failedAttempts++;
                lblError.Text = "Неверный логин или пароль!";
                lblError.Visible = true;

                if (failedAttempts >= 3)
                {
                    lblCaptcha.Visible = true;
                    txtCaptcha.Visible = true;
                    pbCaptcha.Visible = true;
                    LoadCaptcha();
                }

                txtPassword.Clear();
            }
        }
    }
}