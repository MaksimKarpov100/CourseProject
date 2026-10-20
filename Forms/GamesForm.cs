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

        public GamesForm(bool isManagerMode = false)
        {
            InitializeComponent();
            cmbPageSize.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
        }

        private void GamesForm_Load(object sender, EventArgs e)
        {
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
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT category_id, category_name FROM categories ORDER BY category_name", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DataRow row = dt.NewRow(); row["category_id"] = 0; row["category_name"] = "Все категории"; dt.Rows.InsertAt(row, 0);
                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "category_name";
                    cmbCategory.ValueMember = "category_id";
                }
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка категорий: " + ex.Message); }
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

                    MySqlCommand cmdCount = new MySqlCommand("SELECT COUNT(*) FROM board_games g " + where, conn);
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Поиск...")
                        cmdCount.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    if (cmbCategory.SelectedIndex > 0)
                        cmdCount.Parameters.AddWithValue("@cat", cmbCategory.SelectedValue);

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;

                    string orderBy = " ORDER BY g.title ASC ";
                    if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY g.price ASC ";
                    else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY g.stock_quantity DESC ";

                    string sql = $@"
                        SELECT g.image_data AS `Фото`, g.game_id AS `ID`, g.title AS `Название`, 
                               c.category_name AS `Категория`, g.price AS `Цена`, g.stock_quantity AS `Остаток`
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

                    // Конвертация байтов в картинку
                    dt.Columns.Add("Image", typeof(Image));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Фото"] != DBNull.Value)
                        {
                            byte[] imgBytes = (byte[])row["Фото"];
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                row["Image"] = Image.FromStream(ms);
                            }
                        }
                    }

                    // Ручная настройка колонок (чтобы не было крашей)
                    dgvGames.DataSource = null;
                    dgvGames.Columns.Clear();
                    dgvGames.AutoGenerateColumns = false;

                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.Name = "Image"; imgCol.HeaderText = "Фото";
                    imgCol.DataPropertyName = "Image";
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; imgCol.Width = 60;
                    dgvGames.Columns.Add(imgCol);

                    dgvGames.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", DataPropertyName = "ID", Visible = false });
                    dgvGames.Columns.Add(new DataGridViewTextBoxColumn { Name = "Название", DataPropertyName = "Название", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                    dgvGames.Columns.Add(new DataGridViewTextBoxColumn { Name = "Категория", DataPropertyName = "Категория" });
                    dgvGames.Columns.Add(new DataGridViewTextBoxColumn { Name = "Цена", DataPropertyName = "Цена" });
                    dgvGames.Columns.Add(new DataGridViewTextBoxColumn { Name = "Остаток", DataPropertyName = "Остаток" });

                    dgvGames.DataSource = dt;
                    dgvGames.RowTemplate.Height = 50;
                    lblCount.Text = "Количество записей: " + totalRecords;
                    lblPageInfo.Text = $"Страница {currentPage} из {totalPages}";
                }
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка загрузки: " + ex.Message); }
        }

        // --- События фильтров ---
        private void txtSearch_TextChanged(object sender, EventArgs e) { currentPage = 1; LoadGames(); }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { currentPage = 1; LoadGames(); }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) { LoadGames(); }
        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e) { pageSize = int.Parse(cmbPageSize.SelectedItem.ToString()); currentPage = 1; LoadGames(); }
        private void btnFirst_Click(object sender, EventArgs e) { currentPage = 1; LoadGames(); }
        private void btnPrev_Click(object sender, EventArgs e) { if (currentPage > 1) currentPage--; LoadGames(); }
        private void btnNext_Click(object sender, EventArgs e) { if (currentPage < totalPages) currentPage++; LoadGames(); }
        private void btnLast_Click(object sender, EventArgs e) { currentPage = totalPages; LoadGames(); }

        // --- CRUD ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GameEditForm form = new GameEditForm();
            if (form.ShowDialog() == DialogResult.OK) LoadGames();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null) { ValidationHelper.ShowWarning("Выберите товар"); return; }
            int id = Convert.ToInt32(dgvGames.CurrentRow.Cells["ID"].Value);
            GameEditForm form = new GameEditForm(id);
            if (form.ShowDialog() == DialogResult.OK) LoadGames();
        }

        private void dgvGames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null) { ValidationHelper.ShowWarning("Выберите товар"); return; }
            int id = Convert.ToInt32(dgvGames.CurrentRow.Cells["ID"].Value);
            string name = dgvGames.CurrentRow.Cells["Название"].Value.ToString();

            if (MessageBox.Show($"Удалить товар '{name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM board_games WHERE game_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadGames();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451) ValidationHelper.ShowWarning("Этот товар нельзя удалить, он уже есть в заказах!");
                    else ValidationHelper.ShowError("Ошибка: " + ex.Message);
                }
            }
        }
    }
}