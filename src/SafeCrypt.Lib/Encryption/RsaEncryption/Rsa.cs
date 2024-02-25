using System;
using System.Text;
using System.Threading.Tasks;
using SafeCrypt.RsaEncryption.Models;

namespace SafeCrypt.RsaEncryption
{
    public static class Rsa
    {
        /// <summary>
        /// Asynchronously encrypts the specified data using RSA encryption.
        /// </summary>
        /// <param name="model">The parameters for RSA encryption.</param>
        /// <returns>An <see cref="EncryptionResult"/> containing the encrypted data, and errors (if any).</returns>
        public static async Task<EncryptionResult> EncryptAsync(RsaEncryptionParameters model)
        {
            var result = new EncryptionResult();

            if(string.IsNullOrWhiteSpace(model.DataToEncrypt))
            {
                result.Errors.Add($"Data cannot be null {nameof(model.DataToEncrypt)}");
                return result;
            }

            if (string.IsNullOrWhiteSpace(model.PublicKey))
            {
                result.Errors.Add($"PublicKey cannot be null {nameof(model.PublicKey)}");
                return result;
            }

            // asynchronously perform RSA encryption
            var data = await RsaEncryption.EncryptAsync(model.DataToEncrypt, model.PublicKey);

            if(data.Errors.Count > 0)
            {
                result.Errors.AddRange(data.Errors);
                return result;
            }

            result.EncryptedData = data.EncryptedData;
            return result;
        }

        /// <summary>
        /// Asynchronously decrypts data using the RSA algorithm.
        /// </summary>
        /// <param name="model">The parameters for RSA decryption.</param>
        /// <returns>A task representing the asynchronous decryption operation. The result contains the decrypted data or any encountered errors.</returns>
        public static async Task<DecryptionResult> DecryptAsync(RsaDecryptionParameters model)
        {
            var result = new DecryptionResult();

            if(model.DataToDecrypt == null)
            {
                result.Errors.Add($"DataToDecrypt cannot be null {nameof(model.DataToDecrypt)}");
                return result;
            }

            if (string.IsNullOrWhiteSpace(model.PrivateKey))
            {
                result.Errors.Add($"PrivateKey cannot be null {nameof(model.PrivateKey)}");
                return result;
            }

            // asynchronously perform RSA encryption
            var data = await RsaEncryption.DecryptAsync(model.DataToDecrypt, model.PrivateKey);

            if (data.Errors.Count > 0)
            {
                result.Errors.AddRange(data.Errors);
                return result;
            }
                        
            result.DecryptedData = Encoding.UTF8.GetString(data.DecryptedData);
            return result;
        }
    }
}
