﻿using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Tools;

namespace BinarySearchAlgorithms.Implementation;

//monobound_quaternary_search
public class QuickDescentAndLinearAndMonoboundQuaternaryWith2StepsPerCycleBinarySearch : IBinarySearch
{
    private readonly int _countElementsForLinearSearch = 4;
    private readonly int _countElementsForQuaternarySearch = 256;

    public QuickDescentAndLinearAndMonoboundQuaternaryWith2StepsPerCycleBinarySearch()
    {
    }

    public QuickDescentAndLinearAndMonoboundQuaternaryWith2StepsPerCycleBinarySearch(int countElementsForLinearSearch)
    {
        _countElementsForLinearSearch = countElementsForLinearSearch;
    }

    public QuickDescentAndLinearAndMonoboundQuaternaryWith2StepsPerCycleBinarySearch(int countElementsForLinearSearch, int countElementsForQuaternarySearch)
    {
        _countElementsForLinearSearch = countElementsForLinearSearch;
        _countElementsForQuaternarySearch = countElementsForQuaternarySearch;
    }

    //https://github.com/scandum/binary_search
    //monobound_quaternary_search
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

        while (high >= _countElementsForQuaternarySearch)
        {
            middle = high >> 2;
            high -= middle * 3;

            if (key < array[low + (middle << 1)])
            {
                if (key >= array[low + middle])
                {
                    low += middle;
                }
            }
            else
            {
                low += middle << 1;

                if (key >= array[low + middle])
                {
                    low += middle;
                }
            }

            middle = high >> 2;
            high -= middle * 3;

            if (key < array[low + (middle << 1)])
            {
                if (key >= array[low + middle])
                {
                    low += middle;
                }
            }
            else
            {
                low += middle << 1;

                if (key >= array[low + middle])
                {
                    low += middle;
                }
            }
        }

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

        while (high >= _countElementsForQuaternarySearch)
        {
            middle = high >> 2;
            high -= middle * 3;

            if (key < array[low + (middle << 1)])
            {
                if (OperationCounting.IncreaseNumberOfComparisons(() => key >= array[low + middle], ref numberOfComparisons))
                {
                    low += middle;
                }
            }
            else
            {
                low += middle << 1;

                if (OperationCounting.IncreaseNumberOfComparisons(() => key >= array[low + middle], ref numberOfComparisons))
                {
                    low += middle;
                }
            }

            middle = high >> 2;
            high -= middle * 3;

            if (key < array[low + (middle << 1)])
            {
                if (OperationCounting.IncreaseNumberOfComparisons(() => key >= array[low + middle], ref numberOfComparisons))
                {
                    low += middle;
                }
            }
            else
            {
                low += middle << 1;

                if (OperationCounting.IncreaseNumberOfComparisons(() => key >= array[low + middle], ref numberOfComparisons))
                {
                    low += middle;
                }
            }
        }

        while (high > _countElementsForLinearSearch)
        {
            middle = high >> 1;

            if (OperationCounting.IncreaseNumberOfComparisons(() => key >= array[low + middle], ref numberOfComparisons))
            {
                low += middle;
            }

            high -= middle;

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