using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class UserProfileForm : Form
    {
        public UserProfileForm()
        {
            InitializeComponent();
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT login, phone FROM users WHERE user_id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", CurrentUser.UserId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtFullName.Text = CurrentUser.FullName;
                            txtLogin.Text = r["login"].ToString();
                            txtRole.Text = CurrentUser.Role;
                            txtPhone.Text = string.IsNullOrWhiteSpace(r["phone"].ToString())
                                            ? "Не указан"
                                            : r["phone"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки профиля: " + ex.Message);
            }

            txtFullName.ReadOnly = true;
            txtLogin.ReadOnly = true;
            txtRole.ReadOnly = true;
            txtPhone.ReadOnly = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}