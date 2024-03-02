using System.Collections.Generic;

namespace SafeCrypt.Models
{
    public class EncryptionData : BaseAesData
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        public string EncryptedData { get; set; }
    }
}
