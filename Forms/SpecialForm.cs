using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class SpecialForm : Form
    {
        private static readonly string[] TablesInOrder =
        {
            "users", "customers", "categories", "statuses",
            "board_games", "orders", "order_items"
        };

        private Timer autoBackupTimer;
        private DateTime lastBackupTime = DateTime.MinValue;

        private static string SettingsPath = Path.Combine(Application.StartupPath, "backup_settings.txt");

        private string BackupFolder = Path.Combine(Application.StartupPath, "Backup");

        public SpecialForm()
        {
            InitializeComponent();

            if (!Directory.Exists(BackupFolder))
            {
                Directory.CreateDirectory(BackupFolder);
            }

            lblBackupsTitle.Text = "Доступные копии в папке: " + BackupFolder;

            autoBackupTimer = new Timer();
            autoBackupTimer.Interval = 1000;
            autoBackupTimer.Tick += autoBackupTimer_Tick;

            clbTables.Items.Clear();
            foreach (string t in TablesInOrder)
            {
                clbTables.Items.Add(t);
            }

            LoadAutoBackupSettings();
            LoadBackupsList();
            Log("Готово. Папка бэкапов: " + BackupFolder);
        }

        private void Log(string text)
        {
            string line = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text + "\r\n";
            txtLog.AppendText(line);
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        private void LoadBackupsList()
        {
            if (!Directory.Exists(BackupFolder))
            {
                Directory.CreateDirectory(BackupFolder);
            }

            try
            {
                var files = Directory.GetFiles(BackupFolder, "*.sql");

                dgvBackups.DataSource = null;
                dgvBackups.Rows.Clear();
                dgvBackups.Columns.Clear();

                DataTable dt = new DataTable();
                dt.Columns.Add("Имя файла", typeof(string));
                dt.Columns.Add("Дата создания", typeof(string));
                dt.Columns.Add("Размер", typeof(string));
                dt.Columns.Add("FullPath", typeof(string)); 

                foreach (var file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    dt.Rows.Add(fi.Name, fi.CreationTime.ToString("dd.MM.yyyy HH:mm"),
                        Math.Ceiling(fi.Length / 1024.0) + " KB", fi.FullName);
                }

                dgvBackups.DataSource = dt;

                if (dgvBackups.Columns.Contains("FullPath"))
                    dgvBackups.Columns["FullPath"].Visible = false;

                dgvBackups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                Log("Ошибка чтения папки с бэкапами: " + ex.Message);
            }
        }

        private void btnRefreshBackups_Click(object sender, EventArgs e)
        {
            LoadBackupsList();
            Log("Список бэкапов обновлен.");
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvBackups.CurrentRow == null)
            {
                MessageHelper.ShowWarning("Выберите файл бэкапа из списка");
                return;
            }

            string filePath = dgvBackups.CurrentRow.Cells["FullPath"].Value.ToString();
            string fileName = dgvBackups.CurrentRow.Cells["Имя файла"].Value.ToString();

            if (!MessageHelper.AskConfirm($"ВНИМАНИЕ!\nВы собираетесь восстановить базу данных из файла:\n{fileName}\n\nВсе текущие данные будут УДАЛЕНЫ и заменены данными из копии. Продолжить?"))
            {
                return;
            }

            Log("=== ВОССТАНОВЛЕНИЕ ИЗ БЭКАПА ===");
            Log("Файл: " + fileName);

            try
            {
                string script = File.ReadAllText(filePath, Encoding.UTF8);

                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlScript mySqlScript = new MySqlScript(conn, script);
                    mySqlScript.Execute();
                }

                Log("УСПЕХ: База данных успешно восстановлена.");
                MessageHelper.ShowInfo("База данных успешно восстановлена!");
            }
            catch (Exception ex)
            {
                Log("ОШИБКА ВОССТАНОВЛЕНИЯ: " + ex.Message);
                MessageHelper.ShowError("Ошибка восстановления:\n" + ex.Message);
            }
        }

        private void LoadAutoBackupSettings()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    string[] lines = File.ReadAllLines(SettingsPath);
                    if (lines.Length >= 3)
                    {
                        nudInterval.Value = Convert.ToInt32(lines[1]);
                        if (!string.IsNullOrWhiteSpace(lines[2]))
                            txtFolder.Text = lines[2];

                        chkBackupAuto.Checked = lines[0] == "1";
                    }
                }
            }
            catch { }
        }

        private void SaveAutoBackupSettings()
        {
            try
            {
                string[] lines = new string[]
                {
                    chkBackupAuto.Checked ? "1" : "0",
                    ((int)nudInterval.Value).ToString(),
                    txtFolder.Text 
                };
                File.WriteAllLines(SettingsPath, lines);
            }
            catch (Exception ex)
            {
                Log("Ошибка сохранения настроек: " + ex.Message);
            }
        }

        private void chkBackupAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBackupAuto.Checked)
            {
                lastBackupTime = DateTime.Now;
                autoBackupTimer.Start();
                Log("Авторезерв ВКЛЮЧЁН. Интервал: " + nudInterval.Value + " ч.");
            }
            else
            {
                autoBackupTimer.Stop();
                Log("Авторезерв ВЫКЛЮЧЕН.");
            }
            SaveAutoBackupSettings();
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            SaveAutoBackupSettings();
            if (chkBackupAuto.Checked) Log("Интервал изменён: " + nudInterval.Value + " ч.");
        }

        private void autoBackupTimer_Tick(object sender, EventArgs e)
        {
            double hoursPassed = (DateTime.Now - lastBackupTime).TotalHours;

            if (hoursPassed >= (double)nudInterval.Value)
            {
                lastBackupTime = DateTime.Now;
                Log("=== АВТОРЕЗЕРВ ===");

                try
                {
                    string file = Path.Combine(BackupFolder, "autobackup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql");
                    MakeBackup(file);
                    Log("Автобэкап создан: " + Path.GetFileName(file));
                    LoadBackupsList();
                }
                catch (Exception ex)
                {
                    Log("Ошибка авторезерва: " + ex.Message);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Выберите папку для экспорта/импорта CSV файлов";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fbd.SelectedPath;
                Log("Папка для CSV: " + fbd.SelectedPath);
                SaveAutoBackupSettings();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTables.Items.Count; i++) clbTables.SetItemChecked(i, true);
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTables.Items.Count; i++) clbTables.SetItemChecked(i, false);
        }

        private List<string> GetSelectedTables()
        {
            HashSet<string> checkedSet = new HashSet<string>();
            foreach (var item in clbTables.CheckedItems) checkedSet.Add(item.ToString());

            List<string> result = new List<string>();
            foreach (string t in TablesInOrder)
            {
                if (checkedSet.Contains(t)) result.Add(t);
            }
            return result;
        }

        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            List<string> tables = GetSelectedTables();
            if (tables.Count == 0) { MessageHelper.ShowWarning("Выберите хотя бы одну таблицу"); return; }

            string folder = txtFolder.Text;
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder)) { MessageHelper.ShowWarning("Сначала выберите папку для CSV"); return; }

            Log("=== ЭКСПОРТ CSV ===");
            int ok = 0, errors = 0;

            foreach (string table in tables)
            {
                try
                {
                    string path = Path.Combine(folder, table + ".csv");
                    int rows = ExportTable(table, path);
                    Log("  OK " + table + " -> " + Path.GetFileName(path) + " (" + rows + " записей)");
                    ok++;
                }
                catch (Exception ex)
                {
                    Log("  ОШИБКА " + table + " -> " + ex.Message);
                    errors++;
                }
            }
            MessageHelper.ShowInfo("Экспорт завершён\nУспешно: " + ok + "\nОшибок: " + errors);
        }

        private int ExportTable(string table, string path)
        {
            int rows = 0;
            using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + table, conn);

                using (var reader = cmd.ExecuteReader())
                using (StreamWriter writer = new StreamWriter(path, false, new UTF8Encoding(true)))
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        writer.Write(reader.GetName(i));
                        if (i < reader.FieldCount - 1) writer.Write(";");
                    }
                    writer.WriteLine();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string val = reader.IsDBNull(i) ? "" : reader.GetValue(i).ToString();
                            if (val.Contains(";") || val.Contains("\"") || val.Contains("\n") || val.Contains("\r"))
                                val = "\"" + val.Replace("\"", "\"\"") + "\"";
                            writer.Write(val);
                            if (i < reader.FieldCount - 1) writer.Write(";");
                        }
                        writer.WriteLine();
                        rows++;
                    }
                }
            }
            return rows;
        }

        private void btnImportSelected_Click(object sender, EventArgs e)
        {
            List<string> tables = GetSelectedTables();
            if (tables.Count == 0) { MessageHelper.ShowWarning("Выберите хотя бы одну таблицу"); return; }

            string folder = txtFolder.Text;
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder)) { MessageHelper.ShowWarning("Сначала выберите папку для CSV"); return; }
            if (!MessageHelper.AskConfirm("Импорт добавит данные в существующие таблицы. Продолжить?")) return;

            Log("=== ИМПОРТ CSV ===");
            int ok = 0, errors = 0;

            foreach (string table in tables)
            {
                string path = Path.Combine(folder, table + ".csv");
                if (!File.Exists(path))
                {
                    Log("  ОШИБКА: файл не найден " + path);
                    errors++;
                    continue;
                }

                try
                {
                    int rows = ImportTable(table, path);
                    Log("  OK " + Path.GetFileName(path) + " -> " + table + " (" + rows + " записей)");
                    ok++;
                }
                catch (Exception ex)
                {
                    Log("  ОШИБКА " + table + " -> " + ex.Message);
                    errors++;
                }
            }
            MessageHelper.ShowInfo("Импорт завершён\nУспешно: " + ok + "\nОшибок: " + errors);
        }

        private int ImportTable(string table, string path)
        {
            int inserted = 0;
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            if (lines.Length < 2) return 0;

            string[] csvColumns = SplitCsvLine(lines[0]);
            List<string> realColumns = GetTableColumns(table);
            List<string> validColumns = new List<string>();
            List<int> validIndexes = new List<int>();

            for (int i = 0; i < csvColumns.Length; i++)
            {
                if (realColumns.Contains(csvColumns[i]))
                {
                    validColumns.Add(csvColumns[i]);
                    validIndexes.Add(i);
                }
            }

            if (validColumns.Count == 0) return 0;

            string colList = string.Join(", ", validColumns);
            string paramList = "@p" + string.Join(", @p", Enumerable.Range(0, validColumns.Count));
            string sql = "INSERT IGNORE INTO " + table + " (" + colList + ") VALUES (" + paramList + ")";

            using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
            {
                conn.Open();
                new MySqlCommand("SET FOREIGN_KEY_CHECKS=0", conn).ExecuteNonQuery();
                try
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i])) continue;
                        string[] values = SplitCsvLine(lines[i]);
                        if (values.Length != csvColumns.Length) continue;

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            for (int k = 0; k < validColumns.Count; k++)
                            {
                                int csvIndex = validIndexes[k];
                                string v = values[csvIndex];
                                cmd.Parameters.AddWithValue("@p" + k, string.IsNullOrEmpty(v) ? (object)DBNull.Value : v);
                            }
                            inserted += cmd.ExecuteNonQuery();
                        }
                    }
                }
                finally
                {
                    new MySqlCommand("SET FOREIGN_KEY_CHECKS=1", conn).ExecuteNonQuery();
                }
            }
            return inserted;
        }

        private List<string> GetTableColumns(string table)
        {
            List<string> columns = new List<string>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    using (var reader = new MySqlCommand("SHOW COLUMNS FROM " + table, conn).ExecuteReader())
                    {
                        while (reader.Read()) columns.Add(reader["Field"].ToString());
                    }
                }
            }
            catch { }
            return columns;
        }

        private string[] SplitCsvLine(string line)
        {
            List<string> result = new List<string>();
            bool inQuotes = false;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"') { sb.Append('"'); i++; }
                        else inQuotes = false;
                    }
                    else sb.Append(c);
                }
                else
                {
                    if (c == '"') inQuotes = true;
                    else if (c == ';') { result.Add(sb.ToString()); sb.Clear(); }
                    else sb.Append(c);
                }
            }
            result.Add(sb.ToString());
            return result.ToArray();
        }

        private void btnBackupManual_Click(object sender, EventArgs e)
        {
            string fileName = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";
            string fullPath = Path.Combine(BackupFolder, fileName);

            Log("=== РУЧНОЙ БЭКАП ===");
            try
            {
                MakeBackup(fullPath);
                Log("Готово: " + fileName);
                MessageHelper.ShowInfo("Резервная копия успешно создана!\n" + fullPath);

                LoadBackupsList(); 
            }
            catch (Exception ex)
            {
                Log("Ошибка: " + ex.Message);
                MessageHelper.ShowError("Ошибка создания бэкапа: " + ex.Message);
            }
        }

        private void MakeBackup(string path)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SET FOREIGN_KEY_CHECKS=0;");
            sb.AppendLine("USE board_game_store;");
            sb.AppendLine();

            foreach (string table in TablesInOrder)
            {
                sb.AppendLine("DELETE FROM " + table + ";");

                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + table, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        int rows = 0;
                        while (reader.Read())
                        {
                            sb.Append("INSERT INTO " + table + " VALUES (");
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader.IsDBNull(i)) sb.Append("NULL");
                                else
                                {
                                    object v = reader.GetValue(i);
                                    if (v is string || v is DateTime) sb.Append("'" + v.ToString().Replace("'", "''") + "'");
                                    else sb.Append(v.ToString().Replace(",", "."));
                                }
                                if (i < reader.FieldCount - 1) sb.Append(", ");
                            }
                            sb.AppendLine(");");
                            rows++;
                        }
                        Log("  OK " + table + " (" + rows + " записей)");
                    }
                }
                sb.AppendLine();
            }

            sb.AppendLine("SET FOREIGN_KEY_CHECKS=1;");
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Отчёт_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");

                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT o.order_id, c.full_name, o.order_date, s.status_name, o.total_amount FROM orders o " +
                                 "JOIN customers c ON o.customer_id=c.customer_id " +
                                 "JOIN statuses s ON o.status_id=s.status_id " +
                                 "WHERE o.order_date >= @f AND o.order_date <= @t ORDER BY o.order_date";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@f", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@t", dtpTo.Value.Date.AddDays(1));

                    using (var r = cmd.ExecuteReader())
                    using (StreamWriter w = new StreamWriter(path, false, new UTF8Encoding(true)))
                    {
                        w.WriteLine("МАГАЗИН НАСТОЛЬНЫХ ИГР");
                        w.WriteLine("Отчёт по заказам");
                        w.WriteLine("Период: " + dtpFrom.Value.ToShortDateString() + " - " + dtpTo.Value.ToShortDateString());
                        w.WriteLine("Дата формирования: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                        w.WriteLine();
                        w.WriteLine("Номер;Клиент;Дата;Статус;Сумма");

                        while (r.Read())
                        {
                            w.WriteLine(r["order_id"] + ";" + r["full_name"] + ";" +
                                        Convert.ToDateTime(r["order_date"]).ToShortDateString() + ";" +
                                        r["status_name"] + ";" + r["total_amount"]);
                        }
                    }

                    MySqlCommand cmdTotal = new MySqlCommand("SELECT COUNT(*) AS c, IFNULL(SUM(total_amount), 0) AS s, IFNULL(AVG(total_amount), 0) AS avg_sum, IFNULL(MAX(total_amount), 0) AS max_sum FROM orders WHERE order_date >= @f AND order_date <= @t", conn);
                    cmdTotal.Parameters.AddWithValue("@f", dtpFrom.Value.Date);
                    cmdTotal.Parameters.AddWithValue("@t", dtpTo.Value.Date.AddDays(1));

                    using (var r = cmdTotal.ExecuteReader())
                    using (StreamWriter w = new StreamWriter(path, true, new UTF8Encoding(true)))
                    {
                        if (r.Read())
                        {
                            w.WriteLine();
                            w.WriteLine("========================================");
                            w.WriteLine("ИТОГИ ЗА ПЕРИОД:");
                            w.WriteLine("Количество заказов: " + r["c"]);
                            w.WriteLine("Общая выручка: " + Convert.ToDecimal(r["s"]).ToString("0.00") + " руб.");
                            w.WriteLine("Средний чек: " + Convert.ToDecimal(r["avg_sum"]).ToString("0.00") + " руб.");
                            w.WriteLine("Максимальный чек: " + Convert.ToDecimal(r["max_sum"]).ToString("0.00") + " руб.");
                            w.WriteLine("========================================");
                            w.WriteLine();
                            w.WriteLine("Отчёт сформирован: " + CurrentUser.FullName);
                        }
                    }
                }
                MessageHelper.ShowInfo("Отчёт сохранён:\n" + path);
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка отчёта: " + ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            autoBackupTimer.Stop();
            this.Close();
        }
    }
}