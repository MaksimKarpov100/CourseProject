using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;

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
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '●';
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

            if (pbCaptcha.Visible == true)
            {
                if (captchaGen.Validate(captcha) == false)
                {
                    lblError.Text = "Неверная капча!";
                    lblError.Visible = true;
                    LoadCaptcha();
                    return;
                }
            }

            bool isValid = false;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string hash = PasswordHelper.GetHash(password);

                    string sql = "SELECT user_id, full_name, role FROM users WHERE login=@l AND password_hash=@p";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@l", login);
                    cmd.Parameters.AddWithValue("@p", hash);

                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read() == true)
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
                MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isValid == true)
            {
                this.Hide();

                if (CurrentUser.Role == "Администратор")
                {
                    MainFormAdmin adminForm = new MainFormAdmin();
                    adminForm.ShowDialog();
                }
                else if (CurrentUser.Role == "Товаровед")
                {
                    MainFormManager managerForm = new MainFormManager();
                    managerForm.ShowDialog();
                }
                else if (CurrentUser.Role == "Продавец")
                {
                    MainFormSeller sellerForm = new MainFormSeller();
                    sellerForm.ShowDialog();
                }

                this.Close();
                Application.Exit();
            }
            else
            {
                failedAttempts++;

                lblError.Text = "Неверный логин или пароль!";
                lblError.Visible = true;

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
    }
}