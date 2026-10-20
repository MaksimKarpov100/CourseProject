using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class UserEditForm : Form
    {
        private int _userId = 0;

        public UserEditForm() { InitializeComponent(); cmbRole.SelectedIndex = 2; lblTitle.Text = "Добавление"; }
        public UserEditForm(int id) { InitializeComponent(); _userId = id; lblTitle.Text = "Редактирование"; }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            if (_userId > 0)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT full_name, login, role, phone FROM users WHERE user_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", _userId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                txtName.Text = r["full_name"].ToString();
                                txtLogin.Text = r["login"].ToString();
                                cmbRole.Text = r["role"].ToString();
                                mtxtPhone.Text = r["phone"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex) { ValidationHelper.ShowError("Ошибка загрузки: " + ex.Message); }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Умные проверки по ТЗ
            if (!ValidationHelper.IsRussianText(txtName.Text)) { ValidationHelper.ShowWarning("ФИО: только русские буквы!"); return; }

            if (txtLogin.Text.Length < 4 || txtLogin.Text.Length > 32)
            { ValidationHelper.ShowWarning("Логин должен быть от 4 до 32 символов!"); return; }

            if (_userId == 0 && txtPass.Text.Length < 8)
            { ValidationHelper.ShowWarning("Пароль должен быть от 8 символов!"); return; }

            if (_userId > 0 && txtPass.Text.Length > 0 && txtPass.Text.Length < 8)
            { ValidationHelper.ShowWarning("Новый пароль должен быть от 8 символов!"); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql;
                    MySqlCommand cmd;

                    if (_userId == 0)
                    {
                        string hash = PasswordHelper.GetHash(txtPass.Text);
                        sql = "INSERT INTO users (full_name, login, password_hash, role, phone) VALUES (@n, @l, @p, @r, @ph)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@p", hash);
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(txtPass.Text))
                        {
                            sql = "UPDATE users SET full_name=@n, login=@l, password_hash=@p, role=@r, phone=@ph WHERE user_id=@id";
                            cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@p", PasswordHelper.GetHash(txtPass.Text));
                        }
                        else
                        {
                            sql = "UPDATE users SET full_name=@n, login=@l, role=@r, phone=@ph WHERE user_id=@id";
                            cmd = new MySqlCommand(sql, conn);
                        }
                        cmd.Parameters.AddWithValue("@id", _userId);
                    }

                    cmd.Parameters.AddWithValue("@n", txtName.Text);
                    cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@r", cmbRole.Text);
                    cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                    cmd.ExecuteNonQuery();
                }
                ValidationHelper.ShowSuccess("Пользователь сохранен!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) ValidationHelper.ShowWarning("Этот логин уже занят!");
                else ValidationHelper.ShowError("Ошибка БД: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }

        // Привязка: выдели txtName в дизайнере -> события -> KeyPress
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}