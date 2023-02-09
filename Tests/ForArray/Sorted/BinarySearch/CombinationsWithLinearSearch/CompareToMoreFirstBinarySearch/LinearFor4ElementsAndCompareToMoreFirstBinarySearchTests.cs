using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearFor4ElementsAndCompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearFor4ElementsAndCompareToMoreFirstBinarySearchTests(
            LinearFor4ElementsAndCompareToMoreFirstBinarySearch linearAndCompareToMoreFirstBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndCompareToMoreFirstBinarySearch, testDataProvider)
        {
        }
    }
}