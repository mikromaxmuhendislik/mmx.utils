using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace V7.BaseApplication.Utilies.Encryption
{
    public static class Hashing
    {
        public static string ToSha256(this string value)
        {
            var output = "";
            using (SHA256 hasher = SHA256.Create())
            {
                hasher.ComputeHash(Encoding.UTF8.GetBytes(value));
            }
            return output;
        }
    }
}
