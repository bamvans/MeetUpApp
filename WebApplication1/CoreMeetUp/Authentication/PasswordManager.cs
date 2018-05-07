using CoreMeetUp.Database;
using CoreMeetUp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoreMeetUp.Authentication
{
    public class PasswordManager
    {
        public static byte[] GetSafeHash(string message, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                return hmac.ComputeHash(messageBytes);
            }
        }

        public static bool ArrayEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null) { return false; }
            if (a.Length != b.Length) { return false; }
            for (int i = 0, j = a.Length; i < j; i++) { if (a[i] != b[i]) { return false; } }
            return true;
        }

        public static void SetUserPassword(Login login, string password)
        {
            byte[] salt = new byte[64];
            (new Random()).NextBytes(salt);
            login.PasswordHash = GetSafeHash(password, salt);
            login.PasswordSalt = salt;
        }

        public static async Task<bool> ValidatePassword(string userName, string password)
        {

            using (var repo = new LoginRepository())
            {
                var user = await repo.GetByEmail(userName);
                if (user == null)
                {
                    return false;
                }
                if (user.PasswordHash == null || user.PasswordSalt == null) { return false; }
                byte[] calculatedHash = GetSafeHash(password, user.PasswordSalt);
                return ArrayEquals(calculatedHash, user.PasswordHash);
            }

        }
    }
}