using Core.Infrastructure;
using static Core.Infrastructure.StopwatchUtil;
using Infra = Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.DataStructure
{
    using ClassExample = Infra;
    [ClassExample::ExampleClass]
    class LinkedListExample
    {
        [ClassExample::ExampleMethod(IncludeParams = true)]
        static void Main(int customSize)
        {
            var linkedList = new LinkedList<int>();

            var rnd = new Random();
            int size = customSize > 0 ? customSize : 20000000;

            var insertTime = Time(() =>
            {
                for (int i = 0; i < size; i++)
                {
                    linkedList.AddFirst(rnd.Next(1, 5000));
                }
            });

            Console.WriteLine($"Insert time of linked list for {size} elements: {insertTime.Milliseconds}ms");
            bool containElement = false;
            List<KeyValuePair<int, long>> searchedElements = new List<KeyValuePair<int, long>>();
            for (int i = 0; i < 5; i++)
            {
                int element = rnd.Next(1, 5000);
                
                var searchTime = TimeInMicroSecond(() =>
                {
                    linkedList.Contains(element);
                });

                searchedElements.Add(new KeyValuePair<int, long>(element, searchTime));
            }

            searchedElements.ForEach(kv => Console.WriteLine($"Time to search element {kv.Key} is {kv.Value} microseconds"));

        }
    }
}
