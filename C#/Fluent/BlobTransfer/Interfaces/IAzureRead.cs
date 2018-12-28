using System.IO;
using System.Threading.Tasks;

namespace Fluent.BlobTransfer.Interfaces
{
    public interface IAzureRead
    {
        void FromFile(string filePath);
        Task FromFileAsync(string filePath);
        void FromStream(Stream stream);
        Task FromStreamAsync(Stream stream);
    }
}
