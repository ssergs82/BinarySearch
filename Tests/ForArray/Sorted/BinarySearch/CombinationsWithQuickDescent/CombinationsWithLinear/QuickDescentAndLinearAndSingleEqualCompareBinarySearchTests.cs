using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndLinearAndSingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndLinearAndSingleEqualCompareBinarySearchTests(
            QuickDescentAndLinearAndSingleEqualCompareBinarySearch quickDescentAndLinearAndSingleEqualCompareBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndLinearAndSingleEqualCompareBinarySearch, testDataProvider)
        {
        }
    }
}