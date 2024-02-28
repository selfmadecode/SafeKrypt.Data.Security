using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SafeCrypt.Models
{
    public class BaseAesEncryptionParameters
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        [Required]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the secret key used for encryption.
        /// </summary>
        [Required]
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets the initialization vector (IV) used for encryption.
        /// </summary>
        [Required]
        public string IV { get; set; }
    }

    public class BaseAesData
    {
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
