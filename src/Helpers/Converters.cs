using System;
using System.IO;
using System.Text;

namespace SafeCrypt.src.Helpers
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

        public static byte[] ConvertKeysToBytes(this string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }
    }
}
