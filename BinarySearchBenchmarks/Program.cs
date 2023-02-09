using BenchmarkDotNet.Running;
using BinarySearchBenchmarks.ForArray;

namespace BinarySearchBenchmarks;

class Program
{
    static void Main(string[] args)
    {
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData16Benchmarks>();
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData256Benchmarks>();
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData512Benchmarks>();
        //BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData16kBenchmarks>();
        BenchmarkRunner.Run<SearchAlgorithmsForSortedArrayLinearData131kBenchmarks>();
    }
}