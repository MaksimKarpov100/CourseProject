using System.Windows.Forms;

namespace BoardGame_Store
{
    public static class MessageHelper
    {
        public static void ShowInfo(string text)
        {
            MessageBox.Show(text, "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void ShowError(string text)
        {
            MessageBox.Show(text, "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void ShowWarning(string text)
        {
            MessageBox.Show(text, "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        public static bool AskConfirm(string text)
        {
            DialogResult result = MessageBox.Show(text, "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }
    }
}