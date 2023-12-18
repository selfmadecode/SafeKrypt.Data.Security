using SafeCrypt.src.Encryption.AesEncryption.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.Models
{
    /// <summary>
    /// Represents the data and initialization vector (IV) used in encryption.
    /// </summary>
    public class EncryptionData : BaseModel
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        public string EncryptedData { get; set; }
    }
}
