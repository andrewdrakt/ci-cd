using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observatory.code
{
    public class PasswordWork
    {
        public static List<string> CreateHash(string input)
        {
            using (System.Security.Cryptography.MD5 incoding = System.Security.Cryptography.MD5.Create())
            {
                Random salt = new Random();
                string s = Convert.ToString(salt.NextDouble());
                string hash = input + s;
                byte[] inputBytes = Encoding.ASCII.GetBytes(hash);
                byte[] hashBytes = incoding.ComputeHash(inputBytes);
                List<string> result = new List<string> {s,Convert.ToBase64String(hashBytes) };
                return result;
            }
        }

        public static bool CheckPassword(string input, string password, string salt)
        {
            using (System.Security.Cryptography.MD5 incoding = System.Security.Cryptography.MD5.Create())
            {
                string hash = input + salt;
                byte[] inputBytes = Encoding.ASCII.GetBytes(hash);
                byte[] hashBytes = incoding.ComputeHash(inputBytes);
                if (Convert.ToBase64String(hashBytes) == password) {
                    return true;
                }
                return false;
            }
        }
    }
}