using System.Collections.Generic;

namespace SafeCrypt.Models
{
    public class DecryptionData : BaseAesData
    {
        /// <summary>
        /// Gets or sets the data to be decrypted.
        /// </summary>
        public string DecryptedData { get; set; }
    }
}
