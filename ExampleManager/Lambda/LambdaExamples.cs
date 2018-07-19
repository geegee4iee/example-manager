using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager.Lambda
{
    [ExampleClass]
    class LambdaExamples
    {
        static void Main()
        {
            Begin().Wait();
        }

        static async Task Begin()
        {
            var numbers = (2, 3, 4, 5, 6);
            Func<(int, int, int, int, int), int> func = (n) => n.Item1 * n.Item2 * n.Item3 * n.Item4 * n.Item5;

            var a = func(numbers);

            Console.WriteLine(a);
            var (_, b) = GetTuple();
            Console.WriteLine($"{nameof(b)}={b}");
        }

        static (int a, int b) GetTuple()
        {
            return (1, 2);
        }
    }
}
