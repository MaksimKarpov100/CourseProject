using System;
using MySql.Data.MySqlClient;

namespace BoardGame_Store
{
    public static class DbInitializer
    {
        public static void EnsureDefaultUsers()
        {
            using (MySqlConnection conn = new MySqlConnection(DbConfig.BuildConnectionString()))
            {
                conn.Open();

                if (UserExists(conn, "admin") == false)
                {
                    CreateUser(conn, "Иванов Иван Иванович", "admin", "admin1234", "Администратор", "+7 (900) 000-00-01");
                }

                if (UserExists(conn, "manager") == false)
                {
                    CreateUser(conn, "Петрова Мария Сергеевна", "manager", "manager1234", "Товаровед", "+7 (900) 000-00-02");
                }

                if (UserExists(conn, "seller") == false)
                {
                    CreateUser(conn, "Сидоров Сергей Петрович", "seller", "seller1234", "Продавец", "+7 (900) 000-00-03");
                }
            }
        }

        private static bool UserExists(MySqlConnection conn, string login)
        {
            string sql = "SELECT COUNT(*) FROM users WHERE login=@l";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@l", login);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CreateUser(MySqlConnection conn, string fullName, string login, string password, string role, string phone)
        {
            string hash = PasswordHelper.GetHash(password);

            string sql = "INSERT INTO users (full_name, login, password_hash, role, phone) VALUES (@n, @l, @p, @r, @ph)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@n", fullName);
            cmd.Parameters.AddWithValue("@l", login);
            cmd.Parameters.AddWithValue("@p", hash);
            cmd.Parameters.AddWithValue("@r", role);
            cmd.Parameters.AddWithValue("@ph", phone);

            cmd.ExecuteNonQuery();
        }
    }
}