using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class SingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public SingleEqualCompareBinarySearchTests(
            SingleEqualCompareBinarySearch singleEqualCompareBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(singleEqualCompareBinarySearch, testDataProvider)
        {
        }
    }
}