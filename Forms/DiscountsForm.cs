using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class DiscountsForm : Form
    {
        public DiscountsForm()
        {
            InitializeComponent();
        }

        private void DiscountsForm_Load(object sender, EventArgs e)
        {
            lblSum1.Text = "• Сумма заказа от 2 000 руб. — скидка 5%";
            lblSum2.Text = "• Сумма заказа от 5 000 руб. — скидка 10%";
            lblSum3.Text = "• Сумма заказа от 10 000 руб. — скидка 15%";

            lblSeason1.Text = "• Новогодние праздники (с 20 по 31 декабря) — скидка 15%";
            lblSeason2.Text = "• 23 февраля и 8 марта — скидка 15%";

            lblRule1.Text = "1. Скидка рассчитывается автоматически при оформлении заказа.";
            lblRule2.Text = "2. Если подходит несколько условий — применяется наибольшая скидка.";
            lblRule3.Text = "3. Если ни одно условие не подходит — скидка равна 0%.";
            lblRule4.Text = "4. Примененная скидка сохраняется в базе данных вместе с заказом.";

            string exampleText = "";
            exampleText = exampleText + "Пример: заказ на 6 000 руб. в декабре.\r\n";
            exampleText = exampleText + "Скидка от 5 000 руб. = 10%, новогодняя скидка = 15%.\r\n";
            exampleText = exampleText + "Так как подходят оба условия, применяется наибольшая — 15%.\r\n";
            exampleText = exampleText + "Сумма скидки: 6 000 × 0,15 = 900 руб.\r\n";
            exampleText = exampleText + "Итого к оплате: 6 000 - 900 = 5 100 руб.";

            lblExample.Text = exampleText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}