using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace BoardGame_Store
{
    public partial class OrdersListForm : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private int selectedOrderId = 0;

        public OrdersListForm()
        {
            InitializeComponent();
            ApplyRolePermissions();

            cmbPageSize.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dtpDateFrom.Value = DateTime.Today.AddMonths(-3);
            dtpDateTo.Value = DateTime.Today;
        }

        private void ApplyRolePermissions()
        {
            if (CurrentUser.Role == "Продавец")
            {
                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnReport.Visible = false;
                btnWord.Visible = true;
            }
            else if (CurrentUser.Role == "Товаровед")
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnWord.Visible = false;
                btnReport.Visible = true;
            }
            else if (CurrentUser.Role == "Администратор")
            {
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnReport.Visible = false; 
                btnWord.Visible = false;   
            }
        }

        private void OrdersListForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string where = " WHERE o.order_date >= @df AND o.order_date < @dt ";

                    if (string.IsNullOrWhiteSpace(txtOrderNumber.Text) == false && txtOrderNumber.Text != "Поиск...")
                    {
                        where += " AND o.order_id LIKE @num ";
                    }
                    if (cmbStatus.SelectedIndex > 0)
                    {
                        where += " AND s.status_name = @status ";
                    }

                    string orderBy = " ORDER BY o.order_id DESC ";
                    if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY o.order_date DESC ";
                    else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY s.status_name ASC ";
                    else if (cmbSort.SelectedIndex == 3) orderBy = " ORDER BY o.total_amount DESC ";

                    string countSql = "SELECT COUNT(*) FROM orders o JOIN statuses s ON o.status_id=s.status_id " + where;
                    MySqlCommand cmdCount = new MySqlCommand(countSql, conn);

                    if (string.IsNullOrWhiteSpace(txtOrderNumber.Text) == false && txtOrderNumber.Text != "Поиск...")
                    {
                        cmdCount.Parameters.AddWithValue("@num", "%" + txtOrderNumber.Text + "%");
                    }
                    if (cmbStatus.SelectedIndex > 0)
                    {
                        cmdCount.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    }
                    cmdCount.Parameters.AddWithValue("@df", dtpDateFrom.Value.Date);
                    cmdCount.Parameters.AddWithValue("@dt", dtpDateTo.Value.Date.AddDays(1));

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;

                    string sql = "SELECT o.order_id AS `Номер`, c.full_name AS `Клиент`, o.order_date AS `Дата`, " +
                                 "s.status_name AS `Статус`, o.discount AS `Скидка`, o.total_amount AS `Сумма` " +
                                 "FROM orders o JOIN customers c ON o.customer_id=c.customer_id " +
                                 "JOIN statuses s ON o.status_id=s.status_id " +
                                 where + orderBy + " LIMIT @offset, @pageSize";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    if (string.IsNullOrWhiteSpace(txtOrderNumber.Text) == false && txtOrderNumber.Text != "Поиск...")
                    {
                        cmd.Parameters.AddWithValue("@num", "%" + txtOrderNumber.Text + "%");
                    }
                    if (cmbStatus.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    }
                    cmd.Parameters.AddWithValue("@df", dtpDateFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@dt", dtpDateTo.Value.Date.AddDays(1));
                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrders.DataSource = dt;
                }

                lblCount.Text = "Количество записей: " + totalRecords;
                lblPageInfo.Text = "Страница " + currentPage + " из " + totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrders.Columns[e.ColumnIndex].Name == "Статус" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Новый")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 245, 200);
                    e.CellStyle.ForeColor = Color.DarkGoldenrod;
                }
                else if (status == "Готов")
                {
                    e.CellStyle.BackColor = Color.FromArgb(200, 240, 210);
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (status == "Отменён")
                {
                    e.CellStyle.BackColor = Color.FromArgb(250, 210, 210);
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        private void LoadOrderContent(int orderId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT g.title AS `Товар`, oi.quantity AS `Кол-во`, oi.unit_price AS `Цена`, (oi.quantity*oi.unit_price) AS `Сумма` " +
                                 "FROM order_items oi JOIN board_games g ON oi.game_id=g.game_id WHERE oi.order_id=@id";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", orderId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvContent.DataSource = dt;

                    MySqlCommand cmd = new MySqlCommand("SELECT discount, total_without_discount, total_with_discount, total_amount FROM orders WHERE order_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", orderId);
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read() == true)
                        {
                            decimal sw = Convert.ToDecimal(r["total_without_discount"]);
                            decimal sww = Convert.ToDecimal(r["total_with_discount"]);
                            nudDiscount.Value = Convert.ToDecimal(r["discount"]);
                            txtSumWithout.Text = sw.ToString("0.00");
                            txtDiscountAmount.Text = (sw - sww).ToString("0.00");
                            txtSumWith.Text = sww.ToString("0.00");
                            txtTotal.Text = Convert.ToDecimal(r["total_amount"]).ToString("0.00");
                        }
                    }
                }
            }
            catch { }
        }

        private void txtOrderNumber_TextChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) { LoadOrders(); }
        private void dtpDateFrom_ValueChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void dtpDateTo_ValueChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e) { pageSize = int.Parse(cmbPageSize.SelectedItem.ToString()); currentPage = 1; LoadOrders(); }
        private void btnFirst_Click(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) { currentPage--; }
            LoadOrders();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages) { currentPage++; }
            LoadOrders();
        }

        private void btnLast_Click(object sender, EventArgs e) { currentPage = totalPages; LoadOrders(); }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOrderNumber.Text = "Поиск...";
            cmbStatus.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dtpDateFrom.Value = DateTime.Today.AddMonths(-3);
            dtpDateTo.Value = DateTime.Today;
            currentPage = 1;
            LoadOrders();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) { return; }
            selectedOrderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["Номер"].Value);
            LoadOrderContent(selectedOrderId);
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            decimal sw;
            if (decimal.TryParse(txtSumWithout.Text, out sw))
            {
                decimal da = sw * nudDiscount.Value / 100;
                decimal sww = sw - da;
                txtDiscountAmount.Text = da.ToString("0.00");
                txtSumWith.Text = sww.ToString("0.00");
                txtTotal.Text = sww.ToString("0.00");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) { new OrderAddForm().ShowDialog(); LoadOrders(); }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0)
            {
                MessageBox.Show("Выберите заказ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new OrderEditForm(selectedOrderId).ShowDialog();
            LoadOrders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0)
            {
                MessageBox.Show("Выберите заказ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Удалить выбранный заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmdItems = new MySqlCommand("DELETE FROM order_items WHERE order_id=" + selectedOrderId, conn);
                        cmdItems.ExecuteNonQuery();
                        MySqlCommand cmdOrder = new MySqlCommand("DELETE FROM orders WHERE order_id=" + selectedOrderId, conn);
                        cmdOrder.ExecuteNonQuery();
                    }
                    MessageBox.Show("Заказ удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                }
                catch (Exception ex) { MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0)
            {
                MessageBox.Show("Выберите заказ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string customerName = "";
                DateTime orderDate = DateTime.Now;
                decimal totalSum = 0;
                DataTable itemsTable = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sqlOrder = "SELECT c.full_name, o.order_date, o.total_amount FROM orders o JOIN customers c ON o.customer_id = c.customer_id WHERE o.order_id = @id";
                    MySqlCommand cmdOrder = new MySqlCommand(sqlOrder, conn);
                    cmdOrder.Parameters.AddWithValue("@id", selectedOrderId);
                    using (MySqlDataReader r = cmdOrder.ExecuteReader())
                    {
                        if (r.Read() == true)
                        {
                            customerName = r["full_name"].ToString();
                            orderDate = Convert.ToDateTime(r["order_date"]);
                            totalSum = Convert.ToDecimal(r["total_amount"]);
                        }
                    }

                    string sqlItems = "SELECT g.title, oi.quantity, oi.unit_price, (oi.quantity * oi.unit_price) AS item_total FROM order_items oi JOIN board_games g ON oi.game_id = g.game_id WHERE oi.order_id = @id";
                    MySqlCommand cmdItems = new MySqlCommand(sqlItems, conn);
                    cmdItems.Parameters.AddWithValue("@id", selectedOrderId);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdItems);
                    da.Fill(itemsTable);
                }

                StringBuilder txt = new StringBuilder();
                txt.AppendLine("==========================================");
                txt.AppendLine("          МАГАЗИН НАСТОЛЬНЫХ ИГР");
                txt.AppendLine("==========================================");
                txt.AppendLine("Чек к заказу №" + selectedOrderId);
                txt.AppendLine("Дата: " + orderDate.ToString("dd.MM.yyyy HH:mm"));
                txt.AppendLine("Клиент: " + customerName);
                txt.AppendLine("------------------------------------------");
                txt.AppendLine("Товар               Кол-во   Цена     Сумма");
                txt.AppendLine("------------------------------------------");

                foreach (DataRow row in itemsTable.Rows)
                {
                    string title = row["title"].ToString();
                    if (title.Length > 18) title = title.Substring(0, 15) + "...";
                    txt.AppendLine(title.PadRight(20) + " " + row["quantity"].ToString().PadRight(8) + " " + Convert.ToDecimal(row["unit_price"]).ToString("0.00").PadRight(8) + " " + Convert.ToDecimal(row["item_total"]).ToString("0.00"));
                }

                txt.AppendLine("------------------------------------------");
                txt.AppendLine("ИТОГО К ОПЛАТЕ: " + totalSum.ToString("C2"));
                txt.AppendLine("==========================================");
                txt.AppendLine("          Спасибо за покупку!");

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Документ Word (*.doc)|*.doc";
                    sfd.FileName = "Чек_Заказ_" + selectedOrderId + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".doc";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, txt.ToString(), Encoding.UTF8);
                        MessageBox.Show("Чек успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка чека: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT o.order_id, c.full_name, o.order_date, o.total_amount FROM orders o JOIN customers c ON o.customer_id = c.customer_id WHERE o.order_date >= @df AND o.order_date < @dt ORDER BY o.order_date ASC";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@df", dtpDateFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@dt", dtpDateTo.Value.Date.AddDays(1));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0) { MessageBox.Show("Нет данных за период."); return; }

                    decimal totalSum = 0;
                    foreach (DataRow row in dt.Rows) { totalSum += Convert.ToDecimal(row["total_amount"]); }

                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine("sep=;");
                    csv.AppendLine("Номер заказа;Клиент;Дата оформления;Сумма");
                    foreach (DataRow row in dt.Rows)
                    {
                        csv.AppendLine(row["order_id"] + ";" + row["full_name"] + ";" + Convert.ToDateTime(row["order_date"]).ToString("dd.MM.yyyy HH:mm") + ";" + Convert.ToDecimal(row["total_amount"]).ToString("0.00"));
                    }
                    csv.AppendLine(";;ИТОГО ЗА ПЕРИОД:;" + totalSum.ToString("0.00"));

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "Excel документ (*.csv)|*.csv";
                        sfd.FileName = "Отчет_" + dtpDateFrom.Value.ToString("ddMMyyyy") + ".csv";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.UTF8);
                            MessageBox.Show("Отчет сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process.Start(sfd.FileName);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }
    }
}