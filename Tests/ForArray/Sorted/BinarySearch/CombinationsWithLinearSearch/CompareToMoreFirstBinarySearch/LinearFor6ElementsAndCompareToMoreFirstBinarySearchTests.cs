using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearFor6ElementsAndCompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearFor6ElementsAndCompareToMoreFirstBinarySearchTests(
            LinearFor6ElementsAndCompareToMoreFirstBinarySearch linearAndCompareToMoreFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndCompareToMoreFirstBinarySearch, testDataProvider)
        {
        }
    }
}