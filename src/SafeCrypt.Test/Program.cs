// See https://aka.ms/new-console-template for more information

using SafeCrypt.AESDecryption;
using SafeCrypt.AESEncryption;
using SafeCrypt.Models;

var dataToEncrypt = "Data to Encrypt";
var secret = "hghjuytsdfraestwsgtere==";

// Encryption process
var encryptor = new AesEncryption();
// this method generates a random IV key for the encryption process
// the IV is returned in the response with other properties 
var response = encryptor.EncryptToBase64String(dataToEncrypt, secret);

//Console.WriteLine("............Encryption Started............");

//Console.WriteLine($"Encrypted data: {response.EncryptedData}");
//Console.WriteLine($"IV key: {response.Iv}");
//Console.WriteLine($"Secret key: {response.SecretKey}");


// Decryption process
var decryptorParam = new DecryptionParameters
{
    IV = response.Iv,
    SecretKey = secret,
    DataToDecrypt = response.EncryptedData
};

var decryptor = new AesDecryption();
var decryptionData = decryptor.DecryptFromBase64String(decryptorParam);

Console.WriteLine("............Decryption Started............");
Console.WriteLine($"Decrypted data: { decryptionData.DecryptedData }");
Console.WriteLine($"IV key: {decryptionData.Iv}");
Console.WriteLine($"Secret key: {decryptionData.SecretKey}");


Console.WriteLine("Hello, World!");
