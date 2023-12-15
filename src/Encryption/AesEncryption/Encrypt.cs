using System;
using System.Text;
using System.Security.Cryptography;
using SafeCrypt.src.Helpers;
using SafeCrypt.src.Encryption.AesEncryption.Models;

namespace SafeCrypt.src.Encrypt.AesEncryption
{
    public class Encrypt : BaseAesEncryption
    {
        public byte[] AesEncrypt(byte[] data, byte[] secretKey, byte[] iv)
            => EncryptAES(data, secretKey, iv);

        public byte[] AesDecrypt(byte[] data, byte[] secretKey, byte[] iv)
            => DecryptAES(data, secretKey, iv);

        public byte[] AesEncrypt(string data, string secretKey, string iv)
        {
            NullChecks(data, secretKey, iv);
            var convertedKeys = ConvertKeysToBytes(secretKey, iv);

            var aesKey = convertedKeys.Item1;
            var aesIv = convertedKeys.Item2;

            var aesData = data.HexadecimalStringToByteArray();
            return EncryptAES(aesData, aesKey, aesIv);
        }

        public byte[] AesDecrypt(string data, string secretKey, string iv)
        {
            NullChecks(data, secretKey, iv);
            //var convertedKeys = ConvertKeysToBytes(secretKey, iv);

            var (aesKey, aesIv) = ConvertKeysToBytesAndGetKeys(secretKey, iv);
            //var aesKey = convertedKeys.Item1;
            //var aesIv = convertedKeys.Item2;

            var aesData = data.HexadecimalStringToByteArray();
            return DecryptAES(aesData, aesKey, aesIv);
        }

        public AesEncryptionData AesEncrypt(string data, string secretKey)
        {
            NullChecks(data, secretKey);

            var aesIv = GenerateRandomBytes(16);
            var aesKey = Encoding.UTF8.GetBytes(secretKey);
            var aesData = data.HexadecimalStringToByteArray();

            var response = EncryptAES(aesData, aesKey, aesIv);

            var responseData = new AesEncryptionData
            {
                Data = response,
                Iv = aesIv
            };

            return responseData;
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

        public string AesEncryptByteToString(byte[] data, byte[] secretKey, byte[] iv)
        {
            var cipherText = EncryptAES(data, secretKey, iv);

            return cipherText.BytesToString();
        }

        // needs methods that would accept aes mode
        //public byte[] AesEncrypt(byte[] data, byte[] key, byte[] iv, ReturnType returnType)
        //{

        //}     

        private void NullChecks(string data, string secretKey, string iv)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException(nameof(data));

            if (secretKey == null || secretKey.Length <= 0)
                throw new ArgumentNullException(nameof(secretKey));

            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));
        }

        private (byte[], byte[]) ConvertKeysToBytes(string secretKey, string ivKey)
        {
            var secret = Encoding.UTF8.GetBytes(secretKey);
            var iv = Encoding.UTF8.GetBytes(ivKey);

            return (secret, iv);
        }

        private (byte[], byte[]) ConvertKeysToBytesAndGetKeys(string secretKey, string iv)
        {
            var convertedKeys = ConvertKeysToBytes(secretKey, iv);

            return (convertedKeys.Item1, convertedKeys.Item2);
        }
        private void NullChecks(string data, string secretKey)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException(nameof(data));

            if (secretKey == null || secretKey.Length <= 0)
                throw new ArgumentNullException(nameof(secretKey));
        }
    }

}
