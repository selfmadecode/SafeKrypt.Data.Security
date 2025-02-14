using System.ComponentModel.DataAnnotations;

namespace SafeCrypt.RsaEncryption
{
    public sealed class RsaEncryptionParameters : IEncryptionData
    {
        /// <summary>
        /// Gets or sets the public key for RSA encryption.
        /// </summary>
        [Required]
        public string PublicKey { get; set; }       

        /// <summary>
        /// Gets or sets the data to be encrypted using RSA.
        /// </summary>
        [Required]
        public string DataToEncrypt { get; set; }
    }

    public sealed class RsaDecryptionParameters 
    {
        /// <summary>
        /// Gets or sets the private key for RSA encryption.
        /// </summary>
        [Required]
        public string PrivateKey { get; set; }

        /// <summary>
        /// Gets or sets the data to be encrypted using RSA.
        /// </summary>
        [Required]
        public byte[] DataToDecrypt { get; set; }
    }
}
