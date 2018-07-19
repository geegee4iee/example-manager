using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ArrayManipulationCase
{
    [ExampleClass]
    class ArrayManipulation
    {
        // Complete the arrayManipulation function below.
        // Complete the arrayManipulation function below.
        static long arrayManipulation(int n, int[][] queries)
        {
            long[] arr = new long[n + 1];

            for (int i = 0; i < queries.Length; i++)
            {
                arr[queries[i][0]] += queries[i][2];
                if (queries[i][1] + 1 <= n) arr[queries[i][1] + 1] -= queries[i][2];
            }

            long max = 0;
            long tempMax = 0;
            for (int i = 0; i < n; i++)
            {
                tempMax += arr[i];
                if (tempMax > max) max = tempMax;
            }

            return max;
        }

        static void Main()
        {
            string[] lines = File.ReadAllLines($"./ArrayManipulationCase/input07.txt");
            string[] firstLine = lines[0].Split(' ');
            int n = Convert.ToInt32(firstLine[0]);

            int m = Convert.ToInt32(firstLine[1]);

            int[][] queries = new int[m][];

            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(lines[i + 1].Split(' '), temp => Convert.ToInt32(temp));
            }

            long result = arrayManipulation(n, queries);
        }
    }
}
