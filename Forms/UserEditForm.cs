using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class UserEditForm : Form
    {
        private int userId = 0;

        public UserEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление пользователя";
        }

        public UserEditForm(int id)
        {
            InitializeComponent();
            this.userId = id;
            lblTitle.Text = "Редактирование пользователя";
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            if (userId > 0)
            {
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", userId);

                string sql = "SELECT full_name, login, role, phone FROM users WHERE user_id=@id";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["full_name"].ToString();
                    txtLogin.Text = dt.Rows[0]["login"].ToString();
                    cmbRole.SelectedItem = dt.Rows[0]["role"].ToString();
                    mtxtPhone.Text = dt.Rows[0]["phone"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки данных пользователя: " + ex.Message);
            }
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
            string name = txtName.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(name) == true)
            {
                MessageHelper.ShowWarning("Введите ФИО!");
                return;
            }

            if (ValidationHelper.IsRussianText(name) == false)
            {
                MessageHelper.ShowWarning("ФИО должно содержать только русские буквы и дефис!");
                return;
            }

            if (login.Length < 4 || login.Length > 32)
            {
                MessageHelper.ShowWarning("Логин должен быть от 4 до 32 символов!");
                return;
            }

            if (userId == 0 || string.IsNullOrWhiteSpace(password) == false)
            {
                if (password.Length < 8 || password.Length > 64)
                {
                    MessageHelper.ShowWarning("Пароль должен быть от 8 до 64 символов!");
                    return;
                }
            }

            if (cmbRole.SelectedIndex == -1)
            {
                MessageHelper.ShowWarning("Выберите роль!");
                return;
            }

            try
            {
                if (userId == 0)
                {
                    string hash = PasswordHelper.GetHash(password);

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@n", name);
                    parameters.Add("@l", login);
                    parameters.Add("@p", hash);
                    parameters.Add("@r", cmbRole.SelectedItem.ToString());
                    parameters.Add("@ph", mtxtPhone.Text);

                    string sql = "INSERT INTO users (full_name, login, password_hash, role, phone) VALUES (@n, @l, @p, @r, @ph)";
                    DatabaseHelper.ExecuteNonQuery(sql, parameters);
                }
                else
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@n", name);
                    parameters.Add("@l", login);
                    parameters.Add("@r", cmbRole.SelectedItem.ToString());
                    parameters.Add("@ph", mtxtPhone.Text);
                    parameters.Add("@id", userId);

                    if (string.IsNullOrWhiteSpace(password) == false)
                    {
                        parameters.Add("@p", PasswordHelper.GetHash(password));
                        string sqlWithPass = "UPDATE users SET full_name=@n, login=@l, role=@r, phone=@ph, password_hash=@p WHERE user_id=@id";
                        DatabaseHelper.ExecuteNonQuery(sqlWithPass, parameters);
                    }
                    else
                    {
                        string sqlWithoutPass = "UPDATE users SET full_name=@n, login=@l, role=@r, phone=@ph WHERE user_id=@id";
                        DatabaseHelper.ExecuteNonQuery(sqlWithoutPass, parameters);
                    }
                }

                MessageHelper.ShowInfo("Данные успешно сохранены!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError("Пользователь с таким логином уже существует!");
                }
                else
                {
                    MessageHelper.ShowError("Ошибка базы данных: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Неизвестная ошибка: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}