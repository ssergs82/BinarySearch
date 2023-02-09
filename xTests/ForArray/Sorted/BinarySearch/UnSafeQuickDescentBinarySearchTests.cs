using Tests.ForArray.Sorted;
using TestData;

using BinarySearchAlgorithms.Implementation;

namespace Tests
{
    [Trait("Array.Sorted", "UnSave.BinarySearch")]
    public class UnSafeQuickDescentBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public UnSafeQuickDescentBinarySearchTests(
            UnSafeQuickDescentBinarySearch search,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(search, testDataProvider)
        {
        }
    }
}