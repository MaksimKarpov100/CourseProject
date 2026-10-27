using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class CatalogsForm : Form
    {
        private int pageCat = 1, totalCatPages = 1;
        private int pageCust = 1, totalCustPages = 1;
        private int pageSize = 10;

        public CatalogsForm(int startTab = 0)
        {
            InitializeComponent();
            this.dgvCategories.DataBindingComplete += (s, e) => HideId(dgvCategories);
            this.dgvCustomers.DataBindingComplete += (s, e) => HideId(dgvCustomers);
            this.dgvStatuses.DataBindingComplete += (s, e) => HideId(dgvStatuses);

            if (CurrentUser.Role == "Товаровед") { tabCatalogs.TabPages.Remove(tabCustomers); tabCatalogs.TabPages.Remove(tabStatuses); }
            else if (CurrentUser.Role == "Продавец") { tabCatalogs.TabPages.Remove(tabCategories); tabCatalogs.TabPages.Remove(tabStatuses); }

            if (startTab >= 0 && startTab < tabCatalogs.TabCount) tabCatalogs.SelectedIndex = startTab;
        }

        public void RefreshData() { LoadCategories(); LoadCustomers(); LoadStatuses(); }

        private void HideId(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
                if (col.Name == "ID" || col.HeaderText == "ID" || col.DataPropertyName == "ID") col.Visible = false;
        }

        private void CatalogsForm_Load(object sender, EventArgs e) { RefreshData(); }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string where = " WHERE 1=1 ";
                    string search = txtSearchCat.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(search) && search != "Поиск...") where += " AND category_name LIKE @s ";

                    MySqlCommand cmdC = new MySqlCommand("SELECT COUNT(*) FROM categories " + where, conn);
                    if (!string.IsNullOrWhiteSpace(search) && search != "Поиск...") cmdC.Parameters.AddWithValue("@s", "%" + search + "%");
                    totalCatPages = (int)Math.Ceiling((double)Convert.ToInt32(cmdC.ExecuteScalar()) / pageSize);
                    if (totalCatPages < 1) totalCatPages = 1;
                    if (pageCat > totalCatPages) pageCat = totalCatPages;

                    MySqlCommand cmd = new MySqlCommand("SELECT category_id AS ID, category_name AS Название, description AS Описание FROM categories " + where + " LIMIT @o, @p", conn);
                    if (!string.IsNullOrWhiteSpace(search) && search != "Поиск...") cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                    cmd.Parameters.AddWithValue("@o", (pageCat - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@p", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    dgvCategories.DataSource = dt;
                    lblPageCat.Text = $"Страница {pageCat} из {totalCatPages}";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void txtSearchCat_TextChanged(object sender, EventArgs e) { pageCat = 1; LoadCategories(); }
        private void btnCatPrev_Click(object sender, EventArgs e) { if (pageCat > 1) { pageCat--; LoadCategories(); } }
        private void btnCatNext_Click(object sender, EventArgs e) { if (pageCat < totalCatPages) { pageCat++; LoadCategories(); } }

        private void LoadCustomers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string where = " WHERE 1=1 ";
                    string search = txtSearchCust.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(search) && search != "Поиск...") where += " AND full_name LIKE @s ";

                    MySqlCommand cmdC = new MySqlCommand("SELECT COUNT(*) FROM customers " + where, conn);
                    if (!string.IsNullOrWhiteSpace(search) && search != "Поиск...") cmdC.Parameters.AddWithValue("@s", "%" + search + "%");
                    totalCustPages = (int)Math.Ceiling((double)Convert.ToInt32(cmdC.ExecuteScalar()) / pageSize);
                    if (totalCustPages < 1) totalCustPages = 1;
                    if (pageCust > totalCustPages) pageCust = totalCustPages;

                    MySqlCommand cmd = new MySqlCommand("SELECT customer_id AS ID, full_name AS ФИО, phone AS Телефон FROM customers " + where + " LIMIT @o, @p", conn);
                    if (!string.IsNullOrWhiteSpace(search) && search != "Поиск...") cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                    cmd.Parameters.AddWithValue("@o", (pageCust - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@p", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    dgvCustomers.DataSource = dt;
                    lblPageCust.Text = $"Страница {pageCust} из {totalCustPages}";

                    foreach (DataGridViewRow row in dgvCustomers.Rows)
                    {
                        if (row.Cells["Телефон"].Value != null)
                        {
                            string digits = Regex.Replace(row.Cells["Телефон"].Value.ToString(), @"\D", "");
                            if (digits.Length >= 10) row.Cells["Телефон"].Value = digits.Substring(digits.Length - 10, 3) + "****" + digits.Substring(digits.Length - 2);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void txtSearchCust_TextChanged(object sender, EventArgs e) { pageCust = 1; LoadCustomers(); }
        private void btnCustPrev_Click(object sender, EventArgs e) { if (pageCust > 1) { pageCust--; LoadCustomers(); } }
        private void btnCustNext_Click(object sender, EventArgs e) { if (pageCust < totalCustPages) { pageCust++; LoadCustomers(); } }

        private void LoadStatuses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT status_id AS ID, status_name AS Название FROM statuses", conn);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    dgvStatuses.DataSource = dt;
                }
            }
            catch { }
        }

        private void btnCatAdd_Click(object sender, EventArgs e) { new CategoryEditForm().ShowDialog(); LoadCategories(); }
        private void btnCatEdit_Click(object sender, EventArgs e) { if (dgvCategories.CurrentRow == null) return; new CategoryEditForm(Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value)).ShowDialog(); LoadCategories(); }
        private void btnCatDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM categories WHERE category_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", dgvCategories.CurrentRow.Cells["ID"].Value);
                        cmd.ExecuteNonQuery();
                    }
                    LoadCategories();
                }
                catch (MySqlException ex) { if (ex.Number == 1451) MessageBox.Show("Нельзя удалить, есть товары!"); }
            }
        }
        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) btnCatEdit_Click(sender, e); }

        private void btnCustAdd_Click(object sender, EventArgs e) { new CustomerEditForm().ShowDialog(); LoadCustomers(); }
        private void btnCustEdit_Click(object sender, EventArgs e) { if (dgvCustomers.CurrentRow == null) return; new CustomerEditForm(Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value)).ShowDialog(); LoadCustomers(); }
        private void btnCustDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM customers WHERE customer_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", dgvCustomers.CurrentRow.Cells["ID"].Value);
                        cmd.ExecuteNonQuery();
                    }
                    LoadCustomers();
                }
                catch (MySqlException ex) { if (ex.Number == 1451) MessageBox.Show("Нельзя удалить, есть заказы!"); }
            }
        }
        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) btnCustEdit_Click(sender, e); }
    }
}