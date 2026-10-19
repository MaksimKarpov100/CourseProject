using System;
using System.Data;
using System.Drawing;
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

        // Конструктор, который ждет MainFormAdmin (чтобы не было ошибки)
        public GamesForm(bool isManagerMode = false)
        {
            InitializeComponent();

            cmbPageSize.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            LoadCategoriesForFilters();
            LoadGames();
        }

        private void LoadCategoriesForFilters()
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

                    // Добавляем пустую строку для "Все категории"
                    DataRow row = dt.NewRow();
                    row["category_id"] = 0;
                    row["category_name"] = "Все категории";
                    dt.Rows.InsertAt(row, 0);

                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "category_name";
                    cmbCategory.ValueMember = "category_id";
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка категорий: " + ex.Message); }
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
                        where += " AND g.title LIKE @search ";

                    if (cmbCategory.SelectedIndex > 0)
                        where += " AND g.category_id = @cat ";

                    // Подсчет
                    MySqlCommand cmdCount = new MySqlCommand("SELECT COUNT(*) FROM board_games g " + where, conn);
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                        cmdCount.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    if (cmbCategory.SelectedIndex > 0)
                        cmdCount.Parameters.AddWithValue("@cat", cmbCategory.SelectedValue);

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;

                    // Сортировка
                    string orderBy = " ORDER BY g.title ASC ";
                    if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY g.price ASC ";
                    else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY g.stock_quantity DESC ";

                    // Выборка
                    string sql = $@"
                        SELECT 
                            g.game_id AS `ID`, 
                            g.title AS `Название`, 
                            c.category_name AS `Категория`, 
                            g.price AS `Цена`, 
                            g.stock_quantity AS `Остаток`
                        FROM board_games g
                        LEFT JOIN categories c ON g.category_id = c.category_id
                        {where} {orderBy} LIMIT @offset, @pageSize";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    if (cmbCategory.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@cat", cmbCategory.SelectedValue);

                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvGames.DataSource = dt;
                    if (dgvGames.Columns["ID"] != null) dgvGames.Columns["ID"].Visible = false;

                    lblCount.Text = "Количество записей: " + totalRecords;
                    lblPageInfo.Text = $"Страница {currentPage} из {totalPages}";
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка загрузки: " + ex.Message); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { currentPage = 1; LoadGames(); }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { currentPage = 1; LoadGames(); }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) { LoadGames(); }
        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e) { pageSize = int.Parse(cmbPageSize.SelectedItem.ToString()); currentPage = 1; LoadGames(); }

        private void btnFirst_Click(object sender, EventArgs e) { currentPage = 1; LoadGames(); }
        private void btnPrev_Click(object sender, EventArgs e) { if (currentPage > 1) currentPage--; LoadGames(); }
        private void btnNext_Click(object sender, EventArgs e) { if (currentPage < totalPages) currentPage++; LoadGames(); }
        private void btnLast_Click(object sender, EventArgs e) { currentPage = totalPages; LoadGames(); }

        private void dgvGames_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null) return;
            if (dgvGames.Columns["ID"].ValueType != typeof(DBNull)) // защита
                selectedGameId = Convert.ToInt32(dgvGames.CurrentRow.Cells["ID"].Value);
        }

        // --- ДОБАВЛЕНИЕ ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GameEditForm form = new GameEditForm(); // Вызываем форму добавления
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadGames();
            }
        }

        // --- РЕДАКТИРОВАНИЕ ---
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedGameId == 0) { MessageHelper.ShowWarning("Выберите товар"); return; }

            GameEditForm form = new GameEditForm(selectedGameId); // Вызываем форму редактирования
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadGames();
            }
        }

        private void dgvGames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit_Click(sender, e); // Двойной клик тоже редактирует
        }

        // --- УДАЛЕНИЕ ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedGameId == 0) { MessageHelper.ShowWarning("Выберите товар"); return; }

            string name = dgvGames.CurrentRow.Cells["Название"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить товар:\n\n'{name}'?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM board_games WHERE game_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", selectedGameId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageHelper.ShowInfo("Товар удален");
                    LoadGames();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Ошибка удаления (возможно, товар есть в заказах): " + ex.Message);
                }
            }
        }
    }
}