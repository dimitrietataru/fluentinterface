namespace Fluent.Security.Interfaces
{
    public interface ISecurityAlgorithm
    {
        IAesKey UsingAes();
        IRsaKey UsingRsa();
    }
}
