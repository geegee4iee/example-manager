using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.Sorting
{
    public class QuickSelect
    {
        private static void swap(int[] arr, int first, int second)
        {
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        public static void quickSelect(int[] arr, int k)
        {
            quickSelect(arr, 0, arr.Length - 1, k);
        }

        public static void quickSelect(int[] arr, int lower, int upper, int k)
        {
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
            if (k < upper)
            {
                quickSelect(arr, start, upper - 1, k);
            }

            if (k > upper)
            {
                quickSelect(arr, upper + 1, stop, k);
            }
        }
    }

    [ExampleClass]
    class QuickSelectExample
    {
        static void Main()
        {
            int [] array = new int[] { 3, 4, 2, 1, 6, 5, 7, 8, 10, 9 };
            QuickSelect.quickSelect(array, 5);
            Console.Write("value at index 5 is : " + array[5]);
        }
    }
}
