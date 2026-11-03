using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class OrderAddForm : Form
    {
        public OrderAddForm()
        {
            InitializeComponent();
            nudDiscount.Enabled = false; 
        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {
            SetupCartGrid();
            LoadCustomers();
            LoadGames();
            dtpOrderDate.Value = DateTime.Now;
        }

        private void SetupCartGrid()
        {
            dgvOrderItems.AutoGenerateColumns = false;
            dgvOrderItems.Columns.Clear();

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.Name = "Image";
            imgCol.HeaderText = "Фото";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgCol.Width = 60;
            dgvOrderItems.Columns.Add(imgCol);

            DataGridViewTextBoxColumn idCol = new DataGridViewTextBoxColumn();
            idCol.Name = "ID";
            idCol.Visible = false;
            dgvOrderItems.Columns.Add(idCol);

            DataGridViewTextBoxColumn titleCol = new DataGridViewTextBoxColumn();
            titleCol.Name = "Название";
            titleCol.HeaderText = "Товар";
            titleCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrderItems.Columns.Add(titleCol);

            DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn();
            qtyCol.Name = "Кол-во";
            dgvOrderItems.Columns.Add(qtyCol);

            DataGridViewTextBoxColumn priceCol = new DataGridViewTextBoxColumn();
            priceCol.Name = "Цена";
            dgvOrderItems.Columns.Add(priceCol);

            DataGridViewTextBoxColumn sumCol = new DataGridViewTextBoxColumn();
            sumCol.Name = "Сумма";
            dgvOrderItems.Columns.Add(sumCol);

            dgvOrderItems.RowTemplate.Height = 50;
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.MultiSelect = false;
        }

        private void LoadCustomers()
        {
            try
            {
                string sql = "SELECT customer_id, full_name FROM customers ORDER BY full_name";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql);

                cmbCustomer.DataSource = dt;
                cmbCustomer.DisplayMember = "full_name";
                cmbCustomer.ValueMember = "customer_id";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки клиентов: " + ex.Message);
            }
        }

        private void LoadGames()
        {
            try
            {
                string sql = "SELECT game_id, title, price FROM board_games WHERE stock_quantity > 0 ORDER BY title";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql);

                cmbGame.DataSource = dt;
                cmbGame.DisplayMember = "title";
                cmbGame.ValueMember = "game_id";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки игр: " + ex.Message);
            }
        }

        private void cmbGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGame.SelectedIndex != -1)
            {
                DataRowView row = cmbGame.SelectedItem as DataRowView;
                if (row != null)
                {
                    txtPrice.Text = row["price"].ToString();
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbGame.SelectedIndex == -1)
            {
                MessageHelper.ShowWarning("Выберите товар!");
                return;
            }

            int gameId = Convert.ToInt32(cmbGame.SelectedValue);
            int addQty = (int)nudQuantity.Value;
            decimal price = Convert.ToDecimal(txtPrice.Text);

            if (addQty <= 0)
            {
                MessageHelper.ShowWarning("Количество должно быть больше нуля!");
                return;
            }

            int stock = GetStockQuantity(gameId);

            if (stock <= 0)
            {
                MessageHelper.ShowWarning("Этого товара нет на складе!");
                return;
            }

            bool itemExists = false;

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                if (row.Cells["ID"].Value != null && Convert.ToInt32(row.Cells["ID"].Value) == gameId)
                {
                    itemExists = true;
                    int currentQty = Convert.ToInt32(row.Cells["Кол-во"].Value);
                    int newQty = currentQty + addQty;

                    if (newQty > stock)
                    {
                        MessageHelper.ShowWarning("На складе осталось только " + stock + " шт. этого товара!");
                        return;
                    }

                    row.Cells["Кол-во"].Value = newQty;
                    row.Cells["Сумма"].Value = newQty * price;
                    row.Selected = true;
                    break;
                }
            }

            if (itemExists == false)
            {
                if (addQty > stock)
                {
                    MessageHelper.ShowWarning("На складе осталось только " + stock + " шт. этого товара!");
                    return;
                }

                Image photo = GetGameImage(gameId);
                dgvOrderItems.Rows.Add(photo, gameId, cmbGame.Text, addQty, price, addQty * price);

                dgvOrderItems.ClearSelection();
                dgvOrderItems.Rows[dgvOrderItems.Rows.Count - 1].Selected = true;
            }

            CalculateTotal();
            nudQuantity.Value = 1; 
        }

        private int GetStockQuantity(int gameId)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", gameId);

                string sql = "SELECT stock_quantity FROM board_games WHERE game_id=@id";
                object result = DatabaseHelper.ExecuteScalar(sql, parameters);

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private Image GetGameImage(int gameId)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", gameId);

                string sql = "SELECT image_data FROM board_games WHERE game_id=@id";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["image_data"] != DBNull.Value)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["image_data"];
                        if (bytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                return Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch
            {

            }

            try
            {
                return Image.FromFile("Resources/picture.png");
            }
            catch
            {
                return null;
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.Rows.Count == 0)
            {
                MessageHelper.ShowWarning("В корзине нет товаров для удаления!");
                return;
            }

            if (dgvOrderItems.SelectedRows.Count > 0)
            {
                int rowIndex = dgvOrderItems.SelectedRows[0].Index;
                dgvOrderItems.Rows.RemoveAt(rowIndex);
                CalculateTotal();
            }
            else
            {
                MessageHelper.ShowWarning("Пожалуйста, кликните по строке, которую хотите удалить, и нажмите кнопку еще раз!");
            }
        }

        private void CalculateTotal()
        {
            decimal sum = 0;

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                if (row.Cells["Сумма"].Value != null)
                {
                    sum = sum + Convert.ToDecimal(row.Cells["Сумма"].Value);
                }
            }

            decimal discountPercent = DiscountHelper.GetDiscount(sum, dtpOrderDate.Value);

            nudDiscount.ValueChanged -= nudDiscount_ValueChanged;
            nudDiscount.Value = discountPercent;
            nudDiscount.ValueChanged += nudDiscount_ValueChanged;

            decimal discountAmount = DiscountHelper.GetDiscountAmount(sum, discountPercent);
            decimal totalWithDiscount = DiscountHelper.GetTotal(sum, discountAmount);

            txtSumWithout.Text = sum.ToString("0.00");
            txtDiscountAmount.Text = discountAmount.ToString("0.00");
            txtSumWith.Text = totalWithDiscount.ToString("0.00");
            txtTotal.Text = txtSumWith.Text;
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == -1)
            {
                MessageHelper.ShowWarning("Выберите клиента!");
                return;
            }

            if (dgvOrderItems.Rows.Count == 0)
            {
                MessageHelper.ShowWarning("Добавьте хотя бы один товар в заказ!");
                return;
            }

            int customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            int userId = CurrentUser.UserId;
            DateTime orderDate = dtpOrderDate.Value;
            decimal discount = nudDiscount.Value;
            decimal totalWithout = 0;

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                totalWithout = totalWithout + Convert.ToDecimal(row.Cells["Сумма"].Value);
            }

            decimal totalWith = totalWithout - (totalWithout * (discount / 100));

            using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string sqlOrder = "INSERT INTO orders (customer_id, user_id, status_id, order_date, discount, total_without_discount, total_with_discount, total_amount, shipping_address) " +
                                      "VALUES (@cust, @user, 1, @date, @disc, @totalW, @totalWo, @total, 'Самовывоз'); " +
                                      "SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdOrder = new MySqlCommand(sqlOrder, conn, transaction);
                    cmdOrder.Parameters.AddWithValue("@cust", customerId);
                    cmdOrder.Parameters.AddWithValue("@user", userId);
                    cmdOrder.Parameters.AddWithValue("@date", orderDate);
                    cmdOrder.Parameters.AddWithValue("@disc", discount);
                    cmdOrder.Parameters.AddWithValue("@totalW", totalWithout);
                    cmdOrder.Parameters.AddWithValue("@totalWo", totalWith);
                    cmdOrder.Parameters.AddWithValue("@total", totalWith);

                    int orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());

                    foreach (DataGridViewRow row in dgvOrderItems.Rows)
                    {
                        int gameId = Convert.ToInt32(row.Cells["ID"].Value);
                        int qty = Convert.ToInt32(row.Cells["Кол-во"].Value);
                        decimal price = Convert.ToDecimal(row.Cells["Цена"].Value);

                        string sqlItem = "INSERT INTO order_items (order_id, game_id, quantity, unit_price) VALUES (@oid, @gid, @qty, @price)";
                        MySqlCommand cmdItem = new MySqlCommand(sqlItem, conn, transaction);
                        cmdItem.Parameters.AddWithValue("@oid", orderId);
                        cmdItem.Parameters.AddWithValue("@gid", gameId);
                        cmdItem.Parameters.AddWithValue("@qty", qty);
                        cmdItem.Parameters.AddWithValue("@price", price);
                        cmdItem.ExecuteNonQuery();

                        string sqlStock = "UPDATE board_games SET stock_quantity = stock_quantity - @qty WHERE game_id = @gid";
                        MySqlCommand cmdStock = new MySqlCommand(sqlStock, conn, transaction);
                        cmdStock.Parameters.AddWithValue("@qty", qty);
                        cmdStock.Parameters.AddWithValue("@gid", gameId);
                        cmdStock.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageHelper.ShowInfo("Заказ успешно оформлен!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageHelper.ShowError("Ошибка сохранения: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}