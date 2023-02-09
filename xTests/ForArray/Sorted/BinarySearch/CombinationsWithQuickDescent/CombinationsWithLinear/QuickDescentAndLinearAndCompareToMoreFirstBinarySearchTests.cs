using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndLinearAndCompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndLinearAndCompareToMoreFirstBinarySearchTests(
            QuickDescentAndLinearAndCompareToMoreFirstBinarySearch quickDescentAndLinearAndCompareToMoreFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndLinearAndCompareToMoreFirstBinarySearch, testDataProvider)
        {
        }
    }
}