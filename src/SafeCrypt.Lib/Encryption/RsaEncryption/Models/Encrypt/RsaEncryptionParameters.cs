namespace SafeCrypt.RsaEncryption.Models
{
    internal class RsaEncryptionParameters : IEncryptionData
    {
        /// <summary>
        /// Gets or sets the public key for RSA encryption.
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Gets or sets the private key for RSA encryption.
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// Gets or sets the data to be encrypted using RSA.
        /// </summary>
        public string DataToEncrypt { get; set; }
    }
}
