using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class CatalogsForm : Form
    {
        private int selectedCategoryId = 0;
        private int selectedCustomerId = 0;

        public CatalogsForm(int startTab)
        {
            InitializeComponent();

            if (startTab >= 0 && startTab < tabCatalogs.TabCount)
            {
                tabCatalogs.SelectedIndex = startTab;
            }

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

                    string sql = "SELECT category_id AS `ID`, category_name AS `Название`, " +
                                 "description AS `Описание` FROM categories ORDER BY category_name";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCategories.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка категорий: " + ex.Message);
            }
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null)
            {
                return;
            }

            selectedCategoryId = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);

            txtCatName.Text = dgvCategories.CurrentRow.Cells["Название"].Value == null
                ? ""
                : dgvCategories.CurrentRow.Cells["Название"].Value.ToString();

            txtCatDesc.Text = dgvCategories.CurrentRow.Cells["Описание"].Value == null
                ? ""
                : dgvCategories.CurrentRow.Cells["Описание"].Value.ToString();
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["ID"].Value);

            if (!MessageHelper.AskConfirm("Удалить категорию?"))
            {
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM categories WHERE category_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Категория удалена");
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка удаления: " + ex.Message);
            }
        }

        private void btnCatAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatName.Text))
            {
                MessageHelper.ShowWarning("Введите название");
                return;
            }

            if (txtCatName.Text.Length < 2 || txtCatName.Text.Length > 100)
            {
                MessageHelper.ShowWarning("Название: от 2 до 100 символов");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO categories (category_name, description) VALUES (@n, @d)", conn);

                    cmd.Parameters.AddWithValue("@n", txtCatName.Text);
                    cmd.Parameters.AddWithValue("@d", txtCatDesc.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Категория добавлена");
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка добавления: " + ex.Message);
            }
        }

        private void btnCatEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == 0)
            {
                MessageHelper.ShowWarning("Выберите категорию");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCatName.Text))
            {
                MessageHelper.ShowWarning("Введите название");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "UPDATE categories SET category_name=@n, description=@d WHERE category_id=@id", conn);

                    cmd.Parameters.AddWithValue("@id", selectedCategoryId);
                    cmd.Parameters.AddWithValue("@n", txtCatName.Text);
                    cmd.Parameters.AddWithValue("@d", txtCatDesc.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Изменения сохранены");
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка изменения: " + ex.Message);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT customer_id AS `ID`, full_name AS `ФИО`, " +
                                 "phone AS `Телефон` FROM customers ORDER BY full_name";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCustomers.DataSource = dt;
                }

                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    string phone = row.Cells["Телефон"].Value == null
                        ? ""
                        : row.Cells["Телефон"].Value.ToString();

                    if (!string.IsNullOrEmpty(phone))
                    {
                        row.Cells["Телефон"].Value = Validator.MaskPhone(phone);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка клиентов: " + ex.Message);
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                return;
            }

            selectedCustomerId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);

            txtCustName.Text = dgvCustomers.CurrentRow.Cells["ФИО"].Value == null
                ? ""
                : dgvCustomers.CurrentRow.Cells["ФИО"].Value.ToString();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "SELECT phone FROM customers WHERE customer_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedCustomerId);

                    object phone = cmd.ExecuteScalar();

                    mtxtCustPhone.Text = phone == null ? "" : phone.ToString();
                }
            }
            catch
            {
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["ID"].Value);

            if (!MessageHelper.AskConfirm("Удалить клиента?"))
            {
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM customers WHERE customer_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Клиент удалён");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка удаления: " + ex.Message);
            }
        }

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            if (!Validator.CheckFullName(txtCustName.Text))
            {
                MessageHelper.ShowWarning("ФИО: только русские буквы");
                return;
            }

            if (!Validator.CheckPhone(mtxtCustPhone.Text))
            {
                MessageHelper.ShowWarning("Телефон: 11 цифр");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO customers (full_name, phone) VALUES (@n, @p)", conn);

                    cmd.Parameters.AddWithValue("@n", txtCustName.Text);
                    cmd.Parameters.AddWithValue("@p", mtxtCustPhone.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Клиент добавлен");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка добавления: " + ex.Message);
            }
        }

        private void btnCustEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0)
            {
                MessageHelper.ShowWarning("Выберите клиента");
                return;
            }

            if (!Validator.CheckFullName(txtCustName.Text))
            {
                MessageHelper.ShowWarning("ФИО: только русские буквы");
                return;
            }

            if (!Validator.CheckPhone(mtxtCustPhone.Text))
            {
                MessageHelper.ShowWarning("Телефон: 11 цифр");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "UPDATE customers SET full_name=@n, phone=@p WHERE customer_id=@id", conn);

                    cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                    cmd.Parameters.AddWithValue("@n", txtCustName.Text);
                    cmd.Parameters.AddWithValue("@p", mtxtCustPhone.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Изменения сохранены");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка изменения: " + ex.Message);
            }
        }

        private void LoadStatuses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT status_id AS `ID`, status_name AS `Название` " +
                                 "FROM statuses ORDER BY status_id";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvStatuses.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка статусов: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}