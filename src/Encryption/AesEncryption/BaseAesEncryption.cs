using System;
using System.IO;
using System.Security.Cryptography;

namespace SafeCrypt.src.Encrypt.AesEncryption
{
    public class BaseAesEncryption
    {
        /// <summary>
        /// Encrypts the provided data using the Advanced Encryption Standard (AES) algorithm.
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="key">The secret key used for encryption.</param>
        /// <param name="iv">The initialization vector used for encryption.</param>
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
        public virtual byte[] EncryptAES(byte[] data, byte[] key, byte[] iv)
        {
            try
            {
                // Create an instance of the AES algorithm
                using (Aes aes = Aes.Create())
                {
                    // Set the key and initialization vector
                    aes.Key = key;
                    aes.IV = iv;
                    // Create an encryptor using the key and initialization vector
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    // Use a MemoryStream to store the encrypted data
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        // Use a CryptoStream to perform the encryption
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            // Write the data to be encrypted to the CryptoStream
                            cryptoStream.Write(data, 0, data.Length);
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
        public static byte[] DecryptAES(byte[] encryptedData, byte[] key, byte[] iv)
        {
            // Create an instance of the AES algorithm
            using (Aes aes = Aes.Create())
            {
                // Set the key and initialization vector
                aes.Key = key;
                aes.IV = iv;

                // Create a decryptor using the key and initialization vector
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Use a MemoryStream to read the encrypted data
                using (MemoryStream memoryStream = new MemoryStream(encryptedData))
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

        
        /// <summary>
        /// Generates an array of random bytes using a cryptographically secure random number generator.
        /// </summary>
        /// <param name="length">The length of the byte array to generate.</param>
        /// <returns>An array of random bytes or the IV key</returns>
        /// <remarks>
        /// The method uses a cryptographically secure random number generator (RNGCryptoServiceProvider) to generate
        /// a byte array with the specified length, providing a high level of randomness suitable for cryptographic use.
        /// </remarks>
        /// <param name="length">The desired length of the generated byte array.</param>
        /// <returns>An array of random bytes with the specified length.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified length is less than or equal to zero.
        /// </exception>
        public static byte[] GenerateRandomIVKeyAsBytes(int length)
        {
            byte[] randomBytes = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
