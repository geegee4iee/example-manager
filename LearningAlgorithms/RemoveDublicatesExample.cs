using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms
{
    [ExampleClass]
    class RemoveDublicatesExample
    {

        static void Main()
        {
            int?[] arr = new int?[] { 1, 1, 2, 3, 4, 4 };
            int size = arr.Length;
            int j = 0;
            int removedElements = 0;
            for (int i = 1; i < size; i++)
            {
                if (arr[i] != arr[j])
                {
                    arr[++j] = arr[i];
                    arr[i] = null;   
                } else
                {
                    removedElements++;
                }
            }

            arr.Take(size - removedElements).ToList().ForEach(i => Console.WriteLine($"[{i}] "));
        }
    }
}
