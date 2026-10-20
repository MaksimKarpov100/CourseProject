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
        public OrderAddForm() { InitializeComponent(); }

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
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT customer_id, full_name FROM customers ORDER BY full_name", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "full_name";
                    cmbCustomer.ValueMember = "customer_id";
                }
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка клиентов: " + ex.Message); }
        }

        private void LoadGames()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT game_id, title, price FROM board_games WHERE stock_quantity > 0 ORDER BY title", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbGame.DataSource = dt;
                    cmbGame.DisplayMember = "title";
                    cmbGame.ValueMember = "game_id";
                }
            }
            catch (Exception ex) { ValidationHelper.ShowError("Ошибка игр: " + ex.Message); }
        }

        private void cmbGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGame.SelectedIndex != -1)
            {
                DataRowView row = cmbGame.SelectedItem as DataRowView;
                if (row != null) txtPrice.Text = row["price"].ToString();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbGame.SelectedIndex == -1) { ValidationHelper.ShowWarning("Выберите товар!"); return; }

            int id = Convert.ToInt32(cmbGame.SelectedValue);
            int qty = (int)nudQuantity.Value;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT stock_quantity, title FROM board_games WHERE game_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            int stock = Convert.ToInt32(r["stock_quantity"]);
                            string title = r["title"].ToString();
                            if (qty > stock)
                            {
                                ValidationHelper.ShowWarning($"На складе осталось только {stock} шт. товара '{title}'!");
                                return;
                            }
                        }
                    }
                }
            }
            catch { return; }

            Image photo = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT image_data FROM board_games WHERE game_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    byte[] bytes = cmd.ExecuteScalar() as byte[];
                    if (bytes != null && bytes.Length > 0)
                        using (MemoryStream ms = new MemoryStream(bytes)) photo = Image.FromStream(ms);
                }
            }
            catch { }

            decimal prc = Convert.ToDecimal(txtPrice.Text);
            dgvOrderItems.Rows.Add(photo, id, cmbGame.Text, qty, prc, qty * prc);
            CalculateTotal();
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
                if (row.Cells["Сумма"].Value != null) sum += Convert.ToDecimal(row.Cells["Сумма"].Value);

            decimal disc = sum * (nudDiscount.Value / 100);
            txtSumWithout.Text = sum.ToString("0.00");
            txtDiscountAmount.Text = disc.ToString("0.00");
            txtSumWith.Text = (sum - disc).ToString("0.00");
            txtTotal.Text = (sum - disc).ToString("0.00");
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e) { CalculateTotal(); }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == -1) { ValidationHelper.ShowWarning("Выберите клиента!"); return; }
            if (dgvOrderItems.Rows.Count == 0) { ValidationHelper.ShowWarning("Добавьте товары!"); return; }
            if (dtpOrderDate.Value.Date > DateTime.Today) { ValidationHelper.ShowWarning("Дата не может быть в будущем!"); return; }

            int customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            int userId = CurrentUser.UserId;
            DateTime orderDate = dtpOrderDate.Value;
            decimal discount = nudDiscount.Value;
            decimal totalWithout = 0;

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
                totalWithout += Convert.ToDecimal(row.Cells["Сумма"].Value);

            decimal totalWith = totalWithout - (totalWithout * (discount / 100));

            using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string sqlOrder = @"INSERT INTO orders (customer_id, user_id, status_id, order_date, discount, total_without_discount, total_with_discount, total_amount, shipping_address) 
                                        VALUES (@cust, @user, 1, @date, @disc, @totalW, @totalWo, @total, 'Самовывоз');
                                        SELECT LAST_INSERT_ID();";

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
                    ValidationHelper.ShowSuccess("Заказ оформлен!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ValidationHelper.ShowError("Ошибка сохранения: " + ex.Message);
                }
            }
        }
    }
}