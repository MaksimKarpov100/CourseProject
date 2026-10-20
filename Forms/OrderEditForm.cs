using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public partial class OrderEditForm : Form
    {
        private int _orderId = 0;

        public OrderEditForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            lblTitle.Text = $"Просмотр заказа №{_orderId}";
        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            LoadOrderInfo();
            LoadOrderItems();
        }

        private void LoadOrderInfo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT c.full_name, o.shipping_address, s.status_name, 
                               o.total_without_discount, o.total_with_discount, o.total_amount, o.discount
                        FROM orders o
                        JOIN customers c ON o.customer_id = c.customer_id
                        JOIN statuses s ON o.status_id = s.status_id
                        WHERE o.order_id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", _orderId);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            lblCustomer.Text = "Клиент: " + r["full_name"].ToString();
                            txtAddress.Text = r["shipping_address"].ToString();
                            cmbStatus.Text = r["status_name"].ToString();

                            txtSum.Text = Convert.ToDecimal(r["total_without_discount"]).ToString("0.00");
                            txtDiscount.Text = (Convert.ToDecimal(r["total_without_discount"]) - Convert.ToDecimal(r["total_with_discount"])).ToString("0.00");
                            txtTotal.Text = Convert.ToDecimal(r["total_amount"]).ToString("0.00");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка данных: " + ex.Message); }
        }

        private void LoadOrderItems()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT g.title AS `Товар`, oi.quantity AS `Кол-во`, oi.unit_price AS `Цена`, (oi.quantity * oi.unit_price) AS `Сумма`
                        FROM order_items oi
                        JOIN board_games g ON oi.game_id = g.game_id
                        WHERE oi.order_id = @id";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", _orderId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvItems.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка состава: " + ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();

                    int statusId = 1; 
                    MySqlCommand cmdStatus = new MySqlCommand("SELECT status_id FROM statuses WHERE status_name=@name", conn);
                    cmdStatus.Parameters.AddWithValue("@name", cmbStatus.Text);
                    object result = cmdStatus.ExecuteScalar();
                    if (result != null) statusId = Convert.ToInt32(result);

                    string sql = "UPDATE orders SET status_id = @status, shipping_address = @address WHERE order_id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@status", statusId);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@id", _orderId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Заказ обновлен!", "Успех");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка сохранения: " + ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
    }
}