using System.Security.Cryptography;
using System.Text;

namespace BoardGame_Store
{
    public static class PasswordHelper
    {
        public static string GetHash(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static bool CheckPassword(string password, string hashFromDb)
        {
            string hash = GetHash(password);

            return hash == hashFromDb;
        }
    }
}