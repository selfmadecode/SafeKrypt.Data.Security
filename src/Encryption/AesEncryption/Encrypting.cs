using System;
using System.Text;
using SafeCrypt.src.Helpers;
using SafeCrypt.src.Encryption.AesEncryption.Models;

namespace SafeCrypt.src.Encrypt.AesEncryption
{
    public class Encrypting : BaseAesEncryption
    {
        /// <summary>
        /// Encrypts the provided data using the specified secret key and initialization vector (IV).
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="secretKey">The secret key used for encryption.</param>
        /// <param name="iv">The initialization vector used for encryption.</param>
        /// <returns>The encrypted data as a byte array.</returns>
        /// <remarks>
        /// This method serves as a wrapper around the underlying AES encryption logic provided by the
        /// <see cref="EncryptAES"/> method. It simplifies the encryption process by exposing a more
        /// user-friendly interface, accepting data, secret key, and initialization vector as parameters.
        /// </remarks>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="secretKey">The secret key used for encryption.</param>
        /// <param name="iv">The initialization vector used for encryption.</param>
        /// <returns>The encrypted data as a byte array.</returns>
        public byte[] Encrypt(byte[] data, byte[] secretKey, byte[] iv)
        {
            // Delegate the encryption to the underlying AES encryption method
            return EncryptAES(data, secretKey, iv);
        }

        
        public byte[] Encrypt(string data, string secretKey, string iv)
        {
            NullChecks(data, secretKey, iv);

            var aesKey = secretKey.ConvertKeysToBytes();
            var aesIv = iv.ConvertKeysToBytes();

            var aesData = data.HexadecimalStringToByteArray();
            return EncryptAES(aesData, aesKey, aesIv);
        }       

        public AesEncryptionData Encrypt(string data, string secretKey)
        {
            NullChecks(data, secretKey);

            // Generate a random 16-byte IV for AES in CBC mode
            var aesIv = GenerateRandomIVKeyAsBytes(16);

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

        public string EncryptByteToHexString(byte[] data, byte[] secretKey, byte[] iv)
        {
            var cipherText = EncryptAES(data, secretKey, iv);

            return cipherText.ByteArrayToHexString();
        }

        public string EncryptByteToBase64String(byte[] data, byte[] secretKey, byte[] iv)
        {
            var cipherText = EncryptAES(data, secretKey, iv);

            return Convert.ToBase64String(cipherText);
        }

        public string EncryptByteToString(byte[] data, byte[] secretKey, byte[] iv)
        {
            var cipherText = EncryptAES(data, secretKey, iv);

            return cipherText.BytesToString();
        }

        // needs methods that would accept aes mode
        //public byte[] AesEncrypt(byte[] data, byte[] key, byte[] iv, ReturnType returnType)
        //{

        //}     

        private void NullChecks(string data, string secretKey, string iv = "")
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException(nameof(data));

            if (secretKey == null || secretKey.Length <= 0)
                throw new ArgumentNullException(nameof(secretKey));

            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));
        }
    }

}
