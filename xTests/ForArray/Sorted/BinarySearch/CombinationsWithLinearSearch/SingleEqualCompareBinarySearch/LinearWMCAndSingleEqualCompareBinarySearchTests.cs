using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearWMCAndSingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearWMCAndSingleEqualCompareBinarySearchTests(
            LinearWMCAndSingleEqualCompareBinarySearch linearWlcAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearWlcAndBinarySearch, testDataProvider)
        {
        }
    }
}