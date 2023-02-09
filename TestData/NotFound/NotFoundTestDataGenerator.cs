using System.Collections;

namespace TestData.NotFound;

public class NotFoundTestDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                //out of array range
                new NotFoundTestData
                {
                    SortedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 },
                    NotFoundValues = new int[] { -1, 0, 31, 100 }
                }
            },
            new object[]
            {
                //second and item before last
                new NotFoundTestData
                {
                    SortedArray = new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 30 },
                    NotFoundValues = new int[] { 2, 29 }
                }
            },
            new object[]
            {
                //3d  and item prev prev last
                new NotFoundTestData
                {
                    SortedArray = new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 29, 30 },
                    NotFoundValues = new int[] { 3, 28 }
                }
            },
            new object[]
            {
                //between
                new NotFoundTestData
                {
                    SortedArray = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58 },
                    NotFoundValues = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59 }
                }
            },
            new object[]
            {
                //even count
                new NotFoundTestData
                {
                    SortedArray = new int[] { -10, -5, 0, 3, 4, 10 },
                    NotFoundValues = new int[] { -20, -11, -9, -8, -7, -6, -4, -3, -2, -1, 1, 2, 5, 6, 7, 8, 9, 11, 12, 20 }
                }
            },
            new object[]
            {
                //not even count
                new NotFoundTestData
                {
                    SortedArray = new int[] { -5, -3, -1, 1, 3, 5, 7, 9, 11 },
                    NotFoundValues = new int[] { -100, -6, -4, -2, 0, 2, 4, 6, 8, 10, 100 }
                }
            },
            new object[]
            {
                //single item
                new NotFoundTestData
                {
                    SortedArray = new int[] { 0 },
                    NotFoundValues = new int[] { -1, 1 }
                }
            },
            new object[]
            {
                //2 items
                new NotFoundTestData
                {
                    SortedArray = new int[] { 0, 1 },
                    NotFoundValues = new int[] { -1, 2 }
                }
            },
            new object[]
            {
                //min and max values
                new NotFoundTestData
                {
                    SortedArray = new int[] { int.MinValue, int.MaxValue },
                    NotFoundValues = new int[] { int.MinValue + 1, int.MaxValue - 1, 0, -1, 1, 500 }
                }
            }
        };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
