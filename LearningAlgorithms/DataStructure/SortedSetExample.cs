using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.DataStructure
{
    [ExampleClass]
    public class SortedSetExample
    {
        [ExampleMethod(IncludeParams = true)]
        static void Main(int customSize)
        {
            SortedSet<int> ss = new SortedSet<int>();
            List<int> s = new List<int>();

            int size = 200000;

            if (customSize > 0)
            {
                size = customSize;
            }

            var rd = new Random();

            Console.WriteLine("Start inserting item");
            long sortedSetInsertTime = 0;
            long listInsertTime = 0;
            for (int i = 0; i < size; i++)
            {
                sortedSetInsertTime += StopwatchUtil.TimeInMicroSecond(() =>
                {
                       ss.Add(i);
                });

                listInsertTime += StopwatchUtil.TimeInMicroSecond(() =>
                {
                    s.Add(i);
                });
            }

            Console.WriteLine("Start searching items");
            long sortedSetSearchTime = 0;
            long listSearchTime = 0;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Searching item {i}");
                sortedSetSearchTime += StopwatchUtil.TimeInMicroSecond(() =>
                {
                    ss.Contains(i);
                });

                listSearchTime += StopwatchUtil.TimeInMicroSecond(() =>
                {
                    s.Contains(i);
                });
            }


            Console.WriteLine($"Insert time of sorted set is {sortedSetInsertTime / size} microseconds on average");
            Console.WriteLine($"Insert time of list is {listInsertTime / size} microseconds on average");

            Console.WriteLine($"Search time of sorted set is {sortedSetSearchTime / size} microseconds on average");
            Console.WriteLine($"Search time of list is {listSearchTime / size} microseconds on average");
        }
    }
}
