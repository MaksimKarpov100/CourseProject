using System;

namespace BoardGame_Store
{
    public static class DiscountHelper
    {
        public static decimal GetDiscount(decimal sum, DateTime date)
        {
            decimal discount = 0;

            // Скидки от суммы заказа
            if (sum >= 10000) discount = 15;
            else if (sum >= 5000) discount = 10;
            else if (sum >= 2000) discount = 5;

            // Новогодние праздники
            if (date.Month == 12 && date.Day >= 20)
            {
                if (discount < 15) discount = 15;
            }
            // 23 февраля
            if (date.Month == 2 && date.Day == 23)
            {
                if (discount < 15) discount = 15;
            }
            // 8 марта
            if (date.Month == 3 && date.Day == 8)
            {
                if (discount < 15) discount = 15;
            }

            return discount;
        }

        public static decimal GetDiscountAmount(decimal sum, decimal percent)
        {
            return Math.Round(sum * percent / 100, 2);
        }

        public static decimal GetTotal(decimal sum, decimal discountAmount)
        {
            return sum - discountAmount;
        }
    }
}