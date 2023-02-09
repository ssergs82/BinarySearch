using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LengthAdaptiveQuickDescentAndLinearAndCompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LengthAdaptiveQuickDescentAndLinearAndCompareToMoreFirstBinarySearchTests(
            LengthAdaptiveQuickDescentAndLinearAndCompareToMoreFirstBinarySearch binarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(binarySearch, testDataProvider)
        {
        }
    }
}