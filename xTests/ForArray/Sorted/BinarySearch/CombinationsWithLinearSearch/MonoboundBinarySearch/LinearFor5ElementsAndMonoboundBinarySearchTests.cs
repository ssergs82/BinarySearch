using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearFor5ElementsAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearFor5ElementsAndMonoboundBinarySearchTests(
            LinearFor5ElementsAndMonoboundBinarySearch linearAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndBinarySearch, testDataProvider)
        {
        }
    }
}