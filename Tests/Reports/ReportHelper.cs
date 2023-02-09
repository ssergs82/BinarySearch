using Xunit.Abstractions;
using TestData.Extensions;
using Tests.NumberOfComparisons;

namespace Tests.Reports;

public static class ReportHelper
{
    public static  void GenerateReport(ITestOutputHelper output, int size, int[] ranges, int[] array, List<NumberOfComparisonsResult> result)
    {
        output.WriteLine($"Data size {size} and ranges [{ranges[0]} - {ranges[1]}]");
        output.WriteLine($"Data: {string.Join(", ", array)}\n".Truncate(1000));
        output.WriteLine("Algorithm name:\tSize\tTotal\tAvg");
        foreach (NumberOfComparisonsResult r in result.OrderBy(x => !x.IsImplemented).ThenBy(x => x.AvgComparisons))
        {
            if (r.IsImplemented)
            {
                output.WriteLine($"{r.AlgorithName}:\t{r.ArraySize}\t{r.TotalComparisons}\t{r.AvgComparisons}");
            }
            else
            {
                output.WriteLine($"{r.AlgorithName}:\tNot Implemented");
            }
        }
    }
}
