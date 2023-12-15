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
        public byte[] Encrypt(ByteEncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            // Delegate the encryption to the underlying AES encryption method
            return EncryptAES(param);
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
        /// <param name="data">The string data to be encrypted.</param>
        /// <param name="secretKey">The secret key used for encryption.</param>
        /// <returns>An <see cref="AesEncrypted"/> object containing the encrypted data and initialization vector (IV).</returns>
        /// <remarks>
        /// This method encrypts the input string data using the specified secret key and a randomly generated initialization
        /// vector (IV) for AES encryption in Cipher Block Chaining (CBC) mode. The resulting encrypted data and IV are encapsulated
        /// in an <see cref="AesEncrypted"/> object, which is then returned.
        /// </remarks>
        /// <param name="data">The string data to be encrypted.</param>
        /// <param name="secretKey">The secret key used for encryption.</param>
        /// <returns>An <see cref="AesEncrypted"/> object containing the encrypted data and initialization vector (IV).</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the input data or secret key is null.
        /// </exception>
        public EncryptionData Encrypt(string data, string secretKey)
        {
            NullChecks(data, secretKey);

            // Generate a random 16-byte IV for AES in CBC mode
            var aesIv = GenerateRandomIVKeyAsBytes(16);

            //var aesKey = Encoding.UTF8.GetBytes(secretKey);
            //var aesData = data.HexadecimalStringToByteArray();

            var byteEncryptionParameters = new ByteEncryptionParameters
            {
                SecretKey = Encoding.UTF8.GetBytes(secretKey),
                IV = aesIv,
                Data = data.HexadecimalStringToByteArray()
            };

            //var response = EncryptAES(aesData, aesKey, aesIv);
            var response = EncryptAES(byteEncryptionParameters);

            var responseData = new EncryptionData
            {
                Data = response,
                Iv = aesIv
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
        public string EncryptByteToHexString(ByteEncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            var cipherText = EncryptAES(param);

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
        public string EncryptByteToBase64String(ByteEncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            var cipherText = EncryptAES(param);

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
        public string EncryptByteToString(ByteEncryptionParameters param)
        {
            Validators.ValidateNotNull(param);

            var cipherText = EncryptAES(param);

            return cipherText.BytesToString();
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
