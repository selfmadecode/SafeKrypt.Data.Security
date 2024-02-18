# RSA Encryption and Decryption

## Overview

This library provides a straightforward implementation of RSA encryption and decryption in C# using the .NET `RSACryptoServiceProvider`.
It includes methods for generating RSA key pairs, encrypting data with a public key, and decrypting data with a private key.

## Table of Contents

- [Usage](#usage)
  - [Generate RSA Keys](#generate-rsa-keys)
  - [Encrypt and Decrypt using RSA](#encrypt-and-decrypt-using-rsa)

## Usage

### Generate RSA Keys

```csharp
using SafeCrypt.Helpers;

var rsaKeyPair = KeyGenerators.GenerateRsaKeys(2048);

string rsaPublicKey = rsaKeyPair.Item1;
string rsaPrivateKey = rsaKeyPair.Item2;

Console.WriteLine($"Public Key: {rsaPublicKey}");
Console.WriteLine($"Private Key: {rsaPrivateKey}");
```

### Encrypt and Decrypt using RSA

```csharp
    using SafeCrypt.RsaEncryption;

    // Encrypt
    string originalData = "Hello, RSA Encryption!";

    var encryptionModel = new RsaEncryptionParameters
    {
        DataToEncrypt = originalData,
        PublicKey = rsaPublicKey,
    };

    var encryptedData = await Rsa.EncryptAsync(encryptionModel);

    Console.WriteLine($"Original Data: {originalData}");
    Console.WriteLine("Encrypted Data: " + BitConverter.ToString(encryptedData.EncryptedData));

    // Convert encrypted byte array to Base64 string
    string encryptedDataConvertedString = Convert.ToBase64String(encryptedData.EncryptedData);

    // Convert string back to byte array for decryption
    byte[] convertedBytes = Convert.FromBase64String(encryptedDataConvertedString);

    bool arraysAreEqual = StructuralComparisons.StructuralEqualityComparer.Equals(encryptedData.EncryptedData, convertedBytes);
    Console.WriteLine("Original and converted byte arrays are equal: " + arraysAreEqual); // should return true



    // Decrypt
    var decryptionModel = new RsaDecryptionParameters
    {
        DataToDecrypt = convertedBytes, // encryptedData.EncryptedData
        PrivateKey = rsaPrivateKey,
    };

    var decryptedData = await Rsa.DecryptAsync(decryptionModel);

    // if Error occurs during encryption
    if (decryptedData.Errors.Count > 0)
    {
        Console.WriteLine("Decryption Errors:");
        foreach (var error in decryptedData.Errors)
        {
            Console.WriteLine(error);
        }
    }
    else
    {
        Console.WriteLine($"Decrypted Data: {decryptedData.DecryptedData}"); 
    }

// Note: The return type from Rsa.EncryptAsync is `EncryptionResult`, and Rsa.DecryptAsync is `DecryptionResult`.
// Both models include a list of errors encountered during encryption/decryption.

```
## Contributing

Contributions are welcome! Feel free to open issues, submit pull requests, or provide feedback.