using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.DataStructure.Queues
{
    [ExampleClass]
    class JosephusProblem
    {
        static int FindTheLastStandPerson(Queue<int> queue, int k)
        {
            while (queue.Count > 1)
            {
                for (int i = 1; i < k; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                queue.Dequeue();
            }


            if (queue.Count == 1)
            {
                return queue.Dequeue();
            }

            return 0;
        }

        static int josephus(int n, int k)
        {
            if (n == 1)
                return 1;
            else
            {
                /* The position returned 
                by josephus(n - 1, k) is
                adjusted because the
                recursive call josephus(n
                - 1, k) considers the 
                original position k%n + 1
                as position 1 */
                var jus = josephus(n - 1, k) + (k - 1);
                var pos = jus % n + 1;

                return pos;
            }
        }
        static void Main()
        {
            Enumerable.Range(1, 7).ToList().ForEach(c => Console.Write(c + " "));
            Queue<int> queue = new Queue<int>(Enumerable.Range(1, 7));
            Console.WriteLine($"The last stand person is {josephus(5, 2)}");


        }
    }
}
