using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Collections.Immutable;

namespace BinarySearchBenchmarks;

public class FastestToSlowestOrderer : IOrderer
{
    public string GetHighlightGroupKey(BenchmarkCase benchmarkCase) => null;

    public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase)
    {
        return from benchmark in benchmarksCase
               orderby benchmark.Descriptor.WorkloadMethodDisplayInfo
               select benchmark;
    }

    public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCases, Summary summary)
    {
        return from benchmark in benchmarksCases
               orderby summary[benchmark].ResultStatistics.Mean
               select benchmark;
    }

    public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
    {
        return benchmarkCase.Job.DisplayInfo + "_" + benchmarkCase.Parameters.DisplayInfo;
    }

    public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups, IEnumerable<BenchmarkLogicalGroupRule> order = null)
    {
        return logicalGroups.OrderBy(it => it.Key);
    }

    public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase, IEnumerable<BenchmarkLogicalGroupRule> order = null)
    {
        return benchmarksCase.ToList();
    }


    public bool SeparateLogicalGroups => true;
}
