﻿using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.Sorting
{
    public class QuickSort
    {
        private int[] arr;

        public QuickSort(int[] array)
        {
            arr = array;
        }

        public virtual void sort()
        {
            int size = arr.Length;
            quickSortUtil(arr, 0, size - 1);
        }

        private void swap(int[] arr, int first, int second)
        {
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        private void quickSortUtil(int[] arr, int lower, int upper)
        {
            Console.Write("Sorting array ");
            for (int i = lower; i <= upper; i++)
            {
                Console.Write($"[{arr[i]}] ");
            }

            Console.WriteLine();

            if (upper <= lower)
            {
                return;
            }
            int pivot = arr[lower];
            int start = lower;
            int stop = upper;

 

            while (lower < upper)
            {
                while (arr[lower] <= pivot && lower < upper)
                {
                    lower++;
                }

                while (arr[upper] > pivot && lower <= upper)
                {
                    upper--;
                }

                if (lower < upper)
                {
                    swap(arr, upper, lower);
                }
            }

            swap(arr, upper, start); //upper is the pivot position
            quickSortUtil(arr, start, upper - 1); //pivot -1 is the upper for left sub array.
            quickSortUtil(arr, upper + 1, stop); // pivot + 1 is the lower for right sub array.
        }
    }

    [ExampleClass]
    public class QuickSortExample
    {
        static void Main()
        {
            int[] array = new int[] { 3, 4, 2, 1, 6, 5, 7, 8, 1, 1 };
            QuickSort m = new QuickSort(array);
            m.sort();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
}
}
