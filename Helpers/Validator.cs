using System.Text.RegularExpressions;

namespace BoardGame_Store
{
    public static class Validator
    {
        public static bool CheckFullName(string fio)
        {
            if (string.IsNullOrWhiteSpace(fio))
            {
                return false;
            }

            if (fio.Length < 3 || fio.Length > 100)
            {
                return false;
            }

            return Regex.IsMatch(fio, @"^[А-Яа-яЁё\s\-]+$");
        }

        public static bool CheckLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return false;
            }

            if (login.Length < 4 || login.Length > 32)
            {
                return false;
            }

            return Regex.IsMatch(login, @"^[A-Za-z0-9_]+$");
        }

        public static bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < 8 || password.Length > 64)
            {
                return false;
            }

            bool hasLetter = Regex.IsMatch(password, @"[A-Za-z]");
            bool hasDigit = Regex.IsMatch(password, @"\d");

            return hasLetter && hasDigit;
        }

        public static bool CheckPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            string digits = Regex.Replace(phone, @"\D", "");

            return digits.Length == 11 && digits.StartsWith("7");
        }

        public static bool CheckPrice(decimal price)
        {
            return price >= 0 && price <= 10000;
        }

        public static bool CheckStock(int stock)
        {
            return stock >= 0 && stock <= 1000;
        }

        public static bool CheckDiscount(decimal d)
        {
            return d >= 0 && d <= 100;
        }

        public static string MaskPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "";
            }

            string digits = Regex.Replace(phone, @"\D", "");

            if (digits.Length < 10)
            {
                return phone;
            }

            return digits.Substring(1, 3) + "****" + digits.Substring(digits.Length - 2);
        }

        public static string MaskFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return "";
            }

            string[] parts = fullName.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                return fullName;
            }

            string result = parts[0];

            for (int i = 1; i < parts.Length; i++)
            {
                result += " " + parts[i][0] + ".";
            }

            return result;
        }
    }
}