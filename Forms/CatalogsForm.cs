using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class CatalogsForm : Form
    {
        private static string ConnectionString => DbConfig.BuildConnectionString();

        private int selectedCategoryId = 0;
        private int selectedCustomerId = 0;

        public CatalogsForm(int startTab)
        {
            InitializeComponent();
            if (startTab >= 0 && startTab < tabCatalogs.TabCount)
                tabCatalogs.SelectedIndex = startTab;

            LoadCategories();
            LoadCustomers();
            LoadStatuses();
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT category_id AS `ID`, category_name AS `Название`, " +
                                 "description AS `Описание` FROM categories ORDER BY category_name";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    { DataTable dt = new DataTable(); da.Fill(dt); dgvCategories.DataSource = dt; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;
            selectedCategoryId = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
            txtCatName.Text = dgvCategories.CurrentRow.Cells["Название"].Value == null ? "" : dgvCategories.CurrentRow.Cells["Название"].Value.ToString();
            txtCatDesc.Text = dgvCategories.CurrentRow.Cells["Описание"].Value == null ? "" : dgvCategories.CurrentRow.Cells["Описание"].Value.ToString();
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int id = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["ID"].Value);
            if (MessageBox.Show("Удалить категорию?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM categories WHERE category_id=@id", conn))
                    { cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); }
                }
                LoadCategories();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnCatAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatName.Text)) { MessageBox.Show("Введите название"); return; }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO categories (category_name, description) VALUES (@n,@d)", conn))
                    {
                        cmd.Parameters.AddWithValue("@n", txtCatName.Text);
                        cmd.Parameters.AddWithValue("@d", txtCatDesc.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadCategories();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnCatEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == 0) { MessageBox.Show("Выберите категорию"); return; }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE categories SET category_name=@n, description=@d WHERE category_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedCategoryId);
                        cmd.Parameters.AddWithValue("@n", txtCatName.Text);
                        cmd.Parameters.AddWithValue("@d", txtCatDesc.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadCategories();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void LoadCustomers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT customer_id AS `ID`, full_name AS `ФИО`, " +
                                 "phone AS `Телефон` FROM customers ORDER BY full_name";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    { DataTable dt = new DataTable(); da.Fill(dt); dgvCustomers.DataSource = dt; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            selectedCustomerId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
            txtCustName.Text = dgvCustomers.CurrentRow.Cells["ФИО"].Value == null ? "" : dgvCustomers.CurrentRow.Cells["ФИО"].Value.ToString();
            mtxtCustPhone.Text = dgvCustomers.CurrentRow.Cells["Телефон"].Value == null ? "" : dgvCustomers.CurrentRow.Cells["Телефон"].Value.ToString();
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int id = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["ID"].Value);
            if (MessageBox.Show("Удалить клиента?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM customers WHERE customer_id=@id", conn))
                    { cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); }
                }
                LoadCustomers();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustName.Text)) { MessageBox.Show("Введите ФИО"); return; }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO customers (full_name, phone) VALUES (@n,@p)", conn))
                    {
                        cmd.Parameters.AddWithValue("@n", txtCustName.Text);
                        cmd.Parameters.AddWithValue("@p", mtxtCustPhone.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadCustomers();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnCustEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0) { MessageBox.Show("Выберите клиента"); return; }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE customers SET full_name=@n, phone=@p WHERE customer_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                        cmd.Parameters.AddWithValue("@n", txtCustName.Text);
                        cmd.Parameters.AddWithValue("@p", mtxtCustPhone.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadCustomers();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void LoadStatuses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT status_id AS `ID`, status_name AS `Название` FROM statuses ORDER BY status_id";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    { DataTable dt = new DataTable(); da.Fill(dt); dgvStatuses.DataSource = dt; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}