using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class QuickDescentAndCompareToMoreFirstBinarySearch : IBinarySearch
{
    public int Find(int[] array, int key)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        
        if (array.Length == 0)
        {
            return -1;
        }

        if (key < array[0])
        {
            return -1;
        }

        int high = array.Length - 1, middle;
        while (key < array[high >> 1])
        {
            high >>= 1;
        }

        int low = high >> 1;

        while (low <= high)
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
            else if (key < array[middle])
            {
                high = middle - 1;
            }
            else
            {
                return middle;
            }
        }

        return -1;
    }

    public int Find(int[] array, int key, ref int numberOfComparisons)
    {
        if (array.Length == 0)
        {
            return -1;
        }

        if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[0], ref numberOfComparisons))
        {
            return -1;
        }

        int high = array.Length - 1, middle;
        while (OperationCounting.IncreaseNumberOfComparisons(() => key < array[high >> 1], ref numberOfComparisons))
        {
            high >>= 1;
        }

        int low = high >> 1;

        while (low <= high)
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
            else if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[middle], ref numberOfComparisons))
            {
                high = middle - 1;
            }
            else
            {
                return middle;
            }
        }

        return -1;
    }
}
