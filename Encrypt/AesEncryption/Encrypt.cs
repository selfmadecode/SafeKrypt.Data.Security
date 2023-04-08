using System.IO;
using System.Security.Cryptography;

namespace SafeCrypt
{
    public class Encrypt : BaseAesEncryption
    {
        public byte[] AesEncrypt(byte[] data, byte[] key, byte[] iv)
        {
            return EncryptAES(data, key, iv);
        }

        public string AesEncryptByteToHex(byte[] data, byte[] key, byte[] iv)
        {
            var cipherText = EncryptAES(data, key, iv);

            return cipherText.ByteArrayToHexString();
        }

        public string AesEncryptByteToBase64(byte[] data, byte[] key, byte[] iv)
        {
            var cipherText = EncryptAES(data, key, iv);

            return cipherText.ByteArrayToHexString();
        }

        //public byte[] AesEncrypt(byte[] data, byte[] key, byte[] iv, ReturnType returnType)
        //{

        //}        
    }
}
