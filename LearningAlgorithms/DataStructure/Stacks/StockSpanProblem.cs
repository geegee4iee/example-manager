using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.DataStructure.Stacks
{
    [ExampleClass]
    class StockSpanProblem
    {
        static int[] FindSpan(int[] dailyStock)
        {

            int[] spans = new int[dailyStock.Length];
            Stack<int> indexStack = new Stack<int>();
            spans[0] = 1;
            indexStack.Push(0);

            for (int i = 1; i < dailyStock.Length; i++)
            {
                while (indexStack.Count != 0 && dailyStock[indexStack.Peek()] <= dailyStock[i])
                {
                    indexStack.Pop();
                }

                spans[i] = indexStack.Count == 0 ? i + 1 : i - indexStack.Peek();

                indexStack.Push(i);
            }

            return spans;

        }

        static void Main()
        {
            int[] dailyStock = new int[] { 100, 80, 60, 70, 60, 75, 85 };
            var spans = FindSpan(dailyStock);

            spans.ToList().ForEach(i => Console.Write(i + " "));
        }
    }
}
