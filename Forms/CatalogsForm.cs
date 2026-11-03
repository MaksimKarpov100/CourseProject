using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class CatalogsForm : Form
    {
        public CatalogsForm(int startTab = 0)
        {
            InitializeComponent();

            this.dgvCategories.DataBindingComplete += (s, e) => HideId(dgvCategories);
            this.dgvCustomers.DataBindingComplete += (s, e) => HideId(dgvCustomers);
            this.dgvStatuses.DataBindingComplete += (s, e) => HideId(dgvStatuses);

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

        public void RefreshData()
        {
            LoadCategories();
            LoadCustomers();
            LoadStatuses();
        }

        private void HideId(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name == "ID" || col.HeaderText == "ID" || col.DataPropertyName == "ID")
                {
                    col.Visible = false;
                }
            }
        }

        private void CatalogsForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void LoadCategories()
        {
            string search = txtSearchCat.Text.Trim();
            string whereClause = " WHERE 1=1 ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(search) && search != "Поиск...")
            {
                whereClause = whereClause + " AND category_name LIKE @s ";
                parameters.Add("@s", "%" + search + "%");
            }

            string orderBy = " ORDER BY category_name ASC ";
            if (cmbSortCat.SelectedIndex == 1)
            {
                orderBy = " ORDER BY category_name DESC ";
            }

            string sql = "SELECT category_id AS ID, category_name AS 'Название', description AS 'Описание' FROM categories " + whereClause + orderBy;

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            dgvCategories.DataSource = dt;
        }

        private void txtSearchCat_TextChanged(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void cmbSortCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategories();
        }
        private void LoadCustomers()
        {
            string search = txtSearchCust.Text.Trim();
            string whereClause = " WHERE 1=1 ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(search) && search != "Поиск...")
            {
                whereClause = whereClause + " AND full_name LIKE @s ";
                parameters.Add("@s", "%" + search + "%");
            }

            string orderBy = " ORDER BY full_name ASC ";
            if (cmbSortCust.SelectedIndex == 1)
            {
                orderBy = " ORDER BY full_name DESC ";
            }

            string sql = "SELECT customer_id AS ID, full_name AS 'ФИО', phone AS 'Телефон' FROM customers " + whereClause + orderBy;

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            dgvCustomers.DataSource = dt;

            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                if (row.Cells["Телефон"].Value != null)
                {
                    string phone = row.Cells["Телефон"].Value.ToString();
                    string digits = Regex.Replace(phone, @"\D", "");

                    if (digits.Length >= 10)
                    {
                        string masked = digits.Substring(digits.Length - 10, 3) + "****" + digits.Substring(digits.Length - 2);
                        row.Cells["Телефон"].Value = masked;
                    }
                }
            }
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void cmbSortCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadStatuses()
        {
            string sql = "SELECT status_id AS ID, status_name AS 'Название' FROM statuses";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            dgvStatuses.DataSource = dt;
        }

        private void btnCatAdd_Click(object sender, EventArgs e)
        {
            CategoryEditForm form = new CategoryEditForm();
            form.ShowDialog();
            LoadCategories();
        }

        private void btnCatEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null)
            {
                return;
            }

            int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
            CategoryEditForm form = new CategoryEditForm(id);
            form.ShowDialog();
            LoadCategories();
        }

        private void btnCatDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null)
            {
                return;
            }

            if (MessageHelper.AskConfirm("Удалить выбранную категорию?") == true)
            {
                try
                {
                    int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@id", id);

                    DatabaseHelper.ExecuteNonQuery("DELETE FROM categories WHERE category_id=@id", parameters);
                    MessageHelper.ShowInfo("Категория успешно удалена!");
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Нельзя удалить категорию, так как к ней привязаны товары! " + ex.Message);
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

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            CustomerEditForm form = new CustomerEditForm();
            form.ShowDialog();
            LoadCustomers();
        }

        private void btnCustEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
            CustomerEditForm form = new CustomerEditForm(id);
            form.ShowDialog();
            LoadCustomers();
        }

        private void btnCustDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                return;
            }

            if (MessageHelper.AskConfirm("Удалить выбранного клиента?") == true)
            {
                try
                {
                    int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@id", id);

                    DatabaseHelper.ExecuteNonQuery("DELETE FROM customers WHERE customer_id=@id", parameters);
                    MessageHelper.ShowInfo("Клиент успешно удален!");
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Нельзя удалить клиента, так как у него есть заказы! " + ex.Message);
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
    }
}