using SafeCrypt.AES;
using SafeCrypt.Helpers;
using SafeCrypt.Models;

namespace SafeCrypt.App.Usage;

internal static class AesUsage
{
    internal static async Task Execute()
    {
        Console.WriteLine("------- AES Test Started -------");

        var aesIv = KeyGenerators.GenerateHexadecimalIVKey();
        var secret = KeyGenerators.GenerateAesSecretKey(256);
        var dataToEncrypt = "Hello World";

        var data = new EncryptionParameters
        {
            Data = dataToEncrypt,
            IV = aesIv,
            SecretKey = secret
        };

        Console.WriteLine($"AES Hex Encryption Started");
        Console.WriteLine();
        Console.WriteLine();
        var encryptionResult = await Aes.EncryptToHexStringAsync(data);

        if (encryptionResult.Errors.Count > 0)
        {
            // List errors here
        }

        Console.WriteLine($"Data to Encrypt {dataToEncrypt}");
        Console.WriteLine($"Hex Encrypted data: {encryptionResult.EncryptedData}");
        Console.WriteLine($"IV key: {encryptionResult.Iv}");
        Console.WriteLine($"Secret key: {encryptionResult.SecretKey}");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine($"Data to Decrypt: {encryptionResult.EncryptedData}");

        Console.WriteLine($"AES Hex Decryption Started");
        // Perform decryption using the same IV and secret
        var decryptionResult = await Aes.DecryptFromHexStringAsync(new DecryptionParameters
        {
            Data = encryptionResult.EncryptedData,
            IV = aesIv,
            SecretKey = secret
        });

        Console.WriteLine($"Hex Decrypted data: {decryptionResult.DecryptedData}");
        Console.WriteLine($"IV key: {decryptionResult.Iv}");
        Console.WriteLine($"Secret key: {decryptionResult.SecretKey}");

        // Using the EncryptToBase64StringAsync and DecryptFromBase64StringAsync methods

        var base64AesIv = KeyGenerators.GenerateBase64IVKey();

        var base64dataToEncrypt = new EncryptionParameters
        {
            Data = dataToEncrypt,
            IV = base64AesIv,
            SecretKey = secret
        };

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"AES Base64 Encryption Started");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"Data to Encrypt {dataToEncrypt}");
        Console.WriteLine();

        var encryptedResult = await Aes.EncryptToBase64StringAsync(base64dataToEncrypt);

        Console.WriteLine($"Base64 Encrypted data: {encryptedResult.EncryptedData}");

        Console.WriteLine($"IV key: {encryptedResult.Iv}");
        Console.WriteLine($"Secret key: {encryptedResult.SecretKey}");
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine($"AES Base64 Decryption Started");


        var decryptionResponse = await Aes.DecryptFromBase64StringAsync(new DecryptionParameters
        {
            Data = encryptedResult.EncryptedData,
            IV = base64AesIv,
            SecretKey = secret
        });

        Console.WriteLine($"Base64 Decrypted data: {decryptionResponse.DecryptedData}");
        Console.WriteLine($"IV key: {decryptionResponse.Iv}");
        Console.WriteLine($"Secret key: {decryptionResponse.SecretKey}");

        Console.WriteLine("------- AES Test Ended -------");
    }
}
