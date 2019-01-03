using System.Threading.Tasks;

namespace Fluent.Report.Interfaces
{
    public interface IReportExecute
    {
        object Generate();
        Task<object> GenerateAsync();
    }
}
