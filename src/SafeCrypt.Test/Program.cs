// See https://aka.ms/new-console-template for more information
using SafeCrypt.App.Usage;
using safecrypt_testapp.Usage;

BlowfishTest.Test();

await RsaUsage.Execute();

await AesUsage.Execute();

Console.ReadLine();
