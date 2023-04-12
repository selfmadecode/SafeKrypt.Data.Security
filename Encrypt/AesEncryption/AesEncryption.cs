﻿using System;
using System.Text;
using System.Security.Cryptography;

namespace SafeCrypt
{
    public class AesEncryption : BaseAesEncryption
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

        public AesData AesEncrypt(string data, string secretKey)
        {
            NullChecks(data, secretKey);

            var aesIv = GenerateRandomBytes(16);
            var aesKey = Encoding.UTF8.GetBytes(secretKey);
            var aesData = data.HexadecimalStringToByteArray();

            var response = EncryptAES(aesData, aesKey, aesIv);

            var responseData = new AesData
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

        private void NullChecks(string data, string secretKey)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException(nameof(data));

            if (secretKey == null || secretKey.Length <= 0)
                throw new ArgumentNullException(nameof(secretKey));
        }   
    }

    public class AesData
    {
        public byte[] Data { get; set; }
        public byte[] Iv { get; set; }
    }
}