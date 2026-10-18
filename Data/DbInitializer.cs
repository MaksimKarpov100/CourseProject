using System;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public static class DbInitializer
    {
        public static void EnsureDefaultUsers()
        {
            string cs = "Server=" + DbConfig.Server + ";" +
                        "Port=" + DbConfig.Port + ";" +
                        "Database=" + DbConfig.Database + ";" +
                        "Uid=" + DbConfig.User + ";" +
                        "Pwd=" + DbConfig.Password + ";" +
                        "CharSet=utf8mb4;" +
                        "AllowPublicKeyRetrieval=True;";

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();

                if (!UserExists(conn, "admin"))
                {
                    CreateUser(conn, "Иванов Иван Иванович", "admin", "admin1234",
                        "Администратор", "+7 (900) 000-00-01");
                }

                if (!UserExists(conn, "manager"))
                {
                    CreateUser(conn, "Петрова Мария Сергеевна", "manager", "manager1234",
                        "Товаровед", "+7 (900) 000-00-02");
                }

                if (!UserExists(conn, "seller"))
                {
                    CreateUser(conn, "Сидоров Сергей Петрович", "seller", "seller1234",
                        "Продавец", "+7 (900) 000-00-03");
                }
            }
        }

        private static bool UserExists(MySqlConnection conn, string login)
        {
            MySqlCommand cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM users WHERE login=@l", conn);
            cmd.Parameters.AddWithValue("@l", login);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private static void CreateUser(MySqlConnection conn, string fullName, string login,
            string password, string role, string phone)
        {
            string hash = PasswordHelper.GetHash(password);

            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO users (full_name, login, password_hash, role, phone) " +
                "VALUES (@n, @l, @p, @r, @ph)", conn);

            cmd.Parameters.AddWithValue("@n", fullName);
            cmd.Parameters.AddWithValue("@l", login);
            cmd.Parameters.AddWithValue("@p", hash);
            cmd.Parameters.AddWithValue("@r", role);
            cmd.Parameters.AddWithValue("@ph", phone);
            cmd.ExecuteNonQuery();
        }
    }
}