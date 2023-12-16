using System;
using System.Security.Cryptography;
using SafeCrypt.AesEncryption;
using SafeCrypt.Helpers;
using SafeCrypt.Models;

namespace SafeCrypt.AESEncryption
{
    public class AesEncryption : BaseAesEncryption
    {
        /// <summary>
        /// Encrypts the provided data using the specified secret key and initialization vector (IV).
        /// </summary>
        /// <param name="parameters">The encryption parameters.</param>
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
        public EncryptionData EncryptToHexString(EncryptionParameters param)
        {
            var responseData = new EncryptionData();

            var parameterValidation = ValidateEncryptionParameters(param);

            if (parameterValidation.HasError)
            {
                return parameterValidation;
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
            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = Convert.FromBase64String(param.SecretKey),
                IV = dataBytes,
                Data = param.DataToEncrypt.ConvertToHexString().HexadecimalStringToByteArray()
            };

            var response = EncryptAES(byteEncryptionParameters);

            return new EncryptionData
            {
                EncryptedData = response.ByteArrayToHexString(),
                Iv = param.IV,
                SecretKey = param.SecretKey
            };
        }

        /// <summary>
        /// Encrypts the provided string data using the Advanced Encryption Standard (AES) algorithm.
        /// </summary>
        /// <param name="dataToBeEncrypted">The string data to be encrypted.</param>
        /// <param name="base64secretKey">The Base64-encoded secret key used for encryption.</param>
        /// <returns>An <see cref="EncryptionData"/> object containing the encrypted data and initialization vector (IV) as bas64 strings.</returns>
        /// <remarks>
        /// This method validates the Base64 encoding of the secret key using <see cref="Validators.IsBase64String"/>.
        /// If the key is not valid, the method returns null. Otherwise, it proceeds with the encryption process.
        /// The method generates a random 16-byte IV for AES in CBC mode, converts the input data to a byte array,
        /// and then encrypts the data using AES. The result is encapsulated in an <see cref="EncryptionData"/> object
        /// containing the encrypted data and IV, both Base64-encoded.
        /// </remarks>
        /// <param name="dataToBeEncrypted">The string data to be encrypted.</param>
        /// <param name="base64secretKey">The Base64-encoded secret key used for encryption.</param>
        /// <returns>An <see cref="EncryptionData"/> object containing the encrypted data and initialization vector (IV).</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the input data or base64secretKey is null.
        /// </exception>
        /// <exception cref="FormatException">
        /// Thrown if the base64secretKey is not a valid Base64-encoded string.
        /// </exception>
        public EncryptionData EncryptToBase64String(string dataToBeEncrypted, string base64secretKey)
        {
            // validate is base64
            if (!Validators.IsBase64String(base64secretKey))
            {
                return null;
            }

            NullChecks(data: dataToBeEncrypted, base64secretKey);

            // Generate a random 16-byte IV for AES in CBC mode
            var aesIv = KeyGenerators.GenerateRandomIVKeyAsBytes(16);

            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = Convert.FromBase64String(base64secretKey),
                IV = aesIv,
                Data = dataToBeEncrypted.ConvertToHexString().HexadecimalStringToByteArray()
            };

            var response = EncryptAES(byteEncryptionParameters);

            return new EncryptionData
            {
                EncryptedData = Convert.ToBase64String(response),
                Iv = Convert.ToBase64String(aesIv),
                SecretKey = base64secretKey
            };
        }

        private EncryptionData ValidateEncryptionParameters(EncryptionParameters param)
        {
            var responseData = new EncryptionData();

            Validators.ValidateNotNull(param);

            // validate is base64
            if (!Validators.IsBase64String(param.SecretKey))
            {
                AddError(responseData, $"SecretKey: {param.SecretKey} is not a base64 string");
            }

            if (!Validators.IsBase64String(param.IV))
            {
                AddError(responseData, $"IV: {param.IV} is not a base64 string");
            }

            return responseData;
        }

        private void NullChecks(string data, string secretKey)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException(nameof(data));

            if (secretKey == null )
                throw new ArgumentNullException(nameof(secretKey));
        }

        private void AddError(EncryptionData responseData, string error)
        {
            responseData.HasError = true;
            responseData.Errors.Add(error);
        }        
    }
}
