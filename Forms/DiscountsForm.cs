using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGame_Store
{
    public partial class DiscountsForm : Form
    {
        private float baseWidth = 600f;

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

        private void DiscountsForm_Resize(object sender, EventArgs e)
        {
            float scale = this.Width / baseWidth;

            if (scale < 0.9f) scale = 0.9f;
            if (scale > 1.3f) scale = 1.3f;

            Font newLabelFont = new Font("Tahoma", 9f * scale);
            Font newHeaderFont = new Font("Trebuchet MS", 10f * scale, FontStyle.Bold);

            lblSum1.Font = newLabelFont;
            lblSum2.Font = newLabelFont;
            lblSum3.Font = newLabelFont;

            lblSeason1.Font = newLabelFont;
            lblSeason2.Font = newLabelFont;

            lblRule1.Font = newLabelFont;
            lblRule2.Font = newLabelFont;
            lblRule3.Font = newLabelFont;
            lblRule4.Font = newLabelFont;

            lblExample.Font = newLabelFont;

            grpSum.Font = newHeaderFont;
            grpSeason.Font = newHeaderFont;
            grpRules.Font = newHeaderFont;
            grpExample.Font = newHeaderFont;
        }
    }
}