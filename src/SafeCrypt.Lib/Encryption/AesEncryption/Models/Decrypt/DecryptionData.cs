using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.Models
{
    public class DecryptionData
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        public string DecryptedData { get; set; }

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
