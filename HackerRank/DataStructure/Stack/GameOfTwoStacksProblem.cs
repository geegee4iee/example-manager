using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.DataStructure.Stack
{
    [ExampleClass]
    class GameOfTwoStacksProblem
    {
        static int FindLongestChainRecursive(int x, Stack<int> a, Stack<int> b, int sum, int count, int max)
        {

            if (count > max)
            {
                max = count;
            }
            int topA = a.Pop();
            FindLongestChainRecursive(x, a, b, sum + topA, count + 1, max);

            return 0;

        }

        static int FindLongestChain(int x, int[] a, int[] b)
        {
            return 0;
        }
        static void Main()
        {
            int[] a = new int[] { 4, 2, 4, 6, 1 };
            int[] b = new int[] { 2, 1, 8, 5 };
            int x = 10;
        }
    }
}
