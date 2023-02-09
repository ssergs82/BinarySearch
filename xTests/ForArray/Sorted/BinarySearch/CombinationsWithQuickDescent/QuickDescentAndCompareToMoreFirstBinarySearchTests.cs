using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndCompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndCompareToMoreFirstBinarySearchTests(
            QuickDescentAndCompareToMoreFirstBinarySearch quickDescentAndCompareToMoreFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndCompareToMoreFirstBinarySearch, testDataProvider)
        {
        }
    }
}