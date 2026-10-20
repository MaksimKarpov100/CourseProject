using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class CategoryEditForm : Form
    {
        private int _categoryId = 0;

        public CategoryEditForm() { InitializeComponent(); lblTitle.Text = "Добавление категории"; }
        public CategoryEditForm(int id) { InitializeComponent(); _categoryId = id; lblTitle.Text = "Редактирование категории"; }

        private void CategoryEditForm_Load(object sender, EventArgs e)
        {
            if (_categoryId > 0)
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT category_name, description FROM categories WHERE category_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", _categoryId);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtName.Text = r["category_name"].ToString();
                            txtDesc.Text = r["description"].ToString();
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Введите название!"); return; }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = _categoryId == 0
                        ? "INSERT INTO categories (category_name, description) VALUES (@n, @d)"
                        : "UPDATE categories SET category_name=@n, description=@d WHERE category_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtName.Text);
                    cmd.Parameters.AddWithValue("@d", txtDesc.Text);
                    if (_categoryId > 0) cmd.Parameters.AddWithValue("@id", _categoryId);
                    cmd.ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка: " + ex.Message); }
        }
        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
    }
}