using BenchmarkDotNet.Running;
using BinarySearchAlgorithms.Services;
using BinarySearchBenchmarks.ForArray;

namespace BinarySearchBenchmarks;

class Program
{
    static void Main(string[] args)
    {
        SearchAlgorithmsProvider.AlgorithmTypePredicate = (Type p) =>
        {
            return p.Name.Contains("Monobound", StringComparison.InvariantCultureIgnoreCase);
        };

        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData16Benchmarks>();
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData256Benchmarks>();
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData512Benchmarks>();
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData16kBenchmarks>();
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData131kBenchmarks>();
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData1MBenchmarks>();
        BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData8MBenchmarks>();
    }
}