using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class CategoryEditForm : Form
    {
        private int _categoryId = 0;

        public CategoryEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление категории";
        }

        public CategoryEditForm(int id)
        {
            InitializeComponent();
            _categoryId = id;
            lblTitle.Text = "Редактирование категории";
        }

        private void CategoryEditForm_Load(object sender, EventArgs e)
        {
            if (_categoryId > 0)
            {
                try
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
                catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message); }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(name, @"^[А-Яа-яЁё\s\-]+$"))
            {
                MessageBox.Show("Название должно содержать только русские буквы и дефис!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = _categoryId == 0
                        ? "INSERT INTO categories (category_name, description) VALUES (@n, @d)"
                        : "UPDATE categories SET category_name=@n, description=@d WHERE category_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@d", txtDesc.Text.Trim());
                    if (_categoryId > 0) cmd.Parameters.AddWithValue("@id", _categoryId);
                    cmd.ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) MessageBox.Show("Категория с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Ошибка БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
    }
}