using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Services;
using TestData;
using Tests.Reports;

using Xunit.Abstractions;

namespace Tests.NumberOfComparisons.Models;

public abstract class NumberOfComparisonsTestsBase
{
    protected readonly ITestOutputHelper _output;
    protected readonly ITestDataProvider<int> _testDataProvider;
    protected readonly List<IArraySearch> _searchAlgorithms;

    public NumberOfComparisonsTestsBase(
        ITestOutputHelper output,
        ITestDataProvider<int> testDataProvider,
        SearchAlgorithmsProvider searchAlgorithmsProvider
    )
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));
        _testDataProvider = testDataProvider ?? throw new ArgumentNullException(nameof(testDataProvider));
        _searchAlgorithms = searchAlgorithmsProvider.GetSearchAlgorithms<IArraySearch>();
    }

    [Theory]
    [InlineData(3, new int[] { 0, 100 })]
    [InlineData(4, new int[] { 0, 100 })]
    [InlineData(5, new int[] { 0, 100 })]
    [InlineData(10, new int[] { 0, 100 })]
    [InlineData(50, new int[] { 0, 100 })]
    [InlineData(100, new int[] { 0, 101 })]
    [InlineData(100, new int[] { 0, 150 })]
    [InlineData(100, new int[] { 0, 200 })]
    [InlineData(100, new int[] { 0, 300 })]
    [InlineData(100, new int[] { 0, 500 })]
    [InlineData(100, new int[] { 0, 1000 })]
    [InlineData(100, new int[] { 0, 10000 })]
    [InlineData(10000, new int[] { 0, 100000 })]
    public void CalculateForNoDuplicatesData(int size, int[] ranges)
    {
        List<NumberOfComparisonsResult> result = new List<NumberOfComparisonsResult>();


        int[] array = _testDataProvider.Get(
            new DataGenerationParameters
            {
                Size = size,
                Sorted = true,
                RangeStart = ranges[0],
                RangeEnd = ranges[1],
                CanHasDuplicates = false
            }
        );

        foreach (IArraySearch searchAlgorithm in _searchAlgorithms)
        {
            try
            {
                int numberOfComparisons = 0;
                foreach (var value in array)
                {
                    searchAlgorithm.Find(array, value, ref numberOfComparisons);
                }

                result.Add(new NumberOfComparisonsResult
                {
                    AlgorithName = searchAlgorithm.GetType().Name,
                    IsImplemented = true,
                    ArraySize = size,
                    TotalComparisons = numberOfComparisons
                });
            }
            catch (NotImplementedException)
            {
                result.Add(new NumberOfComparisonsResult
                {
                    AlgorithName = searchAlgorithm.GetType().Name,
                    IsImplemented = false
                });
            }
        }

        ReportHelper.GenerateReport(_output, size, ranges, array, result);
    }
}
