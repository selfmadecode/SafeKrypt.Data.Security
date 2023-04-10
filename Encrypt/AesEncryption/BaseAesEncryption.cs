using System;
using System.IO;
using System.Security.Cryptography;

namespace SafeCrypt
{
    public class BaseAesEncryption
    {
        // Method to encrypt data using AES algorithm
        public virtual byte[] EncryptAES(byte[] data, byte[] key, byte[] iv)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(data, 0, data.Length);
                            cryptoStream.FlushFinalBlock();

                            return memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Method to generate a random byte array of given length
        public static byte[] GenerateRandomBytes(int length)
        {
            byte[] randomBytes = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
