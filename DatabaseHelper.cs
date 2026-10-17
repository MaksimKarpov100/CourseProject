using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using BoardGame_Store.Properties;

namespace BoardGame_Store
{
    public static class DatabaseHelper
    {
        private static string GetConnectionString()
        {
            return $"server={Settings.Default.DbServer};" +
                   $"port={Settings.Default.DbPort};" +
                   $"database={Settings.Default.DbName};" +
                   $"user={Settings.Default.DbUser};" +
                   $"password={Settings.Default.DbPassword};" +
                   $"charset=utf8;";
        }

        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}