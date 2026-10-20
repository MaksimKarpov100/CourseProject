using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        // ВОТ ЭТОТ МЕТОД НУЖНО БЫЛО ДОБАВИТЬ
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Если галочка стоит, показываем текст, иначе скрываем
            char passChar = chkShowPassword.Checked ? '\0' : '●';
            txtOldPass.PasswordChar = passChar;
            txtNewPass.PasswordChar = passChar;
            txtConfirmPass.PasswordChar = passChar;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPass.Text) ||
                string.IsNullOrWhiteSpace(txtNewPass.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                ValidationHelper.ShowWarning("Заполните все поля!");
                return;
            }

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                ValidationHelper.ShowWarning("Новые пароли не совпадают!");
                return;
            }

            if (txtNewPass.Text.Length < 8)
            {
                ValidationHelper.ShowWarning("Новый пароль должен быть не менее 8 символов!");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmdCheck = new MySqlCommand("SELECT password_hash FROM users WHERE user_id=@id", conn);
                    cmdCheck.Parameters.AddWithValue("@id", CurrentUser.UserId);
                    string oldHash = cmdCheck.ExecuteScalar().ToString();

                    if (!PasswordHelper.CheckPassword(txtOldPass.Text, oldHash))
                    {
                        ValidationHelper.ShowWarning("Неверный старый пароль!");
                        return;
                    }

                    string newHash = PasswordHelper.GetHash(txtNewPass.Text);
                    MySqlCommand cmdUpdate = new MySqlCommand("UPDATE users SET password_hash=@hash WHERE user_id=@id", conn);
                    cmdUpdate.Parameters.AddWithValue("@hash", newHash);
                    cmdUpdate.Parameters.AddWithValue("@id", CurrentUser.UserId);
                    cmdUpdate.ExecuteNonQuery();
                }

                ValidationHelper.ShowSuccess("Пароль успешно изменен!");
                this.Close();
            }
            catch (Exception ex)
            {
                ValidationHelper.ShowError("Ошибка: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}