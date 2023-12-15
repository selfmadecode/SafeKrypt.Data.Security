using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeCrypt.src.Encryption.AesEncryption.Models
{
    /// <summary>
    /// Represents the parameters required for encryption.
    /// </summary>
    public class ByteEncryptionParameters
    {
        /// <summary>
        /// Gets or sets the data to be encrypted.
        /// </summary>
        [Required]
        public byte[] Data { get; set; }

        /// <summary>
        /// Gets or sets the secret key used for encryption.
        /// </summary>
        [Required]
        public byte[] SecretKey { get; set; }

        /// <summary>
        /// Gets or sets the initialization vector (IV) used for encryption.
        /// </summary>
        [Required]
        public byte[] IV { get; set; }
    }
        

    

}
