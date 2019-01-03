using Fluent.BlobTransfer;
using Fluent.Report;
using System.Collections.Generic;
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
        }
    }
}
