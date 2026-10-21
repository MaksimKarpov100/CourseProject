using System;
using System.Data;
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
            if (_userId > 0)
            {
                LoadUserData();
            }
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
            catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message); }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
                btnShowPass.Text = "🙈";
            }
            else
            {
                txtPassword.PasswordChar = '●';
                btnShowPass.Text = "👁";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Заполните ФИО и Логин!", "Внимание");
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
                        if (string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            MessageBox.Show("Введите пароль!", "Внимание");
                            return;
                        }
                        string hash = PasswordHelper.GetHash(txtPassword.Text);
                        sql = "INSERT INTO users (full_name, login, password_hash, role, phone) VALUES (@n, @l, @p, @r, @ph)";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@p", hash);
                        cmd.Parameters.AddWithValue("@n", txtName.Text);
                        cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                        cmd.Parameters.AddWithValue("@r", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sql = "UPDATE users SET full_name=@n, login=@l, role=@r, phone=@ph";
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            sql += ", password_hash=@p";
                        }
                        sql += " WHERE user_id=@id";

                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@n", txtName.Text);
                        cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                        cmd.Parameters.AddWithValue("@r", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                        cmd.Parameters.AddWithValue("@id", _userId);

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                            cmd.Parameters.AddWithValue("@p", PasswordHelper.GetHash(txtPassword.Text));

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Сохранено!", "Успех");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
    }
}