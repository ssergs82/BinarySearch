using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearFor6ElementsAndSingleEqualCompareBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearFor6ElementsAndSingleEqualCompareBinarySearchTests(
            LinearFor6ElementsAndSingleEqualCompareBinarySearch linearAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndBinarySearch, testDataProvider)
        {
        }
    }
}