using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearWMCFor4ElementsAndSingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearWMCFor4ElementsAndSingleEqualCompareBinarySearchTests(
            LinearWMCFor4ElementsAndSingleEqualCompareBinarySearch linearWmcAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearWmcAndBinarySearch, testDataProvider)
        {
        }
    }
}