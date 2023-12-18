using SafeCrypt.src.Encryption.AesEncryption.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.Models
{
    public class DecryptionData:BaseModel
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        public string DecryptedData { get; set; }
    }
}
