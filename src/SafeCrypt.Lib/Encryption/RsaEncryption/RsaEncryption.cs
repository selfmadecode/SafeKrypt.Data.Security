using System.Security.Cryptography;
using System.Text;
using System;
using System.Threading.Tasks;
using SafeCrypt.RsaEncryption.Models;

namespace SafeCrypt.RsaEncryption
{
    internal static class RsaEncryption
    {
        /// <summary>
        /// Asynchronously encrypts the provided data using the RSA (Rivest–Shamir–Adleman) algorithm.
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="publicKey">The public key used for encryption.</param>
        /// <returns>
        /// A task representing the asynchronous operation that, upon completion,
        /// returns an <see cref="RsaEncryptionResult"/> containing the encrypted data.
        /// </returns>
        /// <remarks>
        /// This method uses the RSA algorithm to encrypt the input data with the provided public key.
        /// The encryption is performed asynchronously using <see cref="Task.Run"/>.
        /// </remarks>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="publicKey">The public key used for encryption.</param>
        /// <returns>
        /// A task representing the asynchronous operation that, upon completion,
        /// returns an <see cref="RsaEncryptionResult"/> containing the encrypted data.
        /// </returns>
        internal static async Task<RsaEncryptionResult> EncryptAsync(string data, string publicKey)
        {
            var result = new RsaEncryptionResult();

            try
            {
                var encryptedData = await Task.Run(() =>
                {
                    using (var rsa = new RSACryptoServiceProvider())
                    {
                        rsa.FromXmlString(publicKey);
                        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                        return rsa.Encrypt(dataBytes, false);
                    }
                });

                result.EncryptedData = encryptedData;
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Decrypts data using RSA private key.
        /// </summary>
        /// <param name="encryptedData">The encrypted data.</param>
        /// <param name="privateKey">The RSA private key.</param>
        /// <returns>The decrypted data.</returns>
        internal static async Task<RsaDecryptionResult> DecryptAsync(byte[] encryptedData, string privateKey)
        {
            var result = new RsaDecryptionResult();

            try
            {
                var decryptedData = await Task.Run(() =>
                {
                    using (var rsa = new RSACryptoServiceProvider())
                    {
                        rsa.FromXmlString(privateKey);
                        byte[] dataBytes = encryptedData;
                        return rsa.Decrypt(encryptedData, false);
                    }
                });

                result.DecryptedData = decryptedData;

            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
