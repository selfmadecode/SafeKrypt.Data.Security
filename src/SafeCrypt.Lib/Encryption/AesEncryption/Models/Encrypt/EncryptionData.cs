using System.Collections.Generic;

namespace SafeCrypt.Models
{
    /// <summary>
    /// Represents the data and initialization vector (IV) used in encryption.
    /// </summary>
    public class EncryptionData
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        public string EncryptedData { get; set; }

        /// <summary>
        /// Gets or sets the initialization vector (IV) used for encryption.
        /// </summary>
        public string Iv { get; set; }

        /// <summary>
        /// Gets or sets the secret key used for encryption. Should be a base64 string
        /// </summary>
        public string SecretKey { get; set; }

        public bool HasError { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}
