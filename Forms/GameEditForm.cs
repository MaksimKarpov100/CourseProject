using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class GameEditForm : Form
    {
        private int gameId = 0;
        private byte[] imageBytes = null;

        public GameEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление товара";
        }

        public GameEditForm(int id)
        {
            InitializeComponent();
            this.gameId = id;
            lblTitle.Text = "Редактирование товара";
        }

        private void GameEditForm_Load(object sender, EventArgs e)
        {
            LoadCategories();

            if (gameId > 0)
            {
                LoadGameData();
            }
        }

        private void LoadCategories()
        {
            try
            {
                string sql = "SELECT category_id, category_name FROM categories ORDER BY category_name";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки категорий: " + ex.Message);
            }
        }

        private void LoadGameData()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", gameId);

                string sql = "SELECT title, price, stock_quantity, category_id, image_data FROM board_games WHERE game_id=@id";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["title"].ToString();
                    txtPrice.Text = dt.Rows[0]["price"].ToString();
                    txtStock.Text = dt.Rows[0]["stock_quantity"].ToString();
                    cmbCategory.SelectedValue = dt.Rows[0]["category_id"];

                    if (dt.Rows[0]["image_data"] != DBNull.Value)
                    {
                        imageBytes = (byte[])dt.Rows[0]["image_data"];

                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbImage.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        try
                        {
                            pbImage.Image = Image.FromFile("Resources/picture.png");
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);
            bool isSeparator = (e.KeyChar == ',' || e.KeyChar == '.');

            if (isDigit == false && isControl == false && isSeparator == false)
            {
                e.Handled = true;
            }

            if (isSeparator == true)
            {
                if (txtPrice.Text.Contains(",") == true || txtPrice.Text.Contains(".") == true)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);

            if (isDigit == false && isControl == false)
            {
                e.Handled = true;
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imageBytes = File.ReadAllBytes(ofd.FileName);

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pbImage.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Ошибка загрузки картинки: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) == true)
            {
                MessageHelper.ShowWarning("Введите название игры!");
                return;
            }

            if (ValidationHelper.IsRussianText(title) == false)
            {
                MessageHelper.ShowWarning("Название игры должно содержать только русские буквы и дефис!");
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageHelper.ShowWarning("Выберите категорию!");
                return;
            }

            decimal price = 0;
            bool isPriceValid = decimal.TryParse(txtPrice.Text, out price);

            if (isPriceValid == false)
            {
                MessageHelper.ShowWarning("Введите корректную цену!");
                return;
            }

            if (price < 0 || price > 10000)
            {
                MessageHelper.ShowWarning("Цена должна быть от 0 до 10 000!");
                return;
            }

            int stock = 0;
            bool isStockValid = int.TryParse(txtStock.Text, out stock);

            if (isStockValid == false)
            {
                MessageHelper.ShowWarning("Введите корректное количество!");
                return;
            }

            if (stock < 0 || stock > 1000)
            {
                MessageHelper.ShowWarning("Количество на складе должно быть от 0 до 1 000!");
                return;
            }

            try
            {
                object imageParam = DBNull.Value;
                if (imageBytes != null)
                {
                    imageParam = imageBytes;
                }

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@t", title);
                parameters.Add("@p", price);
                parameters.Add("@s", stock);
                parameters.Add("@c", cmbCategory.SelectedValue);
                parameters.Add("@img", imageParam);

                if (gameId == 0)
                {
                    string sqlInsert = "INSERT INTO board_games (title, price, stock_quantity, category_id, image_data) VALUES (@t, @p, @s, @c, @img)";
                    DatabaseHelper.ExecuteNonQuery(sqlInsert, parameters);
                    MessageHelper.ShowInfo("Товар успешно добавлен!");
                }
                else
                {
                    parameters.Add("@id", gameId);
                    string sqlUpdate = "UPDATE board_games SET title=@t, price=@p, stock_quantity=@s, category_id=@c, image_data=@img WHERE game_id=@id";
                    DatabaseHelper.ExecuteNonQuery(sqlUpdate, parameters);
                    MessageHelper.ShowInfo("Товар успешно обновлен!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка базы данных: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}