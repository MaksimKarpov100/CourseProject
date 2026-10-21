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
            txtPrice.KeyPress += txtPrice_KeyPress;
            txtStock.KeyPress += txtStock_KeyPress;
        }

        public GameEditForm(int gameId)
        {
            InitializeComponent();
            _gameId = gameId;
            lblTitle.Text = "Редактирование товара";
            txtPrice.KeyPress += txtPrice_KeyPress;
            txtStock.KeyPress += txtStock_KeyPress;
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
            catch (Exception ex) { MessageBox.Show("Ошибка категорий: " + ex.Message); }
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
                                using (MemoryStream ms = new MemoryStream(_imageBytes)) { pbImage.Image = Image.FromStream(ms); }
                            }
                            else
                            {
                                try { pbImage.Image = Image.FromFile("Resources/picture.png"); } catch { }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message); }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && !char.IsControl(e.KeyChar)) e.Handled = true;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txtPrice.Text.Contains(",") || txtPrice.Text.Contains("."))) e.Handled = true;
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _imageBytes = File.ReadAllBytes(ofd.FileName);
                        using (MemoryStream ms = new MemoryStream(_imageBytes)) { pbImage.Image = Image.FromStream(ms); }
                    }
                    catch (Exception ex) { MessageBox.Show("Ошибка картинки: " + ex.Message); }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price = 0;
            decimal.TryParse(txtPrice.Text, out price);
            int stock = 0;
            int.TryParse(txtStock.Text, out stock);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql;

                    if (_gameId == 0)
                        sql = "INSERT INTO board_games (title, price, stock_quantity, category_id, image_data) VALUES (@t, @p, @s, @c, @img)";
                    else
                        sql = "UPDATE board_games SET title=@t, price=@p, stock_quantity=@s, category_id=@c, image_data=@img WHERE game_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@t", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", stock);
                    cmd.Parameters.AddWithValue("@c", cmbCategory.SelectedValue);

                    if (_imageBytes != null)
                        cmd.Parameters.AddWithValue("@img", _imageBytes);
                    else
                        cmd.Parameters.AddWithValue("@img", DBNull.Value);

                    if (_gameId > 0) cmd.Parameters.AddWithValue("@id", _gameId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
    }
}