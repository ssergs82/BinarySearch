using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class LinearFor4ElementsAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public LinearFor4ElementsAndMonoboundBinarySearchTests(
            LinearFor4ElementsAndMonoboundBinarySearch linearAndBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(linearAndBinarySearch, testDataProvider)
        {
        }
    }
}