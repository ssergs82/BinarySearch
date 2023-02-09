using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearWMCFor6ElementsAndSingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearWMCFor6ElementsAndSingleEqualCompareBinarySearchTests(
            LinearWMCFor6ElementsAndSingleEqualCompareBinarySearch linearWmcAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearWmcAndBinarySearch, testDataProvider)
        {
        }
    }
}