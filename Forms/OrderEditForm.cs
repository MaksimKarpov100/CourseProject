using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class OrderEditForm : Form
    {
        private int orderId = 0;

        public OrderEditForm(int id)
        {
            InitializeComponent();
            this.orderId = id;
        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            if (orderId == 0)
            {
                MessageHelper.ShowError("Ошибка: ID заказа не передан!");
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
                string sql = "SELECT status_id, status_name FROM statuses ORDER BY status_id";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql);

                cmbStatus.DataSource = dt;
                cmbStatus.DisplayMember = "status_name";
                cmbStatus.ValueMember = "status_id";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки статусов: " + ex.Message);
            }
        }

        private void LoadOrderInfo()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", orderId);

                string sql = "SELECT c.full_name, o.shipping_address, o.status_id, o.discount, " +
                             "o.total_without_discount, o.total_with_discount, o.total_amount, " +
                             "o.order_date, o.completion_date " +
                             "FROM orders o " +
                             "JOIN customers c ON o.customer_id = c.customer_id " +
                             "WHERE o.order_id = @id";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    lblCustomerName.Text = dt.Rows[0]["full_name"].ToString();
                    txtAddress.Text = dt.Rows[0]["shipping_address"].ToString();
                    cmbStatus.SelectedValue = dt.Rows[0]["status_id"];

                    dtpOrderDate.Value = Convert.ToDateTime(dt.Rows[0]["order_date"]);

                    if (dt.Rows[0]["completion_date"] != DBNull.Value)
                    {
                        dtpCompletionDate.Value = Convert.ToDateTime(dt.Rows[0]["completion_date"]);
                    }
                    else
                    {
                        dtpCompletionDate.Value = DateTime.Now;
                    }

                    decimal sumWithout = Convert.ToDecimal(dt.Rows[0]["total_without_discount"]);
                    decimal sumWith = Convert.ToDecimal(dt.Rows[0]["total_with_discount"]);
                    decimal discountAmount = sumWithout - sumWith;

                    txtSumWithout.Text = sumWithout.ToString("0.00");
                    txtSumWith.Text = sumWith.ToString("0.00");
                    txtTotal.Text = Convert.ToDecimal(dt.Rows[0]["total_amount"]).ToString("0.00");
                    txtDiscountAmount.Text = discountAmount.ToString("0.00");
                }
                else
                {
                    MessageHelper.ShowWarning("Заказ не найден!");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки данных заказа: " + ex.Message);
            }
        }

        private void LoadOrderItems()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", orderId);

                string sql = "SELECT g.title AS 'Товар', oi.quantity AS 'Кол-во', " +
                             "oi.unit_price AS 'Цена', (oi.quantity * oi.unit_price) AS 'Сумма' " +
                             "FROM order_items oi " +
                             "JOIN board_games g ON oi.game_id = g.game_id " +
                             "WHERE oi.order_id = @id";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
                dgvOrderItems.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка загрузки состава заказа: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpCompletionDate.Value.Date < dtpOrderDate.Value.Date)
            {
                MessageHelper.ShowWarning("Дата завершения не может быть меньше даты оформления!");
                return;
            }

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@status", cmbStatus.SelectedValue);
                parameters.Add("@addr", txtAddress.Text);
                parameters.Add("@odate", dtpOrderDate.Value);
                parameters.Add("@cdate", dtpCompletionDate.Value);
                parameters.Add("@id", orderId);

                string sql = "UPDATE orders SET status_id=@status, shipping_address=@addr, " +
                             "order_date=@odate, completion_date=@cdate WHERE order_id=@id";

                DatabaseHelper.ExecuteNonQuery(sql, parameters);

                MessageHelper.ShowInfo("Заказ успешно обновлен!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Ошибка сохранения: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}