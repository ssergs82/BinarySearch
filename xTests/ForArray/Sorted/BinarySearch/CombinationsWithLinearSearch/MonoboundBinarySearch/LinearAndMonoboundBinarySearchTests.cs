using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearAndMonoboundBinarySearchTests(
            LinearAndMonoboundBinarySearch linearAndMonoboundBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndMonoboundBinarySearch, testDataProvider)

        {
        }
    }
}