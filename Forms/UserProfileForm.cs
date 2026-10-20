using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class UserProfileForm : Form
    {
        public UserProfileForm()
        {
            InitializeComponent();
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            txtName.Text = CurrentUser.FullName;
            txtRole.Text = CurrentUser.Role;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT login, phone FROM users WHERE user_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", CurrentUser.UserId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtLogin.Text = r["login"].ToString();

                            // Маскировка телефона по ТЗ
                            string phone = r["phone"].ToString();
                            if (phone.Length >= 10)
                            {
                                string digits = Regex.Replace(phone, @"\D", "");
                                txtPhone.Text = digits.Substring(digits.Length - 10, 3) + "****" + digits.Substring(digits.Length - 2);
                            }
                            else
                            {
                                txtPhone.Text = phone;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка: " + ex.Message); }
        }

        // --- ВЫЗОВ ФОРМЫ СМЕНЫ ПАРОЛЯ ---
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            // Открываем ту самую форму, которую мы сделали
            ChangePasswordForm form = new ChangePasswordForm();
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}