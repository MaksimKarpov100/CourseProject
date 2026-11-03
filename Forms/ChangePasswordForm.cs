using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnShowOld_Click(object sender, EventArgs e)
        {
            if (txtOldPass.PasswordChar == '●')
            {
                txtOldPass.PasswordChar = '\0';
            }
            else
            {
                txtOldPass.PasswordChar = '●';
            }
        }

        private void btnShowNew_Click(object sender, EventArgs e)
        {
            if (txtNewPass.PasswordChar == '●')
            {
                txtNewPass.PasswordChar = '\0';
            }
            else
            {
                txtNewPass.PasswordChar = '●';
            }
        }

        private void btnShowConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirmPass.PasswordChar == '●')
            {
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtConfirmPass.PasswordChar = '●';
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPass.Text;
            string newPassword = txtNewPass.Text;
            string confirmPassword = txtConfirmPass.Text;

            if (string.IsNullOrWhiteSpace(oldPassword) == true)
            {
                MessageHelper.ShowWarning("Введите старый пароль!");
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword) == true)
            {
                MessageHelper.ShowWarning("Введите новый пароль!");
                return;
            }

            if (string.IsNullOrWhiteSpace(confirmPassword) == true)
            {
                MessageHelper.ShowWarning("Подтвердите новый пароль!");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageHelper.ShowWarning("Новые пароли не совпадают!");
                return;
            }

            if (newPassword.Length < 8 || newPassword.Length > 64)
            {
                MessageHelper.ShowWarning("Новый пароль должен быть от 8 до 64 символов!");
                return;
            }

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", CurrentUser.UserId);

                string sqlSelect = "SELECT password_hash FROM users WHERE user_id=@id";
                DataTable dt = DatabaseHelper.ExecuteQuery(sqlSelect, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageHelper.ShowError("Пользователь не найден!");
                    return;
                }

                string oldHashFromDb = dt.Rows[0]["password_hash"].ToString();

                if (PasswordHelper.CheckPassword(oldPassword, oldHashFromDb) == false)
                {
                    MessageHelper.ShowWarning("Неверный старый пароль!");
                    return;
                }

                string newHash = PasswordHelper.GetHash(newPassword);

                Dictionary<string, object> updateParameters = new Dictionary<string, object>();
                updateParameters.Add("@hash", newHash);
                updateParameters.Add("@id", CurrentUser.UserId);

                string sqlUpdate = "UPDATE users SET password_hash=@hash WHERE user_id=@id";
                DatabaseHelper.ExecuteNonQuery(sqlUpdate, updateParameters);

                MessageHelper.ShowInfo("Пароль успешно изменен!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка базы данных: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}