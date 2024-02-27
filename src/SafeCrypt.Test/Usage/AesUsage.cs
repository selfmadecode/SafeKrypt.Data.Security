using SafeCrypt.AES;
using SafeCrypt.Models;

namespace SafeCrypt.App.Usage;

internal static class AesUsage
{
    internal static async void Execute()
    {
        Console.WriteLine("------- AES Test Started -------");

        var dataToEncrypt = "Data to Encrypt";
        var secret = "hghjuytsdfraestwsgtere==";

        // Encryption process
        // this method generates a random IV key for the encryption process
        // the IV is returned in the response with other properties 
        var response = await Aes.EncryptToBase64StringAsync(dataToEncrypt, secret);

        Console.WriteLine("............Encryption Started............");

        Console.WriteLine($"Encrypted data: {response.EncryptedData}");
        Console.WriteLine($"IV key: {response.Iv}");
        Console.WriteLine($"Secret key: {response.SecretKey}");

        Console.WriteLine();

        // Decryption process
        var decryptorParam = new DecryptionParameters
        {
            IV = response.Iv,
            SecretKey = secret,
            Data = response.EncryptedData
        };

        var decryptionData = await Aes.DecryptFromBase64StringAsync(decryptorParam);

        Console.WriteLine("............Decryption Started............");
        Console.WriteLine($"Decrypted data: {decryptionData.DecryptedData}");
        Console.WriteLine($"IV key: {decryptionData.Iv}");
        Console.WriteLine($"Secret key: {decryptionData.SecretKey}");
        
        Console.WriteLine();

        Console.WriteLine("------- AES Test Ended -------");

    }
}
