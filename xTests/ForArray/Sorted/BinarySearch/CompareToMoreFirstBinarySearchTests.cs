using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class CompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public CompareToMoreFirstBinarySearchTests(
            CompareToMoreFirstBinarySearch ñompareToMoreFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(ñompareToMoreFirstBinarySearch, testDataProvider)

        {
        }
    }
}