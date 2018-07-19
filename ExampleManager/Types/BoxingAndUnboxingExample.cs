using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager.Types
{
    [ExampleClass]
    class BoxingAndUnboxingExample
    {
        static void Main()
        {
            List<object> mixedTypes = new List<object>();

            for (int i = 0; i < 5; i++)
            {
                mixedTypes.Add($"Hello {i}");
            }


            for (int i = 0; i < 5; i++)
            {
                mixedTypes.Add(i);
            }
            
            foreach(var elem in mixedTypes)
            {
                Console.WriteLine($"Type of {elem} is {elem.GetType().ToString()}");
            }
        }
    }
}
