using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms
{
    [ExampleClass]
    class TowerOfHanoi
    {
        public static void RunTowerOfHanoi(int num, char src, char dst, char temp)
        {
            if (num < 1)
            {
                return;
            }

            RunTowerOfHanoi(num - 1, src: src, dst: temp, temp: dst);
            Console.WriteLine("Move " + num + " disk from peg " + src + " to peg " + dst);
            RunTowerOfHanoi(num - 1, src: temp, dst: dst, temp: src);
        }

        public static void Main(string[] args)
        {
            int
            num = 4;
            Console.WriteLine("The sequence of moves in Tower of Hanoi are :\n");
            RunTowerOfHanoi(num, src: 'A', dst: 'C', temp: 'B');
        }
    }
}
