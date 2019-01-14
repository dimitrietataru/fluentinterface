namespace Fluent.Security.Interfaces
{
    public interface ITextCipher
    {
        ISecurityAlgorithm CipherText(string text);
    }
}
