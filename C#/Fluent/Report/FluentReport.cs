using Fluent.Report.Enums;
using Fluent.Report.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluent.Report
{
    public class FluentReport : IReportContent, IReportFilter, IReportExecute
    {
        private readonly ReportType type;
        private List<int> reportItems;

        private FluentReport(ReportType type) => this.type = type;

        public static IReportContent Pdf() => new FluentReport(ReportType.Pdf);

        public static IReportContent Xml() => new FluentReport(ReportType.Xml);

        public static IReportContent Doc() => new FluentReport(ReportType.Doc);

        public IReportFilter WithFilteredItems(List<int> items)
        {
            reportItems = items;

            return this;
        }

        public IReportExecute WithItems(List<int> items)
        {
            reportItems = items;

            return this;
        }

        public IReportExecute ByMinimumThreshold(int threshold)
        {
            reportItems = reportItems
                .Where(item => item > threshold)
                .ToList();

            return this;
        }

        public IReportExecute ByMaximumThreshold(int threshold)
        {
            reportItems = reportItems
                .Where(item => item < threshold)
                .ToList();

            return this;
        }

        public object Generate()
        {
            // Code to generate report

            return default;
        }

        public async Task<object> GenerateAsync()
        {
            // Code to generate async report

            return default;
        }
    }
}
