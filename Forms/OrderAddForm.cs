using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class OrderAddForm : Form
    {
        private DataTable cartTable;

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

            nudDiscount.ReadOnly = true;

            LoadCustomers();
            LoadGames();
            LoadStatuses();

            dtpDate.ValueChanged += dtpDate_ValueChanged;
        }

        private void LoadCustomers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(
                        "SELECT customer_id, full_name FROM customers ORDER BY full_name", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "full_name";
                    cmbCustomer.ValueMember = "customer_id";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка клиентов: " + ex.Message);
            }
        }

        private void LoadGames()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(
                        "SELECT game_id, title, price, stock_quantity FROM board_games " +
                        "WHERE stock_quantity > 0 ORDER BY title", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbGame.DataSource = dt;
                    cmbGame.DisplayMember = "title";
                    cmbGame.ValueMember = "game_id";
                }

                if (cmbGame.SelectedItem is DataRowView row)
                {
                    txtPrice.Text = row["price"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка игр: " + ex.Message);
            }
        }

        private void LoadStatuses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(
                        "SELECT status_id, status_name FROM statuses ORDER BY status_id", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbStatus.DataSource = dt;
                    cmbStatus.DisplayMember = "status_name";
                    cmbStatus.ValueMember = "status_id";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка статусов: " + ex.Message);
            }
        }

        private void cmbGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGame.SelectedItem is DataRowView row)
            {
                txtPrice.Text = row["price"].ToString();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbGame.SelectedItem == null)
            {
                MessageHelper.ShowWarning("Выберите товар");
                return;
            }

            DataRowView game = (DataRowView)cmbGame.SelectedItem;

            int gameId = Convert.ToInt32(game["game_id"]);
            int stock = Convert.ToInt32(game["stock_quantity"]);
            int qty = (int)nudQuantity.Value;
            decimal price = Convert.ToDecimal(game["price"]);

            if (qty > stock)
            {
                MessageHelper.ShowWarning("На складе только " + stock + " шт.");
                return;
            }

            foreach (DataRow r in cartTable.Rows)
            {
                if (Convert.ToInt32(r["game_id"]) == gameId)
                {
                    int oldQty = Convert.ToInt32(r["Кол-во"]);

                    if (oldQty + qty > stock)
                    {
                        MessageHelper.ShowWarning("На складе только " + stock + " шт.");
                        return;
                    }

                    r["Кол-во"] = oldQty + qty;
                    r["Сумма"] = (oldQty + qty) * price;

                    Recalculate();
                    return;
                }
            }

            cartTable.Rows.Add(gameId, game["title"].ToString(), qty, price, qty * price);

            Recalculate();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvContent.CurrentRow == null)
            {
                MessageHelper.ShowWarning("Выберите строку");
                return;
            }

            dgvContent.Rows.Remove(dgvContent.CurrentRow);

            Recalculate();
        }

        private void Recalculate()
        {
            decimal sum = 0;

            foreach (DataRow r in cartTable.Rows)
            {
                sum += Convert.ToDecimal(r["Сумма"]);
            }

            decimal percent = DiscountHelper.GetDiscount(sum, dtpDate.Value);
            nudDiscount.Value = percent;

            decimal dAmount = DiscountHelper.GetDiscountAmount(sum, percent);
            decimal total = DiscountHelper.GetTotal(sum, dAmount);

            txtSumWithout.Text = sum.ToString("0.00");
            txtDiscountAmount.Text = dAmount.ToString("0.00");
            txtSumWith.Text = total.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");

            lblCount.Text = "Количество записей: " + cartTable.Rows.Count;
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageHelper.ShowWarning("Выберите клиента");
                return;
            }

            if (cartTable.Rows.Count == 0)
            {
                MessageHelper.ShowWarning("Корзина пуста");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    MySqlTransaction tr = conn.BeginTransaction();

                    try
                    {
                        string sqlOrder = "INSERT INTO orders " +
                            "(customer_id, user_id, status_id, order_date, discount, " +
                            "total_without_discount, total_with_discount, total_amount, shipping_address) " +
                            "VALUES (@c, @u, @s, @d, @disc, @sw, @sww, @t, @a)";

                        MySqlCommand cmd = new MySqlCommand(sqlOrder, conn, tr);

                        cmd.Parameters.AddWithValue("@c", cmbCustomer.SelectedValue);
                        cmd.Parameters.AddWithValue("@u", CurrentUser.UserId);
                        cmd.Parameters.AddWithValue("@s", cmbStatus.SelectedValue);
                        cmd.Parameters.AddWithValue("@d", dtpDate.Value);
                        cmd.Parameters.AddWithValue("@disc", nudDiscount.Value);
                        cmd.Parameters.AddWithValue("@sw", decimal.Parse(txtSumWithout.Text));
                        cmd.Parameters.AddWithValue("@sww", decimal.Parse(txtSumWith.Text));
                        cmd.Parameters.AddWithValue("@t", decimal.Parse(txtTotal.Text));
                        cmd.Parameters.AddWithValue("@a", "г. Москва");

                        cmd.ExecuteNonQuery();

                        long orderId = cmd.LastInsertedId;

                        foreach (DataRow r in cartTable.Rows)
                        {
                            string sqlItem = "INSERT INTO order_items " +
                                "(order_id, game_id, quantity, unit_price) " +
                                "VALUES (@o, @g, @q, @p)";

                            MySqlCommand cmdItem = new MySqlCommand(sqlItem, conn, tr);

                            cmdItem.Parameters.AddWithValue("@o", orderId);
                            cmdItem.Parameters.AddWithValue("@g", r["game_id"]);
                            cmdItem.Parameters.AddWithValue("@q", r["Кол-во"]);
                            cmdItem.Parameters.AddWithValue("@p", r["Цена"]);

                            cmdItem.ExecuteNonQuery();

                            string sqlStock = "UPDATE board_games " +
                                "SET stock_quantity = stock_quantity - @q WHERE game_id = @g";

                            MySqlCommand cmdStock = new MySqlCommand(sqlStock, conn, tr);

                            cmdStock.Parameters.AddWithValue("@q", r["Кол-во"]);
                            cmdStock.Parameters.AddWithValue("@g", r["game_id"]);

                            cmdStock.ExecuteNonQuery();
                        }

                        tr.Commit();

                        MessageHelper.ShowInfo("Заказ успешно добавлен");
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
                MessageHelper.ShowError("Ошибка сохранения: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}