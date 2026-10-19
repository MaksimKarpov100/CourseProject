using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class GameEditForm : Form
    {
        private int _gameId = 0;

        public GameEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление товара";
        }

        public GameEditForm(int gameId)
        {
            InitializeComponent();
            _gameId = gameId;
            lblTitle.Text = "Редактирование товара";
        }

        private void GameEditForm_Load(object sender, EventArgs e)
        {
            LoadCategories();

            if (_gameId > 0)
            {
                LoadGameData();
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT category_id, category_name FROM categories ORDER BY category_name";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "category_name";
                    cmbCategory.ValueMember = "category_id";
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка категорий: " + ex.Message); }
        }

        private void LoadGameData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT title, price, stock_quantity, category_id FROM board_games WHERE game_id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", _gameId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtName.Text = r["title"].ToString();
                            txtPrice.Text = r["price"].ToString();
                            txtStock.Text = r["stock_quantity"].ToString();
                            cmbCategory.SelectedValue = r["category_id"];
                        }
                    }
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка загрузки: " + ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название игры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    {
                        sql = "INSERT INTO board_games (title, price, stock_quantity, category_id) VALUES (@t, @p, @s, @c)";
                    }
                    else 
                    {
                        sql = "UPDATE board_games SET title=@t, price=@p, stock_quantity=@s, category_id=@c WHERE game_id=@id";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@t", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", stock);
                    cmd.Parameters.AddWithValue("@c", cmbCategory.SelectedValue);

                    if (_gameId > 0)
                        cmd.Parameters.AddWithValue("@id", _gameId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Запись успешно сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка сохранения: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}