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
            "users",
            "customers",
            "categories",
            "statuses",
            "board_games",
            "orders",
            "order_items"
        };

        private Timer autoBackupTimer;
        private DateTime lastBackupTime = DateTime.MinValue;

        private static string SettingsPath =
            Path.Combine(Application.StartupPath, "backup_settings.txt");

        public SpecialForm()
        {
            InitializeComponent();

            clbTables.Items.Clear();

            foreach (string t in TablesInOrder)
            {
                clbTables.Items.Add(t);
            }

            LoadOrdersToCombo();
            LoadAutoBackupSettings();

            autoBackupTimer = new Timer();
            autoBackupTimer.Interval = 1000;
            autoBackupTimer.Tick += autoBackupTimer_Tick;

            Log("Готово. Выберите таблицы и папку.");
        }

        private void Log(string text)
        {
            string line = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text + "\r\n";

            txtLog.AppendText(line);
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
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
                        chkBackupAuto.Checked = lines[0] == "1";
                        nudInterval.Value = Convert.ToInt32(lines[1]);
                        txtFolder.Text = lines[2];
                    }
                }
            }
            catch
            {
            }
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
                if (string.IsNullOrWhiteSpace(txtFolder.Text) || !Directory.Exists(txtFolder.Text))
                {
                    MessageHelper.ShowWarning("Сначала выберите папку для авторезерва");
                    chkBackupAuto.Checked = false;
                    return;
                }

                lastBackupTime = DateTime.Now;
                autoBackupTimer.Start();

                Log("Авторезерв ВКЛЮЧЁН. Интервал: " + nudInterval.Value + " ч.");
                MessageHelper.ShowInfo("Авторезерв включён\nИнтервал: " + nudInterval.Value + " ч.");
            }
            else
            {
                autoBackupTimer.Stop();

                Log("Авторезерв ВЫКЛЮЧЕН.");
                MessageHelper.ShowInfo("Авторезерв выключен");
            }

            SaveAutoBackupSettings();
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            SaveAutoBackupSettings();

            if (chkBackupAuto.Checked)
            {
                Log("Интервал изменён: " + nudInterval.Value + " ч.");
            }
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
                    string folder = txtFolder.Text;

                    if (!Directory.Exists(folder))
                    {
                        Log("Ошибка: папка " + folder + " не найдена");
                        return;
                    }

                    string file = Path.Combine(folder,
                        "autobackup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql");

                    MakeBackup(file);

                    Log("Автобэкап создан: " + Path.GetFileName(file));
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
            fbd.Description = "Выберите папку для CSV и бэкапов";

            if (fbd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtFolder.Text = fbd.SelectedPath;

            Log("Папка: " + fbd.SelectedPath);
            SaveAutoBackupSettings();
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

        private List<string> GetSelectedTables()
        {
            HashSet<string> checkedSet = new HashSet<string>();

            foreach (var item in clbTables.CheckedItems)
            {
                checkedSet.Add(item.ToString());
            }

            List<string> result = new List<string>();

            foreach (string t in TablesInOrder)
            {
                if (checkedSet.Contains(t))
                {
                    result.Add(t);
                }
            }

            return result;
        }

        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            List<string> tables = GetSelectedTables();

            if (tables.Count == 0)
            {
                MessageHelper.ShowWarning("Выберите хотя бы одну таблицу");
                return;
            }

            string folder = txtFolder.Text;

            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
            {
                MessageHelper.ShowWarning("Сначала выберите папку");
                return;
            }

            Log("=== ЭКСПОРТ CSV ===");

            int ok = 0;
            int errors = 0;

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

            Log("Итого: успешно " + ok + ", ошибок " + errors);
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

                        if (i < reader.FieldCount - 1)
                        {
                            writer.Write(";");
                        }
                    }

                    writer.WriteLine();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string val = reader.IsDBNull(i)
                                ? ""
                                : reader.GetValue(i).ToString();

                            if (val.Contains(";") || val.Contains("\"") ||
                                val.Contains("\n") || val.Contains("\r"))
                            {
                                val = "\"" + val.Replace("\"", "\"\"") + "\"";
                            }

                            writer.Write(val);

                            if (i < reader.FieldCount - 1)
                            {
                                writer.Write(";");
                            }
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

            if (tables.Count == 0)
            {
                MessageHelper.ShowWarning("Выберите хотя бы одну таблицу");
                return;
            }

            string folder = txtFolder.Text;

            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
            {
                MessageHelper.ShowWarning("Сначала выберите папку");
                return;
            }

            if (!MessageHelper.AskConfirm("Импорт добавит данные в существующие таблицы. Продолжить?"))
            {
                return;
            }

            Log("=== ИМПОРТ CSV ===");

            int ok = 0;
            int errors = 0;

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

            Log("Итого: успешно " + ok + ", ошибок " + errors);
            MessageHelper.ShowInfo("Импорт завершён\nУспешно: " + ok + "\nОшибок: " + errors);
        }

        private int ImportTable(string table, string path)
        {
            int inserted = 0;

            string[] lines = File.ReadAllLines(path, Encoding.UTF8);

            if (lines.Length < 2)
            {
                return 0;
            }

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

            if (validColumns.Count == 0)
            {
                return 0;
            }

            string colList = string.Join(", ", validColumns);
            string paramList = "@p" + string.Join(", @p", Enumerable.Range(0, validColumns.Count));

            string sql = "INSERT IGNORE INTO " + table +
                         " (" + colList + ") VALUES (" + paramList + ")";

            using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
            {
                conn.Open();

                MySqlCommand fk0 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0", conn);
                fk0.ExecuteNonQuery();

                try
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i]))
                        {
                            continue;
                        }

                        string[] values = SplitCsvLine(lines[i]);

                        if (values.Length != csvColumns.Length)
                        {
                            continue;
                        }

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            for (int k = 0; k < validColumns.Count; k++)
                            {
                                int csvIndex = validIndexes[k];
                                string v = values[csvIndex];

                                if (string.IsNullOrEmpty(v))
                                {
                                    cmd.Parameters.AddWithValue("@p" + k, DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@p" + k, v);
                                }
                            }

                            inserted += cmd.ExecuteNonQuery();
                        }
                    }
                }
                finally
                {
                    MySqlCommand fk1 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1", conn);
                    fk1.ExecuteNonQuery();
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

                    MySqlCommand cmd = new MySqlCommand("SHOW COLUMNS FROM " + table, conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columns.Add(reader["Field"].ToString());
                        }
                    }
                }
            }
            catch
            {
            }

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
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            sb.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == ';')
                    {
                        result.Add(sb.ToString());
                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            result.Add(sb.ToString());

            return result.ToArray();
        }

        private void btnBackupManual_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SQL|*.sql";
            sfd.FileName = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Log("=== РУЧНОЙ БЭКАП ===");
            Log("Файл: " + sfd.FileName);

            try
            {
                MakeBackup(sfd.FileName);

                Log("Готово: " + sfd.FileName);
                MessageHelper.ShowInfo("Резервная копия создана:\n" + sfd.FileName);
            }
            catch (Exception ex)
            {
                Log("Ошибка: " + ex.Message);
                MessageHelper.ShowError("Ошибка: " + ex.Message);
            }
        }

        private void MakeBackup(string path)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("USE board_game_store;");
            sb.AppendLine();

            foreach (string table in TablesInOrder)
            {
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
                                if (reader.IsDBNull(i))
                                {
                                    sb.Append("NULL");
                                }
                                else
                                {
                                    object v = reader.GetValue(i);

                                    if (v is string || v is DateTime)
                                    {
                                        sb.Append("'" + v.ToString().Replace("'", "''") + "'");
                                    }
                                    else
                                    {
                                        sb.Append(v.ToString().Replace(",", "."));
                                    }
                                }

                                if (i < reader.FieldCount - 1)
                                {
                                    sb.Append(", ");
                                }
                            }

                            sb.AppendLine(");");
                            rows++;
                        }

                        Log("  OK " + table + " (" + rows + " записей)");
                    }
                }

                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (cmbOrder.SelectedValue == null)
            {
                MessageHelper.ShowWarning("Выберите заказ");
                return;
            }

            int orderId = Convert.ToInt32(cmbOrder.SelectedValue);

            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Чек_Заказ_" + orderId + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".doc");

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("==========================================");
                sb.AppendLine("        МАГАЗИН НАСТОЛЬНЫХ ИГР");
                sb.AppendLine("==========================================");
                sb.AppendLine("Чек № " + orderId);
                sb.AppendLine("Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                sb.AppendLine("------------------------------------------");

                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string sqlOrder =
                        "SELECT c.full_name, o.order_date, o.discount, " +
                        "o.total_without_discount, o.total_with_discount, o.total_amount, " +
                        "s.status_name FROM orders o " +
                        "JOIN customers c ON o.customer_id=c.customer_id " +
                        "JOIN statuses s ON o.status_id=s.status_id " +
                        "WHERE o.order_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sqlOrder, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            sb.AppendLine("Клиент: " + r["full_name"]);
                            sb.AppendLine("Дата: " + Convert.ToDateTime(r["order_date"]).ToString("dd.MM.yyyy HH:mm"));
                            sb.AppendLine("Статус: " + r["status_name"]);
                            sb.AppendLine("------------------------------------------");
                            sb.AppendLine("Состав заказа:");
                        }
                    }

                    MySqlCommand cmdItems = new MySqlCommand(
                        "SELECT g.title, oi.quantity, oi.unit_price, " +
                        "(oi.quantity*oi.unit_price) AS total " +
                        "FROM order_items oi " +
                        "JOIN board_games g ON oi.game_id=g.game_id " +
                        "WHERE oi.order_id=@id", conn);
                    cmdItems.Parameters.AddWithValue("@id", orderId);

                    using (var r = cmdItems.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            sb.AppendLine("  " + r["title"] + " x" + r["quantity"] +
                                          " = " + Convert.ToDecimal(r["total"]).ToString("0.00") + " руб.");
                        }
                    }

                    sb.AppendLine("------------------------------------------");

                    MySqlCommand cmdTotal = new MySqlCommand(sqlOrder, conn);
                    cmdTotal.Parameters.AddWithValue("@id", orderId);

                    using (var r = cmdTotal.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            decimal sw = Convert.ToDecimal(r["total_without_discount"]);
                            decimal sww = Convert.ToDecimal(r["total_with_discount"]);
                            decimal disc = Convert.ToDecimal(r["discount"]);

                            sb.AppendLine("Без скидки: " + sw.ToString("0.00") + " руб.");
                            sb.AppendLine("Скидка (" + disc + "%): -" + (sw - sww).ToString("0.00") + " руб.");
                            sb.AppendLine("ИТОГО К ОПЛАТЕ: " + sww.ToString("0.00") + " руб.");
                        }
                    }
                }

                sb.AppendLine("==========================================");
                sb.AppendLine("Спасибо за покупку!");

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

                MessageHelper.ShowInfo("Чек сохранён:\n" + path);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка: " + ex.Message);
            }
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

                    string sql =
                        "SELECT o.order_id, c.full_name, o.order_date, s.status_name, " +
                        "o.total_amount FROM orders o " +
                        "JOIN customers c ON o.customer_id=c.customer_id " +
                        "JOIN statuses s ON o.status_id=s.status_id " +
                        "WHERE o.order_date >= @f AND o.order_date <= @t " +
                        "ORDER BY o.order_date";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@f", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@t", dtpTo.Value.Date.AddDays(1));

                    using (var r = cmd.ExecuteReader())
                    using (StreamWriter w = new StreamWriter(path, false, new UTF8Encoding(true)))
                    {
                        w.WriteLine("МАГАЗИН НАСТОЛЬНЫХ ИГР");
                        w.WriteLine("Отчёт по заказам");
                        w.WriteLine("Период: " + dtpFrom.Value.ToShortDateString()
                            + " - " + dtpTo.Value.ToShortDateString());
                        w.WriteLine("Дата формирования: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                        w.WriteLine();
                        w.WriteLine("Номер;Клиент;Дата;Статус;Сумма");

                        while (r.Read())
                        {
                            w.WriteLine(
                                r["order_id"] + ";" +
                                r["full_name"] + ";" +
                                Convert.ToDateTime(r["order_date"]).ToShortDateString() + ";" +
                                r["status_name"] + ";" +
                                r["total_amount"]);
                        }
                    }

                    MySqlCommand cmdTotal = new MySqlCommand(
                        "SELECT COUNT(*) AS c, IFNULL(SUM(total_amount), 0) AS s, " +
                        "IFNULL(AVG(total_amount), 0) AS avg_sum, " +
                        "IFNULL(MAX(total_amount), 0) AS max_sum " +
                        "FROM orders WHERE order_date >= @f AND order_date <= @t", conn);

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
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка отчёта: " + ex.Message);
            }
        }

        private void LoadOrdersToCombo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT o.order_id, c.full_name FROM orders o " +
                                 "JOIN customers c ON o.customer_id=c.customer_id " +
                                 "ORDER BY o.order_id DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbOrder.DataSource = dt;
                    cmbOrder.DisplayMember = "order_id";
                    cmbOrder.ValueMember = "order_id";
                }
            }
            catch
            {
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            autoBackupTimer.Stop();
            this.Close();
        }
    }
}