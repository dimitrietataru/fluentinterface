namespace Fluent.BlobTransfer.Interfaces
{
    public interface IAzureBlob
    {
        IAzureAction OnBlob(string blobBlockPath);
    }
}
