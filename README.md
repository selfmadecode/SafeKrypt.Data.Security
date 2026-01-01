## SafeKrypt Library
[![NuGet Version](https://img.shields.io/nuget/v/SafeCrypt.Data.Security.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/SafeCrypt.Data.Security)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SafeCrypt.Data.Security.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/SafeCrypt.Data.Security)
[![License](https://img.shields.io/github/license/selfmadecode/SafeKrypt.Data.Security.svg?style=flat)](LICENSE)
[![GitHub Stars](https://img.shields.io/github/stars/selfmadecode/SafeKrypt.Data.Security?style=flat&logo=github)](https://github.com/selfmadecode/SafeKrypt.Data.Security/stargazers)
[![GitHub Issues](https://img.shields.io/github/issues/selfmadecode/SafeKrypt.Data.Security.svg?style=flat)](https://github.com/selfmadecode/SafeKrypt.Data.Security/issues)
[![Open PRs](https://img.shields.io/github/issues-pr/selfmadecode/SafeKrypt.Data.Security.svg?style=flat)](https://github.com/selfmadecode/SafeKrypt.Data.Security/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat)](https://github.com/selfmadecode/SafeKrypt.Data.Security/pulls)
![.NET Standard 2.0](https://img.shields.io/badge/.NET-Standard%202.0-512BD4?style=flat&logo=dot-net)

A C# utility library for encryption and decryption.

## Overview

This library provides a set of methods for encrypting and decrypting data using various encryption algorithms,
including the Advanced Encryption Standard (AES) and RSA (Rivest–Shamir–Adleman).
It is designed to be easy to use and can be integrated into C# applications that require secure data transmission or storage.

## Table of Contents

- [Installation](#installation)
- [AES Encryption and Decryption usage](#aes)
- [RSA Encryption and Decryption usage](#rsa)
- [Contributing](#contributing)
- [License](#license)

## Installation

To use this library in your C# project, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/selfmadecode/SafeKrypt.Data.Security
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

Now, you can reference the library in your C# project.

## Aes
To use AES encryption in your C# application, access the static Aes class directly.
Call the provided methods; 

Check the [Aes.md](doc/Aes.md) documentation for guidance.

## Rsa
This library provides a straightforward implementation of RSA encryption and decryption in C# using the .NET `RSACryptoServiceProvider`.
It includes methods for generating RSA key pairs, encrypting data with a public key, and decrypting data with a private key.

For more details on RSA Encryption, check the [Rsa.md](doc/Rsa.md) document.


## Contributing

If you would like to contribute to the development of the library, follow these steps:

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

This project is licensed under the MIT License - see the [LICENSE](https://github.com/selfmadecode/SafeKrypt.Data.Security/tree/master?tab=MIT-1-ov-file) file for details.
