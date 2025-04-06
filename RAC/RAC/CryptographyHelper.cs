using System;
using System.Security.Cryptography;
using System.Text;

namespace RAC
{
    public class CryptographyHelper
    {
        // Generates a random salt  
        public string GenerateSalt()
        {
            byte[] saltBytes = new byte[16]; // 16 bytes = 128 bits  
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Hashes the password with a salt  
        public string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Combine password and salt  
                string saltedPassword = password + salt;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Convert to hex  
                }
                return builder.ToString();
            }
        }
    }
}