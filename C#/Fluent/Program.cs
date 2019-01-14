using Fluent.BlobTransfer;
using Fluent.Report;
using Fluent.Security;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Fluent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FluentBlobTransfer
                .Connect("storageAccountConnectionString")
                .OnBlob("blobName")
                .Download("fileName")
                .ToFile(@"D:\Azure\Downloads\");

            await FluentBlobTransfer
                .Connect("storageAccountConnectionString")
                .OnBlob("blobName")
                .Upload("fileName")
                .FromStreamAsync(null);

            var report = FluentReport
                .Pdf()
                .WithItems(new List<int> { 1, 2, 3 })
                .Generate();

            var asyncReport = await FluentReport
                .Xml()
                .WithFilteredItems(new List<int> { 1, 2, 3 })
                .ByMaximumThreshold(3)
                .GenerateAsync();

            var encryptedAes = FluentSecurity
                .Encrypt()
                .PlainText("plainText")
                .UsingAes()
                .WithKey("securityKey")
                .WithCipherMode(CipherMode.ECB)
                .WithPaddingMode(PaddingMode.ANSIX923)
                .Execute();

            var decryptedAes = FluentSecurity
                .Decrypt()
                .CipherText(encryptedAes)
                .UsingAes()
                .WithKey("securityKey")
                .WithCipherMode(CipherMode.ECB)
                .WithPaddingMode(PaddingMode.ANSIX923)
                .Execute();

            var encryptedRsa = FluentSecurity
                .Encrypt()
                .PlainText("plainText")
                .UsingRsa()
                .WithKey()
                .WithKeySize(2048)
                .WithPadding(RSAEncryptionPadding.Pkcs1)
                .ExecuteEncrypt(out RSAParameters privateKey);

            var decryptedRsa = FluentSecurity
                .Decrypt()
                .CipherText(encryptedRsa)
                .UsingRsa()
                .WithKey(privateKey)
                .WithKeySize(2048)
                .WithPadding(RSAEncryptionPadding.Pkcs1)
                .ExecuteDecrypt();
        }
    }
}
