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
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtFolder.Text = fbd.SelectedPath;
                    RefreshBackupsList();
                }
            }
        }

        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            if (clbTables.CheckedItems.Count == 0)
            {
                MessageBox.Show("Отметьте хотя бы одну таблицу!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Directory.Exists(txtFolder.Text) == false)
            {
                Directory.CreateDirectory(txtFolder.Text);
            }

            int count = 0;
            foreach (var item in clbTables.CheckedItems)
            {
                string tableName = item.ToString();
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        string sql = "SELECT * FROM `" + tableName + "`";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

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
                        Log("Экспортирована таблица: " + tableName);
                    }
                }
                catch (Exception ex)
                {
                    Log("Ошибка экспорта " + tableName + ": " + ex.Message);
                }
            }
            MessageBox.Show("Экспортировано таблиц: " + count, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Импорт из CSV пока в разработке. Используйте восстановление БД.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dt.Columns.Add("Имя файла", typeof(string));
            dt.Columns.Add("Дата создания", typeof(string));
            dt.Columns.Add("Размер", typeof(string));

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

            try
            {
                string mysqldumpPath = FindMysqldumpPath();
                if (string.IsNullOrEmpty(mysqldumpPath))
                {
                    MessageBox.Show("Не найден mysqldump.exe.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string args = "-u" + DbConfig.User + " ";
                if (string.IsNullOrEmpty(DbConfig.Password) == false)
                {
                    args += "-p" + DbConfig.Password + " ";
                }
                args += "--databases " + DbConfig.Database + " --result-file=\"" + filePath + "\"";

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = mysqldumpPath;
                psi.Arguments = args;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardError = true;

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        Log("Создан бэкап: " + fileName);
                        MessageBox.Show("Бэкап успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshBackupsList();
                    }
                    else
                    {
                        string err = process.StandardError.ReadToEnd();
                        Log("Ошибка бэкапа: " + err);
                        MessageBox.Show("Ошибка: " + err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Ошибка бэкапа: " + ex.Message);
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvBackups.CurrentRow == null)
            {
                MessageBox.Show("Выберите бэкап из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = dgvBackups.CurrentRow.Cells[0].Value.ToString();
            string filePath = Path.Combine(txtFolder.Text, fileName);

            DialogResult result = MessageBox.Show("Восстановить базу из файла?\n" + fileName, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                string serverConn = "server=" + DbConfig.Server + ";port=" + DbConfig.Port + ";user=" + DbConfig.User + ";password=" + DbConfig.Password + ";charset=utf8mb4;AllowPublicKeyRetrieval=True;";

                using (MySqlConnection conn = new MySqlConnection(serverConn))
                {
                    conn.Open();
                    MySqlCommand cmdCreate = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + DbConfig.Database + "`", conn);
                    cmdCreate.ExecuteNonQuery();
                    conn.ChangeDatabase(DbConfig.Database);

                    string script = File.ReadAllText(filePath);
                    MySqlScript scriptExec = new MySqlScript(conn, script);
                    scriptExec.Execute();

                    Log("База восстановлена из " + fileName);
                    MessageBox.Show("База данных успешно восстановлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log("Ошибка восстановления: " + ex.Message);
                MessageBox.Show("Ошибка восстановления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT o.order_id, c.full_name, o.order_date, o.total_amount " +
                                 "FROM orders o JOIN customers c ON o.customer_id = c.customer_id " +
                                 "WHERE o.order_date >= @df AND o.order_date < @dt " +
                                 "ORDER BY o.order_date ASC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@df", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@dt", dtpTo.Value.Date.AddDays(1));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("За выбранный период нет данных.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    decimal totalSum = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalSum += Convert.ToDecimal(row["total_amount"]);
                    }

                    StringBuilder csv = new StringBuilder();

                    // МАГИЧЕСКАЯ СТРОКА ДЛЯ EXCEL (разбивает по точкам с запятой)
                    csv.AppendLine("sep=;");

                    // Заголовки
                    csv.AppendLine("Номер заказа;Клиент;Дата оформления;Сумма");

                    // Данные
                    foreach (DataRow row in dt.Rows)
                    {
                        csv.AppendLine(row["order_id"].ToString() + ";" +
                                       row["full_name"].ToString() + ";" +
                                       Convert.ToDateTime(row["order_date"]).ToString("dd.MM.yyyy HH:mm") + ";" +
                                       Convert.ToDecimal(row["total_amount"]).ToString("0.00"));
                    }

                    // Итог
                    csv.AppendLine(";;ИТОГО ЗА ПЕРИОД:;" + totalSum.ToString("0.00"));

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "Excel документ (*.csv)|*.csv";
                        sfd.FileName = "Отчет_с_" + dtpFrom.Value.ToString("ddMMyyyy") + "_по_" + dtpTo.Value.ToString("ddMMyyyy") + ".csv";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.UTF8);
                            MessageBox.Show("Отчет успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process.Start(sfd.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отчета: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Log(string message)
        {
            txtLog.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - " + message + Environment.NewLine);
        }

        private string FindMysqldumpPath()
        {
            string[] paths = new string[]
            {
                @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                @"C:\Program Files\MySQL\MySQL Server 5.7\bin\mysqldump.exe",
                @"C:\xampp\mysql\bin\mysqldump.exe"
            };

            for (int i = 0; i < paths.Length; i++)
            {
                if (File.Exists(paths[i]) == true)
                {
                    return paths[i];
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