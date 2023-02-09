using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class UnSafeMonoboundBinarySearch : IBinarySearch
{
    private readonly int _optimizedSkipElementsCount = 25;

    //https://github.com/scandum/binary_search
    //optimized
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

        unsafe
        {
            fixed (int* pFirst = &array[0])
            {
                uint high = (uint)array.Length;
                uint middle;
                int* pBase = pFirst;

                while (high > _optimizedSkipElementsCount)
                {
                    middle = high >> 1;
                    int* pCurrent = pBase + middle;

                    //if (*pCurrent == key)
                    //{
                    //    return (int)(pCurrent - pFirst);
                    //}

                    if (key >= *pCurrent)
                    {
                        if (*pCurrent == key)
                        {
                            return (int)(pCurrent - pFirst);
                        }
                        pBase = pCurrent;
                    }

                    high -= middle;
                }

                while (high != 0)
                {
                    if (*pBase == key)
                    {
                        return (int)(pBase - pFirst);
                    }
                    pBase++;
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

        unsafe
        {
            fixed (int* pFirst = &array[0])
            {
                uint high = (uint)array.Length;
                uint middle;
                int* pBase = pFirst;

                while (high > _optimizedSkipElementsCount)
                {
                    middle = high >> 1;
                    int* pCurrent = pBase + middle;

                    //if (*pCurrent == key)
                    //{
                    //    return (int)(pCurrent - pFirst);
                    //}

                    if (OperationCounting.IncreaseNumberOfComparisons(() => key >= *pCurrent, ref numberOfComparisons))
                    {
                        if (OperationCounting.IncreaseNumberOfComparisons(() => *pCurrent == key, ref numberOfComparisons))
                        {
                            return (int)(pCurrent - pFirst);
                        }
                        pBase = pCurrent;
                    }

                    high -= middle;
                }

                while (high != 0)
                {
                    if (OperationCounting.IncreaseNumberOfComparisons(() => *pBase == key, ref numberOfComparisons))
                    {
                        return (int)(pBase - pFirst);
                    }
                    pBase++;
                    high--;
                }

                return -1;
            }
        }
    }
}
