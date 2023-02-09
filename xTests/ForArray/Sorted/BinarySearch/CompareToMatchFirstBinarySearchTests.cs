using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class CompareToMatchFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public CompareToMatchFirstBinarySearchTests(
            CompareToMatchFirstBinarySearch compareToMatchFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(compareToMatchFirstBinarySearch, testDataProvider)
        {
        }
    }
}