using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearAndCompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearAndCompareToMoreFirstBinarySearchTests(
            LinearAndCompareToMoreFirstBinarySearch linearAndCompareToMoreFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndCompareToMoreFirstBinarySearch, testDataProvider)
        {
        }
    }
}