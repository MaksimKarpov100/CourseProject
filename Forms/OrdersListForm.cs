using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class OrdersListForm : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private int selectedOrderId = 0;
        private bool isLoadingContent = false;

        public OrdersListForm()
        {
            InitializeComponent();

            cmbPageSize.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dtpDateFrom.Value = DateTime.Today.AddMonths(-3);
            dtpDateTo.Value = DateTime.Today;

            dgvOrders.DataBindingComplete += dgvOrders_DataBindingComplete;

            btnWord.Visible = false;
            btnReport.Visible = false;

            if (CurrentUser.Role == "Продавец")
            {
                btnWord.Visible = true;
                btnWord.Location = new Point(300, 5);
            }
            else if (CurrentUser.Role == "Товаровед")
            {
                btnReport.Visible = true;
                btnReport.Location = new Point(300, 5);
            }

            LoadOrderNumbers();
            LoadOrders();
        }

        private void dgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowColors();
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.IsNewRow) continue;
                string status = row.Cells["Статус"].Value == null ? "" : row.Cells["Статус"].Value.ToString();

                if (status == "Новый") row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                else if (status == "Не готов") row.DefaultCellStyle.BackColor = Color.White;
                else if (status == "Готов") row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218);
                else if (status == "Отменён") row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218);
                else row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void LoadOrders()
        {
            try
            {
                int selectedOrderNum = 0;
                if (cmbOrderNumber.SelectedItem is DataRowView drv)
                {
                    selectedOrderNum = Convert.ToInt32(drv["order_id"]);
                }

                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string where = " WHERE o.order_date >= @df AND o.order_date < @dt ";

                    if (selectedOrderNum > 0) where += " AND o.order_id = @num ";
                    if (cmbStatus.SelectedIndex > 0) where += " AND s.status_name = @status ";

                    string orderBy = " ORDER BY o.order_id DESC ";
                    if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY o.order_date DESC ";
                    else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY s.status_name ASC ";
                    else if (cmbSort.SelectedIndex == 3) orderBy = " ORDER BY o.total_amount DESC ";

                    MySqlCommand cmdCount = new MySqlCommand(
                        "SELECT COUNT(*) FROM orders o " +
                        "JOIN statuses s ON o.status_id=s.status_id " + where, conn);

                    if (selectedOrderNum > 0) cmdCount.Parameters.AddWithValue("@num", selectedOrderNum);
                    if (cmbStatus.SelectedIndex > 0) cmdCount.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());

                    cmdCount.Parameters.AddWithValue("@df", dtpDateFrom.Value.Date);
                    cmdCount.Parameters.AddWithValue("@dt", dtpDateTo.Value.Date.AddDays(1));

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    string sql = "SELECT o.order_id AS `Номер`, c.full_name AS `Клиент`, o.order_date AS `Дата`, " +
                                 "s.status_name AS `Статус`, o.discount AS `Скидка`, o.total_amount AS `Сумма` " +
                                 "FROM orders o " +
                                 "JOIN customers c ON o.customer_id=c.customer_id " +
                                 "JOIN statuses s ON o.status_id=s.status_id " +
                                 where + orderBy + " LIMIT @offset, @pageSize";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (selectedOrderNum > 0) cmd.Parameters.AddWithValue("@num", selectedOrderNum);
                    if (cmbStatus.SelectedIndex > 0) cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());

                    cmd.Parameters.AddWithValue("@df", dtpDateFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@dt", dtpDateTo.Value.Date.AddDays(1));
                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrders.DataSource = dt;
                    dgvOrders.ClearSelection();
                }

                lblCount.Text = "Записей: " + totalRecords;
                lblPageInfo.Text = "Страница " + currentPage + " из " + totalPages;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки заказов: " + ex.Message);
            }
        }

        private void LoadOrderNumbers()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("order_id", typeof(int));
                dt.Columns.Add("display_name", typeof(string));
                dt.Rows.Add(0, "Все");

                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT order_id FROM orders ORDER BY order_id DESC", conn);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read()) dt.Rows.Add(Convert.ToInt32(r["order_id"]), r["order_id"].ToString());
                    }
                }

                cmbOrderNumber.SelectedIndexChanged -= cmbOrderNumber_SelectedIndexChanged;
                cmbOrderNumber.DataSource = dt;
                cmbOrderNumber.DisplayMember = "display_name";
                cmbOrderNumber.ValueMember = "order_id";
                cmbOrderNumber.SelectedIndexChanged += cmbOrderNumber_SelectedIndexChanged;
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка загрузки номеров: " + ex.Message); }
        }

        private void LoadOrderContent(int orderId)
        {
            isLoadingContent = true;
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
                    dgvContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    MySqlCommand cmd = new MySqlCommand("SELECT discount, total_without_discount, total_with_discount, total_amount FROM orders WHERE order_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            decimal sw = Convert.ToDecimal(r["total_without_discount"]);
                            decimal sww = Convert.ToDecimal(r["total_with_discount"]);
                            decimal discountVal = Convert.ToDecimal(r["discount"]);

                            if (discountVal < nudDiscount.Minimum) discountVal = nudDiscount.Minimum;
                            if (discountVal > nudDiscount.Maximum) discountVal = nudDiscount.Maximum;

                            nudDiscount.Value = discountVal;
                            txtSumWithout.Text = sw.ToString("0.00");
                            txtDiscountAmount.Text = (sw - sww).ToString("0.00");
                            txtSumWith.Text = sww.ToString("0.00");
                            txtTotal.Text = Convert.ToDecimal(r["total_amount"]).ToString("0.00");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка состава: " + ex.Message); }
            finally { isLoadingContent = false; }
        }

        private void cmbOrderNumber_SelectedIndexChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) { LoadOrders(); }
        private void dtpDateFrom_ValueChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void dtpDateTo_ValueChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e) { pageSize = int.Parse(cmbPageSize.SelectedItem.ToString()); currentPage = 1; LoadOrders(); }

        private void btnFirst_Click(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
        private void btnPrev_Click(object sender, EventArgs e) { if (currentPage > 1) currentPage--; LoadOrders(); }
        private void btnNext_Click(object sender, EventArgs e) { if (currentPage < totalPages) currentPage++; LoadOrders(); }
        private void btnLast_Click(object sender, EventArgs e) { currentPage = totalPages; LoadOrders(); }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbOrderNumber.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dtpDateFrom.Value = DateTime.Today.AddMonths(-3);
            dtpDateTo.Value = DateTime.Today;
            currentPage = 1;
            LoadOrders();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null || dgvOrders.SelectedRows.Count == 0) return;
            object cellValue = dgvOrders.CurrentRow.Cells["Номер"].Value;
            if (cellValue == null || cellValue == DBNull.Value) return;

            int newId = Convert.ToInt32(cellValue);
            if (newId != selectedOrderId)
            {
                selectedOrderId = newId;
                LoadOrderContent(selectedOrderId);
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            object cellValue = dgvOrders.Rows[e.RowIndex].Cells["Номер"].Value;
            if (cellValue == null || cellValue == DBNull.Value) return;

            int id = Convert.ToInt32(cellValue);
            OrderEditForm editForm = new OrderEditForm(id);
            editForm.ShowDialog();
            LoadOrderNumbers();
            LoadOrders();
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadingContent) return;
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

        private void btnAdd_Click(object sender, EventArgs e) { new OrderAddForm().ShowDialog(); LoadOrderNumbers(); LoadOrders(); }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0) { MessageHelper.ShowWarning("Выберите заказ"); return; }
            new OrderEditForm(selectedOrderId).ShowDialog();
            LoadOrderNumbers();
            LoadOrders();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0)
            {
                MessageHelper.ShowWarning("Выберите заказ в таблице для печати чека");
                return;
            }

            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Чек_Заказ_" + selectedOrderId + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".doc");

                string line = new string('=', 62);
                string thin = new string('-', 62);
                const int nameWidth = 25;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(line);
                sb.AppendLine("                    МАГАЗИН НАСТОЛЬНЫХ ИГР");
                sb.AppendLine(line);
                sb.AppendLine("                         КАССОВЫЙ ЧЕК");
                sb.AppendLine("                          Чек № " + selectedOrderId);
                sb.AppendLine(thin);

                string fullName = "";
                DateTime orderDate = DateTime.Now;
                decimal discountPercent = 0;
                decimal totalWithout = 0;
                decimal totalWith = 0;
                string status = "";

                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sqlOrder = "SELECT c.full_name, o.order_date, o.discount, o.total_without_discount, o.total_with_discount, s.status_name FROM orders o " +
                                      "JOIN customers c ON o.customer_id=c.customer_id JOIN statuses s ON o.status_id=s.status_id WHERE o.order_id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sqlOrder, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedOrderId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                fullName = r["full_name"].ToString();
                                orderDate = Convert.ToDateTime(r["order_date"]);
                                discountPercent = Convert.ToDecimal(r["discount"]);
                                totalWithout = Convert.ToDecimal(r["total_without_discount"]);
                                totalWith = Convert.ToDecimal(r["total_with_discount"]);
                                status = r["status_name"].ToString();
                            }
                        }
                    }

                    sb.AppendLine("Дата чека:     " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                    sb.AppendLine("Дата заказа:   " + orderDate.ToString("dd.MM.yyyy HH:mm"));
                    sb.AppendLine("Клиент:        " + fullName);
                    sb.AppendLine("Статус:        " + status);
                    sb.AppendLine(thin);
                    sb.AppendLine("Состав заказа:");
                    sb.AppendLine(thin);
                    sb.AppendLine(PadLeft("№", 3) + "  " + PadRight("Наименование", nameWidth) + "  " + PadLeft("Кол-во", 6) + "  " + PadLeft("Цена", 10) + "  " + PadLeft("Сумма", 10));
                    sb.AppendLine(thin);

                    string sqlItems = "SELECT g.title, oi.quantity, oi.unit_price, (oi.quantity*oi.unit_price) AS total FROM order_items oi " +
                                      "JOIN board_games g ON oi.game_id=g.game_id WHERE oi.order_id=@id ORDER BY oi.order_item_id";

                    int n = 1;
                    using (MySqlCommand cmd = new MySqlCommand(sqlItems, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedOrderId);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string title = r["title"].ToString();
                                if (title.Length > nameWidth - 1) title = title.Substring(0, nameWidth - 2) + "…";
                                int qty = Convert.ToInt32(r["quantity"]);
                                decimal price = Convert.ToDecimal(r["unit_price"]);
                                decimal sum = Convert.ToDecimal(r["total"]);

                                sb.AppendLine(PadLeft(n.ToString(), 3) + "  " + PadRight(title, nameWidth) + "  " + PadLeft(qty.ToString(), 6) + "  " + PadLeft(price.ToString("0.00"), 10) + "  " + PadLeft(sum.ToString("0.00"), 10));
                                n++;
                            }
                        }
                    }

                    sb.AppendLine(thin);

                    decimal discountAmount = totalWithout - totalWith;
                    sb.AppendLine(PadLeft("Подытог:", 45) + "  " + PadLeft(totalWithout.ToString("0.00"), 10) + " руб.");

                    if (discountPercent > 0)
                    {
                        string discLabel = "Скидка (" + discountPercent.ToString("0.##") + "%):";
                        sb.AppendLine(PadLeft(discLabel, 45) + "  " + PadLeft("-" + discountAmount.ToString("0.00"), 10) + " руб.");
                    }

                    sb.AppendLine(line);
                    sb.AppendLine(PadLeft("ИТОГО К ОПЛАТЕ:", 45) + "  " + PadLeft(totalWith.ToString("0.00"), 10) + " руб.");
                    sb.AppendLine(line);
                    sb.AppendLine("                    Спасибо за покупку!");
                    sb.AppendLine(line);
                }

                File.WriteAllText(path, sb.ToString(), new UTF8Encoding(true));
                MessageHelper.ShowInfo("Чек сохранён:\n" + path);
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка печати чека: " + ex.Message); }
        }

        private static string PadRight(string s, int width)
        {
            if (string.IsNullOrEmpty(s)) return new string(' ', width);
            if (s.Length > width) return s.Substring(0, width);
            return s.PadRight(width);
        }

        private static string PadLeft(string s, int width)
        {
            if (string.IsNullOrEmpty(s)) return new string(' ', width);
            if (s.Length > width) return s;
            return s.PadLeft(width);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            while (parent != null && !(parent is TabControl)) parent = parent.Parent;

            if (parent is TabControl tabControl)
            {
                bool found = false;
                foreach (TabPage page in tabControl.TabPages)
                {
                    if (page.Text.ToLower().Contains("спец") || page.Text.ToLower().Contains("отчет"))
                    {
                        tabControl.SelectedTab = page;
                        found = true;
                        break;
                    }
                }
                if (!found) MessageHelper.ShowWarning("Вкладка с отчетами не найдена в главном меню.");
            }
            else
            {
                new SpecialForm().ShowDialog();
            }
        }
    }
}