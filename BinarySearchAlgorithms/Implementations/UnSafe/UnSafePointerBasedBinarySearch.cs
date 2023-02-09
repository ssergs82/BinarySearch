using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class UnSafePointerBasedBinarySearch : IBinarySearch
{
    private readonly int _optimizedSkipElementsCount = 25;

    //https://github.com/gcc-mirror/gcc/blob/master/libiberty/bsearch.c
    //set _optimizedSkipElementsCount to 0 to have almost the same algorithm
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
                int high = array.Length;
                int* pBase = pFirst;

                while (high > _optimizedSkipElementsCount)
                {
                    int* pCurrent = pBase + (high >> 1);

                    if (key >= *pCurrent) /* key > p: move right */
                    {
                        if (*pCurrent == key)
                        {
                            return (int)(pCurrent - pFirst);
                        }
                        pBase = pCurrent + 1;
                        high--;
                    }

                    high >>= 1;
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
                int high = array.Length;
                int* pBase = pFirst;

                while (high > _optimizedSkipElementsCount)
                {
                    int* pCurrent = pBase + (high >> 1);

                    if (OperationCounting.IncreaseNumberOfComparisons(() => key >= *pCurrent, ref numberOfComparisons)) /* key > p: move right */
                    {
                        if (OperationCounting.IncreaseNumberOfComparisons(() => *pCurrent == key, ref numberOfComparisons))
                        {
                            return (int)(pCurrent - pFirst);
                        }
                        pBase = pCurrent + 1;
                        high--;
                    }

                    high >>= 1;
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
