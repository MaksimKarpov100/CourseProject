using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class CustomerEditForm : Form
    {
        private int customerId = 0;

        public CustomerEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление клиента";
        }

        public CustomerEditForm(int id)
        {
            InitializeComponent();
            this.customerId = id;
            lblTitle.Text = "Редактирование клиента";
        }

        private void CustomerEditForm_Load(object sender, EventArgs e)
        {
            if (customerId > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", customerId);

                string sql = "SELECT full_name, phone FROM customers WHERE customer_id=@id";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["full_name"].ToString();
                    txtPhone.Text = dt.Rows[0]["phone"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) == true)
            {
                MessageHelper.ShowWarning("Введите ФИО!");
                return;
            }

            if (ValidationHelper.IsRussianText(name) == false)
            {
                MessageHelper.ShowWarning("ФИО должно содержать только русские буквы, пробелы и дефис!");
                return;
            }

            if (phone.Length < 18)
            {
                MessageHelper.ShowWarning("Введите полный номер телефона!");
                return;
            }

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@n", name);
                parameters.Add("@p", phone);

                if (customerId == 0)
                {
                    string sqlInsert = "INSERT INTO customers (full_name, phone) VALUES (@n, @p)";
                    DatabaseHelper.ExecuteNonQuery(sqlInsert, parameters);
                    MessageHelper.ShowInfo("Клиент успешно добавлен!");
                }
                else
                {
                    parameters.Add("@id", customerId);
                    string sqlUpdate = "UPDATE customers SET full_name=@n, phone=@p WHERE customer_id=@id";
                    DatabaseHelper.ExecuteNonQuery(sqlUpdate, parameters);
                    MessageHelper.ShowInfo("Данные клиента успешно обновлены!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка базы данных: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}