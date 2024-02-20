// See https://aka.ms/new-console-template for more information

using SafeCrypt.AESDecryption;
using SafeCrypt.AESEncryption;
using SafeCrypt.Models;

var dataToEncrypt = "Data to Encrypt";
var secret = "hghjuytsdfraestwsgtere==";

// Encryption process
// this method generates a random IV key for the encryption process
// the IV is returned in the response with other properties 
var response = await AesEncryption.EncryptToBase64StringAsync(dataToEncrypt, secret);

Console.WriteLine("............Encryption Started............");

Console.WriteLine($"Encrypted data: {response.EncryptedData}");
Console.WriteLine($"IV key: {response.Iv}");
Console.WriteLine($"Secret key: {response.SecretKey}");


// Decryption process
var decryptorParam = new DecryptionParameters
{
    IV = response.Iv,
    SecretKey = secret,
    DataToDecrypt = response.EncryptedData
};

var decryptionData = await AesDecryption.DecryptFromBase64StringAsync(decryptorParam);

Console.WriteLine("............Decryption Started............");
Console.WriteLine($"Decrypted data: { decryptionData.DecryptedData }");
Console.WriteLine($"IV key: {decryptionData.Iv}");
Console.WriteLine($"Secret key: {decryptionData.SecretKey}");


Console.WriteLine("Hello, World!");
