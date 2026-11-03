using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class CategoryEditForm : Form
    {
        private int categoryId = 0;

        public CategoryEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление категории";
        }

        public CategoryEditForm(int id)
        {
            InitializeComponent();
            this.categoryId = id;
            lblTitle.Text = "Редактирование категории";
        }

        private void CategoryEditForm_Load(object sender, EventArgs e)
        {
            if (categoryId > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", categoryId);

                string sql = "SELECT category_name, description FROM categories WHERE category_id=@id";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["category_name"].ToString();
                    txtDesc.Text = dt.Rows[0]["description"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string description = txtDesc.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) == true)
            {
                MessageHelper.ShowWarning("Введите название категории!");
                return;
            }

            if (ValidationHelper.IsRussianText(name) == false)
            {
                MessageHelper.ShowWarning("Название должно содержать только русские буквы и дефис!");
                return;
            }

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@n", name);
                parameters.Add("@d", description);

                if (categoryId == 0)
                {
                    string sqlInsert = "INSERT INTO categories (category_name, description) VALUES (@n, @d)";
                    DatabaseHelper.ExecuteNonQuery(sqlInsert, parameters);
                    MessageHelper.ShowInfo("Категория успешно добавлена!");
                }
                else
                {
                    parameters.Add("@id", categoryId);
                    string sqlUpdate = "UPDATE categories SET category_name=@n, description=@d WHERE category_id=@id";
                    DatabaseHelper.ExecuteNonQuery(sqlUpdate, parameters);
                    MessageHelper.ShowInfo("Категория успешно обновлена!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("1062") == true)
                {
                    MessageHelper.ShowError("Категория с таким названием уже существует!");
                }
                else
                {
                    MessageHelper.ShowError("Ошибка базы данных: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}