using SafeCrypt.Models;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SafeCrypt.AesEncryption
{
    public class BaseAesEncryption
    {
        /// <summary>
        /// Encrypts the provided data using the Advanced Encryption Standard (AES) algorithm.
        /// </summary>
        /// <param name="param.Data">The data to be encrypted.</param>
        /// <param name="param.SecretKey">The secret key used for encryption.</param>
        /// <param name="param.IV">The initialization vector used for encryption.</param>
        /// <returns>The encrypted data as a byte array.</returns>
        /// <remarks>
        /// The method uses the AES algorithm to encrypt the input data with the provided key and initialization vector.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the input data, key, or initialization vector is null.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown for general encryption-related exceptions.
        /// </exception>
        internal static byte[] EncryptAES(ByteEncryptionParameters param)
        {
            try
            {
                // Create an instance of the AES algorithm
                using (Aes aes = Aes.Create())
                {
                    // Set the key and initialization vector
                    aes.Key = param.SecretKey;
                    aes.IV = param.IV;
                    // Create an encryptor using the key and initialization vector
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    // Use a MemoryStream to store the encrypted data
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        // Use a CryptoStream to perform the encryption
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            // Write the data to be encrypted to the CryptoStream
                            cryptoStream.Write(param.Data, 0, param.Data.Length);
                            cryptoStream.FlushFinalBlock();

                            // Return the encrypted data as a byte array
                            return memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Decrypts the provided encrypted data using the Advanced Encryption Standard (AES) algorithm.
        /// </summary>
        /// <param name="encryptedData">The data to be decrypted.</param>
        /// <param name="key">The secret key used for decryption.</param>
        /// <param name="iv">The initialization vector used for decryption.</param>
        /// <returns>The decrypted data as a byte array.</returns>
        /// <remarks>
        /// The method uses the AES algorithm to decrypt the input encrypted data with the provided key and initialization vector.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the input encrypted data, key, or initialization vector is null.
        /// </exception>
        internal static byte[] DecryptAES(ByteDecryptionParameters param)
        {
            try
            {
                // Create an instance of the AES algorithm
                using (Aes aes = Aes.Create())
                {
                    // Set the key and initialization vector
                    aes.Key = param.SecretKey;
                    aes.IV = param.IV;

                    // Create a decryptor using the key and initialization vector
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    // Use a MemoryStream to read the encrypted data
                    using (MemoryStream memoryStream = new MemoryStream(param.Data))
                    {
                        // Use a CryptoStream to perform the decryption
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            // Use a MemoryStream to store the decrypted data
                            using (MemoryStream decryptedStream = new MemoryStream())
                            {
                                // Copy the decrypted data from the CryptoStream to the MemoryStream
                                cryptoStream.CopyTo(decryptedStream);
                                return decryptedStream.ToArray();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /*
        * method involves I/O operations, you should make it asynchronous by using the asynchronous methods provided by the cryptographic APIs
        * */
        internal static async Task<byte[]> DecryptAESAsync(ByteDecryptionParameters param)
        {
            using (Aes aes = Aes.Create())
            {
                // Set the key and initialization vector
                aes.Key = param.SecretKey;
                aes.IV = param.IV;

                // Create a decryptor using the key and initialization vector
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Use a MemoryStream to read the encrypted data
                using (MemoryStream memoryStream = new MemoryStream(param.Data))
                {
                    // Use a CryptoStream to perform the decryption
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream decryptedStream = new MemoryStream())
                        {
                            // Copy the decrypted data from the CryptoStream to the MemoryStream
                            await cryptoStream.CopyToAsync(decryptedStream);
                            return decryptedStream.ToArray();
                        }
                    }
                }
            }
        }

        internal static async Task<byte[]> EncryptAESAsync(ByteEncryptionParameters param)
        {
            // Create an instance of the AES algorithm
            using (Aes aes = Aes.Create())
            {
                // Set the key and initialization vector
                aes.Key = param.SecretKey;
                aes.IV = param.IV;
                // Create an encryptor using the key and initialization vector
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Use a MemoryStream to store the encrypted data
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Use a CryptoStream to perform the encryption
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        // Write the data to be encrypted to the CryptoStream
                        await cryptoStream.WriteAsync(param.Data, 0, param.Data.Length);
                        cryptoStream.FlushFinalBlock();

                        // Return the encrypted data as a byte array
                        return memoryStream.ToArray();
                    }
                }
            }
        }
    }
}
