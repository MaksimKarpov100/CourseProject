using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace BoardGame_Store
{
    public partial class SpecialForm : Form
    {
        public SpecialForm()
        {
            InitializeComponent();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                    Color.FromArgb(220, 220, 220), ButtonBorderStyle.Solid);
            }
        }

        private void SpecialForm_Load(object sender, EventArgs e)
        {
            txtFolder.Text = Path.Combine(Application.StartupPath, "Backups");
            RefreshBackupsList();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTables.Items.Count; i++)
            {
                clbTables.SetItemChecked(i, true);
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTables.Items.Count; i++)
            {
                clbTables.SetItemChecked(i, false);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fbd.SelectedPath;
                RefreshBackupsList();
            }
        }

        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            if (clbTables.CheckedItems.Count == 0)
            {
                MessageHelper.ShowWarning("Отметьте хотя бы одну таблицу для экспорта!");
                return;
            }

            if (Directory.Exists(txtFolder.Text) == false)
            {
                Directory.CreateDirectory(txtFolder.Text);
            }

            int count = 0;
            Cursor = Cursors.WaitCursor;

            foreach (object item in clbTables.CheckedItems)
            {
                string tableName = item.ToString();

                try
                {
                    string sql = "SELECT * FROM `" + tableName + "`";
                    DataTable dt = DatabaseHelper.ExecuteQuery(sql);

                    string filePath = Path.Combine(txtFolder.Text, tableName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv");
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(dt.Columns[i].ColumnName);
                        if (i < dt.Columns.Count - 1)
                        {
                            sb.Append(";");
                        }
                    }
                    sb.AppendLine();

                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sb.Append(row[i].ToString().Replace(";", ","));
                            if (i < dt.Columns.Count - 1)
                            {
                                sb.Append(";");
                            }
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                    count++;
                    Log("Экспорт: " + tableName);
                }
                catch (Exception ex)
                {
                    Log("Ошибка экспорта " + tableName + ": " + ex.Message);
                }
            }

            Cursor = Cursors.Default;
            MessageHelper.ShowInfo("Успешно экспортировано таблиц: " + count);
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV файлы (*.csv)|*.csv";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            MessageHelper.ShowInfo("Импорт запущен (упрощенно для защиты).");
        }

        private void RefreshBackupsList()
        {
            string folder = txtFolder.Text;

            if (Directory.Exists(folder) == false)
            {
                dgvBackups.DataSource = null;
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Имя файла");
            dt.Columns.Add("Дата");
            dt.Columns.Add("Размер");

            string[] files = Directory.GetFiles(folder, "*.sql");
            Array.Sort(files);
            Array.Reverse(files);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                dt.Rows.Add(fi.Name, fi.CreationTime.ToString("dd.MM.yyyy HH:mm"), (fi.Length / 1024) + " КБ");
            }

            dgvBackups.DataSource = dt;
        }

        private void btnBackupManual_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtFolder.Text) == false)
            {
                Directory.CreateDirectory(txtFolder.Text);
            }

            string fileName = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";
            string filePath = Path.Combine(txtFolder.Text, fileName);
            Cursor = Cursors.WaitCursor;

            try
            {
                string mysqldump = FindMysqldumpPath();

                if (string.IsNullOrEmpty(mysqldump) == true)
                {
                    MessageHelper.ShowError("mysqldump.exe не найден! Убедитесь, что MySQL установлен.");
                    return;
                }

                string args = "-u" + DbConfig.User + " ";

                if (string.IsNullOrEmpty(DbConfig.Password) == false)
                {
                    args += "-p" + DbConfig.Password + " ";
                }

                args += "--databases " + DbConfig.Database + " --result-file=\"" + filePath + "\"";

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = mysqldump;
                psi.Arguments = args;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardError = true;

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        Log("Бэкап создан: " + fileName);
                        MessageHelper.ShowInfo("Бэкап успешно создан!");
                        RefreshBackupsList();
                    }
                    else
                    {
                        MessageHelper.ShowError(process.StandardError.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvBackups.CurrentRow == null)
            {
                MessageHelper.ShowWarning("Выберите файл резервной копии!");
                return;
            }

            string fileName = dgvBackups.CurrentRow.Cells[0].Value.ToString();
            string filePath = Path.Combine(txtFolder.Text, fileName);

            if (MessageHelper.AskConfirm("Восстановить базу данных из этого файла?") == false)
            {
                return;
            }

            Cursor = Cursors.WaitCursor;

            try
            {
                string serverConn = "server=" + DbConfig.Server + ";port=" + DbConfig.Port + ";user=" + DbConfig.User + ";password=" + DbConfig.Password + ";charset=utf8mb4;AllowPublicKeyRetrieval=True;";

                using (MySqlConnection conn = new MySqlConnection(serverConn))
                {
                    conn.Open();

                    MySqlCommand cmdCreate = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + DbConfig.Database + "`", conn);
                    cmdCreate.ExecuteNonQuery();

                    conn.ChangeDatabase(DbConfig.Database);

                    string sqlScript = File.ReadAllText(filePath);
                    MySqlScript script = new MySqlScript(conn, sqlScript);
                    script.Execute();

                    try
                    {
                        DbInitializer.EnsureDefaultUsers();
                    }
                    catch
                    {

                    }

                    Log("Восстановлено из " + fileName);
                    MessageHelper.ShowInfo("База данных успешно восстановлена!");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка восстановления: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Студент Курсового");
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@df", dtpFrom.Value.Date);
                parameters.Add("@dt", dtpTo.Value.Date.AddDays(1));

                string sql = "SELECT o.order_id, c.full_name, o.order_date, o.total_amount FROM orders o JOIN customers c ON o.customer_id = c.customer_id WHERE o.order_date >= @df AND o.order_date < @dt ORDER BY o.order_date ASC";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageHelper.ShowWarning("Нет данных за выбранный период.");
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel документ (*.xlsx)|*.xlsx";
                sfd.FileName = "Отчет_о_продажах_" + dtpFrom.Value.ToString("ddMMyyyy") + ".xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Отчет");

                    worksheet.Column(1).Width = 12;
                    worksheet.Column(2).Width = 35; 
                    worksheet.Column(3).Width = 25; 
                    worksheet.Column(4).Width = 15; 

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
                    worksheet.Cells["A4"].Value = "Период: с " + dtpFrom.Value.ToShortDateString() + " по " + dtpTo.Value.ToShortDateString();
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
                    }
                    worksheet.Row(6).Height = 25; 

                    int row = 7;
                    decimal totalSum = 0;

                    foreach (DataRow r in dt.Rows)
                    {
                        worksheet.Cells[row, 1].Value = r["order_id"].ToString();
                        worksheet.Cells[row, 2].Value = r["full_name"].ToString();
                        worksheet.Cells[row, 3].Value = Convert.ToDateTime(r["order_date"]).ToString("dd.MM.yyyy HH:mm");
                        worksheet.Cells[row, 4].Value = Convert.ToDecimal(r["total_amount"]).ToString("0.00");

                        totalSum += Convert.ToDecimal(r["total_amount"]);

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
                            worksheet.Cells[row, 1, row, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.WhiteSmoke);
                        }

                        row++;
                    }

                    worksheet.Cells[row, 3].Value = "ИТОГО:";
                    worksheet.Cells[row, 4].Value = totalSum.ToString("0.00");

                    using (ExcelRange totalRange = worksheet.Cells[row, 1, row, 4])
                    {
                        totalRange.Style.Font.Bold = true;
                        totalRange.Style.Font.Name = "Arial";
                        totalRange.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        totalRange.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    }
                    worksheet.Cells[row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[row, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    int footerRow = row + 3;

                    worksheet.Cells[footerRow, 1].Value = "Отчет сформирован: " + CurrentUser.FullName;
                    worksheet.Cells[footerRow, 1].Style.Font.Italic = true;
                    worksheet.Cells[footerRow, 1].Style.Font.Size = 10;

                    worksheet.Cells[footerRow + 1, 1].Value = "Дата формирования: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                    worksheet.Cells[footerRow + 1, 1].Style.Font.Italic = true;
                    worksheet.Cells[footerRow + 1, 1].Style.Font.Size = 10;

                    worksheet.Cells[footerRow, 3].Value = "____________________";
                    worksheet.Cells[footerRow, 3, footerRow, 4].Merge = true;
                    worksheet.Cells[footerRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[footerRow + 1, 3].Value = "(подпись директора)";
                    worksheet.Cells[footerRow + 1, 3, footerRow + 1, 4].Merge = true;
                    worksheet.Cells[footerRow + 1, 3].Style.Font.Size = 9;
                    worksheet.Cells[footerRow + 1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[footerRow + 1, 3].Style.Font.Color.SetColor(System.Drawing.Color.Gray);

                    worksheet.PrinterSettings.FitToPage = true;
                    worksheet.PrinterSettings.Orientation = eOrientation.Portrait;

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

        private void Log(string message)
        {
            string logLine = DateTime.Now.ToString("HH:mm:ss") + " - " + message + Environment.NewLine;
            txtLog.AppendText(logLine);
        }

        private string FindMysqldumpPath()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "where";
                psi.Arguments = "mysqldump.exe";
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadLine();
                    if (!string.IsNullOrEmpty(output) && File.Exists(output))
                    {
                        return output;
                    }
                }
            }
            catch { }

            string[] commonPaths = new string[]
            {
                @"C:\Program Files\MySQL\MySQL Server 8.4\bin\mysqldump.exe",
                @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                @"C:\Program Files\MySQL\MySQL Server 5.7\bin\mysqldump.exe",
                @"C:\Program Files (x86)\MySQL\MySQL Server 5.7\bin\mysqldump.exe",

                @"C:\xampp\mysql\bin\mysqldump.exe",

                @"C:\OpenServer\modules\database\MySQL-8.0\bin\mysqldump.exe",
                @"C:\OpenServer\modules\database\MySQL-5.7\bin\mysqldump.exe",
                @"C:\OpenServer\modules\database\MySQL-5.6\bin\mysqldump.exe",

                @"C:\wamp64\bin\mysql\mysql8.0.31\bin\mysqldump.exe",
                @"C:\wamp64\bin\mysql\mysql5.7.40\bin\mysqldump.exe",
                @"C:\wamp\bin\mysql\mysql5.7.26\bin\mysqldump.exe",

        
                @"C:\MAMP\bin\mysql\bin\mysqldump.exe"
            };

            foreach (string path in commonPaths)
            {
                if (File.Exists(path))
                {
                    return path;
                }
            }

            return null; 
        }
    }
}