using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;

using BinarySearchAlgorithms.Implementations.Uniform;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class UniformBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public UniformBinarySearchTests(
            UniformBinarySearch uniformBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(uniformBinarySearch, testDataProvider)
        {
        }
    }
}