using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms
{
    [ExampleClass]
    class FindMedianOfTwoSortedArraysExample
    {
        static void Main()
        {
            var rnd = new Random();

            int size1 = rnd.Next(10, 15);
            int size2 = rnd.Next(13, 20);

            int[] arr1 = new int[size1];
            int[] arr2 = new int[size2];

            int min = 0;
            int max = min + 2;
            for (int i = 0; i < size1; i++)
            {
                arr1[i] = rnd.Next(min, max);

                Console.Write($"[{arr1[i]}] ");
                min = max + 1;
                max = min + 5;
            }

            Console.WriteLine();

            min = 0;
            max = min + 2;

            for (int i = 0; i < size2; i++)
            {
                arr2[i] = rnd.Next(min, max);

                Console.Write($"[{arr2[i]}]");
                min = max + 1;
                max = min + 5;
            }

            int median = findMedian(arr1, size1, arr2, size2);

            Console.WriteLine($"Median of two arrays is {median}");
        }

        static int findMedian(int[] arrFirst, int sizeFirst, int[] arrSecond, int sizeSecond)
        {
            int
            medianIndex = ((sizeFirst + sizeSecond) + (sizeFirst + sizeSecond) % 2) / 2;
            int
            i = 0, j = 0;
            int
            count = 0;
            while (count < medianIndex - 1)
            {
                if (i < sizeFirst - 1 && arrFirst[i] < arrSecond[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
                count++;
            }
            if
           (arrFirst[i] < arrSecond[j])
            {
                return arrFirst[i];
            }
            else
            {
                return arrSecond[j];
            }
        }
    }
}
