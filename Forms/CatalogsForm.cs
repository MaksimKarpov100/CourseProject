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
        private bool isLoading = true;

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
            isLoading = true;
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

                    if (dt.Columns.Contains("ID"))
                        dt.Columns["ID"].ColumnMapping = MappingType.Hidden;

                    dgvCategories.DataSource = dt;
                    dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvCategories.Columns.Contains("ID"))
                        dgvCategories.Columns["ID"].Visible = false;
                }

                dgvCategories.ClearSelection();
                dgvCategories.CurrentCell = null;
                txtCatName.Clear();
                txtCatDesc.Clear();
                selectedCategoryId = 0;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка категорий: " + ex.Message);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading || dgvCategories.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvCategories.SelectedRows[0];
            DataRowView drv = row.DataBoundItem as DataRowView;
            if (drv == null) return;

            object idValue = drv["ID"];
            if (idValue == null || idValue == DBNull.Value) return;

            selectedCategoryId = Convert.ToInt32(idValue);
            txtCatName.Text = drv["Название"]?.ToString() ?? "";
            txtCatDesc.Text = drv["Описание"]?.ToString() ?? "";
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;
            if (drv == null) return;

            object idValue = drv["ID"];
            if (idValue == null || idValue == DBNull.Value) return;
            int id = Convert.ToInt32(idValue);

            if (!MessageHelper.AskConfirm("Удалить категорию?")) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM categories WHERE category_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Категория удалена");
                LoadCategories();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
        }

        private void btnCatAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatName.Text) || txtCatName.Text.Length < 2)
            {
                MessageHelper.ShowWarning("Введите название (от 2 символов)");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO categories (category_name, description) VALUES (@n, @d)", conn);
                    cmd.Parameters.AddWithValue("@n", txtCatName.Text);
                    cmd.Parameters.AddWithValue("@d", txtCatDesc.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Категория добавлена");
                LoadCategories();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
        }

        private void btnCatEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == 0) { MessageHelper.ShowWarning("Выберите категорию"); return; }
            if (string.IsNullOrWhiteSpace(txtCatName.Text)) { MessageHelper.ShowWarning("Введите название"); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE categories SET category_name=@n, description=@d WHERE category_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedCategoryId);
                    cmd.Parameters.AddWithValue("@n", txtCatName.Text);
                    cmd.Parameters.AddWithValue("@d", txtCatDesc.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Изменения сохранены");
                LoadCategories();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
        }


        private void LoadCustomers()
        {
            isLoading = true;
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

                    if (dt.Columns.Contains("ID"))
                        dt.Columns["ID"].ColumnMapping = MappingType.Hidden;
                    dt.Columns["FullNameOriginal"].ColumnMapping = MappingType.Hidden;
                    dt.Columns["PhoneOriginal"].ColumnMapping = MappingType.Hidden;

                    dgvCustomers.DataSource = dt;
                    dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    if (row.IsNewRow) continue;

                    DataRowView drv = row.DataBoundItem as DataRowView;
                    if (drv == null) continue;

                    string fullName = drv["FullNameOriginal"]?.ToString() ?? "";
                    string phone = drv["PhoneOriginal"]?.ToString() ?? "";

                    if (dgvCustomers.Columns.Contains("ФИО"))
                        row.Cells["ФИО"].ToolTipText = "Полное ФИО: " + fullName;
                    if (dgvCustomers.Columns.Contains("Телефон"))
                        row.Cells["Телефон"].ToolTipText = "Телефон: " + phone;
                }

                dgvCustomers.ClearSelection();
                dgvCustomers.CurrentCell = null;
                txtCustName.Clear();
                mtxtCustPhone.Clear();
                selectedCustomerId = 0;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка клиентов: " + ex.Message);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading || dgvCustomers.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvCustomers.SelectedRows[0];
            DataRowView drv = row.DataBoundItem as DataRowView;
            if (drv == null) return;

            object idValue = drv["ID"];
            if (idValue == null || idValue == DBNull.Value) return;

            selectedCustomerId = Convert.ToInt32(idValue);

            txtCustName.Text = drv["FullNameOriginal"]?.ToString() ?? "";
            mtxtCustPhone.Text = drv["PhoneOriginal"]?.ToString() ?? "";
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;
            if (drv == null) return;

            object idValue = drv["ID"];
            if (idValue == null || idValue == DBNull.Value) return;
            int id = Convert.ToInt32(idValue);

            if (!MessageHelper.AskConfirm("Удалить клиента?")) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM customers WHERE customer_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Клиент удалён");
                LoadCustomers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
        }

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            string fullName = txtCustName.Text.Trim();
            string phone = mtxtCustPhone.Text;

            if (!Validator.CheckFullName(fullName))
            {
                MessageHelper.ShowWarning("ФИО: 3–100 символов, только русские буквы, пробел и дефис");
                return;
            }
            if (!Validator.CheckPhone(phone))
            {
                MessageHelper.ShowWarning("Телефон: формат +7 (XXX) XXX-XX-XX");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO customers (full_name, phone) VALUES (@n, @p)", conn);
                    cmd.Parameters.AddWithValue("@n", fullName);
                    cmd.Parameters.AddWithValue("@p", phone);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Клиент добавлен");
                LoadCustomers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
        }

        private void btnCustEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0) { MessageHelper.ShowWarning("Выберите клиента"); return; }

            string fullName = txtCustName.Text.Trim();
            string phone = mtxtCustPhone.Text;

            if (!Validator.CheckFullName(fullName))
            {
                MessageHelper.ShowWarning("ФИО: 3–100 символов, только русские буквы, пробел и дефис");
                return;
            }
            if (!Validator.CheckPhone(phone))
            {
                MessageHelper.ShowWarning("Телефон: формат +7 (XXX) XXX-XX-XX");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE customers SET full_name=@n, phone=@p WHERE customer_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                    cmd.Parameters.AddWithValue("@n", fullName);
                    cmd.Parameters.AddWithValue("@p", phone);
                    cmd.ExecuteNonQuery();
                }
                MessageHelper.ShowInfo("Изменения сохранены");
                LoadCustomers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
        }


        private void LoadStatuses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT status_id AS `ID`, status_name AS `Название` FROM statuses ORDER BY status_id";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Columns.Contains("ID"))
                        dt.Columns["ID"].ColumnMapping = MappingType.Hidden;

                    dgvStatuses.DataSource = dt;
                    dgvStatuses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvStatuses.Columns.Contains("ID"))
                        dgvStatuses.Columns["ID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
        }

        private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if (char.IsLetter(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), "[А-Яа-яЁё]"))
                e.Handled = true;
        }
    }
}