using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.BigSortingCase
{
    [ExampleClass]
    class BigSorting
    {
        static void sort(string[] arr)
        {
            int size = arr.Length;
            quickSortUtil(arr, 0, size - 1);
        }

        static void swap(string[] arr, int first, int second)
        {
            string temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        static void quickSortUtil(string[] arr, int lower, int upper)
        {
            if (upper <= lower)
            {
                return;
            }
            string pivot = arr[lower];
            int start = lower;
            int stop = upper;



            while (lower < upper)
            {
                int result = compare(pivot, arr[lower]);
                while (result >= 0 && lower < upper)
                {
                    lower++;
                    result = compare(pivot, arr[lower]);
                }

                result = compare(arr[upper], pivot);

                while (result > 0 && lower <= upper)
                {
                    upper--;
                    result = compare(arr[upper], pivot);
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

        static int compare(string a, string b)
        {
            int lengthA = a.Length;
            int lengthB = b.Length;

            if (lengthA > lengthB)
            {
                return 1;
            } else if (lengthB > lengthA)
            {
                return -1;
            }

            int minLength = lengthA;

            for(int i = 0; i < minLength; i++)
            {
                int compare = a[i].CompareTo(b[i]);

                if (compare != 0)
                {
                    return compare;
                }
            }

            return 0;
        }

        static void  Main()
        {
            var lines = File.ReadAllLines($"./BigSortingCase/input03.txt");
            int size = Convert.ToInt32(lines[0]);

            string[] unsorted = new string[size];
            for (int i = 0; i < size; i++)
            {
                unsorted[i] = lines[i + 1];
            }

            sort(unsorted);

            Console.WriteLine("Sorted!!");
            //for (int i = 0; i < size; i++)
            //{
            //    Console.WriteLine($"sorted[{i}] = {unsorted[i]}");
            //}
        }
    }
}
