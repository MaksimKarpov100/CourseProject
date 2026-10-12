using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class DiscountsForm : Form
    {
        public DiscountsForm()
        {
            InitializeComponent();

            lblSum1.Text = "• Сумма заказа от 2 000 ₽  —  скидка 5%";
            lblSum2.Text = "• Сумма заказа от 5 000 ₽  —  скидка 10%";
            lblSum3.Text = "• Сумма заказа от 10 000 ₽ —  скидка 15%";

            lblSeason1.Text = "• Новогодняя скидка — 15% (с 20 по 31 декабря)";
            lblSeason2.Text = "• Скидка к 8 марта — 10% (с 7 по 9 марта)";

            lblRule1.Text = "1. Скидка рассчитывается автоматически при оформлении заказа.";
            lblRule2.Text = "2. Если подходит несколько правил — применяется наибольшая скидка.";
            lblRule3.Text = "3. Если ни одно правило не подходит — скидка равна 0%.";
            lblRule4.Text = "4. Все скидки сохраняются в БД для отчётов по выручке.";

            lblExample.Text = "Пример: заказ на 6 000 ₽ в декабре.\r\n" +
                              "Скидка от 5 000 ₽ = 10%, новогодняя = 15%. Применяется 15%.\r\n" +
                              "Сумма скидки: 6 000 × 0,15 = 900 ₽. Итого к оплате: 5 100 ₽.";
        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}