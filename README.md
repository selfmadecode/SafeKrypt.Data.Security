# SafeEnkrypt Library

A C# library for encryption and decryption.

## Overview

The SafeEnkrypt library provides a set of methods for encrypting and decrypting data using various encryption algorithms,
including the Advanced Encryption Standard (AES) and RSA (Rivest–Shamir–Adleman).
It is designed to be easy to use and can be integrated into C# applications that require secure data transmission or storage.
## Table of Contents

- [Installation](#installation)
- [AES Encryption and Decryption usage](#aes)
- [RSA Encryption and Decryption usage](#rsa)
- [Contributing](#contributing)
- [License](#license)

## Installation

To use the SafeEnkrypt library in your C# project, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/selfmadecode/SafeEnkrypt
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

Now, you can reference the SafeEnkrypt library in your C# project.

## Aes
To use AES encryption in your C# application, access the static Aes class directly.
Call the provided methods; 

Check the [Aes.md](doc/Aes.md) documentation for guidance.

## Rsa
This library provides a straightforward implementation of RSA encryption and decryption in C# using the .NET `RSACryptoServiceProvider`.
It includes methods for generating RSA key pairs, encrypting data with a public key, and decrypting data with a private key.

For more details on RSA Encryption, check the [Rsa.md](doc/Rsa.md) document.


## Contributing

If you would like to contribute to the development of the SafeEnkrypt library, follow these steps:

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

This project is licensed under the MIT License - see the [LICENSE](https://github.com/selfmadecode/SafeEnkrypt/tree/master?tab=MIT-1-ov-file) file for details.
