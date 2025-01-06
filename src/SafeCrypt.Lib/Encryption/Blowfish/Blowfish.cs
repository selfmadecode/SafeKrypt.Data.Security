using System.Text;
using System;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;

namespace SafeCrypt.Encryption.BlowfishEncryption
{
    public class Blowfish
    {
        private const int BlockSize = 8; // Blowfish block size is fixed at 8 bytes

        /// <summary>
        /// Encrypts a plaintext string using the Blowfish algorithm.
        /// </summary>
        /// <param name="plainText">The text to encrypt.</param>
        /// <param name="key">The encryption key (up to 448 bits).</param>
        /// <returns>Base64-encoded encrypted text.</returns>
        public static string Encrypt(string plainText, byte[] key)
        {
            var cipher = GeneratePaddedBufferedBlockCipher();

            cipher.Init(true, new KeyParameter(key));

            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = ProcessCipher(cipher, inputBytes);

            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Decrypts an encrypted Base64 string using the Blowfish algorithm.
        /// </summary>
        /// <param name="cipherText">The Base64-encoded encrypted text.</param>
        /// <param name="key">The decryption key (same key used for encryption).</param>
        /// <returns>The decrypted plaintext string.</returns>
        public static string Decrypt(string cipherText, byte[] key)
        {
            var cipher = GeneratePaddedBufferedBlockCipher();

            cipher.Init(false, new KeyParameter(key));

            byte[] encryptedBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = ProcessCipher(cipher, encryptedBytes);

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        /// <summary>
        /// Processes the encryption or decryption using the cipher.
        /// </summary>
        /// <param name="cipher">The cipher to process the data.</param>
        /// <param name="input">The input data to process.</param>
        /// <returns>The processed data.</returns>
        private static byte[] ProcessCipher(IBufferedCipher cipher, byte[] input)
        {
            try
            {
                return cipher.DoFinal(input);
            }
            catch (CryptoException ex)
            {
                throw new InvalidOperationException("Error during cipher processing", ex);
            }
        }

        private static PaddedBufferedBlockCipher GeneratePaddedBufferedBlockCipher()
        {
            var engine = new BlowfishEngine();
            return new PaddedBufferedBlockCipher(engine);
        }
    }
}
