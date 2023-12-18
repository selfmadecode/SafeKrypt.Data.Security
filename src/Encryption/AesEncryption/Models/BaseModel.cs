using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.src.Encryption.AesEncryption.Models
{
    public class BaseModel
    {
        /// <summary>
        /// Gets or sets Error
        /// </summary>
        public bool HasError { get; set; }
        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets the secret key used for encryption. Should be a base64 string
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// Gets or sets the initialization vector (IV) used for encryption.
        /// </summary>
        public string IV { get; set; }
    }
}
