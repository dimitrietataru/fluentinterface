using System.Security.Cryptography;

namespace Fluent.Security.Interfaces
{
    public interface IRsaKey
    {
        IRsaKeySize WithKey(RSAParameters key = default);
    }
}
