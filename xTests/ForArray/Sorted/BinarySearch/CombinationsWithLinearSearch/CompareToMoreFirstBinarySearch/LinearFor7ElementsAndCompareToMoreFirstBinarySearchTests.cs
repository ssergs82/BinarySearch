using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearFor7ElementsAndCompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearFor7ElementsAndCompareToMoreFirstBinarySearchTests(
            LinearFor7ElementsAndCompareToMoreFirstBinarySearch linearAndCompareToMoreFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndCompareToMoreFirstBinarySearch, testDataProvider)
        {
        }
    }
}