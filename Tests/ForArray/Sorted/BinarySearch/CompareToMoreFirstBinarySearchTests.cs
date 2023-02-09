using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;
using Xunit;

namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class CompareToMoreFirstBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public CompareToMoreFirstBinarySearchTests(
        ) : base(new CompareToMoreFirstBinarySearch(), new DefaultTestDataProvider<int>())
        {
        }
    }
}