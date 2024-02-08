// See https://aka.ms/new-console-template for more information

using SafeCrypt.AESDecryption;
using SafeCrypt.AESEncryption;
using SafeCrypt.Helpers;
using SafeCrypt.Models;
using SafeCrypt.RsaEncryption;
using SafeCrypt.RsaEncryption.Models;

var dataToEncrypt = "Data to Encrypt";
var secret = "hghjuytsdfraestwsgtere==";

// Encryption process
var encryptor = new AesEncryption();
// this method generates a random IV key for the encryption process
// the IV is returned in the response with other properties 
var response = await encryptor.EncryptToBase64StringAsync(dataToEncrypt, secret);

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

var decryptor = new AesDecryption();
var decryptionData = await decryptor.DecryptFromBase64StringAsync(decryptorParam);

Console.WriteLine("............Decryption Started............");
Console.WriteLine($"Decrypted data: { decryptionData.DecryptedData }");
Console.WriteLine($"IV key: {decryptionData.Iv}");
Console.WriteLine($"Secret key: {decryptionData.SecretKey}");



///////////////////////////
///
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

var uccRYTED = new RsaDecryptionParameters
{
    DataToDecrypt = encryptedData.EncryptedData,
    PrivateKey = rsaPrivateKey
};

var decryptedData = await Rsa.DecryptAsync(uccRYTED);

// Display results
Console.WriteLine($"Original Data: {originalData}");
Console.WriteLine($"Encrypted Data: {encryptedData.EncryptedData}");
//Console.WriteLine($"Encrypted Data-------: {BitConverter.ToString(encryptedData.EncryptedData)}");
Console.WriteLine($"Decrypted Data: {decryptedData.DecryptedData}");


Console.WriteLine("Hello, World!");
