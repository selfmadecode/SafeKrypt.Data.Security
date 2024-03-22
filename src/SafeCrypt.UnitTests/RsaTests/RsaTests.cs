using SafeCrypt.Helpers;
using SafeCrypt.RsaEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeCrypt.UnitTests.RsaTests;

public class RsaTests
{
    private readonly string PublicKey;
    private readonly string PrivateKey;
    public RsaTests()
    {
        (PublicKey, PrivateKey) = KeyGenerators.GenerateRsaKeys(2048);
    }

    [Fact]
    public async Task EncryptAsync_DecryptAsync_ValidParameters_ReturnsOriginalData()
    {
        // Example: Generate RSA keys
        //var rsaKeyPair = KeyGenerators.GenerateRsaKeys(2048);
        //string rsaPublicKey = rsaKeyPair.Item1;
        //string rsaPrivateKey = rsaKeyPair.Item2;

        // Arrange
        var model = new RsaEncryptionParameters
        {
            DataToEncrypt = "Hello, RSA!",
            PublicKey = PublicKey
        };

        // Act
        var encrypt = await Rsa.EncryptAsync(model);

        var decryptModel = new RsaDecryptionParameters
        {
            DataToDecrypt = encrypt.EncryptedData,
            PrivateKey = PrivateKey
        };

        var decrypt = await Rsa.DecryptAsync(decryptModel);

        // Assert
        Assert.Equal(model.DataToEncrypt, decrypt.DecryptedData);
        Assert.NotNull(encrypt.EncryptedData);
        Assert.Empty(encrypt.Errors);
        Assert.NotNull(decrypt.DecryptedData);
        Assert.Empty(decrypt.Errors);
    }

    [Fact]
    public async Task EncryptAsync_InvalidData_ReturnsErrors()
    {
        // Arrange
        var model = new RsaEncryptionParameters
        {
            DataToEncrypt = "",
            PublicKey = PublicKey
        };

        // Act
        var result = await Rsa.EncryptAsync(model);

        // Assert
        Assert.Null(result.EncryptedData);
        Assert.NotEmpty(result.Errors);
    }
}
