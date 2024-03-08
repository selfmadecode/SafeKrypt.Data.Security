# SafeCrypt AES Encryption and Decryption

## Overview

The SafeCrypt library provides a simple and secure implementation of the Advanced Encryption Standard (AES) algorithm for
encryption and decryption in C#.
This document guides you through the basic steps to use AES encryption and decryption methods.

## Table of Contents

- [Usage](#usage)
  - [EncryptToHexStringAsync method](#encryptToHexStringAsync-method)
    - [Encrypting Data](#encrypting-data)
    - [Decrypting Data](#decrypting-data)
  - [EncryptToBase64StringAsync method](#encryptToBase64StringAsync-method)
 - [Example](#example)
 - [EncryptionData Object](#encryptiondata-object)
 - [Cipher Modes](#cipher-modes)
- [Contributing](#contributing)

## Usage

### EncryptToHexStringAsync method

#### Encrypting Data

To encrypt data using the AES algorithm in this library, you first need to decide which method you want to use.
The `EncryptToHexStringAsync` method returns a hexadecimal string, while `EncryptToBase64StringAsync` returns a Base64 string.
Follow the steps below to use `EncryptToHexStringAsync`:

1. **Generate an IV Key:** Use the `KeyGenerators.GenerateHexadecimalIVKey()` method to create an Initialization Vector (IV) key. The IV is crucial for secure encryption.

2. **Generate a Secret Key:** Call `KeyGenerators.GenerateAesSecretKey(128)` to generate a secret key with the desired bit size. Supported bit sizes are 128, 192, or 256. Any other value will result in an exception.

3. **Create an EncryptionParameters Model:** Construct an `EncryptionParameters` model, providing the data to be encrypted, IV, and secret key.

4. **Call EncryptToHexStringAsync:** Invoke the `Aes.EncryptToHexStringAsync` method with the `EncryptionParameters` model to encrypt the data. Check for errors in the `Errors` property of the returned `EncryptionData` object.

#### Decrypting Data

To decrypt data encrypted with AES, follow these steps:

1. **Create a DecryptionParameters Model:** Build a `DecryptionParameters` model, providing the encrypted data, IV, and secret key used during encryption.

2. **Call DecryptFromHexStringAsync:** Use the `Aes.DecryptFromHexStringAsync` method with the `DecryptionParameters` model to decrypt the data. Ensure that the provided IV and secret key match those used during encryption.



### EncryptToBase64StringAsync method
To use the EncryptToBase64StringAsync method for encryption, follow these steps:

Generate an Initialization Vector (IV) using the KeyGenerators.GenerateBase64IVKey() method.
Generate a secret key by calling the KeyGenerators.GenerateAesSecretKey(256) method. The parameter for this method accepts the following values: 128, 192, 256. Any value aside from these throws an exception with the message "Invalid key size. Supported sizes are 128, 192, or 256 bits."
To encrypt the data, provide the EncryptionParameters model to the EncryptToBase64StringAsync method, along with an optional cipher mode. The cipher mode defaults to CBC if not specified.


## Example

```csharp
using SafeCrypt.AES;
using SafeCrypt.Helpers;
using SafeCrypt.Models;

// Using the EncryptToHexStringAsync and DecryptFromHexStringAsync methods

var aesIv = KeyGenerators.GenerateHexadecimalIVKey();
var secret = KeyGenerators.GenerateAesSecretKey(256);

var dataToEncrypt = "Hello World";

var data = new EncryptionParameters
{
    Data = dataToEncrypt,
    IV = aesIv,
    SecretKey = secret
};

Console.WriteLine($"Hex Encryption Started");

Console.WriteLine();
Console.WriteLine();

var encryptionResult = await Aes.EncryptToHexStringAsync(data);

if (encryptionResult.Errors.Count > 0)
{
    // List errors here
}

Console.WriteLine($"Hex Encrypted data: {encryptionResult.EncryptedData}");
Console.WriteLine($"IV key: {encryptionResult.Iv}");
Console.WriteLine($"Secret key: {encryptionResult.SecretKey}");

Console.WriteLine();
Console.WriteLine();

Console.WriteLine($"Hex Decryption Started");

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


Console.WriteLine($"Base64 Encryption Started");

Console.WriteLine();
Console.WriteLine();

var encryptedResult = await Aes.EncryptToBase64StringAsync(base64dataToEncrypt);
Console.WriteLine($"Base64 Encrypted data: {encryptedResult.EncryptedData}");
Console.WriteLine($"IV key: {encryptedResult.Iv}");
Console.WriteLine($"Secret key: {encryptedResult.SecretKey}");


Console.WriteLine();
Console.WriteLine();

Console.WriteLine($"Base64 Decryption Started");

var decryptionResponse = await Aes.DecryptFromBase64StringAsync(new DecryptionParameters
{
    Data = encryptedResult.EncryptedData,
    IV = base64AesIv,
    SecretKey = secret
});

Console.WriteLine($"Base64 Decrypted data: {decryptionResponse.DecryptedData}");
Console.WriteLine($"IV key: {decryptionResponse.Iv}");
Console.WriteLine($"Secret key: {decryptionResponse.SecretKey}");
```

## EncryptionData Object

The Encryption methods returns an `EncryptionData` object with the following properties:

- `EncryptedData`: Holds the encrypted data as a hexadecimal string.
- `Iv`: The Initialization Vector used for encryption.
- `SecretKey`: The secret key used for encryption.
- `HasError`: If an error occurs during encryption, this property is set to true.
- `Errors`: A list of all errors that occurred during encryption.

## Cipher Modes

By default, the methods uses Cipher Block Chaining (CBC) mode for both encryption and decryption.
If you change the mode during encryption, provide the same mode during decryption.

## Contributing

Contributions to the SafeCrypt library are welcome! Follow the contribution guidelines and feel free to open issues or submit pull requests.