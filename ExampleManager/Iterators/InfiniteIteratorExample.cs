using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleManager.Iterators
{
    [ExampleClass]
    class InfiniteIteratorExample
    {
        static IEnumerable<int> GetStreamingCollection()
        {
            Console.WriteLine($"GetStreamingCollection is running on thread {Thread.CurrentThread.ManagedThreadId}");
            var rnd = new Random();
            while (true)
            {
                yield return rnd.Next();

                Thread.Sleep(2000);
            }
        }
        static int RunIterator()
        {
            Console.WriteLine($"RunIterator is running on thread {Thread.CurrentThread.ManagedThreadId}");
            foreach(var i in GetStreamingCollection())
            {
                Console.WriteLine($"i={i} on thread {Thread.CurrentThread.ManagedThreadId}");
            }
            return 0;
        }

        static Task<int> RunIteratorAsync() {
            var task = new Task<int>(RunIterator);
            task.Start();
            Console.WriteLine($"RunIteratorAsync is running on thread {Thread.CurrentThread.ManagedThreadId}");

            return task;
        }

        static async Task<int> AnotherTask()
        {
            Console.WriteLine($"AnotherTask is running on thread {Thread.CurrentThread.ManagedThreadId}");
            var a =  RunIteratorAsync();
            var b = RunIteratorAsync();

            Console.WriteLine($"Do something on AnotherTask func");

            await a;
            Console.WriteLine($"Completed AnotherTask func");
            return 0;
        }


        static void Main()
        {
            Console.WriteLine($"Main is running on thread {Thread.CurrentThread.ManagedThreadId}");
            var task = AnotherTask();
            task.Wait();
            

            while (true)
            {
                Console.WriteLine($"Do something on Main func {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(3000);
            }
        }
    }
}
