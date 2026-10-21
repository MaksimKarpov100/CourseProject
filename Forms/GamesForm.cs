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

        // ЗАЩИТНЫЙ ФЛАГ
        private bool isLoaded = false;

        public GamesForm()
        {
            InitializeComponent();
            ApplyRolePermissions();
            SetupFilters();
        }

        public GamesForm(bool isManagerMode)
        {
            InitializeComponent();
            ApplyRolePermissions();
            SetupFilters();
        }

        private void SetupFilters()
        {
            cmbPageSize.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            LoadCategoriesForFilters();
        }

        private void ApplyRolePermissions()
        {
            if (CurrentUser.Role == "Продавец")
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void GamesForm_Load(object sender, EventArgs e)
        {
            // Форма загрузилась, теперь можно разрешать загрузку данных
            isLoaded = true;
            LoadGames();
        }

        private void LoadCategoriesForFilters()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT category_id, category_name FROM categories ORDER BY category_name", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow row = dt.NewRow();
                    row["category_id"] = 0;
                    row["category_name"] = "Все категории";
                    dt.Rows.InsertAt(row, 0);

                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "category_name";
                    cmbCategory.ValueMember = "category_id";
                }
            }
            catch { }
        }

        private void LoadGames()
        {
            // Если форма еще не готова, выходим и не крашимся
            if (isLoaded == false)
            {
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string where = " WHERE 1=1 ";

                    if (string.IsNullOrWhiteSpace(txtSearch.Text) == false && txtSearch.Text != "Поиск...")
                    {
                        where += " AND g.title LIKE @search ";
                    }
                    if (cmbCategory.SelectedIndex > 0)
                    {
                        where += " AND g.category_id = @cat ";
                    }

                    MySqlCommand cmdCount = new MySqlCommand("SELECT COUNT(*) FROM board_games g " + where, conn);

                    if (string.IsNullOrWhiteSpace(txtSearch.Text) == false && txtSearch.Text != "Поиск...")
                    {
                        cmdCount.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    }
                    if (cmbCategory.SelectedIndex > 0)
                    {
                        cmdCount.Parameters.AddWithValue("@cat", cmbCategory.SelectedValue);
                    }

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;

                    string orderBy = " ORDER BY g.title ASC ";
                    if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY g.price ASC ";
                    else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY g.stock_quantity ASC ";

                    string sql = "SELECT g.game_id AS `ID`, g.title AS `Название`, c.category_name AS `Категория`, " +
                                 "g.price AS `Цена`, g.stock_quantity AS `Остаток`, g.image_data " +
                                 "FROM board_games g " +
                                 "LEFT JOIN categories c ON g.category_id = c.category_id " +
                                 where + orderBy + " LIMIT @offset, @pageSize";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    if (string.IsNullOrWhiteSpace(txtSearch.Text) == false && txtSearch.Text != "Поиск...")
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    }
                    if (cmbCategory.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@cat", cmbCategory.SelectedValue);
                    }

                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Columns.Contains("Image") == false)
                    {
                        dt.Columns.Add("Image", typeof(Image));
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["image_data"] != DBNull.Value)
                        {
                            byte[] imgBytes = (byte[])row["image_data"];
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                row["Image"] = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            try
                            {
                                row["Image"] = Image.FromFile("Resources/picture.png");
                            }
                            catch
                            {
                                row["Image"] = null;
                            }
                        }
                    }

                    dgvGames.DataSource = dt;

                    foreach (DataGridViewColumn col in dgvGames.Columns)
                    {
                        if (col.Name == "ID" || col.Name == "image_data")
                        {
                            col.Visible = false;
                        }
                        if (col.Name == "Image")
                        {
                            col.HeaderText = "Фото";
                            col.Width = 80;
                            DataGridViewImageColumn imgCol = col as DataGridViewImageColumn;
                            if (imgCol != null)
                            {
                                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            }
                        }
                    }

                    lblCount.Text = "Количество записей: " + totalRecords;
                    lblPageInfo.Text = "Страница " + currentPage + " из " + totalPages;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGames.Columns[e.ColumnIndex].Name == "Остаток" && e.Value != null)
            {
                int stock = 0;
                if (int.TryParse(e.Value.ToString(), out stock) == true)
                {
                    if (stock < 4)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(250, 210, 210);
                        e.CellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (stock <= 10)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 245, 200);
                        e.CellStyle.ForeColor = Color.DarkGoldenrod;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.FromArgb(200, 240, 210);
                        e.CellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (isLoaded == false) return;
            currentPage = 1;
            LoadGames();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded == false) return;
            currentPage = 1;
            LoadGames();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded == false) return;
            LoadGames();
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded == false) return;
            if (cmbPageSize.SelectedItem != null)
            {
                pageSize = int.Parse(cmbPageSize.SelectedItem.ToString());
                currentPage = 1;
                LoadGames();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadGames();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) { currentPage--; }
            LoadGames();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages) { currentPage++; }
            LoadGames();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadGames();
        }

        private void dgvGames_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null) { return; }
            if (dgvGames.Columns.Contains("ID") == false) { return; }
            selectedGameId = Convert.ToInt32(dgvGames.CurrentRow.Cells["ID"].Value);
        }

        private void dgvGames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CurrentUser.Role != "Продавец") { btnEdit_Click(sender, e); }
        }

        private void btnAdd_Click(object sender, EventArgs e) { new GameEditForm().ShowDialog(); LoadGames(); }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedGameId == 0) { MessageBox.Show("Выберите товар"); return; }
            new GameEditForm(selectedGameId).ShowDialog();
            LoadGames();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedGameId == 0)
            {
                MessageBox.Show("Выберите товар", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Удалить выбранный товар?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM board_games WHERE game_id=" + selectedGameId, conn);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Товар удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGames();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451)
                    {
                        MessageBox.Show("Невозможно удалить товар!\n\nЭтот товар уже присутствует в оформленных заказах. Сначала удалите заказы, в которых он есть.",
                                        "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}