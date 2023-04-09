using System;
using System.Text;
using System.Security.Cryptography;

namespace SafeCrypt
{
    public class Encrypt : BaseAesEncryption
    {
        public byte[] AesEncrypt(byte[] data, byte[] secretKey, byte[] iv)
            => EncryptAES(data, secretKey, iv);

        public byte[] AesEncrypt(string data, string secretKey, string iv)
        {
            NullChecks(data, secretKey, iv);

            var aesKey = Encoding.UTF8.GetBytes(secretKey);
            var aesIv = Encoding.UTF8.GetBytes(iv);
            var aesData = data.HexadecimalStringToByteArray();

            return EncryptAES(aesData, aesKey, aesIv);
        }

        public string AesEncryptByteToHexString(byte[] data, byte[] secretKey, byte[] iv)
        {
            var cipherText = EncryptAES(data, secretKey, iv);

            return cipherText.ByteArrayToHexString();
        }

        public string AesEncryptByteToBase64String(byte[] data, byte[] secretKey, byte[] iv)
        {
            var cipherText = EncryptAES(data, secretKey, iv);

            return Convert.ToBase64String(cipherText);
        }

        

        private void NullChecks(string data, string secretKey, string iv)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("plainText");

            if (secretKey == null || secretKey.Length <= 0)
                throw new ArgumentNullException("Key");

            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
        }

        //public byte[] AesEncrypt(byte[] data, byte[] key, byte[] iv, ReturnType returnType)
        //{

        //}        
    }
}
