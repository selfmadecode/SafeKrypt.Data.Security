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
                // If there are errors in the encryption process, add them to the result and return
                result.Errors.AddRange(data.Errors);
                return result;
            }

            // Convert the encrypted data to a hexadecimal string
            //result.EncryptedData = data.EncryptedData;
            //result.EncryptedData = Convert.ToBase64String(data.EncryptedData);
            //result.EncryptedData = BitConverter.ToString(data.EncryptedData);
            //result.EncryptedData = Encoding.UTF8.GetString(data.EncryptedData); //Encoding.UTF8.GetString(decryptedData)
            result.EncryptedData = data.EncryptedData; //Encoding.UTF8.GetString(decryptedData)
            return result;
        }

        public static async Task<DecryptionResult> DecryptAsync(RsaDecryptionParameters model)
        {
            var result = new DecryptionResult();

            //if (string.IsNullOrWhiteSpace(model.DataToDecrypt))
            //{
            //    result.Errors.Add($"Data cannot be null {nameof(model.DataToDecrypt)}");
            //    return result;
            //}

            if (string.IsNullOrWhiteSpace(model.PrivateKey))
            {
                result.Errors.Add($"PrivateKey cannot be null {nameof(model.PrivateKey)}");
                return result;
            }

            // asynchronously perform RSA encryption
            var data = await RsaEncryption.DecryptAsync(model.DataToDecrypt, model.PrivateKey);

            if (data.Errors.Count > 0)
            {
                // if there are errors in the encryption process, add them to the result and return
                result.Errors.AddRange(data.Errors);
                return result;
            }
                        
            result.DecryptedData = Encoding.UTF8.GetString(data.DecryptedData);
            return result;
        }
    }
}
