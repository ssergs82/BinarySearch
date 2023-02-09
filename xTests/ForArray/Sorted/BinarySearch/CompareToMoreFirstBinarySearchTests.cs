using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class CompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public CompareToMoreFirstBinarySearchTests(
            CompareToMoreFirstBinarySearch �ompareToMoreFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(�ompareToMoreFirstBinarySearch, testDataProvider)

        {
        }
    }
}