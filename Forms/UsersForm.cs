using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class UsersForm : Form
    {
        private static string ConnectionString => DbConfig.BuildConnectionString();

        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private int selectedUserId = 0;

        public UsersForm()
        {
            InitializeComponent();
            cmbPageSize.SelectedIndex = 0;
            cmbRoleFilter.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            cmbRoleEdit.SelectedIndex = 0;
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string where = " WHERE 1=1 ";
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                        where += " AND full_name LIKE @search ";
                    if (cmbRoleFilter.SelectedIndex > 0)
                        where += " AND role = @role ";

                    string orderBy = " ORDER BY user_id ASC ";
                    switch (cmbSort.SelectedIndex)
                    {
                        case 1: orderBy = " ORDER BY login ASC "; break;
                        case 2: orderBy = " ORDER BY role ASC "; break;
                    }

                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM users " + where, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                        if (cmbRoleFilter.SelectedIndex > 0)
                            cmd.Parameters.AddWithValue("@role", cmbRoleFilter.SelectedItem.ToString());
                        totalRecords = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    string sql = "SELECT user_id AS `ID`, full_name AS `ФИО`, login AS `Логин`, " +
                                 "role AS `Роль`, phone AS `Телефон` FROM users " +
                                 where + orderBy + " LIMIT @offset, @pageSize";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                        if (cmbRoleFilter.SelectedIndex > 0)
                            cmd.Parameters.AddWithValue("@role", cmbRoleFilter.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvUsers.DataSource = dt;
                        }
                    }
                }

                ApplyRowFormatting();
                lblCount.Text = "Записей: " + totalRecords;
                lblPageInfo.Text = "Страница " + currentPage + " из " + totalPages;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void ApplyRowFormatting()
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                string phone = row.Cells["Телефон"].Value == null ? "" : row.Cells["Телефон"].Value.ToString();
                string digits = Regex.Replace(phone, @"\D", "");
                if (digits.Length >= 10)
                    row.Cells["Телефон"].Value = digits.Substring(1, 3) + "****" + digits.Substring(digits.Length - 2);

                string role = row.Cells["Роль"].Value == null ? "" : row.Cells["Роль"].Value.ToString();
                if (role == "Администратор")
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                    row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                }
                else if (role == "Товаровед") row.DefaultCellStyle.ForeColor = Color.FromArgb(41, 128, 185);
                else if (role == "Продавец") row.DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { currentPage = 1; LoadUsers(); }
        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e) { currentPage = 1; LoadUsers(); }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) { LoadUsers(); }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = int.Parse(cmbPageSize.SelectedItem.ToString());
            currentPage = 1;
            LoadUsers();
        }

        private void btnFirst_Click(object sender, EventArgs e) { currentPage = 1; LoadUsers(); }
        private void btnPrev_Click(object sender, EventArgs e) { if (currentPage > 1) currentPage--; LoadUsers(); }
        private void btnNext_Click(object sender, EventArgs e) { if (currentPage < totalPages) currentPage++; LoadUsers(); }
        private void btnLast_Click(object sender, EventArgs e) { currentPage = totalPages; LoadUsers(); }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Поиск...";
            cmbRoleFilter.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            currentPage = 1;
            LoadUsers();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            selectedUserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ID"].Value);
            txtFullName.Text = dgvUsers.CurrentRow.Cells["ФИО"].Value == null ? "" : dgvUsers.CurrentRow.Cells["ФИО"].Value.ToString();
            txtLogin.Text = dgvUsers.CurrentRow.Cells["Логин"].Value == null ? "" : dgvUsers.CurrentRow.Cells["Логин"].Value.ToString();
            cmbRoleEdit.Text = dgvUsers.CurrentRow.Cells["Роль"].Value == null ? "" : dgvUsers.CurrentRow.Cells["Роль"].Value.ToString();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT phone FROM users WHERE user_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedUserId);
                        object phone = cmd.ExecuteScalar();
                        mtxtPhone.Text = phone == null ? "" : phone.ToString();
                    }
                }
            }
            catch { }
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["ID"].Value);
            if (MessageBox.Show("Удалить пользователя?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE user_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadUsers();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            { MessageBox.Show("Заполните обязательные поля"); return; }
            if (txtLogin.Text.Length < 4 || txtLogin.Text.Length > 32)
            { MessageBox.Show("Логин: 4-32 символа"); return; }
            if (txtPassword.Text.Length < 8 || txtPassword.Text.Length > 64)
            { MessageBox.Show("Пароль: 8-64 символа"); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO users (full_name, login, password_hash, role, phone) " +
                        "VALUES (@n,@l,@p,@r,@ph)", conn))
                    {
                        cmd.Parameters.AddWithValue("@n", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                        cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@r", cmbRoleEdit.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadUsers();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0) { MessageBox.Show("Выберите пользователя"); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = string.IsNullOrWhiteSpace(txtPassword.Text)
                        ? "UPDATE users SET full_name=@n, login=@l, role=@r, phone=@ph WHERE user_id=@id"
                        : "UPDATE users SET full_name=@n, login=@l, password_hash=@p, role=@r, phone=@ph WHERE user_id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedUserId);
                        cmd.Parameters.AddWithValue("@n", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                        cmd.Parameters.AddWithValue("@r", cmbRoleEdit.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                            cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadUsers();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}