using System.Security.Cryptography;

namespace Fluent.Security.Interfaces
{
    public interface IRsaPadding : IRsaExecute
    {
        IRsaExecute WithPadding(RSAEncryptionPadding rsaPadding);
    }
}
