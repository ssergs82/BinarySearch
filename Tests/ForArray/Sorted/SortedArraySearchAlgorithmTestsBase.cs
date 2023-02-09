using BinarySearchAlgorithms.Interfaces;
using TestData;
using TestData.NotFound;
using Xunit;

namespace Tests.ForArray.Sorted
{
    /// <summary>
    /// Tipical bugs:
    //— doesn't work with arrays size 0, 1, 2 
    //— ca't find first and last element
    //— doesn't work if element is not presented
    //— doesn't work properly if duplicates presented
    //— out of range issues
    //— middle index calculation overflow
    /// </summary>
    [Trait("Array.Sorted", "")]
    public abstract class SortedArraySearchAlgorithmTestsBase
    {
        protected IArraySearch _searchAlgorithm;
        protected ITestDataProvider<int> _testDataProvider;

        public SortedArraySearchAlgorithmTestsBase(
            IArraySearch searchAlgorithm,
            DefaultTestDataProvider<int> testDataProvider
        )
        {
            _searchAlgorithm = searchAlgorithm ?? throw new ArgumentNullException(nameof(searchAlgorithm));
            _testDataProvider = testDataProvider ?? throw new ArgumentNullException(nameof(testDataProvider));
        }

        [Theory, CombinatorialData]
        public void RandomData_SuccessSearchTest(
            [CombinatorialValues(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 99, 100, 101, 
                254, 255, 256, 383, 384, 385, 447, 448, 449, 511, 512, 513, 1000, 1001, 10000, 10001, 999999)] int size,
            [CombinatorialValues(
                new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { int.MinValue, int.MinValue }, new int[] { int.MaxValue, int.MaxValue },
                new int[] { 0, 1 }, new int[] { 0, 10 }, new int[] { 0, 50 }, new int[] { 0, 100 }, new int[] { 0, 1000 }, new int[] { 0, int.MaxValue },
                new int[] { -1, 0 }, new int[] { -10, 0 }, new int[] { -50, 0 }, new int[] { -100, 0 }, new int[] { -1000, 0 }, new int[] { int.MinValue, 0 },
                new int[] { -1, 1 }, new int[] { -10, 10 }, new int[] { -50, 50 }, new int[] { -100, 100 }, new int[] { -1000, 1000 }, new int[] { int.MinValue, int.MaxValue }
            )] int [] ranges
        )
        {
            int[] array = _testDataProvider.Get(
                new DataGenerationParameters
                {
                    Size = size,
                    Sorted = true,
                    RangeStart = ranges[0],
                    RangeEnd = ranges[1]
                }
            );

            foreach (var value in array)
            {
                var index = _searchAlgorithm.Find(array, value);
                //Assert.NotEqual(index, -1);
                Assert.NotEqual($"Searching for {value} - index {index} found", $"Searching for {value} - index -1 found");
                Assert.Equal(value, array[index]);
            }
        }

        [Theory]
        [InlineData((int.MaxValue / 2 ) + 5)]
        [InlineData((int.MaxValue / 2) + (int.MaxValue / 4))]
        public void MiddleIndexOverflow_WhenSearchLastElementInLargeArray_SuccessSearchTest(int size)
        {
            GC.Collect();

            var value = int.MaxValue;
            int[] array = new int[size];
            array[array.Length - 1] = value;

            var index = _searchAlgorithm.Find(array, value);
            Assert.NotEqual($"Searching for {value} - index {index} found", $"Searching for {value} - index -1 found");
            Assert.Equal(value, array[index]);
        }

        [Theory]
        [ClassData(typeof(NotFoundTestDataGenerator))]
        public void NotFoundTest(NotFoundTestData notFoundTestData)
        {
            foreach (var value in notFoundTestData.NotFoundValues)
            {
                var index = _searchAlgorithm.Find(notFoundTestData.SortedArray, value);
                Assert.Equal(-1, index);
            }
        }

        [Fact]
        public void ArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => _searchAlgorithm.Find(null, 0));
        }

        [Fact]
        public void EmptyArrayTest()
        {
            var index = _searchAlgorithm.Find(new int[0], 0);
            Assert.Equal(-1, index);
        }
    }
}
