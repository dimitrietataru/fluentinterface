using System.IO;
using System.Threading.Tasks;

namespace Fluent.BlobTransfer.Interfaces
{
    public interface IAzureWrite
    {
        void ToFile(string filePath);
        Task ToFileAsync(string filePath);
        void ToStream(Stream stream);
        Task ToStreamAsync(Stream stream);
    }
}
