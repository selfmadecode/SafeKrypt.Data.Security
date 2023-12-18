using SafeCrypt.Models;
using SafeCrypt.src.Encryption.AesEncryption.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeCrypt.Helpers
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
        public static void ValidateNotNull(EncryptionParameters parameters)
        {
            if (parameters == null || parameters.DataToEncrypt == null || parameters.SecretKey == null || parameters.IV == null)
            {
                throw new ArgumentNullException(nameof(parameters), "All EncryptionParameters properties must be non-null.");
            }
        }

        /*
         * The error code S3928 is a SonarQube rule that suggests simplifying the code to use a single call to ArgumentNullException with a more general error message instead of individual checks for each property. This rule is often applied when there are multiple checks for null values, and consolidating them can lead to cleaner and more maintainable code.

        Here's a modified version of your code that addresses the SonarQube suggestion:

        This way, you have a single check that throws an ArgumentNullException if any of the specified properties is null, and the error message indicates that all properties must be non-null. This adheres to the SonarQube recommendation and can make the code more concise.
         * */

        public static void ValidateNotNull(DecryptionParameters parameters)
        {
            if (parameters == null || parameters.DataToDecrypt == null || parameters.SecretKey == null || parameters.IV == null)
            {
                throw new ArgumentNullException(nameof(parameters), "All DecryptionParameters properties must be non-null.");
            }
        }

        //Same comment as above
        public static void ValidateNotNull(StringEncryptionParameters parameters)
        {
            if (parameters == null || parameters.Data == null || parameters.SecretKey == null || parameters.IV == null)
            {
                throw new ArgumentNullException(nameof(parameters), "All StringEncryptionParameters properties must be non-null.");
            }
        }


        /// <summary>
        /// Validates whether the provided string is a valid Base64-encoded key.
        /// </summary>
        /// <param name="keyAsString">The string to validate.</param>
        /// <returns>True if the string is a valid Base64-encoded key; otherwise, false.</returns>
        /*
         * 
            Your IsBase64String method looks good for checking whether a given string is a valid base64-encoded string. It checks for null or empty input and then attempts to convert the input string to a byte array using Convert.FromBase64String. If the conversion succeeds, it returns true; otherwise, it catches a FormatException and returns false.

            Here's a slight improvement to make the code more concise:
         */
        public static bool IsBase64String(string keyAsString)
        {
            return !string.IsNullOrEmpty(keyAsString) &&
                   TryConvertFromBase64String(keyAsString);
        }

        private static bool TryConvertFromBase64String(string input)
        {
            try
            {
                Convert.FromBase64String(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        /// <summary>
        /// Validates whether the block size is valid for the AES algorithm.
        /// </summary>
        /// <param name="dataLength">The length of the data to be encrypted.</param>
        /// <returns>True if the block size is valid; otherwise, false.</returns>
        public static bool IsValidBlockSize(int dataLength)
        {
            // AES block size is 128 bits (16 bytes)
            return dataLength % 16 == 0;
        }

        /// <summary>
        /// Validates whether the byte array is valid for a specific algorithm.
        /// </summary>
        /// <param name="byteArray">The byte array to validate.</param>
        /// <returns>True if the byte array is valid; otherwise, false.</returns>
        private static bool IsValidByteArray(byte[] byteArray)
        {
            // Add your specific validation criteria here
            // For example, you might check for non-null, non-empty, or other constraints

            return byteArray != null && byteArray.Length > 0;
        }

        public static void AddError<T>(T responseData, string error) where T : BaseModel
        {
            if (responseData != null)
            {
                responseData.HasError = true;
                responseData.Errors.Add(error);
            }
            // Optionally handle the case where responseData is null.
            // You might throw an ArgumentNullException or handle it differently based on your requirements.
        }
    }
}
