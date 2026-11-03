using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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

        public void RefreshData()
        {
            LoadUsers();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                string whereClause = " WHERE 1=1 ";
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (string.IsNullOrWhiteSpace(txtSearch.Text) == false && txtSearch.Text != "Поиск...")
                {
                    whereClause = whereClause + " AND (full_name LIKE @search OR login LIKE @search) ";
                    parameters.Add("@search", "%" + txtSearch.Text + "%");
                }

                if (cmbRoleFilter.SelectedIndex > 0)
                {
                    whereClause = whereClause + " AND role = @role ";
                    parameters.Add("@role", cmbRoleFilter.SelectedItem.ToString());
                }

                string countSql = "SELECT COUNT(*) FROM users " + whereClause;
                totalRecords = Convert.ToInt32(DatabaseHelper.ExecuteScalar(countSql, parameters));

                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                if (totalPages < 1)
                {
                    totalPages = 1;
                }
                if (currentPage > totalPages)
                {
                    currentPage = totalPages;
                }

                string orderBy = " ORDER BY full_name ASC ";
                if (cmbSort.SelectedIndex == 1)
                {
                    orderBy = " ORDER BY login ASC ";
                }
                else if (cmbSort.SelectedIndex == 2)
                {
                    orderBy = " ORDER BY role ASC ";
                }

                string sqlData = "SELECT user_id AS ID, full_name AS 'ФИО', login AS 'Логин', role AS 'Роль', phone AS 'Телефон' FROM users " + whereClause + orderBy + " LIMIT @offset, @pageSize";

                parameters.Add("@offset", (currentPage - 1) * pageSize);
                parameters.Add("@pageSize", pageSize);

                DataTable dt = DatabaseHelper.ExecuteQuery(sqlData, parameters);
                dgvUsers.DataSource = dt;

                if (dgvUsers.Columns.Contains("ID") == true)
                {
                    dgvUsers.Columns["ID"].Visible = false;
                }

                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    if (row.Cells["ФИО"].Value != null)
                    {
                        row.Cells["ФИО"].Value = MaskName(row.Cells["ФИО"].Value.ToString());
                    }
                    if (row.Cells["Телефон"].Value != null)
                    {
                        row.Cells["Телефон"].Value = MaskPhone(row.Cells["Телефон"].Value.ToString());
                    }
                }

                lblCount.Text = "Количество записей: " + totalRecords;
                lblPageInfo.Text = "Страница " + currentPage + " из " + totalPages;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки пользователей: " + ex.Message);
            }
        }

        private string MaskName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) == true)
            {
                return "";
            }

            string[] parts = name.Split(' ');

            if (parts.Length >= 2)
            {
                string result = parts[0] + " " + parts[1][0] + ".";

                if (parts.Length > 2)
                {
                    result = result + parts[2][0] + ".";
                }

                return result;
            }

            return name;
        }

        private string MaskPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) == true)
            {
                return "";
            }

            string digits = Regex.Replace(phone, @"\D", "");

            if (digits.Length >= 10)
            {
                string start = digits.Substring(digits.Length - 10, 3);
                string end = digits.Substring(digits.Length - 2);
                return start + "****" + end;
            }

            return phone;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadUsers();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Поиск...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) == true)
            {
                txtSearch.Text = "Поиск...";
                txtSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadUsers();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPageSize.SelectedItem != null)
            {
                pageSize = int.Parse(cmbPageSize.SelectedItem.ToString());
                currentPage = 1;
                LoadUsers();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadUsers();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            LoadUsers();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
            }
            LoadUsers();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserEditForm form = new UserEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageHelper.ShowWarning("Выберите пользователя!");
                return;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ID"].Value);
            UserEditForm form = new UserEditForm(id);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageHelper.ShowWarning("Выберите пользователя!");
                return;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ID"].Value);
            string name = dgvUsers.CurrentRow.Cells["ФИО"].Value.ToString();

            if (id == CurrentUser.UserId)
            {
                MessageHelper.ShowWarning("Вы не можете удалить самого себя!");
                return;
            }

            if (MessageHelper.AskConfirm("Удалить пользователя '" + name + "'?") == true)
            {
                try
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@id", id);

                    DatabaseHelper.ExecuteNonQuery("DELETE FROM users WHERE user_id=@id", parameters);
                    MessageHelper.ShowInfo("Пользователь успешно удален!");
                    LoadUsers();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451)
                    {
                        MessageHelper.ShowError("Этого пользователя нельзя удалить, так как он оформлял заказы!");
                    }
                    else
                    {
                        MessageHelper.ShowError("Ошибка базы данных: " + ex.Message);
                    }
                }
            }
        }
    }
}