using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearWMCFor5ElementsAndSingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearWMCFor5ElementsAndSingleEqualCompareBinarySearchTests(
            LinearWMCFor5ElementsAndSingleEqualCompareBinarySearch linearWmcAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearWmcAndBinarySearch, testDataProvider)
        {
        }
    }
}