using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class UsersForm : Form
    {
        private int currentPage = 1, pageSize = 10, totalRecords = 0, totalPages = 1, selectedUserId = 0;
        private bool isLoading = true;

        public UsersForm()
        {
            InitializeComponent();
            cmbPageSize.SelectedIndex = 0;
            cmbRoleFilter.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            cmbRoleEdit.SelectedIndex = 0;

            dgvUsers.DataBindingComplete += dgvUsers_DataBindingComplete;

            LoadUsers();
        }

        private void dgvUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowFormatting();
        }

        private void ApplyRowFormatting()
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.IsNewRow) continue;
                DataRowView drv = row.DataBoundItem as DataRowView;
                if (drv == null) continue;

                string role = drv["Роль"]?.ToString() ?? "";

                if (role == "Администратор")
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                else if (role == "Товаровед") row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                else if (role == "Продавец") row.DefaultCellStyle.ForeColor = Color.DarkGreen;
            }
        }

        private void LoadUsers()
        {
            isLoading = true;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string where = " WHERE 1=1 ";
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...") where += " AND full_name LIKE @search ";
                    if (cmbRoleFilter.SelectedIndex > 0) where += " AND role = @role ";

                    string orderBy = " ORDER BY user_id ASC ";
                    if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY login ASC ";
                    else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY role ASC ";

                    MySqlCommand cmdCount = new MySqlCommand("SELECT COUNT(*) FROM users " + where, conn);
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...") cmdCount.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    if (cmbRoleFilter.SelectedIndex > 0) cmdCount.Parameters.AddWithValue("@role", cmbRoleFilter.SelectedItem.ToString());

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    string sql = "SELECT user_id AS `ID`, full_name AS `ФИО`, login AS `Логин`, role AS `Роль`, phone AS `Телефон` FROM users " + where + orderBy + " LIMIT @offset, @pageSize";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...") cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    if (cmbRoleFilter.SelectedIndex > 0) cmd.Parameters.AddWithValue("@role", cmbRoleFilter.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("FullNameOriginal", typeof(string));
                    dt.Columns.Add("PhoneOriginal", typeof(string));

                    foreach (DataRow dr in dt.Rows)
                    {
                        string fullName = dr["ФИО"] == DBNull.Value ? "" : dr["ФИО"].ToString();
                        string phone = dr["Телефон"] == DBNull.Value ? "" : dr["Телефон"].ToString();

                        dr["FullNameOriginal"] = fullName;
                        dr["PhoneOriginal"] = phone;
                        dr["ФИО"] = Validator.MaskFullName(fullName);
                        dr["Телефон"] = Validator.MaskPhone(phone);
                    }

                    if (dt.Columns.Contains("ID")) dt.Columns["ID"].ColumnMapping = MappingType.Hidden;
                    dt.Columns["FullNameOriginal"].ColumnMapping = MappingType.Hidden;
                    dt.Columns["PhoneOriginal"].ColumnMapping = MappingType.Hidden;

                    dgvUsers.DataSource = dt;
                    dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    if (row.IsNewRow) continue;
                    DataRowView drv = row.DataBoundItem as DataRowView;
                    if (drv == null) continue;
                    if (dgvUsers.Columns.Contains("ФИО")) row.Cells["ФИО"].ToolTipText = "Полное ФИО: " + (drv["FullNameOriginal"]?.ToString() ?? "");
                    if (dgvUsers.Columns.Contains("Телефон")) row.Cells["Телефон"].ToolTipText = "Телефон: " + (drv["PhoneOriginal"]?.ToString() ?? "");
                }

                lblCount.Text = "Записей: " + totalRecords;
                lblPageInfo.Text = "Страница " + currentPage + " из " + totalPages;

                isLoading = false;
                if (dgvUsers.CurrentRow != null) dgvUsers_SelectionChanged(dgvUsers, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                isLoading = false;
                MessageHelper.ShowError("Ошибка загрузки: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { currentPage = 1; LoadUsers(); }
        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e) { currentPage = 1; LoadUsers(); }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) { LoadUsers(); }
        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e) { pageSize = int.Parse(cmbPageSize.SelectedItem.ToString()); currentPage = 1; LoadUsers(); }
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
            if (isLoading || dgvUsers.CurrentRow == null) return;
            DataRowView drv = dgvUsers.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            object idValue = drv["ID"];
            if (idValue == null || idValue == DBNull.Value) return;

            selectedUserId = Convert.ToInt32(idValue);
            txtFullName.Text = drv["FullNameOriginal"]?.ToString() ?? "";
            txtLogin.Text = drv["Логин"]?.ToString() ?? "";
            cmbRoleEdit.Text = drv["Роль"]?.ToString() ?? "";
            mtxtPhone.Text = drv["PhoneOriginal"]?.ToString() ?? "";
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView drv = dgvUsers.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;
            object idValue = drv["ID"];
            if (idValue == null || idValue == DBNull.Value) return;
            int id = Convert.ToInt32(idValue);

            if (!MessageHelper.AskConfirm("Удалить пользователя?")) return;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE user_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Пользователь удалён");
                LoadUsers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка удаления: " + ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text)) { MessageHelper.ShowWarning("Введите ФИО"); return; }
            if (!Validator.CheckFullName(txtFullName.Text)) { MessageHelper.ShowWarning("ФИО: только русские буквы, пробел и дефис"); return; }
            if (!Validator.CheckLogin(txtLogin.Text)) { MessageHelper.ShowWarning("Логин: 4-32 символа, латиница, цифры, _"); return; }
            if (!Validator.CheckPassword(txtPassword.Text)) { MessageHelper.ShowWarning("Пароль: 8-64 символа, буквы и цифры"); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand check = new MySqlCommand("SELECT COUNT(*) FROM users WHERE login=@l", conn);
                    check.Parameters.AddWithValue("@l", txtLogin.Text);
                    if (Convert.ToInt32(check.ExecuteScalar()) > 0) { MessageHelper.ShowWarning("Такой логин уже занят"); return; }

                    string hash = PasswordHelper.GetHash(txtPassword.Text);
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO users (full_name, login, password_hash, role, phone) VALUES (@n, @l, @p, @r, @ph)", conn);
                    cmd.Parameters.AddWithValue("@n", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@p", hash);
                    cmd.Parameters.AddWithValue("@r", cmbRoleEdit.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Пользователь добавлен");
                LoadUsers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка добавления: " + ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0) { MessageHelper.ShowWarning("Выберите пользователя"); return; }
            if (!Validator.CheckFullName(txtFullName.Text)) { MessageHelper.ShowWarning("ФИО: только русские буквы"); return; }
            if (!Validator.CheckLogin(txtLogin.Text)) { MessageHelper.ShowWarning("Логин: 4-32 символа"); return; }
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && !Validator.CheckPassword(txtPassword.Text)) { MessageHelper.ShowWarning("Пароль: 8-64 символа"); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql;
                    MySqlCommand cmd;

                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        sql = "UPDATE users SET full_name=@n, login=@l, role=@r, phone=@ph WHERE user_id=@id";
                        cmd = new MySqlCommand(sql, conn);
                    }
                    else
                    {
                        sql = "UPDATE users SET full_name=@n, login=@l, password_hash=@p, role=@r, phone=@ph WHERE user_id=@id";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@p", PasswordHelper.GetHash(txtPassword.Text));
                    }

                    cmd.Parameters.AddWithValue("@id", selectedUserId);
                    cmd.Parameters.AddWithValue("@n", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@r", cmbRoleEdit.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ph", mtxtPhone.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Изменения сохранены");
                LoadUsers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка изменения: " + ex.Message); }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0) { MessageHelper.ShowWarning("Сначала выберите пользователя"); return; }
            string login = dgvUsers.CurrentRow?.Cells["Логин"].Value?.ToString() ?? "";
            ChangePasswordForm form = new ChangePasswordForm(selectedUserId, login);
            form.ShowDialog();
            LoadUsers();
        }
    }
}