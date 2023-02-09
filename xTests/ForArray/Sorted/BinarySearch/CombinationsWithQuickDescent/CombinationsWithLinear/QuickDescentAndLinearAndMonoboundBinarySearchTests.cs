using BinarySearchAlgorithms.Implementation;
using Tests.ForArray.Sorted;
using TestData;


namespace Tests
{
    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndLinearAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndLinearAndMonoboundBinarySearchTests(
            QuickDescentAndLinearAndMonoboundBinarySearch quickDescentAndLineaAndMonoboundBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndLineaAndMonoboundBinarySearch, testDataProvider)
        {
        }
    }

    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndLinearFor4ElementsAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndLinearFor4ElementsAndMonoboundBinarySearchTests(
            QuickDescentAndLinearFor4ElementsAndMonoboundBinarySearch quickDescentAndLineaAndMonoboundBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndLineaAndMonoboundBinarySearch, testDataProvider)
        {
        }
    }

    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndLinearFor5ElementsAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndLinearFor5ElementsAndMonoboundBinarySearchTests(
            QuickDescentAndLinearFor5ElementsAndMonoboundBinarySearch quickDescentAndLineaAndMonoboundBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndLineaAndMonoboundBinarySearch, testDataProvider)
        {
        }
    }

    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndLinearFor20ElementsAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndLinearFor20ElementsAndMonoboundBinarySearchTests(
            QuickDescentAndLinearFor20ElementsAndMonoboundBinarySearch quickDescentAndLineaAndMonoboundBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndLineaAndMonoboundBinarySearch, testDataProvider)
        {
        }
    }

    [Trait("Array.Sorted", "BinarySearch")]
    public class QuickDescentAndLinearFor30ElementsAndMonoboundBinarySearchTests : SortedArraySearchAlgorithmTestsBase
    {
        public QuickDescentAndLinearFor30ElementsAndMonoboundBinarySearchTests(
            QuickDescentAndLinearFor30ElementsAndMonoboundBinarySearch quickDescentAndLineaAndMonoboundBinarySearch,
            DefaultTestDataProvider<int> testDataProvider
        ) : base(quickDescentAndLineaAndMonoboundBinarySearch, testDataProvider)
        {
        }
    }
}