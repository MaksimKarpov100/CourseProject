using System;
using System.IO;

namespace BoardGame_Store
{
    public static class DbConfig
    {
        public static string Server = "localhost";
        public static int Port = 3306;
        public static string Database = "board_game_store";
        public static string User = "root";
        public static string Password = "";

        public static string BuildConnectionString()
        {
            return "Server=" + Server + ";Port=" + Port + ";" +
                   "Database=" + Database + ";Uid=" + User + ";" +
                   "Pwd=" + Password + ";CharSet=utf8mb4;";
        }

        public static void Save()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_settings.ini");

                string[] lines = new string[]
                {
                    Server,
                    Port.ToString(),
                    Database,
                    User,
                    Password
                };

                File.WriteAllLines(path, lines);
            }
            catch
            {
            }
        }

        public static void Load()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_settings.ini");

                if (!File.Exists(path))
                {
                    return;
                }

                string[] lines = File.ReadAllLines(path);

                if (lines.Length >= 5)
                {
                    Server = lines[0];
                    Port = int.Parse(lines[1]);
                    Database = lines[2];
                    User = lines[3];
                    Password = lines[4];
                }
            }
            catch
            {

            }
        }
    }
}