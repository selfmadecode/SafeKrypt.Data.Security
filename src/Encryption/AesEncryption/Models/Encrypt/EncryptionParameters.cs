using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeCrypt.Models
{
    public class EncryptionParameters
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        [Required]
        public string DataToEncrypt { get; set; }

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

    public class StringEncryptionParameters
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

}
