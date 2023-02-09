using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "UnSave.BinarySearch")]
    public class UnSafeMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public UnSafeMonoboundBinarySearchTests(
            UnSafeMonoboundBinarySearch search,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(search, testDataProvider)
        {
        }
    }
}