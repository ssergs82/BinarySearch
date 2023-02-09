using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndSingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndSingleEqualCompareBinarySearchTests(
            QuickDescentAndSingleEqualCompareBinarySearch quickDescentAndSingleEqualCompareBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndSingleEqualCompareBinarySearch, testDataProvider)
        {
        }
    }
}