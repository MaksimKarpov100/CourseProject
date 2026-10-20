using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class UsersForm : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;

        public UsersForm()
        {
            InitializeComponent();
            cmbPageSize.SelectedIndex = 0;
            cmbRoleFilter.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string where = " WHERE 1=1 ";
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                        where += " AND (full_name LIKE @search OR login LIKE @search) ";
                    if (cmbRoleFilter.SelectedIndex > 0)
                        where += " AND role = @role ";

                    MySqlCommand cmdCount = new MySqlCommand("SELECT COUNT(*) FROM users " + where, conn);
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                        cmdCount.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    if (cmbRoleFilter.SelectedIndex > 0)
                        cmdCount.Parameters.AddWithValue("@role", cmbRoleFilter.SelectedItem.ToString());

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;

                    string orderBy = " ORDER BY full_name ASC ";
                    if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY login ASC ";
                    else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY role ASC ";

                    string sql = "SELECT user_id AS `ID`, full_name AS `ФИО`, login AS `Логин`, role AS `Роль`, phone AS `Телефон` FROM users " + where + orderBy + " LIMIT @offset, @pageSize";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    if (cmbRoleFilter.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@role", cmbRoleFilter.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsers.DataSource = dt;
                    if (dgvUsers.Columns["ID"] != null) dgvUsers.Columns["ID"].Visible = false;

                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {
                        if (row.Cells["ФИО"].Value != null) row.Cells["ФИО"].Value = MaskName(row.Cells["ФИО"].Value.ToString());
                        if (row.Cells["Телефон"].Value != null) row.Cells["Телефон"].Value = MaskPhone(row.Cells["Телефон"].Value.ToString());
                    }
                }
                lblCount.Text = "Количество записей: " + totalRecords;
                lblPageInfo.Text = $"Страница {currentPage} из {totalPages}";
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка загрузки: " + ex.Message); }
        }

        private string MaskName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            var parts = name.Split(' ');
            return parts.Length >= 2 ? parts[0] + " " + parts[1][0] + "." + (parts.Length > 2 ? parts[2][0] + "." : "") : name;
        }

        private string MaskPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return "";
            string digits = Regex.Replace(phone, @"\D", "");
            return digits.Length >= 10 ? digits.Substring(digits.Length - 10, 3) + "****" + digits.Substring(digits.Length - 2) : phone;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { currentPage = 1; LoadUsers(); }
        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e) { currentPage = 1; LoadUsers(); }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) { LoadUsers(); }
        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e) { pageSize = int.Parse(cmbPageSize.SelectedItem.ToString()); currentPage = 1; LoadUsers(); }
        private void btnFirst_Click(object sender, EventArgs e) { currentPage = 1; LoadUsers(); }
        private void btnPrev_Click(object sender, EventArgs e) { if (currentPage > 1) currentPage--; LoadUsers(); }
        private void btnNext_Click(object sender, EventArgs e) { if (currentPage < totalPages) currentPage++; LoadUsers(); }
        private void btnLast_Click(object sender, EventArgs e) { currentPage = totalPages; LoadUsers(); }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserEditForm form = new UserEditForm();
            if (form.ShowDialog() == DialogResult.OK) LoadUsers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) { ValidationHelper.ShowWarning("Выберите пользователя"); return; }
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ID"].Value);
            UserEditForm form = new UserEditForm(id);
            if (form.ShowDialog() == DialogResult.OK) LoadUsers();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) { ValidationHelper.ShowWarning("Выберите пользователя"); return; }
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ID"].Value);
            string name = dgvUsers.CurrentRow.Cells["ФИО"].Value.ToString();

            if (id == CurrentUser.UserId) { ValidationHelper.ShowWarning("Вы не можете удалить самого себя!"); return; }

            if (MessageBox.Show($"Удалить пользователя '{name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE user_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadUsers();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451) ValidationHelper.ShowWarning("Этого пользователя нельзя удалить, он оформлял заказы!");
                    else ValidationHelper.ShowError("Ошибка: " + ex.Message);
                }
            }
        }
    }
}