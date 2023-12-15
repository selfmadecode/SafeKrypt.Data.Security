using System;
using System.Text;
using SafeCrypt.src.Helpers;
using SafeCrypt.src.Encryption.AesEncryption.Models;
using SafeCrypt.AesEncryption;
using System.ComponentModel.DataAnnotations;

namespace SafeCrypt.Encrypt
{
    public class Encrypting : BaseAesEncryption
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
        public byte[] Encrypt(EncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            // Delegate the encryption to the underlying AES encryption method
            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = param.SecretKey.ConvertKeysToBytes(),
                IV = param.IV.ConvertKeysToBytes(),
                Data = param.DataToEncrypt.HexadecimalStringToByteArray()
            };
            return EncryptAES(byteEncryptionParameters);
        }

        
        public byte[] Encrypt(StringEncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = param.SecretKey.ConvertKeysToBytes(),
                IV = param.IV.ConvertKeysToBytes(),
                Data = param.Data.HexadecimalStringToByteArray()
            };

            return EncryptAES(byteEncryptionParameters);
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
            var aesIv = GenerateRandomIVKeyAsBytes(16);

            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = Convert.FromBase64String(base64secretKey),
                IV = aesIv,
                Data = dataToBeEncrypted.ConvertToHexString().HexadecimalStringToByteArray()
            };

            var response = EncryptAES(byteEncryptionParameters);

            var responseData = new EncryptionData
            {
                EncryptedData = Convert.ToBase64String(response),
                Iv = Convert.ToBase64String(aesIv)
            };

            return responseData;
        }

        /// <summary>
        /// Encrypts the provided byte data using the Advanced Encryption Standard (AES) algorithm
        /// and returns the encrypted data as a hexadecimal string.
        /// </summary>
        /// <param name="param">The parameters containing the byte data, secret key, and initialization vector (IV).</param>
        /// <returns>The encrypted data represented as a hexadecimal string.</returns>
        /// <remarks>
        /// This method encrypts the input byte data using the specified secret key and initialization vector (IV)
        /// using the AES algorithm. The resulting encrypted data is then converted to a hexadecimal string before being
        /// returned. The encryption parameters are encapsulated in a <see cref="ByteEncryptionParameters"/> object.
        /// </remarks>
        /// <param name="param">The parameters containing the byte data, secret key, and initialization vector (IV).</param>
        /// <returns>The encrypted data represented as a hexadecimal string.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the input parameters or byte data is null.
        /// </exception>
        public string EncryptByteToHexString(EncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = param.SecretKey.ConvertKeysToBytes(),
                IV = param.IV.ConvertKeysToBytes(),
                Data = param.DataToEncrypt.HexadecimalStringToByteArray()
            };

            var cipherText = EncryptAES(byteEncryptionParameters);

            // Convert the encrypted data to a hexadecimal string
            return cipherText.ByteArrayToHexString();
        }

        /// <summary>
        /// Encrypts the provided byte data using the Advanced Encryption Standard (AES) algorithm
        /// and returns the encrypted data as a Base64-encoded string.
        /// </summary>
        /// <param name="param">The parameters containing the byte data, secret key, and initialization vector (IV).</param>
        /// <returns>The encrypted data represented as a Base64-encoded string.</returns>
        /// <remarks>
        /// This method encrypts the input byte data using the specified secret key and initialization vector (IV)
        /// using the AES algorithm. The resulting encrypted data is then converted to a Base64-encoded string before
        /// being returned. The encryption parameters are encapsulated in a <see cref="ByteEncryptionParameters"/> object.
        /// </remarks>
        /// <param name="param">The parameters containing the byte data, secret key, and initialization vector (IV).</param>
        /// <returns>The encrypted data represented as a Base64-encoded string.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the input parameters or byte data is null.
        /// </exception>
        public string EncryptByteToBase64String(EncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = param.SecretKey.ConvertKeysToBytes(),
                IV = param.IV.ConvertKeysToBytes(),
                Data = param.DataToEncrypt.HexadecimalStringToByteArray()
            };

            var cipherText = EncryptAES(byteEncryptionParameters);

            return Convert.ToBase64String(cipherText);
        }

        /// <summary>
        /// Encrypts the provided byte data using the Advanced Encryption Standard (AES) algorithm
        /// and returns the encrypted data as a string using UTF-8 encoding.
        /// </summary>
        /// <param name="param">The parameters containing the byte data, secret key, and initialization vector (IV).</param>
        /// <returns>The encrypted data represented as a string using UTF-8 encoding.</returns>
        /// <remarks>
        /// This method encrypts the input byte data using the specified secret key and initialization vector (IV)
        /// using the AES algorithm. The resulting encrypted data is then converted to a string using UTF-8
        /// encoding before being returned. The encryption parameters are encapsulated in a <see cref="ByteEncryptionParameters"/> object.
        /// </remarks>
        /// <param name="param">The parameters containing the byte data, secret key, and initialization vector (IV).</param>
        /// <returns>The encrypted data represented as a string using UTF-8 encoding.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the input parameters or byte data is null.
        /// </exception>
        public string EncryptByteToString(EncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = param.SecretKey.ConvertKeysToBytes(),
                IV = param.IV.ConvertKeysToBytes(),
                Data = param.DataToEncrypt.HexadecimalStringToByteArray()
            };

            var cipherText = EncryptAES(byteEncryptionParameters);

            return cipherText.BytesToString();
        }
                    

        private void NullChecks(string data, string secretKey)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException(nameof(data));

            if (secretKey == null )
                throw new ArgumentNullException(nameof(secretKey));
        }
    }

}
