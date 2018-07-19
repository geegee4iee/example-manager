using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgorithms
{
    [ExampleClass(description: "printing base 16 integer algorithm")]
    class PrintBase16Integer
    {
        public static void PrintInt(int number, int baseValue)
        {
            string conversion = "0123456789ABCDEF";
            char digit = (char)(number % baseValue);
            number = number / baseValue;
            if (number != 0)
            {
                PrintInt(number, baseValue);
            }


            Console.Write(" " + conversion[digit]);
        }

        [ExampleMethod]
        public static void Main()
        {
            PrintInt(53444, 16);
        }

    }
}
