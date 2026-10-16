using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class GamesForm : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private int selectedGameId = 0;
        private bool readOnlyMode;
        private byte[] pendingImage = null;

        public GamesForm(bool readOnly)
        {
            InitializeComponent();
            readOnlyMode = readOnly;

            if (readOnlyMode)
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnImageAdd.Visible = false;
                panelEdit.Enabled = false;
                lblHint.Visible = false;
                this.Text = "Просмотр товаров";
            }

            cmbPageSize.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;

            LoadCategories();
            LoadGames();
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(
                        "SELECT category_id, category_name FROM categories ORDER BY category_name", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow allRow = dt.NewRow();
                    allRow["category_id"] = 0;
                    allRow["category_name"] = "Все категории";
                    dt.Rows.InsertAt(allRow, 0);

                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "category_name";
                    cmbCategory.ValueMember = "category_id";
                    cmbCategory.SelectedIndex = 0;

                    DataTable dt2 = dt.Copy();
                    dt2.Rows.RemoveAt(0);

                    cmbGameCategory.DataSource = dt2;
                    cmbGameCategory.DisplayMember = "category_name";
                    cmbGameCategory.ValueMember = "category_id";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка категорий: " + ex.Message);
            }
        }

        private int GetCategoryId(ComboBox cmb)
        {
            if (cmb.SelectedIndex < 0)
            {
                return 0;
            }

            DataRowView row = cmb.SelectedItem as DataRowView;

            if (row == null)
            {
                return 0;
            }

            return Convert.ToInt32(row["category_id"]);
        }

        private void LoadGames()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string where = " WHERE 1=1 ";

                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                    {
                        where += " AND g.title LIKE @search ";
                    }

                    if (GetCategoryId(cmbCategory) != 0)
                    {
                        where += " AND g.category_id = @cat ";
                    }

                    string orderBy = " ORDER BY g.title ASC ";

                    if (cmbSort.SelectedIndex == 1)
                    {
                        orderBy = " ORDER BY g.price ASC ";
                    }
                    else if (cmbSort.SelectedIndex == 2)
                    {
                        orderBy = " ORDER BY g.stock_quantity ASC ";
                    }

                    MySqlCommand cmdCount = new MySqlCommand(
                        "SELECT COUNT(*) FROM board_games g " + where, conn);

                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                    {
                        cmdCount.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    }

                    if (GetCategoryId(cmbCategory) != 0)
                    {
                        cmdCount.Parameters.AddWithValue("@cat", GetCategoryId(cmbCategory));
                    }

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    string sql = "SELECT g.game_id AS `ID`, g.image_data AS `img`, " +
                                 "g.title AS `Название`, c.category_name AS `Категория`, " +
                                 "g.price AS `Цена`, g.stock_quantity AS `Остаток`, " +
                                 "g.age_rating AS `Возраст` " +
                                 "FROM board_games g " +
                                 "LEFT JOIN categories c ON g.category_id=c.category_id " +
                                 where + orderBy + " LIMIT @offset, @pageSize";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    }

                    if (GetCategoryId(cmbCategory) != 0)
                    {
                        cmd.Parameters.AddWithValue("@cat", GetCategoryId(cmbCategory));
                    }

                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvGames.DataSource = dt;

                    dgvGames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvGames.Columns["ID"] != null)
                    {
                        dgvGames.Columns["ID"].Visible = false;
                    }

                    if (dgvGames.Columns["img"] != null)
                    {
                        dgvGames.Columns["img"].Visible = false;
                    }
                }

                lblCount.Text = "Записей: " + totalRecords;
                lblPageInfo.Text = "Страница " + currentPage + " из " + totalPages;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка игр: " + ex.Message);
            }
        }

        private void dgvGames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGames.Columns[e.ColumnIndex].Name == "Фото" && e.RowIndex >= 0)
            {
                object imgObj = dgvGames.Rows[e.RowIndex].Cells["img"].Value;
                byte[] data = imgObj as byte[];

                if (data != null && data.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            e.Value = Image.FromStream(ms);
                            return;
                        }
                    }
                    catch
                    {
                    }
                }

                e.Value = null;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadGames();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadGames();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGames();
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = int.Parse(cmbPageSize.SelectedItem.ToString());
            currentPage = 1;
            LoadGames();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadGames();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
            }

            LoadGames();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
            }

            LoadGames();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadGames();
        }

        private void dgvGames_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null)
            {
                return;
            }

            selectedGameId = Convert.ToInt32(dgvGames.CurrentRow.Cells["ID"].Value);

            txtGameTitle.Text = dgvGames.CurrentRow.Cells["Название"].Value == null
                ? ""
                : dgvGames.CurrentRow.Cells["Название"].Value.ToString();

            txtPrice.Text = dgvGames.CurrentRow.Cells["Цена"].Value == null
                ? ""
                : dgvGames.CurrentRow.Cells["Цена"].Value.ToString();

            nudStock.Value = Convert.ToDecimal(dgvGames.CurrentRow.Cells["Остаток"].Value);

            cmbGameCategory.Text = dgvGames.CurrentRow.Cells["Категория"].Value == null
                ? ""
                : dgvGames.CurrentRow.Cells["Категория"].Value.ToString();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "SELECT image_data, description FROM board_games WHERE game_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedGameId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            pendingImage = r["image_data"] == DBNull.Value
                                ? null
                                : (byte[])r["image_data"];

                            txtDescription.Text = r["description"] == DBNull.Value
                                ? ""
                                : r["description"].ToString();

                            ShowPreview(pendingImage);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void ShowPreview(byte[] data)
        {
            if (pbPreview.Image != null)
            {
                pbPreview.Image.Dispose();
            }

            pbPreview.Image = null;

            if (data != null && data.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        pbPreview.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    pbPreview.Image = null;
                }
            }
        }

        private void dgvGames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (readOnlyMode || e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dgvGames.Rows[e.RowIndex].Cells["ID"].Value);

            if (!MessageHelper.AskConfirm("Удалить игру?"))
            {
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM board_games WHERE game_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Игра удалена");
                LoadGames();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка удаления: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGameTitle.Text))
            {
                MessageHelper.ShowWarning("Введите название игры");
                return;
            }

            decimal price;

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageHelper.ShowWarning("Цена должна быть числом");
                return;
            }

            if (!Validator.CheckPrice(price))
            {
                MessageHelper.ShowWarning("Цена должна быть от 0 до 10000");
                return;
            }

            int stock = (int)nudStock.Value;

            if (!Validator.CheckStock(stock))
            {
                MessageHelper.ShowWarning("Остаток от 0 до 1000");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string sql = "INSERT INTO board_games " +
                        "(category_id, title, description, price, stock_quantity, image_data) " +
                        "VALUES (@c, @t, @d, @p, @s, @i)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    int catId = GetCategoryId(cmbGameCategory);

                    cmd.Parameters.AddWithValue("@c", catId == 0 ? (object)DBNull.Value : catId);
                    cmd.Parameters.AddWithValue("@t", txtGameTitle.Text);
                    cmd.Parameters.AddWithValue("@d", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", stock);
                    cmd.Parameters.AddWithValue("@i", pendingImage == null ? (object)DBNull.Value : pendingImage);

                    cmd.ExecuteNonQuery();
                }

                pendingImage = null;

                if (pbPreview.Image != null)
                {
                    pbPreview.Image.Dispose();
                }

                pbPreview.Image = null;

                MessageHelper.ShowInfo("Игра добавлена");
                LoadGames();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка добавления: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedGameId == 0)
            {
                MessageHelper.ShowWarning("Выберите игру");
                return;
            }

            decimal price;

            if (!decimal.TryParse(txtPrice.Text, out price) || !Validator.CheckPrice(price))
            {
                MessageHelper.ShowWarning("Цена от 0 до 10000");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string sql = "UPDATE board_games SET category_id=@c, title=@t, description=@d, " +
                                 "price=@p, stock_quantity=@s, image_data=@i WHERE game_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    int catId = GetCategoryId(cmbGameCategory);

                    cmd.Parameters.AddWithValue("@id", selectedGameId);
                    cmd.Parameters.AddWithValue("@c", catId == 0 ? (object)DBNull.Value : catId);
                    cmd.Parameters.AddWithValue("@t", txtGameTitle.Text);
                    cmd.Parameters.AddWithValue("@d", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", (int)nudStock.Value);
                    cmd.Parameters.AddWithValue("@i", pendingImage == null ? (object)DBNull.Value : pendingImage);

                    cmd.ExecuteNonQuery();
                }

                MessageHelper.ShowInfo("Изменения сохранены");
                LoadGames();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка изменения: " + ex.Message);
            }
        }

        private void btnImageAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Изображения|*.png;*.jpg;*.jpeg;*.bmp";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            pendingImage = File.ReadAllBytes(ofd.FileName);
            ShowPreview(pendingImage);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}