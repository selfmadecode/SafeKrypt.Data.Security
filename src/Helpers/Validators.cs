using SafeCrypt.src.Encryption.AesEncryption.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.src.Helpers
{
    public static class Validators
    {
        /// <summary>
        /// Validates that the specified ByteEncryptionParameters instance is not null
        /// and that its required properties (Data, SecretKey, IV) are not null.
        /// </summary>
        /// <param name="parameters">The ByteEncryptionParameters instance to validate.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified parameters instance is null or if any of its required properties are null.
        /// </exception>
        public static void ValidateNotNull(ByteEncryptionParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters), "ByteEncryptionParameters instance cannot be null.");
            }

            if (parameters.Data == null)
            {
                throw new ArgumentNullException(nameof(parameters.Data), "Data property cannot be null.");
            }

            if (parameters.SecretKey == null)
            {
                throw new ArgumentNullException(nameof(parameters.SecretKey), "SecretKey property cannot be null.");
            }

            if (parameters.IV == null)
            {
                throw new ArgumentNullException(nameof(parameters.IV), "IV property cannot be null.");
            }
        }
    }
}
