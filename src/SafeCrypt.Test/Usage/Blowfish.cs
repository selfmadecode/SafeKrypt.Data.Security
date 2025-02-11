using SafeCrypt.Encryption;
using SafeCrypt.Helpers;
using SafeCrypt.Encryption.BlowfishEncryption;

namespace safecrypt_testapp.Usage
{
    public static class BlowfishTest
    {
        public static void Test()
        {
            // Generate a random key (128 bits in this example)
            int keySize = 128; // Todo: validate keysize, it can be 32, 64, ..., 448
            byte[] key = KeyGenerators.GenerateBlowfishKey(keySize);

            string plainText = "Hello, Blowfish!";
            Console.WriteLine($"Original Text: {plainText}");

            // Encrypt
            string encryptedText = Blowfish.Encrypt(plainText, key);
            Console.WriteLine($"Encrypted Text (Base64): {encryptedText}");

            // Decrypt
            string decryptedText = Blowfish.Decrypt(encryptedText, key);
            Console.WriteLine($"Decrypted Text: {decryptedText}");
        }
    }
}
