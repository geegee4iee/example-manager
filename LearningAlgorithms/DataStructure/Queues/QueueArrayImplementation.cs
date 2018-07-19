using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms.DataStructure.Queues
{
    [ExampleClass]
    class QueueArrayImplementation
    {
        class Queue
        {
            int front = 0;
            int back = 0;
            int[] data;
            int count = 0;
            int capacity = 4;

            public Queue()
            {
                data = new int[capacity];
            }

            public Queue Enqueue(int value)
            {
                if (count >= capacity)
                {
                    throw new Exception("Queue is full");
                } else
                {
                    count++;
                    data[back] = value;

                    back = (++back) % (capacity - 1);
                }

                return this;
            }

            public int Dequeue()
            {
                if (count <= 0)
                {
                    throw new Exception("Queue is empty");
                } else
                {
                    count--;
                    int value = data[front];

                    front = (++front) % (capacity - 1);

                    return value;
                }
            }
        }
        static void Main()
        {
            var queue = new Queue();

            queue.Enqueue(1).Enqueue(2).Enqueue(3).Enqueue(4);
        }
    }
}
