using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class QuickDescentAndSingleEqualCompareBinarySearch : IBinarySearch
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

        int low = 0, high = array.Length - 1, middle;

        if (key < array[0])
        {
            return -1;
        }

        while (key < array[high >> 1])
        {
            high >>= 1;
        }

        low = high >> 1;

        while (low < high)
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

        //low and high should be the same here
        if (key == array[low])
        {
            return low;
        }

        return -1;
    }

    public int Find(int[] array, int key, ref int numberOfComparisons)
    {
        if (array.Length == 0)
        {
            return -1;
        }

        int low = 0, high = array.Length - 1, middle;

        if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[0], ref numberOfComparisons))
        {
            return -1;
        }

        while (OperationCounting.IncreaseNumberOfComparisons(() => key < array[high >> 1], ref numberOfComparisons))
        {
            high >>= 1;
        }

        low = high >> 1;

        while (low < high)
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

        //low and high should be the same here
        if (OperationCounting.IncreaseNumberOfComparisons(() => key == array[low], ref numberOfComparisons))
        {
            return low;
        }

        return -1;
    }
}
