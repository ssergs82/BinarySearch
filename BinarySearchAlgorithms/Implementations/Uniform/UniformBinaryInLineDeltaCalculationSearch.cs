using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementations.Uniform;

public class UniformBinaryInLineDeltaCalculation : IBinarySearch
{
    //https://en.wikipedia.org/wiki/Uniform_binary_search
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

        if (key < array[0] || key > array[array.Length - 1])
        {
            return -1;
        }

        int count = array.Length;
        int middle = count >> 1;
        int iterationNumber = 1;
        int delta;

        do
        {
            delta = count + (1 << iterationNumber) >> ++iterationNumber;

            if (key > array[middle])
            {
                middle += delta;
            }
            else if (key < array[middle])
            {
                middle -= delta;
            }
            else
            {
                return middle;
            }
        } while (delta > 0);

        return -1;
    }

    public int Find(int[] array, int key, ref int numberOfComparisons)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.Length == 0)
        {
            return -1;
        }

        if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[0], ref numberOfComparisons)
             || OperationCounting.IncreaseNumberOfComparisons(() => key > array[array.Length - 1], ref numberOfComparisons))
        {
            return -1;
        }

        int count = array.Length;
        int middle = count >> 1;
        int i = 1;
        int delta;

        do
        {
            delta = count + (1 << i) >> ++i;

            if (OperationCounting.IncreaseNumberOfComparisons(() => key > array[middle], ref numberOfComparisons))
            {
                middle += delta;
            }
            else if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[middle], ref numberOfComparisons))
            {
                middle -= delta;
            }
            else
            {
                return middle;
            }
        } while (delta > 0);

        return -1;
    }
}
