using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class MonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public MonoboundBinarySearchTests(
            MonoboundBinarySearch monoboundBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(monoboundBinarySearch, testDataProvider)

        {
        }
    }
}