using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class HasPassword
    {
        public static string HashPassword(string password)
        {
            // Convert the password to a byte array and hash it with MD5
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashedBytes = MD5.Create().ComputeHash(passwordBytes);

            // Convert the hashed bytes to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }
            string hashedPassword = builder.ToString();
            return hashedPassword;
        }

        public static bool CheckPassword(string inputPassword, string hashedPassword)
        {
            // Hash the input password and compare it to the hashed password
            string hashedInputPassword = HashPassword(inputPassword);
            return hashedInputPassword == hashedPassword;
        }
    }
}
