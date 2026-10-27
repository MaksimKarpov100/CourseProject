using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class UserEditForm : Form
    {
        private int _userId = 0;

        public UserEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление пользователя";
        }

        public UserEditForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            lblTitle.Text = "Редактирование пользователя";
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            if (_userId > 0) LoadUserData();
        }

        private void LoadUserData()
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
                            cmbRole.SelectedItem = r["role"].ToString();
                            mtxtPhone.Text = r["phone"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●') { txtPassword.PasswordChar = '\0'; btnShowPass.Text = "🙈"; }
            else { txtPassword.PasswordChar = '●'; btnShowPass.Text = "👁"; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите ФИО!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(name, @"^[А-Яа-яЁё\s\-]+$"))
            {
                MessageBox.Show("ФИО должно содержать только русские буквы и дефис!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (login.Length < 4 || login.Length > 32)
            {
                MessageBox.Show("Логин должен быть от 4 до 32 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userId == 0 || !string.IsNullOrWhiteSpace(password))
            {
                if (password.Length < 8 || password.Length > 64)
                {
                    MessageBox.Show("Пароль должен быть от 8 до 64 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите роль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql;

                    if (_userId == 0)
                    {
                        string hash = PasswordHelper.GetHash(password);
                        sql = "INSERT INTO users (full_name, login, password_hash, role, phone) VALUES (@n, @l, @p, @r, @ph)";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@p", hash);
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@l", login);
                        cmd.Parameters.AddWithValue("@r", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sql = "UPDATE users SET full_name=@n, login=@l, role=@r, phone=@ph";
                        if (!string.IsNullOrWhiteSpace(password)) sql += ", password_hash=@p";
                        sql += " WHERE user_id=@id";

                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@l", login);
                        cmd.Parameters.AddWithValue("@r", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                        cmd.Parameters.AddWithValue("@id", _userId);

                        if (!string.IsNullOrWhiteSpace(password))
                            cmd.Parameters.AddWithValue("@p", PasswordHelper.GetHash(password));

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
    }
}