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

        private static string SettingsPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_settings.ini");
            }
        }

        public static string BuildConnectionString()
        {
            return "Server=" + Server + ";" +
                   "Port=" + Port + ";" +
                   "Database=" + Database + ";" +
                   "Uid=" + User + ";" +
                   "Pwd=" + Password + ";" +
                   "CharSet=utf8mb4;" +
                   "AllowPublicKeyRetrieval=True;";
        }

        public static string BuildServerOnlyConnectionString()
        {
            return "Server=" + Server + ";" +
                   "Port=" + Port + ";" +
                   "Uid=" + User + ";" +
                   "Pwd=" + Password + ";" +
                   "CharSet=utf8mb4;" +
                   "AllowPublicKeyRetrieval=True;";
        }

        public static void Save()
        {
            try
            {
                string[] lines = new string[]
                {
                    Server,
                    Port.ToString(),
                    Database,
                    User,
                    Password
                };

                File.WriteAllLines(SettingsPath, lines);
            }
            catch
            {
            }
        }

        public static void Load()
        {
            try
            {
                if (!File.Exists(SettingsPath))
                {
                    return;
                }

                string[] lines = File.ReadAllLines(SettingsPath);

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