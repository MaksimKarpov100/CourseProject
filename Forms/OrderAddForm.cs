using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class OrderAddForm : Form
    {
        private static string ConnectionString => DbConfig.BuildConnectionString();

        private readonly DataTable cartTable;

        public OrderAddForm()
        {
            InitializeComponent();

            cartTable = new DataTable();
            cartTable.Columns.Add("game_id", typeof(int));
            cartTable.Columns.Add("Товар", typeof(string));
            cartTable.Columns.Add("Кол-во", typeof(int));
            cartTable.Columns.Add("Цена", typeof(decimal));
            cartTable.Columns.Add("Сумма", typeof(decimal));
            dgvContent.DataSource = cartTable;

            nudQuantity.Minimum = 1;
            nudQuantity.Value = 1;
            dtpDate.Value = DateTime.Today;

            LoadCustomers();
            LoadGames();
            LoadStatuses();
        }

        private void LoadCustomers()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(
                    "SELECT customer_id, full_name FROM customers ORDER BY full_name", conn))
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
                using (MySqlDataAdapter da = new MySqlDataAdapter(
                    "SELECT game_id, title, price, stock_quantity FROM board_games " +
                    "WHERE stock_quantity > 0 ORDER BY title", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbGame.DataSource = dt;
                    cmbGame.DisplayMember = "title";
                    cmbGame.ValueMember = "game_id";
                }
            }
            if (cmbGame.SelectedItem is DataRowView row)
                txtPrice.Text = row["price"].ToString();
        }

        private void LoadStatuses()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(
                    "SELECT status_id, status_name FROM statuses ORDER BY status_id", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbStatus.DataSource = dt;
                    cmbStatus.DisplayMember = "status_name";
                    cmbStatus.ValueMember = "status_id";
                }
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
            cartTable.Rows.Add(gameId, game["title"].ToString(), qty, price, qty * price);
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
            foreach (DataRow r in cartTable.Rows) sw += Convert.ToDecimal(r["Сумма"]);
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
            if (cmbCustomer.SelectedValue == null) { MessageBox.Show("Выберите клиента"); return; }
            if (cartTable.Rows.Count == 0) { MessageBox.Show("Корзина пуста"); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction tr = conn.BeginTransaction();
                    try
                    {
                        long orderId;
                        using (MySqlCommand cmd = new MySqlCommand(
                            "INSERT INTO orders (customer_id, user_id, status_id, order_date, discount, " +
                            "total_without_discount, total_with_discount, total_amount, shipping_address) " +
                            "VALUES (@c,@u,@s,@d,@disc,@sw,@sww,@t,@a)", conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@c", cmbCustomer.SelectedValue);
                            cmd.Parameters.AddWithValue("@u", CurrentUser.UserId > 0 ? CurrentUser.UserId : 21);
                            cmd.Parameters.AddWithValue("@s", cmbStatus.SelectedValue);
                            cmd.Parameters.AddWithValue("@d", dtpDate.Value);
                            cmd.Parameters.AddWithValue("@disc", nudDiscount.Value);
                            cmd.Parameters.AddWithValue("@sw", decimal.Parse(txtSumWithout.Text));
                            cmd.Parameters.AddWithValue("@sww", decimal.Parse(txtSumWith.Text));
                            cmd.Parameters.AddWithValue("@t", decimal.Parse(txtTotal.Text));
                            cmd.Parameters.AddWithValue("@a", "г. Москва");
                            cmd.ExecuteNonQuery();
                            orderId = cmd.LastInsertedId;
                        }

                        foreach (DataRow r in cartTable.Rows)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(
                                "INSERT INTO order_items (order_id, game_id, quantity, unit_price) " +
                                "VALUES (@o,@g,@q,@p)", conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@o", orderId);
                                cmd.Parameters.AddWithValue("@g", r["game_id"]);
                                cmd.Parameters.AddWithValue("@q", r["Кол-во"]);
                                cmd.Parameters.AddWithValue("@p", r["Цена"]);
                                cmd.ExecuteNonQuery();
                            }
                            using (MySqlCommand cmd = new MySqlCommand(
                                "UPDATE board_games SET stock_quantity = stock_quantity - @q WHERE game_id = @g", conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@q", r["Кол-во"]);
                                cmd.Parameters.AddWithValue("@g", r["game_id"]);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tr.Commit();
                        MessageBox.Show("Заказ добавлен");
                        this.Close();
                    }
                    catch { tr.Rollback(); throw; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}