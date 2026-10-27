using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace BoardGame_Store
{
    public partial class SpecialForm : Form
    {
        public SpecialForm() { InitializeComponent(); }

        private void SpecialForm_Load(object sender, EventArgs e)
        {
            txtFolder.Text = Path.Combine(Application.StartupPath, "Backups");
            RefreshBackupsList();
        }

        private void btnSelectAll_Click(object sender, EventArgs e) { for (int i = 0; i < clbTables.Items.Count; i++) clbTables.SetItemChecked(i, true); }
        private void btnDeselectAll_Click(object sender, EventArgs e) { for (int i = 0; i < clbTables.Items.Count; i++) clbTables.SetItemChecked(i, false); }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                if (fbd.ShowDialog() == DialogResult.OK) { txtFolder.Text = fbd.SelectedPath; RefreshBackupsList(); }
        }

        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            if (clbTables.CheckedItems.Count == 0) { MessageBox.Show("Отметьте таблицу!"); return; }
            if (!Directory.Exists(txtFolder.Text)) Directory.CreateDirectory(txtFolder.Text);

            int count = 0;
            Cursor = Cursors.WaitCursor;
            foreach (var item in clbTables.CheckedItems)
            {
                string tableName = item.ToString();
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `" + tableName + "`", conn);
                        DataTable dt = new DataTable(); da.Fill(dt);

                        string filePath = Path.Combine(txtFolder.Text, tableName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv");
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < dt.Columns.Count; i++) { sb.Append(dt.Columns[i].ColumnName); if (i < dt.Columns.Count - 1) sb.Append(";"); }
                        sb.AppendLine();
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < dt.Columns.Count; i++) { sb.Append(row[i].ToString().Replace(";", ",")); if (i < dt.Columns.Count - 1) sb.Append(";"); }
                            sb.AppendLine();
                        }
                        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                        count++;
                        Log("Экспорт: " + tableName);
                    }
                }
                catch (Exception ex) { Log("Ошибка экспорта " + tableName + ": " + ex.Message); }
            }
            Cursor = Cursors.Default;
            MessageBox.Show("Экспортировано: " + count);
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV файлы (*.csv)|*.csv";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() != DialogResult.OK) return;

            int imported = 0, errors = 0;
            string lastError = "";
            Cursor = Cursors.WaitCursor;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    // СОРТИРОВКА ФАЙЛОВ (чтобы не было ошибок внешних ключей)
                    string[] files = ofd.FileNames;
                    Array.Sort(files, (a, b) =>
                    {
                        string fa = Path.GetFileName(a).ToLower();
                        string fb = Path.GetFileName(b).ToLower();
                        int orderA = 0, orderB = 0;

                        if (fa.Contains("categories")) orderA = 1;
                        else if (fa.Contains("users")) orderA = 2;
                        else if (fa.Contains("customers")) orderA = 3;
                        else if (fa.Contains("board_games")) orderA = 4;
                        else if (fa.Contains("order_items")) orderA = 6;
                        else if (fa.Contains("orders")) orderA = 5;

                        if (fb.Contains("categories")) orderB = 1;
                        else if (fb.Contains("users")) orderB = 2;
                        else if (fb.Contains("customers")) orderB = 3;
                        else if (fb.Contains("board_games")) orderB = 4;
                        else if (fb.Contains("order_items")) orderB = 6;
                        else if (fb.Contains("orders")) orderB = 5;

                        return orderA.CompareTo(orderB);
                    });

                    foreach (string filePath in files)
                    {
                        string fileName = Path.GetFileName(filePath).ToLower();
                        string sql = "";

                        if (fileName.Contains("categories"))
                            sql = "INSERT IGNORE INTO categories (category_id, category_name, description) VALUES (@0, @1, @2)";
                        else if (fileName.Contains("board_games"))
                            sql = "INSERT IGNORE INTO board_games (game_id, category_id, title, description, price, stock_quantity, min_players, max_players, age_rating) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
                        else if (fileName.Contains("customers"))
                            sql = "INSERT IGNORE INTO customers (customer_id, full_name, phone) VALUES (@0, @1, @2)";
                        else if (fileName.Contains("users"))
                            sql = "INSERT IGNORE INTO users (user_id, full_name, login, password_hash, role, phone, registration_date) VALUES (@0, @1, @2, @3, @4, @5, @6)";
                        else if (fileName.Contains("order_items"))
                            sql = "INSERT IGNORE INTO order_items (order_item_id, order_id, game_id, quantity, unit_price) VALUES (@0, @1, @2, @3, @4)";
                        else if (fileName.Contains("orders"))
                            sql = "INSERT IGNORE INTO orders (order_id, customer_id, user_id, status_id, order_date, completion_date, discount, total_without_discount, total_with_discount, total_amount, shipping_address) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";
                        else continue;

                        string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string line = lines[i].Trim();
                            if (line == "") continue;

                            string[] parts = line.Replace("\"", "").Split(';');
                            try
                            {
                                MySqlCommand cmd = new MySqlCommand(sql, conn);
                                for (int j = 0; j < parts.Length; j++)
                                {
                                    if (j > 10) break;

                                    string val = parts[j].Trim();

                                    // Конвертация дат для Заказов (колонки 4 и 5)
                                    if (fileName.Contains("orders") && !fileName.Contains("items") && (j == 4 || j == 5))
                                    {
                                        if (string.IsNullOrEmpty(val)) cmd.Parameters.AddWithValue("@" + j, DBNull.Value);
                                        else cmd.Parameters.AddWithValue("@" + j, DateTime.Parse(val).ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    // Конвертация цен (замена запятой на точку)
                                    else if ((fileName.Contains("board_games") && j == 4) || (fileName.Contains("orders") && (j == 6 || j == 7 || j == 8 || j == 9)))
                                    {
                                        val = val.Replace(",", ".");
                                        cmd.Parameters.AddWithValue("@" + j, val);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@" + j, val);
                                    }
                                }
                                cmd.ExecuteNonQuery();
                                imported++;
                            }
                            catch (Exception ex) { errors++; lastError = ex.Message; }
                        }
                    }
                }
                Cursor = Cursors.Default;
                string msg = $"Успешно импортировано: {imported}\nОшибок: {errors}";
                if (errors > 0) msg += $"\n\nПоследняя ошибка: {lastError}";
                MessageBox.Show(msg, "Результат импорта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { Cursor = Cursors.Default; MessageBox.Show("Критическая ошибка: " + ex.Message); }
        }

        private void RefreshBackupsList()
        {
            string folder = txtFolder.Text;
            if (!Directory.Exists(folder)) { dgvBackups.DataSource = null; return; }

            DataTable dt = new DataTable();
            dt.Columns.Add("Имя файла"); dt.Columns.Add("Дата"); dt.Columns.Add("Размер");

            string[] files = Directory.GetFiles(folder, "*.sql");
            Array.Sort(files); Array.Reverse(files);

            foreach (string file in files) { FileInfo fi = new FileInfo(file); dt.Rows.Add(fi.Name, fi.CreationTime.ToString("dd.MM.yyyy HH:mm"), (fi.Length / 1024) + " КБ"); }
            dgvBackups.DataSource = dt;
        }

        private void btnBackupManual_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolder.Text)) Directory.CreateDirectory(txtFolder.Text);
            string fileName = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";
            string filePath = Path.Combine(txtFolder.Text, fileName);
            Cursor = Cursors.WaitCursor;

            try
            {
                string mysqldump = FindMysqldumpPath();
                if (string.IsNullOrEmpty(mysqldump)) { MessageBox.Show("mysqldump.exe не найден!"); return; }

                string args = "-u" + DbConfig.User + " ";
                if (!string.IsNullOrEmpty(DbConfig.Password)) args += "-p" + DbConfig.Password + " ";
                args += "--databases " + DbConfig.Database + " --result-file=\"" + filePath + "\"";

                ProcessStartInfo psi = new ProcessStartInfo { FileName = mysqldump, Arguments = args, UseShellExecute = false, CreateNoWindow = true, RedirectStandardError = true };
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    if (process.ExitCode == 0) { Log("Бэкап: " + fileName); MessageBox.Show("Бэкап создан!"); RefreshBackupsList(); }
                    else { MessageBox.Show("Ошибка: " + process.StandardError.ReadToEnd()); }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            finally { Cursor = Cursors.Default; }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvBackups.CurrentRow == null) { MessageBox.Show("Выберите бэкап!"); return; }
            string fileName = dgvBackups.CurrentRow.Cells[0].Value.ToString();
            string filePath = Path.Combine(txtFolder.Text, fileName);

            if (MessageBox.Show("Восстановить базу?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            Cursor = Cursors.WaitCursor;

            try
            {
                string serverConn = "server=" + DbConfig.Server + ";port=" + DbConfig.Port + ";user=" + DbConfig.User + ";password=" + DbConfig.Password + ";charset=utf8mb4;AllowPublicKeyRetrieval=True;";
                using (MySqlConnection conn = new MySqlConnection(serverConn))
                {
                    conn.Open();
                    new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + DbConfig.Database + "`", conn).ExecuteNonQuery();
                    conn.ChangeDatabase(DbConfig.Database);
                    new MySqlScript(conn, File.ReadAllText(filePath)).Execute();

                    try { DbInitializer.EnsureDefaultUsers(); } catch { }

                    Log("Восстановлено из " + fileName);
                    MessageBox.Show("База восстановлена, пользователи созданы!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            finally { Cursor = Cursors.Default; }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT o.order_id, c.full_name, o.order_date, o.total_amount FROM orders o JOIN customers c ON o.customer_id = c.customer_id WHERE o.order_date >= @df AND o.order_date < @dt ORDER BY o.order_date ASC", conn);
                    cmd.Parameters.AddWithValue("@df", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@dt", dtpTo.Value.Date.AddDays(1));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable(); da.Fill(dt);

                    if (dt.Rows.Count == 0) { MessageBox.Show("Нет данных."); return; }

                    decimal totalSum = 0; foreach (DataRow row in dt.Rows) totalSum += Convert.ToDecimal(row["total_amount"]);

                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine("sep=;");
                    csv.AppendLine("Номер заказа;Клиент;Дата;Сумма");
                    foreach (DataRow row in dt.Rows) csv.AppendLine(row["order_id"] + ";" + row["full_name"] + ";" + Convert.ToDateTime(row["order_date"]).ToString("dd.MM.yyyy HH:mm") + ";" + Convert.ToDecimal(row["total_amount"]).ToString("0.00"));
                    csv.AppendLine(";;ИТОГО:;" + totalSum.ToString("0.00"));

                    SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel (*.csv)|*.csv", FileName = "Отчет_" + dtpFrom.Value.ToString("ddMMyyyy") + ".csv" };
                    if (sfd.ShowDialog() == DialogResult.OK) { File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.UTF8); Process.Start(sfd.FileName); }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void Log(string message) { txtLog.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - " + message + Environment.NewLine); }

        private string FindMysqldumpPath()
        {
            string[] paths = { @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe", @"C:\Program Files\MySQL\MySQL Server 5.7\bin\mysqldump.exe", @"C:\xampp\mysql\bin\mysqldump.exe" };
            foreach (string p in paths) if (File.Exists(p)) return p;
            return null;
        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}