using Fluent.BlobTransfer;
using Fluent.Report;
using Fluent.Security;
using Fluent.Security.Enums;
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

            FluentSecurity
                .Encrypt()
                .PlainText("plainText")
                .UsingAes()
                .WithKey("securityKey")
                .WithCipherMode(CipherMode.CBC)
                .WithPaddingMode(PaddingMode.ISO10126)
                .Execute();

            FluentSecurity
                .Encrypt()
                .PlainText("plainText")
                .UsingRsa()
                .WithKey(default)
                .WithKeySize(2048)
                .Execute();

            FluentAes
                .Initialize(ActionType.Encrypt, "plainText")
                .WithKey("")
                .Execute();

            FluentRsa
                .Initialize(ActionType.Encrypt, "plainText")
                .WithKey(default)
                .WithKeySize(2048)
                .Execute();
        }
    }
}
