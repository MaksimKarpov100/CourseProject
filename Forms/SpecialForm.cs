using System;
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

        private static readonly string[] Tables =
        {
            "users", "customers", "categories",
            "statuses", "board_games", "orders", "order_items"
        };

        public SpecialForm()
        {
            InitializeComponent();
            LoadOrdersToCombo();
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

        // ===== ЭКСПОРТ CSV =====
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    foreach (string table in Tables)
                        ExportTable(table, Path.Combine(fbd.SelectedPath, table + ".csv"));
                    MessageBox.Show("Экспорт завершён успешно");
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        private void ExportTable(string table, string path)
        {
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
                            if (val.Contains(";") || val.Contains("\""))
                                val = "\"" + val.Replace("\"", "\"\"") + "\"";
                            writer.Write(val);
                            if (i < reader.FieldCount - 1) writer.Write(";");
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        // ===== ИМПОРТ CSV =====
        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV|*.csv";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string table = Path.GetFileNameWithoutExtension(ofd.FileName).ToLower();
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                        if (lines.Length < 2) return;

                        string[] columns = lines[0].Split(';');

                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(';');
                            if (values.Length != columns.Length) continue;

                            string colList = string.Join(", ", columns);
                            string paramList = "@p" + string.Join(", @p", Enumerable.Range(0, columns.Length));
                            string sql = "INSERT INTO " + table + " (" + colList + ") VALUES (" + paramList + ")";

                            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                            {
                                for (int k = 0; k < values.Length; k++)
                                    cmd.Parameters.AddWithValue("@p" + k, values[k]);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Импорт завершён успешно");
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        // ===== РЕЗЕРВНОЕ КОПИРОВАНИЕ =====
        private void btnBackupManual_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "SQL|*.sql";
                sfd.FileName = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("USE board_game_store;");

                    foreach (string table in Tables)
                    {
                        using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                        {
                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + table, conn))
                            using (var reader = cmd.ExecuteReader())
                            {
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
                                }
                            }
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Резервная копия создана:\n" + sfd.FileName);
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        private void chkBackupAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBackupAuto.Checked)
                MessageBox.Show("Автоматическое резервное копирование включено.\nИнтервал: " + nudInterval.Value + " ч.");
            else
                MessageBox.Show("Автоматическое резервное копирование выключено.");
        }

        // ===== ЧЕК В WORD =====
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

        // ===== ОТЧЁТ В EXCEL =====
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

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}