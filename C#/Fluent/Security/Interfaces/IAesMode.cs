using System.Security.Cryptography;

namespace Fluent.Security.Interfaces
{
    public interface IAesMode : IAesExecute
    {
        IAesPadding WithCipherMode(CipherMode cipherMode);
    }
}
