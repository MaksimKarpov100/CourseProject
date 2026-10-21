using System;
using System.Windows.Forms;

namespace BoardGame_Store
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DbConfig.Load();
            Application.Run(new LoginForm());
        }
    }
}