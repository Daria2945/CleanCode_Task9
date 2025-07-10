using System.Security.Cryptography;
using System.Text;

namespace CleanCode_Task9
{
    public class HashSystem
    {
        public static string ComputeSha256Hash(string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
        }
    }
}