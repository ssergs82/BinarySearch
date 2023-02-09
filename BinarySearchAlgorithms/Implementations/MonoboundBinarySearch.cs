using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class MonoboundBinarySearch : IBinarySearch
{
    //https://github.com/scandum/binary_search
    public int Find(int[] array, int key)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        uint low = 0, middle, high;
        high = (uint)array.Length;

        if (high == 0)
        {
            return -1;
        }

        while (high > 1)
        {
            middle = high >> 1;

            if (key >= array[low + middle])
            {
                low += middle;
            }
            high -= middle;
        }

        if (key == array[low])
        {
            return (int)low;
        }

        return -1;
    }

    public int Find(int[] array, int key, ref int numberOfComparisons)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        uint low = 0, middle, high;
        high = (uint)array.Length;

        if (high == 0)
        {
            return -1;
        }

        while (high > 1)
        {
            middle = high >> 1;

            if (OperationCounting.IncreaseNumberOfComparisons(() => key >= array[low + middle], ref numberOfComparisons))
            {
                low += middle;
            }
            high -= middle;
        }

        if (OperationCounting.IncreaseNumberOfComparisons(() => key == array[low], ref numberOfComparisons))
        {
            return (int)low;
        }

        return -1;
    }
}