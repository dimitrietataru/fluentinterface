namespace Fluent.BlobTransfer.Interfaces
{
    public interface IAzureAction
    {
        IAzureWrite Download(string fileName);
        IAzureRead Upload(string fileName);
    }
}
