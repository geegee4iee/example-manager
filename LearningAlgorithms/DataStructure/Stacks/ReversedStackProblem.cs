using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.DataStructure.Stacks
{
    [ExampleClass]
    class ReversedStackProblem
    {

        static void ReverseStack(Stack<int> stk)
        {
            if (stk.Count == 0)
            {
                return;
            }

            var val = stk.Pop();
            ReverseStack(stk);
            InsertValueAtBottomOfTheStack(stk, val);
        }

        static void InsertValueAtBottomOfTheStack(Stack<int> stk, int val)
        {
            if (stk.Count == 0)
            {
                stk.Push(val);
            } else
            {
                int pop = stk.Pop();
                InsertValueAtBottomOfTheStack(stk, val);
                stk.Push(pop);
            }
        }

        static void Main()
        {
            var stack = new Stack<int>();

            Enumerable.Range(0, 10).ToList().ForEach(e => stack.Push(e));

            stack.ToList().ForEach(c => Console.Write(c + " "));
            Console.WriteLine();


            ReverseStack(stack);
            stack.ToList().ForEach(c => Console.Write(c + " "));
            Console.WriteLine();
        }
    }
}
