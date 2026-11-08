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

        public static string CapitalizeWords(string text)
        {
            if (string.IsNullOrEmpty(text) == true)
            {
                return text;
            }

            char[] chars = text.ToCharArray();
            bool isNewWord = true;

            for (int i = 0; i < chars.Length; i++)
            {
                if (isNewWord == true && char.IsLetter(chars[i]) == true)
                {
                    chars[i] = char.ToUpper(chars[i]);
                    isNewWord = false;
                }
                else if (chars[i] == ' ' || chars[i] == '-')
                {
                    isNewWord = true;
                }
            }

            return new string(chars);
        }

        public static string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text) == true)
            {
                return text;
            }

            if (text.Length == 1)
            {
                return text.ToUpper();
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
