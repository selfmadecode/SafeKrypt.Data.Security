using SafeCrypt.Helpers;
using SafeCrypt.Models;
using SafeCrypt.AES;

namespace SafeCrypt.UnitTests.AesTests;

public class Encryption
{
    public const string Data = "Hello, World!";

    [Fact]
    public async Task EncryptToHexStringAsync_And_DecryptFromHexStringAsync_ValidParameters_ReturnsOriginalData()
    {
        // Arrange
        var aesIv = KeyGenerators.GenerateHexadecimalIVKey();
        var secret = KeyGenerators.GenerateAesSecretKey(256);

        var encryptionParameters = new EncryptionParameters
        {
            Data = Data,
            IV = aesIv,
            SecretKey = secret
        };

        // Act
        var encryptedResult = await Aes.EncryptToHexStringAsync(encryptionParameters);
        var decryptedResult = await Aes.DecryptFromHexStringAsync(new DecryptionParameters
        {
            Data = encryptedResult.EncryptedData,
            IV = aesIv,
            SecretKey = secret
        });

        // Assert
        Assert.NotNull(encryptedResult.EncryptedData);
        Assert.Equal(Data, decryptedResult.DecryptedData);

        Assert.False(encryptedResult.HasError);
        Assert.False(decryptedResult.HasError);

        Assert.Empty(encryptedResult.Errors);
        Assert.Empty(decryptedResult.Errors);
    }
}
