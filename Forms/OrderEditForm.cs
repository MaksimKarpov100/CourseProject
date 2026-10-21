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
        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            if (_orderId == 0)
            {
                MessageBox.Show("Ошибка: ID заказа не передан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadStatuses();
            LoadOrderInfo();
            LoadOrderItems();
        }

        private void LoadStatuses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT status_id, status_name FROM statuses ORDER BY status_id";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbStatus.DataSource = dt;
                    cmbStatus.DisplayMember = "status_name";
                    cmbStatus.ValueMember = "status_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка статусов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderInfo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT c.full_name, o.shipping_address, o.status_id, o.discount, " +
                                 "o.total_without_discount, o.total_with_discount, o.total_amount " +
                                 "FROM orders o " +
                                 "JOIN customers c ON o.customer_id = c.customer_id " +
                                 "WHERE o.order_id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", _orderId);

                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read() == true)
                        {
                            lblCustomerName.Text = r["full_name"].ToString();
                            txtAddress.Text = r["shipping_address"].ToString();
                            cmbStatus.SelectedValue = r["status_id"];

                            decimal sumWithout = Convert.ToDecimal(r["total_without_discount"]);
                            decimal sumWith = Convert.ToDecimal(r["total_with_discount"]);

                            txtSumWithout.Text = sumWithout.ToString("0.00");
                            txtSumWith.Text = sumWith.ToString("0.00");
                            txtTotal.Text = Convert.ToDecimal(r["total_amount"]).ToString("0.00");
                            txtDiscountAmount.Text = (sumWithout - sumWith).ToString("0.00");
                        }
                        else
                        {
                            MessageBox.Show("Заказ не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заказа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderItems()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT g.title AS `Товар`, oi.quantity AS `Кол-во`, " +
                                 "oi.unit_price AS `Цена`, (oi.quantity * oi.unit_price) AS `Сумма` " +
                                 "FROM order_items oi " +
                                 "JOIN board_games g ON oi.game_id = g.game_id " +
                                 "WHERE oi.order_id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", _orderId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrderItems.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка состава: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
                {
                    conn.Open();
                    string sql = "UPDATE orders SET status_id=@status, shipping_address=@addr WHERE order_id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@id", _orderId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Заказ обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}