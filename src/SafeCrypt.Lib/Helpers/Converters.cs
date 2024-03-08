using System;
using System.IO;
using System.Text;

namespace SafeCrypt.Helpers
{
    public static class Converters
    {
        public static string ByteArrayToHexString(this byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string BytesToString(this byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public static byte[] HexadecimalStringToByteArray(this string input)
        {
            var outputLength = input.Length / 2;
            var output = new byte[outputLength];
            using (var sr = new StringReader(input))
            {
                for (var i = 0; i < outputLength; i++)
                    output[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(),
                    (char)sr.Read() }), 16);
            }
            return output;
        }

        /// <summary>
        /// Converts a string to its hexadecimal representation.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The hexadecimal representation of the input string.</returns>

        public static string ConvertToHexString(this string input)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(input);
            StringBuilder hexBuilder = new StringBuilder(byteArray.Length * 2);

            foreach (byte b in byteArray)
            {
                hexBuilder.AppendFormat("{0:X2}", b);
            }

            return hexBuilder.ToString();
        }

        /// <summary>
        /// Converts a string to byte array.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The byte array representation of the input string if valid; otherwise, null.</returns>
        public static byte[] ConvertKeysToBytes(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            return Encoding.UTF8.GetBytes(input);
        }
    }
}
