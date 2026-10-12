namespace BoardGame_Store
{
    public static class DbConfig
    {
        public static string Server
        {
            get { return Properties.Settings.Default.DbServer; }
            set { Properties.Settings.Default.DbServer = value; }
        }

        public static int Port
        {
            get { return Properties.Settings.Default.DbPort; }
            set { Properties.Settings.Default.DbPort = value; }
        }

        public static string Database
        {
            get { return Properties.Settings.Default.DbName; }
            set { Properties.Settings.Default.DbName = value; }
        }

        public static string User
        {
            get { return Properties.Settings.Default.DbUser; }
            set { Properties.Settings.Default.DbUser = value; }
        }

        public static string Password
        {
            get { return Properties.Settings.Default.DbPassword; }
            set { Properties.Settings.Default.DbPassword = value; }
        }

        public static string BuildConnectionString()
        {
            return "Server=" + Server + ";Port=" + Port + ";Database=" + Database +
                   ";Uid=" + User + ";Pwd=" + Password + ";CharSet=utf8mb4;";
        }

        public static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}