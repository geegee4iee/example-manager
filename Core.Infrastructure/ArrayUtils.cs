using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public static class ArrayUtils
    {
        public static int[] GetRandomArray(int size, int? min, int? max)
        {
            int[] arr = new int[size];
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(min ?? 0, max ?? 10000);
            }

            return arr;
        }
    }
}
