using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace V7.BaseApplication.Utilies.Encryption
{
    public static class Cryptography
    {
        #region Settings

        private static readonly int _iterations = 2;
        private static readonly int _keySize = 128;
        private static readonly string _hash = "SHA1";
        private static readonly string _salt = "a2el2iasa8497a32"; // Random
        private static readonly string _vector = "8945aza42wl34kjq"; // Random

		#endregion

		/// <summary>
		/// Value değerini password'u kullnarak şifreler. <see cref=" CipherMode.CBC"/> yöntemini kullanarak şifreleme yapar.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static string Encrypt(string value, string password)
                
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(EncryptBytes(valueBytes, password));
        }

        //public static string Decrypt(string value, string password)
        //{
        //    return Decrypt<AesManaged>(value, password);
        //}
        public static string Decrypt(string value, string password) 
        {

            byte[] valueBytes = Convert.FromBase64String(value);

            var result = DecryptBytes(valueBytes, password);
            return Encoding.UTF8.GetString(result);
        }

        //public static byte[] EncryptBytes(byte[] value, string password)
        //{
        //    return EncryptBytes<AesManaged>(value, password);
        //}
        public static byte[] EncryptBytes(byte[] value, string password)
        {
            byte[] vectorBytes = Encoding.UTF8.GetBytes(_vector);
            byte[] saltBytes = Encoding.UTF8.GetBytes(_salt);

            byte[] encrypted;
            using (var cipher = Aes.Create())
            {
                PasswordDeriveBytes _passwordBytes =
                    new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(value, 0, value.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }
                cipher.Clear();
            }
            return encrypted;
        }
        
        public static byte[] DecryptBytes(byte[] value, string password) 
        {
            byte[] vectorBytes = Encoding.UTF8.GetBytes(_vector);
            byte[] saltBytes = Encoding.UTF8.GetBytes(_salt);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (var cipher = Aes.Create())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(value))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[value.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return new byte[0];
                }

                cipher.Clear();
            }
            return decrypted.Take(decryptedByteCount).ToArray();
        }
    }
}
