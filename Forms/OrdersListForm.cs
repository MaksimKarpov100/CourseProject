using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
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

        public void RefreshData()
        {
            LoadOrders();
        }

        private void ApplyRolePermissions()
        {
            if (CurrentUser.Role == "Продавец")
            {
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnWord.Visible = true;
                btnReport.Visible = false;
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
                btnReport.Visible = true;
                btnWord.Visible = true;
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
                string whereClause = " WHERE o.order_date >= @df AND o.order_date < @dt ";
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@df", dtpDateFrom.Value.Date);
                parameters.Add("@dt", dtpDateTo.Value.Date.AddDays(1));

                if (string.IsNullOrWhiteSpace(txtOrderNumber.Text) == false && txtOrderNumber.Text != "Поиск...")
                {
                    whereClause = whereClause + " AND o.order_id LIKE @num ";
                    parameters.Add("@num", "%" + txtOrderNumber.Text + "%");
                }

                if (cmbStatus.SelectedIndex > 0)
                {
                    whereClause = whereClause + " AND s.status_name = @status ";
                    parameters.Add("@status", cmbStatus.SelectedItem.ToString());
                }

                string countSql = "SELECT COUNT(*) FROM orders o JOIN statuses s ON o.status_id=s.status_id " + whereClause;
                totalRecords = Convert.ToInt32(DatabaseHelper.ExecuteScalar(countSql, parameters));

                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                if (totalPages < 1)
                {
                    totalPages = 1;
                }
                if (currentPage > totalPages)
                {
                    currentPage = totalPages;
                }

                string orderBy = " ORDER BY o.order_id DESC ";
                if (cmbSort.SelectedIndex == 1)
                {
                    orderBy = " ORDER BY o.order_date DESC ";
                }
                else if (cmbSort.SelectedIndex == 2)
                {
                    orderBy = " ORDER BY s.status_name ASC ";
                }
                else if (cmbSort.SelectedIndex == 3)
                {
                    orderBy = " ORDER BY o.total_amount DESC ";
                }

                string sqlData = "SELECT o.order_id AS 'Номер', c.full_name AS 'Клиент', o.order_date AS 'Дата', " +
                                 "s.status_name AS 'Статус', o.discount AS 'Скидка', o.total_amount AS 'Сумма' " +
                                 "FROM orders o JOIN customers c ON o.customer_id=c.customer_id " +
                                 "JOIN statuses s ON o.status_id=s.status_id " +
                                 whereClause + orderBy + " LIMIT @offset, @pageSize";

                parameters.Add("@offset", (currentPage - 1) * pageSize);
                parameters.Add("@pageSize", pageSize);

                DataTable dt = DatabaseHelper.ExecuteQuery(sqlData, parameters);
                dgvOrders.DataSource = dt;

                lblCount.Text = "Количество записей: " + totalRecords;
                lblPageInfo.Text = "Страница " + currentPage + " из " + totalPages;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки заказов: " + ex.Message);
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
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", orderId);

                string sqlItems = "SELECT g.title AS 'Товар', oi.quantity AS 'Кол-во', oi.unit_price AS 'Цена', (oi.quantity*oi.unit_price) AS 'Сумма' " +
                                  "FROM order_items oi JOIN board_games g ON oi.game_id=g.game_id WHERE oi.order_id=@id";
                DataTable dtItems = DatabaseHelper.ExecuteQuery(sqlItems, parameters);
                dgvContent.DataSource = dtItems;

                string sqlOrder = "SELECT discount, total_without_discount, total_with_discount, total_amount FROM orders WHERE order_id=@id";
                DataTable dtOrder = DatabaseHelper.ExecuteQuery(sqlOrder, parameters);

                if (dtOrder.Rows.Count > 0)
                {
                    decimal sumWithout = Convert.ToDecimal(dtOrder.Rows[0]["total_without_discount"]);
                    decimal sumWith = Convert.ToDecimal(dtOrder.Rows[0]["total_with_discount"]);

                    nudDiscount.Value = Convert.ToDecimal(dtOrder.Rows[0]["discount"]);
                    txtSumWithout.Text = sumWithout.ToString("0.00");
                    txtDiscountAmount.Text = (sumWithout - sumWith).ToString("0.00");
                    txtSumWith.Text = sumWith.ToString("0.00");
                    txtTotal.Text = Convert.ToDecimal(dtOrder.Rows[0]["total_amount"]).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки состава заказа: " + ex.Message);
            }
        }

        private void txtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderNumber.Text != "Поиск...")
            {
                currentPage = 1;
                LoadOrders();
            }
        }

        private void txtOrderNumber_Enter(object sender, EventArgs e)
        {
            if (txtOrderNumber.Text == "Поиск...")
            {
                txtOrderNumber.Text = "";
                txtOrderNumber.ForeColor = Color.Black;
            }
        }

        private void txtOrderNumber_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text) == true)
            {
                txtOrderNumber.Text = "Поиск...";
                txtOrderNumber.ForeColor = Color.Gray;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadOrders();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadOrders();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadOrders();
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPageSize.SelectedItem != null)
            {
                pageSize = int.Parse(cmbPageSize.SelectedItem.ToString());
                currentPage = 1;
                LoadOrders();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadOrders();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            LoadOrders();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
            }
            LoadOrders();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadOrders();
        }

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
            if (dgvOrders.CurrentRow == null)
            {
                return;
            }

            selectedOrderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["Номер"].Value);
            LoadOrderContent(selectedOrderId);
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            decimal sumWithout = 0;

            if (decimal.TryParse(txtSumWithout.Text, out sumWithout) == true)
            {
                decimal discountAmount = sumWithout * nudDiscount.Value / 100;
                decimal sumWith = sumWithout - discountAmount;

                txtDiscountAmount.Text = discountAmount.ToString("0.00");
                txtSumWith.Text = sumWith.ToString("0.00");
                txtTotal.Text = sumWith.ToString("0.00");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderAddForm form = new OrderAddForm();
            form.ShowDialog();
            LoadOrders();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0)
            {
                MessageHelper.ShowWarning("Выберите заказ для редактирования!");
                return;
            }

            OrderEditForm form = new OrderEditForm(selectedOrderId);
            form.ShowDialog();
            LoadOrders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0)
            {
                MessageHelper.ShowWarning("Выберите заказ для удаления!");
                return;
            }

            if (MessageHelper.AskConfirm("Удалить выбранный заказ?") == true)
            {
                try
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@id", selectedOrderId);

                    DatabaseHelper.ExecuteNonQuery("DELETE FROM order_items WHERE order_id=@id", parameters);
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM orders WHERE order_id=@id", parameters);

                    MessageHelper.ShowInfo("Заказ успешно удален!");
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Ошибка удаления: " + ex.Message);
                }
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0)
            {
                MessageHelper.ShowWarning("Выберите заказ!");
                return;
            }

            try
            {
                string customerName = "";
                DateTime orderDate = DateTime.Now;
                decimal totalSum = 0;

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", selectedOrderId);

                string sqlOrder = "SELECT c.full_name, o.order_date, o.total_amount FROM orders o JOIN customers c ON o.customer_id = c.customer_id WHERE o.order_id = @id";
                DataTable dtOrder = DatabaseHelper.ExecuteQuery(sqlOrder, parameters);

                if (dtOrder.Rows.Count > 0)
                {
                    customerName = dtOrder.Rows[0]["full_name"].ToString();
                    orderDate = Convert.ToDateTime(dtOrder.Rows[0]["order_date"]);
                    totalSum = Convert.ToDecimal(dtOrder.Rows[0]["total_amount"]);
                }

                string sqlItems = "SELECT g.title, oi.quantity, oi.unit_price, (oi.quantity * oi.unit_price) AS item_total FROM order_items oi JOIN board_games g ON oi.game_id = g.game_id WHERE oi.order_id = @id";
                DataTable dtItems = DatabaseHelper.ExecuteQuery(sqlItems, parameters);

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

                foreach (DataRow row in dtItems.Rows)
                {
                    string title = row["title"].ToString();

                    if (title.Length > 18)
                    {
                        title = title.Substring(0, 15) + "...";
                    }

                    string line = title.PadRight(20) + " " + row["quantity"].ToString().PadRight(8) + " " + Convert.ToDecimal(row["unit_price"]).ToString("0.00").PadRight(8) + " " + Convert.ToDecimal(row["item_total"]).ToString("0.00");
                    txt.AppendLine(line);
                }

                txt.AppendLine("------------------------------------------");
                txt.AppendLine("ИТОГО К ОПЛАТЕ: " + totalSum.ToString("C2"));
                txt.AppendLine("==========================================");
                txt.AppendLine("          Спасибо за покупку!");

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Документ Word (*.doc)|*.doc";
                sfd.FileName = "Чек_Заказ_" + selectedOrderId + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".doc";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, txt.ToString(), Encoding.UTF8);
                    Process.Start(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка формирования чека: " + ex.Message);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@df", dtpDateFrom.Value.Date);
                parameters.Add("@dt", dtpDateTo.Value.Date.AddDays(1));

                string sql = "SELECT o.order_id, c.full_name, o.order_date, o.total_amount FROM orders o JOIN customers c ON o.customer_id = c.customer_id WHERE o.order_date >= @df AND o.order_date < @dt ORDER BY o.order_date ASC";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageHelper.ShowWarning("Нет данных за выбранный период.");
                    return;
                }

                decimal totalSum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalSum = totalSum + Convert.ToDecimal(row["total_amount"]);
                }

                StringBuilder csv = new StringBuilder();
                csv.AppendLine("sep=;");
                csv.AppendLine("Номер заказа;Клиент;Дата оформления;Сумма");

                foreach (DataRow row in dt.Rows)
                {
                    string line = row["order_id"] + ";" + row["full_name"] + ";" + Convert.ToDateTime(row["order_date"]).ToString("dd.MM.yyyy HH:mm") + ";" + Convert.ToDecimal(row["total_amount"]).ToString("0.00");
                    csv.AppendLine(line);
                }

                csv.AppendLine(";;ИТОГО ЗА ПЕРИОД:;" + totalSum.ToString("0.00"));

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel документ (*.csv)|*.csv";
                sfd.FileName = "Отчет_" + dtpDateFrom.Value.ToString("ddMMyyyy") + ".csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.UTF8);
                    Process.Start(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка формирования отчета: " + ex.Message);
            }
        }
    }
}