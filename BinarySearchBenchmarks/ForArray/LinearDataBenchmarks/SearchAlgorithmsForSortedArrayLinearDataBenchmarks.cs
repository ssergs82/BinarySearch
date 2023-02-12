using TestData;

namespace BinarySearchBenchmarks.ForArray;

public class SearchAlgorithmsForSortedArrayLinearData1MBenchmarks : SearchAlgorithmsForSortedArrayBenchmarksBase
{
    public SearchAlgorithmsForSortedArrayLinearData1MBenchmarks() : base(new DefaultTestDataProvider<int>(), size: 1048576)
    {
    }
}

public class SearchAlgorithmsForSortedArrayLinearData131kBenchmarks : SearchAlgorithmsForSortedArrayBenchmarksBase
{
    public SearchAlgorithmsForSortedArrayLinearData131kBenchmarks():base(new DefaultTestDataProvider<int>(), size: 131072)
    {
    }
}

public class SearchAlgorithmsForSortedArrayLinearData16kBenchmarks : SearchAlgorithmsForSortedArrayBenchmarksBase
{
    public SearchAlgorithmsForSortedArrayLinearData16kBenchmarks() : base(new DefaultTestDataProvider<int>(), size: 16384)
    {
    }
}


public class SearchAlgorithmsForSortedArrayLinearData512Benchmarks : SearchAlgorithmsForSortedArrayBenchmarksBase
{
    public SearchAlgorithmsForSortedArrayLinearData512Benchmarks() : base(new DefaultTestDataProvider<int>(), size: 512)
    {
    }
}

public class SearchAlgorithmsForSortedArrayLinearData256Benchmarks : SearchAlgorithmsForSortedArrayBenchmarksBase
{
    public SearchAlgorithmsForSortedArrayLinearData256Benchmarks() : base(new DefaultTestDataProvider<int>(), size: 256)
    {
    }
}

public class SearchAlgorithmsForSortedArrayLinearData16Benchmarks : SearchAlgorithmsForSortedArrayBenchmarksBase
{
    public SearchAlgorithmsForSortedArrayLinearData16Benchmarks() : base(new DefaultTestDataProvider<int>(), size: 16)
    {
    }
}
