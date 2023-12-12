# SafeCrypt Library

A C# library for encryption and decryption.

## Overview

The Encryption library provides a set of methods for encrypting and decrypting data using the Advanced Encryption Standard (AES) algorithm, and other algorithm. It is designed to be easy to use and can be integrated into C# applications that require secure data transmission or storage.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [API Reference](#api-reference)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## Installation

To use the SafeCrypt library in your C# project, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/selfmadecode/SafeCrypt
   cd SafeCrypt
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

Now, you can reference the SafeCrypt library in your C# project.

## Usage

To use the library in your C# application, instantiate the `SafeCrypt` class and call the provided methods. Here's a simple example:

```csharp
using SafeCrypt;

class Program
{
    static void Main()
    {
        var aesEncryptor = new AesEncryption();
        var encryptedData = aesEncryptor.AesEncrypt("Hello, World!", "mySecretKey");
        Console.WriteLine($"Encrypted Data: {encryptedData.Data}");
        Console.WriteLine($"Initialization Vector: {encryptedData.Iv}");
    }
}
```

## API Reference

### `AesEncryption`

- `AesEncrypt(byte[] data, byte[] secretKey, byte[] iv): byte[]`
  - Encrypts a byte array using AES algorithm.
  - Parameters:
    - `data`: The data to encrypt.
    - `secretKey`: The secret key for encryption.
    - `iv`: The initialization vector for encryption.
  - Returns: The encrypted data.

## Examples

### Encrypting a String

```csharp
var aesEncryptor = new AesEncryption();
var encryptionData = aesEncryptor.AesEncrypt("Hello, World!", "mySecretKey");
Console.WriteLine($"Encrypted Data: {encryptionData.Data}");
Console.WriteLine($"Initialization Vector: {encryptionData.Iv}");
```

## Contributing

If you would like to contribute to the development of the SafeCrypt library, follow these steps:

1. Create an issue to discuss the proposed changes or bug fixes.
2. Fork the repository and create a new branch for your work:

   ```bash
   git checkout -b feature/my-feature
   ```

3. Make your changes and commit them with clear and concise messages.
4. Push your changes to your fork.
5. Create a pull request from your branch to the main repository.
6. Ensure that your pull request follows the contribution guidelines and includes necessary tests.

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/selfmadecode/SafeCrypt/tree/master?tab=MIT-1-ov-file)https://github.com/selfmadecode/SafeCrypt/tree/master?tab=MIT-1-ov-file file for details.
