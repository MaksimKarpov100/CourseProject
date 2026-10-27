using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class CustomerEditForm : Form
    {
        private int _customerId = 0;

        public CustomerEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление клиента";
        }

        public CustomerEditForm(int id)
        {
            InitializeComponent();
            _customerId = id;
            lblTitle.Text = "Редактирование клиента";
        }

        private void CustomerEditForm_Load(object sender, EventArgs e)
        {
            if (_customerId > 0)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT full_name, phone FROM customers WHERE customer_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", _customerId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                txtName.Text = r["full_name"].ToString();
                                txtPhone.Text = r["phone"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message); }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите ФИО!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(name, @"^[А-Яа-яЁё\s\-]+$"))
            {
                MessageBox.Show("ФИО должно содержать только русские буквы, пробелы и дефис!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (phone.Length < 18) 
            {
                MessageBox.Show("Введите полный номер телефона!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = _customerId == 0
                        ? "INSERT INTO customers (full_name, phone) VALUES (@n, @p)"
                        : "UPDATE customers SET full_name=@n, phone=@p WHERE customer_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@p", phone);
                    if (_customerId > 0) cmd.Parameters.AddWithValue("@id", _customerId);
                    cmd.ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
    }
}