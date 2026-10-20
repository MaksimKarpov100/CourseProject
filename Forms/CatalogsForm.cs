using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class CatalogsForm : Form
    {
        public CatalogsForm(int startTab = 0)
        {
            InitializeComponent();

            if (startTab >= 0 && startTab < tabCatalogs.TabCount)
                tabCatalogs.SelectedIndex = startTab;


            dgvCategories.DataBindingComplete += (s, e) => HideIdColumn(dgvCategories);
            dgvCustomers.DataBindingComplete += (s, e) => HideIdColumn(dgvCustomers);
            dgvStatuses.DataBindingComplete += (s, e) => HideIdColumn(dgvStatuses);
        }

        private void HideIdColumn(DataGridView dgv)
        {
            if (dgv.Columns.Contains("ID"))
            {
                dgv.Columns["ID"].Visible = false;
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
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT category_id AS ID, category_name AS Название, description AS Описание FROM categories", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCategories.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка категорий: " + ex.Message); }
        }

        private void btnCatAdd_Click(object sender, EventArgs e)
        {
            CategoryEditForm form = new CategoryEditForm();
            if (form.ShowDialog() == DialogResult.OK) LoadCategories();
        }

        private void btnCatEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
            CategoryEditForm form = new CategoryEditForm(id);
            if (form.ShowDialog() == DialogResult.OK) LoadCategories();
        }

        private void btnCatDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
            string name = dgvCategories.CurrentRow.Cells["Название"].Value.ToString();

            if (MessageBox.Show($"Удалить категорию '{name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
            }
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnCatEdit_Click(sender, e);
        }

        private void LoadCustomers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT customer_id AS ID, full_name AS ФИО, phone AS Телефон FROM customers", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCustomers.DataSource = dt;
                }

                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    string phone = row.Cells["Телефон"].Value?.ToString() ?? "";
                    if (phone.Length >= 10)
                    {
                        string digits = Regex.Replace(phone, @"\D", "");
                        row.Cells["Телефон"].Value = digits.Substring(digits.Length - 10, 3) + "****" + digits.Substring(digits.Length - 2);
                    }
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка клиентов: " + ex.Message); }
        }

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            CustomerEditForm form = new CustomerEditForm();
            if (form.ShowDialog() == DialogResult.OK) LoadCustomers();
        }

        private void btnCustEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
            CustomerEditForm form = new CustomerEditForm(id);
            if (form.ShowDialog() == DialogResult.OK) LoadCustomers();
        }

        private void btnCustDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
            string name = dgvCustomers.CurrentRow.Cells["ФИО"].Value.ToString();

            if (MessageBox.Show($"Удалить клиента '{name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnCustEdit_Click(sender, e);
        }

        private void LoadStatuses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT status_id AS ID, status_name AS Название FROM statuses", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStatuses.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка статусов: " + ex.Message); }
        }
    }
}