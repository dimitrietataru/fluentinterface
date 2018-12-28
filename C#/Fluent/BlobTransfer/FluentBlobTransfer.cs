using Fluent.BlobTransfer.Enums;
using Fluent.BlobTransfer.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace Fluent.BlobTransfer
{
    public class FluentBlobTransfer : IAzureBlob, IAzureAction, IAzureWrite, IAzureRead
    {
        private readonly string connectionString;
        private string blobBlockPath;
        private string fileName;
        private TransferType type;

        private FluentBlobTransfer(string connectionString) => this.connectionString = connectionString;

        public static IAzureBlob Connect(string connectionString) => new FluentBlobTransfer(connectionString);

        public IAzureAction OnBlob(string blobBlockPath)
        {
            this.blobBlockPath = blobBlockPath;

            return this;
        }

        public IAzureWrite Download(string fileName)
        {
            this.fileName = fileName;
            type = TransferType.Download;

            return this;
        }

        public IAzureRead Upload(string fileName)
        {
            type = TransferType.Upload;
            this.fileName = fileName;

            return this;
        }

        public void ToFile(string filePath)
        {
            // Code to download from Azure Blob Storage to file
        }

        public async Task ToFileAsync(string filePath)
        {
            // Code to download async from Azure Blob Storage to file
        }

        public void ToStream(Stream stream)
        {
            // Code to download from Azure Blob Storage to stream
        }

        public async Task ToStreamAsync(Stream stream)
        {
            // Code to download async from Azure Blob Storage to stream
        }

        public void FromFile(string filePath)
        {
            // Code to upload from file to Azure Blob Storage
        }

        public async Task FromFileAsync(string filePath)
        {
            // Code to upload async from file to Azure Blob Storage
        }

        public void FromStream(Stream stream)
        {
            // Code to upload from stream to Azure Blob Storage
        }

        public async Task FromStreamAsync(Stream stream)
        {
            // Code to upload async from stream to Azure Blob Storage
        }
    }
}
