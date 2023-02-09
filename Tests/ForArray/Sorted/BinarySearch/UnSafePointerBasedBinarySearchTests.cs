using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "UnSave.BinarySearch")]
    public class UnSafePointerBasedBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public UnSafePointerBasedBinarySearchTests(
            UnSafePointerBasedBinarySearch search,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(search, testDataProvider)
        {
        }
    }
}