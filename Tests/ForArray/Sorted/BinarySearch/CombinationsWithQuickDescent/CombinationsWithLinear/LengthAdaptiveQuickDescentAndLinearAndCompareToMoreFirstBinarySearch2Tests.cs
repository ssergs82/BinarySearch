using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LengthAdaptiveQuickDescentAndLinearAndCompareToMoreFirstBinarySearch2Tests : SortedArraySearchAlgorithmTestsBase
    {
        public LengthAdaptiveQuickDescentAndLinearAndCompareToMoreFirstBinarySearch2Tests(
            LengthAdaptiveQuickDescentAndLinearAndCompareToMoreFirstBinarySearch2 binarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(binarySearch, testDataProvider)
        {
        }
    }
}