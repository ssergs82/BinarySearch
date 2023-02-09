using BenchmarkDotNet.Attributes;
using BinarySearchAlgorithms.Implementations.Uniform;
using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Services;
using TestData;

namespace BinarySearchBenchmarks.ForArray
{
    [Config(typeof(Config))]
    public class SearchAlgorithmsForSortedArrayBenchmarksBase
    {
        protected readonly ITestDataProvider<int> _testDataProvider;
        protected readonly List<IArraySearch> _searchAlgorithms;
        protected readonly List<IUniformBinarySearch> _uniformBinarySearches;

        protected readonly int[] _arrayToTest;
        protected readonly int _size;

        public SearchAlgorithmsForSortedArrayBenchmarksBase(ITestDataProvider<int> testDataProvider, int size)
        {
            _testDataProvider = testDataProvider ?? throw new ArgumentNullException(nameof(testDataProvider));

            SearchAlgorithmsProvider searchAlgorithmsProvider = new SearchAlgorithmsProvider();
            //_searchAlgorithms = new List<IArraySearch>() { new QuickDescentBinarySearch() };
            _searchAlgorithms = searchAlgorithmsProvider
                .GetSearchAlgorithms<IBinarySearch>()
                .Select(x => x as IArraySearch)
                .ToList();

            _uniformBinarySearches = searchAlgorithmsProvider
                .GetSearchAlgorithms<IUniformBinarySearch>()
                .ToList();

            _size = size;
            int[] ranges = new int[] { int.MinValue, int.MaxValue };
            _arrayToTest = _testDataProvider.Get(
                new DataGenerationParameters
                {
                    Size = size,
                    Sorted = true,
                    GrowUpStep = 1,
                    RangeStart = ranges[0],
                    RangeEnd = ranges[1],
                    CanHasDuplicates = false
                }
            );
        }

        public IEnumerable<object[]> FindArguments()
        {
            foreach (var searchAlgorithm in _searchAlgorithms)
            {
                yield return new object[] { _size, searchAlgorithm, searchAlgorithm.GetType().Name };
            }
        }

        public IEnumerable<object[]> FindUniformBinarySearchArguments()
        {
            foreach (var searchAlgorithm in _uniformBinarySearches)
            {
                yield return new object[] { _size, searchAlgorithm, searchAlgorithm.GetType().Name };
            }
        }

        public IEnumerable<object[]> DefaultSearchFindArguments()
        {
            yield return new object[] { _size, null, "Array.BinarySearch" };
        }

        [Benchmark]
        [ArgumentsSource(nameof(FindArguments))]
        public void Find(int size, IArraySearch searchAlgorithm, string searchAlgorithmName)
        {
            foreach (var item in _arrayToTest)
            {
                searchAlgorithm.Find(_arrayToTest, item);
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(FindUniformBinarySearchArguments))]
        public void Find(int size, IUniformBinarySearch searchAlgorithm, string searchAlgorithmName)
        {
            int length = _arrayToTest.Length;
            int[] deltas = UniformBinarySearch.GetDeltasArray(length);
            foreach (var item in _arrayToTest)
            {
                searchAlgorithm.Find(_arrayToTest, item, deltas);
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(DefaultSearchFindArguments))]
        public void DefaultFind(int size, IArraySearch searchAlgorithm, string searchAlgorithmName)
        {
            foreach (var item in _arrayToTest)
            {
                Array.BinarySearch(_arrayToTest, 0, size, item);
            }
        }
    }
}
