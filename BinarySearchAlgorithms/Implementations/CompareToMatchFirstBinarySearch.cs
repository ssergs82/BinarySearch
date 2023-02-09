using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class CompareToMatchFirstBinarySearch : IBinarySearch
{
    public int Find(int[] array, int key)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        int low = 0, high = array.Length - 1, middle;

        while(low <= high)
        {
#if MIDDLEPOINTCALCULATIONBYCONVERSION
            middle = (int)(((uint)low + (uint)high) >> 1);
#else
            middle = low + ((high - low) >> 1);
#endif

            if (array[middle] == key)
            {
                return middle;
            }
            else if (key < array[middle])
            {
                high = middle - 1;
            }
            else
            {
                low = middle + 1;
            }
        }

        return -1;
    }
    
    public int Find(int[] array, int key, ref int numberOfComparisons)
    {
        int low = 0, high = array.Length - 1, middle;

        while(low <= high)
        {
#if MIDDLEPOINTCALCULATIONBYCONVERSION
            middle = (int)(((uint)low + (uint)high) >> 1);
#else
            middle = low + ((high - low) >> 1);
#endif

            if (OperationCounting.IncreaseNumberOfComparisons(() => array[middle] == key, ref numberOfComparisons))
            {
                return middle;
            }
            else if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[middle], ref numberOfComparisons))
            {
                high = middle - 1;
            }
            else
            {
                low = middle + 1;
            }
        }

        return -1;
    }
}
