using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace BinarySearchBenchmarks;

public class Config : ManualConfig
{
    public Config()
    {
        AddJob(
            Job.Default
                .WithWarmupCount(1)
                .WithIterationCount(6)
                .WithLaunchCount(1)
        );
        WithOrderer(new FastestToSlowestOrderer());
        WithSummaryStyle(SummaryStyle.Default.WithMaxParameterColumnWidth(100));
        //WithOption(ConfigOptions.DisableOptimizationsValidator, true);
    }
}
