using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class GameEditForm : Form
    {
        private int _gameId = 0;
        private byte[] _imageBytes = null;

        public GameEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление товара";
        }

        public GameEditForm(int id)
        {
            InitializeComponent();
            _gameId = id;
            lblTitle.Text = "Редактирование товара";
        }

        private void GameEditForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            if (_gameId > 0) LoadGameData();
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT category_id, category_name FROM categories ORDER BY category_name", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "category_name";
                    cmbCategory.ValueMember = "category_id";
                }
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка категорий: " + ex.Message); }
        }

        private void LoadGameData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT title, price, stock_quantity, category_id, image_data FROM board_games WHERE game_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", _gameId);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtName.Text = r["title"].ToString();
                            txtPrice.Text = r["price"].ToString();
                            txtStock.Text = r["stock_quantity"].ToString();
                            cmbCategory.SelectedValue = r["category_id"];

                            if (r["image_data"] != DBNull.Value)
                            {
                                _imageBytes = (byte[])r["image_data"];
                                using (MemoryStream ms = new MemoryStream(_imageBytes)) pbImage.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка загрузки: " + ex.Message); }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbImage.Image = Image.FromFile(ofd.FileName);
                    _imageBytes = File.ReadAllBytes(ofd.FileName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Умные проверки
            if (string.IsNullOrWhiteSpace(txtName.Text)) { ValidationHelper.ShowWarning("Введите название!"); return; }
            if (txtName.Text.Length > 200) { ValidationHelper.ShowWarning("Название слишком длинное (макс 200)!"); return; }
            if (!ValidationHelper.IsRussianText(txtName.Text)) { ValidationHelper.ShowWarning("Название: только русские буквы!"); return; }

            if (!ValidationHelper.IsDigitsOnly(txtPrice.Text)) { ValidationHelper.ShowWarning("Цена должна быть числом!"); return; }
            decimal price = Convert.ToDecimal(txtPrice.Text);
            if (price > 10000) { ValidationHelper.ShowWarning("Цена не может быть больше 10 000!"); return; }

            if (!ValidationHelper.IsDigitsOnly(txtStock.Text)) { ValidationHelper.ShowWarning("Остаток должен быть числом!"); return; }
            int stock = Convert.ToInt32(txtStock.Text);
            if (stock > 1000) { ValidationHelper.ShowWarning("Остаток не может быть больше 1000!"); return; }

            if (cmbCategory.SelectedIndex == -1) { ValidationHelper.ShowWarning("Выберите категорию!"); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = _gameId == 0
                        ? "INSERT INTO board_games (title, price, stock_quantity, category_id, image_data) VALUES (@t, @p, @s, @c, @img)"
                        : "UPDATE board_games SET title=@t, price=@p, stock_quantity=@s, category_id=@c, image_data=@img WHERE game_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@t", txtName.Text);
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", stock);
                    cmd.Parameters.AddWithValue("@c", cmbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@img", _imageBytes ?? (object)DBNull.Value);
                    if (_gameId > 0) cmd.Parameters.AddWithValue("@id", _gameId);
                    cmd.ExecuteNonQuery();
                }
                ValidationHelper.ShowSuccess("Сохранено!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка: " + ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }

        // Привязка: выдели txtPrice в дизайнере -> события (молния) -> KeyPress
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        // Привязка: выдели txtStock в дизайнере -> события (молния) -> KeyPress
        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }
    }
}