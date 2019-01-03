using System.Collections.Generic;

namespace Fluent.Report.Interfaces
{
    public interface IReportContent
    {
        IReportFilter WithFilteredItems(List<int> items);
        IReportExecute WithItems(List<int> items);
    }
}
