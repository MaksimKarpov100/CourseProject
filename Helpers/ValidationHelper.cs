using System.Text.RegularExpressions;

namespace BoardGame_Store
{
    public static class ValidationHelper
    {
        public static bool IsRussianText(string text)
        {
            return Regex.IsMatch(text, @"^[А-Яа-яЁё\s\-]+$");
        }

        public static bool IsDigitsOnly(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}