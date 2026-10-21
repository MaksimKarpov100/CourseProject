using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class CatalogsForm : Form
    {
        private int selectedCategoryId = 0;
        private int selectedCustomerId = 0;

        public CatalogsForm(int startTab = 0)
        {
            InitializeComponent();

            if (CurrentUser.Role == "Товаровед")
            {
                tabCatalogs.TabPages.Remove(tabCustomers);
                tabCatalogs.TabPages.Remove(tabStatuses);
            }
            else if (CurrentUser.Role == "Продавец")
            {
                tabCatalogs.TabPages.Remove(tabCategories);
                tabCatalogs.TabPages.Remove(tabStatuses);
            }

            if (startTab >= 0 && startTab < tabCatalogs.TabCount)
            {
                tabCatalogs.SelectedIndex = startTab;
            }
        }

        private void CatalogsForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadCustomers();
            LoadStatuses();
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT category_id AS ID, category_name AS Название, description AS Описание FROM categories";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCategories.DataSource = dt;

                    if (dgvCategories.Columns.Contains("ID") == true)
                    {
                        dgvCategories.Columns["ID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка категорий: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCatAdd_Click(object sender, EventArgs e)
        {
            CategoryEditForm form = new CategoryEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private void btnCatEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null)
            {
                MessageBox.Show("Выберите категорию", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
            CategoryEditForm form = new CategoryEditForm(id);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private void btnCatDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null)
            {
                MessageBox.Show("Выберите категорию", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
            string name = dgvCategories.CurrentRow.Cells["Название"].Value.ToString();

            DialogResult result = MessageBox.Show("Удалить категорию '" + name + "'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM categories WHERE category_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnCatEdit_Click(sender, e);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT customer_id AS ID, full_name AS ФИО, phone AS Телефон FROM customers";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCustomers.DataSource = dt;

                    if (dgvCustomers.Columns.Contains("ID") == true)
                    {
                        dgvCustomers.Columns["ID"].Visible = false;
                    }
                }

                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    if (row.Cells["Телефон"].Value != null)
                    {
                        string phone = row.Cells["Телефон"].Value.ToString();

                        if (phone.Length >= 10)
                        {
                            string digits = Regex.Replace(phone, @"\D", "");
                            row.Cells["Телефон"].Value = digits.Substring(digits.Length - 10, 3) + "****" + digits.Substring(digits.Length - 2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка клиентов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            CustomerEditForm form = new CustomerEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }

        private void btnCustEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
            CustomerEditForm form = new CustomerEditForm(id);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }

        private void btnCustDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
            string name = dgvCustomers.CurrentRow.Cells["ФИО"].Value.ToString();

            DialogResult result = MessageBox.Show("Удалить клиента '" + name + "'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM customers WHERE customer_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnCustEdit_Click(sender, e);
            }
        }


        private void LoadStatuses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT status_id AS ID, status_name AS Название FROM statuses";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvStatuses.DataSource = dt;

                    if (dgvStatuses.Columns.Contains("ID") == true)
                    {
                        dgvStatuses.Columns["ID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка статусов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}