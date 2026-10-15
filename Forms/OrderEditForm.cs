using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class OrderEditForm : Form
    {
        private int orderId;
        private DataTable cartTable;

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

            nudDiscount.ReadOnly = true;

            LoadCustomers();
            LoadGames();
            LoadStatuses();
            LoadOrder();

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
                        "SELECT game_id, title, price, stock_quantity FROM board_games ORDER BY title", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbGame.DataSource = dt;
                    cmbGame.DisplayMember = "title";
                    cmbGame.ValueMember = "game_id";
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

        private void LoadOrder()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT customer_id, status_id, order_date, completion_date, " +
                                 "discount, total_without_discount, total_with_discount, " +
                                 "total_amount, shipping_address FROM orders WHERE order_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            cmbCustomer.SelectedValue = r["customer_id"];
                            cmbStatus.SelectedValue = r["status_id"];
                            dtpDate.Value = Convert.ToDateTime(r["order_date"]);

                            if (r["completion_date"] != DBNull.Value)
                            {
                                dtpCompletion.Value = Convert.ToDateTime(r["completion_date"]);
                            }

                            decimal sw = Convert.ToDecimal(r["total_without_discount"]);
                            decimal sww = Convert.ToDecimal(r["total_with_discount"]);

                            nudDiscount.Value = Convert.ToDecimal(r["discount"]);
                            txtSumWithout.Text = sw.ToString("0.00");
                            txtDiscountAmount.Text = (sw - sww).ToString("0.00");
                            txtSumWith.Text = sww.ToString("0.00");
                            txtTotal.Text = Convert.ToDecimal(r["total_amount"]).ToString("0.00");

                            txtAddress.Text = r["shipping_address"] == DBNull.Value
                                ? ""
                                : r["shipping_address"].ToString();
                        }
                    }

                    cartTable.Clear();

                    string sqlItems = "SELECT oi.order_item_id, oi.game_id, g.title, oi.quantity, " +
                                      "oi.unit_price, (oi.quantity * oi.unit_price) AS total " +
                                      "FROM order_items oi " +
                                      "JOIN board_games g ON oi.game_id=g.game_id " +
                                      "WHERE oi.order_id=@id";

                    MySqlCommand cmdItems = new MySqlCommand(sqlItems, conn);
                    cmdItems.Parameters.AddWithValue("@id", orderId);

                    using (var r = cmdItems.ExecuteReader())
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

                    lblCount.Text = "Количество записей: " + cartTable.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки заказа: " + ex.Message);
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

            cartTable.Rows.Add(0, gameId, game["title"].ToString(), qty, price, qty * price);

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
            if (cartTable.Rows.Count == 0)
            {
                MessageHelper.ShowWarning("Заказ не может быть пустым");
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
                        string sqlUpdate =
                            "UPDATE orders SET customer_id=@c, status_id=@s, order_date=@d, " +
                            "completion_date=@cd, discount=@disc, total_without_discount=@sw, " +
                            "total_with_discount=@sww, total_amount=@t, shipping_address=@a " +
                            "WHERE order_id=@id";

                        MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn, tr);

                        cmd.Parameters.AddWithValue("@id", orderId);
                        cmd.Parameters.AddWithValue("@c", cmbCustomer.SelectedValue);
                        cmd.Parameters.AddWithValue("@s", cmbStatus.SelectedValue);
                        cmd.Parameters.AddWithValue("@d", dtpDate.Value);

                        if (cmbStatus.Text == "Готов")
                        {
                            cmd.Parameters.AddWithValue("@cd", dtpCompletion.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@cd", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@disc", nudDiscount.Value);
                        cmd.Parameters.AddWithValue("@sw", decimal.Parse(txtSumWithout.Text));
                        cmd.Parameters.AddWithValue("@sww", decimal.Parse(txtSumWith.Text));
                        cmd.Parameters.AddWithValue("@t", decimal.Parse(txtTotal.Text));
                        cmd.Parameters.AddWithValue("@a", txtAddress.Text);

                        cmd.ExecuteNonQuery();

                        MySqlCommand cmdDel = new MySqlCommand(
                            "DELETE FROM order_items WHERE order_id=@id", conn, tr);
                        cmdDel.Parameters.AddWithValue("@id", orderId);
                        cmdDel.ExecuteNonQuery();

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
                        }

                        tr.Commit();

                        MessageHelper.ShowInfo("Заказ сохранён");
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageHelper.ShowWarning("Нечего печатать — заказ пуст");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintReceipt;

            PrintDialog dialog = new PrintDialog();
            dialog.Document = pd;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pd.Print();
                    MessageHelper.ShowInfo("Чек отправлен на печать");
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Ошибка печати: " + ex.Message);
                }
            }
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font fTitle = new Font("Consolas", 14, FontStyle.Bold);
            Font fNormal = new Font("Consolas", 10);
            Font fBold = new Font("Consolas", 11, FontStyle.Bold);
            Font fSmall = new Font("Consolas", 9);

            int y = 40;
            int x = 80;
            int width = 400;

            StringFormat center = new StringFormat();
            center.Alignment = StringAlignment.Center;

            g.DrawString("МАГАЗИН НАСТОЛЬНЫХ ИГР", fTitle, Brushes.Black,
                new RectangleF(x, y, width, 25), center);
            y += 30;

            g.DrawString("г. Москва, ул. Главная, д.1", fSmall, Brushes.Black,
                new RectangleF(x, y, width, 15), center);
            y += 20;

            g.DrawString("Тел: +7 (900) 123-45-67", fSmall, Brushes.Black,
                new RectangleF(x, y, width, 15), center);
            y += 30;

            g.DrawString("========================================", fNormal, Brushes.Black, x, y);
            y += 20;

            g.DrawString("ЧЕК № " + orderId, fBold, Brushes.Black, x, y);
            y += 20;

            g.DrawString("Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"), fNormal, Brushes.Black, x, y);
            y += 18;

            g.DrawString("Клиент: " + cmbCustomer.Text, fNormal, Brushes.Black, x, y);
            y += 18;

            g.DrawString("Кассир: " + CurrentUser.FullName, fNormal, Brushes.Black, x, y);
            y += 25;

            g.DrawString("----------------------------------------", fNormal, Brushes.Black, x, y);
            y += 20;

            g.DrawString("Наименование", fSmall, Brushes.Black, x, y);
            g.DrawString("Кол-во", fSmall, Brushes.Black, x + 220, y);
            g.DrawString("Цена", fSmall, Brushes.Black, x + 280, y);
            g.DrawString("Сумма", fSmall, Brushes.Black, x + 350, y);
            y += 18;

            g.DrawString("----------------------------------------", fNormal, Brushes.Black, x, y);
            y += 18;

            foreach (DataRow r in cartTable.Rows)
            {
                string title = r["Товар"].ToString();

                if (title.Length > 22)
                {
                    title = title.Substring(0, 22);
                }

                g.DrawString(title, fSmall, Brushes.Black, x, y);
                g.DrawString(r["Кол-во"].ToString(), fSmall, Brushes.Black, x + 230, y);
                g.DrawString(Convert.ToDecimal(r["Цена"]).ToString("0.00"), fSmall, Brushes.Black, x + 285, y);
                g.DrawString(Convert.ToDecimal(r["Сумма"]).ToString("0.00"), fSmall, Brushes.Black, x + 355, y);

                y += 18;
            }

            y += 5;
            g.DrawString("----------------------------------------", fNormal, Brushes.Black, x, y);
            y += 20;

            g.DrawString("Сумма без скидки:", fNormal, Brushes.Black, x, y);
            g.DrawString(txtSumWithout.Text + " руб.", fNormal, Brushes.Black, x + 300, y);
            y += 18;

            g.DrawString("Скидка " + nudDiscount.Value + "%:", fNormal, Brushes.Black, x, y);
            g.DrawString("-" + txtDiscountAmount.Text + " руб.", fNormal, Brushes.Black, x + 300, y);
            y += 22;

            g.DrawString("ИТОГО К ОПЛАТЕ:", fBold, Brushes.Black, x, y);
            g.DrawString(txtTotal.Text + " руб.", fBold, Brushes.Black, x + 300, y);
            y += 30;

            g.DrawString("========================================", fNormal, Brushes.Black, x, y);
            y += 25;

            g.DrawString("СПАСИБО ЗА ПОКУПКУ!", fBold, Brushes.Black,
                new RectangleF(x, y, width, 20), center);
            y += 25;

            g.DrawString("Ждём вас снова!", fSmall, Brushes.Black,
                new RectangleF(x, y, width, 20), center);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}