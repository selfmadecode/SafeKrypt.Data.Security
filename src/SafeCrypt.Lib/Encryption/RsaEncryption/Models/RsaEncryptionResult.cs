using System.Collections.Generic;

namespace SafeCrypt.RsaEncryption.Models
{
    public class RsaEncryptionResult
    {
        /// <summary>
        /// Gets or sets the encrypted data.
        /// </summary>
        public byte[] EncryptedData { get; set; }

        /// <summary>
        /// Gets or sets the list of errors encountered during encryption.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RsaEncryptionResult"/> class.
        /// </summary>
        public RsaEncryptionResult()
        {
            Errors = new List<string>();
        }
    }

    public class RsaDecryptionResult
    {
        /// <summary>
        /// Gets or sets the encrypted data.
        /// </summary>
        public byte[] DecryptedData { get; set; }

        /// <summary>
        /// Gets or sets the list of errors encountered during encryption.
        /// </summary>
        public List<string> Errors { get; set; }

        ///// <summary>
        ///// Gets or sets the public key used for encryption.
        ///// </summary>
        //public string PublicKey { get; set; }

        /// <summary>
        /// Gets or sets the private key used for encryption.
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RsaEncryptionResult"/> class.
        /// </summary>
        public RsaDecryptionResult()
        {
            Errors = new List<string>();
        }
    }

    public class EncryptionResult
    {
        /// <summary>
        /// Gets or sets the list of errors encountered during encryption.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets the encrypted data.
        /// </summary>
        public byte[] EncryptedData { get; set; }

        public EncryptionResult()
        {
            Errors = new List<string>();
        }
    }

    public class DecryptionResult
    {
        /// <summary>
        /// Gets or sets the list of errors encountered during encryption.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets the encrypted data.
        /// </summary>
        public string DecryptedData { get; set; }

        public DecryptionResult()
        {
            Errors = new List<string>();
        }
    }
}
