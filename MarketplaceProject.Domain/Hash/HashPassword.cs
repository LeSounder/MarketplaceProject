using System.Security.Cryptography;
using System.Text;

namespace MarketplaceProject.Domain.Hash
{
    public static class HashPassword
    {
        public static string HashPass(string password)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
