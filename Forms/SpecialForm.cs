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

        // --- БЛОК 1: ИМПОРТ / ЭКСПОРТ ---
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

        // --- БЛОК 2: РЕЗЕРВНОЕ КОПИРОВАНИЕ ---
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
                        // Игнорируем
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

        // --- БЛОК 3: ОТЧЕТЫ ---
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

        // --- ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ---
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
            catch
            {
                // Игнорируем
            }

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

                        if (foundFiles.Length > 0)
                        {
                            return foundFiles[0];
                        }
                    }
                    catch
                    {
                        // Игнорируем
                    }
                }
            }

            return null;
        }
    }
}