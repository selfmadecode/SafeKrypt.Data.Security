using SafeCrypt.Helpers;
using SafeCrypt.RsaEncryption;
using System.Collections;

namespace safecrypt_testapp.Usage;

internal class RsaUsage
{
    internal protected async void Usage()
    {
        // Example: Generate RSA keys
        var rsaKeyPair = KeyGenerators.GenerateRsaKeys(2048);

        string rsaPublicKey = rsaKeyPair.Item1;
        string rsaPrivateKey = rsaKeyPair.Item2;

        Console.WriteLine($"pubic key {rsaPublicKey}");
        Console.WriteLine($"private key {rsaPrivateKey}");

        // Example: Encrypt and Decrypt using RSA
        string originalData = "Hello, RSA Encryption!";

        var enModel = new RsaEncryptionParameters
        {
            DataToEncrypt = originalData,
            PublicKey = rsaPublicKey,
        };

        var encryptedData = await Rsa.EncryptAsync(enModel);

        Console.WriteLine($"Original Data: {originalData}");

        Console.WriteLine("Original byte array: " + BitConverter.ToString(encryptedData.EncryptedData));
        string EncryptedDataconvertedString = Convert.ToBase64String(encryptedData.EncryptedData);

        byte[] convertedBytes = Convert.FromBase64String(EncryptedDataconvertedString);

        Console.WriteLine("Converted back to byte array: " + BitConverter.ToString(convertedBytes));
        bool arraysAreEqual = StructuralComparisons.StructuralEqualityComparer.Equals(encryptedData.EncryptedData, convertedBytes);
        Console.WriteLine("Original and converted byte arrays are equal: " + arraysAreEqual);

        // Decrypting
        var decryptionModel = new RsaDecryptionParameters
        {
            DataToDecrypt = convertedBytes,
            PrivateKey = rsaPrivateKey
        };

        var decryptedData = await Rsa.DecryptAsync(decryptionModel);
        Console.WriteLine($"{decryptedData.DecryptedData}");

        Console.ReadLine();
    }
}
