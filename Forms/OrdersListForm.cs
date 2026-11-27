using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using Xceed.Words.NET;
using Xceed.Document.NET;
using OfficeOpenXml;
using OfficeOpenXml.Style;

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

                string orderBy = " ORDER BY o.order_id ASC ";
                if (cmbSort.SelectedIndex == 1)
                {
                    orderBy = " ORDER BY o.order_date ASC ";
                }
                else if (cmbSort.SelectedIndex == 2)
                {
                    orderBy = " ORDER BY s.status_name ASC ";
                }
                else if (cmbSort.SelectedIndex == 3)
                {
                    orderBy = " ORDER BY o.total_amount ASC ";
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
                    decimal discountPercent = Convert.ToDecimal(dtOrder.Rows[0]["discount"]);

                    txtDiscount.Text = discountPercent.ToString() + " %";
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
                MessageHelper.ShowWarning("Выберите заказ для печати чека!");
                return;
            }

            try
            {
                Dictionary<string, object> pOrder = new Dictionary<string, object>();
                pOrder.Add("@id", selectedOrderId);

                string sqlOrder = "SELECT c.full_name, o.order_date, o.total_amount FROM orders o JOIN customers c ON o.customer_id = c.customer_id WHERE o.order_id = @id";
                DataTable dtOrder = DatabaseHelper.ExecuteQuery(sqlOrder, pOrder);

                if (dtOrder.Rows.Count == 0) return;

                string customerName = dtOrder.Rows[0]["full_name"].ToString();
                string orderDate = Convert.ToDateTime(dtOrder.Rows[0]["order_date"]).ToString("dd.MM.yyyy HH:mm");
                decimal totalSum = Convert.ToDecimal(dtOrder.Rows[0]["total_amount"]);

                string sqlItems = "SELECT g.title, oi.quantity, oi.unit_price, (oi.quantity * oi.unit_price) AS item_total FROM order_items oi JOIN board_games g ON oi.game_id = g.game_id WHERE oi.order_id = @id";
                DataTable dtItems = DatabaseHelper.ExecuteQuery(sqlItems, pOrder);

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Документ Word (*.docx)|*.docx";
                sfd.FileName = "Чек_Заказ_" + selectedOrderId + ".doc";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (DocX document = DocX.Create(sfd.FileName))
                {
                    document.SetDefaultFont(new Xceed.Document.NET.Font("Times New Roman"), 12);

                    var title = document.InsertParagraph("ТОВАРНЫЙ ЧЕК № " + selectedOrderId);
                    title.Font("Times New Roman").FontSize(18).Bold().Alignment = Alignment.center;

                    var info = document.InsertParagraph("Магазин настольных игр \"Название\"\n" +
                                                        "ИНН: 0000000000, Адрес: г. Москва, ул. Игровая, д. 1\n" +
                                                        "--------------------------------------------------------\n" +
                                                        "Клиент: " + customerName + "\n" +
                                                        "Дата оформления: " + orderDate + "\n\n");
                    info.Font("Times New Roman").FontSize(12);

                    int rows = dtItems.Rows.Count + 2;
                    int cols = 5;
                    var table = document.AddTable(rows, cols);

                    table.Design = TableDesign.TableGrid;
                    table.Alignment = Alignment.center;

                    table.Rows[0].Cells[0].Paragraphs[0].Append("№").Bold().Alignment = Alignment.center;
                    table.Rows[0].Cells[1].Paragraphs[0].Append("Наименование").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("Кол-во").Bold().Alignment = Alignment.center;
                    table.Rows[0].Cells[3].Paragraphs[0].Append("Цена").Bold().Alignment = Alignment.right;
                    table.Rows[0].Cells[4].Paragraphs[0].Append("Сумма").Bold().Alignment = Alignment.right;

                    for (int i = 0; i < dtItems.Rows.Count; i++)
                    {
                        table.Rows[i + 1].Cells[0].Paragraphs[0].Append((i + 1).ToString()).Alignment = Alignment.center;
                        table.Rows[i + 1].Cells[1].Paragraphs[0].Append(dtItems.Rows[i]["title"].ToString());
                        table.Rows[i + 1].Cells[2].Paragraphs[0].Append(dtItems.Rows[i]["quantity"].ToString()).Alignment = Alignment.center;
                        table.Rows[i + 1].Cells[3].Paragraphs[0].Append(Convert.ToDecimal(dtItems.Rows[i]["unit_price"]).ToString("0.00")).Alignment = Alignment.right;
                        table.Rows[i + 1].Cells[4].Paragraphs[0].Append(Convert.ToDecimal(dtItems.Rows[i]["item_total"]).ToString("0.00")).Alignment = Alignment.right;
                    }

                    int lastRow = rows - 1;
                    table.Rows[lastRow].Cells[3].Paragraphs[0].Append("ИТОГО:").Bold().Alignment = Alignment.right;
                    table.Rows[lastRow].Cells[4].Paragraphs[0].Append(totalSum.ToString("0.00")).Bold().Alignment = Alignment.right;

                    document.InsertTable(table);

                    var footer = document.InsertParagraph("\n\nПродавец: ____________________ / " + CurrentUser.FullName + " /\n\n" +
                                                          "Спасибо за покупку! Ждем вас снова.");
                    footer.Font("Times New Roman").FontSize(12);

                    document.Save();
                }

                Process.Start(sfd.FileName);
                MessageHelper.ShowInfo("Чек успешно сформирован!");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка формирования чека: " + ex.Message);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Студент Курсового");
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

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel документ (*.xlsx)|*.xlsx";
                sfd.FileName = "Отчет_о_продажах_" + dtpDateFrom.Value.ToString("ddMMyyyy") + ".xlsx";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Отчет");

                    worksheet.Column(1).Width = 12;
                    worksheet.Column(2).Width = 40;
                    worksheet.Column(3).Width = 22;
                    worksheet.Column(4).Width = 18;

                    worksheet.Cells["A1:D1"].Merge = true;
                    worksheet.Cells["A1"].Value = "МАГАЗИН НАСТОЛЬНЫХ ИГР";
                    worksheet.Cells["A1"].Style.Font.Name = "Arial";
                    worksheet.Cells["A1"].Style.Font.Size = 14;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells["A2:D2"].Merge = true;
                    worksheet.Cells["A2"].Value = "Отчет о продажах";
                    worksheet.Cells["A2"].Style.Font.Name = "Arial";
                    worksheet.Cells["A2"].Style.Font.Size = 18;
                    worksheet.Cells["A2"].Style.Font.Bold = true;
                    worksheet.Cells["A2"].Style.Font.Color.SetColor(System.Drawing.Color.DarkSlateGray);
                    worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells["A4:D4"].Merge = true;
                    worksheet.Cells["A4"].Value = "Период: с " + dtpDateFrom.Value.ToShortDateString() + " по " + dtpDateTo.Value.ToShortDateString();
                    worksheet.Cells["A4"].Style.Font.Name = "Arial";
                    worksheet.Cells["A4"].Style.Font.Size = 12;
                    worksheet.Cells["A4"].Style.Font.Italic = true;
                    worksheet.Cells["A4"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    worksheet.Cells["A6"].Value = "№ Заказа";
                    worksheet.Cells["B6"].Value = "Клиент";
                    worksheet.Cells["C6"].Value = "Дата оформления";
                    worksheet.Cells["D6"].Value = "Сумма (руб.)";

                    using (ExcelRange headerRange = worksheet.Cells["A6:D6"])
                    {
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Font.Name = "Arial";
                        headerRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkSlateGray);
                        headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        headerRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        headerRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        headerRange.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                        headerRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        headerRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    }
                    worksheet.Row(6).Height = 25;

                    int row = 7;
                    foreach (DataRow r in dt.Rows)
                    {
                        worksheet.Cells[row, 1].Value = Convert.ToInt32(r["order_id"]);
                        worksheet.Cells[row, 2].Value = r["full_name"].ToString();
                        worksheet.Cells[row, 3].Value = Convert.ToDateTime(r["order_date"]).ToString("dd.MM.yyyy HH:mm");

                        worksheet.Cells[row, 4].Value = Convert.ToDecimal(r["total_amount"]);
                        worksheet.Cells[row, 4].Style.Numberformat.Format = "#,##0.00"; 

                        using (ExcelRange rowRange = worksheet.Cells[row, 1, row, 4])
                        {
                            rowRange.Style.Font.Name = "Arial";
                            rowRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            rowRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            rowRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            rowRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        worksheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        worksheet.Cells[row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        if (row % 2 == 0)
                        {
                            worksheet.Cells[row, 1, row, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[row, 1, row, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(245, 245, 245)); 
                        }

                        row++;
                    }

                    worksheet.Cells[row, 3].Value = "ИТОГО:";
                    worksheet.Cells[row, 4].Formula = $"SUM(D7:D{row - 1})";
                    worksheet.Cells[row, 4].Style.Numberformat.Format = "#,##0.00";

                    using (ExcelRange totalRange = worksheet.Cells[row, 1, row, 4])
                    {
                        totalRange.Style.Font.Bold = true;
                        totalRange.Style.Font.Name = "Arial";
                        totalRange.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        totalRange.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                        totalRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        totalRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    }
                    worksheet.Cells[row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[row, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    int footerRow = row + 3;

                    worksheet.Cells[footerRow, 1].Value = "Отчет сформирован: " + CurrentUser.FullName;
                    worksheet.Cells[footerRow, 1].Style.Font.Italic = true;
                    worksheet.Cells[footerRow, 1].Style.Font.Size = 10;
                    worksheet.Cells[footerRow, 1, footerRow, 2].Merge = true; // Объединяем для красоты

                    worksheet.Cells[footerRow + 1, 1].Value = "Дата формирования: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                    worksheet.Cells[footerRow + 1, 1].Style.Font.Italic = true;
                    worksheet.Cells[footerRow + 1, 1].Style.Font.Size = 10;
                    worksheet.Cells[footerRow + 1, 1, footerRow + 1, 2].Merge = true;

                    worksheet.Cells[footerRow, 3].Value = "____________________";
                    worksheet.Cells[footerRow, 3, footerRow, 4].Merge = true;
                    worksheet.Cells[footerRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[footerRow + 1, 3].Value = "(подпись директора)";
                    worksheet.Cells[footerRow + 1, 3, footerRow + 1, 4].Merge = true;
                    worksheet.Cells[footerRow + 1, 3].Style.Font.Size = 9;
                    worksheet.Cells[footerRow + 1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[footerRow + 1, 3].Style.Font.Color.SetColor(System.Drawing.Color.Gray);

                    worksheet.PrinterSettings.FitToPage = true;
                    worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                    worksheet.PrinterSettings.FitToWidth = 1;
                    worksheet.PrinterSettings.FitToHeight = 0;

                    FileInfo fileInfo = new FileInfo(sfd.FileName);
                    package.SaveAs(fileInfo);

                    Process.Start(sfd.FileName);
                    MessageHelper.ShowInfo("Отчет успешно сформирован!");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка формирования отчета: " + ex.Message);
            }
        }
    }
}