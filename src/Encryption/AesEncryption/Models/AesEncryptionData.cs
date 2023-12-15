using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.src.Encryption.AesEncryption.Models
{
    public class AesEncryptionData
    {
        public byte[] Data { get; set; }
        public byte[] Iv { get; set; }
    }
}
