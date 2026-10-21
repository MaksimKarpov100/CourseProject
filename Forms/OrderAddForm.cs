using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class OrderAddForm : Form
    {
        public OrderAddForm()
        {
            InitializeComponent();
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

            dgvOrderItems.Columns.Add(new DataGridViewImageColumn { Name = "Image", HeaderText = "Фото", ImageLayout = DataGridViewImageCellLayout.Zoom, Width = 60 });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", Visible = false });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Название", HeaderText = "Товар", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Кол-во" });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Цена" });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Сумма" });

            dgvOrderItems.RowTemplate.Height = 50;
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.ReadOnly = true;
        }

        private void LoadCustomers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT customer_id, full_name FROM customers ORDER BY full_name";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "full_name";
                    cmbCustomer.ValueMember = "customer_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка клиентов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGames()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT game_id, title, price FROM board_games WHERE stock_quantity > 0 ORDER BY title";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbGame.DataSource = dt;
                    cmbGame.DisplayMember = "title";
                    cmbGame.ValueMember = "game_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка игр: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Выберите товар!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int gameId = Convert.ToInt32(cmbGame.SelectedValue);
            int addQty = (int)nudQuantity.Value;
            decimal price = Convert.ToDecimal(txtPrice.Text);

            if (addQty <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    int stock = GetStockQuantity(gameId);
                    if (newQty > stock)
                    {
                        MessageBox.Show("На складе осталось только " + stock + " шт. этого товара!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells["Кол-во"].Value = newQty;
                    row.Cells["Сумма"].Value = newQty * price;
                    break;
                }
            }

            if (itemExists == false)
            {
                int stock = GetStockQuantity(gameId);
                if (addQty > stock)
                {
                    MessageBox.Show("На складе осталось только " + stock + " шт. этого товара!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Image photo = GetGameImage(gameId);
                dgvOrderItems.Rows.Add(photo, gameId, cmbGame.Text, addQty, price, addQty * price);
            }

            CalculateTotal();
        }

        private int GetStockQuantity(int gameId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT stock_quantity FROM board_games WHERE game_id=" + gameId;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
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
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT image_data FROM board_games WHERE game_id=" + gameId;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    byte[] bytes = cmd.ExecuteScalar() as byte[];

                    if (bytes != null && bytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            return Image.FromStream(ms);
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
            if (dgvOrderItems.CurrentRow != null)
            {
                dgvOrderItems.Rows.Remove(dgvOrderItems.CurrentRow);
                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            decimal sum = 0;

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                if (row.Cells["Сумма"].Value != null)
                {
                    sum += Convert.ToDecimal(row.Cells["Сумма"].Value);
                }
            }

            decimal disc = sum * (nudDiscount.Value / 100);

            txtSumWithout.Text = sum.ToString("0.00");
            txtDiscountAmount.Text = disc.ToString("0.00");
            txtSumWith.Text = (sum - disc).ToString("0.00");
            txtTotal.Text = (sum - disc).ToString("0.00");
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите клиента!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvOrderItems.Rows.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один товар!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            int userId = CurrentUser.UserId;
            DateTime orderDate = dtpOrderDate.Value;
            decimal discount = nudDiscount.Value;
            decimal totalWithout = 0;

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                totalWithout += Convert.ToDecimal(row.Cells["Сумма"].Value);
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
                    MessageBox.Show("Заказ успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}