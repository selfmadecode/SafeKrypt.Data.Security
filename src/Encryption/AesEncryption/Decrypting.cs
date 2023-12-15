using SafeCrypt.AesEncryption;
using SafeCrypt.Helpers;
using SafeCrypt.Models;
using SafeCrypt.src.Encryption.AesEncryption.Models;
using System;

namespace SafeCrypt.AESDecryption
{
    public class AesDecryption : BaseAesEncryption
    {
        public DecryptionData DeEncryptFromHexString(DecryptionParameters param)
        {
            var responseData = new DecryptionData();

            Validators.ValidateNotNull(param);

            // validate is base64
            if (!Validators.IsBase64String(param.SecretKey))
            {
                AddError(responseData, $"SecretKey: {param.SecretKey} is not a base64 string");
                return responseData;
            }

            if (!Validators.IsBase64String(param.IV))
            {
                AddError(responseData, $"IV: {param.IV} is not a base64 string");
                return responseData;
            }
            // Convert input string to bytes
            byte[] dataBytes = param.IV.ConvertKeysToBytes();

            // Validate block size based on AES algorithm's requirements
            if (!Validators.IsValidBlockSize(dataBytes.Length))
            {
                AddError(responseData, $"IV: {param.IV} is not a valid block size for this algorithm");
                return responseData;
            }

            // Delegate the encryption to the underlying AES encryption method
            var byteEncryptionParameters = new ByteDecryptionParameters
            {
                SecretKey = Convert.FromBase64String(param.SecretKey),
                IV = dataBytes,
                Data = param.DataToDecrypt.HexadecimalStringToByteArray()
            };

            var response = DecryptAES(byteEncryptionParameters);

            return new DecryptionData
            {
                DecryptedData = response.BytesToString(),
                Iv = param.IV,
                SecretKey = param.SecretKey
            };
        }

        public DecryptionData DecryptFromBase64String(DecryptionParameters param)
        {
            var responseData = new DecryptionData();

            Validators.ValidateNotNull(param);
            

            if (!Validators.IsBase64String(param.SecretKey))
            {
                AddError(responseData, $"SecretKey: {param.SecretKey} is not a base64 string");
                return responseData;
            }

            if (!Validators.IsBase64String(param.IV))
            {
                AddError(responseData, $"IV: {param.IV} is not a base64 string");
                return responseData;
            }

            try
            {
                var byteDecryptionParameters = new ByteDecryptionParameters
                {
                    SecretKey = Convert.FromBase64String(param.SecretKey),
                    IV = Convert.FromBase64String(param.IV),
                    Data = Convert.FromBase64String(param.DataToDecrypt)
                };

                var response = DecryptAES(byteDecryptionParameters);

                return new DecryptionData
                {
                    DecryptedData = response.BytesToString(),
                    Iv = param.IV,
                    SecretKey = param.SecretKey
                };
            }
            catch (Exception ex)
            {
                // Handle decryption failure or padding errors
                AddError(responseData, $"Decryption error: {ex.Message}");
                return responseData;
            }
        }


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

        private void AddError(DecryptionData responseData, string error)
        {
            responseData.HasError = true;
            responseData.Errors.Add(error);
        }
    }
}
