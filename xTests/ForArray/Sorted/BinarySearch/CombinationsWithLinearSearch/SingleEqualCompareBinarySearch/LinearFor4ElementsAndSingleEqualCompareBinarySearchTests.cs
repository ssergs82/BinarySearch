using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearFor4ElementsAndSingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearFor4ElementsAndSingleEqualCompareBinarySearchTests(
            LinearFor4ElementsAndSingleEqualCompareBinarySearch linearAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndBinarySearch, testDataProvider)
        {
        }
    }
}