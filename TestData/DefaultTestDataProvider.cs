using System.Collections.Concurrent;
using TestData.Randomize;

namespace TestData;

public class DefaultTestDataProvider<T>: ITestDataProvider<T>
{
    //Cached arrays
    private readonly ConcurrentDictionary<DataGenerationParameters, T[]> _cache = new ConcurrentDictionary<DataGenerationParameters, T[]>();
    private readonly Random _rand = new CustomRandom();

    /// <summary>
    /// return an array of T (short, int, long)
    /// </summary>
    /// <param name="DataGenerationParameters">Array size, should be sorted, Range</param>
    /// <returns>Sorted or is not sorted Array with needed size and data range [start, end]</returns>
    public T[] Get(DataGenerationParameters dataGenerationParameters) 
    {
        int min = dataGenerationParameters.RangeStart != int.MinValue ? dataGenerationParameters.RangeStart : ITestDataProvider<T>.DefaultRangeStart;
        int max = dataGenerationParameters.RangeEnd != int.MaxValue ? dataGenerationParameters.RangeEnd : ITestDataProvider<T>.DefaultRangeEnd;

        dataGenerationParameters.RangeStart = min;
        dataGenerationParameters.RangeEnd = max;

        if (!dataGenerationParameters.CanHasDuplicates && ((double)max - min) < dataGenerationParameters.Size)
        {
            throw new ArgumentException($"Can't generate {dataGenerationParameters.Size} of unique data between {min} and {max}");
        }

        if (!_cache.ContainsKey(dataGenerationParameters))
        {
            T[] result = new T[dataGenerationParameters.Size];

            if (!dataGenerationParameters.CanHasDuplicates)
            {
                double step = ((double)max - min + 1) / dataGenerationParameters.Size;

                if (step <= 2.0)
                {
                    // in this case much more easy to generate ignore list and then use it when add data from min to max

                    int ignoreElementsCount = (int)((double)max - min + 1 - dataGenerationParameters.Size);
                    HashSet<int> ignoreSet = new HashSet<int>(ignoreElementsCount);

                    while (ignoreElementsCount > 0)
                    {
                        int elementToIgnore = _rand.Next(min, max) + _rand.Next(0, 2);
                        if (!ignoreSet.Contains(elementToIgnore))
                        {
                            ignoreSet.Add(elementToIgnore);
                            ignoreElementsCount--;
                        }
                    }

                    int value = min;
                    for (long pos = 0; pos < dataGenerationParameters.Size; value++)
                    {
                        if (!ignoreSet.Contains(value))
                        {
                            result[pos] = (T)Convert.ChangeType(value, typeof(T));
                            pos++;
                        }
                    }
                }
                else
                {
                    long pos;
                    HashSet<int> resultSet = new HashSet<int>(dataGenerationParameters.Size);
                    for (pos = 0; pos < dataGenerationParameters.Size; )
                    {
                        int newElement = _rand.Next(min, max) + _rand.Next(0, 2);
                        if (!resultSet.Contains(newElement))
                        {
                            resultSet.Add(newElement);
                            pos++;
                        }
                    }

                    pos = 0;
                    foreach (var element in resultSet)
                    {
                        result[pos] = (T)Convert.ChangeType(element, typeof(T));
                        pos++;
                    }
                }
            }
            else
            {
                for (long pos = 0; pos < dataGenerationParameters.Size; pos++)
                {
                    result[pos] = (T)Convert.ChangeType(_rand.Next(min, max) + _rand.Next(0, 2), typeof(T));
                }
            }

            if (dataGenerationParameters.Sorted)
            {
                Array.Sort<T>(result);
            }
            else
            {
                int swapIndex;
                T tmp;
                for (long pos = 0; pos < dataGenerationParameters.Size; pos++)
                {
                    swapIndex = _rand.Next(0, dataGenerationParameters.Size);

                    tmp = result[pos];
                    result[pos] = result[swapIndex];
                    result[swapIndex] = tmp;
                }
            }

            if (!_cache.ContainsKey(dataGenerationParameters))
            {
                _cache.TryAdd(dataGenerationParameters, result);
            }
        }

        return _cache[dataGenerationParameters];
    }
}
