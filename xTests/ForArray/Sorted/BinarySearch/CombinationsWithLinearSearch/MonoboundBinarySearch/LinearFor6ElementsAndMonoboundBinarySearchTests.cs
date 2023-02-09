using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearFor6ElementsAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearFor6ElementsAndMonoboundBinarySearchTests(
            LinearFor6ElementsAndMonoboundBinarySearch linearAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndBinarySearch, testDataProvider)
        {
        }
    }
}