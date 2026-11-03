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
            string connectionString = "Server=" + Server + ";";
            connectionString = connectionString + "Port=" + Port + ";";
            connectionString = connectionString + "Database=" + Database + ";";
            connectionString = connectionString + "Uid=" + User + ";";
            connectionString = connectionString + "Pwd=" + Password + ";";
            connectionString = connectionString + "CharSet=utf8mb4;";
            connectionString = connectionString + "AllowPublicKeyRetrieval=True;";

            return connectionString;
        }

        public static void Save()
        {
            try
            {
                string[] lines = new string[5];
                lines[0] = Server;
                lines[1] = Port.ToString();
                lines[2] = Database;
                lines[3] = User;
                lines[4] = Password;

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
                if (File.Exists(SettingsPath) == true)
                {
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
            }
            catch
            {

            }
        }
    }
}