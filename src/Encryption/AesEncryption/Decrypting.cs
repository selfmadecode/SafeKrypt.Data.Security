using SafeCrypt.src.Encrypt.AesEncryption;
using SafeCrypt.src.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.src.Encryption.AesEncryption
{
    public class Decrypting : BaseAesEncryption
    {
        public byte[] AesDecrypt(string data, string secretKey, string iv)
        {
            NullChecks(data, secretKey, iv);

            var (aesKey, aesIv) = ConvertKeysToBytesAndGetKeys(secretKey, iv);

            var aesData = data.HexadecimalStringToByteArray();
            return DecryptAES(aesData, aesKey, aesIv);
        }

        public byte[] Decrypt(byte[] data, byte[] secretKey, byte[] iv)
            => DecryptAES(data, secretKey, iv);


        private void NullChecks(string data, string secretKey, string iv)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException(nameof(data));

            if (secretKey == null || secretKey.Length <= 0)
                throw new ArgumentNullException(nameof(secretKey));

            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));
        }

        private (byte[], byte[]) ConvertKeysToBytesAndGetKeys(string secretKey, string iv)
        {

            return (secretKey.ConvertKeysToBytes(), iv.ConvertKeysToBytes());
        }
    }
}
