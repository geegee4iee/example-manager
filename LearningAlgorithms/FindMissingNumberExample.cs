using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms
{
    [ExampleClass]
    class FindMissingNumberExample
    {
        static void Main()
        {
            int range = 8, size = range - 1;

            int[] arr = new int[] { 1, 4, 3, 5, 7, 8, 2 };

            int xorSum = 0;
            for (int i = 1; i <= range; i++)
            {
                xorSum ^= i;
            }

            for (int i = 0; i < size; i++)
            {
                xorSum ^= arr[i];
            }

            Console.WriteLine("The missing number is " + xorSum);

        }


    }
}
