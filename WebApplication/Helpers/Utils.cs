using System.Security.Cryptography;
using System.Text;

namespace WebApplication.Helpers
{
    public static class Utils
    {
        public static class Util
        {
            public static string GetEncondeMD5(string input)
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    // Convertir los bytes del hash a un string hexadecimal
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
        }
    }
}
