using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class UnSafeQuickDescentBinarySearch : IBinarySearch
{
    private readonly int _optimizedSkipElementsCount = 25;

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

        unsafe
        {
            fixed (int* pFirst = &array[0])
            {
                int high = array.Length - 1;
                int* pCurrent = pFirst;
                int half;

                while (high > _optimizedSkipElementsCount)
                {
                    half = high >> 1;
                    while (key < pCurrent[half]) //potential issue for not presented item that less than *pCurrent - need check half!=0?
                    {
                        high = half;
                        half >>= 1;
                    }
                    pCurrent += half;//reindexing array
                    high -= half;
                }

                while (high >= 0)
                {
                    if (pCurrent[high] == key)
                    {
                        return (int)(pCurrent - pFirst) + high;
                    }

                    high--;
                }

                return -1;
            }
        }
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

        if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[0], ref numberOfComparisons))
        {
            return -1;
        }

        unsafe
        {
            fixed (int* pFirst = &array[0])
            {
                int high = array.Length - 1;
                int* pCurrent = pFirst;
                int half;

                while (high > _optimizedSkipElementsCount)
                {
                    half = high >> 1;
                    while (OperationCounting.IncreaseNumberOfComparisons(() => key < pCurrent[half], ref numberOfComparisons)) //potential issue for not presented item that less than *pCurrent - need check half!=0?
                    {
                        high = half;
                        half >>= 1;
                    }
                    pCurrent += half;//reindexing array
                    high -= half;
                }

                while (high >= 0)
                {
                    if (OperationCounting.IncreaseNumberOfComparisons(() => pCurrent[high] == key, ref numberOfComparisons))
                    {
                        return (int)(pCurrent - pFirst) + high;
                    }

                    high--;
                }

                return -1;
            }
        }
    }
}
