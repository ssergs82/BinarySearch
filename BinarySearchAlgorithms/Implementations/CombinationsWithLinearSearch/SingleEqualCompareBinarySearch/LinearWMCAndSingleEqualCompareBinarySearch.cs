using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class LinearWMCAndSingleEqualCompareBinarySearch : IBinarySearch
{
    private readonly int _optimizedSkipElementsCount;

    public LinearWMCAndSingleEqualCompareBinarySearch()
    {
        //linear search will be used for 3 elements array size
        // 3 = _optimizedSkipElementsCount + 2
        //+1 from count element in range = (high-low) + 1
        //+1 because of using < but not <=  (low + _skipElementsCount < high)
        _optimizedSkipElementsCount = 1;
    }

    public LinearWMCAndSingleEqualCompareBinarySearch(int countElementsForLinearSearch)
    {
        _optimizedSkipElementsCount = countElementsForLinearSearch - 2;
    }

    public int Find(int[] array, int key)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        int low = 0, high = array.Length - 1, middle;

        while (low + _optimizedSkipElementsCount < high)
        {
#if MIDDLEPOINTCALCULATIONBYCONVERSION
            middle = (int)(((uint)low + (uint)high) >> 1);
#else
            middle = low + ((high - low) >> 1);
#endif

            if (key > array[middle])
            {
                low = middle + 1;
            }
            else
            {
                high = middle;
            }
        }

        //linear search for range size less or equal to 
        //CountElementsForLinearSearch=_optimizedSkipElementsCount + 2
        while (low <= high)
        {
            if (key <= array[low])
            {
                if (key == array[low])
                {
                    return low;
                }

                break;
            }

            low++;
        }

        return -1;
    }

    public int Find(int[] array, int key, ref int numberOfComparisons)
    {
        int low = 0, high = array.Length - 1, middle;

        while (low + _optimizedSkipElementsCount < high)
        {
#if MIDDLEPOINTCALCULATIONBYCONVERSION
            middle = (int)(((uint)low + (uint)high) >> 1);
#else
            middle = low + ((high - low) >> 1);
#endif

            if (OperationCounting.IncreaseNumberOfComparisons(() => key > array[middle], ref numberOfComparisons))
            {
                low = middle + 1;
            }
            else
            {
                high = middle;
            }
        }

        //linear search for range size less or equal to 
        //CountElementsForLinearSearch=_optimizedSkipElementsCount + 2
        while (low <= high)
        {
            if (OperationCounting.IncreaseNumberOfComparisons(() => key <= array[low], ref numberOfComparisons))
            {
                if (OperationCounting.IncreaseNumberOfComparisons(() => key == array[low], ref numberOfComparisons))
                {
                    return low;
                }

                break;
            }

            low++;
        }

        return -1;
    }
}
