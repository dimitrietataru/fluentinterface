using System.Security.Cryptography;

namespace Fluent.Security.Interfaces
{
    public interface IRsaExecute
    {
        string ExecuteEncrypt(out RSAParameters privateKey);
        string ExecuteDecrypt();
    }
}
