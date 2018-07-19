using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.DataStructure.Stacks
{
    [ExampleClass]
    class MaxRectangularAreaInHistogramProblem
    {
        static int GetMaxRectangular(int[] histogram)
        {
            int size = histogram.Length;
            var stk = new Stack<int>();
            int i = 0;
            int maxArea = 0;

            while (i < size)
            {
                while ((i < size) && (stk.Count == 0 || histogram[stk.Peek()] < histogram[i]))
                {
                    stk.Push(i);
                    i++;
                }

                while (stk.Count != 0 && (i == size || histogram[stk.Peek()] >= histogram[i]))
                {
                    int top = stk.Peek();
                    stk.Pop();

                    int span = stk.Count == 0 ? i : i - stk.Peek() - 1;
                    int area = histogram[top] * span;

                    Console.WriteLine($"Calculating the area of column {top}th that spans {span}");
                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }
            }


            return maxArea;
        }

        static void Main()
        {
            int[] histogram = new int[] { 70, 120, 100, 60, 130, 110, 75 };

            var maxArea = GetMaxRectangular(histogram);
        }
    }
}
