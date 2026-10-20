using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            if (string.IsNullOrEmpty(text)) return false;
            foreach (char c in text)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

        public static void ShowWarning(string text)
        { 
            MessageBox.Show(text, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }
        public static void ShowError(string text) 
        { 
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
        public static void ShowSuccess(string text)
        {
            MessageBox.Show(text, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
    }
}