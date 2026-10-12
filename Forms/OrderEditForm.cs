using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    /// <summary>
    /// Форма просмотра и редактирования заказа.
    /// </summary>
    public partial class OrderEditForm : Form
    {
        private static string ConnectionString => DbConfig.BuildConnectionString();

        private readonly int orderId;
        private readonly DataTable cartTable;

        public OrderEditForm(int id)
        {
            InitializeComponent();
            orderId = id;

            cartTable = new DataTable();
            cartTable.Columns.Add("order_item_id", typeof(int));
            cartTable.Columns.Add("game_id", typeof(int));
            cartTable.Columns.Add("Товар", typeof(string));
            cartTable.Columns.Add("Кол-во", typeof(int));
            cartTable.Columns.Add("Цена", typeof(decimal));
            cartTable.Columns.Add("Сумма", typeof(decimal));
            dgvContent.DataSource = cartTable;

            nudQuantity.Minimum = 1;
            nudQuantity.Value = 1;

            LoadCustomers();
            LoadGames();
            LoadStatuses();
            LoadOrder();
        }

        private void LoadCustomers()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT customer_id, full_name FROM customers ORDER BY full_name";

                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "full_name";
                    cmbCustomer.ValueMember = "customer_id";
                }
            }
        }

        private void LoadGames()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT game_id, title, price, stock_quantity FROM board_games ORDER BY title";

                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbGame.DataSource = dt;
                    cmbGame.DisplayMember = "title";
                    cmbGame.ValueMember = "game_id";
                }
            }
        }

        private void LoadStatuses()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT status_id, status_name FROM statuses ORDER BY status_id";

                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbStatus.DataSource = dt;
                    cmbStatus.DisplayMember = "status_name";
                    cmbStatus.ValueMember = "status_id";
                }
            }
        }

        private void LoadOrder()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = "SELECT customer_id, status_id, order_date, completion_date, discount, " +
                                 "total_without_discount, total_with_discount, total_amount, shipping_address " +
                                 "FROM orders WHERE order_id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                cmbCustomer.SelectedValue = r["customer_id"];
                                cmbStatus.SelectedValue = r["status_id"];
                                dtpDate.Value = Convert.ToDateTime(r["order_date"]);

                                if (r["completion_date"] != DBNull.Value)
                                    dtpCompletion.Value = Convert.ToDateTime(r["completion_date"]);

                                decimal sw = Convert.ToDecimal(r["total_without_discount"]);
                                decimal sww = Convert.ToDecimal(r["total_with_discount"]);

                                nudDiscount.Value = Convert.ToDecimal(r["discount"]);
                                txtSumWithout.Text = sw.ToString("0.00");
                                txtDiscountAmount.Text = (sw - sww).ToString("0.00");
                                txtSumWith.Text = sww.ToString("0.00");
                                txtTotal.Text = Convert.ToDecimal(r["total_amount"]).ToString("0.00");
                                txtAddress.Text = r["shipping_address"] == DBNull.Value ? "" : r["shipping_address"].ToString();
                            }
                        }
                    }

                    cartTable.Clear();

                    string sqlItems = "SELECT oi.order_item_id, oi.game_id, g.title, oi.quantity, oi.unit_price, " +
                                      "(oi.quantity * oi.unit_price) AS total FROM order_items oi " +
                                      "JOIN board_games g ON oi.game_id=g.game_id WHERE oi.order_id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sqlItems, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                cartTable.Rows.Add(
                                    Convert.ToInt32(r["order_item_id"]),
                                    Convert.ToInt32(r["game_id"]),
                                    r["title"].ToString(),
                                    Convert.ToInt32(r["quantity"]),
                                    Convert.ToDecimal(r["unit_price"]),
                                    Convert.ToDecimal(r["total"]));
                            }
                        }
                    }

                    lblCount.Text = "Количество записей: " + cartTable.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заказа: " + ex.Message);
            }
        }

        private void cmbGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGame.SelectedItem is DataRowView row)
                txtPrice.Text = row["price"].ToString();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbGame.SelectedItem == null) return;

            DataRowView game = (DataRowView)cmbGame.SelectedItem;
            int gameId = Convert.ToInt32(game["game_id"]);
            int stock = Convert.ToInt32(game["stock_quantity"]);
            int qty = (int)nudQuantity.Value;
            decimal price = Convert.ToDecimal(game["price"]);

            if (qty > stock) { MessageBox.Show("На складе только " + stock + " шт."); return; }

            foreach (DataRow r in cartTable.Rows)
            {
                if (Convert.ToInt32(r["game_id"]) == gameId)
                {
                    int oldQty = Convert.ToInt32(r["Кол-во"]);
                    if (oldQty + qty > stock) { MessageBox.Show("На складе только " + stock + " шт."); return; }
                    r["Кол-во"] = oldQty + qty;
                    r["Сумма"] = (oldQty + qty) * price;
                    RecalculateTotals();
                    return;
                }
            }

            cartTable.Rows.Add(0, gameId, game["title"].ToString(), qty, price, qty * price);
            RecalculateTotals();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvContent.CurrentRow == null) return;
            dgvContent.Rows.Remove(dgvContent.CurrentRow);
            RecalculateTotals();
        }

        private void RecalculateTotals()
        {
            decimal sw = 0;
            foreach (DataRow r in cartTable.Rows)
                sw += Convert.ToDecimal(r["Сумма"]);

            decimal da = sw * nudDiscount.Value / 100;
            decimal sww = sw - da;

            txtSumWithout.Text = sw.ToString("0.00");
            txtDiscountAmount.Text = da.ToString("0.00");
            txtSumWith.Text = sww.ToString("0.00");
            txtTotal.Text = sww.ToString("0.00");
            lblCount.Text = "Количество записей: " + cartTable.Rows.Count;
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e) { RecalculateTotals(); }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction tr = conn.BeginTransaction();

                    try
                    {
                        string sqlUpdate = "UPDATE orders SET customer_id=@c, status_id=@s, order_date=@d, " +
                                           "completion_date=@cd, discount=@disc, total_without_discount=@sw, " +
                                           "total_with_discount=@sww, total_amount=@t, shipping_address=@a " +
                                           "WHERE order_id=@id";

                        using (MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@id", orderId);
                            cmd.Parameters.AddWithValue("@c", cmbCustomer.SelectedValue);
                            cmd.Parameters.AddWithValue("@s", cmbStatus.SelectedValue);
                            cmd.Parameters.AddWithValue("@d", dtpDate.Value);
                            cmd.Parameters.AddWithValue("@cd", cmbStatus.Text == "Готов" ? (object)dtpCompletion.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@disc", nudDiscount.Value);
                            cmd.Parameters.AddWithValue("@sw", decimal.Parse(txtSumWithout.Text));
                            cmd.Parameters.AddWithValue("@sww", decimal.Parse(txtSumWith.Text));
                            cmd.Parameters.AddWithValue("@t", decimal.Parse(txtTotal.Text));
                            cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                            cmd.ExecuteNonQuery();
                        }

                        using (MySqlCommand cmd = new MySqlCommand("DELETE FROM order_items WHERE order_id=@id", conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@id", orderId);
                            cmd.ExecuteNonQuery();
                        }

                        foreach (DataRow r in cartTable.Rows)
                        {
                            string sqlItem = "INSERT INTO order_items (order_id, game_id, quantity, unit_price) " +
                                             "VALUES (@o,@g,@q,@p)";
                            using (MySqlCommand cmd = new MySqlCommand(sqlItem, conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@o", orderId);
                                cmd.Parameters.AddWithValue("@g", r["game_id"]);
                                cmd.Parameters.AddWithValue("@q", r["Кол-во"]);
                                cmd.Parameters.AddWithValue("@p", r["Цена"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tr.Commit();
                        MessageBox.Show("Заказ сохранён");
                        this.Close();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}