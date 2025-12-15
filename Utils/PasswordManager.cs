using System;
using System.Security.Cryptography;
using System.Text;

namespace Course_Project.Utils
{
    internal static class PasswordManager
    {        
            public static string Hash(string password)
            {
                using (var sha = SHA256.Create())
                {
                    byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return Convert.ToBase64String(hashBytes);
                }
            }
    }
}

// Посилання на документацію
//https://learn.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.sha256?view=net-10.0