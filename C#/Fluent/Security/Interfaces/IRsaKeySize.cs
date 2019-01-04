namespace Fluent.Security.Interfaces
{
    public interface IRsaKeySize : IRsaExecute
    {
        IRsaPadding WithKeySize(int keySize);
    }
}
