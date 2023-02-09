using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class CompareToLessFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public CompareToLessFirstBinarySearchTests(
            CompareToLessFirstBinarySearch compareToLessFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(compareToLessFirstBinarySearch, testDataProvider)
        {
        }
    }
}