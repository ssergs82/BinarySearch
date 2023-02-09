using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;
using BinarySearchAlgorithms.Implementations.Uniform;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class UniformBinaryInLineDeltaCalculationTests : SortedArraySearchAlgorithmTestsBase
    {
        public UniformBinaryInLineDeltaCalculationTests(
            UniformBinaryInLineDeltaCalculation uniformBinaryInLineDeltaCalculation,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(uniformBinaryInLineDeltaCalculation, testDataProvider)
        {
        }
    }
}