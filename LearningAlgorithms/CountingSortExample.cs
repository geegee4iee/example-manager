using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms
{   
    [ExampleClass]
    class CountingSortExample
    {
        static void Main()
        {
            var arr1 = GetRandomArray(10000, 200);
            var arr2 = GetRandomArray(1000000, 1000);
            var arr3 = GetRandomArray(100000000, 50000);

            var result1 = StopwatchUtil.TimeInMicroSecond(() =>
            {
                Run(arr1, 10000, 200);
            });

            Console.WriteLine($"Size = 10000, range = 200: run time {result1} microseconds");

            var result2 = StopwatchUtil.TimeInMicroSecond(() =>
            {
                Run(arr2, 1000000, 1000);
            });

            Console.WriteLine($"Size = 1000000, range = 1000: run time {result2} microseconds");

            var result3 = StopwatchUtil.TimeInMicroSecond(() =>
            {
                Run(arr3, 100000000, 50000);
            });

            Console.WriteLine($"Size = 10000000, range = 5000: run time {result3} microseconds");

            arr1 = GetRandomArray(10000, 200);
            arr2 = GetRandomArray(1000000, 1000);
            arr3 = GetRandomArray(100000000, 50000);

            var result4 = StopwatchUtil.TimeInMicroSecond(() =>
            {
                Array.Sort<int>(arr1);
            });

            var result5 = StopwatchUtil.TimeInMicroSecond(() =>
            {
                Array.Sort<int>(arr2);
            });

            var result6 = StopwatchUtil.TimeInMicroSecond(() =>
            {
                Array.Sort(arr3);
            });
            Console.WriteLine($"Size = 10000, range = 200: run time {result4} microseconds and {result4/result1} times slower");
            Console.WriteLine($"Size = 1000000, range = 1000: run time {result5} microseconds and {result5/result2} times slower");
            Console.WriteLine($"Size = 10000000, range = 5000: run time {result6} microseconds and {result6/result3} times slower");

        }

        static int[] GetRandomArray(int size, int range)
        {
            int[] arr = new int[size];

            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(range - 1);
            }

            return arr;
        }

        static void Run(int[] arr, int size, int range)
        {
            int[] count = new int[range];

            for(int i = 0; i < size; i++)
            {
                ++count[arr[i]];
            }

            for (int i = 1; i < range; i++)
            {
                count[i] += count[i - 1];
            }

            int[] sortedArr = new int[size];

            for (int i = 0; i < size; i++)
            {
                sortedArr[--count[arr[i]]] = arr[i];
            }
        }
    }
}
