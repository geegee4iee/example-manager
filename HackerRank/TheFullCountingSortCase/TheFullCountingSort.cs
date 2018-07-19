using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.TheFullCountingSortCase
{
    [ExampleClass]
    class TheFullCountingSort
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines($"./TheFullCountingSortCase/input05.txt");
            string[] firstLine = lines[0].Split(' ');
            int n = Convert.ToInt32(firstLine[0]);

            int[] range = new int[100];
            int[] listOfX = new int[n];
            string[] listOfS = new string[n];

            string[][] list = new string[100][];

            for (int nItr = 0; nItr < n; nItr++)
            {
                string[] xs = lines[nItr + 1].Split(' ');

                listOfX[nItr] = Convert.ToInt32(xs[0]);
                listOfS[nItr] = xs[1];
            }

            for (int i = 0; i < n / 2; i++)
            {
                listOfS[i] = "-";
            }

            for (int i = 0; i < n; i++)
            {
                range[listOfX[i]]++;

                if (list[listOfX[i]] == null)
                {
                    list[listOfX[i]] = new string[2];
                }

                if (range[listOfX[i]] > list[listOfX[i]].Length)
                {
                    string[] temp = list[listOfX[i]];
                    list[listOfX[i]] = new string[list[listOfX[i]].Length * 2];

                    for (int j = 0; j < temp.Length; j++)
                    {
                        list[listOfX[i]][j] = temp[j];
                    }
                }

                list[listOfX[i]][range[listOfX[i]] - 1] = listOfS[i];
            }



            // Sum up position
            /*
            for (int i = 1; i < range.Length; i++) {
                range[i] += range[i - 1];
            }*/

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                int size = range[i];
                while (range[i] > 0)
                {
                    strBuilder.Append(list[i][size - range[i]] + " ");
                    range[i]--;
                }
            }

            Console.Write(strBuilder.ToString());

        }
    }
}
