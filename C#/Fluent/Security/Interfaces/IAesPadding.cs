using System.Security.Cryptography;

namespace Fluent.Security.Interfaces
{
    public interface IAesPadding : IAesExecute
    {
        IAesExecute WithPaddingMode(PaddingMode paddingMode);
    }
}
