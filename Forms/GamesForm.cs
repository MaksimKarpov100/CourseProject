using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class GamesForm : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private int selectedGameId = 0;
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

        public void RefreshData()
        {
            LoadGames();
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
            isLoaded = true;
            LoadGames();
        }

        private void LoadCategoriesForFilters()
        {
            try
            {
                string sql = "SELECT category_id, category_name FROM categories ORDER BY category_name";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql);

                DataRow row = dt.NewRow();
                row["category_id"] = 0;
                row["category_name"] = "Все категории";
                dt.Rows.InsertAt(row, 0);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки категорий: " + ex.Message);
            }
        }

        private void LoadGames()
        {
            if (isLoaded == false)
            {
                return;
            }

            try
            {
                string whereClause = " WHERE 1=1 ";
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (string.IsNullOrWhiteSpace(txtSearch.Text) == false && txtSearch.Text != "Поиск...")
                {
                    whereClause = whereClause + " AND g.title LIKE @search ";
                    parameters.Add("@search", "%" + txtSearch.Text + "%");
                }

                if (cmbCategory.SelectedIndex > 0)
                {
                    whereClause = whereClause + " AND g.category_id = @cat ";
                    parameters.Add("@cat", cmbCategory.SelectedValue);
                }

                string sqlCount = "SELECT COUNT(*) FROM board_games g " + whereClause;
                totalRecords = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlCount, parameters));

                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                if (totalPages < 1)
                {
                    totalPages = 1;
                }
                if (currentPage > totalPages)
                {
                    currentPage = totalPages;
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

                string sqlData = "SELECT g.game_id AS ID, g.title AS 'Название', c.category_name AS 'Категория', " +
                                 "g.price AS 'Цена', g.stock_quantity AS 'Кол-во на складе', g.image_data " +
                                 "FROM board_games g LEFT JOIN categories c ON g.category_id = c.category_id " +
                                 whereClause + orderBy + " LIMIT @offset, @pageSize";

                parameters.Add("@offset", (currentPage - 1) * pageSize);
                parameters.Add("@pageSize", pageSize);

                DataTable dt = DatabaseHelper.ExecuteQuery(sqlData, parameters);

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
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void dgvGames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGames.Columns[e.ColumnIndex].Name == "Кол-во на складе" && e.Value != null)
            {
                int stock = 0;
                bool isParsed = int.TryParse(e.Value.ToString(), out stock);

                if (isParsed == true)
                {
                    if (stock < 4)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(250, 210, 210);
                        e.CellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (stock >= 4 && stock <= 10)
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
            if (isLoaded == true)
            {
                currentPage = 1;
                LoadGames();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Поиск...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Поиск...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded == true)
            {
                currentPage = 1;
                LoadGames();
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded == true)
            {
                LoadGames();
            }
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded == true && cmbPageSize.SelectedItem != null)
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
            if (dgvGames.CurrentRow == null || dgvGames.Columns.Contains("ID") == false)
            {
                return;
            }
            selectedGameId = Convert.ToInt32(dgvGames.CurrentRow.Cells["ID"].Value);
        }

        private void dgvGames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CurrentUser.Role != "Продавец")
            {
                btnEdit_Click(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GameEditForm form = new GameEditForm();
            form.ShowDialog();
            LoadGames();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedGameId == 0)
            {
                MessageHelper.ShowWarning("Выберите товар для редактирования!");
                return;
            }

            GameEditForm form = new GameEditForm(selectedGameId);
            form.ShowDialog();
            LoadGames();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedGameId == 0)
            {
                MessageHelper.ShowWarning("Выберите товар для удаления!");
                return;
            }

            string message = "Удалить выбранный товар?\n(ВНИМАНИЕ: он также удалится из всех оформленных заказов!)";

            if (MessageHelper.AskConfirm(message) == true)
            {
                try
                {
                    Dictionary<string, object> pItems = new Dictionary<string, object>();
                    pItems.Add("@id", selectedGameId);
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM order_items WHERE game_id = @id", pItems);

                    Dictionary<string, object> pGame = new Dictionary<string, object>();
                    pGame.Add("@id", selectedGameId);
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM board_games WHERE game_id = @id", pGame);

                    MessageHelper.ShowInfo("Товар успешно удален!");
                    LoadGames();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Ошибка при удалении: " + ex.Message);
                }
            }
        }
    }
}