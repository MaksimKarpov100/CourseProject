using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class SpecialForm : Form
    {
        public SpecialForm()
        {
            InitializeComponent();
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
                        if (i < dt.Columns.Count - 1) sb.Append(";");
                    }
                    sb.AppendLine();

                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sb.Append(row[i].ToString().Replace(";", ","));
                            if (i < dt.Columns.Count - 1) sb.Append(";");
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

            int imported = 0;
            int errors = 0;
            string lastError = "";
            Cursor = Cursors.WaitCursor;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string[] files = ofd.FileNames;
                    Array.Sort(files, CompareFilesByDependency);

                    foreach (string filePath in files)
                    {
                        string fileName = Path.GetFileName(filePath).ToLower();
                        string sql = "";

                        if (fileName.Contains("categories") == true)
                        {
                            sql = "INSERT IGNORE INTO categories (category_id, category_name, description) VALUES (@0, @1, @2)";
                        }
                        else if (fileName.Contains("board_games") == true)
                        {
                            sql = "INSERT IGNORE INTO board_games (game_id, category_id, title, description, price, stock_quantity, min_players, max_players, age_rating) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
                        }
                        else if (fileName.Contains("customers") == true)
                        {
                            sql = "INSERT IGNORE INTO customers (customer_id, full_name, phone) VALUES (@0, @1, @2)";
                        }
                        else if (fileName.Contains("users") == true)
                        {
                            sql = "INSERT IGNORE INTO users (user_id, full_name, login, password_hash, role, phone, registration_date) VALUES (@0, @1, @2, @3, @4, @5, @6)";
                        }
                        else if (fileName.Contains("order_items") == true)
                        {
                            sql = "INSERT IGNORE INTO order_items (order_item_id, order_id, game_id, quantity, unit_price) VALUES (@0, @1, @2, @3, @4)";
                        }
                        else if (fileName.Contains("orders") == true)
                        {
                            sql = "INSERT IGNORE INTO orders (order_id, customer_id, user_id, status_id, order_date, completion_date, discount, total_without_discount, total_with_discount, total_amount, shipping_address) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";
                        }
                        else
                        {
                            continue;
                        }

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

                                    if (fileName.Contains("orders") == true && fileName.Contains("items") == false && (j == 4 || j == 5))
                                    {
                                        if (string.IsNullOrEmpty(val) == true)
                                            cmd.Parameters.AddWithValue("@" + j, DBNull.Value);
                                        else
                                            cmd.Parameters.AddWithValue("@" + j, DateTime.Parse(val).ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    else if ((fileName.Contains("board_games") == true && j == 4) || (fileName.Contains("orders") == true && (j == 6 || j == 7 || j == 8 || j == 9)))
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
                            catch (Exception ex)
                            {
                                errors++;
                                lastError = ex.Message;
                            }
                        }
                    }
                }

                Cursor = Cursors.Default;
                string msg = "Успешно импортировано: " + imported + "\nОшибок: " + errors;
                if (errors > 0) msg = msg + "\n\nПоследняя ошибка: " + lastError;

                MessageHelper.ShowInfo(msg);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageHelper.ShowError("Критическая ошибка импорта: " + ex.Message);
            }
        }

        private int CompareFilesByDependency(string fileA, string fileB)
        {
            string nameA = Path.GetFileName(fileA).ToLower();
            string nameB = Path.GetFileName(fileB).ToLower();
            int orderA = GetTablePriority(nameA);
            int orderB = GetTablePriority(nameB);
            return orderA.CompareTo(orderB);
        }

        private int GetTablePriority(string fileName)
        {
            if (fileName.Contains("categories") == true) return 1;
            if (fileName.Contains("users") == true) return 2;
            if (fileName.Contains("customers") == true) return 3;
            if (fileName.Contains("board_games") == true) return 4;
            if (fileName.Contains("orders") == true && fileName.Contains("items") == false) return 5;
            if (fileName.Contains("order_items") == true) return 6;
            return 0;
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
                    args = args + "-p" + DbConfig.Password + " ";
                }
                args = args + "--databases " + DbConfig.Database + " --result-file=\"" + filePath + "\"";

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
                        Log("Бэкап: " + fileName);
                        MessageHelper.ShowInfo("Резервная копия успешно создана!");
                        RefreshBackupsList();
                    }
                    else
                    {
                        MessageHelper.ShowError("Ошибка mysqldump: " + process.StandardError.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка создания бэкапа: " + ex.Message);
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

                    try { DbInitializer.EnsureDefaultUsers(); } catch { }

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

                decimal totalSum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalSum = totalSum + Convert.ToDecimal(row["total_amount"]);
                }

                StringBuilder csv = new StringBuilder();
                csv.AppendLine("sep=;");
                csv.AppendLine("Номер заказа;Клиент;Дата;Сумма");

                foreach (DataRow row in dt.Rows)
                {
                    string line = row["order_id"] + ";" + row["full_name"] + ";" + Convert.ToDateTime(row["order_date"]).ToString("dd.MM.yyyy HH:mm") + ";" + Convert.ToDecimal(row["total_amount"]).ToString("0.00");
                    csv.AppendLine(line);
                }

                csv.AppendLine(";;ИТОГО:;" + totalSum.ToString("0.00"));

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel документ (*.csv)|*.csv";
                sfd.FileName = "Отчет_" + dtpFrom.Value.ToString("ddMMyyyy") + ".csv";

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
                    if (string.IsNullOrEmpty(output) == false && File.Exists(output) == true)
                    {
                        return output;
                    }
                }
            }
            catch { }

            string[] searchFolders = new string[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\MySQL",
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\MySQL",
                "C:\\xampp\\mysql\\bin",
                "C:\\OpenServer\\modules\\database\\MySQL"
            };

            foreach (string folder in searchFolders)
            {
                if (Directory.Exists(folder) == true)
                {
                    try
                    {
                        string[] foundFiles = Directory.GetFiles(folder, "mysqldump.exe", SearchOption.AllDirectories);
                        if (foundFiles.Length > 0) return foundFiles[0];
                    }
                    catch { }
                }
            }

            return null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}