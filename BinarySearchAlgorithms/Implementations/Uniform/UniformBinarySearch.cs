using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementations.Uniform;

public class UniformBinarySearch : IUniformBinarySearch
{
    private static Dictionary<int, int[]> LookUpArraysDictionary = new Dictionary<int, int[]>();

    public static int[] GetDeltasArray(int length)
    {
        if (!LookUpArraysDictionary.ContainsKey(length))
        {
            int[] deltas = new int[(int)Math.Log2(length) + 2];

            ulong power = 1;
            int i = 0;

            do
            {
                ulong half = power;
                power <<= 1;
                deltas[i] = (int)(((ulong)length + half) / power);
                i++;
            } while (deltas[i - 1] != 0);

            LookUpArraysDictionary.Add(length, deltas);
        }

        return LookUpArraysDictionary[length];
    }

    public int Find(int[] array, int key) => Find(array, key, null);

    //https://en.wikipedia.org/wiki/Uniform_binary_search
    public int Find(int[] array, int key, int[] deltas = null)
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

        if (deltas == null)
        {
            deltas = GetDeltasArray(array.Length);
        }

        int middle = deltas[0] - 1;
        int pos = 1;
        int delta;

        do
        {
            //unsave code: could be improved by using pointer on items of deltas array
            //so, that line of code could be removed in unsave code
            delta = deltas[pos];

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

            pos++;
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

        int[] deltas = GetDeltasArray(array.Length);
        int middle = deltas[0] - 1;
        int pos = 1;
        int delta;

        do
        {
            delta = deltas[pos];

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

            pos++;
        } while (delta > 0);

        return -1;
    }
}
