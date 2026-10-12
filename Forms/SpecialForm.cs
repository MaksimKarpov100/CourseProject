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
        private static string ConnectionString => DbConfig.BuildConnectionString();

        /// <summary>
        /// Порядок важен: сначала справочники без FK, потом зависимые таблицы.
        /// </summary>
        private static readonly string[] TablesInOrder =
        {
            "users", "customers", "categories", "statuses",
            "board_games", "orders", "order_items"
        };

        public SpecialForm()
        {
            InitializeComponent();

            clbTables.Items.Clear();
            foreach (string t in TablesInOrder)
                clbTables.Items.Add(t);

            LoadOrdersToCombo();
            Log("Готово. Выберите таблицы и папку, затем нажмите «Экспорт» или «Импорт».");
        }

        private void Log(string message)
        {
            string line = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + Environment.NewLine;
            txtLog.AppendText(line);
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        private void ClearLog()
        {
            txtLog.Clear();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTables.Items.Count; i++)
                clbTables.SetItemChecked(i, true);
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTables.Items.Count; i++)
                clbTables.SetItemChecked(i, false);
        }

        /// <summary>
        /// Возвращает выбранные таблицы в правильном порядке (FK-safe).
        /// </summary>
        private List<string> GetSelectedTables()
        {
            var checkedSet = new HashSet<string>();
            foreach (var item in clbTables.CheckedItems)
                checkedSet.Add(item.ToString());

            var result = new List<string>();
            foreach (string t in TablesInOrder)
                if (checkedSet.Contains(t))
                    result.Add(t);

            return result;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Выберите папку для CSV-файлов";
                if (fbd.ShowDialog() != DialogResult.OK) return;

                txtFolder.Text = fbd.SelectedPath;
                Log("Папка: " + fbd.SelectedPath);
            }
        }

        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            var tables = GetSelectedTables();
            if (tables.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одну таблицу");
                return;
            }

            string folder = txtFolder.Text;
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
            {
                MessageBox.Show("Сначала выберите папку");
                return;
            }

            ClearLog();
            Log("=== ЭКСПОРТ ===");
            Log("Папка: " + folder);

            int ok = 0, errors = 0;
            foreach (string table in tables)
            {
                try
                {
                    string path = Path.Combine(folder, table + ".csv");
                    int rows = ExportTable(table, path);
                    Log("  ✓ " + table + " → " + Path.GetFileName(path) +
                        " (" + rows + " записей)");
                    ok++;
                }
                catch (Exception ex)
                {
                    Log("  ✗ " + table + " — ОШИБКА: " + ex.Message);
                    errors++;
                }
            }
            Log("Итого: успешно " + ok + ", ошибок " + errors);
        }

        private int ExportTable(string table, string path)
        {
            int rows = 0;
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + table, conn))
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

                            if (val.Contains(";") || val.Contains("\"") ||
                                val.Contains("\n") || val.Contains("\r"))
                            {
                                val = "\"" + val.Replace("\"", "\"\"") + "\"";
                            }
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
            var tables = GetSelectedTables();
            if (tables.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одну таблицу");
                return;
            }

            string folder = txtFolder.Text;
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
            {
                MessageBox.Show("Сначала выберите папку");
                return;
            }

            if (MessageBox.Show(
                "Импорт добавит данные в существующие таблицы.\n" +
                "Продолжить?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            ClearLog();
            Log("=== ИМПОРТ ===");
            Log("Папка: " + folder);

            int ok = 0, errors = 0;
            foreach (string table in tables) 
            {
                string path = Path.Combine(folder, table + ".csv");
                if (!File.Exists(path))
                {
                    Log("  ✗ " + table + " — файл не найден: " + Path.GetFileName(path));
                    errors++;
                    continue;
                }

                try
                {
                    int rows = ImportTable(table, path);
                    Log("  ✓ " + Path.GetFileName(path) + " → " + table +
                        " (" + rows + " записей)");
                    ok++;
                }
                catch (Exception ex)
                {
                    Log("  ✗ " + table + " — ОШИБКА: " + ex.Message);
                    errors++;
                }
            }
            Log("Итого: успешно " + ok + ", ошибок " + errors);
        }

        private int ImportTable(string table, string path)
        {
            int inserted = 0;

            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            if (lines.Length < 2) return 0;  

            string[] columns = SplitCsvLine(lines[0]);
            string colList = string.Join(", ", columns);
            string paramList = "@p" + string.Join(", @p", Enumerable.Range(0, columns.Length));
            string sql = "INSERT INTO " + table + " (" + colList + ") VALUES (" + paramList + ")";

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                using (MySqlCommand cmdFk = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0", conn))
                    cmdFk.ExecuteNonQuery();

                try
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i])) continue;

                        string[] values = SplitCsvLine(lines[i]);
                        if (values.Length != columns.Length) continue;

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            for (int k = 0; k < values.Length; k++)
                            {
                                string v = values[k];
                                cmd.Parameters.AddWithValue("@p" + k,
                                    string.IsNullOrEmpty(v) ? (object)DBNull.Value : v);
                            }
                            cmd.ExecuteNonQuery();
                            inserted++;
                        }
                    }
                }
                finally
                {
                    using (MySqlCommand cmdFk = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1", conn))
                        cmdFk.ExecuteNonQuery();
                }
            }
            return inserted;
        }

        /// <summary>
        /// CSV-парсер: учитывает кавычки и ; внутри.
        /// </summary>
        private string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;
            var sb = new StringBuilder();

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
                        else inQuotes = false;
                    }
                    else sb.Append(c);
                }
                else
                {
                    if (c == '"') inQuotes = true;
                    else if (c == ';')
                    {
                        result.Add(sb.ToString());
                        sb.Clear();
                    }
                    else sb.Append(c);
                }
            }
            result.Add(sb.ToString());
            return result.ToArray();
        }

        private void btnBackupManual_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "SQL|*.sql";
                sfd.FileName = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                ClearLog();
                Log("=== РЕЗЕРВНОЕ КОПИРОВАНИЕ ===");
                Log("Файл: " + sfd.FileName);

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("USE board_game_store;");

                    foreach (string table in TablesInOrder)
                    {
                        using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                        {
                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + table, conn))
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
                                            if (v is string || v is DateTime)
                                                sb.Append("'" + v.ToString().Replace("'", "''") + "'");
                                            else
                                                sb.Append(v.ToString().Replace(",", "."));
                                        }
                                        if (i < reader.FieldCount - 1) sb.Append(", ");
                                    }
                                    sb.AppendLine(");");
                                    rows++;
                                }
                                Log("  ✓ " + table + " (" + rows + " записей)");
                            }
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    Log("Готово: " + sfd.FileName);
                    MessageBox.Show("Резервная копия создана:\n" + sfd.FileName);
                }
                catch (Exception ex)
                {
                    Log("  ✗ ОШИБКА: " + ex.Message);
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void chkBackupAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBackupAuto.Checked)
                MessageBox.Show("Автоматическое резервное копирование включено.\nИнтервал: " + nudInterval.Value + " ч.");
            else
                MessageBox.Show("Автоматическое резервное копирование выключено.");
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (cmbOrder.SelectedValue == null) { MessageBox.Show("Выберите заказ"); return; }

            int orderId = Convert.ToInt32(cmbOrder.SelectedValue);
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Чек_Заказ_" + orderId + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".doc");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("==========================================");
                sb.AppendLine("          МАГАЗИН НАСТОЛЬНЫХ ИГР");
                sb.AppendLine("==========================================");
                sb.AppendLine("Чек № " + orderId);
                sb.AppendLine("Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                sb.AppendLine("------------------------------------------");

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sqlOrder = "SELECT c.full_name, o.order_date, o.discount, " +
                                      "o.total_without_discount, o.total_with_discount, o.total_amount, " +
                                      "s.status_name FROM orders o " +
                                      "JOIN customers c ON o.customer_id=c.customer_id " +
                                      "JOIN statuses s ON o.status_id=s.status_id " +
                                      "WHERE o.order_id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sqlOrder, conn))
                    {
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
                    }

                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT g.title, oi.quantity, oi.unit_price, (oi.quantity*oi.unit_price) AS total " +
                        "FROM order_items oi JOIN board_games g ON oi.game_id=g.game_id " +
                        "WHERE oi.order_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                sb.AppendLine("  " + r["title"] + " x" + r["quantity"] +
                                              " = " + Convert.ToDecimal(r["total"]).ToString("0.00") + " руб.");
                            }
                        }
                    }

                    sb.AppendLine("------------------------------------------");
                    using (MySqlCommand cmd = new MySqlCommand(sqlOrder, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (var r = cmd.ExecuteReader())
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
                }
                sb.AppendLine("==========================================");
                sb.AppendLine("Спасибо за покупку!");

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Чек сохранён:\n" + path);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Отчёт_Excel_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT o.order_id, c.full_name, o.order_date, s.status_name, " +
                                 "o.total_amount FROM orders o " +
                                 "JOIN customers c ON o.customer_id=c.customer_id " +
                                 "JOIN statuses s ON o.status_id=s.status_id " +
                                 "WHERE o.order_date >= @f AND o.order_date <= @t ORDER BY o.order_date";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@f", dtpFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@t", dtpTo.Value.Date.AddDays(1));

                        using (var r = cmd.ExecuteReader())
                        using (StreamWriter w = new StreamWriter(path, false, new UTF8Encoding(true)))
                        {
                            w.WriteLine("Номер;Клиент;Дата;Статус;Сумма");
                            while (r.Read())
                            {
                                w.WriteLine(r["order_id"] + ";" + r["full_name"] + ";" +
                                            Convert.ToDateTime(r["order_date"]).ToShortDateString() + ";" +
                                            r["status_name"] + ";" + r["total_amount"]);
                            }
                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT COUNT(*) AS c, IFNULL(SUM(total_amount),0) AS s FROM orders " +
                        "WHERE order_date >= @f AND order_date <= @t", conn))
                    {
                        cmd.Parameters.AddWithValue("@f", dtpFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@t", dtpTo.Value.Date.AddDays(1));

                        using (var r = cmd.ExecuteReader())
                        using (StreamWriter w = new StreamWriter(path, true, new UTF8Encoding(true)))
                        {
                            if (r.Read())
                            {
                                w.WriteLine();
                                w.WriteLine("ИТОГО:");
                                w.WriteLine("Заказов: " + r["c"]);
                                w.WriteLine("Выручка: " + Convert.ToDecimal(r["s"]).ToString("0.00") + " руб.");
                            }
                        }
                    }
                }
                MessageBox.Show("Отчёт Excel сохранён:\n" + path);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void LoadOrdersToCombo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT o.order_id, c.full_name FROM orders o " +
                                 "JOIN customers c ON o.customer_id=c.customer_id " +
                                 "ORDER BY o.order_id DESC";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbOrder.DataSource = dt;
                        cmbOrder.DisplayMember = "order_id";
                        cmbOrder.ValueMember = "order_id";
                    }
                }
            }
            catch { }
        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}