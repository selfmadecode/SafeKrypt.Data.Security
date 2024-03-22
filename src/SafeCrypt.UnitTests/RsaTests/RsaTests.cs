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
    [Fact]
    public async Task EncryptAsync_DecryptAsync_ValidParameters_ReturnsOriginalData()
    {
        // Example: Generate RSA keys
        var rsaKeyPair = KeyGenerators.GenerateRsaKeys(2048);
        string rsaPublicKey = rsaKeyPair.Item1;
        string rsaPrivateKey = rsaKeyPair.Item2;

        // Arrange
        var model = new RsaEncryptionParameters
        {
            DataToEncrypt = "Hello, RSA!",
            PublicKey = rsaPublicKey
        };

        // Act
        var encrypt = await Rsa.EncryptAsync(model);

        var decryptModel = new RsaDecryptionParameters
        {
            DataToDecrypt = encrypt.EncryptedData,
            PrivateKey = rsaPrivateKey
        };

        var decrypt = await Rsa.DecryptAsync(decryptModel);

        // Assert
        Assert.Equal(model.DataToEncrypt, decrypt.DecryptedData);
        Assert.NotNull(encrypt.EncryptedData);
        Assert.Empty(encrypt.Errors);
        Assert.NotNull(decrypt.DecryptedData);
        Assert.Empty(decrypt.Errors);
    }
}
