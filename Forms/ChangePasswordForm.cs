using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class ChangePasswordForm : Form
    {
        private int userId;
        private string userLogin;

        public ChangePasswordForm(int id, string login)
        {
            InitializeComponent();

            userId = id;
            userLogin = login;

            lblUser.Text = "Пользователь: " + userLogin;

            txtNewPassword.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageHelper.ShowWarning("Введите новый пароль");
                return;
            }

            if (!Validator.CheckPassword(newPass))
            {
                MessageHelper.ShowWarning("Пароль: 8-64 символа, буквы и цифры");
                return;
            }

            if (newPass != confirm)
            {
                MessageHelper.ShowWarning("Пароли не совпадают");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand getHash = new MySqlCommand(
                        "SELECT password_hash FROM users WHERE user_id=@id", conn);
                    getHash.Parameters.AddWithValue("@id", userId);

                    object oldHash = getHash.ExecuteScalar();

                    if (oldHash != null && PasswordHelper.CheckPassword(newPass, oldHash.ToString()))
                    {
                        MessageHelper.ShowWarning("Новый пароль совпадает со старым");
                        return;
                    }

                    string newHash = PasswordHelper.GetHash(newPass);

                    MySqlCommand update = new MySqlCommand(
                        "UPDATE users SET password_hash=@h WHERE user_id=@id", conn);

                    update.Parameters.AddWithValue("@h", newHash);
                    update.Parameters.AddWithValue("@id", userId);

                    update.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Пароль успешно изменён");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка смены пароля: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtNewPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtNewPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }
    }
}