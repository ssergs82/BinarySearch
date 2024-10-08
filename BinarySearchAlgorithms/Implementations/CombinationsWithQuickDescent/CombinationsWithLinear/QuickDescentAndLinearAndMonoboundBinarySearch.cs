﻿using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

public class QuickDescentAndLinearAndMonoboundBinarySearch : IBinarySearch
{
    private readonly int _countElementsForLinearSearch;

    public QuickDescentAndLinearAndMonoboundBinarySearch()
    {
        _countElementsForLinearSearch = 3;
    }

    public QuickDescentAndLinearAndMonoboundBinarySearch(int countElementsForLinearSearch)
    {
        _countElementsForLinearSearch = countElementsForLinearSearch;
    }

    //https://github.com/scandum/binary_search
    //tripletapped_binary_search
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

        if (key < array[0])
        {
            return -1;
        }

        while (key < array[high >> 1])
        {
            high >>= 1;
        }

        low = high >> 1;
        high -= low;

        while (high > _countElementsForLinearSearch)
        {
            middle = high >> 1;

            if (key >= array[low + middle])
            {
                low += middle;
            }

            high -= middle;
        }

        while (high-- > 0)
        {
            if (key == array[low + high])
            {
                return (int)(low + high);
            }
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

        if (OperationCounting.IncreaseNumberOfComparisons(() => key < array[0], ref numberOfComparisons))
        {
            return -1;
        }

        while (OperationCounting.IncreaseNumberOfComparisons(() => key < array[high >> 1], ref numberOfComparisons))
        {
            high >>= 1;
        }

        low = high >> 1;
        high -= low;

        while (high > _countElementsForLinearSearch)
        {
            middle = high >> 1;

            if (OperationCounting.IncreaseNumberOfComparisons(() => key >= array[low + middle], ref numberOfComparisons))
            {
                low += middle;
            }

            high -= middle;
        }

        while (high-- > 0)
        {
            if (OperationCounting.IncreaseNumberOfComparisons(() => key == array[low + high], ref numberOfComparisons))
            {
                return (int)(low + high);
            }
        }

        return -1;
    }
}