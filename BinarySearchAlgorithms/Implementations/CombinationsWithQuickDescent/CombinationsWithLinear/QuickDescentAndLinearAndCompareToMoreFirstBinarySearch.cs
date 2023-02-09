﻿using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class QuickDescentAndLinearAndCompareToMoreFirstBinarySearch : IBinarySearch
{
    private readonly int _optimizedSkipElementsCount;


    public QuickDescentAndLinearAndCompareToMoreFirstBinarySearch()
    {
        //linear search will be used for 3 elements array size
        // 3 = _optimizedSkipElementsCount + 2
        //+1 from count element in range = (high-low) + 1
        //+1 because of using < but not <=  (low + _skipElementsCount < high)
        _optimizedSkipElementsCount = 1;
    }

    public QuickDescentAndLinearAndCompareToMoreFirstBinarySearch(int countElementsForLinearSearch)
    {
        _optimizedSkipElementsCount = countElementsForLinearSearch - 2;
    }

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
            else if(key < array[middle])
            {
                high = middle - 1;
            }
            else
            {
                return middle;
            }
        }

        //linear search for range size less or equal to 
        //CountElementsForLinearSearch=_optimizedSkipElementsCount + 2
        while (low <= high)
        {
            if (key == array[low])
            {
                return low;
            }

            low++;
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
            else if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[middle], ref numberOfComparisons))
            {
                high = middle - 1;
            }
            else
            {
                return middle;
            }
        }

        //linear search for range size less or equal to 
        //CountElementsForLinearSearch=_optimizedSkipElementsCount + 2
        while (low <= high)
        {
            if (OperationCounting.IncreaseNumberOfComparisons(() => key == array[low], ref numberOfComparisons))
            {
                return low;
            }

            low++;
        }

        return -1;
    }
}
