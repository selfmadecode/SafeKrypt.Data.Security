using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeCrypt.Models
{
    public class DecryptionParameters
    {
        /// <summary>
        /// Gets or sets the data to be decrypted.
        /// </summary>
        [Required]
        public string DataToDecrypt { get; set; }

        /// <summary>
        /// Gets or sets the secret key used for decryption.
        /// </summary>
        [Required]
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets the initialization vector (IV) used for decryption.
        /// </summary>
        [Required]
        public string IV { get; set; }
    }
}
