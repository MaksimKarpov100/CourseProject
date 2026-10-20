using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
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

        public OrdersListForm()
        {
            InitializeComponent();
            cmbPageSize.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dtpDateFrom.Value = DateTime.Today.AddMonths(-3);
            dtpDateTo.Value = DateTime.Today;
        }

        private void OrdersListForm_Load(object sender, EventArgs e)
        {
            // Скрываем кнопки для Администратора (по ТЗ)
            if (CurrentUser.Role == "Администратор")
            {
                btnWord.Visible = false;
                btnReport.Visible = false;
            }

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

                    // Живой поиск по номеру (используем txtOrderNumber)
                    if (!string.IsNullOrWhiteSpace(txtOrderNumber.Text))
                        where += " AND o.order_id LIKE @num ";

                    if (cmbStatus.SelectedIndex > 0)
                        where += " AND s.status_name = @status ";

                    MySqlCommand cmdCount = new MySqlCommand("SELECT COUNT(*) FROM orders o JOIN statuses s ON o.status_id=s.status_id " + where, conn);
                    if (!string.IsNullOrWhiteSpace(txtOrderNumber.Text))
                        cmdCount.Parameters.AddWithValue("@num", "%" + txtOrderNumber.Text + "%");
                    if (cmbStatus.SelectedIndex > 0)
                        cmdCount.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());

                    cmdCount.Parameters.AddWithValue("@df", dtpDateFrom.Value.Date);
                    cmdCount.Parameters.AddWithValue("@dt", dtpDateTo.Value.Date.AddDays(1));

                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages < 1) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;

                    string orderBy = " ORDER BY o.order_id DESC ";
                    if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY o.order_date DESC ";
                    else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY s.status_name ASC ";
                    else if (cmbSort.SelectedIndex == 3) orderBy = " ORDER BY o.total_amount DESC ";

                    // Не выбираем ID в SQL, чтобы он не вылез
                    string sql = $@"
                        SELECT 
                            o.order_id AS `Номер`, 
                            c.full_name AS `Клиент`, 
                            c.phone AS `Телефон`, 
                            o.shipping_address AS `Адрес`, 
                            o.order_date AS `Дата`, 
                            s.status_name AS `Статус`, 
                            o.discount AS `Скидка`, 
                            o.total_amount AS `Сумма`
                        FROM orders o
                        JOIN customers c ON o.customer_id = c.customer_id
                        JOIN statuses s ON o.status_id = s.status_id
                        {where} {orderBy} LIMIT @offset, @pageSize";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (!string.IsNullOrWhiteSpace(txtOrderNumber.Text))
                        cmd.Parameters.AddWithValue("@num", "%" + txtOrderNumber.Text + "%");
                    if (cmbStatus.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());

                    cmd.Parameters.AddWithValue("@df", dtpDateFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@dt", dtpDateTo.Value.Date.AddDays(1));
                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrders.DataSource = dt;

                    // Прячем колонку ID (если она вдруг есть)
                    if (dgvOrders.Columns["ID"] != null) dgvOrders.Columns["ID"].Visible = false;

                    // Маскировка ПД
                    foreach (DataGridViewRow row in dgvOrders.Rows)
                    {
                        if (row.Cells["Клиент"].Value != null)
                            row.Cells["Клиент"].Value = MaskName(row.Cells["Клиент"].Value.ToString());
                        if (row.Cells["Телефон"].Value != null)
                            row.Cells["Телефон"].Value = MaskPhone(row.Cells["Телефон"].Value.ToString());
                        if (row.Cells["Адрес"].Value != null)
                            row.Cells["Адрес"].Value = MaskAddress(row.Cells["Адрес"].Value.ToString());
                    }
                }

                ApplyRowColors();
                lblCount.Text = "Количество записей: " + totalRecords;
                lblPageInfo.Text = $"Страница {currentPage} из {totalPages}";
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка загрузки заказов: " + ex.Message); }
        }

        // Загрузка состава заказа
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            selectedOrderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["Номер"].Value);
            LoadOrderContent(selectedOrderId);
        }

        private void LoadOrderContent(int orderId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = @"SELECT g.title AS `Товар`, oi.quantity AS `Кол-во`, oi.unit_price AS `Цена`, (oi.quantity * oi.unit_price) AS `Сумма`
                                   FROM order_items oi JOIN board_games g ON oi.game_id = g.game_id WHERE oi.order_id = @id";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", orderId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvContent.DataSource = dt;

                    MySqlCommand cmd = new MySqlCommand("SELECT discount, total_without_discount, total_with_discount, total_amount FROM orders WHERE order_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            decimal sumWithout = Convert.ToDecimal(r["total_without_discount"]);
                            decimal sumWith = Convert.ToDecimal(r["total_with_discount"]);

                            nudDiscount.Value = Convert.ToDecimal(r["discount"]);
                            txtSumWithout.Text = sumWithout.ToString("0.00");
                            txtDiscountAmount.Text = (sumWithout - sumWith).ToString("0.00");
                            txtSumWith.Text = sumWith.ToString("0.00");
                            txtTotal.Text = Convert.ToDecimal(r["total_amount"]).ToString("0.00");
                        }
                    }
                }
            }
            catch { }
        }

        // Маскировка
        private string MaskName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            var parts = name.Split(' ');
            return parts.Length >= 2 ? parts[0] + " " + parts[1][0] + "." : name;
        }
        private string MaskPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return "";
            string digits = Regex.Replace(phone, @"\D", "");
            return digits.Length >= 10 ? digits.Substring(digits.Length - 10, 3) + "****" + digits.Substring(digits.Length - 2) : phone;
        }
        private string MaskAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return "";
            return address.Split(',').Length > 0 ? address.Split(',')[0] + ", ул. ***" : "***";
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["Статус"].Value == null) continue;
                string status = row.Cells["Статус"].Value.ToString();
                if (status == "Новый") row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                else if (status == "Готов") row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218);
                else if (status == "Отменён") row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218);
            }
        }

        private void txtOrderNumber_TextChanged(object sender, EventArgs e) { currentPage = 1; LoadOrders(); }
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
            txtOrderNumber.Text = "";
            cmbStatus.SelectedIndex = 0; cmbSort.SelectedIndex = 0;
            dtpDateFrom.Value = DateTime.Today.AddMonths(-3); dtpDateTo.Value = DateTime.Today;
            currentPage = 1; LoadOrders();
        }
        private void nudDiscount_ValueChanged(object sender, EventArgs e) { /* Можно добавить пересчет, если нужно */ }
        private void btnAdd_Click(object sender, EventArgs e) { new OrderAddForm().ShowDialog(); LoadOrders(); }
        private void btnEdit_Click(object sender, EventArgs e) { if (selectedOrderId > 0) { new OrderEditForm(selectedOrderId).ShowDialog(); LoadOrders(); } }
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) btnEdit_Click(sender, e); }
        private void btnWord_Click(object sender, EventArgs e) { MessageBox.Show("В разработке"); }
        private void btnReport_Click(object sender, EventArgs e) { MessageBox.Show("В разработке"); }
    }
}