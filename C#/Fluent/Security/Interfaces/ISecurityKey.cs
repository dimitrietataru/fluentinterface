namespace Fluent.Security.Interfaces
{
    public interface ISecurityKey
    {
        ISecurityAlgorithm WithKey(string key);
    }
}
