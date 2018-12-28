using Fluent.BlobTransfer;
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
        }
    }
}
