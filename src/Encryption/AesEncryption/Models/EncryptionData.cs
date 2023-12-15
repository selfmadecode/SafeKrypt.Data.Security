using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.src.Encryption.AesEncryption.Models
{
    /// <summary>
    /// Represents the data and initialization vector (IV) used in encryption.
    /// </summary>
    public class EncryptionData
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Gets or sets the initialization vector (IV) used for encryption.
        /// </summary>
        public byte[] Iv { get; set; }
    }
}
